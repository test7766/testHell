namespace WMSOffice.Dialogs.Containers
{
    partial class NewOutputForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbDepartments = new System.Windows.Forms.ComboBox();
            this.departmentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.containers = new WMSOffice.Data.Containers();
            this.departmentsTableAdapter = new WMSOffice.Data.ContainersTableAdapters.DepartmentsTableAdapter();
            this.filialsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.filialsTableAdapter = new WMSOffice.Data.ContainersTableAdapters.FilialsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.containers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filialsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(148, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 26);
            this.label1.TabIndex = 105;
            this.label1.Text = "Выберите отдел, \r\nв который будет передаваться тара:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WMSOffice.Properties.Resources.paper_box;
            this.pictureBox1.Location = new System.Drawing.Point(15, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(127, 95);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 104;
            this.pictureBox1.TabStop = false;
            // 
            // cbDepartments
            // 
            this.cbDepartments.DataSource = this.filialsBindingSource;
            this.cbDepartments.DisplayMember = "Warehouse";
            this.cbDepartments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDepartments.FormattingEnabled = true;
            this.cbDepartments.Location = new System.Drawing.Point(148, 68);
            this.cbDepartments.Name = "cbDepartments";
            this.cbDepartments.Size = new System.Drawing.Size(190, 21);
            this.cbDepartments.TabIndex = 106;
            this.cbDepartments.ValueMember = "Warehouse_ID";
            // 
            // departmentsBindingSource
            // 
            this.departmentsBindingSource.DataMember = "Departments";
            this.departmentsBindingSource.DataSource = this.containers;
            // 
            // containers
            // 
            this.containers.DataSetName = "Containers";
            this.containers.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // departmentsTableAdapter
            // 
            this.departmentsTableAdapter.ClearBeforeFill = true;
            // 
            // filialsBindingSource
            // 
            this.filialsBindingSource.DataMember = "Filials";
            this.filialsBindingSource.DataSource = this.containers;
            // 
            // filialsTableAdapter
            // 
            this.filialsTableAdapter.ClearBeforeFill = true;
            // 
            // NewOutputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 162);
            this.Controls.Add(this.cbDepartments);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "NewOutputForm";
            this.Text = "Новая выдача оборотной тары";
            this.Load += new System.EventHandler(this.NewOutputForm_Load);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cbDepartments, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.containers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filialsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbDepartments;
        private WMSOffice.Data.Containers containers;
        private System.Windows.Forms.BindingSource departmentsBindingSource;
        private WMSOffice.Data.ContainersTableAdapters.DepartmentsTableAdapter departmentsTableAdapter;
        private System.Windows.Forms.BindingSource filialsBindingSource;
        private WMSOffice.Data.ContainersTableAdapters.FilialsTableAdapter filialsTableAdapter;
    }
}