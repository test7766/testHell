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
    public partial class RoleWizardForm : WizardBlankForm
    {
        public RoleWizardForm(List<string> limitationList, int role_ID, string role_Name)
        {
            InitializeComponent();

            this.CanResize = true;
            
            RoleID = role_ID;
            tbRoleID.Text = (role_ID == 0 ? (int)Database.Actions.MaxRoleID() + 10 : role_ID).ToString();
            RoleName = role_Name;
            MovePageBack = false;
            LimitationList = limitationList;
        
            this.Text = this.wizard.Pages[0].Title = (RoleID > 0) ? "Редактирование роли" : "Создание роли";

            bShowUserList.Enabled = bShowResourceList.Enabled = bShowEntityList.Enabled = false;

            if (limitationList.Contains("user"))
                bShowUserList.Enabled = true;

            if (limitationList.Contains("entity"))
            {
                bShowEntityList.Enabled = true;
                bShowEntityElements.Visible = true;
            }

            if (limitationList.Contains("resource"))
                bShowResourceList.Enabled = true;

            UsersTwoListControl.contextMenuItem.Click += new System.EventHandler(this.contextMenuItem_Click);
            RoleResourcesTwoListControl.contextMenuItem.Click += new System.EventHandler(this.contextMenuItem_Click2);
            RoleLimitationEntityElementsTwoListControl.contextMenuItem.Click += new System.EventHandler(this.contextMenuItem_Click3);

            // Теперь разрешаем Bind() данных в контроле. Т.к. на этапе инициализации он вызывается несколько раз без надобности.
            UsersTwoListControl.CanBind = RoleResourcesTwoListControl.CanBind = RoleLimitationEntityElementsTwoListControl.CanBind = true;

            this.RoleLimitationEntityElementsTwoListControl.MaxShownItems = 300;
        }

        #region properties

        public List<string> LimitationList { get; private set; }

        private int roleID;
        public int RoleID
        {
            get
            {
                int num;
                if (!int.TryParse(tbRoleID.Text, out num))
                    return 0;
                return num;
            }
            set { tbRoleID.Text = value.ToString(); roleID = value; }
        }

        private string roleName;
        public string RoleName
        {
            get { return tbRoleName.Text; }
            set { tbRoleName.Text = roleName = value; }
        }

        public int LimitationID {get; set;}

        /// <summary>Признак изменения свойст роли</summary>
        private bool IsRolePropertiesChanged
        {
            get
            {
                return (tbRoleName.Text != roleName) ||
                        (tbRoleID.Text != roleID.ToString());
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

        private bool UsersTwoListControl_OnAddItem(object sender, ListView.SelectedListViewItemCollection e)
        {
            try
            {
                foreach (ListViewItem item in e)
                    Database.Actions.RoleUserInsert(RoleID, int.Parse(item.Name));
            }
            catch (Exception) { return false; }
            return true;
        }

        private bool UsersTwoListControl_OnDeleteItem(object sender, ListView.SelectedListViewItemCollection e)
        {
            try
            {
                foreach (ListViewItem item in e)
                    Database.Actions.RoleUserDelete(RoleID, int.Parse(item.Name));
            }
            catch (Exception) { return false; }
            return true;
        }

        private bool RoleLimitationEntityElementsTwoListControl_OnAddItem(object sender, ListView.SelectedListViewItemCollection e)
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

        private bool RoleLimitationEntityElementsTwoListControl_OnDeleteItem(object sender, ListView.SelectedListViewItemCollection e)
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
                    cbLimit.Checked = RoleLimitationEntityElementsTwoListControl.Enabled = cbAllValues.Enabled = (entityLimitationID == null) ? false : true;
                    cbLimit.CheckedChanged += new System.EventHandler(this.cbLimit_CheckedChanged);
                }

                if (cbLimit.Checked)
                {
                    LoadEntityElements();
                }
                else
                {
                    RoleLimitationEntityElementsTwoListControl.Clear();
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

        private bool RoleResourcesTwoListControl_OnAddItem(object sender, ListView.SelectedListViewItemCollection e)
        {
            try
            {
                foreach (ListViewItem item in e)
                    Database.Actions.SecurityObjectResourcesInsert(RoleID, item.Name);
            }
            catch (Exception) { return false; }
            return true;
        }

        private bool RoleResourcesTwoListControl_OnDeleteItem(object sender, ListView.SelectedListViewItemCollection e)
        {
            try
            {
                foreach (ListViewItem item in e)
                    Database.Actions.SecurityObjectResourcesDelete(RoleID, item.Name);
            }
            catch (Exception) { return false; }
            return true;
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

                    RoleLimitationEntityElementsTwoListControl.Clear();
                    cbAllValues.CheckedChanged -= new System.EventHandler(this.cbAllValues_CheckedChanged);
                    cbAllValues.Checked = false;
                    cbAllValues.CheckedChanged += new System.EventHandler(this.cbAllValues_CheckedChanged);
                    cbEntities.SelectedIndexChanged -= new System.EventHandler(this.cbEntities_SelectedIndexChanged);
                    LoadEntities();
                    cbEntities.SelectedIndexChanged += new System.EventHandler(this.cbEntities_SelectedIndexChanged);
                }
                RoleLimitationEntityElementsTwoListControl.Enabled = cbAllValues.Enabled = cbLimit.Checked;
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

        private void bShowResourceList_Click(object sender, EventArgs e)
        {
            ResourceForm form = new ResourceForm(LimitationList);
            form.ShowDialog(this);
        }

        /// <summary>Ограничение доступа пользователя в роли</summary>
        private void contextMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int relationID = (int)Database.Actions.GetRelationID(roleID, int.Parse(UsersTwoListControl.ListView2SelectedItemKey));
                object limitation_ID = Database.Actions.LimitationIDSelect("RELATION", relationID.ToString());
                string description = "Ограничение доступа пользователя «" + UsersTwoListControl.ListView2SelectedItemName + "» в роли «" + roleName + "»";
                LimitationForm form = new LimitationForm(LimitationList, (int)limitation_ID, description, 16 /*relation*/);
                form.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>Ограничение доступа на ресурс</summary>
        private void contextMenuItem_Click2(object sender, EventArgs e)
        {
            try
            {
                int accessID = (int)Database.Actions.GetAccessID(roleID, RoleResourcesTwoListControl.ListView2SelectedItemKey);
                int limitation_ID = (int)Database.Actions.LimitationIDSelect("ACCESS", accessID.ToString());
                string description = (string)Database.Actions.AccessDescription(roleID , RoleResourcesTwoListControl.ListView2SelectedItemKey);
                LimitationForm form = new LimitationForm(LimitationList, limitation_ID, description, 8 /*access*/);
                form.ShowDialog(this);
            }
            catch (Exception ex)
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
                int entityLimitationDetailID = (int)Database.Actions.GetEntityLimitationDetailID(LimitationID, p.Pair.Key, RoleLimitationEntityElementsTwoListControl.ListView2SelectedItemKey);
                int limitation_ID = (int)Database.Actions.LimitationIDSelect("ATTRIBUTE", entityLimitationDetailID.ToString());
                string description = "Установка атрибутов для элемента «" + RoleLimitationEntityElementsTwoListControl.ListView2SelectedItemName + "» сущности «" + p.Pair.Value.Replace("* ","") + "»";
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

        /// <summary>Применение изменений при переходе на следующую страницу мастера</summary>
        /// <param name="pageName">Название страницы</param>
        private void ApplyChanges(string pageName)
        {
            try
            {
                switch (pageName)
                {
                    case "wizardWelcomePageRole":
                        // создаем/обновляем данные
                        if (roleID == 0)
                        {
                            int newRoleID = 0;
                            if (int.TryParse(tbRoleID.Text, out newRoleID) && newRoleID > 0 && newRoleID < 15000)
                            {
                                // добавляем роль                        
                                Database.Actions.RoleInsert(newRoleID, tbRoleName.Text);
                                RoleID = newRoleID;
                                RoleName = tbRoleName.Text;
                            }
                            else
                                throw new Exception("ID роли должно быть целое число больше 0 и менее 15000!");
                        }
                        else if (IsRolePropertiesChanged)
                        {
                            int newRoleID = 0;
                            if (int.TryParse(tbRoleID.Text, out newRoleID) && newRoleID > 0 && newRoleID < 15000)
                            {
                                // изменяем роль                        
                                Database.Actions.RoleUpdate(newRoleID, tbRoleName.Text, roleID);
                                RoleID = newRoleID;
                                RoleName = tbRoleName.Text;
                            }
                            else
                                throw new Exception("ID роли должно быть целое число больше 0 и менее 15000!");
                        }
                        // отображаем название роли в заголовке
                        this.Text = String.Format("Роль - {0}", RoleName);
                        UsersTwoListControl.SelectedListParamValue = RoleID;
                        break;
                    case "wizardPageRoleUsers":
                        // Получаем LimitationID или создается, если не было
                        using (ActionsTableAdapter adapter = new ActionsTableAdapter())
                        {
                            object limitationID = adapter.LimitationIDSelect("ROLE", RoleID.ToString());
                            this.LimitationID = (limitationID == null) ? 0 : (int)limitationID;
                        }
                        LoadEntities();                        
                        break;
                    case "wizardPageRoleEntityLimitations":
                        RoleResourcesTwoListControl.SelectedListParamValue = RoleID;
                        break;
                    case "wizardPageRoleResources":
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

        private void LoadEntities()
        {
            cbEntities.Items.Clear();
            using (EntitiesTableAdapter adapter = new EntitiesTableAdapter())
            {
                Data.Admin.EntitiesDataTable tableEntities = adapter.GetData(2);
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
            RoleLimitationEntityElementsTwoListControl.Parameters.Clear();
            RoleLimitationEntityElementsTwoListControl.Parameters.Add(new KeyValuePair<string, object>("entityID", p.Pair.Key));
            RoleLimitationEntityElementsTwoListControl.SelectedListParamValue = LimitationID;
            using (ActionsTableAdapter adapter = new ActionsTableAdapter())
            {
                object allValues = adapter.LimitationEntityAllValuesSelect(p.Pair.Key, LimitationID);
                cbAllValues.Checked = (allValues == null) ? false : (bool)allValues;
            }
        }

        #endregion

    }

    /// <summary>Измененный KeyValuePair с переопределенным методом ToString</summary>
    public class MyKeyValuePair
    {
        public KeyValuePair<string, string> Pair { get; set; }
        public MyKeyValuePair(KeyValuePair<string, string> pair)
        {
            this.Pair = pair;
        }
        public override string ToString()
        {
            return String.Format("{0}", Pair.Value);
        }
    }

    /// <summary>Список MyKeyValuePair</summary>
    public class MyList : List<MyKeyValuePair>
    {
        public void CopyTo(MyList entities)
        {
            foreach (MyKeyValuePair item in this)
                entities.Add(item);
        }
    }
}
