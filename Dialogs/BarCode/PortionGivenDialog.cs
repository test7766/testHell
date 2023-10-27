using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.BarCode
{
    public partial class PortionGivenDialog : Form
    {
        public PortionGivenDialog()
        {
            InitializeComponent();
        }

        public string UserCode { get; set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UserCode = string.Empty;

            Binding binding = new Binding("Text", this, "UserCode") { DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged };
            textBoxScaner.DataBindings.Add(binding);
        }
    }
}
