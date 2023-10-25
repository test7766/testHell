using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.Custom;
using WMSOffice.Controls.Receive;
using WMSOffice.Dialogs;
using System.Reflection;
using WMSOffice.Dialogs.Receive;
using WMSOffice.Controls.EBW;

namespace WMSOffice.Window
{
    public interface IHost
    {
        SplashForm WaitProgressForm { get; }
        long SessionID { get; }
        OperationAccess Access { get; }
        bool IsUserCEO { get; }
        Data.Receive.RampFilialsRow CurrentFilial { get; }
        ResourceContext ResourceContext { get; }
    }

    public partial class LimesLoadingWindow : GeneralWindow, IHost
    {
        #region ПОЛЯ И СВОЙСТВА ДАННЫХ
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm waitProcessForm = new WMSOffice.Dialogs.SplashForm();

        /// <summary>
        /// Уровень доступа к форме
        /// </summary>
        private OperationAccess operationAccess = OperationAccess.None;

        /// <summary>
        /// Режим работы пользователя
        /// </summary>
        private OperationAccess userСurrentWorkMode = OperationAccess.None;

        private bool isUserCEO { get; set; }

        /// <summary>
        /// Рассматриваемый период
        /// </summary>
        public DateTime? Period { get; private set; }

        /// <summary>
        /// Поставки на разгрузку
        /// </summary>
        private IShipmentContent freeShipments = null;

        /// <summary>
        /// График разгрузки поставок
        /// </summary>
        private IRampContent shipmentsOnRamp = null;

        /// <summary>
        /// Список операций, котрые изменяют свою доступность к выполнению 
        /// </summary>
        List<ToolStripButton> AccessibleOperationButtons = new List<ToolStripButton>();

        /// <summary>
        /// Источник данных для привязки филиалов
        /// </summary>
        private BindingSource bsRampFilials = new BindingSource(null, "RampFilials");

        private ToolStripButton findShipmentsButton = null;
        private ToolStripButton refreshButton = null;

        private Button changeScaleButton = null;
        private Button exportToExcelButton = null;

        private ResourceContext resourceContext = new ResourceContext(); 


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
                    _shipmentsOnRampControl = new ShipmentsOnRampControl((IHost)this);
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
                    _freeShipmentsOnDateControl = new FreeShipmentsOnDateControl((IHost)this);
                return _freeShipmentsOnDateControl;
            }
        }
        #endregion
        #endregion

        public LimesLoadingWindow()
        {
            InitializeComponent();
            this.pnlWorkArea.Visible = false;
        }


        /// <summary>
        /// Возвращает признак продолжения работать с интерфейсом в установленном режиме
        /// </summary>
        /// <returns></returns>
        private bool ContinueWorkInSelectedMode()
        {
            var workModeSelector = new LimesLoadingWorkModeForm() { UserID = this.UserID };
            if (workModeSelector.ShowDialog() == DialogResult.OK)
            {
                this.userСurrentWorkMode = (OperationAccess)workModeSelector.SelectedWorkMode;
                //this.ApplyCurrentWorkMode();

                this.CheckCEOAuthorities();

                return true;
            }

            return false;
        }

        /// <summary>
        /// Проверка пользователя на вхождение в роль начальника приемного отдела
        /// </summary>
        /// <returns></returns>
        private void CheckCEOAuthorities()
        {
            try
            {
                using (var adapter = new Data.ReceiveTableAdapters.ChangeStatusSignResponseForPalletsActTableAdapter())
                    this.isUserCEO = adapter.GetData(this.UserID)[0].CanChangeFlag;

            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void LimesLoadingWindow_Load(object sender, EventArgs e)
        {
      
        }

        private bool LoadFilials()
        {
            try
            {
                using (var adapter = new Data.ReceiveTableAdapters.RampFilialsTableAdapter())
                    bsRampFilials.DataSource = adapter.GetData(this.UserID);

                return true;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
                return false;
            }
        }

        
        private void ApplyCurrentWorkMode()
        {
            this.DocTitle.Text = string.Format("{0} [{1}]", this.Caption/*DocTitle.Text*/, this.GetEnumDescription(this.operationAccess));
        }

        private string Caption;
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            Caption = this.DocTitle.Text;
            if (!this.ContinueWorkInSelectedMode() || !this.LoadFilials())
            {
                this.Close();
                return;
            }

            this.pnlWorkArea.Visible = true;
            ShipmentsOnRampControl.CurrentScaleInterval = null;
            //this.InitializeWorkArea();

            this.InitializeWorkArea();
            this.LoadData(null);
        }

        private ToolStripControlHost tschDateTimePicker = null;

         /// <summary>
        /// Инициализация рабочей области
        /// </summary>
        private void InitializeWorkArea()
        {
            tsMainToolbar.Items.Clear();

            // Добавление вызова поиска поставок
            var sbFindShipments = new ToolStripButton();
            sbFindShipments.Image = Properties.Resources.find;
            sbFindShipments.Text = "Все поставки";
            sbFindShipments.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            sbFindShipments.Click += new EventHandler(sbFindShipments_Click);
            tsMainToolbar.Items.Add(findShipmentsButton = sbFindShipments);

            tsMainToolbar.Items.Add(new ToolStripSeparator());

            // Добавление кнопки "Обновить"
            var sbRefresh = new ToolStripButton();
            sbRefresh.Image = Properties.Resources.refresh;
            sbRefresh.Text = "Обновить";
            sbRefresh.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            sbRefresh.Click += sbRefresh_Click;
            tsMainToolbar.Items.Add(refreshButton = sbRefresh);

            //// Добавление надписи "за период"
            //var slFilter = new ToolStripLabel();
            //slFilter.Text = "за   период   ";
            //tsMainToolbar.Items.Add(slFilter);

            // Добавление фильтра для выбора периода
            var dtPeriodFilter = new DateTimePicker();
            dtPeriodFilter.Width = 110;
            dtPeriodFilter.Format = DateTimePickerFormat.Custom;
            dtPeriodFilter.CustomFormat = "dd / MM / yyyy";
            dtPeriodFilter.ValueChanged += delegate(object sender, EventArgs e)
            {
                this.Period = dtPeriodFilter.Value.Date;

                this.operationAccess = this.userСurrentWorkMode;

                // Анализ и установка режима "только для чтения"
                if (dtPeriodFilter.Value.Date < DateTime.Today)
                {
                    if (this.userСurrentWorkMode == OperationAccess.PriorPlanning)
                        this.operationAccess = OperationAccess.PriorPlanningReview;

                    if (this.userСurrentWorkMode == OperationAccess.RegisterShipments)
                        this.operationAccess = OperationAccess.RegisterShipmentsReview;
                }
                    
                //this.ApplyCurrentWorkMode();
            };
            //dtPeriodFilter.Value = selectedPeriod.HasValue ? selectedPeriod.Value : DateTime.Today;
            //this.ApplyCurrentWorkMode();
            tsMainToolbar.Items.Add(tschDateTimePicker = new ToolStripControlHost(dtPeriodFilter));


            // Добавление отступа
            var slIndent = new ToolStripLabel(string.Empty.PadLeft(1, ' '));
            tsMainToolbar.Items.Add(slIndent);


            // Добавление фильтра пофилиального
            var cmbRampFilials = new ComboBox();
            cmbRampFilials.Size = new Size(180, cmbRampFilials.Height);
            cmbRampFilials.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRampFilials.DisplayMember = "FilialName";
            cmbRampFilials.ValueMember = "Filial_ID";

            cmbRampFilials.DataSource = bsRampFilials;
            tsMainToolbar.Items.Add(new ToolStripControlHost(cmbRampFilials));


            if (shipmentsOnRamp != null)
                shipmentsOnRamp.LockNavigation(true);

            if (freeShipments != null)
                freeShipments.LockNavigation(true);

            this.rvlcHost.Controls.Clear();

            //var shipmentsOnRampControl = new ShipmentsOnRampControl((IHost)this);
            shipmentsOnRamp = (IRampContent)ShipmentsOnRampControlWrapper;

            #region Формирование доп. опции изменения шкалы времени
            Button btnChangeScale = new Button();
            shipmentsOnRamp.ChangeScaleControl = btnChangeScale;
            btnChangeScale.Image = Properties.Resources.scale;
            var tip = new ToolTip();
            tip.SetToolTip(btnChangeScale, string.Format("Цена делений на шкале времени : {0} минут.", shipmentsOnRamp.ScaleInterval));
            btnChangeScale.Tag = tip;
            btnChangeScale.Click += delegate(object sender, EventArgs e)
            {
                ShipmentsOnRampControlWrapper.ChangeScale();
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

            ShipmentsOnRampControlWrapper.OnPopulateResource -= new EventHandler<PopulateResourseArgs>(ShipmentsOnRampControl_OnPopulateResource);
            ShipmentsOnRampControlWrapper.OnPopulateResource += new EventHandler<PopulateResourseArgs>(ShipmentsOnRampControl_OnPopulateResource);

            this.rvlcHost.AddContent(new ReversedVisibilityLayoutControl(ShipmentsOnRampControlWrapper, "График загрузки рамп", 45.5M, ContentVisibility.Show, changeScaleButton = btnChangeScale, btnMoveRampsForward, btnMoveRampsBackward));
            

            //var freeShipmentsControl = new FreeShipmentsOnDateControl((IHost)this);
            freeShipments = (IShipmentContent)FreeShipmentsOnDateControlWrapper;
            #region Формирование доп. опции экспорта поставок в Excel
            Button btnExportToExcel= new Button();
            btnExportToExcel.Image = Properties.Resources.accept_16;
            var tipExcel = new ToolTip();
            tipExcel.SetToolTip(btnExportToExcel, string.Format("Экспорт поставок в Excel."));
            btnExportToExcel.Click += delegate(object sender, EventArgs e)
            {
                FreeShipmentsOnDateControlWrapper.ExportToExcel();
            };
            #endregion

            FreeShipmentsOnDateControlWrapper.OnPopulateResource -= new EventHandler<PopulateResourseArgs>(ShipmentsOnRampControl_OnPopulateResource);
            FreeShipmentsOnDateControlWrapper.OnPopulateResource += new EventHandler<PopulateResourseArgs>(ShipmentsOnRampControl_OnPopulateResource);

            this.rvlcHost.AddContent(new ReversedVisibilityLayoutControl(FreeShipmentsOnDateControlWrapper, "Таблица записи поставок на разгрузку", 54.5M, ContentVisibility.Show, exportToExcelButton = btnExportToExcel));

            // -------------------------------------------------------------------------------------------------------------------------------

            ////this.SetAccessLevel();
            //this.PrepareUserModeSettings();
            //shipmentsOnRamp.PrepareUserModeOperations();
            //freeShipments.PrepareUserModeOperations();

            ////this.LoadData();
        }

        void ShipmentsOnRampControl_OnPopulateResource(object sender, PopulateResourseArgs e)
        {
            e.Resources.Add(findShipmentsButton);
            e.Resources.Add(refreshButton);

            if (sender == ShipmentsOnRampControlWrapper)
            {
                e.Resources.Add(changeScaleButton);
            }

            if (sender == FreeShipmentsOnDateControlWrapper)
            {
                e.Resources.Add(exportToExcelButton);
            }
        }

       

        void sbFindShipments_Click(object sender, EventArgs e)
        {
            var dialog = new ShipmentsFindForm() { UserID = this.UserID, Host = this, ShipmentDate = this.Period.Value };
            if (dialog.ShowDialog() == DialogResult.OK)
                this.LoadData(dialog.ShipmentDate);
        }

        private readonly List<ToolStripItem> lstModeStripItems = new List<ToolStripItem>();

        /// <summary>
        /// Подготовка режима пользователя к работе
        /// </summary>
        private void PrepareUserModeSettings()
        {
            foreach (var item in lstModeStripItems)
            {
                if (tsMainToolbar.Items.Contains(item))
                    tsMainToolbar.Items.Remove(item);
            }

            lstModeStripItems.Clear();
            this.AccessibleOperationButtons.Clear();

            if (this.operationAccess == OperationAccess.Review || this.operationAccess == OperationAccess.PriorPlanningReview || this.operationAccess == OperationAccess.RegisterShipmentsReview || this.operationAccess == OperationAccess.None)
                return;

            var sep = new ToolStripSeparator();
            tsMainToolbar.Items.Add(sep);
            lstModeStripItems.Add(sep);

            ToolStripButton accessibleOperationButton = null;

            if (this.operationAccess == OperationAccess.PriorPlanning || this.operationAccess == OperationAccess.RegisterShipments)
            {
                var button = new ToolStripButton("Сформировать\nграфик", Properties.Resources.history_review, delegate(object sender, EventArgs e) { shipmentsOnRamp.CreateShipmentPlanning(); });
                tsMainToolbar.Items.Add(button);
                lstModeStripItems.Add(button);
            }

            if (this.operationAccess == OperationAccess.PriorPlanning || this.operationAccess == OperationAccess.RapidPlanning || this.operationAccess == OperationAccess.RegisterShipments)
            {
                var button = freeShipments.EditButton = new ToolStripButton("Записать на\nразгрузку", Properties.Resources.edit_document, delegate(object sender, EventArgs e) { freeShipments.EditShipment(); }) { Tag = OperationType.EditShipment, Enabled = false };
                tsMainToolbar.Items.Add(button);
                lstModeStripItems.Add(button);

                var separator = new ToolStripSeparator();
                tsMainToolbar.Items.Add(separator);
                lstModeStripItems.Add(separator);
            }

            if (this.operationAccess == OperationAccess.PriorPlanning || this.operationAccess == OperationAccess.RapidPlanning)
            {
                tsMainToolbar.Items.Add(accessibleOperationButton = new ToolStripButton("Подтвердить\nзапись", Properties.Resources.document_ok, delegate(object sender, EventArgs e) { shipmentsOnRamp.ConfirmShipment(); }) { Tag = OperationType.ConfirmShipment });
                this.AccessibleOperationButtons.Add(accessibleOperationButton);
                lstModeStripItems.Add(accessibleOperationButton);
            }

            if (this.operationAccess == OperationAccess.PriorPlanning || this.operationAccess == OperationAccess.RapidPlanning)
            {
                tsMainToolbar.Items.Add(accessibleOperationButton = new ToolStripButton("Отменить\nподтверждение", Properties.Resources.undo_action, delegate(object sender, EventArgs e) { shipmentsOnRamp.DeleteShipmentFromLimes(); }) { Tag = OperationType.DeleteShipmentFromLimes });
                this.AccessibleOperationButtons.Add(accessibleOperationButton);
                 lstModeStripItems.Add(accessibleOperationButton);
            }

            if (this.operationAccess == OperationAccess.PriorPlanning)
            {
                var button = new ToolStripButton("График\nзавершен", Properties.Resources.finish_process, delegate(object sender, EventArgs e) { shipmentsOnRamp.CloseDoc(); });
                tsMainToolbar.Items.Add(button);
                lstModeStripItems.Add(button);
            }

            if (this.operationAccess == OperationAccess.RapidPlanning)
            {
                tsMainToolbar.Items.Add(accessibleOperationButton = new ToolStripButton("Пригласить\nна разгрузку", Properties.Resources.delivery, delegate(object sender, EventArgs e) { shipmentsOnRamp.InviteToUnloading(); }) { Tag = OperationType.InviteToUnloading });
                this.AccessibleOperationButtons.Add(accessibleOperationButton);
                 lstModeStripItems.Add(accessibleOperationButton);
            }

            if (this.operationAccess == OperationAccess.RapidPlanning)
            {
                tsMainToolbar.Items.Add(accessibleOperationButton = new ToolStripButton("Выгрузка\nзавершена", Properties.Resources.finish_process, delegate(object sender, EventArgs e) { shipmentsOnRamp.CompleteUnloading(); }) { Tag = OperationType.CompleteUnloading });
                this.AccessibleOperationButtons.Add(accessibleOperationButton);
                 lstModeStripItems.Add(accessibleOperationButton);
            }

            if (this.operationAccess == OperationAccess.RapidPlanning)
            {
                var separator = new ToolStripSeparator();
                tsMainToolbar.Items.Add(separator);
                lstModeStripItems.Add(separator);

                tsMainToolbar.Items.Add(accessibleOperationButton = new ToolStripButton("Возврат\nпаллет", Properties.Resources.baggage, delegate(object sender, EventArgs e) { shipmentsOnRamp.ReturnTare(); }) { Tag = OperationType.TareReturning });
                this.AccessibleOperationButtons.Add(accessibleOperationButton);
                 lstModeStripItems.Add(accessibleOperationButton);
            }

            if (this.operationAccess == OperationAccess.RapidPlanning && this.IsUserCEO)
            {
                tsMainToolbar.Items.Add(accessibleOperationButton = new ToolStripButton("Аннулирование\nвозврата", Properties.Resources.assign, delegate(object sender, EventArgs e) { shipmentsOnRamp.CorrectPalletsReturn(); }) { Tag = OperationType.CorrectPalletsReturn });
                this.AccessibleOperationButtons.Add(accessibleOperationButton);
                 lstModeStripItems.Add(accessibleOperationButton);
            }

            if (this.operationAccess == OperationAccess.RapidPlanning)
            {
                tsMainToolbar.Items.Add(accessibleOperationButton = new ToolStripButton("Создать поставку\nдля возврата", Properties.Resources.document_new, delegate(object sender, EventArgs e) { shipmentsOnRamp.CreateEmptyShipment(); }) { Tag = OperationType.CreateEmptyShipment, Alignment = ToolStripItemAlignment.Right });
                this.AccessibleOperationButtons.Add(accessibleOperationButton);
                lstModeStripItems.Add(accessibleOperationButton);

                var separator = new ToolStripSeparator() { Alignment = ToolStripItemAlignment.Right };
                tsMainToolbar.Items.Add(separator);
                lstModeStripItems.Add(separator);
            }

            // Подпишемся на событие перечитки данных
            shipmentsOnRamp.OnReloadDoc -= this.ReloadData;
            shipmentsOnRamp.OnReloadDoc += this.ReloadData;
            shipmentsOnRamp.OnAccessibleShipmentChanged += new EventHandler<ShipmentOperationsAccessParametersEventArgs>(shipmentsOnRamp_OnAccessibleShipmentChanged);

            // Подпишемся на событие перечитки данных
            freeShipments.OnReloadDoc -= this.ReloadData;
            freeShipments.OnReloadDoc += this.ReloadData;
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

        void shipmentsOnRamp_OnAccessibleShipmentChanged(object sender, ShipmentOperationsAccessParametersEventArgs e)
        {
            ShipmentsOnRampControl.ChangeOperationsAccess(this.AccessibleOperationButtons, e);
        }

        private void sbRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData(this.Period);
        }

        /// <summary>
        /// Загрузка данных за текущий период
        /// </summary>
        private void LoadData(DateTime? selectedPeriod)
        {
            if (freeShipments != null)
                freeShipments.SaveContentPlacementSettings();

            if (tschDateTimePicker != null)
            {
                (tschDateTimePicker.Control as DateTimePicker).Value = selectedPeriod.HasValue ? selectedPeriod.Value : DateTime.Today;
                this.ApplyCurrentWorkMode();
                this.PrepareUserModeSettings();
                shipmentsOnRamp.PrepareUserModeOperations();
                freeShipments.PrepareUserModeOperations();
            }
            //InitializeWorkArea(selectedPeriod);

            if (shipmentsOnRamp != null)
            {
                shipmentsOnRamp.LoadData(this.Period.Value);
                shipmentsOnRamp.LockNavigation(false);
            }
            //return;

            if (freeShipments != null)
            {
                freeShipments.LoadData(this.Period.Value);
                freeShipments.LockNavigation(false);
            }
        }

        /// <summary>
        /// Определение уровня доступа
        /// </summary>
        [Obsolete("Метод заменен на выбор режима работы с интерфейсом")]
        private void SetAccessLevel()
        {
            try
            {
                int accessMode;
                using (Data.ReceiveTableAdapters.AccessModesTableAdapter adapter = new WMSOffice.Data.ReceiveTableAdapters.AccessModesTableAdapter())
                    accessMode = Convert.ToInt32(adapter.GetData(this.UserID)[0].mode);

                this.operationAccess = (OperationAccess)accessMode;
                //this.operationAccess = OperationAccess.Review; // TEST ONLY
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.DocTitle.Text = string.Format("{0} [{1}]", this.DocTitle.Text, this.GetEnumDescription(this.operationAccess));
        }

        /// <summary>
        /// Получить описание элемента перечисления
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public string GetEnumDescription(object enumValue)
        {
            FieldInfo fi = enumValue.GetType().GetField(enumValue.ToString());

            if (fi != null)
            {
                object[] attrs = fi.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }

            return string.Empty;
        }

        #region IHost Members

        public SplashForm WaitProgressForm
        {
            get { return this.waitProcessForm; }
        }

        public long SessionID
        {
            get { return this.UserID; }
        }

        public OperationAccess Access
        {
            get { return this.operationAccess; }
        }

        public bool IsUserCEO
        {
            get { return this.isUserCEO; }
        }

        public Data.Receive.RampFilialsRow CurrentFilial
        {
            get { return (bsRampFilials.CurrencyManager.Current as DataRowView).Row as Data.Receive.RampFilialsRow; }
        }

        public ResourceContext ResourceContext 
        {
            get { return resourceContext; }
        }

        #endregion

        private void LimesLoadingWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.freeShipments != null)
                this.freeShipments.SaveContentPlacementSettings();
        }
    }

    /// <summary>
    /// Уровень доступа согласно режима работы
    /// </summary>
    public enum OperationAccess
    {
        /// <summary>
        /// Уровень доступа не определен
        /// </summary>
        [Description("Уровень доступа не определен")]
        None = -1,

         /// <summary>
        /// Предварительное планирование - только просмотр
        /// </summary>
        [Description("Предварительное планирование - только просмотр")]
        PriorPlanningReview = -2,

        /// <summary>
        /// Предварительное планирование
        /// </summary>
        [Description("Предварительное планирование")]
        PriorPlanning = 1,

        /// <summary>
        /// Оперативное планирование
        /// </summary>
        [Description("Оперативное планирование")]
        RapidPlanning = 2,

        /// <summary>
        /// Просмотр графика поставок
        /// </summary>
        [Description("Просмотр графика поставок")]
        Review = 3,

        /// <summary>
        /// Запись поставок на разгрузку
        /// </summary>
        [Description("Запись поставок на разгрузку")]
        RegisterShipments = 4,

        /// <summary>
        /// Запись поставок на разгрузку - только просмотр
        /// </summary>
        [Description("Запись поставок на разгрузку - только просмотр")]
        RegisterShipmentsReview = -3,
    }

    /// <summary>
    /// Статус поставки
    /// </summary>
    public enum ShipmentState
    { 
        /// <summary>
        /// Статус неопределен 
        /// </summary>
        None = -1,

        /// <summary>
        /// Записана
        /// </summary>
        Registered = 100,

        /// <summary>
        /// Подтверждена
        /// </summary>
        Confirmed = 105,

        /// <summary>
        /// Приехала
        /// </summary>
        Arrived = 110,

        /// <summary>
        /// Ожидает
        /// </summary>
        Waiting = 115,

        /// <summary>
        /// Приглашена
        /// </summary>
        Invited = 120,

        /// <summary>
        /// Выгружена
        /// </summary>
        Unloaded = 125,

        /// <summary>
        /// Загружена
        /// </summary>
        Uploaded = 130
    }

    /// <summary>
    /// Тип операции
    /// </summary>
    public enum OperationType
    {
        /// <summary>
        /// Подтвердить запись
        /// </summary>
        ConfirmShipment,

        /// <summary>
        /// Отменить подтверждение
        /// </summary>
        DeleteShipmentFromLimes,

        /// <summary>
        /// Пригласить на разгрузку
        /// </summary>
        InviteToUnloading,

        /// <summary>
        /// Выгрузка завершена
        /// </summary>
        CompleteUnloading,

        /// <summary>
        /// Возврат паллет
        /// </summary>
        TareReturning,

        /// <summary>
        /// Повторная печать акта при разгрузке
        /// </summary>
        ReprintTareReceivingAct,

        /// <summary>
        /// Повторная печать акта при возврате
        /// </summary>
        ReprintTareReturningAct,

        /// <summary>
        /// Создание поставки-"пустышки" (для возврата тары)
        /// </summary>
        CreateEmptyShipment,

        /// <summary>
        /// Аннулирование (корректировка) возврата
        /// </summary>
        CorrectPalletsReturn,

        /// <summary>
        /// Запись на разгрузку
        /// </summary>
        EditShipment,

        /// <summary>
        /// Отобразить заказы по поставке
        /// </summary>
        ShowShipmentOrders,
        
        /// <summary>
        /// Отобразить паллеты поставки
        /// </summary>
        ShowShipmentPallets
    }

    public static class ShipmentHelper
    {
        public static bool CheckSpecialShipmentType(string shipmentType)
        {
            foreach (var st in new string[] { "P1", "P2", "P3", "P4" })
                if (st.Equals(shipmentType))
                    return true;

            return false;
        }

        public static SpecialShipmentMode GetSpecialShipmentMode(string shipmentType)
        {
            switch (shipmentType)
            { 
                case "P1":
                case "P3":
                    return SpecialShipmentMode.Sender;
                case "P2":
                case "P4":
                    return SpecialShipmentMode.Receiver;
                default:
                    throw new ArgumentException("Неверный тип поставки.");
            }
        }
    }

    public class PopulateResourseArgs : EventArgs
    {
        public List<object> Resources { get; private set; }

        public PopulateResourseArgs()
        {
            this.Resources = new List<object>();       
        }
    }

    public enum SpecialShipmentMode
    {
        /// <summary>
        /// Отправитель
        /// </summary>
        Sender,

        /// <summary>
        /// Получатель
        /// </summary>
        Receiver
    }
}
