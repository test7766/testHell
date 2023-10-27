using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.WH
{
    public partial class ApproveOrderShipmentForm : DialogForm
    {
        private readonly Data.WH.PurchaseOrdersForDebitRow order = null;

        public ApproveOrderShipmentForm()
        {
            InitializeComponent();
        }

        public ApproveOrderShipmentForm(Data.WH.PurchaseOrdersForDebitRow pOrder)
            : this()
        {
            order = pOrder;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            var shipmentID = order.IsShipmentIDNull() ? -1 : order.ShipmentID;
            this.Text = string.Format("{0} № {1}", this.Text, shipmentID);

            this.btnOK.Location = new Point(987, 8);
            this.btnCancel.Location = new Point(1077, 8);

            this.Initialize();
        }

        public void Initialize()
        {
            this.LoadHeader();
            this.LoadDetails();
        }

        private void LoadHeader()
        {
            try
            {
                var shipmentID = order.IsShipmentIDNull() ? -1 : order.ShipmentID;
                using (var adapter = new Data.WHTableAdapters.PurchaseOrderShipmentHeaderTableAdapter())
                    adapter.Fill(wH.PurchaseOrderShipmentHeader, this.UserID, shipmentID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDetails()
        {
            try
            {
                var shipmentID = order.IsShipmentIDNull() ? -1 : order.ShipmentID;
                var orderNumber = order.OrderNumber;
                var orderType = order.OrderType;
                using (var adapter = new Data.WHTableAdapters.PurchaseOrderShipmentDetailsTableAdapter())
                    adapter.Fill(wH.PurchaseOrderShipmentDetails, this.UserID, shipmentID);

                foreach (DataGridViewRow row in dgvOrders.Rows)
                {
                    var detail = (row.DataBoundItem as DataRowView).Row as Data.WH.PurchaseOrderShipmentDetailsRow;
                    if (detail.OrderNumber.Equals(orderNumber) && detail.OrderType.Equals(orderType, StringComparison.OrdinalIgnoreCase))
                    {
                        row.Selected = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBoxLabel_Click(object sender, EventArgs e)
        {
            var label = sender as Label;
            var groupBox = label.Parent as GroupBox;

            foreach (var control in groupBox.Controls)
                if (control is CheckBox)
                {
                    var checkBox = control as CheckBox;

                    if (label.Tag.Equals(checkBox.Tag))
                    {
                        checkBox.Checked = !checkBox.Checked;
                        break;
                    }
                }

        }

        private void ApproveOrderShipmentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.ApproveOrderShipment();
        }

        private bool ApproveOrderShipment()
        {
            try
            {
                var header = wH.PurchaseOrderShipmentHeader[0];

                var sQty = header.IsStandartPalletsNull() ? (int?)null : header.StandartPallets;
                var eQty = header.IsEuroPalletsNull() ? (int?)null : header.EuroPallets;
                var pQty = header.IsPlasticPalletsNull() ? (int?)null : header.PlasticPallets;

                var hasWaybill = header.IsHasWaybillNull() ? (bool?)null : header.HasWaybill;
                var hasLicense = header.IsHasLicenseNull() ? (bool?)null : header.HasLicense;
                var hasCertificate = header.IsHasCertificateNull() ? (bool?)null : header.HasCertificate;
                var hasConclusion = header.IsHasConclusionNull() ? (bool?)null : header.HasConclusion;

                var shipmentID = order.IsShipmentIDNull() ? -1 : order.ShipmentID;
                using (var adapter = new Data.WHTableAdapters.PurchaseOrderShipmentHeaderTableAdapter())
                    adapter.UpdateShipment(this.UserID, shipmentID, sQty, eQty, pQty, hasWaybill, hasLicense, hasCertificate, hasConclusion);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
