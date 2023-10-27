using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Quality
{
    public partial class ManufacturerPlantCountryEditorForm : DialogForm
    {
        /// <summary>
        /// Страна завода-производителя
        /// </summary>
        public string ManufacturerCountry
        {
            get { return tbManufacturerCountry.Text; }
            set { tbManufacturerCountry.Text = value; }
        }

        public ManufacturerPlantCountryEditorForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            btnOK.Location = new Point(303, 8);
            btnCancel.Location = new Point(393, 8);
        }
    }
}
