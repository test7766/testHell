namespace WMSOffice.Dialogs.Quality
{
    partial class QualityGLSActRemainsForm
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
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.pnlWarehouseRemainsHost = new System.Windows.Forms.Panel();
            this.xdgvWarehouseRemains = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.pnlWarehouseRemains = new System.Windows.Forms.Panel();
            this.lblWarehouseRemains = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlDebtorRemainsHost = new System.Windows.Forms.Panel();
            this.xdgvDebtorRemains = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.pnlDebtorRemains = new System.Windows.Forms.Panel();
            this.lblDebtorRemains = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.pnlWarehouseRemainsHost.SuspendLayout();
            this.pnlWarehouseRemains.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlDebtorRemainsHost.SuspendLayout();
            this.pnlDebtorRemains.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(3605, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(3695, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 732);
            this.pnlButtons.Size = new System.Drawing.Size(1494, 43);
            // 
            // scMain
            // 
            this.scMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scMain.Location = new System.Drawing.Point(0, 0);
            this.scMain.Name = "scMain";
            this.scMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.pnlWarehouseRemainsHost);
            this.scMain.Panel1.Controls.Add(this.pnlWarehouseRemains);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.panel2);
            this.scMain.Panel2.Controls.Add(this.pnlDebtorRemains);
            this.scMain.Size = new System.Drawing.Size(1494, 726);
            this.scMain.SplitterDistance = 355;
            this.scMain.TabIndex = 101;
            // 
            // pnlWarehouseRemainsHost
            // 
            this.pnlWarehouseRemainsHost.Controls.Add(this.xdgvWarehouseRemains);
            this.pnlWarehouseRemainsHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWarehouseRemainsHost.Location = new System.Drawing.Point(0, 24);
            this.pnlWarehouseRemainsHost.Name = "pnlWarehouseRemainsHost";
            this.pnlWarehouseRemainsHost.Size = new System.Drawing.Size(1494, 331);
            this.pnlWarehouseRemainsHost.TabIndex = 3;
            // 
            // xdgvWarehouseRemains
            // 
            this.xdgvWarehouseRemains.AllowSort = true;
            this.xdgvWarehouseRemains.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvWarehouseRemains.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvWarehouseRemains.LargeAmountOfData = false;
            this.xdgvWarehouseRemains.Location = new System.Drawing.Point(0, 0);
            this.xdgvWarehouseRemains.Name = "xdgvWarehouseRemains";
            this.xdgvWarehouseRemains.RowHeadersVisible = false;
            this.xdgvWarehouseRemains.Size = new System.Drawing.Size(1494, 331);
            this.xdgvWarehouseRemains.TabIndex = 0;
            this.xdgvWarehouseRemains.UserID = ((long)(0));
            // 
            // pnlWarehouseRemains
            // 
            this.pnlWarehouseRemains.BackColor = System.Drawing.Color.LightSkyBlue;
            this.pnlWarehouseRemains.Controls.Add(this.lblWarehouseRemains);
            this.pnlWarehouseRemains.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlWarehouseRemains.Location = new System.Drawing.Point(0, 0);
            this.pnlWarehouseRemains.Name = "pnlWarehouseRemains";
            this.pnlWarehouseRemains.Size = new System.Drawing.Size(1494, 24);
            this.pnlWarehouseRemains.TabIndex = 2;
            // 
            // lblWarehouseRemains
            // 
            this.lblWarehouseRemains.AutoSize = true;
            this.lblWarehouseRemains.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWarehouseRemains.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblWarehouseRemains.Location = new System.Drawing.Point(0, 0);
            this.lblWarehouseRemains.Name = "lblWarehouseRemains";
            this.lblWarehouseRemains.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.lblWarehouseRemains.Size = new System.Drawing.Size(157, 19);
            this.lblWarehouseRemains.TabIndex = 0;
            this.lblWarehouseRemains.Text = "Залишки на складах";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pnlDebtorRemainsHost);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1494, 343);
            this.panel2.TabIndex = 5;
            // 
            // pnlDebtorRemainsHost
            // 
            this.pnlDebtorRemainsHost.Controls.Add(this.xdgvDebtorRemains);
            this.pnlDebtorRemainsHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDebtorRemainsHost.Location = new System.Drawing.Point(0, 0);
            this.pnlDebtorRemainsHost.Name = "pnlDebtorRemainsHost";
            this.pnlDebtorRemainsHost.Size = new System.Drawing.Size(1494, 343);
            this.pnlDebtorRemainsHost.TabIndex = 2;
            // 
            // xdgvDebtorRemains
            // 
            this.xdgvDebtorRemains.AllowSort = true;
            this.xdgvDebtorRemains.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvDebtorRemains.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvDebtorRemains.LargeAmountOfData = false;
            this.xdgvDebtorRemains.Location = new System.Drawing.Point(0, 0);
            this.xdgvDebtorRemains.Name = "xdgvDebtorRemains";
            this.xdgvDebtorRemains.RowHeadersVisible = false;
            this.xdgvDebtorRemains.Size = new System.Drawing.Size(1494, 343);
            this.xdgvDebtorRemains.TabIndex = 0;
            this.xdgvDebtorRemains.UserID = ((long)(0));
            // 
            // pnlDebtorRemains
            // 
            this.pnlDebtorRemains.BackColor = System.Drawing.Color.LightSkyBlue;
            this.pnlDebtorRemains.Controls.Add(this.lblDebtorRemains);
            this.pnlDebtorRemains.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDebtorRemains.Location = new System.Drawing.Point(0, 0);
            this.pnlDebtorRemains.Name = "pnlDebtorRemains";
            this.pnlDebtorRemains.Size = new System.Drawing.Size(1494, 24);
            this.pnlDebtorRemains.TabIndex = 4;
            // 
            // lblDebtorRemains
            // 
            this.lblDebtorRemains.AutoSize = true;
            this.lblDebtorRemains.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDebtorRemains.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDebtorRemains.Location = new System.Drawing.Point(0, 0);
            this.lblDebtorRemains.Name = "lblDebtorRemains";
            this.lblDebtorRemains.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.lblDebtorRemains.Size = new System.Drawing.Size(265, 19);
            this.lblDebtorRemains.TabIndex = 0;
            this.lblDebtorRemains.Text = "Очікуваний залишок (від клієнтів)";
            // 
            // QualityGLSActRemainsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1494, 775);
            this.Controls.Add(this.scMain);
            this.MaximizeBox = true;
            this.Name = "QualityGLSActRemainsForm";
            this.Text = "Залишки";
            this.Controls.SetChildIndex(this.scMain, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            this.scMain.ResumeLayout(false);
            this.pnlWarehouseRemainsHost.ResumeLayout(false);
            this.pnlWarehouseRemains.ResumeLayout(false);
            this.pnlWarehouseRemains.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.pnlDebtorRemainsHost.ResumeLayout(false);
            this.pnlDebtorRemains.ResumeLayout(false);
            this.pnlDebtorRemains.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.Panel pnlWarehouseRemainsHost;
        private System.Windows.Forms.Panel pnlWarehouseRemains;
        private System.Windows.Forms.Label lblWarehouseRemains;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlDebtorRemains;
        private System.Windows.Forms.Label lblDebtorRemains;
        private System.Windows.Forms.Panel pnlDebtorRemainsHost;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvDebtorRemains;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvWarehouseRemains;
    }
}