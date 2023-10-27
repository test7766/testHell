namespace WMSOffice.Dialogs.WH
{
    partial class WhExportDestructionRequestsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WhExportDestructionRequestsForm));
            this.btnCancel = new System.Windows.Forms.Button();
            this.dgvDestructionRequest = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.tsTools = new System.Windows.Forms.ToolStrip();
            this.btnConsolidExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExportToPdf = new System.Windows.Forms.ToolStripButton();
            this.btnExportExcel = new System.Windows.Forms.ToolStripButton();
            this.cmbPrintedFilter = new System.Windows.Forms.ToolStripComboBox();
            this.btnAcceptanceTransmission = new System.Windows.Forms.ToolStripButton();
            this.btnSendWithRegistry = new System.Windows.Forms.ToolStripButton();
            this.cmsDestructionRequests = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miExportToPdf = new System.Windows.Forms.ToolStripMenuItem();
            this.wh = new WMSOffice.Data.WH();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsTools.SuspendLayout();
            this.cmsDestructionRequests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wh)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(876, 461);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 33);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Закрыть";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // dgvDestructionRequest
            // 
            this.dgvDestructionRequest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDestructionRequest.BackColor = System.Drawing.SystemColors.Control;
            this.dgvDestructionRequest.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.dgvDestructionRequest.LargeAmountOfData = false;
            this.dgvDestructionRequest.Location = new System.Drawing.Point(0, 42);
            this.dgvDestructionRequest.Name = "dgvDestructionRequest";
            this.dgvDestructionRequest.RowHeadersVisible = false;
            this.dgvDestructionRequest.Size = new System.Drawing.Size(973, 413);
            this.dgvDestructionRequest.TabIndex = 4;
            this.dgvDestructionRequest.UserID = ((long)(0));
            // 
            // tsTools
            // 
            this.tsTools.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnConsolidExportToExcel,
            this.toolStripSeparator1,
            this.btnExportToPdf,
            this.btnExportExcel,
            this.cmbPrintedFilter,
            this.btnAcceptanceTransmission,
            this.btnSendWithRegistry,
            this.toolStripSeparator2});
            this.tsTools.Location = new System.Drawing.Point(0, 0);
            this.tsTools.Name = "tsTools";
            this.tsTools.Size = new System.Drawing.Size(973, 39);
            this.tsTools.TabIndex = 1;
            this.tsTools.Text = "toolStrip1";
            // 
            // btnConsolidExportToExcel
            // 
            this.btnConsolidExportToExcel.Image = global::WMSOffice.Properties.Resources.Excel;
            this.btnConsolidExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConsolidExportToExcel.Name = "btnConsolidExportToExcel";
            this.btnConsolidExportToExcel.Size = new System.Drawing.Size(125, 36);
            this.btnConsolidExportToExcel.Text = "Консолид.\nэкспорт в Excel";
            this.btnConsolidExportToExcel.Click += new System.EventHandler(this.btnConsolidExportExcel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // btnExportToPdf
            // 
            this.btnExportToPdf.Image = global::WMSOffice.Properties.Resources.export_pdf;
            this.btnExportToPdf.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportToPdf.Name = "btnExportToPdf";
            this.btnExportToPdf.Size = new System.Drawing.Size(121, 36);
            this.btnExportToPdf.Text = "Экспорт в PDF";
            this.btnExportToPdf.ToolTipText = "Экспорт выбранных заявок на уничтожение в Excel-файлы";
            this.btnExportToPdf.Click += new System.EventHandler(this.btnExportToPdf_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExportExcel.Image")));
            this.btnExportExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(126, 36);
            this.btnExportExcel.Text = "Экспорт в Excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // cmbPrintedFilter
            // 
            this.cmbPrintedFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrintedFilter.Name = "cmbPrintedFilter";
            this.cmbPrintedFilter.Size = new System.Drawing.Size(200, 39);
            // 
            // btnAcceptanceTransmission
            // 
            this.btnAcceptanceTransmission.Image = global::WMSOffice.Properties.Resources.document_print_preview;
            this.btnAcceptanceTransmission.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAcceptanceTransmission.Name = "btnAcceptanceTransmission";
            this.btnAcceptanceTransmission.Size = new System.Drawing.Size(164, 36);
            this.btnAcceptanceTransmission.Text = "Акт приема-передачи";
            this.btnAcceptanceTransmission.Click += new System.EventHandler(this.btnAcceptanceTransmission_Click);
            // 
            // btnSendWithRegistry
            // 
            this.btnSendWithRegistry.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSendWithRegistry.Image = global::WMSOffice.Properties.Resources.Excel;
            this.btnSendWithRegistry.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSendWithRegistry.Name = "btnSendWithRegistry";
            this.btnSendWithRegistry.Size = new System.Drawing.Size(150, 36);
            this.btnSendWithRegistry.Text = "Отправить Реестр\nзаявок Контрагенту";
            this.btnSendWithRegistry.Click += new System.EventHandler(this.btnSendWithRegistry_Click);
            // 
            // cmsDestructionRequests
            // 
            this.cmsDestructionRequests.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miExportToPdf});
            this.cmsDestructionRequests.Name = "cmsPrintDocs";
            this.cmsDestructionRequests.Size = new System.Drawing.Size(193, 26);
            // 
            // miExportToPdf
            // 
            this.miExportToPdf.Image = global::WMSOffice.Properties.Resources.export_pdf;
            this.miExportToPdf.Name = "miExportToPdf";
            this.miExportToPdf.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.miExportToPdf.Size = new System.Drawing.Size(192, 22);
            this.miExportToPdf.Text = "Экспорт в PDF";
            this.miExportToPdf.ToolTipText = "Экспорт выбранных заявок на уничтожение в PDF-файлы";
            // 
            // wh
            // 
            this.wh.DataSetName = "WH";
            this.wh.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // WhExportDestructionRequestsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(973, 506);
            this.Controls.Add(this.tsTools);
            this.Controls.Add(this.dgvDestructionRequest);
            this.Controls.Add(this.btnCancel);
            this.Name = "WhExportDestructionRequestsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Печать актов списания";
            this.Load += new System.EventHandler(this.WhExportDestructionRequestsForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.hExportDestructionRequestsForm_FormClosing);
            this.tsTools.ResumeLayout(false);
            this.tsTools.PerformLayout();
            this.cmsDestructionRequests.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView dgvDestructionRequest;
        private System.Windows.Forms.ToolStrip tsTools;
        private System.Windows.Forms.ContextMenuStrip cmsDestructionRequests;
        private System.Windows.Forms.ToolStripButton btnExportToPdf;
        private System.Windows.Forms.ToolStripMenuItem miExportToPdf;
        private System.Windows.Forms.ToolStripComboBox cmbPrintedFilter;
        private WMSOffice.Data.WH wh;
        private System.Windows.Forms.ToolStripButton btnAcceptanceTransmission;
        private System.Windows.Forms.ToolStripButton btnExportExcel;
        private System.Windows.Forms.ToolStripButton btnConsolidExportToExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnSendWithRegistry;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}