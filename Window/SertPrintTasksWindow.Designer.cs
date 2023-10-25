namespace WMSOffice.Window
{
    partial class SertPrintTasksWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SertPrintTasksWindow));
            this.toolStripDoc = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnStartStopAutoPrint = new System.Windows.Forms.ToolStripButton();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.btnPrintSelected = new System.Windows.Forms.ToolStripButton();
            this.btnSettings = new System.Windows.Forms.ToolStripButton();
            this.btnDistinctPrint = new System.Windows.Forms.ToolStripButton();
            this.dgvTasks = new System.Windows.Forms.DataGridView();
            this.taskIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dCTODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dOCODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DCT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hostNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stateChangedDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tasksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sert = new WMSOffice.Data.Sert();
            this.pnlLegend = new System.Windows.Forms.Panel();
            this.lblTasksCount = new System.Windows.Forms.Label();
            this.lblTasksCountCaption = new System.Windows.Forms.Label();
            this.lblLegendError = new System.Windows.Forms.Label();
            this.pnlLegendError = new System.Windows.Forms.Panel();
            this.lblLegendThisComp = new System.Windows.Forms.Label();
            this.lblLegendOtherComp = new System.Windows.Forms.Label();
            this.pnlLegendThisComp = new System.Windows.Forms.Panel();
            this.pnlLegendOtherComp = new System.Windows.Forms.Panel();
            this.refreshDataTimer = new System.Windows.Forms.Timer(this.components);
            this.tasksTableAdapter = new WMSOffice.Data.SertTableAdapters.TasksTableAdapter();
            this.gbCurrentInfo = new System.Windows.Forms.GroupBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblTaskID = new System.Windows.Forms.Label();
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.lblTaskState = new System.Windows.Forms.Label();
            this.lblOrderNumberCaption = new System.Windows.Forms.Label();
            this.lblTaskIDCaption = new System.Windows.Forms.Label();
            this.lblCustomerNameCaption = new System.Windows.Forms.Label();
            this.lblTaskStateCaption = new System.Windows.Forms.Label();
            this.refreshCurrentInfoTimer = new System.Windows.Forms.Timer(this.components);
            this.toolStripDoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tasksBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sert)).BeginInit();
            this.pnlLegend.SuspendLayout();
            this.gbCurrentInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripDoc
            // 
            this.toolStripDoc.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStripDoc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.toolStripSeparator2,
            this.btnStartStopAutoPrint,
            this.btnSearch,
            this.btnPrintSelected,
            this.btnSettings,
            this.btnDistinctPrint});
            this.toolStripDoc.Location = new System.Drawing.Point(0, 40);
            this.toolStripDoc.Name = "toolStripDoc";
            this.toolStripDoc.Size = new System.Drawing.Size(1167, 55);
            this.toolStripDoc.TabIndex = 0;
            this.toolStripDoc.Text = "Панель инструментов документа";
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(52, 52);
            this.btnRefresh.Text = "Обновить список\n\r нераспечатанных заказов";
            this.btnRefresh.ToolTipText = "Обновить список нераспечатанных заказов";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // btnStartStopAutoPrint
            // 
            this.btnStartStopAutoPrint.Image = global::WMSOffice.Properties.Resources.start;
            this.btnStartStopAutoPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStartStopAutoPrint.Name = "btnStartStopAutoPrint";
            this.btnStartStopAutoPrint.Size = new System.Drawing.Size(123, 52);
            this.btnStartStopAutoPrint.Text = "Запустить\n\r автоматич.\r печать";
            this.btnStartStopAutoPrint.ToolTipText = "Запустить автоматич. печать";
            this.btnStartStopAutoPrint.Click += new System.EventHandler(this.btnStartStopAutoPrint_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::WMSOffice.Properties.Resources.find;
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(108, 52);
            this.btnSearch.Text = "Поиск\n\r заказа\n\r в архиве";
            this.btnSearch.ToolTipText = "Поиск заказа в архиве";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnPrintSelected
            // 
            this.btnPrintSelected.Enabled = false;
            this.btnPrintSelected.Image = global::WMSOffice.Properties.Resources.document_print;
            this.btnPrintSelected.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintSelected.Name = "btnPrintSelected";
            this.btnPrintSelected.Size = new System.Drawing.Size(127, 52);
            this.btnPrintSelected.Text = "Напечатать\n\r выбранный\n\r заказ";
            this.btnPrintSelected.ToolTipText = "Напечатать выбранный заказ";
            this.btnPrintSelected.Click += new System.EventHandler(this.btnPrintSelected_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Image = global::WMSOffice.Properties.Resources.settings;
            this.btnSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(119, 52);
            this.btnSettings.Text = "Настройки";
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnDistinctPrint
            // 
            this.btnDistinctPrint.Image = global::WMSOffice.Properties.Resources.print;
            this.btnDistinctPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDistinctPrint.Name = "btnDistinctPrint";
            this.btnDistinctPrint.Size = new System.Drawing.Size(134, 52);
            this.btnDistinctPrint.Text = "Печать\n\r для таможни";
            this.btnDistinctPrint.Click += new System.EventHandler(this.btnDistinctPrint_Click);
            // 
            // dgvTasks
            // 
            this.dgvTasks.AllowUserToAddRows = false;
            this.dgvTasks.AllowUserToDeleteRows = false;
            this.dgvTasks.AllowUserToOrderColumns = true;
            this.dgvTasks.AllowUserToResizeRows = false;
            this.dgvTasks.AutoGenerateColumns = false;
            this.dgvTasks.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTasks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTasks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.taskIDDataGridViewTextBoxColumn,
            this.createdDateDataGridViewTextBoxColumn,
            this.dCTODataGridViewTextBoxColumn,
            this.dOCODataGridViewTextBoxColumn,
            this.DCT,
            this.DOC,
            this.customerNameDataGridViewTextBoxColumn,
            this.hostNameDataGridViewTextBoxColumn,
            this.userIDDataGridViewTextBoxColumn,
            this.stateChangedDateDataGridViewTextBoxColumn});
            this.dgvTasks.DataSource = this.tasksBindingSource;
            this.dgvTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTasks.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTasks.Location = new System.Drawing.Point(0, 95);
            this.dgvTasks.MultiSelect = false;
            this.dgvTasks.Name = "dgvTasks";
            this.dgvTasks.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTasks.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTasks.RowHeadersVisible = false;
            this.dgvTasks.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dgvTasks.RowTemplate.Height = 24;
            this.dgvTasks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTasks.ShowRowErrors = false;
            this.dgvTasks.Size = new System.Drawing.Size(1167, 374);
            this.dgvTasks.TabIndex = 2;
            this.dgvTasks.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvTasks_DataBindingComplete);
            // 
            // taskIDDataGridViewTextBoxColumn
            // 
            this.taskIDDataGridViewTextBoxColumn.DataPropertyName = "TaskID";
            this.taskIDDataGridViewTextBoxColumn.HeaderText = "Код";
            this.taskIDDataGridViewTextBoxColumn.Name = "taskIDDataGridViewTextBoxColumn";
            this.taskIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // createdDateDataGridViewTextBoxColumn
            // 
            this.createdDateDataGridViewTextBoxColumn.DataPropertyName = "CreatedDate";
            this.createdDateDataGridViewTextBoxColumn.HeaderText = "Создано";
            this.createdDateDataGridViewTextBoxColumn.Name = "createdDateDataGridViewTextBoxColumn";
            this.createdDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.createdDateDataGridViewTextBoxColumn.Width = 155;
            // 
            // dCTODataGridViewTextBoxColumn
            // 
            this.dCTODataGridViewTextBoxColumn.DataPropertyName = "DCTO";
            this.dCTODataGridViewTextBoxColumn.HeaderText = "Тип зак.";
            this.dCTODataGridViewTextBoxColumn.Name = "dCTODataGridViewTextBoxColumn";
            this.dCTODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dOCODataGridViewTextBoxColumn
            // 
            this.dOCODataGridViewTextBoxColumn.DataPropertyName = "DOCO";
            this.dOCODataGridViewTextBoxColumn.HeaderText = "№ заказа";
            this.dOCODataGridViewTextBoxColumn.Name = "dOCODataGridViewTextBoxColumn";
            this.dOCODataGridViewTextBoxColumn.ReadOnly = true;
            this.dOCODataGridViewTextBoxColumn.Width = 120;
            // 
            // DCT
            // 
            this.DCT.DataPropertyName = "DCT";
            this.DCT.HeaderText = "Тип накл.";
            this.DCT.Name = "DCT";
            this.DCT.ReadOnly = true;
            // 
            // DOC
            // 
            this.DOC.DataPropertyName = "DOC";
            this.DOC.HeaderText = "№ накладной";
            this.DOC.Name = "DOC";
            this.DOC.ReadOnly = true;
            this.DOC.Width = 120;
            // 
            // customerNameDataGridViewTextBoxColumn
            // 
            this.customerNameDataGridViewTextBoxColumn.DataPropertyName = "CustomerName";
            this.customerNameDataGridViewTextBoxColumn.HeaderText = "Заказчик";
            this.customerNameDataGridViewTextBoxColumn.Name = "customerNameDataGridViewTextBoxColumn";
            this.customerNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.customerNameDataGridViewTextBoxColumn.Width = 200;
            // 
            // hostNameDataGridViewTextBoxColumn
            // 
            this.hostNameDataGridViewTextBoxColumn.DataPropertyName = "Host_Name";
            this.hostNameDataGridViewTextBoxColumn.HeaderText = "Компьютер";
            this.hostNameDataGridViewTextBoxColumn.Name = "hostNameDataGridViewTextBoxColumn";
            this.hostNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.hostNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // userIDDataGridViewTextBoxColumn
            // 
            this.userIDDataGridViewTextBoxColumn.DataPropertyName = "User_ID";
            this.userIDDataGridViewTextBoxColumn.HeaderText = "Пользователь";
            this.userIDDataGridViewTextBoxColumn.Name = "userIDDataGridViewTextBoxColumn";
            this.userIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.userIDDataGridViewTextBoxColumn.Width = 200;
            // 
            // stateChangedDateDataGridViewTextBoxColumn
            // 
            this.stateChangedDateDataGridViewTextBoxColumn.DataPropertyName = "StateChangedDate";
            this.stateChangedDateDataGridViewTextBoxColumn.HeaderText = "Дата обработки";
            this.stateChangedDateDataGridViewTextBoxColumn.Name = "stateChangedDateDataGridViewTextBoxColumn";
            this.stateChangedDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.stateChangedDateDataGridViewTextBoxColumn.Width = 155;
            // 
            // tasksBindingSource
            // 
            this.tasksBindingSource.DataMember = "Tasks";
            this.tasksBindingSource.DataSource = this.sert;
            // 
            // sert
            // 
            this.sert.DataSetName = "Sert";
            this.sert.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pnlLegend
            // 
            this.pnlLegend.Controls.Add(this.lblTasksCount);
            this.pnlLegend.Controls.Add(this.lblTasksCountCaption);
            this.pnlLegend.Controls.Add(this.lblLegendError);
            this.pnlLegend.Controls.Add(this.pnlLegendError);
            this.pnlLegend.Controls.Add(this.lblLegendThisComp);
            this.pnlLegend.Controls.Add(this.lblLegendOtherComp);
            this.pnlLegend.Controls.Add(this.pnlLegendThisComp);
            this.pnlLegend.Controls.Add(this.pnlLegendOtherComp);
            this.pnlLegend.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLegend.Location = new System.Drawing.Point(0, 469);
            this.pnlLegend.Name = "pnlLegend";
            this.pnlLegend.Size = new System.Drawing.Size(1167, 97);
            this.pnlLegend.TabIndex = 3;
            // 
            // lblTasksCount
            // 
            this.lblTasksCount.AutoSize = true;
            this.lblTasksCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTasksCount.Location = new System.Drawing.Point(251, 71);
            this.lblTasksCount.Name = "lblTasksCount";
            this.lblTasksCount.Size = new System.Drawing.Size(19, 20);
            this.lblTasksCount.TabIndex = 7;
            this.lblTasksCount.Text = "0";
            // 
            // lblTasksCountCaption
            // 
            this.lblTasksCountCaption.AutoSize = true;
            this.lblTasksCountCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTasksCountCaption.Location = new System.Drawing.Point(8, 71);
            this.lblTasksCountCaption.Name = "lblTasksCountCaption";
            this.lblTasksCountCaption.Size = new System.Drawing.Size(237, 20);
            this.lblTasksCountCaption.TabIndex = 6;
            this.lblTasksCountCaption.Text = "Осталось заданий в очереди:";
            // 
            // lblLegendError
            // 
            this.lblLegendError.AutoSize = true;
            this.lblLegendError.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLegendError.Location = new System.Drawing.Point(194, 48);
            this.lblLegendError.Name = "lblLegendError";
            this.lblLegendError.Size = new System.Drawing.Size(375, 20);
            this.lblLegendError.TabIndex = 5;
            this.lblLegendError.Text = "- во время обработки задания возникла ошибка";
            // 
            // pnlLegendError
            // 
            this.pnlLegendError.BackColor = System.Drawing.Color.LightPink;
            this.pnlLegendError.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLegendError.Location = new System.Drawing.Point(12, 48);
            this.pnlLegendError.Name = "pnlLegendError";
            this.pnlLegendError.Size = new System.Drawing.Size(176, 20);
            this.pnlLegendError.TabIndex = 4;
            // 
            // lblLegendThisComp
            // 
            this.lblLegendThisComp.AutoSize = true;
            this.lblLegendThisComp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLegendThisComp.Location = new System.Drawing.Point(194, 4);
            this.lblLegendThisComp.Name = "lblLegendThisComp";
            this.lblLegendThisComp.Size = new System.Drawing.Size(487, 20);
            this.lblLegendThisComp.TabIndex = 1;
            this.lblLegendThisComp.Text = "- печать сертификатов выполняется текущим пользователем";
            // 
            // lblLegendOtherComp
            // 
            this.lblLegendOtherComp.AutoSize = true;
            this.lblLegendOtherComp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLegendOtherComp.Location = new System.Drawing.Point(194, 26);
            this.lblLegendOtherComp.Name = "lblLegendOtherComp";
            this.lblLegendOtherComp.Size = new System.Drawing.Size(685, 20);
            this.lblLegendOtherComp.TabIndex = 3;
            this.lblLegendOtherComp.Text = "- печать сертификатов выполняется на другом компьютере или другим пользователем";
            // 
            // pnlLegendThisComp
            // 
            this.pnlLegendThisComp.BackColor = System.Drawing.Color.LightGreen;
            this.pnlLegendThisComp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLegendThisComp.Location = new System.Drawing.Point(12, 4);
            this.pnlLegendThisComp.Name = "pnlLegendThisComp";
            this.pnlLegendThisComp.Size = new System.Drawing.Size(176, 20);
            this.pnlLegendThisComp.TabIndex = 0;
            // 
            // pnlLegendOtherComp
            // 
            this.pnlLegendOtherComp.BackColor = System.Drawing.Color.SkyBlue;
            this.pnlLegendOtherComp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLegendOtherComp.Location = new System.Drawing.Point(12, 26);
            this.pnlLegendOtherComp.Name = "pnlLegendOtherComp";
            this.pnlLegendOtherComp.Size = new System.Drawing.Size(176, 20);
            this.pnlLegendOtherComp.TabIndex = 2;
            // 
            // refreshDataTimer
            // 
            this.refreshDataTimer.Interval = 10000;
            this.refreshDataTimer.Tick += new System.EventHandler(this.refreshDataTimer_Tick);
            // 
            // tasksTableAdapter
            // 
            this.tasksTableAdapter.ClearBeforeFill = true;
            // 
            // gbCurrentInfo
            // 
            this.gbCurrentInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCurrentInfo.Controls.Add(this.lblCustomerName);
            this.gbCurrentInfo.Controls.Add(this.lblTaskID);
            this.gbCurrentInfo.Controls.Add(this.lblOrderNumber);
            this.gbCurrentInfo.Controls.Add(this.lblTaskState);
            this.gbCurrentInfo.Controls.Add(this.lblOrderNumberCaption);
            this.gbCurrentInfo.Controls.Add(this.lblTaskIDCaption);
            this.gbCurrentInfo.Controls.Add(this.lblCustomerNameCaption);
            this.gbCurrentInfo.Controls.Add(this.lblTaskStateCaption);
            this.gbCurrentInfo.Location = new System.Drawing.Point(686, 0);
            this.gbCurrentInfo.Name = "gbCurrentInfo";
            this.gbCurrentInfo.Size = new System.Drawing.Size(481, 55);
            this.gbCurrentInfo.TabIndex = 1;
            this.gbCurrentInfo.TabStop = false;
            this.gbCurrentInfo.Text = "Текущее состояние автоматической печати";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCustomerName.Location = new System.Drawing.Point(255, 33);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(11, 13);
            this.lblCustomerName.TabIndex = 7;
            this.lblCustomerName.Text = "-";
            // 
            // lblTaskID
            // 
            this.lblTaskID.AutoSize = true;
            this.lblTaskID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTaskID.Location = new System.Drawing.Point(255, 16);
            this.lblTaskID.Name = "lblTaskID";
            this.lblTaskID.Size = new System.Drawing.Size(11, 13);
            this.lblTaskID.TabIndex = 3;
            this.lblTaskID.Text = "-";
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.AutoSize = true;
            this.lblOrderNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblOrderNumber.Location = new System.Drawing.Point(97, 33);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(11, 13);
            this.lblOrderNumber.TabIndex = 5;
            this.lblOrderNumber.Text = "-";
            // 
            // lblTaskState
            // 
            this.lblTaskState.AutoSize = true;
            this.lblTaskState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTaskState.Location = new System.Drawing.Point(97, 16);
            this.lblTaskState.Name = "lblTaskState";
            this.lblTaskState.Size = new System.Drawing.Size(11, 13);
            this.lblTaskState.TabIndex = 1;
            this.lblTaskState.Text = "-";
            // 
            // lblOrderNumberCaption
            // 
            this.lblOrderNumberCaption.AutoSize = true;
            this.lblOrderNumberCaption.Location = new System.Drawing.Point(6, 33);
            this.lblOrderNumberCaption.Name = "lblOrderNumberCaption";
            this.lblOrderNumberCaption.Size = new System.Drawing.Size(60, 13);
            this.lblOrderNumberCaption.TabIndex = 4;
            this.lblOrderNumberCaption.Text = "№ заказа:";
            // 
            // lblTaskIDCaption
            // 
            this.lblTaskIDCaption.AutoSize = true;
            this.lblTaskIDCaption.Location = new System.Drawing.Point(179, 16);
            this.lblTaskIDCaption.Name = "lblTaskIDCaption";
            this.lblTaskIDCaption.Size = new System.Drawing.Size(74, 13);
            this.lblTaskIDCaption.TabIndex = 2;
            this.lblTaskIDCaption.Text = "Код задания:";
            // 
            // lblCustomerNameCaption
            // 
            this.lblCustomerNameCaption.AutoSize = true;
            this.lblCustomerNameCaption.Location = new System.Drawing.Point(179, 33);
            this.lblCustomerNameCaption.Name = "lblCustomerNameCaption";
            this.lblCustomerNameCaption.Size = new System.Drawing.Size(46, 13);
            this.lblCustomerNameCaption.TabIndex = 6;
            this.lblCustomerNameCaption.Text = "Клиент:";
            // 
            // lblTaskStateCaption
            // 
            this.lblTaskStateCaption.AutoSize = true;
            this.lblTaskStateCaption.Location = new System.Drawing.Point(6, 16);
            this.lblTaskStateCaption.Name = "lblTaskStateCaption";
            this.lblTaskStateCaption.Size = new System.Drawing.Size(89, 13);
            this.lblTaskStateCaption.TabIndex = 0;
            this.lblTaskStateCaption.Text = "Статус задания:";
            // 
            // refreshCurrentInfoTimer
            // 
            this.refreshCurrentInfoTimer.Interval = 200;
            this.refreshCurrentInfoTimer.Tick += new System.EventHandler(this.refreshCurrentInfoTimer_Tick);
            // 
            // SertPrintTasksWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 566);
            this.Controls.Add(this.gbCurrentInfo);
            this.Controls.Add(this.dgvTasks);
            this.Controls.Add(this.pnlLegend);
            this.Controls.Add(this.toolStripDoc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SertPrintTasksWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Печать сертификатов по собранным заказам";
            this.Shown += new System.EventHandler(this.SertPrintTasksWindow_Shown);
            this.Controls.SetChildIndex(this.toolStripDoc, 0);
            this.Controls.SetChildIndex(this.pnlLegend, 0);
            this.Controls.SetChildIndex(this.dgvTasks, 0);
            this.Controls.SetChildIndex(this.gbCurrentInfo, 0);
            this.toolStripDoc.ResumeLayout(false);
            this.toolStripDoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tasksBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sert)).EndInit();
            this.pnlLegend.ResumeLayout(false);
            this.pnlLegend.PerformLayout();
            this.gbCurrentInfo.ResumeLayout(false);
            this.gbCurrentInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripDoc;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton btnStartStopAutoPrint;
        private System.Windows.Forms.DataGridView dgvTasks;
        private System.Windows.Forms.Panel pnlLegend;
        private System.Windows.Forms.Label lblLegendThisComp;
        private System.Windows.Forms.Label lblLegendOtherComp;
        private System.Windows.Forms.Panel pnlLegendThisComp;
        private System.Windows.Forms.Panel pnlLegendOtherComp;
        private System.Windows.Forms.BindingSource tasksBindingSource;
        private WMSOffice.Data.Sert sert;
        private WMSOffice.Data.SertTableAdapters.TasksTableAdapter tasksTableAdapter;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStripButton btnSettings;
        private System.Windows.Forms.ToolStripButton btnPrintSelected;
        private System.Windows.Forms.Timer refreshDataTimer;
        private System.Windows.Forms.Label lblLegendError;
        private System.Windows.Forms.Panel pnlLegendError;
        private System.Windows.Forms.GroupBox gbCurrentInfo;
        private System.Windows.Forms.Label lblTaskStateCaption;
        private System.Windows.Forms.Label lblOrderNumberCaption;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblTaskID;
        private System.Windows.Forms.Label lblOrderNumber;
        private System.Windows.Forms.Label lblTaskState;
        private System.Windows.Forms.Label lblTaskIDCaption;
        private System.Windows.Forms.Label lblCustomerNameCaption;
        private System.Windows.Forms.Timer refreshCurrentInfoTimer;
        private System.Windows.Forms.Label lblTasksCount;
        private System.Windows.Forms.Label lblTasksCountCaption;
        private System.Windows.Forms.ToolStripButton btnDistinctPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dCTODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dOCODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DCT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hostNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stateChangedDateDataGridViewTextBoxColumn;
    }
}