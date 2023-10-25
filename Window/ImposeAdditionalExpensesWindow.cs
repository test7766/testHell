using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls;
using WMSOffice.Dialogs.Receive;

namespace WMSOffice.Window
{
    public partial class ImposeAdditionalExpensesWindow : GeneralWindow
    {
        #region ПОЛЯ И СВОЙСТВА ДАННЫХ

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных
        /// </summary>
        private Dialogs.SplashForm waitProgressForm = new WMSOffice.Dialogs.SplashForm();

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ

        public ImposeAdditionalExpensesWindow()
        {
            InitializeComponent();
        }

        private void ImposeAdditionalExpensesWindow_Load(object sender, EventArgs e)
        {
            stbWarehouse.ValueReferenceQuery = "[dbo].[pr_AE_Get_MCU_List]";
            stbSupplier.ValueReferenceQuery = "[dbo].[pr_AE_Get_Supplier_List]";
            stbOrderType.ValueReferenceQuery = "[dbo].[pr_AE_Get_DocTypes_List]";

            stbWarehouse.UserID = this.UserID;
            stbSupplier.UserID = this.UserID;
            stbOrderType.UserID = this.UserID;

            stbWarehouse.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stb_OnVerifyValue);
            stbSupplier.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stb_OnVerifyValue);
            stbOrderType.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stb_OnVerifyValue);

            // Инициализация критериев поиска
            //
            stbOrderType.SetFirstValueByDefault();
            stbWarehouse.SetFirstValueByDefault();
        }

        void stb_OnVerifyValue(object sender, WMSOffice.Controls.VerifyValueArgs e)
        {
            var control = sender as SearchTextBox;
            TextBox tbDescription = null;

            if (control == stbOrderType)
                tbDescription = lblOrderTypeName;
            else if (control == stbWarehouse)
                tbDescription = lblWarehouseName;
            else if (control == stbSupplier)
                tbDescription = lblSupplierName;

            if (tbDescription != null)
            {
                tbDescription.Text = e.Success ? e.Description : "ЗНАЧЕНИЕ НЕ НАЙДЕНО!";
                tbDescription.ForeColor = e.Success ? SystemColors.ControlText : Color.Red;

                if (e.Success)
                    control.Value = e.Value;
                //else
                //    control.Value = string.Empty;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F5))
            {
                this.RefreshData();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void AllowOnlyNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }

        #endregion

        private void sbRefreshData_Click(object sender, EventArgs e)
        {
            this.RefreshData();
        }

        private void RefreshData()
        {
            try
            {
                var orderID = (long?)null;
                var orderType = (string)null;
                var warehouseID = (string)null;
                var supplierID = (int?)null;

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
                }

                if (!string.IsNullOrEmpty(stbOrderType.Value))
                {
                    orderType = stbOrderType.Value;
                    allowReloadData = true;
                }

                if (!string.IsNullOrEmpty(stbWarehouse.Value))
                {
                    warehouseID = stbWarehouse.Value;
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
                }

                #endregion

                if (!allowReloadData)
                    throw new Exception("Хотя бы один критерий поиска должен быть задан.");

                var bw = new BackgroundWorker();

                bw.DoWork += delegate(object sender, DoWorkEventArgs e)
                {
                    try
                    {
                        pr_AE_Get_Main_HeaderTableAdapter.SetTimeout((int)TimeSpan.FromMinutes(3).TotalSeconds);
                        e.Result = pr_AE_Get_Main_HeaderTableAdapter.GetData(this.UserID, warehouseID, orderID, supplierID, orderType);
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };

                bw.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
                {
                    if (e.Result is Exception)
                        this.ShowError(e.Result as Exception);
                    else
                        receive.pr_AE_Get_Main_Header.Merge(e.Result as DataTable);

                    waitProgressForm.CloseForce();
                };

                receive.pr_AE_Get_Main_Header.Clear();

                waitProgressForm.ActionText = "Выполняется загрузка данных..";
                bw.RunWorkerAsync();
                waitProgressForm.ShowDialog();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            sbProcessOrder.Enabled = dgvOrders.SelectedRows.Count > 0;
        }

        private void dgvOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            ProcessOrder();
        }

        private void sbProcessOrder_Click(object sender, EventArgs e)
        {
            ProcessOrder();
        }

        private void ProcessOrder()
        {
            var dr = (dgvOrders.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.Receive.pr_AE_Get_Main_HeaderRow;
            var orderNumber = Convert.ToInt64(dr.order_number);
            var orderType = dr.order_type;

            var dlgImposeAdditionalExpensesEditForm = new ImposeAdditionalExpensesEditForm(orderNumber, orderType) { UserID = this.UserID };
            if (dlgImposeAdditionalExpensesEditForm.ShowDialog() == DialogResult.OK)
                this.RefreshData();
        }

        private void dgvOrders_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grid = sender as DataGridView;

            var boundRow = (grid.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as DataRow;
            var color = Color.FromName(boundRow["color"].ToString());

            grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionBackColor = color;
            grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = color;
        }
    }
}
