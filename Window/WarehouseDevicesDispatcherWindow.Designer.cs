namespace WMSOffice.Window
{
    partial class WarehouseDevicesDispatcherWindow
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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRestart = new System.Windows.Forms.ToolStripButton();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.scContent = new System.Windows.Forms.SplitContainer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.xdgvClusters = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.xdgvClusterItems = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.tsMain.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.scContent.Panel1.SuspendLayout();
            this.scContent.Panel2.SuspendLayout();
            this.scContent.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.toolStripSeparator1,
            this.btnRestart});
            this.tsMain.Location = new System.Drawing.Point(0, 40);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1160, 55);
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // btnRestart
            // 
            this.btnRestart.Image = global::WMSOffice.Properties.Resources.finish_process;
            this.btnRestart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(123, 52);
            this.btnRestart.Text = "Перезапуск\nсервисов";
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.scContent);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 95);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1160, 462);
            this.pnlMain.TabIndex = 2;
            // 
            // scContent
            // 
            this.scContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scContent.Location = new System.Drawing.Point(0, 0);
            this.scContent.Name = "scContent";
            // 
            // scContent.Panel1
            // 
            this.scContent.Panel1.Controls.Add(this.panel3);
            this.scContent.Panel1.Controls.Add(this.panel1);
            // 
            // scContent.Panel2
            // 
            this.scContent.Panel2.Controls.Add(this.panel4);
            this.scContent.Panel2.Controls.Add(this.panel2);
            this.scContent.Size = new System.Drawing.Size(1160, 462);
            this.scContent.SplitterDistance = 725;
            this.scContent.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.xdgvClusters);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 24);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(725, 438);
            this.panel3.TabIndex = 2;
            // 
            // xdgvClusters
            // 
            this.xdgvClusters.AllowSort = true;
            this.xdgvClusters.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvClusters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvClusters.LargeAmountOfData = false;
            this.xdgvClusters.Location = new System.Drawing.Point(0, 0);
            this.xdgvClusters.Name = "xdgvClusters";
            this.xdgvClusters.RowHeadersVisible = false;
            this.xdgvClusters.Size = new System.Drawing.Size(725, 438);
            this.xdgvClusters.TabIndex = 0;
            this.xdgvClusters.UserID = ((long)(0));
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(725, 24);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.label1.Size = new System.Drawing.Size(725, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Кластеры (Сервисы)";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.xdgvClusterItems);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 24);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(431, 438);
            this.panel4.TabIndex = 2;
            // 
            // xdgvClusterItems
            // 
            this.xdgvClusterItems.AllowSort = true;
            this.xdgvClusterItems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvClusterItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvClusterItems.LargeAmountOfData = false;
            this.xdgvClusterItems.Location = new System.Drawing.Point(0, 0);
            this.xdgvClusterItems.Name = "xdgvClusterItems";
            this.xdgvClusterItems.RowHeadersVisible = false;
            this.xdgvClusterItems.Size = new System.Drawing.Size(431, 438);
            this.xdgvClusterItems.TabIndex = 1;
            this.xdgvClusterItems.UserID = ((long)(0));
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(431, 24);
            this.panel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.label2.Size = new System.Drawing.Size(431, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Зоны (Станции)";
            // 
            // WarehouseDevicesDispatcherWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 557);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.tsMain);
            this.Name = "WarehouseDevicesDispatcherWindow";
            this.Text = "DevicesServicesDispatcherWindow";
            this.Controls.SetChildIndex(this.tsMain, 0);
            this.Controls.SetChildIndex(this.pnlMain, 0);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.scContent.Panel1.ResumeLayout(false);
            this.scContent.Panel2.ResumeLayout(false);
            this.scContent.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnRestart;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.SplitContainer scContent;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvClusters;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvClusterItems;
    }
}