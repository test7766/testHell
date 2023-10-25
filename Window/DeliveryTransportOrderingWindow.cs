using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.Custom;
using WMSOffice.Controls.Interbranch;
using WMSOffice.Dialogs;

namespace WMSOffice.Window
{
    public partial class DeliveryTransportOrderingWindow : GeneralWindow, IDeliveryTransportOrderingHost
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm waitProcessForm = new WMSOffice.Dialogs.SplashForm();

        /// <summary>
        /// Рассматриваемый период
        /// </summary>
        public DateTime? Period { get; private set; }

        /// <summary>
        /// Поставки на разгрузку
        /// </summary>
        private IDeliveryTransportShipmentContent freeShipments = null;

        /// <summary>
        /// График разгрузки поставок
        /// </summary>
        private IDeliveryTransportRampContent shipmentsOnRamp = null;

        #region УПАКОВКА ДЛЯ ЭЛЕМЕНТОВ УПРАВЛЕНИЯ, КОТОРЫЕ ХОСТЯТСЯ НА ГЛАВНОМ ИНТЕРФЕЙСЕ

        private ShipmentsOnRampControl _shipmentsOnRampControl = null;
        /// <summary>
        /// Обертка для элемента управления "поставки на рампе"
        /// </summary>
        private ShipmentsOnRampControl ShipmentsOnRampControlWrapper
        {
            get
            {
                if (_shipmentsOnRampControl == null)
                    _shipmentsOnRampControl = new ShipmentsOnRampControl((IDeliveryTransportOrderingHost)this);
                return _shipmentsOnRampControl;
            }
        }

        private FreeShipmentsOnDateControl _freeShipmentsOnDateControl = null;
        /// <summary>
        /// Обертка для элемента управления "поставки на дату"
        /// </summary>
        private FreeShipmentsOnDateControl FreeShipmentsOnDateControlWrapper
        {
            get
            {
                if (_freeShipmentsOnDateControl == null)
                    _freeShipmentsOnDateControl = new FreeShipmentsOnDateControl((IDeliveryTransportOrderingHost)this);
                return _freeShipmentsOnDateControl;
            }
        }

        #endregion

        private ToolStripButton refreshButton = null;
        private ToolStripControlHost tschDateTimePicker = null;

        private Button changePercentageModeButton = null;

        private readonly List<ToolStripItem> lstModeStripItems = new List<ToolStripItem>();

        /// <summary>
        /// Источник данных для привязки филиалов
        /// </summary>
        private BindingSource bsRampFilials = new BindingSource(null, "TSP_Filials");

        public DeliveryTransportOrderingWindow()
        {
            InitializeComponent();
        }

        private void DeliveryTransportOrderingWindow_Load(object sender, EventArgs e)
        {

        }

        private bool LoadFilials()
        {
            try
            {
                using (var adapter = new Data.InterbranchTableAdapters.TSP_FilialsTableAdapter())
                    bsRampFilials.DataSource = adapter.GetData(this.UserID);

                return true;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
                return false;
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (!this.LoadFilials())
            {
                this.Close();
                return;
            }

            this.InitializeWorkArea();
            this.LoadData(null);
        }

        /// <summary>
        /// Инициализация рабочей области
        /// </summary>
        private void InitializeWorkArea()
        {
            tsMainToolbar.Items.Clear();

            // Добавление кнопки "Обновить"
            var btnRefresh = new ToolStripButton();
            btnRefresh.Image = Properties.Resources.refresh;
            btnRefresh.Text = "Обновить";
            btnRefresh.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            btnRefresh.Click += btnRefreshData_Click;
            tsMainToolbar.Items.Add(refreshButton = btnRefresh);

            // Добавление фильтра для выбора периода
            var dtPeriodFilter = new DateTimePicker();
            dtPeriodFilter.Width = 80;
            dtPeriodFilter.Format = DateTimePickerFormat.Custom;
            dtPeriodFilter.CustomFormat = "dd.MM.yyyy";
            dtPeriodFilter.ValueChanged += delegate(object sender, EventArgs e)
            {
                this.Period = dtPeriodFilter.Value.Date;
            };
           
            tsMainToolbar.Items.Add(tschDateTimePicker = new ToolStripControlHost(dtPeriodFilter));

            // Добавление отступа
            var slIndent = new ToolStripLabel(string.Empty.PadLeft(1, ' '));
            tsMainToolbar.Items.Add(slIndent);

            // Добавление фильтра пофилиального
            var cmbRampFilials = new ComboBox();
            cmbRampFilials.Size = new Size(180, cmbRampFilials.Height);
            cmbRampFilials.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRampFilials.DisplayMember = "FilialName";
            cmbRampFilials.ValueMember = "FilialID";

            cmbRampFilials.DataSource = bsRampFilials;
            tsMainToolbar.Items.Add(new ToolStripControlHost(cmbRampFilials));


            freeShipments = (IDeliveryTransportShipmentContent)FreeShipmentsOnDateControlWrapper;
            shipmentsOnRamp = (IDeliveryTransportRampContent)ShipmentsOnRampControlWrapper;

            this.rvlcHost.Controls.Clear();

            var tip = new ToolTip();

            #region Изменение режима отображения поставок
            Button btnChangePercentageMode = new Button();
            freeShipments.ChangePercentageModeControl = btnChangePercentageMode;
            btnChangePercentageMode.Image = Properties.Resources.accept_16;
            tip.SetToolTip(btnChangePercentageMode, string.Format("Перейти к режиму отображения поставок в {0}", FreeShipmentsOnDateControlWrapper.PercentageMode ? "м³" : "%"));
            btnChangePercentageMode.Tag = tip;
            btnChangePercentageMode.Click += delegate(object sender, EventArgs e)
            {
                FreeShipmentsOnDateControlWrapper.ChangePercentageMode();
            };
            #endregion

            #region Прокрутка рамп
            Button btnMoveRampsForward = new Button();
            Button btnMoveRampsBackward = new Button();

            #region Прокрутка рамп вперед
            btnMoveRampsForward.Enabled = false;
            btnMoveRampsForward.Image = Properties.Resources.chevron_right;
            tip.SetToolTip(btnMoveRampsForward, string.Format("Отобразить следующюю тройку рамп"));
            btnMoveRampsForward.Click += delegate(object sender, EventArgs e)
            {
                ShipmentsOnRampControlWrapper.RampsNavigator.MoveForward();
            };
            #endregion

            #region Прокрутка рамп назад
            btnMoveRampsBackward.Enabled = false;
            btnMoveRampsBackward.Image = Properties.Resources.chevron_left;
            tip.SetToolTip(btnMoveRampsBackward, string.Format("Отобразить предыдущюю тройку рамп"));
            btnMoveRampsBackward.Click += delegate(object sender, EventArgs e)
            {
                ShipmentsOnRampControlWrapper.RampsNavigator.MoveBackward();
            };
            #endregion
            #endregion

            this.ShipmentsOnRampControlWrapper.RampsNavigator.OnNavigate += delegate(object sender, EventArgs e)
            {
                btnMoveRampsForward.Enabled = ShipmentsOnRampControlWrapper.RampsNavigator.CanMoveForward;
                btnMoveRampsBackward.Enabled = ShipmentsOnRampControlWrapper.RampsNavigator.CanMoveBackward;
            };

            this.rvlcHost.AddContent(new ReversedVisibilityLayoutControl(FreeShipmentsOnDateControlWrapper, "Таблица записи поставок на загрузку авто", 44.5M, ContentVisibility.Show, changePercentageModeButton = btnChangePercentageMode));

            this.rvlcHost.AddContent(new ReversedVisibilityLayoutControl(ShipmentsOnRampControlWrapper, "График загрузки рамп", 55.5M, ContentVisibility.Show, btnMoveRampsForward, btnMoveRampsBackward));
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F5))
            {
                this.LoadData(this.Period);
                return true;
            }

            //if (keyData == (Keys.Control | Keys.A))
            //{
            //    freeShipments.SetAdditionalShipmentsPlan();
            //    return true;
            //}

            //if (keyData == (Keys.Control | Keys.Q))
            //{
            //    shipmentsOnRamp.SetFactPallets();
            //    return true;
            //}

            if (keyData == (Keys.Control | Keys.End))
            {
                shipmentsOnRamp.CloseDoc();
                return true;
            }

            if (keyData == (Keys.Control | Keys.P))
            {
                shipmentsOnRamp.AttachDocPhotos();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnRefreshData_Click(object sender, EventArgs e)
        {
            this.LoadData(this.Period);
        }

        /// <summary>
        /// Перечитать данные
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReloadData(object sender, EventArgs e)
        {
            this.LoadData(this.Period);
        }

        private void SetCarOperationsAccess(object sender, CarOperationsAccessParametersEventArgs e)
        {
            foreach (var control in lstModeStripItems)
            {
                //if (SET_FACT_PALLETS_TAG.Equals(control.Tag))
                //    control.Enabled = e.IsCarAccessible && e.StatusID != (int)CarStatus.Completed;
             
                if (ATTACH_PHOTOS_TAG.Equals(control.Tag))
                    control.Enabled = e.IsCarAccessible;

                if (CLOSE_DOC_TAG.Equals(control.Tag))
                    control.Enabled = !string.IsNullOrEmpty(this.CurrentFilial.FilialID);
            }
        }

        /// <summary>
        /// Загрузка данных за текущий период
        /// </summary>
        private void LoadData(DateTime? selectedPeriod)
        {
            //selectedPeriod = new DateTime(2020, 8, 26); // TODO For TEST

            //if (freeShipments != null)
            //    freeShipments.SaveContentPlacementSettings();

            if (tschDateTimePicker != null)
            {
                (tschDateTimePicker.Control as DateTimePicker).Value = selectedPeriod.HasValue ? selectedPeriod.Value : DateTime.Today;
                //this.ApplyCurrentWorkMode();
                this.PrepareUserModeSettings();
                //shipmentsOnRamp.PrepareUserModeOperations();
                //freeShipments.PrepareUserModeOperations();
            }
            //InitializeWorkArea(selectedPeriod);

            if (freeShipments != null)
            {
                freeShipments.LoadData(this.Period.Value);
                //freeShipments.LockNavigation(false);
            }

            if (shipmentsOnRamp != null)
            {
                shipmentsOnRamp.LoadData(this.Period.Value);
                //shipmentsOnRamp.LockNavigation(false);
            }
            //return;
        }

        private const string SET_FACT_PALLETS_TAG = "SET_FACT_PALLETS_TAG";
        private const string ATTACH_PHOTOS_TAG = "ATTACH_PHOTOS_TAG";
        private const string CLOSE_DOC_TAG = "CLOSE_DOC_TAG";

        /// <summary>
        /// Подготовка режима пользователя к работе
        /// </summary>
        private void PrepareUserModeSettings()
        {
            ToolStripSeparator separator = null;
            ToolStripButton button = null;

            foreach (var item in lstModeStripItems)
            {
                if (tsMainToolbar.Items.Contains(item))
                    tsMainToolbar.Items.Remove(item);
            }

            lstModeStripItems.Clear();

            separator = new ToolStripSeparator();
            tsMainToolbar.Items.Add(separator);
            lstModeStripItems.Add(separator);


            //button = new ToolStripButton("Допланировать\nобъемы", Properties.Resources.lifetime, delegate(object sender, EventArgs e) { freeShipments.SetAdditionalShipmentsPlan(); });
            //tsMainToolbar.Items.Add(button);
            //lstModeStripItems.Add(button);

            //separator = new ToolStripSeparator();
            //tsMainToolbar.Items.Add(separator);
            //lstModeStripItems.Add(separator);


            //button = new ToolStripButton("Указать\nфакт паллет", Properties.Resources.pallet, delegate(object sender, EventArgs e) { shipmentsOnRamp.SetFactPallets(); }) { Tag = SET_FACT_PALLETS_TAG, Enabled = false };
            //tsMainToolbar.Items.Add(button);
            //lstModeStripItems.Add(button);

            //separator = new ToolStripSeparator();
            //tsMainToolbar.Items.Add(separator);
            //lstModeStripItems.Add(separator);


            button = new ToolStripButton("График\nзавершен", Properties.Resources.finish_process, delegate(object sender, EventArgs e) { shipmentsOnRamp.CloseDoc(); }) { Tag = CLOSE_DOC_TAG, Enabled = false };
            tsMainToolbar.Items.Add(button);
            lstModeStripItems.Add(button);

            separator = new ToolStripSeparator();
            tsMainToolbar.Items.Add(separator);
            lstModeStripItems.Add(separator);


            button = new ToolStripButton("Приложить\nфото", Properties.Resources.paperclip, delegate(object sender, EventArgs e) { shipmentsOnRamp.AttachDocPhotos(); }) { Tag = ATTACH_PHOTOS_TAG, Enabled = false };
            tsMainToolbar.Items.Add(button);
            lstModeStripItems.Add(button);

            separator = new ToolStripSeparator();
            tsMainToolbar.Items.Add(separator);
            lstModeStripItems.Add(separator);


            // Подпишемся на событие перечитки данных
            shipmentsOnRamp.OnReloadDoc -= this.ReloadData;
            shipmentsOnRamp.OnReloadDoc += this.ReloadData;

            // Подпишемся на событие перечитки данных
            freeShipments.OnReloadDoc -= this.ReloadData;
            freeShipments.OnReloadDoc += this.ReloadData;

            // Подпишемся на событие изменения доступности операций с выбранным авто
            shipmentsOnRamp.OnAccessibleCarChanged -= this.SetCarOperationsAccess;
            shipmentsOnRamp.OnAccessibleCarChanged += this.SetCarOperationsAccess;
        }

        private void DeliveryTransportOrderingWindow_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        #region IDeliveryTransportOrderingHost Members

        public SplashForm WaitProgressForm
        {
            get { return this.waitProcessForm; }
        }

        public long SessionID
        {
            get { return this.UserID; }
        }

        public Data.Interbranch.TSP_FilialsRow CurrentFilial
        {
            get { return (bsRampFilials.CurrencyManager.Current as DataRowView).Row as Data.Interbranch.TSP_FilialsRow; }
        }

        #endregion
    }

    public class DeliveryTransportDragDropArgs
    {
        public Data.Interbranch.TSP_DeliveriesRow Delivery { get; set; }
        public Data.Interbranch.TSP_Shipments_On_DateRow Row { get; set; }
    }

    public interface IDeliveryTransportOrderingHost
    {
        SplashForm WaitProgressForm { get; }
        long SessionID { get; }
        Data.Interbranch.TSP_FilialsRow CurrentFilial { get; }
    }
}
