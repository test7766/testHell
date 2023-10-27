namespace WMSOffice.Dialogs.Containers
{
    partial class DebtorsReturnedTareSetExceptionForm
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
            this.stbDeliveryID = new WMSOffice.Controls.SearchTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbOrderNumber = new System.Windows.Forms.TextBox();
            this.tbDebtorName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDeliveryAddress = new System.Windows.Forms.TextBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(1629, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1719, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 193);
            this.pnlButtons.Size = new System.Drawing.Size(714, 43);
            this.pnlButtons.TabIndex = 9;
            // 
            // stbDeliveryID
            // 
            this.stbDeliveryID.Location = new System.Drawing.Point(111, 15);
            this.stbDeliveryID.Name = "stbDeliveryID";
            this.stbDeliveryID.ReadOnly = false;
            this.stbDeliveryID.Size = new System.Drawing.Size(100, 20);
            this.stbDeliveryID.TabIndex = 1;
            this.stbDeliveryID.UserID = ((long)(0));
            this.stbDeliveryID.Value = null;
            this.stbDeliveryID.ValueReferenceQuery = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Код ТТ :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "№ заказа :";
            // 
            // tbOrderNumber
            // 
            this.tbOrderNumber.Location = new System.Drawing.Point(111, 89);
            this.tbOrderNumber.Name = "tbOrderNumber";
            this.tbOrderNumber.Size = new System.Drawing.Size(100, 20);
            this.tbOrderNumber.TabIndex = 6;
            // 
            // tbDebtorName
            // 
            this.tbDebtorName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDebtorName.BackColor = System.Drawing.SystemColors.Window;
            this.tbDebtorName.Location = new System.Drawing.Point(217, 15);
            this.tbDebtorName.Name = "tbDebtorName";
            this.tbDebtorName.ReadOnly = true;
            this.tbDebtorName.Size = new System.Drawing.Size(485, 20);
            this.tbDebtorName.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Адрес :";
            // 
            // tbDeliveryAddress
            // 
            this.tbDeliveryAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDeliveryAddress.BackColor = System.Drawing.SystemColors.Window;
            this.tbDeliveryAddress.Location = new System.Drawing.Point(111, 44);
            this.tbDeliveryAddress.Name = "tbDeliveryAddress";
            this.tbDeliveryAddress.ReadOnly = true;
            this.tbDeliveryAddress.Size = new System.Drawing.Size(591, 20);
            this.tbDeliveryAddress.TabIndex = 4;
            // 
            // tbDescription
            // 
            this.tbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDescription.Location = new System.Drawing.Point(111, 134);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbDescription.Size = new System.Drawing.Size(591, 50);
            this.tbDescription.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Комментарий :";
            // 
            // DebtorsReturnedTareSetExceptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 236);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.tbDeliveryAddress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbDebtorName);
            this.Controls.Add(this.tbOrderNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stbDeliveryID);
            this.Name = "DebtorsReturnedTareSetExceptionForm";
            this.Text = "Настройка исключения по использованию ОТ";
            this.Load += new System.EventHandler(this.DebtorsReturnedTareSetExceptionForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DebtorsReturnedTareSetExceptionForm_FormClosing);
            this.Controls.SetChildIndex(this.stbDeliveryID, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.tbOrderNumber, 0);
            this.Controls.SetChildIndex(this.tbDebtorName, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.tbDeliveryAddress, 0);
            this.Controls.SetChildIndex(this.tbDescription, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WMSOffice.Controls.SearchTextBox stbDeliveryID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbOrderNumber;
        private System.Windows.Forms.TextBox tbDebtorName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDeliveryAddress;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label label4;
    }
}