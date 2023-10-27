namespace WMSOffice.Dialogs.Admin
{
    partial class AttributeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AttributeForm));
            this.wizard = new UtilityLibrary.Wizards.WizardForm();
            this.wizardPageAccessEntityLimitations = new UtilityLibrary.Wizards.WizardPageBase();
            this.bShowEntityElements = new System.Windows.Forms.Button();
            this.bShowEntityList = new System.Windows.Forms.Button();
            this.cbLimit = new System.Windows.Forms.CheckBox();
            this.lblEntity = new System.Windows.Forms.Label();
            this.AccessLimitationEntityElementsTwoListControl = new WMSOffice.Controls.TwoListControl();
            this.cbAllValues = new System.Windows.Forms.CheckBox();
            this.cbEntities = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.wizardPageAccessEntityLimitations.SuspendLayout();
            this.SuspendLayout();
            // 
            // wizard
            // 
            this.wizard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizard.Location = new System.Drawing.Point(0, 0);
            this.wizard.Name = "wizard";
            this.wizard.PageIndex = 0;
            this.wizard.Pages.AddRange(new UtilityLibrary.Wizards.WizardPageBase[] {
            this.wizardPageAccessEntityLimitations});
            this.wizard.ShowCancelConfirm = false;
            this.wizard.Size = new System.Drawing.Size(494, 374);
            this.wizard.TabIndex = 0;
            this.wizard.WizardClosed += new System.EventHandler(this.wizard_WizardClosed);
            // 
            // wizardPageAccessEntityLimitations
            // 
            this.wizardPageAccessEntityLimitations.Controls.Add(this.bShowEntityElements);
            this.wizardPageAccessEntityLimitations.Controls.Add(this.bShowEntityList);
            this.wizardPageAccessEntityLimitations.Controls.Add(this.cbLimit);
            this.wizardPageAccessEntityLimitations.Controls.Add(this.lblEntity);
            this.wizardPageAccessEntityLimitations.Controls.Add(this.AccessLimitationEntityElementsTwoListControl);
            this.wizardPageAccessEntityLimitations.Controls.Add(this.cbAllValues);
            this.wizardPageAccessEntityLimitations.Controls.Add(this.cbEntities);
            this.wizardPageAccessEntityLimitations.Description = "";
            this.wizardPageAccessEntityLimitations.FinishPage = true;
            this.wizardPageAccessEntityLimitations.HeaderImage = ((System.Drawing.Image)(resources.GetObject("wizardPageAccessEntityLimitations.HeaderImage")));
            this.wizardPageAccessEntityLimitations.Index = 0;
            this.wizardPageAccessEntityLimitations.Name = "wizardPageAccessEntityLimitations";
            this.wizardPageAccessEntityLimitations.Size = new System.Drawing.Size(478, 263);
            this.wizardPageAccessEntityLimitations.TabIndex = 0;
            this.wizardPageAccessEntityLimitations.Title = null;
            this.wizardPageAccessEntityLimitations.WizardPageParent = this.wizard;
            // 
            // bShowEntityElements
            // 
            this.bShowEntityElements.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bShowEntityElements.Enabled = false;
            this.bShowEntityElements.Location = new System.Drawing.Point(227, 148);
            this.bShowEntityElements.Name = "bShowEntityElements";
            this.bShowEntityElements.Size = new System.Drawing.Size(23, 23);
            this.bShowEntityElements.TabIndex = 9;
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
            this.lblEntity.Size = new System.Drawing.Size(50, 13);
            this.lblEntity.TabIndex = 3;
            this.lblEntity.Text = "Атрибут:";
            // 
            // AccessLimitationEntityElementsTwoListControl
            // 
            this.AccessLimitationEntityElementsTwoListControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.AccessLimitationEntityElementsTwoListControl.Caption = "Элементы сущности:";
            this.AccessLimitationEntityElementsTwoListControl.CaptionSelected = "Выбранные элементы сущности:";
            this.AccessLimitationEntityElementsTwoListControl.ColumnsList = null;
            this.AccessLimitationEntityElementsTwoListControl.ContextMenuItemText = "";
            this.AccessLimitationEntityElementsTwoListControl.DisplayMember = "Название";
            this.AccessLimitationEntityElementsTwoListControl.Filter = null;
            this.AccessLimitationEntityElementsTwoListControl.FormClass = null;
            this.AccessLimitationEntityElementsTwoListControl.GroupMember = null;
            this.AccessLimitationEntityElementsTwoListControl.Location = new System.Drawing.Point(4, 23);
            this.AccessLimitationEntityElementsTwoListControl.MaxShownItems = 0;
            this.AccessLimitationEntityElementsTwoListControl.Name = "AccessLimitationEntityElementsTwoListControl";
            this.AccessLimitationEntityElementsTwoListControl.PopupControlClass = null;
            this.AccessLimitationEntityElementsTwoListControl.SelectedListParamName = "limitationID";
            this.AccessLimitationEntityElementsTwoListControl.SelectedListParamValue = null;
            this.AccessLimitationEntityElementsTwoListControl.Size = new System.Drawing.Size(470, 237);
            this.AccessLimitationEntityElementsTwoListControl.TabIndex = 2;
            this.AccessLimitationEntityElementsTwoListControl.Table = WMSOffice.Admin.Database.Table.LimitationEntityElements;
            this.AccessLimitationEntityElementsTwoListControl.ValueMember = "ID";
            this.AccessLimitationEntityElementsTwoListControl.OnDeleteItem += new WMSOffice.Controls.TwoListControl.TwoListEventHandler(this.AccessLimitationEntityElementsTwoListControl_OnDeleteItem);
            this.AccessLimitationEntityElementsTwoListControl.OnAddItem += new WMSOffice.Controls.TwoListControl.TwoListEventHandler(this.AccessLimitationEntityElementsTwoListControl_OnAddItem);
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
            // AttributeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 374);
            this.Controls.Add(this.wizard);
            this.Name = "AttributeForm";
            this.Text = "Установка атрибутов";
            this.wizardPageAccessEntityLimitations.ResumeLayout(false);
            this.wizardPageAccessEntityLimitations.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UtilityLibrary.Wizards.WizardForm wizard;
        private UtilityLibrary.Wizards.WizardPageBase wizardPageAccessEntityLimitations;
        private System.Windows.Forms.ComboBox cbEntities;
        private System.Windows.Forms.CheckBox cbAllValues;
        private System.Windows.Forms.Label lblEntity;
        private WMSOffice.Controls.TwoListControl AccessLimitationEntityElementsTwoListControl;
        private System.Windows.Forms.CheckBox cbLimit;
        private System.Windows.Forms.Button bShowEntityList;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button bShowEntityElements;
    }
}