using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Dialogs.Quality;
using WMSOffice.Controls;
using System.IO;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.Diagnostics;

namespace WMSOffice.Window
{
    public partial class ImportLicenseRequestsWindow : GeneralWindow
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        /// <summary>
        /// Пустое изображение
        /// </summary>
        private static Bitmap emptyIcon = new Bitmap(16, 16);

        private Data.Quality.QK_LI_LicRequestsRow SelectedRequest { get { return xdgvRequests.SelectedItem as Data.Quality.QK_LI_LicRequestsRow; } }

        private Data.Quality.QK_LI_LicRequest_DetailsRow SelectedRequestItem { get { return dgvRequestDetails.SelectedRows.Count > 0 ? (dgvRequestDetails.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.Quality.QK_LI_LicRequest_DetailsRow : null; } }

        private int? selectedRequestID = (int?)null;

        public ImportLicenseRequestsWindow()
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

            stbVendor.ValueReferenceQuery = "[dbo].[pr_QK_LI_Get_Vendors_List]";
            stbVendor.UserID = this.UserID;
            stbVendor.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stbVendor_OnVerifyValue);

            stbItem.ValueReferenceQuery = "[dbo].[pr_QK_LI_Get_Items_List]";
            stbItem.ApplyAdditionalParameter("Show_Additional_Items", true);
            stbItem.UserID = this.UserID;
            stbItem.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stbVendor_OnVerifyValue);

            stbStatusFrom.ValueReferenceQuery = "[dbo].[pr_QK_LI_Get_Statuses_List]";
            stbStatusFrom.UserID = this.UserID;
            stbStatusFrom.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stbVendor_OnVerifyValue);
            stbStatusFrom.SetValueByDefault("100");

            stbStatusTo.ValueReferenceQuery = "[dbo].[pr_QK_LI_Get_Statuses_List]";
            stbStatusTo.UserID = this.UserID;
            stbStatusTo.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stbVendor_OnVerifyValue);
            stbStatusTo.SetValueByDefault("300");

            var today = DateTime.Today.Date;
            dtpPeriodFrom.Value = today.AddDays(-14);
            dtpPeriodTo.Value = today.AddDays(0);

            xdgvRequests.AllowSummary = false;
            xdgvRequests.AllowRangeColumns = true;

            xdgvRequests.UseMultiSelectMode = false;

            xdgvRequests.Init(new ImportLicenseRequestsView(), true);
            xdgvRequests.LoadExtraDataGridViewSettings(this.Name);

            xdgvRequests.UserID = this.UserID;

            xdgvRequests.OnDataError += new DataGridViewDataErrorEventHandler(xdgvRequests_OnDataError);
            xdgvRequests.OnRowSelectionChanged += new EventHandler(xdgvRequests_OnRowSelectionChanged);
            xdgvRequests.OnRowDoubleClick += new DataGridViewCellEventHandler(xdgvRequests_OnRowDoubleClick);
            xdgvRequests.OnFilterChanged += new EventHandler(xdgvRequests_OnFilterChanged);
            xdgvRequests.OnDataBindingComplete += new DataGridViewBindingCompleteEventHandler(xdgvRequests_OnDataBindingComplete);
            xdgvRequests.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvRequests_OnFormattingCell);

            // активация постраничного просмотра
            xdgvRequests.CreatePageNavigator();

            SetOperationAccess();
            SetDetailsOperationAccess();

            this.LoadRequests();
        }

        void stbVendor_OnVerifyValue(object sender, WMSOffice.Controls.VerifyValueArgs e)
        {
            var control = sender as SearchTextBox;
            TextBox lblDescription = null;

            if (control == stbVendor)
                lblDescription = tbVendor;
            else if (control == stbItem)
                lblDescription = tbItem;
            else if (control == stbStatusFrom)
                lblDescription = tbStatusFrom;
            else if (control == stbStatusTo)
                lblDescription = tbStatusTo;

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

        void xdgvRequests_OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        void xdgvRequests_OnRowSelectionChanged(object sender, EventArgs e)
        {
            SetOperationAccess();
            LoadDetails();
        }

        void xdgvRequests_OnRowDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditRequest();
        }

        void xdgvRequests_OnFilterChanged(object sender, EventArgs e)
        {
            SetOperationAccess();
            xdgvRequests.RecalculateSummary();
        }

        void xdgvRequests_OnDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Восстанавливаем фокус
            if (selectedRequestID.HasValue)
            {
                xdgvRequests.SelectRow("RequestID", selectedRequestID.ToString());
                xdgvRequests.ScrollToSelectedRow();
            }
        }

        void xdgvRequests_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var request = (xdgvRequests.DataGrid.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Quality.QK_LI_LicRequestsRow;
            var statusID = request.StatusID;
            switch (statusID)
            { 
                case 300:
                    e.CellStyle.BackColor = e.CellStyle.SelectionForeColor = Color.LightGreen;
                    break;
                case 400:
                    e.CellStyle.BackColor = e.CellStyle.SelectionForeColor = Color.LightPink;
                    break;
                default:
                    break;
            }
        }

        private void SetOperationAccess()
        {
            try
            {
                btnEditRequest.Enabled =
                btnSetConclusion.Enabled =
                btnExportRequestStatement.Enabled = false;

                var hasDecision = this.SelectedRequest != null && (this.SelectedRequest.StatusID == 300 || this.SelectedRequest.StatusID == 400);
                var canEditRequest = this.SelectedRequest != null && this.SelectedRequest.StatusID == 100;

                btnEditRequest.Enabled = canEditRequest;
                btnExportRequestStatement.Enabled = this.SelectedRequest != null;
                btnSetConclusion.Enabled = this.SelectedRequest != null && !hasDecision;
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
                this.LoadRequests();
                return true;
            }

            if (keyData == (Keys.F3))
            {
                this.EditRequest();
                return true;
            }

            if (keyData == (Keys.Control | Keys.N))
            {
                this.CreateRequest();
                return true;
            }

            if (keyData == (Keys.Delete))
            {
                this.DeleteItem();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.LoadRequests();
        }

        private void LoadRequests()
        {
            try
            {
                var searchParams = new ImportLicenseRequestsSearchParameters() { SessionID = this.UserID };


                if (!string.IsNullOrEmpty(stbVendor.Value))
                {
                    int vendorID;
                    if (!int.TryParse(stbVendor.Value, out vendorID))
                        throw new Exception("Код поставщика должен быть числом.");
                    else
                        searchParams.VendorID = vendorID;
                }


                if (!string.IsNullOrEmpty(stbItem.Value))
                {
                    int itemID;
                    if (!int.TryParse(stbItem.Value, out itemID))
                        throw new Exception("Код товара должен быть числом.");
                    else
                        searchParams.ItemID = itemID;
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


                if (dtpPeriodFrom.Value.Date > dtpPeriodTo.Value.Date)
                    throw new Exception("Начальный период не должен превышать конечный.");
                else
                {
                    searchParams.PeriodFrom = dtpPeriodFrom.Value.Date;
                    searchParams.PeriodTo = dtpPeriodTo.Value.Date;
                }

                // Запоминаем фокус
                selectedRequestID = this.SelectedRequest == null ? 0 : SelectedRequest.RequestID;

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    try
                    {
                        this.xdgvRequests.DataView.FillData(e.Argument as ImportLicenseRequestsSearchParameters);
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
                        this.xdgvRequests.BindData(false);

                        //this.xdgvDocs.AllowFilter = true;
                        this.xdgvRequests.AllowSummary = true;
                    }

                    splashForm.CloseForce();
                };

                splashForm.ActionText = "Выполняется получение списка уведомлений для лицензий на импорт..";
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
                if (SelectedRequest == null)
                {
                    quality.QK_LI_LicRequest_Details.Clear();
                    return;
                }

                this.LoadRequestDetails(quality.QK_LI_LicRequest_Details, SelectedRequest.RequestID, false);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
            finally
            {
                if (dgvRequestDetails.Rows.Count > 0)
                    dgvRequestDetails.Rows[0].Selected = false;
            }
        }

        private void LoadRequestDetails(Data.Quality.QK_LI_LicRequest_DetailsDataTable details, int requestID, bool exportMode)
        {
            using (var adapter = new Data.QualityTableAdapters.QK_LI_LicRequest_DetailsTableAdapter())
                adapter.Fill(details, this.UserID, requestID, exportMode);
        }

        private void btnCreateRequest_Click(object sender, EventArgs e)
        {
            this.CreateRequest();
        }

        private void CreateRequest()
        {
            try
            {
                this.ModifyRequest(null);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnEditRequest_Click(object sender, EventArgs e)
        {
            this.EditRequest();
        }

        private void EditRequest()
        {
            try
            {
                if (!btnEditRequest.Enabled)
                    return;

                this.ModifyRequest(this.SelectedRequest);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void ModifyRequest(Data.Quality.QK_LI_LicRequestsRow request)
        {
            var dlgImportLicenseRequestEdit = new ImportLicenseRequestEditForm(request) { UserID = this.UserID };
            if (dlgImportLicenseRequestEdit.ShowDialog() == DialogResult.OK)
            {
                this.LoadRequests();
            }
        }

        private void btnExportRequestStatement_Click(object sender, EventArgs e)
        {
            this.ExportRequestStatement();
        }

        private void ExportRequestStatement()
        {
            try
            {
                if (!btnExportRequestStatement.Enabled)
                    return;

                var dlgSelectFolder = new FolderBrowserDialog();
                dlgSelectFolder.RootFolder = Environment.SpecialFolder.MyComputer;
                dlgSelectFolder.Description = string.Format("Экспорт уведомления на обновление лицензии на импорт.\nВНИМАНИЕ!!! После завершения экспорта\nУВЕДОМЛЕНИЕ СТАНЕТ НЕДОСТУПНЫМ ДЛЯ ИЗМЕНЕНИЯ!!!");
                dlgSelectFolder.ShowNewFolderButton = false;
                if (dlgSelectFolder.ShowDialog() != DialogResult.OK)
                    return;

                var requestID = this.SelectedRequest.RequestID;
                var requestDate = this.SelectedRequest.RequestDate;

                var folderName = dlgSelectFolder.SelectedPath;
                var rootDir = Path.Combine(folderName, string.Format("Уведомление № {0} от {1} на обновление лицензии на импорт", requestID, requestDate.ToString("dd.MM.yyyy")));

                if (!Directory.Exists(rootDir))
                    Directory.CreateDirectory(rootDir);
                else
                {
                    foreach (var fileName in Directory.GetFiles(folderName))
                    {
                        try
                        {
                            File.Delete(fileName);
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }

                var splashForm = new WMSOffice.Dialogs.SplashForm();
                var exportWorker = new BackgroundWorker();
                exportWorker.DoWork += (s, e) =>
                {
                    try
                    {
                        // 0.
                        var reportData = this.GetStatementReportData(requestID);

                        // 1.
                        this.ExportStatementReport(requestID, reportData, rootDir);

                        // 2.
                        this.ExportStatementRegistryItemsReport(requestID, reportData, rootDir);

                        // 3.
                        this.CompleteExport(requestID);
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                exportWorker.RunWorkerCompleted += (s, e) =>
                {
                    splashForm.CloseForce();

                    if (e.Result is Exception)
                        this.ShowError(e.Result as Exception);
                    else
                        Process.Start(rootDir);
                };
                splashForm.ActionText = "Выполняется экспорт уведомления..";
                exportWorker.RunWorkerAsync();
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
            finally
            {
                this.LoadRequests();
            }
        }

        private Data.Quality GetStatementReportData(int requestID)
        {
            var data = new Data.Quality();

            using (var adapter = new Data.QualityTableAdapters.QK_LI_Request_ReasonsTableAdapter())
                adapter.Fill(data.QK_LI_Request_Reasons, this.UserID, requestID);

            using (var adapter = new Data.QualityTableAdapters.QK_LI_Request_ProdTypesTableAdapter())
                adapter.Fill(data.QK_LI_Request_ProdTypes, this.UserID, requestID);

            using (var adapter = new Data.QualityTableAdapters.QK_LI_Request_ReceiveAdditionsTableAdapter())
                adapter.Fill(data.QK_LI_Request_ReceiveAdditions, this.UserID, requestID);

            using (var adapter = new Data.QualityTableAdapters.QK_LI_Request_ReceiveDecisionsTableAdapter())
                adapter.Fill(data.QK_LI_Request_ReceiveDecisions, this.UserID, requestID);

            using (var adapter = new Data.QualityTableAdapters.QK_LI_Request_ResponsiblePersonsTableAdapter())
                adapter.Fill(data.QK_LI_Request_ResponsiblePersons, this.UserID, requestID);

            this.LoadRequestDetails(data.QK_LI_LicRequest_Details, requestID, true);

            return data;
        }

        private void ExportStatementReport(int requestID, WMSOffice.Data.Quality reportData, string rootDir)
        {
            //using (var report = new Reports.QualityImportLicenseStatementReport())
            //{
            //    using (var reportForm = new WMSOffice.Dialogs.ReportForm())
            //    {

            //        report.SetDataSource(reportData);
            //        reportForm.ReportDocument = report;
            //        reportForm.ShowDialog();
            //    }
            //}

            var reportPdfPath = Path.Combine(rootDir, string.Format("Уведомление № {0} на обновление лицензии на импорт.PDF", requestID));
            var reportXlsPath = Path.Combine(rootDir, string.Format("Уведомление № {0} на обновление лицензии на импорт.XLS", requestID));
            //var reportDocPath = Path.Combine(rootDir, string.Format("Уведомление № {0} на обновление лицензии на импорт.DOC", requestID));
            using (var report = new Reports.QualityImportLicenseStatementReport())
            {
                report.SetDataSource(reportData);
                report.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, reportPdfPath);
                report.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Excel, reportXlsPath);
                //report.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.WordForWindows, reportDocPath);
            }
        }

        private void ExportStatementRegistryItemsReport(int requestID, WMSOffice.Data.Quality reportData, string rootDir)
        {
            MemoryStream stream = new MemoryStream(Properties.Resources.QK_LI_ImportLicenseStatementItems);

            XSSFWorkbook templateWorkbook = new XSSFWorkbook(stream);
            var sheet = templateWorkbook.GetSheet("Лист1");

            ICell cell = null;

            int rowNum = 9; // первая строка данных реестра

            foreach (Data.Quality.QK_LI_LicRequest_DetailsRow item in reportData.QK_LI_LicRequest_Details)
            {
                try
                {
                    IRow row = sheet.CreateRow(rowNum);

                    row.CreateCell(0).SetCellValue(rowNum - 8);
                    row.CreateCell(1).SetCellValue(item.ItemName);
                    row.CreateCell(2).SetCellValue(item.ReleaseForm);
                    row.CreateCell(3).SetCellValue(item.Dosage);
                    row.CreateCell(4).SetCellValue(item.QtyPack);
                    row.CreateCell(5).SetCellValue(item.MNN);
                    row.CreateCell(6).SetCellValue(item.NoReg);
                    row.CreateCell(7).SetCellValue(item.AtcCode);
                    row.CreateCell(8).SetCellValue(item.Manufacturer);
                    row.CreateCell(9).SetCellValue(item.ManufacturerCountry);
                    row.CreateCell(10).SetCellValue(item.Vendor);
                    row.CreateCell(11).SetCellValue(item.VendorCountry);
                    row.CreateCell(12).SetCellValue(item.VendorAddress);
                    row.CreateCell(13).SetCellValue(item.QK_LI_Note);

                    rowNum++;
                }
                catch (Exception ex)
                {

                }
            }

            var itemsPath = Path.Combine(rootDir, string.Format("Реестр товаров по уведомлению № {0} на обновление лицензии на импорт.XLSX", requestID));

            FileStream file = new FileStream(itemsPath, FileMode.Create);
            templateWorkbook.Write(file);

            file.Close();
            file.Dispose();

            stream.Close();
            stream.Dispose();
        }

        private void CompleteExport(int requestID)
        {
            using (var adapter = new Data.QualityTableAdapters.QK_LI_LicRequestsTableAdapter())
                adapter.CompleteExport(this.UserID, requestID);

            //btnExportRequestStatement.Enabled = false;
        }

        private void btnSetConclusion_Click(object sender, EventArgs e)
        {
            this.SetConclusion();
        }

        private void SetConclusion()
        {
            try
            {
                if (!btnSetConclusion.Enabled)
                    return;

                var request = this.SelectedRequest;

                var dlgImportLicenseSetConclusion = new ImportLicenseSetConclusionForm(request) { UserID = this.UserID };
                if (dlgImportLicenseSetConclusion.ShowDialog() == DialogResult.OK)
                {
                    this.LoadRequests();
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void dgvRequestDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvRequestDetails.Rows)
            {
                var dataRow = (row.DataBoundItem as DataRowView).Row as Data.Quality.QK_LI_LicRequest_DetailsRow;

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

        private void dgvRequestDetails_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                var dataRow = ((sender as DataGridView).Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Quality.QK_LI_LicRequest_DetailsRow;
                var operationType = dataRow.IsOperationTypeNull() ? (bool?)null : dataRow.OperationType;
                var itemExists = dataRow.ItemID > 0;

                e.CellStyle.BackColor = operationType.HasValue ? (operationType.Value ? Color.LightBlue : Color.LightPink) : e.CellStyle.BackColor;
                e.CellStyle.SelectionForeColor = operationType.HasValue ? (operationType.Value ? Color.LightBlue : Color.LightPink) : e.CellStyle.SelectionForeColor;

                //e.CellStyle.BackColor = itemExists ? (operationType.HasValue ? (operationType.Value ? Color.LightBlue : Color.LightPink) : e.CellStyle.BackColor) : Color.LightGray;
                //e.CellStyle.SelectionForeColor = itemExists ? (operationType.HasValue ? (operationType.Value ? Color.LightBlue : Color.LightPink) : e.CellStyle.SelectionForeColor) : Color.LightGray;

                if (!itemExists)
                    e.CellStyle.ForeColor = Color.Brown;

                if (!itemExists && dgvRequestDetails.Columns[e.ColumnIndex].DataPropertyName == quality.QK_LI_LicRequest_Details.ItemIDColumn.Caption)
                    e.Value = string.Empty;
            }
            catch (Exception ex)
            {

            }
        }

        private void dgvRequestDetails_SelectionChanged(object sender, EventArgs e)
        {
            this.SetDetailsOperationAccess();
        }

        private void SetDetailsOperationAccess()
        {
            var isEnabled = dgvRequestDetails.SelectedRows.Count > 0 && this.SelectedRequest != null;

            miCreateItemCopy.Enabled = isEnabled && this.SelectedRequest.StatusID == 100;
            miDeleteItem.Enabled = isEnabled && this.SelectedRequest.StatusID == 100; // && this.SelectedRequestItem.ItemID <= 0;
        }

        private void miCreateItemCopy_Click(object sender, EventArgs e)
        {
            this.CreateItemCopy();
        }

        private void CreateItemCopy()
        {
            try
            {
                if (!miCreateItemCopy.Enabled)
                    return;

                var requestID = this.SelectedRequest.RequestID;
                var item = this.SelectedRequestItem;

                var dlgImportLicenseRequestCreateItem = new ImportLicenseRequestCreateItemForm(requestID, item) { UserID = this.UserID };
                if (dlgImportLicenseRequestCreateItem.ShowDialog() == DialogResult.OK)
                {
                    this.LoadDetails();
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void miDeleteItem_Click(object sender, EventArgs e)
        {
            this.DeleteItem();
        }

        private void DeleteItem()
        {
            try
            {
                if (!miDeleteItem.Enabled)
                    return;

                if (MessageBox.Show("Вы действительно хотите удалить товар из уведомления?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                    return;

                var requestID = this.SelectedRequest.RequestID;
                var item = this.SelectedRequestItem;

                using (var adapter = new Data.QualityTableAdapters.QK_LI_LicRequestsTableAdapter())
                    adapter.DeleteItem(this.UserID, requestID, item.ItemID);

                this.LoadDetails();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void dgvRequestDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            this.CreateItemCopy();
        }
    }

    /// <summary>
    /// Представление для уведомлений на обновление лицензий на импорт
    /// </summary>
    public class ImportLicenseRequestsView : IDataView
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
            var searchCriteria = searchParameters as ImportLicenseRequestsSearchParameters;

            var sessionID = searchCriteria.SessionID;
            var vendorID = searchCriteria.VendorID;
            var itemID = searchCriteria.ItemID;
            var statusFrom = searchCriteria.StatusFrom;
            var statusTo = searchCriteria.StatusTo;
            var periodFrom = searchCriteria.PeriodFrom;
            var periodTo = searchCriteria.PeriodTo;

            using (var adapter = new Data.QualityTableAdapters.QK_LI_LicRequestsTableAdapter())
            {
                adapter.SetTimeout(DEFAULT_RESPONSE_TIMEOUT);
                data = adapter.GetData(sessionID, vendorID, itemID, statusFrom, statusTo, periodFrom, periodTo);
            }
        }

        #endregion

        public ImportLicenseRequestsView()
        {
            this.dataColumns.Add(new PatternColumn("№ уведомления", "RequestID", new FilterCompareExpressionRule<int>("RequestID"), SummaryCalculationType.Count) { Width = 130 });
            this.dataColumns.Add(new PatternColumn("Дата создания уведомления", "RequestDate", new FilterDateCompareExpressionRule("RequestDate"), SummaryCalculationType.Count) { Width = 130 });
            this.dataColumns.Add(new PatternColumn("Дата согласования уведомления", "ConclusionDate", new FilterDateCompareExpressionRule("ConclusionDate"), SummaryCalculationType.Count) { Width = 130 });
            this.dataColumns.Add(new PatternColumn("№ задания в Directum", "DirectumTaskID", new FilterCompareExpressionRule<long>("DirectumTaskID"), SummaryCalculationType.Count) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Статус уведомления", "StatusName", new FilterPatternExpressionRule("StatusName")) { Width = 150 });
            this.dataColumns.Add(new PatternColumn("Причина", "ReasonName", new FilterPatternExpressionRule("ReasonName")) { Width = 150 });
            this.dataColumns.Add(new PatternColumn("Тип продукции", "ProdTypeName", new FilterPatternExpressionRule("ProdTypeName")) { Width = 250 });
            //this.dataColumns.Add(new PatternColumn("Получение дополнения", "ReceiveAdditionName", new FilterPatternExpressionRule("ReceiveAdditionName")) { Width = 150 });
            //this.dataColumns.Add(new PatternColumn("Получение решения", "ReceiveDecisionName", new FilterPatternExpressionRule("ReceiveDecisionName")) { Width = 150 });
            this.dataColumns.Add(new PatternColumn("Решение", "Decision", new FilterPatternExpressionRule("Decision")) { Width = 80 });
            this.dataColumns.Add(new PatternColumn("Примечание", "Note", new FilterPatternExpressionRule("Note")) { Width = 250 });
        }
    }

    /// <summary>
    /// Критерий поиска
    /// </summary>
    public class ImportLicenseRequestsSearchParameters : SessionIDSearchParameters
    {
        public int? VendorID { get; set; }
        public int? ItemID { get; set; }
        public int? StatusFrom { get; set; }
        public int? StatusTo { get; set; }
        public DateTime? PeriodFrom { get; set; }
        public DateTime? PeriodTo { get; set; }
    }
}
