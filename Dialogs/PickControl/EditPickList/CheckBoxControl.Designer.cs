namespace WMSOffice.Dialogs.PickControl.EditPickList
{
    partial class CheckBoxControl
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
            this.chbSelect = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chbSelect
            // 
            this.chbSelect.AutoSize = true;
            this.chbSelect.Location = new System.Drawing.Point(3, 3);
            this.chbSelect.Name = "chbSelect";
            this.chbSelect.Size = new System.Drawing.Size(70, 17);
            this.chbSelect.TabIndex = 0;
            this.chbSelect.Text = "Выбрать";
            this.chbSelect.UseVisualStyleBackColor = true;
            this.chbSelect.CheckedChanged += new System.EventHandler(this.chbSelect_CheckedChanged);
            // 
            // CheckBoxControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chbSelect);
            this.Name = "CheckBoxControl";
            this.Size = new System.Drawing.Size(600, 22);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chbSelect;
    }
}
