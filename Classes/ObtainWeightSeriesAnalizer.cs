using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.ComponentModel;
using Optima.Devices.Configuration.DigitalWeigher.TVP_12e;
using Optima.Devices.Core.DigitalWeigher.TVP_12e.MessageFormatters.Utils;
using Optima.Devices.Core.DigitalWeigher.TVP_12e;
using System.Security.Principal;
using Optima.Devices.Core.DigitalWeigher.TVP_12e.Commands.Enums;

namespace WMSOffice.Classes
{
    public class ObtainWeightSeriesAnalizer
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        /// <summary>
        /// Таймер продолжительности анализа процесса
        /// </summary>
        private System.Threading.Timer analizeDurationTimer = null;

        /// <summary>
        /// Продолжительность анализа процесса
        /// </summary>
        public int AnalizeDurationTimeout { get; set; }

        /// <summary>
        /// Признак завершения анализа апроцесса
        /// </summary>
        private bool isAnalizeCompleted = false;

        /// <summary>
        /// Тип весов
        /// </summary>
        public int WeightTypeID { get; set; }

        /// <summary>
        /// Минимальный порог взвешивания
        /// </summary>
        public decimal MinRatio { get; set; }

        /// <summary>
        /// Последовательность неприрывных измерений
        /// </summary>
        public List<WeightSeries> WeightSeries { get; private set; }

        public Exception Error { get; private set; }

        /// <summary>
        /// Событие завершения работы провайдера
        /// </summary>
        public event EventHandler OnComplete;
        public void RaiseOnComplete()
        {
            if (OnComplete != null)
                OnComplete(this, EventArgs.Empty);
        }

        public ObtainWeightSeriesAnalizer()
        {
            this.WeightTypeID = (int)Optima.Devices.Data.DigitalWeigher.DataManager.DWType.Static; // по умолчанию статические
            this.MinRatio = 0.5M; // по умолчанию принимается, что минимальный порог задан в граммах

            this.WeightSeries = new List<WeightSeries>();
            analizeDurationTimer = new System.Threading.Timer(new TimerCallback(AnalizeCompleted), this, Timeout.Infinite, Timeout.Infinite);
        }

        private static void AnalizeCompleted(object target)
        {
            var owp = target as ObtainWeightSeriesAnalizer;
            owp.isAnalizeCompleted = true;
            owp.analizeDurationTimer.Change(Timeout.Infinite, Timeout.Infinite);
        }

        public void Run()
        {
            try
            {
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
                            analizeDurationTimer.Change(AnalizeDurationTimeout, Timeout.Infinite);

                            while (true)
                            {
                                if (isAnalizeCompleted)
                                    break;

                                //if (WeightObtained)
                                //    break;

                                //if (isAborted)
                                //    throw new Exception("Операция не выполнилась за отведенное ей время.");
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

                    splashForm.ActionText = "Выполняется анализ данных цифровых весов..";
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
                        PopulateWeight(message.WValue);
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

        private void PopulateWeight(object oWeight)
        {
            if (isAnalizeCompleted)
                return;

            var weight = oWeight.ToString();
            weight = weight.Replace(" ", string.Empty);

            var separator = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;

            decimal parsedWeight;
            if (decimal.TryParse((weight = weight.Replace(".", separator).Replace(",", separator)), out parsedWeight))
            {
                if (parsedWeight == 0.0M)
                    weight = weight.Replace("-", string.Empty);

                if (Math.Abs(parsedWeight) > this.MinRatio)
                    this.WeightSeries.Add(new WeightSeries(DateTime.Now, parsedWeight));
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
    }

    public class WeightSeries
    {
        public DateTime Time { get; private set; }
        public decimal Value { get; private set; }

        public WeightSeries(DateTime time, decimal value)
        {
            Time = time;
            Value = value;
        }

        public override string ToString()
        {
            return string.Format("{0} : {1}", Time, Value);
        }
    }
}
