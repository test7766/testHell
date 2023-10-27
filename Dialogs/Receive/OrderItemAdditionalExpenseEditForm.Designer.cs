namespace WMSOffice.Dialogs.Receive
{
    partial class OrderItemAdditionalExpenseEditForm
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
            this.lblExpenseType = new System.Windows.Forms.Label();
            this.cmbExpenseType = new System.Windows.Forms.ComboBox();
            this.prAEGetCostTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.receive = new WMSOffice.Data.Receive();
            this.lblExpenseRate = new System.Windows.Forms.Label();
            this.lblSuppliers = new System.Windows.Forms.Label();
            this.cmbSuppliers = new System.Windows.Forms.ComboBox();
            this.prAEGetSupplierForCostBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cbCheckPriority = new System.Windows.Forms.CheckBox();
            this.pr_AE_Get_Cost_TypesTableAdapter = new WMSOffice.Data.ReceiveTableAdapters.pr_AE_Get_Cost_TypesTableAdapter();
            this.tbExpenseRate = new System.Windows.Forms.TextBox();
            this.orderItemAdditionalExpenseEditFormBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.pr_AE_Get_Supplier_For_CostTableAdapter = new WMSOffice.Data.ReceiveTableAdapters.pr_AE_Get_Supplier_For_CostTableAdapter();
            this.cbUseExpenseForFullInvoice = new System.Windows.Forms.CheckBox();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prAEGetCostTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prAEGetSupplierForCostBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderItemAdditionalExpenseEditFormBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(605, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(695, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 159);
            this.pnlButtons.Size = new System.Drawing.Size(494, 43);
            this.pnlButtons.TabIndex = 7;
            // 
            // lblExpenseType
            // 
            this.lblExpenseType.AutoSize = true;
            this.lblExpenseType.Location = new System.Drawing.Point(12, 13);
            this.lblExpenseType.Name = "lblExpenseType";
            this.lblExpenseType.Size = new System.Drawing.Size(94, 13);
            this.lblExpenseType.TabIndex = 0;
            this.lblExpenseType.Text = "Тип начисления :";
            // 
            // cmbExpenseType
            // 
            this.cmbExpenseType.DataSource = this.prAEGetCostTypesBindingSource;
            this.cmbExpenseType.DisplayMember = "Description";
            this.cmbExpenseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbExpenseType.FormattingEnabled = true;
            this.cmbExpenseType.Location = new System.Drawing.Point(119, 9);
            this.cmbExpenseType.Name = "cmbExpenseType";
            this.cmbExpenseType.Size = new System.Drawing.Size(363, 21);
            this.cmbExpenseType.TabIndex = 1;
            this.cmbExpenseType.ValueMember = "ID";
            this.cmbExpenseType.SelectedValueChanged += new System.EventHandler(this.cmbExpenseType_SelectedValueChanged);
            // 
            // prAEGetCostTypesBindingSource
            // 
            this.prAEGetCostTypesBindingSource.DataMember = "pr_AE_Get_Cost_Types";
            this.prAEGetCostTypesBindingSource.DataSource = this.receive;
            // 
            // receive
            // 
            this.receive.DataSetName = "Receive";
            this.receive.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblExpenseRate
            // 
            this.lblExpenseRate.AutoSize = true;
            this.lblExpenseRate.Location = new System.Drawing.Point(12, 75);
            this.lblExpenseRate.Name = "lblExpenseRate";
            this.lblExpenseRate.Size = new System.Drawing.Size(101, 13);
            this.lblExpenseRate.TabIndex = 2;
            this.lblExpenseRate.Text = "Процент наценки :";
            // 
            // lblSuppliers
            // 
            this.lblSuppliers.AutoSize = true;
            this.lblSuppliers.Location = new System.Drawing.Point(12, 111);
            this.lblSuppliers.Name = "lblSuppliers";
            this.lblSuppliers.Size = new System.Drawing.Size(71, 13);
            this.lblSuppliers.TabIndex = 4;
            this.lblSuppliers.Text = "Поставщик :";
            // 
            // cmbSuppliers
            // 
            this.cmbSuppliers.DataSource = this.prAEGetSupplierForCostBindingSource;
            this.cmbSuppliers.DisplayMember = "Name";
            this.cmbSuppliers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSuppliers.FormattingEnabled = true;
            this.cmbSuppliers.Location = new System.Drawing.Point(119, 107);
            this.cmbSuppliers.Name = "cmbSuppliers";
            this.cmbSuppliers.Size = new System.Drawing.Size(363, 21);
            this.cmbSuppliers.TabIndex = 5;
            this.cmbSuppliers.ValueMember = "Code";
            // 
            // prAEGetSupplierForCostBindingSource
            // 
            this.prAEGetSupplierForCostBindingSource.DataMember = "pr_AE_Get_Supplier_For_Cost";
            this.prAEGetSupplierForCostBindingSource.DataSource = this.receive;
            // 
            // cbCheckPriority
            // 
            this.cbCheckPriority.AutoSize = true;
            this.cbCheckPriority.Location = new System.Drawing.Point(15, 140);
            this.cbCheckPriority.Name = "cbCheckPriority";
            this.cbCheckPriority.Size = new System.Drawing.Size(180, 17);
            this.cbCheckPriority.TabIndex = 6;
            this.cbCheckPriority.Text = "Учитывать другие начисления";
            this.cbCheckPriority.UseVisualStyleBackColor = true;
            this.cbCheckPriority.Visible = false;
            // 
            // pr_AE_Get_Cost_TypesTableAdapter
            // 
            this.pr_AE_Get_Cost_TypesTableAdapter.ClearBeforeFill = true;
            // 
            // tbExpenseRate
            // 
            this.tbExpenseRate.Location = new System.Drawing.Point(119, 71);
            this.tbExpenseRate.Name = "tbExpenseRate";
            this.tbExpenseRate.Size = new System.Drawing.Size(117, 20);
            this.tbExpenseRate.TabIndex = 3;
            this.tbExpenseRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbExpenseRate.Validated += new System.EventHandler(this.tbExpenseRate_Validated);
            this.tbExpenseRate.Validating += new System.ComponentModel.CancelEventHandler(this.tbExpenseRate_Validating);
            // 
            // orderItemAdditionalExpenseEditFormBindingSource
            // 
            this.orderItemAdditionalExpenseEditFormBindingSource.DataSource = typeof(WMSOffice.Dialogs.Receive.OrderItemAdditionalExpenseEditForm);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // pr_AE_Get_Supplier_For_CostTableAdapter
            // 
            this.pr_AE_Get_Supplier_For_CostTableAdapter.ClearBeforeFill = true;
            // 
            // cbUseExpenseForFullInvoice
            // 
            this.cbUseExpenseForFullInvoice.AutoSize = true;
            this.cbUseExpenseForFullInvoice.Location = new System.Drawing.Point(119, 38);
            this.cbUseExpenseForFullInvoice.Name = "cbUseExpenseForFullInvoice";
            this.cbUseExpenseForFullInvoice.Size = new System.Drawing.Size(90, 17);
            this.cbUseExpenseForFullInvoice.TabIndex = 8;
            this.cbUseExpenseForFullInvoice.Text = "В накладной";
            this.cbUseExpenseForFullInvoice.UseVisualStyleBackColor = true;
            // 
            // OrderItemAdditionalExpenseEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 202);
            this.Controls.Add(this.cbUseExpenseForFullInvoice);
            this.Controls.Add(this.tbExpenseRate);
            this.Controls.Add(this.cbCheckPriority);
            this.Controls.Add(this.lblSuppliers);
            this.Controls.Add(this.cmbSuppliers);
            this.Controls.Add(this.lblExpenseRate);
            this.Controls.Add(this.lblExpenseType);
            this.Controls.Add(this.cmbExpenseType);
            this.Name = "OrderItemAdditionalExpenseEditForm";
            this.Text = "Начисление дополнительных расходов";
            this.Load += new System.EventHandler(this.OrderItemAdditionalExpenseEditForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OrderItemAdditionalExpenseEditForm_FormClosing);
            this.Controls.SetChildIndex(this.cmbExpenseType, 0);
            this.Controls.SetChildIndex(this.lblExpenseType, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.lblExpenseRate, 0);
            this.Controls.SetChildIndex(this.cmbSuppliers, 0);
            this.Controls.SetChildIndex(this.lblSuppliers, 0);
            this.Controls.SetChildIndex(this.cbCheckPriority, 0);
            this.Controls.SetChildIndex(this.tbExpenseRate, 0);
            this.Controls.SetChildIndex(this.cbUseExpenseForFullInvoice, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.prAEGetCostTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prAEGetSupplierForCostBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderItemAdditionalExpenseEditFormBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblExpenseType;
        private System.Windows.Forms.ComboBox cmbExpenseType;
        private System.Windows.Forms.Label lblExpenseRate;
        private System.Windows.Forms.Label lblSuppliers;
        private System.Windows.Forms.ComboBox cmbSuppliers;
        private System.Windows.Forms.CheckBox cbCheckPriority;
        private System.Windows.Forms.BindingSource prAEGetCostTypesBindingSource;
        private WMSOffice.Data.Receive receive;
        private WMSOffice.Data.ReceiveTableAdapters.pr_AE_Get_Cost_TypesTableAdapter pr_AE_Get_Cost_TypesTableAdapter;
        private System.Windows.Forms.TextBox tbExpenseRate;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.BindingSource orderItemAdditionalExpenseEditFormBindingSource;
        private System.Windows.Forms.BindingSource prAEGetSupplierForCostBindingSource;
        private WMSOffice.Data.ReceiveTableAdapters.pr_AE_Get_Supplier_For_CostTableAdapter pr_AE_Get_Supplier_For_CostTableAdapter;
        private System.Windows.Forms.CheckBox cbUseExpenseForFullInvoice;
    }
}