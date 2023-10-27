using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Classes;
using Optimapharm.VKM.S2Lib;
using System.Threading;

namespace WMSOffice.Dialogs.PickControl
{
    public partial class WeightControlTestForm : DialogForm
    {
        public string MoveWCarretIP { get; set; }

        public int MoveWCarretPort { get; set; }

        public byte MoveWCarretValue { get; set; }

        private readonly System.Windows.Forms.Timer timerMoveWCarret = null;  

        public WeightControlTestForm()
        {
            InitializeComponent();

            MoveWCarretIP = "192.168.212.195";
            MoveWCarretPort = 9761;
            MoveWCarretValue = 0;

            timerMoveWCarret = new System.Windows.Forms.Timer();
            timerMoveWCarret.Interval = 15000;
            timerMoveWCarret.Tick += new EventHandler(timerMoveWCarret_Tick);
        }

        private void btnObtainWeight_Click(object sender, EventArgs e)
        {
            try
            {
                var typeID = (int)Optima.Devices.Data.DigitalWeigher.DataManager.DWType.Lab;
                var minRatio = 0.5M;

                var weightProvider = new ObtainWeightProvider() { AbortTimeout = 10000, WeightTypeID = typeID, MinRatio = minRatio };
                weightProvider.OnComplete += delegate(object snd, EventArgs ea)
                {
                    try
                    {
                        if (weightProvider.WeightObtained)
                        {
                            var sCurrentWeight = weightProvider.Value;
                            double currentWeight;

                            if (!double.TryParse(sCurrentWeight, out currentWeight))
                                throw new Exception("Вес ящика задан некорректно");

                            tbWeight.Text = currentWeight.ToString();

                            var color = Color.Green;
                            var messageForm = new WMSOffice.Dialogs.PickControl.FullScreenErrorForm("Вес получен", "ПРОДОЛЖИТЬ (Enter)", color);
                            messageForm.TimeOut = 1000;
                            messageForm.AutoClose = true;
                            messageForm.ShowDialog();

                            this.MoveEWCarret();
                        }
                        else
                        {
                            if (weightProvider.Error != null)
                                throw new Exception(weightProvider.Error.Message);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                };

                // Запускаем фоновый поток
                weightProvider.Run();
            }
            catch (Exception ex)
            {
                var color = Color.Red;
                var messageForm = new WMSOffice.Dialogs.PickControl.FullScreenErrorForm(ex.Message, "ПРОДОЛЖИТЬ (Enter)", color);
                messageForm.TimeOut = 1000;
                messageForm.AutoClose = true;
                messageForm.ShowDialog();

                this.MoveEWCarret();
            }
        }

        private void MoveEWCarret()
        {
            try
            {
                var number = this.MoveWCarretValue;
                using (var client = S2Client.CreateClient(this.MoveWCarretIP, this.MoveWCarretPort))
                {
                    client.OnOff(number, true, 10);

                    if (NeedMoveCarret())
                        timerMoveWCarret.Enabled = true;

                    Thread.Sleep(100);
                    client.Close();
                }
            }
            catch (Exception ex)
            {
                var color = Color.Red;
                var messageForm = new WMSOffice.Dialogs.PickControl.FullScreenErrorForm(ex.Message, "ПРОДОЛЖИТЬ (Enter)", color);
                messageForm.TimeOut = 1000;
                messageForm.AutoClose = false;
                messageForm.ShowDialog();
            }
        }

        private bool NeedMoveCarret()
        {
            var needMoveCarret = true;

            try
            {

                var typeID = (int)Optima.Devices.Data.DigitalWeigher.DataManager.DWType.Static;
                var minRatio = 0.5M;

                var weightAnalizer = new ObtainWeightSeriesAnalizer() { AnalizeDurationTimeout = 2000, WeightTypeID = typeID, MinRatio = minRatio };
                weightAnalizer.OnComplete += delegate(object snd, EventArgs ea)
                {
                    if (weightAnalizer.WeightSeries.Count > 0)
                    {
                        var firstWeight = weightAnalizer.WeightSeries[0].Value;
                        var lastWeight = weightAnalizer.WeightSeries[weightAnalizer.WeightSeries.Count - 1].Value;

                        if (firstWeight > lastWeight && Math.Abs(lastWeight) <= minRatio)
                        {
                            needMoveCarret = false;
                        }
                    }
                };

                weightAnalizer.Run();
            }
            catch (Exception ex)
            {

            }

            return needMoveCarret;
        }

        void timerMoveWCarret_Tick(object sender, EventArgs e)
        {
            timerMoveWCarret.Enabled = false;
            this.MoveEWCarret();
        }
    }
}
