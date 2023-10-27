using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Delivery
{
    public partial class ReceiptDebtorsReturnedTareSetNotVisitedForm : DialogForm
    {
        public int? ReceiptDocID { get; set; }

        public int? TareDocID { get; set; }

        public ReceiptDebtorsReturnedTareSetNotVisitedForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(173, 8);
            this.btnCancel.Location = new Point(263, 8);

            this.Initialize();
        }

        private void Initialize()
        {
            this.InitReasons();
            this.InitReasonsForDeliveryID();
        }

        private void InitReasons()
        {
            try
            {
                this.checkTareInvoiceReturnNotVisitedReasonsTableAdapter.Fill(delivery.CheckTareInvoiceReturnNotVisitedReasons);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitReasonsForDeliveryID()
        {
            try
            {
                using (var adapter = new Data.DeliveryTableAdapters.CheckTareInvoiceReturnNotVisitedInitReasonsTableAdapter())
                    adapter.Fill(delivery.CheckTareInvoiceReturnNotVisitedInitReasons, this.ReceiptDocID, this.TareDocID);

                if (delivery.CheckTareInvoiceReturnNotVisitedInitReasons.Count > 0)
                {
                    var info = delivery.CheckTareInvoiceReturnNotVisitedInitReasons[0];
                    tbDeliveryName.Text = info.Client;

                    if (!info.IsReason_IdNull())
                        cmbReasons.SelectedValue = info.Reason_Id;

                    if (!info.IsReason_DSCNull())
                        tbReasonNote.Text = info.Reason_DSC;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbReasons_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbReasons.SelectedValue == null)
                return;

            var reason = (cmbReasons.SelectedItem as DataRowView).Row as Data.Delivery.CheckTareInvoiceReturnNotVisitedReasonsRow;
            var needTypeReasonNote = reason.IsNeed_DSCNull() ? false : reason.Need_DSC;

            tbReasonNote.Enabled = needTypeReasonNote;
            
            if (!needTypeReasonNote)
                tbReasonNote.Clear();
        }

        private void ReceiptDebtorsReturnedTareSetNotVisitedForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveReason();
        }

        private bool SaveReason()
        {
            try
            {
                var reasonID = Convert.ToInt32(cmbReasons.SelectedValue);

                if (tbReasonNote.Enabled && string.IsNullOrEmpty(tbReasonNote.Text))
                    throw new Exception("Необходимо указать описание причины.");

                var reasonNote = tbReasonNote.Enabled ? tbReasonNote.Text : (string)null;

                this.checkTareInvoiceReturnNotVisitedReasonsTableAdapter.SetNotVisitedReason(this.ReceiptDocID, this.TareDocID, reasonID, reasonNote);

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
