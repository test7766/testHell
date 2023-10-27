namespace WMSOffice.Dialogs.Complaints
{
    partial class CorrectPickedReturnsForm
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
            this.btbRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnConfirmDoc = new System.Windows.Forms.ToolStripButton();
            this.btnCancelDoc = new System.Windows.Forms.ToolStripButton();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.dgvDocLines = new System.Windows.Forms.DataGridView();
            this.vRNRDocLinesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.complaints = new WMSOffice.Data.Complaints();
            this.vR_NR_DocLinesTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.VR_NR_DocLinesTableAdapter();
            this.isselectedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.boxBarDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Location_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iorlotDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Exp_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Invoice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlButtons.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vRNRDocLinesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(1261, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1351, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 528);
            this.pnlButtons.Size = new System.Drawing.Size(894, 43);
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btbRefresh,
            this.toolStripSeparator1,
            this.btnConfirmDoc,
            this.btnCancelDoc});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(894, 39);
            this.tsMain.TabIndex = 101;
            this.tsMain.Text = "toolStrip1";
            // 
            // btbRefresh
            // 
            this.btbRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btbRefresh.Name = "btbRefresh";
            this.btbRefresh.Size = new System.Drawing.Size(97, 36);
            this.btbRefresh.Text = "Обновить";
            this.btbRefresh.Click += new System.EventHandler(this.btbRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // btnConfirmDoc
            // 
            this.btnConfirmDoc.Image = global::WMSOffice.Properties.Resources.document_ok;
            this.btnConfirmDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConfirmDoc.Name = "btnConfirmDoc";
            this.btnConfirmDoc.Size = new System.Drawing.Size(145, 36);
            this.btnConfirmDoc.Text = "Принять документ";
            this.btnConfirmDoc.Click += new System.EventHandler(this.btnConfirmDoc_Click);
            // 
            // btnCancelDoc
            // 
            this.btnCancelDoc.Image = global::WMSOffice.Properties.Resources.symbol_stop;
            this.btnCancelDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelDoc.Name = "btnCancelDoc";
            this.btnCancelDoc.Size = new System.Drawing.Size(152, 36);
            this.btnCancelDoc.Text = "Отменить документ";
            this.btnCancelDoc.Click += new System.EventHandler(this.btnCancelDoc_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContent.Controls.Add(this.dgvDocLines);
            this.pnlContent.Location = new System.Drawing.Point(0, 42);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(894, 480);
            this.pnlContent.TabIndex = 102;
            // 
            // dgvDocLines
            // 
            this.dgvDocLines.AllowUserToAddRows = false;
            this.dgvDocLines.AllowUserToDeleteRows = false;
            this.dgvDocLines.AllowUserToResizeColumns = false;
            this.dgvDocLines.AllowUserToResizeRows = false;
            this.dgvDocLines.AutoGenerateColumns = false;
            this.dgvDocLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocLines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.isselectedDataGridViewCheckBoxColumn,
            this.boxBarDataGridViewTextBoxColumn,
            this.Location_id,
            this.itemDataGridViewTextBoxColumn,
            this.lotNumberDataGridViewTextBoxColumn,
            this.iorlotDataGridViewTextBoxColumn,
            this.Exp_date,
            this.Column1,
            this.quantityDataGridViewTextBoxColumn,
            this.Invoice,
            this.InvoiceDate});
            this.dgvDocLines.DataSource = this.vRNRDocLinesBindingSource;
            this.dgvDocLines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocLines.Location = new System.Drawing.Point(0, 0);
            this.dgvDocLines.MultiSelect = false;
            this.dgvDocLines.Name = "dgvDocLines";
            this.dgvDocLines.RowHeadersVisible = false;
            this.dgvDocLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocLines.Size = new System.Drawing.Size(894, 480);
            this.dgvDocLines.TabIndex = 0;
            this.dgvDocLines.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocLines_CellValueChanged);
            this.dgvDocLines.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDocLines_CellFormatting);
            this.dgvDocLines.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvDocLines_CurrentCellDirtyStateChanged);
            // 
            // vRNRDocLinesBindingSource
            // 
            this.vRNRDocLinesBindingSource.DataMember = "VR_NR_DocLines";
            this.vRNRDocLinesBindingSource.DataSource = this.complaints;
            // 
            // complaints
            // 
            this.complaints.DataSetName = "Complaints";
            this.complaints.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vR_NR_DocLinesTableAdapter
            // 
            this.vR_NR_DocLinesTableAdapter.ClearBeforeFill = true;
            // 
            // isselectedDataGridViewCheckBoxColumn
            // 
            this.isselectedDataGridViewCheckBoxColumn.DataPropertyName = "is_selected";
            this.isselectedDataGridViewCheckBoxColumn.HeaderText = "Отм.";
            this.isselectedDataGridViewCheckBoxColumn.Name = "isselectedDataGridViewCheckBoxColumn";
            this.isselectedDataGridViewCheckBoxColumn.Width = 35;
            // 
            // boxBarDataGridViewTextBoxColumn
            // 
            this.boxBarDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.boxBarDataGridViewTextBoxColumn.DataPropertyName = "Box_Bar";
            this.boxBarDataGridViewTextBoxColumn.HeaderText = "Ш/К ящика";
            this.boxBarDataGridViewTextBoxColumn.Name = "boxBarDataGridViewTextBoxColumn";
            this.boxBarDataGridViewTextBoxColumn.ReadOnly = true;
            this.boxBarDataGridViewTextBoxColumn.Width = 89;
            // 
            // Location_id
            // 
            this.Location_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Location_id.DataPropertyName = "Location_id";
            this.Location_id.HeaderText = "Место";
            this.Location_id.Name = "Location_id";
            this.Location_id.ReadOnly = true;
            this.Location_id.Width = 64;
            // 
            // itemDataGridViewTextBoxColumn
            // 
            this.itemDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemDataGridViewTextBoxColumn.DataPropertyName = "Item";
            this.itemDataGridViewTextBoxColumn.HeaderText = "Наименование товара";
            this.itemDataGridViewTextBoxColumn.Name = "itemDataGridViewTextBoxColumn";
            this.itemDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemDataGridViewTextBoxColumn.Width = 133;
            // 
            // lotNumberDataGridViewTextBoxColumn
            // 
            this.lotNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lotNumberDataGridViewTextBoxColumn.DataPropertyName = "Lot_Number";
            this.lotNumberDataGridViewTextBoxColumn.HeaderText = "Партия";
            this.lotNumberDataGridViewTextBoxColumn.Name = "lotNumberDataGridViewTextBoxColumn";
            this.lotNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.lotNumberDataGridViewTextBoxColumn.Width = 69;
            // 
            // iorlotDataGridViewTextBoxColumn
            // 
            this.iorlotDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.iorlotDataGridViewTextBoxColumn.DataPropertyName = "iorlot";
            this.iorlotDataGridViewTextBoxColumn.HeaderText = "Серия";
            this.iorlotDataGridViewTextBoxColumn.Name = "iorlotDataGridViewTextBoxColumn";
            this.iorlotDataGridViewTextBoxColumn.ReadOnly = true;
            this.iorlotDataGridViewTextBoxColumn.Width = 63;
            // 
            // Exp_date
            // 
            this.Exp_date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Exp_date.DataPropertyName = "Exp_date";
            this.Exp_date.HeaderText = "Срок годности";
            this.Exp_date.Name = "Exp_date";
            this.Exp_date.ReadOnly = true;
            this.Exp_date.Width = 97;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.DataPropertyName = "UOM";
            this.Column1.HeaderText = "ЕИ";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 47;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Кол-во";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.ReadOnly = true;
            this.quantityDataGridViewTextBoxColumn.Width = 66;
            // 
            // Invoice
            // 
            this.Invoice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Invoice.DataPropertyName = "Invoice";
            this.Invoice.HeaderText = "№ ориг. док.";
            this.Invoice.Name = "Invoice";
            this.Invoice.ReadOnly = true;
            this.Invoice.Width = 88;
            // 
            // InvoiceDate
            // 
            this.InvoiceDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.InvoiceDate.DataPropertyName = "InvoiceDate";
            this.InvoiceDate.HeaderText = "Дата ориг. док.";
            this.InvoiceDate.Name = "InvoiceDate";
            this.InvoiceDate.ReadOnly = true;
            this.InvoiceDate.Width = 83;
            // 
            // CorrectPickedReturnsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 571);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.tsMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "CorrectPickedReturnsForm";
            this.Text = "Корректировка собранных возвратов № {0}";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CorrectPickedReturnsForm_FormClosing);
            this.Controls.SetChildIndex(this.tsMain, 0);
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vRNRDocLinesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btbRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnConfirmDoc;
        private System.Windows.Forms.ToolStripButton btnCancelDoc;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.DataGridView dgvDocLines;
        private System.Windows.Forms.BindingSource vRNRDocLinesBindingSource;
        private WMSOffice.Data.Complaints complaints;
        private WMSOffice.Data.ComplaintsTableAdapters.VR_NR_DocLinesTableAdapter vR_NR_DocLinesTableAdapter;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isselectedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn boxBarDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Location_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iorlotDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Exp_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Invoice;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceDate;
    }
}