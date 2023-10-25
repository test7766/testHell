namespace WMSOffice.Window.WriteOff
{
    partial class RequestViewForm
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
            this.mainMenu = new System.Windows.Forms.ToolStrip();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnExportExcel = new System.Windows.Forms.ToolStripButton();
            this.btnExportPdf = new System.Windows.Forms.ToolStripButton();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.dgvMakets = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.dgvDocs = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.mainMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExportExcel,
            this.btnExportPdf,
            this.btnPrint});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1143, 35);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "MainMenu";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 320);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1143, 3);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 323);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1143, 21);
            this.panel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Макеты списания";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 580);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1143, 22);
            this.statusStrip.TabIndex = 7;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Image = global::WMSOffice.Properties.Resources.Excel;
            this.btnExportExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportExcel.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(122, 32);
            this.btnExportExcel.Text = "Экспорт в Excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnExportPdf
            // 
            this.btnExportPdf.Image = global::WMSOffice.Properties.Resources.export_pdf;
            this.btnExportPdf.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportPdf.Name = "btnExportPdf";
            this.btnExportPdf.Size = new System.Drawing.Size(116, 32);
            this.btnExportPdf.Text = "Експорт в PDF";
            this.btnExportPdf.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::WMSOffice.Properties.Resources.document_print;
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(78, 32);
            this.btnPrint.Text = "Печать";
            this.btnPrint.Visible = false;
            // 
            // dgvMakets
            // 
            this.dgvMakets.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvMakets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMakets.LargeAmountOfData = false;
            this.dgvMakets.Location = new System.Drawing.Point(0, 344);
            this.dgvMakets.Name = "dgvMakets";
            this.dgvMakets.RowHeadersVisible = false;
            this.dgvMakets.Size = new System.Drawing.Size(1143, 236);
            this.dgvMakets.TabIndex = 5;
            this.dgvMakets.UserID = ((long)(0));
            // 
            // dgvDocs
            // 
            this.dgvDocs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvDocs.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvDocs.LargeAmountOfData = false;
            this.dgvDocs.Location = new System.Drawing.Point(0, 35);
            this.dgvDocs.Name = "dgvDocs";
            this.dgvDocs.RowHeadersVisible = false;
            this.dgvDocs.Size = new System.Drawing.Size(1143, 285);
            this.dgvDocs.TabIndex = 3;
            this.dgvDocs.UserID = ((long)(0));
            // 
            // RequestViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 602);
            this.Controls.Add(this.dgvMakets);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.dgvDocs);
            this.Controls.Add(this.mainMenu);
            this.MinimizeBox = false;
            this.Name = "RequestViewForm";
            this.ShowIcon = false;
            this.Text = "Заявки на утилизацию";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip mainMenu;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView dgvDocs;
        private System.Windows.Forms.Splitter splitter1;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView dgvMakets;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripButton btnExportExcel;
        private System.Windows.Forms.ToolStripButton btnExportPdf;
        private System.Windows.Forms.ToolStripButton btnPrint;
    }
}