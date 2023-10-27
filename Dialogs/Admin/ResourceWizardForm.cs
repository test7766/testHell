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
    public partial class ResourceWizardForm : WizardBlankForm
    {
        public ResourceWizardForm(List<string> limitationList, string resource_ID, string resource_Name, string resource_Module)
        {
            InitializeComponent();

            this.CanResize = true;
            
            ResourceID = resource_ID;
            ResourceName = resource_Name;
            MovePageBack = false;
            LimitationList = limitationList;

            cbModulesLoad();
            ResourceModuleName = resource_Module;  

            this.Text = this.wizard.Pages[0].Title = (string.IsNullOrEmpty(ResourceID)) ? "Создание ресурса" : "Редактирование ресурса";

            bShowUserList.Enabled = bShowRoleList.Enabled = bShowEntityList.Enabled = false;

            if (limitationList.Contains("user"))
                bShowUserList.Enabled = true;

            if (limitationList.Contains("role"))
                bShowRoleList.Enabled = true;

            if (limitationList.Contains("entity"))
            {
                bShowEntityList.Enabled = true;
                bShowEntityElements.Visible = true;
            }

            ResourceUsersAndRolesAccessTwoListControl.contextMenuItem.Click += new System.EventHandler(this.contextMenuItem_Click);
            ResourceLimitationEntityElementsTwoListControl.contextMenuItem.Click += new System.EventHandler(this.contextMenuItem_Click3);

            // Теперь разрешаем Bind() данных в контроле. Т.к. на этапе инициализации он вызывается несколько раз без надобности.
            ResourceUsersAndRolesAccessTwoListControl.CanBind = ResourceLimitationEntityElementsTwoListControl.CanBind = true;

            this.ResourceLimitationEntityElementsTwoListControl.MaxShownItems = 300;
        }

        #region properties

        public List<string> LimitationList { get; private set; }

        private string resourceID;
        public string ResourceID
        {
            get { return tbResourceID.Text; }
            set { tbResourceID.Text = resourceID = value; }
        }

        private string resourceName;
        public string ResourceName
        {
            get { return tbResourceName.Text; }
            set { tbResourceName.Text = resourceName = value; }
        }

        private string resourceModuleName;
        public string ResourceModuleName
        {
            get { return cbModules.SelectedText; }
            set
            { 
                if (string.IsNullOrEmpty(value))
                {
                    cbModules.SelectedIndex = -1;
                }
                else
                {
                    foreach (var item in cbModules.Items)
                    {
                        MyKeyValuePair p = (MyKeyValuePair)item;
                        if (p.Pair.Value == value)
                            cbModules.SelectedItem = item;
                    }
                }

                resourceModuleName = value;
            }
        }

        public int LimitationID {get; set;}

        /// <summary>Признак изменения свойст роли</summary>
        private bool IsResourcePropertiesChanged
        {
            get
            {
                return (tbResourceName.Text != resourceName) ||
                        (tbResourceID.Text != resourceID) ||
                        (cbModules.Text != resourceModuleName);
            }
        }

        /// <summary>Признак возврата на предыдущую страницу (при ошибке например)</summary>
        private bool MovePageBack { get; set; }

        public string SelectedEntityID { get; set; }

        #endregion

        #region EventHandlers

        private void wizard_Next(object sender, UtilityLibrary.Wizards.WizardForm.EventNextArgs e)
        {
            ApplyChanges(e.CurrentPage.Name);
        }

        /// <summary>
        /// Меняет видимость кнопки "Готово"
        /// </summary>
        private void wizard_PageShown(object sender, UtilityLibrary.Wizards.WizardForm.EventNextArgs e)
        {
            wizard.btnCancel.Visible = (e.CurrentPage.Name != wizardFinalPage.Name);
            if (MovePageBack && wizard.PageIndex > 0)
            {
                wizard.MoveBackStep();
                MovePageBack = false;
            }
        }

        private void wizard_WizardClosed(object sender, EventArgs e)
        {
            Close();
        }

        private bool ResourceUsersAndRolesAccessTwoListControl_OnAddItem(object sender, ListView.SelectedListViewItemCollection e)
        {
            try
            {
                foreach (ListViewItem item in e)
                    Database.Actions.SecurityObjectResourcesInsert(int.Parse(item.Name), ResourceID);
            }
            catch (Exception) { return false; }
            return true;
        }

        private bool ResourceUsersAndRolesAccessTwoListControl_OnDeleteItem(object sender, ListView.SelectedListViewItemCollection e)
        {
            try
            {
                foreach (ListViewItem item in e)
                    Database.Actions.SecurityObjectResourcesDelete(int.Parse(item.Name), ResourceID);
            }
            catch (Exception) { return false; }
            return true;
        }

        private bool ResourceLimitationEntityElementsTwoListControl_OnAddItem(object sender, ListView.SelectedListViewItemCollection e)
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

        private bool ResourceLimitationEntityElementsTwoListControl_OnDeleteItem(object sender, ListView.SelectedListViewItemCollection e)
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
                    cbLimit.Checked = ResourceLimitationEntityElementsTwoListControl.Enabled = cbAllValues.Enabled = (entityLimitationID == null) ? false : true;
                    cbLimit.CheckedChanged += new System.EventHandler(this.cbLimit_CheckedChanged);
                }

                if (cbLimit.Checked)
                {
                    LoadEntityElements();
                }
                else
                {
                    ResourceLimitationEntityElementsTwoListControl.Clear();
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

                    ResourceLimitationEntityElementsTwoListControl.Clear();
                    cbAllValues.CheckedChanged -= new System.EventHandler(this.cbAllValues_CheckedChanged);
                    cbAllValues.Checked = false;
                    cbAllValues.CheckedChanged += new System.EventHandler(this.cbAllValues_CheckedChanged);
                    cbEntities.SelectedIndexChanged -= new System.EventHandler(this.cbEntities_SelectedIndexChanged);
                    LoadEntities();
                    cbEntities.SelectedIndexChanged += new System.EventHandler(this.cbEntities_SelectedIndexChanged);
                }
                ResourceLimitationEntityElementsTwoListControl.Enabled = cbAllValues.Enabled = cbLimit.Checked;
            }
        }

        private void bShowEntityList_Click(object sender, EventArgs e)
        {
            EntityForm form = new EntityForm(LimitationList);
            form.ShowDialog(this);
        }

        private void bShowUserList_Click(object sender, EventArgs e)
        {
            UserForm form = new UserForm(LimitationList);
            form.ShowDialog(this);
        }

        private void bShowRoleList_Click(object sender, EventArgs e)
        {
            RoleForm form = new RoleForm(LimitationList);
            form.ShowDialog(this);
        }

        /// <summary>Ограничение доступа на ресурс</summary>
        private void contextMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int accessID = (int)Database.Actions.GetAccessID(int.Parse(ResourceUsersAndRolesAccessTwoListControl.ListView2SelectedItemKey), resourceID);
                int limitation_ID = (int)Database.Actions.LimitationIDSelect("ACCESS", accessID.ToString());
                string description = (string)Database.Actions.AccessDescription(int.Parse(ResourceUsersAndRolesAccessTwoListControl.ListView2SelectedItemKey), resourceID);
                LimitationForm form = new LimitationForm(LimitationList, (int)limitation_ID, description, 8 /*access*/);
                form.ShowDialog(this);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>Ограничение атрибутами</summary>
        private void contextMenuItem_Click3(object sender, EventArgs e)
        {
            try
            {
                MyKeyValuePair p = (MyKeyValuePair)cbEntities.SelectedItem;
                int entityLimitationDetailID = (int)Database.Actions.GetEntityLimitationDetailID(LimitationID , p.Pair.Key, ResourceLimitationEntityElementsTwoListControl.ListView2SelectedItemKey);
                int limitation_ID = (int)Database.Actions.LimitationIDSelect("ATTRIBUTE", entityLimitationDetailID.ToString());
                string description = "Установка атрибутов для элемента «" + ResourceLimitationEntityElementsTwoListControl.ListView2SelectedItemName + "» сущности «" + p.Pair.Value.Replace("* ", "") + "»";
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
            EntityWizardForm form = new EntityWizardForm(LimitationList, p.Pair.Key, p.Pair.Value.Replace("* ",""), (string)Database.Actions.GetEntityElementsProcedure(p.Pair.Key));
            form.wizard.PageIndex = 1;
            form.ShowDialog(this);           
        }

        #endregion

        #region Methods

        /// <summary>Применение изменений при переходе на следующую страницу мастера</summary>
        /// <param name="pageName">Название страницы</param>
        private void ApplyChanges(string pageName)
        {
            try
            {
                switch (pageName)
                {
                    case "wizardWelcomePageResource":
                        // создаем/обновляем данные
                        if (string.IsNullOrEmpty(resourceID))
                        {
                            if (!string.IsNullOrEmpty(ResourceID))
                            {
                                if (cbModules.SelectedIndex >= 0)
                                {
                                    // добавляем ресурс                        
                                    MyKeyValuePair p = (MyKeyValuePair)cbModules.SelectedItem;
                                    Database.Actions.ResourceInsert(tbResourceID.Text, tbResourceName.Text, p.Pair.Key);
                                    ResourceID = tbResourceID.Text;
                                    ResourceName = tbResourceName.Text;
                                    ResourceModuleName = cbModules.Text;
                                }
                                else
                                    throw new Exception("Модуль не указан!");
                            }
                            else
                                throw new Exception("ID ресурса не задано!");
                        }
                        else if (IsResourcePropertiesChanged)
                        {
                            if (!string.IsNullOrEmpty(ResourceID))
                            {
                                if (cbModules.SelectedIndex >= 0)
                                {
                                    // добавляем ресурс                        
                                    MyKeyValuePair p = (MyKeyValuePair)cbModules.SelectedItem;
                                    Database.Actions.ResourceUpdate(tbResourceID.Text, tbResourceName.Text, p.Pair.Key, resourceID);
                                    ResourceID = tbResourceID.Text;
                                    ResourceName = tbResourceName.Text;
                                    ResourceModuleName = cbModules.Text;
                                }
                                else
                                    throw new Exception("Модуль не указан!");
                            }
                            else
                                throw new Exception("ID ресурса не задано!");
                        }
                        // отображаем название ресурса в заголовке
                        this.Text = String.Format("Ресурс - {0}", ResourceName);
                        ResourceUsersAndRolesAccessTwoListControl.SelectedListParamValue = ResourceID;
                        break;
                    case "wizardPageResourceRolesAndUsersAccess":
                        // Получаем LimitationID или создается, если не было
                        using (ActionsTableAdapter adapter = new ActionsTableAdapter())
                        {
                            object limitationID = adapter.LimitationIDSelect("RESOURCE", ResourceID.ToString());
                            this.LimitationID = (limitationID == null) ? 0 : (int)limitationID;
                        }
                        LoadEntities();                 
                        break;
                    case "wizardPageResourceEntityLimitations":
                        break;
                    case "wizardPageResourceResources":
                        break;
                    default:
                        break;
                }
            }
            catch (SqlException ex)
            {
                if (ex.Message.StartsWith("The UPDATE statement conflicted with the REFERENCE constraint"))
                    MessageBox.Show("Невозможно изменить либо удалить, т.к. в других таблицах исползуется этот FOREIGN KEY.\n\nПолный текст ошибки:\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Во время обращения к базе данных произошла ошибка:\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MovePageBack = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MovePageBack = true;
            }
        }

        private void cbModulesLoad()
        {
            using (ModulesTableAdapter adapter = new ModulesTableAdapter())
            {
                Data.Admin.ModulesDataTable tableModules = adapter.GetData();
                MyList modules = new MyList();
                foreach (Data.Admin.ModulesRow row in tableModules.Rows)
                {
                    modules.Add(new MyKeyValuePair(new KeyValuePair<string, string>(row.ID, row.Модуль)));
                }
                cbModules.DataSource = modules;                
            }
        }

        private void LoadEntities()
        {
            cbEntities.Items.Clear();
            using (EntitiesTableAdapter adapter = new EntitiesTableAdapter())
            {
                Data.Admin.EntitiesDataTable tableEntities = adapter.GetData(4);
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
            ResourceLimitationEntityElementsTwoListControl.Parameters.Clear();
            ResourceLimitationEntityElementsTwoListControl.Parameters.Add(new KeyValuePair<string, object>("entityID", p.Pair.Key));
            ResourceLimitationEntityElementsTwoListControl.SelectedListParamValue = LimitationID;
            using (ActionsTableAdapter adapter = new ActionsTableAdapter())
            {
                object allValues = adapter.LimitationEntityAllValuesSelect(p.Pair.Key, LimitationID);
                cbAllValues.Checked = (allValues == null) ? false : (bool)allValues;
            }
        }

        #endregion

    }
}
