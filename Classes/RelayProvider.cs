using System;
using System.Collections.Generic;
using System.Text;
using Optima.Devices.Core.DigitalRelay;
using Optima.Devices.Core.DigitalRelay.Providers;
using System.Threading;
using Optima.Devices.Core.DigitalRelay.Commands.Enums;

namespace WMSOffice.Classes
{
    public class RelayProvider
    {
        /// <summary>
        /// Контроллер
        /// </summary>
        private RController rController = null;

        /// <summary>
        /// Имя хоста
        /// </summary>
        public string HostName { get; private set; }

        /// <summary>
        /// Номер порта
        /// </summary>
        public int Port { get; private set; }

        /// <summary>
        /// Событие получения состояния входов реле
        /// </summary>
        public event EventHandler<RelayDataReceivedArgs> RelayDataReceived;
        public void OnRelayDataReceived(byte inputNumber, byte value)
        {
            if (this.RelayDataReceived != null)
                this.RelayDataReceived(this, new RelayDataReceivedArgs(inputNumber, value));
        }

        /// <summary>
        /// Событие получения ошибки с реле
        /// </summary>
        public event EventHandler<RelayErrorReceivedArgs> RelayErrorReceived;
        public void OnRelayErrorReceived(Exception exception)
        {
            if (this.RelayErrorReceived != null)
                this.RelayErrorReceived(this, new RelayErrorReceivedArgs(exception));
        }

        public Exception Error { get; private set; }

        public RelayProvider(string hostName, int port)
        {
            this.HostName = hostName;
            this.Port = port;
        }

        public void Initialize()
        {
            var rProvider = new REthernetProvider(this.HostName, this.Port);
            rController = new RController(rProvider);

            rController.RMessageCallback += (s, e) =>
            {
                try
                {
                    Error = null;
                    var message = e.Message;

                    switch (message.RCommandActionType)
                    {
                        case RCommandActionType.RequestStatus:
                            OnRelayDataReceived(message.RInputNumber, message.RValue);
                            break;
                        case RCommandActionType.RequestDigitalInput:
                            OnRelayDataReceived(message.RInputNumber, message.RValue);
                            break;
                        default:
                            break;
                    }
                }
                catch (ThreadAbortException ex)
                {

                }
                catch (Exception ex)
                {
                    OnRelayErrorReceived(Error = ex);
                }

            };
        }

        public void Connect()
        {
            try
            {
                rController.Connect();
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
                rController.Disconnect();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void OnOff(int inputNumber, bool isEnabled, int timeout)
        {
            try
            {
                rController.OnOff(inputNumber, isEnabled, timeout);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class RelayDataReceivedArgs : EventArgs
    {
        public byte InputNumber { get; private set; }
        public byte Value { get; private set; }

        public RelayDataReceivedArgs(byte inputNumber, byte value)
        {
            this.InputNumber = inputNumber;
            this.Value = value;
        }
    }

    public class RelayErrorReceivedArgs : EventArgs
    {
        public Exception Exception { get; private set; }

        public RelayErrorReceivedArgs(Exception exception)
        {
            this.Exception = exception;
        }
    }
}
