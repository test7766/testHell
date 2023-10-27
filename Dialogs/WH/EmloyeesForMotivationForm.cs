using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.ExtraDataGridViewComponents;

namespace WMSOffice.Dialogs.WH
{
    public partial class EmloyeesForMotivationForm : DialogForm
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        public int? SelectedEmployeeID { get; private set; }

        public string SelectedEmployeeName { get; private set; }

        public EmloyeesForMotivationForm()
        {
            InitializeComponent();
        }

        public EmloyeesForMotivationForm(int? employeeID)
            : this()
        {
            this.SelectedEmployeeID = employeeID;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Initialize();

            this.btnOK.Location = new Point(707, 8);
            this.btnCancel.Location = new Point(797, 8);

            this.LoadData();
        }

        private void Initialize()
        {
            this.xdgvEmployees.UseMultiSelectMode = false;

            //this.xdgvEmployees.AllowFilter = false;
            this.xdgvEmployees.AllowSummary = false;
            this.xdgvEmployees.AllowRangeColumns = true;

            this.xdgvEmployees.Init(new EmployeesForMotivationView(), true);

            this.xdgvEmployees.UserID = this.UserID;

            this.xdgvEmployees.OnDataError += (s, e) => { e.ThrowException = false; };
            this.xdgvEmployees.OnRowDoubleClick += (s, e) => { this.DialogResult = DialogResult.OK; };
            //this.xdgvEmployees.OnRowSelectionChanged += (s, e) => { };
            this.xdgvEmployees.OnFilterChanged += (s, e) => { this.xdgvEmployees.RecalculateSummary(); };
        }

        private void LoadData()
        {
            BackgroundWorker loadWorker = new BackgroundWorker();
            loadWorker.DoWork += (s, e) =>
            {
                try
                {
                    var sessionID = this.UserID;
                    var employeeID = (int?)null; // this.SelectedEmployeeID;
                  
                    var searchCriteria = new EmployeesForMotivationSearchParameters() { SessionID = sessionID , EmployeeID = employeeID };
                    this.xdgvEmployees.DataView.FillData(searchCriteria);
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            };

            loadWorker.RunWorkerCompleted += (s, e) =>
            {
                if (e.Result is Exception)
                {
                    MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.xdgvEmployees.BindData(false);

                    //this.xdgvEmployees.AllowFilter = true;
                    this.xdgvEmployees.AllowSummary = true;

                    this.SelectEmployee();
                }

                splashForm.CloseForce();
            };

            splashForm.ActionText = "Поиск сотрудников...";
            loadWorker.RunWorkerAsync();
            splashForm.ShowDialog();
        }

        private void SelectEmployee()
        {
            if (this.SelectedEmployeeID.HasValue)
            {
                this.xdgvEmployees.SelectRow("Employee_ID", this.SelectedEmployeeID.ToString());
                this.xdgvEmployees.ScrollToSelectedRow();
            }
        }

        private void EmloyeesForMotivationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.ValidateEmployee();
        }

        private bool ValidateEmployee()
        {
            try
            {
                if (xdgvEmployees.SelectedItem == null)
                    throw new Exception("Не выбран сотрудник.");

                var employee = xdgvEmployees.SelectedItem as Data.WH.EmployeesForMotivationRow;
                this.SelectedEmployeeID = employee.Employee_ID;
                this.SelectedEmployeeName = employee.Employee;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }

    /// <summary>
    /// Представление для списка сотрудников мотивации
    /// </summary>
    public class EmployeesForMotivationView : IDataView
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

        public void FillData(SearchParametersBase searchParameters)
        {
            var searchCriteria = searchParameters as EmployeesForMotivationSearchParameters;

            using (var adapter = new Data.WHTableAdapters.EmployeesForMotivationTableAdapter())
            {
                adapter.SetTimeout(DEFAULT_RESPONSE_TIMEOUT);
                data = adapter.GetData(searchCriteria.SessionID, searchCriteria.EmployeeID);
            }
        }

        #endregion

        public EmployeesForMotivationView()
        {
            this.dataColumns.Add(new PatternColumn("Код", "Employee_ID", new FilterCompareExpressionRule<Int32>("Employee_ID"), SummaryCalculationType.Count) { Width = 80 });
            this.dataColumns.Add(new PatternColumn("Ф.И.О.", "Employee", new FilterPatternExpressionRule("Employee")) { Width = 200 });
            this.dataColumns.Add(new PatternColumn("Подразделение", "BusinessUnitName", new FilterPatternExpressionRule("BusinessUnitName"), SummaryCalculationType.Count) { Width = 570 });
        }
    }

    /// <summary>
    /// Критерий поиска
    /// </summary>
    public class EmployeesForMotivationSearchParameters : SessionIDSearchParameters
    {
        public int? EmployeeID { get; set; }
    }


}
