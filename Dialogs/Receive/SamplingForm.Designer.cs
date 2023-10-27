namespace WMSOffice.Dialogs.Receive
{
    partial class SamplingForm
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
            this.lblScanItemCode = new System.Windows.Forms.Label();
            this.btnAddItemWithoutBarcode = new System.Windows.Forms.Button();
            this.lblWithoutBarcode = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblScanBasketCode = new System.Windows.Forms.Label();
            this.tbsBasketCode = new WMSOffice.Controls.TextBoxScaner();
            this.tbsItemCode = new WMSOffice.Controls.TextBoxScaner();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlSampleQuantity = new System.Windows.Forms.Panel();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.tbsSampleCode = new WMSOffice.Controls.TextBoxScaner();
            this.lblScanSampleCode = new System.Windows.Forms.Label();
            this.pnlItem = new System.Windows.Forms.Panel();
            this.pnlSample = new System.Windows.Forms.Panel();
            this.pnlBasket = new System.Windows.Forms.Panel();
            this.pnlSampleQuantity.SuspendLayout();
            this.pnlItem.SuspendLayout();
            this.pnlSample.SuspendLayout();
            this.pnlBasket.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblScanItemCode
            // 
            this.lblScanItemCode.AutoSize = true;
            this.lblScanItemCode.BackColor = System.Drawing.SystemColors.Info;
            this.lblScanItemCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblScanItemCode.ForeColor = System.Drawing.Color.Blue;
            this.lblScanItemCode.Location = new System.Drawing.Point(13, 12);
            this.lblScanItemCode.Name = "lblScanItemCode";
            this.lblScanItemCode.Size = new System.Drawing.Size(184, 15);
            this.lblScanItemCode.TabIndex = 0;
            this.lblScanItemCode.Text = "Отсканируйте код товара:";
            this.lblScanItemCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAddItemWithoutBarcode
            // 
            this.btnAddItemWithoutBarcode.Location = new System.Drawing.Point(248, 60);
            this.btnAddItemWithoutBarcode.Name = "btnAddItemWithoutBarcode";
            this.btnAddItemWithoutBarcode.Size = new System.Drawing.Size(75, 23);
            this.btnAddItemWithoutBarcode.TabIndex = 3;
            this.btnAddItemWithoutBarcode.Text = "Добавить";
            this.btnAddItemWithoutBarcode.UseVisualStyleBackColor = true;
            this.btnAddItemWithoutBarcode.Click += new System.EventHandler(this.btnAddItemWithoutBarcode_Click);
            // 
            // lblWithoutBarcode
            // 
            this.lblWithoutBarcode.AutoSize = true;
            this.lblWithoutBarcode.BackColor = System.Drawing.SystemColors.Info;
            this.lblWithoutBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblWithoutBarcode.ForeColor = System.Drawing.Color.Blue;
            this.lblWithoutBarcode.Location = new System.Drawing.Point(13, 63);
            this.lblWithoutBarcode.Name = "lblWithoutBarcode";
            this.lblWithoutBarcode.Size = new System.Drawing.Size(229, 15);
            this.lblWithoutBarcode.TabIndex = 2;
            this.lblWithoutBarcode.Text = "Добавить товар без штрих-кода:";
            this.lblWithoutBarcode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(366, 266);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblScanBasketCode
            // 
            this.lblScanBasketCode.AutoSize = true;
            this.lblScanBasketCode.BackColor = System.Drawing.SystemColors.Info;
            this.lblScanBasketCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblScanBasketCode.ForeColor = System.Drawing.Color.Blue;
            this.lblScanBasketCode.Location = new System.Drawing.Point(15, 12);
            this.lblScanBasketCode.Name = "lblScanBasketCode";
            this.lblScanBasketCode.Size = new System.Drawing.Size(192, 15);
            this.lblScanBasketCode.TabIndex = 0;
            this.lblScanBasketCode.Text = "Отсканируйте код корзины:";
            this.lblScanBasketCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbsBasketCode
            // 
            this.tbsBasketCode.AllowType = true;
            this.tbsBasketCode.AutoConvert = true;
            this.tbsBasketCode.DelayThreshold = 50;
            this.tbsBasketCode.Location = new System.Drawing.Point(17, 30);
            this.tbsBasketCode.Name = "tbsBasketCode";
            this.tbsBasketCode.RaiseTextChangeWithoutEnter = false;
            this.tbsBasketCode.ReadOnly = false;
            this.tbsBasketCode.Size = new System.Drawing.Size(424, 25);
            this.tbsBasketCode.TabIndex = 1;
            this.tbsBasketCode.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.tbsBasketCode.UseParentFont = false;
            this.tbsBasketCode.UseScanModeOnly = false;
            this.tbsBasketCode.TextChanged += new System.EventHandler(this.tbsBasketCode_TextChanged);
            // 
            // tbsItemCode
            // 
            this.tbsItemCode.AllowType = true;
            this.tbsItemCode.AutoConvert = true;
            this.tbsItemCode.DelayThreshold = 50;
            this.tbsItemCode.Location = new System.Drawing.Point(16, 30);
            this.tbsItemCode.Name = "tbsItemCode";
            this.tbsItemCode.RaiseTextChangeWithoutEnter = false;
            this.tbsItemCode.ReadOnly = false;
            this.tbsItemCode.Size = new System.Drawing.Size(425, 25);
            this.tbsItemCode.TabIndex = 1;
            this.tbsItemCode.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.tbsItemCode.UseParentFont = false;
            this.tbsItemCode.UseScanModeOnly = false;
            this.tbsItemCode.TextChanged += new System.EventHandler(this.tbsItemCode_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Количество образцов для отбора:";
            // 
            // pnlSampleQuantity
            // 
            this.pnlSampleQuantity.BackColor = System.Drawing.SystemColors.Info;
            this.pnlSampleQuantity.Controls.Add(this.lblQuantity);
            this.pnlSampleQuantity.Controls.Add(this.label1);
            this.pnlSampleQuantity.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSampleQuantity.Location = new System.Drawing.Point(0, 0);
            this.pnlSampleQuantity.Name = "pnlSampleQuantity";
            this.pnlSampleQuantity.Size = new System.Drawing.Size(449, 40);
            this.pnlSampleQuantity.TabIndex = 0;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblQuantity.ForeColor = System.Drawing.Color.Red;
            this.lblQuantity.Location = new System.Drawing.Point(282, 10);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(0, 20);
            this.lblQuantity.TabIndex = 1;
            // 
            // tbsSampleCode
            // 
            this.tbsSampleCode.AllowType = true;
            this.tbsSampleCode.AutoConvert = true;
            this.tbsSampleCode.DelayThreshold = 50;
            this.tbsSampleCode.Location = new System.Drawing.Point(17, 30);
            this.tbsSampleCode.Name = "tbsSampleCode";
            this.tbsSampleCode.RaiseTextChangeWithoutEnter = false;
            this.tbsSampleCode.ReadOnly = false;
            this.tbsSampleCode.Size = new System.Drawing.Size(424, 25);
            this.tbsSampleCode.TabIndex = 1;
            this.tbsSampleCode.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.tbsSampleCode.UseParentFont = false;
            this.tbsSampleCode.UseScanModeOnly = false;
            // 
            // lblScanSampleCode
            // 
            this.lblScanSampleCode.AutoSize = true;
            this.lblScanSampleCode.BackColor = System.Drawing.SystemColors.Info;
            this.lblScanSampleCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblScanSampleCode.ForeColor = System.Drawing.Color.Blue;
            this.lblScanSampleCode.Location = new System.Drawing.Point(15, 12);
            this.lblScanSampleCode.Name = "lblScanSampleCode";
            this.lblScanSampleCode.Size = new System.Drawing.Size(256, 15);
            this.lblScanSampleCode.TabIndex = 0;
            this.lblScanSampleCode.Text = "Отсканируйте код этикетки образца:";
            this.lblScanSampleCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlItem
            // 
            this.pnlItem.Controls.Add(this.tbsItemCode);
            this.pnlItem.Controls.Add(this.lblScanItemCode);
            this.pnlItem.Controls.Add(this.lblWithoutBarcode);
            this.pnlItem.Controls.Add(this.btnAddItemWithoutBarcode);
            this.pnlItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlItem.Location = new System.Drawing.Point(0, 40);
            this.pnlItem.Name = "pnlItem";
            this.pnlItem.Size = new System.Drawing.Size(449, 90);
            this.pnlItem.TabIndex = 1;
            // 
            // pnlSample
            // 
            this.pnlSample.Controls.Add(this.tbsSampleCode);
            this.pnlSample.Controls.Add(this.lblScanSampleCode);
            this.pnlSample.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSample.Location = new System.Drawing.Point(0, 130);
            this.pnlSample.Name = "pnlSample";
            this.pnlSample.Size = new System.Drawing.Size(449, 65);
            this.pnlSample.TabIndex = 2;
            // 
            // pnlBasket
            // 
            this.pnlBasket.Controls.Add(this.tbsBasketCode);
            this.pnlBasket.Controls.Add(this.lblScanBasketCode);
            this.pnlBasket.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBasket.Location = new System.Drawing.Point(0, 195);
            this.pnlBasket.Name = "pnlBasket";
            this.pnlBasket.Size = new System.Drawing.Size(449, 65);
            this.pnlBasket.TabIndex = 3;
            // 
            // SamplingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(449, 300);
            this.Controls.Add(this.pnlBasket);
            this.Controls.Add(this.pnlSample);
            this.Controls.Add(this.pnlItem);
            this.Controls.Add(this.pnlSampleQuantity);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SamplingForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Отбор образца";
            this.pnlSampleQuantity.ResumeLayout(false);
            this.pnlSampleQuantity.PerformLayout();
            this.pnlItem.ResumeLayout(false);
            this.pnlItem.PerformLayout();
            this.pnlSample.ResumeLayout(false);
            this.pnlSample.PerformLayout();
            this.pnlBasket.ResumeLayout(false);
            this.pnlBasket.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblScanItemCode;
        private WMSOffice.Controls.TextBoxScaner tbsItemCode;
        private System.Windows.Forms.Button btnAddItemWithoutBarcode;
        private System.Windows.Forms.Label lblWithoutBarcode;
        private System.Windows.Forms.Button btnCancel;
        private WMSOffice.Controls.TextBoxScaner tbsBasketCode;
        private System.Windows.Forms.Label lblScanBasketCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlSampleQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private WMSOffice.Controls.TextBoxScaner tbsSampleCode;
        private System.Windows.Forms.Label lblScanSampleCode;
        private System.Windows.Forms.Panel pnlItem;
        private System.Windows.Forms.Panel pnlSample;
        private System.Windows.Forms.Panel pnlBasket;
    }
}