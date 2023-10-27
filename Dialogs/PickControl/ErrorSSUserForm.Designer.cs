namespace WMSOffice.Dialogs.PickControl
{
    partial class ErrorSSUserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorSSUserForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUndoDoc = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRepairDoc = new System.Windows.Forms.Button();
            this.imageListButtons = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WMSOffice.Properties.Resources.metacontact_unknown;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 101;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(146, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 20);
            this.label1.TabIndex = 102;
            this.label1.Text = "Контроль завершен с ошибкой!";
            // 
            // btnUndoDoc
            // 
            this.btnUndoDoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUndoDoc.Image = global::WMSOffice.Properties.Resources.symbol_stop;
            this.btnUndoDoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUndoDoc.Location = new System.Drawing.Point(146, 67);
            this.btnUndoDoc.Name = "btnUndoDoc";
            this.btnUndoDoc.Size = new System.Drawing.Size(231, 56);
            this.btnUndoDoc.TabIndex = 103;
            this.btnUndoDoc.Text = "Отменить контроль сборочного\r\n(F8)";
            this.btnUndoDoc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUndoDoc.UseVisualStyleBackColor = true;
            this.btnUndoDoc.Click += new System.EventHandler(this.btnUndoDoc_Click);
            this.btnUndoDoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ErrorSSUserForm_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(143, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 26);
            this.label2.TabIndex = 104;
            this.label2.Text = "Вы можете: \r\n1) полностью повторить контроль";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(146, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(232, 39);
            this.label3.TabIndex = 105;
            this.label3.Text = "2) исправить контроль. \r\nПозовите Старшего смены для проведения \r\nисправления оши" +
                "бок сборки/контроля";
            // 
            // btnRepairDoc
            // 
            this.btnRepairDoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRepairDoc.ImageKey = "question";
            this.btnRepairDoc.ImageList = this.imageListButtons;
            this.btnRepairDoc.Location = new System.Drawing.Point(146, 172);
            this.btnRepairDoc.Name = "btnRepairDoc";
            this.btnRepairDoc.Size = new System.Drawing.Size(231, 56);
            this.btnRepairDoc.TabIndex = 106;
            this.btnRepairDoc.Text = "Исправить контроль\r\n(с правами Старшего смены)\r\n(F4)";
            this.btnRepairDoc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRepairDoc.UseVisualStyleBackColor = true;
            this.btnRepairDoc.Click += new System.EventHandler(this.btnRepairDoc_Click);
            this.btnRepairDoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ErrorSSUserForm_KeyDown);
            // 
            // imageListButtons
            // 
            this.imageListButtons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListButtons.ImageStream")));
            this.imageListButtons.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListButtons.Images.SetKeyName(0, "question");
            // 
            // ErrorSSUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 241);
            this.ControlBox = false;
            this.Controls.Add(this.btnRepairDoc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnUndoDoc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ErrorSSUserForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ошибка контроля!";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ErrorSSUserForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUndoDoc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRepairDoc;
        private System.Windows.Forms.ImageList imageListButtons;
    }
}