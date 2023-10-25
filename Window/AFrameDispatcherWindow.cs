using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.ExtraDataGridViewComponents;

namespace WMSOffice.Window
{
    public partial class AFrameDispatcherWindow : GeneralWindow
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        public AFrameDispatcherWindow()
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
            #region ИНИЦИАЛИЗАЦИЯ ФИЛЬТРА СКЛАДА ОТБОРА

            stbWarehouseID.ValueReferenceQuery = "[dbo].[pr_AF_Get_MCU_From]";
            stbWarehouseID.UserID = this.UserID;
            stbWarehouseID.OnVerifyValue += (s, e) =>
            {
                lblWarehouseDesc.Text = e.Success ? e.Description : "СКЛАД НЕ НАЙДЕН";
                lblWarehouseDesc.ForeColor = e.Success ? Color.Blue : Color.Red;

                if (e.Success)
                {
                    stbWarehouseID.Value = e.Value;

                    //if (!string.IsNullOrEmpty(e.Value))
                    //    this.LoadData();
                }
            };
            stbWarehouseID.SetFirstValueByDefault();

            tsMain.Items.Insert(0, new ToolStripControlHost(pnlWarehouseFilter));

            #endregion

            #region ИНИЦИАЛИЗАЦИЯ ФИЛЬТРА ДАТЫ ОТБОРА

            //dtpOrderDate.ValueChanged += (s, e) => { this.LoadData(); };
            //dtpOrderDate.ValueChanged += (s, e) => { this.ApplyOrdersFilter(); }; 
            tsMain.Items.Insert(1, new ToolStripControlHost(pnlOrderDateFilter));

            #endregion


            #region ИНИЦИАЛИЗАЦИЯ ТАБЛИЦЫ ОСТАТКОВ

            xdgvRemains.AllowSummary = false;
            xdgvRemains.UseMultiSelectMode = false;

            xdgvRemains.SetSameStyleForAlternativeRows();

            xdgvRemains.Init(new AFrameRemainsView(), true);

            xdgvRemains.UserID = this.UserID;

            xdgvRemains.OnDataError += new DataGridViewDataErrorEventHandler(xdgv_OnDataError);
            xdgvRemains.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgv_OnFormattingCell);
            xdgvRemains.OnFilterChanged += new EventHandler(xdgv_OnFilterChanged);
            xdgvRemains.OnRowSelectionChanged += new EventHandler(xdgvRemains_OnRowSelectionChanged);

            // активация постраничного просмотра
            xdgvRemains.CreatePageNavigator();

            #endregion

            #region ИНИЦИАЛИЗАЦИЯ ТАБЛИЦЫ ФИКС. МЕСТ

            xdgvFixPlaces.AllowSummary = false;
            xdgvFixPlaces.UseMultiSelectMode = false;

            xdgvFixPlaces.SetSameStyleForAlternativeRows();

            xdgvFixPlaces.Init(new AFrameFixPlacesView(), true);

            xdgvFixPlaces.UserID = this.UserID;

            xdgvFixPlaces.OnDataError += new DataGridViewDataErrorEventHandler(xdgv_OnDataError);
            xdgvFixPlaces.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgv_OnFormattingCell);
            xdgvFixPlaces.OnFilterChanged += new EventHandler(xdgv_OnFilterChanged);

            // активация постраничного просмотра
            xdgvFixPlaces.CreatePageNavigator();

            #endregion

            #region ИНИЦИАЛИЗАЦИЯ ТАБЛИЦЫ ЗАКАЗОВ

            xdgvOrders.AllowSummary = false;
            xdgvOrders.UseMultiSelectMode = false;

            xdgvOrders.SetSameStyleForAlternativeRows();

            xdgvOrders.Init(new AFrameOrdersView(), true);

            xdgvOrders.UserID = this.UserID;

            xdgvOrders.OnDataError += new DataGridViewDataErrorEventHandler(xdgv_OnDataError);
            xdgvOrders.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgv_OnFormattingCell);
            xdgvOrders.OnFilterChanged += new EventHandler(xdgv_OnFilterChanged);
            xdgvOrders.OnRowSelectionChanged += new EventHandler(xdgvOrders_OnRowSelectionChanged);

            // активация постраничного просмотра
            xdgvOrders.CreatePageNavigator();

            #endregion
            
            #region ИНИЦИАЛИЗАЦИЯ ТАБЛИЦЫ СТРОК ЗАКАЗА

            xdgvOrderLines.AllowSummary = false;
            xdgvOrderLines.UseMultiSelectMode = false;

            xdgvOrderLines.SetSameStyleForAlternativeRows();

            xdgvOrderLines.Init(new AFrameOrderLinesView(), true);

            xdgvOrderLines.UserID = this.UserID;

            xdgvOrderLines.OnDataError += new DataGridViewDataErrorEventHandler(xdgv_OnDataError);
            xdgvOrderLines.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgv_OnFormattingCell);
            xdgvOrderLines.OnFilterChanged += new EventHandler(xdgv_OnFilterChanged);

            // активация постраничного просмотра
            xdgvOrderLines.CreatePageNavigator();

            #endregion


            #region ИНИЦИАЛИЗАЦИЯ ДОСТУПОВ

            this.InitializeTab();

            #endregion
           
            //this.LoadData();

            stbWarehouseID.Focus();
        }

        void xdgvRemains_OnRowSelectionChanged(object sender, EventArgs e)
        {
            var placeCode = xdgvRemains.SelectedItem == null ? (string)null : (xdgvRemains.SelectedItem as Data.WH.AF_RemainsRow).PlaceCode;
            this.LoadFixPlaces(placeCode);

            this.InitializeTabOperations();
        }

        void xdgvOrders_OnRowSelectionChanged(object sender, EventArgs e)
        {
            var orderNumber = xdgvOrders.SelectedItem == null ? (string)null : (xdgvOrders.SelectedItem as Data.WH.AF_OrdersRow).OrderNumber;
            this.LoadOrderLines(orderNumber);
        }

        void xdgv_OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        void xdgv_OnFilterChanged(object sender, EventArgs e)
        {
            var grid = sender as ExtraDataGridView;
            grid.RecalculateSummary();
        }

        void xdgv_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                    return;

                var grid = sender as DataGridView;

                var boundRow = (grid.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as DataRow;
                var color = Color.FromName(boundRow["Color"].ToString());

                grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = color;
                grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = color;
            }
            catch
            {

            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F5))
            {
                this.LoadData();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void LoadData()
        {
            if (tcViews.SelectedIndex == tcViews.TabPages.IndexOf(tpRemains))
                this.LoadRemains();
            else if (tcViews.SelectedIndex == tcViews.TabPages.IndexOf(tpOrders))
                this.LoadOrders();
        }

        private void LoadRemains()
        {
            try
            {
                var searchParams = new AFrameRemainsSearchParameters() { SessionID = this.UserID };

                if (string.IsNullOrEmpty(stbWarehouseID.Value))
                    throw new Exception("Необходимо указать склад.");
                else
                    searchParams.WarehouseID = stbWarehouseID.Value;

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    try
                    {
                        this.xdgvRemains.DataView.FillData(e.Argument as AFrameRemainsSearchParameters);
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
                        this.xdgvRemains.BindData(false);

                        //this.xdgvRemains.AllowFilter = true;
                        this.xdgvRemains.AllowSummary = true;
                    }

                    splashForm.CloseForce();
                };

                splashForm.ActionText = "Выполняется получение остатков..";
                bw.RunWorkerAsync(searchParams);
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
            finally
            {
                this.ApplyRemainsFilter();
            }
        }

        private void LoadFixPlaces(string placeCode)
        {
            try
            {
                var searchParams = new AFrameFixPlacesSearchParameters() { SessionID = this.UserID };

                if (string.IsNullOrEmpty(stbWarehouseID.Value))
                    throw new Exception("Необходимо указать склад.");
                else
                    searchParams.WarehouseID = stbWarehouseID.Value;

                searchParams.PlaceCode = placeCode;

                var splashForm = new WMSOffice.Dialogs.SplashForm();

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    try
                    {
                        this.xdgvFixPlaces.DataView.FillData(e.Argument as AFrameFixPlacesSearchParameters);
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
                        this.xdgvFixPlaces.BindData(false);

                        //this.xdgvFixPlaces.AllowFilter = true;
                        this.xdgvFixPlaces.AllowSummary = true;
                    }

                    splashForm.CloseForce();
                };

                splashForm.ActionText = "Выполняется получение фикс. мест..";
                bw.RunWorkerAsync(searchParams);
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
            finally
            {
                if (xdgvFixPlaces.DataGrid.Rows.Count > 0)
                    xdgvFixPlaces.DataGrid.Rows[0].Selected = false;
            }
        }

        private void LoadOrders()
        {
            try
            {
                var searchParams = new AFrameOrdersSearchParameters() { SessionID = this.UserID };

                if (string.IsNullOrEmpty(stbWarehouseID.Value))
                    throw new Exception("Необходимо указать склад.");
                else
                    searchParams.WarehouseID = stbWarehouseID.Value;

                searchParams.OrderDate = dtpOrderDate.Value;

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    try
                    {
                        this.xdgvOrders.DataView.FillData(e.Argument as AFrameOrdersSearchParameters);
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
                        this.xdgvOrders.BindData(false);

                        //this.xdgvOrders.AllowFilter = true;
                        this.xdgvOrders.AllowSummary = true;
                    }

                    splashForm.CloseForce();
                };

                splashForm.ActionText = "Выполняется получение заказов..";
                bw.RunWorkerAsync(searchParams);
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
            finally
            {
                this.ApplyOrdersFilter();
            }
        }

        private void LoadOrderLines(string orderNumber)
        {
            try
            {
                var searchParams = new AFrameOrderLinesSearchParameters() { SessionID = this.UserID };

                searchParams.OrderNumber = orderNumber;

                var splashForm = new WMSOffice.Dialogs.SplashForm();

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    try
                    {
                        this.xdgvOrderLines.DataView.FillData(e.Argument as AFrameOrderLinesSearchParameters);
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
                        this.xdgvOrderLines.BindData(false);

                        //this.xdgvOrderLines.AllowFilter = true;
                        this.xdgvOrderLines.AllowSummary = true;
                    }

                    splashForm.CloseForce();
                };

                splashForm.ActionText = "Выполняется получение строк заказа..";
                bw.RunWorkerAsync(searchParams);
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
            finally
            {
                if (xdgvOrderLines.DataGrid.Rows.Count > 0)
                    xdgvOrderLines.DataGrid.Rows[0].Selected = false;
            }
        }

        private void tcViews_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.InitializeTab();
        }

        private void InitializeTab()
        {
            this.InitializeTabFilters();
            this.InitializeTabOperations();
        }

        private void InitializeTabFilters()
        {
            pnlRemainsFilter.Visible = tcViews.SelectedIndex == tcViews.TabPages.IndexOf(tpRemains);
            pnlOrdersFilter.Visible = pnlOrderDateFilter.Visible = tcViews.SelectedIndex == tcViews.TabPages.IndexOf(tpOrders);

            pnlFilter.Height = (pnlRemainsFilter.Visible ? pnlRemainsFilter.Height : 0) + (pnlOrdersFilter.Visible ? pnlOrdersFilter.Height : 0);        
        }

        private void InitializeTabOperations()
        {
            btnAlignRemains.Visible = tssAlignRemains.Visible = tcViews.SelectedIndex == tcViews.TabPages.IndexOf(tpRemains);
            btnAlignRemains.Enabled = xdgvRemains.HasRows;
        }

        private void cbOnlyPositiveRemains_CheckedChanged(object sender, EventArgs e)
        {
            this.ApplyRemainsFilter();
        }

        private void cbOnlyRemainsWithDivergences_CheckedChanged(object sender, EventArgs e)
        {
            this.ApplyRemainsFilter();
        }

        private void ApplyRemainsFilter()
        {
            var onlyPositiveRemains = cbOnlyPositiveRemains.Checked;
            var onlyRemainsWithDivergences = cbOnlyRemainsWithDivergences.Checked;

            var filterStorage = xdgvRemains.GetFilterStorage();

            foreach (var filterItem in filterStorage)
                if (filterItem.DataFieldName == "OnlyPositiveRemains" || filterItem.DataFieldName == "OnlyRemainsWithDivergences")
                    filterItem.Value = string.Empty;

            if (onlyPositiveRemains)
                filterStorage.Add(new FilterItem("OnlyPositiveRemains", "1"));

            if (onlyRemainsWithDivergences)
                filterStorage.Add(new FilterItem("OnlyRemainsWithDivergences", "1"));

            xdgvRemains.ApplyFilter(filterStorage);
        }

        private void cbOnlyNotPickedOrders_CheckedChanged(object sender, EventArgs e)
        {
            this.ApplyOrdersFilter();
        }

        private void ApplyOrdersFilter()
        {
            var onlyNotPickedOrders = cbOnlyNotPickedOrders.Checked;

            var filterStorage = xdgvOrders.GetFilterStorage();

            foreach (var filterItem in filterStorage)
                if (filterItem.DataFieldName == "OnlyNotPickedOrders")
                    filterItem.Value = string.Empty;

            if (onlyNotPickedOrders)
                filterStorage.Add(new FilterItem("OnlyNotPickedOrders", "1"));

            //filterStorage.Add(new FilterItem("OrderDate", dtpOrderDate.Value.ToShortDateString()));

            xdgvOrders.ApplyFilter(filterStorage);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (tcViews.SelectedIndex == tcViews.TabPages.IndexOf(tpRemains))
                this.ExportRemains();
            else if (tcViews.SelectedIndex == tcViews.TabPages.IndexOf(tpOrders))
                this.ExportOrders();
        }

        private void ExportRemains()
        {
            try
            {
                xdgvRemains.ExportToExcel("Экспорт остатков A-Frame в Excel", "остатки A-Frame", true);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void ExportOrders()
        {
            try
            {
                xdgvOrders.ExportToExcel("Экспорт заказов A-Frame в Excel", "заказы A-Frame", true);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnAlignRemains_Click(object sender, EventArgs e)
        {
            this.AlignRemains();
        }

        private void AlignRemains()
        {
            try
            {
                if (MessageBox.Show("Вы действительно хотите выровнять остатки?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                    return;

                var warehouseID = (string)null;
                if (string.IsNullOrEmpty(stbWarehouseID.Value))
                    throw new Exception("Необходимо указать склад.");
                else
                    warehouseID = stbWarehouseID.Value;

                using (var adapter = new Data.WHTableAdapters.AF_RemainsTableAdapter())
                    adapter.AlignRemains(this.UserID, warehouseID);

                MessageBox.Show("Обновите остатки в течении ближайшей минуты.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }
    }

    /// <summary>
    /// Представление для остатков AFrame
    /// </summary>
    public class AFrameRemainsView : IDataView
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
            var searchCriteria = searchParameters as AFrameRemainsSearchParameters;

            var sessionID = searchCriteria.SessionID;
            var warehouseID = searchCriteria.WarehouseID;

            using (var adapter = new Data.WHTableAdapters.AF_RemainsTableAdapter())
            {
                adapter.SetTimeout(DEFAULT_RESPONSE_TIMEOUT);
                data = adapter.GetData(sessionID, warehouseID);
            }
        }

        #endregion

        public AFrameRemainsView()
        {
            this.dataColumns.Add(new PatternColumn("Место", "PlaceCode", new FilterPatternExpressionRule("PlaceCode"), SummaryCalculationType.Count) { Width = 120 });

            this.dataColumns.Add(new PatternColumn("Код", "ProductCode", new FilterCompareExpressionRule<Int32>("ProductCode"), SummaryCalculationType.Count) { Width = 70 });
            this.dataColumns.Add(new PatternColumn("Наименование товара", "ProductName", new FilterPatternExpressionRule("ProductName")) { Width = 300 });

            this.dataColumns.Add(new PatternColumn("Наличие в A-Frame", "ExistAF", new FilterCompareExpressionRule<Int32>("ExistAF"), SummaryCalculationType.Sum) { Width = 150, UseIntegerNumbersAlignment = true });
            this.dataColumns.Add(new PatternColumn("Наличие в JDE", "ExistJDE", new FilterCompareExpressionRule<Int32>("ExistJDE"), SummaryCalculationType.Sum) { Width = 150, UseIntegerNumbersAlignment = true });
            this.dataColumns.Add(new PatternColumn("Резерв в JDE", "ReserveJDE", new FilterCompareExpressionRule<Int32>("ReserveJDE"), SummaryCalculationType.Sum) { Width = 150, UseIntegerNumbersAlignment = true });

            this.dataColumns.Add(new PatternColumn("Только положительные остатки", "OnlyPositiveRemains", new FilterBoolCompareExpressionRule("OnlyPositiveRemains")) { Width = 150, Hidden = true });
            this.dataColumns.Add(new PatternColumn("Только остатки с расхождениями", "OnlyRemainsWithDivergences", new FilterBoolCompareExpressionRule("OnlyRemainsWithDivergences")) { Width = 150, Hidden = true });
        }
    }

    /// <summary>
    /// Критерий поиска
    /// </summary>
    public class AFrameRemainsSearchParameters : SessionIDSearchParameters
    {
        public string WarehouseID { get; set; }
    }


    /// <summary>
    /// Представление для фикс. мест AFrame
    /// </summary>
    public class AFrameFixPlacesView : IDataView
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
            var searchCriteria = searchParameters as AFrameFixPlacesSearchParameters;

            var sessionID = searchCriteria.SessionID;
            var warehouseID = searchCriteria.WarehouseID;
            var placeCode = searchCriteria.PlaceCode;

            using (var adapter = new Data.WHTableAdapters.AF_FixPlacesTableAdapter())
            {
                adapter.SetTimeout(DEFAULT_RESPONSE_TIMEOUT);
                data = adapter.GetData(sessionID, warehouseID, placeCode);
            }
        }

        #endregion

        public AFrameFixPlacesView()
        {
            //this.dataColumns.Add(new PatternColumn("Место", "PlaceCode", new FilterPatternExpressionRule("PlaceCode"), SummaryCalculationType.Count) { Width = 70 });
            
            this.dataColumns.Add(new PatternColumn("Код", "ProductCode", new FilterCompareExpressionRule<Int32>("ProductCode"), SummaryCalculationType.Count) { Width = 70 });
            this.dataColumns.Add(new PatternColumn("Наименование товара", "ProductName", new FilterPatternExpressionRule("ProductName")) { Width = 300 });

            this.dataColumns.Add(new PatternColumn("Вместимость канала в A-Frame", "Capacity", new FilterCompareExpressionRule<Int32>("Capacity"), SummaryCalculationType.Count) { Width = 145, UseIntegerNumbersAlignment = true });
            this.dataColumns.Add(new PatternColumn("Макс. кол-во пополнения в буфере", "MaxReplenishQty", new FilterCompareExpressionRule<Int32>("MaxReplenishQty"), SummaryCalculationType.Count) { Width = 145, UseIntegerNumbersAlignment = true });
            this.dataColumns.Add(new PatternColumn("Точка норм. пополнения в буфере ", "NormReplenishTreshold", new FilterCompareExpressionRule<Int32>("NormReplenishTreshold"), SummaryCalculationType.Count) { Width = 145, UseIntegerNumbersAlignment = true });
            this.dataColumns.Add(new PatternColumn("Точка мин. пополнения в буфере", "MinReplenishTreshold", new FilterCompareExpressionRule<Int32>("MinReplenishTreshold"), SummaryCalculationType.Count) { Width = 145, UseIntegerNumbersAlignment = true }); // 210

            this.dataColumns.Add(new PatternColumn("Статус\nфикс. места", "StatusName", new FilterPatternExpressionRule("StatusName"), SummaryCalculationType.Count) { Width = 130 });
        }
    }

    /// <summary>
    /// Критерий поиска
    /// </summary>
    public class AFrameFixPlacesSearchParameters : SessionIDSearchParameters
    {
        public string WarehouseID { get; set; }
        public string PlaceCode { get; set; }
    }


    /// <summary>
    /// Представление для заказов AFrame
    /// </summary>
    public class AFrameOrdersView : IDataView
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
            var searchCriteria = searchParameters as AFrameOrdersSearchParameters;

            var sessionID = searchCriteria.SessionID;
            var warehouseID = searchCriteria.WarehouseID;
            var orderDate = searchCriteria.OrderDate;

            using (var adapter = new Data.WHTableAdapters.AF_OrdersTableAdapter())
            {
                adapter.SetTimeout(DEFAULT_RESPONSE_TIMEOUT);
                data = adapter.GetData(sessionID, warehouseID, orderDate);
            }
        }

        #endregion

        public AFrameOrdersView()
        {
            this.dataColumns.Add(new PatternColumn("Дата заказа", "OrderDate", new FilterDateCompareExpressionRule("OrderDate")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("№ заказа", "OrderNumber", new FilterPatternExpressionRule("OrderNumber"), SummaryCalculationType.Count) { Width = 100 });

            this.dataColumns.Add(new PatternColumn("№ СЛ", "PickSlipNumber", new FilterCompareExpressionRule<Int64>("PickSlipNumber"), SummaryCalculationType.Count) { Width = 70 });
            this.dataColumns.Add(new PatternColumn("Статус", "OrderStatus", new FilterPatternExpressionRule("OrderStatus"), SummaryCalculationType.Count) { Width = 70 });

            this.dataColumns.Add(new PatternColumn("№ контейнера", "ContainerNumber", new FilterPatternExpressionRule("ContainerNumber"), SummaryCalculationType.Count) { Width = 110 });
            this.dataColumns.Add(new PatternColumn("Тип контейнера", "ContainerType", new FilterPatternExpressionRule("ContainerType"), SummaryCalculationType.Count) { Width = 120 });

            this.dataColumns.Add(new PatternColumn("Дата окончания сборки", "DateModif", new FilterDateCompareExpressionRule("DateModif"), SummaryCalculationType.Count) { Width = 160 });
            this.dataColumns.Add(new PatternColumn("Примечание строки", "LineDsc", new FilterPatternExpressionRule("LineDsc"), SummaryCalculationType.None) { Width = 160 });

            this.dataColumns.Add(new PatternColumn("Только несобранные заказы", "OnlyNotPickedOrders", new FilterBoolCompareExpressionRule("OnlyNotPickedOrders")) { Width = 150, Hidden = true });
        }
    }

    /// <summary>
    /// Критерий поиска
    /// </summary>
    public class AFrameOrdersSearchParameters : SessionIDSearchParameters
    {
        public string WarehouseID { get; set; }
        public DateTime OrderDate { get; set; }
    }


    /// <summary>
    /// Представление для строк заказа AFrame
    /// </summary>
    public class AFrameOrderLinesView : IDataView
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
            var searchCriteria = searchParameters as AFrameOrderLinesSearchParameters;

            var sessionID = searchCriteria.SessionID;
            var orderNumber = searchCriteria.OrderNumber;

            using (var adapter = new Data.WHTableAdapters.AF_Order_LinesTableAdapter())
            {
                adapter.SetTimeout(DEFAULT_RESPONSE_TIMEOUT);
                data = adapter.GetData(sessionID, orderNumber);
            }
        }

        #endregion

        public AFrameOrderLinesView()
        {
            //this.dataColumns.Add(new PatternColumn("№ заказа", "OrderNumber", new FilterPatternExpressionRule("OrderNumber"), SummaryCalculationType.Count) { Width = 100 });

            this.dataColumns.Add(new PatternColumn("Код", "ProductCode", new FilterCompareExpressionRule<Int32>("ProductCode"), SummaryCalculationType.Count) { Width = 70 });
            this.dataColumns.Add(new PatternColumn("Наименование товара", "ProductName", new FilterPatternExpressionRule("ProductName")) { Width = 300 });

            this.dataColumns.Add(new PatternColumn("Вес штуки, г", "WeightItem", new FilterCompareExpressionRule<Double>("WeightItem")) { Width = 100, /*UseDecimalNumbersAlignment = true,*/ Format = "N3" });
            this.dataColumns.Add(new PatternColumn("Место отбора", "PlaceCode", new FilterPatternExpressionRule("PlaceCode"), SummaryCalculationType.Count) { Width = 120 });

            this.dataColumns.Add(new PatternColumn("Количество\nв заказе", "OrderedQty", new FilterCompareExpressionRule<Int32>("OrderedQty"), SummaryCalculationType.Sum) { Width = 145, UseIntegerNumbersAlignment = true });
            this.dataColumns.Add(new PatternColumn("Количество\nсобрано", "PickedQty", new FilterCompareExpressionRule<Int32>("PickedQty"), SummaryCalculationType.Sum) { Width = 145, UseIntegerNumbersAlignment = true });

            this.dataColumns.Add(new PatternColumn("Статус\nстроки", "LineStatus", new FilterPatternExpressionRule("LineStatus"), SummaryCalculationType.Count) { Width = 130 });
            this.dataColumns.Add(new PatternColumn("Примечание", "Note", new FilterPatternExpressionRule("Note")) { Width = 170 });
        }
    }

    /// <summary>
    /// Критерий поиска
    /// </summary>
    public class AFrameOrderLinesSearchParameters : SessionIDSearchParameters
    {
        public string OrderNumber { get; set; }
    }
}
