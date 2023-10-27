namespace WMSOffice.Dialogs.Quality
{
    partial class CloseGlsRequestForReasonForm
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
            this.pbxStopRequest = new System.Windows.Forms.PictureBox();
            this.lblReason = new System.Windows.Forms.Label();
            this.lblDocNumber = new System.Windows.Forms.Label();
            this.lblDocDate = new System.Windows.Forms.Label();
            this.cmbReason = new System.Windows.Forms.ComboBox();
            this.bsQkGetConclusionTypes = new System.Windows.Forms.BindingSource(this.components);
            this.quality = new WMSOffice.Data.Quality();
            this.tbxDocNumber = new System.Windows.Forms.TextBox();
            this.dtpDocDate = new System.Windows.Forms.DateTimePicker();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.taQkGetConclusionTypes = new WMSOffice.Data.QualityTableAdapters.QK_Get_Conclusion_TypesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.pbxStopRequest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsQkGetConclusionTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxStopRequest
            // 
            this.pbxStopRequest.Image = global::WMSOffice.Properties.Resources.symbol_stop;
            this.pbxStopRequest.Location = new System.Drawing.Point(12, 12);
            this.pbxStopRequest.Name = "pbxStopRequest";
            this.pbxStopRequest.Size = new System.Drawing.Size(48, 48);
            this.pbxStopRequest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxStopRequest.TabIndex = 102;
            this.pbxStopRequest.TabStop = false;
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Location = new System.Drawing.Point(80, 12);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(105, 13);
            this.lblReason.TabIndex = 103;
            this.lblReason.Text = "Причина закриття:";
            // 
            // lblDocNumber
            // 
            this.lblDocNumber.AutoSize = true;
            this.lblDocNumber.Location = new System.Drawing.Point(80, 47);
            this.lblDocNumber.Name = "lblDocNumber";
            this.lblDocNumber.Size = new System.Drawing.Size(101, 13);
            this.lblDocNumber.TabIndex = 104;
            this.lblDocNumber.Text = "Номер документу:";
            // 
            // lblDocDate
            // 
            this.lblDocDate.AutoSize = true;
            this.lblDocDate.Location = new System.Drawing.Point(80, 84);
            this.lblDocDate.Name = "lblDocDate";
            this.lblDocDate.Size = new System.Drawing.Size(93, 13);
            this.lblDocDate.TabIndex = 105;
            this.lblDocDate.Text = "Дата документу:";
            // 
            // cmbReason
            // 
            this.cmbReason.DataSource = this.bsQkGetConclusionTypes;
            this.cmbReason.DisplayMember = "type_name";
            this.cmbReason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReason.FormattingEnabled = true;
            this.cmbReason.Location = new System.Drawing.Point(191, 9);
            this.cmbReason.Name = "cmbReason";
            this.cmbReason.Size = new System.Drawing.Size(146, 21);
            this.cmbReason.TabIndex = 10;
            this.cmbReason.ValueMember = "type_id";
            // 
            // bsQkGetConclusionTypes
            // 
            this.bsQkGetConclusionTypes.DataMember = "QK_Get_Conclusion_Types";
            this.bsQkGetConclusionTypes.DataSource = this.quality;
            // 
            // quality
            // 
            this.quality.DataSetName = "Quality";
            this.quality.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbxDocNumber
            // 
            this.tbxDocNumber.Location = new System.Drawing.Point(191, 44);
            this.tbxDocNumber.Name = "tbxDocNumber";
            this.tbxDocNumber.Size = new System.Drawing.Size(146, 20);
            this.tbxDocNumber.TabIndex = 20;
            // 
            // dtpDocDate
            // 
            this.dtpDocDate.Location = new System.Drawing.Point(191, 78);
            this.dtpDocDate.Name = "dtpDocDate";
            this.dtpDocDate.Size = new System.Drawing.Size(146, 20);
            this.dtpDocDate.TabIndex = 30;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(271, 118);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 50;
            this.btnCancel.Text = "Скасувати";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(190, 118);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 40;
            this.btnOk.Text = "ОК";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // taQkGetConclusionTypes
            // 
            this.taQkGetConclusionTypes.ClearBeforeFill = true;
            // 
            // CloseGlsRequestForReasonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(358, 153);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dtpDocDate);
            this.Controls.Add(this.tbxDocNumber);
            this.Controls.Add(this.cmbReason);
            this.Controls.Add(this.lblDocDate);
            this.Controls.Add(this.lblDocNumber);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.pbxStopRequest);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CloseGlsRequestForReasonForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Закриття рядків заяви з причини";
            this.Load += new System.EventHandler(this.CloseGlsRequestForReasonForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxStopRequest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsQkGetConclusionTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxStopRequest;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.Label lblDocNumber;
        private System.Windows.Forms.Label lblDocDate;
        private System.Windows.Forms.ComboBox cmbReason;
        private System.Windows.Forms.TextBox tbxDocNumber;
        private System.Windows.Forms.DateTimePicker dtpDocDate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.BindingSource bsQkGetConclusionTypes;
        private WMSOffice.Data.Quality quality;
        private WMSOffice.Data.QualityTableAdapters.QK_Get_Conclusion_TypesTableAdapter taQkGetConclusionTypes;
    }
}