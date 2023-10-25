namespace WMSOffice.Dialogs.Quality
{
    partial class LotnPrescriptionsForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.dgvPrescriptions = new System.Windows.Forms.DataGridView();
            this.clHoldTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clHoldDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDocNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDocDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clVendorLot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clLotNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clWhID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsAtGetPrescriptionsForLotn = new System.Windows.Forms.BindingSource(this.components);
            this.quality = new WMSOffice.Data.Quality();
            this.tbxDescription = new System.Windows.Forms.TextBox();
            this.taAtGetPrescriptionsForLotn = new WMSOffice.Data.QualityTableAdapters.AT_Get_Prescriptions_For_LotnTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrescriptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAtGetPrescriptionsForLotn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(1001, 293);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text = "Закрыть";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // dgvPrescriptions
            // 
            this.dgvPrescriptions.AllowUserToAddRows = false;
            this.dgvPrescriptions.AllowUserToDeleteRows = false;
            this.dgvPrescriptions.AllowUserToOrderColumns = true;
            this.dgvPrescriptions.AllowUserToResizeRows = false;
            this.dgvPrescriptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPrescriptions.AutoGenerateColumns = false;
            this.dgvPrescriptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrescriptions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clHoldTypeId,
            this.clHoldDate,
            this.clComment,
            this.clDocNumber,
            this.clDocDate,
            this.clItemID,
            this.clVendorLot,
            this.clLotNumber,
            this.clWhID});
            this.dgvPrescriptions.DataSource = this.bsAtGetPrescriptionsForLotn;
            this.dgvPrescriptions.Location = new System.Drawing.Point(12, 12);
            this.dgvPrescriptions.MultiSelect = false;
            this.dgvPrescriptions.Name = "dgvPrescriptions";
            this.dgvPrescriptions.ReadOnly = true;
            this.dgvPrescriptions.RowHeadersVisible = false;
            this.dgvPrescriptions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPrescriptions.Size = new System.Drawing.Size(1064, 177);
            this.dgvPrescriptions.TabIndex = 10;
            this.dgvPrescriptions.SelectionChanged += new System.EventHandler(this.dgvPrescriptions_SelectionChanged);
            // 
            // clHoldTypeId
            // 
            this.clHoldTypeId.DataPropertyName = "hold_type_id";
            this.clHoldTypeId.HeaderText = "Бл.";
            this.clHoldTypeId.Name = "clHoldTypeId";
            this.clHoldTypeId.ReadOnly = true;
            this.clHoldTypeId.Width = 30;
            // 
            // clHoldDate
            // 
            this.clHoldDate.DataPropertyName = "hold_date";
            this.clHoldDate.HeaderText = "Дата бл.";
            this.clHoldDate.Name = "clHoldDate";
            this.clHoldDate.ReadOnly = true;
            this.clHoldDate.Width = 80;
            // 
            // clComment
            // 
            this.clComment.DataPropertyName = "comment";
            this.clComment.HeaderText = "Описание";
            this.clComment.Name = "clComment";
            this.clComment.ReadOnly = true;
            this.clComment.Width = 250;
            // 
            // clDocNumber
            // 
            this.clDocNumber.DataPropertyName = "doc_number";
            this.clDocNumber.HeaderText = "Номер документа";
            this.clDocNumber.Name = "clDocNumber";
            this.clDocNumber.ReadOnly = true;
            this.clDocNumber.Width = 120;
            // 
            // clDocDate
            // 
            this.clDocDate.DataPropertyName = "doc_date";
            this.clDocDate.HeaderText = "Дата документа";
            this.clDocDate.Name = "clDocDate";
            this.clDocDate.ReadOnly = true;
            // 
            // clItemID
            // 
            this.clItemID.DataPropertyName = "item_id";
            this.clItemID.HeaderText = "Код товара";
            this.clItemID.Name = "clItemID";
            this.clItemID.ReadOnly = true;
            this.clItemID.Width = 80;
            // 
            // clVendorLot
            // 
            this.clVendorLot.DataPropertyName = "vendor_lot";
            this.clVendorLot.HeaderText = "Серия";
            this.clVendorLot.Name = "clVendorLot";
            this.clVendorLot.ReadOnly = true;
            // 
            // clLotNumber
            // 
            this.clLotNumber.DataPropertyName = "lot_number";
            this.clLotNumber.HeaderText = "Партия";
            this.clLotNumber.Name = "clLotNumber";
            this.clLotNumber.ReadOnly = true;
            // 
            // clWhID
            // 
            this.clWhID.DataPropertyName = "wh_id";
            this.clWhID.HeaderText = "Склад";
            this.clWhID.Name = "clWhID";
            this.clWhID.ReadOnly = true;
            this.clWhID.Width = 80;
            // 
            // bsAtGetPrescriptionsForLotn
            // 
            this.bsAtGetPrescriptionsForLotn.DataMember = "AT_Get_Prescriptions_For_Lotn";
            this.bsAtGetPrescriptionsForLotn.DataSource = this.quality;
            // 
            // quality
            // 
            this.quality.DataSetName = "Quality";
            this.quality.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbxDescription
            // 
            this.tbxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxDescription.Location = new System.Drawing.Point(12, 195);
            this.tbxDescription.Multiline = true;
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.ReadOnly = true;
            this.tbxDescription.Size = new System.Drawing.Size(1064, 92);
            this.tbxDescription.TabIndex = 20;
            // 
            // taAtGetPrescriptionsForLotn
            // 
            this.taAtGetPrescriptionsForLotn.ClearBeforeFill = true;
            // 
            // LotnPrescriptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1088, 328);
            this.Controls.Add(this.tbxDescription);
            this.Controls.Add(this.dgvPrescriptions);
            this.Controls.Add(this.btnCancel);
            this.Name = "LotnPrescriptionsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Предписания ГЛС";
            this.Load += new System.EventHandler(this.LotnPrescriptionsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrescriptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAtGetPrescriptionsForLotn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dgvPrescriptions;
        private System.Windows.Forms.TextBox tbxDescription;
        private System.Windows.Forms.BindingSource bsAtGetPrescriptionsForLotn;
        private WMSOffice.Data.Quality quality;
        private WMSOffice.Data.QualityTableAdapters.AT_Get_Prescriptions_For_LotnTableAdapter taAtGetPrescriptionsForLotn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clHoldTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clHoldDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDocNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDocDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clVendorLot;
        private System.Windows.Forms.DataGridViewTextBoxColumn clLotNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clWhID;
    }
}