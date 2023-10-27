namespace WMSOffice.Dialogs.PickControl
{
    partial class DebtorsReturnedTareAddDublicateDocDetailForm
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
            this.lblDriver = new System.Windows.Forms.Label();
            this.lblClientName = new System.Windows.Forms.Label();
            this.stbClient = new WMSOffice.Controls.SearchTextBox();
            this.lblClient = new System.Windows.Forms.Label();
            this.tbDriver = new System.Windows.Forms.TextBox();
            this.tbReason = new System.Windows.Forms.TextBox();
            this.lblReason = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(-55, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(35, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 148);
            this.pnlButtons.Size = new System.Drawing.Size(274, 43);
            this.pnlButtons.TabIndex = 7;
            // 
            // lblDriver
            // 
            this.lblDriver.AutoSize = true;
            this.lblDriver.Location = new System.Drawing.Point(5, 74);
            this.lblDriver.Name = "lblDriver";
            this.lblDriver.Size = new System.Drawing.Size(55, 13);
            this.lblDriver.TabIndex = 2;
            this.lblDriver.Text = "Водитель";
            // 
            // lblClientName
            // 
            this.lblClientName.AutoSize = true;
            this.lblClientName.Location = new System.Drawing.Point(66, 129);
            this.lblClientName.Name = "lblClientName";
            this.lblClientName.Size = new System.Drawing.Size(0, 13);
            this.lblClientName.TabIndex = 6;
            // 
            // stbClient
            // 
            this.stbClient.Location = new System.Drawing.Point(66, 106);
            this.stbClient.Name = "stbClient";
            this.stbClient.ReadOnly = false;
            this.stbClient.Size = new System.Drawing.Size(196, 20);
            this.stbClient.TabIndex = 5;
            this.stbClient.UserID = ((long)(0));
            this.stbClient.Value = null;
            this.stbClient.ValueReferenceQuery = null;
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Location = new System.Drawing.Point(5, 110);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(43, 13);
            this.lblClient.TabIndex = 4;
            this.lblClient.Text = "Клиент";
            // 
            // tbDriver
            // 
            this.tbDriver.Location = new System.Drawing.Point(66, 70);
            this.tbDriver.Name = "tbDriver";
            this.tbDriver.Size = new System.Drawing.Size(196, 20);
            this.tbDriver.TabIndex = 3;
            this.tbDriver.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbControl_KeyDown);
            // 
            // tbReason
            // 
            this.tbReason.Location = new System.Drawing.Point(66, 9);
            this.tbReason.Multiline = true;
            this.tbReason.Name = "tbReason";
            this.tbReason.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbReason.Size = new System.Drawing.Size(196, 45);
            this.tbReason.TabIndex = 1;
            this.tbReason.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbControl_KeyDown);
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Location = new System.Drawing.Point(5, 9);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(50, 13);
            this.lblReason.TabIndex = 0;
            this.lblReason.Text = "Причина";
            // 
            // DebtorsReturnedTareAddDublicateDocDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 191);
            this.Controls.Add(this.tbReason);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.tbDriver);
            this.Controls.Add(this.lblClientName);
            this.Controls.Add(this.stbClient);
            this.Controls.Add(this.lblClient);
            this.Controls.Add(this.lblDriver);
            this.Name = "DebtorsReturnedTareAddDublicateDocDetailForm";
            this.Text = "Регистрация дубля тары";
            this.Load += new System.EventHandler(this.DebtorsReturnedTareAddDublicateDocDetailForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DebtorsReturnedTareAddDublicateDocDetailForm_FormClosing);
            this.Controls.SetChildIndex(this.lblDriver, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.lblClient, 0);
            this.Controls.SetChildIndex(this.stbClient, 0);
            this.Controls.SetChildIndex(this.lblClientName, 0);
            this.Controls.SetChildIndex(this.tbDriver, 0);
            this.Controls.SetChildIndex(this.lblReason, 0);
            this.Controls.SetChildIndex(this.tbReason, 0);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDriver;
        private System.Windows.Forms.Label lblClientName;
        private WMSOffice.Controls.SearchTextBox stbClient;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.TextBox tbDriver;
        private System.Windows.Forms.TextBox tbReason;
        private System.Windows.Forms.Label lblReason;
    }
}