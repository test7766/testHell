namespace WMSOffice.Dialogs.ColdChain
{
    partial class SelectBranchForm
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
            this.lbBranches = new System.Windows.Forms.ListBox();
            this.branchesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.coldChain = new WMSOffice.Data.ColdChain();
            this.branchesTableAdapter = new WMSOffice.Data.ColdChainTableAdapters.BranchesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.branchesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coldChain)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lbBranches
            // 
            this.lbBranches.DataSource = this.branchesBindingSource;
            this.lbBranches.DisplayMember = "Branch_Name";
            this.lbBranches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbBranches.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbBranches.FormattingEnabled = true;
            this.lbBranches.ItemHeight = 16;
            this.lbBranches.Location = new System.Drawing.Point(0, 0);
            this.lbBranches.Name = "lbBranches";
            this.lbBranches.Size = new System.Drawing.Size(358, 244);
            this.lbBranches.TabIndex = 101;
            this.lbBranches.ValueMember = "Warehouse_ID";
            this.lbBranches.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbBranches_KeyDown);
            // 
            // branchesBindingSource
            // 
            this.branchesBindingSource.DataMember = "Branches";
            this.branchesBindingSource.DataSource = this.coldChain;
            // 
            // coldChain
            // 
            this.coldChain.DataSetName = "ColdChain";
            this.coldChain.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // branchesTableAdapter
            // 
            this.branchesTableAdapter.ClearBeforeFill = true;
            // 
            // SelectBranchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 291);
            this.Controls.Add(this.lbBranches);
            this.Name = "SelectBranchForm";
            this.Text = "Выберите филиал:";
            this.Load += new System.EventHandler(this.SelectBranchForm_Load);
            this.Controls.SetChildIndex(this.lbBranches, 0);
            ((System.ComponentModel.ISupportInitialize)(this.branchesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coldChain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbBranches;
        private WMSOffice.Data.ColdChain coldChain;
        private System.Windows.Forms.BindingSource branchesBindingSource;
        private WMSOffice.Data.ColdChainTableAdapters.BranchesTableAdapter branchesTableAdapter;
    }
}