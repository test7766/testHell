namespace WMSOffice.Window
{
    partial class ContainersBalanceReportWindow
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
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.dgvBalanceReport = new System.Windows.Forms.DataGridView();
            this.tareBalanceReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.containers = new WMSOffice.Data.Containers();
            this.tareBalanceReportTableAdapter = new WMSOffice.Data.ContainersTableAdapters.TareBalanceReportTableAdapter();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type_Equipment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isRestDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isReservedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receivedDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isSentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docdateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBalanceReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tareBalanceReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.containers)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.toolStripSeparator1,
            this.btnExport});
            this.tsMain.Location = new System.Drawing.Point(0, 40);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1291, 55);
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
            // btnExport
            // 
            this.btnExport.Image = global::WMSOffice.Properties.Resources.Excel;
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(142, 52);
            this.btnExport.Text = "Экспорт в Excel";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // dgvBalanceReport
            // 
            this.dgvBalanceReport.AllowUserToAddRows = false;
            this.dgvBalanceReport.AllowUserToDeleteRows = false;
            this.dgvBalanceReport.AllowUserToResizeRows = false;
            this.dgvBalanceReport.AutoGenerateColumns = false;
            this.dgvBalanceReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBalanceReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBalanceReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBalanceReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Type_Equipment,
            this.barCodeDataGridViewTextBoxColumn,
            this.isRestDataGridViewTextBoxColumn,
            this.isReservedDataGridViewTextBoxColumn,
            this.receivedDateDataGridViewTextBoxColumn,
            this.isSentDataGridViewTextBoxColumn,
            this.docidDataGridViewTextBoxColumn,
            this.docdateDataGridViewTextBoxColumn,
            this.employeeDataGridViewTextBoxColumn});
            this.dgvBalanceReport.DataSource = this.tareBalanceReportBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBalanceReport.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBalanceReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBalanceReport.Location = new System.Drawing.Point(0, 95);
            this.dgvBalanceReport.MultiSelect = false;
            this.dgvBalanceReport.Name = "dgvBalanceReport";
            this.dgvBalanceReport.ReadOnly = true;
            this.dgvBalanceReport.RowHeadersVisible = false;
            this.dgvBalanceReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBalanceReport.Size = new System.Drawing.Size(1291, 486);
            this.dgvBalanceReport.TabIndex = 2;
            // 
            // tareBalanceReportBindingSource
            // 
            this.tareBalanceReportBindingSource.DataMember = "TareBalanceReport";
            this.tareBalanceReportBindingSource.DataSource = this.containers;
            // 
            // containers
            // 
            this.containers.DataSetName = "Containers";
            this.containers.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tareBalanceReportTableAdapter
            // 
            this.tareBalanceReportTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Bar_Code";
            this.dataGridViewTextBoxColumn1.HeaderText = "Серия";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 73;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "IsRest";
            this.dataGridViewTextBoxColumn2.HeaderText = "Кол-во на балансе";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 141;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "IsReserved";
            this.dataGridViewTextBoxColumn3.HeaderText = "Кол-во на резерве";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 142;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Received_Date";
            this.dataGridViewTextBoxColumn4.HeaderText = "Received_Date";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 128;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "IsSent";
            this.dataGridViewTextBoxColumn5.HeaderText = "IsSent";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 70;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "doc_id";
            this.dataGridViewTextBoxColumn6.HeaderText = "№ документа";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 111;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "doc_date";
            this.dataGridViewTextBoxColumn7.HeaderText = "Дата документа";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 127;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Employee";
            this.dataGridViewTextBoxColumn8.HeaderText = "Сотрудник";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 104;
            // 
            // Type_Equipment
            // 
            this.Type_Equipment.DataPropertyName = "Type_Equipment";
            this.Type_Equipment.HeaderText = "Тип оборудования";
            this.Type_Equipment.Name = "Type_Equipment";
            this.Type_Equipment.ReadOnly = true;
            this.Type_Equipment.Width = 142;
            // 
            // barCodeDataGridViewTextBoxColumn
            // 
            this.barCodeDataGridViewTextBoxColumn.DataPropertyName = "Bar_Code";
            this.barCodeDataGridViewTextBoxColumn.HeaderText = "Код оборудования";
            this.barCodeDataGridViewTextBoxColumn.Name = "barCodeDataGridViewTextBoxColumn";
            this.barCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.barCodeDataGridViewTextBoxColumn.Width = 141;
            // 
            // isRestDataGridViewTextBoxColumn
            // 
            this.isRestDataGridViewTextBoxColumn.DataPropertyName = "IsRest";
            this.isRestDataGridViewTextBoxColumn.HeaderText = "На балансе, шт.";
            this.isRestDataGridViewTextBoxColumn.Name = "isRestDataGridViewTextBoxColumn";
            this.isRestDataGridViewTextBoxColumn.ReadOnly = true;
            this.isRestDataGridViewTextBoxColumn.Width = 123;
            // 
            // isReservedDataGridViewTextBoxColumn
            // 
            this.isReservedDataGridViewTextBoxColumn.DataPropertyName = "IsReserved";
            this.isReservedDataGridViewTextBoxColumn.HeaderText = "Зарезервировано, шт.";
            this.isReservedDataGridViewTextBoxColumn.Name = "isReservedDataGridViewTextBoxColumn";
            this.isReservedDataGridViewTextBoxColumn.ReadOnly = true;
            this.isReservedDataGridViewTextBoxColumn.Width = 163;
            // 
            // receivedDateDataGridViewTextBoxColumn
            // 
            this.receivedDateDataGridViewTextBoxColumn.DataPropertyName = "Received_Date";
            this.receivedDateDataGridViewTextBoxColumn.HeaderText = "Дата получения";
            this.receivedDateDataGridViewTextBoxColumn.Name = "receivedDateDataGridViewTextBoxColumn";
            this.receivedDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.receivedDateDataGridViewTextBoxColumn.Width = 127;
            // 
            // isSentDataGridViewTextBoxColumn
            // 
            this.isSentDataGridViewTextBoxColumn.DataPropertyName = "IsSent";
            this.isSentDataGridViewTextBoxColumn.HeaderText = "Возвращено, шт.";
            this.isSentDataGridViewTextBoxColumn.Name = "isSentDataGridViewTextBoxColumn";
            this.isSentDataGridViewTextBoxColumn.ReadOnly = true;
            this.isSentDataGridViewTextBoxColumn.Width = 128;
            // 
            // docidDataGridViewTextBoxColumn
            // 
            this.docidDataGridViewTextBoxColumn.DataPropertyName = "doc_id";
            this.docidDataGridViewTextBoxColumn.HeaderText = "№ документа возврата";
            this.docidDataGridViewTextBoxColumn.Name = "docidDataGridViewTextBoxColumn";
            this.docidDataGridViewTextBoxColumn.ReadOnly = true;
            this.docidDataGridViewTextBoxColumn.Width = 170;
            // 
            // docdateDataGridViewTextBoxColumn
            // 
            this.docdateDataGridViewTextBoxColumn.DataPropertyName = "doc_date";
            this.docdateDataGridViewTextBoxColumn.HeaderText = "Дата документа возврата";
            this.docdateDataGridViewTextBoxColumn.Name = "docdateDataGridViewTextBoxColumn";
            this.docdateDataGridViewTextBoxColumn.ReadOnly = true;
            this.docdateDataGridViewTextBoxColumn.Width = 186;
            // 
            // employeeDataGridViewTextBoxColumn
            // 
            this.employeeDataGridViewTextBoxColumn.DataPropertyName = "Employee";
            this.employeeDataGridViewTextBoxColumn.HeaderText = "Сотрудник";
            this.employeeDataGridViewTextBoxColumn.Name = "employeeDataGridViewTextBoxColumn";
            this.employeeDataGridViewTextBoxColumn.ReadOnly = true;
            this.employeeDataGridViewTextBoxColumn.Width = 104;
            // 
            // ContainersBalanceReportWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 581);
            this.Controls.Add(this.dgvBalanceReport);
            this.Controls.Add(this.tsMain);
            this.Name = "ContainersBalanceReportWindow";
            this.Text = "ContainersBalanceReportWindow";
            this.Load += new System.EventHandler(this.ContainersBalanceReportWindow_Load);
            this.Controls.SetChildIndex(this.tsMain, 0);
            this.Controls.SetChildIndex(this.dgvBalanceReport, 0);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBalanceReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tareBalanceReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.containers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.DataGridView dgvBalanceReport;
        private System.Windows.Forms.BindingSource tareBalanceReportBindingSource;
        private WMSOffice.Data.Containers containers;
        private WMSOffice.Data.ContainersTableAdapters.TareBalanceReportTableAdapter tareBalanceReportTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnExport;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type_Equipment;
        private System.Windows.Forms.DataGridViewTextBoxColumn barCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn isRestDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn isReservedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn receivedDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn isSentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docdateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeDataGridViewTextBoxColumn;
    }
}