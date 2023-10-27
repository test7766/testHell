namespace WMSOffice.Dialogs.Admin
{
    partial class RoleWizardForm
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
            this.wizardWelcomePageRole = new UtilityLibrary.Wizards.WizardWelcomePage();
            this.tbRoleID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.tbRoleName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.wizardPageRoleUsers = new UtilityLibrary.Wizards.WizardPageBase();
            this.bShowUserList = new System.Windows.Forms.Button();
            this.UsersTwoListControl = new WMSOffice.Controls.TwoListControl();
            this.wizardPageRoleEntityLimitations = new UtilityLibrary.Wizards.WizardPageBase();
            this.bShowEntityElements = new System.Windows.Forms.Button();
            this.bShowEntityList = new System.Windows.Forms.Button();
            this.cbLimit = new System.Windows.Forms.CheckBox();
            this.lblEntity = new System.Windows.Forms.Label();
            this.RoleLimitationEntityElementsTwoListControl = new WMSOffice.Controls.TwoListControl();
            this.cbAllValues = new System.Windows.Forms.CheckBox();
            this.cbEntities = new System.Windows.Forms.ComboBox();
            this.wizardPageRoleResources = new UtilityLibrary.Wizards.WizardPageBase();
            this.bShowResourceList = new System.Windows.Forms.Button();
            this.RoleResourcesTwoListControl = new WMSOffice.Controls.TwoListControl();
            this.wizardFinalPage = new UtilityLibrary.Wizards.WizardFinalPage();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.wizardWelcomePageRole.SuspendLayout();
            this.wizardPageRoleUsers.SuspendLayout();
            this.wizardPageRoleEntityLimitations.SuspendLayout();
            this.wizardPageRoleResources.SuspendLayout();
            this.SuspendLayout();
            // 
            // wizard
            // 
            this.wizard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizard.Location = new System.Drawing.Point(0, 0);
            this.wizard.Name = "wizard";
            this.wizard.PageIndex = 2;
            this.wizard.Pages.AddRange(new UtilityLibrary.Wizards.WizardPageBase[] {
            this.wizardWelcomePageRole,
            this.wizardPageRoleUsers,
            this.wizardPageRoleEntityLimitations,
            this.wizardPageRoleResources,
            this.wizardFinalPage});
            this.wizard.ShowCancelConfirm = false;
            this.wizard.Size = new System.Drawing.Size(494, 374);
            this.wizard.TabIndex = 0;
            this.wizard.WizardClosed += new System.EventHandler(this.wizard_WizardClosed);
            this.wizard.Next += new UtilityLibrary.Wizards.WizardForm.WizardNextEventHandler(this.wizard_Next);
            this.wizard.PageShown += new UtilityLibrary.Wizards.WizardForm.WizardNextEventHandler(this.wizard_PageShown);
            // 
            // wizardWelcomePageRole
            // 
            this.wizardWelcomePageRole.BackColor = System.Drawing.Color.White;
            this.wizardWelcomePageRole.Controls.Add(this.tbRoleID);
            this.wizardWelcomePageRole.Controls.Add(this.lblID);
            this.wizardWelcomePageRole.Controls.Add(this.tbRoleName);
            this.wizardWelcomePageRole.Controls.Add(this.lblName);
            this.wizardWelcomePageRole.Description = "Все изменения, проводимые в этом мастере сразу вносятся в базу данных сайта! При " +
                "нажатии кнопки \"Далее\" будет сохранено новое название роли...";
            this.wizardWelcomePageRole.Description2 = "";
            this.wizardWelcomePageRole.HeaderImage = global::WMSOffice.Properties.Resources.role;
            this.wizardWelcomePageRole.Index = 0;
            this.wizardWelcomePageRole.Name = "wizardWelcomePageRole";
            this.wizardWelcomePageRole.Size = new System.Drawing.Size(494, 327);
            this.wizardWelcomePageRole.TabIndex = 0;
            this.wizardWelcomePageRole.Title = "Создание роли";
            this.wizardWelcomePageRole.WizardPageParent = this.wizard;
            // 
            // tbRoleID
            // 
            this.tbRoleID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRoleID.Location = new System.Drawing.Point(263, 208);
            this.tbRoleID.MaxLength = 9;
            this.tbRoleID.Name = "tbRoleID";
            this.tbRoleID.Size = new System.Drawing.Size(207, 20);
            this.tbRoleID.TabIndex = 20;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(197, 211);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(21, 13);
            this.lblID.TabIndex = 21;
            this.lblID.Text = "ID:";
            // 
            // tbRoleName
            // 
            this.tbRoleName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRoleName.Location = new System.Drawing.Point(263, 234);
            this.tbRoleName.MaxLength = 50;
            this.tbRoleName.Name = "tbRoleName";
            this.tbRoleName.Size = new System.Drawing.Size(207, 20);
            this.tbRoleName.TabIndex = 18;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(197, 237);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(60, 13);
            this.lblName.TabIndex = 19;
            this.lblName.Text = "Название:";
            // 
            // wizardPageRoleUsers
            // 
            this.wizardPageRoleUsers.Controls.Add(this.bShowUserList);
            this.wizardPageRoleUsers.Controls.Add(this.UsersTwoListControl);
            this.wizardPageRoleUsers.Description = "Шаг - Добавление пользователей в роль";
            this.wizardPageRoleUsers.HeaderImage = global::WMSOffice.Properties.Resources.role;
            this.wizardPageRoleUsers.Index = 1;
            this.wizardPageRoleUsers.Name = "wizardPageRoleUsers";
            this.wizardPageRoleUsers.Size = new System.Drawing.Size(478, 263);
            this.wizardPageRoleUsers.TabIndex = 0;
            this.wizardPageRoleUsers.Title = "";
            this.wizardPageRoleUsers.WizardPageParent = this.wizard;
            // 
            // bShowUserList
            // 
            this.bShowUserList.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bShowUserList.Location = new System.Drawing.Point(227, 125);
            this.bShowUserList.Name = "bShowUserList";
            this.bShowUserList.Size = new System.Drawing.Size(23, 23);
            this.bShowUserList.TabIndex = 2;
            this.bShowUserList.Text = "...";
            this.toolTip1.SetToolTip(this.bShowUserList, "Перейти к списку пользователей");
            this.bShowUserList.UseVisualStyleBackColor = true;
            this.bShowUserList.Click += new System.EventHandler(this.bShowUserList_Click);
            // 
            // UsersTwoListControl
            // 
            this.UsersTwoListControl.Caption = "Пользователи:";
            this.UsersTwoListControl.CaptionSelected = "Выбранные пользователи:";
            this.UsersTwoListControl.ColumnsList = "UserID";
            this.UsersTwoListControl.ContextMenuItemText = "Ограничить";
            this.UsersTwoListControl.DisplayMember = "Пользователь";
            this.UsersTwoListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UsersTwoListControl.Filter = null;
            this.UsersTwoListControl.FormClass = null;
            this.UsersTwoListControl.GroupMember = "Отдел";
            this.UsersTwoListControl.Location = new System.Drawing.Point(0, 0);
            this.UsersTwoListControl.MaxShownItems = 0;
            this.UsersTwoListControl.Name = "UsersTwoListControl";
            this.UsersTwoListControl.PopupControlClass = null;
            this.UsersTwoListControl.SelectedListParamName = "RoleID";
            this.UsersTwoListControl.SelectedListParamValue = null;
            this.UsersTwoListControl.Size = new System.Drawing.Size(478, 263);
            this.UsersTwoListControl.TabIndex = 1;
            this.UsersTwoListControl.Table = WMSOffice.Admin.Database.Table.RoleUsers;
            this.toolTip1.SetToolTip(this.UsersTwoListControl, "Перейти к списку пользователей");
            this.UsersTwoListControl.ValueMember = "UserID";
            this.UsersTwoListControl.OnDeleteItem += new WMSOffice.Controls.TwoListControl.TwoListEventHandler(this.UsersTwoListControl_OnDeleteItem);
            this.UsersTwoListControl.OnAddItem += new WMSOffice.Controls.TwoListControl.TwoListEventHandler(this.UsersTwoListControl_OnAddItem);
            // 
            // wizardPageRoleEntityLimitations
            // 
            this.wizardPageRoleEntityLimitations.Controls.Add(this.bShowEntityElements);
            this.wizardPageRoleEntityLimitations.Controls.Add(this.bShowEntityList);
            this.wizardPageRoleEntityLimitations.Controls.Add(this.cbLimit);
            this.wizardPageRoleEntityLimitations.Controls.Add(this.lblEntity);
            this.wizardPageRoleEntityLimitations.Controls.Add(this.RoleLimitationEntityElementsTwoListControl);
            this.wizardPageRoleEntityLimitations.Controls.Add(this.cbAllValues);
            this.wizardPageRoleEntityLimitations.Controls.Add(this.cbEntities);
            this.wizardPageRoleEntityLimitations.Description = "Шаг - Ограничения сущностей для роли";
            this.wizardPageRoleEntityLimitations.HeaderImage = global::WMSOffice.Properties.Resources.role;
            this.wizardPageRoleEntityLimitations.Index = 2;
            this.wizardPageRoleEntityLimitations.Name = "wizardPageRoleEntityLimitations";
            this.wizardPageRoleEntityLimitations.Size = new System.Drawing.Size(478, 263);
            this.wizardPageRoleEntityLimitations.TabIndex = 0;
            this.wizardPageRoleEntityLimitations.Title = null;
            this.wizardPageRoleEntityLimitations.WizardPageParent = this.wizard;
            // 
            // bShowEntityElements
            // 
            this.bShowEntityElements.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bShowEntityElements.Enabled = false;
            this.bShowEntityElements.Location = new System.Drawing.Point(227, 149);
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
            this.lblEntity.Location = new System.Drawing.Point(4, 4);
            this.lblEntity.Name = "lblEntity";
            this.lblEntity.Size = new System.Drawing.Size(60, 13);
            this.lblEntity.TabIndex = 3;
            this.lblEntity.Text = "Сущность:";
            // 
            // RoleLimitationEntityElementsTwoListControl
            // 
            this.RoleLimitationEntityElementsTwoListControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.RoleLimitationEntityElementsTwoListControl.Caption = "Элементы сущности:";
            this.RoleLimitationEntityElementsTwoListControl.CaptionSelected = "Выбранные элементы сущности:";
            this.RoleLimitationEntityElementsTwoListControl.ColumnsList = null;
            this.RoleLimitationEntityElementsTwoListControl.ContextMenuItemText = "Ограничить";
            this.RoleLimitationEntityElementsTwoListControl.DisplayMember = "Название";
            this.RoleLimitationEntityElementsTwoListControl.Filter = null;
            this.RoleLimitationEntityElementsTwoListControl.FormClass = null;
            this.RoleLimitationEntityElementsTwoListControl.GroupMember = null;
            this.RoleLimitationEntityElementsTwoListControl.Location = new System.Drawing.Point(4, 23);
            this.RoleLimitationEntityElementsTwoListControl.MaxShownItems = 0;
            this.RoleLimitationEntityElementsTwoListControl.Name = "RoleLimitationEntityElementsTwoListControl";
            this.RoleLimitationEntityElementsTwoListControl.PopupControlClass = null;
            this.RoleLimitationEntityElementsTwoListControl.SelectedListParamName = "limitationID";
            this.RoleLimitationEntityElementsTwoListControl.SelectedListParamValue = null;
            this.RoleLimitationEntityElementsTwoListControl.Size = new System.Drawing.Size(470, 237);
            this.RoleLimitationEntityElementsTwoListControl.TabIndex = 2;
            this.RoleLimitationEntityElementsTwoListControl.Table = WMSOffice.Admin.Database.Table.LimitationEntityElements;
            this.RoleLimitationEntityElementsTwoListControl.ValueMember = "ID";
            this.RoleLimitationEntityElementsTwoListControl.OnDeleteItem += new WMSOffice.Controls.TwoListControl.TwoListEventHandler(this.RoleLimitationEntityElementsTwoListControl_OnDeleteItem);
            this.RoleLimitationEntityElementsTwoListControl.OnAddItem += new WMSOffice.Controls.TwoListControl.TwoListEventHandler(this.RoleLimitationEntityElementsTwoListControl_OnAddItem);
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
            // wizardPageRoleResources
            // 
            this.wizardPageRoleResources.Controls.Add(this.bShowResourceList);
            this.wizardPageRoleResources.Controls.Add(this.RoleResourcesTwoListControl);
            this.wizardPageRoleResources.Description = "Шаг - Предоставление прав доступа к ресурсам";
            this.wizardPageRoleResources.HeaderImage = global::WMSOffice.Properties.Resources.role;
            this.wizardPageRoleResources.Index = 3;
            this.wizardPageRoleResources.Name = "wizardPageRoleResources";
            this.wizardPageRoleResources.Size = new System.Drawing.Size(478, 263);
            this.wizardPageRoleResources.TabIndex = 0;
            this.wizardPageRoleResources.Title = null;
            this.wizardPageRoleResources.WizardPageParent = this.wizard;
            // 
            // bShowResourceList
            // 
            this.bShowResourceList.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bShowResourceList.Location = new System.Drawing.Point(227, 125);
            this.bShowResourceList.Name = "bShowResourceList";
            this.bShowResourceList.Size = new System.Drawing.Size(23, 23);
            this.bShowResourceList.TabIndex = 3;
            this.bShowResourceList.Text = "...";
            this.toolTip1.SetToolTip(this.bShowResourceList, "Перейти к списку ресурсов");
            this.bShowResourceList.UseVisualStyleBackColor = true;
            this.bShowResourceList.Click += new System.EventHandler(this.bShowResourceList_Click);
            // 
            // RoleResourcesTwoListControl
            // 
            this.RoleResourcesTwoListControl.Caption = "Ресурсы:";
            this.RoleResourcesTwoListControl.CaptionSelected = "Доступные ресурсы:";
            this.RoleResourcesTwoListControl.ColumnsList = "ID";
            this.RoleResourcesTwoListControl.ContextMenuItemText = "Ограничить";
            this.RoleResourcesTwoListControl.DisplayMember = "Ресурс";
            this.RoleResourcesTwoListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RoleResourcesTwoListControl.Filter = null;
            this.RoleResourcesTwoListControl.FormClass = null;
            this.RoleResourcesTwoListControl.GroupMember = "Модуль";
            this.RoleResourcesTwoListControl.Location = new System.Drawing.Point(0, 0);
            this.RoleResourcesTwoListControl.MaxShownItems = 0;
            this.RoleResourcesTwoListControl.Name = "RoleResourcesTwoListControl";
            this.RoleResourcesTwoListControl.PopupControlClass = null;
            this.RoleResourcesTwoListControl.SelectedListParamName = "securityObjectID";
            this.RoleResourcesTwoListControl.SelectedListParamValue = null;
            this.RoleResourcesTwoListControl.Size = new System.Drawing.Size(478, 263);
            this.RoleResourcesTwoListControl.TabIndex = 2;
            this.RoleResourcesTwoListControl.Table = WMSOffice.Admin.Database.Table.SecurityObjectResources;
            this.RoleResourcesTwoListControl.ValueMember = "ID";
            this.RoleResourcesTwoListControl.OnDeleteItem += new WMSOffice.Controls.TwoListControl.TwoListEventHandler(this.RoleResourcesTwoListControl_OnDeleteItem);
            this.RoleResourcesTwoListControl.OnAddItem += new WMSOffice.Controls.TwoListControl.TwoListEventHandler(this.RoleResourcesTwoListControl_OnAddItem);
            // 
            // wizardFinalPage
            // 
            this.wizardFinalPage.BackColor = System.Drawing.Color.White;
            this.wizardFinalPage.Description = "Все сделанные изменения сохранены в базе данных.";
            this.wizardFinalPage.Description2 = "Для завершения работы с мастером нажмите \"Готово\". Чтобы вернуться к редактирован" +
                "ию роли нажмите кнопку \"Назад\".";
            this.wizardFinalPage.FinishPage = true;
            this.wizardFinalPage.HeaderImage = global::WMSOffice.Properties.Resources.role;
            this.wizardFinalPage.Index = 4;
            this.wizardFinalPage.Name = "wizardFinalPage";
            this.wizardFinalPage.Size = new System.Drawing.Size(494, 327);
            this.wizardFinalPage.TabIndex = 0;
            this.wizardFinalPage.Title = "Роль успешно изменена!";
            this.wizardFinalPage.WelcomePage = true;
            this.wizardFinalPage.WizardPageParent = this.wizard;
            // 
            // RoleWizardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 374);
            this.Controls.Add(this.wizard);
            this.Name = "RoleWizardForm";
            this.Text = "Роль";
            this.wizardWelcomePageRole.ResumeLayout(false);
            this.wizardWelcomePageRole.PerformLayout();
            this.wizardPageRoleUsers.ResumeLayout(false);
            this.wizardPageRoleEntityLimitations.ResumeLayout(false);
            this.wizardPageRoleEntityLimitations.PerformLayout();
            this.wizardPageRoleResources.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UtilityLibrary.Wizards.WizardForm wizard;
        private UtilityLibrary.Wizards.WizardWelcomePage wizardWelcomePageRole;
        private UtilityLibrary.Wizards.WizardPageBase wizardPageRoleUsers;
        private System.Windows.Forms.TextBox tbRoleName;
        private System.Windows.Forms.Label lblName;
        private WMSOffice.Controls.TwoListControl UsersTwoListControl;
        private System.Windows.Forms.TextBox tbRoleID;
        private System.Windows.Forms.Label lblID;
        private UtilityLibrary.Wizards.WizardFinalPage wizardFinalPage;
        private UtilityLibrary.Wizards.WizardPageBase wizardPageRoleEntityLimitations;
        private System.Windows.Forms.ComboBox cbEntities;
        private System.Windows.Forms.CheckBox cbAllValues;
        private System.Windows.Forms.Label lblEntity;
        private WMSOffice.Controls.TwoListControl RoleLimitationEntityElementsTwoListControl;
        private UtilityLibrary.Wizards.WizardPageBase wizardPageRoleResources;
        private WMSOffice.Controls.TwoListControl RoleResourcesTwoListControl;
        private System.Windows.Forms.CheckBox cbLimit;
        private System.Windows.Forms.Button bShowEntityList;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button bShowUserList;
        private System.Windows.Forms.Button bShowResourceList;
        private System.Windows.Forms.Button bShowEntityElements;
    }
}