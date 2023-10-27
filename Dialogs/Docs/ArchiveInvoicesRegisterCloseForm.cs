using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using WMSOffice.Controls;

namespace WMSOffice.Dialogs.Docs
{
    public partial class ArchiveInvoicesRegisterCloseForm : DialogForm
    {
        public DateTime? ClosePeriod { get; private set; }

        public string WarehouseCode { get; private set; }

        public ArchiveInvoicesRegisterCloseForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(117, 8);
            this.btnCancel.Location = new Point(207, 8);

            this.Initialize();
        }

        private void Initialize()
        {
            var today = DateTime.Today;
            cmbClosePeriodMonth.SelectedIndex = today.Month - 1;
            nudClosePeriod.Value = Convert.ToDecimal(today.Year);

            stbWarehouse.ValueReferenceQuery = "[dbo].[pr_AI_Get_MCU_List]";
            stbWarehouse.ApplyAdditionalParameter("CanSelectAllWarehouses", false);
            stbWarehouse.UserID = this.UserID;
            stbWarehouse.OnVerifyValue += new VerifyValueHandler(stb_OnVerifyValue);

            stbWarehouse.SetFirstValueByDefault();
        }

        void stb_OnVerifyValue(object sender, VerifyValueArgs e)
        {
            var control = sender as SearchTextBox;
            Label lblDescription = null;

            if (control == stbWarehouse)
                lblDescription = lblWarehouseName;

            if (lblDescription != null)
            {
                lblDescription.Text = e.Success ? e.Description : "ЗНАЧЕННЯ НЕ ЗНАЙДЕНО!";
                lblDescription.ForeColor = e.Success ? SystemColors.ControlText : Color.Red;

                if (e.Success)
                    control.Value = e.Value;
                //else
                //    control.Value = string.Empty;
            }
        }

        private void ArchiveInvoicesRegisterCloseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveData();
        }

        private bool SaveData()
        {

            try
            {
                var month = cmbClosePeriodMonth.SelectedIndex + 1;
                var year = Convert.ToInt32(nudClosePeriod.Value);

                this.ClosePeriod = new DateTime(year, month, 1);

                if (string.IsNullOrEmpty(stbWarehouse.Value))
                    throw new Exception("Філіал повинен бути вказаний.");
                else
                    this.WarehouseCode = stbWarehouse.Value;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
