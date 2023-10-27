using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls;
using System.Xml;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Classes;
using WMSOffice.Dialogs.Quality;

namespace WMSOffice.Dialogs.WH
{
    public partial class DebitOrderForm : DialogForm
    {
        private readonly Data.WH.PurchaseOrdersForDebitRow order = null;

        public bool IsReadOnly { get; private set; }

        public bool CanEdit { get; private set; }

        public bool CanEditHeader { get; private set; }

        public bool CanEditCostPrice { get; private set; }

        public bool CanEditGTD { get; private set; }


        public DebitOrderForm()
        {
            InitializeComponent();
        }

        public DebitOrderForm(Data.WH.PurchaseOrdersForDebitRow pOrder)
            : this()
        {
            order = pOrder;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Initialize();

            this.IsReadOnly = false;


            this.CheckAccess();
            if (this.CanEdit || this.CanEditHeader)
            {
                var hasEditAccess = this.CheckActiveEditSession();
                if (!hasEditAccess)
                    this.CanEdit = this.CanEditHeader = false;
            }

            this.IsReadOnly = !this.CanEdit;

            if (this.CanEditCostPrice)
            {
                btnEditCostPrice.Enabled = true;
            }
            else
            {
                btnEditCostPrice.Enabled = false;
            }

            if (this.CanEditGTD)
            {
                btnEditGTD.Enabled = true;
            }
            else
            {
                btnEditGTD.Enabled = false;
            }


            // Инициализация счет-фактуры
            tbInvoiceNumber.Text = order.IsInvoiceNumberNull() ? string.Empty : order.InvoiceNumber;

            dtpInvoiceDate.Value = order.IsInvoiceDateNull() ? DateTime.Today : order.InvoiceDate;

            if (this.CanEdit || this.CanEditHeader)
                dtpInvoiceDate.Checked = false;

            if (!this.order.EDI.ToUpper().Equals("ДА"))
                btnSelectInvoice.Visible = false;


            if (this.CanEdit || this.CanEditHeader)
            {
                #region obsolete
                ////if (!this.CanEdit)
                ////{
                ////    btnValidateOrder.Enabled = false;
                ////    btnSplitOrderItem.Enabled = false;
                ////    btnGenerateBatches.Enabled = false;
                ////    btnDeleteOrderLine.Enabled = false;

                ////    dgvDetails.ReadOnly = true;
                ////    dgvDetails.Invalidate();
                ////}


                ////if (this.CanEditHeader)
                ////    this.Text = string.Format("{0} (только счет-фактура)", this.Text);

                //if (this.order.OrderType.Equals("90") || this.CanEditHeader)
                //{
                //    tbInvoiceNumber.Text = order.IsInvoiceNumberNull() ? string.Empty : order.InvoiceNumber;

                //    dtpInvoiceDate.Value = order.IsInvoiceDateNull() ? DateTime.Today : order.InvoiceDate;

                //    if (!this.CanEditHeader)
                //        dtpInvoiceDate.Checked = false;
                //}

                //if (!this.order.EDI.ToUpper().Equals("ДА"))
                //{
                //    btnSelectInvoice.Visible = false;
                //}
                #endregion
            }
            else
            {
                if (!this.CanEditCostPrice && !this.CanEditGTD)
                    this.Text = string.Format("{0} (только чтение)", this.Text);

                tbInvoiceNumber.ReadOnly = true;
                tbInvoiceNumber.BackColor = SystemColors.Window;
                btnSelectInvoice.Visible = false;

                dtpInvoiceDate.Enabled = false;

                //btnValidateOrder.Enabled = false;
                //btnSplitOrderItem.Enabled = false;
                //btnGenerateBatches.Enabled = false;
                //btnDeleteOrderLine.Enabled = false;

                //dgvDetails.ReadOnly = true;
                //dgvDetails.Invalidate();

                this.btnOK.Visible = false;
                this.btnCancel.Text = "Закрыть";
            }

            if (!this.CanEdit)
            {
                btnValidateOrder.Enabled = false;
                btnSplitOrderItem.Enabled = false;
                btnGenerateBatches.Enabled = false;
                btnDeleteOrderLine.Enabled = false;

                dgvDetails.ReadOnly = true;
                dgvDetails.Invalidate();
            }

            #region Obsolete
            //if (!this.IsReadOnly)
            //    this.IsReadOnly = !this.CheckAccess();

            //if (!this.IsReadOnly)
            //    this.IsReadOnly = !this.CheckActiveEditSession();

            ////this.IsReadOnly = true;

            //if (this.IsReadOnly)
            //{
            //    this.Text = string.Format("{0} (только чтение)", this.Text);

            //    tbInvoiceNumber.ReadOnly = true;
            //    tbInvoiceNumber.BackColor = SystemColors.Window;
            //    btnSelectInvoice.Visible = false;

            //    dtpInvoiceDate.Enabled = false;

            //    btnValidateOrder.Enabled = false;
            //    btnSplitOrderItem.Enabled = false;
            //    btnGenerateBatches.Enabled = false;
            //    btnDeleteOrderLine.Enabled = false;

            //    dgvDetails.ReadOnly = true;
            //    dgvDetails.Invalidate();

            //    this.btnOK.Visible = false;
            //    this.btnCancel.Text = "Закрыть";
            //}
            //else
            //{
            //    if (this.order.OrderType.Equals("90"))
            //    {
            //        tbInvoiceNumber.Text = order.IsInvoiceNumberNull() ? string.Empty : order.InvoiceNumber;

            //        dtpInvoiceDate.Value = order.IsInvoiceDateNull() ? DateTime.Today : order.InvoiceDate;
            //        dtpInvoiceDate.Checked = false;
            //    }

            //    if (!this.order.EDI.ToUpper().Equals("ДА"))
            //    {
            //        btnSelectInvoice.Visible = false;
            //    }
            //}
            #endregion

            btnOK.Location = new Point(1107, 8);
            btnCancel.Location = new Point(1197, 8);

            this.WindowState = FormWindowState.Maximized;

            tbInvoiceNumber.Focus();
        }

        private void Initialize()
        {
            Config.LoadDataGridViewSettings(this.Name, dgvDetails);

            tbOrderNumber.Text = order.OrderNumber.ToString();

            stbOrderType.ValueReferenceQuery = "[dbo].[pr_DG_Get_Purch_Order_Types_List]";
            stbOrderType.UserID = this.UserID;
            stbOrderType.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stbVendor_OnVerifyValue);
            stbOrderType.SetValueByDefault(order.OrderType);

            stbSupplier.ValueReferenceQuery = "[dbo].[pr_DG_Get_Vendors_List]";
            stbSupplier.UserID = this.UserID;
            stbSupplier.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stbVendor_OnVerifyValue);
            stbSupplier.SetValueByDefault(order.SuplierCod.ToString());

            tbCurrencyRate.Text = string.Format("{0:N4} {1}", order.IsExchangeRateNull() ? 0.0D : order.ExchangeRate, order.IsCurrencyCodeNull() ? "N/A" : order.CurrencyCode);

            //tbInvoiceNumber.Text = !order.IsInvoiceNumberNull() ? order.InvoiceNumber : (string)null;
            //dtpInvoiceDate.Value = !order.IsInvoiceDateNull() && !string.IsNullOrEmpty(order.InvoiceDate) ? Convert.ToDateTime(order.InvoiceDate) : DateTime.Today;

            tbInvoiceNumber.Text = (string)null;

            dtpInvoiceDate.Value = DateTime.Today;
            dtpInvoiceDate.Checked = false;

            this.LoadDetails();
        }

        private void CheckAccess()
        {
            try
            {
                var orderNumber = order.OrderNumber;
                var orderType = order.OrderType;

                var canEdit = (bool?)null;
                var canEditHeader = (bool?)null;
                var canEditCostPrice = (bool?)null;
                var canEditGTD = (bool?)null;

                using (var adapter = new Data.WHTableAdapters.PurchaseOrdersForDebitTableAdapter())
                    adapter.CheckAccess(this.UserID, orderNumber, orderType, ref canEdit, ref canEditHeader, ref canEditCostPrice, ref canEditGTD);

                this.CanEdit = canEdit ?? false;
                this.CanEditHeader = canEditHeader ?? false;
                this.CanEditCostPrice = canEditCostPrice ?? false;
                this.CanEditGTD = canEditGTD ?? false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckActiveEditSession()
        {
            try
            {
                var orderNumber = order.OrderNumber;
                var orderType = order.OrderType;

                using (var adapter = new Data.WHTableAdapters.PurchaseOrdersForDebitTableAdapter())
                    adapter.CheckActiveEditSession(this.UserID, orderNumber, orderType);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        void stbVendor_OnVerifyValue(object sender, WMSOffice.Controls.VerifyValueArgs e)
        {
            var control = sender as SearchTextBox;
            TextBox lblDescription = null;

            if (control == stbOrderType)
                lblDescription = tbOrderType;
            else if (control == stbSupplier)
                lblDescription = tbSupplier;

            if (lblDescription != null)
            {
                lblDescription.Text = e.Success ? e.Description : "ЗНАЧЕНИЕ НЕ НАЙДЕНО!";
                lblDescription.ForeColor = e.Success ? SystemColors.ControlText : Color.Red;

                if (e.Success)
                    control.Value = e.Value;
                //else
                //    control.Value = string.Empty;
            }
        }

        private void LoadDetails()
        {
            this.LoadDetails((int?)null);
        }

        private void LoadDetails(int? lineID)
        {
            try
            {
                var orderNumber = order.OrderNumber;
                var orderType = order.OrderType;

                purchaseOrderDetailsForDebitTableAdapter.Fill(wH.PurchaseOrderDetailsForDebit, this.UserID, orderNumber, orderType);

                if (dgvDetails.Rows.Count > 0)
                    this.NavigateToOrderItem(lineID);

                this.RecalcTotalAmount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NavigateToOrderItem(int? lineID)
        {
            if (!lineID.HasValue)
                dgvDetails.Rows[0].Selected = false;
            else
            {
                foreach (DataGridViewRow row in dgvDetails.Rows)
                {
                    var detail = (row.DataBoundItem as DataRowView).Row as Data.WH.PurchaseOrderDetailsForDebitRow;
                    if (detail.LineID.Equals(lineID))
                    {
                        //row.Selected = true;
                        row.Cells[dgvDetails.CurrentCell.OwningColumn.Index].Selected = true;

                        //dgvDetails.FirstDisplayedScrollingRowIndex = row.Index;
                    }
                }
            }
        }

        private static readonly Color selectedCellDefaultBackColor = ColorTranslator.FromHtml("#CCDAFF");
        private static readonly Color editableCellBackColor = ColorTranslator.FromHtml("#fff5d5");
        private static readonly Color deletedCellBackColor = ColorTranslator.FromHtml("#D3D3D3");
        
        private void dgvDetails_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            //if (dgvDetails.SelectedCells.Count > 0 && e.RowIndex == dgvDetails.SelectedCells[0].RowIndex)
            ////if (dgvDetails.CurrentCell != null && e.RowIndex == dgvDetails.CurrentCell.RowIndex)
            //{
            //    e.CellStyle.BackColor = selectedCellDefaultBackColor;
            //    e.CellStyle.SelectionForeColor = selectedCellDefaultBackColor;

            //    //e.CellStyle.SelectionBackColor = selectedCellDefaultBackColor;
            //}
            ////else
            ////{
            ////    e.CellStyle.BackColor = SystemColors.Window;
            ////    e.CellStyle.SelectionForeColor = SystemColors.Window;
            ////}

            var detail = (dgvDetails.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.WH.PurchaseOrderDetailsForDebitRow;

            if (detail.IsDeleted)
            {
                e.CellStyle.BackColor = deletedCellBackColor;
                e.CellStyle.SelectionForeColor = deletedCellBackColor;

                return;
            }

            if (dgvDetails.Columns[e.ColumnIndex].DataPropertyName == wH.PurchaseOrderDetailsForDebit.CostPriceColumn.Caption)
            {
                // Исключение для себестоимости на статусе 999
                if (this.CanEditCostPrice)
                {
                    e.CellStyle.BackColor = editableCellBackColor;
                    e.CellStyle.SelectionForeColor = editableCellBackColor;
                }

                return;
            }


            if (dgvDetails.Columns[e.ColumnIndex].DataPropertyName == wH.PurchaseOrderDetailsForDebit.QuantityColumn.Caption ||
                dgvDetails.Columns[e.ColumnIndex].DataPropertyName == wH.PurchaseOrderDetailsForDebit.LocationColumn.Caption ||
                dgvDetails.Columns[e.ColumnIndex].DataPropertyName == wH.PurchaseOrderDetailsForDebit.SupplierLotColumn.Caption ||
                dgvDetails.Columns[e.ColumnIndex].DataPropertyName == wH.PurchaseOrderDetailsForDebit.LotExpirationColumn.Caption ||
                dgvDetails.Columns[e.ColumnIndex].DataPropertyName == wH.PurchaseOrderDetailsForDebit.UKTVEDColumn.Caption ||
                dgvDetails.Columns[e.ColumnIndex].DataPropertyName == wH.PurchaseOrderDetailsForDebit.CostColumn.Caption ||
                dgvDetails.Columns[e.ColumnIndex].DataPropertyName == wH.PurchaseOrderDetailsForDebit.AmountColumn.Caption ||

                dgvDetails.Columns[e.ColumnIndex].DataPropertyName == wH.PurchaseOrderDetailsForDebit.TaxColumn.Caption ||
                dgvDetails.Columns[e.ColumnIndex].DataPropertyName == wH.PurchaseOrderDetailsForDebit.VatColumn.Caption)
            {
                var lineID = detail.LineID;
                var propertyName = dgvDetails.Columns[e.ColumnIndex].DataPropertyName;

                var hasDefaultColor = false;

                var drValidateResult = wH.PurchaseOrderForDebitValidateResult.FindByLineIDPropertyName(lineID, propertyName);
                if (drValidateResult != null)
                {
                    if (!drValidateResult.IsColorNull())
                    {
                        var color = Color.FromName(drValidateResult.Color); //drValidateResult.IsValid ? Color.LightGreen : Color.LightPink;
                        e.CellStyle.BackColor = color;
                        e.CellStyle.SelectionForeColor = color;
                    }
                    else
                    {
                        hasDefaultColor = true;
                    }

                    dgvDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = drValidateResult.IsToolTipTextNull() ? (string)null : drValidateResult.ToolTipText;
                }
                else
                {
                    hasDefaultColor = true;
                }

                if (hasDefaultColor)
                {
                    if (!this.IsReadOnly && !dgvDetails.Columns[e.ColumnIndex].ReadOnly && detail.CanEditLine)
                    {
                        e.CellStyle.BackColor = editableCellBackColor;
                        e.CellStyle.SelectionForeColor = editableCellBackColor;

                        //e.CellStyle.SelectionBackColor = selectionBackColor;
                        //e.CellStyle.SelectionForeColor = Color.Black;
                    }
                }
            }
        }

        private void dgvDetails_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;

            if (dgvDetails.Columns[e.ColumnIndex].DataPropertyName == wH.PurchaseOrderDetailsForDebit.QuantityColumn.Caption ||
                dgvDetails.Columns[e.ColumnIndex].DataPropertyName == wH.PurchaseOrderDetailsForDebit.CostColumn.Caption ||
                dgvDetails.Columns[e.ColumnIndex].DataPropertyName == wH.PurchaseOrderDetailsForDebit.AmountColumn.Caption)
                //|| dgvDetails.Columns[e.ColumnIndex].DataPropertyName == wH.PurchaseOrderDetailsForDebit.LotExpirationColumn.Caption)
            {
                if (e.Exception is FormatException)
                    MessageBox.Show(string.Format("Значение поля {0} должно быть числом.", dgvDetails.Columns[e.ColumnIndex].HeaderText), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int currentRowIndex = -1;
        private void dgvDetails_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            #region ПОКРАСКА ПЕРВЫХ 2-Х ЯЧЕЕК ТЕКУЩЕЙ СТРОКИ (НЕ ТРЕБУЕТСЯ)
            //if (e.RowIndex != currentRowIndex)
            //{
            //    if (currentRowIndex > 0)
            //    {
            //        dgvDetails.Rows[currentRowIndex].Cells[itemIDDataGridViewTextBoxColumn.Index].Style.ForeColor = Color.Black;
            //        dgvDetails.Rows[currentRowIndex].Cells[itemNameDataGridViewTextBoxColumn.Index].Style.ForeColor = Color.Black;
            //    }

            //    if (e.RowIndex > 0)
            //    {
            //        dgvDetails.Rows[e.RowIndex].Cells[itemIDDataGridViewTextBoxColumn.Index].Style.ForeColor = Color.Brown;
            //        dgvDetails.Rows[e.RowIndex].Cells[itemNameDataGridViewTextBoxColumn.Index].Style.ForeColor = Color.Brown;
            //    }

            //    currentRowIndex = e.RowIndex;
            //}
            #endregion

            if (!this.dgvDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].IsInEditMode)
            {
                this.dgvDetails.CurrentCell = this.dgvDetails.Rows[e.RowIndex].Cells[e.ColumnIndex];
                this.dgvDetails.BeginEdit(true);
            }
        }

        private void dgvDetails_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var detail = (dgvDetails.CurrentCell.OwningRow.DataBoundItem as DataRowView).Row as Data.WH.PurchaseOrderDetailsForDebitRow;
            var branch = detail.Branch;
            var itemID = detail.ItemID;

            if (detail.IsDeleted || !detail.CanEditLine)
            {
                this.dgvDetails.EndEdit(DataGridViewDataErrorContexts.Commit);
                return;
            }

            var propertyName = dgvDetails.CurrentCell.OwningColumn.DataPropertyName;

            if (e.Control is SearchTextBoxCellEditorControl)
            {
                var control = e.Control as SearchTextBoxCellEditorControl;
                control.Initialize();

                if (propertyName == wH.PurchaseOrderDetailsForDebit.UKTVEDColumn.Caption)
                {
                    control.ValueReferenceQuery = "[dbo].[pr_DG_Get_UKTVED_List]";
                    control.ApplyFilter(new FilterStorage(new List<FilterItem>(new FilterItem[] { new FilterItem("UKTVEDcode", string.Format("{0}*", control.TextEditor.Text.Substring(0, Math.Min(4, control.TextEditor.Text.Length)))) })));
                }
                else if (propertyName == wH.PurchaseOrderDetailsForDebit.LocationColumn.Caption)
                {
                    control.ValueReferenceQuery = "[dbo].[pr_DG_Get_Locn_List]";
                    control.ApplyAdditionalParameter("branch", branch);
                }
                else if (propertyName == wH.PurchaseOrderDetailsForDebit.SupplierLotColumn.Caption)
                {
                    control.ValueReferenceQuery = "[dbo].[pr_DG_Get_Vendor_Lots_List]";
                    control.ApplyAdditionalParameter("itm", itemID);
                    //control.AddIgnorableColumn("ExpDate");
                    control.AddIgnorableColumn("IsNew");
                }

                control.UserID = this.UserID;
                control.NavigateByValue = true;

                control.OnVerifyValue -= new VerifyValueHandler(control_OnVerifyValue);
                control.OnVerifyValue += new VerifyValueHandler(control_OnVerifyValue);
            }
        }

        void control_OnVerifyValue(object sender, VerifyValueArgs e)
        {
            try
            {
                var detail = (dgvDetails.CurrentCell.OwningRow.DataBoundItem as DataRowView).Row as Data.WH.PurchaseOrderDetailsForDebitRow;

                var isValid = false;
                var toolTipText = string.Empty;
                var color = Color.Empty;

                if (e.Success)
                {
                    (sender as SearchTextBoxCellEditorControl).Value = e.Value;
                    dgvDetails.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    //dgvDetails.EditingControl.Hide();

                    if (!string.IsNullOrEmpty(e.Value))
                    {
                        toolTipText = string.Format("({0}) {1}", e.Value, e.Description);
                        color = e.OwnedRow.Table.Columns.Contains("IsNew") && Convert.ToBoolean(e.OwnedRow["IsNew"]) ? Color.Cyan : Color.LightGreen;
                        isValid = true;

                        // Авто выбор СГ
                        if (e.OwnedRow.Table.Columns.Contains("ExpDate") && e.OwnedRow["ExpDate"] != DBNull.Value)
                        {
                            detail.LotExpiration = Convert.ToDateTime(e.OwnedRow["ExpDate"]);

                            this.ValidateDetailLotExpirationPropertyValue(detail);

                            dgvDetails.InvalidateCell(lotExpirationDataGridViewTextBoxColumn.Index, dgvDetails.CurrentCell.OwningRow.Index);
                        }
                    }
                }
                else
                {
                    var propertyDescription = dgvDetails.CurrentCell.OwningColumn.HeaderText;
                    toolTipText = string.Format("Значение поля {0} не найдено в справочнике!", propertyDescription);
                    color = Color.LightPink;
                    isValid = false;
                }

                this.ValidateDetailPropertyValue(detail, dgvDetails.CurrentCell.OwningColumn.DataPropertyName, isValid, toolTipText, color, true);

                dgvDetails.InvalidateCell(dgvDetails.CurrentCell.OwningColumn.Index, dgvDetails.CurrentCell.OwningRow.Index);

                // навигация
                //this.SelectNextCell(detail);
            }
            catch (Exception ex)
            {

            }
        }

        private void dgvDetails_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var isQuantityChanged = false;
                var isCostChanged = false;
                var isAmountChanged = false;
                var needRecalcTotalAmount = false;

                if (dgvDetails.Columns[e.ColumnIndex].DataPropertyName == wH.PurchaseOrderDetailsForDebit.QuantityColumn.Caption ||
                    dgvDetails.Columns[e.ColumnIndex].DataPropertyName == wH.PurchaseOrderDetailsForDebit.LotExpirationColumn.Caption ||
                    dgvDetails.Columns[e.ColumnIndex].DataPropertyName == wH.PurchaseOrderDetailsForDebit.CostColumn.Caption ||
                    dgvDetails.Columns[e.ColumnIndex].DataPropertyName == wH.PurchaseOrderDetailsForDebit.AmountColumn.Caption)
                {
                    var detail = (dgvDetails.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.WH.PurchaseOrderDetailsForDebitRow;
                    
                    if (dgvDetails.Columns[e.ColumnIndex].DataPropertyName == wH.PurchaseOrderDetailsForDebit.QuantityColumn.Caption)
                    {
                        this.ValidateDetailQuantityPropertyValue(detail);

                        isQuantityChanged = true;
                        needRecalcTotalAmount = true;
                    }
                    else if (dgvDetails.Columns[e.ColumnIndex].DataPropertyName == wH.PurchaseOrderDetailsForDebit.LotExpirationColumn.Caption)
                    {
                        this.ValidateDetailLotExpirationPropertyValue(detail);
                    }
                    else if (dgvDetails.Columns[e.ColumnIndex].DataPropertyName == wH.PurchaseOrderDetailsForDebit.CostColumn.Caption)
                    {
                        this.ValidateDetailCostPropertyValue(detail);

                        isCostChanged = true;
                        needRecalcTotalAmount = true;
                    }
                    else if (dgvDetails.Columns[e.ColumnIndex].DataPropertyName == wH.PurchaseOrderDetailsForDebit.AmountColumn.Caption)
                    {
                        this.ValidateDetailAmountPropertyValue(detail);

                        isAmountChanged = true;
                        needRecalcTotalAmount = true;
                    }

                    if (needRecalcTotalAmount)
                    {
                        this.RecalcOrderItem(isQuantityChanged, isCostChanged, isAmountChanged);
                        this.RecalcTotalAmount();
                    }

                    dgvDetails.InvalidateCell(e.ColumnIndex, e.RowIndex);

                    // навигация
                    //this.SelectNextCell(detail);
                }
            }
            catch (Exception ex)
            {
            
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F5)
            {
                if (dgvDetails.Columns[dgvDetails.CurrentCell.OwningColumn.Index].DataPropertyName == wH.PurchaseOrderDetailsForDebit.SupplierLotColumn.Caption
                    && dgvDetails.CurrentCell.IsInEditMode)
                {
                    var detail = (dgvDetails.CurrentCell.OwningRow.DataBoundItem as DataRowView).Row as Data.WH.PurchaseOrderDetailsForDebitRow;

                    if (!detail.IsSeriesVendorNull())
                        detail.SupplierLot = detail.SeriesVendor;

                    if (!detail.IsExpDateVendorNull())
                        detail.LotExpiration = detail.ExpDateVendor;

                    // Авто выбор СГ
                    this.ValidateDetailLotExpirationPropertyValue(detail);

                    dgvDetails.InvalidateCell(lotExpirationDataGridViewTextBoxColumn.Index, dgvDetails.CurrentCell.OwningRow.Index);

                    // навигация
                    this.SelectNextCell(detail, true);
                }

                return true;
            }
            if (keyData == Keys.Up)
            {
                if (dgvDetails.CurrentCell.OwningRow.Index > 0)
                    dgvDetails.CurrentCell = dgvDetails.Rows[dgvDetails.CurrentCell.OwningRow.Index - 1].Cells[dgvDetails.CurrentCell.OwningColumn.Index];

                return true;
            }

            if (keyData == Keys.Down)
            {
                if (dgvDetails.CurrentCell.OwningRow.Index < dgvDetails.Rows.Count - 1)
                    dgvDetails.CurrentCell = dgvDetails.Rows[dgvDetails.CurrentCell.OwningRow.Index + 1].Cells[dgvDetails.CurrentCell.OwningColumn.Index];

                return true;
            }

            if (keyData == (Keys.Left | Keys.Control))
            {
                if (dgvDetails.CurrentCell.OwningColumn.Index > 0)
                    dgvDetails.CurrentCell = dgvDetails.Rows[dgvDetails.CurrentCell.OwningRow.Index].Cells[dgvDetails.CurrentCell.OwningColumn.Index - 1];

                return true;
            }

            if (keyData == (Keys.Right | Keys.Control))
            {
                if (dgvDetails.CurrentCell.IsInEditMode)
                    // навигация
                    this.SelectNextCell();
                else if (dgvDetails.CurrentCell.OwningColumn.Index < dgvDetails.Columns.Count - 1)
                    dgvDetails.CurrentCell = dgvDetails.Rows[dgvDetails.CurrentCell.OwningRow.Index].Cells[dgvDetails.CurrentCell.OwningColumn.Index + 1];

                return true;
            }

            if (keyData == Keys.Enter)
            {
                if (dgvDetails.CurrentCell.IsInEditMode)
                    // навигация
                    this.SelectNextCell(true);
                else if (dgvDetails.CurrentCell.OwningRow.Index < dgvDetails.Rows.Count - 1)
                    dgvDetails.CurrentCell = dgvDetails.Rows[dgvDetails.CurrentCell.OwningRow.Index + 1].Cells[dgvDetails.CurrentCell.OwningColumn.Index];

                return true;
            }

            if (keyData == (Keys.Enter | Keys.Control))
            {
                this.SelectNearestEditableCell();

                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void SelectNearestEditableCell()
        {
            if (this.IsReadOnly)
            {
                if (dgvDetails.CurrentCell.OwningColumn.Index < dgvDetails.Columns.Count - 1)
                    dgvDetails.CurrentCell = dgvDetails.Rows[dgvDetails.CurrentCell.OwningRow.Index].Cells[dgvDetails.CurrentCell.OwningColumn.Index + 1];

                return;
            }

            var idxNextColumn =
                dgvDetails.CurrentCell.OwningColumn.Index < quantityDataGridViewTextBoxColumn.Index
                    ? itemIDDataGridViewTextBoxColumn.Index // quantityDataGridViewTextBoxColumn.Index
                    : dgvDetails.CurrentCell.OwningColumn.Index < locationDataGridViewTextBoxColumn.Index
                        ? quantityDataGridViewTextBoxColumn.Index // locationDataGridViewTextBoxColumn.Index
                        : dgvDetails.CurrentCell.OwningColumn.Index < supplierLotDataGridViewTextBoxColumn.Index
                            ? locationDataGridViewTextBoxColumn.Index // supplierLotDataGridViewTextBoxColumn.Index
                            : dgvDetails.CurrentCell.OwningColumn.Index < lotExpirationDataGridViewTextBoxColumn.Index
                                ? supplierLotDataGridViewTextBoxColumn.Index // lotExpirationDataGridViewTextBoxColumn.Index
                                : dgvDetails.CurrentCell.OwningColumn.Index < uKTVEDDataGridViewTextBoxColumn.Index
                                    ? lotExpirationDataGridViewTextBoxColumn.Index // uKTVEDDataGridViewTextBoxColumn.Index
                                    : dgvDetails.CurrentCell.OwningColumn.Index < costDataGridViewTextBoxColumn.Index
                                        ? uKTVEDDataGridViewTextBoxColumn.Index // costDataGridViewTextBoxColumn.Index
                                        : dgvDetails.CurrentCell.OwningColumn.Index < amountDataGridViewTextBoxColumn.Index
                                            ? costDataGridViewTextBoxColumn.Index // amountDataGridViewTextBoxColumn.Index
                                            : dgvDetails.CurrentCell.OwningColumn.Index < dgvDetails.Columns.Count // - 1
                                                ? amountDataGridViewTextBoxColumn.Index // dgvDetails.CurrentCell.OwningColumn.Index + 1
                                                : dgvDetails.CurrentCell.OwningColumn.Index;

            this.SelectNextCell(dgvDetails.CurrentCell.OwningRow, dgvDetails.Columns[idxNextColumn], true);
        }

        private void SelectNextCell()
        {
            var detail = (dgvDetails.CurrentCell.OwningRow.DataBoundItem as DataRowView).Row as Data.WH.PurchaseOrderDetailsForDebitRow;
            this.SelectNextCell(detail, false);
        }

        private void SelectNextCell(bool smartNavigation)
        {
            this.SelectNextCell(dgvDetails.CurrentCell.OwningRow, dgvDetails.CurrentCell.OwningColumn, smartNavigation);
        }

        private void SelectNextCell(DataGridViewRow targetRow, DataGridViewColumn targetColumn, bool smartNavigation)
        {
            var detail = (dgvDetails.CurrentCell.OwningRow.DataBoundItem as DataRowView).Row as Data.WH.PurchaseOrderDetailsForDebitRow;
            this.SelectNextCell(detail, targetRow, targetColumn, smartNavigation);
        }

        private void SelectNextCell(Data.WH.PurchaseOrderDetailsForDebitRow detail)
        {
            this.SelectNextCell(detail, false);
        }

        private void SelectNextCell(Data.WH.PurchaseOrderDetailsForDebitRow detail, bool smartNavigation)
        {
            this.SelectNextCell(detail, dgvDetails.CurrentCell.OwningRow, dgvDetails.CurrentCell.OwningColumn, smartNavigation);
        }

        private void SelectNextCell(Data.WH.PurchaseOrderDetailsForDebitRow detail, DataGridViewRow targetRow, DataGridViewColumn targetColumn, bool smartNavigation)
        {
            try
            {
                if (false)
                {

                }
                else if (targetColumn.DataPropertyName == wH.PurchaseOrderDetailsForDebit.ItemIDColumn.Caption)
                {
                    if (smartNavigation)
                    {
                        if (detail.IsQuantityNull())
                            dgvDetails.CurrentCell = dgvDetails.Rows[targetRow.Index].Cells[quantityDataGridViewTextBoxColumn.Index];
                        else if (detail.IsLocationNull())
                            dgvDetails.CurrentCell = dgvDetails.Rows[targetRow.Index].Cells[locationDataGridViewTextBoxColumn.Index];
                        else
                            dgvDetails.CurrentCell = dgvDetails.Rows[targetRow.Index].Cells[supplierLotDataGridViewTextBoxColumn.Index]; 
                    }
                    else
                        dgvDetails.CurrentCell = dgvDetails.Rows[targetRow.Index].Cells[quantityDataGridViewTextBoxColumn.Index];
                }
                else if (targetColumn.DataPropertyName == wH.PurchaseOrderDetailsForDebit.QuantityColumn.Caption)
                {
                    if (smartNavigation)
                    {
                        if (detail.IsLocationNull())
                            dgvDetails.CurrentCell = dgvDetails.Rows[targetRow.Index].Cells[locationDataGridViewTextBoxColumn.Index];
                        else
                            dgvDetails.CurrentCell = dgvDetails.Rows[targetRow.Index].Cells[supplierLotDataGridViewTextBoxColumn.Index]; 
                    }
                    else
                        dgvDetails.CurrentCell = dgvDetails.Rows[targetRow.Index].Cells[locationDataGridViewTextBoxColumn.Index];
                }
                else if (targetColumn.DataPropertyName == wH.PurchaseOrderDetailsForDebit.LocationColumn.Caption)
                {
                    dgvDetails.CurrentCell = dgvDetails.Rows[targetRow.Index].Cells[supplierLotDataGridViewTextBoxColumn.Index];
                }
                else if (targetColumn.DataPropertyName == wH.PurchaseOrderDetailsForDebit.SupplierLotColumn.Caption)
                {
                    if (smartNavigation)
                    {
                        if (detail.IsLotExpirationNull())
                            dgvDetails.CurrentCell = dgvDetails.Rows[targetRow.Index].Cells[lotExpirationDataGridViewTextBoxColumn.Index];
                        else
                            dgvDetails.CurrentCell = dgvDetails.Rows[targetRow.Index].Cells[uKTVEDDataGridViewTextBoxColumn.Index];
                    }
                    else
                        dgvDetails.CurrentCell = dgvDetails.Rows[targetRow.Index].Cells[lotExpirationDataGridViewTextBoxColumn.Index];
                }
                else if (targetColumn.DataPropertyName == wH.PurchaseOrderDetailsForDebit.LotExpirationColumn.Caption)
                {
                    dgvDetails.CurrentCell = dgvDetails.Rows[targetRow.Index].Cells[uKTVEDDataGridViewTextBoxColumn.Index];
                }
                else if (targetColumn.DataPropertyName == wH.PurchaseOrderDetailsForDebit.UKTVEDColumn.Caption)
                {
                    if (smartNavigation)
                    {
                        if (detail.IsCostNull())
                            dgvDetails.CurrentCell = dgvDetails.Rows[targetRow.Index].Cells[costDataGridViewTextBoxColumn.Index];
                        else
                        {
                            dgvDetails.CurrentCell = dgvDetails.Rows[targetRow.Index].Cells[amountDataGridViewTextBoxColumn.Index];
                            if (!detail.IsAmountNull())
                                this.SelectNextCell(detail, targetRow, targetColumn = dgvDetails.CurrentCell.OwningColumn, smartNavigation);
                        }
                    }
                    else
                        dgvDetails.CurrentCell = dgvDetails.Rows[targetRow.Index].Cells[costDataGridViewTextBoxColumn.Index];
                }
                else if (targetColumn.DataPropertyName == wH.PurchaseOrderDetailsForDebit.CostColumn.Caption)
                {
                    if (smartNavigation)
                    {
                        if (detail.IsAmountNull())
                            dgvDetails.CurrentCell = dgvDetails.Rows[targetRow.Index].Cells[amountDataGridViewTextBoxColumn.Index];
                        else
                        {
                            this.SelectFirstCellInNextRow(detail, targetRow, targetColumn, smartNavigation);
                        }
                    }
                    else
                        dgvDetails.CurrentCell = dgvDetails.Rows[targetRow.Index].Cells[amountDataGridViewTextBoxColumn.Index];
                }
                else if (targetColumn.DataPropertyName == wH.PurchaseOrderDetailsForDebit.AmountColumn.Caption)
                {
                    this.SelectFirstCellInNextRow(detail, targetRow, targetColumn, smartNavigation);
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private void SelectFirstCellInNextRow(Data.WH.PurchaseOrderDetailsForDebitRow detail, DataGridViewRow targetRow, DataGridViewColumn targetColumn, bool smartNavigation)
        {
            dgvDetails.CurrentCell = dgvDetails.Rows[targetRow.Index].Cells[quantityDataGridViewTextBoxColumn.Index];

            if (targetRow.Index < dgvDetails.Rows.Count - 1)
            {
                dgvDetails.CurrentCell = (targetRow = dgvDetails.Rows[dgvDetails.CurrentCell.OwningRow.Index + 1]).Cells[(targetColumn = dgvDetails.CurrentCell.OwningColumn).Index];

                if (smartNavigation)
                {
                    detail = (targetRow.DataBoundItem as DataRowView).Row as Data.WH.PurchaseOrderDetailsForDebitRow;

                    if (!detail.IsQuantityNull())
                        this.SelectNextCell(detail, targetRow, targetColumn, smartNavigation);
                }
            }
        }

        private void ValidateDetailLotExpirationPropertyValue(Data.WH.PurchaseOrderDetailsForDebitRow detail)
        {
            var isValid = !detail.IsLotExpirationNull() && detail.LotExpiration.Date > DateTime.Today.Date;
            var toolTipText = isValid ? detail.LotExpiration.ToShortDateString() : "Срок годности должен превышать текущую дату!";

            this.ValidateDetailPropertyValue(detail, dgvDetails.Columns[lotExpirationDataGridViewTextBoxColumn.Index].DataPropertyName, isValid, toolTipText);
        }

        private void ValidateDetailQuantityPropertyValue(Data.WH.PurchaseOrderDetailsForDebitRow detail)
        {
            var isValid = !detail.IsQuantityNull() && detail.Quantity > 0;
            var toolTipText = isValid ? string.Format("{0:N0}", detail.Quantity) : "Количество должно быть положительным числом!";

            this.ValidateDetailPropertyValue(detail, dgvDetails.Columns[quantityDataGridViewTextBoxColumn.Index].DataPropertyName, isValid, toolTipText);
        }

        private void ValidateDetailCostPropertyValue(Data.WH.PurchaseOrderDetailsForDebitRow detail)
        {
            var isValid = !detail.IsCostNull() && detail.Cost > 0;
            var toolTipText = isValid ? string.Format("{0:N2}", detail.Cost) : "Цена за шт. должна быть положительным числом!";

            this.ValidateDetailPropertyValue(detail, dgvDetails.Columns[costDataGridViewTextBoxColumn.Index].DataPropertyName, isValid, toolTipText);
        }

        private void ValidateDetailAmountPropertyValue(Data.WH.PurchaseOrderDetailsForDebitRow detail)
        {
            var isValid = !detail.IsAmountNull() && detail.Amount > 0;
            var toolTipText = isValid ? string.Format("{0:N4}", detail.Amount) : "Сумма должна быть положительным числом!";

            this.ValidateDetailPropertyValue(detail, dgvDetails.Columns[amountDataGridViewTextBoxColumn.Index].DataPropertyName, isValid, toolTipText);
        }

        [Obsolete]
        private void ValidateDetailPropertyValue(int rowIndex, int columnIndex, bool isValid, string toolTipText, Color color)
        {
            var detail = (dgvDetails.Rows[dgvDetails.CurrentCell.OwningRow.Index].DataBoundItem as DataRowView).Row as Data.WH.PurchaseOrderDetailsForDebitRow;
            var propertyName = dgvDetails.CurrentCell.OwningColumn.DataPropertyName;
            this.ValidateDetailPropertyValue(detail, propertyName, isValid, toolTipText, color, false);
        }

        private void ValidateDetailPropertyValue(Data.WH.PurchaseOrderDetailsForDebitRow detail, string propertyName, bool isValid, string toolTipText)
        {
            this.ValidateDetailPropertyValue(detail, propertyName, isValid, toolTipText, isValid ? Color.LightGreen : Color.LightPink, false);
        }

        private void ValidateDetailPropertyValue(Data.WH.PurchaseOrderDetailsForDebitRow detail, string propertyName, bool isValid, string toolTipText, Color color, bool removeEmptyCellValue)
        {
            var lineID = detail.LineID;

            var drValidateResult = wH.PurchaseOrderForDebitValidateResult.FindByLineIDPropertyName(lineID, propertyName);
            if (drValidateResult == null)
            {
                drValidateResult = wH.PurchaseOrderForDebitValidateResult.NewPurchaseOrderForDebitValidateResultRow();
                drValidateResult.LineID = lineID;
                drValidateResult.PropertyName = propertyName;
                wH.PurchaseOrderForDebitValidateResult.AddPurchaseOrderForDebitValidateResultRow(drValidateResult);
            }

            if (detail[propertyName].Equals(DBNull.Value) || (removeEmptyCellValue && string.IsNullOrEmpty(detail[propertyName].ToString())))
            {
                //wH.PurchaseOrderForDebitValidateResult.RemovePurchaseOrderForDebitValidateResultRow(drValidateResult);
                drValidateResult.SetColorNull();
                drValidateResult.SetToolTipTextNull();
                drValidateResult.SetIsValidNull();
            }
            else
            {
                drValidateResult.ToolTipText = toolTipText;
                drValidateResult.Color = Enum.GetName(typeof(KnownColor), color.ToKnownColor());
                drValidateResult.IsValid = isValid;
            }
        }

        private void NavigateToItemID()
        {
            if (dgvDetails.SelectedCells.Count < 1)
                return;

            try
            {
                dgvDetails.CurrentCell = dgvDetails.Rows[dgvDetails.CurrentCell.OwningRow.Index].Cells[itemIDDataGridViewTextBoxColumn.Index];
            }
            catch (Exception ex)
            { 
            
            }
        }

        private void btnValidateOrder_Click(object sender, EventArgs e)
        {
            this.NavigateToItemID();
            this.ValidateOrder();
        }

        private bool ValidateOrder()
        {
            try
            {
                var xOrder = this.CreateOrderXML();
                return this.ValidateOrder(xOrder);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool ValidateOrder(XmlDocument xOrder)
        {
            try
            {
                //dgvDetails.CommitEdit(DataGridViewDataErrorContexts.Commit);
                //dgvDetails.EditingControl.Hide();

                using (var adapter = new Data.WHTableAdapters.PurchaseOrderForDebitValidateResultTableAdapter())
                    adapter.Fill(wH.PurchaseOrderForDebitValidateResult, this.UserID, xOrder.InnerXml);

                this.ClearValidationToolTips();

                dgvDetails.Invalidate();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;                
            }
        }

        private void ClearValidationToolTips()
        {
            try
            {
                foreach (DataGridViewRow row in dgvDetails.Rows)
                    foreach (DataGridViewCell cell in row.Cells)
                        cell.ToolTipText = (string)null;
            }
            catch (Exception ex)
            {
                
            }
        }

        private void btnGenerateBatches_Click(object sender, EventArgs e)
        {

        }

        private void btnSplitOrderItem_Click(object sender, EventArgs e)
        {
            if (dgvDetails.SelectedCells.Count < 1)
                return;

            this.NavigateToItemID();
            this.SplitOrderItem();
        }

        private void SplitOrderItem()
        {
            try
            {
                var orderNumber = order.OrderNumber;
                var orderType = order.OrderType;

                var detail = (dgvDetails.CurrentCell.OwningRow.DataBoundItem as DataRowView).Row as Data.WH.PurchaseOrderDetailsForDebitRow;
                var lineID = detail.LineID;
                var groupID = detail.PDLNID;
                var quantity = Convert.ToDecimal(detail.IsQuantityNull() ? 0.0 : detail.Quantity);
                if (quantity > 1)
                {
                    var dlgDebitOrderLineSplitForm = new DebitOrderItemSplitForm(quantity);
                    if (dlgDebitOrderLineSplitForm.ShowDialog(this) == DialogResult.OK)
                    {
                        var xOrder = this.CreateOrderXML(false);

                        using (var adapter = new Data.WHTableAdapters.PurchaseOrderDetailsForDebitTableAdapter())
                            adapter.SplitOrderItem(this.UserID, orderNumber, orderType, lineID, dlgDebitOrderLineSplitForm.Quantity, groupID, xOrder.InnerXml);

                        this.LoadDetails(lineID);
                    }
                }
                else
                    throw new Exception(string.Format("Сплитовка невозможна: недостаточно количества."));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DebitOrderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.CommitOrder();
            //else if (!this.IsReadOnly)
            //else if (this.CanEdit)
            else
                e.Cancel = !this.CancelOrder();
        }

        private bool CommitOrder()
        {
            try
            {
                // Можно редактировать только заголовок 
                if (this.CanEditHeader)
                {
                    this.ValidateOrderHeader();

                    using (var adapter = new Data.WHTableAdapters.PurchaseOrdersForDebitTableAdapter())
                        adapter.ChangeInvoice(this.UserID, order.OrderNumber, order.OrderType, tbInvoiceNumber.Text, dtpInvoiceDate.Value.Date);

                    return true;
                }

                // Можно редактировать заголовок и строки
                if (this.CanEdit)
                {
                    var xOrder = this.CreateOrderXML();

                    if (this.ValidateOrder(xOrder))
                    {
                        var validateWarnings = true;
                        var messageWarnings = (string)null;

                        while (true)
                        {
                            using (var adapter = new Data.WHTableAdapters.PurchaseOrdersForDebitTableAdapter())
                                adapter.CommitEdit(this.UserID, xOrder.InnerXml, ref messageWarnings, validateWarnings);

                            if (validateWarnings && !string.IsNullOrEmpty(messageWarnings))
                            {
                                if (MessageBox.Show(string.Format("Обнаружены следующие замечания \r\nпри проверке строк приходования:\r\n\r\n{0}\r\n\r\nВы желаете продолжить?", messageWarnings), "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                                    return false;

                                validateWarnings = false;
                                continue;
                            }

                            return true;
                        }
                    }

                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool CancelOrder()
        {
            try
            {
                var orderNumber = order.OrderNumber;
                var orderType = order.OrderType;

                using (var adapter = new Data.WHTableAdapters.PurchaseOrdersForDebitTableAdapter())
                    adapter.CancelEdit(this.UserID, orderNumber, orderType);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool ValidateOrderHeader()
        {
            if (string.IsNullOrEmpty(tbInvoiceNumber.Text))
                throw new Exception("Не указан № счет-фактуры.");

            if (!dtpInvoiceDate.Checked)
                throw new Exception("Не выбрана дата счет-фактуры.");

            //if (dtpInvoiceDate.Value.Date < DateTime.Today)
            //    throw new Exception("Дата счет-фактуры не может быть указана задним числом.");

            return true;
        }

        private XmlDocument CreateOrderXML()
        {
            return this.CreateOrderXML(true);
        }

        private XmlDocument CreateOrderXML(bool validate)
        {
            if (validate)
                this.ValidateOrderHeader();

            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml("<Order></Order>");
            XmlElement xRoot = xDoc.DocumentElement;

            XmlAttribute xValue = null;

            #region Header
            var xHeaderElement = xDoc.CreateElement("Header");

            xValue = xHeaderElement.Attributes.Append(xDoc.CreateAttribute("order_number"));
            xValue.Value = order.OrderNumber.ToString();

            xValue = xHeaderElement.Attributes.Append(xDoc.CreateAttribute("order_type"));
            xValue.Value = order.OrderType.ToString();

            xValue = xHeaderElement.Attributes.Append(xDoc.CreateAttribute("invoice_number"));
            xValue.Value = tbInvoiceNumber.Text.ToString();

            xValue = xHeaderElement.Attributes.Append(xDoc.CreateAttribute("invoice_date"));
            xValue.Value = dtpInvoiceDate.Value.ToString("yyyy-MM-dd");

            xRoot.AppendChild(xHeaderElement);
            #endregion

            #region Lines
            var xLinesElement = xDoc.CreateElement("Lines");
            foreach (Data.WH.PurchaseOrderDetailsForDebitRow line in wH.PurchaseOrderDetailsForDebit)
            {
                if (!line.CanEditLine)
                    continue;

                var xLineElement = xDoc.CreateElement("Line");

                xValue = xLineElement.Attributes.Append(xDoc.CreateAttribute("pdlnid"));
                xValue.Value = line.IsPDLNIDNull() ? string.Empty : line.PDLNID.ToString();

                xValue = xLineElement.Attributes.Append(xDoc.CreateAttribute("line_id"));
                xValue.Value = line.IsLineIDNull() ? string.Empty : line.LineID.ToString();

                xValue = xLineElement.Attributes.Append(xDoc.CreateAttribute("item_id"));
                xValue.Value = line.IsItemIDNull() ? string.Empty : line.ItemID.ToString();

                xValue = xLineElement.Attributes.Append(xDoc.CreateAttribute("qty"));
                xValue.Value = line.IsQuantityNull() ? string.Empty : line.Quantity.ToString();

                xValue = xLineElement.Attributes.Append(xDoc.CreateAttribute("vendor_lot"));
                xValue.Value = line.IsSupplierLotNull() ? string.Empty : line.SupplierLot.ToString();

                xValue = xLineElement.Attributes.Append(xDoc.CreateAttribute("exp_date"));
                xValue.Value = line.IsLotExpirationNull() ? string.Empty : line.LotExpiration.ToString("yyyy-MM-dd");

                xValue = xLineElement.Attributes.Append(xDoc.CreateAttribute("locn"));
                xValue.Value = line.IsLocationNull() ? string.Empty : line.Location.ToString();

                xValue = xLineElement.Attributes.Append(xDoc.CreateAttribute("uktved"));
                xValue.Value = line.IsUKTVEDNull() ? string.Empty : line.UKTVED.ToString();

                xValue = xLineElement.Attributes.Append(xDoc.CreateAttribute("cost"));
                xValue.Value = line.IsCostNull() ? string.Empty : line.Cost.ToString();

                xValue = xLineElement.Attributes.Append(xDoc.CreateAttribute("amount"));
                xValue.Value = line.IsAmountNull() ? string.Empty : line.Amount.ToString();

                xValue = xLineElement.Attributes.Append(xDoc.CreateAttribute("is_deleted"));
                xValue.Value = line.IsIsDeletedNull() ? string.Empty : Convert.ToInt32(line.IsDeleted).ToString();

                xLinesElement.AppendChild(xLineElement);
            }
            xRoot.AppendChild(xLinesElement);
            #endregion

            return xDoc;
        }

        private void RecalcOrderItem(bool isQuantityChanged, bool isCostChanged, bool isAmountChanged)
        {
            try
            {
                var orderNumber = order.OrderNumber;
                var orderType = order.OrderType;

                var detail = (dgvDetails.CurrentCell.OwningRow.DataBoundItem as DataRowView).Row as Data.WH.PurchaseOrderDetailsForDebitRow;
                var lineID = detail.LineID;
                var groupID = detail.PDLNID;
                var quantity = detail.IsQuantityNull() ? (double?)null : detail.Quantity;
                var cost = detail.IsCostNull() ? (decimal?)null : detail.Cost;
                var amount = detail.IsAmountNull() ? (decimal?)null : detail.Amount;
                var amountNDS = detail.IsAmountNDSNull() ? (decimal?)null : detail.AmountNDS;
                var amountWithNDS = detail.IsAmountWithNDSNull() ? (decimal?)null : detail.AmountWithNDS;

                using (var adapter = new Data.WHTableAdapters.PurchaseOrderDetailsForDebitTableAdapter())
                    adapter.RecalcOrderItem(this.UserID, orderNumber, orderType, lineID, groupID, quantity, cost, amount, ref amount, ref amountNDS, ref amountWithNDS, ref cost, isQuantityChanged, isCostChanged, isAmountChanged);

                if (cost.HasValue)
                    detail.Cost = cost.Value;

                if (amount.HasValue)
                    detail.Amount = amount.Value;

                if (amountNDS.HasValue)
                    detail.AmountNDS = amountNDS.Value;

                if (amountWithNDS.HasValue)
                    detail.AmountWithNDS = amountWithNDS.Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RecalcTotalAmount()
        {
            try
            {
                var totalAmount = 0.0M;
                var totalDiscount = 0.0M;

                foreach (Data.WH.PurchaseOrderDetailsForDebitRow line in wH.PurchaseOrderDetailsForDebit)
                {
                    if (!line.IsDeleted)
                    {
                        totalAmount += (line.IsAmountNull() ? 0.0M : line.Amount);
                        totalDiscount += (line.IsDiscountNull() ? 0.0M : line.Discount);
                    }
                }

                tbTotalAmount.Text = string.Format("{0:N4}", totalAmount);
                tbTotalAmountWithDiscount.Text = string.Format("{0:N4}", totalAmount - totalDiscount);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            this.NavigateToItemID();
            this.ExportToExcel();
        }

        private void ExportToExcel()
        {
            try
            {
                var msgError = ExportHelper.ExportDataGridViewToExcel(dgvDetails, "Экспорт позиций заказа на закупку", string.Format("Заказ на закупку № ({0}){1}", order.OrderType, order.OrderNumber), true);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSelectInvoice_Click(object sender, EventArgs e)
        {
            this.SelectInvoice();
        }

        private void btnDeleteOrderLine_Click(object sender, EventArgs e)
        {
            this.DeleteOrderLine();
        }

        private void DeleteOrderLine()
        {
            try
            {
                dgvDetails.CancelEdit();
                dgvDetails.EndEdit(DataGridViewDataErrorContexts.LeaveControl);

                if (MessageBox.Show("Вы действительно хотите удалить выбранную строку?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                    return;

                var line = (dgvDetails.SelectedCells[0].OwningRow.DataBoundItem as DataRowView).Row as Data.WH.PurchaseOrderDetailsForDebitRow;
                line.IsDeleted = true;

                dgvDetails.Invalidate();

                this.SetOperationsAccess();

                this.RecalcTotalAmount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SelectInvoice()
        {
            try
            {
                var dlgDebitOrderSelectInvoice = new DebitOrderSelectInvoiceForm(order) { UserID = this.UserID };
                if (dlgDebitOrderSelectInvoice.ShowDialog() == DialogResult.OK)
                {
                    tbInvoiceNumber.Text = dlgDebitOrderSelectInvoice.SelectedDoc.DocNum ?? string.Empty;
                    dtpInvoiceDate.Value = dlgDebitOrderSelectInvoice.SelectedDoc.DocDate ?? DateTime.Today;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DebitOrderForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Config.SaveDataGridViewSettings(this.Name, dgvDetails);
        }

        private void dgvDetails_SelectionChanged(object sender, EventArgs e)
        {
            this.SetOperationsAccess();
        }

        private void SetOperationsAccess()
        {
            var isEnabled = !this.IsReadOnly && dgvDetails.SelectedCells.Count > 0;

            if (isEnabled)
            {
                var line = (dgvDetails.SelectedCells[0].OwningRow.DataBoundItem as DataRowView).Row as Data.WH.PurchaseOrderDetailsForDebitRow;
                isEnabled = line.CanEditLine && !line.IsDeleted;
            }

            btnSplitOrderItem.Enabled = isEnabled;
            btnDeleteOrderLine.Enabled = isEnabled;
        }

        void dgvDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgvDetails.Columns[e.ColumnIndex].DataPropertyName == "CostPrice")
            //{
            //    if (this.CanEditHeader)
            //    {
            //        var curLine = (dgvDetails.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.WH.PurchaseOrderDetailsForDebitRow;
            //        var hasCostPrice = !curLine.IsCostPriceNull() && curLine.CostPrice == 1;

            //        foreach (Data.WH.PurchaseOrderDetailsForDebitRow line in wH.PurchaseOrderDetailsForDebit.Rows)
            //        {
            //            if (hasCostPrice)
            //                line.SetCostPriceNull();
            //            else
            //                line.CostPrice = 1;
            //        }
            //    }
            //}
        }

        private void dgvDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex < 0)
                return;

            if (dgvDetails.Columns[e.ColumnIndex].DataPropertyName == "CostPrice")
            {
                if (this.CanEditCostPrice)
                {
                    var curLine = (dgvDetails.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.WH.PurchaseOrderDetailsForDebitRow;
                    var hasCostPriceSource = !curLine.IsCostPriceNull() && curLine.CostPrice == 1;

                    this.EditCostPrice(hasCostPriceSource);
                }
            }
        }

        private void btnEditCostPrice_Click(object sender, EventArgs e)
        {
            var curLine = (dgvDetails.Rows[0].DataBoundItem as DataRowView).Row as Data.WH.PurchaseOrderDetailsForDebitRow;
            var hasCostPriceSource = !curLine.IsCostPriceNull() && curLine.CostPrice == 1;

            this.EditCostPrice(hasCostPriceSource);
        }

        private void EditCostPrice(bool hasCostPriceSource)
        {
            try
            {
                var flagCostPriceTarget = hasCostPriceSource ? (int?)null : 1;

                using (var adapter = new Data.WHTableAdapters.PurchaseOrdersForDebitTableAdapter())
                    adapter.EditCostPrice(this.UserID, order.OrderNumber, order.OrderType, flagCostPriceTarget);

                foreach (Data.WH.PurchaseOrderDetailsForDebitRow line in wH.PurchaseOrderDetailsForDebit.Rows)
                {
                    if (flagCostPriceTarget.HasValue)
                        line.CostPrice = flagCostPriceTarget.Value;
                    else
                        line.SetCostPriceNull();
                }

                if (flagCostPriceTarget.HasValue)
                    MessageBox.Show("Себестоимость подтверждена.", "Корректировка себестоимости", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Себестоимость не подтверждена.", "Корректировка себестоимости", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditGTD_Click(object sender, EventArgs e)
        {
            this.EditGTD();
        }

        private void EditGTD()
        {
            try
            {
                var numberGTD = string.Empty;
                var dateGTD = DateTime.Today;
                foreach (Data.WH.PurchaseOrderDetailsForDebitRow line in wH.PurchaseOrderDetailsForDebit.Rows)
                {
                    numberGTD = line.IsGTDNumberNull() ? numberGTD : line.GTDNumber;
                    dateGTD = line.IsGTDDateNull() ? dateGTD : line.GTDDate;
                    break;
                }

                var dlgGTDEditor = new GTDEditorForm() { UserID = this.UserID, NumberGTD = numberGTD, DateGTD = dateGTD };
                if (dlgGTDEditor.ShowDialog() != DialogResult.OK)
                    return;

                numberGTD = dlgGTDEditor.NumberGTD;
                dateGTD = dlgGTDEditor.DateGTD;

                using (var adapter = new Data.WHTableAdapters.PurchaseOrdersForDebitTableAdapter())
                    adapter.EditGTD(this.UserID, order.OrderNumber, order.OrderType, numberGTD, dateGTD);

                foreach (Data.WH.PurchaseOrderDetailsForDebitRow line in wH.PurchaseOrderDetailsForDebit.Rows)
                {
                    line.GTDNumber = numberGTD;
                    line.GTDDate = dateGTD;
                }

                MessageBox.Show("Информация о ГТД была изменена.", "Корректировка ГТД", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
