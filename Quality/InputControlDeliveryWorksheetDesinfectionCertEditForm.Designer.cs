namespace WMSOffice.Dialogs.Quality
{
    partial class InputControlDeliveryWorksheetDesinfectionCertEditForm 
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
            this.pnlContent = new System.Windows.Forms.Panel();
            this.tcDocs = new System.Windows.Forms.TabControl();
            this.tpDocTemplate = new System.Windows.Forms.TabPage();
            this.crvDocTemplate = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tpDocCopy = new System.Windows.Forms.TabPage();
            this.ivcDocCopy = new WMSOffice.Controls.Custom.ImageViewerControl();
            this.quality = new WMSOffice.Data.Quality();
            this.pnlButtons.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.tcDocs.SuspendLayout();
            this.tpDocTemplate.SuspendLayout();
            this.tpDocCopy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(2125, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(2215, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 628);
            this.pnlButtons.Size = new System.Drawing.Size(594, 43);
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContent.Controls.Add(this.tcDocs);
            this.pnlContent.Location = new System.Drawing.Point(0, 2);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(594, 620);
            this.pnlContent.TabIndex = 102;
            // 
            // tcDocs
            // 
            this.tcDocs.Controls.Add(this.tpDocTemplate);
            this.tcDocs.Controls.Add(this.tpDocCopy);
            this.tcDocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcDocs.Location = new System.Drawing.Point(0, 0);
            this.tcDocs.Name = "tcDocs";
            this.tcDocs.SelectedIndex = 0;
            this.tcDocs.Size = new System.Drawing.Size(594, 620);
            this.tcDocs.TabIndex = 2;
            // 
            // tpDocTemplate
            // 
            this.tpDocTemplate.Controls.Add(this.crvDocTemplate);
            this.tpDocTemplate.Location = new System.Drawing.Point(4, 22);
            this.tpDocTemplate.Name = "tpDocTemplate";
            this.tpDocTemplate.Padding = new System.Windows.Forms.Padding(3);
            this.tpDocTemplate.Size = new System.Drawing.Size(586, 594);
            this.tpDocTemplate.TabIndex = 0;
            this.tpDocTemplate.Text = "Шаблон";
            this.tpDocTemplate.UseVisualStyleBackColor = true;
            // 
            // crvDocTemplate
            // 
            this.crvDocTemplate.ActiveViewIndex = -1;
            this.crvDocTemplate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvDocTemplate.DisplayGroupTree = false;
            this.crvDocTemplate.DisplayStatusBar = false;
            this.crvDocTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvDocTemplate.Location = new System.Drawing.Point(3, 3);
            this.crvDocTemplate.Name = "crvDocTemplate";
            this.crvDocTemplate.SelectionFormula = "";
            this.crvDocTemplate.ShowCloseButton = false;
            this.crvDocTemplate.ShowGotoPageButton = false;
            this.crvDocTemplate.ShowGroupTreeButton = false;
            this.crvDocTemplate.ShowPageNavigateButtons = false;
            this.crvDocTemplate.ShowRefreshButton = false;
            this.crvDocTemplate.ShowTextSearchButton = false;
            this.crvDocTemplate.Size = new System.Drawing.Size(580, 588);
            this.crvDocTemplate.TabIndex = 1;
            this.crvDocTemplate.ViewTimeSelectionFormula = "";
            // 
            // tpDocCopy
            // 
            this.tpDocCopy.Controls.Add(this.ivcDocCopy);
            this.tpDocCopy.Location = new System.Drawing.Point(4, 22);
            this.tpDocCopy.Name = "tpDocCopy";
            this.tpDocCopy.Padding = new System.Windows.Forms.Padding(3);
            this.tpDocCopy.Size = new System.Drawing.Size(586, 594);
            this.tpDocCopy.TabIndex = 1;
            this.tpDocCopy.Text = "Скан-копия";
            this.tpDocCopy.UseVisualStyleBackColor = true;
            // 
            // ivcDocCopy
            // 
            this.ivcDocCopy.AutoZoomActivated = true;
            this.ivcDocCopy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ivcDocCopy.CurrentItem = null;
            this.ivcDocCopy.CurrentZoomFactor = 1;
            this.ivcDocCopy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ivcDocCopy.Location = new System.Drawing.Point(3, 3);
            this.ivcDocCopy.Name = "ivcDocCopy";
            this.ivcDocCopy.Size = new System.Drawing.Size(580, 588);
            this.ivcDocCopy.TabIndex = 1;
            // 
            // quality
            // 
            this.quality.DataSetName = "Quality";
            this.quality.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // InputControlDeliveryWorksheetDesinfectionCertEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 671);
            this.Controls.Add(this.pnlContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "InputControlDeliveryWorksheetDesinfectionCertEditForm";
            this.Text = "Паспорт дезинфекции";
            this.SizeChanged += new System.EventHandler(this.InputControlDeliveryWorksheetDesinfectionCertEditForm_SizeChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InputControlDeliveryWorksheetUnloadDateEditForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.tcDocs.ResumeLayout(false);
            this.tpDocTemplate.ResumeLayout(false);
            this.tpDocCopy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvDocTemplate;
        private System.Windows.Forms.TabControl tcDocs;
        private System.Windows.Forms.TabPage tpDocTemplate;
        private System.Windows.Forms.TabPage tpDocCopy;
        private WMSOffice.Controls.Custom.ImageViewerControl ivcDocCopy;
        private WMSOffice.Data.Quality quality;

    }
}