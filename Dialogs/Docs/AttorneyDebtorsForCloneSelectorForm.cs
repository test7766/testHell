using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Docs
{
    /// <summary>
    /// Диалог выбора товарных позиций для выборочной печати пакета документов
    /// </summary>
    public partial class AttorneyDebtorsForCloneSelectorForm : DialogForm
    {
        public Data.WH.AC_Debtors_For_CloneDataTable Items { get; set; }

        public AttorneyDebtorsForCloneSelectorForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.btnOK.Location = new Point(820, 8);
            this.btnCancel.Location = new Point(910, 8);

            this.Items.AcceptChanges();
            aCDebtorsForCloneBindingSource.DataSource = this.Items;
        }

        private void dgvSelector_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvSelector.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvSelector.CommitEdit(DataGridViewDataErrorContexts.Commit);

                var rowDebtor = (this.dgvSelector.Rows[this.dgvSelector.CurrentRow.Index].DataBoundItem as DataRowView).Row as Data.WH.AC_Debtors_For_CloneRow;
                var hasActiveAttorney = !rowDebtor.IsActive_Attorney_PeriodNull() && !rowDebtor.Active_Attorney_Period.Trim().Equals("-");
                var canSelect = rowDebtor.IsCan_AccessNull() ? false : rowDebtor.Can_Access;
                var isSelected = canSelect ? (rowDebtor.IsIsSelectedNull() ? false : rowDebtor.IsSelected) : false;

                // Раскраска
                foreach (DataGridViewColumn column in this.dgvSelector.Columns)
                {
                    this.dgvSelector.Rows[this.dgvSelector.CurrentRow.Index].Cells[column.Index].Style.BackColor = canSelect ? (isSelected ? Color.FromArgb(209, 255, 117) : (hasActiveAttorney ? Color.FromArgb(255, 255, 153) : SystemColors.Window)) : Color.LightGray;
                    this.dgvSelector.Rows[this.dgvSelector.CurrentRow.Index].Cells[column.Index].Style.SelectionForeColor = canSelect ? (isSelected ? Color.FromArgb(209, 255, 117) : (hasActiveAttorney ? Color.FromArgb(255, 255, 153) : SystemColors.Window)) : Color.LightGray;
                }
            }
        }

        private void PrintDocItemsSelector_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                this.Items.AcceptChanges();
            else
                this.Items.RejectChanges();
        }

        private void dgvSelector_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            var rowDebtor = (this.dgvSelector.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.WH.AC_Debtors_For_CloneRow;
            var hasActiveAttorney = !rowDebtor.IsActive_Attorney_PeriodNull() && !rowDebtor.Active_Attorney_Period.Trim().Equals("-");
            var canSelect = rowDebtor.IsCan_AccessNull() ? false : rowDebtor.Can_Access;
            var isSelected = canSelect ? (rowDebtor.IsIsSelectedNull() ? false : rowDebtor.IsSelected) : false;

            // Доступ к ячейке запрещен
            if (!canSelect && e.ColumnIndex == this.isSelectedDataGridViewCheckBoxColumn.Index)
                dgvSelector.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;

            // Раскраска
            this.dgvSelector.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = canSelect ? (isSelected ? Color.FromArgb(209, 255, 117) : (hasActiveAttorney ? Color.FromArgb(255, 255, 153) : SystemColors.Window)) : Color.LightGray;
            this.dgvSelector.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = canSelect ? (isSelected ? Color.FromArgb(209, 255, 117) : (hasActiveAttorney ? Color.FromArgb(255, 255, 153) : SystemColors.Window)) : Color.LightGray;
        }
    }
}
