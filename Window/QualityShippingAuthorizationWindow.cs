using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Classes;
using WMSOffice.Dialogs.Quality;
using WMSOffice.Dialogs;
using WMSOffice.Classes.ReportProviders;
using WMSOffice.Reports;

namespace WMSOffice.Window
{
    public partial class QualityShippingAuthorizationWindow : GeneralWindow
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        private Data.Quality.QK_SA_WorksheetsRow SelectedWorksheet { get { return xdgvWorksheets.SelectedItem as Data.Quality.QK_SA_WorksheetsRow; } }

        private long? selectedWorksheetNumber = (int?)null;

        public QualityShippingAuthorizationWindow()
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
            //#region ИНИЦИАЛИЗАЦИЯ ПРИНТЕРОВ

            //PrintDocsThread.FillPrintersComboBox(cmbPrinters.ComboBox);

            //#endregion

            QualityShippingAuthorizationWorksheetSearchForm.SearchParameter.SessionID = this.UserID;

            // статусы анкет
            chbStatusNew.Checked = QualityShippingAuthorizationWorksheetSearchForm.SearchParameter.StatusNew;
            chbStatusInWork.Checked = QualityShippingAuthorizationWorksheetSearchForm.SearchParameter.StatusInWork;
            chbStatusAccepted.Checked = QualityShippingAuthorizationWorksheetSearchForm.SearchParameter.StatusAccepted;
            chbStatusNotAccepted.Checked = QualityShippingAuthorizationWorksheetSearchForm.SearchParameter.StatusNotAccepted;

            xdgvWorksheets.AllowSummary = false;
            xdgvWorksheets.UseMultiSelectMode = false;

            xdgvWorksheets.Init(new QualityShippingAuthorizationView(), true);

            xdgvWorksheets.UserID = this.UserID;

            xdgvWorksheets.OnDataError += new DataGridViewDataErrorEventHandler(xdgvWorksheets_OnDataError);
            xdgvWorksheets.OnRowSelectionChanged += new EventHandler(xdgvWorksheets_OnRowSelectionChanged);
            xdgvWorksheets.OnRowDoubleClick += new DataGridViewCellEventHandler(xdgvWorksheets_OnRowDoubleClick);
            xdgvWorksheets.OnFilterChanged += new EventHandler(xdgvWorksheets_OnFilterChanged);
            xdgvWorksheets.OnDataBindingComplete += new DataGridViewBindingCompleteEventHandler(xdgvWorksheets_OnDataBindingComplete);

            // активация постраничного просмотра
            xdgvWorksheets.CreatePageNavigator();

            SetOperationAccess();

            LoadData();
        }

        void xdgvWorksheets_OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        void xdgvWorksheets_OnRowSelectionChanged(object sender, EventArgs e)
        {
            SetOperationAccess();
        }

        void xdgvWorksheets_OnRowDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OpenWorksheetEditor();
        }


        void xdgvWorksheets_OnFilterChanged(object sender, EventArgs e)
        {
            SetOperationAccess();
            xdgvWorksheets.RecalculateSummary();
        }

        void xdgvWorksheets_OnDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Восстанавливаем фокус
            if (selectedWorksheetNumber.HasValue)
            {
                xdgvWorksheets.SelectRow("worksheet_number", selectedWorksheetNumber.ToString());
                xdgvWorksheets.ScrollToSelectedRow();
            }
        }

        private void SetOperationAccess()
        {
            var isEnabled = xdgvWorksheets.SelectedItem != null;
            var hasRows = xdgvWorksheets.HasRows;

            btnEditWorksheet.Enabled = isEnabled;
            btnPrintWorksheet.Enabled = isEnabled;
            //btnPrintRegistry.Enabled = isEnabled;
            btnExportToExcel.Enabled = hasRows;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F5))
            {
                LoadData();
                return true;
            }

            if (keyData == (Keys.Control | Keys.F))
            {
                SearchData();
                return true;
            }

            if (keyData == (Keys.F2))
            {
                OpenWorksheetEditor();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            var qsap = new QualityShippingAuthorizationParameters
            {
                SessionID = QualityShippingAuthorizationWorksheetSearchForm.SearchParameter.SessionID,

                StatusNew = QualityShippingAuthorizationWorksheetSearchForm.SearchParameter.StatusNew,
                StatusInWork = QualityShippingAuthorizationWorksheetSearchForm.SearchParameter.StatusInWork,
                StatusAccepted = QualityShippingAuthorizationWorksheetSearchForm.SearchParameter.StatusAccepted,
                StatusNotAccepted = QualityShippingAuthorizationWorksheetSearchForm.SearchParameter.StatusNotAccepted
            };

            this.LoadData(qsap);
        }

        private void LoadData(QualityShippingAuthorizationParameters qsap)
        {
            try
            {
                // Запоминаем фокус
                selectedWorksheetNumber = this.SelectedWorksheet == null ? 0 : SelectedWorksheet.worksheet_number;

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    try
                    {
                        this.xdgvWorksheets.DataView.FillData(e.Argument as QualityShippingAuthorizationParameters);
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
                        this.xdgvWorksheets.BindData(false);

                        //this.xdgvWorksheets.AllowFilter = true;
                        this.xdgvWorksheets.AllowSummary = true;
                    }

                    splashForm.CloseForce();
                };

                splashForm.ActionText = "Выполняется получение списка анкет разрешений на отгрузку..";
                bw.RunWorkerAsync(qsap);
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchData();
        }

        private void SearchData()
        {
            var dlgSearchForm = new QualityShippingAuthorizationWorksheetSearchForm() { UserID = this.UserID };
            if (dlgSearchForm.ShowDialog() == DialogResult.OK)
            {
                chbStatusNew.Checked = QualityShippingAuthorizationWorksheetSearchForm.SearchParameter.StatusNew;
                chbStatusInWork.Checked = QualityShippingAuthorizationWorksheetSearchForm.SearchParameter.StatusInWork;
                chbStatusAccepted.Checked = QualityShippingAuthorizationWorksheetSearchForm.SearchParameter.StatusAccepted;
                chbStatusNotAccepted.Checked = QualityShippingAuthorizationWorksheetSearchForm.SearchParameter.StatusNotAccepted;

                this.LoadData(QualityShippingAuthorizationWorksheetSearchForm.SearchParameter);
            }
        }

        private void btnEditWorksheet_Click(object sender, EventArgs e)
        {
            OpenWorksheetEditor();
        }

        private void OpenWorksheetEditor()
        {
            try
            {
                if (!btnEditWorksheet.Enabled)
                    return;

                var isEditable = SelectedWorksheet.is_last_version && (SelectedWorksheet.status_id == Constants.QK_IC_STATUS_NEW || SelectedWorksheet.status_id == Constants.QK_IC_STATUS_IN_WORK);
                var isReadOnly = !isEditable;
                var editForm = new EditShippingAuthorizationWorksheetForm(UserID, SelectedWorksheet, isReadOnly);

                if (editForm.ShowDialog(this) == DialogResult.OK)
                {
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnPrintWorksheet_Click(object sender, EventArgs e)
        {
            this.PrintWorksheet();
        }

        private void PrintWorksheet()
        {
            try
            {
                if (!btnPrintWorksheet.Enabled)
                    return;

                using (var form = new ReportForm())
                {
                    var spReportProvider = new QualityInputControlReportProvider(UserID) { ControlType = InputControlTypes.ShippingAuthorizationControl };
                    form.ReportDocument = spReportProvider.GetReport(SelectedWorksheet);
                    form.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void btnPrintRegistry_Click(object sender, EventArgs e)
        {
            this.PrintRegistry();
        }

        private void PrintRegistry()
        {
            try
            {
                if (!btnPrintRegistry.Enabled)
                    return;

                var dlgSearchForm = new QualityShippingAuthorizationRegistrySearchForm() { UserID = this.UserID };
                if (dlgSearchForm.ShowDialog() == DialogResult.OK)
                {
                    using (var report = new QualityShippingAuthorizationControlRegistryReport())
                    {
                        var data = this.PrepareRegistryReportData(this.UserID, dlgSearchForm.RouteListNumber, dlgSearchForm.PeriodFrom, dlgSearchForm.PeriodTo, dlgSearchForm.ProvisorID, dlgSearchForm.BranchID);
                        report.SetDataSource(data);

                        using (var form = new ReportForm())
                        {
                            form.ReportDocument = report;
                            form.ShowDialog(this);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private Data.Quality PrepareRegistryReportData(int userID, long? routeListNumber, DateTime? periodFrom, DateTime? periodTo, long? provisorID, int? branchID)
        {
            var data = new Data.Quality();

            using (var adapter = new Data.QualityTableAdapters.QK_SA_Control_Registry_ReportTableAdapter())
                adapter.Fill(data.QK_SA_Control_Registry_Report, userID, routeListNumber, periodFrom, periodTo, provisorID, branchID); 

            return data;
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            this.ExportToExcel();
        }

        private void ExportToExcel()
        {
            try
            {
                xdgvWorksheets.ExportToExcel("Экспорт анкет", "список анкет", true);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void chbWorksheetStatuses_CheckedChanged(object sender, EventArgs e)
        {
            var chbStatusSelector = sender as CheckBox;

            if (chbStatusSelector.Equals(chbStatusNew))
                QualityShippingAuthorizationWorksheetSearchForm.SearchParameter.StatusNew = chbStatusNew.Checked;
            else if (chbStatusSelector.Equals(chbStatusInWork))
                QualityShippingAuthorizationWorksheetSearchForm.SearchParameter.StatusInWork = chbStatusInWork.Checked;
            else if (chbStatusSelector.Equals(chbStatusAccepted))
                QualityShippingAuthorizationWorksheetSearchForm.SearchParameter.StatusAccepted = chbStatusAccepted.Checked;
            else if (chbStatusSelector.Equals(chbStatusNotAccepted))
                QualityShippingAuthorizationWorksheetSearchForm.SearchParameter.StatusNotAccepted = chbStatusNotAccepted.Checked;
        }
    }

    /// <summary>
    /// Представление для анкет разрешений на отгрузку
    /// </summary>
    public class QualityShippingAuthorizationView : IDataView
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
            var searchCriteria = searchParameters as QualityShippingAuthorizationParameters;

            var sessionID = searchCriteria.SessionID;
            var routeListNumber = searchCriteria.RouteListNumber;
            var worksheetNumber = searchCriteria.WorksheetNumber;
            var carNumber = searchCriteria.CarNumber;
            var debtorID = searchCriteria.DebtorID;
            var driverName = searchCriteria.DriverName;
            var periodFrom = searchCriteria.PeriodFrom;
            var periodTo = searchCriteria.PeriodTo;
            var provisorID = searchCriteria.ProvisorID;
            var statusesList = searchCriteria.StatusesList;
            var hasDesinfectionCert = searchCriteria.HasDesinfectionCert;
            var isShippingToWarehouse = searchCriteria.IsShippingToWarehouse;

            using (var adapter = new Data.QualityTableAdapters.QK_SA_WorksheetsTableAdapter())
            {
                adapter.SetTimeout(DEFAULT_RESPONSE_TIMEOUT);
                data = adapter.GetData(sessionID, routeListNumber, worksheetNumber, carNumber, debtorID, driverName, periodFrom, periodTo, provisorID, statusesList, hasDesinfectionCert, isShippingToWarehouse);
            }
        }

        #endregion

        public QualityShippingAuthorizationView()
        {
            this.dataColumns.Add(new PatternColumn("Номер МЛ", "route_list_number", new FilterCompareExpressionRule<Int64>("route_list_number"), SummaryCalculationType.Count) { Width = 120 });
            this.dataColumns.Add(new PatternColumn("Номер авто", "car_number", new FilterPatternExpressionRule("car_number")) { Width = 150 });
            this.dataColumns.Add(new PatternColumn("Номер полуприцепа", "trailer", new FilterPatternExpressionRule("trailer")) { Width = 150 });
            this.dataColumns.Add(new PatternColumn("ФИО водителя", "driver_name", new FilterPatternExpressionRule("driver_name")) { Width = 200 });
            this.dataColumns.Add(new PatternColumn("Вид отгрузки", "type_shipments", new FilterPatternExpressionRule("type_shipments")) { Width = 120 });
            this.dataColumns.Add(new PatternColumn("Перевозчик", "carrier", new FilterPatternExpressionRule("carrier")) { Width = 200 });
            this.dataColumns.Add(new PatternColumn("Статус анкеты", "worksheet_status", new FilterPatternExpressionRule("worksheet_status"), SummaryCalculationType.Count) { Width = 150 });
            this.dataColumns.Add(new PatternColumn("Номер анкеты", "worksheet_number", new FilterCompareExpressionRule<Int64>("worksheet_number"), SummaryCalculationType.Count) { Width = 120 });
            this.dataColumns.Add(new PatternColumn("Дата анкеты", "worksheet_date", new FilterDateCompareExpressionRule("worksheet_date"), SummaryCalculationType.Count) { Width = 120 });
            this.dataColumns.Add(new PatternColumn("Фармацевт", "provisor_name", new FilterPatternExpressionRule("provisor_name")) { Width = 200 });
            this.dataColumns.Add(new PatternColumn("Филиал", "warehouse_name", new FilterPatternExpressionRule("warehouse_name"), SummaryCalculationType.Count) { Width = 200 });
            this.dataColumns.Add(new PatternColumn("Дата отгрузки", "shipment_date", new FilterDateCompareExpressionRule("shipment_date"), SummaryCalculationType.Count) { Width = 120 });
        }
    }

    /// <summary>
    /// Критерий поиска
    /// </summary>
    public class QualityShippingAuthorizationParameters : SessionIDSearchParameters
    {
        public long? RouteListNumber { get; set; }
        public long? WorksheetNumber { get; set; }
        public string CarNumber { get; set; }
        public long? DebtorID { get; set; }
        public string DriverName { get; set; }
        public DateTime? PeriodFrom { get; set; }
        public DateTime? PeriodTo { get; set; }
        public long? ProvisorID { get; set; }

        public bool StatusNew { get; set; }
        public bool StatusInWork { get; set; }
        public bool StatusAccepted { get; set; }
        public bool StatusNotAccepted { get; set; }

        public bool? HasDesinfectionCert { get; set; }
        public bool? IsShippingToWarehouse { get; set; }

        public string StatusesList
        {
            get
            {
                var lstStatuses = new List<int>();

                if (this.StatusNew)
                    lstStatuses.Add(1);
                if (this.StatusInWork)
                    lstStatuses.Add(2);
                if (this.StatusAccepted)
                    lstStatuses.Add(3);
                if (this.StatusNotAccepted)
                    lstStatuses.Add(4);

                var sbStatusesList = new StringBuilder();

                foreach (var status in lstStatuses)
                {
                    if (sbStatusesList.Length > 0)
                        sbStatusesList.AppendFormat(",{0}", status);
                    else
                        sbStatusesList.AppendFormat("{0}", status);
                }

                return sbStatusesList.Length > 0 ? sbStatusesList.ToString() : (string)null;
            }
        }
    }
}
