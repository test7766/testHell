namespace WMSOffice.Window
{
    partial class PickSlipContentPreviewWindow
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
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.dgvPickSlipContent = new System.Windows.Forms.DataGridView();
            this.pickSlipContentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pickControl = new WMSOffice.Data.PickControl();
            this.pickSlipContentTableAdapter = new WMSOffice.Data.PickControlTableAdapters.PickSlipContentTableAdapter();
            this.psnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itmdescDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weightitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weightsumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPickSlipContent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickSlipContentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsMain.Location = new System.Drawing.Point(0, 40);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1012, 25);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
            // 
            // dgvPickSlipContent
            // 
            this.dgvPickSlipContent.AllowUserToAddRows = false;
            this.dgvPickSlipContent.AllowUserToDeleteRows = false;
            this.dgvPickSlipContent.AllowUserToResizeRows = false;
            this.dgvPickSlipContent.AutoGenerateColumns = false;
            this.dgvPickSlipContent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPickSlipContent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPickSlipContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPickSlipContent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.psnDataGridViewTextBoxColumn,
            this.itmDataGridViewTextBoxColumn,
            this.itmdescDataGridViewTextBoxColumn,
            this.lotnDataGridViewTextBoxColumn,
            this.qtyDataGridViewTextBoxColumn,
            this.weightitDataGridViewTextBoxColumn,
            this.weightsumDataGridViewTextBoxColumn});
            this.dgvPickSlipContent.DataSource = this.pickSlipContentBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPickSlipContent.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPickSlipContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPickSlipContent.Location = new System.Drawing.Point(0, 65);
            this.dgvPickSlipContent.MultiSelect = false;
            this.dgvPickSlipContent.Name = "dgvPickSlipContent";
            this.dgvPickSlipContent.ReadOnly = true;
            this.dgvPickSlipContent.RowHeadersVisible = false;
            this.dgvPickSlipContent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPickSlipContent.Size = new System.Drawing.Size(1012, 442);
            this.dgvPickSlipContent.TabIndex = 2;
            // 
            // pickSlipContentBindingSource
            // 
            this.pickSlipContentBindingSource.DataMember = "PickSlipContent";
            this.pickSlipContentBindingSource.DataSource = this.pickControl;
            // 
            // pickControl
            // 
            this.pickControl.DataSetName = "PickControl";
            this.pickControl.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pickSlipContentTableAdapter
            // 
            this.pickSlipContentTableAdapter.ClearBeforeFill = true;
            // 
            // psnDataGridViewTextBoxColumn
            // 
            this.psnDataGridViewTextBoxColumn.DataPropertyName = "psn";
            this.psnDataGridViewTextBoxColumn.HeaderText = "Сборочный";
            this.psnDataGridViewTextBoxColumn.Name = "psnDataGridViewTextBoxColumn";
            this.psnDataGridViewTextBoxColumn.ReadOnly = true;
            this.psnDataGridViewTextBoxColumn.Width = 119;
            // 
            // itmDataGridViewTextBoxColumn
            // 
            this.itmDataGridViewTextBoxColumn.DataPropertyName = "itm";
            this.itmDataGridViewTextBoxColumn.HeaderText = "Код";
            this.itmDataGridViewTextBoxColumn.Name = "itmDataGridViewTextBoxColumn";
            this.itmDataGridViewTextBoxColumn.ReadOnly = true;
            this.itmDataGridViewTextBoxColumn.Width = 64;
            // 
            // itmdescDataGridViewTextBoxColumn
            // 
            this.itmdescDataGridViewTextBoxColumn.DataPropertyName = "itm_desc";
            this.itmdescDataGridViewTextBoxColumn.HeaderText = "Наименование";
            this.itmdescDataGridViewTextBoxColumn.Name = "itmdescDataGridViewTextBoxColumn";
            this.itmdescDataGridViewTextBoxColumn.ReadOnly = true;
            this.itmdescDataGridViewTextBoxColumn.Width = 147;
            // 
            // lotnDataGridViewTextBoxColumn
            // 
            this.lotnDataGridViewTextBoxColumn.DataPropertyName = "lotn";
            this.lotnDataGridViewTextBoxColumn.HeaderText = "Партия";
            this.lotnDataGridViewTextBoxColumn.Name = "lotnDataGridViewTextBoxColumn";
            this.lotnDataGridViewTextBoxColumn.ReadOnly = true;
            this.lotnDataGridViewTextBoxColumn.Width = 91;
            // 
            // qtyDataGridViewTextBoxColumn
            // 
            this.qtyDataGridViewTextBoxColumn.DataPropertyName = "qty";
            this.qtyDataGridViewTextBoxColumn.HeaderText = "Кол-во";
            this.qtyDataGridViewTextBoxColumn.Name = "qtyDataGridViewTextBoxColumn";
            this.qtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.qtyDataGridViewTextBoxColumn.Width = 86;
            // 
            // weightitDataGridViewTextBoxColumn
            // 
            this.weightitDataGridViewTextBoxColumn.DataPropertyName = "weight_it";
            this.weightitDataGridViewTextBoxColumn.HeaderText = "Вес единицы";
            this.weightitDataGridViewTextBoxColumn.Name = "weightitDataGridViewTextBoxColumn";
            this.weightitDataGridViewTextBoxColumn.ReadOnly = true;
            this.weightitDataGridViewTextBoxColumn.Width = 133;
            // 
            // weightsumDataGridViewTextBoxColumn
            // 
            this.weightsumDataGridViewTextBoxColumn.DataPropertyName = "weight_sum";
            this.weightsumDataGridViewTextBoxColumn.HeaderText = "Вес позиции";
            this.weightsumDataGridViewTextBoxColumn.Name = "weightsumDataGridViewTextBoxColumn";
            this.weightsumDataGridViewTextBoxColumn.ReadOnly = true;
            this.weightsumDataGridViewTextBoxColumn.Width = 128;
            // 
            // PickSlipContentPreviewWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 507);
            this.Controls.Add(this.dgvPickSlipContent);
            this.Controls.Add(this.tsMain);
            this.Name = "PickSlipContentPreviewWindow";
            this.Text = "PickSlipContentPreviewWindow";
            this.Controls.SetChildIndex(this.tsMain, 0);
            this.Controls.SetChildIndex(this.dgvPickSlipContent, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPickSlipContent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickSlipContentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.DataGridView dgvPickSlipContent;
        private System.Windows.Forms.BindingSource pickSlipContentBindingSource;
        private WMSOffice.Data.PickControl pickControl;
        private WMSOffice.Data.PickControlTableAdapters.PickSlipContentTableAdapter pickSlipContentTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn psnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itmdescDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn weightitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn weightsumDataGridViewTextBoxColumn;
    }
}