namespace WMSOffice.Dialogs.Inventory
{
    partial class CountSheetsByInventoryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CountSheetsByInventoryForm));
            this.dgvCountSheets = new System.Windows.Forms.DataGridView();
            this.colDocID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDocType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recalcDocIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iNCountSheetsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.inventory = new WMSOffice.Data.Inventory();
            this.toolStripDoc = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCreate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrintSelected = new System.Windows.Forms.ToolStripButton();
            this.btnPrintPreview = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.Button();
            this.iN_CountSheetsTableAdapter = new WMSOffice.Data.InventoryTableAdapters.IN_CountSheetsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCountSheets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNCountSheetsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventory)).BeginInit();
            this.toolStripDoc.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(4967, 8);
            this.btnOK.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(2969, 8);
            this.btnCancel.Text = "Закрыть";
            // 
            // dgvCountSheets
            // 
            this.dgvCountSheets.AllowUserToAddRows = false;
            this.dgvCountSheets.AllowUserToDeleteRows = false;
            this.dgvCountSheets.AllowUserToOrderColumns = true;
            this.dgvCountSheets.AllowUserToResizeRows = false;
            this.dgvCountSheets.AutoGenerateColumns = false;
            this.dgvCountSheets.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCountSheets.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCountSheets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCountSheets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDocID,
            this.colDocType,
            this.typeNameDataGridViewTextBoxColumn,
            this.recalcDocIDDataGridViewTextBoxColumn,
            this.statusNameDataGridViewTextBoxColumn});
            this.dgvCountSheets.DataSource = this.iNCountSheetsBindingSource;
            this.dgvCountSheets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCountSheets.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCountSheets.Location = new System.Drawing.Point(0, 55);
            this.dgvCountSheets.Name = "dgvCountSheets";
            this.dgvCountSheets.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCountSheets.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCountSheets.RowHeadersVisible = false;
            this.dgvCountSheets.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dgvCountSheets.RowTemplate.Height = 24;
            this.dgvCountSheets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCountSheets.ShowRowErrors = false;
            this.dgvCountSheets.Size = new System.Drawing.Size(977, 423);
            this.dgvCountSheets.TabIndex = 102;
            // 
            // colDocID
            // 
            this.colDocID.DataPropertyName = "Doc_ID";
            this.colDocID.HeaderText = "№";
            this.colDocID.Name = "colDocID";
            this.colDocID.ReadOnly = true;
            this.colDocID.Width = 110;
            // 
            // colDocType
            // 
            this.colDocType.DataPropertyName = "Doc_Type";
            this.colDocType.HeaderText = "Doc_Type";
            this.colDocType.Name = "colDocType";
            this.colDocType.ReadOnly = true;
            this.colDocType.Visible = false;
            // 
            // typeNameDataGridViewTextBoxColumn
            // 
            this.typeNameDataGridViewTextBoxColumn.DataPropertyName = "TypeName";
            this.typeNameDataGridViewTextBoxColumn.HeaderText = "Тип листа";
            this.typeNameDataGridViewTextBoxColumn.Name = "typeNameDataGridViewTextBoxColumn";
            this.typeNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.typeNameDataGridViewTextBoxColumn.Width = 300;
            // 
            // recalcDocIDDataGridViewTextBoxColumn
            // 
            this.recalcDocIDDataGridViewTextBoxColumn.DataPropertyName = "RecalcDoc_ID";
            this.recalcDocIDDataGridViewTextBoxColumn.HeaderText = "№ пересч.";
            this.recalcDocIDDataGridViewTextBoxColumn.Name = "recalcDocIDDataGridViewTextBoxColumn";
            this.recalcDocIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.recalcDocIDDataGridViewTextBoxColumn.Width = 110;
            // 
            // statusNameDataGridViewTextBoxColumn
            // 
            this.statusNameDataGridViewTextBoxColumn.DataPropertyName = "StatusName";
            this.statusNameDataGridViewTextBoxColumn.HeaderText = "Статус";
            this.statusNameDataGridViewTextBoxColumn.Name = "statusNameDataGridViewTextBoxColumn";
            this.statusNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusNameDataGridViewTextBoxColumn.Width = 300;
            // 
            // iNCountSheetsBindingSource
            // 
            this.iNCountSheetsBindingSource.DataMember = "IN_CountSheets";
            this.iNCountSheetsBindingSource.DataSource = this.inventory;
            // 
            // inventory
            // 
            this.inventory.DataSetName = "Inventory";
            this.inventory.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // toolStripDoc
            // 
            this.toolStripDoc.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStripDoc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.toolStripSeparator1,
            this.btnCreate,
            this.toolStripSeparator2,
            this.btnPrintSelected,
            this.btnPrintPreview});
            this.toolStripDoc.Location = new System.Drawing.Point(0, 0);
            this.toolStripDoc.Name = "toolStripDoc";
            this.toolStripDoc.Size = new System.Drawing.Size(977, 55);
            this.toolStripDoc.TabIndex = 101;
            this.toolStripDoc.Text = "Панель инструментов документа";
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(52, 52);
            this.btnRefresh.Text = "Обновить список нераспечатанных накладных";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // btnCreate
            // 
            this.btnCreate.Image = global::WMSOffice.Properties.Resources.document_plain_new;
            this.btnCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(188, 52);
            this.btnCreate.Text = "Создать счетные листы";
            this.btnCreate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // btnPrintSelected
            // 
            this.btnPrintSelected.Image = global::WMSOffice.Properties.Resources.document_print;
            this.btnPrintSelected.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintSelected.Name = "btnPrintSelected";
            this.btnPrintSelected.Size = new System.Drawing.Size(231, 52);
            this.btnPrintSelected.Text = "Напечатать выделенные листы";
            this.btnPrintSelected.Click += new System.EventHandler(this.btnPrintSelected_Click);
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Image = global::WMSOffice.Properties.Resources.document_print_preview;
            this.btnPrintPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(218, 52);
            this.btnPrintPreview.Text = "Предварительный просмотр";
            this.btnPrintPreview.Click += new System.EventHandler(this.btnPrintPreview_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(886, 485);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 103;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // iN_CountSheetsTableAdapter
            // 
            this.iN_CountSheetsTableAdapter.ClearBeforeFill = true;
            // 
            // CountSheetsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(977, 521);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvCountSheets);
            this.Controls.Add(this.toolStripDoc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = true;
            this.Name = "CountSheetsForm";
            this.ShowIcon = true;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Счетные листы инвентаризации";
            this.Controls.SetChildIndex(this.toolStripDoc, 0);
            this.Controls.SetChildIndex(this.dgvCountSheets, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCountSheets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNCountSheetsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventory)).EndInit();
            this.toolStripDoc.ResumeLayout(false);
            this.toolStripDoc.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCountSheets;
        private System.Windows.Forms.ToolStrip toolStripDoc;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnCreate;
        private System.Windows.Forms.BindingSource iNCountSheetsBindingSource;
        private WMSOffice.Data.Inventory inventory;
        private WMSOffice.Data.InventoryTableAdapters.IN_CountSheetsTableAdapter iN_CountSheetsTableAdapter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnPrintSelected;
        private System.Windows.Forms.ToolStripButton btnPrintPreview;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDocID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDocType;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn recalcDocIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusNameDataGridViewTextBoxColumn;
    }
}