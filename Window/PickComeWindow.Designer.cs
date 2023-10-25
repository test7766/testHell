namespace WMSOffice.Window
{
    partial class PickComeWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PickComeWindow));
            this.gvLines = new System.Windows.Forms.DataGridView();
            this.shipToDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderNumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pickSlipDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.getPSSToStatusBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pickControl = new WMSOffice.Data.PickControl();
            this.getPSSToStatusTableAdapter = new WMSOffice.Data.PickControlTableAdapters.GetPSSToStatusTableAdapter();
            this.tsToolbar = new System.Windows.Forms.ToolStrip();
            this.sbRegisterMultiPick = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tbBarcode = new WMSOffice.Controls.TextBoxScaner();
            ((System.ComponentModel.ISupportInitialize)(this.gvLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getPSSToStatusBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).BeginInit();
            this.tsToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvLines
            // 
            this.gvLines.AllowUserToAddRows = false;
            this.gvLines.AllowUserToDeleteRows = false;
            this.gvLines.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.gvLines.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvLines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gvLines.AutoGenerateColumns = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvLines.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gvLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvLines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.shipToDataGridViewTextBoxColumn,
            this.orderNumDataGridViewTextBoxColumn,
            this.orderTypeDataGridViewTextBoxColumn,
            this.pickSlipDataGridViewTextBoxColumn});
            this.gvLines.DataSource = this.getPSSToStatusBindingSource;
            this.gvLines.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gvLines.Location = new System.Drawing.Point(0, 98);
            this.gvLines.Name = "gvLines";
            this.gvLines.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvLines.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gvLines.RowHeadersVisible = false;
            this.gvLines.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gvLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvLines.ShowEditingIcon = false;
            this.gvLines.Size = new System.Drawing.Size(866, 302);
            this.gvLines.TabIndex = 2;
            // 
            // shipToDataGridViewTextBoxColumn
            // 
            this.shipToDataGridViewTextBoxColumn.DataPropertyName = "ShipTo";
            this.shipToDataGridViewTextBoxColumn.HeaderText = "Получатель";
            this.shipToDataGridViewTextBoxColumn.Name = "shipToDataGridViewTextBoxColumn";
            this.shipToDataGridViewTextBoxColumn.ReadOnly = true;
            this.shipToDataGridViewTextBoxColumn.Width = 400;
            // 
            // orderNumDataGridViewTextBoxColumn
            // 
            this.orderNumDataGridViewTextBoxColumn.DataPropertyName = "OrderNum";
            this.orderNumDataGridViewTextBoxColumn.HeaderText = "Номер заказа";
            this.orderNumDataGridViewTextBoxColumn.Name = "orderNumDataGridViewTextBoxColumn";
            this.orderNumDataGridViewTextBoxColumn.ReadOnly = true;
            this.orderNumDataGridViewTextBoxColumn.Width = 140;
            // 
            // orderTypeDataGridViewTextBoxColumn
            // 
            this.orderTypeDataGridViewTextBoxColumn.DataPropertyName = "OrderType";
            this.orderTypeDataGridViewTextBoxColumn.HeaderText = "Тип заказа";
            this.orderTypeDataGridViewTextBoxColumn.Name = "orderTypeDataGridViewTextBoxColumn";
            this.orderTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.orderTypeDataGridViewTextBoxColumn.Width = 80;
            // 
            // pickSlipDataGridViewTextBoxColumn
            // 
            this.pickSlipDataGridViewTextBoxColumn.DataPropertyName = "PickSlip";
            this.pickSlipDataGridViewTextBoxColumn.HeaderText = "Номер сборочного";
            this.pickSlipDataGridViewTextBoxColumn.Name = "pickSlipDataGridViewTextBoxColumn";
            this.pickSlipDataGridViewTextBoxColumn.ReadOnly = true;
            this.pickSlipDataGridViewTextBoxColumn.Width = 160;
            // 
            // getPSSToStatusBindingSource
            // 
            this.getPSSToStatusBindingSource.DataMember = "GetPSSToStatus";
            this.getPSSToStatusBindingSource.DataSource = this.pickControl;
            // 
            // pickControl
            // 
            this.pickControl.DataSetName = "PickControl";
            this.pickControl.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // getPSSToStatusTableAdapter
            // 
            this.getPSSToStatusTableAdapter.ClearBeforeFill = true;
            // 
            // tsToolbar
            // 
            this.tsToolbar.Dock = System.Windows.Forms.DockStyle.None;
            this.tsToolbar.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbRegisterMultiPick,
            this.toolStripSeparator1,
            this.toolStripLabel1});
            this.tsToolbar.Location = new System.Drawing.Point(0, 40);
            this.tsToolbar.Name = "tsToolbar";
            this.tsToolbar.Size = new System.Drawing.Size(234, 55);
            this.tsToolbar.TabIndex = 3;
            this.tsToolbar.Text = "tsToolbar";
            // 
            // sbRegisterMultiPick
            // 
            this.sbRegisterMultiPick.Image = global::WMSOffice.Properties.Resources.assign;
            this.sbRegisterMultiPick.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbRegisterMultiPick.Name = "sbRegisterMultiPick";
            this.sbRegisterMultiPick.Size = new System.Drawing.Size(139, 52);
            this.sbRegisterMultiPick.Text = "Регистрация\nмультисборки";
            this.sbRegisterMultiPick.Click += new System.EventHandler(this.sbRegisterMultiPick_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(77, 52);
            this.toolStripLabel1.Text = "Штрих-код\nсборочного:";
            // 
            // tbBarcode
            // 
            this.tbBarcode.AllowType = true;
            this.tbBarcode.AutoConvert = true;
            this.tbBarcode.Location = new System.Drawing.Point(235, 57);
            this.tbBarcode.Name = "tbBarcode";
            this.tbBarcode.RaiseTextChangeWithoutEnter = false;
            this.tbBarcode.ReadOnly = false;
            this.tbBarcode.Size = new System.Drawing.Size(375, 25);
            this.tbBarcode.TabIndex = 1;
            this.tbBarcode.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.tbBarcode.UseParentFont = false;
            // 
            // PickComeWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 400);
            this.Controls.Add(this.tbBarcode);
            this.Controls.Add(this.tsToolbar);
            this.Controls.Add(this.gvLines);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PickComeWindow";
            this.Text = "PickComeWindow";
            this.Load += new System.EventHandler(this.PickComeWindow_Load);
            this.Controls.SetChildIndex(this.gvLines, 0);
            this.Controls.SetChildIndex(this.tsToolbar, 0);
            this.Controls.SetChildIndex(this.tbBarcode, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gvLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getPSSToStatusBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).EndInit();
            this.tsToolbar.ResumeLayout(false);
            this.tsToolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvLines;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipToDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderNumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pickSlipDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource getPSSToStatusBindingSource;
        private WMSOffice.Data.PickControl pickControl;
        private WMSOffice.Data.PickControlTableAdapters.GetPSSToStatusTableAdapter getPSSToStatusTableAdapter;
        private System.Windows.Forms.ToolStrip tsToolbar;
        private System.Windows.Forms.ToolStripButton sbRegisterMultiPick;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private WMSOffice.Controls.TextBoxScaner tbBarcode;
    }
}