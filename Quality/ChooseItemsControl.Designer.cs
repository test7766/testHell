namespace WMSOffice.Dialogs.Quality
{
    partial class ChooseItemsControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmsItems = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miPasteExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.bsBlBlockItems = new System.Windows.Forms.BindingSource(this.components);
            this.quality = new WMSOffice.Data.Quality();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblBatchID = new System.Windows.Forms.Label();
            this.stbBatchID = new WMSOffice.Controls.SearchTextBox();
            this.lblVendorLot = new System.Windows.Forms.Label();
            this.stbVendorLot = new WMSOffice.Controls.SearchTextBox();
            this.lblItemName = new System.Windows.Forms.Label();
            this.lblItemId = new System.Windows.Forms.Label();
            this.stbItemID = new WMSOffice.Controls.SearchTextBox();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.clItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clVendorLot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clBatchID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsBlBlockItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsItems
            // 
            this.cmsItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miPasteExcel});
            this.cmsItems.Name = "cmsItems";
            this.cmsItems.Size = new System.Drawing.Size(167, 26);
            // 
            // miPasteExcel
            // 
            this.miPasteExcel.Image = global::WMSOffice.Properties.Resources.Excel;
            this.miPasteExcel.Name = "miPasteExcel";
            this.miPasteExcel.Size = new System.Drawing.Size(166, 22);
            this.miPasteExcel.Text = "Вставить из Excel";
            this.miPasteExcel.Click += new System.EventHandler(this.miPaste_Click);
            // 
            // bsBlBlockItems
            // 
            this.bsBlBlockItems.DataMember = "BL_BlockItems";
            this.bsBlBlockItems.DataSource = this.quality;
            // 
            // quality
            // 
            this.quality.DataSetName = "Quality";
            this.quality.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(646, 25);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblBatchID
            // 
            this.lblBatchID.AutoSize = true;
            this.lblBatchID.Location = new System.Drawing.Point(435, 9);
            this.lblBatchID.Name = "lblBatchID";
            this.lblBatchID.Size = new System.Drawing.Size(47, 13);
            this.lblBatchID.TabIndex = 19;
            this.lblBatchID.Text = "Партия:";
            // 
            // stbBatchID
            // 
            this.stbBatchID.Enabled = false;
            this.stbBatchID.Location = new System.Drawing.Point(438, 25);
            this.stbBatchID.Name = "stbBatchID";
            this.stbBatchID.Size = new System.Drawing.Size(161, 23);
            this.stbBatchID.TabIndex = 14;
            this.stbBatchID.UserID = ((long)(0));
            this.stbBatchID.Value = null;
            this.stbBatchID.ValueReferenceQuery = null;
            // 
            // lblVendorLot
            // 
            this.lblVendorLot.AutoSize = true;
            this.lblVendorLot.Location = new System.Drawing.Point(216, 9);
            this.lblVendorLot.Name = "lblVendorLot";
            this.lblVendorLot.Size = new System.Drawing.Size(41, 13);
            this.lblVendorLot.TabIndex = 18;
            this.lblVendorLot.Text = "Серия:";
            // 
            // stbVendorLot
            // 
            this.stbVendorLot.Enabled = false;
            this.stbVendorLot.Location = new System.Drawing.Point(219, 25);
            this.stbVendorLot.Name = "stbVendorLot";
            this.stbVendorLot.Size = new System.Drawing.Size(161, 23);
            this.stbVendorLot.TabIndex = 13;
            this.stbVendorLot.UserID = ((long)(0));
            this.stbVendorLot.Value = null;
            this.stbVendorLot.ValueReferenceQuery = null;
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Location = new System.Drawing.Point(3, 51);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(41, 13);
            this.lblItemName.TabIndex = 17;
            this.lblItemName.Text = "Товар:";
            // 
            // lblItemId
            // 
            this.lblItemId.AutoSize = true;
            this.lblItemId.Location = new System.Drawing.Point(-3, 9);
            this.lblItemId.Name = "lblItemId";
            this.lblItemId.Size = new System.Drawing.Size(41, 13);
            this.lblItemId.TabIndex = 15;
            this.lblItemId.Text = "Товар:";
            // 
            // stbItemID
            // 
            this.stbItemID.Location = new System.Drawing.Point(0, 25);
            this.stbItemID.Name = "stbItemID";
            this.stbItemID.Size = new System.Drawing.Size(161, 23);
            this.stbItemID.TabIndex = 12;
            this.stbItemID.UserID = ((long)(0));
            this.stbItemID.Value = null;
            this.stbItemID.ValueReferenceQuery = null;
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToResizeRows = false;
            this.dgvItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvItems.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clItemID,
            this.clVendorLot,
            this.clBatchID,
            this.clItemName,
            this.clResult});
            this.dgvItems.ContextMenuStrip = this.cmsItems;
            this.dgvItems.DataSource = this.bsBlBlockItems;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvItems.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvItems.Location = new System.Drawing.Point(0, 75);
            this.dgvItems.Name = "dgvItems";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItems.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(721, 335);
            this.dgvItems.TabIndex = 11;
            this.dgvItems.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvItems_RowValidating);
            this.dgvItems.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvItems_CellFormatting);
            this.dgvItems.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItems_RowValidated);
            this.dgvItems.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvItems_DataError);
            // 
            // clItemID
            // 
            this.clItemID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clItemID.DataPropertyName = "ItemID";
            this.clItemID.HeaderText = "ID товара";
            this.clItemID.Name = "clItemID";
            this.clItemID.Width = 81;
            // 
            // clVendorLot
            // 
            this.clVendorLot.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clVendorLot.DataPropertyName = "VendorLot";
            this.clVendorLot.HeaderText = "Серия";
            this.clVendorLot.Name = "clVendorLot";
            this.clVendorLot.Width = 63;
            // 
            // clBatchID
            // 
            this.clBatchID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clBatchID.DataPropertyName = "BatchID";
            this.clBatchID.HeaderText = "Партия";
            this.clBatchID.Name = "clBatchID";
            this.clBatchID.Width = 69;
            // 
            // clItemName
            // 
            this.clItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clItemName.DataPropertyName = "ItemName";
            this.clItemName.HeaderText = "Наименование товара";
            this.clItemName.Name = "clItemName";
            this.clItemName.ReadOnly = true;
            this.clItemName.Width = 133;
            // 
            // clResult
            // 
            this.clResult.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clResult.DataPropertyName = "Result";
            this.clResult.HeaderText = "Ошибка";
            this.clResult.Name = "clResult";
            this.clResult.ReadOnly = true;
            this.clResult.Width = 72;
            // 
            // ChooseItemsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblBatchID);
            this.Controls.Add(this.stbBatchID);
            this.Controls.Add(this.lblVendorLot);
            this.Controls.Add(this.stbVendorLot);
            this.Controls.Add(this.lblItemName);
            this.Controls.Add(this.lblItemId);
            this.Controls.Add(this.stbItemID);
            this.Controls.Add(this.dgvItems);
            this.Name = "ChooseItemsControl";
            this.Size = new System.Drawing.Size(724, 410);
            this.cmsItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsBlBlockItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmsItems;
        private System.Windows.Forms.ToolStripMenuItem miPasteExcel;
        private System.Windows.Forms.BindingSource bsBlBlockItems;
        private WMSOffice.Data.Quality quality;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblBatchID;
        private WMSOffice.Controls.SearchTextBox stbBatchID;
        private System.Windows.Forms.Label lblVendorLot;
        private WMSOffice.Controls.SearchTextBox stbVendorLot;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Label lblItemId;
        private WMSOffice.Controls.SearchTextBox stbItemID;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn clItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clVendorLot;
        private System.Windows.Forms.DataGridViewTextBoxColumn clBatchID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clResult;
    }
}
