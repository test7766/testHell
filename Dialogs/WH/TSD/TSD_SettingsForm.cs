using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls;

namespace WMSOffice.Dialogs.WH.TSD
{
    public partial class TSD_SettingsForm : DialogForm
    {
        public TSD_SettingsForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(173, 8);
            this.btnCancel.Location = new Point(263, 8);

            this.Initialize();
        }

        private void Initialize()
        {
            try
            {
                stbTSD.ValueReferenceQuery = "[dbo].[pr_TC_TSD_List]";
                stbTSD.UserID = this.UserID;
                stbTSD.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stbTSD_OnVerifyValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void stbTSD_OnVerifyValue(object sender, WMSOffice.Controls.VerifyValueArgs e)
        {
            var control = sender as SearchTextBox;
            TextBox tbDescription = null;

            if (control == stbTSD)
                tbDescription = tbTSD;

            if (tbDescription != null)
            {
                tbDescription.Text = e.Success ? e.Description : "ЗНАЧЕНИЕ НЕ НАЙДЕНО!";
                tbDescription.ForeColor = e.Success ? SystemColors.ControlText : Color.Red;

                if (e.Success)
                    control.Value = e.Value;
                //else
                //    control.Value = string.Empty;

                tbInventoryNumber.Text = e.Success ? e.OwnedRow["Инв.№"].ToString() : string.Empty;
            }
        }

        private void TSD_SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.CheckData();
        }

        private bool CheckData()
        {
            try
            {
                if (string.IsNullOrEmpty(stbTSD.Value))
                    throw new Exception("Не выбран ТСД.");

                if (string.IsNullOrEmpty(stbTSD.Value))
                    throw new Exception("Не указан Инв. №.");

                var terminalID = stbTSD.Value;
                var inventoryNumber = tbInventoryNumber.Text.Trim();

                using (var adapter = new Data.TSDTableAdapters.TSDAccountingItemsTableAdapter())
                    adapter.EditInventoryNumber(this.UserID, terminalID, inventoryNumber);

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
