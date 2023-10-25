namespace WMSOffice.Window
{
    partial class InterbranchFacturesWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InterbranchFacturesWindow));
            this.toolStripDoc = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.btnPrintPreview = new System.Windows.Forms.ToolStripButton();
            this.btnRegisterPreview = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.lblPrinter = new System.Windows.Forms.ToolStripLabel();
            this.cbPrinters = new System.Windows.Forms.ToolStripComboBox();
            this.dgvFactures = new System.Windows.Forms.DataGridView();
            this.facturesListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iBFactures = new WMSOffice.Data.IBFactures();
            this.lblDocsCount = new System.Windows.Forms.Label();
            this.lblDocsCountCaption = new System.Windows.Forms.Label();
            this.kcooDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dctoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.senderIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.senderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shipToIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shipToDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shipDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.summDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripDoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFactures)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturesListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iBFactures)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripDoc
            // 
            this.toolStripDoc.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStripDoc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.toolStripSeparator1,
            this.btnPrint,
            this.btnPrintPreview,
            this.btnRegisterPreview,
            this.toolStripSeparator2,
            this.btnFind,
            this.toolStripSeparator3,
            this.lblPrinter,
            this.cbPrinters});
            this.toolStripDoc.Location = new System.Drawing.Point(0, 40);
            this.toolStripDoc.Name = "toolStripDoc";
            this.toolStripDoc.Size = new System.Drawing.Size(974, 55);
            this.toolStripDoc.TabIndex = 3;
            this.toolStripDoc.Text = "Панель инструментов документа";
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(52, 52);
            this.btnRefresh.Text = "Обновить список нераспечатанных накладных";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::WMSOffice.Properties.Resources.document_print;
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(123, 52);
            this.btnPrint.Text = "Напечатать\rвыбранные\rнакладные";
            this.btnPrint.ToolTipText = "Напечатать \rвыбранные \rнакладные";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Image = global::WMSOffice.Properties.Resources.document_print_preview;
            this.btnPrintPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(114, 52);
            this.btnPrintPreview.Text = "Предв.\rпросмотр";
            this.btnPrintPreview.ToolTipText = "Предварительный \rпросмотр";
            this.btnPrintPreview.Click += new System.EventHandler(this.btnPrintPreview_Click);
            // 
            // btnRegisterPreview
            // 
            this.btnRegisterPreview.Image = global::WMSOffice.Properties.Resources.document_print_preview;
            this.btnRegisterPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRegisterPreview.Name = "btnRegisterPreview";
            this.btnRegisterPreview.Size = new System.Drawing.Size(116, 52);
            this.btnRegisterPreview.Text = "Просмотр\rреестра";
            this.btnRegisterPreview.ToolTipText = "Предварительный \rпросмотр";
            this.btnRegisterPreview.Click += new System.EventHandler(this.btnRegisterPreview_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // btnFind
            // 
            this.btnFind.Image = global::WMSOffice.Properties.Resources.find;
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(105, 52);
            this.btnFind.Text = "Поиск \rв архиве";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 55);
            // 
            // lblPrinter
            // 
            this.lblPrinter.Name = "lblPrinter";
            this.lblPrinter.Size = new System.Drawing.Size(58, 52);
            this.lblPrinter.Text = "Принтер:";
            // 
            // cbPrinters
            // 
            this.cbPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPrinters.Name = "cbPrinters";
            this.cbPrinters.Size = new System.Drawing.Size(230, 55);
            this.cbPrinters.SelectedIndexChanged += new System.EventHandler(this.cbPrinters_SelectedIndexChanged);
            // 
            // dgvFactures
            // 
            this.dgvFactures.AllowUserToAddRows = false;
            this.dgvFactures.AllowUserToDeleteRows = false;
            this.dgvFactures.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvFactures.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFactures.AutoGenerateColumns = false;
            this.dgvFactures.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFactures.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFactures.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFactures.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.kcooDataGridViewTextBoxColumn,
            this.dctoDataGridViewTextBoxColumn,
            this.docoDataGridViewTextBoxColumn,
            this.senderIDDataGridViewTextBoxColumn,
            this.senderDataGridViewTextBoxColumn,
            this.shipToIDDataGridViewTextBoxColumn,
            this.shipToDataGridViewTextBoxColumn,
            this.orderDateDataGridViewTextBoxColumn,
            this.shipDateDataGridViewTextBoxColumn,
            this.summDataGridViewTextBoxColumn,
            this.Descr});
            this.dgvFactures.DataSource = this.facturesListBindingSource;
            this.dgvFactures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFactures.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvFactures.Location = new System.Drawing.Point(0, 95);
            this.dgvFactures.Name = "dgvFactures";
            this.dgvFactures.RowHeadersVisible = false;
            this.dgvFactures.RowTemplate.Height = 21;
            this.dgvFactures.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFactures.ShowEditingIcon = false;
            this.dgvFactures.Size = new System.Drawing.Size(974, 422);
            this.dgvFactures.TabIndex = 4;
            this.dgvFactures.SelectionChanged += new System.EventHandler(this.dgvFactures_SelectionChanged);
            // 
            // facturesListBindingSource
            // 
            this.facturesListBindingSource.DataMember = "FacturesList";
            this.facturesListBindingSource.DataSource = this.iBFactures;
            // 
            // iBFactures
            // 
            this.iBFactures.DataSetName = "IBFactures";
            this.iBFactures.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblDocsCount
            // 
            this.lblDocsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDocsCount.Location = new System.Drawing.Point(827, 67);
            this.lblDocsCount.Name = "lblDocsCount";
            this.lblDocsCount.Size = new System.Drawing.Size(148, 15);
            this.lblDocsCount.TabIndex = 12;
            this.lblDocsCount.Text = "0";
            this.lblDocsCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDocsCountCaption
            // 
            this.lblDocsCountCaption.AutoSize = true;
            this.lblDocsCountCaption.Location = new System.Drawing.Point(827, 53);
            this.lblDocsCountCaption.Name = "lblDocsCountCaption";
            this.lblDocsCountCaption.Size = new System.Drawing.Size(148, 13);
            this.lblDocsCountCaption.TabIndex = 11;
            this.lblDocsCountCaption.Text = "К-во накладных для печати:";
            // 
            // kcooDataGridViewTextBoxColumn
            // 
            this.kcooDataGridViewTextBoxColumn.DataPropertyName = "kcoo";
            this.kcooDataGridViewTextBoxColumn.HeaderText = "kcoo";
            this.kcooDataGridViewTextBoxColumn.Name = "kcooDataGridViewTextBoxColumn";
            this.kcooDataGridViewTextBoxColumn.Visible = false;
            // 
            // dctoDataGridViewTextBoxColumn
            // 
            this.dctoDataGridViewTextBoxColumn.DataPropertyName = "dcto";
            this.dctoDataGridViewTextBoxColumn.HeaderText = "Тип";
            this.dctoDataGridViewTextBoxColumn.Name = "dctoDataGridViewTextBoxColumn";
            this.dctoDataGridViewTextBoxColumn.Width = 40;
            // 
            // docoDataGridViewTextBoxColumn
            // 
            this.docoDataGridViewTextBoxColumn.DataPropertyName = "doco";
            this.docoDataGridViewTextBoxColumn.HeaderText = "№ заказа";
            this.docoDataGridViewTextBoxColumn.Name = "docoDataGridViewTextBoxColumn";
            this.docoDataGridViewTextBoxColumn.Width = 75;
            // 
            // senderIDDataGridViewTextBoxColumn
            // 
            this.senderIDDataGridViewTextBoxColumn.DataPropertyName = "SenderID";
            this.senderIDDataGridViewTextBoxColumn.HeaderText = "Код отп.";
            this.senderIDDataGridViewTextBoxColumn.Name = "senderIDDataGridViewTextBoxColumn";
            this.senderIDDataGridViewTextBoxColumn.Width = 50;
            // 
            // senderDataGridViewTextBoxColumn
            // 
            this.senderDataGridViewTextBoxColumn.DataPropertyName = "Sender";
            this.senderDataGridViewTextBoxColumn.HeaderText = "Отправитель";
            this.senderDataGridViewTextBoxColumn.Name = "senderDataGridViewTextBoxColumn";
            this.senderDataGridViewTextBoxColumn.Width = 200;
            // 
            // shipToIDDataGridViewTextBoxColumn
            // 
            this.shipToIDDataGridViewTextBoxColumn.DataPropertyName = "ShipTo_ID";
            this.shipToIDDataGridViewTextBoxColumn.HeaderText = "Код пол.";
            this.shipToIDDataGridViewTextBoxColumn.Name = "shipToIDDataGridViewTextBoxColumn";
            this.shipToIDDataGridViewTextBoxColumn.Width = 50;
            // 
            // shipToDataGridViewTextBoxColumn
            // 
            this.shipToDataGridViewTextBoxColumn.DataPropertyName = "ShipTo";
            this.shipToDataGridViewTextBoxColumn.HeaderText = "Получатель";
            this.shipToDataGridViewTextBoxColumn.Name = "shipToDataGridViewTextBoxColumn";
            this.shipToDataGridViewTextBoxColumn.Width = 200;
            // 
            // orderDateDataGridViewTextBoxColumn
            // 
            this.orderDateDataGridViewTextBoxColumn.DataPropertyName = "OrderDate";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.orderDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.orderDateDataGridViewTextBoxColumn.HeaderText = "Дата заказа";
            this.orderDateDataGridViewTextBoxColumn.Name = "orderDateDataGridViewTextBoxColumn";
            this.orderDateDataGridViewTextBoxColumn.Width = 85;
            // 
            // shipDateDataGridViewTextBoxColumn
            // 
            this.shipDateDataGridViewTextBoxColumn.DataPropertyName = "ShipDate";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.shipDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.shipDateDataGridViewTextBoxColumn.HeaderText = "Дата доставки";
            this.shipDateDataGridViewTextBoxColumn.Name = "shipDateDataGridViewTextBoxColumn";
            this.shipDateDataGridViewTextBoxColumn.Width = 85;
            // 
            // summDataGridViewTextBoxColumn
            // 
            this.summDataGridViewTextBoxColumn.DataPropertyName = "Summ";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.summDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.summDataGridViewTextBoxColumn.HeaderText = "Сумма";
            this.summDataGridViewTextBoxColumn.Name = "summDataGridViewTextBoxColumn";
            this.summDataGridViewTextBoxColumn.Width = 90;
            // 
            // Descr
            // 
            this.Descr.DataPropertyName = "Descr";
            this.Descr.HeaderText = "Примечание";
            this.Descr.Name = "Descr";
            this.Descr.Width = 140;
            // 
            // InterbranchFacturesWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 517);
            this.Controls.Add(this.lblDocsCount);
            this.Controls.Add(this.lblDocsCountCaption);
            this.Controls.Add(this.dgvFactures);
            this.Controls.Add(this.toolStripDoc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InterbranchFacturesWindow";
            this.Text = "Печать межскладских накладных";
            this.Controls.SetChildIndex(this.toolStripDoc, 0);
            this.Controls.SetChildIndex(this.dgvFactures, 0);
            this.Controls.SetChildIndex(this.lblDocsCountCaption, 0);
            this.Controls.SetChildIndex(this.lblDocsCount, 0);
            this.toolStripDoc.ResumeLayout(false);
            this.toolStripDoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFactures)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturesListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iBFactures)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripDoc;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.ToolStripButton btnPrintPreview;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel lblPrinter;
        private System.Windows.Forms.ToolStripComboBox cbPrinters;
        private System.Windows.Forms.DataGridView dgvFactures;
        private System.Windows.Forms.BindingSource facturesListBindingSource;
        private WMSOffice.Data.IBFactures iBFactures;
        private System.Windows.Forms.Label lblDocsCount;
        private System.Windows.Forms.Label lblDocsCountCaption;
        private System.Windows.Forms.ToolStripButton btnRegisterPreview;
        private System.Windows.Forms.DataGridViewTextBoxColumn kcooDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dctoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn senderIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn senderDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipToIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipToDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn summDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descr;

    }
}