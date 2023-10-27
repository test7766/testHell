using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls;
using WMSOffice.Window;

namespace WMSOffice.Dialogs.Docs
{
    public partial class ArchivedInvoicesRegisterCreateForm : DialogForm
    {
        public ArchiveInvoicesRegisterSearchParameters CreateParameters { get; private set; }

        public ArchivedInvoicesRegisterCreateForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(717, 8);
            this.btnCancel.Location = new Point(807, 8);

            this.Initialize();
        }

        private void Initialize()
        {
            stbDocType.ValueReferenceQuery = "[dbo].[pr_RG_Get_Register_Types_List]";
            stbDocType.UserID = this.UserID;
            stbDocType.OnVerifyValue += new VerifyValueHandler(stb_OnVerifyValue);

            stbDebtorFrom.ValueReferenceQuery = "[dbo].[pr_RG_Get_Debtors_List]";
            stbDebtorFrom.UserID = this.UserID;
            stbDebtorFrom.OnVerifyValue += new VerifyValueHandler(stb_OnVerifyValue);

            stbDebtorTo.ValueReferenceQuery = "[dbo].[pr_RG_Get_Debtors_List]";
            stbDebtorTo.UserID = this.UserID;
            stbDebtorTo.OnVerifyValue += new VerifyValueHandler(stb_OnVerifyValue);

            var today = DateTime.Today;
            dtpPeriodFrom.Value = today; // new DateTime(today.Year, today.Month, 1);
            dtpPeriodTo.Value = today;

            stbDocType.Focus();
        }

        void stb_OnVerifyValue(object sender, VerifyValueArgs e)
        {
            var control = sender as SearchTextBox;
            TextBox lblDescription = null;

            if (control == stbDocType)
                lblDescription = tbDocType;
            else if (control == stbDebtorFrom)
                lblDescription = tbDebtorFrom;
            else if (control == stbDebtorTo)
                lblDescription = tbDebtorTo;

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

        private void ArchivedInvoicesRegisterCreateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.ValidateParameters();
        }

        private bool ValidateParameters()
        {
            try
            {
                var createParams = new ArchiveInvoicesRegisterSearchParameters() { SessionID = this.UserID };

                if (string.IsNullOrEmpty(stbDocType.Value))
                    throw new Exception("Тип документа не вказано.");
                else
                {
                    int registerType;
                    if (!int.TryParse(stbDocType.Value, out registerType))
                        throw new Exception("Тип документа повинен бути числом.");
                    else
                        createParams.RegisterType = registerType;
                }

                if (string.IsNullOrEmpty(stbDebtorFrom.Value))
                    throw new Exception("Дебітор з не вказан.");
                else
                {
                    int debtorFrom;
                    if (!int.TryParse(stbDebtorFrom.Value, out debtorFrom))
                        throw new Exception("Дебітор з повинен бути числом.");
                    else
                        createParams.DebtorFrom = debtorFrom;
                }

                if (string.IsNullOrEmpty(stbDebtorTo.Value))
                    throw new Exception("Дебітор по не вказан.");
                else
                {
                    int debtorTo;
                    if (!int.TryParse(stbDebtorTo.Value, out debtorTo))
                        throw new Exception("Дебітор по повинен бути числом.");
                    else
                        createParams.DebtorTo = debtorTo;
                }

                var periodFrom = dtpPeriodFrom.Checked ? dtpPeriodFrom.Value.Date : (DateTime?)null;
                var periodTo = dtpPeriodTo.Checked ? dtpPeriodTo.Value.Date : (DateTime?)null;
                if (periodFrom.HasValue && periodTo.HasValue && periodFrom > periodTo)
                    throw new Exception("Початковий період не повинен перевищувати\nкінцевий.");

                createParams.PeriodFrom = periodFrom;
                createParams.PeriodTo = periodTo;

                this.CreateParameters = createParams;

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
