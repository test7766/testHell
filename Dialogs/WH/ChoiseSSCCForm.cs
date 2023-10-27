using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.WH
{
    public partial class ChoiseSSCCForm : DialogForm
    {
        private Dialogs.SplashForm waitProcessForm = new WMSOffice.Dialogs.SplashForm();
        public Data.WH.SSCCByLocationRow SelectedItem
        {
            get
            {
                if (dgvSSCC.SelectedRows.Count == 0)
                    return null;
                else
                    return (Data.WH.SSCCByLocationRow)((DataRowView)dgvSSCC.SelectedRows[0].DataBoundItem).Row;
            }
        }

        /// <summary>
        /// Свалидированное значение
        /// </summary>
        public Data.WH.SSCCByLocationRow VerifiedItem { get; private set; }

        /// <summary>
        /// Код склада
        /// </summary>
        public String WarehouseID { get; set; }

        /// <summary>
        /// Место
        /// </summary>
        public String LocationID { get; set; }

        /// <summary>
        /// Код товара
        /// </summary>
        public Int32? ItemID { get; set; }

        /// <summary>
        /// Серия
        /// </summary>
        public String VendorLot { get; set; }

        /// <summary>
        /// Партия
        /// </summary>
        public String LotNumber { get; set; }

        /// <summary>
        /// Кол-во
        /// </summary>
        public Double? Quantity { get; set; }

        public ChoiseSSCCForm()
        {
            InitializeComponent();

            try
            {
                Config.LoadDataGridViewSettings("ChoiseSSCCForm", dgvSSCC);
            }
            catch (Exception ex)
            {
                
            }
            this.ApplyOperation(DialogResult.None);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Search();
        }

        private void Search()
        {
            BackgroundWorker loadWorker = new BackgroundWorker();
            loadWorker.DoWork += new DoWorkEventHandler(loadWorker_DoWork);
            loadWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(loadWorker_RunWorkerCompleted);
            this.sSCCByLocationBindingSource.DataSource = null;
            waitProcessForm.ActionText = "Обработка запроса...";
            loadWorker.RunWorkerAsync();
            waitProcessForm.ShowDialog();

            // Если кол-во эл-тов равно 1 - то выбираем автоматически
            //if (this.dgvSSCC.RowCount == 1)
            //    this.ApplyOperation(DialogResult.OK);
        }

        private void loadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = this.sSCCByLocationTableAdapter.GetData(this.UserID, this.WarehouseID, this.LocationID, this.ItemID, 
                    this.VendorLot, this.LotNumber, this.Quantity, null);
            }
            catch (Exception error)
            {
                e.Result = error;
            }
        }

        private void loadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
            {
                MessageBox.Show((e.Result as Exception).ToString(), "Ошибка поиска", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.wH.SSCCByLocation.Clear();
            }
            else
                this.sSCCByLocationBindingSource.DataSource = e.Result;

            waitProcessForm.CloseForce();
        }

        private void ApplyOperation(DialogResult agreedResult)
        {
            this.DialogResult = agreedResult;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.ApplyOperation(DialogResult.OK);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ApplyOperation(DialogResult.Cancel);
        }

        private void dgvSSCC_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
                this.ApplyOperation(DialogResult.OK);
        }

        private void ChoiseSSCCForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                e.Cancel = !ValidateOperation();
                try
                {
                    Config.SaveDataGridViewSettings("ChoiseSSCCForm", dgvSSCC);
                }
                catch (Exception ex)
                {
                    
                }
            }
        }

        private bool ValidateOperation()
        {
            if (this.SelectedItem == null)
            {
                MessageBox.Show("Не выбран SSCC из списка!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Валидация введенного значения
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool VerifyValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;

            string sscc = value;

            BackgroundWorker verifyWorker = new BackgroundWorker();
            verifyWorker.DoWork += new DoWorkEventHandler(verifyWorker_DoWork);
            verifyWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(verifyWorker_RunWorkerCompleted);
            waitProcessForm.ActionText = "Валидация на соответствие справочнику..";
            verifyWorker.RunWorkerAsync(sscc);
            waitProcessForm.ShowDialog();

            return this.VerifiedItem != null;
        }

        void verifyWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string sscc = e.Argument.ToString();
                var table = this.sSCCByLocationTableAdapter.GetData(this.UserID, this.WarehouseID, this.LocationID, this.ItemID, this.VendorLot, this.LotNumber, this.Quantity, sscc);
                if (table.Rows.Count != 0)
                {
                    var a = table[0].ItemArray;
                    this.VerifiedItem = table[0];
                }
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        void verifyWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            waitProcessForm.CloseForce();
        }
    }
}
