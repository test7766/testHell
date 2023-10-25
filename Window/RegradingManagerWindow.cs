using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Dialogs.WH;

namespace WMSOffice.Window
{
    public partial class RegradingManagerWindow : GeneralWindow
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        private Data.WH.HD_DocsRow SelectedDoc { get { return xdgvDocs.SelectedItem as Data.WH.HD_DocsRow; } }

        public RegradingManagerWindow()
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
            stbDocType.ValueReferenceQuery = "[dbo].[pr_HD_GetDocTypes]";
            stbDocType.UserID = this.UserID;
            stbDocType.OnVerifyValue += new VerifyValueHandler(stb_OnVerifyValue);

            var today = DateTime.Today;
            dtpPeriodFrom.Value = new DateTime(today.Year, today.Month, 1);
            dtpPeriodTo.Value = today;

            dtpPeriodFrom.Checked = false;
            dtpPeriodTo.Checked = false;

            xdgvDocs.AllowSummary = false;

            xdgvDocs.Init(new RegradingManagerView(), true);
            xdgvDocs.UserID = this.UserID;

            xdgvDocs.OnDataError += new DataGridViewDataErrorEventHandler(xdgvDocs_OnDataError);
            xdgvDocs.OnRowDoubleClick += new DataGridViewCellEventHandler(xdgvDocs_OnRowDoubleClick);
            xdgvDocs.OnRowSelectionChanged += new EventHandler(xdgvDocs_OnRowSelectionChanged);
            xdgvDocs.OnFilterChanged += new EventHandler(xdgvDocs_OnFilterChanged);
            xdgvDocs.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvDocs_OnFormattingCell);

            // активация постраничного просмотра
            xdgvDocs.CreatePageNavigator();

            this.SetOperationAccess(true);

            stbDocType.Focus();
        }

        void stb_OnVerifyValue(object sender, VerifyValueArgs e)
        {
            var control = sender as SearchTextBox;
            TextBox lblDescription = null;

            if (control == stbDocType)
                lblDescription = tbDocType;

            if (lblDescription != null)
            {
                lblDescription.Text = e.Success ? e.Description : "ЗНАЧЕНИЕ НЕ НАЙДЕНО!";
                lblDescription.ForeColor = e.Success ? SystemColors.ControlText : Color.Red;

                if (e.Success)
                    control.Value = e.Value;
                //else
                //    control.Value = string.Empty;
            }
        }

        void xdgvDocs_OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        void xdgvDocs_OnRowDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            if (xdgvDocs.SelectedItem != null)
                this.ShowDoc();
        }

        private void ShowDoc()
        {
            try
            {
                var dlgRegradingDocumentEditor = new RegradingDocumentEditorForm(this.SelectedDoc) { UserID = this.UserID };
                if (dlgRegradingDocumentEditor.ShowDialog() == DialogResult.OK)
                { 
                
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        void xdgvDocs_OnRowSelectionChanged(object sender, EventArgs e)
        {
            this.SetOperationAccess(false);
        }

        private void SetOperationAccess(bool wholeViewAccess)
        {
            
        }

        void xdgvDocs_OnFilterChanged(object sender, EventArgs e)
        {
            xdgvDocs.RecalculateSummary();
            this.SetOperationAccess(true);
        }

        void xdgvDocs_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
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

        private void btnRefreshDocs_Click(object sender, EventArgs e)
        {
            this.ReloadData();
        }

        private void ReloadData()
        {
            try
            {
                var searchParams = new RegradingManagerSearchParameters() { SessionID = this.UserID };

                if (string.IsNullOrEmpty(stbDocType.Value))
                    throw new Exception("Тип документа не вказано.");
                else
                    searchParams.DocType = stbDocType.Value;

                var periodFrom = dtpPeriodFrom.Checked ? dtpPeriodFrom.Value.Date : (DateTime?)null;
                var periodTo = dtpPeriodTo.Checked ? dtpPeriodTo.Value.Date : (DateTime?)null;
                if (periodFrom.HasValue && periodTo.HasValue && periodFrom > periodTo)
                    throw new Exception("Початковий період не повинен перевищувати\nкінцевий.");

                searchParams.PeriodFrom = periodFrom;
                searchParams.PeriodTo = periodTo;

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    try
                    {
                        this.xdgvDocs.DataView.FillData(e.Argument as RegradingManagerSearchParameters);
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
                        this.xdgvDocs.BindData(false);

                        //this.xdgvDocs.AllowFilter = true;
                        this.xdgvDocs.AllowSummary = true;
                    }

                    splashForm.CloseForce();
                };

                splashForm.ActionText = "Виконується завантаження реєстру пересортів..";
                bw.RunWorkerAsync(searchParams);
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnCreateDoc_Click(object sender, EventArgs e)
        {

        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {

        }
    }

    /// <summary>
    /// Представление для менеджера пересортов
    /// </summary>
    public class RegradingManagerView : IDataView
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
            var searchCriteria = searchParameters as RegradingManagerSearchParameters;

            using (var adapter = new Data.WHTableAdapters.HD_DocsTableAdapter())
            {
                adapter.SetTimeout(DEFAULT_RESPONSE_TIMEOUT);

                this.data = adapter.GetData(
                    searchCriteria.SessionID,
                    searchCriteria.DocType,
                    searchCriteria.PeriodFrom,
                    searchCriteria.PeriodTo);
            }
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ
        public RegradingManagerView()
        {
            this.dataColumns.Add(new PatternColumn("№ документа", "Document_Number", new FilterCompareExpressionRule<Int64>("Document_Number"), SummaryCalculationType.TotalRecords) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Тип документа", "Doc_Type", new FilterPatternExpressionRule("Doc_Type"), SummaryCalculationType.Count) { Width = 110 });
            this.dataColumns.Add(new PatternColumn("Компанія", "Doc_Company", new FilterPatternExpressionRule("Doc_Company")) { Width = 80 });
            this.dataColumns.Add(new PatternColumn("Дата ГК", "GL_Date", new FilterDateCompareExpressionRule("GL_Date")) { Width = 110 });
            this.dataColumns.Add(new PatternColumn("Опис операції", "Transaction_Explanation", new FilterPatternExpressionRule("Transaction_Explanation")) { Width = 300 });
            this.dataColumns.Add(new PatternColumn("Склад", "BranchPlant", new FilterPatternExpressionRule("BranchPlant"), SummaryCalculationType.Count) { Width = 70 });
            this.dataColumns.Add(new PatternColumn("Дата операції", "Trans_Date", new FilterDateCompareExpressionRule("Trans_Date")) { Width = 110 });
            this.dataColumns.Add(new PatternColumn("№ пакета", "BatchNumber", new FilterCompareExpressionRule<Int64>("BatchNumber")) { Width = 100 });
        }
        #endregion
    }

    /// <summary>
    /// Критерий поиска
    /// </summary>
    public class RegradingManagerSearchParameters : SessionIDSearchParameters
    {
        public string DocType { get; set; }
        public DateTime? PeriodFrom { get; set; }
        public DateTime? PeriodTo { get; set; }

        public RegradingManagerSearchParameters()
        {
            this.DocType = (string)null;
        }
    }
}
