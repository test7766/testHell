namespace WMSOffice.Dialogs.Quality
{
    partial class ImportLicenseItemRequestDocsFromPurchaseDepartmentForm
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
            this.gbDocs = new System.Windows.Forms.GroupBox();
            this.cbRequestRegDocTab = new System.Windows.Forms.CheckBox();
            this.cbRequestGmpDoc = new System.Windows.Forms.CheckBox();
            this.cbRequestRegDoc = new System.Windows.Forms.CheckBox();
            this.tbNote = new System.Windows.Forms.TextBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            this.gbDocs.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(-223, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(-133, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 228);
            this.pnlButtons.Size = new System.Drawing.Size(284, 43);
            this.pnlButtons.TabIndex = 4;
            // 
            // gbDocs
            // 
            this.gbDocs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDocs.Controls.Add(this.cbRequestRegDocTab);
            this.gbDocs.Controls.Add(this.cbRequestGmpDoc);
            this.gbDocs.Controls.Add(this.cbRequestRegDoc);
            this.gbDocs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbDocs.ForeColor = System.Drawing.Color.Brown;
            this.gbDocs.Location = new System.Drawing.Point(12, 19);
            this.gbDocs.Name = "gbDocs";
            this.gbDocs.Size = new System.Drawing.Size(260, 140);
            this.gbDocs.TabIndex = 1;
            this.gbDocs.TabStop = false;
            // 
            // cbRequestRegDocTab
            // 
            this.cbRequestRegDocTab.AutoSize = true;
            this.cbRequestRegDocTab.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbRequestRegDocTab.Location = new System.Drawing.Point(16, 101);
            this.cbRequestRegDocTab.Name = "cbRequestRegDocTab";
            this.cbRequestRegDocTab.Size = new System.Drawing.Size(183, 17);
            this.cbRequestRegDocTab.TabIndex = 2;
            this.cbRequestRegDocTab.Tag = "2";
            this.cbRequestRegDocTab.Text = "Вкладыш к рег. свидетельству";
            this.cbRequestRegDocTab.UseVisualStyleBackColor = true;
            // 
            // cbRequestGmpDoc
            // 
            this.cbRequestGmpDoc.AutoSize = true;
            this.cbRequestGmpDoc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbRequestGmpDoc.Location = new System.Drawing.Point(16, 65);
            this.cbRequestGmpDoc.Name = "cbRequestGmpDoc";
            this.cbRequestGmpDoc.Size = new System.Drawing.Size(50, 17);
            this.cbRequestGmpDoc.TabIndex = 1;
            this.cbRequestGmpDoc.Tag = "2";
            this.cbRequestGmpDoc.Text = "GMP";
            this.cbRequestGmpDoc.UseVisualStyleBackColor = true;
            // 
            // cbRequestRegDoc
            // 
            this.cbRequestRegDoc.AutoSize = true;
            this.cbRequestRegDoc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbRequestRegDoc.Location = new System.Drawing.Point(16, 30);
            this.cbRequestRegDoc.Name = "cbRequestRegDoc";
            this.cbRequestRegDoc.Size = new System.Drawing.Size(126, 17);
            this.cbRequestRegDoc.TabIndex = 0;
            this.cbRequestRegDoc.Tag = "0";
            this.cbRequestRegDoc.Text = "Рег. свидетельство";
            this.cbRequestRegDoc.UseVisualStyleBackColor = true;
            // 
            // tbNote
            // 
            this.tbNote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNote.Location = new System.Drawing.Point(12, 180);
            this.tbNote.Multiline = true;
            this.tbNote.Name = "tbNote";
            this.tbNote.Size = new System.Drawing.Size(260, 45);
            this.tbNote.TabIndex = 3;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.ForeColor = System.Drawing.Color.Brown;
            this.lblNote.Location = new System.Drawing.Point(12, 165);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(116, 13);
            this.lblNote.TabIndex = 2;
            this.lblNote.Text = "Укажите примечание";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Brown;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выберите тип документа";
            // 
            // ImportLicenseItemRequestDocsFromPurchaseDepartmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 271);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.tbNote);
            this.Controls.Add(this.gbDocs);
            this.Name = "ImportLicenseItemRequestDocsFromPurchaseDepartmentForm";
            this.Text = "Запросить документы у поставщика";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImportLicenseItemRequestDocsFromPurchaseDepartmentForm_FormClosing);
            this.Controls.SetChildIndex(this.gbDocs, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.tbNote, 0);
            this.Controls.SetChildIndex(this.lblNote, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.pnlButtons.ResumeLayout(false);
            this.gbDocs.ResumeLayout(false);
            this.gbDocs.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDocs;
        private System.Windows.Forms.TextBox tbNote;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbRequestRegDocTab;
        private System.Windows.Forms.CheckBox cbRequestGmpDoc;
        private System.Windows.Forms.CheckBox cbRequestRegDoc;
    }
}