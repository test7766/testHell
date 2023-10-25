namespace WMSOffice.Window
{
    partial class DebtorsReturnedTareActsReprintWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCreate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.dtpPeriodTo = new System.Windows.Forms.DateTimePicker();
            this.dtpPeriodFrom = new System.Windows.Forms.DateTimePicker();
            this.lblPeriodTo = new System.Windows.Forms.Label();
            this.lblPeriodFrom = new System.Windows.Forms.Label();
            this.lblDeliveryID = new System.Windows.Forms.Label();
            this.tblDeliveryID = new System.Windows.Forms.TextBox();
            this.stbDeliveryID = new WMSOffice.Controls.SearchTextBox();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.dgvActs = new System.Windows.Forms.DataGridView();
            this.docDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.routeNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deliveryIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warehouseIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityBoxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityCapDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lTActsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.delivery = new WMSOffice.Data.Delivery();
            this.lT_ActsTableAdapter = new WMSOffice.Data.DeliveryTableAdapters.LT_ActsTableAdapter();
            this.toolStrip1.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lTActsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.delivery)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.toolStripSeparator1,
            this.btnCreate,
            this.toolStripSeparator2,
            this.btnPrint});
            this.toolStrip1.Location = new System.Drawing.Point(0, 40);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(953, 39);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "tsMain";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(93, 36);
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // btnCreate
            // 
            this.btnCreate.Image = global::WMSOffice.Properties.Resources.add_document;
            this.btnCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(107, 36);
            this.btnCreate.Text = "Создать акт";
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::WMSOffice.Properties.Resources.document_print_preview;
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(107, 36);
            this.btnPrint.Text = "Печать акта";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.dtpPeriodTo);
            this.pnlFilter.Controls.Add(this.dtpPeriodFrom);
            this.pnlFilter.Controls.Add(this.lblPeriodTo);
            this.pnlFilter.Controls.Add(this.lblPeriodFrom);
            this.pnlFilter.Controls.Add(this.lblDeliveryID);
            this.pnlFilter.Controls.Add(this.tblDeliveryID);
            this.pnlFilter.Controls.Add(this.stbDeliveryID);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 79);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(953, 62);
            this.pnlFilter.TabIndex = 2;
            // 
            // dtpPeriodTo
            // 
            this.dtpPeriodTo.CustomFormat = "dd.MM.yyyy";
            this.dtpPeriodTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriodTo.Location = new System.Drawing.Point(329, 35);
            this.dtpPeriodTo.Name = "dtpPeriodTo";
            this.dtpPeriodTo.Size = new System.Drawing.Size(101, 20);
            this.dtpPeriodTo.TabIndex = 6;
            // 
            // dtpPeriodFrom
            // 
            this.dtpPeriodFrom.CustomFormat = "dd.MM.yyyy";
            this.dtpPeriodFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriodFrom.Location = new System.Drawing.Point(109, 35);
            this.dtpPeriodFrom.Name = "dtpPeriodFrom";
            this.dtpPeriodFrom.Size = new System.Drawing.Size(101, 20);
            this.dtpPeriodFrom.TabIndex = 4;
            // 
            // lblPeriodTo
            // 
            this.lblPeriodTo.AutoSize = true;
            this.lblPeriodTo.Location = new System.Drawing.Point(250, 39);
            this.lblPeriodTo.Name = "lblPeriodTo";
            this.lblPeriodTo.Size = new System.Drawing.Size(63, 13);
            this.lblPeriodTo.TabIndex = 5;
            this.lblPeriodTo.Text = "Период по:";
            // 
            // lblPeriodFrom
            // 
            this.lblPeriodFrom.AutoSize = true;
            this.lblPeriodFrom.Location = new System.Drawing.Point(42, 39);
            this.lblPeriodFrom.Name = "lblPeriodFrom";
            this.lblPeriodFrom.Size = new System.Drawing.Size(57, 13);
            this.lblPeriodFrom.TabIndex = 3;
            this.lblPeriodFrom.Text = "Период с:";
            // 
            // lblDeliveryID
            // 
            this.lblDeliveryID.AutoSize = true;
            this.lblDeliveryID.Location = new System.Drawing.Point(10, 10);
            this.lblDeliveryID.Name = "lblDeliveryID";
            this.lblDeliveryID.Size = new System.Drawing.Size(89, 13);
            this.lblDeliveryID.TabIndex = 0;
            this.lblDeliveryID.Text = "Торговая точка:";
            // 
            // tblDeliveryID
            // 
            this.tblDeliveryID.Location = new System.Drawing.Point(215, 6);
            this.tblDeliveryID.Name = "tblDeliveryID";
            this.tblDeliveryID.Size = new System.Drawing.Size(700, 20);
            this.tblDeliveryID.TabIndex = 2;
            // 
            // stbDeliveryID
            // 
            this.stbDeliveryID.Location = new System.Drawing.Point(109, 6);
            this.stbDeliveryID.Name = "stbDeliveryID";
            this.stbDeliveryID.NavigateByValue = false;
            this.stbDeliveryID.ReadOnly = false;
            this.stbDeliveryID.Size = new System.Drawing.Size(100, 20);
            this.stbDeliveryID.TabIndex = 1;
            this.stbDeliveryID.UserID = ((long)(0));
            this.stbDeliveryID.Value = null;
            this.stbDeliveryID.ValueReferenceQuery = null;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.dgvActs);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 141);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(953, 247);
            this.pnlContent.TabIndex = 3;
            // 
            // dgvActs
            // 
            this.dgvActs.AllowUserToAddRows = false;
            this.dgvActs.AllowUserToDeleteRows = false;
            this.dgvActs.AllowUserToResizeColumns = false;
            this.dgvActs.AllowUserToResizeRows = false;
            this.dgvActs.AutoGenerateColumns = false;
            this.dgvActs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvActs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.docDataGridViewTextBoxColumn,
            this.docTypeDataGridViewTextBoxColumn,
            this.docDateDataGridViewTextBoxColumn,
            this.routeNumberDataGridViewTextBoxColumn,
            this.deliveryIDDataGridViewTextBoxColumn,
            this.warehouseIDDataGridViewTextBoxColumn,
            this.quantityBoxDataGridViewTextBoxColumn,
            this.quantityCapDataGridViewTextBoxColumn,
            this.docStatusDataGridViewTextBoxColumn});
            this.dgvActs.DataSource = this.lTActsBindingSource;
            this.dgvActs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvActs.Location = new System.Drawing.Point(0, 0);
            this.dgvActs.MultiSelect = false;
            this.dgvActs.Name = "dgvActs";
            this.dgvActs.ReadOnly = true;
            this.dgvActs.RowHeadersVisible = false;
            this.dgvActs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvActs.Size = new System.Drawing.Size(953, 247);
            this.dgvActs.TabIndex = 0;
            this.dgvActs.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvActs_CellFormatting);
            this.dgvActs.SelectionChanged += new System.EventHandler(this.dgvActs_SelectionChanged);
            // 
            // docDataGridViewTextBoxColumn
            // 
            this.docDataGridViewTextBoxColumn.DataPropertyName = "Doc";
            this.docDataGridViewTextBoxColumn.HeaderText = "Номер акта";
            this.docDataGridViewTextBoxColumn.Name = "docDataGridViewTextBoxColumn";
            this.docDataGridViewTextBoxColumn.ReadOnly = true;
            this.docDataGridViewTextBoxColumn.Width = 85;
            // 
            // docTypeDataGridViewTextBoxColumn
            // 
            this.docTypeDataGridViewTextBoxColumn.DataPropertyName = "DocType";
            this.docTypeDataGridViewTextBoxColumn.HeaderText = "Тип акта";
            this.docTypeDataGridViewTextBoxColumn.Name = "docTypeDataGridViewTextBoxColumn";
            this.docTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.docTypeDataGridViewTextBoxColumn.Width = 71;
            // 
            // docDateDataGridViewTextBoxColumn
            // 
            this.docDateDataGridViewTextBoxColumn.DataPropertyName = "DocDate";
            dataGridViewCellStyle1.Format = "dd.MM.yyyy";
            this.docDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.docDateDataGridViewTextBoxColumn.HeaderText = "Дата акта";
            this.docDateDataGridViewTextBoxColumn.Name = "docDateDataGridViewTextBoxColumn";
            this.docDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.docDateDataGridViewTextBoxColumn.Width = 78;
            // 
            // routeNumberDataGridViewTextBoxColumn
            // 
            this.routeNumberDataGridViewTextBoxColumn.DataPropertyName = "RouteNumber";
            this.routeNumberDataGridViewTextBoxColumn.HeaderText = "Маршрутный лист";
            this.routeNumberDataGridViewTextBoxColumn.Name = "routeNumberDataGridViewTextBoxColumn";
            this.routeNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.routeNumberDataGridViewTextBoxColumn.Width = 113;
            // 
            // deliveryIDDataGridViewTextBoxColumn
            // 
            this.deliveryIDDataGridViewTextBoxColumn.DataPropertyName = "DeliveryID";
            this.deliveryIDDataGridViewTextBoxColumn.HeaderText = "Код ТТ";
            this.deliveryIDDataGridViewTextBoxColumn.Name = "deliveryIDDataGridViewTextBoxColumn";
            this.deliveryIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.deliveryIDDataGridViewTextBoxColumn.Width = 51;
            // 
            // warehouseIDDataGridViewTextBoxColumn
            // 
            this.warehouseIDDataGridViewTextBoxColumn.DataPropertyName = "WarehouseID";
            this.warehouseIDDataGridViewTextBoxColumn.HeaderText = "Склад";
            this.warehouseIDDataGridViewTextBoxColumn.Name = "warehouseIDDataGridViewTextBoxColumn";
            this.warehouseIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.warehouseIDDataGridViewTextBoxColumn.Width = 63;
            // 
            // quantityBoxDataGridViewTextBoxColumn
            // 
            this.quantityBoxDataGridViewTextBoxColumn.DataPropertyName = "QuantityBox";
            this.quantityBoxDataGridViewTextBoxColumn.HeaderText = "Кол-во ящиков";
            this.quantityBoxDataGridViewTextBoxColumn.Name = "quantityBoxDataGridViewTextBoxColumn";
            this.quantityBoxDataGridViewTextBoxColumn.ReadOnly = true;
            this.quantityBoxDataGridViewTextBoxColumn.Width = 99;
            // 
            // quantityCapDataGridViewTextBoxColumn
            // 
            this.quantityCapDataGridViewTextBoxColumn.DataPropertyName = "QuantityCap";
            this.quantityCapDataGridViewTextBoxColumn.HeaderText = "Кол-во крышек";
            this.quantityCapDataGridViewTextBoxColumn.Name = "quantityCapDataGridViewTextBoxColumn";
            this.quantityCapDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // docStatusDataGridViewTextBoxColumn
            // 
            this.docStatusDataGridViewTextBoxColumn.DataPropertyName = "DocStatus";
            this.docStatusDataGridViewTextBoxColumn.HeaderText = "Статус акта";
            this.docStatusDataGridViewTextBoxColumn.Name = "docStatusDataGridViewTextBoxColumn";
            this.docStatusDataGridViewTextBoxColumn.ReadOnly = true;
            this.docStatusDataGridViewTextBoxColumn.Width = 85;
            // 
            // lTActsBindingSource
            // 
            this.lTActsBindingSource.DataMember = "LT_Acts";
            this.lTActsBindingSource.DataSource = this.delivery;
            // 
            // delivery
            // 
            this.delivery.DataSetName = "Delivery";
            this.delivery.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lT_ActsTableAdapter
            // 
            this.lT_ActsTableAdapter.ClearBeforeFill = true;
            // 
            // DebtorsReturnedTareActsReprintWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 388);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.toolStrip1);
            this.Name = "DebtorsReturnedTareActsReprintWindow";
            this.Text = "DebtorsReturnedTareActsReprintWindow";
            this.Controls.SetChildIndex(this.toolStrip1, 0);
            this.Controls.SetChildIndex(this.pnlFilter, 0);
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lTActsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.delivery)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.DataGridView dgvActs;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.Label lblDeliveryID;
        private System.Windows.Forms.TextBox tblDeliveryID;
        private WMSOffice.Controls.SearchTextBox stbDeliveryID;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DateTimePicker dtpPeriodTo;
        private System.Windows.Forms.DateTimePicker dtpPeriodFrom;
        private System.Windows.Forms.Label lblPeriodTo;
        private System.Windows.Forms.Label lblPeriodFrom;
        private System.Windows.Forms.ToolStripButton btnCreate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.BindingSource lTActsBindingSource;
        private WMSOffice.Data.Delivery delivery;
        private WMSOffice.Data.DeliveryTableAdapters.LT_ActsTableAdapter lT_ActsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn docDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn routeNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deliveryIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn warehouseIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityBoxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityCapDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docStatusDataGridViewTextBoxColumn;
    }
}