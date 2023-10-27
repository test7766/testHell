namespace WMSOffice.Dialogs.Docs
{
    partial class ArchiveReturnedTareInvoiceFindForm
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
            this.tbDocNumber = new System.Windows.Forms.TextBox();
            this.lblDocNumber = new System.Windows.Forms.Label();
            this.tbDocTypeName = new System.Windows.Forms.TextBox();
            this.stbDocType = new WMSOffice.Controls.SearchTextBox();
            this.lblDocType = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(749, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(839, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 98);
            this.pnlButtons.Size = new System.Drawing.Size(494, 43);
            this.pnlButtons.TabIndex = 7;
            // 
            // tbDocNumber
            // 
            this.tbDocNumber.BackColor = System.Drawing.SystemColors.Window;
            this.tbDocNumber.Location = new System.Drawing.Point(113, 55);
            this.tbDocNumber.Name = "tbDocNumber";
            this.tbDocNumber.Size = new System.Drawing.Size(100, 20);
            this.tbDocNumber.TabIndex = 4;
            // 
            // lblDocNumber
            // 
            this.lblDocNumber.AutoSize = true;
            this.lblDocNumber.Location = new System.Drawing.Point(12, 59);
            this.lblDocNumber.Name = "lblDocNumber";
            this.lblDocNumber.Size = new System.Drawing.Size(78, 13);
            this.lblDocNumber.TabIndex = 3;
            this.lblDocNumber.Text = "№ документа:";
            // 
            // tbDocTypeName
            // 
            this.tbDocTypeName.BackColor = System.Drawing.SystemColors.Window;
            this.tbDocTypeName.Location = new System.Drawing.Point(219, 26);
            this.tbDocTypeName.Name = "tbDocTypeName";
            this.tbDocTypeName.ReadOnly = true;
            this.tbDocTypeName.Size = new System.Drawing.Size(263, 20);
            this.tbDocTypeName.TabIndex = 2;
            this.tbDocTypeName.TabStop = false;
            // 
            // stbDocType
            // 
            this.stbDocType.Location = new System.Drawing.Point(113, 26);
            this.stbDocType.Name = "stbDocType";
            this.stbDocType.ReadOnly = false;
            this.stbDocType.Size = new System.Drawing.Size(100, 20);
            this.stbDocType.TabIndex = 1;
            this.stbDocType.UserID = ((long)(0));
            this.stbDocType.Value = null;
            this.stbDocType.ValueReferenceQuery = null;
            // 
            // lblDocType
            // 
            this.lblDocType.AutoSize = true;
            this.lblDocType.Location = new System.Drawing.Point(12, 30);
            this.lblDocType.Name = "lblDocType";
            this.lblDocType.Size = new System.Drawing.Size(86, 13);
            this.lblDocType.TabIndex = 0;
            this.lblDocType.Text = "Тип документа:";
            // 
            // ArchiveReturnedTareInvoiceFindForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 141);
            this.Controls.Add(this.tbDocNumber);
            this.Controls.Add(this.lblDocNumber);
            this.Controls.Add(this.tbDocTypeName);
            this.Controls.Add(this.stbDocType);
            this.Controls.Add(this.lblDocType);
            this.Name = "ArchiveReturnedTareInvoiceFindForm";
            this.Text = "Поиск документа";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ArchiveInvoiceFindForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.lblDocType, 0);
            this.Controls.SetChildIndex(this.stbDocType, 0);
            this.Controls.SetChildIndex(this.tbDocTypeName, 0);
            this.Controls.SetChildIndex(this.lblDocNumber, 0);
            this.Controls.SetChildIndex(this.tbDocNumber, 0);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDocNumber;
        private System.Windows.Forms.Label lblDocNumber;
        private System.Windows.Forms.TextBox tbDocTypeName;
        private WMSOffice.Controls.SearchTextBox stbDocType;
        private System.Windows.Forms.Label lblDocType;
    }
}