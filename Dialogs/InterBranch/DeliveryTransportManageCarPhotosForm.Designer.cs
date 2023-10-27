namespace WMSOffice.Dialogs.InterBranch
{
    partial class DeliveryTransportManageCarPhotosForm
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
            this.pnlContent = new System.Windows.Forms.Panel();
            this.scContent = new System.Windows.Forms.SplitContainer();
            this.pnlImages = new System.Windows.Forms.Panel();
            this.pnlImagesPath = new System.Windows.Forms.Panel();
            this.dgvPhotos = new System.Windows.Forms.DataGridView();
            this.fullNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SizeInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageProxyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tsOperations = new System.Windows.Forms.ToolStrip();
            this.btnLoadPhoto = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDeletePhoto = new System.Windows.Forms.ToolStripButton();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbLockBar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFactPallets = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbCarVolumes = new System.Windows.Forms.ComboBox();
            this.tSPCarVolumesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.interbranch = new WMSOffice.Data.Interbranch();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbRouteInformation = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbRouteNumber = new System.Windows.Forms.TextBox();
            this.imageViewerControl = new WMSOffice.Controls.Custom.ImageViewerControl();
            this.tSP_Car_VolumesTableAdapter = new WMSOffice.Data.InterbranchTableAdapters.TSP_Car_VolumesTableAdapter();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.scContent.Panel1.SuspendLayout();
            this.scContent.Panel2.SuspendLayout();
            this.scContent.SuspendLayout();
            this.pnlImages.SuspendLayout();
            this.pnlImagesPath.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhotos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageProxyBindingSource)).BeginInit();
            this.tsOperations.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tSPCarVolumesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.interbranch)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(5069, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(5159, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 528);
            this.pnlButtons.Size = new System.Drawing.Size(894, 43);
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContent.Controls.Add(this.scContent);
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(894, 522);
            this.pnlContent.TabIndex = 101;
            // 
            // scContent
            // 
            this.scContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scContent.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scContent.IsSplitterFixed = true;
            this.scContent.Location = new System.Drawing.Point(0, 0);
            this.scContent.Name = "scContent";
            // 
            // scContent.Panel1
            // 
            this.scContent.Panel1.Controls.Add(this.pnlImages);
            this.scContent.Panel1.Controls.Add(this.pnlHeader);
            // 
            // scContent.Panel2
            // 
            this.scContent.Panel2.Controls.Add(this.imageViewerControl);
            this.scContent.Size = new System.Drawing.Size(894, 522);
            this.scContent.SplitterDistance = 383;
            this.scContent.TabIndex = 0;
            // 
            // pnlImages
            // 
            this.pnlImages.Controls.Add(this.pnlImagesPath);
            this.pnlImages.Controls.Add(this.tsOperations);
            this.pnlImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImages.Location = new System.Drawing.Point(0, 205);
            this.pnlImages.Name = "pnlImages";
            this.pnlImages.Size = new System.Drawing.Size(383, 317);
            this.pnlImages.TabIndex = 1;
            // 
            // pnlImagesPath
            // 
            this.pnlImagesPath.Controls.Add(this.dgvPhotos);
            this.pnlImagesPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImagesPath.Location = new System.Drawing.Point(0, 31);
            this.pnlImagesPath.Name = "pnlImagesPath";
            this.pnlImagesPath.Size = new System.Drawing.Size(383, 286);
            this.pnlImagesPath.TabIndex = 4;
            // 
            // dgvPhotos
            // 
            this.dgvPhotos.AllowUserToAddRows = false;
            this.dgvPhotos.AllowUserToResizeColumns = false;
            this.dgvPhotos.AllowUserToResizeRows = false;
            this.dgvPhotos.AutoGenerateColumns = false;
            this.dgvPhotos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPhotos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvPhotos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhotos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fullNameDataGridViewTextBoxColumn,
            this.SizeInfo});
            this.dgvPhotos.DataSource = this.imageProxyBindingSource;
            this.dgvPhotos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhotos.Location = new System.Drawing.Point(0, 0);
            this.dgvPhotos.MultiSelect = false;
            this.dgvPhotos.Name = "dgvPhotos";
            this.dgvPhotos.ReadOnly = true;
            this.dgvPhotos.RowHeadersWidth = 15;
            this.dgvPhotos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhotos.Size = new System.Drawing.Size(383, 286);
            this.dgvPhotos.TabIndex = 2;
            this.dgvPhotos.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvPhotos_UserDeletingRow);
            this.dgvPhotos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPhotos_CellFormatting);
            this.dgvPhotos.SelectionChanged += new System.EventHandler(this.dgvPhotos_SelectionChanged);
            // 
            // fullNameDataGridViewTextBoxColumn
            // 
            this.fullNameDataGridViewTextBoxColumn.DataPropertyName = "FullName";
            this.fullNameDataGridViewTextBoxColumn.HeaderText = "Путь к файлу";
            this.fullNameDataGridViewTextBoxColumn.Name = "fullNameDataGridViewTextBoxColumn";
            this.fullNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.fullNameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.fullNameDataGridViewTextBoxColumn.Width = 80;
            // 
            // SizeInfo
            // 
            this.SizeInfo.DataPropertyName = "SizeInfo";
            this.SizeInfo.HeaderText = "Размер";
            this.SizeInfo.Name = "SizeInfo";
            this.SizeInfo.ReadOnly = true;
            this.SizeInfo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SizeInfo.Width = 52;
            // 
            // imageProxyBindingSource
            // 
            this.imageProxyBindingSource.DataSource = typeof(WMSOffice.Controls.Custom.ImageProxy);
            // 
            // tsOperations
            // 
            this.tsOperations.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tsOperations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLoadPhoto,
            this.toolStripSeparator1,
            this.btnDeletePhoto});
            this.tsOperations.Location = new System.Drawing.Point(0, 0);
            this.tsOperations.Name = "tsOperations";
            this.tsOperations.Size = new System.Drawing.Size(383, 31);
            this.tsOperations.TabIndex = 3;
            this.tsOperations.Text = "toolStrip1";
            // 
            // btnLoadPhoto
            // 
            this.btnLoadPhoto.Image = global::WMSOffice.Properties.Resources.Open;
            this.btnLoadPhoto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLoadPhoto.Name = "btnLoadPhoto";
            this.btnLoadPhoto.Size = new System.Drawing.Size(120, 28);
            this.btnLoadPhoto.Text = "Загрузить фото";
            this.btnLoadPhoto.Click += new System.EventHandler(this.btnLoadPhoto_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // btnDeletePhoto
            // 
            this.btnDeletePhoto.Image = global::WMSOffice.Properties.Resources.Delete;
            this.btnDeletePhoto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeletePhoto.Name = "btnDeletePhoto";
            this.btnDeletePhoto.Size = new System.Drawing.Size(110, 28);
            this.btnDeletePhoto.Text = "Удалить фото";
            this.btnDeletePhoto.Click += new System.EventHandler(this.btnDeletePhoto_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.groupBox1);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(383, 205);
            this.pnlHeader.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tbComment);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbLockBar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbFactPallets);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cmbCarVolumes);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbRouteInformation);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbRouteNumber);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 175);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Информация об авто";
            // 
            // tbLockBar
            // 
            this.tbLockBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLockBar.BackColor = System.Drawing.SystemColors.Info;
            this.tbLockBar.Location = new System.Drawing.Point(98, 109);
            this.tbLockBar.Name = "tbLockBar";
            this.tbLockBar.Size = new System.Drawing.Size(244, 20);
            this.tbLockBar.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Brown;
            this.label1.Location = new System.Drawing.Point(25, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "№ пломбы :";
            // 
            // tbFactPallets
            // 
            this.tbFactPallets.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFactPallets.BackColor = System.Drawing.SystemColors.Info;
            this.tbFactPallets.Location = new System.Drawing.Point(292, 51);
            this.tbFactPallets.Name = "tbFactPallets";
            this.tbFactPallets.Size = new System.Drawing.Size(50, 20);
            this.tbFactPallets.TabIndex = 5;
            this.tbFactPallets.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Brown;
            this.label10.Location = new System.Drawing.Point(236, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Паллет :";
            // 
            // cmbCarVolumes
            // 
            this.cmbCarVolumes.DataSource = this.tSPCarVolumesBindingSource;
            this.cmbCarVolumes.DisplayMember = "Volume";
            this.cmbCarVolumes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCarVolumes.FormattingEnabled = true;
            this.cmbCarVolumes.Location = new System.Drawing.Point(98, 22);
            this.cmbCarVolumes.Name = "cmbCarVolumes";
            this.cmbCarVolumes.Size = new System.Drawing.Size(100, 21);
            this.cmbCarVolumes.TabIndex = 1;
            this.cmbCarVolumes.ValueMember = "CV_ID";
            // 
            // tSPCarVolumesBindingSource
            // 
            this.tSPCarVolumesBindingSource.DataMember = "TSP_Car_Volumes";
            this.tSPCarVolumesBindingSource.DataSource = this.interbranch;
            // 
            // interbranch
            // 
            this.interbranch.DataSetName = "Interbranch";
            this.interbranch.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Объем, м³ :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "№ М/Л :";
            // 
            // tbRouteInformation
            // 
            this.tbRouteInformation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRouteInformation.BackColor = System.Drawing.SystemColors.Window;
            this.tbRouteInformation.Location = new System.Drawing.Point(98, 80);
            this.tbRouteInformation.Name = "tbRouteInformation";
            this.tbRouteInformation.ReadOnly = true;
            this.tbRouteInformation.Size = new System.Drawing.Size(244, 20);
            this.tbRouteInformation.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Описание :";
            // 
            // tbRouteNumber
            // 
            this.tbRouteNumber.BackColor = System.Drawing.SystemColors.Window;
            this.tbRouteNumber.Location = new System.Drawing.Point(98, 51);
            this.tbRouteNumber.Name = "tbRouteNumber";
            this.tbRouteNumber.ReadOnly = true;
            this.tbRouteNumber.Size = new System.Drawing.Size(100, 20);
            this.tbRouteNumber.TabIndex = 3;
            // 
            // imageViewerControl
            // 
            this.imageViewerControl.AutoZoomActivated = true;
            this.imageViewerControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewerControl.CurrentItem = null;
            this.imageViewerControl.CurrentZoomFactor = 1;
            this.imageViewerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageViewerControl.Location = new System.Drawing.Point(0, 0);
            this.imageViewerControl.Name = "imageViewerControl";
            this.imageViewerControl.Size = new System.Drawing.Size(507, 522);
            this.imageViewerControl.TabIndex = 1;
            this.imageViewerControl.PreviewCurrentItem += new System.EventHandler(this.imageViewerControl_PreviewCurrentItem);
            this.imageViewerControl.SizeChanged += new System.EventHandler(this.imageViewerControl_SizeChanged);
            // 
            // tSP_Car_VolumesTableAdapter
            // 
            this.tSP_Car_VolumesTableAdapter.ClearBeforeFill = true;
            // 
            // tbNote
            // 
            this.tbComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbComment.BackColor = System.Drawing.SystemColors.Info;
            this.tbComment.Location = new System.Drawing.Point(98, 139);
            this.tbComment.Name = "tbNote";
            this.tbComment.Size = new System.Drawing.Size(244, 20);
            this.tbComment.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Brown;
            this.label2.Location = new System.Drawing.Point(16, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Примечание :";
            // 
            // DeliveryTransportManageCarPhotosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 571);
            this.Controls.Add(this.pnlContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "DeliveryTransportManageCarPhotosForm";
            this.Text = "Создание фотоотчета по авто";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DeliveryTransportManageCarPhotosForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.scContent.Panel1.ResumeLayout(false);
            this.scContent.Panel2.ResumeLayout(false);
            this.scContent.ResumeLayout(false);
            this.pnlImages.ResumeLayout(false);
            this.pnlImages.PerformLayout();
            this.pnlImagesPath.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhotos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageProxyBindingSource)).EndInit();
            this.tsOperations.ResumeLayout(false);
            this.tsOperations.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tSPCarVolumesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.interbranch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.SplitContainer scContent;
        private System.Windows.Forms.Panel pnlImages;
        private System.Windows.Forms.Panel pnlHeader;
        private WMSOffice.Controls.Custom.ImageViewerControl imageViewerControl;
        private System.Windows.Forms.DataGridView dgvPhotos;
        private System.Windows.Forms.BindingSource imageProxyBindingSource;
        private WMSOffice.Data.Interbranch interbranch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbFactPallets;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbCarVolumes;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbRouteInformation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbRouteNumber;
        private System.Windows.Forms.ToolStrip tsOperations;
        private System.Windows.Forms.Panel pnlImagesPath;
        private System.Windows.Forms.ToolStripButton btnLoadPhoto;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnDeletePhoto;
        private System.Windows.Forms.BindingSource tSPCarVolumesBindingSource;
        private WMSOffice.Data.InterbranchTableAdapters.TSP_Car_VolumesTableAdapter tSP_Car_VolumesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SizeInfo;
        private System.Windows.Forms.TextBox tbLockBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbComment;
        private System.Windows.Forms.Label label2;
    }
}