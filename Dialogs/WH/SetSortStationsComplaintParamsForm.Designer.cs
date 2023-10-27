namespace WMSOffice.Dialogs.WH
{
    partial class SetSortStationsComplaintParamsForm
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
            this.lblComplaintDocTypes = new System.Windows.Forms.Label();
            this.cmbCompaintDocTypes = new System.Windows.Forms.ComboBox();
            this.pTLDeclareCOTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wH = new WMSOffice.Data.WH();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.pTL_Declare_CO_TypesTableAdapter = new WMSOffice.Data.WHTableAdapters.PTL_Declare_CO_TypesTableAdapter();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pTLDeclareCOTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(349, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(439, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 108);
            this.pnlButtons.Size = new System.Drawing.Size(394, 43);
            this.pnlButtons.TabIndex = 4;
            // 
            // lblComplaintDocTypes
            // 
            this.lblComplaintDocTypes.AutoSize = true;
            this.lblComplaintDocTypes.Location = new System.Drawing.Point(13, 32);
            this.lblComplaintDocTypes.Name = "lblComplaintDocTypes";
            this.lblComplaintDocTypes.Size = new System.Drawing.Size(88, 13);
            this.lblComplaintDocTypes.TabIndex = 0;
            this.lblComplaintDocTypes.Text = "Тип претензии :";
            // 
            // cmbCompaintDocTypes
            // 
            this.cmbCompaintDocTypes.DataSource = this.pTLDeclareCOTypesBindingSource;
            this.cmbCompaintDocTypes.DisplayMember = "Doc_Type_Name";
            this.cmbCompaintDocTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompaintDocTypes.FormattingEnabled = true;
            this.cmbCompaintDocTypes.Location = new System.Drawing.Point(107, 29);
            this.cmbCompaintDocTypes.Name = "cmbCompaintDocTypes";
            this.cmbCompaintDocTypes.Size = new System.Drawing.Size(275, 21);
            this.cmbCompaintDocTypes.TabIndex = 1;
            this.cmbCompaintDocTypes.ValueMember = "Doc_Type";
            this.cmbCompaintDocTypes.SelectedValueChanged += new System.EventHandler(this.cmbCompaintDocTypes_SelectedValueChanged);
            // 
            // pTLDeclareCOTypesBindingSource
            // 
            this.pTLDeclareCOTypesBindingSource.DataMember = "PTL_Declare_CO_Types";
            this.pTLDeclareCOTypesBindingSource.DataSource = this.wH;
            // 
            // wH
            // 
            this.wH.DataSetName = "WH";
            this.wH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // nudQuantity
            // 
            this.nudQuantity.Location = new System.Drawing.Point(107, 65);
            this.nudQuantity.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(120, 20);
            this.nudQuantity.TabIndex = 3;
            this.nudQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(13, 69);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(72, 13);
            this.lblQuantity.TabIndex = 2;
            this.lblQuantity.Text = "Количество :";
            // 
            // pTL_Declare_CO_TypesTableAdapter
            // 
            this.pTL_Declare_CO_TypesTableAdapter.ClearBeforeFill = true;
            // 
            // SetSortStationsCompaintParamsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 151);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.cmbCompaintDocTypes);
            this.Controls.Add(this.nudQuantity);
            this.Controls.Add(this.lblComplaintDocTypes);
            this.Name = "SetSortStationsCompaintParamsForm";
            this.Text = "Укажите параметры создаваемой претензии";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SetSortStationsCompaintParamsForm_FormClosing);
            this.Controls.SetChildIndex(this.lblComplaintDocTypes, 0);
            this.Controls.SetChildIndex(this.nudQuantity, 0);
            this.Controls.SetChildIndex(this.cmbCompaintDocTypes, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.lblQuantity, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pTLDeclareCOTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblComplaintDocTypes;
        private System.Windows.Forms.ComboBox cmbCompaintDocTypes;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.BindingSource pTLDeclareCOTypesBindingSource;
        private WMSOffice.Data.WH wH;
        private WMSOffice.Data.WHTableAdapters.PTL_Declare_CO_TypesTableAdapter pTL_Declare_CO_TypesTableAdapter;
    }
}