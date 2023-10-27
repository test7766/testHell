using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.WH.PL
{
    public partial class SetPLLabelPrintProperties : DialogForm
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm waitProcessForm = new WMSOffice.Dialogs.SplashForm();

        /// <summary>
        /// Ид-р выбранного принтера
        /// </summary>
        public String SelectedPrinter
        {
            get { return cmbPrinters.SelectedValue.ToString(); }
        }

        /// <summary>
        /// Кол-во этикеток
        /// </summary>
        public Int32 Quantity
        {
            get { return Convert.ToInt32(nudLabelsCount.Value); }
            set { nudLabelsCount.Value = value; }
        }

        /// <summary>
        /// Название выбранного типа SSCC
        /// </summary>
        public String SelectedSSCCTypeName
        {
            get { return ((cmbSSCCTypes.SelectedItem as DataRowView).Row as Data.WH.SSCCTypesRow).pl_type_name; }
        }

        /// <summary>
        /// Описание выбранного типа SSCC
        /// </summary>
        public String SelectedSSCCTypeDescription
        {
            get { return ((cmbSSCCTypes.SelectedItem as DataRowView).Row as Data.WH.SSCCTypesRow).pl_type_dsc; }
        }

        /// <summary>
        /// Режим печати новых этикеток
        /// </summary>
        public Boolean UseNewLabelPrintMode { get; set; }

        public SetPLLabelPrintProperties()
        {
            InitializeComponent();
            this.UseNewLabelPrintMode = true;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.LoadPrinters();
            this.LoadSSCCTypes();

            if (!this.UseNewLabelPrintMode)
            {
                this.Quantity = 1;
                this.nudLabelsCount.Enabled = false;
            }

            this.btnOK.Location = new Point(107, 8);
            this.btnCancel.Location = new Point(197, 8);
    }

        #region ФОНОВАЯ ЗАГРУЗКА СПИСКА ПРИНТЕРОВ
        private void LoadPrinters()
        {
            BackgroundWorker loadWorker = new BackgroundWorker();
            loadWorker.DoWork += new DoWorkEventHandler(loadWorker_DoWork);
            loadWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(loadWorker_RunWorkerCompleted);

            this.pLSSCCPrinterListBindingSource.DataSource = null;
            waitProcessForm.ActionText = "Получение списка принтеров...";
            loadWorker.RunWorkerAsync();
            waitProcessForm.ShowDialog();
        }

        void loadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = this.pL_SSCC_PrinterListTableAdapter.GetData(this.UserID);
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
                MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.wH.PL_SSCC_PrinterList.Clear();
            }
            else
                this.pLSSCCPrinterListBindingSource.DataSource = e.Result;

            this.waitProcessForm.CloseForce();
        }
        #endregion

        private void LoadSSCCTypes()
        {
            try
            {
                this.sSCCTypesTableAdapter.Fill(this.wH.SSCCTypes, this.UserID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка получения типов SSCC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
