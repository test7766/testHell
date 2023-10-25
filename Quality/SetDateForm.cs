using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Quality
{
    public partial class SetDateForm : DialogForm
    {
        public SetDateForm()
        {
            InitializeComponent();
        }

        public string DateTypeString
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

        public DateTime SelectedDate
        {
            get { return dateFrom.Value; }
            set { dateFrom.Value = value; }
        }
    }
}
