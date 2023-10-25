namespace WMSOffice.Window
{
    partial class InventoryScheduleWindow
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
            this.btnCreate = new System.Windows.Forms.ToolStripButton();
            this.btnModify = new System.Windows.Forms.ToolStripButton();
            this.btnRemove = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPlanStations = new System.Windows.Forms.ToolStripButton();
            this.btnPlanResources = new System.Windows.Forms.ToolStripButton();
            this.btnCreateVirtual = new System.Windows.Forms.ToolStripButton();
            this.xdgvInventories = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.toolStripSeparator1,
            this.btnCreate,
            this.btnModify,
            this.btnRemove,
            this.toolStripSeparator2,
            this.btnPlanStations,
            this.btnPlanResources,
            this.toolStripSeparator3,
            this.btnCreateVirtual});
            this.tsMain.Location = new System.Drawing.Point(0, 40);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(943, 55);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(109, 52);
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // btnCreate
            // 
            this.btnCreate.Image = global::WMSOffice.Properties.Resources.add_document;
            this.btnCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(102, 52);
            this.btnCreate.Text = "Создать";
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnModify
            // 
            this.btnModify.Image = global::WMSOffice.Properties.Resources.edit_document;
            this.btnModify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(138, 52);
            this.btnModify.Text = "Редактировать";
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Image = global::WMSOffice.Properties.Resources.Delete;
            this.btnRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(103, 52);
            this.btnRemove.Text = "Удалить";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // btnPlanStations
            // 
            this.btnPlanStations.Image = global::WMSOffice.Properties.Resources.history_review;
            this.btnPlanStations.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPlanStations.Name = "btnPlanStations";
            this.btnPlanStations.Size = new System.Drawing.Size(132, 52);
            this.btnPlanStations.Text = "Планирование\nстанций";
            this.btnPlanStations.Click += new System.EventHandler(this.btnPlanStations_Click);
            // 
            // btnPlanResources
            // 
            this.btnPlanResources.Image = global::WMSOffice.Properties.Resources.user;
            this.btnPlanResources.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPlanResources.Name = "btnPlanResources";
            this.btnPlanResources.Size = new System.Drawing.Size(132, 52);
            this.btnPlanResources.Text = "Планирование\nресурсов";
            this.btnPlanResources.Click += new System.EventHandler(this.btnPlanResources_Click);
            // 
            // btnCreateVirtual
            // 
            this.btnCreateVirtual.Image = global::WMSOffice.Properties.Resources.platzkart;
            this.btnCreateVirtual.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreateVirtual.Name = "btnCreateVirtual";
            this.btnCreateVirtual.Size = new System.Drawing.Size(105, 52);
            this.btnCreateVirtual.Text = "Модуль I";
            this.btnCreateVirtual.Click += new System.EventHandler(this.btnCreateVirtual_Click);
            // 
            // xdgvInventories
            // 
            this.xdgvInventories.AllowSort = true;
            this.xdgvInventories.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvInventories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvInventories.LargeAmountOfData = false;
            this.xdgvInventories.Location = new System.Drawing.Point(0, 95);
            this.xdgvInventories.Name = "xdgvInventories";
            this.xdgvInventories.RowHeadersVisible = false;
            this.xdgvInventories.Size = new System.Drawing.Size(943, 443);
            this.xdgvInventories.TabIndex = 2;
            this.xdgvInventories.UserID = ((long)(0));
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 55);
            // 
            // InventoryScheduleWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 538);
            this.Controls.Add(this.xdgvInventories);
            this.Controls.Add(this.tsMain);
            this.Name = "InventoryScheduleWindow";
            this.Text = "InventoryScheduleWindow";
            this.Controls.SetChildIndex(this.tsMain, 0);
            this.Controls.SetChildIndex(this.xdgvInventories, 0);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvInventories;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnCreate;
        private System.Windows.Forms.ToolStripButton btnModify;
        private System.Windows.Forms.ToolStripButton btnRemove;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnPlanStations;
        private System.Windows.Forms.ToolStripButton btnPlanResources;
        private System.Windows.Forms.ToolStripButton btnCreateVirtual;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}