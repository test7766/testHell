using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls;

namespace WMSOffice.Dialogs.PickControl
{
    public partial class DebtorsReturnedTareAddDublicateDocDetailForm : DialogForm
    {
        public long DocID { get; set; }

        public long DocDetailID { get; set; }

        public DebtorsReturnedTareAddDublicateDocDetailForm()
        {
            InitializeComponent();
        }

        private void DebtorsReturnedTareAddDublicateDocDetailForm_Load(object sender, EventArgs e)
        {
            this.Initialize();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(97, 8);
            this.btnCancel.Location = new Point(187, 8);
        }

        private void Initialize()
        {
            stbClient.ValueReferenceQuery = "[dbo].[pr_DBL_RET_Get_Debtors]";
            stbClient.UserID = this.UserID;
            stbClient.OnVerifyValue += new VerifyValueHandler(stb_OnVerifyValue);
        }

        void stb_OnVerifyValue(object sender, VerifyValueArgs e)
        {
            var control = sender as SearchTextBox;
            Label lblDescription = null;

            if (control == stbClient)
                lblDescription = lblClientName;

            if (lblDescription != null)
            {
                lblDescription.Text = e.Success ? e.Description : "ЗНАЧЕНИЕ НЕ НАЙДЕНО!";
                lblDescription.ForeColor = e.Success ? SystemColors.ControlText : Color.Red;

                if (e.Success)
                {
                    control.Value = e.Value;

                    if (!string.IsNullOrEmpty(e.Value))
                        this.SelectNextControl(control, true, true, true, false);
                }
                //else
                //    control.Value = string.Empty;
            }
        }

        private void tbControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.SelectNextControl(sender as Control, true, true, true, false);
        }

        private void DebtorsReturnedTareAddDublicateDocDetailForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveData();
        }

        private bool SaveData()
        {
            try
            {
                var reason = (string)null;
                var driver = (string)null;
                var clientID = (int?)null;

                // 0. Валидация
                if (string.IsNullOrEmpty(tbReason.Text.Trim()))
                    throw new Exception("Укажите причину.");

                reason = tbReason.Text.Trim();

                if (!string.IsNullOrEmpty(tbDriver.Text))
                    driver = tbDriver.Text;

                if (!string.IsNullOrEmpty(stbClient.Value))
                {
                    int parsedClientID;
                    if (!int.TryParse(stbClient.Value, out parsedClientID))
                        throw new Exception("Код клиента должен быть числом.");

                    clientID = parsedClientID;
                }


                // 1. Создание позиции документа
                var docDetailObject = (object)null;

                using (var adapter = new Data.PickControlTableAdapters.DBL_RET_DocDetailsTableAdapter())
                    docDetailObject = adapter.CreateDocDetail(this.UserID, this.DocID, reason, driver, clientID);

                if (docDetailObject == null)
                    throw new Exception("Позиция документа не была создана.");

                this.DocDetailID = Convert.ToInt64(docDetailObject);

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
