namespace WMSOffice.Window
{
    partial class ReprintFrostEticWindow
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
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnReprintEtic = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCloseDoc = new System.Windows.Forms.ToolStripButton();
            this.btnCancelDoc = new System.Windows.Forms.ToolStripButton();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.eFReprintTaskDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.coldChain = new WMSOffice.Data.ColdChain();
            this.tsSearch = new System.Windows.Forms.ToolStrip();
            this.eF_Reprint_Task_DetailsTableAdapter = new WMSOffice.Data.ColdChainTableAdapters.EF_Reprint_Task_DetailsTableAdapter();
            this.barCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeEtic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.copiesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printedCopiesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateCreatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsMain.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eFReprintTaskDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coldChain)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.toolStripSeparator1,
            this.btnReprintEtic,
            this.toolStripSeparator2,
            this.btnCloseDoc,
            this.btnCancelDoc});
            this.tsMain.Location = new System.Drawing.Point(0, 40);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(740, 55);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(113, 52);
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // btnReprintEtic
            // 
            this.btnReprintEtic.Image = global::WMSOffice.Properties.Resources.document_print;
            this.btnReprintEtic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReprintEtic.Name = "btnReprintEtic";
            this.btnReprintEtic.Size = new System.Drawing.Size(122, 52);
            this.btnReprintEtic.Text = "Напечатать\nповторно";
            this.btnReprintEtic.Click += new System.EventHandler(this.btnReprintEtic_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // btnCloseDoc
            // 
            this.btnCloseDoc.Image = global::WMSOffice.Properties.Resources.finish_process;
            this.btnCloseDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCloseDoc.Name = "btnCloseDoc";
            this.btnCloseDoc.Size = new System.Drawing.Size(111, 52);
            this.btnCloseDoc.Text = "Закрыть\nдокумент";
            this.btnCloseDoc.Click += new System.EventHandler(this.btnCloseDoc_Click);
            // 
            // btnCancelDoc
            // 
            this.btnCancelDoc.Image = global::WMSOffice.Properties.Resources.symbol_stop;
            this.btnCancelDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelDoc.Name = "btnCancelDoc";
            this.btnCancelDoc.Size = new System.Drawing.Size(113, 52);
            this.btnCancelDoc.Text = "Отменить\nдокумент";
            this.btnCancelDoc.Click += new System.EventHandler(this.btnCancelDoc_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.dgvDetails);
            this.pnlContent.Controls.Add(this.tsSearch);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 95);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(740, 293);
            this.pnlContent.TabIndex = 2;
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.AllowUserToResizeColumns = false;
            this.dgvDetails.AllowUserToResizeRows = false;
            this.dgvDetails.AutoGenerateColumns = false;
            this.dgvDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.barCodeDataGridViewTextBoxColumn,
            this.TypeEtic,
            this.copiesDataGridViewTextBoxColumn,
            this.printedCopiesDataGridViewTextBoxColumn,
            this.dateCreatedDataGridViewTextBoxColumn});
            this.dgvDetails.DataSource = this.eFReprintTaskDetailsBindingSource;
            this.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails.Location = new System.Drawing.Point(0, 25);
            this.dgvDetails.MultiSelect = false;
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;
            this.dgvDetails.RowHeadersVisible = false;
            this.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetails.Size = new System.Drawing.Size(740, 268);
            this.dgvDetails.TabIndex = 1;
            this.dgvDetails.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDetails_CellFormatting);
            this.dgvDetails.SelectionChanged += new System.EventHandler(this.dgvDetails_SelectionChanged);
            // 
            // eFReprintTaskDetailsBindingSource
            // 
            this.eFReprintTaskDetailsBindingSource.DataMember = "EF_Reprint_Task_Details";
            this.eFReprintTaskDetailsBindingSource.DataSource = this.coldChain;
            // 
            // coldChain
            // 
            this.coldChain.DataSetName = "ColdChain";
            this.coldChain.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tsSearch
            // 
            this.tsSearch.Location = new System.Drawing.Point(0, 0);
            this.tsSearch.Name = "tsSearch";
            this.tsSearch.Size = new System.Drawing.Size(740, 25);
            this.tsSearch.TabIndex = 0;
            this.tsSearch.Text = "toolStrip1";
            // 
            // eF_Reprint_Task_DetailsTableAdapter
            // 
            this.eF_Reprint_Task_DetailsTableAdapter.ClearBeforeFill = true;
            // 
            // barCodeDataGridViewTextBoxColumn
            // 
            this.barCodeDataGridViewTextBoxColumn.DataPropertyName = "Bar_Code";
            this.barCodeDataGridViewTextBoxColumn.HeaderText = "Ш/К";
            this.barCodeDataGridViewTextBoxColumn.Name = "barCodeDataGridViewTextBoxColumn";
            this.barCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.barCodeDataGridViewTextBoxColumn.Width = 53;
            // 
            // TypeEtic
            // 
            this.TypeEtic.DataPropertyName = "TypeEtic";
            this.TypeEtic.HeaderText = "Тип оборудования";
            this.TypeEtic.Name = "TypeEtic";
            this.TypeEtic.ReadOnly = true;
            this.TypeEtic.Width = 125;
            // 
            // copiesDataGridViewTextBoxColumn
            // 
            this.copiesDataGridViewTextBoxColumn.DataPropertyName = "copies";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            this.copiesDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.copiesDataGridViewTextBoxColumn.HeaderText = "Копий";
            this.copiesDataGridViewTextBoxColumn.Name = "copiesDataGridViewTextBoxColumn";
            this.copiesDataGridViewTextBoxColumn.ReadOnly = true;
            this.copiesDataGridViewTextBoxColumn.Width = 63;
            // 
            // printedCopiesDataGridViewTextBoxColumn
            // 
            this.printedCopiesDataGridViewTextBoxColumn.DataPropertyName = "PrintedCopies";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            this.printedCopiesDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.printedCopiesDataGridViewTextBoxColumn.HeaderText = "Напечатано";
            this.printedCopiesDataGridViewTextBoxColumn.Name = "printedCopiesDataGridViewTextBoxColumn";
            this.printedCopiesDataGridViewTextBoxColumn.ReadOnly = true;
            this.printedCopiesDataGridViewTextBoxColumn.Width = 92;
            // 
            // dateCreatedDataGridViewTextBoxColumn
            // 
            this.dateCreatedDataGridViewTextBoxColumn.DataPropertyName = "Date_Created";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dateCreatedDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.dateCreatedDataGridViewTextBoxColumn.HeaderText = "Дата создания";
            this.dateCreatedDataGridViewTextBoxColumn.Name = "dateCreatedDataGridViewTextBoxColumn";
            this.dateCreatedDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateCreatedDataGridViewTextBoxColumn.Width = 109;
            // 
            // ReprintFrostEticWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 388);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.tsMain);
            this.Name = "ReprintFrostEticWindow";
            this.Text = "ReprintFrostEticWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReprintFrostEticWindow_FormClosing);
            this.Controls.SetChildIndex(this.tsMain, 0);
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eFReprintTaskDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coldChain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton btnReprintEtic;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.ToolStrip tsSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnCloseDoc;
        private System.Windows.Forms.ToolStripButton btnCancelDoc;
        private System.Windows.Forms.BindingSource eFReprintTaskDetailsBindingSource;
        private WMSOffice.Data.ColdChain coldChain;
        private WMSOffice.Data.ColdChainTableAdapters.EF_Reprint_Task_DetailsTableAdapter eF_Reprint_Task_DetailsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn barCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeEtic;
        private System.Windows.Forms.DataGridViewTextBoxColumn copiesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn printedCopiesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateCreatedDataGridViewTextBoxColumn;

    }
}