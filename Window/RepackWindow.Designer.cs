namespace WMSOffice.Window
{
    partial class RepackWindow
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
            this.sbRefreshData = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.dgvCurrentTasks = new System.Windows.Forms.DataGridView();
            this.replTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zone_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Orders = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lines = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iMITMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nazvaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iORLOTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iommejDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barcodeYLDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uORGDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sOQSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datemodifedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iSLOCNDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lTBXCNTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lTURABDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bXNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CanUseBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SRUORG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REC_SOQS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.repackMainDisplayCurrentTasksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wH = new WMSOffice.Data.WH();
            this.repackMainDisplayCurrentTasksTableAdapter = new WMSOffice.Data.WHTableAdapters.RepackMainDisplayCurrentTasksTableAdapter();
            this.pnlMainLayout = new System.Windows.Forms.Panel();
            this.tsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentTasks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repackMainDisplayCurrentTasksBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).BeginInit();
            this.pnlMainLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbRefreshData,
            this.toolStripSeparator1,
            this.toolStripLabel1});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1341, 39);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
            // 
            // sbRefreshData
            // 
            this.sbRefreshData.Image = global::WMSOffice.Properties.Resources.refresh;
            this.sbRefreshData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbRefreshData.Name = "sbRefreshData";
            this.sbRefreshData.Size = new System.Drawing.Size(97, 36);
            this.sbRefreshData.Text = "Обновить";
            this.sbRefreshData.Click += new System.EventHandler(this.sbRefreshData_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(123, 36);
            this.toolStripLabel1.Text = "Отсканируйте ЖЭ,\r\nдоступную в буфере:";
            // 
            // dgvCurrentTasks
            // 
            this.dgvCurrentTasks.AllowUserToAddRows = false;
            this.dgvCurrentTasks.AllowUserToDeleteRows = false;
            this.dgvCurrentTasks.AllowUserToResizeRows = false;
            this.dgvCurrentTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCurrentTasks.AutoGenerateColumns = false;
            this.dgvCurrentTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCurrentTasks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.replTypeDataGridViewTextBoxColumn,
            this.zone_id,
            this.Orders,
            this.Lines,
            this.iMITMDataGridViewTextBoxColumn,
            this.nazvaDataGridViewTextBoxColumn,
            this.iORLOTDataGridViewTextBoxColumn,
            this.iommejDataGridViewTextBoxColumn,
            this.barcodeYLDataGridViewTextBoxColumn,
            this.uORGDataGridViewTextBoxColumn,
            this.sOQSDataGridViewTextBoxColumn,
            this.datemodifedDataGridViewTextBoxColumn,
            this.iSLOCNDataGridViewTextBoxColumn,
            this.lTBXCNTDataGridViewTextBoxColumn,
            this.lTURABDataGridViewTextBoxColumn,
            this.bXNAMEDataGridViewTextBoxColumn,
            this.CanUseBox,
            this.SRUORG,
            this.REC_SOQS});
            this.dgvCurrentTasks.DataSource = this.repackMainDisplayCurrentTasksBindingSource;
            this.dgvCurrentTasks.Location = new System.Drawing.Point(3, 42);
            this.dgvCurrentTasks.MultiSelect = false;
            this.dgvCurrentTasks.Name = "dgvCurrentTasks";
            this.dgvCurrentTasks.ReadOnly = true;
            this.dgvCurrentTasks.RowHeadersWidth = 30;
            this.dgvCurrentTasks.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCurrentTasks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCurrentTasks.Size = new System.Drawing.Size(1335, 443);
            this.dgvCurrentTasks.TabIndex = 2;
            this.dgvCurrentTasks.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvCurrentTasks_DataBindingComplete);
            // 
            // replTypeDataGridViewTextBoxColumn
            // 
            this.replTypeDataGridViewTextBoxColumn.DataPropertyName = "ReplType";
            this.replTypeDataGridViewTextBoxColumn.HeaderText = "Тип пополнения";
            this.replTypeDataGridViewTextBoxColumn.Name = "replTypeDataGridViewTextBoxColumn";
            this.replTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // zone_id
            // 
            this.zone_id.DataPropertyName = "zone_id";
            this.zone_id.HeaderText = "Код Зоны";
            this.zone_id.Name = "zone_id";
            this.zone_id.ReadOnly = true;
            // 
            // Orders
            // 
            this.Orders.DataPropertyName = "Orders";
            this.Orders.HeaderText = "Кол-во Заказов";
            this.Orders.Name = "Orders";
            this.Orders.ReadOnly = true;
            // 
            // Lines
            // 
            this.Lines.DataPropertyName = "Lines";
            this.Lines.HeaderText = "Кол-во Строк";
            this.Lines.Name = "Lines";
            this.Lines.ReadOnly = true;
            // 
            // iMITMDataGridViewTextBoxColumn
            // 
            this.iMITMDataGridViewTextBoxColumn.DataPropertyName = "IMITM";
            this.iMITMDataGridViewTextBoxColumn.HeaderText = "КНН";
            this.iMITMDataGridViewTextBoxColumn.Name = "iMITMDataGridViewTextBoxColumn";
            this.iMITMDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nazvaDataGridViewTextBoxColumn
            // 
            this.nazvaDataGridViewTextBoxColumn.DataPropertyName = "nazva";
            this.nazvaDataGridViewTextBoxColumn.HeaderText = "Препарат";
            this.nazvaDataGridViewTextBoxColumn.Name = "nazvaDataGridViewTextBoxColumn";
            this.nazvaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iORLOTDataGridViewTextBoxColumn
            // 
            this.iORLOTDataGridViewTextBoxColumn.DataPropertyName = "IORLOT";
            this.iORLOTDataGridViewTextBoxColumn.HeaderText = "Серия";
            this.iORLOTDataGridViewTextBoxColumn.Name = "iORLOTDataGridViewTextBoxColumn";
            this.iORLOTDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iommejDataGridViewTextBoxColumn
            // 
            this.iommejDataGridViewTextBoxColumn.DataPropertyName = "iommej";
            this.iommejDataGridViewTextBoxColumn.HeaderText = "Срок Годности";
            this.iommejDataGridViewTextBoxColumn.Name = "iommejDataGridViewTextBoxColumn";
            this.iommejDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // barcodeYLDataGridViewTextBoxColumn
            // 
            this.barcodeYLDataGridViewTextBoxColumn.DataPropertyName = "barcode_YL";
            this.barcodeYLDataGridViewTextBoxColumn.HeaderText = "Ш/К ЖЭ";
            this.barcodeYLDataGridViewTextBoxColumn.Name = "barcodeYLDataGridViewTextBoxColumn";
            this.barcodeYLDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // uORGDataGridViewTextBoxColumn
            // 
            this.uORGDataGridViewTextBoxColumn.DataPropertyName = "UORG";
            this.uORGDataGridViewTextBoxColumn.HeaderText = "Кол-во";
            this.uORGDataGridViewTextBoxColumn.Name = "uORGDataGridViewTextBoxColumn";
            this.uORGDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sOQSDataGridViewTextBoxColumn
            // 
            this.sOQSDataGridViewTextBoxColumn.DataPropertyName = "SOQS";
            this.sOQSDataGridViewTextBoxColumn.HeaderText = "Списано";
            this.sOQSDataGridViewTextBoxColumn.Name = "sOQSDataGridViewTextBoxColumn";
            this.sOQSDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // datemodifedDataGridViewTextBoxColumn
            // 
            this.datemodifedDataGridViewTextBoxColumn.DataPropertyName = "datemodifed";
            this.datemodifedDataGridViewTextBoxColumn.HeaderText = "Дата изменения";
            this.datemodifedDataGridViewTextBoxColumn.Name = "datemodifedDataGridViewTextBoxColumn";
            this.datemodifedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iSLOCNDataGridViewTextBoxColumn
            // 
            this.iSLOCNDataGridViewTextBoxColumn.DataPropertyName = "ISLOCN";
            this.iSLOCNDataGridViewTextBoxColumn.HeaderText = "Канал";
            this.iSLOCNDataGridViewTextBoxColumn.Name = "iSLOCNDataGridViewTextBoxColumn";
            this.iSLOCNDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lTBXCNTDataGridViewTextBoxColumn
            // 
            this.lTBXCNTDataGridViewTextBoxColumn.DataPropertyName = "LTBXCNT";
            this.lTBXCNTDataGridViewTextBoxColumn.HeaderText = "Вместимость канала ";
            this.lTBXCNTDataGridViewTextBoxColumn.Name = "lTBXCNTDataGridViewTextBoxColumn";
            this.lTBXCNTDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lTURABDataGridViewTextBoxColumn
            // 
            this.lTURABDataGridViewTextBoxColumn.DataPropertyName = "LTURAB";
            this.lTURABDataGridViewTextBoxColumn.HeaderText = "КНН ящика";
            this.lTURABDataGridViewTextBoxColumn.Name = "lTURABDataGridViewTextBoxColumn";
            this.lTURABDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bXNAMEDataGridViewTextBoxColumn
            // 
            this.bXNAMEDataGridViewTextBoxColumn.DataPropertyName = "BXNAME";
            this.bXNAMEDataGridViewTextBoxColumn.HeaderText = "Тип ящика";
            this.bXNAMEDataGridViewTextBoxColumn.Name = "bXNAMEDataGridViewTextBoxColumn";
            this.bXNAMEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // CanUseBox
            // 
            this.CanUseBox.DataPropertyName = "CanUseBox";
            this.CanUseBox.HeaderText = "Использовать ЗУ";
            this.CanUseBox.Name = "CanUseBox";
            this.CanUseBox.ReadOnly = true;
            this.CanUseBox.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CanUseBox.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // SRUORG
            // 
            this.SRUORG.DataPropertyName = "SRUORG";
            this.SRUORG.HeaderText = "В связке";
            this.SRUORG.Name = "SRUORG";
            this.SRUORG.ReadOnly = true;
            // 
            // REC_SOQS
            // 
            this.REC_SOQS.DataPropertyName = "REC_SOQS";
            this.REC_SOQS.HeaderText = "Рекоменд. кол-во";
            this.REC_SOQS.Name = "REC_SOQS";
            this.REC_SOQS.ReadOnly = true;
            // 
            // repackMainDisplayCurrentTasksBindingSource
            // 
            this.repackMainDisplayCurrentTasksBindingSource.DataMember = "RepackMainDisplayCurrentTasks";
            this.repackMainDisplayCurrentTasksBindingSource.DataSource = this.wH;
            // 
            // wH
            // 
            this.wH.DataSetName = "WH";
            this.wH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // repackMainDisplayCurrentTasksTableAdapter
            // 
            this.repackMainDisplayCurrentTasksTableAdapter.ClearBeforeFill = true;
            // 
            // pnlMainLayout
            // 
            this.pnlMainLayout.Controls.Add(this.tsMain);
            this.pnlMainLayout.Controls.Add(this.dgvCurrentTasks);
            this.pnlMainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainLayout.Location = new System.Drawing.Point(0, 40);
            this.pnlMainLayout.Name = "pnlMainLayout";
            this.pnlMainLayout.Size = new System.Drawing.Size(1341, 485);
            this.pnlMainLayout.TabIndex = 3;
            this.pnlMainLayout.Visible = false;
            // 
            // RepackWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1341, 525);
            this.Controls.Add(this.pnlMainLayout);
            this.Name = "RepackWindow";
            this.Text = "RepackWindow";
            this.Controls.SetChildIndex(this.pnlMainLayout, 0);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentTasks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repackMainDisplayCurrentTasksBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).EndInit();
            this.pnlMainLayout.ResumeLayout(false);
            this.pnlMainLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton sbRefreshData;
        private System.Windows.Forms.DataGridView dgvCurrentTasks;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.BindingSource repackMainDisplayCurrentTasksBindingSource;
        private WMSOffice.Data.WH wH;
        private WMSOffice.Data.WHTableAdapters.RepackMainDisplayCurrentTasksTableAdapter repackMainDisplayCurrentTasksTableAdapter;
        private System.Windows.Forms.Panel pnlMainLayout;
        private System.Windows.Forms.DataGridViewTextBoxColumn replTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn zone_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Orders;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lines;
        private System.Windows.Forms.DataGridViewTextBoxColumn iMITMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nazvaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iORLOTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iommejDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcodeYLDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uORGDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sOQSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datemodifedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iSLOCNDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lTBXCNTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lTURABDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bXNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CanUseBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn SRUORG;
        private System.Windows.Forms.DataGridViewTextBoxColumn REC_SOQS;
    }
}