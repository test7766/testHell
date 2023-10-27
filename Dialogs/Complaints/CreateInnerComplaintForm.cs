using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Windows.Forms.VisualStyles;
using WMSOffice.Window;
using WMSOffice.Classes;
using WMSOffice.Data.ComplaintsTableAdapters;
using System.IO;
using WMSOffice.Controls;
using WMSOffice.Controls.Complaints;

namespace WMSOffice.Dialogs.Complaints
{
    /// <summary>
    /// Диалог для создания новой претензии.
    /// </summary>
    public partial class CreateInnerComplaintForm : Form
    {
        /// <summary>
        /// Таймаут для операции взаимодействия с БД
        /// </summary>
        private const int DEFAULT_RESPONSE_TIMEOUT = 600; // 60*5

        /// <summary>
        /// Код компании (KCOO).
        /// </summary>
        public const string CompanyKey = "00001";

        /// <summary>
        /// Возвращает / устанавливает идентификатор пользовательской сессии.
        /// </summary>
        private long SessionID { get; set; }
        /// <summary>
        /// Возвращает / устанавливает идентификатор типа создаваемой претензии.
        /// </summary>
        private string DocTypeID { get; set; }
        /// <summary>
        /// Возвращает / устанавливает код адреса доставки из последней найденной накладной.
        /// </summary>
        private int? DeliveryCode { get; set; }
        /// <summary>
        /// Возвращает / устанавливает тип последней найденной накладной.
        /// </summary>
        private string InvoiceType { get; set; }
        /// <summary>
        /// Возвращает / устанавливает номер последней найденной накладной.
        /// </summary>
        private double? InvoiceNumber { get; set; }
        /// <summary>
        /// Возвращает / устанавливает идентификатор претензии, выбранной для связи.
        /// </summary>
        private long? LinkedDocID { get; set; }

        /// <summary>
        /// Название типа претензии
        /// </summary>
        private string docTypeName;

        /// <summary>
        /// Пустое изображение
        /// </summary>
        private readonly static Bitmap emptyIcon = new Bitmap(16, 16);

        /// <summary>
        /// Файлы, прикрепленные к претензии
        /// </summary>
        private List<Data.Complaints.AttachmentsRow> attachedFiles = new List<Data.Complaints.AttachmentsRow>();

        private static Bitmap AttachImage
        {
            get
            {
                Bitmap b = new Bitmap(16, 16);
                Graphics g = Graphics.FromImage((Image)b);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(Properties.Resources.paperclip, 0, 0, 16, 16);
                g.Dispose();
                return b;
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр диалога.
        /// </summary>
        /// <param name="sessionID">Идентификатор пользовательской сессии.</param>
        public CreateInnerComplaintForm(long sessionID, string pDocTypeID, string pDocTypeName)
        {
            InitializeComponent();

            this.SessionID = sessionID;
            this.DeliveryCode = null;
            this.InvoiceType = null;
            this.InvoiceNumber = null;
            this.LinkedDocID = null;
            DocTypeID = pDocTypeID;
            docTypeName = pDocTypeName;

            cbComplaintType.SelectedIndex = 0;

            var useFullMode = 0;
            availableWarehousesTableAdapter.Fill(complaints.AvailableWarehouses, sessionID, useFullMode);

            dtpDateReceivedFromClient.Value = DateTime.Now;
            dtpDateForecastSolution.Value = DateTime.Today.AddDays(1);

            dgvInvoiceLines.Columns[colCheckBox.Index].HeaderCell = new DatagridViewCheckBoxHeaderCell(false);
            ((DatagridViewCheckBoxHeaderCell)dgvInvoiceLines.Columns[colCheckBox.Index].HeaderCell).CheckBoxClicked += CheckBoxHeaderCell_OnCheckBoxClicked;
        }

        /// <summary>
        /// Обрабатывает момент первого отображения диалога, предлагая выбрать тип претензии.
        /// </summary>
        private void CreateInnerComplaintForm_Shown(object sender, EventArgs e)
        {
            CustomSubtypeComboBox();

            cbComplaintType.Items[0] = docTypeName;
            if (DocTypeID == "NR" || DocTypeID == "CN" || DocTypeID == "VR")
                clmIsCold.Visible = clmAttachImage.Visible = clmButton.Visible = true;

            if (DocTypeID == "VR")
                cBPayConditions.Visible = lblPayConditions.Visible = true;

            // плановая дата решения
            using (Data.ComplaintsTableAdapters.QueriesTableAdapter adapter = new Data.ComplaintsTableAdapters.QueriesTableAdapter())
            {
                dtpDateForecastSolution.Value = (DateTime)adapter.GetPlanDateForNewDoc(DocTypeID);
            }

            dtpDateForecastSolution.Enabled = DocTypeID.Equals(ComplaintsConstants.ComplaintDocTypeFactoryFlaw, StringComparison.InvariantCultureIgnoreCase);
            
            tbSourceAddressCode.Enabled = false;
            
            tbDestAddressCode.Enabled = DocTypeID.Equals(ComplaintsConstants.ComplaintDocTypeVirtualRefuse, StringComparison.InvariantCultureIgnoreCase);
            btnAddItem.Enabled = DocTypeID.Equals(ComplaintsConstants.ComplaintDocTypeExcess, StringComparison.InvariantCultureIgnoreCase);
            btnSearchVendorLotFact.Enabled = DocTypeID.Equals(ComplaintsConstants.ComplaintDocTypeRegrade, StringComparison.InvariantCultureIgnoreCase);
        }

        #region РЕДАКТИРОВАНИЕ ИНФОРМАЦИИ О ПОДТИПАХ ВОЗВРАТОВ

        /// <summary>
        /// Идентификатор ответственного сотрудника
        /// </summary>
        private int faultEmployeeID = 0;

        /// <summary>
        /// Массив с названиями файлов, которые нужно вложить в претензию
        /// </summary>
        private string[] fileNames = new string[0];

        /// <summary>
        /// № документа-вложения
        /// </summary>
        private string attachDocumentNumber = null;

        /// <summary>
        /// Дата документа-вложения
        /// </summary>
        private DateTime? attachDocumentDate = (DateTime?)null;

        /// <summary>
        /// Тип документа-вложения
        /// </summary>
        private string attachDescriptionType = null;

        /// <summary>
        /// Сумма с НДС документа-вложения
        /// </summary>
        private double? attachDocumentAmount = (double?)null;

        /// <summary>
        /// Признак оплаты документа-вложения Поставщиком
        /// </summary>
        private bool? attachDocumentIsVendorPayer = (bool?)null;

        /// <summary>
        /// Если тип претензии - не "Возврат", то не отображаем выпадающий список с подтипами
        /// </summary>
        private void CustomSubtypeComboBox()
        {
            if (NeedSubtypes)
                LoadComplaintSubtypes();
            else
                HideSubtypesCombobox();

            CustomSubtypeInfoPanel();
        }

        /// <summary>
        /// True если для данного типа претензии есть подтипы, False в противном случае
        /// </summary>
        private bool NeedSubtypes { get { return DocTypeID == Constants.CO_DT_REFUSE || DocTypeID == Constants.CO_DT_CANCELLATION; } }

        /// <summary>
        /// Загрузка всех возможных подтипов претензии (для отображения в выпадающем списке)
        /// </summary>
        private void LoadComplaintSubtypes()
        {
            try
            {
                taCoGetAvailableDocsSubtypes.Fill(complaints.CO_Get_Available_Docs_Subtypes, SessionID, DocTypeID, null);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время загрузки подтипов претензии: ", exc);
            }
        }

        /// <summary>
        /// Сокрытие выпадающего списка с подтипами для тех типов претензий, у которых нет подтипов
        /// </summary>
        private void HideSubtypesCombobox()
        {
            lblSubtype.Enabled = lblSubtype.Visible = cmbSubtype.Enabled = cmbSubtype.Visible = false;
            int diff = 199;
            lblDateReceivedFromClient.Location = new Point(lblDateReceivedFromClient.Location.X - diff,
                lblDateReceivedFromClient.Location.Y);
            dtpDateReceivedFromClient.Location = new Point(dtpDateReceivedFromClient.Location.X - diff,
                dtpDateReceivedFromClient.Location.Y);
            lblDateForecastSolution.Location = new Point(lblDateForecastSolution.Location.X - diff,
                lblDateForecastSolution.Location.Y);
            dtpDateForecastSolution.Location = new Point(dtpDateForecastSolution.Location.X - diff,
                dtpDateForecastSolution.Location.Y);
            lblPayConditions.Location = new Point(lblPayConditions.Location.X - diff,
                lblPayConditions.Location.Y);
            cBPayConditions.Location = new Point(cBPayConditions.Location.X - diff,
                cBPayConditions.Location.Y);
        }

        /// <summary>
        /// В зависимости от выбранного подтипа нужно настроить панель с дополнительной информацией (виновный сотрудник, вложенный файл)
        /// </summary>
        private void cmbSubtype_SelectedValueChanged(object sender, EventArgs e)
        {
            faultEmployeeID = 0;
            tbxFaultEmployee.Text = tbxAttachment.Text = String.Empty;
            fileNames = new string[0];
            CustomSubtypeInfoPanel();
        }

        /// <summary>
        /// Настройка панели с дополнительной информацией по подтипу претензии
        /// </summary>
        private void CustomSubtypeInfoPanel()
        {
            var selItem = cmbSubtype.SelectedItem as DataRowView;
            var row = selItem == null ? null : selItem.Row as Data.Complaints.CO_Get_Available_Docs_SubtypesRow;
            var show = row != null && (!row.IsAttachment_RequiredNull() && !String.IsNullOrEmpty(row.Attachment_Required) ||
                !row.IsResponsible_RequiredNull() && !String.IsNullOrEmpty(row.Responsible_Required));
            HideOrShowSubtypeInfoPanel(show);
            lblFaultEmployee.Text = row == null || row.IsResponsibleNull() || String.IsNullOrEmpty(row.Responsible) ?
                "Ответственный сотрудник: " : row.Responsible + ": ";
            lblAttachment.Text = row == null || row.IsAttachmentNull() || String.IsNullOrEmpty(row.Attachment) ?
                "Вложенный файл: " : row.Attachment + ": ";
            lblFaultEmployee.Enabled = tbxFaultEmployee.Enabled = btnFaultEmployee.Enabled = row != null &&
                !row.IsResponsible_RequiredNull() && !String.IsNullOrEmpty(row.Responsible_Required);
            lblAttachment.Enabled = tbxAttachment.Enabled = btnAttachment.Enabled = row != null &&
                !row.IsAttachment_RequiredNull() && !String.IsNullOrEmpty(row.Attachment_Required);            
        }

        /// <summary>
        /// Отображение или сокрытие панели с дополнительной информацией по подтипу претензии
        /// </summary>
        /// <param name="pShow">True если надо отобразить дополнительную информацию по подтипу претензии,
        /// False если надо сокрыть дополнительную информацию по подтипу претензии</param>
        private void HideOrShowSubtypeInfoPanel(bool pShow)
        {
            int diff = 95;
            if (pShow && !grbRefuseSubtypeData.Visible)
            {
                grbRefuseSubtypeData.Visible = grbRefuseSubtypeData.Enabled = true;
                gbInvoiceHeader.Location = new Point(gbInvoiceHeader.Location.X, gbInvoiceHeader.Location.Y + diff);
                gbInvoiceLines.Location = new Point(gbInvoiceLines.Location.X, gbInvoiceLines.Location.Y + diff);
                gbInvoiceLines.Size = new Size(gbInvoiceLines.Size.Width, gbInvoiceLines.Size.Height - diff);
            }
            else if (!pShow && grbRefuseSubtypeData.Visible)
            {
                grbRefuseSubtypeData.Visible = grbRefuseSubtypeData.Enabled = false;
                gbInvoiceHeader.Location = new Point(gbInvoiceHeader.Location.X, gbInvoiceHeader.Location.Y - diff);
                gbInvoiceLines.Location = new Point(gbInvoiceLines.Location.X, gbInvoiceLines.Location.Y - diff);
                gbInvoiceLines.Size = new Size(gbInvoiceLines.Size.Width, gbInvoiceLines.Size.Height + diff);
            }
        }

        /// <summary>
        /// Выбор ответственного сотрудника
        /// </summary>
        private void btnFaultEmployee_Click(object sender, EventArgs e)
        {
            var form = new EnterFaultEmployeeForm(SessionID, faultEmployeeID,
                DocTypeID, cmbSubtype.SelectedValue.ToString(),cbWarehouses.SelectedValue == null ? null : cbWarehouses.SelectedValue.ToString()) { IsDepartmentChoiceEnabled = false };
            if (form.ShowDialog() == DialogResult.OK)
            {
                tbxFaultEmployee.Text = String.Format("{0} ({1})", form.FaultEmployee, form.FaultEmployeeID.Value);
                faultEmployeeID = form.FaultEmployeeID.Value;
            }
        }

        /// <summary>
        /// Вложение файла
        /// </summary>
        private void btnAttachment_Click(object sender, EventArgs e)
        {
            var form = new NewAttachmentForm();

            var subType = (cmbSubtype.SelectedItem as DataRowView).Row as Data.Complaints.CO_Get_Available_Docs_SubtypesRow;
            var attachmentTypeCode = subType.IsAttachment_Type_CodeNull() ? (string)null : subType.Attachment_Type_Code;
            form.AttachmentDocTypeCode = attachmentTypeCode;

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    // Проверка добавления вложения
                    using (var adapter = new Data.ComplaintsTableAdapters.DocAttachmentsTableAdapter())
                        adapter.CheckDocAttachment(this.SessionID, DocTypeID, form.AttachDocNumber, form.AttachmentDocTypeCode);

                    fileNames = form.FilePaths;
                    attachDocumentNumber = form.AttachDocNumber;
                    attachDocumentDate = form.AttachDocDate;
                    attachDescriptionType = form.AttachmentDocTypeCode;
                    attachDocumentAmount = form.AttachDocAmount;
                    attachDocumentIsVendorPayer = form.AttachDocIsVendorPayer;

                    tltFilePaths.SetToolTip(tbxAttachment, String.Empty);
                    var sb = new StringBuilder();
                    foreach (string fileName in fileNames)
                        sb.AppendLine(fileName);
                    if (fileNames.Length == 0)
                        tbxAttachment.Text = String.Empty;
                    else if (fileNames.Length == 1)
                        tbxAttachment.Text = "Файл: " + fileNames[0];
                    else
                    {
                        tbxAttachment.Text = "Вложено несколько файлов (перечень во всплывающей подсказке)";
                        tltFilePaths.SetToolTip(tbxAttachment, sb.ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Поиск накладной (заказа) по номеру".
        /// </summary>
        private void btnSearchInvoice_Click(object sender, EventArgs e)
        {
            //bool canSearchByOrderNumber = DocTypeID.Equals(ComplaintsConstants.ComplaintDocTypeCancellation, StringComparison.InvariantCultureIgnoreCase);
            bool canSearchByOrderNumber = false;

            string defaultOrderType = string.Empty,
                defaultInvoiceType = string.Empty,
                defaultInnerDocType = string.Empty;

            if (cbWarehouses.SelectedIndex != -1 && cbWarehouses.SelectedValue != null && availableWarehousesBindingSource.Current is DataRowView && ((DataRowView)availableWarehousesBindingSource.Current).Row != null)
            {
                //defaultOrderType = ((Data.Complaints.AvailableWarehousesRow)((DataRowView)availableWarehousesBindingSource.Current).Row).DefaultOrderType;
                //defaultInvoiceType = ((Data.Complaints.AvailableWarehousesRow)((DataRowView)availableWarehousesBindingSource.Current).Row).DefaultInvoiceType;
                defaultInnerDocType = "MF"; 
            }

            using (Dialogs.Complaints.SearchInvoiceOptionsForm form = new SearchInvoiceOptionsForm(true, canSearchByOrderNumber, defaultOrderType, defaultInvoiceType, defaultInnerDocType, this.DocTypeID))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var adapter = new Data.ComplaintsExtTableAdapters.SearchInnerDocsLinesTableAdapter())
                            adapter.Fill(complaintsExt.SearchInnerDocsLines, this.SessionID, form.InnerDocType, form.InnerDocNumber);

                        UpdateInfoByLastInvoice();
                        //return;

                        #region TODO закомментировано

                        //// если тип претензии - возврат/виртуальный возврат, результат поиска добавляется (не всегда); иначе - предыдущие результаты заменяются новыми
                        //if (DocTypeID.Equals(ComplaintsConstants.ComplaintDocTypeNormalRefuse, StringComparison.InvariantCultureIgnoreCase) ||
                        //    DocTypeID.Equals(ComplaintsConstants.ComplaintDocTypeVirtualRefuse, StringComparison.InvariantCultureIgnoreCase) ||
                        //    DocTypeID.Equals(ComplaintsConstants.ComplaintDocTypeQualityOrder, StringComparison.InvariantCultureIgnoreCase))
                        //{
                        //    Data.Complaints.SearchInvoiceLinesDataTable newSearchResults = new Data.Complaints.SearchInvoiceLinesDataTable();
                        //    searchInvoiceLinesTableAdapter.Fill(newSearchResults,
                        //        SessionID,
                        //        CompanyKey,
                        //        (int)form.SelectedSearchType,
                        //        form.OrderType,
                        //        form.OrderNumber,
                        //        form.InvoiceType,
                        //        form.InvoiceNumber);

                        //    if (newSearchResults.Rows.Count > 0)
                        //    {
                        //        int newDebtorCode = Convert.ToInt32(newSearchResults[0].DebtorCode);
                        //        int oldDebtorCode = 0;
                        //        if (complaints.SearchInvoiceLines.Count > 0)
                        //            oldDebtorCode = Convert.ToInt32(complaints.SearchInvoiceLines[complaints.SearchInvoiceLines.Count - 1].DebtorCode);

                        //        // претензия должна содержать строки накладных только одного основного дебитора
                        //        if ((complaints.SearchInvoiceLines.Count > 0 && oldDebtorCode == newDebtorCode) ||
                        //            complaints.SearchInvoiceLines.Count == 0)
                        //        {
                        //            string newInvoiceType = newSearchResults[0].InvoiceType;
                        //            int newInvoiceNumber = Convert.ToInt32(newSearchResults[0].InvoiceNumber);
                        //            bool foundSameInvoice = false; // признак, показывающий, что в составе претензии уже есть накладная с тем же типом и номером

                        //            foreach (Data.Complaints.SearchInvoiceLinesRow row in complaints.SearchInvoiceLines.Rows)
                        //            {
                        //                if (row.InvoiceType.Equals(newInvoiceType, StringComparison.InvariantCultureIgnoreCase) &&
                        //                    Convert.ToInt32(row.InvoiceNumber) == newInvoiceNumber)
                        //                {
                        //                    foundSameInvoice = true;
                        //                    break;
                        //                }
                        //            }

                        //            if (!foundSameInvoice)
                        //            {
                        //                complaints.SearchInvoiceLines.Merge(newSearchResults, true, MissingSchemaAction.Ignore);
                        //                UpdateInfoByLastInvoice();
                        //            }
                        //            else
                        //            {
                        //                MessageBox.Show("Накладная (" + newInvoiceType + ") " + newInvoiceNumber.ToString() + " уже содержится в претензии " +
                        //                    "и не может быть добавлена еще раз. Результаты поиска отменены.",
                        //                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //            }
                        //        }
                        //        else if (oldDebtorCode != newDebtorCode)
                        //        {
                        //            MessageBox.Show("Код основного дебитора в предыдущих накладных (" + oldDebtorCode.ToString() + ") не совпадает " +
                        //                "с кодом основного дебитора в найденной накладной (" + newDebtorCode.ToString() + "). Претензия может содержать " +
                        //                "строки накладных только одного основного дебитора. Результаты поиска отменены.",
                        //                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //        }
                        //    }
                        //}
                        //else
                        //{
                        //    searchInvoiceLinesTableAdapter.Fill(complaints.SearchInvoiceLines,
                        //        SessionID,
                        //        CompanyKey,
                        //        (int)form.SelectedSearchType,
                        //        form.OrderType,
                        //        form.OrderNumber,
                        //        form.InvoiceType,
                        //        form.InvoiceNumber);
                        //    UpdateInfoByLastInvoice();
                        //}

                        #endregion

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Обновляет информацию о накладной / заказе по данным из последней найденной строки.
        /// </summary>
        private void UpdateInfoByLastInvoice()
        {
            if (complaintsExt.SearchInnerDocsLines.Rows.Count > 0)
            {
                Data.ComplaintsExt.SearchInnerDocsLinesRow row = complaintsExt.SearchInnerDocsLines[complaintsExt.SearchInnerDocsLines.Count - 1];

                DeliveryCode = null;
                InvoiceType = row.IsInvoiceTypeNull() || string.IsNullOrEmpty(row.InvoiceType) || row.InvoiceType == "  " ? null : row.InvoiceType;
                InvoiceNumber = row.InvoiceNumber == 0 ? (double?)null : row.InvoiceNumber;

                tbInnerDocTypeAndNumber.Text = row.IsInvoiceTypeNull() ? "-" : row.InvoiceType + "-" + row.InvoiceNumber;
                tbInnerDocDate.Text = row.IsInvoiceDateNull() ? "-" : row.InvoiceDate.ToString("dd.MM.yyy");
            }
            else
            {
                tbInnerDocTypeAndNumber.Text = tbInnerDocDate.Text = "-";

                DeliveryCode = null;
                InvoiceType = null;
                InvoiceNumber = null;
            }

            #region TODO закоммент.

            //if (complaints.SearchInvoiceLines.Rows.Count > 0)
            //{
            //    Data.Complaints.SearchInvoiceLinesRow row = complaints.SearchInvoiceLines[complaints.SearchInvoiceLines.Count - 1];
            //    tbDeliveryCode.Text = row.IsDeliveryCodeNull() ? "-" : row.DeliveryCode.ToString();
            //    tbDebtorName.Text = row.IsDebtorNameNull() ? "-" : row.DebtorName;
            //    tbDeliveryAddress.Text = row.IsDeliveryAddressNull() ? "-" : row.DeliveryAddress;

            //    //tbOrderTypeAndNumber.Text = row.OrderType + "-" + row.OrderNumber.ToString();
            //    //tbOrderDate.Text = row.IsOrderDateNull() ? "-" : row.OrderDate.ToString("dd.MM.yyy");
            //    //tbInvoiceTypeAndNumber.Text = row.IsInvoiceTypeNull() || row.IsInvoiceNumberNull() ? "-" : row.InvoiceType + "-" + row.InvoiceNumber;
            //    //tbInvoiceDate.Text = row.IsInvoiceDateNull() ? "-" : row.InvoiceDate.ToString("dd.MM.yyy");

            //    DeliveryCode = row.IsDeliveryCodeNull() ? (int?)null : Convert.ToInt32(row.DeliveryCode);
            //    InvoiceType = row.IsInvoiceTypeNull() || string.IsNullOrEmpty(row.InvoiceType) || row.InvoiceType == "  " ? null : row.InvoiceType;
            //    InvoiceNumber = row.IsInvoiceNumberNull() || row.InvoiceNumber == 0 ? (double?)null : row.InvoiceNumber;
            //}
            //else
            //{
            //    tbDeliveryCode.Text = tbDebtorName.Text = tbDeliveryAddress.Text
            //         //= tbOrderTypeAndNumber.Text = tbOrderDate.Text = tbInvoiceTypeAndNumber.Text = tbInvoiceDate.Text
            //         = "-";

            //    DeliveryCode = null;
            //    InvoiceType = null;
            //    InvoiceNumber = null;
            //}

            #endregion
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "История претензий по адр.дост. или накладной".
        /// </summary>
        private void btnShowComplaintsHistory_Click(object sender, EventArgs e)
        {
            bool canLinkDocFromHistory = DocTypeID.Equals(ComplaintsConstants.ComplaintDocTypeFreak, StringComparison.InvariantCultureIgnoreCase);
            using (ComplaintsHistoryForm form = new ComplaintsHistoryForm(SessionID, DeliveryCode, InvoiceType, InvoiceNumber, canLinkDocFromHistory))
            {
                if (form.ShowDialog() == DialogResult.OK && canLinkDocFromHistory && form.WasLinked)
                {
                    LinkedDocID = form.LinkedDocID;
                    lblLinkedComplaintInfo.Text = "*СВЯЗАНА С ПРЕТЕНЗИЕЙ " + form.LinkedDocCaption;
                    lblLinkedComplaintInfo.Visible = true;
                }
            }
        }

        /// <summary>
        /// Обрабатывает клик по флажку в заголовке столбца "Отм.".
        /// </summary>
        private void CheckBoxHeaderCell_OnCheckBoxClicked(object sender, DataGridViewCheckBoxHeaderCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvInvoiceLines.Rows)
            {
                row.Cells[colCheckBox.Index].Value = e.IsChecked;
            }
            dgvInvoiceLines.RefreshEdit();
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Добавить товар".
        /// </summary>
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (complaintsExt.SearchInnerDocsLines.Rows.Count > 0)
                {
                    Data.ComplaintsExt.SearchInnerDocsLinesRow firstInvoiceRow = (Data.ComplaintsExt.SearchInnerDocsLinesRow)complaintsExt.SearchInnerDocsLines.Rows[0];

                    //using (ItemChooseForm form = new ItemChooseForm(SessionID))
                    //{
                    //    if (form.ShowDialog() == DialogResult.OK)
                    //    {
                    //        Data.ComplaintsExt.SearchInnerDocsLinesRow row = complaintsExt.SearchInnerDocsLines.NewSearchInnerDocsLinesRow();
                    //        row.DebtorCode = firstInvoiceRow.DebtorCode;
                    //        row.OrderType = firstInvoiceRow.OrderType;
                    //        row.OrderNumber = firstInvoiceRow.OrderNumber;
                    //        row.InvoiceType = firstInvoiceRow.IsInvoiceTypeNull() ? null : firstInvoiceRow.InvoiceType;
                    //        if (firstInvoiceRow.IsInvoiceNumberNull())
                    //            row.SetInvoiceNumberNull();
                    //        else
                    //            row.InvoiceNumber = firstInvoiceRow.InvoiceNumber;
                    //        row.ItemID = form.ItemID;
                    //        row.ItemName = form.ItemName;
                    //        row.VendorLot = form.VendorLot;
                    //        row.LotNumber = form.LotNumber;
                    //        row.VendorLotFact = form.VendorLot;
                    //        if (form.LotExpirationDate.HasValue)
                    //            row.LotExpirationDate = form.LotExpirationDate.Value;
                    //        else
                    //            row.SetLotExpirationDateNull();
                    //        row.Quantity = form.Quantity;
                    //        row.UnitOfMeasure = form.UnitOfMeasure;
                    //        row.ManufacturerName = form.Manufacturer;

                    //        // для новой добавленой строки установим значение цены в "ноль"
                    //        row.Price = 0;
                    //        row.IsVat = false;
                    //        row.SumWithoutVAT = 0;


                    //        row.IsChecked = true;
                    //        complaintsExt.SearchInnerDocsLines.AddSearchInnerDocsLinesRow(row);
                    //    }
                    //}
                }
                else
                {
                    MessageBox.Show("Перед добавлением товара вручную необходимо воспользоваться поиском накладной.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch { }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Сменить факт. серию".
        /// </summary>
        private void btnSearchVendorLotFact_Click(object sender, EventArgs e)
        {
            if (dgvInvoiceLines.SelectedRows.Count > 0)
            {
                Data.ComplaintsExt.SearchInnerDocsLinesRow selectedRow = (Data.ComplaintsExt.SearchInnerDocsLinesRow)((DataRowView)dgvInvoiceLines.SelectedRows[0].DataBoundItem).Row;
                using (Data.ComplaintsTableAdapters.SearchVendorLotTableAdapter adapter = new Data.ComplaintsTableAdapters.SearchVendorLotTableAdapter())
                {
                    Data.Complaints.SearchVendorLotDataTable table = adapter.GetData(SessionID, Convert.ToInt32(selectedRow.ItemID));
                    if (table.Rows.Count > 0)
                    {
                        using (Dialogs.RichListForm form = new RichListForm())
                        {
                            #region column VendorLot
                            DataGridViewTextBoxColumn colVendorLot = new DataGridViewTextBoxColumn();
                            colVendorLot.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                            colVendorLot.DataPropertyName = "VendorLot";
                            colVendorLot.HeaderText = "Серия";
                            colVendorLot.Name = "colVendorLot";
                            colVendorLot.ReadOnly = true;
                            form.Columns.Add(colVendorLot);
                            #endregion
                            #region column LotExpirationDate
                            DataGridViewTextBoxColumn colLotExpirationDate = new DataGridViewTextBoxColumn();
                            colLotExpirationDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                            colLotExpirationDate.DataPropertyName = "LotExpirationDate";
                            colLotExpirationDate.HeaderText = "Срок годности";
                            colLotExpirationDate.Name = "colLotExpirationDate";
                            colLotExpirationDate.ReadOnly = true;
                            form.Columns.Add(colLotExpirationDate);
                            #endregion

                            form.Text = "Выбор серии";
                            form.DataSource = table;
                            form.ColumnForFilters.Add("VendorLot");
                            form.ColumnForFilters.Add("LotExpirationDate");
                            form.FilterVisible = false;
                            form.DataSource = table;

                            if (form.ShowDialog() == DialogResult.OK)
                            {
                                if (form.SelectedRow != null)
                                {
                                    Data.Complaints.SearchVendorLotRow row = (Data.Complaints.SearchVendorLotRow)form.SelectedRow;
                                    selectedRow.VendorLotFact = row.VendorLot;
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Нет ни одной серии по данному коду товара.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Строка накладной не выбрана!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Сохранить".
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckAttachedFile())
                return;

            int sourceAddressCode = 0,
                destAddressCode = 0;
            btnSearchInvoice.BackColor = SystemColors.Control;
            tbSourceAddressCode.BackColor = tbDestAddressCode.BackColor = tbxAttachment.BackColor = tbxFaultEmployee.BackColor =
                tbContactName.BackColor = tbComment.BackColor = cmbSubtype.BackColor = SystemColors.Window;

            if (dgvInvoiceLines.Rows.Count == 0)
            {
                MessageBox.Show("Создаваемая претензия обязательно должна быть связана с строками накладной (заказа)! Воспользуйтесь кнопкой \"Поиск накладной (заказа) по номеру\".",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSearchInvoice.BackColor = Color.Pink;
            }
            else if (NeedSubtypes && cmbSubtype.SelectedValue == null)
            {
                MessageBox.Show("Для этого типа претензии нужно обязательно выбрать подтип!",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSubtype.BackColor = Color.Pink;
            }
            //else if (!int.TryParse(tbSourceAddressCode.Text, out sourceAddressCode) || sourceAddressCode <= 0)
            //{
            //    MessageBox.Show("Неверно указан код адреса доставки источника претензии!",
            //        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    tbSourceAddressCode.BackColor = Color.Pink;
            //}
            else if (DocTypeID.Equals(ComplaintsConstants.ComplaintDocTypeVirtualRefuse, StringComparison.InvariantCultureIgnoreCase) &&
                (!int.TryParse(tbDestAddressCode.Text, out destAddressCode) || destAddressCode <= 0))
            {
                MessageBox.Show("Неверно указан код адреса доставки получателя нового заказа!",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbDestAddressCode.BackColor = Color.Pink;
            }
            else if (tbContactName.Text.Length < 15)
            {
                MessageBox.Show("Не заполнено поле контактной информации (минимум 15 символов)!",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbContactName.BackColor = Color.Pink;
            }
            else if (tbComment.Text.Length < 15)
            {
                MessageBox.Show("Не заполнено поле описания претензии (минимум 15 символов)!",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbComment.BackColor = Color.Pink;
            }
            else if (NeedSubtypes && tbxFaultEmployee.Enabled && faultEmployeeID == 0)
            {
                var row = (cmbSubtype.SelectedItem as DataRowView).Row as Data.Complaints.CO_Get_Available_Docs_SubtypesRow;
                MessageBox.Show(row.Responsible_Required, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbxFaultEmployee.BackColor = Color.Pink;
            }
            else if (NeedSubtypes && tbxAttachment.Enabled && fileNames.Length == 0)
            {
                var row = (cmbSubtype.SelectedItem as DataRowView).Row as Data.Complaints.CO_Get_Available_Docs_SubtypesRow;
                MessageBox.Show(row.Attachment_Required, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbxAttachment.BackColor = Color.Pink;
            }
            else
            {
                List<Data.ComplaintsExt.SearchInnerDocsLinesRow> complaintRows = new List<WMSOffice.Data.ComplaintsExt.SearchInnerDocsLinesRow>();
                foreach (DataGridViewRow r in dgvInvoiceLines.Rows)
                {
                    if (r.Cells[colCheckBox.Name].Value != DBNull.Value && r.Cells[colCheckBox.Name].Value != null && (bool)r.Cells[colCheckBox.Name].Value)
                        complaintRows.Add((Data.ComplaintsExt.SearchInnerDocsLinesRow)((DataRowView)r.DataBoundItem).Row);
                }
                if (complaintRows.Count == 0)
                {
                    MessageBox.Show("Для создания претензии нужно отметить (в столбце \"Отм.\") как минимум одну товарную позицию!",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    foreach (var row in complaintRows)
                        if (row.IsGuiltyEmployeesListNull() || string.IsNullOrEmpty(row.GuiltyEmployeesList.Trim()))
                        {
                            MessageBox.Show("Для создания претензии нужно указать виновных сотрудников по каждой отмеченной товарной позиции!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                    #region ПРОВЕРКА ДОБАВЛЕНИЯ ВЛОЖЕНИЯ

                    try
                    {
                        using (var adapter = new Data.ComplaintsTableAdapters.DocAttachmentsTableAdapter())
                        {
                            foreach (var file in attachedFiles)
                                adapter.CheckDocAttachment(this.SessionID, DocTypeID, file.Document_Number, file.IsDescriptionTypeNull() ? (string)null : file.DescriptionType);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    #endregion

                    if (MessageBox.Show("Создать новую претензию по введенным данным?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        var targetStatus = ComplaintsConstants.ComplaintStatusAccepting;

                        var tranOptions = new System.Transactions.TransactionOptions();
                        tranOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;

                        long docID = -1;
                        Data.Complaints.CheckDocDataTable checkTable = null;

                        #region СОЗДАНИЕ ДОКУМЕНТА ПРЕТЕНЗИИ (ТРАНЗАКЦИЯ)
                        using (var scope = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.Required, tranOptions))
                        {
                            try
                            {
                                // добавление претензии и её деталей
                                using (Data.ComplaintsTableAdapters.CurrentDocsTableAdapter createAdapter = new Data.ComplaintsTableAdapters.CurrentDocsTableAdapter())
                                {
                                    // увеличим таймаут до 10-ти минут
                                    createAdapter.SetTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds);

                                    // добавление заголовка
                                    docID = Convert.ToInt64(createAdapter.AddComplaintDoc(
                                        LinkedDocID,
                                        DocTypeID,
                                        (string)cbWarehouses.SelectedValue,
                                        sourceAddressCode,
                                        destAddressCode,
                                        dtpDateReceivedFromClient.Value,
                                        dtpDateForecastSolution.Value,
                                        tbContactName.Text,
                                        tbComment.Text,
                                        SessionID,
                                        (cBPayConditions.SelectedItem == null) ? null : cBPayConditions.SelectedItem.ToString(),
                                        NeedSubtypes ? cmbSubtype.SelectedValue.ToString() : null));

                                    // добавление строк
                                    for (int i = 0; i < complaintRows.Count; ++i)
                                    {
                                        Data.ComplaintsExt.SearchInnerDocsLinesRow r = complaintRows[i];
                                        long docLineID = Convert.ToInt64(createAdapter.AddComplaintDocRow(
                                           docID,
                                           CompanyKey,
                                           r.InvoiceType,
                                           r.InvoiceNumber,
                                           (string)null,
                                           (double?)null,
                                           Convert.ToInt32(r.IsLineIDNull() ? 1000000000 + i : r.LineID),
                                            //r.OrderType,
                                            //r.OrderNumber,
                                            //r.IsInvoiceTypeNull() ? null : r.InvoiceType,
                                            //r.IsInvoiceNumberNull() ? (double?)null : r.InvoiceNumber,
                                            //Convert.ToInt32(r.IsLineIDNull() ? 1000000000 + i : r.LineID),
                                           Convert.ToInt32(r.ItemID),
                                           r.ItemName,
                                           r.ManufacturerName,
                                           r.VendorLot,
                                           r.IsLotNumberNull() ? null : r.LotNumber,
                                           r.IsVendorLotFactNull() ? null : r.VendorLotFact,
                                           r.UnitOfMeasure,
                                           r.Quantity, r.IsAttachNull() ? null : r.Attach));

                                        var locationTo = r.Islocn_toNull() ? (string)null : r.locn_to;

                                        // Сохраним список виновных сотрудников
                                        foreach (var csvItem in r.GuiltyEmployeesList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                                        {
                                            var employeeID = Convert.ToInt32(csvItem);
                                            using (var employeeAdapter = new Data.ComplaintsExtTableAdapters.ComplaintLineGuiltyEmployeesTableAdapter())
                                                employeeAdapter.AddGuiltyEmployee(docID, docLineID, employeeID, 0, locationTo);
                                        }
                                    }

                                    using (Data.ComplaintsTableAdapters.CheckDocTableAdapter checkAdapter = new Data.ComplaintsTableAdapters.CheckDocTableAdapter())
                                    {
                                        // увеличим таймаут до 10-ти минут
                                        checkAdapter.SetTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds);

                                        checkTable = checkAdapter.GetData(docID, SessionID);
                                    }
                                }

                                scope.Complete();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Во время сохранения претензии в базе данных возникла следующая ошибка:" + Environment.NewLine + Environment.NewLine + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        #endregion

                        var allWarningsAccepted = true; // признак, показывающий, что пользователь согласился со всеми предупреждениями
                        var resultMessage = (string)null; // чисто информационное текстовое сообщение, которое может вернуть процедура проверки

                        var exceptionID = (long?)null;
                        var hasDocException = false;
                        var docExceptionStatusID = (string)null;
                        var docExceptionComment = (string)null;

                        #region СОЗДАНИЕ ПАРАМЕТРОВ ДЛЯ ФОРМИРОВАНИЯ ИСКЛЮЧЕНИЙ В ДОКУМЕНТЕ ПРЕТЕНЗИИ + СОЗДАНИЕ ПАРАМЕТРОВ ДЛЯ ИЗМЕНЕНИЯ СКЛАДА В ДОКУМЕНТЕ ПРЕТЕНЗИИ
                        try
                        {
                            // выполнение проверок
                            bool processCheckResults = false;
                            foreach (Data.Complaints.CheckDocRow checkRow in checkTable.Rows)
                            {
                                if (checkRow.IsWarning || checkRow.IsError)
                                {
                                    processCheckResults = true;
                                    break;
                                }
                            }

                            if (processCheckResults)
                            {
                                using (Data.ComplaintsTableAdapters.CurrentDocsTableAdapter createAdapter = new Data.ComplaintsTableAdapters.CurrentDocsTableAdapter())
                                {
                                    createAdapter.SetTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds);
                                    createAdapter.CheckDocExceptionsExists(SessionID, docID, ref exceptionID);
                                }

                                var canIgnoreDocExceptions = exceptionID.HasValue && exceptionID.Value > 0;

                                ComplaintCheckErrorsForm dlgComplaintCheckErrorsForm = null;

                                //  Игнорирование проверок при создании претензии
                                if (canIgnoreDocExceptions && (dlgComplaintCheckErrorsForm = new ComplaintCheckErrorsForm(checkTable)).ShowDialog() == DialogResult.OK)
                                {
                                    docExceptionStatusID = "110";
                                    docExceptionComment = dlgComplaintCheckErrorsForm.Comment;
                                    hasDocException = true;

                                    targetStatus = ComplaintsConstants.ComplaintStatusWaitAccepting;
                                    allWarningsAccepted = true;
                                }
                                else
                                {
                                    docExceptionStatusID = "198";
                                    docExceptionComment = (string)null;
                                    hasDocException = true;

                                    foreach (Data.Complaints.CheckDocRow checkRow in checkTable.Rows)
                                    {
                                        if (checkRow.IsError)
                                            throw new OperationCanceledException(checkRow.MessageText);
                                    }
                                    foreach (Data.Complaints.CheckDocRow checkRow in checkTable.Rows)
                                    {
                                        if (checkRow.IsWarning && MessageBox.Show(checkRow.MessageText + Environment.NewLine + Environment.NewLine +
                                                "Вы хотите продолжить создание претензии?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                                        {
                                            allWarningsAccepted = false;
                                            break;
                                        }
                                        else if (!checkRow.IsError && !checkRow.IsWarning)
                                        {
                                            resultMessage = checkRow.MessageText;
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            try
                            {
                                using (Data.ComplaintsTableAdapters.CurrentDocsTableAdapter createAdapter = new Data.ComplaintsTableAdapters.CurrentDocsTableAdapter())
                                {
                                    createAdapter.SetTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds);
                                    createAdapter.CancelNotActualDoc(docID);
                                }
                            }
                            catch (Exception)
                            {

                            }

                            MessageBox.Show("Во время сохранения претензии в базе данных возникла следующая ошибка:" + Environment.NewLine + Environment.NewLine + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        #endregion

                        var result = false;

                        var hasError = false;

                        #region СОХРАНЕНИЕ ИСКЛЮЧЕНИЙ ПО ПРЕТЕНЗИИ + ДОБАВЛЕНИЕ ВИНОВНЫХ СОТРУДНИКОВ + ДОБАВЛЕНИЕ ВЛОЖЕНИЙ + ЗАПУСК ПРЕТЕНЗИИ В РАБОТУ (ТРАНЗАКЦИЯ)
                        using (var scope = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.Required, tranOptions))
                        {
                            try
                            {
                                using (Data.ComplaintsTableAdapters.CurrentDocsTableAdapter createAdapter = new Data.ComplaintsTableAdapters.CurrentDocsTableAdapter())
                                {
                                    // Увеличим таймаут до 10-ти минут
                                    createAdapter.SetTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds);

                                    // Сохранение исключения
                                    if (hasDocException)
                                        createAdapter.ChangeDocExceptionsStatus(SessionID, docID, docExceptionStatusID, docExceptionComment, exceptionID);

                                    if (allWarningsAccepted)
                                    {
                                        createAdapter.AddDocStages(docID); // Инициализация этапов обработки претензии
                                        createAdapter.ChangeDocStatus(SessionID, docID, targetStatus, ComplaintsConstants.ComplaintStatusJustCreated);

                                        // Добавляем виновного сотрудника
                                        if (faultEmployeeID > 0)
                                            using (var adapter = new Data.ComplaintsTableAdapters.QueriesTableAdapter())
                                            {
                                                adapter.SetTimeout((int)TimeSpan.FromMinutes(2).TotalSeconds);
                                                adapter.ChangeCommonFaultEmployeeID(SessionID, docID, faultEmployeeID, null);
                                            }

                                        // Добавляем вложения
                                        if (fileNames.Length > 0)
                                        {
                                            var row = (cmbSubtype.SelectedItem as DataRowView).Row as Data.Complaints.CO_Get_Available_Docs_SubtypesRow;
                                            using (var adapter = new DocAttachmentsTableAdapter())
                                            {
                                                adapter.SetTimeout((int)TimeSpan.FromMinutes(2).TotalSeconds);

                                                foreach (string fileName in fileNames)
                                                    adapter.AddDocAttachment(docID, Path.GetFileName(fileName), row.Attachment, File.ReadAllBytes(fileName), SessionID, attachDocumentNumber, attachDocumentDate, attachDescriptionType, attachDocumentAmount, attachDocumentIsVendorPayer);
                                            }
                                        }

                                        // Добавляем вложенные файлы
                                        using (var adapter = new DocAttachmentsTableAdapter())
                                        {
                                            adapter.SetTimeout((int)TimeSpan.FromMinutes(2).TotalSeconds);

                                            foreach (var file in attachedFiles)
                                                adapter.AddDocAttachment(docID, file.File_Name, file.Description, file.File_Data, SessionID, file.Document_Number, file.Document_Date, file.IsDescriptionTypeNull() ? (string)null : file.DescriptionType, file.IsDocument_AmountNull() ? (double?)null : file.Document_Amount, file.IsIS_Vendor_PayerNull() ? (bool?)null : file.IS_Vendor_Payer);
                                        }

                                        result = true;
                                    }
                                    else
                                    {
                                        createAdapter.CancelNotActualDoc(docID);
                                    }
                                }

                                scope.Complete();

                                if (result)
                                {
                                    if (resultMessage != null)
                                        MessageBox.Show(resultMessage, "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    DialogResult = DialogResult.OK;
                                    Close();
                                }
                                else
                                    return;
                            }
                            catch (Exception ex)
                            {
                                hasError = true;

                                MessageBox.Show("Во время сохранения претензии в базе данных возникла следующая ошибка:" + Environment.NewLine + Environment.NewLine + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //return;
                            }
                        }

                        if (hasError)
                        {
                            try
                            {
                                using (Data.ComplaintsTableAdapters.CurrentDocsTableAdapter createAdapter = new Data.ComplaintsTableAdapters.CurrentDocsTableAdapter())
                                {
                                    createAdapter.SetTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds);
                                    createAdapter.CancelNotActualDoc(docID);
                                }
                            }
                            catch (Exception)
                            {

                            }
                        }

                        #endregion
                    }
                }
            }
        }

        /// <summary>
        /// Обрабатывает изменение текста в поле быстрого поиска.
        /// </summary>
        private void tbFastSearch_Enter(object sender, EventArgs e)
        {
            if (tbFastSearch.Text == "Быстрый поиск...")
                tbFastSearch.Text = string.Empty;
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопки в поле быстрого поиска для перехвата нажатий на Enter.
        /// </summary>
        private void tbFastSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDoFactSearch_Click(this, EventArgs.Empty);
                e.Handled = true;
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку быстрого поиска (фильтра строк накладной).
        /// </summary>
        private void btnDoFactSearch_Click(object sender, EventArgs e)
        {
            int tmpItemID = 0;
            int.TryParse(tbFastSearch.Text, out tmpItemID);

            if (tbFastSearch.Text != "Быстрый поиск...")
                searchInnerDocsLinesBindingSource.Filter = "IsChecked = 1 OR ItemID = " + tmpItemID.ToString() + " OR bar_code = '" + tbFastSearch.Text + "' OR ItemName LIKE '%" + tbFastSearch.Text + "%' OR VendorLot LIKE '%" + tbFastSearch.Text + "%' OR VendorLotFact LIKE '%" + tbFastSearch.Text + "%'";
            else
                searchInnerDocsLinesBindingSource.Filter = string.Empty;

            //if (tbFastSearch.Text != "Быстрый поиск...")
            //    searchInvoiceLinesBindingSource.Filter = "IsChecked = 1 OR ItemID = " + tmpItemID.ToString() + " OR ItemName LIKE '%" + tbFastSearch.Text + "%' OR VendorLot LIKE '%" + tbFastSearch.Text + "%' OR VendorLotFact LIKE '%" + tbFastSearch.Text + "%'";
            //else
            //    searchInvoiceLinesBindingSource.Filter = string.Empty;
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку сброса результатов быстрого поиска (отмена фильтрации строк накладной).
        /// </summary>
        private void btnCancelFastSearch_Click(object sender, EventArgs e)
        {
            searchInnerDocsLinesBindingSource.Filter = string.Empty;
            //searchInvoiceLinesBindingSource.Filter = string.Empty;
            
            tbFastSearch.Text = "Быстрый поиск...";
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Экспорт в Excel".
        /// </summary>
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Title = "Экспорт в Excel";
                dlg.FileName = "Претензия от " + tbSourceAddressCode.Text + " - " + cbComplaintType.Items[0].ToString() + ".xls";
                dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                dlg.Filter = "Таблицы Excel (*.xls)|*.xls;*.XLS|Все файлы (*.*)|*.*";
                dlg.FilterIndex = 0;
                dlg.AddExtension = true;
                dlg.DefaultExt = "xls";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    ExportToExcel(dlg.FileName.EndsWith(".xls", StringComparison.OrdinalIgnoreCase) ? dlg.FileName : (dlg.FileName + ".xls"));
                    System.Diagnostics.Process.Start(dlg.FileName);
                }
            }
        }

        /// <summary>
        /// Экспортирует данные по создаваемой претензии в файл Excel по шаблону (формат файла - XML 2003).
        /// </summary>
        /// <param name="fileName">Путь к файлу.</param>
        private void ExportToExcel(string fileName)
        {
            System.IO.StreamWriter excelDoc;
            excelDoc = new System.IO.StreamWriter(fileName, false, Encoding.Unicode);

            #region Шапка документа
            excelDoc.Write(
@"<?xml version=""1.0""?>
<?mso-application progid=""Excel.Sheet""?>
<Workbook xmlns=""urn:schemas-microsoft-com:office:spreadsheet""
 xmlns:o=""urn:schemas-microsoft-com:office:office""
 xmlns:x=""urn:schemas-microsoft-com:office:excel""
 xmlns:ss=""urn:schemas-microsoft-com:office:spreadsheet""
 xmlns:html=""http://www.w3.org/TR/REC-html40"">
 <DocumentProperties xmlns=""urn:schemas-microsoft-com:office:office"">
  <Author>WMS</Author>
  <LastAuthor>WMS</LastAuthor>
  <Created>" + DateTime.Now.ToString("s") + @"</Created>
  <Company>СП ""Оптима-Фарм, ЛТД""</Company>
  <Version>14.00</Version>
 </DocumentProperties>
 <OfficeDocumentSettings xmlns=""urn:schemas-microsoft-com:office:office"">
  <AllowPNG/>
 </OfficeDocumentSettings>
 <ExcelWorkbook xmlns=""urn:schemas-microsoft-com:office:excel"">
  <ProtectStructure>False</ProtectStructure>
  <ProtectWindows>False</ProtectWindows>
 </ExcelWorkbook>
");
            #endregion

            #region Стили, используемые для ячеек
            excelDoc.Write(
@"<Styles>
  <Style ss:ID=""Default"" ss:Name=""Normal"">
   <Alignment ss:Vertical=""Bottom""/>
   <Borders/>
   <Font ss:FontName=""Calibri"" x:CharSet=""204"" x:Family=""Swiss"" ss:Size=""11""
    ss:Color=""#000000""/>
   <Interior/>
   <NumberFormat/>
   <Protection/>
  </Style>
  <Style ss:ID=""s62"">
   <Alignment ss:Vertical=""Center""/>
   <Font ss:FontName=""Arial"" x:CharSet=""204"" x:Family=""Swiss"" ss:Size=""11""
    ss:Color=""#000000"" ss:Bold=""1""/>
  </Style>
  <Style ss:ID=""s63"">
   <Alignment ss:Horizontal=""Left"" ss:Vertical=""Center""/>
   <Font ss:FontName=""Arial"" x:CharSet=""204"" x:Family=""Swiss"" ss:Size=""11""
    ss:Color=""#000000""/>
  </Style>
  <Style ss:ID=""s64"">
   <Alignment ss:Horizontal=""Left"" ss:Vertical=""Center""/>
   <Font ss:FontName=""Arial"" x:CharSet=""204"" x:Family=""Swiss"" ss:Size=""11""
    ss:Color=""#000000""/>
   <NumberFormat ss:Format=""General Date""/>
  </Style>
  <Style ss:ID=""s65"">
   <Alignment ss:Horizontal=""Left"" ss:Vertical=""Center""/>
   <Font ss:FontName=""Arial"" x:CharSet=""204"" x:Family=""Swiss"" ss:Size=""11""
    ss:Color=""#000000""/>
   <NumberFormat ss:Format=""Short Date""/>
  </Style>
  <Style ss:ID=""s66"">
   <Alignment ss:Vertical=""Center""/>
   <Borders>
    <Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>
    <Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>
    <Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>
    <Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>
   </Borders>
   <Font ss:FontName=""Arial"" x:CharSet=""204"" x:Family=""Swiss"" ss:Size=""11""
    ss:Color=""#000000"" ss:Bold=""1""/>
  </Style>
  <Style ss:ID=""s67"">
   <Alignment ss:Horizontal=""Center"" ss:Vertical=""Center""/>
   <Borders>
    <Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>
    <Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>
    <Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>
    <Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>
   </Borders>
   <Font ss:FontName=""Arial"" x:CharSet=""204"" x:Family=""Swiss"" ss:Size=""11""
    ss:Color=""#000000"" ss:Bold=""1""/>
   <Interior/>
  </Style>
  <Style ss:ID=""s68"">
   <Alignment ss:Vertical=""Center""/>
   <Borders>
    <Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>
    <Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>
    <Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>
    <Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>
   </Borders>
   <Font ss:FontName=""Arial"" x:CharSet=""204"" x:Family=""Swiss"" ss:Size=""11""
    ss:Color=""#000000""/>
  </Style>
  <Style ss:ID=""s71"">
   <Alignment ss:Horizontal=""Left"" ss:Vertical=""Center""/>
   <Borders>
    <Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>
    <Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>
    <Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>
    <Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>
   </Borders>
   <Font ss:FontName=""Arial"" x:CharSet=""204"" x:Family=""Swiss"" ss:Size=""11""
    ss:Color=""#000000""/>
  </Style>
  <Style ss:ID=""s72"">
   <Alignment ss:Horizontal=""Right"" ss:Vertical=""Center""/>
   <Borders>
    <Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>
    <Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>
    <Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>
    <Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>
   </Borders>
   <Font ss:FontName=""Arial"" x:CharSet=""204"" x:Family=""Swiss"" ss:Size=""11""
    ss:Color=""#000000""/>
   <NumberFormat ss:Format=""Short Date""/>
  </Style>
  <Style ss:ID=""s73"">
   <Alignment ss:Horizontal=""Right"" ss:Vertical=""Center""/>
   <Borders>
    <Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>
    <Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>
    <Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>
    <Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>
   </Borders>
   <Font ss:FontName=""Arial"" x:CharSet=""204"" x:Family=""Swiss"" ss:Size=""11""
    ss:Color=""#000000""/>
  </Style>
 </Styles>
");
            #endregion

            #region Лист 1: шапка, заголовки столбцов
            excelDoc.Write(
@"<Worksheet ss:Name=""Претензия"">
  <Table ss:ExpandedColumnCount=""11"" x:FullColumns=""1""
   x:FullRows=""1"" ss:DefaultRowHeight=""15"">
   <Column ss:AutoFitWidth=""0"" ss:Width=""44""/>
   <Column ss:AutoFitWidth=""0"" ss:Width=""94""/>
   <Column ss:AutoFitWidth=""0"" ss:Width=""80"" ss:Span=""1""/>
   <Column ss:Index=""5"" ss:AutoFitWidth=""0"" ss:Width=""200""/>
   <Column ss:AutoFitWidth=""0"" ss:Width=""95""/>
   <Column ss:AutoFitWidth=""0"" ss:Width=""95""/>
   <Column ss:Width=""76""/>
   <Column ss:AutoFitWidth=""0"" ss:Width=""45""/>
   <Column ss:Width=""62""/>
   <Column ss:AutoFitWidth=""0"" ss:Width=""300""/>
   <Row ss:AutoFitHeight=""0"">
    <Cell ss:StyleID=""s62""><Data ss:Type=""String"">Тип претензии:</Data></Cell>
    <Cell ss:Index=""5"" ss:StyleID=""s63""><Data ss:Type=""String"">" + FixXmlChars(cbComplaintType.Items[0].ToString()) + @"</Data></Cell>
   </Row>
   <Row ss:AutoFitHeight=""0"">
    <Cell ss:StyleID=""s62""><Data ss:Type=""String"">Время обращения клиента:</Data></Cell>
    <Cell ss:Index=""5"" ss:StyleID=""s64""><Data ss:Type=""DateTime"">" + dtpDateReceivedFromClient.Value.ToString("s") + @"</Data></Cell>
   </Row>
   <Row ss:AutoFitHeight=""0"">
    <Cell ss:StyleID=""s62""><Data ss:Type=""String"">Плановая дата решения:</Data></Cell>
    <Cell ss:Index=""5"" ss:StyleID=""s65""><Data ss:Type=""DateTime"">" + dtpDateForecastSolution.Value.ToString("s") + @"</Data></Cell>
   </Row>
   <Row ss:AutoFitHeight=""0"">
    <Cell ss:StyleID=""s62""><Data ss:Type=""String"">Склад, к которому предъявляется претензия:</Data></Cell>
    <Cell ss:Index=""5"" ss:StyleID=""s63""><Data ss:Type=""String"">" + FixXmlChars(cbWarehouses.Text + " (" + cbWarehouses.SelectedValue.ToString()) + @")</Data></Cell>
   </Row>
   <Row ss:AutoFitHeight=""0"">
    <Cell ss:StyleID=""s62""><Data ss:Type=""String"">Код адр. дост. источника претензии:</Data></Cell>
    <Cell ss:Index=""5"" ss:StyleID=""s63""><Data ss:Type=""Number"">" + FixXmlChars(tbSourceAddressCode.Text) + @"</Data></Cell>
   </Row>
" + (DocTypeID.Equals(ComplaintsConstants.ComplaintDocTypeVirtualRefuse, StringComparison.InvariantCultureIgnoreCase) ? @"
   <Row ss:AutoFitHeight=""0"">
    <Cell ss:StyleID=""s62""><Data ss:Type=""String"">Код адр. дост. получателя:</Data></Cell>
    <Cell ss:Index=""5"" ss:StyleID=""s63""><Data ss:Type=""Number"">" + FixXmlChars(tbDestAddressCode.Text) + @"</Data></Cell>
   </Row>" : string.Empty) +
@"   <Row ss:AutoFitHeight=""0"">
    <Cell ss:StyleID=""s62""><Data ss:Type=""String"">Контактная информация:</Data></Cell>
    <Cell ss:Index=""5"" ss:StyleID=""s63""><Data ss:Type=""String"">" + FixXmlChars(tbContactName.Text) + @"</Data></Cell>
   </Row>
   <Row ss:AutoFitHeight=""0"">
    <Cell ss:StyleID=""s62""><Data ss:Type=""String"">Описание претензии:</Data></Cell>
    <Cell ss:Index=""5"" ss:StyleID=""s63""><Data ss:Type=""String"">" + FixXmlChars(tbComment.Text) + @"</Data></Cell>
   </Row>
   <Row ss:Index=""10"" ss:AutoFitHeight=""0"">
    <Cell ss:StyleID=""s66""><Data ss:Type=""String"">Отм.</Data></Cell>
    <Cell ss:StyleID=""s66""><Data ss:Type=""String"">№ накладной</Data></Cell>
    <Cell ss:StyleID=""s66""><Data ss:Type=""String"">Дата накл.</Data></Cell>
    <Cell ss:StyleID=""s66""><Data ss:Type=""String"">Код товара</Data></Cell>
    <Cell ss:StyleID=""s66""><Data ss:Type=""String"">Наименование товара</Data></Cell>
    <Cell ss:StyleID=""s66""><Data ss:Type=""String"">Серия</Data></Cell>
    <Cell ss:StyleID=""s66""><Data ss:Type=""String"">Факт. серия</Data></Cell>
    <Cell ss:StyleID=""s66""><Data ss:Type=""String"">Срок годн.</Data></Cell>
    <Cell ss:StyleID=""s66""><Data ss:Type=""String"">К-во</Data></Cell>
    <Cell ss:StyleID=""s66""><Data ss:Type=""String"">Ед. изм.</Data></Cell>
    <Cell ss:StyleID=""s66""><Data ss:Type=""String"">Наименование производителя</Data></Cell>
   </Row>
");
            #endregion

            #region Строки (состав) претензии
            foreach (Data.ComplaintsExt.SearchInnerDocsLinesRow row in complaintsExt.SearchInnerDocsLines.Rows)
            {
                excelDoc.Write(String.Format(
@"   <Row ss:AutoFitHeight=""0"">
    <Cell ss:StyleID=""s67""><Data ss:Type=""String"">{0}</Data></Cell>
    <Cell ss:StyleID=""s71""><Data ss:Type=""String"">{1}</Data></Cell>
    <Cell ss:StyleID=""s72""><Data ss:Type=""DateTime"">{2}</Data></Cell>
    <Cell ss:StyleID=""s73""><Data ss:Type=""Number"">{3}</Data></Cell>
    <Cell ss:StyleID=""s71""><Data ss:Type=""String"">{4}</Data></Cell>
    <Cell ss:StyleID=""s71""><Data ss:Type=""String"">{5}</Data></Cell>
    <Cell ss:StyleID=""s71""><Data ss:Type=""String"">{6}</Data></Cell>
    <Cell ss:StyleID=""s72""><Data ss:Type=""DateTime"">{7}</Data></Cell>
    <Cell ss:StyleID=""s73""><Data ss:Type=""Number"">{8}</Data></Cell>
    <Cell ss:StyleID=""s68""><Data ss:Type=""String"">{9}</Data></Cell>
    <Cell ss:StyleID=""s71""><Data ss:Type=""String"">{10}</Data></Cell>
   </Row>
",
                  (!row.IsIsCheckedNull() && row.IsChecked ? "X" : string.Empty),
                  row.InvoiceTypeAndNumber,
                  (row.IsInvoiceDateNull() ? "" : row.InvoiceDate.ToString("s")),
                  row.ItemID.ToString(),
                  FixXmlChars(row.ItemName),
                  FixXmlChars(row.VendorLot),
                  FixXmlChars(row.VendorLotFact),
                  row.LotExpirationDate.ToString("s"),
                  row.Quantity.ToString(),
                  FixXmlChars(row.UnitOfMeasure),
                  FixXmlChars(row.ManufacturerName)
                  ));
            }
            #endregion

            #region Всякие дополнительные параметры листа, конец документа
            excelDoc.Write(
@"  </Table>
  <WorksheetOptions xmlns=""urn:schemas-microsoft-com:office:excel"">
   <Unsynced/>
   <Selected/>
   <ProtectObjects>False</ProtectObjects>
   <ProtectScenarios>False</ProtectScenarios>
  </WorksheetOptions>
  <AutoFilter x:Range=""R10C1:R10C11""
   xmlns=""urn:schemas-microsoft-com:office:excel"">
  </AutoFilter>
 </Worksheet>
</Workbook>");
            #endregion

            excelDoc.Close();
        }

        /// <summary>
        /// Заменяет зарезервированные XML-символы на допустимые.
        /// </summary>
        /// <param name="s">Строка, в которой нужно заменить символы.</param>
        /// <returns>Результат замены.</returns>
        private string FixXmlChars(string s)
        {
            return s.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("%", "&#37;");
        }

        /// <summary>
        /// После ввода "Кода адр. доставки источника претензии" обновляет доступные условия оплат в cBPayConditions
        /// </summary>
        private void tbSourceAddressCode_Leave(object sender, EventArgs e)
        {
            int adressCode;
            if (DocTypeID == "VR" && int.TryParse(tbSourceAddressCode.Text, out adressCode))
                try
                {
                    using (Data.ComplaintsTableAdapters.ConditionsByDebtorTableAdapter tableAdapter = new Data.ComplaintsTableAdapters.ConditionsByDebtorTableAdapter())
                    {
                        Data.Complaints.ConditionsByDebtorDataTable table = tableAdapter.GetData(adressCode);
                        cBPayConditions.Items.Clear();
                        foreach (Data.Complaints.ConditionsByDebtorRow row in table.Rows)
                            cBPayConditions.Items.Add(row.Conditions);
                        cBPayConditions.SelectedItem = cBPayConditions.Items[0];
                    }
                    cBPayConditions.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Во время поиска доступных условий оплат в базе данных по данному адресу доставки в возникла следующая ошибка:" + Environment.NewLine + Environment.NewLine +
                            ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        /// <summary>
        /// После ввода "Кода адр. доставки источника претензии" вызов обновления доступных условий оплат в cBPayConditions
        /// </summary>
        private void tbSourceAddressCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (DocTypeID == "VR" && e.KeyChar == (char)Keys.Enter)
                tbSourceAddressCode_Leave(this, EventArgs.Empty);
        }

        /// <summary>
        /// При изменении "Кода адр. доставки источника претензии" условя оплат в cBPayConditions недоступны
        /// </summary>
        private void tbSourceAddressCode_TextChanged(object sender, EventArgs e)
        {
            if (DocTypeID == "VR")
            {
                cBPayConditions.SelectedItem = null;
                cBPayConditions.Enabled = false;
            }
        }

        /// <summary>
        /// Активация мгновенного пересчета при задействовании/снятии строки 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvInvoiceLines_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvInvoiceLines.CurrentCell is DataGridViewCheckBoxCell)
                dgvInvoiceLines.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }


        private void dgvInvoiceLines_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.RecalculateTotalAmounts();
            SetAttachImage();
        }

        private void dgvInvoiceLines_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            this.RecalculateTotalAmounts();
        }

        /// <summary>
        /// Пересчет итоговых сумм для отмеченных строк
        /// </summary>
        private void RecalculateTotalAmounts()
        {
            double totalAmountWithoutVAT = 0; // итоговая сумма без НДС
            double totalAmountVAT = 0; // итоговая сумма НДС
            double totalAmountWithVAT = 0; // итоговая сумма с НДС

            double lineSumWithoutVAT = 0; // сумма без НДС текущая

            foreach (Data.ComplaintsExt.SearchInnerDocsLinesRow row in complaintsExt.SearchInnerDocsLines.Rows)
            {
                if (row.IsChecked)
                {
                    lineSumWithoutVAT = row.SumWithoutVAT;

                    totalAmountWithoutVAT += lineSumWithoutVAT; // накапливаем сумму без НДС

                    if (row.IsVat)
                    {
                        totalAmountVAT += (lineSumWithoutVAT * 0.2F); // накапливаем сумму НДС
                        totalAmountWithVAT += (lineSumWithoutVAT * 1.2F); // накапливаем сумму с НДС
                    }
                    else
                        totalAmountWithVAT += lineSumWithoutVAT; // накапливаем сумму с НДС (для случая где нет НДС)
                }
            }

            // Устанавливаем накопленные значения итоговых сумм
            this.lblSumWithoutVAT.Text = totalAmountWithoutVAT.ToString("f2");
            this.lblSumVAT.Text = totalAmountVAT.ToString("f2");
            this.lblSumWithVAT.Text = totalAmountWithVAT.ToString("f2");
        }

        private void dgvInvoiceLines_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((DocTypeID == "NR" || DocTypeID == "CN" || DocTypeID == "VR") && e.RowIndex >= 0 && e.ColumnIndex == clmIsCold.Index && e.Value != null && !String.IsNullOrEmpty(e.Value.ToString()))
            {
                e.PaintBackground(e.ClipBounds, false);
                dgvInvoiceLines[e.ColumnIndex, e.RowIndex].ToolTipText = e.Value.ToString();
                PointF p = e.CellBounds.Location;
                p.X += Properties.Resources.snowflakeB.Width;

                e.Graphics.DrawImage(Properties.Resources.snowflakeB, e.CellBounds.X, e.CellBounds.Y, 16, 16);
                e.Graphics.DrawString(e.Value.ToString(), e.CellStyle.Font, Brushes.Black, p);
                e.Handled = true;
            }
        }

        private bool CheckAttachedFile()
        {
            bool retValue = true;
            if (DocTypeID == "NR" || DocTypeID == "CN" || DocTypeID == "VR")
            {
                foreach (DataGridViewRow row in dgvInvoiceLines.Rows)
                {
                    var rowData = (row.DataBoundItem as DataRowView).Row as Data.ComplaintsExt.SearchInnerDocsLinesRow;
                    if ((rowData == null || rowData.IsAttachNull()) && (!rowData.IsColdNull() && !String.IsNullOrEmpty(rowData.Cold)))
                    {
                        bool m_ret = false;

                        if (!Boolean.TryParse(row.Cells[colCheckBox.Index].Value == null ? String.Empty : row.Cells[colCheckBox.Index].Value.ToString(), out m_ret))
                            continue;
                        if (!m_ret)
                        {
                            row.DefaultCellStyle.BackColor = dgvInvoiceLines.BackgroundColor;
                            continue;
                        }
                        
                        row.DefaultCellStyle.BackColor = Color.Salmon;
                        retValue = retValue ? false : retValue;
                    }
                }

                if (!retValue)
                    MessageBox.Show(String.Format(@"Некоторые препаратытребуют специального условия хранения. 
                                                {0}Прикрепите скан.копию журнала регистрации условий температурного режима за весь период хранения препарата у клиента.", Environment.NewLine),
                        "Ошибка!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }

            return retValue;
        }

        private void SetAttachImage()
        {
            if (DocTypeID == "NR" || DocTypeID == "CN" || DocTypeID == "VR")
                foreach (DataGridViewRow row in dgvInvoiceLines.Rows)
                {
                    row.Cells[clmAttachImage.Index].Value = emptyIcon;
                    var rowData = (row.DataBoundItem as DataRowView).Row as Data.ComplaintsExt.SearchInnerDocsLinesRow;
                    if (rowData == null)
                        continue;
                    var buttonCell = (DataGridViewDisableButtonCell)row.Cells[clmButton.Index];
                    buttonCell.Value = "...";
                    buttonCell.ToolTipText = "Прикрепить документ";
                    buttonCell.Enabled = !rowData.IsColdNull();

                    if (!rowData.IsAttachNull())
                        row.Cells[clmAttachImage.Index].Value = AttachImage;
                }
        }

        private void dgvInvoiceLines_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                if (e.ColumnIndex == clmButton.Index)
                {
                    var buttonCell = (DataGridViewDisableButtonCell)dgvInvoiceLines.Rows[e.RowIndex].Cells[clmButton.Index];
                    if (!buttonCell.Enabled)
                        return;

                    var row = (dgvInvoiceLines.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.ComplaintsExt.SearchInnerDocsLinesRow;
                    if (row == null)
                        return;
                    using (ComplaintAttachmentForm frm = new ComplaintAttachmentForm(row.IsAttachNull() ? null : row.Attach) { Owner = this })
                    {
                        if (frm.ShowDialog() == DialogResult.Cancel)
                            return;
                        if (frm.ImageRow != null)
                        {
                            row.Attach = frm.ImageRow;
                            dgvInvoiceLines.Rows[e.RowIndex].DefaultCellStyle.BackColor = dgvInvoiceLines.BackgroundColor;
                        }
                    }
                }
                else if (e.ColumnIndex == colCheckBox.Index)
                {
                    bool ch = Convert.ToBoolean(dgvInvoiceLines.Rows[e.RowIndex].Cells[colCheckBox.Index].EditedFormattedValue);
                    foreach (DataGridViewRow row in dgvInvoiceLines.SelectedRows)
                        ((row.DataBoundItem as DataRowView).Row as Data.ComplaintsExt.SearchInnerDocsLinesRow).IsChecked = ch;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Открыть окно с прикрепленными файлами
        /// </summary>
        private void btnFiles_Click(object sender, EventArgs e)
        {
            var window = new AttachmentsForm(attachedFiles) { Owner = this };
            window.ShowDialog();
            attachedFiles = window.Files;
        }

        private void dgvInvoiceLines_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvInvoiceLines.Columns[dgvInvoiceLines.CurrentCell.ColumnIndex].DataPropertyName == complaintsExt.SearchInnerDocsLines.GuiltyEmployeesListColumn.Caption)
            {
                if (e.Control is ButtonCellEditorControl)
                {
                    var editor = e.Control as ButtonCellEditorControl;
                    editor.OnAction -= new EventHandler(editor_OnAction);
                    editor.OnAction += new EventHandler(editor_OnAction);
                }
            }
        }

        void editor_OnAction(object sender, EventArgs e)
        {
            var selector = new GuiltyEmployeesSelectionControl()
            {
                SessionID = this.SessionID,
                DocType = this.DocTypeID,
                DepartmentID = (int?)null,
                CallMode = 0
            };

            var dlgSelector = new DialogForm();
            dlgSelector.Height = 250;
            dlgSelector.Width = 320;
            dlgSelector.Text = "Выбор виновных сотрудников";
            dlgSelector.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            dlgSelector.StartPosition = FormStartPosition.CenterScreen;
            dlgSelector.Controls.Add(selector);
            
            selector.Left = 0;
            selector.Width = dlgSelector.OptionsPanel.Width;
            selector.Top = 0;
            selector.Height = dlgSelector.OptionsPanel.Top;
            selector.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;

            selector.Initialize();
            selector.Value = (dgvInvoiceLines.EditingControl as ButtonCellEditorControl).Value;

            dlgSelector.BeginShown += delegate(object s, EventArgs ea)
            {
                selector.Focus();
            };

            if (dlgSelector.ShowDialog() == DialogResult.OK)
            {
                (dgvInvoiceLines.EditingControl as ButtonCellEditorControl).Value = selector.Value.Equals(DBNull.Value) ? (string)null : selector.Value.ToString();
                dgvInvoiceLines.EndEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}
