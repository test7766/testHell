using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using System.Data.SqlClient;
using WMSOffice.Dialogs.PickControl;

namespace WMSOffice.Window
{
    public partial class RegistrationStationWindow : GeneralWindow
    {
        #region ПОЛЯ И СВОЙСТВА ДАННЫХ

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных
        /// </summary>
        private Dialogs.SplashForm waitProgressForm = new WMSOffice.Dialogs.SplashForm();

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ

        public RegistrationStationWindow()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            
            tbScanEmployee.TextChanged += new EventHandler(tbScanEmployee_TextChanged);

            this.xdgvStations.AllowSummary = false;
            this.xdgvStations.AllowRangeColumns = false;
            this.xdgvStations.UseMultiSelectMode = false;

            this.xdgvStations.Init(new StationsDataView(), true);
            this.xdgvStations.UserID = this.UserID;

            #region ПРИМЕНЕНИЕ СТИЛЯ ОТОБРАЖЕНИЯ ДАННЫХ
            
            this.xdgvStations.DataGrid.BackgroundColor = this.dgvRegisteredEmployees.BackgroundColor;
            this.xdgvStations.DataGrid.ColumnHeadersDefaultCellStyle = this.dgvRegisteredEmployees.ColumnHeadersDefaultCellStyle;
            this.xdgvStations.DataGrid.DefaultCellStyle = this.dgvRegisteredEmployees.DefaultCellStyle;
            this.xdgvStations.SetSameStyleForAlternativeRows();
            this.xdgvStations.DataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            this.xdgvStations.FilterGrid.BackgroundColor = this.dgvRegisteredEmployees.BackgroundColor;
            this.xdgvStations.FilterGrid.DefaultCellStyle = this.dgvRegisteredEmployees.DefaultCellStyle;

            this.xdgvStations.SummaryGrid.BackgroundColor = this.dgvRegisteredEmployees.BackgroundColor;
            this.xdgvStations.SummaryGrid.DefaultCellStyle = this.dgvRegisteredEmployees.DefaultCellStyle;
            
            #endregion

            this.LoadStations();

            this.xdgvStations.OnFilterChanged += new EventHandler(xdgvStations_OnFilterChanged);
            this.xdgvStations.OnRowSelectionChanged += new System.EventHandler(this.xdgvStations_OnRowSelectionChanged);

            tbScanEmployee.Focus();
        }

        void xdgvStations_OnFilterChanged(object sender, EventArgs e)
        {
            this.xdgvStations.RecalculateSummary();
        }

        #endregion

        void tbScanEmployee_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (xdgvStations.SelectedItem == null)
                    throw new Exception("Для регистрации необходимо выбрать станцию.");

                int employeeID = 0;
                if (String.IsNullOrEmpty(tbScanEmployee.Text) || !int.TryParse(tbScanEmployee.Text, out employeeID))
                    throw new Exception("Код сотрудника должен быть целым числом.");

                var stationRow = this.xdgvStations.SelectedItem;
                var stationID = Convert.ToInt32(stationRow["station_id"]);
                var processID = Convert.ToInt32(stationRow["process_id"]);

                var response = this.stationRegistrationsListTableAdapter.RegisterEmployeeOnStation(this.UserID, employeeID.ToString(), stationID, processID);
                int responseCode; 
                if (response != null && int.TryParse(response.ToString(), out responseCode))
                {
                    switch (responseCode)
                    { 
                        case 0:
                            throw new Exception(string.Format("Ошибка регистрации на станции №{0}\nсотрудника с кодом {1}.", stationID, employeeID));
                            break;
                        case 1:
                            throw new Exception("Просканирован некорректный код сотрудника.");
                            break;
                        case 2:
                            MessageBox.Show(string.Format("Сотрудник с кодом {0}\nуспешно снят с регистрации на станции №{1}.", employeeID, stationID), "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LoadRegisteredEmployeesForCurrentStation();
                            break;
                        case 3 :
                            MessageBox.Show(string.Format("Сотрудник с кодом {0}\nуспешно зарегистрирован на станции №{1}.", employeeID, stationID), "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LoadRegisteredEmployeesForCurrentStation();
                            break;
                        default:
                            break;
                    }
                }
                else
                    throw new Exception("Не определен признак завершения регистрации.");
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }

            this.tbScanEmployee.Text = string.Empty;
        }

        /// <summary>
        /// Загрузка станций
        /// </summary>
        private void LoadStations()
        {
            this.xdgvStations.Focus();

            BackgroundWorker loadWorker = new BackgroundWorker();
            loadWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    this.xdgvStations.DataView.FillData(e.Argument as StationsSearchParameters);
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
            loadWorker.RunWorkerAsync(new StationsSearchParameters() { UserID = this.UserID });
            waitProgressForm.ShowDialog();

            if (this.xdgvStations.DataView.Data.Rows.Count > 0)
                this.LoadRegisteredEmployeesForCurrentStation();

        }

        private void xdgvStations_OnRowSelectionChanged(object sender, EventArgs e)
        {
            this.stationRegistrationsListBindingSource.DataSource = null;

            if (this.xdgvStations.SelectedItem != null)
                this.LoadRegisteredEmployeesForCurrentStation();
        }

        /// <summary>
        /// Загрузка зарегистрированных сотрудников для текущей станции
        /// </summary>
        private void LoadRegisteredEmployeesForCurrentStation()
        {
            var stationRow = this.xdgvStations.SelectedItem;
            var stationID = Convert.ToInt32(stationRow["station_id"]);
            var processID = Convert.ToInt32(stationRow["process_id"]);

            BackgroundWorker loadWorker = new BackgroundWorker();
            loadWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    e.Result = this.stationRegistrationsListTableAdapter.GetData(processID, stationID, (int?)null);
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
                    this.stationRegistrationsListBindingSource.DataSource = e.Result;


                waitProgressForm.CloseForce();
            };

            waitProgressForm.ActionText = "Выполняется загрузка зарегистрированных сотрудников..";
            this.stationRegistrationsListBindingSource.DataSource = null;
            loadWorker.RunWorkerAsync();
            waitProgressForm.ShowDialog();
        }

        private void sbShowEmployees_Click(object sender, EventArgs e)
        {
            new PresentEmployeesViewForm() { UserID = this.UserID }.ShowDialog();
        }
    }

    /// <summary>
    /// Отображение станций
    /// </summary>
    public class StationsDataView : IDataView
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
            var searchCriteria = searchParameters as StationsSearchParameters;

            using (SqlCommand command = new SqlCommand("[dbo].[pr_aw_get_stations_list]", new SqlConnection(Properties.Settings.Default.JDE_PROCConnectionString)))
            {
                command.CommandTimeout = DEFAULT_RESPONSE_TIMEOUT;
                command.CommandType = CommandType.StoredProcedure;

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    var dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    this.data = dataSet.Tables[0];
                }
            }
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ

        public StationsDataView()
        {
            this.dataColumns.Add(new PatternColumn("Станция", "station_description", new FilterPatternExpressionRule("station_description"), SummaryCalculationType.Count) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Тип процесса", "process_type_description", new FilterPatternExpressionRule("process_type_description")) { Width = 100 });
        }

        #endregion
    }

    /// <summary>
    /// Параметры поиска станций
    /// </summary>
    public class StationsSearchParameters : SearchParametersBase
    {
        /// <summary>
        /// Код сессии пользователя
        /// </summary>
        public long UserID { get; set; }
    }
}
