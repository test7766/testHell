using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using System.Data.SqlClient;

namespace WMSOffice.Dialogs.Inventory
{
    public partial class InventoryShortageMovementForm : DialogForm
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm waitProcessForm = new WMSOffice.Dialogs.SplashForm();

        /// <summary>
        /// Ид-р документа инвентаризации
        /// </summary>
        public long InventoryDocID { get; set; }

        public InventoryShortageMovementForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.btnOK.Location = new Point(1190, 8);
            this.btnCancel.Location = new Point(1280, 8);

            this.Initialize();
        }

        private void Initialize()
        {
            this.xdgvShortage.AllowSummary = false;
            this.xdgvShortage.AllowRangeColumns = true;
            this.xdgvShortage.UserID = this.UserID;
            this.xdgvShortage.Init(new ShortageView(), true);
            xdgvShortage.OnFilterChanged += new EventHandler(xdgvShortage_OnFilterChanged);

            this.LoadData();
        }

        void xdgvShortage_OnFilterChanged(object sender, EventArgs e)
        {
            this.xdgvShortage.RecalculateSummary();
            sbExportToExcel.Enabled = this.xdgvShortage.HasRows;
        }

        private void LoadData()
        {
            this.xdgvShortage.Focus();

            BackgroundWorker loadWorker = new BackgroundWorker();

            var searchCriteria = new ShortageParameters();
            searchCriteria.UserID = this.UserID;
            searchCriteria.InventoryDocID = this.InventoryDocID;

            loadWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    this.xdgvShortage.DataView.FillData(searchCriteria);
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            };
            loadWorker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Result is Exception)
                    MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    this.xdgvShortage.BindData(false);

                    //this.xdgvResult.AllowFilter = true;
                    this.xdgvShortage.AllowSummary = true;
                }

                waitProcessForm.CloseForce();
            };

            waitProcessForm.ActionText = "Выполняется формирование итоговых недостач..";
            loadWorker.RunWorkerAsync();
            waitProcessForm.ShowDialog();
        }

        private void sbExportToExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlgSelectFile = new SaveFileDialog())
            {
                dlgSelectFile.Title = "Экспорт итоговых недостач";

                DateTime now = DateTime.Now;
                dlgSelectFile.FileName = string.Format("{0}{1}{2}{3}{4}{5}-итоговые недостачи",
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
                dlgSelectFile.AddExtension = true;
                dlgSelectFile.DefaultExt = "csv";
                if (dlgSelectFile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        this.xdgvShortage.ExportToExcel(dlgSelectFile.FileName);
                        Process.Start(dlgSelectFile.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void InventoryShortageMovementForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.InvokeMovement();
        }

        /// <summary>
        /// Выполнение перемещений
        /// </summary>
        /// <returns></returns>
        private bool InvokeMovement()
        {
            bool succeed = false;
            BackgroundWorker saveWorker = new BackgroundWorker();
            saveWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    using (Data.InventoryTableAdapters.QueriesTableAdapter adapter = new WMSOffice.Data.InventoryTableAdapters.QueriesTableAdapter())
                        adapter.MoveShortage(this.InventoryDocID);
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            };
            saveWorker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Result is Exception)
                    MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    succeed = true;

                waitProcessForm.CloseForce();
            };

            waitProcessForm.ActionText = "Выполняется перемещение итоговых недостач..";
            saveWorker.RunWorkerAsync();
            waitProcessForm.ShowDialog();

            return succeed;
        }
    }

    /// <summary>
    /// Представление ведомости расхождений
    /// </summary>
    public class ShortageView : IDataView
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
            var searchCriteria = searchParameters as ShortageParameters;

            string query = string.Format("EXEC [dbo].[pr_IV_ResultingShortage] {0}, {1}",
                searchCriteria.UserID,
                searchCriteria.InventoryDocID);

            SqlDataAdapter adapter = new SqlDataAdapter(query, new SqlConnection(Properties.Settings.Default.JDE_PROCConnectionString));
            adapter.SelectCommand.CommandTimeout = DEFAULT_RESPONSE_TIMEOUT;
            //adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            var dataSet = new DataSet();
            adapter.Fill(dataSet);
            this.data = dataSet.Tables[0];
        }

        #endregion

        public ShortageView()
        {
            this.dataColumns.Add(new PatternColumn("№", "RowID") { Width = 40 });            
            this.dataColumns.Add(new PatternColumn("Код товара", "Item_ID", new FilterCompareExpressionRule<Int32>("Item_ID"), SummaryCalculationType.Count) { Width = 50 });
            this.dataColumns.Add(new PatternColumn("Товар", "ItemName", new FilterPatternExpressionRule("ItemName")) { Width = 200 });
            this.dataColumns.Add(new PatternColumn("Производитель", "Manufacturer", new FilterPatternExpressionRule("Manufacturer")) { Width = 220 });
            this.dataColumns.Add(new PatternColumn("Серия", "LotNumber", new FilterPatternExpressionRule("LotNumber")) { Width = 80 });
            this.dataColumns.Add(new PatternColumn("Партия", "Batch_ID", new FilterPatternExpressionRule("Batch_ID")) { Width = 80 });
            this.dataColumns.Add(new PatternColumn("Себ-сть, грн.", "SSUAH", new FilterCompareExpressionRule<Decimal>("SSUAH")) { Width = 100, UseDecimalNumbersAlignment = true });
            this.dataColumns.Add(new PatternColumn("Кол-во, шт.", "Qty", new FilterCompareExpressionRule<Decimal>("Qty")) { Width = 100, UseDecimalNumbersAlignment = true });
            this.dataColumns.Add(new PatternColumn("Сумма, грн.", "AmountUAH", new FilterCompareExpressionRule<Decimal>("AmountUAH"), SummaryCalculationType.Sum) { Width = 100, UseDecimalNumbersAlignment = true });
            this.dataColumns.Add(new PatternColumn("На склад", "WarehouseTo", new FilterPatternExpressionRule("WarehouseTo")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("На полку", "LocationTo", new FilterPatternExpressionRule("LocationTo")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Ответств. по полке", "Department", new FilterPatternExpressionRule("Department")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Категория ПТ", "Category_ID", new FilterPatternExpressionRule("Category_ID")) { Width = 70 });
        }
    }

    /// <summary>
    /// Критерий поиска ведомости расхождений
    /// </summary>
    public class ShortageParameters : SearchParametersBase
    {
        public long UserID { get; set; }
        public long InventoryDocID { get; set; }
    }
}
