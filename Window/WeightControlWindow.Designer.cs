namespace WMSOffice.Window
{
    partial class WeightControlWindow
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
            this.lblPlanWeight = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPickID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.stbBoxScanner = new WMSOffice.Controls.TextBoxScaner();
            this.dgvDocs = new System.Windows.Forms.DataGridView();
            this.docdateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.psnidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.planweightDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.factweightDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reasonnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weightControlDocsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pickControl = new WMSOffice.Data.PickControl();
            this.pnlMainLayout = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.weightControlDocsTableAdapter = new WMSOffice.Data.PickControlTableAdapters.WeightControlDocsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weightControlDocsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).BeginInit();
            this.pnlMainLayout.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPlanWeight
            // 
            this.lblPlanWeight.AutoSize = true;
            this.lblPlanWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPlanWeight.ForeColor = System.Drawing.Color.Blue;
            this.lblPlanWeight.Location = new System.Drawing.Point(541, 27);
            this.lblPlanWeight.Name = "lblPlanWeight";
            this.lblPlanWeight.Size = new System.Drawing.Size(13, 16);
            this.lblPlanWeight.TabIndex = 5;
            this.lblPlanWeight.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(403, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Плановый вес, г :";
            // 
            // lblPickID
            // 
            this.lblPickID.AutoSize = true;
            this.lblPickID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPickID.ForeColor = System.Drawing.Color.Blue;
            this.lblPickID.Location = new System.Drawing.Point(541, 8);
            this.lblPickID.Name = "lblPickID";
            this.lblPickID.Size = new System.Drawing.Size(13, 16);
            this.lblPickID.TabIndex = 3;
            this.lblPickID.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(403, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "№ сборочного :";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Отсканируйте ящик с товаром:";
            // 
            // stbBoxScanner
            // 
            this.stbBoxScanner.AllowType = true;
            this.stbBoxScanner.AutoConvert = true;
            this.stbBoxScanner.DelayThreshold = 50;
            this.stbBoxScanner.Location = new System.Drawing.Point(147, 13);
            this.stbBoxScanner.Name = "stbBoxScanner";
            this.stbBoxScanner.RaiseTextChangeWithoutEnter = false;
            this.stbBoxScanner.ReadOnly = false;
            this.stbBoxScanner.Size = new System.Drawing.Size(250, 25);
            this.stbBoxScanner.TabIndex = 1;
            this.stbBoxScanner.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.stbBoxScanner.UseParentFont = false;
            this.stbBoxScanner.UseScanModeOnly = false;
            this.stbBoxScanner.TextChanged += new System.EventHandler(this.stbBoxScanner_TextChanged);
            // 
            // dgvDocs
            // 
            this.dgvDocs.AllowUserToAddRows = false;
            this.dgvDocs.AllowUserToDeleteRows = false;
            this.dgvDocs.AllowUserToResizeRows = false;
            this.dgvDocs.AutoGenerateColumns = false;
            this.dgvDocs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDocs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDocs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.docdateDataGridViewTextBoxColumn,
            this.psnidDataGridViewTextBoxColumn,
            this.planweightDataGridViewTextBoxColumn,
            this.factweightDataGridViewTextBoxColumn,
            this.reasonnameDataGridViewTextBoxColumn});
            this.dgvDocs.DataSource = this.weightControlDocsBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDocs.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocs.Location = new System.Drawing.Point(0, 50);
            this.dgvDocs.MultiSelect = false;
            this.dgvDocs.Name = "dgvDocs";
            this.dgvDocs.ReadOnly = true;
            this.dgvDocs.RowHeadersVisible = false;
            this.dgvDocs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocs.Size = new System.Drawing.Size(1158, 464);
            this.dgvDocs.TabIndex = 1;
            this.dgvDocs.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvDocs_DataBindingComplete);
            // 
            // docdateDataGridViewTextBoxColumn
            // 
            this.docdateDataGridViewTextBoxColumn.DataPropertyName = "doc_date";
            this.docdateDataGridViewTextBoxColumn.HeaderText = "Дата проведения";
            this.docdateDataGridViewTextBoxColumn.Name = "docdateDataGridViewTextBoxColumn";
            this.docdateDataGridViewTextBoxColumn.ReadOnly = true;
            this.docdateDataGridViewTextBoxColumn.Width = 134;
            // 
            // psnidDataGridViewTextBoxColumn
            // 
            this.psnidDataGridViewTextBoxColumn.DataPropertyName = "psn_id";
            this.psnidDataGridViewTextBoxColumn.HeaderText = "Сборочный";
            this.psnidDataGridViewTextBoxColumn.Name = "psnidDataGridViewTextBoxColumn";
            this.psnidDataGridViewTextBoxColumn.ReadOnly = true;
            this.psnidDataGridViewTextBoxColumn.Width = 107;
            // 
            // planweightDataGridViewTextBoxColumn
            // 
            this.planweightDataGridViewTextBoxColumn.DataPropertyName = "plan_weight";
            this.planweightDataGridViewTextBoxColumn.HeaderText = "Плановый вес, г";
            this.planweightDataGridViewTextBoxColumn.Name = "planweightDataGridViewTextBoxColumn";
            this.planweightDataGridViewTextBoxColumn.ReadOnly = true;
            this.planweightDataGridViewTextBoxColumn.Width = 126;
            // 
            // factweightDataGridViewTextBoxColumn
            // 
            this.factweightDataGridViewTextBoxColumn.DataPropertyName = "fact_weight";
            this.factweightDataGridViewTextBoxColumn.HeaderText = "Фактический вес, г";
            this.factweightDataGridViewTextBoxColumn.Name = "factweightDataGridViewTextBoxColumn";
            this.factweightDataGridViewTextBoxColumn.ReadOnly = true;
            this.factweightDataGridViewTextBoxColumn.Width = 144;
            // 
            // reasonnameDataGridViewTextBoxColumn
            // 
            this.reasonnameDataGridViewTextBoxColumn.DataPropertyName = "Reason_name";
            this.reasonnameDataGridViewTextBoxColumn.HeaderText = "Результат";
            this.reasonnameDataGridViewTextBoxColumn.Name = "reasonnameDataGridViewTextBoxColumn";
            this.reasonnameDataGridViewTextBoxColumn.ReadOnly = true;
            this.reasonnameDataGridViewTextBoxColumn.Width = 103;
            // 
            // weightControlDocsBindingSource
            // 
            this.weightControlDocsBindingSource.DataMember = "WeightControlDocs";
            this.weightControlDocsBindingSource.DataSource = this.pickControl;
            // 
            // pickControl
            // 
            this.pickControl.DataSetName = "PickControl";
            this.pickControl.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pnlMainLayout
            // 
            this.pnlMainLayout.Controls.Add(this.dgvDocs);
            this.pnlMainLayout.Controls.Add(this.panel1);
            this.pnlMainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainLayout.Location = new System.Drawing.Point(0, 40);
            this.pnlMainLayout.Name = "pnlMainLayout";
            this.pnlMainLayout.Size = new System.Drawing.Size(1158, 514);
            this.pnlMainLayout.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblResult);
            this.panel1.Controls.Add(this.lblPlanWeight);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.stbBoxScanner);
            this.panel1.Controls.Add(this.lblPickID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1158, 50);
            this.panel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(631, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Результат :";
            // 
            // lblResult
            // 
            this.lblResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblResult.Location = new System.Drawing.Point(736, 8);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(419, 35);
            this.lblResult.TabIndex = 7;
            this.lblResult.Text = "-";
            // 
            // weightControlDocsTableAdapter
            // 
            this.weightControlDocsTableAdapter.ClearBeforeFill = true;
            // 
            // WeightControlWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 554);
            this.Controls.Add(this.pnlMainLayout);
            this.Name = "WeightControlWindow";
            this.Text = "WeightControlWindow";
            this.Controls.SetChildIndex(this.pnlMainLayout, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weightControlDocsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).EndInit();
            this.pnlMainLayout.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private WMSOffice.Controls.TextBoxScaner stbBoxScanner;
        private System.Windows.Forms.Label lblPlanWeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPickID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvDocs;
        private System.Windows.Forms.Panel pnlMainLayout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource weightControlDocsBindingSource;
        private WMSOffice.Data.PickControl pickControl;
        private WMSOffice.Data.PickControlTableAdapters.WeightControlDocsTableAdapter weightControlDocsTableAdapter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn docdateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn psnidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn planweightDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn factweightDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reasonnameDataGridViewTextBoxColumn;
    }
}