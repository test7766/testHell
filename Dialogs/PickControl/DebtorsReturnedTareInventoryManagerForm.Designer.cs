namespace WMSOffice.Dialogs.PickControl
{
    partial class DebtorsReturnedTareInventoryManagerForm
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
            this.sbRunChecks = new System.Windows.Forms.ToolStripButton();
            this.sbOpenCheckDetails = new System.Windows.Forms.ToolStripButton();
            this.sbStartInventory = new System.Windows.Forms.ToolStripButton();
            this.sbSetTareShortageOnInitRecounts = new System.Windows.Forms.ToolStripButton();
            this.sbMoveDublicateTare = new System.Windows.Forms.ToolStripButton();
            this.sbRunFourthRecalculation = new System.Windows.Forms.ToolStripButton();
            this.sbCloseInventory = new System.Windows.Forms.ToolStripButton();
            this.sbOpenDetails = new System.Windows.Forms.ToolStripButton();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.dgvInventoryDocs = new System.Windows.Forms.DataGridView();
            this.inventorynumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filialNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creatorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inventoryDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rETTareInventoryInvDocsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pickControl = new WMSOffice.Data.PickControl();
            this.rET_Tare_Inventory_Inv_DocsTableAdapter = new WMSOffice.Data.PickControlTableAdapters.RET_Tare_Inventory_Inv_DocsTableAdapter();
            this.pnlButtons.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventoryDocs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rETTareInventoryInvDocsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(3149, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(3239, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 428);
            this.pnlButtons.Size = new System.Drawing.Size(1094, 43);
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbRefreshData,
            this.toolStripSeparator1,
            this.sbRunChecks,
            this.sbOpenCheckDetails,
            this.sbStartInventory,
            this.sbSetTareShortageOnInitRecounts,
            this.sbMoveDublicateTare,
            this.sbRunFourthRecalculation,
            this.sbCloseInventory,
            this.sbOpenDetails});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1094, 39);
            this.tsMain.TabIndex = 101;
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
            // sbRunChecks
            // 
            this.sbRunChecks.Image = global::WMSOffice.Properties.Resources.assign;
            this.sbRunChecks.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbRunChecks.Name = "sbRunChecks";
            this.sbRunChecks.Size = new System.Drawing.Size(96, 36);
            this.sbRunChecks.Text = "Запуск\nпроверок";
            this.sbRunChecks.Click += new System.EventHandler(this.sbRunChecks_Click);
            // 
            // sbOpenCheckDetails
            // 
            this.sbOpenCheckDetails.Image = global::WMSOffice.Properties.Resources.checklist;
            this.sbOpenCheckDetails.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbOpenCheckDetails.Name = "sbOpenCheckDetails";
            this.sbOpenCheckDetails.Size = new System.Drawing.Size(96, 36);
            this.sbOpenCheckDetails.Text = "Статусы\nпроверок";
            this.sbOpenCheckDetails.Click += new System.EventHandler(this.sbOpenCheckDetails_Click);
            // 
            // sbStartInventory
            // 
            this.sbStartInventory.Image = global::WMSOffice.Properties.Resources.start;
            this.sbStartInventory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbStartInventory.Name = "sbStartInventory";
            this.sbStartInventory.Size = new System.Drawing.Size(133, 36);
            this.sbStartInventory.Text = "Запуск\nинвентаризации";
            this.sbStartInventory.Click += new System.EventHandler(this.sbStartInventory_Click);
            // 
            // sbSetTareShortageOnInitRecounts
            // 
            this.sbSetTareShortageOnInitRecounts.Image = global::WMSOffice.Properties.Resources.yellow_triangle;
            this.sbSetTareShortageOnInitRecounts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbSetTareShortageOnInitRecounts.Name = "sbSetTareShortageOnInitRecounts";
            this.sbSetTareShortageOnInitRecounts.Size = new System.Drawing.Size(133, 36);
            this.sbSetTareShortageOnInitRecounts.Text = "Тара не найдена\nпосле 1-2 счета";
            this.sbSetTareShortageOnInitRecounts.Click += new System.EventHandler(this.sbSetTareShortageOnInitRecounts_Click);
            // 
            // sbMoveDublicateTare
            // 
            this.sbMoveDublicateTare.Image = global::WMSOffice.Properties.Resources.link;
            this.sbMoveDublicateTare.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbMoveDublicateTare.Name = "sbMoveDublicateTare";
            this.sbMoveDublicateTare.Size = new System.Drawing.Size(123, 36);
            this.sbMoveDublicateTare.Text = "Перемещение\nдублей";
            this.sbMoveDublicateTare.Click += new System.EventHandler(this.sbMoveDublicateTare_Click);
            // 
            // sbRunFourthRecalculation
            // 
            this.sbRunFourthRecalculation.Image = global::WMSOffice.Properties.Resources.Calc;
            this.sbRunFourthRecalculation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbRunFourthRecalculation.Name = "sbRunFourthRecalculation";
            this.sbRunFourthRecalculation.Size = new System.Drawing.Size(107, 36);
            this.sbRunFourthRecalculation.Text = "Запуск 4-го\nпересчета";
            this.sbRunFourthRecalculation.Click += new System.EventHandler(this.sbRunFourthRecalculation_Click);
            // 
            // sbCloseInventory
            // 
            this.sbCloseInventory.Image = global::WMSOffice.Properties.Resources.finish_process;
            this.sbCloseInventory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbCloseInventory.Name = "sbCloseInventory";
            this.sbCloseInventory.Size = new System.Drawing.Size(133, 36);
            this.sbCloseInventory.Text = "Закрытие\nинвентаризации";
            this.sbCloseInventory.Click += new System.EventHandler(this.sbCloseInventory_Click);
            // 
            // sbOpenDetails
            // 
            this.sbOpenDetails.Image = global::WMSOffice.Properties.Resources.monitoring;
            this.sbOpenDetails.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbOpenDetails.Name = "sbOpenDetails";
            this.sbOpenDetails.Size = new System.Drawing.Size(133, 36);
            this.sbOpenDetails.Text = "Детали\nинвентаризации";
            this.sbOpenDetails.Click += new System.EventHandler(this.sbOpenDetails_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContent.Controls.Add(this.dgvInventoryDocs);
            this.pnlContent.Location = new System.Drawing.Point(0, 42);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1094, 380);
            this.pnlContent.TabIndex = 102;
            // 
            // dgvInventoryDocs
            // 
            this.dgvInventoryDocs.AllowUserToAddRows = false;
            this.dgvInventoryDocs.AllowUserToDeleteRows = false;
            this.dgvInventoryDocs.AllowUserToResizeRows = false;
            this.dgvInventoryDocs.AutoGenerateColumns = false;
            this.dgvInventoryDocs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventoryDocs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.inventorynumberDataGridViewTextBoxColumn,
            this.filialNameDataGridViewTextBoxColumn,
            this.statusIDDataGridViewTextBoxColumn,
            this.statusNameDataGridViewTextBoxColumn,
            this.creatorDataGridViewTextBoxColumn,
            this.inventoryDateDataGridViewTextBoxColumn});
            this.dgvInventoryDocs.DataSource = this.rETTareInventoryInvDocsBindingSource;
            this.dgvInventoryDocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInventoryDocs.Location = new System.Drawing.Point(0, 0);
            this.dgvInventoryDocs.MultiSelect = false;
            this.dgvInventoryDocs.Name = "dgvInventoryDocs";
            this.dgvInventoryDocs.ReadOnly = true;
            this.dgvInventoryDocs.RowHeadersVisible = false;
            this.dgvInventoryDocs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventoryDocs.Size = new System.Drawing.Size(1094, 380);
            this.dgvInventoryDocs.TabIndex = 0;
            this.dgvInventoryDocs.SelectionChanged += new System.EventHandler(this.dgvInventoryDocs_SelectionChanged);
            // 
            // inventorynumberDataGridViewTextBoxColumn
            // 
            this.inventorynumberDataGridViewTextBoxColumn.DataPropertyName = "Inventory_number";
            this.inventorynumberDataGridViewTextBoxColumn.HeaderText = "№ инв.";
            this.inventorynumberDataGridViewTextBoxColumn.Name = "inventorynumberDataGridViewTextBoxColumn";
            this.inventorynumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.inventorynumberDataGridViewTextBoxColumn.Width = 70;
            // 
            // filialNameDataGridViewTextBoxColumn
            // 
            this.filialNameDataGridViewTextBoxColumn.DataPropertyName = "Filial_Name";
            this.filialNameDataGridViewTextBoxColumn.HeaderText = "Склад";
            this.filialNameDataGridViewTextBoxColumn.Name = "filialNameDataGridViewTextBoxColumn";
            this.filialNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.filialNameDataGridViewTextBoxColumn.Width = 300;
            // 
            // statusIDDataGridViewTextBoxColumn
            // 
            this.statusIDDataGridViewTextBoxColumn.DataPropertyName = "Status_ID";
            this.statusIDDataGridViewTextBoxColumn.HeaderText = "Код ст.";
            this.statusIDDataGridViewTextBoxColumn.Name = "statusIDDataGridViewTextBoxColumn";
            this.statusIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusIDDataGridViewTextBoxColumn.Width = 70;
            // 
            // statusNameDataGridViewTextBoxColumn
            // 
            this.statusNameDataGridViewTextBoxColumn.DataPropertyName = "Status_Name";
            this.statusNameDataGridViewTextBoxColumn.HeaderText = "Описание статуса";
            this.statusNameDataGridViewTextBoxColumn.Name = "statusNameDataGridViewTextBoxColumn";
            this.statusNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusNameDataGridViewTextBoxColumn.Width = 200;
            // 
            // creatorDataGridViewTextBoxColumn
            // 
            this.creatorDataGridViewTextBoxColumn.DataPropertyName = "creator";
            this.creatorDataGridViewTextBoxColumn.HeaderText = "Инициатор";
            this.creatorDataGridViewTextBoxColumn.Name = "creatorDataGridViewTextBoxColumn";
            this.creatorDataGridViewTextBoxColumn.ReadOnly = true;
            this.creatorDataGridViewTextBoxColumn.Width = 250;
            // 
            // inventoryDateDataGridViewTextBoxColumn
            // 
            this.inventoryDateDataGridViewTextBoxColumn.DataPropertyName = "InventoryDate";
            this.inventoryDateDataGridViewTextBoxColumn.HeaderText = "Дата проведения";
            this.inventoryDateDataGridViewTextBoxColumn.Name = "inventoryDateDataGridViewTextBoxColumn";
            this.inventoryDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.inventoryDateDataGridViewTextBoxColumn.Width = 130;
            // 
            // rETTareInventoryInvDocsBindingSource
            // 
            this.rETTareInventoryInvDocsBindingSource.DataMember = "RET_Tare_Inventory_Inv_Docs";
            this.rETTareInventoryInvDocsBindingSource.DataSource = this.pickControl;
            // 
            // pickControl
            // 
            this.pickControl.DataSetName = "PickControl";
            this.pickControl.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rET_Tare_Inventory_Inv_DocsTableAdapter
            // 
            this.rET_Tare_Inventory_Inv_DocsTableAdapter.ClearBeforeFill = true;
            // 
            // DebtorsReturnedTareInventoryManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 471);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.pnlContent);
            this.Name = "DebtorsReturnedTareInventoryManagerForm";
            this.Text = "Менеджер инвентаризации ОТ";
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.Controls.SetChildIndex(this.tsMain, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventoryDocs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rETTareInventoryInvDocsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton sbRefreshData;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.DataGridView dgvInventoryDocs;
        private System.Windows.Forms.BindingSource rETTareInventoryInvDocsBindingSource;
        private WMSOffice.Data.PickControl pickControl;
        private WMSOffice.Data.PickControlTableAdapters.RET_Tare_Inventory_Inv_DocsTableAdapter rET_Tare_Inventory_Inv_DocsTableAdapter;
        private System.Windows.Forms.ToolStripButton sbRunChecks;
        private System.Windows.Forms.ToolStripButton sbOpenCheckDetails;
        private System.Windows.Forms.ToolStripButton sbStartInventory;
        private System.Windows.Forms.ToolStripButton sbMoveDublicateTare;
        private System.Windows.Forms.ToolStripButton sbRunFourthRecalculation;
        private System.Windows.Forms.ToolStripButton sbCloseInventory;
        private System.Windows.Forms.DataGridViewTextBoxColumn inventorynumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn filialNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn creatorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn inventoryDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripButton sbSetTareShortageOnInitRecounts;
        private System.Windows.Forms.ToolStripButton sbOpenDetails;
    }
}