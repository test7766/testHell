namespace WMSOffice.Dialogs.Complaints
{
    partial class CustomActionsForm
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
            this.panel = new System.Windows.Forms.TableLayoutPanel();
            this.testCheckBox = new System.Windows.Forms.CheckBox();
            this.testButton = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlMessage = new System.Windows.Forms.Panel();
            this.lblAmountWithVATValue = new System.Windows.Forms.Label();
            this.lblVATValue = new System.Windows.Forms.Label();
            this.lblAmountValue = new System.Windows.Forms.Label();
            this.lblDebtorValue = new System.Windows.Forms.Label();
            this.lblAmountWithVAT = new System.Windows.Forms.Label();
            this.lblVAT = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblDebtor = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.panel.SuspendLayout();
            this.pnlMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.ColumnCount = 2;
            this.panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 394F));
            this.panel.Controls.Add(this.testCheckBox, 0, 0);
            this.panel.Controls.Add(this.testButton, 1, 0);
            this.panel.Location = new System.Drawing.Point(12, 204);
            this.panel.Name = "panel";
            this.panel.RowCount = 1;
            this.panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.panel.Size = new System.Drawing.Size(420, 64);
            this.panel.TabIndex = 0;
            // 
            // testCheckBox
            // 
            this.testCheckBox.AutoSize = true;
            this.testCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testCheckBox.Location = new System.Drawing.Point(3, 3);
            this.testCheckBox.Name = "testCheckBox";
            this.testCheckBox.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.testCheckBox.Size = new System.Drawing.Size(20, 58);
            this.testCheckBox.TabIndex = 1;
            this.testCheckBox.UseVisualStyleBackColor = true;
            // 
            // testButton
            // 
            this.testButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.testButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.testButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.testButton.Location = new System.Drawing.Point(29, 3);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(388, 56);
            this.testButton.TabIndex = 2;
            this.testButton.Text = "Action text bla-bla-bla";
            this.testButton.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(254, 285);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(97, 23);
            this.btnOK.TabIndex = 1000;
            this.btnOK.Text = "Продолжить";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(357, 285);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1001;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlMessage
            // 
            this.pnlMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMessage.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlMessage.Controls.Add(this.lblAmountWithVATValue);
            this.pnlMessage.Controls.Add(this.lblVATValue);
            this.pnlMessage.Controls.Add(this.lblAmountValue);
            this.pnlMessage.Controls.Add(this.lblDebtorValue);
            this.pnlMessage.Controls.Add(this.lblAmountWithVAT);
            this.pnlMessage.Controls.Add(this.lblVAT);
            this.pnlMessage.Controls.Add(this.lblAmount);
            this.pnlMessage.Controls.Add(this.lblDebtor);
            this.pnlMessage.Controls.Add(this.lblMessage);
            this.pnlMessage.Location = new System.Drawing.Point(12, 12);
            this.pnlMessage.Name = "pnlMessage";
            this.pnlMessage.Size = new System.Drawing.Size(420, 179);
            this.pnlMessage.TabIndex = 1002;
            // 
            // lblAmountWithVATValue
            // 
            this.lblAmountWithVATValue.AutoSize = true;
            this.lblAmountWithVATValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAmountWithVATValue.Location = new System.Drawing.Point(145, 144);
            this.lblAmountWithVATValue.Name = "lblAmountWithVATValue";
            this.lblAmountWithVATValue.Size = new System.Drawing.Size(14, 18);
            this.lblAmountWithVATValue.TabIndex = 8;
            this.lblAmountWithVATValue.Text = "-";
            // 
            // lblVATValue
            // 
            this.lblVATValue.AutoSize = true;
            this.lblVATValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblVATValue.Location = new System.Drawing.Point(145, 118);
            this.lblVATValue.Name = "lblVATValue";
            this.lblVATValue.Size = new System.Drawing.Size(14, 18);
            this.lblVATValue.TabIndex = 7;
            this.lblVATValue.Text = "-";
            // 
            // lblAmountValue
            // 
            this.lblAmountValue.AutoSize = true;
            this.lblAmountValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAmountValue.Location = new System.Drawing.Point(145, 92);
            this.lblAmountValue.Name = "lblAmountValue";
            this.lblAmountValue.Size = new System.Drawing.Size(14, 18);
            this.lblAmountValue.TabIndex = 6;
            this.lblAmountValue.Text = "-";
            // 
            // lblDebtorValue
            // 
            this.lblDebtorValue.AutoSize = true;
            this.lblDebtorValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDebtorValue.Location = new System.Drawing.Point(74, 66);
            this.lblDebtorValue.Name = "lblDebtorValue";
            this.lblDebtorValue.Size = new System.Drawing.Size(14, 18);
            this.lblDebtorValue.TabIndex = 5;
            this.lblDebtorValue.Text = "-";
            // 
            // lblAmountWithVAT
            // 
            this.lblAmountWithVAT.AutoSize = true;
            this.lblAmountWithVAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAmountWithVAT.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblAmountWithVAT.Location = new System.Drawing.Point(4, 144);
            this.lblAmountWithVAT.Name = "lblAmountWithVAT";
            this.lblAmountWithVAT.Size = new System.Drawing.Size(127, 18);
            this.lblAmountWithVAT.TabIndex = 4;
            this.lblAmountWithVAT.Text = "Сумма с НДС: ";
            // 
            // lblVAT
            // 
            this.lblVAT.AutoSize = true;
            this.lblVAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblVAT.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblVAT.Location = new System.Drawing.Point(3, 118);
            this.lblVAT.Name = "lblVAT";
            this.lblVAT.Size = new System.Drawing.Size(55, 18);
            this.lblVAT.TabIndex = 3;
            this.lblVAT.Text = "НДС: ";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAmount.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblAmount.Location = new System.Drawing.Point(4, 92);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(146, 18);
            this.lblAmount.TabIndex = 2;
            this.lblAmount.Text = "Сумма без НДС: ";
            // 
            // lblDebtor
            // 
            this.lblDebtor.AutoSize = true;
            this.lblDebtor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDebtor.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblDebtor.Location = new System.Drawing.Point(4, 66);
            this.lblDebtor.Name = "lblDebtor";
            this.lblDebtor.Size = new System.Drawing.Size(74, 18);
            this.lblDebtor.TabIndex = 1;
            this.lblDebtor.Text = "Клиент: ";
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblMessage.Location = new System.Drawing.Point(4, 4);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(413, 62);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "Проверьте суммы ВН, если не сходятся \r\nверните претензию на статус Экспедиции \r\nд" +
                "ля оформления корректных документов";
            // 
            // CustomActionsForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(444, 326);
            this.Controls.Add(this.pnlMessage);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomActionsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Выбор действия";
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.pnlMessage.ResumeLayout(false);
            this.pnlMessage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panel;
        private System.Windows.Forms.CheckBox testCheckBox;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlMessage;
        private System.Windows.Forms.Label lblDebtor;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblAmountWithVATValue;
        private System.Windows.Forms.Label lblVATValue;
        private System.Windows.Forms.Label lblAmountValue;
        private System.Windows.Forms.Label lblDebtorValue;
        private System.Windows.Forms.Label lblAmountWithVAT;
        private System.Windows.Forms.Label lblVAT;
        private System.Windows.Forms.Label lblAmount;
    }
}