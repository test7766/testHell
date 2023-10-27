namespace WMSOffice.Dialogs.Complaints
{
    partial class CheckInvoicesForCancelWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckInvoicesForCancelWindow));
            this.pnlWork = new System.Windows.Forms.Panel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCloseDoc = new System.Windows.Forms.ToolStripButton();
            this.lblBarcodeCaption = new System.Windows.Forms.Label();
            this.tbBarcode = new WMSOffice.Controls.TextBoxScaner();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.miCloseDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.gvLines = new System.Windows.Forms.DataGridView();
            this.companyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoiceTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoiceNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taxInvoiceNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isInvoiceClosedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isScannedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.barCodesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkInvoicesForCancelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.complaints = new WMSOffice.Data.Complaints();
            this.checkInvoicesForCancelTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.CheckInvoicesForCancelTableAdapter();
            this.pnlWork.SuspendLayout();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkInvoicesForCancelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlWork
            // 
            this.pnlWork.Controls.Add(this.splitContainer);
            this.pnlWork.Controls.Add(this.lblBarcodeCaption);
            this.pnlWork.Controls.Add(this.tbBarcode);
            this.pnlWork.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlWork.Location = new System.Drawing.Point(0, 40);
            this.pnlWork.Name = "pnlWork";
            this.pnlWork.Size = new System.Drawing.Size(839, 93);
            this.pnlWork.TabIndex = 10;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainer.Size = new System.Drawing.Size(839, 59);
            this.splitContainer.SplitterDistance = 234;
            this.splitContainer.TabIndex = 8;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnUndo,
            this.toolStripSeparator3,
            this.btnCloseDoc});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(234, 55);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "Панель инструментов документа";
            // 
            // btnUndo
            // 
            this.btnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUndo.Enabled = false;
            this.btnUndo.Image = global::WMSOffice.Properties.Resources.undo43;
            this.btnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(52, 52);
            this.btnUndo.Text = "Отменить последнее действие";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 55);
            // 
            // btnCloseDoc
            // 
            this.btnCloseDoc.Image = global::WMSOffice.Properties.Resources.F4;
            this.btnCloseDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCloseDoc.Name = "btnCloseDoc";
            this.btnCloseDoc.Size = new System.Drawing.Size(148, 52);
            this.btnCloseDoc.Text = "Завершить\n\r аннулирование\n\r заказа";
            this.btnCloseDoc.ToolTipText = "Завершить комплектацию акта передачи";
            this.btnCloseDoc.Click += new System.EventHandler(this.btnCloseDoc_Click);
            // 
            // lblBarcodeCaption
            // 
            this.lblBarcodeCaption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBarcodeCaption.AutoSize = true;
            this.lblBarcodeCaption.Location = new System.Drawing.Point(14, 69);
            this.lblBarcodeCaption.Name = "lblBarcodeCaption";
            this.lblBarcodeCaption.Size = new System.Drawing.Size(119, 13);
            this.lblBarcodeCaption.TabIndex = 7;
            this.lblBarcodeCaption.Text = "Штрих-код накладной:";
            // 
            // tbBarcode
            // 
            this.tbBarcode.AllowType = true;
            this.tbBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBarcode.AutoConvert = true;
            this.tbBarcode.ContextMenuStrip = this.contextMenuStrip1;
            this.tbBarcode.Location = new System.Drawing.Point(139, 62);
            this.tbBarcode.Name = "tbBarcode";
            this.tbBarcode.Size = new System.Drawing.Size(688, 25);
            this.tbBarcode.TabIndex = 2;
            this.tbBarcode.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.tbBarcode.TextChanged += new System.EventHandler(this.tbBarcode_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miUndo,
            this.miCloseDoc});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(283, 48);
            // 
            // miUndo
            // 
            this.miUndo.Name = "miUndo";
            this.miUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.miUndo.Size = new System.Drawing.Size(282, 22);
            this.miUndo.Text = "Отменить последнее действие";
            // 
            // miCloseDoc
            // 
            this.miCloseDoc.Name = "miCloseDoc";
            this.miCloseDoc.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.miCloseDoc.Size = new System.Drawing.Size(282, 22);
            this.miCloseDoc.Text = "Завершить аннулирование заказа";
            this.miCloseDoc.Click += new System.EventHandler(this.btnCloseDoc_Click);
            // 
            // gvLines
            // 
            this.gvLines.AllowUserToAddRows = false;
            this.gvLines.AllowUserToDeleteRows = false;
            this.gvLines.AllowUserToResizeRows = false;
            this.gvLines.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvLines.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvLines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.companyDataGridViewTextBoxColumn,
            this.orderTypeDataGridViewTextBoxColumn,
            this.orderNumberDataGridViewTextBoxColumn,
            this.invoiceTypeDataGridViewTextBoxColumn,
            this.invoiceNumberDataGridViewTextBoxColumn,
            this.taxInvoiceNumberDataGridViewTextBoxColumn,
            this.isInvoiceClosedDataGridViewCheckBoxColumn,
            this.isScannedDataGridViewCheckBoxColumn,
            this.barCodesDataGridViewTextBoxColumn});
            this.gvLines.ContextMenuStrip = this.contextMenuStrip1;
            this.gvLines.DataSource = this.checkInvoicesForCancelBindingSource;
            this.gvLines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvLines.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gvLines.Location = new System.Drawing.Point(0, 133);
            this.gvLines.Name = "gvLines";
            this.gvLines.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvLines.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gvLines.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gvLines.Size = new System.Drawing.Size(839, 255);
            this.gvLines.TabIndex = 11;
            this.gvLines.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gvLines_DataBindingComplete);
            // 
            // companyDataGridViewTextBoxColumn
            // 
            this.companyDataGridViewTextBoxColumn.DataPropertyName = "Company";
            this.companyDataGridViewTextBoxColumn.HeaderText = "Company";
            this.companyDataGridViewTextBoxColumn.Name = "companyDataGridViewTextBoxColumn";
            this.companyDataGridViewTextBoxColumn.ReadOnly = true;
            this.companyDataGridViewTextBoxColumn.Visible = false;
            // 
            // orderTypeDataGridViewTextBoxColumn
            // 
            this.orderTypeDataGridViewTextBoxColumn.DataPropertyName = "Order_Type";
            this.orderTypeDataGridViewTextBoxColumn.HeaderText = "Order_Type";
            this.orderTypeDataGridViewTextBoxColumn.Name = "orderTypeDataGridViewTextBoxColumn";
            this.orderTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.orderTypeDataGridViewTextBoxColumn.Visible = false;
            // 
            // orderNumberDataGridViewTextBoxColumn
            // 
            this.orderNumberDataGridViewTextBoxColumn.DataPropertyName = "Order_Number";
            this.orderNumberDataGridViewTextBoxColumn.HeaderText = "Order_Number";
            this.orderNumberDataGridViewTextBoxColumn.Name = "orderNumberDataGridViewTextBoxColumn";
            this.orderNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.orderNumberDataGridViewTextBoxColumn.Visible = false;
            // 
            // invoiceTypeDataGridViewTextBoxColumn
            // 
            this.invoiceTypeDataGridViewTextBoxColumn.DataPropertyName = "Invoice_Type";
            this.invoiceTypeDataGridViewTextBoxColumn.HeaderText = "Тип накл.";
            this.invoiceTypeDataGridViewTextBoxColumn.Name = "invoiceTypeDataGridViewTextBoxColumn";
            this.invoiceTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // invoiceNumberDataGridViewTextBoxColumn
            // 
            this.invoiceNumberDataGridViewTextBoxColumn.DataPropertyName = "Invoice_Number";
            this.invoiceNumberDataGridViewTextBoxColumn.HeaderText = "№ расх. накладной";
            this.invoiceNumberDataGridViewTextBoxColumn.Name = "invoiceNumberDataGridViewTextBoxColumn";
            this.invoiceNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.invoiceNumberDataGridViewTextBoxColumn.Width = 160;
            // 
            // taxInvoiceNumberDataGridViewTextBoxColumn
            // 
            this.taxInvoiceNumberDataGridViewTextBoxColumn.DataPropertyName = "Tax_Invoice_Number";
            this.taxInvoiceNumberDataGridViewTextBoxColumn.HeaderText = "№ налоговой";
            this.taxInvoiceNumberDataGridViewTextBoxColumn.Name = "taxInvoiceNumberDataGridViewTextBoxColumn";
            this.taxInvoiceNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.taxInvoiceNumberDataGridViewTextBoxColumn.Width = 120;
            // 
            // isInvoiceClosedDataGridViewCheckBoxColumn
            // 
            this.isInvoiceClosedDataGridViewCheckBoxColumn.DataPropertyName = "Is_Invoice_Closed";
            this.isInvoiceClosedDataGridViewCheckBoxColumn.HeaderText = "Is_Invoice_Closed";
            this.isInvoiceClosedDataGridViewCheckBoxColumn.Name = "isInvoiceClosedDataGridViewCheckBoxColumn";
            this.isInvoiceClosedDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isInvoiceClosedDataGridViewCheckBoxColumn.Visible = false;
            // 
            // isScannedDataGridViewCheckBoxColumn
            // 
            this.isScannedDataGridViewCheckBoxColumn.DataPropertyName = "IsScanned";
            this.isScannedDataGridViewCheckBoxColumn.HeaderText = "Отсканировано";
            this.isScannedDataGridViewCheckBoxColumn.Name = "isScannedDataGridViewCheckBoxColumn";
            this.isScannedDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isScannedDataGridViewCheckBoxColumn.Width = 120;
            // 
            // barCodesDataGridViewTextBoxColumn
            // 
            this.barCodesDataGridViewTextBoxColumn.DataPropertyName = "BarCodes";
            this.barCodesDataGridViewTextBoxColumn.HeaderText = "BarCodes";
            this.barCodesDataGridViewTextBoxColumn.Name = "barCodesDataGridViewTextBoxColumn";
            this.barCodesDataGridViewTextBoxColumn.ReadOnly = true;
            this.barCodesDataGridViewTextBoxColumn.Visible = false;
            // 
            // checkInvoicesForCancelBindingSource
            // 
            this.checkInvoicesForCancelBindingSource.DataMember = "CheckInvoicesForCancel";
            this.checkInvoicesForCancelBindingSource.DataSource = this.complaints;
            // 
            // complaints
            // 
            this.complaints.DataSetName = "Complaints";
            this.complaints.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // checkInvoicesForCancelTableAdapter
            // 
            this.checkInvoicesForCancelTableAdapter.ClearBeforeFill = true;
            // 
            // CheckInvoicesForCancelWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 388);
            this.Controls.Add(this.gvLines);
            this.Controls.Add(this.pnlWork);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CheckInvoicesForCancelWindow";
            this.Text = "Проверка аннулируемых накладных по заказу";
            this.Controls.SetChildIndex(this.pnlWork, 0);
            this.Controls.SetChildIndex(this.gvLines, 0);
            this.pnlWork.ResumeLayout(false);
            this.pnlWork.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkInvoicesForCancelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlWork;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Label lblBarcodeCaption;
        private WMSOffice.Controls.TextBoxScaner tbBarcode;
        private System.Windows.Forms.DataGridView gvLines;
        private System.Windows.Forms.ToolStripButton btnCloseDoc;
        private System.Windows.Forms.ToolStripButton btnUndo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem miUndo;
        private System.Windows.Forms.ToolStripMenuItem miCloseDoc;
        private System.Windows.Forms.BindingSource checkInvoicesForCancelBindingSource;
        private WMSOffice.Data.Complaints complaints;
        private WMSOffice.Data.ComplaintsTableAdapters.CheckInvoicesForCancelTableAdapter checkInvoicesForCancelTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn companyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoiceTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoiceNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn taxInvoiceNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isInvoiceClosedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isScannedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn barCodesDataGridViewTextBoxColumn;

    }
}