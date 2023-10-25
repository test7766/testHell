namespace WMSOffice.Window.Protocols
{
    partial class MedicinesProtocolWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.quality = new WMSOffice.Data.Quality();
            this.tsMainDocStrip = new System.Windows.Forms.ToolStrip();
            this.sbFindRegistry = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.sbPrintRegistry = new System.Windows.Forms.ToolStripButton();
            this.lbPrinters = new System.Windows.Forms.ToolStripLabel();
            this.cbPrinters = new System.Windows.Forms.ToolStripComboBox();
            this.tssBeforeAllow = new System.Windows.Forms.ToolStripSeparator();
            this.medicinesRegistryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.medicinesRegistryTableAdapter = new WMSOffice.Data.QualityTableAdapters.MedicinesRegistryTableAdapter();
            this.menuRegistry = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miPreviewRegistry = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvRegistry = new System.Windows.Forms.DataGridView();
            this.optimaordertypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optimaorderidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optima_invoice_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendor_invoice_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendor_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendornameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderdateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deliverydateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderamountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            this.tsMainDocStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.medicinesRegistryBindingSource)).BeginInit();
            this.menuRegistry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistry)).BeginInit();
            this.SuspendLayout();
            // 
            // quality
            // 
            this.quality.DataSetName = "Quality";
            this.quality.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tsMainDocStrip
            // 
            this.tsMainDocStrip.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMainDocStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbFindRegistry,
            this.toolStripSeparator2,
            this.sbPrintRegistry,
            this.lbPrinters,
            this.cbPrinters,
            this.tssBeforeAllow});
            this.tsMainDocStrip.Location = new System.Drawing.Point(0, 40);
            this.tsMainDocStrip.Name = "tsMainDocStrip";
            this.tsMainDocStrip.Size = new System.Drawing.Size(1035, 55);
            this.tsMainDocStrip.TabIndex = 2;
            this.tsMainDocStrip.Text = "toolStrip1";
            // 
            // sbFindRegistry
            // 
            this.sbFindRegistry.Image = global::WMSOffice.Properties.Resources.find;
            this.sbFindRegistry.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbFindRegistry.Name = "sbFindRegistry";
            this.sbFindRegistry.Size = new System.Drawing.Size(175, 52);
            this.sbFindRegistry.Text = "Поиск протокола ЛС";
            this.sbFindRegistry.Click += new System.EventHandler(this.sbFindRegistry_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // sbPrintRegistry
            // 
            this.sbPrintRegistry.Image = global::WMSOffice.Properties.Resources.document_print;
            this.sbPrintRegistry.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbPrintRegistry.Name = "sbPrintRegistry";
            this.sbPrintRegistry.Size = new System.Drawing.Size(179, 52);
            this.sbPrintRegistry.Text = "Печать протокола ЛС";
            this.sbPrintRegistry.Click += new System.EventHandler(this.sbPrintRegistry_Click);
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
            // medicinesRegistryBindingSource
            // 
            this.medicinesRegistryBindingSource.DataMember = "MedicinesRegistry";
            this.medicinesRegistryBindingSource.DataSource = this.quality;
            // 
            // medicinesRegistryTableAdapter
            // 
            this.medicinesRegistryTableAdapter.ClearBeforeFill = true;
            // 
            // menuRegistry
            // 
            this.menuRegistry.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miPreviewRegistry});
            this.menuRegistry.Name = "menuRegistry";
            this.menuRegistry.Size = new System.Drawing.Size(205, 26);
            // 
            // miPreviewRegistry
            // 
            this.miPreviewRegistry.Name = "miPreviewRegistry";
            this.miPreviewRegistry.Size = new System.Drawing.Size(204, 22);
            this.miPreviewRegistry.Text = "Просмотреть протокол";
            this.miPreviewRegistry.Click += new System.EventHandler(this.miPreviewRegistry_Click);
            // 
            // dgvRegistry
            // 
            this.dgvRegistry.AllowUserToAddRows = false;
            this.dgvRegistry.AllowUserToDeleteRows = false;
            this.dgvRegistry.AllowUserToResizeRows = false;
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
            this.dgvRegistry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRegistry.Location = new System.Drawing.Point(0, 95);
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
            this.dgvRegistry.Size = new System.Drawing.Size(1035, 393);
            this.dgvRegistry.TabIndex = 3;
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
            // MedicinesProtocolWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 488);
            this.Controls.Add(this.dgvRegistry);
            this.Controls.Add(this.tsMainDocStrip);
            this.Name = "MedicinesProtocolWindow";
            this.Text = "MedicinesProtocolWindow";
            this.Controls.SetChildIndex(this.tsMainDocStrip, 0);
            this.Controls.SetChildIndex(this.dgvRegistry, 0);
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            this.tsMainDocStrip.ResumeLayout(false);
            this.tsMainDocStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.medicinesRegistryBindingSource)).EndInit();
            this.menuRegistry.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistry)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WMSOffice.Data.Quality quality;
        private System.Windows.Forms.ToolStrip tsMainDocStrip;
        private System.Windows.Forms.ToolStripButton sbFindRegistry;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton sbPrintRegistry;
        private System.Windows.Forms.ToolStripLabel lbPrinters;
        private System.Windows.Forms.ToolStripComboBox cbPrinters;
        private System.Windows.Forms.ToolStripSeparator tssBeforeAllow;
        private System.Windows.Forms.BindingSource medicinesRegistryBindingSource;
        private WMSOffice.Data.QualityTableAdapters.MedicinesRegistryTableAdapter medicinesRegistryTableAdapter;
        private System.Windows.Forms.ContextMenuStrip menuRegistry;
        private System.Windows.Forms.ToolStripMenuItem miPreviewRegistry;
        private System.Windows.Forms.DataGridView dgvRegistry;
        private System.Windows.Forms.DataGridViewTextBoxColumn optimaordertypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn optimaorderidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn optima_invoice_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendor_invoice_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendor_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendornameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderdateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deliverydateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderamountDataGridViewTextBoxColumn;
    }
}