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
    public partial class ResourceForm : ListForm
    {
        public ResourceForm(List<string> limitationList)
        {
            InitializeComponent();
            LimitationList = limitationList;
        }

        public List<string> LimitationList { get; private set; }

        private void UserForm_OnAddItem(object sender, EventArgs e)
        {
            // добавление роли
            ResourceWizardForm form = new ResourceWizardForm(LimitationList, null, tbSearch.Text, null);
            form.ShowDialog();
        }

        private void UserForm_OnEditItem(object sender, DataGridViewRowEventArgs e)
        {
            ResourceWizardForm form = new ResourceWizardForm(LimitationList,
                                                         (string)(((DataRowView)e.Row.DataBoundItem).Row["ID"]), 
                                                         (string)(((DataRowView)e.Row.DataBoundItem).Row["Ресурс"]),
                                                         (string)(((DataRowView)e.Row.DataBoundItem).Row["Модуль"]));
            form.ShowDialog();
        }
    }
}
