namespace WMSOffice.Dialogs.Receive
{
    partial class RecognizeBarcodeForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.lblItemName = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.tbItemsInBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbEI = new System.Windows.Forms.TextBox();
            this.tbBarcode = new System.Windows.Forms.TextBox();
            this.itemsTableAdapter = new WMSOffice.Data.ReceiveTableAdapters.ItemsTableAdapter();
            this.itemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.receive = new WMSOffice.Data.Receive();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receive)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(146, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 115;
            this.label3.Text = "Единица измерения:";
            // 
            // lblItemName
            // 
            this.lblItemName.Location = new System.Drawing.Point(146, 57);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(220, 13);
            this.lblItemName.TabIndex = 109;
            this.lblItemName.TabStop = true;
            this.lblItemName.Text = "(выбор)";
            this.lblItemName.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblItemName_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(146, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 114;
            this.label2.Text = "Количество в ящике:";
            // 
            // tbItemsInBox
            // 
            this.tbItemsInBox.Location = new System.Drawing.Point(266, 106);
            this.tbItemsInBox.Name = "tbItemsInBox";
            this.tbItemsInBox.Size = new System.Drawing.Size(100, 20);
            this.tbItemsInBox.TabIndex = 110;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(146, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 112;
            this.label1.Text = "Товар:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::WMSOffice.Properties.Resources.dialog_question;
            this.pictureBox2.Location = new System.Drawing.Point(46, 67);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(63, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 116;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WMSOffice.Properties.Resources.barcode;
            this.pictureBox1.Location = new System.Drawing.Point(12, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 91);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 113;
            this.pictureBox1.TabStop = false;
            // 
            // tbEI
            // 
            this.tbEI.Enabled = false;
            this.tbEI.Location = new System.Drawing.Point(266, 80);
            this.tbEI.Name = "tbEI";
            this.tbEI.Size = new System.Drawing.Size(100, 20);
            this.tbEI.TabIndex = 111;
            // 
            // tbBarcode
            // 
            this.tbBarcode.Enabled = false;
            this.tbBarcode.Location = new System.Drawing.Point(12, 12);
            this.tbBarcode.Name = "tbBarcode";
            this.tbBarcode.Size = new System.Drawing.Size(354, 20);
            this.tbBarcode.TabIndex = 117;
            // 
            // itemsTableAdapter
            // 
            this.itemsTableAdapter.ClearBeforeFill = true;
            // 
            // itemsBindingSource
            // 
            this.itemsBindingSource.DataMember = "Items";
            this.itemsBindingSource.DataSource = this.receive;
            // 
            // receive
            // 
            this.receive.DataSetName = "Receive";
            this.receive.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // RecognizeBarcodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 182);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.tbBarcode);
            this.Controls.Add(this.lblItemName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbEI);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbItemsInBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "RecognizeBarcodeForm";
            this.Text = "Распознать штрих код";
            this.Load += new System.EventHandler(this.RecognizeBarcodeForm_Load);
            this.Shown += new System.EventHandler(this.RecognizeBarcodeForm_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RecognizeBarcodeForm_FormClosing);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.tbItemsInBox, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.tbEI, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.lblItemName, 0);
            this.Controls.SetChildIndex(this.tbBarcode, 0);
            this.Controls.SetChildIndex(this.pictureBox2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receive)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel lblItemName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbItemsInBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox tbEI;
        private System.Windows.Forms.TextBox tbBarcode;
        private WMSOffice.Data.ReceiveTableAdapters.ItemsTableAdapter itemsTableAdapter;
        private System.Windows.Forms.BindingSource itemsBindingSource;
        private WMSOffice.Data.Receive receive;
    }
}