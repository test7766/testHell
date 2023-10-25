using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs;
using WMSOffice.Controls;

namespace WMSOffice.Window.QualityWnd
{
    public partial class QualityRegistrySearchPrintDocForm : DialogForm
    {
        public static WMSOffice.Window.QualityWnd.QualityRegistryGLSWindow.RegistryNewGLSSearchParameters SearchParameter { get; private set; }

        //public DateTime PeriodFrom { get; private set; }
        //public DateTime PeriodTo { get; private set; }
        //public string WarehouseCode { get; private set; }

        public QualityRegistrySearchPrintDocForm()
        {
            InitializeComponent();
        }

        static QualityRegistrySearchPrintDocForm()
        {
            var today = DateTime.Today;
            SearchParameter = new QualityRegistryGLSWindow.RegistryNewGLSSearchParameters 
            {
                PeriodFrom = new DateTime(today.Year, today.Month, 1),
                PeriodTo = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month)),

                WarehouseCode = "       01LA1"
            };
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Initialize();

            btnOK.Location = new Point(172, 8);
            btnCancel.Location = new Point(262, 8);
        }

        private void Initialize()
        {
            //var today = DateTime.Today;
            //dtpPeriodFrom.Value = new DateTime(today.Year, today.Month, 1);
            //dtpPeriodTo.Value = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));

            stbWarehouse.ValueReferenceQuery = "[dbo].[pr_QB_Get_Warehouses]";
            stbWarehouse.UserID = this.UserID;
            stbWarehouse.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stbWarehouse_OnVerifyValue);

            if (SearchParameter.PeriodFrom.HasValue)
                dtpPeriodFrom.Value = SearchParameter.PeriodFrom.Value;

            if (SearchParameter.PeriodTo.HasValue)
                dtpPeriodTo.Value = SearchParameter.PeriodTo.Value;

            if (!string.IsNullOrEmpty(SearchParameter.WarehouseCode))
                stbWarehouse.SetValueByDefault(SearchParameter.WarehouseCode);
        }

        void stbWarehouse_OnVerifyValue(object sender, WMSOffice.Controls.VerifyValueArgs e)
        {
            var control = sender as SearchTextBox;
            Label lblDescription = null;

            if (control == stbWarehouse)
                lblDescription = lblWarehouseName;

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

        private void QualityRegistrySearchPrintDocForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.CreateFilter();
        }

        private bool CreateFilter()
        {
            try
            {
                if (dtpPeriodFrom.Value.Date > dtpPeriodTo.Value.Date)
                    throw new Exception("Начальный период не должен превышать конечный.");

                //if (string.IsNullOrEmpty(stbWarehouse.Value))
                //    throw new Exception("Не указан склад.");

                //this.PeriodFrom = dtpPeriodFrom.Value.Date;
                //this.PeriodTo = dtpPeriodTo.Value.Date;
                //this.WarehouseCode = stbWarehouse.Value;

                SearchParameter.PeriodFrom = dtpPeriodFrom.Value.Date;
                SearchParameter.PeriodTo = dtpPeriodTo.Value.Date;
                SearchParameter.WarehouseCode = stbWarehouse.Value;

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
