using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Inventory
{
    public partial class InventoryClosureActionsForm : DialogForm
    {
        /// <summary>
        /// Ид-р документа инвентаризации
        /// </summary>
        public long InventoryDocID { get; set; }

        /// <summary>
        /// Выбранное действие
        /// </summary>
        public Data.Inventory.InventoryClosureActionsRow SelectedAction 
        { 
            get 
            { 
                return dgvClosureActions.SelectedRows.Count == 0 
                    ? null
                    : (dgvClosureActions.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.Inventory.InventoryClosureActionsRow; 
            } 
        }

        public InventoryClosureActionsForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.btnOK.Location = new Point(340, 8);
            this.btnCancel.Location = new Point(430, 8);

            this.LoadData();

            this.dgvicAccess.DefaultCellStyle.NullValue = null;
        }

        private void LoadData()
        {
            try
            {
                this.inventoryClosureActionsBindingSource.DataSource = this.inventoryClosureActionsTableAdapter.GetData(this.UserID, this.InventoryDocID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvClosureActions_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in this.dgvClosureActions.Rows)
            {
                var boundRow = (row.DataBoundItem as DataRowView).Row as Data.Inventory.InventoryClosureActionsRow;
                if (!boundRow.IsAllowNull())
                {
                    row.Cells[dgvicAccess.Index].Value = boundRow.Allow ? Properties.Resources.Apply : Properties.Resources.cancel;
                }
            }
        }

        private void dgvClosureActions_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var dataGrid = sender as DataGridView;
            //if (dataGrid.Columns[e.ColumnIndex].DataPropertyName == this.inventory.InventoryClosureActions.DESCColumn.Caption)
            {
                var boundItem = (dataGrid.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Inventory.InventoryClosureActionsRow;
                if (!boundItem.IsAllowNull())
                {
                    dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = boundItem.Allow ? Color.Black : Color.Gray;
                    dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionBackColor = boundItem.Allow ? SystemColors.Highlight : Color.Gray;
                }
            }
        }

        private void dgvClosureActions_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            this.DialogResult = DialogResult.OK;
        }

        private void dgvClosureActions_SelectionChanged(object sender, EventArgs e)
        {
            this.btnOK.Enabled = this.SelectedAction != null && !this.SelectedAction.IsAllowNull() && this.SelectedAction.Allow;
        }
    }
}
