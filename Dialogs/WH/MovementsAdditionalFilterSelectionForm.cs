using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.WH
{
    public partial class MovementsAdditionalFilterSelectionForm : DialogForm
    {
        public string Item { get; set; }
        public DateTime PeriodFrom { get; set; }
        public DateTime PeriodTo { get; set; }
        public string Warehouse { get; set; }
        public string Location_ { get; set; }
        public string Batch { get; set; }

        public string Period { get { return string.Format("{0} - {1}", this.PeriodFrom.ToShortDateString(), this.PeriodTo.ToShortDateString()); } }

        public MovementsAdditionalFilterSelectionForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Initialize();

            this.btnOK.Location = new Point(172, 8);
            this.btnCancel.Location = new Point(262, 8);
        }

        private void Initialize()
        {
            cbItem.Enabled = false;
            cbItem.Checked = true;
            tbItem.Text = this.Item;
            tbItem.BackColor = SystemColors.Info;

            cbPeriod.Enabled = false;
            cbPeriod.Checked = true;
            tbPeriod.Text = string.Format("{0} - {1}", this.PeriodFrom.ToShortDateString(), this.PeriodTo.ToShortDateString());
            tbPeriod.BackColor = SystemColors.Info;

            cbWarehouse.Enabled = false; //!string.IsNullOrEmpty(this.Warehouse);
            cbWarehouse.Checked = true; //!string.IsNullOrEmpty(this.Warehouse);
            tbWarehouse.Text = this.Warehouse;
            tbWarehouse.BackColor = !string.IsNullOrEmpty(this.Warehouse) ? SystemColors.Info : SystemColors.Window;

            cbLocation.Enabled = !string.IsNullOrEmpty(this.Location_);
            cbLocation.Checked = !string.IsNullOrEmpty(this.Location_);
            tbLocation.Text = this.Location_;
            tbLocation.BackColor = !string.IsNullOrEmpty(this.Location_) ? SystemColors.Info : SystemColors.Window;

            cbBatch.Enabled = !string.IsNullOrEmpty(this.Batch);
            cbBatch.Checked = !string.IsNullOrEmpty(this.Batch);
            tbBatch.Text = this.Batch;
            tbBatch.BackColor = !string.IsNullOrEmpty(this.Batch) ? SystemColors.Info : SystemColors.Window;
        }

        private void lblItem_Click(object sender, EventArgs e)
        {
            if (cbItem.Enabled)
                cbItem.Checked = !cbItem.Checked;
        }

        private void lblPeriod_Click(object sender, EventArgs e)
        {
            if (cbPeriod.Enabled)
                cbPeriod.Checked = !cbPeriod.Checked;
        }

        private void lblWarehouse_Click(object sender, EventArgs e)
        {
            if (cbWarehouse.Enabled)
                cbWarehouse.Checked = !cbWarehouse.Checked;
        }

        private void lblLocation_Click(object sender, EventArgs e)
        {
            if (cbLocation.Enabled)
                cbLocation.Checked = !cbLocation.Checked;
        }

        private void lblBatch_Click(object sender, EventArgs e)
        {
            if (cbBatch.Enabled)
                cbBatch.Checked = !cbBatch.Checked;
        }

        private void cbItem_CheckedChanged(object sender, EventArgs e)
        {
            tbItem.Text = cbItem.Checked ? this.Item : string.Empty;
            tbItem.BackColor = cbItem.Checked ? SystemColors.Info : SystemColors.Window;
        }

        private void cbPeriod_CheckedChanged(object sender, EventArgs e)
        {
            tbPeriod.Text = cbPeriod.Checked ? this.Period : string.Empty;
            tbPeriod.BackColor = cbPeriod.Checked ? SystemColors.Info : SystemColors.Window;
        }

        private void cbWarehouse_CheckedChanged(object sender, EventArgs e)
        {
            tbWarehouse.Text = cbWarehouse.Checked ? this.Warehouse : string.Empty;
            tbWarehouse.BackColor = cbWarehouse.Checked ? SystemColors.Info : SystemColors.Window;
        }

        private void cbLocation_CheckedChanged(object sender, EventArgs e)
        {
            tbLocation.Text = cbLocation.Checked ? this.Location_ : string.Empty;
            tbLocation.BackColor = cbLocation.Checked ? SystemColors.Info : SystemColors.Window;
        }

        private void cbBatch_CheckedChanged(object sender, EventArgs e)
        {
            tbBatch.Text = cbBatch.Checked ? this.Batch : string.Empty;
            tbBatch.BackColor = cbBatch.Checked ? SystemColors.Info : SystemColors.Window;
        }

        private void MovementsAdditionalFilterSelectionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.PrepareFilter();
        }

        private bool PrepareFilter()
        {
            try
            {
                if (!cbWarehouse.Checked)
                    this.Warehouse = (string)null;

                if (!cbLocation.Checked)
                    this.Location_ = (string)null;

                if (!cbBatch.Checked)
                    this.Batch = (string)null;

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
