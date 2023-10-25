using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs;
using WMSOffice.Controls;

namespace WMSOffice.Dialogs.Quality
{
    public partial class QualityConsolidatedGLSRemainsNotificationSearchPrintDocForm : DialogForm
    {
        public static string WarehouseCode { get; private set; }

        public QualityConsolidatedGLSRemainsNotificationSearchPrintDocForm()
        {
            InitializeComponent();
        }

        static QualityConsolidatedGLSRemainsNotificationSearchPrintDocForm()
        {
            WarehouseCode = "       01LA1";
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
            stbWarehouse.ValueReferenceQuery = "[dbo].[pr_QB_Get_Warehouses]";
            stbWarehouse.UserID = this.UserID;
            stbWarehouse.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stbWarehouse_OnVerifyValue);

            if (!string.IsNullOrEmpty(WarehouseCode))
                stbWarehouse.SetValueByDefault(WarehouseCode);
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
                //if (string.IsNullOrEmpty(stbWarehouse.Value))
                //    throw new Exception("Не указан склад.");

                WarehouseCode = stbWarehouse.Value;

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
