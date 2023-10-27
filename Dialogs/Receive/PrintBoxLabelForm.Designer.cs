namespace WMSOffice.Dialogs.Receive
{
    partial class PrintBoxLabelForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbItemsInBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbEticCount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.itemsTableAdapter = new WMSOffice.Data.ReceiveTableAdapters.ItemsTableAdapter();
            this.lblItem = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSeria = new System.Windows.Forms.Label();
            this.tbItemBarCode = new WMSOffice.Controls.TextBoxScaner();
            this.lblItemBarcode = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(290, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(380, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 154);
            this.pnlButtons.Size = new System.Drawing.Size(465, 43);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(146, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 102;
            this.label1.Text = "Товар:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WMSOffice.Properties.Resources.barcode;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 91);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 103;
            this.pictureBox1.TabStop = false;
            // 
            // tbItemsInBox
            // 
            this.tbItemsInBox.Location = new System.Drawing.Point(266, 97);
            this.tbItemsInBox.Name = "tbItemsInBox";
            this.tbItemsInBox.Size = new System.Drawing.Size(187, 20);
            this.tbItemsInBox.TabIndex = 2;
            this.tbItemsInBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_SelectNextControl_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(146, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 105;
            this.label2.Text = "Количество в ящике:";
            // 
            // tbEticCount
            // 
            this.tbEticCount.Location = new System.Drawing.Point(266, 122);
            this.tbEticCount.Name = "tbEticCount";
            this.tbEticCount.Size = new System.Drawing.Size(187, 20);
            this.tbEticCount.TabIndex = 3;
            this.tbEticCount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_SelectNextControl_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(146, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 108;
            this.label3.Text = "Напечатать наклеек:";
            // 
            // itemsTableAdapter
            // 
            this.itemsTableAdapter.ClearBeforeFill = true;
            // 
            // lblItem
            // 
            this.lblItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblItem.Location = new System.Drawing.Point(193, 12);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(260, 13);
            this.lblItem.TabIndex = 109;
            this.lblItem.Text = "...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(146, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 110;
            this.label4.Text = "Серия:";
            // 
            // lblSeria
            // 
            this.lblSeria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSeria.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSeria.Location = new System.Drawing.Point(193, 37);
            this.lblSeria.Name = "lblSeria";
            this.lblSeria.Size = new System.Drawing.Size(260, 13);
            this.lblSeria.TabIndex = 111;
            this.lblSeria.Text = "...";
            // 
            // tbItemBarCode
            // 
            this.tbItemBarCode.AllowType = true;
            this.tbItemBarCode.AutoConvert = true;
            this.tbItemBarCode.DelayThreshold = 50;
            this.tbItemBarCode.Location = new System.Drawing.Point(263, 56);
            this.tbItemBarCode.Name = "tbItemBarCode";
            this.tbItemBarCode.RaiseTextChangeWithoutEnter = false;
            this.tbItemBarCode.ReadOnly = false;
            this.tbItemBarCode.Size = new System.Drawing.Size(187, 25);
            this.tbItemBarCode.TabIndex = 1;
            this.tbItemBarCode.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.tbItemBarCode.UseParentFont = false;
            this.tbItemBarCode.UseScanModeOnly = false;
            this.tbItemBarCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_SelectNextControl_KeyDown);
            // 
            // lblItemBarcode
            // 
            this.lblItemBarcode.AutoSize = true;
            this.lblItemBarcode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblItemBarcode.Location = new System.Drawing.Point(146, 62);
            this.lblItemBarcode.Name = "lblItemBarcode";
            this.lblItemBarcode.Size = new System.Drawing.Size(69, 13);
            this.lblItemBarcode.TabIndex = 113;
            this.lblItemBarcode.Text = "Ш/К товара:";
            // 
            // PrintBoxLabelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 197);
            this.Controls.Add(this.lblItemBarcode);
            this.Controls.Add(this.tbItemBarCode);
            this.Controls.Add(this.lblSeria);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblItem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbEticCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbItemsInBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "PrintBoxLabelForm";
            this.Text = "Печать штрих кода на заводской ящик";
            this.Load += new System.EventHandler(this.PrintBoxLabelForm_Load);
            this.Shown += new System.EventHandler(this.PrintBoxLabelForm_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PrintBoxLabelForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.tbItemsInBox, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.tbEticCount, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.lblItem, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.lblSeria, 0);
            this.Controls.SetChildIndex(this.tbItemBarCode, 0);
            this.Controls.SetChildIndex(this.lblItemBarcode, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tbItemsInBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbEticCount;
        private System.Windows.Forms.Label label3;
        private WMSOffice.Data.ReceiveTableAdapters.ItemsTableAdapter itemsTableAdapter;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSeria;
        private WMSOffice.Controls.TextBoxScaner tbItemBarCode;
        private System.Windows.Forms.Label lblItemBarcode;

    }
}