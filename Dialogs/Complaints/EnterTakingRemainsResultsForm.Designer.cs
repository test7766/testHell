namespace WMSOffice.Dialogs.Complaints
{
    partial class EnterTakingRemainsResultsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvTakingRemainsRequests = new System.Windows.Forms.DataGridView();
            this.takingRemainsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.complaints = new WMSOffice.Data.Complaints();
            this.takingRemainsTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.TakingRemainsTableAdapter();
            this.colCheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.takingIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateCreatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorLotDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityByTakingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTakingRemainsRequests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.takingRemainsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // dgvTakingRemainsRequests
            // 
            this.dgvTakingRemainsRequests.AllowUserToAddRows = false;
            this.dgvTakingRemainsRequests.AllowUserToDeleteRows = false;
            this.dgvTakingRemainsRequests.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgvTakingRemainsRequests.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTakingRemainsRequests.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTakingRemainsRequests.AutoGenerateColumns = false;
            this.dgvTakingRemainsRequests.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTakingRemainsRequests.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTakingRemainsRequests.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTakingRemainsRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTakingRemainsRequests.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheckBox,
            this.takingIDDataGridViewTextBoxColumn,
            this.dateCreatedDataGridViewTextBoxColumn,
            this.itemIDDataGridViewTextBoxColumn,
            this.Item_Name,
            this.vendorLotDataGridViewTextBoxColumn,
            this.quantityByTakingDataGridViewTextBoxColumn});
            this.dgvTakingRemainsRequests.DataSource = this.takingRemainsBindingSource;
            this.dgvTakingRemainsRequests.Location = new System.Drawing.Point(12, 12);
            this.dgvTakingRemainsRequests.Name = "dgvTakingRemainsRequests";
            this.dgvTakingRemainsRequests.RowHeadersVisible = false;
            this.dgvTakingRemainsRequests.RowTemplate.Height = 21;
            this.dgvTakingRemainsRequests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTakingRemainsRequests.ShowEditingIcon = false;
            this.dgvTakingRemainsRequests.Size = new System.Drawing.Size(658, 241);
            this.dgvTakingRemainsRequests.TabIndex = 101;
            // 
            // takingRemainsBindingSource
            // 
            this.takingRemainsBindingSource.DataMember = "TakingRemains";
            this.takingRemainsBindingSource.DataSource = this.complaints;
            // 
            // complaints
            // 
            this.complaints.DataSetName = "Complaints";
            this.complaints.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // takingRemainsTableAdapter
            // 
            this.takingRemainsTableAdapter.ClearBeforeFill = true;
            // 
            // colCheckBox
            // 
            this.colCheckBox.DataPropertyName = "IsChecked";
            this.colCheckBox.HeaderText = "Отм.";
            this.colCheckBox.Name = "colCheckBox";
            this.colCheckBox.ToolTipText = "Отм.";
            this.colCheckBox.Width = 45;
            // 
            // takingIDDataGridViewTextBoxColumn
            // 
            this.takingIDDataGridViewTextBoxColumn.DataPropertyName = "Taking_ID";
            this.takingIDDataGridViewTextBoxColumn.HeaderText = "Код запроса";
            this.takingIDDataGridViewTextBoxColumn.Name = "takingIDDataGridViewTextBoxColumn";
            this.takingIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.takingIDDataGridViewTextBoxColumn.Width = 60;
            // 
            // dateCreatedDataGridViewTextBoxColumn
            // 
            this.dateCreatedDataGridViewTextBoxColumn.DataPropertyName = "Date_Created";
            dataGridViewCellStyle6.Format = "g";
            dataGridViewCellStyle6.NullValue = null;
            this.dateCreatedDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.dateCreatedDataGridViewTextBoxColumn.HeaderText = "Время запроса";
            this.dateCreatedDataGridViewTextBoxColumn.Name = "dateCreatedDataGridViewTextBoxColumn";
            this.dateCreatedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // itemIDDataGridViewTextBoxColumn
            // 
            this.itemIDDataGridViewTextBoxColumn.DataPropertyName = "Item_ID";
            this.itemIDDataGridViewTextBoxColumn.HeaderText = "Код товара";
            this.itemIDDataGridViewTextBoxColumn.Name = "itemIDDataGridViewTextBoxColumn";
            this.itemIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemIDDataGridViewTextBoxColumn.Width = 60;
            // 
            // Item_Name
            // 
            this.Item_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Item_Name.DataPropertyName = "Item_Name";
            this.Item_Name.HeaderText = "Название товара";
            this.Item_Name.Name = "Item_Name";
            this.Item_Name.ReadOnly = true;
            // 
            // vendorLotDataGridViewTextBoxColumn
            // 
            this.vendorLotDataGridViewTextBoxColumn.DataPropertyName = "Vendor_Lot";
            this.vendorLotDataGridViewTextBoxColumn.HeaderText = "Серия";
            this.vendorLotDataGridViewTextBoxColumn.Name = "vendorLotDataGridViewTextBoxColumn";
            this.vendorLotDataGridViewTextBoxColumn.ReadOnly = true;
            this.vendorLotDataGridViewTextBoxColumn.Width = 90;
            // 
            // quantityByTakingDataGridViewTextBoxColumn
            // 
            this.quantityByTakingDataGridViewTextBoxColumn.DataPropertyName = "Quantity_By_Taking";
            this.quantityByTakingDataGridViewTextBoxColumn.HeaderText = "Результат снятия остатков, уп.";
            this.quantityByTakingDataGridViewTextBoxColumn.Name = "quantityByTakingDataGridViewTextBoxColumn";
            this.quantityByTakingDataGridViewTextBoxColumn.Width = 130;
            // 
            // EnterTakingRemainsResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 302);
            this.Controls.Add(this.dgvTakingRemainsRequests);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "EnterTakingRemainsResultsForm";
            this.Text = "Ввод результатов снятия остатков";
            this.Controls.SetChildIndex(this.dgvTakingRemainsRequests, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTakingRemainsRequests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.takingRemainsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTakingRemainsRequests;
        private System.Windows.Forms.BindingSource takingRemainsBindingSource;
        private WMSOffice.Data.Complaints complaints;
        private WMSOffice.Data.ComplaintsTableAdapters.TakingRemainsTableAdapter takingRemainsTableAdapter;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn takingIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateCreatedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorLotDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityByTakingDataGridViewTextBoxColumn;

    }
}