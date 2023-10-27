namespace WMSOffice.Dialogs.Receive
{
    partial class PalletsEntryAccountingForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbStandartPalletsQty = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbEuroPalletsQty = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPlasticPalletsQty = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbWithoutPallets = new System.Windows.Forms.CheckBox();
            this.gbLoaders = new System.Windows.Forms.GroupBox();
            this.dgvLoaders = new System.Windows.Forms.DataGridView();
            this.optionDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.userNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loadersForPalletsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.receive = new WMSOffice.Data.Receive();
            this.tbsLoaders = new WMSOffice.Controls.TextBoxScaner();
            this.tbWithoutPalletsQty = new System.Windows.Forms.TextBox();
            this.loadersForPalletsTableAdapter = new WMSOffice.Data.ReceiveTableAdapters.LoadersForPalletsTableAdapter();
            this.pnlButtons.SuspendLayout();
            this.gbLoaders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadersForPalletsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receive)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(417, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(507, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 443);
            this.pnlButtons.Size = new System.Drawing.Size(409, 43);
            this.pnlButtons.TabIndex = 10;
            // 
            // tbStandartPalletsQty
            // 
            this.tbStandartPalletsQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbStandartPalletsQty.Location = new System.Drawing.Point(175, 54);
            this.tbStandartPalletsQty.Name = "tbStandartPalletsQty";
            this.tbStandartPalletsQty.Size = new System.Drawing.Size(100, 22);
            this.tbStandartPalletsQty.TabIndex = 2;
            this.tbStandartPalletsQty.Text = "0";
            this.tbStandartPalletsQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbStandartPalletsQty.TextChanged += new System.EventHandler(this.Number_TextChanged);
            this.tbStandartPalletsQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllowOnlyNumber_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "стандартных паллет";
            // 
            // tbEuroPalletsQty
            // 
            this.tbEuroPalletsQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbEuroPalletsQty.Location = new System.Drawing.Point(175, 91);
            this.tbEuroPalletsQty.Name = "tbEuroPalletsQty";
            this.tbEuroPalletsQty.Size = new System.Drawing.Size(100, 22);
            this.tbEuroPalletsQty.TabIndex = 4;
            this.tbEuroPalletsQty.Text = "0";
            this.tbEuroPalletsQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbEuroPalletsQty.TextChanged += new System.EventHandler(this.Number_TextChanged);
            this.tbEuroPalletsQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllowOnlyNumber_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "евро-паллет";
            // 
            // tbPlasticPalletsQty
            // 
            this.tbPlasticPalletsQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbPlasticPalletsQty.Location = new System.Drawing.Point(175, 131);
            this.tbPlasticPalletsQty.Name = "tbPlasticPalletsQty";
            this.tbPlasticPalletsQty.Size = new System.Drawing.Size(100, 22);
            this.tbPlasticPalletsQty.TabIndex = 6;
            this.tbPlasticPalletsQty.Text = "0";
            this.tbPlasticPalletsQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbPlasticPalletsQty.TextChanged += new System.EventHandler(this.Number_TextChanged);
            this.tbPlasticPalletsQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllowOnlyNumber_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(13, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "пластиковых паллет";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(0, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(313, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Введите количество паллет в приходе:";
            // 
            // cbWithoutPallets
            // 
            this.cbWithoutPallets.AutoSize = true;
            this.cbWithoutPallets.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbWithoutPallets.ForeColor = System.Drawing.Color.Blue;
            this.cbWithoutPallets.Location = new System.Drawing.Point(12, 183);
            this.cbWithoutPallets.Name = "cbWithoutPallets";
            this.cbWithoutPallets.Size = new System.Drawing.Size(102, 20);
            this.cbWithoutPallets.TabIndex = 7;
            this.cbWithoutPallets.Text = "Без паллет";
            this.cbWithoutPallets.UseVisualStyleBackColor = true;
            this.cbWithoutPallets.CheckedChanged += new System.EventHandler(this.cbWithoutPallets_CheckedChanged);
            // 
            // gbLoaders
            // 
            this.gbLoaders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbLoaders.Controls.Add(this.dgvLoaders);
            this.gbLoaders.Controls.Add(this.tbsLoaders);
            this.gbLoaders.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbLoaders.Location = new System.Drawing.Point(4, 229);
            this.gbLoaders.Name = "gbLoaders";
            this.gbLoaders.Size = new System.Drawing.Size(401, 212);
            this.gbLoaders.TabIndex = 9;
            this.gbLoaders.TabStop = false;
            this.gbLoaders.Text = "Грузчики";
            // 
            // dgvLoaders
            // 
            this.dgvLoaders.AllowUserToAddRows = false;
            this.dgvLoaders.AllowUserToDeleteRows = false;
            this.dgvLoaders.AllowUserToResizeRows = false;
            this.dgvLoaders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLoaders.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLoaders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLoaders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoaders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.optionDataGridViewCheckBoxColumn,
            this.userNameDataGridViewTextBoxColumn,
            this.TotalQty});
            this.dgvLoaders.DataSource = this.loadersForPalletsBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLoaders.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLoaders.Location = new System.Drawing.Point(12, 59);
            this.dgvLoaders.MultiSelect = false;
            this.dgvLoaders.Name = "dgvLoaders";
            this.dgvLoaders.RowHeadersVisible = false;
            this.dgvLoaders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLoaders.Size = new System.Drawing.Size(384, 147);
            this.dgvLoaders.TabIndex = 1;
            this.dgvLoaders.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvLoaders_CellFormatting);
            this.dgvLoaders.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvLoaders_EditingControlShowing);
            this.dgvLoaders.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvLoaders_CurrentCellDirtyStateChanged);
            this.dgvLoaders.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvLoaders_DataError);
            this.dgvLoaders.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLoaders_CellEnter);
            // 
            // optionDataGridViewCheckBoxColumn
            // 
            this.optionDataGridViewCheckBoxColumn.DataPropertyName = "Option";
            this.optionDataGridViewCheckBoxColumn.HeaderText = "Отм.";
            this.optionDataGridViewCheckBoxColumn.Name = "optionDataGridViewCheckBoxColumn";
            this.optionDataGridViewCheckBoxColumn.Width = 35;
            // 
            // userNameDataGridViewTextBoxColumn
            // 
            this.userNameDataGridViewTextBoxColumn.DataPropertyName = "UserName";
            this.userNameDataGridViewTextBoxColumn.FillWeight = 73F;
            this.userNameDataGridViewTextBoxColumn.HeaderText = "Ф.И.О.";
            this.userNameDataGridViewTextBoxColumn.Name = "userNameDataGridViewTextBoxColumn";
            this.userNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.userNameDataGridViewTextBoxColumn.Width = 255;
            // 
            // TotalQty
            // 
            this.TotalQty.DataPropertyName = "TotalQty";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "N0";
            this.TotalQty.DefaultCellStyle = dataGridViewCellStyle2;
            this.TotalQty.HeaderText = "Σ к-во";
            this.TotalQty.Name = "TotalQty";
            this.TotalQty.Width = 65;
            // 
            // loadersForPalletsBindingSource
            // 
            this.loadersForPalletsBindingSource.DataMember = "LoadersForPallets";
            this.loadersForPalletsBindingSource.DataSource = this.receive;
            // 
            // receive
            // 
            this.receive.DataSetName = "Receive";
            this.receive.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbsLoaders
            // 
            this.tbsLoaders.AllowType = true;
            this.tbsLoaders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbsLoaders.AutoConvert = true;
            this.tbsLoaders.DelayThreshold = 50;
            this.tbsLoaders.Location = new System.Drawing.Point(8, 22);
            this.tbsLoaders.Margin = new System.Windows.Forms.Padding(4);
            this.tbsLoaders.Name = "tbsLoaders";
            this.tbsLoaders.RaiseTextChangeWithoutEnter = false;
            this.tbsLoaders.ReadOnly = false;
            this.tbsLoaders.Size = new System.Drawing.Size(388, 30);
            this.tbsLoaders.TabIndex = 0;
            this.tbsLoaders.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.tbsLoaders.UseParentFont = true;
            this.tbsLoaders.UseScanModeOnly = false;
            // 
            // tbWithoutPalletsQty
            // 
            this.tbWithoutPalletsQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbWithoutPalletsQty.Location = new System.Drawing.Point(175, 182);
            this.tbWithoutPalletsQty.Name = "tbWithoutPalletsQty";
            this.tbWithoutPalletsQty.Size = new System.Drawing.Size(100, 22);
            this.tbWithoutPalletsQty.TabIndex = 8;
            this.tbWithoutPalletsQty.Text = "0";
            this.tbWithoutPalletsQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbWithoutPalletsQty.Visible = false;
            this.tbWithoutPalletsQty.TextChanged += new System.EventHandler(this.Number_TextChanged);
            this.tbWithoutPalletsQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllowOnlyNumber_KeyPress);
            // 
            // loadersForPalletsTableAdapter
            // 
            this.loadersForPalletsTableAdapter.ClearBeforeFill = true;
            // 
            // PalletsEntryAccountingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 486);
            this.Controls.Add(this.tbWithoutPalletsQty);
            this.Controls.Add(this.gbLoaders);
            this.Controls.Add(this.cbWithoutPallets);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbPlasticPalletsQty);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbEuroPalletsQty);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbStandartPalletsQty);
            this.Controls.Add(this.label1);
            this.Name = "PalletsEntryAccountingForm";
            this.Text = "Учет паллет по приходу";
            this.Load += new System.EventHandler(this.PalletsEntryAccountingForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PalletsEntryAccountingForm_FormClosing);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.tbStandartPalletsQty, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.tbEuroPalletsQty, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.tbPlasticPalletsQty, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.cbWithoutPallets, 0);
            this.Controls.SetChildIndex(this.gbLoaders, 0);
            this.Controls.SetChildIndex(this.tbWithoutPalletsQty, 0);
            this.pnlButtons.ResumeLayout(false);
            this.gbLoaders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadersForPalletsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receive)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbStandartPalletsQty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbEuroPalletsQty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPlasticPalletsQty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbWithoutPallets;
        private System.Windows.Forms.GroupBox gbLoaders;
        private System.Windows.Forms.DataGridView dgvLoaders;
        private WMSOffice.Controls.TextBoxScaner tbsLoaders;
        private System.Windows.Forms.TextBox tbWithoutPalletsQty;
        private System.Windows.Forms.BindingSource loadersForPalletsBindingSource;
        private WMSOffice.Data.Receive receive;
        private WMSOffice.Data.ReceiveTableAdapters.LoadersForPalletsTableAdapter loadersForPalletsTableAdapter;
        private System.Windows.Forms.DataGridViewCheckBoxColumn optionDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalQty;
    }
}