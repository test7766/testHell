namespace WMSOffice.Dialogs.Receive
{
    partial class MeasurementWizardForm
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
            this.wizard = new UtilityLibrary.Wizards.WizardForm();
            this.wizardWelcomePage = new UtilityLibrary.Wizards.WizardWelcomePage();
            this.wizardItemSearchPage = new UtilityLibrary.Wizards.WizardPageBase();
            this.itemMeasurementSearchControl = new WMSOffice.Controls.Receive.Measurement.ItemMeasurementSearchControl();
            this.wizardItemMeasurementPage = new UtilityLibrary.Wizards.WizardPageBase();
            this.itemMeasurementControl = new WMSOffice.Controls.Receive.Measurement.ItemMeasurementControl();
            this.wizardItemPhotoPage = new UtilityLibrary.Wizards.WizardPageBase();
            this.itemPhotoControl = new WMSOffice.Controls.Receive.Measurement.ItemPhotoControl();
            this.wizardBunchMeasurementPage = new UtilityLibrary.Wizards.WizardPageBase();
            this.bunchMeasurementControl = new WMSOffice.Controls.Receive.Measurement.BunchMeasurementControl();
            this.wizardBoxMeasurementPage = new UtilityLibrary.Wizards.WizardPageBase();
            this.boxMeasurementControl = new WMSOffice.Controls.Receive.Measurement.BoxMeasurementControl();
            this.wizardPalletMeasurementPage = new UtilityLibrary.Wizards.WizardPageBase();
            this.palletMeasurementControl = new WMSOffice.Controls.Receive.Measurement.PalletMeasurementControl();
            this.wizardItemComfirmationPage = new UtilityLibrary.Wizards.WizardPageBase();
            this.itemMeasurementConfirmationControl = new WMSOffice.Controls.Receive.Measurement.ItemMeasurementSearchControl();
            this.wizardFinalPage = new UtilityLibrary.Wizards.WizardFinalPage();
            this.wizardItemSearchPage.SuspendLayout();
            this.wizardItemMeasurementPage.SuspendLayout();
            this.wizardItemPhotoPage.SuspendLayout();
            this.wizardBunchMeasurementPage.SuspendLayout();
            this.wizardBoxMeasurementPage.SuspendLayout();
            this.wizardPalletMeasurementPage.SuspendLayout();
            this.wizardItemComfirmationPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // wizard
            // 
            this.wizard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizard.Location = new System.Drawing.Point(0, 0);
            this.wizard.Name = "wizard";
            this.wizard.PageIndex = 0;
            this.wizard.Pages.AddRange(new UtilityLibrary.Wizards.WizardPageBase[] {
            this.wizardWelcomePage,
            this.wizardItemSearchPage,
            this.wizardItemPhotoPage,
            this.wizardItemMeasurementPage,
            this.wizardBunchMeasurementPage,
            this.wizardBoxMeasurementPage,
            this.wizardPalletMeasurementPage,
            this.wizardItemComfirmationPage,
            this.wizardFinalPage});
            this.wizard.ShowCancelConfirm = false;
            this.wizard.Size = new System.Drawing.Size(594, 421);
            this.wizard.TabIndex = 0;
            this.wizard.WizardClosed += new System.EventHandler(this.wizard_WizardClosed);
            this.wizard.Next += new UtilityLibrary.Wizards.WizardForm.WizardNextEventHandler(this.wizard_Next);
            this.wizard.PageShown += new UtilityLibrary.Wizards.WizardForm.WizardNextEventHandler(this.wizard_PageShown);
            // 
            // wizardWelcomePage
            // 
            this.wizardWelcomePage.BackColor = System.Drawing.Color.White;
            this.wizardWelcomePage.Description = "Все изменения, проводимые в этом мастере сразу вносятся в базу данных сайта! При " +
                "нажатии кнопки \"Далее\" необходимо выбрать товар, с которым предстоит работа. ";
            this.wizardWelcomePage.Description2 = "";
            this.wizardWelcomePage.HeaderImage = global::WMSOffice.Properties.Resources.measurement;
            this.wizardWelcomePage.Index = 0;
            this.wizardWelcomePage.Name = "wizardWelcomePage";
            this.wizardWelcomePage.Size = new System.Drawing.Size(594, 374);
            this.wizardWelcomePage.TabIndex = 0;
            this.wizardWelcomePage.Title = "Редактирование ОБВХ";
            this.wizardWelcomePage.WizardPageParent = this.wizard;
            // 
            // wizardItemSearchPage
            // 
            this.wizardItemSearchPage.Controls.Add(this.itemMeasurementSearchControl);
            this.wizardItemSearchPage.Description = "Шаг 1 - Выбор существующего товара";
            this.wizardItemSearchPage.HeaderImage = global::WMSOffice.Properties.Resources.measurement;
            this.wizardItemSearchPage.Index = 1;
            this.wizardItemSearchPage.Name = "wizardItemSearchPage";
            this.wizardItemSearchPage.Size = new System.Drawing.Size(578, 310);
            this.wizardItemSearchPage.TabIndex = 0;
            this.wizardItemSearchPage.Title = "ВЫБОР ТОВАРА";
            this.wizardItemSearchPage.WizardPageParent = this.wizard;
            // 
            // itemMeasurementSearchControl
            // 
            this.itemMeasurementSearchControl.DataContext = null;
            this.itemMeasurementSearchControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemMeasurementSearchControl.Location = new System.Drawing.Point(0, 0);
            this.itemMeasurementSearchControl.Name = "itemMeasurementSearchControl";
            this.itemMeasurementSearchControl.NeedConfirmItem = false;
            this.itemMeasurementSearchControl.Size = new System.Drawing.Size(578, 310);
            this.itemMeasurementSearchControl.TabIndex = 0;
            // 
            // wizardItemMeasurementPage
            // 
            this.wizardItemMeasurementPage.Controls.Add(this.itemMeasurementControl);
            this.wizardItemMeasurementPage.Description = "Шаг 2 - Измерение упаковки товара";
            this.wizardItemMeasurementPage.HeaderImage = global::WMSOffice.Properties.Resources.measurement;
            this.wizardItemMeasurementPage.Index = 3;
            this.wizardItemMeasurementPage.Name = "wizardItemMeasurementPage";
            this.wizardItemMeasurementPage.Size = new System.Drawing.Size(578, 310);
            this.wizardItemMeasurementPage.TabIndex = 0;
            this.wizardItemMeasurementPage.Title = "УПАКОВКА";
            this.wizardItemMeasurementPage.WizardPageParent = this.wizard;
            // 
            // itemMeasurementControl
            // 
            this.itemMeasurementControl.DataContext = null;
            this.itemMeasurementControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemMeasurementControl.Location = new System.Drawing.Point(0, 0);
            this.itemMeasurementControl.Name = "itemMeasurementControl";
            this.itemMeasurementControl.Size = new System.Drawing.Size(578, 310);
            this.itemMeasurementControl.TabIndex = 0;
            // 
            // wizardItemPhotoPage
            // 
            this.wizardItemPhotoPage.Controls.Add(this.itemPhotoControl);
            this.wizardItemPhotoPage.Description = "Шаг 2.1 - Добавление фотографии упаковки товара";
            this.wizardItemPhotoPage.HeaderImage = global::WMSOffice.Properties.Resources.measurement;
            this.wizardItemPhotoPage.Index = 2;
            this.wizardItemPhotoPage.Name = "wizardItemPhotoPage";
            this.wizardItemPhotoPage.Size = new System.Drawing.Size(578, 310);
            this.wizardItemPhotoPage.TabIndex = 0;
            this.wizardItemPhotoPage.Title = "ФОТОГРАФИЯ УПАКОВКИ";
            this.wizardItemPhotoPage.WizardPageParent = this.wizard;
            // 
            // itemPhotoControl
            // 
            this.itemPhotoControl.DataContext = null;
            this.itemPhotoControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemPhotoControl.Location = new System.Drawing.Point(0, 0);
            this.itemPhotoControl.Name = "itemPhotoControl";
            this.itemPhotoControl.Size = new System.Drawing.Size(578, 310);
            this.itemPhotoControl.TabIndex = 0;
            // 
            // wizardBunchMeasurementPage
            // 
            this.wizardBunchMeasurementPage.Controls.Add(this.bunchMeasurementControl);
            this.wizardBunchMeasurementPage.Description = "Шаг 3 - Измерение склейки";
            this.wizardBunchMeasurementPage.HeaderImage = global::WMSOffice.Properties.Resources.measurement;
            this.wizardBunchMeasurementPage.Index = 4;
            this.wizardBunchMeasurementPage.Name = "wizardBunchMeasurementPage";
            this.wizardBunchMeasurementPage.Size = new System.Drawing.Size(578, 310);
            this.wizardBunchMeasurementPage.TabIndex = 0;
            this.wizardBunchMeasurementPage.Title = "СКЛЕЙКА";
            this.wizardBunchMeasurementPage.WizardPageParent = this.wizard;
            // 
            // bunchMeasurementControl
            // 
            this.bunchMeasurementControl.DataContext = null;
            this.bunchMeasurementControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunchMeasurementControl.Location = new System.Drawing.Point(0, 0);
            this.bunchMeasurementControl.Name = "bunchMeasurementControl";
            this.bunchMeasurementControl.Size = new System.Drawing.Size(578, 310);
            this.bunchMeasurementControl.TabIndex = 0;
            // 
            // wizardBoxMeasurementPage
            // 
            this.wizardBoxMeasurementPage.Controls.Add(this.boxMeasurementControl);
            this.wizardBoxMeasurementPage.Description = "Шаг 4 - Измерение заводского ящика";
            this.wizardBoxMeasurementPage.HeaderImage = global::WMSOffice.Properties.Resources.measurement;
            this.wizardBoxMeasurementPage.Index = 5;
            this.wizardBoxMeasurementPage.Name = "wizardBoxMeasurementPage";
            this.wizardBoxMeasurementPage.Size = new System.Drawing.Size(578, 310);
            this.wizardBoxMeasurementPage.TabIndex = 0;
            this.wizardBoxMeasurementPage.Title = "ЯЩИК";
            this.wizardBoxMeasurementPage.WizardPageParent = this.wizard;
            // 
            // boxMeasurementControl
            // 
            this.boxMeasurementControl.DataContext = null;
            this.boxMeasurementControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boxMeasurementControl.Location = new System.Drawing.Point(0, 0);
            this.boxMeasurementControl.Name = "boxMeasurementControl";
            this.boxMeasurementControl.Size = new System.Drawing.Size(578, 310);
            this.boxMeasurementControl.TabIndex = 0;
            // 
            // wizardPalletMeasurementPage
            // 
            this.wizardPalletMeasurementPage.Controls.Add(this.palletMeasurementControl);
            this.wizardPalletMeasurementPage.Description = "Шаг 5 - Измерение паллеты";
            this.wizardPalletMeasurementPage.HeaderImage = global::WMSOffice.Properties.Resources.measurement;
            this.wizardPalletMeasurementPage.Index = 6;
            this.wizardPalletMeasurementPage.Name = "wizardPalletMeasurementPage";
            this.wizardPalletMeasurementPage.Size = new System.Drawing.Size(578, 310);
            this.wizardPalletMeasurementPage.TabIndex = 0;
            this.wizardPalletMeasurementPage.Title = "ПАЛЛЕТА";
            this.wizardPalletMeasurementPage.WizardPageParent = this.wizard;
            // 
            // palletMeasurementControl
            // 
            this.palletMeasurementControl.DataContext = null;
            this.palletMeasurementControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.palletMeasurementControl.Location = new System.Drawing.Point(0, 0);
            this.palletMeasurementControl.Name = "palletMeasurementControl";
            this.palletMeasurementControl.Size = new System.Drawing.Size(578, 310);
            this.palletMeasurementControl.TabIndex = 0;
            // 
            // wizardItemComfirmationPage
            // 
            this.wizardItemComfirmationPage.Controls.Add(this.itemMeasurementConfirmationControl);
            this.wizardItemComfirmationPage.Description = "Шаг 6 - Подтверждение выбранного товара";
            this.wizardItemComfirmationPage.HeaderImage = global::WMSOffice.Properties.Resources.measurement;
            this.wizardItemComfirmationPage.Index = 7;
            this.wizardItemComfirmationPage.Name = "wizardItemComfirmationPage";
            this.wizardItemComfirmationPage.Size = new System.Drawing.Size(578, 310);
            this.wizardItemComfirmationPage.TabIndex = 0;
            this.wizardItemComfirmationPage.Title = "ПОДТВЕРЖДЕНИЕ ТОВАРА";
            this.wizardItemComfirmationPage.WizardPageParent = this.wizard;
            // 
            // itemMeasurementConfirmationControl
            // 
            this.itemMeasurementConfirmationControl.DataContext = null;
            this.itemMeasurementConfirmationControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemMeasurementConfirmationControl.Location = new System.Drawing.Point(0, 0);
            this.itemMeasurementConfirmationControl.Name = "itemMeasurementConfirmationControl";
            this.itemMeasurementConfirmationControl.NeedConfirmItem = true;
            this.itemMeasurementConfirmationControl.Size = new System.Drawing.Size(578, 310);
            this.itemMeasurementConfirmationControl.TabIndex = 0;
            // 
            // wizardFinalPage
            // 
            this.wizardFinalPage.BackColor = System.Drawing.Color.White;
            this.wizardFinalPage.Description = "Все сделанные изменения сохранены в базе данных.";
            this.wizardFinalPage.Description2 = "Для завершения работы с мастером нажмите \"Готово\". Чтобы вернуться к редактирован" +
                "ию ОБВХ нажмите кнопку \"Назад\".";
            this.wizardFinalPage.FinishPage = true;
            this.wizardFinalPage.HeaderImage = global::WMSOffice.Properties.Resources.measurement;
            this.wizardFinalPage.Index = 8;
            this.wizardFinalPage.Name = "wizardFinalPage";
            this.wizardFinalPage.Size = new System.Drawing.Size(594, 374);
            this.wizardFinalPage.TabIndex = 0;
            this.wizardFinalPage.Title = "Обмер ОБВХ закончен!";
            this.wizardFinalPage.WelcomePage = true;
            this.wizardFinalPage.WizardPageParent = this.wizard;
            // 
            // MeasurementWizardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 421);
            this.Controls.Add(this.wizard);
            this.Name = "MeasurementWizardForm";
            this.Text = "Мастер действий ОБВХ";
            this.Load += new System.EventHandler(this.MeasurementWizardForm_Load);
            this.wizardItemSearchPage.ResumeLayout(false);
            this.wizardItemMeasurementPage.ResumeLayout(false);
            this.wizardItemPhotoPage.ResumeLayout(false);
            this.wizardBunchMeasurementPage.ResumeLayout(false);
            this.wizardBoxMeasurementPage.ResumeLayout(false);
            this.wizardPalletMeasurementPage.ResumeLayout(false);
            this.wizardItemComfirmationPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UtilityLibrary.Wizards.WizardForm wizard;
        private UtilityLibrary.Wizards.WizardWelcomePage wizardWelcomePage;
        private UtilityLibrary.Wizards.WizardPageBase wizardItemMeasurementPage;
        private UtilityLibrary.Wizards.WizardPageBase wizardBunchMeasurementPage;
        private UtilityLibrary.Wizards.WizardFinalPage wizardFinalPage;
        private UtilityLibrary.Wizards.WizardPageBase wizardBoxMeasurementPage;
        private UtilityLibrary.Wizards.WizardPageBase wizardPalletMeasurementPage;
        private WMSOffice.Controls.Receive.Measurement.ItemMeasurementControl itemMeasurementControl;
        private WMSOffice.Controls.Receive.Measurement.BunchMeasurementControl bunchMeasurementControl;
        private WMSOffice.Controls.Receive.Measurement.BoxMeasurementControl boxMeasurementControl;
        private WMSOffice.Controls.Receive.Measurement.PalletMeasurementControl palletMeasurementControl;
        private UtilityLibrary.Wizards.WizardPageBase wizardItemSearchPage;
        private WMSOffice.Controls.Receive.Measurement.ItemMeasurementSearchControl itemMeasurementSearchControl;
        private UtilityLibrary.Wizards.WizardPageBase wizardItemComfirmationPage;
        private WMSOffice.Controls.Receive.Measurement.ItemMeasurementSearchControl itemMeasurementConfirmationControl;
        private UtilityLibrary.Wizards.WizardPageBase wizardItemPhotoPage;
        private WMSOffice.Controls.Receive.Measurement.ItemPhotoControl itemPhotoControl;


    }
}