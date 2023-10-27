namespace WMSOffice.Dialogs.D3
{
    partial class RackPlacesForm
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
            this.tbName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbDirection = new System.Windows.Forms.ComboBox();
            this.gbPlaces = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnEditPlaceType = new System.Windows.Forms.Button();
            this.btnDeletePlace = new System.Windows.Forms.Button();
            this.btnAddPlace = new System.Windows.Forms.Button();
            this.lbTypes = new System.Windows.Forms.ListBox();
            this.placeTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.d3 = new WMSOffice.Data.D3();
            this.lbPlaces = new System.Windows.Forms.ListBox();
            this.placesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.placeTypesTableAdapter = new WMSOffice.Data.D3TableAdapters.PlaceTypesTableAdapter();
            this.placesTableAdapter = new WMSOffice.Data.D3TableAdapters.PlacesTableAdapter();
            this.preview = new WMSOffice.Controls.D3.View();
            this.nudSectionSize = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.gbPlaces.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.placeTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.placesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSectionSize)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 101;
            this.label1.Text = "Стеллаж:";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(96, 12);
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(121, 20);
            this.tbName.TabIndex = 102;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 103;
            this.label2.Text = "Направление:";
            // 
            // cbDirection
            // 
            this.cbDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDirection.FormattingEnabled = true;
            this.cbDirection.Items.AddRange(new object[] {
            "Слева направо --->",
            "Справа налево <---"});
            this.cbDirection.Location = new System.Drawing.Point(96, 38);
            this.cbDirection.Name = "cbDirection";
            this.cbDirection.Size = new System.Drawing.Size(121, 21);
            this.cbDirection.TabIndex = 104;
            this.cbDirection.SelectedIndexChanged += new System.EventHandler(this.cbDirection_SelectedIndexChanged);
            // 
            // gbPlaces
            // 
            this.gbPlaces.Controls.Add(this.splitContainer1);
            this.gbPlaces.Location = new System.Drawing.Point(12, 199);
            this.gbPlaces.Name = "gbPlaces";
            this.gbPlaces.Size = new System.Drawing.Size(394, 168);
            this.gbPlaces.TabIndex = 106;
            this.gbPlaces.TabStop = false;
            this.gbPlaces.Text = "Места хранения:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 16);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnEditPlaceType);
            this.splitContainer1.Panel1.Controls.Add(this.btnDeletePlace);
            this.splitContainer1.Panel1.Controls.Add(this.btnAddPlace);
            this.splitContainer1.Panel1.Controls.Add(this.lbTypes);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lbPlaces);
            this.splitContainer1.Size = new System.Drawing.Size(388, 149);
            this.splitContainer1.SplitterDistance = 192;
            this.splitContainer1.TabIndex = 106;
            // 
            // btnEditPlaceType
            // 
            this.btnEditPlaceType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditPlaceType.Location = new System.Drawing.Point(166, 95);
            this.btnEditPlaceType.Name = "btnEditPlaceType";
            this.btnEditPlaceType.Size = new System.Drawing.Size(23, 23);
            this.btnEditPlaceType.TabIndex = 3;
            this.btnEditPlaceType.Text = "..";
            this.btnEditPlaceType.UseVisualStyleBackColor = true;
            this.btnEditPlaceType.Click += new System.EventHandler(this.btnEditPlaceType_Click);
            // 
            // btnDeletePlace
            // 
            this.btnDeletePlace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeletePlace.Image = global::WMSOffice.Properties.Resources.close;
            this.btnDeletePlace.Location = new System.Drawing.Point(166, 66);
            this.btnDeletePlace.Name = "btnDeletePlace";
            this.btnDeletePlace.Size = new System.Drawing.Size(23, 23);
            this.btnDeletePlace.TabIndex = 2;
            this.btnDeletePlace.UseVisualStyleBackColor = true;
            this.btnDeletePlace.Click += new System.EventHandler(this.btnDeletePlace_Click);
            // 
            // btnAddPlace
            // 
            this.btnAddPlace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddPlace.Image = global::WMSOffice.Properties.Resources.add;
            this.btnAddPlace.Location = new System.Drawing.Point(166, 37);
            this.btnAddPlace.Name = "btnAddPlace";
            this.btnAddPlace.Size = new System.Drawing.Size(23, 23);
            this.btnAddPlace.TabIndex = 1;
            this.btnAddPlace.UseVisualStyleBackColor = true;
            this.btnAddPlace.Click += new System.EventHandler(this.btnAddPlace_Click);
            // 
            // lbTypes
            // 
            this.lbTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTypes.DataSource = this.placeTypesBindingSource;
            this.lbTypes.DisplayMember = "Place_Type_ID";
            this.lbTypes.FormattingEnabled = true;
            this.lbTypes.Location = new System.Drawing.Point(0, 0);
            this.lbTypes.Name = "lbTypes";
            this.lbTypes.Size = new System.Drawing.Size(160, 147);
            this.lbTypes.TabIndex = 0;
            this.lbTypes.ValueMember = "Place_Type_ID";
            // 
            // placeTypesBindingSource
            // 
            this.placeTypesBindingSource.DataMember = "PlaceTypes";
            this.placeTypesBindingSource.DataSource = this.d3;
            // 
            // d3
            // 
            this.d3.DataSetName = "D3";
            this.d3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lbPlaces
            // 
            this.lbPlaces.DataSource = this.placesBindingSource;
            this.lbPlaces.DisplayMember = "Place_Name";
            this.lbPlaces.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPlaces.FormattingEnabled = true;
            this.lbPlaces.Location = new System.Drawing.Point(0, 0);
            this.lbPlaces.Name = "lbPlaces";
            this.lbPlaces.Size = new System.Drawing.Size(192, 147);
            this.lbPlaces.TabIndex = 0;
            this.lbPlaces.ValueMember = "Place_ID";
            // 
            // placesBindingSource
            // 
            this.placesBindingSource.DataMember = "Places";
            this.placesBindingSource.DataSource = this.d3;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(394, 43);
            this.label3.TabIndex = 107;
            this.label3.Text = "Выберите тип места хранения и нажмите \"+\", чтобы добавить место хранения в стелла" +
                "ж. Чтобы удалить место хранения, выберите его в правом списке и нажмите \"Х\".";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(331, 374);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 108;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // placeTypesTableAdapter
            // 
            this.placeTypesTableAdapter.ClearBeforeFill = true;
            // 
            // placesTableAdapter
            // 
            this.placesTableAdapter.ClearBeforeFill = true;
            // 
            // preview
            // 
            this.preview.Location = new System.Drawing.Point(12, 65);
            this.preview.MaxBitmapSize = 16777;
            this.preview.Name = "preview";
            this.preview.ShowToolStrip = false;
            this.preview.Size = new System.Drawing.Size(394, 84);
            this.preview.Source = null;
            this.preview.TabIndex = 109;
            // 
            // nudSectionSize
            // 
            this.nudSectionSize.Location = new System.Drawing.Point(360, 39);
            this.nudSectionSize.Name = "nudSectionSize";
            this.nudSectionSize.Size = new System.Drawing.Size(46, 20);
            this.nudSectionSize.TabIndex = 110;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(223, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 13);
            this.label4.TabIndex = 111;
            this.label4.Text = "Авто-создание секторов:";
            // 
            // RackPlacesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 409);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudSectionSize);
            this.Controls.Add(this.preview);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gbPlaces);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbDirection);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RackPlacesForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактирование мест";
            this.Load += new System.EventHandler(this.RackPlacesForm_Load);
            this.gbPlaces.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.placeTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.placesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSectionSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbDirection;
        private System.Windows.Forms.GroupBox gbPlaces;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnAddPlace;
        private System.Windows.Forms.ListBox lbTypes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDeletePlace;
        private System.Windows.Forms.ListBox lbPlaces;
        private System.Windows.Forms.Button btnClose;
        private WMSOffice.Data.D3 d3;
        private System.Windows.Forms.BindingSource placeTypesBindingSource;
        private WMSOffice.Data.D3TableAdapters.PlaceTypesTableAdapter placeTypesTableAdapter;
        private System.Windows.Forms.BindingSource placesBindingSource;
        private WMSOffice.Data.D3TableAdapters.PlacesTableAdapter placesTableAdapter;
        private WMSOffice.Controls.D3.View preview;
        private System.Windows.Forms.Button btnEditPlaceType;
        private System.Windows.Forms.NumericUpDown nudSectionSize;
        private System.Windows.Forms.Label label4;
    }
}