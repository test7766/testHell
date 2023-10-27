using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.WH
{
    public partial class ChangeOrderCurrencyForm : DialogForm
    {
        private readonly Data.WH.PurchaseOrdersForDebitRow order = null;

        public decimal DebitCurrencyRate
        {
            get { return nudDebitCurrencyRate.Value; }
            set { nudDebitCurrencyRate.Value = value; }
        }

        public DateTime DebitCurrencyDate
        {
            get { return dtpDebitCurrencyDate.Value; }
            set { dtpDebitCurrencyDate.Value = value; }
        }

        public string DebitCurrency
        {
            get { return tbDebitCurrency.Text; }
        }

        public ChangeOrderCurrencyForm()
        {
            InitializeComponent();
        }

        public ChangeOrderCurrencyForm(Data.WH.PurchaseOrdersForDebitRow pOrder)
            : this()
        {
            order = pOrder;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Initialize();

            this.btnOK.Location = new Point(62, 0);
            this.btnCancel.Location = new Point(152, 0);
        }

        private void Initialize()
        {
            tbDebitCurrency.Text = order.IsCurrencyCodeNull() ? "N/A" : order.CurrencyCode;

            this.DebitCurrencyDate = DateTime.Today;
        }

        private void dtpDebitCurrencyDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                var rate = (double?)null;
                using (var adapter = new Data.WHTableAdapters.PurchaseOrdersForDebitTableAdapter())
                    adapter.GetCurrencyRateByPeriod(this.DebitCurrencyDate, this.DebitCurrency, ref rate);

                if (rate.HasValue)
                    this.DebitCurrencyRate = Convert.ToDecimal(rate.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void controlDebitCurrency_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                this.DialogResult = DialogResult.OK;
        }

        private void ChangeOrderCurrencyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveData();
        }

        private bool SaveData()
        {
            try
            {
                if (this.DebitCurrencyRate.Equals(nudDebitCurrencyRate.Minimum))
                    throw new Exception("Неверное значение курса.");

                var orderNumber = order.OrderNumber;
                var orderType = order.OrderType;

                using (var adapter = new Data.WHTableAdapters.PurchaseOrdersForDebitTableAdapter())
                    adapter.ChangeCurrencyRate(this.UserID, orderNumber, orderType, Convert.ToDouble(this.DebitCurrencyRate), this.DebitCurrencyDate);

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
