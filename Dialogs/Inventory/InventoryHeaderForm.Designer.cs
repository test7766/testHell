namespace WMSOffice.Dialogs.Inventory
{
    partial class InventoryHeaderForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudInventoryPlanDurationHours = new System.Windows.Forms.NumericUpDown();
            this.dtpInventoryPlanDurationMinutes = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpInventoryDate = new System.Windows.Forms.DateTimePicker();
            this.cmbInventoryType = new System.Windows.Forms.ComboBox();
            this.inventoryTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.inventory = new WMSOffice.Data.Inventory();
            this.inventoryTypesTableAdapter = new WMSOffice.Data.InventoryTableAdapters.InventoryTypesTableAdapter();
            this.pnlButtons.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudInventoryPlanDurationHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventory)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(1260, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1350, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 139);
            this.pnlButtons.Size = new System.Drawing.Size(428, 43);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.nudInventoryPlanDurationHours);
            this.groupBox1.Controls.Add(this.dtpInventoryPlanDurationMinutes);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpInventoryDate);
            this.groupBox1.Controls.Add(this.cmbInventoryType);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(404, 131);
            this.groupBox1.TabIndex = 101;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Укажите:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(288, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "минут";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(200, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "часов";
            // 
            // nudInventoryPlanDurationHours
            // 
            this.nudInventoryPlanDurationHours.Location = new System.Drawing.Point(154, 91);
            this.nudInventoryPlanDurationHours.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudInventoryPlanDurationHours.Name = "nudInventoryPlanDurationHours";
            this.nudInventoryPlanDurationHours.Size = new System.Drawing.Size(40, 20);
            this.nudInventoryPlanDurationHours.TabIndex = 6;
            // 
            // dtpInventoryPlanDurationMinutes
            // 
            this.dtpInventoryPlanDurationMinutes.CustomFormat = "mm";
            this.dtpInventoryPlanDurationMinutes.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpInventoryPlanDurationMinutes.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInventoryPlanDurationMinutes.Location = new System.Drawing.Point(242, 91);
            this.dtpInventoryPlanDurationMinutes.Name = "dtpInventoryPlanDurationMinutes";
            this.dtpInventoryPlanDurationMinutes.ShowUpDown = true;
            this.dtpInventoryPlanDurationMinutes.Size = new System.Drawing.Size(40, 20);
            this.dtpInventoryPlanDurationMinutes.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(16, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "План. длительность:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(16, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Тип инвентаризации:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(16, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Дата инвентаризации:\r\n";
            // 
            // dtpInventoryDate
            // 
            this.dtpInventoryDate.CustomFormat = "dd / MM / yyyy";
            this.dtpInventoryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtpInventoryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInventoryDate.Location = new System.Drawing.Point(154, 29);
            this.dtpInventoryDate.Name = "dtpInventoryDate";
            this.dtpInventoryDate.Size = new System.Drawing.Size(114, 20);
            this.dtpInventoryDate.TabIndex = 1;
            // 
            // cmbInventoryType
            // 
            this.cmbInventoryType.DataSource = this.inventoryTypesBindingSource;
            this.cmbInventoryType.DisplayMember = "TypeName";
            this.cmbInventoryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInventoryType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbInventoryType.FormattingEnabled = true;
            this.cmbInventoryType.Location = new System.Drawing.Point(154, 60);
            this.cmbInventoryType.Name = "cmbInventoryType";
            this.cmbInventoryType.Size = new System.Drawing.Size(228, 21);
            this.cmbInventoryType.TabIndex = 0;
            this.cmbInventoryType.ValueMember = "TYPE_ID";
            // 
            // inventoryTypesBindingSource
            // 
            this.inventoryTypesBindingSource.DataMember = "InventoryTypes";
            this.inventoryTypesBindingSource.DataSource = this.inventory;
            // 
            // inventory
            // 
            this.inventory.DataSetName = "Inventory";
            this.inventory.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // inventoryTypesTableAdapter
            // 
            this.inventoryTypesTableAdapter.ClearBeforeFill = true;
            // 
            // InventoryHeaderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 182);
            this.Controls.Add(this.groupBox1);
            this.Name = "InventoryHeaderForm";
            this.Text = "Планирование инвентаризации - шаг 1";
            this.Load += new System.EventHandler(this.InventoryHeaderForm_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudInventoryPlanDurationHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpInventoryDate;
        private System.Windows.Forms.ComboBox cmbInventoryType;
        private System.Windows.Forms.BindingSource inventoryTypesBindingSource;
        private WMSOffice.Data.Inventory inventory;
        private WMSOffice.Data.InventoryTableAdapters.InventoryTypesTableAdapter inventoryTypesTableAdapter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpInventoryPlanDurationMinutes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudInventoryPlanDurationHours;
        private System.Windows.Forms.Label label5;
    }
}