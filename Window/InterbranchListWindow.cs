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
    public partial class InterbranchListWindow : GeneralWindow
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        public InterbranchListWindow()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            Initialize();
        }

        private void Initialize()
        {
            #region ИНИЦИАЛИЗАЦИЯ ФИЛЬТРА СКЛАДОВ-ОТПРАВИТЕЛЕЙ

            stbWarehouseID.ValueReferenceQuery = "[dbo].[pr_IB_Get_Available_Warehouses]";
            stbWarehouseID.UserID = this.UserID;
            stbWarehouseID.OnVerifyValue += (s, e) =>
            {
                lblWarehouseDesc.Text = e.Success ? e.Description : "СКЛАД НЕ НАЙДЕН";
                lblWarehouseDesc.ForeColor = e.Success ? Color.Blue : Color.Red;

                if (e.Success)
                    stbWarehouseID.Value = e.Value;
            };
            stbWarehouseID.SetFirstValueByDefault();

            tsMain.Items.Insert(0, new ToolStripControlHost(pnlWarehouseFilter));

            #endregion

            xdgvBranches.LoadExtraDataGridViewSettings(this.Name);

            xdgvBranches.AllowSummary = false;
            xdgvBranches.UseMultiSelectMode = true;

            xdgvBranches.Init(new InterbranchListView(), true);

            xdgvBranches.UserID = this.UserID;

            xdgvBranches.OnDataError += new DataGridViewDataErrorEventHandler(xdgvBranches_OnDataError);
            xdgvBranches.OnRowSelectionChanged += new EventHandler(xdgvBranches_OnRowSelectionChanged);
            xdgvBranches.OnFilterChanged += new EventHandler(xdgvBranches_OnFilterChanged);

            SetOperationAccess();

            RefreshFilials();
            
            stbWarehouseID.Focus();
        }

        void xdgvBranches_OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        void xdgvBranches_OnFilterChanged(object sender, EventArgs e)
        {
            SetOperationAccess();
            xdgvBranches.RecalculateSummary();
        }

        void xdgvBranches_OnRowSelectionChanged(object sender, EventArgs e)
        {
            try
            {
                SetOperationAccess();

                if (xdgvBranches.SelectedItems.Count == 1)
                {
                    Data.Interbranch.ReportByFilialRow row = (Data.Interbranch.ReportByFilialRow)(xdgvBranches.SelectedItems[0]);
                    var filialID = Convert.ToInt32(row.IsFilial_IDNull() ? 0 : row.Filial_ID);
                    var warehouseFrom = row.IsMCU_FNull() ? (string)null : row.MCU_F;
                    
                    var filialFilter = stbWarehouseID.Value;

                    RefreshOrders(filialID, row.OrderDate, warehouseFrom, filialFilter);
                }
                else
                    ClearOrders();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void SetOperationAccess()
        {
            btnExportToExcel.Enabled = xdgvBranches.HasRows;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshFilials();
        }

        private void RefreshFilials()
        {
            ClearOrders();

            try
            {
                var searchParams = new InterbranchListSearchParameters() { SessionID = this.UserID };
                searchParams.WarehouseID = stbWarehouseID.Value;

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    this.xdgvBranches.DataView.FillData(e.Argument as InterbranchListSearchParameters);
                };
                bw.RunWorkerCompleted += (s, e) =>
                {
                    if (e.Result is Exception)
                        this.ShowError(e.Result as Exception);
                    else
                    {
                        this.xdgvBranches.BindData(false);

                        //this.xdgvBranches.AllowFilter = true;
                        this.xdgvBranches.AllowSummary = true;
                    }

                    splashForm.CloseForce();
                };

                splashForm.ActionText = "Выполняется получение списка м/с..";
                bw.RunWorkerAsync(searchParams);
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F5))
            {
                this.RefreshFilials();
                return true;
            }

            if (keyData == (Keys.F6))
            {
                this.ExportToExcel();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void RefreshOrders(int shipTo, DateTime orderDate, string warehouseFrom, string filialFilter)
        {
            ClearItems();
            try
            {
                this.reportByOrderTableAdapter.Fill(this.interbranch.ReportByOrder, shipTo, orderDate, warehouseFrom, filialFilter);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void ClearOrders()
        {
            ClearItems();
            this.interbranch.ReportByOrder.Clear();
        }

        private void gvPicks_SelectionChanged(object sender, EventArgs e)
        {
            if (gvPicks.SelectedRows.Count == 1)
            {
                Data.Interbranch.ReportByOrderRow row = (Data.Interbranch.ReportByOrderRow)((DataRowView)gvPicks.SelectedRows[0].DataBoundItem).Row;
                RefreshItems(row.OrderID, row.OrderType, row.PickSlip);
            }
            else
                ClearItems();
        }

        private void RefreshItems(double orderID, string orderType, double pickSlip)
        {
            try
            {
                this.reportByItmTableAdapter.Fill(this.interbranch.ReportByItm, orderID, orderType, pickSlip);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void ClearItems()
        {
            this.interbranch.ReportByItm.Clear();
        }

        private void InterbranchListWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            xdgvBranches.SaveExtraDataGridViewSettings(this.Name);
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        private void ExportToExcel()
        {
            try
            {
                this.xdgvBranches.ExportToExcel("Экспорт списка м/с", "Список МС", true);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        /// <summary>
        /// Представление для списка м/с
        /// </summary>
        public class InterbranchListView : IDataView
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
                var searchCriteria = searchParameters as InterbranchListSearchParameters;

                using (var adapter = new Data.InterbranchTableAdapters.ReportByFilialTableAdapter())
                    this.data = adapter.GetData(searchCriteria.SessionID, searchCriteria.WarehouseID);
            }

            #endregion

            #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ
            public InterbranchListView()
            {
                this.dataColumns.Add(new PatternColumn("Филиал - получатель", "Filial", new FilterPatternExpressionRule("Filial")) { Width = 235 });
                this.dataColumns.Add(new PatternColumn("Дата", "OrderDate", new FilterDateCompareExpressionRule("OrderDate")) { Width = 70 });
                this.dataColumns.Add(new PatternColumn("Плановый объем, м³", "Volume_Plan", new FilterCompareExpressionRule<Decimal>("Volume_Plan"), SummaryCalculationType.Sum) { Width = 70, UseDecimalNumbersAlignment = true });
                //this.dataColumns.Add(new PatternColumn("\"Ручные\" межсклады до 540 статуса, объем, м³", "Volume_Man_b540", new FilterCompareExpressionRule<Decimal>("Volume_Man_b540"), SummaryCalculationType.Sum) { Width = 160, UseDecimalNumbersAlignment = true });
                //this.dataColumns.Add(new PatternColumn("\"Ручные\" межсклады после 540 статуса, объем, м³", "Volume_Man", new FilterCompareExpressionRule<Decimal>("Volume_Man"), SummaryCalculationType.Sum) { Width = 175, UseDecimalNumbersAlignment = true });
                this.dataColumns.Add(new PatternColumn("Остаток брутто на 562 и 571 статусе, м³", "Volume_rem_562", new FilterCompareExpressionRule<Decimal>("Volume_rem_562"), SummaryCalculationType.Sum) { Width = 140, UseDecimalNumbersAlignment = true });
                this.dataColumns.Add(new PatternColumn("Кросс-доки, объем, м³", "Volume_CD", new FilterCompareExpressionRule<Decimal>("Volume_CD"), SummaryCalculationType.Sum) { Width = 70, UseDecimalNumbersAlignment = true });
                this.dataColumns.Add(new PatternColumn("Объем дроби, м³", "Volume_fr", new FilterCompareExpressionRule<Decimal>("Volume_fr"), SummaryCalculationType.Sum) { Width = 65, UseDecimalNumbersAlignment = true });
                this.dataColumns.Add(new PatternColumn("Итого, объем, м³", "Volume", new FilterCompareExpressionRule<Decimal>("Volume"), SummaryCalculationType.Sum) { Width = 65, UseDecimalNumbersAlignment = true });
                this.dataColumns.Add(new PatternColumn("Итого объем брутто, м³", "Volume_Brutto", new FilterCompareExpressionRule<Decimal>("Volume_Brutto"), SummaryCalculationType.Sum) { Width = 100, UseDecimalNumbersAlignment = true });
                this.dataColumns.Add(new PatternColumn("Плановый объем кросс-док с ПО, м³", "Volume_MSCD", new FilterCompareExpressionRule<Decimal>("Volume_MSCD"), SummaryCalculationType.Sum) { Width = 130, UseDecimalNumbersAlignment = true });
                this.dataColumns.Add(new PatternColumn("Плановый объем кросс-док с ПО брутто, м³", "Volume_MSCD_Gross", new FilterCompareExpressionRule<Decimal>("Volume_MSCD_Gross"), SummaryCalculationType.Sum) { Width = 165, UseDecimalNumbersAlignment = true });
                this.dataColumns.Add(new PatternColumn("Объем с 28LA1, м³", "Volume_Plan28", new FilterCompareExpressionRule<Decimal>("Volume_Plan28"), SummaryCalculationType.Sum) { Width = 80, UseDecimalNumbersAlignment = true });
                this.dataColumns.Add(new PatternColumn("Заказать объем, м³", "Order_Volume", new FilterCompareExpressionRule<Decimal>("Order_Volume"), SummaryCalculationType.Sum) { Width = 70, UseDecimalNumbersAlignment = true });
                this.dataColumns.Add(new PatternColumn("Объем с 10LA1, м³", "Volume_Plan10", new FilterCompareExpressionRule<Decimal>("Volume_Plan10"), SummaryCalculationType.Sum) { Width = 80, UseDecimalNumbersAlignment = true });
                this.dataColumns.Add(new PatternColumn("Лимит, м³", "V_Limit", new FilterCompareExpressionRule<Decimal>("V_Limit"), SummaryCalculationType.Sum) { Width = 82, UseDecimalNumbersAlignment = true });
                this.dataColumns.Add(new PatternColumn("Остаток объема плана, м³", "Volume_Plan_bd", new FilterCompareExpressionRule<Decimal>("Volume_Plan_bd"), SummaryCalculationType.Sum) { Width = 120, UseDecimalNumbersAlignment = true });
                this.dataColumns.Add(new PatternColumn("Остаток объема итого, м³", "Volume_bd", new FilterCompareExpressionRule<Decimal>("Volume_bd"), SummaryCalculationType.Sum) { Width = 120, UseDecimalNumbersAlignment = true });
                this.dataColumns.Add(new PatternColumn("Остаток объема дроби, м³", "Volume_bd_fr", new FilterCompareExpressionRule<Decimal>("Volume_bd_fr"), SummaryCalculationType.Sum) { Width = 120, UseDecimalNumbersAlignment = true });
                this.dataColumns.Add(new PatternColumn("Склад - отправитель", "MCU_From_Name", new FilterPatternExpressionRule("MCU_From_Name")) { Width = 235 });
            }
            #endregion
        }

        /// <summary>
        /// Критерий поиска
        /// </summary>
        public class InterbranchListSearchParameters : SessionIDSearchParameters
        {
            public string WarehouseID { get; set; }
        }
    }
}
