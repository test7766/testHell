using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Reports;
using WMSOffice.Classes;
using CrystalDecisions.CrystalReports.Engine;
using WMSOffice.Controls.EBW;

namespace WMSOffice.Dialogs.PickControl
{
    public partial class MultiPickRegistrationForm : DialogForm
    {
        public new long UserID { get; set; }

        public int? EmployeeID { get; set; }

        public string EmployeeName { get; set; }

        public long? DocID { get; private set; }

        private int cntPickSlip;

        public MultiPickRegistrationForm()
        {
            InitializeComponent();
        }

        private void MultiPickRegistrationForm_Load(object sender, EventArgs e)
        {
            try
            {
                var docID = (long?)null;

                // Получение количества доступных сборочных
                cntPickSlip = Convert.ToInt32(multiPickSlipDetailsTableAdapter.GetPickSlipCount(this.UserID));

                // Регистрация документа мультисборки
                multiPickSlipDetailsTableAdapter.CreateTask(this.UserID, this.EmployeeID, ref docID);

                if (!(DocID = docID).HasValue)
                    throw new Exception("Не удалось зарегистрировать мультисборку!");

                // Получение списка рекомендуемых сборочных
                ReloadRecommendedPickSlips();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (string.IsNullOrEmpty(this.EmployeeName))
                this.Text = string.Format("{0} № {1}", this.Text, this.DocID);
            else
                this.Text = string.Format("{0} № {1} [{2}]", this.Text, this.DocID, this.EmployeeName);

            tbPickSlipCount.Text = string.Format("{0}", cntPickSlip);

            PrintDocsThread.FillPrintersComboBox(cmbPrinters);

            //tbBarcode.KeyPress += delegate(object sender, KeyPressEventArgs ea)
            //{
            //    if (!Char.IsDigit(ea.KeyChar) && ea.KeyChar != '\b')
            //        ea.Handled = true;
            //};

            tbBarcode.TextChanged += new EventHandler(tbBarcode_TextChanged);

            this.btnOK.Location = new Point(726, 8);
            this.btnCancel.Location = new Point(807, 8);
        }

        void tbBarcode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbBarcode.Text))
                    return;

                var errorCode = (int?)null;
                var errorMessage = (string)null;

                // Добавление сборочного в документ мультисборки 
                multiPickSlipDetailsTableAdapter.AddTaskDetail(this.UserID, this.DocID, tbBarcode.Text, ref errorCode, ref errorMessage);

                if ((errorCode.HasValue && errorCode.Value > 0) || !string.IsNullOrEmpty(errorMessage))
                    throw new Exception(errorMessage);

                // Получение деталей документа мультисборки
                ReloadMultiPickSlipDetails();

                // Получение списка рекомендуемых сборочных
                ReloadRecommendedPickSlips();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            tbBarcode.Text = string.Empty;
            tbBarcode.Focus();
        }

        private void ReloadMultiPickSlipDetails()
        {
            multiPickSlipDetailsTableAdapter.Fill(pickControl.MultiPickSlipDetails, this.UserID, this.DocID);
        }

        private bool loadingRecommendedPickSlipsInProgress = false;
        private bool waitForLoadingRecommendedPickSlips = false;
        private void ReloadRecommendedPickSlips()
        {
            if (loadingRecommendedPickSlipsInProgress)
            {
                waitForLoadingRecommendedPickSlips = true;
                return;
            }

            loadingRecommendedPickSlipsInProgress = true;

            var ebw = new EmbeddedBackgroundWorker(dgvRecommendedPickSlips, "Выполняется загрузка рекомендуемых сборочных..");
            ebw.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    e.Result = recomendedPickSlipsTableAdapter.GetData(this.UserID);
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            };
            ebw.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
            {
                loadingRecommendedPickSlipsInProgress = false;

                if (e.Result is Exception)
                    MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    pickControl.RecomendedPickSlips.Merge(e.Result as Data.PickControl.RecomendedPickSlipsDataTable);
                    recomendedPickSlipsBindingSource.DataSource = e.Result;
                }

                if (waitForLoadingRecommendedPickSlips)
                {
                    // Повторное получение списка рекомендуемых сборочных
                    ReloadRecommendedPickSlips();
                    waitForLoadingRecommendedPickSlips = false;
                }
            };

            pickControl.RecomendedPickSlips.Clear();
            recomendedPickSlipsBindingSource.DataSource = null;
            ebw.RunWorkerAsync();
        }

        private void MultiPickRegistrationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !ConfirmMultiPickRegistration();
            else
                e.Cancel = !CancelMultiPickRegistration();
            
        }

        private bool ConfirmMultiPickRegistration()
        {
            try
            {
                if (pickControl.MultiPickSlipDetails.Count == 0)
                    throw new Exception("Мультисборочный не содержит сборочных!");

                // Визирование документа мультисборки
                multiPickSlipDetailsTableAdapter.ChangeTaskStatus(this.UserID, this.DocID, (string)null, "120");

                // Получение отсортированных деталей документа мультисборки
                ReloadMultiPickSlipDetails();

                // Печать документа мультисборки
                PrintMultiPickDocument();

                // Подтверждение печати документа мультисборки
                multiPickSlipDetailsTableAdapter.ChangeTaskStatus(this.UserID, this.DocID, (string)null, "199");

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void PrintMultiPickDocument()
        {
            var report = MultiPickRegistrationForm.PrepareMultiPickDocument(this.UserID, this.DocID.Value);
            report.PrintOptions.PrinterName = (string)cmbPrinters.SelectedItem;
            report.PrintToPrinter(1, false, 1, 0);
        }

        public static ReportDocument PrepareMultiPickDocument(long UserID, long DocID)
        {
            var pickControl = new Data.PickControl();

            // Получение заголовка сборочных
            using (var adapter = new Data.PickControlTableAdapters.MultiPickSlipReportHeadersTableAdapter())
                adapter.Fill(pickControl.MultiPickSlipReportHeaders, UserID, DocID);

            if (pickControl.MultiPickSlipReportHeaders.Count == 0)
                throw new Exception("Не определены заголовки сборочных в мультисборочном!");


            // Получение состава сборочных
            using (var adapter = new Data.PickControlTableAdapters.MultiPickSlipReportDetailsTableAdapter())
                adapter.Fill(pickControl.MultiPickSlipReportDetails, UserID, DocID);

            if (pickControl.MultiPickSlipReportDetails.Count == 0)
                throw new Exception("Не определен состав сборочных в мультисборочном!");


            // Формирование изображения со штрихкодом мультисборочного
            foreach (Data.PickControl.MultiPickSlipReportDetailsRow psl in pickControl.MultiPickSlipReportDetails)
                psl.bar_code_image = Dialogs.Complaints.BarCodeGenerator.GetBarcodeCODE39(psl.bar_code.Trim());

            // Создание печатной формы документа мультисборки
            var report = new MultiPickSlipReport();
            report.SetDataSource(pickControl);

            // Установка номера мультисборочного
            report.SetParameterValue("MPSN", DocID);

            return report;
        }

        private bool CancelMultiPickRegistration()
        {
            try
            {
                // Подтверждение печати документа мультисборки
                multiPickSlipDetailsTableAdapter.ChangeTaskStatus(this.UserID, this.DocID, (string)null, "198");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
