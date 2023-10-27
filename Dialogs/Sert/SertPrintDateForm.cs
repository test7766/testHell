using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Sert
{
    public partial class SertPrintDateForm : Form
    {
        public SertPrintDateForm()
        {
            InitializeComponent();
        }

        public DateTime SelectedDate { get { return dateTimePicker1.Value.Date; } }

        private void SertPrintDateForm_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Today;
        }
    }
}
