namespace WMSOffice.Dialogs.Complaints
{
    partial class DocTypeChooseForm
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
            this.cbDocTypes = new System.Windows.Forms.ComboBox();
            this.availableDocsTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.complaints = new WMSOffice.Data.Complaints();
            this.availableDocsTypesTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.AvailableDocsTypesTableAdapter();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.availableDocsTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(-307, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(-226, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 84);
            this.pnlButtons.Size = new System.Drawing.Size(252, 43);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 13);
            this.label1.TabIndex = 101;
            this.label1.Text = "Выберите тип создаваемой претензии:";
            // 
            // cbDocTypes
            // 
            this.cbDocTypes.DataSource = this.availableDocsTypesBindingSource;
            this.cbDocTypes.DisplayMember = "Doc_Type_Name";
            this.cbDocTypes.DropDownHeight = 525;
            this.cbDocTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDocTypes.FormattingEnabled = true;
            this.cbDocTypes.IntegralHeight = false;
            this.cbDocTypes.Location = new System.Drawing.Point(15, 34);
            this.cbDocTypes.MaxDropDownItems = 20;
            this.cbDocTypes.Name = "cbDocTypes";
            this.cbDocTypes.Size = new System.Drawing.Size(225, 21);
            this.cbDocTypes.TabIndex = 102;
            this.cbDocTypes.ValueMember = "Doc_Type";
            // 
            // availableDocsTypesBindingSource
            // 
            this.availableDocsTypesBindingSource.DataMember = "AvailableDocsTypes";
            this.availableDocsTypesBindingSource.DataSource = this.complaints;
            // 
            // complaints
            // 
            this.complaints.DataSetName = "Complaints";
            this.complaints.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // availableDocsTypesTableAdapter
            // 
            this.availableDocsTypesTableAdapter.ClearBeforeFill = true;
            // 
            // DocTypeChooseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 127);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbDocTypes);
            this.Name = "DocTypeChooseForm";
            this.Text = "Тип новой претензии";
            this.Shown += new System.EventHandler(this.DocTypeChooseForm_Shown);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.cbDocTypes, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.availableDocsTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbDocTypes;
        private WMSOffice.Data.Complaints complaints;
        private System.Windows.Forms.BindingSource availableDocsTypesBindingSource;
        private WMSOffice.Data.ComplaintsTableAdapters.AvailableDocsTypesTableAdapter availableDocsTypesTableAdapter;
    }
}