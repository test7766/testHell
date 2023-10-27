using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.WH.TSD
{
    public partial class TSD_Selector : DialogForm
    {
        /// <summary>
        /// Индикатор выполнения длительной операции
        /// </summary>
        private Dialogs.SplashForm waitProcessForm = new WMSOffice.Dialogs.SplashForm();

        /// <summary>
        /// № документа
        /// </summary>
        public Int64? DocID { get; set; }

        /// <summary>
        /// Тип документа
        /// </summary>
        public string DocTypeID { get; set; }

        /// <summary>
        /// Код склада
        /// </summary>
        public string WarehouseID { get; set; }

        /// <summary>
        /// Полка "С"
        /// </summary>
        public string LocationFrom { get; set; }

        /// <summary>
        /// Полка "НА"
        /// </summary>
        public string LocationTo { get; set; }

        /// <summary>
        /// № выбранного ТСД
        /// </summary>
        public string SelectedTerminalID { get; private set; }

        public TSD_Selector()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.btnOK.Location = new Point(307, 8);
            this.btnCancel.Location = new Point(397, 8);

            this.LoadData();
        }

        #region ФОНОВАЯ ЗАГРУЗКА ДАННЫХ
        private void LoadData()
        {
            BackgroundWorker loadWorker = new BackgroundWorker();
            loadWorker.DoWork += new DoWorkEventHandler(loadWorker_DoWork);
            loadWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(loadWorker_RunWorkerCompleted);

            this.selectedTerminalsBindingSource.DataSource = null;
            waitProcessForm.ActionText = "Выполняется загрузка ТСД..";
            loadWorker.RunWorkerAsync();
            waitProcessForm.ShowDialog();
        }

        void loadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
               e.Result = this.selectedTerminalsTableAdapter.GetData(this.UserID, this.DocID, this.DocTypeID, this.WarehouseID, this.LocationFrom, this.LocationTo);
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        void loadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                this.selectedTerminalsBindingSource.DataSource = e.Result;

            waitProcessForm.CloseForce();
        }
        #endregion

        private void TSD_Selector_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.ValidateSelection();
        }

        /// <summary>
        /// Валидация выбора элемента из списка
        /// </summary>
        /// <returns></returns>
        private bool ValidateSelection()
        {
            if (this.dgvSelector.SelectedRows.Count > 0)
            {
                this.SelectedTerminalID = ((this.dgvSelector.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.TSD.SelectedTerminalsRow).terminal_id;
                return true;
            }
            else
            {
                MessageBox.Show("Для назначения задания необходимо выбрать ТСД.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.SelectedTerminalID = null;
                return false;
            }
        }

        private void dgvSelector_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
