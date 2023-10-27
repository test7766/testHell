using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Quality
{
    public partial class GTDEditorForm : DialogForm
    {
        /// <summary>
        /// Номер ГТД
        /// </summary>
        public string NumberGTD
        {
            get { return tbNumberGTD.Text; }
            set { tbNumberGTD.Text = value; }
        }

        /// <summary>
        /// Дата ГТД
        /// </summary>
        public DateTime DateGTD
        {
            get { return dtpDateGTD.Value; }
            set { dtpDateGTD.Value = value; }
        }

        public GTDEditorForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            btnOK.Location = new Point(50, 8);
            btnCancel.Location = new Point(140, 8);

            Initialize();
        }

        private void Initialize()
        {
            dtpDateGTD.Focus();
        }
    }
}
