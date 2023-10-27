namespace WMSOffice.Dialogs.Receive
{
    partial class PalletsOutgoingAccountingForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.tbPlasticPalletsQty = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbEuroPalletsQty = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbStandartPalletsQty = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(110, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(200, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Size = new System.Drawing.Size(284, 43);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(0, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(284, 45);
            this.label4.TabIndex = 114;
            this.label4.Text = "Введите кол-во паллет к возврату, согласно служебной записке:";
            // 
            // tbPlasticPalletsQty
            // 
            this.tbPlasticPalletsQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbPlasticPalletsQty.Location = new System.Drawing.Point(12, 174);
            this.tbPlasticPalletsQty.Name = "tbPlasticPalletsQty";
            this.tbPlasticPalletsQty.Size = new System.Drawing.Size(100, 22);
            this.tbPlasticPalletsQty.TabIndex = 112;
            this.tbPlasticPalletsQty.Text = "0";
            this.tbPlasticPalletsQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbPlasticPalletsQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllowOnlyNumber_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(118, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 16);
            this.label3.TabIndex = 113;
            this.label3.Text = "пластиковых паллет";
            // 
            // tbEuroPalletsQty
            // 
            this.tbEuroPalletsQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbEuroPalletsQty.Location = new System.Drawing.Point(12, 122);
            this.tbEuroPalletsQty.Name = "tbEuroPalletsQty";
            this.tbEuroPalletsQty.Size = new System.Drawing.Size(100, 22);
            this.tbEuroPalletsQty.TabIndex = 110;
            this.tbEuroPalletsQty.Text = "0";
            this.tbEuroPalletsQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbEuroPalletsQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllowOnlyNumber_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(118, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 16);
            this.label2.TabIndex = 111;
            this.label2.Text = "евро-паллет";
            // 
            // tbStandartPalletsQty
            // 
            this.tbStandartPalletsQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbStandartPalletsQty.Location = new System.Drawing.Point(12, 70);
            this.tbStandartPalletsQty.Name = "tbStandartPalletsQty";
            this.tbStandartPalletsQty.Size = new System.Drawing.Size(100, 22);
            this.tbStandartPalletsQty.TabIndex = 108;
            this.tbStandartPalletsQty.Text = "0";
            this.tbStandartPalletsQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbStandartPalletsQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllowOnlyNumber_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(118, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 16);
            this.label1.TabIndex = 109;
            this.label1.Text = "стандартных паллет";
            // 
            // PalletsOutgoingAccountingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbPlasticPalletsQty);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbEuroPalletsQty);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbStandartPalletsQty);
            this.Controls.Add(this.label1);
            this.Name = "PalletsOutgoingAccountingForm";
            this.Text = "Возврат паллет поставщику";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PalletsOutgoingAccountingForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.tbStandartPalletsQty, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.tbEuroPalletsQty, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.tbPlasticPalletsQty, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPlasticPalletsQty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbEuroPalletsQty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbStandartPalletsQty;
        private System.Windows.Forms.Label label1;
    }
}