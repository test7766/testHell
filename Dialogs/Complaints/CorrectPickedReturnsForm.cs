using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Complaints
{
    public partial class CorrectPickedReturnsForm : DialogForm
    {
        public long? VRDocID { get; private set; }
        public long? CorrectDocID { get; private set; } 
        
        public CorrectPickedReturnsForm()
        {
            InitializeComponent();
        }

        public CorrectPickedReturnsForm(long vrDocID)
            : this()
        {
            this.VRDocID = vrDocID;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            btnOK.Location = new Point(717, 8);
            btnCancel.Location = new Point(807, 8);

            btnOK.Visible = false;
            btnCancel.Text = "Закрыть";

            if (!this.CreateDoc())
            {
                this.DialogResult = DialogResult.Abort;
                return;
            }

            this.Text = string.Format(this.Text, this.CorrectDocID);
            this.RefreshDocLines((string)null);

            this.WindowState = FormWindowState.Maximized;
        }

        private bool CreateDoc()
        {
            try
            {
                var correctDocID = (long?)null;

                using (var adapter = new Data.ComplaintsTableAdapters.VR_NR_DocLinesTableAdapter())
                    adapter.CreateDoc(this.VRDocID, this.UserID, ref correctDocID);

                if (!correctDocID.HasValue)
                    throw new Exception("Не удалось создать документ корректировки.");

                this.CorrectDocID = correctDocID;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btbRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshDocLines(null);
        }

        private void RefreshDocLines(string boxBar)
        {
            try
            {
                if (string.IsNullOrEmpty(boxBar) && dgvDocLines.SelectedRows.Count > 0)
                    boxBar = ((dgvDocLines.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.Complaints.VR_NR_DocLinesRow).Box_Bar;

                using (var adapter = new Data.ComplaintsTableAdapters.VR_NR_DocLinesTableAdapter())
                    adapter.Fill(complaints.VR_NR_DocLines, this.VRDocID, this.CorrectDocID, this.UserID);

                this.FindDocLine(boxBar);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FindDocLine(string boxBar)
        {
            if (string.IsNullOrEmpty(boxBar))
                return;

            foreach (DataGridViewRow row in dgvDocLines.Rows)
            {
                var boundRow = (row.DataBoundItem as DataRowView).Row as Data.Complaints.VR_NR_DocLinesRow;
                if (boundRow.Box_Bar.Equals(boxBar, StringComparison.OrdinalIgnoreCase))
                {
                    row.Selected = true;
                    dgvDocLines.FirstDisplayedScrollingRowIndex = row.Index;
                }
            }
        }

        private void btnConfirmDoc_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelDoc_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void CorrectPickedReturnsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (!this.UpdateDoc(false))
                    e.Cancel = true;
            }

            if (this.DialogResult == DialogResult.Cancel)
            {
                if (!this.UpdateDoc(true))
                    e.Cancel = true;
            }
        }

        private bool UpdateDoc(bool isCancelled)
        {
            try
            {
                using (var adapter = new Data.ComplaintsTableAdapters.VR_NR_DocLinesTableAdapter())
                    adapter.ConfirmDoc(this.VRDocID, this.CorrectDocID, this.UserID, isCancelled);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void dgvDocLines_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvDocLines.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvDocLines.CommitEdit(DataGridViewDataErrorContexts.Commit);

                //// Раскраска
                //bool isChecked = Convert.ToBoolean(this.dgvDocLines.Rows[this.dgvDocLines.CurrentRow.Index].Cells[this.isselectedDataGridViewCheckBoxColumn.Index].Value);
                //foreach (DataGridViewColumn column in this.dgvDocLines.Columns)
                //{
                //    this.dgvDocLines.Rows[this.dgvDocLines.CurrentRow.Index].Cells[column.Index].Style.BackColor = isChecked ? Color.FromArgb(209, 255, 117) : SystemColors.Window;
                //    this.dgvDocLines.Rows[this.dgvDocLines.CurrentRow.Index].Cells[column.Index].Style.SelectionForeColor = isChecked ? Color.FromArgb(209, 255, 117) : Color.Black;
                //}
            }
        }

        private void dgvDocLines_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Раскраска
            bool isChecked = Convert.ToBoolean(this.dgvDocLines.Rows[e.RowIndex].Cells[this.isselectedDataGridViewCheckBoxColumn.Index].Value);
            this.dgvDocLines.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = isChecked ? Color.FromArgb(209, 255, 117) : SystemColors.Window;
            this.dgvDocLines.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = isChecked ? Color.FromArgb(209, 255, 117) : Color.Black;
        }

        private void dgvDocLines_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            if (e.ColumnIndex == this.isselectedDataGridViewCheckBoxColumn.Index)
            {
                var boundRow = (dgvDocLines.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Complaints.VR_NR_DocLinesRow;

                if (boundRow.is_selected)
                    this.AddDocLine(boundRow.Box_Bar);
                else
                    this.DeleteDocLine(boundRow.Box_Bar);
            }
        }

        private void AddDocLine(string boxBar)
        {
            try
            {
                using (var adapter = new Data.ComplaintsTableAdapters.VR_NR_DocLinesTableAdapter())
                    adapter.AddLine(this.VRDocID, this.CorrectDocID, boxBar, this.UserID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.RefreshDocLines(boxBar);
            }
        }

        private void DeleteDocLine(string boxBar)
        {
            try
            {
                using (var adapter = new Data.ComplaintsTableAdapters.VR_NR_DocLinesTableAdapter())
                    adapter.DeleteLine(this.VRDocID, this.CorrectDocID, boxBar, this.UserID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.RefreshDocLines(boxBar);
            }
        }
    }
}
