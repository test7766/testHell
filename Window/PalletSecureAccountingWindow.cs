using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs;
using WMSOffice.Controls.Custom;
using WMSOffice.Controls.Receive.Pallets;

namespace WMSOffice.Window
{
    public partial class PalletSecureAccountingWindow : GeneralWindow
    {
        #region КОНСТАНТЫ
        /// <summary>
        /// Цвет панели операций для въезда
        /// </summary>
        private readonly Color EntryToolBarBackground = Color.FromArgb(182, 221, 232);

        /// <summary>
        /// Цвет панели операций для выезда
        /// </summary>
        private readonly Color OutgoingToolBarBackground = Color.FromArgb(255, 255, 102);
        #endregion

        #region ПОЛЯ И СВОЙСТВА КЛАССА
        /// <summary>
        /// Рассматриваемый период
        /// </summary>
        public DateTime Period { get; private set; }

        /// <summary>
        /// Признак режима "Начальник охраны"
        /// </summary>
        public bool IsChiefSecurityMode { get; private set; }

        /// <summary>
        /// Содержимое обладающее необходимым  функционалом по учету паллет
        /// </summary>
        private List<PalletsAccountingControl> Content = new List<PalletsAccountingControl>();

        /// <summary>
        /// Список доступных операций c цветом фона
        /// </summary>
        private Dictionary<Image, ToolStripButton> operationButtonImages = new Dictionary<Image, ToolStripButton>();
        #endregion

        public PalletSecureAccountingWindow()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Initialize();
            this.ReloadData();
        }

        private void Initialize()
        {
            tsMainMenu.Items.Clear();

            #region Добавление кнопки "Обновить"
            var sbRefresh = new ToolStripButton();
            sbRefresh.Image = Properties.Resources.refresh;
            sbRefresh.Text = "Обновить";
            sbRefresh.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            sbRefresh.Click += sbRefreshData_Click;
            tsMainMenu.Items.Add(sbRefresh);
            #endregion

            #region Добавление фильтра для выбора периода
            var dtPeriodFilter = new DateTimePicker();
            dtPeriodFilter.Width = 120;
            dtPeriodFilter.Format = DateTimePickerFormat.Custom;
            dtPeriodFilter.CustomFormat = "dd / MM / yyyy";
            dtPeriodFilter.ValueChanged += delegate(object sender, EventArgs ea) { this.Period = dtPeriodFilter.Value.Date; };
            dtPeriodFilter.Value = DateTime.Today.Date;
            tsMainMenu.Items.Add(new ToolStripControlHost(dtPeriodFilter));
            #endregion

            #region Формирование контента
            this.pnlMainLayout.Controls.Clear();

            this.SetUserAccessMode();

            PalletsAccountingControl contentItem = null;
            //if (this.IsChiefSecurityMode) // режим "Начальник охраны"
            //{
            //    this.Content.Add(contentItem = new PalletsAccountingControl()
            //    {
            //        UserID = this.UserID,
            //        Period = DateTime.Today,
            //        ViewSearchDirectionType = ViewSearchDirectionType.Both,
            //        Dock = DockStyle.Fill,
            //    });
            //    contentItem.OnNeedReloadData += new EventHandler(contentItem_OnNeedReloadData);
            //}
            //else // режим "Охранник"
            {
                #region Добавим "Разделитель"
                tsMainMenu.Items.Add(new ToolStripLabel(string.Empty.PadLeft(3, ' ')));
                tsMainMenu.Items.Add(new ToolStripSeparator());
                tsMainMenu.Items.Add(new ToolStripLabel(string.Empty.PadLeft(3, ' ')));
                #endregion

                #region Формирование контента для операции въезда
                this.Content.Add(contentItem = new PalletsAccountingControl()
                {
                    UserID = this.UserID,
                    Period = DateTime.Today,
                    ViewSearchDirectionType = ViewSearchDirectionType.Entry,
                    IsChiefSecurityMode = this.IsChiefSecurityMode,
                    ToolBarBackground = this.EntryToolBarBackground,
                    LinkedOperationImage = Properties.Resources.blue_squere,
                    Dock = DockStyle.Fill,
                });
                contentItem.OnNeedReloadData += new EventHandler(contentItem_OnNeedReloadData);

                var sbShowEntryOperationsPanel = new ToolStripButton("ВЪЕЗД", contentItem.LinkedOperationImage, this.ChangeOperationsMode) { Font = new Font("Segoe UI", 20, FontStyle.Bold) }; // { BackColor = this.EntryToolBarBackground, Text = "ВЪЕЗД", Font = new Font("Segoe UI", 20, FontStyle.Bold) };
                sbShowEntryOperationsPanel.Tag = contentItem;
                //sbShowEntryOperationsPanel.Click += this.ChangeOperationsMode;
                tsMainMenu.Items.Add(sbShowEntryOperationsPanel);
                operationButtonImages.Add(sbShowEntryOperationsPanel.Image, sbShowEntryOperationsPanel);
                #endregion

                #region Формирование контента для операции выезда

                // Добавим отступ
                tsMainMenu.Items.Add(new ToolStripLabel(string.Empty.PadLeft(3, ' ')));

                this.Content.Add(contentItem = new PalletsAccountingControl()
                {
                    UserID = this.UserID,
                    Period = DateTime.Today,
                    ViewSearchDirectionType = ViewSearchDirectionType.Outgoing,
                    IsChiefSecurityMode = this.IsChiefSecurityMode,
                    ToolBarBackground = this.OutgoingToolBarBackground,
                    LinkedOperationImage = Properties.Resources.yellow_squere,
                    Dock = DockStyle.Fill
                });
                contentItem.OnNeedReloadData += new EventHandler(contentItem_OnNeedReloadData);

                var sbShowOutgoingOperationsPanel = new ToolStripButton("ВЫЕЗД", contentItem.LinkedOperationImage, this.ChangeOperationsMode) { Font = new Font("Segoe UI", 20, FontStyle.Bold) }; //{ BackColor = this.OutgoingToolBarBackground, Text = "ВЫЕЗД", Font = new Font("Segoe UI", 20, FontStyle.Bold) };
                sbShowOutgoingOperationsPanel.Tag = contentItem;
                //sbShowOutgoingOperationsPanel.Click += this.ChangeOperationsMode;
                tsMainMenu.Items.Add(sbShowOutgoingOperationsPanel);
                operationButtonImages.Add(sbShowOutgoingOperationsPanel.Image, sbShowOutgoingOperationsPanel);
                #endregion
            }

            this.pnlMainLayout.Controls.Add(this.Content[0]);
            #endregion
        }

        /// <summary>
        /// Изменение режима работы для операции въезда/выезда
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeOperationsMode (object sender, EventArgs e)
        {
            this.pnlMainLayout.Controls.Clear();
            this.pnlMainLayout.Controls.Add((Control)(((ToolStripButton)sender).Tag));
            this.ReloadData();
        }

        void contentItem_OnNeedReloadData(object sender, EventArgs e)
        {
            // Перечитуем данные по периоду
            this.ReloadData();
        }

        /// <summary>
        /// Установка режима работы с интерфейсом
        /// </summary>
        private void SetUserAccessMode()
        {
            try
            {
                using (var adapter = new Data.ReceiveTableAdapters.ChiefSecurityCheckResponseTableAdapter())
                    this.IsChiefSecurityMode = adapter.GetData(this.UserID)[0].Access;

                this.DocTitle.Text = string.Format("{0} [{1}]", this.DocTitle.Text, this.IsChiefSecurityMode ? "Начальник охраны" : "Охранник");
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void sbRefreshData_Click(object sender, EventArgs e)
        {
            this.ReloadData();
        }

        /// <summary>
        /// Перечитка данных
        /// </summary>
        private void ReloadData()
        {
            // уберем фон
            foreach (var item in operationButtonImages)
            {
                item.Value.Image = Properties.Resources.gray_squere;
                item.Value.ForeColor = Color.Gray;
            }

            foreach (var contentItem in this.Content)
                if (this.pnlMainLayout.Contains(contentItem))
                {
                    // установим фон
                    if (contentItem.LinkedOperationImage != null && operationButtonImages.ContainsKey(contentItem.LinkedOperationImage))
                    {
                        operationButtonImages[contentItem.LinkedOperationImage].Image = contentItem.LinkedOperationImage;
                        operationButtonImages[contentItem.LinkedOperationImage].ForeColor = Color.Black;
                    }

                    contentItem.ReloadData(this.Period);
                }
        }
    }
}
