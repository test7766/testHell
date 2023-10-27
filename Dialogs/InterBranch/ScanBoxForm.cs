using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Containers
{
    public partial class ScanBoxForm : DialogForm
    {
        public ScanBoxForm()
        {
            InitializeComponent();
            ButtonOKEnabled = false;
        }

        public string Barcode
        {
            get { return tbScanner.Text; }
            set { tbScanner.Text = value; }
        }

        private void tbScanner_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbScanner.Text))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void ScanContainerForm_Shown(object sender, EventArgs e)
        {
            tbScanner.SelectAll();
            tbScanner.Focus();
        }
    }
}
