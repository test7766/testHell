using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml;

using WMSOffice.Classes;
using WMSOffice.Data.ComplaintsTableAdapters;

namespace WMSOffice.Dialogs.Complaints
{
    /// <summary>
    /// Диалог для корректировки количеств в составе претензии.
    /// </summary>
    public partial class EditComplaintForm : Form
    {
        #region ОСНОВНЫЕ ПЕРЕМЕННЫЕ И СВОЙСТВА

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private readonly long sessionID;

        /// <summary>
        /// Корректируемая претензия
        /// </summary>
        private readonly Data.Complaints.CurrentDocsRow complaintRow;

        /// <summary>
        /// Таблица-копия исходного содержимого претензии (для сверки)
        /// </summary>
        private Data.Complaints.DocRequestDetailsDataTable originalTable;

        /// <summary>
        /// Признак, который показывает, может ли пользователь менять полку для строк претензий
        /// </summary>
        private readonly bool canChangeLocation;

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ КЛАССА

        /// <summary>
        /// Инициализирует новый экземпляр диалога.
        /// </summary>
        /// <param name="sessionID">Идентификатор пользовательской сессии.</param>
        /// <param name="headerRow">Ссылка на строку с данными заголовка претензии.</param>
        public EditComplaintForm(long pSessionID, Data.Complaints.CurrentDocsRow pComplaintRow, 
            bool pCanEdit, bool pCanChangeLocation)
        {
            if (pComplaintRow == null)
                throw new ArgumentNullException("Параметр pComplaintRow равен NULL!");

            InitializeComponent();
            sessionID = pSessionID;
            complaintRow = pComplaintRow;
            canChangeLocation = pCanChangeLocation;
            dgvComplaintDetails.ReadOnly = !pCanEdit;
            CustomCommonInfo();
        }

        /// <summary>
        /// Заполнение заголовка с общими данными по претензии
        /// </summary>
        private void CustomCommonInfo()
        {
            lblDocID.Text = complaintRow.Doc_ID.ToString();
            lblDocType.Text = String.Format("({0}) {1}", complaintRow.Doc_Type, complaintRow.Doc_Type_Name);
            lblDocStatus.Text = String.Format("({0}) {1}", complaintRow.Status_ID, complaintRow.Status_Name);
            lblContactName.Text = complaintRow.IsContact_NameNull() ? "-" : complaintRow.Contact_Name;
            txbComment.Text = complaintRow.IsCommentNull() ? "-" : complaintRow.Comment;
        }

        /// <summary>
        /// Загрузка строк претензии при загрузке окна
        /// </summary>
        private void EditComplaintForm_Load(object sender, EventArgs e)
        {
            RefreshDetails();
            btnChangeLocation.Focus();
        }

        /// <summary>
        /// Обновление строк в таблице
        /// </summary>
        private void RefreshDetails()
        {
            try
            {
                taDocRequestDetails.Fill(complaints.DocRequestDetails, sessionID, complaintRow.Doc_ID);
                originalTable = complaints.DocRequestDetails.Copy() as Data.Complaints.DocRequestDetailsDataTable;
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка при загрузке строк претензии: ", exc);
            }
        }

        #endregion

        #region КОРРЕКТИРОВКА КОЛИЧЕСТВА ТОВАРОВ В ПРЕТЕНЗИИ

        /// <summary>
        /// Сохранение откорректированных строк претензии
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите сохранить изменения в претензии? ", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;
            try
            {
                dgvComplaintDetails.EndEdit();
                if (!HasChangedRows())
                    MessageBox.Show("В претензии не была изменена ни одна строка!", "Корректировка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    using (var adapter = new CurrentDocsTableAdapter())
                    {
                        if (complaintRow.Doc_Type.ToUpper() == "EX")
                            adapter.ChangeDocDetailsSurplus(sessionID, complaintRow.Doc_ID, GetXML());
                        else
                            adapter.ChangeDocDetails(sessionID, complaintRow.Doc_ID, GetXML());
                        DialogResult = DialogResult.OK;
                        Close();
                    }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Во время корректировки претензии возникла следующая ошибка:", exc);
            }
        }

        /// <summary>
        /// Проверка, была ли изменена хотя бы одна строка в претензии
        /// </summary>
        /// <returns>True если была изменена хотя бы одна строка в претензии, False если нет
        /// (сохранять изменения можно только тогда, когда претензия была изменена)</returns>
        private bool HasChangedRows()
        {
            foreach (Data.Complaints.DocRequestDetailsRow editedRow in complaints.DocRequestDetails.Rows)
                foreach (Data.Complaints.DocRequestDetailsRow originalRow in originalTable)
                    if (originalRow.Detail_ID == editedRow.Detail_ID && originalRow.Quantity != editedRow.Quantity)
                        return true;    // нашли измененную строку

            return false;   // изменений не найдено
        }

        /// <summary>
        /// Генерирует XML, содержащий состав откорректированной претензии.
        /// </summary>
        /// <returns>XML, содержащий состав откорректированной претензии.</returns>
        private string GetXML()
        {
            /* пример генерируемого XML с одной строкой состава:
             * <WMS><Complaint><Body><Details>
             *      <d Detail_ID="12345" Quantity="3" />
             * </Details></Body></Complaint></WMS>
             * */

            var resultXml = new StringBuilder();
            var smlWriter = XmlWriter.Create(resultXml);
            smlWriter.WriteStartDocument();
            smlWriter.WriteStartElement("WMS");
            smlWriter.WriteStartElement("Complaint");
            smlWriter.WriteStartElement("Body");
            smlWriter.WriteStartElement("Details");

            foreach (Data.Complaints.DocRequestDetailsRow row in complaints.DocRequestDetails.Rows)
            {
                smlWriter.WriteStartElement("d");
                smlWriter.WriteAttributeString("Detail_ID", row.Detail_ID.ToString());
                smlWriter.WriteAttributeString("Quantity", row.Quantity.ToString());
                smlWriter.WriteEndElement();
            }

            smlWriter.WriteEndElement();
            smlWriter.WriteEndElement();
            smlWriter.WriteEndElement();
            smlWriter.WriteEndElement();
            smlWriter.WriteEndDocument();
            smlWriter.Close();

            return resultXml.ToString();
        }

        #endregion

        #region ОПРЕДЕЛЕНИЕ ПОЛКИ ДЛЯ ТОВАРОВ

        /// <summary>
        /// Определение полки для выделенных товаров
        /// </summary>
        private void btnChangeLocation_Click(object sender, EventArgs e)
        {
            var locn = GetLocationFromDirectory();
            if (locn == null)
                return;

            try
            {
                var selectedRow = (dgvComplaintDetails.SelectedRows[0].DataBoundItem as DataRowView).Row as
                    Data.Complaints.DocRequestDetailsRow;
                using (var adapter = new CO_Search_LocationsTableAdapter())
                    adapter.ChangeReturnDefinedLocation(sessionID, complaintRow.Doc_ID, complaintRow.First_Doc_ID,
                        selectedRow.Item_ID, locn.Location_ID, locn.Warehouse_ID);
                selectedRow.Location = locn.Location_ID;
                MessageBox.Show("Полка успешно изменена!", "Корректировка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время изменения полки для товара: ", exc);
            }
        }

        /// <summary>
        /// Выбор полки из справочника
        /// </summary>
        private Data.Complaints.CO_Search_LocationsRow GetLocationFromDirectory()
        {
            var locs = GetLocationsForSelectedItem();
            if (locs == null)
                return null;

            var choiceForm = new ManyItemsChoiceForm(locs, new string[] { "Склад", "Полка" }, ItemsChoiceMode.Single);
            choiceForm.Text = "Выбор полки";
            choiceForm.ConfigName = "ComplaintsLocationSelectorForm";
            choiceForm.FilterPattern = "[Warehouse_ID] LIKE '%{0}%' OR [Location_ID] LIKE '%{0}%'";
            if (choiceForm.ShowDialog(this) == DialogResult.OK)
                return choiceForm.SelectedRow as Data.Complaints.CO_Search_LocationsRow;
            else return null;
        }

        /// <summary>
        /// Получает доступные для выбора полки для выделенной строки в таблице
        /// </summary>
        /// <returns>Таблица с доступными для выбора полками</returns>
        private Data.Complaints.CO_Search_LocationsDataTable GetLocationsForSelectedItem()
        {
            try
            {
                var selectedRow = (dgvComplaintDetails.SelectedRows[0].DataBoundItem as DataRowView).Row as
                    Data.Complaints.DocRequestDetailsRow;
                using (var adapter = new CO_Search_LocationsTableAdapter())
                    return adapter.GetData(sessionID, selectedRow.Item_ID, complaintRow.Doc_ID, null);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время получения полок, доступных для выбора: ", exc);
                return null;
            }
        }

        /// <summary>
        /// Настройка доступности кнопки "Изменить полку" в зависимости от выбранных в таблице товаров
        /// </summary>
        private void dgvComplaintDetails_SelectionChanged(object sender, EventArgs e)
        {
            btnChangeLocation.Enabled = dgvComplaintDetails.SelectedRows.Count == 1 && canChangeLocation;
        }

        #endregion
    }
}
