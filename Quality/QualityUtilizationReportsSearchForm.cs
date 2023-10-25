using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Window;

namespace WMSOffice.Dialogs.Quality
{
    public partial class QualityUtilizationReportsSearchForm : DialogForm
    {
       public static QualityUtilizationReportsSearchParameters SearchParameters {get;set;}

        public QualityUtilizationReportsSearchForm()
        {
            InitializeComponent();
        }

        static QualityUtilizationReportsSearchForm()
        {
            SearchParameters = new QualityUtilizationReportsSearchParameters();

            SearchParameters.PeriodTo = DateTime.Today;

            SearchParameters.AllowUsageProhibitionReports = true;
            SearchParameters.AllowTransferToUtilizationReports = true;
            SearchParameters.AllowUtilizationVolumeMethodsReports = true;

            SearchParameters.SearchLastActiveReports = true;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            Initialize();

            this.btnOK.Location = new Point(172, 8);
            this.btnCancel.Location = new Point(262, 8);
        }

        private void Initialize()
        {
            if (!string.IsNullOrEmpty(SearchParameters.DocNumber))
                tbDocNumber.Text = SearchParameters.DocNumber;

            if (SearchParameters.PeriodFrom.HasValue)
                dtpPeriodFrom.Value = SearchParameters.PeriodFrom.Value;
            dtpPeriodFrom.Checked = SearchParameters.PeriodFrom.HasValue;

            if (SearchParameters.PeriodTo.HasValue)
                dtpPeriodTo.Value = SearchParameters.PeriodTo.Value;
            dtpPeriodTo.Checked = SearchParameters.PeriodTo.HasValue;

            if (!string.IsNullOrEmpty(SearchParameters.ItemID))
                tbItemID.Text = SearchParameters.ItemID;
            if (!string.IsNullOrEmpty(SearchParameters.VendorLot))
                tbVendorLot.Text = SearchParameters.VendorLot;
            if (!string.IsNullOrEmpty(SearchParameters.BatchNumber))
                tbBatchNumber.Text = SearchParameters.BatchNumber;
            if (!string.IsNullOrEmpty(SearchParameters.Supplier))
                tbSupplier.Text = SearchParameters.Supplier;

            if (SearchParameters.AllowUsageProhibitionReports.HasValue)
                cbAllowUsageProhibitionReports.Checked = SearchParameters.AllowUsageProhibitionReports.Value;
            if (SearchParameters.AllowTransferToUtilizationReports.HasValue)
                cbAllowTransferToUtilizationReports.Checked = SearchParameters.AllowTransferToUtilizationReports.Value;
            if (SearchParameters.AllowUtilizationVolumeMethodsReports.HasValue)
                cbAllowUtilizationVolumeMethodsReports.Checked = SearchParameters.AllowUtilizationVolumeMethodsReports.Value;

            if (SearchParameters.SearchLastActiveReports.HasValue)
                cbSearchLastActiveReports.Checked = SearchParameters.SearchLastActiveReports.Value;
        }

        private void AllowOnlyNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void QualityUtilizationReportsSearchForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !ValidateChanges();
        }

        private bool ValidateChanges()
        {
            try
            {
                if (!string.IsNullOrEmpty(tbDocNumber.Text))
                    SearchParameters.DocNumber = tbDocNumber.Text;
                else
                    SearchParameters.DocNumber = (string)null;

                if (dtpPeriodFrom.Checked && dtpPeriodTo.Checked && dtpPeriodFrom.Value.Date > dtpPeriodTo.Value.Date)
                    throw new Exception("Начальная дата не может превышать конечную.");

                if (dtpPeriodFrom.Checked)
                    SearchParameters.PeriodFrom = dtpPeriodFrom.Value.Date;
                else
                    SearchParameters.PeriodFrom = (DateTime?)null;

                if (dtpPeriodTo.Checked)
                    SearchParameters.PeriodTo = dtpPeriodTo.Value.Date;
                else
                    SearchParameters.PeriodTo = (DateTime?)null;

                if (!string.IsNullOrEmpty(tbItemID.Text))
                    SearchParameters.ItemID = tbItemID.Text;
                else
                    SearchParameters.ItemID = (string)null;

                if (!string.IsNullOrEmpty(tbVendorLot.Text))
                    SearchParameters.VendorLot = tbVendorLot.Text;
                else
                    SearchParameters.VendorLot = (string)null;

                if (!string.IsNullOrEmpty(tbBatchNumber.Text))
                    SearchParameters.BatchNumber = tbBatchNumber.Text;
                else
                    SearchParameters.BatchNumber = (string)null;

                if (!string.IsNullOrEmpty(tbSupplier.Text))
                    SearchParameters.Supplier = tbSupplier.Text;
                else
                    SearchParameters.Supplier = (string)null;

                SearchParameters.AllowUsageProhibitionReports = cbAllowUsageProhibitionReports.Checked;
                SearchParameters.AllowTransferToUtilizationReports = cbAllowTransferToUtilizationReports.Checked;
                SearchParameters.AllowUtilizationVolumeMethodsReports = cbAllowUtilizationVolumeMethodsReports.Checked;

                SearchParameters.SearchLastActiveReports = cbSearchLastActiveReports.Checked;

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
