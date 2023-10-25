namespace WMSOffice.Dialogs.Quality
{
    partial class ProvisorsEditForm
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
            this.dgvProvisors = new System.Windows.Forms.DataGridView();
            this.bsGetProvisors = new System.Windows.Forms.BindingSource(this.components);
            this.quality = new WMSOffice.Data.Quality();
            this.taGetProvisors = new WMSOffice.Data.QualityTableAdapters.QK_Get_ProvisorsTableAdapter();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clProvisorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clProvisorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDateFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDateTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProvisors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsGetProvisors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(461, 283);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // dgvProvisors
            // 
            this.dgvProvisors.AllowUserToAddRows = false;
            this.dgvProvisors.AllowUserToDeleteRows = false;
            this.dgvProvisors.AllowUserToResizeRows = false;
            this.dgvProvisors.AutoGenerateColumns = false;
            this.dgvProvisors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProvisors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clProvisorID,
            this.clProvisorName,
            this.clDepartment,
            this.clDateFrom,
            this.clDateTo});
            this.dgvProvisors.DataSource = this.bsGetProvisors;
            this.dgvProvisors.Location = new System.Drawing.Point(12, 12);
            this.dgvProvisors.Name = "dgvProvisors";
            this.dgvProvisors.ReadOnly = true;
            this.dgvProvisors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProvisors.Size = new System.Drawing.Size(524, 265);
            this.dgvProvisors.TabIndex = 1;
            // 
            // bsGetProvisors
            // 
            this.bsGetProvisors.DataMember = "QK_Get_Provisors";
            this.bsGetProvisors.DataSource = this.quality;
            // 
            // quality
            // 
            this.quality.DataSetName = "Quality";
            this.quality.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // taGetProvisors
            // 
            this.taGetProvisors.ClearBeforeFill = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "provisor_id";
            this.dataGridViewTextBoxColumn1.HeaderText = "provisor_id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "provisor_name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Провизор";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 82;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "department";
            this.dataGridViewTextBoxColumn3.HeaderText = "Отдел";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 63;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "date_from";
            this.dataGridViewTextBoxColumn4.HeaderText = "Дата с";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 67;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "date_to";
            this.dataGridViewTextBoxColumn5.HeaderText = "Дата по";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 73;
            // 
            // clProvisorID
            // 
            this.clProvisorID.DataPropertyName = "provisor_id";
            this.clProvisorID.HeaderText = "provisor_id";
            this.clProvisorID.Name = "clProvisorID";
            this.clProvisorID.ReadOnly = true;
            this.clProvisorID.Visible = false;
            // 
            // clProvisorName
            // 
            this.clProvisorName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clProvisorName.DataPropertyName = "provisor_name";
            this.clProvisorName.HeaderText = "Провизор";
            this.clProvisorName.Name = "clProvisorName";
            this.clProvisorName.ReadOnly = true;
            this.clProvisorName.Width = 82;
            // 
            // clDepartment
            // 
            this.clDepartment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clDepartment.DataPropertyName = "department";
            this.clDepartment.HeaderText = "Отдел";
            this.clDepartment.Name = "clDepartment";
            this.clDepartment.ReadOnly = true;
            this.clDepartment.Width = 63;
            // 
            // clDateFrom
            // 
            this.clDateFrom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clDateFrom.DataPropertyName = "date_from";
            this.clDateFrom.HeaderText = "Дата с";
            this.clDateFrom.Name = "clDateFrom";
            this.clDateFrom.ReadOnly = true;
            this.clDateFrom.Width = 67;
            // 
            // clDateTo
            // 
            this.clDateTo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clDateTo.DataPropertyName = "date_to";
            this.clDateTo.HeaderText = "Дата по";
            this.clDateTo.Name = "clDateTo";
            this.clDateTo.ReadOnly = true;
            this.clDateTo.Width = 73;
            // 
            // ProvisorsEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 318);
            this.Controls.Add(this.dgvProvisors);
            this.Controls.Add(this.btnClose);
            this.Name = "ProvisorsEditForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Провизоры";
            this.Load += new System.EventHandler(this.ProvisorsEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProvisors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsGetProvisors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvProvisors;
        private System.Windows.Forms.BindingSource bsGetProvisors;
        private WMSOffice.Data.Quality quality;
        private WMSOffice.Data.QualityTableAdapters.QK_Get_ProvisorsTableAdapter taGetProvisors;
        private System.Windows.Forms.DataGridViewTextBoxColumn clProvisorID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clProvisorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDateFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDateTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    }
}