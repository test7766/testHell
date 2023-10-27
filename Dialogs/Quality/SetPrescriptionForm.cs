using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Quality
{
    public partial class SetPrescriptionForm : DialogForm
    {
        public SetPrescriptionForm()
        {
            InitializeComponent();
        }

        public string Number
        {
            get
            {
                return tbNumber.Text;
            }
            set
            {
                tbNumber.Text = value;
            }
        }

        public DateTime SelectedDate
        {
            get { return dateFrom.Value; }
            set { dateFrom.Value = value; }
        }
    }
}
