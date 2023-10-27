using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Delivery
{
    public partial class ReceiptDebtorsReturnedTareTransitCheckInvoiceForm : DialogForm
    {
        public string RouteListBarcode { get; set; }
        
        public int ReceiptDocID { get; private set; }

        public bool NeedScanTare { get; private set; }

        public ReceiptDebtorsReturnedTareTransitCheckInvoiceForm()
        {
            InitializeComponent();
        }

        public ReceiptDebtorsReturnedTareTransitCheckInvoiceForm(int receiptDocID)
            : this()
        {
            ReceiptDocID = receiptDocID;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            btnOK.Location = new Point(620, 8);
            btnCancel.Location = new Point(710, 8);

            btnOK.Enabled = false;

            this.Text = string.Format("{0} (Ш/К МЛ: {1})", this.Text, this.RouteListBarcode);

            tbsTareInvoice.TextChanged += new EventHandler(tbsTareInvoice_TextChanged);

            ReloadTareInvoice();
        }

        void tbsTareInvoice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbsTareInvoice.Text))
                    return;

                var tareInvoiceBarCode = tbsTareInvoice.Text;

                var needCloseFlag = (int?)null;
                var needScanTare = (int?)null;

                using (var adapter = new Data.DeliveryTableAdapters.CheckTareInvoiceTransitReturnByRouteListTableAdapter())
                    adapter.CheckInvoice(this.ReceiptDocID, tareInvoiceBarCode, ref needCloseFlag, ref needScanTare);

                // Признак выбора режима сдачи тары
                if (needScanTare.HasValue)
                    this.NeedScanTare = Convert.ToBoolean(needScanTare ?? 0);

                // Признак сканирования последней тары
                if (Convert.ToBoolean(needCloseFlag ?? 0) == true)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return;
                }

                ReloadTareInvoice();

                tbsTareInvoice.Text = string.Empty;
                tbsTareInvoice.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbsTareInvoice.Focus();
                tbsTareInvoice.SelectAll();
            }
        }

        private void ReloadTareInvoice()
        {
            try
            {
                checkTareInvoiceTransitReturnByRouteListBindingSource.DataSource = null;
                delivery.TareReturnByRouteList.Clear();

                var qttyScannedInvoices = (int?)null;
                var tare = checkTareInvoiceTransitReturnByRouteListTableAdapter.GetData(this.ReceiptDocID, ref qttyScannedInvoices);

                if (qttyScannedInvoices.HasValue)
                    lblScannedInvoicesQtty.Text = qttyScannedInvoices.Value.ToString();

                delivery.TareReturnByRouteList.Merge(tare);
                checkTareInvoiceTransitReturnByRouteListBindingSource.DataSource = tare;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ReceiptDebtorsReturnedTareForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                var tareReceiptCommit = false;
                var tareReceiptCancel = false;

                if (DialogResult != DialogResult.OK)
                    tareReceiptCancel = true;
                else
                {
                    if (!this.NeedScanTare)
                        tareReceiptCommit = true;
                }

                if (tareReceiptCommit)
                {
                    this.ConfirmTareReceipt();
                    return;
                }

                if (tareReceiptCancel)
                {
                    this.CancelTareReceipt();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbsTareInvoice.Text = string.Empty;
                tbsTareInvoice.Focus();

                e.Cancel = true;
            }
        }

        private void CancelTareReceipt()
        {
            ReceiptDebtorsReturnedTareTransitForm.CancelTareReceipt(this.ReceiptDocID);
        }

        private void ConfirmTareReceipt()
        {
            ReceiptDebtorsReturnedTareTransitForm.ConfirmTareReceipt(this.UserID, this.ReceiptDocID);
        }
    }
}
