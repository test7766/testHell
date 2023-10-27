using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.ExtraDataGridViewComponents;

namespace WMSOffice.Dialogs.Inventory
{
    public partial class InventoryMonitoringForm : DialogForm
    {
        private const int RESPONSE_WAIT_TIMEOUT = 300; // 5 минут

        /// <summary>
        /// Ид-р документа инвентаризации
        /// </summary>
        public long InventoryDocID { get; set; }

        /// <summary>
        /// Список для хранения индикации загрузки страницы статистики
        /// </summary>
        private List<bool> lstLoadingCompleted = new List<bool>();

        private SplashForm waitProgressForm = new SplashForm();

        public bool UseFilialSearchMode { get; set; }

        public InventoryMonitoringForm()
        {
            InitializeComponent();
            this.Initialize();

            foreach (var page in this.tcMonitoringLayout.TabPages)
                lstLoadingCompleted.Add(false);
        }

        private void Initialize()
        {
            #region Инициализация итогов по зонам 
            this.dgvTotalZones.Rows.Clear();
            this.dgvTotalZones.Columns.Clear();
            foreach (DataGridViewColumn column in this.dgvZones.Columns)
            {
                var newColumn = new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = column.DataPropertyName,
                    Width = column.Width,
                    Visible = column.Visible,
                };

                if (column.GetType() == typeof(DataGridViewTextBoxColumn))
                    newColumn.DefaultCellStyle = column.DefaultCellStyle;

                this.dgvTotalZones.Columns.Add(newColumn);
            }

            this.dgvTotalZones.Rows.Add(1);
            #endregion

            #region Инициализация итогов по бригадам
            this.dgvTotalTeams.Rows.Clear();
            this.dgvTotalTeams.Columns.Clear();
            foreach (DataGridViewColumn column in this.dgvTeams.Columns)
            {
                var newColumn = new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = column.DataPropertyName,
                    Width = column.Width,
                    Visible = column.Visible,
                };

                if (column.GetType() == typeof(DataGridViewTextBoxColumn))
                    newColumn.DefaultCellStyle = column.DefaultCellStyle;

                this.dgvTotalTeams.Columns.Add(newColumn);
            }

            this.dgvTotalTeams.Rows.Add(1);
            #endregion

            #region Инициализация представления по станциям

            xdgvStations.DataGrid.DefaultCellStyle = dgvStations.DefaultCellStyle;
            xdgvStations.DataGrid.ColumnHeadersDefaultCellStyle = dgvStations.ColumnHeadersDefaultCellStyle;

            xdgvStations.Init(new InventoryProgressByStationView(), true);
            xdgvStations.UserID = UserID;

            xdgvStations.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvStations_OnFormattingCell);
            xdgvStations.OnFilterChanged += new EventHandler(xdgvStations_OnFilterChanged);
            #endregion
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            btnOK.Location = new Point(1050, 8);
            btnCancel.Location = new Point(1140, 8);
            btnCancel.Text = "Закрыть";

            tcMonitoringLayout.SelectedIndex = -1;
            tcMonitoringLayout.SelectedIndex = 0;
        }

        /// <summary>
        /// Загрузка статистики о ходе проведения инвентаризации (основная информация)
        /// </summary>
        private void LoadGeneralStatistics()
        {
            this.LoadGeneralHeaderData();
            this.LoadStatisticsByCounts();
        }

        /// <summary>
        /// Загрузка данных (заголовок основной статистики)
        /// </summary>
        private void LoadGeneralHeaderData()
        {
            BackgroundWorker loadworker = new BackgroundWorker();
            loadworker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    this.inventoryProgressHeaderTableAdapter.SetTimeout(RESPONSE_WAIT_TIMEOUT);
                    e.Result = this.UseFilialSearchMode ? this.inventoryProgressHeaderTableAdapter.GetDataByFilial(this.UserID, this.InventoryDocID) : this.inventoryProgressHeaderTableAdapter.GetData(this.UserID, this.InventoryDocID);
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            };
            loadworker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Result is Exception)
                    MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    this.inventoryProgressHeaderBindingSource.DataSource = e.Result;

                waitProgressForm.CloseForce();
            };

            waitProgressForm.ActionText = "Выполняется формирование основной статистики..";
            loadworker.RunWorkerAsync();
            waitProgressForm.ShowDialog();
        }

        /// <summary>
        /// Загрузка деталей общей статистики о ходе проведения инвентаризации (по пересчетам)
        /// </summary>
        private void LoadStatisticsByCounts()
        {
            BackgroundWorker loadworker = new BackgroundWorker();
            loadworker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    this.inventoryProgressByLocationsTableAdapter.SetTimeout(RESPONSE_WAIT_TIMEOUT);
                    e.Result = this.UseFilialSearchMode ? this.inventoryProgressByLocationsTableAdapter.GetDataByFilial(this.UserID, this.InventoryDocID) : this.inventoryProgressByLocationsTableAdapter.GetData(this.UserID, this.InventoryDocID);
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            };
            loadworker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Result is Exception)
                    MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    this.inventory.InventoryProgressByLocations.Clear();
                    this.inventory.InventoryProgressByLocations.Merge(e.Result as DataTable);
                    this.inventoryProgressByLocationsBindingSource.DataSource = e.Result;
                }

                waitProgressForm.CloseForce();
            };

            waitProgressForm.ActionText = "Выполняется формирование деталей статистики пересчетов..";
            loadworker.RunWorkerAsync();
            waitProgressForm.ShowDialog();
        }

        /// <summary>
        /// Загрузка статистики рейтинга побригадно
        /// </summary>
        private void LoadStatisticsByTeams()
        {
            BackgroundWorker loadworker = new BackgroundWorker();
            loadworker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    this.inventoryProgressByTeamsTableAdapter.SetTimeout(RESPONSE_WAIT_TIMEOUT);
                    e.Result = this.UseFilialSearchMode ? this.inventoryProgressByTeamsTableAdapter.GetDataByFilial(this.UserID, this.InventoryDocID) : this.inventoryProgressByTeamsTableAdapter.GetData(this.UserID, this.InventoryDocID);
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            };
            loadworker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Result is Exception)
                    MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    this.inventory.InventoryProgressByTeams.Clear();
                    this.inventory.InventoryProgressByTeams.Merge(e.Result as DataTable);
                    this.inventoryProgressByTeamsBindingSource.DataSource = e.Result;
                }

                waitProgressForm.CloseForce();
            };

            waitProgressForm.ActionText = "Выполняется формирование статистики рейтинга бригад..";
            loadworker.RunWorkerAsync();
            waitProgressForm.ShowDialog();
        }

        /// <summary>
        /// Загрузка статистики рейтинга по станциям
        /// </summary>
        private void LoadStatisticsByStation()
        {
            BackgroundWorker loadworker = new BackgroundWorker();
            loadworker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    xdgvStations.DataView.FillData(new InventoryProgressByStationSearchParameters() { SessionID = UserID, DocID = this.InventoryDocID, UseFilialSearchMode = this.UseFilialSearchMode });

                    //this.inventoryProgressByStationTableAdapter.SetTimeout(RESPONSE_WAIT_TIMEOUT);
                    //e.Result = this.UseFilialSearchMode ? this.inventoryProgressByStationTableAdapter.GetData(this.UserID, this.InventoryDocID) : this.inventoryProgressByStationTableAdapter.GetData(this.UserID, this.InventoryDocID);
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            };
            loadworker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Result is Exception)
                    MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    xdgvStations.BindData(false);

                    //this.inventory.InventoryProgressByStation.Clear();
                    //this.inventory.InventoryProgressByStation.Merge(e.Result as DataTable);
                    //this.inventoryProgressByStationBindingSource.DataSource = e.Result;
                }

                waitProgressForm.CloseForce();
            };

            waitProgressForm.ActionText = "Выполняется формирование статистики рейтинга станций..";
            loadworker.RunWorkerAsync();
            waitProgressForm.ShowDialog();
        }

        /// <summary>
        /// Загрузка статистики рейтинга по зонам
        /// </summary>
        private void LoadStatisticsByZones()
        {
            BackgroundWorker loadworker = new BackgroundWorker();
            loadworker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    this.inventoryProgressByZonesTableAdapter.SetTimeout(RESPONSE_WAIT_TIMEOUT);
                    e.Result = this.UseFilialSearchMode ? this.inventoryProgressByZonesTableAdapter.GetDataByFilial(this.UserID, this.InventoryDocID) : this.inventoryProgressByZonesTableAdapter.GetData(this.UserID, this.InventoryDocID);
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            };
            loadworker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Result is Exception)
                    MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    this.inventory.InventoryProgressByZones.Clear();
                    this.inventory.InventoryProgressByZones.Merge(e.Result as DataTable);
                    this.inventoryProgressByZonesBindingSource.DataSource = e.Result;
                }

                waitProgressForm.CloseForce();
            };

            waitProgressForm.ActionText = "Выполняется формирование статистики рейтинга зон..";
            loadworker.RunWorkerAsync();
            waitProgressForm.ShowDialog();
        }

        private void dgvDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            decimal totalPercentAmount = 0;
            decimal totalPlanResult = 0;

            foreach (Data.Inventory.InventoryProgressByLocationsRow row in this.inventory.InventoryProgressByLocations)
            { 
                totalPercentAmount += row.IsPercentAmountNull() ? 0 : row.PercentAmount;
                totalPlanResult += row.IsPlanResultNull() ? 0 : row.PlanResult;
            }

            tbTotalPercentAmount.Text = string.Format("{0:N2}", totalPercentAmount);
            tbTotalPlanResult.Text = string.Format("{0:N4}", totalPlanResult);
        }

        private void tcMonitoringLayout_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.AdaptPageDataSource();
        }

        /// <summary>
        /// адаптация источника данных для текущей страницы
        /// </summary>
        private void AdaptPageDataSource()
        {
            switch (tcMonitoringLayout.SelectedIndex)
            {
                case 0:
                    if (!this.lstLoadingCompleted[0])
                    {
                        LoadGeneralStatistics();
                        this.lstLoadingCompleted[0] = true;
                    }
                    break;
                case 1:
                    if (!this.lstLoadingCompleted[1])
                    {
                        LoadStatisticsByZones();
                        this.lstLoadingCompleted[1] = true;
                    }
                    break;
                case 2:
                    if (!this.lstLoadingCompleted[2])
                    {
                        LoadStatisticsByTeams();
                        this.lstLoadingCompleted[2] = true;
                    }
                    break;
                case 3:
                    if (!this.lstLoadingCompleted[3])
                    {
                        LoadStatisticsByStation();
                        this.lstLoadingCompleted[3] = true;
                    }
                    break;
                default:
                    break;
            }
        }

        private void sbRefreshData_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.lstLoadingCompleted.Count; i++)
                this.lstLoadingCompleted[i] = false;

            this.AdaptPageDataSource();
        }

        #region Синхронизация прокрутки для итоговой статистики по зонам
        private void dgvTotalZones_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                try
                {
                    dgvZones.HorizontalScrollingOffset = e.NewValue;
                    //dgvZones.Refresh();
                }
                catch (Exception ex)
                { }
            }
        }

        private void dgvZones_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                try
                {
                    dgvTotalZones.HorizontalScrollingOffset = e.NewValue;
                    //dgvTotalZones.Refresh();
                }
                catch (Exception ex)
                { }
            }
        }

        private void dgvZones_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (dgvTotalZones.Columns.Count > e.Column.Index)
            {
                dgvTotalZones.Columns[e.Column.Index].Width = e.Column.Width;
                //dgvTotalZones.Refresh();
            }
        }
        #endregion

        private void dgvZones_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            int totalCountPlaces = 0;
            int totalCountReadyPlace = 0;
            double totalReadyPercent = 0;
            int totalRestPlace = 0;
            double totalRestPercent = 0;

            foreach (Data.Inventory.InventoryProgressByZonesRow row in this.inventory.InventoryProgressByZones)
            {
                totalCountPlaces += row.IsCountPlacesNull() ? 0 : row.CountPlaces;
                totalCountReadyPlace += row.IsCountReadyPlaceNull() ? 0 : row.CountReadyPlace;
                totalReadyPercent += row.IsReadyPercentNull() ? 0 : row.ReadyPercent;
                totalRestPlace += row.IsRestPlaceNull() ? 0 : row.RestPlace;
                totalRestPercent += row.IsRestPercentNull() ? 0 : row.RestPercent;
            }

            foreach (DataGridViewColumn column in this.dgvTotalZones.Columns)
            {
                if (column.DataPropertyName == this.inventory.InventoryProgressByZones.ZoneNameColumn.Caption)
                    this.dgvTotalZones.Rows[0].Cells[column.Index].Value = "Итого :";

                if (column.DataPropertyName == this.inventory.InventoryProgressByZones.CountPlacesColumn.Caption)
                    this.dgvTotalZones.Rows[0].Cells[column.Index].Value = string.Format("{0:N0}", totalCountPlaces);

                if (column.DataPropertyName == this.inventory.InventoryProgressByZones.CountReadyPlaceColumn.Caption)
                    this.dgvTotalZones.Rows[0].Cells[column.Index].Value = string.Format("{0:N0}", totalCountReadyPlace);

                if (column.DataPropertyName == this.inventory.InventoryProgressByZones.ReadyPercentColumn.Caption)
                    this.dgvTotalZones.Rows[0].Cells[column.Index].Value = string.Format("{0:N2}", totalReadyPercent);

                if (column.DataPropertyName == this.inventory.InventoryProgressByZones.RestPlaceColumn.Caption)
                    this.dgvTotalZones.Rows[0].Cells[column.Index].Value = string.Format("{0:N0}", totalRestPlace);

                if (column.DataPropertyName == this.inventory.InventoryProgressByZones.RestPercentColumn.Caption)
                    this.dgvTotalZones.Rows[0].Cells[column.Index].Value = string.Format("{0:N2}", totalRestPercent);
            }
        }

        #region Синхронизация прокрутки для итоговой статистики по бригадам
        private void dgvTotalTeams_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                try
                {
                    dgvTeams.HorizontalScrollingOffset = e.NewValue;
                    //dgvTeams.Refresh();
                }
                catch (Exception ex)
                { }
            }
        }

        private void dgvTeams_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                try
                {
                    dgvTotalTeams.HorizontalScrollingOffset = e.NewValue;
                    //dgvTotalTeams.Refresh();
                }
                catch (Exception ex)
                { }
            }
        }

        private void dgvTeams_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (dgvTotalTeams.Columns.Count > e.Column.Index)
            {
                dgvTotalTeams.Columns[e.Column.Index].Width = e.Column.Width;
                //dgvTotalTeams.Refresh();
            }
        }
        #endregion

        private void dgvTeams_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            int totalCountPlace = 0;
            double totalPercentPlace = 0;

            foreach (Data.Inventory.InventoryProgressByTeamsRow row in this.inventory.InventoryProgressByTeams)
            {
                totalCountPlace += row.CountPlace;
                totalPercentPlace += row.IsPercentPlaceNull() ? 0 : row.PercentPlace;
            }

            foreach (DataGridViewColumn column in this.dgvTotalTeams.Columns)
            {
                if (column.DataPropertyName == this.inventory.InventoryProgressByTeams.ZoneNameColumn.Caption)
                    this.dgvTotalTeams.Rows[0].Cells[column.Index].Value = "Итого :";

                if (column.DataPropertyName == this.inventory.InventoryProgressByTeams.CountPlaceColumn.Caption)
                    this.dgvTotalTeams.Rows[0].Cells[column.Index].Value = string.Format("{0:N0}", totalCountPlace);

                if (column.DataPropertyName == this.inventory.InventoryProgressByTeams.PercentPlaceColumn.Caption)
                    this.dgvTotalTeams.Rows[0].Cells[column.Index].Value = string.Format("{0:N2}", totalPercentPlace);
            }
        }


        void xdgvStations_OnFilterChanged(object sender, EventArgs e)
        {
            xdgvStations.RecalculateSummary();
        }

        void xdgvStations_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var gridView = sender as DataGridView;
            var bindRow = (gridView.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as DataRow;
            var foreColor = Color.FromName(bindRow["ColorFontRow"].ToString());
            var backColor = Color.FromName(bindRow["ColorBackRow"].ToString());

            gridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = backColor;
            gridView.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = backColor;

            gridView.Rows[e.RowIndex].DefaultCellStyle.ForeColor = foreColor;
            gridView.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = foreColor;
        }

    }

    /// <summary>
    /// Представление для грида со статистикой проведения инвентаризации в разрезе станций
    /// </summary>
    public class InventoryProgressByStationView : IDataView
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
        /// <param name="pSearchParameters">Критерии поиска</param>
        public void FillData(SearchParametersBase pSearchParameters)
        {
            var sc = pSearchParameters as InventoryProgressByStationSearchParameters;

            var useFilialSearchMode = sc.UseFilialSearchMode;

            var sessionID = sc.SessionID;
            var docID = sc.DocID;

            using (var adapter = new Data.InventoryTableAdapters.InventoryProgressByStationTableAdapter())
            {
                adapter.SetTimeout(DEFAULT_RESPONSE_TIMEOUT);
                data = useFilialSearchMode ? adapter.GetData(sessionID, docID) : adapter.GetData(sessionID, docID);
            }
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ КЛАССА

        public InventoryProgressByStationView()
        {
            this.dataColumns.Add(new PatternColumn("Склад", "WarehouseID", new FilterPatternExpressionRule("WarehouseID"), SummaryCalculationType.Count) { Width = 100 });
            
            this.dataColumns.Add(new PatternColumn("Код станции", "StationCode", new FilterPatternExpressionRule("StationCode"), SummaryCalculationType.Count) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Станция", "StationName", new FilterPatternExpressionRule("StationName")));
            
            this.dataColumns.Add(new PatternColumn("Зона", "UnionName", new FilterPatternExpressionRule("UnionName"), SummaryCalculationType.Count));

            this.dataColumns.Add(new PatternColumn("1й пересчет, всего", "CountPlace", new FilterCompareExpressionRule<Int32>("CountPlace"), SummaryCalculationType.Sum) { Width = 110, UseIntegerNumbersAlignment = true });
            this.dataColumns.Add(new PatternColumn("1й пересчет, посчитано", "CountReadyPlace", new FilterCompareExpressionRule<Int32>("CountReadyPlace"), SummaryCalculationType.Sum) { Width = 110, UseIntegerNumbersAlignment = true });

            this.dataColumns.Add(new PatternColumn("2й пересчет, всего", "CountPlace2", new FilterCompareExpressionRule<Int32>("CountPlace2"), SummaryCalculationType.Sum) { Width = 110, UseIntegerNumbersAlignment = true });
            this.dataColumns.Add(new PatternColumn("2й пересчет, посчитано", "CountReadyPlace2", new FilterCompareExpressionRule<Int32>("CountReadyPlace2"), SummaryCalculationType.Sum) { Width = 110, UseIntegerNumbersAlignment = true });

            this.dataColumns.Add(new PatternColumn("3й пересчет, всего", "CountPlace3", new FilterCompareExpressionRule<Int32>("CountPlace3"), SummaryCalculationType.Sum) { Width = 110, UseIntegerNumbersAlignment = true });
            this.dataColumns.Add(new PatternColumn("3й пересчет, посчитано", "CountReadyPlace3", new FilterCompareExpressionRule<Int32>("CountReadyPlace3"), SummaryCalculationType.Sum) { Width = 110, UseIntegerNumbersAlignment = true });

            this.dataColumns.Add(new PatternColumn("Признак завершения", "CloseAllCalcs", new FilterPatternExpressionRule("CloseAllCalcs"), SummaryCalculationType.Count) { Width = 100 });
        }

        #endregion
    }

    /// <summary>
    /// Параметры получения списка со статистикой проведения инвентаризации в разрезе станций
    /// </summary>
    public class InventoryProgressByStationSearchParameters : SessionIDSearchParameters
    {
        /// <summary>
        /// Признак режима поиска
        /// </summary>
        public bool UseFilialSearchMode { get; set; }

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        public long DocID { get; set; }
    }
}
