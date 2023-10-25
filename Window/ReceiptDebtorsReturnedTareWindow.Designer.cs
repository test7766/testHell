namespace WMSOffice.Window
{
    partial class ReceiptDebtorsReturnedTareWindow
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
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.btnRefreshDoc = new System.Windows.Forms.ToolStripButton();
            this.btnCloseDoc = new System.Windows.Forms.ToolStripButton();
            this.btnCancelDoc = new System.Windows.Forms.ToolStripButton();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.barCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tareNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warehouseIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locnTareDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateCreatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pretensionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jTRETRepeatedDocDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.delivery = new WMSOffice.Data.Delivery();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.tbsItemBarcode = new WMSOffice.Controls.TextBoxScaner();
            this.lblItemBarcode = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.jT_RET_Repeated_Doc_DetailsTableAdapter = new WMSOffice.Data.DeliveryTableAdapters.JT_RET_Repeated_Doc_DetailsTableAdapter();
            this.tsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jTRETRepeatedDocDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.delivery)).BeginInit();
            this.pnlSearch.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefreshDoc,
            this.btnCloseDoc,
            this.btnCancelDoc});
            this.tsMain.Location = new System.Drawing.Point(0, 40);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1269, 39);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
            // 
            // btnRefreshDoc
            // 
            this.btnRefreshDoc.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefreshDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefreshDoc.Name = "btnRefreshDoc";
            this.btnRefreshDoc.Size = new System.Drawing.Size(97, 36);
            this.btnRefreshDoc.Text = "Обновить\nдокумент";
            this.btnRefreshDoc.Click += new System.EventHandler(this.btnRefreshDoc_Click);
            // 
            // btnCloseDoc
            // 
            this.btnCloseDoc.Image = global::WMSOffice.Properties.Resources.finish_process;
            this.btnCloseDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCloseDoc.Name = "btnCloseDoc";
            this.btnCloseDoc.Size = new System.Drawing.Size(95, 36);
            this.btnCloseDoc.Text = "Закрыть\nдокумент";
            this.btnCloseDoc.Click += new System.EventHandler(this.btnCloseDoc_Click);
            // 
            // btnCancelDoc
            // 
            this.btnCancelDoc.Image = global::WMSOffice.Properties.Resources.symbol_stop;
            this.btnCancelDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelDoc.Name = "btnCancelDoc";
            this.btnCancelDoc.Size = new System.Drawing.Size(97, 36);
            this.btnCancelDoc.Text = "Отменить\nдокумент";
            this.btnCancelDoc.Click += new System.EventHandler(this.btnCancelDoc_Click);
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AllowUserToResizeRows = false;
            this.dgvItems.AutoGenerateColumns = false;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.barCodeDataGridViewTextBoxColumn,
            this.tareNameDataGridViewTextBoxColumn,
            this.statusNameDataGridViewTextBoxColumn,
            this.warehouseIDDataGridViewTextBoxColumn,
            this.locnTareDataGridViewTextBoxColumn,
            this.dateCreatedDataGridViewTextBoxColumn,
            this.actDataGridViewTextBoxColumn,
            this.pretensionDataGridViewTextBoxColumn});
            this.dgvItems.DataSource = this.jTRETRepeatedDocDetailsBindingSource;
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItems.Location = new System.Drawing.Point(0, 0);
            this.dgvItems.MultiSelect = false;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(1269, 345);
            this.dgvItems.TabIndex = 0;
            this.dgvItems.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvItems_CellFormatting);
            // 
            // barCodeDataGridViewTextBoxColumn
            // 
            this.barCodeDataGridViewTextBoxColumn.DataPropertyName = "BarCode";
            this.barCodeDataGridViewTextBoxColumn.HeaderText = "Ш/К тары";
            this.barCodeDataGridViewTextBoxColumn.Name = "barCodeDataGridViewTextBoxColumn";
            this.barCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tareNameDataGridViewTextBoxColumn
            // 
            this.tareNameDataGridViewTextBoxColumn.DataPropertyName = "TareName";
            this.tareNameDataGridViewTextBoxColumn.HeaderText = "Наименование тары";
            this.tareNameDataGridViewTextBoxColumn.Name = "tareNameDataGridViewTextBoxColumn";
            this.tareNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.tareNameDataGridViewTextBoxColumn.Width = 200;
            // 
            // statusNameDataGridViewTextBoxColumn
            // 
            this.statusNameDataGridViewTextBoxColumn.DataPropertyName = "StatusName";
            this.statusNameDataGridViewTextBoxColumn.HeaderText = "Статус тары";
            this.statusNameDataGridViewTextBoxColumn.Name = "statusNameDataGridViewTextBoxColumn";
            this.statusNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusNameDataGridViewTextBoxColumn.Width = 200;
            // 
            // warehouseIDDataGridViewTextBoxColumn
            // 
            this.warehouseIDDataGridViewTextBoxColumn.DataPropertyName = "WarehouseID";
            this.warehouseIDDataGridViewTextBoxColumn.HeaderText = "Склад тары";
            this.warehouseIDDataGridViewTextBoxColumn.Name = "warehouseIDDataGridViewTextBoxColumn";
            this.warehouseIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // locnTareDataGridViewTextBoxColumn
            // 
            this.locnTareDataGridViewTextBoxColumn.DataPropertyName = "LocnTare";
            this.locnTareDataGridViewTextBoxColumn.HeaderText = "Место хранения";
            this.locnTareDataGridViewTextBoxColumn.Name = "locnTareDataGridViewTextBoxColumn";
            this.locnTareDataGridViewTextBoxColumn.ReadOnly = true;
            this.locnTareDataGridViewTextBoxColumn.Width = 150;
            // 
            // dateCreatedDataGridViewTextBoxColumn
            // 
            this.dateCreatedDataGridViewTextBoxColumn.DataPropertyName = "DateCreated";
            this.dateCreatedDataGridViewTextBoxColumn.HeaderText = "Дата сканирования";
            this.dateCreatedDataGridViewTextBoxColumn.Name = "dateCreatedDataGridViewTextBoxColumn";
            this.dateCreatedDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateCreatedDataGridViewTextBoxColumn.Width = 140;
            // 
            // actDataGridViewTextBoxColumn
            // 
            this.actDataGridViewTextBoxColumn.DataPropertyName = "Act";
            this.actDataGridViewTextBoxColumn.HeaderText = "Акт ОТ";
            this.actDataGridViewTextBoxColumn.Name = "actDataGridViewTextBoxColumn";
            this.actDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pretensionDataGridViewTextBoxColumn
            // 
            this.pretensionDataGridViewTextBoxColumn.DataPropertyName = "Pretension";
            this.pretensionDataGridViewTextBoxColumn.HeaderText = "Претензия";
            this.pretensionDataGridViewTextBoxColumn.Name = "pretensionDataGridViewTextBoxColumn";
            this.pretensionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // jTRETRepeatedDocDetailsBindingSource
            // 
            this.jTRETRepeatedDocDetailsBindingSource.DataMember = "JT_RET_Repeated_Doc_Details";
            this.jTRETRepeatedDocDetailsBindingSource.DataSource = this.delivery;
            // 
            // delivery
            // 
            this.delivery.DataSetName = "Delivery";
            this.delivery.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.tbsItemBarcode);
            this.pnlSearch.Controls.Add(this.lblItemBarcode);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 79);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(1269, 35);
            this.pnlSearch.TabIndex = 4;
            // 
            // tbsItemBarcode
            // 
            this.tbsItemBarcode.AllowType = true;
            this.tbsItemBarcode.AutoConvert = true;
            this.tbsItemBarcode.DelayThreshold = 50;
            this.tbsItemBarcode.Location = new System.Drawing.Point(52, 5);
            this.tbsItemBarcode.Name = "tbsItemBarcode";
            this.tbsItemBarcode.RaiseTextChangeWithoutEnter = false;
            this.tbsItemBarcode.ReadOnly = false;
            this.tbsItemBarcode.ScannerListener = null;
            this.tbsItemBarcode.Size = new System.Drawing.Size(180, 25);
            this.tbsItemBarcode.TabIndex = 1;
            this.tbsItemBarcode.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.tbsItemBarcode.UseParentFont = false;
            this.tbsItemBarcode.UseScanModeOnly = false;
            // 
            // lblItemBarcode
            // 
            this.lblItemBarcode.AutoSize = true;
            this.lblItemBarcode.Location = new System.Drawing.Point(12, 11);
            this.lblItemBarcode.Name = "lblItemBarcode";
            this.lblItemBarcode.Size = new System.Drawing.Size(34, 13);
            this.lblItemBarcode.TabIndex = 0;
            this.lblItemBarcode.Text = "Ш/К :";
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.dgvItems);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 114);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1269, 345);
            this.pnlContent.TabIndex = 5;
            // 
            // jT_RET_Repeated_Doc_DetailsTableAdapter
            // 
            this.jT_RET_Repeated_Doc_DetailsTableAdapter.ClearBeforeFill = true;
            // 
            // ReceiptDebtorsReturnedTareWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 459);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.tsMain);
            this.Name = "ReceiptDebtorsReturnedTareWindow";
            this.Text = "ReceiptDebtorsReturnedTareWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReceiptDebtorsReturnedTareWindow_FormClosing);
            this.Controls.SetChildIndex(this.tsMain, 0);
            this.Controls.SetChildIndex(this.pnlSearch, 0);
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jTRETRepeatedDocDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.delivery)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btnCloseDoc;
        private System.Windows.Forms.ToolStripButton btnCancelDoc;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.ToolStripButton btnRefreshDoc;
        private System.Windows.Forms.Panel pnlSearch;
        private WMSOffice.Controls.TextBoxScaner tbsItemBarcode;
        private System.Windows.Forms.Label lblItemBarcode;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.BindingSource jTRETRepeatedDocDetailsBindingSource;
        private WMSOffice.Data.Delivery delivery;
        private WMSOffice.Data.DeliveryTableAdapters.JT_RET_Repeated_Doc_DetailsTableAdapter jT_RET_Repeated_Doc_DetailsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn barCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tareNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn warehouseIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locnTareDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateCreatedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn actDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pretensionDataGridViewTextBoxColumn;
    }
}