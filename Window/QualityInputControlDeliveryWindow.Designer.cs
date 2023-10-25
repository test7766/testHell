namespace WMSOffice.Window
{
    partial class QualityInputControlDeliveryWindow
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
            this.tsDocs = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnCancelLoading = new System.Windows.Forms.ToolStripButton();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.tssAfterRefresh = new System.Windows.Forms.ToolStripSeparator();
            this.btnEditWorksheet = new System.Windows.Forms.ToolStripButton();
            this.tssAfterEdit = new System.Windows.Forms.ToolStripSeparator();
            this.btnApproveWorksheet = new System.Windows.Forms.ToolStripButton();
            this.tssAfterApprove = new System.Windows.Forms.ToolStripSeparator();
            this.btnUndoWorksheet = new System.Windows.Forms.ToolStripButton();
            this.tssAfterUndo = new System.Windows.Forms.ToolStripSeparator();
            this.btnPreviewWorksheet = new System.Windows.Forms.ToolStripButton();
            this.cmbPrinters = new System.Windows.Forms.ToolStripComboBox();
            this.btnPrintWorksheet = new System.Windows.Forms.ToolStripButton();
            this.btnPrintViolationAct = new System.Windows.Forms.ToolStripButton();
            this.tssAfterPrint = new System.Windows.Forms.ToolStripSeparator();
            this.ssbExportToExcel = new System.Windows.Forms.ToolStripSplitButton();
            this.ssbiExportDocs = new System.Windows.Forms.ToolStripMenuItem();
            this.ssbiExportShipments = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ssbiExportApprovedShipments = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlStatuseFilters = new System.Windows.Forms.Panel();
            this.gbApprovedDocs = new System.Windows.Forms.GroupBox();
            this.chbOnlyApproved = new System.Windows.Forms.CheckBox();
            this.gbStatuses = new System.Windows.Forms.GroupBox();
            this.chbWithSuspectedQuality = new System.Windows.Forms.CheckBox();
            this.chbStatusInWork = new System.Windows.Forms.CheckBox();
            this.chbStatusNotAccepted = new System.Windows.Forms.CheckBox();
            this.chbStatusNew = new System.Windows.Forms.CheckBox();
            this.chbStatusAccepted = new System.Windows.Forms.CheckBox();
            this.edgWorksheets = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.cmsDocs = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.miCancelLoading = new System.Windows.Forms.ToolStripMenuItem();
            this.miSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.tssAfterMiRefresh = new System.Windows.Forms.ToolStripSeparator();
            this.miEditWorksheet = new System.Windows.Forms.ToolStripMenuItem();
            this.tssAfterMiEdit = new System.Windows.Forms.ToolStripSeparator();
            this.miPreviewWorksheet = new System.Windows.Forms.ToolStripMenuItem();
            this.miPrintWorksheet = new System.Windows.Forms.ToolStripMenuItem();
            this.tssAfterMiPrint = new System.Windows.Forms.ToolStripSeparator();
            this.miExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.pbSplashControl = new System.Windows.Forms.PictureBox();
            this.bgwLoader = new System.ComponentModel.BackgroundWorker();
            this.tsDocs.SuspendLayout();
            this.pnlStatuseFilters.SuspendLayout();
            this.gbApprovedDocs.SuspendLayout();
            this.gbStatuses.SuspendLayout();
            this.cmsDocs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSplashControl)).BeginInit();
            this.SuspendLayout();
            // 
            // tsDocs
            // 
            this.tsDocs.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsDocs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.btnCancelLoading,
            this.btnSearch,
            this.tssAfterRefresh,
            this.btnEditWorksheet,
            this.tssAfterEdit,
            this.btnApproveWorksheet,
            this.tssAfterApprove,
            this.btnUndoWorksheet,
            this.tssAfterUndo,
            this.btnPreviewWorksheet,
            this.cmbPrinters,
            this.btnPrintWorksheet,
            this.btnPrintViolationAct,
            this.tssAfterPrint,
            this.ssbExportToExcel});
            this.tsDocs.Location = new System.Drawing.Point(0, 40);
            this.tsDocs.Name = "tsDocs";
            this.tsDocs.Size = new System.Drawing.Size(1284, 55);
            this.tsDocs.TabIndex = 10;
            this.tsDocs.Text = "Панель инструментов документа";
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(52, 52);
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.ToolTipText = "Обновить список анкет входного контроля поставки";
            this.btnRefresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // btnCancelLoading
            // 
            this.btnCancelLoading.Image = global::WMSOffice.Properties.Resources.cancel;
            this.btnCancelLoading.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelLoading.Name = "btnCancelLoading";
            this.btnCancelLoading.Size = new System.Drawing.Size(113, 52);
            this.btnCancelLoading.Text = "Отменить\nзагрузку";
            this.btnCancelLoading.ToolTipText = "Отменить текущую загрузку";
            this.btnCancelLoading.Visible = false;
            this.btnCancelLoading.Click += new System.EventHandler(this.CancelLoading_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::WMSOffice.Properties.Resources.find;
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(94, 52);
            this.btnSearch.Text = "Поиск";
            this.btnSearch.Click += new System.EventHandler(this.Search_Click);
            // 
            // tssAfterRefresh
            // 
            this.tssAfterRefresh.Name = "tssAfterRefresh";
            this.tssAfterRefresh.Size = new System.Drawing.Size(6, 55);
            // 
            // btnEditWorksheet
            // 
            this.btnEditWorksheet.Image = global::WMSOffice.Properties.Resources.edit_document;
            this.btnEditWorksheet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditWorksheet.Name = "btnEditWorksheet";
            this.btnEditWorksheet.Size = new System.Drawing.Size(139, 52);
            this.btnEditWorksheet.Text = "Редактировать\nанкету (F2)";
            this.btnEditWorksheet.ToolTipText = "Отредактировать анкету, выделенную в таблице";
            this.btnEditWorksheet.Click += new System.EventHandler(this.EditWorksheet_Click);
            // 
            // tssAfterEdit
            // 
            this.tssAfterEdit.Name = "tssAfterEdit";
            this.tssAfterEdit.Size = new System.Drawing.Size(6, 55);
            // 
            // btnApproveWorksheet
            // 
            this.btnApproveWorksheet.Image = global::WMSOffice.Properties.Resources.finish_process;
            this.btnApproveWorksheet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnApproveWorksheet.Name = "btnApproveWorksheet";
            this.btnApproveWorksheet.Size = new System.Drawing.Size(129, 52);
            this.btnApproveWorksheet.Text = "Подтвердить";
            this.btnApproveWorksheet.Click += new System.EventHandler(this.btnApproveWorksheet_Click);
            // 
            // tssAfterApprove
            // 
            this.tssAfterApprove.Name = "tssAfterApprove";
            this.tssAfterApprove.Size = new System.Drawing.Size(6, 55);
            // 
            // btnUndoWorksheet
            // 
            this.btnUndoWorksheet.Image = global::WMSOffice.Properties.Resources.undo_action;
            this.btnUndoWorksheet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUndoWorksheet.Name = "btnUndoWorksheet";
            this.btnUndoWorksheet.Size = new System.Drawing.Size(103, 52);
            this.btnUndoWorksheet.Text = "Вернуть";
            this.btnUndoWorksheet.Click += new System.EventHandler(this.btnUndoWorksheet_Click);
            // 
            // tssAfterUndo
            // 
            this.tssAfterUndo.Name = "tssAfterUndo";
            this.tssAfterUndo.Size = new System.Drawing.Size(6, 55);
            // 
            // btnPreviewWorksheet
            // 
            this.btnPreviewWorksheet.Image = global::WMSOffice.Properties.Resources.document_print_preview;
            this.btnPreviewWorksheet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPreviewWorksheet.Name = "btnPreviewWorksheet";
            this.btnPreviewWorksheet.Size = new System.Drawing.Size(116, 52);
            this.btnPreviewWorksheet.Text = "Просмотр\nанкеты";
            this.btnPreviewWorksheet.ToolTipText = "Просмотр анкеты входного контроля поставки, выбранной в таблице";
            this.btnPreviewWorksheet.Click += new System.EventHandler(this.PreviewWorksheet_Click);
            // 
            // cmbPrinters
            // 
            this.cmbPrinters.Name = "cmbPrinters";
            this.cmbPrinters.Size = new System.Drawing.Size(250, 55);
            // 
            // btnPrintWorksheet
            // 
            this.btnPrintWorksheet.Image = global::WMSOffice.Properties.Resources.document_print;
            this.btnPrintWorksheet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintWorksheet.Name = "btnPrintWorksheet";
            this.btnPrintWorksheet.Size = new System.Drawing.Size(98, 52);
            this.btnPrintWorksheet.Text = "Печать\nанкеты";
            this.btnPrintWorksheet.ToolTipText = "Распечатать анкету, выбранную в таблице, на выбранном принтере";
            this.btnPrintWorksheet.Click += new System.EventHandler(this.PrintWorksheet_Click);
            // 
            // btnPrintViolationAct
            // 
            this.btnPrintViolationAct.Image = global::WMSOffice.Properties.Resources.document_print;
            this.btnPrintViolationAct.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintViolationAct.Name = "btnPrintViolationAct";
            this.btnPrintViolationAct.Size = new System.Drawing.Size(144, 52);
            this.btnPrintViolationAct.Text = "Печать акта\nнесоответствия";
            this.btnPrintViolationAct.Click += new System.EventHandler(this.btnPrintViolationAct_Click);
            // 
            // tssAfterPrint
            // 
            this.tssAfterPrint.Name = "tssAfterPrint";
            this.tssAfterPrint.Size = new System.Drawing.Size(6, 55);
            // 
            // ssbExportToExcel
            // 
            this.ssbExportToExcel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ssbiExportDocs,
            this.ssbiExportShipments,
            this.toolStripSeparator1,
            this.ssbiExportApprovedShipments});
            this.ssbExportToExcel.Image = global::WMSOffice.Properties.Resources.Excel;
            this.ssbExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ssbExportToExcel.Name = "ssbExportToExcel";
            this.ssbExportToExcel.Size = new System.Drawing.Size(155, 52);
            this.ssbExportToExcel.Text = "Экспорт в Excel";
            this.ssbExportToExcel.ButtonClick += new System.EventHandler(this.ssbExportToExcel_ButtonClick);
            // 
            // ssbiExportDocs
            // 
            this.ssbiExportDocs.Name = "ssbiExportDocs";
            this.ssbiExportDocs.Size = new System.Drawing.Size(175, 22);
            this.ssbiExportDocs.Text = "реестра анкет ";
            this.ssbiExportDocs.Click += new System.EventHandler(this.ssbiExportDocs_Click);
            // 
            // ssbiExportShipments
            // 
            this.ssbiExportShipments.Name = "ssbiExportShipments";
            this.ssbiExportShipments.Size = new System.Drawing.Size(175, 22);
            this.ssbiExportShipments.Text = "реестра поставок";
            this.ssbiExportShipments.Click += new System.EventHandler(this.ssbiExportShipments_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(172, 6);
            // 
            // ssbiExportApprovedShipments
            // 
            this.ssbiExportApprovedShipments.Name = "ssbiExportApprovedShipments";
            this.ssbiExportApprovedShipments.Size = new System.Drawing.Size(175, 22);
            this.ssbiExportApprovedShipments.Text = "протокола контроля условий транспортировки";
            this.ssbiExportApprovedShipments.Click += new System.EventHandler(this.ssbiExportApprovedShipments_Click);
            // 
            // pnlStatuseFilters
            // 
            this.pnlStatuseFilters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlStatuseFilters.Controls.Add(this.gbApprovedDocs);
            this.pnlStatuseFilters.Controls.Add(this.gbStatuses);
            this.pnlStatuseFilters.Location = new System.Drawing.Point(0, 98);
            this.pnlStatuseFilters.Name = "pnlStatuseFilters";
            this.pnlStatuseFilters.Size = new System.Drawing.Size(1284, 66);
            this.pnlStatuseFilters.TabIndex = 2;
            // 
            // gbApprovedDocs
            // 
            this.gbApprovedDocs.Controls.Add(this.chbOnlyApproved);
            this.gbApprovedDocs.Location = new System.Drawing.Point(674, 3);
            this.gbApprovedDocs.Name = "gbApprovedDocs";
            this.gbApprovedDocs.Size = new System.Drawing.Size(120, 54);
            this.gbApprovedDocs.TabIndex = 62;
            this.gbApprovedDocs.TabStop = false;
            // 
            // chbOnlyApproved
            // 
            this.chbOnlyApproved.AutoSize = true;
            this.chbOnlyApproved.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chbOnlyApproved.Location = new System.Drawing.Point(6, 25);
            this.chbOnlyApproved.Name = "chbOnlyApproved";
            this.chbOnlyApproved.Size = new System.Drawing.Size(113, 17);
            this.chbOnlyApproved.TabIndex = 62;
            this.chbOnlyApproved.Text = "Подтверждена";
            this.chbOnlyApproved.UseVisualStyleBackColor = true;
            this.chbOnlyApproved.CheckedChanged += new System.EventHandler(this.chbStatus_CheckedChanged);
            // 
            // gbStatuses
            // 
            this.gbStatuses.Controls.Add(this.chbWithSuspectedQuality);
            this.gbStatuses.Controls.Add(this.chbStatusInWork);
            this.gbStatuses.Controls.Add(this.chbStatusNotAccepted);
            this.gbStatuses.Controls.Add(this.chbStatusNew);
            this.gbStatuses.Controls.Add(this.chbStatusAccepted);
            this.gbStatuses.Location = new System.Drawing.Point(3, 3);
            this.gbStatuses.Name = "gbStatuses";
            this.gbStatuses.Size = new System.Drawing.Size(665, 54);
            this.gbStatuses.TabIndex = 61;
            this.gbStatuses.TabStop = false;
            this.gbStatuses.Text = "Статусы отображаемых анкет";
            // 
            // chbWithSuspectedQuality
            // 
            this.chbWithSuspectedQuality.AutoSize = true;
            this.chbWithSuspectedQuality.Location = new System.Drawing.Point(378, 25);
            this.chbWithSuspectedQuality.Name = "chbWithSuspectedQuality";
            this.chbWithSuspectedQuality.Size = new System.Drawing.Size(154, 17);
            this.chbWithSuspectedQuality.TabIndex = 50;
            this.chbWithSuspectedQuality.Text = "Сомнительного качества";
            this.chbWithSuspectedQuality.UseVisualStyleBackColor = true;
            this.chbWithSuspectedQuality.Click += new System.EventHandler(this.chbStatus_CheckedChanged);
            // 
            // chbStatusInWork
            // 
            this.chbStatusInWork.AutoSize = true;
            this.chbStatusInWork.Checked = true;
            this.chbStatusInWork.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbStatusInWork.Location = new System.Drawing.Point(107, 25);
            this.chbStatusInWork.Name = "chbStatusInWork";
            this.chbStatusInWork.Size = new System.Drawing.Size(71, 17);
            this.chbStatusInWork.TabIndex = 30;
            this.chbStatusInWork.Text = "В работе";
            this.chbStatusInWork.UseVisualStyleBackColor = true;
            this.chbStatusInWork.CheckedChanged += new System.EventHandler(this.chbStatus_CheckedChanged);
            // 
            // chbStatusNotAccepted
            // 
            this.chbStatusNotAccepted.AutoSize = true;
            this.chbStatusNotAccepted.Location = new System.Drawing.Point(572, 25);
            this.chbStatusNotAccepted.Name = "chbStatusNotAccepted";
            this.chbStatusNotAccepted.Size = new System.Drawing.Size(91, 17);
            this.chbStatusNotAccepted.TabIndex = 60;
            this.chbStatusNotAccepted.Text = "Не пройдена";
            this.chbStatusNotAccepted.UseVisualStyleBackColor = true;
            this.chbStatusNotAccepted.CheckedChanged += new System.EventHandler(this.chbStatus_CheckedChanged);
            // 
            // chbStatusNew
            // 
            this.chbStatusNew.AutoSize = true;
            this.chbStatusNew.Checked = true;
            this.chbStatusNew.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbStatusNew.Location = new System.Drawing.Point(5, 25);
            this.chbStatusNew.Name = "chbStatusNew";
            this.chbStatusNew.Size = new System.Drawing.Size(58, 17);
            this.chbStatusNew.TabIndex = 20;
            this.chbStatusNew.Text = "Новая";
            this.chbStatusNew.UseVisualStyleBackColor = true;
            this.chbStatusNew.CheckedChanged += new System.EventHandler(this.chbStatus_CheckedChanged);
            // 
            // chbStatusAccepted
            // 
            this.chbStatusAccepted.AutoSize = true;
            this.chbStatusAccepted.Location = new System.Drawing.Point(216, 25);
            this.chbStatusAccepted.Name = "chbStatusAccepted";
            this.chbStatusAccepted.Size = new System.Drawing.Size(122, 17);
            this.chbStatusAccepted.TabIndex = 40;
            this.chbStatusAccepted.Text = "Пройдена успешно";
            this.chbStatusAccepted.UseVisualStyleBackColor = true;
            this.chbStatusAccepted.CheckedChanged += new System.EventHandler(this.chbStatus_CheckedChanged);
            // 
            // edgWorksheets
            // 
            this.edgWorksheets.AllowSort = true;
            this.edgWorksheets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edgWorksheets.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.edgWorksheets.ContextMenuStrip = this.cmsDocs;
            this.edgWorksheets.LargeAmountOfData = true;
            this.edgWorksheets.Location = new System.Drawing.Point(0, 161);
            this.edgWorksheets.Name = "edgWorksheets";
            this.edgWorksheets.RowHeadersVisible = false;
            this.edgWorksheets.Size = new System.Drawing.Size(1284, 452);
            this.edgWorksheets.TabIndex = 11;
            this.edgWorksheets.UserID = ((long)(0));
            this.edgWorksheets.OnRowSelectionChanged += new System.EventHandler(this.edgWorksheets_SelectionChanged);
            this.edgWorksheets.OnFilterChanged += new System.EventHandler(this.edgWorksheets_OnFilterChanged);
            this.edgWorksheets.OnRowDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.edgWorksheets_OnRowDoubleClick);
            // 
            // cmsDocs
            // 
            this.cmsDocs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miRefresh,
            this.miCancelLoading,
            this.miSearch,
            this.tssAfterMiRefresh,
            this.miEditWorksheet,
            this.tssAfterMiEdit,
            this.miPreviewWorksheet,
            this.miPrintWorksheet,
            this.tssAfterMiPrint,
            this.miExportToExcel});
            this.cmsDocs.Name = "contextMenuStrip1";
            this.cmsDocs.Size = new System.Drawing.Size(213, 176);
            // 
            // miRefresh
            // 
            this.miRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.miRefresh.Name = "miRefresh";
            this.miRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.miRefresh.Size = new System.Drawing.Size(212, 22);
            this.miRefresh.Text = "Обновить";
            this.miRefresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // miCancelLoading
            // 
            this.miCancelLoading.Enabled = false;
            this.miCancelLoading.Image = global::WMSOffice.Properties.Resources.cancel;
            this.miCancelLoading.Name = "miCancelLoading";
            this.miCancelLoading.Size = new System.Drawing.Size(212, 22);
            this.miCancelLoading.Text = "Отменить загрузку";
            this.miCancelLoading.Click += new System.EventHandler(this.CancelLoading_Click);
            // 
            // miSearch
            // 
            this.miSearch.Image = global::WMSOffice.Properties.Resources.find;
            this.miSearch.Name = "miSearch";
            this.miSearch.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.miSearch.Size = new System.Drawing.Size(212, 22);
            this.miSearch.Text = "Поиск";
            this.miSearch.Click += new System.EventHandler(this.Search_Click);
            // 
            // tssAfterMiRefresh
            // 
            this.tssAfterMiRefresh.Name = "tssAfterMiRefresh";
            this.tssAfterMiRefresh.Size = new System.Drawing.Size(209, 6);
            // 
            // miEditWorksheet
            // 
            this.miEditWorksheet.Image = global::WMSOffice.Properties.Resources.edit_document;
            this.miEditWorksheet.Name = "miEditWorksheet";
            this.miEditWorksheet.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.miEditWorksheet.Size = new System.Drawing.Size(212, 22);
            this.miEditWorksheet.Text = "Редактировать анкету";
            this.miEditWorksheet.Click += new System.EventHandler(this.EditWorksheet_Click);
            // 
            // tssAfterMiEdit
            // 
            this.tssAfterMiEdit.Name = "tssAfterMiEdit";
            this.tssAfterMiEdit.Size = new System.Drawing.Size(209, 6);
            // 
            // miPreviewWorksheet
            // 
            this.miPreviewWorksheet.Image = global::WMSOffice.Properties.Resources.document_print_preview;
            this.miPreviewWorksheet.Name = "miPreviewWorksheet";
            this.miPreviewWorksheet.Size = new System.Drawing.Size(212, 22);
            this.miPreviewWorksheet.Text = "Просмотр анкеты";
            this.miPreviewWorksheet.Click += new System.EventHandler(this.PreviewWorksheet_Click);
            // 
            // miPrintWorksheet
            // 
            this.miPrintWorksheet.Image = global::WMSOffice.Properties.Resources.document_print;
            this.miPrintWorksheet.Name = "miPrintWorksheet";
            this.miPrintWorksheet.Size = new System.Drawing.Size(212, 22);
            this.miPrintWorksheet.Text = "Печать анкеты";
            this.miPrintWorksheet.Click += new System.EventHandler(this.PrintWorksheet_Click);
            // 
            // tssAfterMiPrint
            // 
            this.tssAfterMiPrint.Name = "tssAfterMiPrint";
            this.tssAfterMiPrint.Size = new System.Drawing.Size(209, 6);
            // 
            // miExportToExcel
            // 
            this.miExportToExcel.Image = global::WMSOffice.Properties.Resources.Excel;
            this.miExportToExcel.Name = "miExportToExcel";
            this.miExportToExcel.Size = new System.Drawing.Size(212, 22);
            this.miExportToExcel.Text = "Экспорт в Excel";
            this.miExportToExcel.Click += new System.EventHandler(this.ssbiExportDocs_Click);
            // 
            // pbSplashControl
            // 
            this.pbSplashControl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbSplashControl.Image = global::WMSOffice.Properties.Resources.Loading;
            this.pbSplashControl.InitialImage = null;
            this.pbSplashControl.Location = new System.Drawing.Point(590, 333);
            this.pbSplashControl.Name = "pbSplashControl";
            this.pbSplashControl.Size = new System.Drawing.Size(104, 104);
            this.pbSplashControl.TabIndex = 73;
            this.pbSplashControl.TabStop = false;
            this.pbSplashControl.Visible = false;
            // 
            // QualityInputControlDeliveryWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 615);
            this.Controls.Add(this.pbSplashControl);
            this.Controls.Add(this.edgWorksheets);
            this.Controls.Add(this.pnlStatuseFilters);
            this.Controls.Add(this.tsDocs);
            this.KeyPreview = true;
            this.Name = "QualityInputControlDeliveryWindow";
            this.Text = "Входной контроль поставки";
            this.Load += new System.EventHandler(this.QualityInputControlDeliveryWindow_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QualityInputControlDeliveryWindow_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.QualityInputControlDeliveryWindow_KeyDown);
            this.Controls.SetChildIndex(this.tsDocs, 0);
            this.Controls.SetChildIndex(this.pnlStatuseFilters, 0);
            this.Controls.SetChildIndex(this.edgWorksheets, 0);
            this.Controls.SetChildIndex(this.pbSplashControl, 0);
            this.tsDocs.ResumeLayout(false);
            this.tsDocs.PerformLayout();
            this.pnlStatuseFilters.ResumeLayout(false);
            this.gbApprovedDocs.ResumeLayout(false);
            this.gbApprovedDocs.PerformLayout();
            this.gbStatuses.ResumeLayout(false);
            this.gbStatuses.PerformLayout();
            this.cmsDocs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSplashControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsDocs;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton btnCancelLoading;
        private System.Windows.Forms.ToolStripSeparator tssAfterRefresh;
        private System.Windows.Forms.Panel pnlStatuseFilters;
        private System.Windows.Forms.CheckBox chbStatusNotAccepted;
        private System.Windows.Forms.CheckBox chbStatusAccepted;
        private System.Windows.Forms.CheckBox chbStatusInWork;
        private System.Windows.Forms.CheckBox chbStatusNew;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView edgWorksheets;
        private System.Windows.Forms.PictureBox pbSplashControl;
        private System.ComponentModel.BackgroundWorker bgwLoader;
        private System.Windows.Forms.ContextMenuStrip cmsDocs;
        private System.Windows.Forms.ToolStripMenuItem miRefresh;
        private System.Windows.Forms.ToolStripMenuItem miCancelLoading;
        private System.Windows.Forms.ToolStripSeparator tssAfterMiRefresh;
        private System.Windows.Forms.ToolStripButton btnPreviewWorksheet;
        private System.Windows.Forms.ToolStripMenuItem miPreviewWorksheet;
        private System.Windows.Forms.ToolStripComboBox cmbPrinters;
        private System.Windows.Forms.ToolStripButton btnPrintWorksheet;
        private System.Windows.Forms.ToolStripMenuItem miPrintWorksheet;
        private System.Windows.Forms.ToolStripButton btnEditWorksheet;
        private System.Windows.Forms.ToolStripSeparator tssAfterApprove;
        private System.Windows.Forms.ToolStripMenuItem miEditWorksheet;
        private System.Windows.Forms.ToolStripSeparator tssAfterMiEdit;
        private System.Windows.Forms.ToolStripSeparator tssAfterPrint;
        private System.Windows.Forms.ToolStripSeparator tssAfterMiPrint;
        private System.Windows.Forms.ToolStripMenuItem miExportToExcel;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStripMenuItem miSearch;
        private System.Windows.Forms.CheckBox chbWithSuspectedQuality;
        private System.Windows.Forms.ToolStripSeparator tssAfterEdit;
        private System.Windows.Forms.ToolStripButton btnApproveWorksheet;
        private System.Windows.Forms.GroupBox gbStatuses;
        private System.Windows.Forms.GroupBox gbApprovedDocs;
        private System.Windows.Forms.CheckBox chbOnlyApproved;
        private System.Windows.Forms.ToolStripSplitButton ssbExportToExcel;
        private System.Windows.Forms.ToolStripMenuItem ssbiExportDocs;
        private System.Windows.Forms.ToolStripMenuItem ssbiExportShipments;
        private System.Windows.Forms.ToolStripButton btnPrintViolationAct;
        private System.Windows.Forms.ToolStripMenuItem ssbiExportApprovedShipments;
        private System.Windows.Forms.ToolStripButton btnUndoWorksheet;
        private System.Windows.Forms.ToolStripSeparator tssAfterUndo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}