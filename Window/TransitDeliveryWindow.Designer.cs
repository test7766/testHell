namespace WMSOffice.Window
{
    partial class TransitDeliveryWindow
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.btnLoadData = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrintEtic = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.pnlMainContent = new System.Windows.Forms.Panel();
            this.scContent = new System.Windows.Forms.SplitContainer();
            this.xdgvOrders = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.dgvOrderDetails = new System.Windows.Forms.DataGridView();
            this.orderIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tareTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tareBarCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CostBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Width = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Height = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HasFragile = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.HasCold = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ClientBoxNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dTRETTCMOrderDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.delivery = new WMSOffice.Data.Delivery();
            this.pnlDocDateFilter = new System.Windows.Forms.Panel();
            this.dtpDocDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtpDocDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lblDocDate = new System.Windows.Forms.Label();
            this.pnlDocNumberFilter = new System.Windows.Forms.Panel();
            this.tbDocNumber = new System.Windows.Forms.TextBox();
            this.lblDocNumber = new System.Windows.Forms.Label();
            this.dT_RET_TCM_Order_DetailsTableAdapter = new WMSOffice.Data.DeliveryTableAdapters.DT_RET_TCM_Order_DetailsTableAdapter();
            this.pnlDocStatusFilter = new System.Windows.Forms.Panel();
            this.tbDocStatusTo = new System.Windows.Forms.TextBox();
            this.tbDocStatusFrom = new System.Windows.Forms.TextBox();
            this.stbDocStatusTo = new WMSOffice.Controls.SearchTextBox();
            this.stbDocStatusFrom = new WMSOffice.Controls.SearchTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRepeatDelivery = new System.Windows.Forms.ToolStripButton();
            this.tsMain.SuspendLayout();
            this.pnlMainContent.SuspendLayout();
            this.scContent.Panel1.SuspendLayout();
            this.scContent.Panel2.SuspendLayout();
            this.scContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTRETTCMOrderDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.delivery)).BeginInit();
            this.pnlDocDateFilter.SuspendLayout();
            this.pnlDocNumberFilter.SuspendLayout();
            this.pnlDocStatusFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLoadData,
            this.toolStripSeparator1,
            this.btnPrintEtic,
            this.toolStripSeparator2,
            this.btnExport,
            this.toolStripSeparator3,
            this.btnRepeatDelivery});
            this.tsMain.Location = new System.Drawing.Point(0, 40);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1268, 52);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
            // 
            // btnLoadData
            // 
            this.btnLoadData.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnLoadData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(73, 49);
            this.btnLoadData.Text = "Обновить...";
            this.btnLoadData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 52);
            // 
            // btnPrintEtic
            // 
            this.btnPrintEtic.Image = global::WMSOffice.Properties.Resources.document_print;
            this.btnPrintEtic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintEtic.Name = "btnPrintEtic";
            this.btnPrintEtic.Size = new System.Drawing.Size(60, 49);
            this.btnPrintEtic.Text = "Печать...";
            this.btnPrintEtic.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPrintEtic.Click += new System.EventHandler(this.btnPrintEtic_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 52);
            // 
            // btnExport
            // 
            this.btnExport.Image = global::WMSOffice.Properties.Resources.Excel;
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(65, 49);
            this.btnExport.Text = "Экспорт...";
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // pnlMainContent
            // 
            this.pnlMainContent.Controls.Add(this.scContent);
            this.pnlMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContent.Location = new System.Drawing.Point(0, 92);
            this.pnlMainContent.Name = "pnlMainContent";
            this.pnlMainContent.Size = new System.Drawing.Size(1268, 613);
            this.pnlMainContent.TabIndex = 2;
            // 
            // scContent
            // 
            this.scContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scContent.Location = new System.Drawing.Point(0, 0);
            this.scContent.Name = "scContent";
            this.scContent.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scContent.Panel1
            // 
            this.scContent.Panel1.Controls.Add(this.xdgvOrders);
            // 
            // scContent.Panel2
            // 
            this.scContent.Panel2.Controls.Add(this.dgvOrderDetails);
            this.scContent.Size = new System.Drawing.Size(1268, 613);
            this.scContent.SplitterDistance = 285;
            this.scContent.TabIndex = 1;
            // 
            // xdgvOrders
            // 
            this.xdgvOrders.AllowSort = true;
            this.xdgvOrders.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvOrders.LargeAmountOfData = false;
            this.xdgvOrders.Location = new System.Drawing.Point(0, 0);
            this.xdgvOrders.Name = "xdgvOrders";
            this.xdgvOrders.RowHeadersVisible = false;
            this.xdgvOrders.Size = new System.Drawing.Size(1268, 285);
            this.xdgvOrders.TabIndex = 0;
            this.xdgvOrders.UserID = ((long)(0));
            // 
            // dgvOrderDetails
            // 
            this.dgvOrderDetails.AllowUserToAddRows = false;
            this.dgvOrderDetails.AllowUserToDeleteRows = false;
            this.dgvOrderDetails.AllowUserToResizeRows = false;
            this.dgvOrderDetails.AutoGenerateColumns = false;
            this.dgvOrderDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvOrderDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderIDDataGridViewTextBoxColumn,
            this.tareTypeDataGridViewTextBoxColumn,
            this.tareBarCodeDataGridViewTextBoxColumn,
            this.CostBox,
            this.Width,
            this.Length,
            this.Height,
            this.Weight,
            this.Comment,
            this.HasFragile,
            this.HasCold,
            this.ClientBoxNumber});
            this.dgvOrderDetails.DataSource = this.dTRETTCMOrderDetailsBindingSource;
            this.dgvOrderDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrderDetails.Location = new System.Drawing.Point(0, 0);
            this.dgvOrderDetails.MultiSelect = false;
            this.dgvOrderDetails.Name = "dgvOrderDetails";
            this.dgvOrderDetails.ReadOnly = true;
            this.dgvOrderDetails.RowHeadersVisible = false;
            this.dgvOrderDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrderDetails.Size = new System.Drawing.Size(1268, 324);
            this.dgvOrderDetails.TabIndex = 0;
            // 
            // orderIDDataGridViewTextBoxColumn
            // 
            this.orderIDDataGridViewTextBoxColumn.DataPropertyName = "Order_ID";
            this.orderIDDataGridViewTextBoxColumn.HeaderText = "Order_ID";
            this.orderIDDataGridViewTextBoxColumn.Name = "orderIDDataGridViewTextBoxColumn";
            this.orderIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.orderIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // tareTypeDataGridViewTextBoxColumn
            // 
            this.tareTypeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.tareTypeDataGridViewTextBoxColumn.DataPropertyName = "Tare_Type";
            this.tareTypeDataGridViewTextBoxColumn.HeaderText = "Тип тары";
            this.tareTypeDataGridViewTextBoxColumn.Name = "tareTypeDataGridViewTextBoxColumn";
            this.tareTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.tareTypeDataGridViewTextBoxColumn.Width = 79;
            // 
            // tareBarCodeDataGridViewTextBoxColumn
            // 
            this.tareBarCodeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.tareBarCodeDataGridViewTextBoxColumn.DataPropertyName = "Tare_Bar_Code";
            this.tareBarCodeDataGridViewTextBoxColumn.HeaderText = "Ш/К тары";
            this.tareBarCodeDataGridViewTextBoxColumn.Name = "tareBarCodeDataGridViewTextBoxColumn";
            this.tareBarCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.tareBarCodeDataGridViewTextBoxColumn.Width = 81;
            // 
            // CostBox
            // 
            this.CostBox.DataPropertyName = "CostBox";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.CostBox.DefaultCellStyle = dataGridViewCellStyle6;
            this.CostBox.HeaderText = "Стоимость, грн.";
            this.CostBox.Name = "CostBox";
            this.CostBox.ReadOnly = true;
            // 
            // Width
            // 
            this.Width.DataPropertyName = "Width";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            this.Width.DefaultCellStyle = dataGridViewCellStyle7;
            this.Width.HeaderText = "Ширина, см";
            this.Width.Name = "Width";
            this.Width.ReadOnly = true;
            // 
            // Length
            // 
            this.Length.DataPropertyName = "Length";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            this.Length.DefaultCellStyle = dataGridViewCellStyle8;
            this.Length.HeaderText = "Длина, см";
            this.Length.Name = "Length";
            this.Length.ReadOnly = true;
            // 
            // Height
            // 
            this.Height.DataPropertyName = "Height";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            this.Height.DefaultCellStyle = dataGridViewCellStyle9;
            this.Height.HeaderText = "Высота, см";
            this.Height.Name = "Height";
            this.Height.ReadOnly = true;
            // 
            // Weight
            // 
            this.Weight.DataPropertyName = "Weight";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N3";
            this.Weight.DefaultCellStyle = dataGridViewCellStyle10;
            this.Weight.HeaderText = "Вес, кг";
            this.Weight.Name = "Weight";
            this.Weight.ReadOnly = true;
            // 
            // Comment
            // 
            this.Comment.DataPropertyName = "Comment";
            this.Comment.HeaderText = "Примечание";
            this.Comment.Name = "Comment";
            this.Comment.ReadOnly = true;
            this.Comment.Width = 200;
            // 
            // HasFragile
            // 
            this.HasFragile.DataPropertyName = "HasFragile";
            this.HasFragile.HeaderText = "Хрупкий";
            this.HasFragile.Name = "HasFragile";
            this.HasFragile.ReadOnly = true;
            this.HasFragile.Width = 60;
            // 
            // HasCold
            // 
            this.HasCold.DataPropertyName = "HasCold";
            this.HasCold.HeaderText = "Холод";
            this.HasCold.Name = "HasCold";
            this.HasCold.ReadOnly = true;
            this.HasCold.Width = 60;
            // 
            // ClientBoxNumber
            // 
            this.ClientBoxNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ClientBoxNumber.DataPropertyName = "ClientBoxNumber";
            this.ClientBoxNumber.HeaderText = "Клиентский номер ящика";
            this.ClientBoxNumber.Name = "ClientBoxNumber";
            this.ClientBoxNumber.ReadOnly = true;
            this.ClientBoxNumber.Width = 163;
            // 
            // dTRETTCMOrderDetailsBindingSource
            // 
            this.dTRETTCMOrderDetailsBindingSource.DataMember = "DT_RET_TCM_Order_Details";
            this.dTRETTCMOrderDetailsBindingSource.DataSource = this.delivery;
            // 
            // delivery
            // 
            this.delivery.DataSetName = "Delivery";
            this.delivery.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pnlDocDateFilter
            // 
            this.pnlDocDateFilter.BackColor = System.Drawing.SystemColors.Info;
            this.pnlDocDateFilter.Controls.Add(this.dtpDocDateTo);
            this.pnlDocDateFilter.Controls.Add(this.dtpDocDateFrom);
            this.pnlDocDateFilter.Controls.Add(this.lblDocDate);
            this.pnlDocDateFilter.Location = new System.Drawing.Point(403, 44);
            this.pnlDocDateFilter.Name = "pnlDocDateFilter";
            this.pnlDocDateFilter.Size = new System.Drawing.Size(180, 48);
            this.pnlDocDateFilter.TabIndex = 8;
            // 
            // dtpDocDateTo
            // 
            this.dtpDocDateTo.Checked = false;
            this.dtpDocDateTo.CustomFormat = "dd.MM.yyyy";
            this.dtpDocDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDocDateTo.Location = new System.Drawing.Point(62, 26);
            this.dtpDocDateTo.Name = "dtpDocDateTo";
            this.dtpDocDateTo.ShowCheckBox = true;
            this.dtpDocDateTo.Size = new System.Drawing.Size(110, 20);
            this.dtpDocDateTo.TabIndex = 2;
            // 
            // dtpDocDateFrom
            // 
            this.dtpDocDateFrom.Checked = false;
            this.dtpDocDateFrom.CustomFormat = "dd.MM.yyyy";
            this.dtpDocDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDocDateFrom.Location = new System.Drawing.Point(62, 3);
            this.dtpDocDateFrom.Name = "dtpDocDateFrom";
            this.dtpDocDateFrom.ShowCheckBox = true;
            this.dtpDocDateFrom.Size = new System.Drawing.Size(110, 20);
            this.dtpDocDateFrom.TabIndex = 1;
            // 
            // lblDocDate
            // 
            this.lblDocDate.AutoSize = true;
            this.lblDocDate.Location = new System.Drawing.Point(3, 5);
            this.lblDocDate.Name = "lblDocDate";
            this.lblDocDate.Size = new System.Drawing.Size(52, 26);
            this.lblDocDate.TabIndex = 0;
            this.lblDocDate.Text = "Период\r\nзаказов:";
            // 
            // pnlDocNumberFilter
            // 
            this.pnlDocNumberFilter.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlDocNumberFilter.Controls.Add(this.tbDocNumber);
            this.pnlDocNumberFilter.Controls.Add(this.lblDocNumber);
            this.pnlDocNumberFilter.Location = new System.Drawing.Point(589, 44);
            this.pnlDocNumberFilter.Name = "pnlDocNumberFilter";
            this.pnlDocNumberFilter.Size = new System.Drawing.Size(180, 48);
            this.pnlDocNumberFilter.TabIndex = 9;
            // 
            // tbDocNumber
            // 
            this.tbDocNumber.Location = new System.Drawing.Point(62, 3);
            this.tbDocNumber.Name = "tbDocNumber";
            this.tbDocNumber.Size = new System.Drawing.Size(110, 20);
            this.tbDocNumber.TabIndex = 1;
            // 
            // lblDocNumber
            // 
            this.lblDocNumber.AutoSize = true;
            this.lblDocNumber.Location = new System.Drawing.Point(3, 5);
            this.lblDocNumber.Name = "lblDocNumber";
            this.lblDocNumber.Size = new System.Drawing.Size(46, 26);
            this.lblDocNumber.TabIndex = 0;
            this.lblDocNumber.Text = "Номер \r\nзаказа:";
            // 
            // dT_RET_TCM_Order_DetailsTableAdapter
            // 
            this.dT_RET_TCM_Order_DetailsTableAdapter.ClearBeforeFill = true;
            // 
            // pnlDocStatusFilter
            // 
            this.pnlDocStatusFilter.BackColor = System.Drawing.Color.Bisque;
            this.pnlDocStatusFilter.Controls.Add(this.tbDocStatusTo);
            this.pnlDocStatusFilter.Controls.Add(this.tbDocStatusFrom);
            this.pnlDocStatusFilter.Controls.Add(this.stbDocStatusTo);
            this.pnlDocStatusFilter.Controls.Add(this.stbDocStatusFrom);
            this.pnlDocStatusFilter.Controls.Add(this.label1);
            this.pnlDocStatusFilter.Location = new System.Drawing.Point(775, 44);
            this.pnlDocStatusFilter.Name = "pnlDocStatusFilter";
            this.pnlDocStatusFilter.Size = new System.Drawing.Size(410, 48);
            this.pnlDocStatusFilter.TabIndex = 10;
            // 
            // tbDocStatusTo
            // 
            this.tbDocStatusTo.BackColor = System.Drawing.SystemColors.Window;
            this.tbDocStatusTo.Location = new System.Drawing.Point(168, 26);
            this.tbDocStatusTo.Name = "tbDocStatusTo";
            this.tbDocStatusTo.ReadOnly = true;
            this.tbDocStatusTo.Size = new System.Drawing.Size(235, 20);
            this.tbDocStatusTo.TabIndex = 4;
            // 
            // tbDocStatusFrom
            // 
            this.tbDocStatusFrom.BackColor = System.Drawing.SystemColors.Window;
            this.tbDocStatusFrom.Location = new System.Drawing.Point(168, 3);
            this.tbDocStatusFrom.Name = "tbDocStatusFrom";
            this.tbDocStatusFrom.ReadOnly = true;
            this.tbDocStatusFrom.Size = new System.Drawing.Size(235, 20);
            this.tbDocStatusFrom.TabIndex = 2;
            // 
            // stbDocStatusTo
            // 
            this.stbDocStatusTo.Location = new System.Drawing.Point(62, 26);
            this.stbDocStatusTo.Name = "stbDocStatusTo";
            this.stbDocStatusTo.NavigateByValue = false;
            this.stbDocStatusTo.ReadOnly = false;
            this.stbDocStatusTo.Size = new System.Drawing.Size(100, 20);
            this.stbDocStatusTo.TabIndex = 3;
            this.stbDocStatusTo.UserID = ((long)(0));
            this.stbDocStatusTo.Value = null;
            this.stbDocStatusTo.ValueReferenceQuery = null;
            // 
            // stbDocStatusFrom
            // 
            this.stbDocStatusFrom.Location = new System.Drawing.Point(62, 3);
            this.stbDocStatusFrom.Name = "stbDocStatusFrom";
            this.stbDocStatusFrom.NavigateByValue = false;
            this.stbDocStatusFrom.ReadOnly = false;
            this.stbDocStatusFrom.Size = new System.Drawing.Size(100, 20);
            this.stbDocStatusFrom.TabIndex = 1;
            this.stbDocStatusFrom.UserID = ((long)(0));
            this.stbDocStatusFrom.Value = null;
            this.stbDocStatusFrom.ValueReferenceQuery = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Статус\r\nзаказов:";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 52);
            // 
            // btnRepeatDelivery
            // 
            this.btnRepeatDelivery.Image = global::WMSOffice.Properties.Resources.repeat;
            this.btnRepeatDelivery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRepeatDelivery.Name = "btnRepeatDelivery";
            this.btnRepeatDelivery.Size = new System.Drawing.Size(129, 49);
            this.btnRepeatDelivery.Text = "Повторная доставка...";
            this.btnRepeatDelivery.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRepeatDelivery.Click += new System.EventHandler(this.btnRepeatDelivery_Click);
            // 
            // TransitDeliveryWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 705);
            this.Controls.Add(this.pnlDocStatusFilter);
            this.Controls.Add(this.pnlDocNumberFilter);
            this.Controls.Add(this.pnlDocDateFilter);
            this.Controls.Add(this.pnlMainContent);
            this.Controls.Add(this.tsMain);
            this.Name = "TransitDeliveryWindow";
            this.Text = "TransitDeliveryWindow";
            this.Controls.SetChildIndex(this.tsMain, 0);
            this.Controls.SetChildIndex(this.pnlMainContent, 0);
            this.Controls.SetChildIndex(this.pnlDocDateFilter, 0);
            this.Controls.SetChildIndex(this.pnlDocNumberFilter, 0);
            this.Controls.SetChildIndex(this.pnlDocStatusFilter, 0);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.pnlMainContent.ResumeLayout(false);
            this.scContent.Panel1.ResumeLayout(false);
            this.scContent.Panel2.ResumeLayout(false);
            this.scContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTRETTCMOrderDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.delivery)).EndInit();
            this.pnlDocDateFilter.ResumeLayout(false);
            this.pnlDocDateFilter.PerformLayout();
            this.pnlDocNumberFilter.ResumeLayout(false);
            this.pnlDocNumberFilter.PerformLayout();
            this.pnlDocStatusFilter.ResumeLayout(false);
            this.pnlDocStatusFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btnLoadData;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnExport;
        private System.Windows.Forms.Panel pnlMainContent;
        private System.Windows.Forms.SplitContainer scContent;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvOrders;
        private System.Windows.Forms.DataGridView dgvOrderDetails;
        private System.Windows.Forms.ToolStripButton btnPrintEtic;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Panel pnlDocDateFilter;
        private System.Windows.Forms.DateTimePicker dtpDocDateFrom;
        private System.Windows.Forms.Label lblDocDate;
        private System.Windows.Forms.Panel pnlDocNumberFilter;
        private System.Windows.Forms.TextBox tbDocNumber;
        private System.Windows.Forms.Label lblDocNumber;
        private System.Windows.Forms.DateTimePicker dtpDocDateTo;
        private System.Windows.Forms.BindingSource dTRETTCMOrderDetailsBindingSource;
        private WMSOffice.Data.Delivery delivery;
        private WMSOffice.Data.DeliveryTableAdapters.DT_RET_TCM_Order_DetailsTableAdapter dT_RET_TCM_Order_DetailsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tareTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tareBarCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CostBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Width;
        private System.Windows.Forms.DataGridViewTextBoxColumn Length;
        private System.Windows.Forms.DataGridViewTextBoxColumn Height;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
        private System.Windows.Forms.DataGridViewCheckBoxColumn HasFragile;
        private System.Windows.Forms.DataGridViewCheckBoxColumn HasCold;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientBoxNumber;
        private System.Windows.Forms.Panel pnlDocStatusFilter;
        private System.Windows.Forms.Label label1;
        private WMSOffice.Controls.SearchTextBox stbDocStatusTo;
        private WMSOffice.Controls.SearchTextBox stbDocStatusFrom;
        private System.Windows.Forms.TextBox tbDocStatusTo;
        private System.Windows.Forms.TextBox tbDocStatusFrom;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnRepeatDelivery;

    }
}