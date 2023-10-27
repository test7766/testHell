using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.WH
{
    public partial class ChoiseWarehouseForm : DialogForm
    {
        public Data.WH.OperationWarehousesRow SelectedItem
        {
            get
            {
                if (dgvWarehouses.SelectedRows.Count == 0)
                    return null;
                else
                    return (Data.WH.OperationWarehousesRow)((DataRowView)dgvWarehouses.SelectedRows[0].DataBoundItem).Row;
            }
        }

        public ChoiseWarehouseForm()
        {
            InitializeComponent();
            this.ApplyOperation(DialogResult.None);
        }

        private void ChoiseWarehouseForm_Load(object sender, EventArgs e)
        {
            this.LoadWarehouses();
        }

        /// <summary>
        /// Заполнение справочника складов
        /// </summary>
        private void LoadWarehouses()
        {
            try
            {
                this.operationWarehousesBindingSource.DataSource = null;
                this.operationWarehousesBindingSource.Filter = null;
                this.operationWarehousesBindingSource.DataSource = WHCache.Warehouses;
                //this.operationWarehousesBindingSource.DataSource = this.operationWarehousesTableAdapter.GetData(this.UserID);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString(), "Ошибка загрузки справочника складов", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbWarehouseName_TextChanged(object sender, EventArgs e)
        {
            this.operationWarehousesBindingSource.Filter = String.Format("{0} LIKE '%{1}%'", this.wH.OperationWarehouses.WarehouseColumn.Caption, tbWarehouseName.Text.Trim());
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(192, 8);
            this.btnCancel.Location = new Point(282, 8);

            tbWarehouseName.Focus();
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

        private void dgvWarehouses_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
                this.ApplyOperation(DialogResult.OK);
        }

        private void ChoiseWarehouseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.ValidateOperation();
        }

        private bool ValidateOperation()
        {
            if (this.SelectedItem == null)
            {
                MessageBox.Show("Не выбран склад из списка!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }
    }
}
