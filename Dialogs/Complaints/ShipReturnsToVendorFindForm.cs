using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Complaints
{
    public partial class ShipReturnsToVendorFindForm : DialogForm
    {
        public long DocNumberJDE { get; private set; }

        public ShipReturnsToVendorFindForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(67, 8);
            this.btnCancel.Location = new Point(157, 8);
        }

        private void tbDocNumberJDE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.DialogResult = DialogResult.OK;
        }

        private void ShipReturnsToVendorFindForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveData();
        }

        private bool SaveData()
        {
            try
            {
                long docNumberJDE;
                if (!long.TryParse(tbDocNumberJDE.Text, out docNumberJDE))
                    throw new Exception("№ возвр. накладной должен быть числом.");

                this.DocNumberJDE = docNumberJDE;
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
