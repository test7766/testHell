namespace WMSOffice.Window
{
    partial class MoveToSaleWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoveToSaleWindow));
            this.toolStripDoc = new System.Windows.Forms.ToolStrip();
            this.btnNewDocument = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.gvDocuments = new System.Windows.Forms.DataGridView();
            this.docIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docTypeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wH = new WMSOffice.Data.WH();
            this.docsTableAdapter = new WMSOffice.Data.WHTableAdapters.DocsTableAdapter();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gvLines = new System.Windows.Forms.DataGridView();
            this.moveReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.moveToSale = new WMSOffice.Data.MoveToSale();
            this.moveReportTableAdapter = new WMSOffice.Data.MoveToSaleTableAdapters.MoveReportTableAdapter();
            this.itemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorLotDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lot_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iTinBXDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itmLocnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyITDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyBXDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pallet_Bar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripDoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDocuments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveToSale)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripDoc
            // 
            this.toolStripDoc.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStripDoc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNewDocument,
            this.toolStripSeparator2,
            this.btnRefresh,
            this.toolStripSeparator1,
            this.btnPrint});
            this.toolStripDoc.Location = new System.Drawing.Point(0, 40);
            this.toolStripDoc.Name = "toolStripDoc";
            this.toolStripDoc.Size = new System.Drawing.Size(740, 55);
            this.toolStripDoc.TabIndex = 2;
            this.toolStripDoc.Text = "Панель инструментов документа";
            // 
            // btnNewDocument
            // 
            this.btnNewDocument.Image = global::WMSOffice.Properties.Resources.document_new;
            this.btnNewDocument.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewDocument.Name = "btnNewDocument";
            this.btnNewDocument.Size = new System.Drawing.Size(206, 52);
            this.btnNewDocument.Text = "Создать новые сборочные\n\r на перемещение товара";
            this.btnNewDocument.ToolTipText = "Создать новые сборочные на перемещение товара";
            this.btnNewDocument.Click += new System.EventHandler(this.btnNewDocument_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(52, 52);
            this.btnRefresh.Text = "Обновить список\n\r сборочных";
            this.btnRefresh.ToolTipText = "Обновить список документов";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::WMSOffice.Properties.Resources.document_print;
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(189, 52);
            this.btnPrint.Text = "Напечатать сборочный\n\r на перемещение\n\r товара в отделы";
            this.btnPrint.ToolTipText = "Напечатать сборочный на перемещение товара в отделы";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // gvDocuments
            // 
            this.gvDocuments.AllowUserToAddRows = false;
            this.gvDocuments.AllowUserToDeleteRows = false;
            this.gvDocuments.AllowUserToResizeRows = false;
            this.gvDocuments.AutoGenerateColumns = false;
            this.gvDocuments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDocuments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.docIDDataGridViewTextBoxColumn,
            this.docTypeNameDataGridViewTextBoxColumn,
            this.docDateDataGridViewTextBoxColumn,
            this.statusIDDataGridViewTextBoxColumn,
            this.statusNameDataGridViewTextBoxColumn});
            this.gvDocuments.DataSource = this.docsBindingSource;
            this.gvDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvDocuments.Location = new System.Drawing.Point(0, 0);
            this.gvDocuments.MultiSelect = false;
            this.gvDocuments.Name = "gvDocuments";
            this.gvDocuments.ReadOnly = true;
            this.gvDocuments.RowHeadersVisible = false;
            this.gvDocuments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvDocuments.Size = new System.Drawing.Size(740, 184);
            this.gvDocuments.TabIndex = 3;
            this.gvDocuments.SelectionChanged += new System.EventHandler(this.gvDocuments_SelectionChanged);
            // 
            // docIDDataGridViewTextBoxColumn
            // 
            this.docIDDataGridViewTextBoxColumn.DataPropertyName = "Doc_ID";
            this.docIDDataGridViewTextBoxColumn.HeaderText = "Сборочный";
            this.docIDDataGridViewTextBoxColumn.Name = "docIDDataGridViewTextBoxColumn";
            this.docIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // docTypeNameDataGridViewTextBoxColumn
            // 
            this.docTypeNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.docTypeNameDataGridViewTextBoxColumn.DataPropertyName = "Doc_Type_Name";
            this.docTypeNameDataGridViewTextBoxColumn.HeaderText = "Наименование";
            this.docTypeNameDataGridViewTextBoxColumn.Name = "docTypeNameDataGridViewTextBoxColumn";
            this.docTypeNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.docTypeNameDataGridViewTextBoxColumn.Width = 108;
            // 
            // docDateDataGridViewTextBoxColumn
            // 
            this.docDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.docDateDataGridViewTextBoxColumn.DataPropertyName = "Doc_Date";
            this.docDateDataGridViewTextBoxColumn.HeaderText = "Дата";
            this.docDateDataGridViewTextBoxColumn.Name = "docDateDataGridViewTextBoxColumn";
            this.docDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.docDateDataGridViewTextBoxColumn.Width = 58;
            // 
            // statusIDDataGridViewTextBoxColumn
            // 
            this.statusIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.statusIDDataGridViewTextBoxColumn.DataPropertyName = "Status_ID";
            this.statusIDDataGridViewTextBoxColumn.HeaderText = "Ст.";
            this.statusIDDataGridViewTextBoxColumn.Name = "statusIDDataGridViewTextBoxColumn";
            this.statusIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusIDDataGridViewTextBoxColumn.Width = 47;
            // 
            // statusNameDataGridViewTextBoxColumn
            // 
            this.statusNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.statusNameDataGridViewTextBoxColumn.DataPropertyName = "Status_Name";
            this.statusNameDataGridViewTextBoxColumn.HeaderText = "Статус";
            this.statusNameDataGridViewTextBoxColumn.Name = "statusNameDataGridViewTextBoxColumn";
            this.statusNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusNameDataGridViewTextBoxColumn.Width = 66;
            // 
            // docsBindingSource
            // 
            this.docsBindingSource.DataMember = "Docs";
            this.docsBindingSource.DataSource = this.wH;
            // 
            // wH
            // 
            this.wH.DataSetName = "WH";
            this.wH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // docsTableAdapter
            // 
            this.docsTableAdapter.ClearBeforeFill = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 95);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gvDocuments);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gvLines);
            this.splitContainer1.Size = new System.Drawing.Size(740, 293);
            this.splitContainer1.SplitterDistance = 184;
            this.splitContainer1.TabIndex = 4;
            // 
            // gvLines
            // 
            this.gvLines.AllowUserToAddRows = false;
            this.gvLines.AllowUserToDeleteRows = false;
            this.gvLines.AllowUserToResizeRows = false;
            this.gvLines.AutoGenerateColumns = false;
            this.gvLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvLines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemIDDataGridViewTextBoxColumn,
            this.itemNameDataGridViewTextBoxColumn,
            this.manufacturerDataGridViewTextBoxColumn,
            this.vendorLotDataGridViewTextBoxColumn,
            this.expDateDataGridViewTextBoxColumn,
            this.Lot_Number,
            this.iTinBXDataGridViewTextBoxColumn,
            this.itmLocnDataGridViewTextBoxColumn,
            this.qtyITDataGridViewTextBoxColumn,
            this.qtyBXDataGridViewTextBoxColumn,
            this.Pallet_Bar});
            this.gvLines.DataSource = this.moveReportBindingSource;
            this.gvLines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvLines.Location = new System.Drawing.Point(0, 0);
            this.gvLines.MultiSelect = false;
            this.gvLines.Name = "gvLines";
            this.gvLines.ReadOnly = true;
            this.gvLines.RowHeadersVisible = false;
            this.gvLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvLines.Size = new System.Drawing.Size(740, 105);
            this.gvLines.TabIndex = 0;
            // 
            // moveReportBindingSource
            // 
            this.moveReportBindingSource.DataMember = "MoveReport";
            this.moveReportBindingSource.DataSource = this.moveToSale;
            // 
            // moveToSale
            // 
            this.moveToSale.DataSetName = "MoveToSale";
            this.moveToSale.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // moveReportTableAdapter
            // 
            this.moveReportTableAdapter.ClearBeforeFill = true;
            // 
            // itemIDDataGridViewTextBoxColumn
            // 
            this.itemIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemIDDataGridViewTextBoxColumn.DataPropertyName = "Item_ID";
            this.itemIDDataGridViewTextBoxColumn.HeaderText = "Код";
            this.itemIDDataGridViewTextBoxColumn.Name = "itemIDDataGridViewTextBoxColumn";
            this.itemIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemIDDataGridViewTextBoxColumn.Width = 51;
            // 
            // itemNameDataGridViewTextBoxColumn
            // 
            this.itemNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemNameDataGridViewTextBoxColumn.DataPropertyName = "Item_Name";
            this.itemNameDataGridViewTextBoxColumn.HeaderText = "Наименование";
            this.itemNameDataGridViewTextBoxColumn.Name = "itemNameDataGridViewTextBoxColumn";
            this.itemNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemNameDataGridViewTextBoxColumn.Width = 108;
            // 
            // manufacturerDataGridViewTextBoxColumn
            // 
            this.manufacturerDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.manufacturerDataGridViewTextBoxColumn.DataPropertyName = "Manufacturer";
            this.manufacturerDataGridViewTextBoxColumn.HeaderText = "Производитель";
            this.manufacturerDataGridViewTextBoxColumn.Name = "manufacturerDataGridViewTextBoxColumn";
            this.manufacturerDataGridViewTextBoxColumn.ReadOnly = true;
            this.manufacturerDataGridViewTextBoxColumn.Width = 111;
            // 
            // vendorLotDataGridViewTextBoxColumn
            // 
            this.vendorLotDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.vendorLotDataGridViewTextBoxColumn.DataPropertyName = "Vendor_Lot";
            this.vendorLotDataGridViewTextBoxColumn.HeaderText = "Серия";
            this.vendorLotDataGridViewTextBoxColumn.Name = "vendorLotDataGridViewTextBoxColumn";
            this.vendorLotDataGridViewTextBoxColumn.ReadOnly = true;
            this.vendorLotDataGridViewTextBoxColumn.Width = 63;
            // 
            // expDateDataGridViewTextBoxColumn
            // 
            this.expDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.expDateDataGridViewTextBoxColumn.DataPropertyName = "ExpDate";
            this.expDateDataGridViewTextBoxColumn.HeaderText = "Ср.годн.";
            this.expDateDataGridViewTextBoxColumn.Name = "expDateDataGridViewTextBoxColumn";
            this.expDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.expDateDataGridViewTextBoxColumn.Width = 74;
            // 
            // Lot_Number
            // 
            this.Lot_Number.DataPropertyName = "Lot_Number";
            this.Lot_Number.HeaderText = "Партия";
            this.Lot_Number.Name = "Lot_Number";
            this.Lot_Number.ReadOnly = true;
            this.Lot_Number.Width = 90;
            // 
            // iTinBXDataGridViewTextBoxColumn
            // 
            this.iTinBXDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.iTinBXDataGridViewTextBoxColumn.DataPropertyName = "ITinBX";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "# ##0";
            this.iTinBXDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.iTinBXDataGridViewTextBoxColumn.HeaderText = "шт.";
            this.iTinBXDataGridViewTextBoxColumn.Name = "iTinBXDataGridViewTextBoxColumn";
            this.iTinBXDataGridViewTextBoxColumn.ReadOnly = true;
            this.iTinBXDataGridViewTextBoxColumn.Width = 48;
            // 
            // itmLocnDataGridViewTextBoxColumn
            // 
            this.itmLocnDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itmLocnDataGridViewTextBoxColumn.DataPropertyName = "Itm_Locn";
            this.itmLocnDataGridViewTextBoxColumn.HeaderText = "Полка";
            this.itmLocnDataGridViewTextBoxColumn.Name = "itmLocnDataGridViewTextBoxColumn";
            this.itmLocnDataGridViewTextBoxColumn.ReadOnly = true;
            this.itmLocnDataGridViewTextBoxColumn.Width = 64;
            // 
            // qtyITDataGridViewTextBoxColumn
            // 
            this.qtyITDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.qtyITDataGridViewTextBoxColumn.DataPropertyName = "QtyIT";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "# ##0";
            this.qtyITDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.qtyITDataGridViewTextBoxColumn.HeaderText = "Кол-во";
            this.qtyITDataGridViewTextBoxColumn.Name = "qtyITDataGridViewTextBoxColumn";
            this.qtyITDataGridViewTextBoxColumn.ReadOnly = true;
            this.qtyITDataGridViewTextBoxColumn.Width = 66;
            // 
            // qtyBXDataGridViewTextBoxColumn
            // 
            this.qtyBXDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.qtyBXDataGridViewTextBoxColumn.DataPropertyName = "QtyBX";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "# ##0";
            this.qtyBXDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.qtyBXDataGridViewTextBoxColumn.HeaderText = "Ящиков";
            this.qtyBXDataGridViewTextBoxColumn.Name = "qtyBXDataGridViewTextBoxColumn";
            this.qtyBXDataGridViewTextBoxColumn.ReadOnly = true;
            this.qtyBXDataGridViewTextBoxColumn.Width = 73;
            // 
            // Pallet_Bar
            // 
            this.Pallet_Bar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Pallet_Bar.DataPropertyName = "Pallet_Bar";
            this.Pallet_Bar.HeaderText = "Паллета";
            this.Pallet_Bar.Name = "Pallet_Bar";
            this.Pallet_Bar.ReadOnly = true;
            this.Pallet_Bar.Width = 75;
            // 
            // MoveToSaleWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 388);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStripDoc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MoveToSaleWindow";
            this.Text = "* Перемещение товара из приемного в отделы";
            this.Load += new System.EventHandler(this.MoveToSaleWindow_Load);
            this.Controls.SetChildIndex(this.toolStripDoc, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.toolStripDoc.ResumeLayout(false);
            this.toolStripDoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDocuments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveToSale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripDoc;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.DataGridView gvDocuments;
        private System.Windows.Forms.BindingSource docsBindingSource;
        private WMSOffice.Data.WH wH;
        private WMSOffice.Data.WHTableAdapters.DocsTableAdapter docsTableAdapter;
        private System.Windows.Forms.ToolStripButton btnNewDocument;
        private System.Windows.Forms.DataGridViewTextBoxColumn docIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docTypeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView gvLines;
        private System.Windows.Forms.BindingSource moveReportBindingSource;
        private WMSOffice.Data.MoveToSale moveToSale;
        private WMSOffice.Data.MoveToSaleTableAdapters.MoveReportTableAdapter moveReportTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorLotDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lot_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn iTinBXDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itmLocnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyITDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyBXDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pallet_Bar;
    }
}