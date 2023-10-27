using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls;

namespace WMSOffice.Dialogs.Containers
{
    public partial class DebtorsReturnedTareSetExceptionForm : DialogForm
    {
        public DebtorsReturnedTareSetExceptionForm()
        {
            InitializeComponent();
        }

        private void DebtorsReturnedTareSetExceptionForm_Load(object sender, EventArgs e)
        {
            this.Initialize();
        }

        private void Initialize()
        {
            stbDeliveryID.ValueReferenceQuery = "[dbo].[pr_Ret_tare_client_Search]";
            stbDeliveryID.UserID = this.UserID;
            stbDeliveryID.OnVerifyValue += new VerifyValueHandler(stb_OnVerifyValue);
        }

        void stb_OnVerifyValue(object sender, VerifyValueArgs e)
        {
            var control = sender as SearchTextBox;
            TextBox lblDescription = null;

            if (control == stbDeliveryID)
                lblDescription = tbDebtorName;

            if (lblDescription != null)
            {
                lblDescription.Text = e.Success ? e.Description : "ЗНАЧЕНИЕ НЕ НАЙДЕНО!";
                lblDescription.ForeColor = e.Success ? SystemColors.ControlText : Color.Red;

                tbDeliveryAddress.Clear();

                if (e.Success)
                {
                    control.Value = e.Value;
                    tbDeliveryAddress.Text = e.OwnedRow != null ? e.OwnedRow["Client_address"].ToString() : string.Empty;
                }
                //else
                //    control.Value = string.Empty;
            }
        }
        
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(537, 8);
            this.btnCancel.Location = new Point(627, 8);
        }

        private void DebtorsReturnedTareSetExceptionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveData();
        }

        private bool SaveData()
        {
            try
            {
                var deliveryID = (int?)null;
                var orderID = (int?)null;
                var description = (string)null;

                if (string.IsNullOrEmpty(stbDeliveryID.Value))
                    throw new Exception("Не указан код ТТ.");
                else
                {
                    int parsedDeliveryID;
                    if (!int.TryParse(stbDeliveryID.Value, out parsedDeliveryID))
                        throw new Exception("Код ТТ должен быть числом.");
                    else
                        deliveryID = parsedDeliveryID;
                }


                if (string.IsNullOrEmpty(tbOrderNumber.Text.Trim()))
                    throw new Exception("Не указан № заказа.");
                else
                {
                    int parsedOrderID;
                    if (!int.TryParse(tbOrderNumber.Text, out parsedOrderID))
                        throw new Exception("№ заказа должен быть числом.");
                    else
                        orderID = parsedOrderID;
                }


                if (string.IsNullOrEmpty(tbDescription.Text.Trim()))
                    throw new Exception("Не указан комментарий.");
                else
                {
                    description = tbDescription.Text.Trim();
                    description = description.Substring(0, Math.Min(description.Length, 255));
                }


                using (var adapter = new Data.PickControlTableAdapters.QueriesTableAdapter())
                    adapter.SetClientTareException(orderID, deliveryID, this.UserID, description);

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
