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
    public partial class QualityGLSActFindItemForm : DialogForm
    {
        public int? DocID { get; set; }

        public int? ItemID { get; private set; }

        public string LotNumber { get; private set; }

        public DateTime? ExpireDate { get; private set; }

        public QualityGLSActFindItemForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Initialize();

            this.btnOK.Location = new Point(377, 8);
            this.btnCancel.Location = new Point(467, 8);
        }

        private void Initialize()
        {
            this.Text = string.Format("{0} № {1}", this.Text, this.DocID);

            stbItemID.ValueReferenceQuery = "[dbo].[pr_WH_Wizard_Get_Item_List]";
            stbItemID.UserID = this.UserID;
            stbItemID.OnVerifyValue += this.OnVerifyValue;
            stbItemID.Enter += new EventHandler(stbItemID_Enter);

            tbsItemBarcode.TextChanged += new EventHandler(tbsItemBarcode_TextChanged);

            tbLotNumber.KeyDown += new KeyEventHandler(tbLotNumber_KeyDown);

            tbsItemBarcode.Focus();
        }

        private void OnVerifyValue(object sender, WMSOffice.Controls.VerifyValueArgs e)
        {
            var control = sender as SearchTextBox;

            if (e.Success)
                control.Value = e.Value;

            if (control == stbItemID)
            {
                itemMeasurementHeaderControl.UpdateItemID(e.Success ? control.Value : (string)null);
                itemMeasurementHeaderControl.UpdateItemName(e.Success ? e.Description : "ЗНАЧЕНИЕ НЕ НАЙДЕНО!");

                itemMeasurementHeaderControl.UpdateManufacturerName(e.Success ? (control.Value != null ? e.OwnedRow["MANUFACTURER"].ToString() : string.Empty) : string.Empty);
                itemMeasurementHeaderControl.UpdateSupplierName(e.Success ? (control.Value != null ? e.OwnedRow["SUPPLIER"].ToString() : string.Empty) : string.Empty);

                if (e.Success && !string.IsNullOrEmpty(e.Value))
                {
                    tbLotNumber.Clear();
                    tbLotNumber.Focus();
                }

                return;
            }
        }

        void stbItemID_Enter(object sender, EventArgs e)
        {
            stbItemID.ApplyAdditionalParameter(tbsItemBarcode.Name, tbsItemBarcode.Text);
        }

        private void tbsItemBarcode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbsItemBarcode.Text))
            {
                stbItemID.ApplyAdditionalParameter(tbsItemBarcode.Name, tbsItemBarcode.Text);
                stbItemID.VerifyValue(true, AutoSelectItemSideMode.None);
            }
        }

        private void tbLotNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.DialogResult = DialogResult.OK;
        }

        private void QualityGLSFindItemForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.CheckItem();
        }

        private bool CheckItem()
        {
            try
            {
                int itemID;

                if (!int.TryParse(stbItemID.Value, out itemID))
                    throw new Exception("Необходимо выбрать товар.");

                var lotNumber = tbLotNumber.Text;

                using (var adapter = new Data.QualityTableAdapters.GA_Doc_DetailsTableAdapter())
                    adapter.CheckItem(itemID, lotNumber, this.DocID);

                var expireDate = dtpExpireDate.Checked ? dtpExpireDate.Value.Date : (DateTime?)null;

                this.ItemID = itemID;
                this.LotNumber = lotNumber;
                this.ExpireDate = expireDate;

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
