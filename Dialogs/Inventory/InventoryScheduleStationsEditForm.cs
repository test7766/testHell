using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using System.Diagnostics;
using System.Xml;

namespace WMSOffice.Dialogs.Inventory
{
    public partial class InventoryScheduleStationsEditForm : DialogForm
    {
        public long? PlanID { get; private set; }

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        private readonly Data.Inventory.InventoriesScheduleRow _InventorySchedule = null;

        private CheckBox cbShowOnlyFree = null;

        public InventoryScheduleStationsEditForm()
        {
            InitializeComponent();
        }

        public InventoryScheduleStationsEditForm(Data.Inventory.InventoriesScheduleRow inventorySchedule)
            : this()
        {
            _InventorySchedule = inventorySchedule;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(1017, 8);
            this.btnCancel.Location = new Point(1107, 8);

            this.btnOK.Visible = false;
            this.btnCancel.Text = "Закрыть";

            this.Initialize();

            this.WindowState = FormWindowState.Maximized;
        }

        private void Initialize()
        {
            this.Text = string.Format("{0} [{1}]", this.Text, _InventorySchedule.pln_id.ToString());
            this.PlanID = _InventorySchedule.pln_id;

            var host = new ToolStripControlHost((cbShowOnlyFree = new CheckBox { Text = "Отобразить только доступные станции" }));
            cbShowOnlyFree.Checked = true;
            cbShowOnlyFree.CheckedChanged += (s, e) => { this.ReloadAvailableStations(); };
            tsAvailableStations.Items.Add(host);

            xdgvPlannedStations.Init(new PlannedStationsView(), true);
            xdgvPlannedStations.UserID = this.UserID;
            xdgvPlannedStations.UseMultiSelectMode = true;
            xdgvPlannedStations.SetSameStyleForAlternativeRows();

            xdgvPlannedStations.OnDataError += new DataGridViewDataErrorEventHandler(xdgvPlannedStations_OnDataError);
            xdgvPlannedStations.OnRowSelectionChanged += new EventHandler(xdgvPlannedStations_OnRowSelectionChanged);
            xdgvPlannedStations.OnFilterChanged += new EventHandler(xdgvPlannedStations_OnFilterChanged);
            xdgvPlannedStations.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvPlannedStations_OnFormattingCell);

            xdgvAvailableStations.Init(new AvailableStationsView(), true);
            xdgvAvailableStations.UserID = this.UserID;
            xdgvAvailableStations.UseMultiSelectMode = true;
            xdgvAvailableStations.SetSameStyleForAlternativeRows();

            xdgvAvailableStations.OnDataError += new DataGridViewDataErrorEventHandler(xdgvAvailableStations_OnDataError);
            xdgvAvailableStations.OnRowSelectionChanged += new EventHandler(xdgvAvailableStations_OnRowSelectionChanged);
            xdgvAvailableStations.OnFilterChanged += new EventHandler(xdgvAvailableStations_OnFilterChanged);
            xdgvAvailableStations.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvAvailableStations_OnFormattingCell);

            this.SetOperationAccess();
            this.ReloadData();
        }

        void xdgvPlannedStations_OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        void xdgvPlannedStations_OnRowSelectionChanged(object sender, EventArgs e)
        {
            this.SetOperationAccess();
        }

        void xdgvPlannedStations_OnFilterChanged(object sender, EventArgs e)
        {
            xdgvPlannedStations.RecalculateSummary();
            this.SetOperationAccess();
        }

        void xdgvPlannedStations_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        void xdgvAvailableStations_OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }       

        void xdgvAvailableStations_OnRowSelectionChanged(object sender, EventArgs e)
        {
            this.SetOperationAccess();
        }

        void xdgvAvailableStations_OnFilterChanged(object sender, EventArgs e)
        {
            xdgvAvailableStations.RecalculateSummary();
            this.SetOperationAccess();
        }

        void xdgvAvailableStations_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grid = sender as DataGridView;

            DataRow row = (grid.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;

            #region СТИЛЬ ДЛЯ НЕДОСТУПНЫХ СТАНЦИЙ
            if (row["is_free"] != DBNull.Value)
            {
                decimal value;
                if (Decimal.TryParse(row["is_free"].ToString(), out value))
                {
                    if (value == 0)
                    {
                        e.CellStyle.ForeColor = Color.Gray;
                        e.CellStyle.SelectionBackColor = Color.Gray;
                    }
                }
            }
            #endregion
        }

        private void SetOperationAccess()
        {
            btnExport.Enabled = xdgvPlannedStations.HasRows;
            btnCancelStation.Enabled = xdgvPlannedStations.SelectedItems.Count > 0;
            btnAssignStation.Enabled = xdgvAvailableStations.SelectedItems.Count > 0;
            btnDelete.Enabled = xdgvAvailableStations.SelectedItems.Count > 0;
        }

        private void ReloadPlannedStations()
        {
            try
            {
                var searchParams = new PlannedStationsSearchParameters() { SessionID = this.UserID, PlanID = this.PlanID };

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    this.xdgvPlannedStations.DataView.FillData(e.Argument as PlannedStationsSearchParameters);
                };
                bw.RunWorkerCompleted += (s, e) =>
                {
                    if (e.Result is Exception)
                        MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        this.xdgvPlannedStations.BindData(false);

                        //this.xdgvPlannedStations.AllowFilter = true;
                        this.xdgvPlannedStations.AllowSummary = true;
                    }

                    splashForm.CloseForce();
                };

                splashForm.ActionText = "Подготовка запланированных станций..";
                bw.RunWorkerAsync(searchParams);
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReloadAvailableStations()
        {
            try
            {
                var searchParams = new AvailableStationsSearchParameters() { SessionID = this.UserID, PlanID = this.PlanID, OnlyFree = cbShowOnlyFree.Checked };

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    this.xdgvAvailableStations.DataView.FillData(e.Argument as AvailableStationsSearchParameters);
                };
                bw.RunWorkerCompleted += (s, e) =>
                {
                    if (e.Result is Exception)
                        MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        this.xdgvAvailableStations.BindData(false);

                        //this.xdgvAvailableStations.AllowFilter = true;
                        this.xdgvAvailableStations.AllowSummary = true;
                    }

                    splashForm.CloseForce();
                };

                splashForm.ActionText = "Подготовка доступных станций..";
                bw.RunWorkerAsync(searchParams);
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReloadData()
        {
            this.ReloadPlannedStations();
            this.ReloadAvailableStations();
        }

        private void btnAssignStation_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var row in xdgvAvailableStations.SelectedItems)
                {
                    if (Convert.ToDecimal(row["is_free"]) != 1)
                        continue;

                    var stationID = Convert.ToInt64(row["station_id"]);

                    using (var adapter = new Data.InventoryTableAdapters.InventorySchedulePlannedStationsTableAdapter())
                        adapter.AddPlannedStation(this.UserID, this.PlanID, stationID);
                }

                this.ReloadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelStation_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var row in xdgvPlannedStations.SelectedItems)
                {
                    var planDetailID = Convert.ToInt64(row["plnd_id"]);
                    var stationID = Convert.ToInt64(row["station_id"]);

                    using (var adapter = new Data.InventoryTableAdapters.InventorySchedulePlannedStationsTableAdapter())
                        adapter.DeletePlannedStation(this.UserID, this.PlanID, planDetailID, stationID);
                }

                this.ReloadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlgSelectFile = new SaveFileDialog())
            {
                dlgSelectFile.Title = "Экспорт запланированных станций";

                DateTime now = DateTime.Now;
                dlgSelectFile.FileName = string.Format("{0}{1}{2}{3}{4}{5}-Запланированные станции",
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
                        this.xdgvPlannedStations.ExportToExcel(dlgSelectFile.FileName);
                        Process.Start(dlgSelectFile.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                var sText = Clipboard.GetText() ?? string.Empty;
                if (string.IsNullOrEmpty(sText.Trim()))
                    throw new Exception("Отсутствуют данные для импорта.");

                var importCompleted = false;

                var importWorker = new BackgroundWorker();
                importWorker.DoWork += delegate(object snd, DoWorkEventArgs ea)
                {
                    try
                    {
                        var text = ea.Argument.ToString();

                        var doc = new XmlDocument();
                        var root = (XmlElement)doc.AppendChild(doc.CreateElement("Root"));

                        foreach (var line in text.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            var cells = line.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                            if (cells.Length >= 1)
                            {
                                int stationID;
                                if (!int.TryParse(cells[0], out stationID))
                                    throw new Exception("Код станции должен быть числом.");

                                var node = (XmlElement)root.AppendChild(doc.CreateElement("Item"));
                                node.SetAttribute("StationID", stationID.ToString());
                            }
                            else
                                throw new Exception("Неверная структура импортируемых данных.");
                        }

                        using (var adapter = new Data.InventoryTableAdapters.InventoryScheduleAvailableStationsTableAdapter())
                                adapter.AddAvailableStation(this.UserID, this.PlanID, doc.InnerXml);
                    }
                    catch (Exception ex)
                    {
                        ea.Result = ex;
                    }
                };

                importWorker.RunWorkerCompleted += delegate(object snd, RunWorkerCompletedEventArgs ea)
                {
                    if (ea.Result is Exception)
                        MessageBox.Show((ea.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        importCompleted = true;

                    splashForm.CloseForce();
                };

                splashForm.ActionText = "Импорт доступных станций..";
                importWorker.RunWorkerAsync(sText);
                splashForm.ShowDialog();

                if (importCompleted)
                    ReloadAvailableStations();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var row in xdgvAvailableStations.SelectedItems)
                {
                    if (Convert.ToDecimal(row["is_free"]) != 1)
                        continue;

                    var stationID = Convert.ToInt64(row["station_id"]);

                    using (var adapter = new Data.InventoryTableAdapters.InventoryScheduleAvailableStationsTableAdapter())
                        adapter.DeleteAvailableStation(this.UserID, this.PlanID, stationID);
                }

                ReloadAvailableStations();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }


    /// <summary>
    /// Представление для запланированных станций
    /// </summary>
    public class PlannedStationsView : IDataView
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
            var searchCriteria = searchParameters as PlannedStationsSearchParameters;

            using (var adapter = new Data.InventoryTableAdapters.InventorySchedulePlannedStationsTableAdapter())
                this.data = adapter.GetData(searchCriteria.SessionID, searchCriteria.PlanID);
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ
        public PlannedStationsView()
        {
            this.dataColumns.Add(new PatternColumn("ID", "plnd_id", new FilterCompareExpressionRule<Int32>("plnd_id"), SummaryCalculationType.Count));

            this.dataColumns.Add(new PatternColumn("Код склада", "warehouse_id", new FilterPatternExpressionRule("warehouse_id")));

            this.dataColumns.Add(new PatternColumn("Ш/К станции", "station_code", new FilterPatternExpressionRule("station_code")));
            this.dataColumns.Add(new PatternColumn("Станция", "station_description", new FilterPatternExpressionRule("station_description")));

            this.dataColumns.Add(new PatternColumn("Этаж", "stage_name", new FilterPatternExpressionRule("stage_name")));
        }
        #endregion
    }

    /// <summary>
    /// Критерий поиска
    /// </summary>
    public class PlannedStationsSearchParameters : SessionIDSearchParameters
    {
        public long? PlanID { get; set; }
    }

    /// <summary>
    /// Представление для доступных станций
    /// </summary>
    public class AvailableStationsView : IDataView
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
            var searchCriteria = searchParameters as AvailableStationsSearchParameters;

            using (var adapter = new Data.InventoryTableAdapters.InventoryScheduleAvailableStationsTableAdapter())
                this.data = adapter.GetData(searchCriteria.SessionID, searchCriteria.PlanID, searchCriteria.OnlyFree);
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ
        public AvailableStationsView()
        {
            this.dataColumns.Add(new PatternColumn("Код склада", "warehouse_id", new FilterPatternExpressionRule("warehouse_id")));

            this.dataColumns.Add(new PatternColumn("Ш/К станции", "station_code", new FilterPatternExpressionRule("station_code"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("Станция", "station_description", new FilterPatternExpressionRule("station_description")));

            this.dataColumns.Add(new PatternColumn("Этаж", "stage_name", new FilterPatternExpressionRule("stage_name")));

            this.dataColumns.Add(new PatternColumn("Место \"с\"", "place_start", new FilterPatternExpressionRule("place_start")));
            this.dataColumns.Add(new PatternColumn("Место \"по\"", "place_finish", new FilterPatternExpressionRule("place_finish")));
        }
        #endregion
    }

    /// <summary>
    /// Критерий поиска
    /// </summary>
    public class AvailableStationsSearchParameters : SessionIDSearchParameters
    {
        public long? PlanID { get; set; }
        public bool? OnlyFree { get; set; }
    }
}
