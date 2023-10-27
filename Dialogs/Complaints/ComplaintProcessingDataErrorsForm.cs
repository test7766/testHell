using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Complaints
{
    public partial class ComplaintProcessingDataErrorsForm : DialogForm
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных
        /// </summary>
        private Dialogs.SplashForm waitProgressForm = new WMSOffice.Dialogs.SplashForm();

        /// <summary>
        /// Номер претензии
        /// </summary>
        public long? DocID { get; set; }

        public ComplaintProcessingDataErrorsForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.btnOK.Location = new Point(394, 8);
            this.btnCancel.Location = new Point(484, 8);

            this.LoadErrors();
        }

        private void LoadErrors()
        {
            BackgroundWorker loadWorker = new BackgroundWorker();
            loadWorker.DoWork += new DoWorkEventHandler(loadWorker_DoWork);
            loadWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(loadWorker_RunWorkerCompleted);
            waitProgressForm.ActionText = "Загрузка ошибок, возникших при проверке претензии...";
            this.complaintProcessingDataErrorsBindingSource.DataSource = null;
            loadWorker.RunWorkerAsync();
            waitProgressForm.ShowDialog();
        }


        void loadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = complaintProcessingDataErrorsTableAdapter.GetData(this.UserID, this.DocID);
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        void loadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
            {
                complaints.ComplaintProcessingDataErrors.Clear();
                MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                this.complaintProcessingDataErrorsBindingSource.DataSource = e.Result;

            waitProgressForm.CloseForce();
        }
    }
}
