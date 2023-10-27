using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace WMSOffice.Dialogs.WH
{
    public partial class PrintingDeviceEditorForm : DialogForm
    {
        private readonly Data.WH.DD_DevicesRow _device = null;

        public PrintingDeviceEditorForm()
        {
            InitializeComponent();
        }

        public PrintingDeviceEditorForm(Data.WH.DD_DevicesRow device)
            : this()
        {
            _device = device;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            btnOK.Location = new Point(72, 8);
            btnCancel.Location = new Point(162, 8);

            this.Initialize();
        }

        private void Initialize()
        {
            var ip = _device.IpAddr;
            //if (string.IsNullOrEmpty(ip))
            //    ip = "0.0.0.0";

            tbIP.Text = ip;
        }

        private void tbIP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.DialogResult = DialogResult.OK;
        }

        private void PrintingDeviceEditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveData();
        }

        private bool SaveData()
        {
            try
            {
                IPAddress ip;
                if (!IPAddress.TryParse(tbIP.Text, out ip))
                    throw new Exception("Невірний формат IP-адреси.");

                using (var adapter = new Data.WHTableAdapters.DD_DevicesTableAdapter())
                    adapter.ChangeIP(this.UserID, _device.Device_ID, ip.ToString());

                _device.IpAddr = ip.ToString();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
