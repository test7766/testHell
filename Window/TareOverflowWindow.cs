using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls;
using WMSOffice.Controls.ExtraDataGridViewComponents;

namespace WMSOffice.Window
{
    public partial class TareOverflowWindow : GeneralWindow
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        private TextBoxScaner tbScanner = null;

        public string StoreCode { get; private set; }

        public TareOverflowWindow()
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
            #region ИНИЦИАЛИЗАЦИЯ ПОИСКА ПО Ш/К

            tsSearch.Items.Add(new ToolStripLabel("Ш/К :"));

            tbScanner = new TextBoxScaner();
            tbScanner.TextChanged += (s, e) =>
            {
                if (!string.IsNullOrEmpty(tbScanner.Text))
                {
                    try
                    {
                        var boxCode = tbScanner.Text;
                        using (var adapter = new Data.ContainersTableAdapters.SC_SurplusBox_TareTableAdapter())
                            adapter.ActivateTare(this.UserID, this.StoreCode, boxCode);

                        this.LoadBoxes();
                    }
                    catch (Exception ex)
                    {
                        this.ShowError(ex);
                    }
                    finally
                    {
                        tbScanner.Text = string.Empty;
                    }
                }
            };
            tsSearch.Items.Add(new ToolStripControlHost(tbScanner) { Width = 210 });

            #endregion

            #region ДОБАВЛЕНИЕ СПИСКА СКЛАДОВ

            tsSearch.Items.Add(new ToolStripLabel("Склад :"));

            var cmbWarehouses = new ComboBox();
            cmbWarehouses.Size = new Size(200, cmbWarehouses.Height);
            cmbWarehouses.DropDownStyle = ComboBoxStyle.DropDownList;
            #region Формирование списка складов
            var bsWarehouses = new BindingSource();
            bsWarehouses.DataMember = "SC_SurplusBox_Wrh";
            bsWarehouses.DataSource = new Data.Containers();
            cmbWarehouses.DisplayMember = "StoreName";
            cmbWarehouses.ValueMember = "StoreCode";
            cmbWarehouses.DataSource = bsWarehouses;

            cmbWarehouses.SelectedValueChanged += delegate(object sender, EventArgs e)
            {
                if (cmbWarehouses.SelectedValue == null)
                    return;

                this.LoadBoxes(this.StoreCode = cmbWarehouses.SelectedValue.ToString());
            };


            #endregion
            tsSearch.Items.Add(new ToolStripControlHost(cmbWarehouses));

            #endregion

            xdgvItems.AllowSummary = false;

            xdgvItems.Init(new TareOverflowView(), true);
            xdgvItems.UserID = this.UserID;

            xdgvItems.UseMultiSelectMode = true;

            xdgvItems.OnDataError += new DataGridViewDataErrorEventHandler(xdgvItems_OnDataError);
            xdgvItems.OnRowSelectionChanged += new EventHandler(xdgvItems_OnRowSelectionChanged);
            xdgvItems.OnFilterChanged += new EventHandler(xdgvItems_OnFilterChanged);
            xdgvItems.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvItems_OnFormattingCell);

            // активация постраничного просмотра
            xdgvItems.CreatePageNavigator();

            this.SetOperationAccess(true);


            // Получение списка складов
            try
            {
                using (var adapter = new Data.ContainersTableAdapters.SC_SurplusBox_WrhTableAdapter())
                    bsWarehouses.DataSource = adapter.GetData(this.UserID);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        void xdgvItems_OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        void xdgvItems_OnRowSelectionChanged(object sender, EventArgs e)
        {
            this.SetOperationAccess(false);
        }

        private void SetOperationAccess(bool wholeViewAccess)
        {
            if (wholeViewAccess)
            {
                bool hasRows = xdgvItems.HasRows;
                bool isEnabled = hasRows && xdgvItems.SelectedItem != null;
            }
            else
            {
                bool hasRows = xdgvItems.HasRows;
                bool isEnabled = xdgvItems.SelectedItem != null;
            }
        }

        void xdgvItems_OnFilterChanged(object sender, EventArgs e)
        {
            xdgvItems.RecalculateSummary();
            this.SetOperationAccess(true);
        }

        void xdgvItems_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            var boundRow = (xdgvItems.DataGrid.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;

            #region СТИЛЬ ДЛЯ ИНДИКАЦИИ ЭТИКЕТОК ОБОРОТНОЙ ТАРЫ

            if (boundRow.Table.Columns.Contains("COLOR"))
            {
                var colorName = boundRow["COLOR"].ToString();
                var color = string.IsNullOrEmpty(colorName) ? Color.White : Color.FromName(colorName);

                e.CellStyle.BackColor = color;
                e.CellStyle.SelectionForeColor = color;
            }

            #endregion
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F5))
            {
                LoadBoxes();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnRefreshData_Click(object sender, EventArgs e)
        {
            this.LoadBoxes();
        }

        private void LoadBoxes()
        {
            this.LoadBoxes(this.StoreCode);
        }

        private void LoadBoxes(string storeCode)
        {
            try
            {
                var searchParams = new TareOverflowViewSearchParameters() { SessionID = this.UserID, StoreCode = storeCode };

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    try
                    {
                        this.xdgvItems.DataView.FillData(e.Argument as TareOverflowViewSearchParameters);
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
                        this.xdgvItems.BindData(false);

                        //this.xdgvItems.AllowFilter = true;
                        this.xdgvItems.AllowSummary = true;
                    }

                    splashForm.CloseForce();
                };

                splashForm.ActionText = "Відбувається завантаження списка контейнерів надлишків..";
                bw.RunWorkerAsync(searchParams);
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
            finally
            {
                tbScanner.Focus();
            }
        }

    }

    /// <summary>
    /// Представление для контейнеров излишек
    /// </summary>
    public class TareOverflowView : IDataView
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
            var searchCriteria = searchParameters as TareOverflowViewSearchParameters;

            using (var adapter = new Data.ContainersTableAdapters.SC_SurplusBox_TareTableAdapter())
                this.data = adapter.GetData(searchCriteria.SessionID, searchCriteria.StoreCode);
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ
        public TareOverflowView()
        {
            this.dataColumns.Add(new PatternColumn("Код складу", "StoreCode", new FilterPatternExpressionRule("StoreCode"), SummaryCalculationType.Count) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Назва складу", "StoreName", new FilterPatternExpressionRule("StoreName")) { Width = 150 });

            this.dataColumns.Add(new PatternColumn("Ш/К тари", "BoxCode", new FilterPatternExpressionRule("BoxCode"), SummaryCalculationType.Count) { Width = 200 });
            this.dataColumns.Add(new PatternColumn("Тип тари", "BoxName", new FilterPatternExpressionRule("BoxName"), SummaryCalculationType.Count) { Width = 300 });

            this.dataColumns.Add(new PatternColumn("Дата створення", "DateCreated", new FilterDateCompareExpressionRule("DateCreated")) { Width = 150 });
        }
        #endregion
    }

    /// <summary>
    /// Критерий поиска
    /// </summary>
    public class TareOverflowViewSearchParameters : SessionIDSearchParameters
    {
        public string StoreCode { get; set; }
    }
}
