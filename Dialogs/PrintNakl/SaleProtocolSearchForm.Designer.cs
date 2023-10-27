namespace WMSOffice.Dialogs.PrintNakl
{
    partial class SaleProtocolSearchForm
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
            this.gbDataInterval = new System.Windows.Forms.GroupBox();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbOrder = new System.Windows.Forms.TextBox();
            this.tbLotId = new System.Windows.Forms.TextBox();
            this.tbVendorLot = new System.Windows.Forms.TextBox();
            this.tbItemId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            this.gbDataInterval.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(9, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(99, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Size = new System.Drawing.Size(268, 43);
            // 
            // gbDataInterval
            // 
            this.gbDataInterval.Controls.Add(this.dtStartDate);
            this.gbDataInterval.Controls.Add(this.dtEndDate);
            this.gbDataInterval.Controls.Add(this.lblStartDate);
            this.gbDataInterval.Controls.Add(this.lblEndDate);
            this.gbDataInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbDataInterval.Location = new System.Drawing.Point(3, 4);
            this.gbDataInterval.Name = "gbDataInterval";
            this.gbDataInterval.Size = new System.Drawing.Size(256, 87);
            this.gbDataInterval.TabIndex = 106;
            this.gbDataInterval.TabStop = false;
            this.gbDataInterval.Text = "по диапазону дат:";
            // 
            // dtStartDate
            // 
            this.dtStartDate.CustomFormat = "dd / MM / yyyy";
            this.dtStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStartDate.Location = new System.Drawing.Point(70, 25);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(147, 20);
            this.dtStartDate.TabIndex = 103;
            // 
            // dtEndDate
            // 
            this.dtEndDate.CustomFormat = "dd / MM / yyyy";
            this.dtEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEndDate.Location = new System.Drawing.Point(70, 52);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(147, 20);
            this.dtEndDate.TabIndex = 104;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStartDate.Location = new System.Drawing.Point(10, 25);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(45, 13);
            this.lblStartDate.TabIndex = 101;
            this.lblStartDate.Text = "Дата с:";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblEndDate.Location = new System.Drawing.Point(10, 52);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(51, 13);
            this.lblEndDate.TabIndex = 102;
            this.lblEndDate.Text = "Дата по:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbOrder);
            this.groupBox1.Controls.Add(this.tbLotId);
            this.groupBox1.Controls.Add(this.tbVendorLot);
            this.groupBox1.Controls.Add(this.tbItemId);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 119);
            this.groupBox1.TabIndex = 107;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Найти";
            // 
            // tbOrder
            // 
            this.tbOrder.Location = new System.Drawing.Point(70, 81);
            this.tbOrder.Name = "tbOrder";
            this.tbOrder.Size = new System.Drawing.Size(147, 20);
            this.tbOrder.TabIndex = 7;
            // 
            // tbLotId
            // 
            this.tbLotId.Location = new System.Drawing.Point(70, 59);
            this.tbLotId.Name = "tbLotId";
            this.tbLotId.Size = new System.Drawing.Size(147, 20);
            this.tbLotId.TabIndex = 6;
            // 
            // tbVendorLot
            // 
            this.tbVendorLot.Location = new System.Drawing.Point(70, 37);
            this.tbVendorLot.Name = "tbVendorLot";
            this.tbVendorLot.Size = new System.Drawing.Size(147, 20);
            this.tbVendorLot.TabIndex = 5;
            // 
            // tbItemId
            // 
            this.tbItemId.Location = new System.Drawing.Point(70, 15);
            this.tbItemId.Name = "tbItemId";
            this.tbItemId.Size = new System.Drawing.Size(147, 20);
            this.tbItemId.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "№ заказа";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Партию";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Серию";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "КНН";
            // 
            // SaleProtocolSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 262);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbDataInterval);
            this.Name = "SaleProtocolSearchForm";
            this.Text = "Параметры поиска";
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.gbDataInterval, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.pnlButtons.ResumeLayout(false);
            this.gbDataInterval.ResumeLayout(false);
            this.gbDataInterval.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDataInterval;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.DateTimePicker dtEndDate;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbOrder;
        private System.Windows.Forms.TextBox tbLotId;
        private System.Windows.Forms.TextBox tbVendorLot;
        private System.Windows.Forms.TextBox tbItemId;
    }
}