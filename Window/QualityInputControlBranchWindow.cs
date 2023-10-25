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
using WMSOffice.Classes.ReportProviders;
using WMSOffice.Dialogs;
using WMSOffice.Reports;
using System.IO;
using System.Diagnostics;

namespace WMSOffice.Window
{
    public partial class QualityInputControlBranchWindow : GeneralWindow
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        private Data.Quality.QK_CB_WorksheetsRow SelectedWorksheet { get { return xdgvWorksheets.SelectedItem as Data.Quality.QK_CB_WorksheetsRow; } }

        private long? selectedWorksheetNumber = (int?)null;

        public QualityInputControlBranchWindow()
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

            QualityInputControlBranchWorksheetSearchForm.SearchParameter.SessionID = this.UserID;

            // статусы анкет
            chbStatusNew.Checked = QualityInputControlBranchWorksheetSearchForm.SearchParameter.StatusNew;
            chbStatusInWork.Checked = QualityInputControlBranchWorksheetSearchForm.SearchParameter.StatusInWork;
            chbStatusAccepted.Checked = QualityInputControlBranchWorksheetSearchForm.SearchParameter.StatusAccepted;
            chbStatusNotAccepted.Checked = QualityInputControlBranchWorksheetSearchForm.SearchParameter.StatusNotAccepted;

            xdgvWorksheets.AllowSummary = false;
            xdgvWorksheets.UseMultiSelectMode = false;

            xdgvWorksheets.Init(new QualityInputControlBranchView(), true);

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

            var canPrintActs = isEnabled && this.SelectedWorksheet.can_print_acts;
            btnPrintActs.Enabled = canPrintActs;
            
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
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            var qcbp = new QualityInputControlBranchParameters
            {
                SessionID = QualityInputControlBranchWorksheetSearchForm.SearchParameter.SessionID,

                StatusNew = QualityInputControlBranchWorksheetSearchForm.SearchParameter.StatusNew,
                StatusInWork = QualityInputControlBranchWorksheetSearchForm.SearchParameter.StatusInWork,
                StatusAccepted = QualityInputControlBranchWorksheetSearchForm.SearchParameter.StatusAccepted,
                StatusNotAccepted = QualityInputControlBranchWorksheetSearchForm.SearchParameter.StatusNotAccepted
            };

            this.LoadData(qcbp);
        }

        private void LoadData(QualityInputControlBranchParameters qcbp)
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
                        this.xdgvWorksheets.DataView.FillData(e.Argument as QualityInputControlBranchParameters);
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

                splashForm.ActionText = "Выполняется получение списка анкет м/с входного контроля..";
                bw.RunWorkerAsync(qcbp);
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
            var dlgSearchForm = new QualityInputControlBranchWorksheetSearchForm() { UserID = this.UserID };
            if (dlgSearchForm.ShowDialog() == DialogResult.OK)
            {
                chbStatusNew.Checked = QualityInputControlBranchWorksheetSearchForm.SearchParameter.StatusNew;
                chbStatusInWork.Checked = QualityInputControlBranchWorksheetSearchForm.SearchParameter.StatusInWork;
                chbStatusAccepted.Checked = QualityInputControlBranchWorksheetSearchForm.SearchParameter.StatusAccepted;
                chbStatusNotAccepted.Checked = QualityInputControlBranchWorksheetSearchForm.SearchParameter.StatusNotAccepted;

                this.LoadData(QualityInputControlBranchWorksheetSearchForm.SearchParameter);
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
                var editForm = new EditInputControlBranchWorksheetForm(UserID, SelectedWorksheet, isReadOnly);

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
                    var spReportProvider = new QualityInputControlReportProvider(UserID) { ControlType = InputControlTypes.BranchControl };
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

                var dlgSearchForm = new QualityInputControlBranchRegistrySearchForm() { UserID = this.UserID };
                if (dlgSearchForm.ShowDialog() == DialogResult.OK)
                {
                    using (var report = new QualityInputControlBranchControlRegistryReport())
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

            using (var adapter = new Data.QualityTableAdapters.QK_CB_Control_Registry_ReportTableAdapter())
                adapter.Fill(data.QK_CB_Control_Registry_Report, userID, routeListNumber, periodFrom, periodTo, provisorID, branchID);

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
                QualityInputControlBranchWorksheetSearchForm.SearchParameter.StatusNew = chbStatusNew.Checked;
            else if (chbStatusSelector.Equals(chbStatusInWork))
                QualityInputControlBranchWorksheetSearchForm.SearchParameter.StatusInWork = chbStatusInWork.Checked;
            else if (chbStatusSelector.Equals(chbStatusAccepted))
                QualityInputControlBranchWorksheetSearchForm.SearchParameter.StatusAccepted = chbStatusAccepted.Checked;
            else if (chbStatusSelector.Equals(chbStatusNotAccepted))
                QualityInputControlBranchWorksheetSearchForm.SearchParameter.StatusNotAccepted = chbStatusNotAccepted.Checked;
        }

        private void btnPrintActs_ButtonClick(object sender, EventArgs e)
        {
            btnPrintActs.ShowDropDown();
        }

        private void btnPrintActF129_Click(object sender, EventArgs e)
        {
            this.PrintActF129();
        }

        private void PrintActF129()
        {
            this.PrintActF129(null);
        }


        private void PrintActF129(string folderName)
        {
            try
            {
                if (!btnPrintActF129.Enabled)
                    return;

                var filePath = string.Empty;
                var fileName = string.Format("Акт Ф-129.docx");
                if (string.IsNullOrEmpty(folderName))
                {
                    var sfd = new SaveFileDialog();
                    sfd.FileName = fileName;
                    sfd.Title = "Сохранение акта Ф-129";
                    sfd.Filter = "Документы(*.docx)|*.docx";
                    sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    if (sfd.ShowDialog() != DialogResult.OK)
                        return;

                    filePath = sfd.FileName;
                }
                else
                {
                    filePath = Path.Combine(folderName, fileName);
                }

                using (var ms = new MemoryStream(Properties.Resources.QK_CB_Act_F_129))
                {
                    using (var fs = new FileStream(filePath, FileMode.Create))
                    {
                        ms.WriteTo(fs);

                        fs.Close();
                        ms.Close();

                        if (string.IsNullOrEmpty(folderName))
                            Process.Start(filePath);
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnPrintActF131_Click(object sender, EventArgs e)
        {
            this.PrintActF131();
        }

        private void PrintActF131()
        {
            this.PrintActF131(null);
        }

        private void PrintActF131(string folderName)
        {
            try
            {
                if (!btnPrintActF131.Enabled)
                    return;

                var filePath = string.Empty;
                var fileName = string.Format("Акт Ф-131.docx");
                if (string.IsNullOrEmpty(folderName))
                {
                    var sfd = new SaveFileDialog();
                    sfd.FileName = fileName;
                    sfd.Title = "Сохранение акта Ф-131";
                    sfd.Filter = "Документы(*.docx)|*.docx";
                    sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    if (sfd.ShowDialog() != DialogResult.OK)
                        return;

                    filePath = sfd.FileName;
                }
                else
                {
                    filePath = Path.Combine(folderName, fileName);
                }

                using (var ms = new MemoryStream(Properties.Resources.QK_CB_Act_F_131))
                {
                    using (var fs = new FileStream(filePath, FileMode.Create))
                    {
                        ms.WriteTo(fs);

                        fs.Close();
                        ms.Close();

                        if (string.IsNullOrEmpty(folderName))
                            Process.Start(filePath);
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnPrintAllActs_Click(object sender, EventArgs e)
        {
            this.PrintAllActs();
        }

        private void PrintAllActs()
        {
            try
            {
                if (!btnPrintAllActs.Enabled)
                    return;

                var dlgSelectFolder = new FolderBrowserDialog();
                dlgSelectFolder.RootFolder = Environment.SpecialFolder.MyComputer;
                dlgSelectFolder.Description = string.Format("Формирование актов");
                dlgSelectFolder.ShowNewFolderButton = false;
                if (dlgSelectFolder.ShowDialog() != DialogResult.OK)
                    return;

                var folderName = dlgSelectFolder.SelectedPath;
                var rootDir = folderName;

                if (!Directory.Exists(rootDir))
                    Directory.CreateDirectory(rootDir);

                this.PrintActF129(rootDir);
                this.PrintActF131(rootDir);

                Process.Start(rootDir);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }
    }

    /// <summary>
    /// Представление для анкет разрешений на отгрузку
    /// </summary>
    public class QualityInputControlBranchView : IDataView
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
            var searchCriteria = searchParameters as QualityInputControlBranchParameters;

            var sessionID = searchCriteria.SessionID;
            var routeListNumber = searchCriteria.RouteListNumber;
            var worksheetNumber = searchCriteria.WorksheetNumber;
            var filialFromID = searchCriteria.FilialFromID;
            var filialToID = searchCriteria.FilialToID;
            var driverName = searchCriteria.DriverName;
            var periodFrom = searchCriteria.PeriodFrom;
            var periodTo = searchCriteria.PeriodTo;
            var provisorID = searchCriteria.ProvisorID;
            var statusesList = searchCriteria.StatusesList;

            using (var adapter = new Data.QualityTableAdapters.QK_CB_WorksheetsTableAdapter())
            {
                adapter.SetTimeout(DEFAULT_RESPONSE_TIMEOUT);
                data = adapter.GetData(sessionID, routeListNumber, worksheetNumber, filialFromID, driverName, periodFrom, periodTo, provisorID, statusesList, filialToID);
            }
        }

        #endregion

        public QualityInputControlBranchView()
        {
            this.dataColumns.Add(new PatternColumn("№ МЛ (межсклад)", "route_list_number", new FilterCompareExpressionRule<Int64>("route_list_number"), SummaryCalculationType.Count) { Width = 150 });
            this.dataColumns.Add(new PatternColumn("Номер авто", "car_number", new FilterPatternExpressionRule("car_number")) { Width = 150 });
            this.dataColumns.Add(new PatternColumn("Номер полуприцепа", "trailer", new FilterPatternExpressionRule("trailer")) { Width = 150 });
            this.dataColumns.Add(new PatternColumn("Филиал (отправитель)", "filial_from_name", new FilterPatternExpressionRule("filial_from_name"), SummaryCalculationType.Count) { Width = 200 });
            this.dataColumns.Add(new PatternColumn("Филиал (получатель)", "filial_to_name", new FilterPatternExpressionRule("filial_to_name"), SummaryCalculationType.Count) { Width = 200 });
            this.dataColumns.Add(new PatternColumn("Статус анкеты", "worksheet_status", new FilterPatternExpressionRule("worksheet_status"), SummaryCalculationType.Count) { Width = 150 });
            this.dataColumns.Add(new PatternColumn("№ анкеты", "worksheet_number", new FilterCompareExpressionRule<Int64>("worksheet_number"), SummaryCalculationType.Count) { Width = 90 });
            this.dataColumns.Add(new PatternColumn("Версия анкеты", "version_number", new FilterCompareExpressionRule<Int64>("version_number"), SummaryCalculationType.Count) { Width = 120 });
            this.dataColumns.Add(new PatternColumn("Дата анкеты", "worksheet_date", new FilterDateCompareExpressionRule("worksheet_date"), SummaryCalculationType.Count) { Width = 120 });
            this.dataColumns.Add(new PatternColumn("Дата версии", "version_date", new FilterDateCompareExpressionRule("version_date"), SummaryCalculationType.Count) { Width = 120 });
            this.dataColumns.Add(new PatternColumn("Автор версии", "user_created", new FilterPatternExpressionRule("user_created")) { Width = 200 });
            this.dataColumns.Add(new PatternColumn("Фармацевт", "provisor_name", new FilterPatternExpressionRule("provisor_name")) { Width = 200 });
        }
    }

    /// <summary>
    /// Критерий поиска
    /// </summary>
    public class QualityInputControlBranchParameters : SessionIDSearchParameters
    {
        public long? RouteListNumber { get; set; }
        public long? WorksheetNumber { get; set; }
        public long? FilialFromID { get; set; }
        public long? FilialToID { get; set; }
        public string DriverName { get; set; }
        public DateTime? PeriodFrom { get; set; }
        public DateTime? PeriodTo { get; set; }
        public long? ProvisorID { get; set; }

        public bool StatusNew { get; set; }
        public bool StatusInWork { get; set; }
        public bool StatusAccepted { get; set; }
        public bool StatusNotAccepted { get; set; }

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
