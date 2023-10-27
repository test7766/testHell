using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Quality
{
    public partial class ManufacturerPlantEditorForm : DialogForm
    {
        /// <summary>
        /// Завод-производитель
        /// </summary>
        public string ManufacturerPlant
        {
            get { return tbManufacturerPlant.Text; }
            set { tbManufacturerPlant.Text = value; }
        }

        public ManufacturerPlantEditorForm()
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
