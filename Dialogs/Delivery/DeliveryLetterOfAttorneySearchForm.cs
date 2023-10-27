using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Delivery
{
    public partial class DeliveryLetterOfAttorneySearchForm : DialogForm
    {
        #region ПОЛЯ И СВОЙСТВА ДАННЫХ

        public DateTime? SearchDate { get { return dtpDate.Value.Date; } }

        #endregion

        public static DeliveryLetterOfAttorneySearchContext SearchContext { get; private set; }

        public DeliveryLetterOfAttorneySearchForm()
        {
            InitializeComponent();
        }

        static DeliveryLetterOfAttorneySearchForm()
        {
            SearchContext = new DeliveryLetterOfAttorneySearchContext()
            {
                ComplaintNumber = (long?)null,
                Date = (DateTime?)null
            };
        }

        private void DeliveryLetterOfAttorneySearchForm_Load(object sender, EventArgs e)
        {
            tbComplaintNumber.Text = SearchContext.ComplaintNumber.HasValue ? SearchContext.ComplaintNumber.Value.ToString() : string.Empty;
            dtpDate.Value = SearchContext.Date.HasValue ? SearchContext.Date.Value : DateTime.Today;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(67, 8);
            this.btnCancel.Location = new Point(157, 8);

            if (SearchContext.Date.HasValue)
                rbDate.Checked = true;
            else
                rbComplaintNumber.Checked = true;
        }

        private void tbSearchComponent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.DialogResult = DialogResult.OK;
        }

        private void tbComplaint_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void rbSearchComponent_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rbSearchComponent = sender as RadioButton;

            if (rbSearchComponent == null || !rbSearchComponent.Checked)
                return;

            tbComplaintNumber.Enabled = false;
            dtpDate.Enabled = false;

            // Сценарий поиска -- по № претензии
            if (rbSearchComponent == rbComplaintNumber)
            {
                tbComplaintNumber.Enabled = true;
                tbComplaintNumber.Focus();
                return;
            }

            // Сценарий поиска -- по дате
            if (rbSearchComponent == rbDate)
            {
                dtpDate.Enabled = true;
                dtpDate.Focus();
                return;
            }
        }

        private void DeliveryLetterOfAttorneySearchForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !ApplyChanges();
        }

        private bool ApplyChanges()
        {
            if (rbComplaintNumber.Checked)
            {
                if (string.IsNullOrEmpty(tbComplaintNumber.Text))
                {
                    MessageBox.Show("Номер претензии должен быть указан.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbComplaintNumber.Focus();
                    return false;
                }
            }

            SearchContext.ComplaintNumber = rbComplaintNumber.Checked ? Convert.ToInt64(tbComplaintNumber.Text) : (long?)null;
            SearchContext.Date = rbDate.Checked ? dtpDate.Value.Date : (DateTime?)null;
            return true;
        }
    }

    public class DeliveryLetterOfAttorneySearchContext
    {
        public long? ComplaintNumber { get; set; }
        public DateTime? Date { get; set; }

        public bool SearchAll { get { return !ComplaintNumber.HasValue && !Date.HasValue; } }
    }
}
