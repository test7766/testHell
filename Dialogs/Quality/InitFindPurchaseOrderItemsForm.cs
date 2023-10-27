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
    public partial class InitFindPurchaseOrderItemsForm : DialogForm
    {
        #region ПОЛЯ И СВОЙСТВА ДАННЫХ

        public new long UserID { get; set; }

        private readonly PurchaseOrderItemsBlockParameters purchaseOrderItemsBlockParameters = null;

        public BlockActionType ActionType { get; set; }

        #endregion

        #region КОНСТРУКТОРЫ

        public InitFindPurchaseOrderItemsForm(PurchaseOrderItemsBlockParameters pPurchaseOrderItemsBlockParameters)
            : this()
        {
            purchaseOrderItemsBlockParameters = pPurchaseOrderItemsBlockParameters;
        }

        public InitFindPurchaseOrderItemsForm()
        {
            InitializeComponent();
        }

        #endregion

        private void InitFindPurchaseOrderItemsForm_Load(object sender, EventArgs e)
        {
            stbWarehouse.ValueReferenceQuery = "[dbo].[pr_BL_Get_MCU]";
            stbBlockType.ValueReferenceQuery = "[dbo].[pr_BL_Get_HoldTypes_For_Search]";

            stbWarehouse.UserID = this.UserID;
            stbBlockType.UserID = this.UserID;

            stbWarehouse.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stb_OnVerifyValue);
            stbBlockType.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stb_OnVerifyValue);

            tbOrderID.Text = purchaseOrderItemsBlockParameters.OrderID.ToString();
            stbWarehouse.SetValueByDefault(purchaseOrderItemsBlockParameters.WarehouseID);
        }

        void stb_OnVerifyValue(object sender, WMSOffice.Controls.VerifyValueArgs e)
        {
            var control = sender as SearchTextBox;
            TextBox tbDescription = null;

            if (control == stbWarehouse)
                tbDescription = lblWarehouseName;
            else if (control == stbBlockType)
                tbDescription = lblBlockTypeName;

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

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            btnOK.Location = new Point(424, 8);
            btnCancel.Location = new Point(514, 8);

            switch (this.ActionType)
            {
                case BlockActionType.CreateBlock:
                    cbBlockType.CheckState = CheckState.Checked;
                    cbDateFrom.CheckState = CheckState.Checked;
                    cbBlockAllWarehouses.CheckState = CheckState.Checked;
                    break;
                case BlockActionType.FinishBlock:
                    cbBlockType.CheckState = CheckState.Checked;

                    cbDateFrom.CheckState = CheckState.Indeterminate;
                    cbDateFrom.Enabled = false;

                    cbDateTo.CheckState = CheckState.Checked;

                    cbNewVendorLot.CheckState = CheckState.Indeterminate;
                    cbNewVendorLot.Enabled = false;

                    cbNewItem.CheckState = CheckState.Indeterminate;
                    cbNewItem.Enabled = false;

                    cbBlockAllWarehouses.CheckState = CheckState.Indeterminate;
                    cbBlockAllWarehouses.Enabled = false;
                    break;
                default:
                    break;
            }

            gbInitParameters.Focus();
        }

        private void cbBlockType_CheckStateChanged(object sender, EventArgs e)
        {
            var isEnabled = cbBlockType.CheckState == CheckState.Checked;

            stbBlockType.ReadOnly = !isEnabled;
            stbBlockType.BackColor = isEnabled ? SystemColors.Window : SystemColors.Control;

            lblBlockTypeName.BackColor = isEnabled ? SystemColors.Window : SystemColors.Control;
        }

        private void cbDateFrom_CheckStateChanged(object sender, EventArgs e)
        {
            var isEnabled = cbDateFrom.CheckState == CheckState.Checked;
            dtpDateFrom.Enabled = isEnabled;
        }

        private void cbDateTo_CheckStateChanged(object sender, EventArgs e)
        {
            var isEnabled = cbDateTo.CheckState == CheckState.Checked;
            dtpDateTo.Enabled = isEnabled;
        }

        private void cbNewVendorLot_CheckStateChanged(object sender, EventArgs e)
        {
            var isEnabled = cbNewVendorLot.CheckState == CheckState.Checked;
            cbNewVendorLotValue.Enabled = isEnabled;
        }

        private void cbNewItem_CheckStateChanged(object sender, EventArgs e)
        {
            var isEnabled = cbNewItem.CheckState == CheckState.Checked;
            cbNewItemValue.Enabled = isEnabled;
        }

        private void InitFindPurchaseOrderItemsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.InitPurchaseOrderItemsBlockParameters();
        }

        private bool InitPurchaseOrderItemsBlockParameters()
        {
            try
            {
                if (cbBlockType.CheckState == CheckState.Checked)
                    purchaseOrderItemsBlockParameters.BlockTypeID = string.IsNullOrEmpty(stbBlockType.Value) ? (string)null : stbBlockType.Value;

                if (cbDateFrom.CheckState == CheckState.Checked)
                    purchaseOrderItemsBlockParameters.DateFrom = dtpDateFrom.Value;

                if (cbDateTo.CheckState == CheckState.Checked)
                    purchaseOrderItemsBlockParameters.DateTo = dtpDateTo.Value;

                if (cbNewVendorLot.CheckState == CheckState.Checked)
                    purchaseOrderItemsBlockParameters.IsNewVendorLot = cbNewVendorLotValue.Checked;

                if (cbNewItem.CheckState == CheckState.Checked)
                    purchaseOrderItemsBlockParameters.IsNewItem = cbNewItemValue.Checked;

                purchaseOrderItemsBlockParameters.BlockAllWarehouses = cbBlockAllWarehouses.CheckState == CheckState.Checked ? true : cbBlockAllWarehouses.CheckState == CheckState.Unchecked ? false : (bool?)null;

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
