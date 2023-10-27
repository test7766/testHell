namespace WMSOffice.Dialogs.WH
{
    partial class EllipsisGridCellEditorControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnShowSelector = new System.Windows.Forms.Button();
            this.tbValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnShowSelector
            // 
            this.btnShowSelector.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnShowSelector.Image = global::WMSOffice.Properties.Resources.open_dictionary;
            this.btnShowSelector.Location = new System.Drawing.Point(235, 0);
            this.btnShowSelector.Name = "btnShowSelector";
            this.btnShowSelector.Size = new System.Drawing.Size(23, 23);
            this.btnShowSelector.TabIndex = 1;
            this.btnShowSelector.TabStop = false;
            this.btnShowSelector.UseVisualStyleBackColor = true;
            this.btnShowSelector.Enter += new System.EventHandler(this.btnShowSelector_Enter);
            // 
            // tbValue
            // 
            this.tbValue.BackColor = System.Drawing.SystemColors.Window;
            this.tbValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbValue.Location = new System.Drawing.Point(0, 0);
            this.tbValue.Name = "tbValue";
            this.tbValue.Size = new System.Drawing.Size(235, 20);
            this.tbValue.TabIndex = 2;
            // 
            // EllipsisGridCellEditorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbValue);
            this.Controls.Add(this.btnShowSelector);
            this.Name = "EllipsisGridCellEditorControl";
            this.Size = new System.Drawing.Size(258, 23);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnShowSelector;
        private System.Windows.Forms.TextBox tbValue;
    }
}
