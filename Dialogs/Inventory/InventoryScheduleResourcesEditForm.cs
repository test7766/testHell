using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Diagnostics;
using WMSOffice.Controls.ExtraDataGridViewComponents;

namespace WMSOffice.Dialogs.Inventory
{
    public partial class InventoryScheduleResourcesEditForm : DialogForm
    {
        public long? PlanID { get; private set; }

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        private readonly Data.Inventory.InventoriesScheduleRow _InventorySchedule = null;

        public InventoryScheduleResourcesEditForm()
        {
            InitializeComponent();
        }

        public InventoryScheduleResourcesEditForm(Data.Inventory.InventoriesScheduleRow inventorySchedule)
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

            //scPlannedResources.Panel1Collapsed = true;
            //scAvailableResources.Panel1Collapsed = true;

            //xdgvPlannedResources.Init(new PlannedResourcesView(), true);
            //xdgvPlannedResources.UserID = this.UserID;
            //xdgvPlannedResources.SetSameStyleForAlternativeRows();

            //xdgvPlannedResources.OnDataError += new DataGridViewDataErrorEventHandler(xdgvPlannedResources_OnDataError);
            //xdgvPlannedResources.OnRowSelectionChanged += new EventHandler(xdgvPlannedResources_OnRowSelectionChanged);
            //xdgvPlannedResources.OnFilterChanged += new EventHandler(xdgvPlannedResources_OnFilterChanged);
            //xdgvPlannedResources.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvPlannedResources_OnFormattingCell);

            xdgvAvailableResources.Init(new AvailableResourcesView(), true);
            xdgvAvailableResources.UserID = this.UserID;
            xdgvAvailableResources.SetSameStyleForAlternativeRows();

            xdgvAvailableResources.OnDataError += new DataGridViewDataErrorEventHandler(xdgvAvailableResources_OnDataError);
            xdgvAvailableResources.OnRowSelectionChanged += new EventHandler(xdgvAvailableResources_OnRowSelectionChanged);
            xdgvAvailableResources.OnRowDoubleClick += new DataGridViewCellEventHandler(xdgvAvailableResources_OnRowDoubleClick);
            xdgvAvailableResources.OnFilterChanged += new EventHandler(xdgvAvailableResources_OnFilterChanged);
            xdgvAvailableResources.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvAvailableResources_OnFormattingCell);

            this.SetOperationAccess();
            this.ReloadData();
        }

        void xdgvPlannedResources_OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        void xdgvPlannedResources_OnRowSelectionChanged(object sender, EventArgs e)
        {
            this.SetOperationAccess();
        }

        void xdgvAvailableResources_OnRowDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnEdit.Visible && btnEdit.Enabled)
                this.EditResource();
        }

        void xdgvPlannedResources_OnFilterChanged(object sender, EventArgs e)
        {
            xdgvPlannedResources.RecalculateSummary();
            this.SetOperationAccess();
        }

        void xdgvPlannedResources_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        void xdgvAvailableResources_OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        void xdgvAvailableResources_OnRowSelectionChanged(object sender, EventArgs e)
        {
            this.SetOperationAccess();
        }

        void xdgvAvailableResources_OnFilterChanged(object sender, EventArgs e)
        {
            xdgvAvailableResources.RecalculateSummary();
            this.SetOperationAccess();
        }

        void xdgvAvailableResources_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
        }

        private void SetOperationAccess()
        {
            //btnExport.Enabled = xdgvPlannedResources.HasRows;
            //btnCancelResource.Enabled = xdgvPlannedResources.SelectedItems.Count > 0;
            btnAssignResource.Enabled = xdgvAvailableResources.SelectedItems.Count > 0;
            btnEdit.Enabled = xdgvAvailableResources.SelectedItems.Count > 0;
            btnDelete.Enabled = xdgvAvailableResources.SelectedItems.Count > 0;
        }

        private void ReloadPlannedResources()
        {
            try
            {
                var searchParams = new PlannedResourcesSearchParameters() { SessionID = this.UserID, PlanID = this.PlanID };

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    this.xdgvPlannedResources.DataView.FillData(e.Argument as PlannedResourcesSearchParameters);
                };
                bw.RunWorkerCompleted += (s, e) =>
                {
                    if (e.Result is Exception)
                        MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        this.xdgvPlannedResources.BindData(false);

                        //this.xdgvPlannedResources.AllowFilter = true;
                        this.xdgvPlannedResources.AllowSummary = true;
                    }

                    splashForm.CloseForce();
                };

                splashForm.ActionText = "Подготовка запланированных ресурсов..";
                bw.RunWorkerAsync(searchParams);
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReloadAvailableResources()
        {
            try
            {
                var searchParams = new AvailableResourcesSearchParameters() { SessionID = this.UserID, PlanID = this.PlanID };

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    this.xdgvAvailableResources.DataView.FillData(e.Argument as AvailableResourcesSearchParameters);
                };
                bw.RunWorkerCompleted += (s, e) =>
                {
                    if (e.Result is Exception)
                        MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        this.xdgvAvailableResources.BindData(false);

                        //this.xdgvAvailableResources.AllowFilter = true;
                        this.xdgvAvailableResources.AllowSummary = true;
                    }

                    splashForm.CloseForce();
                };

                splashForm.ActionText = "Подготовка доступных ресурсов..";
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
            //this.ReloadPlannedResources();
            this.ReloadAvailableResources();
        }

        private void btnAssignResource_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    foreach (var row in xdgvAvailableResources.SelectedItems)
            //    {
            //        if (Convert.ToDecimal(row["is_free"]) != 1)
            //            continue;

            //        var stationID = Convert.ToInt64(row["station_id"]);

            //        using (var adapter = new Data.InventoryTableAdapters.InventorySchedulePlannedStationsTableAdapter())
            //            adapter.AddPlannedStation(this.UserID, this.PlanID, stationID);
            //    }

            //    this.ReloadData();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnCancelResource_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    foreach (var row in xdgvAvailableResources.SelectedItems)
            //    {
            //        var planDetailID = Convert.ToInt64(row["plnd_id"]);
            //        var stationID = Convert.ToInt64(row["station_id"]);

            //        using (var adapter = new Data.InventoryTableAdapters.InventorySchedulePlannedStationsTableAdapter())
            //            adapter.DeletePlannedStation(this.UserID, this.PlanID, planDetailID, stationID);
            //    }

            //    this.ReloadData();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //using (SaveFileDialog dlgSelectFile = new SaveFileDialog())
            //{
            //    dlgSelectFile.Title = "Экспорт запланированных ресурсов";

            //    DateTime now = DateTime.Now;
            //    dlgSelectFile.FileName = string.Format("{0}{1}{2}{3}{4}{5}-Запланированные ресурсы",
            //        now.Year.ToString(),
            //        now.Month.ToString().PadLeft(2, '0'),
            //        now.Day.ToString().PadLeft(2, '0'),
            //        now.Hour.ToString().PadLeft(2, '0'),
            //        now.Minute.ToString().PadLeft(2, '0'),
            //        now.Second.ToString().PadLeft(2, '0')
            //        );

            //    dlgSelectFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //    dlgSelectFile.Filter = "Текстовый файл с разделителями (*.csv)|*.csv";//;*.csv|Все файлы (*.*)|*.*";
            //    dlgSelectFile.FilterIndex = 0;
            //    dlgSelectFile.AddExtension = true;
            //    dlgSelectFile.DefaultExt = "csv";
            //    if (dlgSelectFile.ShowDialog() == DialogResult.OK)
            //    {
            //        try
            //        {
            //            this.xdgvPlannedResources.ExportToExcel(dlgSelectFile.FileName);
            //            Process.Start(dlgSelectFile.FileName);
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //}
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
                            if (cells.Length >= 2)
                            {
                                int resourceID;
                                if (!int.TryParse(cells[0], out resourceID))
                                    throw new Exception("Код ресурса должен быть числом.");

                                int establishID;
                                if (!int.TryParse(cells[1], out establishID))
                                    throw new Exception("Код типа ресурса должен быть числом.");

                                var node = (XmlElement)root.AppendChild(doc.CreateElement("Item"));
                                node.SetAttribute("ResourceID", resourceID.ToString());
                                node.SetAttribute("EstablishID", establishID.ToString());
                            }
                            else
                                throw new Exception("Неверная структура импортируемых данных.");
                        }

                        using (var adapter = new Data.InventoryTableAdapters.InventoryScheduleAvailableResourcesTableAdapter())
                            adapter.AddAvailableResource(this.UserID, this.PlanID, doc.InnerXml);
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

                splashForm.ActionText = "Импорт доступных ресурсов..";
                importWorker.RunWorkerAsync(sText);
                splashForm.ShowDialog();

                if (importCompleted)
                    ReloadAvailableResources();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.EditResource();
        }

        private void EditResource()
        {
            try
            {
                var row = xdgvAvailableResources.SelectedItem;
                var resourceID = Convert.ToInt64(row["plnrs_id"]);

                var dlgSelectUnit = new WMSOffice.Dialogs.RichListForm();
                dlgSelectUnit.Text = "Выберите роль (тип ресурса)";
                dlgSelectUnit.AddColumn("establish_id", "establish_id", "Код");
                dlgSelectUnit.AddColumn("establish_name", "establish_name", "Наименование");
                dlgSelectUnit.FilterChangeLevel = 0;
                dlgSelectUnit.FilterVisible = false;

                var table = new Data.Inventory.InventoryScheduleResourcesEstablishUnitsDataTable();

                using (var adapter = new Data.InventoryTableAdapters.InventoryScheduleResourcesEstablishUnitsTableAdapter())
                    adapter.Fill(table, this.UserID, this.PlanID);

                dlgSelectUnit.DataSource = table;

                if (dlgSelectUnit.ShowDialog() != DialogResult.OK)
                    return;

                var establishID = (dlgSelectUnit.SelectedRow as Data.Inventory.InventoryScheduleResourcesEstablishUnitsRow).establish_id;

                using (var adapter = new Data.InventoryTableAdapters.InventoryScheduleAvailableResourcesTableAdapter())
                    adapter.EditAvailableResource(this.UserID, this.PlanID, resourceID, establishID);

                ReloadAvailableResources();
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
                var row = xdgvAvailableResources.SelectedItem;
                var resourceID = Convert.ToInt64(row["plnrs_id"]);

                using (var adapter = new Data.InventoryTableAdapters.InventoryScheduleAvailableResourcesTableAdapter())
                    adapter.DeleteAvailableResource(this.UserID, this.PlanID, resourceID);

                ReloadAvailableResources();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    /// <summary>
    /// Представление для запланированных ресурсов
    /// </summary>
    [Obsolete]
    public class PlannedResourcesView : IDataView
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
            var searchCriteria = searchParameters as PlannedResourcesSearchParameters;

            //using (var adapter = new Data.InventoryTableAdapters.InventorySchedulePlannedStationsTableAdapter())
            //    this.data = adapter.GetData(searchCriteria.SessionID, searchCriteria.PlanID);
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ
        public PlannedResourcesView()
        {
           
        }
        #endregion
    }

    /// <summary>
    /// Критерий поиска
    /// </summary>
    [Obsolete]
    public class PlannedResourcesSearchParameters : SessionIDSearchParameters
    {
        public long? PlanID { get; set; }
    }

    /// <summary>
    /// Представление для доступных ресурсов
    /// </summary>
    public class AvailableResourcesView : IDataView
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
            var searchCriteria = searchParameters as AvailableResourcesSearchParameters;

            using (var adapter = new Data.InventoryTableAdapters.InventoryScheduleAvailableResourcesTableAdapter())
                this.data = adapter.GetData(searchCriteria.SessionID, searchCriteria.PlanID);
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ
        public AvailableResourcesView()
        {
            this.dataColumns.Add(new PatternColumn("Код ресурса", "resource_id", new FilterPatternExpressionRule("resource_id"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("Ресурс", "resource_name", new FilterPatternExpressionRule("resource_name")));
            this.dataColumns.Add(new PatternColumn("Код типа ресурса", "establish_id", new FilterCompareExpressionRule<Int32>("establish_id")));
            this.dataColumns.Add(new PatternColumn("Тип ресурса", "staff_name", new FilterPatternExpressionRule("staff_name")));
        }
        #endregion
    }

    /// <summary>
    /// Критерий поиска
    /// </summary>
    public class AvailableResourcesSearchParameters : SessionIDSearchParameters
    {
        public long? PlanID { get; set; }
    }
}
