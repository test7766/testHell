namespace WMSOffice.Dialogs.Complaints
{
    partial class ShipReturnsToVendorAddShipmentMethodForm
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
            this.cmbShipmentTypes = new System.Windows.Forms.ComboBox();
            this.sVVRShipmentTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.complaints = new WMSOffice.Data.Complaints();
            this.lblShipmentType = new System.Windows.Forms.Label();
            this.sV_VR_Shipment_TypesTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.SV_VR_Shipment_TypesTableAdapter();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlNPContent = new System.Windows.Forms.Panel();
            this.tbDeclarationNumberNP = new System.Windows.Forms.TextBox();
            this.lblDeclarationNumberNP = new System.Windows.Forms.Label();
            this.pnlSelfDeliveryContent = new System.Windows.Forms.Panel();
            this.tbAttorneyNumberSD = new System.Windows.Forms.TextBox();
            this.tbCarNumberSD = new System.Windows.Forms.TextBox();
            this.tbDriverNameSD = new System.Windows.Forms.TextBox();
            this.lblAttorneyNumberSD = new System.Windows.Forms.Label();
            this.lblDriverNameSD = new System.Windows.Forms.Label();
            this.lblCarNumberSD = new System.Windows.Forms.Label();
            this.pnlExpeditionContent = new System.Windows.Forms.Panel();
            this.tbAttorneyNumberE = new System.Windows.Forms.TextBox();
            this.tbCarNumberE = new System.Windows.Forms.TextBox();
            this.tbDriverNameE = new System.Windows.Forms.TextBox();
            this.lblAttorneyNumberE = new System.Windows.Forms.Label();
            this.lblDriverNameE = new System.Windows.Forms.Label();
            this.lblCarNumberE = new System.Windows.Forms.Label();
            this.lblPrintDate = new System.Windows.Forms.Label();
            this.dtpPrintDate = new System.Windows.Forms.DateTimePicker();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sVVRShipmentTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).BeginInit();
            this.pnlContent.SuspendLayout();
            this.pnlNPContent.SuspendLayout();
            this.pnlSelfDeliveryContent.SuspendLayout();
            this.pnlExpeditionContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 268);
            this.pnlButtons.TabIndex = 5;
            // 
            // cmbShipmentTypes
            // 
            this.cmbShipmentTypes.DataSource = this.sVVRShipmentTypesBindingSource;
            this.cmbShipmentTypes.DisplayMember = "Type_Name";
            this.cmbShipmentTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShipmentTypes.FormattingEnabled = true;
            this.cmbShipmentTypes.Location = new System.Drawing.Point(111, 26);
            this.cmbShipmentTypes.Name = "cmbShipmentTypes";
            this.cmbShipmentTypes.Size = new System.Drawing.Size(227, 21);
            this.cmbShipmentTypes.TabIndex = 1;
            this.cmbShipmentTypes.ValueMember = "Type_ID";
            // 
            // sVVRShipmentTypesBindingSource
            // 
            this.sVVRShipmentTypesBindingSource.DataMember = "SV_VR_Shipment_Types";
            this.sVVRShipmentTypesBindingSource.DataSource = this.complaints;
            // 
            // complaints
            // 
            this.complaints.DataSetName = "Complaints";
            this.complaints.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblShipmentType
            // 
            this.lblShipmentType.AutoSize = true;
            this.lblShipmentType.Location = new System.Drawing.Point(12, 30);
            this.lblShipmentType.Name = "lblShipmentType";
            this.lblShipmentType.Size = new System.Drawing.Size(93, 13);
            this.lblShipmentType.TabIndex = 0;
            this.lblShipmentType.Text = "Метод отгрузки :";
            // 
            // sV_VR_Shipment_TypesTableAdapter
            // 
            this.sV_VR_Shipment_TypesTableAdapter.ClearBeforeFill = true;
            // 
            // pnlContent
            // 
            this.pnlContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlContent.Controls.Add(this.pnlNPContent);
            this.pnlContent.Controls.Add(this.pnlSelfDeliveryContent);
            this.pnlContent.Controls.Add(this.pnlExpeditionContent);
            this.pnlContent.Location = new System.Drawing.Point(15, 74);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(323, 129);
            this.pnlContent.TabIndex = 2;
            // 
            // pnlNPContent
            // 
            this.pnlNPContent.Controls.Add(this.tbDeclarationNumberNP);
            this.pnlNPContent.Controls.Add(this.lblDeclarationNumberNP);
            this.pnlNPContent.Location = new System.Drawing.Point(76, 16);
            this.pnlNPContent.Name = "pnlNPContent";
            this.pnlNPContent.Size = new System.Drawing.Size(55, 52);
            this.pnlNPContent.TabIndex = 1;
            this.pnlNPContent.Tag = "2";
            this.pnlNPContent.Visible = false;
            // 
            // tbDeclarationNumberNP
            // 
            this.tbDeclarationNumberNP.Location = new System.Drawing.Point(123, 16);
            this.tbDeclarationNumberNP.Name = "tbDeclarationNumberNP";
            this.tbDeclarationNumberNP.Size = new System.Drawing.Size(180, 20);
            this.tbDeclarationNumberNP.TabIndex = 1;
            this.tbDeclarationNumberNP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbInfoField_KeyDown);
            // 
            // lblDeclarationNumberNP
            // 
            this.lblDeclarationNumberNP.AutoSize = true;
            this.lblDeclarationNumberNP.Location = new System.Drawing.Point(18, 20);
            this.lblDeclarationNumberNP.Name = "lblDeclarationNumberNP";
            this.lblDeclarationNumberNP.Size = new System.Drawing.Size(87, 13);
            this.lblDeclarationNumberNP.TabIndex = 0;
            this.lblDeclarationNumberNP.Text = "№ декларации :";
            // 
            // pnlSelfDeliveryContent
            // 
            this.pnlSelfDeliveryContent.Controls.Add(this.tbAttorneyNumberSD);
            this.pnlSelfDeliveryContent.Controls.Add(this.tbCarNumberSD);
            this.pnlSelfDeliveryContent.Controls.Add(this.tbDriverNameSD);
            this.pnlSelfDeliveryContent.Controls.Add(this.lblAttorneyNumberSD);
            this.pnlSelfDeliveryContent.Controls.Add(this.lblDriverNameSD);
            this.pnlSelfDeliveryContent.Controls.Add(this.lblCarNumberSD);
            this.pnlSelfDeliveryContent.Location = new System.Drawing.Point(5, 16);
            this.pnlSelfDeliveryContent.Name = "pnlSelfDeliveryContent";
            this.pnlSelfDeliveryContent.Size = new System.Drawing.Size(55, 52);
            this.pnlSelfDeliveryContent.TabIndex = 0;
            this.pnlSelfDeliveryContent.Tag = "1";
            this.pnlSelfDeliveryContent.Visible = false;
            // 
            // tbAttorneyNumberSD
            // 
            this.tbAttorneyNumberSD.Location = new System.Drawing.Point(123, 90);
            this.tbAttorneyNumberSD.Name = "tbAttorneyNumberSD";
            this.tbAttorneyNumberSD.Size = new System.Drawing.Size(180, 20);
            this.tbAttorneyNumberSD.TabIndex = 5;
            this.tbAttorneyNumberSD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbInfoField_KeyDown);
            // 
            // tbCarNumberSD
            // 
            this.tbCarNumberSD.Location = new System.Drawing.Point(123, 16);
            this.tbCarNumberSD.Name = "tbCarNumberSD";
            this.tbCarNumberSD.Size = new System.Drawing.Size(180, 20);
            this.tbCarNumberSD.TabIndex = 1;
            this.tbCarNumberSD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbInfoField_KeyDown);
            // 
            // tbDriverNameSD
            // 
            this.tbDriverNameSD.Location = new System.Drawing.Point(123, 53);
            this.tbDriverNameSD.Name = "tbDriverNameSD";
            this.tbDriverNameSD.Size = new System.Drawing.Size(180, 20);
            this.tbDriverNameSD.TabIndex = 3;
            this.tbDriverNameSD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbInfoField_KeyDown);
            // 
            // lblAttorneyNumberSD
            // 
            this.lblAttorneyNumberSD.AutoSize = true;
            this.lblAttorneyNumberSD.Location = new System.Drawing.Point(18, 94);
            this.lblAttorneyNumberSD.Name = "lblAttorneyNumberSD";
            this.lblAttorneyNumberSD.Size = new System.Drawing.Size(98, 13);
            this.lblAttorneyNumberSD.TabIndex = 4;
            this.lblAttorneyNumberSD.Text = "№ доверенности :";
            // 
            // lblDriverNameSD
            // 
            this.lblDriverNameSD.AutoSize = true;
            this.lblDriverNameSD.Location = new System.Drawing.Point(18, 57);
            this.lblDriverNameSD.Name = "lblDriverNameSD";
            this.lblDriverNameSD.Size = new System.Drawing.Size(99, 13);
            this.lblDriverNameSD.TabIndex = 2;
            this.lblDriverNameSD.Text = "Ф.И.О. водителя :";
            // 
            // lblCarNumberSD
            // 
            this.lblCarNumberSD.AutoSize = true;
            this.lblCarNumberSD.Location = new System.Drawing.Point(18, 20);
            this.lblCarNumberSD.Name = "lblCarNumberSD";
            this.lblCarNumberSD.Size = new System.Drawing.Size(88, 13);
            this.lblCarNumberSD.TabIndex = 0;
            this.lblCarNumberSD.Text = "№ автомобиля :";
            // 
            // pnlExpeditionContent
            // 
            this.pnlExpeditionContent.Controls.Add(this.tbAttorneyNumberE);
            this.pnlExpeditionContent.Controls.Add(this.tbCarNumberE);
            this.pnlExpeditionContent.Controls.Add(this.tbDriverNameE);
            this.pnlExpeditionContent.Controls.Add(this.lblAttorneyNumberE);
            this.pnlExpeditionContent.Controls.Add(this.lblDriverNameE);
            this.pnlExpeditionContent.Controls.Add(this.lblCarNumberE);
            this.pnlExpeditionContent.Location = new System.Drawing.Point(147, 16);
            this.pnlExpeditionContent.Name = "pnlExpeditionContent";
            this.pnlExpeditionContent.Size = new System.Drawing.Size(55, 52);
            this.pnlExpeditionContent.TabIndex = 2;
            this.pnlExpeditionContent.Tag = "3";
            this.pnlExpeditionContent.Visible = false;
            // 
            // tbAttorneyNumberE
            // 
            this.tbAttorneyNumberE.Location = new System.Drawing.Point(123, 90);
            this.tbAttorneyNumberE.Name = "tbAttorneyNumberE";
            this.tbAttorneyNumberE.Size = new System.Drawing.Size(180, 20);
            this.tbAttorneyNumberE.TabIndex = 5;
            this.tbAttorneyNumberE.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbInfoField_KeyDown);
            // 
            // tbCarNumberE
            // 
            this.tbCarNumberE.Location = new System.Drawing.Point(123, 16);
            this.tbCarNumberE.Name = "tbCarNumberE";
            this.tbCarNumberE.Size = new System.Drawing.Size(180, 20);
            this.tbCarNumberE.TabIndex = 1;
            this.tbCarNumberE.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbInfoField_KeyDown);
            // 
            // tbDriverNameE
            // 
            this.tbDriverNameE.Location = new System.Drawing.Point(123, 53);
            this.tbDriverNameE.Name = "tbDriverNameE";
            this.tbDriverNameE.Size = new System.Drawing.Size(180, 20);
            this.tbDriverNameE.TabIndex = 3;
            this.tbDriverNameE.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbInfoField_KeyDown);
            // 
            // lblAttorneyNumberE
            // 
            this.lblAttorneyNumberE.AutoSize = true;
            this.lblAttorneyNumberE.Location = new System.Drawing.Point(18, 94);
            this.lblAttorneyNumberE.Name = "lblAttorneyNumberE";
            this.lblAttorneyNumberE.Size = new System.Drawing.Size(98, 13);
            this.lblAttorneyNumberE.TabIndex = 4;
            this.lblAttorneyNumberE.Text = "№ доверенности :";
            // 
            // lblDriverNameE
            // 
            this.lblDriverNameE.AutoSize = true;
            this.lblDriverNameE.Location = new System.Drawing.Point(18, 57);
            this.lblDriverNameE.Name = "lblDriverNameE";
            this.lblDriverNameE.Size = new System.Drawing.Size(99, 13);
            this.lblDriverNameE.TabIndex = 2;
            this.lblDriverNameE.Text = "Ф.И.О. водителя :";
            // 
            // lblCarNumberE
            // 
            this.lblCarNumberE.AutoSize = true;
            this.lblCarNumberE.Location = new System.Drawing.Point(18, 20);
            this.lblCarNumberE.Name = "lblCarNumberE";
            this.lblCarNumberE.Size = new System.Drawing.Size(88, 13);
            this.lblCarNumberE.TabIndex = 0;
            this.lblCarNumberE.Text = "№ автомобиля :";
            // 
            // lblPrintDate
            // 
            this.lblPrintDate.AutoSize = true;
            this.lblPrintDate.Location = new System.Drawing.Point(12, 235);
            this.lblPrintDate.Name = "lblPrintDate";
            this.lblPrintDate.Size = new System.Drawing.Size(76, 13);
            this.lblPrintDate.TabIndex = 3;
            this.lblPrintDate.Text = "Дата печати :";
            // 
            // dtpPrintDate
            // 
            this.dtpPrintDate.Checked = false;
            this.dtpPrintDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPrintDate.Location = new System.Drawing.Point(111, 231);
            this.dtpPrintDate.Name = "dtpPrintDate";
            this.dtpPrintDate.ShowCheckBox = true;
            this.dtpPrintDate.Size = new System.Drawing.Size(100, 20);
            this.dtpPrintDate.TabIndex = 4;
            this.dtpPrintDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbInfoField_KeyDown);
            // 
            // ShipReturnsToVendorAddShipmentMethodForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 311);
            this.Controls.Add(this.dtpPrintDate);
            this.Controls.Add(this.lblPrintDate);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.cmbShipmentTypes);
            this.Controls.Add(this.lblShipmentType);
            this.Name = "ShipReturnsToVendorAddShipmentMethodForm";
            this.Text = "Метод отгрузки возвратов";
            this.Load += new System.EventHandler(this.ShipReturnsToVendorAddShipmentDoc_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShipReturnsToVendorAddShipmentDoc_FormClosing);
            this.Controls.SetChildIndex(this.lblShipmentType, 0);
            this.Controls.SetChildIndex(this.cmbShipmentTypes, 0);
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.lblPrintDate, 0);
            this.Controls.SetChildIndex(this.dtpPrintDate, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sVVRShipmentTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).EndInit();
            this.pnlContent.ResumeLayout(false);
            this.pnlNPContent.ResumeLayout(false);
            this.pnlNPContent.PerformLayout();
            this.pnlSelfDeliveryContent.ResumeLayout(false);
            this.pnlSelfDeliveryContent.PerformLayout();
            this.pnlExpeditionContent.ResumeLayout(false);
            this.pnlExpeditionContent.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbShipmentTypes;
        private System.Windows.Forms.Label lblShipmentType;
        private WMSOffice.Data.Complaints complaints;
        private System.Windows.Forms.BindingSource sVVRShipmentTypesBindingSource;
        private WMSOffice.Data.ComplaintsTableAdapters.SV_VR_Shipment_TypesTableAdapter sV_VR_Shipment_TypesTableAdapter;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlSelfDeliveryContent;
        private System.Windows.Forms.Label lblAttorneyNumberSD;
        private System.Windows.Forms.Label lblDriverNameSD;
        private System.Windows.Forms.Label lblCarNumberSD;
        private System.Windows.Forms.TextBox tbAttorneyNumberSD;
        private System.Windows.Forms.TextBox tbCarNumberSD;
        private System.Windows.Forms.TextBox tbDriverNameSD;
        private System.Windows.Forms.Panel pnlExpeditionContent;
        private System.Windows.Forms.TextBox tbAttorneyNumberE;
        private System.Windows.Forms.TextBox tbCarNumberE;
        private System.Windows.Forms.TextBox tbDriverNameE;
        private System.Windows.Forms.Label lblAttorneyNumberE;
        private System.Windows.Forms.Label lblDriverNameE;
        private System.Windows.Forms.Label lblCarNumberE;
        private System.Windows.Forms.Panel pnlNPContent;
        private System.Windows.Forms.TextBox tbDeclarationNumberNP;
        private System.Windows.Forms.Label lblDeclarationNumberNP;
        private System.Windows.Forms.Label lblPrintDate;
        private System.Windows.Forms.DateTimePicker dtpPrintDate;
    }
}