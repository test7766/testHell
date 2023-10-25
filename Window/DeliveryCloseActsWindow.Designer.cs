namespace WMSOffice.Window
{
    partial class DeliveryCloseActsWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStripDoc = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAssignDataLogger = new System.Windows.Forms.ToolStripButton();
            this.btnAssignTermoBox = new System.Windows.Forms.ToolStripButton();
            this.btnRegistrationOnRoute = new System.Windows.Forms.ToolStripButton();
            this.btnShowRouteDataLoggers = new System.Windows.Forms.ToolStripButton();
            this.sbTermoboxMoveHistory = new System.Windows.Forms.ToolStripButton();
            this.btnCloseAct = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbBarcode = new WMSOffice.Controls.TextBoxScaner();
            this.cmDocs = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.label10 = new System.Windows.Forms.Label();
            this.delivery = new WMSOffice.Data.Delivery();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.xdgvLines = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.itemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorLotDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notClosedActsDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.notClosedActsDetailsTableAdapter = new WMSOffice.Data.DeliveryTableAdapters.NotClosedActsDetailsTableAdapter();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStripDoc.SuspendLayout();
            this.panel1.SuspendLayout();
            this.cmDocs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.delivery)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notClosedActsDetailsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 40);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.toolStripDoc);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(1445, 56);
            this.splitContainer1.SplitterDistance = 1058;
            this.splitContainer1.TabIndex = 6;
            // 
            // toolStripDoc
            // 
            this.toolStripDoc.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStripDoc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.toolStripSeparator1,
            this.btnExport,
            this.toolStripSeparator2,
            this.btnAssignDataLogger,
            this.btnAssignTermoBox,
            this.btnRegistrationOnRoute,
            this.btnShowRouteDataLoggers,
            this.sbTermoboxMoveHistory,
            this.btnCloseAct});
            this.toolStripDoc.Location = new System.Drawing.Point(0, 0);
            this.toolStripDoc.Name = "toolStripDoc";
            this.toolStripDoc.Size = new System.Drawing.Size(1058, 55);
            this.toolStripDoc.TabIndex = 5;
            this.toolStripDoc.Text = "Панель инструментов документа";
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(52, 52);
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // btnExport
            // 
            this.btnExport.Image = global::WMSOffice.Properties.Resources.Excel;
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(107, 52);
            this.btnExport.Text = "Экспорт\nтаблицы\nв Excel";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // btnAssignDataLogger
            // 
            this.btnAssignDataLogger.Image = global::WMSOffice.Properties.Resources.Sensor;
            this.btnAssignDataLogger.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAssignDataLogger.Name = "btnAssignDataLogger";
            this.btnAssignDataLogger.Size = new System.Drawing.Size(116, 52);
            this.btnAssignDataLogger.Text = "Закрепить\nлоггер";
            this.btnAssignDataLogger.Click += new System.EventHandler(this.btnAssignDataLogger_Click);
            // 
            // btnAssignTermoBox
            // 
            this.btnAssignTermoBox.Image = global::WMSOffice.Properties.Resources.cold_chain_icon_75;
            this.btnAssignTermoBox.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAssignTermoBox.Name = "btnAssignTermoBox";
            this.btnAssignTermoBox.Size = new System.Drawing.Size(164, 52);
            this.btnAssignTermoBox.Text = "Закрепить/вернуть\nтермобокс";
            this.btnAssignTermoBox.Click += new System.EventHandler(this.btnAssignTermoBox_Click);
            // 
            // btnRegistrationOnRoute
            // 
            this.btnRegistrationOnRoute.Image = global::WMSOffice.Properties.Resources.assign;
            this.btnRegistrationOnRoute.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRegistrationOnRoute.Name = "btnRegistrationOnRoute";
            this.btnRegistrationOnRoute.Size = new System.Drawing.Size(132, 52);
            this.btnRegistrationOnRoute.Text = "Регистрация\nна маршруте";
            this.btnRegistrationOnRoute.Click += new System.EventHandler(this.btnRegistrationOnRoute_Click);
            // 
            // btnShowRouteDataLoggers
            // 
            this.btnShowRouteDataLoggers.Image = global::WMSOffice.Properties.Resources.table2_information;
            this.btnShowRouteDataLoggers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowRouteDataLoggers.Name = "btnShowRouteDataLoggers";
            this.btnShowRouteDataLoggers.Size = new System.Drawing.Size(132, 52);
            this.btnShowRouteDataLoggers.Text = "Логгеры\nна маршруте";
            this.btnShowRouteDataLoggers.Click += new System.EventHandler(this.btnShowRouteDataLoggers_Click);
            // 
            // sbTermoboxMoveHistory
            // 
            this.sbTermoboxMoveHistory.Image = global::WMSOffice.Properties.Resources.folder_documents;
            this.sbTermoboxMoveHistory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbTermoboxMoveHistory.Name = "sbTermoboxMoveHistory";
            this.sbTermoboxMoveHistory.Size = new System.Drawing.Size(163, 52);
            this.sbTermoboxMoveHistory.Text = "История движения\nтермобокса";
            this.sbTermoboxMoveHistory.Click += new System.EventHandler(this.sbTermoboxMoveHistory_Click);
            // 
            // btnCloseAct
            // 
            this.btnCloseAct.Image = global::WMSOffice.Properties.Resources.document_ok;
            this.btnCloseAct.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCloseAct.Name = "btnCloseAct";
            this.btnCloseAct.Size = new System.Drawing.Size(105, 52);
            this.btnCloseAct.Text = "Закрыть\nакт";
            this.btnCloseAct.Click += new System.EventHandler(this.btnCloseAct_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbBarcode);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(383, 56);
            this.panel1.TabIndex = 2;
            // 
            // tbBarcode
            // 
            this.tbBarcode.AllowType = true;
            this.tbBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBarcode.AutoConvert = true;
            this.tbBarcode.ContextMenuStrip = this.cmDocs;
            this.tbBarcode.DelayThreshold = 50D;
            this.tbBarcode.Location = new System.Drawing.Point(74, 16);
            this.tbBarcode.Name = "tbBarcode";
            this.tbBarcode.RaiseTextChangeWithoutEnter = false;
            this.tbBarcode.ReadOnly = false;
            this.tbBarcode.Size = new System.Drawing.Size(297, 25);
            this.tbBarcode.TabIndex = 2;
            this.tbBarcode.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.tbBarcode.UseParentFont = false;
            this.tbBarcode.UseScanModeOnly = false;
            this.tbBarcode.TextChanged += new System.EventHandler(this.tbBarcode_TextChanged);
            // 
            // cmDocs
            // 
            this.cmDocs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miRefresh});
            this.cmDocs.Name = "cmDocs";
            this.cmDocs.Size = new System.Drawing.Size(148, 26);
            // 
            // miRefresh
            // 
            this.miRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.miRefresh.Name = "miRefresh";
            this.miRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.miRefresh.Size = new System.Drawing.Size(147, 22);
            this.miRefresh.Text = "&Обновить";
            this.miRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Штрих-код:";
            // 
            // delivery
            // 
            this.delivery.DataSetName = "Delivery";
            this.delivery.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 96);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.xdgvLines);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgvDetails);
            this.splitContainer2.Size = new System.Drawing.Size(1445, 597);
            this.splitContainer2.SplitterDistance = 462;
            this.splitContainer2.TabIndex = 8;
            // 
            // xdgvLines
            // 
            this.xdgvLines.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvLines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvLines.LargeAmountOfData = false;
            this.xdgvLines.Location = new System.Drawing.Point(0, 0);
            this.xdgvLines.Name = "xdgvLines";
            this.xdgvLines.RowHeadersVisible = false;
            this.xdgvLines.Size = new System.Drawing.Size(1445, 462);
            this.xdgvLines.TabIndex = 8;
            this.xdgvLines.UserID = ((long)(0));
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.AllowUserToResizeRows = false;
            this.dgvDetails.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemIDDataGridViewTextBoxColumn,
            this.itemNameDataGridViewTextBoxColumn,
            this.manufacturerDataGridViewTextBoxColumn,
            this.vendorLotDataGridViewTextBoxColumn,
            this.expDateDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn});
            this.dgvDetails.DataSource = this.notClosedActsDetailsBindingSource;
            this.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails.Location = new System.Drawing.Point(0, 0);
            this.dgvDetails.MultiSelect = false;
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetails.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDetails.RowHeadersVisible = false;
            this.dgvDetails.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetails.ShowEditingIcon = false;
            this.dgvDetails.Size = new System.Drawing.Size(1445, 131);
            this.dgvDetails.TabIndex = 0;
            // 
            // itemIDDataGridViewTextBoxColumn
            // 
            this.itemIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemIDDataGridViewTextBoxColumn.DataPropertyName = "Item_ID";
            this.itemIDDataGridViewTextBoxColumn.HeaderText = "Код товара";
            this.itemIDDataGridViewTextBoxColumn.Name = "itemIDDataGridViewTextBoxColumn";
            this.itemIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemIDDataGridViewTextBoxColumn.Width = 107;
            // 
            // itemNameDataGridViewTextBoxColumn
            // 
            this.itemNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemNameDataGridViewTextBoxColumn.DataPropertyName = "Item_Name";
            this.itemNameDataGridViewTextBoxColumn.HeaderText = "Наименование";
            this.itemNameDataGridViewTextBoxColumn.Name = "itemNameDataGridViewTextBoxColumn";
            this.itemNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemNameDataGridViewTextBoxColumn.Width = 132;
            // 
            // manufacturerDataGridViewTextBoxColumn
            // 
            this.manufacturerDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.manufacturerDataGridViewTextBoxColumn.DataPropertyName = "Manufacturer";
            this.manufacturerDataGridViewTextBoxColumn.HeaderText = "Производитель";
            this.manufacturerDataGridViewTextBoxColumn.Name = "manufacturerDataGridViewTextBoxColumn";
            this.manufacturerDataGridViewTextBoxColumn.ReadOnly = true;
            this.manufacturerDataGridViewTextBoxColumn.Width = 137;
            // 
            // vendorLotDataGridViewTextBoxColumn
            // 
            this.vendorLotDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.vendorLotDataGridViewTextBoxColumn.DataPropertyName = "Vendor_Lot";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.vendorLotDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.vendorLotDataGridViewTextBoxColumn.HeaderText = "Серия";
            this.vendorLotDataGridViewTextBoxColumn.Name = "vendorLotDataGridViewTextBoxColumn";
            this.vendorLotDataGridViewTextBoxColumn.ReadOnly = true;
            this.vendorLotDataGridViewTextBoxColumn.Width = 73;
            // 
            // expDateDataGridViewTextBoxColumn
            // 
            this.expDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.expDateDataGridViewTextBoxColumn.DataPropertyName = "ExpDate";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.expDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.expDateDataGridViewTextBoxColumn.HeaderText = "Срок годности";
            this.expDateDataGridViewTextBoxColumn.Name = "expDateDataGridViewTextBoxColumn";
            this.expDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.expDateDataGridViewTextBoxColumn.Width = 128;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.quantityDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Количество";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.ReadOnly = true;
            this.quantityDataGridViewTextBoxColumn.Width = 111;
            // 
            // notClosedActsDetailsBindingSource
            // 
            this.notClosedActsDetailsBindingSource.DataMember = "NotClosedActsDetails";
            this.notClosedActsDetailsBindingSource.DataSource = this.delivery;
            // 
            // notClosedActsDetailsTableAdapter
            // 
            this.notClosedActsDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // DeliveryCloseActsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1445, 693);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.splitContainer1);
            this.Name = "DeliveryCloseActsWindow";
            this.Text = "DeliveryCloseActsWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DeliveryCloseActsWindow_FormClosing);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.Controls.SetChildIndex(this.splitContainer2, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.toolStripDoc.ResumeLayout(false);
            this.toolStripDoc.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.cmDocs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.delivery)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notClosedActsDetailsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label10;
        private WMSOffice.Controls.TextBoxScaner tbBarcode;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStripDoc;
        private System.Windows.Forms.ToolStripButton btnExport;
        private WMSOffice.Data.Delivery delivery;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ContextMenuStrip cmDocs;
        private System.Windows.Forms.ToolStripMenuItem miRefresh;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.BindingSource notClosedActsDetailsBindingSource;
        private WMSOffice.Data.DeliveryTableAdapters.NotClosedActsDetailsTableAdapter notClosedActsDetailsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorLotDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnAssignDataLogger;
        private System.Windows.Forms.ToolStripButton btnAssignTermoBox;
        private System.Windows.Forms.ToolStripButton btnShowRouteDataLoggers;
        private System.Windows.Forms.ToolStripButton btnCloseAct;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvLines;
        private System.Windows.Forms.ToolStripButton sbTermoboxMoveHistory;
        private System.Windows.Forms.ToolStripButton btnRegistrationOnRoute;


    }
}