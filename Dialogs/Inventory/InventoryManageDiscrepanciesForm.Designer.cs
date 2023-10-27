namespace WMSOffice.Dialogs.Inventory
{
    partial class InventoryManageDiscrepanciesForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSurplusTotalSum = new System.Windows.Forms.Label();
            this.lblShortageTotalSum = new System.Windows.Forms.Label();
            this.lblTotalSum = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(265, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(355, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 183);
            this.pnlButtons.Size = new System.Drawing.Size(324, 43);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(-3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(327, 66);
            this.label1.TabIndex = 101;
            this.label1.Text = "Выполнить\nавтоматическое приходование излишков\nи списание недостач на сумму излиш" +
                "ков:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 16);
            this.label2.TabIndex = 102;
            this.label2.Text = "Излишки (грн.):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 16);
            this.label3.TabIndex = 103;
            this.label3.Text = "Недостачи  (грн.):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 16);
            this.label4.TabIndex = 104;
            this.label4.Text = "Итого  (грн.):";
            // 
            // lblSurplusTotalSum
            // 
            this.lblSurplusTotalSum.AutoSize = true;
            this.lblSurplusTotalSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSurplusTotalSum.Location = new System.Drawing.Point(140, 87);
            this.lblSurplusTotalSum.Name = "lblSurplusTotalSum";
            this.lblSurplusTotalSum.Size = new System.Drawing.Size(16, 16);
            this.lblSurplusTotalSum.TabIndex = 108;
            this.lblSurplusTotalSum.Text = "0";
            // 
            // lblShortageTotalSum
            // 
            this.lblShortageTotalSum.AutoSize = true;
            this.lblShortageTotalSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblShortageTotalSum.Location = new System.Drawing.Point(140, 119);
            this.lblShortageTotalSum.Name = "lblShortageTotalSum";
            this.lblShortageTotalSum.Size = new System.Drawing.Size(16, 16);
            this.lblShortageTotalSum.TabIndex = 109;
            this.lblShortageTotalSum.Text = "0";
            // 
            // lblTotalSum
            // 
            this.lblTotalSum.AutoSize = true;
            this.lblTotalSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTotalSum.Location = new System.Drawing.Point(140, 151);
            this.lblTotalSum.Name = "lblTotalSum";
            this.lblTotalSum.Size = new System.Drawing.Size(16, 16);
            this.lblTotalSum.TabIndex = 110;
            this.lblTotalSum.Text = "0";
            // 
            // InventoryManageDiscrepanciesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 226);
            this.Controls.Add(this.lblTotalSum);
            this.Controls.Add(this.lblShortageTotalSum);
            this.Controls.Add(this.lblSurplusTotalSum);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "InventoryManageDiscrepanciesForm";
            this.Text = "Балансировка расхождений";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InventoryManageDiscrepanciesForm_FormClosing);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.lblSurplusTotalSum, 0);
            this.Controls.SetChildIndex(this.lblShortageTotalSum, 0);
            this.Controls.SetChildIndex(this.lblTotalSum, 0);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSurplusTotalSum;
        private System.Windows.Forms.Label lblShortageTotalSum;
        private System.Windows.Forms.Label lblTotalSum;
    }
}