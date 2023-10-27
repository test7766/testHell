namespace WMSOffice.Dialogs.Quality
{
    partial class SetConclusionForm
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
            this.pbSert = new System.Windows.Forms.PictureBox();
            this.lblNumber = new System.Windows.Forms.Label();
            this.tbxNumber = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblResult = new System.Windows.Forms.Label();
            this.cmbResult = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.quality = new WMSOffice.Data.Quality();
            this.bsQkGetConclusionTypes = new System.Windows.Forms.BindingSource(this.components);
            this.taQkGetConclusionTypes = new WMSOffice.Data.QualityTableAdapters.QK_Get_Conclusion_TypesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.pbSert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsQkGetConclusionTypes)).BeginInit();
            this.SuspendLayout();
            // 
            // pbSert
            // 
            this.pbSert.Image = global::WMSOffice.Properties.Resources.document_certificate;
            this.pbSert.Location = new System.Drawing.Point(12, 12);
            this.pbSert.Name = "pbSert";
            this.pbSert.Size = new System.Drawing.Size(48, 48);
            this.pbSert.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSert.TabIndex = 101;
            this.pbSert.TabStop = false;
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(66, 15);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(108, 13);
            this.lblNumber.TabIndex = 102;
            this.lblNumber.Text = "Номер висновку:";
            // 
            // tbxNumber
            // 
            this.tbxNumber.Location = new System.Drawing.Point(189, 12);
            this.tbxNumber.Name = "tbxNumber";
            this.tbxNumber.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxNumber.Size = new System.Drawing.Size(153, 20);
            this.tbxNumber.TabIndex = 10;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(66, 42);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(100, 13);
            this.lblDate.TabIndex = 103;
            this.lblDate.Text = "Дата висновку:";
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(189, 38);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(153, 20);
            this.dtpDate.TabIndex = 20;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(66, 72);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(98, 13);
            this.lblResult.TabIndex = 104;
            this.lblResult.Text = "Результат висновку:";
            // 
            // cmbResult
            // 
            this.cmbResult.DataSource = this.bsQkGetConclusionTypes;
            this.cmbResult.DisplayMember = "type_name";
            this.cmbResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResult.FormattingEnabled = true;
            this.cmbResult.Location = new System.Drawing.Point(189, 69);
            this.cmbResult.Name = "cmbResult";
            this.cmbResult.Size = new System.Drawing.Size(153, 21);
            this.cmbResult.TabIndex = 30;
            this.cmbResult.ValueMember = "type_id";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(267, 104);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 50;
            this.btnCancel.Text = "Скасувати";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(186, 104);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 40;
            this.btnOk.Text = "ОК";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // quality
            // 
            this.quality.DataSetName = "Quality";
            this.quality.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bsQkGetConclusionTypes
            // 
            this.bsQkGetConclusionTypes.DataMember = "QK_Get_Conclusion_Types";
            this.bsQkGetConclusionTypes.DataSource = this.quality;
            // 
            // taQkGetConclusionTypes
            // 
            this.taQkGetConclusionTypes.ClearBeforeFill = true;
            // 
            // SetConclusionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(354, 139);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cmbResult);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.tbxNumber);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.pbSert);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SetConclusionForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Отриман висновок";
            this.Load += new System.EventHandler(this.SetConclusionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbSert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsQkGetConclusionTypes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbSert;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.TextBox tbxNumber;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.ComboBox cmbResult;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.BindingSource bsQkGetConclusionTypes;
        private WMSOffice.Data.Quality quality;
        private WMSOffice.Data.QualityTableAdapters.QK_Get_Conclusion_TypesTableAdapter taQkGetConclusionTypes;
    }
}