namespace WMSOffice.Dialogs
{
    partial class ChangePasswordForm
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
            this.lbl_OldPassword = new System.Windows.Forms.Label();
            this.lbl_NewPassword = new System.Windows.Forms.Label();
            this.lbl_ConfirmPassword = new System.Windows.Forms.Label();
            this.tb_OldPassword = new System.Windows.Forms.TextBox();
            this.tb_NewPassword = new System.Windows.Forms.TextBox();
            this.tb_ConfirmPassword = new System.Windows.Forms.TextBox();
            this.lbl_User = new System.Windows.Forms.Label();
            this.cb_Users = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            //this.btnOK.Location = new System.Drawing.Point(260, 8);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            //this.btnCancel.Location = new System.Drawing.Point(341, 8);
            // 
            // lbl_OldPassword
            // 
            this.lbl_OldPassword.AutoSize = true;
            this.lbl_OldPassword.Location = new System.Drawing.Point(12, 48);
            this.lbl_OldPassword.Name = "lbl_OldPassword";
            this.lbl_OldPassword.Size = new System.Drawing.Size(87, 13);
            this.lbl_OldPassword.TabIndex = 8;
            this.lbl_OldPassword.Text = "Старый пароль:";
            // 
            // lbl_NewPassword
            // 
            this.lbl_NewPassword.AutoSize = true;
            this.lbl_NewPassword.Location = new System.Drawing.Point(12, 78);
            this.lbl_NewPassword.Name = "lbl_NewPassword";
            this.lbl_NewPassword.Size = new System.Drawing.Size(83, 13);
            this.lbl_NewPassword.TabIndex = 9;
            this.lbl_NewPassword.Text = "Новый пароль:";
            // 
            // lbl_ConfirmPassword
            // 
            this.lbl_ConfirmPassword.AutoSize = true;
            this.lbl_ConfirmPassword.Location = new System.Drawing.Point(12, 108);
            this.lbl_ConfirmPassword.Name = "lbl_ConfirmPassword";
            this.lbl_ConfirmPassword.Size = new System.Drawing.Size(115, 13);
            this.lbl_ConfirmPassword.TabIndex = 10;
            this.lbl_ConfirmPassword.Text = "Подтвердить пароль:";
            // 
            // tb_OldPassword
            // 
            this.tb_OldPassword.Location = new System.Drawing.Point(127, 45);
            this.tb_OldPassword.MaxLength = 50;
            this.tb_OldPassword.Name = "tb_OldPassword";
            this.tb_OldPassword.Size = new System.Drawing.Size(217, 20);
            this.tb_OldPassword.TabIndex = 11;
            this.tb_OldPassword.UseSystemPasswordChar = true;
            // 
            // tb_NewPassword
            // 
            this.tb_NewPassword.Location = new System.Drawing.Point(127, 75);
            this.tb_NewPassword.MaxLength = 50;
            this.tb_NewPassword.Name = "tb_NewPassword";
            this.tb_NewPassword.Size = new System.Drawing.Size(217, 20);
            this.tb_NewPassword.TabIndex = 12;
            this.tb_NewPassword.UseSystemPasswordChar = true;
            // 
            // tb_ConfirmPassword
            // 
            this.tb_ConfirmPassword.Location = new System.Drawing.Point(127, 105);
            this.tb_ConfirmPassword.MaxLength = 50;
            this.tb_ConfirmPassword.Name = "tb_ConfirmPassword";
            this.tb_ConfirmPassword.Size = new System.Drawing.Size(217, 20);
            this.tb_ConfirmPassword.TabIndex = 13;
            this.tb_ConfirmPassword.UseSystemPasswordChar = true;
            // 
            // lbl_User
            // 
            this.lbl_User.AutoSize = true;
            this.lbl_User.Location = new System.Drawing.Point(12, 9);
            this.lbl_User.Name = "lbl_User";
            this.lbl_User.Size = new System.Drawing.Size(83, 13);
            this.lbl_User.TabIndex = 14;
            this.lbl_User.Text = "Пользователь:";
            // 
            // cb_Users
            // 
            this.cb_Users.FormattingEnabled = true;
            this.cb_Users.Location = new System.Drawing.Point(127, 6);
            this.cb_Users.Name = "cb_Users";
            this.cb_Users.Size = new System.Drawing.Size(217, 21);
            this.cb_Users.TabIndex = 15;
            // 
            // ChangePasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 177);
            this.Controls.Add(this.cb_Users);
            this.Controls.Add(this.lbl_User);
            this.Controls.Add(this.tb_ConfirmPassword);
            this.Controls.Add(this.tb_NewPassword);
            this.Controls.Add(this.tb_OldPassword);
            this.Controls.Add(this.lbl_ConfirmPassword);
            this.Controls.Add(this.lbl_NewPassword);
            this.Controls.Add(this.lbl_OldPassword);
            this.Name = "ChangePasswordForm";
            this.Text = "Смена пароля";
            this.Shown += new System.EventHandler(this.ChangePasswordForm_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChangePasswordForm_FormClosing);
            this.Controls.SetChildIndex(this.lbl_OldPassword, 0);
            this.Controls.SetChildIndex(this.lbl_NewPassword, 0);
            this.Controls.SetChildIndex(this.lbl_ConfirmPassword, 0);
            this.Controls.SetChildIndex(this.tb_OldPassword, 0);
            this.Controls.SetChildIndex(this.tb_NewPassword, 0);
            this.Controls.SetChildIndex(this.tb_ConfirmPassword, 0);
            this.Controls.SetChildIndex(this.lbl_User, 0);
            this.Controls.SetChildIndex(this.cb_Users, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_OldPassword;
        private System.Windows.Forms.Label lbl_NewPassword;
        private System.Windows.Forms.Label lbl_ConfirmPassword;
        private System.Windows.Forms.TextBox tb_OldPassword;
        private System.Windows.Forms.TextBox tb_NewPassword;
        private System.Windows.Forms.TextBox tb_ConfirmPassword;
        private System.Windows.Forms.Label lbl_User;
        private System.Windows.Forms.ComboBox cb_Users;
    }
}