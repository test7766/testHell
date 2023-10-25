namespace WMSOffice.Window.BarCode
{
    partial class GenerateBarCodeWindow
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
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bntGen = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.btnApply = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCheck = new System.Windows.Forms.ToolStripButton();
            this.gridViewPortion = new System.Windows.Forms.DataGridView();
            this.portionIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lengthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isPrintedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.printDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recipientCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recipientNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receivedDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isActiveDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.portionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bC = new WMSOffice.Data.BC();
            this.portionTableAdapter = new WMSOffice.Data.BCTableAdapters.PortionTableAdapter();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pnlWarehouseFilter = new System.Windows.Forms.Panel();
            this.lblWarehouseDesc = new System.Windows.Forms.Label();
            this.stbWarehouseID = new WMSOffice.Controls.SearchTextBox();
            this.lblWarehouseID = new System.Windows.Forms.Label();
            this.tsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPortion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.portionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bC)).BeginInit();
            this.pnlWarehouseFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.toolStripSeparator1,
            this.bntGen,
            this.toolStripButton2,
            this.btnApply,
            this.toolStripSeparator2,
            this.btnCheck});
            this.tsMain.Location = new System.Drawing.Point(0, 40);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(990, 50);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(74, 47);
            this.btnRefresh.Text = "Обновить...";
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRefresh.Click += new System.EventHandler(this.RefreshClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 50);
            // 
            // bntGen
            // 
            this.bntGen.Image = global::WMSOffice.Properties.Resources.barcode;
            this.bntGen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bntGen.Name = "bntGen";
            this.bntGen.Size = new System.Drawing.Size(63, 47);
            this.bntGen.Text = "Создать...";
            this.bntGen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bntGen.ToolTipText = "Создать порцию штрих кодов";
            this.bntGen.Click += new System.EventHandler(this.GenerateClick);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::WMSOffice.Properties.Resources.checklist;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(59, 47);
            this.toolStripButton2.Text = "Выдать...";
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton2.Click += new System.EventHandler(this.GivenClick);
            // 
            // btnApply
            // 
            this.btnApply.Image = global::WMSOffice.Properties.Resources.icon_staff_pick;
            this.btnApply.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(90, 47);
            this.btnApply.Text = "Использована";
            this.btnApply.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 50);
            // 
            // btnCheck
            // 
            this.btnCheck.Image = global::WMSOffice.Properties.Resources.assign;
            this.btnCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(80, 47);
            this.btnCheck.Text = "Проверить...";
            this.btnCheck.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // gridViewPortion
            // 
            this.gridViewPortion.AllowUserToAddRows = false;
            this.gridViewPortion.AllowUserToDeleteRows = false;
            this.gridViewPortion.AutoGenerateColumns = false;
            this.gridViewPortion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridViewPortion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewPortion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.portionIDDataGridViewTextBoxColumn,
            this.TypeName,
            this.lengthDataGridViewTextBoxColumn,
            this.isPrintedDataGridViewCheckBoxColumn,
            this.printDateDataGridViewTextBoxColumn,
            this.recipientCodeDataGridViewTextBoxColumn,
            this.recipientNameDataGridViewTextBoxColumn,
            this.receivedDateDataGridViewTextBoxColumn,
            this.isActiveDataGridViewCheckBoxColumn});
            this.gridViewPortion.DataSource = this.portionBindingSource;
            this.gridViewPortion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridViewPortion.Location = new System.Drawing.Point(0, 90);
            this.gridViewPortion.Name = "gridViewPortion";
            this.gridViewPortion.ReadOnly = true;
            this.gridViewPortion.RowHeadersWidth = 10;
            this.gridViewPortion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridViewPortion.Size = new System.Drawing.Size(990, 490);
            this.gridViewPortion.TabIndex = 2;
            this.gridViewPortion.SelectionChanged += new System.EventHandler(this.gridViewPortion_SelectionChanged);
            // 
            // portionIDDataGridViewTextBoxColumn
            // 
            this.portionIDDataGridViewTextBoxColumn.DataPropertyName = "PortionID";
            this.portionIDDataGridViewTextBoxColumn.HeaderText = "№ порции";
            this.portionIDDataGridViewTextBoxColumn.Name = "portionIDDataGridViewTextBoxColumn";
            this.portionIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.portionIDDataGridViewTextBoxColumn.Width = 82;
            // 
            // TypeName
            // 
            this.TypeName.DataPropertyName = "TypeName";
            this.TypeName.HeaderText = "Тип порции";
            this.TypeName.Name = "TypeName";
            this.TypeName.ReadOnly = true;
            this.TypeName.Width = 90;
            // 
            // lengthDataGridViewTextBoxColumn
            // 
            this.lengthDataGridViewTextBoxColumn.DataPropertyName = "Length";
            this.lengthDataGridViewTextBoxColumn.HeaderText = "Кол-во";
            this.lengthDataGridViewTextBoxColumn.Name = "lengthDataGridViewTextBoxColumn";
            this.lengthDataGridViewTextBoxColumn.ReadOnly = true;
            this.lengthDataGridViewTextBoxColumn.Width = 66;
            // 
            // isPrintedDataGridViewCheckBoxColumn
            // 
            this.isPrintedDataGridViewCheckBoxColumn.DataPropertyName = "IsPrinted";
            this.isPrintedDataGridViewCheckBoxColumn.HeaderText = "Распечатан";
            this.isPrintedDataGridViewCheckBoxColumn.Name = "isPrintedDataGridViewCheckBoxColumn";
            this.isPrintedDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isPrintedDataGridViewCheckBoxColumn.Width = 72;
            // 
            // printDateDataGridViewTextBoxColumn
            // 
            this.printDateDataGridViewTextBoxColumn.DataPropertyName = "PrintDate";
            this.printDateDataGridViewTextBoxColumn.HeaderText = "Дата печати";
            this.printDateDataGridViewTextBoxColumn.Name = "printDateDataGridViewTextBoxColumn";
            this.printDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.printDateDataGridViewTextBoxColumn.Width = 95;
            // 
            // recipientCodeDataGridViewTextBoxColumn
            // 
            this.recipientCodeDataGridViewTextBoxColumn.DataPropertyName = "RecipientCode";
            this.recipientCodeDataGridViewTextBoxColumn.HeaderText = "RecipientCode";
            this.recipientCodeDataGridViewTextBoxColumn.Name = "recipientCodeDataGridViewTextBoxColumn";
            this.recipientCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.recipientCodeDataGridViewTextBoxColumn.Visible = false;
            this.recipientCodeDataGridViewTextBoxColumn.Width = 102;
            // 
            // recipientNameDataGridViewTextBoxColumn
            // 
            this.recipientNameDataGridViewTextBoxColumn.DataPropertyName = "RecipientName";
            this.recipientNameDataGridViewTextBoxColumn.HeaderText = "Получил";
            this.recipientNameDataGridViewTextBoxColumn.Name = "recipientNameDataGridViewTextBoxColumn";
            this.recipientNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.recipientNameDataGridViewTextBoxColumn.Width = 74;
            // 
            // receivedDateDataGridViewTextBoxColumn
            // 
            this.receivedDateDataGridViewTextBoxColumn.DataPropertyName = "ReceivedDate";
            this.receivedDateDataGridViewTextBoxColumn.HeaderText = "Дата выдачи";
            this.receivedDateDataGridViewTextBoxColumn.Name = "receivedDateDataGridViewTextBoxColumn";
            this.receivedDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.receivedDateDataGridViewTextBoxColumn.Width = 98;
            // 
            // isActiveDataGridViewCheckBoxColumn
            // 
            this.isActiveDataGridViewCheckBoxColumn.DataPropertyName = "IsActive";
            this.isActiveDataGridViewCheckBoxColumn.HeaderText = "IsActive";
            this.isActiveDataGridViewCheckBoxColumn.Name = "isActiveDataGridViewCheckBoxColumn";
            this.isActiveDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isActiveDataGridViewCheckBoxColumn.Visible = false;
            this.isActiveDataGridViewCheckBoxColumn.Width = 51;
            // 
            // portionBindingSource
            // 
            this.portionBindingSource.DataMember = "Portion";
            this.portionBindingSource.DataSource = this.bC;
            // 
            // bC
            // 
            this.bC.DataSetName = "BC";
            this.bC.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // portionTableAdapter
            // 
            this.portionTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PortionID";
            this.dataGridViewTextBoxColumn1.HeaderText = "№ порции";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Length";
            this.dataGridViewTextBoxColumn2.HeaderText = "Кол-во";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "IsPrinted";
            this.dataGridViewCheckBoxColumn1.HeaderText = "Распечатан";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "PrintDate";
            this.dataGridViewTextBoxColumn3.HeaderText = "Дата печати";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "RecipientCode";
            this.dataGridViewTextBoxColumn4.HeaderText = "RecipientCode";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "RecipientName";
            this.dataGridViewTextBoxColumn5.HeaderText = "Получил";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "ReceivedDate";
            this.dataGridViewTextBoxColumn6.HeaderText = "Дата выдачи";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.DataPropertyName = "IsActive";
            this.dataGridViewCheckBoxColumn2.HeaderText = "IsActive";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.ReadOnly = true;
            this.dataGridViewCheckBoxColumn2.Visible = false;
            // 
            // pnlWarehouseFilter
            // 
            this.pnlWarehouseFilter.BackColor = System.Drawing.SystemColors.Info;
            this.pnlWarehouseFilter.Controls.Add(this.lblWarehouseDesc);
            this.pnlWarehouseFilter.Controls.Add(this.stbWarehouseID);
            this.pnlWarehouseFilter.Controls.Add(this.lblWarehouseID);
            this.pnlWarehouseFilter.Location = new System.Drawing.Point(16, 132);
            this.pnlWarehouseFilter.Name = "pnlWarehouseFilter";
            this.pnlWarehouseFilter.Size = new System.Drawing.Size(170, 48);
            this.pnlWarehouseFilter.TabIndex = 3;
            // 
            // lblWarehouseDesc
            // 
            this.lblWarehouseDesc.AutoSize = true;
            this.lblWarehouseDesc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblWarehouseDesc.Location = new System.Drawing.Point(49, 29);
            this.lblWarehouseDesc.Name = "lblWarehouseDesc";
            this.lblWarehouseDesc.Size = new System.Drawing.Size(0, 13);
            this.lblWarehouseDesc.TabIndex = 2;
            // 
            // stbWarehouseID
            // 
            this.stbWarehouseID.Location = new System.Drawing.Point(52, 5);
            this.stbWarehouseID.Name = "stbWarehouseID";
            this.stbWarehouseID.ReadOnly = false;
            this.stbWarehouseID.Size = new System.Drawing.Size(110, 20);
            this.stbWarehouseID.TabIndex = 1;
            this.stbWarehouseID.UserID = ((long)(0));
            this.stbWarehouseID.Value = null;
            this.stbWarehouseID.ValueReferenceQuery = null;
            // 
            // lblWarehouseID
            // 
            this.lblWarehouseID.AutoSize = true;
            this.lblWarehouseID.Location = new System.Drawing.Point(3, 8);
            this.lblWarehouseID.Name = "lblWarehouseID";
            this.lblWarehouseID.Size = new System.Drawing.Size(41, 13);
            this.lblWarehouseID.TabIndex = 0;
            this.lblWarehouseID.Text = "Склад:";
            // 
            // GenerateBarCodeWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 580);
            this.Controls.Add(this.pnlWarehouseFilter);
            this.Controls.Add(this.gridViewPortion);
            this.Controls.Add(this.tsMain);
            this.Name = "GenerateBarCodeWindow";
            this.Text = "GenerateBarCodeWindow";
            this.Controls.SetChildIndex(this.tsMain, 0);
            this.Controls.SetChildIndex(this.gridViewPortion, 0);
            this.Controls.SetChildIndex(this.pnlWarehouseFilter, 0);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPortion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.portionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bC)).EndInit();
            this.pnlWarehouseFilter.ResumeLayout(false);
            this.pnlWarehouseFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton bntGen;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.DataGridView gridViewPortion;
        private System.Windows.Forms.BindingSource portionBindingSource;
        private WMSOffice.Data.BC bC;
        private WMSOffice.Data.BCTableAdapters.PortionTableAdapter portionTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.ToolStripButton btnApply;
        private System.Windows.Forms.DataGridViewTextBoxColumn portionIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn lengthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isPrintedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn printDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn recipientCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn recipientNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn receivedDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isActiveDataGridViewCheckBoxColumn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnCheck;
        private System.Windows.Forms.Panel pnlWarehouseFilter;
        private System.Windows.Forms.Label lblWarehouseDesc;
        private WMSOffice.Controls.SearchTextBox stbWarehouseID;
        private System.Windows.Forms.Label lblWarehouseID;
    }
}