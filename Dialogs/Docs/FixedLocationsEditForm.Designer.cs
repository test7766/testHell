namespace WMSOffice.Dialogs.Docs
{
    partial class FixedLocationsEditForm
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
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.tbUnitOfMeasure = new System.Windows.Forms.TextBox();
            this.tbItemName = new System.Windows.Forms.TextBox();
            this.tbWarehouseName = new System.Windows.Forms.TextBox();
            this.stbItemID = new WMSOffice.Controls.SearchTextBox();
            this.stbWarehouseID = new WMSOffice.Controls.SearchTextBox();
            this.lblUnitOfMeasure = new System.Windows.Forms.Label();
            this.lblItemID = new System.Windows.Forms.Label();
            this.lblWarehouseID = new System.Windows.Forms.Label();
            this.stbUnitOfMeasure = new WMSOffice.Controls.SearchTextBox();
            this.tbLocation = new System.Windows.Forms.TextBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblQtyInTE = new System.Windows.Forms.Label();
            this.lblCountTE = new System.Windows.Forms.Label();
            this.tbQtyInTE = new System.Windows.Forms.TextBox();
            this.tbCountTE = new System.Windows.Forms.TextBox();
            this.lblReplMaxQty = new System.Windows.Forms.Label();
            this.tbPointMin = new System.Windows.Forms.TextBox();
            this.lblPointNorm = new System.Windows.Forms.Label();
            this.tbPointNorm = new System.Windows.Forms.TextBox();
            this.lblPointMin = new System.Windows.Forms.Label();
            this.tbReplMaxQty = new System.Windows.Forms.TextBox();
            this.pnlButtons.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(1881, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1971, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 228);
            this.pnlButtons.Size = new System.Drawing.Size(594, 43);
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.tbUnitOfMeasure);
            this.pnlFilter.Controls.Add(this.tbItemName);
            this.pnlFilter.Controls.Add(this.tbWarehouseName);
            this.pnlFilter.Controls.Add(this.stbItemID);
            this.pnlFilter.Controls.Add(this.stbWarehouseID);
            this.pnlFilter.Controls.Add(this.lblUnitOfMeasure);
            this.pnlFilter.Controls.Add(this.lblItemID);
            this.pnlFilter.Controls.Add(this.lblWarehouseID);
            this.pnlFilter.Controls.Add(this.stbUnitOfMeasure);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(594, 100);
            this.pnlFilter.TabIndex = 101;
            // 
            // tbUnitOfMeasure
            // 
            this.tbUnitOfMeasure.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUnitOfMeasure.BackColor = System.Drawing.SystemColors.Window;
            this.tbUnitOfMeasure.Location = new System.Drawing.Point(254, 67);
            this.tbUnitOfMeasure.Name = "tbUnitOfMeasure";
            this.tbUnitOfMeasure.ReadOnly = true;
            this.tbUnitOfMeasure.Size = new System.Drawing.Size(328, 20);
            this.tbUnitOfMeasure.TabIndex = 8;
            this.tbUnitOfMeasure.TabStop = false;
            // 
            // tbItemName
            // 
            this.tbItemName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbItemName.BackColor = System.Drawing.SystemColors.Window;
            this.tbItemName.Location = new System.Drawing.Point(254, 38);
            this.tbItemName.Name = "tbItemName";
            this.tbItemName.ReadOnly = true;
            this.tbItemName.Size = new System.Drawing.Size(328, 20);
            this.tbItemName.TabIndex = 5;
            this.tbItemName.TabStop = false;
            // 
            // tbWarehouseName
            // 
            this.tbWarehouseName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbWarehouseName.BackColor = System.Drawing.SystemColors.Window;
            this.tbWarehouseName.Location = new System.Drawing.Point(254, 9);
            this.tbWarehouseName.Name = "tbWarehouseName";
            this.tbWarehouseName.ReadOnly = true;
            this.tbWarehouseName.Size = new System.Drawing.Size(328, 20);
            this.tbWarehouseName.TabIndex = 2;
            this.tbWarehouseName.TabStop = false;
            // 
            // stbItemID
            // 
            this.stbItemID.Location = new System.Drawing.Point(128, 38);
            this.stbItemID.Name = "stbItemID";
            this.stbItemID.ReadOnly = false;
            this.stbItemID.Size = new System.Drawing.Size(120, 20);
            this.stbItemID.TabIndex = 4;
            this.stbItemID.UserID = ((long)(0));
            this.stbItemID.Value = null;
            this.stbItemID.ValueReferenceQuery = null;
            // 
            // stbWarehouseID
            // 
            this.stbWarehouseID.Location = new System.Drawing.Point(128, 9);
            this.stbWarehouseID.Name = "stbWarehouseID";
            this.stbWarehouseID.ReadOnly = false;
            this.stbWarehouseID.Size = new System.Drawing.Size(120, 20);
            this.stbWarehouseID.TabIndex = 1;
            this.stbWarehouseID.UserID = ((long)(0));
            this.stbWarehouseID.Value = null;
            this.stbWarehouseID.ValueReferenceQuery = null;
            // 
            // lblUnitOfMeasure
            // 
            this.lblUnitOfMeasure.AutoSize = true;
            this.lblUnitOfMeasure.Location = new System.Drawing.Point(13, 71);
            this.lblUnitOfMeasure.Name = "lblUnitOfMeasure";
            this.lblUnitOfMeasure.Size = new System.Drawing.Size(109, 13);
            this.lblUnitOfMeasure.TabIndex = 6;
            this.lblUnitOfMeasure.Text = "Единица измерения";
            // 
            // lblItemID
            // 
            this.lblItemID.AutoSize = true;
            this.lblItemID.Location = new System.Drawing.Point(13, 42);
            this.lblItemID.Name = "lblItemID";
            this.lblItemID.Size = new System.Drawing.Size(64, 13);
            this.lblItemID.TabIndex = 3;
            this.lblItemID.Text = "Код товара";
            // 
            // lblWarehouseID
            // 
            this.lblWarehouseID.AutoSize = true;
            this.lblWarehouseID.Location = new System.Drawing.Point(13, 13);
            this.lblWarehouseID.Name = "lblWarehouseID";
            this.lblWarehouseID.Size = new System.Drawing.Size(48, 13);
            this.lblWarehouseID.TabIndex = 0;
            this.lblWarehouseID.Text = "Филиал";
            // 
            // stbUnitOfMeasure
            // 
            this.stbUnitOfMeasure.Location = new System.Drawing.Point(128, 67);
            this.stbUnitOfMeasure.Name = "stbUnitOfMeasure";
            this.stbUnitOfMeasure.ReadOnly = false;
            this.stbUnitOfMeasure.Size = new System.Drawing.Size(120, 20);
            this.stbUnitOfMeasure.TabIndex = 7;
            this.stbUnitOfMeasure.UserID = ((long)(0));
            this.stbUnitOfMeasure.Value = null;
            this.stbUnitOfMeasure.ValueReferenceQuery = null;
            // 
            // tbLocation
            // 
            this.tbLocation.Location = new System.Drawing.Point(128, 109);
            this.tbLocation.Name = "tbLocation";
            this.tbLocation.Size = new System.Drawing.Size(120, 20);
            this.tbLocation.TabIndex = 102;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(12, 113);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(100, 13);
            this.lblLocation.TabIndex = 9;
            this.lblLocation.Text = "Местонахождение";
            // 
            // lblQtyInTE
            // 
            this.lblQtyInTE.AutoSize = true;
            this.lblQtyInTE.Location = new System.Drawing.Point(13, 149);
            this.lblQtyInTE.Name = "lblQtyInTE";
            this.lblQtyInTE.Size = new System.Drawing.Size(67, 13);
            this.lblQtyInTE.TabIndex = 115;
            this.lblQtyInTE.Text = "Кол-во в ТЕ";
            // 
            // lblCountTE
            // 
            this.lblCountTE.AutoSize = true;
            this.lblCountTE.Location = new System.Drawing.Point(13, 185);
            this.lblCountTE.Name = "lblCountTE";
            this.lblCountTE.Size = new System.Drawing.Size(101, 13);
            this.lblCountTE.TabIndex = 116;
            this.lblCountTE.Text = "Кол-во ТЕ в месте";
            // 
            // tbQtyInTE
            // 
            this.tbQtyInTE.Location = new System.Drawing.Point(128, 145);
            this.tbQtyInTE.Name = "tbQtyInTE";
            this.tbQtyInTE.Size = new System.Drawing.Size(120, 20);
            this.tbQtyInTE.TabIndex = 117;
            this.tbQtyInTE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbCountTE
            // 
            this.tbCountTE.BackColor = System.Drawing.SystemColors.Info;
            this.tbCountTE.Location = new System.Drawing.Point(128, 181);
            this.tbCountTE.Name = "tbCountTE";
            this.tbCountTE.ReadOnly = true;
            this.tbCountTE.Size = new System.Drawing.Size(120, 20);
            this.tbCountTE.TabIndex = 118;
            this.tbCountTE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblReplMaxQty
            // 
            this.lblReplMaxQty.AutoSize = true;
            this.lblReplMaxQty.Location = new System.Drawing.Point(310, 113);
            this.lblReplMaxQty.Name = "lblReplMaxQty";
            this.lblReplMaxQty.Size = new System.Drawing.Size(136, 13);
            this.lblReplMaxQty.TabIndex = 119;
            this.lblReplMaxQty.Text = "Макс. кол-во пополнения";
            // 
            // tbPointMin
            // 
            this.tbPointMin.Location = new System.Drawing.Point(462, 181);
            this.tbPointMin.Name = "tbPointMin";
            this.tbPointMin.Size = new System.Drawing.Size(120, 20);
            this.tbPointMin.TabIndex = 124;
            this.tbPointMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPointNorm
            // 
            this.lblPointNorm.AutoSize = true;
            this.lblPointNorm.Location = new System.Drawing.Point(310, 149);
            this.lblPointNorm.Name = "lblPointNorm";
            this.lblPointNorm.Size = new System.Drawing.Size(132, 13);
            this.lblPointNorm.TabIndex = 120;
            this.lblPointNorm.Text = "Точка норм. пополнения";
            // 
            // tbPointNorm
            // 
            this.tbPointNorm.Location = new System.Drawing.Point(462, 145);
            this.tbPointNorm.Name = "tbPointNorm";
            this.tbPointNorm.Size = new System.Drawing.Size(120, 20);
            this.tbPointNorm.TabIndex = 123;
            this.tbPointNorm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPointMin
            // 
            this.lblPointMin.AutoSize = true;
            this.lblPointMin.Location = new System.Drawing.Point(310, 185);
            this.lblPointMin.Name = "lblPointMin";
            this.lblPointMin.Size = new System.Drawing.Size(126, 13);
            this.lblPointMin.TabIndex = 121;
            this.lblPointMin.Text = "Точка мин. пополнения";
            // 
            // tbReplMaxQty
            // 
            this.tbReplMaxQty.Location = new System.Drawing.Point(462, 109);
            this.tbReplMaxQty.Name = "tbReplMaxQty";
            this.tbReplMaxQty.Size = new System.Drawing.Size(120, 20);
            this.tbReplMaxQty.TabIndex = 122;
            this.tbReplMaxQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FixedLocationsEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 271);
            this.Controls.Add(this.lblReplMaxQty);
            this.Controls.Add(this.tbPointMin);
            this.Controls.Add(this.lblPointNorm);
            this.Controls.Add(this.tbPointNorm);
            this.Controls.Add(this.lblPointMin);
            this.Controls.Add(this.tbReplMaxQty);
            this.Controls.Add(this.lblQtyInTE);
            this.Controls.Add(this.lblCountTE);
            this.Controls.Add(this.tbQtyInTE);
            this.Controls.Add(this.tbCountTE);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.tbLocation);
            this.Controls.Add(this.pnlFilter);
            this.Name = "FixedLocationsEditForm";
            this.Text = "Редактор фиксированных мест";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FixedLocationsEditForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.pnlFilter, 0);
            this.Controls.SetChildIndex(this.tbLocation, 0);
            this.Controls.SetChildIndex(this.lblLocation, 0);
            this.Controls.SetChildIndex(this.tbCountTE, 0);
            this.Controls.SetChildIndex(this.tbQtyInTE, 0);
            this.Controls.SetChildIndex(this.lblCountTE, 0);
            this.Controls.SetChildIndex(this.lblQtyInTE, 0);
            this.Controls.SetChildIndex(this.tbReplMaxQty, 0);
            this.Controls.SetChildIndex(this.lblPointMin, 0);
            this.Controls.SetChildIndex(this.tbPointNorm, 0);
            this.Controls.SetChildIndex(this.lblPointNorm, 0);
            this.Controls.SetChildIndex(this.tbPointMin, 0);
            this.Controls.SetChildIndex(this.lblReplMaxQty, 0);
            this.pnlButtons.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.TextBox tbUnitOfMeasure;
        private System.Windows.Forms.TextBox tbItemName;
        private System.Windows.Forms.TextBox tbWarehouseName;
        private WMSOffice.Controls.SearchTextBox stbItemID;
        private WMSOffice.Controls.SearchTextBox stbWarehouseID;
        private System.Windows.Forms.Label lblUnitOfMeasure;
        private System.Windows.Forms.Label lblItemID;
        private System.Windows.Forms.Label lblWarehouseID;
        private WMSOffice.Controls.SearchTextBox stbUnitOfMeasure;
        private System.Windows.Forms.TextBox tbLocation;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblQtyInTE;
        private System.Windows.Forms.Label lblCountTE;
        private System.Windows.Forms.TextBox tbQtyInTE;
        private System.Windows.Forms.TextBox tbCountTE;
        private System.Windows.Forms.Label lblReplMaxQty;
        private System.Windows.Forms.TextBox tbPointMin;
        private System.Windows.Forms.Label lblPointNorm;
        private System.Windows.Forms.TextBox tbPointNorm;
        private System.Windows.Forms.Label lblPointMin;
        private System.Windows.Forms.TextBox tbReplMaxQty;
    }
}