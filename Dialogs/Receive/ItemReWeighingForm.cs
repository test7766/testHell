using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Classes;
using WMSOffice.Controls;

namespace WMSOffice.Dialogs.Receive
{
    public partial class ItemReWeighingForm : DialogForm
    {
        private bool autoSelectDWType = false;

        public new long UserID { get; set; }

        /// <summary>
        /// Использование пакетного режима (при перевзвешивании товара по листу отбора)
        /// </summary>
        public bool UsePackageMode { get; private set; }

        public Optima.Devices.Data.DigitalWeigher.DataManager.DWType DefaultDWType { get; set; }

        private IItemReWeighingControl itemReWeighingControl = null;

        public ItemReWeighingForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            btnOK.Location = new Point(817, 8);
            btnCancel.Location = new Point(907, 8);

            btnOK.Visible = false;
            btnCancel.Text = "Закрыть";

            SetWorkMode();
            Initialize();
        }

        private void SetWorkMode()
        {
            // определение режима
            UsePackageMode = true;
        }

        public void Initialize()
        {
            // Подготовка компонента взвешивания
            itemReWeighingControl = ReWeighingProcessBuilder.CreateUI(ReWeighingProcessBuilder.DefaultReWeighingProcessType);

            pnlItemReWeighingControlHost.Controls.Clear();
            if (UsePackageMode)
            {
                var weightControl = (UserControl)itemReWeighingControl;
                pnlItemReWeighingControlHost.Controls.Add(weightControl);
                weightControl.Dock = DockStyle.Fill;
            }

            // Корректировка отображаемых областей
            if (!UsePackageMode)
            {
                var width = scContent.Panel1.Width + scContent.SplitterWidth;
                scContent.Panel2Collapsed = true;
                this.Width = width;
            }

            btnObtainWeight.Enabled = false;

            // Режим перевзвешивания по листу отбора
            if (UsePackageMode)
            {
                if (!CheckPickListBox())
                {
                    this.Close();
                    return;
                }

                // Проверка выполнения отката
                this.FormClosing += (s, e) =>
                {
                    e.Cancel = !itemReWeighingControl.TryCancelDoc();
                };

                // Завершение обработки этапа
                itemReWeighingControl.OnStageProcessingCompleted += (s, e) => 
                {
                    btnObtainWeight.Focus();
                };

                // Завершение обработки всех этапов товара
                itemReWeighingControl.OnItemProcessingCompleted += (s, e) => 
                {
                    // Получаем инструкцию
                    var instructionFlag = (int?)null;
                    itemReWeighingControl.GetInsrtuctionFlag(out instructionFlag);

                    var frmItemReWeighingSetInstruction = new ItemReWeighingSetInstructionForm() { DiscardCanceling = true, HasInstruction = Convert.ToBoolean(instructionFlag ?? 0) };
                    if (frmItemReWeighingSetInstruction.ShowDialog() == DialogResult.OK)
                    {
                        instructionFlag = Convert.ToInt32(frmItemReWeighingSetInstruction.HasInstruction);
                        itemReWeighingControl.SetInstructionFlag(instructionFlag);
                    }

                    // Завершение задания по текущей номенклатуре
                    var needMoreItems = itemReWeighingControl.SaveItemFinishProcess(false);

                    // Получаем расчетное значение веса
                    var finalWeight = (double?)null;
                    var finalWeightFlag = (string)null;
                    //var finalInstructionFlag = (int?)null;
                    itemReWeighingControl.GetFinalWeight(out finalWeight, out finalWeightFlag);
                    if (finalWeight.HasValue)
                        lblWeightValue.Text = finalWeight.ToString();

                    if (needMoreItems)
                    {
                        this.LoadDocItems(); // загрузим список товара (для обновления признака перевзвешивания)
                    }
                    else
                    {
                        if (!CheckPickListBox())
                        {
                            this.Close();
                            return;
                        }
                    }

                    tbsItemBarcode.Enabled = true;
                    stbItemID.Enabled = true;

                    btnObtainWeight.Enabled = false;

                    stbItemID.Value = string.Empty;

                    tbsItemBarcode.Text = string.Empty;
                    tbsItemBarcode.Focus();
                };

                cmbUoMValue.Enabled = false;
                tbsItemBarcode.Focus();
            }

            stbItemID.ValueReferenceQuery = "[dbo].[pr_Reweight_Get_Item_List]";
            stbItemID.UserID = this.UserID;
            stbItemID.OnVerifyValue += this.OnVerifyValue;
            stbItemID.Enter += new EventHandler(stbItemID_Enter);

            tbsItemBarcode.TextChanged += new EventHandler(tbsItemBarcode_TextChanged);
        }

        private bool CheckPickListBox()
        {
            var pickSlipBar = string.Empty; // "BR112233"; //string.Empty;
            while (true) // многократное сканирование
            {
                try
                {
                    var dlgScanBox = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                    {
                        Label = "Отсканируйте ящик, который содержит товар для перевзвешивания.",
                        Text = "Перевзвешивание товара",
                        Image = Properties.Resources.paper_box
                    };

                    dlgScanBox.Barcode = pickSlipBar;
                    if (dlgScanBox.ShowDialog() == DialogResult.OK)
                    {
                        pickSlipBar = dlgScanBox.Barcode;

                        // создание документа перевзвешивания
                        var docID = itemReWeighingControl.CreateDoc(pickSlipBar, Convert.ToInt32(this.UserID), "RW");
                        this.Text = string.Format("Повторное взвешивание товара (№ {0})", docID);

                        this.LoadDocItems(); // загрузим список товара

                        this.ClearItemProperties();
                        lblPreviousWeightValue.Text = "-";

                        return true;
                    }
                    else
                        break;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return false;
        }

        private void OnVerifyValue(object sender, WMSOffice.Controls.VerifyValueArgs e)
        {
            var control = sender as SearchTextBox;

            if (e.Success)
                control.Value = e.Value;

            if (control == stbItemID)
            {
                btnObtainWeight.Enabled = false;
                receive.ReWeightUoMTypes.Clear();

                if (e.Success)
                {
                    lblItemIDValue.Text = string.IsNullOrEmpty(e.Value) ? "-" : e.Value;
                    lblItemNameValue.Text = string.IsNullOrEmpty(e.Description) ? "-" : e.Description;
                    lblItemNameValue.ForeColor = SystemColors.ControlText;
                    lblLotNValue.Text = "-";
                    lblBoxNormValue.Text = "-";
                    lblWeightValue.Text = "-";

                    lblPreviousWeightValue.Text = "-";

                    if (!string.IsNullOrEmpty(e.Value))
                    {
                        var canObtainWeight = false;
                        
                        this.ObtainUoM();
                        
                        if (UsePackageMode)
                        {
                            lblLotNValue.Text = string.Empty;
                            canObtainWeight = true;
                        }
                        else
                        {
                            if (this.NeedScanYL())
                            {
                                if (this.ScanYL())
                                    canObtainWeight = true;
                            }
                            else
                                canObtainWeight = true;
                        }

                        if (canObtainWeight)
                        {
                            this.SetPreviousWeight();
                            btnObtainWeight.Enabled = receive.ReWeightUoMTypes.Count > 0;

                            // Режим перевзвешивания по листу отбора
                            if (UsePackageMode)
                            {
                                btnObtainWeight.Enabled = true;

                                // инициализация автоопределения весов
                                this.DefaultDWType = Optima.Devices.Data.DigitalWeigher.DataManager.DWType.Lab;
                                autoSelectDWType = false;

                                try
                                {
                                    var itemID = Convert.ToInt32(e.Value);
                                    itemReWeighingControl.CheckItemID(itemID);

                                    this.NavigateToCurrentDocItem(itemID); // позиционирование выбранного товара

                                    // Блокируем работу с поиском товара (после окончания надо восстановить)
                                    tbsItemBarcode.Enabled = false;
                                    stbItemID.Enabled = false;
                                }
                                catch (Exception ex)
                                {
                                    // Пользователь отсканировал товар не из листа отбора
                                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    btnObtainWeight.Enabled = false;
                                    ClearItemProperties();

                                    //lblPreviewWeightValue.Text = "-";

                                    tbsItemBarcode.Text = string.Empty;
                                    tbsItemBarcode.Focus();
                                }
                            }
                            //else
                            //{
                            //    this.SetPreviousWeight();
                            //    btnObtainWeight.Enabled = receive.ReWeightUoMTypes.Count > 0;
                            //}

                        }
                        else
                            btnObtainWeight.Enabled = false;

                        btnObtainWeight.Focus();
                    }
                }
                else
                {
                    lblItemNameValue.Text = "ЗНАЧЕНИЕ НЕ НАЙДЕНО!";
                    lblItemNameValue.ForeColor = Color.Red;
                }
            }
        }

        void stbItemID_Enter(object sender, EventArgs e)
        {
            stbItemID.ApplyAdditionalParameter(tbsItemBarcode.Name, tbsItemBarcode.Text);
        }

        private void tbsItemBarcode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbsItemBarcode.Text))
            {
                stbItemID.ApplyAdditionalParameter(tbsItemBarcode.Name, tbsItemBarcode.Text);
                stbItemID.VerifyValue(true, AutoSelectItemSideMode.None);
            }
        }

        #region НЕОБХОДИМОСТЬ ПОЛУЧЕНИЯ ПАРТИИ

        private bool NeedScanYL()
        {
            try
            {
                var needScanFlagYL = (int?)null;

                var itemID = Convert.ToInt32(lblItemIDValue.Text);
                var uom = cmbUoMValue.SelectedValue.ToString();
                reWeightUoMTypesTableAdapter.NeedScanYL(itemID, uom, ref needScanFlagYL);


                var needScanYL = needScanFlagYL.HasValue && needScanFlagYL.Value == 1;

                if (!needScanYL)
                    lblLotNValue.Text = string.Empty;

                return needScanYL;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
        }

        private bool ScanYL()
        {
            var itemID = Convert.ToInt32(lblItemIDValue.Text);
            var barcodeYL = (string)null;

            while (true) // многократное сканирование
            {
                try
                {
                    var dlgScannerYL = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                    {
                        Label = "Отсканируйте желтую этикетку, по которой необходимо получить повторный вес.",
                        Text = "Определение партии",
                        Image = Properties.Resources.box
                    };

                    dlgScannerYL.Barcode = barcodeYL ?? string.Empty;
                    if (dlgScannerYL.ShowDialog() == DialogResult.OK)
                    {
                        barcodeYL = dlgScannerYL.Barcode;

                        var lotn = (string)null;
                        reWeightUoMTypesTableAdapter.AdaptLotnYL(itemID, barcodeYL, ref lotn);
                        lblLotNValue.Text = lotn ?? string.Empty;
                        return true;
                    }
                    else
                        break;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return false;
        }

        #endregion

        private void cmbUoMValue_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbUoMValue.SelectedValue != null)
            {
                SetPreviousWeight();
                btnObtainWeight.Focus();
            }
        }

        private void SetPreviousWeight()
        {
            lblPreviousWeightValue.Text = "-";
            lblBoxNormValue.Text = "-";

            try
            {
                var itemID = Convert.ToInt32(lblItemIDValue.Text);
                var uom = cmbUoMValue.SelectedValue.ToString();
                var lotn = string.IsNullOrEmpty(lblLotNValue.Text) ? (string)null : lblLotNValue.Text;

                using (var dt = new Data.ReceiveTableAdapters.ReweightOldWeigthTableAdapter())
                {
                    foreach (Data.Receive.ReweightOldWeigthRow row in dt.GetData(itemID, uom, lotn))
                    {
                        lblPreviousWeightValue.Text = row.IsWeight_UomNull() ? "-" : row.Weight_Uom.ToString();
                        lblBoxNormValue.Text = row.IsIN_BXNull() ? "-" : row.IN_BX.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ObtainUoM()
        {
            try
            {
                var itemID = Convert.ToInt32(lblItemIDValue.Text);
                reWeightUoMTypesTableAdapter.Fill(receive.ReWeightUoMTypes, itemID, this.UserID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnObtainWeight_Click(object sender, EventArgs e)
        {
            try
            {
                var canObtainWeight = false;

                if (UsePackageMode)
                {
                    canObtainWeight = true;
                }
                else
                {
                    var scanYetFlag = (int?)null;

                    var itemID = Convert.ToInt32(lblItemIDValue.Text).ToString();
                    var uom = cmbUoMValue.SelectedValue.ToString();
                    var lotn = string.IsNullOrEmpty(lblLotNValue.Text) ? (string)null : lblLotNValue.Text;
                    reWeightUoMTypesTableAdapter.VerifyReWeight(itemID, uom, ref scanYetFlag, lotn);

                    var scanYet = Convert.ToBoolean(scanYetFlag ?? 0);
                    if (!scanYet || (scanYet && MessageBox.Show("Товар был ранее перевзвешен.\nВы желаете получить вес повторно?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes))
                        canObtainWeight = true;
                }

                if (canObtainWeight)
                    this.ObtainWeight();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ObtainWeight()
        {
            //var sCurrentWeight_ = "50.0";
            //var currentWeight_ = 50.0;
            //lblWeightValue.Text = sCurrentWeight_;
            //this.SaveWeight(currentWeight_);

            //// TODO для тестирования
            //this.SaveWeight(19.0F);
            ////lblPreviewWeightValue.Text = sCurrentWeight_;
            //return;

            try
            {
                #region ОПРЕДЕЛЕНИЕ ТИПА ВЕСОВ

                int typeID = (int)Optima.Devices.Data.DigitalWeigher.DataManager.DWType.Static;
                decimal minRatio = 0.5M;
                int eScaleCoef = 1000;

                if (UsePackageMode)
                {
                    var table = new Optima.Devices.Data.DigitalWeigher.TVP_12e.DW_TypesDataTable();
                    Optima.Devices.Data.DigitalWeigher.DataManager.DW_TypesTableAdapter.Fill(table);
                    table.DefaultView.Sort = string.Format("TypeID {0}", this.DefaultDWType == Optima.Devices.Data.DigitalWeigher.DataManager.DWType.Lab ? "DESC" : "ASC");

                    if (autoSelectDWType)
                    {
                        var drDWType = table.FindByTypeID((int)this.DefaultDWType);
                        typeID = drDWType.TypeID;
                        minRatio = drDWType.MinRatio;
                    }
                    else
                    {
                        var dlgSelectWeightType = new WMSOffice.Dialogs.RichListForm();
                        dlgSelectWeightType.Text = "Выберите тип весов";
                        dlgSelectWeightType.AddColumn("TypeID", "TypeID", "Код");
                        dlgSelectWeightType.AddColumn("TypeName", "TypeName", "Наименование");
                        dlgSelectWeightType.FilterChangeLevel = 0;
                        dlgSelectWeightType.FilterVisible = false;
                        dlgSelectWeightType.DataSource = table;

                        if (dlgSelectWeightType.ShowDialog() != DialogResult.OK)
                            return;

                        typeID = (dlgSelectWeightType.SelectedRow as Optima.Devices.Data.DigitalWeigher.TVP_12e.DW_TypesRow).TypeID;
                        this.DefaultDWType = (Optima.Devices.Data.DigitalWeigher.DataManager.DWType)typeID;

                        minRatio = (dlgSelectWeightType.SelectedRow as Optima.Devices.Data.DigitalWeigher.TVP_12e.DW_TypesRow).MinRatio;
                    }
                }
                else
                {                    
                    var uomToWTypeMapping = new Dictionary<string, Optima.Devices.Data.DigitalWeigher.DataManager.DWType>();
                    uomToWTypeMapping["IT"] = Optima.Devices.Data.DigitalWeigher.DataManager.DWType.Lab;
                    uomToWTypeMapping["SH"] = Optima.Devices.Data.DigitalWeigher.DataManager.DWType.Static;
                    uomToWTypeMapping["BX"] = Optima.Devices.Data.DigitalWeigher.DataManager.DWType.Static;
                    uomToWTypeMapping["PL"] = Optima.Devices.Data.DigitalWeigher.DataManager.DWType.Static;

                    var uom = cmbUoMValue.SelectedValue.ToString();
                    typeID = (int)uomToWTypeMapping[uom];
                }

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

                            lblWeightValue.Text = sCurrentWeight;
                            this.SaveWeight(currentWeight);

                            lblPreviousWeightValue.Text = sCurrentWeight;

                            // Автоматический выбор весов для следующего шага (если на i-м шаге выбраны лабораторные весы, то с учетом уменьшения веса они будут выбраны на к-м шаге, k>i )
                            if (this.DefaultDWType == Optima.Devices.Data.DigitalWeigher.DataManager.DWType.Lab)
                                autoSelectDWType = true;

                            if (!UsePackageMode)
                            {
                                this.ClearItemProperties();

                                tbsItemBarcode.Text = string.Empty;
                                tbsItemBarcode.Focus();
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

        private void SaveWeight(double weight)
        {
            // Режим перевзвешивания по листу отбора
            if (UsePackageMode)
            {
                itemReWeighingControl.SetWeight(weight);
            }
            else
            {
                var itemID = Convert.ToInt32(lblItemIDValue.Text);
                var uom = cmbUoMValue.SelectedValue.ToString();
                var lotn = string.IsNullOrEmpty(lblLotNValue.Text) ? (string)null : lblLotNValue.Text;
                reWeightUoMTypesTableAdapter.UpdateWeight(itemID, uom, weight, this.UserID, lotn);
            }
        }

        private void ClearItemProperties()
        {
            lblItemNameValue.Text = lblItemIDValue.Text = lblLotNValue.Text = tbsItemBarcode.Text = lblWeightValue.Text = stbItemID.Value = lblBoxNormValue.Text = string.Empty;
        }

        /// <summary>
        /// Загрузка позиций для взвешивания
        /// </summary>
        private void LoadDocItems()
        {
            if (!UsePackageMode)
                return;

            try
            {
                var docItems = itemReWeighingControl.GetItems();

                pickControl.ReWeighingDocItems.Clear();
                pickControl.ReWeighingDocItems.Merge(docItems);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Позиционирование выбранного товара
        /// </summary>
        /// <param name="itemID"></param>
        private void NavigateToCurrentDocItem(int itemID)
        {
            foreach (DataGridViewRow dgvr in dgvItems.Rows)
            {
                var rowItemID = Convert.ToInt32(dgvr.Cells[itmIdDataGridViewTextBoxColumn.Index].Value);
                if (rowItemID == itemID)
                {
                    dgvr.Selected = true;
                    dgvItems.FirstDisplayedScrollingRowIndex = dgvr.Index;
                    break;
                }
            }
        }

        private void dgvItems_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var boundRow = (dgvItems.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.PickControl.ReWeighingDocItemsRow;
            var flag = boundRow.IsFlag_ColorNull() ? 0 : boundRow.Flag_Color;
            var color = flag == 1 ? Color.LightGray : SystemColors.Window;

            e.CellStyle.BackColor = color;
            e.CellStyle.SelectionForeColor = color;
        }
    }
}
