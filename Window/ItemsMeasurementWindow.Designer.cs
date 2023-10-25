namespace WMSOffice.Window
{
    partial class ItemsMeasurementWindow
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
            this.gvBranches = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.itemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.itemsMeasurement = new WMSOffice.Data.ItemsMeasurement();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbItemName = new System.Windows.Forms.TextBox();
            this.tbItemCode = new System.Windows.Forms.TextBox();
            this.lblItemName = new System.Windows.Forms.Label();
            this.lblItemCode = new System.Windows.Forms.Label();
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.btnOpenWizard = new System.Windows.Forms.Button();
            this.lblBatchNumber = new System.Windows.Forms.Label();
            this.stbBatchNumber = new WMSOffice.Controls.SearchTextBox();
            this.cbUseBatchNumber = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chbIncludeDeficiencyItems = new System.Windows.Forms.CheckBox();
            this.chbIncludeOutDatedItems = new System.Windows.Forms.CheckBox();
            this.chbIncludeUnPurchasedItems = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSearchCriteria = new System.Windows.Forms.ComboBox();
            this.itemsTableAdapter = new WMSOffice.Data.ItemsMeasurementTableAdapters.ItemsTableAdapter();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lot_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvBranches)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsMeasurement)).BeginInit();
            this.gbFilter.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvBranches
            // 
            this.gvBranches.AllowUserToAddRows = false;
            this.gvBranches.AllowUserToDeleteRows = false;
            this.gvBranches.AllowUserToResizeRows = false;
            this.gvBranches.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gvBranches.AutoGenerateColumns = false;
            this.gvBranches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvBranches.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.item,
            this.barcode,
            this.manufacturer,
            this.vendor,
            this.lot_number});
            this.gvBranches.ContextMenuStrip = this.contextMenuStrip1;
            this.gvBranches.DataSource = this.itemsBindingSource;
            this.gvBranches.Location = new System.Drawing.Point(0, 163);
            this.gvBranches.Name = "gvBranches";
            this.gvBranches.ReadOnly = true;
            this.gvBranches.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvBranches.Size = new System.Drawing.Size(1027, 423);
            this.gvBranches.TabIndex = 1;
            this.gvBranches.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvBranches_CellDoubleClick);
            this.gvBranches.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvBranches_KeyDown);
            this.gvBranches.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gvBranches_DataBindingComplete);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miRefresh});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(148, 26);
            // 
            // miRefresh
            // 
            this.miRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.miRefresh.Name = "miRefresh";
            this.miRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.miRefresh.Size = new System.Drawing.Size(147, 22);
            this.miRefresh.Text = "&Обновить";
            this.miRefresh.Click += new System.EventHandler(this.miRefresh_Click);
            // 
            // itemsBindingSource
            // 
            this.itemsBindingSource.DataMember = "Items";
            this.itemsBindingSource.DataSource = this.itemsMeasurement;
            // 
            // itemsMeasurement
            // 
            this.itemsMeasurement.DataSetName = "ItemsMeasurement";
            this.itemsMeasurement.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSearch.Location = new System.Drawing.Point(754, 19);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(78, 78);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Поиск";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbItemName
            // 
            this.tbItemName.Location = new System.Drawing.Point(489, 19);
            this.tbItemName.Name = "tbItemName";
            this.tbItemName.Size = new System.Drawing.Size(239, 20);
            this.tbItemName.TabIndex = 5;
            this.tbItemName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbItemName_KeyDown);
            // 
            // tbItemCode
            // 
            this.tbItemCode.Location = new System.Drawing.Point(275, 19);
            this.tbItemCode.Name = "tbItemCode";
            this.tbItemCode.Size = new System.Drawing.Size(104, 20);
            this.tbItemCode.TabIndex = 3;
            this.tbItemCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbItemCode_KeyDown);
            this.tbItemCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbItemCode_KeyPress);
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Location = new System.Drawing.Point(397, 23);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(86, 13);
            this.lblItemName.TabIndex = 4;
            this.lblItemName.Text = "Наименование:";
            // 
            // lblItemCode
            // 
            this.lblItemCode.AutoSize = true;
            this.lblItemCode.Location = new System.Drawing.Point(239, 23);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.Size = new System.Drawing.Size(29, 13);
            this.lblItemCode.TabIndex = 2;
            this.lblItemCode.Text = "Код:";
            // 
            // gbFilter
            // 
            this.gbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFilter.Controls.Add(this.btnOpenWizard);
            this.gbFilter.Controls.Add(this.lblBatchNumber);
            this.gbFilter.Controls.Add(this.stbBatchNumber);
            this.gbFilter.Controls.Add(this.cbUseBatchNumber);
            this.gbFilter.Controls.Add(this.groupBox1);
            this.gbFilter.Controls.Add(this.btnSearch);
            this.gbFilter.Controls.Add(this.label1);
            this.gbFilter.Controls.Add(this.tbItemName);
            this.gbFilter.Controls.Add(this.cbSearchCriteria);
            this.gbFilter.Controls.Add(this.tbItemCode);
            this.gbFilter.Controls.Add(this.lblItemName);
            this.gbFilter.Controls.Add(this.lblItemCode);
            this.gbFilter.Location = new System.Drawing.Point(0, 46);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(1027, 111);
            this.gbFilter.TabIndex = 3;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Фильтр:";
            // 
            // btnOpenWizard
            // 
            this.btnOpenWizard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenWizard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOpenWizard.Image = global::WMSOffice.Properties.Resources.measurement;
            this.btnOpenWizard.Location = new System.Drawing.Point(937, 19);
            this.btnOpenWizard.Name = "btnOpenWizard";
            this.btnOpenWizard.Size = new System.Drawing.Size(78, 78);
            this.btnOpenWizard.TabIndex = 18;
            this.btnOpenWizard.Text = "Мастер действий";
            this.btnOpenWizard.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOpenWizard.UseVisualStyleBackColor = true;
            this.btnOpenWizard.Click += new System.EventHandler(this.btnOpenWizard_Click);
            // 
            // lblBatchNumber
            // 
            this.lblBatchNumber.AutoSize = true;
            this.lblBatchNumber.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblBatchNumber.Location = new System.Drawing.Point(489, 89);
            this.lblBatchNumber.Name = "lblBatchNumber";
            this.lblBatchNumber.Size = new System.Drawing.Size(0, 13);
            this.lblBatchNumber.TabIndex = 17;
            // 
            // stbBatchNumber
            // 
            this.stbBatchNumber.Location = new System.Drawing.Point(489, 66);
            this.stbBatchNumber.Name = "stbBatchNumber";
            this.stbBatchNumber.Size = new System.Drawing.Size(239, 20);
            this.stbBatchNumber.TabIndex = 10;
            this.stbBatchNumber.UserID = ((long)(0));
            this.stbBatchNumber.Value = null;
            this.stbBatchNumber.ValueReferenceQuery = null;
            // 
            // cbUseBatchNumber
            // 
            this.cbUseBatchNumber.AutoSize = true;
            this.cbUseBatchNumber.Checked = true;
            this.cbUseBatchNumber.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbUseBatchNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbUseBatchNumber.ForeColor = System.Drawing.Color.Black;
            this.cbUseBatchNumber.Location = new System.Drawing.Point(400, 68);
            this.cbUseBatchNumber.Name = "cbUseBatchNumber";
            this.cbUseBatchNumber.Size = new System.Drawing.Size(66, 17);
            this.cbUseBatchNumber.TabIndex = 7;
            this.cbUseBatchNumber.Text = "Партия:";
            this.cbUseBatchNumber.UseVisualStyleBackColor = true;
            this.cbUseBatchNumber.CheckedChanged += new System.EventHandler(this.cbUseBatchNumber_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chbIncludeDeficiencyItems);
            this.groupBox1.Controls.Add(this.chbIncludeOutDatedItems);
            this.groupBox1.Controls.Add(this.chbIncludeUnPurchasedItems);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.ForeColor = System.Drawing.Color.DarkBlue;
            this.groupBox1.Location = new System.Drawing.Point(16, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(315, 48);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Дополнительно искать среди товаров:";
            // 
            // chbIncludeDeficiencyItems
            // 
            this.chbIncludeDeficiencyItems.AutoSize = true;
            this.chbIncludeDeficiencyItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chbIncludeDeficiencyItems.ForeColor = System.Drawing.Color.Black;
            this.chbIncludeDeficiencyItems.Location = new System.Drawing.Point(228, 19);
            this.chbIncludeDeficiencyItems.Name = "chbIncludeDeficiencyItems";
            this.chbIncludeDeficiencyItems.Size = new System.Drawing.Size(82, 17);
            this.chbIncludeDeficiencyItems.TabIndex = 3;
            this.chbIncludeDeficiencyItems.Text = "дефектуры";
            this.chbIncludeDeficiencyItems.UseVisualStyleBackColor = true;
            // 
            // chbIncludeOutDatedItems
            // 
            this.chbIncludeOutDatedItems.AutoSize = true;
            this.chbIncludeOutDatedItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chbIncludeOutDatedItems.ForeColor = System.Drawing.Color.Black;
            this.chbIncludeOutDatedItems.Location = new System.Drawing.Point(11, 19);
            this.chbIncludeOutDatedItems.Name = "chbIncludeOutDatedItems";
            this.chbIncludeOutDatedItems.Size = new System.Drawing.Size(85, 17);
            this.chbIncludeOutDatedItems.TabIndex = 1;
            this.chbIncludeOutDatedItems.Text = "устаревших";
            this.chbIncludeOutDatedItems.UseVisualStyleBackColor = true;
            // 
            // chbIncludeUnPurchasedItems
            // 
            this.chbIncludeUnPurchasedItems.AutoSize = true;
            this.chbIncludeUnPurchasedItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chbIncludeUnPurchasedItems.ForeColor = System.Drawing.Color.Black;
            this.chbIncludeUnPurchasedItems.Location = new System.Drawing.Point(112, 19);
            this.chbIncludeUnPurchasedItems.Name = "chbIncludeUnPurchasedItems";
            this.chbIncludeUnPurchasedItems.Size = new System.Drawing.Size(100, 17);
            this.chbIncludeUnPurchasedItems.TabIndex = 2;
            this.chbIncludeUnPurchasedItems.Text = "незакупаемых";
            this.chbIncludeUnPurchasedItems.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Критерий:";
            // 
            // cbSearchCriteria
            // 
            this.cbSearchCriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearchCriteria.FormattingEnabled = true;
            this.cbSearchCriteria.Items.AddRange(new object[] {
            "Товар",
            "Производитель",
            "Поставщик"});
            this.cbSearchCriteria.Location = new System.Drawing.Point(77, 19);
            this.cbSearchCriteria.Name = "cbSearchCriteria";
            this.cbSearchCriteria.Size = new System.Drawing.Size(140, 21);
            this.cbSearchCriteria.TabIndex = 1;
            // 
            // itemsTableAdapter
            // 
            this.itemsTableAdapter.ClearBeforeFill = true;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.DataPropertyName = "item_id";
            this.Column1.HeaderText = "Код";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 51;
            // 
            // item
            // 
            this.item.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.item.DataPropertyName = "item";
            this.item.HeaderText = "Наименование";
            this.item.Name = "item";
            this.item.ReadOnly = true;
            this.item.Width = 108;
            // 
            // barcode
            // 
            this.barcode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.barcode.DataPropertyName = "barcode";
            this.barcode.HeaderText = "Штрих-код";
            this.barcode.Name = "barcode";
            this.barcode.ReadOnly = true;
            this.barcode.Width = 84;
            // 
            // manufacturer
            // 
            this.manufacturer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.manufacturer.DataPropertyName = "manufacturer";
            this.manufacturer.HeaderText = "Производитель";
            this.manufacturer.Name = "manufacturer";
            this.manufacturer.ReadOnly = true;
            this.manufacturer.Width = 111;
            // 
            // vendor
            // 
            this.vendor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.vendor.DataPropertyName = "vendor";
            this.vendor.HeaderText = "Поставщик";
            this.vendor.Name = "vendor";
            this.vendor.ReadOnly = true;
            this.vendor.Width = 90;
            // 
            // lot_number
            // 
            this.lot_number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lot_number.DataPropertyName = "lot_number";
            this.lot_number.HeaderText = "Партия";
            this.lot_number.Name = "lot_number";
            this.lot_number.ReadOnly = true;
            this.lot_number.Width = 69;
            // 
            // ItemsMeasurementWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 586);
            this.Controls.Add(this.gbFilter);
            this.Controls.Add(this.gvBranches);
            this.Name = "ItemsMeasurementWindow";
            this.Text = "ItemsMeasurementWindow";
            this.Load += new System.EventHandler(this.ItemsMeasurementWindow_Load);
            this.Controls.SetChildIndex(this.gvBranches, 0);
            this.Controls.SetChildIndex(this.gbFilter, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gvBranches)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsMeasurement)).EndInit();
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvBranches;
        private WMSOffice.Data.ItemsMeasurement itemsMeasurement;
        private System.Windows.Forms.BindingSource itemsBindingSource;
        private WMSOffice.Data.ItemsMeasurementTableAdapters.ItemsTableAdapter itemsTableAdapter;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem miRefresh;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbItemName;
        private System.Windows.Forms.TextBox tbItemCode;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Label lblItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbSearchCriteria;
        private System.Windows.Forms.CheckBox chbIncludeUnPurchasedItems;
        private System.Windows.Forms.CheckBox chbIncludeOutDatedItems;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chbIncludeDeficiencyItems;
        private System.Windows.Forms.CheckBox cbUseBatchNumber;
        private WMSOffice.Controls.SearchTextBox stbBatchNumber;
        private System.Windows.Forms.Label lblBatchNumber;
        private System.Windows.Forms.Button btnOpenWizard;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn item;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendor;
        private System.Windows.Forms.DataGridViewTextBoxColumn lot_number;
    }
}