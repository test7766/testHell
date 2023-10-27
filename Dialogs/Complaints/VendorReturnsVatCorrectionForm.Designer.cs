namespace WMSOffice.Dialogs.Complaints
{
    partial class VendorReturnsVatCorrectionForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.scContent = new System.Windows.Forms.SplitContainer();
            this.lblTotalDiffAmountCaption = new System.Windows.Forms.Label();
            this.lblTotalDiffAmount = new System.Windows.Forms.Label();
            this.dtpCorrectionDate = new System.Windows.Forms.DateTimePicker();
            this.lblCorrectionDate = new System.Windows.Forms.Label();
            this.tbVendorName = new System.Windows.Forms.TextBox();
            this.lblVendorID = new System.Windows.Forms.Label();
            this.stbVendorID = new WMSOffice.Controls.SearchTextBox();
            this.pnlItems = new System.Windows.Forms.Panel();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.vRNSLinesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.complaints = new WMSOffice.Data.Complaints();
            this.tsItemsFilter = new System.Windows.Forms.ToolStrip();
            this.lblFilter = new System.Windows.Forms.ToolStripLabel();
            this.vR_NS_LinesTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.VR_NS_LinesTableAdapter();
            this.isCheckedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.documnetNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documnetDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oldTaxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oldVatAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.newTaxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.newVatAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diffAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlButtons.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.scContent.Panel1.SuspendLayout();
            this.scContent.Panel2.SuspendLayout();
            this.scContent.SuspendLayout();
            this.pnlItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vRNSLinesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).BeginInit();
            this.tsItemsFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(13835, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(13925, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 378);
            this.pnlButtons.Size = new System.Drawing.Size(944, 43);
            this.pnlButtons.TabIndex = 1;
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContent.Controls.Add(this.scContent);
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(944, 372);
            this.pnlContent.TabIndex = 0;
            // 
            // scContent
            // 
            this.scContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scContent.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scContent.IsSplitterFixed = true;
            this.scContent.Location = new System.Drawing.Point(0, 0);
            this.scContent.Name = "scContent";
            this.scContent.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scContent.Panel1
            // 
            this.scContent.Panel1.Controls.Add(this.lblTotalDiffAmountCaption);
            this.scContent.Panel1.Controls.Add(this.lblTotalDiffAmount);
            this.scContent.Panel1.Controls.Add(this.dtpCorrectionDate);
            this.scContent.Panel1.Controls.Add(this.lblCorrectionDate);
            this.scContent.Panel1.Controls.Add(this.tbVendorName);
            this.scContent.Panel1.Controls.Add(this.lblVendorID);
            this.scContent.Panel1.Controls.Add(this.stbVendorID);
            // 
            // scContent.Panel2
            // 
            this.scContent.Panel2.Controls.Add(this.pnlItems);
            this.scContent.Size = new System.Drawing.Size(944, 372);
            this.scContent.SplitterDistance = 80;
            this.scContent.TabIndex = 0;
            // 
            // lblTotalDiffAmountCaption
            // 
            this.lblTotalDiffAmountCaption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalDiffAmountCaption.AutoSize = true;
            this.lblTotalDiffAmountCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTotalDiffAmountCaption.Location = new System.Drawing.Point(674, 53);
            this.lblTotalDiffAmountCaption.Name = "lblTotalDiffAmountCaption";
            this.lblTotalDiffAmountCaption.Size = new System.Drawing.Size(152, 13);
            this.lblTotalDiffAmountCaption.TabIndex = 5;
            this.lblTotalDiffAmountCaption.Text = "Σ Разница сумм с НДС, грн.";
            // 
            // lblTotalDiffAmount
            // 
            this.lblTotalDiffAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalDiffAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalDiffAmount.Location = new System.Drawing.Point(832, 49);
            this.lblTotalDiffAmount.Name = "lblTotalDiffAmount";
            this.lblTotalDiffAmount.Size = new System.Drawing.Size(100, 20);
            this.lblTotalDiffAmount.TabIndex = 6;
            this.lblTotalDiffAmount.Text = "0.00";
            this.lblTotalDiffAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpCorrectionDate
            // 
            this.dtpCorrectionDate.CustomFormat = "dd.MM.yyyy";
            this.dtpCorrectionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCorrectionDate.Location = new System.Drawing.Point(83, 49);
            this.dtpCorrectionDate.Name = "dtpCorrectionDate";
            this.dtpCorrectionDate.Size = new System.Drawing.Size(100, 20);
            this.dtpCorrectionDate.TabIndex = 4;
            // 
            // lblCorrectionDate
            // 
            this.lblCorrectionDate.AutoSize = true;
            this.lblCorrectionDate.Location = new System.Drawing.Point(12, 53);
            this.lblCorrectionDate.Name = "lblCorrectionDate";
            this.lblCorrectionDate.Size = new System.Drawing.Size(50, 13);
            this.lblCorrectionDate.TabIndex = 3;
            this.lblCorrectionDate.Text = "Дата РК";
            // 
            // tbVendorName
            // 
            this.tbVendorName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbVendorName.BackColor = System.Drawing.SystemColors.Window;
            this.tbVendorName.Location = new System.Drawing.Point(189, 11);
            this.tbVendorName.Name = "tbVendorName";
            this.tbVendorName.ReadOnly = true;
            this.tbVendorName.Size = new System.Drawing.Size(743, 20);
            this.tbVendorName.TabIndex = 2;
            // 
            // lblVendorID
            // 
            this.lblVendorID.AutoSize = true;
            this.lblVendorID.Location = new System.Drawing.Point(12, 15);
            this.lblVendorID.Name = "lblVendorID";
            this.lblVendorID.Size = new System.Drawing.Size(65, 13);
            this.lblVendorID.TabIndex = 0;
            this.lblVendorID.Text = "Поставщик";
            // 
            // stbVendorID
            // 
            this.stbVendorID.Location = new System.Drawing.Point(83, 11);
            this.stbVendorID.Name = "stbVendorID";
            this.stbVendorID.ReadOnly = false;
            this.stbVendorID.Size = new System.Drawing.Size(100, 20);
            this.stbVendorID.TabIndex = 1;
            this.stbVendorID.UserID = ((long)(0));
            this.stbVendorID.Value = null;
            this.stbVendorID.ValueReferenceQuery = null;
            // 
            // pnlItems
            // 
            this.pnlItems.Controls.Add(this.dgvItems);
            this.pnlItems.Controls.Add(this.tsItemsFilter);
            this.pnlItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlItems.Location = new System.Drawing.Point(0, 0);
            this.pnlItems.Name = "pnlItems";
            this.pnlItems.Size = new System.Drawing.Size(944, 288);
            this.pnlItems.TabIndex = 0;
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AllowUserToResizeRows = false;
            this.dgvItems.AutoGenerateColumns = false;
            this.dgvItems.ColumnHeadersHeight = 35;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.isCheckedDataGridViewCheckBoxColumn,
            this.documnetNumberDataGridViewTextBoxColumn,
            this.documnetDateDataGridViewTextBoxColumn,
            this.orderNumberDataGridViewTextBoxColumn,
            this.orderTypeDataGridViewTextBoxColumn,
            this.itemIDDataGridViewTextBoxColumn,
            this.itemNameDataGridViewTextBoxColumn,
            this.lotNumberDataGridViewTextBoxColumn,
            this.qtyDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.oldTaxDataGridViewTextBoxColumn,
            this.oldVatAmountDataGridViewTextBoxColumn,
            this.newTaxDataGridViewTextBoxColumn,
            this.newVatAmountDataGridViewTextBoxColumn,
            this.diffAmountDataGridViewTextBoxColumn});
            this.dgvItems.DataSource = this.vRNSLinesBindingSource;
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItems.Location = new System.Drawing.Point(0, 25);
            this.dgvItems.MultiSelect = false;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(944, 263);
            this.dgvItems.TabIndex = 1;
            this.dgvItems.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItems_CellValueChanged);
            this.dgvItems.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvItems_CellFormatting);
            this.dgvItems.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvItems_CurrentCellDirtyStateChanged);
            this.dgvItems.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvItems_DataError);
            // 
            // vRNSLinesBindingSource
            // 
            this.vRNSLinesBindingSource.DataMember = "VR_NS_Lines";
            this.vRNSLinesBindingSource.DataSource = this.complaints;
            // 
            // complaints
            // 
            this.complaints.DataSetName = "Complaints";
            this.complaints.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tsItemsFilter
            // 
            this.tsItemsFilter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblFilter});
            this.tsItemsFilter.Location = new System.Drawing.Point(0, 0);
            this.tsItemsFilter.Name = "tsItemsFilter";
            this.tsItemsFilter.Size = new System.Drawing.Size(944, 25);
            this.tsItemsFilter.TabIndex = 0;
            this.tsItemsFilter.Text = "toolStrip1";
            // 
            // lblFilter
            // 
            this.lblFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFilter.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(57, 22);
            this.lblFilter.Text = "Фильтр :";
            // 
            // vR_NS_LinesTableAdapter
            // 
            this.vR_NS_LinesTableAdapter.ClearBeforeFill = true;
            // 
            // isCheckedDataGridViewCheckBoxColumn
            // 
            this.isCheckedDataGridViewCheckBoxColumn.DataPropertyName = "IsChecked";
            this.isCheckedDataGridViewCheckBoxColumn.Frozen = true;
            this.isCheckedDataGridViewCheckBoxColumn.HeaderText = "Отм.";
            this.isCheckedDataGridViewCheckBoxColumn.Name = "isCheckedDataGridViewCheckBoxColumn";
            this.isCheckedDataGridViewCheckBoxColumn.Width = 35;
            // 
            // documnetNumberDataGridViewTextBoxColumn
            // 
            this.documnetNumberDataGridViewTextBoxColumn.DataPropertyName = "DocumnetNumber";
            this.documnetNumberDataGridViewTextBoxColumn.Frozen = true;
            this.documnetNumberDataGridViewTextBoxColumn.HeaderText = "Номер накл.";
            this.documnetNumberDataGridViewTextBoxColumn.Name = "documnetNumberDataGridViewTextBoxColumn";
            this.documnetNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.documnetNumberDataGridViewTextBoxColumn.Width = 80;
            // 
            // documnetDateDataGridViewTextBoxColumn
            // 
            this.documnetDateDataGridViewTextBoxColumn.DataPropertyName = "DocumnetDate";
            this.documnetDateDataGridViewTextBoxColumn.Frozen = true;
            this.documnetDateDataGridViewTextBoxColumn.HeaderText = "Дата накл.";
            this.documnetDateDataGridViewTextBoxColumn.Name = "documnetDateDataGridViewTextBoxColumn";
            this.documnetDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.documnetDateDataGridViewTextBoxColumn.Width = 65;
            // 
            // orderNumberDataGridViewTextBoxColumn
            // 
            this.orderNumberDataGridViewTextBoxColumn.DataPropertyName = "OrderNumber";
            this.orderNumberDataGridViewTextBoxColumn.Frozen = true;
            this.orderNumberDataGridViewTextBoxColumn.HeaderText = "Номер\nЗЗ";
            this.orderNumberDataGridViewTextBoxColumn.Name = "orderNumberDataGridViewTextBoxColumn";
            this.orderNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.orderNumberDataGridViewTextBoxColumn.Width = 65;
            // 
            // orderTypeDataGridViewTextBoxColumn
            // 
            this.orderTypeDataGridViewTextBoxColumn.DataPropertyName = "OrderType";
            this.orderTypeDataGridViewTextBoxColumn.Frozen = true;
            this.orderTypeDataGridViewTextBoxColumn.HeaderText = "Тип ЗЗ";
            this.orderTypeDataGridViewTextBoxColumn.Name = "orderTypeDataGridViewTextBoxColumn";
            this.orderTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.orderTypeDataGridViewTextBoxColumn.Width = 35;
            // 
            // itemIDDataGridViewTextBoxColumn
            // 
            this.itemIDDataGridViewTextBoxColumn.DataPropertyName = "ItemID";
            this.itemIDDataGridViewTextBoxColumn.Frozen = true;
            this.itemIDDataGridViewTextBoxColumn.HeaderText = "Код";
            this.itemIDDataGridViewTextBoxColumn.Name = "itemIDDataGridViewTextBoxColumn";
            this.itemIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemIDDataGridViewTextBoxColumn.ToolTipText = "Код товара";
            this.itemIDDataGridViewTextBoxColumn.Width = 45;
            // 
            // itemNameDataGridViewTextBoxColumn
            // 
            this.itemNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemNameDataGridViewTextBoxColumn.DataPropertyName = "ItemName";
            this.itemNameDataGridViewTextBoxColumn.HeaderText = "Наименование товара";
            this.itemNameDataGridViewTextBoxColumn.Name = "itemNameDataGridViewTextBoxColumn";
            this.itemNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemNameDataGridViewTextBoxColumn.Width = 133;
            // 
            // lotNumberDataGridViewTextBoxColumn
            // 
            this.lotNumberDataGridViewTextBoxColumn.DataPropertyName = "LotNumber";
            this.lotNumberDataGridViewTextBoxColumn.HeaderText = "Партия";
            this.lotNumberDataGridViewTextBoxColumn.Name = "lotNumberDataGridViewTextBoxColumn";
            this.lotNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.lotNumberDataGridViewTextBoxColumn.Width = 85;
            // 
            // qtyDataGridViewTextBoxColumn
            // 
            this.qtyDataGridViewTextBoxColumn.DataPropertyName = "Qty";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            this.qtyDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.qtyDataGridViewTextBoxColumn.HeaderText = "К-во в приходе";
            this.qtyDataGridViewTextBoxColumn.Name = "qtyDataGridViewTextBoxColumn";
            this.qtyDataGridViewTextBoxColumn.Width = 60;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.priceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.priceDataGridViewTextBoxColumn.HeaderText = "Цена, грн.";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.Width = 65;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.amountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.amountDataGridViewTextBoxColumn.HeaderText = "Сумма, грн.";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.ReadOnly = true;
            this.amountDataGridViewTextBoxColumn.Width = 95;
            // 
            // oldTaxDataGridViewTextBoxColumn
            // 
            this.oldTaxDataGridViewTextBoxColumn.DataPropertyName = "OldTax";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            this.oldTaxDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.oldTaxDataGridViewTextBoxColumn.HeaderText = "Ставка НДС в приходе, %";
            this.oldTaxDataGridViewTextBoxColumn.Name = "oldTaxDataGridViewTextBoxColumn";
            this.oldTaxDataGridViewTextBoxColumn.ReadOnly = true;
            this.oldTaxDataGridViewTextBoxColumn.Width = 80;
            // 
            // oldVatAmountDataGridViewTextBoxColumn
            // 
            this.oldVatAmountDataGridViewTextBoxColumn.DataPropertyName = "OldVatAmount";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.oldVatAmountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.oldVatAmountDataGridViewTextBoxColumn.HeaderText = "Сумма прихода с НДС, грн.";
            this.oldVatAmountDataGridViewTextBoxColumn.Name = "oldVatAmountDataGridViewTextBoxColumn";
            this.oldVatAmountDataGridViewTextBoxColumn.ReadOnly = true;
            this.oldVatAmountDataGridViewTextBoxColumn.Width = 95;
            // 
            // newTaxDataGridViewTextBoxColumn
            // 
            this.newTaxDataGridViewTextBoxColumn.DataPropertyName = "NewTax";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            this.newTaxDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.newTaxDataGridViewTextBoxColumn.HeaderText = "Ставка НДС после корректировки, %";
            this.newTaxDataGridViewTextBoxColumn.Name = "newTaxDataGridViewTextBoxColumn";
            this.newTaxDataGridViewTextBoxColumn.ReadOnly = true;
            this.newTaxDataGridViewTextBoxColumn.Width = 110;
            // 
            // newVatAmountDataGridViewTextBoxColumn
            // 
            this.newVatAmountDataGridViewTextBoxColumn.DataPropertyName = "NewVatAmount";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            this.newVatAmountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.newVatAmountDataGridViewTextBoxColumn.HeaderText = "Сумма с НДС после корректировки, грн.";
            this.newVatAmountDataGridViewTextBoxColumn.Name = "newVatAmountDataGridViewTextBoxColumn";
            this.newVatAmountDataGridViewTextBoxColumn.ReadOnly = true;
            this.newVatAmountDataGridViewTextBoxColumn.Width = 120;
            // 
            // diffAmountDataGridViewTextBoxColumn
            // 
            this.diffAmountDataGridViewTextBoxColumn.DataPropertyName = "DiffAmount";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            this.diffAmountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.diffAmountDataGridViewTextBoxColumn.HeaderText = "Разница сумм с НДС, грн.";
            this.diffAmountDataGridViewTextBoxColumn.Name = "diffAmountDataGridViewTextBoxColumn";
            this.diffAmountDataGridViewTextBoxColumn.Width = 90;
            // 
            // VendorReturnsVatCorrectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 421);
            this.Controls.Add(this.pnlContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "VendorReturnsVatCorrectionForm";
            this.Text = "Параметры акта корректировки НДС";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VendorReturnsVatCorrectionForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.scContent.Panel1.ResumeLayout(false);
            this.scContent.Panel1.PerformLayout();
            this.scContent.Panel2.ResumeLayout(false);
            this.scContent.ResumeLayout(false);
            this.pnlItems.ResumeLayout(false);
            this.pnlItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vRNSLinesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).EndInit();
            this.tsItemsFilter.ResumeLayout(false);
            this.tsItemsFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.SplitContainer scContent;
        private System.Windows.Forms.TextBox tbVendorName;
        private System.Windows.Forms.Label lblVendorID;
        private WMSOffice.Controls.SearchTextBox stbVendorID;
        private System.Windows.Forms.DateTimePicker dtpCorrectionDate;
        private System.Windows.Forms.Label lblCorrectionDate;
        private System.Windows.Forms.Panel pnlItems;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.ToolStrip tsItemsFilter;
        private System.Windows.Forms.ToolStripLabel lblFilter;
        private System.Windows.Forms.BindingSource vRNSLinesBindingSource;
        private WMSOffice.Data.Complaints complaints;
        private WMSOffice.Data.ComplaintsTableAdapters.VR_NS_LinesTableAdapter vR_NS_LinesTableAdapter;
        private System.Windows.Forms.Label lblTotalDiffAmount;
        private System.Windows.Forms.Label lblTotalDiffAmountCaption;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isCheckedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn documnetNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn documnetDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oldTaxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oldVatAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn newTaxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn newVatAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diffAmountDataGridViewTextBoxColumn;
    }
}