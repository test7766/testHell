namespace WMSOffice.Dialogs.WH
{
    partial class RepackItemAddToBox
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
            this.tsMainToolbar = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.wH = new WMSOffice.Data.WH();
            this.repackMainDisplayCurrentTasksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.repackMainDisplayCurrentTasksTableAdapter = new WMSOffice.Data.WHTableAdapters.RepackMainDisplayCurrentTasksTableAdapter();
            this.dgvCurrentTasks = new System.Windows.Forms.DataGridView();
            this.replTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.pnlButtons.SuspendLayout();
            this.tsMainToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repackMainDisplayCurrentTasksBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentTasks)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(1505, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1595, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 329);
            this.pnlButtons.Size = new System.Drawing.Size(794, 43);
            // 
            // tsMainToolbar
            // 
            this.tsMainToolbar.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsMainToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.tsMainToolbar.Location = new System.Drawing.Point(0, 0);
            this.tsMainToolbar.Name = "tsMainToolbar";
            this.tsMainToolbar.Padding = new System.Windows.Forms.Padding(0, 0, 1, 5);
            this.tsMainToolbar.Size = new System.Drawing.Size(794, 38);
            this.tsMainToolbar.TabIndex = 103;
            this.tsMainToolbar.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(123, 30);
            this.toolStripLabel1.Text = "Отсканируйте ЖЭ,\r\nдоступную в буфере:";
            // 
            // wH
            // 
            this.wH.DataSetName = "WH";
            this.wH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // repackMainDisplayCurrentTasksBindingSource
            // 
            this.repackMainDisplayCurrentTasksBindingSource.DataMember = "RepackMainDisplayCurrentTasks";
            this.repackMainDisplayCurrentTasksBindingSource.DataSource = this.wH;
            // 
            // repackMainDisplayCurrentTasksTableAdapter
            // 
            this.repackMainDisplayCurrentTasksTableAdapter.ClearBeforeFill = true;
            // 
            // dgvCurrentTasks
            // 
            this.dgvCurrentTasks.AllowUserToAddRows = false;
            this.dgvCurrentTasks.AllowUserToDeleteRows = false;
            this.dgvCurrentTasks.AllowUserToResizeRows = false;
            this.dgvCurrentTasks.AutoGenerateColumns = false;
            this.dgvCurrentTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCurrentTasks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.replTypeDataGridViewTextBoxColumn,
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
            this.dgvCurrentTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCurrentTasks.Location = new System.Drawing.Point(0, 38);
            this.dgvCurrentTasks.MultiSelect = false;
            this.dgvCurrentTasks.Name = "dgvCurrentTasks";
            this.dgvCurrentTasks.ReadOnly = true;
            this.dgvCurrentTasks.RowHeadersWidth = 30;
            this.dgvCurrentTasks.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCurrentTasks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCurrentTasks.Size = new System.Drawing.Size(794, 291);
            this.dgvCurrentTasks.TabIndex = 104;
            // 
            // replTypeDataGridViewTextBoxColumn
            // 
            this.replTypeDataGridViewTextBoxColumn.DataPropertyName = "ReplType";
            this.replTypeDataGridViewTextBoxColumn.HeaderText = "Тип пополнения";
            this.replTypeDataGridViewTextBoxColumn.Name = "replTypeDataGridViewTextBoxColumn";
            this.replTypeDataGridViewTextBoxColumn.ReadOnly = true;
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
            // RepackItemAddToBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 372);
            this.Controls.Add(this.dgvCurrentTasks);
            this.Controls.Add(this.tsMainToolbar);
            this.Name = "RepackItemAddToBox";
            this.Text = "Отсканируйте ЖЭ";
            this.Load += new System.EventHandler(this.RepackItemAddToBox_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RepackItemAddToBox_FormClosing);
            this.Controls.SetChildIndex(this.tsMainToolbar, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.dgvCurrentTasks, 0);
            this.pnlButtons.ResumeLayout(false);
            this.tsMainToolbar.ResumeLayout(false);
            this.tsMainToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repackMainDisplayCurrentTasksBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentTasks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMainToolbar;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private WMSOffice.Data.WH wH;
        private System.Windows.Forms.BindingSource repackMainDisplayCurrentTasksBindingSource;
        private WMSOffice.Data.WHTableAdapters.RepackMainDisplayCurrentTasksTableAdapter repackMainDisplayCurrentTasksTableAdapter;
        private System.Windows.Forms.DataGridView dgvCurrentTasks;
        private System.Windows.Forms.DataGridViewTextBoxColumn replTypeDataGridViewTextBoxColumn;
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