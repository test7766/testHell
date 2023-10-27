using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls;
using WMSOffice.Dialogs.Complaints;

namespace WMSOffice.Dialogs.PickControl
{
    public partial class DebtorsReturnedTareSetGuiltyEmployeeForm : DialogForm
    {
        public string TareBarCode { get; set; }

        public Data.PickControl.CT_Tare_Guilty_CategoriesRow SelectedGuiltyCategory { get { return cmbGuiltyCategory.SelectedItem == null ? null : (cmbGuiltyCategory.SelectedItem as DataRowView).Row as Data.PickControl.CT_Tare_Guilty_CategoriesRow; } }

        /// <summary>
        /// Файлы, прикрепленные к претензии
        /// </summary>
        private readonly List<Data.Complaints.AttachmentsRow> attachedFiles = new List<Data.Complaints.AttachmentsRow>();

        public DebtorsReturnedTareSetGuiltyEmployeeForm()
        {
            InitializeComponent();
        }

        private void DebtorsReturnedTareSetGuiltyEmployeeForm_Load(object sender, EventArgs e)
        {
            this.LoadGuiltyCategories();
        }

        private void LoadGuiltyCategories()
        {
            try
            {
                cT_Tare_Guilty_CategoriesTableAdapter.Fill(pickControl.CT_Tare_Guilty_Categories, this.UserID, this.TareBarCode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(267, 8);
            this.btnCancel.Location = new Point(357, 8);

            this.Initialize();
        }

        private void Initialize()
        {
            stbGuilty.ValueReferenceQuery = "[dbo].[pr_NTV_RET_Get_Group_Employees]";
            stbGuilty.UserID = this.UserID;

            stbGuilty.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stb_OnVerifyValue);
        }

        void stb_OnVerifyValue(object sender, WMSOffice.Controls.VerifyValueArgs e)
        {
            var control = sender as SearchTextBox;
            TextBox tbDescription = null;

            if (control == stbGuilty)
                tbDescription = tbGuilty;
           
            if (tbDescription != null)
            {
                tbDescription.Text = e.Success ? e.Description : "ЗНАЧЕНИЕ НЕ НАЙДЕНО!";
                tbDescription.ForeColor = e.Success ? SystemColors.ControlText : Color.Red;

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

        private void cmbGuiltyCategory_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbGuiltyCategory.SelectedValue != null)
                this.ChangeGuiltyCategory();
        }

        private void ChangeGuiltyCategory()
        {
            try
            {
                var isAttachEnabled = this.SelectedGuiltyCategory.NeedAttachment;
                var guiltyID = this.SelectedGuiltyCategory.UserID;

                stbGuilty.ClearAdditionalParameters();
                stbGuilty.TextEditor.Clear();
                tbGuilty.Text = string.Empty;
                tbGuilty.Enabled = false;
                stbGuilty.Enabled = guiltyID == 0;
                stbGuilty.ApplyAdditionalParameter(cmbGuiltyCategory.SelectedValue);

                if (isAttachEnabled)
                    stbGuilty.ApplyAdditionalParameter(guiltyID);

                if (guiltyID > 0)
                    stbGuilty.SetValueByDefault(this.SelectedGuiltyCategory.UserID.ToString());

                attachedFiles.Clear();
                btnAttachDocument.Enabled = isAttachEnabled;
                tbAttachedDocumentPath.Clear();
                tbAttachedDocumentPath.Enabled = false;

                this.SelectNextControl(cmbGuiltyCategory, true, true, true, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAttachDocument_Click(object sender, EventArgs e)
        {
            var window = new AttachmentsForm(attachedFiles) { Owner = this };
            window.AttachmentsFilter = "Изображения (*.bmp,*.jpg,*.jpeg,*.png,*.tif,*.tiff,*.gif)|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff;*.gif|Документы (*.pdf)|*.pdf";
            window.ShowDialog();

            attachedFiles.Clear();
            attachedFiles.AddRange(window.Files);

            tbAttachedDocumentPath.Clear();
            if (attachedFiles.Count > 0)
            {
                tbAttachedDocumentPath.Text = attachedFiles[0].File_Name;
                this.SelectNextControl(btnAttachDocument, true, true, true, false);
            }
        }

        private void DebtorsReturnedTareSetGuiltyEmployeeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveData();
        }

        private bool SaveData()
        {
            try
            {
                if (string.IsNullOrEmpty(stbGuilty.Value))
                    throw new Exception("Виновный должен быть указан.");

                if (string.IsNullOrEmpty(tbReason.Text))
                    throw new Exception("Причина должна быть указана.");

                if (this.SelectedGuiltyCategory.NeedAttachment && attachedFiles.Count == 0)
                    throw new Exception("Акт ОТ должен быть указан.");

                var reason = tbReason.Text;
                var guiltyID = Convert.ToInt32(stbGuilty.Value);
                var coDocID = (long?)null;

                // создаем претензию с виновным и причиной
                using (var adapter = new Data.PickControlTableAdapters.CT_Tare_InfoTableAdapter())
                    adapter.SetIlliquidTare(this.TareBarCode, reason, this.UserID, guiltyID, ref coDocID);

                // добавляем вложение к претензии
                if (coDocID.HasValue)
                {
                    using (var adapter = new Data.ComplaintsTableAdapters.DocAttachmentsTableAdapter())
                    {
                        adapter.SetTimeout((int)TimeSpan.FromMinutes(2).TotalSeconds);
                        foreach (var file in attachedFiles)
                            adapter.AddDocAttachment(coDocID, file.File_Name, file.Description, file.File_Data, this.UserID, file.Document_Number, file.Document_Date, file.IsDescriptionTypeNull() ? (string)null : file.DescriptionType, file.IsDocument_AmountNull() ? (double?)null : file.Document_Amount, file.IsIS_Vendor_PayerNull() ? (bool?)null : file.IS_Vendor_Payer);
                    }
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
