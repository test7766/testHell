namespace WMSOffice.Dialogs.InterBranch
{
    partial class AttachImagesForm
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
            this.imageViewerControl = new WMSOffice.Controls.Custom.ImageViewerControl();
            this.pnlDriverInfo = new System.Windows.Forms.Panel();
            this.dgvPhotos = new System.Windows.Forms.DataGridView();
            this.fullNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageProxyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnlDriverInfoHeader = new System.Windows.Forms.Panel();
            this.ecmbDriverName = new WMSOffice.Controls.ExtraComboBox.ExtraComboBox();
            this.photoDocAttributeDriverNameValuesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.interbranch = new WMSOffice.Data.Interbranch();
            this.ecmbCarName = new WMSOffice.Controls.ExtraComboBox.ExtraComboBox();
            this.photoDocAttributeCarNameValuesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gbNumbers = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ecmbTrailerNumber = new WMSOffice.Controls.ExtraComboBox.ExtraComboBox();
            this.photoDocAttributeTrailerNumberValuesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ecmbCarNumber = new WMSOffice.Controls.ExtraComboBox.ExtraComboBox();
            this.photoDocAttributeCarNumberValuesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cbIsHiredCar = new System.Windows.Forms.CheckBox();
            this.cmbWarehouse = new System.Windows.Forms.ComboBox();
            this.warehousesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.btnLoadPhoto = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.warehousesTableAdapter = new WMSOffice.Data.InterbranchTableAdapters.WarehousesTableAdapter();
            this.photoDocAttributeValuesTableAdapter = new WMSOffice.Data.InterbranchTableAdapters.PhotoDocAttributeValuesTableAdapter();
            this.pnlButtons.SuspendLayout();
            this.pnlDriverInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhotos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageProxyBindingSource)).BeginInit();
            this.pnlDriverInfoHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.photoDocAttributeDriverNameValuesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.interbranch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.photoDocAttributeCarNameValuesBindingSource)).BeginInit();
            this.gbNumbers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.photoDocAttributeTrailerNumberValuesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.photoDocAttributeCarNumberValuesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.warehousesBindingSource)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(5165, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(5255, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 469);
            this.pnlButtons.Size = new System.Drawing.Size(734, 43);
            this.pnlButtons.TabIndex = 1;
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
            this.imageViewerControl.Size = new System.Drawing.Size(430, 463);
            this.imageViewerControl.TabIndex = 0;
            this.imageViewerControl.PreviewCurrentItem += new System.EventHandler(this.imageViewerControl_PreviewCurrentItem);
            // 
            // pnlDriverInfo
            // 
            this.pnlDriverInfo.Controls.Add(this.dgvPhotos);
            this.pnlDriverInfo.Controls.Add(this.pnlDriverInfoHeader);
            this.pnlDriverInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDriverInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlDriverInfo.Name = "pnlDriverInfo";
            this.pnlDriverInfo.Size = new System.Drawing.Size(300, 463);
            this.pnlDriverInfo.TabIndex = 0;
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
            this.fullNameDataGridViewTextBoxColumn});
            this.dgvPhotos.DataSource = this.imageProxyBindingSource;
            this.dgvPhotos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhotos.Location = new System.Drawing.Point(0, 225);
            this.dgvPhotos.MultiSelect = false;
            this.dgvPhotos.Name = "dgvPhotos";
            this.dgvPhotos.ReadOnly = true;
            this.dgvPhotos.RowHeadersWidth = 15;
            this.dgvPhotos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhotos.Size = new System.Drawing.Size(300, 238);
            this.dgvPhotos.TabIndex = 1;
            this.dgvPhotos.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvPhotos_UserDeletingRow);
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
            // imageProxyBindingSource
            // 
            this.imageProxyBindingSource.DataSource = typeof(WMSOffice.Controls.Custom.ImageProxy);
            // 
            // pnlDriverInfoHeader
            // 
            this.pnlDriverInfoHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDriverInfoHeader.Controls.Add(this.ecmbDriverName);
            this.pnlDriverInfoHeader.Controls.Add(this.ecmbCarName);
            this.pnlDriverInfoHeader.Controls.Add(this.gbNumbers);
            this.pnlDriverInfoHeader.Controls.Add(this.cbIsHiredCar);
            this.pnlDriverInfoHeader.Controls.Add(this.cmbWarehouse);
            this.pnlDriverInfoHeader.Controls.Add(this.label4);
            this.pnlDriverInfoHeader.Controls.Add(this.btnLoadPhoto);
            this.pnlDriverInfoHeader.Controls.Add(this.label3);
            this.pnlDriverInfoHeader.Controls.Add(this.label1);
            this.pnlDriverInfoHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDriverInfoHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlDriverInfoHeader.Name = "pnlDriverInfoHeader";
            this.pnlDriverInfoHeader.Size = new System.Drawing.Size(300, 225);
            this.pnlDriverInfoHeader.TabIndex = 0;
            // 
            // ecmbDriverName
            // 
            this.ecmbDriverName.DataSource = this.photoDocAttributeDriverNameValuesBindingSource;
            this.ecmbDriverName.DisplayMember = "Value";
            this.ecmbDriverName.FormattingEnabled = true;
            this.ecmbDriverName.Location = new System.Drawing.Point(78, 168);
            this.ecmbDriverName.MatchingMethod = WMSOffice.Controls.ExtraComboBox.StringMatchingMethod.UseWildcards;
            this.ecmbDriverName.Name = "ecmbDriverName";
            this.ecmbDriverName.Size = new System.Drawing.Size(217, 21);
            this.ecmbDriverName.TabIndex = 7;
            this.ecmbDriverName.ValueMember = "Value";
            // 
            // photoDocAttributeDriverNameValuesBindingSource
            // 
            this.photoDocAttributeDriverNameValuesBindingSource.DataMember = "PhotoDocAttributeValues";
            this.photoDocAttributeDriverNameValuesBindingSource.DataSource = this.interbranch;
            // 
            // interbranch
            // 
            this.interbranch.DataSetName = "Interbranch";
            this.interbranch.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ecmbCarName
            // 
            this.ecmbCarName.DataSource = this.photoDocAttributeCarNameValuesBindingSource;
            this.ecmbCarName.DisplayMember = "Value";
            this.ecmbCarName.FormattingEnabled = true;
            this.ecmbCarName.Location = new System.Drawing.Point(78, 33);
            this.ecmbCarName.MatchingMethod = WMSOffice.Controls.ExtraComboBox.StringMatchingMethod.UseWildcards;
            this.ecmbCarName.Name = "ecmbCarName";
            this.ecmbCarName.Size = new System.Drawing.Size(217, 21);
            this.ecmbCarName.TabIndex = 3;
            this.ecmbCarName.ValueMember = "Value";
            // 
            // photoDocAttributeCarNameValuesBindingSource
            // 
            this.photoDocAttributeCarNameValuesBindingSource.DataMember = "PhotoDocAttributeValues";
            this.photoDocAttributeCarNameValuesBindingSource.DataSource = this.interbranch;
            // 
            // gbNumbers
            // 
            this.gbNumbers.Controls.Add(this.label5);
            this.gbNumbers.Controls.Add(this.label2);
            this.gbNumbers.Controls.Add(this.ecmbTrailerNumber);
            this.gbNumbers.Controls.Add(this.ecmbCarNumber);
            this.gbNumbers.Location = new System.Drawing.Point(6, 86);
            this.gbNumbers.Name = "gbNumbers";
            this.gbNumbers.Size = new System.Drawing.Size(289, 70);
            this.gbNumbers.TabIndex = 5;
            this.gbNumbers.TabStop = false;
            this.gbNumbers.Text = "Номера";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Прицеп";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Автомобиль";
            // 
            // ecmbTrailerNumber
            // 
            this.ecmbTrailerNumber.DataSource = this.photoDocAttributeTrailerNumberValuesBindingSource;
            this.ecmbTrailerNumber.DisplayMember = "Value";
            this.ecmbTrailerNumber.FormattingEnabled = true;
            this.ecmbTrailerNumber.Location = new System.Drawing.Point(81, 47);
            this.ecmbTrailerNumber.MatchingMethod = WMSOffice.Controls.ExtraComboBox.StringMatchingMethod.UseWildcards;
            this.ecmbTrailerNumber.Name = "ecmbTrailerNumber";
            this.ecmbTrailerNumber.Size = new System.Drawing.Size(202, 21);
            this.ecmbTrailerNumber.TabIndex = 3;
            this.ecmbTrailerNumber.ValueMember = "Value";
            // 
            // photoDocAttributeTrailerNumberValuesBindingSource
            // 
            this.photoDocAttributeTrailerNumberValuesBindingSource.DataMember = "PhotoDocAttributeValues";
            this.photoDocAttributeTrailerNumberValuesBindingSource.DataSource = this.interbranch;
            // 
            // ecmbCarNumber
            // 
            this.ecmbCarNumber.DataSource = this.photoDocAttributeCarNumberValuesBindingSource;
            this.ecmbCarNumber.DisplayMember = "Value";
            this.ecmbCarNumber.FormattingEnabled = true;
            this.ecmbCarNumber.Location = new System.Drawing.Point(81, 18);
            this.ecmbCarNumber.MatchingMethod = WMSOffice.Controls.ExtraComboBox.StringMatchingMethod.UseWildcards;
            this.ecmbCarNumber.Name = "ecmbCarNumber";
            this.ecmbCarNumber.Size = new System.Drawing.Size(202, 21);
            this.ecmbCarNumber.TabIndex = 1;
            this.ecmbCarNumber.ValueMember = "Value";
            // 
            // photoDocAttributeCarNumberValuesBindingSource
            // 
            this.photoDocAttributeCarNumberValuesBindingSource.DataMember = "PhotoDocAttributeValues";
            this.photoDocAttributeCarNumberValuesBindingSource.DataSource = this.interbranch;
            // 
            // cbIsHiredCar
            // 
            this.cbIsHiredCar.AutoSize = true;
            this.cbIsHiredCar.Location = new System.Drawing.Point(78, 61);
            this.cbIsHiredCar.Name = "cbIsHiredCar";
            this.cbIsHiredCar.Size = new System.Drawing.Size(129, 17);
            this.cbIsHiredCar.TabIndex = 4;
            this.cbIsHiredCar.Text = "Наемный транспорт";
            this.cbIsHiredCar.UseVisualStyleBackColor = true;
            // 
            // cmbWarehouse
            // 
            this.cmbWarehouse.DataSource = this.warehousesBindingSource;
            this.cmbWarehouse.DisplayMember = "WarehouseName";
            this.cmbWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWarehouse.FormattingEnabled = true;
            this.cmbWarehouse.Location = new System.Drawing.Point(78, 4);
            this.cmbWarehouse.Name = "cmbWarehouse";
            this.cmbWarehouse.Size = new System.Drawing.Size(217, 21);
            this.cmbWarehouse.TabIndex = 1;
            this.cmbWarehouse.ValueMember = "WarehouseID";
            this.cmbWarehouse.KeyDown += new System.Windows.Forms.KeyEventHandler(this.driverInfo_KeyDown);
            // 
            // warehousesBindingSource
            // 
            this.warehousesBindingSource.DataMember = "Warehouses";
            this.warehousesBindingSource.DataSource = this.interbranch;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Склад";
            // 
            // btnLoadPhoto
            // 
            this.btnLoadPhoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadPhoto.Location = new System.Drawing.Point(195, 196);
            this.btnLoadPhoto.Name = "btnLoadPhoto";
            this.btnLoadPhoto.Size = new System.Drawing.Size(100, 23);
            this.btnLoadPhoto.TabIndex = 8;
            this.btnLoadPhoto.Text = "Загрузить фото";
            this.btnLoadPhoto.UseVisualStyleBackColor = true;
            this.btnLoadPhoto.Click += new System.EventHandler(this.btnLoadPhoto_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Водитель";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Автомобиль";
            // 
            // scMain
            // 
            this.scMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scMain.Location = new System.Drawing.Point(0, 0);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.pnlDriverInfo);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.imageViewerControl);
            this.scMain.Size = new System.Drawing.Size(734, 463);
            this.scMain.SplitterDistance = 300;
            this.scMain.TabIndex = 0;
            // 
            // warehousesTableAdapter
            // 
            this.warehousesTableAdapter.ClearBeforeFill = true;
            // 
            // photoDocAttributeValuesTableAdapter
            // 
            this.photoDocAttributeValuesTableAdapter.ClearBeforeFill = true;
            // 
            // AttachImagesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 512);
            this.Controls.Add(this.scMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "AttachImagesForm";
            this.Text = "Создание документа фотоотчета";
            this.Load += new System.EventHandler(this.AttachImagesForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AttachImagesForm_FormClosing);
            this.Controls.SetChildIndex(this.scMain, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.pnlDriverInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhotos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageProxyBindingSource)).EndInit();
            this.pnlDriverInfoHeader.ResumeLayout(false);
            this.pnlDriverInfoHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.photoDocAttributeDriverNameValuesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.interbranch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.photoDocAttributeCarNameValuesBindingSource)).EndInit();
            this.gbNumbers.ResumeLayout(false);
            this.gbNumbers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.photoDocAttributeTrailerNumberValuesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.photoDocAttributeCarNumberValuesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.warehousesBindingSource)).EndInit();
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            this.scMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private WMSOffice.Controls.Custom.ImageViewerControl imageViewerControl;
        private System.Windows.Forms.Panel pnlDriverInfo;
        private System.Windows.Forms.DataGridView dgvPhotos;
        private System.Windows.Forms.Panel pnlDriverInfoHeader;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLoadPhoto;
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.BindingSource imageProxyBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.ComboBox cmbWarehouse;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource warehousesBindingSource;
        private WMSOffice.Data.Interbranch interbranch;
        private WMSOffice.Data.InterbranchTableAdapters.WarehousesTableAdapter warehousesTableAdapter;
        private System.Windows.Forms.GroupBox gbNumbers;
        private System.Windows.Forms.CheckBox cbIsHiredCar;
        private System.Windows.Forms.Label label5;
        private WMSOffice.Controls.ExtraComboBox.ExtraComboBox ecmbCarNumber;
        private WMSOffice.Controls.ExtraComboBox.ExtraComboBox ecmbTrailerNumber;
        private WMSOffice.Controls.ExtraComboBox.ExtraComboBox ecmbCarName;
        private WMSOffice.Controls.ExtraComboBox.ExtraComboBox ecmbDriverName;
        private System.Windows.Forms.BindingSource photoDocAttributeCarNameValuesBindingSource;
        private WMSOffice.Data.InterbranchTableAdapters.PhotoDocAttributeValuesTableAdapter photoDocAttributeValuesTableAdapter;
        private System.Windows.Forms.BindingSource photoDocAttributeCarNumberValuesBindingSource;
        private System.Windows.Forms.BindingSource photoDocAttributeTrailerNumberValuesBindingSource;
        private System.Windows.Forms.BindingSource photoDocAttributeDriverNameValuesBindingSource;
    }
}