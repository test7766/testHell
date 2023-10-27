using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.WH.TSD
{
    public partial class TSD_AltLiftTasksChangeForm : DialogForm
    {
        public TSD_AltLiftTasksChangeForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(217, 8);
            this.btnCancel.Location = new Point(307, 8);

            this.btnOK.Visible = false;
            this.btnCancel.Text = "Закрыть";
        }

        private void TSD_AltLiftTasksChangeForm_Load(object sender, EventArgs e)
        {
            this.ReloadData();    
        }

        private void ReloadData()
        {
            try
            {
                liftsTableAdapter.Fill(tSD.Lifts, this.UserID);

                if (dgvLifts.Rows.Count > 0)
                    dgvLifts.Rows[0].Selected = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvLifts_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvLifts.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvLifts.CommitEdit(DataGridViewDataErrorContexts.Commit);

                // Раскраска
                bool isChecked = Convert.ToBoolean(this.dgvLifts.Rows[dgvLifts.CurrentRow.Index].Cells[activeflagDataGridViewCheckBoxColumn.Index].Value);
                foreach (DataGridViewColumn column in dgvLifts.Columns)
                {
                    dgvLifts.Rows[dgvLifts.CurrentRow.Index].Cells[column.Index].Style.BackColor = isChecked ? Color.FromArgb(209, 255, 117) : SystemColors.Window;
                    dgvLifts.Rows[dgvLifts.CurrentRow.Index].Cells[column.Index].Style.SelectionBackColor = isChecked ? Color.FromArgb(209, 255, 117) : SystemColors.Window;
                    dgvLifts.Rows[dgvLifts.CurrentRow.Index].Cells[column.Index].Style.SelectionForeColor = Color.Black;
                }
            }
        }

        private void dgvLifts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            // Раскраска
            bool isChecked = Convert.ToBoolean(dgvLifts.Rows[e.RowIndex].Cells[activeflagDataGridViewCheckBoxColumn.Index].Value);
            dgvLifts.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = isChecked ? Color.FromArgb(209, 255, 117) : SystemColors.Window;
            dgvLifts.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionBackColor = isChecked ? Color.FromArgb(209, 255, 117) : SystemColors.Window;
            dgvLifts.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = Color.Black;
        }

        private void dgvLifts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                var lift = (dgvLifts.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.TSD.LiftsRow;
                var liftID = lift.Lift_Id;
                var activeFlag = lift.Isactive_flagNull() ? false : lift.active_flag;

                liftsTableAdapter.UpdateStatus(liftID, activeFlag, this.UserID);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
