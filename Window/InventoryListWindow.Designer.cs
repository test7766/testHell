namespace WMSOffice.Window
{
    partial class InventoryListWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventoryListWindow));
            this.toolStripDoc = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.dgvInventories = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnCreateInventory = new System.Windows.Forms.ToolStripButton();
            this.btnShowCountSheets = new System.Windows.Forms.ToolStripButton();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.docIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warehouseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.relatedDocIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iNDocsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.inventory = new WMSOffice.Data.Inventory();
            this.iN_DocsTableAdapter = new WMSOffice.Data.InventoryTableAdapters.IN_DocsTableAdapter();
            this.toolStripDoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventories)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNDocsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventory)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripDoc
            // 
            this.toolStripDoc.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStripDoc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.toolStripSeparator1,
            this.btnCreateInventory,
            this.btnShowCountSheets,
            this.btnPrint});
            this.toolStripDoc.Location = new System.Drawing.Point(0, 40);
            this.toolStripDoc.Name = "toolStripDoc";
            this.toolStripDoc.Size = new System.Drawing.Size(860, 55);
            this.toolStripDoc.TabIndex = 4;
            this.toolStripDoc.Text = "Панель инструментов документа";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // dgvInventories
            // 
            this.dgvInventories.AllowUserToAddRows = false;
            this.dgvInventories.AllowUserToDeleteRows = false;
            this.dgvInventories.AllowUserToOrderColumns = true;
            this.dgvInventories.AllowUserToResizeRows = false;
            this.dgvInventories.AutoGenerateColumns = false;
            this.dgvInventories.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInventories.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInventories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventories.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.docIDDataGridViewTextBoxColumn,
            this.warehouseDataGridViewTextBoxColumn,
            this.docDateDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.relatedDocIDDataGridViewTextBoxColumn});
            this.dgvInventories.DataSource = this.iNDocsBindingSource;
            this.dgvInventories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInventories.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvInventories.Location = new System.Drawing.Point(0, 95);
            this.dgvInventories.MultiSelect = false;
            this.dgvInventories.Name = "dgvInventories";
            this.dgvInventories.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInventories.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvInventories.RowHeadersVisible = false;
            this.dgvInventories.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dgvInventories.RowTemplate.Height = 24;
            this.dgvInventories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventories.ShowRowErrors = false;
            this.dgvInventories.Size = new System.Drawing.Size(860, 342);
            this.dgvInventories.TabIndex = 5;
            this.dgvInventories.DoubleClick += new System.EventHandler(this.dgvInventories_DoubleClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(52, 52);
            this.btnRefresh.Text = "Обновить список нераспечатанных накладных";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnCreateInventory
            // 
            this.btnCreateInventory.Enabled = false;
            this.btnCreateInventory.Image = global::WMSOffice.Properties.Resources.document_plain_new;
            this.btnCreateInventory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreateInventory.Name = "btnCreateInventory";
            this.btnCreateInventory.Size = new System.Drawing.Size(102, 52);
            this.btnCreateInventory.Text = "Создать";
            // 
            // btnShowCountSheets
            // 
            this.btnShowCountSheets.Image = global::WMSOffice.Properties.Resources.tables_edit;
            this.btnShowCountSheets.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowCountSheets.Name = "btnShowCountSheets";
            this.btnShowCountSheets.Size = new System.Drawing.Size(106, 52);
            this.btnShowCountSheets.Text = "Открыть\r\nсчетные\r\nлисты";
            this.btnShowCountSheets.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShowCountSheets.Click += new System.EventHandler(this.btnShowCountSheets_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Enabled = false;
            this.btnPrint.Image = global::WMSOffice.Properties.Resources.document_print_preview;
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(118, 52);
            this.btnPrint.Text = "Печать\r\nинвентар.\r\nведомости";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.ToolTipText = "Предварительный \rпросмотр";
            // 
            // docIDDataGridViewTextBoxColumn
            // 
            this.docIDDataGridViewTextBoxColumn.DataPropertyName = "Doc_ID";
            this.docIDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.docIDDataGridViewTextBoxColumn.Name = "docIDDataGridViewTextBoxColumn";
            this.docIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.docIDDataGridViewTextBoxColumn.Width = 60;
            // 
            // warehouseDataGridViewTextBoxColumn
            // 
            this.warehouseDataGridViewTextBoxColumn.DataPropertyName = "Warehouse";
            this.warehouseDataGridViewTextBoxColumn.HeaderText = "Склад";
            this.warehouseDataGridViewTextBoxColumn.Name = "warehouseDataGridViewTextBoxColumn";
            this.warehouseDataGridViewTextBoxColumn.ReadOnly = true;
            this.warehouseDataGridViewTextBoxColumn.Width = 200;
            // 
            // docDateDataGridViewTextBoxColumn
            // 
            this.docDateDataGridViewTextBoxColumn.DataPropertyName = "Doc_Date";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.docDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.docDateDataGridViewTextBoxColumn.HeaderText = "Дата начала";
            this.docDateDataGridViewTextBoxColumn.Name = "docDateDataGridViewTextBoxColumn";
            this.docDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.docDateDataGridViewTextBoxColumn.Width = 160;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Текущий статус";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusDataGridViewTextBoxColumn.Width = 260;
            // 
            // relatedDocIDDataGridViewTextBoxColumn
            // 
            this.relatedDocIDDataGridViewTextBoxColumn.DataPropertyName = "Related_Doc_ID";
            this.relatedDocIDDataGridViewTextBoxColumn.HeaderText = "Внешний ID";
            this.relatedDocIDDataGridViewTextBoxColumn.Name = "relatedDocIDDataGridViewTextBoxColumn";
            this.relatedDocIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.relatedDocIDDataGridViewTextBoxColumn.Width = 110;
            // 
            // iNDocsBindingSource
            // 
            this.iNDocsBindingSource.DataMember = "IN_Docs";
            this.iNDocsBindingSource.DataSource = this.inventory;
            // 
            // inventory
            // 
            this.inventory.DataSetName = "Inventory";
            this.inventory.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // iN_DocsTableAdapter
            // 
            this.iN_DocsTableAdapter.ClearBeforeFill = true;
            // 
            // InventoryListWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 437);
            this.Controls.Add(this.dgvInventories);
            this.Controls.Add(this.toolStripDoc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InventoryListWindow";
            this.Text = "Список инвентаризаций";
            this.Controls.SetChildIndex(this.toolStripDoc, 0);
            this.Controls.SetChildIndex(this.dgvInventories, 0);
            this.toolStripDoc.ResumeLayout(false);
            this.toolStripDoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventories)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNDocsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripDoc;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnShowCountSheets;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.ToolStripButton btnCreateInventory;
        private System.Windows.Forms.DataGridView dgvInventories;
        private WMSOffice.Data.Inventory inventory;
        private System.Windows.Forms.BindingSource iNDocsBindingSource;
        private WMSOffice.Data.InventoryTableAdapters.IN_DocsTableAdapter iN_DocsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn docIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn warehouseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn relatedDocIDDataGridViewTextBoxColumn;
    }
}