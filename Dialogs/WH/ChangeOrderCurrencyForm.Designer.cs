namespace WMSOffice.Dialogs.WH
{
    partial class ChangeOrderCurrencyForm
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
            this.lblDebitCurrencyRate = new System.Windows.Forms.Label();
            this.lblDebitCurrencyDate = new System.Windows.Forms.Label();
            this.nudDebitCurrencyRate = new System.Windows.Forms.NumericUpDown();
            this.dtpDebitCurrencyDate = new System.Windows.Forms.DateTimePicker();
            this.lblDebitCurrency = new System.Windows.Forms.Label();
            this.tbDebitCurrency = new System.Windows.Forms.TextBox();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDebitCurrencyRate)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(-382, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(-292, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 118);
            this.pnlButtons.Size = new System.Drawing.Size(239, 43);
            this.pnlButtons.TabIndex = 6;
            // 
            // lblDebitCurrencyRate
            // 
            this.lblDebitCurrencyRate.AutoSize = true;
            this.lblDebitCurrencyRate.Location = new System.Drawing.Point(15, 52);
            this.lblDebitCurrencyRate.Name = "lblDebitCurrencyRate";
            this.lblDebitCurrencyRate.Size = new System.Drawing.Size(75, 13);
            this.lblDebitCurrencyRate.TabIndex = 2;
            this.lblDebitCurrencyRate.Text = "Курс прихода";
            // 
            // lblDebitCurrencyDate
            // 
            this.lblDebitCurrencyDate.AutoSize = true;
            this.lblDebitCurrencyDate.Location = new System.Drawing.Point(15, 15);
            this.lblDebitCurrencyDate.Name = "lblDebitCurrencyDate";
            this.lblDebitCurrencyDate.Size = new System.Drawing.Size(77, 13);
            this.lblDebitCurrencyDate.TabIndex = 0;
            this.lblDebitCurrencyDate.Text = "Дата прихода";
            // 
            // nudDebitCurrencyRate
            // 
            this.nudDebitCurrencyRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudDebitCurrencyRate.DecimalPlaces = 4;
            this.nudDebitCurrencyRate.Location = new System.Drawing.Point(127, 48);
            this.nudDebitCurrencyRate.Name = "nudDebitCurrencyRate";
            this.nudDebitCurrencyRate.Size = new System.Drawing.Size(100, 20);
            this.nudDebitCurrencyRate.TabIndex = 3;
            this.nudDebitCurrencyRate.ThousandsSeparator = true;
            this.nudDebitCurrencyRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.controlDebitCurrency_KeyDown);
            // 
            // dtpDebitCurrencyDate
            // 
            this.dtpDebitCurrencyDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDebitCurrencyDate.CustomFormat = "dd.MM.yyyy";
            this.dtpDebitCurrencyDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDebitCurrencyDate.Location = new System.Drawing.Point(127, 11);
            this.dtpDebitCurrencyDate.Name = "dtpDebitCurrencyDate";
            this.dtpDebitCurrencyDate.Size = new System.Drawing.Size(100, 20);
            this.dtpDebitCurrencyDate.TabIndex = 1;
            this.dtpDebitCurrencyDate.ValueChanged += new System.EventHandler(this.dtpDebitCurrencyDate_ValueChanged);
            this.dtpDebitCurrencyDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.controlDebitCurrency_KeyDown);
            // 
            // lblDebitCurrency
            // 
            this.lblDebitCurrency.AutoSize = true;
            this.lblDebitCurrency.Location = new System.Drawing.Point(15, 89);
            this.lblDebitCurrency.Name = "lblDebitCurrency";
            this.lblDebitCurrency.Size = new System.Drawing.Size(45, 13);
            this.lblDebitCurrency.TabIndex = 4;
            this.lblDebitCurrency.Text = "Валюта";
            // 
            // tbDebitCurrency
            // 
            this.tbDebitCurrency.BackColor = System.Drawing.SystemColors.Window;
            this.tbDebitCurrency.Location = new System.Drawing.Point(127, 85);
            this.tbDebitCurrency.Name = "tbDebitCurrency";
            this.tbDebitCurrency.ReadOnly = true;
            this.tbDebitCurrency.Size = new System.Drawing.Size(100, 20);
            this.tbDebitCurrency.TabIndex = 5;
            // 
            // ChangeOrderCurrencyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 161);
            this.Controls.Add(this.tbDebitCurrency);
            this.Controls.Add(this.lblDebitCurrency);
            this.Controls.Add(this.lblDebitCurrencyDate);
            this.Controls.Add(this.dtpDebitCurrencyDate);
            this.Controls.Add(this.lblDebitCurrencyRate);
            this.Controls.Add(this.nudDebitCurrencyRate);
            this.Name = "ChangeOrderCurrencyForm";
            this.Text = "Укажите информацию об оплате";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChangeOrderCurrencyForm_FormClosing);
            this.Controls.SetChildIndex(this.nudDebitCurrencyRate, 0);
            this.Controls.SetChildIndex(this.lblDebitCurrencyRate, 0);
            this.Controls.SetChildIndex(this.dtpDebitCurrencyDate, 0);
            this.Controls.SetChildIndex(this.lblDebitCurrencyDate, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.lblDebitCurrency, 0);
            this.Controls.SetChildIndex(this.tbDebitCurrency, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudDebitCurrencyRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDebitCurrencyRate;
        private System.Windows.Forms.Label lblDebitCurrencyDate;
        private System.Windows.Forms.NumericUpDown nudDebitCurrencyRate;
        private System.Windows.Forms.DateTimePicker dtpDebitCurrencyDate;
        private System.Windows.Forms.Label lblDebitCurrency;
        private System.Windows.Forms.TextBox tbDebitCurrency;
    }
}