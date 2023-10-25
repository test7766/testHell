namespace WMSOffice.Window
{
    partial class DeliveryLetterOfAttorneyPrintWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsToolbar = new System.Windows.Forms.ToolStrip();
            this.sbRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.sbFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmbPrinters = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.sbSetDriver = new System.Windows.Forms.ToolStripButton();
            this.sbPrint = new System.Windows.Forms.ToolStripButton();
            this.dgvDocs = new System.Windows.Forms.DataGridView();
            this.cODocidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cODocTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docTypeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debitoridDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debitorNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.driveridDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.driverNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Doc_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Document_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.letterOfAttorneyDocsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.delivery = new WMSOffice.Data.Delivery();
            this.letterOfAttorneyDocsTableAdapter = new WMSOffice.Data.DeliveryTableAdapters.LetterOfAttorneyDocsTableAdapter();
            this.tsToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.letterOfAttorneyDocsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.delivery)).BeginInit();
            this.SuspendLayout();
            // 
            // tsToolbar
            // 
            this.tsToolbar.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbRefresh,
            this.toolStripSeparator3,
            this.sbFind,
            this.toolStripSeparator1,
            this.cmbPrinters,
            this.toolStripLabel1,
            this.toolStripSeparator2,
            this.sbSetDriver,
            this.sbPrint});
            this.tsToolbar.Location = new System.Drawing.Point(0, 40);
            this.tsToolbar.Name = "tsToolbar";
            this.tsToolbar.Size = new System.Drawing.Size(1520, 55);
            this.tsToolbar.TabIndex = 1;
            this.tsToolbar.Text = "toolStrip1";
            // 
            // sbRefresh
            // 
            this.sbRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.sbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbRefresh.Name = "sbRefresh";
            this.sbRefresh.Size = new System.Drawing.Size(113, 52);
            this.sbRefresh.Text = "Обновить";
            this.sbRefresh.Click += new System.EventHandler(this.sbRefresh_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 55);
            // 
            // sbFind
            // 
            this.sbFind.Image = global::WMSOffice.Properties.Resources.find;
            this.sbFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbFind.Name = "sbFind";
            this.sbFind.Size = new System.Drawing.Size(94, 52);
            this.sbFind.Text = "Поиск";
            this.sbFind.Click += new System.EventHandler(this.sbFind_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // cmbPrinters
            // 
            this.cmbPrinters.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cmbPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinters.Name = "cmbPrinters";
            this.cmbPrinters.Size = new System.Drawing.Size(200, 55);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(61, 52);
            this.toolStripLabel1.Text = "Принтер :";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // sbSetDriver
            // 
            this.sbSetDriver.Image = global::WMSOffice.Properties.Resources.quiz;
            this.sbSetDriver.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbSetDriver.Name = "sbSetDriver";
            this.sbSetDriver.Size = new System.Drawing.Size(117, 52);
            this.sbSetDriver.Text = "Назначить\nводителя";
            this.sbSetDriver.Click += new System.EventHandler(this.sbSetDriver_Click);
            // 
            // sbPrint
            // 
            this.sbPrint.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.sbPrint.Image = global::WMSOffice.Properties.Resources.document_print;
            this.sbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbPrint.Name = "sbPrint";
            this.sbPrint.Size = new System.Drawing.Size(122, 52);
            this.sbPrint.Text = "Напечатать";
            this.sbPrint.Click += new System.EventHandler(this.sbPrint_Click);
            // 
            // dgvDocs
            // 
            this.dgvDocs.AllowUserToAddRows = false;
            this.dgvDocs.AllowUserToDeleteRows = false;
            this.dgvDocs.AllowUserToOrderColumns = true;
            this.dgvDocs.AllowUserToResizeRows = false;
            this.dgvDocs.AutoGenerateColumns = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDocs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDocs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cODocidDataGridViewTextBoxColumn,
            this.cODocTypeDataGridViewTextBoxColumn,
            this.docTypeNameDataGridViewTextBoxColumn,
            this.debitoridDataGridViewTextBoxColumn,
            this.debitorNameDataGridViewTextBoxColumn,
            this.driveridDataGridViewTextBoxColumn,
            this.driverNameDataGridViewTextBoxColumn,
            this.Doc_Date,
            this.Document_Number});
            this.dgvDocs.DataSource = this.letterOfAttorneyDocsBindingSource;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDocs.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocs.Location = new System.Drawing.Point(0, 95);
            this.dgvDocs.Name = "dgvDocs";
            this.dgvDocs.ReadOnly = true;
            this.dgvDocs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocs.Size = new System.Drawing.Size(1520, 508);
            this.dgvDocs.TabIndex = 2;
            this.dgvDocs.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDocs_CellFormatting);
            this.dgvDocs.SelectionChanged += new System.EventHandler(this.dgvDocs_SelectionChanged);
            // 
            // cODocidDataGridViewTextBoxColumn
            // 
            this.cODocidDataGridViewTextBoxColumn.DataPropertyName = "CO_Doc_id";
            this.cODocidDataGridViewTextBoxColumn.HeaderText = "№ претензии";
            this.cODocidDataGridViewTextBoxColumn.Name = "cODocidDataGridViewTextBoxColumn";
            this.cODocidDataGridViewTextBoxColumn.ReadOnly = true;
            this.cODocidDataGridViewTextBoxColumn.Width = 90;
            // 
            // cODocTypeDataGridViewTextBoxColumn
            // 
            this.cODocTypeDataGridViewTextBoxColumn.DataPropertyName = "CO_Doc_Type";
            this.cODocTypeDataGridViewTextBoxColumn.HeaderText = "Тип претензии";
            this.cODocTypeDataGridViewTextBoxColumn.Name = "cODocTypeDataGridViewTextBoxColumn";
            this.cODocTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.cODocTypeDataGridViewTextBoxColumn.Width = 90;
            // 
            // docTypeNameDataGridViewTextBoxColumn
            // 
            this.docTypeNameDataGridViewTextBoxColumn.DataPropertyName = "Doc_Type_Name";
            this.docTypeNameDataGridViewTextBoxColumn.HeaderText = "Описание";
            this.docTypeNameDataGridViewTextBoxColumn.Name = "docTypeNameDataGridViewTextBoxColumn";
            this.docTypeNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.docTypeNameDataGridViewTextBoxColumn.Width = 160;
            // 
            // debitoridDataGridViewTextBoxColumn
            // 
            this.debitoridDataGridViewTextBoxColumn.DataPropertyName = "Debitor_id";
            this.debitoridDataGridViewTextBoxColumn.HeaderText = "Код дебитора";
            this.debitoridDataGridViewTextBoxColumn.Name = "debitoridDataGridViewTextBoxColumn";
            this.debitoridDataGridViewTextBoxColumn.ReadOnly = true;
            this.debitoridDataGridViewTextBoxColumn.Width = 90;
            // 
            // debitorNameDataGridViewTextBoxColumn
            // 
            this.debitorNameDataGridViewTextBoxColumn.DataPropertyName = "Debitor_Name";
            this.debitorNameDataGridViewTextBoxColumn.HeaderText = "Дебитор";
            this.debitorNameDataGridViewTextBoxColumn.Name = "debitorNameDataGridViewTextBoxColumn";
            this.debitorNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.debitorNameDataGridViewTextBoxColumn.Width = 350;
            // 
            // driveridDataGridViewTextBoxColumn
            // 
            this.driveridDataGridViewTextBoxColumn.DataPropertyName = "Driver_id";
            this.driveridDataGridViewTextBoxColumn.HeaderText = "Код водителя";
            this.driveridDataGridViewTextBoxColumn.Name = "driveridDataGridViewTextBoxColumn";
            this.driveridDataGridViewTextBoxColumn.ReadOnly = true;
            this.driveridDataGridViewTextBoxColumn.Width = 90;
            // 
            // driverNameDataGridViewTextBoxColumn
            // 
            this.driverNameDataGridViewTextBoxColumn.DataPropertyName = "Driver_Name";
            this.driverNameDataGridViewTextBoxColumn.HeaderText = "Водитель";
            this.driverNameDataGridViewTextBoxColumn.Name = "driverNameDataGridViewTextBoxColumn";
            this.driverNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.driverNameDataGridViewTextBoxColumn.Width = 280;
            // 
            // Doc_Date
            // 
            this.Doc_Date.DataPropertyName = "Doc_Date";
            dataGridViewCellStyle5.Format = "d";
            dataGridViewCellStyle5.NullValue = null;
            this.Doc_Date.DefaultCellStyle = dataGridViewCellStyle5;
            this.Doc_Date.HeaderText = "Дата доверенности";
            this.Doc_Date.Name = "Doc_Date";
            this.Doc_Date.ReadOnly = true;
            this.Doc_Date.Width = 120;
            // 
            // Document_Number
            // 
            this.Document_Number.DataPropertyName = "Document_Number";
            this.Document_Number.HeaderText = "Документ возврата";
            this.Document_Number.Name = "Document_Number";
            this.Document_Number.ReadOnly = true;
            this.Document_Number.Width = 200;
            // 
            // letterOfAttorneyDocsBindingSource
            // 
            this.letterOfAttorneyDocsBindingSource.DataMember = "LetterOfAttorneyDocs";
            this.letterOfAttorneyDocsBindingSource.DataSource = this.delivery;
            // 
            // delivery
            // 
            this.delivery.DataSetName = "Delivery";
            this.delivery.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // letterOfAttorneyDocsTableAdapter
            // 
            this.letterOfAttorneyDocsTableAdapter.ClearBeforeFill = true;
            // 
            // DeliveryLetterOfAttorneyPrintWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1520, 603);
            this.Controls.Add(this.dgvDocs);
            this.Controls.Add(this.tsToolbar);
            this.Name = "DeliveryLetterOfAttorneyPrintWindow";
            this.Text = "DeliveryLetterOfAttorneyPrintWindow";
            this.Load += new System.EventHandler(this.DeliveryLetterOfAttorneyPrintWindow_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DeliveryLetterOfAttorneyPrintWindow_FormClosing);
            this.Controls.SetChildIndex(this.tsToolbar, 0);
            this.Controls.SetChildIndex(this.dgvDocs, 0);
            this.tsToolbar.ResumeLayout(false);
            this.tsToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.letterOfAttorneyDocsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.delivery)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsToolbar;
        private System.Windows.Forms.ToolStripButton sbRefresh;
        private System.Windows.Forms.ToolStripButton sbPrint;
        private System.Windows.Forms.DataGridView dgvDocs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.BindingSource letterOfAttorneyDocsBindingSource;
        private WMSOffice.Data.Delivery delivery;
        private WMSOffice.Data.DeliveryTableAdapters.LetterOfAttorneyDocsTableAdapter letterOfAttorneyDocsTableAdapter;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox cmbPrinters;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton sbFind;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton sbSetDriver;
        private System.Windows.Forms.DataGridViewTextBoxColumn cODocidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cODocTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docTypeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn debitoridDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn debitorNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn driveridDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn driverNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Doc_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Document_Number;
    }
}