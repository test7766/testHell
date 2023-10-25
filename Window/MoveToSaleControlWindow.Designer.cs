namespace WMSOffice.Window
{
    partial class MoveToSaleControlWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlBarcode = new System.Windows.Forms.Panel();
            this.tbDocumentScaner = new WMSOffice.Controls.TextBoxScaner();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDocNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlDocLines = new System.Windows.Forms.Panel();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.colItem_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colManufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVendor_Lot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLot_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocationFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocationTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SectorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitOfMeasure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNeedQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFactQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFactQtyVisible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcCheckPrintYL = new WMSOffice.Dialogs.Inventory.CustomDataGridViewCheckBoxColumn();
            this.colDiff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLM_Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLM_LocationVisible = new WMSOffice.Controls.MoveToSale.ProblemLocationColumn();
            this.controlDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.moveToSale = new WMSOffice.Data.MoveToSale();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDocType = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbDocWarehouse = new System.Windows.Forms.TextBox();
            this.pnlDocumentheader = new System.Windows.Forms.Panel();
            this.lblScanItemsOnly = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbLevels = new System.Windows.Forms.ComboBox();
            this.levelsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.cmbPrinters = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbBoxScaner = new WMSOffice.Controls.TextBoxScaner();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbRelDocType = new System.Windows.Forms.TextBox();
            this.tbRelDocNo = new System.Windows.Forms.TextBox();
            this.tbDocDate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCloseDoc = new System.Windows.Forms.Button();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.containers = new WMSOffice.Data.Containers();
            this.containersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.controlHeaderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.controlHeaderTableAdapter = new WMSOffice.Data.MoveToSaleTableAdapters.ControlHeaderTableAdapter();
            this.controlDetailsTableAdapter = new WMSOffice.Data.MoveToSaleTableAdapters.ControlDetailsTableAdapter();
            this.levelsTableAdapter = new WMSOffice.Data.MoveToSaleTableAdapters.LevelsTableAdapter();
            this.btnCreateTask = new System.Windows.Forms.Button();
            this.pnlBarcode.SuspendLayout();
            this.pnlDocLines.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controlDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveToSale)).BeginInit();
            this.pnlDocumentheader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.levelsBindingSource)).BeginInit();
            this.pnlFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.containers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.containersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controlHeaderBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBarcode
            // 
            this.pnlBarcode.Controls.Add(this.tbDocumentScaner);
            this.pnlBarcode.Controls.Add(this.label1);
            this.pnlBarcode.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBarcode.Location = new System.Drawing.Point(0, 40);
            this.pnlBarcode.Name = "pnlBarcode";
            this.pnlBarcode.Size = new System.Drawing.Size(1516, 35);
            this.pnlBarcode.TabIndex = 1;
            // 
            // tbDocumentScaner
            // 
            this.tbDocumentScaner.AllowType = true;
            this.tbDocumentScaner.AutoConvert = true;
            this.tbDocumentScaner.DelayThreshold = 50D;
            this.tbDocumentScaner.Location = new System.Drawing.Point(137, 3);
            this.tbDocumentScaner.Name = "tbDocumentScaner";
            this.tbDocumentScaner.RaiseTextChangeWithoutEnter = false;
            this.tbDocumentScaner.ReadOnly = false;
            this.tbDocumentScaner.Size = new System.Drawing.Size(174, 25);
            this.tbDocumentScaner.TabIndex = 4;
            this.tbDocumentScaner.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.tbDocumentScaner.UseParentFont = false;
            this.tbDocumentScaner.UseScanModeOnly = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Штрихкод Документа:";
            // 
            // tbDocNo
            // 
            this.tbDocNo.Location = new System.Drawing.Point(104, 7);
            this.tbDocNo.Name = "tbDocNo";
            this.tbDocNo.ReadOnly = true;
            this.tbDocNo.Size = new System.Drawing.Size(132, 20);
            this.tbDocNo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Документ Но.:";
            // 
            // pnlDocLines
            // 
            this.pnlDocLines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDocLines.Controls.Add(this.dgvDetails);
            this.pnlDocLines.Location = new System.Drawing.Point(0, 162);
            this.pnlDocLines.Name = "pnlDocLines";
            this.pnlDocLines.Size = new System.Drawing.Size(1516, 398);
            this.pnlDocLines.TabIndex = 2;
            this.pnlDocLines.Visible = false;
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetails.AutoGenerateColumns = false;
            this.dgvDetails.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colItem_ID,
            this.colItem,
            this.colManufacturer,
            this.colVendor_Lot,
            this.colLot_Number,
            this.colLocationFrom,
            this.colLocationTo,
            this.SectorName,
            this.colUnitOfMeasure,
            this.colNeedQty,
            this.colFactQty,
            this.colFactQtyVisible,
            this.dgvcCheckPrintYL,
            this.colDiff,
            this.colColor,
            this.colLM_Location,
            this.colLM_LocationVisible});
            this.dgvDetails.DataSource = this.controlDetailsBindingSource;
            this.dgvDetails.Location = new System.Drawing.Point(1, 0);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.RowHeadersVisible = false;
            this.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetails.Size = new System.Drawing.Size(1514, 398);
            this.dgvDetails.TabIndex = 0;
            this.dgvDetails.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetails_CellEnter);
            this.dgvDetails.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetails_CellValidated);
            this.dgvDetails.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvDetails_DataError);
            this.dgvDetails.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvDetails_RowPrePaint);
            // 
            // colItem_ID
            // 
            this.colItem_ID.DataPropertyName = "Item_ID";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.colItem_ID.DefaultCellStyle = dataGridViewCellStyle1;
            this.colItem_ID.HeaderText = "Код Товара";
            this.colItem_ID.Name = "colItem_ID";
            this.colItem_ID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colItem_ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colItem_ID.Width = 50;
            // 
            // colItem
            // 
            this.colItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colItem.DataPropertyName = "Item";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.colItem.DefaultCellStyle = dataGridViewCellStyle2;
            this.colItem.HeaderText = "Наименование";
            this.colItem.Name = "colItem";
            this.colItem.ReadOnly = true;
            // 
            // colManufacturer
            // 
            this.colManufacturer.DataPropertyName = "Manufacturer";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.colManufacturer.DefaultCellStyle = dataGridViewCellStyle3;
            this.colManufacturer.HeaderText = "Производитель";
            this.colManufacturer.Name = "colManufacturer";
            this.colManufacturer.ReadOnly = true;
            this.colManufacturer.Width = 200;
            // 
            // colVendor_Lot
            // 
            this.colVendor_Lot.DataPropertyName = "Vendor_Lot";
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.colVendor_Lot.DefaultCellStyle = dataGridViewCellStyle4;
            this.colVendor_Lot.HeaderText = "Серия";
            this.colVendor_Lot.Name = "colVendor_Lot";
            this.colVendor_Lot.ReadOnly = true;
            // 
            // colLot_Number
            // 
            this.colLot_Number.DataPropertyName = "Lot_Number";
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.colLot_Number.DefaultCellStyle = dataGridViewCellStyle5;
            this.colLot_Number.HeaderText = "Партия";
            this.colLot_Number.Name = "colLot_Number";
            this.colLot_Number.ReadOnly = true;
            this.colLot_Number.Width = 150;
            // 
            // colLocationFrom
            // 
            this.colLocationFrom.DataPropertyName = "LocationFrom";
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.colLocationFrom.DefaultCellStyle = dataGridViewCellStyle6;
            this.colLocationFrom.HeaderText = "Исходящее место";
            this.colLocationFrom.Name = "colLocationFrom";
            this.colLocationFrom.ReadOnly = true;
            // 
            // colLocationTo
            // 
            this.colLocationTo.DataPropertyName = "LocationTo";
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            this.colLocationTo.DefaultCellStyle = dataGridViewCellStyle7;
            this.colLocationTo.HeaderText = "Входящее место";
            this.colLocationTo.Name = "colLocationTo";
            this.colLocationTo.ReadOnly = true;
            // 
            // SectorName
            // 
            this.SectorName.DataPropertyName = "SectorName";
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.SectorName.DefaultCellStyle = dataGridViewCellStyle8;
            this.SectorName.HeaderText = "Сектор";
            this.SectorName.Name = "SectorName";
            this.SectorName.ReadOnly = true;
            // 
            // colUnitOfMeasure
            // 
            this.colUnitOfMeasure.DataPropertyName = "UnitOfMeasure";
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            this.colUnitOfMeasure.DefaultCellStyle = dataGridViewCellStyle9;
            this.colUnitOfMeasure.HeaderText = "Ед. изм.";
            this.colUnitOfMeasure.Name = "colUnitOfMeasure";
            this.colUnitOfMeasure.ReadOnly = true;
            this.colUnitOfMeasure.Width = 50;
            // 
            // colNeedQty
            // 
            this.colNeedQty.DataPropertyName = "NeedQty";
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            this.colNeedQty.DefaultCellStyle = dataGridViewCellStyle10;
            this.colNeedQty.HeaderText = "Треб. кол-во";
            this.colNeedQty.Name = "colNeedQty";
            this.colNeedQty.ReadOnly = true;
            this.colNeedQty.Width = 50;
            // 
            // colFactQty
            // 
            this.colFactQty.DataPropertyName = "FactQty";
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.colFactQty.DefaultCellStyle = dataGridViewCellStyle11;
            this.colFactQty.HeaderText = "<FactQty>";
            this.colFactQty.Name = "colFactQty";
            this.colFactQty.ReadOnly = true;
            this.colFactQty.Visible = false;
            this.colFactQty.Width = 50;
            // 
            // colFactQtyVisible
            // 
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.colFactQtyVisible.DefaultCellStyle = dataGridViewCellStyle12;
            this.colFactQtyVisible.HeaderText = "Факт. кол-во";
            this.colFactQtyVisible.Name = "colFactQtyVisible";
            this.colFactQtyVisible.Width = 50;
            // 
            // dgvcCheckPrintYL
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.NullValue = false;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvcCheckPrintYL.DefaultCellStyle = dataGridViewCellStyle13;
            this.dgvcCheckPrintYL.HeaderText = "ПЖЭ";
            this.dgvcCheckPrintYL.Name = "dgvcCheckPrintYL";
            this.dgvcCheckPrintYL.ToolTipText = "Печать желтых этикеток";
            this.dgvcCheckPrintYL.Width = 40;
            // 
            // colDiff
            // 
            this.colDiff.DataPropertyName = "Diff";
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.Black;
            this.colDiff.DefaultCellStyle = dataGridViewCellStyle14;
            this.colDiff.HeaderText = "Недо- стача";
            this.colDiff.Name = "colDiff";
            this.colDiff.ReadOnly = true;
            this.colDiff.Width = 50;
            // 
            // colColor
            // 
            this.colColor.DataPropertyName = "Color";
            this.colColor.HeaderText = "<Color>";
            this.colColor.Name = "colColor";
            this.colColor.ReadOnly = true;
            this.colColor.Visible = false;
            // 
            // colLM_Location
            // 
            this.colLM_Location.DataPropertyName = "LM_Location";
            this.colLM_Location.HeaderText = "<LM_Location>";
            this.colLM_Location.Name = "colLM_Location";
            this.colLM_Location.ReadOnly = true;
            this.colLM_Location.Visible = false;
            // 
            // colLM_LocationVisible
            // 
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.colLM_LocationVisible.DefaultCellStyle = dataGridViewCellStyle15;
            this.colLM_LocationVisible.HeaderText = "Полка недостачи";
            this.colLM_LocationVisible.Name = "colLM_LocationVisible";
            this.colLM_LocationVisible.Width = 120;
            // 
            // controlDetailsBindingSource
            // 
            this.controlDetailsBindingSource.DataMember = "ControlDetails";
            this.controlDetailsBindingSource.DataSource = this.moveToSale;
            // 
            // moveToSale
            // 
            this.moveToSale.DataSetName = "MoveToSale";
            this.moveToSale.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Документ Тип:";
            // 
            // tbDocType
            // 
            this.tbDocType.Location = new System.Drawing.Point(104, 32);
            this.tbDocType.Name = "tbDocType";
            this.tbDocType.ReadOnly = true;
            this.tbDocType.Size = new System.Drawing.Size(132, 20);
            this.tbDocType.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(304, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Склад:";
            // 
            // tbDocWarehouse
            // 
            this.tbDocWarehouse.Location = new System.Drawing.Point(450, 7);
            this.tbDocWarehouse.Name = "tbDocWarehouse";
            this.tbDocWarehouse.ReadOnly = true;
            this.tbDocWarehouse.Size = new System.Drawing.Size(132, 20);
            this.tbDocWarehouse.TabIndex = 8;
            // 
            // pnlDocumentheader
            // 
            this.pnlDocumentheader.Controls.Add(this.lblScanItemsOnly);
            this.pnlDocumentheader.Controls.Add(this.label10);
            this.pnlDocumentheader.Controls.Add(this.cmbLevels);
            this.pnlDocumentheader.Controls.Add(this.label9);
            this.pnlDocumentheader.Controls.Add(this.cmbPrinters);
            this.pnlDocumentheader.Controls.Add(this.label8);
            this.pnlDocumentheader.Controls.Add(this.tbBoxScaner);
            this.pnlDocumentheader.Controls.Add(this.label7);
            this.pnlDocumentheader.Controls.Add(this.label6);
            this.pnlDocumentheader.Controls.Add(this.tbRelDocType);
            this.pnlDocumentheader.Controls.Add(this.tbRelDocNo);
            this.pnlDocumentheader.Controls.Add(this.tbDocDate);
            this.pnlDocumentheader.Controls.Add(this.label5);
            this.pnlDocumentheader.Controls.Add(this.tbDocWarehouse);
            this.pnlDocumentheader.Controls.Add(this.tbDocNo);
            this.pnlDocumentheader.Controls.Add(this.label2);
            this.pnlDocumentheader.Controls.Add(this.label3);
            this.pnlDocumentheader.Controls.Add(this.label4);
            this.pnlDocumentheader.Controls.Add(this.tbDocType);
            this.pnlDocumentheader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDocumentheader.Location = new System.Drawing.Point(0, 75);
            this.pnlDocumentheader.Name = "pnlDocumentheader";
            this.pnlDocumentheader.Size = new System.Drawing.Size(1516, 85);
            this.pnlDocumentheader.TabIndex = 3;
            this.pnlDocumentheader.Visible = false;
            // 
            // lblScanItemsOnly
            // 
            this.lblScanItemsOnly.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblScanItemsOnly.ForeColor = System.Drawing.Color.Red;
            this.lblScanItemsOnly.Location = new System.Drawing.Point(924, 10);
            this.lblScanItemsOnly.Name = "lblScanItemsOnly";
            this.lblScanItemsOnly.Size = new System.Drawing.Size(400, 70);
            this.lblScanItemsOnly.TabIndex = 21;
            this.lblScanItemsOnly.Text = "Контроль необходимо проводить путем сканирования ЖЭ!!!";
            this.lblScanItemsOnly.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(650, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Ячейка приема:";
            // 
            // cmbLevels
            // 
            this.cmbLevels.DataSource = this.levelsBindingSource;
            this.cmbLevels.DisplayMember = "lvl";
            this.cmbLevels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLevels.FormattingEnabled = true;
            this.cmbLevels.Location = new System.Drawing.Point(744, 33);
            this.cmbLevels.Name = "cmbLevels";
            this.cmbLevels.Size = new System.Drawing.Size(140, 21);
            this.cmbLevels.TabIndex = 19;
            this.cmbLevels.ValueMember = "lvl";
            // 
            // levelsBindingSource
            // 
            this.levelsBindingSource.DataMember = "Levels";
            this.levelsBindingSource.DataSource = this.moveToSale;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Blue;
            this.label9.Location = new System.Drawing.Point(685, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Принтер:";
            // 
            // cmbPrinters
            // 
            this.cmbPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinters.FormattingEnabled = true;
            this.cmbPrinters.Location = new System.Drawing.Point(744, 59);
            this.cmbPrinters.Name = "cmbPrinters";
            this.cmbPrinters.Size = new System.Drawing.Size(174, 21);
            this.cmbPrinters.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(643, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Штрихкод ящика:";
            // 
            // tbBoxScaner
            // 
            this.tbBoxScaner.AllowType = true;
            this.tbBoxScaner.AutoConvert = true;
            this.tbBoxScaner.DelayThreshold = 50D;
            this.tbBoxScaner.Location = new System.Drawing.Point(744, 6);
            this.tbBoxScaner.Name = "tbBoxScaner";
            this.tbBoxScaner.RaiseTextChangeWithoutEnter = false;
            this.tbBoxScaner.ReadOnly = false;
            this.tbBoxScaner.Size = new System.Drawing.Size(174, 25);
            this.tbBoxScaner.TabIndex = 15;
            this.tbBoxScaner.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.tbBoxScaner.UseParentFont = false;
            this.tbBoxScaner.UseScanModeOnly = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(304, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Связанный Документ Тип:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(304, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Связанный Документ Но.:";
            // 
            // tbRelDocType
            // 
            this.tbRelDocType.Location = new System.Drawing.Point(450, 57);
            this.tbRelDocType.Name = "tbRelDocType";
            this.tbRelDocType.ReadOnly = true;
            this.tbRelDocType.Size = new System.Drawing.Size(132, 20);
            this.tbRelDocType.TabIndex = 12;
            // 
            // tbRelDocNo
            // 
            this.tbRelDocNo.Location = new System.Drawing.Point(450, 32);
            this.tbRelDocNo.Name = "tbRelDocNo";
            this.tbRelDocNo.ReadOnly = true;
            this.tbRelDocNo.Size = new System.Drawing.Size(132, 20);
            this.tbRelDocNo.TabIndex = 11;
            // 
            // tbDocDate
            // 
            this.tbDocDate.Location = new System.Drawing.Point(104, 57);
            this.tbDocDate.Name = "tbDocDate";
            this.tbDocDate.ReadOnly = true;
            this.tbDocDate.Size = new System.Drawing.Size(132, 20);
            this.tbDocDate.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Документ Дата:";
            // 
            // btnCommit
            // 
            this.btnCloseDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseDoc.Location = new System.Drawing.Point(1373, 10);
            this.btnCloseDoc.Name = "btnCommit";
            this.btnCloseDoc.Size = new System.Drawing.Size(140, 23);
            this.btnCloseDoc.TabIndex = 17;
            this.btnCloseDoc.Text = "Закрыть Документ";
            this.btnCloseDoc.UseVisualStyleBackColor = true;
            this.btnCloseDoc.Click += new System.EventHandler(this.btnCloseDoc_Click);
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnCreateTask);
            this.pnlFooter.Controls.Add(this.btnCloseDoc);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 562);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1516, 45);
            this.pnlFooter.TabIndex = 4;
            this.pnlFooter.Visible = false;
            // 
            // containers
            // 
            this.containers.DataSetName = "Containers";
            this.containers.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // containersBindingSource
            // 
            this.containersBindingSource.DataSource = this.containers;
            this.containersBindingSource.Position = 0;
            // 
            // controlHeaderBindingSource
            // 
            this.controlHeaderBindingSource.DataMember = "ControlHeader";
            this.controlHeaderBindingSource.DataSource = this.moveToSale;
            // 
            // controlHeaderTableAdapter
            // 
            this.controlHeaderTableAdapter.ClearBeforeFill = true;
            // 
            // controlDetailsTableAdapter
            // 
            this.controlDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // levelsTableAdapter
            // 
            this.levelsTableAdapter.ClearBeforeFill = true;
            // 
            // btnCreateJob
            // 
            this.btnCreateTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateTask.Location = new System.Drawing.Point(1227, 10);
            this.btnCreateTask.Name = "btnCreateJob";
            this.btnCreateTask.Size = new System.Drawing.Size(140, 23);
            this.btnCreateTask.TabIndex = 18;
            this.btnCreateTask.Text = "Сформировать Задание";
            this.btnCreateTask.UseVisualStyleBackColor = true;
            this.btnCreateTask.Click += new System.EventHandler(this.btnCreateTask_Click);
            // 
            // MoveToSaleControlWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1516, 607);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlDocumentheader);
            this.Controls.Add(this.pnlDocLines);
            this.Controls.Add(this.pnlBarcode);
            this.KeyPreview = true;
            this.Name = "MoveToSaleControlWindow";
            this.Load += new System.EventHandler(this.MoveToSaleControlWindow_Load);
            this.Controls.SetChildIndex(this.pnlBarcode, 0);
            this.Controls.SetChildIndex(this.pnlDocLines, 0);
            this.Controls.SetChildIndex(this.pnlDocumentheader, 0);
            this.Controls.SetChildIndex(this.pnlFooter, 0);
            this.pnlBarcode.ResumeLayout(false);
            this.pnlBarcode.PerformLayout();
            this.pnlDocLines.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controlDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveToSale)).EndInit();
            this.pnlDocumentheader.ResumeLayout(false);
            this.pnlDocumentheader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.levelsBindingSource)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.containers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.containersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controlHeaderBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBarcode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDocNo;
        private WMSOffice.Controls.TextBoxScaner tbDocumentScaner;
        private System.Windows.Forms.Panel pnlDocLines;
        private System.Windows.Forms.BindingSource controlHeaderBindingSource;
        private WMSOffice.Data.MoveToSale moveToSale;
        private WMSOffice.Data.MoveToSaleTableAdapters.ControlHeaderTableAdapter controlHeaderTableAdapter;
        private System.Windows.Forms.TextBox tbDocType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDocWarehouse;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlDocumentheader;
        private System.Windows.Forms.TextBox tbRelDocType;
        private System.Windows.Forms.TextBox tbRelDocNo;
        private System.Windows.Forms.TextBox tbDocDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.BindingSource controlDetailsBindingSource;
        private WMSOffice.Data.MoveToSaleTableAdapters.ControlDetailsTableAdapter controlDetailsTableAdapter;
        private System.Windows.Forms.Label label8;
        private WMSOffice.Controls.TextBoxScaner tbBoxScaner;
        private System.Windows.Forms.Button btnCloseDoc;
        private System.Windows.Forms.Panel pnlFooter;
        private WMSOffice.Data.Containers containers;
        private System.Windows.Forms.BindingSource containersBindingSource;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbPrinters;
        private System.Windows.Forms.ComboBox cmbLevels;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.BindingSource levelsBindingSource;
        private WMSOffice.Data.MoveToSaleTableAdapters.LevelsTableAdapter levelsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItem_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colManufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVendor_Lot;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLot_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocationFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocationTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SectorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitOfMeasure;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNeedQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFactQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFactQtyVisible;
        private WMSOffice.Dialogs.Inventory.CustomDataGridViewCheckBoxColumn dgvcCheckPrintYL;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiff;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLM_Location;
        private WMSOffice.Controls.MoveToSale.ProblemLocationColumn colLM_LocationVisible;
        private System.Windows.Forms.Label lblScanItemsOnly;
        private System.Windows.Forms.Button btnCreateTask;
    }
}
