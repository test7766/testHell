using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.D3
{
    public partial class ViewSettingsForm : DialogForm
    {
        public ViewSettingsForm()
        {
            InitializeComponent();
        }

        public int MaxBitmapSize
        {
            get { return (int)maxBitmapSize.Value; }
            set { maxBitmapSize.Value = value; }
        }
    }
}
