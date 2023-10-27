namespace WMSOffice.Dialogs.Inventory
{
    partial class InventoryScheduleStationsEditForm
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
            this.pnlContent = new System.Windows.Forms.Panel();
            this.scPlannedStations = new System.Windows.Forms.SplitContainer();
            this.pnlPlannedStations = new System.Windows.Forms.Panel();
            this.pnlPlannedStationsContent = new System.Windows.Forms.Panel();
            this.tsPlannedStations = new System.Windows.Forms.ToolStrip();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.xdgvPlannedStations = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.lblPlannedStations = new System.Windows.Forms.Label();
            this.scAvailableStations = new System.Windows.Forms.SplitContainer();
            this.btnCancelStation = new System.Windows.Forms.Button();
            this.btnAssignStation = new System.Windows.Forms.Button();
            this.pnlAvailableStations = new System.Windows.Forms.Panel();
            this.pnlAvailableStationsContent = new System.Windows.Forms.Panel();
            this.tsAvailableStations = new System.Windows.Forms.ToolStrip();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnImport = new System.Windows.Forms.ToolStripButton();
            this.xdgvAvailableStations = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.lblAvailableStations = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.scPlannedStations.Panel1.SuspendLayout();
            this.scPlannedStations.Panel2.SuspendLayout();
            this.scPlannedStations.SuspendLayout();
            this.pnlPlannedStations.SuspendLayout();
            this.pnlPlannedStationsContent.SuspendLayout();
            this.tsPlannedStations.SuspendLayout();
            this.scAvailableStations.Panel1.SuspendLayout();
            this.scAvailableStations.Panel2.SuspendLayout();
            this.scAvailableStations.SuspendLayout();
            this.pnlAvailableStations.SuspendLayout();
            this.pnlAvailableStationsContent.SuspendLayout();
            this.tsAvailableStations.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(1861, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1951, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 628);
            this.pnlButtons.Size = new System.Drawing.Size(1194, 43);
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContent.Controls.Add(this.scPlannedStations);
            this.pnlContent.Location = new System.Drawing.Point(0, 2);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1194, 620);
            this.pnlContent.TabIndex = 101;
            // 
            // scPlannedStations
            // 
            this.scPlannedStations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scPlannedStations.Location = new System.Drawing.Point(0, 0);
            this.scPlannedStations.Name = "scPlannedStations";
            // 
            // scPlannedStations.Panel1
            // 
            this.scPlannedStations.Panel1.Controls.Add(this.pnlPlannedStations);
            // 
            // scPlannedStations.Panel2
            // 
            this.scPlannedStations.Panel2.Controls.Add(this.scAvailableStations);
            this.scPlannedStations.Size = new System.Drawing.Size(1194, 620);
            this.scPlannedStations.SplitterDistance = 557;
            this.scPlannedStations.TabIndex = 0;
            // 
            // pnlPlannedStations
            // 
            this.pnlPlannedStations.Controls.Add(this.pnlPlannedStationsContent);
            this.pnlPlannedStations.Controls.Add(this.lblPlannedStations);
            this.pnlPlannedStations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPlannedStations.Location = new System.Drawing.Point(0, 0);
            this.pnlPlannedStations.Name = "pnlPlannedStations";
            this.pnlPlannedStations.Size = new System.Drawing.Size(557, 620);
            this.pnlPlannedStations.TabIndex = 2;
            // 
            // pnlPlannedStationsContent
            // 
            this.pnlPlannedStationsContent.Controls.Add(this.tsPlannedStations);
            this.pnlPlannedStationsContent.Controls.Add(this.xdgvPlannedStations);
            this.pnlPlannedStationsContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPlannedStationsContent.Location = new System.Drawing.Point(0, 20);
            this.pnlPlannedStationsContent.Name = "pnlPlannedStationsContent";
            this.pnlPlannedStationsContent.Size = new System.Drawing.Size(557, 600);
            this.pnlPlannedStationsContent.TabIndex = 1;
            // 
            // tsPlannedStations
            // 
            this.tsPlannedStations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExport,
            this.toolStripSeparator2});
            this.tsPlannedStations.Location = new System.Drawing.Point(0, 0);
            this.tsPlannedStations.Name = "tsPlannedStations";
            this.tsPlannedStations.Size = new System.Drawing.Size(557, 25);
            this.tsPlannedStations.TabIndex = 0;
            this.tsPlannedStations.Text = "toolStrip1";
            // 
            // btnExport
            // 
            this.btnExport.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnExport.Image = global::WMSOffice.Properties.Resources.Excel;
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(72, 22);
            this.btnExport.Text = "Экспорт";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // xdgvPlannedStations
            // 
            this.xdgvPlannedStations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xdgvPlannedStations.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvPlannedStations.LargeAmountOfData = false;
            this.xdgvPlannedStations.Location = new System.Drawing.Point(0, 28);
            this.xdgvPlannedStations.Name = "xdgvPlannedStations";
            this.xdgvPlannedStations.RowHeadersVisible = false;
            this.xdgvPlannedStations.Size = new System.Drawing.Size(557, 572);
            this.xdgvPlannedStations.TabIndex = 1;
            this.xdgvPlannedStations.UserID = ((long)(0));
            // 
            // lblPlannedStations
            // 
            this.lblPlannedStations.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblPlannedStations.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPlannedStations.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPlannedStations.Location = new System.Drawing.Point(0, 0);
            this.lblPlannedStations.Name = "lblPlannedStations";
            this.lblPlannedStations.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.lblPlannedStations.Size = new System.Drawing.Size(557, 20);
            this.lblPlannedStations.TabIndex = 0;
            this.lblPlannedStations.Text = "Запланированные станции";
            // 
            // scAvailableStations
            // 
            this.scAvailableStations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scAvailableStations.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scAvailableStations.Location = new System.Drawing.Point(0, 0);
            this.scAvailableStations.Name = "scAvailableStations";
            // 
            // scAvailableStations.Panel1
            // 
            this.scAvailableStations.Panel1.Controls.Add(this.btnCancelStation);
            this.scAvailableStations.Panel1.Controls.Add(this.btnAssignStation);
            // 
            // scAvailableStations.Panel2
            // 
            this.scAvailableStations.Panel2.Controls.Add(this.pnlAvailableStations);
            this.scAvailableStations.Panel2MinSize = 100;
            this.scAvailableStations.Size = new System.Drawing.Size(633, 620);
            this.scAvailableStations.SplitterDistance = 83;
            this.scAvailableStations.TabIndex = 0;
            // 
            // btnCancelStation
            // 
            this.btnCancelStation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancelStation.Image = global::WMSOffice.Properties.Resources.arrow_right;
            this.btnCancelStation.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancelStation.Location = new System.Drawing.Point(3, 325);
            this.btnCancelStation.Name = "btnCancelStation";
            this.btnCancelStation.Size = new System.Drawing.Size(76, 40);
            this.btnCancelStation.TabIndex = 4;
            this.btnCancelStation.Text = "Снять";
            this.btnCancelStation.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelStation.UseVisualStyleBackColor = true;
            this.btnCancelStation.Click += new System.EventHandler(this.btnCancelStation_Click);
            // 
            // btnAssignStation
            // 
            this.btnAssignStation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAssignStation.Image = global::WMSOffice.Properties.Resources.arrow_left;
            this.btnAssignStation.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAssignStation.Location = new System.Drawing.Point(3, 256);
            this.btnAssignStation.Name = "btnAssignStation";
            this.btnAssignStation.Size = new System.Drawing.Size(76, 40);
            this.btnAssignStation.TabIndex = 3;
            this.btnAssignStation.Text = "Назначить";
            this.btnAssignStation.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAssignStation.UseVisualStyleBackColor = true;
            this.btnAssignStation.Click += new System.EventHandler(this.btnAssignStation_Click);
            // 
            // pnlAvailableStations
            // 
            this.pnlAvailableStations.Controls.Add(this.pnlAvailableStationsContent);
            this.pnlAvailableStations.Controls.Add(this.lblAvailableStations);
            this.pnlAvailableStations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAvailableStations.Location = new System.Drawing.Point(0, 0);
            this.pnlAvailableStations.Name = "pnlAvailableStations";
            this.pnlAvailableStations.Size = new System.Drawing.Size(546, 620);
            this.pnlAvailableStations.TabIndex = 2;
            // 
            // pnlAvailableStationsContent
            // 
            this.pnlAvailableStationsContent.Controls.Add(this.tsAvailableStations);
            this.pnlAvailableStationsContent.Controls.Add(this.xdgvAvailableStations);
            this.pnlAvailableStationsContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAvailableStationsContent.Location = new System.Drawing.Point(0, 20);
            this.pnlAvailableStationsContent.Name = "pnlAvailableStationsContent";
            this.pnlAvailableStationsContent.Size = new System.Drawing.Size(546, 600);
            this.pnlAvailableStationsContent.TabIndex = 2;
            // 
            // tsAvailableStations
            // 
            this.tsAvailableStations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDelete,
            this.toolStripSeparator1,
            this.btnImport});
            this.tsAvailableStations.Location = new System.Drawing.Point(0, 0);
            this.tsAvailableStations.Name = "tsAvailableStations";
            this.tsAvailableStations.Size = new System.Drawing.Size(546, 25);
            this.tsAvailableStations.TabIndex = 0;
            this.tsAvailableStations.Text = "toolStrip2";
            // 
            // btnDelete
            // 
            this.btnDelete.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnDelete.Image = global::WMSOffice.Properties.Resources.Delete;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(71, 22);
            this.btnDelete.Text = "Удалить";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnImport
            // 
            this.btnImport.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnImport.Image = global::WMSOffice.Properties.Resources.Excel;
            this.btnImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(71, 22);
            this.btnImport.Text = "Импорт";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // xdgvAvailableStations
            // 
            this.xdgvAvailableStations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xdgvAvailableStations.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvAvailableStations.LargeAmountOfData = false;
            this.xdgvAvailableStations.Location = new System.Drawing.Point(0, 28);
            this.xdgvAvailableStations.Name = "xdgvAvailableStations";
            this.xdgvAvailableStations.RowHeadersVisible = false;
            this.xdgvAvailableStations.Size = new System.Drawing.Size(546, 572);
            this.xdgvAvailableStations.TabIndex = 1;
            this.xdgvAvailableStations.UserID = ((long)(0));
            // 
            // lblAvailableStations
            // 
            this.lblAvailableStations.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblAvailableStations.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAvailableStations.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAvailableStations.Location = new System.Drawing.Point(0, 0);
            this.lblAvailableStations.Name = "lblAvailableStations";
            this.lblAvailableStations.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.lblAvailableStations.Size = new System.Drawing.Size(546, 20);
            this.lblAvailableStations.TabIndex = 1;
            this.lblAvailableStations.Text = "Доступные станции";
            // 
            // InventoryScheduleStationsEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 671);
            this.Controls.Add(this.pnlContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "InventoryScheduleStationsEditForm";
            this.Text = "Планирование станций";
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.scPlannedStations.Panel1.ResumeLayout(false);
            this.scPlannedStations.Panel2.ResumeLayout(false);
            this.scPlannedStations.ResumeLayout(false);
            this.pnlPlannedStations.ResumeLayout(false);
            this.pnlPlannedStationsContent.ResumeLayout(false);
            this.pnlPlannedStationsContent.PerformLayout();
            this.tsPlannedStations.ResumeLayout(false);
            this.tsPlannedStations.PerformLayout();
            this.scAvailableStations.Panel1.ResumeLayout(false);
            this.scAvailableStations.Panel2.ResumeLayout(false);
            this.scAvailableStations.ResumeLayout(false);
            this.pnlAvailableStations.ResumeLayout(false);
            this.pnlAvailableStationsContent.ResumeLayout(false);
            this.pnlAvailableStationsContent.PerformLayout();
            this.tsAvailableStations.ResumeLayout(false);
            this.tsAvailableStations.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.SplitContainer scPlannedStations;
        private System.Windows.Forms.SplitContainer scAvailableStations;
        private System.Windows.Forms.Button btnCancelStation;
        private System.Windows.Forms.Button btnAssignStation;
        private System.Windows.Forms.ToolStrip tsPlannedStations;
        private System.Windows.Forms.ToolStrip tsAvailableStations;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvPlannedStations;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvAvailableStations;
        private System.Windows.Forms.ToolStripButton btnImport;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.Panel pnlPlannedStations;
        private System.Windows.Forms.Label lblPlannedStations;
        private System.Windows.Forms.ToolStripButton btnExport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel pnlPlannedStationsContent;
        private System.Windows.Forms.Panel pnlAvailableStations;
        private System.Windows.Forms.Panel pnlAvailableStationsContent;
        private System.Windows.Forms.Label lblAvailableStations;
    }
}