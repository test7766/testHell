using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.WH
{
    public partial class SubscribersForm : DialogForm
    {
        private Dialogs.SplashForm waitProcessForm = new WMSOffice.Dialogs.SplashForm();

        #region Ответственные лица за подпись
        public string Sign1 { get { return cmbSign1.Text.Trim(); } }
        public string Sign2 { get { return cmbSign2.Text.Trim(); } }
        public string Sign3 { get { return cmbSign3.Text.Trim(); } }
        public string Sign4 { get { return cmbSign4.Text.Trim(); } }
        public string Sign5 { get { return cmbSign5.Text.Trim(); } }
        public string Sign6 { get { return cmbSign6.Text.Trim(); } }
        public string Sign7 { get { return cmbSign7.Text.Trim(); } }
        #endregion

        public SubscribersForm()
        {
            InitializeComponent();
            this.ApplyOperation(DialogResult.None);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.SetInterfaceSettings();
            this.LoadSubscribers();
        }

        private void SetInterfaceSettings()
        {
            this.btnOK.Location = new Point(302, 8);
            this.btnCancel.Location = new Point(392, 8);
        }

        private void LoadSubscribers()
        {
            BackgroundWorker loadWorker = new BackgroundWorker();
            loadWorker.DoWork += new DoWorkEventHandler(loadWorker_DoWork);
            loadWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(loadWorker_RunWorkerCompleted);
            waitProcessForm.ActionText = "Загрузка справочника сотрудников";
            loadWorker.RunWorkerAsync();
            waitProcessForm.ShowDialog();
        }

        private void loadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
               e.Result = this.employeesTableAdapter.GetData(this.UserID);
            }
            catch (Exception error)
            {
                e.Result = error;
            }
        }

        private void loadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var emptySignEmployee = this.wH.Employees.NewEmployeesRow();
            emptySignEmployee.Employee_ID = -1;
            emptySignEmployee.Employee = string.Empty;
            this.wH.Employees.AddEmployeesRow(emptySignEmployee);

            if (e.Result is Exception)
                MessageBox.Show((e.Result as Exception).ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                this.wH.Employees.Merge(e.Result as Data.WH.EmployeesDataTable);

            waitProcessForm.CloseForce();
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            this.ApplyOperation(DialogResult.OK);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ApplyOperation(DialogResult.Cancel);
        }

        private void ApplyOperation(DialogResult agreedResult)
        {
            this.DialogResult = agreedResult;
        }

        private void SubscribersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.ValidateOperation();
        }

        private bool ValidateOperation()
        {
            return true;
        }

        /// <summary>
        /// Возврат шапки подписчиков
        /// </summary>
        /// <returns></returns>
        public string GetSubscribersCaption()
        {
            StringBuilder sbSubscribers = new StringBuilder();
            sbSubscribers.Append(string.Format("Комиссия в составе: "));
            if (this.Sign1 != string.Empty)
            sbSubscribers.Append(string.Format("{0} {1}, ", lblSign1.Text.Trim(':'), this.Sign1));

            sbSubscribers.Append(string.Format("члены комиссии: "));
            if (this.Sign2 != string.Empty)
                sbSubscribers.Append(string.Format("{0} {1}, ", lblSign2.Text.Trim(':'), this.Sign2));
            if (this.Sign3 != string.Empty)
                sbSubscribers.Append(string.Format("{0} {1}, ", lblSign3.Text.Trim(':'), this.Sign3));
            if (this.Sign4 != string.Empty)
                sbSubscribers.Append(string.Format("{0} {1}, ", lblSign4.Text.Trim(':'), this.Sign4));
            if (this.Sign5 != string.Empty)
                sbSubscribers.Append(string.Format("{0} {1}, ", lblSign5.Text.Trim(':'), this.Sign5));
            if (this.Sign6 != string.Empty)
                sbSubscribers.Append(string.Format("{0} {1}, ", lblSign6.Text.Trim(':'), this.Sign6));
            if (this.Sign7 != string.Empty)
                sbSubscribers.Append(string.Format("{0} {1}, ", lblSign7.Text.Trim(':'), this.Sign7));

            return sbSubscribers.ToString().Trim(',', ' ');
        }
    }
}
