namespace WMSOffice.Window
{
    partial class QualityСonclusionControlWindow
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
            this.toolStripConclusion = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnAccept = new System.Windows.Forms.ToolStripButton();
            this.btnReject = new System.Windows.Forms.ToolStripButton();
            this.dgvConclusions = new System.Windows.Forms.DataGridView();
            this.uphiqGetItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quality = new WMSOffice.Data.Quality();
            this.complaints = new WMSOffice.Data.Complaints();
            this.gbConclusionFilter = new System.Windows.Forms.GroupBox();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.dtpConclusionsTo = new System.Windows.Forms.DateTimePicker();
            this.dtpConclusionsFrom = new System.Windows.Forms.DateTimePicker();
            this.cBShowProccessing = new System.Windows.Forms.CheckBox();
            this.uphiqGetItemsTableAdapter = new WMSOffice.Data.QualityTableAdapters.UphiqGetItemsTableAdapter();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemNameJDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemNameWebDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerNameJDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerNameWebDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.сonclusionDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conclusionNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.registrationNumberJDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.registrationNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotBlockDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expirationDateJDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expirationDateWebDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gMPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Processing_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Processing_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripConclusion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConclusions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uphiqGetItemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).BeginInit();
            this.gbConclusionFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripConclusion
            // 
            this.toolStripConclusion.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStripConclusion.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.btnAccept,
            this.btnReject});
            this.toolStripConclusion.Location = new System.Drawing.Point(0, 40);
            this.toolStripConclusion.Name = "toolStripConclusion";
            this.toolStripConclusion.Size = new System.Drawing.Size(911, 55);
            this.toolStripConclusion.TabIndex = 6;
            this.toolStripConclusion.Text = "Панель инструментов документа";
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(52, 52);
            this.btnRefresh.Text = "Обновить список заключений";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAccept.Image = global::WMSOffice.Properties.Resources.ok;
            this.btnAccept.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(52, 52);
            this.btnAccept.Text = "Подтвердить соответствие товаров";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnReject
            // 
            this.btnReject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReject.Image = global::WMSOffice.Properties.Resources.symbol_stop;
            this.btnReject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(52, 52);
            this.btnReject.Text = "Отклонить соответствие товаров";
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // dgvConclusions
            // 
            this.dgvConclusions.AllowUserToAddRows = false;
            this.dgvConclusions.AllowUserToDeleteRows = false;
            this.dgvConclusions.AllowUserToResizeRows = false;
            this.dgvConclusions.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConclusions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvConclusions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConclusions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemIDDataGridViewTextBoxColumn,
            this.itemNameJDDataGridViewTextBoxColumn,
            this.itemNameWebDataGridViewTextBoxColumn,
            this.manufacturerNameJDDataGridViewTextBoxColumn,
            this.manufacturerNameWebDataGridViewTextBoxColumn,
            this.сonclusionDateDataGridViewTextBoxColumn,
            this.conclusionNumberDataGridViewTextBoxColumn,
            this.registrationNumberJDDataGridViewTextBoxColumn,
            this.registrationNumberDataGridViewTextBoxColumn,
            this.lotNumberDataGridViewTextBoxColumn,
            this.lotBlockDataGridViewTextBoxColumn,
            this.expirationDateJDDataGridViewTextBoxColumn,
            this.expirationDateWebDataGridViewTextBoxColumn,
            this.gMPDataGridViewTextBoxColumn,
            this.Processing_ID,
            this.Processing_Status});
            this.dgvConclusions.DataSource = this.uphiqGetItemsBindingSource;
            this.dgvConclusions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvConclusions.Location = new System.Drawing.Point(0, 139);
            this.dgvConclusions.MultiSelect = false;
            this.dgvConclusions.Name = "dgvConclusions";
            this.dgvConclusions.ReadOnly = true;
            this.dgvConclusions.RowHeadersVisible = false;
            this.dgvConclusions.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dgvConclusions.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Black;
            this.dgvConclusions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConclusions.Size = new System.Drawing.Size(911, 372);
            this.dgvConclusions.TabIndex = 7;
            this.dgvConclusions.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gvConclusions_DataBindingComplete);
            this.dgvConclusions.SelectionChanged += new System.EventHandler(this.dgvConclusions_SelectionChanged);
            // 
            // uphiqGetItemsBindingSource
            // 
            this.uphiqGetItemsBindingSource.DataMember = "UphiqGetItems";
            this.uphiqGetItemsBindingSource.DataSource = this.quality;
            // 
            // quality
            // 
            this.quality.DataSetName = "Quality";
            this.quality.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // complaints
            // 
            this.complaints.DataSetName = "Complaints";
            this.complaints.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gbConclusionFilter
            // 
            this.gbConclusionFilter.Controls.Add(this.tbFilter);
            this.gbConclusionFilter.Controls.Add(this.lblFilter);
            this.gbConclusionFilter.Controls.Add(this.lblDateTo);
            this.gbConclusionFilter.Controls.Add(this.lblDateFrom);
            this.gbConclusionFilter.Controls.Add(this.dtpConclusionsTo);
            this.gbConclusionFilter.Controls.Add(this.dtpConclusionsFrom);
            this.gbConclusionFilter.Controls.Add(this.cBShowProccessing);
            this.gbConclusionFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbConclusionFilter.Location = new System.Drawing.Point(0, 95);
            this.gbConclusionFilter.Name = "gbConclusionFilter";
            this.gbConclusionFilter.Size = new System.Drawing.Size(911, 44);
            this.gbConclusionFilter.TabIndex = 8;
            this.gbConclusionFilter.TabStop = false;
            this.gbConclusionFilter.Text = "Фильтр заключений";
            // 
            // tbFilter
            // 
            this.tbFilter.Location = new System.Drawing.Point(691, 18);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(140, 20);
            this.tbFilter.TabIndex = 6;
            this.tbFilter.TextChanged += new System.EventHandler(this.tbFilter_TextChanged);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(635, 23);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(50, 13);
            this.lblFilter.TabIndex = 5;
            this.lblFilter.Text = "Фильтр:";
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Location = new System.Drawing.Point(403, 23);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(51, 13);
            this.lblDateTo.TabIndex = 4;
            this.lblDateTo.Text = "Дата по:";
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Location = new System.Drawing.Point(172, 23);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(45, 13);
            this.lblDateFrom.TabIndex = 3;
            this.lblDateFrom.Text = "Дата с:";
            // 
            // dtpConclusionsTo
            // 
            this.dtpConclusionsTo.Location = new System.Drawing.Point(460, 19);
            this.dtpConclusionsTo.MaxDate = new System.DateTime(2099, 1, 1, 0, 0, 0, 0);
            this.dtpConclusionsTo.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpConclusionsTo.Name = "dtpConclusionsTo";
            this.dtpConclusionsTo.Size = new System.Drawing.Size(140, 20);
            this.dtpConclusionsTo.TabIndex = 2;
            this.dtpConclusionsTo.Value = new System.DateTime(2011, 7, 25, 0, 0, 0, 0);
            // 
            // dtpConclusionsFrom
            // 
            this.dtpConclusionsFrom.Location = new System.Drawing.Point(223, 19);
            this.dtpConclusionsFrom.MaxDate = new System.DateTime(2099, 1, 1, 0, 0, 0, 0);
            this.dtpConclusionsFrom.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpConclusionsFrom.Name = "dtpConclusionsFrom";
            this.dtpConclusionsFrom.Size = new System.Drawing.Size(140, 20);
            this.dtpConclusionsFrom.TabIndex = 1;
            this.dtpConclusionsFrom.Value = new System.DateTime(2011, 7, 18, 0, 0, 0, 0);
            // 
            // cBShowProccessing
            // 
            this.cBShowProccessing.AutoSize = true;
            this.cBShowProccessing.Location = new System.Drawing.Point(12, 19);
            this.cBShowProccessing.Name = "cBShowProccessing";
            this.cBShowProccessing.Size = new System.Drawing.Size(128, 17);
            this.cBShowProccessing.TabIndex = 0;
            this.cBShowProccessing.Text = "Только к обработке";
            this.cBShowProccessing.UseVisualStyleBackColor = true;
            this.cBShowProccessing.CheckedChanged += new System.EventHandler(this.cBShowProccessing_CheckedChanged);
            // 
            // uphiqGetItemsTableAdapter
            // 
            this.uphiqGetItemsTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Item_ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "Код товара";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Item_Name_JD";
            this.dataGridViewTextBoxColumn2.HeaderText = "Товар";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 300;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Item_Name_Web";
            this.dataGridViewTextBoxColumn3.HeaderText = "Товар (сайт)";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 300;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Manufacturer_Name_JD";
            this.dataGridViewTextBoxColumn4.HeaderText = "Производитель";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 250;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Manufacturer_Name_Web";
            this.dataGridViewTextBoxColumn5.HeaderText = "Производитель (сайт)";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 250;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Сonclusion_Date";
            this.dataGridViewTextBoxColumn6.HeaderText = "Дата заключения";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 90;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Conclusion_Number";
            this.dataGridViewTextBoxColumn7.HeaderText = "№ заключения";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 110;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Registration_Number_JD";
            this.dataGridViewTextBoxColumn8.HeaderText = "№ регистрации";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 110;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Registration_Number";
            this.dataGridViewTextBoxColumn9.HeaderText = "№ регистрации (сайт)";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 110;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Lot_Number";
            this.dataGridViewTextBoxColumn10.HeaderText = "Серия";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Lot_Block";
            this.dataGridViewTextBoxColumn11.HeaderText = "Блокировка серии";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 200;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Expiration_Date_JD";
            this.dataGridViewTextBoxColumn12.HeaderText = "Окончание рег-ции";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Width = 90;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Expiration_Date_Web";
            this.dataGridViewTextBoxColumn13.HeaderText = "Окончание рег-ции (сайт)";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 90;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "GMP";
            this.dataGridViewTextBoxColumn14.HeaderText = "ГМП";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Width = 250;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "Processing_ID";
            this.dataGridViewTextBoxColumn15.HeaderText = "Processing_ID";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Visible = false;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "Processing_Status";
            this.dataGridViewTextBoxColumn16.HeaderText = "Processing_Status";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            this.dataGridViewTextBoxColumn16.Visible = false;
            // 
            // itemIDDataGridViewTextBoxColumn
            // 
            this.itemIDDataGridViewTextBoxColumn.DataPropertyName = "Item_ID";
            this.itemIDDataGridViewTextBoxColumn.HeaderText = "Код товара";
            this.itemIDDataGridViewTextBoxColumn.Name = "itemIDDataGridViewTextBoxColumn";
            this.itemIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemIDDataGridViewTextBoxColumn.Width = 50;
            // 
            // itemNameJDDataGridViewTextBoxColumn
            // 
            this.itemNameJDDataGridViewTextBoxColumn.DataPropertyName = "Item_Name_JD";
            this.itemNameJDDataGridViewTextBoxColumn.HeaderText = "Товар";
            this.itemNameJDDataGridViewTextBoxColumn.Name = "itemNameJDDataGridViewTextBoxColumn";
            this.itemNameJDDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemNameJDDataGridViewTextBoxColumn.Width = 300;
            // 
            // itemNameWebDataGridViewTextBoxColumn
            // 
            this.itemNameWebDataGridViewTextBoxColumn.DataPropertyName = "Item_Name_Web";
            this.itemNameWebDataGridViewTextBoxColumn.HeaderText = "Товар (сайт)";
            this.itemNameWebDataGridViewTextBoxColumn.Name = "itemNameWebDataGridViewTextBoxColumn";
            this.itemNameWebDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemNameWebDataGridViewTextBoxColumn.Width = 300;
            // 
            // manufacturerNameJDDataGridViewTextBoxColumn
            // 
            this.manufacturerNameJDDataGridViewTextBoxColumn.DataPropertyName = "Manufacturer_Name_JD";
            this.manufacturerNameJDDataGridViewTextBoxColumn.HeaderText = "Производитель";
            this.manufacturerNameJDDataGridViewTextBoxColumn.Name = "manufacturerNameJDDataGridViewTextBoxColumn";
            this.manufacturerNameJDDataGridViewTextBoxColumn.ReadOnly = true;
            this.manufacturerNameJDDataGridViewTextBoxColumn.Width = 250;
            // 
            // manufacturerNameWebDataGridViewTextBoxColumn
            // 
            this.manufacturerNameWebDataGridViewTextBoxColumn.DataPropertyName = "Manufacturer_Name_Web";
            this.manufacturerNameWebDataGridViewTextBoxColumn.HeaderText = "Производитель (сайт)";
            this.manufacturerNameWebDataGridViewTextBoxColumn.Name = "manufacturerNameWebDataGridViewTextBoxColumn";
            this.manufacturerNameWebDataGridViewTextBoxColumn.ReadOnly = true;
            this.manufacturerNameWebDataGridViewTextBoxColumn.Width = 250;
            // 
            // сonclusionDateDataGridViewTextBoxColumn
            // 
            this.сonclusionDateDataGridViewTextBoxColumn.DataPropertyName = "Сonclusion_Date";
            this.сonclusionDateDataGridViewTextBoxColumn.HeaderText = "Дата заключения";
            this.сonclusionDateDataGridViewTextBoxColumn.Name = "сonclusionDateDataGridViewTextBoxColumn";
            this.сonclusionDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.сonclusionDateDataGridViewTextBoxColumn.Width = 90;
            // 
            // conclusionNumberDataGridViewTextBoxColumn
            // 
            this.conclusionNumberDataGridViewTextBoxColumn.DataPropertyName = "Conclusion_Number";
            this.conclusionNumberDataGridViewTextBoxColumn.HeaderText = "№ заключения";
            this.conclusionNumberDataGridViewTextBoxColumn.Name = "conclusionNumberDataGridViewTextBoxColumn";
            this.conclusionNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.conclusionNumberDataGridViewTextBoxColumn.Width = 110;
            // 
            // registrationNumberJDDataGridViewTextBoxColumn
            // 
            this.registrationNumberJDDataGridViewTextBoxColumn.DataPropertyName = "Registration_Number_JD";
            this.registrationNumberJDDataGridViewTextBoxColumn.HeaderText = "№ регистрации";
            this.registrationNumberJDDataGridViewTextBoxColumn.Name = "registrationNumberJDDataGridViewTextBoxColumn";
            this.registrationNumberJDDataGridViewTextBoxColumn.ReadOnly = true;
            this.registrationNumberJDDataGridViewTextBoxColumn.Width = 110;
            // 
            // registrationNumberDataGridViewTextBoxColumn
            // 
            this.registrationNumberDataGridViewTextBoxColumn.DataPropertyName = "Registration_Number";
            this.registrationNumberDataGridViewTextBoxColumn.HeaderText = "№ регистрации (сайт)";
            this.registrationNumberDataGridViewTextBoxColumn.Name = "registrationNumberDataGridViewTextBoxColumn";
            this.registrationNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.registrationNumberDataGridViewTextBoxColumn.Width = 110;
            // 
            // lotNumberDataGridViewTextBoxColumn
            // 
            this.lotNumberDataGridViewTextBoxColumn.DataPropertyName = "Lot_Number";
            this.lotNumberDataGridViewTextBoxColumn.HeaderText = "Серия";
            this.lotNumberDataGridViewTextBoxColumn.Name = "lotNumberDataGridViewTextBoxColumn";
            this.lotNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lotBlockDataGridViewTextBoxColumn
            // 
            this.lotBlockDataGridViewTextBoxColumn.DataPropertyName = "Lot_Block";
            this.lotBlockDataGridViewTextBoxColumn.HeaderText = "Блокировка серии";
            this.lotBlockDataGridViewTextBoxColumn.Name = "lotBlockDataGridViewTextBoxColumn";
            this.lotBlockDataGridViewTextBoxColumn.ReadOnly = true;
            this.lotBlockDataGridViewTextBoxColumn.Width = 200;
            // 
            // expirationDateJDDataGridViewTextBoxColumn
            // 
            this.expirationDateJDDataGridViewTextBoxColumn.DataPropertyName = "Expiration_Date_JD";
            this.expirationDateJDDataGridViewTextBoxColumn.HeaderText = "Окончание рег-ции";
            this.expirationDateJDDataGridViewTextBoxColumn.Name = "expirationDateJDDataGridViewTextBoxColumn";
            this.expirationDateJDDataGridViewTextBoxColumn.ReadOnly = true;
            this.expirationDateJDDataGridViewTextBoxColumn.Width = 90;
            // 
            // expirationDateWebDataGridViewTextBoxColumn
            // 
            this.expirationDateWebDataGridViewTextBoxColumn.DataPropertyName = "Expiration_Date_Web";
            this.expirationDateWebDataGridViewTextBoxColumn.HeaderText = "Окончание рег-ции (сайт)";
            this.expirationDateWebDataGridViewTextBoxColumn.Name = "expirationDateWebDataGridViewTextBoxColumn";
            this.expirationDateWebDataGridViewTextBoxColumn.ReadOnly = true;
            this.expirationDateWebDataGridViewTextBoxColumn.Width = 90;
            // 
            // gMPDataGridViewTextBoxColumn
            // 
            this.gMPDataGridViewTextBoxColumn.DataPropertyName = "GMP";
            this.gMPDataGridViewTextBoxColumn.HeaderText = "ГМП";
            this.gMPDataGridViewTextBoxColumn.Name = "gMPDataGridViewTextBoxColumn";
            this.gMPDataGridViewTextBoxColumn.ReadOnly = true;
            this.gMPDataGridViewTextBoxColumn.Width = 250;
            // 
            // Processing_ID
            // 
            this.Processing_ID.DataPropertyName = "Processing_ID";
            this.Processing_ID.HeaderText = "Processing_ID";
            this.Processing_ID.Name = "Processing_ID";
            this.Processing_ID.ReadOnly = true;
            this.Processing_ID.Visible = false;
            // 
            // Processing_Status
            // 
            this.Processing_Status.DataPropertyName = "Processing_Status";
            this.Processing_Status.HeaderText = "Processing_Status";
            this.Processing_Status.Name = "Processing_Status";
            this.Processing_Status.ReadOnly = true;
            this.Processing_Status.Visible = false;
            // 
            // QualityСonclusionControlWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 511);
            this.Controls.Add(this.dgvConclusions);
            this.Controls.Add(this.gbConclusionFilter);
            this.Controls.Add(this.toolStripConclusion);
            this.Name = "QualityСonclusionControlWindow";
            this.Text = "Контроль заключений выданных УФИЯ";
            this.Shown += new System.EventHandler(this.QualityСonclusionControlWindow_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QualityСonclusionControlWindow_FormClosing);
            this.Controls.SetChildIndex(this.toolStripConclusion, 0);
            this.Controls.SetChildIndex(this.gbConclusionFilter, 0);
            this.Controls.SetChildIndex(this.dgvConclusions, 0);
            this.toolStripConclusion.ResumeLayout(false);
            this.toolStripConclusion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConclusions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uphiqGetItemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).EndInit();
            this.gbConclusionFilter.ResumeLayout(false);
            this.gbConclusionFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripConclusion;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.DataGridView dgvConclusions;
        private WMSOffice.Data.Complaints complaints;
        private System.Windows.Forms.BindingSource uphiqGetItemsBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNameJDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNameWebDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerNameJDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerNameWebDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn сonclusionDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn conclusionNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn registrationNumberJDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn registrationNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotBlockDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expirationDateJDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expirationDateWebDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gMPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Processing_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Processing_Status;
        private WMSOffice.Data.Quality quality;
        private WMSOffice.Data.QualityTableAdapters.UphiqGetItemsTableAdapter uphiqGetItemsTableAdapter;
        private System.Windows.Forms.GroupBox gbConclusionFilter;
        private System.Windows.Forms.CheckBox cBShowProccessing;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.DateTimePicker dtpConclusionsTo;
        private System.Windows.Forms.DateTimePicker dtpConclusionsFrom;
        private System.Windows.Forms.ToolStripButton btnAccept;
        private System.Windows.Forms.ToolStripButton btnReject;
        private System.Windows.Forms.TextBox tbFilter;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
    }
}