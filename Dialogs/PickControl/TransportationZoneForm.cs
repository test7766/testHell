using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Optimapharm.VKM.S2Lib;
using System.Threading;
using WMSOffice.Classes;
using Optima.Devices.Data.DigitalWeigher;

namespace WMSOffice.Dialogs.PickControl
{
    public partial class TransportationZoneForm : DialogForm
    {
        private int processedItemsCount = 0;

        private readonly RelayProvider relayProvider = null;
        private readonly IObtainWeightProvider swp = null;

        private Dictionary<byte, ZoneStatistics> dZoneStatistics = new Dictionary<byte, ZoneStatistics>();

        public TransportationZoneForm()
        {
            InitializeComponent();

            WeightStabilizator.ID = 0;

            relayProvider = new RelayProvider("192.168.212.250", 9761);
            relayProvider.RelayDataReceived += new EventHandler<RelayDataReceivedArgs>(relayProvider_RelayDataReceived);
            relayProvider.RelayErrorReceived += new EventHandler<RelayErrorReceivedArgs>(relayProvider_RelayErrorReceived);

            swp = new WMSOffice.Classes.A12E.A12ESilentObtainWeightProvider() { AbortTimeout = 10000, WeightTypeID = (int)DataManager.DWType.Lab, MinRatio = 1.0M, LogStabilizatorValues = true, UseStabWeightByRequestMode = false };
            swp.OnComplete += new EventHandler(WeightProvider_OnComplete);

            dZoneStatistics[0] = new ZoneStatistics() { ZoneNumber = 0, WeightProvider = swp, BarCodeBox = tbBarCode1, WeightBox = tbWeight1, ProcessedItemsCountBox = tbWeightCounter1 };
        }

        void relayProvider_RelayErrorReceived(object sender, RelayErrorReceivedArgs e)
        {
            var error = e.Exception;
        }

        void relayProvider_RelayDataReceived(object sender, RelayDataReceivedArgs e)
        {
            if (e.InputNumber == 0)
            {
                if (e.Value == 1)
                {
                    var zone = (byte)0;

                    dZoneStatistics[zone].LastNeedWeight = true;
                    dZoneStatistics[zone].WeightProvider.Run();
                }
            }
        }

        void WeightProvider_OnComplete(object sender, EventArgs e)
        {
            // Есть риск получить неверное значение, т.к. в провайдере идет сброс параметра сразу после генерации данного события
            var weightObtained = (sender as IObtainWeightProvider).WeightObtained;

            this.ThreadSafeDelegate(() =>
            {
                var currentWeight = (double?)null;
                var errorMessage = (string)null;

                try
                {
                    if (weightObtained)
                    {
                        var sCurrentWeight = swp.Value;

                        double weight;
                        if (!double.TryParse(sCurrentWeight, out weight))
                            throw new Exception("Вес задан некорректно.");

                        currentWeight = weight;
                    }
                    else
                    {
                        if (swp.Error != null)
                            throw swp.Error;
                        else
                            throw new Exception("ошибка");
                    }
                }
                catch (Exception ex)
                {
                    errorMessage = ex.Message;
                }

                var zone = (byte)0;

                // информация о весе
                dZoneStatistics[zone].WeightBox.Text = string.IsNullOrEmpty(errorMessage) ? currentWeight.ToString() : "ошибка";

                if (weightObtained)
                    dZoneStatistics[zone].WeightBox.BackColor = SystemColors.Window;
                else
                    dZoneStatistics[zone].WeightBox.BackColor = Color.Salmon;

                dZoneStatistics[zone].ProcessedItemsCount++;

                // информация о количестве обработанных ящиков
                dZoneStatistics[zone].ProcessedItemsCountBox.Text = dZoneStatistics[zone].ProcessedItemsCount.ToString();

                dZoneStatistics[zone].LastWeight = currentWeight;
                dZoneStatistics[zone].LastErrorMessage = errorMessage;

                // даем сигнал на продолжение движения
                var relayIndex = zone;
                this.MoveEWCarret(relayProvider.HostName, relayProvider.Port, relayIndex);

                // сохраняем в лог
                using (var adapter = new Data.PickControlTableAdapters.TZ_Check_BarCodeTableAdapter())
                    adapter.SaveRouteLog(this.UserID, dZoneStatistics[zone].LastBarCode, relayProvider.HostName, relayProvider.Port, relayIndex, zone == 0 ? 1 : 0, zone == 1 ? 1 : 0, currentWeight, errorMessage, dZoneStatistics[zone].LastNeedWeight, WeightStabilizator.ID);
            });
        }

        private void ThreadSafeDelegate(MethodInvoker method)
        {
            if (this.InvokeRequired)
                this.BeginInvoke((Delegate)method);
            else
                method();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            btnOK.Visible = false;
            btnCancel.Text = "Закрыть";

            relayProvider.Initialize();
            relayProvider.Connect();

            swp.Initialize();
            swp.Connect();
        }

        /// <summary>
        /// Передача импульса на включение сетевого реле на 1 сек. (для организации смещения ящика дивертером)
        /// </summary>
        private void MoveEWCarret(string hostName, int port, byte relayIndex)
        {
            try
            {
                var number = relayIndex;

                relayProvider.OnOff(number, true, 10);
                Thread.Sleep(100); //Включить реле № на 1 сек.. Если timeout == 0 - постоянно.

                //using (var client = S2Client.CreateClient(hostName, port))
                //{
                //    client.OnOff(number, true, 10); //Включить реле № на 1 сек.. Если timeout == 0 - постоянно.
                //    Thread.Sleep(100);
                //    client.Close();
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void TransportationZoneForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                relayProvider.Disconnect();
                swp.Disconnect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class ZoneStatistics
    {
        public int ZoneNumber { get; set; }
        public IObtainWeightProvider WeightProvider { get; set; }
        //public DataManager.DWType WeightTypeID { get; set; }

        public string LastBarCode { get; set; }
        public bool LastNeedWeight { get; set; }
        public double? LastWeight { get; set; }
        public string LastErrorMessage { get; set; }

        public int ProcessedItemsCount { get; set; }

        public TextBox BarCodeBox { get; set; }
        public TextBox WeightBox { get; set; }
        public TextBox ProcessedItemsCountBox { get; set; }
    }
}
