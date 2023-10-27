using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls;
using System.Data.SqlClient;

namespace WMSOffice.Dialogs.WH.SD
{
    public partial class SalesDispatcherBringOnChargeForm : DialogForm
    {
        /// <summary>
        /// Код сессии
        /// </summary>
        public new long UserID { get; set; }

        /// <summary>
        /// Компания
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// Тип документа
        /// </summary>
        public string DocType { get; set; }

        /// <summary>
        /// Номер документа
        /// </summary>
        public long DocNumber { get; set; }

        /// <summary>
        /// Получатель
        /// </summary>
        public string DeliveryPerson { get; set; }

        /// <summary>
        /// Время ожидания выполнения запроса
        /// </summary>
        private const int DEFAULT_RESPONSE_TIMEOUT = 300;

        public SalesDispatcherBringOnChargeForm()
        {
            InitializeComponent();
        }

        public SalesDispatcherBringOnChargeForm(int workMode, long userID, string company, string docType, long docNumber, string deliveryPerson)
            :this()
        {
            this.UserID = userID;
            this.Company = company;
            this.DocType = docType;
            this.DocNumber = docNumber;
            this.DeliveryPerson = deliveryPerson;

            this.stbWarehouse.ValueReferenceQuery = "[dbo].[pr_DP_Get_MCU_List]";
            this.stbLocation.ValueReferenceQuery = "[dbo].[pr_DP_Get_Locn_List_TransferReceip]";
            this.stbLocation.AddReference(this.stbWarehouse, "Value");

            // Установка дополнительного параметра - режим работы
            this.stbWarehouse.ApplyAdditionalParameter(workMode);
            this.stbLocation.ApplyAdditionalParameter(workMode);

            this.stbLocation.AddReference(tbDocType, "Text");

            this.stbLocation.ApplyAdditionalParameter(this.DocNumber);
        }

        private void SalesDispatcherBringOnChargeForm_Load(object sender, EventArgs e)
        {
            this.stbWarehouse.UserID = this.UserID;
            this.stbLocation.UserID = this.UserID;
            this.stbWarehouse.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(SearchTextBox_OnVerifyValue);
            this.stbLocation.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(SearchTextBox_OnVerifyValue);
        }

        void SearchTextBox_OnVerifyValue(object sender, WMSOffice.Controls.VerifyValueArgs e)
        {
            var control = sender as SearchTextBox;
            Label lblDescription = null;

            if (control == stbWarehouse)
                lblDescription = lblWarehouse;
            else if (control == stbLocation)
                lblDescription = lblLocation;

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

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.btnOK.Location = new Point(258, 8);
            this.btnCancel.Location = new Point(348, 8);

            tbDocType.Text = this.DocType;
            tbDocNumber.Text = this.DocNumber.ToString();
            tbDeliveryPerson.Text = this.DeliveryPerson;

            dtRecieveDate.Value = DateTime.Today;
            tbDocType.Focus();  // КОСТЫЛЬ: не менять фокус, а то не будет работать привязка в SearchTextBox!!!!!
        }

        private void SalesDispatcherBringOnChargeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.ApplyBringOnChargeOperation();
        }

        private bool ApplyBringOnChargeOperation()
        {
            SqlConnection connection = null;
            try
            {
                //connection = new SqlConnection(Properties.Settings.Default.JDE_PROCConnectionString);
                {
                    using (SqlCommand command = new SqlCommand("[dbo].[pr_DP_ReceipTransfer]", (connection = new SqlConnection(Properties.Settings.Default.JDE_PROCConnectionString))))
                    {
                        command.CommandTimeout = DEFAULT_RESPONSE_TIMEOUT;
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@Session_ID", SqlDbType.BigInt) { Value = this.UserID });
                        command.Parameters.Add(new SqlParameter("@kcoo", SqlDbType.Char) { Value = this.Company });
                        command.Parameters.Add(new SqlParameter("@dcto", SqlDbType.Char) { Value = this.DocType });
                        command.Parameters.Add(new SqlParameter("@doco", SqlDbType.Float) { Value = this.DocNumber });
                        command.Parameters.Add(new SqlParameter("@TRDJ", SqlDbType.DateTime) { Value = this.dtRecieveDate.Value });
                        command.Parameters.Add(new SqlParameter("@MCU", SqlDbType.Char) { Value = this.stbWarehouse.Value });
                        command.Parameters.Add(new SqlParameter("@LOCN", SqlDbType.Char) { Value = this.stbLocation.Value });
                        command.Parameters.Add(new SqlParameter("@tref", SqlDbType.Char) { Value = this.tbComments.Text });

                        command.Connection.Open();
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}
