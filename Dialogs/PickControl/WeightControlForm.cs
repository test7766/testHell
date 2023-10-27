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
    public partial class WeightControlForm : Form
    {
        #region ПОЛЯ И СВОЙСТВА ДАННЫХ

        public readonly StationDataContext stationDataContext = null;

        public int UserID { get; set; }
        public long StationID { get; set; }
        public string StationCode { get; set; }
        public string StationDescription { get; set; }
        public string MoveWCarretIP { get; set; }
        public int MoveWCarretPort { get; set; }
        public byte MoveWCarretValue { get; set; }
        public int WeightTypeID { get; set; }

        public string PreviousBoxBarCode
        {
            get { return tbPreviousBoxBarCode.Text == "-" ? (string)null : tbPreviousBoxBarCode.Text; }
            set { tbPreviousBoxBarCode.Text = string.IsNullOrEmpty(value) ? "-" : value; }
        }

        //public readonly S2Client eWCarretClient = null;

        private readonly System.Windows.Forms.Timer timerMoveWCarret = null;  

        #endregion

        public WeightControlForm(int? stationFlag, int? initMode)
        {
            InitializeComponent();

            var stationType = (StationType)Enum.Parse(typeof(StationType), (stationFlag ?? 0).ToString());
            var mode = Convert.ToInt32(Convert.ToBoolean(stationFlag ?? 0) || Convert.ToBoolean(initMode ?? 0));
            stationDataContext = new StationDataContext((StationType)Enum.Parse(typeof(StationType), (stationFlag ?? 0).ToString())) { StationType = stationType };
            //stationDataContext = new StationDataContext((StationType)Enum.Parse(typeof(StationType), mode.ToString())) { StationType = stationType };
            tbsBoxBarCode.TextChanged += new EventHandler(tbsBoxBarCode_TextChanged);

            timerMoveWCarret = new System.Windows.Forms.Timer();
            timerMoveWCarret.Interval = 15000;
            timerMoveWCarret.Tick += new EventHandler(timerMoveWCarret_Tick);

            //try
            //{
            //    eWCarretClient = S2Client.CreateClient("192.168.212.195", 9761);
            //    Thread.Sleep(100);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            stationDataContext.UserID = this.UserID;
            stationDataContext.StationID = this.StationID;
            stationDataContext.StationCode = this.StationCode;
            stationDataContext.StationDescription = this.StationDescription;

            stationDataContext.OnUpdateView += new EventHandler(stationDataContext_OnUpdateView);

            stationDataContext.StationHandler.OnPostInitialize += new EventHandler(StationHandler_OnPostInitialize);

            Initialize(true);
            
            stationDataContext.StationHandler.Initialize();
            UpdateFetchPickSlipDesign();
        }

        void StationHandler_OnPostInitialize(object sender, EventArgs e)
        {
            try
            {
                var message = (string)null;
                if (stationDataContext.PickSlipNumber.HasValue)
                {
                    message = string.Format("По заданию {0} необходимо взять для отбора следующий ящик:\r\n{1}", stationDataContext.PickSlipNumber, stationDataContext.BoxName);
                    btnReleasePickSlip.Enabled = true;
                }
                else
                {
                    message = string.Format("Нет активных заданий для отбора.");
                    btnFetchPickSlip.Enabled = true;
                    btnReleasePickSlip.Enabled = false;
                }

                this.ShowMessage(message, "ПРОДОЛЖИТЬ (Enter)", Color.Yellow, 1000, true);

                tbsBoxBarCode.Focus();
                tbsBoxBarCode.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ex;
            }
        }

        void stationDataContext_OnUpdateView(object sender, EventArgs e)
        {
            try
            {
                tbStationDescription.Text = string.IsNullOrEmpty(stationDataContext.StationDescription) ? "-" : stationDataContext.StationDescription;
                tbsBoxBarCode.Text = stationDataContext.BoxBarCode;
                tbPickSlipNumber.Text = stationDataContext.PickSlipNumber.HasValue ? stationDataContext.PickSlipNumber.ToString() : "-";
                tbWeight.Text = stationDataContext.Weight.HasValue ? stationDataContext.Weight.ToString() : "-";

                lblBoxName.Text = string.IsNullOrEmpty(stationDataContext.BoxName) ? "-" : stationDataContext.BoxName;
                lblBoxName.Visible = !string.IsNullOrEmpty(stationDataContext.BoxName);

                lblMode.Text = stationDataContext.StationHandler.Mode;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ex;
            }
        }

        void tbsBoxBarCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(stationDataContext.BoxBarCode = tbsBoxBarCode.Text))
                    return;

                CheckBoxBarCode();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ex;
            }
        }

        private void CheckBoxBarCode()
        {
            try
            {
                if (btnObtainWeight.Enabled)
                    Initialize(false);

                if (stationDataContext.StationHandler.CheckBoxBarCode())
                {
                    if (this.ObtainWeight())
                    {
                        this.SaveWeight();
                        UpdateFetchPickSlipDesign();
                    }
                }
                else
                {
                    this.ShowMessage(stationDataContext.WarningMessage, "ПРОДОЛЖИТЬ (Enter)", Color.Yellow, 1000, true);

                    if (stationDataContext.BackupStationDataContext != null)
                    {
                        Initialize(false);
                        this.CheckBoxBarCode();
                        stationDataContext.RestoreFromBackup();

                        stationDataContext.StationHandler.PostInitialize();
                        UpdateFetchPickSlipDesign();
                        return;
                    }
                    else
                    {
                        this.MoveEWCarret();

                        var pickSlipNumber = stationDataContext.PickSlipNumber;
                        Initialize(true);
                        if (stationDataContext.StationHandler is InitStationHandler)
                        {
                            stationDataContext.PickSlipNumber = pickSlipNumber;
                            stationDataContext.StationHandler.PostInitialize();
                            stationDataContext.UpdateView();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowMessage(ex.Message, "ПРОДОЛЖИТЬ (Enter)", Color.Red, 1000, true);

                this.MoveEWCarret();
            }

            tbsBoxBarCode.Focus();
            tbsBoxBarCode.SelectAll();
        }

        private bool ObtainWeight()
        {
            try
            {
                var typeID = this.WeightTypeID; // (int)Optima.Devices.Data.DigitalWeigher.DataManager.DWType.Static;
                var minRatio = 0.5M; //StationType == StationType.PickStation ? 0.5M : StationType == StationType.InitStation ? 0.0005M : 0.0M;
                var success = false;

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
                                throw new Exception("Вес ящика задан некорректно.");

                            //// Преобразование кг в г (для весов на станции ассоциации (временно!!!))
                            //if (StationType == StationType.InitStation)
                            //    currentWeight *= 1000;

                            stationDataContext.Weight = currentWeight;
                            stationDataContext.UpdateView();
                            success = true;
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
                return success;
            }
            catch (Exception ex)
            {
                this.ShowMessage(ex.Message, "ПРОДОЛЖИТЬ (Enter)", Color.Red, 1000, true);

                this.MoveEWCarret();

                btnObtainWeight.Enabled = true;
                return false;
            }
        }

        private void btnObtainWeight_Click(object sender, EventArgs e)
        {
            try
            {
                if (ObtainWeight())
                    SaveWeight();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ex;
            }
        }

        private void SaveWeight()
        {
            try
            {
                stationDataContext.StationHandler.SaveWeight();

                this.ShowMessage("Вес ящика получен", "ПРОДОЛЖИТЬ (Enter)", Color.Yellow, 1000, true);

                this.MoveEWCarret();

                Initialize(true);
                stationDataContext.StationHandler.Initialize();
            }
            catch (Exception ex)
            {
                var message = ex.Message;

                var hasError = false;
                if (message.Contains("#"))
                {
                    var regex = new System.Text.RegularExpressions.Regex(@"^#(?<Tag>\w+)#(?<Message>.+)#", System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Singleline);
                    if (regex.IsMatch(ex.Message))
                    {
                        var match = regex.Match(ex.Message);
                        message = match.Groups["Message"].Value;

                        var tag = match.Groups["Tag"].Value.ToUpper();
                        switch (tag)
                        {
                            case "MONO_PICK":
                                this.ShowMessage(message, "ПРОДОЛЖИТЬ (Enter)", Color.LightBlue, 3000, true);

                                Initialize(true);
                                stationDataContext.StationHandler.Initialize();

                                break;
                            case "SUPER_PICK":
                                this.ShowMessage(message, "ПРОДОЛЖИТЬ (Enter)", Color.Green, 3000, true);

                                Initialize(true);
                                stationDataContext.StationHandler.Initialize();

                                break;
                            default:
                                break;
                        }
                    }
                    else
                        hasError = true;
                }
                else
                    hasError = true;

                if (hasError)
                {
                    this.ShowMessage(message, "ПРОДОЛЖИТЬ (Enter)", Color.Red, 1000, true);

                    this.MoveEWCarret();
                }
            }
        }

        /// <summary>
        /// Передача импульса на включение сетевого реле на 1 сек. (для организации смещения ящика с весов)
        /// </summary>
        private void MoveEWCarret()
        {
            try
            {
                var number = this.MoveWCarretValue;// StationType == StationType.PickStation ? 0 : StationType == StationType.InitStation ? 1 : (byte?)null;
                using (var client = S2Client.CreateClient(this.MoveWCarretIP, this.MoveWCarretPort))// "192.168.212.195", 9761))
                {
                    client.OnOff(number, true, 10); //Включить реле № на 1 сек.. Если timeout == 0 - постоянно.
                    Thread.Sleep(100);
                    client.Close();
                }
            }
            catch (Exception ex)
            {
                this.ShowMessage(ex.Message, "ПРОДОЛЖИТЬ (Enter)", Color.Red, 1000, true);
            }
        }

        private bool NeedMoveCarret()
        {
            var needMoveCarret = true;

            try
            {
                
                var typeID = (int)Optima.Devices.Data.DigitalWeigher.DataManager.DWType.Static;
                var minRatio = 0.5M; //StationType == StationType.PickStation ? 0.5M : StationType == StationType.InitStation ? 0.0005M : 0.0M;

                var weightAnalizer = new ObtainWeightSeriesAnalizer() {  AnalizeDurationTimeout = 2000, WeightTypeID = typeID, MinRatio = minRatio };
                weightAnalizer.OnComplete += delegate(object snd, EventArgs ea)
                {
                    if (weightAnalizer.WeightSeries.Count > 0)
                    {
                        var firstWeight = weightAnalizer.WeightSeries[0].Value;
                        var lastWeight = weightAnalizer.WeightSeries[weightAnalizer.WeightSeries.Count - 1].Value;

                        if (firstWeight > lastWeight /*&& Math.Abs(lastWeight) <= minRatio*/)
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

        private void Initialize(bool fullInitialize)
        {
            try
            {
                stationDataContext.PickSlipNumber = (double?)null;
                btnObtainWeight.Enabled = false;

                stationDataContext.DocType = (string)null;
                stationDataContext.CompanyCode = (string)null;

                if (fullInitialize)
                {
                    PreviousBoxBarCode = stationDataContext.BoxBarCode;
                    stationDataContext.BoxBarCode = string.Empty;
                }

                lblBoxName.Visible = stationDataContext.StationHandler is InitStationHandler;

                stationDataContext.UpdateView();
                tbsBoxBarCode.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ex;
            }
        }

        private void btnFetchPickSlip_Click(object sender, EventArgs e)
        {
            try
            {
                stationDataContext.StationHandler.Initialize();
                if (stationDataContext.PickSlipNumber != null)
                    btnFetchPickSlip.Enabled = false;
            }
            catch (Exception ex)
            {
                this.ShowMessage(ex.Message, "ПРОДОЛЖИТЬ (Enter)", Color.Red, 1000, true);

                tbsBoxBarCode.Focus();
                tbsBoxBarCode.SelectAll();
            }
        }

        private void UpdateFetchPickSlipDesign()
        {
            try
            {
                btnReleasePickSlip.Visible = stationDataContext.StationHandler is InitStationHandler;
                //btnReleasePickSlip.Visible = stationDataContext.StationType == StationType.InitStation;
                btnReleasePickSlip.Enabled = stationDataContext.PickSlipNumber != null;

                btnFetchPickSlip.Visible = stationDataContext.StationHandler is InitStationHandler;
                //btnFetchPickSlip.Visible = stationDataContext.StationType == StationType.InitStation;
                btnFetchPickSlip.Enabled = stationDataContext.PickSlipNumber == null;

                stationDataContext.BoxBarCode = string.Empty;
                stationDataContext.UpdateView();
                tbsBoxBarCode.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ex;
            }
        }

        private void btnReleasePickSlip_Click(object sender, EventArgs e)
        {
            try
            {
                stationDataContext.StationHandler.ReleasePickSlip();
                if (stationDataContext.PickSlipNumber == null)
                    btnFetchPickSlip.Enabled = true;
            }
            catch (Exception ex)
            {
                this.ShowMessage(ex.Message, "ПРОДОЛЖИТЬ (Enter)", Color.Red, 1000, true);

                tbsBoxBarCode.Focus();
                tbsBoxBarCode.SelectAll();
            }
        }

        private void WeightControlForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //try
            //{
            //    if (eWCarretClient != null)
            //    {
            //        eWCarretClient.Close();
            //        Thread.Sleep(100);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void ShowMessage(string message, string buttonText, Color backgroundColor, int timeout, bool autoClose)
        {
            try
            {
                var messageForm = new WMSOffice.Dialogs.PickControl.FullScreenErrorForm(message, buttonText, backgroundColor);
                messageForm.TimeOut = timeout;
                messageForm.AutoClose = autoClose;
                messageForm.ShowDialog();

                // обновляем информацию в маркере
                lblMarker.BackColor = backgroundColor;
                lblMarker.BorderStyle = BorderStyle.FixedSingle;
                toolTip.SetToolTip(lblMarker, message);
            }
            catch
            { 
            
            }
        }
    }

    public class StationDataContext : ICloneable
    {
        public int UserID { get; set; }
        public long StationID { get; set; }
        public string StationCode { get; set; }
        public string StationDescription { get; set; }

        public StationType StationType { get; set; }

        public string BoxBarCode { get; set; }
        public string BoxName { get; set; }
        public double? PickSlipNumber { get; set; }
        public double? Weight { get; set; }

        public string DocType { get; set; }
        public string CompanyCode { get; set; }

        public string WarningMessage { get; set; }

        public StationHandler StationHandler { get; set; }
        public StationDataContext BackupStationDataContext { get; private set; }

        public event EventHandler OnUpdateView;
        public void UpdateView()
        {
            if (OnUpdateView != null)
                OnUpdateView(this, EventArgs.Empty);
        }

        public static StationHandler CreateStationHandler(StationType stationType, StationDataContext stationDataContext)
        {
            switch (stationType)
            {
                case StationType.InitStation:
                    return new InitStationHandler() { StationDataContext = stationDataContext };
                case StationType.PickStation:
                    return new PickStationHandler() { StationDataContext = stationDataContext };
                default:
                    throw new NotImplementedException("Не реализован обработчик для станции указанного типа.");
            }
        }

        public StationDataContext(StationType stationType)
        {
            StationHandler = StationDataContext.CreateStationHandler(stationType, this);
        }

        public void CreateBackup()
        {
            BackupStationDataContext = (StationDataContext)this.Clone();
        }

        public void RestoreFromBackup()
        {
            if (BackupStationDataContext != null)
            {
                foreach (var pi in this.GetType().GetProperties())
                {
                    var bpi = BackupStationDataContext.GetType().GetProperty(pi.Name);
                    if (bpi.CanRead && bpi.CanWrite)
                    {
                        var value = bpi.GetValue(BackupStationDataContext, bpi.GetIndexParameters());
                        pi.SetValue(this, value, pi.GetIndexParameters());
                    }
                }

                BackupStationDataContext = null;
                UpdateView();
            }
        }

        #region ICloneable Members

        public object Clone()
        {
            return (StationDataContext)this.MemberwiseClone();
        }

        #endregion
    }

    public abstract class StationHandler
    {
        public StationDataContext StationDataContext { get; set; }

        public abstract string Mode { get; }

        public event EventHandler OnPostInitialize;
        public void PostInitialize()
        {
            if (OnPostInitialize != null)
                OnPostInitialize(this, EventArgs.Empty);
        }

        public void SaveWeight()
        {
            using (var adapter = new Data.PickControlTableAdapters.WeightControlStationsTableAdapter())
                adapter.UpdateBoxWeightOnPickMode(StationDataContext.PickSlipNumber, StationDataContext.DocType, StationDataContext.CompanyCode, StationDataContext.BoxBarCode, StationDataContext.Weight, StationDataContext.UserID, StationDataContext.StationID, StationDataContext.StationCode);
        }

        public abstract bool CheckBoxBarCode();
        public virtual void Initialize() { }
        public virtual void ReleasePickSlip() { }
    }

    public class InitStationHandler : StationHandler
    {
        public override string Mode { get { return "Ассоциация"; } }

        public override void Initialize()
        {
            var pickSlipNumber = (double?)null;
            var docType = (string)null;
            var companyCode = (string)null;
            var boxName = (string)null;

            using (var adapter = new Data.PickControlTableAdapters.WeightControlStationsTableAdapter())
                adapter.FetchPickSlip(StationDataContext.StationCode, StationDataContext.UserID, ref pickSlipNumber, ref docType, ref companyCode, ref boxName);

            StationDataContext.PickSlipNumber = pickSlipNumber;
            StationDataContext.DocType = docType;
            StationDataContext.CompanyCode = companyCode;
            StationDataContext.BoxName = boxName;

            this.StationDataContext.UpdateView();
            this.PostInitialize();
        }

        public override void ReleasePickSlip()
        {
            using (var adapter = new Data.PickControlTableAdapters.WeightControlStationsTableAdapter())
                adapter.ReleaseActivePickSlip(this.StationDataContext.StationCode, this.StationDataContext.UserID, this.StationDataContext.PickSlipNumber, this.StationDataContext.DocType, this.StationDataContext.CompanyCode);

            StationDataContext.PickSlipNumber = (double?)null;
            StationDataContext.DocType = (string)null;
            StationDataContext.CompanyCode = (string)null;
            StationDataContext.BoxName = (string)null;

            //this.StationDataContext.StationHandler = StationDataContext.CreateStationHandler(StationType.PickStation, this.StationDataContext);

            this.StationDataContext.UpdateView();
            this.PostInitialize();
        }

        public override bool CheckBoxBarCode()
        {
            var needWeightResult = (int?)null;
            var needMessageResult = (string)null;

            using (var adapter = new Data.PickControlTableAdapters.WeightControlStationsTableAdapter())
                adapter.CheckBoxBarCodeInitMode(StationDataContext.PickSlipNumber, StationDataContext.DocType, StationDataContext.CompanyCode, StationDataContext.BoxBarCode, StationDataContext.UserID, ref needWeightResult, ref needMessageResult);

            this.StationDataContext.WarningMessage = needMessageResult;

            // Привязка ящика к сборочному выполнена (ящик подобран под ожидаемый тип)
            if ((needWeightResult ?? 2) == 2)
                return true;

            // Весовой контроль не требуется (ящик не подобран под ожидаемый тип)
            if (needWeightResult.Value == 0)
                return false;

            // Весовой контроль требуется (ящик не подобран под ожидаемый тип)
            if (needWeightResult.Value == 1)
            {
                StationDataContext.CreateBackup();
                StationDataContext.StationHandler = StationDataContext.CreateStationHandler(StationType.PickStation, StationDataContext);

                return false;
            }

            return false;
        }
    }

    public class PickStationHandler : StationHandler
    {
        public override string Mode { get { return "Контроль"; } }

        public override bool CheckBoxBarCode()
        {
            var pickSlipNumber = (double?)null;
            var docType = (string)null;
            var companyCode = (string)null;
            var weightFlag = (int?)null;

            using (var adapter = new Data.PickControlTableAdapters.WeightControlStationsTableAdapter())
                adapter.CheckBoxBarCodePickMode(StationDataContext.BoxBarCode, StationDataContext.UserID, ref pickSlipNumber, ref docType, ref companyCode, ref weightFlag);

            this.StationDataContext.WarningMessage = weightFlag.HasValue && weightFlag.Value == 1 ? (string)null : string.Format("Весовой контроль для указанного ящика не требуется.");

            StationDataContext.PickSlipNumber = pickSlipNumber;
            StationDataContext.DocType = docType;
            StationDataContext.CompanyCode = companyCode;

            this.StationDataContext.UpdateView();

            return weightFlag.HasValue && weightFlag.Value == 1 ? true : false;
        }
    }

    public enum StationType
    {
        /// <summary>
        /// Станция запуска
        /// </summary>
        InitStation = 0,

        /// <summary>
        /// Станция контроля
        /// </summary>
        PickStation = 1
    }
}
