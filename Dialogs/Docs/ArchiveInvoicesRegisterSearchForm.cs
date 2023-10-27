using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.ExtraDataGridViewComponents;

namespace WMSOffice.Dialogs.Docs
{
    public partial class ArchiveInvoicesRegisterSearchForm : DialogForm
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        public Data.WH.AI_RegisterDocs_UncompletedRow SelectedRegistry { get; set; }

        public ArchiveInvoicesRegisterSearchForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Initialize();

            this.btnOK.Location = new Point(967, 8);
            this.btnCancel.Location = new Point(1057, 8);
        }

        private void Initialize()
        {
            xdgvRegistry.AllowSummary = false;

            xdgvRegistry.Init(new ArchiveInvoicesDraftRegisterView(), true);
            xdgvRegistry.UserID = this.UserID;

            xdgvRegistry.OnDataError += new DataGridViewDataErrorEventHandler(xdgvRegistry_OnDataError);
            xdgvRegistry.OnRowSelectionChanged += new EventHandler(xdgvRegistry_OnRowSelectionChanged);
            xdgvRegistry.OnRowDoubleClick += new DataGridViewCellEventHandler(xdgvRegistry_OnRowDoubleClick);
            xdgvRegistry.OnFilterChanged += new EventHandler(xdgvRegistry_OnFilterChanged);

            // активация постраничного просмотра
            xdgvRegistry.CreatePageNavigator();

            this.ReloadData();

            this.SetOperationAccess();
        }

        private void SetOperationAccess()
        {
            this.btnOK.Enabled = xdgvRegistry.SelectedItem != null;
        }


        void xdgvRegistry_OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        void xdgvRegistry_OnRowSelectionChanged(object sender, EventArgs e)
        {
            this.SetOperationAccess();
        }

        void xdgvRegistry_OnRowDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            if (xdgvRegistry.SelectedItem != null)
                this.DialogResult = DialogResult.OK;
        }

        void xdgvRegistry_OnFilterChanged(object sender, EventArgs e)
        {
            this.SetOperationAccess();
            xdgvRegistry.RecalculateSummary();
        }

        private void ArchiveInvoicesRegisterSearchForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SelectRegistry();
        }

        private void ReloadData()
        {
            try
            {
                var searchParams = new ArchiveInvoicesDraftRegisterSearchParameters() { SessionID = this.UserID };

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    try
                    {
                        this.xdgvRegistry.DataView.FillData(e.Argument as ArchiveInvoicesDraftRegisterSearchParameters);
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                bw.RunWorkerCompleted += (s, e) =>
                {
                    if (e.Result is Exception)
                         MessageBox.Show((e.Result as Exception).Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        this.xdgvRegistry.BindData(false);

                        //this.xdgvRegistry.AllowFilter = true;
                        this.xdgvRegistry.AllowSummary = true;
                    }

                    splashForm.CloseForce();
                };

                splashForm.ActionText = "Виконується завантаження реєстру..";
                bw.RunWorkerAsync(searchParams);
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool SelectRegistry()
        {
            try
            {
                if (xdgvRegistry.SelectedItem == null)
                    throw new Exception("Реєстр не обрано.");

                this.SelectedRegistry = xdgvRegistry.SelectedItem as Data.WH.AI_RegisterDocs_UncompletedRow;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }

    /// <summary>
    /// Представление для чероновика реестра архивных накладных
    /// </summary>
    public class ArchiveInvoicesDraftRegisterView : IDataView
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
            var searchCriteria = searchParameters as ArchiveInvoicesDraftRegisterSearchParameters;

            using (var adapter = new Data.WHTableAdapters.AI_RegisterDocs_UncompletedTableAdapter())
            {
                //adapter.SetTimeout(DEFAULT_RESPONSE_TIMEOUT);

                this.data = adapter.GetData(searchCriteria.SessionID);
            }
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ
        public ArchiveInvoicesDraftRegisterView()
        {
            this.dataColumns.Add(new PatternColumn("№ реєстру", "RegisterID", new FilterCompareExpressionRule<Int64>("RegisterID"), SummaryCalculationType.TotalRecords) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Дата реєстру", "Date_Created", new FilterDateCompareExpressionRule("Date_Created")) { Width = 110 });
            this.dataColumns.Add(new PatternColumn("Тип реєстру", "Document_Type", new FilterPatternExpressionRule("Document_Type")) { Width = 100 });

            this.dataColumns.Add(new PatternColumn("Філіал", "Filial", new FilterPatternExpressionRule("Filial"), SummaryCalculationType.Count) { Width = 150 });

            this.dataColumns.Add(new PatternColumn("Дата з", "DateFrom", new FilterDateCompareExpressionRule("DateFrom")) { Width = 90 });
            this.dataColumns.Add(new PatternColumn("Дата по", "DateTo", new FilterDateCompareExpressionRule("DateTo")) { Width = 90 });

            this.dataColumns.Add(new PatternColumn("Дебітор з", "DebtorFrom", new FilterCompareExpressionRule<Int32>("DebtorFrom"), SummaryCalculationType.Count) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Дебітор по", "DebtorTo", new FilterCompareExpressionRule<Int32>("DebtorTo"), SummaryCalculationType.Count) { Width = 100 });

            this.dataColumns.Add(new PatternColumn("Код статусу", "Status_ID", new FilterCompareExpressionRule<Int32>("Status_ID"), SummaryCalculationType.Count) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Назва статусу", "Status_Desc", new FilterPatternExpressionRule("Status_Desc")) { Width = 150 });
        }
        #endregion
    }

    /// <summary>
    /// Критерий поиска
    /// </summary>
    public class ArchiveInvoicesDraftRegisterSearchParameters : SessionIDSearchParameters
    {

    }
}
