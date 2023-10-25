namespace WMSOffice.Window
{
    partial class WHSalesRegistriesWindow
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
            this.dgvSalesRegisrties = new System.Windows.Forms.DataGridView();
            this.registryNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.branchDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegistryDeliveryZone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.registryDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.registryStateIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.registryStateNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.registryStateColorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salesRegistriesHeadersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.printNakl = new WMSOffice.Data.PrintNakl();
            this.salesRegistriesHeadersTableAdapter = new WMSOffice.Data.PrintNaklTableAdapters.SalesRegistriesHeadersTableAdapter();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsDoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesRegisrties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesRegistriesHeadersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printNakl)).BeginInit();
            this.SuspendLayout();
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
            this.tsDoc.Size = new System.Drawing.Size(1098, 55);
            this.tsDoc.TabIndex = 1;
            this.tsDoc.Text = "toolStrip1";
            // 
            // sbRefreshRegistries
            // 
            this.sbRefreshRegistries.Image = global::WMSOffice.Properties.Resources.refresh;
            this.sbRefreshRegistries.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbRefreshRegistries.Name = "sbRefreshRegistries";
            this.sbRefreshRegistries.Size = new System.Drawing.Size(151, 52);
            this.sbRefreshRegistries.Text = "Обновить\nсписок реестров";
            this.sbRefreshRegistries.Click += new System.EventHandler(this.sbRefreshRegistries_Click);
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
            this.sbFindRegistries.Size = new System.Drawing.Size(147, 52);
            this.sbFindRegistries.Text = "Поиск реестров";
            this.sbFindRegistries.Click += new System.EventHandler(this.sbFindRegistries_Click);
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
            this.sbPreviewRegister.Size = new System.Drawing.Size(162, 52);
            this.sbPreviewRegister.Text = "Просмотр реестра";
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
            this.sbPrintRegistries.Size = new System.Drawing.Size(151, 52);
            this.sbPrintRegistries.Text = "Печать реестров";
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
            // dgvSalesRegisrties
            // 
            this.dgvSalesRegisrties.AllowUserToAddRows = false;
            this.dgvSalesRegisrties.AllowUserToDeleteRows = false;
            this.dgvSalesRegisrties.AllowUserToResizeRows = false;
            this.dgvSalesRegisrties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
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
            this.dgvSalesRegisrties.Location = new System.Drawing.Point(0, 98);
            this.dgvSalesRegisrties.Name = "dgvSalesRegisrties";
            this.dgvSalesRegisrties.ReadOnly = true;
            this.dgvSalesRegisrties.RowHeadersVisible = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dgvSalesRegisrties.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSalesRegisrties.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSalesRegisrties.Size = new System.Drawing.Size(1098, 377);
            this.dgvSalesRegisrties.TabIndex = 2;
            this.dgvSalesRegisrties.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvSalesRegisrties_DataBindingComplete);
            this.dgvSalesRegisrties.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesRegisrties_CellContentClick);
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
            // salesRegistriesHeadersTableAdapter
            // 
            this.salesRegistriesHeadersTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "RegistryName";
            this.dataGridViewTextBoxColumn1.HeaderText = "Название реестра";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 300;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Branch";
            this.dataGridViewTextBoxColumn2.HeaderText = "Филиал";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "RegistryDate";
            this.dataGridViewTextBoxColumn3.HeaderText = "Дата формирования реестра";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "RegistryStateID";
            this.dataGridViewTextBoxColumn4.HeaderText = "RegistryStateID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "RegistryStateName";
            this.dataGridViewTextBoxColumn5.HeaderText = "Статус";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 150;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "RegistryStateColor";
            this.dataGridViewTextBoxColumn6.HeaderText = "RegistryStateColor";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // WHSalesRegistriesWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 476);
            this.Controls.Add(this.dgvSalesRegisrties);
            this.Controls.Add(this.tsDoc);
            this.Name = "WHSalesRegistriesWindow";
            this.Text = "WHSalesRegistriesWindow";
            this.Shown += new System.EventHandler(this.WHSalesRegistriesWindow_Shown);
            this.Controls.SetChildIndex(this.tsDoc, 0);
            this.Controls.SetChildIndex(this.dgvSalesRegisrties, 0);
            this.tsDoc.ResumeLayout(false);
            this.tsDoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesRegisrties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesRegistriesHeadersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printNakl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsDoc;
        private System.Windows.Forms.ToolStripButton sbRefreshRegistries;
        private System.Windows.Forms.ToolStripButton sbPrintRegistries;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox cbPrinters;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.DataGridView dgvSalesRegisrties;
        private System.Windows.Forms.ToolStripButton sbFindRegistries;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.BindingSource salesRegistriesHeadersBindingSource;
        private WMSOffice.Data.PrintNakl printNakl;
        private WMSOffice.Data.PrintNaklTableAdapters.SalesRegistriesHeadersTableAdapter salesRegistriesHeadersTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.ToolStripButton sbPreviewRegister;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.DataGridViewTextBoxColumn registryNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn branchDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegistryDeliveryZone;
        private System.Windows.Forms.DataGridViewTextBoxColumn registryDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn registryStateIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn registryStateNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn registryStateColorDataGridViewTextBoxColumn;
    }
}