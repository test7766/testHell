using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls;

namespace WMSOffice.Dialogs.WH
{
    public partial class RegradingDocumentEditorForm : DialogForm
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        private readonly Data.WH.HD_DocsRow _document = null;

        public RegradingDocumentEditorForm()
        {
            InitializeComponent();
        }

        public RegradingDocumentEditorForm(Data.WH.HD_DocsRow document)
            : this()
        {
            _document = document;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(715, 8);
            this.btnCancel.Location = new Point(805, 8);

            this.Initialize();
        }

        private void Initialize()
        {
            stbDocType.ValueReferenceQuery = "[dbo].[pr_HD_GetDocTypes]";
            stbDocType.UserID = this.UserID;
            stbDocType.OnVerifyValue += new VerifyValueHandler(stb_OnVerifyValue);

            stbBranch.ValueReferenceQuery = "[dbo].[pr_HD_Get_Branches]";
            stbBranch.UserID = this.UserID;
            stbBranch.OnVerifyValue += new VerifyValueHandler(stb_OnVerifyValue);

            this.LoadData();
        }

        void stb_OnVerifyValue(object sender, VerifyValueArgs e)
        {
            var control = sender as SearchTextBox;
            TextBox lblDescription = null;

            if (control == stbDocType)
                lblDescription = tbDocType;
            else if (control == stbBranch)
                lblDescription = tbBranch;

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

        private void LoadData()
        {
            try
            {
                this.LoadHeaders();
                this.LoadDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadHeaders()
        {
            tbDocNumber.Text = _document.Document_Number.ToString();
            tbCompany.Text = _document.Doc_Company;
            stbDocType.SetValueByDefault(_document.Doc_Type);
            dtpDateGL.Value = _document.GL_Date;
            stbBranch.SetValueByDefault(_document.BranchPlant);
            tbBatchNumber.Text = _document.BatchNumber.ToString();
            dtpTransDate.Value = _document.Trans_Date;
            tbTransExplanation.Text = _document.Transaction_Explanation;
        }

        private void LoadDetails()
        {
            hD_DocDetailsTableAdapter.Fill(wH.HD_DocDetails, this.UserID, _document.Doc_Company, _document.Document_Number, _document.Doc_Type);
        }
    }
}
