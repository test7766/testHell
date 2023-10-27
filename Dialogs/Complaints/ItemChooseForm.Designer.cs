namespace WMSOffice.Dialogs.Complaints
{
    partial class ItemChooseForm
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
            this.lblItemCode = new System.Windows.Forms.Label();
            this.tbItemCode = new System.Windows.Forms.TextBox();
            this.tbVendorLot = new System.Windows.Forms.TextBox();
            this.lblVendorLot = new System.Windows.Forms.Label();
            this.tbUnitOfMeasure = new System.Windows.Forms.TextBox();
            this.lblUnitOfMeasure = new System.Windows.Forms.Label();
            this.tbItemNameFound = new System.Windows.Forms.TextBox();
            this.lblItemName = new System.Windows.Forms.Label();
            this.tbManufacturer = new System.Windows.Forms.TextBox();
            this.lblManufacturer = new System.Windows.Forms.Label();
            this.btnSearchItemByCode = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbQuantity = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.btnSearchVendorLot = new System.Windows.Forms.Button();
            this.btnSearchItemByName = new System.Windows.Forms.Button();
            this.tbItemName = new System.Windows.Forms.TextBox();
            this.cmsItemSearchModes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsiSearchByItemCode = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsiSearchByItemCodeExcludeDocs = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsiSearchByItemCodeInDocs = new System.Windows.Forms.ToolStripMenuItem();
            this.cbExcludeDocs = new System.Windows.Forms.CheckBox();
            this.cmsItemSearchModes.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblItemCode
            // 
            this.lblItemCode.AutoSize = true;
            this.lblItemCode.Location = new System.Drawing.Point(12, 10);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.Size = new System.Drawing.Size(67, 13);
            this.lblItemCode.TabIndex = 0;
            this.lblItemCode.Text = "Код товара:";
            // 
            // tbItemCode
            // 
            this.tbItemCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbItemCode.Location = new System.Drawing.Point(12, 26);
            this.tbItemCode.MaxLength = 7;
            this.tbItemCode.Name = "tbItemCode";
            this.tbItemCode.Size = new System.Drawing.Size(67, 20);
            this.tbItemCode.TabIndex = 1;
            this.tbItemCode.Text = "0";
            this.tbItemCode.TextChanged += new System.EventHandler(this.tbItemCode_TextChanged);
            // 
            // tbVendorLot
            // 
            this.tbVendorLot.Location = new System.Drawing.Point(12, 169);
            this.tbVendorLot.Name = "tbVendorLot";
            this.tbVendorLot.ReadOnly = true;
            this.tbVendorLot.Size = new System.Drawing.Size(246, 20);
            this.tbVendorLot.TabIndex = 10;
            // 
            // lblVendorLot
            // 
            this.lblVendorLot.AutoSize = true;
            this.lblVendorLot.Location = new System.Drawing.Point(12, 153);
            this.lblVendorLot.Name = "lblVendorLot";
            this.lblVendorLot.Size = new System.Drawing.Size(41, 13);
            this.lblVendorLot.TabIndex = 9;
            this.lblVendorLot.Text = "Серия:";
            // 
            // tbUnitOfMeasure
            // 
            this.tbUnitOfMeasure.Location = new System.Drawing.Point(191, 210);
            this.tbUnitOfMeasure.Name = "tbUnitOfMeasure";
            this.tbUnitOfMeasure.ReadOnly = true;
            this.tbUnitOfMeasure.Size = new System.Drawing.Size(67, 20);
            this.tbUnitOfMeasure.TabIndex = 15;
            this.tbUnitOfMeasure.Text = "IT";
            // 
            // lblUnitOfMeasure
            // 
            this.lblUnitOfMeasure.AutoSize = true;
            this.lblUnitOfMeasure.Location = new System.Drawing.Point(173, 194);
            this.lblUnitOfMeasure.Name = "lblUnitOfMeasure";
            this.lblUnitOfMeasure.Size = new System.Drawing.Size(85, 13);
            this.lblUnitOfMeasure.TabIndex = 14;
            this.lblUnitOfMeasure.Text = "Ед. измерения:";
            // 
            // tbItemNameFound
            // 
            this.tbItemNameFound.Location = new System.Drawing.Point(12, 91);
            this.tbItemNameFound.Name = "tbItemNameFound";
            this.tbItemNameFound.ReadOnly = true;
            this.tbItemNameFound.Size = new System.Drawing.Size(408, 20);
            this.tbItemNameFound.TabIndex = 6;
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Location = new System.Drawing.Point(12, 49);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(124, 13);
            this.lblItemName.TabIndex = 3;
            this.lblItemName.Text = "Наименование товара:";
            // 
            // tbManufacturer
            // 
            this.tbManufacturer.Location = new System.Drawing.Point(12, 130);
            this.tbManufacturer.Name = "tbManufacturer";
            this.tbManufacturer.ReadOnly = true;
            this.tbManufacturer.Size = new System.Drawing.Size(408, 20);
            this.tbManufacturer.TabIndex = 8;
            // 
            // lblManufacturer
            // 
            this.lblManufacturer.AutoSize = true;
            this.lblManufacturer.Location = new System.Drawing.Point(12, 114);
            this.lblManufacturer.Name = "lblManufacturer";
            this.lblManufacturer.Size = new System.Drawing.Size(89, 13);
            this.lblManufacturer.TabIndex = 7;
            this.lblManufacturer.Text = "Производитель:";
            // 
            // btnSearchItemByCode
            // 
            this.btnSearchItemByCode.Location = new System.Drawing.Point(264, 25);
            this.btnSearchItemByCode.Name = "btnSearchItemByCode";
            this.btnSearchItemByCode.Size = new System.Drawing.Size(156, 23);
            this.btnSearchItemByCode.TabIndex = 2;
            this.btnSearchItemByCode.Text = "Поиск по коду...";
            this.btnSearchItemByCode.UseVisualStyleBackColor = true;
            this.btnSearchItemByCode.Click += new System.EventHandler(this.btnSearchItemByCode_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(264, 244);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 16;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(345, 244);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // tbQuantity
            // 
            this.tbQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbQuantity.Location = new System.Drawing.Point(12, 210);
            this.tbQuantity.MaxLength = 10;
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.Size = new System.Drawing.Size(67, 20);
            this.tbQuantity.TabIndex = 13;
            this.tbQuantity.Text = "0";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(12, 194);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(69, 13);
            this.lblQuantity.TabIndex = 12;
            this.lblQuantity.Text = "Количество:";
            // 
            // btnSearchVendorLot
            // 
            this.btnSearchVendorLot.Enabled = false;
            this.btnSearchVendorLot.Location = new System.Drawing.Point(264, 167);
            this.btnSearchVendorLot.Name = "btnSearchVendorLot";
            this.btnSearchVendorLot.Size = new System.Drawing.Size(156, 23);
            this.btnSearchVendorLot.TabIndex = 11;
            this.btnSearchVendorLot.Text = "Выбор серии";
            this.btnSearchVendorLot.UseVisualStyleBackColor = true;
            this.btnSearchVendorLot.Click += new System.EventHandler(this.btnSearchVendorLot_Click);
            // 
            // btnSearchItemByName
            // 
            this.btnSearchItemByName.Location = new System.Drawing.Point(264, 63);
            this.btnSearchItemByName.Name = "btnSearchItemByName";
            this.btnSearchItemByName.Size = new System.Drawing.Size(156, 23);
            this.btnSearchItemByName.TabIndex = 5;
            this.btnSearchItemByName.Text = "Поиск по наименованию";
            this.btnSearchItemByName.UseVisualStyleBackColor = true;
            this.btnSearchItemByName.Click += new System.EventHandler(this.btnSearchItemByName_Click);
            // 
            // tbItemName
            // 
            this.tbItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbItemName.Location = new System.Drawing.Point(12, 65);
            this.tbItemName.MaxLength = 30;
            this.tbItemName.Name = "tbItemName";
            this.tbItemName.Size = new System.Drawing.Size(246, 20);
            this.tbItemName.TabIndex = 4;
            this.tbItemName.TextChanged += new System.EventHandler(this.tbItemCode_TextChanged);
            // 
            // cmsItemSearchModes
            // 
            this.cmsItemSearchModes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsiSearchByItemCode,
            this.cmsiSearchByItemCodeExcludeDocs,
            this.cmsiSearchByItemCodeInDocs});
            this.cmsItemSearchModes.Name = "cmsItemSearchModes";
            this.cmsItemSearchModes.Size = new System.Drawing.Size(252, 70);
            // 
            // cmsiSearchByItemCode
            // 
            this.cmsiSearchByItemCode.Name = "cmsiSearchByItemCode";
            this.cmsiSearchByItemCode.Size = new System.Drawing.Size(251, 22);
            this.cmsiSearchByItemCode.Text = "Поиск по коду";
            this.cmsiSearchByItemCode.Click += new System.EventHandler(this.cmsiSearchByItemCode_Click);
            // 
            // cmsiSearchByItemCodeExcludeDocs
            // 
            this.cmsiSearchByItemCodeExcludeDocs.Name = "cmsiSearchByItemCodeExcludeDocs";
            this.cmsiSearchByItemCodeExcludeDocs.Size = new System.Drawing.Size(251, 22);
            this.cmsiSearchByItemCodeExcludeDocs.Text = "Поиск по коду отдельно от р/н";
            this.cmsiSearchByItemCodeExcludeDocs.Click += new System.EventHandler(this.cmsiSearchByItemCodeExcludeDocs_Click);
            // 
            // cmsiSearchByItemCodeInDocs
            // 
            this.cmsiSearchByItemCodeInDocs.Name = "cmsiSearchByItemCodeInDocs";
            this.cmsiSearchByItemCodeInDocs.Size = new System.Drawing.Size(251, 22);
            this.cmsiSearchByItemCodeInDocs.Text = "Поиск по коду в документах р/н";
            this.cmsiSearchByItemCodeInDocs.Click += new System.EventHandler(this.cmsiSearchByItemCodeInDocs_Click);
            // 
            // cbExcludeDocs
            // 
            this.cbExcludeDocs.AutoSize = true;
            this.cbExcludeDocs.BackColor = System.Drawing.SystemColors.Info;
            this.cbExcludeDocs.Enabled = false;
            this.cbExcludeDocs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbExcludeDocs.Location = new System.Drawing.Point(149, 28);
            this.cbExcludeDocs.Name = "cbExcludeDocs";
            this.cbExcludeDocs.Size = new System.Drawing.Size(109, 17);
            this.cbExcludeDocs.TabIndex = 18;
            this.cbExcludeDocs.Text = "Отдельно от р/н";
            this.cbExcludeDocs.UseVisualStyleBackColor = false;
            // 
            // ItemChooseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 279);
            this.Controls.Add(this.tbItemName);
            this.Controls.Add(this.cbExcludeDocs);
            this.Controls.Add(this.btnSearchItemByName);
            this.Controls.Add(this.btnSearchVendorLot);
            this.Controls.Add(this.tbQuantity);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnSearchItemByCode);
            this.Controls.Add(this.tbManufacturer);
            this.Controls.Add(this.lblManufacturer);
            this.Controls.Add(this.tbItemNameFound);
            this.Controls.Add(this.lblItemName);
            this.Controls.Add(this.lblUnitOfMeasure);
            this.Controls.Add(this.tbUnitOfMeasure);
            this.Controls.Add(this.tbVendorLot);
            this.Controls.Add(this.lblVendorLot);
            this.Controls.Add(this.tbItemCode);
            this.Controls.Add(this.lblItemCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ItemChooseForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Выбор товара";
            this.Shown += new System.EventHandler(this.ItemChooseForm_Shown);
            this.cmsItemSearchModes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblItemCode;
        private System.Windows.Forms.TextBox tbItemCode;
        private System.Windows.Forms.TextBox tbVendorLot;
        private System.Windows.Forms.Label lblVendorLot;
        private System.Windows.Forms.TextBox tbUnitOfMeasure;
        private System.Windows.Forms.Label lblUnitOfMeasure;
        private System.Windows.Forms.TextBox tbItemNameFound;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.TextBox tbManufacturer;
        private System.Windows.Forms.Label lblManufacturer;
        private System.Windows.Forms.Button btnSearchItemByCode;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Button btnSearchVendorLot;
        private System.Windows.Forms.Button btnSearchItemByName;
        private System.Windows.Forms.TextBox tbItemName;
        private System.Windows.Forms.ContextMenuStrip cmsItemSearchModes;
        private System.Windows.Forms.ToolStripMenuItem cmsiSearchByItemCode;
        private System.Windows.Forms.ToolStripMenuItem cmsiSearchByItemCodeInDocs;
        private System.Windows.Forms.CheckBox cbExcludeDocs;
        private System.Windows.Forms.ToolStripMenuItem cmsiSearchByItemCodeExcludeDocs;
    }
}