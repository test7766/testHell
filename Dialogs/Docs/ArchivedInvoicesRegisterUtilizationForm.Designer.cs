namespace WMSOffice.Dialogs.Docs
{
    partial class ArchivedInvoicesRegisterUtilizationForm
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
            this.lblYearFrom = new System.Windows.Forms.Label();
            this.nudYearFrom = new System.Windows.Forms.NumericUpDown();
            this.nudYearTo = new System.Windows.Forms.NumericUpDown();
            this.lblYearTo = new System.Windows.Forms.Label();
            this.tbInvoiceNumber = new System.Windows.Forms.TextBox();
            this.lbllInvoiceNumber = new System.Windows.Forms.Label();
            this.tbInvoiceType = new System.Windows.Forms.TextBox();
            this.stbInvoiceType = new WMSOffice.Controls.SearchTextBox();
            this.lblInvoiceType = new System.Windows.Forms.Label();
            this.tbDebtor = new System.Windows.Forms.TextBox();
            this.stbDebtor = new WMSOffice.Controls.SearchTextBox();
            this.lblDebtor = new System.Windows.Forms.Label();
            this.dgvInvoices = new System.Windows.Forms.DataGridView();
            this.isCheckedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.invoiceNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoiceTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoiceDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debtorIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debtorNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deliveryIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deliveryNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rGRegisterDocsForUtilizationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wH = new WMSOffice.Data.WH();
            this.btnSearchInvoices = new System.Windows.Forms.Button();
            this.rG_Register_Docs_For_UtilizationTableAdapter = new WMSOffice.Data.WHTableAdapters.RG_Register_Docs_For_UtilizationTableAdapter();
            this.scContent = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudYearFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYearTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGRegisterDocsForUtilizationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).BeginInit();
            this.scContent.Panel1.SuspendLayout();
            this.scContent.Panel2.SuspendLayout();
            this.scContent.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(3325, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(3415, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 382);
            this.pnlButtons.Size = new System.Drawing.Size(744, 43);
            this.pnlButtons.TabIndex = 1;
            // 
            // lblYearFrom
            // 
            this.lblYearFrom.AutoSize = true;
            this.lblYearFrom.Location = new System.Drawing.Point(61, 12);
            this.lblYearFrom.Name = "lblYearFrom";
            this.lblYearFrom.Size = new System.Drawing.Size(34, 13);
            this.lblYearFrom.TabIndex = 0;
            this.lblYearFrom.Text = "Рік з:";
            // 
            // nudYearFrom
            // 
            this.nudYearFrom.Location = new System.Drawing.Point(101, 8);
            this.nudYearFrom.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudYearFrom.Minimum = new decimal(new int[] {
            2023,
            0,
            0,
            0});
            this.nudYearFrom.Name = "nudYearFrom";
            this.nudYearFrom.Size = new System.Drawing.Size(100, 20);
            this.nudYearFrom.TabIndex = 1;
            this.nudYearFrom.Value = new decimal(new int[] {
            2023,
            0,
            0,
            0});
            // 
            // nudYearTo
            // 
            this.nudYearTo.Location = new System.Drawing.Point(250, 8);
            this.nudYearTo.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudYearTo.Minimum = new decimal(new int[] {
            2023,
            0,
            0,
            0});
            this.nudYearTo.Name = "nudYearTo";
            this.nudYearTo.Size = new System.Drawing.Size(100, 20);
            this.nudYearTo.TabIndex = 3;
            this.nudYearTo.Value = new decimal(new int[] {
            2023,
            0,
            0,
            0});
            // 
            // lblYearTo
            // 
            this.lblYearTo.AutoSize = true;
            this.lblYearTo.Location = new System.Drawing.Point(204, 12);
            this.lblYearTo.Name = "lblYearTo";
            this.lblYearTo.Size = new System.Drawing.Size(40, 13);
            this.lblYearTo.TabIndex = 2;
            this.lblYearTo.Text = "Рік по:";
            // 
            // tbInvoiceNumber
            // 
            this.tbInvoiceNumber.BackColor = System.Drawing.SystemColors.Window;
            this.tbInvoiceNumber.Location = new System.Drawing.Point(101, 66);
            this.tbInvoiceNumber.Name = "tbInvoiceNumber";
            this.tbInvoiceNumber.Size = new System.Drawing.Size(100, 20);
            this.tbInvoiceNumber.TabIndex = 7;
            this.tbInvoiceNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbInvoiceNumber_KeyDown);
            // 
            // lbllInvoiceNumber
            // 
            this.lbllInvoiceNumber.AutoSize = true;
            this.lbllInvoiceNumber.Location = new System.Drawing.Point(20, 70);
            this.lbllInvoiceNumber.Name = "lbllInvoiceNumber";
            this.lbllInvoiceNumber.Size = new System.Drawing.Size(75, 13);
            this.lbllInvoiceNumber.TabIndex = 6;
            this.lbllInvoiceNumber.Text = "№ накладної:";
            // 
            // tbInvoiceType
            // 
            this.tbInvoiceType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbInvoiceType.BackColor = System.Drawing.SystemColors.Window;
            this.tbInvoiceType.Location = new System.Drawing.Point(207, 37);
            this.tbInvoiceType.Name = "tbInvoiceType";
            this.tbInvoiceType.ReadOnly = true;
            this.tbInvoiceType.Size = new System.Drawing.Size(525, 20);
            this.tbInvoiceType.TabIndex = 5;
            this.tbInvoiceType.TabStop = false;
            // 
            // stbInvoiceType
            // 
            this.stbInvoiceType.Location = new System.Drawing.Point(101, 37);
            this.stbInvoiceType.Name = "stbInvoiceType";
            this.stbInvoiceType.NavigateByValue = false;
            this.stbInvoiceType.ReadOnly = false;
            this.stbInvoiceType.Size = new System.Drawing.Size(100, 20);
            this.stbInvoiceType.TabIndex = 4;
            this.stbInvoiceType.UserID = ((long)(0));
            this.stbInvoiceType.Value = null;
            this.stbInvoiceType.ValueReferenceQuery = null;
            // 
            // lblInvoiceType
            // 
            this.lblInvoiceType.AutoSize = true;
            this.lblInvoiceType.Location = new System.Drawing.Point(12, 41);
            this.lblInvoiceType.Name = "lblInvoiceType";
            this.lblInvoiceType.Size = new System.Drawing.Size(83, 13);
            this.lblInvoiceType.TabIndex = 3;
            this.lblInvoiceType.Text = "Тип накладної:";
            // 
            // tbDebtor
            // 
            this.tbDebtor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDebtor.BackColor = System.Drawing.SystemColors.Window;
            this.tbDebtor.Location = new System.Drawing.Point(207, 8);
            this.tbDebtor.Name = "tbDebtor";
            this.tbDebtor.ReadOnly = true;
            this.tbDebtor.Size = new System.Drawing.Size(525, 20);
            this.tbDebtor.TabIndex = 2;
            this.tbDebtor.TabStop = false;
            // 
            // stbDebtor
            // 
            this.stbDebtor.Location = new System.Drawing.Point(101, 8);
            this.stbDebtor.Name = "stbDebtor";
            this.stbDebtor.NavigateByValue = false;
            this.stbDebtor.ReadOnly = false;
            this.stbDebtor.Size = new System.Drawing.Size(100, 20);
            this.stbDebtor.TabIndex = 1;
            this.stbDebtor.UserID = ((long)(0));
            this.stbDebtor.Value = null;
            this.stbDebtor.ValueReferenceQuery = null;
            // 
            // lblDebtor
            // 
            this.lblDebtor.AutoSize = true;
            this.lblDebtor.Location = new System.Drawing.Point(45, 12);
            this.lblDebtor.Name = "lblDebtor";
            this.lblDebtor.Size = new System.Drawing.Size(50, 13);
            this.lblDebtor.TabIndex = 0;
            this.lblDebtor.Text = "Дебітор:";
            // 
            // dgvInvoices
            // 
            this.dgvInvoices.AllowUserToAddRows = false;
            this.dgvInvoices.AllowUserToDeleteRows = false;
            this.dgvInvoices.AllowUserToResizeColumns = false;
            this.dgvInvoices.AllowUserToResizeRows = false;
            this.dgvInvoices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInvoices.AutoGenerateColumns = false;
            this.dgvInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvInvoices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.isCheckedDataGridViewCheckBoxColumn,
            this.invoiceNumberDataGridViewTextBoxColumn,
            this.invoiceTypeDataGridViewTextBoxColumn,
            this.invoiceDateDataGridViewTextBoxColumn,
            this.debtorIDDataGridViewTextBoxColumn,
            this.debtorNameDataGridViewTextBoxColumn,
            this.deliveryIDDataGridViewTextBoxColumn,
            this.deliveryNameDataGridViewTextBoxColumn});
            this.dgvInvoices.DataSource = this.rGRegisterDocsForUtilizationBindingSource;
            this.dgvInvoices.Location = new System.Drawing.Point(3, 94);
            this.dgvInvoices.MultiSelect = false;
            this.dgvInvoices.Name = "dgvInvoices";
            this.dgvInvoices.RowHeadersVisible = false;
            this.dgvInvoices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInvoices.Size = new System.Drawing.Size(741, 191);
            this.dgvInvoices.TabIndex = 9;
            this.dgvInvoices.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvInvoices_CellFormatting);
            this.dgvInvoices.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvInvoices_CurrentCellDirtyStateChanged);
            this.dgvInvoices.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvInvoices_DataBindingComplete);
            // 
            // isCheckedDataGridViewCheckBoxColumn
            // 
            this.isCheckedDataGridViewCheckBoxColumn.DataPropertyName = "IsChecked";
            this.isCheckedDataGridViewCheckBoxColumn.HeaderText = "Обр.";
            this.isCheckedDataGridViewCheckBoxColumn.Name = "isCheckedDataGridViewCheckBoxColumn";
            this.isCheckedDataGridViewCheckBoxColumn.Width = 35;
            // 
            // invoiceNumberDataGridViewTextBoxColumn
            // 
            this.invoiceNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.invoiceNumberDataGridViewTextBoxColumn.DataPropertyName = "InvoiceNumber";
            this.invoiceNumberDataGridViewTextBoxColumn.HeaderText = "№ накладної";
            this.invoiceNumberDataGridViewTextBoxColumn.Name = "invoiceNumberDataGridViewTextBoxColumn";
            this.invoiceNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.invoiceNumberDataGridViewTextBoxColumn.Width = 97;
            // 
            // invoiceTypeDataGridViewTextBoxColumn
            // 
            this.invoiceTypeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.invoiceTypeDataGridViewTextBoxColumn.DataPropertyName = "InvoiceType";
            this.invoiceTypeDataGridViewTextBoxColumn.HeaderText = "Тип накладної";
            this.invoiceTypeDataGridViewTextBoxColumn.Name = "invoiceTypeDataGridViewTextBoxColumn";
            this.invoiceTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.invoiceTypeDataGridViewTextBoxColumn.Width = 105;
            // 
            // invoiceDateDataGridViewTextBoxColumn
            // 
            this.invoiceDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.invoiceDateDataGridViewTextBoxColumn.DataPropertyName = "InvoiceDate";
            this.invoiceDateDataGridViewTextBoxColumn.HeaderText = "Дата  накладної";
            this.invoiceDateDataGridViewTextBoxColumn.Name = "invoiceDateDataGridViewTextBoxColumn";
            this.invoiceDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.invoiceDateDataGridViewTextBoxColumn.Width = 115;
            // 
            // debtorIDDataGridViewTextBoxColumn
            // 
            this.debtorIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.debtorIDDataGridViewTextBoxColumn.DataPropertyName = "DebtorID";
            this.debtorIDDataGridViewTextBoxColumn.HeaderText = "Код дебітора";
            this.debtorIDDataGridViewTextBoxColumn.Name = "debtorIDDataGridViewTextBoxColumn";
            this.debtorIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.debtorIDDataGridViewTextBoxColumn.Width = 97;
            // 
            // debtorNameDataGridViewTextBoxColumn
            // 
            this.debtorNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.debtorNameDataGridViewTextBoxColumn.DataPropertyName = "DebtorName";
            this.debtorNameDataGridViewTextBoxColumn.HeaderText = "Назва дебітора";
            this.debtorNameDataGridViewTextBoxColumn.Name = "debtorNameDataGridViewTextBoxColumn";
            this.debtorNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.debtorNameDataGridViewTextBoxColumn.Width = 110;
            // 
            // deliveryIDDataGridViewTextBoxColumn
            // 
            this.deliveryIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.deliveryIDDataGridViewTextBoxColumn.DataPropertyName = "DeliveryID";
            this.deliveryIDDataGridViewTextBoxColumn.HeaderText = "Код ТТ";
            this.deliveryIDDataGridViewTextBoxColumn.Name = "deliveryIDDataGridViewTextBoxColumn";
            this.deliveryIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.deliveryIDDataGridViewTextBoxColumn.Width = 68;
            // 
            // deliveryNameDataGridViewTextBoxColumn
            // 
            this.deliveryNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.deliveryNameDataGridViewTextBoxColumn.DataPropertyName = "DeliveryName";
            this.deliveryNameDataGridViewTextBoxColumn.HeaderText = "Назва ТТ";
            this.deliveryNameDataGridViewTextBoxColumn.Name = "deliveryNameDataGridViewTextBoxColumn";
            this.deliveryNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.deliveryNameDataGridViewTextBoxColumn.Width = 81;
            // 
            // rGRegisterDocsForUtilizationBindingSource
            // 
            this.rGRegisterDocsForUtilizationBindingSource.DataMember = "RG_Register_Docs_For_Utilization";
            this.rGRegisterDocsForUtilizationBindingSource.DataSource = this.wH;
            // 
            // wH
            // 
            this.wH.DataSetName = "WH";
            this.wH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnSearchInvoices
            // 
            this.btnSearchInvoices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchInvoices.Image = global::WMSOffice.Properties.Resources.Search1;
            this.btnSearchInvoices.Location = new System.Drawing.Point(657, 65);
            this.btnSearchInvoices.Name = "btnSearchInvoices";
            this.btnSearchInvoices.Size = new System.Drawing.Size(75, 23);
            this.btnSearchInvoices.TabIndex = 8;
            this.btnSearchInvoices.Text = "Пошук";
            this.btnSearchInvoices.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearchInvoices.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearchInvoices.UseVisualStyleBackColor = true;
            this.btnSearchInvoices.Click += new System.EventHandler(this.btnSearchInvoices_Click);
            // 
            // rG_Register_Docs_For_UtilizationTableAdapter
            // 
            this.rG_Register_Docs_For_UtilizationTableAdapter.ClearBeforeFill = true;
            // 
            // scContent
            // 
            this.scContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scContent.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scContent.IsSplitterFixed = true;
            this.scContent.Location = new System.Drawing.Point(0, 0);
            this.scContent.Name = "scContent";
            this.scContent.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scContent.Panel1
            // 
            this.scContent.Panel1.Controls.Add(this.panel2);
            this.scContent.Panel1.Controls.Add(this.panel5);
            // 
            // scContent.Panel2
            // 
            this.scContent.Panel2.Controls.Add(this.panel3);
            this.scContent.Panel2.Controls.Add(this.panel1);
            this.scContent.Size = new System.Drawing.Size(744, 376);
            this.scContent.SplitterDistance = 60;
            this.scContent.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblYearFrom);
            this.panel2.Controls.Add(this.nudYearTo);
            this.panel2.Controls.Add(this.lblYearTo);
            this.panel2.Controls.Add(this.nudYearFrom);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(744, 36);
            this.panel2.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel5.Controls.Add(this.label3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(744, 24);
            this.panel5.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.label3.Size = new System.Drawing.Size(744, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "Період утилізації";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSearchInvoices);
            this.panel3.Controls.Add(this.tbDebtor);
            this.panel3.Controls.Add(this.dgvInvoices);
            this.panel3.Controls.Add(this.lblInvoiceType);
            this.panel3.Controls.Add(this.stbDebtor);
            this.panel3.Controls.Add(this.stbInvoiceType);
            this.panel3.Controls.Add(this.lblDebtor);
            this.panel3.Controls.Add(this.tbInvoiceType);
            this.panel3.Controls.Add(this.tbInvoiceNumber);
            this.panel3.Controls.Add(this.lbllInvoiceNumber);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 24);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(744, 288);
            this.panel3.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(744, 24);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.label1.Size = new System.Drawing.Size(744, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Виключити з утилізації документи";
            // 
            // ArchivedInvoicesRegisterUtilizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 425);
            this.Controls.Add(this.scContent);
            this.Name = "ArchivedInvoicesRegisterUtilizationForm";
            this.Text = "Утилізувати документи";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ArchivedInvoicesRegisterUtilizationForm_FormClosing);
            this.Controls.SetChildIndex(this.scContent, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudYearFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYearTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGRegisterDocsForUtilizationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).EndInit();
            this.scContent.Panel1.ResumeLayout(false);
            this.scContent.Panel2.ResumeLayout(false);
            this.scContent.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblYearFrom;
        private System.Windows.Forms.NumericUpDown nudYearFrom;
        private System.Windows.Forms.NumericUpDown nudYearTo;
        private System.Windows.Forms.Label lblYearTo;
        private System.Windows.Forms.TextBox tbInvoiceNumber;
        private System.Windows.Forms.Label lbllInvoiceNumber;
        private System.Windows.Forms.TextBox tbInvoiceType;
        private WMSOffice.Controls.SearchTextBox stbInvoiceType;
        private System.Windows.Forms.Label lblInvoiceType;
        private System.Windows.Forms.TextBox tbDebtor;
        private WMSOffice.Controls.SearchTextBox stbDebtor;
        private System.Windows.Forms.Label lblDebtor;
        private System.Windows.Forms.DataGridView dgvInvoices;
        private System.Windows.Forms.Button btnSearchInvoices;
        private System.Windows.Forms.BindingSource rGRegisterDocsForUtilizationBindingSource;
        private WMSOffice.Data.WH wH;
        private WMSOffice.Data.WHTableAdapters.RG_Register_Docs_For_UtilizationTableAdapter rG_Register_Docs_For_UtilizationTableAdapter;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isCheckedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoiceNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoiceTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoiceDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn debtorIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn debtorNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deliveryIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deliveryNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.SplitContainer scContent;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}