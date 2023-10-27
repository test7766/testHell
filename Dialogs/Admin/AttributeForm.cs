using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls;
using WMSOffice.Admin.Database;
using WMSOffice.Data;
using WMSOffice.Data.AdminTableAdapters;

namespace WMSOffice.Dialogs.Admin
{
    public partial class AttributeForm : WizardBlankForm
    {
        public AttributeForm(List<string> limitationList, int limitation_ID, string description, string entity_ID)
        {
            InitializeComponent();

            this.CanResize = true;

            LimitationID = limitation_ID;
            LimitationList = limitationList;
            EntityID = entity_ID;

            wizardPageAccessEntityLimitations.Description = description;
 
            bShowEntityList.Enabled = false;

            if (limitationList.Contains("entity"))
            {
                bShowEntityList.Enabled = true;
                bShowEntityElements.Visible = true;
            }


            LoadEntityAttributes();

            wizard.btnCancel.Visible = false;

            // Теперь разрешаем Bind() данных в контроле. Т.к. на этапе инициализации он вызывается несколько раз без надобности.
            AccessLimitationEntityElementsTwoListControl.CanBind = true;
        }

        #region properties

        public List<string> LimitationList { get; private set; }

        public string EntityID { private get; set; }

        public int LimitationID {get; set;}

        public string SelectedEntityID { get; set; }

        #endregion


        #region EventHandlers

        private void wizard_WizardClosed(object sender, EventArgs e)
        {
            Close();
        }
          
        private bool AccessLimitationEntityElementsTwoListControl_OnAddItem(object sender, ListView.SelectedListViewItemCollection e)
        {
            try
            {
                MyKeyValuePair p = (MyKeyValuePair)cbEntities.SelectedItem;
                foreach (ListViewItem item in e)
                    Database.Actions.LimitationEntityElementsInsert(p.Pair.Key, item.Name, LimitationID);
            }
            catch (Exception) { return false; }
            return true;
        }

        private bool AccessLimitationEntityElementsTwoListControl_OnDeleteItem(object sender, ListView.SelectedListViewItemCollection e)
        {
            try
            {
                MyKeyValuePair p = (MyKeyValuePair)cbEntities.SelectedItem;
                foreach (ListViewItem item in e)
                    Database.Actions.LimitationEntityElementsDelete(p.Pair.Key, item.Name, LimitationID);
            }
            catch (Exception) { return false; }
            return true;
        }

        private void cbEntities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbEntities.SelectedIndex >= 0)
            {
                cbLimit.Enabled = true;
                MyKeyValuePair p = (MyKeyValuePair)cbEntities.SelectedItem;
                SelectedEntityID = p.Pair.Key;
                using (ActionsTableAdapter adapter = new ActionsTableAdapter())
                {
                    object entityLimitationID = adapter.EntityLimitationIDSelect(p.Pair.Key, LimitationID);
                    cbLimit.CheckedChanged -= new System.EventHandler(this.cbLimit_CheckedChanged);
                    cbLimit.Checked = AccessLimitationEntityElementsTwoListControl.Enabled = cbAllValues.Enabled = (entityLimitationID == null) ? false : true;
                    cbLimit.CheckedChanged += new System.EventHandler(this.cbLimit_CheckedChanged);
                }

                if (cbLimit.Checked)
                {
                    LoadEntityElements();
                }
                else
                {
                    AccessLimitationEntityElementsTwoListControl.Clear();
                    cbAllValues.Checked = false;
                }
            }

            bShowEntityElements.Enabled = true;
        }

        private void cbAllValues_CheckedChanged(object sender, EventArgs e)
        {
            MyKeyValuePair p = (MyKeyValuePair)cbEntities.SelectedItem;
            Database.Actions.LimitationEntityAllValuesUpdate(p.Pair.Key, LimitationID, cbAllValues.Checked);
        }

        private void cbLimit_CheckedChanged(object sender, EventArgs e)
        {
            MyKeyValuePair p = (MyKeyValuePair)cbEntities.SelectedItem;

            if (cbLimit.Checked)
            {                
                Database.Actions.EntityLimitationInsert( p.Pair.Key, LimitationID);
                cbEntities.SelectedIndexChanged -= new System.EventHandler(this.cbEntities_SelectedIndexChanged);
                LoadEntityAttributes();
                cbEntities.SelectedIndexChanged += new System.EventHandler(this.cbEntities_SelectedIndexChanged);
                LoadEntityElements();
            }
            else
            {
                // почистить две таблички
                Database.Actions.EntityLimitationDelete(p.Pair.Key, LimitationID);

                AccessLimitationEntityElementsTwoListControl.Clear();
                cbAllValues.CheckedChanged -= new System.EventHandler(this.cbAllValues_CheckedChanged);
                cbAllValues.Checked = false;
                cbAllValues.CheckedChanged += new System.EventHandler(this.cbAllValues_CheckedChanged);
                cbEntities.SelectedIndexChanged -= new System.EventHandler(this.cbEntities_SelectedIndexChanged);
                LoadEntityAttributes();
                cbEntities.SelectedIndexChanged += new System.EventHandler(this.cbEntities_SelectedIndexChanged);
            }
            AccessLimitationEntityElementsTwoListControl.Enabled = cbAllValues.Enabled = cbLimit.Checked;          
        }

        private void bShowEntityList_Click(object sender, EventArgs e)
        {
            EntityForm form = new EntityForm(LimitationList);
            form.ShowDialog(this);
        }

        private void bShowEntityElements_Click(object sender, EventArgs e)
        {
            MyKeyValuePair p = (MyKeyValuePair)cbEntities.SelectedItem;
            EntityWizardForm form = new EntityWizardForm(LimitationList, p.Pair.Key, p.Pair.Value.Replace("* ", ""), (string)Database.Actions.GetEntityElementsProcedure(p.Pair.Key));
            form.wizard.PageIndex = 1;
            form.ShowDialog(this);  
        }

        #endregion


        #region Methods

        private void LoadEntityAttributes()
        {
            cbEntities.Items.Clear();
            using (EntityAttributesTableAdapter adapter = new EntityAttributesTableAdapter())
            {
                Data.Admin.EntityAttributesDataTable tableEntityAttributes = adapter.GetData(EntityID);
                using (LimitationEntitiesTableAdapter adapter2 = new LimitationEntitiesTableAdapter())
                {
                    Data.Admin.LimitationEntitiesDataTable tableLimEnt = adapter2.GetData(LimitationID);

                    foreach (Data.Admin.EntityAttributesRow row in tableEntityAttributes.Rows)
                    {
                        cbEntities.Items.Add(new MyKeyValuePair(new KeyValuePair<string, string>(
                                        row.ID,
                            // если сущность ограгичена, то добавляем в название вначале *
                                        (tableLimEnt.Select("Entity_ID = '" + row.ID + "'").Length > 0 ? "* " : "") + row.Название)));
                    }
                }
            }

            if (!string.IsNullOrEmpty(SelectedEntityID))
            {
                foreach (var item in cbEntities.Items)
                {
                    if (((MyKeyValuePair)item).Pair.Key == SelectedEntityID)
                        cbEntities.SelectedItem = item;
                }
            }
        }

        private void LoadEntityElements()
        {
            MyKeyValuePair p = (MyKeyValuePair)cbEntities.SelectedItem;
            AccessLimitationEntityElementsTwoListControl.Parameters.Clear();
            AccessLimitationEntityElementsTwoListControl.Parameters.Add(new KeyValuePair<string, object>("entityID", p.Pair.Key));
            AccessLimitationEntityElementsTwoListControl.SelectedListParamValue = LimitationID;
            using (ActionsTableAdapter adapter = new ActionsTableAdapter())
            {
                object allValues = adapter.LimitationEntityAllValuesSelect(p.Pair.Key, LimitationID);
                cbAllValues.Checked = (allValues == null) ? false : (bool)allValues;
            }
        }

        #endregion

    }
}
