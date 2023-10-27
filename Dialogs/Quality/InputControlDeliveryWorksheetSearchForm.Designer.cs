namespace WMSOffice.Dialogs.Quality
{
    partial class InputControlDeliveryWorksheetSearchForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.chbOnlyActual = new System.Windows.Forms.CheckBox();
            this.gbDeliveryNumber = new System.Windows.Forms.GroupBox();
            this.tbxDeliveryNumber = new System.Windows.Forms.TextBox();
            this.chbDeliveryNumber = new System.Windows.Forms.CheckBox();
            this.grbOrderNumber = new System.Windows.Forms.GroupBox();
            this.tbxOrderNumber = new System.Windows.Forms.TextBox();
            this.chbOrderNumber = new System.Windows.Forms.CheckBox();
            this.grbVendor = new System.Windows.Forms.GroupBox();
            this.lblVendorName = new System.Windows.Forms.Label();
            this.stbVendor = new WMSOffice.Controls.SearchTextBox();
            this.chbVendor = new System.Windows.Forms.CheckBox();
            this.grbWorksheetDate = new System.Windows.Forms.GroupBox();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.chbWorksheetDate = new System.Windows.Forms.CheckBox();
            this.grbProvisor = new System.Windows.Forms.GroupBox();
            this.cmbProvisors = new System.Windows.Forms.ComboBox();
            this.bsApGetProvisors = new System.Windows.Forms.BindingSource(this.components);
            this.quality = new WMSOffice.Data.Quality();
            this.chbProvisor = new System.Windows.Forms.CheckBox();
            this.taApGetProvisors = new WMSOffice.Data.QualityTableAdapters.AP_Get_ProvisorsTableAdapter();
            this.grbStatuses = new System.Windows.Forms.GroupBox();
            this.chbIncludeWithSuspectedQuality = new System.Windows.Forms.CheckBox();
            this.chbIncludeNotAccepted = new System.Windows.Forms.CheckBox();
            this.chbIncludeAccepted = new System.Windows.Forms.CheckBox();
            this.chbIncludeInWork = new System.Windows.Forms.CheckBox();
            this.chbIncludeNew = new System.Windows.Forms.CheckBox();
            this.chbIncludeOnlyApproved = new System.Windows.Forms.CheckBox();
            this.gbDeliveryNumber.SuspendLayout();
            this.grbOrderNumber.SuspendLayout();
            this.grbVendor.SuspendLayout();
            this.grbWorksheetDate.SuspendLayout();
            this.grbProvisor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsApGetProvisors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            this.grbStatuses.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(345, 496);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 180;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(264, 496);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 170;
            this.btnOk.Text = "Поиск";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // chbOnlyActual
            // 
            this.chbOnlyActual.AutoSize = true;
            this.chbOnlyActual.Checked = true;
            this.chbOnlyActual.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbOnlyActual.Location = new System.Drawing.Point(18, 12);
            this.chbOnlyActual.Name = "chbOnlyActual";
            this.chbOnlyActual.Size = new System.Drawing.Size(222, 17);
            this.chbOnlyActual.TabIndex = 10;
            this.chbOnlyActual.Text = "Только актуальные версии документа";
            this.chbOnlyActual.UseVisualStyleBackColor = true;
            // 
            // gbDeliveryNumber
            // 
            this.gbDeliveryNumber.Controls.Add(this.tbxDeliveryNumber);
            this.gbDeliveryNumber.Controls.Add(this.chbDeliveryNumber);
            this.gbDeliveryNumber.Location = new System.Drawing.Point(12, 35);
            this.gbDeliveryNumber.Name = "gbDeliveryNumber";
            this.gbDeliveryNumber.Size = new System.Drawing.Size(409, 52);
            this.gbDeliveryNumber.TabIndex = 19;
            this.gbDeliveryNumber.TabStop = false;
            // 
            // tbxDeliveryNumber
            // 
            this.tbxDeliveryNumber.Location = new System.Drawing.Point(124, 16);
            this.tbxDeliveryNumber.Name = "tbxDeliveryNumber";
            this.tbxDeliveryNumber.Size = new System.Drawing.Size(98, 20);
            this.tbxDeliveryNumber.TabIndex = 30;
            // 
            // chbDeliveryNumber
            // 
            this.chbDeliveryNumber.AutoSize = true;
            this.chbDeliveryNumber.Location = new System.Drawing.Point(6, 19);
            this.chbDeliveryNumber.Name = "chbDeliveryNumber";
            this.chbDeliveryNumber.Size = new System.Drawing.Size(110, 17);
            this.chbDeliveryNumber.TabIndex = 20;
            this.chbDeliveryNumber.Text = "Номер поставки";
            this.chbDeliveryNumber.UseVisualStyleBackColor = true;
            this.chbDeliveryNumber.CheckedChanged += new System.EventHandler(this.chb_CheckedChanged);
            // 
            // grbOrderNumber
            // 
            this.grbOrderNumber.Controls.Add(this.tbxOrderNumber);
            this.grbOrderNumber.Controls.Add(this.chbOrderNumber);
            this.grbOrderNumber.Location = new System.Drawing.Point(12, 93);
            this.grbOrderNumber.Name = "grbOrderNumber";
            this.grbOrderNumber.Size = new System.Drawing.Size(409, 52);
            this.grbOrderNumber.TabIndex = 39;
            this.grbOrderNumber.TabStop = false;
            // 
            // tbxOrderNumber
            // 
            this.tbxOrderNumber.Location = new System.Drawing.Point(124, 19);
            this.tbxOrderNumber.Name = "tbxOrderNumber";
            this.tbxOrderNumber.Size = new System.Drawing.Size(98, 20);
            this.tbxOrderNumber.TabIndex = 50;
            // 
            // chbOrderNumber
            // 
            this.chbOrderNumber.AutoSize = true;
            this.chbOrderNumber.Location = new System.Drawing.Point(6, 22);
            this.chbOrderNumber.Name = "chbOrderNumber";
            this.chbOrderNumber.Size = new System.Drawing.Size(99, 17);
            this.chbOrderNumber.TabIndex = 40;
            this.chbOrderNumber.Text = "Номер заказа";
            this.chbOrderNumber.UseVisualStyleBackColor = true;
            this.chbOrderNumber.CheckedChanged += new System.EventHandler(this.chb_CheckedChanged);
            // 
            // grbVendor
            // 
            this.grbVendor.Controls.Add(this.lblVendorName);
            this.grbVendor.Controls.Add(this.stbVendor);
            this.grbVendor.Controls.Add(this.chbVendor);
            this.grbVendor.Location = new System.Drawing.Point(12, 151);
            this.grbVendor.Name = "grbVendor";
            this.grbVendor.Size = new System.Drawing.Size(409, 76);
            this.grbVendor.TabIndex = 59;
            this.grbVendor.TabStop = false;
            // 
            // lblVendorName
            // 
            this.lblVendorName.AutoSize = true;
            this.lblVendorName.Location = new System.Drawing.Point(121, 42);
            this.lblVendorName.Name = "lblVendorName";
            this.lblVendorName.Size = new System.Drawing.Size(122, 13);
            this.lblVendorName.TabIndex = 14;
            this.lblVendorName.Text = "Название поставщика";
            // 
            // stbVendor
            // 
            this.stbVendor.Location = new System.Drawing.Point(124, 16);
            this.stbVendor.Name = "stbVendor";
            this.stbVendor.ReadOnly = false;
            this.stbVendor.Size = new System.Drawing.Size(98, 23);
            this.stbVendor.TabIndex = 70;
            this.stbVendor.UserID = ((long)(0));
            this.stbVendor.Value = null;
            this.stbVendor.ValueReferenceQuery = null;
            // 
            // chbVendor
            // 
            this.chbVendor.AutoSize = true;
            this.chbVendor.Location = new System.Drawing.Point(6, 22);
            this.chbVendor.Name = "chbVendor";
            this.chbVendor.Size = new System.Drawing.Size(84, 17);
            this.chbVendor.TabIndex = 60;
            this.chbVendor.Text = "Поставщик";
            this.chbVendor.UseVisualStyleBackColor = true;
            this.chbVendor.CheckedChanged += new System.EventHandler(this.chb_CheckedChanged);
            // 
            // grbWorksheetDate
            // 
            this.grbWorksheetDate.Controls.Add(this.dtpDateTo);
            this.grbWorksheetDate.Controls.Add(this.lblDateTo);
            this.grbWorksheetDate.Controls.Add(this.dtpDateFrom);
            this.grbWorksheetDate.Controls.Add(this.lblDateFrom);
            this.grbWorksheetDate.Controls.Add(this.chbWorksheetDate);
            this.grbWorksheetDate.Location = new System.Drawing.Point(12, 233);
            this.grbWorksheetDate.Name = "grbWorksheetDate";
            this.grbWorksheetDate.Size = new System.Drawing.Size(409, 108);
            this.grbWorksheetDate.TabIndex = 79;
            this.grbWorksheetDate.TabStop = false;
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Location = new System.Drawing.Point(63, 74);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(128, 20);
            this.dtpDateTo.TabIndex = 100;
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Location = new System.Drawing.Point(6, 80);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(48, 13);
            this.lblDateTo.TabIndex = 8;
            this.lblDateTo.Text = "Дата по";
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Location = new System.Drawing.Point(63, 49);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(128, 20);
            this.dtpDateFrom.TabIndex = 90;
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Location = new System.Drawing.Point(6, 55);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(42, 13);
            this.lblDateFrom.TabIndex = 6;
            this.lblDateFrom.Text = "Дата с";
            // 
            // chbWorksheetDate
            // 
            this.chbWorksheetDate.AutoSize = true;
            this.chbWorksheetDate.Location = new System.Drawing.Point(6, 22);
            this.chbWorksheetDate.Name = "chbWorksheetDate";
            this.chbWorksheetDate.Size = new System.Drawing.Size(143, 17);
            this.chbWorksheetDate.TabIndex = 80;
            this.chbWorksheetDate.Text = "Дата создания анкеты";
            this.chbWorksheetDate.UseVisualStyleBackColor = true;
            this.chbWorksheetDate.CheckedChanged += new System.EventHandler(this.chb_CheckedChanged);
            // 
            // grbProvisor
            // 
            this.grbProvisor.Controls.Add(this.cmbProvisors);
            this.grbProvisor.Controls.Add(this.chbProvisor);
            this.grbProvisor.Location = new System.Drawing.Point(12, 347);
            this.grbProvisor.Name = "grbProvisor";
            this.grbProvisor.Size = new System.Drawing.Size(409, 52);
            this.grbProvisor.TabIndex = 109;
            this.grbProvisor.TabStop = false;
            // 
            // cmbProvisors
            // 
            this.cmbProvisors.DataSource = this.bsApGetProvisors;
            this.cmbProvisors.DisplayMember = "User_FIO";
            this.cmbProvisors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProvisors.FormattingEnabled = true;
            this.cmbProvisors.Location = new System.Drawing.Point(124, 20);
            this.cmbProvisors.Name = "cmbProvisors";
            this.cmbProvisors.Size = new System.Drawing.Size(279, 21);
            this.cmbProvisors.TabIndex = 120;
            this.cmbProvisors.ValueMember = "User_ID";
            // 
            // bsApGetProvisors
            // 
            this.bsApGetProvisors.DataMember = "AP_Get_Provisors";
            this.bsApGetProvisors.DataSource = this.quality;
            // 
            // quality
            // 
            this.quality.DataSetName = "Quality";
            this.quality.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // chbProvisor
            // 
            this.chbProvisor.AutoSize = true;
            this.chbProvisor.Location = new System.Drawing.Point(6, 22);
            this.chbProvisor.Name = "chbProvisor";
            this.chbProvisor.Size = new System.Drawing.Size(112, 17);
            this.chbProvisor.TabIndex = 110;
            this.chbProvisor.Text = "ФИО Фармацевта";
            this.chbProvisor.UseVisualStyleBackColor = true;
            this.chbProvisor.CheckedChanged += new System.EventHandler(this.chb_CheckedChanged);
            // 
            // taApGetProvisors
            // 
            this.taApGetProvisors.ClearBeforeFill = true;
            // 
            // grbStatuses
            // 
            this.grbStatuses.Controls.Add(this.chbIncludeOnlyApproved);
            this.grbStatuses.Controls.Add(this.chbIncludeWithSuspectedQuality);
            this.grbStatuses.Controls.Add(this.chbIncludeNotAccepted);
            this.grbStatuses.Controls.Add(this.chbIncludeAccepted);
            this.grbStatuses.Controls.Add(this.chbIncludeInWork);
            this.grbStatuses.Controls.Add(this.chbIncludeNew);
            this.grbStatuses.Location = new System.Drawing.Point(12, 405);
            this.grbStatuses.Name = "grbStatuses";
            this.grbStatuses.Size = new System.Drawing.Size(409, 77);
            this.grbStatuses.TabIndex = 129;
            this.grbStatuses.TabStop = false;
            this.grbStatuses.Text = "Статусы анкет";
            // 
            // chbIncludeWithSuspectedQuality
            // 
            this.chbIncludeWithSuspectedQuality.AutoSize = true;
            this.chbIncludeWithSuspectedQuality.Location = new System.Drawing.Point(6, 51);
            this.chbIncludeWithSuspectedQuality.Name = "chbIncludeWithSuspectedQuality";
            this.chbIncludeWithSuspectedQuality.Size = new System.Drawing.Size(154, 17);
            this.chbIncludeWithSuspectedQuality.TabIndex = 160;
            this.chbIncludeWithSuspectedQuality.Text = "Сомнительного качества";
            this.chbIncludeWithSuspectedQuality.UseVisualStyleBackColor = true;
            // 
            // chbIncludeNotAccepted
            // 
            this.chbIncludeNotAccepted.AutoSize = true;
            this.chbIncludeNotAccepted.Location = new System.Drawing.Point(172, 51);
            this.chbIncludeNotAccepted.Name = "chbIncludeNotAccepted";
            this.chbIncludeNotAccepted.Size = new System.Drawing.Size(91, 17);
            this.chbIncludeNotAccepted.TabIndex = 170;
            this.chbIncludeNotAccepted.Text = "Не пройдена";
            this.chbIncludeNotAccepted.UseVisualStyleBackColor = true;
            // 
            // chbIncludeAccepted
            // 
            this.chbIncludeAccepted.AutoSize = true;
            this.chbIncludeAccepted.Location = new System.Drawing.Point(281, 28);
            this.chbIncludeAccepted.Name = "chbIncludeAccepted";
            this.chbIncludeAccepted.Size = new System.Drawing.Size(122, 17);
            this.chbIncludeAccepted.TabIndex = 150;
            this.chbIncludeAccepted.Text = "Пройдена успешно";
            this.chbIncludeAccepted.UseVisualStyleBackColor = true;
            // 
            // chbIncludeInWork
            // 
            this.chbIncludeInWork.AutoSize = true;
            this.chbIncludeInWork.Checked = true;
            this.chbIncludeInWork.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbIncludeInWork.Location = new System.Drawing.Point(172, 28);
            this.chbIncludeInWork.Name = "chbIncludeInWork";
            this.chbIncludeInWork.Size = new System.Drawing.Size(71, 17);
            this.chbIncludeInWork.TabIndex = 140;
            this.chbIncludeInWork.Text = "В работе";
            this.chbIncludeInWork.UseVisualStyleBackColor = true;
            // 
            // chbIncludeNew
            // 
            this.chbIncludeNew.AutoSize = true;
            this.chbIncludeNew.Checked = true;
            this.chbIncludeNew.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbIncludeNew.Location = new System.Drawing.Point(6, 28);
            this.chbIncludeNew.Name = "chbIncludeNew";
            this.chbIncludeNew.Size = new System.Drawing.Size(58, 17);
            this.chbIncludeNew.TabIndex = 130;
            this.chbIncludeNew.Text = "Новая";
            this.chbIncludeNew.UseVisualStyleBackColor = true;
            // 
            // chbIncludeOnlyApproved
            // 
            this.chbIncludeOnlyApproved.AutoSize = true;
            this.chbIncludeOnlyApproved.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chbIncludeOnlyApproved.Location = new System.Drawing.Point(281, 51);
            this.chbIncludeOnlyApproved.Name = "chbIncludeOnlyApproved";
            this.chbIncludeOnlyApproved.Size = new System.Drawing.Size(113, 17);
            this.chbIncludeOnlyApproved.TabIndex = 180;
            this.chbIncludeOnlyApproved.Text = "Подтверждена";
            this.chbIncludeOnlyApproved.UseVisualStyleBackColor = true;
            // 
            // InputControlDeliveryWorksheetSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(432, 531);
            this.Controls.Add(this.grbStatuses);
            this.Controls.Add(this.grbProvisor);
            this.Controls.Add(this.grbWorksheetDate);
            this.Controls.Add(this.grbVendor);
            this.Controls.Add(this.grbOrderNumber);
            this.Controls.Add(this.gbDeliveryNumber);
            this.Controls.Add(this.chbOnlyActual);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "InputControlDeliveryWorksheetSearchForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки поиска";
            this.Load += new System.EventHandler(this.InputControlDeliveryWorksheetSearchForm_Load);
            this.gbDeliveryNumber.ResumeLayout(false);
            this.gbDeliveryNumber.PerformLayout();
            this.grbOrderNumber.ResumeLayout(false);
            this.grbOrderNumber.PerformLayout();
            this.grbVendor.ResumeLayout(false);
            this.grbVendor.PerformLayout();
            this.grbWorksheetDate.ResumeLayout(false);
            this.grbWorksheetDate.PerformLayout();
            this.grbProvisor.ResumeLayout(false);
            this.grbProvisor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsApGetProvisors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            this.grbStatuses.ResumeLayout(false);
            this.grbStatuses.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.CheckBox chbOnlyActual;
        private System.Windows.Forms.GroupBox gbDeliveryNumber;
        private System.Windows.Forms.CheckBox chbDeliveryNumber;
        private System.Windows.Forms.TextBox tbxDeliveryNumber;
        private System.Windows.Forms.GroupBox grbOrderNumber;
        private System.Windows.Forms.TextBox tbxOrderNumber;
        private System.Windows.Forms.CheckBox chbOrderNumber;
        private System.Windows.Forms.GroupBox grbVendor;
        private System.Windows.Forms.CheckBox chbVendor;
        private System.Windows.Forms.GroupBox grbWorksheetDate;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.CheckBox chbWorksheetDate;
        private System.Windows.Forms.GroupBox grbProvisor;
        private System.Windows.Forms.ComboBox cmbProvisors;
        private System.Windows.Forms.CheckBox chbProvisor;
        private WMSOffice.Data.Quality quality;
        private System.Windows.Forms.BindingSource bsApGetProvisors;
        private WMSOffice.Data.QualityTableAdapters.AP_Get_ProvisorsTableAdapter taApGetProvisors;
        private WMSOffice.Controls.SearchTextBox stbVendor;
        private System.Windows.Forms.Label lblVendorName;
        private System.Windows.Forms.GroupBox grbStatuses;
        private System.Windows.Forms.CheckBox chbIncludeAccepted;
        private System.Windows.Forms.CheckBox chbIncludeInWork;
        private System.Windows.Forms.CheckBox chbIncludeNew;
        private System.Windows.Forms.CheckBox chbIncludeNotAccepted;
        private System.Windows.Forms.CheckBox chbIncludeWithSuspectedQuality;
        private System.Windows.Forms.CheckBox chbIncludeOnlyApproved;
    }
}