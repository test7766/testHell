using System;
using System.Collections.Generic;
using System.Text;
using Optima.Devices.Core.DigitalScanner;
using Optima.Devices.Configuration.DigitalScanner;
using System.Security.Principal;
using Optima.Devices.Core.DigitalScanner.Commands.Enums;
using System.Threading;
using Optima.Devices.Core.DigitalScanner.MessageFormatters;
using Optima.Devices.Core.DigitalScanner.Commands;

namespace WMSOffice.Classes
{
    public class ObtainBarCodeProvider
    {
        /// <summary>
        /// Контроллер
        /// </summary>
        private SController sController = null;

        /// <summary>
        /// Тип сканера
        /// </summary>
        public int ScannerTypeID { get; set; }

        public Exception Error { get; private set; }

        /// <summary>
        /// Событие получения номера конфигурации сканера
        /// </summary>
        public event EventHandler<ScannerConfigurationDataReceivedArgs> ScannerConfigurationDataReceived;
        public void OnScannerConfigurationDataReceived(string configuration)
        {
            if (this.ScannerConfigurationDataReceived != null)
                this.ScannerConfigurationDataReceived(this, new ScannerConfigurationDataReceivedArgs(configuration));
        }

        /// <summary>
        /// Событие получения ш/к со сканера
        /// </summary>
        public event EventHandler<ScannerBarCodeDataReceivedArgs> ScannerBarCodeDataReceived;
        public void OnScannerBarCodeDataReceived(string barCode)
        {
            if (this.ScannerBarCodeDataReceived != null)
                this.ScannerBarCodeDataReceived(this, new ScannerBarCodeDataReceivedArgs(barCode));
        }

        /// <summary>
        /// Событие получения последнего изображения с ошибкой
        /// </summary>
        public event EventHandler<ScannerLastErrorImageReceivedArgs> ScannerLastErrorImageReceived;
        public void OnScannerLastErrorImageReceived(string imageExtension, byte[] imageBuffer)
        {
            if (this.ScannerLastErrorImageReceived != null)
                this.ScannerLastErrorImageReceived(this, new ScannerLastErrorImageReceivedArgs(imageExtension, imageBuffer));
        }

        /// <summary>
        /// Событие получения ошибки со сканера
        /// </summary>
        public event EventHandler<ScannerErrorReceivedArgs> ScannerErrorReceived;
        public void OnScannerErrorDataReceived(Exception exception, bool recognizeBarCodeErrorOccured)
        {
            if (this.ScannerErrorReceived != null)
                this.ScannerErrorReceived(this, new ScannerErrorReceivedArgs(exception, recognizeBarCodeErrorOccured));
        }

        public ObtainBarCodeProvider()
        {
            this.ScannerTypeID = (int)Optima.Devices.Data.DigitalScanner.DataManager.DSType.O2I353; // по умолчанию O2I353
        }

        public void Initialize()
        {
            var sConfiguration = SConfigurationHelper.CreateConfiguration(WindowsIdentity.GetCurrent().Name, this.ScannerTypeID);
            if (sConfiguration != null)
            {
                sController = new SController(sConfiguration.CreateProvider());

                sController.SMessageCallback += (s, e) =>
                {
                    try
                    {
                        Error = null;
                        var message = e.Message;

                        switch (e.Message.SCommandActionType)
                        {
                            case SCommandActionType.t: // получение ш/к
                                UpdateBarCode(message);
                                break;
                            case SCommandActionType.a: // получение конфигурации
                                UpdateConfiguration(message.SValue);
                                break;
                            case SCommandActionType.E: // получение ошибок
                                UpdateErrors(message);
                                break;
                            default:
                                break;
                        }
                    }
                    catch (ThreadAbortException ex)
                    {

                    }
                    catch (ScannerRecognizeBarCodeException ex)
                    {
                        OnScannerErrorDataReceived(Error = ex, true);
                    }
                    catch (Exception ex)
                    {
                        OnScannerErrorDataReceived(Error = ex, false);
                    }
                };
            }
            else
                throw new Exception("Конфигурация цифрового сканера не настроена для вашего пользователя. Обратитесь к администраторам WMS.");
        }

        private void UpdateBarCode(object oMessage)
        {
            var message = oMessage as SMessage;

            var barCode = message.SValue;
            OnScannerBarCodeDataReceived(barCode);

            //if (message.SImageBuffer == null)
            //{
            //    var barCode = message.SValue;
            //    OnScannerBarCodeDataReceived(barCode);
            //}
        }

        private void UpdateConfiguration(object oConfiguration)
        {
            var configuration = oConfiguration.ToString();
            OnScannerConfigurationDataReceived(configuration);
        }

        private void UpdateErrors(object oMessage)
        {
            var message = oMessage as SMessage;

            // 1. Получение изображения (об ошибке)
            if (message.SImageBuffer != null)
            {
                OnScannerLastErrorImageReceived(message.SImageType, message.SImageBuffer);
                
                // предполагается, что текст ошибки был получен на предыдущем шаге
                return;
            }

            // 2. Получение текста ошибки
            var oErrors = message.SErrors;

            var errors = (List<string>)oErrors;
            var sbErrors = new StringBuilder();

            foreach (var error in errors)
            {
                if (sbErrors.Length == 0)
                    sbErrors.AppendFormat("{0}", error);
                else
                    sbErrors.AppendFormat("\r\n{0}", error);
            }

            throw new ScannerRecognizeBarCodeException(sbErrors.ToString());
        }

        public void Connect()
        {
            try
            {
                if (sController != null)
                    sController.Connect();
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
                if (sController != null)
                    sController.Disconnect();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RequestLastErrorImage()
        {
            try
            {
                if (sController != null)
                    sController.SendMessage(new SCommandRequestLastErrorImage());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class ScannerRecognizeBarCodeException : Exception
    {
        public ScannerRecognizeBarCodeException(string message)
            : base(message)
        {
            
        }
    }

    public class ScannerConfigurationDataReceivedArgs : EventArgs
    {
        public string Configuration { get; private set; }

        public ScannerConfigurationDataReceivedArgs(string configuration)
        {
            this.Configuration = configuration;
        }
    }

    public class ScannerBarCodeDataReceivedArgs : EventArgs
    {
        public string BarCode { get; private set; }
        public byte[] ImageBytes { get; private set; }

        public ScannerBarCodeDataReceivedArgs(string barCode)
        {
            this.BarCode = barCode;
        }
    }

    public class ScannerErrorReceivedArgs : EventArgs
    {
        public Exception Exception { get; private set; }
        public bool RecognizeBarCodeErrorOccured { get; private set; }

        public ScannerErrorReceivedArgs(Exception exception, bool recognizeBarCodeErrorOccured)
        {
            this.Exception = exception;
            this.RecognizeBarCodeErrorOccured = recognizeBarCodeErrorOccured;
        }
    }

    public class ScannerLastErrorImageReceivedArgs : EventArgs
    {
        public string ImageExtension { get; private set; }
        public byte[] ImageBuffer {get; private set;}

        public ScannerLastErrorImageReceivedArgs(string imageExtension, byte[] imageBuffer)
        {
            this.ImageExtension = imageExtension;
            this.ImageBuffer = imageBuffer;
        }
    }
}
