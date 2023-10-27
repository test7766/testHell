namespace WMSOffice.Dialogs.Quality
{
    partial class NewDelayReasonForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblReasonType = new System.Windows.Forms.Label();
            this.cmbReasonTypes = new System.Windows.Forms.ComboBox();
            this.bsQkDelayReasonTypes = new System.Windows.Forms.BindingSource(this.components);
            this.quality = new WMSOffice.Data.Quality();
            this.taQkDelayReasonTypes = new WMSOffice.Data.QualityTableAdapters.QK_Delay_Reason_TypesTableAdapter();
            this.lblDescription = new System.Windows.Forms.Label();
            this.tbxDescription = new System.Windows.Forms.TextBox();
            this.lblGspoRequest = new System.Windows.Forms.Label();
            this.tbxGspoRequest = new System.Windows.Forms.TextBox();
            this.lblResponsible = new System.Windows.Forms.Label();
            this.tbxResponsible = new System.Windows.Forms.TextBox();
            this.taQkDelayReasonsRespEmployee = new WMSOffice.Data.QualityTableAdapters.QK_Delay_Reasons_Resp_EmployeeTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bsQkDelayReasonTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(444, 234);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 60;
            this.btnCancel.Text = "Скасувати";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(363, 234);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 50;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblReasonType
            // 
            this.lblReasonType.AutoSize = true;
            this.lblReasonType.Location = new System.Drawing.Point(12, 9);
            this.lblReasonType.Name = "lblReasonType";
            this.lblReasonType.Size = new System.Drawing.Size(75, 13);
            this.lblReasonType.TabIndex = 2;
            this.lblReasonType.Text = "Тип причини:";
            // 
            // cmbReasonTypes
            // 
            this.cmbReasonTypes.DataSource = this.bsQkDelayReasonTypes;
            this.cmbReasonTypes.DisplayMember = "reason_type_name";
            this.cmbReasonTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReasonTypes.FormattingEnabled = true;
            this.cmbReasonTypes.Location = new System.Drawing.Point(110, 6);
            this.cmbReasonTypes.Name = "cmbReasonTypes";
            this.cmbReasonTypes.Size = new System.Drawing.Size(409, 21);
            this.cmbReasonTypes.TabIndex = 10;
            this.cmbReasonTypes.ValueMember = "reason_type_id";
            this.cmbReasonTypes.SelectedIndexChanged += new System.EventHandler(this.cmbReasonTypes_SelectedIndexChanged);
            // 
            // bsQkDelayReasonTypes
            // 
            this.bsQkDelayReasonTypes.DataMember = "QK_Delay_Reason_Types";
            this.bsQkDelayReasonTypes.DataSource = this.quality;
            // 
            // quality
            // 
            this.quality.DataSetName = "Quality";
            this.quality.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // taQkDelayReasonTypes
            // 
            this.taQkDelayReasonTypes.ClearBeforeFill = true;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 77);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Опис:";
            // 
            // tbxDescription
            // 
            this.tbxDescription.Location = new System.Drawing.Point(110, 74);
            this.tbxDescription.Multiline = true;
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.Size = new System.Drawing.Size(409, 100);
            this.tbxDescription.TabIndex = 30;
            // 
            // lblGspoRequest
            // 
            this.lblGspoRequest.AutoSize = true;
            this.lblGspoRequest.Enabled = false;
            this.lblGspoRequest.Location = new System.Drawing.Point(12, 44);
            this.lblGspoRequest.Name = "lblGspoRequest";
            this.lblGspoRequest.Size = new System.Drawing.Size(92, 13);
            this.lblGspoRequest.TabIndex = 6;
            this.lblGspoRequest.Text = "№ заяви ГППЗ:";
            // 
            // tbxGspoRequest
            // 
            this.tbxGspoRequest.Enabled = false;
            this.tbxGspoRequest.Location = new System.Drawing.Point(110, 41);
            this.tbxGspoRequest.Name = "tbxGspoRequest";
            this.tbxGspoRequest.Size = new System.Drawing.Size(112, 20);
            this.tbxGspoRequest.TabIndex = 20;
            this.tbxGspoRequest.TextChanged += new System.EventHandler(this.tbxGspoRequest_TextChanged);
            // 
            // lblResponsible
            // 
            this.lblResponsible.AutoSize = true;
            this.lblResponsible.Location = new System.Drawing.Point(12, 194);
            this.lblResponsible.Name = "lblResponsible";
            this.lblResponsible.Size = new System.Drawing.Size(89, 13);
            this.lblResponsible.TabIndex = 8;
            this.lblResponsible.Text = "Відповідальний:";
            // 
            // tbxResponsible
            // 
            this.tbxResponsible.Location = new System.Drawing.Point(110, 191);
            this.tbxResponsible.Name = "tbxResponsible";
            this.tbxResponsible.ReadOnly = true;
            this.tbxResponsible.Size = new System.Drawing.Size(409, 20);
            this.tbxResponsible.TabIndex = 40;
            // 
            // taQkDelayReasonsRespEmployee
            // 
            this.taQkDelayReasonsRespEmployee.ClearBeforeFill = true;
            // 
            // NewDelayReasonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(531, 269);
            this.Controls.Add(this.tbxResponsible);
            this.Controls.Add(this.lblResponsible);
            this.Controls.Add(this.tbxGspoRequest);
            this.Controls.Add(this.lblGspoRequest);
            this.Controls.Add(this.tbxDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.cmbReasonTypes);
            this.Controls.Add(this.lblReasonType);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "NewDelayReasonForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Створення причини затримки";
            this.Load += new System.EventHandler(this.NewDelayReasonForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsQkDelayReasonTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblReasonType;
        private System.Windows.Forms.ComboBox cmbReasonTypes;
        private WMSOffice.Data.Quality quality;
        private System.Windows.Forms.BindingSource bsQkDelayReasonTypes;
        private WMSOffice.Data.QualityTableAdapters.QK_Delay_Reason_TypesTableAdapter taQkDelayReasonTypes;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox tbxDescription;
        private System.Windows.Forms.Label lblGspoRequest;
        private System.Windows.Forms.TextBox tbxGspoRequest;
        private System.Windows.Forms.Label lblResponsible;
        private System.Windows.Forms.TextBox tbxResponsible;
        private WMSOffice.Data.QualityTableAdapters.QK_Delay_Reasons_Resp_EmployeeTableAdapter taQkDelayReasonsRespEmployee;
    }
}