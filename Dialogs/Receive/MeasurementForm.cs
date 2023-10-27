using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Data.ItemsMeasurementTableAdapters;
using WMSOffice.Classes;

namespace WMSOffice.Dialogs.Receive
{
    public partial class MeasurementForm : DialogForm
    {
        public MeasurementForm()
        {
            InitializeComponent();
        }

        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string BatchNumber { get; set; }

        public bool DenyAccessFlag { get; private set; }

        private void MeasurementForm_Load(object sender, EventArgs e)
        {
            lblCode.Text = ItemID.ToString();
            lblName.Text = ItemName;

            using (Data.ItemsMeasurementTableAdapters.ItemInfoTableAdapter adapter = new ItemInfoTableAdapter())
            {
                Data.ItemsMeasurement.ItemInfoDataTable table = adapter.GetData(ItemID, BatchNumber);
                if (table.Count > 0)
                {
                    Data.ItemsMeasurement.ItemInfoRow row = table[0];

                    // Измерения паллеты
                    tbPalletDepth.Text = (row.IsDepthPLNull() || row.DepthPL == 0) ? "" : row.DepthPL.ToString();
                    tbPalletWidth.Text = (row.IsWidthPLNull() || row.WidthPL == 0) ? "" : row.WidthPL.ToString();
                    tbPalletHeight.Text = (row.IsHeightPLNull() || row.HeightPL == 0) ? "" : row.HeightPL.ToString();
                    tbPalletWeight.Text = (row.IsWeightPLNull() || row.WeightPL == 0) ? "" : row.WeightPL.ToString();
                    tbBoxesQuantityInPallet.Text = (row.IsConvBXPLNull() || row.ConvBXPL == 0) ? "1" : row.ConvBXPL.ToString();

                    chbIsPalletAbsent.Checked = row.IsNotPLNull() ? false : row.NotPL == "Y";

                    // Измерения ящика
                    tbBoxDepth.Text = (row.IsDepthBXNull() || row.DepthBX == 0) ? "" : row.DepthBX.ToString();
                    tbBoxWidth.Text = (row.IsWidthBXNull() || row.WidthBX == 0) ? "" : row.WidthBX.ToString();
                    tbBoxHeight.Text = (row.IsHeightBXNull() || row.HeightBX == 0) ? "" : row.HeightBX.ToString();
                    tbBoxWeight.Text = (row.IsWeightBXNull() || row.WeightBX == 0) ? "" : row.WeightBX.ToString();
                    tbBunchesQuantityInBox.Text = (row.IsConvSHBXNull() || row.ConvSHBX == 0) ? "1" : row.ConvSHBX.ToString();

                    chbIsBoxAbsent.Checked = row.IsNotBXNull() ? false : row.NotBX == "Y";

                    // Измерения связки
                    tbBunchDepth.Text = (row.IsDepthSHNull() || row.DepthSH == 0) ? "" : row.DepthSH.ToString();
                    tbBunchWidth.Text = (row.IsWidthSHNull() || row.WidthSH == 0) ? "" : row.WidthSH.ToString();
                    tbBunchHeight.Text = (row.IsHeightSHNull() || row.HeightSH == 0) ? "" : row.HeightSH.ToString();
                    tbBunchWeight.Text = (row.IsWeightSHNull() || row.WeightSH == 0) ? "" : row.WeightSH.ToString();
                    tbItemsQuantityInBunch.Text = (row.IsConvITSHNull() || row.ConvITSH == 0) ? "1" : row.ConvITSH.ToString();

                    chbIsBunchAbsent.Checked = row.IsNotSHNull() ? false : row.NotSH == "Y";

                    // Измерения упаковки
                    tbItemDepth.Text = (row.IsDepthITNull() || row.DepthIT == 0) ? "" : row.DepthIT.ToString();
                    tbItemWidth.Text = (row.IsWidthITNull() || row.WidthIT == 0) ? "" : row.WidthIT.ToString();
                    tbItemHeight.Text = (row.IsHeightITNull() || row.HeightIT == 0) ? "" : row.HeightIT.ToString();
                    tbItemWeight.Text = (row.IsWeightITNull() || row.WeightIT == 0) ? "" : row.WeightIT.ToString();

                    // Установка доступа к модулю весоизмерения
                    var accessFlag = this.CheckObtainWeightAccess();
                    this.DenyAccessFlag = accessFlag == 0;
                    switch (accessFlag)
                    {
                        case 1: // DW -- вес с весов
                            tbBoxWeight.ReadOnly = true;
                            tbBunchWeight.ReadOnly = true;
                            tbItemWeight.ReadOnly = true;
                            break;
                        case 2: // MW -- ручное указание веса
                            btnObtainBoxWeight.Enabled = false;
                            btnObtainBunchWeight.Enabled = false;
                            btnObtainItemWeight.Enabled = false;
                            break;
                        default: // -- иначе редактировать вес нельзя
                            DenyAccess();
                            //tbBoxWeight.ReadOnly = true;
                            //tbBunchWeight.ReadOnly = true;
                            //tbItemWeight.ReadOnly = true;

                            //btnObtainBoxWeight.Enabled = false;
                            //btnObtainBunchWeight.Enabled = false;
                            //btnObtainItemWeight.Enabled = false;
                            break;
                    }

                    // Ш/К товара
                    if (!row.IsBarCodeNull() && !String.IsNullOrEmpty(row.BarCode))
                        tbBarcode.Text = row.BarCode;

                    // Ш/К товара ЗУ
                    if (!row.IsBarCodeZuNull() && !String.IsNullOrEmpty(row.BarCodeZu))
                        tbBarcodeZU.Text = row.BarCodeZu;
                }

                this.RecalculateMeasurenentObjectsVolume();
            }
        }

        private void DenyAccess()
        {
            tbPalletDepth.ReadOnly = true;
            tbPalletWidth.ReadOnly = true;
            tbPalletHeight.ReadOnly = true;
            tbBoxesQuantityInPallet.ReadOnly = true;
            chbIsPalletAbsent.Enabled = false;

            tbBoxDepth.ReadOnly = true;
            tbBoxWidth.ReadOnly = true;
            tbBoxHeight.ReadOnly = true;
            tbBunchesQuantityInBox.ReadOnly = true;
            chbIsBoxAbsent.Enabled = false;

            tbBunchDepth.ReadOnly = true;
            tbBunchWidth.ReadOnly = true;
            tbBunchHeight.ReadOnly = true;
            tbItemsQuantityInBunch.ReadOnly = true;
            chbIsBunchAbsent.Enabled = false;

            tbItemDepth.ReadOnly = true;
            tbItemWidth.ReadOnly = true;
            tbItemHeight.ReadOnly = true;

            groupBox1.Enabled = false;

            tbBoxWeight.ReadOnly = true;
            tbBunchWeight.ReadOnly = true;
            tbItemWeight.ReadOnly = true;

            btnObtainBoxWeight.Enabled = false;
            btnObtainBunchWeight.Enabled = false;
            btnObtainItemWeight.Enabled = false;
        }

        /// <summary>
        /// Проверка доступа к модулю весоизмерения
        /// </summary>
        /// <returns></returns>
        private int CheckObtainWeightAccess()
        {
            try
            {
                var accessFlag = (int?)null;

                // TODO Доступ закрыт для "старого" интерфейса ввода ОБВХ
                //using (var adapter = new Data.ItemsMeasurementTableAdapters.ItemInfoTableAdapter())
                //    adapter.CheckObtainWeightAccess(this.UserID, ref accessFlag);

                return accessFlag ?? 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.btnOK.Location = new Point(371, 8);
            this.btnCancel.Location = new Point(461, 8);

            if (DenyAccessFlag)
            {
                this.btnOK.Visible = false;
                this.btnCancel.Text = "Закрыть";

                Label lblDenyMessage = new Label();
                pnlButtons.Controls.Add(lblDenyMessage);
                lblDenyMessage.Location = new Point(20, 3);
                lblDenyMessage.Text = "Если Вам необходим доступ к редактированию ОБВХ\r\n– обратитесь в ГСПО (6444)";
                lblDenyMessage.Font = new Font(FontFamily.GenericSansSerif, 9.75f, FontStyle.Bold);
                lblDenyMessage.AutoSize = false;
                lblDenyMessage.Size = new Size(450, 35);
                lblDenyMessage.ForeColor = Color.Red;

                pnlButtons.BackColor = SystemColors.Info;
            }

            this.AdaptModeDesign();

            tbPalletDepth.Focus();
            ToolTip tip = new ToolTip();
            tip.SetToolTip(btnBarCodes, "Штрих-коды для товара");
        }

        /// <summary>
        /// Настройка дизайна режима отображения диалога
        /// </summary>
        private void AdaptModeDesign()
        {
            if (!string.IsNullOrEmpty(this.BatchNumber))
            {
                lblLotNumber.Text = this.BatchNumber;
            }
            else
            {
                var defaultIndent = 30;

                panel1.Top -= defaultIndent;

                foreach (Control control in this.Controls)
                {
                    if (control is GroupBox)
                        control.Top -= defaultIndent;
                    if (control is TabControl)
                        control.Top -= defaultIndent;
                }

                this.Height -= defaultIndent;
            }
        }

        /// <summary>
        /// Пересчет объемов объектов измерений
        /// </summary>
        private void RecalculateMeasurenentObjectsVolume()
        {
            this.CalculateMeasurenentObjectVolume(tbPalletHeight, tbPalletWidth, tbPalletDepth, tbPalletVolume);
            this.CalculateMeasurenentObjectVolume(tbBoxHeight, tbBoxWidth, tbBoxDepth, tbBoxVolume);
            this.CalculateMeasurenentObjectVolume(tbBunchHeight, tbBunchWidth, tbBunchDepth, tbBunchVolume);
            this.CalculateMeasurenentObjectVolume(tbItemHeight, tbItemWidth, tbItemDepth, tbItemVolume);
        }

        /// <summary>
        /// Расчет объема объекта измерения
        /// </summary>
        /// <param name="tbHeight"></param>
        /// <param name="tbWidth"></param>
        /// <param name="tbDepth"></param>
        /// <param name="tbTargetVolume"></param>
        private void CalculateMeasurenentObjectVolume(TextBox tbHeight, TextBox tbWidth, TextBox tbDepth, TextBox tbTargetVolume)
        {
            try
            {
                double volume = (Convert.ToDouble(tbHeight.Text.Replace(".", separator).Replace(",", separator)) *
                                 Convert.ToDouble(tbWidth.Text.Replace(".", separator).Replace(",", separator)) *
                                 Convert.ToDouble(tbDepth.Text.Replace(".", separator).Replace(",", separator)));

                tbTargetVolume.Text = volume == 0 ? "0" : volume.ToString("f1");
            }
            catch (Exception ex)
            {
                tbTargetVolume.Text = "0";
            }
        }    

        private string separator = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;

        private string CheckDoubleValue(string value, string fieldName, double from, double to, out double result)
        {
            result = 0;
            value = value.Replace(".", separator).Replace(",", separator);
            if (String.IsNullOrEmpty(value)) return String.Format("Необходимо ввести значение {0}.", fieldName) + Environment.NewLine;
            else if (!double.TryParse(value, out result)) return String.Format("Недопустимое значение {0}.", fieldName) + Environment.NewLine;
            else if (result < from || result >= to) return String.Format("Значение {0} должно быть в диапазоне от {1} до {2}.", fieldName, from, to) + Environment.NewLine;
            else return "";
        }

        private string CheckIntValue(string value, string fieldName, double from, double to, out double result)
        {
            string error = CheckDoubleValue(value, fieldName, from, to, out result);
            int resInt = 0;
            if (String.IsNullOrEmpty(error) && !int.TryParse(value, out resInt))
                error = String.Format("Значение {0} должно быть целочисленным.", fieldName) + Environment.NewLine;
            return error;
        }

        private void MeasurementForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                // проверка значений на допустимость
                string error = "";

                #region variables
                string barcode = tbBarcode.Text;
                bool notBarcode = brNOBarcode.Checked;
                bool badBarcode = !brNOBarcode.Checked && chbBadBarcode.Checked;

                string barcodeZU = tbBarcodeZU.Text;
                bool notBarcodeZU = brNOBarcodeZU.Checked; ;
                bool badBarcodeZU = !brNOBarcodeZU.Checked && chbBadBarcodeZU.Checked;

                double weightPL = 0, depthPL = 0, widthPL = 0, heightPL = 0, convBXPL = 0,
                       weightBX = 0, depthBX = 0, widthBX = 0, heightBX = 0, convSHBX = 0,
                       weightSH = 0, depthSH = 0, widthSH = 0, heightSH = 0, convITSH = 0,
                       weightIT = 0, depthIT = 0, widthIT = 0, heightIT = 0;

                string palletAbsent = chbIsPalletAbsent.Checked ? "Y" : "N";
                string boxAbsent = chbIsBoxAbsent.Checked ? "Y" : "N";
                string bunchAbsent = chbIsBunchAbsent.Checked ? "Y" : "N";
                #endregion

                error += CheckDoubleValue(tbPalletDepth.Text, "ДЛИНА паллеты", 0, 1200, out depthPL);
                error += CheckDoubleValue(tbPalletWidth.Text, "ШИРИНА паллеты", 0, 1200, out widthPL);
                error += CheckDoubleValue(tbPalletHeight.Text, "ВЫСОТА паллеты", 0, 1200, out heightPL);
                error += CheckDoubleValue(tbPalletWeight.Text, "ВЕС паллеты", 0, 1000000, out weightPL);
                error += CheckIntValue(tbBoxesQuantityInPallet.Text, "КОЛИЧЕСТВО ящиков в паллете", 0, 1000000, out convBXPL);

                error += CheckDoubleValue(tbBoxDepth.Text, "ДЛИНА ящика", 0, 1200, out depthBX);
                error += CheckDoubleValue(tbBoxWidth.Text, "ШИРИНА ящика", 0, 1200, out widthBX);
                error += CheckDoubleValue(tbBoxHeight.Text, "ВЫСОТА ящика", 0, 1200, out heightBX);
                error += CheckDoubleValue(tbBoxWeight.Text, "ВЕС ящика", 0, 1000000, out weightBX);
                error += CheckIntValue(tbBunchesQuantityInBox.Text, "КОЛИЧЕСТВО связок в ящике", 0, 1000000, out convSHBX);

                error += CheckDoubleValue(tbBunchDepth.Text, "ДЛИНА склейки", 0, 1200, out depthSH);
                error += CheckDoubleValue(tbBunchWidth.Text, "ШИРИНА склейки", 0, 1200, out widthSH);
                error += CheckDoubleValue(tbBunchHeight.Text, "ВЫСОТА склейки", 0, 1200, out heightSH);
                error += CheckDoubleValue(tbBunchWeight.Text, "ВЕС склейки", 0, 1000000, out weightSH);
                error += CheckIntValue(tbItemsQuantityInBunch.Text, "КОЛИЧЕСТВО упаковок в склейке", 0, 1000000, out convITSH);

                error += CheckDoubleValue(tbItemDepth.Text, "ДЛИНА упаковки", 0, 1200, out depthIT);
                error += CheckDoubleValue(tbItemWidth.Text, "ШИРИНА упаковки", 0, 1200, out widthIT);
                error += CheckDoubleValue(tbItemHeight.Text, "ВЫСОТА упаковки", 0, 1200, out heightIT);
                error += CheckDoubleValue(tbItemWeight.Text, "ВЕС упаковки", 0, 1000000, out weightIT);

                error += (!notBarcode && String.IsNullOrEmpty(tbBarcode.Text)) ? "Значение ШТРИХ КОД упаковки не введено!" : "";

                try
                {
                    // сохранение результата
                    if (String.IsNullOrEmpty(error))
                    {
                        // Валидация соотношений объема
                        this.ValidateVolumesСorrelation();
                        
                        // Валидация соотношений веса
                        this.ValidateWeightsСorrelation();

                        using (ItemInfoTableAdapter adapter = new ItemInfoTableAdapter())
                        {
                            // сохранение ОБВХ с привязкой к товару
                            if (string.IsNullOrEmpty(this.BatchNumber))
                            {
                                adapter.AddExtraMeasurement(
                                    UserID, ItemID,
                                    barcode, notBarcode, badBarcode,
                                    barcodeZU, notBarcodeZU, badBarcodeZU,
                                    weightIT, depthIT, heightIT, widthIT,
                                    weightBX, depthBX, heightBX, widthBX,
                                    weightSH, depthSH, heightSH, widthSH,
                                    weightPL, depthPL, heightPL, widthPL,
                                    convITSH, convSHBX, convBXPL,
                                    boxAbsent, palletAbsent, bunchAbsent, (string)null, (string)null, (int?)null, (string)null,
                                    (int?)null, (int?)null, (double?)null, (int?)null, (int?)null);
                            }
                            // сохранение ОБВХ с привязкой к партии товара
                            else
                            {
                                adapter.AddExtraMeasurementByBatchNumber(
                                    UserID, ItemID,
                                        barcode, notBarcode, badBarcode,
                                        barcodeZU, notBarcodeZU, badBarcodeZU,
                                        weightIT, depthIT, heightIT, widthIT,
                                        weightBX, depthBX, heightBX, widthBX,
                                        weightSH, depthSH, heightSH, widthSH,
                                        weightPL, depthPL, heightPL, widthPL,
                                        convITSH, convSHBX, convBXPL,
                                        boxAbsent, palletAbsent, bunchAbsent, BatchNumber, (string)null, (int?)null, (string)null,
                                        (int?)null, (int?)null, (double?)null, (int?)null, (int?)null);
                            }
                        }
                    }
                }
                catch (MeasurementCorrelationException ex)
                {
                    e.Cancel = true;
                    MessageBox.Show(ex.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                }

                // не закрываем окно, если есть ошибки
                if (!String.IsNullOrEmpty(error))
                {
                    e.Cancel = true;
                    MessageBox.Show(error, "Ошибка");
                }
            }
        }

        private void brNOBarcode_CheckedChanged(object sender, EventArgs e)
        {
            tbBarcode.Enabled = chbBadBarcode.Enabled = btnBarCodes.Enabled = !brNOBarcode.Checked;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (this.ActiveControl is TextBox ||
                this.ActiveControl is RadioButton ||
                this.ActiveControl is CheckBox)
                switch (keyData)
                {
                    case Keys.Enter:
                        return base.ProcessDialogKey(Keys.Tab);
                }
            return base.ProcessDialogKey(keyData);
        }

        private void tbBarcode_TextChanged(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void chbIsMeasurementGroupAbsent_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox measurementGroupTrigger = sender as CheckBox;
            this.ChangeMeasurementControlsAccessability(!measurementGroupTrigger.Checked, measurementGroupTrigger.Parent as GroupBox);
        }

        /// <summary>
        /// Изменить доступность компонентов измерений
        /// </summary>
        /// <param name="state"></param>
        /// <param name="gbContainer"></param>
        private void ChangeMeasurementControlsAccessability(bool state, GroupBox gbContainer)
        {
            foreach (Control c in gbContainer.Controls)
            {
                if (c is TextBox)
                {
                    TextBox target = c as TextBox;

                    if (!target.Name.Contains("Volume"))
                        target.Enabled = state;

                    //// Для отсутствующей группы измерений определим значения по умолчанию
                    if (!state)
                    {
                        // Запомним предыдущее значение
                        target.Tag = target.Text;

                        // Определим значение по умолчанию
                        target.Text = "0";

                        if (target.Name.Contains("Quantity"))
                            target.Text = "1";
                    }
                    else
                        // Восстановим предыдущее значение
                        if (target.Tag != null)
                            target.Text = target.Tag.ToString();
                }
                else if (c is Button)
                {
                    Button target = c as Button;
                    target.Visible = state;
                }
            }
        }

        private void btnBarCodes_Click(object sender, EventArgs e)
        {
            var dialog = new ItemMeasurementBarCodes()
            {
                UserID = this.UserID,
                ItemID = this.ItemID
            };
            if (dialog.ShowDialog() == DialogResult.OK && !String.IsNullOrEmpty(dialog.SelectedBarCode))
            {
                chbBadBarcode.Checked = false;
                tbBarcode.Text = dialog.SelectedBarCode;
            }
            
            // Сотрем поле ш/к если он был удален
            if (dialog.CheckForDeletedBarCode(tbBarcode.Text))
            {
                tbBarcode.Text = string.Empty;
                //brNOBarcode.Checked = true;
            }
        }

        private void btnBarCodesZU_Click(object sender, EventArgs e)
        {
            var dialog = new ItemMeasurementBarCodes()
            {
                UserID = this.UserID,
                ItemID = this.ItemID
            };
            if (dialog.ShowDialog() == DialogResult.OK && !String.IsNullOrEmpty(dialog.SelectedBarCode))
            {
                chbBadBarcodeZU.Checked = false;
                tbBarcodeZU.Text = dialog.SelectedBarCode;
            }

            // Сотрем поле ш/к если он был удален
            if (dialog.CheckForDeletedBarCode(tbBarcodeZU.Text))
            {
                tbBarcodeZU.Text = string.Empty;
                //brNOBarcodeZU.Checked = true;
            }
        }

        private void tbMeasurement_Leave(object sender, EventArgs e)
        {
            this.RecalculateMeasurenentObjectsVolume();
        }

        #region ВАЛИДАЦИЯ СООТНОШЕНИЙ ОБЪЕМА
        /// <summary>
        /// Валидация вложенности объемов измеряемых объектов
        /// </summary>
        private void ValidateVolumesСorrelation()
        {
            if (!chbIsBunchAbsent.Checked)
                this.ValidateMeasurementObjectVolumeСorrelation(tbBunchVolume, "склейки", tbItemVolume, tbItemsQuantityInBunch, "упаковок");

            if (!chbIsBoxAbsent.Checked)
            {
                // уровень "склейки" активен
                if (!chbIsBunchAbsent.Checked)
                    this.ValidateMeasurementObjectVolumeСorrelation(tbBoxVolume, "ящика", tbBunchVolume, tbBunchesQuantityInBox, "склеек");
                // уровень "товар"
                else
                    this.ValidateMeasurementObjectVolumeСorrelation(tbBoxVolume, "ящика", tbItemVolume, tbBunchesQuantityInBox, "вложенных единиц");
            }

            if (!chbIsPalletAbsent.Checked)
            {
                // уровень "ящик" активен
                if (!chbIsBoxAbsent.Checked)
                    this.ValidateMeasurementObjectVolumeСorrelation(tbPalletVolume, "паллеты", tbBoxVolume, tbBoxesQuantityInPallet, "ящиков");
                // уровень "склейки" активен
                else if (!chbIsBunchAbsent.Checked)
                    this.ValidateMeasurementObjectVolumeСorrelation(tbPalletVolume, "паллеты", tbBunchVolume, tbBoxesQuantityInPallet, "вложенных единиц");
                // уровень "товар"
                else
                    this.ValidateMeasurementObjectVolumeСorrelation(tbPalletVolume, "паллеты", tbItemVolume, tbBoxesQuantityInPallet, "вложенных единиц");
            }
        }

        /// <summary>
        /// Валидация вложенности объемов измеряемых объектов попарно
        /// </summary>
        /// <param name="tbContainerVolume"></param>
        /// <param name="containerDescription"></param>
        /// <param name="tbContentVolume"></param>
        /// <param name="tbContentCount"></param>
        /// <param name="contentDescription"></param>
        private void ValidateMeasurementObjectVolumeСorrelation(TextBox tbContainerVolume, string containerDescription, TextBox tbContentVolume, TextBox tbContentCount, string contentDescription)
        {
            double containerVolumeRatio = 2.0f;//1.3f;
            double containerVolume = Convert.ToDouble(tbContainerVolume.Text.Replace(".", separator).Replace(",", separator));

            double contentVolume = Convert.ToDouble(tbContentVolume.Text.Replace(".", separator).Replace(",", separator));
            int contentQuantity = Convert.ToInt32(tbContentCount.Text);

            if (containerVolume < contentVolume * contentQuantity)
                throw new MeasurementCorrelationException(string.Format("Обнаружено несоответствие!\n\nОбъем {0} не может быть меньше, чем\nсуммарный объем {1}!\n\nОткорректируйте данные.", containerDescription, contentDescription));

            if (containerVolume > contentVolume * contentQuantity * containerVolumeRatio)
                throw new MeasurementCorrelationException(string.Format("Обнаружено несоответствие!\n\nОбъем {0} не может превышать\nсуммарный объем {1} более чем в 2 раза!\n\nОткорректируйте данные.", containerDescription, contentDescription));
        }
        #endregion

        #region ВАЛИДАЦИЯ СООТНОШЕНИЙ ВЕСА
        /// <summary>
        /// Валидация вложенности веса измеряемых объектов
        /// </summary>
        private void ValidateWeightsСorrelation()
        {
            if (!chbIsBunchAbsent.Checked)
                this.ValidateMeasurementObjectWeightСorrelation(tbBunchWeight, "склейки", tbItemWeight, tbItemsQuantityInBunch, "упаковок");

            if (!chbIsBoxAbsent.Checked)
            {
                // уровень "склейки" активен
                if (!chbIsBunchAbsent.Checked)
                    this.ValidateMeasurementObjectWeightСorrelation(tbBoxWeight, "ящика", tbBunchWeight, tbBunchesQuantityInBox, "склеек");
                // уровень "товар"
                else
                    this.ValidateMeasurementObjectWeightСorrelation(tbBoxWeight, "ящика", tbItemWeight, tbBunchesQuantityInBox, "вложенных единиц");
            }

            if (!chbIsPalletAbsent.Checked)
            {
                // уровень "ящик" активен
                if (!chbIsBoxAbsent.Checked)
                    this.ValidateMeasurementObjectWeightСorrelation(tbPalletWeight, "паллеты", tbBoxWeight, tbBoxesQuantityInPallet, "ящиков");
                // уровень "склейки" активен
                else if (!chbIsBunchAbsent.Checked)
                    this.ValidateMeasurementObjectWeightСorrelation(tbPalletWeight, "паллеты", tbBunchWeight, tbBoxesQuantityInPallet, "вложенных единиц");
                // уровень "товар"
                else
                    this.ValidateMeasurementObjectWeightСorrelation(tbPalletWeight, "паллеты", tbItemWeight, tbBoxesQuantityInPallet, "вложенных единиц");
            }
        }

        /// <summary>
        /// Валидация вложенности веса измеряемых объектов попарно
        /// </summary>
        /// <param name="tbContainerVolume"></param>
        /// <param name="containerDescription"></param>
        /// <param name="tbContentVolume"></param>
        /// <param name="tbContentCount"></param>
        /// <param name="contentDescription"></param>
        private void ValidateMeasurementObjectWeightСorrelation(TextBox tbContainerWeight, string containerDescription, TextBox tbContentWeight, TextBox tbContentQuantity, string contentDescription)
        {
            double containerWeightRatio = 2.0f;//1.3f;
            double containerWeight = Convert.ToDouble(tbContainerWeight.Text.Replace(".", separator).Replace(",", separator));

            double contentWeight = Convert.ToDouble(tbContentWeight.Text.Replace(".", separator).Replace(",", separator));
            int contentQuantity = Convert.ToInt32(tbContentQuantity.Text);

            if (containerWeight < contentWeight * contentQuantity)
                throw new MeasurementCorrelationException(string.Format("Обнаружено несоответствие!\n\nВес {0} не может быть меньше, чем\nсуммарный вес {1}!\n\nОткорректируйте данные.", containerDescription, contentDescription));

            if (containerWeight > contentWeight * contentQuantity * containerWeightRatio)
                throw new MeasurementCorrelationException(string.Format("Обнаружено несоответствие!\n\nВес {0} не может превышать\nсуммарный вес {1} более чем в 2 раза!\n\nОткорректируйте данные.", containerDescription, contentDescription));

        }
        #endregion

        #region ИЗМЕРЕНИЕ ВЕСА

        private void btnObtainWeight_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(btnObtainBoxWeight))
                {
                    if (chbIsBoxAbsent.Checked)
                        return;
                }

                if (sender.Equals(btnObtainBunchWeight))
                {
                    if (chbIsBunchAbsent.Checked)
                        return;
                }

                #region ОПРЕДЕЛЕНИЕ ТИПА ВЕСОВ

                var typeID = (int)Optima.Devices.Data.DigitalWeigher.DataManager.DWType.Static;
                var minRatio = 0.5M;

                if (sender.Equals(btnObtainItemWeight) || sender.Equals(btnObtainBunchWeight)
                    || sender.Equals(btnObtainBoxWeight) // временно !!!
                    )
                {
                    var dlgSelectWeightType = new WMSOffice.Dialogs.RichListForm();
                    dlgSelectWeightType.Text = "Выберите тип весов";
                    dlgSelectWeightType.AddColumn("TypeID", "TypeID", "Код");
                    dlgSelectWeightType.AddColumn("TypeName", "TypeName", "Наименование");
                    dlgSelectWeightType.FilterChangeLevel = 0;
                    dlgSelectWeightType.FilterVisible = false;

                    var table = new Optima.Devices.Data.DigitalWeigher.TVP_12e.DW_TypesDataTable();
                    Optima.Devices.Data.DigitalWeigher.DataManager.DW_TypesTableAdapter.Fill(table);
                    dlgSelectWeightType.DataSource = table;

                    if (dlgSelectWeightType.ShowDialog() != DialogResult.OK)
                        return;

                    typeID = (dlgSelectWeightType.SelectedRow as Optima.Devices.Data.DigitalWeigher.TVP_12e.DW_TypesRow).TypeID;
                    minRatio = (dlgSelectWeightType.SelectedRow as Optima.Devices.Data.DigitalWeigher.TVP_12e.DW_TypesRow).MinRatio; 
                }

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
                                throw new Exception("Вес ящика задан некорректно.");

                            // Преобразование кг в г (для статических весов (временно!!!))
                            if (typeID == (int)Optima.Devices.Data.DigitalWeigher.DataManager.DWType.Static)
                            {
                                currentWeight *= 1000;
                                sCurrentWeight = currentWeight.ToString();
                            }

                            if (sender.Equals(btnObtainBoxWeight))
                            {
                                tbBoxWeight.Text = sCurrentWeight;
                                return;
                            }

                            if (sender.Equals(btnObtainBunchWeight))
                            {
                                tbBunchWeight.Text = sCurrentWeight;
                                return;
                            }

                            if (sender.Equals(btnObtainItemWeight))
                            {
                                tbItemWeight.Text = sCurrentWeight;
                                return;
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
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                // Запускаем фоновый поток
                weightProvider.Run();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }

    /// <summary>
    /// Исключение соотношений компонентов измерений
    /// </summary>
    public class MeasurementCorrelationException : Exception
    {
        public MeasurementCorrelationException(string message)
            : base(message)
        {  }
    }
}
