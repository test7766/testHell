namespace WMSOffice.Dialogs.Delivery
{
    partial class ReceiptDebtorsReturnedTareTransitForm
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlAdditionalOptions = new System.Windows.Forms.Panel();
            this.tbsTare = new WMSOffice.Controls.TextBoxScaner();
            this.lblScanTareInvoice = new System.Windows.Forms.Label();
            this.dgvTareInvoice = new System.Windows.Forms.DataGridView();
            this.tareTransitReturnByRouteListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.delivery = new WMSOffice.Data.Delivery();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblScannedInvoicesQtty = new System.Windows.Forms.Label();
            this.lblScannedItems = new System.Windows.Forms.Label();
            this.tareTransitReturnByRouteListTableAdapter = new WMSOffice.Data.DeliveryTableAdapters.TareTransitReturnByRouteListTableAdapter();
            this.barcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date_updated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlButtons.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTareInvoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tareTransitReturnByRouteListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.delivery)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(9941, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(10031, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 428);
            this.pnlButtons.Size = new System.Drawing.Size(794, 43);
            this.pnlButtons.TabIndex = 2;
            // 
            // pnlHeader
            // 
            this.pnlHeader.AutoSize = true;
            this.pnlHeader.Controls.Add(this.pnlAdditionalOptions);
            this.pnlHeader.Controls.Add(this.tbsTare);
            this.pnlHeader.Controls.Add(this.lblScanTareInvoice);
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(794, 50);
            this.pnlHeader.TabIndex = 0;
            // 
            // pnlAdditionalOptions
            // 
            this.pnlAdditionalOptions.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlAdditionalOptions.Location = new System.Drawing.Point(794, 0);
            this.pnlAdditionalOptions.Name = "pnlAdditionalOptions";
            this.pnlAdditionalOptions.Size = new System.Drawing.Size(0, 50);
            this.pnlAdditionalOptions.TabIndex = 2;
            // 
            // tbsTare
            // 
            this.tbsTare.AllowType = true;
            this.tbsTare.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbsTare.AutoConvert = true;
            this.tbsTare.DelayThreshold = 50;
            this.tbsTare.Location = new System.Drawing.Point(205, 13);
            this.tbsTare.Name = "tbsTare";
            this.tbsTare.RaiseTextChangeWithoutEnter = false;
            this.tbsTare.ReadOnly = false;
            this.tbsTare.ScannerListener = null;
            this.tbsTare.Size = new System.Drawing.Size(577, 25);
            this.tbsTare.TabIndex = 1;
            this.tbsTare.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.tbsTare.UseParentFont = false;
            this.tbsTare.UseScanModeOnly = false;
            // 
            // lblScanTareInvoice
            // 
            this.lblScanTareInvoice.AutoSize = true;
            this.lblScanTareInvoice.Location = new System.Drawing.Point(12, 19);
            this.lblScanTareInvoice.Name = "lblScanTareInvoice";
            this.lblScanTareInvoice.Size = new System.Drawing.Size(187, 13);
            this.lblScanTareInvoice.TabIndex = 0;
            this.lblScanTareInvoice.Text = "Отсканируйте ш/к оборотной тары:";
            // 
            // dgvTareInvoice
            // 
            this.dgvTareInvoice.AllowUserToAddRows = false;
            this.dgvTareInvoice.AllowUserToDeleteRows = false;
            this.dgvTareInvoice.AllowUserToResizeColumns = false;
            this.dgvTareInvoice.AllowUserToResizeRows = false;
            this.dgvTareInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTareInvoice.AutoGenerateColumns = false;
            this.dgvTareInvoice.ColumnHeadersHeight = 25;
            this.dgvTareInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTareInvoice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.barcodeDataGridViewTextBoxColumn,
            this.typeDescriptionDataGridViewTextBoxColumn,
            this.Date_updated});
            this.dgvTareInvoice.DataSource = this.tareTransitReturnByRouteListBindingSource;
            this.dgvTareInvoice.Location = new System.Drawing.Point(0, 56);
            this.dgvTareInvoice.MultiSelect = false;
            this.dgvTareInvoice.Name = "dgvTareInvoice";
            this.dgvTareInvoice.ReadOnly = true;
            this.dgvTareInvoice.RowHeadersVisible = false;
            this.dgvTareInvoice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTareInvoice.Size = new System.Drawing.Size(794, 341);
            this.dgvTareInvoice.TabIndex = 1;
            this.dgvTareInvoice.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvTareInvoice_CellFormatting);
            this.dgvTareInvoice.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvTareInvoice_DataBindingComplete);
            // 
            // tareTransitReturnByRouteListBindingSource
            // 
            this.tareTransitReturnByRouteListBindingSource.DataMember = "TareTransitReturnByRouteList";
            this.tareTransitReturnByRouteListBindingSource.DataSource = this.delivery;
            // 
            // delivery
            // 
            this.delivery.DataSetName = "Delivery";
            this.delivery.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.SystemColors.Info;
            this.pnlFooter.Controls.Add(this.lblScannedInvoicesQtty);
            this.pnlFooter.Controls.Add(this.lblScannedItems);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 403);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(794, 25);
            this.pnlFooter.TabIndex = 3;
            // 
            // lblScannedInvoicesQtty
            // 
            this.lblScannedInvoicesQtty.AutoSize = true;
            this.lblScannedInvoicesQtty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblScannedInvoicesQtty.ForeColor = System.Drawing.Color.Blue;
            this.lblScannedInvoicesQtty.Location = new System.Drawing.Point(220, 4);
            this.lblScannedInvoicesQtty.Name = "lblScannedInvoicesQtty";
            this.lblScannedInvoicesQtty.Size = new System.Drawing.Size(16, 16);
            this.lblScannedInvoicesQtty.TabIndex = 1;
            this.lblScannedInvoicesQtty.Text = "0";
            // 
            // lblScannedItems
            // 
            this.lblScannedItems.AutoSize = true;
            this.lblScannedItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblScannedItems.Location = new System.Drawing.Point(12, 6);
            this.lblScannedItems.Name = "lblScannedItems";
            this.lblScannedItems.Size = new System.Drawing.Size(202, 13);
            this.lblScannedItems.TabIndex = 0;
            this.lblScannedItems.Text = "Отсканировано оборотной тары:";
            // 
            // tareTransitReturnByRouteListTableAdapter
            // 
            this.tareTransitReturnByRouteListTableAdapter.ClearBeforeFill = true;
            // 
            // barcodeDataGridViewTextBoxColumn
            // 
            this.barcodeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.barcodeDataGridViewTextBoxColumn.DataPropertyName = "Bar_code";
            this.barcodeDataGridViewTextBoxColumn.HeaderText = "Ш/К";
            this.barcodeDataGridViewTextBoxColumn.Name = "barcodeDataGridViewTextBoxColumn";
            this.barcodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.barcodeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.barcodeDataGridViewTextBoxColumn.Width = 34;
            // 
            // typeDescriptionDataGridViewTextBoxColumn
            // 
            this.typeDescriptionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.typeDescriptionDataGridViewTextBoxColumn.DataPropertyName = "Type_Description";
            this.typeDescriptionDataGridViewTextBoxColumn.HeaderText = "Тип тары";
            this.typeDescriptionDataGridViewTextBoxColumn.Name = "typeDescriptionDataGridViewTextBoxColumn";
            this.typeDescriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.typeDescriptionDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.typeDescriptionDataGridViewTextBoxColumn.Width = 60;
            // 
            // Date_updated
            // 
            this.Date_updated.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Date_updated.DataPropertyName = "Date_updated";
            dataGridViewCellStyle1.Format = "G";
            dataGridViewCellStyle1.NullValue = null;
            this.Date_updated.DefaultCellStyle = dataGridViewCellStyle1;
            this.Date_updated.HeaderText = "Время обработки";
            this.Date_updated.Name = "Date_updated";
            this.Date_updated.ReadOnly = true;
            this.Date_updated.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Date_updated.Width = 102;
            // 
            // ReceiptDebtorsReturnedTareTransitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 471);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.dgvTareInvoice);
            this.Name = "ReceiptDebtorsReturnedTareTransitForm";
            this.Text = "Сдача транзитной клиентской оборотной тары";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReceiptDebtorsReturnedTareForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.dgvTareInvoice, 0);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.Controls.SetChildIndex(this.pnlFooter, 0);
            this.pnlButtons.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTareInvoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tareTransitReturnByRouteListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.delivery)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private WMSOffice.Controls.TextBoxScaner tbsTare;
        private System.Windows.Forms.Label lblScanTareInvoice;
        private System.Windows.Forms.DataGridView dgvTareInvoice;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblScannedInvoicesQtty;
        private System.Windows.Forms.Label lblScannedItems;
        private System.Windows.Forms.Panel pnlAdditionalOptions;
        private System.Windows.Forms.BindingSource tareTransitReturnByRouteListBindingSource;
        private WMSOffice.Data.Delivery delivery;
        private WMSOffice.Data.DeliveryTableAdapters.TareTransitReturnByRouteListTableAdapter tareTransitReturnByRouteListTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date_updated;
    }
}