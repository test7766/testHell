using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Docs
{
    public partial class ArchiveInvoicesRegisterPrintBoxEticForm : DialogForm
    {
        public int Count
        {
            get
            {
                return Convert.ToInt32(nudCount.Value);
            }
            set
            {
                nudCount.Value = Convert.ToDecimal(value);
            }
        }

        public ArchiveInvoicesRegisterPrintBoxEticForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(115, 8);
            this.btnCancel.Location = new Point(205, 8);

            this.Initialize();
        }

        private void Initialize()
        {
            nudCount.Focus();
        }

        private void nudCount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
