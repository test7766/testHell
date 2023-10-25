namespace WMSOffice.Window
{
    partial class ColdChainTermoBagPackingWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColdChainTermoBagPackingWindow));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStripDoc = new System.Windows.Forms.ToolStrip();
            this.btnRefreshGoodsList = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUseNextTermoBag = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCompleteGoodsPacking = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUndoTermoBagPacking = new System.Windows.Forms.ToolStripButton();
            this.dgvPickSlipContent = new System.Windows.Forms.DataGridView();
            this.peronIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.routeListNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.relatedOrderTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.relatedPoSoNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.relatedPickSlipNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documentTypeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documentIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.routeListPickSlipBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.coldChain = new WMSOffice.Data.ColdChain();
            this.tbScanner = new WMSOffice.Controls.TextBoxScaner();
            this.pnlTools = new System.Windows.Forms.Panel();
            this.lblCurrentTermoBag = new System.Windows.Forms.Label();
            this.lblScannerProcessCaption = new System.Windows.Forms.Label();
            this.routeListPickSlipTableAdapter = new WMSOffice.Data.ColdChainTableAdapters.RouteListPickSlipTableAdapter();
            this.toolStripDoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPickSlipContent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.routeListPickSlipBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coldChain)).BeginInit();
            this.pnlTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripDoc
            // 
            this.toolStripDoc.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStripDoc.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStripDoc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefreshGoodsList,
            this.toolStripSeparator1,
            this.btnUseNextTermoBag,
            this.toolStripSeparator3,
            this.btnCompleteGoodsPacking,
            this.toolStripSeparator2,
            this.btnUndoTermoBagPacking});
            this.toolStripDoc.Location = new System.Drawing.Point(0, 35);
            this.toolStripDoc.Name = "toolStripDoc";
            this.toolStripDoc.Size = new System.Drawing.Size(910, 55);
            this.toolStripDoc.TabIndex = 1;
            this.toolStripDoc.Text = "Панель инструментов документа";
            // 
            // btnRefreshGoodsList
            // 
            this.btnRefreshGoodsList.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefreshGoodsList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefreshGoodsList.Name = "btnRefreshGoodsList";
            this.btnRefreshGoodsList.Size = new System.Drawing.Size(158, 52);
            this.btnRefreshGoodsList.Text = "Обновить список \nне погруженных \nтоваров";
            this.btnRefreshGoodsList.Click += new System.EventHandler(this.btnRefreshGoodsList_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // btnUseNextTermoBag
            // 
            this.btnUseNextTermoBag.Image = global::WMSOffice.Properties.Resources.cold_next;
            this.btnUseNextTermoBag.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUseNextTermoBag.Name = "btnUseNextTermoBag";
            this.btnUseNextTermoBag.Size = new System.Drawing.Size(146, 52);
            this.btnUseNextTermoBag.Text = "Взять еще одну \nтермосумку";
            this.btnUseNextTermoBag.Click += new System.EventHandler(this.btnUseNextTermoBag_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 55);
            // 
            // btnCompleteGoodsPacking
            // 
            this.btnCompleteGoodsPacking.Image = ((System.Drawing.Image)(resources.GetObject("btnCompleteGoodsPacking.Image")));
            this.btnCompleteGoodsPacking.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCompleteGoodsPacking.Name = "btnCompleteGoodsPacking";
            this.btnCompleteGoodsPacking.Size = new System.Drawing.Size(155, 52);
            this.btnCompleteGoodsPacking.Text = "Завершить сбор \nтовара с перрона";
            this.btnCompleteGoodsPacking.Click += new System.EventHandler(this.btnCompleteGoodsPacking_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // btnUndoTermoBagPacking
            // 
            this.btnUndoTermoBagPacking.Image = global::WMSOffice.Properties.Resources.undo_action;
            this.btnUndoTermoBagPacking.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUndoTermoBagPacking.Name = "btnUndoTermoBagPacking";
            this.btnUndoTermoBagPacking.Size = new System.Drawing.Size(168, 52);
            this.btnUndoTermoBagPacking.Text = "Отменить погрузку \nтермосумки";
            this.btnUndoTermoBagPacking.Click += new System.EventHandler(this.btnUndoTermoBagPacking_Click);
            // 
            // dgvPickSlipContent
            // 
            this.dgvPickSlipContent.AllowUserToAddRows = false;
            this.dgvPickSlipContent.AllowUserToDeleteRows = false;
            this.dgvPickSlipContent.AllowUserToResizeRows = false;
            this.dgvPickSlipContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPickSlipContent.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPickSlipContent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPickSlipContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPickSlipContent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.peronIDDataGridViewTextBoxColumn,
            this.routeListNumberDataGridViewTextBoxColumn,
            this.relatedOrderTypeDataGridViewTextBoxColumn,
            this.relatedPoSoNumberDataGridViewTextBoxColumn,
            this.relatedPickSlipNumberDataGridViewTextBoxColumn,
            this.documentTypeNameDataGridViewTextBoxColumn,
            this.documentIDDataGridViewTextBoxColumn});
            this.dgvPickSlipContent.DataSource = this.routeListPickSlipBindingSource;
            this.dgvPickSlipContent.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPickSlipContent.Location = new System.Drawing.Point(0, 133);
            this.dgvPickSlipContent.MultiSelect = false;
            this.dgvPickSlipContent.Name = "dgvPickSlipContent";
            this.dgvPickSlipContent.ReadOnly = true;
            this.dgvPickSlipContent.RowHeadersVisible = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dgvPickSlipContent.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPickSlipContent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPickSlipContent.ShowEditingIcon = false;
            this.dgvPickSlipContent.Size = new System.Drawing.Size(910, 322);
            this.dgvPickSlipContent.TabIndex = 2;
            this.dgvPickSlipContent.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvPickSlipContent_DataBindingComplete);
            // 
            // peronIDDataGridViewTextBoxColumn
            // 
            this.peronIDDataGridViewTextBoxColumn.DataPropertyName = "Peron_ID";
            this.peronIDDataGridViewTextBoxColumn.HeaderText = "Перрон";
            this.peronIDDataGridViewTextBoxColumn.Name = "peronIDDataGridViewTextBoxColumn";
            this.peronIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // routeListNumberDataGridViewTextBoxColumn
            // 
            this.routeListNumberDataGridViewTextBoxColumn.DataPropertyName = "Route_List_Number";
            this.routeListNumberDataGridViewTextBoxColumn.HeaderText = "№ маршр. листа";
            this.routeListNumberDataGridViewTextBoxColumn.Name = "routeListNumberDataGridViewTextBoxColumn";
            this.routeListNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // relatedOrderTypeDataGridViewTextBoxColumn
            // 
            this.relatedOrderTypeDataGridViewTextBoxColumn.DataPropertyName = "RelatedOrderType";
            this.relatedOrderTypeDataGridViewTextBoxColumn.HeaderText = "Тип заказа";
            this.relatedOrderTypeDataGridViewTextBoxColumn.Name = "relatedOrderTypeDataGridViewTextBoxColumn";
            this.relatedOrderTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.relatedOrderTypeDataGridViewTextBoxColumn.Width = 120;
            // 
            // relatedPoSoNumberDataGridViewTextBoxColumn
            // 
            this.relatedPoSoNumberDataGridViewTextBoxColumn.DataPropertyName = "RelatedPoSoNumber";
            this.relatedPoSoNumberDataGridViewTextBoxColumn.HeaderText = "№ заказа";
            this.relatedPoSoNumberDataGridViewTextBoxColumn.Name = "relatedPoSoNumberDataGridViewTextBoxColumn";
            this.relatedPoSoNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // relatedPickSlipNumberDataGridViewTextBoxColumn
            // 
            this.relatedPickSlipNumberDataGridViewTextBoxColumn.DataPropertyName = "RelatedPickSlipNumber";
            this.relatedPickSlipNumberDataGridViewTextBoxColumn.HeaderText = "№ сбор. листа";
            this.relatedPickSlipNumberDataGridViewTextBoxColumn.Name = "relatedPickSlipNumberDataGridViewTextBoxColumn";
            this.relatedPickSlipNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // documentTypeNameDataGridViewTextBoxColumn
            // 
            this.documentTypeNameDataGridViewTextBoxColumn.DataPropertyName = "Document_Type_Name";
            this.documentTypeNameDataGridViewTextBoxColumn.HeaderText = "Тип";
            this.documentTypeNameDataGridViewTextBoxColumn.Name = "documentTypeNameDataGridViewTextBoxColumn";
            this.documentTypeNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // documentIDDataGridViewTextBoxColumn
            // 
            this.documentIDDataGridViewTextBoxColumn.DataPropertyName = "Document_ID";
            this.documentIDDataGridViewTextBoxColumn.HeaderText = "№ места / термоакта";
            this.documentIDDataGridViewTextBoxColumn.Name = "documentIDDataGridViewTextBoxColumn";
            this.documentIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.documentIDDataGridViewTextBoxColumn.Width = 120;
            // 
            // routeListPickSlipBindingSource
            // 
            this.routeListPickSlipBindingSource.DataMember = "RouteListPickSlip";
            this.routeListPickSlipBindingSource.DataSource = this.coldChain;
            // 
            // coldChain
            // 
            this.coldChain.DataSetName = "ColdChain";
            this.coldChain.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbScanner
            // 
            this.tbScanner.AllowType = true;
            this.tbScanner.AutoConvert = true;
            this.tbScanner.Location = new System.Drawing.Point(241, 6);
            this.tbScanner.Name = "tbScanner";
            this.tbScanner.Size = new System.Drawing.Size(375, 25);
            this.tbScanner.TabIndex = 3;
            this.tbScanner.TextBoxBackColor = System.Drawing.SystemColors.Window;
            // 
            // pnlTools
            // 
            this.pnlTools.Controls.Add(this.lblCurrentTermoBag);
            this.pnlTools.Controls.Add(this.lblScannerProcessCaption);
            this.pnlTools.Controls.Add(this.tbScanner);
            this.pnlTools.Controls.Add(this.toolStripDoc);
            this.pnlTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTools.Location = new System.Drawing.Point(0, 40);
            this.pnlTools.Name = "pnlTools";
            this.pnlTools.Size = new System.Drawing.Size(910, 90);
            this.pnlTools.TabIndex = 4;
            // 
            // lblCurrentTermoBag
            // 
            this.lblCurrentTermoBag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentTermoBag.Location = new System.Drawing.Point(622, 6);
            this.lblCurrentTermoBag.Name = "lblCurrentTermoBag";
            this.lblCurrentTermoBag.Size = new System.Drawing.Size(282, 25);
            this.lblCurrentTermoBag.TabIndex = 5;
            this.lblCurrentTermoBag.Text = "Текущая термосумка :";
            this.lblCurrentTermoBag.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblScannerProcessCaption
            // 
            this.lblScannerProcessCaption.Location = new System.Drawing.Point(3, 6);
            this.lblScannerProcessCaption.Name = "lblScannerProcessCaption";
            this.lblScannerProcessCaption.Size = new System.Drawing.Size(236, 25);
            this.lblScannerProcessCaption.TabIndex = 4;
            this.lblScannerProcessCaption.Text = "Отсканируйте штрих-код места / термоакта:";
            this.lblScannerProcessCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // routeListPickSlipTableAdapter
            // 
            this.routeListPickSlipTableAdapter.ClearBeforeFill = true;
            // 
            // ColdChainTermoBagPackingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 455);
            this.Controls.Add(this.pnlTools);
            this.Controls.Add(this.dgvPickSlipContent);
            this.Name = "ColdChainTermoBagPackingWindow";
            this.Text = "* Погрузка товара в термосумку";
            this.Load += new System.EventHandler(this.ColdChainAddGoodsToTermoBag_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ColdChainTermoBagPackingWindow_FormClosing);
            this.Controls.SetChildIndex(this.dgvPickSlipContent, 0);
            this.Controls.SetChildIndex(this.pnlTools, 0);
            this.toolStripDoc.ResumeLayout(false);
            this.toolStripDoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPickSlipContent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.routeListPickSlipBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coldChain)).EndInit();
            this.pnlTools.ResumeLayout(false);
            this.pnlTools.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripDoc;
        private System.Windows.Forms.ToolStripButton btnRefreshGoodsList;
        private System.Windows.Forms.ToolStripButton btnUseNextTermoBag;
        private System.Windows.Forms.ToolStripButton btnCompleteGoodsPacking;
        private System.Windows.Forms.ToolStripButton btnUndoTermoBagPacking;
        private System.Windows.Forms.DataGridView dgvPickSlipContent;
        private WMSOffice.Controls.TextBoxScaner tbScanner;
        private System.Windows.Forms.Panel pnlTools;
        private System.Windows.Forms.Label lblScannerProcessCaption;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.BindingSource routeListPickSlipBindingSource;
        private WMSOffice.Data.ColdChain coldChain;
        private WMSOffice.Data.ColdChainTableAdapters.RouteListPickSlipTableAdapter routeListPickSlipTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn peronIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn routeListNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn relatedOrderTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn relatedPoSoNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn relatedPickSlipNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn documentTypeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn documentIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label lblCurrentTermoBag;
    }
}