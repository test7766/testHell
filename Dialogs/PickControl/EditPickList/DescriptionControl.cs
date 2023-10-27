using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.PickControl.EditPickList
{
    public partial class DescriptionControl : BaseControl
    {
        public DescriptionControl()
        {
            InitializeComponent();
        }

        public string Attention
        {
            get { return lblAttention.Text; }
            set { lblAttention.Text = value; }
        }

        public string Action
        {
            get { return lblAction.Text; }
            set { lblAction.Text = value; }
        }

        public string Count
        {
            get { return lblCount.Text; }
            set { lblCount.Text = value; }
        }

        public string Description
        {
            get { return lblDescription.Text; }
            set { lblDescription.Text = value; }
        }
    }
}
