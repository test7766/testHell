namespace WMSOffice.Dialogs.Inventory
{
    partial class InventoryResourcePlanningAddTeamForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudTeamsQuantity = new System.Windows.Forms.NumericUpDown();
            this.cmbTeamType = new System.Windows.Forms.ComboBox();
            this.inventory = new WMSOffice.Data.Inventory();
            this.inventoryTeamTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.inventoryTeamTypesTableAdapter = new WMSOffice.Data.InventoryTableAdapters.InventoryTeamTypesTableAdapter();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTeamsQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryTeamTypesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(363, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(453, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 79);
            this.pnlButtons.Size = new System.Drawing.Size(412, 43);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 101;
            this.label1.Text = "Тип бригады:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 102;
            this.label2.Text = "Количество бригад:";
            // 
            // nudTeamsQuantity
            // 
            this.nudTeamsQuantity.Location = new System.Drawing.Point(131, 44);
            this.nudTeamsQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTeamsQuantity.Name = "nudTeamsQuantity";
            this.nudTeamsQuantity.Size = new System.Drawing.Size(51, 20);
            this.nudTeamsQuantity.TabIndex = 103;
            this.nudTeamsQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cmbTeamType
            // 
            this.cmbTeamType.DataSource = this.inventoryTeamTypesBindingSource;
            this.cmbTeamType.DisplayMember = "TeamName";
            this.cmbTeamType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTeamType.FormattingEnabled = true;
            this.cmbTeamType.Location = new System.Drawing.Point(131, 13);
            this.cmbTeamType.Name = "cmbTeamType";
            this.cmbTeamType.Size = new System.Drawing.Size(269, 21);
            this.cmbTeamType.TabIndex = 104;
            this.cmbTeamType.ValueMember = "Team_ID";
            // 
            // inventory
            // 
            this.inventory.DataSetName = "Inventory";
            this.inventory.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // inventoryTeamTypesBindingSource
            // 
            this.inventoryTeamTypesBindingSource.DataMember = "InventoryTeamTypes";
            this.inventoryTeamTypesBindingSource.DataSource = this.inventory;
            // 
            // inventoryTeamTypesTableAdapter
            // 
            this.inventoryTeamTypesTableAdapter.ClearBeforeFill = true;
            // 
            // InventoryResourcePlanningAddTeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 122);
            this.Controls.Add(this.cmbTeamType);
            this.Controls.Add(this.nudTeamsQuantity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "InventoryResourcePlanningAddTeam";
            this.Text = "Создание новой бригады";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InventoryResourcePlanningAddTeam_FormClosing);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.nudTeamsQuantity, 0);
            this.Controls.SetChildIndex(this.cmbTeamType, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudTeamsQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryTeamTypesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudTeamsQuantity;
        private System.Windows.Forms.ComboBox cmbTeamType;
        private System.Windows.Forms.BindingSource inventoryTeamTypesBindingSource;
        private WMSOffice.Data.Inventory inventory;
        private WMSOffice.Data.InventoryTableAdapters.InventoryTeamTypesTableAdapter inventoryTeamTypesTableAdapter;
    }
}