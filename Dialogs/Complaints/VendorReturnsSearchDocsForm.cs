using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Window;
using WMSOffice.Controls;

namespace WMSOffice.Dialogs.Complaints
{
    public partial class VendorReturnsSearchDocsForm : DialogForm
    {
        public VendorReturnsSearchParameters SearchCriteria { get; private set; }

        public VendorReturnsSearchDocsForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            btnOK.Location = new Point(317, 8);
            btnCancel.Location = new Point(407, 8);

            this.Initialize();
        }

        private void Initialize()
        {
            stbVendorID.ValueReferenceQuery = "[dbo].[pr_VR_Get_Vendors_List]";
            stbVendorID.UserID = this.UserID;
            stbVendorID.OnVerifyValue += new VerifyValueHandler(stb_OnVerifyValue);

            stbStatusID.ValueReferenceQuery = "[dbo].[pr_VR_Get_Statuses_List]";
            stbStatusID.UserID = this.UserID;
            stbStatusID.OnVerifyValue += new VerifyValueHandler(stb_OnVerifyValue);

            stbUserID.ValueReferenceQuery = "[dbo].[pr_VR_Get_Users_List]";
            stbUserID.UserID = this.UserID;
            stbUserID.OnVerifyValue += new VerifyValueHandler(stb_OnVerifyValue);
        }

        void stb_OnVerifyValue(object sender, VerifyValueArgs e)
        {
            var control = sender as SearchTextBox;
            TextBox lblDescription = null;

            if (control == stbVendorID)
                lblDescription = tbVendorName;
            else if (control == stbStatusID)
                lblDescription = tbStatusName;
            else if (control == stbUserID)
                lblDescription = tbUserName;

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

        private void VendorReturnsSearchDocsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SetCriteria();
        }

        private bool SetCriteria()
        {
            try
            {
                this.SearchCriteria = new VendorReturnsSearchParameters() { SessionID = this.UserID };

                long docID;
                if (!string.IsNullOrEmpty(tbDocID.Text))
                {
                    if (!long.TryParse(tbDocID.Text, out docID))
                        throw new Exception("№ документа должен быть числом.");
                    else
                        this.SearchCriteria.DocID = docID;
                }

                int vendorID;
                if (!string.IsNullOrEmpty(stbVendorID.Value))
                {
                    if (!int.TryParse(stbVendorID.Value, out vendorID))
                        throw new Exception("Код поставщика должен быть числом.");
                    else
                        this.SearchCriteria.VendorID = vendorID;
                }

                if (dtpPeriodFrom.Value.Date > dtpPeriodTo.Value.Date)
                    throw new Exception("Дата начала периода не должна превышать дату конца периода.");

                this.SearchCriteria.PeriodFrom = dtpPeriodFrom.Value.Date;
                this.SearchCriteria.PeriodTo = dtpPeriodTo.Value.Date;


                if (!string.IsNullOrEmpty(stbStatusID.Value))
                    this.SearchCriteria.StatusID = stbStatusID.Value;

                int userID;
                if (!string.IsNullOrEmpty(stbUserID.Value))
                {
                    if (!int.TryParse(stbUserID.Value, out userID))
                        throw new Exception("Код сотрудника должен быть числом.");
                    else
                        this.SearchCriteria.UserDocs = userID;
                }

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
