namespace WMSOffice.Dialogs.Complaints
{
    partial class ChooseLocationForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblFilter = new System.Windows.Forms.Label();
            this.tbxFilter = new System.Windows.Forms.TextBox();
            this.lblFilterDesc = new System.Windows.Forms.Label();
            this.dgvLocations = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(281, 437);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 40;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(200, 437);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 30;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(12, 9);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(45, 13);
            this.lblFilter.TabIndex = 2;
            this.lblFilter.Text = "Поиск: ";
            // 
            // tbxFilter
            // 
            this.tbxFilter.Location = new System.Drawing.Point(71, 6);
            this.tbxFilter.Name = "tbxFilter";
            this.tbxFilter.Size = new System.Drawing.Size(138, 20);
            this.tbxFilter.TabIndex = 10;
            this.tbxFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxFilter_KeyDown);
            // 
            // lblFilterDesc
            // 
            this.lblFilterDesc.AutoSize = true;
            this.lblFilterDesc.Location = new System.Drawing.Point(215, 9);
            this.lblFilterDesc.Name = "lblFilterDesc";
            this.lblFilterDesc.Size = new System.Drawing.Size(138, 13);
            this.lblFilterDesc.TabIndex = 41;
            this.lblFilterDesc.Text = "(не менее трех символов)";
            // 
            // dgvLocations
            // 
            this.dgvLocations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLocations.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.dgvLocations.LargeAmountOfData = false;
            this.dgvLocations.Location = new System.Drawing.Point(12, 32);
            this.dgvLocations.Name = "dgvLocations";
            this.dgvLocations.RowHeadersVisible = false;
            this.dgvLocations.Size = new System.Drawing.Size(341, 399);
            this.dgvLocations.TabIndex = 42;
            this.dgvLocations.UserID = ((long)(0));
            this.dgvLocations.OnRowDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLocations_OnRowDoubleClick);
            // 
            // ChooseLocationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(368, 472);
            this.Controls.Add(this.dgvLocations);
            this.Controls.Add(this.lblFilterDesc);
            this.Controls.Add(this.tbxFilter);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.KeyPreview = true;
            this.Name = "ChooseLocationForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Выбор полки";
            this.Load += new System.EventHandler(this.ChooseLocationForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChooseLocationForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.TextBox tbxFilter;
        private System.Windows.Forms.Label lblFilterDesc;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView dgvLocations;
    }
}