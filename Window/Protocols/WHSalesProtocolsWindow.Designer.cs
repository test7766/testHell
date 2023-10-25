namespace WMSOffice.Window.Protocols
{
    partial class WHSalesProtocolsWindow
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
            this.salesRegistriesHeadersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.printNakl = new WMSOffice.Data.PrintNakl();
            this.tsDoc = new System.Windows.Forms.ToolStrip();
            this.sbRefreshRegistries = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.sbFindRegistries = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.sbPreviewRegister = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.sbPrintRegistries = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cbPrinters = new System.Windows.Forms.ToolStripComboBox();
            this.salesRegistriesHeadersTableAdapter = new WMSOffice.Data.PrintNaklTableAdapters.SalesRegistriesHeadersTableAdapter();
            this.dgvSalesRegisrties = new System.Windows.Forms.DataGridView();
            this.registryNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.branchDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegistryDeliveryZone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.registryDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.registryStateIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.registryStateNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.registryStateColorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.salesRegistriesHeadersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printNakl)).BeginInit();
            this.tsDoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesRegisrties)).BeginInit();
            this.SuspendLayout();
            // 
            // salesRegistriesHeadersBindingSource
            // 
            this.salesRegistriesHeadersBindingSource.DataMember = "SalesRegistriesHeaders";
            this.salesRegistriesHeadersBindingSource.DataSource = this.printNakl;
            // 
            // printNakl
            // 
            this.printNakl.DataSetName = "PrintNakl";
            this.printNakl.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tsDoc
            // 
            this.tsDoc.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsDoc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbRefreshRegistries,
            this.toolStripSeparator2,
            this.sbFindRegistries,
            this.toolStripSeparator3,
            this.sbPreviewRegister,
            this.toolStripSeparator4,
            this.sbPrintRegistries,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.cbPrinters});
            this.tsDoc.Location = new System.Drawing.Point(0, 40);
            this.tsDoc.Name = "tsDoc";
            this.tsDoc.Size = new System.Drawing.Size(1088, 55);
            this.tsDoc.TabIndex = 2;
            this.tsDoc.Text = "toolStrip1";
            // 
            // sbRefreshRegistries
            // 
            this.sbRefreshRegistries.Image = global::WMSOffice.Properties.Resources.refresh;
            this.sbRefreshRegistries.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbRefreshRegistries.Name = "sbRefreshRegistries";
            this.sbRefreshRegistries.Size = new System.Drawing.Size(167, 52);
            this.sbRefreshRegistries.Text = "Обновить\nсписок протоколов";
            this.sbRefreshRegistries.Click += new System.EventHandler(this.sbRefreshProtocols_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // sbFindRegistries
            // 
            this.sbFindRegistries.Image = global::WMSOffice.Properties.Resources.find;
            this.sbFindRegistries.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbFindRegistries.Name = "sbFindRegistries";
            this.sbFindRegistries.Size = new System.Drawing.Size(163, 52);
            this.sbFindRegistries.Text = "Поиск протоколов";
            this.sbFindRegistries.Click += new System.EventHandler(this.sbFindProtocols_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 55);
            // 
            // sbPreviewRegister
            // 
            this.sbPreviewRegister.Image = global::WMSOffice.Properties.Resources.document_print_preview;
            this.sbPreviewRegister.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbPreviewRegister.Name = "sbPreviewRegister";
            this.sbPreviewRegister.Size = new System.Drawing.Size(178, 52);
            this.sbPreviewRegister.Text = "Просмотр протокола";
            this.sbPreviewRegister.Click += new System.EventHandler(this.sbPreviewRegister_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 55);
            // 
            // sbPrintRegistries
            // 
            this.sbPrintRegistries.Image = global::WMSOffice.Properties.Resources.document_print;
            this.sbPrintRegistries.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbPrintRegistries.Name = "sbPrintRegistries";
            this.sbPrintRegistries.Size = new System.Drawing.Size(160, 52);
            this.sbPrintRegistries.Text = "Печать протокола";
            this.sbPrintRegistries.Click += new System.EventHandler(this.sbPrintRegistries_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(58, 52);
            this.toolStripLabel1.Text = "Принтер:";
            // 
            // cbPrinters
            // 
            this.cbPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPrinters.Name = "cbPrinters";
            this.cbPrinters.Size = new System.Drawing.Size(250, 55);
            // 
            // salesRegistriesHeadersTableAdapter
            // 
            this.salesRegistriesHeadersTableAdapter.ClearBeforeFill = true;
            // 
            // dgvSalesRegisrties
            // 
            this.dgvSalesRegisrties.AllowUserToAddRows = false;
            this.dgvSalesRegisrties.AllowUserToDeleteRows = false;
            this.dgvSalesRegisrties.AllowUserToResizeRows = false;
            this.dgvSalesRegisrties.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSalesRegisrties.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSalesRegisrties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalesRegisrties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.registryNameDataGridViewTextBoxColumn,
            this.branchDataGridViewTextBoxColumn,
            this.RegistryDeliveryZone,
            this.registryDateDataGridViewTextBoxColumn,
            this.registryStateIDDataGridViewTextBoxColumn,
            this.registryStateNameDataGridViewTextBoxColumn,
            this.registryStateColorDataGridViewTextBoxColumn});
            this.dgvSalesRegisrties.DataSource = this.salesRegistriesHeadersBindingSource;
            this.dgvSalesRegisrties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSalesRegisrties.Location = new System.Drawing.Point(0, 95);
            this.dgvSalesRegisrties.Name = "dgvSalesRegisrties";
            this.dgvSalesRegisrties.ReadOnly = true;
            this.dgvSalesRegisrties.RowHeadersVisible = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dgvSalesRegisrties.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSalesRegisrties.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSalesRegisrties.Size = new System.Drawing.Size(1088, 473);
            this.dgvSalesRegisrties.TabIndex = 3;
            this.dgvSalesRegisrties.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvSalesProtocols_DataBindingComplete);
            // 
            // registryNameDataGridViewTextBoxColumn
            // 
            this.registryNameDataGridViewTextBoxColumn.DataPropertyName = "RegistryName";
            this.registryNameDataGridViewTextBoxColumn.HeaderText = "Название реестра";
            this.registryNameDataGridViewTextBoxColumn.Name = "registryNameDataGridViewTextBoxColumn";
            this.registryNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.registryNameDataGridViewTextBoxColumn.Width = 200;
            // 
            // branchDataGridViewTextBoxColumn
            // 
            this.branchDataGridViewTextBoxColumn.DataPropertyName = "Branch";
            this.branchDataGridViewTextBoxColumn.HeaderText = "Филиал";
            this.branchDataGridViewTextBoxColumn.Name = "branchDataGridViewTextBoxColumn";
            this.branchDataGridViewTextBoxColumn.ReadOnly = true;
            this.branchDataGridViewTextBoxColumn.Width = 200;
            // 
            // RegistryDeliveryZone
            // 
            this.RegistryDeliveryZone.DataPropertyName = "RegistryDeliveryZone";
            this.RegistryDeliveryZone.HeaderText = "Зона доставки";
            this.RegistryDeliveryZone.Name = "RegistryDeliveryZone";
            this.RegistryDeliveryZone.ReadOnly = true;
            this.RegistryDeliveryZone.Width = 200;
            // 
            // registryDateDataGridViewTextBoxColumn
            // 
            this.registryDateDataGridViewTextBoxColumn.DataPropertyName = "RegistryDate";
            this.registryDateDataGridViewTextBoxColumn.HeaderText = "Дата формирования реестра";
            this.registryDateDataGridViewTextBoxColumn.Name = "registryDateDataGridViewTextBoxColumn";
            this.registryDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.registryDateDataGridViewTextBoxColumn.Width = 165;
            // 
            // registryStateIDDataGridViewTextBoxColumn
            // 
            this.registryStateIDDataGridViewTextBoxColumn.DataPropertyName = "RegistryStateID";
            this.registryStateIDDataGridViewTextBoxColumn.HeaderText = "RegistryStateID";
            this.registryStateIDDataGridViewTextBoxColumn.Name = "registryStateIDDataGridViewTextBoxColumn";
            this.registryStateIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.registryStateIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // registryStateNameDataGridViewTextBoxColumn
            // 
            this.registryStateNameDataGridViewTextBoxColumn.DataPropertyName = "RegistryStateName";
            this.registryStateNameDataGridViewTextBoxColumn.HeaderText = "Статус";
            this.registryStateNameDataGridViewTextBoxColumn.Name = "registryStateNameDataGridViewTextBoxColumn";
            this.registryStateNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.registryStateNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // registryStateColorDataGridViewTextBoxColumn
            // 
            this.registryStateColorDataGridViewTextBoxColumn.DataPropertyName = "RegistryStateColor";
            this.registryStateColorDataGridViewTextBoxColumn.HeaderText = "RegistryStateColor";
            this.registryStateColorDataGridViewTextBoxColumn.Name = "registryStateColorDataGridViewTextBoxColumn";
            this.registryStateColorDataGridViewTextBoxColumn.ReadOnly = true;
            this.registryStateColorDataGridViewTextBoxColumn.Visible = false;
            // 
            // WHSalesProtocolsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 568);
            this.Controls.Add(this.dgvSalesRegisrties);
            this.Controls.Add(this.tsDoc);
            this.Name = "WHSalesProtocolsWindow";
            this.Text = "WHSalesProtocolsWindow";
            this.Controls.SetChildIndex(this.tsDoc, 0);
            this.Controls.SetChildIndex(this.dgvSalesRegisrties, 0);
            ((System.ComponentModel.ISupportInitialize)(this.salesRegistriesHeadersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printNakl)).EndInit();
            this.tsDoc.ResumeLayout(false);
            this.tsDoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesRegisrties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource salesRegistriesHeadersBindingSource;
        private WMSOffice.Data.PrintNakl printNakl;
        private System.Windows.Forms.ToolStrip tsDoc;
        private System.Windows.Forms.ToolStripButton sbRefreshRegistries;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton sbFindRegistries;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton sbPreviewRegister;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton sbPrintRegistries;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox cbPrinters;
        private WMSOffice.Data.PrintNaklTableAdapters.SalesRegistriesHeadersTableAdapter salesRegistriesHeadersTableAdapter;
        private System.Windows.Forms.DataGridView dgvSalesRegisrties;
        private System.Windows.Forms.DataGridViewTextBoxColumn registryNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn branchDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegistryDeliveryZone;
        private System.Windows.Forms.DataGridViewTextBoxColumn registryDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn registryStateIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn registryStateNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn registryStateColorDataGridViewTextBoxColumn;
    }
}