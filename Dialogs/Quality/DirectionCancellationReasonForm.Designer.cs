namespace WMSOffice.Dialogs.Quality
{
    partial class DirectionCancellationReasonForm
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
            this.dRCancelReasonsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quality = new WMSOffice.Data.Quality();
            this.lblReasons = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.dRCancelReasonsTableAdapter = new WMSOffice.Data.QualityTableAdapters.DRCancelReasonsTableAdapter();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dRCancelReasonsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 102);
            this.pnlButtons.TabIndex = 4;
            // 
            // cmbReasons
            // 
            this.cmbReasons.DataSource = this.dRCancelReasonsBindingSource;
            this.cmbReasons.DisplayMember = "Reason_Name";
            this.cmbReasons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReasons.FormattingEnabled = true;
            this.cmbReasons.Location = new System.Drawing.Point(71, 8);
            this.cmbReasons.Name = "cmbReasons";
            this.cmbReasons.Size = new System.Drawing.Size(267, 21);
            this.cmbReasons.TabIndex = 1;
            this.cmbReasons.ValueMember = "Reason_ID";
            // 
            // dRCancelReasonsBindingSource
            // 
            this.dRCancelReasonsBindingSource.DataMember = "DRCancelReasons";
            this.dRCancelReasonsBindingSource.DataSource = this.quality;
            // 
            // quality
            // 
            this.quality.DataSetName = "Quality";
            this.quality.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblReasons
            // 
            this.lblReasons.AutoSize = true;
            this.lblReasons.Location = new System.Drawing.Point(12, 12);
            this.lblReasons.Name = "lblReasons";
            this.lblReasons.Size = new System.Drawing.Size(53, 13);
            this.lblReasons.TabIndex = 0;
            this.lblReasons.Text = "Причина:";
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(71, 41);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDescription.Size = new System.Drawing.Size(267, 50);
            this.tbDescription.TabIndex = 3;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 41);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(36, 13);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Опис:";
            // 
            // dRCancelReasonsTableAdapter
            // 
            this.dRCancelReasonsTableAdapter.ClearBeforeFill = true;
            // 
            // DirectionCancellationReasonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 145);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.lblReasons);
            this.Controls.Add(this.cmbReasons);
            this.Name = "DirectionCancellationReasonForm";
            this.Text = "Анулювання направлення";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DirectionCancellationReasonForm_FormClosing);
            this.Controls.SetChildIndex(this.cmbReasons, 0);
            this.Controls.SetChildIndex(this.lblReasons, 0);
            this.Controls.SetChildIndex(this.tbDescription, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.lblDescription, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dRCancelReasonsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbReasons;
        private System.Windows.Forms.Label lblReasons;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label lblDescription;
        private WMSOffice.Data.Quality quality;
        private System.Windows.Forms.BindingSource dRCancelReasonsBindingSource;
        private WMSOffice.Data.QualityTableAdapters.DRCancelReasonsTableAdapter dRCancelReasonsTableAdapter;
    }
}