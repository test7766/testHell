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
    public partial class SmartRegistrationStationWindow : GeneralWindow
    {
        #region КОНСТАНТЫ

        private const long NOT_REGISTERED_STATION_ID = 0;

        #endregion

        #region ПОЛЯ И СВОЙСТВА ДАННЫХ

        public string WarehouseID { get; private set; }

        public string WarehouseName { get; private set; }

        private TextBoxScaner _registerControl = null;

        private long? _selectedStationID = null;

    #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ

        public SmartRegistrationStationWindow()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            tsMainOptions.Visible = false;
            pnlMainLayout.Visible = false;

            if (!AdaptWarehouse())
            {
                this.Close();
                return;
            }

            this.DocTitle.Text = string.Format("{0} [{1}]", this.DocTitle.Text, this.WarehouseName);
            pnlMainLayout.Visible = true;
            tsMainOptions.Visible = true;
            this.Initialize();
        }

        private bool AdaptWarehouse()
        {
            try
            {
                var warehouseID = string.Empty;
                var warehouseName = string.Empty;

                using (var adapter = new Data.PickControlTableAdapters.QueriesTableAdapter())
                    adapter.pr_SE_GetWarehouses(this.UserID, ref warehouseID, ref warehouseName);

                if (string.IsNullOrEmpty(warehouseID.Trim()))
                    throw new Exception("У Вас недостаточно прав для работы с данным интерфейсом.");

                this.WarehouseID = warehouseID;
                this.WarehouseName = warehouseName.Trim();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void Initialize()
        {
            #region ДОБАВЛЕНИЕ ДИНАМИЧЕСКИХ КНОПОК

            tsMainOptions.Items.Add(new ToolStripControlHost(_registerControl = new TextBoxScaner() { Padding = new Padding(6, 6, 6, 6) }) { Width = 300 });
            _registerControl.TextChanged += delegate(object sender, EventArgs e) { RegisterEmployee(); };
            _registerControl.KeyPress += delegate(object sender, KeyPressEventArgs e)
            {
                if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                    e.Handled = true;
            };

            tsMainOptions.Items.Add(new ToolStripSeparator());
            tsMainOptions.Items.Add(new ToolStripButton("Открепить", Properties.Resources.repeat, delegate(object sender, EventArgs e) { UnregisterEmployee(true, (int?)null); }));

            #endregion

            this.xdgvStations.AllowSummary = false;
            this.xdgvStations.AllowRangeColumns = false;
            this.xdgvStations.UseMultiSelectMode = false;

            this.xdgvStations.Init(new SmartStationsDataView(), true);
            this.xdgvStations.UserID = this.UserID;

            #region ПРИМЕНЕНИЕ СТИЛЯ ОТОБРАЖЕНИЯ ДАННЫХ

            this.xdgvStations.DataGrid.BackgroundColor = this.dgvRegisteredEmployees.BackgroundColor;
            this.xdgvStations.DataGrid.ColumnHeadersDefaultCellStyle = this.dgvRegisteredEmployees.ColumnHeadersDefaultCellStyle;
            this.xdgvStations.DataGrid.DefaultCellStyle = this.dgvRegisteredEmployees.DefaultCellStyle;
            this.xdgvStations.SetSameStyleForAlternativeRows();
            //this.xdgvStations.DataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            this.xdgvStations.FilterGrid.BackgroundColor = this.dgvRegisteredEmployees.BackgroundColor;
            this.xdgvStations.FilterGrid.DefaultCellStyle = this.dgvRegisteredEmployees.DefaultCellStyle;

            this.xdgvStations.SummaryGrid.BackgroundColor = this.dgvRegisteredEmployees.BackgroundColor;
            this.xdgvStations.SummaryGrid.DefaultCellStyle = this.dgvRegisteredEmployees.DefaultCellStyle;

            #endregion
        
            this.xdgvStations.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvStations_OnFormattingCell);

            this.LoadStations(); 
            
            this.xdgvStations.OnFilterChanged += new EventHandler(xdgvStations_OnFilterChanged);
            this.xdgvStations.OnRowSelectionChanged += new EventHandler(this.xdgvStations_OnRowSelectionChanged);

            this.xdgvStations.DataGrid.MouseDown += new MouseEventHandler(DataGrid_MouseDown);

            _registerControl.Focus();
        }

        void DataGrid_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var point = new Point(e.X, e.Y);
                var hitTestInfo = this.xdgvStations.DataGrid.HitTest(point.X, point.Y);
                if (hitTestInfo.Type == DataGridViewHitTestType.Cell)
                    this.xdgvStations.DataGrid.CurrentCell = this.xdgvStations.DataGrid.Rows[hitTestInfo.RowIndex].Cells[hitTestInfo.ColumnIndex];
            }
        }

        void xdgvStations_OnFilterChanged(object sender, EventArgs e)
        {
            this.xdgvStations.RecalculateSummary();
            this.SetAccessToOperations();
        } 
        
        void xdgvStations_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grid = sender as DataGridView;
            var currentRow = (grid.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as DataRow;

            var colorName = currentRow["row_color"];
            if (!colorName.Equals(DBNull.Value))
            {
                var color = Color.FromName(colorName.ToString());

                e.CellStyle.ForeColor = color;
                e.CellStyle.SelectionForeColor = color;
                e.CellStyle.SelectionBackColor = SystemColors.Highlight;
            }
            else
            {
                if (currentRow["station_id"].Equals(NOT_REGISTERED_STATION_ID))
                {
                    e.CellStyle.BackColor = Color.Salmon;
                    e.CellStyle.SelectionForeColor = Color.Crimson;
                    e.CellStyle.SelectionBackColor = SystemColors.Highlight;
                }
                else if (currentRow["knt"].Equals(0))
                {
                    e.CellStyle.ForeColor = Color.Crimson;
                    e.CellStyle.SelectionForeColor = Color.Crimson;
                    e.CellStyle.SelectionBackColor = SystemColors.Highlight;
                }
            }
        }

        #endregion

        /// <summary>
        /// Загрузка станций
        /// </summary>
        private void LoadStations()
        {
            _selectedStationID = this.xdgvStations.SelectedItem != null ? Convert.ToInt64(this.xdgvStations.SelectedItem["station_id"]) : (long?)null;

            this.xdgvStations.Focus();
            var waitProgressForm = new WMSOffice.Dialogs.SplashForm();

            BackgroundWorker loadWorker = new BackgroundWorker();
            loadWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    this.xdgvStations.DataView.FillData(e.Argument as SmartStationsSearchParameters);
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
                    this.xdgvStations.BindData(false);
                    this.xdgvStations.AllowSummary = true;
                }

                waitProgressForm.CloseForce();
            };

            waitProgressForm.ActionText = "Выполняется загрузка станций..";
            loadWorker.RunWorkerAsync(new SmartStationsSearchParameters() { UserID = this.UserID, WarehouseID = this.WarehouseID });
            waitProgressForm.ShowDialog();

            this.NavigateToCurrentStation();

            if (this.xdgvStations.DataView.Data.Rows.Count > 0)
                this.LoadRegisteredEmployeesForCurrentStation();

            this.SetAccessToOperations();
        }

        /// <summary>
        /// Установка фокуса на выбранную строку до обновления
        /// </summary>
        private void NavigateToCurrentStation()
        {
            if (_selectedStationID.HasValue)
            {
                this.xdgvStations.SelectRow("station_id", _selectedStationID.Value.ToString());
                this.xdgvStations.ScrollToSelectedRow();
            }
        }

        private void xdgvStations_OnRowSelectionChanged(object sender, EventArgs e)
        {
            this.prsestationemployeeonstationBindingSource.DataSource = null;

            if (this.xdgvStations.SelectedItem != null)
                this.LoadRegisteredEmployeesForCurrentStation();

            this.SetAccessToOperations();
        }

        /// <summary>
        /// Установка доступа к операциям
        /// </summary>
        private void SetAccessToOperations()
        {
            var isEnabled = false;
            
            // Настройка доступа для таблицы станций
            isEnabled = xdgvStations.SelectedItem != null && !xdgvStations.SelectedItem["station_id"].Equals(NOT_REGISTERED_STATION_ID);
            _registerControl.Enabled = isEnabled;
            miUnregisterAllEmployees.Enabled = isEnabled;

            // Настройка доступа для таблицы сотрудников
            isEnabled &= dgvRegisteredEmployees.SelectedRows.Count > 0;
            miUnregisterEmployee.Enabled = isEnabled;
        }

        /// <summary>
        /// Загрузка зарегистрированных сотрудников для текущей станции
        /// </summary>
        private void LoadRegisteredEmployeesForCurrentStation()
        {
            var waitProgressForm = new WMSOffice.Dialogs.SplashForm();

            var stationRow = this.xdgvStations.SelectedItem;
            var stationID = Convert.ToInt32(stationRow["station_id"]);

            BackgroundWorker loadWorker = new BackgroundWorker();
            loadWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    e.Result = this.pr_se_station_employee_on_stationTableAdapter.GetData(this.UserID, this.WarehouseID, stationID);
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
                    this.prsestationemployeeonstationBindingSource.DataSource = e.Result;


                waitProgressForm.CloseForce();
            };

            waitProgressForm.ActionText = "Выполняется загрузка зарегистрированных сотрудников..";
            this.prsestationemployeeonstationBindingSource.DataSource = null;
            loadWorker.RunWorkerAsync();
            waitProgressForm.ShowDialog();
        }

        private void dgvRegisteredEmployees_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void miUnregisterAllEmployees_Click(object sender, EventArgs e)
        {
            var employeeID = (int?)null;
            UnregisterEmployee(false, employeeID);
        }

        private void miUnregisterEmployee_Click(object sender, EventArgs e)
        {
            var employeeID = Convert.ToInt32(((dgvRegisteredEmployees.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.PickControl.pr_se_station_employee_on_stationRow).ABAN8);
            UnregisterEmployee(false, employeeID);
        }

        /// <summary>
        /// Регистрация сотрудника
        /// </summary>
        private void RegisterEmployee()
        {
            try
            {
                if (string.IsNullOrEmpty(_registerControl.Text))
                    throw new Exception("Код сотрудника должен быть задан.");

                int stationID = Convert.ToInt32(xdgvStations.SelectedItem["station_id"]);
                int processID = Convert.ToInt32(xdgvStations.SelectedItem["process_id"]);
                int sectorID = Convert.ToInt32(xdgvStations.SelectedItem["sector_id"]);

                int employeeID = 0;
                if (int.TryParse(_registerControl.Text, out employeeID))
                {
                    int? errorCode = null;
                    string errorMessage = null;

                    using (var adapter = new Data.PickControlTableAdapters.pr_se_station_loadingTableAdapter())
                        adapter.pr_se_station_employee_registration(this.UserID, this.WarehouseID, employeeID, stationID, processID, sectorID, ref errorCode, ref errorMessage);

                    if (errorCode != 0) // Ошибка регистрации
                        throw new Exception(errorMessage);

                    // Обновление станций
                    LoadStations();
                    _registerControl.Text = string.Empty;
                    _registerControl.Focus();
                }
                else
                    throw new Exception("Неверный код сотрудника.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _registerControl.SelectAll();
                return;
            }
        }

        /// <summary>
        /// Открепление сотрудника
        /// </summary>
        /// <param name="findEmployee"></param>
        /// <param name="employeeID"></param>
        private void UnregisterEmployee(bool findEmployee, int? employeeID)
        {
            var success = false;

            try
            {
                if (findEmployee)
                {
                    #region Поиск и открепление сотрудника

                    while (true)
                    {
                        success = false;

                        try
                        {
                            var dlgScanner = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                            {
                                OnlyNumbersInBarcode = true,
                                Label = "Отсканируйте бэйдж сотрудника, которого вы хотите открепить со станции",
                                Text = "Открепление сотрудника",
                                Image = Properties.Resources.metacontact_unknown
                            };

                            if (dlgScanner.ShowDialog() == DialogResult.OK)
                            {
                                int parsedEmployeeID;
                                if (int.TryParse(dlgScanner.Barcode, out parsedEmployeeID))
                                {
                                    int? errorCode = null;
                                    string errorMessage = null;

                                    using (var adapter = new Data.PickControlTableAdapters.pr_se_station_loadingTableAdapter())
                                        adapter.pr_se_station_employee_UNRegistration(this.UserID, this.WarehouseID, parsedEmployeeID, ref errorCode, ref errorMessage);

                                    if (errorCode != 0) // Ошибка открепления
                                        throw new Exception(errorMessage);

                                    success = true;
                                    break;
                                }
                                else
                                    throw new Exception("Неверный код сотрудника.");
                            }
                            else
                                break;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    #endregion
                }
                else
                {
                    #region Открепление "известного" сотрудника

                    int? errorCode = null;
                    string errorMessage = null;

                    using (var adapter = new Data.PickControlTableAdapters.pr_se_station_loadingTableAdapter())
                        adapter.pr_se_station_employee_UNRegistration(this.UserID, this.WarehouseID, employeeID, ref errorCode, ref errorMessage);

                    if (errorCode != 0) // Ошибка открепления
                        throw new Exception(errorMessage);

                    success = true;

                    #endregion
                }

                if (success) // Обновление станций
                    LoadStations();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvRegisteredEmployees_SelectionChanged(object sender, EventArgs e)
        {
            SetAccessToOperations();
        }

        private void dgvRegisteredEmployees_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var point = new Point(e.X, e.Y);
                var hitTestInfo = dgvRegisteredEmployees.HitTest(point.X, point.Y);
                if (hitTestInfo.Type == DataGridViewHitTestType.Cell)
                    dgvRegisteredEmployees.CurrentCell = dgvRegisteredEmployees.Rows[hitTestInfo.RowIndex].Cells[hitTestInfo.ColumnIndex];
            }
        }
    }

    /// <summary>
    /// Отображение станций
    /// </summary>
    public class SmartStationsDataView : IDataView
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
            var searchCriteria = searchParameters as SmartStationsSearchParameters;

            using (var adapter = new Data.PickControlTableAdapters.pr_se_station_loadingTableAdapter())
                this.data = adapter.GetData(searchCriteria.UserID, searchCriteria.WarehouseID);
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ

        public SmartStationsDataView()
        {
            this.dataColumns.Add(new PatternColumn("Станция", "station_code", new FilterPatternExpressionRule("station_code"), SummaryCalculationType.Count) { Width = 300 });
            this.dataColumns.Add(new PatternColumn("Процесс", "process_name", new FilterPatternExpressionRule("process_name"), SummaryCalculationType.Count) { Width = 200 });
            this.dataColumns.Add(new PatternColumn("Кол-во чел.", "knt", new FilterCompareExpressionRule<Int32>("knt")) { Width = 200 });
        }

        #endregion
    }

    /// <summary>
    /// Параметры поиска станций
    /// </summary>
    public class SmartStationsSearchParameters : SearchParametersBase
    {
        /// <summary>
        /// Код сессии пользователя
        /// </summary>
        public long UserID { get; set; }

        /// <summary>
        /// Код склада
        /// </summary>
        public string WarehouseID { get; set; }
    }
}
