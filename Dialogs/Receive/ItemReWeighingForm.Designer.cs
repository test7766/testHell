namespace WMSOffice.Dialogs.Receive
{
    partial class ItemReWeighingForm
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
            this.lblItemID_ = new System.Windows.Forms.Label();
            this.lblItemBarcode = new System.Windows.Forms.Label();
            this.stbItemID = new WMSOffice.Controls.SearchTextBox();
            this.tbsItemBarcode = new WMSOffice.Controls.TextBoxScaner();
            this.lblItemName = new System.Windows.Forms.Label();
            this.lblItemNameValue = new System.Windows.Forms.Label();
            this.lblWeight = new System.Windows.Forms.Label();
            this.lblWeightValue = new System.Windows.Forms.Label();
            this.cmbUoMValue = new System.Windows.Forms.ComboBox();
            this.reWeightUoMTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.receive = new WMSOffice.Data.Receive();
            this.lblUoM = new System.Windows.Forms.Label();
            this.btnObtainWeight = new System.Windows.Forms.Button();
            this.lblItemID = new System.Windows.Forms.Label();
            this.lblItemIDValue = new System.Windows.Forms.Label();
            this.reWeightUoMTypesTableAdapter = new WMSOffice.Data.ReceiveTableAdapters.ReWeightUoMTypesTableAdapter();
            this.lblPreviousWeightValue = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLotN = new System.Windows.Forms.Label();
            this.lblLotNValue = new System.Windows.Forms.Label();
            this.lblBoxNorm = new System.Windows.Forms.Label();
            this.lblBoxNormValue = new System.Windows.Forms.Label();
            this.scContent = new System.Windows.Forms.SplitContainer();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.itmIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itmNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reWeighingDocItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pickControl = new WMSOffice.Data.PickControl();
            this.reWeighingDocItemsTableAdapter = new WMSOffice.Data.PickControlTableAdapters.ReWeighingDocItemsTableAdapter();
            this.pnlItemReWeighingControlHost = new System.Windows.Forms.Panel();
            this.lblItemReWeighingControl = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reWeightUoMTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receive)).BeginInit();
            this.scContent.Panel1.SuspendLayout();
            this.scContent.Panel2.SuspendLayout();
            this.scContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reWeighingDocItemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).BeginInit();
            this.pnlItemReWeighingControlHost.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(1461, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1551, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 288);
            this.pnlButtons.Size = new System.Drawing.Size(994, 43);
            this.pnlButtons.TabIndex = 20;
            // 
            // lblItemID_
            // 
            this.lblItemID_.AutoSize = true;
            this.lblItemID_.Location = new System.Drawing.Point(236, 14);
            this.lblItemID_.Name = "lblItemID_";
            this.lblItemID_.Size = new System.Drawing.Size(32, 13);
            this.lblItemID_.TabIndex = 2;
            this.lblItemID_.Text = "Код :";
            // 
            // lblItemBarcode
            // 
            this.lblItemBarcode.AutoSize = true;
            this.lblItemBarcode.Location = new System.Drawing.Point(10, 14);
            this.lblItemBarcode.Name = "lblItemBarcode";
            this.lblItemBarcode.Size = new System.Drawing.Size(34, 13);
            this.lblItemBarcode.TabIndex = 0;
            this.lblItemBarcode.Text = "Ш/К :";
            // 
            // stbItemID
            // 
            this.stbItemID.Location = new System.Drawing.Point(274, 10);
            this.stbItemID.Name = "stbItemID";
            this.stbItemID.ReadOnly = false;
            this.stbItemID.Size = new System.Drawing.Size(100, 20);
            this.stbItemID.TabIndex = 3;
            this.stbItemID.UserID = ((long)(0));
            this.stbItemID.Value = null;
            this.stbItemID.ValueReferenceQuery = null;
            // 
            // tbsItemBarcode
            // 
            this.tbsItemBarcode.AllowType = true;
            this.tbsItemBarcode.AutoConvert = true;
            this.tbsItemBarcode.DelayThreshold = 50;
            this.tbsItemBarcode.Location = new System.Drawing.Point(50, 8);
            this.tbsItemBarcode.Name = "tbsItemBarcode";
            this.tbsItemBarcode.RaiseTextChangeWithoutEnter = false;
            this.tbsItemBarcode.ReadOnly = false;
            this.tbsItemBarcode.Size = new System.Drawing.Size(180, 25);
            this.tbsItemBarcode.TabIndex = 1;
            this.tbsItemBarcode.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.tbsItemBarcode.UseParentFont = false;
            this.tbsItemBarcode.UseScanModeOnly = false;
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Location = new System.Drawing.Point(10, 77);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(89, 13);
            this.lblItemName.TabIndex = 8;
            this.lblItemName.Text = "Наименование :";
            // 
            // lblItemNameValue
            // 
            this.lblItemNameValue.AutoSize = true;
            this.lblItemNameValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblItemNameValue.Location = new System.Drawing.Point(113, 77);
            this.lblItemNameValue.Name = "lblItemNameValue";
            this.lblItemNameValue.Size = new System.Drawing.Size(11, 13);
            this.lblItemNameValue.TabIndex = 9;
            this.lblItemNameValue.Text = "-";
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Location = new System.Drawing.Point(10, 140);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(32, 13);
            this.lblWeight.TabIndex = 14;
            this.lblWeight.Text = "Вес :";
            // 
            // lblWeightValue
            // 
            this.lblWeightValue.AutoSize = true;
            this.lblWeightValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblWeightValue.Location = new System.Drawing.Point(113, 140);
            this.lblWeightValue.Name = "lblWeightValue";
            this.lblWeightValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblWeightValue.Size = new System.Drawing.Size(11, 13);
            this.lblWeightValue.TabIndex = 16;
            this.lblWeightValue.Text = "-";
            // 
            // cmbUoMValue
            // 
            this.cmbUoMValue.DataSource = this.reWeightUoMTypesBindingSource;
            this.cmbUoMValue.DisplayMember = "UOM";
            this.cmbUoMValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUoMValue.FormattingEnabled = true;
            this.cmbUoMValue.Location = new System.Drawing.Point(274, 52);
            this.cmbUoMValue.Name = "cmbUoMValue";
            this.cmbUoMValue.Size = new System.Drawing.Size(100, 21);
            this.cmbUoMValue.TabIndex = 7;
            this.cmbUoMValue.ValueMember = "IQUOM";
            this.cmbUoMValue.SelectedValueChanged += new System.EventHandler(this.cmbUoMValue_SelectedValueChanged);
            // 
            // reWeightUoMTypesBindingSource
            // 
            this.reWeightUoMTypesBindingSource.DataMember = "ReweightUoMTypes";
            this.reWeightUoMTypesBindingSource.DataSource = this.receive;
            // 
            // receive
            // 
            this.receive.DataSetName = "Receive";
            this.receive.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblUoM
            // 
            this.lblUoM.AutoSize = true;
            this.lblUoM.Location = new System.Drawing.Point(236, 56);
            this.lblUoM.Name = "lblUoM";
            this.lblUoM.Size = new System.Drawing.Size(28, 13);
            this.lblUoM.TabIndex = 6;
            this.lblUoM.Text = "ЕИ :";
            // 
            // btnObtainWeight
            // 
            this.btnObtainWeight.Image = global::WMSOffice.Properties.Resources.Search1;
            this.btnObtainWeight.Location = new System.Drawing.Point(48, 136);
            this.btnObtainWeight.Name = "btnObtainWeight";
            this.btnObtainWeight.Size = new System.Drawing.Size(20, 20);
            this.btnObtainWeight.TabIndex = 15;
            this.btnObtainWeight.UseVisualStyleBackColor = true;
            this.btnObtainWeight.Click += new System.EventHandler(this.btnObtainWeight_Click);
            // 
            // lblItemID
            // 
            this.lblItemID.AutoSize = true;
            this.lblItemID.Location = new System.Drawing.Point(10, 56);
            this.lblItemID.Name = "lblItemID";
            this.lblItemID.Size = new System.Drawing.Size(32, 13);
            this.lblItemID.TabIndex = 4;
            this.lblItemID.Text = "Код :";
            // 
            // lblItemIDValue
            // 
            this.lblItemIDValue.AutoSize = true;
            this.lblItemIDValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblItemIDValue.Location = new System.Drawing.Point(113, 56);
            this.lblItemIDValue.Name = "lblItemIDValue";
            this.lblItemIDValue.Size = new System.Drawing.Size(11, 13);
            this.lblItemIDValue.TabIndex = 5;
            this.lblItemIDValue.Text = "-";
            // 
            // reWeightUoMTypesTableAdapter
            // 
            this.reWeightUoMTypesTableAdapter.ClearBeforeFill = true;
            // 
            // lblPreviousWeightValue
            // 
            this.lblPreviousWeightValue.AutoSize = true;
            this.lblPreviousWeightValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPreviousWeightValue.Location = new System.Drawing.Point(327, 140);
            this.lblPreviousWeightValue.Name = "lblPreviousWeightValue";
            this.lblPreviousWeightValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPreviousWeightValue.Size = new System.Drawing.Size(11, 13);
            this.lblPreviousWeightValue.TabIndex = 18;
            this.lblPreviousWeightValue.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Предыдущий вес :";
            // 
            // lblLotN
            // 
            this.lblLotN.AutoSize = true;
            this.lblLotN.Location = new System.Drawing.Point(10, 98);
            this.lblLotN.Name = "lblLotN";
            this.lblLotN.Size = new System.Drawing.Size(50, 13);
            this.lblLotN.TabIndex = 10;
            this.lblLotN.Text = "Партия :";
            // 
            // lblLotNValue
            // 
            this.lblLotNValue.AutoSize = true;
            this.lblLotNValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLotNValue.Location = new System.Drawing.Point(113, 98);
            this.lblLotNValue.Name = "lblLotNValue";
            this.lblLotNValue.Size = new System.Drawing.Size(11, 13);
            this.lblLotNValue.TabIndex = 11;
            this.lblLotNValue.Text = "-";
            // 
            // lblBoxNorm
            // 
            this.lblBoxNorm.AutoSize = true;
            this.lblBoxNorm.Location = new System.Drawing.Point(10, 119);
            this.lblBoxNorm.Name = "lblBoxNorm";
            this.lblBoxNorm.Size = new System.Drawing.Size(94, 13);
            this.lblBoxNorm.TabIndex = 12;
            this.lblBoxNorm.Text = "Ящичная норма :";
            // 
            // lblBoxNormValue
            // 
            this.lblBoxNormValue.AutoSize = true;
            this.lblBoxNormValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBoxNormValue.Location = new System.Drawing.Point(113, 119);
            this.lblBoxNormValue.Name = "lblBoxNormValue";
            this.lblBoxNormValue.Size = new System.Drawing.Size(11, 13);
            this.lblBoxNormValue.TabIndex = 13;
            this.lblBoxNormValue.Text = "-";
            // 
            // scContent
            // 
            this.scContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scContent.IsSplitterFixed = true;
            this.scContent.Location = new System.Drawing.Point(0, 0);
            this.scContent.Name = "scContent";
            // 
            // scContent.Panel1
            // 
            this.scContent.Panel1.Controls.Add(this.pnlItemReWeighingControlHost);
            this.scContent.Panel1.Controls.Add(this.lblBoxNormValue);
            this.scContent.Panel1.Controls.Add(this.tbsItemBarcode);
            this.scContent.Panel1.Controls.Add(this.lblBoxNorm);
            this.scContent.Panel1.Controls.Add(this.stbItemID);
            this.scContent.Panel1.Controls.Add(this.lblLotNValue);
            this.scContent.Panel1.Controls.Add(this.lblItemBarcode);
            this.scContent.Panel1.Controls.Add(this.lblLotN);
            this.scContent.Panel1.Controls.Add(this.lblItemID_);
            this.scContent.Panel1.Controls.Add(this.lblPreviousWeightValue);
            this.scContent.Panel1.Controls.Add(this.lblItemName);
            this.scContent.Panel1.Controls.Add(this.label2);
            this.scContent.Panel1.Controls.Add(this.lblItemNameValue);
            this.scContent.Panel1.Controls.Add(this.lblItemIDValue);
            this.scContent.Panel1.Controls.Add(this.lblWeight);
            this.scContent.Panel1.Controls.Add(this.lblItemID);
            this.scContent.Panel1.Controls.Add(this.lblWeightValue);
            this.scContent.Panel1.Controls.Add(this.btnObtainWeight);
            this.scContent.Panel1.Controls.Add(this.cmbUoMValue);
            this.scContent.Panel1.Controls.Add(this.lblUoM);
            // 
            // scContent.Panel2
            // 
            this.scContent.Panel2.Controls.Add(this.dgvItems);
            this.scContent.Size = new System.Drawing.Size(994, 288);
            this.scContent.SplitterDistance = 400;
            this.scContent.TabIndex = 21;
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AllowUserToResizeRows = false;
            this.dgvItems.AutoGenerateColumns = false;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itmIdDataGridViewTextBoxColumn,
            this.itmNameDataGridViewTextBoxColumn,
            this.manufDataGridViewTextBoxColumn,
            this.vendorDataGridViewTextBoxColumn});
            this.dgvItems.DataSource = this.reWeighingDocItemsBindingSource;
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItems.Location = new System.Drawing.Point(0, 0);
            this.dgvItems.MultiSelect = false;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(590, 288);
            this.dgvItems.TabIndex = 0;
            this.dgvItems.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvItems_CellFormatting);
            // 
            // itmIdDataGridViewTextBoxColumn
            // 
            this.itmIdDataGridViewTextBoxColumn.DataPropertyName = "Itm_Id";
            this.itmIdDataGridViewTextBoxColumn.HeaderText = "Код";
            this.itmIdDataGridViewTextBoxColumn.Name = "itmIdDataGridViewTextBoxColumn";
            this.itmIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.itmIdDataGridViewTextBoxColumn.Width = 45;
            // 
            // itmNameDataGridViewTextBoxColumn
            // 
            this.itmNameDataGridViewTextBoxColumn.DataPropertyName = "Itm_Name";
            this.itmNameDataGridViewTextBoxColumn.HeaderText = "Наименование";
            this.itmNameDataGridViewTextBoxColumn.Name = "itmNameDataGridViewTextBoxColumn";
            this.itmNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.itmNameDataGridViewTextBoxColumn.Width = 220;
            // 
            // manufDataGridViewTextBoxColumn
            // 
            this.manufDataGridViewTextBoxColumn.DataPropertyName = "Manuf";
            this.manufDataGridViewTextBoxColumn.HeaderText = "Производитель";
            this.manufDataGridViewTextBoxColumn.Name = "manufDataGridViewTextBoxColumn";
            this.manufDataGridViewTextBoxColumn.ReadOnly = true;
            this.manufDataGridViewTextBoxColumn.Width = 150;
            // 
            // vendorDataGridViewTextBoxColumn
            // 
            this.vendorDataGridViewTextBoxColumn.DataPropertyName = "Vendor";
            this.vendorDataGridViewTextBoxColumn.HeaderText = "Поставщик";
            this.vendorDataGridViewTextBoxColumn.Name = "vendorDataGridViewTextBoxColumn";
            this.vendorDataGridViewTextBoxColumn.ReadOnly = true;
            this.vendorDataGridViewTextBoxColumn.Width = 150;
            // 
            // reWeighingDocItemsBindingSource
            // 
            this.reWeighingDocItemsBindingSource.DataMember = "ReWeighingDocItems";
            this.reWeighingDocItemsBindingSource.DataSource = this.pickControl;
            // 
            // pickControl
            // 
            this.pickControl.DataSetName = "PickControl";
            this.pickControl.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reWeighingDocItemsTableAdapter
            // 
            this.reWeighingDocItemsTableAdapter.ClearBeforeFill = true;
            // 
            // pnlItemReWeighingControlHost
            // 
            this.pnlItemReWeighingControlHost.Controls.Add(this.lblItemReWeighingControl);
            this.pnlItemReWeighingControlHost.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlItemReWeighingControlHost.Location = new System.Drawing.Point(0, 168);
            this.pnlItemReWeighingControlHost.Name = "pnlItemReWeighingControlHost";
            this.pnlItemReWeighingControlHost.Size = new System.Drawing.Size(400, 120);
            this.pnlItemReWeighingControlHost.TabIndex = 20;
            // 
            // lblItemReWeighingControl
            // 
            this.lblItemReWeighingControl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblItemReWeighingControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblItemReWeighingControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblItemReWeighingControl.Location = new System.Drawing.Point(36, 37);
            this.lblItemReWeighingControl.Name = "lblItemReWeighingControl";
            this.lblItemReWeighingControl.Size = new System.Drawing.Size(329, 46);
            this.lblItemReWeighingControl.TabIndex = 0;
            this.lblItemReWeighingControl.Text = "Хостинг компонента взвешивания, \r\nкоторый реализует сценарный алгоритм\r\n";
            // 
            // ItemReWeighingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 331);
            this.Controls.Add(this.scContent);
            this.KeyPreview = true;
            this.Name = "ItemReWeighingForm";
            this.Text = "Повторное взвешивание товара";
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.scContent, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.reWeightUoMTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receive)).EndInit();
            this.scContent.Panel1.ResumeLayout(false);
            this.scContent.Panel1.PerformLayout();
            this.scContent.Panel2.ResumeLayout(false);
            this.scContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reWeighingDocItemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).EndInit();
            this.pnlItemReWeighingControlHost.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblItemID_;
        private System.Windows.Forms.Label lblItemBarcode;
        private WMSOffice.Controls.SearchTextBox stbItemID;
        private WMSOffice.Controls.TextBoxScaner tbsItemBarcode;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Label lblItemNameValue;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Label lblWeightValue;
        private System.Windows.Forms.ComboBox cmbUoMValue;
        private System.Windows.Forms.Label lblUoM;
        private System.Windows.Forms.Button btnObtainWeight;
        private System.Windows.Forms.Label lblItemID;
        private System.Windows.Forms.Label lblItemIDValue;
        private System.Windows.Forms.BindingSource reWeightUoMTypesBindingSource;
        private WMSOffice.Data.Receive receive;
        private WMSOffice.Data.ReceiveTableAdapters.ReWeightUoMTypesTableAdapter reWeightUoMTypesTableAdapter;
        private System.Windows.Forms.Label lblPreviousWeightValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblLotN;
        private System.Windows.Forms.Label lblLotNValue;
        private System.Windows.Forms.Label lblBoxNorm;
        private System.Windows.Forms.Label lblBoxNormValue;
        private System.Windows.Forms.SplitContainer scContent;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.BindingSource reWeighingDocItemsBindingSource;
        private Data.PickControl pickControl;
        private Data.PickControlTableAdapters.ReWeighingDocItemsTableAdapter reWeighingDocItemsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn itmIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itmNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel pnlItemReWeighingControlHost;
        private System.Windows.Forms.Label lblItemReWeighingControl;
    }
}