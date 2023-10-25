using System;
using System.Collections.Generic;
using System.Text;
using WMSOffice.Dialogs.PickControl;
using Optima.Devices.Configuration.DigitalWeigher.TVP_12e;
using Optima.Devices.Core.DigitalWeigher.TVP_12e;
using System.Security.Principal;
using System.Windows.Forms;
using Optima.Devices.Core.DigitalWeigher.TVP_12e.MessageFormatters.Utils;
using System.Threading;
using Optima.Devices.Core.DigitalWeigher.TVP_12e.Commands.Enums;
using System.Drawing;
using System.ComponentModel;
using Optima.Devices.Core.DigitalWeigher.TVP_12e.Commands;
using Optima.Devices.Core.DigitalWeigher.TVE.MessageFormatters;
using System.Text.RegularExpressions;
using System.Net.Sockets;
using Optima.Devices.Core.DigitalWeigher.A12E;
using Optima.Devices.Core.DigitalWeigher.A12E.Providers;

namespace WMSOffice.Classes
{
    public interface IObtainWeightProvider
    {
        event EventHandler OnComplete;
        void Run();
        void Initialize();
        void Connect();
        void Disconnect();
        string Value { get; }
        Exception Error { get; }
        bool WeightObtained { get; }
    }

    public class ObtainWeightProvider : IObtainWeightProvider
    {
        /// <summary>
        /// Стабилизатор веса
        /// </summary>
        private WeightStabilizator weightStabilizator = null;

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        /// <summary>
        /// Таймер прерывания процесса
        /// </summary>
        private System.Threading.Timer abortTimer = null;

        /// <summary>
        /// Признак прерывания процесса
        /// </summary>
        private bool isAborted = false;

        /// <summary>
        /// Время ожидания до прерывания процесса
        /// </summary>
        public int AbortTimeout { get; set; }


        /// <summary>
        /// Тип весов
        /// </summary>
        public int WeightTypeID { get; set; }

        /// <summary>
        /// Минимальный порог взвешивания
        /// </summary>
        public decimal MinRatio { get; set; }

        /// <summary>
        /// Разрешающий признак фиксации только положительного веса
        /// </summary>
        private bool AllowPositiveWeightOnly { get; set; }

        /// <summary>
        /// Событие завершения работы провайдера
        /// </summary>
        public event EventHandler OnComplete;
        public void RaiseOnComplete()
        {
            if (OnComplete != null)
                OnComplete(this, EventArgs.Empty);
        }

        public bool WeightObtained { get; private set; }
        public string Value { get; private set; }
        public Exception Error { get; private set; }

        public ObtainWeightProvider()
        {
            this.AllowPositiveWeightOnly = true;

            this.WeightTypeID = (int)Optima.Devices.Data.DigitalWeigher.DataManager.DWType.Static; // по умолчанию статические
            this.MinRatio = 0.5M; // по умолчанию принимается, что минимальный порог задан в граммах

            abortTimer = new System.Threading.Timer(new TimerCallback(Abort), this, Timeout.Infinite, Timeout.Infinite);
        }

        public void Initialize()
        {
            isAborted = false;

            Error = null;
            Value = string.Empty;
            WeightObtained = false;

            weightStabilizator = new WeightStabilizator(this.MinRatio, 25);
        }

        public void Connect()
        { 
        
        }

        public void Disconnect()
        {

        }

        public void Run()
        {
            try
            {
                Initialize();

                var wConfiguration = WConfigurationHelper.CreateConfiguration(WindowsIdentity.GetCurrent().Name, this.WeightTypeID);
                if (wConfiguration != null)
                {
                    var wController = new WController(wConfiguration.CreateProvider(), wConfiguration.Address);
                    wController.WMessageCallback += new EventHandler<WMessageCallbackEventArgs>(wController_WMessageCallback);

                    var loadWoker = new BackgroundWorker();
                    loadWoker.DoWork += delegate(object sender, DoWorkEventArgs e)
                    {
                        try
                        {
                            wController.Connect();
                            abortTimer.Change(AbortTimeout, Timeout.Infinite);

                            while (true)
                            {
                                if (WeightObtained)
                                    break;

                                if (isAborted)
                                    throw new Exception("Операция не выполнилась за отведенное ей время.");
                            }
                        }
                        catch (Exception ex)
                        {
                            e.Result = ex;
                        }
                    };
                    loadWoker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
                    {
                        if (e.Result is Exception)
                            this.Error = e.Result as Exception;

                        wController.Disconnect();
                        splashForm.CloseForce();
                    };

                    splashForm.ActionText = "Выполняется получение данных с цифровых весов..";
                    loadWoker.RunWorkerAsync();
                    splashForm.ShowDialog();

                    // Уведомляем клиента о завершении работы с весами
                    RaiseOnComplete();
                }
                else
                    throw new Exception("Конфигурация цифровых весов не настроена для вашего пользователя. Обратитесь к администраторам WMS.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void wController_WMessageCallback(object sender, Optima.Devices.Core.DigitalWeigher.TVP_12e.MessageFormatters.Utils.WMessageCallbackEventArgs e)
        {
            try
            {
                Error = null;

                var message = e.Message;
                switch (message.WCommandActionType)
                {
                    case WCommandActionType.W:
                        UpdateWeight(message.WValue, message.WUoM);
                        break;
                    case WCommandActionType.E:
                        UpdateErrors(message.WErrors);
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
                Error = ex;
            }
        }

        private void UpdateWeight(object oWeight, string uom)
        {
            if (WeightObtained)
                return;

            var weight = oWeight.ToString();
            weight = weight.Replace(" ", string.Empty);

            var separator = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;

            decimal parsedWeight;
            if (decimal.TryParse((weight = weight.Replace(".", separator).Replace(",", separator)), out parsedWeight))
            {
                // Если весы напольные и возвращают вес в граммах, то значение переводим в килограммы
                if (this.WeightTypeID == (int)Optima.Devices.Data.DigitalWeigher.DataManager.DWType.Static && "g".Equals(uom, StringComparison.OrdinalIgnoreCase))
                {
                    parsedWeight /= 1000;
                    weight = parsedWeight.ToString();
                }

                if (parsedWeight == 0.0M)
                    weight = weight.Replace("-", string.Empty);

                Value = weight;

                if (Math.Abs(parsedWeight) > weightStabilizator.Treshold && ((this.AllowPositiveWeightOnly && parsedWeight > 0.0M) || !this.AllowPositiveWeightOnly))
                    weightStabilizator.ProcessCurrentValue(parsedWeight);

                if (weightStabilizator.IsStabilityValue)
                    WeightObtained = true;
            }
        }

        private void UpdateErrors(object oErrors)
        {
            var errors = (List<string>)oErrors;
            var sbErrors = new StringBuilder();

            foreach (var error in errors)
            {
                if (sbErrors.Length == 0)
                    sbErrors.AppendFormat("{0}", error);
                else
                    sbErrors.AppendFormat("\r\n{0}", error);
            }

            throw new Exception(sbErrors.ToString());
        }

        private static void Abort(object target)
        {
            var owp = target as ObtainWeightProvider;
            owp.isAborted = true;
            owp.abortTimer.Change(Timeout.Infinite, Timeout.Infinite);
        }
    }

    public class SilentObtainWeightProvider : IObtainWeightProvider
    {
        /// <summary>
        /// Фиксировать в логе промежуточные значения алгоритма стабилизации
        /// </summary>
        public bool LogStabilizatorValues { get; set; }

        /// <summary>
        /// Режим получения стабильного веса по запросу
        /// </summary>
        public bool UseStabWeightByRequestMode { get; set; }

        /// <summary>
        /// Контроллер
        /// </summary>
        private WController wController = null;

        /// <summary>
        /// Стабилизатор веса
        /// </summary>
        private WeightStabilizator weightStabilizator = null;

        /// <summary>
        /// Таймер прерывания процесса
        /// </summary>
        private System.Threading.Timer abortTimer = null;

        /// <summary>
        /// Признак прерывания процесса
        /// </summary>
        private bool isAborted = false;

        /// <summary>
        /// Время ожидания до прерывания процесса
        /// </summary>
        public int AbortTimeout { get; set; }

        /// <summary>
        /// Тип весов
        /// </summary>
        public int WeightTypeID { get; set; }

        /// <summary>
        /// Минимальный порог взвешивания
        /// </summary>
        public decimal MinRatio { get; set; }

        /// <summary>
        /// Разрешающий признак фиксации только положительного веса
        /// </summary>
        private bool AllowPositiveWeightOnly { get; set; }

        /// <summary>
        /// Весы выполняют взвешивание с учетом стабилизации
        /// </summary>
        public bool IsBusy { get; private set; }

        /// <summary>
        /// Событие завершения работы провайдера
        /// </summary>
        public event EventHandler OnComplete;
        public void RaiseOnComplete()
        {
            if (OnComplete != null)
                OnComplete(this, EventArgs.Empty);
        }

        public bool WeightObtained { get; private set; }
        public string Value { get; private set; }
        public Exception Error { get; private set; }

        public SilentObtainWeightProvider()
        {
            this.AllowPositiveWeightOnly = true;

            this.WeightTypeID = (int)Optima.Devices.Data.DigitalWeigher.DataManager.DWType.Static; // по умолчанию статические
            this.MinRatio = 0.5M; // по умолчанию принимается, что минимальный порог задан в граммах

            abortTimer = new System.Threading.Timer(new TimerCallback(Abort), this, Timeout.Infinite, Timeout.Infinite);
            //weightStabilizator = new WeightStabilizator(this.MinRatio, 25);
        }

        public void Initialize()
        {
            try
            {
                var wConfiguration = WConfigurationHelper.CreateConfiguration("optima2k\\sklibra07"/*WindowsIdentity.GetCurrent().Name*/, this.WeightTypeID);
                if (wConfiguration != null)
                {
                    wController = new WController(wConfiguration.CreateProvider(), wConfiguration.Address);
                    //wController.WMessageCallback += new EventHandler<WMessageCallbackEventArgs>(wController_WMessageCallback);

                    wController.WMessageCallback += (s, e) =>
                    {
                        if (!IsBusy)
                            return;

                        try
                        {
                            //System.Diagnostics.Debug.WriteLine(e.Message.WValue);

                            //weightStabilizator = new WeightStabilizator(this.MinRatio, 25);

                            //while (true)
                            //{
                                if (WeightObtained)
                                    return; //break;

                                if (isAborted)
                                    throw new Exception("Операция не выполнилась за отведенное ей время.");

                                Error = null;

                                var message = e.Message;
                                switch (message.WCommandActionType)
                                {
                                    case WCommandActionType.W:
                                        UpdateWeight(message.WValue);
                                        if (WeightObtained)
                                            break; // выходим из switch, выполняем инициацию завершения обработки веса
                                        else
                                            return; // выходим из switch и метода
                                    case WCommandActionType.E:
                                        try
                                        {
                                            UpdateErrors(message.WErrors);
                                            return;
                                        }
                                        catch
                                        {
                                            return;
                                        }
                                        //break;
                                    default:
                                        return; //break;
                                }
                            //}
                        }
                        catch (ThreadAbortException ex)
                        {

                        }
                        catch (Exception ex)
                        {
                            Error = ex;
                        }

                        //abortTimer.Change(AbortTimeout, Timeout.Infinite);

                        // Уведомляем клиента о завершении работы с весами
                        RaiseOnComplete();

                        IsBusy = false;
                        WeightObtained = false;
                    };
                }
                else
                    throw new Exception("Конфигурация цифровых весов не настроена для вашего пользователя. Обратитесь к администраторам WMS.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Connect()
        {
            try
            {
                wController.Connect();
                IsBusy = false;
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
                wController.Disconnect();
                IsBusy = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Run() 
        {
            isAborted = false;

            Error = null;
            Value = string.Empty;
            WeightObtained = false;

            if (weightStabilizator != null) weightStabilizator.CloseSW();

            var screenWidth = this.UseStabWeightByRequestMode ? 1 : 25;
            weightStabilizator = new WeightStabilizator(this.MinRatio, screenWidth, this.LogStabilizatorValues);
            
            IsBusy = true;

            // Запрос на получение стабильного веса
            if (this.UseStabWeightByRequestMode)
                wController.SendMessage(new WCommandW<WSmartMessage>().Execute());

            abortTimer.Change(AbortTimeout, Timeout.Infinite);
        }

        public void Stop()
        { 
        
        }

        //void wController_WMessageCallback(object sender, Optima.Devices.Core.DigitalWeigher.TVP_12e.MessageFormatters.Utils.WMessageCallbackEventArgs e)
        //{
        //    try
        //    {
        //        Error = null;

        //        var message = e.Message;
        //        switch (message.WCommandActionType)
        //        {
        //            case WCommandActionType.W:
        //                UpdateWeight(message.WValue);
        //                break;
        //            case WCommandActionType.E:
        //                UpdateErrors(message.WErrors);
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    catch (ThreadAbortException ex)
        //    {

        //    }
        //    catch (Exception ex)
        //    {
        //        Error = ex;
        //    }
        //}

        private void UpdateWeight(object oWeight)
        {
            if (WeightObtained)
                return;

            var weight = oWeight.ToString();
            weight = weight.Replace(" ", string.Empty);

            var separator = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;

            decimal parsedWeight;
            if (decimal.TryParse((weight = weight.Replace(".", separator).Replace(",", separator)), out parsedWeight))
            {
                if (parsedWeight == 0.0M)
                    weight = weight.Replace("-", string.Empty);

                Value = weight;

                if (Math.Abs(parsedWeight) > weightStabilizator.Treshold && ((this.AllowPositiveWeightOnly && parsedWeight > 0.0M) || !this.AllowPositiveWeightOnly))
                    weightStabilizator.ProcessCurrentValue(parsedWeight);

                if (weightStabilizator.IsStabilityValue)
                {
                    WeightObtained = true;
                    weightStabilizator.CloseSW();
                }
            }
        }

        private void UpdateErrors(object oErrors)
        {
            var errors = (List<string>)oErrors;
            var sbErrors = new StringBuilder();

            foreach (var error in errors)
            {
                if (sbErrors.Length == 0)
                    sbErrors.AppendFormat("{0}", error);
                else
                    sbErrors.AppendFormat("\r\n{0}", error);
            }

            throw new Exception(sbErrors.ToString());
        }

        private static void Abort(object target)
        {
            var owp = target as SilentObtainWeightProvider;
            owp.isAborted = true;
            owp.abortTimer.Change(Timeout.Infinite, Timeout.Infinite);
        }
    }

    public class WeightStabilizator
    {
        public decimal Value { get; private set; }

        public decimal Treshold { get; private set; }
        public int MinIterationsCount { get; private set; }

        public bool IsStabilityValue { get; private set; }

        private decimal previousValue;
        private int cntIterations = 0;

        private readonly string path = null;
        private readonly System.IO.StreamWriter sw = null;
        public static int ID { get; set; } 

        public WeightStabilizator(decimal treshold, int minIterationsCount)
        {
            Treshold = treshold;
            MinIterationsCount = minIterationsCount;
            previousValue = Value = 0.0M;
        }

        public WeightStabilizator(decimal treshold, int minIterationsCount, bool logStabilizatorValues)
            : this(treshold, minIterationsCount)
        {
            if (logStabilizatorValues)
            {
                path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "weights.txt");
                sw = new System.IO.StreamWriter(path, true);
                WeightStabilizator.ID++;
            }
        }

        public void ProcessCurrentValue(decimal currentValue)
        {
            LogWeight(sw, currentValue);

            Value = currentValue;

            // костыль при получении стабильного веса на весах (размер экрана = 1 и режим by stab)
            if (this.MinIterationsCount == 1)
            {
                IsStabilityValue = true;
                return;
            }

            cntIterations++;
            if (CompareValues(Value, previousValue, this.Treshold))
            {
                if (cntIterations == this.MinIterationsCount)
                    IsStabilityValue = true;
            }
            else
            {
                cntIterations = 0;
                previousValue = Value;
            }
        }

        private static bool CompareValues(decimal valueFirst, decimal valueSecond, decimal treshold)
        {
            return Math.Abs(valueFirst - valueSecond) <= treshold;
        }

        public void CloseSW()
        {
            try
            {
                if (sw != null)
                    sw.Close();
            }
            catch (Exception)
            {
               
            }
        }

        private static void LogWeight(System.IO.StreamWriter sw, decimal weight)
        {
            try
            {
                if (sw != null)
                    sw.WriteLine(string.Format("{0}; {1}; {2}", DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture), WeightStabilizator.ID, weight));
            }
            catch (Exception)
            {

            }
        }
    }

    namespace A12E
    {
        //public class A12EController : IDisposable
        //{
        //    private readonly A12EProvider wProvider = null;

        //    public bool Ready { get { return wProvider.Ready; } }

        //    public event EventHandler<A12EMessageCallbackEventArgs> WMessageCallback;
        //    private void OnWMessageCallback(A12EMessage message)
        //    {
        //        if (message != null)
        //        {
        //            if (WMessageCallback != null)
        //                WMessageCallback(this, new A12EMessageCallbackEventArgs(message));
        //        }
        //    }

        //    public A12EController(A12EProvider iwProvider)
        //    {
        //        wProvider = iwProvider;
        //        wProvider.WMessageCallback += new EventHandler<A12EMessageCallbackEventArgs>(wProvider_WMessageCallback);
        //    }

        //    void wProvider_WMessageCallback(object sender, A12EMessageCallbackEventArgs e)
        //    {
        //        OnWMessageCallback(e.Message);
        //    }

        //    public void Connect()
        //    {
        //        wProvider.Connect();
        //    }

        //    public void Disconnect()
        //    {
        //        wProvider.Disconnect();
        //    }

        //    public void SendMessage(A12EMessage wMessage)
        //    {
        //        wProvider.SendMessage(wMessage);
        //    }

        //    public string GetConnectionParametersString()
        //    {
        //        var sbParameters = new StringBuilder(wProvider.GetConnectionParametersString());
        //        return sbParameters.ToString();
        //    }

        //    #region IDisposable Members

        //    public void Dispose()
        //    {
        //        Disconnect();
        //    }

        //    #endregion
        //}

        //public class A12EProvider
        //{
        //    private const int RECEIVE_BUFFER_SIZE = 8192;

        //    private TcpClient socket = new TcpClient();
        //    public string HostName { get; private set; }
        //    public int Port { get; private set; }

        //    private Thread thCallback;
        //    private readonly A12EMessageBufferFormatter wMessageBufferFormatter = new A12EMessageBufferFormatter();

        //    public A12EProvider(string hostName, int port)
        //    {
        //        HostName = hostName;
        //        Port = port;
        //        wMessageBufferFormatter.WMessageProxyCompleted += new EventHandler<A12EMessageProxyCompletedEventArgs>(wBufferCallback_WMessageProxyCompleted);
        //    }

        //    void wBufferCallback_WMessageProxyCompleted(object sender, A12EMessageProxyCompletedEventArgs e)
        //    {
        //        var messageProxy = e.MessageProxy;
        //        var message = messageProxy.GetMessage();

        //        OnWMessageCallback(message);
        //    }

        //    public bool Ready { get { return socket.Connected; } }

        //    public event EventHandler<A12EMessageCallbackEventArgs> WMessageCallback;
        //    private void OnWMessageCallback(A12EMessage message)
        //    {
        //        if (message != null)
        //        {
        //            if (WMessageCallback != null)
        //                WMessageCallback(this, new A12EMessageCallbackEventArgs(message));
        //        }
        //    }

        //    public void Connect()
        //    {
        //        if (!socket.Connected)
        //        {
        //            socket = new TcpClient();
        //            socket.Connect(HostName, Port);
        //            socket.ReceiveBufferSize = RECEIVE_BUFFER_SIZE;

        //            thCallback = new Thread(GetMessageCallback);
        //            thCallback.Start();
        //        }
        //    }

        //    public void Disconnect()
        //    {
        //        if (socket.Connected)
        //        {
        //            thCallback.Abort();
        //            socket.Client.Disconnect(true);
        //        }
        //    }

        //    public void SendMessage(A12EMessage wMessage)
        //    {
        //        if (socket.Connected)
        //        {
        //            var sw = socket.GetStream();
        //            var buffer = wMessage.GetBuffer();

        //            sw.Write(buffer, 0, buffer.Length);
        //            sw.Flush();
        //        }
        //    }

        //    public string GetConnectionParametersString()
        //    {
        //        var sbParameters = new StringBuilder();
        //        sbParameters.AppendFormat("Имя хоста: {0}\r\n", HostName);
        //        sbParameters.AppendFormat("Порт: {0}\r\n", Port);

        //        return sbParameters.ToString();
        //    }

        //    private void GetMessageCallback()
        //    {
        //        while (true)
        //        {
        //            if (socket.Connected)
        //            {
        //                try
        //                {
        //                    var sr = socket.GetStream();
        //                    if (sr.DataAvailable)
        //                    {
        //                        byte[] bufferCallback = new byte[RECEIVE_BUFFER_SIZE];
        //                        var bufferSize = socket.ReceiveBufferSize;
        //                        var bufferCallbackSize = sr.Read(bufferCallback, 0, bufferSize);

        //                        wMessageBufferFormatter.Populate(bufferCallback, bufferCallbackSize);
        //                    }
        //                }
        //                catch (ThreadAbortException)
        //                {
        //                    break;
        //                }
        //                catch (Exception)
        //                {

        //                }
        //            }
        //        }
        //    }
        //}

        //public class A12EMessageBufferFormatter
        //{
        //    private A12EMessageProxy currentMessage = null;

        //    public event EventHandler<A12EMessageProxyCompletedEventArgs> WMessageProxyCompleted;
        //    private void OnWMessageProxyCompleted(A12EMessageProxy message)
        //    {
        //        if (WMessageProxyCompleted != null)
        //            WMessageProxyCompleted(this, new A12EMessageProxyCompletedEventArgs(message));
        //    }

        //    public void Populate(byte[] wData, int wSize)
        //    {
        //        for (int idx = 0; idx < wSize; idx++)
        //        {
        //            var wItem = wData[idx];

        //            if (currentMessage == null)
        //                currentMessage = new A12EMessageProxy();

        //            if (currentMessage != null && !currentMessage.Completed)
        //            {
        //                currentMessage.Buffer.Add(wItem);

        //                if (wItem == (byte)A12ECommandTailType.LF)
        //                {
        //                    currentMessage.Completed = true;
        //                    OnWMessageProxyCompleted(currentMessage);
        //                    currentMessage = null;

        //                }
        //            }
        //        }
        //    }
        //}

        //public class A12EMessage
        //{
        //    public string WValue { get; set; }
        //    public string WUoM { get; set; }

        //    public A12EMessage(string wValue)
        //    {
        //        this.WValue = wValue;
        //    }

        //    public byte[] GetBuffer()
        //    {
        //        var buffer = new List<byte>();

        //        foreach (char c in WValue)
        //            buffer.Add((byte)c);

        //        buffer.Add((byte)A12ECommandTailType.CR);
        //        buffer.Add((byte)A12ECommandTailType.LF);

        //        return buffer.ToArray();
        //    }
        //}

        //public class A12EMessageProxy
        //{
        //    public List<byte> Buffer { get; private set; }
        //    public bool Completed { get; set; }

        //    public A12EMessageProxy()
        //    {
        //        Buffer = new List<byte>();
        //    }

        //    public A12EMessage GetMessage()
        //    {
        //        if (Completed)
        //        {
        //            var messageParser = new A12EMessageParser(Buffer.ToArray());
        //            return messageParser.Parse();
        //        }

        //        return null;
        //    }
        //}

        //public class A12EMessageParser
        //{
        //    protected readonly byte[] wData = null;

        //    private static readonly Regex wRegex = new Regex(@"^w[w|n|t](?<weight>.*)(?<uom>kg)$", RegexOptions.Singleline);

        //    public A12EMessageParser(byte[] wData)
        //    {
        //        this.wData = wData;
        //    }

        //    public A12EMessage Parse()
        //    {
        //        try
        //        {
        //            var sb = new StringBuilder();
        //            for (int i = 0; i < wData.Length; i++)
        //                sb.Append((char)wData[i]);

        //            var sValue = sb.ToString().TrimEnd('\r', '\n');

        //            if (wRegex.IsMatch(sValue))
        //            {
        //                var wMatch = wRegex.Match(sValue);
        //                var wValue = wMatch.Groups["weight"].Value;
        //                var wUoM = wMatch.Groups["uom"].Value;

        //                return new A12EMessage(wValue) { WUoM = wUoM };
        //            }
        //            else
        //            {
        //                throw new Exception("Вес не был получен.");
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            return null;
        //        }
        //    }
        //}

        //public class A12EMessageCallbackEventArgs : EventArgs
        //{
        //    public A12EMessage Message { get; private set; }
        //    public A12EMessageCallbackEventArgs(A12EMessage message)
        //    {
        //        Message = message;
        //    }
        //}

        //public class A12EMessageProxyCompletedEventArgs : EventArgs
        //{
        //    public A12EMessageProxy MessageProxy { get; private set; }
        //    public A12EMessageProxyCompletedEventArgs(A12EMessageProxy message)
        //    {
        //        MessageProxy = message;
        //    }
        //}

        //public enum A12ECommandTailType
        //{
        //    /// <summary>
        //    /// Конец передачи CR (0x0D)
        //    /// </summary>
        //    CR = 0x0D,

        //    /// <summary>
        //    /// Конец передачи LF (0x0A)
        //    /// </summary>
        //    LF = 0x0A
        //}

       
        // клиент

        public class A12ESilentObtainWeightProvider : IObtainWeightProvider
        {
            /// <summary>
            /// Фиксировать в логе промежуточные значения алгоритма стабилизации
            /// </summary>
            public bool LogStabilizatorValues { get; set; }

            /// <summary>
            /// Режим получения стабильного веса по запросу
            /// </summary>
            public bool UseStabWeightByRequestMode { get; set; }

            /// <summary>
            /// Контроллер
            /// </summary>
            private A12EController wController = null;

            /// <summary>
            /// Стабилизатор веса
            /// </summary>
            private WeightStabilizator weightStabilizator = null;

            /// <summary>
            /// Таймер прерывания процесса
            /// </summary>
            private System.Threading.Timer abortTimer = null;

            /// <summary>
            /// Признак прерывания процесса
            /// </summary>
            private bool isAborted = false;

            /// <summary>
            /// Время ожидания до прерывания процесса
            /// </summary>
            public int AbortTimeout { get; set; }

            /// <summary>
            /// Тип весов
            /// </summary>
            public int WeightTypeID { get; set; }

            /// <summary>
            /// Минимальный порог взвешивания
            /// </summary>
            public decimal MinRatio { get; set; }

            /// <summary>
            /// Весы выполняют взвешивание с учетом стабилизации
            /// </summary>
            public bool IsBusy { get; private set; }

            /// <summary>
            /// Событие завершения работы провайдера
            /// </summary>
            public event EventHandler OnComplete;
            public void RaiseOnComplete()
            {
                if (OnComplete != null)
                    OnComplete(this, EventArgs.Empty);
            }

            public bool WeightObtained { get; private set; }
            public string Value { get; private set; }
            public Exception Error { get; private set; }

            public A12ESilentObtainWeightProvider()
            {
                this.WeightTypeID = (int)Optima.Devices.Data.DigitalWeigher.DataManager.DWType.Static; // по умолчанию статические
                this.MinRatio = 0.5M; // по умолчанию принимается, что минимальный порог задан в граммах

                abortTimer = new System.Threading.Timer(new TimerCallback(Abort), this, Timeout.Infinite, Timeout.Infinite);
                //weightStabilizator = new WeightStabilizator(this.MinRatio, 25);
            }

            public void Initialize()
            {
                try
                {
                    wController = new A12EController(new A12EProvider("192.168.212.48", 9761));
                    //wController.WMessageCallback += new EventHandler<WMessageCallbackEventArgs>(wController_WMessageCallback);

                    wController.WMessageCallback += (s, e) =>
                    {
                        if (!IsBusy)
                            return;

                        try
                        {
                            //System.Diagnostics.Debug.WriteLine(e.Message.WValue);

                            //weightStabilizator = new WeightStabilizator(this.MinRatio, 25);

                            //while (true)
                            //{
                            if (WeightObtained)
                                return; //break;

                            if (isAborted)
                                throw new Exception("Операция не выполнилась за отведенное ей время.");

                            Error = null;

                            var message = e.Message;

                            UpdateWeight(message.WValue);
                            if (WeightObtained)
                            {
                                // Уведомляем клиента о завершении работы с весами
                                RaiseOnComplete();

                                IsBusy = false;
                                WeightObtained = false;
                            }
                            else
                                return;
                        }
                        catch (ThreadAbortException ex)
                        {

                        }
                        catch (Exception ex)
                        {
                            Error = ex;
                        }

                        //abortTimer.Change(AbortTimeout, Timeout.Infinite);
                    };
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void Connect()
            {
                try
                {
                    wController.Connect();
                    IsBusy = false;
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
                    wController.Disconnect();
                    IsBusy = false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void Run()
            {
                isAborted = false;

                Error = null;
                Value = string.Empty;
                WeightObtained = false;

                if (weightStabilizator != null) weightStabilizator.CloseSW();

                var screenWidth = this.UseStabWeightByRequestMode ? 1 : 25;
                weightStabilizator = new WeightStabilizator(this.MinRatio, screenWidth, this.LogStabilizatorValues);

                IsBusy = true;

                abortTimer.Change(AbortTimeout, Timeout.Infinite);
            }

            public void Stop()
            {

            }

            private void UpdateWeight(object oWeight)
            {
                if (WeightObtained)
                    return;

                var weight = oWeight.ToString();
                weight = weight.Replace(" ", string.Empty);

                var separator = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;

                decimal parsedWeight;
                if (decimal.TryParse((weight = weight.Replace(".", separator).Replace(",", separator)), out parsedWeight))
                {
                    if (parsedWeight == 0.0M)
                        weight = weight.Replace("-", string.Empty);

                    Value = weight;

                    if (Math.Abs(parsedWeight) > weightStabilizator.Treshold)
                        weightStabilizator.ProcessCurrentValue(parsedWeight);

                    if (weightStabilizator.IsStabilityValue)
                    {
                        WeightObtained = true;
                        weightStabilizator.CloseSW();
                    }
                }
            }

            private static void Abort(object target)
            {
                var owp = target as A12ESilentObtainWeightProvider;
                owp.isAborted = true;
                owp.abortTimer.Change(Timeout.Infinite, Timeout.Infinite);
            }
        }
    }
}
