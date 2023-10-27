namespace WMSOffice.Dialogs.PickControl
{
    partial class DebtorsReturnedTareSetDublicateForm
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
            this.scLayout = new System.Windows.Forms.SplitContainer();
            this.dgvDocs = new System.Windows.Forms.DataGridView();
            this.tareBarDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tareStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tareTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warehouseIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastActionDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countbarDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dBLRETDocsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pickControl = new WMSOffice.Data.PickControl();
            this.tsMainMenu = new System.Windows.Forms.ToolStrip();
            this.sbAddTare = new System.Windows.Forms.ToolStripButton();
            this.sbAddDublicate = new System.Windows.Forms.ToolStripButton();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.dBLRETDocDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dBL_RET_DocsTableAdapter = new WMSOffice.Data.PickControlTableAdapters.DBL_RET_DocsTableAdapter();
            this.dBL_RET_DocDetailsTableAdapter = new WMSOffice.Data.PickControlTableAdapters.DBL_RET_DocDetailsTableAdapter();
            this.tareBarDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logDateDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tareStatusDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.newTareBarDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actualStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlButtons.SuspendLayout();
            this.scLayout.Panel1.SuspendLayout();
            this.scLayout.Panel2.SuspendLayout();
            this.scLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBLRETDocsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).BeginInit();
            this.tsMainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBLRETDocDetailsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(817, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(907, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 528);
            this.pnlButtons.Size = new System.Drawing.Size(994, 43);
            // 
            // scLayout
            // 
            this.scLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scLayout.Location = new System.Drawing.Point(0, 1);
            this.scLayout.Name = "scLayout";
            this.scLayout.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scLayout.Panel1
            // 
            this.scLayout.Panel1.Controls.Add(this.dgvDocs);
            this.scLayout.Panel1.Controls.Add(this.tsMainMenu);
            // 
            // scLayout.Panel2
            // 
            this.scLayout.Panel2.Controls.Add(this.dgvDetails);
            this.scLayout.Size = new System.Drawing.Size(994, 521);
            this.scLayout.SplitterDistance = 273;
            this.scLayout.TabIndex = 101;
            // 
            // dgvDocs
            // 
            this.dgvDocs.AllowUserToAddRows = false;
            this.dgvDocs.AllowUserToDeleteRows = false;
            this.dgvDocs.AllowUserToResizeColumns = false;
            this.dgvDocs.AllowUserToResizeRows = false;
            this.dgvDocs.AutoGenerateColumns = false;
            this.dgvDocs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDocs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tareBarDataGridViewTextBoxColumn,
            this.tareStatusDataGridViewTextBoxColumn,
            this.tareTypeDataGridViewTextBoxColumn,
            this.warehouseIdDataGridViewTextBoxColumn,
            this.logDateDataGridViewTextBoxColumn,
            this.lastActionDateDataGridViewTextBoxColumn,
            this.countbarDataGridViewTextBoxColumn});
            this.dgvDocs.DataSource = this.dBLRETDocsBindingSource;
            this.dgvDocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocs.Location = new System.Drawing.Point(0, 39);
            this.dgvDocs.MultiSelect = false;
            this.dgvDocs.Name = "dgvDocs";
            this.dgvDocs.ReadOnly = true;
            this.dgvDocs.RowHeadersVisible = false;
            this.dgvDocs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocs.Size = new System.Drawing.Size(994, 234);
            this.dgvDocs.TabIndex = 1;
            this.dgvDocs.SelectionChanged += new System.EventHandler(this.dgvDocs_SelectionChanged);
            // 
            // tareBarDataGridViewTextBoxColumn
            // 
            this.tareBarDataGridViewTextBoxColumn.DataPropertyName = "Tare_Bar";
            this.tareBarDataGridViewTextBoxColumn.HeaderText = "Ш/К тары";
            this.tareBarDataGridViewTextBoxColumn.Name = "tareBarDataGridViewTextBoxColumn";
            this.tareBarDataGridViewTextBoxColumn.ReadOnly = true;
            this.tareBarDataGridViewTextBoxColumn.Width = 75;
            // 
            // tareStatusDataGridViewTextBoxColumn
            // 
            this.tareStatusDataGridViewTextBoxColumn.DataPropertyName = "Tare_Status";
            this.tareStatusDataGridViewTextBoxColumn.HeaderText = "Статус";
            this.tareStatusDataGridViewTextBoxColumn.Name = "tareStatusDataGridViewTextBoxColumn";
            this.tareStatusDataGridViewTextBoxColumn.ReadOnly = true;
            this.tareStatusDataGridViewTextBoxColumn.Width = 66;
            // 
            // tareTypeDataGridViewTextBoxColumn
            // 
            this.tareTypeDataGridViewTextBoxColumn.DataPropertyName = "Tare_Type";
            this.tareTypeDataGridViewTextBoxColumn.HeaderText = "Тип";
            this.tareTypeDataGridViewTextBoxColumn.Name = "tareTypeDataGridViewTextBoxColumn";
            this.tareTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.tareTypeDataGridViewTextBoxColumn.Width = 51;
            // 
            // warehouseIdDataGridViewTextBoxColumn
            // 
            this.warehouseIdDataGridViewTextBoxColumn.DataPropertyName = "Warehouse_Id";
            this.warehouseIdDataGridViewTextBoxColumn.HeaderText = "Склад";
            this.warehouseIdDataGridViewTextBoxColumn.Name = "warehouseIdDataGridViewTextBoxColumn";
            this.warehouseIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.warehouseIdDataGridViewTextBoxColumn.Width = 63;
            // 
            // logDateDataGridViewTextBoxColumn
            // 
            this.logDateDataGridViewTextBoxColumn.DataPropertyName = "Log_Date";
            this.logDateDataGridViewTextBoxColumn.HeaderText = "Дата добавления";
            this.logDateDataGridViewTextBoxColumn.Name = "logDateDataGridViewTextBoxColumn";
            this.logDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.logDateDataGridViewTextBoxColumn.Width = 111;
            // 
            // lastActionDateDataGridViewTextBoxColumn
            // 
            this.lastActionDateDataGridViewTextBoxColumn.DataPropertyName = "Last_Action_Date";
            this.lastActionDateDataGridViewTextBoxColumn.HeaderText = "Дата посл. операции";
            this.lastActionDateDataGridViewTextBoxColumn.Name = "lastActionDateDataGridViewTextBoxColumn";
            this.lastActionDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.lastActionDateDataGridViewTextBoxColumn.Width = 127;
            // 
            // countbarDataGridViewTextBoxColumn
            // 
            this.countbarDataGridViewTextBoxColumn.DataPropertyName = "Count_bar";
            this.countbarDataGridViewTextBoxColumn.HeaderText = "Кол-во дублей";
            this.countbarDataGridViewTextBoxColumn.Name = "countbarDataGridViewTextBoxColumn";
            this.countbarDataGridViewTextBoxColumn.ReadOnly = true;
            this.countbarDataGridViewTextBoxColumn.Width = 96;
            // 
            // dBLRETDocsBindingSource
            // 
            this.dBLRETDocsBindingSource.DataMember = "DBL_RET_Docs";
            this.dBLRETDocsBindingSource.DataSource = this.pickControl;
            // 
            // pickControl
            // 
            this.pickControl.DataSetName = "PickControl";
            this.pickControl.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tsMainMenu
            // 
            this.tsMainMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbAddTare,
            this.sbAddDublicate});
            this.tsMainMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMainMenu.Name = "tsMainMenu";
            this.tsMainMenu.Size = new System.Drawing.Size(994, 39);
            this.tsMainMenu.TabIndex = 0;
            this.tsMainMenu.Text = "toolStrip1";
            // 
            // sbAddTare
            // 
            this.sbAddTare.Image = global::WMSOffice.Properties.Resources.add_document;
            this.sbAddTare.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbAddTare.Name = "sbAddTare";
            this.sbAddTare.Size = new System.Drawing.Size(122, 36);
            this.sbAddTare.Text = "Добавить тару";
            this.sbAddTare.Click += new System.EventHandler(this.sbAddTare_Click);
            // 
            // sbAddDublicate
            // 
            this.sbAddDublicate.Image = global::WMSOffice.Properties.Resources.link;
            this.sbAddDublicate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbAddDublicate.Name = "sbAddDublicate";
            this.sbAddDublicate.Size = new System.Drawing.Size(146, 36);
            this.sbAddDublicate.Text = "Создать дубль ш/к";
            this.sbAddDublicate.Click += new System.EventHandler(this.sbAddDublicate_Click);
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.AllowUserToResizeColumns = false;
            this.dgvDetails.AllowUserToResizeRows = false;
            this.dgvDetails.AutoGenerateColumns = false;
            this.dgvDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tareBarDataGridViewTextBoxColumn1,
            this.logDateDataGridViewTextBoxColumn1,
            this.tareStatusDataGridViewTextBoxColumn1,
            this.userDataGridViewTextBoxColumn,
            this.newTareBarDataGridViewTextBoxColumn,
            this.actualStatusDataGridViewTextBoxColumn,
            this.Reason});
            this.dgvDetails.DataSource = this.dBLRETDocDetailsBindingSource;
            this.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails.Location = new System.Drawing.Point(0, 0);
            this.dgvDetails.MultiSelect = false;
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;
            this.dgvDetails.RowHeadersVisible = false;
            this.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetails.Size = new System.Drawing.Size(994, 244);
            this.dgvDetails.TabIndex = 2;
            // 
            // dBLRETDocDetailsBindingSource
            // 
            this.dBLRETDocDetailsBindingSource.DataMember = "DBL_RET_DocDetails";
            this.dBLRETDocDetailsBindingSource.DataSource = this.pickControl;
            // 
            // dBL_RET_DocsTableAdapter
            // 
            this.dBL_RET_DocsTableAdapter.ClearBeforeFill = true;
            // 
            // dBL_RET_DocDetailsTableAdapter
            // 
            this.dBL_RET_DocDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // tareBarDataGridViewTextBoxColumn1
            // 
            this.tareBarDataGridViewTextBoxColumn1.DataPropertyName = "Tare_Bar";
            this.tareBarDataGridViewTextBoxColumn1.HeaderText = "Ш/К тары";
            this.tareBarDataGridViewTextBoxColumn1.Name = "tareBarDataGridViewTextBoxColumn1";
            this.tareBarDataGridViewTextBoxColumn1.ReadOnly = true;
            this.tareBarDataGridViewTextBoxColumn1.Width = 81;
            // 
            // logDateDataGridViewTextBoxColumn1
            // 
            this.logDateDataGridViewTextBoxColumn1.DataPropertyName = "Log_Date";
            this.logDateDataGridViewTextBoxColumn1.HeaderText = "Дата добавления";
            this.logDateDataGridViewTextBoxColumn1.Name = "logDateDataGridViewTextBoxColumn1";
            this.logDateDataGridViewTextBoxColumn1.ReadOnly = true;
            this.logDateDataGridViewTextBoxColumn1.Width = 111;
            // 
            // tareStatusDataGridViewTextBoxColumn1
            // 
            this.tareStatusDataGridViewTextBoxColumn1.DataPropertyName = "Tare_Status";
            this.tareStatusDataGridViewTextBoxColumn1.HeaderText = "Статус";
            this.tareStatusDataGridViewTextBoxColumn1.Name = "tareStatusDataGridViewTextBoxColumn1";
            this.tareStatusDataGridViewTextBoxColumn1.ReadOnly = true;
            this.tareStatusDataGridViewTextBoxColumn1.Width = 66;
            // 
            // userDataGridViewTextBoxColumn
            // 
            this.userDataGridViewTextBoxColumn.DataPropertyName = "User";
            this.userDataGridViewTextBoxColumn.HeaderText = "Пользователь";
            this.userDataGridViewTextBoxColumn.Name = "userDataGridViewTextBoxColumn";
            this.userDataGridViewTextBoxColumn.ReadOnly = true;
            this.userDataGridViewTextBoxColumn.Width = 105;
            // 
            // newTareBarDataGridViewTextBoxColumn
            // 
            this.newTareBarDataGridViewTextBoxColumn.DataPropertyName = "New_Tare_Bar";
            this.newTareBarDataGridViewTextBoxColumn.HeaderText = "Новый Ш/К тары";
            this.newTareBarDataGridViewTextBoxColumn.Name = "newTareBarDataGridViewTextBoxColumn";
            this.newTareBarDataGridViewTextBoxColumn.ReadOnly = true;
            this.newTareBarDataGridViewTextBoxColumn.Width = 86;
            // 
            // actualStatusDataGridViewTextBoxColumn
            // 
            this.actualStatusDataGridViewTextBoxColumn.DataPropertyName = "Actual_Status";
            this.actualStatusDataGridViewTextBoxColumn.HeaderText = "Текущий статус";
            this.actualStatusDataGridViewTextBoxColumn.Name = "actualStatusDataGridViewTextBoxColumn";
            this.actualStatusDataGridViewTextBoxColumn.ReadOnly = true;
            this.actualStatusDataGridViewTextBoxColumn.Width = 104;
            // 
            // Reason
            // 
            this.Reason.DataPropertyName = "Reason";
            this.Reason.HeaderText = "Причина";
            this.Reason.Name = "Reason";
            this.Reason.ReadOnly = true;
            this.Reason.Width = 75;
            // 
            // DebtorsReturnedTareSetDublicateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 571);
            this.Controls.Add(this.scLayout);
            this.Name = "DebtorsReturnedTareSetDublicateForm";
            this.Text = "Фиксация дублей ш/к";
            this.Load += new System.EventHandler(this.DebtorsReturnedTareSetDublicateForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DebtorsReturnedTareSetDublicateForm_FormClosing);
            this.Controls.SetChildIndex(this.scLayout, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.scLayout.Panel1.ResumeLayout(false);
            this.scLayout.Panel1.PerformLayout();
            this.scLayout.Panel2.ResumeLayout(false);
            this.scLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBLRETDocsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).EndInit();
            this.tsMainMenu.ResumeLayout(false);
            this.tsMainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBLRETDocDetailsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer scLayout;
        private System.Windows.Forms.DataGridView dgvDocs;
        private System.Windows.Forms.ToolStrip tsMainMenu;
        private System.Windows.Forms.ToolStripButton sbAddTare;
        private System.Windows.Forms.ToolStripButton sbAddDublicate;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.BindingSource dBLRETDocsBindingSource;
        private WMSOffice.Data.PickControl pickControl;
        private System.Windows.Forms.BindingSource dBLRETDocDetailsBindingSource;
        private WMSOffice.Data.PickControlTableAdapters.DBL_RET_DocsTableAdapter dBL_RET_DocsTableAdapter;
        private WMSOffice.Data.PickControlTableAdapters.DBL_RET_DocDetailsTableAdapter dBL_RET_DocDetailsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn tareBarDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tareStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tareTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn warehouseIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn logDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastActionDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countbarDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tareBarDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn logDateDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tareStatusDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn userDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn newTareBarDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn actualStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reason;
    }
}