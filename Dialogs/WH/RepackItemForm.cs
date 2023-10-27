using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WMSOffice.Dialogs.WH
{
    public partial class RepackItemForm : Form
    {
        /// <summary>
        /// Текущий товар для перепаковки
        /// </summary>
        public Data.WH.RepackMainDisplayCurrentTasksRow RepackItem { get; private set; }

        /// <summary>
        /// Код сессии пользователя
        /// </summary>
        public long UserID { get; set; }

        /// <summary>
        /// Код склада
        /// </summary>
        public string WarehouseID { get; set; }

        /// <summary>
        /// Стол перепаковки
        /// </summary>
        public string LOCN { get;  set; }

        /// <summary>
        /// Код станции
        /// </summary>
        public string StationID { get; set; }

        /// <summary>
        /// Ш/К тележки
        /// </summary>
        public string TrolleyBarCode { get; set; }

        /// <summary>
        /// Текущее кол-во в ЖЭ
        /// </summary>
        public int CurrentQuantityInYL
        {
            get
            {
                if (RepackItem == null)
                    return 0;

                var beforeQtty = RepackItem.IsUORGNull() ? 0 : RepackItem.UORG;
                var repackQtty = RepackItem.IsSOQSNull() ? 0 : RepackItem.SOQS;
                return beforeQtty - repackQtty;
            }
        }

        /// <summary>
        /// Признак оставить ТЕ на столе перепаковки
        /// </summary>
        private int CanLeaveBox = 0;

        /// <summary>
        /// Необходимость перемещения излишков
        /// </summary>
        private bool NeedTransferSurplus;

        /// <summary>
        /// Необходимость еще одной перепаковки
        /// </summary>
        private bool AnotherRepackOccured;

        /// <summary>
        /// Режим допаковки в ту же ТЕ
        /// </summary>
        private bool RepackPopulationOccured;

        /// <summary>
        /// Блокировка проверки данных
        /// </summary>
        private bool CheckDataLockInstalled;

        /// <summary>
        /// Содержимое ТЕ
        /// </summary>
        private int BoxContentQuantity;

        public RepackItemForm()
        {
            InitializeComponent();
        }

        public RepackItemForm(Data.WH.RepackMainDisplayCurrentTasksRow repackItem)
            : this()
        {
            RepackItem = repackItem;
        }

        private void RepackItemForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CheckDataLockInstalled = true;

            if (DialogResult == DialogResult.Abort)
            {
                e.Cancel = false;
                DialogResult = DialogResult.OK;
                return;
            }
            else if (DialogResult == DialogResult.Cancel && e.CloseReason == CloseReason.UserClosing)
            {
                if (Control.ModifierKeys == Keys.Control)
                {
                    MessageBox.Show("Задание перепаковки не завершено\r\nи было прервано автоматически!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Cancel = false;
                    DialogResult = DialogResult.Abort;
                    return;
                }
                else
                {
                    MessageBox.Show("Нельзя закрыть окно до завершения задания перепаковки!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Cancel = true;
                    return;
                }
            }

            if (DialogResult == DialogResult.OK)
                e.Cancel = !SaveChanges(false);
            else if (DialogResult == DialogResult.Ignore || DialogResult == DialogResult.None)
                e.Cancel = !MoveNonliquidRemains();
                //e.Cancel = !SaveCancelReason();

            CheckDataLockInstalled = false;
        }

        /// <summary>
        /// Сохранение процесса перепаковки товара
        /// </summary>
        /// <returns></returns>
        private bool SaveChanges(bool isSavePointOccured)
        {
            int? errorCode = null;
            string errorMessage = null;

            try
            {
                if (!ValidateFillItem())
                {
                    tbScanItem.Focus();
                    MessageBox.Show(string.Format("Значение в поле \"{0}\" должно быть указано!", "Товар из ЖЭ"), "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                if (!ValidateFillPackInBox())
                {
                    MessageBox.Show(string.Format("Значение в поле \"{0}\" должно быть указано!", "Кол-во в ТЕ"), "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbPackInBox.Focus();
                    return false;
                }

                if (!ValidateFillBox())
                {
                    MessageBox.Show(string.Format("Значение в поле \"{0}\" должно быть указано!", "Ш/К ТЕ"), "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbScanBox.Focus();
                    return false;
                }

                if (!Convert.ToBoolean(this.CanLeaveBox) && !ValidateFillSSCC())
                {
                    MessageBox.Show(string.Format("Значение в поле \"{0}\" должно быть указано!", "Ш/К SSCC"), "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbScanSSCC.Focus();
                    return false;
                }

                if (!Convert.ToBoolean(this.CanLeaveBox) && !ValidateFillTrolleyPlace())
                {
                    MessageBox.Show(string.Format("Значение в поле \"{0}\" должно быть указано!", "Место тележки"), "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbScanTrolleyPlace.Focus();
                    return false;
                }

                using (var adapter = new Data.WHTableAdapters.QueriesTableAdapter())
                    adapter.SaveItemRepack(UserID, WarehouseID, LOCN, RepackItem.barcode_YL, tbScanBox.Text, tbScanSSCC.Text, Convert.ToInt32(tbPackInBox.Text), this.CanLeaveBox, ref errorCode, ref errorMessage, tbScanTrolleyPlace.Text);

                if ((errorCode.HasValue && errorCode.Value > 0) || !string.IsNullOrEmpty(errorMessage))
                    throw new Exception(errorMessage);

                if (isSavePointOccured)
                    return true;

                if (AnotherRepackOccured = CheckAnotherRepack())
                    return false;

                #region ЛОГИРОВАНИЕ МАКС. КОЛ-ВА В ЯЩИКЕ

                int maxCapacity;
                if (int.TryParse(tbMaxPackInBox.Text, out maxCapacity) && maxCapacity > 0)
                {
                    using (var adapter = new Data.WHTableAdapters.QueriesTableAdapter())
                        adapter.SaveBoxCapacity(UserID, (int)RepackItem.IMITM, (int)RepackItem.Box_ID, maxCapacity);
                }

                #endregion

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (isSavePointOccured)
                    return false;

                if (errorCode == 6)
                {
                    #region ПЕРЕМЕЩЕНИЕ ИЗЛИШКОВ

                    var context = new ItemMoveSurplusContext()
                    {
                        Description = "Кол-во ТЕ в канале\r\nпревышает макс.\r\nдопустимое, разместите\r\nТЕ на стеллаже излишков",
                        Action = "Отсканируйте адресное место\r\nстеллажа излишков",
                        UserID = UserID,
                        WarehouseID = WarehouseID,
                        LOCN = LOCN,
                        BarcodeYL = RepackItem.barcode_YL,
                        StationID = this.StationID,
                        BoxBarCode = tbScanBox.Text,
                        PackInBox = Convert.ToInt32(tbPackInBox.Text)
                    };

                    var dlgRepackItemMove = new RepackItemMoveForm(context);
                    if (dlgRepackItemMove.ShowDialog() == DialogResult.OK)
                    {
                        if (CheckAnotherRepack())
                            return false;

                        return true;
                    }

                    #endregion
                }

                return false;
            }
        }

        private bool CheckAnotherRepack()
        {
            try
            {
                int? soqs = null;

                using (var adapter = new Data.WHTableAdapters.QueriesTableAdapter())
                    adapter.NeedAnotherRepack(this.UserID, this.WarehouseID, this.LOCN, RepackItem.barcode_YL, ref soqs);

                if (soqs.HasValue && soqs.Value > 0)
                {
                    tbCurrentQuantityInYL.Text = soqs.Value.ToString();

                    BoxContentQuantity = 0;
                    lblBoxContentQuantity.Visible = false;

                    tbPackInBox.Clear();

                    tbScanBox.Enabled = true;
                    tbScanBox.Text = string.Empty;
                    //tbScanSSCC.Text = string.Empty;
                    tbScanTrolleyPlace.Text = string.Empty;

                    //tbPackInBox.Focus();
                    tbScanBox.Focus();

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        [Obsolete]
        private bool SaveCancelReason()
        {
            try
            {
                #region УКАЗАНИЕ ПРИЧИНЫ ОТМЕНЫ ПЕРЕПАКОВКИ ТОВАРА
              
                Data.WH.RepackItemCancelReasonsDataTable reasons = null;
                using (var adapter = new Data.WHTableAdapters.RepackItemCancelReasonsTableAdapter())
                    reasons = adapter.GetData(UserID, "MG");

                var dlgSelectReason = new WMSOffice.Dialogs.RichListForm();
                dlgSelectReason.Text = "Укажите причину отмены перепаковки";
                dlgSelectReason.AddColumn("Description", "Description", "Причина");
                dlgSelectReason.ColumnForFilters = new List<string>(new string[] { "Description" });
                dlgSelectReason.FilterChangeLevel = 0;
                dlgSelectReason.DataSource = reasons;
                if (dlgSelectReason.ShowDialog() != DialogResult.OK)
                    return false;

                var reasonID = (dlgSelectReason.SelectedRow as Data.WH.RepackItemCancelReasonsRow).ReasonCode;
                var reasonDescription = (dlgSelectReason.SelectedRow as Data.WH.RepackItemCancelReasonsRow).Description;

                var context = new ItemMoveShortageContext()
                {
                    Description = string.Format("Вы отменяете задание перепаковки\r\nЖЭ № \"{0}\"\r\n по причине\"{1}\"", RepackItem.barcode_YL, reasonDescription),
                    Action = "Отсканируйте адресное место\r\nстеллажа проблемного товара",
                    UserID = UserID,
                    WarehouseID = WarehouseID,
                    LOCN = LOCN,
                    BarcodeYL = RepackItem.barcode_YL,
                    ReasonCode = reasonID,
                    StationID = this.StationID
                };

                var dlgRepackItemMove = new RepackItemMoveForm(context);
                if (dlgRepackItemMove.ShowDialog() == DialogResult.OK)
                {
                    return true;
                }
               
                #endregion

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool MoveNonliquidRemains()
        {
            try
            {
                Data.WH.RepackItemCancelReasonsDataTable reasons = null;
                using (var adapter = new Data.WHTableAdapters.RepackItemCancelReasonsTableAdapter())
                    reasons = adapter.GetData(UserID, "MG");

                var dlgSelectReason = new WMSOffice.Dialogs.RichListForm();
                dlgSelectReason.Text = "Укажите причину перемещения проблемного товара";
                dlgSelectReason.AddColumn("Description", "Description", "Причина");
                dlgSelectReason.ColumnForFilters = new List<string>(new string[] { "Description" });
                dlgSelectReason.FilterChangeLevel = 0;
                dlgSelectReason.DataSource = reasons;
                if (dlgSelectReason.ShowDialog() != DialogResult.OK)
                    return false;

                var reasonID = (dlgSelectReason.SelectedRow as Data.WH.RepackItemCancelReasonsRow).ReasonCode;
                var reasonDescription = (dlgSelectReason.SelectedRow as Data.WH.RepackItemCancelReasonsRow).Description;

                var context = new ItemMoveRemainsContext()
                {
                    Caption = string.Format("Перемещение проблемного товара [{0}]", reasonDescription),
                    Description = "Переместите остаток ЖЭ\r\nна стеллаж проблемного товара",
                    Action = "Отсканируйте место\r\nстеллажа проблемного товара",
                    UserID = UserID,
                    WarehouseID = WarehouseID,
                    LOCN = LOCN,
                    BarcodeYL = RepackItem.barcode_YL,
                    StationID = StationID,
                    ReasonCode = reasonID
                };

                var dlgRepackItemMove = new RepackItemMoveForm(context);
                if (dlgRepackItemMove.ShowDialog() != DialogResult.OK)
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void RepackItemForm_Load(object sender, EventArgs e)
        {
            Initialize(true);
        }

        private void Initialize(bool needSubscription)
        {
            tbYLBarcode.Text = RepackItem.barcode_YL;
            tbBoxName.Text = RepackItem.IsBXNAMENull() ? string.Empty : RepackItem.BXNAME;
            tbItemName.Text = RepackItem.IsnazvaNull() ? string.Empty : RepackItem.nazva;
            tbItemID.Text = RepackItem.IMITM.ToString();
            tbVendorLot.Text = RepackItem.IsIORLOTNull() ? string.Empty : RepackItem.IORLOT;
            tbShelfLife.Text = RepackItem.IsiommejNull() ? string.Empty : RepackItem.iommej.ToShortDateString();

            tbCurrentQuantityInYL.Text = CurrentQuantityInYL.ToString();
            cbCanUseBox.Checked = RepackItem.IsCanUseBoxNull() ? false : Convert.ToBoolean(RepackItem.CanUseBox);
            if (cbCanUseBox.Checked)
            {
                tCanUseBox.Enabled = true;
                lblScanBox.Text = "Отсканируйте ТЕ (SSCC):";
            }

            if (!RepackItem.IsREC_SOQSNull())
                lblRecSOQS.Text = string.Format("(Рек.: {0})", (int)RepackItem.REC_SOQS);

            if (needSubscription)
            {
                // Информация о тележке
                if (!string.IsNullOrEmpty(this.TrolleyBarCode))
                    lblCaption.Text = string.Format("{0}. Зафиксирована тележка № {1}", lblCaption.Text, this.TrolleyBarCode); 

                tbScanItem.TextChanged += new EventHandler(tbScanItem_TextChanged);
                tbScanItem.Leave += new EventHandler(tbScanItem_Leave);

                tbManualItem.KeyPress += new KeyPressEventHandler(AllowOnlyNumber_KeyPress);
                tbManualItem.Leave += new EventHandler(tbManualItem_Leave);

                tbPackInBox.KeyPress += new KeyPressEventHandler(AllowOnlyNumber_KeyPress);
                tbPackInBox.KeyDown += new KeyEventHandler(tbPackInBox_KeyDown);
                tbPackInBox.Leave += new EventHandler(tbPackInBox_Leave);

                tbScanBox.TextChanged += new EventHandler(tbScanBox_TextChanged);
                tbScanBox.Leave += new EventHandler(tbScanBox_Leave);

                tbScanSSCC.TextChanged += new EventHandler(tbScanSSCC_TextChanged);
                tbScanSSCC.Leave += new EventHandler(tbScanSSCC_Leave);

                tbScanTrolleyPlace.TextChanged += new EventHandler(tbScanTrolleyPlace_TextChanged);
                tbScanTrolleyPlace.Leave += new EventHandler(tbScanTrolleyPlace_Leave);
            }
        }

        private void tCanUseBox_Tick(object sender, EventArgs e)
        {
            pbCanUseBoxExclamation.Visible = !pbCanUseBoxExclamation.Visible;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            CheckNeedBunch();
        }

        /// <summary>
        /// Проверка необходимости вязки
        /// </summary>
        private void CheckNeedBunch()
        {
            lblBunchQuantity.Visible = false;
            tbBunchQuantity.Visible = false;

            if (!RepackItem.IsSRUORGNull() && RepackItem.SRUORG > 0.0F)
            {
                MessageBox.Show(string.Format("Необходима вязка с {0} шт. в связке.", (int)RepackItem.SRUORG), "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lblBunchQuantity.Visible = true;
                tbBunchQuantity.Visible = true;
                tbBunchQuantity.Text = RepackItem.SRUORG.ToString();
            }
        }

      
        void tbScanItem_TextChanged(object sender, EventArgs e)
        {
            //SelectNextControl(tbScanItem, true, true, false, false);
            //if (RepackPopulationOccured && ValidateFillBox())
            if (!tbScanBox.Enabled && ValidateFillBox())
                tbPackInBox.Focus();
            else
                tbScanBox.Focus();
        }

        void tbScanItem_Leave(object sender, EventArgs e)
        {
            if (CheckDataLockInstalled)
                return;

            try
            {
                if (ValidateFillItem())
                {
                    int? errorCode = null;
                    string errorMessage = null;

                    using (var adapter = new Data.WHTableAdapters.QueriesTableAdapter())
                        adapter.CheckRepackItemInYL(UserID, tbScanItem.Text, RepackItem.barcode_YL, ref errorCode, ref errorMessage);

                    if ((errorCode.HasValue && errorCode.Value > 0) || !string.IsNullOrEmpty(errorMessage))
                    {
                        if (errorCode == 2) // потоварная пересортица
                        {
                            // узнаем КНН сканируемого товара из сообщения об ошибке
                            int scannedItem;
                            int.TryParse(Regex.Replace(errorMessage, @"[^\d]", ""), out scannedItem);

                            var dlgRepackItemCheckRegradingUnits = new RepackItemCheckRegradingUnits(this.RepackItem, scannedItem);
                            dlgRepackItemCheckRegradingUnits.UserID = this.UserID;
                            dlgRepackItemCheckRegradingUnits.WarehouseID = WarehouseID;
                            dlgRepackItemCheckRegradingUnits.LOCN = LOCN;
                            dlgRepackItemCheckRegradingUnits.StationID = StationID;

                            if (dlgRepackItemCheckRegradingUnits.ShowDialog() == DialogResult.OK)
                            {
                                this.DialogResult = DialogResult.Abort;
                                this.Close();
                            }
                        }
                        else
                            throw new Exception(errorMessage);
                    }
                    else // посерийная пересортица
                    {
                        var dlgRepackItemCheckRegradingUnitSeries = new RepackItemCheckRegradingUnitSeries(this.RepackItem);
                        dlgRepackItemCheckRegradingUnitSeries.UserID = this.UserID;
                        dlgRepackItemCheckRegradingUnitSeries.WarehouseID = WarehouseID;
                        dlgRepackItemCheckRegradingUnitSeries.LOCN = LOCN;
                        dlgRepackItemCheckRegradingUnitSeries.StationID = StationID;

                        if (dlgRepackItemCheckRegradingUnitSeries.ShowDialog() == DialogResult.OK)
                        {
                            this.DialogResult = DialogResult.Abort;
                            this.Close();
                        }
                    }
                    //throw new Exception(errorMessage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                tbScanItem.Focus();
                tbScanItem.SelectAll();
            }
        }

        private bool ValidateFillItem()
        {
            return !string.IsNullOrEmpty(tbScanItem.Text);
        }

        void tbManualItem_Leave(object sender, EventArgs e)
        {
            if (CheckDataLockInstalled)
                return;

            try
            {
                if (ValidateFillManualItem())
                {
                    var needScanBoss = true;
                    var abortScanBoss = false;
                    while (needScanBoss)
                    {
                        try
                        {
                            var bossID = (int?)null;
                            var dlgBossScanner = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                            {
                                Label = "Отсканируйте бэйдж старшего,\r\nкоторый отвечает за контроль перепаковки",
                                Text = "Перепаковка в ТЕ",
                                Image = Properties.Resources.role,
                                //OnlyNumbersInBarcode = true
                                UseScanModeOnly = true
                            };

                            if (dlgBossScanner.ShowDialog() != DialogResult.OK)
                            {
                                abortScanBoss = true;
                                break;
                            }

                            int? errorCode = null;
                            string errorMessage = null;

                            using (var adapter = new Data.WHTableAdapters.QueriesTableAdapter())
                                adapter.CheckBossForRepackItem(UserID, dlgBossScanner.Barcode, ref errorCode, ref errorMessage);

                            if ((errorCode.HasValue && errorCode.Value > 0) || !string.IsNullOrEmpty(errorMessage))
                                throw new Exception(errorMessage);

                            needScanBoss = false;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    if (abortScanBoss)
                    {
                        tbManualItem.Clear();
                        tbManualItem.Focus();
                    }
                    else
                    {
                        tbScanItem.Text = tbManualItem.Text;
                        tbManualItem.Clear();

                        tbScanItem.Focus();
                        //SelectNextControl(tbScanItem, true, true, false, false);
                        tbScanItem_TextChanged(tbScanItem, EventArgs.Empty);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                tbManualItem.Focus();
                tbManualItem.SelectAll();
            }
        }

        private bool ValidateFillManualItem()
        {
            return !string.IsNullOrEmpty(tbManualItem.Text);
        }


        void tbScanBox_TextChanged(object sender, EventArgs e)
        {
            //SelectNextControl(tbScanBox, true, true, false, false);
            tbPackInBox.Focus();
        }

        void tbScanBox_Leave(object sender, EventArgs e)
        {
            if (CheckDataLockInstalled)
                return;

            int? errorCode = null;
            string errorMessage = null;

            NeedTransferSurplus = false;

            try
            {
                if (ValidateFillBox())
                {
                    using (var adapter = new Data.WHTableAdapters.QueriesTableAdapter())
                        adapter.CheckRepackBoxType(UserID, WarehouseID, tbScanBox.Text, (int)RepackItem.IMITM, RepackItem.IsCanUseBoxNull() ? (int?)null : RepackItem.CanUseBox, ref errorCode, ref errorMessage);

                    if ((errorCode.HasValue && errorCode.Value > 0) || !string.IsNullOrEmpty(errorMessage))
                        throw new Exception(errorMessage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (errorCode == 4)
                {
                    NeedTransferSurplus = true;
                    return;
                }

                tbScanBox.Focus();
                tbScanBox.SelectAll();
            }
        }

        private bool ValidateFillBox()
        {
            return !string.IsNullOrEmpty(tbScanBox.Text);
        }


        private void AllowOnlyNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }

        void tbPackInBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (AnotherRepackOccured && ValidateFillSSCC())
                    tbScanTrolleyPlace.Focus();
                else
                    tbScanSSCC.Focus();
                    //SelectNextControl(tbPackInBox, true, true, false, false);
            }
        }

        void tbPackInBox_Leave(object sender, EventArgs e)
        {
            if (CheckDataLockInstalled)
                return;

            int? errorCode = null;
            string errorMessage = null;

            #region ПРОВЕРКА ВВЕДЕННОГО КОЛИЧЕСТВА 

            try
            {
                if (ValidateFillPackInBox())
                {
                    int parsedQtty = 0;
                    if (!int.TryParse(tbPackInBox.Text, out parsedQtty))
                        throw new Exception("Ожидается для ввода целое число!");

                    using (var adapter = new Data.WHTableAdapters.QueriesTableAdapter())
                        adapter.CheckRepackSoqsInYL(UserID, WarehouseID, LOCN, RepackItem.barcode_YL, parsedQtty, ref errorCode, ref errorMessage);
                }
                else
                    return;
            }
            catch (Exception ex)
            {
                if (errorCode.HasValue && (errorCode.Value == 4 || errorCode.Value == 5))
                {
                    MessageBox.Show(ex.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    tbPackInBox.Focus();
                    tbPackInBox.SelectAll();
                    return;
                }
            }

            #endregion 

            #region ПЕРЕМЕЩЕНИЕ ИЗЛИШКОВ

            try
            {
                if (NeedTransferSurplus && (!errorCode.HasValue || errorCode.Value == 4 || errorCode.Value == 5))
                {
                    var context = new ItemMoveSurplusContext()
                    {
                        Description = "Кол-во ТЕ в канале\r\nпревышает макс.\r\nдопустимое, разместите\r\nТЕ на стеллаже излишков",
                        Action = "Отсканируйте адресное место\r\nстеллажа излишков",
                        UserID = UserID,
                        WarehouseID = WarehouseID,
                        LOCN = LOCN,
                        BarcodeYL = RepackItem.barcode_YL,
                        StationID = this.StationID,
                        BoxBarCode = tbScanBox.Text,
                        PackInBox = Convert.ToInt32(tbPackInBox.Text)
                    };

                    var dlgRepackItemMove = new RepackItemMoveForm(context);
                    if (dlgRepackItemMove.ShowDialog() != DialogResult.OK)
                        return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbPackInBox.Focus();
                tbPackInBox.SelectAll();
                return;
            }

            #endregion

            #region ПРОВЕРКА ИСПОЛЬЗОВАНИЯ ТОЙ ЖЕ ТЕ ДЛЯ СЛЕД. ПЕРЕПАКОВКИ

            try
            {
                if (!errorCode.HasValue || errorCode.Value == 5)
                {
                    int itemsInBox = 0;
                    int.TryParse(tbPackInBox.Text, out itemsInBox);

                    int? canLeaveBox = null;
                    using (var adapter = new Data.WHTableAdapters.QueriesTableAdapter())
                        adapter.RepackItemCheckCanLeaveBox(UserID, WarehouseID, LOCN, RepackItem.barcode_YL, itemsInBox, ref canLeaveBox);

                    if (canLeaveBox.HasValue && Convert.ToBoolean(canLeaveBox.Value) == true)
                    {
                        btnAddPackToBox.Visible = true;
                        tAddPackToBox.Enabled = true;

                        //if (MessageBox.Show("В текущих заданиях есть еще позиции с такой же серией и КНН.\r\nЖелаете оставить ТЕ на столе перепаковки?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        //{
                        //    this.CanLeaveBox = canLeaveBox.Value;
                        //    tbScanSSCC.Text = string.Empty;
                        //    tbScanSSCC.Enabled = false;
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbPackInBox.Focus();
                tbPackInBox.SelectAll();
                return;
            }

            #endregion

            #region OBSOLETE

            //try
            //{
            //    if (ValidateFillPackInBox())
            //    {
            //        int parsedQtty = 0;
            //        if (!int.TryParse(tbPackInBox.Text, out parsedQtty))
            //            throw new Exception("Ожидается для ввода целое число!");

            //        using (var adapter = new Data.WHTableAdapters.QueriesTableAdapter())
            //            adapter.CheckRepackSoqsInYL(UserID, WarehouseID, LOCN, RepackItem.barcode_YL, parsedQtty, ref errorCode, ref errorMessage);

            //        if ((errorCode.HasValue && errorCode.Value > 0) || !string.IsNullOrEmpty(errorMessage))
            //            //if (errorCode.HasValue && errorCode.Value != 5) // событие "кол-во меньше рек." считать некритичным
            //                throw new Exception(errorMessage);

            //        // Доп. проверка
            //        int itemsInBox = 0;
            //        int.TryParse(tbPackInBox.Text, out itemsInBox);

            //        int? canLeaveBox = null;
            //        using (var adapter = new Data.WHTableAdapters.QueriesTableAdapter())
            //            adapter.RepackItemCheckCanLeaveBox(UserID, WarehouseID, LOCN, RepackItem.barcode_YL, itemsInBox, ref canLeaveBox);

            //        if (canLeaveBox.HasValue && Convert.ToBoolean(canLeaveBox.Value) == true)
            //        {
            //            if (MessageBox.Show("В текущих заданиях есть еще позиции с такой же серией и КНН.\r\nЖелаете оставить ТЕ на столе перепаковки?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //            {
            //                this.CanLeaveBox = canLeaveBox.Value;
            //                tbScanSSCC.Text = string.Empty;
            //                tbScanSSCC.Enabled = false;
            //            }
            //        }
            //    }             
            //}
            //catch (Exception ex)
            //{
            //    if (errorCode.HasValue && (errorCode.Value == 4 || errorCode.Value == 5))
            //    {
            //        MessageBox.Show(ex.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    }
            //    else
            //    {
            //        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //        tbPackInBox.Focus();
            //        tbPackInBox.SelectAll();
            //        return;
            //    }

            //    if (NeedTransferSurplus)
            //    {
            //        #region ПЕРЕМЕЩЕНИЕ ИЗЛИШКОВ

            //        var context = new ItemMoveSurplusContext()
            //        {
            //            Description = "Кол-во ТЕ в канале\r\nпревышает макс.\r\nдопустимое, разместите\r\nТЕ на стеллаже излишков",
            //            Action = "Отсканируйте адресное место\r\nстеллажа излишков",
            //            UserID = UserID,
            //            WarehouseID = WarehouseID,
            //            LOCN = LOCN,
            //            BarcodeYL = RepackItem.barcode_YL,
            //            StationID = this.StationID,
            //            BoxBarCode = tbScanBox.Text,
            //            PackInBox = Convert.ToInt32(tbPackInBox.Text)
            //        };

            //        var dlgRepackItemMove = new RepackItemMoveForm(context);
            //        if (dlgRepackItemMove.ShowDialog() == DialogResult.OK)
            //            return;

            //        #endregion
            //    }
            //}

            #endregion
        }

        private bool ValidateFillPackInBox()
        {
            return !string.IsNullOrEmpty(tbPackInBox.Text);
        }


        void tbScanSSCC_TextChanged(object sender, EventArgs e)
        {
            //SelectNextControl(tbScanSSCC, true, true, false, false);
            tbScanTrolleyPlace.Focus();
        }

        void tbScanSSCC_Leave(object sender, EventArgs e)
        {
            if (CheckDataLockInstalled)
                return;

            try
            {
                if (ValidateFillSSCC())
                {
                    int? errorCode = null;
                    string errorMessage = null;

                    using (var adapter = new Data.WHTableAdapters.QueriesTableAdapter())
                        adapter.CheckRepackTrolley(UserID, WarehouseID, tbScanSSCC.Text, LOCN, ref errorCode, ref errorMessage);

                    if ((errorCode.HasValue && errorCode.Value > 0) || !string.IsNullOrEmpty(errorMessage))
                        throw new Exception(errorMessage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                tbScanSSCC.Focus();
                tbScanSSCC.SelectAll();
            }   
        }

        private bool ValidateFillSSCC()
        {
            return !string.IsNullOrEmpty(tbScanSSCC.Text);
        }


        void tbScanTrolleyPlace_TextChanged(object sender, EventArgs e)
        {
            //SelectNextControl(tbScanTrolleyPlace, true, true, true, false);
            btnOK.Focus();
        }

        void tbScanTrolleyPlace_Leave(object sender, EventArgs e)
        {
            if (CheckDataLockInstalled)
                return;

            try
            {
                if (ValidateFillTrolleyPlace())
                {
                    int? errorCode = null;
                    string errorMessage = null;

                    using (var adapter = new Data.WHTableAdapters.QueriesTableAdapter())
                        adapter.CheckRepackTrolleyPlace(UserID, tbScanSSCC.Text, tbScanTrolleyPlace.Text, ref errorCode, ref errorMessage);

                    if ((errorCode.HasValue && errorCode.Value > 0) || !string.IsNullOrEmpty(errorMessage))
                        throw new Exception(errorMessage);

                    //if (!CheckAnotherRepack())
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                tbScanTrolleyPlace.Focus();
                tbScanTrolleyPlace.SelectAll();
            }   
        }

        private bool ValidateFillTrolleyPlace()
        {
            return !string.IsNullOrEmpty(tbScanTrolleyPlace.Text);
        }

        private void tAddPackToBox_Tick(object sender, EventArgs e)
        {
            pbAddPackToBoxExclamation.Visible = !pbAddPackToBoxExclamation.Visible;
        }

        private void btnAddPackToBox_Click(object sender, EventArgs e)
        {
            RepackPopulationOccured = true;

            var dlgAddToBox = new RepackItemAddToBox(RepackItem.barcode_YL) { UserID = this.UserID, WarehouseID = this.WarehouseID, LOCN = this.LOCN };
            if (dlgAddToBox.ShowDialog() == DialogResult.OK)
            {
                this.CanLeaveBox = 1;

                // Попытка сохранить текущую перепаковку
                //
                if (!this.SaveChanges(true))
                {
                    MessageBox.Show("Не удалось доложить товар в ТЕ.\r\nПопробуйте снова.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.CanLeaveBox = 0;
                    return;
                }

                this.CanLeaveBox = 0;

                // Инициализация новой перепаковки (для другой выбранной ЖЭ)
                //
                this.RepackItem = dlgAddToBox.RepackItem;
                Initialize(false);
                CheckNeedBunch();

                BoxContentQuantity += Convert.ToInt32(tbPackInBox.Text);
                lblBoxContentQuantity.Text = string.Format("Содержимое ТЕ: {0} шт.", BoxContentQuantity);
                lblBoxContentQuantity.Visible = true;

                tbScanBox.Enabled = false;

                tAddPackToBox.Enabled = false;
                btnAddPackToBox.Visible = false;
                pbAddPackToBoxExclamation.Visible = false;

                tbScanItem.Text = string.Empty;
                tbPackInBox.Clear();
                tbScanItem.Focus();
            }

            RepackPopulationOccured = false;
        }

        private void btnShowBoxInfo_Click(object sender, EventArgs e)
        {
            var dlgRepackItemShowBoxInfo = new RepackItemShowBoxInfo(tbScanBox.Text) { UserID = this.UserID };
            dlgRepackItemShowBoxInfo.ShowDialog();
        }
    }
}
