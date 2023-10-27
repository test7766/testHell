namespace WMSOffice.Dialogs.Delivery
{
    partial class DeliverySensorsOnRoute
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
            this.dgvSensorsOnRoute = new System.Windows.Forms.DataGridView();
            this.aMDocsIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateOutDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.driverNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sensorNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientAddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.relatedPickSlipNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.routeListNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sensorsOnRouteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.delivery = new WMSOffice.Data.Delivery();
            this.sensorsOnRouteTableAdapter = new WMSOffice.Data.DeliveryTableAdapters.SensorsOnRouteTableAdapter();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSensorsOnRoute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sensorsOnRouteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.delivery)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(3393, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(3483, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 429);
            this.pnlButtons.Size = new System.Drawing.Size(994, 43);
            // 
            // dgvSensorsOnRoute
            // 
            this.dgvSensorsOnRoute.AllowUserToAddRows = false;
            this.dgvSensorsOnRoute.AllowUserToDeleteRows = false;
            this.dgvSensorsOnRoute.AllowUserToOrderColumns = true;
            this.dgvSensorsOnRoute.AllowUserToResizeRows = false;
            this.dgvSensorsOnRoute.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSensorsOnRoute.AutoGenerateColumns = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSensorsOnRoute.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSensorsOnRoute.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSensorsOnRoute.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.aMDocsIDDataGridViewTextBoxColumn,
            this.dateOutDataGridViewTextBoxColumn,
            this.driverNameDataGridViewTextBoxColumn,
            this.sensorNameDataGridViewTextBoxColumn,
            this.clientNameDataGridViewTextBoxColumn,
            this.clientAddressDataGridViewTextBoxColumn,
            this.relatedPickSlipNumberDataGridViewTextBoxColumn,
            this.routeListNumberDataGridViewTextBoxColumn});
            this.dgvSensorsOnRoute.DataSource = this.sensorsOnRouteBindingSource;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSensorsOnRoute.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSensorsOnRoute.Location = new System.Drawing.Point(0, 1);
            this.dgvSensorsOnRoute.MultiSelect = false;
            this.dgvSensorsOnRoute.Name = "dgvSensorsOnRoute";
            this.dgvSensorsOnRoute.ReadOnly = true;
            this.dgvSensorsOnRoute.RowHeadersVisible = false;
            this.dgvSensorsOnRoute.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSensorsOnRoute.Size = new System.Drawing.Size(994, 422);
            this.dgvSensorsOnRoute.TabIndex = 101;
            // 
            // aMDocsIDDataGridViewTextBoxColumn
            // 
            this.aMDocsIDDataGridViewTextBoxColumn.DataPropertyName = "AM_Docs_ID";
            this.aMDocsIDDataGridViewTextBoxColumn.HeaderText = "№ акта вакцины";
            this.aMDocsIDDataGridViewTextBoxColumn.Name = "aMDocsIDDataGridViewTextBoxColumn";
            this.aMDocsIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateOutDataGridViewTextBoxColumn
            // 
            this.dateOutDataGridViewTextBoxColumn.DataPropertyName = "Date_Out";
            this.dateOutDataGridViewTextBoxColumn.HeaderText = "Время забора вакцины на маршрут";
            this.dateOutDataGridViewTextBoxColumn.Name = "dateOutDataGridViewTextBoxColumn";
            this.dateOutDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateOutDataGridViewTextBoxColumn.ToolTipText = "Время сканирования водителем своего пропуска";
            this.dateOutDataGridViewTextBoxColumn.Width = 200;
            // 
            // driverNameDataGridViewTextBoxColumn
            // 
            this.driverNameDataGridViewTextBoxColumn.DataPropertyName = "Driver_Name";
            this.driverNameDataGridViewTextBoxColumn.HeaderText = "Водитель";
            this.driverNameDataGridViewTextBoxColumn.Name = "driverNameDataGridViewTextBoxColumn";
            this.driverNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.driverNameDataGridViewTextBoxColumn.Width = 300;
            // 
            // sensorNameDataGridViewTextBoxColumn
            // 
            this.sensorNameDataGridViewTextBoxColumn.DataPropertyName = "Sensor_Name";
            this.sensorNameDataGridViewTextBoxColumn.HeaderText = "Ш/К логгера";
            this.sensorNameDataGridViewTextBoxColumn.Name = "sensorNameDataGridViewTextBoxColumn";
            this.sensorNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.sensorNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // clientNameDataGridViewTextBoxColumn
            // 
            this.clientNameDataGridViewTextBoxColumn.DataPropertyName = "ClientName";
            this.clientNameDataGridViewTextBoxColumn.HeaderText = "Клиент";
            this.clientNameDataGridViewTextBoxColumn.Name = "clientNameDataGridViewTextBoxColumn";
            this.clientNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.clientNameDataGridViewTextBoxColumn.Width = 350;
            // 
            // clientAddressDataGridViewTextBoxColumn
            // 
            this.clientAddressDataGridViewTextBoxColumn.DataPropertyName = "ClientAddress";
            this.clientAddressDataGridViewTextBoxColumn.HeaderText = "Адрес";
            this.clientAddressDataGridViewTextBoxColumn.Name = "clientAddressDataGridViewTextBoxColumn";
            this.clientAddressDataGridViewTextBoxColumn.ReadOnly = true;
            this.clientAddressDataGridViewTextBoxColumn.Width = 350;
            // 
            // relatedPickSlipNumberDataGridViewTextBoxColumn
            // 
            this.relatedPickSlipNumberDataGridViewTextBoxColumn.DataPropertyName = "RelatedPickSlipNumber";
            this.relatedPickSlipNumberDataGridViewTextBoxColumn.HeaderText = "Сборочный";
            this.relatedPickSlipNumberDataGridViewTextBoxColumn.Name = "relatedPickSlipNumberDataGridViewTextBoxColumn";
            this.relatedPickSlipNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.relatedPickSlipNumberDataGridViewTextBoxColumn.Width = 150;
            // 
            // routeListNumberDataGridViewTextBoxColumn
            // 
            this.routeListNumberDataGridViewTextBoxColumn.DataPropertyName = "Route_List_Number";
            this.routeListNumberDataGridViewTextBoxColumn.HeaderText = "МЛ";
            this.routeListNumberDataGridViewTextBoxColumn.Name = "routeListNumberDataGridViewTextBoxColumn";
            this.routeListNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sensorsOnRouteBindingSource
            // 
            this.sensorsOnRouteBindingSource.DataMember = "SensorsOnRoute";
            this.sensorsOnRouteBindingSource.DataSource = this.delivery;
            // 
            // delivery
            // 
            this.delivery.DataSetName = "Delivery";
            this.delivery.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sensorsOnRouteTableAdapter
            // 
            this.sensorsOnRouteTableAdapter.ClearBeforeFill = true;
            // 
            // DeliverySensorsOnRoute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 472);
            this.Controls.Add(this.dgvSensorsOnRoute);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "DeliverySensorsOnRoute";
            this.Text = "Логгеры на маршруте";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DeliverySensorsOnRoute_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DeliverySensorsOnRoute_FormClosed);
            this.Controls.SetChildIndex(this.dgvSensorsOnRoute, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSensorsOnRoute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sensorsOnRouteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.delivery)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSensorsOnRoute;
        private System.Windows.Forms.BindingSource sensorsOnRouteBindingSource;
        private WMSOffice.Data.Delivery delivery;
        private WMSOffice.Data.DeliveryTableAdapters.SensorsOnRouteTableAdapter sensorsOnRouteTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn aMDocsIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateOutDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn driverNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sensorNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientAddressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn relatedPickSlipNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn routeListNumberDataGridViewTextBoxColumn;
    }
}