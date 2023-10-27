namespace WMSOffice.Dialogs.Delivery
{
    partial class NeededPSNForm
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
            this.gvLines = new System.Windows.Forms.DataGridView();
            this.orderNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pickSlipNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.otdelNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SectorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Places = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlacesFact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debitorIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debitorNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debitorAddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.needPSNbyPeronBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.delivery = new WMSOffice.Data.Delivery();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.needPSNbyPeronTableAdapter = new WMSOffice.Data.DeliveryTableAdapters.NeedPSNbyPeronTableAdapter();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.btnWriteOffShortage = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.pnlContent = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.gvLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.needPSNbyPeronBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.delivery)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvLines
            // 
            this.gvLines.AllowUserToAddRows = false;
            this.gvLines.AllowUserToDeleteRows = false;
            this.gvLines.AllowUserToResizeRows = false;
            this.gvLines.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvLines.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvLines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderNumberDataGridViewTextBoxColumn,
            this.orderTypeDataGridViewTextBoxColumn,
            this.pickSlipNumberDataGridViewTextBoxColumn,
            this.statusIDDataGridViewTextBoxColumn,
            this.otdelNameDataGridViewTextBoxColumn,
            this.SectorName,
            this.Places,
            this.PlacesFact,
            this.debitorIDDataGridViewTextBoxColumn,
            this.debitorNameDataGridViewTextBoxColumn,
            this.debitorAddressDataGridViewTextBoxColumn});
            this.gvLines.DataSource = this.needPSNbyPeronBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvLines.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvLines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvLines.Location = new System.Drawing.Point(0, 0);
            this.gvLines.MultiSelect = false;
            this.gvLines.Name = "gvLines";
            this.gvLines.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvLines.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gvLines.RowHeadersVisible = false;
            this.gvLines.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gvLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gvLines.Size = new System.Drawing.Size(981, 267);
            this.gvLines.TabIndex = 101;
            this.gvLines.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gvLines_DataBindingComplete);
            // 
            // orderNumberDataGridViewTextBoxColumn
            // 
            this.orderNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.orderNumberDataGridViewTextBoxColumn.DataPropertyName = "Order_Number";
            this.orderNumberDataGridViewTextBoxColumn.HeaderText = "№_заказа";
            this.orderNumberDataGridViewTextBoxColumn.Name = "orderNumberDataGridViewTextBoxColumn";
            this.orderNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // orderTypeDataGridViewTextBoxColumn
            // 
            this.orderTypeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.orderTypeDataGridViewTextBoxColumn.DataPropertyName = "OrderType";
            this.orderTypeDataGridViewTextBoxColumn.HeaderText = "Тип";
            this.orderTypeDataGridViewTextBoxColumn.Name = "orderTypeDataGridViewTextBoxColumn";
            this.orderTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.orderTypeDataGridViewTextBoxColumn.Width = 58;
            // 
            // pickSlipNumberDataGridViewTextBoxColumn
            // 
            this.pickSlipNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.pickSlipNumberDataGridViewTextBoxColumn.DataPropertyName = "PickSlipNumber";
            this.pickSlipNumberDataGridViewTextBoxColumn.HeaderText = "№_сборочного";
            this.pickSlipNumberDataGridViewTextBoxColumn.Name = "pickSlipNumberDataGridViewTextBoxColumn";
            this.pickSlipNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.pickSlipNumberDataGridViewTextBoxColumn.Width = 131;
            // 
            // statusIDDataGridViewTextBoxColumn
            // 
            this.statusIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.statusIDDataGridViewTextBoxColumn.DataPropertyName = "Status_ID";
            this.statusIDDataGridViewTextBoxColumn.HeaderText = "Статус";
            this.statusIDDataGridViewTextBoxColumn.Name = "statusIDDataGridViewTextBoxColumn";
            this.statusIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusIDDataGridViewTextBoxColumn.Width = 78;
            // 
            // otdelNameDataGridViewTextBoxColumn
            // 
            this.otdelNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.otdelNameDataGridViewTextBoxColumn.DataPropertyName = "OtdelName";
            this.otdelNameDataGridViewTextBoxColumn.HeaderText = "Отдел";
            this.otdelNameDataGridViewTextBoxColumn.Name = "otdelNameDataGridViewTextBoxColumn";
            this.otdelNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.otdelNameDataGridViewTextBoxColumn.Width = 75;
            // 
            // SectorName
            // 
            this.SectorName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SectorName.DataPropertyName = "SectorName";
            this.SectorName.HeaderText = "Сектор";
            this.SectorName.Name = "SectorName";
            this.SectorName.ReadOnly = true;
            this.SectorName.Width = 80;
            // 
            // Places
            // 
            this.Places.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Places.DataPropertyName = "Places";
            this.Places.HeaderText = "Мест";
            this.Places.Name = "Places";
            this.Places.ReadOnly = true;
            this.Places.Width = 66;
            // 
            // PlacesFact
            // 
            this.PlacesFact.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PlacesFact.DataPropertyName = "PlacesFact";
            this.PlacesFact.HeaderText = "Фактически";
            this.PlacesFact.Name = "PlacesFact";
            this.PlacesFact.ReadOnly = true;
            this.PlacesFact.Width = 114;
            // 
            // debitorIDDataGridViewTextBoxColumn
            // 
            this.debitorIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.debitorIDDataGridViewTextBoxColumn.DataPropertyName = "Debitor_ID";
            this.debitorIDDataGridViewTextBoxColumn.HeaderText = "Код";
            this.debitorIDDataGridViewTextBoxColumn.Name = "debitorIDDataGridViewTextBoxColumn";
            this.debitorIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.debitorIDDataGridViewTextBoxColumn.Width = 58;
            // 
            // debitorNameDataGridViewTextBoxColumn
            // 
            this.debitorNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.debitorNameDataGridViewTextBoxColumn.DataPropertyName = "Debitor_Name";
            this.debitorNameDataGridViewTextBoxColumn.HeaderText = "Клиент";
            this.debitorNameDataGridViewTextBoxColumn.Name = "debitorNameDataGridViewTextBoxColumn";
            this.debitorNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.debitorNameDataGridViewTextBoxColumn.Width = 81;
            // 
            // debitorAddressDataGridViewTextBoxColumn
            // 
            this.debitorAddressDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.debitorAddressDataGridViewTextBoxColumn.DataPropertyName = "Debitor_Address";
            this.debitorAddressDataGridViewTextBoxColumn.HeaderText = "Адрес";
            this.debitorAddressDataGridViewTextBoxColumn.Name = "debitorAddressDataGridViewTextBoxColumn";
            this.debitorAddressDataGridViewTextBoxColumn.ReadOnly = true;
            this.debitorAddressDataGridViewTextBoxColumn.Width = 73;
            // 
            // needPSNbyPeronBindingSource
            // 
            this.needPSNbyPeronBindingSource.DataMember = "NeedPSNbyPeron";
            this.needPSNbyPeronBindingSource.DataSource = this.delivery;
            // 
            // delivery
            // 
            this.delivery.DataSetName = "Delivery";
            this.delivery.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnClose);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 306);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(981, 39);
            this.pnlFooter.TabIndex = 102;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(894, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // needPSNbyPeronTableAdapter
            // 
            this.needPSNbyPeronTableAdapter.ClearBeforeFill = true;
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.toolStripSeparator1,
            this.btnWriteOffShortage});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(981, 39);
            this.tsMain.TabIndex = 104;
            this.tsMain.Text = "toolStrip1";
            // 
            // btnWriteOffShortage
            // 
            this.btnWriteOffShortage.Image = global::WMSOffice.Properties.Resources.undo_action;
            this.btnWriteOffShortage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnWriteOffShortage.Name = "btnWriteOffShortage";
            this.btnWriteOffShortage.Size = new System.Drawing.Size(147, 36);
            this.btnWriteOffShortage.Text = "Списать недостачу";
            this.btnWriteOffShortage.Click += new System.EventHandler(this.btnWriteOffShortage_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(97, 36);
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.gvLines);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 39);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(981, 267);
            this.pnlContent.TabIndex = 105;
            // 
            // NeededPSNForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(981, 345);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.pnlFooter);
            this.MinimizeBox = false;
            this.Name = "NeededPSNForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NeededPSNForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.NeededPSNForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.needPSNbyPeronBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.delivery)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvLines;
        private System.Windows.Forms.BindingSource needPSNbyPeronBindingSource;
        private WMSOffice.Data.Delivery delivery;
        private WMSOffice.Data.DeliveryTableAdapters.NeedPSNbyPeronTableAdapter needPSNbyPeronTableAdapter;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pickSlipNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn otdelNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SectorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Places;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlacesFact;
        private System.Windows.Forms.DataGridViewTextBoxColumn debitorIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn debitorNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn debitorAddressDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnWriteOffShortage;
        private System.Windows.Forms.Panel pnlContent;
    }
}