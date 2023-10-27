using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Delivery
{
    public partial class DeliveryLetterOfAttorneyInitNumberForm : DialogForm
    {
        public int InitNumber { get { return Convert.ToInt32(tbInitNumber.Text); } }

        public DeliveryLetterOfAttorneyInitNumberForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.btnOK.Location = new Point(117, 8);
            this.btnCancel.Location = new Point(207, 8);
        }

        private void tbInitNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.DialogResult = DialogResult.OK;
        }

        private void AllowOnlyNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void DeliveryLetterOfAttorneyInitNumberForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !ValidateNumber();
        }

        private bool ValidateNumber()
        {
            try
            {
                if (string.IsNullOrEmpty(tbInitNumber.Text))
                    throw new Exception("Номер доверенности должен быть числом.");

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbInitNumber.Focus();
                return false;
            }
        }
    }
}
