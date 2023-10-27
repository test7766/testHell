using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs.Admin;
using WMSOffice.Controls.Receive.Measurement;
using WMSOffice.Classes;
using Optima.Devices.Core.DigitalTrammel.Providers.Utils;

namespace WMSOffice.Dialogs.Receive
{
    public partial class MeasurementWizardForm : WizardBlankForm, IMeasurementHost
    {
        public long UserID { get; private set; }

        private readonly MeasurementItem dataContext = null;

        //private readonly Dictionary<Optima.Devices.Data.DigitalTrammel.DataManager.DTType, ObtainMeasureProvider> dMProviders = null;
        private readonly ObtainMeasureProvider mProvider = null;

        private Dialogs.SplashForm waitProcessForm = new WMSOffice.Dialogs.SplashForm();

        protected MeasurementWizardForm()
        {
            InitializeComponent();
            dataContext = new MeasurementItem(this);            
        }

        public MeasurementWizardForm(long userID, ObtainMeasureProvider mProviderExternal)
            : this()
        {
            this.UserID = userID;
            dataContext.UserID = userID;

            //dMProviders = new Dictionary<Optima.Devices.Data.DigitalTrammel.DataManager.DTType, ObtainMeasureProvider>();
            //dMProviders.Add(Optima.Devices.Data.DigitalTrammel.DataManager.DTType.L300, new ObtainMeasureProvider() { TrammelTypeID = (int)Optima.Devices.Data.DigitalTrammel.DataManager.DTType.L300 });
            //dMProviders.Add(Optima.Devices.Data.DigitalTrammel.DataManager.DTType.L1000, new ObtainMeasureProvider() { TrammelTypeID = (int)Optima.Devices.Data.DigitalTrammel.DataManager.DTType.L1000 });

            mProvider = mProviderExternal ?? new ObtainMeasureProvider();
        }

        private void MeasurementWizardForm_Load(object sender, EventArgs e)
        {
            itemMeasurementSearchControl.Initialize(this.UserID);
            itemMeasurementSearchControl.DataContext = dataContext;
            itemMeasurementSearchControl.OnFinishPage += (s, ea) => 
            {
                wizard.PageIndex = wizardFinalPage.Index;
            };

            itemMeasurementControl.DataContext = dataContext;
            itemPhotoControl.DataContext = dataContext;
            bunchMeasurementControl.DataContext = dataContext;
            boxMeasurementControl.DataContext = dataContext;
            palletMeasurementControl.DataContext = dataContext;

            itemMeasurementConfirmationControl.Initialize(this.UserID);
            itemMeasurementConfirmationControl.DataContext = dataContext;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            //wizard.MoveNextStep(); // пропускаем страницу приветствия
            wizard.PageIndex = wizardItemSearchPage.Index;

            var bw = new BackgroundWorker();
            bw.DoWork += (s, ea) => 
            {
                try
                {
                    dataContext.Initialize();

                    // 1. Подписка на события измерений
                    this.SubsribeOnEvents();

                    // 2. Инициилизация провайдера
                    this.Initialize();

                    // 3. 
                    this.PrepareAvailableDevicesForUser();
                 
                    this.Connect();
                }
                catch (Exception ex)
                {
                    ea.Result = ex;
                }
            };
            bw.RunWorkerCompleted += (s, ea) => 
            {
                if (ea.Result is Exception)
                    MessageBox.Show((ea.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                waitProcessForm.CloseForce();
            };
            waitProcessForm.ActionText = "Выполняется инициализация мастера..";
            bw.RunWorkerAsync();
            waitProcessForm.ShowDialog();
        }

        private void Initialize()
        {
            // Если при внешней инициализации возникла ошибка, то блокируем работу с устройством
            if (mProvider.IsAccessDenied)
                return;

            try
            {
                var measureAcquireMode = this.dataContext.MeasureAccessFlag == 1;
                if (measureAcquireMode)
                    mProvider.Initialize();
                else
                    mProvider.IsAccessDenied = true;
            }
            catch (Exception ex)
            {
                mProvider.IsAccessDenied = true;
            }

            #region OBSOLETE
            //foreach (var kvp in dMProviders)
            //{
            //    var mProvider = kvp.Value;

            //    try
            //    {
            //        var measureAcquireMode = this.dataContext.MeasureAccessFlag == 1;
            //        if (measureAcquireMode)
            //            mProvider.Initialize();
            //        else
            //            mProvider.IsAccessDenied = true;
            //    }
            //    catch (Exception ex)
            //    {
            //        //MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        mProvider.IsAccessDenied = true;
            //    }
            //}
            #endregion
        }

        private void PrepareAvailableDevicesForUser()
        {
            try
            {
                var devices = mProvider.AvailableDevicesForUser;
                var connectedDeviceMAC = mProvider.ConnectedDeviceMAC;

                itemMeasurementControl.PrepareAvailableDevicesForUser(devices, connectedDeviceMAC);
                bunchMeasurementControl.PrepareAvailableDevicesForUser(devices, connectedDeviceMAC);
                boxMeasurementControl.PrepareAvailableDevicesForUser(devices, connectedDeviceMAC);
                palletMeasurementControl.PrepareAvailableDevicesForUser(devices, connectedDeviceMAC);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SubsribeOnEvents()
        {
            try
            {
                itemMeasurementControl.SubscribeOnEvents();
                bunchMeasurementControl.SubscribeOnEvents();
                boxMeasurementControl.SubscribeOnEvents();
                palletMeasurementControl.SubscribeOnEvents();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Connect()
        {
            try
            {
                mProvider.Connect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            #region OBSOLETE
            //foreach (var kvp in dMProviders)
            //{
            //    try
            //    {
            //        var mProvider = kvp.Value;
            //        mProvider.Connect();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            #endregion
        }

        private void wizard_PageShown(object sender, UtilityLibrary.Wizards.WizardForm.EventNextArgs e)
        {
            if (e.CurrentPage == wizardItemSearchPage)
                itemMeasurementSearchControl.InitializeData(this.dataContext.UseLotNumberSearchMode ?? false, this.dataContext.UseAssignBarCodeMode ?? false, this.dataContext.UseDeleteBarCodeMode ?? false, this.dataContext.UseAssignBarCodeZUMode ?? false, this.dataContext.UseDeleteBarCodeZUMode ?? false);

            if (e.CurrentPage == wizardItemMeasurementPage)
            {
                this.BeginReadData(null);
                itemMeasurementControl.InitializeData();
            }

            if (e.CurrentPage == wizardItemPhotoPage)
                itemPhotoControl.InitializeData();

            if (e.CurrentPage == wizardBunchMeasurementPage)
                bunchMeasurementControl.InitializeData();

            if (e.CurrentPage == wizardBoxMeasurementPage)
                boxMeasurementControl.InitializeData();

            if (e.CurrentPage == wizardPalletMeasurementPage)
                palletMeasurementControl.InitializeData();

            if (e.CurrentPage == wizardItemComfirmationPage)
                itemMeasurementConfirmationControl.InitializeData(this.dataContext.UseLotNumberSearchMode ?? false, this.dataContext.UseAssignBarCodeMode ?? false, this.dataContext.UseDeleteBarCodeMode ?? false, this.dataContext.UseAssignBarCodeZUMode ?? false, this.dataContext.UseDeleteBarCodeZUMode ?? false);

            if (e.CurrentPage == wizardFinalPage)
                this.EndReadData();

            wizard.btnCancel.Visible = (e.CurrentPage.Name != wizardFinalPage.Name);
        }

        //[Obsolete]
        //private void BeginReadData()
        //{
        //    #region OBSOLETE
        //    //foreach (var kvp in dMProviders)
        //    //{
        //    //    try
        //    //    {
        //    //        var mProvider = kvp.Value;
        //    //        mProvider.BeginReadData();
        //    //    }
        //    //    catch (Exception ex)
        //    //    {
        //    //        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    //    }
        //    //}
        //    #endregion
        //}

        public void BeginReadData(string deviceMAC)
        {
           try
           {
               mProvider.BeginReadData(deviceMAC);
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
        }

        public void EndReadData()
        {
            try
            {
                mProvider.EndReadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            #region OBSOLETE
            //foreach (var kvp in dMProviders)
            //{
            //    try
            //    {
            //        var mProvider = kvp.Value;
            //        mProvider.EndReadData();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            #endregion
        }

        private void wizard_Next(object sender, UtilityLibrary.Wizards.WizardForm.EventNextArgs e)
        {
            if (e.CurrentPage == wizardItemSearchPage && !itemMeasurementSearchControl.ValidateData())
            {
                e.Step = 0;
                return;
            }
           
            if (e.CurrentPage == wizardItemSearchPage)
            {
                // После удаления ш/к с первой страницы перескакиваем сразу на последнюю
                if ((itemMeasurementSearchControl.DataContext.UseDeleteBarCodeMode ?? false) == true)
                {
                    e.Step = 7;
                    return;
                }

                // Пропускаем блок фото
                if (!itemMeasurementControl.DataContext.NeedItemPhoto)
                {
                    e.Step = 2;
                    return;
                }
            }

            if (e.CurrentPage == wizardItemPhotoPage && itemMeasurementControl.DataContext.NeedItemPhoto && !itemPhotoControl.ValidateData())
            {
                e.Step = 0;
                return;
            }

            if (e.CurrentPage == wizardItemMeasurementPage && !itemMeasurementControl.ValidateData())
            {
                e.Step = 0;
                return;
            }

            if (e.CurrentPage == wizardBunchMeasurementPage && !bunchMeasurementControl.ValidateData())
            {
                e.Step = 0;
                return;
            }

            if (e.CurrentPage == wizardBoxMeasurementPage && !boxMeasurementControl.ValidateData())
            {
                e.Step = 0;
                return;
            }

            if (e.CurrentPage == wizardPalletMeasurementPage && !palletMeasurementControl.ValidateData())
            {
                e.Step = 0;
                return;
            }

            if (e.CurrentPage == wizardItemComfirmationPage && !itemMeasurementConfirmationControl.ValidateData())
            {
                e.Step = 0;
                return;
            }
        }

        private void wizard_WizardClosed(object sender, EventArgs e)
        {
            //this.Disconnect();
            TryCancelWeightDoc();
            Close();
        }

        private void TryCancelWeightDoc()
        {
            try
            {
                if (dataContext.ItemWeightDocID.HasValue)
                    dataContext.CancelWeightDoc();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        [Obsolete("Отключение от устройства вынесено во внешний блок")]
        private void Disconnect()
        {
            try
            {
                mProvider.Disconnect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            #region OBSOLETE
            //foreach (var kvp in dMProviders)
            //{
            //    try
            //    {
            //        var mProvider = kvp.Value;
            //        mProvider.Disconnect();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            #endregion
        }

        #region IMeasurementHost Members

        //[Obsolete]
        //public void ReConnect(Optima.Devices.Data.DigitalTrammel.DataManager.DTType dtType)
        //{
        //    #region OBSOLETE
        //    //try
        //    //{
        //    //    var mProvider = dMProviders[dtType];

        //    //    mProvider.EndReadData();
        //    //    mProvider.Disconnect();
        //    //    mProvider.Connect();
        //    //    mProvider.BeginReadData();
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    //}
        //    #endregion
        //}

        public void ReConnect()
        {
            try
            {
                mProvider.EndReadData();
                mProvider.Disconnect();
                mProvider.Connect();
                mProvider.BeginReadData(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UseManualInput(bool setActive)
        {
            try
            {
               this.RaiseUseManualInput(setActive);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public event EventHandler<UseManualInputEventArgs> OnUseManualInput;
        public void RaiseUseManualInput(bool setActive)
        {
            if (this.OnUseManualInput != null)
                this.OnUseManualInput(this, new UseManualInputEventArgs(setActive));
        }

        //public IMeasurementProvider GetProvider(Optima.Devices.Data.DigitalTrammel.DataManager.DTType dtType)
        //{
        //    return dMProviders[dtType];
        //}

        public IMeasurementProvider GetProvider()
        {
            return mProvider;
        }

        #endregion
    }
}
