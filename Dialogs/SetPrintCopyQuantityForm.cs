using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs
{
    public partial class SetPrintCopyQuantityForm : DialogForm
    {
        public int Quantity { get { return Convert.ToInt32(nudQuantity.Value); } }

        public SetPrintCopyQuantityForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            btnOK.Location = new Point(25, 8);
            btnCancel.Location = new Point(115, 8);
        }
    }
}
