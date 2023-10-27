using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Admin
{
    public partial class WizardBlankForm : Form
    {
        public bool CanResize
        {
            set
            {
                FormBorderStyle = FormBorderStyle.Sizable;
                MaximizeBox = true;
            }
        }

        public WizardBlankForm()
        {
            InitializeComponent();
        }
    }
}
