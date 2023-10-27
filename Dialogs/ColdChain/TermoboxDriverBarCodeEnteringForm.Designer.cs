namespace WMSOffice.Dialogs.ColdChain
{
    partial class TermoboxDriverBarCodeEnteringForm
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
            this.lblTermobox = new System.Windows.Forms.Label();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.tbsEmployee = new WMSOffice.Controls.TextBoxScaner();
            this.tbsTermobox = new WMSOffice.Controls.TextBoxScaner();
            this.tbsSensor = new WMSOffice.Controls.TextBoxScaner();
            this.lblSensor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCancel.Location = new System.Drawing.Point(415, 258);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 27);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblTermobox
            // 
            this.lblTermobox.AutoSize = true;
            this.lblTermobox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblTermobox.Location = new System.Drawing.Point(20, 18);
            this.lblTermobox.Name = "lblTermobox";
            this.lblTermobox.Size = new System.Drawing.Size(298, 20);
            this.lblTermobox.TabIndex = 20;
            this.lblTermobox.Text = "Отсканируйте штрих-код термобокса:";
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblEmployee.Location = new System.Drawing.Point(18, 181);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(292, 20);
            this.lblEmployee.TabIndex = 20;
            this.lblEmployee.Text = "Отсканируйте штрих-код сотрудника";
            // 
            // tbsEmployee
            // 
            this.tbsEmployee.AllowType = true;
            this.tbsEmployee.AutoConvert = true;
            this.tbsEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbsEmployee.Location = new System.Drawing.Point(22, 206);
            this.tbsEmployee.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbsEmployee.Name = "tbsEmployee";
            this.tbsEmployee.ReadOnly = false;
            this.tbsEmployee.Size = new System.Drawing.Size(473, 38);
            this.tbsEmployee.TabIndex = 3;
            this.tbsEmployee.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.tbsEmployee.TextChanged += new System.EventHandler(this.tbsEmployee_TextChanged);
            // 
            // tbsTermobox
            // 
            this.tbsTermobox.AllowType = true;
            this.tbsTermobox.AutoConvert = true;
            this.tbsTermobox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbsTermobox.Location = new System.Drawing.Point(24, 43);
            this.tbsTermobox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbsTermobox.Name = "tbsTermobox";
            this.tbsTermobox.ReadOnly = false;
            this.tbsTermobox.Size = new System.Drawing.Size(473, 38);
            this.tbsTermobox.TabIndex = 1;
            this.tbsTermobox.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.tbsTermobox.TextChanged += new System.EventHandler(this.tbsTermobox_TextChanged);
            // 
            // tbsSensor
            // 
            this.tbsSensor.AllowType = true;
            this.tbsSensor.AutoConvert = true;
            this.tbsSensor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbsSensor.Location = new System.Drawing.Point(22, 124);
            this.tbsSensor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbsSensor.Name = "tbsSensor";
            this.tbsSensor.ReadOnly = false;
            this.tbsSensor.Size = new System.Drawing.Size(473, 38);
            this.tbsSensor.TabIndex = 2;
            this.tbsSensor.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.tbsSensor.TextChanged += new System.EventHandler(this.tbsSensor_TextChanged);
            // 
            // lblSensor
            // 
            this.lblSensor.AutoSize = true;
            this.lblSensor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblSensor.Location = new System.Drawing.Point(18, 99);
            this.lblSensor.Name = "lblSensor";
            this.lblSensor.Size = new System.Drawing.Size(272, 20);
            this.lblSensor.TabIndex = 22;
            this.lblSensor.Text = "Отсканируйте штрих-код датчика:";
            // 
            // TermoboxDriverBarCodeEnteringForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(509, 297);
            this.Controls.Add(this.tbsSensor);
            this.Controls.Add(this.lblSensor);
            this.Controls.Add(this.tbsEmployee);
            this.Controls.Add(this.lblEmployee);
            this.Controls.Add(this.tbsTermobox);
            this.Controls.Add(this.lblTermobox);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "TermoboxDriverBarCodeEnteringForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Выдача термобокса";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblTermobox;
        private WMSOffice.Controls.TextBoxScaner tbsTermobox;
        private WMSOffice.Controls.TextBoxScaner tbsEmployee;
        private System.Windows.Forms.Label lblEmployee;
        private WMSOffice.Controls.TextBoxScaner tbsSensor;
        private System.Windows.Forms.Label lblSensor;
    }
}