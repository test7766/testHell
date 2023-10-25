using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs;

namespace WMSOffice.Window.QualityLotsWindow
{
    public partial class GroupEditingOfInformation : DialogForm
    {
        public GroupEditingOfInformation()
        {
            InitializeComponent();
            var today = DateTime.Today;
            dtpExpDate.Value = DateTime.Today;
        }
    }
}
