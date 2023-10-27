using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.PickControl
{
    public partial class SearchVendorLotForm : DialogForm
    {
        public long? DocID { get; private set; }
        public int ItemID { get; private set; }
        public string ItemName { get; private set; }
        public int? SurplusMode { get; private set; }
        public long? ProcessVersionID { get; private set; }

        public Data.PickControl.VendorLotsRow SelectedVendorLot { get; private set; }

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных
        /// </summary>
        private Dialogs.SplashForm waitProgressForm = new WMSOffice.Dialogs.SplashForm();

        public SearchVendorLotForm()
        {
            InitializeComponent();
        }

        public SearchVendorLotForm(long? docID, int itemID, string itemName, int? surplusMode, long? processVersionID)
            : this()
        {
            this.DocID = docID;
            this.ItemID = itemID;
            this.ItemName = itemName;
            this.SurplusMode = surplusMode;
            this.ProcessVersionID = processVersionID;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Text = string.Format("{0} {1}", this.Text, this.ItemName);

            this.btnOK.Location = new Point(517, 8);
            this.btnCancel.Location = new Point(607, 8);

            this.LoadData(false);
        }

        private void LoadData(bool searchInArchive)
        {
            var loadWorker = new BackgroundWorker();
            loadWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    var searchInArchiveMode = Convert.ToInt32(searchInArchive);
                    e.Result = vendorLotsTableAdapter.GetData(this.DocID, this.ItemID, (string)null, this.SurplusMode, searchInArchiveMode, this.ProcessVersionID);
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            };
            loadWorker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Result is Exception)
                    MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    vendorLotsBindingSource.DataSource = e.Result;

                waitProgressForm.CloseForce();
            };

            vendorLotsBindingSource.DataSource = null;
            waitProgressForm.ActionText = "Выполняется поиск серий..";
            
            loadWorker.RunWorkerAsync();
            waitProgressForm.ShowDialog();

            SetFilter(tbFilter.Text);
        }

        private void cbSearchInArchive_CheckedChanged(object sender, EventArgs e)
        {
            LoadData(cbSearchInArchive.Checked);
        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            SetFilter(tbFilter.Text);
        }

        private void SetFilter(string filter)
        {
            vendorLotsBindingSource.Filter = string.IsNullOrEmpty(filter) ? (string)null : string.Format("{0} LIKE '%{1}%'", pickControl.VendorLots.Vendor_LotColumn.Caption, filter);
        }

        private void tbFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
            {
                dgvItems.Focus();
            }
        }

        private void dgvItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void dgvItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void dgvItems_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Разрисовка строк в таблице
            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                DataRow dr = (row.DataBoundItem as DataRowView).Row;

                // Простая разрисовка строк
                Color backColor = (dr["Color"] == DBNull.Value ||
                                   string.IsNullOrEmpty(dr["Color"].ToString()) ||
                                   dr["Color"].ToString().ToLower() == "white")
                                      ? Color.White
                                      : Color.FromName(dr["Color"].ToString());

                for (int c = 0; c < row.Cells.Count; c++)
                {
                    row.Cells[c].Style.BackColor = backColor;
                    row.Cells[c].Style.SelectionForeColor = backColor;
                }
            }
        }

        private void SearchVendorLotForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.ValidateData();
        }

        private bool ValidateData()
        {
            try
            {
                if (dgvItems.SelectedRows.Count == 0)
                    throw new Exception("Серия не выбрана.");

                this.SelectedVendorLot = (dgvItems.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.PickControl.VendorLotsRow;
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
