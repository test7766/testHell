namespace WMSOffice.Dialogs.PickControl
{
    partial class DebtorsReturnedTareInventoryInfoForm
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
            this.scContent = new System.Windows.Forms.SplitContainer();
            this.dgvInfo = new System.Windows.Forms.DataGridView();
            this.dgvInfoDetails = new System.Windows.Forms.DataGridView();
            this.pickControl = new WMSOffice.Data.PickControl();
            this.rETTareInventoryInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rET_Tare_Inventory_InfoTableAdapter = new WMSOffice.Data.PickControlTableAdapters.RET_Tare_Inventory_InfoTableAdapter();
            this.rETTareInventoryInfoDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rET_Tare_Inventory_Info_DetailsTableAdapter = new WMSOffice.Data.PickControlTableAdapters.RET_Tare_Inventory_Info_DetailsTableAdapter();
            this.tareTypeDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bARCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlButtons.SuspendLayout();
            this.scContent.Panel1.SuspendLayout();
            this.scContent.Panel2.SuspendLayout();
            this.scContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfoDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rETTareInventoryInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rETTareInventoryInfoDetailsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(617, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(707, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 528);
            this.pnlButtons.Size = new System.Drawing.Size(794, 43);
            // 
            // scContent
            // 
            this.scContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scContent.Location = new System.Drawing.Point(0, 2);
            this.scContent.Name = "scContent";
            this.scContent.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scContent.Panel1
            // 
            this.scContent.Panel1.Controls.Add(this.dgvInfo);
            // 
            // scContent.Panel2
            // 
            this.scContent.Panel2.Controls.Add(this.dgvInfoDetails);
            this.scContent.Size = new System.Drawing.Size(794, 520);
            this.scContent.SplitterDistance = 249;
            this.scContent.TabIndex = 101;
            // 
            // dgvInfo
            // 
            this.dgvInfo.AllowUserToAddRows = false;
            this.dgvInfo.AllowUserToDeleteRows = false;
            this.dgvInfo.AllowUserToResizeColumns = false;
            this.dgvInfo.AllowUserToResizeRows = false;
            this.dgvInfo.AutoGenerateColumns = false;
            this.dgvInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.typeIdDataGridViewTextBoxColumn,
            this.typeNameDataGridViewTextBoxColumn,
            this.valueDataGridViewTextBoxColumn});
            this.dgvInfo.DataSource = this.rETTareInventoryInfoBindingSource;
            this.dgvInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInfo.Location = new System.Drawing.Point(0, 0);
            this.dgvInfo.MultiSelect = false;
            this.dgvInfo.Name = "dgvInfo";
            this.dgvInfo.ReadOnly = true;
            this.dgvInfo.RowHeadersVisible = false;
            this.dgvInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInfo.Size = new System.Drawing.Size(794, 249);
            this.dgvInfo.TabIndex = 0;
            this.dgvInfo.SelectionChanged += new System.EventHandler(this.dgvInfo_SelectionChanged);
            // 
            // dgvInfoDetails
            // 
            this.dgvInfoDetails.AllowUserToAddRows = false;
            this.dgvInfoDetails.AllowUserToDeleteRows = false;
            this.dgvInfoDetails.AllowUserToResizeColumns = false;
            this.dgvInfoDetails.AllowUserToResizeRows = false;
            this.dgvInfoDetails.AutoGenerateColumns = false;
            this.dgvInfoDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvInfoDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInfoDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tareTypeDescriptionDataGridViewTextBoxColumn,
            this.bARCodeDataGridViewTextBoxColumn});
            this.dgvInfoDetails.DataSource = this.rETTareInventoryInfoDetailsBindingSource;
            this.dgvInfoDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInfoDetails.Location = new System.Drawing.Point(0, 0);
            this.dgvInfoDetails.MultiSelect = false;
            this.dgvInfoDetails.Name = "dgvInfoDetails";
            this.dgvInfoDetails.ReadOnly = true;
            this.dgvInfoDetails.RowHeadersVisible = false;
            this.dgvInfoDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInfoDetails.Size = new System.Drawing.Size(794, 267);
            this.dgvInfoDetails.TabIndex = 1;
            // 
            // pickControl
            // 
            this.pickControl.DataSetName = "PickControl";
            this.pickControl.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rETTareInventoryInfoBindingSource
            // 
            this.rETTareInventoryInfoBindingSource.DataMember = "RET_Tare Inventory_Info";
            this.rETTareInventoryInfoBindingSource.DataSource = this.pickControl;
            // 
            // rET_Tare_Inventory_InfoTableAdapter
            // 
            this.rET_Tare_Inventory_InfoTableAdapter.ClearBeforeFill = true;
            // 
            // rETTareInventoryInfoDetailsBindingSource
            // 
            this.rETTareInventoryInfoDetailsBindingSource.DataMember = "RET_Tare_Inventory_Info_Details";
            this.rETTareInventoryInfoDetailsBindingSource.DataSource = this.pickControl;
            // 
            // rET_Tare_Inventory_Info_DetailsTableAdapter
            // 
            this.rET_Tare_Inventory_Info_DetailsTableAdapter.ClearBeforeFill = true;
            // 
            // tareTypeDescriptionDataGridViewTextBoxColumn
            // 
            this.tareTypeDescriptionDataGridViewTextBoxColumn.DataPropertyName = "Tare_Type_Description";
            this.tareTypeDescriptionDataGridViewTextBoxColumn.HeaderText = "Тип тары";
            this.tareTypeDescriptionDataGridViewTextBoxColumn.Name = "tareTypeDescriptionDataGridViewTextBoxColumn";
            this.tareTypeDescriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.tareTypeDescriptionDataGridViewTextBoxColumn.Width = 79;
            // 
            // bARCodeDataGridViewTextBoxColumn
            // 
            this.bARCodeDataGridViewTextBoxColumn.DataPropertyName = "BAR_Code";
            this.bARCodeDataGridViewTextBoxColumn.HeaderText = "Ш/К";
            this.bARCodeDataGridViewTextBoxColumn.Name = "bARCodeDataGridViewTextBoxColumn";
            this.bARCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.bARCodeDataGridViewTextBoxColumn.Width = 53;
            // 
            // typeIdDataGridViewTextBoxColumn
            // 
            this.typeIdDataGridViewTextBoxColumn.DataPropertyName = "Type_Id";
            this.typeIdDataGridViewTextBoxColumn.HeaderText = "Код";
            this.typeIdDataGridViewTextBoxColumn.Name = "typeIdDataGridViewTextBoxColumn";
            this.typeIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.typeIdDataGridViewTextBoxColumn.Width = 51;
            // 
            // typeNameDataGridViewTextBoxColumn
            // 
            this.typeNameDataGridViewTextBoxColumn.DataPropertyName = "Type_Name";
            this.typeNameDataGridViewTextBoxColumn.HeaderText = "Тип счета";
            this.typeNameDataGridViewTextBoxColumn.Name = "typeNameDataGridViewTextBoxColumn";
            this.typeNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.typeNameDataGridViewTextBoxColumn.Width = 82;
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            this.valueDataGridViewTextBoxColumn.HeaderText = "Количество";
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            this.valueDataGridViewTextBoxColumn.ReadOnly = true;
            this.valueDataGridViewTextBoxColumn.Width = 91;
            // 
            // DebtorsReturnedTareInventoryInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 571);
            this.Controls.Add(this.scContent);
            this.Name = "DebtorsReturnedTareInventoryInfoForm";
            this.Text = "Детали инвентаризации";
            this.Controls.SetChildIndex(this.scContent, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.scContent.Panel1.ResumeLayout(false);
            this.scContent.Panel2.ResumeLayout(false);
            this.scContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfoDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rETTareInventoryInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rETTareInventoryInfoDetailsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer scContent;
        private System.Windows.Forms.DataGridView dgvInfo;
        private System.Windows.Forms.DataGridView dgvInfoDetails;
        private System.Windows.Forms.BindingSource rETTareInventoryInfoBindingSource;
        private WMSOffice.Data.PickControl pickControl;
        private System.Windows.Forms.BindingSource rETTareInventoryInfoDetailsBindingSource;
        private WMSOffice.Data.PickControlTableAdapters.RET_Tare_Inventory_InfoTableAdapter rET_Tare_Inventory_InfoTableAdapter;
        private WMSOffice.Data.PickControlTableAdapters.RET_Tare_Inventory_Info_DetailsTableAdapter rET_Tare_Inventory_Info_DetailsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn tareTypeDescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bARCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
    }
}