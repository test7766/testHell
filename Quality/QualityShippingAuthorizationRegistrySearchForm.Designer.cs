namespace WMSOffice.Dialogs.Quality
{
    partial class QualityShippingAuthorizationRegistrySearchForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            this.cbBranch = new System.Windows.Forms.CheckBox();
            this.cmbProvisor = new System.Windows.Forms.ComboBox();
            this.aPGetProvisorsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quality = new WMSOffice.Data.Quality();
            this.cbProvisor = new System.Windows.Forms.CheckBox();
            this.lblWorksheetDateCreateFrom = new System.Windows.Forms.Label();
            this.lblWorksheetDateCreateTo = new System.Windows.Forms.Label();
            this.dtpWorksheetDateCreateTo = new System.Windows.Forms.DateTimePicker();
            this.cbWorksheetDateCreate = new System.Windows.Forms.CheckBox();
            this.tbRouteListNumber = new System.Windows.Forms.TextBox();
            this.cbRouteListNumber = new System.Windows.Forms.CheckBox();
            this.dtpWorksheetDateCreateFrom = new System.Windows.Forms.DateTimePicker();
            this.aP_Get_ProvisorsTableAdapter = new WMSOffice.Data.QualityTableAdapters.AP_Get_ProvisorsTableAdapter();
            this.qKSABranchesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qK_SA_BranchesTableAdapter = new WMSOffice.Data.QualityTableAdapters.QK_SA_BranchesTableAdapter();
            this.pnlButtons.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aPGetProvisorsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qKSABranchesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(137, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(227, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 208);
            this.pnlButtons.Size = new System.Drawing.Size(334, 43);
            this.pnlButtons.TabIndex = 1;
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContent.Controls.Add(this.cmbBranch);
            this.pnlContent.Controls.Add(this.cbBranch);
            this.pnlContent.Controls.Add(this.cmbProvisor);
            this.pnlContent.Controls.Add(this.cbProvisor);
            this.pnlContent.Controls.Add(this.lblWorksheetDateCreateFrom);
            this.pnlContent.Controls.Add(this.lblWorksheetDateCreateTo);
            this.pnlContent.Controls.Add(this.dtpWorksheetDateCreateTo);
            this.pnlContent.Controls.Add(this.cbWorksheetDateCreate);
            this.pnlContent.Controls.Add(this.tbRouteListNumber);
            this.pnlContent.Controls.Add(this.cbRouteListNumber);
            this.pnlContent.Controls.Add(this.dtpWorksheetDateCreateFrom);
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(334, 202);
            this.pnlContent.TabIndex = 0;
            // 
            // cmbBranch
            // 
            this.cmbBranch.DataSource = this.qKSABranchesBindingSource;
            this.cmbBranch.DisplayMember = "Branch_Name";
            this.cmbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBranch.Enabled = false;
            this.cmbBranch.FormattingEnabled = true;
            this.cmbBranch.Location = new System.Drawing.Point(120, 166);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.Size = new System.Drawing.Size(202, 21);
            this.cmbBranch.TabIndex = 10;
            this.cmbBranch.ValueMember = "Branch_ID";
            // 
            // cbBranch
            // 
            this.cbBranch.AutoSize = true;
            this.cbBranch.Location = new System.Drawing.Point(12, 168);
            this.cbBranch.Name = "cbBranch";
            this.cbBranch.Size = new System.Drawing.Size(67, 17);
            this.cbBranch.TabIndex = 9;
            this.cbBranch.Text = "Филиал";
            this.cbBranch.UseVisualStyleBackColor = true;
            this.cbBranch.CheckedChanged += new System.EventHandler(this.cbParameter_CheckedChanged);
            // 
            // cmbProvisor
            // 
            this.cmbProvisor.DataSource = this.aPGetProvisorsBindingSource;
            this.cmbProvisor.DisplayMember = "User_FIO";
            this.cmbProvisor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProvisor.Enabled = false;
            this.cmbProvisor.FormattingEnabled = true;
            this.cmbProvisor.Location = new System.Drawing.Point(120, 125);
            this.cmbProvisor.Name = "cmbProvisor";
            this.cmbProvisor.Size = new System.Drawing.Size(202, 21);
            this.cmbProvisor.TabIndex = 8;
            this.cmbProvisor.ValueMember = "User_ID";
            // 
            // aPGetProvisorsBindingSource
            // 
            this.aPGetProvisorsBindingSource.DataMember = "AP_Get_Provisors";
            this.aPGetProvisorsBindingSource.DataSource = this.quality;
            // 
            // quality
            // 
            this.quality.DataSetName = "Quality";
            this.quality.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cbProvisor
            // 
            this.cbProvisor.AutoSize = true;
            this.cbProvisor.Location = new System.Drawing.Point(12, 127);
            this.cbProvisor.Name = "cbProvisor";
            this.cbProvisor.Size = new System.Drawing.Size(76, 17);
            this.cbProvisor.TabIndex = 7;
            this.cbProvisor.Text = "Фармацевт";
            this.cbProvisor.UseVisualStyleBackColor = true;
            this.cbProvisor.CheckedChanged += new System.EventHandler(this.cbParameter_CheckedChanged);
            // 
            // lblWorksheetDateCreateFrom
            // 
            this.lblWorksheetDateCreateFrom.AutoSize = true;
            this.lblWorksheetDateCreateFrom.Location = new System.Drawing.Point(193, 57);
            this.lblWorksheetDateCreateFrom.Name = "lblWorksheetDateCreateFrom";
            this.lblWorksheetDateCreateFrom.Size = new System.Drawing.Size(13, 13);
            this.lblWorksheetDateCreateFrom.TabIndex = 3;
            this.lblWorksheetDateCreateFrom.Text = "с";
            // 
            // lblWorksheetDateCreateTo
            // 
            this.lblWorksheetDateCreateTo.AutoSize = true;
            this.lblWorksheetDateCreateTo.Location = new System.Drawing.Point(187, 85);
            this.lblWorksheetDateCreateTo.Name = "lblWorksheetDateCreateTo";
            this.lblWorksheetDateCreateTo.Size = new System.Drawing.Size(19, 13);
            this.lblWorksheetDateCreateTo.TabIndex = 5;
            this.lblWorksheetDateCreateTo.Text = "по";
            // 
            // dtpWorksheetDateCreateTo
            // 
            this.dtpWorksheetDateCreateTo.Checked = false;
            this.dtpWorksheetDateCreateTo.Enabled = false;
            this.dtpWorksheetDateCreateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpWorksheetDateCreateTo.Location = new System.Drawing.Point(212, 81);
            this.dtpWorksheetDateCreateTo.Name = "dtpWorksheetDateCreateTo";
            this.dtpWorksheetDateCreateTo.ShowCheckBox = true;
            this.dtpWorksheetDateCreateTo.Size = new System.Drawing.Size(110, 20);
            this.dtpWorksheetDateCreateTo.TabIndex = 6;
            // 
            // cbWorksheetDateCreate
            // 
            this.cbWorksheetDateCreate.AutoSize = true;
            this.cbWorksheetDateCreate.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cbWorksheetDateCreate.Location = new System.Drawing.Point(12, 53);
            this.cbWorksheetDateCreate.Name = "cbWorksheetDateCreate";
            this.cbWorksheetDateCreate.Size = new System.Drawing.Size(106, 30);
            this.cbWorksheetDateCreate.TabIndex = 2;
            this.cbWorksheetDateCreate.Text = "Дата создания \r\nанкеты";
            this.cbWorksheetDateCreate.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cbWorksheetDateCreate.UseVisualStyleBackColor = true;
            this.cbWorksheetDateCreate.CheckedChanged += new System.EventHandler(this.cbParameter_CheckedChanged);
            // 
            // tbRouteListNumber
            // 
            this.tbRouteListNumber.Enabled = false;
            this.tbRouteListNumber.Location = new System.Drawing.Point(212, 9);
            this.tbRouteListNumber.Name = "tbRouteListNumber";
            this.tbRouteListNumber.Size = new System.Drawing.Size(110, 20);
            this.tbRouteListNumber.TabIndex = 1;
            // 
            // cbRouteListNumber
            // 
            this.cbRouteListNumber.AutoSize = true;
            this.cbRouteListNumber.Location = new System.Drawing.Point(12, 12);
            this.cbRouteListNumber.Name = "cbRouteListNumber";
            this.cbRouteListNumber.Size = new System.Drawing.Size(80, 17);
            this.cbRouteListNumber.TabIndex = 0;
            this.cbRouteListNumber.Text = "Номер МЛ";
            this.cbRouteListNumber.UseVisualStyleBackColor = true;
            this.cbRouteListNumber.CheckedChanged += new System.EventHandler(this.cbParameter_CheckedChanged);
            // 
            // dtpWorksheetDateCreateFrom
            // 
            this.dtpWorksheetDateCreateFrom.Checked = false;
            this.dtpWorksheetDateCreateFrom.Enabled = false;
            this.dtpWorksheetDateCreateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpWorksheetDateCreateFrom.Location = new System.Drawing.Point(212, 53);
            this.dtpWorksheetDateCreateFrom.Name = "dtpWorksheetDateCreateFrom";
            this.dtpWorksheetDateCreateFrom.ShowCheckBox = true;
            this.dtpWorksheetDateCreateFrom.Size = new System.Drawing.Size(110, 20);
            this.dtpWorksheetDateCreateFrom.TabIndex = 4;
            // 
            // aP_Get_ProvisorsTableAdapter
            // 
            this.aP_Get_ProvisorsTableAdapter.ClearBeforeFill = true;
            // 
            // qKSABranchesBindingSource
            // 
            this.qKSABranchesBindingSource.DataMember = "QK_SA_Branches";
            this.qKSABranchesBindingSource.DataSource = this.quality;
            // 
            // qK_SA_BranchesTableAdapter
            // 
            this.qK_SA_BranchesTableAdapter.ClearBeforeFill = true;
            // 
            // QualityShippingAuthorizationRegistrySearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 251);
            this.Controls.Add(this.pnlContent);
            this.Name = "QualityShippingAuthorizationRegistrySearchForm";
            this.Text = "Критерии формирования реестра контроля условий";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QualityShippingAuthorizationRegistrySearchForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aPGetProvisorsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qKSABranchesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.ComboBox cmbProvisor;
        private System.Windows.Forms.CheckBox cbProvisor;
        private System.Windows.Forms.Label lblWorksheetDateCreateFrom;
        private System.Windows.Forms.Label lblWorksheetDateCreateTo;
        private System.Windows.Forms.DateTimePicker dtpWorksheetDateCreateTo;
        private System.Windows.Forms.CheckBox cbWorksheetDateCreate;
        private System.Windows.Forms.TextBox tbRouteListNumber;
        private System.Windows.Forms.CheckBox cbRouteListNumber;
        private System.Windows.Forms.DateTimePicker dtpWorksheetDateCreateFrom;
        private WMSOffice.Data.Quality quality;
        private System.Windows.Forms.BindingSource aPGetProvisorsBindingSource;
        private WMSOffice.Data.QualityTableAdapters.AP_Get_ProvisorsTableAdapter aP_Get_ProvisorsTableAdapter;
        private System.Windows.Forms.ComboBox cmbBranch;
        private System.Windows.Forms.CheckBox cbBranch;
        private System.Windows.Forms.BindingSource qKSABranchesBindingSource;
        private WMSOffice.Data.QualityTableAdapters.QK_SA_BranchesTableAdapter qK_SA_BranchesTableAdapter;
    }
}