using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.PickControl.EditPickList
{
    public partial class CurrentRowControl : BaseControl
    {
        public CurrentRowControl()
        {
            InitializeComponent();
        }

        public new string Location
        {
            get { return tbLocation.Text; }
            set { tbLocation.Text = value; }
        }

        public string Item
        {
            get { return tbItem.Text; }
            set { tbItem.Text = value; }
        }

        public string Quantity
        {
            get { return tbQuantity.Text; }
            set { tbQuantity.Text = value; }
        }

        public string Series
        {
            get { return tbSeries.Text; }
            set { tbSeries.Text = value; }
        }

    }
}
