using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls;

namespace WMSOffice.Dialogs.Quality
{
    public partial class FindPurchaseOrderForm : DialogForm
    {
        #region ПОЛЯ И СВОЙСТВА ДАННЫХ

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных
        /// </summary>
        private Dialogs.SplashForm waitProgressForm = new WMSOffice.Dialogs.SplashForm();

        public new long UserID { get; set; }

        public BlockActionType ActionType { get; set; }

        public PurchaseOrderItemsBlockParameters PurchaseOrderItemsBlockParameters { get; private set; }

        #endregion

        public FindPurchaseOrderForm()
        {
            InitializeComponent();
        }

        private void FindPurchaseOrderForm_Load(object sender, EventArgs e)
        {
            stbSupplier.ValueReferenceQuery = "[dbo].[pr_BL_Get_Supplier_List]";
            stbSupplier.UserID = this.UserID;

            stbSupplier.OnVerifyValue += (s, ea) => 
            {
                var control = s as SearchTextBox;
                TextBox tbDescription = null;

                if (control == stbSupplier)
                    tbDescription = lblSupplierName;

                if (tbDescription != null)
                {
                    tbDescription.Text = ea.Success ? ea.Description : "ЗНАЧЕНИЕ НЕ НАЙДЕНО!";
                    tbDescription.ForeColor = ea.Success ? SystemColors.ControlText : Color.Red;

                    if (ea.Success)
                        control.Value = ea.Value;
                    //else
                    //    control.Value = string.Empty;
                }
            };
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            btnOK.Location = new Point(567, 8);
            btnCancel.Location = new Point(657, 8);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F5))
            {
                this.FindPurchaseOrder();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void sbFindPurchaseOrder_Click(object sender, EventArgs e)
        {
            this.FindPurchaseOrder();
        }

        private void FindPurchaseOrder()
        {
            try
            {
                var orderID = (long?)null;
                var invoiceNumber = (string)null;
                var supplierID = (int?)null;
                var dateFrom = (DateTime?)null;
                var dateTo = (DateTime?)null;

                var allowReloadData = false;

                #region ВАЛИДАЦИЯ КРИТЕРИЕВ ПОИСКА

                if (!string.IsNullOrEmpty(tbOrderNumber.Text))
                {
                    long parsedOrderID;
                    if (long.TryParse(tbOrderNumber.Text, out parsedOrderID))
                    {
                        orderID = parsedOrderID;
                        allowReloadData = true;
                    }
                    else
                        throw new Exception("Номер заказа должен быть числом.");
                }

                if (!string.IsNullOrEmpty(tbInvoiceNumber.Text))
                {
                    invoiceNumber = tbInvoiceNumber.Text;
                    allowReloadData = true;
                }

                if (!string.IsNullOrEmpty(stbSupplier.Value))
                {
                    int parsedSupplierID;
                    if (int.TryParse(stbSupplier.Value, out parsedSupplierID))
                    {
                        supplierID = parsedSupplierID;
                        allowReloadData = true;
                    }
                    else
                        throw new Exception("Код поставщика должен быть числом.");
                }

                if (cbDateFrom.Checked && cbDateTo.Checked)
                {
                    dateFrom = dtpDateFrom.Value.Date;
                    dateTo = dtpDateTo.Value.Date;

                    if (dateFrom > dateTo)
                        throw new Exception("Дата начала поиска не может превышать дату конца поиска.");

                    var daysLimit = 30;
                    if (dateTo - dateFrom > TimeSpan.FromDays(daysLimit))
                        throw new Exception(string.Format("Период поиска не должен превышать {0} дней.", daysLimit));

                    allowReloadData = true;
                }

                if (allowReloadData)
                {
                    if ((!orderID.HasValue && string.IsNullOrEmpty(invoiceNumber) && !supplierID.HasValue && dateFrom.HasValue && dateTo.HasValue) ||
                        (!orderID.HasValue && string.IsNullOrEmpty(invoiceNumber) && supplierID.HasValue && !dateFrom.HasValue && !dateTo.HasValue))
                        throw new Exception("Поиск по коду поставщика возможен\nтолько при указании периода.");
                }
                else
                    throw new Exception("Хотя бы один критерий поиска должен быть задан."); 

                #endregion

                var findWorker = new BackgroundWorker();
                findWorker.DoWork += (s, e) =>
                {
                    try
                    {
                        e.Result = bL_Search_Purchase_OrderTableAdapter.GetData(dateFrom, dateTo, supplierID, orderID, invoiceNumber, (string)null);
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                findWorker.RunWorkerCompleted += (s, e) =>
                {
                    if (e.Result is Exception)
                        MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        bLSearchPurchaseOrderBindingSource.DataSource = e.Result;
                    }

                    waitProgressForm.CloseForce();
                };

                waitProgressForm.ActionText = "Выполняется поиск заказов на закупку..";
                bLSearchPurchaseOrderBindingSource.DataSource = null;
                findWorker.RunWorkerAsync();
                waitProgressForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbPeriod_CheckedChanged(object sender, EventArgs e)
        {
            var isEnabled = (sender as CheckBox).Checked;
            cbDateFrom.Checked = dtpDateFrom.Enabled = isEnabled;
            cbDateTo.Checked = dtpDateTo.Enabled = isEnabled;
        }

        private void dgvPurchaseOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            this.DialogResult = DialogResult.OK;
        }

        private void FindPurchaseOrderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SelectPurchaseOrderItems();
        }

        private bool SelectPurchaseOrderItems()
        {
            try
            {
                if (dgvPurchaseOrders.SelectedRows.Count == 0)
                    throw new Exception("Не выбран заказ.");

                var purchaseOrderRow = (dgvPurchaseOrders.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.Quality.BL_Search_Purchase_OrderRow;

                this.PurchaseOrderItemsBlockParameters = new PurchaseOrderItemsBlockParameters();
                this.PurchaseOrderItemsBlockParameters.OrderID = Convert.ToInt64(purchaseOrderRow.OrderNumber);
                this.PurchaseOrderItemsBlockParameters.OrderType = purchaseOrderRow.OrderType;
                this.PurchaseOrderItemsBlockParameters.WarehouseID = purchaseOrderRow.WarehouseID;

                if (this.ActionType == BlockActionType.CreateBlock || this.ActionType == BlockActionType.FinishBlock)
                {
                    var dlgInitFindPurchaseOrderItems = new InitFindPurchaseOrderItemsForm(this.PurchaseOrderItemsBlockParameters) { UserID = this.UserID, ActionType = this.ActionType };
                    return dlgInitFindPurchaseOrderItems.ShowDialog() == DialogResult.OK;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }

    public class PurchaseOrderItemsBlockParameters
    {
        public long OrderID { get; set; }
        public string OrderType { get; set; }
        public string WarehouseID { get; set; }
        public string BlockTypeID { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public bool? IsNewVendorLot { get; set; }
        public bool? IsNewItem { get; set; }
        public bool? BlockAllWarehouses { get; set; }

        public PurchaseOrderItemsBlockParameters()
        {
            WarehouseID = (string)null;
            BlockTypeID = (string)null;
        }
    }
}
