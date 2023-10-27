namespace WMSOffice.Dialogs.ColdChain
{
    partial class ColdEquipmentRegistrationForm
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
            this.tbEquipmentName = new System.Windows.Forms.TextBox();
            this.lblEquipmentName = new System.Windows.Forms.Label();
            this.gbMeasurementsTools = new System.Windows.Forms.GroupBox();
            this.lblMeasurements = new System.Windows.Forms.Label();
            this.pnlMeasurements = new System.Windows.Forms.Panel();
            this.tbHeight = new System.Windows.Forms.TextBox();
            this.equipmentMeasurementsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.coldChain = new WMSOffice.Data.ColdChain();
            this.tbWidth = new System.Windows.Forms.TextBox();
            this.tbDepth = new System.Windows.Forms.TextBox();
            this.lblHeight = new System.Windows.Forms.Label();
            this.lblDepth = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.pbEquipment = new System.Windows.Forms.PictureBox();
            this.cbMeasurements = new System.Windows.Forms.ComboBox();
            this.cbEquipmentTypes = new System.Windows.Forms.ComboBox();
            this.equipmentTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblEquipmentType = new System.Windows.Forms.Label();
            this.equipmentMeasurementsTableAdapter = new WMSOffice.Data.ColdChainTableAdapters.EquipmentMeasurementsTableAdapter();
            this.equipmentTypesTableAdapter = new WMSOffice.Data.ColdChainTableAdapters.EquipmentTypesTableAdapter();
            this.lblBranch = new System.Windows.Forms.Label();
            this.cbBranches = new System.Windows.Forms.ComboBox();
            this.branchesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.branchesTableAdapter = new WMSOffice.Data.ColdChainTableAdapters.BranchesTableAdapter();
            this.lblDepartmentNotation = new System.Windows.Forms.Label();
            this.tbDepartmentNotation = new System.Windows.Forms.TextBox();
            this.lblSerialNumber = new System.Windows.Forms.Label();
            this.tbSerialNumber = new System.Windows.Forms.TextBox();
            this.pnlButtons.SuspendLayout();
            this.gbMeasurementsTools.SuspendLayout();
            this.pnlMeasurements.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentMeasurementsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coldChain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEquipment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.branchesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(241, 8);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(331, 8);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 318);
            this.pnlButtons.Size = new System.Drawing.Size(384, 43);
            this.pnlButtons.TabIndex = 11;
            // 
            // tbEquipmentName
            // 
            this.tbEquipmentName.Location = new System.Drawing.Point(98, 8);
            this.tbEquipmentName.Name = "tbEquipmentName";
            this.tbEquipmentName.Size = new System.Drawing.Size(264, 20);
            this.tbEquipmentName.TabIndex = 1;
            // 
            // lblEquipmentName
            // 
            this.lblEquipmentName.AutoSize = true;
            this.lblEquipmentName.Location = new System.Drawing.Point(12, 12);
            this.lblEquipmentName.Name = "lblEquipmentName";
            this.lblEquipmentName.Size = new System.Drawing.Size(60, 13);
            this.lblEquipmentName.TabIndex = 0;
            this.lblEquipmentName.Text = "Название:";
            // 
            // gbMeasurementsTools
            // 
            this.gbMeasurementsTools.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbMeasurementsTools.Controls.Add(this.lblMeasurements);
            this.gbMeasurementsTools.Controls.Add(this.pnlMeasurements);
            this.gbMeasurementsTools.Controls.Add(this.pbEquipment);
            this.gbMeasurementsTools.Controls.Add(this.cbMeasurements);
            this.gbMeasurementsTools.Location = new System.Drawing.Point(12, 172);
            this.gbMeasurementsTools.Name = "gbMeasurementsTools";
            this.gbMeasurementsTools.Size = new System.Drawing.Size(348, 140);
            this.gbMeasurementsTools.TabIndex = 10;
            this.gbMeasurementsTools.TabStop = false;
            // 
            // lblMeasurements
            // 
            this.lblMeasurements.Location = new System.Drawing.Point(15, 11);
            this.lblMeasurements.Name = "lblMeasurements";
            this.lblMeasurements.Size = new System.Drawing.Size(82, 30);
            this.lblMeasurements.TabIndex = 0;
            this.lblMeasurements.Text = "Внутренние размеры (мм):";
            // 
            // pnlMeasurements
            // 
            this.pnlMeasurements.Controls.Add(this.tbHeight);
            this.pnlMeasurements.Controls.Add(this.tbWidth);
            this.pnlMeasurements.Controls.Add(this.tbDepth);
            this.pnlMeasurements.Controls.Add(this.lblHeight);
            this.pnlMeasurements.Controls.Add(this.lblDepth);
            this.pnlMeasurements.Controls.Add(this.lblWidth);
            this.pnlMeasurements.Location = new System.Drawing.Point(104, 47);
            this.pnlMeasurements.Name = "pnlMeasurements";
            this.pnlMeasurements.Size = new System.Drawing.Size(238, 88);
            this.pnlMeasurements.TabIndex = 2;
            // 
            // tbHeight
            // 
            this.tbHeight.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.equipmentMeasurementsBindingSource, "Height", true));
            this.tbHeight.Location = new System.Drawing.Point(66, 5);
            this.tbHeight.Name = "tbHeight";
            this.tbHeight.Size = new System.Drawing.Size(140, 20);
            this.tbHeight.TabIndex = 1;
            this.tbHeight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbHeight_KeyDown);
            this.tbHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbMeasurementItem_KeyPress);
            this.tbHeight.Validating += new System.ComponentModel.CancelEventHandler(this.tbMeasurementItem_Validating);
            // 
            // equipmentMeasurementsBindingSource
            // 
            this.equipmentMeasurementsBindingSource.DataMember = "EquipmentMeasurements";
            this.equipmentMeasurementsBindingSource.DataSource = this.coldChain;
            // 
            // coldChain
            // 
            this.coldChain.DataSetName = "ColdChain";
            this.coldChain.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbWidth
            // 
            this.tbWidth.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.equipmentMeasurementsBindingSource, "Width", true));
            this.tbWidth.Location = new System.Drawing.Point(66, 33);
            this.tbWidth.Name = "tbWidth";
            this.tbWidth.Size = new System.Drawing.Size(140, 20);
            this.tbWidth.TabIndex = 3;
            this.tbWidth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbWidth_KeyDown);
            this.tbWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbMeasurementItem_KeyPress);
            this.tbWidth.Validating += new System.ComponentModel.CancelEventHandler(this.tbMeasurementItem_Validating);
            // 
            // tbDepth
            // 
            this.tbDepth.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.equipmentMeasurementsBindingSource, "Depth", true));
            this.tbDepth.Location = new System.Drawing.Point(66, 61);
            this.tbDepth.Name = "tbDepth";
            this.tbDepth.Size = new System.Drawing.Size(140, 20);
            this.tbDepth.TabIndex = 5;
            this.tbDepth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbDepth_KeyDown);
            this.tbDepth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbMeasurementItem_KeyPress);
            this.tbDepth.Validating += new System.ComponentModel.CancelEventHandler(this.tbMeasurementItem_Validating);
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(9, 8);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(48, 13);
            this.lblHeight.TabIndex = 0;
            this.lblHeight.Text = "Высота:";
            // 
            // lblDepth
            // 
            this.lblDepth.AutoSize = true;
            this.lblDepth.Location = new System.Drawing.Point(9, 64);
            this.lblDepth.Name = "lblDepth";
            this.lblDepth.Size = new System.Drawing.Size(51, 13);
            this.lblDepth.TabIndex = 4;
            this.lblDepth.Text = "Глубина:";
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(9, 36);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(49, 13);
            this.lblWidth.TabIndex = 2;
            this.lblWidth.Text = "Ширина:";
            // 
            // pbEquipment
            // 
            this.pbEquipment.Image = global::WMSOffice.Properties.Resources.cold_chain_icon_75;
            this.pbEquipment.Location = new System.Drawing.Point(18, 47);
            this.pbEquipment.Name = "pbEquipment";
            this.pbEquipment.Size = new System.Drawing.Size(75, 75);
            this.pbEquipment.TabIndex = 112;
            this.pbEquipment.TabStop = false;
            // 
            // cbMeasurements
            // 
            this.cbMeasurements.DataSource = this.equipmentMeasurementsBindingSource;
            this.cbMeasurements.DisplayMember = "Measurements";
            this.cbMeasurements.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMeasurements.FormattingEnabled = true;
            this.cbMeasurements.Location = new System.Drawing.Point(116, 16);
            this.cbMeasurements.Name = "cbMeasurements";
            this.cbMeasurements.Size = new System.Drawing.Size(194, 21);
            this.cbMeasurements.TabIndex = 1;
            this.cbMeasurements.ValueMember = "Measurement_ID";
            this.cbMeasurements.SelectedIndexChanged += new System.EventHandler(this.cbMeasurements_SelectedIndexChanged);
            // 
            // cbEquipmentTypes
            // 
            this.cbEquipmentTypes.DataSource = this.equipmentTypesBindingSource;
            this.cbEquipmentTypes.DisplayMember = "Equipment_Type_Name";
            this.cbEquipmentTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEquipmentTypes.FormattingEnabled = true;
            this.cbEquipmentTypes.Location = new System.Drawing.Point(98, 41);
            this.cbEquipmentTypes.Name = "cbEquipmentTypes";
            this.cbEquipmentTypes.Size = new System.Drawing.Size(264, 21);
            this.cbEquipmentTypes.TabIndex = 3;
            this.cbEquipmentTypes.ValueMember = "Equipment_Type_ID";
            // 
            // equipmentTypesBindingSource
            // 
            this.equipmentTypesBindingSource.DataMember = "EquipmentTypes";
            this.equipmentTypesBindingSource.DataSource = this.coldChain;
            // 
            // lblEquipmentType
            // 
            this.lblEquipmentType.AutoSize = true;
            this.lblEquipmentType.Location = new System.Drawing.Point(12, 45);
            this.lblEquipmentType.Name = "lblEquipmentType";
            this.lblEquipmentType.Size = new System.Drawing.Size(29, 13);
            this.lblEquipmentType.TabIndex = 2;
            this.lblEquipmentType.Text = "Тип:";
            // 
            // equipmentMeasurementsTableAdapter
            // 
            this.equipmentMeasurementsTableAdapter.ClearBeforeFill = true;
            // 
            // equipmentTypesTableAdapter
            // 
            this.equipmentTypesTableAdapter.ClearBeforeFill = true;
            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.Location = new System.Drawing.Point(12, 79);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(51, 13);
            this.lblBranch.TabIndex = 4;
            this.lblBranch.Text = "Филиал:";
            // 
            // cbBranches
            // 
            this.cbBranches.DataSource = this.branchesBindingSource;
            this.cbBranches.DisplayMember = "Branch_Name";
            this.cbBranches.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBranches.FormattingEnabled = true;
            this.cbBranches.Location = new System.Drawing.Point(98, 75);
            this.cbBranches.Name = "cbBranches";
            this.cbBranches.Size = new System.Drawing.Size(264, 21);
            this.cbBranches.TabIndex = 5;
            this.cbBranches.ValueMember = "Warehouse_ID";
            // 
            // branchesBindingSource
            // 
            this.branchesBindingSource.DataMember = "Branches";
            this.branchesBindingSource.DataSource = this.coldChain;
            // 
            // branchesTableAdapter
            // 
            this.branchesTableAdapter.ClearBeforeFill = true;
            // 
            // lblDepartmentNotation
            // 
            this.lblDepartmentNotation.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblDepartmentNotation.Location = new System.Drawing.Point(12, 105);
            this.lblDepartmentNotation.Name = "lblDepartmentNotation";
            this.lblDepartmentNotation.Size = new System.Drawing.Size(79, 28);
            this.lblDepartmentNotation.TabIndex = 6;
            this.lblDepartmentNotation.Text = "Отдел (примечание):";
            // 
            // tbDepartmentNotation
            // 
            this.tbDepartmentNotation.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.equipmentTypesBindingSource, "Use_Department", true));
            this.tbDepartmentNotation.Location = new System.Drawing.Point(98, 113);
            this.tbDepartmentNotation.Name = "tbDepartmentNotation";
            this.tbDepartmentNotation.Size = new System.Drawing.Size(264, 20);
            this.tbDepartmentNotation.TabIndex = 7;
            // 
            // lblSerialNumber
            // 
            this.lblSerialNumber.AutoSize = true;
            this.lblSerialNumber.Location = new System.Drawing.Point(12, 149);
            this.lblSerialNumber.Name = "lblSerialNumber";
            this.lblSerialNumber.Size = new System.Drawing.Size(30, 13);
            this.lblSerialNumber.TabIndex = 8;
            this.lblSerialNumber.Text = "S/N:";
            // 
            // tbSerialNumber
            // 
            this.tbSerialNumber.Location = new System.Drawing.Point(98, 145);
            this.tbSerialNumber.Name = "tbSerialNumber";
            this.tbSerialNumber.Size = new System.Drawing.Size(264, 20);
            this.tbSerialNumber.TabIndex = 9;
            // 
            // ColdEquipmentRegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.tbSerialNumber);
            this.Controls.Add(this.lblSerialNumber);
            this.Controls.Add(this.tbDepartmentNotation);
            this.Controls.Add(this.lblDepartmentNotation);
            this.Controls.Add(this.cbBranches);
            this.Controls.Add(this.lblBranch);
            this.Controls.Add(this.lblEquipmentType);
            this.Controls.Add(this.lblEquipmentName);
            this.Controls.Add(this.cbEquipmentTypes);
            this.Controls.Add(this.gbMeasurementsTools);
            this.Controls.Add(this.tbEquipmentName);
            this.Name = "ColdEquipmentRegistrationForm";
            this.Text = "Регистрация нового холодильного оборудования";
            this.Load += new System.EventHandler(this.ColdEquipmentRegistrationForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ColdEquipmentRegistrationForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.tbEquipmentName, 0);
            this.Controls.SetChildIndex(this.gbMeasurementsTools, 0);
            this.Controls.SetChildIndex(this.cbEquipmentTypes, 0);
            this.Controls.SetChildIndex(this.lblEquipmentName, 0);
            this.Controls.SetChildIndex(this.lblEquipmentType, 0);
            this.Controls.SetChildIndex(this.lblBranch, 0);
            this.Controls.SetChildIndex(this.cbBranches, 0);
            this.Controls.SetChildIndex(this.lblDepartmentNotation, 0);
            this.Controls.SetChildIndex(this.tbDepartmentNotation, 0);
            this.Controls.SetChildIndex(this.lblSerialNumber, 0);
            this.Controls.SetChildIndex(this.tbSerialNumber, 0);
            this.pnlButtons.ResumeLayout(false);
            this.gbMeasurementsTools.ResumeLayout(false);
            this.pnlMeasurements.ResumeLayout(false);
            this.pnlMeasurements.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentMeasurementsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coldChain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEquipment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.branchesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbEquipmentName;
        private System.Windows.Forms.Label lblEquipmentName;
        private System.Windows.Forms.GroupBox gbMeasurementsTools;
        private System.Windows.Forms.ComboBox cbEquipmentTypes;
        private System.Windows.Forms.Label lblEquipmentType;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.Label lblDepth;
        private System.Windows.Forms.PictureBox pbEquipment;
        private System.Windows.Forms.TextBox tbDepth;
        private System.Windows.Forms.TextBox tbWidth;
        private System.Windows.Forms.TextBox tbHeight;
        private System.Windows.Forms.ComboBox cbMeasurements;
        private WMSOffice.Data.ColdChain coldChain;
        private System.Windows.Forms.BindingSource equipmentMeasurementsBindingSource;
        private WMSOffice.Data.ColdChainTableAdapters.EquipmentMeasurementsTableAdapter equipmentMeasurementsTableAdapter;
        private System.Windows.Forms.BindingSource equipmentTypesBindingSource;
        private WMSOffice.Data.ColdChainTableAdapters.EquipmentTypesTableAdapter equipmentTypesTableAdapter;
        private System.Windows.Forms.Panel pnlMeasurements;
        private System.Windows.Forms.Label lblMeasurements;
        private System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.ComboBox cbBranches;
        private System.Windows.Forms.BindingSource branchesBindingSource;
        private WMSOffice.Data.ColdChainTableAdapters.BranchesTableAdapter branchesTableAdapter;
        private System.Windows.Forms.Label lblDepartmentNotation;
        private System.Windows.Forms.TextBox tbDepartmentNotation;
        private System.Windows.Forms.Label lblSerialNumber;
        private System.Windows.Forms.TextBox tbSerialNumber;
    }
}