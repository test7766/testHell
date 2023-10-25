using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Quality
{
    public partial class RegistrationLifetimeEditorForm : DialogForm
    {
        /// <summary>
        /// Срок действия РС
        /// </summary>
        public DateTime LifetimeDate
        {
            get { return dtLifetimeDate.Value; }
            set { dtLifetimeDate.Value = value; }
        }

        public RegistrationLifetimeEditorForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            btnOK.Location = new Point(50, 8);
            btnCancel.Location = new Point(140, 8);
        }
    }
}
