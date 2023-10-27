namespace WMSOffice.Dialogs.Inventory
{
    partial class LinkZoneToTeamForm
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
            this.cmbZones = new System.Windows.Forms.ComboBox();
            this.inventoryTeamZonesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.inventory = new WMSOffice.Data.Inventory();
            this.inventoryTeamZonesTableAdapter = new WMSOffice.Data.InventoryTableAdapters.InventoryTeamZonesTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryTeamZonesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventory)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(210, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(300, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 62);
            this.pnlButtons.Size = new System.Drawing.Size(339, 43);
            // 
            // cmbZones
            // 
            this.cmbZones.DataSource = this.inventoryTeamZonesBindingSource;
            this.cmbZones.DisplayMember = "ZoneName";
            this.cmbZones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbZones.FormattingEnabled = true;
            this.cmbZones.Location = new System.Drawing.Point(53, 22);
            this.cmbZones.Name = "cmbZones";
            this.cmbZones.Size = new System.Drawing.Size(267, 21);
            this.cmbZones.TabIndex = 101;
            this.cmbZones.ValueMember = "Zone_ID";
            // 
            // inventoryTeamZonesBindingSource
            // 
            this.inventoryTeamZonesBindingSource.DataMember = "InventoryTeamZones";
            this.inventoryTeamZonesBindingSource.DataSource = this.inventory;
            // 
            // inventory
            // 
            this.inventory.DataSetName = "Inventory";
            this.inventory.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // inventoryTeamZonesTableAdapter
            // 
            this.inventoryTeamZonesTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 102;
            this.label1.Text = "Зона:";
            // 
            // LinkZoneToTeamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 105);
            this.Controls.Add(this.cmbZones);
            this.Controls.Add(this.label1);
            this.Name = "LinkZoneToTeamForm";
            this.Text = "Привязка зоны к бригаде";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LinkZoneToTeamForm_FormClosing);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmbZones, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.inventoryTeamZonesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbZones;
        private System.Windows.Forms.BindingSource inventoryTeamZonesBindingSource;
        private WMSOffice.Data.Inventory inventory;
        private WMSOffice.Data.InventoryTableAdapters.InventoryTeamZonesTableAdapter inventoryTeamZonesTableAdapter;
        private System.Windows.Forms.Label label1;
    }
}