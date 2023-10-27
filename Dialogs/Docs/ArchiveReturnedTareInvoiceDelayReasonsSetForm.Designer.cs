namespace WMSOffice.Dialogs.Docs
{
    partial class ArchiveReturnedTareInvoiceDelayReasonsSetForm
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
            this.gbReasons = new System.Windows.Forms.GroupBox();
            this.cbWithoutStamp = new System.Windows.Forms.CheckBox();
            this.cbWithoutQty = new System.Windows.Forms.CheckBox();
            this.cbWithoutSign = new System.Windows.Forms.CheckBox();
            this.cbWrongSign = new System.Windows.Forms.CheckBox();
            this.pnlButtons.SuspendLayout();
            this.gbReasons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(142, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(232, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 153);
            this.pnlButtons.Size = new System.Drawing.Size(319, 43);
            this.pnlButtons.TabIndex = 1;
            // 
            // gbReasons
            // 
            this.gbReasons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbReasons.Controls.Add(this.cbWrongSign);
            this.gbReasons.Controls.Add(this.cbWithoutStamp);
            this.gbReasons.Controls.Add(this.cbWithoutQty);
            this.gbReasons.Controls.Add(this.cbWithoutSign);
            this.gbReasons.Location = new System.Drawing.Point(12, 12);
            this.gbReasons.Name = "gbReasons";
            this.gbReasons.Size = new System.Drawing.Size(295, 130);
            this.gbReasons.TabIndex = 0;
            this.gbReasons.TabStop = false;
            this.gbReasons.Text = "Выберите одну или несколько";
            // 
            // cbWithoutStamp
            // 
            this.cbWithoutStamp.AutoSize = true;
            this.cbWithoutStamp.Location = new System.Drawing.Point(19, 22);
            this.cbWithoutStamp.Name = "cbWithoutStamp";
            this.cbWithoutStamp.Size = new System.Drawing.Size(82, 17);
            this.cbWithoutStamp.TabIndex = 0;
            this.cbWithoutStamp.Tag = "1";
            this.cbWithoutStamp.Text = "Нет печати";
            this.cbWithoutStamp.UseVisualStyleBackColor = true;
            // 
            // cbWithoutQty
            // 
            this.cbWithoutQty.AutoSize = true;
            this.cbWithoutQty.Location = new System.Drawing.Point(19, 72);
            this.cbWithoutQty.Name = "cbWithoutQty";
            this.cbWithoutQty.Size = new System.Drawing.Size(133, 17);
            this.cbWithoutQty.TabIndex = 2;
            this.cbWithoutQty.Tag = "3";
            this.cbWithoutQty.Text = "Не заполнено кол-во";
            this.cbWithoutQty.UseVisualStyleBackColor = true;
            // 
            // cbWithoutSign
            // 
            this.cbWithoutSign.AutoSize = true;
            this.cbWithoutSign.Location = new System.Drawing.Point(19, 47);
            this.cbWithoutSign.Name = "cbWithoutSign";
            this.cbWithoutSign.Size = new System.Drawing.Size(90, 17);
            this.cbWithoutSign.TabIndex = 1;
            this.cbWithoutSign.Tag = "2";
            this.cbWithoutSign.Text = "Нет подписи";
            this.cbWithoutSign.UseVisualStyleBackColor = true;
            // 
            // cbWrongSign
            // 
            this.cbWrongSign.AutoSize = true;
            this.cbWrongSign.Location = new System.Drawing.Point(19, 97);
            this.cbWrongSign.Name = "cbWrongSign";
            this.cbWrongSign.Size = new System.Drawing.Size(265, 17);
            this.cbWrongSign.TabIndex = 3;
            this.cbWrongSign.Tag = "4";
            this.cbWrongSign.Text = "Несоответствие подписи МОЛ в доверенности";
            this.cbWrongSign.UseVisualStyleBackColor = true;
            // 
            // ArchiveReturnedTareInvoiceDelayReasonsSetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 196);
            this.Controls.Add(this.gbReasons);
            this.Name = "ArchiveReturnedTareInvoiceDelayReasonsSetForm";
            this.Text = "Причины доработки";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ArchiveReturnedTareInvoiceDelayReasonsSetForm_FormClosing);
            this.Controls.SetChildIndex(this.gbReasons, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.gbReasons.ResumeLayout(false);
            this.gbReasons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbReasons;
        private System.Windows.Forms.CheckBox cbWithoutQty;
        private System.Windows.Forms.CheckBox cbWithoutSign;
        private System.Windows.Forms.CheckBox cbWithoutStamp;
        private System.Windows.Forms.CheckBox cbWrongSign;
    }
}