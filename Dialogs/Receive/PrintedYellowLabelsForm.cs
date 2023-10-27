using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Receive
{
    public partial class PrintedYellowLabelsForm : Form
    {
        public int ItemID { get; set; }

        public string LotNumber { get; set; }

        public PrintedYellowLabelsForm()
        {
            InitializeComponent();
        }

        private void PrintedYellowLabelsForm_Load(object sender, EventArgs e)
        {
            ReloadData();
        }

        private void ReloadData()
        {
            try
            {
                createdYLBindingSource.DataSource = createdYLTableAdapter.GetData(ItemID, LotNumber);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                createdYLBindingSource.DataSource = null;
            }
        }

        private void sbDeleteYellowLabels_Click(object sender, EventArgs e)
        {
            try
            {
                var canDelete = false;

                foreach (DataGridViewRow row in dgvDetails.Rows)
                    if ((bool)(row.Cells[dgvcCheckItems.Name].Value ?? false))
                    {
                        canDelete = true;
                        break;
                    }

                if (canDelete && MessageBox.Show("Вы действительно хотите удалить выбранные ж/э?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dgvDetails.Rows)
                    {
                        var isChecked = (bool)(row.Cells[dgvcCheckItems.Name].Value ?? false);
                        if (isChecked)
                        {
                            var boundRow = (row.DataBoundItem as DataRowView).Row as Data.Receive.CreatedYLRow;
                            var itemID = Convert.ToInt32(boundRow.BLITM);
                            var vendorLot = boundRow.BLLOTN;
                            var stickerID = Convert.ToInt32(boundRow.BLUKID);

                            DeleteYellowLabel(itemID, vendorLot, stickerID);
                        }
                    }

                    ReloadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteYellowLabel(int ItemID, string lotNumber, double stickerID)
        {
            using (var adapter = new Data.ReceiveTableAdapters.CreatedYLTableAdapter())
                adapter.DeleteCreatedYL(ItemID, lotNumber, stickerID);
        }

        private void dgvDetails_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvDetails.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvDetails.CommitEdit(DataGridViewDataErrorContexts.Commit);

                // Раскраска
                bool isChecked = Convert.ToBoolean(this.dgvDetails.Rows[this.dgvDetails.CurrentRow.Index].Cells[this.dgvcCheckItems.Index].Value);
                foreach (DataGridViewColumn column in this.dgvDetails.Columns)
                {
                    this.dgvDetails.Rows[this.dgvDetails.CurrentRow.Index].Cells[column.Index].Style.BackColor = isChecked ? Color.Salmon : SystemColors.Window;
                    this.dgvDetails.Rows[this.dgvDetails.CurrentRow.Index].Cells[column.Index].Style.SelectionForeColor = isChecked ? Color.Salmon : Color.Black;
                }
            }
        }

        private void dgvDetails_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Раскраска
            bool isChecked = Convert.ToBoolean(this.dgvDetails.Rows[e.RowIndex].Cells[this.dgvcCheckItems.Index].Value);
            this.dgvDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = isChecked ? Color.Salmon : SystemColors.Window;
            this.dgvDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = isChecked ? Color.Salmon : Color.Black;
        }
    }
}
