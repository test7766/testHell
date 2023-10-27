namespace WMSOffice.Dialogs.Receive
{
    partial class PalletsAccountingControlCloseActsForm
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
            this.pnlOptionalButtons = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblcloseActInfo = new System.Windows.Forms.Label();
            this.tbsScanActs = new WMSOffice.Controls.TextBoxScaner();
            this.pnlOptionalButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlOptionalButtons
            // 
            this.pnlOptionalButtons.Controls.Add(this.btnClose);
            this.pnlOptionalButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlOptionalButtons.Location = new System.Drawing.Point(0, 77);
            this.pnlOptionalButtons.Name = "pnlOptionalButtons";
            this.pnlOptionalButtons.Size = new System.Drawing.Size(315, 35);
            this.pnlOptionalButtons.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(233, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Отмена";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.label1.Size = new System.Drawing.Size(212, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Отсканируйте штрих-код акта :";
            // 
            // lblcloseActInfo
            // 
            this.lblcloseActInfo.AutoSize = true;
            this.lblcloseActInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblcloseActInfo.ForeColor = System.Drawing.Color.Green;
            this.lblcloseActInfo.Location = new System.Drawing.Point(0, 51);
            this.lblcloseActInfo.Name = "lblcloseActInfo";
            this.lblcloseActInfo.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.lblcloseActInfo.Size = new System.Drawing.Size(3, 19);
            this.lblcloseActInfo.TabIndex = 3;
            // 
            // tbsScanActs
            // 
            this.tbsScanActs.AllowType = true;
            this.tbsScanActs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbsScanActs.AutoConvert = true;
            this.tbsScanActs.Location = new System.Drawing.Point(1, 27);
            this.tbsScanActs.Name = "tbsScanActs";
            this.tbsScanActs.ReadOnly = false;
            this.tbsScanActs.Size = new System.Drawing.Size(307, 25);
            this.tbsScanActs.TabIndex = 1;
            this.tbsScanActs.TextBoxBackColor = System.Drawing.SystemColors.Window;
            // 
            // PalletsAccountingControlCloseActsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(315, 112);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbsScanActs);
            this.Controls.Add(this.pnlOptionalButtons);
            this.Controls.Add(this.lblcloseActInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PalletsAccountingControlCloseActsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Прием актов";
            this.pnlOptionalButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlOptionalButtons;
        private System.Windows.Forms.Button btnClose;
        private WMSOffice.Controls.TextBoxScaner tbsScanActs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblcloseActInfo;
    }
}