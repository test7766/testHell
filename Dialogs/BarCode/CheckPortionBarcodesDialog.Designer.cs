namespace WMSOffice.Dialogs.BarCode
{
    partial class CheckPortionBarcodesDialog
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
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.portionBarCodesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bC = new WMSOffice.Data.BC();
            this.portionBarCodesTableAdapter = new WMSOffice.Data.BCTableAdapters.PortionBarCodesTableAdapter();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barcodeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkedCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbsScanBarCode = new WMSOffice.Controls.TextBoxScaner();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotalBarCodes = new System.Windows.Forms.Label();
            this.lblCheckedBarCodes = new System.Windows.Forms.Label();
            this.lblDublicateBarCodes = new System.Windows.Forms.Label();
            this.pnlFooter.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.portionBarCodesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bC)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 287);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(344, 35);
            this.pnlFooter.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(257, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Закрыть";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblDublicateBarCodes);
            this.pnlHeader.Controls.Add(this.lblCheckedBarCodes);
            this.pnlHeader.Controls.Add(this.lblTotalBarCodes);
            this.pnlHeader.Controls.Add(this.label4);
            this.pnlHeader.Controls.Add(this.label3);
            this.pnlHeader.Controls.Add(this.label2);
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Controls.Add(this.tbsScanBarCode);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(344, 100);
            this.pnlHeader.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Отсканируйте этикетку:";
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.AllowUserToResizeRows = false;
            this.dgvDetails.AutoGenerateColumns = false;
            this.dgvDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.barcodeIDDataGridViewTextBoxColumn,
            this.checkedCountDataGridViewTextBoxColumn});
            this.dgvDetails.DataSource = this.portionBarCodesBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetails.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails.Location = new System.Drawing.Point(0, 100);
            this.dgvDetails.MultiSelect = false;
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetails.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDetails.RowHeadersVisible = false;
            this.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetails.Size = new System.Drawing.Size(344, 187);
            this.dgvDetails.TabIndex = 1;
            this.dgvDetails.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDetails_CellFormatting);
            // 
            // portionBarCodesBindingSource
            // 
            this.portionBarCodesBindingSource.DataMember = "PortionBarCodes";
            this.portionBarCodesBindingSource.DataSource = this.bC;
            // 
            // bC
            // 
            this.bC.DataSetName = "BC";
            this.bC.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // portionBarCodesTableAdapter
            // 
            this.portionBarCodesTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "BarcodeID";
            this.dataGridViewTextBoxColumn1.HeaderText = "Ш/К этикетки";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 94;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "CheckedCount";
            this.dataGridViewTextBoxColumn2.HeaderText = "Проверено, шт.";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 101;
            // 
            // barcodeIDDataGridViewTextBoxColumn
            // 
            this.barcodeIDDataGridViewTextBoxColumn.DataPropertyName = "BarcodeID";
            this.barcodeIDDataGridViewTextBoxColumn.HeaderText = "Ш/К этикетки";
            this.barcodeIDDataGridViewTextBoxColumn.Name = "barcodeIDDataGridViewTextBoxColumn";
            this.barcodeIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.barcodeIDDataGridViewTextBoxColumn.Width = 94;
            // 
            // checkedCountDataGridViewTextBoxColumn
            // 
            this.checkedCountDataGridViewTextBoxColumn.DataPropertyName = "CheckedCount";
            this.checkedCountDataGridViewTextBoxColumn.HeaderText = "Проверено, шт.";
            this.checkedCountDataGridViewTextBoxColumn.Name = "checkedCountDataGridViewTextBoxColumn";
            this.checkedCountDataGridViewTextBoxColumn.ReadOnly = true;
            this.checkedCountDataGridViewTextBoxColumn.Width = 101;
            // 
            // tbsScanBarCode
            // 
            this.tbsScanBarCode.AllowType = true;
            this.tbsScanBarCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbsScanBarCode.AutoConvert = true;
            this.tbsScanBarCode.DelayThreshold = 50;
            this.tbsScanBarCode.Location = new System.Drawing.Point(138, 3);
            this.tbsScanBarCode.Name = "tbsScanBarCode";
            this.tbsScanBarCode.RaiseTextChangeWithoutEnter = false;
            this.tbsScanBarCode.ReadOnly = false;
            this.tbsScanBarCode.Size = new System.Drawing.Size(194, 25);
            this.tbsScanBarCode.TabIndex = 1;
            this.tbsScanBarCode.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.tbsScanBarCode.UseParentFont = false;
            this.tbsScanBarCode.UseScanModeOnly = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Всего этикеток в порции:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Отсканировано этикеток:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "из них дублей:";
            // 
            // lblTotalBarCodes
            // 
            this.lblTotalBarCodes.AutoSize = true;
            this.lblTotalBarCodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTotalBarCodes.Location = new System.Drawing.Point(146, 35);
            this.lblTotalBarCodes.Name = "lblTotalBarCodes";
            this.lblTotalBarCodes.Size = new System.Drawing.Size(14, 13);
            this.lblTotalBarCodes.TabIndex = 3;
            this.lblTotalBarCodes.Text = "0";
            // 
            // lblCheckedBarCodes
            // 
            this.lblCheckedBarCodes.AutoSize = true;
            this.lblCheckedBarCodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCheckedBarCodes.Location = new System.Drawing.Point(146, 56);
            this.lblCheckedBarCodes.Name = "lblCheckedBarCodes";
            this.lblCheckedBarCodes.Size = new System.Drawing.Size(14, 13);
            this.lblCheckedBarCodes.TabIndex = 5;
            this.lblCheckedBarCodes.Text = "0";
            // 
            // lblDublicateBarCodes
            // 
            this.lblDublicateBarCodes.AutoSize = true;
            this.lblDublicateBarCodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDublicateBarCodes.Location = new System.Drawing.Point(146, 77);
            this.lblDublicateBarCodes.Name = "lblDublicateBarCodes";
            this.lblDublicateBarCodes.Size = new System.Drawing.Size(14, 13);
            this.lblDublicateBarCodes.TabIndex = 7;
            this.lblDublicateBarCodes.Text = "0";
            // 
            // CheckPortionBarcodesDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(344, 322);
            this.Controls.Add(this.dgvDetails);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlFooter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CheckPortionBarcodesDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Проверка ш/к в порции";
            this.Load += new System.EventHandler(this.CheckPortionBarcodesDialog_Load);
            this.pnlFooter.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.portionBarCodesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.Label label1;
        private WMSOffice.Controls.TextBoxScaner tbsScanBarCode;
        private System.Windows.Forms.BindingSource portionBarCodesBindingSource;
        private WMSOffice.Data.BC bC;
        private WMSOffice.Data.BCTableAdapters.PortionBarCodesTableAdapter portionBarCodesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcodeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkedCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDublicateBarCodes;
        private System.Windows.Forms.Label lblCheckedBarCodes;
        private System.Windows.Forms.Label lblTotalBarCodes;
    }
}