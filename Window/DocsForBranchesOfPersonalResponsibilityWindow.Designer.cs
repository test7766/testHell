namespace WMSOffice.Window
{
    partial class DocsForBranchesOfPersonalResponsibilityWindow
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
            this.btnRefreshDocs = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCreateDoc = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAssignDoc = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAcceptDoc = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDeclineDoc = new System.Windows.Forms.ToolStripButton();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.xdgvDocs = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.tbEmployee = new System.Windows.Forms.TextBox();
            this.tbStatusTo = new System.Windows.Forms.TextBox();
            this.tbStatusFrom = new System.Windows.Forms.TextBox();
            this.stbEmployee = new WMSOffice.Controls.SearchTextBox();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.stbStatusTo = new WMSOffice.Controls.SearchTextBox();
            this.lblStatusTo = new System.Windows.Forms.Label();
            this.lblStatusFrom = new System.Windows.Forms.Label();
            this.stbStatusFrom = new WMSOffice.Controls.SearchTextBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExportDoc = new System.Windows.Forms.ToolStripButton();
            this.tsMain.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefreshDocs,
            this.toolStripSeparator1,
            this.btnCreateDoc,
            this.toolStripSeparator2,
            this.btnAssignDoc,
            this.toolStripSeparator4,
            this.btnAcceptDoc,
            this.toolStripSeparator3,
            this.btnDeclineDoc,
            this.toolStripSeparator5,
            this.btnExportDoc});
            this.tsMain.Location = new System.Drawing.Point(0, 40);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1030, 55);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
            // 
            // btnRefreshDocs
            // 
            this.btnRefreshDocs.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefreshDocs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefreshDocs.Name = "btnRefreshDocs";
            this.btnRefreshDocs.Size = new System.Drawing.Size(113, 52);
            this.btnRefreshDocs.Text = "Обновить";
            this.btnRefreshDocs.Click += new System.EventHandler(this.btnRefreshDocs_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // btnCreateDoc
            // 
            this.btnCreateDoc.Image = global::WMSOffice.Properties.Resources.add_document;
            this.btnCreateDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreateDoc.Name = "btnCreateDoc";
            this.btnCreateDoc.Size = new System.Drawing.Size(102, 52);
            this.btnCreateDoc.Text = "Создать\nмакет";
            this.btnCreateDoc.Click += new System.EventHandler(this.btnCreateDoc_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // btnAssignDoc
            // 
            this.btnAssignDoc.Image = global::WMSOffice.Properties.Resources.engineer;
            this.btnAssignDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAssignDoc.Name = "btnAssignDoc";
            this.btnAssignDoc.Size = new System.Drawing.Size(106, 52);
            this.btnAssignDoc.Text = "Взять\nв работу";
            this.btnAssignDoc.Click += new System.EventHandler(this.btnAssignDoc_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 55);
            // 
            // btnAcceptDoc
            // 
            this.btnAcceptDoc.Image = global::WMSOffice.Properties.Resources.finish_process;
            this.btnAcceptDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAcceptDoc.Name = "btnAcceptDoc";
            this.btnAcceptDoc.Size = new System.Drawing.Size(114, 52);
            this.btnAcceptDoc.Text = "Утвердить\nмакет";
            this.btnAcceptDoc.Click += new System.EventHandler(this.btnAcceptDoc_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 55);
            // 
            // btnDeclineDoc
            // 
            this.btnDeclineDoc.Image = global::WMSOffice.Properties.Resources.symbol_stop;
            this.btnDeclineDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeclineDoc.Name = "btnDeclineDoc";
            this.btnDeclineDoc.Size = new System.Drawing.Size(118, 52);
            this.btnDeclineDoc.Text = "Отклонить\nмакет";
            this.btnDeclineDoc.Click += new System.EventHandler(this.btnDeclineDoc_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlContent);
            this.pnlMain.Controls.Add(this.pnlFilter);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 95);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1030, 293);
            this.pnlMain.TabIndex = 2;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.xdgvDocs);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 67);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1030, 226);
            this.pnlContent.TabIndex = 1;
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
            this.xdgvDocs.Size = new System.Drawing.Size(1030, 226);
            this.xdgvDocs.TabIndex = 0;
            this.xdgvDocs.UserID = ((long)(0));
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.tbEmployee);
            this.pnlFilter.Controls.Add(this.tbStatusTo);
            this.pnlFilter.Controls.Add(this.tbStatusFrom);
            this.pnlFilter.Controls.Add(this.stbEmployee);
            this.pnlFilter.Controls.Add(this.lblEmployee);
            this.pnlFilter.Controls.Add(this.stbStatusTo);
            this.pnlFilter.Controls.Add(this.lblStatusTo);
            this.pnlFilter.Controls.Add(this.lblStatusFrom);
            this.pnlFilter.Controls.Add(this.stbStatusFrom);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1030, 67);
            this.pnlFilter.TabIndex = 0;
            // 
            // tbEmployee
            // 
            this.tbEmployee.BackColor = System.Drawing.SystemColors.Window;
            this.tbEmployee.Location = new System.Drawing.Point(192, 9);
            this.tbEmployee.Name = "tbEmployee";
            this.tbEmployee.ReadOnly = true;
            this.tbEmployee.Size = new System.Drawing.Size(816, 20);
            this.tbEmployee.TabIndex = 2;
            // 
            // tbStatusTo
            // 
            this.tbStatusTo.BackColor = System.Drawing.SystemColors.Window;
            this.tbStatusTo.Location = new System.Drawing.Point(708, 38);
            this.tbStatusTo.Name = "tbStatusTo";
            this.tbStatusTo.ReadOnly = true;
            this.tbStatusTo.Size = new System.Drawing.Size(300, 20);
            this.tbStatusTo.TabIndex = 8;
            // 
            // tbStatusFrom
            // 
            this.tbStatusFrom.BackColor = System.Drawing.SystemColors.Window;
            this.tbStatusFrom.Location = new System.Drawing.Point(192, 38);
            this.tbStatusFrom.Name = "tbStatusFrom";
            this.tbStatusFrom.ReadOnly = true;
            this.tbStatusFrom.Size = new System.Drawing.Size(300, 20);
            this.tbStatusFrom.TabIndex = 5;
            // 
            // stbEmployee
            // 
            this.stbEmployee.Location = new System.Drawing.Point(84, 9);
            this.stbEmployee.Name = "stbEmployee";
            this.stbEmployee.NavigateByValue = false;
            this.stbEmployee.ReadOnly = false;
            this.stbEmployee.Size = new System.Drawing.Size(100, 20);
            this.stbEmployee.TabIndex = 1;
            this.stbEmployee.UserID = ((long)(0));
            this.stbEmployee.Value = null;
            this.stbEmployee.ValueReferenceQuery = null;
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Location = new System.Drawing.Point(13, 13);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(63, 13);
            this.lblEmployee.TabIndex = 0;
            this.lblEmployee.Text = "Сотрудник:";
            // 
            // stbStatusTo
            // 
            this.stbStatusTo.Location = new System.Drawing.Point(602, 38);
            this.stbStatusTo.Name = "stbStatusTo";
            this.stbStatusTo.NavigateByValue = false;
            this.stbStatusTo.ReadOnly = false;
            this.stbStatusTo.Size = new System.Drawing.Size(100, 20);
            this.stbStatusTo.TabIndex = 7;
            this.stbStatusTo.UserID = ((long)(0));
            this.stbStatusTo.Value = null;
            this.stbStatusTo.ValueReferenceQuery = null;
            // 
            // lblStatusTo
            // 
            this.lblStatusTo.AutoSize = true;
            this.lblStatusTo.Location = new System.Drawing.Point(528, 42);
            this.lblStatusTo.Name = "lblStatusTo";
            this.lblStatusTo.Size = new System.Drawing.Size(59, 13);
            this.lblStatusTo.TabIndex = 6;
            this.lblStatusTo.Text = "Статус по:";
            // 
            // lblStatusFrom
            // 
            this.lblStatusFrom.AutoSize = true;
            this.lblStatusFrom.Location = new System.Drawing.Point(13, 42);
            this.lblStatusFrom.Name = "lblStatusFrom";
            this.lblStatusFrom.Size = new System.Drawing.Size(53, 13);
            this.lblStatusFrom.TabIndex = 3;
            this.lblStatusFrom.Text = "Статус с:";
            // 
            // stbStatusFrom
            // 
            this.stbStatusFrom.Location = new System.Drawing.Point(84, 38);
            this.stbStatusFrom.Name = "stbStatusFrom";
            this.stbStatusFrom.NavigateByValue = false;
            this.stbStatusFrom.ReadOnly = false;
            this.stbStatusFrom.Size = new System.Drawing.Size(100, 20);
            this.stbStatusFrom.TabIndex = 4;
            this.stbStatusFrom.UserID = ((long)(0));
            this.stbStatusFrom.Value = null;
            this.stbStatusFrom.ValueReferenceQuery = null;
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 55);
            // 
            // btnExportDoc
            // 
            this.btnExportDoc.Image = global::WMSOffice.Properties.Resources.Excel;
            this.btnExportDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportDoc.Name = "btnExportDoc";
            this.btnExportDoc.Size = new System.Drawing.Size(143, 52);
            this.btnExportDoc.Text = "Экспорт\nв Excel";
            this.btnExportDoc.Click += new System.EventHandler(this.btnExportDoc_Click);
            // 
            // DocsForBranchesOfPersonalResponsibilityWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 388);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.tsMain);
            this.Name = "DocsForBranchesOfPersonalResponsibilityWindow";
            this.Text = "DocsForBranchesOfPersonalResponsibilityWindow";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DocsForBranchesOfPersonalResponsibilityWindow_FormClosed);
            this.Controls.SetChildIndex(this.tsMain, 0);
            this.Controls.SetChildIndex(this.pnlMain, 0);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btnRefreshDocs;
        private System.Windows.Forms.ToolStripButton btnCreateDoc;
        private System.Windows.Forms.ToolStripButton btnAcceptDoc;
        private System.Windows.Forms.ToolStripButton btnDeclineDoc;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlContent;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvDocs;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.TextBox tbEmployee;
        private System.Windows.Forms.TextBox tbStatusTo;
        private System.Windows.Forms.TextBox tbStatusFrom;
        private WMSOffice.Controls.SearchTextBox stbEmployee;
        private System.Windows.Forms.Label lblEmployee;
        private WMSOffice.Controls.SearchTextBox stbStatusTo;
        private System.Windows.Forms.Label lblStatusTo;
        private System.Windows.Forms.Label lblStatusFrom;
        private WMSOffice.Controls.SearchTextBox stbStatusFrom;
        private System.Windows.Forms.ToolStripButton btnAssignDoc;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnExportDoc;
    }
}