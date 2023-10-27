namespace WMSOffice.Dialogs.WMove
{
    partial class ChangeLocnForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbCount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbLocn = new System.Windows.Forms.TextBox();
            this.btnLocn = new System.Windows.Forms.Button();
            this.groupSplit = new System.Windows.Forms.GroupBox();
            this.btnSplitLocn = new System.Windows.Forms.Button();
            this.tbSplitLocn = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSplitCount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chbSplit = new System.Windows.Forms.CheckBox();
            this.groupReason = new System.Windows.Forms.GroupBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbReasons = new System.Windows.Forms.ComboBox();
            this.wMChangeLocnReasonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wMove = new WMSOffice.Data.WMove();
            this.wM_ChangeLocnReasonTableAdapter = new WMSOffice.Data.WMoveTableAdapters.WM_ChangeLocnReasonTableAdapter();
            this.groupSplit.SuspendLayout();
            this.groupReason.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wMChangeLocnReasonBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wMove)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(21, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(118, 8);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 101;
            this.label1.Text = "Количество:";
            // 
            // tbCount
            // 
            this.tbCount.Enabled = false;
            this.tbCount.Location = new System.Drawing.Point(93, 10);
            this.tbCount.Name = "tbCount";
            this.tbCount.Size = new System.Drawing.Size(100, 20);
            this.tbCount.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(199, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 103;
            this.label2.Text = "Место:";
            // 
            // tbLocn
            // 
            this.tbLocn.BackColor = System.Drawing.SystemColors.Window;
            this.tbLocn.Location = new System.Drawing.Point(247, 10);
            this.tbLocn.Name = "tbLocn";
            this.tbLocn.ReadOnly = true;
            this.tbLocn.Size = new System.Drawing.Size(100, 20);
            this.tbLocn.TabIndex = 4;
            this.tbLocn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbLocn_KeyDown);
            // 
            // btnLocn
            // 
            this.btnLocn.Location = new System.Drawing.Point(353, 8);
            this.btnLocn.Name = "btnLocn";
            this.btnLocn.Size = new System.Drawing.Size(23, 23);
            this.btnLocn.TabIndex = 5;
            this.btnLocn.TabStop = false;
            this.btnLocn.Text = "..";
            this.btnLocn.UseVisualStyleBackColor = true;
            this.btnLocn.Click += new System.EventHandler(this.btnLocn_Click);
            // 
            // groupSplit
            // 
            this.groupSplit.Controls.Add(this.btnSplitLocn);
            this.groupSplit.Controls.Add(this.tbSplitLocn);
            this.groupSplit.Controls.Add(this.label4);
            this.groupSplit.Controls.Add(this.tbSplitCount);
            this.groupSplit.Controls.Add(this.label3);
            this.groupSplit.Enabled = false;
            this.groupSplit.Location = new System.Drawing.Point(12, 39);
            this.groupSplit.Name = "groupSplit";
            this.groupSplit.Size = new System.Drawing.Size(379, 62);
            this.groupSplit.TabIndex = 7;
            this.groupSplit.TabStop = false;
            // 
            // btnSplitLocn
            // 
            this.btnSplitLocn.Location = new System.Drawing.Point(341, 24);
            this.btnSplitLocn.Name = "btnSplitLocn";
            this.btnSplitLocn.Size = new System.Drawing.Size(23, 23);
            this.btnSplitLocn.TabIndex = 10;
            this.btnSplitLocn.TabStop = false;
            this.btnSplitLocn.Text = "..";
            this.btnSplitLocn.UseVisualStyleBackColor = true;
            this.btnSplitLocn.Click += new System.EventHandler(this.btnSplitLocn_Click);
            // 
            // tbSplitLocn
            // 
            this.tbSplitLocn.BackColor = System.Drawing.SystemColors.Window;
            this.tbSplitLocn.Location = new System.Drawing.Point(235, 26);
            this.tbSplitLocn.Name = "tbSplitLocn";
            this.tbSplitLocn.ReadOnly = true;
            this.tbSplitLocn.Size = new System.Drawing.Size(100, 20);
            this.tbSplitLocn.TabIndex = 9;
            this.tbSplitLocn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSplitLocn_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(187, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 106;
            this.label4.Text = "Место:";
            // 
            // tbSplitCount
            // 
            this.tbSplitCount.Location = new System.Drawing.Point(81, 26);
            this.tbSplitCount.Name = "tbSplitCount";
            this.tbSplitCount.Size = new System.Drawing.Size(100, 20);
            this.tbSplitCount.TabIndex = 8;
            this.tbSplitCount.TextChanged += new System.EventHandler(this.tbSplitCount_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 102;
            this.label3.Text = "Количество:";
            // 
            // chbSplit
            // 
            this.chbSplit.AutoSize = true;
            this.chbSplit.Location = new System.Drawing.Point(18, 37);
            this.chbSplit.Name = "chbSplit";
            this.chbSplit.Size = new System.Drawing.Size(125, 17);
            this.chbSplit.TabIndex = 6;
            this.chbSplit.Text = "Разделение строки";
            this.chbSplit.UseVisualStyleBackColor = true;
            this.chbSplit.CheckedChanged += new System.EventHandler(this.chbSplit_CheckedChanged);
            // 
            // groupReason
            // 
            this.groupReason.Controls.Add(this.tbDescription);
            this.groupReason.Controls.Add(this.label6);
            this.groupReason.Controls.Add(this.label5);
            this.groupReason.Controls.Add(this.cbReasons);
            this.groupReason.Location = new System.Drawing.Point(12, 107);
            this.groupReason.Name = "groupReason";
            this.groupReason.Size = new System.Drawing.Size(379, 118);
            this.groupReason.TabIndex = 11;
            this.groupReason.TabStop = false;
            this.groupReason.Text = "Причина изменения:";
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(72, 50);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDescription.Size = new System.Drawing.Size(292, 60);
            this.tbDescription.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Описание:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Тип:";
            // 
            // cbReasons
            // 
            this.cbReasons.DataSource = this.wMChangeLocnReasonBindingSource;
            this.cbReasons.DisplayMember = "Reason_Code";
            this.cbReasons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReasons.FormattingEnabled = true;
            this.cbReasons.Location = new System.Drawing.Point(72, 23);
            this.cbReasons.Name = "cbReasons";
            this.cbReasons.Size = new System.Drawing.Size(292, 21);
            this.cbReasons.TabIndex = 12;
            this.cbReasons.ValueMember = "Reason_Code_ID";
            // 
            // wMChangeLocnReasonBindingSource
            // 
            this.wMChangeLocnReasonBindingSource.DataMember = "WM_ChangeLocnReason";
            this.wMChangeLocnReasonBindingSource.DataSource = this.wMove;
            // 
            // wMove
            // 
            this.wMove.DataSetName = "WMove";
            this.wMove.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // wM_ChangeLocnReasonTableAdapter
            // 
            this.wM_ChangeLocnReasonTableAdapter.ClearBeforeFill = true;
            // 
            // ChangeLocnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 275);
            this.Controls.Add(this.chbSplit);
            this.Controls.Add(this.groupSplit);
            this.Controls.Add(this.groupReason);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbCount);
            this.Controls.Add(this.btnLocn);
            this.Controls.Add(this.tbLocn);
            this.Name = "ChangeLocnForm";
            this.Text = "Изменить место назначения";
            this.Load += new System.EventHandler(this.ChangeLocnForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChangeLocnForm_FormClosing);
            this.Controls.SetChildIndex(this.tbLocn, 0);
            this.Controls.SetChildIndex(this.btnLocn, 0);
            this.Controls.SetChildIndex(this.tbCount, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.groupReason, 0);
            this.Controls.SetChildIndex(this.groupSplit, 0);
            this.Controls.SetChildIndex(this.chbSplit, 0);
            this.groupSplit.ResumeLayout(false);
            this.groupSplit.PerformLayout();
            this.groupReason.ResumeLayout(false);
            this.groupReason.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wMChangeLocnReasonBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wMove)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource wMChangeLocnReasonBindingSource;
        private WMSOffice.Data.WMove wMove;
        private WMSOffice.Data.WMoveTableAdapters.WM_ChangeLocnReasonTableAdapter wM_ChangeLocnReasonTableAdapter;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.TextBox tbCount;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.TextBox tbLocn;
        protected System.Windows.Forms.Button btnLocn;
        protected System.Windows.Forms.CheckBox chbSplit;
        protected System.Windows.Forms.GroupBox groupSplit;
        protected System.Windows.Forms.Button btnSplitLocn;
        protected System.Windows.Forms.TextBox tbSplitLocn;
        protected System.Windows.Forms.Label label4;
        protected System.Windows.Forms.TextBox tbSplitCount;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.GroupBox groupReason;
        protected System.Windows.Forms.Label label6;
        protected System.Windows.Forms.Label label5;
        protected System.Windows.Forms.ComboBox cbReasons;
        protected System.Windows.Forms.TextBox tbDescription;
    }
}