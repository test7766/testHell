namespace WMSOffice.Dialogs.PickControl
{
    partial class SetCountForm
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
            this.lblNote = new System.Windows.Forms.Label();
            this.lblLotn = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.listUOMs = new System.Windows.Forms.ListBox();
            this.uOMStructureBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pickControl = new WMSOffice.Data.PickControl();
            this.uOMStructureTableAdapter = new WMSOffice.Data.PickControlTableAdapters.UOMStructureTableAdapter();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uOMStructureBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(127, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(217, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 179);
            this.pnlButtons.Size = new System.Drawing.Size(305, 43);
            // 
            // lblItemName
            // 
            this.lblItemName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblItemName.Location = new System.Drawing.Point(12, 10);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(281, 17);
            this.lblItemName.TabIndex = 101;
            this.lblItemName.Text = "НАИМЕНОВАНИЕ ТОВАРА";
            // 
            // tbCount
            // 
            this.tbCount.Location = new System.Drawing.Point(107, 90);
            this.tbCount.Name = "tbCount";
            this.tbCount.Size = new System.Drawing.Size(53, 20);
            this.tbCount.TabIndex = 1;
            this.tbCount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCount_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 104;
            this.label1.Text = "Серия:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 105;
            this.label2.Text = "Ранее введено:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 106;
            this.label3.Text = "Количество:";
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNote.Location = new System.Drawing.Point(166, 71);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(126, 39);
            this.lblNote.TabIndex = 107;
            this.lblNote.Text = "* указанное количество \r\nбудет добавлено \r\nк ранее введенному";
            // 
            // lblLotn
            // 
            this.lblLotn.AutoSize = true;
            this.lblLotn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLotn.Location = new System.Drawing.Point(102, 32);
            this.lblLotn.Name = "lblLotn";
            this.lblLotn.Size = new System.Drawing.Size(103, 26);
            this.lblLotn.TabIndex = 108;
            this.lblLotn.Text = "9021852";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCount.Location = new System.Drawing.Point(104, 67);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(14, 13);
            this.lblCount.TabIndex = 109;
            this.lblCount.Text = "0";
            // 
            // listUOMs
            // 
            this.listUOMs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listUOMs.DataSource = this.uOMStructureBindingSource;
            this.listUOMs.DisplayMember = "Uom";
            this.listUOMs.FormattingEnabled = true;
            this.listUOMs.Location = new System.Drawing.Point(12, 116);
            this.listUOMs.Name = "listUOMs";
            this.listUOMs.Size = new System.Drawing.Size(281, 56);
            this.listUOMs.TabIndex = 2;
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
            // SetCountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 222);
            this.Controls.Add(this.listUOMs);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.lblLotn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblItemName);
            this.Controls.Add(this.tbCount);
            this.Name = "SetCountForm";
            this.Text = "Количество";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SetCountForm_FormClosing);
            this.Load += new System.EventHandler(this.SetCountForm_Load);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.tbCount, 0);
            this.Controls.SetChildIndex(this.lblItemName, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblLotn, 0);
            this.Controls.SetChildIndex(this.lblCount, 0);
            this.Controls.SetChildIndex(this.lblNote, 0);
            this.Controls.SetChildIndex(this.listUOMs, 0);
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
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Label lblLotn;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.ListBox listUOMs;
        private System.Windows.Forms.BindingSource uOMStructureBindingSource;
        private WMSOffice.Data.PickControl pickControl;
        private WMSOffice.Data.PickControlTableAdapters.UOMStructureTableAdapter uOMStructureTableAdapter;
    }
}