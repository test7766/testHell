namespace WMSOffice.Dialogs.WH
{
    partial class PrintWriteOffActsForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.tsTools = new System.Windows.Forms.ToolStrip();
            this.btnPreview = new System.Windows.Forms.ToolStripButton();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.lblPrinter = new System.Windows.Forms.ToolStripLabel();
            this.cmbPrinters = new System.Windows.Forms.ToolStripComboBox();
            this.btnExtendedReport = new System.Windows.Forms.ToolStripButton();
            this.btnPrintPackage = new System.Windows.Forms.ToolStripButton();
            this.cmsPrintDocs = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.miPrintDocs = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvPrintDocs = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.tsTools.SuspendLayout();
            this.cmsPrintDocs.SuspendLayout();
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
            // tsTools
            // 
            this.tsTools.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPreview,
            this.btnPrint,
            this.lblPrinter,
            this.cmbPrinters,
            this.btnExtendedReport,
            this.btnPrintPackage});
            this.tsTools.Location = new System.Drawing.Point(0, 0);
            this.tsTools.Name = "tsTools";
            this.tsTools.Size = new System.Drawing.Size(973, 39);
            this.tsTools.TabIndex = 1;
            this.tsTools.Text = "toolStrip1";
            // 
            // btnPreview
            // 
            this.btnPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPreview.Image = global::WMSOffice.Properties.Resources.document_print_preview;
            this.btnPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(36, 36);
            this.btnPreview.Text = "toolStripButton1";
            this.btnPreview.ToolTipText = "Просмотреть выбранный документ";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrint.Image = global::WMSOffice.Properties.Resources.document_print;
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(36, 36);
            this.btnPrint.Text = "toolStripButton2";
            this.btnPrint.ToolTipText = "Печать выбранных документов на принтере";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lblPrinter
            // 
            this.lblPrinter.Name = "lblPrinter";
            this.lblPrinter.Size = new System.Drawing.Size(61, 36);
            this.lblPrinter.Text = "Принтер: ";
            // 
            // cmbPrinters
            // 
            this.cmbPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinters.Name = "cmbPrinters";
            this.cmbPrinters.Size = new System.Drawing.Size(200, 39);
            // 
            // btnExtendedReport
            // 
            this.btnExtendedReport.Image = global::WMSOffice.Properties.Resources.document_print_preview;
            this.btnExtendedReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExtendedReport.Name = "btnExtendedReport";
            this.btnExtendedReport.Size = new System.Drawing.Size(156, 36);
            this.btnExtendedReport.Text = "Расширенный отчет";
            this.btnExtendedReport.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnPrintPackage
            // 
            this.btnPrintPackage.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnPrintPackage.Image = global::WMSOffice.Properties.Resources.print;
            this.btnPrintPackage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintPackage.Name = "btnPrintPackage";
            this.btnPrintPackage.Size = new System.Drawing.Size(134, 36);
            this.btnPrintPackage.Text = "Пакетная печать";
            this.btnPrintPackage.Click += new System.EventHandler(this.btnPrintPackage_Click);
            // 
            // cmsPrintDocs
            // 
            this.cmsPrintDocs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miPreview,
            this.miPrintDocs});
            this.cmsPrintDocs.Name = "cmsPrintDocs";
            this.cmsPrintDocs.Size = new System.Drawing.Size(248, 48);
            // 
            // miPreview
            // 
            this.miPreview.Image = global::WMSOffice.Properties.Resources.document_print_preview;
            this.miPreview.Name = "miPreview";
            this.miPreview.Size = new System.Drawing.Size(247, 22);
            this.miPreview.Text = "Просмотреть документ";
            // 
            // miPrintDocs
            // 
            this.miPrintDocs.Image = global::WMSOffice.Properties.Resources.document_print;
            this.miPrintDocs.Name = "miPrintDocs";
            this.miPrintDocs.Size = new System.Drawing.Size(247, 22);
            this.miPrintDocs.Text = "Печать выбранных документов";
            // 
            // dgvPrintDocs
            // 
            this.dgvPrintDocs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPrintDocs.BackColor = System.Drawing.SystemColors.Control;
            this.dgvPrintDocs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.dgvPrintDocs.LargeAmountOfData = false;
            this.dgvPrintDocs.Location = new System.Drawing.Point(0, 42);
            this.dgvPrintDocs.Name = "dgvPrintDocs";
            this.dgvPrintDocs.RowHeadersVisible = false;
            this.dgvPrintDocs.Size = new System.Drawing.Size(973, 413);
            this.dgvPrintDocs.TabIndex = 4;
            this.dgvPrintDocs.UserID = ((long)(0));
            // 
            // PrintWriteOffActsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(973, 506);
            this.Controls.Add(this.tsTools);
            this.Controls.Add(this.dgvPrintDocs);
            this.Controls.Add(this.btnCancel);
            this.Name = "PrintWriteOffActsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Печать актов списания";
            this.Load += new System.EventHandler(this.PrintWriteOffActsForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PrintWriteOffActsForm_FormClosing);
            this.tsTools.ResumeLayout(false);
            this.tsTools.PerformLayout();
            this.cmsPrintDocs.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ToolStrip tsTools;
        private System.Windows.Forms.ToolStripLabel lblPrinter;
        private System.Windows.Forms.ToolStripComboBox cmbPrinters;
        private System.Windows.Forms.ToolStripButton btnPreview;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.ContextMenuStrip cmsPrintDocs;
        private System.Windows.Forms.ToolStripMenuItem miPreview;
        private System.Windows.Forms.ToolStripMenuItem miPrintDocs;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView dgvPrintDocs;
        private System.Windows.Forms.ToolStripButton btnExtendedReport;
        private System.Windows.Forms.ToolStripButton btnPrintPackage;
    }
}