namespace WMSOffice.Dialogs.Quality
{
    partial class ImportLicenseRequestCreateItemForm
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
            this.tbItemID = new System.Windows.Forms.TextBox();
            this.qKLILicRequestDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quality = new WMSOffice.Data.Quality();
            this.qK_LI_LicRequest_DetailsTableAdapter = new WMSOffice.Data.QualityTableAdapters.QK_LI_LicRequest_DetailsTableAdapter();
            this.lblItemID = new System.Windows.Forms.Label();
            this.lblItemName = new System.Windows.Forms.Label();
            this.tbItemName = new System.Windows.Forms.TextBox();
            this.lblReleaseForm = new System.Windows.Forms.Label();
            this.tbReleaseForm = new System.Windows.Forms.TextBox();
            this.lblDosage = new System.Windows.Forms.Label();
            this.tbDosage = new System.Windows.Forms.TextBox();
            this.lblGMPDateTo = new System.Windows.Forms.Label();
            this.tbGMPDateTo = new System.Windows.Forms.TextBox();
            this.lblGMP = new System.Windows.Forms.Label();
            this.tbGMP = new System.Windows.Forms.TextBox();
            this.lblDateEndReg = new System.Windows.Forms.Label();
            this.tbDateEndReg = new System.Windows.Forms.TextBox();
            this.lblNoReg = new System.Windows.Forms.Label();
            this.tbNoReg = new System.Windows.Forms.TextBox();
            this.lblVendorAddress = new System.Windows.Forms.Label();
            this.tbVendorAddress = new System.Windows.Forms.TextBox();
            this.lblVendorCountry = new System.Windows.Forms.Label();
            this.tbVendorCountry = new System.Windows.Forms.TextBox();
            this.lblVendorName = new System.Windows.Forms.Label();
            this.tbVendorName = new System.Windows.Forms.TextBox();
            this.lblManufacturerCountry = new System.Windows.Forms.Label();
            this.tbManufacturerCountry = new System.Windows.Forms.TextBox();
            this.lblManufacturerName = new System.Windows.Forms.Label();
            this.tbManufacturerName = new System.Windows.Forms.TextBox();
            this.lblAtcCode = new System.Windows.Forms.Label();
            this.tbAtcCode = new System.Windows.Forms.TextBox();
            this.lblMNN = new System.Windows.Forms.Label();
            this.tbMNN = new System.Windows.Forms.TextBox();
            this.lblQtyPack = new System.Windows.Forms.Label();
            this.tbQtyPack = new System.Windows.Forms.TextBox();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qKLILicRequestDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(868, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(958, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 473);
            this.pnlButtons.Size = new System.Drawing.Size(489, 43);
            this.pnlButtons.TabIndex = 32;
            // 
            // tbItemID
            // 
            this.tbItemID.BackColor = System.Drawing.SystemColors.Window;
            this.tbItemID.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.qKLILicRequestDetailsBindingSource, "ItemID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbItemID.Location = new System.Drawing.Point(175, 8);
            this.tbItemID.Name = "tbItemID";
            this.tbItemID.ReadOnly = true;
            this.tbItemID.Size = new System.Drawing.Size(100, 20);
            this.tbItemID.TabIndex = 1;
            // 
            // qKLILicRequestDetailsBindingSource
            // 
            this.qKLILicRequestDetailsBindingSource.DataMember = "QK_LI_LicRequest_Details";
            this.qKLILicRequestDetailsBindingSource.DataSource = this.quality;
            // 
            // quality
            // 
            this.quality.DataSetName = "Quality";
            this.quality.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // qK_LI_LicRequest_DetailsTableAdapter
            // 
            this.qK_LI_LicRequest_DetailsTableAdapter.ClearBeforeFill = true;
            // 
            // lblItemID
            // 
            this.lblItemID.AutoSize = true;
            this.lblItemID.Location = new System.Drawing.Point(12, 12);
            this.lblItemID.Name = "lblItemID";
            this.lblItemID.Size = new System.Drawing.Size(26, 13);
            this.lblItemID.TabIndex = 0;
            this.lblItemID.Text = "Код";
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.ForeColor = System.Drawing.Color.Brown;
            this.lblItemName.Location = new System.Drawing.Point(12, 41);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(121, 13);
            this.lblItemName.TabIndex = 2;
            this.lblItemName.Text = "Наименование товара";
            // 
            // tbItemName
            // 
            this.tbItemName.BackColor = System.Drawing.SystemColors.Info;
            this.tbItemName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.qKLILicRequestDetailsBindingSource, "ItemName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbItemName.Location = new System.Drawing.Point(175, 37);
            this.tbItemName.Name = "tbItemName";
            this.tbItemName.Size = new System.Drawing.Size(300, 20);
            this.tbItemName.TabIndex = 3;
            // 
            // lblReleaseForm
            // 
            this.lblReleaseForm.AutoSize = true;
            this.lblReleaseForm.ForeColor = System.Drawing.Color.Brown;
            this.lblReleaseForm.Location = new System.Drawing.Point(12, 70);
            this.lblReleaseForm.Name = "lblReleaseForm";
            this.lblReleaseForm.Size = new System.Drawing.Size(90, 13);
            this.lblReleaseForm.TabIndex = 4;
            this.lblReleaseForm.Text = "Форма выпуска";
            // 
            // tbReleaseForm
            // 
            this.tbReleaseForm.BackColor = System.Drawing.SystemColors.Info;
            this.tbReleaseForm.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.qKLILicRequestDetailsBindingSource, "ReleaseForm", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbReleaseForm.Location = new System.Drawing.Point(175, 66);
            this.tbReleaseForm.Name = "tbReleaseForm";
            this.tbReleaseForm.Size = new System.Drawing.Size(300, 20);
            this.tbReleaseForm.TabIndex = 5;
            // 
            // lblDosage
            // 
            this.lblDosage.AutoSize = true;
            this.lblDosage.ForeColor = System.Drawing.Color.Brown;
            this.lblDosage.Location = new System.Drawing.Point(12, 99);
            this.lblDosage.Name = "lblDosage";
            this.lblDosage.Size = new System.Drawing.Size(64, 13);
            this.lblDosage.TabIndex = 6;
            this.lblDosage.Text = "Дозировка";
            // 
            // tbDosage
            // 
            this.tbDosage.BackColor = System.Drawing.SystemColors.Info;
            this.tbDosage.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.qKLILicRequestDetailsBindingSource, "Dosage", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbDosage.Location = new System.Drawing.Point(175, 95);
            this.tbDosage.Name = "tbDosage";
            this.tbDosage.Size = new System.Drawing.Size(300, 20);
            this.tbDosage.TabIndex = 7;
            // 
            // lblGMPDateTo
            // 
            this.lblGMPDateTo.AutoSize = true;
            this.lblGMPDateTo.Location = new System.Drawing.Point(12, 447);
            this.lblGMPDateTo.Name = "lblGMPDateTo";
            this.lblGMPDateTo.Size = new System.Drawing.Size(109, 13);
            this.lblGMPDateTo.TabIndex = 30;
            this.lblGMPDateTo.Text = "Срок действия GMP";
            // 
            // tbGMPDateTo
            // 
            this.tbGMPDateTo.BackColor = System.Drawing.SystemColors.Window;
            this.tbGMPDateTo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.qKLILicRequestDetailsBindingSource, "GMPDateTo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbGMPDateTo.Location = new System.Drawing.Point(175, 443);
            this.tbGMPDateTo.Name = "tbGMPDateTo";
            this.tbGMPDateTo.ReadOnly = true;
            this.tbGMPDateTo.Size = new System.Drawing.Size(100, 20);
            this.tbGMPDateTo.TabIndex = 31;
            // 
            // lblGMP
            // 
            this.lblGMP.AutoSize = true;
            this.lblGMP.Location = new System.Drawing.Point(12, 418);
            this.lblGMP.Name = "lblGMP";
            this.lblGMP.Size = new System.Drawing.Size(31, 13);
            this.lblGMP.TabIndex = 28;
            this.lblGMP.Text = "GMP";
            // 
            // tbGMP
            // 
            this.tbGMP.BackColor = System.Drawing.SystemColors.Window;
            this.tbGMP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.qKLILicRequestDetailsBindingSource, "GMP", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbGMP.Location = new System.Drawing.Point(175, 414);
            this.tbGMP.Name = "tbGMP";
            this.tbGMP.ReadOnly = true;
            this.tbGMP.Size = new System.Drawing.Size(150, 20);
            this.tbGMP.TabIndex = 29;
            // 
            // lblDateEndReg
            // 
            this.lblDateEndReg.AutoSize = true;
            this.lblDateEndReg.Location = new System.Drawing.Point(12, 389);
            this.lblDateEndReg.Name = "lblDateEndReg";
            this.lblDateEndReg.Size = new System.Drawing.Size(155, 13);
            this.lblDateEndReg.TabIndex = 26;
            this.lblDateEndReg.Text = "Срок действия РС в Украине";
            // 
            // tbDateEndReg
            // 
            this.tbDateEndReg.BackColor = System.Drawing.SystemColors.Window;
            this.tbDateEndReg.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.qKLILicRequestDetailsBindingSource, "DateEndReg", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbDateEndReg.Location = new System.Drawing.Point(175, 385);
            this.tbDateEndReg.Name = "tbDateEndReg";
            this.tbDateEndReg.ReadOnly = true;
            this.tbDateEndReg.Size = new System.Drawing.Size(100, 20);
            this.tbDateEndReg.TabIndex = 27;
            // 
            // lblNoReg
            // 
            this.lblNoReg.AutoSize = true;
            this.lblNoReg.Location = new System.Drawing.Point(12, 360);
            this.lblNoReg.Name = "lblNoReg";
            this.lblNoReg.Size = new System.Drawing.Size(114, 13);
            this.lblNoReg.TabIndex = 24;
            this.lblNoReg.Text = "Номер РС в Украине";
            // 
            // tbNoReg
            // 
            this.tbNoReg.BackColor = System.Drawing.SystemColors.Window;
            this.tbNoReg.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.qKLILicRequestDetailsBindingSource, "NoReg", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbNoReg.Location = new System.Drawing.Point(175, 356);
            this.tbNoReg.Name = "tbNoReg";
            this.tbNoReg.ReadOnly = true;
            this.tbNoReg.Size = new System.Drawing.Size(150, 20);
            this.tbNoReg.TabIndex = 25;
            // 
            // lblVendorAddress
            // 
            this.lblVendorAddress.AutoSize = true;
            this.lblVendorAddress.ForeColor = System.Drawing.Color.Brown;
            this.lblVendorAddress.Location = new System.Drawing.Point(12, 331);
            this.lblVendorAddress.Name = "lblVendorAddress";
            this.lblVendorAddress.Size = new System.Drawing.Size(103, 13);
            this.lblVendorAddress.TabIndex = 22;
            this.lblVendorAddress.Text = "Адрес поставщика";
            // 
            // tbVendorAddress
            // 
            this.tbVendorAddress.BackColor = System.Drawing.SystemColors.Info;
            this.tbVendorAddress.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.qKLILicRequestDetailsBindingSource, "VendorAddress", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbVendorAddress.Location = new System.Drawing.Point(175, 327);
            this.tbVendorAddress.Name = "tbVendorAddress";
            this.tbVendorAddress.Size = new System.Drawing.Size(300, 20);
            this.tbVendorAddress.TabIndex = 23;
            // 
            // lblVendorCountry
            // 
            this.lblVendorCountry.AutoSize = true;
            this.lblVendorCountry.ForeColor = System.Drawing.Color.Brown;
            this.lblVendorCountry.Location = new System.Drawing.Point(12, 302);
            this.lblVendorCountry.Name = "lblVendorCountry";
            this.lblVendorCountry.Size = new System.Drawing.Size(108, 13);
            this.lblVendorCountry.TabIndex = 20;
            this.lblVendorCountry.Text = "Страна поставщика";
            // 
            // tbVendorCountry
            // 
            this.tbVendorCountry.BackColor = System.Drawing.SystemColors.Info;
            this.tbVendorCountry.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.qKLILicRequestDetailsBindingSource, "VendorCountry", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbVendorCountry.Location = new System.Drawing.Point(175, 298);
            this.tbVendorCountry.Name = "tbVendorCountry";
            this.tbVendorCountry.Size = new System.Drawing.Size(300, 20);
            this.tbVendorCountry.TabIndex = 21;
            // 
            // lblVendorName
            // 
            this.lblVendorName.AutoSize = true;
            this.lblVendorName.ForeColor = System.Drawing.Color.Brown;
            this.lblVendorName.Location = new System.Drawing.Point(12, 273);
            this.lblVendorName.Name = "lblVendorName";
            this.lblVendorName.Size = new System.Drawing.Size(65, 13);
            this.lblVendorName.TabIndex = 18;
            this.lblVendorName.Text = "Поставщик";
            // 
            // tbVendorName
            // 
            this.tbVendorName.BackColor = System.Drawing.SystemColors.Info;
            this.tbVendorName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.qKLILicRequestDetailsBindingSource, "Vendor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbVendorName.Location = new System.Drawing.Point(175, 269);
            this.tbVendorName.Name = "tbVendorName";
            this.tbVendorName.Size = new System.Drawing.Size(300, 20);
            this.tbVendorName.TabIndex = 19;
            // 
            // lblManufacturerCountry
            // 
            this.lblManufacturerCountry.AutoSize = true;
            this.lblManufacturerCountry.ForeColor = System.Drawing.Color.Brown;
            this.lblManufacturerCountry.Location = new System.Drawing.Point(12, 244);
            this.lblManufacturerCountry.Name = "lblManufacturerCountry";
            this.lblManufacturerCountry.Size = new System.Drawing.Size(123, 13);
            this.lblManufacturerCountry.TabIndex = 16;
            this.lblManufacturerCountry.Text = "Страна производителя";
            // 
            // tbManufacturerCountry
            // 
            this.tbManufacturerCountry.BackColor = System.Drawing.SystemColors.Info;
            this.tbManufacturerCountry.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.qKLILicRequestDetailsBindingSource, "ManufacturerCountry", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbManufacturerCountry.Location = new System.Drawing.Point(175, 240);
            this.tbManufacturerCountry.Name = "tbManufacturerCountry";
            this.tbManufacturerCountry.Size = new System.Drawing.Size(300, 20);
            this.tbManufacturerCountry.TabIndex = 17;
            // 
            // lblManufacturerName
            // 
            this.lblManufacturerName.AutoSize = true;
            this.lblManufacturerName.ForeColor = System.Drawing.Color.Brown;
            this.lblManufacturerName.Location = new System.Drawing.Point(12, 215);
            this.lblManufacturerName.Name = "lblManufacturerName";
            this.lblManufacturerName.Size = new System.Drawing.Size(86, 13);
            this.lblManufacturerName.TabIndex = 14;
            this.lblManufacturerName.Text = "Производитель";
            // 
            // tbManufacturerName
            // 
            this.tbManufacturerName.BackColor = System.Drawing.SystemColors.Info;
            this.tbManufacturerName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.qKLILicRequestDetailsBindingSource, "Manufacturer", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbManufacturerName.Location = new System.Drawing.Point(175, 211);
            this.tbManufacturerName.Name = "tbManufacturerName";
            this.tbManufacturerName.Size = new System.Drawing.Size(300, 20);
            this.tbManufacturerName.TabIndex = 15;
            // 
            // lblAtcCode
            // 
            this.lblAtcCode.AutoSize = true;
            this.lblAtcCode.Location = new System.Drawing.Point(12, 186);
            this.lblAtcCode.Name = "lblAtcCode";
            this.lblAtcCode.Size = new System.Drawing.Size(50, 13);
            this.lblAtcCode.TabIndex = 12;
            this.lblAtcCode.Text = "Код АТС";
            // 
            // tbAtcCode
            // 
            this.tbAtcCode.BackColor = System.Drawing.SystemColors.Window;
            this.tbAtcCode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.qKLILicRequestDetailsBindingSource, "AtcCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbAtcCode.Location = new System.Drawing.Point(175, 182);
            this.tbAtcCode.Name = "tbAtcCode";
            this.tbAtcCode.ReadOnly = true;
            this.tbAtcCode.Size = new System.Drawing.Size(100, 20);
            this.tbAtcCode.TabIndex = 13;
            // 
            // lblMNN
            // 
            this.lblMNN.AutoSize = true;
            this.lblMNN.Location = new System.Drawing.Point(12, 157);
            this.lblMNN.Name = "lblMNN";
            this.lblMNN.Size = new System.Drawing.Size(32, 13);
            this.lblMNN.TabIndex = 10;
            this.lblMNN.Text = "МНН";
            // 
            // tbMNN
            // 
            this.tbMNN.BackColor = System.Drawing.SystemColors.Window;
            this.tbMNN.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.qKLILicRequestDetailsBindingSource, "MNN", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbMNN.Location = new System.Drawing.Point(175, 153);
            this.tbMNN.Name = "tbMNN";
            this.tbMNN.ReadOnly = true;
            this.tbMNN.Size = new System.Drawing.Size(300, 20);
            this.tbMNN.TabIndex = 11;
            // 
            // lblQtyPack
            // 
            this.lblQtyPack.AutoSize = true;
            this.lblQtyPack.ForeColor = System.Drawing.Color.Brown;
            this.lblQtyPack.Location = new System.Drawing.Point(12, 128);
            this.lblQtyPack.Name = "lblQtyPack";
            this.lblQtyPack.Size = new System.Drawing.Size(125, 13);
            this.lblQtyPack.TabIndex = 8;
            this.lblQtyPack.Text = "Количество в упаковке";
            // 
            // tbQtyPack
            // 
            this.tbQtyPack.BackColor = System.Drawing.SystemColors.Info;
            this.tbQtyPack.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.qKLILicRequestDetailsBindingSource, "QtyPack", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbQtyPack.Location = new System.Drawing.Point(175, 124);
            this.tbQtyPack.Name = "tbQtyPack";
            this.tbQtyPack.Size = new System.Drawing.Size(300, 20);
            this.tbQtyPack.TabIndex = 9;
            // 
            // ImportLicenseRequestCreateItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 516);
            this.Controls.Add(this.lblQtyPack);
            this.Controls.Add(this.tbQtyPack);
            this.Controls.Add(this.lblMNN);
            this.Controls.Add(this.tbMNN);
            this.Controls.Add(this.lblAtcCode);
            this.Controls.Add(this.tbAtcCode);
            this.Controls.Add(this.lblManufacturerName);
            this.Controls.Add(this.tbManufacturerName);
            this.Controls.Add(this.lblManufacturerCountry);
            this.Controls.Add(this.tbManufacturerCountry);
            this.Controls.Add(this.lblVendorName);
            this.Controls.Add(this.tbVendorName);
            this.Controls.Add(this.lblVendorCountry);
            this.Controls.Add(this.tbVendorCountry);
            this.Controls.Add(this.lblVendorAddress);
            this.Controls.Add(this.tbVendorAddress);
            this.Controls.Add(this.lblNoReg);
            this.Controls.Add(this.tbNoReg);
            this.Controls.Add(this.lblDateEndReg);
            this.Controls.Add(this.tbDateEndReg);
            this.Controls.Add(this.lblGMP);
            this.Controls.Add(this.tbGMP);
            this.Controls.Add(this.lblGMPDateTo);
            this.Controls.Add(this.tbGMPDateTo);
            this.Controls.Add(this.lblDosage);
            this.Controls.Add(this.tbDosage);
            this.Controls.Add(this.lblReleaseForm);
            this.Controls.Add(this.tbReleaseForm);
            this.Controls.Add(this.lblItemName);
            this.Controls.Add(this.tbItemName);
            this.Controls.Add(this.lblItemID);
            this.Controls.Add(this.tbItemID);
            this.Name = "ImportLicenseRequestCreateItemForm";
            this.Text = "Создание товара для уведомления на обновление лицензии на импорт";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImportLicenseRequestCreateItemForm_FormClosing);
            this.Controls.SetChildIndex(this.tbItemID, 0);
            this.Controls.SetChildIndex(this.lblItemID, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.tbItemName, 0);
            this.Controls.SetChildIndex(this.lblItemName, 0);
            this.Controls.SetChildIndex(this.tbReleaseForm, 0);
            this.Controls.SetChildIndex(this.lblReleaseForm, 0);
            this.Controls.SetChildIndex(this.tbDosage, 0);
            this.Controls.SetChildIndex(this.lblDosage, 0);
            this.Controls.SetChildIndex(this.tbGMPDateTo, 0);
            this.Controls.SetChildIndex(this.lblGMPDateTo, 0);
            this.Controls.SetChildIndex(this.tbGMP, 0);
            this.Controls.SetChildIndex(this.lblGMP, 0);
            this.Controls.SetChildIndex(this.tbDateEndReg, 0);
            this.Controls.SetChildIndex(this.lblDateEndReg, 0);
            this.Controls.SetChildIndex(this.tbNoReg, 0);
            this.Controls.SetChildIndex(this.lblNoReg, 0);
            this.Controls.SetChildIndex(this.tbVendorAddress, 0);
            this.Controls.SetChildIndex(this.lblVendorAddress, 0);
            this.Controls.SetChildIndex(this.tbVendorCountry, 0);
            this.Controls.SetChildIndex(this.lblVendorCountry, 0);
            this.Controls.SetChildIndex(this.tbVendorName, 0);
            this.Controls.SetChildIndex(this.lblVendorName, 0);
            this.Controls.SetChildIndex(this.tbManufacturerCountry, 0);
            this.Controls.SetChildIndex(this.lblManufacturerCountry, 0);
            this.Controls.SetChildIndex(this.tbManufacturerName, 0);
            this.Controls.SetChildIndex(this.lblManufacturerName, 0);
            this.Controls.SetChildIndex(this.tbAtcCode, 0);
            this.Controls.SetChildIndex(this.lblAtcCode, 0);
            this.Controls.SetChildIndex(this.tbMNN, 0);
            this.Controls.SetChildIndex(this.lblMNN, 0);
            this.Controls.SetChildIndex(this.tbQtyPack, 0);
            this.Controls.SetChildIndex(this.lblQtyPack, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qKLILicRequestDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbItemID;
        private WMSOffice.Data.Quality quality;
        private System.Windows.Forms.BindingSource qKLILicRequestDetailsBindingSource;
        private WMSOffice.Data.QualityTableAdapters.QK_LI_LicRequest_DetailsTableAdapter qK_LI_LicRequest_DetailsTableAdapter;
        private System.Windows.Forms.Label lblItemID;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.TextBox tbItemName;
        private System.Windows.Forms.Label lblReleaseForm;
        private System.Windows.Forms.TextBox tbReleaseForm;
        private System.Windows.Forms.Label lblDosage;
        private System.Windows.Forms.TextBox tbDosage;
        private System.Windows.Forms.Label lblGMPDateTo;
        private System.Windows.Forms.TextBox tbGMPDateTo;
        private System.Windows.Forms.Label lblGMP;
        private System.Windows.Forms.TextBox tbGMP;
        private System.Windows.Forms.Label lblDateEndReg;
        private System.Windows.Forms.TextBox tbDateEndReg;
        private System.Windows.Forms.Label lblNoReg;
        private System.Windows.Forms.TextBox tbNoReg;
        private System.Windows.Forms.Label lblVendorAddress;
        private System.Windows.Forms.TextBox tbVendorAddress;
        private System.Windows.Forms.Label lblVendorCountry;
        private System.Windows.Forms.TextBox tbVendorCountry;
        private System.Windows.Forms.Label lblVendorName;
        private System.Windows.Forms.TextBox tbVendorName;
        private System.Windows.Forms.Label lblManufacturerCountry;
        private System.Windows.Forms.TextBox tbManufacturerCountry;
        private System.Windows.Forms.Label lblManufacturerName;
        private System.Windows.Forms.TextBox tbManufacturerName;
        private System.Windows.Forms.Label lblAtcCode;
        private System.Windows.Forms.TextBox tbAtcCode;
        private System.Windows.Forms.Label lblMNN;
        private System.Windows.Forms.TextBox tbMNN;
        private System.Windows.Forms.Label lblQtyPack;
        private System.Windows.Forms.TextBox tbQtyPack;
    }
}