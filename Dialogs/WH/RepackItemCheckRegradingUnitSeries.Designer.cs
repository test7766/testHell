namespace WMSOffice.Dialogs.WH
{
    partial class RepackItemCheckRegradingUnitSeries
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
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnBeginRegradeUnitSeries = new System.Windows.Forms.Button();
            this.btnConfirmUnitSeries = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUnitSeries = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUnit = new System.Windows.Forms.Label();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnBeginRegradeUnitSeries);
            this.pnlFooter.Controls.Add(this.btnConfirmUnitSeries);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 122);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(544, 35);
            this.pnlFooter.TabIndex = 0;
            // 
            // btnBeginRegradeUnitSeries
            // 
            this.btnBeginRegradeUnitSeries.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBeginRegradeUnitSeries.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBeginRegradeUnitSeries.Location = new System.Drawing.Point(432, 6);
            this.btnBeginRegradeUnitSeries.Name = "btnBeginRegradeUnitSeries";
            this.btnBeginRegradeUnitSeries.Size = new System.Drawing.Size(100, 23);
            this.btnBeginRegradeUnitSeries.TabIndex = 1;
            this.btnBeginRegradeUnitSeries.Text = "Другая серия";
            this.btnBeginRegradeUnitSeries.UseVisualStyleBackColor = true;
            this.btnBeginRegradeUnitSeries.Click += new System.EventHandler(this.btnBeginRegradeUnitSeries_Click);
            // 
            // btnConfirmUnitSeries
            // 
            this.btnConfirmUnitSeries.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirmUnitSeries.Location = new System.Drawing.Point(351, 6);
            this.btnConfirmUnitSeries.Name = "btnConfirmUnitSeries";
            this.btnConfirmUnitSeries.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmUnitSeries.TabIndex = 0;
            this.btnConfirmUnitSeries.Text = "ОК";
            this.btnConfirmUnitSeries.UseVisualStyleBackColor = true;
            this.btnConfirmUnitSeries.Click += new System.EventHandler(this.btnConfirmUnitSeries_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Подтвердите серию ";
            // 
            // lblUnitSeries
            // 
            this.lblUnitSeries.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblUnitSeries.ForeColor = System.Drawing.Color.Red;
            this.lblUnitSeries.Location = new System.Drawing.Point(188, 7);
            this.lblUnitSeries.Name = "lblUnitSeries";
            this.lblUnitSeries.Size = new System.Drawing.Size(344, 25);
            this.lblUnitSeries.TabIndex = 2;
            this.lblUnitSeries.Text = "Номер серии";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "по товару";
            // 
            // lblUnit
            // 
            this.lblUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblUnit.Location = new System.Drawing.Point(101, 38);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(431, 75);
            this.lblUnit.TabIndex = 4;
            this.lblUnit.Text = "Наименование товара (Код товара)";
            // 
            // RepackItemCheckRegradingUnitSeries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 157);
            this.Controls.Add(this.lblUnit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblUnitSeries);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlFooter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RepackItemCheckRegradingUnitSeries";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RepackItemRegradingUnitSeries";
            this.Load += new System.EventHandler(this.RepackItemCheckRegradingUnitSeries_Load);
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnBeginRegradeUnitSeries;
        private System.Windows.Forms.Button btnConfirmUnitSeries;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUnitSeries;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUnit;
    }
}