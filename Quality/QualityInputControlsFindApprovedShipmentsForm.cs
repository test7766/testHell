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
    public partial class QualityInputControlsFindApprovedShipmentsForm : DialogForm
    {
        public DateTime? PeriodFrom { get; set; }
        public DateTime? PeriodTo { get; set; }
        public int? WarehouseID { get; set; }

        public QualityInputControlsFindApprovedShipmentsForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(235, 8);
            this.btnCancel.Location = new Point(325, 8);

            this.Initialize();
        }

        private void Initialize()
        {
            stbWarehouse.ValueReferenceQuery = "[dbo].[pr_AP_STB_Get_Warehouses]";
            stbWarehouse.UserID = this.UserID;
            stbWarehouse.OnVerifyValue += new VerifyValueHandler(stb_OnVerifyValue);

            stbWarehouse.SetFirstValueByDefault();
        }

        void stb_OnVerifyValue(object sender, VerifyValueArgs e)
        {
            var control = sender as SearchTextBox;
            TextBox lblDescription = null;

            if (control == stbWarehouse)
                lblDescription = tbWarehouse;

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

        private void dtpPeriodFrom_ValueChanged(object sender, EventArgs e)
        {
            dtpPeriodTo.Value = dtpPeriodFrom.Value;
        }

        private void QualityInputControlsFindApprovedShipmentsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.ApplyParameters();
        }

        private bool ApplyParameters()
        {

            try
            {
                if (!dtpPeriodFrom.Checked && !dtpPeriodTo.Checked)
                    throw new Exception("Период поиска должен быть указан.");

                if (dtpPeriodFrom.Checked && dtpPeriodTo.Checked)
                {
                    if (dtpPeriodFrom.Value.Date > dtpPeriodTo.Value.Date)
                        throw new Exception("Период С не должен превышать период ПО.");
                }

                int warehouseID = -1;
                if (!string.IsNullOrEmpty(stbWarehouse.Value))
                {
                    if (!int.TryParse(stbWarehouse.Value, out warehouseID))
                        throw new Exception("Код склада должен быть числом.");
                }


                this.PeriodFrom = dtpPeriodFrom.Checked ? dtpPeriodFrom.Value.Date : (DateTime?)null;
                this.PeriodTo = dtpPeriodTo.Checked ? dtpPeriodTo.Value.Date : (DateTime?)null;

                this.WarehouseID = warehouseID == -1 ? (int?)null : warehouseID;

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
