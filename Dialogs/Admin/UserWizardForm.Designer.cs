namespace WMSOffice.Dialogs.Admin
{
    partial class UserWizardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.wizard = new UtilityLibrary.Wizards.WizardForm();
            this.wizardPageUserProperties = new UtilityLibrary.Wizards.WizardPageBase();
            this.bUserSearch = new System.Windows.Forms.Button();
            this.tbUserDepartment = new System.Windows.Forms.TextBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.tbUserPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.tbUserFIO = new System.Windows.Forms.TextBox();
            this.lblFIO = new System.Windows.Forms.Label();
            this.tbUserCardID = new System.Windows.Forms.TextBox();
            this.lblCard = new System.Windows.Forms.Label();
            this.tbUserID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.tbUserLogin = new System.Windows.Forms.TextBox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.wizardPageUserRoles = new UtilityLibrary.Wizards.WizardPageBase();
            this.bShowRoleList = new System.Windows.Forms.Button();
            this.RolesTwoListControl = new WMSOffice.Controls.TwoListControl();
            this.wizardPageUserEntityLimitations = new UtilityLibrary.Wizards.WizardPageBase();
            this.bShowEntityElements = new System.Windows.Forms.Button();
            this.bShowEntityList = new System.Windows.Forms.Button();
            this.cbLimit = new System.Windows.Forms.CheckBox();
            this.lblEntity = new System.Windows.Forms.Label();
            this.UserLimitationEntityElementsTwoListControl = new WMSOffice.Controls.TwoListControl();
            this.cbAllValues = new System.Windows.Forms.CheckBox();
            this.cbEntities = new System.Windows.Forms.ComboBox();
            this.wizardPageUserResources = new UtilityLibrary.Wizards.WizardPageBase();
            this.bShowResourceList = new System.Windows.Forms.Button();
            this.UserResourcesTwoListControl = new WMSOffice.Controls.TwoListControl();
            this.wizardFinalPage = new UtilityLibrary.Wizards.WizardFinalPage();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.wizardPageUserProperties.SuspendLayout();
            this.wizardPageUserRoles.SuspendLayout();
            this.wizardPageUserEntityLimitations.SuspendLayout();
            this.wizardPageUserResources.SuspendLayout();
            this.SuspendLayout();
            // 
            // wizard
            // 
            this.wizard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizard.Location = new System.Drawing.Point(0, 0);
            this.wizard.Name = "wizard";
            this.wizard.PageIndex = 3;
            this.wizard.Pages.AddRange(new UtilityLibrary.Wizards.WizardPageBase[] {
            this.wizardPageUserProperties,
            this.wizardPageUserRoles,
            this.wizardPageUserEntityLimitations,
            this.wizardPageUserResources,
            this.wizardFinalPage});
            this.wizard.ShowCancelConfirm = false;
            this.wizard.Size = new System.Drawing.Size(494, 374);
            this.wizard.TabIndex = 0;
            this.wizard.WizardClosed += new System.EventHandler(this.wizard_WizardClosed);
            this.wizard.Next += new UtilityLibrary.Wizards.WizardForm.WizardNextEventHandler(this.wizard_Next);
            this.wizard.PageShown += new UtilityLibrary.Wizards.WizardForm.WizardNextEventHandler(this.wizard_PageShown);
            // 
            // wizardPageUserProperties
            // 
            this.wizardPageUserProperties.Controls.Add(this.bUserSearch);
            this.wizardPageUserProperties.Controls.Add(this.tbUserDepartment);
            this.wizardPageUserProperties.Controls.Add(this.lblDepartment);
            this.wizardPageUserProperties.Controls.Add(this.tbUserPassword);
            this.wizardPageUserProperties.Controls.Add(this.lblPassword);
            this.wizardPageUserProperties.Controls.Add(this.tbUserFIO);
            this.wizardPageUserProperties.Controls.Add(this.lblFIO);
            this.wizardPageUserProperties.Controls.Add(this.tbUserCardID);
            this.wizardPageUserProperties.Controls.Add(this.lblCard);
            this.wizardPageUserProperties.Controls.Add(this.tbUserID);
            this.wizardPageUserProperties.Controls.Add(this.lblID);
            this.wizardPageUserProperties.Controls.Add(this.tbUserLogin);
            this.wizardPageUserProperties.Controls.Add(this.lblLogin);
            this.wizardPageUserProperties.Description = "Шаг - Данные пользователя";
            this.wizardPageUserProperties.Index = 0;
            this.wizardPageUserProperties.Name = "wizardPageUserProperties";
            this.wizardPageUserProperties.Size = new System.Drawing.Size(478, 263);
            this.wizardPageUserProperties.TabIndex = 0;
            this.wizardPageUserProperties.Title = null;
            this.wizardPageUserProperties.WizardPageParent = this.wizard;
            // 
            // bUserSearch
            // 
            this.bUserSearch.Location = new System.Drawing.Point(53, 208);
            this.bUserSearch.Name = "bUserSearch";
            this.bUserSearch.Size = new System.Drawing.Size(358, 23);
            this.bUserSearch.TabIndex = 34;
            this.bUserSearch.Text = "Найти пользователя в Active Directory";
            this.bUserSearch.UseVisualStyleBackColor = true;
            this.bUserSearch.Click += new System.EventHandler(this.bUserSearch_Click);
            // 
            // tbUserDepartment
            // 
            this.tbUserDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUserDepartment.Location = new System.Drawing.Point(123, 132);
            this.tbUserDepartment.MaxLength = 50;
            this.tbUserDepartment.Name = "tbUserDepartment";
            this.tbUserDepartment.Size = new System.Drawing.Size(288, 20);
            this.tbUserDepartment.TabIndex = 42;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(50, 135);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(41, 13);
            this.lblDepartment.TabIndex = 33;
            this.lblDepartment.Text = "Отдел:";
            // 
            // tbUserPassword
            // 
            this.tbUserPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUserPassword.Location = new System.Drawing.Point(123, 158);
            this.tbUserPassword.MaxLength = 50;
            this.tbUserPassword.Name = "tbUserPassword";
            this.tbUserPassword.Size = new System.Drawing.Size(288, 20);
            this.tbUserPassword.TabIndex = 43;
            this.tbUserPassword.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(50, 161);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(48, 13);
            this.lblPassword.TabIndex = 31;
            this.lblPassword.Text = "Пароль:";
            // 
            // tbUserFIO
            // 
            this.tbUserFIO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUserFIO.Location = new System.Drawing.Point(123, 80);
            this.tbUserFIO.MaxLength = 50;
            this.tbUserFIO.Name = "tbUserFIO";
            this.tbUserFIO.Size = new System.Drawing.Size(288, 20);
            this.tbUserFIO.TabIndex = 40;
            // 
            // lblFIO
            // 
            this.lblFIO.AutoSize = true;
            this.lblFIO.Location = new System.Drawing.Point(50, 83);
            this.lblFIO.Name = "lblFIO";
            this.lblFIO.Size = new System.Drawing.Size(37, 13);
            this.lblFIO.TabIndex = 29;
            this.lblFIO.Text = "ФИО:";
            // 
            // tbUserCardID
            // 
            this.tbUserCardID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUserCardID.Location = new System.Drawing.Point(123, 106);
            this.tbUserCardID.MaxLength = 25;
            this.tbUserCardID.Name = "tbUserCardID";
            this.tbUserCardID.Size = new System.Drawing.Size(288, 20);
            this.tbUserCardID.TabIndex = 41;
            // 
            // lblCard
            // 
            this.lblCard.AutoSize = true;
            this.lblCard.Location = new System.Drawing.Point(50, 109);
            this.lblCard.Name = "lblCard";
            this.lblCard.Size = new System.Drawing.Size(78, 13);
            this.lblCard.TabIndex = 27;
            this.lblCard.Text = "Код карточки:";
            // 
            // tbUserID
            // 
            this.tbUserID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUserID.Location = new System.Drawing.Point(123, 28);
            this.tbUserID.MaxLength = 9;
            this.tbUserID.Name = "tbUserID";
            this.tbUserID.Size = new System.Drawing.Size(288, 20);
            this.tbUserID.TabIndex = 44;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(50, 31);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(29, 13);
            this.lblID.TabIndex = 25;
            this.lblID.Text = "Код:";
            // 
            // tbUserLogin
            // 
            this.tbUserLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUserLogin.Location = new System.Drawing.Point(123, 54);
            this.tbUserLogin.MaxLength = 50;
            this.tbUserLogin.Name = "tbUserLogin";
            this.tbUserLogin.Size = new System.Drawing.Size(288, 20);
            this.tbUserLogin.TabIndex = 45;
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(50, 57);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(41, 13);
            this.lblLogin.TabIndex = 23;
            this.lblLogin.Text = "Логин:";
            // 
            // wizardPageUserRoles
            // 
            this.wizardPageUserRoles.Controls.Add(this.bShowRoleList);
            this.wizardPageUserRoles.Controls.Add(this.RolesTwoListControl);
            this.wizardPageUserRoles.Description = "Шаг - Добавление пользователя в роли";
            this.wizardPageUserRoles.HeaderImage = global::WMSOffice.Properties.Resources.user;
            this.wizardPageUserRoles.Index = 1;
            this.wizardPageUserRoles.Name = "wizardPageUserRoles";
            this.wizardPageUserRoles.Size = new System.Drawing.Size(478, 263);
            this.wizardPageUserRoles.TabIndex = 0;
            this.wizardPageUserRoles.Title = "";
            this.wizardPageUserRoles.WizardPageParent = this.wizard;
            // 
            // bShowRoleList
            // 
            this.bShowRoleList.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bShowRoleList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bShowRoleList.Location = new System.Drawing.Point(227, 125);
            this.bShowRoleList.Name = "bShowRoleList";
            this.bShowRoleList.Size = new System.Drawing.Size(23, 23);
            this.bShowRoleList.TabIndex = 2;
            this.bShowRoleList.Text = "...";
            this.toolTip1.SetToolTip(this.bShowRoleList, "Перейти к списку ролей");
            this.bShowRoleList.UseVisualStyleBackColor = true;
            this.bShowRoleList.Click += new System.EventHandler(this.bShowRoleList_Click);
            // 
            // RolesTwoListControl
            // 
            this.RolesTwoListControl.Caption = "Роли:";
            this.RolesTwoListControl.CaptionSelected = "Добавленные роли:";
            this.RolesTwoListControl.ColumnsList = "RoleID";
            this.RolesTwoListControl.ContextMenuItemText = "Ограничить";
            this.RolesTwoListControl.DisplayMember = "Роль";
            this.RolesTwoListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RolesTwoListControl.Filter = null;
            this.RolesTwoListControl.FormClass = "";
            this.RolesTwoListControl.GroupMember = null;
            this.RolesTwoListControl.Location = new System.Drawing.Point(0, 0);
            this.RolesTwoListControl.MaxShownItems = 0;
            this.RolesTwoListControl.Name = "RolesTwoListControl";
            this.RolesTwoListControl.PopupControlClass = null;
            this.RolesTwoListControl.SelectedListParamName = "UserID";
            this.RolesTwoListControl.SelectedListParamValue = null;
            this.RolesTwoListControl.Size = new System.Drawing.Size(478, 263);
            this.RolesTwoListControl.TabIndex = 1;
            this.RolesTwoListControl.Table = WMSOffice.Admin.Database.Table.UserRoles;
            this.RolesTwoListControl.ValueMember = "RoleID";
            this.RolesTwoListControl.OnDeleteItem += new WMSOffice.Controls.TwoListControl.TwoListEventHandler(this.RolesTwoListControl_OnDeleteItem);
            this.RolesTwoListControl.OnAddItem += new WMSOffice.Controls.TwoListControl.TwoListEventHandler(this.RolesTwoListControl_OnAddItem);
            // 
            // wizardPageUserEntityLimitations
            // 
            this.wizardPageUserEntityLimitations.Controls.Add(this.bShowEntityElements);
            this.wizardPageUserEntityLimitations.Controls.Add(this.bShowEntityList);
            this.wizardPageUserEntityLimitations.Controls.Add(this.cbLimit);
            this.wizardPageUserEntityLimitations.Controls.Add(this.lblEntity);
            this.wizardPageUserEntityLimitations.Controls.Add(this.UserLimitationEntityElementsTwoListControl);
            this.wizardPageUserEntityLimitations.Controls.Add(this.cbAllValues);
            this.wizardPageUserEntityLimitations.Controls.Add(this.cbEntities);
            this.wizardPageUserEntityLimitations.Description = "Шаг - Ограничения сущностей для пользователя";
            this.wizardPageUserEntityLimitations.HeaderImage = global::WMSOffice.Properties.Resources.user;
            this.wizardPageUserEntityLimitations.Index = 2;
            this.wizardPageUserEntityLimitations.Name = "wizardPageUserEntityLimitations";
            this.wizardPageUserEntityLimitations.Size = new System.Drawing.Size(478, 263);
            this.wizardPageUserEntityLimitations.TabIndex = 0;
            this.wizardPageUserEntityLimitations.Title = null;
            this.wizardPageUserEntityLimitations.WizardPageParent = this.wizard;
            // 
            // bShowEntityElements
            // 
            this.bShowEntityElements.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bShowEntityElements.Enabled = false;
            this.bShowEntityElements.Location = new System.Drawing.Point(227, 148);
            this.bShowEntityElements.Name = "bShowEntityElements";
            this.bShowEntityElements.Size = new System.Drawing.Size(23, 23);
            this.bShowEntityElements.TabIndex = 8;
            this.bShowEntityElements.Text = "...";
            this.toolTip1.SetToolTip(this.bShowEntityElements, "Установить атрибуты");
            this.bShowEntityElements.UseVisualStyleBackColor = true;
            this.bShowEntityElements.Visible = false;
            this.bShowEntityElements.Click += new System.EventHandler(this.bShowEntityElements_Click);
            // 
            // bShowEntityList
            // 
            this.bShowEntityList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bShowEntityList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bShowEntityList.Location = new System.Drawing.Point(290, -1);
            this.bShowEntityList.Name = "bShowEntityList";
            this.bShowEntityList.Size = new System.Drawing.Size(23, 23);
            this.bShowEntityList.TabIndex = 7;
            this.bShowEntityList.Text = "...";
            this.toolTip1.SetToolTip(this.bShowEntityList, "Перейти к списку сущностей");
            this.bShowEntityList.UseVisualStyleBackColor = true;
            this.bShowEntityList.Click += new System.EventHandler(this.bShowEntityList_Click);
            // 
            // cbLimit
            // 
            this.cbLimit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbLimit.AutoSize = true;
            this.cbLimit.Enabled = false;
            this.cbLimit.Location = new System.Drawing.Point(320, 3);
            this.cbLimit.Name = "cbLimit";
            this.cbLimit.Size = new System.Drawing.Size(83, 17);
            this.cbLimit.TabIndex = 6;
            this.cbLimit.Text = "ограничить";
            this.cbLimit.UseVisualStyleBackColor = true;
            this.cbLimit.CheckedChanged += new System.EventHandler(this.cbLimit_CheckedChanged);
            // 
            // lblEntity
            // 
            this.lblEntity.AutoSize = true;
            this.lblEntity.Location = new System.Drawing.Point(4, 3);
            this.lblEntity.Name = "lblEntity";
            this.lblEntity.Size = new System.Drawing.Size(60, 13);
            this.lblEntity.TabIndex = 3;
            this.lblEntity.Text = "Сущность:";
            // 
            // UserLimitationEntityElementsTwoListControl
            // 
            this.UserLimitationEntityElementsTwoListControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.UserLimitationEntityElementsTwoListControl.Caption = "Элементы сущности:";
            this.UserLimitationEntityElementsTwoListControl.CaptionSelected = "Выбранные элементы сущности:";
            this.UserLimitationEntityElementsTwoListControl.ColumnsList = null;
            this.UserLimitationEntityElementsTwoListControl.ContextMenuItemText = "Ограничить";
            this.UserLimitationEntityElementsTwoListControl.DisplayMember = "Название";
            this.UserLimitationEntityElementsTwoListControl.Filter = null;
            this.UserLimitationEntityElementsTwoListControl.FormClass = null;
            this.UserLimitationEntityElementsTwoListControl.GroupMember = null;
            this.UserLimitationEntityElementsTwoListControl.Location = new System.Drawing.Point(4, 23);
            this.UserLimitationEntityElementsTwoListControl.MaxShownItems = 0;
            this.UserLimitationEntityElementsTwoListControl.Name = "UserLimitationEntityElementsTwoListControl";
            this.UserLimitationEntityElementsTwoListControl.PopupControlClass = null;
            this.UserLimitationEntityElementsTwoListControl.SelectedListParamName = "limitationID";
            this.UserLimitationEntityElementsTwoListControl.SelectedListParamValue = null;
            this.UserLimitationEntityElementsTwoListControl.Size = new System.Drawing.Size(470, 237);
            this.UserLimitationEntityElementsTwoListControl.TabIndex = 2;
            this.UserLimitationEntityElementsTwoListControl.Table = WMSOffice.Admin.Database.Table.LimitationEntityElements;
            this.UserLimitationEntityElementsTwoListControl.ValueMember = "ID";
            this.UserLimitationEntityElementsTwoListControl.OnDeleteItem += new WMSOffice.Controls.TwoListControl.TwoListEventHandler(this.UserLimitationEntityElementsTwoListControl_OnDeleteItem);
            this.UserLimitationEntityElementsTwoListControl.OnAddItem += new WMSOffice.Controls.TwoListControl.TwoListEventHandler(this.UserLimitationEntityElementsTwoListControl_OnAddItem);
            // 
            // cbAllValues
            // 
            this.cbAllValues.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAllValues.AutoSize = true;
            this.cbAllValues.Enabled = false;
            this.cbAllValues.Location = new System.Drawing.Point(405, 3);
            this.cbAllValues.Name = "cbAllValues";
            this.cbAllValues.Size = new System.Drawing.Size(79, 17);
            this.cbAllValues.TabIndex = 1;
            this.cbAllValues.Text = "все кроме";
            this.cbAllValues.UseVisualStyleBackColor = true;
            this.cbAllValues.CheckedChanged += new System.EventHandler(this.cbAllValues_CheckedChanged);
            // 
            // cbEntities
            // 
            this.cbEntities.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbEntities.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEntities.FormattingEnabled = true;
            this.cbEntities.Location = new System.Drawing.Point(65, 0);
            this.cbEntities.Name = "cbEntities";
            this.cbEntities.Size = new System.Drawing.Size(224, 21);
            this.cbEntities.TabIndex = 0;
            this.cbEntities.SelectedIndexChanged += new System.EventHandler(this.cbEntities_SelectedIndexChanged);
            // 
            // wizardPageUserResources
            // 
            this.wizardPageUserResources.Controls.Add(this.bShowResourceList);
            this.wizardPageUserResources.Controls.Add(this.UserResourcesTwoListControl);
            this.wizardPageUserResources.Description = "Шаг - Предоставление прав доступа к ресурсам";
            this.wizardPageUserResources.HeaderImage = global::WMSOffice.Properties.Resources.user;
            this.wizardPageUserResources.Index = 3;
            this.wizardPageUserResources.Name = "wizardPageUserResources";
            this.wizardPageUserResources.Size = new System.Drawing.Size(478, 263);
            this.wizardPageUserResources.TabIndex = 0;
            this.wizardPageUserResources.Title = null;
            this.wizardPageUserResources.WizardPageParent = this.wizard;
            // 
            // bShowResourceList
            // 
            this.bShowResourceList.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bShowResourceList.Location = new System.Drawing.Point(227, 125);
            this.bShowResourceList.Name = "bShowResourceList";
            this.bShowResourceList.Size = new System.Drawing.Size(23, 23);
            this.bShowResourceList.TabIndex = 4;
            this.bShowResourceList.Text = "...";
            this.toolTip1.SetToolTip(this.bShowResourceList, "Перейти к списку ресурсов");
            this.bShowResourceList.UseVisualStyleBackColor = true;
            this.bShowResourceList.Click += new System.EventHandler(this.bShowResourceList_Click);
            // 
            // UserResourcesTwoListControl
            // 
            this.UserResourcesTwoListControl.Caption = "Ресурсы:";
            this.UserResourcesTwoListControl.CaptionSelected = "Доступные ресурсы:";
            this.UserResourcesTwoListControl.ColumnsList = "ID";
            this.UserResourcesTwoListControl.ContextMenuItemText = "Ограничить";
            this.UserResourcesTwoListControl.DisplayMember = "Ресурс";
            this.UserResourcesTwoListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserResourcesTwoListControl.Filter = null;
            this.UserResourcesTwoListControl.FormClass = "";
            this.UserResourcesTwoListControl.GroupMember = "Модуль";
            this.UserResourcesTwoListControl.Location = new System.Drawing.Point(0, 0);
            this.UserResourcesTwoListControl.MaxShownItems = 0;
            this.UserResourcesTwoListControl.Name = "UserResourcesTwoListControl";
            this.UserResourcesTwoListControl.PopupControlClass = null;
            this.UserResourcesTwoListControl.SelectedListParamName = "securityObjectID";
            this.UserResourcesTwoListControl.SelectedListParamValue = null;
            this.UserResourcesTwoListControl.Size = new System.Drawing.Size(478, 263);
            this.UserResourcesTwoListControl.TabIndex = 3;
            this.UserResourcesTwoListControl.Table = WMSOffice.Admin.Database.Table.SecurityObjectResources;
            this.UserResourcesTwoListControl.ValueMember = "ID";
            this.UserResourcesTwoListControl.OnDeleteItem += new WMSOffice.Controls.TwoListControl.TwoListEventHandler(this.UserResourcesTwoListControl_OnDeleteItem);
            this.UserResourcesTwoListControl.OnAddItem += new WMSOffice.Controls.TwoListControl.TwoListEventHandler(this.UserResourcesTwoListControl_OnAddItem);
            // 
            // wizardFinalPage
            // 
            this.wizardFinalPage.BackColor = System.Drawing.Color.White;
            this.wizardFinalPage.Description = "Все сделанные изменения сохранены в базе данных.";
            this.wizardFinalPage.Description2 = "Для завершения работы с мастером нажмите \"Готово\". Чтобы вернуться к редактирован" +
                "ию пользователя нажмите кнопку \"Назад\".";
            this.wizardFinalPage.FinishPage = true;
            this.wizardFinalPage.HeaderImage = global::WMSOffice.Properties.Resources.user;
            this.wizardFinalPage.Index = 4;
            this.wizardFinalPage.Name = "wizardFinalPage";
            this.wizardFinalPage.Size = new System.Drawing.Size(494, 327);
            this.wizardFinalPage.TabIndex = 0;
            this.wizardFinalPage.Title = "Пользователь успешно изменен!";
            this.wizardFinalPage.WelcomePage = true;
            this.wizardFinalPage.WizardPageParent = this.wizard;
            // 
            // UserWizardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 374);
            this.Controls.Add(this.wizard);
            this.Name = "UserWizardForm";
            this.Text = "Пользователь";
            this.wizardPageUserProperties.ResumeLayout(false);
            this.wizardPageUserProperties.PerformLayout();
            this.wizardPageUserRoles.ResumeLayout(false);
            this.wizardPageUserEntityLimitations.ResumeLayout(false);
            this.wizardPageUserEntityLimitations.PerformLayout();
            this.wizardPageUserResources.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UtilityLibrary.Wizards.WizardForm wizard;
        private UtilityLibrary.Wizards.WizardPageBase wizardPageUserRoles;
        private WMSOffice.Controls.TwoListControl RolesTwoListControl;
        private UtilityLibrary.Wizards.WizardFinalPage wizardFinalPage;
        private UtilityLibrary.Wizards.WizardPageBase wizardPageUserEntityLimitations;
        private System.Windows.Forms.ComboBox cbEntities;
        private System.Windows.Forms.CheckBox cbAllValues;
        private System.Windows.Forms.Label lblEntity;
        private WMSOffice.Controls.TwoListControl UserLimitationEntityElementsTwoListControl;
        private UtilityLibrary.Wizards.WizardPageBase wizardPageUserResources;
        private WMSOffice.Controls.TwoListControl UserResourcesTwoListControl;
        private System.Windows.Forms.CheckBox cbLimit;
        private UtilityLibrary.Wizards.WizardPageBase wizardPageUserProperties;
        private System.Windows.Forms.TextBox tbUserDepartment;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.TextBox tbUserPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox tbUserFIO;
        private System.Windows.Forms.Label lblFIO;
        private System.Windows.Forms.TextBox tbUserCardID;
        private System.Windows.Forms.Label lblCard;
        private System.Windows.Forms.TextBox tbUserID;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox tbUserLogin;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Button bUserSearch;
        private System.Windows.Forms.Button bShowEntityList;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button bShowRoleList;
        private System.Windows.Forms.Button bShowResourceList;
        private System.Windows.Forms.Button bShowEntityElements;
    }
}