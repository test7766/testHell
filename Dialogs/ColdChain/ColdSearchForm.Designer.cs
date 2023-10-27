namespace WMSOffice.Dialogs.ColdChain
{
    partial class ColdSearchForm
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
            this.rbDateInterval = new System.Windows.Forms.RadioButton();
            this.rbDelivery = new System.Windows.Forms.RadioButton();
            this.rbOrder = new System.Windows.Forms.RadioButton();
            this.rbPickSlip = new System.Windows.Forms.RadioButton();
            this.rbWhiteStickerBarCode = new System.Windows.Forms.RadioButton();
            this.pnlDateInterval = new System.Windows.Forms.Panel();
            this.pnlAdvanced = new System.Windows.Forms.Panel();
            this.pnlAdvancedMedicines = new System.Windows.Forms.Panel();
            this.cmbSelectorMedicinesSearchType = new System.Windows.Forms.ComboBox();
            this.tbSaleMedicines = new System.Windows.Forms.TextBox();
            this.pnlAdvancedBranch = new System.Windows.Forms.Panel();
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            this.branchesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.coldChain = new WMSOffice.Data.ColdChain();
            this.rbBranch = new System.Windows.Forms.RadioButton();
            this.rbSaleMedicines = new System.Windows.Forms.RadioButton();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.dtDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtDateFrom = new System.Windows.Forms.DateTimePicker();
            this.cbAdvancedByDate = new System.Windows.Forms.CheckBox();
            this.pnlDelivery = new System.Windows.Forms.Panel();
            this.lblDeliveryCode = new System.Windows.Forms.Label();
            this.cmbSelectorDeliveryCodeSearchType = new System.Windows.Forms.ComboBox();
            this.tbDelivery = new System.Windows.Forms.TextBox();
            this.pnlOrder = new System.Windows.Forms.Panel();
            this.lblOrderType = new System.Windows.Forms.Label();
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.tbOrderType = new System.Windows.Forms.TextBox();
            this.tbOrderNumber = new System.Windows.Forms.TextBox();
            this.pnlPickSlip = new System.Windows.Forms.Panel();
            this.lblPickSlipNumber = new System.Windows.Forms.Label();
            this.tbPickSlipNumber = new System.Windows.Forms.TextBox();
            this.pnlWhiteStickerBarCode = new System.Windows.Forms.Panel();
            this.tbWhiteStickerBarCode = new WMSOffice.Controls.TextBoxScaner();
            this.branchesTableAdapter = new WMSOffice.Data.ColdChainTableAdapters.BranchesTableAdapter();
            this.pnlButtons.SuspendLayout();
            this.pnlDateInterval.SuspendLayout();
            this.pnlAdvanced.SuspendLayout();
            this.pnlAdvancedMedicines.SuspendLayout();
            this.pnlAdvancedBranch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.branchesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coldChain)).BeginInit();
            this.pnlDelivery.SuspendLayout();
            this.pnlOrder.SuspendLayout();
            this.pnlPickSlip.SuspendLayout();
            this.pnlWhiteStickerBarCode.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            //
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 377);
            this.pnlButtons.Size = new System.Drawing.Size(651, 43);
            // 
            // rbDateInterval
            // 
            this.rbDateInterval.AutoSize = true;
            this.rbDateInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbDateInterval.ForeColor = System.Drawing.SystemColors.Desktop;
            this.rbDateInterval.Location = new System.Drawing.Point(12, 69);
            this.rbDateInterval.Name = "rbDateInterval";
            this.rbDateInterval.Size = new System.Drawing.Size(82, 19);
            this.rbDateInterval.TabIndex = 101;
            this.rbDateInterval.TabStop = true;
            this.rbDateInterval.Text = "по датам:";
            this.rbDateInterval.UseVisualStyleBackColor = true;
            this.rbDateInterval.CheckedChanged += new System.EventHandler(this.rbSearchScenario_CheckedChanged);
            // 
            // rbDelivery
            // 
            this.rbDelivery.AutoSize = true;
            this.rbDelivery.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbDelivery.ForeColor = System.Drawing.SystemColors.Desktop;
            this.rbDelivery.Location = new System.Drawing.Point(12, 167);
            this.rbDelivery.Name = "rbDelivery";
            this.rbDelivery.Size = new System.Drawing.Size(99, 19);
            this.rbDelivery.TabIndex = 102;
            this.rbDelivery.TabStop = true;
            this.rbDelivery.Text = "по дебитору:";
            this.rbDelivery.UseVisualStyleBackColor = true;
            this.rbDelivery.CheckedChanged += new System.EventHandler(this.rbSearchScenario_CheckedChanged);
            // 
            // rbOrder
            // 
            this.rbOrder.AutoSize = true;
            this.rbOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbOrder.ForeColor = System.Drawing.SystemColors.Desktop;
            this.rbOrder.Location = new System.Drawing.Point(12, 226);
            this.rbOrder.Name = "rbOrder";
            this.rbOrder.Size = new System.Drawing.Size(82, 19);
            this.rbOrder.TabIndex = 103;
            this.rbOrder.TabStop = true;
            this.rbOrder.Text = "по заказу:";
            this.rbOrder.UseVisualStyleBackColor = true;
            this.rbOrder.CheckedChanged += new System.EventHandler(this.rbSearchScenario_CheckedChanged);
            // 
            // rbPickSlip
            // 
            this.rbPickSlip.AutoSize = true;
            this.rbPickSlip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbPickSlip.ForeColor = System.Drawing.SystemColors.Desktop;
            this.rbPickSlip.Location = new System.Drawing.Point(12, 285);
            this.rbPickSlip.Name = "rbPickSlip";
            this.rbPickSlip.Size = new System.Drawing.Size(113, 19);
            this.rbPickSlip.TabIndex = 104;
            this.rbPickSlip.TabStop = true;
            this.rbPickSlip.Text = "по сборочному:";
            this.rbPickSlip.UseVisualStyleBackColor = true;
            this.rbPickSlip.CheckedChanged += new System.EventHandler(this.rbSearchScenario_CheckedChanged);
            // 
            // rbWhiteStickerBarCode
            // 
            this.rbWhiteStickerBarCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbWhiteStickerBarCode.ForeColor = System.Drawing.SystemColors.Desktop;
            this.rbWhiteStickerBarCode.Location = new System.Drawing.Point(12, 326);
            this.rbWhiteStickerBarCode.Name = "rbWhiteStickerBarCode";
            this.rbWhiteStickerBarCode.Size = new System.Drawing.Size(100, 40);
            this.rbWhiteStickerBarCode.TabIndex = 105;
            this.rbWhiteStickerBarCode.TabStop = true;
            this.rbWhiteStickerBarCode.Text = "по ш/к белой этикетки:";
            this.rbWhiteStickerBarCode.UseVisualStyleBackColor = true;
            this.rbWhiteStickerBarCode.CheckedChanged += new System.EventHandler(this.rbSearchScenario_CheckedChanged);
            // 
            // pnlDateInterval
            // 
            this.pnlDateInterval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDateInterval.Controls.Add(this.pnlAdvanced);
            this.pnlDateInterval.Controls.Add(this.lblDateTo);
            this.pnlDateInterval.Controls.Add(this.lblDateFrom);
            this.pnlDateInterval.Controls.Add(this.dtDateTo);
            this.pnlDateInterval.Controls.Add(this.dtDateFrom);
            this.pnlDateInterval.Controls.Add(this.cbAdvancedByDate);
            this.pnlDateInterval.Location = new System.Drawing.Point(124, 11);
            this.pnlDateInterval.Name = "pnlDateInterval";
            this.pnlDateInterval.Size = new System.Drawing.Size(515, 135);
            this.pnlDateInterval.TabIndex = 106;
            // 
            // pnlAdvanced
            // 
            this.pnlAdvanced.Controls.Add(this.pnlAdvancedMedicines);
            this.pnlAdvanced.Controls.Add(this.pnlAdvancedBranch);
            this.pnlAdvanced.Controls.Add(this.rbBranch);
            this.pnlAdvanced.Controls.Add(this.rbSaleMedicines);
            this.pnlAdvanced.Location = new System.Drawing.Point(18, 60);
            this.pnlAdvanced.Name = "pnlAdvanced";
            this.pnlAdvanced.Size = new System.Drawing.Size(482, 71);
            this.pnlAdvanced.TabIndex = 105;
            // 
            // pnlAdvancedMedicines
            // 
            this.pnlAdvancedMedicines.Controls.Add(this.cmbSelectorMedicinesSearchType);
            this.pnlAdvancedMedicines.Controls.Add(this.tbSaleMedicines);
            this.pnlAdvancedMedicines.Location = new System.Drawing.Point(102, 38);
            this.pnlAdvancedMedicines.Name = "pnlAdvancedMedicines";
            this.pnlAdvancedMedicines.Size = new System.Drawing.Size(377, 28);
            this.pnlAdvancedMedicines.TabIndex = 109;
            // 
            // cmbSelectorMedicinesSearchType
            // 
            this.cmbSelectorMedicinesSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelectorMedicinesSearchType.FormattingEnabled = true;
            this.cmbSelectorMedicinesSearchType.Items.AddRange(new object[] {
            "код товара",
            "наименование товара"});
            this.cmbSelectorMedicinesSearchType.Location = new System.Drawing.Point(3, 3);
            this.cmbSelectorMedicinesSearchType.Name = "cmbSelectorMedicinesSearchType";
            this.cmbSelectorMedicinesSearchType.Size = new System.Drawing.Size(174, 21);
            this.cmbSelectorMedicinesSearchType.TabIndex = 5;
            this.cmbSelectorMedicinesSearchType.SelectedIndexChanged += new System.EventHandler(this.cmbSelectorMedicinesSearchType_SelectedIndexChanged);
            // 
            // tbSaleMedicines
            // 
            this.tbSaleMedicines.Location = new System.Drawing.Point(193, 4);
            this.tbSaleMedicines.Name = "tbSaleMedicines";
            this.tbSaleMedicines.Size = new System.Drawing.Size(181, 20);
            this.tbSaleMedicines.TabIndex = 106;
            this.tbSaleMedicines.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ApplyFilter_KeyDown);
            this.tbSaleMedicines.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSaleMedicines_KeyPress);
            // 
            // pnlAdvancedBranch
            // 
            this.pnlAdvancedBranch.Controls.Add(this.cmbBranch);
            this.pnlAdvancedBranch.Location = new System.Drawing.Point(102, 4);
            this.pnlAdvancedBranch.Name = "pnlAdvancedBranch";
            this.pnlAdvancedBranch.Size = new System.Drawing.Size(377, 28);
            this.pnlAdvancedBranch.TabIndex = 108;
            // 
            // cmbBranch
            // 
            this.cmbBranch.DataSource = this.branchesBindingSource;
            this.cmbBranch.DisplayMember = "Branch_Name";
            this.cmbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBranch.FormattingEnabled = true;
            this.cmbBranch.Location = new System.Drawing.Point(3, 3);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.Size = new System.Drawing.Size(174, 21);
            this.cmbBranch.TabIndex = 107;
            this.cmbBranch.ValueMember = "Warehouse_ID";
            // 
            // branchesBindingSource
            // 
            this.branchesBindingSource.DataMember = "Branches";
            this.branchesBindingSource.DataSource = this.coldChain;
            // 
            // coldChain
            // 
            this.coldChain.DataSetName = "ColdChain";
            this.coldChain.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rbBranch
            // 
            this.rbBranch.AutoSize = true;
            this.rbBranch.Location = new System.Drawing.Point(10, 10);
            this.rbBranch.Name = "rbBranch";
            this.rbBranch.Size = new System.Drawing.Size(86, 17);
            this.rbBranch.TabIndex = 103;
            this.rbBranch.TabStop = true;
            this.rbBranch.Text = "по филиалу:";
            this.rbBranch.UseVisualStyleBackColor = true;
            this.rbBranch.CheckedChanged += new System.EventHandler(this.rbAdvancedByDateSearchScenario_CheckedChanged);
            // 
            // rbSaleMedicines
            // 
            this.rbSaleMedicines.AutoSize = true;
            this.rbSaleMedicines.Location = new System.Drawing.Point(10, 44);
            this.rbSaleMedicines.Name = "rbSaleMedicines";
            this.rbSaleMedicines.Size = new System.Drawing.Size(77, 17);
            this.rbSaleMedicines.TabIndex = 104;
            this.rbSaleMedicines.TabStop = true;
            this.rbSaleMedicines.Text = "по товару:";
            this.rbSaleMedicines.UseVisualStyleBackColor = true;
            this.rbSaleMedicines.CheckedChanged += new System.EventHandler(this.rbAdvancedByDateSearchScenario_CheckedChanged);
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Location = new System.Drawing.Point(227, 12);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(51, 13);
            this.lblDateTo.TabIndex = 6;
            this.lblDateTo.Text = "Дата по:";
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Location = new System.Drawing.Point(15, 12);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(45, 13);
            this.lblDateFrom.TabIndex = 5;
            this.lblDateFrom.Text = "Дата с:";
            // 
            // dtDateTo
            // 
            this.dtDateTo.CustomFormat = "dd / MM / yyyy";
            this.dtDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateTo.Location = new System.Drawing.Point(284, 8);
            this.dtDateTo.Name = "dtDateTo";
            this.dtDateTo.Size = new System.Drawing.Size(120, 20);
            this.dtDateTo.TabIndex = 2;
            // 
            // dtDateFrom
            // 
            this.dtDateFrom.CustomFormat = "dd / MM / yyyy";
            this.dtDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateFrom.Location = new System.Drawing.Point(66, 8);
            this.dtDateFrom.Name = "dtDateFrom";
            this.dtDateFrom.Size = new System.Drawing.Size(120, 20);
            this.dtDateFrom.TabIndex = 1;
            // 
            // cbAdvancedByDate
            // 
            this.cbAdvancedByDate.AutoSize = true;
            this.cbAdvancedByDate.Checked = true;
            this.cbAdvancedByDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAdvancedByDate.Location = new System.Drawing.Point(18, 40);
            this.cbAdvancedByDate.Name = "cbAdvancedByDate";
            this.cbAdvancedByDate.Size = new System.Drawing.Size(106, 17);
            this.cbAdvancedByDate.TabIndex = 0;
            this.cbAdvancedByDate.Text = "Дополнительно";
            this.cbAdvancedByDate.UseVisualStyleBackColor = true;
            this.cbAdvancedByDate.CheckedChanged += new System.EventHandler(this.cbAdvancedByDate_CheckedChanged);
            // 
            // pnlDelivery
            // 
            this.pnlDelivery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDelivery.Controls.Add(this.lblDeliveryCode);
            this.pnlDelivery.Controls.Add(this.cmbSelectorDeliveryCodeSearchType);
            this.pnlDelivery.Controls.Add(this.tbDelivery);
            this.pnlDelivery.Location = new System.Drawing.Point(124, 153);
            this.pnlDelivery.Name = "pnlDelivery";
            this.pnlDelivery.Size = new System.Drawing.Size(515, 46);
            this.pnlDelivery.TabIndex = 107;
            // 
            // lblDeliveryCode
            // 
            this.lblDeliveryCode.AutoSize = true;
            this.lblDeliveryCode.Location = new System.Drawing.Point(18, 16);
            this.lblDeliveryCode.Name = "lblDeliveryCode";
            this.lblDeliveryCode.Size = new System.Drawing.Size(26, 13);
            this.lblDeliveryCode.TabIndex = 4;
            this.lblDeliveryCode.Text = "Код";
            // 
            // cmbSelectorDeliveryCodeSearchType
            // 
            this.cmbSelectorDeliveryCodeSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelectorDeliveryCodeSearchType.FormattingEnabled = true;
            this.cmbSelectorDeliveryCodeSearchType.Items.AddRange(new object[] {
            "дебитора",
            "адреса доставки"});
            this.cmbSelectorDeliveryCodeSearchType.Location = new System.Drawing.Point(50, 12);
            this.cmbSelectorDeliveryCodeSearchType.Name = "cmbSelectorDeliveryCodeSearchType";
            this.cmbSelectorDeliveryCodeSearchType.Size = new System.Drawing.Size(173, 21);
            this.cmbSelectorDeliveryCodeSearchType.TabIndex = 3;
            this.cmbSelectorDeliveryCodeSearchType.SelectedIndexChanged += new System.EventHandler(this.cmbSelectorDeliveryCodeSearchType_SelectedIndexChanged);
            // 
            // tbDelivery
            // 
            this.tbDelivery.Location = new System.Drawing.Point(241, 12);
            this.tbDelivery.Name = "tbDelivery";
            this.tbDelivery.Size = new System.Drawing.Size(163, 20);
            this.tbDelivery.TabIndex = 2;
            this.tbDelivery.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ApplyFilter_KeyDown);
            this.tbDelivery.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllowOnlyNumber_KeyPress);
            // 
            // pnlOrder
            // 
            this.pnlOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOrder.Controls.Add(this.lblOrderType);
            this.pnlOrder.Controls.Add(this.lblOrderNumber);
            this.pnlOrder.Controls.Add(this.tbOrderType);
            this.pnlOrder.Controls.Add(this.tbOrderNumber);
            this.pnlOrder.Location = new System.Drawing.Point(124, 205);
            this.pnlOrder.Name = "pnlOrder";
            this.pnlOrder.Size = new System.Drawing.Size(515, 60);
            this.pnlOrder.TabIndex = 107;
            // 
            // lblOrderType
            // 
            this.lblOrderType.AutoSize = true;
            this.lblOrderType.Location = new System.Drawing.Point(18, 36);
            this.lblOrderType.Name = "lblOrderType";
            this.lblOrderType.Size = new System.Drawing.Size(68, 13);
            this.lblOrderType.TabIndex = 6;
            this.lblOrderType.Text = "Тип заказа:";
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.AutoSize = true;
            this.lblOrderNumber.Location = new System.Drawing.Point(18, 10);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(60, 13);
            this.lblOrderNumber.TabIndex = 5;
            this.lblOrderNumber.Text = "№ заказа:";
            // 
            // tbOrderType
            // 
            this.tbOrderType.Location = new System.Drawing.Point(92, 33);
            this.tbOrderType.MaxLength = 2;
            this.tbOrderType.Name = "tbOrderType";
            this.tbOrderType.Size = new System.Drawing.Size(131, 20);
            this.tbOrderType.TabIndex = 2;
            this.tbOrderType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ApplyFilter_KeyDown);
            // 
            // tbOrderNumber
            // 
            this.tbOrderNumber.Location = new System.Drawing.Point(92, 7);
            this.tbOrderNumber.Name = "tbOrderNumber";
            this.tbOrderNumber.Size = new System.Drawing.Size(131, 20);
            this.tbOrderNumber.TabIndex = 1;
            this.tbOrderNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbOrderNumber_KeyDown);
            this.tbOrderNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllowOnlyNumber_KeyPress);
            // 
            // pnlPickSlip
            // 
            this.pnlPickSlip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPickSlip.Controls.Add(this.lblPickSlipNumber);
            this.pnlPickSlip.Controls.Add(this.tbPickSlipNumber);
            this.pnlPickSlip.Location = new System.Drawing.Point(125, 271);
            this.pnlPickSlip.Name = "pnlPickSlip";
            this.pnlPickSlip.Size = new System.Drawing.Size(514, 46);
            this.pnlPickSlip.TabIndex = 107;
            // 
            // lblPickSlipNumber
            // 
            this.lblPickSlipNumber.AutoSize = true;
            this.lblPickSlipNumber.Location = new System.Drawing.Point(17, 15);
            this.lblPickSlipNumber.Name = "lblPickSlipNumber";
            this.lblPickSlipNumber.Size = new System.Drawing.Size(82, 13);
            this.lblPickSlipNumber.TabIndex = 7;
            this.lblPickSlipNumber.Text = "№ сборочного:";
            // 
            // tbPickSlipNumber
            // 
            this.tbPickSlipNumber.Location = new System.Drawing.Point(105, 12);
            this.tbPickSlipNumber.Name = "tbPickSlipNumber";
            this.tbPickSlipNumber.Size = new System.Drawing.Size(131, 20);
            this.tbPickSlipNumber.TabIndex = 0;
            this.tbPickSlipNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ApplyFilter_KeyDown);
            this.tbPickSlipNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllowOnlyNumber_KeyPress);
            // 
            // pnlWhiteStickerBarCode
            // 
            this.pnlWhiteStickerBarCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlWhiteStickerBarCode.Controls.Add(this.tbWhiteStickerBarCode);
            this.pnlWhiteStickerBarCode.Location = new System.Drawing.Point(125, 323);
            this.pnlWhiteStickerBarCode.Name = "pnlWhiteStickerBarCode";
            this.pnlWhiteStickerBarCode.Size = new System.Drawing.Size(514, 46);
            this.pnlWhiteStickerBarCode.TabIndex = 107;
            // 
            // tbWhiteStickerBarCode
            // 
            this.tbWhiteStickerBarCode.AllowType = true;
            this.tbWhiteStickerBarCode.AutoConvert = true;
            this.tbWhiteStickerBarCode.Location = new System.Drawing.Point(17, 10);
            this.tbWhiteStickerBarCode.Name = "tbWhiteStickerBarCode";
            this.tbWhiteStickerBarCode.ReadOnly = false;
            this.tbWhiteStickerBarCode.Size = new System.Drawing.Size(236, 25);
            this.tbWhiteStickerBarCode.TabIndex = 0;
            this.tbWhiteStickerBarCode.TextBoxBackColor = System.Drawing.SystemColors.Window;
            // 
            // branchesTableAdapter
            // 
            this.branchesTableAdapter.ClearBeforeFill = true;
            // 
            // ColdSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 420);
            this.Controls.Add(this.pnlDelivery);
            this.Controls.Add(this.pnlOrder);
            this.Controls.Add(this.pnlPickSlip);
            this.Controls.Add(this.pnlWhiteStickerBarCode);
            this.Controls.Add(this.pnlDateInterval);
            this.Controls.Add(this.rbWhiteStickerBarCode);
            this.Controls.Add(this.rbPickSlip);
            this.Controls.Add(this.rbOrder);
            this.Controls.Add(this.rbDelivery);
            this.Controls.Add(this.rbDateInterval);
            this.Name = "ColdSearchForm";
            this.Text = "Параметры поиска отчетов о температурном режиме";
            this.Load += new System.EventHandler(this.ColdSearchForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ColdSearchForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.rbDateInterval, 0);
            this.Controls.SetChildIndex(this.rbDelivery, 0);
            this.Controls.SetChildIndex(this.rbOrder, 0);
            this.Controls.SetChildIndex(this.rbPickSlip, 0);
            this.Controls.SetChildIndex(this.rbWhiteStickerBarCode, 0);
            this.Controls.SetChildIndex(this.pnlDateInterval, 0);
            this.Controls.SetChildIndex(this.pnlWhiteStickerBarCode, 0);
            this.Controls.SetChildIndex(this.pnlPickSlip, 0);
            this.Controls.SetChildIndex(this.pnlOrder, 0);
            this.Controls.SetChildIndex(this.pnlDelivery, 0);
            this.pnlButtons.ResumeLayout(false);
            this.pnlDateInterval.ResumeLayout(false);
            this.pnlDateInterval.PerformLayout();
            this.pnlAdvanced.ResumeLayout(false);
            this.pnlAdvanced.PerformLayout();
            this.pnlAdvancedMedicines.ResumeLayout(false);
            this.pnlAdvancedMedicines.PerformLayout();
            this.pnlAdvancedBranch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.branchesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coldChain)).EndInit();
            this.pnlDelivery.ResumeLayout(false);
            this.pnlDelivery.PerformLayout();
            this.pnlOrder.ResumeLayout(false);
            this.pnlOrder.PerformLayout();
            this.pnlPickSlip.ResumeLayout(false);
            this.pnlPickSlip.PerformLayout();
            this.pnlWhiteStickerBarCode.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbDateInterval;
        private System.Windows.Forms.RadioButton rbDelivery;
        private System.Windows.Forms.RadioButton rbOrder;
        private System.Windows.Forms.RadioButton rbPickSlip;
        private System.Windows.Forms.RadioButton rbWhiteStickerBarCode;
        private System.Windows.Forms.Panel pnlDateInterval;
        private System.Windows.Forms.Panel pnlDelivery;
        private System.Windows.Forms.TextBox tbDelivery;
        private System.Windows.Forms.Panel pnlOrder;
        private System.Windows.Forms.TextBox tbOrderType;
        private System.Windows.Forms.TextBox tbOrderNumber;
        private System.Windows.Forms.Panel pnlPickSlip;
        private System.Windows.Forms.TextBox tbPickSlipNumber;
        private System.Windows.Forms.Panel pnlWhiteStickerBarCode;
        private System.Windows.Forms.RadioButton rbSaleMedicines;
        private System.Windows.Forms.RadioButton rbBranch;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.DateTimePicker dtDateTo;
        private System.Windows.Forms.DateTimePicker dtDateFrom;
        private System.Windows.Forms.CheckBox cbAdvancedByDate;
        private System.Windows.Forms.Label lblDeliveryCode;
        private System.Windows.Forms.ComboBox cmbSelectorDeliveryCodeSearchType;
        private System.Windows.Forms.Panel pnlAdvanced;
        private System.Windows.Forms.ComboBox cmbSelectorMedicinesSearchType;
        private System.Windows.Forms.TextBox tbSaleMedicines;
        private WMSOffice.Controls.TextBoxScaner tbWhiteStickerBarCode;
        private System.Windows.Forms.Label lblOrderType;
        private System.Windows.Forms.Label lblOrderNumber;
        private System.Windows.Forms.Label lblPickSlipNumber;
        private System.Windows.Forms.Panel pnlAdvancedMedicines;
        private System.Windows.Forms.Panel pnlAdvancedBranch;
        private System.Windows.Forms.ComboBox cmbBranch;
        private WMSOffice.Data.ColdChain coldChain;
        private System.Windows.Forms.BindingSource branchesBindingSource;
        private WMSOffice.Data.ColdChainTableAdapters.BranchesTableAdapter branchesTableAdapter;
    }
}