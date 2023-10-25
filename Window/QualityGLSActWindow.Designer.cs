namespace WMSOffice.Window
{
    partial class QualityGLSActWindow
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
            this.btnShowAttachments = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCreateRecallDoc = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAcceptRecallDoc = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCancelRecallDoc = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCreateRecallNotification = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSendRecalcNotification = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.ssbCreateConsolidatedGLSRemainsNotification = new System.Windows.Forms.ToolStripSplitButton();
            this.ssbiCreateConsolidatedGLSRemainsNotification = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.ssbiCreateConsolidatedGLSRemainsNotificationExtendedIn = new System.Windows.Forms.ToolStripMenuItem();
            this.ssbiCreateConsolidatedGLSRemainsNotificationExtendedOut = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCreateRecallActionsProtocol = new System.Windows.Forms.ToolStripButton();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.xdgvRecallDocs = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.dgvRecalcDocDetails = new System.Windows.Forms.DataGridView();
            this.itemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expireDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currVendorIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currVendorNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotVendorIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotVendorNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Manufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gADocDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quality = new WMSOffice.Data.Quality();
            this.gA_Doc_DetailsTableAdapter = new WMSOffice.Data.QualityTableAdapters.GA_Doc_DetailsTableAdapter();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.btnShowRemains = new System.Windows.Forms.ToolStripButton();
            this.tsMain.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecalcDocDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gADocDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.toolStripSeparator1,
            this.btnShowAttachments,
            this.toolStripSeparator5,
            this.btnCreateRecallDoc,
            this.toolStripSeparator2,
            this.btnAcceptRecallDoc,
            this.toolStripSeparator6,
            this.btnCancelRecallDoc,
            this.toolStripSeparator4,
            this.btnCreateRecallNotification,
            this.toolStripSeparator3,
            this.btnSendRecalcNotification,
            this.toolStripSeparator7,
            this.ssbCreateConsolidatedGLSRemainsNotification,
            this.toolStripSeparator8,
            this.btnCreateRecallActionsProtocol,
            this.toolStripSeparator10,
            this.btnShowRemains});
            this.tsMain.Location = new System.Drawing.Point(0, 40);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1355, 55);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(109, 52);
            this.btnRefresh.Text = "Оновити";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // btnShowAttachments
            // 
            this.btnShowAttachments.Image = global::WMSOffice.Properties.Resources.paperclip;
            this.btnShowAttachments.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowAttachments.Name = "btnShowAttachments";
            this.btnShowAttachments.Size = new System.Drawing.Size(94, 52);
            this.btnShowAttachments.Text = "Прикр.\nфайли";
            this.btnShowAttachments.Click += new System.EventHandler(this.btnShowAttachments_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 55);
            // 
            // btnCreateRecallDoc
            // 
            this.btnCreateRecallDoc.Image = global::WMSOffice.Properties.Resources.add_document;
            this.btnCreateRecallDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreateRecallDoc.Name = "btnCreateRecallDoc";
            this.btnCreateRecallDoc.Size = new System.Drawing.Size(102, 52);
            this.btnCreateRecallDoc.Text = "Створити";
            this.btnCreateRecallDoc.Click += new System.EventHandler(this.btnCreateRecallDoc_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // btnAcceptRecallDoc
            // 
            this.btnAcceptRecallDoc.Image = global::WMSOffice.Properties.Resources.document_ok;
            this.btnAcceptRecallDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAcceptRecallDoc.Name = "btnAcceptRecallDoc";
            this.btnAcceptRecallDoc.Size = new System.Drawing.Size(115, 52);
            this.btnAcceptRecallDoc.Text = "Затвердити";
            this.btnAcceptRecallDoc.Click += new System.EventHandler(this.btnAcceptRecallDoc_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 55);
            // 
            // btnCancelRecallDoc
            // 
            this.btnCancelRecallDoc.Image = global::WMSOffice.Properties.Resources.undo43;
            this.btnCancelRecallDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelRecallDoc.Name = "btnCancelRecallDoc";
            this.btnCancelRecallDoc.Size = new System.Drawing.Size(109, 52);
            this.btnCancelRecallDoc.Text = "Скасувати";
            this.btnCancelRecallDoc.Click += new System.EventHandler(this.btnCancelRecallDoc_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 55);
            // 
            // btnCreateRecallNotification
            // 
            this.btnCreateRecallNotification.Image = global::WMSOffice.Properties.Resources.export_pdf;
            this.btnCreateRecallNotification.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreateRecallNotification.Name = "btnCreateRecallNotification";
            this.btnCreateRecallNotification.Size = new System.Drawing.Size(127, 52);
            this.btnCreateRecallNotification.Text = "Повідомлення\nза відкликанням";
            this.btnCreateRecallNotification.ToolTipText = "Сформувати повідомлення для клієнтів";
            this.btnCreateRecallNotification.Click += new System.EventHandler(this.btnCreateRecallNotification_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 55);
            // 
            // btnSendRecalcNotification
            // 
            this.btnSendRecalcNotification.Image = global::WMSOffice.Properties.Resources.mail_ok;
            this.btnSendRecalcNotification.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSendRecalcNotification.Name = "btnSendRecalcNotification";
            this.btnSendRecalcNotification.Size = new System.Drawing.Size(126, 52);
            this.btnSendRecalcNotification.Text = "Відправити\nповідомлення";
            this.btnSendRecalcNotification.Click += new System.EventHandler(this.btnSendRecalcNotification_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 55);
            // 
            // ssbCreateConsolidatedGLSRemainsNotification
            // 
            this.ssbCreateConsolidatedGLSRemainsNotification.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ssbiCreateConsolidatedGLSRemainsNotification,
            this.toolStripSeparator9,
            this.ssbiCreateConsolidatedGLSRemainsNotificationExtendedIn,
            this.ssbiCreateConsolidatedGLSRemainsNotificationExtendedOut});
            this.ssbCreateConsolidatedGLSRemainsNotification.Image = global::WMSOffice.Properties.Resources.finish_process;
            this.ssbCreateConsolidatedGLSRemainsNotification.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ssbCreateConsolidatedGLSRemainsNotification.Name = "ssbCreateConsolidatedGLSRemainsNotification";
            this.ssbCreateConsolidatedGLSRemainsNotification.Size = new System.Drawing.Size(139, 52);
            this.ssbCreateConsolidatedGLSRemainsNotification.Text = "Повідомлення\nв ДЛС";
            this.ssbCreateConsolidatedGLSRemainsNotification.ButtonClick += new System.EventHandler(this.ssbCreateConsolidatedGLSRemainsNotification_ButtonClick);
            // 
            // ssbiCreateConsolidatedGLSRemainsNotification
            // 
            this.ssbiCreateConsolidatedGLSRemainsNotification.Name = "ssbiCreateConsolidatedGLSRemainsNotification";
            this.ssbiCreateConsolidatedGLSRemainsNotification.Size = new System.Drawing.Size(300, 22);
            this.ssbiCreateConsolidatedGLSRemainsNotification.Text = "Повідомлення в простій формі";
            this.ssbiCreateConsolidatedGLSRemainsNotification.Click += new System.EventHandler(this.ssbiCreateConsolidatedGLSRemainsNotification_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(297, 6);
            // 
            // ssbiCreateConsolidatedGLSRemainsNotificationExtendedIn
            // 
            this.ssbiCreateConsolidatedGLSRemainsNotificationExtendedIn.Name = "ssbiCreateConsolidatedGLSRemainsNotificationExtendedIn";
            this.ssbiCreateConsolidatedGLSRemainsNotificationExtendedIn.Size = new System.Drawing.Size(300, 22);
            this.ssbiCreateConsolidatedGLSRemainsNotificationExtendedIn.Text = "Повідомлення на момент отримання заборони";
            this.ssbiCreateConsolidatedGLSRemainsNotificationExtendedIn.Click += new System.EventHandler(this.ssbiCreateConsolidatedGLSRemainsNotificationExtendedIn_Click);
            // 
            // ssbiCreateConsolidatedGLSRemainsNotificationExtendedOut
            // 
            this.ssbiCreateConsolidatedGLSRemainsNotificationExtendedOut.Name = "ssbiCreateConsolidatedGLSRemainsNotificationExtendedOut";
            this.ssbiCreateConsolidatedGLSRemainsNotificationExtendedOut.Size = new System.Drawing.Size(300, 22);
            this.ssbiCreateConsolidatedGLSRemainsNotificationExtendedOut.Text = "Повідомлення на момент завершення відкликання";
            this.ssbiCreateConsolidatedGLSRemainsNotificationExtendedOut.Click += new System.EventHandler(this.ssbiCreateConsolidatedGLSRemainsNotificationExtendedOut_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 55);
            // 
            // btnCreateRecallActionsProtocol
            // 
            this.btnCreateRecallActionsProtocol.Image = global::WMSOffice.Properties.Resources.checklist;
            this.btnCreateRecallActionsProtocol.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreateRecallActionsProtocol.Name = "btnCreateRecallActionsProtocol";
            this.btnCreateRecallActionsProtocol.Size = new System.Drawing.Size(159, 52);
            this.btnCreateRecallActionsProtocol.Text = "Протокол дій\nвідкликання продукції";
            this.btnCreateRecallActionsProtocol.Click += new System.EventHandler(this.btnCreateRecallActionsProtocol_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.splitContainer1);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 95);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1355, 323);
            this.pnlContent.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.xdgvRecallDocs);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvRecalcDocDetails);
            this.splitContainer1.Size = new System.Drawing.Size(1355, 323);
            this.splitContainer1.SplitterDistance = 131;
            this.splitContainer1.TabIndex = 1;
            // 
            // xdgvRecallDocs
            // 
            this.xdgvRecallDocs.AllowSort = true;
            this.xdgvRecallDocs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvRecallDocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvRecallDocs.LargeAmountOfData = false;
            this.xdgvRecallDocs.Location = new System.Drawing.Point(0, 0);
            this.xdgvRecallDocs.Name = "xdgvRecallDocs";
            this.xdgvRecallDocs.RowHeadersVisible = false;
            this.xdgvRecallDocs.Size = new System.Drawing.Size(1355, 131);
            this.xdgvRecallDocs.TabIndex = 0;
            this.xdgvRecallDocs.UserID = ((long)(0));
            // 
            // dgvRecalcDocDetails
            // 
            this.dgvRecalcDocDetails.AllowUserToAddRows = false;
            this.dgvRecalcDocDetails.AllowUserToDeleteRows = false;
            this.dgvRecalcDocDetails.AllowUserToResizeRows = false;
            this.dgvRecalcDocDetails.AutoGenerateColumns = false;
            this.dgvRecalcDocDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRecalcDocDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemIDDataGridViewTextBoxColumn,
            this.itemNameDataGridViewTextBoxColumn,
            this.lotNumberDataGridViewTextBoxColumn,
            this.expireDateDataGridViewTextBoxColumn,
            this.currVendorIDDataGridViewTextBoxColumn,
            this.currVendorNameDataGridViewTextBoxColumn,
            this.lotVendorIDDataGridViewTextBoxColumn,
            this.lotVendorNameDataGridViewTextBoxColumn,
            this.Manufacturer});
            this.dgvRecalcDocDetails.DataSource = this.gADocDetailsBindingSource;
            this.dgvRecalcDocDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRecalcDocDetails.Location = new System.Drawing.Point(0, 0);
            this.dgvRecalcDocDetails.MultiSelect = false;
            this.dgvRecalcDocDetails.Name = "dgvRecalcDocDetails";
            this.dgvRecalcDocDetails.ReadOnly = true;
            this.dgvRecalcDocDetails.RowHeadersVisible = false;
            this.dgvRecalcDocDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecalcDocDetails.Size = new System.Drawing.Size(1355, 188);
            this.dgvRecalcDocDetails.TabIndex = 0;
            this.dgvRecalcDocDetails.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvRecalcDocDetails_CellFormatting);
            // 
            // itemIDDataGridViewTextBoxColumn
            // 
            this.itemIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemIDDataGridViewTextBoxColumn.DataPropertyName = "ItemID";
            this.itemIDDataGridViewTextBoxColumn.HeaderText = "Код";
            this.itemIDDataGridViewTextBoxColumn.Name = "itemIDDataGridViewTextBoxColumn";
            this.itemIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemIDDataGridViewTextBoxColumn.Width = 51;
            // 
            // itemNameDataGridViewTextBoxColumn
            // 
            this.itemNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemNameDataGridViewTextBoxColumn.DataPropertyName = "ItemName";
            this.itemNameDataGridViewTextBoxColumn.HeaderText = "Назва товару";
            this.itemNameDataGridViewTextBoxColumn.Name = "itemNameDataGridViewTextBoxColumn";
            this.itemNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemNameDataGridViewTextBoxColumn.Width = 146;
            // 
            // lotNumberDataGridViewTextBoxColumn
            // 
            this.lotNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lotNumberDataGridViewTextBoxColumn.DataPropertyName = "LotNumber";
            this.lotNumberDataGridViewTextBoxColumn.HeaderText = "Серія";
            this.lotNumberDataGridViewTextBoxColumn.Name = "lotNumberDataGridViewTextBoxColumn";
            this.lotNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.lotNumberDataGridViewTextBoxColumn.Width = 63;
            // 
            // expireDateDataGridViewTextBoxColumn
            // 
            this.expireDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.expireDateDataGridViewTextBoxColumn.DataPropertyName = "ExpireDate";
            this.expireDateDataGridViewTextBoxColumn.HeaderText = "Термін дії";
            this.expireDateDataGridViewTextBoxColumn.Name = "expireDateDataGridViewTextBoxColumn";
            this.expireDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.expireDateDataGridViewTextBoxColumn.Width = 106;
            // 
            // currVendorIDDataGridViewTextBoxColumn
            // 
            this.currVendorIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.currVendorIDDataGridViewTextBoxColumn.DataPropertyName = "CurrVendorID";
            this.currVendorIDDataGridViewTextBoxColumn.HeaderText = "Пост.";
            this.currVendorIDDataGridViewTextBoxColumn.Name = "currVendorIDDataGridViewTextBoxColumn";
            this.currVendorIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.currVendorIDDataGridViewTextBoxColumn.Width = 60;
            // 
            // currVendorNameDataGridViewTextBoxColumn
            // 
            this.currVendorNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.currVendorNameDataGridViewTextBoxColumn.DataPropertyName = "CurrVendorName";
            this.currVendorNameDataGridViewTextBoxColumn.HeaderText = "Постачальник";
            this.currVendorNameDataGridViewTextBoxColumn.Name = "currVendorNameDataGridViewTextBoxColumn";
            this.currVendorNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.currVendorNameDataGridViewTextBoxColumn.Width = 90;
            // 
            // lotVendorIDDataGridViewTextBoxColumn
            // 
            this.lotVendorIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lotVendorIDDataGridViewTextBoxColumn.DataPropertyName = "LotVendorID";
            this.lotVendorIDDataGridViewTextBoxColumn.HeaderText = "Іст. Пост.";
            this.lotVendorIDDataGridViewTextBoxColumn.Name = "lotVendorIDDataGridViewTextBoxColumn";
            this.lotVendorIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.lotVendorIDDataGridViewTextBoxColumn.Width = 85;
            // 
            // lotVendorNameDataGridViewTextBoxColumn
            // 
            this.lotVendorNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lotVendorNameDataGridViewTextBoxColumn.DataPropertyName = "LotVendorName";
            this.lotVendorNameDataGridViewTextBoxColumn.HeaderText = "Історичний постачальник";
            this.lotVendorNameDataGridViewTextBoxColumn.Name = "lotVendorNameDataGridViewTextBoxColumn";
            this.lotVendorNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.lotVendorNameDataGridViewTextBoxColumn.Width = 163;
            // 
            // Manufacturer
            // 
            this.Manufacturer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Manufacturer.DataPropertyName = "Manufacturer";
            this.Manufacturer.HeaderText = "Виробник";
            this.Manufacturer.Name = "Manufacturer";
            this.Manufacturer.ReadOnly = true;
            this.Manufacturer.Width = 111;
            // 
            // gADocDetailsBindingSource
            // 
            this.gADocDetailsBindingSource.DataMember = "GA_Doc_Details";
            this.gADocDetailsBindingSource.DataSource = this.quality;
            // 
            // quality
            // 
            this.quality.DataSetName = "Quality";
            this.quality.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gA_Doc_DetailsTableAdapter
            // 
            this.gA_Doc_DetailsTableAdapter.ClearBeforeFill = true;
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 55);
            // 
            // btnShowRemains
            // 
            this.btnShowRemains.Image = global::WMSOffice.Properties.Resources.table2_information;
            this.btnShowRemains.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowRemains.Name = "btnShowRemains";
            this.btnShowRemains.Size = new System.Drawing.Size(102, 52);
            this.btnShowRemains.Text = "Залишки";
            this.btnShowRemains.Click += new System.EventHandler(this.btnShowRemains_Click);
            // 
            // QualityGLSActWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1355, 418);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.tsMain);
            this.Name = "QualityGLSActWindow";
            this.Text = "QualityGLSActWindow";
            this.Controls.SetChildIndex(this.tsMain, 0);
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecalcDocDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gADocDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnCreateRecallNotification;
        private System.Windows.Forms.ToolStripButton btnCreateRecallDoc;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Panel pnlContent;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvRecallDocs;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvRecalcDocDetails;
        private System.Windows.Forms.BindingSource gADocDetailsBindingSource;
        private WMSOffice.Data.Quality quality;
        private WMSOffice.Data.QualityTableAdapters.GA_Doc_DetailsTableAdapter gA_Doc_DetailsTableAdapter;
        private System.Windows.Forms.ToolStripButton btnSendRecalcNotification;
        private System.Windows.Forms.ToolStripButton btnCancelRecallDoc;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnShowAttachments;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnAcceptRecallDoc;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expireDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn currVendorIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn currVendorNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotVendorIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotVendorNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manufacturer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton btnCreateRecallActionsProtocol;
        private System.Windows.Forms.ToolStripSplitButton ssbCreateConsolidatedGLSRemainsNotification;
        private System.Windows.Forms.ToolStripMenuItem ssbiCreateConsolidatedGLSRemainsNotification;
        private System.Windows.Forms.ToolStripMenuItem ssbiCreateConsolidatedGLSRemainsNotificationExtendedIn;
        private System.Windows.Forms.ToolStripMenuItem ssbiCreateConsolidatedGLSRemainsNotificationExtendedOut;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton btnShowRemains;
    }
}