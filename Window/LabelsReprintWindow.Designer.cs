namespace WMSOffice.Window
{
    partial class LabelsReprintWindow
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
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.lblOrder = new System.Windows.Forms.ToolStripLabel();
            this.tbOrder = new System.Windows.Forms.ToolStripTextBox();
            this.btnRefreshLabels = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblPrinters = new System.Windows.Forms.ToolStripLabel();
            this.cmbPrinters = new System.Windows.Forms.ToolStripComboBox();
            this.btnReprintLabels = new System.Windows.Forms.ToolStripButton();
            this.dgvLabels = new System.Windows.Forms.DataGridView();
            this.checkedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.orderNumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.companyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assemblyNumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eticIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.placesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReprintDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printerIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yellowEticDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lRLabelsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pickControl = new WMSOffice.Data.PickControl();
            this.lR_LabelsTableAdapter = new WMSOffice.Data.PickControlTableAdapters.LR_LabelsTableAdapter();
            this.tsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLabels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lRLabelsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblOrder,
            this.tbOrder,
            this.btnRefreshLabels,
            this.toolStripSeparator1,
            this.lblPrinters,
            this.cmbPrinters,
            this.btnReprintLabels});
            this.tsMain.Location = new System.Drawing.Point(0, 40);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1232, 55);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
            // 
            // lblOrder
            // 
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(85, 52);
            this.lblOrder.Text = "Номер заказа,\nсборочного";
            // 
            // tbOrder
            // 
            this.tbOrder.Name = "tbOrder";
            this.tbOrder.Size = new System.Drawing.Size(120, 55);
            // 
            // btnRefreshLabels
            // 
            this.btnRefreshLabels.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefreshLabels.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefreshLabels.Name = "btnRefreshLabels";
            this.btnRefreshLabels.Size = new System.Drawing.Size(113, 52);
            this.btnRefreshLabels.Text = "Обновить";
            this.btnRefreshLabels.ToolTipText = "Обновить (F5)";
            this.btnRefreshLabels.Click += new System.EventHandler(this.btnRefreshLabels_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // lblPrinters
            // 
            this.lblPrinters.Name = "lblPrinters";
            this.lblPrinters.Size = new System.Drawing.Size(97, 52);
            this.lblPrinters.Text = "Принтер\n(расположение)";
            // 
            // cmbPrinters
            // 
            this.cmbPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinters.Name = "cmbPrinters";
            this.cmbPrinters.Size = new System.Drawing.Size(250, 55);
            // 
            // btnReprintLabels
            // 
            this.btnReprintLabels.Image = global::WMSOffice.Properties.Resources.document_print;
            this.btnReprintLabels.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReprintLabels.Name = "btnReprintLabels";
            this.btnReprintLabels.Size = new System.Drawing.Size(122, 52);
            this.btnReprintLabels.Text = "Напечатать\nповторно";
            this.btnReprintLabels.ToolTipText = "Напечатать \nповторно (Ctrl + P)";
            this.btnReprintLabels.Click += new System.EventHandler(this.btnReprintLabels_Click);
            // 
            // dgvLabels
            // 
            this.dgvLabels.AllowUserToAddRows = false;
            this.dgvLabels.AllowUserToDeleteRows = false;
            this.dgvLabels.AllowUserToResizeRows = false;
            this.dgvLabels.AutoGenerateColumns = false;
            this.dgvLabels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLabels.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkedDataGridViewTextBoxColumn,
            this.orderNumDataGridViewTextBoxColumn,
            this.orderTypeDataGridViewTextBoxColumn,
            this.companyDataGridViewTextBoxColumn,
            this.assemblyNumDataGridViewTextBoxColumn,
            this.eticIDDataGridViewTextBoxColumn,
            this.placesDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.ReprintDate,
            this.printerIDDataGridViewTextBoxColumn,
            this.yellowEticDataGridViewTextBoxColumn});
            this.dgvLabels.DataSource = this.lRLabelsBindingSource;
            this.dgvLabels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLabels.Location = new System.Drawing.Point(0, 95);
            this.dgvLabels.MultiSelect = false;
            this.dgvLabels.Name = "dgvLabels";
            this.dgvLabels.RowHeadersVisible = false;
            this.dgvLabels.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLabels.Size = new System.Drawing.Size(1232, 342);
            this.dgvLabels.TabIndex = 2;
            this.dgvLabels.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvLabels_CellFormatting);
            this.dgvLabels.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvLabels_CurrentCellDirtyStateChanged);
            this.dgvLabels.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvLabels_DataError);
            // 
            // checkedDataGridViewTextBoxColumn
            // 
            this.checkedDataGridViewTextBoxColumn.DataPropertyName = "Checked";
            this.checkedDataGridViewTextBoxColumn.HeaderText = "Отм.";
            this.checkedDataGridViewTextBoxColumn.Name = "checkedDataGridViewTextBoxColumn";
            this.checkedDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.checkedDataGridViewTextBoxColumn.Width = 37;
            // 
            // orderNumDataGridViewTextBoxColumn
            // 
            this.orderNumDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.orderNumDataGridViewTextBoxColumn.DataPropertyName = "OrderNum";
            this.orderNumDataGridViewTextBoxColumn.HeaderText = "№ заказа";
            this.orderNumDataGridViewTextBoxColumn.Name = "orderNumDataGridViewTextBoxColumn";
            this.orderNumDataGridViewTextBoxColumn.ReadOnly = true;
            this.orderNumDataGridViewTextBoxColumn.Width = 76;
            // 
            // orderTypeDataGridViewTextBoxColumn
            // 
            this.orderTypeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.orderTypeDataGridViewTextBoxColumn.DataPropertyName = "OrderType";
            this.orderTypeDataGridViewTextBoxColumn.HeaderText = "Тип заказа";
            this.orderTypeDataGridViewTextBoxColumn.Name = "orderTypeDataGridViewTextBoxColumn";
            this.orderTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.orderTypeDataGridViewTextBoxColumn.Width = 83;
            // 
            // companyDataGridViewTextBoxColumn
            // 
            this.companyDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.companyDataGridViewTextBoxColumn.DataPropertyName = "Company";
            this.companyDataGridViewTextBoxColumn.HeaderText = "Компания";
            this.companyDataGridViewTextBoxColumn.Name = "companyDataGridViewTextBoxColumn";
            this.companyDataGridViewTextBoxColumn.ReadOnly = true;
            this.companyDataGridViewTextBoxColumn.Width = 83;
            // 
            // assemblyNumDataGridViewTextBoxColumn
            // 
            this.assemblyNumDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.assemblyNumDataGridViewTextBoxColumn.DataPropertyName = "AssemblyNum";
            this.assemblyNumDataGridViewTextBoxColumn.HeaderText = "№ сборочного";
            this.assemblyNumDataGridViewTextBoxColumn.Name = "assemblyNumDataGridViewTextBoxColumn";
            this.assemblyNumDataGridViewTextBoxColumn.ReadOnly = true;
            this.assemblyNumDataGridViewTextBoxColumn.Width = 96;
            // 
            // eticIDDataGridViewTextBoxColumn
            // 
            this.eticIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.eticIDDataGridViewTextBoxColumn.DataPropertyName = "EticID";
            this.eticIDDataGridViewTextBoxColumn.HeaderText = "Номер этикетки";
            this.eticIDDataGridViewTextBoxColumn.Name = "eticIDDataGridViewTextBoxColumn";
            this.eticIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.eticIDDataGridViewTextBoxColumn.Width = 106;
            // 
            // placesDataGridViewTextBoxColumn
            // 
            this.placesDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.placesDataGridViewTextBoxColumn.DataPropertyName = "Places";
            this.placesDataGridViewTextBoxColumn.HeaderText = "Кол-во мест";
            this.placesDataGridViewTextBoxColumn.Name = "placesDataGridViewTextBoxColumn";
            this.placesDataGridViewTextBoxColumn.ReadOnly = true;
            this.placesDataGridViewTextBoxColumn.Width = 87;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Статус";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusDataGridViewTextBoxColumn.Width = 66;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "Дата создания";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ReprintDate
            // 
            this.ReprintDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ReprintDate.DataPropertyName = "ReprintDate";
            this.ReprintDate.HeaderText = "Дата печати";
            this.ReprintDate.Name = "ReprintDate";
            this.ReprintDate.ReadOnly = true;
            this.ReprintDate.Width = 88;
            // 
            // printerIDDataGridViewTextBoxColumn
            // 
            this.printerIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.printerIDDataGridViewTextBoxColumn.DataPropertyName = "PrinterID";
            this.printerIDDataGridViewTextBoxColumn.HeaderText = "Принтер";
            this.printerIDDataGridViewTextBoxColumn.Name = "printerIDDataGridViewTextBoxColumn";
            this.printerIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.printerIDDataGridViewTextBoxColumn.Width = 75;
            // 
            // yellowEticDataGridViewTextBoxColumn
            // 
            this.yellowEticDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.yellowEticDataGridViewTextBoxColumn.DataPropertyName = "YellowEtic";
            this.yellowEticDataGridViewTextBoxColumn.HeaderText = "Номер ЖЭ";
            this.yellowEticDataGridViewTextBoxColumn.Name = "yellowEticDataGridViewTextBoxColumn";
            this.yellowEticDataGridViewTextBoxColumn.ReadOnly = true;
            this.yellowEticDataGridViewTextBoxColumn.Width = 80;
            // 
            // lRLabelsBindingSource
            // 
            this.lRLabelsBindingSource.DataMember = "LR_Labels";
            this.lRLabelsBindingSource.DataSource = this.pickControl;
            // 
            // pickControl
            // 
            this.pickControl.DataSetName = "PickControl";
            this.pickControl.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lR_LabelsTableAdapter
            // 
            this.lR_LabelsTableAdapter.ClearBeforeFill = true;
            // 
            // LabelsReprintWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 437);
            this.Controls.Add(this.dgvLabels);
            this.Controls.Add(this.tsMain);
            this.Name = "LabelsReprintWindow";
            this.Text = "LabelsReprintWindow";
            this.Load += new System.EventHandler(this.LabelsReprintWindow_Load);
            this.Controls.SetChildIndex(this.tsMain, 0);
            this.Controls.SetChildIndex(this.dgvLabels, 0);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLabels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lRLabelsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btnRefreshLabels;
        private System.Windows.Forms.ToolStripLabel lblOrder;
        private System.Windows.Forms.ToolStripTextBox tbOrder;
        private System.Windows.Forms.ToolStripLabel lblPrinters;
        private System.Windows.Forms.ToolStripComboBox cmbPrinters;
        private System.Windows.Forms.ToolStripButton btnReprintLabels;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridView dgvLabels;
        private System.Windows.Forms.BindingSource lRLabelsBindingSource;
        private WMSOffice.Data.PickControl pickControl;
        private WMSOffice.Data.PickControlTableAdapters.LR_LabelsTableAdapter lR_LabelsTableAdapter;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderNumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn companyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn assemblyNumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eticIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn placesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReprintDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn printerIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yellowEticDataGridViewTextBoxColumn;
    }
}