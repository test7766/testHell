using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Delivery
{
    public partial class ReceiptDebtorsReturnedTareCheckInvoiceForm : DialogForm
    {
        public string RouteListBarcode { get; set; }

        public bool UseCorrectMode { get; set; }
        
        public int ReceiptDocID { get; private set; }

        public int? TareDocID { get; private set; }

        public ReceiptDebtorsReturnedTareCheckInvoiceForm()
        {
            InitializeComponent();
        }

        public ReceiptDebtorsReturnedTareCheckInvoiceForm(int receiptDocID)
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

            if (this.UseCorrectMode)
                this.Text = string.Format("{0} (доработка)", this.Text);
            else
                this.Text = string.Format("{0} (Ш/К МЛ: {1})", this.Text, this.RouteListBarcode);

            tbsTareInvoice.TextChanged += new EventHandler(tbsTareInvoice_TextChanged);

            if (!this.UseCorrectMode)
                ReloadTareInvoice();

            this.SetNotVisitedReasonsAccess();
        }

        void tbsTareInvoice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbsTareInvoice.Text))
                    return;

                var tareInvoiceBarCode = tbsTareInvoice.Text;

                var needCloseFlag = (int?)null;
                if (this.UseCorrectMode)
                {
                    var receiptDocID = (long?)null;
                    var tareDocID = (long?)null;
                    using (var adapter = new Data.DeliveryTableAdapters.TareReturnByRouteListTableAdapter())
                        adapter.CheckTareInvoiceRevision(tareInvoiceBarCode, this.UserID, ref receiptDocID, ref tareDocID);

                    if (!receiptDocID.HasValue)
                        throw new Exception("Не определен документ сдачи ОТ.");

                    if (!tareDocID.HasValue)
                        throw new Exception("Не определен документ ОТ.");

                    this.ReceiptDocID = Convert.ToInt32(receiptDocID.Value);
                    this.TareDocID = Convert.ToInt32(tareDocID.Value);

                    needCloseFlag = 1;
                }
                else
                {
                    using (var adapter = new Data.DeliveryTableAdapters.TareReturnByRouteListTableAdapter())
                        adapter.CheckTareInvoice(this.ReceiptDocID, tareInvoiceBarCode, ref needCloseFlag);
                }

                // Признак сканирования последней тары
                if (Convert.ToBoolean(needCloseFlag ?? 0) == true)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return;
                }

                if (!this.UseCorrectMode)
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
                checkTareInvoiceReturnByRouteListBindingSource.DataSource = null;
                delivery.TareReturnByRouteList.Clear();

                var qttyScannedInvoices = (int?)null;
                var tare = checkTareInvoiceReturnByRouteListTableAdapter.GetData(this.ReceiptDocID, ref qttyScannedInvoices);

                if (qttyScannedInvoices.HasValue)
                    lblScannedInvoicesQtty.Text = qttyScannedInvoices.Value.ToString();

                delivery.TareReturnByRouteList.Merge(tare);
                checkTareInvoiceReturnByRouteListBindingSource.DataSource = tare;
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
                if (DialogResult != DialogResult.OK)
                    this.CancelTareReceipt();
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
            if (this.UseCorrectMode)
            {

            }
            else
            {
                ReceiptDebtorsReturnedTareForm.CancelTareReceipt(this.ReceiptDocID);
            }
        }

        private void btnSetNotVisitedReasons_Click(object sender, EventArgs e)
        {
            this.SetNotVisitedReasons();
        }

        private void SetNotVisitedReasons()
        {
            try
            {
                var doc = (dgvTareInvoice.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.Delivery.CheckTareInvoiceReturnByRouteListRow;
                var tareDocID = doc.CT_doc;

                var dlgReceiptDebtorsReturnedTareSetNotVisited = new ReceiptDebtorsReturnedTareSetNotVisitedForm() { ReceiptDocID = this.ReceiptDocID, TareDocID = tareDocID, UserID = this.UserID };
                if (dlgReceiptDebtorsReturnedTareSetNotVisited.ShowDialog(this) == DialogResult.OK)
                    this.ReloadTareInvoice();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvTareInvoice_SelectionChanged(object sender, EventArgs e)
        {
            this.SetNotVisitedReasonsAccess();
        }

        private void SetNotVisitedReasonsAccess()
        {
            btnSetNotVisitedReasons.Enabled = false;

            if (this.UseCorrectMode)
                return;

            if (dgvTareInvoice.SelectedRows.Count == 0)
                return;

            var doc = (dgvTareInvoice.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.Delivery.CheckTareInvoiceReturnByRouteListRow;

            btnSetNotVisitedReasons.Enabled = doc.IsSP_DeliveryNull() ? false : doc.SP_Delivery;
        }
    }
}
