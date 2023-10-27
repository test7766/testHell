namespace WMSOffice.Controls.ExtraDataGridViewComponents
{
    partial class ExtraDataGridView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlDataViewContent = new System.Windows.Forms.Panel();
            this.dgvFilter = new System.Windows.Forms.DataGridView();
            this.cmFilterOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miClearFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.dgvSummary = new System.Windows.Forms.DataGridView();
            this.pnlDataViewNavigator = new System.Windows.Forms.Panel();
            this.pnlDataView = new System.Windows.Forms.Panel();
            this.pnlDataViewContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilter)).BeginInit();
            this.cmFilterOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSummary)).BeginInit();
            this.pnlDataView.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDataViewContent
            // 
            this.pnlDataViewContent.Controls.Add(this.dgvFilter);
            this.pnlDataViewContent.Controls.Add(this.dgvMain);
            this.pnlDataViewContent.Controls.Add(this.dgvSummary);
            this.pnlDataViewContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDataViewContent.Location = new System.Drawing.Point(0, 0);
            this.pnlDataViewContent.Name = "pnlDataViewContent";
            this.pnlDataViewContent.Size = new System.Drawing.Size(646, 268);
            this.pnlDataViewContent.TabIndex = 0;
            // 
            // dgvFilter
            // 
            this.dgvFilter.AllowUserToAddRows = false;
            this.dgvFilter.AllowUserToDeleteRows = false;
            this.dgvFilter.AllowUserToResizeColumns = false;
            this.dgvFilter.AllowUserToResizeRows = false;
            this.dgvFilter.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvFilter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFilter.ColumnHeadersVisible = false;
            this.dgvFilter.ContextMenuStrip = this.cmFilterOptions;
            this.dgvFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvFilter.Location = new System.Drawing.Point(0, 0);
            this.dgvFilter.MultiSelect = false;
            this.dgvFilter.Name = "dgvFilter";
            this.dgvFilter.RowHeadersVisible = false;
            this.dgvFilter.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvFilter.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvFilter.Size = new System.Drawing.Size(646, 27);
            this.dgvFilter.StandardTab = true;
            this.dgvFilter.TabIndex = 1;
            this.dgvFilter.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFilter_CellValueChanged);
            this.dgvFilter.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dgvFilter_Scroll);
            this.dgvFilter.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvFilter_EditingControlShowing);
            this.dgvFilter.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvFilter_CurrentCellDirtyStateChanged);
            this.dgvFilter.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFilter_CellEnter);
            // 
            // cmFilterOptions
            // 
            this.cmFilterOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miClearFilter});
            this.cmFilterOptions.Name = "cmFilterOptions";
            this.cmFilterOptions.Size = new System.Drawing.Size(201, 26);
            // 
            // miClearFilter
            // 
            this.miClearFilter.Name = "miClearFilter";
            this.miClearFilter.Size = new System.Drawing.Size(200, 22);
            this.miClearFilter.Text = "Очистить все фильтры";
            this.miClearFilter.Click += new System.EventHandler(this.miClearFilter_Click);
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvMain.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Location = new System.Drawing.Point(0, 26);
            this.dgvMain.MultiSelect = false;
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.RowHeadersVisible = false;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.ShowCellErrors = false;
            this.dgvMain.ShowEditingIcon = false;
            this.dgvMain.ShowRowErrors = false;
            this.dgvMain.Size = new System.Drawing.Size(646, 217);
            this.dgvMain.StandardTab = true;
            this.dgvMain.TabIndex = 0;
            this.dgvMain.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dgvMain_Scroll);
            this.dgvMain.ColumnDisplayIndexChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvMain_ColumnDisplayIndexChanged);
            this.dgvMain.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvMain_ColumnWidthChanged);
            // 
            // dgvSummary
            // 
            this.dgvSummary.AllowUserToAddRows = false;
            this.dgvSummary.AllowUserToDeleteRows = false;
            this.dgvSummary.AllowUserToResizeColumns = false;
            this.dgvSummary.AllowUserToResizeRows = false;
            this.dgvSummary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSummary.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSummary.ColumnHeadersVisible = false;
            this.dgvSummary.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvSummary.Location = new System.Drawing.Point(0, 243);
            this.dgvSummary.MultiSelect = false;
            this.dgvSummary.Name = "dgvSummary";
            this.dgvSummary.ReadOnly = true;
            this.dgvSummary.RowHeadersVisible = false;
            this.dgvSummary.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvSummary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvSummary.Size = new System.Drawing.Size(646, 25);
            this.dgvSummary.TabIndex = 2;
            this.dgvSummary.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dgvSummary_Scroll);
            // 
            // pnlDataViewNavigator
            // 
            this.pnlDataViewNavigator.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDataViewNavigator.Location = new System.Drawing.Point(0, 0);
            this.pnlDataViewNavigator.Name = "pnlDataViewNavigator";
            this.pnlDataViewNavigator.Size = new System.Drawing.Size(646, 0);
            this.pnlDataViewNavigator.TabIndex = 1;
            // 
            // pnlDataView
            // 
            this.pnlDataView.Controls.Add(this.pnlDataViewContent);
            this.pnlDataView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDataView.Location = new System.Drawing.Point(0, 0);
            this.pnlDataView.Name = "pnlDataView";
            this.pnlDataView.Size = new System.Drawing.Size(646, 268);
            this.pnlDataView.TabIndex = 0;
            // 
            // ExtraDataGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlDataView);
            this.Controls.Add(this.pnlDataViewNavigator);
            this.Name = "ExtraDataGridView";
            this.Size = new System.Drawing.Size(646, 268);
            this.pnlDataViewContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilter)).EndInit();
            this.cmFilterOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSummary)).EndInit();
            this.pnlDataView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDataViewContent;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.DataGridView dgvFilter;
        private System.Windows.Forms.DataGridView dgvSummary;
        private System.Windows.Forms.ContextMenuStrip cmFilterOptions;
        private System.Windows.Forms.ToolStripMenuItem miClearFilter;
        private System.Windows.Forms.Panel pnlDataViewNavigator;
        private System.Windows.Forms.Panel pnlDataView;
    }
}
