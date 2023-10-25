namespace WMSOffice.Window
{
    partial class ColdChainTermoboxDriverAccountingWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColdChainTermoboxDriverAccountingWindow));
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnCancelLoading = new System.Windows.Forms.ToolStripButton();
            this.tssAfterRefresh = new System.Windows.Forms.ToolStripSeparator();
            this.btnExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.tssAfterExcel = new System.Windows.Forms.ToolStripSeparator();
            this.btnLink = new System.Windows.Forms.ToolStripButton();
            this.btnUnlink = new System.Windows.Forms.ToolStripButton();
            this.btnMassLink = new System.Windows.Forms.ToolStripButton();
            this.bgwHistoryLoader = new System.ComponentModel.BackgroundWorker();
            this.egvHistory = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.pbSplashControl = new System.Windows.Forms.PictureBox();
            this.tsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSplashControl)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.btnCancelLoading,
            this.tssAfterRefresh,
            this.btnExportToExcel,
            this.tssAfterExcel,
            this.btnLink,
            this.btnUnlink,
            this.btnMassLink});
            this.tsMain.Location = new System.Drawing.Point(0, 40);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1139, 55);
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
            this.btnRefresh.Text = "toolStripButton1";
            this.btnRefresh.ToolTipText = "Обновить историю выдачи термобоксов сотрудникам";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnCancelLoading
            // 
            this.btnCancelLoading.Image = global::WMSOffice.Properties.Resources.cancel;
            this.btnCancelLoading.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelLoading.Name = "btnCancelLoading";
            this.btnCancelLoading.Size = new System.Drawing.Size(113, 52);
            this.btnCancelLoading.Text = "Отменить\nзагрузку";
            this.btnCancelLoading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelLoading.Click += new System.EventHandler(this.btnCancelLoading_Click);
            // 
            // tssAfterRefresh
            // 
            this.tssAfterRefresh.Name = "tssAfterRefresh";
            this.tssAfterRefresh.Size = new System.Drawing.Size(6, 55);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Image = global::WMSOffice.Properties.Resources.Excel;
            this.btnExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(104, 52);
            this.btnExportToExcel.Text = "Экспорт\nв Excel\n(F3)";
            this.btnExportToExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // tssAfterExcel
            // 
            this.tssAfterExcel.Name = "tssAfterExcel";
            this.tssAfterExcel.Size = new System.Drawing.Size(6, 55);
            // 
            // btnLink
            // 
            this.btnLink.Image = global::WMSOffice.Properties.Resources.line_sight;
            this.btnLink.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLink.Name = "btnLink";
            this.btnLink.Size = new System.Drawing.Size(119, 52);
            this.btnLink.Text = "Выдать\nтермобокс\n(F4)";
            this.btnLink.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLink.ToolTipText = "Отсканировать штрих-кода водителя и термобокса";
            this.btnLink.Click += new System.EventHandler(this.btnLink_Click);
            // 
            // btnUnlink
            // 
            this.btnUnlink.Image = global::WMSOffice.Properties.Resources.Restore;
            this.btnUnlink.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUnlink.Name = "btnUnlink";
            this.btnUnlink.Size = new System.Drawing.Size(119, 52);
            this.btnUnlink.Text = "Вернуть\nтермобокс\n(F5)";
            this.btnUnlink.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUnlink.ToolTipText = "Отсканировать код термобокса";
            this.btnUnlink.Click += new System.EventHandler(this.btnUnlink_Click);
            // 
            // btnMassLink
            // 
            this.btnMassLink.Image = global::WMSOffice.Properties.Resources.config_users;
            this.btnMassLink.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMassLink.Name = "btnMassLink";
            this.btnMassLink.Size = new System.Drawing.Size(156, 52);
            this.btnMassLink.Text = "Массовая выдача\nтермобоксов\n(F6)";
            this.btnMassLink.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMassLink.Click += new System.EventHandler(this.btnMassLink_Click);
            // 
            // egvHistory
            // 
            this.egvHistory.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.egvHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.egvHistory.LargeAmountOfData = false;
            this.egvHistory.Location = new System.Drawing.Point(0, 95);
            this.egvHistory.Name = "egvHistory";
            this.egvHistory.RowHeadersVisible = false;
            this.egvHistory.Size = new System.Drawing.Size(1139, 388);
            this.egvHistory.TabIndex = 2;
            this.egvHistory.UserID = ((long)(0));
            this.egvHistory.OnFilterChanged += new System.EventHandler(this.egvHistory_OnFilterChanged);
            // 
            // pbSplashControl
            // 
            this.pbSplashControl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbSplashControl.Image = ((System.Drawing.Image)(resources.GetObject("pbSplashControl.Image")));
            this.pbSplashControl.Location = new System.Drawing.Point(513, 229);
            this.pbSplashControl.Name = "pbSplashControl";
            this.pbSplashControl.Size = new System.Drawing.Size(104, 104);
            this.pbSplashControl.TabIndex = 4;
            this.pbSplashControl.TabStop = false;
            this.pbSplashControl.Visible = false;
            // 
            // ColdChainTermoboxDriverAccountingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 483);
            this.Controls.Add(this.pbSplashControl);
            this.Controls.Add(this.egvHistory);
            this.Controls.Add(this.tsMain);
            this.KeyPreview = true;
            this.Name = "ColdChainTermoboxDriverAccountingWindow";
            this.Text = "Выдача термобоксов водителям";
            this.Load += new System.EventHandler(this.TermoboxDriverAccountingWindow_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TermoboxDriverAccountingWindow_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ColdChainTermoboxDriverAccountingWindow_KeyDown);
            this.Controls.SetChildIndex(this.tsMain, 0);
            this.Controls.SetChildIndex(this.egvHistory, 0);
            this.Controls.SetChildIndex(this.pbSplashControl, 0);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSplashControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton btnCancelLoading;
        private System.Windows.Forms.ToolStripSeparator tssAfterRefresh;
        private System.ComponentModel.BackgroundWorker bgwHistoryLoader;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView egvHistory;
        private System.Windows.Forms.PictureBox pbSplashControl;
        private System.Windows.Forms.ToolStripButton btnExportToExcel;
        private System.Windows.Forms.ToolStripSeparator tssAfterExcel;
        private System.Windows.Forms.ToolStripButton btnLink;
        private System.Windows.Forms.ToolStripButton btnUnlink;
        private System.Windows.Forms.ToolStripButton btnMassLink;
    }
}