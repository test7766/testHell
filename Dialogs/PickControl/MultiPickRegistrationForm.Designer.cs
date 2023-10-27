namespace WMSOffice.Dialogs.PickControl
{
    partial class MultiPickRegistrationForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.tbPickSlipCount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPrinters = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbBarcode = new WMSOffice.Controls.TextBoxScaner();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.aBALPHDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sDDCTODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.psnidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.multiPickSlipDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pickControl = new WMSOffice.Data.PickControl();
            this.multiPickSlipDetailsTableAdapter = new WMSOffice.Data.PickControlTableAdapters.MultiPickSlipDetailsTableAdapter();
            this.scMainLayout = new System.Windows.Forms.SplitContainer();
            this.pnlRecommendedPickSlips = new System.Windows.Forms.Panel();
            this.lblRecommendedPickSlips = new System.Windows.Forms.Label();
            this.dgvRecommendedPickSlips = new System.Windows.Forms.DataGridView();
            this.pickSlipNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pickVolumeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pickLinesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pickItemsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pickBoxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deliveryDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deliveryZoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recomendedPickSlipsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.recomendedPickSlipsTableAdapter = new WMSOffice.Data.PickControlTableAdapters.RecomendedPickSlipsTableAdapter();
            this.pnlButtons.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.multiPickSlipDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).BeginInit();
            this.scMainLayout.Panel1.SuspendLayout();
            this.scMainLayout.Panel2.SuspendLayout();
            this.scMainLayout.SuspendLayout();
            this.pnlRecommendedPickSlips.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecommendedPickSlips)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recomendedPickSlipsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(8342, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(8423, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 529);
            this.pnlButtons.Size = new System.Drawing.Size(894, 43);
            this.pnlButtons.TabIndex = 1;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.tbPickSlipCount);
            this.pnlHeader.Controls.Add(this.label3);
            this.pnlHeader.Controls.Add(this.label2);
            this.pnlHeader.Controls.Add(this.cmbPrinters);
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Controls.Add(this.tbBarcode);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(894, 35);
            this.pnlHeader.TabIndex = 0;
            // 
            // tbPickSlipCount
            // 
            this.tbPickSlipCount.BackColor = System.Drawing.SystemColors.Window;
            this.tbPickSlipCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbPickSlipCount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tbPickSlipCount.Location = new System.Drawing.Point(547, 7);
            this.tbPickSlipCount.Name = "tbPickSlipCount";
            this.tbPickSlipCount.ReadOnly = true;
            this.tbPickSlipCount.Size = new System.Drawing.Size(50, 20);
            this.tbPickSlipCount.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(394, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Количество сборочных:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(641, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Принтер:";
            // 
            // cmbPrinters
            // 
            this.cmbPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinters.FormattingEnabled = true;
            this.cmbPrinters.Location = new System.Drawing.Point(700, 7);
            this.cmbPrinters.Name = "cmbPrinters";
            this.cmbPrinters.Size = new System.Drawing.Size(180, 21);
            this.cmbPrinters.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ш/К сборочного:";
            // 
            // tbBarcode
            // 
            this.tbBarcode.AllowType = true;
            this.tbBarcode.AutoConvert = true;
            this.tbBarcode.DelayThreshold = 50;
            this.tbBarcode.Location = new System.Drawing.Point(101, 5);
            this.tbBarcode.Name = "tbBarcode";
            this.tbBarcode.RaiseTextChangeWithoutEnter = false;
            this.tbBarcode.ReadOnly = false;
            this.tbBarcode.Size = new System.Drawing.Size(250, 25);
            this.tbBarcode.TabIndex = 1;
            this.tbBarcode.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.tbBarcode.UseParentFont = false;
            this.tbBarcode.UseScanModeOnly = false;
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.AllowUserToResizeColumns = false;
            this.dgvDetails.AllowUserToResizeRows = false;
            this.dgvDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetails.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.aBALPHDataGridViewTextBoxColumn,
            this.sDDCTODataGridViewTextBoxColumn,
            this.psnidDataGridViewTextBoxColumn,
            this.Column1});
            this.dgvDetails.DataSource = this.multiPickSlipDetailsBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetails.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetails.Location = new System.Drawing.Point(0, 41);
            this.dgvDetails.MultiSelect = false;
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetails.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDetails.RowHeadersVisible = false;
            this.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetails.Size = new System.Drawing.Size(894, 227);
            this.dgvDetails.TabIndex = 1;
            // 
            // aBALPHDataGridViewTextBoxColumn
            // 
            this.aBALPHDataGridViewTextBoxColumn.DataPropertyName = "ABALPH";
            this.aBALPHDataGridViewTextBoxColumn.HeaderText = "Получатель";
            this.aBALPHDataGridViewTextBoxColumn.Name = "aBALPHDataGridViewTextBoxColumn";
            this.aBALPHDataGridViewTextBoxColumn.ReadOnly = true;
            this.aBALPHDataGridViewTextBoxColumn.Width = 400;
            // 
            // sDDCTODataGridViewTextBoxColumn
            // 
            this.sDDCTODataGridViewTextBoxColumn.DataPropertyName = "SDDCTO";
            this.sDDCTODataGridViewTextBoxColumn.HeaderText = "Тип заказа";
            this.sDDCTODataGridViewTextBoxColumn.Name = "sDDCTODataGridViewTextBoxColumn";
            this.sDDCTODataGridViewTextBoxColumn.ReadOnly = true;
            this.sDDCTODataGridViewTextBoxColumn.Width = 80;
            // 
            // psnidDataGridViewTextBoxColumn
            // 
            this.psnidDataGridViewTextBoxColumn.DataPropertyName = "psn_id";
            this.psnidDataGridViewTextBoxColumn.HeaderText = "Номер сборочного";
            this.psnidDataGridViewTextBoxColumn.Name = "psnidDataGridViewTextBoxColumn";
            this.psnidDataGridViewTextBoxColumn.ReadOnly = true;
            this.psnidDataGridViewTextBoxColumn.Width = 160;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "box_barcode";
            this.Column1.HeaderText = "Код ящика";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 200;
            // 
            // multiPickSlipDetailsBindingSource
            // 
            this.multiPickSlipDetailsBindingSource.DataMember = "MultiPickSlipDetails";
            this.multiPickSlipDetailsBindingSource.DataSource = this.pickControl;
            // 
            // pickControl
            // 
            this.pickControl.DataSetName = "PickControl";
            this.pickControl.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // multiPickSlipDetailsTableAdapter
            // 
            this.multiPickSlipDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // scMainLayout
            // 
            this.scMainLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scMainLayout.Location = new System.Drawing.Point(0, 2);
            this.scMainLayout.Name = "scMainLayout";
            this.scMainLayout.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMainLayout.Panel1
            // 
            this.scMainLayout.Panel1.Controls.Add(this.pnlHeader);
            this.scMainLayout.Panel1.Controls.Add(this.dgvDetails);
            // 
            // scMainLayout.Panel2
            // 
            this.scMainLayout.Panel2.Controls.Add(this.pnlRecommendedPickSlips);
            this.scMainLayout.Panel2.Controls.Add(this.dgvRecommendedPickSlips);
            this.scMainLayout.Size = new System.Drawing.Size(894, 521);
            this.scMainLayout.SplitterDistance = 270;
            this.scMainLayout.TabIndex = 0;
            // 
            // pnlRecommendedPickSlips
            // 
            this.pnlRecommendedPickSlips.Controls.Add(this.lblRecommendedPickSlips);
            this.pnlRecommendedPickSlips.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRecommendedPickSlips.Location = new System.Drawing.Point(0, 0);
            this.pnlRecommendedPickSlips.Name = "pnlRecommendedPickSlips";
            this.pnlRecommendedPickSlips.Size = new System.Drawing.Size(894, 20);
            this.pnlRecommendedPickSlips.TabIndex = 1;
            // 
            // lblRecommendedPickSlips
            // 
            this.lblRecommendedPickSlips.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRecommendedPickSlips.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRecommendedPickSlips.Location = new System.Drawing.Point(0, 0);
            this.lblRecommendedPickSlips.Name = "lblRecommendedPickSlips";
            this.lblRecommendedPickSlips.Size = new System.Drawing.Size(894, 20);
            this.lblRecommendedPickSlips.TabIndex = 0;
            this.lblRecommendedPickSlips.Text = "Рекомендуемые сборочные";
            this.lblRecommendedPickSlips.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvRecommendedPickSlips
            // 
            this.dgvRecommendedPickSlips.AllowUserToAddRows = false;
            this.dgvRecommendedPickSlips.AllowUserToDeleteRows = false;
            this.dgvRecommendedPickSlips.AllowUserToResizeColumns = false;
            this.dgvRecommendedPickSlips.AllowUserToResizeRows = false;
            this.dgvRecommendedPickSlips.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRecommendedPickSlips.AutoGenerateColumns = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRecommendedPickSlips.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvRecommendedPickSlips.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecommendedPickSlips.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pickSlipNumberDataGridViewTextBoxColumn,
            this.pickVolumeDataGridViewTextBoxColumn,
            this.pickLinesDataGridViewTextBoxColumn,
            this.pickItemsDataGridViewTextBoxColumn,
            this.pickBoxDataGridViewTextBoxColumn,
            this.deliveryDateDataGridViewTextBoxColumn,
            this.deliveryZoneDataGridViewTextBoxColumn});
            this.dgvRecommendedPickSlips.DataSource = this.recomendedPickSlipsBindingSource;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRecommendedPickSlips.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvRecommendedPickSlips.Location = new System.Drawing.Point(0, 23);
            this.dgvRecommendedPickSlips.MultiSelect = false;
            this.dgvRecommendedPickSlips.Name = "dgvRecommendedPickSlips";
            this.dgvRecommendedPickSlips.ReadOnly = true;
            this.dgvRecommendedPickSlips.RowHeadersVisible = false;
            this.dgvRecommendedPickSlips.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecommendedPickSlips.Size = new System.Drawing.Size(894, 224);
            this.dgvRecommendedPickSlips.TabIndex = 0;
            // 
            // pickSlipNumberDataGridViewTextBoxColumn
            // 
            this.pickSlipNumberDataGridViewTextBoxColumn.DataPropertyName = "PickSlipNumber";
            this.pickSlipNumberDataGridViewTextBoxColumn.HeaderText = "Номер сборочного";
            this.pickSlipNumberDataGridViewTextBoxColumn.Name = "pickSlipNumberDataGridViewTextBoxColumn";
            this.pickSlipNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.pickSlipNumberDataGridViewTextBoxColumn.Width = 160;
            // 
            // pickVolumeDataGridViewTextBoxColumn
            // 
            this.pickVolumeDataGridViewTextBoxColumn.DataPropertyName = "PickVolume";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N1";
            dataGridViewCellStyle5.NullValue = null;
            this.pickVolumeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.pickVolumeDataGridViewTextBoxColumn.HeaderText = "Объем, л";
            this.pickVolumeDataGridViewTextBoxColumn.Name = "pickVolumeDataGridViewTextBoxColumn";
            this.pickVolumeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pickLinesDataGridViewTextBoxColumn
            // 
            this.pickLinesDataGridViewTextBoxColumn.DataPropertyName = "PickLines";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = null;
            this.pickLinesDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.pickLinesDataGridViewTextBoxColumn.HeaderText = "Кол-во строк";
            this.pickLinesDataGridViewTextBoxColumn.Name = "pickLinesDataGridViewTextBoxColumn";
            this.pickLinesDataGridViewTextBoxColumn.ReadOnly = true;
            this.pickLinesDataGridViewTextBoxColumn.Width = 85;
            // 
            // pickItemsDataGridViewTextBoxColumn
            // 
            this.pickItemsDataGridViewTextBoxColumn.DataPropertyName = "PickItems";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            dataGridViewCellStyle7.NullValue = null;
            this.pickItemsDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.pickItemsDataGridViewTextBoxColumn.HeaderText = "Кол-во упаковок, шт.";
            this.pickItemsDataGridViewTextBoxColumn.Name = "pickItemsDataGridViewTextBoxColumn";
            this.pickItemsDataGridViewTextBoxColumn.ReadOnly = true;
            this.pickItemsDataGridViewTextBoxColumn.Width = 120;
            // 
            // pickBoxDataGridViewTextBoxColumn
            // 
            this.pickBoxDataGridViewTextBoxColumn.DataPropertyName = "PickBox";
            this.pickBoxDataGridViewTextBoxColumn.HeaderText = "Тип ящика";
            this.pickBoxDataGridViewTextBoxColumn.Name = "pickBoxDataGridViewTextBoxColumn";
            this.pickBoxDataGridViewTextBoxColumn.ReadOnly = true;
            this.pickBoxDataGridViewTextBoxColumn.Width = 160;
            // 
            // deliveryDateDataGridViewTextBoxColumn
            // 
            this.deliveryDateDataGridViewTextBoxColumn.DataPropertyName = "DeliveryDate";
            dataGridViewCellStyle8.Format = "d";
            dataGridViewCellStyle8.NullValue = null;
            this.deliveryDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.deliveryDateDataGridViewTextBoxColumn.HeaderText = "Дата доставки";
            this.deliveryDateDataGridViewTextBoxColumn.Name = "deliveryDateDataGridViewTextBoxColumn";
            this.deliveryDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.deliveryDateDataGridViewTextBoxColumn.Width = 125;
            // 
            // deliveryZoneDataGridViewTextBoxColumn
            // 
            this.deliveryZoneDataGridViewTextBoxColumn.DataPropertyName = "DeliveryZone";
            this.deliveryZoneDataGridViewTextBoxColumn.HeaderText = "Зона доставки";
            this.deliveryZoneDataGridViewTextBoxColumn.Name = "deliveryZoneDataGridViewTextBoxColumn";
            this.deliveryZoneDataGridViewTextBoxColumn.ReadOnly = true;
            this.deliveryZoneDataGridViewTextBoxColumn.Width = 90;
            // 
            // recomendedPickSlipsBindingSource
            // 
            this.recomendedPickSlipsBindingSource.DataMember = "RecomendedPickSlips";
            this.recomendedPickSlipsBindingSource.DataSource = this.pickControl;
            // 
            // recomendedPickSlipsTableAdapter
            // 
            this.recomendedPickSlipsTableAdapter.ClearBeforeFill = true;
            // 
            // MultiPickRegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 572);
            this.Controls.Add(this.scMainLayout);
            this.Name = "MultiPickRegistrationForm";
            this.Text = "Регистрация мультисборки";
            this.Load += new System.EventHandler(this.MultiPickRegistrationForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MultiPickRegistrationForm_FormClosing);
            this.Controls.SetChildIndex(this.scMainLayout, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.multiPickSlipDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).EndInit();
            this.scMainLayout.Panel1.ResumeLayout(false);
            this.scMainLayout.Panel2.ResumeLayout(false);
            this.scMainLayout.ResumeLayout(false);
            this.pnlRecommendedPickSlips.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecommendedPickSlips)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recomendedPickSlipsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.Label label1;
        private WMSOffice.Controls.TextBoxScaner tbBarcode;
        private System.Windows.Forms.BindingSource multiPickSlipDetailsBindingSource;
        private WMSOffice.Data.PickControl pickControl;
        private WMSOffice.Data.PickControlTableAdapters.MultiPickSlipDetailsTableAdapter multiPickSlipDetailsTableAdapter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPrinters;
        private System.Windows.Forms.DataGridViewTextBoxColumn aBALPHDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sDDCTODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn psnidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPickSlipCount;
        private System.Windows.Forms.SplitContainer scMainLayout;
        private System.Windows.Forms.DataGridView dgvRecommendedPickSlips;
        private System.Windows.Forms.BindingSource recomendedPickSlipsBindingSource;
        private WMSOffice.Data.PickControlTableAdapters.RecomendedPickSlipsTableAdapter recomendedPickSlipsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn pickSlipNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pickVolumeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pickLinesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pickItemsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pickBoxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deliveryDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deliveryZoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel pnlRecommendedPickSlips;
        private System.Windows.Forms.Label lblRecommendedPickSlips;
    }
}