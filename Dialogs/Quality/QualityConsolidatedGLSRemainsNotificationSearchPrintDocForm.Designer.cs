namespace WMSOffice.Dialogs.Quality
{
    partial class QualityConsolidatedGLSRemainsNotificationSearchPrintDocForm
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
            this.stbWarehouse = new WMSOffice.Controls.SearchTextBox();
            this.lblWarehouse = new System.Windows.Forms.Label();
            this.lblWarehouseName = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(170, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(260, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 133);
            this.pnlButtons.Size = new System.Drawing.Size(349, 43);
            this.pnlButtons.TabIndex = 3;
            // 
            // stbWarehouse
            // 
            this.stbWarehouse.Location = new System.Drawing.Point(91, 56);
            this.stbWarehouse.Name = "stbWarehouse";
            this.stbWarehouse.NavigateByValue = false;
            this.stbWarehouse.ReadOnly = false;
            this.stbWarehouse.Size = new System.Drawing.Size(100, 20);
            this.stbWarehouse.TabIndex = 1;
            this.stbWarehouse.UserID = ((long)(0));
            this.stbWarehouse.Value = null;
            this.stbWarehouse.ValueReferenceQuery = null;
            // 
            // lblWarehouse
            // 
            this.lblWarehouse.AutoSize = true;
            this.lblWarehouse.Location = new System.Drawing.Point(12, 60);
            this.lblWarehouse.Name = "lblWarehouse";
            this.lblWarehouse.Size = new System.Drawing.Size(41, 13);
            this.lblWarehouse.TabIndex = 0;
            this.lblWarehouse.Text = "Склад:";
            // 
            // lblWarehouseName
            // 
            this.lblWarehouseName.AutoSize = true;
            this.lblWarehouseName.Location = new System.Drawing.Point(91, 79);
            this.lblWarehouseName.Name = "lblWarehouseName";
            this.lblWarehouseName.Size = new System.Drawing.Size(0, 13);
            this.lblWarehouseName.TabIndex = 2;
            // 
            // QualityConsolidatedGLSRemainsNotificationSearchPrintDocForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 176);
            this.Controls.Add(this.lblWarehouseName);
            this.Controls.Add(this.lblWarehouse);
            this.Controls.Add(this.stbWarehouse);
            this.Name = "QualityConsolidatedGLSRemainsNotificationSearchPrintDocForm";
            this.Text = "Критерии поиска уведомления";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QualityRegistrySearchPrintDocForm_FormClosing);
            this.Controls.SetChildIndex(this.stbWarehouse, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.lblWarehouse, 0);
            this.Controls.SetChildIndex(this.lblWarehouseName, 0);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WMSOffice.Controls.SearchTextBox stbWarehouse;
        private System.Windows.Forms.Label lblWarehouse;
        private System.Windows.Forms.Label lblWarehouseName;
    }
}