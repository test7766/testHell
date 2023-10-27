namespace WMSOffice.Dialogs.InterBranch
{
    partial class SetCountWithNtvForm
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
            this.tbxCount = new System.Windows.Forms.TextBox();
            this.lblLotnHeader = new System.Windows.Forms.Label();
            this.lblCountHeader = new System.Windows.Forms.Label();
            this.lblNote = new System.Windows.Forms.Label();
            this.lblLotn = new System.Windows.Forms.Label();
            this.lblExistedCount = new System.Windows.Forms.Label();
            this.lbxUoms = new System.Windows.Forms.ListBox();
            this.bsUomStructure = new System.Windows.Forms.BindingSource(this.components);
            this.pickControl = new WMSOffice.Data.PickControl();
            this.taUomStructure = new WMSOffice.Data.PickControlTableAdapters.UOMStructureTableAdapter();
            this.lblCountNtvHeader = new System.Windows.Forms.Label();
            this.tbxCountNtv = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxCountBoy = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbxCountDefect = new System.Windows.Forms.TextBox();
            this.lblCountDefectHeader = new System.Windows.Forms.Label();
            this.grbEntered = new System.Windows.Forms.GroupBox();
            this.lblExistedCountNtvHeader = new System.Windows.Forms.Label();
            this.lblExistedCountNtv = new System.Windows.Forms.Label();
            this.lblExistedCountBoyHeader = new System.Windows.Forms.Label();
            this.lblExistedCountBoy = new System.Windows.Forms.Label();
            this.lblExistedCountDefectHeader = new System.Windows.Forms.Label();
            this.lblExistedCountDefect = new System.Windows.Forms.Label();
            this.lblExistedCountHeader = new System.Windows.Forms.Label();
            this.cbND_ZU = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.bsUomStructure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).BeginInit();
            this.grbEntered.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblItemName
            // 
            this.lblItemName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblItemName.Location = new System.Drawing.Point(12, 10);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(284, 17);
            this.lblItemName.TabIndex = 101;
            this.lblItemName.Text = "НАИМЕНОВАНИЕ ТОВАРА";
            // 
            // tbxCount
            // 
            this.tbxCount.Location = new System.Drawing.Point(107, 152);
            this.tbxCount.Name = "tbxCount";
            this.tbxCount.Size = new System.Drawing.Size(53, 20);
            this.tbxCount.TabIndex = 10;
            this.tbxCount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.element_KeyDown);
            // 
            // lblLotnHeader
            // 
            this.lblLotnHeader.AutoSize = true;
            this.lblLotnHeader.Location = new System.Drawing.Point(12, 41);
            this.lblLotnHeader.Name = "lblLotnHeader";
            this.lblLotnHeader.Size = new System.Drawing.Size(41, 13);
            this.lblLotnHeader.TabIndex = 104;
            this.lblLotnHeader.Text = "Серия:";
            // 
            // lblCountHeader
            // 
            this.lblCountHeader.AutoSize = true;
            this.lblCountHeader.Location = new System.Drawing.Point(12, 155);
            this.lblCountHeader.Name = "lblCountHeader";
            this.lblCountHeader.Size = new System.Drawing.Size(69, 13);
            this.lblCountHeader.TabIndex = 106;
            this.lblCountHeader.Text = "Количество:";
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNote.Location = new System.Drawing.Point(170, 152);
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
            // lblExistedCount
            // 
            this.lblExistedCount.AutoSize = true;
            this.lblExistedCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblExistedCount.Location = new System.Drawing.Point(59, 28);
            this.lblExistedCount.Name = "lblExistedCount";
            this.lblExistedCount.Size = new System.Drawing.Size(14, 13);
            this.lblExistedCount.TabIndex = 109;
            this.lblExistedCount.Text = "0";
            // 
            // lbxUoms
            // 
            this.lbxUoms.DataSource = this.bsUomStructure;
            this.lbxUoms.DisplayMember = "Uom";
            this.lbxUoms.FormattingEnabled = true;
            this.lbxUoms.Location = new System.Drawing.Point(12, 257);
            this.lbxUoms.Name = "lbxUoms";
            this.lbxUoms.Size = new System.Drawing.Size(284, 56);
            this.lbxUoms.TabIndex = 50;
            this.lbxUoms.ValueMember = "Qt";
            this.lbxUoms.SelectedIndexChanged += new System.EventHandler(this.lbxUoms_SelectedIndexChanged);
            this.lbxUoms.KeyDown += new System.Windows.Forms.KeyEventHandler(this.element_KeyDown);
            // 
            // bsUomStructure
            // 
            this.bsUomStructure.DataMember = "UOMStructure";
            this.bsUomStructure.DataSource = this.pickControl;
            // 
            // pickControl
            // 
            this.pickControl.DataSetName = "PickControl";
            this.pickControl.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // taUomStructure
            // 
            this.taUomStructure.ClearBeforeFill = true;
            // 
            // lblCountNtvHeader
            // 
            this.lblCountNtvHeader.AutoSize = true;
            this.lblCountNtvHeader.Location = new System.Drawing.Point(12, 182);
            this.lblCountNtvHeader.Name = "lblCountNtvHeader";
            this.lblCountNtvHeader.Size = new System.Drawing.Size(69, 13);
            this.lblCountNtvHeader.TabIndex = 110;
            this.lblCountNtvHeader.Text = "Кол-во НТВ:";
            // 
            // tbxCountNtv
            // 
            this.tbxCountNtv.Location = new System.Drawing.Point(107, 179);
            this.tbxCountNtv.Name = "tbxCountNtv";
            this.tbxCountNtv.Size = new System.Drawing.Size(53, 20);
            this.tbxCountNtv.TabIndex = 20;
            this.tbxCountNtv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.element_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 208);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 112;
            this.label6.Text = "Кол-во бой:";
            // 
            // tbxCountBoy
            // 
            this.tbxCountBoy.Location = new System.Drawing.Point(107, 205);
            this.tbxCountBoy.Name = "tbxCountBoy";
            this.tbxCountBoy.Size = new System.Drawing.Size(53, 20);
            this.tbxCountBoy.TabIndex = 30;
            this.tbxCountBoy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.element_KeyDown);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(133, 324);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 60;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(220, 324);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 70;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // tbxCountDefect
            // 
            this.tbxCountDefect.Location = new System.Drawing.Point(107, 231);
            this.tbxCountDefect.Name = "tbxCountDefect";
            this.tbxCountDefect.Size = new System.Drawing.Size(53, 20);
            this.tbxCountDefect.TabIndex = 40;
            // 
            // lblCountDefectHeader
            // 
            this.lblCountDefectHeader.AutoSize = true;
            this.lblCountDefectHeader.Location = new System.Drawing.Point(12, 234);
            this.lblCountDefectHeader.Name = "lblCountDefectHeader";
            this.lblCountDefectHeader.Size = new System.Drawing.Size(77, 13);
            this.lblCountDefectHeader.TabIndex = 116;
            this.lblCountDefectHeader.Text = "Кол-во брака:";
            // 
            // grbEntered
            // 
            this.grbEntered.Controls.Add(this.lblExistedCountNtvHeader);
            this.grbEntered.Controls.Add(this.lblExistedCountNtv);
            this.grbEntered.Controls.Add(this.lblExistedCountBoyHeader);
            this.grbEntered.Controls.Add(this.lblExistedCountBoy);
            this.grbEntered.Controls.Add(this.lblExistedCountDefectHeader);
            this.grbEntered.Controls.Add(this.lblExistedCountDefect);
            this.grbEntered.Controls.Add(this.lblExistedCountHeader);
            this.grbEntered.Controls.Add(this.lblExistedCount);
            this.grbEntered.Location = new System.Drawing.Point(15, 61);
            this.grbEntered.Name = "grbEntered";
            this.grbEntered.Size = new System.Drawing.Size(281, 75);
            this.grbEntered.TabIndex = 118;
            this.grbEntered.TabStop = false;
            this.grbEntered.Text = "Ранее введено";
            // 
            // lblExistedCountNtvHeader
            // 
            this.lblExistedCountNtvHeader.AutoSize = true;
            this.lblExistedCountNtvHeader.Location = new System.Drawing.Point(116, 28);
            this.lblExistedCountNtvHeader.Name = "lblExistedCountNtvHeader";
            this.lblExistedCountNtvHeader.Size = new System.Drawing.Size(32, 13);
            this.lblExistedCountNtvHeader.TabIndex = 125;
            this.lblExistedCountNtvHeader.Text = "НТВ:";
            // 
            // lblExistedCountNtv
            // 
            this.lblExistedCountNtv.AutoSize = true;
            this.lblExistedCountNtv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblExistedCountNtv.Location = new System.Drawing.Point(151, 28);
            this.lblExistedCountNtv.Name = "lblExistedCountNtv";
            this.lblExistedCountNtv.Size = new System.Drawing.Size(14, 13);
            this.lblExistedCountNtv.TabIndex = 124;
            this.lblExistedCountNtv.Text = "0";
            // 
            // lblExistedCountBoyHeader
            // 
            this.lblExistedCountBoyHeader.AutoSize = true;
            this.lblExistedCountBoyHeader.Location = new System.Drawing.Point(9, 53);
            this.lblExistedCountBoyHeader.Name = "lblExistedCountBoyHeader";
            this.lblExistedCountBoyHeader.Size = new System.Drawing.Size(29, 13);
            this.lblExistedCountBoyHeader.TabIndex = 123;
            this.lblExistedCountBoyHeader.Text = "Боя:";
            // 
            // lblExistedCountBoy
            // 
            this.lblExistedCountBoy.AutoSize = true;
            this.lblExistedCountBoy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblExistedCountBoy.Location = new System.Drawing.Point(59, 53);
            this.lblExistedCountBoy.Name = "lblExistedCountBoy";
            this.lblExistedCountBoy.Size = new System.Drawing.Size(14, 13);
            this.lblExistedCountBoy.TabIndex = 122;
            this.lblExistedCountBoy.Text = "0";
            // 
            // lblExistedCountDefectHeader
            // 
            this.lblExistedCountDefectHeader.AutoSize = true;
            this.lblExistedCountDefectHeader.Location = new System.Drawing.Point(116, 53);
            this.lblExistedCountDefectHeader.Name = "lblExistedCountDefectHeader";
            this.lblExistedCountDefectHeader.Size = new System.Drawing.Size(103, 13);
            this.lblExistedCountDefectHeader.TabIndex = 121;
            this.lblExistedCountDefectHeader.Text = "Заводского брака:";
            // 
            // lblExistedCountDefect
            // 
            this.lblExistedCountDefect.AutoSize = true;
            this.lblExistedCountDefect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblExistedCountDefect.Location = new System.Drawing.Point(225, 53);
            this.lblExistedCountDefect.Name = "lblExistedCountDefect";
            this.lblExistedCountDefect.Size = new System.Drawing.Size(14, 13);
            this.lblExistedCountDefect.TabIndex = 120;
            this.lblExistedCountDefect.Text = "0";
            // 
            // lblExistedCountHeader
            // 
            this.lblExistedCountHeader.AutoSize = true;
            this.lblExistedCountHeader.Location = new System.Drawing.Point(6, 28);
            this.lblExistedCountHeader.Name = "lblExistedCountHeader";
            this.lblExistedCountHeader.Size = new System.Drawing.Size(47, 13);
            this.lblExistedCountHeader.TabIndex = 119;
            this.lblExistedCountHeader.Text = "Товара:";
            // 
            // cbND_ZU
            // 
            this.cbND_ZU.Location = new System.Drawing.Point(195, 205);
            this.cbND_ZU.Name = "cbND_ZU";
            this.cbND_ZU.Size = new System.Drawing.Size(100, 46);
            this.cbND_ZU.TabIndex = 119;
            this.cbND_ZU.Text = "Заводское\r\nнедовложение";
            this.cbND_ZU.UseVisualStyleBackColor = true;
            // 
            // SetCountWithNtvForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(308, 359);
            this.Controls.Add(this.cbND_ZU);
            this.Controls.Add(this.grbEntered);
            this.Controls.Add(this.tbxCountDefect);
            this.Controls.Add(this.lblCountDefectHeader);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbxCountBoy);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbxCountNtv);
            this.Controls.Add(this.lblCountNtvHeader);
            this.Controls.Add(this.lbxUoms);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.lblLotn);
            this.Controls.Add(this.lblLotnHeader);
            this.Controls.Add(this.lblCountHeader);
            this.Controls.Add(this.lblItemName);
            this.Controls.Add(this.tbxCount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "SetCountWithNtvForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ввод количества";
            this.Load += new System.EventHandler(this.SetCountForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsUomStructure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickControl)).EndInit();
            this.grbEntered.ResumeLayout(false);
            this.grbEntered.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.TextBox tbxCount;
        private System.Windows.Forms.Label lblLotnHeader;
        private System.Windows.Forms.Label lblCountHeader;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Label lblLotn;
        private System.Windows.Forms.Label lblExistedCount;
        private System.Windows.Forms.ListBox lbxUoms;
        private System.Windows.Forms.BindingSource bsUomStructure;
        private WMSOffice.Data.PickControl pickControl;
        private WMSOffice.Data.PickControlTableAdapters.UOMStructureTableAdapter taUomStructure;
        private System.Windows.Forms.Label lblCountNtvHeader;
        private System.Windows.Forms.TextBox tbxCountNtv;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxCountBoy;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbxCountDefect;
        private System.Windows.Forms.Label lblCountDefectHeader;
        private System.Windows.Forms.GroupBox grbEntered;
        private System.Windows.Forms.Label lblExistedCountHeader;
        private System.Windows.Forms.Label lblExistedCountDefectHeader;
        private System.Windows.Forms.Label lblExistedCountDefect;
        private System.Windows.Forms.Label lblExistedCountBoyHeader;
        private System.Windows.Forms.Label lblExistedCountBoy;
        private System.Windows.Forms.Label lblExistedCountNtvHeader;
        private System.Windows.Forms.Label lblExistedCountNtv;
        private System.Windows.Forms.CheckBox cbND_ZU;
    }
}