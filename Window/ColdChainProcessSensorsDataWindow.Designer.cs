namespace WMSOffice.Window
{
    partial class ColdChainProcessSensorsDataWindow
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
            this.tsToolbar = new System.Windows.Forms.ToolStrip();
            this.sbRefreshData = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.sbFindSensor = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.sbReadSensorData = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.sbOpenTemperatureAccountingReport = new System.Windows.Forms.ToolStripButton();
            this.scMainLayout = new System.Windows.Forms.SplitContainer();
            this.dgvDocs = new System.Windows.Forms.DataGridView();
            this.readOutDocsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.coldChain = new WMSOffice.Data.ColdChain();
            this.xdgvDetails = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.readOutDocsTableAdapter = new WMSOffice.Data.ColdChainTableAdapters.ReadOutDocsTableAdapter();
            this.docidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docdateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.routelistnumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.driversNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormattedWarehouseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsToolbar.SuspendLayout();
            this.scMainLayout.Panel1.SuspendLayout();
            this.scMainLayout.Panel2.SuspendLayout();
            this.scMainLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.readOutDocsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coldChain)).BeginInit();
            this.SuspendLayout();
            // 
            // tsToolbar
            // 
            this.tsToolbar.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbRefreshData,
            this.toolStripSeparator1,
            this.sbFindSensor,
            this.toolStripSeparator2,
            this.sbReadSensorData,
            this.toolStripSeparator3,
            this.sbOpenTemperatureAccountingReport});
            this.tsToolbar.Location = new System.Drawing.Point(0, 40);
            this.tsToolbar.Name = "tsToolbar";
            this.tsToolbar.Size = new System.Drawing.Size(1081, 55);
            this.tsToolbar.TabIndex = 1;
            this.tsToolbar.Text = "toolStrip1";
            // 
            // sbRefreshData
            // 
            this.sbRefreshData.Image = global::WMSOffice.Properties.Resources.refresh;
            this.sbRefreshData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbRefreshData.Name = "sbRefreshData";
            this.sbRefreshData.Size = new System.Drawing.Size(113, 52);
            this.sbRefreshData.Text = "Обновить";
            this.sbRefreshData.Click += new System.EventHandler(this.sbRefreshData_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // sbFindSensor
            // 
            this.sbFindSensor.Image = global::WMSOffice.Properties.Resources.find;
            this.sbFindSensor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbFindSensor.Name = "sbFindSensor";
            this.sbFindSensor.Size = new System.Drawing.Size(94, 52);
            this.sbFindSensor.Text = "Поиск";
            this.sbFindSensor.ToolTipText = "Поиск  закрепленного оборудования";
            this.sbFindSensor.Click += new System.EventHandler(this.sbFindSensor_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // sbReadSensorData
            // 
            this.sbReadSensorData.Image = global::WMSOffice.Properties.Resources.Sensor;
            this.sbReadSensorData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbReadSensorData.Name = "sbReadSensorData";
            this.sbReadSensorData.Size = new System.Drawing.Size(151, 52);
            this.sbReadSensorData.Text = "Снять показания";
            this.sbReadSensorData.Click += new System.EventHandler(this.sbReadSensorData_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 55);
            // 
            // sbOpenTemperatureAccountingReport
            // 
            this.sbOpenTemperatureAccountingReport.Image = global::WMSOffice.Properties.Resources.document_print_preview;
            this.sbOpenTemperatureAccountingReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbOpenTemperatureAccountingReport.Name = "sbOpenTemperatureAccountingReport";
            this.sbOpenTemperatureAccountingReport.Size = new System.Drawing.Size(136, 52);
            this.sbOpenTemperatureAccountingReport.Text = "Журнал учета\nтемператур";
            this.sbOpenTemperatureAccountingReport.Click += new System.EventHandler(this.sbOpenTemperatureAccountingReport_Click);
            // 
            // scMainLayout
            // 
            this.scMainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMainLayout.Location = new System.Drawing.Point(0, 95);
            this.scMainLayout.Name = "scMainLayout";
            this.scMainLayout.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMainLayout.Panel1
            // 
            this.scMainLayout.Panel1.Controls.Add(this.dgvDocs);
            // 
            // scMainLayout.Panel2
            // 
            this.scMainLayout.Panel2.Controls.Add(this.xdgvDetails);
            this.scMainLayout.Size = new System.Drawing.Size(1081, 523);
            this.scMainLayout.SplitterDistance = 350;
            this.scMainLayout.TabIndex = 2;
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
            this.docidDataGridViewTextBoxColumn,
            this.docdateDataGridViewTextBoxColumn,
            this.routelistnumberDataGridViewTextBoxColumn,
            this.driversNameDataGridViewTextBoxColumn,
            this.FormattedWarehouseName});
            this.dgvDocs.DataSource = this.readOutDocsBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDocs.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocs.Location = new System.Drawing.Point(0, 0);
            this.dgvDocs.MultiSelect = false;
            this.dgvDocs.Name = "dgvDocs";
            this.dgvDocs.ReadOnly = true;
            this.dgvDocs.RowHeadersVisible = false;
            this.dgvDocs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocs.Size = new System.Drawing.Size(1081, 350);
            this.dgvDocs.TabIndex = 0;
            this.dgvDocs.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDocs_CellFormatting);
            this.dgvDocs.SelectionChanged += new System.EventHandler(this.dgvDocs_SelectionChanged);
            // 
            // readOutDocsBindingSource
            // 
            this.readOutDocsBindingSource.DataMember = "ReadOutDocs";
            this.readOutDocsBindingSource.DataSource = this.coldChain;
            // 
            // coldChain
            // 
            this.coldChain.DataSetName = "ColdChain";
            this.coldChain.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // xdgvDetails
            // 
            this.xdgvDetails.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvDetails.LargeAmountOfData = false;
            this.xdgvDetails.Location = new System.Drawing.Point(0, 0);
            this.xdgvDetails.Name = "xdgvDetails";
            this.xdgvDetails.RowHeadersVisible = false;
            this.xdgvDetails.Size = new System.Drawing.Size(1081, 169);
            this.xdgvDetails.TabIndex = 0;
            this.xdgvDetails.UserID = ((long)(0));
            // 
            // readOutDocsTableAdapter
            // 
            this.readOutDocsTableAdapter.ClearBeforeFill = true;
            // 
            // docidDataGridViewTextBoxColumn
            // 
            this.docidDataGridViewTextBoxColumn.DataPropertyName = "doc_id";
            this.docidDataGridViewTextBoxColumn.HeaderText = "№ документа";
            this.docidDataGridViewTextBoxColumn.Name = "docidDataGridViewTextBoxColumn";
            this.docidDataGridViewTextBoxColumn.ReadOnly = true;
            this.docidDataGridViewTextBoxColumn.Width = 111;
            // 
            // docdateDataGridViewTextBoxColumn
            // 
            this.docdateDataGridViewTextBoxColumn.DataPropertyName = "doc_date";
            this.docdateDataGridViewTextBoxColumn.HeaderText = "Дата документа";
            this.docdateDataGridViewTextBoxColumn.Name = "docdateDataGridViewTextBoxColumn";
            this.docdateDataGridViewTextBoxColumn.ReadOnly = true;
            this.docdateDataGridViewTextBoxColumn.Width = 127;
            // 
            // routelistnumberDataGridViewTextBoxColumn
            // 
            this.routelistnumberDataGridViewTextBoxColumn.DataPropertyName = "route_list_number";
            this.routelistnumberDataGridViewTextBoxColumn.HeaderText = "№ маршрутного листа";
            this.routelistnumberDataGridViewTextBoxColumn.Name = "routelistnumberDataGridViewTextBoxColumn";
            this.routelistnumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.routelistnumberDataGridViewTextBoxColumn.Width = 162;
            // 
            // driversNameDataGridViewTextBoxColumn
            // 
            this.driversNameDataGridViewTextBoxColumn.DataPropertyName = "Drivers_Name";
            this.driversNameDataGridViewTextBoxColumn.HeaderText = "Водители-экспедиторы";
            this.driversNameDataGridViewTextBoxColumn.Name = "driversNameDataGridViewTextBoxColumn";
            this.driversNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.driversNameDataGridViewTextBoxColumn.Width = 187;
            // 
            // FormattedWarehouseName
            // 
            this.FormattedWarehouseName.DataPropertyName = "FormattedWarehouseName";
            this.FormattedWarehouseName.HeaderText = "Склад";
            this.FormattedWarehouseName.Name = "FormattedWarehouseName";
            this.FormattedWarehouseName.ReadOnly = true;
            this.FormattedWarehouseName.Width = 73;
            // 
            // ColdChainProcessSensorsDataWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 618);
            this.Controls.Add(this.scMainLayout);
            this.Controls.Add(this.tsToolbar);
            this.Name = "ColdChainProcessSensorsDataWindow";
            this.Text = "ColdChainProcessSensorsDataWindow";
            this.Controls.SetChildIndex(this.tsToolbar, 0);
            this.Controls.SetChildIndex(this.scMainLayout, 0);
            this.tsToolbar.ResumeLayout(false);
            this.tsToolbar.PerformLayout();
            this.scMainLayout.Panel1.ResumeLayout(false);
            this.scMainLayout.Panel2.ResumeLayout(false);
            this.scMainLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.readOutDocsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coldChain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsToolbar;
        private System.Windows.Forms.ToolStripButton sbRefreshData;
        private System.Windows.Forms.ToolStripButton sbFindSensor;
        private System.Windows.Forms.ToolStripButton sbReadSensorData;
        private System.Windows.Forms.ToolStripButton sbOpenTemperatureAccountingReport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.SplitContainer scMainLayout;
        private System.Windows.Forms.DataGridView dgvDocs;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvDetails;
        private System.Windows.Forms.BindingSource readOutDocsBindingSource;
        private WMSOffice.Data.ColdChain coldChain;
        private WMSOffice.Data.ColdChainTableAdapters.ReadOutDocsTableAdapter readOutDocsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn docidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docdateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn routelistnumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn driversNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormattedWarehouseName;
    }
}