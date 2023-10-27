namespace WMSOffice.Dialogs.Admin
{
    partial class ResourceWizardForm
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
            this.wizardWelcomePageResource = new UtilityLibrary.Wizards.WizardWelcomePage();
            this.tbResourceID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.tbResourceName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.cbModules = new System.Windows.Forms.ComboBox();
            this.lblModule = new System.Windows.Forms.Label();
            this.wizardPageResourceRolesAndUsersAccess = new UtilityLibrary.Wizards.WizardPageBase();
            this.bShowRoleList = new System.Windows.Forms.Button();
            this.bShowUserList = new System.Windows.Forms.Button();
            this.ResourceUsersAndRolesAccessTwoListControl = new WMSOffice.Controls.TwoListControl();
            this.wizardPageResourceEntityLimitations = new UtilityLibrary.Wizards.WizardPageBase();
            this.bShowEntityElements = new System.Windows.Forms.Button();
            this.bShowEntityList = new System.Windows.Forms.Button();
            this.cbLimit = new System.Windows.Forms.CheckBox();
            this.lblEntity = new System.Windows.Forms.Label();
            this.ResourceLimitationEntityElementsTwoListControl = new WMSOffice.Controls.TwoListControl();
            this.cbAllValues = new System.Windows.Forms.CheckBox();
            this.cbEntities = new System.Windows.Forms.ComboBox();
            this.wizardFinalPage = new UtilityLibrary.Wizards.WizardFinalPage();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.wizardWelcomePageResource.SuspendLayout();
            this.wizardPageResourceRolesAndUsersAccess.SuspendLayout();
            this.wizardPageResourceEntityLimitations.SuspendLayout();
            this.SuspendLayout();
            // 
            // wizard
            // 
            this.wizard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizard.Location = new System.Drawing.Point(0, 0);
            this.wizard.Name = "wizard";
            this.wizard.PageIndex = 3;
            this.wizard.Pages.AddRange(new UtilityLibrary.Wizards.WizardPageBase[] {
            this.wizardWelcomePageResource,
            this.wizardPageResourceRolesAndUsersAccess,
            this.wizardPageResourceEntityLimitations,
            this.wizardFinalPage});
            this.wizard.ShowCancelConfirm = false;
            this.wizard.Size = new System.Drawing.Size(494, 374);
            this.wizard.TabIndex = 0;
            this.wizard.WizardClosed += new System.EventHandler(this.wizard_WizardClosed);
            this.wizard.Next += new UtilityLibrary.Wizards.WizardForm.WizardNextEventHandler(this.wizard_Next);
            this.wizard.PageShown += new UtilityLibrary.Wizards.WizardForm.WizardNextEventHandler(this.wizard_PageShown);
            // 
            // wizardWelcomePageResource
            // 
            this.wizardWelcomePageResource.BackColor = System.Drawing.Color.White;
            this.wizardWelcomePageResource.Controls.Add(this.tbResourceID);
            this.wizardWelcomePageResource.Controls.Add(this.lblID);
            this.wizardWelcomePageResource.Controls.Add(this.tbResourceName);
            this.wizardWelcomePageResource.Controls.Add(this.lblName);
            this.wizardWelcomePageResource.Controls.Add(this.cbModules);
            this.wizardWelcomePageResource.Controls.Add(this.lblModule);
            this.wizardWelcomePageResource.Description = "Все изменения, проводимые в этом мастере сразу вносятся в базу данных сайта! При " +
                "нажатии кнопки \"Далее\" будет сохранено новое название ресурса...";
            this.wizardWelcomePageResource.Description2 = "";
            this.wizardWelcomePageResource.HeaderImage = global::WMSOffice.Properties.Resources.resource;
            this.wizardWelcomePageResource.Index = 0;
            this.wizardWelcomePageResource.Name = "wizardWelcomePageResource";
            this.wizardWelcomePageResource.Size = new System.Drawing.Size(494, 327);
            this.wizardWelcomePageResource.TabIndex = 0;
            this.wizardWelcomePageResource.Title = "Создание ресурса";
            this.wizardWelcomePageResource.WizardPageParent = this.wizard;
            // 
            // tbResourceID
            // 
            this.tbResourceID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbResourceID.Location = new System.Drawing.Point(263, 208);
            this.tbResourceID.MaxLength = 2;
            this.tbResourceID.Name = "tbResourceID";
            this.tbResourceID.Size = new System.Drawing.Size(207, 20);
            this.tbResourceID.TabIndex = 20;
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
            // tbResourceName
            // 
            this.tbResourceName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbResourceName.Location = new System.Drawing.Point(263, 234);
            this.tbResourceName.MaxLength = 50;
            this.tbResourceName.Name = "tbResourceName";
            this.tbResourceName.Size = new System.Drawing.Size(207, 20);
            this.tbResourceName.TabIndex = 18;
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
            // cbModules
            // 
            this.cbModules.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbModules.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModules.FormattingEnabled = true;
            this.cbModules.Location = new System.Drawing.Point(263, 260);
            this.cbModules.Name = "cbModules";
            this.cbModules.Size = new System.Drawing.Size(207, 21);
            this.cbModules.TabIndex = 22;
            // 
            // lblModule
            // 
            this.lblModule.AutoSize = true;
            this.lblModule.Location = new System.Drawing.Point(197, 263);
            this.lblModule.Name = "lblModule";
            this.lblModule.Size = new System.Drawing.Size(48, 13);
            this.lblModule.TabIndex = 23;
            this.lblModule.Text = "Модуль:";
            // 
            // wizardPageResourceRolesAndUsersAccess
            // 
            this.wizardPageResourceRolesAndUsersAccess.Controls.Add(this.bShowRoleList);
            this.wizardPageResourceRolesAndUsersAccess.Controls.Add(this.bShowUserList);
            this.wizardPageResourceRolesAndUsersAccess.Controls.Add(this.ResourceUsersAndRolesAccessTwoListControl);
            this.wizardPageResourceRolesAndUsersAccess.Description = "Шаг - Предоставление прав доступа к ресурсу";
            this.wizardPageResourceRolesAndUsersAccess.HeaderImage = global::WMSOffice.Properties.Resources.resource;
            this.wizardPageResourceRolesAndUsersAccess.Index = 1;
            this.wizardPageResourceRolesAndUsersAccess.Name = "wizardPageResourceRolesAndUsersAccess";
            this.wizardPageResourceRolesAndUsersAccess.Size = new System.Drawing.Size(478, 263);
            this.wizardPageResourceRolesAndUsersAccess.TabIndex = 0;
            this.wizardPageResourceRolesAndUsersAccess.Title = "";
            this.wizardPageResourceRolesAndUsersAccess.WizardPageParent = this.wizard;
            // 
            // bShowRoleList
            // 
            this.bShowRoleList.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bShowRoleList.BackgroundImage = global::WMSOffice.Properties.Resources.role;
            this.bShowRoleList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bShowRoleList.Location = new System.Drawing.Point(227, 125);
            this.bShowRoleList.Name = "bShowRoleList";
            this.bShowRoleList.Size = new System.Drawing.Size(23, 23);
            this.bShowRoleList.TabIndex = 3;
            this.toolTip1.SetToolTip(this.bShowRoleList, "Перейти к списку ролей");
            this.bShowRoleList.UseVisualStyleBackColor = true;
            this.bShowRoleList.Click += new System.EventHandler(this.bShowRoleList_Click);
            // 
            // bShowUserList
            // 
            this.bShowUserList.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bShowUserList.BackgroundImage = global::WMSOffice.Properties.Resources.user;
            this.bShowUserList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bShowUserList.Location = new System.Drawing.Point(227, 154);
            this.bShowUserList.Name = "bShowUserList";
            this.bShowUserList.Size = new System.Drawing.Size(23, 23);
            this.bShowUserList.TabIndex = 2;
            this.bShowUserList.Text = "...";
            this.toolTip1.SetToolTip(this.bShowUserList, "Перейти к списку пользователей");
            this.bShowUserList.UseVisualStyleBackColor = true;
            this.bShowUserList.Click += new System.EventHandler(this.bShowUserList_Click);
            // 
            // ResourceUsersAndRolesAccessTwoListControl
            // 
            this.ResourceUsersAndRolesAccessTwoListControl.Caption = "Доступ отсутствует:";
            this.ResourceUsersAndRolesAccessTwoListControl.CaptionSelected = "Доступ разрешен:";
            this.ResourceUsersAndRolesAccessTwoListControl.ColumnsList = "ID";
            this.ResourceUsersAndRolesAccessTwoListControl.ContextMenuItemText = "Ограничить";
            this.ResourceUsersAndRolesAccessTwoListControl.DisplayMember = "Обьект доступа";
            this.ResourceUsersAndRolesAccessTwoListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResourceUsersAndRolesAccessTwoListControl.Filter = null;
            this.ResourceUsersAndRolesAccessTwoListControl.FormClass = "";
            this.ResourceUsersAndRolesAccessTwoListControl.GroupMember = "Тип обьекта";
            this.ResourceUsersAndRolesAccessTwoListControl.Location = new System.Drawing.Point(0, 0);
            this.ResourceUsersAndRolesAccessTwoListControl.MaxShownItems = 0;
            this.ResourceUsersAndRolesAccessTwoListControl.Name = "ResourceUsersAndRolesAccessTwoListControl";
            this.ResourceUsersAndRolesAccessTwoListControl.PopupControlClass = null;
            this.ResourceUsersAndRolesAccessTwoListControl.SelectedListParamName = "resourceID";
            this.ResourceUsersAndRolesAccessTwoListControl.SelectedListParamValue = null;
            this.ResourceUsersAndRolesAccessTwoListControl.Size = new System.Drawing.Size(478, 263);
            this.ResourceUsersAndRolesAccessTwoListControl.TabIndex = 1;
            this.ResourceUsersAndRolesAccessTwoListControl.Table = WMSOffice.Admin.Database.Table.ResourceAccess;
            this.ResourceUsersAndRolesAccessTwoListControl.ValueMember = "ID";
            this.ResourceUsersAndRolesAccessTwoListControl.OnDeleteItem += new WMSOffice.Controls.TwoListControl.TwoListEventHandler(this.ResourceUsersAndRolesAccessTwoListControl_OnDeleteItem);
            this.ResourceUsersAndRolesAccessTwoListControl.OnAddItem += new WMSOffice.Controls.TwoListControl.TwoListEventHandler(this.ResourceUsersAndRolesAccessTwoListControl_OnAddItem);
            // 
            // wizardPageResourceEntityLimitations
            // 
            this.wizardPageResourceEntityLimitations.Controls.Add(this.bShowEntityElements);
            this.wizardPageResourceEntityLimitations.Controls.Add(this.bShowEntityList);
            this.wizardPageResourceEntityLimitations.Controls.Add(this.cbLimit);
            this.wizardPageResourceEntityLimitations.Controls.Add(this.lblEntity);
            this.wizardPageResourceEntityLimitations.Controls.Add(this.ResourceLimitationEntityElementsTwoListControl);
            this.wizardPageResourceEntityLimitations.Controls.Add(this.cbAllValues);
            this.wizardPageResourceEntityLimitations.Controls.Add(this.cbEntities);
            this.wizardPageResourceEntityLimitations.Description = "Шаг - Ограничения сущностей для ресурса";
            this.wizardPageResourceEntityLimitations.HeaderImage = global::WMSOffice.Properties.Resources.resource;
            this.wizardPageResourceEntityLimitations.Index = 2;
            this.wizardPageResourceEntityLimitations.Name = "wizardPageResourceEntityLimitations";
            this.wizardPageResourceEntityLimitations.Size = new System.Drawing.Size(478, 263);
            this.wizardPageResourceEntityLimitations.TabIndex = 0;
            this.wizardPageResourceEntityLimitations.Title = null;
            this.wizardPageResourceEntityLimitations.WizardPageParent = this.wizard;
            // 
            // bShowEntityElements
            // 
            this.bShowEntityElements.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bShowEntityElements.Enabled = false;
            this.bShowEntityElements.Location = new System.Drawing.Point(227, 149);
            this.bShowEntityElements.Name = "bShowEntityElements";
            this.bShowEntityElements.Size = new System.Drawing.Size(23, 23);
            this.bShowEntityElements.TabIndex = 7;
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
            this.bShowEntityList.TabIndex = 6;
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
            this.cbLimit.TabIndex = 5;
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
            // ResourceLimitationEntityElementsTwoListControl
            // 
            this.ResourceLimitationEntityElementsTwoListControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ResourceLimitationEntityElementsTwoListControl.Caption = "Элементы сущности:";
            this.ResourceLimitationEntityElementsTwoListControl.CaptionSelected = "Выбранные элементы сущности:";
            this.ResourceLimitationEntityElementsTwoListControl.ColumnsList = null;
            this.ResourceLimitationEntityElementsTwoListControl.ContextMenuItemText = "Ограничить";
            this.ResourceLimitationEntityElementsTwoListControl.DisplayMember = "Название";
            this.ResourceLimitationEntityElementsTwoListControl.Filter = null;
            this.ResourceLimitationEntityElementsTwoListControl.FormClass = null;
            this.ResourceLimitationEntityElementsTwoListControl.GroupMember = null;
            this.ResourceLimitationEntityElementsTwoListControl.Location = new System.Drawing.Point(4, 23);
            this.ResourceLimitationEntityElementsTwoListControl.MaxShownItems = 0;
            this.ResourceLimitationEntityElementsTwoListControl.Name = "ResourceLimitationEntityElementsTwoListControl";
            this.ResourceLimitationEntityElementsTwoListControl.PopupControlClass = null;
            this.ResourceLimitationEntityElementsTwoListControl.SelectedListParamName = "limitationID";
            this.ResourceLimitationEntityElementsTwoListControl.SelectedListParamValue = null;
            this.ResourceLimitationEntityElementsTwoListControl.Size = new System.Drawing.Size(470, 237);
            this.ResourceLimitationEntityElementsTwoListControl.TabIndex = 2;
            this.ResourceLimitationEntityElementsTwoListControl.Table = WMSOffice.Admin.Database.Table.LimitationEntityElements;
            this.ResourceLimitationEntityElementsTwoListControl.ValueMember = "ID";
            this.ResourceLimitationEntityElementsTwoListControl.OnDeleteItem += new WMSOffice.Controls.TwoListControl.TwoListEventHandler(this.ResourceLimitationEntityElementsTwoListControl_OnDeleteItem);
            this.ResourceLimitationEntityElementsTwoListControl.OnAddItem += new WMSOffice.Controls.TwoListControl.TwoListEventHandler(this.ResourceLimitationEntityElementsTwoListControl_OnAddItem);
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
            // wizardFinalPage
            // 
            this.wizardFinalPage.BackColor = System.Drawing.Color.White;
            this.wizardFinalPage.Description = "Все сделанные изменения сохранены в базе данных.";
            this.wizardFinalPage.Description2 = "Для завершения работы с мастером нажмите \"Готово\". Чтобы вернуться к редактирован" +
                "ия ресурса нажмите кнопку \"Назад\".";
            this.wizardFinalPage.FinishPage = true;
            this.wizardFinalPage.HeaderImage = global::WMSOffice.Properties.Resources.resource;
            this.wizardFinalPage.Index = 3;
            this.wizardFinalPage.Name = "wizardFinalPage";
            this.wizardFinalPage.Size = new System.Drawing.Size(494, 327);
            this.wizardFinalPage.TabIndex = 0;
            this.wizardFinalPage.Title = "Ресурс успешно изменен!";
            this.wizardFinalPage.WelcomePage = true;
            this.wizardFinalPage.WizardPageParent = this.wizard;
            // 
            // ResourceWizardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 374);
            this.Controls.Add(this.wizard);
            this.Name = "ResourceWizardForm";
            this.Text = "Ресурс";
            this.wizardWelcomePageResource.ResumeLayout(false);
            this.wizardWelcomePageResource.PerformLayout();
            this.wizardPageResourceRolesAndUsersAccess.ResumeLayout(false);
            this.wizardPageResourceEntityLimitations.ResumeLayout(false);
            this.wizardPageResourceEntityLimitations.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UtilityLibrary.Wizards.WizardForm wizard;
        private UtilityLibrary.Wizards.WizardWelcomePage wizardWelcomePageResource;
        private UtilityLibrary.Wizards.WizardPageBase wizardPageResourceRolesAndUsersAccess;
        private System.Windows.Forms.TextBox tbResourceName;
        private System.Windows.Forms.Label lblName;
        private WMSOffice.Controls.TwoListControl ResourceUsersAndRolesAccessTwoListControl;
        private System.Windows.Forms.TextBox tbResourceID;
        private System.Windows.Forms.Label lblID;
        private UtilityLibrary.Wizards.WizardFinalPage wizardFinalPage;
        private UtilityLibrary.Wizards.WizardPageBase wizardPageResourceEntityLimitations;
        private System.Windows.Forms.ComboBox cbEntities;
        private System.Windows.Forms.CheckBox cbAllValues;
        private System.Windows.Forms.Label lblEntity;
        private WMSOffice.Controls.TwoListControl ResourceLimitationEntityElementsTwoListControl;
        private System.Windows.Forms.ComboBox cbModules;
        private System.Windows.Forms.Label lblModule;
        private System.Windows.Forms.CheckBox cbLimit;
        private System.Windows.Forms.Button bShowEntityList;
        private System.Windows.Forms.Button bShowUserList;
        private System.Windows.Forms.Button bShowRoleList;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button bShowEntityElements;
    }
}