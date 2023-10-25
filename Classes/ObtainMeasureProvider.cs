using System;
using System.Collections.Generic;
using System.Text;
using Optima.Devices.Core.DigitalTrammel;
using Optima.Devices.Configuration.DigitalTrammel;
using Optima.Devices.Core.DigitalTrammel.Providers.Utils;
using System.Threading;
using WMSOffice.Controls.Receive.Measurement;
using Optima.Devices.Configuration.DigitalTrammel.Configurations;

namespace WMSOffice.Classes
{
    public class ObtainMeasureProvider : IMeasurementProvider
    {
        /// <summary>
        /// Контроллер
        /// </summary>
        private TController tController = null;

        /// <summary>
        /// Тип штангенциркуля
        /// </summary>
        public int TrammelTypeID { get; set; }

        /// <summary>
        /// Признак подключения (получен MAC-адрес)
        /// </summary>
        public bool IsConnected { get; private set; }

        /// <summary>
        /// Признак проведенной инициализации
        /// </summary>
        public bool IsInitialized { get; private set; }

        /// <summary>
        /// Признак отсутствия доступа к устройству
        /// </summary>
        public bool IsAccessDenied { get; set; }

        /// <summary>
        /// Доступные для пользователя устройства
        /// </summary>
        public Dictionary<string, int> AvailableDevicesForUser { get; private set; }

        /// <summary>
        /// Подключенные устройства
        /// </summary>
        public List<string> ConnectedDeviceMAC { get; private set; }

        ///// <summary>
        ///// Все MAC-адреса устройства
        ///// </summary>
        //public List<string> AllDeviceMAC { get; private set; }

        /// <summary>
        /// Таймер проверки установленного соединения с устройством
        /// </summary>
        private Timer waitForMeasurementObtainTimer = null;

        /// <summary>
        /// Время восстановления после получения фиксированного измерения
        /// </summary>
        private int measureResumeTimeInSeconds = 1;

        /// <summary>
        /// Время ожидания получения сигнала перед его потерей
        /// </summary>
        private int measureWaitTimeBeforeLostSignalInSeconds = 5;

        /// <summary>
        /// Время получения последнего измерения
        /// </summary>
        public DateTime LastMeasureEventDate;

        /// <summary>
        /// Время получения последнего фиксированного измерения после восстановления
        /// </summary>
        public DateTime LastFixedMeasureEventDate;

        public Exception Error { get; private set; }

        /// <summary>
        /// Событие "Получено измерение"
        /// </summary>
        public event EventHandler<TMeasurementReceivedEventArgs> OnMeasurementReceived;

        /// <summary>
        /// Событие "Изменен сигнал"
        /// </summary>
        public event EventHandler<SignalChangedEventArgs> SignalChanged;

        /// <summary>
        /// Событие получения ошибки
        /// </summary>
        public event EventHandler<TrammelErrorReceivedArgs> TrammelErrorReceived;
        public void OnTrammelErrorReceived(Exception exception)
        {
            if (this.TrammelErrorReceived != null)
                this.TrammelErrorReceived(this, new TrammelErrorReceivedArgs(exception));
        }

        /// <summary>
        /// Событие получения MAC-адреса
        /// </summary>
        public event EventHandler<TrammelMACReceivedArgs> TrammelMACReceived;
        public void OnTrammelMACReceived(string deviceMAC)
        {
            if (this.TrammelMACReceived != null)
                this.TrammelMACReceived(this, new TrammelMACReceivedArgs(deviceMAC));
        }

        /// <summary>
        /// Событие начала начала чтения данных
        /// </summary>
        public event EventHandler<BeginReadDataEventArgs> StartBeginReadData;
        public void OnStartBeginReadData(string deviceMAC)
        {
            if (this.StartBeginReadData != null)
                this.StartBeginReadData(this, new BeginReadDataEventArgs(deviceMAC));
        }

        /// <summary>
        /// Событие начала конца чтения данных
        /// </summary>
        public event EventHandler StartEndReadData;
        public void OnStartEndReadData()
        {
            if (this.StartEndReadData != null)
                this.StartEndReadData(this, EventArgs.Empty);
        }

        /// <summary>
        /// Событие начала отключения от устройства
        /// </summary>
        public event EventHandler StartDisconnect;
        public void OnStartDisconnect()
        {
            if (this.StartDisconnect != null)
                this.StartDisconnect(this, EventArgs.Empty);
        }

        public ObtainMeasureProvider()
        {
            this.TrammelTypeID = (int)Optima.Devices.Data.DigitalTrammel.DataManager.DTType.L300; // ШК 300 мм
            
            waitForMeasurementObtainTimer = new System.Threading.Timer(new TimerCallback(WaitForMeasurementObtain), this, Timeout.Infinite, Timeout.Infinite);

            this.AvailableDevicesForUser = new Dictionary<string, int>();

            this.ConnectedDeviceMAC = new List<string>();
        }

        private void WaitForMeasurementObtain(object target)
        {
            var omp = target as ObtainMeasureProvider;
            if ((DateTime.Now - omp.LastMeasureEventDate).TotalSeconds > TimeSpan.FromSeconds(omp.measureWaitTimeBeforeLostSignalInSeconds).TotalSeconds)
                omp.OnSignalChanged(SignalLevel.Low);
        }

        public void OnSignalChanged(SignalLevel signalLevel)
        {
            if (this.SignalChanged != null)
                this.SignalChanged(this, new SignalChangedEventArgs(signalLevel));
        }

        public void Initialize()
        {
            //if (this.IsInitialized)
            //{
            //    this.ConnectedDeviceMAC.Clear();
            //    foreach (var kvp in this.AvailableDevicesForUser)
            //    {
            //        var deviceMAC = kvp.Key;
            //        this.ConnectedDeviceMAC.Add(deviceMAC);
            //    }
            //}

            if (!this.IsInitialized)
            {
                this.AvailableDevicesForUser.Clear();

                var tConfigurations = TConfigurationHelper.CreateAllConfigurations(Environment.MachineName);
                if (tConfigurations != null && tConfigurations.Count > 0)
                {
                    var tProvider = tConfigurations[0].CreateProvider();

                    var lstAllDeviceMAC = new List<string>();
                    foreach (TBluetoothConfiguration tConfiguration in tConfigurations)
                    {
                        lstAllDeviceMAC.Add(tConfiguration.DeviceMAC);
                        this.AvailableDevicesForUser.Add(tConfiguration.DeviceMAC, tConfiguration.DeviceTypeID);
                    }

                    tProvider.PopulateAllExpectedDeviceMAC(lstAllDeviceMAC);

                    tController = new TController(tProvider);

                    tController.OnDeviceMacReceived += (s, e) =>
                    {
                        try
                        {
                            var deviceMAC = e.DeviceMAC;

                            this.OnTrammelMACReceived(deviceMAC);
                            
                            this.ConnectedDeviceMAC.Add(deviceMAC);

                            this.IsConnected = true;

                            this.OnSignalChanged(SignalLevel.Low);
                        }
                        catch (ThreadAbortException ex)
                        {

                        }
                        catch (Exception ex)
                        {
                            OnTrammelErrorReceived(Error = ex);
                        }
                    };

                    tController.OnMeasurementReceived += (s, e) =>
                    {
                        try
                        {
                            this.LastMeasureEventDate = DateTime.Now;

                            this.OnSignalChanged(SignalLevel.High);

                            if (e.IsFixed)
                            {
                                // Фиксированное измерение принимаем только после времени восстановления
                                if ((this.LastMeasureEventDate - this.LastFixedMeasureEventDate).TotalSeconds > TimeSpan.FromSeconds(measureResumeTimeInSeconds).TotalSeconds)
                                {
                                    this.LastFixedMeasureEventDate = this.LastMeasureEventDate;

                                    if (this.OnMeasurementReceived != null)
                                        this.OnMeasurementReceived(this, new TMeasurementReceivedEventArgs(e.Measurement, e.UnitOfMeasure, e.IsFixed));
                                }
                            }
                        }
                        catch (ThreadAbortException ex)
                        {

                        }
                        catch (Exception ex)
                        {
                            OnTrammelErrorReceived(Error = ex);
                        }
                    };

                    tController.OnErrorOccured += (s, e) =>
                    {
                        OnTrammelErrorReceived(Error = e.Error);
                    };
                }
                else
                    throw new Exception("Конфигурация цифрового штангенциркуля не настроена для вашего пользователя. Обратитесь к администраторам WMS.");

                this.IsInitialized = true;
            }

            #region OBSOLETE
            //var tConfiguration = TConfigurationHelper.CreateConfiguration(Environment.MachineName, TrammelTypeID);
            //if (tConfiguration != null)
            //{
            //    tController = new TController(tConfiguration.CreateProvider());

            //    tController.OnDeviceMacReceived += (s, e) =>
            //    {
            //        this.DeviceMAC = e.DeviceMAC;
            //        this.IsConnected = true;

            //        this.RaiseOnSignalChanged(SignalLevel.Low);
            //    };

            //    tController.OnMeasurementReceived += (s, e) =>
            //    {
            //        this.LastMeasureEventDate = DateTime.Now;

            //        this.RaiseOnSignalChanged(SignalLevel.High);

            //        if (e.IsFixed)
            //        {
            //            // Фиксированное измерение принимаем только после времени восстановления
            //            if ((this.LastMeasureEventDate - this.LastFixedMeasureEventDate).TotalSeconds > TimeSpan.FromSeconds(measureResumeTimeInSeconds).TotalSeconds)
            //            {
            //                this.LastFixedMeasureEventDate = this.LastMeasureEventDate;

            //                if (this.OnMeasurementReceived != null)
            //                    this.OnMeasurementReceived(this, new TMeasurementReceivedEventArgs(e.Measurement, e.UnitOfMeasure, e.IsFixed));
            //            }
            //        }
            //    };

            //    tController.OnErrorOccured += (s, e) =>
            //    {
            //        MessageBox.Show(e.Error.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        //throw new Exception(e.Error.Message);
            //    };
            //}
            //else
            //    throw new Exception("Конфигурация цифрового штангенциркуля не настроена для вашего пользователя. Обратитесь к администраторам WMS.");
            #endregion
        }

        public void Connect()
        {
            try
            {
                if (this.IsAccessDenied)
                    return;

                if (!this.IsConnected)
                    tController.Connect();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BeginReadData(string deviceMAC)
        {
            try
            {
                if (this.IsAccessDenied)
                    return;

                // Подключение к устройству (по умолчанию подключение выполняется к приоритетному)
                if ((deviceMAC = deviceMAC ?? this.GetPriorityDeviceMAC()) == null)
                    return;

                this.OnStartBeginReadData(deviceMAC);

                if (this.IsConnected)
                {
                    tController.SelectDevice(deviceMAC);
                    tController.BeginReadData();

                    this.LastFixedMeasureEventDate = this.LastMeasureEventDate = DateTime.Now;

                    waitForMeasurementObtainTimer.Change(0, 1000 * measureWaitTimeBeforeLostSignalInSeconds);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string GetPriorityDeviceMAC()
        {
            try
            {
                foreach (var deviceMAC in this.ConnectedDeviceMAC)
                    if (this.AvailableDevicesForUser[deviceMAC] == (int)Optima.Devices.Data.DigitalTrammel.DataManager.DTType.L300)
                        return deviceMAC;

                return this.ConnectedDeviceMAC.Count > 0 ? this.ConnectedDeviceMAC[0] : (string)null;
            }
            catch
            {
                return (string)null;
            }
        }

        public void EndReadData()
        {
            try
            {
                if (this.IsAccessDenied)
                    return;

                this.OnStartEndReadData();

                waitForMeasurementObtainTimer.Change(Timeout.Infinite, Timeout.Infinite);

                tController.EndReadData();

                this.OnSignalChanged(SignalLevel.Low);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Disconnect()
        {
            try
            {
                if (this.IsAccessDenied)
                    return;

                this.OnStartDisconnect();

                tController.Disconnect();
                this.IsConnected = false;

                this.ConnectedDeviceMAC.Clear();

                this.OnSignalChanged(SignalLevel.Zero);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region IMeasurementProvider Members

        //Optima.Devices.Data.DigitalTrammel.DataManager.DTType IMeasurementProvider.TrammelTypeID { get { return (Optima.Devices.Data.DigitalTrammel.DataManager.DTType)this.TrammelTypeID; } }

        bool IMeasurementProvider.IsAccessDenied { get { return this.IsAccessDenied; } }

        event EventHandler<TMeasurementReceivedEventArgs> IMeasurementProvider.OnMeasurementReceived
        {
            add { this.OnMeasurementReceived += value; }
            remove { this.OnMeasurementReceived -= value; }
        }

        event EventHandler<SignalChangedEventArgs> IMeasurementProvider.OnSignalChanged
        {
            add { this.SignalChanged += value; }
            remove { this.SignalChanged -= value; }
        }

        event EventHandler<TrammelMACReceivedArgs> IMeasurementProvider.OnTrammelMACReceived
        {
            add { this.TrammelMACReceived += value; }
            remove { this.TrammelMACReceived -= value; }
        }

        event EventHandler<BeginReadDataEventArgs> IMeasurementProvider.OnStartBeginReadData
        {
            add { this.StartBeginReadData += value; }
            remove { this.StartBeginReadData -= value; }
        }

        event EventHandler IMeasurementProvider.OnStartEndReadData
        {
            add { this.StartEndReadData += value; }
            remove { this.StartEndReadData -= value; }
        }

        event EventHandler IMeasurementProvider.OnStartDisconnect
        {
            add { this.StartDisconnect += value; }
            remove { this.StartDisconnect -= value; }
        }

        #endregion
    }

    public class TrammelMACReceivedArgs : EventArgs
    {
        public string DeviceMAC { get; private set; }

        public TrammelMACReceivedArgs(string deviceMAC)
        {
            this.DeviceMAC = deviceMAC;
        }
    }

    public class TrammelErrorReceivedArgs : EventArgs
    {
        public Exception Exception { get; private set; }

        public TrammelErrorReceivedArgs(Exception exception)
        {
            this.Exception = exception;
        }
    }

    public class SignalChangedEventArgs : EventArgs
    {
        public SignalLevel SignalLevel { get; private set; }

        public SignalChangedEventArgs(SignalLevel signalLevel)
        {
            this.SignalLevel = signalLevel;
        }
    }

    public class BeginReadDataEventArgs : EventArgs
    {
        public string DeviceMAC { get; private set; }

        public BeginReadDataEventArgs(string deviceMAC)
        {
            this.DeviceMAC = deviceMAC;
        }
    }

    /// <summary>
    /// Уровень сигнала
    /// </summary>
    public enum SignalLevel
    { 
        /// <summary>
        /// Нулевой
        /// </summary>
        Zero = 0,

        /// <summary>
        /// Низкий
        /// </summary>
        Low = 1,
        
        /// <summary>
        /// Высокий
        /// </summary>
        High = 2
    }
}
