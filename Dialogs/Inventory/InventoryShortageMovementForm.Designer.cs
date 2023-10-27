namespace WMSOffice.Dialogs.Inventory
{
    partial class InventoryShortageMovementForm
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.sbExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.xdgvShortage = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.pnlButtons.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(1190, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1280, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 418);
            this.pnlButtons.Size = new System.Drawing.Size(1382, 43);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbExportToExcel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1382, 25);
            this.toolStrip1.TabIndex = 101;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // sbExportToExcel
            // 
            this.sbExportToExcel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.sbExportToExcel.Image = global::WMSOffice.Properties.Resources.Excel;
            this.sbExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbExportToExcel.Name = "sbExportToExcel";
            this.sbExportToExcel.Size = new System.Drawing.Size(110, 22);
            this.sbExportToExcel.Text = "Экспорт в Excel";
            this.sbExportToExcel.Click += new System.EventHandler(this.sbExportToExcel_Click);
            // 
            // xdgvShortage
            // 
            this.xdgvShortage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xdgvShortage.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.xdgvShortage.Location = new System.Drawing.Point(0, 28);
            this.xdgvShortage.Name = "xdgvShortage";
            this.xdgvShortage.Size = new System.Drawing.Size(1382, 384);
            this.xdgvShortage.TabIndex = 102;
            this.xdgvShortage.UserID = ((long)(0));
            // 
            // InventoryShortageMovementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 461);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.xdgvShortage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "InventoryShortageMovementForm";
            this.Text = "Перемещение итоговых недостач на соответсвующие полки";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InventoryShortageMovementForm_FormClosing);
            this.Controls.SetChildIndex(this.xdgvShortage, 0);
            this.Controls.SetChildIndex(this.toolStrip1, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton sbExportToExcel;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvShortage;
    }
}