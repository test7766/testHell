using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Quality
{
    public partial class ImportLicenseRequestCreateItemForm : DialogForm
    {
        private readonly int _requestID;
        private readonly Data.Quality.QK_LI_LicRequest_DetailsRow _item = null;

        public ImportLicenseRequestCreateItemForm()
        {
            InitializeComponent();
        }

        public ImportLicenseRequestCreateItemForm(int requestID, Data.Quality.QK_LI_LicRequest_DetailsRow item)
            : this()
        {
            _requestID = requestID;
            _item = item;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Initialize();

            this.btnOK.Location = new Point(312, 8);
            this.btnCancel.Location = new Point(402, 8);
        }

        private void Initialize()
        {
            quality.QK_LI_LicRequest_Details.LoadDataRow(_item.ItemArray, true);

            var operationType = _item.IsOperationTypeNull() ? (bool?)null : _item.OperationType;
            var itemExists = _item.ItemID > 0;

            tbItemID.BackColor = itemExists ? (operationType.HasValue ? (operationType.Value ? Color.LightBlue : Color.LightPink) : SystemColors.Window) : Color.LightGray;

            if (!itemExists)
                tbItemID.ForeColor = tbItemID.BackColor;

            tbItemName.Focus();
            tbItemName.SelectionStart = tbItemName.SelectionLength = 0;
        }

        private void ImportLicenseRequestCreateItemForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveData();
        }

        private bool SaveData()
        {
            try
            {
                var item = quality.QK_LI_LicRequest_Details[0];

                if (string.IsNullOrEmpty(item.IsItemNameNull() ? (string)null : item.ItemName))
                    throw new Exception("Наименование товара не должно быть пустым.");

                if (string.IsNullOrEmpty(item.IsReleaseFormNull() ? (string)null : item.ReleaseForm))
                    throw new Exception("Форма выпуска не должна быть пустой.");

                if (string.IsNullOrEmpty(item.IsDosageNull() ? (string)null : item.Dosage))
                    throw new Exception("Дозировка не должна быть пустой.");

                if (string.IsNullOrEmpty(item.IsQtyPackNull() ? (string)null : item.QtyPack))
                    throw new Exception("Количество в упаковке не должно быть пустым.");


                if (string.IsNullOrEmpty(item.IsManufacturerNull() ? (string)null : item.Manufacturer))
                    throw new Exception("Производитель не должен быть пустым.");

                if (string.IsNullOrEmpty(item.IsManufacturerCountryNull() ? (string)null : item.ManufacturerCountry))
                    throw new Exception("Страна производителя не должна быть пустой.");

                if (string.IsNullOrEmpty(item.IsVendorNull() ? (string)null : item.Vendor))
                    throw new Exception("Поставщик не должен быть пустым.");

                if (string.IsNullOrEmpty(item.IsVendorCountryNull() ? (string)null : item.VendorCountry))
                    throw new Exception("Страна поставщика не должна быть пустой.");

                if (string.IsNullOrEmpty(item.IsVendorAddressNull() ? (string)null : item.VendorAddress))
                    throw new Exception("Адрес поставщика не должен быть пустым.");


                using (var adapter = new Data.QualityTableAdapters.QK_LI_LicRequestsTableAdapter())
                    adapter.AddItem(this.UserID, _requestID, item.ItemID, item.ItemName, item.ReleaseForm, item.Dosage, item.QtyPack, item.Manufacturer, item.ManufacturerCountry, item.Vendor, item.VendorCountry, item.VendorAddress);

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
