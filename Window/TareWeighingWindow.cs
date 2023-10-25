using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs.Receive;
using WMSOffice.Controls.ExtraDataGridViewComponents;

namespace WMSOffice.Window
{
    public partial class TareWeighingWindow : GeneralWindow
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        public TareWeighingWindow()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.xdgvData.SetSameStyleForAlternativeRows();

            this.xdgvData.AllowSummary = false;
            this.xdgvData.AllowRangeColumns = false;
            this.xdgvData.UseMultiSelectMode = false;

            this.xdgvData.Init(new TareWeighingView(), true);
            this.xdgvData.UserID = this.UserID;

            this.xdgvData.OnFilterChanged += new EventHandler(xdgvData_OnFilterChanged);
            this.xdgvData.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvData_OnFormattingCell);

            // активация постраничного просмотра
            this.xdgvData.CreatePageNavigator();

            //RefreshData();
        }

        void xdgvData_OnFilterChanged(object sender, EventArgs e)
        {
            this.xdgvData.RecalculateSummary();
        }

        void xdgvData_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
             if (e.RowIndex == -1)
                 return;

             var drContainer = (xdgvData.DataGrid.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;
             var hasWeight = drContainer["IOUB01"] != DBNull.Value && Convert.ToDouble(drContainer["IOUB01"]) > 0.0F;
             if (hasWeight)
             {
                 e.CellStyle.BackColor = Color.LightGreen;
                 e.CellStyle.SelectionForeColor = Color.LightGreen;
             }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            var loadWorker = new BackgroundWorker();
            loadWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    var searchParameters = e.Argument as TareWeighingSearchParameters;
                    this.xdgvData.DataView.FillData(searchParameters);
                   
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            };
            loadWorker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Result is Exception)
                    this.ShowError(e.Result as Exception);
                else
                {
                    this.xdgvData.BindData(false);
                    this.xdgvData.AllowSummary = true;
                }

                splashForm.CloseForce();
            };

            var sp = new TareWeighingSearchParameters();
            sp.SessionID = this.UserID;
            sp.ContainerID = (string)null;

            splashForm.ActionText = "Выполняется загрузка ящиков..";
            loadWorker.RunWorkerAsync(sp);
            splashForm.ShowDialog();
        }

        private void btnSetTareWeight_Click(object sender, EventArgs e)
        {
            while (true)
            {
                using (var dlgTareWeighing = new TareWeighingSetForm() { UserID = this.UserID })
                {
                    if (dlgTareWeighing.ShowDialog() == DialogResult.OK)
                        continue;
                    else
                        break;
                }
            }
        }

        #region ЭКСПОРТ ЛОГА ВЗВЕШИВАНИЯ

        private void btnExport_ButtonClick(object sender, EventArgs e)
        {
            btnExport.ShowDropDown();
        }

        private void miExportAll_Click(object sender, EventArgs e)
        {
            var filter = (string)null;
            ExportLog(filter);
        }

        private void miExportSelected_Click(object sender, EventArgs e)
        {
            if (!xdgvData.HasRows)
            {
                MessageBox.Show("Отсутствуют записи для выборочного экспорта.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!xdgvData.HasFilter)
            {
                MessageBox.Show("Для выборочного экспорта необходимо отфильтровать таблицу.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var sbFilter = new StringBuilder();
            foreach (DataGridViewRow dgvRow in xdgvData.DataGrid.Rows)
            {
                var dr = (dgvRow.DataBoundItem as DataRowView).Row;

                if (sbFilter.Length > 0)
                    sbFilter.AppendFormat(";{0}", dr["container_id"]);
                else
                    sbFilter.AppendFormat("{0}", dr["container_id"]);
            }

            var filter = sbFilter.ToString();
            ExportLog(filter);
        }

        private void ExportLog(string filter)
        {
            try
            {
                var dtLog = new Data.ItemsMeasurement.ContainersWeighingLogDataTable();

                using (var adapter = new Data.ItemsMeasurementTableAdapters.ContainersWeighingLogTableAdapter())
                    adapter.Fill(dtLog, this.UserID, filter);

                if (dtLog.Rows.Count > 0)
                {
                    var titles = new string[] { "Ш/К ящика", "Склад", "КНН", "Наименование", "Партия", "Вес", "Автор", "Дата" };
                    var columns = new string[] { "container_id", "mcu", "itm", "itm_name", "lotn", "weight", "users", "event_date" };
                    var saveFileDialogTitle = "Экспорт журнала взвешивания";
                    var namePart = string.Format("{0} журнал взвешивания тары", string.IsNullOrEmpty(filter) ? "Полный" : "Выборочный");

                    WMSOffice.Classes.ExportHelper.ExportDataTableToExcel(dtLog, titles, columns, saveFileDialogTitle, namePart, true);
                }
                else
                {
                    MessageBox.Show("По Вашему запросу отсутствуют данные журнала взвешивания.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        #endregion
    }

    /// <summary>
    /// Отображение тары
    /// </summary>
    public class TareWeighingView : IDataView
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
            var searchCriteria = searchParameters as TareWeighingSearchParameters;

            using (var adapter = new Data.ItemsMeasurementTableAdapters.ContainersTableAdapter())
                this.data = adapter.GetData(searchCriteria.SessionID, searchCriteria.ContainerID);
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ

        public TareWeighingView()
        {
            this.dataColumns.Add(new PatternColumn("Код склада", "IOMCU", new FilterPatternExpressionRule("IOMCU"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("КНН", "IOITM", new FilterCompareExpressionRule<Int32>("IOITM"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("Партия", "IOLOTN", new FilterPatternExpressionRule("IOLOTN")));

            this.dataColumns.Add(new PatternColumn("Тип ящика", "container_type", new FilterPatternExpressionRule("container_type"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("Описание типа ящика", "container_name", new FilterPatternExpressionRule("container_name"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("Ш/К ящика", "container_id", new FilterPatternExpressionRule("container_id")));

            this.dataColumns.Add(new PatternColumn("Вес ящика", "IOUB01", new FilterCompareExpressionRule<Double>("IOUB01")) { UseDecimalNumbersAlignment = true, Format = "N3" });
            this.dataColumns.Add(new PatternColumn("Дата взвешивания", "ReweightDate", new FilterDateCompareExpressionRule("ReweightDate")));
        }
        #endregion
    }

    /// <summary>
    /// Параметры поиска тары
    /// </summary>
    public class TareWeighingSearchParameters : SessionIDSearchParameters
    {
        public string ContainerID { get; set; }
    }
}
