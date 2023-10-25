namespace WMSOffice.Window
{
    partial class DebtorsReturnedTareWindow
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
            this.sbRefresh = new System.Windows.Forms.ToolStripButton();
            this.sbUndoLevel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.sbExport = new System.Windows.Forms.ToolStripSplitButton();
            this.miExportPartialData = new System.Windows.Forms.ToolStripMenuItem();
            this.miExportFullData = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.miExportHistoryData = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.sbPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.sbAssign = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.sbRepeatPrint = new System.Windows.Forms.ToolStripButton();
            this.cmbPrinters = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.sbTareIssue = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.sbSetDublicate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.sbTareSetIlliquid = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.sbOpenInventoryManager = new System.Windows.Forms.ToolStripButton();
            this.xdgvItems = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.tsSearch = new System.Windows.Forms.ToolStrip();
            this.tsMain.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbRefresh,
            this.sbUndoLevel,
            this.toolStripSeparator1,
            this.sbExport,
            this.toolStripSeparator6,
            this.sbPrint,
            this.toolStripSeparator3,
            this.sbAssign,
            this.toolStripSeparator9,
            this.sbRepeatPrint,
            this.cmbPrinters,
            this.toolStripLabel1,
            this.toolStripSeparator4,
            this.toolStripSeparator5,
            this.sbTareIssue,
            this.toolStripSeparator2,
            this.sbSetDublicate,
            this.toolStripSeparator7,
            this.sbTareSetIlliquid,
            this.toolStripSeparator10,
            this.sbOpenInventoryManager});
            this.tsMain.Location = new System.Drawing.Point(0, 40);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1617, 55);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
            // 
            // sbRefresh
            // 
            this.sbRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.sbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbRefresh.Name = "sbRefresh";
            this.sbRefresh.Size = new System.Drawing.Size(113, 52);
            this.sbRefresh.Text = "Обновить";
            this.sbRefresh.Click += new System.EventHandler(this.sbRefresh_Click);
            // 
            // sbUndoLevel
            // 
            this.sbUndoLevel.Image = global::WMSOffice.Properties.Resources.undo43;
            this.sbUndoLevel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbUndoLevel.Name = "sbUndoLevel";
            this.sbUndoLevel.Size = new System.Drawing.Size(122, 52);
            this.sbUndoLevel.Text = "На уровень\nвыше";
            this.sbUndoLevel.Click += new System.EventHandler(this.sbUndoLevel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // sbExport
            // 
            this.sbExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miExportPartialData,
            this.miExportFullData,
            this.toolStripSeparator8,
            this.miExportHistoryData});
            this.sbExport.Image = global::WMSOffice.Properties.Resources.Excel;
            this.sbExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbExport.Name = "sbExport";
            this.sbExport.Size = new System.Drawing.Size(116, 52);
            this.sbExport.Text = "Экспорт\nв Excel";
            this.sbExport.ButtonClick += new System.EventHandler(this.sbExport_ButtonClick);
            // 
            // miExportPartialData
            // 
            this.miExportPartialData.Name = "miExportPartialData";
            this.miExportPartialData.Size = new System.Drawing.Size(124, 22);
            this.miExportPartialData.Text = "Текущий";
            this.miExportPartialData.Click += new System.EventHandler(this.miExportCurrentData_Click);
            // 
            // miExportFullData
            // 
            this.miExportFullData.Name = "miExportFullData";
            this.miExportFullData.Size = new System.Drawing.Size(124, 22);
            this.miExportFullData.Text = "Полный";
            this.miExportFullData.Click += new System.EventHandler(this.miExportFullData_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(121, 6);
            // 
            // miExportHistoryData
            // 
            this.miExportHistoryData.Name = "miExportHistoryData";
            this.miExportHistoryData.Size = new System.Drawing.Size(124, 22);
            this.miExportHistoryData.Text = "История";
            this.miExportHistoryData.Click += new System.EventHandler(this.miExportHistoryData_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 55);
            // 
            // sbPrint
            // 
            this.sbPrint.Image = global::WMSOffice.Properties.Resources.barcode;
            this.sbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbPrint.Name = "sbPrint";
            this.sbPrint.Size = new System.Drawing.Size(107, 52);
            this.sbPrint.Text = "Печать\nэтикеток";
            this.sbPrint.Click += new System.EventHandler(this.sbPrint_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 55);
            // 
            // sbAssign
            // 
            this.sbAssign.Image = global::WMSOffice.Properties.Resources.link;
            this.sbAssign.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbAssign.Name = "sbAssign";
            this.sbAssign.Size = new System.Drawing.Size(111, 52);
            this.sbAssign.Text = "Привязка\nэтикеток";
            this.sbAssign.Click += new System.EventHandler(this.sbAssign_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 55);
            this.toolStripSeparator9.Visible = false;
            // 
            // sbRepeatPrint
            // 
            this.sbRepeatPrint.Image = global::WMSOffice.Properties.Resources.barcode;
            this.sbRepeatPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbRepeatPrint.Name = "sbRepeatPrint";
            this.sbRepeatPrint.Size = new System.Drawing.Size(119, 52);
            this.sbRepeatPrint.Text = "Повторная\nпечать\nэтикеток";
            this.sbRepeatPrint.Visible = false;
            this.sbRepeatPrint.Click += new System.EventHandler(this.sbRepeatPrint_Click);
            // 
            // cmbPrinters
            // 
            this.cmbPrinters.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cmbPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinters.Name = "cmbPrinters";
            this.cmbPrinters.Size = new System.Drawing.Size(150, 55);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(58, 52);
            this.toolStripLabel1.Text = "Принтер:";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 55);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 55);
            // 
            // sbTareIssue
            // 
            this.sbTareIssue.Image = global::WMSOffice.Properties.Resources.assign;
            this.sbTareIssue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbTareIssue.Name = "sbTareIssue";
            this.sbTareIssue.Size = new System.Drawing.Size(120, 52);
            this.sbTareIssue.Text = "Выдача\nоборотной\nтары";
            this.sbTareIssue.Click += new System.EventHandler(this.sbTareIssue_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // sbSetDublicate
            // 
            this.sbSetDublicate.Image = global::WMSOffice.Properties.Resources.barcode;
            this.sbSetDublicate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbSetDublicate.Name = "sbSetDublicate";
            this.sbSetDublicate.Size = new System.Drawing.Size(123, 52);
            this.sbSetDublicate.Text = "Фиксация\nдублей ш/к";
            this.sbSetDublicate.Click += new System.EventHandler(this.sbSetDublicate_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 55);
            // 
            // sbTareSetIlliquid
            // 
            this.sbTareSetIlliquid.Image = global::WMSOffice.Properties.Resources.hand_yellow_card;
            this.sbTareSetIlliquid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbTareSetIlliquid.Name = "sbTareSetIlliquid";
            this.sbTareSetIlliquid.Size = new System.Drawing.Size(128, 52);
            this.sbTareSetIlliquid.Text = "Регистрация\nбоя";
            this.sbTareSetIlliquid.Click += new System.EventHandler(this.sbTareSetIlliquid_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 55);
            // 
            // sbOpenInventoryManager
            // 
            this.sbOpenInventoryManager.Image = global::WMSOffice.Properties.Resources.Calc;
            this.sbOpenInventoryManager.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbOpenInventoryManager.Name = "sbOpenInventoryManager";
            this.sbOpenInventoryManager.Size = new System.Drawing.Size(149, 52);
            this.sbOpenInventoryManager.Text = "Менеджер\nинвентаризации";
            this.sbOpenInventoryManager.Click += new System.EventHandler(this.sbOpenInventoryManager_Click);
            // 
            // xdgvItems
            // 
            this.xdgvItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xdgvItems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvItems.LargeAmountOfData = false;
            this.xdgvItems.Location = new System.Drawing.Point(0, 28);
            this.xdgvItems.Name = "xdgvItems";
            this.xdgvItems.RowHeadersVisible = false;
            this.xdgvItems.Size = new System.Drawing.Size(1617, 516);
            this.xdgvItems.TabIndex = 2;
            this.xdgvItems.UserID = ((long)(0));
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.tsSearch);
            this.pnlContent.Controls.Add(this.xdgvItems);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 95);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1617, 544);
            this.pnlContent.TabIndex = 3;
            // 
            // tsSearch
            // 
            this.tsSearch.Location = new System.Drawing.Point(0, 0);
            this.tsSearch.Name = "tsSearch";
            this.tsSearch.Size = new System.Drawing.Size(1617, 25);
            this.tsSearch.TabIndex = 3;
            this.tsSearch.Text = "toolStrip1";
            // 
            // DebtorsReturnedTareWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1617, 639);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.tsMain);
            this.Name = "DebtorsReturnedTareWindow";
            this.Text = "ReturnedTareWindow";
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
        private System.Windows.Forms.ToolStripButton sbRefresh;
        private System.Windows.Forms.ToolStripButton sbPrint;
        private System.Windows.Forms.ToolStripButton sbAssign;
        private System.Windows.Forms.ToolStripButton sbRepeatPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvItems;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripComboBox cmbPrinters;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton sbTareIssue;
        private System.Windows.Forms.ToolStripButton sbUndoLevel;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.ToolStrip tsSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSplitButton sbExport;
        private System.Windows.Forms.ToolStripMenuItem miExportPartialData;
        private System.Windows.Forms.ToolStripMenuItem miExportFullData;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton sbTareSetIlliquid;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem miExportHistoryData;
        private System.Windows.Forms.ToolStripButton sbSetDublicate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton sbOpenInventoryManager;
    }
}