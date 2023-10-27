namespace WMSOffice.Dialogs.PickControl
{
    partial class WavePickLabelControlForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblAction = new System.Windows.Forms.Label();
            this.tbsLabelBarcode = new WMSOffice.Controls.TextBoxScaner();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.itemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seriallotDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wLDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yLDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.psnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pcdocidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pcrecontrolwldocidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wavePickLabelDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pickControl = new WMSOffice.Data.PickControl();
            this.wavePickLabelDetailsTableAdapter = new WMSOffice.Data.PickControlTableAdapters.WavePickLabelDetailsTableAdapter();
            this.pnlButtons.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wavePickLabelDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(3949, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(4039, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 628);
            this.pnlButtons.Size = new System.Drawing.Size(1294, 43);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlHeader.Controls.Add(this.lblAction);
            this.pnlHeader.Controls.Add(this.tbsLabelBarcode);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1294, 42);
            this.pnlHeader.TabIndex = 101;
            // 
            // lblAction
            // 
            this.lblAction.AutoSize = true;
            this.lblAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAction.ForeColor = System.Drawing.Color.Green;
            this.lblAction.Location = new System.Drawing.Point(12, 9);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(208, 25);
            this.lblAction.TabIndex = 1;
            this.lblAction.Text = "Отсканируйте ЖЭ";
            // 
            // tbsLabelBarcode
            // 
            this.tbsLabelBarcode.AllowType = true;
            this.tbsLabelBarcode.AutoConvert = true;
            this.tbsLabelBarcode.DelayThreshold = 50;
            this.tbsLabelBarcode.Location = new System.Drawing.Point(254, 9);
            this.tbsLabelBarcode.Name = "tbsLabelBarcode";
            this.tbsLabelBarcode.RaiseTextChangeWithoutEnter = false;
            this.tbsLabelBarcode.ReadOnly = false;
            this.tbsLabelBarcode.Size = new System.Drawing.Size(375, 25);
            this.tbsLabelBarcode.TabIndex = 0;
            this.tbsLabelBarcode.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.tbsLabelBarcode.UseParentFont = false;
            this.tbsLabelBarcode.UseScanModeOnly = false;
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.AllowUserToResizeRows = false;
            this.dgvDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetails.AutoGenerateColumns = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemDataGridViewTextBoxColumn,
            this.itemnameDataGridViewTextBoxColumn,
            this.manufacturerDataGridViewTextBoxColumn,
            this.seriallotDataGridViewTextBoxColumn,
            this.qtyDataGridViewTextBoxColumn,
            this.wLDataGridViewTextBoxColumn,
            this.yLDataGridViewTextBoxColumn,
            this.psnDataGridViewTextBoxColumn,
            this.pcdocidDataGridViewTextBoxColumn,
            this.pcrecontrolwldocidDataGridViewTextBoxColumn});
            this.dgvDetails.DataSource = this.wavePickLabelDetailsBindingSource;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetails.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDetails.Location = new System.Drawing.Point(0, 48);
            this.dgvDetails.MultiSelect = false;
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;
            this.dgvDetails.RowHeadersVisible = false;
            this.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetails.Size = new System.Drawing.Size(1294, 574);
            this.dgvDetails.TabIndex = 102;
            this.dgvDetails.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvDetails_DataBindingComplete);
            // 
            // itemDataGridViewTextBoxColumn
            // 
            this.itemDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemDataGridViewTextBoxColumn.DataPropertyName = "item";
            this.itemDataGridViewTextBoxColumn.HeaderText = "Код";
            this.itemDataGridViewTextBoxColumn.Name = "itemDataGridViewTextBoxColumn";
            this.itemDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemDataGridViewTextBoxColumn.Width = 64;
            // 
            // itemnameDataGridViewTextBoxColumn
            // 
            this.itemnameDataGridViewTextBoxColumn.DataPropertyName = "item_name";
            this.itemnameDataGridViewTextBoxColumn.HeaderText = "Наименование";
            this.itemnameDataGridViewTextBoxColumn.Name = "itemnameDataGridViewTextBoxColumn";
            this.itemnameDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemnameDataGridViewTextBoxColumn.Width = 250;
            // 
            // manufacturerDataGridViewTextBoxColumn
            // 
            this.manufacturerDataGridViewTextBoxColumn.DataPropertyName = "manufacturer";
            this.manufacturerDataGridViewTextBoxColumn.HeaderText = "Производитель";
            this.manufacturerDataGridViewTextBoxColumn.Name = "manufacturerDataGridViewTextBoxColumn";
            this.manufacturerDataGridViewTextBoxColumn.ReadOnly = true;
            this.manufacturerDataGridViewTextBoxColumn.Width = 200;
            // 
            // seriallotDataGridViewTextBoxColumn
            // 
            this.seriallotDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.seriallotDataGridViewTextBoxColumn.DataPropertyName = "serial_lot";
            this.seriallotDataGridViewTextBoxColumn.HeaderText = "Серия";
            this.seriallotDataGridViewTextBoxColumn.Name = "seriallotDataGridViewTextBoxColumn";
            this.seriallotDataGridViewTextBoxColumn.ReadOnly = true;
            this.seriallotDataGridViewTextBoxColumn.Width = 81;
            // 
            // qtyDataGridViewTextBoxColumn
            // 
            this.qtyDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.qtyDataGridViewTextBoxColumn.DataPropertyName = "qty";
            this.qtyDataGridViewTextBoxColumn.HeaderText = "Кол-во";
            this.qtyDataGridViewTextBoxColumn.Name = "qtyDataGridViewTextBoxColumn";
            this.qtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.qtyDataGridViewTextBoxColumn.Width = 86;
            // 
            // wLDataGridViewTextBoxColumn
            // 
            this.wLDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.wLDataGridViewTextBoxColumn.DataPropertyName = "WL";
            this.wLDataGridViewTextBoxColumn.HeaderText = "Ш/К БЭ";
            this.wLDataGridViewTextBoxColumn.Name = "wLDataGridViewTextBoxColumn";
            this.wLDataGridViewTextBoxColumn.ReadOnly = true;
            this.wLDataGridViewTextBoxColumn.Width = 61;
            // 
            // yLDataGridViewTextBoxColumn
            // 
            this.yLDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.yLDataGridViewTextBoxColumn.DataPropertyName = "YL";
            this.yLDataGridViewTextBoxColumn.HeaderText = "Ш/К ЖЭ";
            this.yLDataGridViewTextBoxColumn.Name = "yLDataGridViewTextBoxColumn";
            this.yLDataGridViewTextBoxColumn.ReadOnly = true;
            this.yLDataGridViewTextBoxColumn.Width = 61;
            // 
            // psnDataGridViewTextBoxColumn
            // 
            this.psnDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.psnDataGridViewTextBoxColumn.DataPropertyName = "psn";
            this.psnDataGridViewTextBoxColumn.HeaderText = "Сборочный";
            this.psnDataGridViewTextBoxColumn.Name = "psnDataGridViewTextBoxColumn";
            this.psnDataGridViewTextBoxColumn.ReadOnly = true;
            this.psnDataGridViewTextBoxColumn.Width = 119;
            // 
            // pcdocidDataGridViewTextBoxColumn
            // 
            this.pcdocidDataGridViewTextBoxColumn.DataPropertyName = "pc_doc_id";
            this.pcdocidDataGridViewTextBoxColumn.HeaderText = "Документ контроля";
            this.pcdocidDataGridViewTextBoxColumn.Name = "pcdocidDataGridViewTextBoxColumn";
            this.pcdocidDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pcrecontrolwldocidDataGridViewTextBoxColumn
            // 
            this.pcrecontrolwldocidDataGridViewTextBoxColumn.DataPropertyName = "pc_recontrol_wl_doc_id";
            this.pcrecontrolwldocidDataGridViewTextBoxColumn.HeaderText = "Документ привязки";
            this.pcrecontrolwldocidDataGridViewTextBoxColumn.Name = "pcrecontrolwldocidDataGridViewTextBoxColumn";
            this.pcrecontrolwldocidDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // wavePickLabelDetailsBindingSource
            // 
            this.wavePickLabelDetailsBindingSource.DataMember = "WavePickLabelDetails";
            this.wavePickLabelDetailsBindingSource.DataSource = this.pickControl;
            // 
            // pickControl
            // 
            this.pickControl.DataSetName = "PickControl";
            this.pickControl.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // wavePickLabelDetailsTableAdapter
            // 
            this.wavePickLabelDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // WavePickLabelControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 671);
            this.Controls.Add(this.dgvDetails);
            this.Controls.Add(this.pnlHeader);
            this.Name = "WavePickLabelControlForm";
            this.Text = "Интерфейс контроля привязки ЖЭ к БЭ";
            this.Load += new System.EventHandler(this.WavePickLabelControlForm_Load);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.Controls.SetChildIndex(this.dgvDetails, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wavePickLabelDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.BindingSource wavePickLabelDetailsBindingSource;
        private WMSOffice.Data.PickControl pickControl;
        private WMSOffice.Data.PickControlTableAdapters.WavePickLabelDetailsTableAdapter wavePickLabelDetailsTableAdapter;
        private WMSOffice.Controls.TextBoxScaner tbsLabelBarcode;
        private System.Windows.Forms.Label lblAction;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn seriallotDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn wLDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yLDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn psnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pcdocidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pcrecontrolwldocidDataGridViewTextBoxColumn;
    }
}