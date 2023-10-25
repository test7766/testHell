namespace WMSOffice.Window
{
    partial class TareWeighingWindow
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
            this.tsMainToolbar = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSetTareWeight = new System.Windows.Forms.ToolStripButton();
            this.btnExport = new System.Windows.Forms.ToolStripSplitButton();
            this.miExportAll = new System.Windows.Forms.ToolStripMenuItem();
            this.miExportSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.xdgvData = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.tsMainToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMainToolbar
            // 
            this.tsMainToolbar.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMainToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.toolStripSeparator1,
            this.btnSetTareWeight,
            this.btnExport});
            this.tsMainToolbar.Location = new System.Drawing.Point(0, 40);
            this.tsMainToolbar.Name = "tsMainToolbar";
            this.tsMainToolbar.Size = new System.Drawing.Size(740, 55);
            this.tsMainToolbar.TabIndex = 1;
            this.tsMainToolbar.Text = "toolStrip1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(128, 52);
            this.btnRefresh.Text = "Обновить\nсписок тары";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // btnSetTareWeight
            // 
            this.btnSetTareWeight.Image = global::WMSOffice.Properties.Resources.Sensor;
            this.btnSetTareWeight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSetTareWeight.Name = "btnSetTareWeight";
            this.btnSetTareWeight.Size = new System.Drawing.Size(107, 52);
            this.btnSetTareWeight.Text = "Взвесить\nтару";
            this.btnSetTareWeight.Click += new System.EventHandler(this.btnSetTareWeight_Click);
            // 
            // btnExport
            // 
            this.btnExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miExportAll,
            this.miExportSelected});
            this.btnExport.Image = global::WMSOffice.Properties.Resources.Excel;
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(184, 52);
            this.btnExport.Text = "Журнал результатов\nвзвешивания";
            this.btnExport.ButtonClick += new System.EventHandler(this.btnExport_ButtonClick);
            // 
            // miExportAll
            // 
            this.miExportAll.Name = "miExportAll";
            this.miExportAll.Size = new System.Drawing.Size(152, 22);
            this.miExportAll.Text = "Полный";
            this.miExportAll.Click += new System.EventHandler(this.miExportAll_Click);
            // 
            // miExportSelected
            // 
            this.miExportSelected.Name = "miExportSelected";
            this.miExportSelected.Size = new System.Drawing.Size(152, 22);
            this.miExportSelected.Text = "Выборочный";
            this.miExportSelected.Click += new System.EventHandler(this.miExportSelected_Click);
            // 
            // xdgvData
            // 
            this.xdgvData.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvData.LargeAmountOfData = false;
            this.xdgvData.Location = new System.Drawing.Point(0, 95);
            this.xdgvData.Name = "xdgvData";
            this.xdgvData.RowHeadersVisible = false;
            this.xdgvData.Size = new System.Drawing.Size(740, 293);
            this.xdgvData.TabIndex = 2;
            this.xdgvData.UserID = ((long)(0));
            // 
            // TareWeighingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 388);
            this.Controls.Add(this.xdgvData);
            this.Controls.Add(this.tsMainToolbar);
            this.Name = "TareWeighingWindow";
            this.Text = "TareWeighingWindow";
            this.Controls.SetChildIndex(this.tsMainToolbar, 0);
            this.Controls.SetChildIndex(this.xdgvData, 0);
            this.tsMainToolbar.ResumeLayout(false);
            this.tsMainToolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMainToolbar;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnSetTareWeight;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvData;
        private System.Windows.Forms.ToolStripSplitButton btnExport;
        private System.Windows.Forms.ToolStripMenuItem miExportAll;
        private System.Windows.Forms.ToolStripMenuItem miExportSelected;
    }
}