using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Window;
using WMSOffice.Controls;

namespace WMSOffice.Dialogs.WH
{
    public partial class ElectronicInvoiceSearchDialog : DialogForm
    {
        public ElectronicInvoicesSearchParameters SearchCriteria { get; private set; }

        public ElectronicInvoiceSearchDialog()
        {
            InitializeComponent();
            SearchCriteria = new ElectronicInvoicesSearchParameters();

            stbDebtorID.ValueReferenceQuery = "[dbo].[pr_EI_Get_Debtors]";
            stbDebtorID.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stbDebtorID_OnVerifyValue);
            stbDebtorID.TextEditor.KeyDown += SelectNextControl_KeyDown;
            stbDebtorID.TextEditor.KeyPress += AllowOnlyNumber_KeyPress;
        }

        void stbDebtorID_OnVerifyValue(object sender, WMSOffice.Controls.VerifyValueArgs e)
        {
            var control = sender as SearchTextBox;
            Label lblDescription = null;

            if (control == stbDebtorID)
                lblDescription = lblDebtorID;

            if (lblDescription != null)
            {
                lblDescription.Text = e.Success ? e.Description : "ЗНАЧЕНИЕ НЕ НАЙДЕНО!";
                lblDescription.ForeColor = e.Success ? SystemColors.ControlText : Color.Red;
                lblDescription.Tag = e.Success;

                if (e.Success)
                    control.Value = e.Value;
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Initialize();
            
            this.btnOK.Location = new Point(294, 8);
            this.btnCancel.Location = new Point(384, 8);
            this.stbDebtorID.Focus();

            //System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("ru-RU");
            //System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfo;
            //System.Threading.Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }

        /// <summary>
        /// Инициализация
        /// </summary>
        private void Initialize()
        {
            this.SearchCriteria.UserID = this.UserID;
            stbDebtorID.UserID = this.UserID;

            this.stbDebtorID.Value = null;
            if (this.SearchCriteria.DebtorID.HasValue)
            {
                this.stbDebtorID.Value = this.SearchCriteria.DebtorID.ToString();
                this.stbDebtorID_OnVerifyValue(stbDebtorID, new VerifyValueArgs(this.SearchCriteria.DebtorID.Value.ToString(), this.SearchCriteria.DebtorName, this.SearchCriteria.IsDebtorIDValid));
            }
            this.stbDebtorID.VerifyValue();

            this.tbTaxInvoiceID.Clear();
            if (this.SearchCriteria.TaxInvoiceID.HasValue)
                this.tbTaxInvoiceID.Text = this.SearchCriteria.TaxInvoiceID.ToString();

            this.tbInvoiceID.Clear();
            if (this.SearchCriteria.InvoiceID.HasValue)
                this.tbInvoiceID.Text = this.SearchCriteria.InvoiceID.ToString();

            this.tbOrderID.Clear();
            if (this.SearchCriteria.OrderID.HasValue)
                this.tbOrderID.Text = this.SearchCriteria.OrderID.ToString();

            this.tbDeliveryID.Clear();
            if (this.SearchCriteria.DeliveryID.HasValue)
                this.tbDeliveryID.Text = this.SearchCriteria.DeliveryID.ToString();

            this.dtpDateFrom.Value = DateTime.Today;
            if (this.SearchCriteria.DateFrom.HasValue)
            {
                cbUseDates.Checked = true;
                this.dtpDateFrom.Value = this.SearchCriteria.DateFrom.Value;
            }

            this.dtpDateTo.Value = DateTime.Today;
            if (this.SearchCriteria.DateTo.HasValue)
            {
                cbUseDates.Checked = true;
                this.dtpDateTo.Value = this.SearchCriteria.DateTo.Value;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Enter))
            {
                this.DialogResult = DialogResult.OK;
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void AllowOnlyNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != (char)22) // CTRL + V
                e.Handled = true;
        }

        private void SelectNextControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var control = sender as Control;

                if (control == tbDeliveryID)
                    cbUseDates.Focus();
                else
                    this.SelectNextControl(control, true, true, true, true);
            }
        }

        private void cbUseDates_CheckedChanged(object sender, EventArgs e)
        {
            dtpDateFrom.Enabled = cbUseDates.Checked;
            dtpDateTo.Enabled = cbUseDates.Checked;
        }

        private void ElectronicInvoiceSearchDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !ValidateSearchCriteria();
        }

        /// <summary>
        /// Метод валидации
        /// </summary>
        /// <returns></returns>
        private bool ValidateSearchCriteria()
        {
            // Валидация установления критериев поиска
            if (string.IsNullOrEmpty(stbDebtorID.Value) &&
                string.IsNullOrEmpty(tbTaxInvoiceID.Text) &&
                string.IsNullOrEmpty(tbInvoiceID.Text) &&
                string.IsNullOrEmpty(tbOrderID.Text) &&
                string.IsNullOrEmpty(tbDeliveryID.Text) &&
                !cbUseDates.Checked)
            {
                MessageBox.Show("Не установлены критерии поиска.", "Ошибка задания критериев поиска", MessageBoxButtons.OK, MessageBoxIcon.Error);
                stbDebtorID.Focus();
                return false;
            }

            this.SearchCriteria.DateFrom = (DateTime?)null;
            this.SearchCriteria.DateTo = (DateTime?)null;
            if (cbUseDates.Checked)
            {
                // Валидация дат
                if (dtpDateFrom.Value.Date > dtpDateTo.Value.Date)
                {
                    MessageBox.Show("Начальная дата не должна превышать конечную.", "Ошибка задания критериев поиска", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtpDateFrom.Focus();
                    return false;
                }

                this.SearchCriteria.DateFrom = dtpDateFrom.Value.Date;
                this.SearchCriteria.DateTo = dtpDateTo.Value.Date;
            }

            int value32; long value64;
            this.SearchCriteria.DebtorID = Int32.TryParse(stbDebtorID.Value, out value32) ? value32 : (int?)null;
            this.SearchCriteria.DebtorName = string.IsNullOrEmpty(lblDebtorID.Text) ? (string)null : lblDebtorID.Text;
            this.SearchCriteria.IsDebtorIDValid = lblDebtorID.Tag == null ? false : Convert.ToBoolean(lblDebtorID.Tag);
            this.SearchCriteria.TaxInvoiceID = Int64.TryParse(tbTaxInvoiceID.Text, out value64) ? value64 : (long?)null;
            this.SearchCriteria.InvoiceID = Int64.TryParse(tbInvoiceID.Text, out value64) ? value64 : (long?)null;
            this.SearchCriteria.OrderID = Int64.TryParse(tbOrderID.Text, out value64) ? value64 : (long?)null;
            this.SearchCriteria.DeliveryID = Int32.TryParse(tbDeliveryID.Text, out value32) ? value32 : (int?)null;

            return true;
        }
    }
}
