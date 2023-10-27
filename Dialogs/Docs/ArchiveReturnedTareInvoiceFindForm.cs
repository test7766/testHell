using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls;

namespace WMSOffice.Dialogs.Docs
{
    public partial class ArchiveReturnedTareInvoiceFindForm : DialogForm
    {
        /// <summary>
        /// Тип документа
        /// </summary>
        public string DocTypeID { get; set; }

        /// <summary>
        /// № документа
        /// </summary>
        public double? DocNumber { get; set; }

        public ArchiveReturnedTareInvoiceFindForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(317, 8);
            this.btnCancel.Location = new Point(407, 8);

            this.Initialize();
        }

        private void Initialize()
        {
            try
            {
                stbDocType.ValueReferenceQuery = "[dbo].[pr_AI_RET_Get_Doc_Types_List]";
                stbDocType.UserID = this.UserID;
                stbDocType.OnVerifyValue += new VerifyValueHandler(stb_OnVerifyValue);

                if (!string.IsNullOrEmpty(this.DocTypeID))
                    stbDocType.SetValueByDefault(this.DocTypeID);

                if (this.DocNumber.HasValue)
                    tbDocNumber.Text = this.DocNumber.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void stb_OnVerifyValue(object sender, VerifyValueArgs e)
        {
            var control = sender as SearchTextBox;
            TextBox lblDescription = null;

            if (control == stbDocType)
                lblDescription = tbDocTypeName;

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

        private void ArchiveInvoiceFindForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.VerifyData();
        }

        private bool VerifyData()
        {
            try
            {
                if (string.IsNullOrEmpty(stbDocType.Value))
                    throw new Exception("Тип документа должен быть указан.");
                else
                    this.DocTypeID = stbDocType.Value;

                if (string.IsNullOrEmpty(tbDocNumber.Text))
                    throw new Exception("№ документа должен быть указан.");
                else
                {
                    long parsedDocNumber;
                    if (!long.TryParse(tbDocNumber.Text, out parsedDocNumber))
                        throw new Exception("№ документа должен быть числом.");
                    else
                        this.DocNumber = parsedDocNumber;
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
