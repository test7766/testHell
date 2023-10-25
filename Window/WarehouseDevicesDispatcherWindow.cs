using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Controls;

namespace WMSOffice.Window
{
    public partial class WarehouseDevicesDispatcherWindow : GeneralWindow
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        public WarehouseDevicesDispatcherWindow()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Initialize();
            this.ReloadData();
        }

        private void Initialize()
        {
            xdgvClusters.UseMultiSelectMode = false;
            xdgvClusters.AllowSummary = false;
            xdgvClusters.AllowRangeColumns = false;

            xdgvClusters.Init(new DevicesGroupsServicesView(), true);
            xdgvClusters.UserID = this.UserID;

            xdgvClusters.OnDataError += new DataGridViewDataErrorEventHandler(xdgvClusters_OnDataError);
            xdgvClusters.OnRowSelectionChanged += new EventHandler(xdgvClusters_OnRowSelectionChanged);
            xdgvClusters.OnFilterChanged += new EventHandler(xdgvClusters_OnFilterChanged);
            xdgvClusters.OnCellContentClick += new DataGridViewCellEventHandler(xdgvClusters_OnCellContentClick);
            xdgvClusters.OnMultiRowsSelectionChanged += new EventHandler<DataGridViewCheckBoxHeaderCellEventArgs>(xdgvClusters_OnMultiRowsSelectionChanged);
            xdgvClusters.OnCustomSummaryCalculation += new EventHandler<СustomSummaryCalculationEventArgs>(xdgvClusters_OnСustomSummaryCalculation);
            xdgvClusters.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvClusters_OnFormattingCell);


            xdgvClusterItems.AllowSummary = false;

            xdgvClusterItems.Init(new DevicesGroupsServicesItemsView(), true);
            xdgvClusterItems.UserID = this.UserID;

            xdgvClusterItems.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvClusterItems_OnFormattingCell);

            this.SetOperationAccess();
        }

        void xdgvClusters_OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        void xdgvClusters_OnRowSelectionChanged(object sender, EventArgs e)
        {
            this.LoadDetails();
        }

        void xdgvClusters_OnFilterChanged(object sender, EventArgs e)
        {
            xdgvClusters.RecalculateSummary();
        }

        void xdgvClusters_OnCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (xdgvClusters.DataGrid.Columns[e.ColumnIndex].DataPropertyName == "IsChecked")
                {
                    var row = (xdgvClusters.DataGrid.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;

                    var isActive = Convert.ToBoolean(row["IsActive"]);
                    if (!isActive)
                        return;

                    var keyValue = row["GroupID"];

                    var isChecked = Convert.ToBoolean(row["IsChecked"]);

                    if (this.xdgvClusters.ChangeRowPropertyValue("GroupID", keyValue, "IsChecked", !isChecked))
                    {
                        row["IsChecked"] = !isChecked;
                        this.xdgvClusters.RecalculateSummary();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.SetOperationAccess();
            }
        }

        void xdgvClusters_OnMultiRowsSelectionChanged(object sender, DataGridViewCheckBoxHeaderCellEventArgs e)
        {
            try
            {
                if (this.xdgvClusters.ChangeMultipleRowsPropertyValue("IsChecked", e.Checked))
                {
                    foreach (DataGridViewRow dgRow in xdgvClusters.DataGrid.Rows)
                    {
                        var row = (dgRow.DataBoundItem as DataRowView).Row;

                        var isActive = Convert.ToBoolean(row["IsActive"]);
                        if (!isActive)
                        {
                            row["IsChecked"] = false;
                            continue;
                        }

                        row["IsChecked"] = e.Checked;
                    }

                    this.xdgvClusters.RecalculateSummary();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.SetOperationAccess();
            }
        }

        void xdgvClusters_OnСustomSummaryCalculation(object sender, СustomSummaryCalculationEventArgs e)
        {
            try
            {
                if (e.PatternСolumn.DataFieldName == "IsChecked")
                {
                    var cntCheckedRows = 0;
                    foreach (DataRow dataRow in e.FilteredFullDataRows)
                    {
                        if (dataRow["IsChecked"].Equals(true))
                            cntCheckedRows++;
                    }

                    e.TargetCell.Value = cntCheckedRows;
                    e.TargetCell.Style.BackColor = e.TargetCell.Style.SelectionBackColor = cntCheckedRows > 0 ? Color.FromArgb(209, 255, 117) : SystemColors.Window;
                    e.TargetCell.Style.ForeColor = e.TargetCell.Style.SelectionForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {

            }
        }

        void xdgvClusters_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            // Раскраска
            bool isChecked = Convert.ToBoolean(this.xdgvClusters.DataGrid.Rows[e.RowIndex].Cells[0].Value);
            this.xdgvClusters.DataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = isChecked ? Color.FromArgb(209, 255, 117) : SystemColors.Window;
            this.xdgvClusters.DataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = isChecked ? Color.FromArgb(209, 255, 117) : Color.Black;


            var boundRow = (xdgvClusters.DataGrid.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;

            var isActive = Convert.ToBoolean(boundRow["IsActive"]);
            if (!isActive)
            {
                var color = Color.LightPink;
                e.CellStyle.BackColor = color;
                e.CellStyle.SelectionForeColor = color;
                //e.CellStyle.SelectionBackColor = color;
            }
        }

        void xdgvClusterItems_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            var boundRow = (xdgvClusterItems.DataGrid.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;

            var isActive = Convert.ToBoolean(boundRow["IsActive"]);
            if (!isActive)
            {
                var color = Color.LightPink;
                e.CellStyle.BackColor = color;
                e.CellStyle.SelectionForeColor = color;
                //e.CellStyle.SelectionBackColor = color;
            }
        }

        private void SetOperationAccess()
        {
            var hasCheckedItems = false;

            if (xdgvClusters.DataView.Data != null)
            {
                //foreach (DataGridViewRow row in xdgvClusters.DataGrid.Rows)
                foreach (DataRow item in xdgvClusters.DataView.Data.Rows)
                {
                    //if (Convert.ToBoolean((row.DataBoundItem as DataRowView).Row["IsChecked"]))
                    if (Convert.ToBoolean(item["IsChecked"]))
                    {
                        hasCheckedItems = true;
                        continue;
                    }
                }
            }

            btnRestart.Enabled = hasCheckedItems;
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.ReloadData();
        }

        private void ReloadData()
        {
            try
            {
                var searchParams = new DevicesGroupsServicesSearchParameters() { SessionID = this.UserID };

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    this.xdgvClusters.DataView.FillData(e.Argument as DevicesGroupsServicesSearchParameters);
                };
                bw.RunWorkerCompleted += (s, e) =>
                {
                    if (e.Result is Exception)
                        this.ShowError(e.Result as Exception);
                    else
                    {
                        this.xdgvClusters.BindData(false);

                        //this.xdgvClusters.AllowFilter = true;
                        this.xdgvClusters.AllowSummary = true;
                    }

                    splashForm.CloseForce();
                };

                splashForm.ActionText = "Выполняется получение кластеров..";
                bw.RunWorkerAsync(searchParams);
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void LoadDetails()
        {
            try
            {
                var groupID = xdgvClusters.SelectedItem == null ? (int?)null : Convert.ToInt32(xdgvClusters.SelectedItem["GroupID"]);

                var searchParams = new DevicesGroupsServicesItemsSearchParameters() { SessionID = this.UserID, GroupID = groupID };

                using (var splashForm = new WMSOffice.Dialogs.SplashForm())
                {
                    var bw = new BackgroundWorker();
                    bw.DoWork += (s, e) =>
                    {
                        this.xdgvClusterItems.DataView.FillData(e.Argument as DevicesGroupsServicesItemsSearchParameters);
                    };
                    bw.RunWorkerCompleted += (s, e) =>
                    {
                        if (e.Result is Exception)
                            this.ShowError(e.Result as Exception);
                        else
                        {
                            this.xdgvClusterItems.BindData(false);

                            //this.xdgvClusterItems.AllowFilter = true;
                            this.xdgvClusterItems.AllowSummary = true;
                        }

                        splashForm.CloseForce();
                    };

                    splashForm.ActionText = "Выполняется получение зон кластера..";
                    bw.RunWorkerAsync(searchParams);
                    splashForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            this.Restart();
        }

        private void Restart()
        {
            try
            {
                var lstActiveGroupIDs = new List<int>();
                var lstCheckedGroupIDs = new List<int>();

                foreach (DataRow item in xdgvClusters.DataView.Data.Rows)
                {
                    if (Convert.ToBoolean(item["IsActive"]))
                        lstActiveGroupIDs.Add(Convert.ToInt32(item["GroupID"]));

                    if (Convert.ToBoolean(item["IsChecked"]))
                        lstCheckedGroupIDs.Add(Convert.ToInt32(item["GroupID"]));
                }

                var canRestart = true;
                if (lstActiveGroupIDs.Count == lstCheckedGroupIDs.Count && MessageBox.Show("Перезапустить все сервисы?", "Внимание",  MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                    canRestart = false;

                if (canRestart)
                {
                    foreach (var groupID in lstCheckedGroupIDs)
                        using (var adapter = new Data.WHTableAdapters.DTS_DW_Get_Devices_Groups_ServicesTableAdapter())
                            adapter.CreateReloadTask(this.UserID, groupID);

                    MessageBox.Show("Перезапуск сервисов произойдет в течении минуты.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }
    }

    /// <summary>
    /// Представление для списка кластеров с привязкой к логгерам
    /// </summary>
    public class DevicesGroupsServicesView : IDataView
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
            var searchCriteria = searchParameters as DevicesGroupsServicesSearchParameters;

            using (var adapter = new Data.WHTableAdapters.DTS_DW_Get_Devices_Groups_ServicesTableAdapter())
                this.data = adapter.GetData(searchCriteria.SessionID);
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ
        public DevicesGroupsServicesView()
        {
            this.dataColumns.Add(new SelectorPatternColumn("Отм.", "IsChecked", new FilterBoolCompareExpressionRule("IsChecked"), SummaryCalculationType.Custom) { Width = 35 });

            this.dataColumns.Add(new PatternColumn("Код", "GroupID", new FilterCompareExpressionRule<Int32>("GroupID"), SummaryCalculationType.Count) { Width = 40, UseIntegerNumbersAlignment = true });
            this.dataColumns.Add(new PatternColumn("Описание кластера", "GroupName", new FilterPatternExpressionRule("GroupName")) { Width = 400 });
            this.dataColumns.Add(new PatternColumn("Название группы", "ServiceGroupName", new FilterPatternExpressionRule("ServiceGroupName"), SummaryCalculationType.Count) { Width = 120 });
            this.dataColumns.Add(new PatternColumn("Название сервиса", "ServiceName", new FilterPatternExpressionRule("ServiceName")) { Width = 300 });
            this.dataColumns.Add(new PatternColumn("Имя сервера", "ServiceLocation", new FilterPatternExpressionRule("ServiceLocation"), SummaryCalculationType.Count) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Дата перезапуска", "LastReloadDate", new FilterDateCompareExpressionRule("LastReloadDate")) { Width = 130 });
        }
        #endregion
    }

    /// <summary>
    /// Критерий поиска
    /// </summary>
    public class DevicesGroupsServicesSearchParameters : SessionIDSearchParameters
    {
       
    }


    /// <summary>
    /// Представление для списка кластеров с привязкой к логгерам
    /// </summary>
    public class DevicesGroupsServicesItemsView : IDataView
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
            var searchCriteria = searchParameters as DevicesGroupsServicesItemsSearchParameters;

            using (var adapter = new Data.WHTableAdapters.DTS_DW_Get_Devices_Groups_Services_ItemsTableAdapter())
                this.data = adapter.GetData(searchCriteria.SessionID, searchCriteria.GroupID);
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ
        public DevicesGroupsServicesItemsView()
        {
            this.dataColumns.Add(new PatternColumn("Код", "DeviceName", new FilterPatternExpressionRule("DeviceName")) { Width = 150 });
            this.dataColumns.Add(new PatternColumn("Название станции", "DeviceLocation", new FilterPatternExpressionRule("DeviceLocation"), SummaryCalculationType.Count) { Width = 400 });
        }
        #endregion
    }

    /// <summary>
    /// Критерий поиска
    /// </summary>
    public class DevicesGroupsServicesItemsSearchParameters : SessionIDSearchParameters
    {
        public int? GroupID { get; set; }
    }
}
