using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Transactions;

namespace WMSOffice.Dialogs.Receive
{
    public partial class ImposeAdditionalExpensesEditForm : DialogForm
    {
        #region КОНСТАНТЫ

        /// <summary>
        /// Валюта в гривнах
        /// </summary>
        private const string UAH_CURRENCY = "UAH";

        #endregion

        #region ПОЛЯ И СВОЙСТВА ДАННЫХ

        public new long UserID { get; set; }

        private readonly long orderNumber;

        private readonly string orderType;

        public double CurrencyRate { get; private set; }

        public DateTime DateGK { get; private set; }

        private readonly List<ExpenseItem> lstSelectedRows = new List<ExpenseItem>();

        private bool allowSaveSelection = false;

        private bool readOnlyMode = false;

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ

        public ImposeAdditionalExpensesEditForm()
        {
            InitializeComponent();
        }

        public ImposeAdditionalExpensesEditForm(long pOrderNumber, string pOrderType)
            : this()
        {
            orderNumber = pOrderNumber;
            orderType = pOrderType;
        }

        private void ImposeAdditionalExpensesEditForm_Load(object sender, EventArgs e)
        {
            RefreshHeader();
            RefreshDetails();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Insert))
            {
                if (sbAdd.Enabled)
                {
                    sbAdd_Click(sbAdd, EventArgs.Empty);
                    return true;
                }
            }

            if (keyData == (Keys.F2))
            {
                if (sbEdit.Enabled)
                {
                    sbEdit_Click(sbEdit, EventArgs.Empty);
                    return true;
                }
            }

            if (keyData == (Keys.Delete) && !dgvDetails.IsCurrentCellInEditMode)
            {
                if (sbDelete.Enabled)
                {
                    sbDelete_Click(sbDelete, EventArgs.Empty);
                    return true;
                }
            }

            if (keyData == (Keys.F5))
            {
                RefreshDetails();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            SetHeaderDesign();
            ChangeFormEditMode();

            this.btnOK.Location = new Point(1167, 8);
            this.btnCancel.Location = new Point(1257, 8);
           
            this.MaximizeBox = true;
            this.MinimizeBox = true; 
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Maximized;
        }

        private void SetHeaderDesign()
        {
            if (tbCurrency.Text.Equals(UAH_CURRENCY))
            {
                lblCurrencyRate.Visible = false;
                tbCurrencyRate.Visible = false;
                lblOrderSumCUR.Visible = false;
                tbOrderSumCUR.Visible = false;

                totalSumCURDataGridViewTextBoxColumn.Visible = false;
                sum_cur.Visible = false;
            }
        }

        private void ChangeFormEditMode()
        {
            if (readOnlyMode)
            {
                this.Text = string.Format("{0} (только чтение)", this.Text);

                this.btnOK.Visible = false;
                this.btnCancel.Text = "Закрыть";

                lblDateGK.ForeColor = SystemColors.ControlText;
                dtpDateGK.Enabled = false;

                lblCurrencyRate.ForeColor = SystemColors.ControlText;
                tbCurrencyRate.ReadOnly = true;

                sumDataGridViewTextBoxColumn.ReadOnly = true;
            }
        }

        private void RefreshHeader()
        {
            LoadHeader();
        }

        private void LoadHeader()
        {
            try
            {
                pr_AE_Get_Details_HeaderTableAdapter.Fill(receive.pr_AE_Get_Details_Header, this.UserID, orderType, orderNumber);

                readOnlyMode = receive.pr_AE_Get_Details_Header[0].Isread_onlyNull() ? false : receive.pr_AE_Get_Details_Header[0].read_only;

                
                // Получение даты ГК
                //
                var dateGK = pr_AE_Get_Details_HeaderTableAdapter.GetDateGK(this.UserID, orderType, orderNumber);
                DateTime parsedDateGK;
                if (DateTime.TryParse((dateGK ?? DateTime.Today).ToString(), out parsedDateGK))
                    receive.pr_AE_Get_Details_Header[0].date_GK = parsedDateGK;                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshDetails()
        {
            allowSaveSelection = false;

            LoadDetails();
            LoadDetailsTotal();

            RestoreSelection();

            allowSaveSelection = true;
        }

        private void LoadDetails()
        {
            try
            {
            pr_AE_Get_DetailsTableAdapter.Fill(receive.pr_AE_Get_Details, this.UserID, orderType, orderNumber);
                prAEGetDetailsBindingSource.Sort = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDetailsTotal()
        {            
            try
            {
                pr_AE_Get_Details_TotalTableAdapter.Fill(receive.pr_AE_Get_Details_Total, this.UserID, orderType, orderNumber);

                var cntRows = receive.pr_AE_Get_Details_Total.Count;
                for (int i = 0; i < cntRows; i++)
                {
                    var row = receive.pr_AE_Get_Details_Total.Rows[i] as Data.Receive.pr_AE_Get_Details_TotalRow;
                    var emptyRow = receive.pr_AE_Get_Details_Total.Newpr_AE_Get_Details_TotalRow();
                    emptyRow.SetTotalSumUAHNull();
                    emptyRow.SetTotalSumCURNull();
                    emptyRow.Position = row.Position;
                    emptyRow.IsEmpty = true;

                    receive.pr_AE_Get_Details_Total.Addpr_AE_Get_Details_TotalRow(emptyRow);
                }

                prAEGetDetailsTotalBindingSource.Sort = string.Format("{0}, {1} DESC", receive.pr_AE_Get_Details_Total.PositionColumn.Caption, receive.pr_AE_Get_Details_Total.IsEmptyColumn.Caption);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void dtpDateGK_Enter(object sender, EventArgs e)
        {
            this.DateGK = dtpDateGK.Value;
        }

        private void dtpDateGK_Validating(object sender, CancelEventArgs e)
        {
            var dateGK = dtpDateGK.Value;
            if (!dateGK.Equals(this.DateGK))
            {
                if (ChangeDateGK(dateGK))
                    RefreshDetails();
                else
                    dtpDateGK.Value = this.DateGK;
            }
        }

        private bool ChangeDateGK(DateTime dateGK)
        {
            try
            {
                pr_AE_Get_Details_HeaderTableAdapter.ChangeDateGK(this.UserID, orderType, orderNumber, dateGK);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void tbCurrencyRate_Enter(object sender, EventArgs e)
        {
            double currencyRate;
            if (double.TryParse(tbCurrencyRate.Text, out currencyRate) && currencyRate > 0.0F)
                this.CurrencyRate = currencyRate;
        }

        private void tbCurrencyRate_Validating(object sender, CancelEventArgs e)
        {
            errorProvider.Clear();

            double currencyRate;
            if (!double.TryParse(tbCurrencyRate.Text, out currencyRate) || currencyRate <= 0.0F)
                errorProvider.SetError(tbCurrencyRate, string.Format("Неверно указан курс валют."));
            else
            {
                if (!currencyRate.Equals(this.CurrencyRate))
                {
                    if (ChangeCurrencyRate(currencyRate))
                        RefreshDetails();
                    else
                        tbCurrencyRate.Text = this.CurrencyRate.ToString();
                }
            }

            e.Cancel = !String.IsNullOrEmpty(errorProvider.GetError(tbCurrencyRate));
        }

        private bool ChangeCurrencyRate(double currencyRate)
        {
            try
            {
                pr_AE_Get_Details_HeaderTableAdapter.ChangeCurrencyRate(this.UserID, orderType, orderNumber, currencyRate);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void sbAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var dlgOrderItemAdditionalExpenseEditForm = new OrderItemAdditionalExpenseEditForm(orderNumber, orderType, null, 0.0M) { UserID = this.UserID };
                if (dlgOrderItemAdditionalExpenseEditForm.ShowDialog() == DialogResult.OK)
                {
                    var expenseTypeID = dlgOrderItemAdditionalExpenseEditForm.ExpenseTypeID;
                    var expenseRate = dlgOrderItemAdditionalExpenseEditForm.ExpenseRate;
                    var supplierID = dlgOrderItemAdditionalExpenseEditForm.SupplierID;
                    var checkPriority = dlgOrderItemAdditionalExpenseEditForm.CheckPriority;
                    var useExpenseForFullInvoice = dlgOrderItemAdditionalExpenseEditForm.UseExpenseForFullInvoice;

                    if (useExpenseForFullInvoice)
                    {
                        pr_AE_Get_DetailsTableAdapter.AddCostFullInvoice(this.UserID, orderType, orderNumber, expenseTypeID, expenseRate, supplierID);
                    }
                    else
                    {
                        using (var ts = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted }))
                        {
                            foreach (DataGridViewRow dgvr in dgvDetails.SelectedRows)
                            {
                                var dr = (dgvr.DataBoundItem as DataRowView).Row as Data.Receive.pr_AE_Get_DetailsRow;
                                var itemID = dr.item_id;
                                var batchNumber = dr.batch_number;

                                pr_AE_Get_DetailsTableAdapter.AddCost(this.UserID, orderType, orderNumber, itemID, batchNumber, expenseTypeID, expenseRate, supplierID, checkPriority);
                            }

                            ts.Complete();
                        }
                    }

                    RefreshDetails();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sbEdit_Click(object sender, EventArgs e)
        {
            try
            {
                var expenseTypeID = ((dgvDetails.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.Receive.pr_AE_Get_DetailsRow).expense_type_id;
                var expenseRate = ((dgvDetails.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.Receive.pr_AE_Get_DetailsRow).percent;

                var dlgOrderItemAdditionalExpenseEditForm = new OrderItemAdditionalExpenseEditForm(orderNumber, orderType, expenseTypeID, expenseRate) { UserID = this.UserID };
                if (dlgOrderItemAdditionalExpenseEditForm.ShowDialog() == DialogResult.OK)
                {
                    expenseRate = dlgOrderItemAdditionalExpenseEditForm.ExpenseRate;
                    var supplierID = dlgOrderItemAdditionalExpenseEditForm.SupplierID;
                    var checkPriority = dlgOrderItemAdditionalExpenseEditForm.CheckPriority;

                    using (var ts = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted }))
                    {
                        foreach (DataGridViewRow dgvr in dgvDetails.SelectedRows)
                        {
                            var dr = (dgvr.DataBoundItem as DataRowView).Row as Data.Receive.pr_AE_Get_DetailsRow;
                            var itemID = dr.item_id;
                            var batchNumber = dr.batch_number;

                            pr_AE_Get_DetailsTableAdapter.EditCost(this.UserID, orderType, orderNumber, itemID, batchNumber, expenseTypeID, expenseRate, supplierID, checkPriority);
                        }

                        ts.Complete();
                    }

                    RefreshDetails();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Вы действительно хотите удалить выбранные позиции начислений?", "Удаление начислений", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (var ts = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted }))
                    {
                        foreach (DataGridViewRow dgvr in dgvDetails.SelectedRows)
                        {
                            var dr = (dgvr.DataBoundItem as DataRowView).Row as Data.Receive.pr_AE_Get_DetailsRow;
                            var itemID = dr.item_id;
                            var batchNumber = dr.batch_number;
                            var expenseTypeID = dr.expense_type_id;

                            pr_AE_Get_DetailsTableAdapter.DeleteCost(this.UserID, orderType, orderNumber, itemID, batchNumber, expenseTypeID);
                        }

                        ts.Complete();
                    }

                    RefreshDetails();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal? sumBeforeEdit;
        private void dgvDetails_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvDetails.SelectedRows.Count == 0)
                return;

            var dr = (dgvDetails.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.Receive.pr_AE_Get_DetailsRow;
            sumBeforeEdit = dr.IssumNull() ? (decimal?)null : dr.sum;

            if (string.IsNullOrEmpty(dr.expense_type_id))
                dgvDetails.EndEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvDetails_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            // Если редактировалось поле "Сумма"
            if (dgvDetails.Columns[e.ColumnIndex].DataPropertyName == this.receive.pr_AE_Get_Details.sumColumn.Caption)
            {
                try
                {
                    var dr = (dgvDetails.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Receive.pr_AE_Get_DetailsRow;

                    var itemID = dr.item_id;
                    var batchNumber = dr.batch_number;
                    var expenseTypeID = dr.expense_type_id;

                    var sum = dr.IssumNull() ? (decimal?)null : dr.sum;

                    pr_AE_Get_DetailsTableAdapter.EditCostSum(this.UserID, orderType, orderNumber, itemID, batchNumber, expenseTypeID, sum);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                RefreshDetails();
            }
        }

        private void dgvDetails_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.ColumnIndex == dgvDetails.Columns[sumDataGridViewTextBoxColumn.Name].Index)
            {
                if (e.Exception != null)
                {
                    var context = (DataGridViewDataErrorContexts.Parsing | DataGridViewDataErrorContexts.Commit);
                    if ((e.Context | DataGridViewDataErrorContexts.Parsing | DataGridViewDataErrorContexts.Commit) == context)
                    {
                        MessageBox.Show(string.Format("Значение суммы должно быть вещественным числом\r\nс 2-мя знаками после запятой."), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = sumBeforeEdit;
                        dgvDetails.RefreshEdit();
                    }
                }
            }
        }

        private void sbRefresh_Click(object sender, EventArgs e)
        {
            RefreshDetails();
        }

        private void dgvDetails_SelectionChanged(object sender, EventArgs e)
        {
            var addOperationEnabled = true;
            var deleteOperationEnabled = true;
            var editOperationEnabled = true;

            if (readOnlyMode || dgvDetails.SelectedRows.Count == 0)
            {
                addOperationEnabled = false;
                deleteOperationEnabled = false;
                editOperationEnabled = false;
            }
            else
            {
                var lstEditExpenseTypes = new List<string>();

                foreach (DataGridViewRow dgvr in dgvDetails.SelectedRows)
                {
                    var dr = (dgvr.DataBoundItem as DataRowView).Row as Data.Receive.pr_AE_Get_DetailsRow;

                    // Add
                    if (addOperationEnabled && !string.IsNullOrEmpty(dr.expense_type_id))
                        addOperationEnabled = false;

                    // Delete
                    if (deleteOperationEnabled && string.IsNullOrEmpty(dr.expense_type_id))
                        deleteOperationEnabled = false;

                    // Edit
                    if (editOperationEnabled && string.IsNullOrEmpty(dr.expense_type_id))
                        editOperationEnabled = false;

                    if (editOperationEnabled && (lstEditExpenseTypes.Count > 0 && !lstEditExpenseTypes.Contains(dr.expense_type_id)))
                        editOperationEnabled = false;

                    if (editOperationEnabled)
                        lstEditExpenseTypes.Add(dr.expense_type_id);
                }
            }

            sbAdd.Enabled = addOperationEnabled;
            sbDelete.Enabled = deleteOperationEnabled;
            sbEdit.Enabled = editOperationEnabled;

            if (allowSaveSelection)
                SaveSelection();
        }

        private void SaveSelection()
        {
            lstSelectedRows.Clear();

            foreach (DataGridViewRow dgvr in dgvDetails.SelectedRows)
            {
                var dr = (dgvr.DataBoundItem as DataRowView).Row as Data.Receive.pr_AE_Get_DetailsRow;

                var expenseItem = new ExpenseItem()
                {
                    ItemID = dr.item_id,
                    BatchNumber = dr.batch_number,
                    ExpenseTypeID = dr.expense_type_id
                };

                lstSelectedRows.Add(expenseItem);
            }
        }

        private void RestoreSelection()
        {
            dgvDetails.ClearSelection();

            foreach (DataGridViewRow dgvr in dgvDetails.Rows)
            {
                var dr = (dgvr.DataBoundItem as DataRowView).Row as Data.Receive.pr_AE_Get_DetailsRow;

                foreach (var sr in lstSelectedRows)
                    if (dr.item_id.Equals(sr.ItemID) && dr.batch_number.Equals(sr.BatchNumber) && dr.expense_type_id.Equals(sr.ExpenseTypeID))
                        dgvr.Selected = true;
            }
        }

        private void dgvDetails_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grid = sender as DataGridView;

            var boundRow = (grid.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Receive.pr_AE_Get_DetailsRow;
            var isMainRow = string.IsNullOrEmpty(boundRow.expense_type_id);
            var color = isMainRow ? Color.LightGray : Color.Wheat;

            grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = color;
            grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = color;
        }

        private void dgvTotal_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grid = sender as DataGridView;

            var boundRow = (grid.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Receive.pr_AE_Get_Details_TotalRow;

            if (boundRow.IsEmpty)
            {
                grid.Rows[e.RowIndex].Height = 7;
                grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = SystemColors.Control;
                grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionBackColor = SystemColors.Control;
            }
            else
            {
                grid.Rows[e.RowIndex].Height = 20;
                grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Black;
                grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = Color.Black;
                grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = boundRow.Position.Equals(1) ? Color.LightGreen : SystemColors.Window;
                grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionBackColor = boundRow.Position.Equals(1) ? Color.LightGreen : SystemColors.Window;
            }
        }

        private void ImposeAdditionalExpensesEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                e.Cancel = !CommitChanges();
            }
            else
            {
                var controlPressed = Control.ModifierKeys == Keys.Control;
                var success = readOnlyMode || RollbackChanges();

                if (!controlPressed)
                    e.Cancel = !success;
            }
        }

        private bool CommitChanges()
        {
            try
            {
                pr_AE_Get_Details_HeaderTableAdapter.CommitChanges(this.UserID, orderType, orderNumber);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool RollbackChanges()
        {
            try
            {
                pr_AE_Get_Details_HeaderTableAdapter.RollbackChanges(this.UserID, orderType, orderNumber);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }

    class ExpenseItem
    {
        public int ItemID { get; set; }
        public string BatchNumber { get; set; }
        public string ExpenseTypeID { get; set; }
    }
}
