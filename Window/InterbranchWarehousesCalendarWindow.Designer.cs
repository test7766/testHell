namespace WMSOffice.Window
{
    partial class InterbranchWarehousesCalendarWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.btnLoad = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.dgvCalendar = new System.Windows.Forms.DataGridView();
            this.mCUNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v3DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v4DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v5DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v6DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v7DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.miEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.miDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.gWCalendarBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.interbranch = new WMSOffice.Data.Interbranch();
            this.pnlWarehouseFilter = new System.Windows.Forms.Panel();
            this.lblWarehouseDesc = new System.Windows.Forms.Label();
            this.stbWarehouseID = new WMSOffice.Controls.SearchTextBox();
            this.lblWarehouseID = new System.Windows.Forms.Label();
            this.gW_CalendarTableAdapter = new WMSOffice.Data.InterbranchTableAdapters.GW_CalendarTableAdapter();
            this.pnlShipmentDateFilter = new System.Windows.Forms.Panel();
            this.dtpShipmentDate = new System.Windows.Forms.DateTimePicker();
            this.lblShipmentDate = new System.Windows.Forms.Label();
            this.tsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalendar)).BeginInit();
            this.cmsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gWCalendarBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.interbranch)).BeginInit();
            this.pnlWarehouseFilter.SuspendLayout();
            this.pnlShipmentDateFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLoad,
            this.toolStripSeparator1,
            this.btnExport});
            this.tsMain.Location = new System.Drawing.Point(0, 40);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(740, 50);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
            // 
            // btnLoad
            // 
            this.btnLoad.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(74, 47);
            this.btnLoad.Text = "Обновить...";
            this.btnLoad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 50);
            // 
            // btnExport
            // 
            this.btnExport.Image = global::WMSOffice.Properties.Resources.Excel;
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(65, 47);
            this.btnExport.Text = "Экспорт...";
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // dgvCalendar
            // 
            this.dgvCalendar.AllowUserToAddRows = false;
            this.dgvCalendar.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvCalendar.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCalendar.AutoGenerateColumns = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCalendar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCalendar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCalendar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mCUNameDataGridViewTextBoxColumn,
            this.v1DataGridViewTextBoxColumn,
            this.v2DataGridViewTextBoxColumn,
            this.v3DataGridViewTextBoxColumn,
            this.v4DataGridViewTextBoxColumn,
            this.v5DataGridViewTextBoxColumn,
            this.v6DataGridViewTextBoxColumn,
            this.v7DataGridViewTextBoxColumn});
            this.dgvCalendar.ContextMenuStrip = this.cmsMain;
            this.dgvCalendar.DataSource = this.gWCalendarBindingSource;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCalendar.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCalendar.Location = new System.Drawing.Point(0, 90);
            this.dgvCalendar.MultiSelect = false;
            this.dgvCalendar.Name = "dgvCalendar";
            this.dgvCalendar.ReadOnly = true;
            this.dgvCalendar.RowHeadersVisible = false;
            this.dgvCalendar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvCalendar.Size = new System.Drawing.Size(740, 298);
            this.dgvCalendar.TabIndex = 2;
            this.dgvCalendar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvCalendar_MouseDown);
            this.dgvCalendar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCalendar_CellDoubleClick);
            this.dgvCalendar.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvCalendar_CellFormatting);
            this.dgvCalendar.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvCalendar_DataBindingComplete);
            // 
            // mCUNameDataGridViewTextBoxColumn
            // 
            this.mCUNameDataGridViewTextBoxColumn.DataPropertyName = "MCU_Name";
            this.mCUNameDataGridViewTextBoxColumn.HeaderText = "Склад доставки";
            this.mCUNameDataGridViewTextBoxColumn.Name = "mCUNameDataGridViewTextBoxColumn";
            this.mCUNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.mCUNameDataGridViewTextBoxColumn.Width = 220;
            // 
            // v1DataGridViewTextBoxColumn
            // 
            this.v1DataGridViewTextBoxColumn.DataPropertyName = "V1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            this.v1DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.v1DataGridViewTextBoxColumn.HeaderText = "V1";
            this.v1DataGridViewTextBoxColumn.Name = "v1DataGridViewTextBoxColumn";
            this.v1DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // v2DataGridViewTextBoxColumn
            // 
            this.v2DataGridViewTextBoxColumn.DataPropertyName = "V2";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            this.v2DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.v2DataGridViewTextBoxColumn.HeaderText = "V2";
            this.v2DataGridViewTextBoxColumn.Name = "v2DataGridViewTextBoxColumn";
            this.v2DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // v3DataGridViewTextBoxColumn
            // 
            this.v3DataGridViewTextBoxColumn.DataPropertyName = "V3";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            this.v3DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.v3DataGridViewTextBoxColumn.HeaderText = "V3";
            this.v3DataGridViewTextBoxColumn.Name = "v3DataGridViewTextBoxColumn";
            this.v3DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // v4DataGridViewTextBoxColumn
            // 
            this.v4DataGridViewTextBoxColumn.DataPropertyName = "V4";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            this.v4DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.v4DataGridViewTextBoxColumn.HeaderText = "V4";
            this.v4DataGridViewTextBoxColumn.Name = "v4DataGridViewTextBoxColumn";
            this.v4DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // v5DataGridViewTextBoxColumn
            // 
            this.v5DataGridViewTextBoxColumn.DataPropertyName = "V5";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            this.v5DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.v5DataGridViewTextBoxColumn.HeaderText = "V5";
            this.v5DataGridViewTextBoxColumn.Name = "v5DataGridViewTextBoxColumn";
            this.v5DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // v6DataGridViewTextBoxColumn
            // 
            this.v6DataGridViewTextBoxColumn.DataPropertyName = "V6";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N0";
            this.v6DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.v6DataGridViewTextBoxColumn.HeaderText = "V6";
            this.v6DataGridViewTextBoxColumn.Name = "v6DataGridViewTextBoxColumn";
            this.v6DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // v7DataGridViewTextBoxColumn
            // 
            this.v7DataGridViewTextBoxColumn.DataPropertyName = "V7";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N0";
            this.v7DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.v7DataGridViewTextBoxColumn.HeaderText = "V7";
            this.v7DataGridViewTextBoxColumn.Name = "v7DataGridViewTextBoxColumn";
            this.v7DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cmsMain
            // 
            this.cmsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAdd,
            this.toolStripSeparator2,
            this.miEdit,
            this.toolStripSeparator3,
            this.miDelete});
            this.cmsMain.Name = "cmsMain";
            this.cmsMain.Size = new System.Drawing.Size(155, 82);
            this.cmsMain.Opening += new System.ComponentModel.CancelEventHandler(this.cmsMain_Opening);
            // 
            // miAdd
            // 
            this.miAdd.Image = global::WMSOffice.Properties.Resources.add;
            this.miAdd.Name = "miAdd";
            this.miAdd.Size = new System.Drawing.Size(154, 22);
            this.miAdd.Text = "Добавить";
            this.miAdd.Click += new System.EventHandler(this.miAdd_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(151, 6);
            // 
            // miEdit
            // 
            this.miEdit.Image = global::WMSOffice.Properties.Resources.Edit_10x10;
            this.miEdit.Name = "miEdit";
            this.miEdit.Size = new System.Drawing.Size(154, 22);
            this.miEdit.Text = "Редактировать";
            this.miEdit.Click += new System.EventHandler(this.miEdit_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(151, 6);
            // 
            // miDelete
            // 
            this.miDelete.Image = global::WMSOffice.Properties.Resources.close;
            this.miDelete.Name = "miDelete";
            this.miDelete.Size = new System.Drawing.Size(154, 22);
            this.miDelete.Text = "Удалить";
            this.miDelete.Click += new System.EventHandler(this.miDelete_Click);
            // 
            // gWCalendarBindingSource
            // 
            this.gWCalendarBindingSource.DataMember = "GW_Calendar";
            this.gWCalendarBindingSource.DataSource = this.interbranch;
            // 
            // interbranch
            // 
            this.interbranch.DataSetName = "Interbranch";
            this.interbranch.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pnlWarehouseFilter
            // 
            this.pnlWarehouseFilter.BackColor = System.Drawing.SystemColors.Info;
            this.pnlWarehouseFilter.Controls.Add(this.lblWarehouseDesc);
            this.pnlWarehouseFilter.Controls.Add(this.stbWarehouseID);
            this.pnlWarehouseFilter.Controls.Add(this.lblWarehouseID);
            this.pnlWarehouseFilter.Location = new System.Drawing.Point(26, 132);
            this.pnlWarehouseFilter.Name = "pnlWarehouseFilter";
            this.pnlWarehouseFilter.Size = new System.Drawing.Size(180, 48);
            this.pnlWarehouseFilter.TabIndex = 5;
            // 
            // lblWarehouseDesc
            // 
            this.lblWarehouseDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWarehouseDesc.AutoSize = true;
            this.lblWarehouseDesc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblWarehouseDesc.Location = new System.Drawing.Point(59, 29);
            this.lblWarehouseDesc.Name = "lblWarehouseDesc";
            this.lblWarehouseDesc.Size = new System.Drawing.Size(0, 13);
            this.lblWarehouseDesc.TabIndex = 2;
            // 
            // stbWarehouseID
            // 
            this.stbWarehouseID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stbWarehouseID.Location = new System.Drawing.Point(62, 5);
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
            this.lblWarehouseID.Location = new System.Drawing.Point(3, 5);
            this.lblWarehouseID.Name = "lblWarehouseID";
            this.lblWarehouseID.Size = new System.Drawing.Size(55, 26);
            this.lblWarehouseID.TabIndex = 0;
            this.lblWarehouseID.Text = "Склад \r\nотгрузки:";
            // 
            // gW_CalendarTableAdapter
            // 
            this.gW_CalendarTableAdapter.ClearBeforeFill = true;
            // 
            // pnlShipmentDateFilter
            // 
            this.pnlShipmentDateFilter.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlShipmentDateFilter.Controls.Add(this.dtpShipmentDate);
            this.pnlShipmentDateFilter.Controls.Add(this.lblShipmentDate);
            this.pnlShipmentDateFilter.Location = new System.Drawing.Point(212, 132);
            this.pnlShipmentDateFilter.Name = "pnlShipmentDateFilter";
            this.pnlShipmentDateFilter.Size = new System.Drawing.Size(180, 48);
            this.pnlShipmentDateFilter.TabIndex = 6;
            // 
            // dtpShipmentDate
            // 
            this.dtpShipmentDate.CustomFormat = "dd.MM.yyyy";
            this.dtpShipmentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpShipmentDate.Location = new System.Drawing.Point(62, 5);
            this.dtpShipmentDate.Name = "dtpShipmentDate";
            this.dtpShipmentDate.Size = new System.Drawing.Size(110, 20);
            this.dtpShipmentDate.TabIndex = 1;
            // 
            // lblShipmentDate
            // 
            this.lblShipmentDate.AutoSize = true;
            this.lblShipmentDate.Location = new System.Drawing.Point(3, 5);
            this.lblShipmentDate.Name = "lblShipmentDate";
            this.lblShipmentDate.Size = new System.Drawing.Size(55, 26);
            this.lblShipmentDate.TabIndex = 0;
            this.lblShipmentDate.Text = "Дата \r\nотгрузки:";
            // 
            // InterbranchWarehousesCalendarWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 388);
            this.Controls.Add(this.pnlShipmentDateFilter);
            this.Controls.Add(this.pnlWarehouseFilter);
            this.Controls.Add(this.dgvCalendar);
            this.Controls.Add(this.tsMain);
            this.Name = "InterbranchWarehousesCalendarWindow";
            this.Text = "InterbranchWarehousesCalendarWindow";
            this.Controls.SetChildIndex(this.tsMain, 0);
            this.Controls.SetChildIndex(this.dgvCalendar, 0);
            this.Controls.SetChildIndex(this.pnlWarehouseFilter, 0);
            this.Controls.SetChildIndex(this.pnlShipmentDateFilter, 0);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalendar)).EndInit();
            this.cmsMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gWCalendarBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.interbranch)).EndInit();
            this.pnlWarehouseFilter.ResumeLayout(false);
            this.pnlWarehouseFilter.PerformLayout();
            this.pnlShipmentDateFilter.ResumeLayout(false);
            this.pnlShipmentDateFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btnLoad;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnExport;
        private System.Windows.Forms.DataGridView dgvCalendar;
        private System.Windows.Forms.Panel pnlWarehouseFilter;
        private System.Windows.Forms.Label lblWarehouseDesc;
        private WMSOffice.Controls.SearchTextBox stbWarehouseID;
        private System.Windows.Forms.Label lblWarehouseID;
        private System.Windows.Forms.BindingSource gWCalendarBindingSource;
        private WMSOffice.Data.Interbranch interbranch;
        private WMSOffice.Data.InterbranchTableAdapters.GW_CalendarTableAdapter gW_CalendarTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn mCUNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn v1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn v2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn v3DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn v4DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn v5DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn v6DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn v7DataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel pnlShipmentDateFilter;
        private System.Windows.Forms.DateTimePicker dtpShipmentDate;
        private System.Windows.Forms.Label lblShipmentDate;
        private System.Windows.Forms.ContextMenuStrip cmsMain;
        private System.Windows.Forms.ToolStripMenuItem miAdd;
        private System.Windows.Forms.ToolStripMenuItem miEdit;
        private System.Windows.Forms.ToolStripMenuItem miDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}