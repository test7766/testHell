namespace WMSOffice.Dialogs.Admin
{
    partial class EntityWizardForm
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
            this.wizardPageEntityProperties = new UtilityLibrary.Wizards.WizardPageBase();
            this.clbLimitations = new System.Windows.Forms.CheckedListBox();
            this.lblLimit = new System.Windows.Forms.Label();
            this.tbEntityID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.tbEntityName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.wizardPageEntityElements = new UtilityLibrary.Wizards.WizardPageBase();
            this.rbProcedure = new System.Windows.Forms.RadioButton();
            this.rbElements = new System.Windows.Forms.RadioButton();
            this.gbProcedure = new System.Windows.Forms.GroupBox();
            this.cbEntityElementsProc = new System.Windows.Forms.ComboBox();
            this.gbElements = new System.Windows.Forms.GroupBox();
            this.gvElements = new System.Windows.Forms.DataGridView();
            this.wizardPageEntityAttributes = new UtilityLibrary.Wizards.WizardPageBase();
            this.AttributesTwoListControl = new WMSOffice.Controls.TwoListControl();
            this.wizardPageEntityLimitations = new UtilityLibrary.Wizards.WizardPageBase();
            this.gvEntityLimitationsSet = new System.Windows.Forms.DataGridView();
            this.типDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.владелецDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entityLimitationsSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.admin = new WMSOffice.Data.Admin();
            this.wizardFinalPage = new UtilityLibrary.Wizards.WizardFinalPage();
            this.toolTipEntityWizard = new System.Windows.Forms.ToolTip(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.entityLimitationsSetTableAdapter = new WMSOffice.Data.AdminTableAdapters.EntityLimitationsSetTableAdapter();
            this.wizardPageEntityProperties.SuspendLayout();
            this.wizardPageEntityElements.SuspendLayout();
            this.gbProcedure.SuspendLayout();
            this.gbElements.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvElements)).BeginInit();
            this.wizardPageEntityAttributes.SuspendLayout();
            this.wizardPageEntityLimitations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvEntityLimitationsSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.entityLimitationsSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.admin)).BeginInit();
            this.SuspendLayout();
            // 
            // wizard
            // 
            this.wizard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizard.Location = new System.Drawing.Point(0, 0);
            this.wizard.Name = "wizard";
            this.wizard.PageIndex = 0;
            this.wizard.Pages.AddRange(new UtilityLibrary.Wizards.WizardPageBase[] {
            this.wizardPageEntityProperties,
            this.wizardPageEntityElements,
            this.wizardPageEntityAttributes,
            this.wizardPageEntityLimitations,
            this.wizardFinalPage});
            this.wizard.ShowCancelConfirm = false;
            this.wizard.Size = new System.Drawing.Size(494, 374);
            this.wizard.TabIndex = 0;
            this.wizard.WizardClosed += new System.EventHandler(this.wizard_WizardClosed);
            this.wizard.Next += new UtilityLibrary.Wizards.WizardForm.WizardNextEventHandler(this.wizard_Next);
            this.wizard.PageShown += new UtilityLibrary.Wizards.WizardForm.WizardNextEventHandler(this.wizard_PageShown);
            // 
            // wizardPageEntityProperties
            // 
            this.wizardPageEntityProperties.Controls.Add(this.clbLimitations);
            this.wizardPageEntityProperties.Controls.Add(this.lblLimit);
            this.wizardPageEntityProperties.Controls.Add(this.tbEntityID);
            this.wizardPageEntityProperties.Controls.Add(this.lblID);
            this.wizardPageEntityProperties.Controls.Add(this.tbEntityName);
            this.wizardPageEntityProperties.Controls.Add(this.lblName);
            this.wizardPageEntityProperties.Description = "Шаг - Свойства сущности";
            this.wizardPageEntityProperties.HeaderImage = global::WMSOffice.Properties.Resources.entity;
            this.wizardPageEntityProperties.Index = 1;
            this.wizardPageEntityProperties.Name = "wizardPageEntityProperties";
            this.wizardPageEntityProperties.Size = new System.Drawing.Size(478, 263);
            this.wizardPageEntityProperties.TabIndex = 0;
            this.wizardPageEntityProperties.Title = null;
            this.wizardPageEntityProperties.WizardPageParent = this.wizard;
            // 
            // clbLimitations
            // 
            this.clbLimitations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.clbLimitations.FormattingEnabled = true;
            this.clbLimitations.Location = new System.Drawing.Point(102, 85);
            this.clbLimitations.Name = "clbLimitations";
            this.clbLimitations.Size = new System.Drawing.Size(292, 154);
            this.clbLimitations.TabIndex = 30;
            // 
            // lblLimit
            // 
            this.lblLimit.AutoSize = true;
            this.lblLimit.Location = new System.Drawing.Point(99, 69);
            this.lblLimit.Name = "lblLimit";
            this.lblLimit.Size = new System.Drawing.Size(138, 13);
            this.lblLimit.TabIndex = 28;
            this.lblLimit.Text = "Возможные ограничения:";
            // 
            // tbEntityID
            // 
            this.tbEntityID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbEntityID.Location = new System.Drawing.Point(165, 8);
            this.tbEntityID.MaxLength = 15;
            this.tbEntityID.Name = "tbEntityID";
            this.tbEntityID.Size = new System.Drawing.Size(229, 20);
            this.tbEntityID.TabIndex = 25;
            this.toolTipEntityWizard.SetToolTip(this.tbEntityID, "Введите краткое (до 15 символов) название сущности на английском.\r\nНапример: acce" +
                    "ss_type, branch, login_type.");
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(99, 11);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(21, 13);
            this.lblID.TabIndex = 26;
            this.lblID.Text = "ID:";
            // 
            // tbEntityName
            // 
            this.tbEntityName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbEntityName.Location = new System.Drawing.Point(165, 34);
            this.tbEntityName.MaxLength = 50;
            this.tbEntityName.Name = "tbEntityName";
            this.tbEntityName.Size = new System.Drawing.Size(229, 20);
            this.tbEntityName.TabIndex = 23;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(99, 37);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(60, 13);
            this.lblName.TabIndex = 24;
            this.lblName.Text = "Название:";
            // 
            // wizardPageEntityElements
            // 
            this.wizardPageEntityElements.Controls.Add(this.rbProcedure);
            this.wizardPageEntityElements.Controls.Add(this.rbElements);
            this.wizardPageEntityElements.Controls.Add(this.gbProcedure);
            this.wizardPageEntityElements.Controls.Add(this.gbElements);
            this.wizardPageEntityElements.Description = "Шаг - Просмотр/добавление элементов сущности";
            this.wizardPageEntityElements.HeaderImage = global::WMSOffice.Properties.Resources.entity;
            this.wizardPageEntityElements.Index = 2;
            this.wizardPageEntityElements.Name = "wizardPageEntityElements";
            this.wizardPageEntityElements.Size = new System.Drawing.Size(478, 263);
            this.wizardPageEntityElements.TabIndex = 0;
            this.wizardPageEntityElements.Title = null;
            this.wizardPageEntityElements.WizardPageParent = this.wizard;
            // 
            // rbProcedure
            // 
            this.rbProcedure.AutoSize = true;
            this.rbProcedure.Location = new System.Drawing.Point(52, 11);
            this.rbProcedure.Name = "rbProcedure";
            this.rbProcedure.Size = new System.Drawing.Size(80, 17);
            this.rbProcedure.TabIndex = 0;
            this.rbProcedure.TabStop = true;
            this.rbProcedure.Text = "Процедура";
            this.rbProcedure.UseVisualStyleBackColor = true;
            this.rbProcedure.CheckedChanged += new System.EventHandler(this.rbProcedure_CheckedChanged);
            // 
            // rbElements
            // 
            this.rbElements.AutoSize = true;
            this.rbElements.Location = new System.Drawing.Point(52, 72);
            this.rbElements.Name = "rbElements";
            this.rbElements.Size = new System.Drawing.Size(77, 17);
            this.rbElements.TabIndex = 0;
            this.rbElements.TabStop = true;
            this.rbElements.Text = "Элементы";
            this.rbElements.UseVisualStyleBackColor = true;
            this.rbElements.CheckedChanged += new System.EventHandler(this.rbElements_CheckedChanged);
            // 
            // gbProcedure
            // 
            this.gbProcedure.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbProcedure.Controls.Add(this.cbEntityElementsProc);
            this.gbProcedure.Location = new System.Drawing.Point(40, 15);
            this.gbProcedure.Name = "gbProcedure";
            this.gbProcedure.Size = new System.Drawing.Size(393, 55);
            this.gbProcedure.TabIndex = 3;
            this.gbProcedure.TabStop = false;
            this.gbProcedure.Text = "                          ";
            // 
            // cbEntityElementsProc
            // 
            this.cbEntityElementsProc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbEntityElementsProc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEntityElementsProc.FormattingEnabled = true;
            this.cbEntityElementsProc.Location = new System.Drawing.Point(12, 19);
            this.cbEntityElementsProc.Name = "cbEntityElementsProc";
            this.cbEntityElementsProc.Size = new System.Drawing.Size(375, 21);
            this.cbEntityElementsProc.TabIndex = 0;
            this.cbEntityElementsProc.SelectedIndexChanged += new System.EventHandler(this.cbEntityElementsProc_SelectedIndexChanged);
            // 
            // gbElements
            // 
            this.gbElements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbElements.Controls.Add(this.gvElements);
            this.gbElements.Location = new System.Drawing.Point(40, 76);
            this.gbElements.Name = "gbElements";
            this.gbElements.Size = new System.Drawing.Size(393, 172);
            this.gbElements.TabIndex = 2;
            this.gbElements.TabStop = false;
            this.gbElements.Text = "                          ";
            // 
            // gvElements
            // 
            this.gvElements.AllowUserToResizeRows = false;
            this.gvElements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gvElements.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gvElements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvElements.Location = new System.Drawing.Point(3, 16);
            this.gvElements.MultiSelect = false;
            this.gvElements.Name = "gvElements";
            this.gvElements.RowHeadersWidth = 15;
            this.gvElements.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gvElements.Size = new System.Drawing.Size(387, 153);
            this.gvElements.TabIndex = 0;
            // 
            // wizardPageEntityAttributes
            // 
            this.wizardPageEntityAttributes.Controls.Add(this.AttributesTwoListControl);
            this.wizardPageEntityAttributes.Description = "Шаг - Атрибуты сущности (связанные сущности)";
            this.wizardPageEntityAttributes.HeaderImage = global::WMSOffice.Properties.Resources.entity;
            this.wizardPageEntityAttributes.Index = 3;
            this.wizardPageEntityAttributes.Name = "wizardPageEntityAttributes";
            this.wizardPageEntityAttributes.Size = new System.Drawing.Size(478, 263);
            this.wizardPageEntityAttributes.TabIndex = 0;
            this.wizardPageEntityAttributes.Title = "";
            this.wizardPageEntityAttributes.WizardPageParent = this.wizard;
            // 
            // AttributesTwoListControl
            // 
            this.AttributesTwoListControl.Caption = "Атрибуты:";
            this.AttributesTwoListControl.CaptionSelected = "Выбранные атрибуты:";
            this.AttributesTwoListControl.ColumnsList = null;
            this.AttributesTwoListControl.ContextMenuItemText = "";
            this.AttributesTwoListControl.DisplayMember = "Название";
            this.AttributesTwoListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AttributesTwoListControl.Filter = null;
            this.AttributesTwoListControl.FormClass = null;
            this.AttributesTwoListControl.GroupMember = null;
            this.AttributesTwoListControl.Location = new System.Drawing.Point(0, 0);
            this.AttributesTwoListControl.MaxShownItems = 0;
            this.AttributesTwoListControl.Name = "AttributesTwoListControl";
            this.AttributesTwoListControl.PopupControlClass = null;
            this.AttributesTwoListControl.SelectedListParamName = "entityID";
            this.AttributesTwoListControl.SelectedListParamValue = null;
            this.AttributesTwoListControl.Size = new System.Drawing.Size(478, 263);
            this.AttributesTwoListControl.TabIndex = 0;
            this.AttributesTwoListControl.Table = WMSOffice.Admin.Database.Table.EntityAttributes;
            this.AttributesTwoListControl.ValueMember = "ID";
            this.AttributesTwoListControl.OnDeleteItem += new WMSOffice.Controls.TwoListControl.TwoListEventHandler(this.AttributesTwoListControl_OnDeleteItem);
            this.AttributesTwoListControl.OnAddItem += new WMSOffice.Controls.TwoListControl.TwoListEventHandler(this.AttributesTwoListControl_OnAddItem);
            // 
            // wizardPageEntityLimitations
            // 
            this.wizardPageEntityLimitations.Controls.Add(this.gvEntityLimitationsSet);
            this.wizardPageEntityLimitations.Description = "Шаг - Просмотр установленных ограничений";
            this.wizardPageEntityLimitations.HeaderImage = global::WMSOffice.Properties.Resources.entity;
            this.wizardPageEntityLimitations.Index = 4;
            this.wizardPageEntityLimitations.Name = "wizardPageEntityLimitations";
            this.wizardPageEntityLimitations.Size = new System.Drawing.Size(478, 263);
            this.wizardPageEntityLimitations.TabIndex = 0;
            this.wizardPageEntityLimitations.Title = null;
            this.wizardPageEntityLimitations.WizardPageParent = this.wizard;
            // 
            // gvEntityLimitationsSet
            // 
            this.gvEntityLimitationsSet.AllowUserToAddRows = false;
            this.gvEntityLimitationsSet.AllowUserToDeleteRows = false;
            this.gvEntityLimitationsSet.AllowUserToResizeColumns = false;
            this.gvEntityLimitationsSet.AllowUserToResizeRows = false;
            this.gvEntityLimitationsSet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gvEntityLimitationsSet.AutoGenerateColumns = false;
            this.gvEntityLimitationsSet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvEntityLimitationsSet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.типDataGridViewTextBoxColumn,
            this.владелецDataGridViewTextBoxColumn});
            this.gvEntityLimitationsSet.DataSource = this.entityLimitationsSetBindingSource;
            this.gvEntityLimitationsSet.Location = new System.Drawing.Point(56, 15);
            this.gvEntityLimitationsSet.Name = "gvEntityLimitationsSet";
            this.gvEntityLimitationsSet.ReadOnly = true;
            this.gvEntityLimitationsSet.RowHeadersWidth = 15;
            this.gvEntityLimitationsSet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvEntityLimitationsSet.Size = new System.Drawing.Size(361, 234);
            this.gvEntityLimitationsSet.TabIndex = 0;
            // 
            // типDataGridViewTextBoxColumn
            // 
            this.типDataGridViewTextBoxColumn.DataPropertyName = "Тип";
            this.типDataGridViewTextBoxColumn.HeaderText = "Тип";
            this.типDataGridViewTextBoxColumn.Name = "типDataGridViewTextBoxColumn";
            this.типDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // владелецDataGridViewTextBoxColumn
            // 
            this.владелецDataGridViewTextBoxColumn.DataPropertyName = "Владелец";
            this.владелецDataGridViewTextBoxColumn.HeaderText = "Владелец";
            this.владелецDataGridViewTextBoxColumn.Name = "владелецDataGridViewTextBoxColumn";
            this.владелецDataGridViewTextBoxColumn.ReadOnly = true;
            this.владелецDataGridViewTextBoxColumn.Width = 225;
            // 
            // entityLimitationsSetBindingSource
            // 
            this.entityLimitationsSetBindingSource.DataMember = "EntityLimitationsSet";
            this.entityLimitationsSetBindingSource.DataSource = this.admin;
            // 
            // admin
            // 
            this.admin.DataSetName = "Admin";
            this.admin.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // wizardFinalPage
            // 
            this.wizardFinalPage.BackColor = System.Drawing.Color.White;
            this.wizardFinalPage.Description = "Все сделанные изменения сохранены в базе данных.";
            this.wizardFinalPage.Description2 = "Для завершения работы с мастером нажмите \"Готово\". Чтобы вернуться к редактирован" +
                "ию сущности нажмите кнопку \"Назад\".";
            this.wizardFinalPage.FinishPage = true;
            this.wizardFinalPage.HeaderImage = global::WMSOffice.Properties.Resources.entity;
            this.wizardFinalPage.Index = 5;
            this.wizardFinalPage.Name = "wizardFinalPage";
            this.wizardFinalPage.Size = new System.Drawing.Size(494, 327);
            this.wizardFinalPage.TabIndex = 0;
            this.wizardFinalPage.Title = "Сущность успешно изменена!";
            this.wizardFinalPage.WelcomePage = true;
            this.wizardFinalPage.WizardPageParent = this.wizard;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Limitation_Name";
            this.dataGridViewTextBoxColumn1.HeaderText = "Название";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 245;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Limitation_Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Limitation_Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 22;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Entity_ID";
            this.dataGridViewTextBoxColumn3.HeaderText = "Entity_ID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "Limited";
            this.dataGridViewCheckBoxColumn1.HeaderText = "Ограничения";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCheckBoxColumn1.Width = 22;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.DataPropertyName = "Limited";
            this.dataGridViewCheckBoxColumn2.HeaderText = "Limited";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.ReadOnly = true;
            // 
            // entityLimitationsSetTableAdapter
            // 
            this.entityLimitationsSetTableAdapter.ClearBeforeFill = true;
            // 
            // EntityWizardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 374);
            this.Controls.Add(this.wizard);
            this.Name = "EntityWizardForm";
            this.Text = "Сущность";
            this.wizardPageEntityProperties.ResumeLayout(false);
            this.wizardPageEntityProperties.PerformLayout();
            this.wizardPageEntityElements.ResumeLayout(false);
            this.wizardPageEntityElements.PerformLayout();
            this.gbProcedure.ResumeLayout(false);
            this.gbElements.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvElements)).EndInit();
            this.wizardPageEntityAttributes.ResumeLayout(false);
            this.wizardPageEntityLimitations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvEntityLimitationsSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.entityLimitationsSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.admin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UtilityLibrary.Wizards.WizardPageBase wizardPageEntityAttributes;
        private System.Windows.Forms.ToolTip toolTipEntityWizard;
        private UtilityLibrary.Wizards.WizardPageBase wizardPageEntityProperties;
        private System.Windows.Forms.TextBox tbEntityID;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox tbEntityName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblLimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private UtilityLibrary.Wizards.WizardPageBase wizardPageEntityElements;
        private System.Windows.Forms.ComboBox cbEntityElementsProc;
        private System.Windows.Forms.CheckedListBox clbLimitations;
        private System.Windows.Forms.GroupBox gbElements;
        private System.Windows.Forms.GroupBox gbProcedure;
        private System.Windows.Forms.RadioButton rbProcedure;
        private System.Windows.Forms.RadioButton rbElements;
        private System.Windows.Forms.DataGridView gvElements;
        private UtilityLibrary.Wizards.WizardFinalPage wizardFinalPage;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private WMSOffice.Data.Admin admin;
        private WMSOffice.Controls.TwoListControl AttributesTwoListControl;
        private UtilityLibrary.Wizards.WizardPageBase wizardPageEntityLimitations;
        private System.Windows.Forms.DataGridView gvEntityLimitationsSet;
        private System.Windows.Forms.BindingSource entityLimitationsSetBindingSource;
        private WMSOffice.Data.AdminTableAdapters.EntityLimitationsSetTableAdapter entityLimitationsSetTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn типDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn владелецDataGridViewTextBoxColumn;
        public UtilityLibrary.Wizards.WizardForm wizard;
    }
}