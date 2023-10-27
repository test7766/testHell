using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Admin
{
    public partial class CloseApplicationNotificationForm : Form
    {
        public string MessageText { set { lblText.Text = value; } }

        public CloseApplicationNotificationForm()
        {
            InitializeComponent();
        }
    }
}
