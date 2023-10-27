using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using System.Data.SqlClient;
using System.Diagnostics;

namespace WMSOffice.Dialogs.Inventory
{
    public partial class InventoryDifferenceDocForm : DialogForm
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm waitProcessForm = new WMSOffice.Dialogs.SplashForm();

        /// <summary>
        /// Ид-р документа инвентаризации
        /// </summary>
        public long InventoryDocID { get; set; }

        public InventoryDifferenceDocForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.btnOK.Location = new Point(935, 8);
            this.btnCancel.Location = new Point(1025, 8);

            this.Initialize();
        }

        private void Initialize()
        {
            this.xdgvDifferenceDoc.AllowSummary = false;
            this.xdgvDifferenceDoc.AllowRangeColumns = true;
            this.xdgvDifferenceDoc.UserID = this.UserID;
            this.xdgvDifferenceDoc.Init(new DifferenceDocView(), true);
            xdgvDifferenceDoc.OnFilterChanged += new EventHandler(xdgvDifferenceDoc_OnFilterChanged);

            this.LoadData();
        }

        void xdgvDifferenceDoc_OnFilterChanged(object sender, EventArgs e)
        {
            this.xdgvDifferenceDoc.RecalculateSummary();
            sbExportToExcel.Enabled = this.xdgvDifferenceDoc.HasRows;
        }

        /// <summary>
        /// Зпгрузка данных
        /// </summary>
        private void LoadData()
        {
            this.xdgvDifferenceDoc.Focus();

            BackgroundWorker loadWorker = new BackgroundWorker();

            var searchCriteria = new DifferenceDocParameters();
            searchCriteria.UserID = this.UserID;
            searchCriteria.InventoryDocID = this.InventoryDocID;

            loadWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    this.xdgvDifferenceDoc.DataView.FillData(searchCriteria);
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
                    this.xdgvDifferenceDoc.BindData(false);

                    //this.xdgvResult.AllowFilter = true;
                    this.xdgvDifferenceDoc.AllowSummary = true;
                }

                waitProcessForm.CloseForce();
            };

            waitProcessForm.ActionText = "Выполняется формирование ведомости расхождений..";
            loadWorker.RunWorkerAsync();
            waitProcessForm.ShowDialog();
        }

        private void sbExportToExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlgSelectFile = new SaveFileDialog())
            {
                dlgSelectFile.Title = "Экспорт ведомости расхождений";

                DateTime now = DateTime.Now;
                dlgSelectFile.FileName = string.Format("{0}{1}{2}{3}{4}{5}-ведомость расхождений",
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
                        this.xdgvDifferenceDoc.ExportToExcel(dlgSelectFile.FileName);
                        Process.Start(dlgSelectFile.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }

    /// <summary>
    /// Представление ведомости расхождений
    /// </summary>
    public class DifferenceDocView : IDataView
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
            var searchCriteria = searchParameters as DifferenceDocParameters;

            string query = string.Format("EXEC [dbo].[pr_IV_SheetDifferences] {0}, {1}",
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

        public DifferenceDocView()
        {
            this.dataColumns.Add(new PatternColumn("№", "RowID") { Width = 40 });
            this.dataColumns.Add(new PatternColumn("Код товара", "Item_ID", new FilterCompareExpressionRule<Int32>("Item_ID"), SummaryCalculationType.Count) { Width = 80 });
            this.dataColumns.Add(new PatternColumn("Товар", "ItemName", new FilterPatternExpressionRule("ItemName")) { Width = 230 });
            this.dataColumns.Add(new PatternColumn("Производитель", "Manufacturer", new FilterPatternExpressionRule("Manufacturer")) { Width = 220 });
            this.dataColumns.Add(new PatternColumn("Серия", "LotNumber", new FilterPatternExpressionRule("LotNumber")) { Width = 120 });
            this.dataColumns.Add(new PatternColumn("Учетн. ост., шт.", "PlanQty", new FilterCompareExpressionRule<Decimal>("PlanQty")) { Width = 100, UseDecimalNumbersAlignment = true });
            this.dataColumns.Add(new PatternColumn("Факт. ост., шт.", "FactQty", new FilterCompareExpressionRule<Decimal>("FactQty")) { Width = 100, UseDecimalNumbersAlignment = true });
            this.dataColumns.Add(new PatternColumn("Расхождение, шт.", "DiffQty", new FilterCompareExpressionRule<Decimal>("DiffQty")) { Width = 100, UseDecimalNumbersAlignment = true });
            this.dataColumns.Add(new PatternColumn("Расхождение, грн.", "DiffAmountUAH", new FilterCompareExpressionRule<Decimal>("DiffAmountUAH"), SummaryCalculationType.Sum) { Width = 100, UseDecimalNumbersAlignment = true });
        }
    }

    /// <summary>
    /// Критерий поиска ведомости расхождений
    /// </summary>
    public class DifferenceDocParameters : SearchParametersBase
    {
        public long UserID { get; set; }
        public long InventoryDocID { get; set; }
    }
}
