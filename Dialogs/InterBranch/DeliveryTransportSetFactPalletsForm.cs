using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.InterBranch
{
    public partial class DeliveryTransportSetFactPalletsForm : DialogForm
    {
        public new long UserID { get; set; }

        public long? CarID { get; set; }
        public int? FactPallets { get; set; }

        public DeliveryTransportSetFactPalletsForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            this.Text = string.Format("{0} [{1}]", this.Text, this.CarID ?? -1);

            if (this.FactPallets.HasValue)
                nudFactPallets.Value = Convert.ToDecimal(this.FactPallets.Value);

            nudFactPallets.Select(0, (this.FactPallets ?? 0).ToString().Length);

            this.btnOK.Location = new Point(67, 8);
            this.btnCancel.Location = new Point(157, 8);

            base.OnShown(e);
        }

        private void nudFactPallets_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.DialogResult = DialogResult.OK;
        }

        private void DeliveryTransportSetFactPalletsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveData();
        }

        private bool SaveData()
        {
            try
            {
                this.FactPallets = Convert.ToInt32(nudFactPallets.Value);

                using (var adapter = new Data.InterbranchTableAdapters.TSP_Cars_On_Ramps_By_DateTableAdapter())
                    adapter.SetFactPalletsInCar(this.UserID, this.CarID, this.FactPallets);

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
