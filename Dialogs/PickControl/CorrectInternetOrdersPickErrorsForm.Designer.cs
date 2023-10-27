namespace WMSOffice.Dialogs.PickControl
{
    partial class CorrectInternetOrdersPickErrorsForm
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
            this.scContent = new System.Windows.Forms.SplitContainer();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pCIODifferenceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pickControl = new WMSOffice.Data.PickControl();
            this.pnlButtons.SuspendLayout();
            this.scContent.Panel2.SuspendLayout();
            this.scContent.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pCIODifferenceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(671, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(897, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 518);
            this.pnlButtons.Size = new System.Drawing.Size(984, 43);
            // 
            // scContent
            // 
            this.scContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scContent.IsSplitterFixed = true;
            this.scContent.Location = new System.Drawing.Point(0, 0);
            this.scContent.Name = "scContent";
            this.scContent.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scContent.Panel2
            // 
            this.scContent.Panel2.Controls.Add(this.pnlContent);
            this.scContent.Size = new System.Drawing.Size(984, 512);
            this.scContent.SplitterDistance = 56;
            this.scContent.TabIndex = 101;
            // 
            // pnlContent
            // 
            this.pnlContent.AutoScroll = true;
            this.pnlContent.Controls.Add(this.label1);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(984, 452);
            this.pnlContent.TabIndex = 102;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(984, 452);
            this.label1.TabIndex = 0;
            this.label1.Text = "Контейнер для динамического контента";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pCIODifferenceBindingSource
            // 
            this.pCIODifferenceBindingSource.DataMember = "PC_IO_Difference";
            this.pCIODifferenceBindingSource.DataSource = this.pickControl;
            // 
            // pickControl
            // 
            this.pickControl.DataSetName = "PickControl";
            this.pickControl.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // CorrectInternetOrdersPickErrorsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.scContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "CorrectInternetOrdersPickErrorsForm";
            this.Text = "Исправление ошибок сборки/контроля интернет заказов";
            this.Load += new System.EventHandler(this.CorrectInternetOrdersPickErrorsForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CorrectInternetOrdersPickErrorsForm_FormClosing);
            this.Controls.SetChildIndex(this.scContent, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.scContent.Panel2.ResumeLayout(false);
            this.scContent.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pCIODifferenceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer scContent;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource pCIODifferenceBindingSource;
        private WMSOffice.Data.PickControl pickControl;
    }
}