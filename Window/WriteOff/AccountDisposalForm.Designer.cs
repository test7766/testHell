namespace WMSOffice.Window.WriteOff
{
    partial class AccountDisposalForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountDisposalForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.nudSumWithoutVAT = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.isCheckedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.requestnumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requestcreatedateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isprintedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isprintedstrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendornameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.summ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoice_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.util_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wFGetDestructionRequestsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wH = new WMSOffice.Data.WH();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.wF_Get_Destruction_RequestsTableAdapter = new WMSOffice.Data.WHTableAdapters.WF_Get_Destruction_RequestsTableAdapter();
            this.label6 = new System.Windows.Forms.Label();
            this.nudSumWithVAT = new System.Windows.Forms.NumericUpDown();
            this.cmbVATRate = new System.Windows.Forms.ComboBox();
            this.vatRateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wF = new WMSOffice.Data.WF();
            this.label7 = new System.Windows.Forms.Label();
            this.rbNotProcessed = new System.Windows.Forms.RadioButton();
            this.chbShowSelected = new System.Windows.Forms.CheckBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stbContract = new WMSOffice.Controls.SearchTextBox();
            this.stbPartner = new WMSOffice.Controls.SearchTextBox();
            this.customDataGridViewCheckBoxColumn1 = new WMSOffice.Dialogs.Inventory.CustomDataGridViewCheckBoxColumn();
            this.gbFilters = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudSumWithoutVAT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wFGetDestructionRequestsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSumWithVAT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vatRateBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wF)).BeginInit();
            this.gbFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(139, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(139, 32);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(100, 20);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // nudSumWithoutVAT
            // 
            this.nudSumWithoutVAT.DecimalPlaces = 2;
            this.nudSumWithoutVAT.Location = new System.Drawing.Point(139, 60);
            this.nudSumWithoutVAT.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            131072});
            this.nudSumWithoutVAT.Name = "nudSumWithoutVAT";
            this.nudSumWithoutVAT.Size = new System.Drawing.Size(100, 20);
            this.nudSumWithoutVAT.TabIndex = 9;
            this.nudSumWithoutVAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudSumWithoutVAT.ValueChanged += new System.EventHandler(this.nudSumWithoutVAT_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "№ счета";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Дата счета";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Сумма счета без НДС";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(251, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Контрагент";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(251, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Договор";
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDel.Enabled = false;
            this.btnDel.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.Image")));
            this.btnDel.Location = new System.Drawing.Point(951, 112);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(25, 25);
            this.btnDel.TabIndex = 16;
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(927, 112);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(25, 25);
            this.btnAdd.TabIndex = 15;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // listView
            // 
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.HideSelection = false;
            this.listView.LargeImageList = this.imageList;
            this.listView.Location = new System.Drawing.Point(654, 4);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(321, 108);
            this.listView.TabIndex = 14;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(32, 32);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeight = 32;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.isCheckedDataGridViewCheckBoxColumn,
            this.requestnumberDataGridViewTextBoxColumn,
            this.requestcreatedateDataGridViewTextBoxColumn,
            this.isprintedDataGridViewCheckBoxColumn,
            this.isprintedstrDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.vendornameDataGridViewTextBoxColumn,
            this.weight,
            this.summ,
            this.invoice_number,
            this.util_date});
            this.dataGridView1.DataSource = this.wFGetDestructionRequestsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(0, 142);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 10;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(978, 380);
            this.dataGridView1.TabIndex = 19;
            this.dataGridView1.Sorted += new System.EventHandler(this.dataGridView1_Sorted);
            // 
            // isCheckedDataGridViewCheckBoxColumn
            // 
            this.isCheckedDataGridViewCheckBoxColumn.DataPropertyName = "isChecked";
            this.isCheckedDataGridViewCheckBoxColumn.HeaderText = "";
            this.isCheckedDataGridViewCheckBoxColumn.Name = "isCheckedDataGridViewCheckBoxColumn";
            this.isCheckedDataGridViewCheckBoxColumn.Width = 25;
            // 
            // requestnumberDataGridViewTextBoxColumn
            // 
            this.requestnumberDataGridViewTextBoxColumn.DataPropertyName = "request_number";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.requestnumberDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.requestnumberDataGridViewTextBoxColumn.HeaderText = "Номер";
            this.requestnumberDataGridViewTextBoxColumn.Name = "requestnumberDataGridViewTextBoxColumn";
            this.requestnumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.requestnumberDataGridViewTextBoxColumn.Width = 66;
            // 
            // requestcreatedateDataGridViewTextBoxColumn
            // 
            this.requestcreatedateDataGridViewTextBoxColumn.DataPropertyName = "request_create_date";
            this.requestcreatedateDataGridViewTextBoxColumn.HeaderText = "Дата заявки";
            this.requestcreatedateDataGridViewTextBoxColumn.Name = "requestcreatedateDataGridViewTextBoxColumn";
            this.requestcreatedateDataGridViewTextBoxColumn.Width = 97;
            // 
            // isprintedDataGridViewCheckBoxColumn
            // 
            this.isprintedDataGridViewCheckBoxColumn.DataPropertyName = "is_printed";
            this.isprintedDataGridViewCheckBoxColumn.HeaderText = "is_printed";
            this.isprintedDataGridViewCheckBoxColumn.Name = "isprintedDataGridViewCheckBoxColumn";
            this.isprintedDataGridViewCheckBoxColumn.Visible = false;
            // 
            // isprintedstrDataGridViewTextBoxColumn
            // 
            this.isprintedstrDataGridViewTextBoxColumn.DataPropertyName = "is_printed_str";
            this.isprintedstrDataGridViewTextBoxColumn.HeaderText = "is_printed_str";
            this.isprintedstrDataGridViewTextBoxColumn.Name = "isprintedstrDataGridViewTextBoxColumn";
            this.isprintedstrDataGridViewTextBoxColumn.ReadOnly = true;
            this.isprintedstrDataGridViewTextBoxColumn.Visible = false;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Описание заявки";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.descriptionDataGridViewTextBoxColumn.Width = 350;
            // 
            // vendornameDataGridViewTextBoxColumn
            // 
            this.vendornameDataGridViewTextBoxColumn.DataPropertyName = "vendor_name";
            this.vendornameDataGridViewTextBoxColumn.HeaderText = "vendor_name";
            this.vendornameDataGridViewTextBoxColumn.Name = "vendornameDataGridViewTextBoxColumn";
            this.vendornameDataGridViewTextBoxColumn.ReadOnly = true;
            this.vendornameDataGridViewTextBoxColumn.Visible = false;
            // 
            // weight
            // 
            this.weight.DataPropertyName = "weight";
            this.weight.HeaderText = "Вес заявки";
            this.weight.Name = "weight";
            this.weight.ReadOnly = true;
            // 
            // summ
            // 
            this.summ.DataPropertyName = "summ";
            this.summ.HeaderText = "Сумма с НДС";
            this.summ.Name = "summ";
            this.summ.ReadOnly = true;
            // 
            // invoice_number
            // 
            this.invoice_number.DataPropertyName = "invoice_number";
            this.invoice_number.HeaderText = "№ счёта";
            this.invoice_number.Name = "invoice_number";
            this.invoice_number.ReadOnly = true;
            // 
            // util_date
            // 
            this.util_date.DataPropertyName = "util_date";
            this.util_date.HeaderText = "Дата счёта";
            this.util_date.Name = "util_date";
            this.util_date.ReadOnly = true;
            // 
            // wFGetDestructionRequestsBindingSource
            // 
            this.wFGetDestructionRequestsBindingSource.DataMember = "WF_Get_Destruction_Requests";
            this.wFGetDestructionRequestsBindingSource.DataSource = this.wH;
            // 
            // wH
            // 
            this.wH.DataSetName = "WH";
            this.wH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAccept.Location = new System.Drawing.Point(774, 528);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(98, 25);
            this.btnAccept.TabIndex = 20;
            this.btnAccept.Text = "Сохранить";
            this.btnAccept.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(877, 528);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 25);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(406, 4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(242, 20);
            this.textBox2.TabIndex = 5;
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(406, 32);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(242, 20);
            this.textBox3.TabIndex = 7;
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Location = new System.Drawing.Point(139, 22);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(44, 17);
            this.rbAll.TabIndex = 17;
            this.rbAll.Text = "Все";
            this.rbAll.UseVisualStyleBackColor = true;
            this.rbAll.CheckedChanged += new System.EventHandler(this.rbFilterType_CheckedChenged);
            // 
            // wF_Get_Destruction_RequestsTableAdapter
            // 
            this.wF_Get_Destruction_RequestsTableAdapter.ClearBeforeFill = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(434, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Сумма счета с НДС";
            // 
            // nudSumWithVAT
            // 
            this.nudSumWithVAT.BackColor = System.Drawing.SystemColors.Window;
            this.nudSumWithVAT.DecimalPlaces = 2;
            this.nudSumWithVAT.Enabled = false;
            this.nudSumWithVAT.Location = new System.Drawing.Point(548, 60);
            this.nudSumWithVAT.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            131072});
            this.nudSumWithVAT.Name = "nudSumWithVAT";
            this.nudSumWithVAT.ReadOnly = true;
            this.nudSumWithVAT.Size = new System.Drawing.Size(100, 20);
            this.nudSumWithVAT.TabIndex = 13;
            this.nudSumWithVAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmbVATRate
            // 
            this.cmbVATRate.DataSource = this.vatRateBindingSource;
            this.cmbVATRate.DisplayMember = "Name";
            this.cmbVATRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVATRate.FormattingEnabled = true;
            this.cmbVATRate.Location = new System.Drawing.Point(327, 60);
            this.cmbVATRate.Name = "cmbVATRate";
            this.cmbVATRate.Size = new System.Drawing.Size(73, 21);
            this.cmbVATRate.TabIndex = 11;
            this.cmbVATRate.ValueMember = "Ratio";
            this.cmbVATRate.SelectedValueChanged += new System.EventHandler(this.cmbVATRate_SelectedValueChanged);
            // 
            // vatRateBindingSource
            // 
            this.vatRateBindingSource.DataMember = "VatRate";
            this.vatRateBindingSource.DataSource = this.wF;
            // 
            // wF
            // 
            this.wF.DataSetName = "WF";
            this.wF.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(251, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Ставка НДС";
            // 
            // rbNotProcessed
            // 
            this.rbNotProcessed.AutoSize = true;
            this.rbNotProcessed.Checked = true;
            this.rbNotProcessed.Location = new System.Drawing.Point(14, 22);
            this.rbNotProcessed.Name = "rbNotProcessed";
            this.rbNotProcessed.Size = new System.Drawing.Size(115, 17);
            this.rbNotProcessed.TabIndex = 22;
            this.rbNotProcessed.TabStop = true;
            this.rbNotProcessed.Text = "Не обработанные";
            this.rbNotProcessed.UseVisualStyleBackColor = true;
            this.rbNotProcessed.CheckedChanged += new System.EventHandler(this.rbFilterType_CheckedChenged);
            // 
            // chbShowSelected
            // 
            this.chbShowSelected.AutoSize = true;
            this.chbShowSelected.Location = new System.Drawing.Point(235, 22);
            this.chbShowSelected.Name = "chbShowSelected";
            this.chbShowSelected.Size = new System.Drawing.Size(128, 17);
            this.chbShowSelected.TabIndex = 23;
            this.chbShowSelected.Text = "Только отмеченные";
            this.chbShowSelected.UseVisualStyleBackColor = true;
            this.chbShowSelected.CheckedChanged += new System.EventHandler(this.chbShowSelected_CheckedChanged);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(423, 24);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(119, 13);
            this.lblFilter.TabIndex = 24;
            this.lblFilter.Text = "Номер заявки / счета";
            // 
            // tbFilter
            // 
            this.tbFilter.Location = new System.Drawing.Point(548, 20);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(78, 20);
            this.tbFilter.TabIndex = 25;
            this.tbFilter.TextChanged += new System.EventHandler(this.tbFilter_TextChanged);
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.BackgroundImage = global::WMSOffice.Properties.Resources.clear_32;
            this.btnClearFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClearFilter.Location = new System.Drawing.Point(626, 19);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(22, 22);
            this.btnClearFilter.TabIndex = 26;
            this.btnClearFilter.UseVisualStyleBackColor = true;
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "isCkecked";
            this.dataGridViewCheckBoxColumn1.FalseValue = "False";
            this.dataGridViewCheckBoxColumn1.HeaderText = "";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewCheckBoxColumn1.TrueValue = "True";
            this.dataGridViewCheckBoxColumn1.Width = 23;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "request_number";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn1.HeaderText = "Номер";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "request_created_date";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn2.HeaderText = "Дата создания";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.DataPropertyName = "is_printed";
            this.dataGridViewCheckBoxColumn2.HeaderText = "is_printed";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "description";
            this.dataGridViewTextBoxColumn3.HeaderText = "Описание заявки";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "description";
            this.dataGridViewTextBoxColumn4.HeaderText = "Опимание заявки";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "vendor_name";
            this.dataGridViewTextBoxColumn5.HeaderText = "vendor_name";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "weight";
            this.dataGridViewTextBoxColumn6.HeaderText = "Вес заявки";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "summ";
            this.dataGridViewTextBoxColumn7.HeaderText = "Сумма с НДС";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "invoice_number";
            this.dataGridViewTextBoxColumn8.HeaderText = "№ счёта";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "util_date";
            this.dataGridViewTextBoxColumn9.HeaderText = "Дата счёта";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // stbContract
            // 
            this.stbContract.Location = new System.Drawing.Point(327, 32);
            this.stbContract.Name = "stbContract";
            this.stbContract.ReadOnly = false;
            this.stbContract.Size = new System.Drawing.Size(73, 20);
            this.stbContract.TabIndex = 6;
            this.stbContract.UserID = ((long)(0));
            this.stbContract.Value = null;
            this.stbContract.ValueReferenceQuery = null;
            this.stbContract.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(this.stbContract_OnVerifyValue);
            // 
            // stbPartner
            // 
            this.stbPartner.Location = new System.Drawing.Point(327, 4);
            this.stbPartner.Name = "stbPartner";
            this.stbPartner.ReadOnly = false;
            this.stbPartner.Size = new System.Drawing.Size(73, 20);
            this.stbPartner.TabIndex = 4;
            this.stbPartner.UserID = ((long)(0));
            this.stbPartner.Value = null;
            this.stbPartner.ValueReferenceQuery = null;
            this.stbPartner.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(this.stbPartner_OnVerifyValue);
            // 
            // customDataGridViewCheckBoxColumn1
            // 
            this.customDataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.customDataGridViewCheckBoxColumn1.HeaderText = "";
            this.customDataGridViewCheckBoxColumn1.Name = "customDataGridViewCheckBoxColumn1";
            this.customDataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.customDataGridViewCheckBoxColumn1.TrueValue = "";
            this.customDataGridViewCheckBoxColumn1.Width = 23;
            // 
            // gbFilters
            // 
            this.gbFilters.Controls.Add(this.lblFilter);
            this.gbFilters.Controls.Add(this.btnClearFilter);
            this.gbFilters.Controls.Add(this.rbAll);
            this.gbFilters.Controls.Add(this.tbFilter);
            this.gbFilters.Controls.Add(this.rbNotProcessed);
            this.gbFilters.Controls.Add(this.chbShowSelected);
            this.gbFilters.Location = new System.Drawing.Point(0, 96);
            this.gbFilters.Name = "gbFilters";
            this.gbFilters.Size = new System.Drawing.Size(656, 45);
            this.gbFilters.TabIndex = 27;
            this.gbFilters.TabStop = false;
            this.gbFilters.Text = "Фильтры";
            // 
            // AccountDisposalForm
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(979, 556);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.gbFilters);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbVATRate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nudSumWithVAT);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stbContract);
            this.Controls.Add(this.stbPartner);
            this.Controls.Add(this.nudSumWithoutVAT);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AccountDisposalForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Счет за услуги утилизации";
            ((System.ComponentModel.ISupportInitialize)(this.nudSumWithoutVAT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wFGetDestructionRequestsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSumWithVAT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vatRateBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wF)).EndInit();
            this.gbFilters.ResumeLayout(false);
            this.gbFilters.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.NumericUpDown nudSumWithoutVAT;
        private WMSOffice.Controls.SearchTextBox stbPartner;
        private WMSOffice.Controls.SearchTextBox stbContract;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private WMSOffice.Dialogs.Inventory.CustomDataGridViewCheckBoxColumn customDataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.BindingSource wFGetDestructionRequestsBindingSource;
        private WMSOffice.Data.WH wH;
        private WMSOffice.Data.WHTableAdapters.WF_Get_Destruction_RequestsTableAdapter wF_Get_Destruction_RequestsTableAdapter;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isCheckedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn requestnumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn requestcreatedateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isprintedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn isprintedstrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendornameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn summ;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoice_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn util_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudSumWithVAT;
        private System.Windows.Forms.ComboBox cmbVATRate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.BindingSource vatRateBindingSource;
        private WMSOffice.Data.WF wF;
        private System.Windows.Forms.RadioButton rbNotProcessed;
        private System.Windows.Forms.CheckBox chbShowSelected;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.TextBox tbFilter;
        private System.Windows.Forms.Button btnClearFilter;
        private System.Windows.Forms.GroupBox gbFilters;
    }
}