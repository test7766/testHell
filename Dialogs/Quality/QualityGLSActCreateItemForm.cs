using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Quality
{
    public partial class QualityGLSActCreateItemForm : DialogForm
    {
        public int? _docID { get; set; }
        private readonly Data.Quality.GA_ItemsRow _item = null;

        public string ItemName { get; private set; }

        public string LotNumber { get; private set; }

        public string ManufacturerName { get; private set; }

        public string VendorName { get; private set; }

        public QualityGLSActCreateItemForm()
        {
            InitializeComponent();
        }

        public QualityGLSActCreateItemForm(int? docID, Data.Quality.GA_ItemsRow item)
            : this()
        {
            _docID = docID;
            _item = item;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Initialize();

            this.btnOK.Location = new Point(317, 8);
            this.btnCancel.Location = new Point(407, 8);
        }

        private void Initialize()
        {
            quality.GA_Items.LoadDataRow(_item.ItemArray, true);

            this.Text = string.Format("{0} № {1}", this.Text, _docID);
        }

        private void QualityGLSActCreateItemForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveData();
        }

        private bool SaveData()
        {
            try
            {
                var item = quality.GA_Items[0];

                if (string.IsNullOrEmpty(item.IsItemNameNull() ? (string)null : item.ItemName))
                    throw new Exception("Наименование товара не должно быть пустым.");

                if (string.IsNullOrEmpty(item.IsManufacturerNull() ? (string)null : item.Manufacturer))
                    throw new Exception("Производитель не должен быть пустым.");

                if (string.IsNullOrEmpty(item.IsCurrVendorNameNull() ? (string)null : item.CurrVendorName))
                    throw new Exception("Поставщик не должен быть пустым.");

                this.ItemName = item.IsItemNameNull() ? (string)null : item.ItemName;
                this.LotNumber = item.IsLotNumberNull() ? (string)null : item.LotNumber;
                this.ManufacturerName = item.IsManufacturerNull() ? (string)null : item.Manufacturer;
                this.VendorName = item.IsCurrVendorNameNull() ? (string)null : item.CurrVendorName;

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
