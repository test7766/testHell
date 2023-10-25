using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls;
using WMSOffice.Controls.Receive.Measurement;
using WMSOffice.Dialogs.PickControl;
using WMSOffice.Classes;
using WMSOffice.Dialogs.Receive;

namespace WMSOffice.Window
{
    public partial class ReWeightPickSlipWindow : GeneralWindow
    {
        public bool Terminate { get; private set; }

        private ReWeightDocItem docItem = null;

        private const int MIN_UNIT_WEIGHING_COUNT = 1; // мин. кол-во попыток взвешивания для определения веса упаковки
        private const int MAX_UNIT_WEIGHING_COUNT = 3; // макс. кол-во попыток взвешивания для определения веса упаковки
        
        public ReWeightPickSlipWindow()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Initialize();
        }

        private void Initialize()
        {
            if (!this.CheckPickSlip())
            {
                allowCloseWindow = true;
                this.Terminate = true;
                this.Close();
                return;
            }

            stbItemID.ValueReferenceQuery = "[dbo].[pr_Reweight_Get_Item_List]";
            stbItemID.UserID = this.UserID;
            stbItemID.OnVerifyValue += this.OnVerifyValue;
            stbItemID.Enter += new EventHandler(stbItemID_Enter);
            
            tbsItemBarcode.TextChanged += new EventHandler(tbsItemBarcode_TextChanged);
        }

        void stbItemID_Enter(object sender, EventArgs e)
        {
            stbItemID.ApplyAdditionalParameter(tbsItemBarcode.Name, tbsItemBarcode.Text);
        }

        private void OnVerifyValue(object sender, WMSOffice.Controls.VerifyValueArgs e)
        {
            var control = sender as SearchTextBox;

            if (e.Success)
                control.Value = e.Value;

            if (control == stbItemID)
            {
                if (e.Success)
                {
                    //lblItemIDValue.Text = string.IsNullOrEmpty(e.Value) ? "-" : e.Value;
                    lblItemNameValue.Text = string.IsNullOrEmpty(e.Value) ? string.Empty : (string.IsNullOrEmpty(e.Description) ? "-" : e.Description);
                    lblItemNameValue.ForeColor = SystemColors.ControlText;

                    if (!string.IsNullOrEmpty(e.Value))
                    {
                        var itemID = -1;

                        try
                        {
                            // получение кода товара
                            itemID = Convert.ToInt32(e.Value);

                            // очистка предыдущих результатов
                            docItem.Clear();

                            // проверка наличия товара
                            docItem.CheckItem(itemID);

                            // инициализация работы с товаром
                            var gridRow = this.FindDocItemGridRow(itemID);
                            this.SelectItem(gridRow);

                            // ввод количества
                            this.SetItemQuantity();

                            // взвешивание строки
                            this.ObtainLineWeight();

                            // взвешивание упаковки
                            this.ObtainUnitWeight();

                            // установка признака наличия инструкции
                            this.ObtainInstructionFlag();

                            // сохранение изменений
                            docItem.UpdateItem();
                        }
                        catch (Exception ex)
                        {
                            var errorMessage = ex.Message;
                            var throwException = false;

                            if (errorMessage.Contains("#"))
                            {
                                var regex = new System.Text.RegularExpressions.Regex(@"^#(?<Action>\w+)#(?<Message>.+)#$", System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Singleline);
                                if (regex.IsMatch(errorMessage))
                                {
                                    var match = regex.Match(ex.Message);
                                    var action = match.Groups["Action"].Value;
                                    var message = match.Groups["Message"].Value;

                                    // фиксация излишка
                                    if (action.Equals("ADD_ITEM_MANUALLY"))
                                    {
                                        if (MessageBox.Show(message, "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                                        {
                                            // добавление позиции в документ
                                            docItem.AddItem(itemID);

                                            // перечитка списка товара
                                            RefreshDocItems();

                                            // обработка добавленной позиции
                                            OnVerifyValue(stbItemID, new VerifyValueArgs(e.OwnedRow));

                                            return;
                                        }
                                        else
                                        {
                                            errorMessage = message.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)[0];
                                            throwException = true;
                                        }
                                    }
                                }
                                else
                                    throwException = true;
                            }
                            else
                                throwException = true;

                            if (throwException)
                                this.ShowError(errorMessage);
                        }
                        finally
                        {
                            stbItemID.Value = string.Empty;
                            tbsItemBarcode.Text = string.Empty;
                            tbsItemBarcode.Focus();
                        }
                    }
                }
                else
                {
                    lblItemNameValue.Text = "ЗНАЧЕНИЕ НЕ НАЙДЕНО!";
                    lblItemNameValue.ForeColor = Color.Red;

                    this.ShowError("Товар не найден в справочнике.");

                    stbItemID.Value = string.Empty;
                    tbsItemBarcode.Focus();
                    tbsItemBarcode.SelectAll();
                }
            }
        }

        void tbsItemBarcode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbsItemBarcode.Text))
            {
                stbItemID.ApplyAdditionalParameter(tbsItemBarcode.Name, tbsItemBarcode.Text);
                stbItemID.VerifyValue(true, AutoSelectItemSideMode.None);
            }
        }

        /// <summary>
        /// Взятие сборочного в работу
        /// </summary>
        /// <returns></returns>
        private bool CheckPickSlip()
        {
            var boxBarcode = string.Empty;
            while (true) // многократное сканирование
            {
                try
                {
                    var dlgScanBox = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                    {
                        Label = "Отсканируйте ящик, который содержит сборочный для перевзвешивания.",
                        Text = "Перевзвешивание сборочного",
                        Image = Properties.Resources.paper_box
                    };

                    dlgScanBox.Barcode = boxBarcode;
                    if (dlgScanBox.ShowDialog() == DialogResult.OK)
                    {
                        boxBarcode = dlgScanBox.Barcode;

                        var docID = (long?)null;
                        var emptyContainerWeightPlan = (double?)null;
                        var fullContainerWeightPlan = (double?)null;
                        using (var adapter = new Data.ReceiveTableAdapters.ReWeightPickControlDocItemsTableAdapter())
                            adapter.CreateDoc(boxBarcode, Convert.ToInt32(this.UserID), "RC", ref docID, ref emptyContainerWeightPlan, ref fullContainerWeightPlan);

                        if (docID.HasValue)
                            this.DocID = docID.Value;
                        else
                            throw new Exception("Документ перевзвешивания сборочного не удалось создать.");

                        docItem = new ReWeightDocItem(this.DocID);

                        this.InitDocument(this.DocName, this.DocID, "RC", DateTime.Now, "", "");

                        // перечитка списка товара
                        this.RefreshDocItems();

                        // инициализация предыдущего веса ящика
                        lblEmptyContainerPlanWeightValue.Text = emptyContainerWeightPlan.HasValue ? emptyContainerWeightPlan.Value.ToString("f2") : "-";
                        lblFullContainerPlanWeightValue.Text = fullContainerWeightPlan.HasValue ? fullContainerWeightPlan.Value.ToString("f2") : "-";

                        // взвешивание полного ящика
                        this.ObtainFullContainerWeight();

                        // фиксация результатов взвешивания полного ящика
                        var fullContainerWeightFact = docItem.WeightFullContainer;
                        lblFullContainerFactWeightValue.Text = fullContainerWeightFact.HasValue ? fullContainerWeightFact.Value.ToString("f2") : "-";

                        // завершение обработки позиции
                        docItem.OnCompleteItem += (s, e) => 
                        {
                            try
                            {
                                // перечитка списка товара
                                this.RefreshDocItems();

                                // навигация на только что обработанный товар
                                var gridRow = this.FindDocItemGridRow(docItem.ItemMeasurement.ItemID.Value);
                                this.SelectItem(gridRow);

                                // возможность закрытия документа
                                var canCloseDoc = docItem.CanCloseDoc();

                                // документ можно закрыть
                                if (canCloseDoc && MessageBox.Show("Обработка документа завершена.\r\nВы подтверждаете?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                                {
                                    // взвешивание пустого ящика
                                    this.ObtainEmptyContainerWeight();

                                    // фиксация результатов взвешивания пустого ящика
                                    var emptyContainerWeightFact = docItem.WeightEmptyContainer;
                                    lblEmptyContainerFactWeightValue.Text = emptyContainerWeightFact.HasValue ? emptyContainerWeightFact.Value.ToString("f2") : "-";

                                    // нормальное завершение работы с документом
                                    this.CloseDoc(false);
                                }
                            }
                            catch (Exception ex)
                            {
                                this.ShowError(ex);
                            }
                        };

                        return true;
                    }
                    else
                        break;
                }
                catch (Exception ex)
                {
                    this.ShowError(ex);
                }
            }

            return false;
        }

        /// <summary>
        /// Ввод заявленного к-ва
        /// </summary>
        /// <param name="itemMeasurement"></param>
        /// <returns></returns>
        private bool SetItemQuantity()
        {
            var success = false;
            var itemMeasurement = docItem.ItemMeasurement;

            SetCountForm form = new SetCountForm();
            form.Width = 350;
            form.ItemID = itemMeasurement.ItemID.Value;
            form.ItemName = itemMeasurement.ItemName;
            form.Lotn = string.Empty;
            form.TotalCount = docItem.QuantityPlan ?? 0;
            form.Count = 1;
            form.MinCount = 1;
            form.InputCountEnabled = true;
            form.ShowNote = false;
            form.CommitVersionChanges = true;
            form.CheckQuantity = true;

            if (form.ShowDialog() == DialogResult.OK)
            {
                docItem.QuantityFact = form.Count;
                success = true;
            }
            else
            {
                throw new Exception("Обработка позиции была прервана.");
            }

            return success;
        }

        delegate void UpdateWeightHandler(double? weight);

        /// <summary>
        /// Вывод полноэкранного сообщения
        /// </summary>
        /// <param name="message"></param>
        private void ShowFullScreenMessage(string message)
        {
            var msgForm = new WMSOffice.Dialogs.PickControl.FullScreenErrorForm(message, "ПРОДОЛЖИТЬ (Enter)", System.Drawing.Color.Yellow);
            msgForm.TimeOut = 500;
            msgForm.AutoClose = false;
            msgForm.ShowDialog();
        }

        /// <summary>
        /// Вес полного контейнера
        /// </summary>
        private bool ObtainFullContainerWeight()
        {
            bool success = false;
            this.ShowFullScreenMessage("Поставьте на весы полный ящик.");
            while (true)
            {
                var failure = !this.ObtainSingleWeight(Optima.Devices.Data.DigitalWeigher.DataManager.DWType.Static, (w) => { var pi = docItem.GetType().GetProperty("WeightFullContainer"); pi.SetValue(docItem, w, pi.GetIndexParameters()); });
                if (failure)
                {
                    if (MessageBox.Show("Вес не был получен.\r\nВы желаете повторить взвешивание полного ящика?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        continue;
                    }
                    else
                    {
                        MessageBox.Show("Отменить операцию невозможно.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        continue;

                        //throw new Exception("Обработка была прервана.");
                        //break;
                    }
                }
                else
                {
                    success = true;
                    break;
                }
            }

            return success;
        }

        /// <summary>
        /// Получение веса строки
        /// </summary>
        private bool ObtainLineWeight()
        {
            // вес строки при общем количестве 3 уп. будет получен на первой итерации многократного взвешивания
            var quantity = docItem.QuantityFact;
            if (quantity == MAX_UNIT_WEIGHING_COUNT)
                return true;

            bool success = false;

            this.ShowFullScreenMessage(string.Format("Поставьте на весы товар \"{0}\"\r\nв количестве {1} уп..", docItem.ItemMeasurement.ItemName.Trim(), docItem.QuantityFact));
            while (true)
            {
                var failure = !this.ObtainSingleWeight(Optima.Devices.Data.DigitalWeigher.DataManager.DWType.Lab, (w) => { var pi = docItem.GetType().GetProperty("WeightLine"); pi.SetValue(docItem, w, pi.GetIndexParameters()); });
                if (failure)
                {
                    if (MessageBox.Show("Вес не был получен.\r\nВы желаете повторить взвешивание всей строки?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        continue;
                    }
                    else
                    {
                        throw new Exception("Обработка позиции была прервана.");
                        break;
                    }
                }
                else
                {
                    success = true;
                    break;
                }
            }

            return success;
        }

        /// <summary>
        /// Получение веса упаковки
        /// </summary>
        private bool ObtainUnitWeight()
        {
            // не требуется перевзвешивание упаковки при общем количестве 1 уп. 
            var quantity = docItem.QuantityFact;
            if (quantity == MIN_UNIT_WEIGHING_COUNT)
            {
                docItem.WeightUnit = docItem.WeightLine;
                return true;
            }

            bool success = false;
            var isObtainSingleWeight = docItem.QuantityFact < MAX_UNIT_WEIGHING_COUNT;
            var weightQuantity = isObtainSingleWeight ? MIN_UNIT_WEIGHING_COUNT : MAX_UNIT_WEIGHING_COUNT;

            this.ShowFullScreenMessage(string.Format("Поставьте на весы товар \"{0}\"\r\nв количестве {1} уп..", docItem.ItemMeasurement.ItemName.Trim(), weightQuantity));
            while (true)
            {
                var failure = false;

                if (isObtainSingleWeight)
                    failure = !this.ObtainSingleWeight(Optima.Devices.Data.DigitalWeigher.DataManager.DWType.Lab, (w) => { var pi = docItem.GetType().GetProperty("WeightUnit"); pi.SetValue(docItem, w, pi.GetIndexParameters()); });
                else
                    failure = !this.ObtainMultipleWeight(Optima.Devices.Data.DigitalWeigher.DataManager.DWType.Lab, (w) => { var pi = docItem.GetType().GetProperty("WeightUnit"); pi.SetValue(docItem, w, pi.GetIndexParameters()); });

                if (failure)
                {
                    if (MessageBox.Show("Вес не был получен.\r\nВы желаете повторить взвешивание единицы товара?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        continue;
                    }
                    else
                    {
                        throw new Exception("Обработка позиции была прервана.");
                        break;
                    }
                }
                else
                {
                    success = true;
                    break;
                }
            }

            return success;
        }

        /// <summary>
        /// Получение признака наличия инструкции
        /// </summary>
        /// <returns></returns>
        private bool ObtainInstructionFlag()
        {
            bool success = false;

            while (true)
            {
                var frmItemReWeighingSetInstruction = new ItemReWeighingSetInstructionForm() {  };
                if (frmItemReWeighingSetInstruction.ShowDialog() == DialogResult.OK)
                {
                    docItem.InstructionFlag = Convert.ToInt32(frmItemReWeighingSetInstruction.HasInstruction);
                    success = true;
                    break;
                }
                else
                {
                    if (MessageBox.Show("Признак наличия инструкции не был получен.\r\nВы желаете повторить фикскацию признака наличия инструкции?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        continue;
                    }
                    else
                    {
                        throw new Exception("Обработка позиции была прервана.");
                        break;
                    }
                }
            }

            return success;
        }

        /// <summary>
        /// Вес пустого контейнера
        /// </summary>
        private bool ObtainEmptyContainerWeight()
        {
            bool success = false;
            this.ShowFullScreenMessage("Поставьте на весы пустой ящик.");
            while (true)
            {
                var failure = !this.ObtainSingleWeight(Optima.Devices.Data.DigitalWeigher.DataManager.DWType.Static, (w) => { var pi = docItem.GetType().GetProperty("WeightEmptyContainer"); pi.SetValue(docItem, w, pi.GetIndexParameters()); });
                if (failure)
                {
                    if (MessageBox.Show("Вес не был получен.\r\nВы желаете повторить взвешивание пустого ящика?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        continue;
                    }
                    else
                    {
                        throw new Exception("Обработка была прервана.");
                        break;
                    }
                }
                else
                {
                    success = true;
                    break;
                }
            }

            return success;
        }

        /// <summary>
        /// Вес одиночный
        /// </summary>
        private bool ObtainSingleWeight(Optima.Devices.Data.DigitalWeigher.DataManager.DWType defaultDWType, UpdateWeightHandler updateWeightHandler)
        {
            bool success = false;

            try
            {
                #region ОПРЕДЕЛЕНИЕ ТИПА ВЕСОВ

                int typeID = (int)Optima.Devices.Data.DigitalWeigher.DataManager.DWType.Static;
                decimal minRatio = 0.5M;
                int eScaleCoef = 1000;

                var dlgSelectWeightType = new WMSOffice.Dialogs.RichListForm();
                dlgSelectWeightType.Text = "Выберите тип весов";
                dlgSelectWeightType.AddColumn("TypeID", "TypeID", "Код");
                dlgSelectWeightType.AddColumn("TypeName", "TypeName", "Наименование");
                dlgSelectWeightType.FilterChangeLevel = 0;
                dlgSelectWeightType.FilterVisible = false;

                var table = new Optima.Devices.Data.DigitalWeigher.TVP_12e.DW_TypesDataTable();
                Optima.Devices.Data.DigitalWeigher.DataManager.DW_TypesTableAdapter.Fill(table);
                table.DefaultView.Sort = string.Format("TypeID {0}", defaultDWType == Optima.Devices.Data.DigitalWeigher.DataManager.DWType.Lab ? "DESC" : "ASC");
                dlgSelectWeightType.DataSource = table;

                if (dlgSelectWeightType.ShowDialog() != DialogResult.OK)
                    return false;

                typeID = (dlgSelectWeightType.SelectedRow as Optima.Devices.Data.DigitalWeigher.TVP_12e.DW_TypesRow).TypeID;
                minRatio = (dlgSelectWeightType.SelectedRow as Optima.Devices.Data.DigitalWeigher.TVP_12e.DW_TypesRow).MinRatio;

                eScaleCoef = typeID == (int)Optima.Devices.Data.DigitalWeigher.DataManager.DWType.Static
                                        ? 1000
                                        : typeID == (int)Optima.Devices.Data.DigitalWeigher.DataManager.DWType.Lab
                                            ? 1
                                            : 0;
                minRatio = 0.5M / eScaleCoef;

                #endregion

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
                                throw new Exception("Вес задан некорректно.");

                            currentWeight *= eScaleCoef;
                            sCurrentWeight = currentWeight.ToString();

                            // обновление веса
                            updateWeightHandler(currentWeight);
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
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                //updateWeightHandler(w = (w * 1.5));
                //return true;

                // Запускаем фоновый поток
                weightProvider.Run();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return success;
        }
        //double w = 100.0;

        /// <summary>
        /// Вес многократный
        /// </summary>
        private bool ObtainMultipleWeight(Optima.Devices.Data.DigitalWeigher.DataManager.DWType defaultDWType, UpdateWeightHandler updateWeightHandler)
        {
            var itemMeasurement = docItem.ItemMeasurement;
            bool success = false;

            try
            {
                var frmObtainWeight = new ObtainItemWeightForm(itemMeasurement, ReWeighingProcessType.ReWeighingBy3) { DefaultDWType = defaultDWType };
                frmObtainWeight.OnCancelPreviousDoc += (s, ea) =>
                {
                    itemMeasurement.ItemWeightDocID = (long?)null;
                    itemMeasurement.ItemWeightFlag = (string)null;
                };

                if (frmObtainWeight.ShowDialog() == DialogResult.OK)
                {                    
                    itemMeasurement.ItemWeightDocID = frmObtainWeight.WeightDocID;
                    itemMeasurement.ItemWeightFlag = frmObtainWeight.WeightFlag;

                    // закроем документ многократного взвешивания
                    itemMeasurement.CloseWeightDoc();

                    // обновление веса
                    updateWeightHandler(frmObtainWeight.Weight);
                    docItem.WeightUnitFlag = frmObtainWeight.WeightFlag;

                    // вес строки при общем количестве 3 уп. получен на первой итерации многократного взвешивания
                    var quantity = docItem.QuantityFact;
                    if (quantity == MAX_UNIT_WEIGHING_COUNT)
                        docItem.WeightLine = frmObtainWeight.UnitX3Weight;

                    success = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return success;
        }

        private void dgvDocItems_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var boundRow = (dgvDocItems.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Receive.ReWeightPickControlDocItemsRow;
            var flag = boundRow.IsFlag_ColorNull() ? 0 : boundRow.Flag_Color;
            var color = flag == 1 ? Color.LightGray : SystemColors.Window;

            e.CellStyle.BackColor = color;
            e.CellStyle.SelectionForeColor = color;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshDocItems();
        }

        private void RefreshDocItems()
        {
            try
            {
                reWeightPickControlDocItemsBindingSource.DataSource = null;
                receive.ReWeightPickControlDocItems.Clear();

                Data.Receive.ReWeightPickControlDocItemsDataTable docItems = null;

                using (var adapter = new Data.ReceiveTableAdapters.ReWeightPickControlDocItemsTableAdapter())
                   docItems = adapter.GetData(this.DocID);

                receive.ReWeightPickControlDocItems.Merge(docItems);
                reWeightPickControlDocItemsBindingSource.DataSource = docItems;

                //reWeightPickControlDocItemsBindingSource.Sort = string.Format("{0} DESC", receive.ReWeightPickControlDocItems.Flag_ColorColumn.Caption);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
            finally
            {
                tbsItemBarcode.Focus();
            }
        }

        /// <summary>
        /// Поиск строки с товаром в таблице
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        private DataGridViewRow FindDocItemGridRow(int itemID)
        {
            DataGridViewRow findGridRow = null;
            foreach (DataGridViewRow dgvr in dgvDocItems.Rows)
            {
                var rowItemID = Convert.ToInt32(dgvr.Cells[itmIdDataGridViewTextBoxColumn.Index].Value);
                if (rowItemID == itemID)
                {
                    findGridRow = dgvr;
                    break;
                }
            }

            return findGridRow;
        
        }

        /// <summary>
        /// Позиционирование выбранной строки
        /// </summary>
        /// <param name="gridRow"></param>
        private void NavigateToCurrentGridRow(DataGridViewRow gridRow)
        {
            gridRow.Selected = true;
            dgvDocItems.FirstDisplayedScrollingRowIndex = gridRow.Index;
        }

        /// <summary>
        /// Выбор позиции в документе
        /// </summary>
        /// <param name="gridRow"></param>
        private void SelectItem(DataGridViewRow gridRow)
        {
            // позиционирование
            this.NavigateToCurrentGridRow(gridRow);

            var drDocItem = (gridRow.DataBoundItem as DataRowView).Row as Data.Receive.ReWeightPickControlDocItemsRow;
            var itemID = Convert.ToInt32(drDocItem.Itm_Id);
            var itemName = drDocItem.Itm_Name;
            var manufacturer = drDocItem.Manuf;
            var supplier = drDocItem.Vendor;

            // получение ОБВХ товара
            var itemMeasurement = new MeasurementItem();
            itemMeasurement.ItemID = itemID;
            itemMeasurement.ItemName = itemName;
            itemMeasurement.ManufacturerName = manufacturer;
            itemMeasurement.SupplierName = supplier;
            itemMeasurement.LoadData();

            docItem.ItemMeasurement = itemMeasurement;
            docItem.QuantityPlan = Convert.ToInt32(drDocItem.IsDoc_QtyNull() ? 0 : drDocItem.Doc_Qty);
        }

        private void btnCloseDoc_Click(object sender, EventArgs e)
        {
            this.CloseDocForce();
        }

        private void CloseDocForce()
        {
            try
            {
                // взвешивание пустого ящика
                this.ObtainEmptyContainerWeight();

                // фиксация результатов взвешивания пустого ящика
                var emptyContainerWeightFact = docItem.WeightEmptyContainer;
                lblEmptyContainerFactWeightValue.Text = emptyContainerWeightFact.HasValue ? emptyContainerWeightFact.Value.ToString("f2") : "-";

                // принудительное завершение работы с документом
                this.CloseDoc(true);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void CloseDoc(bool closeForce)
        {
            try
            {
                if (closeForce)
                    docItem.CloseDocForce();
                else
                    docItem.CloseDoc();

                MessageBox.Show("Документ был успешно закрыт.", "Закрытие документа", MessageBoxButtons.OK, MessageBoxIcon.Information);

                allowCloseWindow = true;
                this.Close();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private bool allowCloseWindow = false;
        private void ReWeightPickSlipWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!allowCloseWindow && (Control.ModifierKeys != Keys.Control))
            {
                MessageBox.Show("Нельзя закрыть окно документа до завершения\r\nпроцедуры контроля. Пожалуйста, продолжайте работу.\r\nДля закрытия документа контроля воспользуйтесь командой \"Закрыть документ\".", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }

            if (Control.ModifierKeys == Keys.Control)
                this.Terminate = true;
        }

        private class ReWeightDocItem
        {
            public long DocID { get; private set; }

            public MeasurementItem ItemMeasurement { get; set; }
            public int? LineID { get; set; }

            public int? QuantityPlan { get; set; }
            public int? QuantityFact { get; set; }
            public double? WeightLine { get; set; }
            public double? WeightUnit { get; set; }
            public string WeightUnitFlag { get; set; }
            public int? InstructionFlag { get; set; }
            public double? WeightFullContainer { get; set; }
            public double? WeightEmptyContainer { get; set; }

            public event EventHandler OnCompleteItem;
            public void RaiseOnCompleteItem()
            {
                if (this.OnCompleteItem != null)
                    this.OnCompleteItem(this, EventArgs.Empty);
            }

            public ReWeightDocItem(long docID)
            {
                this.DocID = docID;
            }

            public void Clear()
            {
                this.ItemMeasurement = null;
                this.LineID = (int?)null;
                this.QuantityPlan = (int?)null;
                this.QuantityFact = (int?)null;
                this.WeightLine = (double?)null;
                this.WeightUnit = (double?)null;
                this.WeightUnitFlag = (string)null;
                this.InstructionFlag = (int?)null;
            }

            public void CheckItem(int itemID)
            {
                try
                {
                    var lineID = (int?)null;
                    using (var adapter = new Data.ReceiveTableAdapters.ReWeightPickControlDocItemsTableAdapter())
                        adapter.CheckDocItem(this.DocID, itemID, ref lineID);

                    this.LineID = lineID;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void AddItem(int itemID)
            {
                try
                {
                    using (var adapter = new Data.ReceiveTableAdapters.ReWeightPickControlDocItemsTableAdapter())
                        adapter.AddDocItem(this.DocID, itemID, 0);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void UpdateItem()
            {
                try
                {
                    using (var adapter = new Data.ReceiveTableAdapters.ReWeightPickControlDocItemsTableAdapter())
                        adapter.UpdateDocItem(this.DocID, this.LineID, this.QuantityFact, this.WeightUnit, this.WeightLine, this.WeightUnitFlag, this.InstructionFlag);

                    this.RaiseOnCompleteItem();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public bool CanCloseDoc()
            {
                try
                {
                    var canCloseDocFlag = (int?)null;

                    using (var adapter = new Data.ReceiveTableAdapters.ReWeightPickControlDocItemsTableAdapter())
                        adapter.CheckDocCanClose(this.DocID, ref canCloseDocFlag);

                    return Convert.ToBoolean(canCloseDocFlag ?? 0);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void CloseDoc()
            {
                try
                {
                    using (var adapter = new Data.ReceiveTableAdapters.ReWeightPickControlDocItemsTableAdapter())
                        adapter.CloseDoc(this.DocID, this.WeightFullContainer, this.WeightEmptyContainer);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void CloseDocForce()
            {
                try
                {
                    using (var adapter = new Data.ReceiveTableAdapters.ReWeightPickControlDocItemsTableAdapter())
                        adapter.CloseDocForce(this.DocID, this.WeightFullContainer, this.WeightEmptyContainer);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
