using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Complaints
{
    /// <summary>
    /// Форма для задания полок при закрытии претензии
    /// </summary>
    public partial class ChooseLocationsForComplaintForm : Form
    {
        #region ПЕРЕМЕННЫЕ И СВОЙСТВА

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private readonly long sessionID;

        /// <summary>
        /// Идентификатор претензии
        /// </summary>
        private readonly long docID;

        /// <summary>
        /// Тип документа заказа
        /// </summary>
        private readonly string orderDocType;

        /// <summary>
        /// № документа заказа
        /// </summary>
        private readonly int? orderDocNumber;

        /// <summary>
        /// Выделенные в таблице строки
        /// </summary>
        private List<Data.Complaints.CO_Get_Transfer_DetailsRow> SelectedRows
        {
            get
            {
                var rows = new List<Data.Complaints.CO_Get_Transfer_DetailsRow>();
                foreach (DataGridViewRow dgvRow in dgvDetails.SelectedRows)
                    rows.Add((dgvRow.DataBoundItem as DataRowView).Row as Data.Complaints.CO_Get_Transfer_DetailsRow);
                return rows;
            }
        }

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ

        public ChooseLocationsForComplaintForm(long pSessionID, long pDocID, string pOrderDocType, int? pOrderDocNumber)
        {
            InitializeComponent();
            sessionID = pSessionID;
            docID = pDocID;
            orderDocType = pOrderDocType;
            orderDocNumber = pOrderDocNumber;
        }

        /// <summary>
        /// Загрузка деталей претензии при загрузке окна
        /// </summary>
        private void ChooseLocationForm_Load(object sender, EventArgs e)
        {
            if (!LoadDetails())
                Close();
        }

        /// <summary>
        /// Загрузка деталей претензии
        /// </summary>
        /// <returns>True если удалось загрузить детали претензии, False если не удалось</returns>
        private bool LoadDetails()
        {
            try
            {
                taCoGetTransferDetails.Fill(complaints.CO_Get_Transfer_Details, sessionID, docID, orderDocNumber, orderDocType);
                return true;
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время загрузки товаров в претензии: ", exc);
                return false;
            }
        }

        #endregion

        #region УСТАНОВКА ПОЛКИ ДЛЯ ТОВАРОВ

        /// <summary>
        /// Кнопка редактирования полок доступна только тогда, когда выделена хотя бы одна строка в таблице
        /// </summary>
        private void dgvDetails_SelectionChanged(object sender, EventArgs e)
        {
            btnChooseLocation.Enabled = dgvDetails.SelectedRows.Count > 0;
        }

        /// <summary>
        /// Выбор полки для выбранных в таблице товаров
        /// </summary>
        private void btnChooseLocation_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedRows = SelectedRows;
                var form = new ChooseLocationForm(sessionID, docID);
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    foreach (var detail in selectedRows)
                        taCoSearchLocations.ChangeReturnDefinedLocation(sessionID, docID, null,
                            Convert.ToInt32(detail.Item_ID),
                            form.SelectedLocation.Location_ID, form.SelectedLocation.Warehouse_ID);
                    LoadDetails();
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Во время установки полок произошла ошибка: ", exc);
            }
        }

        /// <summary>
        /// Выбор полки из выпадающего справочника
        /// </summary>
        /// <returns>Выбранная из справочника полка или null, если полка не выбиралась</returns>
        private Data.Complaints.CO_Search_LocationsRow GetLocationFromDirectory()
        {
            var locations = GetLocations();
            if (locations != null)
            {
                var titles = new Dictionary<string, string>();
                var selectorForm = new ManyItemsChoiceForm(locations, new string[] { "Склад", "Полка" }, ItemsChoiceMode.Single);
                selectorForm.Text = "Выбор полок";
                selectorForm.FilterPattern = "[Warehouse_ID] LIKE '%{0}%' OR [Location_ID] LIKE '%{0}%'";
                selectorForm.ConfigName = "CloseComplaintChooseLocationForm";
                if (selectorForm.ShowDialog(this) == DialogResult.OK)
                    return selectorForm.SelectedRow as Data.Complaints.CO_Search_LocationsRow;
            }

            return null;
        }

        /// <summary>
        /// Загрузка доступных полок
        /// </summary>
        /// <returns>Таблица с доступными полками</returns>
        private Data.Complaints.CO_Search_LocationsDataTable GetLocations()
        {
            try
            {
                return taCoSearchLocations.GetData(sessionID, null, docID, null);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Во время загрузки доступных полок произошла ошибка: ", exc);
                return null;
            }
        }

        #endregion

        #region ЗАКРЫТИЕ ОКНА С ПОЛОЖИТЕЛЬНЫМ РЕЗУЛЬТАТОМ

        /// <summary>
        /// Задали все полки - закрываем окно чтобы дальше закрыть претензию
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        /// <summary>
        /// Проверка, заданы ли полки для всех строк
        /// </summary>
        /// <returns>True если заданы полки для всех строк, False если есть незаполненные полки</returns>
        private bool ValidateData()
        {
            string msg = String.Empty;
            foreach (var row in complaints.CO_Get_Transfer_Details)
            {
                var detail = row as Data.Complaints.CO_Get_Transfer_DetailsRow;
                if (detail.IsLocationNull() || String.IsNullOrEmpty(detail.Location))
                {
                    msg = "Полка должна быть задана для всех строк в претензии!";
                    break;
                }
            }

            if (!String.IsNullOrEmpty(msg))
            {
                MessageBox.Show(msg, "Проверка данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
                return true;
        }

        #endregion
    }
}
