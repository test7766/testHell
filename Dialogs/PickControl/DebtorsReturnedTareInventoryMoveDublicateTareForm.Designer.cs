namespace WMSOffice.Dialogs.PickControl
{
    partial class DebtorsReturnedTareInventoryMoveDublicateTareForm
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
            this.sbMoveDublicateTare = new System.Windows.Forms.ToolStripButton();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.dgvDublicateTare = new System.Windows.Forms.DataGridView();
            this.sSCCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tAREBARDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tARENAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sTATUSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rETTareInventoryInvDBLTasksInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pickControl = new WMSOffice.Data.PickControl();
            this.rET_Tare_Inventory_Inv_DBL_Tasks_InfoTableAdapter = new WMSOffice.Data.PickControlTableAdapters.RET_Tare_Inventory_Inv_DBL_Tasks_InfoTableAdapter();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.sbExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.pnlButtons.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDublicateTare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rETTareInventoryInvDBLTasksInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(1061, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1151, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 228);
            this.pnlButtons.Size = new System.Drawing.Size(794, 43);
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbRefreshData,
            this.toolStripSeparator1,
            this.sbMoveDublicateTare,
            this.toolStripSeparator2,
            this.sbExportToExcel});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(794, 39);
            this.tsMain.TabIndex = 103;
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
            // sbMoveDublicateTare
            // 
            this.sbMoveDublicateTare.Image = global::WMSOffice.Properties.Resources.link;
            this.sbMoveDublicateTare.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbMoveDublicateTare.Name = "sbMoveDublicateTare";
            this.sbMoveDublicateTare.Size = new System.Drawing.Size(167, 36);
            this.sbMoveDublicateTare.Text = "Создать\nперемещение";
            this.sbMoveDublicateTare.Click += new System.EventHandler(this.sbMoveDublicateTare_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContent.Controls.Add(this.dgvDublicateTare);
            this.pnlContent.Location = new System.Drawing.Point(0, 42);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(794, 180);
            this.pnlContent.TabIndex = 104;
            // 
            // dgvDublicateTare
            // 
            this.dgvDublicateTare.AllowUserToAddRows = false;
            this.dgvDublicateTare.AllowUserToDeleteRows = false;
            this.dgvDublicateTare.AllowUserToResizeRows = false;
            this.dgvDublicateTare.AutoGenerateColumns = false;
            this.dgvDublicateTare.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDublicateTare.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sSCCDataGridViewTextBoxColumn,
            this.tAREBARDataGridViewTextBoxColumn,
            this.tARENAMEDataGridViewTextBoxColumn,
            this.sTATUSDataGridViewTextBoxColumn});
            this.dgvDublicateTare.DataSource = this.rETTareInventoryInvDBLTasksInfoBindingSource;
            this.dgvDublicateTare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDublicateTare.Location = new System.Drawing.Point(0, 0);
            this.dgvDublicateTare.MultiSelect = false;
            this.dgvDublicateTare.Name = "dgvDublicateTare";
            this.dgvDublicateTare.ReadOnly = true;
            this.dgvDublicateTare.RowHeadersVisible = false;
            this.dgvDublicateTare.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDublicateTare.Size = new System.Drawing.Size(794, 180);
            this.dgvDublicateTare.TabIndex = 0;
            // 
            // sSCCDataGridViewTextBoxColumn
            // 
            this.sSCCDataGridViewTextBoxColumn.DataPropertyName = "SSCC";
            this.sSCCDataGridViewTextBoxColumn.HeaderText = "SSCC";
            this.sSCCDataGridViewTextBoxColumn.Name = "sSCCDataGridViewTextBoxColumn";
            this.sSCCDataGridViewTextBoxColumn.ReadOnly = true;
            this.sSCCDataGridViewTextBoxColumn.Width = 180;
            // 
            // tAREBARDataGridViewTextBoxColumn
            // 
            this.tAREBARDataGridViewTextBoxColumn.DataPropertyName = "TARE_BAR";
            this.tAREBARDataGridViewTextBoxColumn.HeaderText = "Ш/К тары";
            this.tAREBARDataGridViewTextBoxColumn.Name = "tAREBARDataGridViewTextBoxColumn";
            this.tAREBARDataGridViewTextBoxColumn.ReadOnly = true;
            this.tAREBARDataGridViewTextBoxColumn.Width = 200;
            // 
            // tARENAMEDataGridViewTextBoxColumn
            // 
            this.tARENAMEDataGridViewTextBoxColumn.DataPropertyName = "TARE_NAME";
            this.tARENAMEDataGridViewTextBoxColumn.HeaderText = "Тип тары";
            this.tARENAMEDataGridViewTextBoxColumn.Name = "tARENAMEDataGridViewTextBoxColumn";
            this.tARENAMEDataGridViewTextBoxColumn.ReadOnly = true;
            this.tARENAMEDataGridViewTextBoxColumn.Width = 180;
            // 
            // sTATUSDataGridViewTextBoxColumn
            // 
            this.sTATUSDataGridViewTextBoxColumn.DataPropertyName = "STATUS";
            this.sTATUSDataGridViewTextBoxColumn.HeaderText = "Статус ";
            this.sTATUSDataGridViewTextBoxColumn.Name = "sTATUSDataGridViewTextBoxColumn";
            this.sTATUSDataGridViewTextBoxColumn.ReadOnly = true;
            this.sTATUSDataGridViewTextBoxColumn.Width = 200;
            // 
            // rETTareInventoryInvDBLTasksInfoBindingSource
            // 
            this.rETTareInventoryInvDBLTasksInfoBindingSource.DataMember = "RET_Tare_Inventory_Inv_DBL_Tasks_Info";
            this.rETTareInventoryInvDBLTasksInfoBindingSource.DataSource = this.pickControl;
            // 
            // pickControl
            // 
            this.pickControl.DataSetName = "PickControl";
            this.pickControl.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rET_Tare_Inventory_Inv_DBL_Tasks_InfoTableAdapter
            // 
            this.rET_Tare_Inventory_Inv_DBL_Tasks_InfoTableAdapter.ClearBeforeFill = true;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // sbExportToExcel
            // 
            this.sbExportToExcel.Image = global::WMSOffice.Properties.Resources.Excel;
            this.sbExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbExportToExcel.Name = "sbExportToExcel";
            this.sbExportToExcel.Size = new System.Drawing.Size(126, 36);
            this.sbExportToExcel.Text = "Экспорт\nв Excel";
            this.sbExportToExcel.Click += new System.EventHandler(this.sbExportToExcel_Click);
            // 
            // DebtorsReturnedTareInventoryMoveDublicateTareForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 271);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.tsMain);
            this.Name = "DebtorsReturnedTareInventoryMoveDublicateTareForm";
            this.Text = "Перемещение дублей по инвентаризации";
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.tsMain, 0);
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.pnlButtons.ResumeLayout(false);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDublicateTare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rETTareInventoryInvDBLTasksInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton sbRefreshData;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.DataGridView dgvDublicateTare;
        private System.Windows.Forms.BindingSource rETTareInventoryInvDBLTasksInfoBindingSource;
        private WMSOffice.Data.PickControl pickControl;
        private WMSOffice.Data.PickControlTableAdapters.RET_Tare_Inventory_Inv_DBL_Tasks_InfoTableAdapter rET_Tare_Inventory_Inv_DBL_Tasks_InfoTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn sSCCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tAREBARDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tARENAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sTATUSDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton sbMoveDublicateTare;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton sbExportToExcel;
    }
}