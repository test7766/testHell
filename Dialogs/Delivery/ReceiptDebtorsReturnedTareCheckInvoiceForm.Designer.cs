namespace WMSOffice.Dialogs.Delivery
{
    partial class ReceiptDebtorsReturnedTareCheckInvoiceForm
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
            this.tsAdditionalOptions = new System.Windows.Forms.ToolStrip();
            this.btnSetNotVisitedReasons = new System.Windows.Forms.ToolStripButton();
            this.tbsTareInvoice = new WMSOffice.Controls.TextBoxScaner();
            this.lblScanTareInvoice = new System.Windows.Forms.Label();
            this.dgvTareInvoice = new System.Windows.Forms.DataGridView();
            this.cTdocDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTdctDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkTareInvoiceReturnByRouteListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.delivery = new WMSOffice.Data.Delivery();
            this.checkTareInvoiceReturnByRouteListTableAdapter = new WMSOffice.Data.DeliveryTableAdapters.CheckTareInvoiceReturnByRouteListTableAdapter();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblScannedInvoicesQtty = new System.Windows.Forms.Label();
            this.lblScannedItems = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlAdditionalOptions.SuspendLayout();
            this.tsAdditionalOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTareInvoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkTareInvoiceReturnByRouteListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.delivery)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(7721, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(7811, 8);
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
            this.pnlAdditionalOptions.Controls.Add(this.tsAdditionalOptions);
            this.pnlAdditionalOptions.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlAdditionalOptions.Location = new System.Drawing.Point(644, 0);
            this.pnlAdditionalOptions.Name = "pnlAdditionalOptions";
            this.pnlAdditionalOptions.Size = new System.Drawing.Size(150, 50);
            this.pnlAdditionalOptions.TabIndex = 2;
            // 
            // tsAdditionalOptions
            // 
            this.tsAdditionalOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsAdditionalOptions.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsAdditionalOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSetNotVisitedReasons});
            this.tsAdditionalOptions.Location = new System.Drawing.Point(0, 0);
            this.tsAdditionalOptions.Name = "tsAdditionalOptions";
            this.tsAdditionalOptions.Size = new System.Drawing.Size(150, 50);
            this.tsAdditionalOptions.TabIndex = 0;
            this.tsAdditionalOptions.Text = "toolStrip1";
            // 
            // btnSetNotVisitedReasons
            // 
            this.btnSetNotVisitedReasons.Image = global::WMSOffice.Properties.Resources.assign;
            this.btnSetNotVisitedReasons.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSetNotVisitedReasons.Name = "btnSetNotVisitedReasons";
            this.btnSetNotVisitedReasons.Size = new System.Drawing.Size(119, 47);
            this.btnSetNotVisitedReasons.Text = "Причины\nнепосещения";
            this.btnSetNotVisitedReasons.Click += new System.EventHandler(this.btnSetNotVisitedReasons_Click);
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
            this.tbsTareInvoice.Size = new System.Drawing.Size(485, 25);
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
            this.dgvTareInvoice.DataSource = this.checkTareInvoiceReturnByRouteListBindingSource;
            this.dgvTareInvoice.Location = new System.Drawing.Point(0, 56);
            this.dgvTareInvoice.MultiSelect = false;
            this.dgvTareInvoice.Name = "dgvTareInvoice";
            this.dgvTareInvoice.ReadOnly = true;
            this.dgvTareInvoice.RowHeadersVisible = false;
            this.dgvTareInvoice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTareInvoice.Size = new System.Drawing.Size(794, 341);
            this.dgvTareInvoice.TabIndex = 1;
            this.dgvTareInvoice.SelectionChanged += new System.EventHandler(this.dgvTareInvoice_SelectionChanged);
            // 
            // cTdocDataGridViewTextBoxColumn
            // 
            this.cTdocDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cTdocDataGridViewTextBoxColumn.DataPropertyName = "CT_doc";
            this.cTdocDataGridViewTextBoxColumn.HeaderText = "№ документа";
            this.cTdocDataGridViewTextBoxColumn.Name = "cTdocDataGridViewTextBoxColumn";
            this.cTdocDataGridViewTextBoxColumn.ReadOnly = true;
            this.cTdocDataGridViewTextBoxColumn.Width = 92;
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
            // checkTareInvoiceReturnByRouteListBindingSource
            // 
            this.checkTareInvoiceReturnByRouteListBindingSource.DataMember = "CheckTareInvoiceReturnByRouteList";
            this.checkTareInvoiceReturnByRouteListBindingSource.DataSource = this.delivery;
            // 
            // delivery
            // 
            this.delivery.DataSetName = "Delivery";
            this.delivery.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // checkTareInvoiceReturnByRouteListTableAdapter
            // 
            this.checkTareInvoiceReturnByRouteListTableAdapter.ClearBeforeFill = true;
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
            // ReceiptDebtorsReturnedTareCheckInvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 471);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.dgvTareInvoice);
            this.Name = "ReceiptDebtorsReturnedTareCheckInvoiceForm";
            this.Text = "Проверка актов приема-передачи клиентской оборотной тары перед сдачей";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReceiptDebtorsReturnedTareForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.dgvTareInvoice, 0);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.Controls.SetChildIndex(this.pnlFooter, 0);
            this.pnlButtons.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlAdditionalOptions.ResumeLayout(false);
            this.pnlAdditionalOptions.PerformLayout();
            this.tsAdditionalOptions.ResumeLayout(false);
            this.tsAdditionalOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTareInvoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkTareInvoiceReturnByRouteListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.delivery)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private WMSOffice.Controls.TextBoxScaner tbsTareInvoice;
        private System.Windows.Forms.Label lblScanTareInvoice;
        private System.Windows.Forms.DataGridView dgvTareInvoice;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTdocDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTdctDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource checkTareInvoiceReturnByRouteListBindingSource;
        private Data.Delivery delivery;
        private Data.DeliveryTableAdapters.CheckTareInvoiceReturnByRouteListTableAdapter checkTareInvoiceReturnByRouteListTableAdapter;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblScannedInvoicesQtty;
        private System.Windows.Forms.Label lblScannedItems;
        private System.Windows.Forms.Panel pnlAdditionalOptions;
        private System.Windows.Forms.ToolStrip tsAdditionalOptions;
        private System.Windows.Forms.ToolStripButton btnSetNotVisitedReasons;
    }
}