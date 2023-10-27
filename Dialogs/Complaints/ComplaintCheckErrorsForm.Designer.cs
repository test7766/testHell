namespace WMSOffice.Dialogs.Complaints
{
    partial class ComplaintCheckErrorsForm
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.dgvExceptions = new System.Windows.Forms.DataGridView();
            this.messageTextDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkDocBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.complaints = new WMSOffice.Data.Complaints();
            this.checkDocTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.CheckDocTableAdapter();
            this.pnlButtons.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExceptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkDocBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(664, 8);
            this.btnOK.Size = new System.Drawing.Size(87, 23);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(754, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 329);
            this.pnlButtons.Size = new System.Drawing.Size(594, 43);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.SystemColors.Info;
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(594, 85);
            this.pnlHeader.TabIndex = 101;
            // 
            // lblHeader
            // 
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblHeader.ForeColor = System.Drawing.Color.Blue;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.lblHeader.Size = new System.Drawing.Size(594, 85);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "У Вас есть возможность игнорировать ошибки и предупреждения возникшие в результат" +
                "е проверок претензии и передать их на рассмотрение в ОМУ!!!";
            // 
            // dgvExceptions
            // 
            this.dgvExceptions.AllowUserToAddRows = false;
            this.dgvExceptions.AllowUserToDeleteRows = false;
            this.dgvExceptions.AllowUserToResizeRows = false;
            this.dgvExceptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvExceptions.AutoGenerateColumns = false;
            this.dgvExceptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExceptions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.messageTextDataGridViewTextBoxColumn});
            this.dgvExceptions.DataSource = this.checkDocBindingSource;
            this.dgvExceptions.Location = new System.Drawing.Point(0, 88);
            this.dgvExceptions.MultiSelect = false;
            this.dgvExceptions.Name = "dgvExceptions";
            this.dgvExceptions.ReadOnly = true;
            this.dgvExceptions.RowHeadersVisible = false;
            this.dgvExceptions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExceptions.Size = new System.Drawing.Size(594, 237);
            this.dgvExceptions.TabIndex = 102;
            this.dgvExceptions.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvExceptions_CellFormatting);
            // 
            // messageTextDataGridViewTextBoxColumn
            // 
            this.messageTextDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.messageTextDataGridViewTextBoxColumn.DataPropertyName = "MessageText";
            this.messageTextDataGridViewTextBoxColumn.HeaderText = "Ошибка/Предупреждение ";
            this.messageTextDataGridViewTextBoxColumn.Name = "messageTextDataGridViewTextBoxColumn";
            this.messageTextDataGridViewTextBoxColumn.ReadOnly = true;
            this.messageTextDataGridViewTextBoxColumn.Width = 167;
            // 
            // checkDocBindingSource
            // 
            this.checkDocBindingSource.DataMember = "CheckDoc";
            this.checkDocBindingSource.DataSource = this.complaints;
            // 
            // complaints
            // 
            this.complaints.DataSetName = "Complaints";
            this.complaints.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // checkDocTableAdapter
            // 
            this.checkDocTableAdapter.ClearBeforeFill = true;
            // 
            // ComplaintCheckErrorsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 372);
            this.Controls.Add(this.dgvExceptions);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "ComplaintCheckErrorsForm";
            this.Text = "Ошибки и предупреждения полученные в момент создания претензии";
            this.Load += new System.EventHandler(this.CreateComplaintCheckErrorsForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ComplaintCheckErrorsForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.Controls.SetChildIndex(this.dgvExceptions, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExceptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkDocBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.DataGridView dgvExceptions;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.BindingSource checkDocBindingSource;
        private WMSOffice.Data.Complaints complaints;
        private WMSOffice.Data.ComplaintsTableAdapters.CheckDocTableAdapter checkDocTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn messageTextDataGridViewTextBoxColumn;
    }
}