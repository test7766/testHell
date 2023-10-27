namespace WMSOffice.Dialogs.Inventory
{
    partial class PostInventoryFilialAddDocScansForm
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
            this.btnClose = new System.Windows.Forms.Button();
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.dgvFiles = new System.Windows.Forms.DataGridView();
            this.bsFpGetCorrectionAttachments = new System.Windows.Forms.BindingSource(this.components);
            this.inventory = new WMSOffice.Data.Inventory();
            this.tsTools = new System.Windows.Forms.ToolStrip();
            this.btnAddDoc = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveDoc = new System.Windows.Forms.ToolStripButton();
            this.pnlPictureBox = new System.Windows.Forms.Panel();
            this.pbImageDisplaying = new System.Windows.Forms.PictureBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.taFpGetCorrectionAttachments = new WMSOffice.Data.InventoryTableAdapters.FP_Get_Correction_AttachmentsTableAdapter();
            this.lblNotPicture = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clAttachmentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFpGetCorrectionAttachments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventory)).BeginInit();
            this.tsTools.SuspendLayout();
            this.pnlPictureBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImageDisplaying)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(844, 538);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 35);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // spcMain
            // 
            this.spcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.spcMain.Location = new System.Drawing.Point(12, 1);
            this.spcMain.Name = "spcMain";
            // 
            // spcMain.Panel1
            // 
            this.spcMain.Panel1.Controls.Add(this.dgvFiles);
            this.spcMain.Panel1.Controls.Add(this.tsTools);
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.pnlPictureBox);
            this.spcMain.Size = new System.Drawing.Size(924, 531);
            this.spcMain.SplitterDistance = 288;
            this.spcMain.TabIndex = 1;
            // 
            // dgvFiles
            // 
            this.dgvFiles.AllowUserToAddRows = false;
            this.dgvFiles.AllowUserToDeleteRows = false;
            this.dgvFiles.AllowUserToResizeRows = false;
            this.dgvFiles.AutoGenerateColumns = false;
            this.dgvFiles.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clAttachmentID,
            this.clFileName,
            this.clDescription});
            this.dgvFiles.DataSource = this.bsFpGetCorrectionAttachments;
            this.dgvFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFiles.Location = new System.Drawing.Point(0, 39);
            this.dgvFiles.MultiSelect = false;
            this.dgvFiles.Name = "dgvFiles";
            this.dgvFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFiles.Size = new System.Drawing.Size(288, 492);
            this.dgvFiles.TabIndex = 1;
            this.dgvFiles.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvFiles_CellValidating);
            this.dgvFiles.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFiles_CellEndEdit);
            this.dgvFiles.SelectionChanged += new System.EventHandler(this.dgvFiles_SelectionChanged);
            // 
            // bsFpGetCorrectionAttachments
            // 
            this.bsFpGetCorrectionAttachments.DataMember = "FP_Get_Correction_Attachments";
            this.bsFpGetCorrectionAttachments.DataSource = this.inventory;
            // 
            // inventory
            // 
            this.inventory.DataSetName = "Inventory";
            this.inventory.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tsTools
            // 
            this.tsTools.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddDoc,
            this.btnRemoveDoc});
            this.tsTools.Location = new System.Drawing.Point(0, 0);
            this.tsTools.Name = "tsTools";
            this.tsTools.Size = new System.Drawing.Size(288, 39);
            this.tsTools.TabIndex = 0;
            this.tsTools.Text = "toolStrip1";
            // 
            // btnAddDoc
            // 
            this.btnAddDoc.Image = global::WMSOffice.Properties.Resources.document_new;
            this.btnAddDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddDoc.Name = "btnAddDoc";
            this.btnAddDoc.Size = new System.Drawing.Size(127, 36);
            this.btnAddDoc.Text = "Добавить файл";
            this.btnAddDoc.Click += new System.EventHandler(this.btnAddDoc_Click);
            // 
            // btnRemoveDoc
            // 
            this.btnRemoveDoc.Image = global::WMSOffice.Properties.Resources.Delete;
            this.btnRemoveDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveDoc.Name = "btnRemoveDoc";
            this.btnRemoveDoc.Size = new System.Drawing.Size(119, 36);
            this.btnRemoveDoc.Text = "Удалить файл";
            this.btnRemoveDoc.Click += new System.EventHandler(this.btnRemoveDoc_Click);
            // 
            // pnlPictureBox
            // 
            this.pnlPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPictureBox.AutoScroll = true;
            this.pnlPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPictureBox.Controls.Add(this.lblNotPicture);
            this.pnlPictureBox.Controls.Add(this.pbImageDisplaying);
            this.pnlPictureBox.Location = new System.Drawing.Point(3, 0);
            this.pnlPictureBox.Name = "pnlPictureBox";
            this.pnlPictureBox.Size = new System.Drawing.Size(626, 528);
            this.pnlPictureBox.TabIndex = 1;
            // 
            // pbImageDisplaying
            // 
            this.pbImageDisplaying.Location = new System.Drawing.Point(0, 0);
            this.pbImageDisplaying.Name = "pbImageDisplaying";
            this.pbImageDisplaying.Size = new System.Drawing.Size(42, 114);
            this.pbImageDisplaying.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbImageDisplaying.TabIndex = 0;
            this.pbImageDisplaying.TabStop = false;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Все файлы|*.*";
            this.openFileDialog.SupportMultiDottedExtensions = true;
            this.openFileDialog.Title = "Выбор файла";
            // 
            // taFpGetCorrectionAttachments
            // 
            this.taFpGetCorrectionAttachments.ClearBeforeFill = true;
            // 
            // lblNotPicture
            // 
            this.lblNotPicture.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNotPicture.AutoSize = true;
            this.lblNotPicture.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNotPicture.ForeColor = System.Drawing.Color.Maroon;
            this.lblNotPicture.Location = new System.Drawing.Point(94, 254);
            this.lblNotPicture.Name = "lblNotPicture";
            this.lblNotPicture.Size = new System.Drawing.Size(441, 31);
            this.lblNotPicture.TabIndex = 1;
            this.lblNotPicture.Text = "Этот файл не является рисунком!";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Attachment_ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "Attachment_ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "File_Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Название";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 82;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Description";
            this.dataGridViewTextBoxColumn3.HeaderText = "Описание";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 82;
            // 
            // clAttachmentID
            // 
            this.clAttachmentID.DataPropertyName = "Attachment_ID";
            this.clAttachmentID.HeaderText = "Attachment_ID";
            this.clAttachmentID.Name = "clAttachmentID";
            this.clAttachmentID.ReadOnly = true;
            this.clAttachmentID.Visible = false;
            // 
            // clFileName
            // 
            this.clFileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clFileName.DataPropertyName = "File_Name";
            this.clFileName.HeaderText = "Название";
            this.clFileName.Name = "clFileName";
            this.clFileName.Width = 82;
            // 
            // clDescription
            // 
            this.clDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clDescription.DataPropertyName = "Description";
            this.clDescription.HeaderText = "Описание";
            this.clDescription.Name = "clDescription";
            this.clDescription.Width = 82;
            // 
            // PostInventoryFilialAddDocScansForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 585);
            this.Controls.Add(this.spcMain);
            this.Controls.Add(this.btnClose);
            this.Name = "PostInventoryFilialAddDocScansForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Прикрепленные файлы";
            this.Load += new System.EventHandler(this.PostInventoryFilialAddDocScansForm_Load);
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel1.PerformLayout();
            this.spcMain.Panel2.ResumeLayout(false);
            this.spcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFpGetCorrectionAttachments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventory)).EndInit();
            this.tsTools.ResumeLayout(false);
            this.tsTools.PerformLayout();
            this.pnlPictureBox.ResumeLayout(false);
            this.pnlPictureBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImageDisplaying)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.SplitContainer spcMain;
        private System.Windows.Forms.ToolStrip tsTools;
        private System.Windows.Forms.PictureBox pbImageDisplaying;
        private System.Windows.Forms.ToolStripButton btnAddDoc;
        private System.Windows.Forms.ToolStripButton btnRemoveDoc;
        private System.Windows.Forms.DataGridView dgvFiles;
        private System.Windows.Forms.BindingSource bsFpGetCorrectionAttachments;
        private WMSOffice.Data.Inventory inventory;
        private WMSOffice.Data.InventoryTableAdapters.FP_Get_Correction_AttachmentsTableAdapter taFpGetCorrectionAttachments;
        private System.Windows.Forms.DataGridViewTextBoxColumn clAttachmentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Panel pnlPictureBox;
        private System.Windows.Forms.Label lblNotPicture;
    }
}