namespace WMSOffice.Dialogs.Receive
{
    partial class PrintedYellowLabelsForm
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
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.sbDeleteYellowLabels = new System.Windows.Forms.ToolStripButton();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.gbItem = new System.Windows.Forms.GroupBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdYLBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.receive = new WMSOffice.Data.Receive();
            this.createdYLTableAdapter = new WMSOffice.Data.ReceiveTableAdapters.CreatedYLTableAdapter();
            this.dgvcCheckItems = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bLITMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nAZVADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vyrobnikDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bLLOTNDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iorlotDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bLUKIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bLCONVDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bLCSTGDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bLEV01DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bLEV02DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bLUPMJDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFooter.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlDetails.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.gbItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.createdYLBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receive)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnClose);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 432);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(894, 40);
            this.pnlFooter.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(807, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlDetails);
            this.pnlMain.Controls.Add(this.gbItem);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(894, 432);
            this.pnlMain.TabIndex = 1;
            // 
            // pnlDetails
            // 
            this.pnlDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDetails.Controls.Add(this.toolStrip1);
            this.pnlDetails.Controls.Add(this.dgvDetails);
            this.pnlDetails.Location = new System.Drawing.Point(3, 124);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(888, 305);
            this.pnlDetails.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbDeleteYellowLabels});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(888, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // sbDeleteYellowLabels
            // 
            this.sbDeleteYellowLabels.Image = global::WMSOffice.Properties.Resources.Delete;
            this.sbDeleteYellowLabels.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbDeleteYellowLabels.Name = "sbDeleteYellowLabels";
            this.sbDeleteYellowLabels.Size = new System.Drawing.Size(94, 22);
            this.sbDeleteYellowLabels.Text = "Удалить ж/э";
            this.sbDeleteYellowLabels.Click += new System.EventHandler(this.sbDeleteYellowLabels_Click);
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
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcCheckItems,
            this.bLITMDataGridViewTextBoxColumn,
            this.nAZVADataGridViewTextBoxColumn,
            this.vyrobnikDataGridViewTextBoxColumn,
            this.bLLOTNDataGridViewTextBoxColumn,
            this.iorlotDataGridViewTextBoxColumn,
            this.bLUKIDDataGridViewTextBoxColumn,
            this.bLCONVDataGridViewTextBoxColumn,
            this.bLCSTGDataGridViewTextBoxColumn,
            this.bLEV01DataGridViewTextBoxColumn,
            this.bLEV02DataGridViewTextBoxColumn,
            this.bLUPMJDataGridViewTextBoxColumn,
            this.employeeDataGridViewTextBoxColumn});
            this.dgvDetails.DataSource = this.createdYLBindingSource;
            this.dgvDetails.Location = new System.Drawing.Point(3, 28);
            this.dgvDetails.MultiSelect = false;
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.RowHeadersVisible = false;
            this.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetails.Size = new System.Drawing.Size(882, 274);
            this.dgvDetails.TabIndex = 0;
            this.dgvDetails.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDetails_CellFormatting);
            this.dgvDetails.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvDetails_CurrentCellDirtyStateChanged);
            // 
            // gbItem
            // 
            this.gbItem.Controls.Add(this.textBox5);
            this.gbItem.Controls.Add(this.label5);
            this.gbItem.Controls.Add(this.textBox3);
            this.gbItem.Controls.Add(this.label3);
            this.gbItem.Controls.Add(this.textBox4);
            this.gbItem.Controls.Add(this.label4);
            this.gbItem.Controls.Add(this.textBox2);
            this.gbItem.Controls.Add(this.label2);
            this.gbItem.Controls.Add(this.textBox1);
            this.gbItem.Controls.Add(this.label1);
            this.gbItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbItem.Location = new System.Drawing.Point(0, 0);
            this.gbItem.Name = "gbItem";
            this.gbItem.Size = new System.Drawing.Size(894, 118);
            this.gbItem.TabIndex = 1;
            this.gbItem.TabStop = false;
            this.gbItem.Text = "Товар";
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.Window;
            this.textBox5.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.createdYLBindingSource, "Vyrobnik", true));
            this.textBox5.Location = new System.Drawing.Point(101, 85);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(300, 20);
            this.textBox5.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Производитель";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Window;
            this.textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.createdYLBindingSource, "iorlot", true));
            this.textBox3.Location = new System.Drawing.Point(507, 53);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(200, 20);
            this.textBox3.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(457, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Серия";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Window;
            this.textBox4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.createdYLBindingSource, "NAZVA", true));
            this.textBox4.Location = new System.Drawing.Point(101, 53);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(300, 20);
            this.textBox4.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Наименование";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Window;
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.createdYLBindingSource, "BLLOTN", true));
            this.textBox2.Location = new System.Drawing.Point(507, 21);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(200, 20);
            this.textBox2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(457, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Партия";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.createdYLBindingSource, "BLITM", true));
            this.textBox1.Location = new System.Drawing.Point(101, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "КНН";
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "Отм.";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Width = 35;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "BLITM";
            this.dataGridViewTextBoxColumn1.HeaderText = "BLITM";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "NAZVA";
            this.dataGridViewTextBoxColumn2.HeaderText = "NAZVA";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Vyrobnik";
            this.dataGridViewTextBoxColumn3.HeaderText = "Vyrobnik";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "BLLOTN";
            this.dataGridViewTextBoxColumn4.HeaderText = "BLLOTN";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "iorlot";
            this.dataGridViewTextBoxColumn5.HeaderText = "iorlot";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "BLUKID";
            this.dataGridViewTextBoxColumn6.HeaderText = "BLUKID";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 63;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "BLCONV";
            this.dataGridViewTextBoxColumn7.HeaderText = "BLCONV";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 91;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "BLCSTG";
            this.dataGridViewTextBoxColumn8.HeaderText = "BLCSTG";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 55;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn9.DataPropertyName = "BLEV01";
            this.dataGridViewTextBoxColumn9.HeaderText = "BLEV01";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 92;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn10.DataPropertyName = "BLEV02";
            this.dataGridViewTextBoxColumn10.HeaderText = "BLEV02";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 75;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn11.DataPropertyName = "BLUPMJ";
            this.dataGridViewTextBoxColumn11.HeaderText = "BLUPMJ";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 58;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Employee";
            this.dataGridViewTextBoxColumn12.HeaderText = "Employee";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Width = 85;
            // 
            // createdYLBindingSource
            // 
            this.createdYLBindingSource.DataMember = "CreatedYL";
            this.createdYLBindingSource.DataSource = this.receive;
            // 
            // receive
            // 
            this.receive.DataSetName = "Receive";
            this.receive.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // createdYLTableAdapter
            // 
            this.createdYLTableAdapter.ClearBeforeFill = true;
            // 
            // dgvcCheckItems
            // 
            this.dgvcCheckItems.DataPropertyName = "IsChecked";
            this.dgvcCheckItems.HeaderText = "Отм.";
            this.dgvcCheckItems.Name = "dgvcCheckItems";
            this.dgvcCheckItems.Width = 35;
            // 
            // bLITMDataGridViewTextBoxColumn
            // 
            this.bLITMDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.bLITMDataGridViewTextBoxColumn.DataPropertyName = "BLITM";
            this.bLITMDataGridViewTextBoxColumn.HeaderText = "КНН";
            this.bLITMDataGridViewTextBoxColumn.Name = "bLITMDataGridViewTextBoxColumn";
            this.bLITMDataGridViewTextBoxColumn.ReadOnly = true;
            this.bLITMDataGridViewTextBoxColumn.Visible = false;
            this.bLITMDataGridViewTextBoxColumn.Width = 55;
            // 
            // nAZVADataGridViewTextBoxColumn
            // 
            this.nAZVADataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nAZVADataGridViewTextBoxColumn.DataPropertyName = "NAZVA";
            this.nAZVADataGridViewTextBoxColumn.HeaderText = "Наименование";
            this.nAZVADataGridViewTextBoxColumn.Name = "nAZVADataGridViewTextBoxColumn";
            this.nAZVADataGridViewTextBoxColumn.ReadOnly = true;
            this.nAZVADataGridViewTextBoxColumn.Visible = false;
            this.nAZVADataGridViewTextBoxColumn.Width = 108;
            // 
            // vyrobnikDataGridViewTextBoxColumn
            // 
            this.vyrobnikDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.vyrobnikDataGridViewTextBoxColumn.DataPropertyName = "Vyrobnik";
            this.vyrobnikDataGridViewTextBoxColumn.HeaderText = "Производитель";
            this.vyrobnikDataGridViewTextBoxColumn.Name = "vyrobnikDataGridViewTextBoxColumn";
            this.vyrobnikDataGridViewTextBoxColumn.ReadOnly = true;
            this.vyrobnikDataGridViewTextBoxColumn.Visible = false;
            this.vyrobnikDataGridViewTextBoxColumn.Width = 111;
            // 
            // bLLOTNDataGridViewTextBoxColumn
            // 
            this.bLLOTNDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.bLLOTNDataGridViewTextBoxColumn.DataPropertyName = "BLLOTN";
            this.bLLOTNDataGridViewTextBoxColumn.HeaderText = "Партия";
            this.bLLOTNDataGridViewTextBoxColumn.Name = "bLLOTNDataGridViewTextBoxColumn";
            this.bLLOTNDataGridViewTextBoxColumn.ReadOnly = true;
            this.bLLOTNDataGridViewTextBoxColumn.Visible = false;
            this.bLLOTNDataGridViewTextBoxColumn.Width = 69;
            // 
            // iorlotDataGridViewTextBoxColumn
            // 
            this.iorlotDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.iorlotDataGridViewTextBoxColumn.DataPropertyName = "iorlot";
            this.iorlotDataGridViewTextBoxColumn.HeaderText = "Серия";
            this.iorlotDataGridViewTextBoxColumn.Name = "iorlotDataGridViewTextBoxColumn";
            this.iorlotDataGridViewTextBoxColumn.ReadOnly = true;
            this.iorlotDataGridViewTextBoxColumn.Visible = false;
            this.iorlotDataGridViewTextBoxColumn.Width = 63;
            // 
            // bLUKIDDataGridViewTextBoxColumn
            // 
            this.bLUKIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.bLUKIDDataGridViewTextBoxColumn.DataPropertyName = "BLUKID";
            this.bLUKIDDataGridViewTextBoxColumn.HeaderText = "№ п/п";
            this.bLUKIDDataGridViewTextBoxColumn.Name = "bLUKIDDataGridViewTextBoxColumn";
            this.bLUKIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.bLUKIDDataGridViewTextBoxColumn.Width = 63;
            // 
            // bLCONVDataGridViewTextBoxColumn
            // 
            this.bLCONVDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.bLCONVDataGridViewTextBoxColumn.DataPropertyName = "BLCONV";
            this.bLCONVDataGridViewTextBoxColumn.HeaderText = "Количество";
            this.bLCONVDataGridViewTextBoxColumn.Name = "bLCONVDataGridViewTextBoxColumn";
            this.bLCONVDataGridViewTextBoxColumn.ReadOnly = true;
            this.bLCONVDataGridViewTextBoxColumn.Width = 91;
            // 
            // bLCSTGDataGridViewTextBoxColumn
            // 
            this.bLCSTGDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.bLCSTGDataGridViewTextBoxColumn.DataPropertyName = "BLCSTG";
            this.bLCSTGDataGridViewTextBoxColumn.HeaderText = "Ж/Э";
            this.bLCSTGDataGridViewTextBoxColumn.Name = "bLCSTGDataGridViewTextBoxColumn";
            this.bLCSTGDataGridViewTextBoxColumn.ReadOnly = true;
            this.bLCSTGDataGridViewTextBoxColumn.Width = 55;
            // 
            // bLEV01DataGridViewTextBoxColumn
            // 
            this.bLEV01DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.bLEV01DataGridViewTextBoxColumn.DataPropertyName = "BLEV01";
            this.bLEV01DataGridViewTextBoxColumn.HeaderText = "Напечатана";
            this.bLEV01DataGridViewTextBoxColumn.Name = "bLEV01DataGridViewTextBoxColumn";
            this.bLEV01DataGridViewTextBoxColumn.ReadOnly = true;
            this.bLEV01DataGridViewTextBoxColumn.Width = 92;
            // 
            // bLEV02DataGridViewTextBoxColumn
            // 
            this.bLEV02DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.bLEV02DataGridViewTextBoxColumn.DataPropertyName = "BLEV02";
            this.bLEV02DataGridViewTextBoxColumn.HeaderText = "Принята";
            this.bLEV02DataGridViewTextBoxColumn.Name = "bLEV02DataGridViewTextBoxColumn";
            this.bLEV02DataGridViewTextBoxColumn.ReadOnly = true;
            this.bLEV02DataGridViewTextBoxColumn.Width = 75;
            // 
            // bLUPMJDataGridViewTextBoxColumn
            // 
            this.bLUPMJDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.bLUPMJDataGridViewTextBoxColumn.DataPropertyName = "BLUPMJ";
            this.bLUPMJDataGridViewTextBoxColumn.HeaderText = "Дата";
            this.bLUPMJDataGridViewTextBoxColumn.Name = "bLUPMJDataGridViewTextBoxColumn";
            this.bLUPMJDataGridViewTextBoxColumn.ReadOnly = true;
            this.bLUPMJDataGridViewTextBoxColumn.Width = 58;
            // 
            // employeeDataGridViewTextBoxColumn
            // 
            this.employeeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.employeeDataGridViewTextBoxColumn.DataPropertyName = "Employee";
            this.employeeDataGridViewTextBoxColumn.HeaderText = "Сотрудник";
            this.employeeDataGridViewTextBoxColumn.Name = "employeeDataGridViewTextBoxColumn";
            this.employeeDataGridViewTextBoxColumn.ReadOnly = true;
            this.employeeDataGridViewTextBoxColumn.Width = 85;
            // 
            // PrintedYellowLabelsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 472);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlFooter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PrintedYellowLabelsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Напечатанные ж/э";
            this.Load += new System.EventHandler(this.PrintedYellowLabelsForm_Load);
            this.pnlFooter.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlDetails.ResumeLayout(false);
            this.pnlDetails.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.gbItem.ResumeLayout(false);
            this.gbItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.createdYLBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receive)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.BindingSource createdYLBindingSource;
        private WMSOffice.Data.Receive receive;
        private WMSOffice.Data.ReceiveTableAdapters.CreatedYLTableAdapter createdYLTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.GroupBox gbItem;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton sbDeleteYellowLabels;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvcCheckItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn bLITMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nAZVADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vyrobnikDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bLLOTNDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iorlotDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bLUKIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bLCONVDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bLCSTGDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bLEV01DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bLEV02DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bLUPMJDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeDataGridViewTextBoxColumn;
    }
}