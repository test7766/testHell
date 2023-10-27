namespace WMSOffice.Dialogs.Inventory
{
    partial class InventoryResourcePlanningForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.xdgvAssignedResources = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.tsAssignedResourcesToolBar = new System.Windows.Forms.ToolStrip();
            this.sbExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.sbCancelEmployee = new System.Windows.Forms.Button();
            this.sbAssignEmployee = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.xdgvFreeResources = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.tsFreeResourcesToolBar = new System.Windows.Forms.ToolStrip();
            this.sbDeleteResource = new System.Windows.Forms.ToolStripButton();
            this.sbEditResource = new System.Windows.Forms.ToolStripButton();
            this.tsEditSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.sbImportResources = new System.Windows.Forms.ToolStripButton();
            this.tsImportSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.tsMainMenu = new System.Windows.Forms.ToolStrip();
            this.sbAddTeam = new System.Windows.Forms.ToolStripButton();
            this.sbDeleteTeam = new System.Windows.Forms.ToolStripButton();
            this.sbGenerateTeams = new System.Windows.Forms.ToolStripButton();
            this.sbLinkZoneToTeam = new System.Windows.Forms.ToolStripButton();
            this.pnlButtons.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tsAssignedResourcesToolBar.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tsFreeResourcesToolBar.SuspendLayout();
            this.tsMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(22932, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(23022, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 685);
            this.pnlButtons.Size = new System.Drawing.Size(1514, 43);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 58);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1514, 621);
            this.splitContainer1.SplitterDistance = 869;
            this.splitContainer1.TabIndex = 101;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.label1.Size = new System.Drawing.Size(185, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Необходимые ресурсы";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.xdgvAssignedResources);
            this.panel1.Controls.Add(this.tsAssignedResourcesToolBar);
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(869, 590);
            this.panel1.TabIndex = 0;
            // 
            // xdgvAssignedResources
            // 
            this.xdgvAssignedResources.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xdgvAssignedResources.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.xdgvAssignedResources.LargeAmountOfData = false;
            this.xdgvAssignedResources.Location = new System.Drawing.Point(0, 28);
            this.xdgvAssignedResources.Name = "xdgvAssignedResources";
            this.xdgvAssignedResources.RowHeadersVisible = false;
            this.xdgvAssignedResources.Size = new System.Drawing.Size(869, 559);
            this.xdgvAssignedResources.TabIndex = 1;
            this.xdgvAssignedResources.UserID = ((long)(0));
            // 
            // tsAssignedResourcesToolBar
            // 
            this.tsAssignedResourcesToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbExportToExcel,
            this.toolStripSeparator1,
            this.toolStripSeparator2});
            this.tsAssignedResourcesToolBar.Location = new System.Drawing.Point(0, 0);
            this.tsAssignedResourcesToolBar.Name = "tsAssignedResourcesToolBar";
            this.tsAssignedResourcesToolBar.Size = new System.Drawing.Size(869, 25);
            this.tsAssignedResourcesToolBar.TabIndex = 0;
            this.tsAssignedResourcesToolBar.Text = "toolStrip1";
            // 
            // sbExportToExcel
            // 
            this.sbExportToExcel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.sbExportToExcel.Image = global::WMSOffice.Properties.Resources.Excel;
            this.sbExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbExportToExcel.Name = "sbExportToExcel";
            this.sbExportToExcel.Size = new System.Drawing.Size(110, 22);
            this.sbExportToExcel.Text = "Экспорт в Excel";
            this.sbExportToExcel.Click += new System.EventHandler(this.sbExportToExcel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.Panel1.Controls.Add(this.sbCancelEmployee);
            this.splitContainer2.Panel1.Controls.Add(this.sbAssignEmployee);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.Panel2.Controls.Add(this.label2);
            this.splitContainer2.Panel2.Controls.Add(this.panel2);
            this.splitContainer2.Panel2MinSize = 100;
            this.splitContainer2.Size = new System.Drawing.Size(641, 621);
            this.splitContainer2.SplitterDistance = 83;
            this.splitContainer2.TabIndex = 0;
            // 
            // sbCancelEmployee
            // 
            this.sbCancelEmployee.Image = global::WMSOffice.Properties.Resources.arrow_right;
            this.sbCancelEmployee.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.sbCancelEmployee.Location = new System.Drawing.Point(3, 357);
            this.sbCancelEmployee.Name = "sbCancelEmployee";
            this.sbCancelEmployee.Size = new System.Drawing.Size(76, 40);
            this.sbCancelEmployee.TabIndex = 2;
            this.sbCancelEmployee.Text = "Снять";
            this.sbCancelEmployee.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.sbCancelEmployee.UseVisualStyleBackColor = true;
            this.sbCancelEmployee.Click += new System.EventHandler(this.sbCancelEmployee_Click);
            // 
            // sbAssignEmployee
            // 
            this.sbAssignEmployee.Image = global::WMSOffice.Properties.Resources.arrow_left;
            this.sbAssignEmployee.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.sbAssignEmployee.Location = new System.Drawing.Point(3, 288);
            this.sbAssignEmployee.Name = "sbAssignEmployee";
            this.sbAssignEmployee.Size = new System.Drawing.Size(76, 40);
            this.sbAssignEmployee.TabIndex = 1;
            this.sbAssignEmployee.Text = "Назначить";
            this.sbAssignEmployee.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.sbAssignEmployee.UseVisualStyleBackColor = true;
            this.sbAssignEmployee.Click += new System.EventHandler(this.sbAssignEmployee_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.label2.Size = new System.Drawing.Size(162, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Доступные ресурсы";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.xdgvFreeResources);
            this.panel2.Controls.Add(this.tsFreeResourcesToolBar);
            this.panel2.Location = new System.Drawing.Point(0, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(554, 587);
            this.panel2.TabIndex = 0;
            // 
            // xdgvFreeResources
            // 
            this.xdgvFreeResources.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xdgvFreeResources.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.xdgvFreeResources.LargeAmountOfData = false;
            this.xdgvFreeResources.Location = new System.Drawing.Point(3, 28);
            this.xdgvFreeResources.Name = "xdgvFreeResources";
            this.xdgvFreeResources.RowHeadersVisible = false;
            this.xdgvFreeResources.Size = new System.Drawing.Size(548, 556);
            this.xdgvFreeResources.TabIndex = 1;
            this.xdgvFreeResources.UserID = ((long)(0));
            // 
            // tsFreeResourcesToolBar
            // 
            this.tsFreeResourcesToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbDeleteResource,
            this.sbEditResource,
            this.tsEditSeparator,
            this.sbImportResources,
            this.tsImportSeparator});
            this.tsFreeResourcesToolBar.Location = new System.Drawing.Point(0, 0);
            this.tsFreeResourcesToolBar.Name = "tsFreeResourcesToolBar";
            this.tsFreeResourcesToolBar.Size = new System.Drawing.Size(554, 25);
            this.tsFreeResourcesToolBar.TabIndex = 0;
            this.tsFreeResourcesToolBar.Text = "toolStrip2";
            // 
            // sbDeleteResource
            // 
            this.sbDeleteResource.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.sbDeleteResource.Image = global::WMSOffice.Properties.Resources.Delete;
            this.sbDeleteResource.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbDeleteResource.Name = "sbDeleteResource";
            this.sbDeleteResource.Size = new System.Drawing.Size(71, 22);
            this.sbDeleteResource.Text = "Удалить";
            this.sbDeleteResource.ToolTipText = "Удалить ресурс";
            this.sbDeleteResource.Click += new System.EventHandler(this.sbDeleteResource_Click);
            // 
            // sbEditResource
            // 
            this.sbEditResource.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.sbEditResource.Image = global::WMSOffice.Properties.Resources.edit_document;
            this.sbEditResource.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbEditResource.Name = "sbEditResource";
            this.sbEditResource.Size = new System.Drawing.Size(81, 22);
            this.sbEditResource.Text = "Изменить";
            this.sbEditResource.ToolTipText = "Изменить ресурс";
            this.sbEditResource.Click += new System.EventHandler(this.sbEditResource_Click);
            // 
            // tsEditSeparator
            // 
            this.tsEditSeparator.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsEditSeparator.Name = "tsEditSeparator";
            this.tsEditSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // sbImportResources
            // 
            this.sbImportResources.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.sbImportResources.Image = global::WMSOffice.Properties.Resources.Excel;
            this.sbImportResources.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbImportResources.Name = "sbImportResources";
            this.sbImportResources.Size = new System.Drawing.Size(125, 22);
            this.sbImportResources.Text = "Импорт ресурсов";
            this.sbImportResources.Click += new System.EventHandler(this.sbImportResources_Click);
            // 
            // tsImportSeparator
            // 
            this.tsImportSeparator.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsImportSeparator.Name = "tsImportSeparator";
            this.tsImportSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // tsMainMenu
            // 
            this.tsMainMenu.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbAddTeam,
            this.sbDeleteTeam,
            this.sbGenerateTeams,
            this.sbLinkZoneToTeam});
            this.tsMainMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMainMenu.Name = "tsMainMenu";
            this.tsMainMenu.Size = new System.Drawing.Size(1514, 55);
            this.tsMainMenu.TabIndex = 102;
            this.tsMainMenu.Text = "toolStrip1";
            // 
            // sbAddTeam
            // 
            this.sbAddTeam.Image = global::WMSOffice.Properties.Resources.Add_48;
            this.sbAddTeam.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbAddTeam.Name = "sbAddTeam";
            this.sbAddTeam.Size = new System.Drawing.Size(111, 52);
            this.sbAddTeam.Text = "Добавить\nбригаду";
            this.sbAddTeam.Click += new System.EventHandler(this.sbAddTeam_Click);
            // 
            // sbDeleteTeam
            // 
            this.sbDeleteTeam.Image = global::WMSOffice.Properties.Resources.Delete;
            this.sbDeleteTeam.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbDeleteTeam.Name = "sbDeleteTeam";
            this.sbDeleteTeam.Size = new System.Drawing.Size(103, 52);
            this.sbDeleteTeam.Text = "Удалить\nбригаду";
            this.sbDeleteTeam.Click += new System.EventHandler(this.sbDeleteTeam_Click);
            // 
            // sbGenerateTeams
            // 
            this.sbGenerateTeams.Image = global::WMSOffice.Properties.Resources.add_document;
            this.sbGenerateTeams.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbGenerateTeams.Name = "sbGenerateTeams";
            this.sbGenerateTeams.Size = new System.Drawing.Size(143, 52);
            this.sbGenerateTeams.Text = "Сформировать\nбригады";
            this.sbGenerateTeams.Click += new System.EventHandler(this.sbGenerateTeams_Click);
            // 
            // sbLinkZoneToTeam
            // 
            this.sbLinkZoneToTeam.Image = global::WMSOffice.Properties.Resources.link;
            this.sbLinkZoneToTeam.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbLinkZoneToTeam.Name = "sbLinkZoneToTeam";
            this.sbLinkZoneToTeam.Size = new System.Drawing.Size(144, 52);
            this.sbLinkZoneToTeam.Text = "Привязать зону\nк бригаде";
            this.sbLinkZoneToTeam.Click += new System.EventHandler(this.sbLinkZoneToTeam_Click);
            // 
            // InventoryResourcePlanningForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1514, 728);
            this.Controls.Add(this.tsMainMenu);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MinimumSize = new System.Drawing.Size(1100, 700);
            this.Name = "InventoryResourcePlanningForm";
            this.Text = "Планирование ресурсов";
            this.Load += new System.EventHandler(this.InventoryResourcePlanningForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InventoryResourcePlanningForm_FormClosing);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.Controls.SetChildIndex(this.tsMainMenu, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tsAssignedResourcesToolBar.ResumeLayout(false);
            this.tsAssignedResourcesToolBar.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tsFreeResourcesToolBar.ResumeLayout(false);
            this.tsFreeResourcesToolBar.PerformLayout();
            this.tsMainMenu.ResumeLayout(false);
            this.tsMainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button sbCancelEmployee;
        private System.Windows.Forms.Button sbAssignEmployee;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvAssignedResources;
        private System.Windows.Forms.ToolStrip tsAssignedResourcesToolBar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton sbExportToExcel;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvFreeResources;
        private System.Windows.Forms.ToolStrip tsFreeResourcesToolBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStrip tsMainMenu;
        private System.Windows.Forms.ToolStripButton sbAddTeam;
        private System.Windows.Forms.ToolStripButton sbDeleteTeam;
        private System.Windows.Forms.ToolStripButton sbGenerateTeams;
        private System.Windows.Forms.ToolStripButton sbLinkZoneToTeam;
        private System.Windows.Forms.ToolStripButton sbImportResources;
        private System.Windows.Forms.ToolStripSeparator tsImportSeparator;
        private System.Windows.Forms.ToolStripButton sbDeleteResource;
        private System.Windows.Forms.ToolStripButton sbEditResource;
        private System.Windows.Forms.ToolStripSeparator tsEditSeparator;

    }
}