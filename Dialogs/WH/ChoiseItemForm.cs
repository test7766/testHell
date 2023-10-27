using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.WH
{
    public partial class ChoiseItemForm : DialogForm
    {
        private Dialogs.SplashForm waitProcessForm = new WMSOffice.Dialogs.SplashForm();
        public Data.WH.ItemsRow SelectedItem
        {
            get 
            {
                if (dgvItems.SelectedRows.Count == 0)
                    return null;
                else
                    return (Data.WH.ItemsRow)((DataRowView)dgvItems.SelectedRows[0].DataBoundItem).Row;
            }
        }

        /// <summary>
        /// Свалидированное значение
        /// </summary>
        public Data.WH.ItemsRow VerifiedItem { get; private set; }

        public ChoiseItemForm()
        {
            try
            {
                Config.LoadDataGridViewSettings("ChoiseItemForm", dgvItems);
            }
            catch (Exception ex)
            {
                
            }
            InitializeComponent();
            this.ApplyOperation(DialogResult.None);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            //this.btnOK.Location = new Point(362, 8);
            //this.btnCancel.Location = new Point(452, 8);

            this.tbItemID.Focus();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.SearchItems();  
        }

        private void SearchItems()
        {
            BackgroundWorker loadWorker = new BackgroundWorker();
            loadWorker.DoWork += new DoWorkEventHandler(loadWorker_DoWork);
            loadWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(loadWorker_RunWorkerCompleted);
            this.itemsBindingSource.DataSource = null;
            waitProcessForm.ActionText = "Обработка запроса...";
            loadWorker.RunWorkerAsync();
            waitProcessForm.ShowDialog();

        }

        private void loadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                int? itemID = (tbItemID.Text == string.Empty) ? (int?)null : Convert.ToInt32(tbItemID.Text);
                string itemName = tbItemName.Text.Trim();
                e.Result = this.itemsTableAdapter.GetData(itemName, itemID);
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
                this.wH.Items.Clear();
            }
            else
                this.itemsBindingSource.DataSource = e.Result;

            waitProcessForm.CloseForce();
        }


        private void tbItemID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.SearchItems();
        }

        private void tbItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.SearchItems();
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

        private void tbItemID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void dgvItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
                this.ApplyOperation(DialogResult.OK);
        }

        private void ChoiseItemForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Config.SaveDataGridViewSettings("ChoiseItemForm", dgvItems);
            }
            catch (Exception ex)
            {
                
            }
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.ValidateOperation();
        }

        private bool ValidateOperation()
        {
            if (this.SelectedItem == null)
            {
                MessageBox.Show("Не выбран товар из списка!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

            int itemID;
            if (!Int32.TryParse(value, out itemID))
                return false;

            BackgroundWorker verifyWorker = new BackgroundWorker();
            verifyWorker.DoWork += new DoWorkEventHandler(verifyWorker_DoWork);
            verifyWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(verifyWorker_RunWorkerCompleted);
            waitProcessForm.ActionText = "Валидация на соответствие справочнику..";
            verifyWorker.RunWorkerAsync(itemID);
            waitProcessForm.ShowDialog();

            return this.VerifiedItem != null;
        }

        void verifyWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                int itemID = Convert.ToInt32(e.Argument.ToString());
                var table = this.itemsTableAdapter.GetData(null, itemID);
                if (table.Rows.Count != 0)
                    this.VerifiedItem = table[0];
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
