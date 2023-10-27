namespace WMSOffice.Dialogs.Quality
{
    partial class QualityInpectionDetailsEditForm
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
            this.lblInspectionPlaces = new System.Windows.Forms.Label();
            this.cmbInspectionPlaces = new System.Windows.Forms.ComboBox();
            this.qKICDPlaceInspectionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quality = new WMSOffice.Data.Quality();
            this.dtpPlanReceiptDate = new System.Windows.Forms.DateTimePicker();
            this.lblPlanReceiptDate = new System.Windows.Forms.Label();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.qK_ICD_Place_InspectionsTableAdapter = new WMSOffice.Data.QualityTableAdapters.QK_ICD_Place_InspectionsTableAdapter();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qKICDPlaceInspectionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(245, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(335, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 110);
            this.pnlButtons.Size = new System.Drawing.Size(374, 43);
            this.pnlButtons.TabIndex = 4;
            // 
            // lblInspectionPlaces
            // 
            this.lblInspectionPlaces.Location = new System.Drawing.Point(93, 12);
            this.lblInspectionPlaces.Name = "lblInspectionPlaces";
            this.lblInspectionPlaces.Size = new System.Drawing.Size(109, 37);
            this.lblInspectionPlaces.TabIndex = 0;
            this.lblInspectionPlaces.Text = "Місце проведення інспекції:";
            // 
            // cmbInspectionPlaces
            // 
            this.cmbInspectionPlaces.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbInspectionPlaces.DataSource = this.qKICDPlaceInspectionsBindingSource;
            this.cmbInspectionPlaces.DisplayMember = "InspectDesc";
            this.cmbInspectionPlaces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInspectionPlaces.FormattingEnabled = true;
            this.cmbInspectionPlaces.Location = new System.Drawing.Point(207, 12);
            this.cmbInspectionPlaces.Name = "cmbInspectionPlaces";
            this.cmbInspectionPlaces.Size = new System.Drawing.Size(155, 21);
            this.cmbInspectionPlaces.TabIndex = 1;
            this.cmbInspectionPlaces.ValueMember = "InspectID";
            // 
            // qKICDPlaceInspectionsBindingSource
            // 
            this.qKICDPlaceInspectionsBindingSource.DataMember = "QK_ICD_Place_Inspections";
            this.qKICDPlaceInspectionsBindingSource.DataSource = this.quality;
            // 
            // quality
            // 
            this.quality.DataSetName = "Quality";
            this.quality.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dtpPlanReceiptDate
            // 
            this.dtpPlanReceiptDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpPlanReceiptDate.CustomFormat = "dd.MM.yyyy";
            this.dtpPlanReceiptDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPlanReceiptDate.Location = new System.Drawing.Point(207, 62);
            this.dtpPlanReceiptDate.Name = "dtpPlanReceiptDate";
            this.dtpPlanReceiptDate.Size = new System.Drawing.Size(155, 20);
            this.dtpPlanReceiptDate.TabIndex = 3;
            // 
            // lblPlanReceiptDate
            // 
            this.lblPlanReceiptDate.Location = new System.Drawing.Point(96, 45);
            this.lblPlanReceiptDate.Name = "lblPlanReceiptDate";
            this.lblPlanReceiptDate.Size = new System.Drawing.Size(109, 37);
            this.lblPlanReceiptDate.TabIndex = 2;
            this.lblPlanReceiptDate.Text = "Очікувана дата приходу:";
            this.lblPlanReceiptDate.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // pbImage
            // 
            this.pbImage.Image = global::WMSOffice.Properties.Resources.symbol_stop;
            this.pbImage.Location = new System.Drawing.Point(12, 12);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(70, 70);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImage.TabIndex = 105;
            this.pbImage.TabStop = false;
            // 
            // qK_ICD_Place_InspectionsTableAdapter
            // 
            this.qK_ICD_Place_InspectionsTableAdapter.ClearBeforeFill = true;
            // 
            // QualityInpectionDetailsEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 153);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.lblPlanReceiptDate);
            this.Controls.Add(this.cmbInspectionPlaces);
            this.Controls.Add(this.dtpPlanReceiptDate);
            this.Controls.Add(this.lblInspectionPlaces);
            this.Name = "QualityInpectionDetailsEditForm";
            this.Text = "Деталі інспекції";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QualityInpectionDetailsEditForm_FormClosing);
            this.Controls.SetChildIndex(this.lblInspectionPlaces, 0);
            this.Controls.SetChildIndex(this.dtpPlanReceiptDate, 0);
            this.Controls.SetChildIndex(this.cmbInspectionPlaces, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.lblPlanReceiptDate, 0);
            this.Controls.SetChildIndex(this.pbImage, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qKICDPlaceInspectionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblInspectionPlaces;
        private System.Windows.Forms.ComboBox cmbInspectionPlaces;
        private System.Windows.Forms.DateTimePicker dtpPlanReceiptDate;
        private System.Windows.Forms.Label lblPlanReceiptDate;
        private System.Windows.Forms.PictureBox pbImage;
        private WMSOffice.Data.Quality quality;
        private System.Windows.Forms.BindingSource qKICDPlaceInspectionsBindingSource;
        private WMSOffice.Data.QualityTableAdapters.QK_ICD_Place_InspectionsTableAdapter qK_ICD_Place_InspectionsTableAdapter;
    }
}