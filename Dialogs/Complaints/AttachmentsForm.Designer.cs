namespace WMSOffice.Dialogs.Complaints
{
    partial class AttachmentsForm
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
            this.tsTools = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnView = new System.Windows.Forms.ToolStripButton();
            this.btnRemove = new System.Windows.Forms.ToolStripButton();
            this.dgvFiles = new System.Windows.Forms.DataGridView();
            this.clFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clFileLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Document_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Document_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsFiles = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.miView = new System.Windows.Forms.ToolStripMenuItem();
            this.miRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.bsAttachments = new System.Windows.Forms.BindingSource(this.components);
            this.complaints = new WMSOffice.Data.Complaints();
            this.dlgSaveFile = new System.Windows.Forms.SaveFileDialog();
            this.btnClose = new System.Windows.Forms.Button();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEditAttachmentRequisites = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.miEditAttachmentRequisites = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).BeginInit();
            this.cmsFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsAttachments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).BeginInit();
            this.SuspendLayout();
            // 
            // tsTools
            // 
            this.tsTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnView,
            this.toolStripSeparator1,
            this.btnEditAttachmentRequisites,
            this.toolStripSeparator2,
            this.btnRemove});
            this.tsTools.Location = new System.Drawing.Point(0, 0);
            this.tsTools.Name = "tsTools";
            this.tsTools.Size = new System.Drawing.Size(734, 25);
            this.tsTools.TabIndex = 101;
            this.tsTools.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::WMSOffice.Properties.Resources.add;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(79, 22);
            this.btnAdd.Text = "Добавить";
            this.btnAdd.Click += new System.EventHandler(this.Add_Click);
            // 
            // btnView
            // 
            this.btnView.Enabled = false;
            this.btnView.Image = global::WMSOffice.Properties.Resources.view;
            this.btnView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(101, 22);
            this.btnView.Text = "Просмотреть";
            this.btnView.Click += new System.EventHandler(this.View_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Enabled = false;
            this.btnRemove.Image = global::WMSOffice.Properties.Resources.Delete;
            this.btnRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(71, 22);
            this.btnRemove.Text = "Удалить";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // dgvFiles
            // 
            this.dgvFiles.AllowUserToAddRows = false;
            this.dgvFiles.AllowUserToDeleteRows = false;
            this.dgvFiles.AllowUserToOrderColumns = true;
            this.dgvFiles.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgvFiles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFiles.AutoGenerateColumns = false;
            this.dgvFiles.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFiles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clFileName,
            this.clDescription,
            this.clFileLength,
            this.Document_Number,
            this.Document_Date});
            this.dgvFiles.ContextMenuStrip = this.cmsFiles;
            this.dgvFiles.DataSource = this.bsAttachments;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFiles.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvFiles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvFiles.Location = new System.Drawing.Point(0, 25);
            this.dgvFiles.Name = "dgvFiles";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFiles.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvFiles.RowHeadersVisible = false;
            this.dgvFiles.RowTemplate.Height = 21;
            this.dgvFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFiles.ShowEditingIcon = false;
            this.dgvFiles.Size = new System.Drawing.Size(722, 244);
            this.dgvFiles.TabIndex = 102;
            this.dgvFiles.DoubleClick += new System.EventHandler(this.dgvFiles_DoubleClick);
            this.dgvFiles.SelectionChanged += new System.EventHandler(this.dgvFiles_SelectionChanged);
            // 
            // clFileName
            // 
            this.clFileName.DataPropertyName = "File_Name";
            this.clFileName.HeaderText = "Имя файла";
            this.clFileName.Name = "clFileName";
            this.clFileName.ReadOnly = true;
            this.clFileName.Width = 160;
            // 
            // clDescription
            // 
            this.clDescription.DataPropertyName = "Description";
            this.clDescription.HeaderText = "Описание (тип)";
            this.clDescription.Name = "clDescription";
            this.clDescription.ReadOnly = true;
            this.clDescription.Width = 200;
            // 
            // clFileLength
            // 
            this.clFileLength.DataPropertyName = "File_Length";
            this.clFileLength.HeaderText = "Размер, Кб";
            this.clFileLength.Name = "clFileLength";
            this.clFileLength.ReadOnly = true;
            this.clFileLength.Width = 70;
            // 
            // Document_Number
            // 
            this.Document_Number.DataPropertyName = "Document_Number";
            this.Document_Number.HeaderText = "№ док-та";
            this.Document_Number.Name = "Document_Number";
            this.Document_Number.ReadOnly = true;
            // 
            // Document_Date
            // 
            this.Document_Date.DataPropertyName = "Document_Date";
            this.Document_Date.HeaderText = "Дата док-та";
            this.Document_Date.Name = "Document_Date";
            this.Document_Date.ReadOnly = true;
            // 
            // cmsFiles
            // 
            this.cmsFiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAdd,
            this.miView,
            this.toolStripSeparator3,
            this.miEditAttachmentRequisites,
            this.toolStripSeparator4,
            this.miRemove});
            this.cmsFiles.Name = "cmsFiles";
            this.cmsFiles.Size = new System.Drawing.Size(190, 126);
            // 
            // miAdd
            // 
            this.miAdd.Image = global::WMSOffice.Properties.Resources.add;
            this.miAdd.Name = "miAdd";
            this.miAdd.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.miAdd.Size = new System.Drawing.Size(189, 22);
            this.miAdd.Text = "Добавить";
            this.miAdd.Click += new System.EventHandler(this.Add_Click);
            // 
            // miView
            // 
            this.miView.Enabled = false;
            this.miView.Image = global::WMSOffice.Properties.Resources.view;
            this.miView.Name = "miView";
            this.miView.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.miView.Size = new System.Drawing.Size(189, 22);
            this.miView.Text = "Просмотреть";
            this.miView.Click += new System.EventHandler(this.View_Click);
            // 
            // miRemove
            // 
            this.miRemove.Enabled = false;
            this.miRemove.Image = global::WMSOffice.Properties.Resources.Delete;
            this.miRemove.Name = "miRemove";
            this.miRemove.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.miRemove.Size = new System.Drawing.Size(189, 22);
            this.miRemove.Text = "Удалить";
            this.miRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // bsAttachments
            // 
            this.bsAttachments.DataMember = "Attachments";
            this.bsAttachments.DataSource = this.complaints;
            // 
            // complaints
            // 
            this.complaints.DataSetName = "Complaints";
            this.complaints.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dlgSaveFile
            // 
            this.dlgSaveFile.Filter = "Все файлы|*.*";
            this.dlgSaveFile.Title = "Сохранение прикрепленного файла";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(647, 277);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 103;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnEditAttachmentRequisites
            // 
            this.btnEditAttachmentRequisites.Enabled = false;
            this.btnEditAttachmentRequisites.Image = global::WMSOffice.Properties.Resources.Edit_10x10;
            this.btnEditAttachmentRequisites.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditAttachmentRequisites.Name = "btnEditAttachmentRequisites";
            this.btnEditAttachmentRequisites.Size = new System.Drawing.Size(142, 22);
            this.btnEditAttachmentRequisites.Text = "Изменить реквизиты";
            this.btnEditAttachmentRequisites.Click += new System.EventHandler(this.btnEditAttachmentRequisites_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // miEditAttachmentRequisites
            // 
            this.miEditAttachmentRequisites.Enabled = false;
            this.miEditAttachmentRequisites.Image = global::WMSOffice.Properties.Resources.Edit_10x10;
            this.miEditAttachmentRequisites.Name = "miEditAttachmentRequisites";
            this.miEditAttachmentRequisites.Size = new System.Drawing.Size(189, 22);
            this.miEditAttachmentRequisites.Text = "Изменить реквизиты";
            this.miEditAttachmentRequisites.Click += new System.EventHandler(this.btnEditAttachmentRequisites_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(186, 6);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(186, 6);
            // 
            // AttachmentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 312);
            this.Controls.Add(this.dgvFiles);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tsTools);
            this.Name = "AttachmentsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Прикрепленные к претензии файлы";
            this.tsTools.ResumeLayout(false);
            this.tsTools.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).EndInit();
            this.cmsFiles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsAttachments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsTools;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnView;
        private System.Windows.Forms.DataGridView dgvFiles;
        private WMSOffice.Data.Complaints complaints;
        private System.Windows.Forms.SaveFileDialog dlgSaveFile;
        private System.Windows.Forms.BindingSource bsAttachments;
        private System.Windows.Forms.ToolStripButton btnRemove;
        private System.Windows.Forms.ContextMenuStrip cmsFiles;
        private System.Windows.Forms.ToolStripMenuItem miAdd;
        private System.Windows.Forms.ToolStripMenuItem miView;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ToolStripMenuItem miRemove;
        private System.Windows.Forms.DataGridViewTextBoxColumn clFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn clFileLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn Document_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Document_Date;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnEditAttachmentRequisites;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem miEditAttachmentRequisites;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;

    }
}