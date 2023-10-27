namespace WMSOffice.Dialogs.Inventory
{
    partial class InventoryScheduleResourcesEditForm
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
            this.scPlannedResources = new System.Windows.Forms.SplitContainer();
            this.pnlPlannedResources = new System.Windows.Forms.Panel();
            this.pnlPlannedResourcesContent = new System.Windows.Forms.Panel();
            this.tsPlannedResources = new System.Windows.Forms.ToolStrip();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.xdgvPlannedResources = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.lblPlannedResources = new System.Windows.Forms.Label();
            this.scAvailableResources = new System.Windows.Forms.SplitContainer();
            this.btnCancelResource = new System.Windows.Forms.Button();
            this.btnAssignResource = new System.Windows.Forms.Button();
            this.pnlAvailableResources = new System.Windows.Forms.Panel();
            this.pnlAvailableResourcesContent = new System.Windows.Forms.Panel();
            this.tsAvailableResources = new System.Windows.Forms.ToolStrip();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnImport = new System.Windows.Forms.ToolStripButton();
            this.xdgvAvailableResources = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.lblAvailableResources = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.scPlannedResources.Panel1.SuspendLayout();
            this.scPlannedResources.Panel2.SuspendLayout();
            this.scPlannedResources.SuspendLayout();
            this.pnlPlannedResources.SuspendLayout();
            this.pnlPlannedResourcesContent.SuspendLayout();
            this.tsPlannedResources.SuspendLayout();
            this.scAvailableResources.Panel1.SuspendLayout();
            this.scAvailableResources.Panel2.SuspendLayout();
            this.scAvailableResources.SuspendLayout();
            this.pnlAvailableResources.SuspendLayout();
            this.pnlAvailableResourcesContent.SuspendLayout();
            this.tsAvailableResources.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(6081, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(6171, 8);
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
            this.pnlContent.Controls.Add(this.scPlannedResources);
            this.pnlContent.Location = new System.Drawing.Point(0, 2);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1194, 620);
            this.pnlContent.TabIndex = 102;
            // 
            // scPlannedResources
            // 
            this.scPlannedResources.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scPlannedResources.Location = new System.Drawing.Point(0, 0);
            this.scPlannedResources.Name = "scPlannedResources";
            // 
            // scPlannedResources.Panel1
            // 
            this.scPlannedResources.Panel1.Controls.Add(this.pnlPlannedResources);
            this.scPlannedResources.Panel1Collapsed = true;
            // 
            // scPlannedResources.Panel2
            // 
            this.scPlannedResources.Panel2.Controls.Add(this.scAvailableResources);
            this.scPlannedResources.Size = new System.Drawing.Size(1194, 620);
            this.scPlannedResources.SplitterDistance = 557;
            this.scPlannedResources.TabIndex = 0;
            // 
            // pnlPlannedResources
            // 
            this.pnlPlannedResources.Controls.Add(this.pnlPlannedResourcesContent);
            this.pnlPlannedResources.Controls.Add(this.lblPlannedResources);
            this.pnlPlannedResources.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPlannedResources.Location = new System.Drawing.Point(0, 0);
            this.pnlPlannedResources.Name = "pnlPlannedResources";
            this.pnlPlannedResources.Size = new System.Drawing.Size(557, 100);
            this.pnlPlannedResources.TabIndex = 2;
            // 
            // pnlPlannedResourcesContent
            // 
            this.pnlPlannedResourcesContent.Controls.Add(this.tsPlannedResources);
            this.pnlPlannedResourcesContent.Controls.Add(this.xdgvPlannedResources);
            this.pnlPlannedResourcesContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPlannedResourcesContent.Location = new System.Drawing.Point(0, 20);
            this.pnlPlannedResourcesContent.Name = "pnlPlannedResourcesContent";
            this.pnlPlannedResourcesContent.Size = new System.Drawing.Size(557, 80);
            this.pnlPlannedResourcesContent.TabIndex = 1;
            // 
            // tsPlannedResources
            // 
            this.tsPlannedResources.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExport,
            this.toolStripSeparator2});
            this.tsPlannedResources.Location = new System.Drawing.Point(0, 0);
            this.tsPlannedResources.Name = "tsPlannedResources";
            this.tsPlannedResources.Size = new System.Drawing.Size(557, 25);
            this.tsPlannedResources.TabIndex = 0;
            this.tsPlannedResources.Text = "toolStrip1";
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
            // xdgvPlannedResources
            // 
            this.xdgvPlannedResources.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xdgvPlannedResources.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvPlannedResources.LargeAmountOfData = false;
            this.xdgvPlannedResources.Location = new System.Drawing.Point(0, 28);
            this.xdgvPlannedResources.Name = "xdgvPlannedResources";
            this.xdgvPlannedResources.RowHeadersVisible = false;
            this.xdgvPlannedResources.Size = new System.Drawing.Size(557, 52);
            this.xdgvPlannedResources.TabIndex = 1;
            this.xdgvPlannedResources.UserID = ((long)(0));
            // 
            // lblPlannedResources
            // 
            this.lblPlannedResources.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblPlannedResources.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPlannedResources.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPlannedResources.Location = new System.Drawing.Point(0, 0);
            this.lblPlannedResources.Name = "lblPlannedResources";
            this.lblPlannedResources.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.lblPlannedResources.Size = new System.Drawing.Size(557, 20);
            this.lblPlannedResources.TabIndex = 0;
            this.lblPlannedResources.Text = "Запланированные ресурсы";
            // 
            // scAvailableResources
            // 
            this.scAvailableResources.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scAvailableResources.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scAvailableResources.Location = new System.Drawing.Point(0, 0);
            this.scAvailableResources.Name = "scAvailableResources";
            // 
            // scAvailableResources.Panel1
            // 
            this.scAvailableResources.Panel1.Controls.Add(this.btnCancelResource);
            this.scAvailableResources.Panel1.Controls.Add(this.btnAssignResource);
            this.scAvailableResources.Panel1Collapsed = true;
            // 
            // scAvailableResources.Panel2
            // 
            this.scAvailableResources.Panel2.Controls.Add(this.pnlAvailableResources);
            this.scAvailableResources.Panel2MinSize = 100;
            this.scAvailableResources.Size = new System.Drawing.Size(1194, 620);
            this.scAvailableResources.SplitterDistance = 83;
            this.scAvailableResources.TabIndex = 0;
            // 
            // btnCancelResource
            // 
            this.btnCancelResource.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancelResource.Image = global::WMSOffice.Properties.Resources.arrow_right;
            this.btnCancelResource.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancelResource.Location = new System.Drawing.Point(3, 325);
            this.btnCancelResource.Name = "btnCancelResource";
            this.btnCancelResource.Size = new System.Drawing.Size(76, 40);
            this.btnCancelResource.TabIndex = 4;
            this.btnCancelResource.Text = "Снять";
            this.btnCancelResource.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelResource.UseVisualStyleBackColor = true;
            this.btnCancelResource.Click += new System.EventHandler(this.btnCancelResource_Click);
            // 
            // btnAssignResource
            // 
            this.btnAssignResource.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAssignResource.Image = global::WMSOffice.Properties.Resources.arrow_left;
            this.btnAssignResource.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAssignResource.Location = new System.Drawing.Point(3, 256);
            this.btnAssignResource.Name = "btnAssignResource";
            this.btnAssignResource.Size = new System.Drawing.Size(76, 40);
            this.btnAssignResource.TabIndex = 3;
            this.btnAssignResource.Text = "Назначить";
            this.btnAssignResource.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAssignResource.UseVisualStyleBackColor = true;
            this.btnAssignResource.Click += new System.EventHandler(this.btnAssignResource_Click);
            // 
            // pnlAvailableResources
            // 
            this.pnlAvailableResources.Controls.Add(this.pnlAvailableResourcesContent);
            this.pnlAvailableResources.Controls.Add(this.lblAvailableResources);
            this.pnlAvailableResources.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAvailableResources.Location = new System.Drawing.Point(0, 0);
            this.pnlAvailableResources.Name = "pnlAvailableResources";
            this.pnlAvailableResources.Size = new System.Drawing.Size(1194, 620);
            this.pnlAvailableResources.TabIndex = 2;
            // 
            // pnlAvailableResourcesContent
            // 
            this.pnlAvailableResourcesContent.Controls.Add(this.tsAvailableResources);
            this.pnlAvailableResourcesContent.Controls.Add(this.xdgvAvailableResources);
            this.pnlAvailableResourcesContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAvailableResourcesContent.Location = new System.Drawing.Point(0, 20);
            this.pnlAvailableResourcesContent.Name = "pnlAvailableResourcesContent";
            this.pnlAvailableResourcesContent.Size = new System.Drawing.Size(1194, 600);
            this.pnlAvailableResourcesContent.TabIndex = 2;
            // 
            // tsAvailableResources
            // 
            this.tsAvailableResources.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEdit,
            this.btnDelete,
            this.toolStripSeparator1,
            this.btnImport});
            this.tsAvailableResources.Location = new System.Drawing.Point(0, 0);
            this.tsAvailableResources.Name = "tsAvailableResources";
            this.tsAvailableResources.Size = new System.Drawing.Size(1194, 25);
            this.tsAvailableResources.TabIndex = 0;
            this.tsAvailableResources.Text = "toolStrip2";
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::WMSOffice.Properties.Resources.edit_document;
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(81, 22);
            this.btnEdit.Text = "Изменить";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::WMSOffice.Properties.Resources.Delete;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(71, 22);
            this.btnDelete.Text = "Удалить";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnImport
            // 
            this.btnImport.Image = global::WMSOffice.Properties.Resources.Excel;
            this.btnImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(71, 22);
            this.btnImport.Text = "Импорт";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // xdgvAvailableResources
            // 
            this.xdgvAvailableResources.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xdgvAvailableResources.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvAvailableResources.LargeAmountOfData = false;
            this.xdgvAvailableResources.Location = new System.Drawing.Point(0, 28);
            this.xdgvAvailableResources.Name = "xdgvAvailableResources";
            this.xdgvAvailableResources.RowHeadersVisible = false;
            this.xdgvAvailableResources.Size = new System.Drawing.Size(1194, 572);
            this.xdgvAvailableResources.TabIndex = 1;
            this.xdgvAvailableResources.UserID = ((long)(0));
            // 
            // lblAvailableResources
            // 
            this.lblAvailableResources.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblAvailableResources.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAvailableResources.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAvailableResources.Location = new System.Drawing.Point(0, 0);
            this.lblAvailableResources.Name = "lblAvailableResources";
            this.lblAvailableResources.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.lblAvailableResources.Size = new System.Drawing.Size(1194, 20);
            this.lblAvailableResources.TabIndex = 1;
            this.lblAvailableResources.Text = "Доступные ресурсы";
            // 
            // InventoryScheduleResourcesEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 671);
            this.Controls.Add(this.pnlContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "InventoryScheduleResourcesEditForm";
            this.Text = "Планирование ресурсов";
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.pnlButtons.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.scPlannedResources.Panel1.ResumeLayout(false);
            this.scPlannedResources.Panel2.ResumeLayout(false);
            this.scPlannedResources.ResumeLayout(false);
            this.pnlPlannedResources.ResumeLayout(false);
            this.pnlPlannedResourcesContent.ResumeLayout(false);
            this.pnlPlannedResourcesContent.PerformLayout();
            this.tsPlannedResources.ResumeLayout(false);
            this.tsPlannedResources.PerformLayout();
            this.scAvailableResources.Panel1.ResumeLayout(false);
            this.scAvailableResources.Panel2.ResumeLayout(false);
            this.scAvailableResources.ResumeLayout(false);
            this.pnlAvailableResources.ResumeLayout(false);
            this.pnlAvailableResourcesContent.ResumeLayout(false);
            this.pnlAvailableResourcesContent.PerformLayout();
            this.tsAvailableResources.ResumeLayout(false);
            this.tsAvailableResources.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.SplitContainer scPlannedResources;
        private System.Windows.Forms.Panel pnlPlannedResources;
        private System.Windows.Forms.Panel pnlPlannedResourcesContent;
        private System.Windows.Forms.ToolStrip tsPlannedResources;
        private System.Windows.Forms.ToolStripButton btnExport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvPlannedResources;
        private System.Windows.Forms.Label lblPlannedResources;
        private System.Windows.Forms.SplitContainer scAvailableResources;
        private System.Windows.Forms.Button btnCancelResource;
        private System.Windows.Forms.Button btnAssignResource;
        private System.Windows.Forms.Panel pnlAvailableResources;
        private System.Windows.Forms.Panel pnlAvailableResourcesContent;
        private System.Windows.Forms.ToolStrip tsAvailableResources;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnImport;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvAvailableResources;
        private System.Windows.Forms.Label lblAvailableResources;
        private System.Windows.Forms.ToolStripButton btnEdit;
    }
}