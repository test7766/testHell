namespace WMSOffice.Dialogs.PickControl
{
    partial class OrderMiniControlForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvDocRows = new System.Windows.Forms.DataGridView();
            this.orderIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lineIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorLotDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itmUOMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docQtyPlanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docQtyControlDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docQtyNTVDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pCIOOrderDocRowsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pickControl = new WMSOffice.Data.PickControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.tbBarcode = new WMSOffice.Controls.TextBoxScaner();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.btnUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAddItem = new System.Windows.Forms.ToolStripButton();
            this.btnCloseDoc = new System.Windows.Forms.ToolStripButton();
            this.btnUndoDoc = new System.Windows.Forms.ToolStripButton();
            this.pC_IO_Order_DocRowsTableAdapter = new WMSOffice.Data.PickControlTableAdapters.PC_IO_Order_DocRowsTableAdapter();
            this.miAddItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlButtons.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pCIOOrderDocRowsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).BeginInit();
            this.panel2.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(4011, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(4101, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 428);
            this.pnlButtons.Size = new System.Drawing.Size(794, 43);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.tsMain);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 422);
            this.panel1.TabIndex = 101;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvDocRows);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 101);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(794, 321);
            this.panel3.TabIndex = 2;
            // 
            // dgvDocRows
            // 
            this.dgvDocRows.AllowUserToAddRows = false;
            this.dgvDocRows.AllowUserToDeleteRows = false;
            this.dgvDocRows.AllowUserToResizeRows = false;
            this.dgvDocRows.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDocRows.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDocRows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocRows.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderIdDataGridViewTextBoxColumn,
            this.lineIdDataGridViewTextBoxColumn,
            this.itemIDDataGridViewTextBoxColumn,
            this.itemnameDataGridViewTextBoxColumn,
            this.vendorLotDataGridViewTextBoxColumn,
            this.itmUOMDataGridViewTextBoxColumn,
            this.docQtyPlanDataGridViewTextBoxColumn,
            this.docQtyControlDataGridViewTextBoxColumn,
            this.docQtyNTVDataGridViewTextBoxColumn});
            this.dgvDocRows.DataSource = this.pCIOOrderDocRowsBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDocRows.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDocRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocRows.Location = new System.Drawing.Point(0, 0);
            this.dgvDocRows.MultiSelect = false;
            this.dgvDocRows.Name = "dgvDocRows";
            this.dgvDocRows.ReadOnly = true;
            this.dgvDocRows.RowHeadersVisible = false;
            this.dgvDocRows.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocRows.Size = new System.Drawing.Size(794, 321);
            this.dgvDocRows.TabIndex = 0;
            this.dgvDocRows.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDocRows_CellFormatting);
            this.dgvDocRows.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvDocRows_DataBindingComplete);
            // 
            // orderIdDataGridViewTextBoxColumn
            // 
            this.orderIdDataGridViewTextBoxColumn.DataPropertyName = "Order_Id";
            this.orderIdDataGridViewTextBoxColumn.HeaderText = "Order_Id";
            this.orderIdDataGridViewTextBoxColumn.Name = "orderIdDataGridViewTextBoxColumn";
            this.orderIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.orderIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // lineIdDataGridViewTextBoxColumn
            // 
            this.lineIdDataGridViewTextBoxColumn.DataPropertyName = "line_Id";
            this.lineIdDataGridViewTextBoxColumn.HeaderText = "line_Id";
            this.lineIdDataGridViewTextBoxColumn.Name = "lineIdDataGridViewTextBoxColumn";
            this.lineIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.lineIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // itemIDDataGridViewTextBoxColumn
            // 
            this.itemIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemIDDataGridViewTextBoxColumn.DataPropertyName = "Item_ID";
            this.itemIDDataGridViewTextBoxColumn.HeaderText = "Код";
            this.itemIDDataGridViewTextBoxColumn.Name = "itemIDDataGridViewTextBoxColumn";
            this.itemIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemIDDataGridViewTextBoxColumn.Width = 57;
            // 
            // itemnameDataGridViewTextBoxColumn
            // 
            this.itemnameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemnameDataGridViewTextBoxColumn.DataPropertyName = "Item_name";
            this.itemnameDataGridViewTextBoxColumn.HeaderText = "Наименование";
            this.itemnameDataGridViewTextBoxColumn.Name = "itemnameDataGridViewTextBoxColumn";
            this.itemnameDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemnameDataGridViewTextBoxColumn.Width = 132;
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
            // itmUOMDataGridViewTextBoxColumn
            // 
            this.itmUOMDataGridViewTextBoxColumn.DataPropertyName = "Itm_UOM";
            this.itmUOMDataGridViewTextBoxColumn.HeaderText = "ЕИ";
            this.itmUOMDataGridViewTextBoxColumn.Name = "itmUOMDataGridViewTextBoxColumn";
            this.itmUOMDataGridViewTextBoxColumn.ReadOnly = true;
            this.itmUOMDataGridViewTextBoxColumn.Width = 40;
            // 
            // docQtyPlanDataGridViewTextBoxColumn
            // 
            this.docQtyPlanDataGridViewTextBoxColumn.DataPropertyName = "Doc_Qty_Plan";
            this.docQtyPlanDataGridViewTextBoxColumn.HeaderText = "План, шт.";
            this.docQtyPlanDataGridViewTextBoxColumn.Name = "docQtyPlanDataGridViewTextBoxColumn";
            this.docQtyPlanDataGridViewTextBoxColumn.ReadOnly = true;
            this.docQtyPlanDataGridViewTextBoxColumn.ToolTipText = "План, шт.";
            // 
            // docQtyControlDataGridViewTextBoxColumn
            // 
            this.docQtyControlDataGridViewTextBoxColumn.DataPropertyName = "Doc_Qty_Control";
            this.docQtyControlDataGridViewTextBoxColumn.HeaderText = "Факт, шт.";
            this.docQtyControlDataGridViewTextBoxColumn.Name = "docQtyControlDataGridViewTextBoxColumn";
            this.docQtyControlDataGridViewTextBoxColumn.ReadOnly = true;
            this.docQtyControlDataGridViewTextBoxColumn.ToolTipText = "Факт, шт.";
            // 
            // docQtyNTVDataGridViewTextBoxColumn
            // 
            this.docQtyNTVDataGridViewTextBoxColumn.DataPropertyName = "Doc_Qty_NTV";
            this.docQtyNTVDataGridViewTextBoxColumn.HeaderText = "НТВ, шт.";
            this.docQtyNTVDataGridViewTextBoxColumn.Name = "docQtyNTVDataGridViewTextBoxColumn";
            this.docQtyNTVDataGridViewTextBoxColumn.ReadOnly = true;
            this.docQtyNTVDataGridViewTextBoxColumn.ToolTipText = "НТВ, шт.";
            // 
            // pCIOOrderDocRowsBindingSource
            // 
            this.pCIOOrderDocRowsBindingSource.DataMember = "PC_IO_Order_DocRows";
            this.pCIOOrderDocRowsBindingSource.DataSource = this.pickControl;
            // 
            // pickControl
            // 
            this.pickControl.DataSetName = "PickControl";
            this.pickControl.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.tbBarcode);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 55);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(794, 46);
            this.panel2.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Штрих-код:";
            // 
            // tbBarcode
            // 
            this.tbBarcode.AllowType = true;
            this.tbBarcode.AutoConvert = true;
            this.tbBarcode.DelayThreshold = 50;
            this.tbBarcode.Location = new System.Drawing.Point(73, 11);
            this.tbBarcode.Name = "tbBarcode";
            this.tbBarcode.RaiseTextChangeWithoutEnter = false;
            this.tbBarcode.ReadOnly = false;
            this.tbBarcode.ScannerListener = null;
            this.tbBarcode.Size = new System.Drawing.Size(200, 25);
            this.tbBarcode.TabIndex = 25;
            this.tbBarcode.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.tbBarcode.UseParentFont = false;
            this.tbBarcode.UseScanModeOnly = false;
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnUndo,
            this.toolStripSeparator1,
            this.btnAddItem,
            this.btnCloseDoc,
            this.btnUndoDoc});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(794, 55);
            this.tsMain.TabIndex = 0;
            this.tsMain.Text = "toolStrip1";
            // 
            // btnUndo
            // 
            this.btnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUndo.Enabled = false;
            this.btnUndo.Image = global::WMSOffice.Properties.Resources.undo43;
            this.btnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(52, 52);
            this.btnUndo.Text = "toolStripButton4";
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Image = global::WMSOffice.Properties.Resources.F2;
            this.btnAddItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(111, 52);
            this.btnAddItem.Text = "Добавить\nтовар\nбез ш/к";
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnCloseDoc
            // 
            this.btnCloseDoc.Image = global::WMSOffice.Properties.Resources.F4;
            this.btnCloseDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCloseDoc.Name = "btnCloseDoc";
            this.btnCloseDoc.Size = new System.Drawing.Size(120, 52);
            this.btnCloseDoc.Text = "Завершить\nконтроль\nзаказа";
            this.btnCloseDoc.Click += new System.EventHandler(this.btnCloseDoc_Click);
            // 
            // btnUndoDoc
            // 
            this.btnUndoDoc.Image = global::WMSOffice.Properties.Resources.F8;
            this.btnUndoDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUndoDoc.Name = "btnUndoDoc";
            this.btnUndoDoc.Size = new System.Drawing.Size(113, 52);
            this.btnUndoDoc.Text = "Отменить\nконтроль\nзаказа";
            this.btnUndoDoc.Click += new System.EventHandler(this.btnUndoDoc_Click);
            // 
            // pC_IO_Order_DocRowsTableAdapter
            // 
            this.pC_IO_Order_DocRowsTableAdapter.ClearBeforeFill = true;
            // 
            // miAddItem
            // 
            this.miAddItem.Name = "miAddItem";
            this.miAddItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.miAddItem.Size = new System.Drawing.Size(287, 22);
            this.miAddItem.Text = "Добавить товар без штрих кода";
            // 
            // OrderMiniControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 471);
            this.Controls.Add(this.panel1);
            this.Name = "OrderMiniControlForm";
            this.Text = "Мини-контроль заказа";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OrderMiniControlForm_FormClosing);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pCIOOrderDocRowsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btnAddItem;
        private System.Windows.Forms.ToolStripButton btnCloseDoc;
        private System.Windows.Forms.ToolStripButton btnUndoDoc;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label10;
        private WMSOffice.Controls.TextBoxScaner tbBarcode;
        private System.Windows.Forms.ToolStripButton btnUndo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvDocRows;
        private System.Windows.Forms.BindingSource pCIOOrderDocRowsBindingSource;
        private WMSOffice.Data.PickControl pickControl;
        private WMSOffice.Data.PickControlTableAdapters.PC_IO_Order_DocRowsTableAdapter pC_IO_Order_DocRowsTableAdapter;
        private System.Windows.Forms.ToolStripMenuItem miAddItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lineIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorLotDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itmUOMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docQtyPlanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docQtyControlDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docQtyNTVDataGridViewTextBoxColumn;
    }
}