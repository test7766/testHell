using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Controls;
using WMSOffice.Dialogs.Complaints;
using System.IO;
using WMSOffice.Classes;
using WMSOffice.Reports;
using CrystalDecisions.Shared;

namespace WMSOffice.Window
{
    public partial class ComplaintActsWindow : GeneralWindow
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        private Data.Complaints.CO_Vendor_Act_HeaderRow SelectedDoc { get { return xdgvDocs.SelectedItem as Data.Complaints.CO_Vendor_Act_HeaderRow; } }

        private int? selectedDocID = (int?)null;

        /// <summary>
        /// Столбец с информацией о наличии вложенных файлов
        /// </summary>
        private DataGridViewImageColumn dgvcHasAttachedFiles = null;

        /// <summary>
        /// Пустое изображение
        /// </summary>
        private static Bitmap emptyIcon = new Bitmap(16, 16);

        public ComplaintActsWindow()
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
            dgvcColdType.DefaultCellStyle.NullValue = null;

            stbVendor.ValueReferenceQuery = "[dbo].[pr_CO_Get_Vendors_List]";
            stbVendor.UserID = this.UserID;
            stbVendor.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stbVendor_OnVerifyValue);

            stbStatusFrom.ValueReferenceQuery = "[dbo].[pr_CO_Get_Vendor_Act_Statuses_List]";
            stbStatusFrom.UserID = this.UserID;
            stbStatusFrom.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stbVendor_OnVerifyValue);
            stbStatusFrom.SetValueByDefault("100");

            stbStatusTo.ValueReferenceQuery = "[dbo].[pr_CO_Get_Vendor_Act_Statuses_List]";
            stbStatusTo.UserID = this.UserID;
            stbStatusTo.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stbVendor_OnVerifyValue);
            stbStatusTo.SetValueByDefault("450");

            stbItem.ValueReferenceQuery = "[dbo].[pr_CO_Get_Item_List]";
            stbItem.UserID = this.UserID;
            stbItem.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stbVendor_OnVerifyValue);

            xdgvDocs.AllowSummary = false;
            xdgvDocs.AllowRangeColumns = true;

            xdgvDocs.UseMultiSelectMode = false;

            xdgvDocs.Init(new ComplaintActsView(), true);
            xdgvDocs.LoadExtraDataGridViewSettings(this.Name);

            xdgvDocs.UserID = this.UserID;

            #region ИНИЦИАЛИЗАЦИЯ СТОЛБЦОВ-ИНДИКАТОРОВ

            foreach (DataGridViewColumn column in xdgvDocs.DataGrid.Columns)
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

            xdgvDocs.OnDataError += new DataGridViewDataErrorEventHandler(xdgvDocs_OnDataError);
            xdgvDocs.OnRowSelectionChanged += new EventHandler(xdgvDocs_OnRowSelectionChanged);
            xdgvDocs.OnFilterChanged += new EventHandler(xdgvDocs_OnFilterChanged);
            xdgvDocs.OnDataBindingComplete += new DataGridViewBindingCompleteEventHandler(xdgvDocs_OnDataBindingComplete);

            // активация постраничного просмотра
            xdgvDocs.CreatePageNavigator();

            SetOperationAccess();

            LoadDocs();
        }

        void stbVendor_OnVerifyValue(object sender, WMSOffice.Controls.VerifyValueArgs e)
        {
            var control = sender as SearchTextBox;
            TextBox lblDescription = null;

            if (control == stbVendor)
                lblDescription = tbVendor;
            else if (control == stbStatusFrom)
                lblDescription = tbStatusFrom;
            else if (control == stbStatusTo)
                lblDescription = tbStatusTo;
            else if (control == stbItem)
                lblDescription = tbItem;

            if (lblDescription != null)
            {
                lblDescription.Text = e.Success ? e.Description : "ЗНАЧЕНИЕ НЕ НАЙДЕНО!";
                lblDescription.ForeColor = e.Success ? SystemColors.ControlText : Color.Red;

                if (e.Success)
                    control.Value = e.Value;
                //else
                //    control.Value = string.Empty;
            }
        }

        void xdgvDocs_OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        void xdgvDocs_OnFilterChanged(object sender, EventArgs e)
        {
            SetOperationAccess();
            xdgvDocs.RecalculateSummary();
        }

        void xdgvDocs_OnDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in xdgvDocs.DataGrid.Rows)
            {
                var boundRow = (xdgvDocs.DataGrid.Rows[row.Index].DataBoundItem as DataRowView).Row as Data.Complaints.CO_Vendor_Act_HeaderRow;

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
                    xdgvDocs.DataGrid.Rows[row.Index].Cells[dgvcHasAttachedFiles.Index].Value = attachedFilesValue;
            }

            // Восстанавливаем фокус
            if (selectedDocID.HasValue)
            {
                xdgvDocs.SelectRow("ActID", selectedDocID.ToString());
                xdgvDocs.ScrollToSelectedRow();
            }
        }

        void xdgvDocs_OnRowSelectionChanged(object sender, EventArgs e)
        {
            SetOperationAccess();
            LoadDetails();
            LoadStages();
        }

        private void SetOperationAccess()
        {
            try
            {
                btnShowAttachments.Enabled =
                    btnShowExternalDocs.Enabled =
                    btnSendVendorAct.Enabled =
                    btnCreateMemoForLead.Enabled =
                    btnCloseAct.Enabled =
                    btnSetNoResponseReceived.Enabled =
                    btnCloseExchange.Enabled =
                    btnSendDocsToLawDepartment.Enabled =
                    btnSplitAct.Enabled = false;

                btnExport.Enabled = xdgvDocs.HasRows;

                if (this.SelectedDoc == null)
                    return;

                using (var adapter = new Data.ComplaintsTableAdapters.CO_Vendor_Avaliable_ActionsTableAdapter())
                    adapter.Fill(complaints.CO_Vendor_Avaliable_Actions, SelectedDoc.ActID, this.UserID);

                if (complaints.CO_Vendor_Avaliable_Actions.Count > 0)
                {
                    var action = complaints.CO_Vendor_Avaliable_Actions[0];

                    btnShowAttachments.Enabled = action.CanOpenAttachments;
                    btnShowExternalDocs.Enabled = action.CanOpenExternalDocs;
                    btnSendVendorAct.Enabled = action.CanSendVendorAct;
                    btnCreateMemoForLead.Enabled = action.CanCreateMemo;
                    btnCloseAct.Enabled = action.CanCloseAct;
                    btnSetNoResponseReceived.Enabled = action.CanSetNoResponseReceived;
                    btnCloseExchange.Enabled = action.CanCloseExchange;
                    btnSendDocsToLawDepartment.Enabled = action.CanCreateDirectumTask;
                    btnSplitAct.Enabled = action.CanSplitAct;
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
            LoadDocs();
        }

        private void LoadDocs()
        {
            try
            {
                var searchParams = new ComplaintActsSearchParameters() { SessionID = this.UserID };

                if (!string.IsNullOrEmpty(stbVendor.Value))
                {
                    int vendorID;
                    if (!int.TryParse(stbVendor.Value, out vendorID))
                        throw new Exception("Код поставщика должен быть числом.");
                    else
                        searchParams.VendorID = vendorID;
                }

                if (!string.IsNullOrEmpty(stbStatusFrom.Value))
                {
                    int statusFrom;
                    if (!int.TryParse(stbStatusFrom.Value, out statusFrom))
                        throw new Exception("Код статуса с должен быть числом.");
                    else
                        searchParams.StatusFrom = statusFrom;
                }

                if (!string.IsNullOrEmpty(stbStatusTo.Value))
                {
                    int statusTo;
                    if (!int.TryParse(stbStatusTo.Value, out statusTo))
                        throw new Exception("Код статуса по должен быть числом.");
                    else
                        searchParams.StatusTo = statusTo;
                }

                if (!string.IsNullOrEmpty(stbItem.Value))
                {
                    int itemID;
                    if (!int.TryParse(stbItem.Value, out itemID))
                        throw new Exception("Код товара должен быть числом.");
                    else
                        searchParams.ItemID = itemID;
                }

                // Запоминаем фокус
                selectedDocID = this.SelectedDoc == null ? 0 : SelectedDoc.ActID;

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    try
                    {
                        this.xdgvDocs.DataView.FillData(e.Argument as ComplaintActsSearchParameters);
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
                        this.xdgvDocs.BindData(false);

                        //this.xdgvDocs.AllowFilter = true;
                        this.xdgvDocs.AllowSummary = true;
                    }

                    splashForm.CloseForce();
                };

                splashForm.ActionText = "Выполняется получение списка актов рекламаций..";
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
                    complaints.CO_Vendor_Act_Details.Clear();
                    return;
                }

                using (var adapter = new Data.ComplaintsTableAdapters.CO_Vendor_Act_DetailsTableAdapter())
                    adapter.Fill(complaints.CO_Vendor_Act_Details, SelectedDoc.ActID, this.UserID);

                if (dgvDocDetails.Rows.Count > 0)
                    dgvDocDetails.Rows[0].Selected = false;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void LoadStages()
        {
            try
            {
                if (SelectedDoc == null)
                {
                    complaints.CO_Vendor_Act_Stages.Clear();
                    return;
                }

                using (var adapter = new Data.ComplaintsTableAdapters.CO_Vendor_Act_StagesTableAdapter())
                    adapter.Fill(complaints.CO_Vendor_Act_Stages, SelectedDoc.ActID);

                if (dgvDocStages.Rows.Count > 0)
                    dgvDocStages.Rows[0].Selected = false;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }


        private void btnShowAttachments_Click(object sender, EventArgs e)
        {
            ShowAttachments();
        }

        private void ShowAttachments()
        {
            try
            {
                using (var form = new ComplaintAttachmentsForm(UserID, SelectedDoc.Co_Doc_ID))
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


        private void btnShowExternalDocs_Click(object sender, EventArgs e)
        {
            ShowExternalDocs();
        }

        private void ShowExternalDocs()
        {
            try
            {
                using (var form = new ComplaintsExternalDocsShowForm(SelectedDoc.Co_Doc_ID) { UserID = this.UserID })
                    form.ShowDialog(this);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }


        private void btnSendVendorAct_Click(object sender, EventArgs e)
        {
            SendVendorAct();
        }

        private void SendVendorAct()
        {
            try
            {
                using (Dialogs.Complaints.ComplaintAttachmentsForm form = new ComplaintAttachmentsForm(UserID, SelectedDoc.Co_Doc_ID) { UseSelectionMode = true })
                {
                    List<Data.Complaints.DocAttachmentsRow> attachments = null;
                    if (form.ShowDialog() == DialogResult.OK)
                        attachments = new List<Data.Complaints.DocAttachmentsRow>(form.SelectedAttachments);

                    if (attachments != null)
                    {
                        using (var adapter = new Data.ComplaintsTableAdapters.CO_Vendor_Letter_PropertiesTableAdapter())
                            adapter.Fill(complaints.CO_Vendor_Letter_Properties, SelectedDoc.Co_Doc_ID, UserID);

                        if (complaints.CO_Vendor_Letter_Properties == null || complaints.CO_Vendor_Letter_Properties.Count == 0)
                            throw new Exception("Не удалось подготовить документ outlook с актом поставщику.");

                        var doc = complaints.CO_Vendor_Letter_Properties[0];
                        CreateVendorOutlookDocument(doc, attachments);
                    }
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
        private void CreateVendorOutlookDocument(Data.Complaints.CO_Vendor_Letter_PropertiesRow doc, List<Data.Complaints.DocAttachmentsRow> attachments)
        {
            try
            {
                oMsg = null;

                Microsoft.Office.Interop.Outlook.Application oApp = new Microsoft.Office.Interop.Outlook.Application();
                oMsg = (Microsoft.Office.Interop.Outlook.MailItem)oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

                //oMsg.Attachments.Add(registryDoc.FilePath, Microsoft.Office.Interop.Outlook.OlAttachmentType.olByValue, 1, new FileInfo(registryDoc.FilePath).Name);

                var subject = doc.IsSubjectNull() ? string.Format("Акт поставщику по претензии № {0}", SelectedDoc.Co_Doc_ID) : doc.Subject;
                oMsg.Subject = subject.Substring(0, Math.Min(subject.Length, 255));

                foreach (var item in attachments)
                {
                    var tmpPath_ = Path.GetTempFileName();
                    var filePath = string.Format("{0}.{1}", tmpPath_, item.File_Name);
                    File.Move(tmpPath_, filePath);
                    File.WriteAllBytes(filePath, item.File_Data);

                    oMsg.Attachments.Add(filePath, Microsoft.Office.Interop.Outlook.OlAttachmentType.olByValue, 1, item.File_Name);
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
                throw new Exception(string.Format("Произошла ошибка во время формирования документа outlook акта поставщику: {0}", ex.Message));
            }
        }

        bool _isSend = false;
        void ThisAddIn_Send(ref bool Cancel)
        {
            try
            {
                using (var adapter = new Data.ComplaintsTableAdapters.CO_Create_ActDiscrepancy_HeaderTableAdapter())
                    adapter.UpdateAct(UserID, SelectedDoc.Co_Doc_ID);

                _isSend = true;
            }
            catch (Exception ex)
            {
                Logger.ShowErrorMessageBox("Во время отправки акта поставщику произошла ошибка: ", ex);
            }
        }

        void ThisAddIn_Close(ref bool Cancel)
        {
            try
            {
                if (_isSend)
                {
                    MessageBox.Show("Отправка акта поставщику завершена.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ThreadSafeDelegate(() => { SetOperationAccess(); });
                }
            }
            catch (Exception ex)
            {
                Logger.ShowErrorMessageBox("Во время отправки акта поставщику произошла ошибка: ", ex);
            }
        }

        private void ThreadSafeDelegate(MethodInvoker method)
        {
            if (this.InvokeRequired)
                this.BeginInvoke((Delegate)method);
            else
                method();
        }

        private void btnCreateMemoForLead_Click(object sender, EventArgs e)
        {
            CreateMemoForLead();
        }

        private void CreateMemoForLead()
        {
            try
            {
                using (var report = new ComplaintActMemoReport())
                {
                    var ds = new Data.Complaints();

                    // 1. Заголовок - complaints.CO_Vendor_Act_Header_For_Memo - загружаем
                    using (var adapter = new Data.ComplaintsTableAdapters.CO_Vendor_Act_Header_For_MemoTableAdapter())
                        adapter.Fill(ds.CO_Vendor_Act_Header_For_Memo, SelectedDoc.ActID);

                    // 2. Детали - complaints.CO_Vendor_Act_Details - уже загружены
                    ds.CO_Vendor_Act_Details.Merge(complaints.CO_Vendor_Act_Details, true);

                    report.SetDataSource(ds);

                    string message = ExportHelper.ExportCrystalReport(report, ExportFormatType.RichText, "Экспорт СЗ для Руководства",
                        "акт №" + SelectedDoc.ActNumber, true);

                    if (!String.IsNullOrEmpty(message))
                        Logger.ShowErrorMessageBox("Во время экспорта возникла ошибка: " + Environment.NewLine + message);
                    else
                    {
                        using (var adapter = new Data.ComplaintsTableAdapters.CO_Create_ActDiscrepancy_HeaderTableAdapter())
                            adapter.UpdateAct(UserID, SelectedDoc.Co_Doc_ID);

                        LoadDocs();
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }


        private void btnCloseAct_Click(object sender, EventArgs e)
        {
            CloseAct();
        }

        private void CloseAct()
        {
            try
            {
                using (var form = new ComplaintActCloseForm(SelectedDoc.ActID, SelectedDoc.ActNumber) { UserID = this.UserID })
                    if (form.ShowDialog(this) == DialogResult.OK)
                        LoadDocs();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnSetNoResponseReceived_Click(object sender, EventArgs e)
        {
            SetNoResponseReceived();
        }

        private void SetNoResponseReceived()
        {
            try
            {
                using (EnterStringValueForm dlgEnterStringValue = new EnterStringValueForm("Ответ не получен", string.Format("Введите примечание для фиксации неполученного ответа по акту № {0}", SelectedDoc.ActNumber), string.Empty) { AllowEmptyValue = false })
                    if (dlgEnterStringValue.ShowDialog() == DialogResult.OK)
                    {
                        var note = dlgEnterStringValue.Value;
                        using (var adapter = new Data.ComplaintsTableAdapters.CO_Vendor_Act_HeaderTableAdapter())
                            adapter.SetNoResponseReceived(this.UserID, SelectedDoc.ActID, note);

                        LoadDocs();
                    }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }


        private void btnCloseExchange_Click(object sender, EventArgs e)
        {
            CloseExchange();
        }

        private void CloseExchange()
        {
            try
            {
                using (var form = new EnterStringValueForm("Завершение обмена / довоза", string.Format("Введите примечание для подтверждения операции по акту № {0}", SelectedDoc.ActNumber), string.Empty) { AllowEmptyValue = false })
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        var note = form.Value;
                        using (var adapter = new Data.ComplaintsTableAdapters.CO_Vendor_Act_HeaderTableAdapter())
                            adapter.CreateActExchange(SelectedDoc.ActID, note, this.UserID);
                        
                        LoadDocs();
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }


        private void btnSendDocsToLawDepartment_Click(object sender, EventArgs e)
        {
            SendDocsToLawDepartment();
        }

        private void SendDocsToLawDepartment()
        {
            try
            {
                using (var adapter = new Data.ComplaintsTableAdapters.CO_Vendor_Act_HeaderTableAdapter())
                    adapter.SendDocsToLawDepartment(SelectedDoc.ActID, this.UserID);

                LoadDocs();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }


        private void btnSplitAct_Click(object sender, EventArgs e)
        {
            this.SplitAct();
        }

        private void SplitAct()
        {
            try
            {
                var dlgComplaintActSplit = new ComplaintActSplitForm(this.SelectedDoc.ActID) { UserID = this.UserID };
                if (dlgComplaintActSplit.ShowDialog() == DialogResult.OK)
                {
                    LoadDocs();
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }


        private void btnExport_Click(object sender, EventArgs e)
        {
            Export();
        }

        private void Export()
        {
            try
            {
                var sbDocs = new StringBuilder();
                var dtDocs = xdgvDocs.DataView.Data.DefaultView.ToTable(true, "ActID");
                var cntDocs = dtDocs.Rows.Count;

                foreach (DataRow doc in dtDocs.Rows)
                {
                    if (sbDocs.Length > 0)
                        sbDocs.AppendFormat(",{0}", doc["ActID"]);
                    else
                        sbDocs.AppendFormat("{0}", doc["ActID"]);
                }

                var csvDocs = sbDocs.ToString();
                var docs = GetVendorActWithDetails(UserID, csvDocs);
                if (docs == null)
                    return;

                var message = ExportHelper.ExportDataTableToExcel(docs,
                    new string[] { "Тип документа", "Номер акта", "Дата акта", "Тип акта", "Код поставщика", "Поставщик", "Номер претензии", 
                    "Кем создана", "Код статуса", "Статус", "Результат согласования", "МОЗ", 
                    "Дата просрочки", "Код товара", "Товар", "Производитель", "Партия", "Серия", 
                    "ЕИ", "К-во", "Склад", "Место", "Валюта", "Цена", "НДС", "Сумма" },
                    new string[] { "DocType", "ActNumber", "ActDate", "ActTypeName", "VendorID", "VendorName", "Co_Doc_ID", 
                    "UserCreated", "StatusID", "StatusName", "ResultName", "MOZ", 
                    "ExpirationDate", "Item_ID", "Item_Name", "Manufacturer", "Lot_Number", "Vendor_Lot_Fact", 
                    "UnitOfMeasure", "Qty", "Warehouse_ID", "location_id", "CurrencyID", "Price", "VatRate", "Amount" }, 
                    "Экспорт перечня актов со строками", String.Format("Перечень актов ({0}) со строками", cntDocs), true);

                if (!String.IsNullOrEmpty(message))
                    Logger.ShowErrorMessageBox(String.Format("Во время экспорта в Excel возникла ошибка:\n{0}", message));
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        /// <summary>
        /// Получение таблицы перечня актов со строками 
        /// </summary>
        /// <param name="pSessionID">Код сессии пользователя</param>
        /// <param name="pcsvDocs"></param>
        /// <returns>Таблица перечня актов со строками</returns>
        private static Data.Complaints.CO_Doc_Vendor_Act_Combin_ExportDataTable GetVendorActWithDetails(long pSessionID, string pcsvDocs)
        {
            try
            {
                using (var adapter = new Data.ComplaintsTableAdapters.CO_Doc_Vendor_Act_Combin_ExportTableAdapter())
                    return adapter.GetData(pSessionID, pcsvDocs);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Не удалось загрузить акты со строками: ", exc);
                return null;
            }
        }


        private void ComplaintActsWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                xdgvDocs.SaveExtraDataGridViewSettings(this.Name);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void dgvDocDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvDocDetails.Rows)
            {
                var dataRow = (row.DataBoundItem as DataRowView).Row as Data.Complaints.CO_Vendor_Act_DetailsRow;

                if (dataRow.IsColdTypeNull() || string.IsNullOrEmpty(dataRow.ColdType))
                {
                    row.Cells[dgvcColdType.Index].Value = emptyIcon;
                }
                else
                {
                    if (dataRow.ColdType == "R")
                    {
                        row.Cells[dgvcColdType.Index].Value = Properties.Resources.snowflakeR;
                        row.Cells[dgvcColdType.Index].ToolTipText = "Признак холода 2-8";
                    }
                    else if (dataRow.ColdType == "B")
                    {
                        row.Cells[dgvcColdType.Index].Value = Properties.Resources.snowflakeB;
                        row.Cells[dgvcColdType.Index].ToolTipText = "Признак холода 8-15";
                    }
                }
            }
        }
    }

    /// <summary>
    /// Представление для актов рекламаций
    /// </summary>
    public class ComplaintActsView : IDataView
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
            var searchCriteria = searchParameters as ComplaintActsSearchParameters;

            var sessionID = searchCriteria.SessionID;
            var statusFrom = searchCriteria.StatusFrom;
            var statusTo = searchCriteria.StatusTo;
            var vendorID = searchCriteria.VendorID;
            var itemID = searchCriteria.ItemID;

            using (var adapter = new Data.ComplaintsTableAdapters.CO_Vendor_Act_HeaderTableAdapter())
            {
                adapter.SetTimeout(DEFAULT_RESPONSE_TIMEOUT);
                data = adapter.GetData(statusFrom, statusTo, vendorID, sessionID, itemID);
            }
        }

        #endregion

        public ComplaintActsView()
        {
            this.dataColumns.Add(new PatternColumn("№ док.", "ActID", new FilterCompareExpressionRule<Int32>("ActID"), SummaryCalculationType.Count) { Width = 70 });
            this.dataColumns.Add(new PatternColumn("№ акта", "ActNumber", new FilterPatternExpressionRule("ActNumber"), SummaryCalculationType.Count) { Width = 70 });
            this.dataColumns.Add(new PatternColumn("Дата акта", "ActDate", new FilterDateCompareExpressionRule("ActDate")) { Width = 100 });

            this.dataColumns.Add(new ImagePatternColumn("П. ф.", "HasAttachedFiles") { Width = 22 });

            this.dataColumns.Add(new PatternColumn("Код пост.", "VendorID", new FilterCompareExpressionRule<Int32>("VendorID"), SummaryCalculationType.Count) { Width = 80 });
            this.dataColumns.Add(new PatternColumn("Наим. поставщика", "VendorName", new FilterPatternExpressionRule("VendorName")) { Width = 160 });

            this.dataColumns.Add(new PatternColumn("Тип акта", "ActType", new FilterPatternExpressionRule("ActType"), SummaryCalculationType.Count) { Width = 85 });
            this.dataColumns.Add(new PatternColumn("Назв. типа", "ActTypeName", new FilterPatternExpressionRule("ActTypeName")) { Width = 150 });

            this.dataColumns.Add(new PatternColumn("№ претензии", "Co_Doc_ID", new FilterCompareExpressionRule<Int64>("Co_Doc_ID"), SummaryCalculationType.Count) { Width = 105 });
            this.dataColumns.Add(new PatternColumn("Кем создана", "UserCreated", new FilterPatternExpressionRule("UserCreated")) { Width = 140 });

            this.dataColumns.Add(new PatternColumn("Статус", "StatusID", new FilterCompareExpressionRule<Int32>("StatusID"), SummaryCalculationType.Count) { Width = 50 });
            this.dataColumns.Add(new PatternColumn("Назв. статуса", "StatusName", new FilterPatternExpressionRule("StatusName")) { Width = 200 });

            this.dataColumns.Add(new PatternColumn("Рез. согласования", "ResultName", new FilterPatternExpressionRule("ResultName")) { Width = 140 });

            this.dataColumns.Add(new PatternColumn("МОЗ", "MOZ", new FilterPatternExpressionRule("MOZ")) { Width = 160 });
            this.dataColumns.Add(new PatternColumn("Дата просрочки", "ExpirationDate", new FilterDateCompareExpressionRule("ExpirationDate")) { Width = 120 });

            this.dataColumns.Add(new PatternColumn("Тип документа", "DocType", new FilterPatternExpressionRule("DocType"), SummaryCalculationType.Count) { Width = 120 });
        }
    }

    /// <summary>
    /// Критерий поиска
    /// </summary>
    public class ComplaintActsSearchParameters : SessionIDSearchParameters
    {
        public int? VendorID { get; set; }
        public int? StatusFrom { get; set; }
        public int? StatusTo { get; set; }
        public int? ItemID { get; set; }
    }
}
