namespace WMSOffice.Dialogs.D3
{
    partial class PlaceTypeEditForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lbCells = new System.Windows.Forms.ListBox();
            this.cellsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.d3 = new WMSOffice.Data.D3();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.btnAddCell = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteCell = new System.Windows.Forms.ToolStripButton();
            this.pnlSelect = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbPlaceType = new System.Windows.Forms.ComboBox();
            this.placeTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.btnAddPlaceType = new System.Windows.Forms.ToolStripButton();
            this.btnDeletePlaceType = new System.Windows.Forms.ToolStripButton();
            this.preview = new WMSOffice.Controls.D3.View();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.editPlaceTypeProperties = new WMSOffice.Controls.D3.EditPropertiesControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.editCellProperties = new WMSOffice.Controls.D3.EditPropertiesControl();
            this.placeTypesTableAdapter = new WMSOffice.Data.D3TableAdapters.PlaceTypesTableAdapter();
            this.cellsTableAdapter = new WMSOffice.Data.D3TableAdapters.CellsTableAdapter();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cellsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d3)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.pnlSelect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.placeTypesBindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(594, 544);
            this.splitContainer1.SplitterDistance = 257;
            this.splitContainer1.TabIndex = 101;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lbCells);
            this.splitContainer2.Panel1.Controls.Add(this.toolStrip2);
            this.splitContainer2.Panel1.Controls.Add(this.pnlSelect);
            this.splitContainer2.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.preview);
            this.splitContainer2.Size = new System.Drawing.Size(594, 257);
            this.splitContainer2.SplitterDistance = 370;
            this.splitContainer2.TabIndex = 0;
            // 
            // lbCells
            // 
            this.lbCells.DataSource = this.cellsBindingSource;
            this.lbCells.DisplayMember = "Cell_ID";
            this.lbCells.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCells.FormattingEnabled = true;
            this.lbCells.Location = new System.Drawing.Point(0, 82);
            this.lbCells.Name = "lbCells";
            this.lbCells.Size = new System.Drawing.Size(370, 173);
            this.lbCells.TabIndex = 4;
            this.lbCells.ValueMember = "Cell_ID";
            this.lbCells.SelectedIndexChanged += new System.EventHandler(this.lbCells_SelectedIndexChanged);
            // 
            // cellsBindingSource
            // 
            this.cellsBindingSource.DataMember = "Cells";
            this.cellsBindingSource.DataSource = this.d3;
            // 
            // d3
            // 
            this.d3.DataSetName = "D3";
            this.d3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.btnAddCell,
            this.btnDeleteCell});
            this.toolStrip2.Location = new System.Drawing.Point(0, 57);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(370, 25);
            this.toolStrip2.TabIndex = 3;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(49, 22);
            this.toolStripLabel2.Text = "Ячейка:";
            // 
            // btnAddCell
            // 
            this.btnAddCell.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddCell.Image = global::WMSOffice.Properties.Resources.add;
            this.btnAddCell.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddCell.Name = "btnAddCell";
            this.btnAddCell.Size = new System.Drawing.Size(23, 22);
            this.btnAddCell.Text = "Добавить ячейку";
            this.btnAddCell.Click += new System.EventHandler(this.btnAddCell_Click);
            // 
            // btnDeleteCell
            // 
            this.btnDeleteCell.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDeleteCell.Image = global::WMSOffice.Properties.Resources.close;
            this.btnDeleteCell.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteCell.Name = "btnDeleteCell";
            this.btnDeleteCell.Size = new System.Drawing.Size(23, 22);
            this.btnDeleteCell.Text = "Удаление ячейки";
            this.btnDeleteCell.Click += new System.EventHandler(this.btnDeleteCell_Click);
            // 
            // pnlSelect
            // 
            this.pnlSelect.Controls.Add(this.label1);
            this.pnlSelect.Controls.Add(this.cbPlaceType);
            this.pnlSelect.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSelect.Location = new System.Drawing.Point(0, 25);
            this.pnlSelect.Name = "pnlSelect";
            this.pnlSelect.Size = new System.Drawing.Size(370, 32);
            this.pnlSelect.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Тип:";
            // 
            // cbPlaceType
            // 
            this.cbPlaceType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPlaceType.DataSource = this.placeTypesBindingSource;
            this.cbPlaceType.DisplayMember = "Place_Type_ID";
            this.cbPlaceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPlaceType.FormattingEnabled = true;
            this.cbPlaceType.Location = new System.Drawing.Point(47, 6);
            this.cbPlaceType.Name = "cbPlaceType";
            this.cbPlaceType.Size = new System.Drawing.Size(320, 21);
            this.cbPlaceType.TabIndex = 0;
            this.cbPlaceType.ValueMember = "Place_Type_ID";
            this.cbPlaceType.SelectedIndexChanged += new System.EventHandler(this.cbPlaceType_SelectedIndexChanged);
            // 
            // placeTypesBindingSource
            // 
            this.placeTypesBindingSource.DataMember = "PlaceTypes";
            this.placeTypesBindingSource.DataSource = this.d3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.btnAddPlaceType,
            this.btnDeletePlaceType});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(370, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(120, 22);
            this.toolStripLabel1.Text = "Тип места хранения:";
            // 
            // btnAddPlaceType
            // 
            this.btnAddPlaceType.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddPlaceType.Image = global::WMSOffice.Properties.Resources.add;
            this.btnAddPlaceType.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddPlaceType.Name = "btnAddPlaceType";
            this.btnAddPlaceType.Size = new System.Drawing.Size(23, 22);
            this.btnAddPlaceType.Text = "Добавить тип места хранения";
            this.btnAddPlaceType.Click += new System.EventHandler(this.btnAddPlaceType_Click);
            // 
            // btnDeletePlaceType
            // 
            this.btnDeletePlaceType.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDeletePlaceType.Image = global::WMSOffice.Properties.Resources.close;
            this.btnDeletePlaceType.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeletePlaceType.Name = "btnDeletePlaceType";
            this.btnDeletePlaceType.Size = new System.Drawing.Size(23, 22);
            this.btnDeletePlaceType.Text = "Удалить тип места хранения";
            this.btnDeletePlaceType.Click += new System.EventHandler(this.btnDeletePlaceType_Click);
            // 
            // preview
            // 
            this.preview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.preview.Location = new System.Drawing.Point(0, 0);
            this.preview.MaxBitmapSize = 16777;
            this.preview.Name = "preview";
            this.preview.ShowToolStrip = false;
            this.preview.Size = new System.Drawing.Size(220, 257);
            this.preview.Source = null;
            this.preview.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer3.Size = new System.Drawing.Size(594, 283);
            this.splitContainer3.SplitterDistance = 297;
            this.splitContainer3.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.editPlaceTypeProperties);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 283);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Свойства типа места хранения:";
            // 
            // editPlaceTypeProperties
            // 
            this.editPlaceTypeProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editPlaceTypeProperties.Location = new System.Drawing.Point(3, 16);
            this.editPlaceTypeProperties.Name = "editPlaceTypeProperties";
            this.editPlaceTypeProperties.Size = new System.Drawing.Size(291, 264);
            this.editPlaceTypeProperties.TabIndex = 3;
            this.editPlaceTypeProperties.ToolbarVisible = false;
            this.editPlaceTypeProperties.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.editPlaceTypeProperties_PropertyValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.editCellProperties);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(293, 283);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Свойства ячейки:";
            // 
            // editCellProperties
            // 
            this.editCellProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editCellProperties.Location = new System.Drawing.Point(3, 16);
            this.editCellProperties.Name = "editCellProperties";
            this.editCellProperties.Size = new System.Drawing.Size(287, 264);
            this.editCellProperties.TabIndex = 4;
            this.editCellProperties.ToolbarVisible = false;
            this.editCellProperties.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.editCellProperties_PropertyValueChanged);
            // 
            // placeTypesTableAdapter
            // 
            this.placeTypesTableAdapter.ClearBeforeFill = true;
            // 
            // cellsTableAdapter
            // 
            this.cellsTableAdapter.ClearBeforeFill = true;
            // 
            // PlaceTypeEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 587);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "PlaceTypeEditForm";
            this.Text = "Типы мест хранения";
            this.Load += new System.EventHandler(this.PlaceTypeEditForm_Load);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cellsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d3)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.pnlSelect.ResumeLayout(false);
            this.pnlSelect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.placeTypesBindingSource)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel pnlSelect;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPlaceType;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAddPlaceType;
        private System.Windows.Forms.ToolStripButton btnDeletePlaceType;
        private WMSOffice.Controls.D3.View preview;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private WMSOffice.Data.D3 d3;
        private System.Windows.Forms.BindingSource placeTypesBindingSource;
        private WMSOffice.Data.D3TableAdapters.PlaceTypesTableAdapter placeTypesTableAdapter;
        private System.Windows.Forms.BindingSource cellsBindingSource;
        private WMSOffice.Data.D3TableAdapters.CellsTableAdapter cellsTableAdapter;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton btnAddCell;
        private System.Windows.Forms.ToolStripButton btnDeleteCell;
        private System.Windows.Forms.ListBox lbCells;
        private System.Windows.Forms.GroupBox groupBox1;
        private WMSOffice.Controls.D3.EditPropertiesControl editPlaceTypeProperties;
        private System.Windows.Forms.GroupBox groupBox2;
        private WMSOffice.Controls.D3.EditPropertiesControl editCellProperties;
    }
}