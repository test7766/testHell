using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.ExtraDataGridViewComponents;

namespace WMSOffice.Dialogs.Quality
{
    public partial class QualityGLSActRemainsForm : DialogForm
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        public int DocID { get; private set; }

        public QualityGLSActRemainsForm()
        {
            InitializeComponent();
        }

        public QualityGLSActRemainsForm(int docID)
            : this()
        {
            this.DocID = docID;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Text = string.Format("{0} по акту розпоряджень № {1}", this.Text, this.DocID);

            this.btnOK.Location = new Point(1317, 8);
            this.btnCancel.Location = new Point(1407, 8);

            this.WindowState = FormWindowState.Maximized;

            this.Initialize();
        }

        private void Initialize()
        {
            xdgvWarehouseRemains.AllowSummary = false;
            xdgvWarehouseRemains.AllowRangeColumns = true;

            xdgvWarehouseRemains.UseMultiSelectMode = false;

            xdgvWarehouseRemains.Init(new QualityGLSActWarehouseRemainsView(), true);

            xdgvWarehouseRemains.UserID = this.UserID;

            xdgvWarehouseRemains.OnDataError += new DataGridViewDataErrorEventHandler(xdgvWarehouseRemains_OnDataError);
            xdgvWarehouseRemains.OnFilterChanged += new EventHandler(xdgvWarehouseRemains_OnFilterChanged);

            // активация постраничного просмотра
            xdgvWarehouseRemains.CreatePageNavigator();



            xdgvDebtorRemains.AllowSummary = false;
            xdgvDebtorRemains.AllowRangeColumns = true;

            xdgvDebtorRemains.UseMultiSelectMode = false;

            xdgvDebtorRemains.Init(new QualityGLSActDebtorRemainsView(), true);

            xdgvDebtorRemains.UserID = this.UserID;

            xdgvDebtorRemains.OnDataError += new DataGridViewDataErrorEventHandler(xdgvDebtorRemains_OnDataError);
            xdgvDebtorRemains.OnFilterChanged += new EventHandler(xdgvDebtorRemains_OnFilterChanged);

            // активация постраничного просмотра
            xdgvDebtorRemains.CreatePageNavigator();


            LoadRemains();
        }

        void xdgvWarehouseRemains_OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        void xdgvWarehouseRemains_OnFilterChanged(object sender, EventArgs e)
        {
            xdgvWarehouseRemains.RecalculateSummary();
        }


        void xdgvDebtorRemains_OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        void xdgvDebtorRemains_OnFilterChanged(object sender, EventArgs e)
        {
            xdgvDebtorRemains.RecalculateSummary();
        }

        private void LoadRemains()
        {
            this.LoadWarehouseRemains();
            this.LoadDebtorRemains();
        }

        private void LoadWarehouseRemains()
        {
            try
            {
                var searchParams = new QualityGLSActWarehouseRemainsSearchParameters() { SessionID = this.UserID, DocID = this.DocID };

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    try
                    {
                        this.xdgvWarehouseRemains.DataView.FillData(e.Argument as QualityGLSActWarehouseRemainsSearchParameters);
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                bw.RunWorkerCompleted += (s, e) =>
                {
                    if (e.Result is Exception)
                        MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        this.xdgvWarehouseRemains.BindData(false);

                        //this.xdgvWarehouseRemains.AllowFilter = true;
                        this.xdgvWarehouseRemains.AllowSummary = true;
                    }

                    splashForm.CloseForce();
                };

                splashForm.ActionText = "Выполняется получение складских остатков..";
                bw.RunWorkerAsync(searchParams);
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDebtorRemains()
        {
            try
            {
                var searchParams = new QualityGLSActDebtorRemainsSearchParameters() { SessionID = this.UserID, DocID = this.DocID };

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    try
                    {
                        this.xdgvDebtorRemains.DataView.FillData(e.Argument as QualityGLSActDebtorRemainsSearchParameters);
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                bw.RunWorkerCompleted += (s, e) =>
                {
                    if (e.Result is Exception)
                        MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        this.xdgvDebtorRemains.BindData(false);

                        //this.xdgvDebtorRemains.AllowFilter = true;
                        this.xdgvDebtorRemains.AllowSummary = true;
                    }

                    splashForm.CloseForce();
                };

                splashForm.ActionText = "Выполняется получение клиентских остатков..";
                bw.RunWorkerAsync(searchParams);
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    /// <summary>
    /// Представление для складских остатков по акту ГЛС
    /// </summary>
    public class QualityGLSActWarehouseRemainsView : IDataView
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
            var searchCriteria = searchParameters as QualityGLSActWarehouseRemainsSearchParameters;

            var sessionID = searchCriteria.SessionID;
            var docID = searchCriteria.DocID;

            using (var adapter = new Data.ComplaintsTableAdapters.GA_Doc_RemainsTableAdapter())
            {
                //adapter.SetTimeout(DEFAULT_RESPONSE_TIMEOUT);
                data = adapter.GetData(docID);
            }
        }

        #endregion

        public QualityGLSActWarehouseRemainsView()
        {
            this.dataColumns.Add(new PatternColumn("Склад", "Warehouse_ID", new FilterPatternExpressionRule("Warehouse_ID"), SummaryCalculationType.Count) { Width = 70 });

            this.dataColumns.Add(new PatternColumn("Код товара", "Item_ID", new FilterCompareExpressionRule<Int32>("Item_ID"), SummaryCalculationType.Count) { Width = 90 });
            this.dataColumns.Add(new PatternColumn("Назва товара", "Item_Name", new FilterPatternExpressionRule("Item_Name")) { Width = 200 });

            this.dataColumns.Add(new PatternColumn("Серія", "Batch_ID", new FilterPatternExpressionRule("Batch_ID"), SummaryCalculationType.Count) { Width = 120 });
            this.dataColumns.Add(new PatternColumn("Термін придатності", "EXP_Date", new FilterDateCompareExpressionRule("EXP_Date")) { Width = 120 });

            this.dataColumns.Add(new PatternColumn("Місце", "Location_ID", new FilterPatternExpressionRule("Location_ID"), SummaryCalculationType.Count) { Width = 120 });
            this.dataColumns.Add(new PatternColumn("Партія", "Lot_Number", new FilterPatternExpressionRule("Lot_Number"), SummaryCalculationType.Count) { Width = 120 });

            this.dataColumns.Add(new PatternColumn("Блок", "Hold_ID", new FilterPatternExpressionRule("Hold_ID"), SummaryCalculationType.Count) { Width = 80 });
            this.dataColumns.Add(new PatternColumn("Опис блоку", "Hold_descr", new FilterPatternExpressionRule("Hold_descr"), SummaryCalculationType.Count) { Width = 150 });

            this.dataColumns.Add(new PatternColumn("Залишок", "Qty_on_hand", new FilterCompareExpressionRule<Int32>("Qty_on_hand"), SummaryCalculationType.Sum) { Width = 140, UseIntegerNumbersAlignment = true });
            this.dataColumns.Add(new PatternColumn("Доступний залишок", "Qty_available", new FilterCompareExpressionRule<Int32>("Qty_available"), SummaryCalculationType.Sum) { Width = 140, UseIntegerNumbersAlignment = true });
            this.dataColumns.Add(new PatternColumn("Жорсткий резерв", "Qty_committed", new FilterCompareExpressionRule<Int32>("Qty_committed"), SummaryCalculationType.Sum) { Width = 140, UseIntegerNumbersAlignment = true });
            this.dataColumns.Add(new PatternColumn("В надходженні", "Qty_income", new FilterCompareExpressionRule<Int32>("Qty_income"), SummaryCalculationType.Sum) { Width = 140, UseIntegerNumbersAlignment = true });
        }
    }

    /// <summary>
    /// Критерий поиска
    /// </summary>
    public class QualityGLSActWarehouseRemainsSearchParameters : SessionIDSearchParameters
    {
        public int DocID { get; set; } 
    }


    /// <summary>
    /// Представление для клиентских остатков по акту ГЛС
    /// </summary>
    public class QualityGLSActDebtorRemainsView : IDataView
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
            var searchCriteria = searchParameters as QualityGLSActDebtorRemainsSearchParameters;

            var sessionID = searchCriteria.SessionID;
            var docID = searchCriteria.DocID;

            using (var adapter = new Data.ComplaintsTableAdapters.GA_Return_RemainsTableAdapter())
            {
                //adapter.SetTimeout(DEFAULT_RESPONSE_TIMEOUT);
                data = adapter.GetData(docID);
            }
        }

        #endregion

        public QualityGLSActDebtorRemainsView()
        {
            this.dataColumns.Add(new PatternColumn("Тип возврата", "Doc_Type_Name", new FilterPatternExpressionRule("Doc_Type_Name"), SummaryCalculationType.Count) { Width = 150 });
            this.dataColumns.Add(new PatternColumn("Склад", "Warehouse_ID", new FilterPatternExpressionRule("Warehouse_ID"), SummaryCalculationType.Count) { Width = 70 });

            this.dataColumns.Add(new PatternColumn("Код товара", "Item_ID", new FilterCompareExpressionRule<Int32>("Item_ID"), SummaryCalculationType.Count) { Width = 90 });
            this.dataColumns.Add(new PatternColumn("Назва товара", "Item_Name", new FilterPatternExpressionRule("Item_Name")) { Width = 200 });

            this.dataColumns.Add(new PatternColumn("Серія", "Batch_ID", new FilterPatternExpressionRule("Batch_ID"), SummaryCalculationType.Count) { Width = 120 });
            this.dataColumns.Add(new PatternColumn("Термін придатності", "EXP_Date", new FilterDateCompareExpressionRule("EXP_Date")) { Width = 120 });
            this.dataColumns.Add(new PatternColumn("Кількість", "Quantity", new FilterCompareExpressionRule<Int32>("Quantity"), SummaryCalculationType.Sum) { Width = 100, UseIntegerNumbersAlignment = true });
        }
    }

    /// <summary>
    /// Критерий поиска
    /// </summary>
    public class QualityGLSActDebtorRemainsSearchParameters : SessionIDSearchParameters
    {
        public int DocID { get; set; }
    }
}
