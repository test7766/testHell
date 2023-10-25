using System;
using System.Collections.Generic;
using System.Text;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;

namespace WMSOffice.Window
{
    public partial class FullEquipmentStateWindow : GeneralWindow
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        public FullEquipmentStateWindow()
        {
            InitializeComponent();
        }

        private void FullEquipmentStateWindow_Load(object sender, EventArgs e)
        {
            this.Initialize();
        }

        private void Initialize()
        {
            xdgvItems.AllowSummary = false;

            xdgvItems.Init(new FullEquipmentStateView(), true);
            xdgvItems.UserID = this.UserID;

            xdgvItems.OnDataError += new DataGridViewDataErrorEventHandler(xdgvItems_OnDataError);
            xdgvItems.OnFilterChanged += new EventHandler(xdgvItems_OnFilterChanged);
            xdgvItems.OnRowSelectionChanged += new EventHandler(xdgvItems_OnRowSelectionChanged);

            this.SetOperationAccess(true);
        }

        void xdgvItems_OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        void xdgvItems_OnFilterChanged(object sender, EventArgs e)
        {
            xdgvItems.RecalculateSummary();
            this.SetOperationAccess(true);
        }

        void xdgvItems_OnRowSelectionChanged(object sender, EventArgs e)
        {
            this.SetOperationAccess(false);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.ReloadData();
        }

        private void sbRefresh_Click(object sender, EventArgs e)
        {
            this.ReloadData();
        }

        private void ReloadData()
        {
            try
            {
                var searchParams = new FullEquipmentStateSearchParameters() { SessionID = this.UserID };
                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    try
                    {
                        this.xdgvItems.DataView.FillData(e.Argument as FullEquipmentStateSearchParameters);
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
                        this.xdgvItems.BindData(false);

                        //this.xdgvItems.AllowFilter = true;
                        this.xdgvItems.AllowSummary = true;
                    }

                    splashForm.CloseForce();
                };

                splashForm.ActionText = "Выполняется получение списка статусов оборудования..";
                bw.RunWorkerAsync(searchParams);
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetOperationAccess(bool wholeViewAccess)
        {
            if (wholeViewAccess)
            {
                bool hasRows = xdgvItems.HasRows;

                bool isExportEnabled = hasRows;
                sbExport.Enabled = isExportEnabled;
            }
            else
            {
                bool hasRows = xdgvItems.HasRows;

                bool isExportEnabled = hasRows;
                sbExport.Enabled = isExportEnabled;
            }
        }

        private void sbExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlgSelectFile = new SaveFileDialog())
            {
                dlgSelectFile.Title = "Экспорт статусов термооборудования";

                DateTime now = DateTime.Now;
                dlgSelectFile.FileName = string.Format("{0}{1}{2}{3}{4}{5}-список статусов термооборудования",
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
    }

    /// <summary>
    /// Представление для доверенностей
    /// </summary>
    public class FullEquipmentStateView : IDataView
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
            var searchCriteria = searchParameters as FullEquipmentStateSearchParameters;

            using (var adapter = new Data.ColdChainTableAdapters.FullEquipmentStateTableAdapter())
                this.data = adapter.GetData();
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ
        public FullEquipmentStateView()
        {
            this.dataColumns.Add(new PatternColumn("Тип оборудования", "Тип оборудования", new FilterPatternExpressionRule("Тип оборудования")) { Width = 120 });
            this.dataColumns.Add(new PatternColumn("ШК оборудования", "ШК оборудования", new FilterPatternExpressionRule("ШК оборудования")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Наименование", "Наименование", new FilterPatternExpressionRule("Наименование")) { Width = 150 });

            this.dataColumns.Add(new PatternColumn("Код товара", "Код товара", new FilterCompareExpressionRule<Int32>("Код товара"), SummaryCalculationType.Count) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Партия", "Партия", new FilterPatternExpressionRule("Партия]"), SummaryCalculationType.Count) { Width = 120 });
            this.dataColumns.Add(new PatternColumn("Место", "место", new FilterPatternExpressionRule("место"), SummaryCalculationType.Count) { Width = 120 });
            this.dataColumns.Add(new PatternColumn("Склад", "склад", new FilterPatternExpressionRule("склад"), SummaryCalculationType.Count) { Width = 120 });

            this.dataColumns.Add(new PatternColumn("Статус", "статус", new FilterPatternExpressionRule("статус")) { Width = 200 });

            this.dataColumns.Add(new PatternColumn("МЛ", "МЛ", new FilterPatternExpressionRule("МЛ")) { Width = 120 });

            this.dataColumns.Add(new PatternColumn("На месте с", "На месте с", new FilterDateCompareExpressionRule("На месте с")) { Width = 120 });
        }
        #endregion
    }

    /// <summary>
    /// Критерий поиска
    /// </summary>
    public class FullEquipmentStateSearchParameters : SessionIDSearchParameters
    {

    }
}
