namespace WMSOffice.Dialogs.Quality
{
    partial class SetModeForm
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
            this.lblModes = new System.Windows.Forms.Label();
            this.cmbModes = new System.Windows.Forms.ComboBox();
            this.bsModes = new System.Windows.Forms.BindingSource(this.components);
            this.quality = new WMSOffice.Data.Quality();
            this.taModes = new WMSOffice.Data.QualityTableAdapters.ModesTableAdapter();
            this.tbxLotVolume = new System.Windows.Forms.TextBox();
            this.lblLotVolume = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblManufDate = new System.Windows.Forms.Label();
            this.dtpManufDate = new System.Windows.Forms.DateTimePicker();
            this.lblLicenseRequisites = new System.Windows.Forms.Label();
            this.tbxLicenseRequisites = new System.Windows.Forms.TextBox();
            this.lblGMP_Sert = new System.Windows.Forms.Label();
            this.tbxGMP_Sert = new System.Windows.Forms.TextBox();
            this.gbOtherEditors = new System.Windows.Forms.GroupBox();
            this.cbEnableOtherEditors = new System.Windows.Forms.CheckBox();
            this.lblManufItemDate = new System.Windows.Forms.Label();
            this.dtpManufItemDate = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.bsModes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            this.gbOtherEditors.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblModes
            // 
            this.lblModes.AutoSize = true;
            this.lblModes.Location = new System.Drawing.Point(12, 15);
            this.lblModes.Name = "lblModes";
            this.lblModes.Size = new System.Drawing.Size(29, 13);
            this.lblModes.TabIndex = 0;
            this.lblModes.Text = "Тип:";
            // 
            // cmbModes
            // 
            this.cmbModes.DataSource = this.bsModes;
            this.cmbModes.DisplayMember = "Mode_Name";
            this.cmbModes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModes.FormattingEnabled = true;
            this.cmbModes.Location = new System.Drawing.Point(68, 11);
            this.cmbModes.Name = "cmbModes";
            this.cmbModes.Size = new System.Drawing.Size(251, 21);
            this.cmbModes.TabIndex = 1;
            this.cmbModes.ValueMember = "Mode_ID";
            // 
            // bsModes
            // 
            this.bsModes.DataMember = "Modes";
            this.bsModes.DataSource = this.quality;
            // 
            // quality
            // 
            this.quality.DataSetName = "Quality";
            this.quality.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // taModes
            // 
            this.taModes.ClearBeforeFill = true;
            // 
            // tbxLotVolume
            // 
            this.tbxLotVolume.Location = new System.Drawing.Point(68, 49);
            this.tbxLotVolume.Name = "tbxLotVolume";
            this.tbxLotVolume.Size = new System.Drawing.Size(100, 20);
            this.tbxLotVolume.TabIndex = 3;
            this.tbxLotVolume.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxLotVolume_KeyPress);
            // 
            // lblLotVolume
            // 
            this.lblLotVolume.Location = new System.Drawing.Point(12, 46);
            this.lblLotVolume.Name = "lblLotVolume";
            this.lblLotVolume.Size = new System.Drawing.Size(46, 26);
            this.lblLotVolume.TabIndex = 2;
            this.lblLotVolume.Text = "Розмір серії:";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(257, 416);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Скасувати";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(176, 416);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblManufDate
            // 
            this.lblManufDate.AutoSize = true;
            this.lblManufDate.Location = new System.Drawing.Point(6, 59);
            this.lblManufDate.Name = "lblManufDate";
            this.lblManufDate.Size = new System.Drawing.Size(115, 13);
            this.lblManufDate.TabIndex = 2;
            this.lblManufDate.Text = "Дата випуску серії:";
            // 
            // dtpManufDate
            // 
            this.dtpManufDate.Location = new System.Drawing.Point(176, 55);
            this.dtpManufDate.Name = "dtpManufDate";
            this.dtpManufDate.Size = new System.Drawing.Size(138, 20);
            this.dtpManufDate.TabIndex = 3;
            // 
            // lblLicenseRequisites
            // 
            this.lblLicenseRequisites.Location = new System.Drawing.Point(6, 93);
            this.lblLicenseRequisites.Name = "lblLicenseRequisites";
            this.lblLicenseRequisites.Size = new System.Drawing.Size(308, 26);
            this.lblLicenseRequisites.TabIndex = 4;
            this.lblLicenseRequisites.Text = "Назва, місцеположення та номер ліцензії виробничої дільниці виробника";
            // 
            // tbxLicenseRequisites
            // 
            this.tbxLicenseRequisites.Location = new System.Drawing.Point(9, 122);
            this.tbxLicenseRequisites.Multiline = true;
            this.tbxLicenseRequisites.Name = "tbxLicenseRequisites";
            this.tbxLicenseRequisites.Size = new System.Drawing.Size(305, 57);
            this.tbxLicenseRequisites.TabIndex = 5;
            // 
            // lblGMP_Sert
            // 
            this.lblGMP_Sert.Location = new System.Drawing.Point(6, 192);
            this.lblGMP_Sert.Name = "lblGMP_Sert";
            this.lblGMP_Sert.Size = new System.Drawing.Size(308, 53);
            this.lblGMP_Sert.TabIndex = 6;
            this.lblGMP_Sert.Text = "Сертифікат відповідності GMP для виробничої дільниці виробника, уповноважена особа якого надає дозвіл на випуск серії чи номери посилань у базі даних Eudra GMP";
            // 
            // tbxGMP_Sert
            // 
            this.tbxGMP_Sert.Location = new System.Drawing.Point(9, 248);
            this.tbxGMP_Sert.Multiline = true;
            this.tbxGMP_Sert.Name = "tbxGMP_Sert";
            this.tbxGMP_Sert.Size = new System.Drawing.Size(305, 57);
            this.tbxGMP_Sert.TabIndex = 7;
            // 
            // gbOtherEditors
            // 
            this.gbOtherEditors.Controls.Add(this.dtpManufItemDate);
            this.gbOtherEditors.Controls.Add(this.lblManufItemDate);
            this.gbOtherEditors.Controls.Add(this.lblManufDate);
            this.gbOtherEditors.Controls.Add(this.tbxGMP_Sert);
            this.gbOtherEditors.Controls.Add(this.dtpManufDate);
            this.gbOtherEditors.Controls.Add(this.lblGMP_Sert);
            this.gbOtherEditors.Controls.Add(this.lblLicenseRequisites);
            this.gbOtherEditors.Controls.Add(this.tbxLicenseRequisites);
            this.gbOtherEditors.Location = new System.Drawing.Point(5, 95);
            this.gbOtherEditors.Name = "gbOtherEditors";
            this.gbOtherEditors.Size = new System.Drawing.Size(330, 316);
            this.gbOtherEditors.TabIndex = 5;
            this.gbOtherEditors.TabStop = false;
            // 
            // cbEnableOtherEditors
            // 
            this.cbEnableOtherEditors.AutoSize = true;
            this.cbEnableOtherEditors.Location = new System.Drawing.Point(14, 95);
            this.cbEnableOtherEditors.Name = "cbEnableOtherEditors";
            this.cbEnableOtherEditors.Size = new System.Drawing.Size(77, 17);
            this.cbEnableOtherEditors.TabIndex = 4;
            this.cbEnableOtherEditors.Text = "Змінити";
            this.cbEnableOtherEditors.UseVisualStyleBackColor = true;
            this.cbEnableOtherEditors.CheckedChanged += new System.EventHandler(this.cbEnableOtherEditors_CheckedChanged);
            // 
            // lblManufItemDate
            // 
            this.lblManufItemDate.AutoSize = true;
            this.lblManufItemDate.Location = new System.Drawing.Point(7, 30);
            this.lblManufItemDate.Name = "lblManufItemDate";
            this.lblManufItemDate.Size = new System.Drawing.Size(110, 13);
            this.lblManufItemDate.TabIndex = 0;
            this.lblManufItemDate.Text = "Дата виробництва:";
            // 
            // dtpManufItemDate
            // 
            this.dtpManufItemDate.Location = new System.Drawing.Point(176, 26);
            this.dtpManufItemDate.Name = "dtpManufItemDate";
            this.dtpManufItemDate.Size = new System.Drawing.Size(138, 20);
            this.dtpManufItemDate.TabIndex = 1;
            // 
            // SetModeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(344, 451);
            this.Controls.Add(this.cbEnableOtherEditors);
            this.Controls.Add(this.gbOtherEditors);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblLotVolume);
            this.Controls.Add(this.tbxLotVolume);
            this.Controls.Add(this.cmbModes);
            this.Controls.Add(this.lblModes);
            this.Name = "SetModeForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Встановити параметри";
            this.Load += new System.EventHandler(this.SetModeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsModes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            this.gbOtherEditors.ResumeLayout(false);
            this.gbOtherEditors.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblModes;
        private System.Windows.Forms.ComboBox cmbModes;
        private WMSOffice.Data.Quality quality;
        private System.Windows.Forms.BindingSource bsModes;
        private WMSOffice.Data.QualityTableAdapters.ModesTableAdapter taModes;
        private System.Windows.Forms.TextBox tbxLotVolume;
        private System.Windows.Forms.Label lblLotVolume;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblManufDate;
        private System.Windows.Forms.DateTimePicker dtpManufDate;
        private System.Windows.Forms.Label lblLicenseRequisites;
        private System.Windows.Forms.TextBox tbxLicenseRequisites;
        private System.Windows.Forms.Label lblGMP_Sert;
        private System.Windows.Forms.TextBox tbxGMP_Sert;
        private System.Windows.Forms.GroupBox gbOtherEditors;
        private System.Windows.Forms.CheckBox cbEnableOtherEditors;
        private System.Windows.Forms.DateTimePicker dtpManufItemDate;
        private System.Windows.Forms.Label lblManufItemDate;
    }
}