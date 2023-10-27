namespace WMSOffice.Dialogs.Inventory
{
    partial class InventoryFilialCheckForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventoryFilialCheckForm));
            this.btnClose = new System.Windows.Forms.Button();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btnRun = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dgvChecks = new System.Windows.Forms.DataGridView();
            this.Checked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.checkID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkDsc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.statusDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsFiChecksList = new System.Windows.Forms.BindingSource(this.components);
            this.inventory = new WMSOffice.Data.Inventory();
            this.taFiChecksList = new WMSOffice.Data.InventoryTableAdapters.FI_ChecksListTableAdapter();
            this.timerCheck = new System.Windows.Forms.Timer(this.components);
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChecks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFiChecksList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventory)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.ImageKey = "exit.png";
            this.btnClose.ImageList = this.imageList;
            this.btnClose.Location = new System.Drawing.Point(637, 357);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 31);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Выход";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "ok.png");
            this.imageList.Images.SetKeyName(1, "exit.png");
            this.imageList.Images.SetKeyName(2, "status-error.png");
            this.imageList.Images.SetKeyName(3, "status-offline.png");
            this.imageList.Images.SetKeyName(4, "status-ok.png");
            this.imageList.Images.SetKeyName(5, "status-warn.png");
            this.imageList.Images.SetKeyName(6, "refresh.png");
            // 
            // btnRun
            // 
            this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRun.Enabled = false;
            this.btnRun.ImageKey = "ok.png";
            this.btnRun.ImageList = this.imageList;
            this.btnRun.Location = new System.Drawing.Point(547, 357);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(89, 31);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "Запустить";
            this.btnRun.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRun.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.ImageKey = "refresh.png";
            this.btnRefresh.ImageList = this.imageList;
            this.btnRefresh.Location = new System.Drawing.Point(452, 357);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(89, 31);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dgvChecks
            // 
            this.dgvChecks.AllowUserToAddRows = false;
            this.dgvChecks.AllowUserToDeleteRows = false;
            this.dgvChecks.AllowUserToResizeColumns = false;
            this.dgvChecks.AllowUserToResizeRows = false;
            this.dgvChecks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvChecks.AutoGenerateColumns = false;
            this.dgvChecks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChecks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Checked,
            this.checkID,
            this.checkDsc,
            this.startTime,
            this.clmImage,
            this.statusDesc,
            this.Status_ID});
            this.dgvChecks.DataSource = this.bsFiChecksList;
            this.dgvChecks.Location = new System.Drawing.Point(0, 0);
            this.dgvChecks.MultiSelect = false;
            this.dgvChecks.Name = "dgvChecks";
            this.dgvChecks.RowHeadersVisible = false;
            this.dgvChecks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChecks.Size = new System.Drawing.Size(736, 351);
            this.dgvChecks.TabIndex = 3;
            this.dgvChecks.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChecks_CellDoubleClick);
            this.dgvChecks.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvChecks_CellFormatting);
            this.dgvChecks.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChecks_CellContentClick);
            // 
            // Checked
            // 
            this.Checked.DataPropertyName = "Checked";
            this.Checked.HeaderText = "";
            this.Checked.Name = "Checked";
            this.Checked.Width = 20;
            // 
            // checkID
            // 
            this.checkID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.checkID.DataPropertyName = "Check_ID";
            this.checkID.HeaderText = "№";
            this.checkID.Name = "checkID";
            this.checkID.ReadOnly = true;
            this.checkID.Width = 43;
            // 
            // checkDsc
            // 
            this.checkDsc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.checkDsc.DataPropertyName = "Check_Dsc";
            this.checkDsc.HeaderText = "Название проверки";
            this.checkDsc.Name = "checkDsc";
            this.checkDsc.ReadOnly = true;
            this.checkDsc.Width = 122;
            // 
            // startTime
            // 
            this.startTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.startTime.DataPropertyName = "StartTime";
            this.startTime.HeaderText = "Время запуска";
            this.startTime.Name = "startTime";
            this.startTime.ReadOnly = true;
            // 
            // clmImage
            // 
            this.clmImage.HeaderText = "";
            this.clmImage.Name = "clmImage";
            this.clmImage.ReadOnly = true;
            this.clmImage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmImage.Width = 23;
            // 
            // statusDesc
            // 
            this.statusDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.statusDesc.DataPropertyName = "Status_Desc";
            this.statusDesc.HeaderText = "Статус";
            this.statusDesc.Name = "statusDesc";
            this.statusDesc.ReadOnly = true;
            this.statusDesc.Width = 66;
            // 
            // Status_ID
            // 
            this.Status_ID.DataPropertyName = "Status_ID";
            this.Status_ID.HeaderText = "Status_ID";
            this.Status_ID.Name = "Status_ID";
            this.Status_ID.ReadOnly = true;
            this.Status_ID.Visible = false;
            // 
            // bsFiChecksList
            // 
            this.bsFiChecksList.DataMember = "FI_ChecksList";
            this.bsFiChecksList.DataSource = this.inventory;
            // 
            // inventory
            // 
            this.inventory.DataSetName = "Inventory";
            this.inventory.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // taFiChecksList
            // 
            this.taFiChecksList.ClearBeforeFill = true;
            // 
            // timerCheck
            // 
            this.timerCheck.Interval = 30000;
            this.timerCheck.Tick += new System.EventHandler(this.timerCheck_Tick);
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "Checked";
            this.dataGridViewCheckBoxColumn1.HeaderText = "";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Width = 20;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Check_ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "№";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Check_Dsc";
            this.dataGridViewTextBoxColumn2.HeaderText = "Название проверки";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "StartTime";
            this.dataGridViewTextBoxColumn3.HeaderText = "Время запуска";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn1.Width = 23;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Status_Desc";
            this.dataGridViewTextBoxColumn4.HeaderText = "Статус";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Status_ID";
            this.dataGridViewTextBoxColumn5.HeaderText = "Status_ID";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // InventoryFilialCheckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(738, 392);
            this.Controls.Add(this.dgvChecks);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnClose);
            this.Name = "InventoryFilialCheckForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Проверки инвентаризации филиалов";
            this.Load += new System.EventHandler(this.InventoryFilialCheckForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChecks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFiChecksList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvChecks;
        private System.Windows.Forms.BindingSource bsFiChecksList;
        private WMSOffice.Data.Inventory inventory;
        private WMSOffice.Data.InventoryTableAdapters.FI_ChecksListTableAdapter taFiChecksList;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Timer timerCheck;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Checked;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkID;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkDsc;
        private System.Windows.Forms.DataGridViewTextBoxColumn startTime;
        private System.Windows.Forms.DataGridViewImageColumn clmImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    }
}