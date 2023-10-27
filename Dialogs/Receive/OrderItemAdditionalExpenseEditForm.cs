using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Receive
{
    public partial class OrderItemAdditionalExpenseEditForm : DialogForm
    {
        #region ПОЛЯ И СВОЙСТВА ДАННЫХ

        public new long UserID { get; set; }

        private readonly long orderNumber;

        private readonly string orderType;

        private readonly string inExpenseTypeID;

        public Data.Receive.pr_AE_Get_Cost_TypesRow SelectedExspenseType
        {
            get { return cmbExpenseType.SelectedItem == null ? null :(cmbExpenseType.SelectedItem as DataRowView).Row as Data.Receive.pr_AE_Get_Cost_TypesRow; }
        }

        public string ExpenseTypeID { get; private set; }

        public bool CreateMode { get { return string.IsNullOrEmpty(inExpenseTypeID); } }

        public bool UseExpenseForFullInvoice { get; private set; }

        public decimal ExpenseRate { get; private set; }

        public int SupplierID { get; private set; }

        public bool CheckPriority { get; private set; }

        private bool isDataLoaded = false;

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ

        public OrderItemAdditionalExpenseEditForm()
        {
            InitializeComponent();
        }

        public OrderItemAdditionalExpenseEditForm(long pOrderNumber, string pOrderType, string pExpenseTypeID, decimal pExpenseRate)
            : this()
        {
            orderNumber = pOrderNumber;
            orderType = pOrderType;
            inExpenseTypeID = pExpenseTypeID;

            ExpenseRate = pExpenseRate;
        }

        private void OrderItemAdditionalExpenseEditForm_Load(object sender, EventArgs e)
        {
            isDataLoaded = true;

            LoadSuppliers();
            LoadExpenseTypes();
            
            SetExpenseRateFormat();

            isDataLoaded = false;
        }

        private void LoadExpenseTypes()
        {
            try
            {
                pr_AE_Get_Cost_TypesTableAdapter.Fill(receive.pr_AE_Get_Cost_Types, this.UserID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSuppliers()
        {
            try
            {
                var expenseTypeID = SelectedExspenseType != null ? SelectedExspenseType.ID : (string)null;
                pr_AE_Get_Supplier_For_CostTableAdapter.Fill(receive.pr_AE_Get_Supplier_For_Cost, this.UserID, orderType, orderNumber, expenseTypeID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(317, 8);
            this.btnCancel.Location = new Point(407, 8);

            // Режим изменения
            if (!this.CreateMode)
            {
                cmbExpenseType.SelectedValue = inExpenseTypeID;
                cmbExpenseType.Enabled = false;
            }

            // Если текущий элемент не выбран (отсутствует в списке)
            if (cmbExpenseType.SelectedValue == null)
            {
                tbExpenseRate.Enabled = false;
                cmbSuppliers.Enabled = false;

                this.btnOK.Visible = false;
                this.btnCancel.Text = "Закрыть";

                this.Text = string.Format("{0} ({1})", this.Text, "только чтение");
            }
            else
            {
                this.Text = string.Format("{0} ({1})", this.Text, this.CreateMode ? "создание" : "изменение");
            }
        }

        #endregion

        private void tbExpenseRate_Validating(object sender, CancelEventArgs e)
        {
            if (!tbExpenseRate.Enabled)
                return;

            errorProvider.Clear();

            var expenseRateSign = SelectedExspenseType.IsExpenseRateSignNull() ? 0 : SelectedExspenseType.ExpenseRateSign;
            bool negativeValueError = false;
            bool positiveValueError = false;
            decimal expenseRate;
            if (!decimal.TryParse(tbExpenseRate.Text, out expenseRate) ||
                (negativeValueError = expenseRateSign < 0 && (expenseRate < expenseRateSign * 100.0M || expenseRate >= 0.0M)) ||
                (positiveValueError = expenseRateSign > 0 && (expenseRate > expenseRateSign * 100.0M || expenseRate <= 0.0M)))
            {
                
                errorProvider.SetError(tbExpenseRate, string.Format("Неверно указан процент наценки.\r\n{0}",
                    negativeValueError ? "Значение должно находится в интервале [-100.0; 0.0)" :
                    positiveValueError ? "Значение должно находится в интервале (0.0; 100.0]" :
                    string.Empty));
            }
            else
            {
                ExpenseRate = expenseRate;
            }

            e.Cancel = !String.IsNullOrEmpty(errorProvider.GetError(tbExpenseRate));
        }

        private void tbExpenseRate_Validated(object sender, EventArgs e)
        {
            SetExpenseRateFormat();
        }

        private void SetExpenseRateFormat()
        {
            tbExpenseRate.Text = ExpenseRate.ToString("N7");
        }

        private void cmbExpenseType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!(cbUseExpenseForFullInvoice.Visible = this.CreateMode && SelectedExspenseType != null && !SelectedExspenseType.IsExpenseRateSignNull() && SelectedExspenseType.ExpenseRateSign < 0))
                cbUseExpenseForFullInvoice.Checked = false;

            if (SelectedExspenseType == null)
                return;

            if (!isDataLoaded)
            {
                ExpenseRate = 0.0M;
                SetExpenseRateFormat();
            }

            LoadSuppliers();
            cmbSuppliers.SelectedValue = receive.pr_AE_Get_Supplier_For_Cost[0].Code;
        }

        private void OrderItemAdditionalExpenseEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !ApplyChanges();
        }

        private bool ApplyChanges()
        {
            try
            {
                if (!this.ValidateChildren(ValidationConstraints.Enabled))
                    return false;

                ExpenseTypeID = cmbExpenseType.SelectedValue.ToString();
                UseExpenseForFullInvoice = cbUseExpenseForFullInvoice.Checked;
                SupplierID = Convert.ToInt32(cmbSuppliers.SelectedValue);
                CheckPriority = cbCheckPriority.Checked;

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
