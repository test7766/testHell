namespace WMSOffice.Dialogs.ColdChain
{
    partial class SearchOrdersForm
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
            this.tbOrderNumber = new System.Windows.Forms.TextBox();
            this.tbDocCode = new System.Windows.Forms.TextBox();
            this.rbDocCode = new System.Windows.Forms.RadioButton();
            this.rbOrderNumber = new System.Windows.Forms.RadioButton();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 75);
            this.pnlButtons.Size = new System.Drawing.Size(287, 43);
            // 
            // tbOrderNumber
            // 
            this.tbOrderNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOrderNumber.Location = new System.Drawing.Point(103, 43);
            this.tbOrderNumber.Name = "tbOrderNumber";
            this.tbOrderNumber.Size = new System.Drawing.Size(171, 20);
            this.tbOrderNumber.TabIndex = 101;
            this.tbOrderNumber.Tag = "";
            this.tbOrderNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSearchFilterElement_KeyDown);
            this.tbOrderNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSearchFilterElement_KeyPress);
            // 
            // tbDocCode
            // 
            this.tbDocCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDocCode.Location = new System.Drawing.Point(103, 11);
            this.tbDocCode.Name = "tbDocCode";
            this.tbDocCode.Size = new System.Drawing.Size(171, 20);
            this.tbDocCode.TabIndex = 102;
            this.tbDocCode.Tag = "";
            this.tbDocCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSearchFilterElement_KeyDown);
            this.tbDocCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSearchFilterElement_KeyPress);
            // 
            // rbDocCode
            // 
            this.rbDocCode.AutoSize = true;
            this.rbDocCode.Location = new System.Drawing.Point(14, 12);
            this.rbDocCode.Name = "rbDocCode";
            this.rbDocCode.Size = new System.Drawing.Size(73, 17);
            this.rbDocCode.TabIndex = 105;
            this.rbDocCode.Text = "Код акта:";
            this.rbDocCode.UseVisualStyleBackColor = true;
            this.rbDocCode.CheckedChanged += new System.EventHandler(this.rbSearchFilterElement_Changed);
            // 
            // rbOrderNumber
            // 
            this.rbOrderNumber.AutoSize = true;
            this.rbOrderNumber.Location = new System.Drawing.Point(14, 44);
            this.rbOrderNumber.Name = "rbOrderNumber";
            this.rbOrderNumber.Size = new System.Drawing.Size(78, 17);
            this.rbOrderNumber.TabIndex = 106;
            this.rbOrderNumber.Text = "№ заказа:";
            this.rbOrderNumber.UseVisualStyleBackColor = true;
            this.rbOrderNumber.CheckedChanged += new System.EventHandler(this.rbSearchFilterElement_Changed);
            // 
            // SearchOrdersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 118);
            this.Controls.Add(this.rbOrderNumber);
            this.Controls.Add(this.rbDocCode);
            this.Controls.Add(this.tbDocCode);
            this.Controls.Add(this.tbOrderNumber);
            this.Name = "SearchOrdersForm";
            this.Text = "Параметры поиска заказов";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SearchOrdersForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.tbOrderNumber, 0);
            this.Controls.SetChildIndex(this.tbDocCode, 0);
            this.Controls.SetChildIndex(this.rbDocCode, 0);
            this.Controls.SetChildIndex(this.rbOrderNumber, 0);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbOrderNumber;
        private System.Windows.Forms.TextBox tbDocCode;
        private System.Windows.Forms.RadioButton rbDocCode;
        private System.Windows.Forms.RadioButton rbOrderNumber;
    }
}