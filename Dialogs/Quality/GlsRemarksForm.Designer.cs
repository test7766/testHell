namespace WMSOffice.Dialogs.Quality
{
    partial class GlsRemarksForm
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
            this.btnClose = new System.Windows.Forms.Button();
            this.tsButtons = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.tssAfterRefresh = new System.Windows.Forms.ToolStripSeparator();
            this.btnNewRemark = new System.Windows.Forms.ToolStripButton();
            this.btnResolveRemark = new System.Windows.Forms.ToolStripButton();
            this.btnInformlist = new System.Windows.Forms.ToolStripButton();
            this.btnDocsToGls = new System.Windows.Forms.ToolStripButton();
            this.btnResumeRemark = new System.Windows.Forms.ToolStripButton();
            this.cmsRemarks = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.tssAfterMiRefresh = new System.Windows.Forms.ToolStripSeparator();
            this.miNewRemark = new System.Windows.Forms.ToolStripMenuItem();
            this.miResolveRemark = new System.Windows.Forms.ToolStripMenuItem();
            this.miInformlist = new System.Windows.Forms.ToolStripMenuItem();
            this.miDocsToGls = new System.Windows.Forms.ToolStripMenuItem();
            this.miResumeRemark = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvRemarks = new System.Windows.Forms.DataGridView();
            this.clLineID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clVendorLot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clRemarkTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDateCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDateResolved = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDateInformList = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDateDocsToGls = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clGlsExpert = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clLastUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsQkGLSRemarks = new System.Windows.Forms.BindingSource(this.components);
            this.quality = new WMSOffice.Data.Quality();
            this.pbSplashControl = new System.Windows.Forms.PictureBox();
            this.tmrLoadingShower = new System.Windows.Forms.Timer(this.components);
            this.bwGlsRemarksLoader = new System.ComponentModel.BackgroundWorker();
            this.lblDescription = new System.Windows.Forms.Label();
            this.tbxDescription = new System.Windows.Forms.TextBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taQkGLSRemarks = new WMSOffice.Data.QualityTableAdapters.QK_GLS_RemarksTableAdapter();
            this.tsButtons.SuspendLayout();
            this.cmsRemarks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemarks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsQkGLSRemarks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSplashControl)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(1109, 597);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 30);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Закрити";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // tsButtons
            // 
            this.tsButtons.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsButtons.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.tssAfterRefresh,
            this.btnNewRemark,
            this.btnResolveRemark,
            this.btnInformlist,
            this.btnDocsToGls,
            this.btnResumeRemark});
            this.tsButtons.Location = new System.Drawing.Point(0, 0);
            this.tsButtons.Name = "tsButtons";
            this.tsButtons.Size = new System.Drawing.Size(1196, 39);
            this.tsButtons.TabIndex = 1;
            this.tsButtons.Text = "toolStrip1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(120, 36);
            this.btnRefresh.Text = "Оновити (F5)";
            this.btnRefresh.ToolTipText = "Оновити таблицю із зауваженнями від ДЛС";
            this.btnRefresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // tssAfterRefresh
            // 
            this.tssAfterRefresh.Name = "tssAfterRefresh";
            this.tssAfterRefresh.Size = new System.Drawing.Size(6, 39);
            // 
            // btnNewRemark
            // 
            this.btnNewRemark.Image = global::WMSOffice.Properties.Resources.add;
            this.btnNewRemark.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewRemark.Name = "btnNewRemark";
            this.btnNewRemark.Size = new System.Drawing.Size(183, 36);
            this.btnNewRemark.Text = "Додати зауваження (Ins)";
            this.btnNewRemark.ToolTipText = "Додати нове зауваження від ДЛС";
            this.btnNewRemark.Click += new System.EventHandler(this.NewGlsRemark_Click);
            // 
            // btnResolveRemark
            // 
            this.btnResolveRemark.Image = global::WMSOffice.Properties.Resources.Apply;
            this.btnResolveRemark.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnResolveRemark.Name = "btnResolveRemark";
            this.btnResolveRemark.Size = new System.Drawing.Size(187, 36);
            this.btnResolveRemark.Text = "Зауваження усунуто (F2)";
            this.btnResolveRemark.ToolTipText = "Помітити вибрані в таблиці некритичні зауваження як усунуті";
            this.btnResolveRemark.Click += new System.EventHandler(this.DoActionWithRemark_Click);
            // 
            // btnInformlist
            // 
            this.btnInformlist.Image = global::WMSOffice.Properties.Resources.line_sight;
            this.btnInformlist.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInformlist.Name = "btnInformlist";
            this.btnInformlist.Size = new System.Drawing.Size(175, 36);
            this.btnInformlist.Text = "Видано інформлист (F3)";
            this.btnInformlist.ToolTipText = "Внести у систему факт отримання інформлиста від ДЛС";
            this.btnInformlist.Click += new System.EventHandler(this.DoActionWithRemark_Click);
            // 
            // btnDocsToGls
            // 
            this.btnDocsToGls.Image = global::WMSOffice.Properties.Resources.mail_ok;
            this.btnDocsToGls.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDocsToGls.Name = "btnDocsToGls";
            this.btnDocsToGls.Size = new System.Drawing.Size(197, 36);
            this.btnDocsToGls.Text = "Документи доставлено (F4)";
            this.btnDocsToGls.ToolTipText = "Внести у систему факт відправлення документів у ДЛС";
            this.btnDocsToGls.Click += new System.EventHandler(this.DoActionWithRemark_Click);
            // 
            // btnResumeRemark
            // 
            this.btnResumeRemark.Image = global::WMSOffice.Properties.Resources.Restore;
            this.btnResumeRemark.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnResumeRemark.Name = "btnResumeRemark";
            this.btnResumeRemark.Size = new System.Drawing.Size(199, 36);
            this.btnResumeRemark.Text = "Поновити зауваження (F6)";
            this.btnResumeRemark.Click += new System.EventHandler(this.ResumeRemark_Click);
            // 
            // cmsRemarks
            // 
            this.cmsRemarks.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miRefresh,
            this.tssAfterMiRefresh,
            this.miNewRemark,
            this.miResolveRemark,
            this.miInformlist,
            this.miDocsToGls,
            this.miResumeRemark});
            this.cmsRemarks.Name = "cmsRemarks";
            this.cmsRemarks.Size = new System.Drawing.Size(227, 164);
            // 
            // miRefresh
            // 
            this.miRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.miRefresh.Name = "miRefresh";
            this.miRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.miRefresh.Size = new System.Drawing.Size(226, 22);
            this.miRefresh.Text = "Оновити";
            this.miRefresh.ToolTipText = "Оновити таблицю із зауваженнями від ДЛС";
            this.miRefresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // tssAfterMiRefresh
            // 
            this.tssAfterMiRefresh.Name = "tssAfterMiRefresh";
            this.tssAfterMiRefresh.Size = new System.Drawing.Size(223, 6);
            // 
            // miNewRemark
            // 
            this.miNewRemark.Image = global::WMSOffice.Properties.Resources.add;
            this.miNewRemark.Name = "miNewRemark";
            this.miNewRemark.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.miNewRemark.Size = new System.Drawing.Size(226, 22);
            this.miNewRemark.Text = "Додати зауваження";
            this.miNewRemark.ToolTipText = "Додати нове зауваження від ДЛС";
            this.miNewRemark.Click += new System.EventHandler(this.NewGlsRemark_Click);
            // 
            // miResolveRemark
            // 
            this.miResolveRemark.Image = global::WMSOffice.Properties.Resources.Apply;
            this.miResolveRemark.Name = "miResolveRemark";
            this.miResolveRemark.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.miResolveRemark.Size = new System.Drawing.Size(226, 22);
            this.miResolveRemark.Text = "Зауваження усунуто";
            this.miResolveRemark.Click += new System.EventHandler(this.DoActionWithRemark_Click);
            // 
            // miInformlist
            // 
            this.miInformlist.Image = global::WMSOffice.Properties.Resources.line_sight;
            this.miInformlist.Name = "miInformlist";
            this.miInformlist.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.miInformlist.Size = new System.Drawing.Size(226, 22);
            this.miInformlist.Text = "Видано інформлист";
            this.miInformlist.ToolTipText = "Внести у систему факт отримання інформлиста від ДЛС";
            this.miInformlist.Click += new System.EventHandler(this.DoActionWithRemark_Click);
            // 
            // miDocsToGls
            // 
            this.miDocsToGls.Image = global::WMSOffice.Properties.Resources.mail_ok;
            this.miDocsToGls.Name = "miDocsToGls";
            this.miDocsToGls.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.miDocsToGls.Size = new System.Drawing.Size(226, 22);
            this.miDocsToGls.Text = "Документи доставлено";
            this.miDocsToGls.ToolTipText = "Внести у систему факт відправлення документів у ДЛС";
            this.miDocsToGls.Click += new System.EventHandler(this.DoActionWithRemark_Click);
            // 
            // miResumeRemark
            // 
            this.miResumeRemark.Image = global::WMSOffice.Properties.Resources.Restore;
            this.miResumeRemark.Name = "miResumeRemark";
            this.miResumeRemark.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.miResumeRemark.Size = new System.Drawing.Size(226, 22);
            this.miResumeRemark.Text = "Поновити зауваження";
            this.miResumeRemark.Click += new System.EventHandler(this.ResumeRemark_Click);
            // 
            // dgvRemarks
            // 
            this.dgvRemarks.AllowUserToAddRows = false;
            this.dgvRemarks.AllowUserToDeleteRows = false;
            this.dgvRemarks.AllowUserToOrderColumns = true;
            this.dgvRemarks.AllowUserToResizeRows = false;
            this.dgvRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRemarks.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRemarks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRemarks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRemarks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clLineID,
            this.clItemID,
            this.clItem,
            this.clVendorLot,
            this.clRemarkTypeID,
            this.clDateCreated,
            this.clDateResolved,
            this.clDateInformList,
            this.clDateDocsToGls,
            this.clGlsExpert,
            this.clLastUser});
            this.dgvRemarks.ContextMenuStrip = this.cmsRemarks;
            this.dgvRemarks.DataSource = this.bsQkGLSRemarks;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRemarks.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRemarks.Location = new System.Drawing.Point(0, 42);
            this.dgvRemarks.Name = "dgvRemarks";
            this.dgvRemarks.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRemarks.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRemarks.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dgvRemarks.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvRemarks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRemarks.Size = new System.Drawing.Size(1184, 441);
            this.dgvRemarks.TabIndex = 3;
            this.dgvRemarks.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvRemarks_DataError);
            this.dgvRemarks.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvRemarks_DataBindingComplete);
            this.dgvRemarks.SelectionChanged += new System.EventHandler(this.dgvRemarks_SelectionChanged);
            // 
            // clLineID
            // 
            this.clLineID.DataPropertyName = "line_id";
            this.clLineID.HeaderText = "№";
            this.clLineID.Name = "clLineID";
            this.clLineID.ReadOnly = true;
            this.clLineID.Width = 30;
            // 
            // clItemID
            // 
            this.clItemID.DataPropertyName = "item_id";
            this.clItemID.HeaderText = "Код товару";
            this.clItemID.Name = "clItemID";
            this.clItemID.ReadOnly = true;
            this.clItemID.Width = 60;
            // 
            // clItem
            // 
            this.clItem.DataPropertyName = "item";
            this.clItem.HeaderText = "Назва";
            this.clItem.Name = "clItem";
            this.clItem.ReadOnly = true;
            this.clItem.Width = 200;
            // 
            // clVendorLot
            // 
            this.clVendorLot.DataPropertyName = "vendor_lot";
            this.clVendorLot.HeaderText = "Серія";
            this.clVendorLot.Name = "clVendorLot";
            this.clVendorLot.ReadOnly = true;
            // 
            // clRemarkTypeID
            // 
            this.clRemarkTypeID.DataPropertyName = "remark_type";
            this.clRemarkTypeID.HeaderText = "Тип зауваження";
            this.clRemarkTypeID.Name = "clRemarkTypeID";
            this.clRemarkTypeID.ReadOnly = true;
            this.clRemarkTypeID.Width = 150;
            // 
            // clDateCreated
            // 
            this.clDateCreated.DataPropertyName = "date_created";
            this.clDateCreated.HeaderText = "Внесено";
            this.clDateCreated.Name = "clDateCreated";
            this.clDateCreated.ReadOnly = true;
            this.clDateCreated.Width = 80;
            // 
            // clDateResolved
            // 
            this.clDateResolved.DataPropertyName = "date_resolved";
            this.clDateResolved.HeaderText = "Усунуто";
            this.clDateResolved.Name = "clDateResolved";
            this.clDateResolved.ReadOnly = true;
            this.clDateResolved.Width = 80;
            // 
            // clDateInformList
            // 
            this.clDateInformList.DataPropertyName = "date_informlist";
            this.clDateInformList.HeaderText = "Інформлист";
            this.clDateInformList.Name = "clDateInformList";
            this.clDateInformList.ReadOnly = true;
            this.clDateInformList.Width = 80;
            // 
            // clDateDocsToGls
            // 
            this.clDateDocsToGls.DataPropertyName = "date_docs_to_gls";
            this.clDateDocsToGls.HeaderText = "Документи в ДЛС";
            this.clDateDocsToGls.Name = "clDateDocsToGls";
            this.clDateDocsToGls.ReadOnly = true;
            this.clDateDocsToGls.Width = 80;
            // 
            // clGlsExpert
            // 
            this.clGlsExpert.DataPropertyName = "gls_expert";
            this.clGlsExpert.HeaderText = "Експерт ДЛС";
            this.clGlsExpert.Name = "clGlsExpert";
            this.clGlsExpert.ReadOnly = true;
            this.clGlsExpert.Width = 150;
            // 
            // clLastUser
            // 
            this.clLastUser.DataPropertyName = "last_user";
            this.clLastUser.HeaderText = "Користувач";
            this.clLastUser.Name = "clLastUser";
            this.clLastUser.ReadOnly = true;
            this.clLastUser.Width = 300;
            // 
            // bsQkGLSRemarks
            // 
            this.bsQkGLSRemarks.DataMember = "QK_GLS_Remarks";
            this.bsQkGLSRemarks.DataSource = this.quality;
            // 
            // quality
            // 
            this.quality.DataSetName = "Quality";
            this.quality.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pbSplashControl
            // 
            this.pbSplashControl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbSplashControl.Image = global::WMSOffice.Properties.Resources.Loading;
            this.pbSplashControl.InitialImage = null;
            this.pbSplashControl.Location = new System.Drawing.Point(547, 209);
            this.pbSplashControl.Name = "pbSplashControl";
            this.pbSplashControl.Size = new System.Drawing.Size(104, 104);
            this.pbSplashControl.TabIndex = 74;
            this.pbSplashControl.TabStop = false;
            this.pbSplashControl.Visible = false;
            // 
            // tmrLoadingShower
            // 
            this.tmrLoadingShower.Interval = 500;
            this.tmrLoadingShower.Tick += new System.EventHandler(this.tmrLoadingShower_Tick);
            // 
            // bwGlsRemarksLoader
            // 
            this.bwGlsRemarksLoader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwGlsRemarksLoader_DoWork);
            this.bwGlsRemarksLoader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwGlsRemarksLoader_RunWorkerCompleted);
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 500);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 75;
            this.lblDescription.Text = "Опис:";
            // 
            // tbxDescription
            // 
            this.tbxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxDescription.Location = new System.Drawing.Point(78, 497);
            this.tbxDescription.Multiline = true;
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.ReadOnly = true;
            this.tbxDescription.Size = new System.Drawing.Size(1106, 94);
            this.tbxDescription.TabIndex = 76;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "line_id";
            this.dataGridViewTextBoxColumn1.HeaderText = "№";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 30;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "item";
            this.dataGridViewTextBoxColumn2.HeaderText = "Назва";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 130;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "vendor_lot";
            this.dataGridViewTextBoxColumn3.HeaderText = "Серія";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 80;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "remark_type";
            this.dataGridViewTextBoxColumn4.HeaderText = "Тип зауваження";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 130;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "date_created";
            this.dataGridViewTextBoxColumn5.HeaderText = "Внесено";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 80;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "date_resolved";
            this.dataGridViewTextBoxColumn6.HeaderText = "Усунуто";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 80;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "date_informlist";
            this.dataGridViewTextBoxColumn7.HeaderText = "Інформлист";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 80;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "date_docs_to_gls";
            this.dataGridViewTextBoxColumn8.HeaderText = "Документи в ДЛС";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 80;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "last_user";
            this.dataGridViewTextBoxColumn9.HeaderText = "Користувач";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 150;
            // 
            // taQkGLSRemarks
            // 
            this.taQkGLSRemarks.ClearBeforeFill = true;
            // 
            // GlsRemarksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1196, 639);
            this.Controls.Add(this.tsButtons);
            this.Controls.Add(this.tbxDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.pbSplashControl);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvRemarks);
            this.Name = "GlsRemarksForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Зауваження від ДЛС";
            this.Load += new System.EventHandler(this.GlsRemarksForm_Load);
            this.tsButtons.ResumeLayout(false);
            this.tsButtons.PerformLayout();
            this.cmsRemarks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemarks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsQkGLSRemarks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSplashControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ToolStrip tsButtons;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripSeparator tssAfterRefresh;
        private System.Windows.Forms.ToolStripButton btnNewRemark;
        private System.Windows.Forms.ToolStripButton btnResolveRemark;
        private System.Windows.Forms.ContextMenuStrip cmsRemarks;
        private System.Windows.Forms.ToolStripButton btnInformlist;
        private System.Windows.Forms.ToolStripButton btnDocsToGls;
        private System.Windows.Forms.DataGridView dgvRemarks;
        private System.Windows.Forms.ToolStripMenuItem miRefresh;
        private System.Windows.Forms.ToolStripSeparator tssAfterMiRefresh;
        private System.Windows.Forms.ToolStripMenuItem miNewRemark;
        private System.Windows.Forms.ToolStripMenuItem miResolveRemark;
        private System.Windows.Forms.ToolStripMenuItem miInformlist;
        private System.Windows.Forms.ToolStripMenuItem miDocsToGls;
        private System.Windows.Forms.BindingSource bsQkGLSRemarks;
        private WMSOffice.Data.Quality quality;
        private WMSOffice.Data.QualityTableAdapters.QK_GLS_RemarksTableAdapter taQkGLSRemarks;
        private System.Windows.Forms.PictureBox pbSplashControl;
        private System.Windows.Forms.Timer tmrLoadingShower;
        private System.ComponentModel.BackgroundWorker bwGlsRemarksLoader;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox tbxDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn clLineID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn clVendorLot;
        private System.Windows.Forms.DataGridViewTextBoxColumn clRemarkTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDateCreated;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDateResolved;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDateInformList;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDateDocsToGls;
        private System.Windows.Forms.DataGridViewTextBoxColumn clGlsExpert;
        private System.Windows.Forms.DataGridViewTextBoxColumn clLastUser;
        private System.Windows.Forms.ToolStripButton btnResumeRemark;
        private System.Windows.Forms.ToolStripMenuItem miResumeRemark;
    }
}