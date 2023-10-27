using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Receive
{
    public partial class SetPalletHeightForm : DialogForm
    {
        public int PalletHeight { get; private set; }
        public long DocID { get; private set; }

        public SetPalletHeightForm()
        {
            InitializeComponent();
        }

        public SetPalletHeightForm(long docID, int defaultPalletHeight)
            : this()
        {
            this.DocID = docID;
            this.PalletHeight = defaultPalletHeight;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.btnOK.Location = new Point(50, 8);
            this.btnCancel.Location = new Point(140, 8);

            tbPalletHeight.Text = PalletHeight.ToString();
        }

        private void SetPalletHeightForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.ValidatePalletHeight();
        }

        private bool ValidatePalletHeight()
        {
            try
            {
                using (var adapter = new Data.ReceiveTableAdapters.QueriesTableAdapter())
                    adapter.CheckPalletByHeight(this.UserID, this.DocID, this.PalletHeight);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbPalletHeight.Focus();
                return false;
            }
        }

        private void tbPalletHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void tbPalletHeight_TextChanged(object sender, EventArgs e)
        {
            int height;
            int.TryParse(tbPalletHeight.Text, out height);
            this.PalletHeight = height;
        }
    }
}
