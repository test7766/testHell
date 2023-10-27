namespace WMSOffice.Dialogs.PickControl
{
    partial class EditPickListItemForm
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
            this.dsPickControl = new WMSOffice.Data.PickControl();
            this.bsCpEditPickListReasons = new System.Windows.Forms.BindingSource(this.components);
            this.taCpEditPickListReasons = new WMSOffice.Data.PickControlTableAdapters.CpEditPickListReasonsTableAdapter();
            this.lblUnitOfMeasureHeader = new System.Windows.Forms.Label();
            this.tbUnitOfMeasure = new System.Windows.Forms.TextBox();
            this.lblLotNumberHeader = new System.Windows.Forms.Label();
            this.tbLotNumber = new System.Windows.Forms.TextBox();
            this.lblVendorLotHeader = new System.Windows.Forms.Label();
            this.tbVendorLot = new System.Windows.Forms.TextBox();
            this.lblSpLnUnitOfMeasureHeader = new System.Windows.Forms.Label();
            this.tbSpLnUnitOfMeasure = new System.Windows.Forms.TextBox();
            this.lblSpLnLotNumberHeader = new System.Windows.Forms.Label();
            this.tbSpLnLotNumber = new System.Windows.Forms.TextBox();
            this.lblSpLnVendorLotHeader = new System.Windows.Forms.Label();
            this.tbSpLnVendorLot = new System.Windows.Forms.TextBox();
            this.groupSplit.SuspendLayout();
            this.groupReason.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsPickControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCpEditPickListReasons)).BeginInit();
            this.SuspendLayout();
            // 
            // tbCount
            // 
            this.tbCount.Enabled = true;
            this.tbCount.Text = "0";
            this.tbCount.Leave += new System.EventHandler(this.tbCount_Leave);
            // 
            // chbSplit
            // 
            this.chbSplit.CheckedChanged += new System.EventHandler(this.chbSplit_CheckedChanged);
            // 
            // groupSplit
            // 
            this.groupSplit.Controls.Add(this.lblSpLnUnitOfMeasureHeader);
            this.groupSplit.Controls.Add(this.tbSpLnUnitOfMeasure);
            this.groupSplit.Controls.Add(this.tbSpLnLotNumber);
            this.groupSplit.Controls.Add(this.lblSpLnLotNumberHeader);
            this.groupSplit.Controls.Add(this.tbSpLnVendorLot);
            this.groupSplit.Controls.Add(this.lblSpLnVendorLotHeader);
            this.groupSplit.Size = new System.Drawing.Size(838, 62);
            this.groupSplit.Controls.SetChildIndex(this.lblSpLnVendorLotHeader, 0);
            this.groupSplit.Controls.SetChildIndex(this.tbSpLnVendorLot, 0);
            this.groupSplit.Controls.SetChildIndex(this.lblSpLnLotNumberHeader, 0);
            this.groupSplit.Controls.SetChildIndex(this.tbSpLnLotNumber, 0);
            this.groupSplit.Controls.SetChildIndex(this.tbSpLnUnitOfMeasure, 0);
            this.groupSplit.Controls.SetChildIndex(this.label3, 0);
            this.groupSplit.Controls.SetChildIndex(this.lblSpLnUnitOfMeasureHeader, 0);
            this.groupSplit.Controls.SetChildIndex(this.tbSplitCount, 0);
            this.groupSplit.Controls.SetChildIndex(this.label4, 0);
            this.groupSplit.Controls.SetChildIndex(this.tbSplitLocn, 0);
            this.groupSplit.Controls.SetChildIndex(this.btnSplitLocn, 0);
            // 
            // tbSplitCount
            // 
            this.tbSplitCount.BackColor = System.Drawing.Color.Pink;
            this.tbSplitCount.Text = "0";
            // 
            // groupReason
            // 
            this.groupReason.Size = new System.Drawing.Size(838, 118);
            // 
            // cbReasons
            // 
            this.cbReasons.DataSource = this.bsCpEditPickListReasons;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnOK.Location = new System.Drawing.Point(1239, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCancel.Location = new System.Drawing.Point(1370, 8);
            // 
            // dsPickControl
            // 
            this.dsPickControl.DataSetName = "PickControl";
            this.dsPickControl.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bsCpEditPickListReasons
            // 
            this.bsCpEditPickListReasons.DataMember = "CpEditPickListReasons";
            this.bsCpEditPickListReasons.DataSource = this.dsPickControl;
            // 
            // taCpEditPickListReasons
            // 
            this.taCpEditPickListReasons.ClearBeforeFill = true;
            // 
            // lblUnitOfMeasureHeader
            // 
            this.lblUnitOfMeasureHeader.AutoSize = true;
            this.lblUnitOfMeasureHeader.Location = new System.Drawing.Point(712, 13);
            this.lblUnitOfMeasureHeader.Name = "lblUnitOfMeasureHeader";
            this.lblUnitOfMeasureHeader.Size = new System.Drawing.Size(25, 13);
            this.lblUnitOfMeasureHeader.TabIndex = 114;
            this.lblUnitOfMeasureHeader.Text = "ЕИ:";
            // 
            // tbUnitOfMeasure
            // 
            this.tbUnitOfMeasure.Location = new System.Drawing.Point(739, 10);
            this.tbUnitOfMeasure.Name = "tbUnitOfMeasure";
            this.tbUnitOfMeasure.ReadOnly = true;
            this.tbUnitOfMeasure.Size = new System.Drawing.Size(100, 20);
            this.tbUnitOfMeasure.TabIndex = 115;
            // 
            // lblLotNumberHeader
            // 
            this.lblLotNumberHeader.AutoSize = true;
            this.lblLotNumberHeader.Location = new System.Drawing.Point(547, 12);
            this.lblLotNumberHeader.Name = "lblLotNumberHeader";
            this.lblLotNumberHeader.Size = new System.Drawing.Size(47, 13);
            this.lblLotNumberHeader.TabIndex = 112;
            this.lblLotNumberHeader.Text = "Партия:";
            // 
            // tbLotNumber
            // 
            this.tbLotNumber.Location = new System.Drawing.Point(594, 10);
            this.tbLotNumber.Name = "tbLotNumber";
            this.tbLotNumber.ReadOnly = true;
            this.tbLotNumber.Size = new System.Drawing.Size(100, 20);
            this.tbLotNumber.TabIndex = 113;
            // 
            // lblVendorLotHeader
            // 
            this.lblVendorLotHeader.AutoSize = true;
            this.lblVendorLotHeader.Location = new System.Drawing.Point(388, 12);
            this.lblVendorLotHeader.Name = "lblVendorLotHeader";
            this.lblVendorLotHeader.Size = new System.Drawing.Size(41, 13);
            this.lblVendorLotHeader.TabIndex = 110;
            this.lblVendorLotHeader.Text = "Серия:";
            // 
            // tbVendorLot
            // 
            this.tbVendorLot.Location = new System.Drawing.Point(435, 9);
            this.tbVendorLot.Name = "tbVendorLot";
            this.tbVendorLot.ReadOnly = true;
            this.tbVendorLot.Size = new System.Drawing.Size(100, 20);
            this.tbVendorLot.TabIndex = 111;
            // 
            // lblSpLnUnitOfMeasureHeader
            // 
            this.lblSpLnUnitOfMeasureHeader.AutoSize = true;
            this.lblSpLnUnitOfMeasureHeader.Location = new System.Drawing.Point(700, 29);
            this.lblSpLnUnitOfMeasureHeader.Name = "lblSpLnUnitOfMeasureHeader";
            this.lblSpLnUnitOfMeasureHeader.Size = new System.Drawing.Size(25, 13);
            this.lblSpLnUnitOfMeasureHeader.TabIndex = 120;
            this.lblSpLnUnitOfMeasureHeader.Text = "ЕИ:";
            // 
            // tbSpLnUnitOfMeasure
            // 
            this.tbSpLnUnitOfMeasure.Location = new System.Drawing.Point(727, 26);
            this.tbSpLnUnitOfMeasure.Name = "tbSpLnUnitOfMeasure";
            this.tbSpLnUnitOfMeasure.ReadOnly = true;
            this.tbSpLnUnitOfMeasure.Size = new System.Drawing.Size(100, 20);
            this.tbSpLnUnitOfMeasure.TabIndex = 121;
            // 
            // lblSpLnLotNumberHeader
            // 
            this.lblSpLnLotNumberHeader.AutoSize = true;
            this.lblSpLnLotNumberHeader.Location = new System.Drawing.Point(535, 28);
            this.lblSpLnLotNumberHeader.Name = "lblSpLnLotNumberHeader";
            this.lblSpLnLotNumberHeader.Size = new System.Drawing.Size(47, 13);
            this.lblSpLnLotNumberHeader.TabIndex = 118;
            this.lblSpLnLotNumberHeader.Text = "Партия:";
            // 
            // tbSpLnLotNumber
            // 
            this.tbSpLnLotNumber.Location = new System.Drawing.Point(582, 26);
            this.tbSpLnLotNumber.Name = "tbSpLnLotNumber";
            this.tbSpLnLotNumber.ReadOnly = true;
            this.tbSpLnLotNumber.Size = new System.Drawing.Size(100, 20);
            this.tbSpLnLotNumber.TabIndex = 119;
            // 
            // lblSpLnVendorLotHeader
            // 
            this.lblSpLnVendorLotHeader.AutoSize = true;
            this.lblSpLnVendorLotHeader.Location = new System.Drawing.Point(376, 28);
            this.lblSpLnVendorLotHeader.Name = "lblSpLnVendorLotHeader";
            this.lblSpLnVendorLotHeader.Size = new System.Drawing.Size(41, 13);
            this.lblSpLnVendorLotHeader.TabIndex = 116;
            this.lblSpLnVendorLotHeader.Text = "Серия:";
            // 
            // tbSpLnVendorLot
            // 
            this.tbSpLnVendorLot.Location = new System.Drawing.Point(423, 25);
            this.tbSpLnVendorLot.Name = "tbSpLnVendorLot";
            this.tbSpLnVendorLot.ReadOnly = true;
            this.tbSpLnVendorLot.Size = new System.Drawing.Size(100, 20);
            this.tbSpLnVendorLot.TabIndex = 117;
            // 
            // EditPickListItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 275);
            this.Controls.Add(this.lblUnitOfMeasureHeader);
            this.Controls.Add(this.tbUnitOfMeasure);
            this.Controls.Add(this.lblLotNumberHeader);
            this.Controls.Add(this.tbLotNumber);
            this.Controls.Add(this.lblVendorLotHeader);
            this.Controls.Add(this.tbVendorLot);
            this.Name = "EditPickListItemForm";
            this.Text = "Корректировка товара";
            this.Load += new System.EventHandler(this.EditPickListItemForm_Load);
            this.Controls.SetChildIndex(this.tbLocn, 0);
            this.Controls.SetChildIndex(this.btnLocn, 0);
            this.Controls.SetChildIndex(this.tbCount, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.groupReason, 0);
            this.Controls.SetChildIndex(this.groupSplit, 0);
            this.Controls.SetChildIndex(this.chbSplit, 0);
            this.Controls.SetChildIndex(this.tbVendorLot, 0);
            this.Controls.SetChildIndex(this.lblVendorLotHeader, 0);
            this.Controls.SetChildIndex(this.tbLotNumber, 0);
            this.Controls.SetChildIndex(this.lblLotNumberHeader, 0);
            this.Controls.SetChildIndex(this.tbUnitOfMeasure, 0);
            this.Controls.SetChildIndex(this.lblUnitOfMeasureHeader, 0);
            this.groupSplit.ResumeLayout(false);
            this.groupSplit.PerformLayout();
            this.groupReason.ResumeLayout(false);
            this.groupReason.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsPickControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCpEditPickListReasons)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WMSOffice.Data.PickControl dsPickControl;
        private System.Windows.Forms.BindingSource bsCpEditPickListReasons;
        private WMSOffice.Data.PickControlTableAdapters.CpEditPickListReasonsTableAdapter taCpEditPickListReasons;
        private System.Windows.Forms.Label lblSpLnUnitOfMeasureHeader;
        private System.Windows.Forms.TextBox tbSpLnUnitOfMeasure;
        private System.Windows.Forms.TextBox tbSpLnLotNumber;
        private System.Windows.Forms.Label lblSpLnLotNumberHeader;
        private System.Windows.Forms.TextBox tbSpLnVendorLot;
        private System.Windows.Forms.Label lblSpLnVendorLotHeader;
        private System.Windows.Forms.Label lblUnitOfMeasureHeader;
        private System.Windows.Forms.TextBox tbUnitOfMeasure;
        private System.Windows.Forms.Label lblLotNumberHeader;
        private System.Windows.Forms.TextBox tbLotNumber;
        private System.Windows.Forms.Label lblVendorLotHeader;
        private System.Windows.Forms.TextBox tbVendorLot;
    }
}