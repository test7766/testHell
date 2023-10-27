namespace WMSOffice.Dialogs.PickControl
{
    partial class DebtorsReturnedTareSetGuiltyEmployeeForm
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
            this.tbGuilty = new System.Windows.Forms.TextBox();
            this.lblGuilty = new System.Windows.Forms.Label();
            this.stbGuilty = new WMSOffice.Controls.SearchTextBox();
            this.lblGuiltyCategory = new System.Windows.Forms.Label();
            this.cmbGuiltyCategory = new System.Windows.Forms.ComboBox();
            this.cTTareGuiltyCategoriesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pickControl = new WMSOffice.Data.PickControl();
            this.tbReason = new System.Windows.Forms.TextBox();
            this.lblReason = new System.Windows.Forms.Label();
            this.tbAttachedDocumentPath = new System.Windows.Forms.TextBox();
            this.btnAttachDocument = new System.Windows.Forms.Button();
            this.cT_Tare_Guilty_CategoriesTableAdapter = new WMSOffice.Data.PickControlTableAdapters.CT_Tare_Guilty_CategoriesTableAdapter();
            this.lblAttachedDocument = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cTTareGuiltyCategoriesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(643, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(733, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 221);
            this.pnlButtons.Size = new System.Drawing.Size(444, 43);
            this.pnlButtons.TabIndex = 10;
            // 
            // tbGuilty
            // 
            this.tbGuilty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbGuilty.BackColor = System.Drawing.SystemColors.Window;
            this.tbGuilty.Location = new System.Drawing.Point(157, 39);
            this.tbGuilty.Name = "tbGuilty";
            this.tbGuilty.ReadOnly = true;
            this.tbGuilty.Size = new System.Drawing.Size(275, 20);
            this.tbGuilty.TabIndex = 4;
            this.tbGuilty.TabStop = false;
            // 
            // lblGuilty
            // 
            this.lblGuilty.AutoSize = true;
            this.lblGuilty.Location = new System.Drawing.Point(12, 43);
            this.lblGuilty.Name = "lblGuilty";
            this.lblGuilty.Size = new System.Drawing.Size(58, 13);
            this.lblGuilty.TabIndex = 2;
            this.lblGuilty.Text = "Виновный";
            // 
            // stbGuilty
            // 
            this.stbGuilty.Location = new System.Drawing.Point(81, 39);
            this.stbGuilty.Name = "stbGuilty";
            this.stbGuilty.ReadOnly = false;
            this.stbGuilty.Size = new System.Drawing.Size(70, 20);
            this.stbGuilty.TabIndex = 3;
            this.stbGuilty.UserID = ((long)(0));
            this.stbGuilty.Value = null;
            this.stbGuilty.ValueReferenceQuery = null;
            // 
            // lblGuiltyCategory
            // 
            this.lblGuiltyCategory.AutoSize = true;
            this.lblGuiltyCategory.Location = new System.Drawing.Point(12, 14);
            this.lblGuiltyCategory.Name = "lblGuiltyCategory";
            this.lblGuiltyCategory.Size = new System.Drawing.Size(63, 13);
            this.lblGuiltyCategory.TabIndex = 0;
            this.lblGuiltyCategory.Text = "Категория ";
            // 
            // cmbGuiltyCategory
            // 
            this.cmbGuiltyCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbGuiltyCategory.DataSource = this.cTTareGuiltyCategoriesBindingSource;
            this.cmbGuiltyCategory.DisplayMember = "GroupName";
            this.cmbGuiltyCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGuiltyCategory.FormattingEnabled = true;
            this.cmbGuiltyCategory.Location = new System.Drawing.Point(81, 10);
            this.cmbGuiltyCategory.Name = "cmbGuiltyCategory";
            this.cmbGuiltyCategory.Size = new System.Drawing.Size(351, 21);
            this.cmbGuiltyCategory.TabIndex = 1;
            this.cmbGuiltyCategory.ValueMember = "ID";
            this.cmbGuiltyCategory.SelectedValueChanged += new System.EventHandler(this.cmbGuiltyCategory_SelectedValueChanged);
            // 
            // cTTareGuiltyCategoriesBindingSource
            // 
            this.cTTareGuiltyCategoriesBindingSource.DataMember = "CT_Tare_Guilty_Categories";
            this.cTTareGuiltyCategoriesBindingSource.DataSource = this.pickControl;
            // 
            // pickControl
            // 
            this.pickControl.DataSetName = "PickControl";
            this.pickControl.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbReason
            // 
            this.tbReason.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbReason.Location = new System.Drawing.Point(81, 96);
            this.tbReason.Multiline = true;
            this.tbReason.Name = "tbReason";
            this.tbReason.Size = new System.Drawing.Size(351, 119);
            this.tbReason.TabIndex = 9;
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Location = new System.Drawing.Point(12, 96);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(50, 13);
            this.lblReason.TabIndex = 8;
            this.lblReason.Text = "Причина";
            // 
            // tbAttachedDocumentPath
            // 
            this.tbAttachedDocumentPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAttachedDocumentPath.BackColor = System.Drawing.SystemColors.Window;
            this.tbAttachedDocumentPath.Location = new System.Drawing.Point(157, 66);
            this.tbAttachedDocumentPath.Name = "tbAttachedDocumentPath";
            this.tbAttachedDocumentPath.ReadOnly = true;
            this.tbAttachedDocumentPath.Size = new System.Drawing.Size(275, 20);
            this.tbAttachedDocumentPath.TabIndex = 7;
            this.tbAttachedDocumentPath.TabStop = false;
            // 
            // btnAttachDocument
            // 
            this.btnAttachDocument.Location = new System.Drawing.Point(81, 65);
            this.btnAttachDocument.Name = "btnAttachDocument";
            this.btnAttachDocument.Size = new System.Drawing.Size(70, 23);
            this.btnAttachDocument.TabIndex = 6;
            this.btnAttachDocument.Text = "Вложить";
            this.btnAttachDocument.UseVisualStyleBackColor = true;
            this.btnAttachDocument.Click += new System.EventHandler(this.btnAttachDocument_Click);
            // 
            // cT_Tare_Guilty_CategoriesTableAdapter
            // 
            this.cT_Tare_Guilty_CategoriesTableAdapter.ClearBeforeFill = true;
            // 
            // lblAttachedDocument
            // 
            this.lblAttachedDocument.AutoSize = true;
            this.lblAttachedDocument.Location = new System.Drawing.Point(12, 70);
            this.lblAttachedDocument.Name = "lblAttachedDocument";
            this.lblAttachedDocument.Size = new System.Drawing.Size(43, 13);
            this.lblAttachedDocument.TabIndex = 5;
            this.lblAttachedDocument.Text = "Акт ОТ";
            // 
            // DebtorsReturnedTareSetGuiltyEmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 264);
            this.Controls.Add(this.lblAttachedDocument);
            this.Controls.Add(this.btnAttachDocument);
            this.Controls.Add(this.tbAttachedDocumentPath);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.tbReason);
            this.Controls.Add(this.cmbGuiltyCategory);
            this.Controls.Add(this.lblGuiltyCategory);
            this.Controls.Add(this.tbGuilty);
            this.Controls.Add(this.lblGuilty);
            this.Controls.Add(this.stbGuilty);
            this.Name = "DebtorsReturnedTareSetGuiltyEmployeeForm";
            this.Text = "Регистрация боя ОТ";
            this.Load += new System.EventHandler(this.DebtorsReturnedTareSetGuiltyEmployeeForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DebtorsReturnedTareSetGuiltyEmployeeForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.stbGuilty, 0);
            this.Controls.SetChildIndex(this.lblGuilty, 0);
            this.Controls.SetChildIndex(this.tbGuilty, 0);
            this.Controls.SetChildIndex(this.lblGuiltyCategory, 0);
            this.Controls.SetChildIndex(this.cmbGuiltyCategory, 0);
            this.Controls.SetChildIndex(this.tbReason, 0);
            this.Controls.SetChildIndex(this.lblReason, 0);
            this.Controls.SetChildIndex(this.tbAttachedDocumentPath, 0);
            this.Controls.SetChildIndex(this.btnAttachDocument, 0);
            this.Controls.SetChildIndex(this.lblAttachedDocument, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cTTareGuiltyCategoriesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbGuilty;
        private System.Windows.Forms.Label lblGuilty;
        private WMSOffice.Controls.SearchTextBox stbGuilty;
        private System.Windows.Forms.Label lblGuiltyCategory;
        private System.Windows.Forms.ComboBox cmbGuiltyCategory;
        private System.Windows.Forms.TextBox tbReason;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.TextBox tbAttachedDocumentPath;
        private System.Windows.Forms.Button btnAttachDocument;
        private System.Windows.Forms.BindingSource cTTareGuiltyCategoriesBindingSource;
        private WMSOffice.Data.PickControl pickControl;
        private WMSOffice.Data.PickControlTableAdapters.CT_Tare_Guilty_CategoriesTableAdapter cT_Tare_Guilty_CategoriesTableAdapter;
        private System.Windows.Forms.Label lblAttachedDocument;
    }
}