using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Data;
using WMSOffice.Data.AccessTableAdapters;
using System.Data.SqlClient;
using WMSOffice.Dialogs;

namespace WMSOffice.Dialogs
{
    public partial class ChangePasswordForm : DialogForm
    {
        private Access.SessionUsersDataTable table = null;

        public ChangePasswordForm()
        {
            InitializeComponent();
            btnOK.DialogResult = DialogResult.None;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(tb_NewPassword.Text)) && (!string.IsNullOrEmpty(tb_ConfirmPassword.Text)) && (tb_NewPassword.Text == tb_ConfirmPassword.Text))
            {
                try
                {
                    using (Data.AccessTableAdapters.QueriesTableAdapter adapter = new WMSOffice.Data.AccessTableAdapters.QueriesTableAdapter())
                    {
                        foreach(Access.SessionUsersRow row in table.Rows)
                            if (row.Employee == cb_Users.SelectedItem.ToString())
                            {
                                adapter.ChangeUserPassword(row.Employee_ID, UserID, tb_OldPassword.Text, tb_NewPassword.Text);
                                MessageBox.Show("Пароль был успешно изменен!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Message.Contains("WRONG OLD PASSWORD"))
                    {
                        MessageBox.Show("Старый пароль неправильный!\nПовторите попытку еще раз!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tb_OldPassword.Text = tb_NewPassword.Text = tb_ConfirmPassword.Text = String.Empty;
                    }
                    else
                        MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("\'Новый пароль\' и \'Подтвердить пароль\' должны совпадать!\nВведите заново новый пароль.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tb_NewPassword.Text = tb_ConfirmPassword.Text = String.Empty;
            }
        }

        /// <summary>
        /// Наполняет ComboBox списком пользователей текущей сессии
        /// </summary>
        private void ChangePasswordForm_Shown(object sender, EventArgs e)
        {
            using (SessionUsersTableAdapter adapter = new SessionUsersTableAdapter())
            {
                table = adapter.GetData(UserID);

                if (table != null && table.Count > 0)
                {
                    foreach (Data.Access.SessionUsersRow row in table.Rows)
                        cb_Users.Items.Add(row.Employee);

                    cb_Users.SelectedIndex = 0;
                }
            }
        }

        private void ChangePasswordForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (table != null)
                table.Dispose();
        }

    }
}
