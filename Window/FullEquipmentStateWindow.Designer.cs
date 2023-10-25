using System;
using System.Collections.Generic;
using System.Text;

namespace WMSOffice.Window
{
    partial class FullEquipmentStateWindow
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
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.sbRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.sbExport = new System.Windows.Forms.ToolStripButton();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.xdgvItems = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.tsMain.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbRefresh,
            this.toolStripSeparator1,
            this.sbExport});
            this.tsMain.Location = new System.Drawing.Point(0, 40);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(823, 55);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
            // 
            // sbRefresh
            // 
            this.sbRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.sbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbRefresh.Name = "sbRefresh";
            this.sbRefresh.Size = new System.Drawing.Size(113, 52);
            this.sbRefresh.Text = "Обновить";
            this.sbRefresh.Click += new System.EventHandler(this.sbRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // sbExport
            // 
            this.sbExport.Image = global::WMSOffice.Properties.Resources.Excel;
            this.sbExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbExport.Name = "sbExport";
            this.sbExport.Size = new System.Drawing.Size(104, 52);
            this.sbExport.Text = "Экспорт";
            this.sbExport.Click += new System.EventHandler(this.sbExport_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.xdgvItems);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 95);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(823, 403);
            this.pnlContent.TabIndex = 2;
            // 
            // xdgvItems
            // 
            this.xdgvItems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvItems.LargeAmountOfData = false;
            this.xdgvItems.Location = new System.Drawing.Point(0, 0);
            this.xdgvItems.Name = "xdgvItems";
            this.xdgvItems.RowHeadersVisible = false;
            this.xdgvItems.Size = new System.Drawing.Size(823, 403);
            this.xdgvItems.TabIndex = 102;
            this.xdgvItems.UserID = ((long)(0));
            // 
            // FullEquipmentStateWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(823, 498);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.tsMain);
            this.Name = "FullEquipmentStateWindow";
            this.Load += new System.EventHandler(this.FullEquipmentStateWindow_Load);
            this.Controls.SetChildIndex(this.tsMain, 0);
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton sbRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton sbExport;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.ToolStrip tsMain;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvItems;
    }
}
