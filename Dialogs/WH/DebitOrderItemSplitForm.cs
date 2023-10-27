using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.WH
{
    public partial class DebitOrderItemSplitForm : DialogForm
    {
        private readonly decimal _fullQuantity;

        public double Quantity { get { return Convert.ToDouble(nudQuantity.Value); } }
        public double Remains { get { return Convert.ToDouble(nudRemains.Value); } }

        public DebitOrderItemSplitForm(decimal quantity)
        {
            InitializeComponent();
            _fullQuantity = quantity;
        }

        private void DebitOrderLineSplitForm_Load(object sender, EventArgs e)
        {
            nudQuantity.Maximum = _fullQuantity - 1;
            nudRemains.Maximum = _fullQuantity - 1;

            nudQuantity.Value = _fullQuantity - 1;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(87, 8);
            this.btnCancel.Location = new Point(177, 8);
        }

        private void nudQuantity_ValueChanged(object sender, EventArgs e)
        {
            nudRemains.Value = _fullQuantity - nudQuantity.Value;
        }
    }
}
