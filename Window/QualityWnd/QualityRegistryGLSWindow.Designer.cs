namespace WMSOffice.Window.QualityWnd
{
    partial class QualityRegistryGLSWindow
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.cbPrinter = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ssbPrintRegistry = new System.Windows.Forms.ToolStripSplitButton();
            this.ssbiPrintGlsRegistry = new System.Windows.Forms.ToolStripMenuItem();
            this.ssbiRecalledProductsRegistry = new System.Windows.Forms.ToolStripMenuItem();
            this.ssbiGlsProhibitionsNotificationsRegistry = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.xdgvDocs = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.dgvDetails = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.toolStripSeparator3,
            this.btnFind,
            this.btnPrint,
            this.cbPrinter,
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.btnExportToExcel,
            this.toolStripSeparator4,
            this.ssbPrintRegistry,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 40);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(973, 32);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(93, 29);
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 32);
            // 
            // btnFind
            // 
            this.btnFind.Image = global::WMSOffice.Properties.Resources.find;
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(74, 29);
            this.btnFind.Text = "Поиск";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::WMSOffice.Properties.Resources.document_print;
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(78, 29);
            this.btnPrint.Text = "Печать";
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // cbPrinter
            // 
            this.cbPrinter.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cbPrinter.AutoSize = false;
            this.cbPrinter.Name = "cbPrinter";
            this.cbPrinter.Size = new System.Drawing.Size(210, 23);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(58, 29);
            this.toolStripLabel1.Text = "Принтер:";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 32);
            // 
            // ssbPrintRegistry
            // 
            this.ssbPrintRegistry.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ssbiPrintGlsRegistry,
            this.ssbiRecalledProductsRegistry,
            this.ssbiGlsProhibitionsNotificationsRegistry});
            this.ssbPrintRegistry.Image = global::WMSOffice.Properties.Resources.preview;
            this.ssbPrintRegistry.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ssbPrintRegistry.Name = "ssbPrintRegistry";
            this.ssbPrintRegistry.Size = new System.Drawing.Size(97, 29);
            this.ssbPrintRegistry.Text = "Реестры";
            this.ssbPrintRegistry.ButtonClick += new System.EventHandler(this.ssbPrintRegistry_ButtonClick);
            // 
            // ssbiPrintGlsRegistry
            // 
            this.ssbiPrintGlsRegistry.Name = "ssbiPrintGlsRegistry";
            this.ssbiPrintGlsRegistry.Size = new System.Drawing.Size(417, 22);
            this.ssbiPrintGlsRegistry.Text = "Реестр распоряжений ГЛС";
            this.ssbiPrintGlsRegistry.Click += new System.EventHandler(this.ssbiPrintGlsRegistry_Click);
            // 
            // ssbiRecalledProductsRegistry
            // 
            this.ssbiRecalledProductsRegistry.Name = "ssbiRecalledProductsRegistry";
            this.ssbiRecalledProductsRegistry.Size = new System.Drawing.Size(417, 22);
            this.ssbiRecalledProductsRegistry.Text = "Реестр отозванной продукции";
            this.ssbiRecalledProductsRegistry.Click += new System.EventHandler(this.ssbiRecalledProductsRegistry_Click);
            // 
            // ssbiGlsProhibitionsNotificationsRegistry
            // 
            this.ssbiGlsProhibitionsNotificationsRegistry.Name = "ssbiGlsProhibitionsNotificationsRegistry";
            this.ssbiGlsProhibitionsNotificationsRegistry.Size = new System.Drawing.Size(417, 22);
            this.ssbiGlsProhibitionsNotificationsRegistry.Text = "Реестр уведомлений в ГЛС о постоянном/временном запрете";
            this.ssbiGlsProhibitionsNotificationsRegistry.Click += new System.EventHandler(this.ssbiGlsProhibitionsNotificationsRegistry_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 32);
            // 
            // xdgvDocs
            // 
            this.xdgvDocs.AllowSort = true;
            this.xdgvDocs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvDocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvDocs.LargeAmountOfData = false;
            this.xdgvDocs.Location = new System.Drawing.Point(0, 0);
            this.xdgvDocs.Name = "xdgvDocs";
            this.xdgvDocs.RowHeadersVisible = false;
            this.xdgvDocs.Size = new System.Drawing.Size(973, 481);
            this.xdgvDocs.TabIndex = 2;
            this.xdgvDocs.UserID = ((long)(0));
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowSort = true;
            this.dgvDetails.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails.LargeAmountOfData = false;
            this.dgvDetails.Location = new System.Drawing.Point(0, 0);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.RowHeadersVisible = false;
            this.dgvDetails.Size = new System.Drawing.Size(150, 46);
            this.dgvDetails.TabIndex = 4;
            this.dgvDetails.UserID = ((long)(0));
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 72);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.xdgvDocs);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvDetails);
            this.splitContainer1.Panel2Collapsed = true;
            this.splitContainer1.Size = new System.Drawing.Size(973, 481);
            this.splitContainer1.SplitterDistance = 240;
            this.splitContainer1.TabIndex = 5;
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Image = global::WMSOffice.Properties.Resources.Excel;
            this.btnExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(123, 29);
            this.btnExportToExcel.Text = "Экспорт в Excel";
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 32);
            // 
            // QualityRegistryGLSWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 553);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "QualityRegistryGLSWindow";
            this.Text = "QualityRegistryGLSWindow";
            this.Controls.SetChildIndex(this.toolStrip1, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.ToolStripComboBox cbPrinter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvDocs;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView dgvDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSplitButton ssbPrintRegistry;
        private System.Windows.Forms.ToolStripMenuItem ssbiPrintGlsRegistry;
        private System.Windows.Forms.ToolStripMenuItem ssbiRecalledProductsRegistry;
        private System.Windows.Forms.ToolStripMenuItem ssbiGlsProhibitionsNotificationsRegistry;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnExportToExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;

    }
}