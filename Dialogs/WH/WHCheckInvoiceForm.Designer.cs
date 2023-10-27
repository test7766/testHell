namespace WMSOffice.Dialogs.WH
{
    partial class WHCheckInvoiceForm
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
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.lblStatistics = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblAction = new System.Windows.Forms.Label();
            this.tbScaner = new WMSOffice.Controls.TextBoxScaner();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.checkInvoiceDocsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wH = new WMSOffice.Data.WH();
            this.checkInvoiceDocsTableAdapter = new WMSOffice.Data.WHTableAdapters.CheckInvoiceDocsTableAdapter();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcIsChecked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.line_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doc_kind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documentidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documenttypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debtor_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PromoCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlOptions.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkInvoiceDocsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlOptions
            // 
            this.pnlOptions.Controls.Add(this.lblStatistics);
            this.pnlOptions.Controls.Add(this.btnPrint);
            this.pnlOptions.Controls.Add(this.btnClose);
            this.pnlOptions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlOptions.Location = new System.Drawing.Point(0, 676);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(1034, 35);
            this.pnlOptions.TabIndex = 1;
            // 
            // lblStatistics
            // 
            this.lblStatistics.AutoSize = true;
            this.lblStatistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStatistics.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblStatistics.Location = new System.Drawing.Point(3, 9);
            this.lblStatistics.Name = "lblStatistics";
            this.lblStatistics.Size = new System.Drawing.Size(241, 16);
            this.lblStatistics.TabIndex = 2;
            this.lblStatistics.Text = "Документов обработано: 0 из 0";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(875, 6);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "Печать";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(956, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblAction);
            this.pnlHeader.Controls.Add(this.tbScaner);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1034, 50);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblAction
            // 
            this.lblAction.AutoSize = true;
            this.lblAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAction.Location = new System.Drawing.Point(3, 9);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(274, 16);
            this.lblAction.TabIndex = 1;
            this.lblAction.Text = "Введите номер маршрутного листа:";
            // 
            // tbScaner
            // 
            this.tbScaner.AllowType = true;
            this.tbScaner.AutoConvert = true;
            this.tbScaner.DelayThreshold = 50;
            this.tbScaner.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbScaner.Location = new System.Drawing.Point(0, 25);
            this.tbScaner.Name = "tbScaner";
            this.tbScaner.RaiseTextChangeWithoutEnter = false;
            this.tbScaner.ReadOnly = false;
            this.tbScaner.ScannerListener = null;
            this.tbScaner.Size = new System.Drawing.Size(1034, 25);
            this.tbScaner.TabIndex = 0;
            this.tbScaner.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.tbScaner.UseParentFont = false;
            this.tbScaner.UseScanModeOnly = false;
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AllowUserToResizeColumns = false;
            this.dgvItems.AllowUserToResizeRows = false;
            this.dgvItems.AutoGenerateColumns = false;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcIsChecked,
            this.line_id,
            this.doc_kind,
            this.documentidDataGridViewTextBoxColumn,
            this.documenttypeDataGridViewTextBoxColumn,
            this.statusidDataGridViewTextBoxColumn,
            this.Status_name,
            this.debtor_name,
            this.PromoCode});
            this.dgvItems.DataSource = this.checkInvoiceDocsBindingSource;
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItems.Location = new System.Drawing.Point(0, 50);
            this.dgvItems.MultiSelect = false;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(1034, 626);
            this.dgvItems.TabIndex = 2;
            this.dgvItems.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvItems_CellFormatting);
            this.dgvItems.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvItems_CurrentCellDirtyStateChanged);
            // 
            // checkInvoiceDocsBindingSource
            // 
            this.checkInvoiceDocsBindingSource.DataMember = "CheckInvoiceDocs";
            this.checkInvoiceDocsBindingSource.DataSource = this.wH;
            // 
            // wH
            // 
            this.wH.DataSetName = "WH";
            this.wH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // checkInvoiceDocsTableAdapter
            // 
            this.checkInvoiceDocsTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "isChecked";
            this.dataGridViewCheckBoxColumn1.HeaderText = "Отм.";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Width = 35;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "document_id";
            this.dataGridViewTextBoxColumn1.HeaderText = "№ накл.";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "document_type";
            this.dataGridViewTextBoxColumn2.HeaderText = "Тип накл.";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "status_id";
            this.dataGridViewTextBoxColumn3.HeaderText = "Статус";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "status_id";
            this.dataGridViewTextBoxColumn4.HeaderText = "Статус";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Status_name";
            this.dataGridViewTextBoxColumn5.HeaderText = "Название статуса";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "debtor_name";
            this.dataGridViewTextBoxColumn6.HeaderText = "Клиент";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dgvcIsChecked
            // 
            this.dgvcIsChecked.DataPropertyName = "isChecked";
            this.dgvcIsChecked.HeaderText = "Отм.";
            this.dgvcIsChecked.Name = "dgvcIsChecked";
            this.dgvcIsChecked.Width = 35;
            // 
            // line_id
            // 
            this.line_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.line_id.DataPropertyName = "line_id";
            this.line_id.HeaderText = "№ п/п";
            this.line_id.Name = "line_id";
            this.line_id.ReadOnly = true;
            this.line_id.Width = 63;
            // 
            // doc_kind
            // 
            this.doc_kind.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.doc_kind.DataPropertyName = "doc_kind";
            this.doc_kind.HeaderText = "Вид док.";
            this.doc_kind.Name = "doc_kind";
            this.doc_kind.ReadOnly = true;
            this.doc_kind.Width = 75;
            // 
            // documentidDataGridViewTextBoxColumn
            // 
            this.documentidDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.documentidDataGridViewTextBoxColumn.DataPropertyName = "document_id";
            this.documentidDataGridViewTextBoxColumn.HeaderText = "№ док.";
            this.documentidDataGridViewTextBoxColumn.Name = "documentidDataGridViewTextBoxColumn";
            this.documentidDataGridViewTextBoxColumn.ReadOnly = true;
            this.documentidDataGridViewTextBoxColumn.Width = 67;
            // 
            // documenttypeDataGridViewTextBoxColumn
            // 
            this.documenttypeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.documenttypeDataGridViewTextBoxColumn.DataPropertyName = "document_type";
            this.documenttypeDataGridViewTextBoxColumn.HeaderText = "Тип док.";
            this.documenttypeDataGridViewTextBoxColumn.Name = "documenttypeDataGridViewTextBoxColumn";
            this.documenttypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.documenttypeDataGridViewTextBoxColumn.Width = 75;
            // 
            // statusidDataGridViewTextBoxColumn
            // 
            this.statusidDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.statusidDataGridViewTextBoxColumn.DataPropertyName = "status_id";
            this.statusidDataGridViewTextBoxColumn.HeaderText = "Статус";
            this.statusidDataGridViewTextBoxColumn.Name = "statusidDataGridViewTextBoxColumn";
            this.statusidDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusidDataGridViewTextBoxColumn.Width = 66;
            // 
            // Status_name
            // 
            this.Status_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Status_name.DataPropertyName = "Status_name";
            this.Status_name.HeaderText = "Название статуса";
            this.Status_name.Name = "Status_name";
            this.Status_name.ReadOnly = true;
            this.Status_name.Width = 124;
            // 
            // debtor_name
            // 
            this.debtor_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.debtor_name.DataPropertyName = "debtor_name";
            this.debtor_name.HeaderText = "Торговая точка";
            this.debtor_name.Name = "debtor_name";
            this.debtor_name.ReadOnly = true;
            this.debtor_name.Width = 111;
            // 
            // PromoCode
            // 
            this.PromoCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PromoCode.DataPropertyName = "PromoCode";
            this.PromoCode.HeaderText = "Промо-код";
            this.PromoCode.Name = "PromoCode";
            this.PromoCode.ReadOnly = true;
            this.PromoCode.Width = 87;
            // 
            // WHCheckInvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1034, 711);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlOptions);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WHCheckInvoiceForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Проверка накладных";
            this.pnlOptions.ResumeLayout(false);
            this.pnlOptions.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkInvoiceDocsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.DataGridView dgvItems;
        private WMSOffice.Controls.TextBoxScaner tbScaner;
        private System.Windows.Forms.Label lblAction;
        private System.Windows.Forms.BindingSource checkInvoiceDocsBindingSource;
        private WMSOffice.Data.WH wH;
        private WMSOffice.Data.WHTableAdapters.CheckInvoiceDocsTableAdapter checkInvoiceDocsTableAdapter;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Label lblStatistics;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvcIsChecked;
        private System.Windows.Forms.DataGridViewTextBoxColumn line_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn doc_kind;
        private System.Windows.Forms.DataGridViewTextBoxColumn documentidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn documenttypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn debtor_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn PromoCode;
    }
}