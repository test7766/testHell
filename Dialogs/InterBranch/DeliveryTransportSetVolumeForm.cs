using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.InterBranch
{
    public partial class DeliveryTransportSetVolumeForm : DialogForm
    {
        public new long UserID { get; set; }

        public double? Volume { get; set; }
        public double? MinVolume { get; set; }
        public double? MaxVolume { get; set; }

        public DeliveryTransportSetVolumeForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            if (this.MinVolume.HasValue)
                nudVolume.Minimum = Convert.ToDecimal(this.MinVolume.Value);

            if (this.MaxVolume.HasValue)
                nudVolume.Maximum = Convert.ToDecimal(this.MaxVolume.Value);

            if (this.Volume.HasValue)
                nudVolume.Value = Convert.ToDecimal(this.Volume.Value);

            nudVolume.Select(0, (this.Volume ?? 0).ToString("f4").Length);

            this.btnOK.Location = new Point(67, 8);
            this.btnCancel.Location = new Point(157, 8);

            base.OnShown(e);
        }

        private void nudFactPallets_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.DialogResult = DialogResult.OK;
        }

        private void DeliveryTransportSetVolumeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveData();
        }

        private bool SaveData()
        {
            try
            {
                this.Volume = Convert.ToDouble(nudVolume.Value);

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
