namespace WMSOffice.Dialogs.Complaints
{
    partial class ShipReturnsToVendorDocsSelectorForm
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
            this.pnlContent = new System.Windows.Forms.Panel();
            this.dgvVendorReturns = new System.Windows.Forms.DataGridView();
            this.sVVRDocsByVendorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.complaints = new WMSOffice.Data.Complaints();
            this.sV_VR_Docs_By_VendorTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.SV_VR_Docs_By_VendorTableAdapter();
            this.IsChecked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.docIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expectedDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jDEDocDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountUAHDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrintEventDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlButtons.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendorReturns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sVVRDocsByVendorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(2075, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(2165, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 418);
            this.pnlButtons.Size = new System.Drawing.Size(984, 43);
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContent.Controls.Add(this.dgvVendorReturns);
            this.pnlContent.Location = new System.Drawing.Point(0, 2);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(984, 410);
            this.pnlContent.TabIndex = 101;
            // 
            // dgvVendorReturns
            // 
            this.dgvVendorReturns.AllowUserToAddRows = false;
            this.dgvVendorReturns.AllowUserToDeleteRows = false;
            this.dgvVendorReturns.AllowUserToResizeColumns = false;
            this.dgvVendorReturns.AllowUserToResizeRows = false;
            this.dgvVendorReturns.AutoGenerateColumns = false;
            this.dgvVendorReturns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvVendorReturns.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IsChecked,
            this.docIDDataGridViewTextBoxColumn,
            this.expectedDateDataGridViewTextBoxColumn,
            this.docDateDataGridViewTextBoxColumn,
            this.statusIDDataGridViewTextBoxColumn,
            this.statusNameDataGridViewTextBoxColumn,
            this.jDEDocDataGridViewTextBoxColumn,
            this.amountUAHDataGridViewTextBoxColumn,
            this.PrintEventDate,
            this.Column1});
            this.dgvVendorReturns.DataSource = this.sVVRDocsByVendorBindingSource;
            this.dgvVendorReturns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVendorReturns.Location = new System.Drawing.Point(0, 0);
            this.dgvVendorReturns.MultiSelect = false;
            this.dgvVendorReturns.Name = "dgvVendorReturns";
            this.dgvVendorReturns.RowHeadersVisible = false;
            this.dgvVendorReturns.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVendorReturns.Size = new System.Drawing.Size(984, 410);
            this.dgvVendorReturns.TabIndex = 1;
            this.dgvVendorReturns.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvVendorReturns_CellFormatting);
            this.dgvVendorReturns.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvVendorReturns_CurrentCellDirtyStateChanged);
            // 
            // sVVRDocsByVendorBindingSource
            // 
            this.sVVRDocsByVendorBindingSource.DataMember = "SV_VR_Docs_By_Vendor";
            this.sVVRDocsByVendorBindingSource.DataSource = this.complaints;
            // 
            // complaints
            // 
            this.complaints.DataSetName = "Complaints";
            this.complaints.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sV_VR_Docs_By_VendorTableAdapter
            // 
            this.sV_VR_Docs_By_VendorTableAdapter.ClearBeforeFill = true;
            // 
            // IsChecked
            // 
            this.IsChecked.DataPropertyName = "IsChecked";
            this.IsChecked.HeaderText = "Отм.";
            this.IsChecked.Name = "IsChecked";
            this.IsChecked.Width = 35;
            // 
            // docIDDataGridViewTextBoxColumn
            // 
            this.docIDDataGridViewTextBoxColumn.DataPropertyName = "Doc_ID";
            this.docIDDataGridViewTextBoxColumn.HeaderText = "№ накладной";
            this.docIDDataGridViewTextBoxColumn.Name = "docIDDataGridViewTextBoxColumn";
            this.docIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.docIDDataGridViewTextBoxColumn.Width = 85;
            // 
            // expectedDateDataGridViewTextBoxColumn
            // 
            this.expectedDateDataGridViewTextBoxColumn.DataPropertyName = "ExpectedDate";
            this.expectedDateDataGridViewTextBoxColumn.HeaderText = "Дата накладной";
            this.expectedDateDataGridViewTextBoxColumn.Name = "expectedDateDataGridViewTextBoxColumn";
            this.expectedDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // docDateDataGridViewTextBoxColumn
            // 
            this.docDateDataGridViewTextBoxColumn.DataPropertyName = "Doc_Date";
            this.docDateDataGridViewTextBoxColumn.HeaderText = "Дата создания";
            this.docDateDataGridViewTextBoxColumn.Name = "docDateDataGridViewTextBoxColumn";
            this.docDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // statusIDDataGridViewTextBoxColumn
            // 
            this.statusIDDataGridViewTextBoxColumn.DataPropertyName = "Status_ID";
            this.statusIDDataGridViewTextBoxColumn.HeaderText = "Ст.";
            this.statusIDDataGridViewTextBoxColumn.Name = "statusIDDataGridViewTextBoxColumn";
            this.statusIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusIDDataGridViewTextBoxColumn.Width = 30;
            // 
            // statusNameDataGridViewTextBoxColumn
            // 
            this.statusNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.statusNameDataGridViewTextBoxColumn.DataPropertyName = "StatusName";
            this.statusNameDataGridViewTextBoxColumn.HeaderText = "Статус";
            this.statusNameDataGridViewTextBoxColumn.Name = "statusNameDataGridViewTextBoxColumn";
            this.statusNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusNameDataGridViewTextBoxColumn.Width = 66;
            // 
            // jDEDocDataGridViewTextBoxColumn
            // 
            this.jDEDocDataGridViewTextBoxColumn.DataPropertyName = "JDE_Doc";
            this.jDEDocDataGridViewTextBoxColumn.HeaderText = "Номер в JDE";
            this.jDEDocDataGridViewTextBoxColumn.Name = "jDEDocDataGridViewTextBoxColumn";
            this.jDEDocDataGridViewTextBoxColumn.ReadOnly = true;
            this.jDEDocDataGridViewTextBoxColumn.Width = 85;
            // 
            // amountUAHDataGridViewTextBoxColumn
            // 
            this.amountUAHDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.amountUAHDataGridViewTextBoxColumn.DataPropertyName = "Amount_UAH";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N4";
            dataGridViewCellStyle1.NullValue = null;
            this.amountUAHDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.amountUAHDataGridViewTextBoxColumn.HeaderText = "Итог. сумма";
            this.amountUAHDataGridViewTextBoxColumn.Name = "amountUAHDataGridViewTextBoxColumn";
            this.amountUAHDataGridViewTextBoxColumn.ReadOnly = true;
            this.amountUAHDataGridViewTextBoxColumn.Width = 95;
            // 
            // PrintEventDate
            // 
            this.PrintEventDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PrintEventDate.DataPropertyName = "PrintEventDate";
            this.PrintEventDate.HeaderText = "Когда печатался";
            this.PrintEventDate.Name = "PrintEventDate";
            this.PrintEventDate.ReadOnly = true;
            this.PrintEventDate.Width = 117;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.DataPropertyName = "PrintUserName";
            this.Column1.HeaderText = "Кем печатался";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 108;
            // 
            // ShipReturnsToVendorDocsSelectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.pnlContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "ShipReturnsToVendorDocsSelectorForm";
            this.Text = "Выберите необходимые документы для печати";
            this.Load += new System.EventHandler(this.ShipReturnsToVendorPrintForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShipReturnsToVendorPrintForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendorReturns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sVVRDocsByVendorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.DataGridView dgvVendorReturns;
        private System.Windows.Forms.BindingSource sVVRDocsByVendorBindingSource;
        private WMSOffice.Data.Complaints complaints;
        private WMSOffice.Data.ComplaintsTableAdapters.SV_VR_Docs_By_VendorTableAdapter sV_VR_Docs_By_VendorTableAdapter;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsChecked;
        private System.Windows.Forms.DataGridViewTextBoxColumn docIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expectedDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jDEDocDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountUAHDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrintEventDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}