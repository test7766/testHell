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
using WMSOffice.Window;

namespace WMSOffice.Dialogs.Admin
{
    public partial class UserWizardForm : WizardBlankForm
    {
        public UserWizardForm(List<string> limitationList, int user_ID, string user_FIO)
        {
            InitializeComponent();

            this.CanResize = true;

            UserID = user_ID;
            UserFIO = user_FIO;
            LimitationList = limitationList;

            if (UserID > 0)
            {
                UserInfoLoad();
                bUserSearch.Visible = false;
                tbUserID.ReadOnly = true;
            }
            MovePageBack = false;
        
            this.Text = (UserID > 0) ? "Редактирование пользователя" : "Создание пользователя";

            bShowRoleList.Enabled = bShowResourceList.Enabled = bShowEntityList.Enabled = false;

            if (limitationList.Contains("role"))
                bShowRoleList.Enabled = true;

            if (limitationList.Contains("resource"))
                bShowResourceList.Enabled = true;

            if (limitationList.Contains("entity"))
            {
                bShowEntityList.Enabled = true;
                bShowEntityElements.Visible = true;
            }

            RolesTwoListControl.contextMenuItem.Click += new System.EventHandler(this.contextMenuItem_Click);
            UserResourcesTwoListControl.contextMenuItem.Click += new System.EventHandler(this.contextMenuItem_Click2);
            UserLimitationEntityElementsTwoListControl.contextMenuItem.Click += new System.EventHandler(this.contextMenuItem_Click3);

            // Теперь разрешаем Bind() данных в контроле. Т.к. на этапе инициализации он вызывается несколько раз без надобности.
            RolesTwoListControl.CanBind = UserResourcesTwoListControl.CanBind = UserLimitationEntityElementsTwoListControl.CanBind = true;

            this.UserLimitationEntityElementsTwoListControl.MaxShownItems = 300;
        }

        #region properties

        public List<string> LimitationList { get; private set; }

        private int userID;
        public int UserID
        {
            get
            {
                int num;
                if (!int.TryParse(tbUserID.Text, out num))
                    return 0;
                return num;
            }
            set { tbUserID.Text = value.ToString(); userID = value; }
        }

        private string userFIO;
        public string UserFIO
        {
            get { return tbUserFIO.Text; }
            set { tbUserFIO.Text = userFIO = value; }
        }

        private string userLogin;
        public string UserLogin
        {
            get { return tbUserLogin.Text; }
            set { tbUserLogin.Text = userLogin = value; }
        }

        private string userDepartment;
        public string UserDepartment
        {
            get { return tbUserDepartment.Text; }
            set { tbUserDepartment.Text = userDepartment = value; }
        }

        private string userPassword;
        public string UserPassword
        {
            get { return tbUserPassword.Text; }
            set { tbUserPassword.Text = userPassword = value; }
        }

        private long userCardID;
        public long UserCardID
        {
            get 
            { 
                long cardID = 0;
                long.TryParse(tbUserCardID.Text, out cardID);
                return cardID; 
            }
            set { tbUserCardID.Text = value.ToString(); userCardID = value; }
        }

        public int LimitationID {get; set;}

        /// <summary>Признак изменения свойст роли</summary>
        private bool IsUserPropertiesChanged
        {
            get
            {
                return  (tbUserFIO.Text != userFIO) ||
                        (tbUserID.Text != userID.ToString()) ||
                        (tbUserLogin.Text != userLogin)||
                        (tbUserDepartment.Text != userDepartment) ||
                        (tbUserPassword.Text != userPassword)||
                        (tbUserCardID.Text != userCardID.ToString());
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

        private bool RolesTwoListControl_OnAddItem(object sender, ListView.SelectedListViewItemCollection e)
        {
            try
            {
                foreach (ListViewItem item in e)
                    Database.Actions.RoleUserInsert(int.Parse(item.Name), UserID);
            }
            catch (Exception) { return false; }
            return true;
        }

        private bool RolesTwoListControl_OnDeleteItem(object sender, ListView.SelectedListViewItemCollection e)
        {
            try
            {
                foreach (ListViewItem item in e)
                    Database.Actions.RoleUserDelete(int.Parse(item.Name), UserID);
            }
            catch (Exception) { return false; }
            return true;
        }

        private bool UserLimitationEntityElementsTwoListControl_OnAddItem(object sender, ListView.SelectedListViewItemCollection e)
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

        private bool UserLimitationEntityElementsTwoListControl_OnDeleteItem(object sender, ListView.SelectedListViewItemCollection e)
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
                    cbLimit.Checked = UserLimitationEntityElementsTwoListControl.Enabled = cbAllValues.Enabled = (entityLimitationID == null) ? false : true;
                    cbLimit.CheckedChanged += new System.EventHandler(this.cbLimit_CheckedChanged);
                }

                if (cbLimit.Checked)
                {
                    LoadEntityElements();
                }
                else
                {
                    UserLimitationEntityElementsTwoListControl.Clear();
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

        private bool UserResourcesTwoListControl_OnAddItem(object sender, ListView.SelectedListViewItemCollection e)
        {
            try
            {
                foreach (ListViewItem item in e)
                    Database.Actions.SecurityObjectResourcesInsert(UserID, item.Name);
            }
            catch (Exception) { return false; }
            return true;
        }

        private bool UserResourcesTwoListControl_OnDeleteItem(object sender, ListView.SelectedListViewItemCollection e)
        {
            try
            {
                foreach (ListViewItem item in e)
                    Database.Actions.SecurityObjectResourcesDelete(UserID, item.Name);
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

                    UserLimitationEntityElementsTwoListControl.Clear();
                    cbAllValues.CheckedChanged -= new System.EventHandler(this.cbAllValues_CheckedChanged);
                    cbAllValues.Checked = false;
                    cbAllValues.CheckedChanged += new System.EventHandler(this.cbAllValues_CheckedChanged);
                    cbEntities.SelectedIndexChanged -= new System.EventHandler(this.cbEntities_SelectedIndexChanged);
                    LoadEntities();
                    cbEntities.SelectedIndexChanged += new System.EventHandler(this.cbEntities_SelectedIndexChanged);
                }
                UserLimitationEntityElementsTwoListControl.Enabled = cbAllValues.Enabled = cbLimit.Checked;
            }
        }

        private void bUserSearch_Click(object sender, EventArgs e)
        {
            UserSearchForm form = new UserSearchForm(tbUserFIO.Text);
            if (form.ShowDialog() == DialogResult.OK)
            {
                tbUserID.Text = form.UserID;
                tbUserFIO.Text = form.UserFIO;
                tbUserLogin.Text = form.UserLogin;
                tbUserDepartment.Text = form.UserDepartment;
            }
        }

        private void bShowEntityList_Click(object sender, EventArgs e)
        {
            EntityForm form = new EntityForm(LimitationList);
            form.ShowDialog(this);
        }

        private void bShowRoleList_Click(object sender, EventArgs e)
        {
            RoleForm form = new RoleForm(LimitationList);
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
                int relationID = (int)Database.Actions.GetRelationID(int.Parse(RolesTwoListControl.ListView2SelectedItemKey), userID);
                object limitation_ID = Database.Actions.LimitationIDSelect("RELATION", relationID.ToString());
                string description = "Ограничение доступа пользователя «" + userFIO + "» в роли «" + RolesTwoListControl.ListView2SelectedItemName + "»";
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
                int accessID = (int)Database.Actions.GetAccessID(userID, UserResourcesTwoListControl.ListView2SelectedItemKey);
                int limitation_ID = (int)Database.Actions.LimitationIDSelect("ACCESS", accessID.ToString());
                string description = (string)Database.Actions.AccessDescription(userID, UserResourcesTwoListControl.ListView2SelectedItemKey);
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
                try
                {
                    MyKeyValuePair p = (MyKeyValuePair)cbEntities.SelectedItem;
                    int entityLimitationDetailID = (int)Database.Actions.GetEntityLimitationDetailID(LimitationID, p.Pair.Key, UserLimitationEntityElementsTwoListControl.ListView2SelectedItemKey);
                    int limitation_ID = (int)Database.Actions.LimitationIDSelect("ATTRIBUTE", entityLimitationDetailID.ToString());
                    string description = "Установка атрибутов для элемента «" + UserLimitationEntityElementsTwoListControl.ListView2SelectedItemName + "» сущности «" + p.Pair.Value.Replace("* ", "") + "»";
                    AttributeForm form = new AttributeForm(LimitationList, (int)limitation_ID, description, p.Pair.Key);
                    form.ShowDialog(this);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                    case "wizardPageUserProperties":
                        // создаем/обновляем данные
                        if (userID == 0)
                        {
                            int newUserID = 0;                            
                            if (int.TryParse(tbUserID.Text, out newUserID) && newUserID > 15000)
                            {
                                long cardID = 0;
                                if(long.TryParse(tbUserCardID.Text, out cardID) && cardID > 0)                                                      
                                    Database.Actions.UserInsert(newUserID, tbUserLogin.Text, tbUserPassword.Text, cardID, tbUserFIO.Text, tbUserDepartment.Text);
                                else
                                    Database.Actions.UserInsert(newUserID, tbUserLogin.Text, tbUserPassword.Text, null, tbUserFIO.Text, tbUserDepartment.Text);
                                UserID = newUserID;
                                UserFIO = tbUserFIO.Text;
                                userLogin = tbUserLogin.Text;
                                userDepartment = tbUserDepartment.Text;
                                userPassword = tbUserPassword.Text;
                                userCardID = cardID;                                
                            }
                            else
                                throw new Exception("Код пользователя должно быть целое число больше 15000!");
                        }
                        else if (IsUserPropertiesChanged)
                        {
                            int newUserID = 0;
                            if (int.TryParse(tbUserID.Text, out newUserID) && newUserID > 0)
                            {
                                // изменяем информацию в пользователе  
                                long cardID = 0; 
                                if (long.TryParse(tbUserCardID.Text, out cardID) && cardID > 0)
                                    Database.Actions.UserUpdate(newUserID, tbUserLogin.Text, tbUserPassword.Text, cardID, tbUserFIO.Text, tbUserDepartment.Text, userID);
                                else
                                    Database.Actions.UserUpdate(newUserID, tbUserLogin.Text, tbUserPassword.Text, null, tbUserFIO.Text, tbUserDepartment.Text, userID);
                                UserID = newUserID;
                                UserFIO = tbUserFIO.Text;
                                userLogin = tbUserLogin.Text;
                                userDepartment = tbUserDepartment.Text;
                                userPassword = tbUserPassword.Text;
                                userCardID = cardID;  
                            }
                            else
                                throw new Exception("Код пользователя должно быть целое число больше 0!");
                        }
                        // отображаем название роли в заголовке
                        this.Text = String.Format("Пользователь - {0}", UserFIO);
                        RolesTwoListControl.SelectedListParamValue = UserID;
                        break;
                    case "wizardPageUserRoles":
                        // Получаем LimitationID или создается, если не было
                        using (ActionsTableAdapter adapter = new ActionsTableAdapter())
                        {
                            object limitationID = adapter.LimitationIDSelect("USER", UserID.ToString());
                            this.LimitationID = (limitationID == null) ? 0 : (int)limitationID;
                        }
                        LoadEntities();
                        break;
                    case "wizardPageUserEntityLimitations":
                        UserResourcesTwoListControl.SelectedListParamValue = UserID;
                        break;
                    case "wizardPageUserResources":
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
                Data.Admin.EntitiesDataTable tableEntities = adapter.GetData(1);
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
            UserLimitationEntityElementsTwoListControl.Parameters.Clear();
            UserLimitationEntityElementsTwoListControl.Parameters.Add(new KeyValuePair<string, object>("entityID", p.Pair.Key));
            UserLimitationEntityElementsTwoListControl.SelectedListParamValue = LimitationID;
            using (ActionsTableAdapter adapter = new ActionsTableAdapter())
            {
                object allValues = adapter.LimitationEntityAllValuesSelect(p.Pair.Key, LimitationID);
                cbAllValues.Checked = (allValues == null) ? false : (bool)allValues;
            }
        }

        private void UserInfoLoad()
        {
            using (UserInfoTableAdapter adapter = new UserInfoTableAdapter())
            {
                Data.Admin.UserInfoDataTable tableUserInfo = adapter.GetData(UserID);
                foreach (Data.Admin.UserInfoRow row in tableUserInfo.Rows)
                {
                    tbUserFIO.Text = row.ФИО;
                    tbUserLogin.Text = row.Логин;
                    tbUserDepartment.Text = row.Отдел;
                    tbUserPassword.Text = row.Пароль;
                    tbUserCardID.Text = (row.Код_карточки == 0)? null : row.Код_карточки.ToString();
                    break;
                }
            }
        }

        #endregion

    }

}
