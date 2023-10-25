using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Window.QualityWnd
{
    public partial class QualityRegistrySearchForm : Form
    {
        public QualityRegistrySearchForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Binding binding = new Binding("Enabled", rbFind, "Checked") { DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged };
            panel1.DataBindings.Add(binding);

            binding = new Binding("Enabled", cbPeriod, "Checked") { DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged };
            panelPeriod.DataBindings.Add(binding);

            binding = new Binding("Enabled", cbBlock, "Checked") { DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged };
            panelBlock.DataBindings.Add(binding);

            binding = new Binding("Enabled", cbItem, "Checked") { DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged };
            panelItem.DataBindings.Add(binding);

            binding = new Binding("Enabled", cbManufacturer, "Checked") { DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged };
            panelManufacturer.DataBindings.Add(binding);

            binding = new Binding("Enabled", cbVendor, "Checked") { DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged };
            panelVendor.DataBindings.Add(binding);

            stbLot.UserID = UserID;
            stbItem.UserID = UserID;
            stbBlock.UserID = UserID;
            stbManuf.UserID = UserID;

            stbItem.ValueReferenceQuery = "[dbo].[pr_BL_DirItems]";
            stbLot.ValueReferenceQuery = "[dbo].[pr_BL_DirVendorLots]";

            stbBlock.ValueReferenceQuery = "[dbo].[pr_BL_DirHoldTypes]";
            stbBlock.ClearAdditionalParameters();
            stbBlock.ApplyAdditionalParameter(true);

            stbManuf.ValueReferenceQuery = "[dbo].[pr_BL_DirManufacturers]";
        }

        public long UserID { get; set; }

        public DateTime DateStart
        {
            get
            {
                return dtpStart.Value;
            }
        }

        public DateTime DateEnd
        {
            get
            {
                return dtpEnd.Value;
            }
        }

        public int? ItemID
        {
            get
            {
                int ret = int.MinValue;

                if (int.TryParse(stbItem.Value, out ret))
                    return ret;

                return null;
            }
        }

        public string VendorLot
        {
            get
            {
                return stbLot.Value;
            }
        }

        public int? Manufacturer
        {
            get
            {
                int ret = int.MinValue;

                if (int.TryParse(stbManuf.Value, out ret))
                    return ret;

                return null;
            }
        }

        public int? Vendor
        {
            get
            {
                int ret = int.MinValue;

                if (int.TryParse(tbVendor.Text, out ret))
                    return ret;

                return null;
            }
        }

        public string BlockType
        {
            get
            {
                return stbBlock.Value;
            }

        }

        //0 - отобразить все
        //1 - делаем поиск по периоду (диапазону дат)
        //2 - делаем поиск по коду товара и серии
        //3 - делаем поиск по типу блокировки
        //4 - делаем поиск по поставщику
        //5 - делаем поиск по производителю
        //6 - делаем поиск по нескольким параметрам
        public int SearchType
        {
            get
            {

                if (rbAll.Checked)
                    return 0;

                if (HasMany)
                    return 6;

                if (cbPeriod.Checked)
                    return 1;

                if (cbItem.Checked)
                    return 2;

                if (cbBlock.Checked)
                    return 3;

                if (cbVendor.Checked)
                    return 4;

                if (cbManufacturer.Checked)
                    return 5;

                return 0;
            }
        }

        private bool HasMany
        {
            get
            {
                int ret = 0;

                ret += cbBlock.Checked ? 1 : 0;
                ret += cbItem.Checked ? 1 : 0;
                ret += cbManufacturer.Checked ? 1 : 0;
                ret += cbPeriod.Checked ? 1 : 0;
                ret += cbVendor.Checked ? 1 : 0;

                return ret > 1;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            if (dtpStart.Value > dtpEnd.Value && cbPeriod.Checked)
            {
                MessageBox.Show("Конечная дата не может быть меньше начальной!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void stbItem_OnVerifyValue(object sender, WMSOffice.Controls.VerifyValueArgs e)
        {
            tbItem.Text = String.Empty;
            stbLot.ClearAdditionalParameters(); 
            
            if (!e.Success)
                return;

            tbItem.Text = e.Description;
            stbItem.Value = e.Value;
            
            stbLot.ApplyAdditionalParameter(e.Value);
        }

        private void stbBlock_OnVerifyValue(object sender, WMSOffice.Controls.VerifyValueArgs e)
        {
            tbBlock.Text = String.Empty;
            if (!e.Success)
                return;
            tbBlock.Text = e.Description;
            stbBlock.Value = e.Value;
        }

        private void stbManuf_OnVerifyValue(object sender, WMSOffice.Controls.VerifyValueArgs e)
        {
            tbManufacturer.Text = String.Empty;
            if (!e.Success)
                return;
            tbManufacturer.Text = e.Description;
            stbManuf.Value = e.Value;
        }

        private void stbLot_OnVerifyValue(object sender, WMSOffice.Controls.VerifyValueArgs e)
        {
            stbLot.Value = e.Success ? e.Value : String.Empty;
        }
    }
}
