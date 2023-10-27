using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Classes;

namespace WMSOffice.Dialogs.PickControl
{
    public partial class DebtorsReturnedTareInventoryMoveDublicateTareForm : DialogForm
    {
        public long DocID { get; set; }

        public DebtorsReturnedTareInventoryMoveDublicateTareForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(617, 8);
            this.btnCancel.Location = new Point(707, 8);

            this.btnOK.Visible = false;
            this.btnCancel.Text = "Закрыть";

            this.Text = string.Format("{0} № {1}", this.Text, this.DocID);

            sbMoveDublicateTare.Enabled = false;
            sbExportToExcel.Enabled = false;

            this.RefreshData();
        }

        private void sbRefreshData_Click(object sender, EventArgs e)
        {
            this.RefreshData();
        }

        private void RefreshData()
        {
            try
            {
                rET_Tare_Inventory_Inv_DBL_Tasks_InfoTableAdapter.Fill(pickControl.RET_Tare_Inventory_Inv_DBL_Tasks_Info, this.DocID, this.UserID);

                // Снимаем выделение с первой строки
                if (dgvDublicateTare.Rows.Count > 0)
                    dgvDublicateTare.Rows[0].Selected = false;

                this.SetOperationAccess();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetOperationAccess()
        {
            var hasRows = dgvDublicateTare.Rows.Count > 0;

            sbMoveDublicateTare.Enabled = !hasRows;
            sbExportToExcel.Enabled = hasRows;
        }

        private void sbMoveDublicateTare_Click(object sender, EventArgs e)
        {
            this.MoveDublicateTare();
        }

        private void MoveDublicateTare()
        {
            try
            {
                using (var adapter = new Data.PickControlTableAdapters.RET_Tare_Inventory_Inv_DocsTableAdapter())
                    adapter.MoveInventoryDublicateTare(this.DocID, this.UserID);

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sbExportToExcel_Click(object sender, EventArgs e)
        {
            this.ExportToExcel();
        }

        private void ExportToExcel()
        {
            try
            {
                var sError = ExportHelper.ExportDataGridViewToExcel(dgvDublicateTare, "Экспорт информации по дублям ОТ", string.Format("Дубли ОТ по инвентаризации № {0}", this.DocID), true);

                if (!string.IsNullOrEmpty(sError))
                    throw new Exception(sError);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
