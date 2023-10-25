namespace WMSOffice.Window
{
    partial class QualityPrintBlockListsForPlacesWindow
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
            this.btnCancelLoading = new System.Windows.Forms.ToolStripButton();
            this.tssAfterRefresh = new System.Windows.Forms.ToolStripSeparator();
            this.lblWarehouse = new System.Windows.Forms.ToolStripLabel();
            this.cmbWarehouses = new System.Windows.Forms.ToolStripComboBox();
            this.lblLevels = new System.Windows.Forms.ToolStripLabel();
            this.cmbLevels = new System.Windows.Forms.ToolStripComboBox();
            this.tssAfterComboBox = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrintStickers = new System.Windows.Forms.ToolStripButton();
            this.lblPrinters = new System.Windows.Forms.ToolStripLabel();
            this.cmbPrinters = new System.Windows.Forms.ToolStripComboBox();
            this.egvBlockedLocations = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.cmsBlockedLocations = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.miCancelLoading = new System.Windows.Forms.ToolStripMenuItem();
            this.cssmiAfterRefresh = new System.Windows.Forms.ToolStripSeparator();
            this.miPrintStickers = new System.Windows.Forms.ToolStripMenuItem();
            this.bgwLocationsLoader = new System.ComponentModel.BackgroundWorker();
            this.pbSplashControl = new System.Windows.Forms.PictureBox();
            this.pnlMainGrid = new System.Windows.Forms.Panel();
            this.quality = new WMSOffice.Data.Quality();
            this.bsWarehouses = new System.Windows.Forms.BindingSource(this.components);
            this.taGetWarehouseList = new WMSOffice.Data.QualityTableAdapters.BP_GetWarehouseListTableAdapter();
            this.bsLevels = new System.Windows.Forms.BindingSource(this.components);
            this.taGetLevelsList = new WMSOffice.Data.QualityTableAdapters.BP_GetLevelsListTableAdapter();
            this.tsMain.SuspendLayout();
            this.cmsBlockedLocations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSplashControl)).BeginInit();
            this.pnlMainGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsWarehouses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLevels)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.btnCancelLoading,
            this.tssAfterRefresh,
            this.lblWarehouse,
            this.cmbWarehouses,
            this.lblLevels,
            this.cmbLevels,
            this.tssAfterComboBox,
            this.btnPrintStickers,
            this.lblPrinters,
            this.cmbPrinters});
            this.tsMain.Location = new System.Drawing.Point(0, 40);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1202, 55);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(52, 52);
            this.btnRefresh.ToolTipText = "Обновить таблицу заблокированных мест в соответствии с фильтрами";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnCancelLoading
            // 
            this.btnCancelLoading.Image = global::WMSOffice.Properties.Resources.cancel;
            this.btnCancelLoading.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelLoading.Name = "btnCancelLoading";
            this.btnCancelLoading.Size = new System.Drawing.Size(113, 52);
            this.btnCancelLoading.Text = "Отменить\nзагрузку";
            this.btnCancelLoading.ToolTipText = "Отменить текущее обновление данных";
            this.btnCancelLoading.Click += new System.EventHandler(this.btnCancelLoading_Click);
            // 
            // tssAfterRefresh
            // 
            this.tssAfterRefresh.Name = "tssAfterRefresh";
            this.tssAfterRefresh.Size = new System.Drawing.Size(6, 55);
            // 
            // lblWarehouse
            // 
            this.lblWarehouse.Name = "lblWarehouse";
            this.lblWarehouse.Size = new System.Drawing.Size(46, 52);
            this.lblWarehouse.Text = "Склад: ";
            // 
            // cmbWarehouses
            // 
            this.cmbWarehouses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWarehouses.Name = "cmbWarehouses";
            this.cmbWarehouses.Size = new System.Drawing.Size(200, 55);
            this.cmbWarehouses.ToolTipText = "Выбор склада, на котором находятся искомые места";
            this.cmbWarehouses.SelectedIndexChanged += new System.EventHandler(this.cmbWarehouses_SelectedIndexChanged);
            // 
            // lblLevels
            // 
            this.lblLevels.Name = "lblLevels";
            this.lblLevels.Size = new System.Drawing.Size(67, 52);
            this.lblLevels.Text = "          Этаж:";
            // 
            // cmbLevels
            // 
            this.cmbLevels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLevels.Name = "cmbLevels";
            this.cmbLevels.Size = new System.Drawing.Size(121, 55);
            this.cmbLevels.ToolTipText = "Выбор этажа, на котором находятся искомые места";
            // 
            // tssAfterComboBox
            // 
            this.tssAfterComboBox.Name = "tssAfterComboBox";
            this.tssAfterComboBox.Size = new System.Drawing.Size(6, 55);
            // 
            // btnPrintStickers
            // 
            this.btnPrintStickers.Image = global::WMSOffice.Properties.Resources.document_print;
            this.btnPrintStickers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintStickers.Name = "btnPrintStickers";
            this.btnPrintStickers.Size = new System.Drawing.Size(109, 52);
            this.btnPrintStickers.Text = "Печать\nстикеров";
            this.btnPrintStickers.ToolTipText = "Печать стикеров \"Не для продажи\" на выбранные места в таблице";
            this.btnPrintStickers.Click += new System.EventHandler(this.btnPrintStickers_Click);
            // 
            // lblPrinters
            // 
            this.lblPrinters.Name = "lblPrinters";
            this.lblPrinters.Size = new System.Drawing.Size(100, 52);
            this.lblPrinters.Text = "          Принтеры: ";
            // 
            // cmbPrinters
            // 
            this.cmbPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinters.Name = "cmbPrinters";
            this.cmbPrinters.Size = new System.Drawing.Size(250, 55);
            // 
            // egvBlockedLocations
            // 
            this.egvBlockedLocations.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.egvBlockedLocations.ContextMenuStrip = this.cmsBlockedLocations;
            this.egvBlockedLocations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.egvBlockedLocations.LargeAmountOfData = false;
            this.egvBlockedLocations.Location = new System.Drawing.Point(0, 0);
            this.egvBlockedLocations.Name = "egvBlockedLocations";
            this.egvBlockedLocations.RowHeadersVisible = false;
            this.egvBlockedLocations.Size = new System.Drawing.Size(1202, 347);
            this.egvBlockedLocations.TabIndex = 2;
            this.egvBlockedLocations.UserID = ((long)(0));
            this.egvBlockedLocations.OnRowSelectionChanged += new System.EventHandler(this.egvBlockedLocations_OnRowSelectionChanged);
            this.egvBlockedLocations.OnFormattingCell += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.egvBlockedLocations_OnFormattingCell);
            // 
            // cmsBlockedLocations
            // 
            this.cmsBlockedLocations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miRefresh,
            this.miCancelLoading,
            this.cssmiAfterRefresh,
            this.miPrintStickers});
            this.cmsBlockedLocations.Name = "cmsBlockedLocations";
            this.cmsBlockedLocations.Size = new System.Drawing.Size(224, 76);
            // 
            // miRefresh
            // 
            this.miRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.miRefresh.Name = "miRefresh";
            this.miRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.miRefresh.Size = new System.Drawing.Size(223, 22);
            this.miRefresh.Text = "Обновить";
            this.miRefresh.ToolTipText = "Обновить таблицу заблокированных мест в соответствии с фильтрами";
            this.miRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // miCancelLoading
            // 
            this.miCancelLoading.Image = global::WMSOffice.Properties.Resources.cancel;
            this.miCancelLoading.Name = "miCancelLoading";
            this.miCancelLoading.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F5)));
            this.miCancelLoading.Size = new System.Drawing.Size(223, 22);
            this.miCancelLoading.Text = "Отменить загрузку";
            this.miCancelLoading.ToolTipText = "Отменить текущее обновление данных";
            this.miCancelLoading.Click += new System.EventHandler(this.btnCancelLoading_Click);
            // 
            // cssmiAfterRefresh
            // 
            this.cssmiAfterRefresh.Name = "cssmiAfterRefresh";
            this.cssmiAfterRefresh.Size = new System.Drawing.Size(220, 6);
            // 
            // miPrintStickers
            // 
            this.miPrintStickers.Image = global::WMSOffice.Properties.Resources.document_print;
            this.miPrintStickers.Name = "miPrintStickers";
            this.miPrintStickers.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.miPrintStickers.Size = new System.Drawing.Size(223, 22);
            this.miPrintStickers.Text = "Печать стикеров";
            this.miPrintStickers.Click += new System.EventHandler(this.btnPrintStickers_Click);
            // 
            // pbSplashControl
            // 
            this.pbSplashControl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbSplashControl.Image = global::WMSOffice.Properties.Resources.Loading;
            this.pbSplashControl.Location = new System.Drawing.Point(545, 113);
            this.pbSplashControl.Name = "pbSplashControl";
            this.pbSplashControl.Size = new System.Drawing.Size(100, 100);
            this.pbSplashControl.TabIndex = 3;
            this.pbSplashControl.TabStop = false;
            // 
            // pnlMainGrid
            // 
            this.pnlMainGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMainGrid.Controls.Add(this.pbSplashControl);
            this.pnlMainGrid.Controls.Add(this.egvBlockedLocations);
            this.pnlMainGrid.Location = new System.Drawing.Point(0, 95);
            this.pnlMainGrid.Name = "pnlMainGrid";
            this.pnlMainGrid.Size = new System.Drawing.Size(1202, 347);
            this.pnlMainGrid.TabIndex = 4;
            // 
            // quality
            // 
            this.quality.DataSetName = "Quality";
            this.quality.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bsWarehouses
            // 
            this.bsWarehouses.DataMember = "BP_GetWarehouseList";
            this.bsWarehouses.DataSource = this.quality;
            // 
            // taGetWarehouseList
            // 
            this.taGetWarehouseList.ClearBeforeFill = true;
            // 
            // bsLevels
            // 
            this.bsLevels.DataMember = "BP_GetLevelsList";
            this.bsLevels.DataSource = this.quality;
            // 
            // taGetLevelsList
            // 
            this.taGetLevelsList.ClearBeforeFill = true;
            // 
            // QualityPrintBlockListsForPlacesWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 438);
            this.ContextMenuStrip = this.cmsBlockedLocations;
            this.Controls.Add(this.pnlMainGrid);
            this.Controls.Add(this.tsMain);
            this.Name = "QualityPrintBlockListsForPlacesWindow";
            this.Text = "QualityPrintBlockListsForPlacesWindow";
            this.Load += new System.EventHandler(this.QualityPrintBlockListsForPlacesWindow_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QualityPrintBlockListsForPlacesWindow_FormClosing);
            this.Controls.SetChildIndex(this.tsMain, 0);
            this.Controls.SetChildIndex(this.pnlMainGrid, 0);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.cmsBlockedLocations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSplashControl)).EndInit();
            this.pnlMainGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsWarehouses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLevels)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView egvBlockedLocations;
        private System.Windows.Forms.ToolStripButton btnCancelLoading;
        private System.Windows.Forms.ContextMenuStrip cmsBlockedLocations;
        private System.Windows.Forms.ToolStripMenuItem miRefresh;
        private System.Windows.Forms.ToolStripSeparator tssAfterRefresh;
        private System.Windows.Forms.ToolStripLabel lblWarehouse;
        private System.Windows.Forms.ToolStripComboBox cmbWarehouses;
        private System.Windows.Forms.ToolStripMenuItem miCancelLoading;
        private System.Windows.Forms.ToolStripSeparator cssmiAfterRefresh;
        private WMSOffice.Data.Quality quality;
        private System.Windows.Forms.BindingSource bsWarehouses;
        private WMSOffice.Data.QualityTableAdapters.BP_GetWarehouseListTableAdapter taGetWarehouseList;
        private System.Windows.Forms.ToolStripLabel lblLevels;
        private System.Windows.Forms.ToolStripComboBox cmbLevels;
        private System.Windows.Forms.BindingSource bsLevels;
        private WMSOffice.Data.QualityTableAdapters.BP_GetLevelsListTableAdapter taGetLevelsList;
        private System.ComponentModel.BackgroundWorker bgwLocationsLoader;
        private System.Windows.Forms.PictureBox pbSplashControl;
        private System.Windows.Forms.Panel pnlMainGrid;
        private System.Windows.Forms.ToolStripSeparator tssAfterComboBox;
        private System.Windows.Forms.ToolStripButton btnPrintStickers;
        private System.Windows.Forms.ToolStripMenuItem miPrintStickers;
        private System.Windows.Forms.ToolStripLabel lblPrinters;
        private System.Windows.Forms.ToolStripComboBox cmbPrinters;
    }
}