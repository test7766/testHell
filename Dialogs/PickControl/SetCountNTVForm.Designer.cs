namespace WMSOffice.Dialogs.PickControl
{
    partial class SetCountNTVForm
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
            this.lblItemName = new System.Windows.Forms.Label();
            this.tbCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblLotn = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.listUOMs = new System.Windows.Forms.ListBox();
            this.uOMStructureBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pickControl = new WMSOffice.Data.PickControl();
            this.uOMStructureTableAdapter = new WMSOffice.Data.PickControlTableAdapters.UOMStructureTableAdapter();
            this.label4 = new System.Windows.Forms.Label();
            this.tbTotalCount = new System.Windows.Forms.TextBox();
            this.cbNTVExists = new System.Windows.Forms.CheckBox();
            this.tbNTVCount = new System.Windows.Forms.TextBox();
            this.lblMaxQtyName = new System.Windows.Forms.Label();
            this.lblMaxQty = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uOMStructureBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(-97, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(-7, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 208);
            this.pnlButtons.Size = new System.Drawing.Size(305, 43);
            this.pnlButtons.TabIndex = 12;
            // 
            // lblItemName
            // 
            this.lblItemName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblItemName.Location = new System.Drawing.Point(12, 10);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(281, 17);
            this.lblItemName.TabIndex = 0;
            this.lblItemName.Text = "НАИМЕНОВАНИЕ ТОВАРА";
            // 
            // tbCount
            // 
            this.tbCount.Location = new System.Drawing.Point(107, 89);
            this.tbCount.Name = "tbCount";
            this.tbCount.Size = new System.Drawing.Size(53, 20);
            this.tbCount.TabIndex = 6;
            this.tbCount.TextChanged += new System.EventHandler(this.tbCountValue_TextChanged);
            this.tbCount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCount_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Серия:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ранее введено:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Количество:";
            // 
            // lblLotn
            // 
            this.lblLotn.AutoSize = true;
            this.lblLotn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLotn.Location = new System.Drawing.Point(102, 32);
            this.lblLotn.Name = "lblLotn";
            this.lblLotn.Size = new System.Drawing.Size(103, 26);
            this.lblLotn.TabIndex = 2;
            this.lblLotn.Text = "9021852";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCount.Location = new System.Drawing.Point(104, 67);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(14, 13);
            this.lblCount.TabIndex = 4;
            this.lblCount.Text = "0";
            // 
            // listUOMs
            // 
            this.listUOMs.DataSource = this.uOMStructureBindingSource;
            this.listUOMs.DisplayMember = "Uom";
            this.listUOMs.FormattingEnabled = true;
            this.listUOMs.Location = new System.Drawing.Point(12, 147);
            this.listUOMs.Name = "listUOMs";
            this.listUOMs.Size = new System.Drawing.Size(281, 56);
            this.listUOMs.TabIndex = 11;
            this.listUOMs.ValueMember = "Qt";
            this.listUOMs.SelectedIndexChanged += new System.EventHandler(this.listUOMs_SelectedIndexChanged);
            this.listUOMs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listUOMs_KeyDown);
            // 
            // uOMStructureBindingSource
            // 
            this.uOMStructureBindingSource.DataMember = "UOMStructure";
            this.uOMStructureBindingSource.DataSource = this.pickControl;
            // 
            // pickControl
            // 
            this.pickControl.DataSetName = "PickControl";
            this.pickControl.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // uOMStructureTableAdapter
            // 
            this.uOMStructureTableAdapter.ClearBeforeFill = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "ИТОГО:";
            // 
            // tbTotalCount
            // 
            this.tbTotalCount.Enabled = false;
            this.tbTotalCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbTotalCount.Location = new System.Drawing.Point(107, 116);
            this.tbTotalCount.Name = "tbTotalCount";
            this.tbTotalCount.Size = new System.Drawing.Size(53, 20);
            this.tbTotalCount.TabIndex = 10;
            // 
            // cbNTVExists
            // 
            this.cbNTVExists.AutoSize = true;
            this.cbNTVExists.Location = new System.Drawing.Point(186, 91);
            this.cbNTVExists.Name = "cbNTVExists";
            this.cbNTVExists.Size = new System.Drawing.Size(48, 17);
            this.cbNTVExists.TabIndex = 7;
            this.cbNTVExists.Text = "НТВ";
            this.cbNTVExists.UseVisualStyleBackColor = true;
            this.cbNTVExists.CheckedChanged += new System.EventHandler(this.cbNTVExists_CheckedChanged);
            // 
            // tbNTVCount
            // 
            this.tbNTVCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbNTVCount.Location = new System.Drawing.Point(240, 89);
            this.tbNTVCount.Name = "tbNTVCount";
            this.tbNTVCount.Size = new System.Drawing.Size(53, 20);
            this.tbNTVCount.TabIndex = 8;
            this.tbNTVCount.TextChanged += new System.EventHandler(this.tbCountValue_TextChanged);
            // 
            // lblMaxQtyName
            // 
            this.lblMaxQtyName.AutoSize = true;
            this.lblMaxQtyName.Location = new System.Drawing.Point(183, 67);
            this.lblMaxQtyName.Name = "lblMaxQtyName";
            this.lblMaxQtyName.Size = new System.Drawing.Size(76, 13);
            this.lblMaxQtyName.TabIndex = 13;
            this.lblMaxQtyName.Text = "Потребность:";
            // 
            // lblMaxQty
            // 
            this.lblMaxQty.AutoSize = true;
            this.lblMaxQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblMaxQty.Location = new System.Drawing.Point(279, 67);
            this.lblMaxQty.Name = "lblMaxQty";
            this.lblMaxQty.Size = new System.Drawing.Size(14, 13);
            this.lblMaxQty.TabIndex = 14;
            this.lblMaxQty.Text = "0";
            // 
            // SetCountNTVForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 251);
            this.Controls.Add(this.lblMaxQty);
            this.Controls.Add(this.lblMaxQtyName);
            this.Controls.Add(this.tbNTVCount);
            this.Controls.Add(this.cbNTVExists);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbTotalCount);
            this.Controls.Add(this.listUOMs);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.lblLotn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblItemName);
            this.Controls.Add(this.tbCount);
            this.Name = "SetCountNTVForm";
            this.Text = "Количество";
            this.Load += new System.EventHandler(this.SetCountForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SetCountForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.tbCount, 0);
            this.Controls.SetChildIndex(this.lblItemName, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblLotn, 0);
            this.Controls.SetChildIndex(this.lblCount, 0);
            this.Controls.SetChildIndex(this.listUOMs, 0);
            this.Controls.SetChildIndex(this.tbTotalCount, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.cbNTVExists, 0);
            this.Controls.SetChildIndex(this.tbNTVCount, 0);
            this.Controls.SetChildIndex(this.lblMaxQtyName, 0);
            this.Controls.SetChildIndex(this.lblMaxQty, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uOMStructureBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.TextBox tbCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblLotn;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.ListBox listUOMs;
        private System.Windows.Forms.BindingSource uOMStructureBindingSource;
        private WMSOffice.Data.PickControl pickControl;
        private WMSOffice.Data.PickControlTableAdapters.UOMStructureTableAdapter uOMStructureTableAdapter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbTotalCount;
        private System.Windows.Forms.CheckBox cbNTVExists;
        private System.Windows.Forms.TextBox tbNTVCount;
        private System.Windows.Forms.Label lblMaxQtyName;
        private System.Windows.Forms.Label lblMaxQty;
    }
}