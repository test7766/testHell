namespace WMSOffice.Dialogs.PickControl
{
    partial class ScanUsedTareForm
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.tbsTare = new WMSOffice.Controls.TextBoxScaner();
            this.lblScanTare = new System.Windows.Forms.Label();
            this.dgvTare = new System.Windows.Forms.DataGridView();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblScannedReturnedTareQtty = new System.Windows.Forms.Label();
            this.lblScannedItems = new System.Windows.Forms.Label();
            this.pickControl = new WMSOffice.Data.PickControl();
            this.usedTareBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tareBarCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblAccessibleItems = new System.Windows.Forms.Label();
            this.tbAccessibleItemsQtty = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTare)).BeginInit();
            this.pnlFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usedTareBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(4613, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(4703, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 428);
            this.pnlButtons.Size = new System.Drawing.Size(794, 43);
            this.pnlButtons.TabIndex = 2;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.tbsTare);
            this.pnlHeader.Controls.Add(this.lblScanTare);
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(794, 50);
            this.pnlHeader.TabIndex = 0;
            // 
            // tbsTare
            // 
            this.tbsTare.AllowType = true;
            this.tbsTare.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbsTare.AutoConvert = true;
            this.tbsTare.DelayThreshold = 50;
            this.tbsTare.Location = new System.Drawing.Point(205, 13);
            this.tbsTare.Name = "tbsTare";
            this.tbsTare.RaiseTextChangeWithoutEnter = false;
            this.tbsTare.ReadOnly = false;
            this.tbsTare.Size = new System.Drawing.Size(586, 25);
            this.tbsTare.TabIndex = 1;
            this.tbsTare.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.tbsTare.UseParentFont = false;
            this.tbsTare.UseScanModeOnly = false;
            // 
            // lblScanTare
            // 
            this.lblScanTare.AutoSize = true;
            this.lblScanTare.Location = new System.Drawing.Point(12, 19);
            this.lblScanTare.Name = "lblScanTare";
            this.lblScanTare.Size = new System.Drawing.Size(181, 13);
            this.lblScanTare.TabIndex = 0;
            this.lblScanTare.Text = "Отсканируйте ш/к б/у гофротары:";
            // 
            // dgvTare
            // 
            this.dgvTare.AllowUserToAddRows = false;
            this.dgvTare.AllowUserToDeleteRows = false;
            this.dgvTare.AllowUserToResizeColumns = false;
            this.dgvTare.AllowUserToResizeRows = false;
            this.dgvTare.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTare.AutoGenerateColumns = false;
            this.dgvTare.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTare.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tareBarCodeDataGridViewTextBoxColumn});
            this.dgvTare.DataSource = this.usedTareBindingSource;
            this.dgvTare.Location = new System.Drawing.Point(0, 56);
            this.dgvTare.MultiSelect = false;
            this.dgvTare.Name = "dgvTare";
            this.dgvTare.ReadOnly = true;
            this.dgvTare.RowHeadersVisible = false;
            this.dgvTare.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTare.Size = new System.Drawing.Size(794, 341);
            this.dgvTare.TabIndex = 1;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.SystemColors.Info;
            this.pnlFooter.Controls.Add(this.tbAccessibleItemsQtty);
            this.pnlFooter.Controls.Add(this.lblAccessibleItems);
            this.pnlFooter.Controls.Add(this.lblScannedReturnedTareQtty);
            this.pnlFooter.Controls.Add(this.lblScannedItems);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 403);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(794, 25);
            this.pnlFooter.TabIndex = 4;
            // 
            // lblScannedReturnedTareQtty
            // 
            this.lblScannedReturnedTareQtty.AutoSize = true;
            this.lblScannedReturnedTareQtty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblScannedReturnedTareQtty.ForeColor = System.Drawing.Color.Blue;
            this.lblScannedReturnedTareQtty.Location = new System.Drawing.Point(220, 4);
            this.lblScannedReturnedTareQtty.Name = "lblScannedReturnedTareQtty";
            this.lblScannedReturnedTareQtty.Size = new System.Drawing.Size(16, 16);
            this.lblScannedReturnedTareQtty.TabIndex = 1;
            this.lblScannedReturnedTareQtty.Text = "0";
            // 
            // lblScannedItems
            // 
            this.lblScannedItems.AutoSize = true;
            this.lblScannedItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblScannedItems.Location = new System.Drawing.Point(12, 6);
            this.lblScannedItems.Name = "lblScannedItems";
            this.lblScannedItems.Size = new System.Drawing.Size(195, 13);
            this.lblScannedItems.TabIndex = 0;
            this.lblScannedItems.Text = "Отсканировано б/у гофротары:";
            // 
            // pickControl
            // 
            this.pickControl.DataSetName = "PickControl";
            this.pickControl.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // usedTareBindingSource
            // 
            this.usedTareBindingSource.DataMember = "UsedTare";
            this.usedTareBindingSource.DataSource = this.pickControl;
            // 
            // tareBarCodeDataGridViewTextBoxColumn
            // 
            this.tareBarCodeDataGridViewTextBoxColumn.DataPropertyName = "TareBarCode";
            this.tareBarCodeDataGridViewTextBoxColumn.HeaderText = "ш/к б/у гофротары";
            this.tareBarCodeDataGridViewTextBoxColumn.Name = "tareBarCodeDataGridViewTextBoxColumn";
            this.tareBarCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.tareBarCodeDataGridViewTextBoxColumn.Width = 150;
            // 
            // lblAccessibleItems
            // 
            this.lblAccessibleItems.AutoSize = true;
            this.lblAccessibleItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAccessibleItems.Location = new System.Drawing.Point(584, 6);
            this.lblAccessibleItems.Name = "lblAccessibleItems";
            this.lblAccessibleItems.Size = new System.Drawing.Size(160, 13);
            this.lblAccessibleItems.TabIndex = 2;
            this.lblAccessibleItems.Text = "Доступно б/у гофротары:";
            // 
            // lblAccessibleItemsQtty
            // 
            this.tbAccessibleItemsQtty.AutoSize = true;
            this.tbAccessibleItemsQtty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbAccessibleItemsQtty.ForeColor = System.Drawing.Color.Blue;
            this.tbAccessibleItemsQtty.Location = new System.Drawing.Point(760, 4);
            this.tbAccessibleItemsQtty.Name = "lblAccessibleItemsQtty";
            this.tbAccessibleItemsQtty.Size = new System.Drawing.Size(16, 16);
            this.tbAccessibleItemsQtty.TabIndex = 3;
            this.tbAccessibleItemsQtty.Text = "0";
            // 
            // ScanUsedTareForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 471);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.dgvTare);
            this.Name = "ScanUsedTareForm";
            this.Text = "Сплитовка б/у гофротары";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReceiptDebtorsReturnedTareForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.dgvTare, 0);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.Controls.SetChildIndex(this.pnlFooter, 0);
            this.pnlButtons.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTare)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usedTareBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private WMSOffice.Controls.TextBoxScaner tbsTare;
        private System.Windows.Forms.Label lblScanTare;
        private System.Windows.Forms.DataGridView dgvTare;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblScannedReturnedTareQtty;
        private System.Windows.Forms.Label lblScannedItems;
        private System.Windows.Forms.BindingSource usedTareBindingSource;
        private WMSOffice.Data.PickControl pickControl;
        private System.Windows.Forms.DataGridViewTextBoxColumn tareBarCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label tbAccessibleItemsQtty;
        private System.Windows.Forms.Label lblAccessibleItems;
    }
}