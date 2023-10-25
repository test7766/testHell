namespace WMSOffice.Window
{
    partial class ComplaintCancActPrintWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComplaintCancActPrintWindow));
            this.complaints = new WMSOffice.Data.Complaints();
            this.toolStripDoc = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.btnPrintPreview = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.lblPrinter = new System.Windows.Forms.ToolStripLabel();
            this.cbPrinters = new System.Windows.Forms.ToolStripComboBox();
            this.currentDocsTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.CurrentDocsTableAdapter();
            this.currentDocsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvComplaints = new System.Windows.Forms.DataGridView();
            this.docIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docTypeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateCreatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usersCreatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sourceAddressCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sourceAddressNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sourceAddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordersListDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoicesListDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contactNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commonFaultEmployeeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientLetterSentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dateReceivedFromClientDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateForecastSolutionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warehouseNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateUpdatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usersUpdatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).BeginInit();
            this.toolStripDoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentDocsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComplaints)).BeginInit();
            this.SuspendLayout();
            // 
            // complaints
            // 
            this.complaints.DataSetName = "Complaints";
            this.complaints.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // toolStripDoc
            // 
            this.toolStripDoc.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStripDoc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.toolStripSeparator1,
            this.btnPrint,
            this.btnPrintPreview,
            this.toolStripSeparator2,
            this.btnFind,
            this.toolStripSeparator3,
            this.lblPrinter,
            this.cbPrinters});
            this.toolStripDoc.Location = new System.Drawing.Point(0, 40);
            this.toolStripDoc.Name = "toolStripDoc";
            this.toolStripDoc.Size = new System.Drawing.Size(833, 55);
            this.toolStripDoc.TabIndex = 7;
            this.toolStripDoc.Text = "Панель инструментов документа";
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(52, 52);
            this.btnRefresh.Text = "Обновить список нераспечатанных претензий";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::WMSOffice.Properties.Resources.document_print;
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(123, 52);
            this.btnPrint.Text = "Напечатать\rвыбранные\rакты";
            this.btnPrint.ToolTipText = "Напечатать \rвыбранные \rакты аннулирования";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Image = global::WMSOffice.Properties.Resources.document_print_preview;
            this.btnPrintPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(121, 52);
            this.btnPrintPreview.Text = "Предварит.\rпросмотр";
            this.btnPrintPreview.ToolTipText = "Предварительный \rпросмотр";
            this.btnPrintPreview.Click += new System.EventHandler(this.btnPrintPreview_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // btnFind
            // 
            this.btnFind.Image = global::WMSOffice.Properties.Resources.find;
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(143, 52);
            this.btnFind.Text = "Поиск в архиве";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 55);
            // 
            // lblPrinter
            // 
            this.lblPrinter.Name = "lblPrinter";
            this.lblPrinter.Size = new System.Drawing.Size(58, 52);
            this.lblPrinter.Text = "Принтер:";
            // 
            // cbPrinters
            // 
            this.cbPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPrinters.Name = "cbPrinters";
            this.cbPrinters.Size = new System.Drawing.Size(280, 55);
            // 
            // currentDocsTableAdapter
            // 
            this.currentDocsTableAdapter.ClearBeforeFill = true;
            // 
            // currentDocsBindingSource
            // 
            this.currentDocsBindingSource.DataMember = "CurrentDocs";
            this.currentDocsBindingSource.DataSource = this.complaints;
            // 
            // dgvComplaints
            // 
            this.dgvComplaints.AllowUserToAddRows = false;
            this.dgvComplaints.AllowUserToDeleteRows = false;
            this.dgvComplaints.AllowUserToOrderColumns = true;
            this.dgvComplaints.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgvComplaints.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvComplaints.AutoGenerateColumns = false;
            this.dgvComplaints.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvComplaints.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvComplaints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComplaints.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.docIDDataGridViewTextBoxColumn,
            this.docTypeDataGridViewTextBoxColumn,
            this.docTypeNameDataGridViewTextBoxColumn,
            this.statusIDDataGridViewTextBoxColumn,
            this.statusNameDataGridViewTextBoxColumn,
            this.dateCreatedDataGridViewTextBoxColumn,
            this.usersCreatedDataGridViewTextBoxColumn,
            this.sourceAddressCodeDataGridViewTextBoxColumn,
            this.sourceAddressNameDataGridViewTextBoxColumn,
            this.sourceAddressDataGridViewTextBoxColumn,
            this.ordersListDataGridViewTextBoxColumn,
            this.invoicesListDataGridViewTextBoxColumn,
            this.contactNameDataGridViewTextBoxColumn,
            this.commonFaultEmployeeNameDataGridViewTextBoxColumn,
            this.clientLetterSentDataGridViewTextBoxColumn,
            this.dateReceivedFromClientDataGridViewTextBoxColumn,
            this.dateForecastSolutionDataGridViewTextBoxColumn,
            this.warehouseNameDataGridViewTextBoxColumn,
            this.dateUpdatedDataGridViewTextBoxColumn,
            this.usersUpdatedDataGridViewTextBoxColumn});
            this.dgvComplaints.DataSource = this.currentDocsBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvComplaints.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvComplaints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvComplaints.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvComplaints.Location = new System.Drawing.Point(0, 95);
            this.dgvComplaints.MultiSelect = false;
            this.dgvComplaints.Name = "dgvComplaints";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvComplaints.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvComplaints.RowHeadersVisible = false;
            this.dgvComplaints.RowTemplate.Height = 21;
            this.dgvComplaints.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComplaints.ShowEditingIcon = false;
            this.dgvComplaints.Size = new System.Drawing.Size(833, 355);
            this.dgvComplaints.TabIndex = 8;
            this.dgvComplaints.SelectionChanged += new System.EventHandler(this.dgvComplaints_SelectionChanged);
            // 
            // docIDDataGridViewTextBoxColumn
            // 
            this.docIDDataGridViewTextBoxColumn.DataPropertyName = "First_Doc_ID";
            this.docIDDataGridViewTextBoxColumn.HeaderText = "Код";
            this.docIDDataGridViewTextBoxColumn.Name = "docIDDataGridViewTextBoxColumn";
            this.docIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.docIDDataGridViewTextBoxColumn.Width = 60;
            // 
            // docTypeDataGridViewTextBoxColumn
            // 
            this.docTypeDataGridViewTextBoxColumn.DataPropertyName = "Doc_Type";
            this.docTypeDataGridViewTextBoxColumn.HeaderText = "Тип";
            this.docTypeDataGridViewTextBoxColumn.Name = "docTypeDataGridViewTextBoxColumn";
            this.docTypeDataGridViewTextBoxColumn.Width = 35;
            // 
            // docTypeNameDataGridViewTextBoxColumn
            // 
            this.docTypeNameDataGridViewTextBoxColumn.DataPropertyName = "Doc_Type_Name";
            this.docTypeNameDataGridViewTextBoxColumn.HeaderText = "Назв. типа";
            this.docTypeNameDataGridViewTextBoxColumn.Name = "docTypeNameDataGridViewTextBoxColumn";
            this.docTypeNameDataGridViewTextBoxColumn.Width = 110;
            // 
            // statusIDDataGridViewTextBoxColumn
            // 
            this.statusIDDataGridViewTextBoxColumn.DataPropertyName = "Status_ID";
            this.statusIDDataGridViewTextBoxColumn.HeaderText = "Статус";
            this.statusIDDataGridViewTextBoxColumn.Name = "statusIDDataGridViewTextBoxColumn";
            this.statusIDDataGridViewTextBoxColumn.Width = 50;
            // 
            // statusNameDataGridViewTextBoxColumn
            // 
            this.statusNameDataGridViewTextBoxColumn.DataPropertyName = "Status_Name";
            this.statusNameDataGridViewTextBoxColumn.HeaderText = "Назв. статуса";
            this.statusNameDataGridViewTextBoxColumn.Name = "statusNameDataGridViewTextBoxColumn";
            this.statusNameDataGridViewTextBoxColumn.Width = 180;
            // 
            // dateCreatedDataGridViewTextBoxColumn
            // 
            this.dateCreatedDataGridViewTextBoxColumn.DataPropertyName = "Date_Created";
            this.dateCreatedDataGridViewTextBoxColumn.HeaderText = "Создана";
            this.dateCreatedDataGridViewTextBoxColumn.Name = "dateCreatedDataGridViewTextBoxColumn";
            // 
            // usersCreatedDataGridViewTextBoxColumn
            // 
            this.usersCreatedDataGridViewTextBoxColumn.DataPropertyName = "Users_Created";
            this.usersCreatedDataGridViewTextBoxColumn.HeaderText = "Кем создана";
            this.usersCreatedDataGridViewTextBoxColumn.Name = "usersCreatedDataGridViewTextBoxColumn";
            this.usersCreatedDataGridViewTextBoxColumn.ReadOnly = true;
            this.usersCreatedDataGridViewTextBoxColumn.Width = 140;
            // 
            // sourceAddressCodeDataGridViewTextBoxColumn
            // 
            this.sourceAddressCodeDataGridViewTextBoxColumn.DataPropertyName = "Source_Address_Code";
            this.sourceAddressCodeDataGridViewTextBoxColumn.HeaderText = "Код дост.";
            this.sourceAddressCodeDataGridViewTextBoxColumn.Name = "sourceAddressCodeDataGridViewTextBoxColumn";
            this.sourceAddressCodeDataGridViewTextBoxColumn.Width = 70;
            // 
            // sourceAddressNameDataGridViewTextBoxColumn
            // 
            this.sourceAddressNameDataGridViewTextBoxColumn.DataPropertyName = "Source_Address_Name";
            this.sourceAddressNameDataGridViewTextBoxColumn.HeaderText = "Наименование клиента";
            this.sourceAddressNameDataGridViewTextBoxColumn.Name = "sourceAddressNameDataGridViewTextBoxColumn";
            this.sourceAddressNameDataGridViewTextBoxColumn.Width = 140;
            // 
            // sourceAddressDataGridViewTextBoxColumn
            // 
            this.sourceAddressDataGridViewTextBoxColumn.DataPropertyName = "Source_Address";
            this.sourceAddressDataGridViewTextBoxColumn.HeaderText = "Адрес клиента";
            this.sourceAddressDataGridViewTextBoxColumn.Name = "sourceAddressDataGridViewTextBoxColumn";
            this.sourceAddressDataGridViewTextBoxColumn.Width = 140;
            // 
            // ordersListDataGridViewTextBoxColumn
            // 
            this.ordersListDataGridViewTextBoxColumn.DataPropertyName = "OrdersList";
            this.ordersListDataGridViewTextBoxColumn.HeaderText = "Заказы";
            this.ordersListDataGridViewTextBoxColumn.Name = "ordersListDataGridViewTextBoxColumn";
            // 
            // invoicesListDataGridViewTextBoxColumn
            // 
            this.invoicesListDataGridViewTextBoxColumn.DataPropertyName = "InvoicesList";
            this.invoicesListDataGridViewTextBoxColumn.HeaderText = "№ накладных";
            this.invoicesListDataGridViewTextBoxColumn.Name = "invoicesListDataGridViewTextBoxColumn";
            this.invoicesListDataGridViewTextBoxColumn.Width = 120;
            // 
            // contactNameDataGridViewTextBoxColumn
            // 
            this.contactNameDataGridViewTextBoxColumn.DataPropertyName = "Contact_Name";
            this.contactNameDataGridViewTextBoxColumn.HeaderText = "Контактное лицо";
            this.contactNameDataGridViewTextBoxColumn.Name = "contactNameDataGridViewTextBoxColumn";
            this.contactNameDataGridViewTextBoxColumn.Width = 120;
            // 
            // commonFaultEmployeeNameDataGridViewTextBoxColumn
            // 
            this.commonFaultEmployeeNameDataGridViewTextBoxColumn.DataPropertyName = "Common_Fault_Employee_Name";
            this.commonFaultEmployeeNameDataGridViewTextBoxColumn.HeaderText = "Виновный сотрудник";
            this.commonFaultEmployeeNameDataGridViewTextBoxColumn.Name = "commonFaultEmployeeNameDataGridViewTextBoxColumn";
            this.commonFaultEmployeeNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.commonFaultEmployeeNameDataGridViewTextBoxColumn.Visible = false;
            this.commonFaultEmployeeNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // clientLetterSentDataGridViewTextBoxColumn
            // 
            this.clientLetterSentDataGridViewTextBoxColumn.DataPropertyName = "Client_Letter_Sent";
            this.clientLetterSentDataGridViewTextBoxColumn.HeaderText = "Письмо отправлено";
            this.clientLetterSentDataGridViewTextBoxColumn.Name = "clientLetterSentDataGridViewTextBoxColumn";
            this.clientLetterSentDataGridViewTextBoxColumn.Width = 70;
            // 
            // dateReceivedFromClientDataGridViewTextBoxColumn
            // 
            this.dateReceivedFromClientDataGridViewTextBoxColumn.DataPropertyName = "Date_ReceivedFromClient";
            this.dateReceivedFromClientDataGridViewTextBoxColumn.HeaderText = "Получено от клиента";
            this.dateReceivedFromClientDataGridViewTextBoxColumn.Name = "dateReceivedFromClientDataGridViewTextBoxColumn";
            // 
            // dateForecastSolutionDataGridViewTextBoxColumn
            // 
            this.dateForecastSolutionDataGridViewTextBoxColumn.DataPropertyName = "Date_ForecastSolution";
            this.dateForecastSolutionDataGridViewTextBoxColumn.HeaderText = "Прогн. решения";
            this.dateForecastSolutionDataGridViewTextBoxColumn.Name = "dateForecastSolutionDataGridViewTextBoxColumn";
            this.dateForecastSolutionDataGridViewTextBoxColumn.Width = 70;
            // 
            // warehouseNameDataGridViewTextBoxColumn
            // 
            this.warehouseNameDataGridViewTextBoxColumn.DataPropertyName = "Warehouse_Name";
            this.warehouseNameDataGridViewTextBoxColumn.HeaderText = "Филиал";
            this.warehouseNameDataGridViewTextBoxColumn.Name = "warehouseNameDataGridViewTextBoxColumn";
            this.warehouseNameDataGridViewTextBoxColumn.Width = 140;
            // 
            // dateUpdatedDataGridViewTextBoxColumn
            // 
            this.dateUpdatedDataGridViewTextBoxColumn.DataPropertyName = "Date_Updated";
            this.dateUpdatedDataGridViewTextBoxColumn.HeaderText = "Обновлена";
            this.dateUpdatedDataGridViewTextBoxColumn.Name = "dateUpdatedDataGridViewTextBoxColumn";
            // 
            // usersUpdatedDataGridViewTextBoxColumn
            // 
            this.usersUpdatedDataGridViewTextBoxColumn.DataPropertyName = "Users_Updated";
            this.usersUpdatedDataGridViewTextBoxColumn.HeaderText = "Кем обновлена";
            this.usersUpdatedDataGridViewTextBoxColumn.Name = "usersUpdatedDataGridViewTextBoxColumn";
            this.usersUpdatedDataGridViewTextBoxColumn.ReadOnly = true;
            this.usersUpdatedDataGridViewTextBoxColumn.Width = 140;
            // 
            // ComplaintCancActPrintWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 450);
            this.Controls.Add(this.dgvComplaints);
            this.Controls.Add(this.toolStripDoc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ComplaintCancActPrintWindow";
            this.Text = "ComplaintCancActPrintWindow";
            this.Shown += new System.EventHandler(this.ComplaintCancActPrintWindow_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ComplaintCancActPrintWindow_FormClosing);
            this.Controls.SetChildIndex(this.toolStripDoc, 0);
            this.Controls.SetChildIndex(this.dgvComplaints, 0);
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).EndInit();
            this.toolStripDoc.ResumeLayout(false);
            this.toolStripDoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentDocsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComplaints)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WMSOffice.Data.Complaints complaints;
        private System.Windows.Forms.ToolStrip toolStripDoc;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.ToolStripButton btnPrintPreview;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel lblPrinter;
        private System.Windows.Forms.ToolStripComboBox cbPrinters;
        private WMSOffice.Data.ComplaintsTableAdapters.CurrentDocsTableAdapter currentDocsTableAdapter;
        private System.Windows.Forms.BindingSource currentDocsBindingSource;
        private System.Windows.Forms.DataGridView dgvComplaints;
        private System.Windows.Forms.DataGridViewTextBoxColumn docIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docTypeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateCreatedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usersCreatedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceAddressCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceAddressNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceAddressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordersListDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoicesListDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contactNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn commonFaultEmployeeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clientLetterSentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateReceivedFromClientDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateForecastSolutionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn warehouseNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateUpdatedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usersUpdatedDataGridViewTextBoxColumn;
    }
}