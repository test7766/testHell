using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Dialogs.Quality;
using System.IO;
using WMSOffice.Dialogs.Complaints;
using WMSOffice.Reports;
using WMSOffice.Dialogs;
using WMSOffice.Data;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;

namespace WMSOffice.Window
{
    public partial class QualityGLSActWindow : GeneralWindow
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        private Data.Quality.GA_DocsRow SelectedDoc { get { return xdgvRecallDocs.SelectedItem as Data.Quality.GA_DocsRow; } }

        private int? selectedDocID = (int?)null;

        /// <summary>
        /// Столбец с информацией о наличии вложенных файлов
        /// </summary>
        private DataGridViewImageColumn dgvcHasAttachedFiles = null;

        /// <summary>
        /// Пустое изображение
        /// </summary>
        private static Bitmap emptyIcon = new Bitmap(16, 16);

        public QualityGLSActWindow()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Initialize();
        }

        private void Initialize()
        {
            xdgvRecallDocs.AllowSummary = false;
            xdgvRecallDocs.AllowRangeColumns = true;

            xdgvRecallDocs.UseMultiSelectMode = false;

            xdgvRecallDocs.Init(new QualityGLSActView(), true);

            xdgvRecallDocs.UserID = this.UserID;
            
            #region ИНИЦИАЛИЗАЦИЯ СТОЛБЦОВ-ИНДИКАТОРОВ
            
            foreach (DataGridViewColumn column in xdgvRecallDocs.DataGrid.Columns)
            {
                if ((column.Tag ?? string.Empty).Equals("HasAttachedFiles"))
                    dgvcHasAttachedFiles = column as DataGridViewImageColumn;
            }

            if (dgvcHasAttachedFiles == null)
            {
                this.ShowError("Отсутствует столбец с информацией о наличии вложенных файлов.");
                return;
            }

            #endregion

            xdgvRecallDocs.OnDataError += new DataGridViewDataErrorEventHandler(xdgvRecallDocs_OnDataError);
            xdgvRecallDocs.OnRowSelectionChanged += new EventHandler(xdgvRecallDocs_OnRowSelectionChanged);
            xdgvRecallDocs.OnFilterChanged += new EventHandler(xdgvRecallDocs_OnFilterChanged);
            xdgvRecallDocs.OnDataBindingComplete += new DataGridViewBindingCompleteEventHandler(xdgvRecallDocs_OnDataBindingComplete);
            xdgvRecallDocs.OnRowDoubleClick += new DataGridViewCellEventHandler(xdgvRecallDocs_OnRowDoubleClick);

            // активация постраничного просмотра
            xdgvRecallDocs.CreatePageNavigator();

            SetOperationsAccess();

            LoadDocs();
        }

        void xdgvRecallDocs_OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        void xdgvRecallDocs_OnRowSelectionChanged(object sender, EventArgs e)
        {
            SetOperationsAccess();
            LoadDetails();
        }

        void xdgvRecallDocs_OnFilterChanged(object sender, EventArgs e)
        {
            SetOperationsAccess();
            xdgvRecallDocs.RecalculateSummary();
        }

        void xdgvRecallDocs_OnDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in xdgvRecallDocs.DataGrid.Rows)
            {
                var boundRow = (xdgvRecallDocs.DataGrid.Rows[row.Index].DataBoundItem as DataRowView).Row as Data.Quality.GA_DocsRow;

                var hasAttachedFiles = false;
                object attachedFilesValue = emptyIcon;
                switch (boundRow.AttachedFiles)
                {
                    case 0:
                        attachedFilesValue = Properties.Resources.close;
                        hasAttachedFiles = true;
                        break;
                    case 1:
                        attachedFilesValue = Properties.Resources.paperclip1;
                        hasAttachedFiles = true;
                        break;
                    case 2:
                        attachedFilesValue = Properties.Resources.paperclip2;
                        hasAttachedFiles = true;
                        break;
                    case 3:
                        attachedFilesValue = Properties.Resources.paperclip3;
                        hasAttachedFiles = true;
                        break;
                    default:
                        attachedFilesValue = Properties.Resources.paperclipN;
                        hasAttachedFiles = true;
                        break;
                }

                if (hasAttachedFiles)
                    xdgvRecallDocs.DataGrid.Rows[row.Index].Cells[dgvcHasAttachedFiles.Index].Value = attachedFilesValue;
            }

            // Восстанавливаем фокус
            if (selectedDocID.HasValue)
            {
                xdgvRecallDocs.SelectRow("DocID", selectedDocID.ToString());
                xdgvRecallDocs.ScrollToSelectedRow();
            }
        }

        void xdgvRecallDocs_OnRowDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            ModifyDoc(this.SelectedDoc);
        }

        private void SetOperationsAccess()
        {
            var isEnabled = this.SelectedDoc != null;

            var canSendLetter = false;
            var canCanOpenNotificationInfo = false;
            var canChangeNotificationInfo = false;
            var canCancelRecallDoc = false;
            var canAcceptRecallDoc = false;
            var canEditRecallDoc = false;
            var canCreateConsolidatedGLSRemainsNotification = false;
            var canCreateRecallActionsProtocol = false;
            var canShowRemains = false;

            if (isEnabled)
                this.GetOperationsAccess(ref canSendLetter, ref canCanOpenNotificationInfo, ref canChangeNotificationInfo, ref canCancelRecallDoc, ref canAcceptRecallDoc, ref canEditRecallDoc, ref canCreateConsolidatedGLSRemainsNotification, ref canCreateRecallActionsProtocol, ref canShowRemains);

            btnShowAttachments.Enabled = isEnabled;

            btnAcceptRecallDoc.Enabled = isEnabled && canAcceptRecallDoc;
            btnAcceptRecallDoc.Tag = isEnabled && canEditRecallDoc;

            btnCancelRecallDoc.Enabled = isEnabled && canCancelRecallDoc;

            btnCreateRecallNotification.Enabled = isEnabled && canCanOpenNotificationInfo;
            btnCreateRecallNotification.Tag = isEnabled && canChangeNotificationInfo;

            btnSendRecalcNotification.Enabled = isEnabled && canSendLetter;

            ssbCreateConsolidatedGLSRemainsNotification.Enabled = isEnabled && canCreateConsolidatedGLSRemainsNotification;
            ssbiCreateConsolidatedGLSRemainsNotification.Enabled = isEnabled && canCreateConsolidatedGLSRemainsNotification;
            ssbiCreateConsolidatedGLSRemainsNotificationExtendedIn.Enabled = isEnabled && canCreateConsolidatedGLSRemainsNotification;

            btnCreateRecallActionsProtocol.Enabled = isEnabled && canCreateRecallActionsProtocol;
            btnShowRemains.Enabled = isEnabled && canShowRemains;

        }

        private void GetOperationsAccess(ref bool canSendLetter, ref bool canCanOpenNotificationInfo, ref bool canChangeNotificationInfo, ref bool canCancelRecallDoc, ref bool canAcceptRecallDoc, ref bool canEditRecallDoc, ref bool canCreateConsolidatedGLSRemainsNotification, ref bool canCreateRecallActionsProtocol, ref bool canShowRemains)
        {
            try
            {
                using (var adapter = new Data.QualityTableAdapters.GA_AccessTableAdapter())
                    adapter.Fill(quality.GA_Access, this.SelectedDoc.DocID, this.UserID);

                if (quality.GA_Access.Count > 0)
                {
                    var access = quality.GA_Access[0];

                    canSendLetter = access.CanSendLetter;
                    canCanOpenNotificationInfo = access.CanOpenNotificationInfo;
                    canChangeNotificationInfo = access.CanChangeNotificationInfo;
                    canCancelRecallDoc = access.CanCancelDoc;
                    canAcceptRecallDoc = access.CanAcceptDoc;
                    canEditRecallDoc = access.CanEditDoc;
                    canCreateConsolidatedGLSRemainsNotification = access.CanCreateConsolidatedGLSRemainsNotification;
                    canCreateRecallActionsProtocol = access.CanCreateRecallActionsProtocol;
                    canShowRemains = access.CanShowRemains;
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F5))
            {
                LoadDocs();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.LoadDocs();
        }

        private void LoadDocs()
        {
            this.LoadDocs(this.SelectedDoc != null ? SelectedDoc.DocID : 0);
        }

        private void LoadDocs(int? docID)
        {
            try
            {
                var searchParams = new QualityGLSActSearchParameters() { SessionID = this.UserID };

                // Запоминаем фокус
                selectedDocID = docID;

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    try
                    {
                        this.xdgvRecallDocs.DataView.FillData(e.Argument as QualityGLSActSearchParameters);
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                bw.RunWorkerCompleted += (s, e) =>
                {
                    if (e.Result is Exception)
                        this.ShowError(e.Result as Exception);
                    else
                    {
                        this.xdgvRecallDocs.BindData(false);

                        //this.xdgvRecallDocs.AllowFilter = true;
                        this.xdgvRecallDocs.AllowSummary = true;
                    }

                    splashForm.CloseForce();
                };

                splashForm.ActionText = "Выполняется получение списка актов распоряжений ГЛС..";
                bw.RunWorkerAsync(searchParams);
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void LoadDetails()
        {
            try
            {
                if (SelectedDoc == null)
                {
                    quality.GA_Doc_Details.Clear();
                    return;
                }

                using (var adapter = new Data.QualityTableAdapters.GA_Doc_DetailsTableAdapter())
                    adapter.Fill(quality.GA_Doc_Details, SelectedDoc.DocID);

                if (dgvRecalcDocDetails.Rows.Count > 0)
                    dgvRecalcDocDetails.Rows[0].Selected = false;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnCreateRecallDoc_Click(object sender, EventArgs e)
        {
            this.ModifyDoc(null, false);
        }

        private void CancelDoc(Data.Quality.GA_DocsRow doc)
        {
            this.ModifyDoc(doc, true);
        }

        private void ModifyDoc(Data.Quality.GA_DocsRow doc)
        {
            this.ModifyDoc(doc, (bool?)null);
        }

        private void ModifyDoc(Data.Quality.GA_DocsRow doc, bool? isCancelMode)
        {
            var isDocCreated = doc == null || isCancelMode == true;
            var firstDocID = doc == null ? (int?)null : isCancelMode == true ? doc.DocID : doc.IsFirstDocIDNull() ? (int?)null : doc.FirstDocID;
            var canEditDoc = isDocCreated ? true : Convert.ToBoolean(btnAcceptRecallDoc.Tag);
            var docForEdit = isDocCreated ? null : doc; 

            using (var dlg = new QualityGLSActEditForm(docForEdit) { UserID = this.UserID, IsCancelMode = isCancelMode, FirstDocID = firstDocID, CanEdit = canEditDoc })
            {
                var dlgResult = dlg.ShowDialog(this);

                if (dlgResult == DialogResult.OK || (isDocCreated && dlg.DocID.HasValue) || dlg.HasChanges)
                    this.LoadDocs(dlg.DocID);
            }
        }

        private void btnCreateRecallNotification_Click(object sender, EventArgs e)
        {
            this.CreateRecallNotification();
        }

        private void CreateRecallNotification()
        {
            try
            {
                var canChangeNotificationInfo = Convert.ToBoolean(btnCreateRecallNotification.Tag);
                using (var dlg = new QualityGLSActRecallSetParametersForm(this.SelectedDoc.DocID) { UserID = this.UserID, IsReadOnly = !canChangeNotificationInfo })
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                        SetOperationsAccess();
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }


        private void btnSendRecalcNotification_Click(object sender, EventArgs e)
        {
            this.SendRecalcNotification();
        }

        string attachmentTypeCode = (string)null;
        string receiverName = (string)null;
        private void SendRecalcNotification()
        {
            try
            {
                switch (this.SelectedDoc.StatusID)
                {
                    case 150:
                        attachmentTypeCode = "NT";
                        receiverName = "клієнту";
                        break;
                    case 100:
                    default:
                        attachmentTypeCode = "RA";
                        receiverName = "постачальнику";
                        break;
                }

                List<Data.Quality.GA_Doc_AttachmentsRow> attachments = null;
                using (var adapter = new Data.QualityTableAdapters.GA_Doc_AttachmentsTableAdapter())
                    adapter.Fill(quality.GA_Doc_Attachments, this.SelectedDoc.DocID, attachmentTypeCode);

                if (quality.GA_Doc_Attachments.Count > 0)
                {
                    attachments = new List<WMSOffice.Data.Quality.GA_Doc_AttachmentsRow>();
                    foreach (Data.Quality.GA_Doc_AttachmentsRow attachment in quality.GA_Doc_Attachments)
                        attachments.Add(attachment);
                }

                if (attachments != null)
                {
                    using (var adapter = new Data.QualityTableAdapters.GA_Mail_InfoTableAdapter())
                        adapter.Fill(quality.GA_Mail_Info, this.SelectedDoc.DocID, this.UserID);

                    if (quality.GA_Mail_Info == null || quality.GA_Mail_Info.Count == 0)
                        throw new Exception("Не удалось подготовить документ outlook.");

                    var doc = quality.GA_Mail_Info[0];
                    CreateVendorOutlookDocument(doc, attachments);
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private Microsoft.Office.Interop.Outlook.MailItem oMsg = null;

        /// <summary>
        /// Автоматическое создание документа в Outlook
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="attachments"></param>
        private void CreateVendorOutlookDocument(Data.Quality.GA_Mail_InfoRow doc, List<Data.Quality.GA_Doc_AttachmentsRow> attachments)
        {
            try
            {
                oMsg = null;

                Microsoft.Office.Interop.Outlook.Application oApp = new Microsoft.Office.Interop.Outlook.Application();
                oMsg = (Microsoft.Office.Interop.Outlook.MailItem)oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

                //oMsg.Attachments.Add(registryDoc.FilePath, Microsoft.Office.Interop.Outlook.OlAttachmentType.olByValue, 1, new FileInfo(registryDoc.FilePath).Name);

                var subject = doc.IsSubjectNull() ? string.Format("Документ {0} по внутр. документу № {1}", receiverName, SelectedDoc.DocID) : doc.Subject;
                oMsg.Subject = subject.Substring(0, Math.Min(subject.Length, 255));

                foreach (var item in attachments)
                {
                    var tmpPath_ = Path.GetTempFileName();
                    var filePath = string.Format("{0}.{1}", tmpPath_, item.FileName);
                    File.Move(tmpPath_, filePath);
                    File.WriteAllBytes(filePath, item.FileData);

                    oMsg.Attachments.Add(filePath, Microsoft.Office.Interop.Outlook.OlAttachmentType.olByValue, 1, item.FileName);
                }

                var tmpPath = Path.GetTempFileName();
                var logoPath = string.Format("{0}.png", tmpPath);
                File.Move(tmpPath, logoPath);
                File.WriteAllBytes(logoPath, (byte[])new ImageConverter().ConvertTo(Properties.Resources.logo, typeof(byte[])));
                var logo = oMsg.Attachments.Add(logoPath, Microsoft.Office.Interop.Outlook.OlAttachmentType.olEmbeddeditem, null, "");
                logo.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/proptag/0x3712001E", logoPath);

                var body = doc.TableHtml;
                oMsg.HTMLBody = string.Format(body, logoPath);
                oMsg.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatHTML;

                var to = doc.IsRecipientNull() ? (string)null : doc.Recipient;
                if (!string.IsNullOrEmpty(to))
                    oMsg.To = to;

                var cc = doc.IsCopyRecipientsNull() ? (string)null : doc.CopyRecipients;
                if (!string.IsNullOrEmpty(cc))
                    oMsg.CC = cc;

                var bcc = doc.IsBlindCopyRecipientsNull() ? (string)null : doc.BlindCopyRecipients;
                if (!string.IsNullOrEmpty(bcc))
                    oMsg.BCC = bcc;

                oMsg.Recipients.ResolveAll();

                oMsg.Display(false);

                _isSend = false;

                ((Microsoft.Office.Interop.Outlook.ItemEvents_10_Event)oMsg).Send += new Microsoft.Office.Interop.Outlook.ItemEvents_10_SendEventHandler(ThisAddIn_Send);
                ((Microsoft.Office.Interop.Outlook.ItemEvents_10_Event)oMsg).Close += new Microsoft.Office.Interop.Outlook.ItemEvents_10_CloseEventHandler(ThisAddIn_Close);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Произошла ошибка во время формирования документа outlook {0}: {1}", receiverName, ex.Message));
            }
        }

        bool _isSend = false;
        void ThisAddIn_Send(ref bool Cancel)
        {
            try
            {
                if (this.ChangeDocStatus())
                    _isSend = true;
            }
            catch (Exception ex)
            {
                Logger.ShowErrorMessageBox(string.Format("Во время отправки документа {0} произошла ошибка: ", receiverName), ex);
            }
        }

        private bool ChangeDocStatus()
        {
            using (var adapter = new Data.QualityTableAdapters.GA_DocsTableAdapter())
                adapter.ChangeDocStatus(SelectedDoc.DocID, UserID);

            return true;
        }

        void ThisAddIn_Close(ref bool Cancel)
        {
            try
            {
                if (_isSend)
                {
                    MessageBox.Show(string.Format("Отправка документа {0} завершена.", receiverName), "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ThreadSafeDelegate(() => { SetOperationsAccess(); });
                }
            }
            catch (Exception ex)
            {
                Logger.ShowErrorMessageBox(string.Format("Во время отправки документа {0} произошла ошибка: ", receiverName), ex);
            }
        }

        private void ThreadSafeDelegate(MethodInvoker method)
        {
            if (this.InvokeRequired)
                this.BeginInvoke((Delegate)method);
            else
                method();
        }


        private void btnCancelRecallDoc_Click(object sender, EventArgs e)
        {
            this.CancelRecallDoc();
        }

        private void CancelRecallDoc()
        {
            try
            {
                if (MessageBox.Show("Скасувати обраний документ?", "Увага", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                    return;

                this.CancelDoc(this.SelectedDoc);

                //using (var adapter = new Data.QualityTableAdapters.GA_DocsTableAdapter())
                //    adapter.CancelDoc(SelectedDoc.DocID, this.UserID);

                //this.SetOperationsAccess();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }


        private void btnShowAttachments_Click(object sender, EventArgs e)
        {
            this.ShowAttachments();
        }

        private void ShowAttachments()
        {
            try
            {
                using (var form = new ComplaintAttachmentsForm(UserID, SelectedDoc.DocID, false, true, false))
                {
                    form.ShowDialog(this);
                    LoadDocs();
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }


        private void btnAcceptRecallDoc_Click(object sender, EventArgs e)
        {
            this.AcceptRecallDoc();
        }

        private void AcceptRecallDoc()
        {
            try
            {
                if (this.ChangeDocStatus())
                    SetOperationsAccess();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void dgvRecalcDocDetails_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var boundRow = (dgvRecalcDocDetails.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Quality.GA_Doc_DetailsRow;

            var isCanceled = boundRow.IsIsCanceledNull() ? false : boundRow.IsCanceled;
            var itemExists = boundRow.ItemID > 0;

            if (isCanceled)
                e.CellStyle.BackColor = e.CellStyle.SelectionForeColor = Color.LightGray;

            if (!itemExists)
                e.CellStyle.ForeColor = Color.Brown;

            if (!itemExists && dgvRecalcDocDetails.Columns[e.ColumnIndex].DataPropertyName == quality.GA_Doc_Details.ItemIDColumn.Caption)
                e.Value = string.Empty;
        }

        private void ssbCreateConsolidatedGLSRemainsNotification_ButtonClick(object sender, EventArgs e)
        {
            ssbCreateConsolidatedGLSRemainsNotification.ShowDropDown();
        }

        private void ssbiCreateConsolidatedGLSRemainsNotification_Click(object sender, EventArgs e)
        {
            this.CreateConsolidatedGLSRemainsNotification();
        }

        private void CreateConsolidatedGLSRemainsNotification()
        {
            try
            {
                var dlgQualityConsolidatedGLSRemainsNotificationSearchPrintDoc = new QualityConsolidatedGLSRemainsNotificationSearchPrintDocForm { UserID = this.UserID };
                if (dlgQualityConsolidatedGLSRemainsNotificationSearchPrintDoc.ShowDialog() != DialogResult.OK)
                    return;

                var reportSource = new Quality();
                using (var adapter = new Data.QualityTableAdapters.GA_Notification_ReportsTableAdapter())
                    adapter.Fill(reportSource.GA_Notification_Reports, SelectedDoc.DocID, QualityConsolidatedGLSRemainsNotificationSearchPrintDocForm.WarehouseCode, UserID);

                if (reportSource.GA_Notification_Reports.Count == 0)
                    throw new Exception("Уведомление не содержит записей.");

                using (var report = new QualityConsolidatedGlsRemainsNotificationReport())
                {
                    report.SetDataSource(reportSource);

                    using (var reportForm = new ReportForm())
                    {
                        reportForm.ReportDocument = report;
                        reportForm.ShowDialog(this);
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }


        private void ssbiCreateConsolidatedGLSRemainsNotificationExtendedIn_Click(object sender, EventArgs e)
        {
            this.CreateConsolidatedGLSRemainsNotificationExtendedIn();
        }

        private void CreateConsolidatedGLSRemainsNotificationExtendedIn()
        {
            try
            {
                //var dlgQualityConsolidatedGLSRemainsNotificationSearchPrintDoc = new QualityConsolidatedGLSRemainsNotificationSearchPrintDocForm { UserID = this.UserID };
                //if (dlgQualityConsolidatedGLSRemainsNotificationSearchPrintDoc.ShowDialog() != DialogResult.OK)
                //    return;

                var reportSource = new Quality();
                using (var adapter = new Data.QualityTableAdapters.pr_GA_Get_Notification_AdditionsTableAdapter())
                    adapter.Fill(reportSource.pr_GA_Get_Notification_Additions, SelectedDoc.DocID, UserID);

                using (var adapter = new Data.QualityTableAdapters.pr_GA_Get_NotificationsTableAdapter())
                    adapter.Fill(reportSource.pr_GA_Get_Notifications, SelectedDoc.DocID, QualityConsolidatedGLSRemainsNotificationSearchPrintDocForm.WarehouseCode, UserID);

                if (reportSource.pr_GA_Get_Notifications.Count == 0)
                    throw new Exception("Уведомление не содержит записей.");

                using (var report = new QualityConsolidatedGlsRemainsNotificationExtendedInReport())
                {
                    report.SetDataSource(reportSource);

                    using (var reportForm = new ReportForm())
                    {
                        reportForm.ReportDocument = report;
                        reportForm.ShowDialog(this);
                    }
                }

                return;


                var dlgExport = new SaveFileDialog();
                dlgExport.Title = "Експорт Повідомлення в ДЛС на момент отримання заборони";
                dlgExport.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                dlgExport.FileName = string.Format("Повідомлення в ДЛС № {0} на момент отримання заборони", SelectedDoc.DocID);
                dlgExport.Filter = "Excel-файли (*.xlsx)|*.xlsx";
                if (dlgExport.ShowDialog() != DialogResult.OK)
                    return;

                var filePath = dlgExport.FileName;
                MemoryStream stream = new MemoryStream(Properties.Resources.QualityConsolidatedGlsRemainsNotificationExtendedInReportTemplate);

                XSSFWorkbook templateWorkbook = new XSSFWorkbook(stream);
                ISheet sheet = null;
                ICell cell = null;

                int rowNumBlank = -1;
                int rowNum = -1;

                #region Лист 1

                sheet = templateWorkbook.GetSheet("Лист1");

                // Формирование шапки
                cell = sheet.GetRow(2).GetCell(0);
                var headerNotificationAdditions = string.Format(cell.StringCellValue, reportSource.pr_GA_Get_Notification_Additions[0].GA_Doc);
                cell.SetCellValue(headerNotificationAdditions);

                rowNumBlank = 5;
                rowNum = rowNumBlank + 1; // первая строка данных реестра

                foreach (Data.Quality.pr_GA_Get_Notification_AdditionsRow item in reportSource.pr_GA_Get_Notification_Additions)
                {
                    try
                    {
                        // Клонирование бланка
                        sheet.ShiftRows(rowNum, sheet.LastRowNum, 1);
                        sheet.CopyRow(rowNumBlank, rowNum);
                        IRow row = sheet.GetRow(rowNum);

                        row.Cells[0].SetCellValue(item.ItemName);
                        row.Cells[1].SetCellValue(item.Manufactur);
                        row.Cells[2].SetCellValue(item.Lotnumber);
                        row.Cells[3].SetCellValue(item.VendorName);

                        rowNum++;
                    }
                    catch (Exception ex)
                    {

                    }
                }

                // Удаление бланка
                sheet.RemoveRow(sheet.GetRow(rowNumBlank));
                sheet.ShiftRows(rowNumBlank + 1, sheet.LastRowNum, -1);

                #endregion

                #region Лист 2

                sheet = templateWorkbook.GetSheet("Лист2");

                // Формирование шапки
                cell = sheet.GetRow(2).GetCell(0);
                var headerNotifications = string.Format(cell.StringCellValue, reportSource.pr_GA_Get_Notifications[0].DocNumber);
                cell.SetCellValue(headerNotifications);

                rowNumBlank = 5;
                rowNum = rowNumBlank + 1; // первая строка данных реестра

                foreach (Data.Quality.pr_GA_Get_NotificationsRow item in reportSource.pr_GA_Get_Notifications)
                {
                    try
                    {
                        // Клонирование бланка
                        sheet.ShiftRows(rowNum, sheet.LastRowNum, 1);
                        sheet.CopyRow(rowNumBlank, rowNum);
                        IRow row = sheet.GetRow(rowNum);

                        row.Cells[0].SetCellValue(rowNum - rowNumBlank);
                        row.Cells[1].SetCellValue(item.DocNumber);
                        row.Cells[2].SetCellValue(item.ItemName);
                        row.Cells[3].SetCellValue(item.Manufactur);
                        row.Cells[4].SetCellValue(item.Iorlot);
                        row.Cells[5].SetCellValue(item.VendorName);
                        row.Cells[6].SetCellValue(item.Doc);
                        row.Cells[7].SetCellValue(item.PRQTYS);
                        row.Cells[8].SetCellValue(item.pr_prc);
                        row.Cells[9].SetCellValue(item.sales_qnt);
                        row.Cells[10].SetCellValue(item.sales_prc);
                        row.Cells[11].SetCellValue(item.carantin_qnt);
                        row.Cells[12].SetCellValue(item.carantin_prc);

                        rowNum++;
                    }
                    catch (Exception ex)
                    {

                    }
                }

                // Удаление бланка
                sheet.RemoveRow(sheet.GetRow(rowNumBlank));
                sheet.ShiftRows(rowNumBlank + 1, sheet.LastRowNum, -1);

                #endregion

                FileStream file = new FileStream(filePath, FileMode.Create);
                templateWorkbook.Write(file);

                file.Close();
                file.Dispose();

                stream.Close();
                stream.Dispose();

                System.Diagnostics.Process.Start(filePath);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }


        private void ssbiCreateConsolidatedGLSRemainsNotificationExtendedOut_Click(object sender, EventArgs e)
        {
            this.CreateConsolidatedGLSRemainsNotificationExtendedOut();
        }

        private void CreateConsolidatedGLSRemainsNotificationExtendedOut()
        {
            try
            {
                //var dlgQualityConsolidatedGLSRemainsNotificationSearchPrintDoc = new QualityConsolidatedGLSRemainsNotificationSearchPrintDocForm { UserID = this.UserID };
                //if (dlgQualityConsolidatedGLSRemainsNotificationSearchPrintDoc.ShowDialog() != DialogResult.OK)
                //    return;

                var reportSource = new Quality();
                using (var adapter = new Data.QualityTableAdapters.pr_GA_Get_Notification_AdditionsTableAdapter())
                    adapter.Fill(reportSource.pr_GA_Get_Notification_Additions, SelectedDoc.DocID, UserID);

                using (var adapter = new Data.QualityTableAdapters.pr_GA_Get_VR_NotificationsTableAdapter())
                    adapter.Fill(reportSource.pr_GA_Get_VR_Notifications, SelectedDoc.DocID, QualityConsolidatedGLSRemainsNotificationSearchPrintDocForm.WarehouseCode, UserID);

                if (reportSource.pr_GA_Get_VR_Notifications.Count == 0)
                    throw new Exception("Уведомление не содержит записей.");

                using (var report = new QualityConsolidatedGlsRemainsNotificationExtendedOutReport())
                {
                    report.SetDataSource(reportSource);

                    using (var reportForm = new ReportForm())
                    {
                        reportForm.ReportDocument = report;
                        reportForm.ShowDialog(this);
                    }
                }

                return;

                var dlgExport = new SaveFileDialog();
                dlgExport.Title = "Експорт Повідомлення в ДЛС на момент завершення відкликання";
                dlgExport.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                dlgExport.FileName = string.Format("Повідомлення в ДЛС № {0} на момент завершення відкликання", SelectedDoc.DocID);
                dlgExport.Filter = "Excel-файли (*.xlsx)|*.xlsx";
                if (dlgExport.ShowDialog() != DialogResult.OK)
                    return;

                var filePath = dlgExport.FileName;
                MemoryStream stream = new MemoryStream(Properties.Resources.QualityConsolidatedGlsRemainsNotificationExtendedOutReportTemplate);

                XSSFWorkbook templateWorkbook = new XSSFWorkbook(stream);
                ISheet sheet = null;
                ICell cell = null;

                int rowNumBlank = -1;
                int rowNum = -1;

                #region Лист 1

                sheet = templateWorkbook.GetSheet("Лист1");

                // Формирование шапки
                cell = sheet.GetRow(2).GetCell(0);
                var headerNotificationAdditions = string.Format(cell.StringCellValue, reportSource.pr_GA_Get_Notification_Additions[0].GA_Doc);
                cell.SetCellValue(headerNotificationAdditions);

                rowNumBlank = 5;
                rowNum = rowNumBlank + 1; // первая строка данных реестра

                foreach (Data.Quality.pr_GA_Get_Notification_AdditionsRow item in reportSource.pr_GA_Get_Notification_Additions)
                {
                    try
                    {
                        // Клонирование бланка
                        sheet.ShiftRows(rowNum, sheet.LastRowNum, 1);
                        sheet.CopyRow(rowNumBlank, rowNum);
                        IRow row = sheet.GetRow(rowNum);

                        row.Cells[0].SetCellValue(item.ItemName);
                        row.Cells[1].SetCellValue(item.Manufactur);
                        row.Cells[2].SetCellValue(item.Lotnumber);
                        row.Cells[3].SetCellValue(item.VendorName);

                        rowNum++;
                    }
                    catch (Exception ex)
                    {

                    }
                }

                // Удаление бланка
                sheet.RemoveRow(sheet.GetRow(rowNumBlank));
                sheet.ShiftRows(rowNumBlank + 1, sheet.LastRowNum, -1);

                #endregion

                #region Лист 2

                sheet = templateWorkbook.GetSheet("Лист2");

                // Формирование шапки
                cell = sheet.GetRow(2).GetCell(0);
                var headerNotifications = string.Format(cell.StringCellValue, reportSource.pr_GA_Get_VR_Notifications[0].DocNumber);
                cell.SetCellValue(headerNotifications);

                rowNumBlank = 5;
                rowNum = rowNumBlank + 1; // первая строка данных реестра

                foreach (Data.Quality.pr_GA_Get_VR_NotificationsRow item in reportSource.pr_GA_Get_VR_Notifications)
                {
                    try
                    {
                        // Клонирование бланка
                        sheet.ShiftRows(rowNum, sheet.LastRowNum, 1);
                        sheet.CopyRow(rowNumBlank, rowNum);
                        IRow row = sheet.GetRow(rowNum);

                        row.Cells[0].SetCellValue(rowNum - rowNumBlank);
                        row.Cells[1].SetCellValue(item.DocNumber);
                        row.Cells[2].SetCellValue(item.ItemName);
                        row.Cells[3].SetCellValue(item.Manufactur);
                        row.Cells[4].SetCellValue(item.Iorlot);
                        row.Cells[5].SetCellValue(item.VendorName);
                        row.Cells[6].SetCellValue(item.Doc);
                        row.Cells[7].SetCellValue(item.PRQTYS);
                        row.Cells[8].SetCellValue(item.pr_prc);
                        row.Cells[9].SetCellValue(item.sales_qnt);
                        row.Cells[10].SetCellValue(item.sales_prc);
                        row.Cells[11].SetCellValue(item.TotalQuantity);
                        row.Cells[12].SetCellValue(Convert.ToDouble(item.TotalAmount));
                        row.Cells[13].SetCellValue(item.VR_Doc);

                        rowNum++;
                    }
                    catch (Exception ex)
                    {

                    }
                }

                // Удаление бланка
                sheet.RemoveRow(sheet.GetRow(rowNumBlank));
                sheet.ShiftRows(rowNumBlank + 1, sheet.LastRowNum, -1);

                #endregion

                FileStream file = new FileStream(filePath, FileMode.Create);
                templateWorkbook.Write(file);

                file.Close();
                file.Dispose();

                stream.Close();
                stream.Dispose();

                System.Diagnostics.Process.Start(filePath);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }


        private void btnCreateRecallActionsProtocol_Click(object sender, EventArgs e)
        {
            this.CreateRecallActionsProtocol();
        }

        private void CreateRecallActionsProtocol()
        {
            try
            {

                var reportSource = new Quality();

                using (var adapter = new Data.QualityTableAdapters.pr_GA_RecallInitiatorSubReportTableAdapter())
                    adapter.Fill(reportSource.pr_GA_RecallInitiatorSubReport, SelectedDoc.DocID, UserID);

                using (var adapter = new Data.QualityTableAdapters.pr_GA_NotificationInfoSubReportTableAdapter())
                    adapter.Fill(reportSource.pr_GA_NotificationInfoSubReport, SelectedDoc.DocID, UserID);

                using (var adapter = new Data.QualityTableAdapters.pr_GA_ItemRecallInfoSubReportTableAdapter())
                    adapter.Fill(reportSource.pr_GA_ItemRecallInfoSubReport, SelectedDoc.DocID, UserID);

                using (var adapter = new Data.QualityTableAdapters.pr_GA_ItemReceiveInfoSubReportTableAdapter())
                    adapter.Fill(reportSource.pr_GA_ItemReceiveInfoSubReport, SelectedDoc.DocID, UserID);

                using (var adapter = new Data.QualityTableAdapters.pr_GA_DebtorsWithdrawNotificationSubReportTableAdapter())
                    adapter.Fill(reportSource.pr_GA_DebtorsWithdrawNotificationSubReport, SelectedDoc.DocID, UserID);

                using (var adapter = new Data.QualityTableAdapters.pr_GA_ReturnInfoSubReportTableAdapter())
                    adapter.Fill(reportSource.pr_GA_ReturnInfoSubReport, SelectedDoc.DocID, UserID);

                using (var adapter = new Data.QualityTableAdapters.pr_GA_DeliveryInfoSubReportTableAdapter())
                    adapter.Fill(reportSource.pr_GA_DeliveryInfoSubReport, SelectedDoc.DocID, UserID);

                using (var adapter = new Data.QualityTableAdapters.pr_GA_RecallResultsSubReportTableAdapter())
                    adapter.Fill(reportSource.pr_GA_RecallResultsSubReport, SelectedDoc.DocID, UserID);

                using (var report = new QualityRecallActionsProtocolReport())
                {
                    report.SetDataSource(reportSource);

                    using (var reportForm = new ReportForm())
                    {
                        reportForm.ReportDocument = report;
                        reportForm.ShowDialog(this);
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }


        private void btnShowRemains_Click(object sender, EventArgs e)
        {
            this.ShowRemains();
        }

        private void ShowRemains()
        {
            try
            {
                using (var dlg = new QualityGLSActRemainsForm(this.SelectedDoc.DocID) { UserID = this.UserID })
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    { 
                    
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }
    }

    /// <summary>
    /// Представление для распоряжений ГЛС
    /// </summary>
    public class QualityGLSActView : IDataView
    {
        /// <summary>
        /// Время ожидания выполнения запроса
        /// </summary>
        private const int DEFAULT_RESPONSE_TIMEOUT = 300;

        #region IDataView Members

        private PatternColumnsCollection dataColumns = new PatternColumnsCollection();
        public PatternColumnsCollection Columns
        {
            get { return this.dataColumns; }
        }

        private DataTable data;
        public DataTable Data
        {
            get { return this.data; }
        }

        public void FillData(SearchParametersBase searchParameters)
        {
            var searchCriteria = searchParameters as QualityGLSActSearchParameters;

            var sessionID = searchCriteria.SessionID;

            using (var adapter = new Data.QualityTableAdapters.GA_DocsTableAdapter())
            {
                adapter.SetTimeout(DEFAULT_RESPONSE_TIMEOUT);
                data = adapter.GetData(sessionID);
            }
        }

        #endregion

        public QualityGLSActView()
        {
            this.dataColumns.Add(new PatternColumn("№ док.", "DocID", new FilterCompareExpressionRule<Int32>("DocID"), SummaryCalculationType.Count) { Width = 50 });
            this.dataColumns.Add(new PatternColumn("Дата документа", "DateCreated", new FilterDateCompareExpressionRule("DateCreated")) { Width = 120 });

            this.dataColumns.Add(new ImagePatternColumn("П. ф.", "HasAttachedFiles") { Width = 22 });

            this.dataColumns.Add(new PatternColumn("Ким створений", "UserCreated", new FilterPatternExpressionRule("UserCreated")) { Width = 140 });

            this.dataColumns.Add(new PatternColumn("Тип припису", "DocTypeName", new FilterPatternExpressionRule("DocTypeName"), SummaryCalculationType.Count) { Width = 200 });
            this.dataColumns.Add(new PatternColumn("Блок", "DocType", new FilterPatternExpressionRule("DocType"), SummaryCalculationType.Count) { Width = 40 });

            this.dataColumns.Add(new PatternColumn("№ припису", "DocNumber", new FilterPatternExpressionRule("DocNumber"), SummaryCalculationType.Count) { Width = 200 });
            this.dataColumns.Add(new PatternColumn("Дата припису", "DocDate", new FilterDateCompareExpressionRule("DocDate")) { Width = 130 });

            this.dataColumns.Add(new PatternColumn("Ст.", "StatusID", new FilterCompareExpressionRule<Int32>("StatusID"), SummaryCalculationType.Count) { Width = 50 });
            this.dataColumns.Add(new PatternColumn("Статус документа", "StatusName", new FilterPatternExpressionRule("StatusName")) { Width = 300 });

            this.dataColumns.Add(new PatternColumn("№ зв. док.", "FirstDocID", new FilterCompareExpressionRule<Int32>("FirstDocID"), SummaryCalculationType.Count) { Width = 100 });

            this.dataColumns.Add(new PatternColumn("Вид відкликання", "WorkTypeDescr", new FilterPatternExpressionRule("WorkTypeDescr"), SummaryCalculationType.Count) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Причина відкликання", "Reason", new FilterPatternExpressionRule("Reason"), SummaryCalculationType.Count) { Width = 170 });
            this.dataColumns.Add(new PatternColumn("Иніціатор відкликання", "InitiatorTypeDescr", new FilterPatternExpressionRule("InitiatorTypeDescr"), SummaryCalculationType.Count) { Width = 200 });
            
            this.dataColumns.Add(new PatternColumn("№ протокола", "ProtocolID", new FilterPatternExpressionRule("ProtocolID"), SummaryCalculationType.Count) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Статус протокола", "ProtocolStatus", new FilterPatternExpressionRule("ProtocolStatus"), SummaryCalculationType.Count) { Width = 160 });
        }
    }

    /// <summary>
    /// Критерий поиска
    /// </summary>
    public class QualityGLSActSearchParameters : SessionIDSearchParameters
    {
        
    }
}
