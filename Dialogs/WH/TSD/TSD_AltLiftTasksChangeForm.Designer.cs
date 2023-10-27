namespace WMSOffice.Dialogs.WH.TSD
{
    partial class TSD_AltLiftTasksChangeForm
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
            this.dgvLifts = new System.Windows.Forms.DataGridView();
            this.liftNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activeflagDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.liftsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tSD = new WMSOffice.Data.TSD();
            this.liftsTableAdapter = new WMSOffice.Data.TSDTableAdapters.LiftsTableAdapter();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLifts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.liftsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tSD)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(379, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(469, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 238);
            this.pnlButtons.Size = new System.Drawing.Size(404, 43);
            // 
            // dgvLifts
            // 
            this.dgvLifts.AllowUserToAddRows = false;
            this.dgvLifts.AllowUserToDeleteRows = false;
            this.dgvLifts.AllowUserToResizeColumns = false;
            this.dgvLifts.AllowUserToResizeRows = false;
            this.dgvLifts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLifts.AutoGenerateColumns = false;
            this.dgvLifts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLifts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.liftNameDataGridViewTextBoxColumn,
            this.activeflagDataGridViewCheckBoxColumn});
            this.dgvLifts.DataSource = this.liftsBindingSource;
            this.dgvLifts.Location = new System.Drawing.Point(0, 0);
            this.dgvLifts.MultiSelect = false;
            this.dgvLifts.Name = "dgvLifts";
            this.dgvLifts.RowHeadersVisible = false;
            this.dgvLifts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLifts.Size = new System.Drawing.Size(404, 232);
            this.dgvLifts.TabIndex = 101;
            this.dgvLifts.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLifts_CellValueChanged);
            this.dgvLifts.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvLifts_CellFormatting);
            this.dgvLifts.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvLifts_CurrentCellDirtyStateChanged);
            // 
            // liftNameDataGridViewTextBoxColumn
            // 
            this.liftNameDataGridViewTextBoxColumn.DataPropertyName = "Lift_Name";
            this.liftNameDataGridViewTextBoxColumn.HeaderText = "Лифт";
            this.liftNameDataGridViewTextBoxColumn.Name = "liftNameDataGridViewTextBoxColumn";
            this.liftNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.liftNameDataGridViewTextBoxColumn.Width = 300;
            // 
            // activeflagDataGridViewCheckBoxColumn
            // 
            this.activeflagDataGridViewCheckBoxColumn.DataPropertyName = "active_flag";
            this.activeflagDataGridViewCheckBoxColumn.HeaderText = "Вкл./Выкл.";
            this.activeflagDataGridViewCheckBoxColumn.Name = "activeflagDataGridViewCheckBoxColumn";
            this.activeflagDataGridViewCheckBoxColumn.Width = 70;
            // 
            // liftsBindingSource
            // 
            this.liftsBindingSource.DataMember = "Lifts";
            this.liftsBindingSource.DataSource = this.tSD;
            // 
            // tSD
            // 
            this.tSD.DataSetName = "TSD";
            this.tSD.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // liftsTableAdapter
            // 
            this.liftsTableAdapter.ClearBeforeFill = true;
            // 
            // TSD_AltLiftTasksChangeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 281);
            this.Controls.Add(this.dgvLifts);
            this.Name = "TSD_AltLiftTasksChangeForm";
            this.Text = "Управление лифтами в альтернативных лифтовых заданиях";
            this.Load += new System.EventHandler(this.TSD_AltLiftTasksChangeForm_Load);
            this.Controls.SetChildIndex(this.dgvLifts, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLifts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.liftsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tSD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLifts;
        private System.Windows.Forms.BindingSource liftsBindingSource;
        private WMSOffice.Data.TSD tSD;
        private WMSOffice.Data.TSDTableAdapters.LiftsTableAdapter liftsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn liftNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn activeflagDataGridViewCheckBoxColumn;
    }
}