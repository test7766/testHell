using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using WMSOffice.Dialogs;
using WMSOffice.Dialogs.Containers;
using WMSOffice.Dialogs.PickControl;
using System.Windows.Forms.VisualStyles;
using WMSOffice.Dialogs.Receive;
using WMSOffice.Dialogs.ColdChain;
using WMSOffice.Dialogs.PickControl.Quiz;
using WMSOffice.Classes.PickControl;
using WMSOffice.Classes;
using WMSOffice.Dialogs.Complaints;
using WMSOffice.Controls;

namespace WMSOffice.Window
{
    public partial class PickControlWindow : GeneralWindow
    {
        private readonly WMSOffice.Dialogs.PickControl.PlatzkartPickDirectionForm.PlatzkartBoxesList platzkartBoxes = new WMSOffice.Dialogs.PickControl.PlatzkartPickDirectionForm.PlatzkartBoxesList();

        /// <summary>
        /// Документ для контроля излишков
        /// </summary>
        private SurplusContainerDoc surplusContainerDoc = null;

        /// <summary>
        /// Документ для контроля НТВ
        /// </summary>
        private NTVContainerDoc ntvContainerDoc = null;

        /// <summary>
        /// Менеджер опроса
        /// </summary>
        private QuizManager quizManager = null;

        /// <summary>
        /// ID версии процесса
        /// </summary>
        public long? ProcessVersionID { get; private set; }

        /// <summary>
        /// Признак работы в версии № 2 (Излишки/Недостача/НТВ)
        /// </summary>
        public bool IsProcessVersionEquals_2 { get { return this.ProcessVersionID.HasValue && ProcessVersionID.Value == 2; } }

        /// <summary>
        /// Признак работы в версии № 4 (Весовой контроль)
        /// </summary>
        public bool IsProcessVersionEquals_4 { get { return this.ProcessVersionID.HasValue && ProcessVersionID.Value == 4; } }

        // режим поиска серий для излишка
        private int? surplusMode = (int?)null;
        // режим поиска серий в архиве
        private int? archiveMode = (int?)null;

        /// <summary>
        /// Тип Тары
        /// </summary>
        public static int? InnerBoxType {get;set;}

        /// <summary>
        /// Ш/К Тары
        /// </summary>
        public static string InnerEticBarCode { get; set; }

        /// <summary>
        /// Необходимость наличия крышки при выборе ОТ
        /// </summary>
        public static int? InnerNeedTareCapFlag { get; set; }

        /// <summary>
        /// Сценарий закрытия документа контроля
        /// </summary>
        public static int? InnerActionType { get; set; }

        /// <summary>
        /// Признак мультидробного сборочного
        /// </summary>
        public bool IsMDP { get; set; }

        /// <summary>
        /// Признак сборочного "плацкарт"
        /// </summary>
        public bool IsPlatzkart { get; set; }

        /// <summary>
        /// Признак необходимости взвешивания каждой единицы товара контроля 
        /// </summary>
        public bool NeedReWeightEveryItem { get; set; }

        /// <summary>
        /// Признак необходимости проведения контроля интернет-заказов
        /// </summary>
        public bool NeedControlInternetOrder { get; set; }

        /// <summary>
        /// Признак наличия расхождений контроля
        /// </summary>
        public bool HasDifference { get; set; }

        public PickControlWindow()
        {
            InitializeComponent();
            IsRepeatControl = false;
            UndoEnabled = false;
            lblDocType.Text = lblDocNumber.Text = lblDocDate.Text = lblNumber.Text = lblDelivery.Text = lblDeliveryDate.Text =
                lblContainer.Text = lblDepartment.Text = lblRegim.Text = tbBarcode.Text = "";

            PickControlWindow.InnerBoxType = (int?)null;
            PickControlWindow.InnerEticBarCode = (string)null;
            PickControlWindow.InnerNeedTareCapFlag = (int?)null;
            PickControlWindow.InnerActionType = (int?)null;
        }


        private double numPickSlip = -1; // номер сборочного листа
        private byte isCold = 0; // признак холодильного оборудования (0 - не используется)

        private bool isPlasticBox = false; // признак является ли ящик пластиковым

        /// <summary>
        /// Проверка возможности применения изменений
        /// </summary>
        public bool CommitVersionChanges { get; private set; }

        private void PickControlWindow_Load(object sender, EventArgs e)
        {
            this.CheckCommitVersionChanges(); // проверка на применение изменений

            // получение версии процесса
            this.AdaptProcessVesion();

            quizManager = new QuizManager(this.DocID, this.DocType, this.UserID); // Создание менеджера опросов

            #region ПОЛУЧАЕМ ИНФОРМАЦИЮ ПО НОМЕРУ ДОКУМЕНТА

            this.RefreshHeader();

            #endregion

            #region ИНИЦИАЛИЗАЦИЯ РАБОТЫ С КОНТЕЙНЕРАМИ ДЛЯ ФИКСАЦИИ РЕКЛАМАЦИЙ

            tsContainers.Visible = false;
            Line_Type_Desc.Visible = false;

            if (this.IsProcessVersionEquals_2)
            {
                ////// Тип расхождения виден на повторном контроле
                ////Line_Type_Desc.Visible = this.IsRepeatControl;

                // Просмотр расхождений в разрезе документа доступен на повторном контроле
                lblPickControlVariances.Visible = this.IsRepeatControl;
                sbPreviewPickControlSurplus.Visible = this.IsRepeatControl;
                sbPreviewPickControlNTV.Visible = false; //this.IsRepeatControl;

                tsContainers.Visible = true;// this.IsRepeatControl;
                var userLogin = Environment.UserName;

                #region ИНИЦИАЛИЗАЦИЯ РАБОТЫ С КОНТЕЙНЕРОМ ИЗЛИШКОВ

                lblSurplusContainerNumber.Text = string.Empty;
                miOpenSurplusContainer.Enabled = true;
                miCloseSurplusContainer.Enabled = false;

                surplusContainerDoc = new SurplusContainerDoc(this.UserID, userLogin, this.DocID, this.ProcessVersionID, this.CommitVersionChanges) { IsRepeatControl = this.IsRepeatControl };
                surplusContainerDoc.OnOpen += delegate(object s, EventArgs ea)
                {
                    if (surplusContainerDoc.DocID.HasValue)
                    {
                        lblSurplusContainerNumber.Text = string.Format("{0}", surplusContainerDoc.BarCode);

                        miOpenSurplusContainer.Enabled = true;
                        miOpenSurplusContainer.Text = "Просмотр";

                        miCloseSurplusContainer.Enabled = true;
                    }
                    else
                    {
                        //if (!this.IsRepeatControl)
                        //    tsContainers.Visible = false;
                    }
                };

                if (this.IsRepeatControl)
                {
                    miCloseSurplusContainer.Visible = false;
                }
                else
                {
                    surplusContainerDoc.OnClose += delegate(object s, EventArgs ea)
                    {
                        lblSurplusContainerNumber.Text = string.Empty;
                        miCloseSurplusContainer.Enabled = false;

                        miOpenSurplusContainer.Enabled = true;
                        miOpenSurplusContainer.Text = "Открыть";
                    };
                }

                surplusContainerDoc.TryOpen();

                #endregion

                #region ИНИЦИАЛИЗАЦИЯ РАБОТЫ С КОНТЕЙНЕРОМ НТВ

                //if (this.IsRepeatControl)
                //{
                lblNTVContainerNumber.Text = string.Empty;
                miOpenNTVContainer.Enabled = true;
                miCloseNTVContainer.Enabled = false;

                ntvContainerDoc = new NTVContainerDoc(this.UserID, userLogin, this.DocID, this.ProcessVersionID, this.CommitVersionChanges) { IsRepeatControl = this.IsRepeatControl };
                ntvContainerDoc.OnOpen += delegate(object s, EventArgs ea)
                {
                    btnNTVContainerActions.Visible = false;
                    lblNTVContainerNumber.Visible = false;
                    toolStripSeparator4.Visible = false;

                    if (!surplusContainerDoc.DocID.HasValue && !this.IsRepeatControl)
                        tsContainers.Visible = false;

                    #region OBSOLETE

                    //if (ntvContainerDoc.DocID.HasValue)
                    //{
                    //    lblNTVContainerNumber.Text = string.Format("{0}", ntvContainerDoc.BarCode);

                    //    miOpenNTVContainer.Enabled = true;
                    //    miOpenNTVContainer.Text = "Просмотр";

                    //    miCloseNTVContainer.Enabled = true;

                    //    if (!this.IsRepeatControl)
                    //    {
                    //        if (!surplusContainerDoc.DocID.HasValue)
                    //        {
                    //            btnSurplusContainerActions.Visible = false;
                    //            lblSurplusContainerNumber.Visible = false;
                    //            toolStripSeparator3.Visible = false;
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    if (!this.IsRepeatControl)
                    //    {
                    //        if (surplusContainerDoc.DocID.HasValue)
                    //        {
                    //            btnNTVContainerActions.Visible = false;
                    //            lblNTVContainerNumber.Visible = false;
                    //            toolStripSeparator4.Visible = false;
                    //        }
                    //        else
                    //        {
                    //            tsContainers.Visible = false;
                    //        }
                    //    }
                    //}

                    #endregion
                };

                if (this.IsRepeatControl)
                {
                    miCloseNTVContainer.Visible = false;
                }
                else
                {
                    ntvContainerDoc.OnClose += delegate(object s, EventArgs ea)
                    {
                        lblNTVContainerNumber.Text = string.Empty;
                        miCloseNTVContainer.Enabled = false;

                        miOpenNTVContainer.Enabled = true;
                        miOpenNTVContainer.Text = "Открыть";
                    };
                }

                ntvContainerDoc.TryOpen();
                //}
                //else
                //{
                //    btnNTVContainerActions.Visible = false;
                //    lblNTVContainerNumber.Visible = false;
                //    toolStripSeparator4.Visible = false;
                //}

                #endregion
            }

            #endregion

            this.ShowGreenLines = this.CommitVersionChanges && IsRepeatControl ? 1 : (int?)null;

            pnlFooter.Visible = this.CommitVersionChanges && !IsRepeatControl && !this.IsPlatzkart;
            lblQuantityChange.Visible = !this.IsPlatzkart;

            #region ОРГАНИЗАЦИЯ СМЕЩЕНИЯ ОСНОВНОЙ ТАБЛИЦЫ НА ФОРМЕ

            int heightOffset = 0;
            heightOffset += pnlDescription.Visible ? 0 : pnlDescription.Height;
            heightOffset += lblSpecInstruction.Visible ? 0 : lblSpecInstruction.Height;
            heightOffset += tsContainers.Visible ? 0 : tsContainers.Height;
            gvLines.Location = new Point(gvLines.Location.X, gvLines.Location.Y - heightOffset);

            heightOffset += pnlFooter.Visible ? 0 : pnlFooter.Height;

            gvLines.Height = gvLines.Height + heightOffset;

            #endregion

            colNoItem.Visible = IsRepeatControl;

            colCollectors.Visible = true;

            colProperVendorLots.Visible = false;
            if (this.IsRepeatControl && this.IsProcessVersionEquals_2)
            {
                vendorLotDataGridViewTextBoxColumn.Visible = false;
                colProperVendorLots.Visible = true;
            }

            colDocRowDetails.Visible = false;
            btnSelectNextBox.Visible = false;
            if (this.IsProcessVersionEquals_2 && this.IsPlatzkart)
            {
                colDocRowDetails.Visible = true;

                if (IsRepeatControl)
                {
                    btnSelectNextBox.Visible = true;
 
                    btnSelectNextBox.Enabled = miSelectNextBox.Enabled = true;
                    btnCloseDoc.Enabled = miCloseDoc.Enabled = false;
                }
            }

            if (btnSelectNextBox.Visible == false)
                scMain.SplitterDistance -= btnSelectNextBox.Width;

            if (this.CommitVersionChanges)
            {
                Qty_Scanned.Visible = IsRepeatControl;
                Qty_Need.Visible = IsRepeatControl;

                if (IsRepeatControl)
                {
                    if (!this.NeedControlInternetOrder)
                    {
                        docQtyDataGridViewTextBoxColumn.HeaderText = "Отсканировано второй контроль, шт.";
                        docQtyDataGridViewTextBoxColumn.Width = 120;
                    }
                }
            }
            else
            {
                Qty_Scanned.Visible = false;
                Qty_Need.Visible = false;
            }

            if (this.IsProcessVersionEquals_2)
            {
                //Qty_Need.Visible = this.IsRepeatControl;
                //Qty_Need.HeaderText = "План, шт.";

                //Qty_Scanned.Visible = this.IsRepeatControl;
                //Qty_Scanned.HeaderText = "Факт, шт.";

                //docQtyDataGridViewTextBoxColumn.HeaderText = "Кол-во, шт.";
            }

            if (IsProcessVersionEquals_4)
            {
                WeightColumn.Visible = true;
            }

            btnEnableNTVRegisterMode.Visible = false;
            if (this.NeedReWeightEveryItem)
            {
                btnEnableNTVRegisterMode.Visible = true;
            }

            #region АНАЛИЗ ОТОБРАЖЕНИЯ ДОПОЛНИТЕЛЬНОГО УВЕДОМЛЕНИЯ В НАЧАЛЕ РАБОТЫ

            if (!IsRepeatControl)
            {
                try
                {
                    var entryAdditionalMessage = (string)null;
                    var messageColor = (string)null;
                    using (var adapter = new Data.PickControlTableAdapters.QueriesTableAdapter())
                        adapter.GetPickSlipEntryAdditionalMessage(this.UserID, this.DocID, ref entryAdditionalMessage, ref messageColor);
                    if (!string.IsNullOrEmpty(entryAdditionalMessage))
                    {
                        var message = entryAdditionalMessage.Trim();
                        var color = Color.FromName(string.IsNullOrEmpty(messageColor) ? "WHITE" : messageColor);
                        var errorForm = new WMSOffice.Dialogs.PickControl.FullScreenErrorForm(message, "ПРОДОЛЖИТЬ (Enter)", color);
                        errorForm.TimeOut = 2000;
                        errorForm.AutoClose = false;
                        errorForm.ShowDialog();
                    }
                }
                catch { }
            }

            #endregion

            RefreshLines();


            if (this.NeedControlInternetOrder)
            {
                OrdCode.Visible = true;
                EticCode.Visible = true;

                colNoItem.Visible = false;
                colCollectors.Visible = false;
            }
            else
            {
                OrdCode.Visible = false;
                EticCode.Visible = false;
            }

            // Инициализация расхождений интернет-заказов на повторном контроле
            if (this.IsRepeatControl && this.NeedControlInternetOrder && this.HasDifference)
            {
                var frmDiff = new CorrectInternetOrdersPickErrorsForm()
                {
                    UserID = this.UserID,
                    DocID = this.DocID,
                    PickSlipNumber = Convert.ToInt32(numPickSlip),
                    ProcessVersionID = this.ProcessVersionID,
                    CommitVersionChanges = this.CommitVersionChanges
                };

                if (frmDiff.ShowDialog() == DialogResult.OK || frmDiff.HasOnlySurplus)
                {
                    this.RefreshLines();
                    tbBarcode.Focus();

                    // При успешной корректировке сборочного отмена контроля становится недоступной
                    btnUndoDoc.Enabled = false;
                }
                else
                {
                    this.UndoDoc(true);
                    MessageBox.Show("Вы отменили текущий контроль.");
                }
            }
        }

        private void RefreshHeader()
        {
            using (Data.PickControlTableAdapters.PickSlipInfoTableAdapter adapter = new WMSOffice.Data.PickControlTableAdapters.PickSlipInfoTableAdapter())
            {
                try
                {
                    Data.PickControl.PickSlipInfoDataTable table = adapter.GetData(DocID);
                    if (table == null || table.Count != 1)
                        ShowError("Не найдена информация о документе!");
                    else
                    {
                        Data.PickControl.PickSlipInfoRow row = table[0];
                        lblDocType.Text = row.Doc_type;
                        lblDocNumber.Text = row.Doc_number.ToString();
                        lblDocDate.Text = row.Order_Date.ToShortDateString();
                        lblNumber.Text = row.PickSlip.ToString();
                        lblDelivery.Text = row.Delivery;
                        lblDeliveryDate.Text = row.Delivery_Date.ToShortDateString();
                        lblContainer.Text = row.Conteiner_id;
                        lblDepartment.Text = row.OtdelName;
                        lblRegim.Text = row.Delivery_Zone;
                        IsRepeatControl = !row.IsRelated_Doc_IDNull();
                        _allowChangeCount = row.AllowChangeCount;

                        // WMS - 418 -- погрузка товара в термобокс (подготовка параметров)
                        numPickSlip = row.PickSlip;
                        this.isCold = row.IsIsColdNull() ? (byte)0 : row.IsCold;

                        // Устанавливаем признак является ли ящик пластиковым
                        this.isPlasticBox = row.IsPlasticBoxFlagNull() ? false : Convert.ToBoolean(row.PlasticBoxFlag);

                        // для сборочных типа "волна" с ящиками на Черкассы сразу показываем уведомление "упакуй зеленым скотчем" (01.07.2013)
                        if (string.IsNullOrEmpty(row.SpecInstruction))
                            lblSpecInstruction.Visible = false;
                        else
                        {
                            lblSpecInstruction.Text = row.SpecInstruction;
                            lblSpecInstruction.ForeColor = Color.FromName(row.SpecInstruction_Color);
                            lblSpecInstruction.Visible = true;
                        }

                        // Анализ отображения рекомендаций к сборке 
                        if (row.IsPriorityInstructionNull() || string.IsNullOrEmpty(row.PriorityInstruction))
                        {
                            lblPriorityInstructionHeader.Visible = false;
                            lblPriorityInstruction.Visible = false;
                        }
                        else
                        {
                            lblPriorityInstruction.Text = row.PriorityInstruction;
                            lblPriorityInstruction.ForeColor = Color.FromName(row.PriorityInstruction_Color);
                            lblPriorityInstruction.Visible = true;
                            lblPriorityInstructionHeader.Visible = true;
                        }

                        //new Dialogs.Pack.GreenTapePackForm().ShowDialog();

                        tbBarcode.Focus();
                    }
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
            }
        }

        /// <summary>
        /// Проверка возможности применения изменений
        /// </summary>
        private void CheckCommitVersionChanges()
        {
            try
            {
                var commitVersionChanges = (bool?)null;
                using (var adapter = new Data.PickControlTableAdapters.QueriesTableAdapter())
                    adapter.CheckCommitVersionChanges(this.UserID, DocID, ref commitVersionChanges);

                CommitVersionChanges = commitVersionChanges.HasValue ? commitVersionChanges.Value : false;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
            finally
            {
                CommitVersionChanges = MainForm.IsTestVersion ? true : CommitVersionChanges;
            }
        }

        /// <summary>
        /// Получение версии процесса
        /// </summary>
        private void AdaptProcessVesion()
        {
            try
            {
                var versionID = (long?)null;
                using (var adapter = new Data.PickControlTableAdapters.QueriesTableAdapter())
                    adapter.AdaptProcessVersion(this.UserID, ref versionID);

                if (versionID.HasValue)
                    this.ProcessVersionID = versionID.Value;

            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void RefreshLines()
        {
            docRowsBindingSource.Filter = "";
            docRowsBindingSource.Sort = "";
            docRowsTableAdapter.Fill(pickControl.DocRows, DocID, HideWhiteRows, ShowGreenLines, this.ProcessVersionID);
            if (gvLines.Rows.Count > 0)
                gvLines.Rows[0].Selected = true;
        }

        private void SelectRow(ref Data.PickControl.DocRowsRow docRow)
        {
            foreach (DataGridViewRow dgvr in gvLines.Rows)
            {
                var dr = (dgvr.DataBoundItem as DataRowView).Row as Data.PickControl.DocRowsRow;

                if (dr.Item_ID.Equals(docRow.Item_ID) &&
                    dr.Vendor_Lot.Equals(docRow.Vendor_Lot) &&
                    dr.UnitOfMeasure.Equals(docRow.UnitOfMeasure))
                {
                    docRow = dr;
                    dgvr.Selected = true;
                    break;
                }
            }
        }

        private bool _allowChangeCount = false;
        private void tbBarcode_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbBarcode.Text))
            {
                //if (this.NeedReWeightEveryItem)
                //    return;

                //if (this.IsPlatzkart && !this.IsRepeatControl)
                //    return;


                // Разрешен ввод количества для товара (по ENTER):
                // - в случае установленного режима ввода кол-ва  для документа
                // - документа первичного контроля
                // - товара, введенного без штрих кода
                if (UndoEnabled && (_allowChangeCount || !_isRepeatControl || _scanType == "M"))
                {
                    try
                    {
                        if (this.IsProcessVersionEquals_2 && this.ntvContainerDoc != null && this.IsRepeatControl)
                        {
                            #region ВВОД КОЛИЧЕСТВА В ВЕРСИИ РАБОТЫ С КОНТЕЙНЕРАМИ НТВ

                            _ntvFlag = false;
                            _ntvQuantity = 0;

                            var form = new SetCountNTVForm();
                            form.CommitVersionChanges = this.CommitVersionChanges;
                            form.ItemID = _itemCode;
                            form.ItemName = _itemName;
                            form.Lotn = _vendorLot;
                            form.TotalCount = this.IsPlatzkart ? _factQty : (int)((Data.PickControl.DocRowsRow)((DataRowView)gvLines.Rows[0].DataBoundItem).Row).Doc_Qty -_count;
                            form.Count = _count; // this.NeedReWeightEveryItem ? 0 : _count;
                            form.InputCountEnabled = true;
                            form.NTVCount = 0;
                            //form.EditOnlyNTVCount = this.NeedReWeightEveryItem;
                            form.IsPlatzkart = this.IsPlatzkart;
                            form.Box = _box;
                            form.MaxCount = _maxQty;

                            if (this.IsPlatzkart)
                                form.FactCount = _factQty;

                            if (form.ShowDialog() == DialogResult.OK)
                            {
                                int cnt = _lastCountValue = form.Count;
                                //if (cnt != _count)
                                {
                                    _count = cnt - _count;
                                    _ntvFlag = form.NTVCount > 0 ? true : (bool?)null;
                                    _ntvQuantity = form.NTVCount > 0 ? form.NTVCount : (double?)null;

                                    if (this.AddRow())
                                    {
                                        if (form.NTVCount > 0)
                                        {
                                            #region ФИКСАЦИЯ НТВ

                                            var initNTVByDefault = true;
                                            var needShowMessage = true;
                                            while (needShowMessage)
                                            {
                                                if (initNTVByDefault || MessageBox.Show("Вы желаете зафиксировать НТВ?", "Контроль НТВ", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                                                {
                                                    initNTVByDefault = false;

                                                    // 1. скан бейджа
                                                    var needScanBoss = true;
                                                    var abortScanBoss = false;
                                                    while (needScanBoss)
                                                    {
                                                        try
                                                        {
                                                            var bossID = (int?)null;
                                                            var dlgBossScanner = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                                                            {
                                                                Label = "Отсканируйте бэйдж руководителя,\r\nкоторый отвечает за мониторинг контроля",
                                                                Text = "Фиксация НТВ",
                                                                Image = Properties.Resources.role,
                                                                //OnlyNumbersInBarcode = true
                                                                UseScanModeOnly = true
                                                            };

                                                            if (dlgBossScanner.ShowDialog() != DialogResult.OK)
                                                            {
                                                                abortScanBoss = true;
                                                                break;
                                                            }

                                                            bossID = Convert.ToInt32(dlgBossScanner.Barcode);

                                                            var result = (int?)null;
                                                            using (var adapter = new Data.PickControlTableAdapters.SurplusContainerDocsTableAdapter())
                                                                adapter.CheckBoss(this.UserID, this.DocID, bossID, ref result);

                                                            if (result.HasValue && Convert.ToBoolean(result.Value))
                                                                needScanBoss = false;
                                                            else
                                                                throw new Exception("Пользователь не имеет права\r\nподтверждения фиксации НТВ.");
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            this.ShowError(ex);
                                                        }
                                                    }

                                                    if (abortScanBoss)
                                                        continue;

                                                    // 2. проверка серии на единственность / выбор серии
                                                    var requiredVendorLot = (string)null;
                                                    var needSelectVendorLot = (int?)null;
                                                    using (var adapter = new Data.PickControlTableAdapters.NTVContainerDocsTableAdapter())
                                                        adapter.CheckVendorLotIsDefined(this.DocID, _itemCode, ref requiredVendorLot, ref needSelectVendorLot);

                                                    // 2.1 выбор серии 
                                                    if ((needSelectVendorLot ?? 0) == 1)
                                                    {
                                                        var vendorLots = new Data.PickControl.VendorLotForNTVDataTable();
                                                        using (var adapter = new Data.PickControlTableAdapters.VendorLotForNTVTableAdapter())
                                                            adapter.Fill(vendorLots, this.DocID, _itemCode);

                                                        var dlgSelectVendorLot = new WMSOffice.Dialogs.RichListForm();
                                                        dlgSelectVendorLot.Text = "Выберите серию для НТВ";
                                                        dlgSelectVendorLot.AddColumn("Vendor_Lot", "Vendor_Lot", "Серия");
                                                        dlgSelectVendorLot.ColumnForFilters = new List<string>(new string[] { "Vendor_Lot" });
                                                        dlgSelectVendorLot.FilterChangeLevel = 0;
                                                        dlgSelectVendorLot.DiscardCanceling = true;
                                                        dlgSelectVendorLot.DataSource = vendorLots;

                                                        if (dlgSelectVendorLot.ShowDialog() == DialogResult.OK)
                                                            requiredVendorLot = (dlgSelectVendorLot.SelectedRow as Data.PickControl.VendorLotForNTVRow).Vendor_Lot;
                                                        else
                                                            continue;
                                                    }

                                                    // 3. фиксация НТВ
                                                    try
                                                    {
                                                        using (var adapter = new Data.PickControlTableAdapters.NTVContainerDocsTableAdapter())
                                                            adapter.RegisterNTV(this.DocID, _itemCode, requiredVendorLot, form.NTVCount, this.UserID, Environment.UserName, (long?)null);
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        this.ShowError(ex);
                                                        initNTVByDefault = true;
                                                        continue;
                                                    }

                                                    needShowMessage = false;
                                                }
                                                else
                                                    needShowMessage = false;
                                            }

                                            #endregion

                                            #region ЗАКЛАДКА В КОНТЕЙНЕР НТВ (НЕ ИСПОЛЬЗУЕТСЯ)

                                            //var initNTVByDefault = true;
                                            //var needShowMessage = true;
                                            //while (needShowMessage)
                                            //{
                                            //    if (initNTVByDefault || MessageBox.Show("Вы желаете зафиксировать НТВ?", "Контроль НТВ", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                                            //    {
                                            //        initNTVByDefault = false;
                                            //        var needScanContainer = true;

                                            //        var needShowContainer = true;
                                            //        while (needShowContainer)
                                            //        {
                                            //            try
                                            //            {
                                            //                if (ntvContainerDoc.IsOpened)
                                            //                {
                                            //                    if (ntvContainerDoc.Init(new NTVContainerDocInitParameters() { ItemID = _itemCode, VendorLot = _vendorLot, UnitOfMeasure = _itemUOM, Quantity = form.NTVCount, NeedScanContainer = needScanContainer }))
                                            //                    {
                                            //                        RefreshLines();
                                            //                        tbBarcode.Focus();

                                            //                        needShowContainer = false;
                                            //                        needShowMessage = false;
                                            //                    }
                                            //                    else
                                            //                    {
                                            //                        needShowContainer = false;
                                            //                    }
                                            //                }
                                            //                else
                                            //                {
                                            //                    if (ntvContainerDoc.Open())
                                            //                    {
                                            //                        needShowContainer = true;
                                            //                        needScanContainer = false;
                                            //                    }
                                            //                    else
                                            //                        needShowContainer = false;
                                            //                }
                                            //            }
                                            //            catch (Exception exc)
                                            //            {
                                            //                this.ShowError(exc);
                                            //            }
                                            //        }
                                            //    }
                                            //    else
                                            //        needShowMessage = false;
                                            //}

                                            #endregion
                                        }
                                    }
                                }
                            }

                            #endregion
                        }
                        else
                        {
                            if (this.NeedReWeightEveryItem)
                                return;

                            #region ВВОД КОЛИЧЕСТВА В ОБЫЧНОЙ ВЕРСИИ

                            SetCountForm form = new SetCountForm();
                            form.ItemID = _itemCode;
                            form.ItemName = _itemName;
                            form.Lotn = _vendorLot;
                            form.TotalCount = (int)((Data.PickControl.DocRowsRow)((DataRowView)gvLines.Rows[0].DataBoundItem).Row).Doc_Qty - _count;
                            form.Count = _count;
                            form.InputCountEnabled = true; // (!_isRepeatControl) || (_scanType == "M"); // РАЗРЕШАЕМ ввод количества для товара, выбранного вручную (снова), или для первого контроля

                            if (this.CommitVersionChanges)
                            {
                                form.MinCount = IsRepeatControl ? (int?)null : 1;
                                form.ShowNote = false;
                            }

                            form.CommitVersionChanges = this.CommitVersionChanges;

                            if (form.ShowDialog() == DialogResult.OK)
                            {
                                if (this.IsPlatzkart && !this.IsRepeatControl)
                                {
                                    _count = -1 * _count;
                                    AddRow(false);
                                    _count = -1 * _count;
                                }

                                int cnt = _lastCountValue = form.Count;
                                if (cnt != _count)
                                {
                                    if (this.CommitVersionChanges)
                                    {
                                        if (!IsRepeatControl)
                                        {
                                            cnt = cnt > form.MinCount.Value ? cnt : form.MinCount.Value;
                                        }
                                    }

                                    _count = this.IsPlatzkart && !this.IsRepeatControl ? cnt : cnt - _count;
                                    AddRow();
                                }
                                _count = cnt;
                            }

                            #endregion
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowError(ex);
                    }
                }
            }
            else
            {
                #region ДОБАВЛЕНИЕ ЗАПИСИ В ДОКУМЕНТ КОНТРОЛЯ ПРИ ОБРАБОТКЕ Ш/К

                _lastCountValue = 1;

                using (Data.PickControlTableAdapters.ItemsTableAdapter adapter = new WMSOffice.Data.PickControlTableAdapters.ItemsTableAdapter())
                {
                    try
                    {
                        var success = false; // признак добавления позиции в документ контроля

                        var notRecalcUOMFlag = this.CommitVersionChanges ? 1 : (int?)null;
                        var ignoreSurplusChecks = this.IsProcessVersionEquals_2 ? 1 : (int?)null;
                        Data.PickControl.ItemsDataTable table = adapter.GetData(DocID, UserID, tbBarcode.Text, notRecalcUOMFlag, ignoreSurplusChecks, this.ProcessVersionID);
                        if (table == null || table.Count < 1)
                            throw new Exception("Товар не найден! Воспользуйтесь поиском (Ctrl+F) для добавления товара без штрих кода.");
                        else if (table.Count == 1)
                        {
                            // только один товар нашли! можем переходить к выбору серии
                            Data.PickControl.ItemsRow itemsRow = table[0];
                            _itemCode = (int)itemsRow.Item_ID;
                            _itemName = itemsRow.Item;
                            _itemUOM = itemsRow.UnitOfMeasure;
                            _count = (int)itemsRow.Qty;
                            _scanType = "B";

                            if (!itemsRow.IsVendor_LotNull() && !String.IsNullOrEmpty(itemsRow.Vendor_Lot))
                            {
                                // отсканировали уникальный штрих код ящика! Знаем даже серию!
                                _vendorLot = itemsRow.Vendor_Lot;
                                success = AddRow();
                            }
                            else
                            {
                                // отсканировали простой товар, идентифицировали, выбираем серию
                                success = ChooseSeries();
                            }
                        }
                        else
                        {
                            // нашли несколько товаров, нужно выбрать наш
                            success = ChooseItems(table);
                        }

                        #region ОТОБРАЖЕНИЕ ДОП. СООБЩЕНИЯ ПОСЛЕ СКАНИРОВАНИЯ И ЗАКЛАДКИ ПОЗИЦИИ

                        if (success && !this.NeedControlInternetOrder)
                        {
                            try
                            {
                                var message = (string)null;
                                docRowsTableAdapter.VerifyUOM(this.UserID, this.DocID, _itemCode, ref message);

                                if (!string.IsNullOrEmpty(message))
                                {
                                    var messageForm = new FullScreenErrorForm(message, "ПРОДОЛЖИТЬ (Пробел)", Color.Yellow);
                                    messageForm.TimeOut = 2000;
                                    messageForm.AutoClose = false;
                                    messageForm.CloseKey = Keys.Space;
                                    messageForm.ShowDialog();
                                }
                            }
                            catch
                            {

                            }
                        }

                        #endregion

                        // Весовой контроль наступает после добавления позиции в документ контроля
                        if (this.IsProcessVersionEquals_4 && success && !this.IsRepeatControl)
                        {
                            this.ExecuteItemWeightControl();
                        }

                        // Взвешивание единицы товара наступает после добавления позиции в документ контроля
                        if (this.NeedReWeightEveryItem && success && !isNTVRegisterModeEnabled)
                        {
                            this.ObtainItemWeight();
                        }

                        // Сбрасываем режим регистрации НТВ
                        if (isNTVRegisterModeEnabled)
                            btnEnableNTVRegisterMode_Click(this, EventArgs.Empty);
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("#CANCELMINICONTROL#") && this.NeedControlInternetOrder)
                        {
                            var regex = new System.Text.RegularExpressions.Regex(@"^#CANCELMINICONTROL#(?<oid>.+)#", System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Singleline);
                            if (regex.IsMatch(ex.Message))
                            {
                                var orderID = Convert.ToInt32(regex.Match(ex.Message).Groups["oid"].Value);

                                if (MessageBox.Show(string.Format("Вы уверены что хотите провести повторный мини-контроль заказа № {0}?", orderID), "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                                {
                                    var dlgOrderMiniControl = new OrderMiniControlForm(true) { UserID = this.UserID, DocID = this.DocID, OrderID = orderID, ProcessVersionID = this.ProcessVersionID, CommitVersionChanges = this.CommitVersionChanges };
                                    if (dlgOrderMiniControl.ShowDialog() != DialogResult.OK)
                                    {
                                        RefreshLines();
                                        tbBarcode.Focus();
                                    }
                                }
                            }
                        }
                        else if (ex.Message.Contains("REDFORM"))
                        {
                            FullScreenErrorForm errorForm = new FullScreenErrorForm(
                                String.Format("Товар {0}\n\rНЕ содержится\n\rв сборочном листе.\n\rОтложите товар в прозрачный ящик!\n\r(ведется видеонаблюдение)", ex.Message.Replace("REDFORM", "")),
                                "Товар возвращен в отдел.\n\rПРОДОЛЖИТЬ (Enter)", Color.Red);
                            errorForm.TimeOut = 2000;
                            errorForm.ShowDialog();
                            UndoEnabled = false;
                        }
                        else
                            ShowError(ex);
                    }
                    finally
                    {
                        try
                        {
                            if (isBarCodeAcquiringFromTerminalEnabled)
                            {
                                using (var adapterTask = new Data.PickControlTableAdapters.PickControlDocBarCodeEmulationTableAdapter())
                                    adapterTask.CompleteBarCodeEmulationTask(this.DocID, tbBarcode.Text);

                                tbBarcode.ScannerListener.Start();
                            }
                        }
                        catch (Exception ex)
                        {
                            this.ShowError(ex);
                        }
                    }
                }

                #endregion
            }

            tbBarcode.Text = "";
        }

        /// <summary>
        /// Проведение весового контроля для позиции документа контроля
        /// </summary>
        private void ExecuteItemWeightControl()
        {
            // 1. Необходимость взвесить позицию документа контроля
            var needWeightControl = (bool?)null;
            using (var adapter = new Data.PickControlTableAdapters.QueriesTableAdapter())
                adapter.PickControlItemCanGetWeight(this.UserID, this.DocID, _itemCode, _vendorLot, _itemUOM, ref needWeightControl);

            if (needWeightControl.HasValue && needWeightControl.Value == true)
            {
                // 2. Взвешивание позиции документа контроля и проверка веса на правильность
                var continueWeighing = true;
                while (continueWeighing)
                {
                    try
                    {
                        var weightProvider = new ObtainWeightProvider() { AbortTimeout = 10000 };
                        weightProvider.OnComplete += delegate(object sender, EventArgs e)
                        {
                            try
                            {
                                if (weightProvider.WeightObtained)
                                {
                                    var sCurrentWeight = weightProvider.Value;
                                    double currentWeight;

                                    if (!double.TryParse(sCurrentWeight, out currentWeight))
                                        throw new Exception("Вес ящика задан некорректно.");

                                    var factWeight = currentWeight;
                                    var succeededWeightControl = (bool?)null;
                                    // проверка веса на правильность
                                    using (var adapter = new Data.PickControlTableAdapters.QueriesTableAdapter())                                        
                                        adapter.PickControlItemCheckWeight(this.UserID, _itemCode, _itemUOM, factWeight, ref succeededWeightControl);

                                    if (succeededWeightControl.HasValue && succeededWeightControl.Value == true)
                                    {
                                        // 3. Сохранение веса позиции документа контроля
                                        using (var adapter = new Data.PickControlTableAdapters.QueriesTableAdapter())
                                            adapter.PickControlItemSaveWeight(this.UserID, this.DocID, _itemCode, _vendorLot, _itemUOM, factWeight);

                                        var messageForm = new FullScreenErrorForm("Вес сошелся", "Окно закроется автоматически.\r\n(пожалуйста, подождите...)", Color.Green);
                                        messageForm.TimeOut = 1000;
                                        messageForm.AutoClose = true;
                                        messageForm.ShowDialog();

                                        continueWeighing = false;
                                    }
                                    else 
                                    {
                                        var messageForm = new FullScreenErrorForm("Вес разошелся", "Окно закроется автоматически.\r\n(пожалуйста, подождите...)", Color.Green);
                                        messageForm.TimeOut = 1000;
                                        messageForm.AutoClose = true;
                                        messageForm.ShowDialog();

                                        if (MessageBox.Show("Полученный вес отличается от справочного.\r\nВы желаете провести повторное взвешивание?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                                            continueWeighing = false;
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
                                var messageForm = new FullScreenErrorForm(ex.Message, "Окно закроется автоматически.\r\n(пожалуйста, подождите...)", Color.Red);
                                messageForm.TimeOut = 1000;
                                messageForm.AutoClose = true;
                                messageForm.ShowDialog();
                            }
                        };

                        // Запускаем фоновый поток
                        weightProvider.Run();
                    }
                    catch (Exception ex)
                    {
                        var messageForm = new FullScreenErrorForm(ex.Message, "Окно закроется автоматически.\r\n(пожалуйста, подождите...)", Color.Red);
                        messageForm.TimeOut = 1000;
                        messageForm.AutoClose = true;
                        messageForm.ShowDialog();
                    }
                }
            }
        }

        /// <summary>
        /// Взвешивание единицы товара
        /// </summary>
        private void ObtainItemWeight()
        {
            FullScreenErrorForm messageForm = null;

            var continueWeighing = true;
            while (continueWeighing)
            {
                try
                {
                    messageForm = new FullScreenErrorForm(string.Format("Положите на весы упаковку товара\n({0}){1}", _itemCode, _itemName), "Взвешивание начнется автоматически.\r\n(пожалуйста, подождите...)", Color.Yellow);
                    messageForm.TimeOut = 1000;
                    messageForm.AutoClose = true;
                    messageForm.ShowDialog();

                    var weightProvider = new ObtainWeightProvider() { AbortTimeout = 10000, WeightTypeID = (int)Optima.Devices.Data.DigitalWeigher.DataManager.DWType.Lab, MinRatio = 0.5M };
                    weightProvider.OnComplete += delegate(object sender, EventArgs e)
                    {
                        try
                        {
                            if (weightProvider.WeightObtained)
                            {
                                var sCurrentWeight = weightProvider.Value;
                                double currentWeight;

                                if (!double.TryParse(sCurrentWeight, out currentWeight))
                                    throw new Exception("Вес упаковки задан некорректно.");

                                using (var adapter = new Data.PickControlTableAdapters.QueriesTableAdapter())
                                    adapter.SaveItemWeight(this.DocID, _itemCode, currentWeight);

                                messageForm = new FullScreenErrorForm(string.Format("Получен вес упаковки товара\n({0}){1}\n\n{2:f3}", _itemCode, _itemName, currentWeight), "Окно закроется автоматически.\r\n(пожалуйста, подождите...)", Color.Green);
                                messageForm.TimeOut = 1000;
                                messageForm.AutoClose = true;
                                messageForm.ShowDialog();

                                continueWeighing = false;
                            }
                            else
                            {
                                if (weightProvider.Error != null)
                                    throw new Exception(weightProvider.Error.Message);
                            }
                        }
                        catch (Exception ex)
                        {
                            messageForm = new FullScreenErrorForm(ex.Message, "Нажмите Enter чтобы повторить взвешивание", Color.Red);
                            messageForm.TimeOut = 500;
                            messageForm.AutoClose = false;
                            messageForm.ShowDialog();
                        }
                    };

                    // Запускаем фоновый поток
                    weightProvider.Run();
                }
                catch (Exception ex)
                {
                    messageForm = new FullScreenErrorForm(ex.Message, "Нажмите Enter чтобы повторить взвешивание", Color.Red);
                    messageForm.TimeOut = 500;
                    messageForm.AutoClose = false;
                    messageForm.ShowDialog();
                }
            }
        }

        // текущее значение товара
        int _itemCode = 0;
        string _itemName = "";
        string _itemUOM = "";
        int _count = 0;
        string _vendorLot = "";
        string _scanType = "X";
        bool? _ntvFlag = (bool?)null;
        double? _ntvQuantity = (double?)null;
        string _box = "";
        int _maxQty = 0;
        int _factQty = 0;

        /// <summary>
        /// Метод выбора товара (если количество позиций с одним штрих кодом более 1)
        /// </summary>
        private bool ChooseItems(object dataTable)
        {
            var success = false;

            if (dataTable != null && dataTable is DataTable && ((DataTable)dataTable).Rows.Count > 1)
            {
                RichListForm formItm = new RichListForm();
                //if (formItm == null)
                //{

                #region column Bonus
                DataGridViewTextBoxColumn colBonus = new DataGridViewTextBoxColumn();
                colBonus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                colBonus.DataPropertyName = "bonus";
                colBonus.HeaderText = "Бонус";
                colBonus.Name = "colBonus";
                colBonus.ReadOnly = true;
                formItm.Columns.Add(colBonus);
                #endregion
                #region column Item
                DataGridViewTextBoxColumn colItem = new DataGridViewTextBoxColumn();
                colItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                colItem.DataPropertyName = "Item";
                colItem.HeaderText = "Наименование";
                colItem.Name = "colItem";
                colItem.ReadOnly = true;
                formItm.Columns.Add(colItem);
                #endregion
                #region column Manufacturer
                DataGridViewTextBoxColumn colManuf = new DataGridViewTextBoxColumn();
                colManuf.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                colManuf.DataPropertyName = "Manufacturer";
                colManuf.HeaderText = "Производитель";
                colManuf.Name = "colManuf";
                colManuf.ReadOnly = true;
                formItm.Columns.Add(colManuf);
                #endregion

                formItm.Text = "Выбор товара";
                Data.PickControl.ItemsDataTable table = new WMSOffice.Data.PickControl.ItemsDataTable();
                formItm.DataSource = table;
                formItm.ColumnForFilters.Add("Item");
                formItm.ColumnForFilters.Add("Manufacturer");
                formItm.FilterVisible = false;
                //formItems.FilterChanged += new EventHandler(formItems_FilterChanged);
                //}
                formItm.DataSource = dataTable;

                if (formItm.ShowDialog() == DialogResult.OK)
                {
                    if (formItm.SelectedRow != null)
                    {
                        Data.PickControl.ItemsRow row = (Data.PickControl.ItemsRow)formItm.SelectedRow;

                        _itemCode = (int)row.Item_ID;
                        _itemName = row.Item;
                        _itemUOM = row.UnitOfMeasure;

                        _count = (int)row.Qty;
                        _scanType = "B";

                        success = ChooseSeries();
                    }
                    else UndoEnabled = false;
                }
                else UndoEnabled = false;
            }

            return success;
        }

        /// <summary>
        /// Метод выбора серии (если серий больше 1)
        /// </summary>
        private bool ChooseSeries()
        {
            // получаем серии
            using (Data.PickControlTableAdapters.VendorLotsTableAdapter adapter = new WMSOffice.Data.PickControlTableAdapters.VendorLotsTableAdapter())
            {
                var success = false;

                try
                {
                    Data.PickControl.VendorLotsDataTable table = adapter.GetData(DocID, _itemCode, string.Empty, surplusMode, archiveMode, this.ProcessVersionID);

                    if (table == null || table.Count < 1)
                    {
                        throw new Exception("Серии не найдены! Это исключительная ситуация. Обратитесь в Группу сопровождения ПО.");
                    }
                    else if (table.Count == 1)
                    {
                        if (table[0].Vendor_Lot == "NOSER")
                        {
                            // контроль серий отключен
                            _vendorLot = table[0].Vendor_Lot;
                            success = AddRow();
                        }
                        else
                        {
                            // серию необходимо ввести руками
                            success = SetSeria();
                        }
                    }
                    //else if (table.Count == 2)
                    //{
                    //    // только одину серию, добавляем строку в документ
                    //    _vendorLot = table[0].Vendor_Lot;
                    //    AddRow();
                    //}
                    else
                    {
                        // есть несколько серий, предлагаем пользователю выбрать
                        success = ChooseSeries(table);
                    }
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("YELLOWFORM"))
                    {
                        FullScreenErrorForm errorForm = new FullScreenErrorForm(
                            String.Format("Товар {0}\n\rНЕ содержится в сборочном листе.\n\rТовар был выбран из списка.\n\rИсправьте свой выбор (если ошиблись),\n\rиначе\n\rОтложите товар в прозрачный ящик!", ex.Message.Replace("YELLOWFORM", "")),
                            "ПРОДОЛЖИТЬ (Enter)", Color.Yellow);
                        errorForm.ShowDialog();
                        UndoEnabled = false;
                    }
                    else
                        ShowError(ex);
                }

                return success;
            }
        }

        RichListForm formSeries = null;
        private bool ChooseSeries(DataTable dataTable)
        {
            var success = false;

            #region ПОДГОТОВКА СЕРИЙ К ОТОБРАЖЕНИЮ

            // удалим строки, которые не нужно отображать
            var lstRowsToRemove = new List<Data.PickControl.VendorLotsRow>();
            foreach (Data.PickControl.VendorLotsRow dr in dataTable.Rows)
                if (!dr.IsHideNull() && dr.Hide)
                    lstRowsToRemove.Add(dr);

            for (int i = 0; i < lstRowsToRemove.Count; i++)
                dataTable.Rows.Remove(lstRowsToRemove[i]);

            #endregion

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                if (formSeries == null)
                {
                    formSeries = new RichListForm() { Width = 600, DiscardCanceling = true, AllowSearchByEmptyFilter = true };
                    #region column Lotn
                    DataGridViewTextBoxColumn colLot = new DataGridViewTextBoxColumn();
                    colLot.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                    colLot.DataPropertyName = "Vendor_Lot";
                    colLot.HeaderText = "Серия";
                    colLot.Name = "colLot";
                    colLot.ReadOnly = true;
                    formSeries.Columns.Add(colLot);
                    #endregion
                    #region column Date
                    DataGridViewTextBoxColumn colDate = new DataGridViewTextBoxColumn();
                    colDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                    colDate.DataPropertyName = "Exp_Date";
                    colDate.HeaderText = "Срок годн.";
                    colDate.Name = "colDate";
                    colDate.ReadOnly = true;
                    formSeries.Columns.Add(colDate);
                    #endregion
                    #region column Collectors_remains
                    DataGridViewTextBoxColumn colCollectorsRemains = new DataGridViewTextBoxColumn();
                    colCollectorsRemains.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                    colCollectorsRemains.DataPropertyName = "Collectors_remains";
                    colCollectorsRemains.HeaderText = "Остаток, уп.";
                    colCollectorsRemains.Name = "colCollectorsRemains";
                    colCollectorsRemains.ReadOnly = true;
                    formSeries.Columns.Add(colCollectorsRemains);
                    #endregion

                    //formSeries.FilterVisible = false;
                    formSeries.ColumnForFilters.Add("Vendor_Lot");
                    formSeries.FilterChangeLevel = 2;

                    if (!this.CommitVersionChanges)
                        formSeries.FilterChanged += new EventHandler(formSeries_FilterChanged);
                }
                formSeries.Text = "Выбор серии " + _itemName;
                //ListChoiceForm form = new ListChoiceForm(dataTable, "Vendor_Lot", "Vendor_Lot");
                //form.Text = "Выбор серии " + _itemName;
                //form.RememberChoiceVisible = false;
                formSeries.DataSource = dataTable;

                if (formSeries.ShowDialog() == DialogResult.OK)
                {
                    if (formSeries.SelectedRow != null)
                    {
                        Data.PickControl.VendorLotsRow row = (Data.PickControl.VendorLotsRow)formSeries.SelectedRow;
                        if (row.Vendor_Lot == "Ввести серию вручную...")
                        {
                            success = SetSeria();
                        }
                        else
                        {
                            _vendorLot = row.Vendor_Lot;
                            success = AddRow();
                        }
                    }
                    else
                    {
                        UndoEnabled = false;
                    }
                }
                else
                {
                    UndoEnabled = false;
                }
            }
            else
            {
                UndoEnabled = false;
            }

            return success;
        }

        private void formSeries_FilterChanged(object sender, EventArgs e)
        {
            using (Data.PickControlTableAdapters.VendorLotsTableAdapter adapter = new WMSOffice.Data.PickControlTableAdapters.VendorLotsTableAdapter())
            {
                try
                {
                    Data.PickControl.VendorLotsDataTable table = adapter.GetData(DocID, _itemCode, formSeries.Filter, surplusMode, archiveMode, this.ProcessVersionID);
                    formSeries.DataSource = table;
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
            }
        }

        private bool SetSeria()
        {
            var success = false;

            SetVendorLotnForm form = new SetVendorLotnForm() { UserID = this.UserID };
            form.Text = "Присвоение серии " + _itemName;
            if (form.ShowDialog() == DialogResult.OK)
            {
                _vendorLot = form.Lotn;
                success = AddRow();
            }
            else
            {
                UndoEnabled = false;
            }

            return success;
        }

        private int _lastCountValue;

        private bool AddRow()
        {
            return AddRow(true);
        }

        private bool AddRow(bool allowExceptionHandler)
        {
            try
            {
                UndoEnabled = false;

                if (this.NeedControlInternetOrder)
                {
                    using (var adapter = new Data.PickControlTableAdapters.PC_IO_OrdersTableAdapter())
                        adapter.FillByItem(pickControl.PC_IO_Orders, this.DocID, _itemCode, _vendorLot);

                    Data.PickControl.PC_IO_OrdersRow order = null;

                    if (pickControl.PC_IO_Orders.Count == 1)
                        order = pickControl.PC_IO_Orders[0];
                    else
                    {
                        var dlgSelectOrder = new WMSOffice.Dialogs.RichListForm();
                        dlgSelectOrder.Text = "Выберите заказ для мини-контроля";
                        dlgSelectOrder.AddColumn("Order_ID", "Order_ID", "№");
                        dlgSelectOrder.AddColumn("Order_Description", "Order_Description", "Описание заказа");
                        dlgSelectOrder.FilterVisible = false;
                        dlgSelectOrder.DataSource = pickControl.PC_IO_Orders;

                        if (dlgSelectOrder.ShowDialog() == DialogResult.OK)
                            order = dlgSelectOrder.SelectedRow as Data.PickControl.PC_IO_OrdersRow;
                    }

                    if (order != null)
                    {
                        var dlgOrderMiniControl = new OrderMiniControlForm(_itemCode, _vendorLot, _itemUOM, _scanType, _itemName) { UserID = this.UserID, DocID = this.DocID, OrderID = order.Order_ID, ProcessVersionID = this.ProcessVersionID, CommitVersionChanges = this.CommitVersionChanges };
                        if (dlgOrderMiniControl.ShowDialog() != DialogResult.OK)
                        {
                            RefreshLines();
                            tbBarcode.Focus();

                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Вы отменили контроль текущей позиции!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
                else
                {
                    var mdsMessage = (string)null; // уведомление о завершении комплектности позиции в мультидробном сборочном (МДС)
                    docRowsTableAdapter.Insert(DocID, _itemCode, _vendorLot, _itemUOM, _count, _scanType, _ntvFlag, _ntvQuantity, this.ProcessVersionID, ref mdsMessage);

                    quizManager.TryQuiz("item_id", _itemCode.ToString()); // попытка создать опрос для данного товара

                    #region КОНТРОЛЬ МДС ПО ПОЗИЦИИ ЗАВЕРШЕН
                    if (this.IsMDP && !string.IsNullOrEmpty(mdsMessage))
                    {
                        var htmlRenderMode = mdsMessage.Contains("<div");
                        var msgForm = new WMSOffice.Dialogs.PickControl.FullScreenErrorForm(mdsMessage, "ПРОДОЛЖИТЬ (Enter)", System.Drawing.Color.LightBlue, htmlRenderMode);
                        msgForm.TimeOut = 2000;
                        msgForm.AutoClose = false;
                        msgForm.ShowDialog();

                        // Проверка БЭ
                        PickControlWindow.CheckPrintedEtics(UserID, DocID, CommitVersionChanges, this.IsPlatzkart);

                        // Контроль упаковки
                        PickControlWindow.CheckMDSTare(DocID, _itemCode);
                    }
                    #endregion
                }

                if (!this.NeedControlInternetOrder)
                    UndoEnabled = true;

                RefreshLines();
                tbBarcode.Focus();

                return true;
            }
            catch (Exception ex)
            {
                if (!allowExceptionHandler)
                    return true;

                // красный экран
                if (ex.Message.Contains("#OVERQUANTITY"))
                {
                    var message = ex.Message.Replace("#OVERQUANTITY", string.Empty).Replace("_SKIP", string.Empty);

                    var body = ex.Message.Contains("#OVERQUANTITY_SKIP") ? "OVERQUANTITY_SKIP" : "OVERQUANTITY";

                    var regex = new System.Text.RegularExpressions.Regex(string.Format(@"^#{0}#(?<Message>.+)#", body), System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Singleline);
                    if (regex.IsMatch(ex.Message))
                        message = regex.Match(ex.Message).Groups["Message"].Value;

                    var errorForm = new WMSOffice.Dialogs.PickControl.FullScreenErrorForm(message, "ПРОДОЛЖИТЬ (Enter)", System.Drawing.Color.Red);
                    errorForm.TimeOut = 1000;
                    //errorForm.AutoClose = true;
                    errorForm.ShowDialog();

                    #region РАБОТА С КОНТЕЙНЕРОМ ИЗЛИШКОВ

                    if (this.IsProcessVersionEquals_2 && surplusContainerDoc != null && this.IsRepeatControl)
                    {
                        var initSurplusByDefault = true;
                        var needShowMessage = true;
                        while (needShowMessage)
                        {
                            if (initSurplusByDefault || MessageBox.Show("Вы желаете зафиксировать излишек?", "Контроль излишка", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                            {
                                initSurplusByDefault = false;
                                var needShowContainer = true;
                                while (needShowContainer)
                                {
                                    try
                                    {
                                        if (surplusContainerDoc.IsOpened)
                                        {
                                            var expectedQuantity = _lastCountValue; //this.FindExpectedQuantity();
                                            var expectedSurplusQuantity = 0;

                                            var regexQuantity = new System.Text.RegularExpressions.Regex(@"^.*«(?<Quantity>\d+) .*»", System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Singleline);
                                            if (regexQuantity.IsMatch(message))
                                                expectedSurplusQuantity = Convert.ToInt32(regexQuantity.Match(message).Groups["Quantity"].Value);

                                            //expectedQuantity += expectedSurplusQuantity;

                                            surplusContainerDoc.Init(new SurplusContainerDocInitParameters() { ItemID = _itemCode, UnitOfMeasure = _itemUOM, Quantity = 0, ExpectedQuantity = expectedQuantity, ExpectedVendorLot = _vendorLot, ExpectedSurplusQuantity = expectedSurplusQuantity });
                                            needShowContainer = false;
                                            needShowMessage = false;
                                        }
                                        else
                                        {
                                            if (surplusContainerDoc.Open())
                                                needShowContainer = true;
                                            else
                                                needShowContainer = false;
                                        }
                                    }
                                    catch (Exception exc)
                                    {
                                        this.ShowError(exc);
                                    }
                                }
                            }
                            else
                            {
                                #region ПОДТВЕРЖДЕНИЕ ОТМЕНЫ РЕГИСТРАЦИИ ИЗЛИШКА РУКОВОДИТЕЛЕМ

                                while (true)
                                {
                                    try
                                    {
                                        var dlgBossScanner = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                                        {
                                            Label = "Отсканируйте бэйдж руководителя,\r\nкоторый отвечает за мониторинг контроля",
                                            Text = "Отмена регистрации излишка",
                                            Image = Properties.Resources.role,
                                            //OnlyNumbersInBarcode = true
                                            UseScanModeOnly = true
                                        };

                                        if (dlgBossScanner.ShowDialog() != DialogResult.OK)
                                            break;

                                        var bossID = Convert.ToInt32(dlgBossScanner.Barcode);

                                        var checkBossResult = (int?)null;
                                        using (var adapter = new Data.PickControlTableAdapters.SurplusContainerDocsTableAdapter())
                                            adapter.CheckBoss(this.UserID, this.DocID, bossID, ref checkBossResult);

                                        if (!checkBossResult.HasValue || checkBossResult.Value != 1)
                                            throw new Exception("У Вас отсутствуют полномочия выполнять отмену регистрации излишка.");

                                        needShowMessage = false;
                                        break;
                                    }
                                    catch (Exception exc)
                                    {
                                        this.ShowError(exc);
                                    }
                                }

                                #endregion
                            }
                        }
                    }

                    #endregion

                    RefreshLines();
                    tbBarcode.Focus();

                    if (ex.Message.Contains("#OVERQUANTITY_SKIP"))
                    {
                        UndoEnabled = true;
                        return true;
                    }
                }
                else
                    if (ex.Message.Contains("#PLATZKART_V2"))
                    {
                        platzkartBoxes.Clear();

                        var regex = new System.Text.RegularExpressions.Regex(@"^#PLATZKART_V2#(?<xml>.+)#$", System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Singleline);
                        if (regex.IsMatch(ex.Message))
                        {
                            var match = regex.Match(ex.Message);
                            var xml = match.Groups["xml"].Value;

                            if (this.IsRepeatControl)
                            {
                                UndoEnabled = true;

                                RefreshLines();
                                tbBarcode.Focus();

                                return true;
                            }

                            try
                            {
                                var xDoc = new System.Xml.XmlDocument();

                                using (var sr = new System.IO.StringReader(xml))
                                    xDoc.Load(sr);

                                var xDocRoot = xDoc.DocumentElement;

                                foreach (System.Xml.XmlNode node in xDocRoot.SelectNodes("//Boxes//Box"))
                                {
                                    var pb = new WMSOffice.Dialogs.PickControl.PlatzkartPickDirectionForm.PlatzkartBox();

                                    foreach (var pi in pb.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public))
                                    {
                                        var attr = node.Attributes[pi.Name];
                                        if (attr != null)
                                            pi.SetValue(pb, Convert.ChangeType(attr.Value, pi.PropertyType), pi.GetIndexParameters());
                                    }

                                    platzkartBoxes.Add(pb);
                                }
                            }
                            catch (Exception)
                            {

                            }
                            finally
                            {
                                foreach (var box in platzkartBoxes)
                                {
                                    var marker = WMSOffice.Dialogs.PickControl.PlatzkartPickDirectionForm.Create(box.PlatzkartBoxDirection, box.Value, this, 30, this.IsRepeatControl ? 30 : 50);
                                    box.ChangeMarker(marker);
                                }

                                UndoEnabled = true;

                                RefreshLines();
                                tbBarcode.Focus();
                            }
                        }
                    }
                    else if (ex.Message.Contains("#PLATZKART"))
                    {
                        var regex = new System.Text.RegularExpressions.Regex(@"^#PLATZKART#(?<box>.+)#(?<qty>\d+)#(?<fqty>\d+)#", System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Singleline);
                        if (regex.IsMatch(ex.Message))
                        {
                            var match = regex.Match(ex.Message);

                            var box = _box = match.Groups["box"].Value;
                            var qty = _maxQty = Convert.ToInt32(match.Groups["qty"].Value);
                            var fqty = _factQty = Convert.ToInt32(match.Groups["fqty"].Value);

                            if (this.IsRepeatControl)
                            {
                                UndoEnabled = true;

                                RefreshLines();
                                tbBarcode.Focus();

                                return true;
                            }

                            var form = new SetPlatzkartCountForm();
                            form.ItemID = _itemCode;
                            form.ItemName = _itemName;
                            form.Lotn = _vendorLot;
                            form.Box = box;

                            form.Count = 1;
                            form.MaxCount = qty;
                            form.FactCount = fqty;

                            form.InputCountEnabled = true;
                            form.CommitVersionChanges = this.CommitVersionChanges;
                            form.DiscardCanceling = true;

                            if (form.ShowDialog() == DialogResult.OK)
                            {
                                var cnt = form.Count - 1;

                                var result = false;

                                try
                                {
                                    if (cnt > 0)
                                    {
                                        _count = cnt;
                                        result = AddRow(false);
                                    }
                                }
                                finally
                                {
                                    UndoEnabled = true;

                                    RefreshLines();
                                    tbBarcode.Focus();
                                }

                                return result;
                            }
                        }
                    }
                    else
                        if (ex.Message.StartsWith("#"))
                        {
                            var message = ex.Message.Replace("#", string.Empty);

                            var regex = new System.Text.RegularExpressions.Regex(@"^#(?<Message>.+)#", System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Singleline);
                            if (regex.IsMatch(ex.Message))
                                message = regex.Match(ex.Message).Groups["Message"].Value;

                            var errorForm = new WMSOffice.Dialogs.PickControl.FullScreenErrorForm(message, "ПРОДОЛЖИТЬ (Enter)", System.Drawing.Color.Red);
                            errorForm.TimeOut = 1000;
                            //errorForm.AutoClose = true;
                            errorForm.ShowDialog();
                        }
                        else
                            ShowError(ex);

                return false;
            }
        }

        /// <summary>
        /// Поиск ожидаемого количества по последней сканируемой позиции
        /// </summary>
        /// <returns></returns>
        private int FindExpectedQuantity()
        {
            foreach (DataGridViewRow row in gvLines.Rows)
            {
                Data.PickControl.DocRowsRow boundRow = (Data.PickControl.DocRowsRow)((DataRowView)row.DataBoundItem).Row;
                if (!boundRow.IsItem_IDNull() && boundRow.Item_ID == _itemCode && 
                    !boundRow.IsVendor_LotNull() && boundRow.Vendor_Lot == _vendorLot && 
                    !boundRow.IsUnitOfMeasureNull() && boundRow.UnitOfMeasure == _itemUOM)
                    return boundRow.IsQty_NeedNull() ? 0 : Convert.ToInt32(boundRow.Qty_Need);
            }

            return 0;
        }

        private bool UndoEnabled
        {
            get { return btnUndo.Enabled; }
            set { btnUndo.Enabled = miUndo.Enabled = value; }
        }

        RichListForm formItems = null;
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (formItems == null)
                {
                    formItems = new RichListForm();
                    #region column Item
                    DataGridViewTextBoxColumn colItem = new DataGridViewTextBoxColumn();
                    colItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                    colItem.DataPropertyName = "Item";
                    colItem.HeaderText = "Наименование";
                    colItem.Name = "colItem";
                    colItem.ReadOnly = true;
                    formItems.Columns.Add(colItem);
                    #endregion
                    #region column Manufacturer
                    DataGridViewTextBoxColumn colManuf = new DataGridViewTextBoxColumn();
                    colManuf.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                    colManuf.DataPropertyName = "Manufacturer";
                    colManuf.HeaderText = "Производитель";
                    colManuf.Name = "colManuf";
                    colManuf.ReadOnly = true;
                    formItems.Columns.Add(colManuf);
                    #endregion

                    formItems.Text = "Выбор товара";
                    Data.PickControl.ItemsDataTable table = new WMSOffice.Data.PickControl.ItemsDataTable();
                    formItems.DataSource = table;
                    formItems.ColumnForFilters.Add("Item");
                    formItems.ColumnForFilters.Add("Manufacturer");
                    formItems.FilterChanged += new EventHandler(formItems_FilterChanged);
                }
                if (formItems.ShowDialog() == DialogResult.OK)
                {
                    _itemCode = (int)((Data.PickControl.ItemsRow)formItems.SelectedRow).Item_ID;
                    _itemName = ((Data.PickControl.ItemsRow)formItems.SelectedRow).Item;
                    _itemUOM = ((Data.PickControl.ItemsRow)formItems.SelectedRow).UnitOfMeasure;
                    _count = 1;
                    _scanType = "M"; // ручной выбор товара
                    // двигаемся дальше в сторону выбора серии
                    var success = ChooseSeries();

                    // Взвешивание единицы товара наступает после добавления позиции в документ контроля
                    if (this.NeedReWeightEveryItem && success && !isNTVRegisterModeEnabled)
                    {
                        this.ObtainItemWeight();
                    }

                    // Сбрасываем режим регистрации НТВ
                    if (isNTVRegisterModeEnabled)
                        btnEnableNTVRegisterMode_Click(this, EventArgs.Empty);
                }
                else
                {
                    UndoEnabled = false;
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        void formItems_FilterChanged(object sender, EventArgs e)
        {
            using (Data.PickControlTableAdapters.ItemsTableAdapter adapter = new WMSOffice.Data.PickControlTableAdapters.ItemsTableAdapter())
            {
                try
                {
                    Data.PickControl.ItemsDataTable table = adapter.GetDataAll(formItems.Filter);
                    formItems.DataSource = table;
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (UndoEnabled)
            {
                _count = _count * -1;
                AddRow();
                UndoEnabled = false;
            }
        }

        /// <summary>
        /// Выполнение алгоритма при завершении контроля 
        /// </summary>
        /// <param name="userID">Код сессии</param>
        /// <param name="docID">Номер документа контроля</param>
        /// <param name="appliedProcessVersion">Признак подходящей версии процесса</param>
        /// <param name="adaptTestVersionChanges">Признак интеграции изменений тестовой версии в рабочую</param>
        /// <param name="isPlatzkart">Признак контроля "плацкарт"</param>
        /// <param name="isMDP">Признак мультидроби</param>
        /// <param name="weightControlCompleted">Признак завершенного весового контроля</param>
        public static CloseDocActionType ExecuteCloseDocAction(int userID, string userLogin, long docID, int modeID, bool appliedProcessVersion, bool adaptTestVersionChanges, bool isPlatzkart, bool isMDP, bool weightControlCompleted)
        {
            var closeDocActionType = CloseDocActionType.Default;

            bool needExecuteAction = true;
            while (needExecuteAction)
            {
                try
                {
                    var actionType = (int?)null; // тип действия по закрытию

                    #region АНАЛИЗ ПРИЗНАКА ЗАКРЫТИЯ ДОКУМЕНТА КОНТРОЛЯ -> "ВОЛНА" ИЛИ "МУЛЬТИСБОРОЧНЫЙ А13" ЗАКРЫВАЕТСЯ АВТОМАТИЧЕСКИ БЕЗ ВЫБОРА ТАРЫ

                    using (var adapter = new Data.PickControlTableAdapters.QueriesTableAdapter())
                        adapter.CloseDocActionSmart(docID, ref actionType);

                    closeDocActionType = (CloseDocActionType)(actionType ?? (int)CloseDocActionType.Default);
                    if (closeDocActionType == CloseDocActionType.Default)
                        return closeDocActionType;

                    #endregion

                    var cancelRetTareFlag = 0; // признак отмены выбора оборотной тары
                    var cancelReason = (string)null; // причина отмены оборотной тары
                    var defaultTareBarCode = (string)null;

                    var boxType = (int?)null; // тип тары
                    var eticBarCode = (string)null; // ш/к тары
                    var needTareCapFlag = (int?)null; // необходимость привязки крышки к выбранной таре
                    //var actionType = (int?)null;

                    // Если параметры были получены ранее (этап 1) через сканирование
                    if (modeID == 2 && PickControlWindow.InnerBoxType.HasValue && !string.IsNullOrEmpty(PickControlWindow.InnerEticBarCode))
                    {
                        boxType = PickControlWindow.InnerBoxType;
                        eticBarCode = PickControlWindow.InnerEticBarCode;
                        needTareCapFlag = PickControlWindow.InnerNeedTareCapFlag;

                        if (PickControlWindow.InnerActionType != (int)CloseDocActionType.AbortDueToWeightControlDifference)
                            actionType = PickControlWindow.InnerActionType;
                    }
                    else
                    {
                        // 1.0 Для мультидроби ничего не требуется по завершению контрлоля
                        if (modeID == 2 && isMDP)
                        {
                            actionType = (int)CloseDocActionType.Default;
                        }
                        // 1.1 Выбор тары через сканирование
                        else if (PickControlWindow.SelectTareBarCode(userID, userLogin, docID, modeID, cancelRetTareFlag, cancelReason, defaultTareBarCode, weightControlCompleted, ref boxType, ref eticBarCode, ref needTareCapFlag, ref actionType))
                        {
                            // Параметры получены в методе
                        }
                        // 1.2 Выбор тары вручную (из справочника)
                        else
                        {
                            #region РУЧНОЙ ВЫБОР ТИПА ТАРЫ ДЛЯ УПАКОВКИ

                            boxType = (int?)null;

                            bool needCheckEticBarCode = false; // необходимость сканирования ш/к этикетки 

                            Data.PickControl.PickContainerTypesDataTable containerTypes = null;
                            using (var containerTypeAdapter = new Data.PickControlTableAdapters.PickContainerTypesTableAdapter())
                                containerTypes = containerTypeAdapter.GetData(userID, docID);

                            if (containerTypes != null && containerTypes.Rows.Count > 0)
                            {
                                var dlgSelectContainerType = new WMSOffice.Dialogs.RichListForm();
                                dlgSelectContainerType.Text = "Выберите тип тары для упаковки";
                                dlgSelectContainerType.AddColumn("Short_Value", "Short_Value", "Тип тары");
                                dlgSelectContainerType.ColumnForFilters = new List<string>(new string[] { "Short_Value" });
                                dlgSelectContainerType.FilterChangeLevel = 0;
                                dlgSelectContainerType.DataSource = containerTypes;
                                dlgSelectContainerType.DiscardCanceling = true;

                                if (dlgSelectContainerType.ShowDialog() == DialogResult.OK)
                                {
                                    var selectedItem = dlgSelectContainerType.SelectedRow as Data.PickControl.PickContainerTypesRow;
                                    boxType = Convert.ToInt32(selectedItem.Key);
                                    needCheckEticBarCode = selectedItem.IsNeedCheckBCNull() ? false : Convert.ToBoolean(selectedItem.NeedCheckBC);
                                }
                            }

                            #endregion

                            eticBarCode = (string)null;

                            #region НЕОБХОДИМОСТЬ СКАНИРОВАНИЯ Ш/К ЭТИКЕТКИ

                            if (appliedProcessVersion && needCheckEticBarCode)
                            {
                                var needSelectEtic = true;
                                while (needSelectEtic)
                                {
                                    var dlgScanEtic = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                                    {
                                        Text = "Идентификация этикетки тары",
                                        Label = "Отсканируйте ш/к тары, тип которой выбран для упаковки",
                                        Image = Properties.Resources.paper_box
                                    };

                                    if (dlgScanEtic.ShowDialog() == DialogResult.OK)
                                    {
                                        try
                                        {
                                            eticBarCode = dlgScanEtic.Barcode;

                                            using (var adapter = new WMSOffice.Data.PickControlTableAdapters.QueriesTableAdapter())
                                                adapter.CheckEticBarCode(boxType, eticBarCode);

                                            needSelectEtic = false;
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            needSelectEtic = true;
                                        }
                                    }
                                    else
                                    {
                                        needSelectEtic = true;
                                    }
                                }
                            }

                            #endregion
                        }
                    }

                    closeDocActionType = (CloseDocActionType)(actionType ?? (int)CloseDocActionType.Default);
                    switch (closeDocActionType)
                    {
                        case CloseDocActionType.ChoicePlasticBox:
                            #region ВЫБОР ПЛАСТИКА

                            // Учет выбранного ящика
                            using (var adapter = new WMSOffice.Data.PickControlTableAdapters.QueriesTableAdapter())
                                adapter.InsertContainerToPS(docID, eticBarCode);

                            #endregion
                            break;
                        case CloseDocActionType.PrintEticCount:
                            #region ПЕЧАТЬ БЭ

                            var countEtic = (int?)null; // кол-во БЭ

                            var approvePrintEticFlag = (int?)null; // разрешающий признак печати большего числа БЭ 
                            var bossID = (int?)null; // код руководителя
                            var tareCapBarCode = (string)null; // Ш/К ОТ

                            var needSelectEticCount = true;
                            while (needSelectEticCount)
                            {
                                try
                                {
                                    if (isPlatzkart)
                                    {
                                        
                                    }
                                    else
                                    {
                                        if ((approvePrintEticFlag ?? 0) == 0)
                                        {
                                            // ...спрашиваем количество этикеток (мест)
                                            var frmEticCount = new EticCountForm();
                                            frmEticCount.Count = (countEtic ?? 1);
                                            frmEticCount.LimitCount = 10;
                                            if (frmEticCount.ShowDialog() == DialogResult.OK)
                                            {
                                                if (frmEticCount.Count < 0)
                                                    throw new Exception("Недопустимое значение КОЛИЧЕСТВА МЕСТ:\r\nвведено меньше нуля!");
                                                else if (frmEticCount.Count > 999)
                                                    throw new Exception("Недопустимое значение КОЛИЧЕСТВА МЕСТ:\r\nвведено больше 999!");
                                                else
                                                    countEtic = frmEticCount.Count;
                                            }
                                            else
                                                continue;
                                        }
                                    }

                                    // Необходимость выбора крышки для ОТ
                                    if ((needTareCapFlag ?? 0) == 1 && string.IsNullOrEmpty(tareCapBarCode))
                                        PickControlWindow.LinkDocTareCap(docID, boxType, eticBarCode, ref tareCapBarCode);

                                    // Печать этикеток
                                    using (var adapter = new WMSOffice.Data.PickControlTableAdapters.QueriesTableAdapter())
                                        adapter.PrintEtic(docID, userID, countEtic, System.Security.Principal.WindowsIdentity.GetCurrent().Name, boxType, eticBarCode, tareCapBarCode, (approvePrintEticFlag ?? 0) == 1 ? bossID : (int?)null);

                                    needSelectEticCount = false;

                                    // Контроль БЭ
                                    PickControlWindow.CheckPrintedEtics(userID, docID, adaptTestVersionChanges, isPlatzkart);
                                }
                                catch (Exception ex)
                                {
                                    var message = ex.Message;

                                    if (message.Contains("#"))
                                    {
                                        var regex = new System.Text.RegularExpressions.Regex(@"^#(?<Tag>\w+)#(?<Message>.+)#", System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Singleline);
                                        if (regex.IsMatch(ex.Message))
                                        {
                                            var match = regex.Match(ex.Message);
                                            message = match.Groups["Message"].Value;

                                            var tag = match.Groups["Tag"].Value.ToUpper();
                                            if (tag.Equals("ADD_ETIC", StringComparison.OrdinalIgnoreCase))
                                            {
                                                if (MessageBox.Show(message, "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                                                {
                                                    #region ОЖИДАНИЕ ПОДТВЕРЖДЕНИЯ РУКОВОДИТЕЛЯ СКАНИРОВАНИЕМ

                                                    while (true)
                                                    {
                                                        try
                                                        {
                                                            var dlgBossScanner = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                                                            {
                                                                Label = "Отсканируйте бэйдж руководителя,\r\nкоторый отвечает за мониторинг контроля",
                                                                Text = "Подтверждение указанного количества мест",
                                                                Image = Properties.Resources.role,
                                                                //OnlyNumbersInBarcode = true
                                                                UseScanModeOnly = true
                                                            };

                                                            if (dlgBossScanner.ShowDialog() != DialogResult.OK)
                                                                break;

                                                            bossID = Convert.ToInt32(dlgBossScanner.Barcode);

                                                            var result = (int?)null;
                                                            using (var checkBossAdapter = new Data.PickControlTableAdapters.QueriesTableAdapter())
                                                                checkBossAdapter.CheckBoss(userID, docID, bossID, ref result);

                                                            if (result.HasValue && Convert.ToBoolean(result.Value))
                                                            {
                                                                approvePrintEticFlag = 1;
                                                                break;
                                                            }
                                                            else
                                                            {
                                                                MessageBox.Show("Пользователь не имеет права\r\nподтверждения.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                                continue;
                                                            }
                                                        }
                                                        catch (Exception exc)
                                                        {
                                                            MessageBox.Show(exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                            continue;
                                                        }
                                                    }

                                                    #endregion
                                                }
                                                else
                                                {
                                                    continue;
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }

                            #endregion
                            break;
                        case CloseDocActionType.AbortDueToWeightControlDifference:
                            #region ПРЕРВАТЬ В СВЯЗИ С РАСХОЖДЕНИЯМИ В ВЕСОВОМ КОНТРОЛЕ

                            var dlgWarning = new FullScreenErrorForm("Сборочный не прошел весовой контроль, передайте ящик на стол с весами.", "ПРОДОЛЖИТЬ (Enter)", Color.Orange);
                            dlgWarning.TimeOut = 2000;
                            dlgWarning.ShowDialog();

                            #endregion
                            break;
                        case CloseDocActionType.Default:
                        default:
                            break;
                    }

                    needExecuteAction = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    needExecuteAction = true;
                }
            }

            return closeDocActionType;
        }

        public static void CheckPrintedEtics(int userID, long docID, bool adaptTestVersionChanges)
        {
            PickControlWindow.CheckPrintedEtics(userID, docID, adaptTestVersionChanges, false, false);
        }

        public static void CheckPrintedEtics(int userID, long docID, bool adaptTestVersionChanges, bool needControlInternetOrder)
        {
            PickControlWindow.CheckPrintedEtics(userID, docID, adaptTestVersionChanges, false, needControlInternetOrder);
        }

        public static void CheckPrintedEtics(int userID, long docID, bool adaptTestVersionChanges, bool isPlatzkart, bool needControlInternetOrder)
        {
            if (!adaptTestVersionChanges)
                return;

            try
            {
                #region КОНТРОЛЬ НАПЕЧАТАННОЙ БЭ

                var pickSlipEtics = new Data.PickControl.PickSlipEticsDataTable();

                // Получение списка БЭ для контроля
                using (var eticAdapter = new Data.PickControlTableAdapters.PickSlipEticsTableAdapter())
                    eticAdapter.Fill(pickSlipEtics, userID, docID);

                var eticBarcode = string.Empty;
                var eticControlLeft = pickSlipEtics.Count; // осталось проконтролировать БЭ 

                var boxNumber = 1; // Порядковый номер ящика для сборочного "Плацкарт"
                var tareBarcode = (string)null;

                while (eticControlLeft > 0)
                {
                    try
                    {
                        if (isPlatzkart)
                        {
                            // TODO вывод полноэкранного сообщения о дальнейших действиях пользователя
                        }

                        if (isPlatzkart)
                        {
                            #region СКАНИРОВАНИЕ Ш/К ТАРЫ

                            var dlgTareScanner = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                            {
                                Label = string.Format("Отсканируйте ш/к тары,\r\nкоторую выбрано для упаковки\r\n\r\nЯЩИКА № {0}\r\n\r\nв текущем сборочном", boxNumber),
                                Text = string.Format("Контроль упаковки ящика № {0} в тару", boxNumber),
                                Image = Properties.Resources.platzkart
                            };
                            dlgTareScanner.ChangeLabelHeight(12, 85);

                            if (dlgTareScanner.ShowDialog() == DialogResult.OK)
                                tareBarcode = dlgTareScanner.Barcode;
                            else
                                continue;

                            #endregion
                        }

                        #region СКАНИРОВАНИЕ БЭ

                        var boxLabel = isPlatzkart ? string.Format("для ящика {0} ", boxNumber) : string.Empty;
                        var dlgEticScanner = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                        {
                            Label = string.Format("Отсканируйте белую этикетку,\r\nкоторую необходимо проконтролировать\r\nдля текущего сборочного{0}", needControlInternetOrder ? "\r\n\r\nНАКЛЕЙТЕ ЭТИКЕТКУ НА ПК!!!" : ""),
                            Text = string.Format("Контроль белых этикеток {1}(осталось {0})", eticControlLeft, boxLabel),
                            Image = Properties.Resources.icon_staff_pick
                        };

                        if (needControlInternetOrder)
                            dlgEticScanner.ChangeLabelHeight(12, 85);

                        if (dlgEticScanner.ShowDialog() == DialogResult.OK)
                            eticBarcode = dlgEticScanner.Barcode;
                        else
                            continue;

                        #endregion

                        // Контроль БЭ
                        using (var eticAdapter = new Data.PickControlTableAdapters.PickSlipEticsTableAdapter())
                            eticAdapter.CheckEtic(userID, docID, eticBarcode, tareBarcode);

                        // БЭ проконтролирована
                        eticControlLeft--;

                        // Ящик проконтролирован
                        if (isPlatzkart)
                            boxNumber++;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void CheckMDSTare(long docID, int itemID)
        {
            try
            {
                var label = "Отсканируйте тару, которую выбрали\r\nдля упаковки текущего товара\r\nв мультидробном сборочном";

                var hasRecommendedTare = false;

                #region ВЫБОР РЕКОМЕНДУЕМОЙ ТАРЫ

                var cancelRetTareFlag = 0; 
                var recommendedTareType = (string)null;
                var returnedTareFlag = (int?)null;
                var splitFlag = (int?)null;
                var cancelReason = (string)null;
                var changeTare = (int?)null;

                using (var qAdapter = new Data.PickControlTableAdapters.QueriesTableAdapter())
                    qAdapter.AdaptRecommendedTareType(docID, cancelRetTareFlag, ref recommendedTareType, ref returnedTareFlag, ref splitFlag, cancelReason, itemID, changeTare);

                if (!string.IsNullOrEmpty(recommendedTareType))
                {
                    label = string.Format("{0}\r\n\r\nРЕКОМЕНДУЕМАЯ ТАРА:\r\n{1}", label, recommendedTareType);
                    hasRecommendedTare = true;
                }

                #endregion

                var tareBarcode = string.Empty;

                while (true)
                {
                    try
                    {
                        var dlgTareScanner = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                        {
                            Label = label,
                            Text = "Контроль упаковки",
                            Image = Properties.Resources.paper_box,
                            Barcode = tareBarcode,
                            UseScanModeOnly = true
                        };

                        // Если указана рекоммендуемая тара, то увеличим высоту надписи
                        if (hasRecommendedTare)
                            dlgTareScanner.ChangeLabelHeight(12, 85);

                        if (dlgTareScanner.ShowDialog() == DialogResult.OK)
                            tareBarcode = dlgTareScanner.Barcode;
                        else
                            continue;

                        using (var adapter = new Data.PickControlTableAdapters.QueriesTableAdapter())
                            adapter.CheckMDSTare(docID, itemID, tareBarcode);

                        break;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static WMSOffice.Dialogs.PickControl.FullScreenErrorForm tapeMessageForm = null;
        private static void CloseTapeMessageForm()
        {
            if (tapeMessageForm != null)
            {
                try
                {
                    tapeMessageForm.Hide();
                    tapeMessageForm.Close();
                    tapeMessageForm.Dispose();
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    tapeMessageForm = null;
                }
            }
        }

        /// <summary>
        /// Режим выбора тары через сканирование
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="userLogin"></param>
        /// <param name="docID"></param>
        /// <param name="modeID"></param>
        /// <param name="boxType"></param>
        /// <param name="eticBarCode"></param>
        /// <param name="needTareCapFlag"></param>
        /// <param name="actionType"></param>
        /// <returns></returns>
        public static bool SelectTareBarCode(int userID, string userLogin, long docID, int modeID, int cancelRetTareFlag, string cancelReason, string defaultTareBarCode, bool weightControlCompleted, ref int? boxType, ref string eticBarCode, ref int? needTareCapFlag, ref int? actionType)
        {
            try
            {
                // Освобождение ресурсов формы рекоммендации скотча (для повторного вызова)
                CloseTapeMessageForm();

                // Параметры отображения формы с требуемым скотчем
                var hasTape = false;
                var msgTape = (string)null;

                // Признак изменения выбора упаковки
                var changeTare = (int?)null;

                // Выбор сценария при выборе тары
                var selectionViaScanningFlag = (int?)null;

                using (var adapter = new Data.PickControlTableAdapters.QueriesTableAdapter())
                    adapter.CheckTareSelectionModeViaScanning(docID, userLogin, modeID, actionType, ref selectionViaScanningFlag);

                #region ОБРАБОТКА ПОЛЬЗОВАТЕЛЬСКОГО ВЫБОРА УПАКОВКИ М/С ЛИБО ПЛАСТИКОМ ЛИБО ГОФРОЙ

                if (modeID == 1 && selectionViaScanningFlag == 2)
                {
                    MessageBoxManager.Yes = "&Да";
                    MessageBoxManager.No = "&Нет";
                    MessageBoxManager.Cancel = "&Повтор";
                    MessageBoxManager.Register();

                    var msgResult = MessageBox.Show(string.Format("Для упаковки будет использоваться м/с пластик."), "Внимание", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button3);

                    MessageBoxManager.Unregister();

                    if (msgResult == DialogResult.Yes)
                    {
                        // выбор пластика
                        selectionViaScanningFlag = 0;
                    }
                    else if (msgResult == DialogResult.No)
                    {
                        // выбор гофры
                        selectionViaScanningFlag = 1;
                        changeTare = 1;
                    }
                    else if (msgResult == DialogResult.Cancel)
                    {
                        // повтор опроса
                        var aBoxType = boxType;
                        var aEticBarcode = eticBarCode;
                        var aNeedTareCapFlag = needTareCapFlag;
                        var aActionType = actionType;

                        var selectTareResult = false;

                        selectTareResult = PickControlWindow.SelectTareBarCode(userID, userLogin, docID, modeID, cancelRetTareFlag, cancelReason, defaultTareBarCode, weightControlCompleted, ref aBoxType, ref aEticBarcode, ref aNeedTareCapFlag, ref aActionType);
                        return selectTareResult;
                    }
                }

                #endregion
                
                // Активирован режим выбора тары через сканирование
                if (Convert.ToBoolean(selectionViaScanningFlag ?? 0) == true)
                {
                    var hasRecommendedTare = false;

                    var label = "Отсканируйте ш/к тары,\r\nкоторая выбрана для упаковки.";
                    var returnedTareFlag = (int?)null;
                    var splitFlag = (int?)null;

                    // если тара выбирается сразу после создания документа контроля
                    if (modeID == 1)
                    {
                        #region ВЫБОР РЕКОМЕНДУЕМОЙ ТАРЫ

                        var recommendedTareType = (string)null;
                        var itemID = (int?)null;

                        using (var qAdapter = new Data.PickControlTableAdapters.QueriesTableAdapter())
                            qAdapter.AdaptRecommendedTareType(docID, cancelRetTareFlag, ref recommendedTareType, ref returnedTareFlag, ref splitFlag, cancelReason, itemID, changeTare);

                        if (!string.IsNullOrEmpty(recommendedTareType))
                        {
                            label = string.Format("{0}\r\n\r\nРЕКОМЕНДУЕМАЯ ТАРА:\r\n{1}", label, recommendedTareType);
                            hasRecommendedTare = true;
                        }

                        #endregion

                        #region АНАЛИЗ ТРЕБОВАНИЯ УПАКОВКИ ТОВАРА СКОТЧЕМ

                        using (var qAdapter = new Data.PickControlTableAdapters.QueriesTableAdapter())
                            hasTape = !string.IsNullOrEmpty(msgTape = qAdapter.GetPickSlipControlPackMessage(userID, docID).ToString());

                        #endregion
                    }

                    eticBarCode = (string)null;

                    #region СКАНИРОВАНИЕ Ш/К ТАРЫ

                    var lastBarcode = defaultTareBarCode;

                    var needSelectEtic = true;
                    while (needSelectEtic)
                    {
                        #region ОТОБРАЖЕНИЕ ТРЕБОВАНИЯ УПАКОВКИ ТОВАРА СКОТЧЕМ

                        if (hasTape)
                        {
                            var sbMessage = new StringBuilder(""); // Внимание!
                            sbMessage.Append(msgTape);

                            var sMessage = sbMessage.ToString();
                            tapeMessageForm = new WMSOffice.Dialogs.PickControl.FullScreenErrorForm(sMessage, "ПРОДОЛЖИТЬ (Enter)", System.Drawing.Color.LightGreen, true);
                            tapeMessageForm.PreviewMode = true;
                            tapeMessageForm.TimeOut = 2000;
                            tapeMessageForm.AutoClose = false;

                            tapeMessageForm.Show();
                        }

                        #endregion

                        var dlgScanEtic = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                        {
                            Text = "Идентификация тары",
                            Label = label,
                            Image = Properties.Resources.paper_box,
                            Barcode = lastBarcode,
                            UseScanModeOnly = true
                        };

                        // Позиционирование формы сканирования
                        dlgScanEtic.Load += (s, e) =>
                        {
                            if (hasTape)
                            {
                                dlgScanEtic.StartPosition = FormStartPosition.Manual;

                                var area = Screen.PrimaryScreen.WorkingArea;
                                dlgScanEtic.Location = new Point(area.Width / 2 - dlgScanEtic.Width / 2, area.Height / 2 - dlgScanEtic.Height / 2 - 2 * FullScreenErrorForm.PREVIEW_SHIFT_TOP);
                            }
                        };

                        // Если указана рекоммендуемая тара, то увеличим высоту надписи
                        if (hasRecommendedTare)
                            dlgScanEtic.ChangeLabelHeight(12, 85);

                        #region КНОПКА ПОВТОРНОГО ЗАПРОСА РЕКОММЕНДУЕМОЙ ТАРЫ

                        var aBoxType = boxType;
                        var aEticBarcode = eticBarCode;
                        var aNeedTareCapFlag = needTareCapFlag;
                        var aActionType = actionType;

                        var selectTareResult = false;
                        var refreshDone = false;

                        dlgScanEtic.AddAction("Обновить", () =>
                        {
                            defaultTareBarCode = dlgScanEtic.Barcode;

                            refreshDone = true;
                            selectTareResult = PickControlWindow.SelectTareBarCode(userID, userLogin, docID, modeID, cancelRetTareFlag, cancelReason, defaultTareBarCode, weightControlCompleted, ref aBoxType, ref aEticBarcode, ref aNeedTareCapFlag, ref aActionType);

                        }, true);

                        #endregion

                        #region КНОПКА СБРОСА ОТ

                        if ((returnedTareFlag ?? 0) == 1)
                        {
                            dlgScanEtic.AddAction("Сброс ОТ", () =>
                            {
                                defaultTareBarCode = dlgScanEtic.Barcode;

                                #region ОЖИДАНИЕ ПОДТВЕРЖДЕНИЯ РУКОВОДИТЕЛЯ СКАНИРОВАНИЕМ

                                while (true)
                                {
                                    //// TODO временно сброс тары происходит без сканировки бэйджа
                                    //cancelRetTareFlag = 1; // устанавливаем флаг сброса ОТ
                                    //break;
                                    ////

                                    try
                                    {
                                        var dlgBossScanner = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                                        {
                                            Label = "Отсканируйте бэйдж руководителя,\r\nкоторый отвечает за мониторинг контроля",
                                            Text = "Сброс ОТ",
                                            Image = Properties.Resources.role,
                                            //OnlyNumbersInBarcode = true
                                            UseScanModeOnly = true
                                        };

                                        if (dlgBossScanner.ShowDialog() != DialogResult.OK)
                                            break;

                                        var bossID = Convert.ToInt32(dlgBossScanner.Barcode);

                                        var result = (int?)null;
                                        using (var checkBossAdapter = new Data.PickControlTableAdapters.SurplusContainerDocsTableAdapter())
                                            checkBossAdapter.CheckBoss(userID, docID, bossID, ref result);

                                        if (result.HasValue && Convert.ToBoolean(result.Value))
                                        {
                                            #region ЗАПРАШИВАЕМ КОММЕНТАРИЙ

                                            cancelReason = (string)null;
                                            using (EnterStringValueForm frmEnterStringValue = new EnterStringValueForm("Комментарий", "Укажите причину\r\nсброса ОТ:", string.Empty) { AllowEmptyValue = false, Width = 350 })
                                            {
                                                #region КНОПКА ОТОБРАЖЕНИЯ ОСТАТКА ОТ
                                                frmEnterStringValue.AddAction("Остаток ОТ", () =>
                                                {
                                                    #region ОСТАТОК ОТ
                                                    try
                                                    {
                                                        Data.PickControl.PC_RET_Tare_RemainsDataTable remains = null;
                                                        using (var adapter = new Data.PickControlTableAdapters.PC_RET_Tare_RemainsTableAdapter())
                                                            remains = adapter.GetData(docID);

                                                        var dlgRemains = new WMSOffice.Dialogs.RichListForm();
                                                        dlgRemains.Text = "Остаток ОТ";
                                                        dlgRemains.AddColumn("Tare_Type_Description", "Tare_Type_Description", "Наименование тары");
                                                        dlgRemains.AddColumn("count", "count", "Количество");
                                                        dlgRemains.FilterVisible = false;
                                                        dlgRemains.DataSource = remains;

                                                        dlgRemains.ShowDialog();
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    }
                                                    #endregion
                                                }, false);
                                                #endregion

                                                if (frmEnterStringValue.ShowDialog() == DialogResult.OK)
                                                {
                                                    cancelReason = frmEnterStringValue.Value; // указываем причину сброса ОТ
                                                    cancelReason = cancelReason.Substring(0, Math.Min(cancelReason.Length, 255));
                                                }
                                                else
                                                    break;
                                            }

                                            #endregion

                                            cancelRetTareFlag = bossID; // устанавливаем флаг сброса ОТ (передаем код руководителя(!!!))
                                            defaultTareBarCode = (string)null;
                                            break;
                                        }
                                        else
                                        {
                                            MessageBox.Show("Пользователь не имеет права\r\nподтверждения.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            continue;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        continue;
                                    }
                                }

                                #endregion

                                refreshDone = true;
                                selectTareResult = PickControlWindow.SelectTareBarCode(userID, userLogin, docID, modeID, cancelRetTareFlag, cancelReason, defaultTareBarCode, weightControlCompleted, ref aBoxType, ref aEticBarcode, ref aNeedTareCapFlag, ref aActionType);

                            }, true);
                        }

                        #endregion

                        #region КНОПКА ВЫБОРА Б/У ГОФРОТАРЫ

                        if ((splitFlag ?? 0) > 1)
                        {
                            dlgScanEtic.AddAction("Сплит Б/У", () =>
                            {
                                defaultTareBarCode = dlgScanEtic.Barcode;

                                var dlgScanUsedTare = new ScanUsedTareForm(splitFlag ?? 0);
                                if (dlgScanUsedTare.ShowDialog() == DialogResult.OK)
                                {
                                    var tareCombinedBarCode = dlgScanUsedTare.TareCombinedBarCode;
                                    defaultTareBarCode = tareCombinedBarCode;
                                }
                                refreshDone = true;
                                selectTareResult = PickControlWindow.SelectTareBarCode(userID, userLogin, docID, modeID, cancelRetTareFlag, cancelReason, defaultTareBarCode, weightControlCompleted, ref aBoxType, ref aEticBarcode, ref aNeedTareCapFlag, ref aActionType);

                            }, true);
                        }

                        #endregion


                        #region КНОПКА ВВОДА НТВ

                        if (weightControlCompleted)
                        {
                            dlgScanEtic.Mode = ScanContainerViewMode.Extended;
                            dlgScanEtic.AddAction("Ввод НТВ", () =>
                            {
                                // Получение рекомендуемой тары
                                var recommendedTare = PickControlPreviewForm.GetRecommendedTare(docID);

                                // Отображение списка товара в сборочном
                                var dlgPickControlPreview = new PickControlPreviewForm(userID, docID) { RecommendedTare = recommendedTare };
                                if (dlgPickControlPreview.ShowDialog(/*dlgScanEtic*/) != DialogResult.OK)
                                { }
                                //defaultTareBarCode = dlgScanEtic.Barcode;

                                //var dlgScanUsedTare = new ScanUsedTareForm(splitFlag ?? 0);
                                //if (dlgScanUsedTare.ShowDialog() == DialogResult.OK)
                                //{
                                //    var tareCombinedBarCode = dlgScanUsedTare.TareCombinedBarCode;
                                //    defaultTareBarCode = tareCombinedBarCode;
                                //}
                                //refreshDone = true;
                                //selectTareResult = PickControlWindow.SelectTareBarCode(userID, userLogin, docID, modeID, cancelRetTareFlag, cancelReason, defaultTareBarCode, ref aBoxType, ref aEticBarcode, ref aNeedTareCapFlag, ref aActionType);

                            }, true, false);
                        }

                        #endregion

                        if (dlgScanEtic.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                eticBarCode = dlgScanEtic.Barcode;
                                lastBarcode = eticBarCode;

                                var wrongVolumeFlag = (int?)null;
                                //var needTareCapFlag = (int?)null;

                                var nextTareFlag = (bool?)null;

                                using (var adapter = new Data.PickControlTableAdapters.QueriesTableAdapter())
                                    adapter.AdaptDocTareType(eticBarCode, docID, returnedTareFlag, ref boxType, ref wrongVolumeFlag, ref needTareCapFlag, ref actionType, ref nextTareFlag);

                                // Если объем сборочного превосходит объем тары
                                var wrongVolume = Convert.ToBoolean(wrongVolumeFlag ?? 0);
                                if (wrongVolume && MessageBox.Show("Объем сборочного превышает объем тары.\r\nВы желаете выбрать другую тару?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                                {
                                    lastBarcode = (string)null;
                                    continue;
                                }

                                #region ОБРАБОТКА МНОГОКРАТНОГО СКАНИРОВАНИЯ ДЛЯ СБОРОЧНОГО "ПЛАЦКАРТ"

                                if ((nextTareFlag ?? false) == true)
                                {
                                    aBoxType = boxType;
                                    aEticBarcode = eticBarCode;
                                    aNeedTareCapFlag = needTareCapFlag;
                                    aActionType = actionType;

                                    selectTareResult = PickControlWindow.SelectTareBarCode(userID, userLogin, docID, modeID, cancelRetTareFlag, cancelReason, defaultTareBarCode, weightControlCompleted, ref aBoxType, ref aEticBarcode, ref aNeedTareCapFlag, ref aActionType);
                                    return selectTareResult;
                                }

                                #endregion

                                needSelectEtic = false;
                                lastBarcode = (string)null;
                                return true;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                needSelectEtic = true;
                            }
                        }
                        else
                        {
                            // !!! Анализ автоматического получения результата в случае обновления рекоммендуемой тары
                            if (refreshDone)
                            {
                                boxType = aBoxType;
                                eticBarCode = aEticBarcode;
                                needTareCapFlag = aNeedTareCapFlag;
                                actionType = aActionType;
                                return selectTareResult;
                            }

                            needSelectEtic = true;
                        }
                    }

                    #endregion
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                // Освобождение ресурсов формы рекоммендации скотча
                CloseTapeMessageForm();
            }
        }

        /// <summary>
        /// Привязка крышки к ОТ
        /// </summary>
        /// <param name="docID"></param>
        /// <param name="boxType"></param>
        /// <param name="eticBarCode"></param>
        /// <param name="tareCapBarCode"></param>
        /// <returns></returns>
        public static bool LinkDocTareCap(long docID, int? boxType, string eticBarCode, ref string tareCapBarCode)
        {
            var lastTareCapBarcode = (string)null;

            var needSelectEtic = true;
            while (needSelectEtic)
            {
                var dlgScanEtic = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                {
                    Text = "Идентификация крышки тары",
                    Label = "Отсканируйте ш/к крышки тары,\r\nкоторая выбрана для упаковки.",
                    Image = Properties.Resources.paper_box,
                    Barcode = lastTareCapBarcode,
                    UseScanModeOnly = true
                };

                if (dlgScanEtic.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        tareCapBarCode = dlgScanEtic.Barcode;
                        lastTareCapBarcode = tareCapBarCode;

                        // Привязка крышки к ОТ
                        var confirmFlag = (int?)null;
                        using (var adapter = new Data.PickControlTableAdapters.QueriesTableAdapter())
                            adapter.LinkDocTareCap(docID, tareCapBarCode, boxType, eticBarCode, ref confirmFlag);

                        #region Подтверждение ОТ
                        var lastConfirmTareBarcode = (string)null;

                        var needConfirmEtic = Convert.ToBoolean(confirmFlag ?? 0);
                        while (needConfirmEtic)
                        {
                            var dlgConfirmEtic = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                            {
                                Text = "Подтверждение тары",
                                Label = "Отсканируйте ш/к тары,\r\nкоторая выбрана для упаковки.",
                                Image = Properties.Resources.paper_box,
                                Barcode = lastConfirmTareBarcode,
                                UseScanModeOnly = true
                            };
                            if (dlgConfirmEtic.ShowDialog() == DialogResult.OK)
                            {
                                try
                                {
                                    lastConfirmTareBarcode = dlgConfirmEtic.Barcode;
                                    if (lastConfirmTareBarcode.Equals(eticBarCode, StringComparison.OrdinalIgnoreCase))
                                    {
                                        needConfirmEtic = false;
                                        lastConfirmTareBarcode = (string)null;
                                    }
                                    else
                                        throw new Exception(string.Format("Фактическая тара отличается от заявленной.\r\nШ/К заявленной тары: {0}", eticBarCode));
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    needConfirmEtic = true;
                                }
                            }
                        }
                        #endregion

                        needSelectEtic = false;
                        lastTareCapBarcode = (string)null;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        needSelectEtic = true;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Признак запрета корректировки строк по кнопке "Нет товара"
        /// </summary>
        private bool lockCorrectLines = false;

        private bool allowCloseWindow = false;
        private void btnCloseDoc_Click(object sender, EventArgs e)
        {
            if (Control.ModifierKeys == (Keys.Control | Keys.Alt))
            {
                btnUndoDoc_Click(sender, e);
            }
            else
            {
                bool hasErrors = false;

                #region исправление красных строк

                if (!this.IsProcessVersionEquals_2)
                {
                    foreach (DataGridViewRow row in gvLines.Rows)
                    {
                        Data.PickControl.DocRowsRow diffRow = (Data.PickControl.DocRowsRow)((DataRowView)row.DataBoundItem).Row;
                        if (String.IsNullOrEmpty(diffRow.Vendor_Lot) && diffRow.Doc_Qty == 0)
                        {
                            ShowError("Необходимо исправить все строки, подсвеченные красным!\n\rПри полном отсутствии строки нажмите кнопку \"нет товара\".");
                            hasErrors = true;
                            break;
                        }
                    }
                }
                #endregion

                #region ДОПОЛНИТЕЛЬНАЯ ПРЕДВАЛИДАЦИЯ ПО ИСПРАВЛЕНИЮ СТРОК

                if (!hasErrors && IsRepeatControl && this.IsProcessVersionEquals_2)
                {
                    #region OBSOLETE

                    //var lostItemDel = (int?)null;

                    //try
                    //{
                    //    docRowsTableAdapter.CheckNotControlledItems(this.DocID, (int?)null, (int?)null, ref lostItemDel);
                    //}
                    //catch { }

                    //if (lostItemDel.HasValue && lostItemDel.Value.Equals(1))
                    //{
                    //    ShowError("Необходимо исправить все непроконтролированные строки.\n\rПри полном отсутствии строки нажмите кнопку \"нет товара\".");
                    //    hasErrors = true;
                    //}

                    #endregion

                    if (!this.CheckPickControlCanClose())
                    {
                        ShowError("Необходимо исправить все непроконтролированные строки.\n\rПри полном отсутствии строки нажмите кнопку \"нет товара\".");
                        hasErrors = true;
                    }
                }

                #endregion

                if (hasErrors) { }
                else
                    if (gvLines.Rows.Count < 1 && !IsRepeatControl)
                        ShowError("Документ контроля сборки не содержит строк.\n\rТакой документ нельзя закрыть! Продолжайте работу.");
                    else
                    {
                        using (Data.PickControlTableAdapters.QueriesTableAdapter adapter = new WMSOffice.Data.PickControlTableAdapters.QueriesTableAdapter())
                        {
                            try
                            {
                                if (this.NeedControlInternetOrder && !this.IsRepeatControl)
                                {
                                    var diff = CorrectInternetOrdersPickErrorsForm.GetPickControlDifference(this.DocID);
                                    if (CorrectInternetOrdersPickErrorsForm.CheckOnlySurplus(diff))
                                    {
                                        var frmDiff = new CorrectInternetOrdersPickErrorsForm()
                                        {
                                            UserID = this.UserID,
                                            DocID = this.DocID,
                                            PickSlipNumber = Convert.ToInt32(numPickSlip),
                                            ProcessVersionID = this.ProcessVersionID,
                                            CommitVersionChanges = this.CommitVersionChanges,
                                            HasOnlySurplus = true
                                        };
                                        frmDiff.InitializeDiffernce(diff);
                                        frmDiff.ShowDialog();

                                        this.RefreshLines();
                                    }
                                }

                                // закрываем документ по базе, если есть ошибки -- получим исключение, которое показываем пользователю
                                adapter.CloseDoc(DocID, UserID, null, this.ProcessVersionID);

                                // если все прошло успешно...

                                var modeID = 2; // выполнение режима терминации после закрытия документа контроля
                                var closeDocActionType = PickControlWindow.ExecuteCloseDocAction(this.UserID, Environment.UserName, this.DocID, modeID, this.IsProcessVersionEquals_2 || this.IsProcessVersionEquals_4, this.CommitVersionChanges, this.IsPlatzkart, this.IsMDP, false);

                                #region АНАЛИЗ РЕЖИМА ЗАКРЫТИЯ (ВЫНЕСЕН В ОТДЕЛЬНЫЙ МЕТОД) OBSOLETE

                                //int? action = (int?)null;
                                //adapter.CloseDocAction(this.UserID, this.DocID, lblDocType.Text, lblContainer.Text, Convert.ToInt32(this.isPlasticBox), ref action);

                                //if ((action.HasValue && action.Value == (int)CloseDocActionType.ChoicePlasticBox) ||
                                //    (!action.HasValue && ((lblDocType.Text == "40" || lblDocType.Text == "41") && (lblContainer.Text == "A1" || lblContainer.Text == "A2" || lblContainer.Text == "A3" 
                                //    || (lblContainer.Text == "A10" && this.isPlasticBox)))))
                                //{
                                //    #region ВЫБОР ПЛАСТИКОВОГО ЯЩИКА

                                //    // ... и это межсклад, то спрашиваем штрих код пластикового ящика
                                //    ScanContainerForm form = new ScanContainerForm();
                                //    bool scanError = true;
                                //    while (scanError)
                                //    {
                                //        try
                                //        {
                                //            if (form.ShowDialog() == DialogResult.OK && !String.IsNullOrEmpty(form.Barcode))
                                //            {
                                //                adapter.InsertContainerToPS(DocID, form.Barcode);
                                //                scanError = false;
                                //            }
                                //        }
                                //        catch (Exception exch)
                                //        {
                                //            ShowError(exch);
                                //            scanError = true;
                                //        }
                                //    }

                                //    #endregion
                                //}
                                //else if ((action.HasValue && action.Value == (int)CloseDocActionType.Default) ||
                                //(!action.HasValue && (((lblDocType.Text == "40" || lblDocType.Text == "41") && (lblContainer.Text == "A0"))   // межсклады
                                //|| (lblContainer.Text == "A9")                                                         // сборочные "волна"
                                //|| (lblContainer.Text == "P1")))

                                //// Пока не будут ясны все ньюансы процесса, изменения не вступят в силу
                                //    //|| (!(lblDocType.Text != "40" && lblDocType.Text != "41" && lblContainer.Text == "A10")) // WMS-3182
                                //)
                                //{
                                //    #region ЗАКРЫТИЕ ПО УМОЛЧАНИЮ

                                //    // тут может быть размещена ваша реклама

                                //    #endregion
                                //}
                                //    else if ((action.HasValue && action.Value == (int)CloseDocActionType.PrintEticCount) || (!action.HasValue))
                                //{
                                //    #region ВЫБОР И ПЕЧАТЬ КОЛ-ВА ЭТИКЕТОК

                                //    //var modeID = 2; // определение тары после закрытия документа контроля
                                //    PickControlWindow.ExecuteCloseDocAction(this.UserID, Environment.UserName, this.DocID, modeID, this.IsProcessVersionEquals_2 || this.IsProcessVersionEquals_4, this.CommitVersionChanges);

                                //    #region OBSOLETE (ФУНКЦИОНАЛ ВЫДЕЛЕН В ОТДЕЛЬНЫЙ СТАТИЧЕСКИЙ МЕТОД PickControlWindow.CheckPrintedEtic)

                                //    //// ...спрашиваем количество этикеток (мест)
                                //    //EticCountForm form = new EticCountForm();
                                //    //form.Count = 1;
                                //    //bool eticError = true;
                                //    //while (eticError)
                                //    //{
                                //    //    try
                                //    //    {
                                //    //        if (form.ShowDialog() == DialogResult.OK)
                                //    //            if (form.Count < 0)
                                //    //                MessageBox.Show("Недопустимое значение КОЛИЧЕСТВА МЕСТ: введено меньше нуля!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                //    //            else if (form.Count > 999)
                                //    //                MessageBox.Show("Недопустимое значение КОЛИЧЕСТВА МЕСТ: введено больше 999!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                //    //            else
                                //    //            {
                                //    //                #region ВЫБОР ТИПА ТАРЫ ДЛЯ УПАКОВКИ

                                //    //                int? boxType = 0; // тип тары
                                //    //                bool needCheckEticBarCode = false; // необходимость сканирования ш/к этикетки 

                                //    //                Data.PickControl.PickContainerTypesDataTable containerTypes = null;
                                //    //                using (var containerTypeAdapter = new Data.PickControlTableAdapters.PickContainerTypesTableAdapter())
                                //    //                    containerTypes = containerTypeAdapter.GetData(this.UserID, DocID);

                                //    //                if (containerTypes != null && containerTypes.Rows.Count > 0)
                                //    //                {
                                //    //                    var dlgSelectContainerType = new WMSOffice.Dialogs.RichListForm();
                                //    //                    dlgSelectContainerType.Text = "Выберите тип тары для упаковки";
                                //    //                    dlgSelectContainerType.AddColumn("Short_Value", "Short_Value", "Тип тары");
                                //    //                    dlgSelectContainerType.ColumnForFilters = new List<string>(new string[] { "Short_Value" });
                                //    //                    dlgSelectContainerType.FilterChangeLevel = 0;
                                //    //                    dlgSelectContainerType.DataSource = containerTypes;
                                //    //                    dlgSelectContainerType.DiscardCanceling = true;

                                //    //                    if (dlgSelectContainerType.ShowDialog() == DialogResult.OK)
                                //    //                    {
                                //    //                        var selectedItem = dlgSelectContainerType.SelectedRow as Data.PickControl.PickContainerTypesRow;
                                //    //                        boxType = Convert.ToInt32(selectedItem.Key);
                                //    //                        needCheckEticBarCode = selectedItem.IsNeedCheckBCNull() ? false : Convert.ToBoolean(selectedItem.NeedCheckBC);
                                //    //                    }
                                //    //                }

                                //    //                #endregion

                                //    //                var eticBarCode = (string)null;

                                //    //                #region НЕОБХОДИМОСТЬ СКАНИРОВАТЬ Ш/К ЭТИКЕТКИ

                                //    //                if ((this.IsProcessVersionEquals_2 || this.IsProcessVersionEquals_4) && needCheckEticBarCode)
                                //    //                {
                                //    //                    var needSelectEtic = true;
                                //    //                    while (needSelectEtic)
                                //    //                    {
                                //    //                        var dlgScanEtic = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                                //    //                        {
                                //    //                            Text = "Идентификация этикетки тары",
                                //    //                            Label = "Отсканируйте ш/к тары, тип которой выбран для упаковки",
                                //    //                            Image = Properties.Resources.paper_box
                                //    //                        };

                                //    //                        if (dlgScanEtic.ShowDialog() == DialogResult.OK)
                                //    //                        {
                                //    //                            try
                                //    //                            {
                                //    //                                eticBarCode = dlgScanEtic.Barcode;
                                //    //                                adapter.CheckEticBarCode(boxType, eticBarCode);

                                //    //                                needSelectEtic = false;
                                //    //                            }
                                //    //                            catch (Exception ex)
                                //    //                            {
                                //    //                                ShowError(ex);
                                //    //                                needSelectEtic = true;
                                //    //                            }
                                //    //                        }
                                //    //                        else
                                //    //                        {
                                //    //                            needSelectEtic = true;
                                //    //                        }
                                //    //                    }
                                //    //                }

                                //    //                #endregion

                                //    //                adapter.PrintEtic(DocID, UserID, form.Count, System.Security.Principal.WindowsIdentity.GetCurrent().Name, boxType, eticBarCode);

                                //    //                if (this.CommitVersionChanges)
                                //    //                {
                                //    //                    #region КОНТРОЛЬ НАПЕЧАТАННОЙ БЭ

                                //    //                    // Получение списка БЭ для контроля
                                //    //                    using (var eticAdapter = new Data.PickControlTableAdapters.PickSlipEticsTableAdapter())
                                //    //                        eticAdapter.Fill(this.pickControl.PickSlipEtics, this.UserID, DocID);

                                //    //                    var eticBarcode = string.Empty;
                                //    //                    var eticControlLeft = this.pickControl.PickSlipEtics.Count; // осталось проконтролировать БЭ 

                                //    //                    while (eticControlLeft > 0)
                                //    //                    {
                                //    //                        try
                                //    //                        {
                                //    //                            #region СКАНИРОВАНИЕ БЭ

                                //    //                            var dlgEticScanner = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                                //    //                            {
                                //    //                                Label = "Отсканируйте белую этикетку,\r\nкоторую необходимо проконтролировать\r\nдля текущего сборочного",
                                //    //                                Text = string.Format("Контроль белых этикеток (осталось {0})", eticControlLeft),
                                //    //                                Image = Properties.Resources.icon_staff_pick
                                //    //                            };

                                //    //                            if (dlgEticScanner.ShowDialog() == DialogResult.OK)
                                //    //                                eticBarcode = dlgEticScanner.Barcode;
                                //    //                            else
                                //    //                                continue;

                                //    //                            #endregion

                                //    //                            // Контроль БЭ
                                //    //                            using (var eticAdapter = new Data.PickControlTableAdapters.PickSlipEticsTableAdapter())
                                //    //                                eticAdapter.CheckEtic(this.UserID, this.DocID, eticBarcode);

                                //    //                            // БЭ проконтролирована
                                //    //                            eticControlLeft--;
                                //    //                        }
                                //    //                        catch (Exception ex)
                                //    //                        {
                                //    //                            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //    //                        }
                                //    //                    }

                                //    //                    #endregion
                                //    //                }

                                //    //                eticError = false;


                                //    //            }
                                //    //    }
                                //    //    catch (Exception exch)
                                //    //    {
                                //    //        ShowError(exch);
                                //    //        eticError = true;
                                //    //    }
                                //    //}

                                //    #endregion

                                //    #endregion
                                //}

                                #endregion

                                #region АНАЛИЗ НЕОБХОДИМОСТИ ПРОВЕСТИ ПЕРЕВЗВЕШИВАНИЕ ТОВАРА

                                var reweightMessage = (string)null;
                                adapter.GetPickSlipReweightMessage(this.DocID, ref reweightMessage);
                                if (!string.IsNullOrEmpty(reweightMessage))
                                {
                                    var message = reweightMessage.Trim();
                                    var errorForm = new WMSOffice.Dialogs.PickControl.FullScreenErrorForm(message, "ПРОДОЛЖИТЬ (Enter)", System.Drawing.Color.Yellow);
                                    errorForm.TimeOut = 2000;
                                    errorForm.AutoClose = false;
                                    errorForm.ShowDialog();

                                    #region ОЖИДАНИЕ ПОДТВЕРЖДЕНИЯ РУКОВОДИТЕЛЯ СКАНИРОВАНИЕМ

                                    while (true)
                                    {
                                        try
                                        {
                                            var dlgBossScanner = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                                            {
                                                Label = "Отсканируйте бэйдж руководителя,\r\nкоторый отвечает за мониторинг контроля",
                                                Text = "Передача ящика на перевзвешивание",
                                                Image = Properties.Resources.role,
                                                //OnlyNumbersInBarcode = true
                                                UseScanModeOnly = true
                                            };

                                            if (dlgBossScanner.ShowDialog() != DialogResult.OK)
                                                continue;

                                            var bossID = Convert.ToInt32(dlgBossScanner.Barcode);

                                            var result = (int?)null;
                                            using (var checkBossAdapter = new Data.PickControlTableAdapters.SurplusContainerDocsTableAdapter())
                                                checkBossAdapter.CheckBoss(this.UserID, this.DocID, bossID, ref result);

                                            if (result.HasValue && Convert.ToBoolean(result.Value))
                                                break;
                                            else
                                            {
                                                MessageBox.Show("Пользователь не имеет права\r\nподтверждения.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                continue;
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            this.ShowError(ex);
                                            continue;
                                        }
                                    }

                                    #endregion
                                }

                                #endregion

                                // (WMS 418) Анализируем сборочный и в случае наличия термопрепаратов выполняем погрузку в термобоксы
                                if (this.isCold > 0)
                                    LoadTermoItemsToTermoContainers(this.numPickSlip);

                                #region [WMS-4817] OBSOLETE

                                //// для Черкасс создан новый интерфейс уведомления "упакуй зеленым скотчем" (06.11.2012)
                                //if (lblDocType.Text == "0C" || lblDocType.Text == "2C" || lblDocType.Text == "ZC")
                                //    new Dialogs.Pack.GreenTapePackForm().ShowDialog();

                                #endregion

                                #region АНАЛИЗ ТРЕБОВАНИЯ УПАКОВКИ ТОВАРА СКОТЧЕМ

                                var msg = adapter.GetPickSlipControlPackMessage(this.UserID, this.DocID).ToString();
                                if (!string.IsNullOrEmpty(msg.Trim()))
                                {
                                    var sbMessage = new StringBuilder("Внимание!");
                                    sbMessage.Append(msg);

                                    var sMessage = sbMessage.ToString();
                                    var errorForm = new WMSOffice.Dialogs.PickControl.FullScreenErrorForm(sMessage, "ПРОДОЛЖИТЬ (Enter)", System.Drawing.Color.LightGreen, true);
                                    errorForm.TimeOut = 2000;
                                    errorForm.AutoClose = false;
                                    errorForm.ShowDialog();
                                }

                                #endregion

                                #region АНАЛИЗ ОТОБРАЖЕНИЯ ДОПОЛНИТЕЛЬНОГО УВЕДОМЛЕНИЯ

                                var additionalMessage = (string)null;
                                adapter.GetPickSlipAdditionalMessage(this.DocID, ref additionalMessage);
                                if (!string.IsNullOrEmpty(additionalMessage))
                                {
                                    var message = additionalMessage.Trim();
                                    var errorForm = new WMSOffice.Dialogs.PickControl.FullScreenErrorForm(message, "ПРОДОЛЖИТЬ (Enter)", System.Drawing.Color.LightGreen);
                                    errorForm.TimeOut = 2000;
                                    errorForm.AutoClose = false;
                                    errorForm.ShowDialog();
                                }

                                #endregion

                                #region АНАЛИЗ НЕОБХОДИМОСТИ ПРОВЕРКИ СКАНИРОВАНИЕМ ЖЭ И БЭ ДЛЯ СБОРОЧНОГО ТИПА "ВОЛНА"

                                var needVerify = (int?)null;
                                using (var wAdapter = new Data.PickControlTableAdapters.WavePickLabelDetailsTableAdapter())
                                    wAdapter.NeedVerifyLabel(this.DocID, ref needVerify, (int?)null, this.UserID);

                                if (needVerify.HasValue && needVerify.Value.Equals(1))
                                {
                                    var checkForm = new WavePickLabelControlForm() { UserID = this.UserID, PCDocID = this.DocID };
                                    checkForm.ShowDialog();
                                }

                                #endregion

                                #region АНАЛИЗ НЕОБХОДИМОСТИ ПЕЧАТИ НЕДОСТАЮЩИХ БЭ ДЛЯ МДС

                                if (this.IsMDP)
                                {
                                    Data.PickControl.MDS_EticDataTable etics = null;
                                    PickControlItemsPrintEticForm.LoadNotPrintedEtics(this.DocID, out etics);

                                    if (etics != null)
                                    {

                                        var dlgPickControlItemsPrintEtic = new PickControlItemsPrintEticForm(etics)
                                        {
                                            UserID = this.UserID,
                                            DocID = this.DocID,
                                            CommitVersionChanges = this.CommitVersionChanges,
                                            DiscardCanceling = true
                                        };
                                        if (dlgPickControlItemsPrintEtic.ShowDialog(this) == DialogResult.OK)
                                        {

                                        }
                                    }
                                }

                                #endregion

                                #region АНАЛИЗ НЕОБХОДИМОСТИ ВЫБОРА ПРИЧИНЫ РАСХОЖДЕНИЯ В ВЕСОВОМ КОНТРОЛЕ

                                using (var wAdapter = new Data.PickControlTableAdapters.PC_WeightControl_False_ReasonsTableAdapter())
                                    wAdapter.Fill(pickControl.PC_WeightControl_False_Reasons, this.DocID, this.UserID);

                                if (pickControl.PC_WeightControl_False_Reasons.Count > 0)
                                {
                                    var dlgWeightControlSetDifferenceReasons = new WeightControlSetDifferenceReasonsForm() { UserID = this.UserID, DocID = this.DocID, Reasons = pickControl.PC_WeightControl_False_Reasons, DiscardCanceling = true };
                                    if (dlgWeightControlSetDifferenceReasons.ShowDialog() == DialogResult.OK)
                                    {
                                        var reasonID = dlgWeightControlSetDifferenceReasons.ReasonID;
                                        var reasonNote = dlgWeightControlSetDifferenceReasons.ReasonNote;

                                        using (var wAdapter = new Data.PickControlTableAdapters.PC_WeightControl_False_ReasonsTableAdapter())
                                            wAdapter.SaveReason(this.DocID, reasonID, reasonNote, this.UserID);
                                    }
                                }

                                #endregion

                                platzkartBoxes.Clear();

                                if (closeDocActionType != CloseDocActionType.AbortDueToWeightControlDifference)
                                    MessageBox.Show("Документ контроля успешно закрыт!", "Закрытие документа", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                //var sCloseMessage = "Документ контроля успешно закрыт!";
                                //var closeForm = new WMSOffice.Dialogs.PickControl.FullScreenErrorForm(sCloseMessage, "ПРОДОЛЖИТЬ (Enter)", System.Drawing.Color.LightGreen);
                                //closeForm.TimeOut = 1000;
                                //closeForm.AutoClose = false;
                                //closeForm.ShowDialog(); 

                                // закрываем окно
                                allowCloseWindow = true;
                                Close();
                            }
                            catch (Exception ex)
                            {
                                if (ex.Message.Contains("SHOWDIFF"))
                                {
                                    #region ПОДТВЕРЖДЕНИЕ ПОВТОРНОГО ПЕРЕСЧЕТА РУКОВОДИТЕЛЕМ

                                    if (this.CommitVersionChanges)
                                    {
                                        try
                                        {
                                            bool allowRecalc = false;

                                            var needRecalc = (int?)null;
                                            docRowsTableAdapter.NeedConfrirmSecondRecalc(this.UserID, this.DocID, ref needRecalc);

                                            // Нужно подтверждение пересчета
                                            if (needRecalc.HasValue && needRecalc.Value == 1)
                                            {
                                                // Обеспечим повторные действия на случай возникновения сбоев
                                                while (true)
                                                {
                                                    var dlgBossScanner = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                                                    {
                                                        Label = "Отсканируйте бэйдж руководителя,\r\nкоторый отвечает за мониторинг контроля",
                                                        Text = "Проведение повторного контроля",
                                                        Image = Properties.Resources.role,
                                                        //OnlyNumbersInBarcode = true
                                                        UseScanModeOnly = true
                                                    };

                                                    if (dlgBossScanner.ShowDialog() != DialogResult.OK)
                                                        break;

                                                    var bossID = Convert.ToInt32(dlgBossScanner.Barcode);

                                                    var canAccess = (int?)null;
                                                    docRowsTableAdapter.CanConfirmSecondRecalc(bossID, ref canAccess);

                                                    if (canAccess.HasValue && canAccess.Value == 0)
                                                    {
                                                        MessageBox.Show("Пользователь не имеет права\r\nподтверждения повторного пересчета!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                        continue;
                                                    }
                                                    else
                                                    {
                                                        // Повторный пересчет разрешен
                                                        allowRecalc = true;
                                                        break;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                // Повторный пересчет разрешен
                                                allowRecalc = true;
                                            }

                                            // Пересчет запрещен
                                            if (!allowRecalc)
                                                return;
                                        }
                                        catch (Exception exc)
                                        {
                                            this.ShowError(exc);
                                            return;
                                        }
                                    }

                                    #endregion

                                    //#region крысиные бега за 13.05.2010
                                    if (!IsRepeatControl)
                                    {
                                        try
                                        {
                                            platzkartBoxes.Clear();

                                            // ставим документ на 2-й контроль
                                            using (Data.PickControlTableAdapters.CreatedDocsTableAdapter docAdapter = new WMSOffice.Data.PickControlTableAdapters.CreatedDocsTableAdapter())
                                            {
                                                // получаем "шапку" нового документа контроля
                                                Data.PickControl.CreatedDocsDataTable docRepeat = docAdapter.GetRepeatData(UserID, DocID);
                                                if (docRepeat.Count != 1) throw new Exception("Документ повторного контроля (исправлений) не был создан!");
                                                Data.PickControl.CreatedDocsRow row = docRepeat[0];

                                                var innerBoxType = PickControlWindow.InnerBoxType;
                                                var innerEticBarCode = PickControlWindow.InnerEticBarCode;
                                                var innerNeedTareCapFlag = PickControlWindow.InnerNeedTareCapFlag;
                                                var innerActionType = PickControlWindow.InnerActionType;

                                                // показываем модальное окно повторного контроля с исправлениями
                                                PickControlWindow wnd = new PickControlWindow();
                                                wnd.InitDocument(row.Doc_Type_Name, row.Doc_ID, row.Doc_Type, row.Doc_Date, row.Status_ID, row.Status_Name);
                                                wnd.UserID = UserID;

                                                wnd.IsMDP = this.IsMDP;
                                                wnd.IsPlatzkart = this.IsPlatzkart;
                                                wnd.NeedReWeightEveryItem = this.NeedReWeightEveryItem;
                                                wnd.NeedControlInternetOrder = this.NeedControlInternetOrder;

                                                // Инициализация повторного контроля с расхождениями интернет-заказов
                                                if (this.NeedControlInternetOrder)
                                                    wnd.HasDifference = true;

                                                PickControlWindow.InnerBoxType = innerBoxType;
                                                PickControlWindow.InnerEticBarCode = innerEticBarCode;
                                                PickControlWindow.InnerNeedTareCapFlag = innerNeedTareCapFlag;
                                                PickControlWindow.InnerActionType = innerActionType;

                                                //wnd.UserID = ssForm.UserID;
                                                //wnd.IsRepeatControl = !row.IsRelated_Doc_IDNull();
                                                wnd.WindowState = FormWindowState.Maximized;
                                                wnd.ShowDialog();
                                            }

                                            // закрываем окно
                                            allowCloseWindow = true;
                                            Close();
                                        }
                                        catch (Exception ex2)
                                        {
                                            ShowError(ex2);
                                        }

                                        #region повторный переконтроль, либо позовите Старшего смены
                                        /*// показываем, что возникла ошибка!
                                ErrorSSUserForm errForm = new ErrorSSUserForm();
                                DialogResult dlgResult = errForm.ShowDialog();
                                if (dlgResult == DialogResult.Retry)
                                    btnUndoDoc_Click(sender, e);
                                else if (dlgResult == DialogResult.Yes)
                                {
                                    try
                                    {
                                        // функцию контроля выполняем под другой сессией!
                                        ChangeUserForm ssForm = new ChangeUserForm();
                                        if (ssForm.ShowDialog() == DialogResult.OK)
                                        {
                                            // сессия создана, теперь нужно поставить документ на 2-й контроль
                                            using (Data.PickControlTableAdapters.CreatedDocsTableAdapter docAdapter = new WMSOffice.Data.PickControlTableAdapters.CreatedDocsTableAdapter())
                                            {
                                                // получаем "шапку" нового документа контроля, который выполняем в новой сессии
                                                Data.PickControl.CreatedDocsDataTable docRepeat = docAdapter.GetRepeatData(ssForm.UserID, DocID);
                                                if (docRepeat.Count != 1) throw new Exception("Документ повторного контроля (исправлений) не был создан!");
                                                Data.PickControl.CreatedDocsRow row = docRepeat[0];

                                                // показываем модальное окно повторного контроля с исправлениями
                                                PickControlWindow wnd = new PickControlWindow();
                                                wnd.InitDocument(row.Doc_Type_Name, row.Doc_ID, row.Doc_Type,
                                                         row.Doc_Date, row.Status_ID, row.Status_Name);
                                                wnd.UserID = ssForm.UserID;
                                                //wnd.IsRepeatControl = !row.IsRelated_Doc_IDNull();
                                                wnd.WindowState = FormWindowState.Maximized;
                                                wnd.ShowDialog();
                                            }
                                        }

                                        // закрываем окно
                                        allowCloseWindow = true;
                                        Close();
                                    }
                                    catch (Exception ex2)
                                    {
                                        ShowError(ex2);
                                    }
                                }*/
                                        #endregion
                                    }
                                    else
                                    {
                                        try
                                        {
                                            // Исправление сборки / контроля
                                            if (this.IsProcessVersionEquals_2)
                                            {
                                                lockCorrectLines = true;

                                                var dlgCorrectPickErrors = new WMSOffice.Dialogs.PickControl.CorrectPickErrorsForm()
                                                {
                                                    UserID = this.UserID,
                                                    DocID = this.DocID,
                                                    PickSlipNumber = Convert.ToInt32(numPickSlip),
                                                    ProcessVersionID = this.ProcessVersionID
                                                };

                                                var dlgResult = dlgCorrectPickErrors.ShowDialog();
                                                if (dlgResult == DialogResult.OK)
                                                {
                                                    RefreshLines();
                                                    tbBarcode.Focus();

                                                    // При успешной корректировке сборочного отмена контроля становится недоступной
                                                    btnUndoDoc.Enabled = false;
                                                }
                                                else if (dlgResult == DialogResult.Retry)
                                                {
                                                    this.UndoDoc(true);

                                                    var dlgWarning = new FullScreenErrorForm("Передайте сборочный старшему смены для проведения повторного контроля.", "ПРОДОЛЖИТЬ (Enter)", Color.Yellow);
                                                    dlgWarning.TimeOut = 2000;
                                                    dlgWarning.ShowDialog();
                                                }
                                                else
                                                {
                                                    RefreshLines();
                                                    tbBarcode.Focus();
                                                }
                                            }
                                            else
                                            {
                                                #region исправление оишбки путем физического перемещения товара, либо корректировкой сборочного
                                                using (Data.PickControlTableAdapters.DocRowsWithDifferenceTableAdapter diffAdapter = new WMSOffice.Data.PickControlTableAdapters.DocRowsWithDifferenceTableAdapter())
                                                {
                                                    Data.PickControl.DocRowsWithDifferenceDataTable diffTable = diffAdapter.GetData(DocID);
                                                    diffTable.DefaultView.Sort = "Item_Name";

                                                    RepairScanForm rForm = new RepairScanForm();

                                                    rForm.UserID = this.UserID;
                                                    rForm.PickSlipNumber = Convert.ToInt32(numPickSlip);
                                                    rForm.CommitVersionChanges = this.CommitVersionChanges;

                                                    //DialogResult rResult = DialogResult.OK;

                                                    diffTable.DefaultView.RowFilter = "Instruction_ID = 1";
                                                    if (diffTable.DefaultView.Count > 0)
                                                    {
                                                        rForm.DataSource = diffTable.DefaultView;
                                                        rForm.ErrorType = "ИЗЛИШЕК";
                                                        rForm.Instruction = ((Data.PickControl.DocRowsWithDifferenceRow)diffTable.DefaultView[0].Row).Instruction;//"Верните товар в отдел! \r\nСерии и количество указаны в таблице.";
                                                        rForm.CheckBoxText = "Удостоверяю, что товар перемещен в отдел,\r\nпод мою личную ответственность";
                                                        rForm.CheckBoxVisible = true;
                                                        rForm.Show();
                                                        #region автоматически указываем, что излишек по строкам был перемещен в отдел

                                                        foreach (DataRowView drv in diffTable.DefaultView)
                                                        {
                                                            var mdsMessage = (string)null;

                                                            // обновление строк с излишками
                                                            Data.PickControl.DocRowsWithDifferenceRow diffRow = (Data.PickControl.DocRowsWithDifferenceRow)drv.Row;
                                                            docRowsTableAdapter.Insert(DocID, diffRow.Item_ID, diffRow.Vendor_Lot, diffRow.UnitOfMeasure, diffRow.Delta, "R", _ntvFlag, _ntvQuantity, this.ProcessVersionID, ref mdsMessage);

                                                            // UPD: 23.07.2010 Показываем красный экран для каждой (!) строки с излишком
                                                            FullScreenErrorForm errorForm = new FullScreenErrorForm(
                                                                String.Format("Товар {0}\n\rсерии {1}\n\rв количестве {2} {3}\n\rотложите в прозрачный ящик!\n\r(ведется видеонаблюдение)",
                                                                diffRow.Item_Name, diffRow.Vendor_Lot, diffRow.Delta, diffRow.UnitOfMeasure),
                                                                "Товар возвращен в отдел.\n\rПРОДОЛЖИТЬ (Enter)", Color.Red);
                                                            errorForm.TimeOut = 2000;
                                                            errorForm.ShowDialog();
                                                            // UPD: 23.07.2010 специальная просьба "закрывать через желтый экран в 1 сек."
                                                            errorForm.Message =
                                                                String.Format(
                                                                    "Товар {0}\n\r\n\rотмечен как излишек.",
                                                                    diffRow.Item_Name);
                                                            errorForm.ButtonText = "Окно закроется автоматически.\n\r(пожалуйста, подождите...)";
                                                            errorForm.BackgroundColor = Color.Yellow;
                                                            errorForm.TimeOut = 2000;
                                                            errorForm.AutoClose = true;
                                                            errorForm.ShowDialog();
                                                        }

                                                        #endregion
                                                        rForm.Hide();
                                                        rForm.ShowDialog();
                                                    }

                                                    diffTable.DefaultView.RowFilter = "Instruction_ID = 2";
                                                    if (diffTable.DefaultView.Count > 0)
                                                    {
                                                        // UPD: 23.07.2010 специальная просьба "зеленый экран при возникновении события НЕДОСТАЧА"
                                                        FullScreenErrorForm errorForm = new FullScreenErrorForm("Поиск товара\n\rс недостаточным количеством.",
                                                            "Окно закроется автоматически.\n\r(пожалуйста, подождите...)", Color.LightGreen);
                                                        errorForm.TimeOut = 2000;
                                                        errorForm.AutoClose = true;
                                                        errorForm.ShowDialog();

                                                        // показываем окно со списком недостач
                                                        rForm.DataSource = diffTable.DefaultView;
                                                        rForm.ErrorType = "НЕДОСТАЧА";
                                                        rForm.Instruction = ((Data.PickControl.DocRowsWithDifferenceRow)diffTable.DefaultView[0].Row).Instruction;//"Донесите товар из отдела либо откорректируйте сборочный! Серии и количество указаны в таблице. В окне контроля досканируйте товар.";
                                                        //rForm.CheckBoxText = "Удостоверяю, что товар перемещен в отдел,\r\nпод мою личную ответственность";
                                                        rForm.CheckBoxVisible = false;
                                                        rForm.ShowDialog();
                                                    }

                                                    diffTable.DefaultView.RowFilter = "Instruction_ID = 3";
                                                    if (diffTable.DefaultView.Count > 0)
                                                    {
                                                        rForm.DataSource = diffTable.DefaultView;
                                                        rForm.ErrorType = "ПЕРЕСОРТИЦА";
                                                        rForm.Instruction = ((Data.PickControl.DocRowsWithDifferenceRow)diffTable.DefaultView[0].Row).Instruction;//"Обнаружена пересортица!\n\rОбратитесь к оператору и откорректируйте сборочный.";
                                                        rForm.CheckBoxText = "Удостоверяю, что сборочный откорректирован.";
                                                        rForm.CheckBoxVisible = true;
                                                        rForm.ShowDialog();
                                                    }

                                                    lockCorrectLines = true;

                                                    if (this.CommitVersionChanges)
                                                        HideWhiteRows = 1; // скрываем "белые" позиции

                                                    RefreshLines();
                                                    tbBarcode.Focus();

                                                }
                                                #endregion
                                            }
                                        }
                                        catch (Exception ex3)
                                        {
                                            ShowError(ex3);
                                        }
                                    }
                                    //#endregion

                                    //    // показываем расхождения в сборочном и контроле
                                    //    CompareForm form = new CompareForm();
                                    //    form.DocID = this.DocID;
                                    //    form.ShowDialog();

                                    //    // обновляем документ
                                    //    UndoEnabled = false;
                                    //    RefreshLines();
                                }
                                else
                                    ShowError(ex);
                            }
                        }
                    }
            }
        }

        /// <summary>
        /// Проверка того, что контроль можно завершить
        /// </summary>
        /// <returns></returns>
        private bool CheckPickControlCanClose()
        {
            foreach (DataGridViewRow row in gvLines.Rows)
                if (//((DataGridViewDisableButtonCell)row.Cells[colNoItem.Name]).ButtonVisible && colNoItem.Visible &&
                    !lockCorrectLines &&
                    (row.Cells[docQtyDataGridViewTextBoxColumn.Name].Value.Equals((double)0.0f) && !row.Cells[Line_Type_id.Name].Value.Equals(9)))
                    return false;

            return true;
        }

        #region ХОЛОДОВАЯ ЦЕПОЧКА - ПОГРУЗКА ТОВАРА В ТЕРМОБОКСЫ
        /// <summary>
        /// Погрузка термопрепаратов в термобоксы
        /// </summary>
        /// <param name="numPickSlip">Номер сборочного листа</param>
        private void LoadTermoItemsToTermoContainers(double numPickSlip)
        {
            ColdChainPackingTermoBoxesManager packingManager = new ColdChainPackingTermoBoxesManager(numPickSlip) { UserID = this.UserID };
            packingManager.Execute();
        }
        #endregion

        private bool _isRepeatControl = false;
        public bool IsRepeatControl { get { return _isRepeatControl; } set { _isRepeatControl = value; pnlDescription.Visible = value; } }

        /// <summary>
        /// Признак отображения "белых" позиций (0 - видимы, 1 - скрыты)
        /// </summary>
        public int? HideWhiteRows { get; private set; }

        /// <summary>
        /// Признак отображения "зеленых" строк
        /// </summary>
        public int? ShowGreenLines { get; private set; }

        private void btnUndoDoc_Click(object sender, EventArgs e)
        {
            this.UndoDoc(false);
        }

        private void UndoDoc(bool undoForce)
        {
            if (undoForce || MessageBox.Show("Вы действительно хотите закрыть документ контроля с ошибкой?", "Отмена контроля", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                using (Data.PickControlTableAdapters.QueriesTableAdapter adapter = new WMSOffice.Data.PickControlTableAdapters.QueriesTableAdapter())
                {
                    try
                    {
                        // закрываем документ (ошибка)-> <-, иначе -- получим исключение, которое показываем пользователю
                        adapter.CloseDoc(DocID, UserID, 1, this.ProcessVersionID);
                    }
                    catch (Exception ex)
                    {
                        ShowError(ex);
                    }

                    // закрываем окно
                    allowCloseWindow = true;
                    Close();
                }
            }
        }

        private void PickControlWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!allowCloseWindow && (Control.ModifierKeys != Keys.Control))
                {
                    MessageBox.Show("Нельзя закрыть окно документа до завершения процедуры контроля. Пожалуйста, продолжайте работу.\n\rДля закрытия документа контроля воспользуйтесь командой \"Завершить контроль сборочного\".", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Cancel = true;
                }

                if (isBarCodeAcquiringFromTerminalEnabled)
                    tbBarcode.ScannerListener.Stop();
            }
            catch (Exception ex)
            {
                
            }
        }

        private void gvLines_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Bitmap emptyBitmap = new Bitmap(16, 16);
            // разрисовка строк в таблице, если не указана серия
            foreach (DataGridViewRow row in gvLines.Rows)
            {
                Data.PickControl.DocRowsRow diffRow = (Data.PickControl.DocRowsRow)((DataRowView)row.DataBoundItem).Row;
                if (String.IsNullOrEmpty(diffRow.Vendor_Lot))
                {
                    Color backColor = (diffRow.Doc_Qty == 0) ? Color.Red : Color.Yellow;
                    Color foreColor = (diffRow.Doc_Qty == 0) ? Color.Yellow : Color.Red;

                    if (this.CommitVersionChanges)
                    {
                        if (IsRepeatControl)
                        {
                            backColor = (!diffRow.IsQty_ScannedNull() && diffRow.Qty_Scanned > 0) ? Color.Yellow : Color.Red;
                            foreColor = (!diffRow.IsQty_ScannedNull() && diffRow.Qty_Scanned > 0) ? Color.Red : Color.Yellow;
                        }
                    }

                    // строка отличается - подсвечиваем красным
                    for (int c = 0; c < row.Cells.Count; c++)
                        if (row.Cells[c] is DataGridViewDisableButtonCell) { }
                        else
                        {
                            row.Cells[c].Style.BackColor = backColor;
                            row.Cells[c].Style.ForeColor = foreColor;
                            row.Cells[c].Style.SelectionForeColor = backColor;
                        }
                    // прячем вывод кол-ва в информационной строке
                    row.Cells[docQtyDataGridViewTextBoxColumn.Name].Style.ForeColor = backColor;
                    row.Cells[docQtyDataGridViewTextBoxColumn.Name].Style.SelectionForeColor = SystemColors.Highlight;
                } else
                {
                    // простая разрисовка строк (уже не слепой контроль с 12.08.2010)
                    Color backColor = (diffRow.IsColorNull() || diffRow.Color.ToLower() == "white") ? Color.White : Color.FromName(diffRow.Color);
                    for (int c = 0; c < row.Cells.Count; c++)
                        if (row.Cells[c] is DataGridViewDisableButtonCell) { }
                        else
                        {
                            row.Cells[c].Style.BackColor = backColor;
                            row.Cells[c].Style.SelectionForeColor = backColor;
                        }
                }

                ((DataGridViewDisableButtonCell)row.Cells[colNoItem.Name]).ButtonVisible = false;
                if (colNoItem.Visible)
                {
                    if (CommitVersionChanges)
                        ((DataGridViewDisableButtonCell)row.Cells[colNoItem.Name]).ButtonVisible = (diffRow.Doc_Qty == 0 && (!Qty_Scanned.Visible || (Qty_Scanned.Visible && (diffRow.IsQty_ScannedNull() || diffRow.Qty_Scanned == 0))));
                    else
                        ((DataGridViewDisableButtonCell)row.Cells[colNoItem.Name]).ButtonVisible = (String.IsNullOrEmpty(diffRow.Vendor_Lot) && diffRow.Doc_Qty == 0 && (!Qty_Scanned.Visible || (Qty_Scanned.Visible && (diffRow.IsQty_ScannedNull() || diffRow.Qty_Scanned == 0))));

                    if (IsProcessVersionEquals_2 && lockCorrectLines)
                        ((DataGridViewDisableButtonCell)row.Cells[colNoItem.Name]).ButtonVisible = false;

                    if (((DataGridViewDisableButtonCell)row.Cells[colNoItem.Name]).ButtonVisible)
                        ((DataGridViewDisableButtonCell)row.Cells[colNoItem.Name]).Value = "Нет товара";
                }

                #region АНАЛИЗ ОТОБРАЖЕНИЯ ИНФОРМАЦИИ ПРИ РАБОТЕ С КОНТЕЙНЕРАМИ ИЗЛИШКОВ, НТВ

                if (this.IsProcessVersionEquals_2)
                {
                    //if (colNoItem.Visible)
                    //{
                    //    var lineTypeID = diffRow.IsLine_Type_idNull() ? (int?)null : diffRow.Line_Type_id;
                    //    if (this.RowHasProperVarianceType(diffRow))
                    //    {
                    //        var qtyScanned = diffRow.IsQty_ScannedNull() ? 0.0F : diffRow.Qty_Scanned;
                    //        var qtyNeed = diffRow.IsQty_NeedNull() ? 0.0F : diffRow.Qty_Need;
                    //        var needConfirm = Math.Abs(qtyScanned - qtyNeed) > 0;

                    //        if (needConfirm)
                    //        {
                    //            ((DataGridViewDisableButtonCell)row.Cells[colNoItem.Name]).ButtonVisible = true;
                    //            ((DataGridViewDisableButtonCell)row.Cells[colNoItem.Name]).Value = "Подтвердить";
                    //            ((DataGridViewDisableButtonCell)row.Cells[colNoItem.Name]).Tag = lineTypeID.Value;
                    //        }
                    //        else
                    //        {
                    //            ((DataGridViewDisableButtonCell)row.Cells[colNoItem.Name]).ButtonVisible = false;
                    //        }
                    //    }
                    //}
                }

                #endregion

                if (colCollectors.Visible)
                    ((DataGridViewDisableButtonCell)row.Cells[colCollectors.Name]).ButtonVisible = true;

                if (colProperVendorLots.Visible)
                    ((DataGridViewDisableButtonCell)row.Cells[colProperVendorLots.Name]).ButtonVisible = true;

                if (colDocRowDetails.Visible)
                    ((DataGridViewDisableButtonCell)row.Cells[colDocRowDetails.Name]).ButtonVisible = !diffRow.IsPlatzKart_BX_CntNull() && diffRow.PlatzKart_BX_Cnt > 0;

                // отображение иконок термо-режима
                if (diffRow.IsSnowFlakeNull()) row.Cells[colSnowflake.DisplayIndex].Value = emptyBitmap;
                else row.Cells[colSnowflake.DisplayIndex].Value = (diffRow.SnowFlake == "R")
                    ? Properties.Resources.snowflakeR
                    : (diffRow.SnowFlake == "B")
                        ? Properties.Resources.snowflakeB
                        : emptyBitmap;
            }
        }

        /// <summary>
        /// Наличие в строке признака расхождения (НТВ/Излишек)
        /// </summary>
        /// <param name="docRow"></param>
        /// <returns></returns>
        [Obsolete]
        private bool RowHasProperVarianceType(Data.PickControl.DocRowsRow docRow)
        {
            var lineTypeID = docRow.IsLine_Type_idNull() ? (int?)null : docRow.Line_Type_id;
            if (lineTypeID.HasValue)
                return 
                    (surplusContainerDoc != null && lineTypeID.Value == surplusContainerDoc.VarianceTypeID) ||
                    (ntvContainerDoc != null && lineTypeID == ntvContainerDoc.VarianceTypeID);

            return false;
        }

        private void gvLines_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gvLines.Columns[e.ColumnIndex].Name == colNoItem.Name)
                {
                    if (((DataGridViewDisableButtonCell)gvLines[e.ColumnIndex, e.RowIndex]).ButtonVisible)
                    {
                        try
                        {
                            bool needDeleteBlankRows = false;
                            if (this.IsProcessVersionEquals_2)
                            {
                                if (lockCorrectLines)
                                    throw new Exception("Невозможно откорректировать позицию сборочного, т.к. повторный контроль уже завершен.");

                                #region OBSOLETE

                                //if (((DataGridViewDisableButtonCell)gvLines[e.ColumnIndex, e.RowIndex]).Tag != null)
                                //{
                                //    var lineTypeID = Convert.ToInt32(((DataGridViewDisableButtonCell)gvLines[e.ColumnIndex, e.RowIndex]).Tag);

                                //    var needRefresh = false;
                                //    if (this.surplusContainerDoc != null && lineTypeID == this.surplusContainerDoc.VarianceTypeID) // Излишек
                                //    {
                                //        #region ПОДТВЕРЖДЕНИЕ ИЗЛИШКОВ

                                //        if (this.surplusContainerDoc.IsOpened)
                                //        {
                                //            this.surplusContainerDoc.Confirm();
                                //            needRefresh = true;
                                //        }

                                //        #endregion
                                //    }
                                //    else if (this.ntvContainerDoc != null && lineTypeID == this.ntvContainerDoc.VarianceTypeID) // НТВ
                                //    {
                                //        #region ПОДТВЕРЖДЕНИЕ HTB

                                //        if (this.ntvContainerDoc.IsOpened)
                                //        {
                                //            this.ntvContainerDoc.Confirm();
                                //            needRefresh = true;
                                //        }

                                //        #endregion
                                //    }

                                //    if (needRefresh)
                                //        RefreshLines();
                                //}
                                //else
                                //    needDeleteBlankRows = true;

                                #endregion

                                needDeleteBlankRows = true;
                            }
                            else
                                needDeleteBlankRows = true;

                            if (needDeleteBlankRows)
                            {
                                int id = ((Data.PickControl.DocRowsRow)((DataRowView)gvLines.Rows[e.RowIndex].DataBoundItem).Row).Item_ID;
                                docRowsTableAdapter.DeleteBlankRows(DocID, id);
                                RefreshLines();
                            }
                        }
                        catch (Exception ex)
                        {
                            this.ShowError(ex);
                        }
                    }
                }

                if (gvLines.Columns[e.ColumnIndex].Name == colCollectors.Name)
                {
                    if (((DataGridViewDisableButtonCell)gvLines[e.ColumnIndex, e.RowIndex]).ButtonVisible)
                    {
                        try
                        {
                            var br = (gvLines.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.PickControl.DocRowsRow;

                            pickControl.PickSlipItemCollectors.Clear();
                            using (var adapter = new Data.PickControlTableAdapters.PickSlipItemCollectorsTableAdapter())
                                adapter.Fill(pickControl.PickSlipItemCollectors, this.UserID, Convert.ToInt32(numPickSlip), br.Item_ID);

                            if (pickControl.PickSlipItemCollectors.Rows.Count > 0)
                            {
                                var dlgCollectors = new WMSOffice.Dialogs.RichListForm() { Width = 700 };
                                dlgCollectors.Text = string.Format("Список сборщиков по товару ({0}) {1}", br.Item_ID, br.Item_Name);
                                dlgCollectors.AddColumn("employee", "employee", "Ф.И.О. сотрудника");
                                dlgCollectors.AddColumn("location_id", "location_id", "Место сборки");
                                dlgCollectors.ColumnForFilters = new List<string>(new string[] { "employee", "location_id" });
                                dlgCollectors.FilterChangeLevel = 0;

                                pickControl.PickSlipItemCollectors.DefaultView.RowFilter = string.Empty;
                                dlgCollectors.DataSource = pickControl.PickSlipItemCollectors;
                                dlgCollectors.SetDictionaryViewMode();
                                dlgCollectors.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show(string.Format("Список сборщиков по товару ({0}) {1} не найден.", br.Item_ID, br.Item_Name), "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        catch
                        {

                        }
                    }
                }

                if (gvLines.Columns[e.ColumnIndex].Name == colProperVendorLots.Name)
                {
                    if (((DataGridViewDisableButtonCell)gvLines[e.ColumnIndex, e.RowIndex]).ButtonVisible)
                    {
                        try
                        {
                            var br = (gvLines.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.PickControl.DocRowsRow;

                            pickControl.ProperVendorLot.Clear();
                            using (var adapter = new Data.PickControlTableAdapters.ProperVendorLotTableAdapter())
                                adapter.Fill(pickControl.ProperVendorLot, br.Doc_ID, br.Item_ID, br.UnitOfMeasure);

                            if (pickControl.ProperVendorLot.Rows.Count > 0)
                            {
                                var dlgProperVendorLots = new WMSOffice.Dialogs.RichListForm();// { Width = 700 };
                                dlgProperVendorLots.Text = string.Format("Список серий по товару ({0}) {1}", br.Item_ID, br.Item_Name);
                                dlgProperVendorLots.AddColumn("vendor_lot", "vendor_lot", "Серия");
                                dlgProperVendorLots.AddColumn("doc_qty", "doc_qty", "Количество");
                                dlgProperVendorLots.FilterChangeLevel = 0;
                                dlgProperVendorLots.FilterVisible = false;

                                pickControl.ProperVendorLot.DefaultView.RowFilter = string.Empty;
                                dlgProperVendorLots.DataSource = pickControl.ProperVendorLot;
                                dlgProperVendorLots.SetDictionaryViewMode();
                                dlgProperVendorLots.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show(string.Format("Список серий по товару ({0}) {1} не найден.", br.Item_ID, br.Item_Name), "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        catch
                        { 
                        
                        }
                    }
                }

                if (gvLines.Columns[e.ColumnIndex].Name == colDocRowDetails.Name)
                {
                    if (((DataGridViewDisableButtonCell)gvLines[e.ColumnIndex, e.RowIndex]).ButtonVisible)
                    {
                        try
                        {
                            var br = (gvLines.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.PickControl.DocRowsRow;

                            pickControl.DocRowDetails.Clear();
                            using (var adapter = new Data.PickControlTableAdapters.DocRowDetailsTableAdapter())
                                adapter.Fill(pickControl.DocRowDetails, br.Doc_ID, br.Item_ID, br.UnitOfMeasure);

                            if (pickControl.DocRowDetails.Rows.Count > 0)
                            {
                                var dlgDocRowDetails = new WMSOffice.Dialogs.RichListForm();// { Width = 700 };
                                dlgDocRowDetails.Text = string.Format("Детали сортировки товара ({0}) {1}", br.Item_ID, br.Item_Name);
                                dlgDocRowDetails.AddColumn("box_no", "box_no", "№ ящика");
                                //dlgDocRowDetails.AddColumn("item_id", "item_id", "Код");
                                //dlgDocRowDetails.AddColumn("item_name", "item_name", "Наименование");
                                dlgDocRowDetails.AddColumn("vendor_lot", "vendor_lot", "Серия");
                                //dlgDocRowDetails.AddColumn("uom", "uom", "ЕИ");
                                dlgDocRowDetails.AddColumn("plan_qty", "plan_qty", "Потребность");
                                dlgDocRowDetails.AddColumn("fact_qty", "fact_qty", "В ящике");
                                dlgDocRowDetails.FilterChangeLevel = 0;
                                dlgDocRowDetails.FilterVisible = false;

                                pickControl.DocRowDetails.DefaultView.RowFilter = string.Empty;
                                dlgDocRowDetails.DataSource = pickControl.DocRowDetails;
                                dlgDocRowDetails.SetDictionaryViewMode();
                                dlgDocRowDetails.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show(string.Format("Детали сортировки товара ({0}) {1} не найдены.", br.Item_ID, br.Item_Name), "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        catch
                        {

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void gvLines_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private PrintLotnBarcodeForm printLabelForm;
        private void miPrintYellowEtic_Click(object sender, EventArgs e)
        {
            if (printLabelForm == null)
                printLabelForm = new PrintLotnBarcodeForm();
            printLabelForm.UserID = UserID;
            printLabelForm.Location = "IB";
            printLabelForm.ReceiptMode = LotnReceiptMode.PrintYL;
            printLabelForm.ShowDialog();
        }

        #region КОРРЕКТИРОВКА ПОЗИЦИИ КОНТРОЛЯ

        /// <summary>
        /// Замена серии
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="vendorLot"></param>
        /// <param name="uom"></param>
        private bool ChangeItemVendorLot(Data.PickControl.DocRowsRow docRow)
        {
            if (!this.CommitVersionChanges)
                return false;

            // запрет замены серии на повторном контроле
            if (IsRepeatControl)
                return false;

            if (this.IsPlatzkart)
                return false;

            if (this.NeedReWeightEveryItem)
                return false;

            try
            {
                // Признак смены серии
                bool changeVendorLot = false;

                using (var adapter = new WMSOffice.Data.PickControlTableAdapters.VendorLotsTableAdapter())
                    adapter.Fill(pickControl.VendorLots, DocID, docRow.Item_ID, string.Empty, surplusMode, archiveMode, this.ProcessVersionID);

                if (pickControl.VendorLots == null || pickControl.VendorLots.Count < 1)
                {
                    throw new Exception("Серии не найдены! Это исключительная ситуация. Обратитесь в Группу сопровождения ПО.");
                }
                else if (pickControl.VendorLots.Count == 1)
                {
                    // контроль серий отключен
                    if (pickControl.VendorLots[0].Vendor_Lot == "NOSER")
                    {
                        _vendorLot = pickControl.VendorLots[0].Vendor_Lot;
                        changeVendorLot = true;
                    }
                    else
                    {
                        #region ПРИСВОЕНИЕ СЕРИИ ВРУЧНУЮ

                        SetVendorLotnForm form = new SetVendorLotnForm();
                        form.Text = "Присвоение серии " + _itemName;
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            if (form.Lotn != docRow.Vendor_Lot)
                            {
                                _vendorLot = form.Lotn;
                                changeVendorLot = true;
                            }
                        }

                        #endregion
                    }
                }
                else
                {
                    #region ПОДГОТОВКА СЕРИЙ К ОТОБРАЖЕНИЮ

                    // удалим строки, которые не нужно отображать
                    var lstRowsToRemove = new List<Data.PickControl.VendorLotsRow>();
                    foreach (Data.PickControl.VendorLotsRow dr in pickControl.VendorLots.Rows)
                        if (!dr.IsHideNull() && dr.Hide)
                            lstRowsToRemove.Add(dr);

                    for (int i = 0; i < lstRowsToRemove.Count; i++)
                        pickControl.VendorLots.Rows.Remove(lstRowsToRemove[i]);

                    #endregion

                    // есть несколько серий, предлагаем пользователю выбрать
                    formSeries = new RichListForm() { Width = 600 };
                    #region column Lotn
                    DataGridViewTextBoxColumn colLot = new DataGridViewTextBoxColumn();
                    colLot.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                    colLot.DataPropertyName = "Vendor_Lot";
                    colLot.HeaderText = "Серия";
                    colLot.Name = "colLot";
                    colLot.ReadOnly = true;
                    formSeries.Columns.Add(colLot);
                    #endregion
                    #region column Date
                    DataGridViewTextBoxColumn colDate = new DataGridViewTextBoxColumn();
                    colDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                    colDate.DataPropertyName = "Exp_Date";
                    colDate.HeaderText = "Срок годн.";
                    colDate.Name = "colDate";
                    colDate.ReadOnly = true;
                    formSeries.Columns.Add(colDate);
                    #endregion
                    #region column Collectors_remains
                    DataGridViewTextBoxColumn colCollectorsRemains = new DataGridViewTextBoxColumn();
                    colCollectorsRemains.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                    colCollectorsRemains.DataPropertyName = "Collectors_remains";
                    colCollectorsRemains.HeaderText = "Остаток, уп.";
                    colCollectorsRemains.Name = "colCollectorsRemains";
                    colCollectorsRemains.ReadOnly = true;
                    formSeries.Columns.Add(colCollectorsRemains);
                    #endregion

                    formSeries.ColumnForFilters.Add("Vendor_Lot");
                    formSeries.FilterChangeLevel = 2;
                    //formSeries.FilterChanged += new EventHandler(formSeries_FilterChanged);

                    formSeries.Text = "Выбор серии " + docRow.Item_Name;
                    formSeries.DataSource = pickControl.VendorLots;

                    if (formSeries.ShowDialog() == DialogResult.OK)
                    {
                        if (formSeries.SelectedRow != null)
                        {
                            Data.PickControl.VendorLotsRow row = (Data.PickControl.VendorLotsRow)formSeries.SelectedRow;
                            if (row.Vendor_Lot != docRow.Vendor_Lot)
                            {
                                if (row.Vendor_Lot == "Ввести серию вручную...")
                                {
                                    #region ПРИСВОЕНИЕ СЕРИИ ВРУЧНУЮ

                                    SetVendorLotnForm form = new SetVendorLotnForm();
                                    form.Text = "Присвоение серии " + _itemName;
                                    if (form.ShowDialog() == DialogResult.OK)
                                    {
                                        if (form.Lotn != docRow.Vendor_Lot)
                                        {
                                            _vendorLot = form.Lotn;
                                            changeVendorLot = true;
                                        }
                                    }

                                    #endregion
                                }
                                else
                                {
                                    _vendorLot = row.Vendor_Lot;
                                    changeVendorLot = true;
                                }
                            }
                        }
                    }
                }

                // Замена серии
                if (changeVendorLot)
                {
                    // запоминаем параметры поиска строки
                    var item_ID = docRow.Item_ID;
                    var unitOfMeasure = docRow.UnitOfMeasure;

                    // запоминаем количество в исходной позиции
                    _count = (int)docRow.Doc_Qty;

                    docRowsTableAdapter.UpdateDocRow(this.DocID, docRow.Line_ID, _vendorLot);

                    RefreshLines(); 

                    // восстанавливаем в строке параметра поиска
                    docRow.Vendor_Lot = _vendorLot;
                    docRow.Item_ID = item_ID;
                    docRow.UnitOfMeasure = unitOfMeasure;
                    
                    SelectRow(ref docRow);

                    // При замене серии предлагаем указать новое количество
                    this.ChangeItemQuantity(docRow, true);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
                return false;
            }
        }

        /// <summary>
        /// Замена количества
        /// </summary>
        /// <param name="ItemID"></param>
        /// <param name="vendorLot"></param>
        /// <param name="uom"></param>
        private bool ChangeItemQuantity(Data.PickControl.DocRowsRow docRow, bool changeVendorLot)
        {
            if (!this.CommitVersionChanges)
                return false;

            // запрет замены количества на повторном контроле
            if (IsRepeatControl)
                return false;

            if (this.IsPlatzkart)
                return false;

            if (this.NeedReWeightEveryItem)
                return false;

            try
            {
                if (String.IsNullOrEmpty(docRow.Vendor_Lot))
                    return false;

                _itemCode = docRow.Item_ID;
                _itemName = docRow.Item_Name;
                _vendorLot = docRow.Vendor_Lot;
                _itemUOM = docRow.UnitOfMeasure;
                _scanType = "B";

                if (!changeVendorLot)
                    _count = (int)docRow.Doc_Qty;

                SetCountForm form = new SetCountForm();
                form.ItemID = _itemCode;
                form.ItemName = _itemName;
                form.Lotn = _vendorLot;
                form.TotalCount = (int)docRow.Doc_Qty;
                form.Count = _count;
                form.InputCountEnabled = true;
                form.ShowNote = false;
                form.MinCount = 1;
                form.CommitVersionChanges = this.CommitVersionChanges;

                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Если количество было изменено
                    if (changeVendorLot || form.Count != _count)
                    {
                        // Выравняем количество относительно вводимого (версия без удаления позиции)
                        var formCount = form.Count > form.MinCount.Value ? form.Count : form.MinCount.Value; 
                        
                        _count = changeVendorLot ? formCount - 1 : formCount - _count;

                        //// Удаление позиции
                        //DeleteItem(docRow);

                        // Добавление позиции с необходимым количеством
                        AddRow();

                        //// Обновим позиции
                        //RefreshLines();

                        //// TODO Продумать механизм отката (пока не реализован)
                        //UndoEnabled = false;

                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
                return false;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                if (gvLines.SelectedRows.Count > 0)
                {
                    var docRow = (gvLines.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.PickControl.DocRowsRow;
                    this.ChangeItemVendorLot(docRow);
                    return true;
                }
            }

            if (keyData == (Keys.Control | Keys.Q))
            {
                if (gvLines.SelectedRows.Count > 0)
                {
                    var docRow = (gvLines.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.PickControl.DocRowsRow;

                    this.ChangeItemQuantity(docRow, false);
                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void gvLines_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var docRow = (gvLines.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.PickControl.DocRowsRow;

            if (gvLines.Columns[e.ColumnIndex].DataPropertyName == pickControl.DocRows.Vendor_LotColumn.Caption)
            {
                this.ChangeItemVendorLot(docRow);
                return;
            }

            if (gvLines.Columns[e.ColumnIndex].DataPropertyName == pickControl.DocRows.Doc_QtyColumn.Caption)
            {
                this.ChangeItemQuantity(docRow, false);
                return;
            }
        }

        private void gvLines_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            // Запрет удаления позиции контроля
            e.Cancel = true;
            return;

            #region OBSOLETE

            //if (!this.CommitVersionChanges)
            //{
            //    e.Cancel = true;
            //    return;
            //}

            //var docRow = (e.Row.DataBoundItem as DataRowView).Row as Data.PickControl.DocRowsRow;
            //if (MessageBox.Show(string.Format("Вы уверены что хотите удалить позицию\r\n\r\nКод: {0}\r\nНаименование: {1}\r\nСерия: {2}\r\nКоличество: {3}\r\n\r\n???",
            //                        docRow.Item_ID,
            //                        docRow.IsItem_NameNull() ? string.Empty : docRow.Item_Name.Trim(),
            //                        docRow.Vendor_Lot.Trim(),
            //                        docRow.IsDoc_QtyNull() ? 0 : docRow.Doc_Qty), "Удаление позиции", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
            //{
            //    e.Cancel = true;
            //    return;
            //}

            //// Удаление позиции контроля
            //if (!this.DeleteItem(docRow))
            //    e.Cancel = true;

            #endregion
        }

        private void gvLines_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            RefreshLines();
            tbBarcode.Focus();
        }

        /// <summary>
        /// Удаление позиции
        /// </summary>
        /// <returns></returns>
        private bool DeleteItem(Data.PickControl.DocRowsRow docRow)
        {
            try
            {
                docRowsTableAdapter.DeleteDocRow(this.DocID, docRow.Line_ID);
                return true;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
                return false;
            }
        }
        
        #endregion

        #region РАБОТА С КОНТЕЙНЕРАМИ ДЛЯ ОТБОРА РЕКЛАМАЦИЙ

        #region КОНТЕЙНЕРЫ ДЛЯ ИЗЛИШКОВ

        private void btnSurplusContainerActions_ButtonClick(object sender, EventArgs e)
        {
            btnSurplusContainerActions.ShowDropDown();
        }

        private void miOpenSurplusContainer_Click(object sender, EventArgs e)
        {
            try
            {
                if (surplusContainerDoc.IsOpened)
                    surplusContainerDoc.Preview((long?)null);
                else
                    surplusContainerDoc.Open();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void sbPreviewPickControlSurplus_Click(object sender, EventArgs e)
        {
            surplusContainerDoc.Preview(this.DocID);
        }

        private void miCloseSurplusContainer_Click(object sender, EventArgs e)
        {
            try
            {
                if (surplusContainerDoc.Close())
                {
                    if (!this.IsRepeatControl)
                    {
                        if (ntvContainerDoc.DocID.HasValue)
                        {
                            btnSurplusContainerActions.Visible = false;
                            lblSurplusContainerNumber.Visible = false;
                            toolStripSeparator3.Visible = false;
                        }
                        else
                        {
                            tsContainers.Visible = false;
                        }
                    }

                    //if (!this.IsRepeatControl && !ntvContainerDoc.DocID.HasValue)
                    //    tsContainers.Visible = false;
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        #endregion

        #region КОНТЕЙНЕРЫ ДЛЯ НТВ

        private void btnNTVContainerActions_ButtonClick(object sender, EventArgs e)
        {
            btnNTVContainerActions.ShowDropDown();
        }

        private void miOpenNTVContainer_Click(object sender, EventArgs e)
        {
            try
            {
                if (ntvContainerDoc.IsOpened)
                    ntvContainerDoc.Preview((long?)null);
                else
                    ntvContainerDoc.Open();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void sbPreviewPickControlNTV_Click(object sender, EventArgs e)
        {
            ntvContainerDoc.Preview(this.DocID);
        }

        private void miCloseNTVContainer_Click(object sender, EventArgs e)
        {
            try
            {
                if (ntvContainerDoc.Close())
                {
                    if (!this.IsRepeatControl)
                    {
                        if (surplusContainerDoc.DocID.HasValue)
                        {
                            btnNTVContainerActions.Visible = false;
                            lblNTVContainerNumber.Visible = false;
                            toolStripSeparator4.Visible = false;
                        }
                        else
                        {
                            tsContainers.Visible = false;
                        }
                    }

                    //if (!this.IsRepeatControl && !surplusContainerDoc.DocID.HasValue)
                    //    tsContainers.Visible = false;
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        #endregion

        private void btnSelectNextBox_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.IsRepeatControl && this.IsPlatzkart && btnCloseDoc.Enabled && MessageBox.Show("Достигнут ПОСЛЕДНИЙ ящик!\r\nВы желаете перейти к ПЕРВОМУ ящику?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                    return;

                var needNextBox = (bool?)null;
                using (var adapter = new Data.PickControlTableAdapters.QueriesTableAdapter())
                    adapter.PlatzkartCheckNextBox(this.DocID, ref needNextBox);

                this.RefreshHeader();

                this.RefreshLines();

                var selectNextBoxEnabled = (needNextBox ?? false) == true;

                //btnSelectNextBox.Enabled = miSelectNextBox.Enabled = selectNextBoxEnabled;
                btnSelectNextBox.Enabled = true;
                
                btnCloseDoc.Enabled = miCloseDoc.Enabled = !selectNextBoxEnabled;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        #endregion

        bool isBarCodeAcquiringFromTerminalEnabled = false;
        private void btnEnableAcquireBarCodeFromTerminal_Click(object sender, EventArgs e)
        {
            tbBarcode.Text = "";

            isBarCodeAcquiringFromTerminalEnabled = !isBarCodeAcquiringFromTerminalEnabled;
            btnEnableAcquireBarCodeFromTerminal.BackColor = isBarCodeAcquiringFromTerminalEnabled ? Color.LightSkyBlue : SystemColors.Control;

            tbBarcode.ScannerListener = isBarCodeAcquiringFromTerminalEnabled ? new PickControlScannerListener(DocID) : null;

            if (isBarCodeAcquiringFromTerminalEnabled)
                tbBarcode.ScannerListener.Start();

            tbBarcode.Focus();
        }

        private class PickControlScannerListener : ScannerListenerBase
        {
            public PickControlScannerListener(long docID)
                : base(docID)
            {

            }

            protected override bool Execute()
            {
                try
                {
                    var retData = new Data.PickControl.PickControlDocBarCodeEmulationDataTable();
                    using (var adapter = new Data.PickControlTableAdapters.PickControlDocBarCodeEmulationTableAdapter())
                        adapter.Fill(retData, _docID);

                    if (retData != null && retData.Count > 0)
                    {
                        var barCode = retData[0].BAR_Code;
                        RaiseAquireBarCode(barCode);

                        return true;
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


        bool isNTVRegisterModeEnabled = false;
        private void btnEnableNTVRegisterMode_Click(object sender, EventArgs e)
        {
            isNTVRegisterModeEnabled = !isNTVRegisterModeEnabled;
            btnEnableNTVRegisterMode.BackColor = isNTVRegisterModeEnabled ? Color.LightSkyBlue : SystemColors.Control;
        }
    }

    public class DataGridViewDisableButtonColumn : DataGridViewButtonColumn
    {
        public DataGridViewDisableButtonColumn()
        {
            this.CellTemplate = new DataGridViewDisableButtonCell();
        }
    }

    public class DataGridViewDisableButtonCell : DataGridViewButtonCell
    {
        private bool enabledValue;
        public bool Enabled
        {
            get
            {
                return enabledValue;
            }
            set
            {
                enabledValue = value;
            }
        }

        private bool visibleValue;
        public bool ButtonVisible
        {
            get
            {
                return visibleValue;
            }
            set
            {
                visibleValue = value;
            }
        }

        // Override the Clone method so that the Enabled property is copied.
        public override object Clone()
        {
            DataGridViewDisableButtonCell cell =
                (DataGridViewDisableButtonCell)base.Clone();
            cell.Enabled = this.Enabled;
            cell.ButtonVisible = this.ButtonVisible;
            return cell;
        }

        // By default, enable the button cell.
        public DataGridViewDisableButtonCell()
        {
            this.enabledValue = true;
            this.visibleValue = true;
        }

        protected override void Paint(Graphics graphics,
            Rectangle clipBounds, Rectangle cellBounds, int rowIndex,
            DataGridViewElementStates elementState, object value,
            object formattedValue, string errorText,
            DataGridViewCellStyle cellStyle,
            DataGridViewAdvancedBorderStyle advancedBorderStyle,
            DataGridViewPaintParts paintParts)
        {
            if (this.ButtonVisible)
            {
                // The button cell is disabled, so paint the border,  
                // background, and disabled button for the cell.
                if (!this.enabledValue)
                {
                    // Draw the cell background, if specified.
                    if ((paintParts & DataGridViewPaintParts.Background) ==
                        DataGridViewPaintParts.Background)
                    {
                        SolidBrush cellBackground =
                            new SolidBrush(cellStyle.BackColor);
                        graphics.FillRectangle(cellBackground, cellBounds);
                        cellBackground.Dispose();
                    }

                    // Draw the cell borders, if specified.
                    if ((paintParts & DataGridViewPaintParts.Border) ==
                        DataGridViewPaintParts.Border)
                    {
                        PaintBorder(graphics, clipBounds, cellBounds, cellStyle,
                            advancedBorderStyle);
                    }

                    // Calculate the area in which to draw the button.
                    Rectangle buttonArea = cellBounds;
                    Rectangle buttonAdjustment =
                        this.BorderWidths(advancedBorderStyle);
                    buttonArea.X += buttonAdjustment.X;
                    buttonArea.Y += buttonAdjustment.Y;
                    buttonArea.Height -= buttonAdjustment.Height;
                    buttonArea.Width -= buttonAdjustment.Width;

                    // Draw the disabled button.                
                    ButtonRenderer.DrawButton(graphics, buttonArea,
                        PushButtonState.Disabled);

                    // Draw the disabled button text. 
                    if (this.FormattedValue is String)
                    {
                        TextRenderer.DrawText(graphics,
                            (string)this.FormattedValue,
                            this.DataGridView.Font,
                            buttonArea, SystemColors.GrayText);
                    }
                }
                else
                {
                    // The button cell is enabled, so let the base class 
                    // handle the painting.
                    base.Paint(graphics, clipBounds, cellBounds, rowIndex,
                        elementState, value, formattedValue, errorText,
                        cellStyle, advancedBorderStyle, paintParts);
                }
            }
            else
            {
                if ((paintParts & DataGridViewPaintParts.Background) == DataGridViewPaintParts.Background)
                {
                    SolidBrush cellBackground =
                        new SolidBrush(SystemColors.ControlDark);//cellStyle.BackColor);
                    graphics.FillRectangle(cellBackground, cellBounds);
                    cellBackground.Dispose();
                }

                // Draw the cell borders, if specified.
                if ((paintParts & DataGridViewPaintParts.Border) ==
                    DataGridViewPaintParts.Border)
                {
                    PaintBorder(graphics, clipBounds, cellBounds, cellStyle,
                        advancedBorderStyle);
                }
            }
        }
    }

    /// <summary>
    /// Тип действия при закрытии документа
    /// </summary>
    public enum CloseDocActionType
    {
        /// <summary>
        /// Выбор пластикового ящика
        /// </summary>
        ChoicePlasticBox = 1,

        /// <summary>
        /// Закрытие по умолчанию
        /// </summary>
        Default = 2,

        /// <summary>
        /// Выбор и печать кол-ва этикеток
        /// </summary>
        PrintEticCount = 3,

        /// <summary>
        /// Прервать в связи с расхождениями в весовом контроле
        /// </summary>
        AbortDueToWeightControlDifference = 4
    }
}
