using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Inventory
{
    public partial class InventoryEmptyCountSheetsSetQuantityForm : DialogForm
    {
        public int EmptyCountSheetsQuantity { get { return Convert.ToInt32(nudEmptyCountSheetsQuantity.Value); } }

        public InventoryEmptyCountSheetsSetQuantityForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            btnOK.Location = new Point(117, 8);
            btnCancel.Location = new Point(207, 8);
        }
    }
}
