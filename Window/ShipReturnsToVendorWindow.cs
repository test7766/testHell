using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Dialogs.Complaints;
using WMSOffice.Reports;
using WMSOffice.Classes;
using WMSOffice.Controls;
using System.IO;
using WMSOffice.Dialogs;
using System.Transactions;

namespace WMSOffice.Window
{
    public partial class ShipReturnsToVendorWindow : GeneralWindow
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        public DateTime? PeriodFrom { get; private set; }

        public ShipReturnsToVendorWindow()
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
            #region ИНИЦИАЛИЗАЦИЯ ПЕРИОДА ПОИСКА

            var dtpDateFrom = new DateTimePicker { Value = (this.PeriodFrom = DateTime.Today).Value };
            dtpDateFrom.Width = 100;
            dtpDateFrom.Format = DateTimePickerFormat.Custom;
            dtpDateFrom.CustomFormat = "dd.MM.yyyy";
            dtpDateFrom.ValueChanged += (s, e) => { this.PeriodFrom = dtpDateFrom.Value.Date; };
            tsMain.Items.Insert(1, new ToolStripControlHost(dtpDateFrom));

            #endregion

            #region ИНИЦИАЛИЗАЦИЯ ПРИНТЕРОВ

            PrintDocsThread.FillPrintersComboBox(cmbPrinters.ComboBox);

            #endregion

            xdgvVendorReturnsGroups.AllowSummary = false;
            xdgvVendorReturnsGroups.UseMultiSelectMode = false;

            xdgvVendorReturnsGroups.Init(new ShipReturnsToVendorView(), true);
            xdgvVendorReturnsGroups.LoadExtraDataGridViewSettings(this.Name);

            xdgvVendorReturnsGroups.UserID = this.UserID;

            xdgvVendorReturnsGroups.OnDataError += new DataGridViewDataErrorEventHandler(xdgvVendorReturnsGroups_OnDataError);
            xdgvVendorReturnsGroups.OnRowSelectionChanged += new EventHandler(xdgvVendorReturnsGroups_OnRowSelectionChanged);
            xdgvVendorReturnsGroups.OnFilterChanged += new EventHandler(xdgvVendorReturnsGroups_OnFilterChanged);

            SetOperationAccess();

            RefreshVendorReturnsGroups();

            dtpDateFrom.Focus();
        }

        void xdgvVendorReturnsGroups_OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        void xdgvVendorReturnsGroups_OnFilterChanged(object sender, EventArgs e)
        {
            SetOperationAccess();
            xdgvVendorReturnsGroups.RecalculateSummary();
        }

        void xdgvVendorReturnsGroups_OnRowSelectionChanged(object sender, EventArgs e)
        {
            try
            {
                SetOperationAccess();

                if (xdgvVendorReturnsGroups.SelectedItems.Count == 1)
                {
                    Data.Complaints.SV_VR_Docs_VendorsRow row = (Data.Complaints.SV_VR_Docs_VendorsRow)(xdgvVendorReturnsGroups.SelectedItems[0]);

                    var vendorID = Convert.ToInt64(row.Vendor_ID);
                    var dateFrom = this.PeriodFrom;
                    var jdeDocNumber = row.IsJDE_DocNumberNull() ? (string)null : row.JDE_DocNumber.ToString();
                    RefreshVendorReturns(vendorID, dateFrom, jdeDocNumber);
                }
                else
                    ClearVendorReturns();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void RefreshVendorReturns(long? vendorID, DateTime? dateFrom, string jdeDocNumber)
        {
            sV_VR_Docs_By_VendorTableAdapter.Fill(complaints.SV_VR_Docs_By_Vendor, this.UserID, vendorID ,dateFrom, jdeDocNumber);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshVendorReturnsGroups();
        }

        private void RefreshVendorReturnsGroups()
        {
            RefreshVendorReturnsGroups((string)null);
        }

        private void RefreshVendorReturnsGroups(string jdeDocNumber)
        {
            ClearVendorReturns();

            try
            {
                var searchParams = new ShipReturnsToVendorSearchParameters() { SessionID = this.UserID };
                searchParams.DateFrom = this.PeriodFrom;
                searchParams.JDE_DocNumber = jdeDocNumber;
                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    try
                    {
                        this.xdgvVendorReturnsGroups.DataView.FillData(e.Argument as ShipReturnsToVendorSearchParameters);
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
                        this.xdgvVendorReturnsGroups.BindData(false);

                        //this.xdgvVendorReturnsGroups.AllowFilter = true;
                        this.xdgvVendorReturnsGroups.AllowSummary = true;
                    }

                    splashForm.CloseForce();
                };

                splashForm.ActionText = "Выполняется получение списка поставщиков для возвратов..";
                bw.RunWorkerAsync(searchParams);
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void ClearVendorReturns()
        {
            ClearVendorReturnsItems();
            complaints.SV_VR_Docs_By_Vendor.Clear();
        }

        private void dgvVendorReturns_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                SetOperationAccess();

                if (dgvVendorReturns.SelectedRows.Count == 1)
                {
                    Data.Complaints.SV_VR_Docs_By_VendorRow row = (Data.Complaints.SV_VR_Docs_By_VendorRow)((dgvVendorReturns.SelectedRows[0].DataBoundItem as DataRowView).Row);

                    var docID = Convert.ToInt64(row.Doc_ID);
                    RefreshVendorReturnsItems(docID);
                }
                else
                    ClearVendorReturnsItems();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void SetOperationAccess()
        {
            var cntGroups = xdgvVendorReturnsGroups.SelectedItems.Count;
            var isGroupEnabled = cntGroups > 0;
            var hasTTN = isGroupEnabled && !xdgvVendorReturnsGroups.SelectedItems[0]["SV_Doc_ID"].Equals(DBNull.Value);
            var hasPrintedTTN = isGroupEnabled && !xdgvVendorReturnsGroups.SelectedItems[0]["SV_Doc_Printed"].Equals(DBNull.Value);

            btnAddShipmentMethod.Enabled = isGroupEnabled;
            btnPrintWaybillReport.Enabled = isGroupEnabled && hasTTN;
            btnPrintDocsPackage.Enabled = isGroupEnabled;
            btnShipVendorReturn.Enabled = isGroupEnabled && hasTTN && hasPrintedTTN;

            var isRowsSelected = dgvVendorReturns.SelectedRows.Count > 0;
            btnShowAttachments.Enabled = isRowsSelected;
            btnChangeVendorReturnDate.Enabled = isRowsSelected;
            btnExportVendorReturnItems.Enabled = isRowsSelected && dgvVendorReturns.Rows.Count > 0;
        }

        private void dgvVendorReturns_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void RefreshVendorReturnsItems(long? docID)
        {
            sV_VR_Doc_DetailsTableAdapter.Fill(complaints.SV_VR_Doc_Details, this.UserID, docID);
        }

        /// <summary>
        /// Пустое изображение
        /// </summary>
        private static Bitmap emptyIcon = new Bitmap(16, 16);

        private void dgvVendorReturns_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvVendorReturns.Rows)
            {
                var boundRow = (dgvVendorReturns.Rows[row.Index].DataBoundItem as DataRowView).Row as Data.Complaints.SV_VR_Docs_By_VendorRow;

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
                    dgvVendorReturns.Rows[row.Index].Cells[dgvcHasAttachedFiles.Index].Value = attachedFilesValue;
            }
        }

        private void dgvVendorReturns_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            Data.Complaints.SV_VR_Docs_By_VendorRow row = (Data.Complaints.SV_VR_Docs_By_VendorRow)((dgvVendorReturns.Rows[e.RowIndex].DataBoundItem as DataRowView).Row);

            var color = row.IsPlanDate_Change_CheckNull() ? SystemColors.Window : row.PlanDate_Change_Check == 1 ? Color.Khaki : row.PlanDate_Change_Check == 2 ? Color.LightPink : row.PlanDate_Change_Check == 0 ? SystemColors.Window : SystemColors.Window;
            
            e.CellStyle.BackColor = e.CellStyle.SelectionForeColor = color;
        }


        private void ClearVendorReturnsItems()
        {
            complaints.SV_VR_Doc_Details.Clear();
        }

        private void dgvVendorReturnItems_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F5))
            {
                RefreshVendorReturnsGroups();
                return true;
            }

            if (keyData == (Keys.Control | Keys.F))
            {
                FindVendorReturn();
                return true;
            }

            if (keyData == (Keys.Control | Keys.E))
            {
                ChangeVendorReturnDate();
                return true;
            }

            if (keyData == (Keys.Control | Keys.M))
            {
                AddShipmentMethod();
                return true;
            }

            if (keyData == (Keys.Control | Keys.S))
            {
                ExportVendorReturnItems();
                return true;
            }

            if (keyData == (Keys.Control | Keys.P))
            {
                PrintWaybillReport();
                return true;
            }

            if (keyData == (Keys.Control | Keys.G))
            {
                PrintDocsPackage();
                return true;
            }

            if (keyData == (Keys.Control | Keys.H))
            {
                ShipVendorReturn();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ShipReturnsToVendorWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                xdgvVendorReturnsGroups.SaveExtraDataGridViewSettings(this.Name);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnFindVendorReturn_Click(object sender, EventArgs e)
        {
            FindVendorReturn();
        }

        private void FindVendorReturn()
        {
            var frmShipReturnsToVendorFind = new ShipReturnsToVendorFindForm() { UserID = this.UserID };
            if (frmShipReturnsToVendorFind.ShowDialog() == DialogResult.OK)
            {
                var jdeDocNumber = frmShipReturnsToVendorFind.DocNumberJDE.ToString(); 
                RefreshVendorReturnsGroups(jdeDocNumber);
            }
        }

        private const int SPIRE_DOC_MAX_PAGE_COUNT = 3;
        private void btnShowAttachments_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvVendorReturns.SelectedRows.Count == 0)
                    return;

                Data.Complaints.SV_VR_Docs_By_VendorRow row = (Data.Complaints.SV_VR_Docs_By_VendorRow)((dgvVendorReturns.SelectedRows[0].DataBoundItem as DataRowView).Row);

                var docID = Convert.ToInt64(row.Doc_ID);

                using (var form = new ComplaintAttachmentsForm(this.UserID, docID, true, false, false) { DeleteCanAccess = false, AddCanAccess = false, EditCanAccess = false, UseSelectionMode = true })
                {
                    List<Data.Complaints.DocAttachmentsRow> attachments = null;

                    if (form.ShowDialog() == DialogResult.OK && MessageBox.Show("Запустить печать выбранных документов?", "Запуск печати", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                        attachments = new List<Data.Complaints.DocAttachmentsRow>(form.SelectedAttachments);

                    if (attachments != null)
                    {
                        var isPrinted = false;
                        foreach (var doc in attachments)
                        {
                            var fileName = doc.File_Name.ToUpper();

                            try
                            {
                                if (fileName.EndsWith(".DOCX"))
                                {
                                    using (var ms = new MemoryStream(doc.File_Data))
                                    using (var pdoc = new Spire.Doc.Document(ms))
                                    {
                                        var pcnt = pdoc.PageCount;
                                        if (pcnt <= SPIRE_DOC_MAX_PAGE_COUNT || MessageBox.Show(string.Format("Количество страниц в документе \"{0}\"\r\nпревышает максимально допустимое ({1} стр.).\r\nПродолжить печать?", fileName, SPIRE_DOC_MAX_PAGE_COUNT), "Ограничение печати", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                                        {
                                            pdoc.PrintDocument.PrinterSettings.PrinterName = cmbPrinters.ComboBox.Text;
                                            pdoc.PrintDocument.Print();

                                            isPrinted = true;
                                        }

                                        //pdoc.SaveToFile(System.IO.Path.Combine(@"D:\Temp\ret\", doc.File_Name), Spire.Doc.FileFormat.Docx);
                                    }
                                }
                                else if (fileName.EndsWith(".PDF"))
                                {
                                    using (var ms = new MemoryStream(doc.File_Data))
                                    using (var pdoc = new Spire.Pdf.PdfDocument(ms))
                                    {
                                        var pcnt = pdoc.Pages.Count;
                                        if (pcnt <= SPIRE_DOC_MAX_PAGE_COUNT || MessageBox.Show(string.Format("Количество страниц в документе \"{0}\"\r\nпревышает максимально допустимое ({1} стр.).\r\nПродолжить печать?", fileName, SPIRE_DOC_MAX_PAGE_COUNT), "Ограничение печати", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                                        {
                                            pdoc.PrintDocument.PrinterSettings.PrinterName = cmbPrinters.ComboBox.Text;
                                            pdoc.PrintDocument.Print();

                                            isPrinted = true;
                                        }

                                        //pdoc.SaveToFile(System.IO.Path.Combine(@"D:\Temp\ret\", doc.File_Name), Spire.Pdf.FileFormat.PDF);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(string.Format("Документ \"{0}\" имеет недопустимый для печати формат и будет пропущен.", fileName), "Отмена печати", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                            catch (Exception ex)
                            {
                                this.ShowError(string.Format("Во время печати документа \"{0}\" произошла следующая ошибка:\r\n{1}", fileName, ex));
                            }
                        }

                        if (isPrinted)
                            MessageBox.Show("Печать завершена.", "Подтверждение печати", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Ни один из выбранных документов не был напечатан.", "Отмена печати", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnChangeVendorReturnDate_Click(object sender, EventArgs e)
        {
            ChangeVendorReturnDate();
        }

        private void ChangeVendorReturnDate()
        {
            try
            {
                if (!btnChangeVendorReturnDate.Enabled)
                    return;

                Data.Complaints.SV_VR_Docs_By_VendorRow row = (Data.Complaints.SV_VR_Docs_By_VendorRow)((dgvVendorReturns.SelectedRows[0].DataBoundItem as DataRowView).Row);

                var docID = row.Doc_ID;
                var planDate = row.IsPlanReturnDateNull() ? DateTime.Today : row.PlanReturnDate;

                var frmShipReturnsToVendorEditPlanDate = new ShipReturnsToVendorEditPlanDateForm() { UserID = this.UserID, PlanDate = planDate };
                if (frmShipReturnsToVendorEditPlanDate.ShowDialog() == DialogResult.OK)
                {
                    planDate = frmShipReturnsToVendorEditPlanDate.PlanDate;

                    using (var adapter = new Data.ComplaintsTableAdapters.SV_VR_Docs_By_VendorTableAdapter())
                        adapter.UpdateDocPlanReturnDate(this.UserID, docID, planDate);

                    this.RefreshVendorReturnsGroups();
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnAddShipmentMethod_Click(object sender, EventArgs e)
        {
            AddShipmentMethod();
        }

        private void AddShipmentMethod()
        {
            try
            {
                if (!btnAddShipmentMethod.Enabled)
                    return;

                var vendor = xdgvVendorReturnsGroups.SelectedItem as Data.Complaints.SV_VR_Docs_VendorsRow;
                var frmShipReturnsToVendorAddShipmentMethod = new ShipReturnsToVendorAddShipmentMethodForm(vendor.Vendor_ID, this.PeriodFrom) { UserID = this.UserID };
                if (frmShipReturnsToVendorAddShipmentMethod.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshVendorReturnsGroups();
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnExportVendorReturnItems_Click(object sender, EventArgs e)
        {
            ExportVendorReturnItems();
        }

        private void ExportVendorReturnItems()
        {
            try
            {
                if (!btnExportVendorReturnItems.Enabled)
                    return;

                Data.Complaints.SV_VR_Docs_By_VendorRow row = (Data.Complaints.SV_VR_Docs_By_VendorRow)((dgvVendorReturns.SelectedRows[0].DataBoundItem as DataRowView).Row);

                var docID = row.JDE_Doc;

                string message = WMSOffice.Classes.ExportHelper.ExportDataGridViewToExcel(dgvVendorReturnItems, "Экспорт товаров в накладной",
                "товары в накладной №" + docID, true);

                if (!String.IsNullOrEmpty(message))
                    throw new Exception(message);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnPrintWaybillReport_Click(object sender, EventArgs e)
        {
            this.PrintWaybillReport();
        }

        private void PrintWaybillReport()
        {
            try
            {
                if (!btnPrintWaybillReport.Enabled)
                    return;

                var vendor = xdgvVendorReturnsGroups.SelectedItem as Data.Complaints.SV_VR_Docs_VendorsRow;
                var svDocID = vendor.IsSV_Doc_IDNull() ? (int?)null : vendor.SV_Doc_ID;
                var reportData = this.GetWaybillReportData(vendor.Vendor_ID, this.PeriodFrom.Value);

                var needPrintWatermark = PrintDocsThread.CheckNeedPrintWatermark(this.UserID, "SV", 7, Convert.ToInt64(reportData.SV_VR_WaybillReport_Header[0].ttn_number), (string)null);

                using (var report = new VendorReturnWaybillReport())
                {
                    report.SetDataSource(reportData);
                    report.SetParameterValue("NeedPrintWatermark", needPrintWatermark);

                    var form = new ReportForm();
                    form.ReportDocument = report;
                    form.ShowDialog();

                    if (form.IsPrinted)
                    {
                        // логирование факта печати
                        PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "SV", 7, Convert.ToInt64(reportData.SV_VR_WaybillReport_Header[0].ttn_number), (string)null, Convert.ToInt16(reportData.SV_VR_WaybillReport_Details.Count), cmbPrinters.Text, 1);

                        // Фиксация печати ТТН
                        using (var adapter = new Data.ComplaintsTableAdapters.SV_VR_Docs_By_VendorTableAdapter())
                            adapter.SetDocPrintDate(this.UserID, svDocID, (long?)null);
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private Data.Complaints GetWaybillReportData(int vendorID, DateTime periodFrom)
        {
            var data = new Data.Complaints();

            using (var adapter = new Data.ComplaintsTableAdapters.SV_VR_WaybillReport_HeaderTableAdapter())
                adapter.Fill(data.SV_VR_WaybillReport_Header, this.UserID, vendorID, periodFrom);

            using (var adapter = new Data.ComplaintsTableAdapters.SV_VR_WaybillReport_DetailsTableAdapter())
                adapter.Fill(data.SV_VR_WaybillReport_Details, this.UserID, vendorID, periodFrom);

            WaybillReportBarcodePrepare(data.SV_VR_WaybillReport_Header);

            return data;
        }

        private void WaybillReportBarcodePrepare(Data.Complaints.SV_VR_WaybillReport_HeaderDataTable header)
        {
            if (header.Count > 0)
            {
                // создание штрих-кода
                BarCodeCtrl barCodeCtrl = new BarCodeCtrl();
                barCodeCtrl.Weight = BarCodeCtrl.BarCodeWeight.Large;
                barCodeCtrl.Size = new Size(1000, 200); // 720
                barCodeCtrl.BarCodeHeight = 140;
                barCodeCtrl.FooterFont = new Font(barCodeCtrl.FooterFont.FontFamily, 24, FontStyle.Bold);
                barCodeCtrl.HeaderText = "";
                barCodeCtrl.LeftMargin = 10;
                barCodeCtrl.ShowFooter = true;
                barCodeCtrl.TopMargin = 20;
                barCodeCtrl.BarCode = header[0].barcode;
                byte[] barCode = null;
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    barCodeCtrl.GetImage().Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    barCode = ms.ToArray();
                }
                header[0].barcode_binary = barCode;
            }
        }

        private void btnPrintDocsPackage_Click(object sender, EventArgs e)
        {
            this.PrintDocsPackage();
        }

        private void PrintDocsPackage()
        {
            try
            {
                if (!btnPrintDocsPackage.Enabled)
                    return;

                var vendor = (Data.Complaints.SV_VR_Docs_VendorsRow)(xdgvVendorReturnsGroups.SelectedItems[0]);
                var vendorName = vendor.Vendor_Name;
                var needPrintTTN = vendor.IsSV_Doc_PrintedNull() ? true : !vendor.SV_Doc_Printed;

                var docs = new Data.Complaints.SV_VR_Docs_By_VendorDataTable();
                docs.Merge(complaints.SV_VR_Docs_By_Vendor);

                using (var form = new ShipReturnsToVendorDocsSelectorForm(docs, vendorName, needPrintTTN) { UserID = this.UserID })
                    if (form.ShowDialog(this) == DialogResult.OK)
                    {
                        var docsToPrint = form.SelectedDocs;
                        this.PrintDocs(docsToPrint);
                    }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void PrintDocs(List<Data.Complaints.SV_VR_Docs_By_VendorRow> docs)
        {
            try
            {
                var printerName = cmbPrinters.Text;
                var splashFormPrint = new Dialogs.SplashForm();

                var printWorker = new BackgroundWorker();
                printWorker.DoWork += (s, e) => 
                {
                    try
                    {
                        foreach (var doc in docs)
                            this.PrintDoc(doc, printerName);
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                printWorker.RunWorkerCompleted += (s, e) =>
                {
                    splashFormPrint.CloseForce();

                    if (e.Result is Exception)
                        this.ShowError(e.Result as Exception);
                    else
                        this.RefreshVendorReturnsGroups();
                };

                splashFormPrint.ActionText = "Выполняется печать пакета документов..";
                printWorker.RunWorkerAsync();

                splashFormPrint.ShowDialog();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void PrintDoc(Data.Complaints.SV_VR_Docs_By_VendorRow doc, string printerName)
        {
            try
            {
                Data.Complaints ds = null;
                var needPrintWatermark = false;

                // Печать возвратной накладной
                ds = PrepareDataForInvoicesPrint(doc);

                needPrintWatermark = PrintDocsThread.CheckNeedPrintWatermark(this.UserID, "SV", 25, Convert.ToInt64(doc.Doc_ID), (string)null);

                using (var report = new ComplaintVendorReturnInvoiceReport())
                {
                    report.SetDataSource(ds);
                    report.SetParameterValue("NeedPrintWatermark", needPrintWatermark);
                    report.PrintOptions.PrinterName = printerName;
                    report.PrintToPrinter(4, true, 1, 0);

                    // логирование факта печати
                    PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "SV", 25, Convert.ToInt64(doc.Doc_ID), (string)null, Convert.ToInt16(ds.VR_GetNakl_Detail.Count), printerName, 4);
                }

                // Печать гарантийного письма
                ds = PrepareDataForWarrantyLetterPrint(doc);

                needPrintWatermark = PrintDocsThread.CheckNeedPrintWatermark(this.UserID, "SV", 26, Convert.ToInt64(doc.Doc_ID), (string)null);

                using (var report = new ComplaintVendorReturnWarrantyLetterReport())
                {
                    report.SetDataSource(ds);
                    report.SetParameterValue("NeedPrintWatermark", needPrintWatermark);
                    report.PrintOptions.PrinterName = printerName;
                    report.PrintToPrinter(1, true, 1, 0);

                    // логирование факта печати
                    PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "SV", 26, Convert.ToInt64(doc.Doc_ID), (string)null, Convert.ToInt16(ds.VR_WarrantyLetter.Count), printerName, 1);
                }

                // Фиксация печати
                using (var adapter = new Data.ComplaintsTableAdapters.SV_VR_Docs_By_VendorTableAdapter())
                    adapter.SetDocPrintDate(this.UserID, (int?)null, doc.Doc_ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Подготовка данных для печати накладной
        /// </summary>
        /// <param name="pDoc">Документ, по которому получаем данные</param>
        /// <returns>DataSet з заполненными таблицами для печати накладной</returns>
        private Data.Complaints PrepareDataForInvoicesPrint(Data.Complaints.SV_VR_Docs_By_VendorRow pDoc)
        {
            try
            {
                var ds = new Data.Complaints();
                using (var adapter = new Data.ComplaintsTableAdapters.VR_GetNakl_HeaderTableAdapter())
                {
                    adapter.SetTimeout((int)TimeSpan.FromMinutes(3).TotalSeconds);
                    adapter.Fill(ds.VR_GetNakl_Header, UserID, (int)pDoc.Doc_ID);
                }

                using (var adapter = new Data.ComplaintsTableAdapters.VR_GetNakl_DetailTableAdapter())
                {
                    adapter.SetTimeout((int)TimeSpan.FromMinutes(3).TotalSeconds);
                    adapter.Fill(ds.VR_GetNakl_Detail, UserID, (int)pDoc.Doc_ID);
                }

                using (var adapter = new Data.ComplaintsTableAdapters.CompanyConstantsTableAdapter())
                    adapter.Fill(ds.CompanyConstants, "UA", pDoc.IsDoc_DateNull() ? DateTime.Today : pDoc.Doc_Date);

                return ds;
            }
            catch (Exception exc)
            {
                ShowError("Не удалось получить данные для электронной возвратной накладной: " + Environment.NewLine + exc.Message);
                return null;
            }
        }


        /// <summary>
        /// Подготовка данных для печати гарантийного письма
        /// </summary>
        /// <param name="pDoc">Документ, по которому получаем данные</param>
        /// <returns>DataSet з заполненными таблицами для печати накладной</returns>
        private Data.Complaints PrepareDataForWarrantyLetterPrint(Data.Complaints.SV_VR_Docs_By_VendorRow pDoc)
        {
            try
            {
                var ds = new Data.Complaints();
                using (var adapter = new Data.ComplaintsTableAdapters.VR_WarrantyLetterTableAdapter())
                {
                    adapter.SetTimeout((int)TimeSpan.FromMinutes(3).TotalSeconds);
                    adapter.Fill(ds.VR_WarrantyLetter, pDoc.Doc_ID);
                }

                using (var adapter = new Data.ComplaintsTableAdapters.CompanyConstantsTableAdapter())
                    adapter.Fill(ds.CompanyConstants, "UA", pDoc.IsDoc_DateNull() ? DateTime.Today : pDoc.Doc_Date);

                return ds;
            }
            catch (Exception exc)
            {
                ShowError("Не удалось получить данные для гарантийного письма: " + Environment.NewLine + exc.Message);
                return null;
            }
        }

        private void btnShipVendorReturn_Click(object sender, EventArgs e)
        {
            this.ShipVendorReturn();
        }

        private void ShipVendorReturn()
        {
            try
            {
                if (!btnShipVendorReturn.Enabled)
                    return;

                var tranOptions = new TransactionOptions();
                tranOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;

                using (var scope = new TransactionScope(TransactionScopeOption.Required, tranOptions))
                {
                    try
                    {
                        foreach (DataGridViewRow row in dgvVendorReturns.Rows)
                        {
                            var doc = (row.DataBoundItem as DataRowView).Row as Data.Complaints.SV_VR_Docs_By_VendorRow;
                            var docID = doc.Doc_ID;
                            var statusID = "160"; // Возврат отгружен поставщику

                            using (var adapter = new Data.ComplaintsTableAdapters.VR_DocsTableAdapter())
                                adapter.ChangeStatus(this.UserID, docID, statusID, null, null, null, null);
                        }

                        scope.Complete();
                    }
                    catch (Exception ex)
                    {
                        this.ShowError(ex);
                    }
                }

                this.RefreshVendorReturnsGroups();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }
    }

    /// <summary>
    /// Представление для списка отгрузок возвратов поставщику
    /// </summary>
    public class ShipReturnsToVendorView : IDataView
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
            var searchCriteria = searchParameters as ShipReturnsToVendorSearchParameters;

            var sessionID = searchCriteria.SessionID;
            var dateFrom = searchCriteria.DateFrom;
            var vendorID = searchCriteria.VendorID;
            var jdeDocNumber = searchCriteria.JDE_DocNumber;

            using (var adapter = new Data.ComplaintsTableAdapters.SV_VR_Docs_VendorsTableAdapter())
            {
                adapter.SetTimeout(DEFAULT_RESPONSE_TIMEOUT);
                data = adapter.GetData(sessionID, dateFrom, vendorID, jdeDocNumber);
            }
        }

        #endregion

        public ShipReturnsToVendorView()
        {
            this.dataColumns.Add(new PatternColumn("Код", "Vendor_ID", new FilterCompareExpressionRule<Int32>("Vendor_ID"), SummaryCalculationType.Count) { Width = 60 });
            this.dataColumns.Add(new PatternColumn("Наименование поставщика", "Vendor_Name", new FilterPatternExpressionRule("Vendor_Name")) { Width = 400 });
            this.dataColumns.Add(new PatternColumn("Возвратов", "Doc_Count", new FilterCompareExpressionRule<Int32>("Doc_Count"), SummaryCalculationType.Sum) { Width = 70 });
            this.dataColumns.Add(new PatternColumn("Время поставки", "RM_Date", new FilterDateCompareExpressionRule("RM_Date")) { Width = 120 });
            this.dataColumns.Add(new PatternColumn("Статус поставки", "RM_Status", new FilterPatternExpressionRule("RM_Status"), SummaryCalculationType.Count) { Width = 120 });
            this.dataColumns.Add(new PatternColumn("№ ТТН", "SV_Doc_ID", new FilterCompareExpressionRule<Int32>("SV_Doc_ID"), SummaryCalculationType.Count) { Width = 70 });
        }
    }

    /// <summary>
    /// Критерий поиска
    /// </summary>
    public class ShipReturnsToVendorSearchParameters : SessionIDSearchParameters
    {
        public DateTime? DateFrom { get; set; }
        public int? VendorID { get; set; }
        public string JDE_DocNumber = (string)null;
    }
}
