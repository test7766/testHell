namespace WMSOffice.Window
{
    partial class MedicinesRegistryWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsMainDocStrip = new System.Windows.Forms.ToolStrip();
            this.sbFindRegistry = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExportExtendedRegistry = new System.Windows.Forms.ToolStripButton();
            this.sbPrintRegistry = new System.Windows.Forms.ToolStripButton();
            this.btnPrintSellPermissionRegistry = new System.Windows.Forms.ToolStripButton();
            this.sbPrintTemperatureJournal = new System.Windows.Forms.ToolStripButton();
            this.btnPrintVaccine = new System.Windows.Forms.ToolStripButton();
            this.lbPrinters = new System.Windows.Forms.ToolStripLabel();
            this.cbPrinters = new System.Windows.Forms.ToolStripComboBox();
            this.tssBeforeAllow = new System.Windows.Forms.ToolStripSeparator();
            this.sbAllowRealization = new System.Windows.Forms.ToolStripButton();
            this.sbProvisors = new System.Windows.Forms.ToolStripButton();
            this.dgvRegistry = new System.Windows.Forms.DataGridView();
            this.menuRegistry = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miPreviewRegistry = new System.Windows.Forms.ToolStripMenuItem();
            this.miShowSellPermissionRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.miPreviewTemperatureJournal = new System.Windows.Forms.ToolStripMenuItem();
            this.miPrintVaccine = new System.Windows.Forms.ToolStripMenuItem();
            this.medicinesRegistryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quality = new WMSOffice.Data.Quality();
            this.medicinesRegistryTableAdapter = new WMSOffice.Data.QualityTableAdapters.MedicinesRegistryTableAdapter();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optimaordertypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optimaorderidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optima_invoice_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendor_invoice_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendor_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendornameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderdateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deliverydateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderamountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsMainDocStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistry)).BeginInit();
            this.menuRegistry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.medicinesRegistryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMainDocStrip
            // 
            this.tsMainDocStrip.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMainDocStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbFindRegistry,
            this.toolStripSeparator2,
            this.btnExportExtendedRegistry,
            this.sbPrintRegistry,
            this.btnPrintSellPermissionRegistry,
            this.sbPrintTemperatureJournal,
            this.btnPrintVaccine,
            this.lbPrinters,
            this.cbPrinters,
            this.tssBeforeAllow,
            this.sbAllowRealization,
            this.sbProvisors});
            this.tsMainDocStrip.Location = new System.Drawing.Point(0, 40);
            this.tsMainDocStrip.Name = "tsMainDocStrip";
            this.tsMainDocStrip.Size = new System.Drawing.Size(1360, 55);
            this.tsMainDocStrip.TabIndex = 1;
            this.tsMainDocStrip.Text = "toolStrip1";
            // 
            // sbFindRegistry
            // 
            this.sbFindRegistry.Image = global::WMSOffice.Properties.Resources.find;
            this.sbFindRegistry.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbFindRegistry.Name = "sbFindRegistry";
            this.sbFindRegistry.Size = new System.Drawing.Size(159, 52);
            this.sbFindRegistry.Text = "Поиск реестра ЛС";
            this.sbFindRegistry.Click += new System.EventHandler(this.sbFindRegistry_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // btnExportExtendedRegistry
            // 
            this.btnExportExtendedRegistry.Image = global::WMSOffice.Properties.Resources.Excel;
            this.btnExportExtendedRegistry.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportExtendedRegistry.Name = "btnExportExtendedRegistry";
            this.btnExportExtendedRegistry.Size = new System.Drawing.Size(190, 52);
            this.btnExportExtendedRegistry.Text = "Экспорт расширенного\nреестра";
            this.btnExportExtendedRegistry.ToolTipText = "Экспорт реестра с 16-ю колонками (для \"валютных\" поставщиков)";
            this.btnExportExtendedRegistry.Visible = false;
            this.btnExportExtendedRegistry.Click += new System.EventHandler(this.btnExportExtendedRegistry_Click);
            // 
            // sbPrintRegistry
            // 
            this.sbPrintRegistry.Image = global::WMSOffice.Properties.Resources.document_print;
            this.sbPrintRegistry.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbPrintRegistry.Name = "sbPrintRegistry";
            this.sbPrintRegistry.Size = new System.Drawing.Size(163, 52);
            this.sbPrintRegistry.Text = "Печать реестра ЛС";
            this.sbPrintRegistry.Click += new System.EventHandler(this.sbPrintRegistry_Click);
            // 
            // btnPrintSellPermissionRegistry
            // 
            this.btnPrintSellPermissionRegistry.Image = global::WMSOffice.Properties.Resources.print;
            this.btnPrintSellPermissionRegistry.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintSellPermissionRegistry.Name = "btnPrintSellPermissionRegistry";
            this.btnPrintSellPermissionRegistry.Size = new System.Drawing.Size(144, 52);
            this.btnPrintSellPermissionRegistry.Text = "Печать реестра\nРазрешений";
            this.btnPrintSellPermissionRegistry.ToolTipText = "Печать реестра Разрешений на реализацию серии на выбранном принтере";
            this.btnPrintSellPermissionRegistry.Visible = false;
            this.btnPrintSellPermissionRegistry.Click += new System.EventHandler(this.btnPrintSellPermissionRegistry_Click);
            // 
            // sbPrintTemperatureJournal
            // 
            this.sbPrintTemperatureJournal.Image = global::WMSOffice.Properties.Resources.document_print;
            this.sbPrintTemperatureJournal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbPrintTemperatureJournal.Name = "sbPrintTemperatureJournal";
            this.sbPrintTemperatureJournal.Size = new System.Drawing.Size(165, 52);
            this.sbPrintTemperatureJournal.Text = "Печать журнала\nучета темпаратуры";
            this.sbPrintTemperatureJournal.Click += new System.EventHandler(this.sbPrintTemperatureJournal_Click);
            // 
            // btnPrintVaccine
            // 
            this.btnPrintVaccine.Image = global::WMSOffice.Properties.Resources.document_print;
            this.btnPrintVaccine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintVaccine.Name = "btnPrintVaccine";
            this.btnPrintVaccine.Size = new System.Drawing.Size(102, 52);
            this.btnPrintVaccine.Text = "Печать\nреестра\nвакцин";
            this.btnPrintVaccine.Click += new System.EventHandler(this.PrintVaccine_Click);
            // 
            // lbPrinters
            // 
            this.lbPrinters.Name = "lbPrinters";
            this.lbPrinters.Size = new System.Drawing.Size(61, 52);
            this.lbPrinters.Text = "Принтер :";
            // 
            // cbPrinters
            // 
            this.cbPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPrinters.Name = "cbPrinters";
            this.cbPrinters.Size = new System.Drawing.Size(280, 55);
            // 
            // tssBeforeAllow
            // 
            this.tssBeforeAllow.Name = "tssBeforeAllow";
            this.tssBeforeAllow.Size = new System.Drawing.Size(6, 55);
            // 
            // sbAllowRealization
            // 
            this.sbAllowRealization.Image = global::WMSOffice.Properties.Resources.ok;
            this.sbAllowRealization.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbAllowRealization.Name = "sbAllowRealization";
            this.sbAllowRealization.Size = new System.Drawing.Size(127, 52);
            this.sbAllowRealization.Text = "Разрешить\nреализацию";
            this.sbAllowRealization.Click += new System.EventHandler(this.sbAllowRealization_Click);
            // 
            // sbProvisors
            // 
            this.sbProvisors.Image = global::WMSOffice.Properties.Resources.user;
            this.sbProvisors.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbProvisors.Name = "sbProvisors";
            this.sbProvisors.Size = new System.Drawing.Size(123, 52);
            this.sbProvisors.Text = "Провизоры";
            this.sbProvisors.Click += new System.EventHandler(this.sbProvisors_Click);
            // 
            // dgvRegistry
            // 
            this.dgvRegistry.AllowUserToAddRows = false;
            this.dgvRegistry.AllowUserToDeleteRows = false;
            this.dgvRegistry.AllowUserToResizeRows = false;
            this.dgvRegistry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRegistry.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRegistry.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRegistry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegistry.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.optimaordertypeDataGridViewTextBoxColumn,
            this.optimaorderidDataGridViewTextBoxColumn,
            this.optima_invoice_id,
            this.vendor_invoice_id,
            this.vendor_id,
            this.vendornameDataGridViewTextBoxColumn,
            this.orderdateDataGridViewTextBoxColumn,
            this.deliverydateDataGridViewTextBoxColumn,
            this.orderamountDataGridViewTextBoxColumn});
            this.dgvRegistry.ContextMenuStrip = this.menuRegistry;
            this.dgvRegistry.DataSource = this.medicinesRegistryBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRegistry.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRegistry.Location = new System.Drawing.Point(0, 98);
            this.dgvRegistry.Name = "dgvRegistry";
            this.dgvRegistry.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRegistry.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvRegistry.RowHeadersVisible = false;
            this.dgvRegistry.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRegistry.Size = new System.Drawing.Size(1360, 445);
            this.dgvRegistry.TabIndex = 2;
            this.dgvRegistry.SelectionChanged += new System.EventHandler(this.dgvRegistry_SelectionChanged);
            // 
            // menuRegistry
            // 
            this.menuRegistry.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miPreviewRegistry,
            this.miShowSellPermissionRegister,
            this.miPreviewTemperatureJournal,
            this.miPrintVaccine});
            this.menuRegistry.Name = "menuRegistry";
            this.menuRegistry.Size = new System.Drawing.Size(303, 92);
            // 
            // miPreviewRegistry
            // 
            this.miPreviewRegistry.Name = "miPreviewRegistry";
            this.miPreviewRegistry.Size = new System.Drawing.Size(302, 22);
            this.miPreviewRegistry.Text = "Просмотреть реестр";
            this.miPreviewRegistry.Click += new System.EventHandler(this.miPreviewRegistry_Click);
            // 
            // miShowSellPermissionRegister
            // 
            this.miShowSellPermissionRegister.Enabled = false;
            this.miShowSellPermissionRegister.Name = "miShowSellPermissionRegister";
            this.miShowSellPermissionRegister.Size = new System.Drawing.Size(302, 22);
            this.miShowSellPermissionRegister.Text = "Просмотр реестра Разрешений";
            this.miShowSellPermissionRegister.Click += new System.EventHandler(this.miShowSellPermissionRegister_Click);
            // 
            // miPreviewTemperatureJournal
            // 
            this.miPreviewTemperatureJournal.Name = "miPreviewTemperatureJournal";
            this.miPreviewTemperatureJournal.Size = new System.Drawing.Size(302, 22);
            this.miPreviewTemperatureJournal.Text = "Просмотреть журнал учета температуры";
            this.miPreviewTemperatureJournal.Click += new System.EventHandler(this.miPreviewTemperatureJournal_Click);
            // 
            // miPrintVaccine
            // 
            this.miPrintVaccine.Name = "miPrintVaccine";
            this.miPrintVaccine.Size = new System.Drawing.Size(302, 22);
            this.miPrintVaccine.Text = "Печать реестра вакцин";
            this.miPrintVaccine.Click += new System.EventHandler(this.PrintVaccine_Click);
            // 
            // medicinesRegistryBindingSource
            // 
            this.medicinesRegistryBindingSource.DataMember = "MedicinesRegistry";
            this.medicinesRegistryBindingSource.DataSource = this.quality;
            // 
            // quality
            // 
            this.quality.DataSetName = "Quality";
            this.quality.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // medicinesRegistryTableAdapter
            // 
            this.medicinesRegistryTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "optima_order_type";
            this.dataGridViewTextBoxColumn1.HeaderText = "Тип";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "vendor_order_id";
            this.dataGridViewTextBoxColumn2.HeaderText = "№ заказа (Отп.)";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 120;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "optima_order_id";
            this.dataGridViewTextBoxColumn3.HeaderText = "№ заказа (Оптима)";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 120;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "vendor_id";
            this.dataGridViewTextBoxColumn4.HeaderText = "Код отп.";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 120;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "vendor_name";
            this.dataGridViewTextBoxColumn5.HeaderText = "Отправитель";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 500;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "order_date";
            this.dataGridViewTextBoxColumn6.HeaderText = "Дата заказа";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 500;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "delivery_date";
            this.dataGridViewTextBoxColumn7.HeaderText = "Дата доставки";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "order_amount";
            this.dataGridViewTextBoxColumn8.HeaderText = "Сумма";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 120;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "order_amount";
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn9.HeaderText = "Сумма";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 120;
            // 
            // optimaordertypeDataGridViewTextBoxColumn
            // 
            this.optimaordertypeDataGridViewTextBoxColumn.DataPropertyName = "optima_order_type";
            this.optimaordertypeDataGridViewTextBoxColumn.HeaderText = "Тип";
            this.optimaordertypeDataGridViewTextBoxColumn.Name = "optimaordertypeDataGridViewTextBoxColumn";
            this.optimaordertypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // optimaorderidDataGridViewTextBoxColumn
            // 
            this.optimaorderidDataGridViewTextBoxColumn.DataPropertyName = "optima_order_id";
            this.optimaorderidDataGridViewTextBoxColumn.HeaderText = "№ заказа";
            this.optimaorderidDataGridViewTextBoxColumn.Name = "optimaorderidDataGridViewTextBoxColumn";
            this.optimaorderidDataGridViewTextBoxColumn.ReadOnly = true;
            this.optimaorderidDataGridViewTextBoxColumn.Width = 120;
            // 
            // optima_invoice_id
            // 
            this.optima_invoice_id.DataPropertyName = "optima_invoice_id";
            this.optima_invoice_id.HeaderText = "№ накладной";
            this.optima_invoice_id.Name = "optima_invoice_id";
            this.optima_invoice_id.ReadOnly = true;
            this.optima_invoice_id.Width = 120;
            // 
            // vendor_invoice_id
            // 
            this.vendor_invoice_id.DataPropertyName = "vendor_invoice_id";
            this.vendor_invoice_id.HeaderText = "№ накладной (отп.)";
            this.vendor_invoice_id.Name = "vendor_invoice_id";
            this.vendor_invoice_id.ReadOnly = true;
            this.vendor_invoice_id.Width = 120;
            // 
            // vendor_id
            // 
            this.vendor_id.DataPropertyName = "vendor_id";
            this.vendor_id.HeaderText = "Код отп.";
            this.vendor_id.Name = "vendor_id";
            this.vendor_id.ReadOnly = true;
            // 
            // vendornameDataGridViewTextBoxColumn
            // 
            this.vendornameDataGridViewTextBoxColumn.DataPropertyName = "vendor_name";
            this.vendornameDataGridViewTextBoxColumn.HeaderText = "Отправитель";
            this.vendornameDataGridViewTextBoxColumn.Name = "vendornameDataGridViewTextBoxColumn";
            this.vendornameDataGridViewTextBoxColumn.ReadOnly = true;
            this.vendornameDataGridViewTextBoxColumn.Width = 500;
            // 
            // orderdateDataGridViewTextBoxColumn
            // 
            this.orderdateDataGridViewTextBoxColumn.DataPropertyName = "order_date";
            this.orderdateDataGridViewTextBoxColumn.HeaderText = "Дата заказа";
            this.orderdateDataGridViewTextBoxColumn.Name = "orderdateDataGridViewTextBoxColumn";
            this.orderdateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // deliverydateDataGridViewTextBoxColumn
            // 
            this.deliverydateDataGridViewTextBoxColumn.DataPropertyName = "delivery_date";
            this.deliverydateDataGridViewTextBoxColumn.HeaderText = "Дата доставки";
            this.deliverydateDataGridViewTextBoxColumn.Name = "deliverydateDataGridViewTextBoxColumn";
            this.deliverydateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // orderamountDataGridViewTextBoxColumn
            // 
            this.orderamountDataGridViewTextBoxColumn.DataPropertyName = "order_amount";
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.orderamountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.orderamountDataGridViewTextBoxColumn.HeaderText = "Сумма";
            this.orderamountDataGridViewTextBoxColumn.Name = "orderamountDataGridViewTextBoxColumn";
            this.orderamountDataGridViewTextBoxColumn.ReadOnly = true;
            this.orderamountDataGridViewTextBoxColumn.Width = 120;
            // 
            // MedicinesRegistryWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 544);
            this.Controls.Add(this.dgvRegistry);
            this.Controls.Add(this.tsMainDocStrip);
            this.Name = "MedicinesRegistryWindow";
            this.Text = "MedicinesRegistryForm";
            this.Shown += new System.EventHandler(this.MedicinesRegistryWindow_Shown);
            this.Controls.SetChildIndex(this.tsMainDocStrip, 0);
            this.Controls.SetChildIndex(this.dgvRegistry, 0);
            this.tsMainDocStrip.ResumeLayout(false);
            this.tsMainDocStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistry)).EndInit();
            this.menuRegistry.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.medicinesRegistryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMainDocStrip;
        private System.Windows.Forms.ToolStripButton sbPrintRegistry;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton sbFindRegistry;
        private System.Windows.Forms.ToolStripLabel lbPrinters;
        private System.Windows.Forms.ToolStripComboBox cbPrinters;
        private System.Windows.Forms.DataGridView dgvRegistry;
        private System.Windows.Forms.BindingSource medicinesRegistryBindingSource;
        private WMSOffice.Data.Quality quality;
        private WMSOffice.Data.QualityTableAdapters.MedicinesRegistryTableAdapter medicinesRegistryTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendororderidDataGridViewTextBoxColumn;
        private System.Windows.Forms.ContextMenuStrip menuRegistry;
        private System.Windows.Forms.ToolStripMenuItem miPreviewRegistry;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn optimaordertypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn optimaorderidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn optima_invoice_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendor_invoice_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendor_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendornameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderdateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deliverydateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderamountDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripButton sbPrintTemperatureJournal;
        private System.Windows.Forms.ToolStripMenuItem miPreviewTemperatureJournal;
        private System.Windows.Forms.ToolStripSeparator tssBeforeAllow;
        private System.Windows.Forms.ToolStripButton sbAllowRealization;
        private System.Windows.Forms.ToolStripButton sbProvisors;
        private System.Windows.Forms.ToolStripButton btnExportExtendedRegistry;
        private System.Windows.Forms.ToolStripButton btnPrintSellPermissionRegistry;
        private System.Windows.Forms.ToolStripMenuItem miShowSellPermissionRegister;
        private System.Windows.Forms.ToolStripButton btnPrintVaccine;
        private System.Windows.Forms.ToolStripMenuItem miPrintVaccine;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
    }
}