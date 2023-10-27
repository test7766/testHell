namespace WMSOffice.Dialogs.WH.TSD
{
    partial class TSD_CheckPrintersForm
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
            this.btnUndoPrinter = new System.Windows.Forms.ToolStripButton();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.tSD = new WMSOffice.Data.TSD();
            this.checkedPrintersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.checkedPrintersTableAdapter = new WMSOffice.Data.TSDTableAdapters.CheckedPrintersTableAdapter();
            this.printeridDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printerbarcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateupdatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aBALPHDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlButtons.SuspendLayout();
            this.tsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tSD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedPrintersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(517, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(607, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 378);
            this.pnlButtons.Size = new System.Drawing.Size(694, 43);
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnUndoPrinter});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(694, 39);
            this.tsMain.TabIndex = 101;
            this.tsMain.Text = "toolStrip1";
            // 
            // btnUndoPrinter
            // 
            this.btnUndoPrinter.Image = global::WMSOffice.Properties.Resources.Restore;
            this.btnUndoPrinter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUndoPrinter.Name = "btnUndoPrinter";
            this.btnUndoPrinter.Size = new System.Drawing.Size(136, 36);
            this.btnUndoPrinter.Text = "Вернуть принтер";
            this.btnUndoPrinter.Click += new System.EventHandler(this.btnUndoPrinter_Click);
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AllowUserToResizeRows = false;
            this.dgvItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvItems.AutoGenerateColumns = false;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.printeridDataGridViewTextBoxColumn,
            this.printerbarcodeDataGridViewTextBoxColumn,
            this.dateupdatedDataGridViewTextBoxColumn,
            this.aBALPHDataGridViewTextBoxColumn});
            this.dgvItems.DataSource = this.checkedPrintersBindingSource;
            this.dgvItems.Location = new System.Drawing.Point(0, 42);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(694, 330);
            this.dgvItems.TabIndex = 102;
            // 
            // tSD
            // 
            this.tSD.DataSetName = "TSD";
            this.tSD.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // checkedPrintersBindingSource
            // 
            this.checkedPrintersBindingSource.DataMember = "CheckedPrinters";
            this.checkedPrintersBindingSource.DataSource = this.tSD;
            // 
            // checkedPrintersTableAdapter
            // 
            this.checkedPrintersTableAdapter.ClearBeforeFill = true;
            // 
            // printeridDataGridViewTextBoxColumn
            // 
            this.printeridDataGridViewTextBoxColumn.DataPropertyName = "printer_id";
            this.printeridDataGridViewTextBoxColumn.HeaderText = "Код принтера";
            this.printeridDataGridViewTextBoxColumn.Name = "printeridDataGridViewTextBoxColumn";
            this.printeridDataGridViewTextBoxColumn.ReadOnly = true;
            this.printeridDataGridViewTextBoxColumn.Width = 120;
            // 
            // printerbarcodeDataGridViewTextBoxColumn
            // 
            this.printerbarcodeDataGridViewTextBoxColumn.DataPropertyName = "printer_bar_code";
            this.printerbarcodeDataGridViewTextBoxColumn.HeaderText = "Ш/К принтера";
            this.printerbarcodeDataGridViewTextBoxColumn.Name = "printerbarcodeDataGridViewTextBoxColumn";
            this.printerbarcodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.printerbarcodeDataGridViewTextBoxColumn.Width = 120;
            // 
            // dateupdatedDataGridViewTextBoxColumn
            // 
            this.dateupdatedDataGridViewTextBoxColumn.DataPropertyName = "date_updated";
            this.dateupdatedDataGridViewTextBoxColumn.HeaderText = "Обновлено когда";
            this.dateupdatedDataGridViewTextBoxColumn.Name = "dateupdatedDataGridViewTextBoxColumn";
            this.dateupdatedDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateupdatedDataGridViewTextBoxColumn.Width = 120;
            // 
            // aBALPHDataGridViewTextBoxColumn
            // 
            this.aBALPHDataGridViewTextBoxColumn.DataPropertyName = "ABALPH";
            this.aBALPHDataGridViewTextBoxColumn.HeaderText = "Обновлено кем";
            this.aBALPHDataGridViewTextBoxColumn.Name = "aBALPHDataGridViewTextBoxColumn";
            this.aBALPHDataGridViewTextBoxColumn.ReadOnly = true;
            this.aBALPHDataGridViewTextBoxColumn.Width = 300;
            // 
            // TSD_CheckPrintersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 421);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.tsMain);
            this.Name = "TSD_CheckPrintersForm";
            this.Text = "Проверка активности принтеров на контроле \"волны\"";
            this.Load += new System.EventHandler(this.TSD_CheckPrintersForm_Load);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.tsMain, 0);
            this.Controls.SetChildIndex(this.dgvItems, 0);
            this.pnlButtons.ResumeLayout(false);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tSD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedPrintersBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btnUndoPrinter;
        private System.Windows.Forms.DataGridView dgvItems;
        private Data.TSD tSD;
        private System.Windows.Forms.BindingSource checkedPrintersBindingSource;
        private Data.TSDTableAdapters.CheckedPrintersTableAdapter checkedPrintersTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn printeridDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn printerbarcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateupdatedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aBALPHDataGridViewTextBoxColumn;
    }
}