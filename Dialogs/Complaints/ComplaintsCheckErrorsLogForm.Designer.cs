namespace WMSOffice.Dialogs.Complaints
{
    partial class ComplaintsCheckErrorsLogForm
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
            this.scMainLayout = new System.Windows.Forms.SplitContainer();
            this.dgvExceptionsHeaders = new System.Windows.Forms.DataGridView();
            this.docIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cODocIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Formatted_Doc_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Formatted_Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Formatted_Warehouse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkExceptionsHeadersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.complaints = new WMSOffice.Data.Complaints();
            this.dgvExceptionsDetails = new System.Windows.Forms.DataGridView();
            this.messageTextDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkExceptionsDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.checkExceptionsHeadersTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.CheckExceptionsHeadersTableAdapter();
            this.checkExceptionsDetailsTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.CheckExceptionsDetailsTableAdapter();
            this.tsMainMenu = new System.Windows.Forms.ToolStrip();
            this.btnAcceptException = new System.Windows.Forms.ToolStripButton();
            this.btnDeclineException = new System.Windows.Forms.ToolStripButton();
            this.pnlButtons.SuspendLayout();
            this.scMainLayout.Panel1.SuspendLayout();
            this.scMainLayout.Panel2.SuspendLayout();
            this.scMainLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExceptionsHeaders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkExceptionsHeadersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExceptionsDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkExceptionsDetailsBindingSource)).BeginInit();
            this.tsMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(2225, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(2315, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 519);
            this.pnlButtons.Size = new System.Drawing.Size(1034, 43);
            // 
            // scMainLayout
            // 
            this.scMainLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scMainLayout.Location = new System.Drawing.Point(0, 42);
            this.scMainLayout.Name = "scMainLayout";
            this.scMainLayout.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMainLayout.Panel1
            // 
            this.scMainLayout.Panel1.Controls.Add(this.dgvExceptionsHeaders);
            // 
            // scMainLayout.Panel2
            // 
            this.scMainLayout.Panel2.Controls.Add(this.dgvExceptionsDetails);
            this.scMainLayout.Size = new System.Drawing.Size(1034, 471);
            this.scMainLayout.SplitterDistance = 229;
            this.scMainLayout.TabIndex = 101;
            // 
            // dgvExceptionsHeaders
            // 
            this.dgvExceptionsHeaders.AllowUserToAddRows = false;
            this.dgvExceptionsHeaders.AllowUserToDeleteRows = false;
            this.dgvExceptionsHeaders.AllowUserToResizeRows = false;
            this.dgvExceptionsHeaders.AutoGenerateColumns = false;
            this.dgvExceptionsHeaders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExceptionsHeaders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.docIDDataGridViewTextBoxColumn,
            this.cODocIDDataGridViewTextBoxColumn,
            this.Formatted_Doc_Type,
            this.userNameDataGridViewTextBoxColumn,
            this.docDateDataGridViewTextBoxColumn,
            this.Comment,
            this.Formatted_Address,
            this.Formatted_Warehouse});
            this.dgvExceptionsHeaders.DataSource = this.checkExceptionsHeadersBindingSource;
            this.dgvExceptionsHeaders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExceptionsHeaders.Location = new System.Drawing.Point(0, 0);
            this.dgvExceptionsHeaders.MultiSelect = false;
            this.dgvExceptionsHeaders.Name = "dgvExceptionsHeaders";
            this.dgvExceptionsHeaders.ReadOnly = true;
            this.dgvExceptionsHeaders.RowHeadersVisible = false;
            this.dgvExceptionsHeaders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExceptionsHeaders.Size = new System.Drawing.Size(1034, 229);
            this.dgvExceptionsHeaders.TabIndex = 0;
            this.dgvExceptionsHeaders.SelectionChanged += new System.EventHandler(this.dgvExceptionsHeaders_SelectionChanged);
            // 
            // docIDDataGridViewTextBoxColumn
            // 
            this.docIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.docIDDataGridViewTextBoxColumn.DataPropertyName = "Doc_ID";
            this.docIDDataGridViewTextBoxColumn.HeaderText = "Код исключения";
            this.docIDDataGridViewTextBoxColumn.Name = "docIDDataGridViewTextBoxColumn";
            this.docIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.docIDDataGridViewTextBoxColumn.Width = 106;
            // 
            // cODocIDDataGridViewTextBoxColumn
            // 
            this.cODocIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cODocIDDataGridViewTextBoxColumn.DataPropertyName = "CO_Doc_ID";
            this.cODocIDDataGridViewTextBoxColumn.HeaderText = "Код претензии";
            this.cODocIDDataGridViewTextBoxColumn.Name = "cODocIDDataGridViewTextBoxColumn";
            this.cODocIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.cODocIDDataGridViewTextBoxColumn.Width = 98;
            // 
            // Formatted_Doc_Type
            // 
            this.Formatted_Doc_Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Formatted_Doc_Type.DataPropertyName = "Formatted_Doc_Type";
            this.Formatted_Doc_Type.HeaderText = "Тип претензии";
            this.Formatted_Doc_Type.Name = "Formatted_Doc_Type";
            this.Formatted_Doc_Type.ReadOnly = true;
            this.Formatted_Doc_Type.Width = 98;
            // 
            // userNameDataGridViewTextBoxColumn
            // 
            this.userNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.userNameDataGridViewTextBoxColumn.DataPropertyName = "User_Name";
            this.userNameDataGridViewTextBoxColumn.HeaderText = "Ф.И.О. инициатора исключения";
            this.userNameDataGridViewTextBoxColumn.Name = "userNameDataGridViewTextBoxColumn";
            this.userNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.userNameDataGridViewTextBoxColumn.Width = 177;
            // 
            // docDateDataGridViewTextBoxColumn
            // 
            this.docDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.docDateDataGridViewTextBoxColumn.DataPropertyName = "Doc_Date";
            this.docDateDataGridViewTextBoxColumn.HeaderText = "Дата создания исключения";
            this.docDateDataGridViewTextBoxColumn.Name = "docDateDataGridViewTextBoxColumn";
            this.docDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.docDateDataGridViewTextBoxColumn.Width = 158;
            // 
            // Comment
            // 
            this.Comment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Comment.DataPropertyName = "Comment";
            this.Comment.HeaderText = "Примечание к исключению";
            this.Comment.Name = "Comment";
            this.Comment.ReadOnly = true;
            this.Comment.Width = 155;
            // 
            // Formatted_Address
            // 
            this.Formatted_Address.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Formatted_Address.DataPropertyName = "Formatted_Address";
            this.Formatted_Address.HeaderText = "Адрес доставки претензии";
            this.Formatted_Address.Name = "Formatted_Address";
            this.Formatted_Address.ReadOnly = true;
            this.Formatted_Address.Width = 154;
            // 
            // Formatted_Warehouse
            // 
            this.Formatted_Warehouse.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Formatted_Warehouse.DataPropertyName = "Formatted_Warehouse";
            this.Formatted_Warehouse.HeaderText = "Склад";
            this.Formatted_Warehouse.Name = "Formatted_Warehouse";
            this.Formatted_Warehouse.ReadOnly = true;
            this.Formatted_Warehouse.Width = 63;
            // 
            // checkExceptionsHeadersBindingSource
            // 
            this.checkExceptionsHeadersBindingSource.DataMember = "CheckExceptionsHeaders";
            this.checkExceptionsHeadersBindingSource.DataSource = this.complaints;
            // 
            // complaints
            // 
            this.complaints.DataSetName = "Complaints";
            this.complaints.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dgvExceptionsDetails
            // 
            this.dgvExceptionsDetails.AllowUserToAddRows = false;
            this.dgvExceptionsDetails.AllowUserToDeleteRows = false;
            this.dgvExceptionsDetails.AllowUserToResizeRows = false;
            this.dgvExceptionsDetails.AutoGenerateColumns = false;
            this.dgvExceptionsDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExceptionsDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.messageTextDataGridViewTextBoxColumn});
            this.dgvExceptionsDetails.DataSource = this.checkExceptionsDetailsBindingSource;
            this.dgvExceptionsDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExceptionsDetails.Location = new System.Drawing.Point(0, 0);
            this.dgvExceptionsDetails.MultiSelect = false;
            this.dgvExceptionsDetails.Name = "dgvExceptionsDetails";
            this.dgvExceptionsDetails.ReadOnly = true;
            this.dgvExceptionsDetails.RowHeadersVisible = false;
            this.dgvExceptionsDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExceptionsDetails.Size = new System.Drawing.Size(1034, 238);
            this.dgvExceptionsDetails.TabIndex = 0;
            this.dgvExceptionsDetails.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvExceptionsDetails_CellFormatting);
            // 
            // messageTextDataGridViewTextBoxColumn
            // 
            this.messageTextDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.messageTextDataGridViewTextBoxColumn.DataPropertyName = "MessageText";
            this.messageTextDataGridViewTextBoxColumn.HeaderText = "Ошибка/Предупреждение";
            this.messageTextDataGridViewTextBoxColumn.Name = "messageTextDataGridViewTextBoxColumn";
            this.messageTextDataGridViewTextBoxColumn.ReadOnly = true;
            this.messageTextDataGridViewTextBoxColumn.Width = 164;
            // 
            // checkExceptionsDetailsBindingSource
            // 
            this.checkExceptionsDetailsBindingSource.DataMember = "CheckExceptionsDetails";
            this.checkExceptionsDetailsBindingSource.DataSource = this.complaints;
            // 
            // checkExceptionsHeadersTableAdapter
            // 
            this.checkExceptionsHeadersTableAdapter.ClearBeforeFill = true;
            // 
            // checkExceptionsDetailsTableAdapter
            // 
            this.checkExceptionsDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // tsMainMenu
            // 
            this.tsMainMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAcceptException,
            this.btnDeclineException});
            this.tsMainMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMainMenu.Name = "tsMainMenu";
            this.tsMainMenu.Size = new System.Drawing.Size(1034, 39);
            this.tsMainMenu.TabIndex = 102;
            this.tsMainMenu.Text = "toolStrip1";
            // 
            // btnAcceptException
            // 
            this.btnAcceptException.Image = global::WMSOffice.Properties.Resources.ok;
            this.btnAcceptException.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAcceptException.Name = "btnAcceptException";
            this.btnAcceptException.Size = new System.Drawing.Size(113, 36);
            this.btnAcceptException.Text = "Подтвердить";
            this.btnAcceptException.Click += new System.EventHandler(this.btnAcceptException_Click);
            // 
            // btnDeclineException
            // 
            this.btnDeclineException.Image = global::WMSOffice.Properties.Resources.symbol_stop;
            this.btnDeclineException.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeclineException.Name = "btnDeclineException";
            this.btnDeclineException.Size = new System.Drawing.Size(102, 36);
            this.btnDeclineException.Text = "Отклонить";
            this.btnDeclineException.Click += new System.EventHandler(this.btnDeclineException_Click);
            // 
            // ComplaintsCheckErrorsLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 562);
            this.Controls.Add(this.tsMainMenu);
            this.Controls.Add(this.scMainLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "ComplaintsCheckErrorsLogForm";
            this.Text = "Подтверждение исключений проверок";
            this.Controls.SetChildIndex(this.scMainLayout, 0);
            this.Controls.SetChildIndex(this.tsMainMenu, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.scMainLayout.Panel1.ResumeLayout(false);
            this.scMainLayout.Panel2.ResumeLayout(false);
            this.scMainLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExceptionsHeaders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkExceptionsHeadersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExceptionsDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkExceptionsDetailsBindingSource)).EndInit();
            this.tsMainMenu.ResumeLayout(false);
            this.tsMainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer scMainLayout;
        private System.Windows.Forms.DataGridView dgvExceptionsHeaders;
        private System.Windows.Forms.DataGridView dgvExceptionsDetails;
        private System.Windows.Forms.BindingSource checkExceptionsHeadersBindingSource;
        private WMSOffice.Data.Complaints complaints;
        private WMSOffice.Data.ComplaintsTableAdapters.CheckExceptionsHeadersTableAdapter checkExceptionsHeadersTableAdapter;
        private System.Windows.Forms.BindingSource checkExceptionsDetailsBindingSource;
        private WMSOffice.Data.ComplaintsTableAdapters.CheckExceptionsDetailsTableAdapter checkExceptionsDetailsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn messageTextDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cODocIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Formatted_Doc_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
        private System.Windows.Forms.DataGridViewTextBoxColumn Formatted_Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Formatted_Warehouse;
        private System.Windows.Forms.ToolStrip tsMainMenu;
        private System.Windows.Forms.ToolStripButton btnAcceptException;
        private System.Windows.Forms.ToolStripButton btnDeclineException;
    }
}