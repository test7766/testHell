namespace WMSOffice.Dialogs.PickControl
{
    partial class TransportationZoneForm
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
            this.lblBarCode = new System.Windows.Forms.Label();
            this.lblZone1 = new System.Windows.Forms.Label();
            this.lblZone2 = new System.Windows.Forms.Label();
            this.lblWeight = new System.Windows.Forms.Label();
            this.tbWeight1 = new System.Windows.Forms.TextBox();
            this.lblWeightCounter = new System.Windows.Forms.Label();
            this.tbWeightCounter1 = new System.Windows.Forms.TextBox();
            this.tbWeight2 = new System.Windows.Forms.TextBox();
            this.tbWeightCounter2 = new System.Windows.Forms.TextBox();
            this.lblZone = new System.Windows.Forms.Label();
            this.lblZoneBarCode = new System.Windows.Forms.Label();
            this.tbBarCode2 = new System.Windows.Forms.TextBox();
            this.tbBarCode1 = new System.Windows.Forms.TextBox();
            this.pnlZone1 = new System.Windows.Forms.Panel();
            this.pnlZone2 = new System.Windows.Forms.Panel();
            this.bcrBarCode = new WMSOffice.Controls.BarCodeReaderControl();
            this.pnlButtons.SuspendLayout();
            this.pnlZone1.SuspendLayout();
            this.pnlZone2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.TabIndex = 10;
            // 
            // lblBarCode
            // 
            this.lblBarCode.AutoSize = true;
            this.lblBarCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBarCode.Location = new System.Drawing.Point(13, 13);
            this.lblBarCode.Name = "lblBarCode";
            this.lblBarCode.Size = new System.Drawing.Size(34, 16);
            this.lblBarCode.TabIndex = 0;
            this.lblBarCode.Text = "Ш/К:";
            // 
            // lblZone1
            // 
            this.lblZone1.AutoSize = true;
            this.lblZone1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblZone1.Location = new System.Drawing.Point(126, 71);
            this.lblZone1.Name = "lblZone1";
            this.lblZone1.Size = new System.Drawing.Size(51, 16);
            this.lblZone1.TabIndex = 3;
            this.lblZone1.Text = "Зона 1";
            // 
            // lblZone2
            // 
            this.lblZone2.AutoSize = true;
            this.lblZone2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblZone2.Location = new System.Drawing.Point(242, 71);
            this.lblZone2.Name = "lblZone2";
            this.lblZone2.Size = new System.Drawing.Size(51, 16);
            this.lblZone2.TabIndex = 4;
            this.lblZone2.Text = "Зона 2";
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblWeight.Location = new System.Drawing.Point(13, 153);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(35, 16);
            this.lblWeight.TabIndex = 6;
            this.lblWeight.Text = "Вес:";
            // 
            // tbWeight1
            // 
            this.tbWeight1.BackColor = System.Drawing.SystemColors.Window;
            this.tbWeight1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbWeight1.Location = new System.Drawing.Point(5, 35);
            this.tbWeight1.Name = "tbWeight1";
            this.tbWeight1.ReadOnly = true;
            this.tbWeight1.Size = new System.Drawing.Size(100, 22);
            this.tbWeight1.TabIndex = 1;
            this.tbWeight1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblWeightCounter
            // 
            this.lblWeightCounter.AutoSize = true;
            this.lblWeightCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblWeightCounter.Location = new System.Drawing.Point(13, 184);
            this.lblWeightCounter.Name = "lblWeightCounter";
            this.lblWeightCounter.Size = new System.Drawing.Size(77, 16);
            this.lblWeightCounter.TabIndex = 7;
            this.lblWeightCounter.Text = "Взвешено:";
            // 
            // tbWeightCounter1
            // 
            this.tbWeightCounter1.BackColor = System.Drawing.SystemColors.Window;
            this.tbWeightCounter1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbWeightCounter1.Location = new System.Drawing.Point(5, 67);
            this.tbWeightCounter1.Name = "tbWeightCounter1";
            this.tbWeightCounter1.ReadOnly = true;
            this.tbWeightCounter1.Size = new System.Drawing.Size(100, 22);
            this.tbWeightCounter1.TabIndex = 2;
            this.tbWeightCounter1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbWeight2
            // 
            this.tbWeight2.BackColor = System.Drawing.SystemColors.Window;
            this.tbWeight2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbWeight2.Location = new System.Drawing.Point(5, 35);
            this.tbWeight2.Name = "tbWeight2";
            this.tbWeight2.ReadOnly = true;
            this.tbWeight2.Size = new System.Drawing.Size(100, 22);
            this.tbWeight2.TabIndex = 1;
            this.tbWeight2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbWeightCounter2
            // 
            this.tbWeightCounter2.BackColor = System.Drawing.SystemColors.Window;
            this.tbWeightCounter2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbWeightCounter2.Location = new System.Drawing.Point(5, 67);
            this.tbWeightCounter2.Name = "tbWeightCounter2";
            this.tbWeightCounter2.ReadOnly = true;
            this.tbWeightCounter2.Size = new System.Drawing.Size(100, 22);
            this.tbWeightCounter2.TabIndex = 2;
            this.tbWeightCounter2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblZone
            // 
            this.lblZone.AutoSize = true;
            this.lblZone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblZone.Location = new System.Drawing.Point(13, 71);
            this.lblZone.Name = "lblZone";
            this.lblZone.Size = new System.Drawing.Size(45, 16);
            this.lblZone.TabIndex = 2;
            this.lblZone.Text = "Зоны:";
            // 
            // lblZoneBarCode
            // 
            this.lblZoneBarCode.AutoSize = true;
            this.lblZoneBarCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblZoneBarCode.Location = new System.Drawing.Point(12, 118);
            this.lblZoneBarCode.Name = "lblZoneBarCode";
            this.lblZoneBarCode.Size = new System.Drawing.Size(34, 16);
            this.lblZoneBarCode.TabIndex = 5;
            this.lblZoneBarCode.Text = "Ш/К:";
            // 
            // tbBarCode2
            // 
            this.tbBarCode2.BackColor = System.Drawing.SystemColors.Window;
            this.tbBarCode2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbBarCode2.Location = new System.Drawing.Point(5, 3);
            this.tbBarCode2.Name = "tbBarCode2";
            this.tbBarCode2.ReadOnly = true;
            this.tbBarCode2.Size = new System.Drawing.Size(100, 22);
            this.tbBarCode2.TabIndex = 0;
            this.tbBarCode2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbBarCode1
            // 
            this.tbBarCode1.BackColor = System.Drawing.SystemColors.Window;
            this.tbBarCode1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbBarCode1.Location = new System.Drawing.Point(5, 3);
            this.tbBarCode1.Name = "tbBarCode1";
            this.tbBarCode1.ReadOnly = true;
            this.tbBarCode1.Size = new System.Drawing.Size(100, 22);
            this.tbBarCode1.TabIndex = 0;
            this.tbBarCode1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pnlZone1
            // 
            this.pnlZone1.Controls.Add(this.tbWeight1);
            this.pnlZone1.Controls.Add(this.tbWeightCounter1);
            this.pnlZone1.Controls.Add(this.tbBarCode1);
            this.pnlZone1.Location = new System.Drawing.Point(96, 114);
            this.pnlZone1.Name = "pnlZone1";
            this.pnlZone1.Size = new System.Drawing.Size(110, 92);
            this.pnlZone1.TabIndex = 8;
            // 
            // pnlZone2
            // 
            this.pnlZone2.Controls.Add(this.tbBarCode2);
            this.pnlZone2.Controls.Add(this.tbWeight2);
            this.pnlZone2.Controls.Add(this.tbWeightCounter2);
            this.pnlZone2.Location = new System.Drawing.Point(212, 114);
            this.pnlZone2.Name = "pnlZone2";
            this.pnlZone2.Size = new System.Drawing.Size(110, 92);
            this.pnlZone2.TabIndex = 9;
            // 
            // bcrBarCode
            // 
            this.bcrBarCode.Location = new System.Drawing.Point(96, 9);
            this.bcrBarCode.Name = "bcrBarCode";
            this.bcrBarCode.Size = new System.Drawing.Size(242, 25);
            this.bcrBarCode.TabIndex = 1;
            // 
            // TransportationZoneForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 262);
            this.Controls.Add(this.bcrBarCode);
            this.Controls.Add(this.pnlZone2);
            this.Controls.Add(this.pnlZone1);
            this.Controls.Add(this.lblZoneBarCode);
            this.Controls.Add(this.lblZone);
            this.Controls.Add(this.lblWeightCounter);
            this.Controls.Add(this.lblWeight);
            this.Controls.Add(this.lblZone2);
            this.Controls.Add(this.lblZone1);
            this.Controls.Add(this.lblBarCode);
            this.Name = "TransportationZoneForm";
            this.Text = "Определение зоны транспортировки";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TransportationZoneForm_FormClosed);
            this.Controls.SetChildIndex(this.lblBarCode, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.lblZone1, 0);
            this.Controls.SetChildIndex(this.lblZone2, 0);
            this.Controls.SetChildIndex(this.lblWeight, 0);
            this.Controls.SetChildIndex(this.lblWeightCounter, 0);
            this.Controls.SetChildIndex(this.lblZone, 0);
            this.Controls.SetChildIndex(this.lblZoneBarCode, 0);
            this.Controls.SetChildIndex(this.pnlZone1, 0);
            this.Controls.SetChildIndex(this.pnlZone2, 0);
            this.Controls.SetChildIndex(this.bcrBarCode, 0);
            this.pnlButtons.ResumeLayout(false);
            this.pnlZone1.ResumeLayout(false);
            this.pnlZone1.PerformLayout();
            this.pnlZone2.ResumeLayout(false);
            this.pnlZone2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBarCode;
        private System.Windows.Forms.Label lblZone1;
        private System.Windows.Forms.Label lblZone2;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.TextBox tbWeight1;
        private System.Windows.Forms.Label lblWeightCounter;
        private System.Windows.Forms.TextBox tbWeightCounter1;
        private System.Windows.Forms.TextBox tbWeight2;
        private System.Windows.Forms.TextBox tbWeightCounter2;
        private System.Windows.Forms.Label lblZone;
        private System.Windows.Forms.Label lblZoneBarCode;
        private System.Windows.Forms.TextBox tbBarCode2;
        private System.Windows.Forms.TextBox tbBarCode1;
        private System.Windows.Forms.Panel pnlZone1;
        private System.Windows.Forms.Panel pnlZone2;
        private WMSOffice.Controls.BarCodeReaderControl bcrBarCode;
    }
}