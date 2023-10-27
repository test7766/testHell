namespace WMSOffice.Dialogs.Delivery
{
    partial class ReceiptDebtorsReturnedTareTransitCheckInvoiceForm
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlAdditionalOptions = new System.Windows.Forms.Panel();
            this.tbsTareInvoice = new WMSOffice.Controls.TextBoxScaner();
            this.lblScanTareInvoice = new System.Windows.Forms.Label();
            this.dgvTareInvoice = new System.Windows.Forms.DataGridView();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblScannedInvoicesQtty = new System.Windows.Forms.Label();
            this.lblScannedItems = new System.Windows.Forms.Label();
            this.delivery = new WMSOffice.Data.Delivery();
            this.checkTareInvoiceTransitReturnByRouteListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.checkTareInvoiceTransitReturnByRouteListTableAdapter = new WMSOffice.Data.DeliveryTableAdapters.CheckTareInvoiceTransitReturnByRouteListTableAdapter();
            this.cTdocDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTdctDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlButtons.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTareInvoice)).BeginInit();
            this.pnlFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.delivery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkTareInvoiceTransitReturnByRouteListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(8165, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(8255, 8);
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
            this.pnlHeader.Controls.Add(this.tbsTareInvoice);
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
            // tbsTareInvoice
            // 
            this.tbsTareInvoice.AllowType = true;
            this.tbsTareInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbsTareInvoice.AutoConvert = true;
            this.tbsTareInvoice.DelayThreshold = 50;
            this.tbsTareInvoice.Location = new System.Drawing.Point(147, 13);
            this.tbsTareInvoice.Name = "tbsTareInvoice";
            this.tbsTareInvoice.RaiseTextChangeWithoutEnter = false;
            this.tbsTareInvoice.ReadOnly = false;
            this.tbsTareInvoice.ScannerListener = null;
            this.tbsTareInvoice.Size = new System.Drawing.Size(635, 25);
            this.tbsTareInvoice.TabIndex = 1;
            this.tbsTareInvoice.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.tbsTareInvoice.UseParentFont = false;
            this.tbsTareInvoice.UseScanModeOnly = false;
            // 
            // lblScanTareInvoice
            // 
            this.lblScanTareInvoice.AutoSize = true;
            this.lblScanTareInvoice.Location = new System.Drawing.Point(12, 19);
            this.lblScanTareInvoice.Name = "lblScanTareInvoice";
            this.lblScanTareInvoice.Size = new System.Drawing.Size(129, 13);
            this.lblScanTareInvoice.TabIndex = 0;
            this.lblScanTareInvoice.Text = "Отсканируйте ш/к акта:";
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
            this.dgvTareInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTareInvoice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cTdocDataGridViewTextBoxColumn,
            this.cTdctDataGridViewTextBoxColumn});
            this.dgvTareInvoice.DataSource = this.checkTareInvoiceTransitReturnByRouteListBindingSource;
            this.dgvTareInvoice.Location = new System.Drawing.Point(0, 56);
            this.dgvTareInvoice.MultiSelect = false;
            this.dgvTareInvoice.Name = "dgvTareInvoice";
            this.dgvTareInvoice.ReadOnly = true;
            this.dgvTareInvoice.RowHeadersVisible = false;
            this.dgvTareInvoice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTareInvoice.Size = new System.Drawing.Size(794, 341);
            this.dgvTareInvoice.TabIndex = 1;
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
            this.lblScannedInvoicesQtty.Location = new System.Drawing.Point(161, 4);
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
            this.lblScannedItems.Size = new System.Drawing.Size(141, 13);
            this.lblScannedItems.TabIndex = 0;
            this.lblScannedItems.Text = "Отсканировано актов:";
            // 
            // delivery
            // 
            this.delivery.DataSetName = "Delivery";
            this.delivery.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // checkTareInvoiceTransitReturnByRouteListBindingSource
            // 
            this.checkTareInvoiceTransitReturnByRouteListBindingSource.DataMember = "CheckTareInvoiceTransitReturnByRouteList";
            this.checkTareInvoiceTransitReturnByRouteListBindingSource.DataSource = this.delivery;
            // 
            // checkTareInvoiceTransitReturnByRouteListTableAdapter
            // 
            this.checkTareInvoiceTransitReturnByRouteListTableAdapter.ClearBeforeFill = true;
            // 
            // cTdocDataGridViewTextBoxColumn
            // 
            this.cTdocDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cTdocDataGridViewTextBoxColumn.DataPropertyName = "CT_doc";
            this.cTdocDataGridViewTextBoxColumn.HeaderText = "№ документа";
            this.cTdocDataGridViewTextBoxColumn.Name = "cTdocDataGridViewTextBoxColumn";
            this.cTdocDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cTdctDataGridViewTextBoxColumn
            // 
            this.cTdctDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cTdctDataGridViewTextBoxColumn.DataPropertyName = "CT_dct";
            this.cTdctDataGridViewTextBoxColumn.HeaderText = "Тип документа";
            this.cTdctDataGridViewTextBoxColumn.Name = "cTdctDataGridViewTextBoxColumn";
            this.cTdctDataGridViewTextBoxColumn.ReadOnly = true;
            this.cTdctDataGridViewTextBoxColumn.Width = 99;
            // 
            // ReceiptDebtorsReturnedTareTransitCheckInvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 471);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.dgvTareInvoice);
            this.Name = "ReceiptDebtorsReturnedTareTransitCheckInvoiceForm";
            this.Text = "Проверка актов приема-передачи транзитной клиентской оборотной тары перед сдачей";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReceiptDebtorsReturnedTareForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.dgvTareInvoice, 0);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.Controls.SetChildIndex(this.pnlFooter, 0);
            this.pnlButtons.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTareInvoice)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.delivery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkTareInvoiceTransitReturnByRouteListBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private WMSOffice.Controls.TextBoxScaner tbsTareInvoice;
        private System.Windows.Forms.Label lblScanTareInvoice;
        private System.Windows.Forms.DataGridView dgvTareInvoice;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblScannedInvoicesQtty;
        private System.Windows.Forms.Label lblScannedItems;
        private System.Windows.Forms.Panel pnlAdditionalOptions;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTdocDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTdctDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource checkTareInvoiceTransitReturnByRouteListBindingSource;
        private WMSOffice.Data.Delivery delivery;
        private WMSOffice.Data.DeliveryTableAdapters.CheckTareInvoiceTransitReturnByRouteListTableAdapter checkTareInvoiceTransitReturnByRouteListTableAdapter;
    }
}