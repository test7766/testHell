namespace WMSOffice.Dialogs.WH
{
    partial class EnterSignaturerForDiscountAct
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
            this.lblEnterSignaturer = new System.Windows.Forms.Label();
            this.tbxSignaturer = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblEnterSignaturer
            // 
            this.lblEnterSignaturer.AutoSize = true;
            this.lblEnterSignaturer.Location = new System.Drawing.Point(12, 9);
            this.lblEnterSignaturer.Name = "lblEnterSignaturer";
            this.lblEnterSignaturer.Size = new System.Drawing.Size(225, 13);
            this.lblEnterSignaturer.TabIndex = 0;
            this.lblEnterSignaturer.Text = "Введите подписанта со стороны дебитора:";
            // 
            // tbxSignaturer
            // 
            this.tbxSignaturer.Location = new System.Drawing.Point(234, 6);
            this.tbxSignaturer.Name = "tbxSignaturer";
            this.tbxSignaturer.Size = new System.Drawing.Size(429, 20);
            this.tbxSignaturer.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOK.Location = new System.Drawing.Point(588, 38);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // EnterSignaturerForDiscountAct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnOK;
            this.ClientSize = new System.Drawing.Size(675, 73);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbxSignaturer);
            this.Controls.Add(this.lblEnterSignaturer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EnterSignaturerForDiscountAct";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Печать акта скидки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEnterSignaturer;
        private System.Windows.Forms.TextBox tbxSignaturer;
        private System.Windows.Forms.Button btnOK;
    }
}