namespace WMSOffice.Dialogs.WH.SD
{
    partial class SalesDispatcherLinesForm
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
            this.pnlLines = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.btnChangeSalesCategory = new System.Windows.Forms.ToolStripButton();
            this.gbHeaderInfo = new System.Windows.Forms.GroupBox();
            this.tbDeliveryName = new System.Windows.Forms.TextBox();
            this.dtpDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.tbSHKCOO = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpOrderDate = new System.Windows.Forms.DateTimePicker();
            this.tbSHDCTO = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbSHDOCO = new System.Windows.Forms.TextBox();
            this.tbInstruction2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbDebitor = new System.Windows.Forms.TextBox();
            this.tbInstruction1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbDebitorName = new System.Windows.Forms.TextBox();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbDelivery = new System.Windows.Forms.TextBox();
            this.tbCity = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvLines = new System.Windows.Forms.DataGridView();
            this.label14 = new System.Windows.Forms.Label();
            this.tbSalesCategory = new System.Windows.Forms.TextBox();
            this.pnlButtons.SuspendLayout();
            this.pnlLines.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.gbHeaderInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLines)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(4084, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(4164, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 489);
            this.pnlButtons.Size = new System.Drawing.Size(927, 43);
            this.pnlButtons.TabIndex = 1;
            // 
            // pnlLines
            // 
            this.pnlLines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLines.Controls.Add(this.toolStrip1);
            this.pnlLines.Controls.Add(this.gbHeaderInfo);
            this.pnlLines.Controls.Add(this.dgvLines);
            this.pnlLines.Location = new System.Drawing.Point(0, 1);
            this.pnlLines.Name = "pnlLines";
            this.pnlLines.Size = new System.Drawing.Size(927, 490);
            this.pnlLines.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExportToExcel,
            this.btnChangeSalesCategory});
            this.toolStrip1.Location = new System.Drawing.Point(3, 200);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(310, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Image = global::WMSOffice.Properties.Resources.Excel;
            this.btnExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(110, 22);
            this.btnExportToExcel.Text = "Экспорт в Excel";
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // btnChangeSalesCategory
            // 
            this.btnChangeSalesCategory.Image = global::WMSOffice.Properties.Resources.Edit_10x10;
            this.btnChangeSalesCategory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnChangeSalesCategory.Name = "btnChangeSalesCategory";
            this.btnChangeSalesCategory.Size = new System.Drawing.Size(188, 22);
            this.btnChangeSalesCategory.Text = "Изменить категорию продаж";
            this.btnChangeSalesCategory.Click += new System.EventHandler(this.btnChangeSalesCategory_Click);
            // 
            // gbHeaderInfo
            // 
            this.gbHeaderInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbHeaderInfo.Controls.Add(this.tbSalesCategory);
            this.gbHeaderInfo.Controls.Add(this.label14);
            this.gbHeaderInfo.Controls.Add(this.tbDeliveryName);
            this.gbHeaderInfo.Controls.Add(this.dtpDeliveryDate);
            this.gbHeaderInfo.Controls.Add(this.tbSHKCOO);
            this.gbHeaderInfo.Controls.Add(this.label13);
            this.gbHeaderInfo.Controls.Add(this.label1);
            this.gbHeaderInfo.Controls.Add(this.dtpOrderDate);
            this.gbHeaderInfo.Controls.Add(this.tbSHDCTO);
            this.gbHeaderInfo.Controls.Add(this.label12);
            this.gbHeaderInfo.Controls.Add(this.label2);
            this.gbHeaderInfo.Controls.Add(this.label11);
            this.gbHeaderInfo.Controls.Add(this.tbSHDOCO);
            this.gbHeaderInfo.Controls.Add(this.tbInstruction2);
            this.gbHeaderInfo.Controls.Add(this.label3);
            this.gbHeaderInfo.Controls.Add(this.label10);
            this.gbHeaderInfo.Controls.Add(this.tbDebitor);
            this.gbHeaderInfo.Controls.Add(this.tbInstruction1);
            this.gbHeaderInfo.Controls.Add(this.label4);
            this.gbHeaderInfo.Controls.Add(this.label9);
            this.gbHeaderInfo.Controls.Add(this.tbDebitorName);
            this.gbHeaderInfo.Controls.Add(this.tbAddress);
            this.gbHeaderInfo.Controls.Add(this.label5);
            this.gbHeaderInfo.Controls.Add(this.label8);
            this.gbHeaderInfo.Controls.Add(this.tbDelivery);
            this.gbHeaderInfo.Controls.Add(this.tbCity);
            this.gbHeaderInfo.Controls.Add(this.label6);
            this.gbHeaderInfo.Controls.Add(this.label7);
            this.gbHeaderInfo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.gbHeaderInfo.Location = new System.Drawing.Point(3, 3);
            this.gbHeaderInfo.Name = "gbHeaderInfo";
            this.gbHeaderInfo.Size = new System.Drawing.Size(921, 194);
            this.gbHeaderInfo.TabIndex = 0;
            this.gbHeaderInfo.TabStop = false;
            this.gbHeaderInfo.Text = "Заголовок заказа:";
            // 
            // tbDeliveryName
            // 
            this.tbDeliveryName.BackColor = System.Drawing.SystemColors.Window;
            this.tbDeliveryName.Location = new System.Drawing.Point(289, 92);
            this.tbDeliveryName.Name = "tbDeliveryName";
            this.tbDeliveryName.ReadOnly = true;
            this.tbDeliveryName.Size = new System.Drawing.Size(369, 20);
            this.tbDeliveryName.TabIndex = 17;
            // 
            // dtpDeliveryDate
            // 
            this.dtpDeliveryDate.CustomFormat = "dd / MM / yyyy";
            this.dtpDeliveryDate.Enabled = false;
            this.dtpDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDeliveryDate.Location = new System.Drawing.Point(769, 24);
            this.dtpDeliveryDate.Name = "dtpDeliveryDate";
            this.dtpDeliveryDate.Size = new System.Drawing.Size(140, 20);
            this.dtpDeliveryDate.TabIndex = 9;
            // 
            // tbSHKCOO
            // 
            this.tbSHKCOO.BackColor = System.Drawing.SystemColors.Window;
            this.tbSHKCOO.Location = new System.Drawing.Point(47, 25);
            this.tbSHKCOO.Name = "tbSHKCOO";
            this.tbSHKCOO.ReadOnly = true;
            this.tbSHKCOO.Size = new System.Drawing.Size(67, 20);
            this.tbSHKCOO.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(680, 28);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(86, 13);
            this.label13.TabIndex = 8;
            this.label13.Text = "Дата доставки:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Комп.:";
            // 
            // dtpOrderDate
            // 
            this.dtpOrderDate.CustomFormat = "dd / MM / yyyy";
            this.dtpOrderDate.Enabled = false;
            this.dtpOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOrderDate.Location = new System.Drawing.Point(518, 24);
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.Size = new System.Drawing.Size(140, 20);
            this.dtpOrderDate.TabIndex = 7;
            // 
            // tbSHDCTO
            // 
            this.tbSHDCTO.BackColor = System.Drawing.SystemColors.Window;
            this.tbSHDCTO.Location = new System.Drawing.Point(192, 25);
            this.tbSHDCTO.Name = "tbSHDCTO";
            this.tbSHDCTO.ReadOnly = true;
            this.tbSHDCTO.Size = new System.Drawing.Size(45, 20);
            this.tbSHDCTO.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(439, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Дата заказа:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(136, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Тип зак.:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(467, 164);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(144, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "Инструкция по доставке 2:";
            // 
            // tbSHDOCO
            // 
            this.tbSHDOCO.BackColor = System.Drawing.SystemColors.Window;
            this.tbSHDOCO.Location = new System.Drawing.Point(346, 25);
            this.tbSHDOCO.Name = "tbSHDOCO";
            this.tbSHDOCO.ReadOnly = true;
            this.tbSHDOCO.Size = new System.Drawing.Size(72, 20);
            this.tbSHDOCO.TabIndex = 5;
            // 
            // tbInstruction2
            // 
            this.tbInstruction2.BackColor = System.Drawing.SystemColors.Window;
            this.tbInstruction2.Location = new System.Drawing.Point(614, 161);
            this.tbInstruction2.Name = "tbInstruction2";
            this.tbInstruction2.ReadOnly = true;
            this.tbInstruction2.Size = new System.Drawing.Size(295, 20);
            this.tbInstruction2.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(261, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Номер заказа:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(6, 164);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(144, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Инструкция по доставке 1:";
            // 
            // tbDebitor
            // 
            this.tbDebitor.BackColor = System.Drawing.SystemColors.Window;
            this.tbDebitor.Location = new System.Drawing.Point(74, 59);
            this.tbDebitor.Name = "tbDebitor";
            this.tbDebitor.ReadOnly = true;
            this.tbDebitor.Size = new System.Drawing.Size(72, 20);
            this.tbDebitor.TabIndex = 11;
            // 
            // tbInstruction1
            // 
            this.tbInstruction1.BackColor = System.Drawing.SystemColors.Window;
            this.tbInstruction1.Location = new System.Drawing.Point(153, 161);
            this.tbInstruction1.Name = "tbInstruction1";
            this.tbInstruction1.ReadOnly = true;
            this.tbInstruction1.Size = new System.Drawing.Size(295, 20);
            this.tbInstruction1.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(6, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Код деб-ра:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(320, 130);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Адрес доставки:";
            // 
            // tbDebitorName
            // 
            this.tbDebitorName.BackColor = System.Drawing.SystemColors.Window;
            this.tbDebitorName.Location = new System.Drawing.Point(221, 59);
            this.tbDebitorName.Name = "tbDebitorName";
            this.tbDebitorName.ReadOnly = true;
            this.tbDebitorName.Size = new System.Drawing.Size(437, 20);
            this.tbDebitorName.TabIndex = 13;
            // 
            // tbAddress
            // 
            this.tbAddress.BackColor = System.Drawing.SystemColors.Window;
            this.tbAddress.Location = new System.Drawing.Point(414, 127);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.ReadOnly = true;
            this.tbAddress.Size = new System.Drawing.Size(495, 20);
            this.tbAddress.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(164, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Дебитор:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(6, 130);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Город:";
            // 
            // tbDelivery
            // 
            this.tbDelivery.BackColor = System.Drawing.SystemColors.Window;
            this.tbDelivery.Location = new System.Drawing.Point(88, 92);
            this.tbDelivery.Name = "tbDelivery";
            this.tbDelivery.ReadOnly = true;
            this.tbDelivery.Size = new System.Drawing.Size(76, 20);
            this.tbDelivery.TabIndex = 15;
            // 
            // tbCity
            // 
            this.tbCity.BackColor = System.Drawing.SystemColors.Window;
            this.tbCity.Location = new System.Drawing.Point(49, 127);
            this.tbCity.Name = "tbCity";
            this.tbCity.ReadOnly = true;
            this.tbCity.Size = new System.Drawing.Size(255, 20);
            this.tbCity.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(6, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Код доставки:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(182, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Дебитор доставки:";
            // 
            // dgvLines
            // 
            this.dgvLines.AllowUserToAddRows = false;
            this.dgvLines.AllowUserToDeleteRows = false;
            this.dgvLines.AllowUserToOrderColumns = true;
            this.dgvLines.AllowUserToResizeColumns = false;
            this.dgvLines.AllowUserToResizeRows = false;
            this.dgvLines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLines.Location = new System.Drawing.Point(0, 234);
            this.dgvLines.MultiSelect = false;
            this.dgvLines.Name = "dgvLines";
            this.dgvLines.ReadOnly = true;
            this.dgvLines.RowHeadersVisible = false;
            this.dgvLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLines.Size = new System.Drawing.Size(927, 253);
            this.dgvLines.TabIndex = 2;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(674, 96);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(104, 13);
            this.label14.TabIndex = 18;
            this.label14.Text = "Категория продаж:";
            // 
            // tbSalesCategory
            // 
            this.tbSalesCategory.BackColor = System.Drawing.SystemColors.Window;
            this.tbSalesCategory.Location = new System.Drawing.Point(784, 92);
            this.tbSalesCategory.Name = "tbSalesCategory";
            this.tbSalesCategory.ReadOnly = true;
            this.tbSalesCategory.Size = new System.Drawing.Size(125, 20);
            this.tbSalesCategory.TabIndex = 19;
            // 
            // SalesDispatcherLinesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 532);
            this.Controls.Add(this.pnlLines);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "SalesDispatcherLinesForm";
            this.Text = "Содержимое заказа";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SalesDispatcherLinesForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlLines, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.pnlLines.ResumeLayout(false);
            this.pnlLines.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gbHeaderInfo.ResumeLayout(false);
            this.gbHeaderInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLines)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLines;
        private System.Windows.Forms.DataGridView dgvLines;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbSHDOCO;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSHDCTO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSHKCOO;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbDebitor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbDebitorName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbDelivery;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbCity;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbDeliveryName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbInstruction2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbInstruction1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.DateTimePicker dtpDeliveryDate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtpOrderDate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox gbHeaderInfo;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnExportToExcel;
        private System.Windows.Forms.ToolStripButton btnChangeSalesCategory;
        private System.Windows.Forms.TextBox tbSalesCategory;
        private System.Windows.Forms.Label label14;
    }
}