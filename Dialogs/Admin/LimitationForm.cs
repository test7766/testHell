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
    public partial class LimitationForm : WizardBlankForm
    {
        public LimitationForm(List<string> limitationList, int limitation_ID, string description, int limitType)
        {
            InitializeComponent();

            this.CanResize = true;

            LimitationID = limitation_ID;
            LimitationList = limitationList;
            LimitType = limitType;
        
            wizardPageAccessEntityLimitations.Description = description;
 
            bShowEntityList.Enabled = false;

            if (limitationList.Contains("entity"))
            {
                bShowEntityList.Enabled = true;
                bShowEntityElements.Visible = true;
            }

            LoadEntities();

            wizard.btnCancel.Visible = false;

            AccessLimitationEntityElementsTwoListControl.contextMenuItem.Click += new System.EventHandler(this.contextMenuItem_Click3);

            // Теперь разрешаем Bind() данных в контроле. Т.к. на этапе инициализации он вызывается несколько раз без надобности.
            AccessLimitationEntityElementsTwoListControl.CanBind = true;

            this.AccessLimitationEntityElementsTwoListControl.MaxShownItems = 300;
        }

        #region properties

        public List<string> LimitationList { get; private set; }

        public int LimitationID {get; set;}

        public string SelectedEntityID { get; set; }

        public int LimitType { get; set; }

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

                bShowEntityElements.Enabled = true;
            }
        }

        private void cbAllValues_CheckedChanged(object sender, EventArgs e)
        {
            MyKeyValuePair p = (MyKeyValuePair)cbEntities.SelectedItem;
            Database.Actions.LimitationEntityAllValuesUpdate(p.Pair.Key, LimitationID, cbAllValues.Checked);
        }

        private void cbLimit_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEntities.SelectedIndex >= 0)
            {
                MyKeyValuePair p = (MyKeyValuePair)cbEntities.SelectedItem;

                if (cbLimit.Checked)
                {
                    Database.Actions.EntityLimitationInsert(p.Pair.Key, LimitationID);
                    cbEntities.SelectedIndexChanged -= new System.EventHandler(this.cbEntities_SelectedIndexChanged);
                    LoadEntities();
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
                    LoadEntities();
                    cbEntities.SelectedIndexChanged += new System.EventHandler(this.cbEntities_SelectedIndexChanged);
                }
                AccessLimitationEntityElementsTwoListControl.Enabled = cbAllValues.Enabled = cbLimit.Checked;
            }
        }

        private void bShowEntityList_Click(object sender, EventArgs e)
        {
            EntityForm form = new EntityForm(LimitationList);
            form.ShowDialog(this);
        }

        /// <summary>Ограничение атрибутами</summary>
        private void contextMenuItem_Click3(object sender, EventArgs e)
        {
            try
            {
                MyKeyValuePair p = (MyKeyValuePair)cbEntities.SelectedItem;
                int entityLimitationDetailID = (int)Database.Actions.GetEntityLimitationDetailID(LimitationID, p.Pair.Key, AccessLimitationEntityElementsTwoListControl.ListView2SelectedItemKey);
                int limitation_ID = (int)Database.Actions.LimitationIDSelect("ATTRIBUTE", entityLimitationDetailID.ToString());
                string description = "Установка атрибутов для элемента «" + AccessLimitationEntityElementsTwoListControl.ListView2SelectedItemName + "» сущности «" + p.Pair.Value.Replace("* ", "") + "»";
                AttributeForm form = new AttributeForm(LimitationList, (int)limitation_ID, description, p.Pair.Key);
                form.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void LoadEntities()
        {
            cbEntities.Items.Clear();
            using (EntitiesTableAdapter adapter = new EntitiesTableAdapter())
            {
                Data.Admin.EntitiesDataTable tableEntities = adapter.GetData(LimitType);
                using (LimitationEntitiesTableAdapter adapter2 = new LimitationEntitiesTableAdapter())
                {
                    Data.Admin.LimitationEntitiesDataTable tableLimEnt = adapter2.GetData(LimitationID);

                    foreach (Data.Admin.EntitiesRow row in tableEntities.Rows)
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
