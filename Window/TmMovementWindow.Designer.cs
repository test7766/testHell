namespace WMSOffice.Window
{
    partial class TmMovementWindow
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
            this.toolStripDoc = new System.Windows.Forms.ToolStrip();
            this.btnZonesDirectory = new System.Windows.Forms.ToolStripButton();
            this.btnDocTypesDirectory = new System.Windows.Forms.ToolStripButton();
            this.btnIpDirectory = new System.Windows.Forms.ToolStripButton();
            this.btnDevicesDirectory = new System.Windows.Forms.ToolStripButton();
            this.toolStripDoc.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripDoc
            // 
            this.toolStripDoc.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStripDoc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnZonesDirectory,
            this.btnDocTypesDirectory,
            this.btnIpDirectory,
            this.btnDevicesDirectory});
            this.toolStripDoc.Location = new System.Drawing.Point(0, 40);
            this.toolStripDoc.Name = "toolStripDoc";
            this.toolStripDoc.Size = new System.Drawing.Size(740, 55);
            this.toolStripDoc.TabIndex = 1;
            this.toolStripDoc.Text = "Панель инструментов документа";
            // 
            // btnZonesDirectory
            // 
            this.btnZonesDirectory.Image = global::WMSOffice.Properties.Resources.Desk;
            this.btnZonesDirectory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZonesDirectory.Name = "btnZonesDirectory";
            this.btnZonesDirectory.Size = new System.Drawing.Size(127, 52);
            this.btnZonesDirectory.Text = "Справочник\nплощадок\nпечати";
            this.btnZonesDirectory.Click += new System.EventHandler(this.btnZonesDirectory_Click);
            // 
            // btnDocTypesDirectory
            // 
            this.btnDocTypesDirectory.Image = global::WMSOffice.Properties.Resources.document_plain_new;
            this.btnDocTypesDirectory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDocTypesDirectory.Name = "btnDocTypesDirectory";
            this.btnDocTypesDirectory.Size = new System.Drawing.Size(127, 52);
            this.btnDocTypesDirectory.Text = "Справочник\nтипов\nдокументов";
            this.btnDocTypesDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDocTypesDirectory.Click += new System.EventHandler(this.btnDocTypesDirectory_Click);
            // 
            // btnIpDirectory
            // 
            this.btnIpDirectory.Image = global::WMSOffice.Properties.Resources.Network;
            this.btnIpDirectory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnIpDirectory.Name = "btnIpDirectory";
            this.btnIpDirectory.Size = new System.Drawing.Size(127, 52);
            this.btnIpDirectory.Text = "Справочник\nIP-адресов";
            this.btnIpDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIpDirectory.Click += new System.EventHandler(this.btnIpDirectory_Click);
            // 
            // btnDevicesDirectory
            // 
            this.btnDevicesDirectory.Image = global::WMSOffice.Properties.Resources.document_print;
            this.btnDevicesDirectory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDevicesDirectory.Name = "btnDevicesDirectory";
            this.btnDevicesDirectory.Size = new System.Drawing.Size(127, 52);
            this.btnDevicesDirectory.Text = "Справочник\nустройств";
            this.btnDevicesDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDevicesDirectory.Click += new System.EventHandler(this.btnDevicesDirectory_Click);
            // 
            // TmMovementWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 388);
            this.Controls.Add(this.toolStripDoc);
            this.Name = "TmMovementWindow";
            this.Text = "TmMovementWindow";
            this.Controls.SetChildIndex(this.toolStripDoc, 0);
            this.toolStripDoc.ResumeLayout(false);
            this.toolStripDoc.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripDoc;
        private System.Windows.Forms.ToolStripButton btnZonesDirectory;
        private System.Windows.Forms.ToolStripButton btnDocTypesDirectory;
        private System.Windows.Forms.ToolStripButton btnIpDirectory;
        private System.Windows.Forms.ToolStripButton btnDevicesDirectory;
    }
}