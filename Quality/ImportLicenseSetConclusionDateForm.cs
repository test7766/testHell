using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Quality
{
    public partial class ImportLicenseSetConclusionDateForm : DialogForm
    {
        public bool AddToLicense { get; private set; }

        /// <summary>
        /// Дата заключения
        /// </summary>
        public DateTime ConclusionDate
        {
            get { return dtConclusionDate.Value; }
            set { dtConclusionDate.Value = value; }
        }

        public ImportLicenseSetConclusionDateForm()
        {
            InitializeComponent();
        }

        public ImportLicenseSetConclusionDateForm(bool addToLicense)
            : this()
        {
            this.AddToLicense = addToLicense;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Text = string.Format("{0} {1}", this.Text, this.AddToLicense ? "добавления" : "исключения");

            btnOK.Location = new Point(50, 8);
            btnCancel.Location = new Point(140, 8);
        }
    }
}
