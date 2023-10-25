namespace WMSOffice.Window
{
    partial class ReturnsDeliveryWindow
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
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.btnRefreshDoc = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCloseDoc = new System.Windows.Forms.ToolStripButton();
            this.btnCancelDoc = new System.Windows.Forms.ToolStripButton();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.cOMemoDocDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.complaints = new WMSOffice.Data.Complaints();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.tbsItemBarcode = new WMSOffice.Controls.TextBoxScaner();
            this.lblItemBarcode = new System.Windows.Forms.Label();
            this.cO_Memo_DocDetailsTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.CO_Memo_DocDetailsTableAdapter();
            this.orderNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debtorIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debtorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reasonDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reasonIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsMain.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOMemoDocDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).BeginInit();
            this.pnlSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefreshDoc,
            this.toolStripSeparator1,
            this.btnCloseDoc,
            this.btnCancelDoc});
            this.tsMain.Location = new System.Drawing.Point(0, 40);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(949, 39);
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // btnCloseDoc
            // 
            this.btnCloseDoc.Image = global::WMSOffice.Properties.Resources.document_ok;
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
            this.btnCancelDoc.Size = new System.Drawing.Size(122, 36);
            this.btnCancelDoc.Text = "Аннулировать\nдокумент";
            this.btnCancelDoc.Click += new System.EventHandler(this.btnCancelDoc_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.dgvItems);
            this.pnlContent.Controls.Add(this.pnlSearch);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 79);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(949, 309);
            this.pnlContent.TabIndex = 2;
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AllowUserToResizeRows = false;
            this.dgvItems.AutoGenerateColumns = false;
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderNumberDataGridViewTextBoxColumn,
            this.debtorIDDataGridViewTextBoxColumn,
            this.debtorDataGridViewTextBoxColumn,
            this.addressDataGridViewTextBoxColumn,
            this.reasonDataGridViewTextBoxColumn,
            this.reasonIDDataGridViewTextBoxColumn,
            this.statusIDDataGridViewTextBoxColumn});
            this.dgvItems.DataSource = this.cOMemoDocDetailsBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvItems.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItems.Location = new System.Drawing.Point(0, 35);
            this.dgvItems.MultiSelect = false;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(949, 274);
            this.dgvItems.TabIndex = 5;
            this.dgvItems.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvItems_CellFormatting);
            // 
            // cOMemoDocDetailsBindingSource
            // 
            this.cOMemoDocDetailsBindingSource.DataMember = "CO_Memo_DocDetails";
            this.cOMemoDocDetailsBindingSource.DataSource = this.complaints;
            // 
            // complaints
            // 
            this.complaints.DataSetName = "Complaints";
            this.complaints.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.tbsItemBarcode);
            this.pnlSearch.Controls.Add(this.lblItemBarcode);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(949, 35);
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
            // cO_Memo_DocDetailsTableAdapter
            // 
            this.cO_Memo_DocDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // orderNumberDataGridViewTextBoxColumn
            // 
            this.orderNumberDataGridViewTextBoxColumn.DataPropertyName = "OrderNumber";
            this.orderNumberDataGridViewTextBoxColumn.HeaderText = "№ служебной записки";
            this.orderNumberDataGridViewTextBoxColumn.Name = "orderNumberDataGridViewTextBoxColumn";
            this.orderNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.orderNumberDataGridViewTextBoxColumn.Width = 163;
            // 
            // debtorIDDataGridViewTextBoxColumn
            // 
            this.debtorIDDataGridViewTextBoxColumn.DataPropertyName = "DebtorID";
            this.debtorIDDataGridViewTextBoxColumn.HeaderText = "Код дебитора";
            this.debtorIDDataGridViewTextBoxColumn.Name = "debtorIDDataGridViewTextBoxColumn";
            this.debtorIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.debtorIDDataGridViewTextBoxColumn.Width = 113;
            // 
            // debtorDataGridViewTextBoxColumn
            // 
            this.debtorDataGridViewTextBoxColumn.DataPropertyName = "Debtor";
            this.debtorDataGridViewTextBoxColumn.HeaderText = "Наименование дебитора";
            this.debtorDataGridViewTextBoxColumn.Name = "debtorDataGridViewTextBoxColumn";
            this.debtorDataGridViewTextBoxColumn.ReadOnly = true;
            this.debtorDataGridViewTextBoxColumn.Width = 180;
            // 
            // addressDataGridViewTextBoxColumn
            // 
            this.addressDataGridViewTextBoxColumn.DataPropertyName = "Address";
            this.addressDataGridViewTextBoxColumn.HeaderText = "Адрес доставки";
            this.addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
            this.addressDataGridViewTextBoxColumn.ReadOnly = true;
            this.addressDataGridViewTextBoxColumn.Width = 125;
            // 
            // reasonDataGridViewTextBoxColumn
            // 
            this.reasonDataGridViewTextBoxColumn.DataPropertyName = "Reason";
            this.reasonDataGridViewTextBoxColumn.HeaderText = "Причина отклонения";
            this.reasonDataGridViewTextBoxColumn.Name = "reasonDataGridViewTextBoxColumn";
            this.reasonDataGridViewTextBoxColumn.ReadOnly = true;
            this.reasonDataGridViewTextBoxColumn.Width = 156;
            // 
            // reasonIDDataGridViewTextBoxColumn
            // 
            this.reasonIDDataGridViewTextBoxColumn.DataPropertyName = "ReasonID";
            this.reasonIDDataGridViewTextBoxColumn.HeaderText = "Код причины";
            this.reasonIDDataGridViewTextBoxColumn.Name = "reasonIDDataGridViewTextBoxColumn";
            this.reasonIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.reasonIDDataGridViewTextBoxColumn.Width = 107;
            // 
            // statusIDDataGridViewTextBoxColumn
            // 
            this.statusIDDataGridViewTextBoxColumn.DataPropertyName = "StatusID";
            this.statusIDDataGridViewTextBoxColumn.HeaderText = "Статус";
            this.statusIDDataGridViewTextBoxColumn.Name = "statusIDDataGridViewTextBoxColumn";
            this.statusIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusIDDataGridViewTextBoxColumn.Width = 79;
            // 
            // ReturnsDeliveryWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 388);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.tsMain);
            this.Name = "ReturnsDeliveryWindow";
            this.Text = "ReturnsDeliveryWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReturnsDeliveryWindow_FormClosing);
            this.Controls.SetChildIndex(this.tsMain, 0);
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOMemoDocDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btnRefreshDoc;
        private System.Windows.Forms.ToolStripButton btnCloseDoc;
        private System.Windows.Forms.ToolStripButton btnCancelDoc;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.Panel pnlSearch;
        private WMSOffice.Controls.TextBoxScaner tbsItemBarcode;
        private System.Windows.Forms.Label lblItemBarcode;
        private System.Windows.Forms.BindingSource cOMemoDocDetailsBindingSource;
        private WMSOffice.Data.Complaints complaints;
        private WMSOffice.Data.ComplaintsTableAdapters.CO_Memo_DocDetailsTableAdapter cO_Memo_DocDetailsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn debtorIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn debtorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reasonDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reasonIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusIDDataGridViewTextBoxColumn;
    }
}