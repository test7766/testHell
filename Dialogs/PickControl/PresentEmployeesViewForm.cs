using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using System.Data.SqlClient;

namespace WMSOffice.Dialogs.PickControl
{
    public partial class PresentEmployeesViewForm : DialogForm
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных
        /// </summary>
        private Dialogs.SplashForm waitProgressForm = new WMSOffice.Dialogs.SplashForm();

        public PresentEmployeesViewForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(700, 8);
            this.btnCancel.Location = new Point(790, 8);
            this.btnCancel.Text = "Закрыть";
            this.btnOK.Visible = false;

            this.xdgvEmployees.AllowSummary = false;
            this.xdgvEmployees.AllowRangeColumns = false;
            this.xdgvEmployees.UseMultiSelectMode = false;

            this.xdgvEmployees.Init(new EmployeesView(), true);
            this.xdgvEmployees.UserID = this.UserID;

            #region ПРИМЕНЕНИЕ СТИЛЯ ОТОБРАЖЕНИЯ ДАННЫХ

            this.xdgvEmployees.DataGrid.BackgroundColor = Color.MintCream;
            this.xdgvEmployees.DataGrid.ColumnHeadersDefaultCellStyle.Font = new Font(new FontFamily("Microsoft Sans Serif"), 12);
            this.xdgvEmployees.DataGrid.DefaultCellStyle.Font = new Font(new FontFamily("Microsoft Sans Serif"), 12);
            this.xdgvEmployees.SetSameStyleForAlternativeRows();
            this.xdgvEmployees.DataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            this.xdgvEmployees.FilterGrid.BackgroundColor = Color.MintCream;
            this.xdgvEmployees.FilterGrid.DefaultCellStyle.Font = new Font(new FontFamily("Microsoft Sans Serif"), 12);

            this.xdgvEmployees.SummaryGrid.BackgroundColor = Color.MintCream;
            this.xdgvEmployees.SummaryGrid.DefaultCellStyle.Font = new Font(new FontFamily("Microsoft Sans Serif"), 12);

            #endregion

            this.xdgvEmployees.OnFilterChanged += new EventHandler(xdgvEmployees_OnFilterChanged);
            this.xdgvEmployees.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvEmployees_OnFormattingCell);

            LoadEmployees();
        }

        void xdgvEmployees_OnFilterChanged(object sender, EventArgs e)
        {
            this.xdgvEmployees.RecalculateSummary();
        }

        void xdgvEmployees_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grid = sender as DataGridView;
            var row = (grid.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as DataRow;

            #region ИНДИКАЦИЯ СОТРУДНИКОВ ЗАКРЕПЛЕННЫХ ЗА СТАНЦИЯМИ
            if (row["LinkedStations"] != DBNull.Value)
            {
                e.CellStyle.BackColor = Color.LightGreen;
                e.CellStyle.SelectionForeColor = Color.LightGreen;
                return;
            }
            #endregion
        }

        /// <summary>
        /// Загрузка списка сотрудников
        /// </summary>
        private void LoadEmployees()
        {
            BackgroundWorker loadworker = new BackgroundWorker();
            loadworker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    this.xdgvEmployees.DataView.FillData(e.Argument as EmployeesSearchParameters);
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
                    this.xdgvEmployees.BindData(false);
                    this.xdgvEmployees.AllowSummary = true;
                }

                waitProgressForm.CloseForce();
            };

            waitProgressForm.ActionText = "Выполняется загрузка списка сотрудников..";

            var searchParameters = new EmployeesSearchParameters();
            searchParameters.UserID = this.UserID;
            searchParameters.Date = DateTime.Today;

            loadworker.RunWorkerAsync(searchParameters);
            waitProgressForm.ShowDialog();
        }
    }

    /// <summary>
    /// Параметры поиска сотрудников
    /// </summary>
    public class EmployeesSearchParameters : SearchParametersBase
    {
        /// <summary>
        /// Код сессии пользователя
        /// </summary>
        public long UserID { get; set; }

        /// <summary>
        /// Дата просмотра
        /// </summary>
        public DateTime Date { get; set; }
    }

    /// <summary>
    /// Отображение сотрудников
    /// </summary>
    public class EmployeesView : IDataView
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
            var searchCriteria = searchParameters as EmployeesSearchParameters;

            using (SqlCommand command = new SqlCommand("[dbo].[pr_aw_get_present_employees_list]", new SqlConnection(Properties.Settings.Default.JDE_PROCConnectionString)))
            {
                command.CommandTimeout = DEFAULT_RESPONSE_TIMEOUT;
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@Date", SqlDbType.DateTime) { Value = searchCriteria.Date });

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

        public EmployeesView()
        {
            this.dataColumns.Add(new PatternColumn("Код", "EmployeeID", new FilterCompareExpressionRule<Int32>("EmployeeID"), SummaryCalculationType.Count) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Сотрудник", "EmployeeName", new FilterPatternExpressionRule("EmployeeName")) { Width = 250 });
            this.dataColumns.Add(new PatternColumn("Отдел", "Department", new FilterPatternExpressionRule("Department")) { Width = 150 });
            this.dataColumns.Add(new PatternColumn("Станции", "LinkedStations", new FilterPatternExpressionRule("LinkedStations")) { Width = 150 });
        }
        #endregion
    }
}
