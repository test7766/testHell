namespace WMSOffice.Window
{
    partial class AttorneysWindow
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
            this.btnRegister = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRevert = new System.Windows.Forms.ToolStripButton();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.xdgvDocs = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.pnlSearchParameters = new System.Windows.Forms.Panel();
            this.tbMainDebtorName = new System.Windows.Forms.TextBox();
            this.stbMainDebtor = new WMSOffice.Controls.SearchTextBox();
            this.lblMainDebtor = new System.Windows.Forms.Label();
            this.tbReceiverName = new System.Windows.Forms.TextBox();
            this.tbWarehouseName = new System.Windows.Forms.TextBox();
            this.stbReceiver = new WMSOffice.Controls.SearchTextBox();
            this.cbShowOnlyActualAttorney = new System.Windows.Forms.CheckBox();
            this.lblReceiver = new System.Windows.Forms.Label();
            this.lblWarehouse = new System.Windows.Forms.Label();
            this.stbWarehouse = new WMSOffice.Controls.SearchTextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.tsMain.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlSearchParameters.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.toolStripSeparator1,
            this.btnRegister,
            this.btnEdit,
            this.btnDelete,
            this.toolStripSeparator2,
            this.btnRevert,
            this.toolStripSeparator3,
            this.btnExportToExcel});
            this.tsMain.Location = new System.Drawing.Point(0, 40);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(817, 55);
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
            // btnRegister
            // 
            this.btnRegister.Image = global::WMSOffice.Properties.Resources.document_new;
            this.btnRegister.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(159, 52);
            this.btnRegister.Text = "Зарегистрировать";
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::WMSOffice.Properties.Resources.edit_document;
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(113, 52);
            this.btnEdit.Text = "Изменить";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::WMSOffice.Properties.Resources.Delete;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(103, 52);
            this.btnDelete.Text = "Удалить";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // btnRevert
            // 
            this.btnRevert.Image = global::WMSOffice.Properties.Resources.undo43;
            this.btnRevert.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRevert.Name = "btnRevert";
            this.btnRevert.Size = new System.Drawing.Size(108, 52);
            this.btnRevert.Text = "Отозвать";
            this.btnRevert.Click += new System.EventHandler(this.btnRevert_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.xdgvDocs);
            this.pnlContent.Controls.Add(this.pnlSearchParameters);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 95);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(817, 293);
            this.pnlContent.TabIndex = 2;
            // 
            // xdgvDocs
            // 
            this.xdgvDocs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvDocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvDocs.LargeAmountOfData = false;
            this.xdgvDocs.Location = new System.Drawing.Point(0, 120);
            this.xdgvDocs.Name = "xdgvDocs";
            this.xdgvDocs.RowHeadersVisible = false;
            this.xdgvDocs.Size = new System.Drawing.Size(817, 173);
            this.xdgvDocs.TabIndex = 1;
            this.xdgvDocs.UserID = ((long)(0));
            // 
            // pnlSearchParameters
            // 
            this.pnlSearchParameters.Controls.Add(this.tbMainDebtorName);
            this.pnlSearchParameters.Controls.Add(this.stbMainDebtor);
            this.pnlSearchParameters.Controls.Add(this.lblMainDebtor);
            this.pnlSearchParameters.Controls.Add(this.tbReceiverName);
            this.pnlSearchParameters.Controls.Add(this.tbWarehouseName);
            this.pnlSearchParameters.Controls.Add(this.stbReceiver);
            this.pnlSearchParameters.Controls.Add(this.cbShowOnlyActualAttorney);
            this.pnlSearchParameters.Controls.Add(this.lblReceiver);
            this.pnlSearchParameters.Controls.Add(this.lblWarehouse);
            this.pnlSearchParameters.Controls.Add(this.stbWarehouse);
            this.pnlSearchParameters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearchParameters.Location = new System.Drawing.Point(0, 0);
            this.pnlSearchParameters.Name = "pnlSearchParameters";
            this.pnlSearchParameters.Size = new System.Drawing.Size(817, 120);
            this.pnlSearchParameters.TabIndex = 0;
            // 
            // tbMainDebtorName
            // 
            this.tbMainDebtorName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMainDebtorName.BackColor = System.Drawing.SystemColors.Window;
            this.tbMainDebtorName.Location = new System.Drawing.Point(219, 65);
            this.tbMainDebtorName.Name = "tbMainDebtorName";
            this.tbMainDebtorName.ReadOnly = true;
            this.tbMainDebtorName.Size = new System.Drawing.Size(586, 20);
            this.tbMainDebtorName.TabIndex = 8;
            this.tbMainDebtorName.TabStop = false;
            // 
            // stbMainDebtor
            // 
            this.stbMainDebtor.Location = new System.Drawing.Point(88, 65);
            this.stbMainDebtor.Name = "stbMainDebtor";
            this.stbMainDebtor.ReadOnly = false;
            this.stbMainDebtor.Size = new System.Drawing.Size(125, 20);
            this.stbMainDebtor.TabIndex = 7;
            this.stbMainDebtor.UserID = ((long)(0));
            this.stbMainDebtor.Value = null;
            this.stbMainDebtor.ValueReferenceQuery = null;
            // 
            // lblMainDebtor
            // 
            this.lblMainDebtor.AutoSize = true;
            this.lblMainDebtor.Location = new System.Drawing.Point(13, 69);
            this.lblMainDebtor.Name = "lblMainDebtor";
            this.lblMainDebtor.Size = new System.Drawing.Size(69, 13);
            this.lblMainDebtor.TabIndex = 6;
            this.lblMainDebtor.Text = "Гл. дебитор:";
            // 
            // tbReceiverName
            // 
            this.tbReceiverName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbReceiverName.BackColor = System.Drawing.SystemColors.Window;
            this.tbReceiverName.Location = new System.Drawing.Point(219, 36);
            this.tbReceiverName.Name = "tbReceiverName";
            this.tbReceiverName.ReadOnly = true;
            this.tbReceiverName.Size = new System.Drawing.Size(586, 20);
            this.tbReceiverName.TabIndex = 5;
            this.tbReceiverName.TabStop = false;
            // 
            // tbWarehouseName
            // 
            this.tbWarehouseName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbWarehouseName.BackColor = System.Drawing.SystemColors.Window;
            this.tbWarehouseName.Location = new System.Drawing.Point(219, 7);
            this.tbWarehouseName.Name = "tbWarehouseName";
            this.tbWarehouseName.ReadOnly = true;
            this.tbWarehouseName.Size = new System.Drawing.Size(586, 20);
            this.tbWarehouseName.TabIndex = 2;
            this.tbWarehouseName.TabStop = false;
            // 
            // stbReceiver
            // 
            this.stbReceiver.Location = new System.Drawing.Point(88, 36);
            this.stbReceiver.Name = "stbReceiver";
            this.stbReceiver.ReadOnly = false;
            this.stbReceiver.Size = new System.Drawing.Size(125, 20);
            this.stbReceiver.TabIndex = 4;
            this.stbReceiver.UserID = ((long)(0));
            this.stbReceiver.Value = null;
            this.stbReceiver.ValueReferenceQuery = null;
            // 
            // cbShowOnlyActualAttorney
            // 
            this.cbShowOnlyActualAttorney.AutoSize = true;
            this.cbShowOnlyActualAttorney.Checked = true;
            this.cbShowOnlyActualAttorney.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbShowOnlyActualAttorney.Location = new System.Drawing.Point(13, 98);
            this.cbShowOnlyActualAttorney.Name = "cbShowOnlyActualAttorney";
            this.cbShowOnlyActualAttorney.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbShowOnlyActualAttorney.Size = new System.Drawing.Size(200, 17);
            this.cbShowOnlyActualAttorney.TabIndex = 9;
            this.cbShowOnlyActualAttorney.Text = "Только актуальные доверенности";
            this.cbShowOnlyActualAttorney.UseVisualStyleBackColor = true;
            // 
            // lblReceiver
            // 
            this.lblReceiver.AutoSize = true;
            this.lblReceiver.Location = new System.Drawing.Point(13, 40);
            this.lblReceiver.Name = "lblReceiver";
            this.lblReceiver.Size = new System.Drawing.Size(69, 13);
            this.lblReceiver.TabIndex = 3;
            this.lblReceiver.Text = "Получатель:";
            // 
            // lblWarehouse
            // 
            this.lblWarehouse.AutoSize = true;
            this.lblWarehouse.Location = new System.Drawing.Point(13, 11);
            this.lblWarehouse.Name = "lblWarehouse";
            this.lblWarehouse.Size = new System.Drawing.Size(41, 13);
            this.lblWarehouse.TabIndex = 0;
            this.lblWarehouse.Text = "Склад:";
            // 
            // stbWarehouse
            // 
            this.stbWarehouse.Location = new System.Drawing.Point(88, 7);
            this.stbWarehouse.Name = "stbWarehouse";
            this.stbWarehouse.ReadOnly = false;
            this.stbWarehouse.Size = new System.Drawing.Size(125, 20);
            this.stbWarehouse.TabIndex = 1;
            this.stbWarehouse.UserID = ((long)(0));
            this.stbWarehouse.Value = null;
            this.stbWarehouse.ValueReferenceQuery = null;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 55);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Image = global::WMSOffice.Properties.Resources.Excel;
            this.btnExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(142, 52);
            this.btnExportToExcel.Text = "Экспорт в Excel";
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // AttorneysWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 388);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.tsMain);
            this.Name = "AttorneysWindow";
            this.Text = "AttorneysWindow";
            this.Controls.SetChildIndex(this.tsMain, 0);
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlSearchParameters.ResumeLayout(false);
            this.pnlSearchParameters.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnRegister;
        private System.Windows.Forms.Panel pnlContent;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvDocs;
        private System.Windows.Forms.Panel pnlSearchParameters;
        private System.Windows.Forms.Label lblWarehouse;
        private WMSOffice.Controls.SearchTextBox stbWarehouse;
        private System.Windows.Forms.Label lblReceiver;
        private System.Windows.Forms.CheckBox cbShowOnlyActualAttorney;
        private System.Windows.Forms.TextBox tbWarehouseName;
        private WMSOffice.Controls.SearchTextBox stbReceiver;
        private System.Windows.Forms.TextBox tbReceiverName;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.TextBox tbMainDebtorName;
        private WMSOffice.Controls.SearchTextBox stbMainDebtor;
        private System.Windows.Forms.Label lblMainDebtor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnRevert;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnExportToExcel;
    }
}