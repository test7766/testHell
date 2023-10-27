namespace WMSOffice.Dialogs.Quality
{
    partial class QualityInputControlBranchWorksheetSearchForm
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
            this.lblFilialToName = new System.Windows.Forms.Label();
            this.stbFilialToID = new WMSOffice.Controls.SearchTextBox();
            this.cbFilialTo = new System.Windows.Forms.CheckBox();
            this.lblFilialFromName = new System.Windows.Forms.Label();
            this.stbFilialFromID = new WMSOffice.Controls.SearchTextBox();
            this.gbWorksheetStatuses = new System.Windows.Forms.GroupBox();
            this.cbStatusAccepted = new System.Windows.Forms.CheckBox();
            this.cbStatusNew = new System.Windows.Forms.CheckBox();
            this.cbStatusNotAccepted = new System.Windows.Forms.CheckBox();
            this.cbStatusInWork = new System.Windows.Forms.CheckBox();
            this.cmbProvisor = new System.Windows.Forms.ComboBox();
            this.aPGetProvisorsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quality = new WMSOffice.Data.Quality();
            this.cbProvisor = new System.Windows.Forms.CheckBox();
            this.lblWorksheetDateCreateFrom = new System.Windows.Forms.Label();
            this.lblWorksheetDateCreateTo = new System.Windows.Forms.Label();
            this.dtpWorksheetDateCreateTo = new System.Windows.Forms.DateTimePicker();
            this.cbWorksheetDateCreate = new System.Windows.Forms.CheckBox();
            this.tbDriverName = new System.Windows.Forms.TextBox();
            this.cbDriverName = new System.Windows.Forms.CheckBox();
            this.cbFilialFrom = new System.Windows.Forms.CheckBox();
            this.tbWorksheetNumber = new System.Windows.Forms.TextBox();
            this.cbWorksheetNumber = new System.Windows.Forms.CheckBox();
            this.tbRouteListNumber = new System.Windows.Forms.TextBox();
            this.cbRouteListNumber = new System.Windows.Forms.CheckBox();
            this.dtpWorksheetDateCreateFrom = new System.Windows.Forms.DateTimePicker();
            this.aP_Get_ProvisorsTableAdapter = new WMSOffice.Data.QualityTableAdapters.AP_Get_ProvisorsTableAdapter();
            this.pnlButtons.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.gbWorksheetStatuses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aPGetProvisorsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(-106, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(-25, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 438);
            this.pnlButtons.Size = new System.Drawing.Size(334, 43);
            this.pnlButtons.TabIndex = 1;
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContent.Controls.Add(this.lblFilialToName);
            this.pnlContent.Controls.Add(this.stbFilialToID);
            this.pnlContent.Controls.Add(this.cbFilialTo);
            this.pnlContent.Controls.Add(this.lblFilialFromName);
            this.pnlContent.Controls.Add(this.stbFilialFromID);
            this.pnlContent.Controls.Add(this.gbWorksheetStatuses);
            this.pnlContent.Controls.Add(this.cmbProvisor);
            this.pnlContent.Controls.Add(this.cbProvisor);
            this.pnlContent.Controls.Add(this.lblWorksheetDateCreateFrom);
            this.pnlContent.Controls.Add(this.lblWorksheetDateCreateTo);
            this.pnlContent.Controls.Add(this.dtpWorksheetDateCreateTo);
            this.pnlContent.Controls.Add(this.cbWorksheetDateCreate);
            this.pnlContent.Controls.Add(this.tbDriverName);
            this.pnlContent.Controls.Add(this.cbDriverName);
            this.pnlContent.Controls.Add(this.cbFilialFrom);
            this.pnlContent.Controls.Add(this.tbWorksheetNumber);
            this.pnlContent.Controls.Add(this.cbWorksheetNumber);
            this.pnlContent.Controls.Add(this.tbRouteListNumber);
            this.pnlContent.Controls.Add(this.cbRouteListNumber);
            this.pnlContent.Controls.Add(this.dtpWorksheetDateCreateFrom);
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(334, 432);
            this.pnlContent.TabIndex = 0;
            // 
            // lblFilialToName
            // 
            this.lblFilialToName.Location = new System.Drawing.Point(120, 175);
            this.lblFilialToName.Name = "lblFilialToName";
            this.lblFilialToName.Size = new System.Drawing.Size(202, 26);
            this.lblFilialToName.TabIndex = 9;
            // 
            // stbFilialToID
            // 
            this.stbFilialToID.Enabled = false;
            this.stbFilialToID.Location = new System.Drawing.Point(120, 147);
            this.stbFilialToID.Name = "stbFilialToID";
            this.stbFilialToID.NavigateByValue = false;
            this.stbFilialToID.ReadOnly = false;
            this.stbFilialToID.Size = new System.Drawing.Size(110, 20);
            this.stbFilialToID.TabIndex = 8;
            this.stbFilialToID.UserID = ((long)(0));
            this.stbFilialToID.Value = null;
            this.stbFilialToID.ValueReferenceQuery = null;
            // 
            // cbFilialTo
            // 
            this.cbFilialTo.AutoSize = true;
            this.cbFilialTo.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cbFilialTo.Location = new System.Drawing.Point(12, 147);
            this.cbFilialTo.Name = "cbFilialTo";
            this.cbFilialTo.Size = new System.Drawing.Size(89, 30);
            this.cbFilialTo.TabIndex = 7;
            this.cbFilialTo.Text = "Филиал \r\n(получатель)";
            this.cbFilialTo.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cbFilialTo.UseVisualStyleBackColor = true;
            this.cbFilialTo.CheckedChanged += new System.EventHandler(this.cbParameter_CheckedChanged);
            // 
            // lblFilialFromName
            // 
            this.lblFilialFromName.Location = new System.Drawing.Point(120, 113);
            this.lblFilialFromName.Name = "lblFilialFromName";
            this.lblFilialFromName.Size = new System.Drawing.Size(202, 26);
            this.lblFilialFromName.TabIndex = 6;
            // 
            // stbFilialFromID
            // 
            this.stbFilialFromID.Enabled = false;
            this.stbFilialFromID.Location = new System.Drawing.Point(120, 85);
            this.stbFilialFromID.Name = "stbFilialFromID";
            this.stbFilialFromID.NavigateByValue = false;
            this.stbFilialFromID.ReadOnly = false;
            this.stbFilialFromID.Size = new System.Drawing.Size(110, 20);
            this.stbFilialFromID.TabIndex = 5;
            this.stbFilialFromID.UserID = ((long)(0));
            this.stbFilialFromID.Value = null;
            this.stbFilialFromID.ValueReferenceQuery = null;
            // 
            // gbWorksheetStatuses
            // 
            this.gbWorksheetStatuses.Controls.Add(this.cbStatusAccepted);
            this.gbWorksheetStatuses.Controls.Add(this.cbStatusNew);
            this.gbWorksheetStatuses.Controls.Add(this.cbStatusNotAccepted);
            this.gbWorksheetStatuses.Controls.Add(this.cbStatusInWork);
            this.gbWorksheetStatuses.Location = new System.Drawing.Point(12, 344);
            this.gbWorksheetStatuses.Name = "gbWorksheetStatuses";
            this.gbWorksheetStatuses.Size = new System.Drawing.Size(310, 82);
            this.gbWorksheetStatuses.TabIndex = 19;
            this.gbWorksheetStatuses.TabStop = false;
            this.gbWorksheetStatuses.Text = "Статусы анкет";
            // 
            // cbStatusAccepted
            // 
            this.cbStatusAccepted.AutoSize = true;
            this.cbStatusAccepted.Location = new System.Drawing.Point(111, 28);
            this.cbStatusAccepted.Name = "cbStatusAccepted";
            this.cbStatusAccepted.Size = new System.Drawing.Size(122, 17);
            this.cbStatusAccepted.TabIndex = 2;
            this.cbStatusAccepted.Tag = "3";
            this.cbStatusAccepted.Text = "Пройдена успешно";
            this.cbStatusAccepted.UseVisualStyleBackColor = true;
            // 
            // cbStatusNew
            // 
            this.cbStatusNew.AutoSize = true;
            this.cbStatusNew.Location = new System.Drawing.Point(12, 28);
            this.cbStatusNew.Name = "cbStatusNew";
            this.cbStatusNew.Size = new System.Drawing.Size(58, 17);
            this.cbStatusNew.TabIndex = 0;
            this.cbStatusNew.Tag = "1";
            this.cbStatusNew.Text = "Новая";
            this.cbStatusNew.UseVisualStyleBackColor = true;
            // 
            // cbStatusNotAccepted
            // 
            this.cbStatusNotAccepted.AutoSize = true;
            this.cbStatusNotAccepted.Location = new System.Drawing.Point(111, 53);
            this.cbStatusNotAccepted.Name = "cbStatusNotAccepted";
            this.cbStatusNotAccepted.Size = new System.Drawing.Size(91, 17);
            this.cbStatusNotAccepted.TabIndex = 3;
            this.cbStatusNotAccepted.Tag = "4";
            this.cbStatusNotAccepted.Text = "Не пройдена";
            this.cbStatusNotAccepted.UseVisualStyleBackColor = true;
            // 
            // cbStatusInWork
            // 
            this.cbStatusInWork.AutoSize = true;
            this.cbStatusInWork.Location = new System.Drawing.Point(12, 53);
            this.cbStatusInWork.Name = "cbStatusInWork";
            this.cbStatusInWork.Size = new System.Drawing.Size(71, 17);
            this.cbStatusInWork.TabIndex = 1;
            this.cbStatusInWork.Tag = "2";
            this.cbStatusInWork.Text = "В работе";
            this.cbStatusInWork.UseVisualStyleBackColor = true;
            // 
            // cmbProvisor
            // 
            this.cmbProvisor.DataSource = this.aPGetProvisorsBindingSource;
            this.cmbProvisor.DisplayMember = "User_FIO";
            this.cmbProvisor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProvisor.Enabled = false;
            this.cmbProvisor.FormattingEnabled = true;
            this.cmbProvisor.Location = new System.Drawing.Point(120, 309);
            this.cmbProvisor.Name = "cmbProvisor";
            this.cmbProvisor.Size = new System.Drawing.Size(202, 21);
            this.cmbProvisor.TabIndex = 18;
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
            this.cbProvisor.Location = new System.Drawing.Point(12, 311);
            this.cbProvisor.Name = "cbProvisor";
            this.cbProvisor.Size = new System.Drawing.Size(86, 17);
            this.cbProvisor.TabIndex = 17;
            this.cbProvisor.Text = "Фармацевт";
            this.cbProvisor.UseVisualStyleBackColor = true;
            this.cbProvisor.CheckedChanged += new System.EventHandler(this.cbParameter_CheckedChanged);
            // 
            // lblWorksheetDateCreateFrom
            // 
            this.lblWorksheetDateCreateFrom.AutoSize = true;
            this.lblWorksheetDateCreateFrom.Location = new System.Drawing.Point(193, 249);
            this.lblWorksheetDateCreateFrom.Name = "lblWorksheetDateCreateFrom";
            this.lblWorksheetDateCreateFrom.Size = new System.Drawing.Size(13, 13);
            this.lblWorksheetDateCreateFrom.TabIndex = 13;
            this.lblWorksheetDateCreateFrom.Text = "с";
            // 
            // lblWorksheetDateCreateTo
            // 
            this.lblWorksheetDateCreateTo.AutoSize = true;
            this.lblWorksheetDateCreateTo.Location = new System.Drawing.Point(187, 277);
            this.lblWorksheetDateCreateTo.Name = "lblWorksheetDateCreateTo";
            this.lblWorksheetDateCreateTo.Size = new System.Drawing.Size(19, 13);
            this.lblWorksheetDateCreateTo.TabIndex = 15;
            this.lblWorksheetDateCreateTo.Text = "по";
            // 
            // dtpWorksheetDateCreateTo
            // 
            this.dtpWorksheetDateCreateTo.Checked = false;
            this.dtpWorksheetDateCreateTo.Enabled = false;
            this.dtpWorksheetDateCreateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpWorksheetDateCreateTo.Location = new System.Drawing.Point(212, 273);
            this.dtpWorksheetDateCreateTo.Name = "dtpWorksheetDateCreateTo";
            this.dtpWorksheetDateCreateTo.ShowCheckBox = true;
            this.dtpWorksheetDateCreateTo.Size = new System.Drawing.Size(110, 20);
            this.dtpWorksheetDateCreateTo.TabIndex = 16;
            // 
            // cbWorksheetDateCreate
            // 
            this.cbWorksheetDateCreate.AutoSize = true;
            this.cbWorksheetDateCreate.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cbWorksheetDateCreate.Location = new System.Drawing.Point(12, 245);
            this.cbWorksheetDateCreate.Name = "cbWorksheetDateCreate";
            this.cbWorksheetDateCreate.Size = new System.Drawing.Size(106, 30);
            this.cbWorksheetDateCreate.TabIndex = 12;
            this.cbWorksheetDateCreate.Text = "Дата создания \r\nанкеты";
            this.cbWorksheetDateCreate.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cbWorksheetDateCreate.UseVisualStyleBackColor = true;
            this.cbWorksheetDateCreate.CheckedChanged += new System.EventHandler(this.cbParameter_CheckedChanged);
            // 
            // tbDriverName
            // 
            this.tbDriverName.Enabled = false;
            this.tbDriverName.Location = new System.Drawing.Point(120, 209);
            this.tbDriverName.Name = "tbDriverName";
            this.tbDriverName.Size = new System.Drawing.Size(202, 20);
            this.tbDriverName.TabIndex = 11;
            // 
            // cbDriverName
            // 
            this.cbDriverName.AutoSize = true;
            this.cbDriverName.Location = new System.Drawing.Point(12, 211);
            this.cbDriverName.Name = "cbDriverName";
            this.cbDriverName.Size = new System.Drawing.Size(103, 17);
            this.cbDriverName.TabIndex = 10;
            this.cbDriverName.Text = "ФИО водителя";
            this.cbDriverName.UseVisualStyleBackColor = true;
            this.cbDriverName.CheckedChanged += new System.EventHandler(this.cbParameter_CheckedChanged);
            // 
            // cbFilialFrom
            // 
            this.cbFilialFrom.AutoSize = true;
            this.cbFilialFrom.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cbFilialFrom.Location = new System.Drawing.Point(12, 87);
            this.cbFilialFrom.Name = "cbFilialFrom";
            this.cbFilialFrom.Size = new System.Drawing.Size(96, 30);
            this.cbFilialFrom.TabIndex = 4;
            this.cbFilialFrom.Text = "Филиал \r\n(отправитель)";
            this.cbFilialFrom.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cbFilialFrom.UseVisualStyleBackColor = true;
            this.cbFilialFrom.CheckedChanged += new System.EventHandler(this.cbParameter_CheckedChanged);
            // 
            // tbWorksheetNumber
            // 
            this.tbWorksheetNumber.Enabled = false;
            this.tbWorksheetNumber.Location = new System.Drawing.Point(120, 48);
            this.tbWorksheetNumber.Name = "tbWorksheetNumber";
            this.tbWorksheetNumber.Size = new System.Drawing.Size(110, 20);
            this.tbWorksheetNumber.TabIndex = 3;
            // 
            // cbWorksheetNumber
            // 
            this.cbWorksheetNumber.AutoSize = true;
            this.cbWorksheetNumber.Location = new System.Drawing.Point(12, 50);
            this.cbWorksheetNumber.Name = "cbWorksheetNumber";
            this.cbWorksheetNumber.Size = new System.Drawing.Size(100, 17);
            this.cbWorksheetNumber.TabIndex = 2;
            this.cbWorksheetNumber.Text = "Номер анкеты";
            this.cbWorksheetNumber.UseVisualStyleBackColor = true;
            this.cbWorksheetNumber.CheckedChanged += new System.EventHandler(this.cbParameter_CheckedChanged);
            // 
            // tbRouteListNumber
            // 
            this.tbRouteListNumber.Enabled = false;
            this.tbRouteListNumber.Location = new System.Drawing.Point(120, 10);
            this.tbRouteListNumber.Name = "tbRouteListNumber";
            this.tbRouteListNumber.Size = new System.Drawing.Size(110, 20);
            this.tbRouteListNumber.TabIndex = 1;
            // 
            // cbRouteListNumber
            // 
            this.cbRouteListNumber.AutoSize = true;
            this.cbRouteListNumber.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cbRouteListNumber.Location = new System.Drawing.Point(12, 12);
            this.cbRouteListNumber.Name = "cbRouteListNumber";
            this.cbRouteListNumber.Size = new System.Drawing.Size(84, 30);
            this.cbRouteListNumber.TabIndex = 0;
            this.cbRouteListNumber.Text = "Номер МЛ\r\n(межсклад)";
            this.cbRouteListNumber.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cbRouteListNumber.UseVisualStyleBackColor = true;
            this.cbRouteListNumber.CheckedChanged += new System.EventHandler(this.cbParameter_CheckedChanged);
            // 
            // dtpWorksheetDateCreateFrom
            // 
            this.dtpWorksheetDateCreateFrom.Checked = false;
            this.dtpWorksheetDateCreateFrom.Enabled = false;
            this.dtpWorksheetDateCreateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpWorksheetDateCreateFrom.Location = new System.Drawing.Point(212, 245);
            this.dtpWorksheetDateCreateFrom.Name = "dtpWorksheetDateCreateFrom";
            this.dtpWorksheetDateCreateFrom.ShowCheckBox = true;
            this.dtpWorksheetDateCreateFrom.Size = new System.Drawing.Size(110, 20);
            this.dtpWorksheetDateCreateFrom.TabIndex = 14;
            // 
            // aP_Get_ProvisorsTableAdapter
            // 
            this.aP_Get_ProvisorsTableAdapter.ClearBeforeFill = true;
            // 
            // QualityInputControlBranchWorksheetSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 481);
            this.Controls.Add(this.pnlContent);
            this.Name = "QualityInputControlBranchWorksheetSearchForm";
            this.Text = "Параметры поиска анкет входного контроля МС";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QualityShippingAuthorizationWorksheetSearchForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.gbWorksheetStatuses.ResumeLayout(false);
            this.gbWorksheetStatuses.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aPGetProvisorsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.DateTimePicker dtpWorksheetDateCreateFrom;
        private System.Windows.Forms.TextBox tbRouteListNumber;
        private System.Windows.Forms.CheckBox cbRouteListNumber;
        private System.Windows.Forms.Label lblWorksheetDateCreateFrom;
        private System.Windows.Forms.Label lblWorksheetDateCreateTo;
        private System.Windows.Forms.DateTimePicker dtpWorksheetDateCreateTo;
        private System.Windows.Forms.CheckBox cbWorksheetDateCreate;
        private System.Windows.Forms.TextBox tbDriverName;
        private System.Windows.Forms.CheckBox cbDriverName;
        private System.Windows.Forms.CheckBox cbFilialFrom;
        private System.Windows.Forms.TextBox tbWorksheetNumber;
        private System.Windows.Forms.CheckBox cbWorksheetNumber;
        private System.Windows.Forms.GroupBox gbWorksheetStatuses;
        private System.Windows.Forms.CheckBox cbStatusAccepted;
        private System.Windows.Forms.CheckBox cbStatusNew;
        private System.Windows.Forms.CheckBox cbStatusNotAccepted;
        private System.Windows.Forms.CheckBox cbStatusInWork;
        private System.Windows.Forms.ComboBox cmbProvisor;
        private System.Windows.Forms.CheckBox cbProvisor;
        private WMSOffice.Controls.SearchTextBox stbFilialFromID;
        private System.Windows.Forms.Label lblFilialFromName;
        private WMSOffice.Data.Quality quality;
        private System.Windows.Forms.BindingSource aPGetProvisorsBindingSource;
        private WMSOffice.Data.QualityTableAdapters.AP_Get_ProvisorsTableAdapter aP_Get_ProvisorsTableAdapter;
        private System.Windows.Forms.Label lblFilialToName;
        private WMSOffice.Controls.SearchTextBox stbFilialToID;
        private System.Windows.Forms.CheckBox cbFilialTo;
    }
}