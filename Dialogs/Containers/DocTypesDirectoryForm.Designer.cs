namespace WMSOffice.Dialogs.Containers
{
    partial class DocTypesDirectoryForm
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
            this.dgvDocTypes = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsPrDocTypes = new System.Windows.Forms.BindingSource(this.components);
            this.containers = new WMSOffice.Data.Containers();
            this.btnClose = new System.Windows.Forms.Button();
            this.taPrDocTypes = new WMSOffice.Data.ContainersTableAdapters.PrDocTypesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPrDocTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.containers)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDocTypes
            // 
            this.dgvDocTypes.AllowUserToResizeRows = false;
            this.dgvDocTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDocTypes.AutoGenerateColumns = false;
            this.dgvDocTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocTypes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.desc});
            this.dgvDocTypes.DataSource = this.bsPrDocTypes;
            this.dgvDocTypes.Location = new System.Drawing.Point(12, 12);
            this.dgvDocTypes.MultiSelect = false;
            this.dgvDocTypes.Name = "dgvDocTypes";
            this.dgvDocTypes.Size = new System.Drawing.Size(807, 283);
            this.dgvDocTypes.TabIndex = 0;
            this.dgvDocTypes.VirtualMode = true;
            this.dgvDocTypes.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvDocTypes_UserDeletingRow);
            this.dgvDocTypes.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocTypes_RowEnter);
            this.dgvDocTypes.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvDocTypes_RowValidating);
            // 
            // id
            // 
            this.id.DataPropertyName = "doc_type_id";
            this.id.HeaderText = "doc_type_id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "Название";
            this.name.Name = "name";
            this.name.Width = 200;
            // 
            // desc
            // 
            this.desc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.desc.DataPropertyName = "description";
            this.desc.HeaderText = "Описание";
            this.desc.MinimumWidth = 100;
            this.desc.Name = "desc";
            // 
            // bsPrDocTypes
            // 
            this.bsPrDocTypes.DataMember = "PrDocTypes";
            this.bsPrDocTypes.DataSource = this.containers;
            // 
            // containers
            // 
            this.containers.DataSetName = "Containers";
            this.containers.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(744, 301);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // taPrDocTypes
            // 
            this.taPrDocTypes.ClearBeforeFill = true;
            // 
            // DocTypesDirectoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(831, 336);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvDocTypes);
            this.Name = "DocTypesDirectoryForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Справочник типов документов";
            this.Load += new System.EventHandler(this.DocTypesDirectoryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPrDocTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.containers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDocTypes;
        private System.Windows.Forms.Button btnClose;
        private WMSOffice.Data.Containers containers;
        private System.Windows.Forms.BindingSource bsPrDocTypes;
        private WMSOffice.Data.ContainersTableAdapters.PrDocTypesTableAdapter taPrDocTypes;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn desc;
    }
}