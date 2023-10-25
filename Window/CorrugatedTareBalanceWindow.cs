using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs.Containers;
using WMSOffice.Controls.ExtraDataGridViewComponents;

namespace WMSOffice.Window
{
    public partial class CorrugatedTareBalanceWindow : GeneralWindow
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных
        /// </summary>
        private Dialogs.SplashForm waitProgressForm = new WMSOffice.Dialogs.SplashForm();

        public CorrugatedTareBalanceWindow()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Initialize();

            if (!this.FindTare())
                this.Close();
        }

        private void Initialize()
        {
            this.xdgvTareBalance.Init(new CorrugatedTareBalanceView(), true);

            this.xdgvTareBalance.AllowSummary = false;
            this.xdgvTareBalance.UserID = this.UserID;

            this.xdgvTareBalance.OnDataError += (s, e) => { e.ThrowException = false; };
            this.xdgvTareBalance.OnFilterChanged += (s, e) => { this.xdgvTareBalance.RecalculateSummary(); };
        }

        private void btnReloadData_Click(object sender, EventArgs e)
        {
            this.ReloadData();
        }

        private void btnFindTare_Click(object sender, EventArgs e)
        {
            this.FindTare();
        }

        private bool FindTare()
        {
            var frmCorrugatedTareSearchParametersSet = new CorrugatedTareSearchParametersSetForm() { UserID = this.UserID };
            if (frmCorrugatedTareSearchParametersSet.ShowDialog() == DialogResult.OK)
            {
                this.ReloadData();
                return true;
            }

            return false;
        }

        private void ReloadData()
        {
            try
            {
                var searchParameters = CorrugatedTareSearchParametersSetForm.SearchParameters;
                searchParameters.SessionID = this.UserID;

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    try
                    {
                        this.xdgvTareBalance.DataView.FillData(searchParameters);
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
                        this.xdgvTareBalance.BindData(false);

                        //this.xdgvTareBalance.AllowFilter = true;
                        this.xdgvTareBalance.AllowSummary = true;
                    }

                    waitProgressForm.CloseForce();
                };
                waitProgressForm.ActionText = "Выполняется загрузка данных..";
                bw.RunWorkerAsync();
                waitProgressForm.ShowDialog();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.xdgvTareBalance.HasRows)
                    throw new Exception("Отсутствуют данные для экспорта.");

                var searchCriteria = CorrugatedTareSearchParametersSetForm.SearchParameters;
                var warehouseID = searchCriteria.WarehouseID;
                var periodFrom = searchCriteria.PeriodFrom;
                var periodTo = searchCriteria.PeriodTo;
                this.xdgvTareBalance.ExportToExcel("Экспорт в Excel", string.Format("Учет гофротары {0}-{1}-{2}", warehouseID.Trim(), periodFrom.Value.ToString("yyyyMMdd"), periodTo.Value.ToString("yyyyMMdd")), true);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }
    }

    /// <summary>
    /// Представление для учета гофротары
    /// </summary>
    public class CorrugatedTareBalanceView : IDataView
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
            var searchCriteria = searchParameters as CorrugatedTareBalanceSearchParameters;

            var sessionID = searchCriteria.SessionID;
            var warehouseID = searchCriteria.WarehouseID;
            var periodFrom = searchCriteria.PeriodFrom;
            var periodTo = searchCriteria.PeriodTo;

            using (var adapter = new Data.ContainersTableAdapters.CorrugatedTareRemainsTableAdapter())
            {
                adapter.SetTimeout(DEFAULT_RESPONSE_TIMEOUT);
                data = adapter.GetData(warehouseID, periodFrom, periodTo, sessionID);
            }
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ
        public CorrugatedTareBalanceView()
        {
            this.dataColumns.Add(new PatternColumn("Код", "WarehouseID", new FilterCompareExpressionRule<Int32>("WarehouseID"), SummaryCalculationType.Count) { Width = 60 });
            this.dataColumns.Add(new PatternColumn("Название склада", "WarehouseName", new FilterPatternExpressionRule("WarehouseName")) { Width = 150 });
            this.dataColumns.Add(new PatternColumn("Код", "ItemID", new FilterCompareExpressionRule<Int32>("ItemID"), SummaryCalculationType.Count) { Width = 60 });
            this.dataColumns.Add(new PatternColumn("Наименование товара", "ItemName", new FilterPatternExpressionRule("ItemName")) { Width = 350 });
            this.dataColumns.Add(new PatternColumn("Период", "DateName", new FilterDateCompareExpressionRule("DateName"), SummaryCalculationType.Count) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Остаток на начало", "FirstRemains", new FilterCompareExpressionRule<Int32>("FirstRemains"), SummaryCalculationType.Sum) { Width = 130, UseIntegerNumbersAlignment = true });
            this.dataColumns.Add(new PatternColumn("Приход", "CM", new FilterCompareExpressionRule<Int32>("CM"), SummaryCalculationType.Sum) { Width = 130, UseIntegerNumbersAlignment = true });
            this.dataColumns.Add(new PatternColumn("Расход", "FL", new FilterCompareExpressionRule<Int32>("FL"), SummaryCalculationType.Sum) { Width = 130, UseIntegerNumbersAlignment = true });
            this.dataColumns.Add(new PatternColumn("Остаток на конец", "LastRemains", new FilterCompareExpressionRule<Int32>("FirstRemains"), SummaryCalculationType.Sum) { Width = 130, UseIntegerNumbersAlignment = true });
            this.dataColumns.Add(new PatternColumn("Остаток 1С", "Remains_1C", new FilterCompareExpressionRule<Int32>("Remains_1C"), SummaryCalculationType.Sum) { Width = 130, UseIntegerNumbersAlignment = true });
        }
        #endregion
    }

    public class CorrugatedTareBalanceSearchParameters : SessionIDSearchParameters
    {
        public string WarehouseID { get; set; }
        public DateTime? PeriodFrom { get; set; }
        public DateTime? PeriodTo { get; set; }
    }
}
