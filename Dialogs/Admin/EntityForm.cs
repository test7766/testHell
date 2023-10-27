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
    public partial class EntityForm : ListForm
    {
        public EntityForm(List<string> limitationList)
        {
            InitializeComponent();
            LimitationList = limitationList;
        }

        public List<string> LimitationList { get; private set; }

        private void EntityForm_OnAddItem(object sender, EventArgs e)
        {
            // добавление сущности
            EntityWizardForm form = new EntityWizardForm(LimitationList, null, tbSearch.Text, null);
            form.ShowDialog();
        }

        private void EntityForm_OnEditItem(object sender, DataGridViewRowEventArgs e)
        {
            EntityWizardForm form = new EntityWizardForm(LimitationList,
                                                         (string)(((DataRowView)e.Row.DataBoundItem).Row["ID"]), 
                                                         (string)(((DataRowView)e.Row.DataBoundItem).Row["Название"]),
                                                         (((DataRowView)e.Row.DataBoundItem).Row["Процедура"] == DBNull.Value ? null : (string)((DataRowView)e.Row.DataBoundItem).Row["Процедура"]));
            form.ShowDialog();
        }
    }
}
