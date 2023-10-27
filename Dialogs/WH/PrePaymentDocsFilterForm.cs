using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls;

namespace WMSOffice.Dialogs.WH
{
    public partial class PrePaymentDocsFilterForm : DialogForm
    {
        /// <summary>
        /// Параметры поиска предоплатной НН и РК
        /// </summary>
        public static PrePaymentDocsFilter PrePaymentDocsFilter { get; set; }

        static PrePaymentDocsFilterForm()
        {
           if (PrePaymentDocsFilter == null)
               PrePaymentDocsFilter = new PrePaymentDocsFilter()
               {
                   SearchType = 1
               };
        }

        public PrePaymentDocsFilterForm()
        {
            InitializeComponent();

            if (PrePaymentDocsFilter == null)
                PrePaymentDocsFilter = new PrePaymentDocsFilter()
                {
                    SearchType = 1
                };
        }

        private void PrePaymentDocsFilterForm_Load(object sender, EventArgs e)
        {
            InitializeFilter();
        }

        private void InitializeFilter()
        {
            stbDebtorCode.ValueReferenceQuery = "[dbo].[pr_PD_Get_Debtor_List]";
            stbDebtorCode.UserID = this.UserID;
            stbDebtorCode.OnVerifyValue += delegate(object sender, VerifyValueArgs e)
            {
                var control = sender as SearchTextBox;
                Label lblDescription = null;

                if (control == stbDebtorCode)
                    lblDescription = lblDebtorCode;

                if (lblDescription != null)
                {
                    lblDescription.Text = e.Success ? e.Description : "ЗНАЧЕНИЕ НЕ НАЙДЕНО!";
                    lblDescription.ForeColor = e.Success ? SystemColors.ControlText : Color.Red;

                    if (e.Success)
                        control.Value = e.Value;
                    //else
                    //    control.Value = string.Empty;
                }
            };

            cmbDocType.SelectedIndex = PrePaymentDocsFilter.SearchType % 2 == 1 ? 0 : 1;

            if (PrePaymentDocsFilter.DebtorCode.HasValue)
                stbDebtorCode.SetValueByDefault(PrePaymentDocsFilter.DebtorCode.Value.ToString());

            if (PrePaymentDocsFilter.DocTypeIndex.HasValue)
                cmbDocType.SelectedIndex = PrePaymentDocsFilter.DocTypeIndex.Value;

            if (PrePaymentDocsFilter.DocNumber.HasValue)
                tbDocNumber.Text = PrePaymentDocsFilter.DocNumber.Value.ToString();

            if (PrePaymentDocsFilter.DateFrom.HasValue)
                dtpFrom.Value = PrePaymentDocsFilter.DateFrom.Value;
            else
                dtpFrom.Checked = false;

            if (PrePaymentDocsFilter.DateTo.HasValue)
                dtpTo.Value = PrePaymentDocsFilter.DateTo.Value;
            else
                dtpTo.Checked = false;
           
            ChangeSearchByDocNumberActivationState(PrePaymentDocsFilter.SearchType == 3 || PrePaymentDocsFilter.SearchType == 4);
            ChangeSearchByDebtorPeriodActivationState(PrePaymentDocsFilter.SearchType == 1 || PrePaymentDocsFilter.SearchType == 2);
        }

        private void ChangeSearchByDocNumberActivationState(bool isActivated)
        {
            if ((gbDocument.Enabled = isActivated) == true)
            {
                cbActivateSearchByDebtorPeriod.Checked = false;
                tbDocNumber.Focus();
            }
            else
                cbActivateSearchByDebtorPeriod.Checked = true;
        }

        private void cbActivateSearchByDocNumber_CheckedChanged(object sender, EventArgs e)
        {
            ChangeSearchByDocNumberActivationState(cbActivateSearchByDocNumber.Checked);
        }

        private void ChangeSearchByDebtorPeriodActivationState(bool isActivated)
        {
            if ((gbDebtorPeriod.Enabled = isActivated) == true)
            {
                cbActivateSearchByDocNumber.Checked = false;
                stbDebtorCode.Focus();
            }
            else
                cbActivateSearchByDocNumber.Checked = true;
        }

        private void cbActivateSearchByDebtorPeriod_CheckedChanged(object sender, EventArgs e)
        {
            ChangeSearchByDebtorPeriodActivationState(cbActivateSearchByDebtorPeriod.Checked);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            btnOK.Location = new Point(267, 8);
            btnCancel.Location = new Point(357, 8);
        }

        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            var control = sender as Control;

            if (e.KeyCode == Keys.Enter)
                SelectNextControl(control, true, true, true, false);
        }

        private void AllowOnlyNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void PrePaymentDocsFilterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
                e.Cancel = !ValidateFilter();
        }

        private bool ValidateFilter()
        {
            try
            {
                PrePaymentDocsFilter.DocTypeIndex = cmbDocType.SelectedIndex;
                PrePaymentDocsFilter.SearchType = 
                    cmbDocType.SelectedIndex == 0 && cbActivateSearchByDebtorPeriod.Checked
                        ? 1
                        : cmbDocType.SelectedIndex == 1 && cbActivateSearchByDebtorPeriod.Checked
                            ? 2
                            : cmbDocType.SelectedIndex == 0 && cbActivateSearchByDocNumber.Checked
                                ? 3
                                : cmbDocType.SelectedIndex == 1 && cbActivateSearchByDocNumber.Checked
                                    ? 4
                                    : -1;

                if (PrePaymentDocsFilter.SearchType == 3 || PrePaymentDocsFilter.SearchType == 4)
                {
                    if (string.IsNullOrEmpty(tbDocNumber.Text))
                        throw new Exception("Необходимо указать № документа при выбраном режиме поиска.");
                }

                PrePaymentDocsFilter.DocNumber = string.IsNullOrEmpty(tbDocNumber.Text) ? (long?)null : Convert.ToInt64(tbDocNumber.Text);


                int debtorCode = 0;
                if (PrePaymentDocsFilter.SearchType == 1 || PrePaymentDocsFilter.SearchType == 2)
                {
                    if (string.IsNullOrEmpty(stbDebtorCode.Value) && !dtpFrom.Checked && !dtpTo.Checked)
                        throw new Exception("Хотя бы одно из полей должно быть заполнено при выбраном режиме поиска.");

                   
                    if (!string.IsNullOrEmpty(stbDebtorCode.Value))
                        if (!int.TryParse(stbDebtorCode.Value, out debtorCode))
                            throw new Exception("Код дебитора должен быть числом.");

                    if (dtpFrom.Checked && dtpTo.Checked && dtpFrom.Value > dtpTo.Value)
                        throw new Exception("Дата \"с\" не должна превышать дату \"по\".");
                }
                
                PrePaymentDocsFilter.DebtorCode = string.IsNullOrEmpty(stbDebtorCode.Value) ? (int?)null : debtorCode;

                PrePaymentDocsFilter.DateFrom = dtpFrom.Checked ? dtpFrom.Value : (DateTime?)null;
                PrePaymentDocsFilter.DateTo = dtpTo.Checked ? dtpTo.Value : (DateTime?)null;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }

    /// <summary>
    /// Параметры поиска предоплатных НН и РК
    /// </summary>
    public class PrePaymentDocsFilter
    {
        /// <summary>
        /// Тип поиска
        /// </summary>
        public int SearchType { get; set; }

        /// <summary>
        /// Индекс типа документа
        /// </summary>
        public int? DocTypeIndex { get; set; }

        /// <summary>
        /// Код дебитора
        /// </summary>
        public int? DebtorCode { get; set; }

        /// <summary>
        /// № документа
        /// </summary>
        public long? DocNumber { get; set; } 

        /// <summary>
        /// Дата "с"
        /// </summary>
        public DateTime? DateFrom { get; set; }

        /// <summary>
        /// Дата "по"
        /// </summary>
        public DateTime? DateTo { get; set; }

    }
}
