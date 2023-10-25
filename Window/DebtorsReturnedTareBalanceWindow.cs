using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Controls;
using System.Diagnostics;
using WMSOffice.Classes;
using WMSOffice.Dialogs.Containers;

namespace WMSOffice.Window
{
    public partial class DebtorsReturnedTareBalanceWindow : GeneralWindow
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        /// <summary>
        /// Стратегия изменений представлений
        /// </summary>
        private readonly List<TareBalanceGroupCondition> lstTareBalanceGroupConditions = null;

        /// <summary>
        /// Стек из параметров построения представлений 
        /// </summary>
        private readonly Stack<TareBalanceGroupsViewSearchParameters> stFilter = null;

        /// <summary>
        /// Хранилище компонент фильтрации
        /// </summary>
        private readonly FilterStorage filterStorage = null;

        private TextBoxScaner tbScanner = null;

        private ToolStripTextBox tbDebtorID = null;

        public DebtorsReturnedTareBalanceWindow()
        {
            InitializeComponent();

            lstTareBalanceGroupConditions = new List<TareBalanceGroupCondition>(new TareBalanceGroupCondition[] 
            { 
                TareBalanceGroupCondition.ByType, 
                TareBalanceGroupCondition.ByTypeLocations, 
                TareBalanceGroupCondition.ByTypeLocationsBarcodes 
            });

            stFilter = new Stack<TareBalanceGroupsViewSearchParameters>(new TareBalanceGroupsViewSearchParameters[] { new TareBalanceGroupsViewSearchParameters() });

            filterStorage = new FilterStorage();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            stFilter.Peek().SessionID = this.UserID;

            Initialize();
            ReloadData();
        }


        private void Initialize()
        {
            #region ИНИЦИАЛИЗАЦИЯ ПОИСКА ПО Ш/К

            tsSearch.Items.Add(new ToolStripLabel("Ш/К"));

            tbScanner = new TextBoxScaner();
            tbScanner.TextChanged += (s, e) =>
            {
                if (!string.IsNullOrEmpty(tbScanner.Text))
                {
                    this.ChangeViewLevel(false, true);

                    tbScanner.Text = string.Empty;
                }
            };
            tsSearch.Items.Add(new ToolStripControlHost(tbScanner) { Width = 210 });

            #endregion

            #region ИНИЦИАЛИЗАЦИЯ ПОИСКА ПО КОДУ ТТ

            tsSearch.Items.Add(new ToolStripLabel("Код ТТ"));

            tbDebtorID = new ToolStripTextBox() { Width = 210 };
            tbDebtorID.KeyDown += (s, e) => 
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (!string.IsNullOrEmpty(tbDebtorID.Text))
                    {
                        this.ChangeViewLevel(false, true);

                        tbDebtorID.Text = string.Empty;
                    }
                }
            };
            tsSearch.Items.Add(tbDebtorID);

            #endregion

            xdgvItems.AllowSummary = false;

            //xdgvItems.Init(new DebtorsReturnedTareView(), true);
            xdgvItems.Init(new TareBalanceGroupsByTypeView(TareBalanceGroupCondition.ByType), true);
            xdgvItems.UserID = this.UserID;

            xdgvItems.UseMultiSelectMode = true;

            xdgvItems.OnDataError += new DataGridViewDataErrorEventHandler(xdgvItems_OnDataError);
            xdgvItems.OnRowSelectionChanged += new EventHandler(xdgvItems_OnRowSelectionChanged);
            xdgvItems.OnRowDoubleClick += new DataGridViewCellEventHandler(xdgvItems_OnRowDoubleClick);
            xdgvItems.OnFilterChanged += new EventHandler(xdgvItems_OnFilterChanged);
            xdgvItems.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvItems_OnFormattingCell);

            // активация постраничного просмотра
            xdgvItems.CreatePageNavigator();

            this.SetOperationAccess(true);

            ChangeUndoLevelOperationAccess();
        }

        void xdgvItems_OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        void xdgvItems_OnRowSelectionChanged(object sender, EventArgs e)
        {
            this.SetOperationAccess(false);
        }

        void xdgvItems_OnRowDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            if (xdgvItems.SelectedItem != null)
                this.ChangeViewLevel(false, false);
        }

        private void ChangeViewLevel(bool gotoUpperLevel, bool gotoLeafLevel)
        {
            try
            {
                if (gotoUpperLevel)
                    stFilter.Pop();

                if (gotoLeafLevel)
                {
                    while (stFilter.Count > 1)
                        stFilter.Pop();
                }

                var cntTareGroupsFilterCondition = stFilter.Count; // кол-во элементов в стеке

                if (cntTareGroupsFilterCondition == lstTareBalanceGroupConditions.Count)
                    return;

                var idxNextTareGroupCondition = gotoLeafLevel
                                                    ? lstTareBalanceGroupConditions.Count - 1
                                                    : gotoUpperLevel
                                                        ? cntTareGroupsFilterCondition - 1
                                                        : cntTareGroupsFilterCondition; // индекс следующего типа представления

                var nextTareGroupCondition = lstTareBalanceGroupConditions[idxNextTareGroupCondition]; // следующий тип представления

                var currentSearchParams = stFilter.Peek();
                var nextSearchParams = new TareBalanceGroupsViewSearchParameters();

                filterStorage.Clear();
                switch (nextTareGroupCondition)
                {
                    case TareBalanceGroupCondition.ByType:
                        nextSearchParams.SessionID = currentSearchParams.SessionID;

                        break;
                    case TareBalanceGroupCondition.ByTypeLocations:
                        nextSearchParams.SessionID = currentSearchParams.SessionID;

                        nextSearchParams.DirectionID = gotoUpperLevel ? currentSearchParams.DirectionID : Convert.ToInt32(xdgvItems.SelectedItem["id"]);

                        break;
                    case TareBalanceGroupCondition.ByTypeLocationsBarcodes:
                        nextSearchParams.SessionID = currentSearchParams.SessionID;

                        if (gotoLeafLevel)
                        {
                            if (!string.IsNullOrEmpty(tbScanner.Text))
                            {
                                nextSearchParams.BarCode = tbScanner.Text;
                                filterStorage.Add(new FilterItem("Tare_bar_code", nextSearchParams.BarCode));
                            }

                            if (!string.IsNullOrEmpty(tbDebtorID.Text))
                            {
                                int debtorID;
                                if (!Int32.TryParse(tbDebtorID.Text, out debtorID))
                                    throw new Exception("Код дебитора должен быть числом.");

                                nextSearchParams.DebtorID = debtorID;
                                filterStorage.Add(new FilterItem("client_id", nextSearchParams.DebtorID.ToString()));
                            }
                        }
                        else
                        {
                            nextSearchParams.TareType = gotoUpperLevel ? currentSearchParams.TareType : xdgvItems.SelectedItem["Tare_Type"].ToString();
                            filterStorage.Add(new FilterItem("Tare_type_name", nextSearchParams.TareType));

                            nextSearchParams.LocationID = gotoUpperLevel ? currentSearchParams.LocationID : xdgvItems.SelectedItem["lilocn"].ToString();
                            filterStorage.Add(new FilterItem("location_id", nextSearchParams.LocationID.Trim()));

                            nextSearchParams.WarehouseID = gotoUpperLevel ? currentSearchParams.WarehouseID : xdgvItems.SelectedItem["limcu"].ToString();
                            filterStorage.Add(new FilterItem("mcu", nextSearchParams.WarehouseID.Trim()));
                        }

                        break;
                    default:
                        break;
                }

                if (!gotoUpperLevel)
                    stFilter.Push(nextSearchParams);

                xdgvItems.Init(new TareBalanceGroupsByTypeView(nextTareGroupCondition), true);

                xdgvItems.ApplyFilter(filterStorage);

                ReloadData();

                ChangeUndoLevelOperationAccess();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void ChangeUndoLevelOperationAccess()
        {
            btnUndoLevel.Enabled = stFilter.Count > 1;
        }

        private void SetOperationAccess(bool wholeViewAccess)
        {
            if (wholeViewAccess)
            {
                bool hasRows = xdgvItems.HasRows;
                bool isEnabled = hasRows && xdgvItems.SelectedItem != null;

                bool isExportCurrentDataEnabled = hasRows;
                miExportPartialData.Enabled = isExportCurrentDataEnabled;
            }
            else
            {
                bool hasRows = xdgvItems.HasRows;
                bool isEnabled = xdgvItems.SelectedItem != null;

                bool isExportCurrentDataEnabled = hasRows;
                miExportPartialData.Enabled = isExportCurrentDataEnabled;
            }
        }

        void xdgvItems_OnFilterChanged(object sender, EventArgs e)
        {
            xdgvItems.RecalculateSummary();
            this.SetOperationAccess(true);
        }

        void xdgvItems_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
           
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F5))
            {
                this.ReloadData();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.ReloadData();
        }

        private void ReloadData()
        {
            try
            {
                var searchParams = stFilter.Peek();

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    try
                    {
                        this.xdgvItems.DataView.FillData(e.Argument as TareBalanceGroupsViewSearchParameters);
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
                        this.xdgvItems.BindData(false);

                        //this.xdgvItems.AllowFilter = true;
                        this.xdgvItems.AllowSummary = true;
                    }

                    splashForm.CloseForce();
                };

                splashForm.ActionText = "Выполняется получение данных..";
                bw.RunWorkerAsync(searchParams);
                splashForm.ShowDialog();

                if (xdgvItems.DataGrid.Rows.Count > 0)
                    xdgvItems.DataGrid.Rows[0].Selected = false;

                xdgvItems.DataGrid.Select();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnUndoLevel_Click(object sender, EventArgs e)
        {
            this.ChangeViewLevel(true, false);
        }

        private void btnExport_ButtonClick(object sender, EventArgs e)
        {
            btnExport.ShowDropDown();
        }

        private void miExportPartialData_Click(object sender, EventArgs e)
        {
            this.ExportCurrentData();
        }

        private void ExportCurrentData()
        {
            using (SaveFileDialog dlgSelectFile = new SaveFileDialog())
            {
                dlgSelectFile.Title = "Экспорт баланса оборотной тары (текущий)";

                DateTime now = DateTime.Now;
                dlgSelectFile.FileName = string.Format("{0}{1}{2}{3}{4}{5}-реестр баланса оборотной тары (текущий)",
                    now.Year.ToString(),
                    now.Month.ToString().PadLeft(2, '0'),
                    now.Day.ToString().PadLeft(2, '0'),
                    now.Hour.ToString().PadLeft(2, '0'),
                    now.Minute.ToString().PadLeft(2, '0'),
                    now.Second.ToString().PadLeft(2, '0')
                    );

                dlgSelectFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                dlgSelectFile.Filter = "Текстовый файл с разделителями (*.csv)|*.csv";//;*.csv|Все файлы (*.*)|*.*";
                dlgSelectFile.FilterIndex = 0;
                //////dlgSelectFile.AddExtension = true;
                dlgSelectFile.DefaultExt = "csv";
                if (dlgSelectFile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        this.xdgvItems.ExportToExcel(dlgSelectFile.FileName);
                        Process.Start(dlgSelectFile.FileName);
                    }
                    catch (Exception ex)
                    {
                        this.ShowError(ex);
                    }
                }
            }
        }

        private void miExportFullData_Click(object sender, EventArgs e)
        {
            this.ExportFullData();
        }

        private void ExportFullData()
        {
            try
            {
                var searchParameters = new TareBalanceGroupsViewSearchParameters();
                searchParameters.SessionID = this.UserID;

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    try
                    {
                        var dv = new TareBalanceGroupsByTypeView(TareBalanceGroupCondition.ByTypeLocationsBarcodes);

                        var sp = e.Argument as TareBalanceGroupsViewSearchParameters;
                        dv.FillData(searchParameters);

                        e.Result = dv;
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
                        var dv = e.Result as TareBalanceGroupsByTypeView;

                        var lstTitles = new List<string>();
                        var lstColumnNames = new List<string>();

                        foreach (PatternColumn pc in dv.Columns)
                        {
                            if (!pc.DataFieldName.Contains("COLOR"))
                            {
                                lstTitles.Add(pc.Caption);
                                lstColumnNames.Add(pc.DataFieldName);
                            }
                        }

                        ExportHelper.ExportDataTableToExcel(dv.Data, lstTitles.ToArray(), lstColumnNames.ToArray(), "Экспорт баланса оборотной тары (полный)", "реестр баланса оборотной тары (полный)", true);
                    }

                    splashForm.CloseForce();
                };

                splashForm.ActionText = "Выполняется экспорт данных";
                bw.RunWorkerAsync(searchParameters);
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnSetTareException_Click(object sender, EventArgs e)
        {
            this.SetTareException();
        }

        private void SetTareException()
        {
            try
            {
                var dlgDebtorsReturnedTareSetException = new DebtorsReturnedTareSetExceptionForm() { UserID = this.UserID };
                if (dlgDebtorsReturnedTareSetException.ShowDialog(this) == DialogResult.OK)
                    this.ReloadData();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }
    }

    /// <summary>
    /// Представление для баланса оборотной тары
    /// </summary>
    public class TareBalanceGroupsByTypeView : IDataView
    {
        public TareBalanceGroupCondition TareBalanceGroupCondition { get; private set; }

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

        /// <summary>
        /// Поиск конечной выборки согласно критериям
        /// </summary>
        /// <param name="searchParameters">Критерии поиска</param>
        public void FillData(SearchParametersBase searchParameters)
        {
            var searchCriteria = searchParameters as TareBalanceGroupsViewSearchParameters;

            var sessionID = searchCriteria.SessionID;
            var directionID = searchCriteria.DirectionID;
            var tareType = searchCriteria.TareType;
            var locationID = searchCriteria.LocationID;
            var barCode = searchCriteria.BarCode;
            var warehouseID = searchCriteria.WarehouseID;
            var debtorID = searchCriteria.DebtorID;

            switch (this.TareBalanceGroupCondition)
            {
                case TareBalanceGroupCondition.ByType:
                    using (var adapter = new Data.PickControlTableAdapters.CT_Tare_Balance_Groups_By_TypeTableAdapter())
                    {
                        adapter.SetTimeout(DEFAULT_RESPONSE_TIMEOUT);
                        this.data = adapter.GetData(sessionID);
                    }
                    break;
                case TareBalanceGroupCondition.ByTypeLocations:
                    using (var adapter = new Data.PickControlTableAdapters.CT_Tare_Balance_By_Type_LocationsTableAdapter())
                    {
                        adapter.SetTimeout(DEFAULT_RESPONSE_TIMEOUT);
                        this.data = adapter.GetData(sessionID, directionID);
                    }
                    break;
                case TareBalanceGroupCondition.ByTypeLocationsBarcodes:
                    using (var adapter = new Data.PickControlTableAdapters.CT_Tare_Balance_By_Type_Locations_BarcodesTableAdapter())
                    {
                        adapter.SetTimeout(DEFAULT_RESPONSE_TIMEOUT);
                        this.data = adapter.GetData(sessionID, tareType, locationID, warehouseID, barCode, debtorID);
                    }
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ
        public TareBalanceGroupsByTypeView(TareBalanceGroupCondition tareBalanceGroupCondition)
        {
            switch ((this.TareBalanceGroupCondition = tareBalanceGroupCondition))
            {
                case TareBalanceGroupCondition.ByType:
                    this.dataColumns.Add(new PatternColumn("Местоположение", "type", new FilterPatternExpressionRule("type"), SummaryCalculationType.Count) { Width = 200 });
                    this.dataColumns.Add(new PatternColumn("Количество", "qty", new FilterCompareExpressionRule<Int32>("qty"), SummaryCalculationType.Sum) { Width = 100, UseIntegerNumbersAlignment = true });
                    this.dataColumns.Add(new PatternColumn("Просрочено, шт.", "overdue_qty", new FilterCompareExpressionRule<Int32>("overdue_qty"), SummaryCalculationType.Sum) { Width = 115, UseIntegerNumbersAlignment = true });
                    break;
                case TareBalanceGroupCondition.ByTypeLocations:
                    this.dataColumns.Add(new PatternColumn("Тип тары", "Tare_type_name", new FilterPatternExpressionRule("Tare_type_name"), SummaryCalculationType.Count) { Width = 250 });

                    this.dataColumns.Add(new PatternColumn("Место", "lilocn", new FilterPatternExpressionRule("lilocn"), SummaryCalculationType.Count) { Width = 150 });
                    this.dataColumns.Add(new PatternColumn("Склад", "limcu", new FilterPatternExpressionRule("limcu"), SummaryCalculationType.Count) { Width = 100 });

                    this.dataColumns.Add(new PatternColumn("Код ТТ", "client_id", new FilterCompareExpressionRule<Int32>("client_id"), SummaryCalculationType.Count) { Width = 100 });
                    this.dataColumns.Add(new PatternColumn("Наименование ТТ", "client_name", new FilterPatternExpressionRule("client_name")) { Width = 200 });

                    this.dataColumns.Add(new PatternColumn("Код дебитора", "debtor_id", new FilterPatternExpressionRule("debtor_id"), SummaryCalculationType.Count) { Width = 105 });
                    this.dataColumns.Add(new PatternColumn("Наименование дебитора", "debtor_name", new FilterPatternExpressionRule("debtor_name")) { Width = 200 });

                    this.dataColumns.Add(new PatternColumn("Количество", "qty", new FilterCompareExpressionRule<Int32>("qty"), SummaryCalculationType.Sum) { Width = 100, UseIntegerNumbersAlignment = true });
                    this.dataColumns.Add(new PatternColumn("Просрочено, шт.", "overdue_qty", new FilterCompareExpressionRule<Int32>("overdue_qty"), SummaryCalculationType.Sum) { Width = 115, UseIntegerNumbersAlignment = true });
                    break;
                case TareBalanceGroupCondition.ByTypeLocationsBarcodes:
                    this.dataColumns.Add(new PatternColumn("Ш/К", "Tare_bar_code", new FilterPatternExpressionRule("Tare_bar_code"), SummaryCalculationType.Count) { Width = 150 });
                    this.dataColumns.Add(new PatternColumn("Тип тары", "Tare_type_name", new FilterPatternExpressionRule("Tare_type_name"), SummaryCalculationType.Count) { Width = 250 });

                    this.dataColumns.Add(new PatternColumn("Код товара", "item_id", new FilterCompareExpressionRule<Int32>("item_id"), SummaryCalculationType.Count) { Width = 100 });
                    this.dataColumns.Add(new PatternColumn("Партия", "lot_number", new FilterPatternExpressionRule("lot_number"), SummaryCalculationType.Count) { Width = 100 });

                    this.dataColumns.Add(new PatternColumn("Место", "location_id", new FilterPatternExpressionRule("location_id"), SummaryCalculationType.Count) { Width = 150 });
                    this.dataColumns.Add(new PatternColumn("Склад", "mcu", new FilterPatternExpressionRule("mcu"), SummaryCalculationType.Count) { Width = 100 });

                    this.dataColumns.Add(new PatternColumn("Описание статуса", "status_description", new FilterPatternExpressionRule("status_description"), SummaryCalculationType.Count) { Width = 200 });

                    this.dataColumns.Add(new PatternColumn("Код ТТ", "client_id", new FilterCompareExpressionRule<Int32>("client_id"), SummaryCalculationType.Count) { Width = 100 });
                    this.dataColumns.Add(new PatternColumn("Наименование ТТ", "client_name", new FilterPatternExpressionRule("client_name")) { Width = 200 });

                    this.dataColumns.Add(new PatternColumn("Код дебитора", "debtor_id", new FilterPatternExpressionRule("debtor_id"), SummaryCalculationType.Count) { Width = 105 });
                    this.dataColumns.Add(new PatternColumn("Наименование дебитора", "debtor_name", new FilterPatternExpressionRule("debtor_name")) { Width = 200 });

                    this.dataColumns.Add(new PatternColumn("МЛ", "route_number", new FilterPatternExpressionRule("route_number"), SummaryCalculationType.Count) { Width = 60 });
                    this.dataColumns.Add(new PatternColumn("Накл. ОТ", "invoice_number", new FilterPatternExpressionRule("invoice_number"), SummaryCalculationType.Count) { Width = 60 });

                    this.dataColumns.Add(new PatternColumn("Дата отгрузки", "shipping_date", new FilterDateCompareExpressionRule("shipping_date")) { Width = 115 });
                    this.dataColumns.Add(new PatternColumn("Просрочено, дн.", "overdue_days", new FilterCompareExpressionRule<Int32>("overdue_days")) { Width = 115, UseIntegerNumbersAlignment = true });

                    this.dataColumns.Add(new PatternColumn("ФИО первого водителя", "last_delivery_driver_name", new FilterPatternExpressionRule("last_delivery_driver_name")) { Width = 200 });
                    this.dataColumns.Add(new PatternColumn("ФИО последнего водителя", "last_visit_driver_name", new FilterPatternExpressionRule("last_visit_driver_name")) { Width = 200 });
                    this.dataColumns.Add(new PatternColumn("Дата последней доставки", "last_delivery_date", new FilterDateCompareExpressionRule("last_delivery_date")) { Width = 200 });
                    break;
                default:
                    break;
            }
        }
        #endregion
    }

    /// <summary>
    /// Критерий поиска
    /// </summary>
    public class TareBalanceGroupsViewSearchParameters : SessionIDSearchParameters
    {
        public int? DirectionID { get; set; }
        public string TareType { get; set; }
        public string LocationID { get; set; }
        public string BarCode { get; set; }
        public string WarehouseID { get; set; }
        public int? DebtorID { get; set; }
    }

    public enum TareBalanceGroupCondition
    {
        ByType = 0,
        ByTypeLocations = 1,
        ByTypeLocationsBarcodes = 2
    }
}
