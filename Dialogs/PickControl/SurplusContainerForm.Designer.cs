namespace WMSOffice.Dialogs.PickControl
{
    partial class SurplusContainerForm
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.itemidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorlotDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uomDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.producerNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvbcCollectors = new WMSOffice.Window.DataGridViewDisableButtonColumn();
            this.surplusContainerDocDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pickControl = new WMSOffice.Data.PickControl();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.btnSplit = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblDelete = new System.Windows.Forms.Label();
            this.lblQuantityChange = new System.Windows.Forms.Label();
            this.lblVendorLotChange = new System.Windows.Forms.Label();
            this.surplusContainerDocDetailsTableAdapter = new WMSOffice.Data.PickControlTableAdapters.SurplusContainerDocDetailsTableAdapter();
            this.btnCloseContainer = new System.Windows.Forms.ToolStripButton();
            this.sepCloseContainer = new System.Windows.Forms.ToolStripSeparator();
            this.pnlButtons.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.surplusContainerDocDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).BeginInit();
            this.tsMain.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(11133, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(11223, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 528);
            this.pnlButtons.Size = new System.Drawing.Size(1094, 43);
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.Controls.Add(this.dgvItems);
            this.pnlMain.Controls.Add(this.tsMain);
            this.pnlMain.Controls.Add(this.pnlFooter);
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1094, 522);
            this.pnlMain.TabIndex = 101;
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AllowUserToResizeRows = false;
            this.dgvItems.AutoGenerateColumns = false;
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
            this.itemidDataGridViewTextBoxColumn,
            this.itemnameDataGridViewTextBoxColumn,
            this.vendorlotDataGridViewTextBoxColumn,
            this.uomDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn,
            this.producerNameDataGridViewTextBoxColumn,
            this.dgvbcCollectors});
            this.dgvItems.DataSource = this.surplusContainerDocDetailsBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvItems.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItems.Location = new System.Drawing.Point(0, 31);
            this.dgvItems.MultiSelect = false;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(1094, 456);
            this.dgvItems.TabIndex = 10;
            this.dgvItems.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvItems_CellMouseDoubleClick);
            this.dgvItems.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvItems_DataBindingComplete);
            this.dgvItems.SelectionChanged += new System.EventHandler(this.dgvItems_SelectionChanged);
            this.dgvItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItems_CellContentClick);
            // 
            // itemidDataGridViewTextBoxColumn
            // 
            this.itemidDataGridViewTextBoxColumn.DataPropertyName = "item_id";
            this.itemidDataGridViewTextBoxColumn.HeaderText = "Код";
            this.itemidDataGridViewTextBoxColumn.Name = "itemidDataGridViewTextBoxColumn";
            this.itemidDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemidDataGridViewTextBoxColumn.Width = 60;
            // 
            // itemnameDataGridViewTextBoxColumn
            // 
            this.itemnameDataGridViewTextBoxColumn.DataPropertyName = "item_name";
            this.itemnameDataGridViewTextBoxColumn.HeaderText = "Наименование";
            this.itemnameDataGridViewTextBoxColumn.Name = "itemnameDataGridViewTextBoxColumn";
            this.itemnameDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemnameDataGridViewTextBoxColumn.Width = 340;
            // 
            // vendorlotDataGridViewTextBoxColumn
            // 
            this.vendorlotDataGridViewTextBoxColumn.DataPropertyName = "vendor_lot";
            this.vendorlotDataGridViewTextBoxColumn.HeaderText = "Серия";
            this.vendorlotDataGridViewTextBoxColumn.Name = "vendorlotDataGridViewTextBoxColumn";
            this.vendorlotDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // uomDataGridViewTextBoxColumn
            // 
            this.uomDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.uomDataGridViewTextBoxColumn.DataPropertyName = "uom";
            this.uomDataGridViewTextBoxColumn.HeaderText = "ЕИ";
            this.uomDataGridViewTextBoxColumn.Name = "uomDataGridViewTextBoxColumn";
            this.uomDataGridViewTextBoxColumn.ReadOnly = true;
            this.uomDataGridViewTextBoxColumn.Width = 54;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "К-во излишка";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.ReadOnly = true;
            this.quantityDataGridViewTextBoxColumn.Width = 120;
            // 
            // producerNameDataGridViewTextBoxColumn
            // 
            this.producerNameDataGridViewTextBoxColumn.DataPropertyName = "Producer_Name";
            this.producerNameDataGridViewTextBoxColumn.HeaderText = "Производитель";
            this.producerNameDataGridViewTextBoxColumn.Name = "producerNameDataGridViewTextBoxColumn";
            this.producerNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.producerNameDataGridViewTextBoxColumn.Width = 300;
            // 
            // dgvbcCollectors
            // 
            this.dgvbcCollectors.HeaderText = "";
            this.dgvbcCollectors.Name = "dgvbcCollectors";
            this.dgvbcCollectors.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvbcCollectors.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvbcCollectors.Text = "Сборщики";
            this.dgvbcCollectors.UseColumnTextForButtonValue = true;
            // 
            // surplusContainerDocDetailsBindingSource
            // 
            this.surplusContainerDocDetailsBindingSource.DataMember = "SurplusContainerDocDetails";
            this.surplusContainerDocDetailsBindingSource.DataSource = this.pickControl;
            // 
            // pickControl
            // 
            this.pickControl.DataSetName = "PickControl";
            this.pickControl.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSplit,
            this.btnDelete,
            this.sepCloseContainer,
            this.btnCloseContainer});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1094, 31);
            this.tsMain.TabIndex = 9;
            this.tsMain.Text = "toolStrip1";
            // 
            // btnSplit
            // 
            this.btnSplit.Image = global::WMSOffice.Properties.Resources.Add_48;
            this.btnSplit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSplit.Name = "btnSplit";
            this.btnSplit.Size = new System.Drawing.Size(78, 28);
            this.btnSplit.Text = "Разбить";
            this.btnSplit.Click += new System.EventHandler(this.btnSplit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::WMSOffice.Properties.Resources.Delete;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(79, 28);
            this.btnDelete.Text = "Удалить";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.lblDelete);
            this.pnlFooter.Controls.Add(this.lblQuantityChange);
            this.pnlFooter.Controls.Add(this.lblVendorLotChange);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 487);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1094, 35);
            this.pnlFooter.TabIndex = 8;
            // 
            // lblDelete
            // 
            this.lblDelete.AutoSize = true;
            this.lblDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDelete.ForeColor = System.Drawing.Color.Gray;
            this.lblDelete.Location = new System.Drawing.Point(569, 7);
            this.lblDelete.Name = "lblDelete";
            this.lblDelete.Size = new System.Drawing.Size(215, 20);
            this.lblDelete.TabIndex = 2;
            this.lblDelete.Text = "DEL - удаление позиции";
            this.lblDelete.Visible = false;
            // 
            // lblQuantityChange
            // 
            this.lblQuantityChange.AutoSize = true;
            this.lblQuantityChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblQuantityChange.ForeColor = System.Drawing.Color.Gray;
            this.lblQuantityChange.Location = new System.Drawing.Point(265, 7);
            this.lblQuantityChange.Name = "lblQuantityChange";
            this.lblQuantityChange.Size = new System.Drawing.Size(249, 20);
            this.lblQuantityChange.TabIndex = 1;
            this.lblQuantityChange.Text = "CTRL+Q - выбор количества";
            this.lblQuantityChange.Visible = false;
            // 
            // lblVendorLotChange
            // 
            this.lblVendorLotChange.AutoSize = true;
            this.lblVendorLotChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblVendorLotChange.Location = new System.Drawing.Point(12, 7);
            this.lblVendorLotChange.Name = "lblVendorLotChange";
            this.lblVendorLotChange.Size = new System.Drawing.Size(242, 20);
            this.lblVendorLotChange.TabIndex = 0;
            this.lblVendorLotChange.Text = "F2- корректировка позиции";
            // 
            // surplusContainerDocDetailsTableAdapter
            // 
            this.surplusContainerDocDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // btnCloseContainer
            // 
            this.btnCloseContainer.Image = global::WMSOffice.Properties.Resources.finish_process;
            this.btnCloseContainer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCloseContainer.Name = "btnCloseContainer";
            this.btnCloseContainer.Size = new System.Drawing.Size(142, 28);
            this.btnCloseContainer.Text = "Закрыть контейнер";
            this.btnCloseContainer.Click += new System.EventHandler(this.btnCloseContainer_Click);
            // 
            // sepCloseContainer
            // 
            this.sepCloseContainer.Name = "sepCloseContainer";
            this.sepCloseContainer.Size = new System.Drawing.Size(6, 31);
            // 
            // SurplusContainerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 571);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "SurplusContainerForm";
            this.Text = "Контроль излишка";
            this.Load += new System.EventHandler(this.SurplusContainerForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SurplusContainerForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlMain, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.surplusContainerDocDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).EndInit();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btnSplit;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblDelete;
        private System.Windows.Forms.Label lblQuantityChange;
        private System.Windows.Forms.Label lblVendorLotChange;
        private System.Windows.Forms.BindingSource surplusContainerDocDetailsBindingSource;
        private WMSOffice.Data.PickControl pickControl;
        private WMSOffice.Data.PickControlTableAdapters.SurplusContainerDocDetailsTableAdapter surplusContainerDocDetailsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorlotDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uomDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn producerNameDataGridViewTextBoxColumn;
        private WMSOffice.Window.DataGridViewDisableButtonColumn dgvbcCollectors;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnCloseContainer;
        private System.Windows.Forms.ToolStripSeparator sepCloseContainer;
    }
}