namespace WMSOffice.Dialogs.WH
{
    partial class ChoiseOperationForm
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
            this.lblOperationType = new System.Windows.Forms.Label();
            this.cmbOperationType = new System.Windows.Forms.ComboBox();
            this.operationsTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wH = new WMSOffice.Data.WH();
            this.operationsTypesTableAdapter = new WMSOffice.Data.WHTableAdapters.OperationsTypesTableAdapter();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.operationsTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(206, 8);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(296, 8);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 51);
            this.pnlButtons.Size = new System.Drawing.Size(347, 43);
            // 
            // lblOperationType
            // 
            this.lblOperationType.AutoSize = true;
            this.lblOperationType.Location = new System.Drawing.Point(23, 18);
            this.lblOperationType.Name = "lblOperationType";
            this.lblOperationType.Size = new System.Drawing.Size(80, 13);
            this.lblOperationType.TabIndex = 101;
            this.lblOperationType.Text = "Тип операции:";
            // 
            // cmbOperationType
            // 
            this.cmbOperationType.DataSource = this.operationsTypesBindingSource;
            this.cmbOperationType.DisplayMember = "TypeName";
            this.cmbOperationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOperationType.FormattingEnabled = true;
            this.cmbOperationType.Location = new System.Drawing.Point(109, 14);
            this.cmbOperationType.Name = "cmbOperationType";
            this.cmbOperationType.Size = new System.Drawing.Size(214, 21);
            this.cmbOperationType.TabIndex = 102;
            this.cmbOperationType.ValueMember = "SubType_ID";
            // 
            // operationsTypesBindingSource
            // 
            this.operationsTypesBindingSource.DataMember = "OperationsTypes";
            this.operationsTypesBindingSource.DataSource = this.wH;
            // 
            // wH
            // 
            this.wH.DataSetName = "WH";
            this.wH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // operationsTypesTableAdapter
            // 
            this.operationsTypesTableAdapter.ClearBeforeFill = true;
            // 
            // ChoiseOperationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 94);
            this.Controls.Add(this.lblOperationType);
            this.Controls.Add(this.cmbOperationType);
            this.Name = "ChoiseOperationForm";
            this.Text = "Создание новой операции";
            this.Load += new System.EventHandler(this.ChoiseOperationForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChoiseOperationForm_FormClosing);
            this.Controls.SetChildIndex(this.cmbOperationType, 0);
            this.Controls.SetChildIndex(this.lblOperationType, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.operationsTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOperationType;
        private System.Windows.Forms.ComboBox cmbOperationType;
        private System.Windows.Forms.BindingSource operationsTypesBindingSource;
        private WMSOffice.Data.WH wH;
        private WMSOffice.Data.WHTableAdapters.OperationsTypesTableAdapter operationsTypesTableAdapter;
    }
}