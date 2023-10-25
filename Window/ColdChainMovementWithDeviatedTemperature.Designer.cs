namespace WMSOffice.Window
{
    partial class ColdChainMovementWithDeviatedTemperature
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsMainMenu = new System.Windows.Forms.ToolStrip();
            this.sbRefreshData = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.sbPrintOrder = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmbPrinters = new System.Windows.Forms.ToolStripComboBox();
            this.lblPrinters = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.sbCompleteOrder = new System.Windows.Forms.ToolStripButton();
            this.dgvMainGrid = new System.Windows.Forms.DataGridView();
            this.movementDeviatedItemsHeadersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.coldChain = new WMSOffice.Data.ColdChain();
            this.scMainDoc = new System.Windows.Forms.SplitContainer();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.perronIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eticDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pickSlipNumnerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderNumberTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorLotDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expirationDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitOfMeasureDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.movementDeviatedItemsDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.movementDeviatedItemsHeadersTableAdapter = new WMSOffice.Data.ColdChainTableAdapters.MovementDeviatedItemsHeadersTableAdapter();
            this.movementDeviatedItemsDetailsTableAdapter = new WMSOffice.Data.ColdChainTableAdapters.MovementDeviatedItemsDetailsTableAdapter();
            this.movementIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.branchIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsMainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMainGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.movementDeviatedItemsHeadersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coldChain)).BeginInit();
            this.scMainDoc.Panel1.SuspendLayout();
            this.scMainDoc.Panel2.SuspendLayout();
            this.scMainDoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.movementDeviatedItemsDetailsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMainMenu
            // 
            this.tsMainMenu.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbRefreshData,
            this.toolStripSeparator1,
            this.sbPrintOrder,
            this.toolStripSeparator2,
            this.cmbPrinters,
            this.lblPrinters,
            this.toolStripSeparator3,
            this.sbCompleteOrder});
            this.tsMainMenu.Location = new System.Drawing.Point(0, 40);
            this.tsMainMenu.Name = "tsMainMenu";
            this.tsMainMenu.Size = new System.Drawing.Size(1156, 55);
            this.tsMainMenu.TabIndex = 1;
            this.tsMainMenu.Text = "toolStrip1";
            // 
            // sbRefreshData
            // 
            this.sbRefreshData.Image = global::WMSOffice.Properties.Resources.refresh;
            this.sbRefreshData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbRefreshData.Name = "sbRefreshData";
            this.sbRefreshData.Size = new System.Drawing.Size(113, 52);
            this.sbRefreshData.Text = "Обновить";
            this.sbRefreshData.Click += new System.EventHandler(this.sbRefreshData_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // sbPrintOrder
            // 
            this.sbPrintOrder.Image = global::WMSOffice.Properties.Resources.document_print;
            this.sbPrintOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbPrintOrder.Name = "sbPrintOrder";
            this.sbPrintOrder.Size = new System.Drawing.Size(124, 52);
            this.sbPrintOrder.Text = "Печать акта";
            this.sbPrintOrder.Click += new System.EventHandler(this.sbPrintOrder_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // cmbPrinters
            // 
            this.cmbPrinters.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cmbPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinters.Name = "cmbPrinters";
            this.cmbPrinters.Size = new System.Drawing.Size(250, 55);
            // 
            // lblPrinters
            // 
            this.lblPrinters.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblPrinters.Name = "lblPrinters";
            this.lblPrinters.Size = new System.Drawing.Size(58, 52);
            this.lblPrinters.Text = "Принтер:";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 55);
            // 
            // sbCompleteOrder
            // 
            this.sbCompleteOrder.Image = global::WMSOffice.Properties.Resources.document_ok;
            this.sbCompleteOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbCompleteOrder.Name = "sbCompleteOrder";
            this.sbCompleteOrder.Size = new System.Drawing.Size(125, 52);
            this.sbCompleteOrder.Text = "Закрыть акт";
            this.sbCompleteOrder.Click += new System.EventHandler(this.sbCompleteOrder_Click);
            // 
            // dgvMainGrid
            // 
            this.dgvMainGrid.AllowUserToAddRows = false;
            this.dgvMainGrid.AllowUserToDeleteRows = false;
            this.dgvMainGrid.AllowUserToResizeRows = false;
            this.dgvMainGrid.AutoGenerateColumns = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMainGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvMainGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMainGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.movementIDDataGridViewTextBoxColumn,
            this.branchIDDataGridViewTextBoxColumn,
            this.statusNameDataGridViewTextBoxColumn});
            this.dgvMainGrid.DataSource = this.movementDeviatedItemsHeadersBindingSource;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMainGrid.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvMainGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMainGrid.Location = new System.Drawing.Point(0, 0);
            this.dgvMainGrid.MultiSelect = false;
            this.dgvMainGrid.Name = "dgvMainGrid";
            this.dgvMainGrid.ReadOnly = true;
            this.dgvMainGrid.RowHeadersVisible = false;
            this.dgvMainGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMainGrid.Size = new System.Drawing.Size(1156, 180);
            this.dgvMainGrid.TabIndex = 2;
            // 
            // movementDeviatedItemsHeadersBindingSource
            // 
            this.movementDeviatedItemsHeadersBindingSource.DataMember = "MovementDeviatedItemsHeaders";
            this.movementDeviatedItemsHeadersBindingSource.DataSource = this.coldChain;
            // 
            // coldChain
            // 
            this.coldChain.DataSetName = "ColdChain";
            this.coldChain.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // scMainDoc
            // 
            this.scMainDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMainDoc.Location = new System.Drawing.Point(0, 95);
            this.scMainDoc.Name = "scMainDoc";
            this.scMainDoc.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMainDoc.Panel1
            // 
            this.scMainDoc.Panel1.Controls.Add(this.dgvMainGrid);
            // 
            // scMainDoc.Panel2
            // 
            this.scMainDoc.Panel2.Controls.Add(this.dgvItems);
            this.scMainDoc.Size = new System.Drawing.Size(1156, 412);
            this.scMainDoc.SplitterDistance = 180;
            this.scMainDoc.TabIndex = 3;
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AllowUserToResizeRows = false;
            this.dgvItems.AutoGenerateColumns = false;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.perronIDDataGridViewTextBoxColumn,
            this.eticDataGridViewTextBoxColumn,
            this.pickSlipNumnerDataGridViewTextBoxColumn,
            this.orderNumberTypeDataGridViewTextBoxColumn,
            this.orderNumberDataGridViewTextBoxColumn,
            this.itemIDDataGridViewTextBoxColumn,
            this.itemDataGridViewTextBoxColumn,
            this.vendorLotDataGridViewTextBoxColumn,
            this.expirationDateDataGridViewTextBoxColumn,
            this.unitOfMeasureDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn});
            this.dgvItems.DataSource = this.movementDeviatedItemsDetailsBindingSource;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvItems.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItems.Location = new System.Drawing.Point(0, 0);
            this.dgvItems.MultiSelect = false;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(1156, 228);
            this.dgvItems.TabIndex = 3;
            // 
            // perronIDDataGridViewTextBoxColumn
            // 
            this.perronIDDataGridViewTextBoxColumn.DataPropertyName = "Perron_ID";
            this.perronIDDataGridViewTextBoxColumn.HeaderText = "№ перрона";
            this.perronIDDataGridViewTextBoxColumn.Name = "perronIDDataGridViewTextBoxColumn";
            this.perronIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.perronIDDataGridViewTextBoxColumn.Width = 70;
            // 
            // eticDataGridViewTextBoxColumn
            // 
            this.eticDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.eticDataGridViewTextBoxColumn.DataPropertyName = "Etic";
            this.eticDataGridViewTextBoxColumn.HeaderText = "№ места";
            this.eticDataGridViewTextBoxColumn.Name = "eticDataGridViewTextBoxColumn";
            this.eticDataGridViewTextBoxColumn.ReadOnly = true;
            this.eticDataGridViewTextBoxColumn.Width = 82;
            // 
            // pickSlipNumnerDataGridViewTextBoxColumn
            // 
            this.pickSlipNumnerDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.pickSlipNumnerDataGridViewTextBoxColumn.DataPropertyName = "PickSlipNumner";
            this.pickSlipNumnerDataGridViewTextBoxColumn.HeaderText = "№ сборочного";
            this.pickSlipNumnerDataGridViewTextBoxColumn.Name = "pickSlipNumnerDataGridViewTextBoxColumn";
            this.pickSlipNumnerDataGridViewTextBoxColumn.ReadOnly = true;
            this.pickSlipNumnerDataGridViewTextBoxColumn.Width = 116;
            // 
            // orderNumberTypeDataGridViewTextBoxColumn
            // 
            this.orderNumberTypeDataGridViewTextBoxColumn.DataPropertyName = "Order_Number_Type";
            this.orderNumberTypeDataGridViewTextBoxColumn.HeaderText = "Тип заказа";
            this.orderNumberTypeDataGridViewTextBoxColumn.Name = "orderNumberTypeDataGridViewTextBoxColumn";
            this.orderNumberTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.orderNumberTypeDataGridViewTextBoxColumn.Width = 60;
            // 
            // orderNumberDataGridViewTextBoxColumn
            // 
            this.orderNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.orderNumberDataGridViewTextBoxColumn.DataPropertyName = "Order_Number";
            this.orderNumberDataGridViewTextBoxColumn.HeaderText = "№ заказа";
            this.orderNumberDataGridViewTextBoxColumn.Name = "orderNumberDataGridViewTextBoxColumn";
            this.orderNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.orderNumberDataGridViewTextBoxColumn.Width = 89;
            // 
            // itemIDDataGridViewTextBoxColumn
            // 
            this.itemIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemIDDataGridViewTextBoxColumn.DataPropertyName = "Item_ID";
            this.itemIDDataGridViewTextBoxColumn.HeaderText = "Код товара";
            this.itemIDDataGridViewTextBoxColumn.Name = "itemIDDataGridViewTextBoxColumn";
            this.itemIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemIDDataGridViewTextBoxColumn.Width = 98;
            // 
            // itemDataGridViewTextBoxColumn
            // 
            this.itemDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemDataGridViewTextBoxColumn.DataPropertyName = "Item";
            this.itemDataGridViewTextBoxColumn.HeaderText = "Наименование товара";
            this.itemDataGridViewTextBoxColumn.Name = "itemDataGridViewTextBoxColumn";
            this.itemDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemDataGridViewTextBoxColumn.Width = 166;
            // 
            // vendorLotDataGridViewTextBoxColumn
            // 
            this.vendorLotDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.vendorLotDataGridViewTextBoxColumn.DataPropertyName = "Vendor_Lot";
            this.vendorLotDataGridViewTextBoxColumn.HeaderText = "Серия";
            this.vendorLotDataGridViewTextBoxColumn.Name = "vendorLotDataGridViewTextBoxColumn";
            this.vendorLotDataGridViewTextBoxColumn.ReadOnly = true;
            this.vendorLotDataGridViewTextBoxColumn.Width = 73;
            // 
            // expirationDateDataGridViewTextBoxColumn
            // 
            this.expirationDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.expirationDateDataGridViewTextBoxColumn.DataPropertyName = "Expiration_Date";
            this.expirationDateDataGridViewTextBoxColumn.HeaderText = "Срок годности";
            this.expirationDateDataGridViewTextBoxColumn.Name = "expirationDateDataGridViewTextBoxColumn";
            this.expirationDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.expirationDateDataGridViewTextBoxColumn.Width = 117;
            // 
            // unitOfMeasureDataGridViewTextBoxColumn
            // 
            this.unitOfMeasureDataGridViewTextBoxColumn.DataPropertyName = "UnitOfMeasure";
            this.unitOfMeasureDataGridViewTextBoxColumn.HeaderText = "Ед. измер.";
            this.unitOfMeasureDataGridViewTextBoxColumn.Name = "unitOfMeasureDataGridViewTextBoxColumn";
            this.unitOfMeasureDataGridViewTextBoxColumn.ReadOnly = true;
            this.unitOfMeasureDataGridViewTextBoxColumn.Width = 60;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.NullValue = null;
            this.quantityDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Количество";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.ReadOnly = true;
            this.quantityDataGridViewTextBoxColumn.Width = 111;
            // 
            // movementDeviatedItemsDetailsBindingSource
            // 
            this.movementDeviatedItemsDetailsBindingSource.DataMember = "MovementDeviatedItemsDetails";
            this.movementDeviatedItemsDetailsBindingSource.DataSource = this.coldChain;
            // 
            // movementDeviatedItemsHeadersTableAdapter
            // 
            this.movementDeviatedItemsHeadersTableAdapter.ClearBeforeFill = true;
            // 
            // movementDeviatedItemsDetailsTableAdapter
            // 
            this.movementDeviatedItemsDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // movementIDDataGridViewTextBoxColumn
            // 
            this.movementIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.movementIDDataGridViewTextBoxColumn.DataPropertyName = "Movement_ID";
            this.movementIDDataGridViewTextBoxColumn.HeaderText = "№ акта перемещения";
            this.movementIDDataGridViewTextBoxColumn.Name = "movementIDDataGridViewTextBoxColumn";
            this.movementIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.movementIDDataGridViewTextBoxColumn.Width = 157;
            // 
            // branchIDDataGridViewTextBoxColumn
            // 
            this.branchIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.branchIDDataGridViewTextBoxColumn.DataPropertyName = "Branch_ID";
            this.branchIDDataGridViewTextBoxColumn.HeaderText = "Филиал";
            this.branchIDDataGridViewTextBoxColumn.Name = "branchIDDataGridViewTextBoxColumn";
            this.branchIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.branchIDDataGridViewTextBoxColumn.Width = 84;
            // 
            // statusNameDataGridViewTextBoxColumn
            // 
            this.statusNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.statusNameDataGridViewTextBoxColumn.DataPropertyName = "Status_Name";
            this.statusNameDataGridViewTextBoxColumn.HeaderText = "Статус";
            this.statusNameDataGridViewTextBoxColumn.Name = "statusNameDataGridViewTextBoxColumn";
            this.statusNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusNameDataGridViewTextBoxColumn.Width = 79;
            // 
            // ColdChainMovementWithDeviatedTemperature
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1156, 507);
            this.Controls.Add(this.scMainDoc);
            this.Controls.Add(this.tsMainMenu);
            this.Name = "ColdChainMovementWithDeviatedTemperature";
            this.Text = "ColdChainMovementWithDeviatedTemperature";
            this.Load += new System.EventHandler(this.ColdChainMovementWithDeviatedTemperature_Load);
            this.Controls.SetChildIndex(this.tsMainMenu, 0);
            this.Controls.SetChildIndex(this.scMainDoc, 0);
            this.tsMainMenu.ResumeLayout(false);
            this.tsMainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMainGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.movementDeviatedItemsHeadersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coldChain)).EndInit();
            this.scMainDoc.Panel1.ResumeLayout(false);
            this.scMainDoc.Panel2.ResumeLayout(false);
            this.scMainDoc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.movementDeviatedItemsDetailsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMainMenu;
        private System.Windows.Forms.ToolStripButton sbRefreshData;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton sbPrintOrder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton sbCompleteOrder;
        private System.Windows.Forms.ToolStripComboBox cmbPrinters;
        private System.Windows.Forms.ToolStripLabel lblPrinters;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.DataGridView dgvMainGrid;
        private System.Windows.Forms.SplitContainer scMainDoc;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.BindingSource movementDeviatedItemsHeadersBindingSource;
        private WMSOffice.Data.ColdChain coldChain;
        private WMSOffice.Data.ColdChainTableAdapters.MovementDeviatedItemsHeadersTableAdapter movementDeviatedItemsHeadersTableAdapter;
        private System.Windows.Forms.BindingSource movementDeviatedItemsDetailsBindingSource;
        private WMSOffice.Data.ColdChainTableAdapters.MovementDeviatedItemsDetailsTableAdapter movementDeviatedItemsDetailsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn perronIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eticDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pickSlipNumnerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderNumberTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorLotDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expirationDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitOfMeasureDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn movementIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn branchIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusNameDataGridViewTextBoxColumn;
    }
}