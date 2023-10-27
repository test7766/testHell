namespace WMSOffice.Dialogs.D3
{
    partial class RoutePlanEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoutePlanEditForm));
            this.tbName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lbRoutes = new System.Windows.Forms.ListBox();
            this.lbSelRoutes = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.routesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.d3 = new WMSOffice.Data.D3();
            this.routesSequenceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.routesTableAdapter = new WMSOffice.Data.D3TableAdapters.RoutesTableAdapter();
            this.routesSequenceTableAdapter = new WMSOffice.Data.D3TableAdapters.RoutesSequenceTableAdapter();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.routesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.routesSequenceBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(78, 12);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(288, 20);
            this.tbName.TabIndex = 101;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 15);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(60, 13);
            this.lblName.TabIndex = 102;
            this.lblName.Text = "Название:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitContainer1.Location = new System.Drawing.Point(0, 67);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lbRoutes);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lbSelRoutes);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(378, 174);
            this.splitContainer1.SplitterDistance = 173;
            this.splitContainer1.TabIndex = 103;
            // 
            // lbRoutes
            // 
            this.lbRoutes.DisplayMember = "Name";
            this.lbRoutes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbRoutes.FormattingEnabled = true;
            this.lbRoutes.Location = new System.Drawing.Point(0, 0);
            this.lbRoutes.Name = "lbRoutes";
            this.lbRoutes.Size = new System.Drawing.Size(173, 173);
            this.lbRoutes.TabIndex = 0;
            this.lbRoutes.ValueMember = "ID";
            this.lbRoutes.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbRoutes_MouseDoubleClick);
            this.lbRoutes.SelectedIndexChanged += new System.EventHandler(this.lbRoutes_SelectedIndexChanged);
            // 
            // lbSelRoutes
            // 
            this.lbSelRoutes.DisplayMember = "Name";
            this.lbSelRoutes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSelRoutes.FormattingEnabled = true;
            this.lbSelRoutes.Location = new System.Drawing.Point(24, 0);
            this.lbSelRoutes.Name = "lbSelRoutes";
            this.lbSelRoutes.Size = new System.Drawing.Size(177, 173);
            this.lbSelRoutes.TabIndex = 1;
            this.lbSelRoutes.ValueMember = "ID";
            this.lbSelRoutes.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbSelRoutes_MouseDoubleClick);
            this.lbSelRoutes.SelectedIndexChanged += new System.EventHandler(this.lbSelRoutes_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDown);
            this.panel1.Controls.Add(this.btnUp);
            this.panel1.Controls.Add(this.btnDel);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(24, 174);
            this.panel1.TabIndex = 0;
            // 
            // btnDown
            // 
            this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
            this.btnDown.Location = new System.Drawing.Point(0, 130);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(23, 32);
            this.btnDown.TabIndex = 3;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
            this.btnUp.Location = new System.Drawing.Point(0, 92);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(23, 32);
            this.btnUp.TabIndex = 2;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDel
            // 
            this.btnDel.Image = global::WMSOffice.Properties.Resources.close;
            this.btnDel.Location = new System.Drawing.Point(0, 42);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(23, 23);
            this.btnDel.TabIndex = 1;
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::WMSOffice.Properties.Resources.add;
            this.btnAdd.Location = new System.Drawing.Point(0, 13);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(23, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 104;
            this.label1.Text = "Тип:";
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "R - размещение",
            "P - пополнение",
            "S - сборка"});
            this.cbType.Location = new System.Drawing.Point(78, 38);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(288, 21);
            this.cbType.TabIndex = 105;
            // 
            // routesBindingSource
            // 
            this.routesBindingSource.DataMember = "Routes";
            this.routesBindingSource.DataSource = this.d3;
            // 
            // d3
            // 
            this.d3.DataSetName = "D3";
            this.d3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // routesSequenceBindingSource
            // 
            this.routesSequenceBindingSource.DataMember = "RoutesSequence";
            this.routesSequenceBindingSource.DataSource = this.d3;
            // 
            // routesTableAdapter
            // 
            this.routesTableAdapter.ClearBeforeFill = true;
            // 
            // routesSequenceTableAdapter
            // 
            this.routesSequenceTableAdapter.ClearBeforeFill = true;
            // 
            // RoutePlanEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 284);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.tbName);
            this.Name = "RoutePlanEditForm";
            this.Text = "Редактирование Карты маршрутов";
            this.Load += new System.EventHandler(this.RoutePlanEditForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RoutePlanEditForm_FormClosing);
            this.Controls.SetChildIndex(this.tbName, 0);
            this.Controls.SetChildIndex(this.lblName, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cbType, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.routesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.routesSequenceBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox lbRoutes;
        private System.Windows.Forms.ListBox lbSelRoutes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.BindingSource routesBindingSource;
        private WMSOffice.Data.D3 d3;
        private WMSOffice.Data.D3TableAdapters.RoutesTableAdapter routesTableAdapter;
        private System.Windows.Forms.BindingSource routesSequenceBindingSource;
        private WMSOffice.Data.D3TableAdapters.RoutesSequenceTableAdapter routesSequenceTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbType;
    }
}