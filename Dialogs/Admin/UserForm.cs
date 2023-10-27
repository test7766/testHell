using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls;

namespace WMSOffice.Dialogs.Admin
{
    public partial class UserForm : ListForm
    {
        public UserForm(List<string> limitationList)
        {
            InitializeComponent();
            LimitationList = limitationList;
        }

        public List<string> LimitationList { get; private set; }

        private void UserForm_OnAddItem(object sender, EventArgs e)
        {
            // добавление пользователя
            UserWizardForm form = new UserWizardForm(LimitationList, 0, tbSearch.Text);
            form.ShowDialog();

        }

        private void UserForm_OnEditItem(object sender, DataGridViewRowEventArgs e)
        {
            UserWizardForm form = new UserWizardForm(LimitationList,
                                                     Convert.ToInt32(((DataRowView)e.Row.DataBoundItem).Row["ID"].ToString()), 
                                                     ((DataRowView)e.Row.DataBoundItem).Row["Пользователь"].ToString());
            form.ShowDialog();
        }
    }
}
