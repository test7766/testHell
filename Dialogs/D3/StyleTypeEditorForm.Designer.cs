namespace WMSOffice.Dialogs.D3
{
    partial class StyleTypeEditorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StyleTypeEditorForm));
            this.lvStyles = new System.Windows.Forms.ListView();
            this.ilStylesLarge = new System.Windows.Forms.ImageList(this.components);
            this.ilStylesSmall = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnAddStyle = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnView = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnViewLargeIcon = new System.Windows.Forms.ToolStripMenuItem();
            this.btnViewSmallIcon = new System.Windows.Forms.ToolStripMenuItem();
            this.btnViewList = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEditStyle = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stylesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.d3 = new WMSOffice.Data.D3();
            this.stylesTableAdapter = new WMSOffice.Data.D3TableAdapters.StylesTableAdapter();
            this.btnDeleteStyle = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stylesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d3)).BeginInit();
            this.SuspendLayout();
            // 
            // lvStyles
            // 
            this.lvStyles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvStyles.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lvStyles.GridLines = true;
            this.lvStyles.LargeImageList = this.ilStylesLarge;
            this.lvStyles.Location = new System.Drawing.Point(0, 25);
            this.lvStyles.Name = "lvStyles";
            this.lvStyles.Size = new System.Drawing.Size(478, 356);
            this.lvStyles.SmallImageList = this.ilStylesSmall;
            this.lvStyles.TabIndex = 101;
            this.lvStyles.UseCompatibleStateImageBehavior = false;
            this.lvStyles.View = System.Windows.Forms.View.List;
            this.lvStyles.SelectedIndexChanged += new System.EventHandler(this.lvStyles_SelectedIndexChanged);
            this.lvStyles.DoubleClick += new System.EventHandler(this.lvStyles_DoubleClick);
            // 
            // ilStylesLarge
            // 
            this.ilStylesLarge.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ilStylesLarge.ImageSize = new System.Drawing.Size(48, 48);
            this.ilStylesLarge.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ilStylesSmall
            // 
            this.ilStylesSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ilStylesSmall.ImageSize = new System.Drawing.Size(24, 24);
            this.ilStylesSmall.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddStyle,
            this.toolStripSeparator2,
            this.btnEditStyle,
            this.btnDeleteStyle,
            this.toolStripSeparator1,
            this.btnView});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(478, 25);
            this.toolStrip.TabIndex = 102;
            this.toolStrip.Text = "toolStrip1";
            // 
            // btnAddStyle
            // 
            this.btnAddStyle.Image = global::WMSOffice.Properties.Resources.add;
            this.btnAddStyle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddStyle.Name = "btnAddStyle";
            this.btnAddStyle.Size = new System.Drawing.Size(113, 22);
            this.btnAddStyle.Text = "Добавить стиль";
            this.btnAddStyle.Click += new System.EventHandler(this.btnAddStyle_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnView
            // 
            this.btnView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnViewLargeIcon,
            this.btnViewSmallIcon,
            this.btnViewList});
            this.btnView.Image = ((System.Drawing.Image)(resources.GetObject("btnView.Image")));
            this.btnView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(40, 22);
            this.btnView.Text = "Вид";
            // 
            // btnViewLargeIcon
            // 
            this.btnViewLargeIcon.Name = "btnViewLargeIcon";
            this.btnViewLargeIcon.Size = new System.Drawing.Size(179, 22);
            this.btnViewLargeIcon.Text = "Большие иконки";
            this.btnViewLargeIcon.Click += new System.EventHandler(this.btnViewLargeIcon_Click);
            // 
            // btnViewSmallIcon
            // 
            this.btnViewSmallIcon.Name = "btnViewSmallIcon";
            this.btnViewSmallIcon.Size = new System.Drawing.Size(179, 22);
            this.btnViewSmallIcon.Text = "Маленькие иконки";
            this.btnViewSmallIcon.Click += new System.EventHandler(this.btnViewSmallIcon_Click);
            // 
            // btnViewList
            // 
            this.btnViewList.Checked = true;
            this.btnViewList.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnViewList.Name = "btnViewList";
            this.btnViewList.Size = new System.Drawing.Size(179, 22);
            this.btnViewList.Text = "Список";
            this.btnViewList.Click += new System.EventHandler(this.btnViewList_Click);
            // 
            // btnEditStyle
            // 
            this.btnEditStyle.Image = global::WMSOffice.Properties.Resources.edit_document;
            this.btnEditStyle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditStyle.Name = "btnEditStyle";
            this.btnEditStyle.Size = new System.Drawing.Size(107, 22);
            this.btnEditStyle.Text = "Редактировать";
            this.btnEditStyle.Click += new System.EventHandler(this.btnEditStyle_Click);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewImageColumn1.HeaderText = "Вид";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Style_ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "Название";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // stylesBindingSource
            // 
            this.stylesBindingSource.DataMember = "Styles";
            this.stylesBindingSource.DataSource = this.d3;
            // 
            // d3
            // 
            this.d3.DataSetName = "D3";
            this.d3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // stylesTableAdapter
            // 
            this.stylesTableAdapter.ClearBeforeFill = true;
            // 
            // btnDeleteStyle
            // 
            this.btnDeleteStyle.Image = global::WMSOffice.Properties.Resources.close;
            this.btnDeleteStyle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteStyle.Name = "btnDeleteStyle";
            this.btnDeleteStyle.Size = new System.Drawing.Size(71, 22);
            this.btnDeleteStyle.Text = "Удалить";
            this.btnDeleteStyle.Click += new System.EventHandler(this.btnDeleteStyle_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // StyleTypeEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 424);
            this.Controls.Add(this.lvStyles);
            this.Controls.Add(this.toolStrip);
            this.Name = "StyleTypeEditorForm";
            this.Text = "Стили";
            this.Load += new System.EventHandler(this.StyleTypeEditorForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StyleTypeEditorForm_FormClosing);
            this.Controls.SetChildIndex(this.toolStrip, 0);
            this.Controls.SetChildIndex(this.lvStyles, 0);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stylesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource stylesBindingSource;
        private WMSOffice.Data.D3 d3;
        private WMSOffice.Data.D3TableAdapters.StylesTableAdapter stylesTableAdapter;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.ListView lvStyles;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnAddStyle;
        private System.Windows.Forms.ImageList ilStylesSmall;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton btnView;
        private System.Windows.Forms.ToolStripMenuItem btnViewLargeIcon;
        private System.Windows.Forms.ToolStripMenuItem btnViewSmallIcon;
        private System.Windows.Forms.ToolStripMenuItem btnViewList;
        private System.Windows.Forms.ImageList ilStylesLarge;
        private System.Windows.Forms.ToolStripButton btnEditStyle;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnDeleteStyle;
    }
}