using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Dialogs.PickControl;
using WMSOffice.Controls;
using System.Diagnostics;
using WMSOffice.Classes;
using WMSOffice.Dialogs;

namespace WMSOffice.Window
{
    public partial class DebtorsReturnedTareWindow : GeneralWindow
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        /// <summary>
        /// Стратегия изменений представлений
        /// </summary>
        private readonly List<TareGroupCondition> lstTareGroupConditions = null;

        /// <summary>
        /// Стек из параметров построения представлений 
        /// </summary>
        private readonly Stack<TareGroupsViewSearchParameters> stFilter = null;

        /// <summary>
        /// Хранилище компонент фильтрации
        /// </summary>
        private readonly FilterStorage filterStorage = null;

        private TextBoxScaner tbScanner = null;

        public DebtorsReturnedTareWindow()
        {
            InitializeComponent();

            //sbSetDublicate.Visible = toolStripSeparator2.Visible = false;

            lstTareGroupConditions = new List<TareGroupCondition>(new TareGroupCondition[] 
            { 
                TareGroupCondition.ByType, 
                TareGroupCondition.ByTypeStatuses, 
                TareGroupCondition.ByTypeStatusesBarcodes 
            });

            stFilter = new Stack<TareGroupsViewSearchParameters>(new TareGroupsViewSearchParameters[] { new TareGroupsViewSearchParameters() });

            filterStorage = new FilterStorage();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            stFilter.Peek().SessionID = this.UserID;

            Initialize();
            LoadPrinters();
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

            xdgvItems.AllowSummary = false;

            //xdgvItems.Init(new DebtorsReturnedTareView(), true);
            xdgvItems.Init(new TareGroupsByTypeView(TareGroupCondition.ByType), true);
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

                if (cntTareGroupsFilterCondition == lstTareGroupConditions.Count)
                    return;

                var idxNextTareGroupCondition = gotoLeafLevel
                                                    ? lstTareGroupConditions.Count - 1
                                                    : gotoUpperLevel
                                                        ? cntTareGroupsFilterCondition - 1
                                                        : cntTareGroupsFilterCondition; // индекс следующего типа представления

                var nextTareGroupCondition = lstTareGroupConditions[idxNextTareGroupCondition]; // следующий тип представления

                var currentSearchParams = stFilter.Peek();
                var nextSearchParams = new TareGroupsViewSearchParameters();

                filterStorage.Clear();
                switch (nextTareGroupCondition)
                {
                    case TareGroupCondition.ByType:
                        nextSearchParams.SessionID = currentSearchParams.SessionID;

                        break;
                    case TareGroupCondition.ByTypeStatuses:
                        nextSearchParams.SessionID = currentSearchParams.SessionID;

                        nextSearchParams.TareType = gotoUpperLevel ? currentSearchParams.TareType : xdgvItems.SelectedItem["Tare_Type"].ToString();
                        filterStorage.Add(new FilterItem("Formatted_Tare_Name", nextSearchParams.TareType));

                        nextSearchParams.WarehouseID = gotoUpperLevel ? currentSearchParams.WarehouseID : xdgvItems.SelectedItem["warehouse_id"].ToString();
                        filterStorage.Add(new FilterItem("warehouse_id", nextSearchParams.WarehouseID));

                        break;
                    case TareGroupCondition.ByTypeStatusesBarcodes:
                        nextSearchParams.SessionID = currentSearchParams.SessionID;

                        if (gotoLeafLevel)
                        {
                            nextSearchParams.BarCode = tbScanner.Text;
                            filterStorage.Add(new FilterItem("Bar_code", nextSearchParams.BarCode));
                        }
                        else
                        {
                            nextSearchParams.TareType = currentSearchParams.TareType;
                            filterStorage.Add(new FilterItem("Formatted_Tare_Name", nextSearchParams.TareType));

                            nextSearchParams.StatusID = gotoUpperLevel ? currentSearchParams.StatusID : xdgvItems.SelectedItem["status_id"].ToString();
                            filterStorage.Add(new FilterItem("status_id", nextSearchParams.StatusID));

                            nextSearchParams.WarehouseID = gotoUpperLevel ? currentSearchParams.WarehouseID : xdgvItems.SelectedItem["warehouse_id"].ToString();
                            filterStorage.Add(new FilterItem("warehouse_id", nextSearchParams.WarehouseID));
                        }

                        break;
                    default:
                        break;
                }

                if (!gotoUpperLevel)
                    stFilter.Push(nextSearchParams);

                xdgvItems.Init(new TareGroupsByTypeView(nextTareGroupCondition), true);

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
            sbUndoLevel.Enabled = stFilter.Count > 1;
        }

        private void SetOperationAccess(bool wholeViewAccess)
        {
            if (wholeViewAccess)
            {
                bool hasRows = xdgvItems.HasRows;
                bool isEnabled = hasRows && xdgvItems.SelectedItem != null;

                bool isExportCurrentDataEnabled = hasRows;
                miExportPartialData.Enabled = isExportCurrentDataEnabled;

                var isRepeatPrintEnabled = false;
                sbRepeatPrint.Enabled = isRepeatPrintEnabled;

                var isExportHistoryDataEnabled = isEnabled 
                    && (xdgvItems.DataView as TareGroupsByTypeView).TareGroupCondition == TareGroupCondition.ByTypeStatusesBarcodes 
                    && xdgvItems.SelectedItem["status_id"].ToString() == "444"; // статус "Тару нужно найти на ЦС"
                miExportHistoryData.Enabled = isExportHistoryDataEnabled;
            }
            else
            {
                bool hasRows = xdgvItems.HasRows;
                bool isEnabled = xdgvItems.SelectedItem != null;

                bool isExportCurrentDataEnabled = hasRows;
                miExportPartialData.Enabled = isExportCurrentDataEnabled;

                var isRepeatPrintEnabled = false;
                sbRepeatPrint.Enabled = isRepeatPrintEnabled;

                var isExportHistoryDataEnabled = isEnabled
                   && (xdgvItems.DataView as TareGroupsByTypeView).TareGroupCondition == TareGroupCondition.ByTypeStatusesBarcodes
                   && xdgvItems.SelectedItem["status_id"].ToString() == "444"; // статус "Тару нужно найти на ЦС"
                miExportHistoryData.Enabled = isExportHistoryDataEnabled;
            }
        }

        void xdgvItems_OnFilterChanged(object sender, EventArgs e)
        {
            xdgvItems.RecalculateSummary();
            this.SetOperationAccess(true);
        }

        void xdgvItems_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            var boundRow = (xdgvItems.DataGrid.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;

            #region СТИЛЬ ДЛЯ ИНДИКАЦИИ ЭТИКЕТОК ОБОРОТНОЙ ТАРЫ

            if (boundRow.Table.Columns.Contains("COLOR"))
            {
                var colorName = boundRow["COLOR"].ToString();
                var color = string.IsNullOrEmpty(colorName) ? Color.White : Color.FromName(colorName);

                e.CellStyle.BackColor = color;
                e.CellStyle.SelectionForeColor = color;
            }

            #endregion
        }

        private void LoadPrinters()
        {
            try
            {
                var printers = new Data.PickControl.CT_PrintersDataTable();

                using (var adapter = new Data.PickControlTableAdapters.CT_PrintersTableAdapter())
                    adapter.Fill(printers);

                foreach (Data.PickControl.CT_PrintersRow printer in printers.Rows)
                    cmbPrinters.ComboBox.Items.Add(printer.Print_id);

                if (printers.Rows.Count > 0)
                    cmbPrinters.SelectedItem = printers[0].Print_id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void sbRefresh_Click(object sender, EventArgs e)
        {
            this.ReloadData();
        }

        private void ReloadData()
        {
            try
            {
                //var searchParams = new TareGroupsViewSearchParameters() { SessionID = this.UserID };
                var searchParams = stFilter.Peek();

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    this.xdgvItems.DataView.FillData(e.Argument as TareGroupsViewSearchParameters);
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

        private void sbPrint_Click(object sender, EventArgs e)
        {
            try
            {
                var dlgDebtorsReturnedTarePrint = new DebtorsReturnedTarePrintForm { UserID = this.UserID, DefaultPrinterID = cmbPrinters.SelectedItem.ToString() };
                dlgDebtorsReturnedTarePrint.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sbAssign_Click(object sender, EventArgs e)
        {
            try
            {
                var needReloadData = false;
                //var lastBarcode = (string)null;

                while (true)
                {
                    try
                    {
                        var dlgDebtorsReturnedTareAssign = new DebtorsReturnedTareAssignForm { UserID = this.UserID };
                        if (dlgDebtorsReturnedTareAssign.ShowDialog() == DialogResult.OK)
                        {
                            needReloadData = true;
                            break;
                        }
                        else
                            break;

                        #region ПЕРВИЧЫЙ ПОДХОД ПРИВЯЗКИ ЭТИКЕТОК НЕ ИСПОЛЬЗУЕТСЯ (ЗАКОММЕНТИРОВАН)

                        //var dlgAssignEtic = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                        //{
                        //    Label = "Отсканируйте этикетку,\r\nкоторую необходимо привязать",
                        //    Text = "Привязка этикеток",
                        //    Image = Properties.Resources.barcode,
                        //    Barcode = lastBarcode
                        //};

                        //if (dlgAssignEtic.ShowDialog() == DialogResult.OK)
                        //{
                        //    var barcode = lastBarcode = dlgAssignEtic.Barcode;

                        //    using (var adapter = new Data.PickControlTableAdapters.CT_TareEticsTableAdapter())
                        //        adapter.AssignEtic(barcode, this.UserID);

                        //    needReloadData = true;
                        //    lastBarcode = (string)null;
                        //}
                        //else
                        //    break;

                        #endregion
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }
                }

                if (needReloadData)
                    this.ReloadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sbRepeatPrint_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Напечатать повторно выбранные этикетки?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                return;

            try
            {
                var isSingleEticRepeatPrintMode = xdgvItems.SelectedItems.Count == 1;

                foreach (var item in xdgvItems.SelectedItems)
                {
                    var eticRow = item as Data.PickControl.CT_Tare_Groups_By_Type_Statuses_BarcodesRow;

                    var printerID = cmbPrinters.SelectedItem.ToString();
                    var tareType = (string)null;
                    var eticsQuantity = (int?)null;
                    var itemID = eticRow.Item_id;
                    var barCode = eticRow.Bar_code;
                    var repeatMode = 1;

                    if (isSingleEticRepeatPrintMode)
                    {
                        var dlgSetPrintCopyQuantity = new SetPrintCopyQuantityForm();
                        if (dlgSetPrintCopyQuantity.ShowDialog() == DialogResult.OK)
                            eticsQuantity = dlgSetPrintCopyQuantity.Quantity;
                        else
                            return;
                    }

                    using (var adapter = new Data.PickControlTableAdapters.CT_TareEticsTableAdapter())
                        adapter.PrintEtic(printerID, tareType, eticsQuantity, itemID, barCode, repeatMode);
                }

                this.ReloadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sbTareIssue_Click(object sender, EventArgs e)
        {
            var dlgDebtorsReturnedTareIssue = new DebtorsReturnedTareIssueForm { UserID = this.UserID };
            if (dlgDebtorsReturnedTareIssue.ShowDialog() == DialogResult.OK)
                this.ReloadData();
        }

        private void sbTareSetIlliquid_Click(object sender, EventArgs e)
        {
            var dlgDebtorsReturnedTareSetIlliquid = new DebtorsReturnedTareSetIlliquidForm { UserID = this.UserID };
            if (dlgDebtorsReturnedTareSetIlliquid.ShowDialog() == DialogResult.OK)
                this.ReloadData();
        }

        private void sbUndoLevel_Click(object sender, EventArgs e)
        {
            this.ChangeViewLevel(true, false);
        }

        #region ЭКСПОРТ ОТ

        private void sbExport_ButtonClick(object sender, EventArgs e)
        {
            sbExport.ShowDropDown();
        }

        private void miExportCurrentData_Click(object sender, EventArgs e)
        {
            this.ExportCurrentData();
        }

        private void ExportCurrentData()
        {
            using (SaveFileDialog dlgSelectFile = new SaveFileDialog())
            {
                dlgSelectFile.Title = "Экспорт оборотной тары (текущий)";

                DateTime now = DateTime.Now;
                dlgSelectFile.FileName = string.Format("{0}{1}{2}{3}{4}{5}-реестр оборотной тары (текущий)",
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
                var searchParameters = new TareGroupsViewSearchParameters();
                searchParameters.SessionID = this.UserID;

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    try
                    {
                        var dv = new TareGroupsByTypeView(TareGroupCondition.ByTypeStatusesBarcodes);

                        var sp = e.Argument as TareGroupsViewSearchParameters;
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
                        var dv = e.Result as TareGroupsByTypeView;

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

                        ExportHelper.ExportDataTableToExcel(dv.Data, lstTitles.ToArray(), lstColumnNames.ToArray(), "Экспорт оборотной тары (полный)", "реестр оборотной тары (полный)", true);
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

        private void miExportHistoryData_Click(object sender, EventArgs e)
        {
            this.ExportHistoryData();
        }

        private void ExportHistoryData()
        {
            try
            {
                var eticBarCode = this.xdgvItems.SelectedItem["Bar_code"].ToString();

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    try
                    {
                        Data.PickControl.CT_Tare_LogDataTable dtLog = null;

                        using (var adapter = new Data.PickControlTableAdapters.CT_Tare_LogTableAdapter())
                        {
                            adapter.SetTimeout((int)TimeSpan.FromMinutes(5).TotalMilliseconds);
                            dtLog = adapter.GetData(eticBarCode);
                        }

                        e.Result = dtLog;
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
                        var lstTitles = new List<string>();
                        var lstColumnNames = new List<string>();

                        var dtLog = e.Result as Data.PickControl.CT_Tare_LogDataTable;
                        foreach (DataColumn dc in dtLog.Columns)
                        {
                            //if (!dc.ColumnName.Equals(dtLog.история_ящикаColumn.ColumnName))
                            //{
                            lstTitles.Add(dc.Caption);
                            lstColumnNames.Add(dc.ColumnName);
                            //}
                        }

                        ExportHelper.ExportDataTableToExcel(dtLog, lstTitles.ToArray(), lstColumnNames.ToArray(), "Экспорт истории оборотной тары", "История оборотной тары", true);
                    }

                    splashForm.CloseForce();
                };

                splashForm.ActionText = "Выполняется экспорт данных";
                bw.RunWorkerAsync();
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        #endregion

        private void sbSetDublicate_Click(object sender, EventArgs e)
        {
            var dlgDebtorsReturnedTareSetDublicate = new DebtorsReturnedTareSetDublicateForm { UserID = this.UserID };
            if (dlgDebtorsReturnedTareSetDublicate.ShowDialog() == DialogResult.OK)
                this.ReloadData();
        }

        private void sbOpenInventoryManager_Click(object sender, EventArgs e)
        {
            var dlgDebtorsReturnedTareInventoryManager = new DebtorsReturnedTareInventoryManagerForm { UserID = this.UserID };
            if (dlgDebtorsReturnedTareInventoryManager.ShowDialog() == DialogResult.OK)
                this.ReloadData();
        }
    }

    /// <summary>
    /// Представление для оборотной тары
    /// </summary>
    [Obsolete]
    public class DebtorsReturnedTareView : IDataView
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

        /// <summary>
        /// Поиск конечной выборки согласно критериям
        /// </summary>
        /// <param name="searchParameters">Критерии поиска</param>
        public void FillData(SearchParametersBase searchParameters)
        {
            var searchCriteria = searchParameters as DebtorsReturnedTareViewSearchParameters;

            using (var adapter = new Data.PickControlTableAdapters.CT_TareEticsTableAdapter())
                this.data = adapter.GetData();
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ
        public DebtorsReturnedTareView()
        {
            this.dataColumns.Add(new PatternColumn("Ш/К", "Bar_code", new FilterPatternExpressionRule("Bar_code"), SummaryCalculationType.Count) { Width = 200 });
            this.dataColumns.Add(new PatternColumn("Тип тары", "Formatted_Tare_Name", new FilterPatternExpressionRule("Formatted_Tare_Name")) { Width = 300 });

            this.dataColumns.Add(new PatternColumn("Код товара", "Item_id", new FilterCompareExpressionRule<Int32>("Item_id"), SummaryCalculationType.Count) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Партия", "Lot_Number", new FilterPatternExpressionRule("Lot_Number")) { Width = 150 });

            this.dataColumns.Add(new PatternColumn("Дата создания", "Date_created", new FilterDateCompareExpressionRule("Date_created")) { Width = 150 });
            this.dataColumns.Add(new PatternColumn("Дата обновления", "Date_Updated", new FilterDateCompareExpressionRule("Date_Updated")) { Width = 150 });

            this.dataColumns.Add(new PatternColumn("Сотрудник", "Employee_Updated", new FilterPatternExpressionRule("Employee_Updated")) { Width = 300 });
            this.dataColumns.Add(new PatternColumn("Напечатано", "Count_Printed", new FilterCompareExpressionRule<Int32>("Count_Printed"), SummaryCalculationType.Sum) { Width = 100, UseIntegerNumbersAlignment = true });
        }
        #endregion
    }

    /// <summary>
    /// Критерий поиска
    /// </summary>
    [Obsolete]
    public class DebtorsReturnedTareViewSearchParameters : SessionIDSearchParameters
    {

    }

    /// <summary>
    /// Представление для оборотной тары
    /// </summary>
    public class TareGroupsByTypeView : IDataView
    {
        public TareGroupCondition TareGroupCondition { get; private set; }

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
            var searchCriteria = searchParameters as TareGroupsViewSearchParameters;

            var sessionID = searchCriteria.SessionID;
            var tareType = searchCriteria.TareType;
            var statusID = searchCriteria.StatusID;
            var barCode = searchCriteria.BarCode;
            var warehouseID = searchCriteria.WarehouseID;

            switch (this.TareGroupCondition)
            { 
                case TareGroupCondition.ByType:
                    using (var adapter = new Data.PickControlTableAdapters.CT_Tare_Groups_By_TypeTableAdapter())
                        this.data = adapter.GetData(sessionID);
                    break;
                case TareGroupCondition.ByTypeStatuses:
                    using (var adapter = new Data.PickControlTableAdapters.CT_Tare_Groups_By_Type_StatusesTableAdapter())
                        this.data = adapter.GetData(sessionID, tareType);
                    break;
                case TareGroupCondition.ByTypeStatusesBarcodes:
                    using (var adapter = new Data.PickControlTableAdapters.CT_Tare_Groups_By_Type_Statuses_BarcodesTableAdapter())
                        this.data = adapter.GetData(sessionID, tareType, statusID, barCode);
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ
        public TareGroupsByTypeView(TareGroupCondition tareGroupCondition)
        {
            switch ((this.TareGroupCondition = tareGroupCondition))
            {
                case TareGroupCondition.ByType:
                    this.dataColumns.Add(new PatternColumn("Склад", "warehouse_id", new FilterPatternExpressionRule("warehouse_id"), SummaryCalculationType.Count) { Width = 70 });

                    this.dataColumns.Add(new PatternColumn("Тип тары", "Formatted_Tare_Name", new FilterPatternExpressionRule("Formatted_Tare_Name"), SummaryCalculationType.Count) { Width = 250 });
                    this.dataColumns.Add(new PatternColumn("Количество", "qty", new FilterCompareExpressionRule<Int32>("qty"), SummaryCalculationType.Sum) { Width = 100, UseIntegerNumbersAlignment = true });
                    break;
                case TareGroupCondition.ByTypeStatuses:
                    this.dataColumns.Add(new PatternColumn("Склад", "warehouse_id", new FilterPatternExpressionRule("warehouse_id"), SummaryCalculationType.Count) { Width = 70 });

                    this.dataColumns.Add(new PatternColumn("Тип тары", "Formatted_Tare_Name", new FilterPatternExpressionRule("Formatted_Tare_Name"), SummaryCalculationType.Count) { Width = 250 });
                    
                    this.dataColumns.Add(new PatternColumn("Код статуса", "status_id", new FilterPatternExpressionRule("status_id"), SummaryCalculationType.Count) { Width = 100 });
                    this.dataColumns.Add(new PatternColumn("Описание статуса", "status_description", new FilterPatternExpressionRule("status_description"), SummaryCalculationType.Count) { Width = 200 });
                    
                    this.dataColumns.Add(new PatternColumn("Количество", "qty", new FilterCompareExpressionRule<Int32>("qty"), SummaryCalculationType.Sum) { Width = 100, UseIntegerNumbersAlignment = true });
                    break;
                case TareGroupCondition.ByTypeStatusesBarcodes:
                    this.dataColumns.Add(new PatternColumn("Склад", "warehouse_id", new FilterPatternExpressionRule("warehouse_id"), SummaryCalculationType.Count) { Width = 70 });

                    this.dataColumns.Add(new PatternColumn("Ш/К", "Bar_code", new FilterPatternExpressionRule("Bar_code"), SummaryCalculationType.Count) { Width = 150 });
                    this.dataColumns.Add(new PatternColumn("Тип тары", "Formatted_Tare_Name", new FilterPatternExpressionRule("Formatted_Tare_Name"), SummaryCalculationType.Count) { Width = 250 });

                    this.dataColumns.Add(new PatternColumn("Код товара", "Item_id", new FilterCompareExpressionRule<Int32>("Item_id"), SummaryCalculationType.Count) { Width = 100 });
                    this.dataColumns.Add(new PatternColumn("Партия", "Lot_Number", new FilterPatternExpressionRule("Lot_Number"), SummaryCalculationType.Count) { Width = 100 });

                    this.dataColumns.Add(new PatternColumn("Код статуса", "status_id", new FilterPatternExpressionRule("status_id"), SummaryCalculationType.Count) { Width = 100 });
                    this.dataColumns.Add(new PatternColumn("Описание статуса", "status_description", new FilterPatternExpressionRule("status_description"), SummaryCalculationType.Count) { Width = 200 });

                    this.dataColumns.Add(new PatternColumn("Дата создания", "Date_created", new FilterDateCompareExpressionRule("Date_created")) { Width = 120 });
                    this.dataColumns.Add(new PatternColumn("Дата обновления", "Date_Updated", new FilterDateCompareExpressionRule("Date_Updated")) { Width = 120 });

                    this.dataColumns.Add(new PatternColumn("Сотрудник", "Employee_Updated", new FilterPatternExpressionRule("Employee_Updated")) { Width = 250 });
                    this.dataColumns.Add(new PatternColumn("Напечатано", "Count_Printed", new FilterCompareExpressionRule<Int32>("Count_Printed"), SummaryCalculationType.Sum) { Width = 100, UseIntegerNumbersAlignment = true });
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
    public class TareGroupsViewSearchParameters : SessionIDSearchParameters
    {
        public string TareType { get; set; }
        public string StatusID { get; set; }
        public string BarCode { get; set; }
        public string WarehouseID { get; set; }
    }

    public enum TareGroupCondition
    { 
        ByType = 0,
        ByTypeStatuses = 1,
        ByTypeStatusesBarcodes = 2
    }
}
