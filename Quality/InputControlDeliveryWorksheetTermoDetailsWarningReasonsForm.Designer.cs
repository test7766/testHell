namespace WMSOffice.Dialogs.Quality
{
    partial class InputControlDeliveryWorksheetTermoDetailsWarningReasonsForm
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
            this.cmbReasons = new System.Windows.Forms.ComboBox();
            this.aPTemperatureReasonsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quality = new WMSOffice.Data.Quality();
            this.tbNote = new System.Windows.Forms.TextBox();
            this.lblCaption = new System.Windows.Forms.Label();
            this.lblNote = new System.Windows.Forms.Label();
            this.lblReasons = new System.Windows.Forms.Label();
            this.pbWarning = new System.Windows.Forms.PictureBox();
            this.aP_Temperature_ReasonsTableAdapter = new WMSOffice.Data.QualityTableAdapters.AP_Temperature_ReasonsTableAdapter();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aPTemperatureReasonsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWarning)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 202);
            this.pnlButtons.TabIndex = 5;
            // 
            // cmbReasons
            // 
            this.cmbReasons.DataSource = this.aPTemperatureReasonsBindingSource;
            this.cmbReasons.DisplayMember = "TemperatureReasons";
            this.cmbReasons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReasons.FormattingEnabled = true;
            this.cmbReasons.Location = new System.Drawing.Point(111, 90);
            this.cmbReasons.Name = "cmbReasons";
            this.cmbReasons.Size = new System.Drawing.Size(227, 21);
            this.cmbReasons.TabIndex = 2;
            this.cmbReasons.ValueMember = "ID";
            this.cmbReasons.SelectedValueChanged += new System.EventHandler(this.cmbReasons_SelectedValueChanged);
            // 
            // aPTemperatureReasonsBindingSource
            // 
            this.aPTemperatureReasonsBindingSource.DataMember = "AP_Temperature_Reasons";
            this.aPTemperatureReasonsBindingSource.DataSource = this.quality;
            // 
            // quality
            // 
            this.quality.DataSetName = "Quality";
            this.quality.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbNote
            // 
            this.tbNote.Location = new System.Drawing.Point(111, 131);
            this.tbNote.Multiline = true;
            this.tbNote.Name = "tbNote";
            this.tbNote.Size = new System.Drawing.Size(227, 59);
            this.tbNote.TabIndex = 4;
            // 
            // lblCaption
            // 
            this.lblCaption.Location = new System.Drawing.Point(111, 30);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(227, 30);
            this.lblCaption.TabIndex = 0;
            this.lblCaption.Text = "Зазначений показник температури не входить в допустимі межі";
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Location = new System.Drawing.Point(12, 131);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(60, 13);
            this.lblNote.TabIndex = 3;
            this.lblNote.Text = "Коментар:";
            // 
            // lblReasons
            // 
            this.lblReasons.AutoSize = true;
            this.lblReasons.Location = new System.Drawing.Point(12, 94);
            this.lblReasons.Name = "lblReasons";
            this.lblReasons.Size = new System.Drawing.Size(93, 13);
            this.lblReasons.TabIndex = 1;
            this.lblReasons.Text = "Вкажіть причину:";
            // 
            // pbWarning
            // 
            this.pbWarning.Image = global::WMSOffice.Properties.Resources.Achtung;
            this.pbWarning.Location = new System.Drawing.Point(12, 12);
            this.pbWarning.Name = "pbWarning";
            this.pbWarning.Size = new System.Drawing.Size(77, 67);
            this.pbWarning.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbWarning.TabIndex = 106;
            this.pbWarning.TabStop = false;
            // 
            // aP_Temperature_ReasonsTableAdapter
            // 
            this.aP_Temperature_ReasonsTableAdapter.ClearBeforeFill = true;
            // 
            // InputControlDeliveryWorksheetTermoDetailsWarningReasonsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 245);
            this.Controls.Add(this.pbWarning);
            this.Controls.Add(this.lblReasons);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.cmbReasons);
            this.Controls.Add(this.tbNote);
            this.Name = "InputControlDeliveryWorksheetTermoDetailsWarningReasonsForm";
            this.Text = "Підтвердження введення температури";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InputControlDeliveryWorksheetTermoDetailsWarningReasonsForm_FormClosing);
            this.Controls.SetChildIndex(this.tbNote, 0);
            this.Controls.SetChildIndex(this.cmbReasons, 0);
            this.Controls.SetChildIndex(this.lblCaption, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.lblNote, 0);
            this.Controls.SetChildIndex(this.lblReasons, 0);
            this.Controls.SetChildIndex(this.pbWarning, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.aPTemperatureReasonsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWarning)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbReasons;
        private System.Windows.Forms.TextBox tbNote;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Label lblReasons;
        private System.Windows.Forms.PictureBox pbWarning;
        private System.Windows.Forms.BindingSource aPTemperatureReasonsBindingSource;
        private WMSOffice.Data.Quality quality;
        private WMSOffice.Data.QualityTableAdapters.AP_Temperature_ReasonsTableAdapter aP_Temperature_ReasonsTableAdapter;
    }
}