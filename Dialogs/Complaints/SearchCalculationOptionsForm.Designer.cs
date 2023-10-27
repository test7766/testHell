namespace WMSOffice.Dialogs.Complaints
{
    partial class SearchCalculationOptionsForm
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
            this.chkbDate = new System.Windows.Forms.CheckBox();
            this.gbDate = new System.Windows.Forms.GroupBox();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.chkbItemID = new System.Windows.Forms.CheckBox();
            this.chkbDocType = new System.Windows.Forms.CheckBox();
            this.gbItemID = new System.Windows.Forms.GroupBox();
            this.tbItemID = new System.Windows.Forms.TextBox();
            this.lblItemID = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.gbDocType = new System.Windows.Forms.GroupBox();
            this.tbDocType = new System.Windows.Forms.TextBox();
            this.lblDocType = new System.Windows.Forms.Label();
            this.cbComplaintTypes = new System.Windows.Forms.ComboBox();
            this.availableDocsTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.complaints = new WMSOffice.Data.Complaints();
            this.lblComplaintType = new System.Windows.Forms.Label();
            this.chkbSearchType = new System.Windows.Forms.CheckBox();
            this.gbSearchType = new System.Windows.Forms.GroupBox();
            this.chkbDocNumber = new System.Windows.Forms.CheckBox();
            this.tbDocNumber = new System.Windows.Forms.TextBox();
            this.lblSearchType = new System.Windows.Forms.Label();
            this.cbSearchType = new System.Windows.Forms.ComboBox();
            this.chkbItemName = new System.Windows.Forms.CheckBox();
            this.gbItemName = new System.Windows.Forms.GroupBox();
            this.tbItemName = new System.Windows.Forms.TextBox();
            this.lblItemName = new System.Windows.Forms.Label();
            this.availableDocsTypesTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.AvailableDocsTypesTableAdapter();
            this.gbDate.SuspendLayout();
            this.gbItemID.SuspendLayout();
            this.gbDocType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.availableDocsTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).BeginInit();
            this.gbSearchType.SuspendLayout();
            this.gbItemName.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkbDate
            // 
            this.chkbDate.AutoSize = true;
            this.chkbDate.Location = new System.Drawing.Point(20, 173);
            this.chkbDate.Name = "chkbDate";
            this.chkbDate.Size = new System.Drawing.Size(108, 17);
            this.chkbDate.TabIndex = 4;
            this.chkbDate.Text = "Дата претензии";
            this.chkbDate.UseVisualStyleBackColor = true;
            this.chkbDate.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // gbDate
            // 
            this.gbDate.Controls.Add(this.dtpDateTo);
            this.gbDate.Controls.Add(this.lblDateTo);
            this.gbDate.Controls.Add(this.dtpDateFrom);
            this.gbDate.Controls.Add(this.lblDateFrom);
            this.gbDate.Enabled = false;
            this.gbDate.Location = new System.Drawing.Point(12, 173);
            this.gbDate.Name = "gbDate";
            this.gbDate.Size = new System.Drawing.Size(325, 72);
            this.gbDate.TabIndex = 5;
            this.gbDate.TabStop = false;
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Location = new System.Drawing.Point(101, 44);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(161, 20);
            this.dtpDateTo.TabIndex = 1;
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Location = new System.Drawing.Point(10, 48);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(51, 13);
            this.lblDateTo.TabIndex = 4;
            this.lblDateTo.Text = "Дата по:";
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Location = new System.Drawing.Point(101, 18);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(161, 20);
            this.dtpDateFrom.TabIndex = 0;
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Location = new System.Drawing.Point(10, 22);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(45, 13);
            this.lblDateFrom.TabIndex = 2;
            this.lblDateFrom.Text = "Дата с:";
            // 
            // chkbItemID
            // 
            this.chkbItemID.AutoSize = true;
            this.chkbItemID.Location = new System.Drawing.Point(20, 251);
            this.chkbItemID.Name = "chkbItemID";
            this.chkbItemID.Size = new System.Drawing.Size(83, 17);
            this.chkbItemID.TabIndex = 6;
            this.chkbItemID.Text = "Код товара";
            this.chkbItemID.UseVisualStyleBackColor = true;
            this.chkbItemID.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // chkbDocType
            // 
            this.chkbDocType.AutoSize = true;
            this.chkbDocType.Location = new System.Drawing.Point(20, 91);
            this.chkbDocType.Name = "chkbDocType";
            this.chkbDocType.Size = new System.Drawing.Size(102, 17);
            this.chkbDocType.TabIndex = 2;
            this.chkbDocType.Text = "Тип документа";
            this.chkbDocType.UseVisualStyleBackColor = true;
            this.chkbDocType.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // gbItemID
            // 
            this.gbItemID.Controls.Add(this.tbItemID);
            this.gbItemID.Controls.Add(this.lblItemID);
            this.gbItemID.Enabled = false;
            this.gbItemID.Location = new System.Drawing.Point(12, 251);
            this.gbItemID.Name = "gbItemID";
            this.gbItemID.Size = new System.Drawing.Size(325, 47);
            this.gbItemID.TabIndex = 7;
            this.gbItemID.TabStop = false;
            // 
            // tbItemID
            // 
            this.tbItemID.Location = new System.Drawing.Point(101, 19);
            this.tbItemID.MaxLength = 6;
            this.tbItemID.Name = "tbItemID";
            this.tbItemID.Size = new System.Drawing.Size(86, 20);
            this.tbItemID.TabIndex = 0;
            this.tbItemID.Text = "0";
            // 
            // lblItemID
            // 
            this.lblItemID.AutoSize = true;
            this.lblItemID.Location = new System.Drawing.Point(10, 22);
            this.lblItemID.Name = "lblItemID";
            this.lblItemID.Size = new System.Drawing.Size(67, 13);
            this.lblItemID.TabIndex = 2;
            this.lblItemID.Text = "Код товара:";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(262, 359);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(181, 359);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // gbDocType
            // 
            this.gbDocType.Controls.Add(this.tbDocType);
            this.gbDocType.Controls.Add(this.lblDocType);
            this.gbDocType.Controls.Add(this.cbComplaintTypes);
            this.gbDocType.Controls.Add(this.lblComplaintType);
            this.gbDocType.Enabled = false;
            this.gbDocType.Location = new System.Drawing.Point(12, 93);
            this.gbDocType.Name = "gbDocType";
            this.gbDocType.Size = new System.Drawing.Size(325, 74);
            this.gbDocType.TabIndex = 3;
            this.gbDocType.TabStop = false;
            // 
            // tbDocType
            // 
            this.tbDocType.Location = new System.Drawing.Point(101, 45);
            this.tbDocType.MaxLength = 2;
            this.tbDocType.Name = "tbDocType";
            this.tbDocType.Size = new System.Drawing.Size(86, 20);
            this.tbDocType.TabIndex = 1;
            this.tbDocType.Text = "50";
            // 
            // lblDocType
            // 
            this.lblDocType.AutoSize = true;
            this.lblDocType.Location = new System.Drawing.Point(6, 48);
            this.lblDocType.Name = "lblDocType";
            this.lblDocType.Size = new System.Drawing.Size(53, 13);
            this.lblDocType.TabIndex = 7;
            this.lblDocType.Text = "Тип док.:";
            // 
            // cbComplaintTypes
            // 
            this.cbComplaintTypes.DataSource = this.availableDocsTypesBindingSource;
            this.cbComplaintTypes.DisplayMember = "Doc_Type_Name";
            this.cbComplaintTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbComplaintTypes.FormattingEnabled = true;
            this.cbComplaintTypes.Location = new System.Drawing.Point(101, 18);
            this.cbComplaintTypes.Name = "cbComplaintTypes";
            this.cbComplaintTypes.Size = new System.Drawing.Size(216, 21);
            this.cbComplaintTypes.TabIndex = 0;
            this.cbComplaintTypes.ValueMember = "Doc_Type";
            // 
            // availableDocsTypesBindingSource
            // 
            this.availableDocsTypesBindingSource.DataMember = "AvailableDocsTypes";
            this.availableDocsTypesBindingSource.DataSource = this.complaints;
            // 
            // complaints
            // 
            this.complaints.DataSetName = "Complaints";
            this.complaints.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblComplaintType
            // 
            this.lblComplaintType.AutoSize = true;
            this.lblComplaintType.Location = new System.Drawing.Point(5, 21);
            this.lblComplaintType.Name = "lblComplaintType";
            this.lblComplaintType.Size = new System.Drawing.Size(85, 13);
            this.lblComplaintType.TabIndex = 2;
            this.lblComplaintType.Text = "Тип претензии:";
            // 
            // chkbSearchType
            // 
            this.chkbSearchType.AutoSize = true;
            this.chkbSearchType.Checked = true;
            this.chkbSearchType.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbSearchType.Enabled = false;
            this.chkbSearchType.Location = new System.Drawing.Point(20, 10);
            this.chkbSearchType.Name = "chkbSearchType";
            this.chkbSearchType.Size = new System.Drawing.Size(179, 17);
            this.chkbSearchType.TabIndex = 0;
            this.chkbSearchType.Text = "Тип поиска, номер документа";
            this.chkbSearchType.UseVisualStyleBackColor = true;
            // 
            // gbSearchType
            // 
            this.gbSearchType.Controls.Add(this.chkbDocNumber);
            this.gbSearchType.Controls.Add(this.tbDocNumber);
            this.gbSearchType.Controls.Add(this.lblSearchType);
            this.gbSearchType.Controls.Add(this.cbSearchType);
            this.gbSearchType.Location = new System.Drawing.Point(12, 12);
            this.gbSearchType.Name = "gbSearchType";
            this.gbSearchType.Size = new System.Drawing.Size(325, 75);
            this.gbSearchType.TabIndex = 1;
            this.gbSearchType.TabStop = false;
            // 
            // chkbDocNumber
            // 
            this.chkbDocNumber.AutoSize = true;
            this.chkbDocNumber.Checked = true;
            this.chkbDocNumber.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbDocNumber.Location = new System.Drawing.Point(28, 46);
            this.chkbDocNumber.Name = "chkbDocNumber";
            this.chkbDocNumber.Size = new System.Drawing.Size(117, 17);
            this.chkbDocNumber.TabIndex = 1;
            this.chkbDocNumber.Text = "№ док. / код деб.:";
            this.chkbDocNumber.UseVisualStyleBackColor = true;
            // 
            // tbDocNumber
            // 
            this.tbDocNumber.Location = new System.Drawing.Point(159, 44);
            this.tbDocNumber.MaxLength = 12;
            this.tbDocNumber.Name = "tbDocNumber";
            this.tbDocNumber.Size = new System.Drawing.Size(86, 20);
            this.tbDocNumber.TabIndex = 2;
            // 
            // lblSearchType
            // 
            this.lblSearchType.AutoSize = true;
            this.lblSearchType.Location = new System.Drawing.Point(6, 22);
            this.lblSearchType.Name = "lblSearchType";
            this.lblSearchType.Size = new System.Drawing.Size(68, 13);
            this.lblSearchType.TabIndex = 4;
            this.lblSearchType.Text = "Тип поиска:";
            // 
            // cbSearchType
            // 
            this.cbSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearchType.FormattingEnabled = true;
            this.cbSearchType.Items.AddRange(new object[] {
            "№ претензии",
            "№ расчет-корректировки",
            "№ служебн. записки",
            "№ ориг. накладной",
            "Код адр. доставки / дебитора"});
            this.cbSearchType.Location = new System.Drawing.Point(101, 19);
            this.cbSearchType.Name = "cbSearchType";
            this.cbSearchType.Size = new System.Drawing.Size(216, 21);
            this.cbSearchType.TabIndex = 0;
            this.cbSearchType.SelectedIndexChanged += new System.EventHandler(this.cbSearchType_SelectedIndexChanged);
            // 
            // chkbItemName
            // 
            this.chkbItemName.AutoSize = true;
            this.chkbItemName.Location = new System.Drawing.Point(20, 304);
            this.chkbItemName.Name = "chkbItemName";
            this.chkbItemName.Size = new System.Drawing.Size(254, 17);
            this.chkbItemName.TabIndex = 8;
            this.chkbItemName.Text = "Наименование товара (часть наименования)";
            this.chkbItemName.UseVisualStyleBackColor = true;
            this.chkbItemName.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // gbItemName
            // 
            this.gbItemName.Controls.Add(this.tbItemName);
            this.gbItemName.Controls.Add(this.lblItemName);
            this.gbItemName.Enabled = false;
            this.gbItemName.Location = new System.Drawing.Point(12, 304);
            this.gbItemName.Name = "gbItemName";
            this.gbItemName.Size = new System.Drawing.Size(325, 47);
            this.gbItemName.TabIndex = 9;
            this.gbItemName.TabStop = false;
            // 
            // tbItemName
            // 
            this.tbItemName.Location = new System.Drawing.Point(101, 19);
            this.tbItemName.MaxLength = 50;
            this.tbItemName.Name = "tbItemName";
            this.tbItemName.Size = new System.Drawing.Size(216, 20);
            this.tbItemName.TabIndex = 0;
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Location = new System.Drawing.Point(10, 22);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(91, 13);
            this.lblItemName.TabIndex = 2;
            this.lblItemName.Text = "Наимен. товара:";
            // 
            // availableDocsTypesTableAdapter
            // 
            this.availableDocsTypesTableAdapter.ClearBeforeFill = true;
            // 
            // SearchCalculationOptionsForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(349, 394);
            this.Controls.Add(this.chkbItemName);
            this.Controls.Add(this.gbItemName);
            this.Controls.Add(this.chkbSearchType);
            this.Controls.Add(this.gbSearchType);
            this.Controls.Add(this.chkbDate);
            this.Controls.Add(this.gbDate);
            this.Controls.Add(this.chkbItemID);
            this.Controls.Add(this.chkbDocType);
            this.Controls.Add(this.gbItemID);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gbDocType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchCalculationOptionsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки поиска";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SearchCalculationOptionsForm_FormClosing);
            this.gbDate.ResumeLayout(false);
            this.gbDate.PerformLayout();
            this.gbItemID.ResumeLayout(false);
            this.gbItemID.PerformLayout();
            this.gbDocType.ResumeLayout(false);
            this.gbDocType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.availableDocsTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).EndInit();
            this.gbSearchType.ResumeLayout(false);
            this.gbSearchType.PerformLayout();
            this.gbItemName.ResumeLayout(false);
            this.gbItemName.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkbDate;
        private System.Windows.Forms.GroupBox gbDate;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.CheckBox chkbItemID;
        private System.Windows.Forms.CheckBox chkbDocType;
        private System.Windows.Forms.GroupBox gbItemID;
        private System.Windows.Forms.TextBox tbItemID;
        private System.Windows.Forms.Label lblItemID;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox gbDocType;
        private System.Windows.Forms.ComboBox cbComplaintTypes;
        private System.Windows.Forms.Label lblComplaintType;
        private System.Windows.Forms.CheckBox chkbSearchType;
        private System.Windows.Forms.GroupBox gbSearchType;
        private System.Windows.Forms.ComboBox cbSearchType;
        private System.Windows.Forms.TextBox tbDocType;
        private System.Windows.Forms.Label lblDocType;
        private System.Windows.Forms.TextBox tbDocNumber;
        private System.Windows.Forms.Label lblSearchType;
        private System.Windows.Forms.CheckBox chkbItemName;
        private System.Windows.Forms.GroupBox gbItemName;
        private System.Windows.Forms.TextBox tbItemName;
        private System.Windows.Forms.Label lblItemName;
        private WMSOffice.Data.Complaints complaints;
        private System.Windows.Forms.CheckBox chkbDocNumber;
        private System.Windows.Forms.BindingSource availableDocsTypesBindingSource;
        private WMSOffice.Data.ComplaintsTableAdapters.AvailableDocsTypesTableAdapter availableDocsTypesTableAdapter;
    }
}