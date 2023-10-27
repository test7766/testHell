using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Quality
{
    public partial class InputControlDeliveryWorksheetCarNumberEditForm  : DialogForm
    {
        private readonly ShipmentCarNumberPackage cnPackage = null;

        private readonly bool _readOnlyMode = false; 

        public InputControlDeliveryWorksheetCarNumberEditForm ()
        {
            InitializeComponent();
        }

        public InputControlDeliveryWorksheetCarNumberEditForm(ShipmentCarNumberPackage cn_package, bool readOnlyMode)
            :this()
        {
            cnPackage = cn_package;
            _readOnlyMode = readOnlyMode;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            btnOK.Location = new Point(107, 8);
            btnCancel.Location = new Point(197, 8);

            tbCarNumber.Text = cnPackage.CarNumber;
            tbTrailerNumber.Text = cnPackage.TrailerNumber;

            if (_readOnlyMode)
            {
                this.btnOK.Visible = false;
                this.btnCancel.Text = "Закрыть";

                tbCarNumber.Enabled = false;
                tbTrailerNumber.Enabled = false;
            }
        }

        private void InputControlDeliveryWorksheetUnloadDateEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveData();
            }

        private bool SaveData()
        {
            try
            {
                cnPackage.CarNumber = tbCarNumber.Text;
                cnPackage.TrailerNumber = tbTrailerNumber.Text;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }

    public class ShipmentCarNumberPackage
    {
        public string CarNumber { get; set; }
        public string TrailerNumber { get; set; }
    }
}
