namespace WMSOffice.Window
{
    partial class AWStructureManagementImportFromExcellWindow
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.sectornameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.secflooridDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sectordescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.placecodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.placestatusidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unionnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uniondescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unionsignDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unionstagenameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stationcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stationnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stationdescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stationtitleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aWPlacesStationsLinksImportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pickControl = new WMSOffice.Data.PickControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ButtonOpenExcelFile = new System.Windows.Forms.ToolStripButton();
            this.ButtonApply = new System.Windows.Forms.ToolStripButton();
            this.ButtonClearTable = new System.Windows.Forms.ToolStripButton();
            this.ButtonCopyPaste = new System.Windows.Forms.ToolStripButton();
            this.aWWarehousesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aW_Places_Stations_Links_ImportTableAdapter = new WMSOffice.Data.PickControlTableAdapters.AW_Places_Stations_Links_ImportTableAdapter();
            this.aW_WarehousesTableAdapter = new WMSOffice.Data.PickControlTableAdapters.AW_WarehousesTableAdapter();
            this.stbWarehouseID = new WMSOffice.Controls.SearchTextBox();
            this.lblWarehouseName = new System.Windows.Forms.Label();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.checkBoxDelete = new System.Windows.Forms.CheckBox();
            this.checkBoxAdd = new System.Windows.Forms.CheckBox();
            this.groupBoxWarehouses = new System.Windows.Forms.GroupBox();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aWPlacesStationsLinksImportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aWWarehousesBindingSource)).BeginInit();
            this.groupBox.SuspendLayout();
            this.groupBoxWarehouses.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(15405, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(15495, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 528);
            this.pnlButtons.Size = new System.Drawing.Size(894, 43);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sectornameDataGridViewTextBoxColumn,
            this.secflooridDataGridViewTextBoxColumn,
            this.sectordescriptionDataGridViewTextBoxColumn,
            this.placecodeDataGridViewTextBoxColumn,
            this.placestatusidDataGridViewTextBoxColumn,
            this.unionnameDataGridViewTextBoxColumn,
            this.uniondescriptionDataGridViewTextBoxColumn,
            this.unionsignDataGridViewTextBoxColumn,
            this.unionstagenameDataGridViewTextBoxColumn,
            this.stationcodeDataGridViewTextBoxColumn,
            this.stationnameDataGridViewTextBoxColumn,
            this.stationdescriptionDataGridViewTextBoxColumn,
            this.stationtitleDataGridViewTextBoxColumn,
            this.scDataGridViewTextBoxColumn,
            this.plDataGridViewTextBoxColumn,
            this.unDataGridViewTextBoxColumn,
            this.stDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.aWPlacesStationsLinksImportBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 127);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(879, 395);
            this.dataGridView1.TabIndex = 0;
            // 
            // sectornameDataGridViewTextBoxColumn
            // 
            this.sectornameDataGridViewTextBoxColumn.DataPropertyName = "sector_name";
            this.sectornameDataGridViewTextBoxColumn.HeaderText = "sector_name";
            this.sectornameDataGridViewTextBoxColumn.Name = "sectornameDataGridViewTextBoxColumn";
            // 
            // secflooridDataGridViewTextBoxColumn
            // 
            this.secflooridDataGridViewTextBoxColumn.DataPropertyName = "sec_floor_id";
            this.secflooridDataGridViewTextBoxColumn.HeaderText = "sec_floor_id";
            this.secflooridDataGridViewTextBoxColumn.Name = "secflooridDataGridViewTextBoxColumn";
            // 
            // sectordescriptionDataGridViewTextBoxColumn
            // 
            this.sectordescriptionDataGridViewTextBoxColumn.DataPropertyName = "sector_description";
            this.sectordescriptionDataGridViewTextBoxColumn.HeaderText = "sector_description";
            this.sectordescriptionDataGridViewTextBoxColumn.Name = "sectordescriptionDataGridViewTextBoxColumn";
            // 
            // placecodeDataGridViewTextBoxColumn
            // 
            this.placecodeDataGridViewTextBoxColumn.DataPropertyName = "place_code";
            this.placecodeDataGridViewTextBoxColumn.HeaderText = "place_code";
            this.placecodeDataGridViewTextBoxColumn.Name = "placecodeDataGridViewTextBoxColumn";
            // 
            // placestatusidDataGridViewTextBoxColumn
            // 
            this.placestatusidDataGridViewTextBoxColumn.DataPropertyName = "place_status_id";
            this.placestatusidDataGridViewTextBoxColumn.HeaderText = "place_status_id";
            this.placestatusidDataGridViewTextBoxColumn.Name = "placestatusidDataGridViewTextBoxColumn";
            // 
            // unionnameDataGridViewTextBoxColumn
            // 
            this.unionnameDataGridViewTextBoxColumn.DataPropertyName = "union_name";
            this.unionnameDataGridViewTextBoxColumn.HeaderText = "union_name";
            this.unionnameDataGridViewTextBoxColumn.Name = "unionnameDataGridViewTextBoxColumn";
            // 
            // uniondescriptionDataGridViewTextBoxColumn
            // 
            this.uniondescriptionDataGridViewTextBoxColumn.DataPropertyName = "union_description";
            this.uniondescriptionDataGridViewTextBoxColumn.HeaderText = "union_description";
            this.uniondescriptionDataGridViewTextBoxColumn.Name = "uniondescriptionDataGridViewTextBoxColumn";
            // 
            // unionsignDataGridViewTextBoxColumn
            // 
            this.unionsignDataGridViewTextBoxColumn.DataPropertyName = "union_sign";
            this.unionsignDataGridViewTextBoxColumn.HeaderText = "union_sign";
            this.unionsignDataGridViewTextBoxColumn.Name = "unionsignDataGridViewTextBoxColumn";
            // 
            // unionstagenameDataGridViewTextBoxColumn
            // 
            this.unionstagenameDataGridViewTextBoxColumn.DataPropertyName = "union_stage_name";
            this.unionstagenameDataGridViewTextBoxColumn.HeaderText = "union_stage_name";
            this.unionstagenameDataGridViewTextBoxColumn.Name = "unionstagenameDataGridViewTextBoxColumn";
            // 
            // stationcodeDataGridViewTextBoxColumn
            // 
            this.stationcodeDataGridViewTextBoxColumn.DataPropertyName = "station_code";
            this.stationcodeDataGridViewTextBoxColumn.HeaderText = "station_code";
            this.stationcodeDataGridViewTextBoxColumn.Name = "stationcodeDataGridViewTextBoxColumn";
            // 
            // stationnameDataGridViewTextBoxColumn
            // 
            this.stationnameDataGridViewTextBoxColumn.DataPropertyName = "station_name";
            this.stationnameDataGridViewTextBoxColumn.HeaderText = "station_name";
            this.stationnameDataGridViewTextBoxColumn.Name = "stationnameDataGridViewTextBoxColumn";
            // 
            // stationdescriptionDataGridViewTextBoxColumn
            // 
            this.stationdescriptionDataGridViewTextBoxColumn.DataPropertyName = "station_description";
            this.stationdescriptionDataGridViewTextBoxColumn.HeaderText = "station_description";
            this.stationdescriptionDataGridViewTextBoxColumn.Name = "stationdescriptionDataGridViewTextBoxColumn";
            // 
            // stationtitleDataGridViewTextBoxColumn
            // 
            this.stationtitleDataGridViewTextBoxColumn.DataPropertyName = "station_title";
            this.stationtitleDataGridViewTextBoxColumn.HeaderText = "station_title";
            this.stationtitleDataGridViewTextBoxColumn.Name = "stationtitleDataGridViewTextBoxColumn";
            // 
            // scDataGridViewTextBoxColumn
            // 
            this.scDataGridViewTextBoxColumn.DataPropertyName = "sc";
            this.scDataGridViewTextBoxColumn.HeaderText = "sc";
            this.scDataGridViewTextBoxColumn.Name = "scDataGridViewTextBoxColumn";
            // 
            // plDataGridViewTextBoxColumn
            // 
            this.plDataGridViewTextBoxColumn.DataPropertyName = "pl";
            this.plDataGridViewTextBoxColumn.HeaderText = "pl";
            this.plDataGridViewTextBoxColumn.Name = "plDataGridViewTextBoxColumn";
            // 
            // unDataGridViewTextBoxColumn
            // 
            this.unDataGridViewTextBoxColumn.DataPropertyName = "un";
            this.unDataGridViewTextBoxColumn.HeaderText = "un";
            this.unDataGridViewTextBoxColumn.Name = "unDataGridViewTextBoxColumn";
            // 
            // stDataGridViewTextBoxColumn
            // 
            this.stDataGridViewTextBoxColumn.DataPropertyName = "st";
            this.stDataGridViewTextBoxColumn.HeaderText = "st";
            this.stDataGridViewTextBoxColumn.Name = "stDataGridViewTextBoxColumn";
            // 
            // aWPlacesStationsLinksImportBindingSource
            // 
            this.aWPlacesStationsLinksImportBindingSource.DataMember = "AW_Places_Stations_Links_Import";
            this.aWPlacesStationsLinksImportBindingSource.DataSource = this.pickControl;
            // 
            // pickControl
            // 
            this.pickControl.DataSetName = "PickControl";
            this.pickControl.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ButtonOpenExcelFile,
            this.ButtonApply,
            this.ButtonClearTable,
            this.ButtonCopyPaste});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(894, 39);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ButtonOpenExcelFile
            // 
            this.ButtonOpenExcelFile.Image = global::WMSOffice.Properties.Resources.Open;
            this.ButtonOpenExcelFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonOpenExcelFile.Name = "ButtonOpenExcelFile";
            this.ButtonOpenExcelFile.Size = new System.Drawing.Size(151, 36);
            this.ButtonOpenExcelFile.Text = "Открыть файл Excel";
            this.ButtonOpenExcelFile.Click += new System.EventHandler(this.OpenExcelFileButton_Click);
            // 
            // ButtonApply
            // 
            this.ButtonApply.Image = global::WMSOffice.Properties.Resources.ok_32;
            this.ButtonApply.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonApply.Name = "ButtonApply";
            this.ButtonApply.Size = new System.Drawing.Size(106, 36);
            this.ButtonApply.Text = "Применить";
            this.ButtonApply.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // ButtonClearTable
            // 
            this.ButtonClearTable.Image = global::WMSOffice.Properties.Resources.clear_32;
            this.ButtonClearTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonClearTable.Name = "ButtonClearTable";
            this.ButtonClearTable.Size = new System.Drawing.Size(95, 36);
            this.ButtonClearTable.Text = "Очистить";
            this.ButtonClearTable.Click += new System.EventHandler(this.ClearTableButton_Click);
            // 
            // ButtonCopyPaste
            // 
            this.ButtonCopyPaste.Image = global::WMSOffice.Properties.Resources.tables_edit;
            this.ButtonCopyPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonCopyPaste.Name = "ButtonCopyPaste";
            this.ButtonCopyPaste.Size = new System.Drawing.Size(150, 36);
            this.ButtonCopyPaste.Text = "Вставить из буфера";
            this.ButtonCopyPaste.Click += new System.EventHandler(this.CopyPasteButton_Click);
            // 
            // aWWarehousesBindingSource
            // 
            this.aWWarehousesBindingSource.DataMember = "AW_Warehouses";
            this.aWWarehousesBindingSource.DataSource = this.pickControl;
            // 
            // aW_Places_Stations_Links_ImportTableAdapter
            // 
            this.aW_Places_Stations_Links_ImportTableAdapter.ClearBeforeFill = true;
            // 
            // aW_WarehousesTableAdapter
            // 
            this.aW_WarehousesTableAdapter.ClearBeforeFill = true;
            // 
            // stbWarehouseID
            // 
            this.stbWarehouseID.Location = new System.Drawing.Point(17, 19);
            this.stbWarehouseID.Name = "stbWarehouseID";
            this.stbWarehouseID.ReadOnly = false;
            this.stbWarehouseID.Size = new System.Drawing.Size(100, 20);
            this.stbWarehouseID.TabIndex = 101;
            this.stbWarehouseID.UserID = ((long)(0));
            this.stbWarehouseID.Value = null;
            this.stbWarehouseID.ValueReferenceQuery = null;
            // 
            // lblWarehouseName
            // 
            this.lblWarehouseName.AutoSize = true;
            this.lblWarehouseName.Font = new System.Drawing.Font("Arial", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblWarehouseName.Location = new System.Drawing.Point(14, 51);
            this.lblWarehouseName.Name = "lblWarehouseName";
            this.lblWarehouseName.Size = new System.Drawing.Size(0, 14);
            this.lblWarehouseName.TabIndex = 102;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.checkBoxDelete);
            this.groupBox.Controls.Add(this.checkBoxAdd);
            this.groupBox.Location = new System.Drawing.Point(329, 42);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(97, 79);
            this.groupBox.TabIndex = 103;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Опции";
            // 
            // checkBoxDelete
            // 
            this.checkBoxDelete.AutoSize = true;
            this.checkBoxDelete.Location = new System.Drawing.Point(7, 48);
            this.checkBoxDelete.Name = "checkBoxDelete";
            this.checkBoxDelete.Size = new System.Drawing.Size(76, 17);
            this.checkBoxDelete.TabIndex = 1;
            this.checkBoxDelete.Text = "Удаление";
            this.checkBoxDelete.UseVisualStyleBackColor = true;
            this.checkBoxDelete.CheckedChanged += new System.EventHandler(this.checkBoxDelete_CheckedChanged);
            // 
            // checkBoxAdd
            // 
            this.checkBoxAdd.AutoSize = true;
            this.checkBoxAdd.Location = new System.Drawing.Point(7, 22);
            this.checkBoxAdd.Name = "checkBoxAdd";
            this.checkBoxAdd.Size = new System.Drawing.Size(89, 17);
            this.checkBoxAdd.TabIndex = 0;
            this.checkBoxAdd.Text = "Добавление";
            this.checkBoxAdd.UseVisualStyleBackColor = true;
            this.checkBoxAdd.CheckedChanged += new System.EventHandler(this.checkBoxAdd_CheckedChanged);
            // 
            // groupBoxWarehouses
            // 
            this.groupBoxWarehouses.Controls.Add(this.stbWarehouseID);
            this.groupBoxWarehouses.Controls.Add(this.lblWarehouseName);
            this.groupBoxWarehouses.Location = new System.Drawing.Point(12, 42);
            this.groupBoxWarehouses.Name = "groupBoxWarehouses";
            this.groupBoxWarehouses.Size = new System.Drawing.Size(299, 79);
            this.groupBoxWarehouses.TabIndex = 104;
            this.groupBoxWarehouses.TabStop = false;
            this.groupBoxWarehouses.Text = "Склад";
            // 
            // AWStructureManagementImportFromExcellWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 571);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBoxWarehouses);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox);
            this.Name = "AWStructureManagementImportFromExcellWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Импорт из Excel";
            this.Load += new System.EventHandler(this.AWStructureManagementImportFromExcellWindow_Load);
            this.Controls.SetChildIndex(this.groupBox, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.groupBoxWarehouses, 0);
            this.Controls.SetChildIndex(this.toolStrip1, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aWPlacesStationsLinksImportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aWWarehousesBindingSource)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.groupBoxWarehouses.ResumeLayout(false);
            this.groupBoxWarehouses.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ButtonApply;
        private System.Windows.Forms.ToolStripButton ButtonClearTable;
        private System.Windows.Forms.ToolStripButton ButtonCopyPaste;
        private System.Windows.Forms.ToolStripButton ButtonOpenExcelFile;
        private WMSOffice.Data.PickControl pickControl;
        private System.Windows.Forms.BindingSource aWPlacesStationsLinksImportBindingSource;
        private WMSOffice.Data.PickControlTableAdapters.AW_Places_Stations_Links_ImportTableAdapter aW_Places_Stations_Links_ImportTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn sectornameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn secflooridDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sectordescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn placecodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn placestatusidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unionnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uniondescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unionsignDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unionstagenameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stationcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stationnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stationdescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stationtitleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn scDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn plDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource aWWarehousesBindingSource;
        private WMSOffice.Data.PickControlTableAdapters.AW_WarehousesTableAdapter aW_WarehousesTableAdapter;
        private WMSOffice.Controls.SearchTextBox stbWarehouseID;
        private System.Windows.Forms.Label lblWarehouseName;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.CheckBox checkBoxDelete;
        private System.Windows.Forms.CheckBox checkBoxAdd;
        private System.Windows.Forms.GroupBox groupBoxWarehouses;
    }
}