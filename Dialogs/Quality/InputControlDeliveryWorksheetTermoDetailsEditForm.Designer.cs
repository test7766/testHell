namespace WMSOffice.Dialogs.Quality
{
    partial class InputControlDeliveryWorksheetTermoDetailsEditForm
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.cbSensorsAreAbsent = new System.Windows.Forms.CheckBox();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.aPEquipmentTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quality = new WMSOffice.Data.Quality();
            this.aPVersionTermoDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aP_Version_Termo_DetailTableAdapter = new WMSOffice.Data.QualityTableAdapters.AP_Version_Termo_DetailTableAdapter();
            this.aP_Equipment_TypesTableAdapter = new WMSOffice.Data.QualityTableAdapters.AP_Equipment_TypesTableAdapter();
            this.clTermo_mode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDate = new WMSOffice.Controls.Custom.DataGridViewDatePickerColumn();
            this.clEquipmentType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.EquipmentNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTr_Scaner_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clT_Fact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clT_Min = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clT_Max = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlButtons.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aPEquipmentTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aPVersionTermoDetailBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(4141, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(4231, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 382);
            this.pnlButtons.Size = new System.Drawing.Size(1144, 43);
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.cbSensorsAreAbsent);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1144, 30);
            this.pnlHeader.TabIndex = 101;
            // 
            // cbSensorsAreAbsent
            // 
            this.cbSensorsAreAbsent.AutoSize = true;
            this.cbSensorsAreAbsent.Location = new System.Drawing.Point(12, 7);
            this.cbSensorsAreAbsent.Name = "cbSensorsAreAbsent";
            this.cbSensorsAreAbsent.Size = new System.Drawing.Size(94, 17);
            this.cbSensorsAreAbsent.TabIndex = 0;
            this.cbSensorsAreAbsent.Text = "Нет датчиков";
            this.cbSensorsAreAbsent.UseVisualStyleBackColor = true;
            this.cbSensorsAreAbsent.CheckedChanged += new System.EventHandler(this.cbSensorsAreAbsent_CheckedChanged);
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContent.Controls.Add(this.dgvItems);
            this.pnlContent.Location = new System.Drawing.Point(0, 36);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1144, 340);
            this.pnlContent.TabIndex = 102;
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToResizeColumns = false;
            this.dgvItems.AllowUserToResizeRows = false;
            this.dgvItems.AutoGenerateColumns = false;
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvItems.ColumnHeadersHeight = 20;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clTermo_mode,
            this.clDate,
            this.clEquipmentType,
            this.EquipmentNumber,
            this.clTr_Scaner_Id,
            this.clT_Fact,
            this.clT_Min,
            this.clT_Max,
            this.Comment,
            this.Note});
            this.dgvItems.DataSource = this.aPVersionTermoDetailBindingSource;
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItems.Location = new System.Drawing.Point(0, 0);
            this.dgvItems.MultiSelect = false;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(1144, 340);
            this.dgvItems.TabIndex = 0;
            this.dgvItems.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItems_CellValueChanged);
            this.dgvItems.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvItems_UserDeletingRow);
            this.dgvItems.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvItems_CellFormatting);
            this.dgvItems.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvItems_DefaultValuesNeeded);
            this.dgvItems.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvItems_EditingControlShowing);
            this.dgvItems.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvItems_DataError);
            this.dgvItems.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItems_CellEnter);
            // 
            // aPEquipmentTypesBindingSource
            // 
            this.aPEquipmentTypesBindingSource.DataMember = "AP_Equipment_Types";
            this.aPEquipmentTypesBindingSource.DataSource = this.quality;
            // 
            // quality
            // 
            this.quality.DataSetName = "Quality";
            this.quality.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // aPVersionTermoDetailBindingSource
            // 
            this.aPVersionTermoDetailBindingSource.DataMember = "AP_Version_Termo_Detail";
            this.aPVersionTermoDetailBindingSource.DataSource = this.quality;
            // 
            // aP_Version_Termo_DetailTableAdapter
            // 
            this.aP_Version_Termo_DetailTableAdapter.ClearBeforeFill = true;
            // 
            // aP_Equipment_TypesTableAdapter
            // 
            this.aP_Equipment_TypesTableAdapter.ClearBeforeFill = true;
            // 
            // clTermo_mode
            // 
            this.clTermo_mode.DataPropertyName = "Termo_mode";
            this.clTermo_mode.HeaderText = "Темп. режим";
            this.clTermo_mode.Name = "clTermo_mode";
            this.clTermo_mode.ReadOnly = true;
            this.clTermo_mode.Width = 99;
            // 
            // clDate
            // 
            this.clDate.DataPropertyName = "Date";
            this.clDate.HeaderText = "Дата/время";
            this.clDate.Name = "clDate";
            this.clDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clDate.Width = 95;
            // 
            // clEquipmentType
            // 
            this.clEquipmentType.DataPropertyName = "EquipmentType";
            this.clEquipmentType.DataSource = this.aPEquipmentTypesBindingSource;
            this.clEquipmentType.DisplayMember = "TypeDesc";
            this.clEquipmentType.HeaderText = "Вид оборудования";
            this.clEquipmentType.Name = "clEquipmentType";
            this.clEquipmentType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clEquipmentType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clEquipmentType.ValueMember = "ID";
            this.clEquipmentType.Width = 125;
            // 
            // EquipmentNumber
            // 
            this.EquipmentNumber.DataPropertyName = "EquipmentNumber";
            this.EquipmentNumber.HeaderText = "Номер оборудования";
            this.EquipmentNumber.Name = "EquipmentNumber";
            this.EquipmentNumber.Width = 140;
            // 
            // clTr_Scaner_Id
            // 
            this.clTr_Scaner_Id.DataPropertyName = "Tr_Scaner_Id";
            this.clTr_Scaner_Id.HeaderText = "№ датчика";
            this.clTr_Scaner_Id.Name = "clTr_Scaner_Id";
            this.clTr_Scaner_Id.Width = 86;
            // 
            // clT_Fact
            // 
            this.clT_Fact.DataPropertyName = "T_Fact";
            dataGridViewCellStyle1.Format = "N1";
            dataGridViewCellStyle1.NullValue = null;
            this.clT_Fact.DefaultCellStyle = dataGridViewCellStyle1;
            this.clT_Fact.HeaderText = "t прием., °C";
            this.clT_Fact.Name = "clT_Fact";
            this.clT_Fact.Width = 90;
            // 
            // clT_Min
            // 
            this.clT_Min.DataPropertyName = "T_Min";
            dataGridViewCellStyle2.Format = "N1";
            dataGridViewCellStyle2.NullValue = null;
            this.clT_Min.DefaultCellStyle = dataGridViewCellStyle2;
            this.clT_Min.HeaderText = "t транс.min, °C";
            this.clT_Min.Name = "clT_Min";
            this.clT_Min.Width = 103;
            // 
            // clT_Max
            // 
            this.clT_Max.DataPropertyName = "T_Max";
            dataGridViewCellStyle3.Format = "N1";
            dataGridViewCellStyle3.NullValue = null;
            this.clT_Max.DefaultCellStyle = dataGridViewCellStyle3;
            this.clT_Max.HeaderText = "t транс. max, °C";
            this.clT_Max.Name = "clT_Max";
            this.clT_Max.Width = 109;
            // 
            // Comment
            // 
            this.Comment.DataPropertyName = "Comment";
            this.Comment.HeaderText = "Комментарий (не исп.)";
            this.Comment.Name = "Comment";
            this.Comment.ReadOnly = true;
            this.Comment.Visible = false;
            this.Comment.Width = 147;
            // 
            // Note
            // 
            this.Note.DataPropertyName = "Note";
            this.Note.HeaderText = "Комментарий";
            this.Note.Name = "Note";
            this.Note.ReadOnly = true;
            this.Note.Width = 102;
            // 
            // InputControlDeliveryWorksheetTermoDetailsEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 425);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Name = "InputControlDeliveryWorksheetTermoDetailsEditForm";
            this.Text = "Температура с датчиков";
            this.Load += new System.EventHandler(this.EditInputControlDeliveryWorksheetTermoDetailsForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditInputControlDeliveryWorksheetTermoDetailsForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.pnlButtons.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aPEquipmentTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aPVersionTermoDetailBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.CheckBox cbSensorsAreAbsent;
        private System.Windows.Forms.BindingSource aPVersionTermoDetailBindingSource;
        private Data.Quality quality;
        private Data.QualityTableAdapters.AP_Version_Termo_DetailTableAdapter aP_Version_Termo_DetailTableAdapter;
        private System.Windows.Forms.BindingSource aPEquipmentTypesBindingSource;
        private WMSOffice.Data.QualityTableAdapters.AP_Equipment_TypesTableAdapter aP_Equipment_TypesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTermo_mode;
        private WMSOffice.Controls.Custom.DataGridViewDatePickerColumn clDate;
        private System.Windows.Forms.DataGridViewComboBoxColumn clEquipmentType;
        private System.Windows.Forms.DataGridViewTextBoxColumn EquipmentNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTr_Scaner_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn clT_Fact;
        private System.Windows.Forms.DataGridViewTextBoxColumn clT_Min;
        private System.Windows.Forms.DataGridViewTextBoxColumn clT_Max;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
        private System.Windows.Forms.DataGridViewTextBoxColumn Note;
    }
}