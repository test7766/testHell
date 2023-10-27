namespace WMSOffice.Dialogs.WH
{
    partial class RepackItemCheckRegradingUnits
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
            this.btnBeginRegradeUnits = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblScannedUnit = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblExpectedUnit = new System.Windows.Forms.Label();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnBeginRegradeUnits);
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 122);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(544, 35);
            this.pnlFooter.TabIndex = 1;
            // 
            // btnBeginRegradeUnits
            // 
            this.btnBeginRegradeUnits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBeginRegradeUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBeginRegradeUnits.Location = new System.Drawing.Point(382, 6);
            this.btnBeginRegradeUnits.Name = "btnBeginRegradeUnits";
            this.btnBeginRegradeUnits.Size = new System.Drawing.Size(150, 23);
            this.btnBeginRegradeUnits.TabIndex = 1;
            this.btnBeginRegradeUnits.Text = "Потоварный пересорт";
            this.btnBeginRegradeUnits.UseVisualStyleBackColor = true;
            this.btnBeginRegradeUnits.Click += new System.EventHandler(this.btnBeginRegradeUnits_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(301, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Сканируемый КНН";
            // 
            // lblScannedUnit
            // 
            this.lblScannedUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblScannedUnit.Location = new System.Drawing.Point(167, 5);
            this.lblScannedUnit.Name = "lblScannedUnit";
            this.lblScannedUnit.Size = new System.Drawing.Size(365, 25);
            this.lblScannedUnit.TabIndex = 3;
            this.lblScannedUnit.Text = "Сканируемый КНН";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(220, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "не совпадает с ожидаемым";
            // 
            // lblExpectedUnit
            // 
            this.lblExpectedUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblExpectedUnit.Location = new System.Drawing.Point(238, 41);
            this.lblExpectedUnit.Name = "lblExpectedUnit";
            this.lblExpectedUnit.Size = new System.Drawing.Size(294, 25);
            this.lblExpectedUnit.TabIndex = 5;
            this.lblExpectedUnit.Text = "Ожидаемый КНН";
            // 
            // RepackItemCheckRegradingUnits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 157);
            this.Controls.Add(this.lblExpectedUnit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblScannedUnit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlFooter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RepackItemCheckRegradingUnits";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RepackItemRegradingUnits";
            this.Load += new System.EventHandler(this.RepackItemCheckRegradingUnits_Load);
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnBeginRegradeUnits;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblScannedUnit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblExpectedUnit;
    }
}