namespace WMSOffice.Dialogs
{
    partial class WOAdminForm
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
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gvWO = new System.Windows.Forms.DataGridView();
            this.docIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.relatedWHDocIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.relatedWHDocTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workOrdersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wo = new WMSOffice.Data.WO();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRepeat = new System.Windows.Forms.ToolStripButton();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.cbStatuses = new System.Windows.Forms.ComboBox();
            this.statusesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTypes = new System.Windows.Forms.ComboBox();
            this.typesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvAssingments = new System.Windows.Forms.DataGridView();
            this.assigIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assigDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.terminalIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assigmentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.btnAddAssingment = new System.Windows.Forms.ToolStripButton();
            this.btnDelAssignment = new System.Windows.Forms.ToolStripButton();
            this.typesTableAdapter = new WMSOffice.Data.WOTableAdapters.TypesTableAdapter();
            this.statusesTableAdapter = new WMSOffice.Data.WOTableAdapters.StatusesTableAdapter();
            this.workOrdersTableAdapter = new WMSOffice.Data.WOTableAdapters.WorkOrdersTableAdapter();
            this.assigmentsTableAdapter = new WMSOffice.Data.WOTableAdapters.AssigmentsTableAdapter();
            this.pnlButtons.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvWO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.workOrdersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wo)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.typesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAssingments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.assigmentsBindingSource)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnClose);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 357);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(685, 45);
            this.pnlButtons.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(598, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gvWO);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainer1.Panel1.Controls.Add(this.pnlFilter);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gvAssingments);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip2);
            this.splitContainer1.Size = new System.Drawing.Size(685, 357);
            this.splitContainer1.SplitterDistance = 228;
            this.splitContainer1.TabIndex = 1;
            // 
            // gvWO
            // 
            this.gvWO.AllowUserToAddRows = false;
            this.gvWO.AllowUserToDeleteRows = false;
            this.gvWO.AllowUserToResizeRows = false;
            this.gvWO.AutoGenerateColumns = false;
            this.gvWO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvWO.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.docIDDataGridViewTextBoxColumn,
            this.docTypeDataGridViewTextBoxColumn,
            this.docDateDataGridViewTextBoxColumn,
            this.statusIDDataGridViewTextBoxColumn,
            this.Status_Name,
            this.relatedWHDocIDDataGridViewTextBoxColumn,
            this.relatedWHDocTypeDataGridViewTextBoxColumn});
            this.gvWO.DataSource = this.workOrdersBindingSource;
            this.gvWO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvWO.Location = new System.Drawing.Point(0, 52);
            this.gvWO.MultiSelect = false;
            this.gvWO.Name = "gvWO";
            this.gvWO.ReadOnly = true;
            this.gvWO.RowHeadersVisible = false;
            this.gvWO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvWO.Size = new System.Drawing.Size(685, 176);
            this.gvWO.TabIndex = 1;
            this.gvWO.SelectionChanged += new System.EventHandler(this.gvWO_SelectionChanged);
            // 
            // docIDDataGridViewTextBoxColumn
            // 
            this.docIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.docIDDataGridViewTextBoxColumn.DataPropertyName = "Doc_ID";
            this.docIDDataGridViewTextBoxColumn.HeaderText = "Задание";
            this.docIDDataGridViewTextBoxColumn.Name = "docIDDataGridViewTextBoxColumn";
            this.docIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.docIDDataGridViewTextBoxColumn.Width = 75;
            // 
            // docTypeDataGridViewTextBoxColumn
            // 
            this.docTypeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.docTypeDataGridViewTextBoxColumn.DataPropertyName = "Doc_Type";
            this.docTypeDataGridViewTextBoxColumn.HeaderText = "Тип";
            this.docTypeDataGridViewTextBoxColumn.Name = "docTypeDataGridViewTextBoxColumn";
            this.docTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.docTypeDataGridViewTextBoxColumn.Width = 51;
            // 
            // docDateDataGridViewTextBoxColumn
            // 
            this.docDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.docDateDataGridViewTextBoxColumn.DataPropertyName = "Doc_Date";
            this.docDateDataGridViewTextBoxColumn.HeaderText = "Дата";
            this.docDateDataGridViewTextBoxColumn.Name = "docDateDataGridViewTextBoxColumn";
            this.docDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.docDateDataGridViewTextBoxColumn.Width = 58;
            // 
            // statusIDDataGridViewTextBoxColumn
            // 
            this.statusIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.statusIDDataGridViewTextBoxColumn.DataPropertyName = "Status_ID";
            this.statusIDDataGridViewTextBoxColumn.HeaderText = "Ст.";
            this.statusIDDataGridViewTextBoxColumn.Name = "statusIDDataGridViewTextBoxColumn";
            this.statusIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusIDDataGridViewTextBoxColumn.Width = 47;
            // 
            // Status_Name
            // 
            this.Status_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Status_Name.DataPropertyName = "Status_Name";
            this.Status_Name.HeaderText = "Статус";
            this.Status_Name.Name = "Status_Name";
            this.Status_Name.ReadOnly = true;
            this.Status_Name.Width = 66;
            // 
            // relatedWHDocIDDataGridViewTextBoxColumn
            // 
            this.relatedWHDocIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.relatedWHDocIDDataGridViewTextBoxColumn.DataPropertyName = "Related_WH_Doc_ID";
            this.relatedWHDocIDDataGridViewTextBoxColumn.HeaderText = "Документ";
            this.relatedWHDocIDDataGridViewTextBoxColumn.Name = "relatedWHDocIDDataGridViewTextBoxColumn";
            this.relatedWHDocIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.relatedWHDocIDDataGridViewTextBoxColumn.Width = 83;
            // 
            // relatedWHDocTypeDataGridViewTextBoxColumn
            // 
            this.relatedWHDocTypeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.relatedWHDocTypeDataGridViewTextBoxColumn.DataPropertyName = "Related_WH_Doc_Type";
            this.relatedWHDocTypeDataGridViewTextBoxColumn.HeaderText = "Тип";
            this.relatedWHDocTypeDataGridViewTextBoxColumn.Name = "relatedWHDocTypeDataGridViewTextBoxColumn";
            this.relatedWHDocTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.relatedWHDocTypeDataGridViewTextBoxColumn.Width = 51;
            // 
            // workOrdersBindingSource
            // 
            this.workOrdersBindingSource.DataMember = "WorkOrders";
            this.workOrdersBindingSource.DataSource = this.wo;
            // 
            // wo
            // 
            this.wo.DataSetName = "WO";
            this.wo.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.toolStripSeparator2,
            this.btnRepeat});
            this.toolStrip1.Location = new System.Drawing.Point(0, 27);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(685, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(170, 22);
            this.btnRefresh.Text = "Обновить список заданий";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnRepeat
            // 
            this.btnRepeat.Enabled = false;
            this.btnRepeat.Image = global::WMSOffice.Properties.Resources.undo43;
            this.btnRepeat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRepeat.Name = "btnRepeat";
            this.btnRepeat.Size = new System.Drawing.Size(204, 22);
            this.btnRepeat.Text = "Повторить выполнение задания";
            this.btnRepeat.Click += new System.EventHandler(this.btnRepeat_Click);
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.cbStatuses);
            this.pnlFilter.Controls.Add(this.label2);
            this.pnlFilter.Controls.Add(this.label1);
            this.pnlFilter.Controls.Add(this.cbTypes);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(685, 27);
            this.pnlFilter.TabIndex = 2;
            // 
            // cbStatuses
            // 
            this.cbStatuses.DataSource = this.statusesBindingSource;
            this.cbStatuses.DisplayMember = "Status_Name";
            this.cbStatuses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatuses.FormattingEnabled = true;
            this.cbStatuses.Location = new System.Drawing.Point(294, 3);
            this.cbStatuses.Name = "cbStatuses";
            this.cbStatuses.Size = new System.Drawing.Size(200, 21);
            this.cbStatuses.TabIndex = 3;
            this.cbStatuses.ValueMember = "Status_ID";
            this.cbStatuses.SelectedIndexChanged += new System.EventHandler(this.cbStatuses_SelectedIndexChanged);
            // 
            // statusesBindingSource
            // 
            this.statusesBindingSource.DataMember = "Statuses";
            this.statusesBindingSource.DataSource = this.wo;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(244, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Статус:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Тип:";
            // 
            // cbTypes
            // 
            this.cbTypes.DataSource = this.typesBindingSource;
            this.cbTypes.DisplayMember = "Doc_Type_Name";
            this.cbTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypes.FormattingEnabled = true;
            this.cbTypes.Location = new System.Drawing.Point(38, 3);
            this.cbTypes.Name = "cbTypes";
            this.cbTypes.Size = new System.Drawing.Size(200, 21);
            this.cbTypes.TabIndex = 0;
            this.cbTypes.ValueMember = "Doc_Type_ID";
            this.cbTypes.SelectedIndexChanged += new System.EventHandler(this.cbTypes_SelectedIndexChanged);
            // 
            // typesBindingSource
            // 
            this.typesBindingSource.DataMember = "Types";
            this.typesBindingSource.DataSource = this.wo;
            // 
            // gvAssingments
            // 
            this.gvAssingments.AllowUserToAddRows = false;
            this.gvAssingments.AllowUserToDeleteRows = false;
            this.gvAssingments.AllowUserToResizeRows = false;
            this.gvAssingments.AutoGenerateColumns = false;
            this.gvAssingments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvAssingments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.assigIDDataGridViewTextBoxColumn,
            this.assigDateDataGridViewTextBoxColumn,
            this.employeeIDDataGridViewTextBoxColumn,
            this.employeeNameDataGridViewTextBoxColumn,
            this.terminalIDDataGridViewTextBoxColumn,
            this.statusIDDataGridViewTextBoxColumn1,
            this.statusNameDataGridViewTextBoxColumn});
            this.gvAssingments.DataSource = this.assigmentsBindingSource;
            this.gvAssingments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvAssingments.Location = new System.Drawing.Point(0, 25);
            this.gvAssingments.MultiSelect = false;
            this.gvAssingments.Name = "gvAssingments";
            this.gvAssingments.ReadOnly = true;
            this.gvAssingments.RowHeadersVisible = false;
            this.gvAssingments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvAssingments.Size = new System.Drawing.Size(685, 100);
            this.gvAssingments.TabIndex = 1;
            this.gvAssingments.SelectionChanged += new System.EventHandler(this.gvAssingments_SelectionChanged);
            // 
            // assigIDDataGridViewTextBoxColumn
            // 
            this.assigIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.assigIDDataGridViewTextBoxColumn.DataPropertyName = "Assig_ID";
            this.assigIDDataGridViewTextBoxColumn.HeaderText = "Назн.";
            this.assigIDDataGridViewTextBoxColumn.Name = "assigIDDataGridViewTextBoxColumn";
            this.assigIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.assigIDDataGridViewTextBoxColumn.Width = 61;
            // 
            // assigDateDataGridViewTextBoxColumn
            // 
            this.assigDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.assigDateDataGridViewTextBoxColumn.DataPropertyName = "Assig_Date";
            this.assigDateDataGridViewTextBoxColumn.HeaderText = "Дата";
            this.assigDateDataGridViewTextBoxColumn.Name = "assigDateDataGridViewTextBoxColumn";
            this.assigDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.assigDateDataGridViewTextBoxColumn.Width = 58;
            // 
            // employeeIDDataGridViewTextBoxColumn
            // 
            this.employeeIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.employeeIDDataGridViewTextBoxColumn.DataPropertyName = "Employee_ID";
            this.employeeIDDataGridViewTextBoxColumn.HeaderText = "Код";
            this.employeeIDDataGridViewTextBoxColumn.Name = "employeeIDDataGridViewTextBoxColumn";
            this.employeeIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.employeeIDDataGridViewTextBoxColumn.Width = 51;
            // 
            // employeeNameDataGridViewTextBoxColumn
            // 
            this.employeeNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.employeeNameDataGridViewTextBoxColumn.DataPropertyName = "Employee_Name";
            this.employeeNameDataGridViewTextBoxColumn.HeaderText = "Сотрудник";
            this.employeeNameDataGridViewTextBoxColumn.Name = "employeeNameDataGridViewTextBoxColumn";
            this.employeeNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.employeeNameDataGridViewTextBoxColumn.Width = 85;
            // 
            // terminalIDDataGridViewTextBoxColumn
            // 
            this.terminalIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.terminalIDDataGridViewTextBoxColumn.DataPropertyName = "Terminal_ID";
            this.terminalIDDataGridViewTextBoxColumn.HeaderText = "Терминал";
            this.terminalIDDataGridViewTextBoxColumn.Name = "terminalIDDataGridViewTextBoxColumn";
            this.terminalIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.terminalIDDataGridViewTextBoxColumn.Width = 83;
            // 
            // statusIDDataGridViewTextBoxColumn1
            // 
            this.statusIDDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.statusIDDataGridViewTextBoxColumn1.DataPropertyName = "Status_ID";
            this.statusIDDataGridViewTextBoxColumn1.HeaderText = "Ст.";
            this.statusIDDataGridViewTextBoxColumn1.Name = "statusIDDataGridViewTextBoxColumn1";
            this.statusIDDataGridViewTextBoxColumn1.ReadOnly = true;
            this.statusIDDataGridViewTextBoxColumn1.Width = 47;
            // 
            // statusNameDataGridViewTextBoxColumn
            // 
            this.statusNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.statusNameDataGridViewTextBoxColumn.DataPropertyName = "Status_Name";
            this.statusNameDataGridViewTextBoxColumn.HeaderText = "Статус";
            this.statusNameDataGridViewTextBoxColumn.Name = "statusNameDataGridViewTextBoxColumn";
            this.statusNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusNameDataGridViewTextBoxColumn.Width = 66;
            // 
            // assigmentsBindingSource
            // 
            this.assigmentsBindingSource.DataMember = "Assigments";
            this.assigmentsBindingSource.DataSource = this.wo;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.btnAddAssingment,
            this.btnDelAssignment});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(685, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(76, 22);
            this.toolStripLabel1.Text = "Назначения:";
            // 
            // btnAddAssingment
            // 
            this.btnAddAssingment.Enabled = false;
            this.btnAddAssingment.Image = global::WMSOffice.Properties.Resources.add;
            this.btnAddAssingment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddAssingment.Name = "btnAddAssingment";
            this.btnAddAssingment.Size = new System.Drawing.Size(79, 22);
            this.btnAddAssingment.Text = "Добавить";
            this.btnAddAssingment.Click += new System.EventHandler(this.btnAddAssingment_Click);
            // 
            // btnDelAssignment
            // 
            this.btnDelAssignment.Enabled = false;
            this.btnDelAssignment.Image = global::WMSOffice.Properties.Resources.close;
            this.btnDelAssignment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelAssignment.Name = "btnDelAssignment";
            this.btnDelAssignment.Size = new System.Drawing.Size(71, 22);
            this.btnDelAssignment.Text = "Удалить";
            this.btnDelAssignment.Click += new System.EventHandler(this.btnDelAssignment_Click);
            // 
            // typesTableAdapter
            // 
            this.typesTableAdapter.ClearBeforeFill = true;
            // 
            // statusesTableAdapter
            // 
            this.statusesTableAdapter.ClearBeforeFill = true;
            // 
            // workOrdersTableAdapter
            // 
            this.workOrdersTableAdapter.ClearBeforeFill = true;
            // 
            // assigmentsTableAdapter
            // 
            this.assigmentsTableAdapter.ClearBeforeFill = true;
            // 
            // WOAdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(685, 402);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.pnlButtons);
            this.MinimizeBox = false;
            this.Name = "WOAdminForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Управление назначениями на ТСД";
            this.Load += new System.EventHandler(this.WOAdminForm_Load);
            this.pnlButtons.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvWO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.workOrdersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wo)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.typesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAssingments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.assigmentsBindingSource)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.DataGridView gvWO;
        private System.Windows.Forms.DataGridView gvAssingments;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton btnAddAssingment;
        private System.Windows.Forms.ToolStripButton btnDelAssignment;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTypes;
        private System.Windows.Forms.ComboBox cbStatuses;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripButton btnRepeat;
        private System.Windows.Forms.BindingSource typesBindingSource;
        private WMSOffice.Data.WO wo;
        private WMSOffice.Data.WOTableAdapters.TypesTableAdapter typesTableAdapter;
        private System.Windows.Forms.BindingSource statusesBindingSource;
        private WMSOffice.Data.WOTableAdapters.StatusesTableAdapter statusesTableAdapter;
        private System.Windows.Forms.BindingSource workOrdersBindingSource;
        private WMSOffice.Data.WOTableAdapters.WorkOrdersTableAdapter workOrdersTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn docIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn relatedWHDocIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn relatedWHDocTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn assigIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn assigDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn terminalIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource assigmentsBindingSource;
        private WMSOffice.Data.WOTableAdapters.AssigmentsTableAdapter assigmentsTableAdapter;
    }
}