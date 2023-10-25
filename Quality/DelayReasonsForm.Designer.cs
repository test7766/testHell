namespace WMSOffice.Dialogs.Quality
{
    partial class DelayReasonsForm
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
            this.tsButtons = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.tssAfterRefresh = new System.Windows.Forms.ToolStripSeparator();
            this.btnNewReason = new System.Windows.Forms.ToolStripButton();
            this.btnResolveReason = new System.Windows.Forms.ToolStripButton();
            this.btnCancelReason = new System.Windows.Forms.ToolStripButton();
            this.tssAfterCancelReason = new System.Windows.Forms.ToolStripSeparator();
            this.btnEditDescription = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvReasons = new System.Windows.Forms.DataGridView();
            this.clReasonName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clStatusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clUserCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDateCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clUserClosed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDateClosed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsReasonsActions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.tssAfterMiRefresh = new System.Windows.Forms.ToolStripSeparator();
            this.miNewReason = new System.Windows.Forms.ToolStripMenuItem();
            this.miResolveReason = new System.Windows.Forms.ToolStripMenuItem();
            this.miCancelReason = new System.Windows.Forms.ToolStripMenuItem();
            this.tssAfterMiCancelReason = new System.Windows.Forms.ToolStripSeparator();
            this.miEditDescription = new System.Windows.Forms.ToolStripMenuItem();
            this.bsQkDelayReasons = new System.Windows.Forms.BindingSource(this.components);
            this.quality = new WMSOffice.Data.Quality();
            this.bwReasonsLoader = new System.ComponentModel.BackgroundWorker();
            this.tmrLoadingShower = new System.Windows.Forms.Timer(this.components);
            this.pbSplashControl = new System.Windows.Forms.PictureBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.tbxDescription = new System.Windows.Forms.TextBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taQkDelayReasons = new WMSOffice.Data.QualityTableAdapters.QK_Delay_ReasonsTableAdapter();
            this.tsButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReasons)).BeginInit();
            this.cmsReasonsActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsQkDelayReasons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSplashControl)).BeginInit();
            this.SuspendLayout();
            // 
            // tsButtons
            // 
            this.tsButtons.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsButtons.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.tssAfterRefresh,
            this.btnNewReason,
            this.btnResolveReason,
            this.btnCancelReason,
            this.tssAfterCancelReason,
            this.btnEditDescription});
            this.tsButtons.Location = new System.Drawing.Point(0, 0);
            this.tsButtons.Name = "tsButtons";
            this.tsButtons.Size = new System.Drawing.Size(1200, 39);
            this.tsButtons.TabIndex = 10;
            this.tsButtons.Text = "toolStrip1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(120, 36);
            this.btnRefresh.Text = "Оновити (F5)";
            this.btnRefresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // tssAfterRefresh
            // 
            this.tssAfterRefresh.Name = "tssAfterRefresh";
            this.tssAfterRefresh.Size = new System.Drawing.Size(6, 39);
            // 
            // btnNewReason
            // 
            this.btnNewReason.Image = global::WMSOffice.Properties.Resources.add;
            this.btnNewReason.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewReason.Name = "btnNewReason";
            this.btnNewReason.Size = new System.Drawing.Size(154, 36);
            this.btnNewReason.Text = "Нова причина (Ins)";
            this.btnNewReason.ToolTipText = "Додати нову причину затримки для заяви";
            this.btnNewReason.Click += new System.EventHandler(this.NewReason_Click);
            // 
            // btnResolveReason
            // 
            this.btnResolveReason.Image = global::WMSOffice.Properties.Resources.Apply;
            this.btnResolveReason.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnResolveReason.Name = "btnResolveReason";
            this.btnResolveReason.Size = new System.Drawing.Size(162, 36);
            this.btnResolveReason.Text = "Причина вирішена (F2)";
            this.btnResolveReason.Click += new System.EventHandler(this.CloseReason_Click);
            // 
            // btnCancelReason
            // 
            this.btnCancelReason.Image = global::WMSOffice.Properties.Resources.close;
            this.btnCancelReason.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelReason.Name = "btnCancelReason";
            this.btnCancelReason.Size = new System.Drawing.Size(218, 36);
            this.btnCancelReason.Text = "Анулювати причину (Ctrl+Z)";
            this.btnCancelReason.Click += new System.EventHandler(this.CloseReason_Click);
            // 
            // tssAfterCancelReason
            // 
            this.tssAfterCancelReason.Name = "tssAfterCancelReason";
            this.tssAfterCancelReason.Size = new System.Drawing.Size(6, 39);
            // 
            // btnEditDescription
            // 
            this.btnEditDescription.Image = global::WMSOffice.Properties.Resources.edit_document;
            this.btnEditDescription.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditDescription.Name = "btnEditDescription";
            this.btnEditDescription.Size = new System.Drawing.Size(153, 36);
            this.btnEditDescription.Text = "Змінити опис";
            this.btnEditDescription.ToolTipText = "Змінити опис для причини затримки, вибраної в таблиці";
            this.btnEditDescription.Click += new System.EventHandler(this.EditDescription_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(1113, 344);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 28);
            this.btnClose.TabIndex = 30;
            this.btnClose.Text = "Закрити";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // dgvReasons
            // 
            this.dgvReasons.AllowUserToAddRows = false;
            this.dgvReasons.AllowUserToDeleteRows = false;
            this.dgvReasons.AllowUserToResizeRows = false;
            this.dgvReasons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReasons.AutoGenerateColumns = false;
            this.dgvReasons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReasons.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clReasonName,
            this.clStatusName,
            this.clUserCreated,
            this.clDateCreated,
            this.clUserClosed,
            this.clDateClosed});
            this.dgvReasons.ContextMenuStrip = this.cmsReasonsActions;
            this.dgvReasons.DataSource = this.bsQkDelayReasons;
            this.dgvReasons.Location = new System.Drawing.Point(0, 42);
            this.dgvReasons.Name = "dgvReasons";
            this.dgvReasons.ReadOnly = true;
            this.dgvReasons.RowHeadersVisible = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dgvReasons.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReasons.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReasons.Size = new System.Drawing.Size(1188, 217);
            this.dgvReasons.TabIndex = 20;
            this.dgvReasons.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvReasons_CellMouseDoubleClick);
            this.dgvReasons.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvReasons_DataError);
            this.dgvReasons.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvReasons_DataBindingComplete);
            this.dgvReasons.SelectionChanged += new System.EventHandler(this.dgvReasons_SelectionChanged);
            // 
            // clReasonName
            // 
            this.clReasonName.DataPropertyName = "reason_name";
            this.clReasonName.HeaderText = "Причина";
            this.clReasonName.Name = "clReasonName";
            this.clReasonName.ReadOnly = true;
            this.clReasonName.Width = 200;
            // 
            // clStatusName
            // 
            this.clStatusName.DataPropertyName = "status_name";
            this.clStatusName.HeaderText = "Статус";
            this.clStatusName.Name = "clStatusName";
            this.clStatusName.ReadOnly = true;
            this.clStatusName.Width = 120;
            // 
            // clUserCreated
            // 
            this.clUserCreated.DataPropertyName = "user_created";
            this.clUserCreated.HeaderText = "Створена";
            this.clUserCreated.Name = "clUserCreated";
            this.clUserCreated.ReadOnly = true;
            this.clUserCreated.Width = 230;
            // 
            // clDateCreated
            // 
            this.clDateCreated.DataPropertyName = "date_created";
            this.clDateCreated.HeaderText = "Дата створення";
            this.clDateCreated.Name = "clDateCreated";
            this.clDateCreated.ReadOnly = true;
            this.clDateCreated.Width = 80;
            // 
            // clUserClosed
            // 
            this.clUserClosed.DataPropertyName = "user_closed";
            this.clUserClosed.HeaderText = "Вирішена";
            this.clUserClosed.Name = "clUserClosed";
            this.clUserClosed.ReadOnly = true;
            this.clUserClosed.Width = 230;
            // 
            // clDateClosed
            // 
            this.clDateClosed.DataPropertyName = "date_closed";
            this.clDateClosed.HeaderText = "Дата вирішення";
            this.clDateClosed.Name = "clDateClosed";
            this.clDateClosed.ReadOnly = true;
            this.clDateClosed.Width = 80;
            // 
            // cmsReasonsActions
            // 
            this.cmsReasonsActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miRefresh,
            this.tssAfterMiRefresh,
            this.miNewReason,
            this.miResolveReason,
            this.miCancelReason,
            this.tssAfterMiCancelReason,
            this.miEditDescription});
            this.cmsReasonsActions.Name = "cmsReasonsActions";
            this.cmsReasonsActions.Size = new System.Drawing.Size(246, 126);
            // 
            // miRefresh
            // 
            this.miRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.miRefresh.Name = "miRefresh";
            this.miRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.miRefresh.Size = new System.Drawing.Size(245, 22);
            this.miRefresh.Text = "Оновити";
            this.miRefresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // tssAfterMiRefresh
            // 
            this.tssAfterMiRefresh.Name = "tssAfterMiRefresh";
            this.tssAfterMiRefresh.Size = new System.Drawing.Size(242, 6);
            // 
            // miNewReason
            // 
            this.miNewReason.Image = global::WMSOffice.Properties.Resources.add;
            this.miNewReason.Name = "miNewReason";
            this.miNewReason.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.miNewReason.Size = new System.Drawing.Size(245, 22);
            this.miNewReason.Text = "Нова причина";
            this.miNewReason.Click += new System.EventHandler(this.NewReason_Click);
            // 
            // miResolveReason
            // 
            this.miResolveReason.Image = global::WMSOffice.Properties.Resources.Apply;
            this.miResolveReason.Name = "miResolveReason";
            this.miResolveReason.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.miResolveReason.Size = new System.Drawing.Size(245, 22);
            this.miResolveReason.Text = "Причина вирішена";
            this.miResolveReason.Click += new System.EventHandler(this.CloseReason_Click);
            // 
            // miCancelReason
            // 
            this.miCancelReason.Image = global::WMSOffice.Properties.Resources.close;
            this.miCancelReason.Name = "miCancelReason";
            this.miCancelReason.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.miCancelReason.Size = new System.Drawing.Size(245, 22);
            this.miCancelReason.Text = "Анулювати причину";
            this.miCancelReason.Click += new System.EventHandler(this.CloseReason_Click);
            // 
            // tssAfterMiCancelReason
            // 
            this.tssAfterMiCancelReason.Name = "tssAfterMiCancelReason";
            this.tssAfterMiCancelReason.Size = new System.Drawing.Size(242, 6);
            // 
            // miEditDescription
            // 
            this.miEditDescription.Image = global::WMSOffice.Properties.Resources.edit_document;
            this.miEditDescription.Name = "miEditDescription";
            this.miEditDescription.Size = new System.Drawing.Size(245, 22);
            this.miEditDescription.Text = "Змінити опис";
            this.miEditDescription.ToolTipText = "Змінити опис для причини затримки, вибраної в таблиці";
            this.miEditDescription.Click += new System.EventHandler(this.EditDescription_Click);
            // 
            // bsQkDelayReasons
            // 
            this.bsQkDelayReasons.DataMember = "QK_Delay_Reasons";
            this.bsQkDelayReasons.DataSource = this.quality;
            // 
            // quality
            // 
            this.quality.DataSetName = "Quality";
            this.quality.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bwReasonsLoader
            // 
            this.bwReasonsLoader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwReasonsLoader_DoWork);
            this.bwReasonsLoader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwReasonsLoader_RunWorkerCompleted);
            // 
            // tmrLoadingShower
            // 
            this.tmrLoadingShower.Interval = 500;
            this.tmrLoadingShower.Tick += new System.EventHandler(this.tmrLoadingShower_Tick);
            // 
            // pbSplashControl
            // 
            this.pbSplashControl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbSplashControl.Image = global::WMSOffice.Properties.Resources.Loading;
            this.pbSplashControl.InitialImage = null;
            this.pbSplashControl.Location = new System.Drawing.Point(557, 102);
            this.pbSplashControl.Name = "pbSplashControl";
            this.pbSplashControl.Size = new System.Drawing.Size(104, 104);
            this.pbSplashControl.TabIndex = 73;
            this.pbSplashControl.TabStop = false;
            this.pbSplashControl.Visible = false;
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 268);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 74;
            this.lblDescription.Text = "Опис:";
            // 
            // tbxDescription
            // 
            this.tbxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxDescription.Location = new System.Drawing.Point(78, 265);
            this.tbxDescription.Multiline = true;
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.ReadOnly = true;
            this.tbxDescription.Size = new System.Drawing.Size(1110, 73);
            this.tbxDescription.TabIndex = 75;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "reason_name";
            this.dataGridViewTextBoxColumn1.HeaderText = "Причина";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "description";
            this.dataGridViewTextBoxColumn2.HeaderText = "Опис";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "status_name";
            this.dataGridViewTextBoxColumn3.HeaderText = "Статус";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 230;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "user_created";
            this.dataGridViewTextBoxColumn4.HeaderText = "Створена";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 200;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "date_created";
            this.dataGridViewTextBoxColumn5.HeaderText = "Дата створення";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 230;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "user_closed";
            this.dataGridViewTextBoxColumn6.HeaderText = "Вирішена";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 200;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "date_closed";
            this.dataGridViewTextBoxColumn7.HeaderText = "Дата вирішення";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // taQkDelayReasons
            // 
            this.taQkDelayReasons.ClearBeforeFill = true;
            // 
            // DelayReasonsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 384);
            this.Controls.Add(this.tbxDescription);
            this.Controls.Add(this.tsButtons);
            this.Controls.Add(this.pbSplashControl);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvReasons);
            this.Name = "DelayReasonsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Причини затримки";
            this.Load += new System.EventHandler(this.DelayReasonsForm_Load);
            this.tsButtons.ResumeLayout(false);
            this.tsButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReasons)).EndInit();
            this.cmsReasonsActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsQkDelayReasons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSplashControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsButtons;
        private System.Windows.Forms.ToolStripButton btnNewReason;
        private System.Windows.Forms.ToolStripButton btnResolveReason;
        private System.Windows.Forms.ToolStripButton btnCancelReason;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvReasons;
        private System.Windows.Forms.ContextMenuStrip cmsReasonsActions;
        private System.Windows.Forms.ToolStripMenuItem miNewReason;
        private System.Windows.Forms.ToolStripMenuItem miResolveReason;
        private System.Windows.Forms.ToolStripMenuItem miCancelReason;
        private System.Windows.Forms.BindingSource bsQkDelayReasons;
        private WMSOffice.Data.Quality quality;
        private WMSOffice.Data.QualityTableAdapters.QK_Delay_ReasonsTableAdapter taQkDelayReasons;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.ToolStripSeparator tssAfterRefresh;
        private System.Windows.Forms.ToolStripMenuItem miRefresh;
        private System.Windows.Forms.ToolStripSeparator tssAfterMiRefresh;
        private System.ComponentModel.BackgroundWorker bwReasonsLoader;
        private System.Windows.Forms.Timer tmrLoadingShower;
        private System.Windows.Forms.PictureBox pbSplashControl;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox tbxDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn clReasonName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clStatusName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clUserCreated;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDateCreated;
        private System.Windows.Forms.DataGridViewTextBoxColumn clUserClosed;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDateClosed;
        private System.Windows.Forms.ToolStripSeparator tssAfterCancelReason;
        private System.Windows.Forms.ToolStripButton btnEditDescription;
        private System.Windows.Forms.ToolStripSeparator tssAfterMiCancelReason;
        private System.Windows.Forms.ToolStripMenuItem miEditDescription;
    }
}