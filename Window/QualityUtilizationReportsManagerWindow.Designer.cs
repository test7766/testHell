namespace WMSOffice.Window
{
    partial class QualityUtilizationReportsManagerWindow
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
            this.tsMainMenu = new System.Windows.Forms.ToolStrip();
            this.sbRefresh = new System.Windows.Forms.ToolStripButton();
            this.sbFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.sbPrintUsageProhibitionReport = new System.Windows.Forms.ToolStripButton();
            this.sbPrintTransferToUtilizationReport = new System.Windows.Forms.ToolStripButton();
            this.sbPrintUtilizationVolumeMethodsReport = new System.Windows.Forms.ToolStripButton();
            this.cmbPrinters = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.sbConsExportActs = new System.Windows.Forms.ToolStripSplitButton();
            this.sbConsExportUsageProhibitionActs = new System.Windows.Forms.ToolStripMenuItem();
            this.sbConsExportTransferToUtilizationActs = new System.Windows.Forms.ToolStripMenuItem();
            this.xdgvActs = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.tsMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMainMenu
            // 
            this.tsMainMenu.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbRefresh,
            this.sbFind,
            this.toolStripSeparator1,
            this.sbPrintUsageProhibitionReport,
            this.sbPrintTransferToUtilizationReport,
            this.sbPrintUtilizationVolumeMethodsReport,
            this.cmbPrinters,
            this.toolStripLabel1,
            this.toolStripSeparator2,
            this.toolStripSeparator3,
            this.sbConsExportActs});
            this.tsMainMenu.Location = new System.Drawing.Point(0, 40);
            this.tsMainMenu.Name = "tsMainMenu";
            this.tsMainMenu.Size = new System.Drawing.Size(1366, 55);
            this.tsMainMenu.TabIndex = 1;
            this.tsMainMenu.Text = "toolStrip1";
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
            // sbFind
            // 
            this.sbFind.Image = global::WMSOffice.Properties.Resources.find;
            this.sbFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbFind.Name = "sbFind";
            this.sbFind.Size = new System.Drawing.Size(94, 52);
            this.sbFind.Text = "Поиск";
            this.sbFind.Click += new System.EventHandler(this.sbFind_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // sbPrintUsageProhibitionReport
            // 
            this.sbPrintUsageProhibitionReport.Image = global::WMSOffice.Properties.Resources.document_print;
            this.sbPrintUsageProhibitionReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbPrintUsageProhibitionReport.Name = "sbPrintUsageProhibitionReport";
            this.sbPrintUsageProhibitionReport.Size = new System.Drawing.Size(171, 52);
            this.sbPrintUsageProhibitionReport.Text = "Печать Акта\n\"ЛС не подлежащие\nиспользованию\"";
            this.sbPrintUsageProhibitionReport.Click += new System.EventHandler(this.sbPrintUsageProhibitionReport_Click);
            // 
            // sbPrintTransferToUtilizationReport
            // 
            this.sbPrintTransferToUtilizationReport.Image = global::WMSOffice.Properties.Resources.document_print;
            this.sbPrintTransferToUtilizationReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbPrintTransferToUtilizationReport.Name = "sbPrintTransferToUtilizationReport";
            this.sbPrintTransferToUtilizationReport.Size = new System.Drawing.Size(150, 52);
            this.sbPrintTransferToUtilizationReport.Text = "Печать Акта\n\"ЛС переданные\nна утилизацию\"";
            this.sbPrintTransferToUtilizationReport.Click += new System.EventHandler(this.sbPrintTransferToUtilizationReport_Click);
            // 
            // sbPrintUtilizationVolumeMethodsReport
            // 
            this.sbPrintUtilizationVolumeMethodsReport.Image = global::WMSOffice.Properties.Resources.document_print;
            this.sbPrintUtilizationVolumeMethodsReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbPrintUtilizationVolumeMethodsReport.Name = "sbPrintUtilizationVolumeMethodsReport";
            this.sbPrintUtilizationVolumeMethodsReport.Size = new System.Drawing.Size(157, 52);
            this.sbPrintUtilizationVolumeMethodsReport.Text = "Печать Акта\n\"Объем и методы\nуничтожения\"";
            this.sbPrintUtilizationVolumeMethodsReport.Click += new System.EventHandler(this.sbPrintUtilizationVolumeMethodsReport_Click);
            // 
            // cmbPrinters
            // 
            this.cmbPrinters.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cmbPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinters.Name = "cmbPrinters";
            this.cmbPrinters.Size = new System.Drawing.Size(250, 55);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(61, 52);
            this.toolStripLabel1.Text = "Принтер :";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 55);
            // 
            // sbConsExportActs
            // 
            this.sbConsExportActs.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbConsExportUsageProhibitionActs,
            this.sbConsExportTransferToUtilizationActs});
            this.sbConsExportActs.Image = global::WMSOffice.Properties.Resources.Excel;
            this.sbConsExportActs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbConsExportActs.Name = "sbConsExportActs";
            this.sbConsExportActs.Size = new System.Drawing.Size(148, 52);
            this.sbConsExportActs.Text = "Конс.\nэкспорт";
            // 
            // sbConsExportUsageProhibitionActs
            // 
            this.sbConsExportUsageProhibitionActs.Name = "sbConsExportUsageProhibitionActs";
            this.sbConsExportUsageProhibitionActs.Size = new System.Drawing.Size(395, 22);
            this.sbConsExportUsageProhibitionActs.Text = "Конс. экспорт актов \"ЛС не подлежащие использованию\"";
            this.sbConsExportUsageProhibitionActs.Click += new System.EventHandler(this.sbConsExportUsageProhibitionActs_Click);
            // 
            // sbConsExportTransferToUtilizationActs
            // 
            this.sbConsExportTransferToUtilizationActs.Name = "sbConsExportTransferToUtilizationActs";
            this.sbConsExportTransferToUtilizationActs.Size = new System.Drawing.Size(395, 22);
            this.sbConsExportTransferToUtilizationActs.Text = "Конс. экспорт актов \"ЛС переданные на утилизацию\"";
            this.sbConsExportTransferToUtilizationActs.Click += new System.EventHandler(this.sbConsExportTransferToUtilizationActs_Click);
            // 
            // xdgvActs
            // 
            this.xdgvActs.AllowSort = true;
            this.xdgvActs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvActs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvActs.LargeAmountOfData = false;
            this.xdgvActs.Location = new System.Drawing.Point(0, 95);
            this.xdgvActs.Name = "xdgvActs";
            this.xdgvActs.RowHeadersVisible = false;
            this.xdgvActs.Size = new System.Drawing.Size(1366, 489);
            this.xdgvActs.TabIndex = 2;
            this.xdgvActs.UserID = ((long)(0));
            // 
            // QualityUtilizationReportsManagerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 584);
            this.Controls.Add(this.xdgvActs);
            this.Controls.Add(this.tsMainMenu);
            this.Name = "QualityUtilizationReportsManagerWindow";
            this.Text = "QualityUtilizationReportsManagerWindow";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.QualityUtilizationReportsManagerWindow_FormClosed);
            this.Controls.SetChildIndex(this.tsMainMenu, 0);
            this.Controls.SetChildIndex(this.xdgvActs, 0);
            this.tsMainMenu.ResumeLayout(false);
            this.tsMainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMainMenu;
        private System.Windows.Forms.ToolStripButton sbRefresh;
        private System.Windows.Forms.ToolStripButton sbFind;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton sbPrintUsageProhibitionReport;
        private System.Windows.Forms.ToolStripButton sbPrintTransferToUtilizationReport;
        private System.Windows.Forms.ToolStripButton sbPrintUtilizationVolumeMethodsReport;
        private System.Windows.Forms.ToolStripComboBox cmbPrinters;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvActs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSplitButton sbConsExportActs;
        private System.Windows.Forms.ToolStripMenuItem sbConsExportUsageProhibitionActs;
        private System.Windows.Forms.ToolStripMenuItem sbConsExportTransferToUtilizationActs;
    }
}