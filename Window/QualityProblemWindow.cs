using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Data;

namespace WMSOffice.Window
{
    public partial class QualityProblemWindow : GeneralWindow
    {
        public QualityProblemWindow()
        {
            InitializeComponent();
            InitializeQualityRequestGrid();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshSeries();
        }

        /// <summary>
        /// Инициализация фильтруемого грида с заявками
        /// </summary>
        private void InitializeQualityRequestGrid()
        {
            edgDocs.Init(new QualityProblemView(), true);
            edgDocs.LoadExtraDataGridViewSettings(Name);
            edgDocs.UserID = UserID;
            // edgDocs.SetCellStyles(gvLines.RowTemplate.DefaultCellStyle, gvLines.ColumnHeadersDefaultCellStyle);
            edgDocs.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            //edgDocs.OnRowDoubleClick += egvDocs_CellDoubleClick;
            //edgDocs.OnRowSelectionChanged += egvDocs_SelectionChanged;
            //edgDocs.OnDataBindingComplete += egvDocs_DataBindingComplete;
            //edgDocs.OnFormattingCell += egvDocs_CellFormatting;
            //edgDocs.OnFilterChanged += edgDocs_OnFilterChanged;
        }

        /// <summary>
        /// Идентификатор текущей выбранной заявки в списке заявок
        /// </summary>
        // private Quality.QP_SeriesRow CurrentSeries { get { return (Quality.QP_SeriesRow)edgDocs.SelectedItem; } }

        /// <summary>
        /// Признак, который показывает, выделена ли сейчас какая-нибудь заявка в таблице заявок
        /// </summary>
        private bool IsSeriesSelected { get { return edgDocs.SelectedItem != null; } }
        
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных
        /// </summary>
        private Dialogs.SplashForm waitProgressForm = new WMSOffice.Dialogs.SplashForm();

        /// <summary>
        /// Обновление таблицы проблемных товаров
        /// </summary>
        private void RefreshSeries()
        {
            //long selDocID = -1;
            //int rowIndex = edgDocs.FirstDisplayedScrollingRowIndex;
            //if (IsSeriesSelected)
            //    selDocID = CurrentSeries;

            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (sender, args) =>
                                 {
                                     try
                                     {
                                         edgDocs.DataView.FillData(new QualityProblemSearchParameters() {SessionId = this.UserID});
                                     }
                                     catch (Exception ex)
                                     {
                                         args.Result = ex;
                                     }
                                 };
            worker.RunWorkerCompleted += (sender, args) =>
                                 {
                                     if (args.Result is Exception)
                                         this.ShowError(args.Result as Exception);
                                     else
                                     {
                                         edgDocs.BindData(false);
                                         edgDocs.AllowSummary = true;
                                     }

                                     this.waitProgressForm.CloseForce();
                                 };
            waitProgressForm.ActionText = "Подождите, идет загрузка данных...";
            worker.RunWorkerAsync();
            waitProgressForm.ShowDialog();

            //if (selDocID != -1)
            //    edgDocs.SelectRow("Doc_ID", selDocID.ToString());
            //edgDocs.ScrollToRow(rowIndex);
        }
    }

    /// <summary>
    /// Представление для грида с проблемными сроками
    /// </summary>
    public class QualityProblemView : IDataView
    {
        #region ПЕРЕМЕННЫЕ И СВОЙСТВА КЛАССА

        /// <summary>
        /// Время ожидания выполнения запроса
        /// </summary>
        private const int DEFAULT_RESPONSE_TIMEOUT = 300;

        #endregion

        #region РЕАЛИЗАЦИЯ ИНТЕРФЕЙСА IDataView

        /// <summary>
        /// Коллекция отображаемых колонок
        /// </summary>
        private PatternColumnsCollection dataColumns = new PatternColumnsCollection();

        /// <summary>
        /// Коллекция отображаемых колонок
        /// </summary>
        public PatternColumnsCollection Columns { get { return dataColumns; } }

        /// <summary>
        /// Источник данных для представления
        /// </summary>
        private DataTable data;

        /// <summary>
        /// Источник данных для представления
        /// </summary>
        public DataTable Data { get { return data; } }

        /// <summary>
        /// Получение источника данных согласно критериям поиска
        /// </summary>
        /// <param name="searchParameters">Критерии поиска</param>
        public void FillData(SearchParametersBase searchParameters)
        {
            var sc = searchParameters as QualityProblemSearchParameters;
            using (var adapter = new Data.QualityTableAdapters.QP_SeriesTableAdapter())
                data = adapter.GetData(sc.SessionId);
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ КЛАССА

        public QualityProblemView()
        {
            this.dataColumns.Add(new PatternColumn("№ заявки", "Doc_ID", new FilterCompareExpressionRule<Int64>("Doc_ID"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("Дата заявки", "Doc_Date", new FilterDateCompareExpressionRule("Doc_Date"), SummaryCalculationType.None));
            this.dataColumns.Add(new PatternColumn("Ст.", "Doc_Status_ID", new FilterCompareExpressionRule<Int32>("Doc_Status_ID"), SummaryCalculationType.None));
            this.dataColumns.Add(new PatternColumn("Статус", "Doc_Status_Name", new FilterPatternExpressionRule("Doc_Status_Name"), SummaryCalculationType.None));
            this.dataColumns.Add(new PatternColumn("Код поставщ.", "Vendor_ID", new FilterCompareExpressionRule<Int32>("Vendor_ID"), SummaryCalculationType.None));
            this.dataColumns.Add(new PatternColumn("Поставщик", "Vendor_Name", new FilterPatternExpressionRule("Vendor_Name"), SummaryCalculationType.None));
            this.dataColumns.Add(new PatternColumn("Код МОЗ", "Manager_ID", new FilterCompareExpressionRule<Int32>("Manager_ID"), SummaryCalculationType.None));
            this.dataColumns.Add(new PatternColumn("МОЗ", "Manager_Name", new FilterPatternExpressionRule("Manager_Name"), SummaryCalculationType.None));
            this.dataColumns.Add(new PatternColumn("Код тов.", "Item_ID", new FilterCompareExpressionRule<Int32>("Item_ID"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("Товар", "Item_Name", new FilterPatternExpressionRule("Item_Name"), SummaryCalculationType.None));
            this.dataColumns.Add(new PatternColumn("Серия", "Item_Series", new FilterPatternExpressionRule("Item_Series"), SummaryCalculationType.None));
            this.dataColumns.Add(new PatternColumn("Блок", "Item_Block", new FilterPatternExpressionRule("Item_Block"), SummaryCalculationType.None));
            this.dataColumns.Add(new PatternColumn("Ст.", "Item_Status_ID", new FilterCompareExpressionRule<Int32>("Item_Status_ID"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("Статус", "Item_Status_Name", new FilterPatternExpressionRule("Item_Status_Name"), SummaryCalculationType.None));
            this.dataColumns.Add(new PatternColumn("Кол-во", "Remains_PCS", new FilterCompareExpressionRule<Int32>("Remains_PCS"), SummaryCalculationType.Sum) { UseIntegerNumbersAlignment = true } );
            this.dataColumns.Add(new PatternColumn("Сумма", "Remains_UAH", new FilterCompareExpressionRule<Int32>("Remains_UAH"), SummaryCalculationType.Sum) { UseDecimalNumbersAlignment = true } );
            this.dataColumns.Add(new PatternColumn("Пр.", "Problem_Reason_ID", new FilterCompareExpressionRule<Int32>("Problem_Reason_ID"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("Пробл.", "Problem_Reason_Name", new FilterPatternExpressionRule("Problem_Reason_Name"), SummaryCalculationType.None));
            this.dataColumns.Add(new PatternColumn("Норматив", "Time_Plan", new FilterDateCompareExpressionRule("Time_Plan"), SummaryCalculationType.None));
            this.dataColumns.Add(new PatternColumn("Разница", "Time_Diff", new FilterDateCompareExpressionRule("Time_Diff"), SummaryCalculationType.None));
            //this.dataColumns.Add(new PatternColumn("Ответственный", "ResponsibleUser", new FilterPatternExpressionRule("ResponsibleUser"), SummaryCalculationType.Count));
            //this.dataColumns.Add(new PatternColumn("№ ГТД", "GTD_Num", new FilterPatternExpressionRule("GTD_Num"), SummaryCalculationType.Count));
            //this.dataColumns.Add(new PatternColumn("Дата ГТД", "GTD_Date", new FilterDateCompareExpressionRule("GTD_Date"), SummaryCalculationType.Count));
            //this.dataColumns.Add(new PatternColumn("200", "200", new FilterCompareExpressionRule<Int32>("200"), SummaryCalculationType.Sum));
            //this.dataColumns.Add(new PatternColumn("210", "210", new FilterCompareExpressionRule<Int32>("210"), SummaryCalculationType.Sum));
            //this.dataColumns.Add(new PatternColumn("220", "220", new FilterCompareExpressionRule<Int32>("220"), SummaryCalculationType.Sum));
            //this.dataColumns.Add(new PatternColumn("297", "297", new FilterCompareExpressionRule<Int32>("297"), SummaryCalculationType.Sum));
            //this.dataColumns.Add(new PatternColumn("298", "298", new FilterCompareExpressionRule<Int32>("298"), SummaryCalculationType.Sum));
            //this.dataColumns.Add(new PatternColumn("299", "299", new FilterCompareExpressionRule<Int32>("299"), SummaryCalculationType.Sum));
            //this.dataColumns.Add(new PatternColumn("На статусе с", "StatusDate", new FilterDateCompareExpressionRule("StatusDate"), SummaryCalculationType.Count));
            //this.dataColumns.Add(new PatternColumn("Норматив", "NormTime", new FilterDateCompareExpressionRule("NormTime"), SummaryCalculationType.Count));
            //this.dataColumns.Add(new PatternColumn("Разница", "DiffNorm", new FilterPatternExpressionRule("DiffNorm"), SummaryCalculationType.Count));
            //this.dataColumns.Add(new PatternColumn("Пользователь", "LastUsers", new FilterPatternExpressionRule("LastUsers"), SummaryCalculationType.Count));
            //this.dataColumns.Add(new PatternColumn("Кол-во", "Amount", new FilterCompareExpressionRule<Int32>("Amount"), SummaryCalculationType.Sum));
            //this.dataColumns.Add(new PatternColumn("Сумма", "Suma", new FilterCompareExpressionRule<Int32>("Suma"), SummaryCalculationType.Sum));
            //this.dataColumns.Add(new PatternColumn("Ответственный", "ResponsibleUser", new FilterPatternExpressionRule("ResponsibleUser"), SummaryCalculationType.Count));
        }

        #endregion
    }

    /// <summary>
    /// Параметры получения списка проблемных строк
    /// </summary>
    public class QualityProblemSearchParameters : SearchParametersBase
    {
        /// <summary>
        /// Фильтр для получения списка проблемных строк
        /// </summary>
        public string Filter { get; set; }

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        public long SessionId { get; set; }
    }
}
