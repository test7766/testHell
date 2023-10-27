namespace WMSOffice.Dialogs.Receive
{
    partial class TareWeighingSetForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnObtainWeight = new System.Windows.Forms.Button();
            this.tbBoxWeight = new System.Windows.Forms.TextBox();
            this.tbLotNumber = new System.Windows.Forms.TextBox();
            this.tbItemID = new System.Windows.Forms.TextBox();
            this.tbWarehouseID = new System.Windows.Forms.TextBox();
            this.tbBoxName = new System.Windows.Forms.TextBox();
            this.tbBoxType = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbBoxBarCode = new WMSOffice.Controls.TextBoxScaner();
            this.pnlButtons.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ш/К ящика:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Тип:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Вес:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnObtainWeight);
            this.groupBox1.Controls.Add(this.tbBoxWeight);
            this.groupBox1.Controls.Add(this.tbLotNumber);
            this.groupBox1.Controls.Add(this.tbItemID);
            this.groupBox1.Controls.Add(this.tbWarehouseID);
            this.groupBox1.Controls.Add(this.tbBoxName);
            this.groupBox1.Controls.Add(this.tbBoxType);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 168);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Спецификация ящика";
            // 
            // btnObtainWeight
            // 
            this.btnObtainWeight.Image = global::WMSOffice.Properties.Resources.Search1;
            this.btnObtainWeight.Location = new System.Drawing.Point(237, 139);
            this.btnObtainWeight.Name = "btnObtainWeight";
            this.btnObtainWeight.Size = new System.Drawing.Size(20, 20);
            this.btnObtainWeight.TabIndex = 12;
            this.btnObtainWeight.UseVisualStyleBackColor = true;
            this.btnObtainWeight.Click += new System.EventHandler(this.btnObtainWeight_Click);
            // 
            // tbBoxWeight
            // 
            this.tbBoxWeight.BackColor = System.Drawing.SystemColors.Window;
            this.tbBoxWeight.Location = new System.Drawing.Point(101, 139);
            this.tbBoxWeight.Name = "tbBoxWeight";
            this.tbBoxWeight.ReadOnly = true;
            this.tbBoxWeight.Size = new System.Drawing.Size(136, 20);
            this.tbBoxWeight.TabIndex = 11;
            // 
            // tbLotNumber
            // 
            this.tbLotNumber.BackColor = System.Drawing.SystemColors.Window;
            this.tbLotNumber.Location = new System.Drawing.Point(101, 110);
            this.tbLotNumber.Name = "tbLotNumber";
            this.tbLotNumber.ReadOnly = true;
            this.tbLotNumber.Size = new System.Drawing.Size(136, 20);
            this.tbLotNumber.TabIndex = 9;
            // 
            // tbItemID
            // 
            this.tbItemID.BackColor = System.Drawing.SystemColors.Window;
            this.tbItemID.Location = new System.Drawing.Point(101, 89);
            this.tbItemID.Name = "tbItemID";
            this.tbItemID.ReadOnly = true;
            this.tbItemID.Size = new System.Drawing.Size(136, 20);
            this.tbItemID.TabIndex = 7;
            // 
            // tbWarehouseID
            // 
            this.tbWarehouseID.BackColor = System.Drawing.SystemColors.Window;
            this.tbWarehouseID.Location = new System.Drawing.Point(101, 68);
            this.tbWarehouseID.Name = "tbWarehouseID";
            this.tbWarehouseID.ReadOnly = true;
            this.tbWarehouseID.Size = new System.Drawing.Size(136, 20);
            this.tbWarehouseID.TabIndex = 5;
            // 
            // tbBoxName
            // 
            this.tbBoxName.BackColor = System.Drawing.SystemColors.Window;
            this.tbBoxName.Location = new System.Drawing.Point(101, 40);
            this.tbBoxName.Name = "tbBoxName";
            this.tbBoxName.ReadOnly = true;
            this.tbBoxName.Size = new System.Drawing.Size(220, 20);
            this.tbBoxName.TabIndex = 3;
            // 
            // tbBoxType
            // 
            this.tbBoxType.BackColor = System.Drawing.SystemColors.Window;
            this.tbBoxType.Location = new System.Drawing.Point(101, 19);
            this.tbBoxType.Name = "tbBoxType";
            this.tbBoxType.ReadOnly = true;
            this.tbBoxType.Size = new System.Drawing.Size(220, 20);
            this.tbBoxType.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "КНН:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Партия:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Код склада:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Наименование:";
            // 
            // tbBoxBarCode
            // 
            this.tbBoxBarCode.AllowType = true;
            this.tbBoxBarCode.AutoConvert = true;
            this.tbBoxBarCode.DelayThreshold = 50;
            this.tbBoxBarCode.Location = new System.Drawing.Point(85, 9);
            this.tbBoxBarCode.Name = "tbBoxBarCode";
            this.tbBoxBarCode.RaiseTextChangeWithoutEnter = false;
            this.tbBoxBarCode.ReadOnly = false;
            this.tbBoxBarCode.Size = new System.Drawing.Size(253, 25);
            this.tbBoxBarCode.TabIndex = 1;
            this.tbBoxBarCode.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.tbBoxBarCode.UseParentFont = false;
            this.tbBoxBarCode.UseScanModeOnly = false;
            // 
            // TareWeighingSetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 262);
            this.Controls.Add(this.tbBoxBarCode);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "TareWeighingSetForm";
            this.Text = "Взвешивание ящика";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TareWeighingSetForm_FormClosing);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.tbBoxBarCode, 0);
            this.pnlButtons.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbBoxWeight;
        private System.Windows.Forms.TextBox tbLotNumber;
        private System.Windows.Forms.TextBox tbItemID;
        private System.Windows.Forms.TextBox tbWarehouseID;
        private System.Windows.Forms.TextBox tbBoxName;
        private System.Windows.Forms.TextBox tbBoxType;
        private System.Windows.Forms.Button btnObtainWeight;
        private WMSOffice.Controls.TextBoxScaner tbBoxBarCode;
    }
}