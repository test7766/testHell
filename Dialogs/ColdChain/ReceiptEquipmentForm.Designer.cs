namespace WMSOffice.Dialogs.ColdChain
{
    partial class ReceiptEquipmentForm
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.tbsEquipment = new WMSOffice.Controls.TextBoxScaner();
            this.lblScanEquipment = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.dgvEquipment = new System.Windows.Forms.DataGridView();
            this.шКОборудованияDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.наименованиеDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.типОборудованияDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.статусСтрокиDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullEquipmentByRouteListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.coldChain = new WMSOffice.Data.ColdChain();
            this.fullEquipmentByRouteListTableAdapter = new WMSOffice.Data.ColdChainTableAdapters.FullEquipmentByRouteListTableAdapter();
            this.pnlButtons.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fullEquipmentByRouteListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coldChain)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(1508, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1598, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 428);
            this.pnlButtons.Size = new System.Drawing.Size(794, 43);
            this.pnlButtons.TabIndex = 2;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.tbsEquipment);
            this.pnlHeader.Controls.Add(this.lblScanEquipment);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(794, 50);
            this.pnlHeader.TabIndex = 0;
            // 
            // tbsEquipment
            // 
            this.tbsEquipment.AllowType = true;
            this.tbsEquipment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbsEquipment.AutoConvert = true;
            this.tbsEquipment.DelayThreshold = 50;
            this.tbsEquipment.Location = new System.Drawing.Point(226, 13);
            this.tbsEquipment.Name = "tbsEquipment";
            this.tbsEquipment.RaiseTextChangeWithoutEnter = false;
            this.tbsEquipment.ReadOnly = false;
            this.tbsEquipment.Size = new System.Drawing.Size(565, 25);
            this.tbsEquipment.TabIndex = 1;
            this.tbsEquipment.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.tbsEquipment.UseParentFont = false;
            this.tbsEquipment.UseScanModeOnly = false;
            // 
            // lblScanEquipment
            // 
            this.lblScanEquipment.AutoSize = true;
            this.lblScanEquipment.Location = new System.Drawing.Point(12, 19);
            this.lblScanEquipment.Name = "lblScanEquipment";
            this.lblScanEquipment.Size = new System.Drawing.Size(208, 13);
            this.lblScanEquipment.TabIndex = 0;
            this.lblScanEquipment.Text = "Отсканируйте ш/к термооборудования:";
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.dgvEquipment);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 50);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(794, 378);
            this.pnlContent.TabIndex = 1;
            // 
            // dgvEquipment
            // 
            this.dgvEquipment.AllowUserToAddRows = false;
            this.dgvEquipment.AllowUserToDeleteRows = false;
            this.dgvEquipment.AllowUserToResizeColumns = false;
            this.dgvEquipment.AllowUserToResizeRows = false;
            this.dgvEquipment.AutoGenerateColumns = false;
            this.dgvEquipment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvEquipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEquipment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.шКОборудованияDataGridViewTextBoxColumn,
            this.наименованиеDataGridViewTextBoxColumn,
            this.типОборудованияDataGridViewTextBoxColumn,
            this.статусСтрокиDataGridViewTextBoxColumn});
            this.dgvEquipment.DataSource = this.fullEquipmentByRouteListBindingSource;
            this.dgvEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEquipment.Location = new System.Drawing.Point(0, 0);
            this.dgvEquipment.MultiSelect = false;
            this.dgvEquipment.Name = "dgvEquipment";
            this.dgvEquipment.ReadOnly = true;
            this.dgvEquipment.RowHeadersVisible = false;
            this.dgvEquipment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEquipment.Size = new System.Drawing.Size(794, 378);
            this.dgvEquipment.TabIndex = 0;
            this.dgvEquipment.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvEquipment_DataBindingComplete);
            // 
            // шКОборудованияDataGridViewTextBoxColumn
            // 
            this.шКОборудованияDataGridViewTextBoxColumn.DataPropertyName = "ШК оборудования";
            this.шКОборудованияDataGridViewTextBoxColumn.HeaderText = "ШК оборудования";
            this.шКОборудованияDataGridViewTextBoxColumn.Name = "шКОборудованияDataGridViewTextBoxColumn";
            this.шКОборудованияDataGridViewTextBoxColumn.ReadOnly = true;
            this.шКОборудованияDataGridViewTextBoxColumn.Width = 112;
            // 
            // наименованиеDataGridViewTextBoxColumn
            // 
            this.наименованиеDataGridViewTextBoxColumn.DataPropertyName = "Наименование";
            this.наименованиеDataGridViewTextBoxColumn.HeaderText = "Наименование";
            this.наименованиеDataGridViewTextBoxColumn.Name = "наименованиеDataGridViewTextBoxColumn";
            this.наименованиеDataGridViewTextBoxColumn.ReadOnly = true;
            this.наименованиеDataGridViewTextBoxColumn.Width = 108;
            // 
            // типОборудованияDataGridViewTextBoxColumn
            // 
            this.типОборудованияDataGridViewTextBoxColumn.DataPropertyName = "Тип оборудования";
            this.типОборудованияDataGridViewTextBoxColumn.HeaderText = "Тип оборудования";
            this.типОборудованияDataGridViewTextBoxColumn.Name = "типОборудованияDataGridViewTextBoxColumn";
            this.типОборудованияDataGridViewTextBoxColumn.ReadOnly = true;
            this.типОборудованияDataGridViewTextBoxColumn.Width = 115;
            // 
            // статусСтрокиDataGridViewTextBoxColumn
            // 
            this.статусСтрокиDataGridViewTextBoxColumn.DataPropertyName = "Статус строки";
            this.статусСтрокиDataGridViewTextBoxColumn.HeaderText = "Статус строки";
            this.статусСтрокиDataGridViewTextBoxColumn.Name = "статусСтрокиDataGridViewTextBoxColumn";
            this.статусСтрокиDataGridViewTextBoxColumn.ReadOnly = true;
            this.статусСтрокиDataGridViewTextBoxColumn.Width = 96;
            // 
            // fullEquipmentByRouteListBindingSource
            // 
            this.fullEquipmentByRouteListBindingSource.DataMember = "FullEquipmentByRouteList";
            this.fullEquipmentByRouteListBindingSource.DataSource = this.coldChain;
            // 
            // coldChain
            // 
            this.coldChain.DataSetName = "ColdChain";
            this.coldChain.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fullEquipmentByRouteListTableAdapter
            // 
            this.fullEquipmentByRouteListTableAdapter.ClearBeforeFill = true;
            // 
            // ReceiptEquipmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 471);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Name = "ReceiptEquipmentForm";
            this.Text = "Сдача термооборудования";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReceiptEquipmentForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.pnlButtons.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fullEquipmentByRouteListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coldChain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.DataGridView dgvEquipment;
        private Controls.TextBoxScaner tbsEquipment;
        private System.Windows.Forms.Label lblScanEquipment;
        private System.Windows.Forms.DataGridViewTextBoxColumn шКОборудованияDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn наименованиеDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn типОборудованияDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn статусСтрокиDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource fullEquipmentByRouteListBindingSource;
        private Data.ColdChain coldChain;
        private Data.ColdChainTableAdapters.FullEquipmentByRouteListTableAdapter fullEquipmentByRouteListTableAdapter;
    }
}