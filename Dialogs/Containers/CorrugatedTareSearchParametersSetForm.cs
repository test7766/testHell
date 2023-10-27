using System;
using System.Collections.Generic;
using System.Text;
using WMSOffice.Controls;
using System.Windows.Forms;
using System.Drawing;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Window;

namespace WMSOffice.Dialogs.Containers
{
    public partial class CorrugatedTareSearchParametersSetForm : DialogForm
    {
        public static CorrugatedTareBalanceSearchParameters SearchParameters { get; set; }

        static CorrugatedTareSearchParametersSetForm()
        {
            SearchParameters = new CorrugatedTareBalanceSearchParameters { PeriodFrom = DateTime.Today.AddDays(-7).Date, PeriodTo = DateTime.Today.Date };
        }

        public CorrugatedTareSearchParametersSetForm()
        {
            this.InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Initialize();

            btnOK.Location = new System.Drawing.Point(367, 8);
            btnCancel.Location = new System.Drawing.Point(457, 8);
        }

        private void Initialize()
        {
            stbWarehouse.ValueReferenceQuery = "[dbo].[pr_GF_Get_Warehouse_List]";
            stbWarehouse.UserID = this.UserID;
            stbWarehouse.OnVerifyValue += (s, e) =>
            {
                var control = s as SearchTextBox;
                TextBox tbDescription = null;

                if (control == stbWarehouse)
                    tbDescription = tbWarehouse;

                if (tbDescription != null)
                {
                    tbDescription.Text = e.Success ? e.Description : "ЗНАЧЕНИЕ НЕ НАЙДЕНО!";
                    tbDescription.ForeColor = e.Success ? SystemColors.ControlText : Color.Red;

                    if (e.Success)
                        control.Value = e.Value;
                    //else
                    //    control.Value = string.Empty;
                }
            };

            if (string.IsNullOrEmpty(SearchParameters.WarehouseID))
                stbWarehouse.SetFirstValueByDefault();
            else
                stbWarehouse.SetValueByDefault(SearchParameters.WarehouseID);

            dtpPeriodFrom.Value = (SearchParameters.PeriodFrom ?? DateTime.Today).Date;
            dtpPeriodTo.Value = (SearchParameters.PeriodTo ?? DateTime.Today).Date;
        }

        private void CorrugatedTareSearchParametersSetForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveData();
        }

        private bool SaveData()
        {
            try
            {
                if (string.IsNullOrEmpty(stbWarehouse.Value))
                    throw new Exception("Не выбран склад.");

                if (dtpPeriodFrom.Value.Date > dtpPeriodTo.Value.Date)
                    throw new Exception("Период \"с\" не должен превышать период \"по\".");

                SearchParameters.WarehouseID = stbWarehouse.Value;
                SearchParameters.PeriodFrom = dtpPeriodFrom.Value.Date;
                SearchParameters.PeriodTo = dtpPeriodTo.Value.Date;

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
