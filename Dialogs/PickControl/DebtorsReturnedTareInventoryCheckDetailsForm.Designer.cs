namespace WMSOffice.Dialogs.PickControl
{
    partial class DebtorsReturnedTareInventoryCheckDetailsForm
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
            this.dgvCheckDetails = new System.Windows.Forms.DataGridView();
            this.rETTareInventoryInvCheckDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pickControl = new WMSOffice.Data.PickControl();
            this.rET_Tare_Inventory_Inv_Check_DetailsTableAdapter = new WMSOffice.Data.PickControlTableAdapters.RET_Tare_Inventory_Inv_Check_DetailsTableAdapter();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.sbRefreshData = new System.Windows.Forms.ToolStripButton();
            this.датаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.номерЗаданияDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.статусЗаданияDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.типЗаданияDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.документыДляРаботыDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.номерДокументаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.пользовательDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlButtons.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rETTareInventoryInvCheckDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).BeginInit();
            this.tsMain.SuspendLayout();
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
            this.pnlButtons.Location = new System.Drawing.Point(0, 328);
            this.pnlButtons.Size = new System.Drawing.Size(994, 43);
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContent.Controls.Add(this.dgvCheckDetails);
            this.pnlContent.Location = new System.Drawing.Point(0, 42);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(994, 280);
            this.pnlContent.TabIndex = 101;
            // 
            // dgvCheckDetails
            // 
            this.dgvCheckDetails.AllowUserToAddRows = false;
            this.dgvCheckDetails.AllowUserToDeleteRows = false;
            this.dgvCheckDetails.AllowUserToResizeRows = false;
            this.dgvCheckDetails.AutoGenerateColumns = false;
            this.dgvCheckDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCheckDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCheckDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.датаDataGridViewTextBoxColumn,
            this.номерЗаданияDataGridViewTextBoxColumn,
            this.статусЗаданияDataGridViewTextBoxColumn,
            this.типЗаданияDataGridViewTextBoxColumn,
            this.документыДляРаботыDataGridViewTextBoxColumn,
            this.номерДокументаDataGridViewTextBoxColumn,
            this.пользовательDataGridViewTextBoxColumn});
            this.dgvCheckDetails.DataSource = this.rETTareInventoryInvCheckDetailsBindingSource;
            this.dgvCheckDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCheckDetails.Location = new System.Drawing.Point(0, 0);
            this.dgvCheckDetails.MultiSelect = false;
            this.dgvCheckDetails.Name = "dgvCheckDetails";
            this.dgvCheckDetails.ReadOnly = true;
            this.dgvCheckDetails.RowHeadersVisible = false;
            this.dgvCheckDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCheckDetails.Size = new System.Drawing.Size(994, 280);
            this.dgvCheckDetails.TabIndex = 0;
            // 
            // rETTareInventoryInvCheckDetailsBindingSource
            // 
            this.rETTareInventoryInvCheckDetailsBindingSource.DataMember = "RET_Tare_Inventory_Inv_Check_Details";
            this.rETTareInventoryInvCheckDetailsBindingSource.DataSource = this.pickControl;
            // 
            // pickControl
            // 
            this.pickControl.DataSetName = "PickControl";
            this.pickControl.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rET_Tare_Inventory_Inv_Check_DetailsTableAdapter
            // 
            this.rET_Tare_Inventory_Inv_Check_DetailsTableAdapter.ClearBeforeFill = true;
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbRefreshData});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(994, 39);
            this.tsMain.TabIndex = 102;
            this.tsMain.Text = "toolStrip1";
            // 
            // sbRefreshData
            // 
            this.sbRefreshData.Image = global::WMSOffice.Properties.Resources.refresh;
            this.sbRefreshData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbRefreshData.Name = "sbRefreshData";
            this.sbRefreshData.Size = new System.Drawing.Size(97, 36);
            this.sbRefreshData.Text = "Обновить";
            this.sbRefreshData.Click += new System.EventHandler(this.sbRefreshData_Click);
            // 
            // датаDataGridViewTextBoxColumn
            // 
            this.датаDataGridViewTextBoxColumn.DataPropertyName = "Дата";
            this.датаDataGridViewTextBoxColumn.HeaderText = "Дата";
            this.датаDataGridViewTextBoxColumn.Name = "датаDataGridViewTextBoxColumn";
            this.датаDataGridViewTextBoxColumn.ReadOnly = true;
            this.датаDataGridViewTextBoxColumn.Width = 58;
            // 
            // номерЗаданияDataGridViewTextBoxColumn
            // 
            this.номерЗаданияDataGridViewTextBoxColumn.DataPropertyName = "Номер Задания";
            this.номерЗаданияDataGridViewTextBoxColumn.HeaderText = "Номер задания";
            this.номерЗаданияDataGridViewTextBoxColumn.Name = "номерЗаданияDataGridViewTextBoxColumn";
            this.номерЗаданияDataGridViewTextBoxColumn.ReadOnly = true;
            this.номерЗаданияDataGridViewTextBoxColumn.Width = 102;
            // 
            // статусЗаданияDataGridViewTextBoxColumn
            // 
            this.статусЗаданияDataGridViewTextBoxColumn.DataPropertyName = "Статус Задания";
            this.статусЗаданияDataGridViewTextBoxColumn.HeaderText = "Статус задания";
            this.статусЗаданияDataGridViewTextBoxColumn.Name = "статусЗаданияDataGridViewTextBoxColumn";
            this.статусЗаданияDataGridViewTextBoxColumn.ReadOnly = true;
            this.статусЗаданияDataGridViewTextBoxColumn.Width = 102;
            // 
            // типЗаданияDataGridViewTextBoxColumn
            // 
            this.типЗаданияDataGridViewTextBoxColumn.DataPropertyName = "Тип Задания";
            this.типЗаданияDataGridViewTextBoxColumn.HeaderText = "Тип задания";
            this.типЗаданияDataGridViewTextBoxColumn.Name = "типЗаданияDataGridViewTextBoxColumn";
            this.типЗаданияDataGridViewTextBoxColumn.ReadOnly = true;
            this.типЗаданияDataGridViewTextBoxColumn.Width = 88;
            // 
            // документыДляРаботыDataGridViewTextBoxColumn
            // 
            this.документыДляРаботыDataGridViewTextBoxColumn.DataPropertyName = "Документы для работы";
            this.документыДляРаботыDataGridViewTextBoxColumn.HeaderText = "Документы для работы";
            this.документыДляРаботыDataGridViewTextBoxColumn.Name = "документыДляРаботыDataGridViewTextBoxColumn";
            this.документыДляРаботыDataGridViewTextBoxColumn.ReadOnly = true;
            this.документыДляРаботыDataGridViewTextBoxColumn.Width = 106;
            // 
            // номерДокументаDataGridViewTextBoxColumn
            // 
            this.номерДокументаDataGridViewTextBoxColumn.DataPropertyName = "Номер Документа";
            this.номерДокументаDataGridViewTextBoxColumn.HeaderText = "Номер документа";
            this.номерДокументаDataGridViewTextBoxColumn.Name = "номерДокументаDataGridViewTextBoxColumn";
            this.номерДокументаDataGridViewTextBoxColumn.ReadOnly = true;
            this.номерДокументаDataGridViewTextBoxColumn.Width = 113;
            // 
            // пользовательDataGridViewTextBoxColumn
            // 
            this.пользовательDataGridViewTextBoxColumn.DataPropertyName = "Пользователь";
            this.пользовательDataGridViewTextBoxColumn.HeaderText = "Пользователь";
            this.пользовательDataGridViewTextBoxColumn.Name = "пользовательDataGridViewTextBoxColumn";
            this.пользовательDataGridViewTextBoxColumn.ReadOnly = true;
            this.пользовательDataGridViewTextBoxColumn.Width = 105;
            // 
            // DebtorsReturnedTareInventoryCheckDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 371);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.pnlContent);
            this.Name = "DebtorsReturnedTareInventoryCheckDetailsForm";
            this.Text = "Детали проверок по инвентаризации";
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.Controls.SetChildIndex(this.tsMain, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rETTareInventoryInvCheckDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).EndInit();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.DataGridView dgvCheckDetails;
        private System.Windows.Forms.BindingSource rETTareInventoryInvCheckDetailsBindingSource;
        private WMSOffice.Data.PickControl pickControl;
        private WMSOffice.Data.PickControlTableAdapters.RET_Tare_Inventory_Inv_Check_DetailsTableAdapter rET_Tare_Inventory_Inv_Check_DetailsTableAdapter;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton sbRefreshData;
        private System.Windows.Forms.DataGridViewTextBoxColumn датаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn номерЗаданияDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn статусЗаданияDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn типЗаданияDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn документыДляРаботыDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn номерДокументаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn пользовательDataGridViewTextBoxColumn;
    }
}