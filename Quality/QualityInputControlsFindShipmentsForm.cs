using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls;

namespace WMSOffice.Dialogs.Quality
{
    public partial class QualityInputControlsFindShipmentsForm : DialogForm
    {
        public DateTime? PeriodFrom { get; set; }
        public DateTime? PeriodTo { get; set; }
        public long? VendorID { get; set; }
        public long? ShipmentID { get; set; }
        public int? StatusFrom { get; set; }
        public int? StatusTo { get; set; }

        public string VendorName { get; private set; }
        public string StatusFromName { get; private set; }
        public string StatusToName { get; private set; }

        public QualityInputControlsFindShipmentsForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(317, 8);
            this.btnCancel.Location = new Point(407, 8);

            this.Initialize();
        }

        private void Initialize()
        {
            stbVendor.ValueReferenceQuery = "[dbo].[pr_AP_Get_Vendors_List]";
            stbVendor.UserID = this.UserID;
            stbVendor.OnVerifyValue += new VerifyValueHandler(stb_OnVerifyValue);

            stbStatusFrom.ValueReferenceQuery = "[dbo].[pr_AP_Get_Statuses_List]";
            stbStatusFrom.UserID = this.UserID;
            stbStatusFrom.OnVerifyValue += new VerifyValueHandler(stb_OnVerifyValue);

            stbStatusFrom.SetFirstValueByDefault();

            stbStatusTo.ValueReferenceQuery = "[dbo].[pr_AP_Get_Statuses_List]";
            stbStatusTo.UserID = this.UserID;
            stbStatusTo.OnVerifyValue += new VerifyValueHandler(stb_OnVerifyValue);

            stbStatusTo.SetLastValueByDefault();
        }

        void stb_OnVerifyValue(object sender, VerifyValueArgs e)
        {
            var control = sender as SearchTextBox;
            TextBox lblDescription = null;

            if (control == stbVendor)
                lblDescription = tbVendor;
            else if (control == stbStatusFrom)
                lblDescription = tbStatusFrom;
            else if (control == stbStatusTo)
                lblDescription = tbStatusTo;

            if (lblDescription != null)
            {
                lblDescription.Text = e.Success ? e.Description : "ЗНАЧЕНИЕ НЕ НАЙДЕНО!";
                lblDescription.ForeColor = e.Success ? SystemColors.ControlText : Color.Red;

                if (e.Success)
                    control.Value = e.Value;
                //else
                //    control.Value = string.Empty;
            }
        }

        private void dtpPeriodFrom_ValueChanged(object sender, EventArgs e)
        {
            dtpPeriodTo.Value = dtpPeriodFrom.Value;
        }

        private void QualityInputControlsFindShipmentsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.ApplyParameters();
        }

        private bool ApplyParameters()
        {

            try
            {
                if (!dtpPeriodFrom.Checked && !dtpPeriodTo.Checked)
                    throw new Exception("Период поиска должен быть указан.");

                if (dtpPeriodFrom.Checked && dtpPeriodTo.Checked)
                {
                    if (dtpPeriodFrom.Value.Date > dtpPeriodTo.Value.Date)
                        throw new Exception("Период С не должен превышать период ПО.");
                }

                long vendorID = -1;
                if (!string.IsNullOrEmpty(stbVendor.Value))
                {
                    if (!long.TryParse(stbVendor.Value, out vendorID))
                        throw new Exception("Код поставщика должен быть числом.");

                    this.VendorName = tbVendor.Text;
                }

                long shipmentID = -1;
                if (!string.IsNullOrEmpty(tbShipmentID.Text))
                {
                    if (!long.TryParse(tbShipmentID.Text, out shipmentID))
                        throw new Exception("№ поставки должен быть числом.");
                }

                int statusFrom = -1;
                if (!string.IsNullOrEmpty(stbStatusFrom.Value))
                {
                    if (!int.TryParse(stbStatusFrom.Value, out statusFrom))
                        throw new Exception("Код статуса С должен быть числом.");

                    this.StatusFromName = tbStatusFrom.Text;
                }

                int statusTo = -1;
                if (!string.IsNullOrEmpty(stbStatusTo.Value))
                {
                    if (!int.TryParse(stbStatusTo.Value, out statusTo))
                        throw new Exception("Код статуса ПО должен быть числом.");

                    this.StatusToName = tbStatusTo.Text;
                }

                this.PeriodFrom = dtpPeriodFrom.Checked ? dtpPeriodFrom.Value.Date : (DateTime?)null;
                this.PeriodTo = dtpPeriodTo.Checked ? dtpPeriodTo.Value.Date : (DateTime?)null;

                this.VendorID = vendorID == -1 ? (long?)null : vendorID;
                this.ShipmentID = shipmentID == -1 ? (long?)null : shipmentID;

                this.StatusFrom = statusFrom == -1 ? (int?)null : statusFrom;
                this.StatusTo = statusTo== -1 ? (int?)null : statusTo;

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
