using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

using WMSOffice.Controls;
using WMSOffice.Data.InventoryTableAdapters;

namespace WMSOffice.Dialogs.Inventory
{
    /// <summary>
    /// Форма для запуска проверок по инвентаризации
    /// </summary>
    public partial class InventoryFilialCheckForm : Form
    {
        #region ОСНОВНЫЕ ПЕРЕМЕННЫЕ И СВОЙСТВА КЛАССА

        /// <summary>
        /// Идентификатор инвентаризации, по которой запускаются проверки
        /// </summary>
        private long inventoryId;

        /// <summary>
        /// Коллекция идентификаторов отмеченных проверок
        /// </summary>
        private List<int> checkedCol = new List<int>();

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ КЛАССА

        public InventoryFilialCheckForm(long pInventoryId)
        {
            InitializeComponent();
            inventoryId = pInventoryId;
            CustomCheckHeader();
        }

        /// <summary>
        /// Настройка заголовка для CheckBox-колонки таблицы проверок тоже в виде CheckBox-а
        /// </summary>
        private void CustomCheckHeader()
        {
            var checkHeaderCell = new DataGridViewHeaderCheckBoxCell();
            checkHeaderCell.OnCheckBoxClicked += checkHeaderCell_OnCheckBoxClicked;
            checkHeaderCell.Value = String.Empty;
            dgvChecks.Columns["Checked"].HeaderCell = checkHeaderCell;
        }

        /// <summary>
        /// Выбор/снятие флажка со всех строк при выборе флажка в заголовке колонки
        /// </summary>
        /// <param name="pState">True, если флажок в заголовке был выбран, False - если снят</param>
        public void checkHeaderCell_OnCheckBoxClicked(bool pState)
        {
            checkedCol.Clear();
            foreach (Data.Inventory.FI_ChecksListRow row in inventory.FI_ChecksList)
            {
                row.Checked = pState;
                if (pState)
                    checkedCol.Add(row.Check_ID);
            }

            dgvChecks.RefreshEdit();
            bsFiChecksList.ResetBindings(false);
            btnRun.Enabled = checkedCol.Count > 0;
        }

        /// <summary>
        /// Загрузка допустимых проверок при загрузке формы
        /// </summary>
        private void InventoryFilialCheckForm_Load(object sender, EventArgs e)
        {
            RefreshChecksList();
            timerCheck.Start();
        }

        /// <summary>
        /// Перезагрузка допустимых проверок
        /// </summary>
        private void RefreshChecksList()
        {
            try
            {
                using (var adapter = new FI_ChecksListTableAdapter())
                {
                    inventory.FI_ChecksList.Clear();
                    adapter.Fill(inventory.FI_ChecksList, (int)inventoryId);
                    foreach (WMSOffice.Data.Inventory.FI_ChecksListRow row in inventory.FI_ChecksList.Rows)
                        if (checkedCol.Contains(row.Check_ID))
                            row.Checked = true;
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Не удалось загрузить список допустимых проверок:", exc);
            }
        }

        #endregion

        #region ТАЙМЕР ОБНОВЛЕНИЯ ТЕКУЩЕГО СОСТОЯНИЯ ПРОВЕРОК

        /// <summary>
        /// Обновление текущего состояния проверки
        /// </summary>
        private void timerCheck_Tick(object sender, EventArgs e)
        {
            RefreshChecksList();
        }

        #endregion

        #region СОБЫТИЯ

        /// <summary>
        /// Сохранение во внешней переменной отмеченности проверки
        /// </summary>
        private void dgvChecks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvChecks.Columns["Checked"] != dgvChecks.Columns[e.ColumnIndex])
                return;
            
            dgvChecks.CommitEdit(DataGridViewDataErrorContexts.Commit);
            if (Convert.ToBoolean(dgvChecks.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue))
                checkedCol.Add(Convert.ToInt32(dgvChecks.Rows[e.RowIndex].Cells["checkID"].Value));
            else
                checkedCol.Remove(Convert.ToInt32(dgvChecks.Rows[e.RowIndex].Cells["checkID"].Value));
            btnRun.Enabled = checkedCol.Count > 0;
        }

        /// <summary>
        /// Установка нужной иконки состояния проверки
        /// </summary>
        private void dgvChecks_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (dgvChecks.Columns["clmImage"] != dgvChecks.Columns[e.ColumnIndex])
                    return;

                var statusId = Convert.ToInt32(dgvChecks.Rows[e.RowIndex].Cells["Status_ID"].Value);
                switch (statusId)
                {
                    case 1:
                        e.Value = imageList.Images["status-offline.png"];
                        break;
                    case 2:
                        e.Value = imageList.Images["ok.png"];
                        break;
                    case 3:
                    case 6:
                        e.Value = imageList.Images["status-error.png"];
                        break;
                    case 4:
                        e.Value = imageList.Images["status-warn.png"];
                        break;
                    case 5:
                        e.Value = imageList.Images["status-ok.png"];
                        break;
                    default:
                        e.Value = imageList.Images["status-offline.png"];
                        break;
                }
            }
            catch { }
        }

        /// <summary>
        /// Немедленное выполнение данных о состоянии проверок
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            timerCheck.Stop();
            RefreshChecksList();
            timerCheck.Start();
        }

        #endregion

        #region ЗАПУСК ПРОВЕРОК

        /// <summary>
        /// Запуск выбранных проверок
        /// </summary>
        private void btnRun_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Запустить выполнение выбранных проверок?", "Запуск", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                var sb = new StringBuilder();
                foreach (var item in checkedCol)
                    sb.Append(sb.Length == 0 ? item.ToString() : String.Format(",{0}", item));
                using (var adapter = new FI_ChecksListTableAdapter())
                    adapter.AddCheck((int)inventoryId, sb.ToString());

                checkedCol.Clear();
                btnRun.Enabled = false;
                timerCheck.Stop();
                RefreshChecksList();
                timerCheck.Start();

            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время запуска проверок:", exc);
            }
        }

        #endregion

        #region ОТОБРАЖЕНИЕ ИНФОРМАЦИИ О ПРОВЕРКАХ

        /// <summary>
        /// Отображение информации о проверках по двойному клику на строке
        /// </summary>
        private void dgvChecks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvChecks.Columns["Checked"] == dgvChecks.Columns[e.ColumnIndex] || dgvChecks.SelectedRows.Count == 0)
                return;

            var cursor = Cursor;

            try
            {
                var ret = Convert.ToInt32(dgvChecks.Rows[e.RowIndex].Cells["Status_ID"].Value);
                
                if (ret == 1)
                {
                    MessageBox.Show("Результатов проверки нет.\n\rПроверка не выполнялась", "Детали", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (ret == 2)
                {
                    MessageBox.Show("Результатов проверки нет.\n\rПроверка не завершена", "Детали", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Cursor = Cursors.WaitCursor;
                var source = GetDataSourceForCheckDetails((int)inventoryId, Convert.ToInt32(dgvChecks.Rows[e.RowIndex].Cells["checkID"].Value));
                if (source == null)
                    return;
                Cursor = cursor;
                var dlg = new InventoryCheckDetailDialog()
                {
                    Owner = this,
                    DataSource = source,
                    Text = String.Format("Детали [{0}]", dgvChecks.Rows[e.RowIndex].Cells["checkDsc"].Value.ToString())
                };
                dlg.ShowDialog();
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Во время отображения деталей возникла ошибка:", exc);
            }
            finally
            {
                Cursor = cursor;
            }
        }

        /// <summary>
        /// Получение данных для окна просмотра деталей проверки
        /// </summary>
        /// <param name="pInventoryId">Идентификатор инвентаризации</param>
        /// <param name="pCheckId">Идентификатор проверки</param>
        /// <returns>Таблица с данными о проверке (используем Command, а не подключаемый адаптер, 
        /// потому что для каждой проверки набор возвращаемых колонок может быть разным</returns>
        private DataTable GetDataSourceForCheckDetails(int pInventoryId, int pCheckId)
        {
            var dta = new FI_ChecksListTableAdapter();  // Этот адаптер создаем только для того, чтобы взять оттуда Connection
            var cmd = new SqlCommand()
            {
                Connection = dta.Connection,
                CommandText = "[dbo].[pr_FI_Get_Check_Details]",
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@inventory_id", pInventoryId);
            cmd.Parameters.AddWithValue("@check_id", pCheckId);

            var ds = new DataSet();
            var da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            if (ds.Tables.Count == 0)
                return null;
            else
                return ds.Tables[0];
        }

        #endregion
    }
}
