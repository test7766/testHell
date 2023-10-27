namespace WMSOffice.Dialogs.WH.TSD
{
    partial class TSD_SettingsForm
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
            this.stbTSD = new WMSOffice.Controls.SearchTextBox();
            this.lblTSD = new System.Windows.Forms.Label();
            this.tbTSD = new System.Windows.Forms.TextBox();
            this.lblInventoryNumber = new System.Windows.Forms.Label();
            this.tbInventoryNumber = new System.Windows.Forms.TextBox();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 113);
            this.pnlButtons.TabIndex = 5;
            // 
            // stbTSD
            // 
            this.stbTSD.Location = new System.Drawing.Point(71, 28);
            this.stbTSD.Name = "stbTSD";
            this.stbTSD.ReadOnly = false;
            this.stbTSD.Size = new System.Drawing.Size(100, 20);
            this.stbTSD.TabIndex = 1;
            this.stbTSD.UserID = ((long)(0));
            this.stbTSD.Value = null;
            this.stbTSD.ValueReferenceQuery = null;
            // 
            // lblTSD
            // 
            this.lblTSD.AutoSize = true;
            this.lblTSD.Location = new System.Drawing.Point(13, 32);
            this.lblTSD.Name = "lblTSD";
            this.lblTSD.Size = new System.Drawing.Size(36, 13);
            this.lblTSD.TabIndex = 0;
            this.lblTSD.Text = "ТСД :";
            // 
            // tbTSD
            // 
            this.tbTSD.BackColor = System.Drawing.SystemColors.Window;
            this.tbTSD.Location = new System.Drawing.Point(179, 28);
            this.tbTSD.Name = "tbTSD";
            this.tbTSD.ReadOnly = true;
            this.tbTSD.Size = new System.Drawing.Size(159, 20);
            this.tbTSD.TabIndex = 2;
            // 
            // lblInventoryNumber
            // 
            this.lblInventoryNumber.AutoSize = true;
            this.lblInventoryNumber.Location = new System.Drawing.Point(13, 69);
            this.lblInventoryNumber.Name = "lblInventoryNumber";
            this.lblInventoryNumber.Size = new System.Drawing.Size(50, 13);
            this.lblInventoryNumber.TabIndex = 3;
            this.lblInventoryNumber.Text = "Инв. № :";
            // 
            // tbInventoryNumber
            // 
            this.tbInventoryNumber.Location = new System.Drawing.Point(71, 66);
            this.tbInventoryNumber.Name = "tbInventoryNumber";
            this.tbInventoryNumber.Size = new System.Drawing.Size(100, 20);
            this.tbInventoryNumber.TabIndex = 4;
            // 
            // TSD_SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 156);
            this.Controls.Add(this.tbInventoryNumber);
            this.Controls.Add(this.lblInventoryNumber);
            this.Controls.Add(this.lblTSD);
            this.Controls.Add(this.tbTSD);
            this.Controls.Add(this.stbTSD);
            this.Name = "TSD_SettingsForm";
            this.Text = "Параметры ТСД";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TSD_SettingsForm_FormClosing);
            this.Controls.SetChildIndex(this.stbTSD, 0);
            this.Controls.SetChildIndex(this.tbTSD, 0);
            this.Controls.SetChildIndex(this.lblTSD, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.lblInventoryNumber, 0);
            this.Controls.SetChildIndex(this.tbInventoryNumber, 0);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WMSOffice.Controls.SearchTextBox stbTSD;
        private System.Windows.Forms.Label lblTSD;
        private System.Windows.Forms.TextBox tbTSD;
        private System.Windows.Forms.Label lblInventoryNumber;
        private System.Windows.Forms.TextBox tbInventoryNumber;
    }
}