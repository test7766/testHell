namespace WMSOffice.Dialogs.Quality
{
    partial class ImportLicenseSetConclusionForm
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
            this.lblConclusion = new System.Windows.Forms.Label();
            this.cmbConclusion = new System.Windows.Forms.ComboBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblConclusionDate = new System.Windows.Forms.Label();
            this.dtpConclusionDate = new System.Windows.Forms.DateTimePicker();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(489, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(579, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 88);
            this.pnlButtons.Size = new System.Drawing.Size(444, 43);
            this.pnlButtons.TabIndex = 6;
            // 
            // lblConclusion
            // 
            this.lblConclusion.AutoSize = true;
            this.lblConclusion.Location = new System.Drawing.Point(12, 12);
            this.lblConclusion.Name = "lblConclusion";
            this.lblConclusion.Size = new System.Drawing.Size(55, 13);
            this.lblConclusion.TabIndex = 0;
            this.lblConclusion.Text = "Решение:";
            // 
            // cmbConclusion
            // 
            this.cmbConclusion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbConclusion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConclusion.FormattingEnabled = true;
            this.cmbConclusion.Items.AddRange(new object[] {
            "Утвердить",
            "Отклонить"});
            this.cmbConclusion.Location = new System.Drawing.Point(93, 8);
            this.cmbConclusion.Name = "cmbConclusion";
            this.cmbConclusion.Size = new System.Drawing.Size(200, 21);
            this.cmbConclusion.TabIndex = 1;
            // 
            // tbDescription
            // 
            this.tbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDescription.Location = new System.Drawing.Point(93, 41);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(339, 45);
            this.tbDescription.TabIndex = 5;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 41);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(73, 13);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Примечание:";
            // 
            // lblConclusionDate
            // 
            this.lblConclusionDate.AutoSize = true;
            this.lblConclusionDate.Location = new System.Drawing.Point(308, 12);
            this.lblConclusionDate.Name = "lblConclusionDate";
            this.lblConclusionDate.Size = new System.Drawing.Size(18, 13);
            this.lblConclusionDate.TabIndex = 2;
            this.lblConclusionDate.Text = "от";
            // 
            // dtpConclusionDate
            // 
            this.dtpConclusionDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpConclusionDate.Location = new System.Drawing.Point(332, 8);
            this.dtpConclusionDate.Name = "dtpConclusionDate";
            this.dtpConclusionDate.Size = new System.Drawing.Size(100, 20);
            this.dtpConclusionDate.TabIndex = 3;
            // 
            // ImportLicenseSetConclusionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 131);
            this.Controls.Add(this.dtpConclusionDate);
            this.Controls.Add(this.lblConclusionDate);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.cmbConclusion);
            this.Controls.Add(this.lblConclusion);
            this.Name = "ImportLicenseSetConclusionForm";
            this.Text = "Внести решение по уведомлению на обновление лицензии на импорт";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImportLicenseSetConclusionForm_FormClosing);
            this.Controls.SetChildIndex(this.lblConclusion, 0);
            this.Controls.SetChildIndex(this.cmbConclusion, 0);
            this.Controls.SetChildIndex(this.tbDescription, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.lblDescription, 0);
            this.Controls.SetChildIndex(this.lblConclusionDate, 0);
            this.Controls.SetChildIndex(this.dtpConclusionDate, 0);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblConclusion;
        private System.Windows.Forms.ComboBox cmbConclusion;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblConclusionDate;
        private System.Windows.Forms.DateTimePicker dtpConclusionDate;
    }
}