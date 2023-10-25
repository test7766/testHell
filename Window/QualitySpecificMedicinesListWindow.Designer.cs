namespace WMSOffice.Window
{
    partial class QualitySpecificMedicinesListWindow
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
            this.components = new System.ComponentModel.Container();
            this.tsDocGroups = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.xdgvDocGroups = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tsDocs = new System.Windows.Forms.ToolStrip();
            this.btnCreateDoc = new System.Windows.Forms.ToolStripButton();
            this.btnEditDoc = new System.Windows.Forms.ToolStripButton();
            this.btnCopyDoc = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteDoc = new System.Windows.Forms.ToolStripButton();
            this.dgvDocs = new System.Windows.Forms.DataGridView();
            this.OrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDateUpdated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nLListDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quality = new WMSOffice.Data.Quality();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.nL_ListDetailsTableAdapter = new WMSOffice.Data.QualityTableAdapters.NL_ListDetailsTableAdapter();
            this.tsDocGroups.SuspendLayout();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tsDocs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nLListDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsDocGroups
            // 
            this.tsDocGroups.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsDocGroups.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh});
            this.tsDocGroups.Location = new System.Drawing.Point(0, 0);
            this.tsDocGroups.Name = "tsDocGroups";
            this.tsDocGroups.Size = new System.Drawing.Size(1284, 55);
            this.tsDocGroups.TabIndex = 1;
            this.tsDocGroups.Text = "toolStrip1";
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
            // xdgvDocGroups
            // 
            this.xdgvDocGroups.AllowSort = true;
            this.xdgvDocGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xdgvDocGroups.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvDocGroups.LargeAmountOfData = false;
            this.xdgvDocGroups.Location = new System.Drawing.Point(3, 58);
            this.xdgvDocGroups.Name = "xdgvDocGroups";
            this.xdgvDocGroups.RowHeadersVisible = false;
            this.xdgvDocGroups.Size = new System.Drawing.Size(1278, 130);
            this.xdgvDocGroups.TabIndex = 0;
            this.xdgvDocGroups.UserID = ((long)(0));
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.Location = new System.Drawing.Point(0, 40);
            this.scMain.Name = "scMain";
            this.scMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.panel4);
            this.scMain.Panel1.Controls.Add(this.panel3);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.panel2);
            this.scMain.Panel2.Controls.Add(this.panel1);
            this.scMain.Size = new System.Drawing.Size(1284, 566);
            this.scMain.SplitterDistance = 215;
            this.scMain.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tsDocGroups);
            this.panel4.Controls.Add(this.xdgvDocGroups);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 24);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1284, 191);
            this.panel4.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1284, 24);
            this.panel3.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.label1.Size = new System.Drawing.Size(76, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Перечни";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tsDocs);
            this.panel2.Controls.Add(this.dgvDocs);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1284, 323);
            this.panel2.TabIndex = 5;
            // 
            // tsDocs
            // 
            this.tsDocs.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsDocs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCreateDoc,
            this.btnEditDoc,
            this.btnCopyDoc,
            this.btnDeleteDoc});
            this.tsDocs.Location = new System.Drawing.Point(0, 0);
            this.tsDocs.Name = "tsDocs";
            this.tsDocs.Size = new System.Drawing.Size(1284, 55);
            this.tsDocs.TabIndex = 2;
            this.tsDocs.Text = "toolStrip1";
            // 
            // btnCreateDoc
            // 
            this.btnCreateDoc.Image = global::WMSOffice.Properties.Resources.add_document;
            this.btnCreateDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreateDoc.Name = "btnCreateDoc";
            this.btnCreateDoc.Size = new System.Drawing.Size(102, 52);
            this.btnCreateDoc.Text = "Создать";
            this.btnCreateDoc.Click += new System.EventHandler(this.btnCreateDoc_Click);
            // 
            // btnEditDoc
            // 
            this.btnEditDoc.Image = global::WMSOffice.Properties.Resources.edit_document;
            this.btnEditDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditDoc.Name = "btnEditDoc";
            this.btnEditDoc.Size = new System.Drawing.Size(138, 52);
            this.btnEditDoc.Text = "Редактировать";
            this.btnEditDoc.Click += new System.EventHandler(this.btnEditDoc_Click);
            // 
            // btnCopyDoc
            // 
            this.btnCopyDoc.Image = global::WMSOffice.Properties.Resources.tables_edit;
            this.btnCopyDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopyDoc.Name = "btnCopyDoc";
            this.btnCopyDoc.Size = new System.Drawing.Size(102, 52);
            this.btnCopyDoc.Text = "Создать\nкопию";
            this.btnCopyDoc.Click += new System.EventHandler(this.btnCopyDoc_Click);
            // 
            // btnDeleteDoc
            // 
            this.btnDeleteDoc.Image = global::WMSOffice.Properties.Resources.Delete;
            this.btnDeleteDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteDoc.Name = "btnDeleteDoc";
            this.btnDeleteDoc.Size = new System.Drawing.Size(103, 52);
            this.btnDeleteDoc.Text = "Удалить";
            this.btnDeleteDoc.Click += new System.EventHandler(this.btnDeleteDoc_Click);
            // 
            // dgvDocs
            // 
            this.dgvDocs.AllowUserToAddRows = false;
            this.dgvDocs.AllowUserToDeleteRows = false;
            this.dgvDocs.AllowUserToResizeColumns = false;
            this.dgvDocs.AllowUserToResizeRows = false;
            this.dgvDocs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDocs.AutoGenerateColumns = false;
            this.dgvDocs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrderNumber,
            this.DateFrom,
            this.clDescription,
            this.clUserName,
            this.clDateUpdated});
            this.dgvDocs.DataSource = this.nLListDetailsBindingSource;
            this.dgvDocs.Location = new System.Drawing.Point(0, 58);
            this.dgvDocs.MultiSelect = false;
            this.dgvDocs.Name = "dgvDocs";
            this.dgvDocs.ReadOnly = true;
            this.dgvDocs.RowHeadersVisible = false;
            this.dgvDocs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocs.Size = new System.Drawing.Size(1284, 265);
            this.dgvDocs.TabIndex = 3;
            this.dgvDocs.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocs_CellDoubleClick);
            this.dgvDocs.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDocs_CellFormatting);
            this.dgvDocs.SelectionChanged += new System.EventHandler(this.dgvDocs_SelectionChanged);
            // 
            // OrderNumber
            // 
            this.OrderNumber.DataPropertyName = "OrderNumber";
            this.OrderNumber.HeaderText = "№ приказа";
            this.OrderNumber.Name = "OrderNumber";
            this.OrderNumber.ReadOnly = true;
            this.OrderNumber.Width = 90;
            // 
            // DateFrom
            // 
            this.DateFrom.DataPropertyName = "DateFrom";
            this.DateFrom.HeaderText = "Дата с";
            this.DateFrom.Name = "DateFrom";
            this.DateFrom.ReadOnly = true;
            this.DateFrom.ToolTipText = "Приказ вступает в силу";
            this.DateFrom.Width = 70;
            // 
            // clDescription
            // 
            this.clDescription.DataPropertyName = "Description";
            this.clDescription.HeaderText = "Описание";
            this.clDescription.Name = "clDescription";
            this.clDescription.ReadOnly = true;
            this.clDescription.Width = 1050;
            // 
            // clUserName
            // 
            this.clUserName.DataPropertyName = "UserName";
            this.clUserName.HeaderText = "Изменен кем";
            this.clUserName.Name = "clUserName";
            this.clUserName.ReadOnly = true;
            this.clUserName.Width = 250;
            // 
            // clDateUpdated
            // 
            this.clDateUpdated.DataPropertyName = "DateUpdated";
            this.clDateUpdated.HeaderText = "Изменен когда";
            this.clDateUpdated.Name = "clDateUpdated";
            this.clDateUpdated.ReadOnly = true;
            this.clDateUpdated.Width = 150;
            // 
            // nLListDetailsBindingSource
            // 
            this.nLListDetailsBindingSource.DataMember = "NL_ListDetails";
            this.nLListDetailsBindingSource.DataSource = this.quality;
            // 
            // quality
            // 
            this.quality.DataSetName = "Quality";
            this.quality.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1284, 24);
            this.panel1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.label2.Size = new System.Drawing.Size(76, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Приказы";
            // 
            // nL_ListDetailsTableAdapter
            // 
            this.nL_ListDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // QualitySpecificMedicinesListWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 606);
            this.Controls.Add(this.scMain);
            this.Name = "QualitySpecificMedicinesListWindow";
            this.Text = "QualitySpecificMedicinesListWindow";
            this.Controls.SetChildIndex(this.scMain, 0);
            this.tsDocGroups.ResumeLayout(false);
            this.tsDocGroups.PerformLayout();
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            this.scMain.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tsDocs.ResumeLayout(false);
            this.tsDocs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nLListDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsDocGroups;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvDocGroups;
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.ToolStrip tsDocs;
        private System.Windows.Forms.ToolStripButton btnCreateDoc;
        private System.Windows.Forms.ToolStripButton btnEditDoc;
        private System.Windows.Forms.ToolStripButton btnDeleteDoc;
        private System.Windows.Forms.DataGridView dgvDocs;
        private System.Windows.Forms.BindingSource nLListDetailsBindingSource;
        private WMSOffice.Data.Quality quality;
        private WMSOffice.Data.QualityTableAdapters.NL_ListDetailsTableAdapter nL_ListDetailsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn clUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDateUpdated;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripButton btnCopyDoc;
    }
}