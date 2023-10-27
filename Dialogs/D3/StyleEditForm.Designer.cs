namespace WMSOffice.Dialogs.D3
{
    partial class StyleEditForm
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
            this.groupPreview = new System.Windows.Forms.GroupBox();
            this.picturePreview = new System.Windows.Forms.PictureBox();
            this.groupMain = new System.Windows.Forms.GroupBox();
            this.cbForeColor = new WMSOffice.Controls.Design.ComboBoxColorPicker();
            this.cbBackColor = new WMSOffice.Controls.Design.ComboBoxColorPicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.groupBorder = new System.Windows.Forms.GroupBox();
            this.cbBorderType = new System.Windows.Forms.ComboBox();
            this.nudBorderWidth = new System.Windows.Forms.NumericUpDown();
            this.cbBorderColor = new WMSOffice.Controls.Design.ComboBoxColorPicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturePreview)).BeginInit();
            this.groupMain.SuspendLayout();
            this.groupBorder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBorderWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // groupPreview
            // 
            this.groupPreview.Controls.Add(this.picturePreview);
            this.groupPreview.Location = new System.Drawing.Point(271, 12);
            this.groupPreview.Name = "groupPreview";
            this.groupPreview.Size = new System.Drawing.Size(173, 127);
            this.groupPreview.TabIndex = 101;
            this.groupPreview.TabStop = false;
            this.groupPreview.Text = "Предварительный просмотр:";
            // 
            // picturePreview
            // 
            this.picturePreview.Location = new System.Drawing.Point(6, 19);
            this.picturePreview.Name = "picturePreview";
            this.picturePreview.Size = new System.Drawing.Size(161, 102);
            this.picturePreview.TabIndex = 0;
            this.picturePreview.TabStop = false;
            // 
            // groupMain
            // 
            this.groupMain.Controls.Add(this.cbForeColor);
            this.groupMain.Controls.Add(this.cbBackColor);
            this.groupMain.Controls.Add(this.label3);
            this.groupMain.Controls.Add(this.label2);
            this.groupMain.Location = new System.Drawing.Point(12, 38);
            this.groupMain.Name = "groupMain";
            this.groupMain.Size = new System.Drawing.Size(243, 101);
            this.groupMain.TabIndex = 102;
            this.groupMain.TabStop = false;
            this.groupMain.Text = "Основные параметры:";
            // 
            // cbForeColor
            // 
            this.cbForeColor.Color = System.Drawing.Color.Black;
            this.cbForeColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbForeColor.DropDownHeight = 1;
            this.cbForeColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbForeColor.DropDownWidth = 1;
            this.cbForeColor.FormattingEnabled = true;
            this.cbForeColor.IntegralHeight = false;
            this.cbForeColor.ItemHeight = 16;
            this.cbForeColor.Items.AddRange(new object[] {
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color"});
            this.cbForeColor.Location = new System.Drawing.Point(105, 59);
            this.cbForeColor.Name = "cbForeColor";
            this.cbForeColor.Size = new System.Drawing.Size(90, 22);
            this.cbForeColor.TabIndex = 3;
            this.cbForeColor.SelectedColorChanged += new System.EventHandler(this.cbForeColor_SelectedColorChanged);
            // 
            // cbBackColor
            // 
            this.cbBackColor.Color = System.Drawing.Color.Black;
            this.cbBackColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbBackColor.DropDownHeight = 1;
            this.cbBackColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBackColor.DropDownWidth = 1;
            this.cbBackColor.FormattingEnabled = true;
            this.cbBackColor.IntegralHeight = false;
            this.cbBackColor.ItemHeight = 16;
            this.cbBackColor.Items.AddRange(new object[] {
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color"});
            this.cbBackColor.Location = new System.Drawing.Point(105, 30);
            this.cbBackColor.Name = "cbBackColor";
            this.cbBackColor.Size = new System.Drawing.Size(90, 22);
            this.cbBackColor.TabIndex = 2;
            this.cbBackColor.SelectedColorChanged += new System.EventHandler(this.cbBackColor_SelectedColorChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Цвет текста:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Цвет фона:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 103;
            this.label1.Text = "Название:";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(78, 12);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(177, 20);
            this.tbName.TabIndex = 104;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // groupBorder
            // 
            this.groupBorder.Controls.Add(this.cbBorderType);
            this.groupBorder.Controls.Add(this.nudBorderWidth);
            this.groupBorder.Controls.Add(this.cbBorderColor);
            this.groupBorder.Controls.Add(this.label6);
            this.groupBorder.Controls.Add(this.label5);
            this.groupBorder.Controls.Add(this.label4);
            this.groupBorder.Location = new System.Drawing.Point(12, 145);
            this.groupBorder.Name = "groupBorder";
            this.groupBorder.Size = new System.Drawing.Size(432, 85);
            this.groupBorder.TabIndex = 105;
            this.groupBorder.TabStop = false;
            this.groupBorder.Text = "Граница объекта:";
            // 
            // cbBorderType
            // 
            this.cbBorderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBorderType.FormattingEnabled = true;
            this.cbBorderType.Location = new System.Drawing.Point(291, 53);
            this.cbBorderType.Name = "cbBorderType";
            this.cbBorderType.Size = new System.Drawing.Size(121, 21);
            this.cbBorderType.TabIndex = 5;
            this.cbBorderType.SelectedIndexChanged += new System.EventHandler(this.cbBorderType_SelectedIndexChanged);
            // 
            // nudBorderWidth
            // 
            this.nudBorderWidth.Location = new System.Drawing.Point(105, 54);
            this.nudBorderWidth.Name = "nudBorderWidth";
            this.nudBorderWidth.Size = new System.Drawing.Size(90, 20);
            this.nudBorderWidth.TabIndex = 4;
            this.nudBorderWidth.ValueChanged += new System.EventHandler(this.nudBorderWidth_ValueChanged);
            // 
            // cbBorderColor
            // 
            this.cbBorderColor.Color = System.Drawing.Color.Black;
            this.cbBorderColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbBorderColor.DropDownHeight = 1;
            this.cbBorderColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBorderColor.DropDownWidth = 1;
            this.cbBorderColor.FormattingEnabled = true;
            this.cbBorderColor.IntegralHeight = false;
            this.cbBorderColor.ItemHeight = 16;
            this.cbBorderColor.Items.AddRange(new object[] {
            "Color",
            "Color",
            "Color",
            "Color",
            "Color"});
            this.cbBorderColor.Location = new System.Drawing.Point(105, 26);
            this.cbBorderColor.Name = "cbBorderColor";
            this.cbBorderColor.Size = new System.Drawing.Size(90, 22);
            this.cbBorderColor.TabIndex = 3;
            this.cbBorderColor.SelectedColorChanged += new System.EventHandler(this.cbBorderColor_SelectedColorChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(256, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Тип:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Толщина:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Цвет границы:";
            // 
            // StyleEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 278);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBorder);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.groupPreview);
            this.Controls.Add(this.groupMain);
            this.Name = "StyleEditForm";
            this.Text = "Редактировать стиль";
            this.Load += new System.EventHandler(this.StyleEditForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StyleEditForm_FormClosing);
            this.Controls.SetChildIndex(this.groupMain, 0);
            this.Controls.SetChildIndex(this.groupPreview, 0);
            this.Controls.SetChildIndex(this.tbName, 0);
            this.Controls.SetChildIndex(this.groupBorder, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.groupPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picturePreview)).EndInit();
            this.groupMain.ResumeLayout(false);
            this.groupMain.PerformLayout();
            this.groupBorder.ResumeLayout(false);
            this.groupBorder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBorderWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupPreview;
        private System.Windows.Forms.GroupBox groupMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBorder;
        private System.Windows.Forms.PictureBox picturePreview;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private WMSOffice.Controls.Design.ComboBoxColorPicker cbForeColor;
        private WMSOffice.Controls.Design.ComboBoxColorPicker cbBackColor;
        private System.Windows.Forms.ComboBox cbBorderType;
        private System.Windows.Forms.NumericUpDown nudBorderWidth;
        private WMSOffice.Controls.Design.ComboBoxColorPicker cbBorderColor;
    }
}