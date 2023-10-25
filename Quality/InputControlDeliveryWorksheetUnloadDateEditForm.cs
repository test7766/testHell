using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Quality
{
    public partial class InputControlDeliveryWorksheetUnloadDateEditForm  : DialogForm
    {
        private readonly ShipmentUnloadDatePackage udPackage = null;

        private readonly bool _readOnlyMode = false; 

        public InputControlDeliveryWorksheetUnloadDateEditForm ()
        {
            InitializeComponent();
        }

        public InputControlDeliveryWorksheetUnloadDateEditForm(ShipmentUnloadDatePackage ud_package, bool readOnlyMode)
            :this()
        {
            udPackage = ud_package;
            _readOnlyMode = readOnlyMode;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            btnOK.Location = new Point(107, 8);
            btnCancel.Location = new Point(197, 8);

            dtShipmentUnloadingDate.Value = udPackage.UnloadDate ?? DateTime.Now;
            cbShipmentNotYetUnloaded.Checked = udPackage.NotYetUnloaded;

            if (_readOnlyMode)
            {
                this.btnOK.Visible = false;
                this.btnCancel.Text = "Закрыть";

                dtShipmentUnloadingDate.Enabled = false;
                cbShipmentNotYetUnloaded.Enabled = false;
            }
        }

        private void cbShipmentNotYetUnloaded_CheckedChanged(object sender, EventArgs e)
        {
            dtShipmentUnloadingDate.Enabled = !cbShipmentNotYetUnloaded.Checked;
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
                udPackage.UnloadDate = dtShipmentUnloadingDate.Value;
                udPackage.NotYetUnloaded = cbShipmentNotYetUnloaded.Checked;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }

    public class ShipmentUnloadDatePackage
    {
        public DateTime? UnloadDate { get; set; }
        public bool NotYetUnloaded { get; set; }
    }
}
