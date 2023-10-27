using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Complaints
{
    public partial class ShipReturnsToVendorEditPlanDateForm : DialogForm
    {
        public DateTime PlanDate { get; set; }

        public ShipReturnsToVendorEditPlanDateForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            dtpPlanDate.Value = this.PlanDate;

            this.btnOK.Location = new Point(67, 8);
            this.btnCancel.Location = new Point(157, 8);
        }

        private void dtpPlanDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.DialogResult = DialogResult.OK;
        }

        private void ShipReturnsToVendorEditPlanDateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveData();
        }

        private bool SaveData()
        {
            try
            {
                this.PlanDate = dtpPlanDate.Value.Date;
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
