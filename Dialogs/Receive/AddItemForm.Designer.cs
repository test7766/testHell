namespace WMSOffice.Dialogs.Receive
{
    partial class AddItemForm
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
            this.lblItemName = new System.Windows.Forms.LinkLabel();
            this.lblCount = new System.Windows.Forms.Label();
            this.tbItemsInBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.receive = new WMSOffice.Data.Receive();
            this.itemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.itemsTableAdapter = new WMSOffice.Data.ReceiveTableAdapters.ItemsTableAdapter();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(199, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(289, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 115);
            this.pnlButtons.Size = new System.Drawing.Size(376, 43);
            // 
            // lblItemName
            // 
            this.lblItemName.Location = new System.Drawing.Point(146, 31);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(220, 13);
            this.lblItemName.TabIndex = 109;
            this.lblItemName.TabStop = true;
            this.lblItemName.Text = "(выбор)";
            this.lblItemName.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblItemName_LinkClicked);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(146, 57);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(69, 13);
            this.lblCount.TabIndex = 114;
            this.lblCount.Text = "Количество:";
            // 
            // tbItemsInBox
            // 
            this.tbItemsInBox.Location = new System.Drawing.Point(266, 54);
            this.tbItemsInBox.Name = "tbItemsInBox";
            this.tbItemsInBox.Size = new System.Drawing.Size(100, 20);
            this.tbItemsInBox.TabIndex = 110;
            this.tbItemsInBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbItemsInBox_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(146, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 112;
            this.label1.Text = "Товар:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WMSOffice.Properties.Resources.drug_basket;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 91);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 113;
            this.pictureBox1.TabStop = false;
            // 
            // receive
            // 
            this.receive.DataSetName = "Receive";
            this.receive.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // itemsBindingSource
            // 
            this.itemsBindingSource.DataMember = "Items";
            this.itemsBindingSource.DataSource = this.receive;
            // 
            // itemsTableAdapter
            // 
            this.itemsTableAdapter.ClearBeforeFill = true;
            // 
            // AddItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 158);
            this.Controls.Add(this.lblItemName);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.tbItemsInBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "AddItemForm";
            this.Text = "Добавить товар без штрих кода";
            this.Load += new System.EventHandler(this.AddItemForm_Load);
            this.Shown += new System.EventHandler(this.AddItemForm_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddItemForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.tbItemsInBox, 0);
            this.Controls.SetChildIndex(this.lblCount, 0);
            this.Controls.SetChildIndex(this.lblItemName, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lblItemName;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.TextBox tbItemsInBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private WMSOffice.Data.Receive receive;
        private System.Windows.Forms.BindingSource itemsBindingSource;
        private WMSOffice.Data.ReceiveTableAdapters.ItemsTableAdapter itemsTableAdapter;
    }
}