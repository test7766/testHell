namespace WMSOffice.Dialogs.Quality
{
    partial class SetAnalizForm
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
            this.pbAnalysis = new System.Windows.Forms.PictureBox();
            this.lblNumber = new System.Windows.Forms.Label();
            this.tbxNumber = new System.Windows.Forms.TextBox();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.grbResult = new System.Windows.Forms.GroupBox();
            this.chbNegativeAnaliz = new System.Windows.Forms.CheckBox();
            this.chbDelivery = new System.Windows.Forms.CheckBox();
            this.chbReceipt = new System.Windows.Forms.CheckBox();
            this.dtpDateDelivery = new System.Windows.Forms.DateTimePicker();
            this.dtpDateReceipt = new System.Windows.Forms.DateTimePicker();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tlcFeatures = new WMSOffice.Controls.TwoListControl();
            this.taQkGetAnalysisFeatures = new WMSOffice.Data.QualityTableAdapters.QK_Get_Analysis_FeaturesTableAdapter();
            this.lblCompany = new System.Windows.Forms.Label();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.quality = new WMSOffice.Data.Quality();
            this.analizCompanyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.analizCompanyTableAdapter = new WMSOffice.Data.QualityTableAdapters.AnalizCompanyTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.pbAnalysis)).BeginInit();
            this.grbResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.analizCompanyBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pbAnalysis
            // 
            this.pbAnalysis.Image = global::WMSOffice.Properties.Resources.antivirus;
            this.pbAnalysis.Location = new System.Drawing.Point(12, 21);
            this.pbAnalysis.Name = "pbAnalysis";
            this.pbAnalysis.Size = new System.Drawing.Size(56, 53);
            this.pbAnalysis.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbAnalysis.TabIndex = 101;
            this.pbAnalysis.TabStop = false;
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(74, 24);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(89, 13);
            this.lblNumber.TabIndex = 0;
            this.lblNumber.Text = "Номер аналізу:";
            // 
            // tbxNumber
            // 
            this.tbxNumber.Location = new System.Drawing.Point(169, 20);
            this.tbxNumber.Name = "tbxNumber";
            this.tbxNumber.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxNumber.Size = new System.Drawing.Size(145, 20);
            this.tbxNumber.TabIndex = 1;
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Location = new System.Drawing.Point(74, 53);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(81, 13);
            this.lblDateFrom.TabIndex = 2;
            this.lblDateFrom.Text = "Дата аналізу:";
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateFrom.Location = new System.Drawing.Point(169, 49);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(145, 20);
            this.dtpDateFrom.TabIndex = 3;
            // 
            // grbResult
            // 
            this.grbResult.Controls.Add(this.chbNegativeAnaliz);
            this.grbResult.Controls.Add(this.chbDelivery);
            this.grbResult.Controls.Add(this.chbReceipt);
            this.grbResult.Controls.Add(this.dtpDateDelivery);
            this.grbResult.Controls.Add(this.dtpDateReceipt);
            this.grbResult.Location = new System.Drawing.Point(338, 12);
            this.grbResult.Name = "grbResult";
            this.grbResult.Size = new System.Drawing.Size(302, 92);
            this.grbResult.TabIndex = 6;
            this.grbResult.TabStop = false;
            this.grbResult.Text = "Результат аналізу:";
            // 
            // chbNegativeAnaliz
            // 
            this.chbNegativeAnaliz.AutoSize = true;
            this.chbNegativeAnaliz.Location = new System.Drawing.Point(15, 66);
            this.chbNegativeAnaliz.Name = "chbNegativeAnaliz";
            this.chbNegativeAnaliz.Size = new System.Drawing.Size(160, 17);
            this.chbNegativeAnaliz.TabIndex = 4;
            this.chbNegativeAnaliz.Text = "Негативний результат";
            this.chbNegativeAnaliz.UseVisualStyleBackColor = true;
            // 
            // chbDelivery
            // 
            this.chbDelivery.AutoSize = true;
            this.chbDelivery.Checked = true;
            this.chbDelivery.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbDelivery.Location = new System.Drawing.Point(15, 43);
            this.chbDelivery.Name = "chbDelivery";
            this.chbDelivery.Size = new System.Drawing.Size(141, 17);
            this.chbDelivery.TabIndex = 2;
            this.chbDelivery.Text = "Передано до Інспекції:";
            this.chbDelivery.UseVisualStyleBackColor = true;
            this.chbDelivery.CheckedChanged += new System.EventHandler(this.chb_CheckedChanged);
            // 
            // chbReceipt
            // 
            this.chbReceipt.AutoSize = true;
            this.chbReceipt.Checked = true;
            this.chbReceipt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbReceipt.Location = new System.Drawing.Point(15, 19);
            this.chbReceipt.Name = "chbReceipt";
            this.chbReceipt.Size = new System.Drawing.Size(154, 17);
            this.chbReceipt.TabIndex = 0;
            this.chbReceipt.Text = "Отримано з Лабораторії:";
            this.chbReceipt.UseVisualStyleBackColor = true;
            this.chbReceipt.CheckedChanged += new System.EventHandler(this.chb_CheckedChanged);
            this.chbReceipt.EnabledChanged += new System.EventHandler(this.chb_CheckedChanged);
            // 
            // dtpDateDelivery
            // 
            this.dtpDateDelivery.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateDelivery.Location = new System.Drawing.Point(172, 42);
            this.dtpDateDelivery.Name = "dtpDateDelivery";
            this.dtpDateDelivery.Size = new System.Drawing.Size(124, 20);
            this.dtpDateDelivery.TabIndex = 3;
            // 
            // dtpDateReceipt
            // 
            this.dtpDateReceipt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateReceipt.Location = new System.Drawing.Point(172, 16);
            this.dtpDateReceipt.Name = "dtpDateReceipt";
            this.dtpDateReceipt.Size = new System.Drawing.Size(124, 20);
            this.dtpDateReceipt.TabIndex = 1;
            this.dtpDateReceipt.ValueChanged += new System.EventHandler(this.dtpReceiptDate_ValueChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(561, 373);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Скасувати";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(480, 373);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tlcFeatures
            // 
            this.tlcFeatures.Caption = "Всі ознаки:";
            this.tlcFeatures.CaptionSelected = "Ознаки, за якими проводився аналіз:";
            this.tlcFeatures.ColumnsList = null;
            this.tlcFeatures.ContextMenuItemText = "";
            this.tlcFeatures.DisplayMember = "Ознака";
            this.tlcFeatures.Filter = null;
            this.tlcFeatures.FormClass = null;
            this.tlcFeatures.GroupMember = null;
            this.tlcFeatures.Location = new System.Drawing.Point(12, 120);
            this.tlcFeatures.MaxShownItems = 300;
            this.tlcFeatures.Name = "tlcFeatures";
            this.tlcFeatures.PopupControlClass = null;
            this.tlcFeatures.SelectedListParamName = "line_id";
            this.tlcFeatures.SelectedListParamValue = null;
            this.tlcFeatures.Size = new System.Drawing.Size(628, 247);
            this.tlcFeatures.TabIndex = 7;
            this.tlcFeatures.Table = WMSOffice.Admin.Database.Table.QkAnalysisFeatures;
            this.tlcFeatures.ValueMember = "ID";
            this.tlcFeatures.OnAddItem += new WMSOffice.Controls.TwoListControl.TwoListEventHandler(this.tlcFeatures_OnAddItem);
            this.tlcFeatures.OnDeleteItem += new WMSOffice.Controls.TwoListControl.TwoListEventHandler(this.tlcFeatures_OnDeleteItem);
            // 
            // taQkGetAnalysisFeatures
            // 
            this.taQkGetAnalysisFeatures.ClearBeforeFill = true;
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(75, 82);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(61, 13);
            this.lblCompany.TabIndex = 4;
            this.lblCompany.Text = "Компанія:";
            // 
            // cmbCompany
            // 
            this.cmbCompany.DataSource = this.analizCompanyBindingSource;
            this.cmbCompany.DisplayMember = "CompanyName";
            this.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(169, 78);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(145, 21);
            this.cmbCompany.TabIndex = 5;
            this.cmbCompany.ValueMember = "id";
            // 
            // quality
            // 
            this.quality.DataSetName = "Quality";
            this.quality.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // analizCompanyBindingSource
            // 
            this.analizCompanyBindingSource.DataMember = "AnalizCompany";
            this.analizCompanyBindingSource.DataSource = this.quality;
            // 
            // analizCompanyTableAdapter
            // 
            this.analizCompanyTableAdapter.ClearBeforeFill = true;
            // 
            // SetAnalizForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(648, 408);
            this.Controls.Add(this.cmbCompany);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.tlcFeatures);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grbResult);
            this.Controls.Add(this.dtpDateFrom);
            this.Controls.Add(this.lblDateFrom);
            this.Controls.Add(this.tbxNumber);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.pbAnalysis);
            this.MinimumSize = new System.Drawing.Size(664, 446);
            this.Name = "SetAnalizForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Проведено аналіз товару";
            this.Load += new System.EventHandler(this.SetAnalizForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbAnalysis)).EndInit();
            this.grbResult.ResumeLayout(false);
            this.grbResult.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.analizCompanyBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbAnalysis;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.TextBox tbxNumber;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.GroupBox grbResult;
        private System.Windows.Forms.DateTimePicker dtpDateDelivery;
        private System.Windows.Forms.DateTimePicker dtpDateReceipt;
        private System.Windows.Forms.CheckBox chbDelivery;
        private System.Windows.Forms.CheckBox chbReceipt;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private WMSOffice.Controls.TwoListControl tlcFeatures;
        private WMSOffice.Data.QualityTableAdapters.QK_Get_Analysis_FeaturesTableAdapter taQkGetAnalysisFeatures;
        private System.Windows.Forms.CheckBox chbNegativeAnaliz;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.BindingSource analizCompanyBindingSource;
        private Data.Quality quality;
        private Data.QualityTableAdapters.AnalizCompanyTableAdapter analizCompanyTableAdapter;
    }
}