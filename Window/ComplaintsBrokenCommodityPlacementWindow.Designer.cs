namespace WMSOffice.Window
{
    partial class ComplaintsBrokenCommodityPlacementWindow
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
            this.sbReloadData = new System.Windows.Forms.ToolStripButton();
            this.sbAssignSSCC = new System.Windows.Forms.ToolStripButton();
            this.sbCloseDoc = new System.Windows.Forms.ToolStripButton();
            this.sbCancelDoc = new System.Windows.Forms.ToolStripButton();
            this.slDocDetailsSummary = new System.Windows.Forms.ToolStripLabel();
            this.ssSummary = new System.Windows.Forms.ToolStripSeparator();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.dgvRemains = new System.Windows.Forms.DataGridView();
            this.IsChecked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.itemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batchIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lifeTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOBMGetRemainsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.complaints = new WMSOffice.Data.Complaints();
            this.cO_BM_Get_RemainsTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.CO_BM_Get_RemainsTableAdapter();
            this.tsMain.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemains)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOBMGetRemainsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbReloadData,
            this.sbAssignSSCC,
            this.sbCloseDoc,
            this.sbCancelDoc,
            this.slDocDetailsSummary,
            this.ssSummary});
            this.tsMain.Location = new System.Drawing.Point(0, 40);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1284, 55);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
            // 
            // sbReloadData
            // 
            this.sbReloadData.Image = global::WMSOffice.Properties.Resources.refresh;
            this.sbReloadData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbReloadData.Name = "sbReloadData";
            this.sbReloadData.Size = new System.Drawing.Size(116, 52);
            this.sbReloadData.Text = " Загрузить\nостаток";
            this.sbReloadData.Click += new System.EventHandler(this.sbReloadData_Click);
            // 
            // sbAssignSSCC
            // 
            this.sbAssignSSCC.Image = global::WMSOffice.Properties.Resources.barcode;
            this.sbAssignSSCC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbAssignSSCC.Name = "sbAssignSSCC";
            this.sbAssignSSCC.Size = new System.Drawing.Size(116, 52);
            this.sbAssignSSCC.Text = "Привязать\nSSCC";
            this.sbAssignSSCC.Click += new System.EventHandler(this.sbAssignSSCC_Click);
            // 
            // sbCloseDoc
            // 
            this.sbCloseDoc.Image = global::WMSOffice.Properties.Resources.finish_process;
            this.sbCloseDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbCloseDoc.Name = "sbCloseDoc";
            this.sbCloseDoc.Size = new System.Drawing.Size(111, 52);
            this.sbCloseDoc.Text = "Закрыть\nдокумент";
            this.sbCloseDoc.Click += new System.EventHandler(this.sbCloseDoc_Click);
            // 
            // sbCancelDoc
            // 
            this.sbCancelDoc.Image = global::WMSOffice.Properties.Resources.symbol_stop;
            this.sbCancelDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbCancelDoc.Name = "sbCancelDoc";
            this.sbCancelDoc.Size = new System.Drawing.Size(113, 52);
            this.sbCancelDoc.Text = "Отменить\nдокумент";
            this.sbCancelDoc.Click += new System.EventHandler(this.sbCancelDoc_Click);
            // 
            // slDocDetailsSummary
            // 
            this.slDocDetailsSummary.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.slDocDetailsSummary.IsLink = true;
            this.slDocDetailsSummary.Name = "slDocDetailsSummary";
            this.slDocDetailsSummary.Size = new System.Drawing.Size(66, 52);
            this.slDocDetailsSummary.Text = "Отм. 0 из 0";
            // 
            // ssSummary
            // 
            this.ssSummary.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ssSummary.Name = "ssSummary";
            this.ssSummary.Size = new System.Drawing.Size(6, 55);
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.dgvRemains);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 95);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1284, 388);
            this.pnlContent.TabIndex = 2;
            // 
            // dgvRemains
            // 
            this.dgvRemains.AllowUserToAddRows = false;
            this.dgvRemains.AllowUserToDeleteRows = false;
            this.dgvRemains.AllowUserToResizeRows = false;
            this.dgvRemains.AutoGenerateColumns = false;
            this.dgvRemains.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRemains.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IsChecked,
            this.itemIDDataGridViewTextBoxColumn,
            this.itemNameDataGridViewTextBoxColumn,
            this.batchIDDataGridViewTextBoxColumn,
            this.lotNumberDataGridViewTextBoxColumn,
            this.locationIDDataGridViewTextBoxColumn,
            this.Department,
            this.EmployeeName,
            this.qtyDataGridViewTextBoxColumn,
            this.DocQty,
            this.lifeTimeDataGridViewTextBoxColumn});
            this.dgvRemains.DataSource = this.cOBMGetRemainsBindingSource;
            this.dgvRemains.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRemains.Location = new System.Drawing.Point(0, 0);
            this.dgvRemains.MultiSelect = false;
            this.dgvRemains.Name = "dgvRemains";
            this.dgvRemains.RowHeadersVisible = false;
            this.dgvRemains.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRemains.Size = new System.Drawing.Size(1284, 388);
            this.dgvRemains.TabIndex = 0;
            this.dgvRemains.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRemains_CellValueChanged);
            this.dgvRemains.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvRemains_CellFormatting);
            this.dgvRemains.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvRemains_CurrentCellDirtyStateChanged);
            this.dgvRemains.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvRemains_DataError);
            // 
            // IsChecked
            // 
            this.IsChecked.DataPropertyName = "IsChecked";
            this.IsChecked.HeaderText = "Отм.";
            this.IsChecked.Name = "IsChecked";
            this.IsChecked.Width = 35;
            // 
            // itemIDDataGridViewTextBoxColumn
            // 
            this.itemIDDataGridViewTextBoxColumn.DataPropertyName = "ItemID";
            this.itemIDDataGridViewTextBoxColumn.HeaderText = "КНН";
            this.itemIDDataGridViewTextBoxColumn.Name = "itemIDDataGridViewTextBoxColumn";
            this.itemIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemIDDataGridViewTextBoxColumn.Width = 50;
            // 
            // itemNameDataGridViewTextBoxColumn
            // 
            this.itemNameDataGridViewTextBoxColumn.DataPropertyName = "ItemName";
            this.itemNameDataGridViewTextBoxColumn.HeaderText = "Наименование";
            this.itemNameDataGridViewTextBoxColumn.Name = "itemNameDataGridViewTextBoxColumn";
            this.itemNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemNameDataGridViewTextBoxColumn.Width = 250;
            // 
            // batchIDDataGridViewTextBoxColumn
            // 
            this.batchIDDataGridViewTextBoxColumn.DataPropertyName = "BatchID";
            this.batchIDDataGridViewTextBoxColumn.HeaderText = "Партия";
            this.batchIDDataGridViewTextBoxColumn.Name = "batchIDDataGridViewTextBoxColumn";
            this.batchIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.batchIDDataGridViewTextBoxColumn.Width = 120;
            // 
            // lotNumberDataGridViewTextBoxColumn
            // 
            this.lotNumberDataGridViewTextBoxColumn.DataPropertyName = "LotNumber";
            this.lotNumberDataGridViewTextBoxColumn.HeaderText = "Серия";
            this.lotNumberDataGridViewTextBoxColumn.Name = "lotNumberDataGridViewTextBoxColumn";
            this.lotNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.lotNumberDataGridViewTextBoxColumn.Width = 120;
            // 
            // locationIDDataGridViewTextBoxColumn
            // 
            this.locationIDDataGridViewTextBoxColumn.DataPropertyName = "LocationID";
            this.locationIDDataGridViewTextBoxColumn.HeaderText = "Место";
            this.locationIDDataGridViewTextBoxColumn.Name = "locationIDDataGridViewTextBoxColumn";
            this.locationIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.locationIDDataGridViewTextBoxColumn.Width = 120;
            // 
            // Department
            // 
            this.Department.DataPropertyName = "Department";
            this.Department.HeaderText = "Отдел";
            this.Department.Name = "Department";
            this.Department.ReadOnly = true;
            this.Department.Width = 200;
            // 
            // EmployeeName
            // 
            this.EmployeeName.DataPropertyName = "EmployeeName";
            this.EmployeeName.HeaderText = "Сотрудник";
            this.EmployeeName.Name = "EmployeeName";
            this.EmployeeName.ReadOnly = true;
            this.EmployeeName.Width = 200;
            // 
            // qtyDataGridViewTextBoxColumn
            // 
            this.qtyDataGridViewTextBoxColumn.DataPropertyName = "Qty";
            this.qtyDataGridViewTextBoxColumn.HeaderText = "Кол-во";
            this.qtyDataGridViewTextBoxColumn.Name = "qtyDataGridViewTextBoxColumn";
            this.qtyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // DocQty
            // 
            this.DocQty.DataPropertyName = "DocQty";
            this.DocQty.HeaderText = "Кол-во взято";
            this.DocQty.Name = "DocQty";
            // 
            // lifeTimeDataGridViewTextBoxColumn
            // 
            this.lifeTimeDataGridViewTextBoxColumn.DataPropertyName = "LifeTime";
            this.lifeTimeDataGridViewTextBoxColumn.HeaderText = "Срок";
            this.lifeTimeDataGridViewTextBoxColumn.Name = "lifeTimeDataGridViewTextBoxColumn";
            this.lifeTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.lifeTimeDataGridViewTextBoxColumn.Width = 80;
            // 
            // cOBMGetRemainsBindingSource
            // 
            this.cOBMGetRemainsBindingSource.DataMember = "CO_BM_Get_Remains";
            this.cOBMGetRemainsBindingSource.DataSource = this.complaints;
            // 
            // complaints
            // 
            this.complaints.DataSetName = "Complaints";
            this.complaints.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cO_BM_Get_RemainsTableAdapter
            // 
            this.cO_BM_Get_RemainsTableAdapter.ClearBeforeFill = true;
            // 
            // ComplaintsBrokenCommodityPlacementWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 483);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.tsMain);
            this.Name = "ComplaintsBrokenCommodityPlacementWindow";
            this.Text = "ComplaintsBrokenCommodityPlacementWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ComplaintsBrokenCommodityPlacementWindow_FormClosing);
            this.Controls.SetChildIndex(this.tsMain, 0);
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemains)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOBMGetRemainsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton sbReloadData;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.DataGridView dgvRemains;
        private System.Windows.Forms.ToolStripButton sbCloseDoc;
        private System.Windows.Forms.ToolStripButton sbCancelDoc;
        private System.Windows.Forms.ToolStripButton sbAssignSSCC;
        private System.Windows.Forms.BindingSource cOBMGetRemainsBindingSource;
        private WMSOffice.Data.Complaints complaints;
        private WMSOffice.Data.ComplaintsTableAdapters.CO_BM_Get_RemainsTableAdapter cO_BM_Get_RemainsTableAdapter;
        private System.Windows.Forms.ToolStripLabel slDocDetailsSummary;
        private System.Windows.Forms.ToolStripSeparator ssSummary;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsChecked;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn batchIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Department;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn lifeTimeDataGridViewTextBoxColumn;
    }
}