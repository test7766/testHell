namespace WMSOffice.Dialogs.PickControl
{
    partial class SetPlatzkartCountForm
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
            this.lblLotnName = new System.Windows.Forms.Label();
            this.lblBoxName = new System.Windows.Forms.Label();
            this.lblCountName = new System.Windows.Forms.Label();
            this.lblLotn = new System.Windows.Forms.Label();
            this.lblBox = new System.Windows.Forms.Label();
            this.listUOMs = new System.Windows.Forms.ListBox();
            this.uOMStructureBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pickControl = new WMSOffice.Data.PickControl();
            this.uOMStructureTableAdapter = new WMSOffice.Data.PickControlTableAdapters.UOMStructureTableAdapter();
            this.lblMaxQtyName = new System.Windows.Forms.Label();
            this.lblFactQtyName = new System.Windows.Forms.Label();
            this.lblFactQty = new System.Windows.Forms.Label();
            this.lblMaxQty = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.nudCount = new System.Windows.Forms.NumericUpDown();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uOMStructureBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCount)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(231, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(321, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 338);
            this.pnlButtons.Size = new System.Drawing.Size(379, 43);
            this.pnlButtons.TabIndex = 11;
            // 
            // lblItemName
            // 
            this.lblItemName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblItemName.Location = new System.Drawing.Point(12, 64);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(355, 21);
            this.lblItemName.TabIndex = 1;
            this.lblItemName.Text = "НАИМЕНОВАНИЕ ТОВАРА";
            // 
            // lblLotnName
            // 
            this.lblLotnName.AutoSize = true;
            this.lblLotnName.Location = new System.Drawing.Point(12, 93);
            this.lblLotnName.Name = "lblLotnName";
            this.lblLotnName.Size = new System.Drawing.Size(41, 13);
            this.lblLotnName.TabIndex = 2;
            this.lblLotnName.Text = "Серия:";
            // 
            // lblBoxName
            // 
            this.lblBoxName.AutoSize = true;
            this.lblBoxName.BackColor = System.Drawing.SystemColors.Info;
            this.lblBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBoxName.ForeColor = System.Drawing.Color.Black;
            this.lblBoxName.Location = new System.Drawing.Point(6, 6);
            this.lblBoxName.Name = "lblBoxName";
            this.lblBoxName.Size = new System.Drawing.Size(153, 39);
            this.lblBoxName.TabIndex = 0;
            this.lblBoxName.Text = "Ящик №";
            // 
            // lblCountName
            // 
            this.lblCountName.AutoSize = true;
            this.lblCountName.Location = new System.Drawing.Point(12, 235);
            this.lblCountName.Name = "lblCountName";
            this.lblCountName.Size = new System.Drawing.Size(56, 13);
            this.lblCountName.TabIndex = 8;
            this.lblCountName.Text = "Положил:";
            // 
            // lblLotn
            // 
            this.lblLotn.AutoSize = true;
            this.lblLotn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLotn.ForeColor = System.Drawing.Color.Gray;
            this.lblLotn.Location = new System.Drawing.Point(159, 93);
            this.lblLotn.Name = "lblLotn";
            this.lblLotn.Size = new System.Drawing.Size(49, 13);
            this.lblLotn.TabIndex = 3;
            this.lblLotn.Text = "9021852";
            // 
            // lblBox
            // 
            this.lblBox.AutoSize = true;
            this.lblBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBox.ForeColor = System.Drawing.Color.Red;
            this.lblBox.Location = new System.Drawing.Point(167, 2);
            this.lblBox.Name = "lblBox";
            this.lblBox.Size = new System.Drawing.Size(43, 46);
            this.lblBox.TabIndex = 1;
            this.lblBox.Text = "0";
            this.lblBox.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listUOMs
            // 
            this.listUOMs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listUOMs.DataSource = this.uOMStructureBindingSource;
            this.listUOMs.DisplayMember = "Uom";
            this.listUOMs.FormattingEnabled = true;
            this.listUOMs.Location = new System.Drawing.Point(12, 275);
            this.listUOMs.Name = "listUOMs";
            this.listUOMs.Size = new System.Drawing.Size(355, 56);
            this.listUOMs.TabIndex = 10;
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
            // lblMaxQtyName
            // 
            this.lblMaxQtyName.AutoSize = true;
            this.lblMaxQtyName.Location = new System.Drawing.Point(12, 146);
            this.lblMaxQtyName.Name = "lblMaxQtyName";
            this.lblMaxQtyName.Size = new System.Drawing.Size(76, 13);
            this.lblMaxQtyName.TabIndex = 4;
            this.lblMaxQtyName.Text = "Потребность:";
            // 
            // lblFactQtyName
            // 
            this.lblFactQtyName.AutoSize = true;
            this.lblFactQtyName.Location = new System.Drawing.Point(12, 183);
            this.lblFactQtyName.Name = "lblFactQtyName";
            this.lblFactQtyName.Size = new System.Drawing.Size(122, 13);
            this.lblFactQtyName.TabIndex = 6;
            this.lblFactQtyName.Text = "Ранее введенное к-во:";
            // 
            // lblFactQty
            // 
            this.lblFactQty.AutoSize = true;
            this.lblFactQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFactQty.ForeColor = System.Drawing.Color.Gray;
            this.lblFactQty.Location = new System.Drawing.Point(159, 177);
            this.lblFactQty.Name = "lblFactQty";
            this.lblFactQty.Size = new System.Drawing.Size(24, 25);
            this.lblFactQty.TabIndex = 7;
            this.lblFactQty.Text = "0";
            // 
            // lblMaxQty
            // 
            this.lblMaxQty.AutoSize = true;
            this.lblMaxQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblMaxQty.Location = new System.Drawing.Point(342, 140);
            this.lblMaxQty.Name = "lblMaxQty";
            this.lblMaxQty.Size = new System.Drawing.Size(25, 25);
            this.lblMaxQty.TabIndex = 5;
            this.lblMaxQty.Text = "0";
            this.lblMaxQty.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.Controls.Add(this.lblBoxName);
            this.panel1.Controls.Add(this.lblBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(379, 50);
            this.panel1.TabIndex = 0;
            // 
            // nudCount
            // 
            this.nudCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nudCount.Location = new System.Drawing.Point(159, 226);
            this.nudCount.Name = "nudCount";
            this.nudCount.Size = new System.Drawing.Size(60, 31);
            this.nudCount.TabIndex = 9;
            this.nudCount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nudCount_KeyDown);
            // 
            // SetPlatzkartCountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 381);
            this.Controls.Add(this.nudCount);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblMaxQty);
            this.Controls.Add(this.lblFactQty);
            this.Controls.Add(this.lblFactQtyName);
            this.Controls.Add(this.lblMaxQtyName);
            this.Controls.Add(this.listUOMs);
            this.Controls.Add(this.lblLotn);
            this.Controls.Add(this.lblLotnName);
            this.Controls.Add(this.lblCountName);
            this.Controls.Add(this.lblItemName);
            this.Name = "SetPlatzkartCountForm";
            this.Text = "Количество";
            this.Load += new System.EventHandler(this.SetCountForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SetCountForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.lblItemName, 0);
            this.Controls.SetChildIndex(this.lblCountName, 0);
            this.Controls.SetChildIndex(this.lblLotnName, 0);
            this.Controls.SetChildIndex(this.lblLotn, 0);
            this.Controls.SetChildIndex(this.listUOMs, 0);
            this.Controls.SetChildIndex(this.lblMaxQtyName, 0);
            this.Controls.SetChildIndex(this.lblFactQtyName, 0);
            this.Controls.SetChildIndex(this.lblFactQty, 0);
            this.Controls.SetChildIndex(this.lblMaxQty, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.nudCount, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uOMStructureBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Label lblLotnName;
        private System.Windows.Forms.Label lblBoxName;
        private System.Windows.Forms.Label lblCountName;
        private System.Windows.Forms.Label lblLotn;
        private System.Windows.Forms.Label lblBox;
        private System.Windows.Forms.ListBox listUOMs;
        private System.Windows.Forms.BindingSource uOMStructureBindingSource;
        private WMSOffice.Data.PickControl pickControl;
        private WMSOffice.Data.PickControlTableAdapters.UOMStructureTableAdapter uOMStructureTableAdapter;
        private System.Windows.Forms.Label lblMaxQtyName;
        private System.Windows.Forms.Label lblFactQtyName;
        private System.Windows.Forms.Label lblFactQty;
        private System.Windows.Forms.Label lblMaxQty;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown nudCount;
    }
}