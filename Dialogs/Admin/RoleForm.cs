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
    public partial class RoleForm : ListForm
    {
        public RoleForm(List<string> limitationList)
        {
            InitializeComponent();
            LimitationList = limitationList;
        }

        public List<string> LimitationList { get; private set; }

        private void EntityForm_OnAddItem(object sender, EventArgs e)
        {
            // добавление роли
            RoleWizardForm form = new RoleWizardForm(LimitationList, 0, tbSearch.Text);
            form.ShowDialog();
        }

        private void EntityForm_OnEditItem(object sender, DataGridViewRowEventArgs e)
        {
            RoleWizardForm form = new RoleWizardForm(LimitationList,
                                                    Convert.ToInt32(((DataRowView)e.Row.DataBoundItem).Row["ID"].ToString()), 
                                                    ((DataRowView)e.Row.DataBoundItem).Row["Роль"].ToString());
            form.ShowDialog();
        }
    }
}
