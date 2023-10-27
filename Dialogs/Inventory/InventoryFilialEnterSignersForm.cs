using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;
using System.Windows.Forms;

using WMSOffice.Data.InventoryTableAdapters;

namespace WMSOffice.Dialogs.Inventory
{
    /// <summary>
    /// Окно для внесения данных по номеру/дате приказа и членов комиссии
    /// </summary>
    public partial class InventoryFilialEnterSignersForm : Form
    {
        #region ОСНОВНЫЕ ПЕРЕМЕННЫЕ И СВОЙСТВА

        /// <summary>
        /// Редактируемая инвентаризацияы
        /// </summary>
        private readonly Data.Inventory.FI_Get_Inventory_ListsRow currentInv;

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private readonly int sessionID;

        /// <summary>
        /// Строка с идентификаторами выбранных членов комиссии
        /// </summary>
        private string MembersList
        {
            get
            {
                string slist = String.Empty;
                foreach (Data.Inventory.FI_Get_Elements_For_SignersRow row in inventory1.FI_Get_Elements_For_Signers)
                    if (!row.Checked)
                    {
                        if (slist.Length > 0)
                            slist += ",";
                        slist += row.Employee_ID;
                    }
                
                return slist;
            }
        }

        /// <summary>
        /// Председатель комиссии
        /// </summary>
        private string Chairman
        {
            get
            {
                foreach (Data.Inventory.FI_Get_Elements_For_SignersRow row in inventory1.FI_Get_Elements_For_Signers)
                    if (row.Checked)
                        return row.Employee_ID.ToString();

                return String.Empty;    // Председатель не указан
            }
        }

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ

        public InventoryFilialEnterSignersForm(Data.Inventory.FI_Get_Inventory_ListsRow pInventory, int pSessionID)
        {
            InitializeComponent();
            currentInv = pInventory;
            sessionID = pSessionID;
            tbxOrderNumber.Text = pInventory.Direction_Number;
            if (!pInventory.IsDirection_DateNull())
                dtpOrderDate.Value = pInventory.Direction_Date;
        }

        /// <summary>
        /// Загрузка сотрудников при загрузке формы
        /// </summary>
        private void InventoryFilialEnterSignersForm_Load(object sender, EventArgs e)
        {
            LoadEmployeeList();
            LoadExistedEmployees();
        }

        /// <summary>
        /// Загрузка списка сотрудников
        /// </summary>
        private void LoadEmployeeList()
        {
            try
            {
                taFiGetElementsForSigners.Fill(inventory.FI_Get_Elements_For_Signers, sessionID, null, null);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Ошибка при загрузке списка доступных сотрудников!", exc);
            }
        }

        /// <summary>
        /// Загрузка сотрудников, которые на данный момент выбраны как члены комиссии
        /// </summary>
        private void LoadExistedEmployees()
        {
            try
            {
                taFiGetElementsForSigners.Fill(inventory1.FI_Get_Elements_For_Signers, sessionID, currentInv.Inventory_number,
                    "Inventory_Report");
                foreach (Data.Inventory.FI_Get_Elements_For_SignersRow row in inventory1.FI_Get_Elements_For_Signers)
                    if (row.Signer_Type == "chairman")
                    {
                        row.Checked = true;
                        break;
                    }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Ошибка при загрузке списка членов комиссии!", exc);
            }
        }

        #endregion

        #region ФИЛЬТРАЦИЯ СОТРУДНИКОВ

        /// <summary>
        /// Фильтр по названию или коду сотрудника
        /// </summary>
        private string filter = String.Empty;

        /// <summary>
        /// Делегат для асинхронного вызова фильтрации
        /// </summary>
        private delegate void Method();

        /// <summary>
        /// Если изменяется текст в фильтре, перезапускаем таймер
        /// </summary>
        private void tbNameFilter_TextChanged(object sender, EventArgs e)
        {
            filter = tbNameFilter.Text;
            delayTimer.Stop();
            delayTimer.Start();
        }

        /// <summary>
        /// Если нажали Enter - запускаем фильтрацию
        /// </summary>
        private void tbNameFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                delayTimer.Stop();
                RefreshFilters();
            }
        }

        /// <summary>
        /// Таймер сработал - значит значение в фильтр уже введено
        /// </summary>
        private void delayTimer_Tick(object sender, EventArgs e)
        {
            dgvEmployees.Invoke(new Method(RefreshFilters));
        }

        /// <summary>
        /// Обновление фильтра
        /// </summary>
        private void RefreshFilters()
        {
            try
            {
                if (String.IsNullOrEmpty(filter))
                    bsFiGetElementsForSigners.Filter = String.Empty;
                else
                    bsFiGetElementsForSigners.Filter =
                        String.Format("[Employee_Name] LIKE '%{0}%'", filter);
            }
            catch { }   // Нам тут не важно, какая ошибка - главное чтобы не слетала программа
        }

        #endregion

        #region ДОБАВЛЕНИЕ/УДАЛЕНИЕ СОТРУДНИКОВ

        /// <summary>
        /// Добавление членов комиссии в список
        /// </summary>
        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvEmployees.SelectedRows)
            {
                var dbrow = (row.DataBoundItem as DataRowView).Row as Data.Inventory.FI_Get_Elements_For_SignersRow;
                if (!IsEmployeeInList(dbrow))
                    inventory1.FI_Get_Elements_For_Signers.Rows.Add(dbrow.Employee_ID, dbrow.Employee_Name);
            }
        }

        /// <summary>
        /// Проверка, есть ли заданный сотрудник в списке членов комиссии
        /// </summary>
        /// <param name="pEmployee">Сотрудник, которого проверяем на вхождение в члены комиссии</param>
        /// <returns>True, если сотрудник есть в списке членов комиссии, False в противном случае</returns>
        private bool IsEmployeeInList(Data.Inventory.FI_Get_Elements_For_SignersRow pEmployee)
        {
            foreach (Data.Inventory.FI_Get_Elements_For_SignersRow row in inventory1.FI_Get_Elements_For_Signers)
                if (row.Employee_ID == pEmployee.Employee_ID)
                    return true;
            return false;
        }

        /// <summary>
        /// Удаление членов комиссии из списка
        /// </summary>
        private void btnRemoveEmployee_Click(object sender, EventArgs e)
        {
            var selectedIds = new List<int>();
            foreach (DataGridViewRow row in dgvInvEmployee.SelectedRows)
                selectedIds.Add(((row.DataBoundItem as DataRowView).Row as Data.Inventory.FI_Get_Elements_For_SignersRow).Employee_ID);
            
            for (int i = 0; i < inventory1.FI_Get_Elements_For_Signers.Count; i++)
                if (inventory1.FI_Get_Elements_For_Signers[i].RowState != DataRowState.Deleted &&
                    selectedIds.Contains(inventory1.FI_Get_Elements_For_Signers[i].Employee_ID))
                    inventory1.FI_Get_Elements_For_Signers[i].Delete();
            inventory1.AcceptChanges();
        }

        /// <summary>
        /// Снятие флажков со всех членов комиссии при отмечании флажка
        /// </summary>
        private void dgvInvEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvInvEmployee.CommitEdit(DataGridViewDataErrorContexts.Commit);

            if (e.ColumnIndex == 0)
            {
                var row = dgvInvEmployee.Rows[e.RowIndex];
                var dbrow = (row.DataBoundItem as DataRowView).Row as Data.Inventory.FI_Get_Elements_For_SignersRow;
                foreach (Data.Inventory.FI_Get_Elements_For_SignersRow r in inventory1.FI_Get_Elements_For_Signers)
                    if (!(r.Employee_ID == dbrow.Employee_ID) && r.Checked)
                        r.Checked = false;
            }
        }

        #endregion

        #region СОХРАНЕНИЕ РЕЗУЛЬТАТА

        /// <summary>
        /// Сохранение результата при нажатии на кнопку ОК
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    taFiGetElementsForSigners.AddInventoryDirection(sessionID, currentInv.Inventory_number,
                        tbxOrderNumber.Text, dtpOrderDate.Value);
                    taFiGetElementsForSigners.AddInventoryReportSigners(sessionID, currentInv.Inventory_number,
                            "member", MembersList);
                    taFiGetElementsForSigners.AddInventoryReportSigners(sessionID, currentInv.Inventory_number,
                            "chairman", Chairman);
                    scope.Complete();
                    Close();
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Ошибка при сохранении данных по инвентаризации!", exc);
            }
        }

        /// <summary>
        /// Закрытие окна - останов таймера поиска
        /// </summary>
        private void InventoryFilialEnterSignersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            delayTimer.Stop();
            delayTimer.Dispose();
        }

        #endregion
    }
}
