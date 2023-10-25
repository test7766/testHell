namespace WMSOffice.Window
{
    partial class DebtorsReturnedTareBalanceWindow
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
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnUndoLevel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExport = new System.Windows.Forms.ToolStripSplitButton();
            this.miExportPartialData = new System.Windows.Forms.ToolStripMenuItem();
            this.miExportFullData = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.xdgvItems = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.tsSearch = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSetTareException = new System.Windows.Forms.ToolStripButton();
            this.tsMain.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.btnUndoLevel,
            this.toolStripSeparator1,
            this.btnExport,
            this.toolStripSeparator2,
            this.btnSetTareException});
            this.tsMain.Location = new System.Drawing.Point(0, 40);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(740, 55);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(113, 52);
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnUndoLevel
            // 
            this.btnUndoLevel.Image = global::WMSOffice.Properties.Resources.undo43;
            this.btnUndoLevel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUndoLevel.Name = "btnUndoLevel";
            this.btnUndoLevel.Size = new System.Drawing.Size(122, 52);
            this.btnUndoLevel.Text = "На уровень\nвыше";
            this.btnUndoLevel.Click += new System.EventHandler(this.btnUndoLevel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // btnExport
            // 
            this.btnExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miExportPartialData,
            this.miExportFullData});
            this.btnExport.Image = global::WMSOffice.Properties.Resources.Excel;
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(116, 52);
            this.btnExport.Text = "Экспорт\nв Excel";
            this.btnExport.ButtonClick += new System.EventHandler(this.btnExport_ButtonClick);
            // 
            // miExportPartialData
            // 
            this.miExportPartialData.Name = "miExportPartialData";
            this.miExportPartialData.Size = new System.Drawing.Size(152, 22);
            this.miExportPartialData.Text = "Текущий";
            this.miExportPartialData.Click += new System.EventHandler(this.miExportPartialData_Click);
            // 
            // miExportFullData
            // 
            this.miExportFullData.Name = "miExportFullData";
            this.miExportFullData.Size = new System.Drawing.Size(152, 22);
            this.miExportFullData.Text = "Полный";
            this.miExportFullData.Click += new System.EventHandler(this.miExportFullData_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.xdgvItems);
            this.pnlContent.Controls.Add(this.tsSearch);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 95);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(740, 293);
            this.pnlContent.TabIndex = 2;
            // 
            // xdgvItems
            // 
            this.xdgvItems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvItems.LargeAmountOfData = false;
            this.xdgvItems.Location = new System.Drawing.Point(0, 25);
            this.xdgvItems.Name = "xdgvItems";
            this.xdgvItems.RowHeadersVisible = false;
            this.xdgvItems.Size = new System.Drawing.Size(740, 268);
            this.xdgvItems.TabIndex = 1;
            this.xdgvItems.UserID = ((long)(0));
            // 
            // tsSearch
            // 
            this.tsSearch.Location = new System.Drawing.Point(0, 0);
            this.tsSearch.Name = "tsSearch";
            this.tsSearch.Size = new System.Drawing.Size(740, 25);
            this.tsSearch.TabIndex = 0;
            this.tsSearch.Text = "toolStrip2";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // btnSetTareException
            // 
            this.btnSetTareException.Image = global::WMSOffice.Properties.Resources.symbol_stop;
            this.btnSetTareException.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSetTareException.Name = "btnSetTareException";
            this.btnSetTareException.Size = new System.Drawing.Size(132, 52);
            this.btnSetTareException.Text = "Отменить ОТ";
            this.btnSetTareException.Click += new System.EventHandler(this.btnSetTareException_Click);
            // 
            // DebtorsReturnedTareBalanceWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 388);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.tsMain);
            this.Name = "DebtorsReturnedTareBalanceWindow";
            this.Text = "DebtorsReturnedTareBalanceWindow";
            this.Controls.SetChildIndex(this.tsMain, 0);
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.ToolStrip tsSearch;
        private System.Windows.Forms.ToolStripButton btnUndoLevel;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvItems;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSplitButton btnExport;
        private System.Windows.Forms.ToolStripMenuItem miExportPartialData;
        private System.Windows.Forms.ToolStripMenuItem miExportFullData;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnSetTareException;
    }
}