namespace WMSOffice.Dialogs.Receive
{
    partial class ItemMeasurementBarCodes
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvBarCodes = new System.Windows.Forms.DataGridView();
            this.barCodesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemMeasurementBarCodesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.itemsMeasurement = new WMSOffice.Data.ItemsMeasurement();
            this.itemMeasurementBarCodesTableAdapter = new WMSOffice.Data.ItemsMeasurementTableAdapters.ItemMeasurementBarCodesTableAdapter();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlButtons.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarCodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemMeasurementBarCodesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsMeasurement)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 171);
            this.pnlButtons.Size = new System.Drawing.Size(252, 43);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(252, 41);
            this.panel1.TabIndex = 101;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "Нажмите клавишу Delete для удаления выбранного штрих-кода:";
            // 
            // dgvBarCodes
            // 
            this.dgvBarCodes.AllowUserToAddRows = false;
            this.dgvBarCodes.AllowUserToResizeRows = false;
            this.dgvBarCodes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBarCodes.AutoGenerateColumns = false;
            this.dgvBarCodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBarCodes.ColumnHeadersVisible = false;
            this.dgvBarCodes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.barCodesDataGridViewTextBoxColumn});
            this.dgvBarCodes.DataSource = this.itemMeasurementBarCodesBindingSource;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBarCodes.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBarCodes.Location = new System.Drawing.Point(0, 41);
            this.dgvBarCodes.MultiSelect = false;
            this.dgvBarCodes.Name = "dgvBarCodes";
            this.dgvBarCodes.ReadOnly = true;
            this.dgvBarCodes.RowHeadersVisible = false;
            this.dgvBarCodes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBarCodes.Size = new System.Drawing.Size(252, 132);
            this.dgvBarCodes.TabIndex = 102;
            this.dgvBarCodes.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvBarCodes_UserDeletingRow);
            this.dgvBarCodes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBarCodes_CellDoubleClick);
            // 
            // barCodesDataGridViewTextBoxColumn
            // 
            this.barCodesDataGridViewTextBoxColumn.DataPropertyName = "BarCodes";
            this.barCodesDataGridViewTextBoxColumn.HeaderText = "Штрих - код";
            this.barCodesDataGridViewTextBoxColumn.Name = "barCodesDataGridViewTextBoxColumn";
            this.barCodesDataGridViewTextBoxColumn.ReadOnly = true;
            this.barCodesDataGridViewTextBoxColumn.Width = 200;
            // 
            // itemMeasurementBarCodesBindingSource
            // 
            this.itemMeasurementBarCodesBindingSource.DataMember = "ItemMeasurementBarCodes";
            this.itemMeasurementBarCodesBindingSource.DataSource = this.itemsMeasurement;
            // 
            // itemsMeasurement
            // 
            this.itemsMeasurement.DataSetName = "ItemsMeasurement";
            this.itemsMeasurement.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // itemMeasurementBarCodesTableAdapter
            // 
            this.itemMeasurementBarCodesTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "BarCodes";
            this.dataGridViewTextBoxColumn1.HeaderText = "Штрих - код";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // ItemMeasurementBarCodes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 214);
            this.Controls.Add(this.dgvBarCodes);
            this.Controls.Add(this.panel1);
            this.Name = "ItemMeasurementBarCodes";
            this.Text = "Штрих-коды для товара";
            this.Load += new System.EventHandler(this.ItemMeasurementBarCodes_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ItemMeasurementBarCodes_FormClosing);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.dgvBarCodes, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarCodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemMeasurementBarCodesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsMeasurement)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvBarCodes;
        private System.Windows.Forms.BindingSource itemMeasurementBarCodesBindingSource;
        private WMSOffice.Data.ItemsMeasurement itemsMeasurement;
        private WMSOffice.Data.ItemsMeasurementTableAdapters.ItemMeasurementBarCodesTableAdapter itemMeasurementBarCodesTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn barCodesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    }
}