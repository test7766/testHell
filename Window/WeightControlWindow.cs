using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Classes;
using WMSOffice.Dialogs.PickControl;

namespace WMSOffice.Window
{
    [Obsolete("Решение более не используется")]
    public partial class WeightControlWindow : GeneralWindow
    {
        #region ПОЛЯ И СВОЙСТВА ДАННЫХ

        private readonly ObtainWeightProvider weightProvider = new ObtainWeightProvider() { AbortTimeout = 10000 };

        public long? CurrentDocID {get; private set;}

        private int? _CurrentPickID = null;
        public int? CurrentPickID
        {
            get { return _CurrentPickID; }
            private set
            {
                _CurrentPickID = value;
                lblPickID.Text = _CurrentPickID.HasValue ? string.Format("{0}", _CurrentPickID) : "-";
            }
        }

        private double? _CurrentPlanWeight = null;
        public double? CurrentPlanWeight 
        {
            get { return _CurrentPlanWeight; }
            private set
            {
                _CurrentPlanWeight = value;
                lblPlanWeight.Text = _CurrentPlanWeight.HasValue ? string.Format("{0}", _CurrentPlanWeight) : "-";
            }
        }

        #endregion

        public WeightControlWindow()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.RefreshData();
            this.Initialize();
        }

        /// <summary>
        /// Инициализация
        /// </summary>
        private void Initialize()
        {
            this.CurrentDocID = (long?)null;
            this.CurrentPickID = (int?)null;
            this.CurrentPlanWeight = (double?)null;

            stbBoxScanner.Text = string.Empty;
            stbBoxScanner.Focus();
            stbBoxScanner.SelectAll();
        }

        private void stbBoxScanner_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(stbBoxScanner.Text) && this.CreateDoc(stbBoxScanner.Text))
            {
                this.RefreshData();
                this.CheckDoc();
            }

            stbBoxScanner.Focus();
            stbBoxScanner.SelectAll();
        }

        /// <summary>
        /// Создание документа весового контроля
        /// </summary>
        /// <param name="boxBarCode"></param>
        /// <returns></returns>
        private bool CreateDoc(string boxBarCode)
        {
            try
            {
                var docID = (long?)null;
                var pickID = (int?)null;
                var planWeight = (double?)null;
                var errorCode = (int?)null;
                var errorMessage = (string)null;

                weightControlDocsTableAdapter.CreateDoc(this.UserID, boxBarCode, ref docID, ref pickID, ref planWeight, ref errorCode, ref errorMessage);

                if ((errorCode.HasValue && errorCode.Value > 0)) // || !string.IsNullOrEmpty(errorMessage))
                {
                    this.SetMessage(MessageType.Error, errorMessage);
                    return false;
                }

                this.CurrentDocID = docID;
                this.CurrentPickID = pickID;
                this.CurrentPlanWeight = planWeight;
                this.SetMessage(MessageType.Information, "-");

                return true;
            }
            catch (Exception ex)
            {
                this.SetMessage(MessageType.Error, ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Получение фактического веса ящика с отобранным товаром
        /// </summary>
        private void CheckDoc()
        {
            try
            {
                weightProvider.OnComplete -= new EventHandler(weightProvider_OnComplete);
                weightProvider.OnComplete += new EventHandler(weightProvider_OnComplete);

                // Запускаем фоновый поток
                weightProvider.Run();
            }
            catch (Exception ex)
            {
                this.SetMessage(MessageType.Error, ex.Message);
                this.Initialize();
            }
        }

        void weightProvider_OnComplete(object sender, EventArgs e)
        {
            try
            {
                if (weightProvider.WeightObtained)
                {
                    var sCurrentWeight = weightProvider.Value; 
                    double currentWeight;

                    if (!double.TryParse(sCurrentWeight, out currentWeight))
                        throw new Exception("Вес ящика задан некорректно.");

                    if (this.CheckDoc(currentWeight))
                    {
                        this.RefreshData();
                        this.Initialize();
                    }
                }
                else
                {
                    if (weightProvider.Error != null)
                        throw new Exception(weightProvider.Error.Message);
                }
            }
            catch (Exception ex)
            {
                this.SetMessage(MessageType.Error, ex.Message);
            }

            stbBoxScanner.Focus();
            stbBoxScanner.SelectAll();
        }

        /// <summary>
        /// Сохранение фактического веса в документе весового контроля 
        /// </summary>
        /// <param name="factWeight"></param>
        private bool CheckDoc(double factWeight)
        {
            try
            {
                var actionID = (int?)null;
                var reasonCode = (int?)null;
                var reasonName = (string)null;

                weightControlDocsTableAdapter.CheckDoc(this.UserID, this.CurrentDocID, factWeight, ref actionID, ref reasonCode, ref reasonName);

                var messageText = string.IsNullOrEmpty(reasonName) ? "-" : reasonName;

                if (actionID.HasValue)
                {
                    switch (actionID.Value)
                    { 
                        case 1: // весовой контроль пройден
                            this.SetMessage(MessageType.Recomendation, messageText);
                            break;
                        case 0: // требуется поштучный контроль
                            this.SetMessage(MessageType.Error, messageText);
                            break;
                        default:
                            break;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                this.SetMessage(MessageType.Error, ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Получение документов контроля
        /// </summary>
        private void RefreshData()
        {
            try
            {
                weightControlDocsTableAdapter.Fill(pickControl.WeightControlDocs, this.UserID);
            }
            catch (Exception ex)
            {
                this.SetMessage(MessageType.Error, ex.Message);
            }
        }

        private void dgvDocs_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow dr in dgvDocs.Rows)
            {
                var drDoc = (dr.DataBoundItem as DataRowView).Row as Data.PickControl.WeightControlDocsRow;
                var actionID = drDoc.Isaction_idNull() ? (int?)null : drDoc.action_id;

                if (actionID.HasValue)
                {
                    var color = Color.Empty;
                    switch (actionID.Value)
                    { 
                        case 1: // весовой контроль пройден
                            color = Color.Green;
                            break;
                        case 0: //требуется поштучный контроль
                            color = Color.Red;
                            break;
                    }

                    foreach (DataGridViewCell cell in dr.Cells)
                    {
                        cell.Style.BackColor = SystemColors.Window;
                        cell.Style.SelectionForeColor = SystemColors.Window;

                        cell.Style.ForeColor = color;
                        cell.Style.SelectionBackColor = color;
                    }
                }
            }
        }

        /// <summary>
        /// Формирование сообщения с форматированным выводом
        /// </summary>
        /// <param name="messageType"></param>
        /// <param name="messageText"></param>
        private void SetMessage(MessageType messageType, string messageText)
        {
            var messageColor = Color.Empty;
            switch (messageType)
            {
                case MessageType.Information: // информация
                    messageColor = SystemColors.ControlText;
                    break;
                case MessageType.Recomendation: // рекомендация
                    messageColor = Color.Green;
                    break;
                case MessageType.Error: // ошибка
                    messageColor = Color.Red;
                    break;
                default:
                    break;
            }

            lblResult.ForeColor = messageColor;
            lblResult.Text = messageText;

            if (messageType != MessageType.Information)
            {
                var messageForm = new FullScreenErrorForm(messageText, "Окно закроется автоматически.\r\n(пожалуйста, подождите...)", messageColor);
                messageForm.TimeOut = 1000;
                messageForm.AutoClose = true;
                messageForm.ShowDialog();
            }
        }

        /// <summary>
        /// Тип сообщения
        /// </summary>
        private enum MessageType
        {
            /// <summary>
            /// Информация
            /// </summary>
            Information = -1,

            /// <summary>
            /// Рекомендация
            /// </summary>
            Recomendation = 0,

            /// <summary>
            /// Ошибка
            /// </summary>
            Error = 1
        }
    }
}
