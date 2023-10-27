using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Transactions;
using ErrorHandlerDialog;

namespace WMSOffice.Dialogs.WH
{
    #region Перечисление статуса построения операции (новая, существующая)
    /// <summary>
    /// Статус построения операции 
    /// </summary>
    public enum OperationBuildState
    {
        /// <summary>
        /// Новая операция
        /// </summary>
        New,

        /// <summary>
        /// Существующая операция
        /// </summary>
        Modify
    }
    #endregion

    public partial class OperationEditorForm : DialogForm
    {
        #region Свойства

        private Random rand = new Random();

        private SplashForm waitProcessForm = new SplashForm();

        private SplashForm newWaitProcessForm = new SplashForm();

        private const string FROM_LINE_TYPE = "F";
        private const string TO_LINE_TYPE = "T";
        private const string BOTH_LINE_TYPE = "";

        /// <summary>
        /// Увеличение LINE_ID на 500 при добавлении новой строки
        /// </summary>
        private const int LINE_ID_SEED = 500;

        /// <summary>
        /// Отвечает за вызов меседжбокса, спрашивающего хочет ли юзер сохранить документ без незаполеннных строк
        /// </summary>
        private bool warningEmpty;

        /// <summary>
        /// Фиктивный ид-р для добавленных пользователем строк операции
        /// </summary>
        private int fictLineID;

        /// <summary>
        /// Признак необходимости сохранения заголовка документа
        /// </summary>
        private bool docNeedToSaveHeader = true;

        /// <summary>
        /// Статус построения операции
        /// </summary>
        private OperationBuildState operationBuildState;

        /// <summary>
        /// Код типа операции
        /// </summary>
        public string OperationTypeID { get; set; }

        /// <summary>
        /// Название типа операции
        /// </summary>
        public string OperationTypeName { get; set; }

        /// <summary>
        /// Номер документа
        /// </summary>
        public long? DocID { get; set; }

        /// <summary>
        /// Признак возможности редактирования документа 
        /// </summary>
        public bool CanModify { get; set; }

        /// <summary>
        /// Выбранная строка пользователем в интерфейсе
        /// </summary>
        private Data.WH.OperationDocRowsRow SelectedLineRow
        {
            get
            {
                if (dgvOperationDetails.CurrentRow == null)
                    return null;
                return (Data.WH.OperationDocRowsRow)((DataRowView)dgvOperationDetails.CurrentRow.DataBoundItem).Row;
            }
        }

        /// <summary>
        /// Текущая строка из привязки данных к источнику
        /// </summary>
        private Data.WH.OperationDocRowsRow CurrentLineRow
        {
            get
            {
                var dataRowView = (DataRowView)(operationDocRowsBindingSource.CurrencyManager.Current);
                if (dataRowView != null)
                    return dataRowView.Row as Data.WH.OperationDocRowsRow;
                return null;
            }
        }

        private Data.WH.OperationDocHeaderRow OperationHeader
        {
            get
            {
                return (wH.OperationDocHeader.Rows.Count == 0) ? null : wH.OperationDocHeader[0];
            }
        }

        #endregion

        #region Основные события и инициализация

        public OperationEditorForm(OperationBuildState operationBuildState)
        {
            InitializeComponent();
            this.operationBuildState = operationBuildState;
            ApplyOperation(DialogResult.None);
        }

        private void OperationEditorForm_Load(object sender, EventArgs e)
        {
            try
            {
                Config.LoadDataGridViewSettings("OperationEditorForm", dgvOperationDetails);
            }
            catch (Exception)
            {
                MessageBox.Show(@"У вас нет прав на загрузку и сохранение конфигурации из файла");
            }
            LoadJDDocTypes();

        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            AdaptDocHeader();
            SetInterfaceSettings();
            this.SetDefaultGeneralColumnsLayout();

            // Если это существующий документ -> загрузим строки операции
            if (operationBuildState == OperationBuildState.Modify)
            {
                LoadOperationRows();
                CheckAccessForEditDocument();
                dgvOperationDetails.Focus();
            }
            else
                tbDescription.Focus();
        }

        /// <summary>
        /// Установка расположения основных колонок по умолчанию
        /// </summary>
        private void SetDefaultGeneralColumnsLayout()
        {
            foreach (DataGridViewColumn column in this.dgvOperationDetails.Columns)
                if (column.DataPropertyName == "Item_ID")
                {
                    column.DisplayIndex = 0;
                    break;
                }

            foreach (DataGridViewColumn column in this.dgvOperationDetails.Columns)
                if (column.DataPropertyName == "ItemName")
                {
                    column.DisplayIndex = 1;
                    break;
                }

            foreach (DataGridViewColumn column in this.dgvOperationDetails.Columns)
                if (column.DataPropertyName == "Lot_Number")
                {
                    column.DisplayIndex = 2;
                    break;
                }

            foreach (DataGridViewColumn column in this.dgvOperationDetails.Columns)
                if (column.DataPropertyName == "VendorLot")
                {
                    column.DisplayIndex = 3;
                    break;
                }

            foreach (DataGridViewColumn column in this.dgvOperationDetails.Columns)
                if (column.DataPropertyName == "ExpDate")
                {
                    column.DisplayIndex = 4;
                    break;
                }

            foreach (DataGridViewColumn column in this.dgvOperationDetails.Columns)
                if (column.DataPropertyName == "Location")
                {
                    column.DisplayIndex = 5;
                    break;
                }

            foreach (DataGridViewColumn column in this.dgvOperationDetails.Columns)
                if (column.DataPropertyName == "Quantity")
                {
                    column.DisplayIndex = 6;
                    break;
                }

            foreach (DataGridViewColumn column in this.dgvOperationDetails.Columns)
                if (column.DataPropertyName == "Location_To")
                {
                    if (IsMovementOperation() || IsVirtualMovementOperation())
                    {
                        column.DisplayIndex = 7;
                        break;
                    }
                }

            foreach (DataGridViewColumn column in this.dgvOperationDetails.Columns)
                if (column.DataPropertyName == "LotStatusCode")
                {
                    column.DisplayIndex = (IsMovementOperation() || IsVirtualMovementOperation()) ? 8 : 7;
                    break;
                }

            foreach (DataGridViewColumn column in this.dgvOperationDetails.Columns)
                if (column.DataPropertyName == "LotStatus")
                {
                    column.DisplayIndex = (IsMovementOperation() || IsVirtualMovementOperation()) ? 9 : 8;
                    break;
                }
        }

        private void SetInterfaceSettings()
        {
            btnOK.Location = new Point(896, 8);
            btnCancel.Location = new Point(986, 8);

            Text = string.Format("{0} - {1} операция", OperationTypeName.ToUpper(), (operationBuildState == OperationBuildState.New ? "новая*" : "существующая"));
            SetDocumentAccessState(operationBuildState == OperationBuildState.New);

            // Если открыта операция на редактирование - тогда заблокируем секцю нередактируемых заголовков
            if (operationBuildState == OperationBuildState.Modify)
            {
                LockDocHeaderItems();
                //this.CheckAccessForEditDocument();
            }

            // Если выбрана операция перемещения - отобразим доп. колонки
            if (IsMovementOperation() || IsVirtualMovementOperation())
                ShowAdditionalMovementOperationColumns();

            // Если выбрана операция списания - заблокируем склад "куда"
            if (IsWriteOffOperation())
                LockDestinationWarehouseItems();

            docNeedToSaveHeader = (operationBuildState == OperationBuildState.New);
            btnOK.Enabled = btnAddOperation.Enabled = btnRemoveOperation.Enabled = (operationBuildState == OperationBuildState.Modify && CanModify);
        }

        /// <summary>
        /// Адаптация заголовка документа
        /// </summary>
        private void AdaptDocHeader()
        {
            if (operationBuildState == OperationBuildState.New)
            {
                Data.WH.OperationDocHeaderRow newOperationRow = wH.OperationDocHeader.NewOperationDocHeaderRow();
                newOperationRow.DocDate = DateTime.Now;
                newOperationRow.IsVirtual = false;
                newOperationRow.Description = string.Empty;
                newOperationRow.Amount_UAH = 0;
                wH.OperationDocHeader.AddOperationDocHeaderRow(newOperationRow);
            }
            else
                try
                {
                    operationDocHeaderTableAdapter.Fill(wH.OperationDocHeader, DocID, UserID);
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.ToString(), "Ошибка загрузки заголовка документа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void LoadOperationRows()
        {
            BackgroundWorker loadWorker = new BackgroundWorker();
            loadWorker.DoWork += new DoWorkEventHandler(loadWorker_DoWork);
            loadWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(loadWorker_RunWorkerCompleted);
            operationDocRowsBindingSource.DataSource = null;
            waitProcessForm.ActionText = "Загрузка строк операции..";
            loadWorker.RunWorkerAsync();
            waitProcessForm.ShowDialog();
        }

        private void loadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = operationDocRowsTableAdapter.GetData(UserID, DocID);
            }
            catch (Exception error)
            {
                e.Result = error;
            }
        }

        private void loadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
            {
                MessageBox.Show((e.Result as Exception).ToString(), "Ошибка загрузки строк операции", MessageBoxButtons.OK, MessageBoxIcon.Error);
                wH.OperationDocRows.Clear();
            }
            else
            {
                wH.OperationDocRows.Merge(e.Result as Data.WH.OperationDocRowsDataTable);
                #region Пересчет сумм
                // !!! Это необходимо для срабатывания пересчета сумм
                foreach (Data.WH.OperationDocRowsRow row in wH.OperationDocRows)
                {
                    row.Line_ID = row.Line_ID;
                    row.SSCC_From = row.SSCC_From == null ? null : row.SSCC_From.Trim();
                    row.SSCC_To = row.SSCC_To == null ? null : row.SSCC_To.Trim();
                }
                RecalculateAmounts();
                #endregion
                wH.OperationDocRows.AcceptChanges();
                operationDocRowsBindingSource.DataSource = this.wH.OperationDocRows;
                foreach (DataGridViewRow row in dgvOperationDetails.Rows)
                {
                    CheckErrorsAndSetFill(row);
                }
            }

            waitProcessForm.CloseForce();
        }


        /// <summary>
        /// Определение доступности отображения элементов формы
        /// </summary>
        /// <param name="isDisable"></param>
        private void SetDocumentAccessState(bool isDisable)
        {
            tbDocID.ReadOnly =
            tbBatchNumber.ReadOnly =
            tbJDDocNumber.ReadOnly =
            tbTSDJobType.ReadOnly =
            tbTSDJobNumber.ReadOnly =
            tbEmployee.ReadOnly =
            tbDocStatus.ReadOnly =
            tbDocStatusID.ReadOnly =
            isDisable;
        }

        /// <summary>
        /// Получение справочника типов документов JD
        /// </summary>
        private void LoadJDDocTypes()
        {
            try
            {
                bool whValidated = operationBuildState == OperationBuildState.Modify ? true : Convert.ToBoolean(tbWarehouseFrom.Tag);
                string wh = whValidated ? tbWarehouseFrom.Text : null;

                jDDocTypesTableAdapter.Fill(wH.JDDocTypes, UserID, OperationTypeID, wh);
                //this.jDDocTypesTableAdapter.Fill(this.wH.JDDocTypes, this.UserID, this.OperationTypeID, this.cmbWarehouseFrom.SelectedValue == null ? null : this.cmbWarehouseFrom.SelectedValue.ToString());
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString(), "Ошибка загрузки справочника типов документов JD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Блокировка редактирования элементов шапки уже существующего документа
        /// </summary>
        private void LockDocHeaderItems()
        {
            tbDocID.ReadOnly =
            tbBatchNumber.ReadOnly =
            tbJDDocNumber.ReadOnly =
            tbTSDJobType.ReadOnly =
            tbTSDJobNumber.ReadOnly =
            tbDocStatus.ReadOnly =
            tbDocStatusID.ReadOnly =
            tbEmployee.ReadOnly =
            tbDescription.ReadOnly =
            tbWarehouseFrom.ReadOnly =
            tbWarehouseTo.ReadOnly =
            true;

            dtDocDate.Enabled =
            cmbJDDocType.Enabled =
            false;
        }

        /// <summary>
        /// Проверка документа на доступность редактирования
        /// </summary>
        private void CheckAccessForEditDocument()
        {
            if (!CanModify)
            {
                btnAddOperation.Enabled = btnRemoveOperation.Enabled = false;
                dgvOperationDetails.ReadOnly = true;
                dgvOperationDetails.EndEdit();
                MessageBox.Show(@"Документ НЕ подлежит изменениям!", @"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Отображение дополнительных колонок при перемещении
        /// </summary>
        private void ShowAdditionalMovementOperationColumns()
        {
            dgvOperationDetails.Columns[Location_To.Name].Visible = true;
            dgvOperationDetails.Columns[iCLocationToDataGridViewTextBoxColumn.Name].Visible = true;
            dgvOperationDetails.Columns[SSCC_To.Name].Visible = true;
        }

        private void LockDestinationWarehouseItems()
        {
            tbWarehouseTo.ReadOnly = true;
        }

        #endregion

        #region Вставка различной информации в Грид

        /// <summary>
        /// Вставка информации по товару из справочника
        /// </summary>
        /// <param name="rowDestination"></param>
        /// <param name="rowItemInfo"></param>
        private void InsertItemInfo(Data.WH.OperationDocRowsRow rowDestination, Data.WH.ItemsRow rowItemInfo)
        {
            rowDestination.Item_ID = (int)rowItemInfo.Item_ID; // TODO Узнать насчет нестыковки типов
            rowDestination.ItemName = rowItemInfo.Item;
            rowDestination.Manufacturer = rowItemInfo.Manufacturer;
            rowDestination.UnitOfMeasure = rowItemInfo.UnitOfMeasure;
            //rowDestination.Quantity = (decimal)rowItemInfo.Qty; // TODO Узнать насчет нестыковки типов
        }

        /// <summary>
        /// Вставка информации по партии из справочника
        /// </summary>
        /// <param name="rowDestination"></param>
        /// <param name="rowLotInfo"></param>
        private void InsertLotInfo(Data.WH.OperationDocRowsRow rowDestination, Data.WH.LotsRow rowLotInfo)
        {
            rowDestination.VendorLot = rowLotInfo.VendorLot;
            rowDestination.Lot_Number = rowLotInfo.LotNumber;
            rowDestination.ExpDate = rowLotInfo.ExpDate;
            rowDestination.LotStatusCode = rowLotInfo.LotStatusCode;
            rowDestination.LotStatus = rowLotInfo.LotStatus;
            rowDestination.GLCategory = rowLotInfo.GLCategory;
            rowDestination.CostPrice = (decimal)rowLotInfo.CostPrice; // TODO Узнать насчет нестыковки типов

            if (!rowLotInfo.IsBasePriceNull())
                rowDestination.BasePrice = rowLotInfo.BasePrice;
            else
                rowDestination.SetBasePriceNull();

            rowDestination.SSCC_From = rowLotInfo.SSCC == null ? "" : rowLotInfo.SSCC.Trim();
        }

        /// <summary>
        /// Вставка информации по партии и месту из справочника
        /// </summary>
        /// <param name="rowDestination"></param>
        /// <param name="rowLocationInfo"></param>
        private void InsertLocationInfo(Data.WH.OperationDocRowsRow rowDestination, Data.WH.LocationsRow rowLocationInfo)
        {
            rowDestination.VendorLot = rowLocationInfo.VendorLot;
            rowDestination.Lot_Number = rowLocationInfo.LotNumber;
            rowDestination.ExpDate = rowLocationInfo.ExpDate;
            rowDestination.LotStatusCode = rowLocationInfo.LotStatusCode;
            rowDestination.LotStatus = rowLocationInfo.LotStatus;
            rowDestination.GLCategory = rowLocationInfo.GLCategory;
            if (rowDestination.FT != TO_LINE_TYPE)
                rowDestination.Location = rowLocationInfo.Location;
            rowDestination.IC_Location = rowLocationInfo.IC_Location;
            rowDestination.CostPrice = rowLocationInfo.CostPrice; // TODO Узнать насчет нестыковки типов

            if (!rowLocationInfo.IsBasePriceNull())
                rowDestination.BasePrice = rowLocationInfo.BasePrice;
            else
                rowDestination.SetBasePriceNull();

            rowDestination.SSCC_From = rowLocationInfo.SSCC == null ? "" : rowLocationInfo.SSCC.Trim();
        }

        /// <summary>
        /// Вставка информации по SSCC из справочника
        /// </summary>
        /// <param name="rowDestination"></param>
        /// <param name="rowSSCCInfo"></param>
        private void InsertSSCCInfo(Data.WH.OperationDocRowsRow rowDestination, Data.WH.SSCCByLocationRow rowSSCCInfo)
        {
            rowDestination.SSCC_From = rowSSCCInfo.SSCC == null ? "" : rowSSCCInfo.SSCC.Trim();
        }

        /// <summary>
        /// Вставка информации по SSCC-to из справочника
        /// </summary>
        /// <param name="rowDestination"></param>
        /// <param name="rowSSCCInfo"></param>
        private void InsertSSCC_ToInfo(Data.WH.OperationDocRowsRow rowDestination, Data.WH.SSCCByLocationRow rowSSCCInfo)
        {
            rowDestination.SSCC_To = rowSSCCInfo.SSCC == null ? "" : rowSSCCInfo.SSCC.Trim();
        }

        /// <summary>
        /// Вставка места "куда" из справочника
        /// </summary>
        private void InsertLocationList_ToInfo(Data.WH.OperationDocRowsRow rowDestination, Data.WH.GetLocationListRow rowLocationListInfo)
        {
            if (rowDestination.FT == BOTH_LINE_TYPE)
            {
                if (dgvOperationDetails.CurrentCell.OwningColumn.DataPropertyName == wH.OperationDocRows.LocationColumn.Caption)
                    rowDestination.Location = rowLocationListInfo.Location_ID;
                if (dgvOperationDetails.CurrentCell.OwningColumn.DataPropertyName == wH.OperationDocRows.Location_ToColumn.Caption)
                    rowDestination.Location_To = rowLocationListInfo.Location_ID;
            }
            else
            {
                if (rowDestination.FT == FROM_LINE_TYPE)
                    rowDestination.Location = rowLocationListInfo.Location_ID;
                if (rowDestination.FT == TO_LINE_TYPE)
                    rowDestination.Location = rowLocationListInfo.Location_ID;
            }
        }

        #region Логическое определение типа текущей операции
        /// <summary>
        /// Определения того, является ли текущая операция пересортом серии?
        /// </summary>
        /// <returns></returns>
        private bool IsRegradingOfLotsOperation()
        {
            return (OperationTypeID == "I");
        }

        /// <summary>
        /// Определения того, является ли текущая операция пересортом товаров?
        /// </summary>
        /// <returns></returns>
        private bool IsRegradingOfGoodsOperation()
        {
            return (OperationTypeID == "P");
        }

        /// <summary>
        /// Определения того, является ли текущая операция перемещением?
        /// </summary>
        /// <returns></returns>
        private bool IsMovementOperation()
        {
            return (OperationTypeID == "M");
        }

        /// <summary>
        /// Определение того, является ли текущая операция виртуальным перемещением?
        /// </summary>
        /// <returns></returns>
        private bool IsVirtualMovementOperation()
        {
            return (OperationTypeID == "V");
        }

        /// <summary>
        /// Определения того, является ли текущая операция списанием?
        /// </summary>
        /// <returns></returns>
        private bool IsWriteOffOperation()
        {
            return (OperationTypeID == "S");
        }
        #endregion

        /// <summary>
        /// Старый способ при клике по гриду
        /// </summary>
        private void dgvOperationDetails_Enter(object sender, EventArgs e)
        {
            //dgvOperationDetails.RowLeave += new DataGridViewCellEventHandler(dgvOperationDetails_RowLeave);
            if (!this.docNeedToSaveHeader)
                return;

            //if (this.operationBuildState == OperationBuildState.New && this.docNeedToSaveHeader && this.ValidateOperationHeader() &&
            //    MessageBox.Show("Продолжить сохранение заголовка операции?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            if (this.operationBuildState == OperationBuildState.New && this.docNeedToSaveHeader && this.ValidateOperationHeader())
                this.SaveOperationHeader();
            else
                gbOperationHeader.Focus();
        }

        /// <summary>
        /// Валидация заголовка операции
        /// </summary>
        /// <returns></returns>
        public bool ValidateOperationHeader()
        {
            StringBuilder sbError = new StringBuilder();
            sbError.Append(/*this.OperationHeader.IsWarehouseID_FromNull()*/ !Convert.ToBoolean(tbWarehouseFrom.Tag) ? "Склад \"откуда\" не выбран.\n" : string.Empty);
            sbError.Append(/*this.OperationHeader.IsWarehouseID_ToNull()*/ !Convert.ToBoolean(tbWarehouseTo.Tag) ? "Склад \"куда\" не выбран.\n" : string.Empty);
            sbError.Append(this.OperationHeader.IsJD_DocTypeNull() ? "Тип документа JD не выбран.\n" : string.Empty);

            if (sbError.Length != 0)
            {
                MessageBox.Show(string.Format("Обнаружены следующие ошибки:\n{0}", sbError), "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Сохранение заголовка операции
        /// </summary>
        public void SaveOperationHeader()
        {
            try
            {
                // Если операция - виртуальное перемещение, то установим признак виртуальной операции
                if (IsVirtualMovementOperation())
                    OperationHeader.IsVirtual = true;


                OperationHeader.Doc_ID = Convert.ToInt64(operationDocHeaderTableAdapter.CreateOperationDoc(UserID, OperationTypeID,
                                                              OperationHeader.JD_DocType, OperationHeader.DocDate,
                                                              OperationHeader.Description, OperationHeader.WarehouseID_From,
                                                              OperationHeader.WarehouseID_To, OperationHeader.IsVirtual));

                operationDocHeaderBindingSource.ResetCurrentItem(); // Обновим элемент привязки
                //MessageBox.Show("Заголовок документа успешно сохранен.\nТеперь можно добавлять строки операции.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Получим идентификатор только что созданного документа
                DocID = OperationHeader.Doc_ID;

                LockDocHeaderItems();
                docNeedToSaveHeader = false;
                btnOK.Enabled = btnAddOperation.Enabled = btnRemoveOperation.Enabled = true;
                //Делаем сразу вставку первой пустой строки
                AddOperationLine();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString(), "Ошибка сохранения заголовка операции", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ApplyOperation(DialogResult.OK);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ApplyOperation(DialogResult.Cancel);
        }

        private void ApplyOperation(DialogResult agreedResult)
        {
            DialogResult = agreedResult;
        }

        private void OperationEditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Config.SaveDataGridViewSettings("OperationEditorForm", dgvOperationDetails);
            }
            catch (Exception)
            {
                MessageBox.Show(@"У вас нет прав на загрузку и сохранение конфигурации из файла");
            }
            if (DialogResult == DialogResult.OK)
            {
                e.Cancel = !SaveChanges();
            }
        }

        #endregion

        #region Вставка строк

        private List<int> BatchesList = new List<int>();

        private int CheckBatchId()
        {
            int batchId = rand.Next(1, 1000000);
            if (!BatchesList.Contains(batchId))
            {
                BatchesList.Add(batchId);
                return batchId;
            }
            else
                CheckBatchId();

            return batchId;
        }

        /// <summary>
        /// Метод, проверяющий, есть ли хоть одно значение не равное пустому/нулевому
        /// </summary>
        /// <param name="dataRow">Строка данных</param>
        /// <returns>true - если есть значение, false - если нет</returns>
        private bool CheckEmptyCellsInGrid(Data.WH.OperationDocRowsRow dataRow)
        {
            if (dataRow.FT == BOTH_LINE_TYPE)
            {
                if ((dataRow.Item_ID != 0 || !String.IsNullOrEmpty(dataRow.Lot_Number) ||
                    !String.IsNullOrEmpty(dataRow.Location) ||
                    !String.IsNullOrEmpty(dataRow.Location_To)) && dataRow.Quantity != 0)
                    return true;
            }
            else
                if ((dataRow.Item_ID != 0 || !String.IsNullOrEmpty(dataRow.Lot_Number) ||
                     !String.IsNullOrEmpty(dataRow.Location)) && dataRow.Quantity != 0)
                    return true;

            return false;
        }

        private void btnAddOperation_Click(object sender, EventArgs e)
        {
            AddOperationLine();
        }

        /// <summary>
        /// Добавление новой строки операции в перечень
        /// </summary>
        private void AddOperationLine()
        {
            SaveOperation();

            foreach (DataGridViewRow row in dgvOperationDetails.Rows)
                if (row != null)
                    CheckErrorsAndSetFill(row);


            bool isInserted = false;
            if (!IsRegradingOfLotsOperation() && !IsRegradingOfGoodsOperation())
            {
                if (dgvOperationDetails.RowCount - 1 >= 0)
                {
                    var row = dgvOperationDetails.Rows[dgvOperationDetails.RowCount - 1];
                    var dataRow = (Data.WH.OperationDocRowsRow)((DataRowView)row.DataBoundItem).Row;
                    isInserted = CheckEmptyCellsInGrid(dataRow);
                }
                //!CheckEmptyAndNotValidCells(dgvOperationDetails.Rows[dgvOperationDetails.RowCount - 1],
                //                            dgvOperationDetails);
            }
            else
            {
                if (dgvOperationDetails.RowCount - 1 >= 0 && dgvOperationDetails.RowCount - 2 >= 0)
                {
                    var row1 = dgvOperationDetails.Rows[dgvOperationDetails.RowCount - 2];
                    var dataRow1 = (Data.WH.OperationDocRowsRow)((DataRowView)row1.DataBoundItem).Row;
                    var row2 = dgvOperationDetails.Rows[dgvOperationDetails.RowCount - 1];
                    var dataRow2 = (Data.WH.OperationDocRowsRow)((DataRowView)row2.DataBoundItem).Row;

                    isInserted = CheckEmptyCellsInGrid(dataRow1) && CheckEmptyCellsInGrid(dataRow2);
                    //!CheckEmptyAndNotValidCells(dgvOperationDetails.Rows[dgvOperationDetails.RowCount - 1], dgvOperationDetails) &&
                    //!CheckEmptyAndNotValidCells(dgvOperationDetails.Rows[dgvOperationDetails.RowCount - 2], dgvOperationDetails);
                }
            }

            if (isInserted || dgvOperationDetails.RowCount == 0)
            {
                //Random rand = new Random();
                switch (OperationTypeID)
                {
                    case "I":   //Вставка 2-х строк
                    case "P":
                        int batchId = CheckBatchId();
                        InsertLine(FROM_LINE_TYPE, false, batchId);
                        dgvOperationDetails.CurrentCell = dgvOperationDetails[1, dgvOperationDetails.RowCount - 1];
                        InsertLine(TO_LINE_TYPE, false, batchId);
                        break;
                    case "M":
                    case "V":
                        int batchId1 = CheckBatchId();
                        InsertLine(BOTH_LINE_TYPE, false, batchId1);
                        dgvOperationDetails.CurrentCell = dgvOperationDetails[1, dgvOperationDetails.RowCount - 1];
                        break;
                    case "S":
                        int batchId2 = CheckBatchId();
                        InsertLine(FROM_LINE_TYPE, false, batchId2);
                        dgvOperationDetails.CurrentCell = dgvOperationDetails[1, dgvOperationDetails.RowCount - 1];
                        break;
                }
            }
            dgvOperationDetails.Refresh();
        }

        /// <summary>
        ///  Создание и добавление новой строки операции с batch_id
        /// </summary>
        /// <param name="lineTypeCode">Код операции</param>
        /// <param name="delayInsertion">Признак отложенного добавления созданной строки в коллекцию</param>
        /// <param name="batch_id">Идентификатор пакета строк в базе</param>
        /// <returns>Вставленная строка данных</returns>
        private Data.WH.OperationDocRowsRow InsertLine(string lineTypeCode, bool delayInsertion, long batch_id)
        {
            Data.WH.OperationDocRowsRow newOperationLineRow = wH.OperationDocRows.NewOperationDocRowsRow();
            newOperationLineRow.FT = lineTypeCode;
            fictLineID += LINE_ID_SEED;
            newOperationLineRow.Line_ID = -fictLineID;
            newOperationLineRow.Batch_ID = batch_id;
            newOperationLineRow.BasePriceAmount = newOperationLineRow.IsBasePriceAmountNull() ? 0 : (decimal)newOperationLineRow.BasePriceAmount;
            newOperationLineRow.BasePrice = newOperationLineRow.IsBasePriceNull() ? 0 : (decimal)newOperationLineRow.BasePrice;
            newOperationLineRow.CostPrice = newOperationLineRow.IsCostPriceNull() ? 0 : (decimal)newOperationLineRow.CostPrice;
            newOperationLineRow.CostAmount = newOperationLineRow.IsCostAmountNull() ? 0 : (decimal)newOperationLineRow.CostAmount;
            newOperationLineRow.Quantity = newOperationLineRow.IsQuantityNull() ? 1 : (decimal)newOperationLineRow.Quantity;
            newOperationLineRow.Item_ID = newOperationLineRow.IsItem_IDNull() ? 0 : (int)newOperationLineRow.Item_ID;
            newOperationLineRow.ExpDate = newOperationLineRow.IsExpDateNull() ? DateTime.Now.Date : (DateTime)newOperationLineRow.ExpDate;

            // Добавим запись если не установлен признак отложенного добавления
            if (!delayInsertion)
                wH.OperationDocRows.AddOperationDocRowsRow(newOperationLineRow);

            return newOperationLineRow;
        }
        #endregion

        #region Сохранение документа
        /// <summary>
        /// Сохранение изменений с предварительной валидацией
        /// </summary>
        /// <returns></returns>
        private bool SaveChanges()
        {
            if (!CanModify)
                return true;

            try
            {
                RecalculateAmounts();
                SaveOperation();
                VerifyCells();
                foreach (DataGridViewRow row in dgvOperationDetails.Rows)
                {
                    CheckErrorsAndSetFill(row);
                }

                if (warningEmpty)
                {
                    if (MessageBox.Show(
                        @"Все cтроки, которые не полностью заполнены сохранены не будут! Вы действительно хотите выполнить сохранение?",
                        @"Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                        return false;
                }

                dgvOperationDetails.Refresh();

                CommitOperation();

                return true;
            }

            catch (Exception error)
            {
                MessageBox.Show(error.Message, @"Ошибка сохранения операции", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Фиксирование операции
        /// </summary>
        private void CommitOperation()
        {
            try
            {
                operationDocHeaderTableAdapter.SaveOperationDoc(UserID, DocID);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// Сохранение операции в транзакции
        /// </summary>
        private void SaveOperation()
        {
            //Debug.WriteLine("SaveOperation() ");
            // Определим уровень изоляции для транзакции
            TransactionOptions tranOptions = new TransactionOptions();
            tranOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;

            // Открываем транзакцию
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, tranOptions))
            {
                try
                {
                    SaveOperationLines();

                    // Фиксирование транзакции
                    scope.Complete();
                }
                catch (Exception)
                {
                    //throw error;
                }
            }
        }

        /// <summary>
        /// Сохранение строк операции
        /// </summary>
        private void SaveOperationLines()
        {
            StringBuilder sbErrorText = new StringBuilder(); // накопитель сообщений об ошибках сохранения

            foreach (Data.WH.OperationDocRowsRow operationLine in wH.OperationDocRows)
            {
                if (operationLine.RowState == DataRowState.Unchanged)
                    continue;

                if (operationLine.RowState == DataRowState.Deleted)
                    DeleteOperationLine(operationLine, ref sbErrorText);

                if (operationLine.RowState == DataRowState.Added)
                {
                    int line_id;
                    // Если текущая операция - "перемещение" -> проверим 2 составляющие строки
                    if ((IsMovementOperation() || IsVirtualMovementOperation()) && CheckForEmptyCells(operationLine))
                    {
                        line_id = InsertOperationLine(operationLine, operationLine.Location,
                                                      operationLine.IsSSCC_FromNull()
                                                          ? string.Empty
                                                          : operationLine.SSCC_From, FROM_LINE_TYPE, ref sbErrorText);
                        operationLine.Line_ID = line_id;

                        InsertOperationLine(operationLine, operationLine.Location_To,
                                            operationLine.IsSSCC_ToNull() ? string.Empty : operationLine.SSCC_To,
                                            TO_LINE_TYPE, ref sbErrorText);
                    }
                    //При пересорте мы сохраняем или 2 строки сразу, если они прошли валидацию или ни одной вообще
                    if (IsRegradingOfLotsOperation() || IsRegradingOfGoodsOperation())
                    {
                        var secondLine = ValidationForPeresort(operationLine);
                        if (secondLine != null && CheckForEmptyCells(secondLine) && CheckForEmptyCells(operationLine) &&
                            secondLine.FT != operationLine.FT)
                        {
                            InsertOperationLine(secondLine, secondLine.Location,
                                                secondLine.IsSSCC_FromNull()
                                                    ? string.Empty
                                                    : secondLine.SSCC_From, secondLine.FT,
                                                ref sbErrorText);
                            secondLine.AcceptChanges();
                            InsertOperationLine(operationLine, operationLine.Location,
                                                operationLine.IsSSCC_FromNull()
                                                    ? string.Empty
                                                    : operationLine.SSCC_From, operationLine.FT,
                                                ref sbErrorText);
                            operationLine.AcceptChanges();
                        }
                    }

                    if (IsWriteOffOperation() && CheckForEmptyCells(operationLine))
                    {
                        line_id = InsertOperationLine(operationLine, operationLine.Location,
                                                      operationLine.IsSSCC_FromNull()
                                                          ? string.Empty
                                                          : operationLine.SSCC_From, operationLine.FT,
                                                      ref sbErrorText);
                        operationLine.Line_ID = line_id;
                    }
                }

                if (operationLine.RowState == DataRowState.Modified)
                {
                    if (CheckForEmptyCells(operationLine))
                    {
                        UpdateOperationLine(operationLine,
                                            operationLine.Location,
                                            IsMovementOperation() || IsVirtualMovementOperation()
                                                ? operationLine.Location_To
                                                : null,
                                            operationLine.IsSSCC_FromNull() ? string.Empty : operationLine.SSCC_From,
                                            IsMovementOperation() || IsVirtualMovementOperation()
                                                ? (operationLine.IsSSCC_ToNull() ? string.Empty : operationLine.SSCC_To)
                                                : null,
                                            ref sbErrorText);
                    }
                }
                if (sbErrorText.Length > 0)
                    throw new Exception(sbErrorText.ToString());
            }
        }

        private Data.WH.OperationDocRowsRow ValidationForPeresort(Data.WH.OperationDocRowsRow operationLine)
        {
            Data.WH.OperationDocRowsRow secondLine;
            foreach (Data.WH.OperationDocRowsRow row in wH.OperationDocRows)
                if (row.Batch_ID == operationLine.Batch_ID && row.FT != operationLine.FT)
                {
                    secondLine = row;
                    return secondLine;
                }

            return null;
        }

        /// <summary>
        /// Добавление строки операции
        /// </summary>
        private int InsertOperationLine(Data.WH.OperationDocRowsRow operationLine, string location, string sscc, string FT, ref StringBuilder sbErrorMsg)
        {
            sscc = sscc ?? string.Empty;
            int line_id = 0;
            try
            {
                var obj = operationDocRowsTableAdapter.InsertOperationLine(UserID, DocID, FT,
                  operationLine.Item_ID, operationLine.Lot_Number, location, operationLine.UnitOfMeasure,
                  operationLine.Quantity, operationLine.CostPrice, operationLine.CostAmount, sscc, null, operationLine.Batch_ID);

                foreach (Data.WH.OperationDocRowsRow item in obj)
                {
                    if (item != null)
                    {
                        //batch_id = item.Batch_ID;
                        line_id = item.Line_ID;
                    }
                }
            }
            catch (Exception error)
            {
                sbErrorMsg.Append(error.Message);
                sbErrorMsg.Append("\n");
            }
            return line_id;
        }

        /// <summary>
        /// Обновление строки операции
        /// </summary>
        private void UpdateOperationLine(Data.WH.OperationDocRowsRow operationLine, string location, string location_to, string sscc, string sscc_to, ref StringBuilder sbErrorMsg)
        {
            sscc = sscc ?? string.Empty;
            sscc_to = sscc_to ?? string.Empty;

            try
            {
                operationDocRowsTableAdapter.UpdateOperationLine(UserID, DocID,
                                                                 operationLine.Line_ID,
                                                                 operationLine.Item_ID, operationLine.Lot_Number,
                                                                 location, location_to, operationLine.UnitOfMeasure,
                                                                 operationLine.Quantity, operationLine.CostPrice,
                                                                 operationLine.CostAmount, sscc, sscc_to);

                operationLine.AcceptChanges();

            }
            catch (Exception error)
            {
                sbErrorMsg.Append(error.Message);
                sbErrorMsg.Append("\n");
            }
        }

        /// <summary>
        /// Удаление строки операции
        /// </summary>
        private void DeleteOperationLine(Data.WH.OperationDocRowsRow operationLine, ref StringBuilder sbErrorMsg)
        {
            try
            {
                var abcd =
                    Convert.ToInt64(
                        operationLine[this.wH.OperationDocRows.Line_IDColumn.Caption, DataRowVersion.Original]);

                //this.operationDocRowsTableAdapter.DeleteOperationLine(this.UserID, this.DocID, Convert.ToInt64(operationLine[this.wH.OperationDocRows.Line_IDColumn.Caption, DataRowVersion.Original]));
                //this.operationDocRowsTableAdapter.DeleteOperationLine(this.UserID, this.DocID, operationLine.Item_ID);
                //operationLine.AcceptChanges();
            }
            catch (Exception error)
            {
                sbErrorMsg.Append(error.Message);
                sbErrorMsg.Append("\n");
            }
        }

        #endregion

        #region Пересчет суммы

        /// <summary>
        /// Пересчет сумм для строк операции и общих итоговых
        /// </summary>
        private void RecalculateAmounts()
        {
            decimal sumF = 0; // общая сумма по недостачам
            decimal sumT = 0; // общая сумма по излишкам
            decimal sum; // их разница

            decimal amountF; // сумма по недостачам
            decimal amountT; // сумма по излишкам

            foreach (Data.WH.OperationDocRowsRow operationLine in wH.OperationDocRows)
            {
                DataRowState savedRowState;
                // Если строка удалена - пропускаем
                if (operationLine.RowState == DataRowState.Deleted)
                    continue;

                decimal quantity = operationLine.IsQuantityNull() ? 0 : operationLine.Quantity;
                decimal costPrice = operationLine.IsCostPriceNull() ? 0 : operationLine.CostPrice;
                decimal basePrice = operationLine.IsBasePriceNull() ? 0 : operationLine.BasePrice;
                decimal costAmount;
                decimal basePriceAmount;

                // Пересчет с обновленем запускаем в случае добавления и модификации текущей строки
                if (operationLine.RowState == DataRowState.Added || operationLine.RowState == DataRowState.Modified || operationLine.RowState == DataRowState.Unchanged)
                {
                    savedRowState = operationLine.RowState;
                    if ((costAmount = quantity * costPrice) != (operationLine.IsCostAmountNull() ? 0 : operationLine.CostAmount))
                        operationLine.CostAmount = costAmount;

                    if ((basePriceAmount = quantity * basePrice) != (operationLine.IsBasePriceAmountNull() ? 0 : operationLine.BasePriceAmount))
                        operationLine.BasePriceAmount = basePriceAmount;
                }

                amountF = amountT = (operationLine.IsCostAmountNull() ? 0 : operationLine.CostAmount);

                if (operationLine.FT == BOTH_LINE_TYPE)
                {
                    sumT += amountT;
                    sumF += amountF;
                }
                else
                    if (operationLine.FT == TO_LINE_TYPE)
                        sumT += amountT;
                    else
                        sumF += amountF;
            }

            sum = sumF - sumT;

            lblShortageSumValue.Text = sumF.ToString("f2");
            lblSurplusSumValue.Text = sumT.ToString("f2");

            // TODO Пересчет не запускаем для суммы заголовка!!!
            lblAmountValueUAH.Text = sum.ToString("f2");
        }

        private void dgvOperationDetails_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            RecalculateAmounts();
        }

        private void btnRemoveOperation_Click(object sender, EventArgs e)
        {
            if (dgvOperationDetails.CurrentCell != null)
            {
                if (dgvOperationDetails.IsCurrentCellInEditMode)
                    dgvOperationDetails.CancelEdit();

                //DeleteSelectedRow(dgvOperationDetails.CurrentCell.OwningRow);
                dgvOperationDetails.Rows.Remove(dgvOperationDetails.CurrentCell.OwningRow);

                RecalculateAmounts();
            }
            else
            {
                MessageBox.Show("Для удаления строки необходимо сперва выделить ячейку.", "Удаление строки", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        #endregion

        #region Реализация адаптивного выбора склада из справочника
        private void btnWarehouseFromSelector_Click(object sender, EventArgs e)
        {
            SelectWarehouse(tbWarehouseFrom, lblWarehouseFromValue);
        }

        private void btnWarehouseToSelector_Click(object sender, EventArgs e)
        {
            SelectWarehouse(tbWarehouseTo, lblWarehouseToValue);
        }

        private void tbWarehouse_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.Up))
            {
                if (sender.Equals(tbWarehouseFrom))
                    SelectWarehouse(tbWarehouseFrom, lblWarehouseFromValue);
                if (sender.Equals(tbWarehouseTo))
                    SelectWarehouse(tbWarehouseTo, lblWarehouseToValue);
            }
        }

        /// <summary>
        /// Выбор склада из справочника
        /// </summary>
        /// <param name="tbWHID"></param>
        /// <param name="lblWHName"></param>
        private void SelectWarehouse(TextBox tbWHID, Label lblWHName)
        {
            using (ChoiseWarehouseForm dictionary = new ChoiseWarehouseForm() { UserID = this.UserID })
            {
                if (dictionary.ShowDialog() == DialogResult.OK)
                {
                    tbWHID.Text = dictionary.SelectedItem.Warehouse_ID;
                    lblWHName.Text = dictionary.SelectedItem.Warehouse;
                }
            }

            tbWHID.Focus();
            tbWHID.SelectionStart = 0;
            tbWHID.SelectionLength = 0;
        }

        private void pnlWarehouseFrom_Enter(object sender, EventArgs e)
        {
            btnWarehouseFromSelector.Visible = docNeedToSaveHeader;
        }

        private void pnlWarehouseTo_Enter(object sender, EventArgs e)
        {
            if (this.IsWriteOffOperation())
                btnWarehouseToSelector.Visible = false;
            else
                btnWarehouseToSelector.Visible = docNeedToSaveHeader;
        }

        private void pnlWarehouseFrom_Leave(object sender, EventArgs e)
        {
            btnWarehouseFromSelector.Visible = false;
        }

        private void pnlWarehouseTo_Leave(object sender, EventArgs e)
        {
            btnWarehouseToSelector.Visible = false;
        }

        private void tbWarehouseFrom_TextChanged(object sender, EventArgs e)
        {
            if (this.FindWarehouse(tbWarehouseFrom, lblWarehouseFromValue))
            {
                // TODO Подгрузка справочника JD выполнена здесь
                this.LoadJDDocTypes();

                if (this.IsWriteOffOperation())
                    tbWarehouseTo.Text = tbWarehouseFrom.Text;
            }
            else
            {
                this.wH.JDDocTypes.Clear();
            }
        }

        private void tbWarehouseTo_TextChanged(object sender, EventArgs e)
        {
            this.FindWarehouse(tbWarehouseTo, lblWarehouseToValue);
        }

        /// <summary>
        /// Поиск склада по точному совпадению из окна ввода в справочнике
        /// </summary>
        /// <param name="tbWHID"></param>
        /// <param name="lblWHName"></param>
        private bool FindWarehouse(TextBox tbWHID, Label lblWHName)
        {
            lblWHName.ForeColor = Color.Black;
            tbWHID.ForeColor = Color.Black;
            tbWHID.Tag = true;

            foreach (var findWarehouse in WHCache.Warehouses.Select(String.Format("TRIM({0}) = '{1}'", this.wH.OperationWarehouses.Warehouse_IDColumn.Caption, tbWHID.Text.Trim())))
            {
                //int p = tbWHID.SelectionStart; // TODO запоминаем позицию курсора
                tbWHID.Text = findWarehouse[this.wH.OperationWarehouses.Warehouse_IDColumn.Caption].ToString();
                //tbWHID.SelectionStart = p;
                lblWHName.Text = findWarehouse[this.wH.OperationWarehouses.WarehouseColumn.Caption].ToString();
                return true;
            }

            lblWHName.Text = "Склад не найден!";
            lblWHName.ForeColor = Color.Red;
            tbWHID.ForeColor = Color.Red;
            tbWHID.Tag = false;
            return false;
        }
        #endregion

        #region CellValidated, RowLeave и прочие события

        /// <summary>
        /// Скидываем выделение ячеек при покидании грида
        /// </summary>
        private void dgvOperationDetails_Leave(object sender, EventArgs e)
        {
            dgvOperationDetails.EndEdit();
            dgvOperationDetails.ClearSelection();
        }

        private void cmbJDDocType_Enter(object sender, EventArgs e)
        {
            cmbJDDocType.DroppedDown = true;
        }

        private void dgvOperationDetails_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            if (dgvOperationDetails.Columns[e.ColumnIndex].DataPropertyName == wH.OperationDocRows.QuantityColumn.Caption)
            {
                RecalculateAmounts();
                dgvOperationDetails.Refresh();
            }

            var cell = dgvOperationDetails[e.ColumnIndex, e.RowIndex];

            var dataRowView = dgvOperationDetails.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (dataRowView != null)
            {
                //cell.ToolTipText = "";
                //cell.Style.BackColor = Color.White;
                var bindRow = dataRowView.Row as Data.WH.OperationDocRowsRow;

                var check = CheckCellState(cell, bindRow);
                if (check != null)
                {
                    cell.Style.BackColor = check.BackGroundColor;
                    cell.ToolTipText = check.ToolTip;
                }
            }
        }

        #endregion

        #region Валидация и покраска строк

        /// <summary>
        /// Отвечает за проверку значений строки на 0 и пустые значения
        /// </summary>
        /// <param name="dataRow">Строка данных</param>
        /// <returns>false - если хотя бы одно из значений 0 или пробел, true - если строка прошла валидацию</returns>
        private bool CheckForEmptyCells(Data.WH.OperationDocRowsRow dataRow)
        {
            if (dataRow.FT == BOTH_LINE_TYPE)
            {
                if (dataRow.Item_ID == 0 || String.IsNullOrEmpty(dataRow.Lot_Number) ||
                    String.IsNullOrEmpty(dataRow.Location) ||
                    String.IsNullOrEmpty(dataRow.Location_To) || dataRow.Quantity == 0)
                    return false;
            }
            else
                if (dataRow.Item_ID == 0 || String.IsNullOrEmpty(dataRow.Lot_Number) ||
                     String.IsNullOrEmpty(dataRow.Location) || dataRow.Quantity == 0)
                    return false;

            return true;
        }

        /// <summary>
        /// Метод валидации для контрловов, вставленных в грид
        /// </summary>
        /// <param name="cell">Ячейка грида</param>
        /// <param name="row">Строка данных</param>
        /// <returns>Обьект, хранящий цвет и тултип ячейки</returns>
        private SaveCurrentCellColor CheckCellState(DataGridViewCell cell, Data.WH.OperationDocRowsRow row)
        {
            if (cell.OwningColumn.DataPropertyName == wH.OperationDocRows.Item_IDColumn.Caption)
            {
                var dictionary = new ChoiseItemForm();
                bool verify = dictionary.VerifyValue(cell.Value.ToString());
                SaveCurrentCellColor savedColor = new SaveCurrentCellColor();
                if (!verify)
                {
                    savedColor.BackGroundColor = Color.Red;
                    savedColor.ToolTip = "Товар не найден.";
                }
                if (verify && cell.Style.BackColor != Color.Red)
                {
                    savedColor.BackGroundColor = cell.Style.BackColor;
                    savedColor.ToolTip = cell.ToolTipText;
                    var itemDataInfoRow = dictionary.VerifiedItem;
                    InsertItemInfo(SelectedLineRow, itemDataInfoRow);

                    // Если операция - это посерийная пересортица -> в строку "куда" внесем ту же информацию из справочника
                    if (IsRegradingOfLotsOperation())
                    {
                        // Получаем позицию для соответсвующей строки "куда"
                        int toLineID = (Math.Abs(SelectedLineRow.Line_ID) + LINE_ID_SEED) * Math.Sign(SelectedLineRow.Line_ID);
                        foreach (Data.WH.OperationDocRowsRow newRow in wH.OperationDocRows.Select(string.Format("{0} = {1}", wH.OperationDocRows.Line_IDColumn.Caption, toLineID)))
                            InsertItemInfo(newRow, itemDataInfoRow);
                    }
                }
                else
                {
                    if (verify)
                    {
                        var itemDataInfoRow = dictionary.VerifiedItem;
                        InsertItemInfo(SelectedLineRow, itemDataInfoRow);

                        // Если операция - это посерийная пересортица -> в строку "куда" внесем ту же информацию из справочника
                        if (IsRegradingOfLotsOperation())
                        {
                            // Получаем позицию для соответсвующей строки "куда"
                            int toLineID = (Math.Abs(SelectedLineRow.Line_ID) + LINE_ID_SEED) * Math.Sign(SelectedLineRow.Line_ID);
                            foreach (Data.WH.OperationDocRowsRow newRow in wH.OperationDocRows.Select(string.Format("{0} = {1}", wH.OperationDocRows.Line_IDColumn.Caption, toLineID)))
                                InsertItemInfo(newRow, itemDataInfoRow);
                        }
                    }
                }
                return savedColor;
            }

            if (cell.OwningColumn.DataPropertyName == wH.OperationDocRows.Lot_NumberColumn.Caption)
            {
                if (row.FT == TO_LINE_TYPE)
                {
                    var dictionary = new ChoiseLotForm { UserID = UserID, DocID = DocID, ItemID = row.Item_ID };
                    bool verify = dictionary.VerifyValue(cell.Value.ToString());
                    SaveCurrentCellColor savedColor = new SaveCurrentCellColor();
                    if (!verify)
                    {
                        savedColor.BackGroundColor = Color.Red;
                        savedColor.ToolTip = "Партия не найдена.";
                    }
                    if (verify && cell.Style.BackColor != Color.Red)
                    {
                        savedColor.BackGroundColor = cell.Style.BackColor;
                        savedColor.ToolTip = cell.ToolTipText;
                        var lotDataInfoRow = dictionary.VerifiedItem;
                        InsertLotInfo(SelectedLineRow, lotDataInfoRow);
                    }
                    else
                    {
                        if (verify)
                        {
                            var lotDataInfoRow = dictionary.VerifiedItem;
                            InsertLotInfo(SelectedLineRow, lotDataInfoRow);
                        }
                    }
                    return savedColor;
                }
                else
                {
                    var dictionary = new ChoiseLocationForm { UserID = UserID, DocID = DocID, ItemID = row.Item_ID, LocationFrom = row.Location };
                    bool verify = dictionary.VerifyValue(cell.Value.ToString());
                    SaveCurrentCellColor savedColor = new SaveCurrentCellColor();
                    if (!verify)
                    {
                        savedColor.BackGroundColor = Color.Red;
                        savedColor.ToolTip = "Партия и место не найдены.";
                    }
                    if (verify && cell.Style.BackColor != Color.Red)
                    {
                        savedColor.BackGroundColor = cell.Style.BackColor;
                        savedColor.ToolTip = cell.ToolTipText;
                        var locationDataInfoRow = dictionary.VerifiedItem;
                        InsertLocationInfo(SelectedLineRow, locationDataInfoRow);
                    }
                    else
                    {
                        if (verify)
                        {
                            var locationDataInfoRow = dictionary.VerifiedItem;
                            InsertLocationInfo(SelectedLineRow, locationDataInfoRow);
                        }
                    }
                    return savedColor;
                }
            }

            #region колонки SSCC, пока не нужны в этом методе
            //if (cell.OwningColumn.DataPropertyName == wH.OperationDocRows.SSCC_FromColumn.Caption)
            //{
            //    var item_id = row.FT == TO_LINE_TYPE ? (Int32?)null : row.Item_ID;
            //    var vendor_lot = (String)null;
            //    var lot_number = row.FT == TO_LINE_TYPE ? null : row.Lot_Number;
            //    var location_id = row.Location;
            //    var qtty = row.FT == TO_LINE_TYPE ? (Double?)null : (Double)row.Quantity;

            //    var dictionary = new ChoiseSSCCForm()
            //    {
            //        UserID = this.UserID,
            //        WarehouseID = this.OperationHeader.WarehouseID_From,
            //        ItemID = item_id,
            //        VendorLot = vendor_lot,
            //        LotNumber = lot_number,
            //        LocationID = location_id,
            //        Quantity = qtty
            //    };
            //    bool verify = dictionary.VerifyValue(cell.Value.ToString());
            //    SaveCurrentCellColor savedColor = new SaveCurrentCellColor();
            //    if (!verify)
            //    {
            //        savedColor.BackGroundColor = Color.Red;
            //        savedColor.ToolTip = "Код SSCC не найден.";
            //    }
            //    if (verify && cell.Style.BackColor != Color.Red)
            //    {
            //        savedColor.BackGroundColor = cell.Style.BackColor;
            //        savedColor.ToolTip = cell.ToolTipText;
            //    }
            //    return savedColor;
            //}

            //if (cell.OwningColumn.DataPropertyName == wH.OperationDocRows.SSCC_ToColumn.Caption)
            //{
            //    var item_id = (Int32?)null;
            //    var vendor_lot = (String)null;
            //    var lot_number = (String)null;
            //    var location_id = row.Location_To;
            //    var qtty = (Double?)null;

            //    var dictionary = new ChoiseSSCCForm()
            //    {
            //        UserID = this.UserID,
            //        WarehouseID = this.OperationHeader.WarehouseID_From,
            //        ItemID = item_id,
            //        VendorLot = vendor_lot,
            //        LotNumber = lot_number,
            //        LocationID = location_id,
            //        Quantity = qtty
            //    };
            //    bool verify = dictionary.VerifyValue(cell.Value.ToString());
            //    SaveCurrentCellColor savedColor = new SaveCurrentCellColor();
            //    if (!verify)
            //    {
            //        savedColor.BackGroundColor = Color.Red;
            //        savedColor.ToolTip = "Код SSCC не найден.";
            //    }
            //    if (verify && cell.Style.BackColor != Color.Red)
            //    {
            //        savedColor.BackGroundColor = cell.Style.BackColor;
            //        savedColor.ToolTip = cell.ToolTipText;
            //    }
            //    return savedColor;
            //}
            #endregion

            if (cell.OwningColumn.DataPropertyName == wH.OperationDocRows.LocationColumn.Caption)
            {
                var dictionary = new ChoiceLocationListForm { UserID = this.UserID, DocID = this.DocID, FT = "F" };
                bool verify = dictionary.VerifyValue(cell.Value.ToString());
                SaveCurrentCellColor savedColor = new SaveCurrentCellColor();
                if (!verify)
                {
                    savedColor.BackGroundColor = Color.Red;
                    savedColor.ToolTip = "Место не найдено.";
                }
                if (verify && cell.Style.BackColor != Color.Red)
                {
                    savedColor.BackGroundColor = cell.Style.BackColor;
                    savedColor.ToolTip = cell.ToolTipText;
                    var LocationTo_DataInfoRow = dictionary.VerifiedItem;
                    InsertLocationList_ToInfo(SelectedLineRow, LocationTo_DataInfoRow);
                }
                else
                {
                    if (verify)
                    {
                        var LocationTo_DataInfoRow = dictionary.VerifiedItem;
                        InsertLocationList_ToInfo(SelectedLineRow, LocationTo_DataInfoRow);
                    }
                }
                return savedColor;
            }

            if (cell.OwningColumn.DataPropertyName == wH.OperationDocRows.Location_ToColumn.Caption)
            {
                var dictionary = new ChoiceLocationListForm { UserID = this.UserID, DocID = this.DocID, FT = "T" };
                bool verify = dictionary.VerifyValue(cell.Value.ToString());
                SaveCurrentCellColor savedColor = new SaveCurrentCellColor();
                if (!verify)
                {
                    savedColor.BackGroundColor = Color.Red;
                    savedColor.ToolTip = "Место не найдено.";
                }
                if (verify && cell.Style.BackColor != Color.Red)
                {
                    savedColor.BackGroundColor = cell.Style.BackColor;
                    savedColor.ToolTip = cell.ToolTipText;
                    var LocationTo_DataInfoRow = dictionary.VerifiedItem;
                    InsertLocationList_ToInfo(SelectedLineRow, LocationTo_DataInfoRow);
                }
                else
                {
                    if (verify)
                    {
                        var LocationTo_DataInfoRow = dictionary.VerifiedItem;
                        InsertLocationList_ToInfo(SelectedLineRow, LocationTo_DataInfoRow);
                    }
                }
                return savedColor;
            }

            #region Количество - пока тоже здесь не нужно
            //if (cell.OwningColumn.DataPropertyName == wH.OperationDocRows.QuantityColumn.Caption)
            //{
            //    bool verify = (decimal)cell.Value != 0;
            //    SaveCurrentCellColor savedColor = new SaveCurrentCellColor();
            //    if (!verify)
            //    {
            //        savedColor.BackGroundColor = Color.Red;
            //        savedColor.ToolTip = "Ведите количество, отличное от нуля.";
            //    }
            //    if (verify && cell.Style.BackColor != Color.Red)
            //    {
            //        savedColor.BackGroundColor = cell.Style.BackColor;
            //        savedColor.ToolTip = cell.ToolTipText;
            //    }
            //}
            #endregion
            return null;
        }

        /// <summary>
        /// Метод для проверки пустых полей и валидация необходимых полей 
        /// </summary>
        /// <param name="row">Строка данных</param>
        /// <param name="dataGrid">Таблица</param>
        /// <returns>true - значит найдены незаполненные/непрошедшие валидацию поля
        /// false - все хорошо, строка прошла валидацию</returns>
        private bool CheckEmptyAndNotValidCells(DataGridViewRow row, DataGridView dataGrid)
        {
            //try
            //{
            var dataRow = (Data.WH.OperationDocRowsRow)((DataRowView)row.DataBoundItem).Row;
            bool errorOccured = false;

            //if (row != null && (dataRow.RowState != DataRowState.Unchanged && dataRow.RowState != DataRowState.Deleted))
            for (int c = 0; c < row.Cells.Count; c++)
            {
                bool isVerify = false;

                #region Код товара
                if (dataGrid.Columns[row.Cells[c].ColumnIndex].DataPropertyName ==
                    wH.OperationDocRows.Item_IDColumn.Caption)
                {
                    using (Data.WHTableAdapters.ItemsTableAdapter adapter = new Data.WHTableAdapters.ItemsTableAdapter())
                    {
                        var table = adapter.GetData(null, dataRow.Item_ID);
                        if (table.Rows.Count != 0)
                        {
                            var itemInfoRow = table[0];
                            InsertItemInfo(dataRow, itemInfoRow);
                            isVerify = true;
                            row.Cells[c].Style.BackColor = Color.White;
                            row.Cells[c].ToolTipText = "";
                        }
                    }

                    if (dataRow.Item_ID == 0 || !isVerify)
                    {
                        row.Cells[c].Style.BackColor = Color.Red;
                        row.Cells[c].ToolTipText = "Товар не найден.";
                        errorOccured = true;
                    }
                }

                #endregion

                #region Партия
                if (dataGrid.Columns[row.Cells[c].ColumnIndex].DataPropertyName ==
                    wH.OperationDocRows.Lot_NumberColumn.Caption)
                {
                    if (dataRow.FT == TO_LINE_TYPE)
                    {
                        if (dataRow.Lot_Number != null)
                        {
                            using (Data.WHTableAdapters.LotsTableAdapter adapter = new Data.WHTableAdapters.LotsTableAdapter())
                            {
                                var table = adapter.GetData(UserID, DocID, dataRow.Item_ID, dataRow.Lot_Number, OperationHeader.WarehouseID_To);
                                if (table.Rows.Count != 0)
                                {
                                    var lotInfoRow = table[0];
                                    InsertLotInfo(dataRow, lotInfoRow);
                                    isVerify = true;
                                    row.Cells[c].Style.BackColor = Color.White;
                                    row.Cells[c].ToolTipText = "";
                                }
                            }
                        }
                    }
                    else
                    {
                        if (dataRow.Lot_Number != null)
                        {
                            using (
                                Data.WHTableAdapters.LocationsTableAdapter adapter =
                                    new Data.WHTableAdapters.LocationsTableAdapter())
                            {
                                var table = adapter.GetData(UserID, DocID, dataRow.Item_ID, dataRow.Lot_Number, dataRow.Location,
                                                            null, OperationHeader.WarehouseID_From);
                                if (table.Rows.Count != 0)
                                {
                                    var locationInfoRow = table[0];
                                    InsertLocationInfo(dataRow, locationInfoRow);
                                    isVerify = true;
                                    row.Cells[c].Style.BackColor = Color.White;
                                    row.Cells[c].ToolTipText = "";
                                }
                            }
                        }
                    }

                    if (!isVerify || String.IsNullOrEmpty(dataRow.Lot_Number))
                    {
                        row.Cells[c].Style.BackColor = Color.Red;
                        if (dataRow.FT == TO_LINE_TYPE)
                            row.Cells[c].ToolTipText = "Партия не найдена.";
                        else
                            row.Cells[c].ToolTipText = "Партия и место не найдены.";
                        errorOccured = true;
                    }
                }
                #endregion

                #region Место откуда
                if (dataGrid.Columns[row.Cells[c].ColumnIndex].DataPropertyName ==
                    wH.OperationDocRows.LocationColumn.Caption)
                {
                    if (dataRow.Location != null)
                    {
                        using (
                            Data.WHTableAdapters.GetLocationListTableAdapter adapter =
                                new Data.WHTableAdapters.GetLocationListTableAdapter())
                        {
                            var table = adapter.GetData(UserID, DocID, dataRow.FT, dataRow.Location, OperationHeader.WarehouseID_From, OperationHeader.WarehouseID_To);
                            if (table.Rows.Count != 0)
                            {
                                var infoRow = table[0];
                                InsertLocationList_ToInfo(dataRow, infoRow);
                                isVerify = true;
                                row.Cells[c].Style.BackColor = Color.White;
                                row.Cells[c].ToolTipText = "";
                            }
                        }
                    }
                    if (String.IsNullOrEmpty(dataRow.Location) || !isVerify)
                    {
                        row.Cells[c].Style.BackColor = Color.Red;
                        row.Cells[c].ToolTipText = "Место не найдено.";
                        errorOccured = true;
                    }
                }
                #endregion

                #region Место куда
                if (dataGrid.Columns[row.Cells[c].ColumnIndex].DataPropertyName ==
                    wH.OperationDocRows.Location_ToColumn.Caption)
                {
                    if (dataRow.FT == BOTH_LINE_TYPE)
                    {
                        if (dataRow.Location_To != null)
                        {
                            using (
                                Data.WHTableAdapters.GetLocationListTableAdapter adapter =
                                    new Data.WHTableAdapters.GetLocationListTableAdapter())
                            {
                                var table = adapter.GetData(UserID, DocID, dataRow.FT, dataRow.Location_To, OperationHeader.WarehouseID_From, OperationHeader.WarehouseID_To);
                                if (table.Rows.Count != 0)
                                {
                                    var infoRow = table[0];
                                    InsertLocationList_ToInfo(dataRow, infoRow);
                                    isVerify = true;
                                    row.Cells[c].Style.BackColor = Color.White;
                                    row.Cells[c].ToolTipText = "";
                                }
                            }
                        }
                        if ((dataRow.FT == BOTH_LINE_TYPE && String.IsNullOrEmpty(dataRow.Location_To)) || !isVerify)
                        {
                            row.Cells[c].Style.BackColor = Color.Red;
                            row.Cells[c].ToolTipText = "Место не найдено.";
                            errorOccured = true;
                        }
                    }
                }
                #endregion
            }
            if (errorOccured)
            {
                //MessageBox.Show("Есть колонки с незаполнеными полями, они подсвечены зеленым/красным цветом! Прежде чем создать новую строку заполните все поля!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            return false;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Ошибка ВАЛИДАЦИИ!!!" + "/n" + ex.Message);
            //}
            //return true;
        }

        /// <summary>
        /// Метод покраски с помощью процедуры, возвращающей цвета
        /// </summary>
        /// <param name="row">Строка данных</param>
        private void CheckErrorsAndSetFill(DataGridViewRow row)
        {
            using (var adapter = new Data.WHTableAdapters.CheckLinesResponseTableAdapter())
            {
                try
                {
                    Data.WH.OperationDocRowsRow dataRow = (Data.WH.OperationDocRowsRow)((DataRowView)row.DataBoundItem).Row;

                    Data.WH.CheckLinesResponseDataTable checkedLine;
                    checkedLine = adapter.GetData(UserID, DocID, dataRow.Batch_ID);

                    CheckedLineValues checkedValues = null;
                    if (checkedLine != null)
                        foreach (Data.WH.CheckLinesResponseRow line in checkedLine)
                            checkedValues = new CheckedLineValues(line);

                    //dgvOperationDetails.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);

                    if (dataRow.RowState != DataRowState.Deleted)
                        for (int c = 0; c < row.Cells.Count; c++)
                        {
                            if (checkedValues != null)
                            {
                                if (row.Cells[c].OwningColumn.DataPropertyName ==
                                    wH.OperationDocRows.Item_IDColumn.Caption)
                                {
                                    if (dataRow.FT == FROM_LINE_TYPE || dataRow.FT == BOTH_LINE_TYPE)
                                    {
                                        row.Cells[c].Style.BackColor = Color.FromName(checkedValues.ItemFrom_Color);
                                        row.Cells[c].ToolTipText = checkedValues.ItemFrom;
                                    }
                                    if (dataRow.FT == TO_LINE_TYPE)
                                    {
                                        row.Cells[c].Style.BackColor = Color.FromName(checkedValues.ItemTo_Color);
                                        row.Cells[c].ToolTipText = checkedValues.ItemTo;
                                    }
                                }
                                if (row.Cells[c].OwningColumn.DataPropertyName ==
                                    wH.OperationDocRows.Lot_NumberColumn.Caption)
                                {
                                    if (dataRow.FT == FROM_LINE_TYPE || dataRow.FT == BOTH_LINE_TYPE)
                                    {
                                        row.Cells[c].Style.BackColor = Color.FromName(checkedValues.LotFrom_Color);
                                        row.Cells[c].ToolTipText = checkedValues.LotFrom;
                                    }
                                    if (dataRow.FT == TO_LINE_TYPE)
                                    {
                                        row.Cells[c].Style.BackColor = Color.FromName(checkedValues.LotTo_Color);
                                        row.Cells[c].ToolTipText = checkedValues.LotTo;
                                    }
                                }
                                if (row.Cells[c].OwningColumn.DataPropertyName ==
                                    wH.OperationDocRows.QuantityColumn.Caption)
                                {
                                    if (dataRow.FT == FROM_LINE_TYPE || dataRow.FT == BOTH_LINE_TYPE)
                                    {
                                        row.Cells[c].Style.BackColor =
                                            Color.FromName(checkedValues.QuantityFrom_Color);
                                        row.Cells[c].ToolTipText = checkedValues.QuantityFrom;
                                    }
                                    if (dataRow.FT == TO_LINE_TYPE)
                                    {
                                        row.Cells[c].Style.BackColor = Color.FromName(checkedValues.QuantityTo_Color);
                                        row.Cells[c].ToolTipText = checkedValues.QuantityTo;
                                    }
                                }
                                if (row.Cells[c].OwningColumn.DataPropertyName ==
                                    wH.OperationDocRows.LocationColumn.Caption)
                                {
                                    row.Cells[c].Style.BackColor = Color.FromName(checkedValues.LocationFrom_Color);
                                    row.Cells[c].ToolTipText = checkedValues.LocationFrom;
                                }
                                if (row.Cells[c].OwningColumn.DataPropertyName ==
                                    wH.OperationDocRows.Location_ToColumn.Caption)
                                {
                                    row.Cells[c].Style.BackColor = Color.FromName(checkedValues.LocationTo_Color);
                                    row.Cells[c].ToolTipText = checkedValues.LocationTo;
                                }
                                if (row.Cells[c].OwningColumn.DataPropertyName ==
                                   wH.OperationDocRows.SSCC_FromColumn.Caption)
                                {
                                    row.Cells[c].Style.BackColor = Color.FromName(checkedValues.SSCCFrom_Color);
                                    row.Cells[c].ToolTipText = checkedValues.SSCCFrom;
                                }
                                if (row.Cells[c].OwningColumn.DataPropertyName ==
                                    wH.OperationDocRows.SSCC_ToColumn.Caption)
                                {
                                    row.Cells[c].Style.BackColor = Color.FromName(checkedValues.SSCCTo_Color);
                                    row.Cells[c].ToolTipText = checkedValues.SSCCTo;
                                }
                            }
                        }
                    if (CheckForEmptyCells(dataRow))
                        dataRow.AcceptChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, @"Ошибка покраски", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region Нажатия клавиш

        /// <summary>
        /// Событие для отображения тултипа в метке
        /// </summary>
        private void dgvOperationDetails_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //Debug.WriteLine("CellEnter EVENTS");
            var toolTip = dgvOperationDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText;
            if (toolTip != "")
                tbxCellToolTip.Text = toolTip;
            else
                tbxCellToolTip.Text = "";

            if (dgvOperationDetails.CurrentRow != null && !dgvOperationDetails.CurrentRow.Cells[e.ColumnIndex].ReadOnly)
                dgvOperationDetails.BeginEdit(true);
        }

        private void dgvOperationDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert || e.KeyCode == Keys.Enter)
            {
                if (dgvOperationDetails.Rows.Count > 0)
                //dgvOperationDetails.BeginEdit(false);
                {
                    btnAddOperation.Focus();
                    AddOperationLine();
                }
            }
            if (e.KeyCode == Keys.Delete)
            {
                if (dgvOperationDetails.CurrentRow != null && dgvOperationDetails.SelectedRows.Count == 1)
                {
                    if (MessageBox.Show(@"Вы действительно хотите удалить эту строку?", @"Внимание!",
                                        MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                        DeleteSelectedRow(dgvOperationDetails.CurrentRow);
                }
                if (dgvOperationDetails.SelectedRows.Count > 1)
                {
                    if (MessageBox.Show(@"Вы действительно хотите удалить выделенные строки?", @"Внимание!",
                                        MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                        foreach (DataGridViewRow row in dgvOperationDetails.SelectedRows)
                            DeleteSelectedRow(row);
                }
            }

            //Экспорт в Excel
            if (e.KeyData == (Keys.Control | Keys.C))
            {
                if (dgvOperationDetails.GetCellCount(DataGridViewElementStates.Selected) > 0)
                {
                    dgvOperationDetails.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;

                    Clipboard.Clear();
                    if (dgvOperationDetails.GetClipboardContent() != null)
                    {
                        Clipboard.SetDataObject(dgvOperationDetails.GetClipboardContent());
                        Clipboard.GetData(DataFormats.Text);
                        IDataObject dt = Clipboard.GetDataObject();
                        if (dt.GetDataPresent(typeof(string)))
                        {
                            string tb = (string)(dt.GetData(typeof(string)));
                            Encoding encoding = Encoding.GetEncoding(1251);
                            byte[] dataStr = encoding.GetBytes(tb);
                            Clipboard.SetDataObject(encoding.GetString(dataStr));
                        }
                    }
                    dgvOperationDetails.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
                }
            }
        }

        /// <summary>
        /// Метод удаления строк
        /// </summary>
        public void DeleteSelectedRow(DataGridViewRow selectedRow)
        {
            if (selectedRow != null)
            {
                if (IsMovementOperation() || IsVirtualMovementOperation())
                {
                    var delRow =
                        (Data.WH.OperationDocRowsRow)
                        ((DataRowView)selectedRow.DataBoundItem).Row;
                    delRow.Delete();

                    Int64 batchId = 0;

                    foreach (Data.WH.OperationDocRowsRow row in wH.OperationDocRows)
                    {
                        if (row.RowState == DataRowState.Deleted)
                        {
                            batchId =
                                Convert.ToInt64(
                                    row[wH.OperationDocRows.Batch_IDColumn.Caption, DataRowVersion.Original
                                        ]);
                            break;
                        }
                    }

                    operationDocRowsTableAdapter.DeleteOperationLine(UserID, DocID,
                                                                     batchId);
                }
                else
                {
                    if (selectedRow.DataBoundItem != null)
                    {
                        var delRow =
                            (Data.WH.OperationDocRowsRow)
                            ((DataRowView)selectedRow.DataBoundItem).Row;

                        var secondRow = ValidationForPeresort(delRow);
                        delRow.Delete();
                        secondRow.Delete();

                        Int64 batchId = 0;

                        foreach (Data.WH.OperationDocRowsRow row in wH.OperationDocRows)
                        {
                            if (row.RowState == DataRowState.Deleted)
                            {
                                batchId =
                                    Convert.ToInt64(
                                        row[wH.OperationDocRows.Batch_IDColumn.Caption, DataRowVersion.Original
                                            ]);
                                break;
                            }
                        }

                        if (batchId > 0)
                            operationDocRowsTableAdapter.DeleteOperationLine(UserID, DocID,
                                                                             batchId);

                    }
                }
                dgvOperationDetails.Refresh();
            }
        }

        #endregion

        #region События контролов

        private void dgvOperationDetails_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //dgvOperationDetails.CurrentCell.Style.BackColor = Color.Red;
            //dgvOperationDetails.CurrentCell.Style.SelectionForeColor = Color.Red;
            if (e.ColumnIndex == dgvOperationDetails.Columns[quantityDataGridViewTextBoxColumn.Name].Index)
            {
                if (e.Exception != null)
                {
                    var context = (DataGridViewDataErrorContexts.Parsing | DataGridViewDataErrorContexts.Commit);
                    if (e.Context == context)
                    {
                        MessageBox.Show(string.Format("Неверный формат числа для поля \"{0}\".", quantityDataGridViewTextBoxColumn.HeaderText), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dgvOperationDetails_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is EllipsisGridCellEditorControl)
            {
                //Debug.WriteLine("dgvOperationDetails_EditingControlShowing EVENTS");
                (e.Control as EllipsisGridCellEditorControl).InsertNewLine -= new EventHandler(OperationEditorForm_InsertNewLine);
                (e.Control as EllipsisGridCellEditorControl).InsertNewLine += new EventHandler(OperationEditorForm_InsertNewLine);

                (e.Control as EllipsisGridCellEditorControl).DeleteRowInside -= new EventHandler(OperationEditorForm_DeleteRowInside);
                (e.Control as EllipsisGridCellEditorControl).DeleteRowInside += new EventHandler(OperationEditorForm_DeleteRowInside);

                (e.Control as EllipsisGridCellEditorControl).OnSelectorOpening -= new EventHandler(OperationEditorForm_OnSelectorOpening);
                (e.Control as EllipsisGridCellEditorControl).OnSelectorOpening += new EventHandler(OperationEditorForm_OnSelectorOpening);

                (e.Control as EllipsisGridCellEditorControl).ShowSelector -= new EventHandler(OperationEditorControl_ShowSelector);
                (e.Control as EllipsisGridCellEditorControl).ShowSelector += new EventHandler(OperationEditorControl_ShowSelector);

                (e.Control as EllipsisGridCellEditorControl).OnVerifyValue -= new EventHandler(OperationEditorForm_OnVerifyValue);
                (e.Control as EllipsisGridCellEditorControl).OnVerifyValue += new EventHandler(OperationEditorForm_OnVerifyValue);

                //(e.Control as EllipsisGridCellEditorControl).PasteData -= new EventHandler(OperationEditorForm_PasteData);
                //(e.Control as EllipsisGridCellEditorControl).PasteData += new EventHandler(OperationEditorForm_PasteData);
            }

            if (e.Control is DataGridViewTextBoxEditingControl)
            {
                if (dgvOperationDetails.CurrentCell.ColumnIndex == quantityDataGridViewTextBoxColumn.Index)
                {
                    lockQuantityEditor = false;
                    (e.Control as DataGridViewTextBoxEditingControl).TextChanged -= new EventHandler(OperationEditorForm_TextChanged);
                    (e.Control as DataGridViewTextBoxEditingControl).TextChanged += new EventHandler(OperationEditorForm_TextChanged);
                    (e.Control as DataGridViewTextBoxEditingControl).KeyDown -= new KeyEventHandler(OperationEditorForm_KeyDown);
                    (e.Control as DataGridViewTextBoxEditingControl).KeyDown += new KeyEventHandler(OperationEditorForm_KeyDown);
                }
            }
        }

        void OperationEditorForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert || e.KeyCode == Keys.Enter)
            {
                if (dgvOperationDetails.Rows.Count > 0)
                {
                    btnAddOperation.Focus();
                    AddOperationLine();
                }
            }
        }

        void OperationEditorForm_InsertNewLine(object sender, EventArgs e)
        {
            //Debug.WriteLine("OperationEditorForm_InsertNewLine EVENTS");
            AddOperationLine();
        }

        void OperationEditorForm_DeleteRowInside(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"Вы действительно хотите удалить эту строку?", @"Внимание!",
                                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                DeleteSelectedRow(dgvOperationDetails.CurrentRow);
                dgvOperationDetails.EndEdit();
            }
        }

        void OperationEditorForm_OnSelectorOpening(object sender, EventArgs e)
        {
            //Debug.WriteLine("OperationEditorForm_OnSelectorOpening EVENTS");
            //if ((sender as EllipsisGridCellEditorControl).Value != null)
            //    this.ShowEditorSelector(true);
            //else
            ShowEditorSelector(false);
        }

        private bool lockQuantityEditor; // блокировка повторной замены разделителя целой-дробной частей
        void OperationEditorForm_TextChanged(object sender, EventArgs e)
        {

        }

        void OperationEditorForm_OnVerifyValue(object sender, EventArgs e)
        {
            //Debug.WriteLine("OperationEditorForm_OnVerifyValue EVENTS");
            var ellipsisGridCellEditorControl = sender as EllipsisGridCellEditorControl;
            if (ellipsisGridCellEditorControl != null && ellipsisGridCellEditorControl.Value != null)
            {
                ShowEditorSelector(true);
            }
        }

        private void OperationEditorControl_ShowSelector(object sender, EventArgs e)
        {
            //Debug.WriteLine("OperationEditorControl_ShowSelector EVENTS");
            ShowEditorSelector(false);
        }

        /// <summary>
        /// Анализ отображения справочника и последействия
        /// </summary>
        private void ShowEditorSelector(bool verifyValue)
        {
            //Debug.WriteLine("ShowEditorSelector  " + verifyValue);

            StringBuilder errors = new StringBuilder();
            bool errorOccured = false;

            string checkedCell = string.Empty;
            if (dgvOperationDetails.CurrentCell.Value.ToString() == "0" ||
                dgvOperationDetails.CurrentCell.Value.ToString() == string.Empty)
            {
                checkedCell = dgvOperationDetails.CurrentCell.EditedFormattedValue.ToString();
            }
            else
            {
                checkedCell = dgvOperationDetails.CurrentCell.Value.ToString();
            }

            if (checkedCell != null)
            {
                // Получаем поле редактируемой колонки для дальнейшего анализа
                string dataPropertyName = dgvOperationDetails.Columns[dgvOperationDetails.CurrentCell.ColumnIndex].DataPropertyName;

                #region Новый вариант валидации колонки "Код товара"
                // Если редактируемая колонка - это "Код товара"
                if (dataPropertyName == wH.OperationDocRows.Item_IDColumn.Caption)
                {
                    var dictionary = new ChoiseItemForm();
                    //bool valid = (!verifyValue && dictionary.ShowDialog() == DialogResult.OK) || (verifyValue && dictionary.VerifyValue(checkedCell));
                    bool valid = (!verifyValue && dictionary.ShowDialog() == DialogResult.OK);

                    if (valid)
                    {
                        var itemDataInfoRow = verifyValue ? dictionary.VerifiedItem : dictionary.SelectedItem;
                        InsertItemInfo(SelectedLineRow, itemDataInfoRow);

                        // Если операция - это посерийная пересортица -> в строку "куда" внесем ту же информацию из справочника
                        if (IsRegradingOfLotsOperation())
                        {
                            // Получаем позицию для соответсвующей строки "куда"
                            int toLineID = (Math.Abs(SelectedLineRow.Line_ID) + LINE_ID_SEED) * Math.Sign(SelectedLineRow.Line_ID);
                            foreach (Data.WH.OperationDocRowsRow row in wH.OperationDocRows.Select(string.Format("{0} = {1}", wH.OperationDocRows.Line_IDColumn.Caption, toLineID)))
                                InsertItemInfo(row, itemDataInfoRow);
                        }
                    }
                }
                #endregion

                // Если редактируемая колонка - это "Партия"
                if (dataPropertyName == wH.OperationDocRows.Lot_NumberColumn.Caption)
                {
                    // Предвалидация выбора партии товара 
                    if (SelectedLineRow.IsItem_IDNull())
                    {
                        if (!verifyValue)
                        {
                            MessageBox.Show("Сначала выберите товар из справочника!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    if (!errorOccured)
                    {
                        // Если это строка "куда" -> отобразим справочник выбора партии
                        if (SelectedLineRow.FT == TO_LINE_TYPE)
                        {
                            var dictionary = new ChoiseLotForm { UserID = UserID, DocID = DocID, ItemID = SelectedLineRow.Item_ID };

                            bool valid = (!verifyValue && dictionary.ShowDialog() == DialogResult.OK);
                            if (valid)
                            {
                                var lotDataInfoRow = verifyValue ? dictionary.VerifiedItem : dictionary.SelectedItem;
                                InsertLotInfo(SelectedLineRow, lotDataInfoRow);
                            }
                        }
                        //иначе -> отобразим справочник выбора партии и места для строки "откуда"
                        else
                        {
                            var dictionary = new ChoiseLocationForm() { UserID = UserID, DocID = DocID, ItemID = SelectedLineRow.Item_ID, LocationFrom = SelectedLineRow.Location };

                            bool valid = (!verifyValue && dictionary.ShowDialog() == DialogResult.OK);
                            if (valid)
                            {
                                var locationDataInfoRow = verifyValue ? dictionary.VerifiedItem : dictionary.SelectedItem;
                                InsertLocationInfo(SelectedLineRow, locationDataInfoRow);
                            }
                        }

                        //Пересчитаем итоги
                        RecalculateAmounts();
                    }
                }

                // Если редактируемая колонка - это "SSCC"
                if (dataPropertyName == wH.OperationDocRows.SSCC_FromColumn.Caption)
                {
                    #region Предвалидация выбора SSCC
                    //StringBuilder errors = new StringBuilder();
                    if ((SelectedLineRow.FT == FROM_LINE_TYPE || this.SelectedLineRow.FT == BOTH_LINE_TYPE) && this.SelectedLineRow.IsItem_IDNull())
                        errors.AppendFormat("Не указан товар.\n");

                    //if (this.SelectedLineRow.IsVendorLotNull())
                    //    errors.AppendFormat("Не указана серия.\n");

                    if ((SelectedLineRow.FT == FROM_LINE_TYPE || this.SelectedLineRow.FT == BOTH_LINE_TYPE) && this.SelectedLineRow.IsLot_NumberNull())
                        errors.AppendFormat("Не указана партия.\n");

                    if (SelectedLineRow.IsLocationNull())
                        errors.AppendFormat("Не указано место.\n");

                    if (errors.Length > 0)
                    {
                        if (!verifyValue)
                        {
                            MessageBox.Show(String.Format("Обнаружены следующие ошибки:\n\n{0}", errors.ToString().Trim('\n')), "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                            errorOccured = true;
                    }
                    #endregion

                    if (!errorOccured)
                    {
                        var item_id = SelectedLineRow.FT == TO_LINE_TYPE ? (Int32?)null : SelectedLineRow.Item_ID;
                        var vendor_lot = (String)null;
                        var lot_number = SelectedLineRow.FT == TO_LINE_TYPE ? null : SelectedLineRow.Lot_Number;
                        var location_id = SelectedLineRow.Location;
                        var qtty = SelectedLineRow.FT == TO_LINE_TYPE ? (Double?)null : (Double)SelectedLineRow.Quantity;

                        var dictionary = new ChoiseSSCCForm
                        {
                            UserID = UserID,
                            WarehouseID = OperationHeader.WarehouseID_From,
                            ItemID = item_id,
                            VendorLot = vendor_lot,
                            LotNumber = lot_number,
                            LocationID = location_id,
                            Quantity = qtty
                        };

                        bool valid = (!verifyValue && dictionary.ShowDialog() == DialogResult.OK) || (verifyValue && dictionary.VerifyValue(checkedCell));
                        if (valid)
                        {
                            var SSCC_DataInfoRow = verifyValue ? dictionary.VerifiedItem : dictionary.SelectedItem;
                            //if (this.SelectedLineRow.FT == BOTH_LINE_TYPE)
                            //    this.InserSSCC_ToInfo(this.SelectedLineRow, SSCC_DataInfoRow);
                            //else
                            InsertSSCCInfo(SelectedLineRow, SSCC_DataInfoRow);
                        }
                        else
                        {
                            if (verifyValue)
                            {
                                errors.AppendFormat("Код SSCC не найден.\n");
                            }
                        }
                    }
                }

                // Если редактируемая колонка - это "SSCC"-куда
                if (dataPropertyName == wH.OperationDocRows.SSCC_ToColumn.Caption)
                {
                    #region Предвалидация выбора SSCC-куда
                    //StringBuilder errors = new StringBuilder();
                    if (SelectedLineRow.IsLocation_ToNull())
                        errors.AppendFormat("Не указано место \"куда\".\n");

                    if (errors.Length > 0)
                    {
                        if (!verifyValue)
                        {
                            MessageBox.Show(String.Format("Обнаружены следующие ошибки:\n\n{0}", errors.ToString().Trim('\n')), "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                            errorOccured = true;
                    }
                    #endregion

                    if (!errorOccured)
                    {
                        var item_id = (Int32?)null;
                        var vendor_lot = (String)null;
                        var lot_number = (String)null;
                        var location_id = SelectedLineRow.Location_To;
                        var qtty = (Double?)null;

                        var dictionary = new ChoiseSSCCForm()
                        {
                            UserID = UserID,
                            WarehouseID = OperationHeader.WarehouseID_From,
                            ItemID = item_id,
                            VendorLot = vendor_lot,
                            LotNumber = lot_number,
                            LocationID = location_id,
                            Quantity = qtty
                        };

                        bool valid = (!verifyValue && dictionary.ShowDialog() == DialogResult.OK) || (verifyValue && dictionary.VerifyValue(checkedCell));
                        if (valid)
                        {
                            var SSCC_DataInfoRow = verifyValue ? dictionary.VerifiedItem : dictionary.SelectedItem;
                            InsertSSCC_ToInfo(SelectedLineRow, SSCC_DataInfoRow);
                        }
                        else
                        {
                            if (verifyValue)
                            {
                                errors.AppendFormat("Код SSCC не найден.\n");
                            }
                        }
                    }
                }

                if (dataPropertyName == wH.OperationDocRows.LocationColumn.Caption)
                {
                    // Предвалидация выбора партии товара 
                    if (this.SelectedLineRow.IsItem_IDNull())
                    {
                        if (!verifyValue)
                        {
                            MessageBox.Show("Сначала выберите товар из справочника!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            errors.AppendFormat("Сначала выберите товар из справочника!\n");
                            errorOccured = true;
                        }
                    }
                    if (!errorOccured)
                    {
                        var dictionary = new ChoiceLocationListForm { UserID = UserID, DocID = DocID, FT = "F" };

                        bool valid = (!verifyValue && dictionary.ShowDialog() == DialogResult.OK);
                        if (valid)
                        {
                            var LocationTo_DataInfoRow = verifyValue ? dictionary.VerifiedItem : dictionary.SelectedItem;
                            InsertLocationList_ToInfo(SelectedLineRow, LocationTo_DataInfoRow);
                        }
                    }
                }
                if (dataPropertyName == wH.OperationDocRows.Location_ToColumn.Caption)
                {
                    // Предвалидация выбора партии товара 
                    if (SelectedLineRow.IsItem_IDNull())
                    {
                        if (!verifyValue)
                        {
                            MessageBox.Show("Сначала выберите товар из справочника!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            errors.AppendFormat("Сначала выберите товар из справочника!\n");
                            errorOccured = true;
                        }
                    }
                    if (!errorOccured)
                    {
                        var dictionary = new ChoiceLocationListForm { UserID = UserID, DocID = DocID, FT = "T" };

                        bool valid = (!verifyValue && dictionary.ShowDialog() == DialogResult.OK);
                        if (valid)
                        {
                            var LocationTo_DataInfoRow = verifyValue ? dictionary.VerifiedItem : dictionary.SelectedItem;
                            InsertLocationList_ToInfo(SelectedLineRow, LocationTo_DataInfoRow);
                        }
                    }
                }
            }
            if (errors.Length > 0)
            {
                //dgvOperationDetails.CurrentCell.Style.BackColor = Color.Red;
                //dgvOperationDetails.CurrentCell.Style.SelectionForeColor = Color.Red;
                dgvOperationDetails.CurrentCell.ToolTipText = errors.ToString().Trim('\n');
            }

            dgvOperationDetails.Refresh();
        }

        #endregion

        #region Импорт из EXCEL

        /// <summary>
        /// Втсавка данных из буфера с помощью контекстного меню
        /// </summary>
        private void smbPaste_Click(object sender, EventArgs e)
        {
            if (!CanModify)
            {
                MessageBox.Show(@"Документ НЕ подлежит изменениям!\nДобавление строк ЗАПРЕЩЕНО!!", @"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!docNeedToSaveHeader)
            {
                if (dgvOperationDetails.SelectedCells.Count > 0)
                {
                    PasteClipboard(dgvOperationDetails);
                    VerifyCells();
                    dgvOperationDetails.EndEdit();
                    RecalculateAmounts();
                    SaveOperation();
                    foreach (DataGridViewRow row in dgvOperationDetails.Rows)
                    {
                        CheckErrorsAndSetFill(row);
                    }
                    dgvOperationDetails.Refresh();
                }
                //else
                //    PasteOperations();
            }
            else
                MessageBox.Show(@"Невозможно выполнить добавление новых строк!\nСохраните сперва заголовок операции.",
                                @"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void VerifyCells()
        {
            //try
            //{
            BackgroundWorker pastePartlyWorker = new BackgroundWorker();
            pastePartlyWorker.DoWork += new DoWorkEventHandler(pastePartlyWorker_DoWork);
            pastePartlyWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(pastePartlyWorker_RunWorkerCompleted);
            pastePartlyWorker.WorkerReportsProgress = true;
            newWaitProcessForm.ActionText = "Проверка строк операции...";
            pastePartlyWorker.RunWorkerAsync(new PasteWorkerParameters { OwnerWorker = pastePartlyWorker, dataGrid = dgvOperationDetails });
            newWaitProcessForm.ShowDialog();

            pastePartlyWorker.DoWork -= new DoWorkEventHandler(pastePartlyWorker_DoWork);
            pastePartlyWorker.RunWorkerCompleted -= new RunWorkerCompletedEventHandler(pastePartlyWorker_RunWorkerCompleted);
            //}
            //catch (Exception ex)
            //{
            //}

        }

        void pastePartlyWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var parameters = e.Argument as PasteWorkerParameters;
            DataGridView dataGrid = parameters.dataGrid;
            try
            {
                if (dataGrid != null)
                {
                    warningEmpty = false;
                    foreach (DataGridViewRow row in dataGrid.Rows)
                    {
                        CheckEmptyAndNotValidCells(row, dataGrid);
                        var dataRow = (Data.WH.OperationDocRowsRow)((DataRowView)row.DataBoundItem).Row;
                        if (!CheckForEmptyCells(dataRow))
                            warningEmpty = true;
                        //else
                        //    CheckErrorsAndSetFill(row);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Ошибка валидации и покраски строк", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void pastePartlyWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            newWaitProcessForm.CloseForce();
        }

        /// <summary>
        /// Метод, выполняющий вставку данных в существующие строки
        /// </summary>
        /// <param name="line">строка из буфера</param>
        /// <param name="dataGrid">наш грид</param>
        /// <param name="iColIndex">индекс колонки</param>
        /// <param name="iColDisplayIndex">отображаемый индекс колонки</param>
        /// <param name="parametrs">Обьект, хранящий в себе текщую ячейку, DisplayIndex колонки а также номер строки</param>
        /// <returns>Обьект (хранящий в себе текщую ячейку, DisplayIndex колонки а также номер строки) только с обновленными данными, 
        /// которые будут использоватся при вставке новых строк из буфера</returns>
        private ImportParametrs PasteRows(string line, DataGridView dataGrid, int iColIndex, int iColDisplayIndex, ImportParametrs parametrs)
        {
            int itemID;
            decimal quantity;
            string[] sCells = line.Split('\t');
            for (int i = 0; i < sCells.GetLength(0); ++i)
            {
                if (iColIndex + i < dataGrid.ColumnCount)
                {
                    int currentIndex = 0;

                    if (i > 0)
                    {
                        parametrs.DisplayIndex = iColDisplayIndex + i;
                        foreach (DataGridViewColumn col in dataGrid.Columns)
                        {
                            if (col.DisplayIndex == parametrs.DisplayIndex)
                            {
                                currentIndex = col.Index;
                                break;
                            }
                        }
                        parametrs.Cell = dataGrid[currentIndex, parametrs.Row];
                    }
                    else
                        parametrs.Cell = dataGrid[iColIndex + i, parametrs.Row];


                    if (!parametrs.Cell.ReadOnly)
                    {
                        if (parametrs.Cell.Value.ToString() != sCells[i])
                        {
                            if (parametrs.Cell.OwningColumn.DataPropertyName ==
                                wH.OperationDocRows.Item_IDColumn.Caption)
                            {
                                if (!Int32.TryParse(parametrs.Cell.Value.ToString().Trim(), out itemID))
                                    itemID = 0;
                                parametrs.Cell.Value = itemID;
                            }

                            if (parametrs.Cell.OwningColumn.DataPropertyName ==
                                wH.OperationDocRows.QuantityColumn.Caption)
                            {
                                if (!Decimal.TryParse(parametrs.Cell.Value.ToString().Trim(), out quantity))
                                    quantity = 0;
                                parametrs.Cell.Value = quantity;
                            }

                            if (parametrs.Cell.ValueType == typeof(string) || parametrs.Cell.ValueType == typeof(decimal))
                                parametrs.Cell.Value = Convert.ChangeType(sCells[i],
                                                                          parametrs.Cell.ValueType);
                        }
                    }
                }
                else
                {
                    break;
                }
            }
            parametrs.Row++;

            return new ImportParametrs { Cell = parametrs.Cell, DisplayIndex = parametrs.DisplayIndex, Row = parametrs.Row };
        }

        /// <summary>
        /// Метод, выполняющий вставку данных из буфера в текущие строки, а также добавляющий новые сроки из буфера
        /// </summary>
        /// <param name="dataGrid">наш грид</param>
        private void PasteClipboard(DataGridView dataGrid)
        {
            try
            {
                //Random rand = new Random();
                string s = Clipboard.GetText();
                string[] lines = s.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                int iFail = 0, iRow = dataGrid.CurrentCell.RowIndex;
                int iColIndex = dataGrid.CurrentCell.ColumnIndex;
                int iColDisplayIndex = dataGrid.CurrentCell.OwningColumn.DisplayIndex;
                DataGridViewCell oCell = null;
                int displayIndex = 0;

                bool regradeCoupleStarts = false; // начало позиций пересорта
                int regradeBatchID = 0; // партия для пересорта

                ImportParametrs parameters = new ImportParametrs { Cell = oCell, DisplayIndex = displayIndex, Row = iRow };

                foreach (string line in lines)
                {
                    if (parameters.Row < dataGrid.RowCount && line.Length > 0)
                    {
                        parameters = PasteRows(line, dataGrid, iColIndex, iColDisplayIndex, parameters);
                    }
                    else
                    {
                        //operationDocRowsBindingSource.SuspendBinding(); // TODO остановим привязку данных
                        switch (OperationTypeID)
                        {
                            case "I":
                            case "P":
                                string lineType = string.Empty;
                                if ((regradeCoupleStarts = !regradeCoupleStarts) == true)
                                {
                                    lineType = FROM_LINE_TYPE;
                                    regradeBatchID = CheckBatchId();
                                }
                                else
                                {
                                    lineType = TO_LINE_TYPE;
                                }

                                InsertLine(lineType, false, regradeBatchID);
                                PasteRows(line, dataGrid, iColIndex, iColDisplayIndex, parameters);

                                //batchId = CheckBatchId();
                                //InsertLine(FROM_LINE_TYPE, false, batchId);
                                //PasteRows(line, dataGrid, iColIndex, iColDisplayIndex, parameters);
                                //InsertLine(TO_LINE_TYPE, false, batchId);
                                //PasteRows(line, dataGrid, iColIndex, iColDisplayIndex, parameters);
                                break;
                            case "M":
                            case "V":
                                int batchId1 = CheckBatchId();
                                InsertLine(BOTH_LINE_TYPE, false, batchId1);
                                PasteRows(line, dataGrid, iColIndex, iColDisplayIndex, parameters);
                                break;
                            case "S":
                                int batchId2 = CheckBatchId();
                                InsertLine(FROM_LINE_TYPE, false, batchId2);
                                PasteRows(line, dataGrid, iColIndex, iColDisplayIndex, parameters);
                                break;
                        }
                    }
                    if (iFail > 0)
                        MessageBox.Show(string.Format("{0} апдейт не выполнен" +
                                        " для колонок только для чтения", iFail));
                }
            }
            catch (FormatException)
            {
                MessageBox.Show(@"Данные, что вставлены в ячейку имеют неверный формат!");
            }
        }

        #endregion

        #region Фоновая вставка новых строк из буфера обмена (НА ДАННЫЙ МОМЕНТ НЕ ИСПОЛЬЗУЕТСЯ)
        /// <summary>
        /// Вставка строк операций из буфера обмена
        /// </summary>
        private void PasteOperations()
        {
            BackgroundWorker pasteWorker = new BackgroundWorker();
            pasteWorker.DoWork += new DoWorkEventHandler(pasteWorker_DoWork);
            pasteWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(pasteWorker_RunWorkerCompleted);
            pasteWorker.ProgressChanged += new ProgressChangedEventHandler(pasteWorker_ProgressChanged);
            pasteWorker.WorkerReportsProgress = true;
            waitProcessForm.ActionText = "Вставка строк операции из буфера...";
            pasteWorker.RunWorkerAsync(new PasteWorkerParameters { ClipboardText = Clipboard.GetText(), OwnerWorker = pasteWorker, dataGrid = dgvOperationDetails });
            waitProcessForm.ShowDialog();

            pasteWorker.DoWork -= new DoWorkEventHandler(pasteWorker_DoWork);
            pasteWorker.RunWorkerCompleted -= new RunWorkerCompletedEventHandler(pasteWorker_RunWorkerCompleted);
            pasteWorker.ProgressChanged -= new ProgressChangedEventHandler(pasteWorker_ProgressChanged);
        }

        /// <summary>
        /// Параметры фоновой вставки из буфера обмена
        /// </summary>
        private class PasteWorkerParameters
        {
            public string ClipboardText { get; set; }
            public BackgroundWorker OwnerWorker { get; set; }
            public DataGridView dataGrid { get; set; }
        }

        private void pasteWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            waitProcessForm.ActionText = string.Format("Вставка строк операции из буфера...\nОбработано {0}%", e.ProgressPercentage);
        }

        private void pasteWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            List<Data.WH.OperationDocRowsRow> insertedRows = new List<Data.WH.OperationDocRowsRow>();
            try
            {
                operationDocRowsBindingSource.SuspendBinding(); // TODO остановим привязку данных

                var parameters = e.Argument as PasteWorkerParameters;
                string buffer = parameters.ClipboardText;
                DataGridView dataGrid = parameters.dataGrid;

                //List<Error> errorItems = new List<Error>();
                List<ErrorItemDescription> errorDescriptionItems = null;

                string[] operationBufferLines = buffer.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                int rowNum = 0; // фиктивный номер записи
                int totalRowsNum = operationBufferLines.Length; // к-во записей

                if (dataGrid.Columns.Count == 0)
                    return;

                int lotNumberIndex = 0, locationFromIndex = 0, locationToIndex = 0, quantityIndex = 0,
                    ssccFromIndex = 0, ssccToIndex = 0, vendorLotIndex = 0, manufacturerIndex = 0,
                    expDateIndex = 0, basePriceIndex = 0, basePriceAmountIndex = 0, costPriceIndex = 0,
                    costAmountIndex = 0, itemNameIndex = 0, lotStatusIndex = 0, lotStatusCodeIndex = 0,
                    unitOfMeasureIndex = 0, gLCategoryIndex = 0, IC_LocationIndex = 0, IC_LocationToIndex = 0;

                #region Присвоение значений из буфера соответствующим DisplayIndex'ам колонок
                foreach (DataGridViewColumn col in dataGrid.Columns)
                {
                    if (col.Visible)
                    {
                        if (col.DataPropertyName == wH.OperationDocRows.Lot_NumberColumn.Caption)
                            lotNumberIndex = col.DisplayIndex;
                        if (col.DataPropertyName == wH.OperationDocRows.LocationColumn.Caption)
                            locationFromIndex = col.DisplayIndex;
                        if (col.DataPropertyName == wH.OperationDocRows.Location_ToColumn.Caption)
                            locationToIndex = col.DisplayIndex;
                        if (col.DataPropertyName == wH.OperationDocRows.QuantityColumn.Caption)
                            quantityIndex = col.DisplayIndex;
                        if (col.DataPropertyName == wH.OperationDocRows.SSCC_FromColumn.Caption)
                            ssccFromIndex = col.DisplayIndex;
                        if (col.DataPropertyName == wH.OperationDocRows.SSCC_ToColumn.Caption)
                            ssccToIndex = col.DisplayIndex;
                        if (col.DataPropertyName == wH.OperationDocRows.VendorLotColumn.Caption)
                            vendorLotIndex = col.DisplayIndex;
                        if (col.DataPropertyName == wH.OperationDocRows.ManufacturerColumn.Caption)
                            manufacturerIndex = col.DisplayIndex;
                        if (col.DataPropertyName == wH.OperationDocRows.ExpDateColumn.Caption)
                            expDateIndex = col.DisplayIndex;
                        if (col.DataPropertyName == wH.OperationDocRows.BasePriceColumn.Caption)
                            basePriceIndex = col.DisplayIndex;
                        if (col.DataPropertyName == wH.OperationDocRows.BasePriceAmountColumn.Caption)
                            basePriceAmountIndex = col.DisplayIndex;
                        if (col.DataPropertyName == wH.OperationDocRows.CostPriceColumn.Caption)
                            costPriceIndex = col.DisplayIndex;
                        if (col.DataPropertyName == wH.OperationDocRows.CostAmountColumn.Caption)
                            costAmountIndex = col.DisplayIndex;
                        if (col.DataPropertyName == wH.OperationDocRows.ItemNameColumn.Caption)
                            itemNameIndex = col.DisplayIndex;
                        if (col.DataPropertyName == wH.OperationDocRows.LotStatusColumn.Caption)
                            lotStatusIndex = col.DisplayIndex;
                        if (col.DataPropertyName == wH.OperationDocRows.LotStatusCodeColumn.Caption)
                            lotStatusCodeIndex = col.DisplayIndex;
                        if (col.DataPropertyName == wH.OperationDocRows.UnitOfMeasureColumn.Caption)
                            unitOfMeasureIndex = col.DisplayIndex;
                        if (col.DataPropertyName == wH.OperationDocRows.GLCategoryColumn.Caption)
                            gLCategoryIndex = col.DisplayIndex;
                        if (col.DataPropertyName == wH.OperationDocRows.IC_LocationColumn.Caption)
                            IC_LocationIndex = col.DisplayIndex;
                        if (col.DataPropertyName == wH.OperationDocRows.IC_Location_ToColumn.Caption)
                            IC_LocationToIndex = col.DisplayIndex;
                    }
                }
                #endregion


                if (operationBufferLines.Length == 0)
                    return;
                //if (operationBufferLines.Length == 0)
                //{
                //    operationBufferLines = new string[1];
                //    operationBufferLines[0] = "";
                //}

                foreach (string operationLine in operationBufferLines)
                {
                    parameters.OwnerWorker.ReportProgress((int)(((double)rowNum / totalRowsNum) * 100));
                    rowNum++;

                    string[] operationLineItems = operationLine.Split('\t');

                    string typeFT = string.Empty;
                    int itemID = -1;
                    decimal quantity = 0, basePrice = 0, basePriceAmount = 0, costPrice = 0, costAmount = 0;
                    DateTime expDate;

                    #region Валидация вставляемых данных
                    //Валидация типа операции                   
                    typeFT = operationLineItems[0].Trim().ToUpper();
                    var list = new List<string>();

                    if (!(typeFT == TO_LINE_TYPE || typeFT == FROM_LINE_TYPE || typeFT == BOTH_LINE_TYPE))
                    {
                        if (IsMovementOperation() || IsVirtualMovementOperation())
                        {
                            list.Add(BOTH_LINE_TYPE);
                            list.AddRange(operationLineItems);
                            operationLineItems = list.ToArray();
                            typeFT = operationLineItems[0];
                        }
                        else
                            continue;
                    }

                    //Проверка типа операции
                    if (typeFT == BOTH_LINE_TYPE && (IsRegradingOfLotsOperation() || IsRegradingOfGoodsOperation()))
                        continue;
                    if (typeFT != BOTH_LINE_TYPE && (IsMovementOperation() || IsVirtualMovementOperation()))
                        continue;
                    if (typeFT != FROM_LINE_TYPE && IsWriteOffOperation())
                        continue;

                    //Валидация кода товара
                    if (operationLineItems.Length > 1 && !Int32.TryParse(operationLineItems[1].Trim(), out itemID))
                        itemID = 0;
                    //Валидация вставляемых данных
                    if (quantityIndex >= operationLineItems.Length || !Decimal.TryParse(operationLineItems[quantityIndex].Trim(), out quantity))
                        quantity = 0;

                    string lotNumber = lotNumberIndex < operationLineItems.Length ? operationLineItems[lotNumberIndex].Trim() : "";
                    string location = locationFromIndex < operationLineItems.Length ? operationLineItems[locationFromIndex].Trim() : "";
                    string locationTo = locationToIndex < operationLineItems.Length ? operationLineItems[locationToIndex].Trim() : "";
                    string ssccFrom = ssccFromIndex < operationLineItems.Length ? operationLineItems[ssccFromIndex].Trim() : "";
                    string ssccTo = ssccToIndex < operationLineItems.Length ? operationLineItems[ssccToIndex].Trim() : "";

                    //Нередактируемые поля
                    string vendorLot = vendorLotIndex < operationLineItems.Length ? operationLineItems[vendorLotIndex].Trim() : "";
                    string manufacturer = manufacturerIndex < operationLineItems.Length ? operationLineItems[manufacturerIndex].Trim() : "";
                    string itemName = itemNameIndex < operationLineItems.Length ? operationLineItems[itemNameIndex].Trim() : "";
                    string unitOfMeasure = unitOfMeasureIndex < operationLineItems.Length ? operationLineItems[unitOfMeasureIndex].Trim() : "";
                    string lotStatus = lotStatusIndex < operationLineItems.Length ? operationLineItems[lotStatusIndex].Trim() : "";
                    string lotStatusCode = lotStatusCodeIndex < operationLineItems.Length ? operationLineItems[lotStatusCodeIndex].Trim() : "";
                    string gLCategory = gLCategoryIndex < operationLineItems.Length ? operationLineItems[gLCategoryIndex].Trim() : "";
                    string IC_Location = IC_LocationIndex < operationLineItems.Length ? operationLineItems[IC_LocationIndex].Trim() : "";
                    string IC_LocationTo = IC_LocationToIndex < operationLineItems.Length ? operationLineItems[IC_LocationToIndex].Trim() : "";

                    if (expDateIndex >= operationLineItems.Length || !DateTime.TryParse(operationLineItems[expDateIndex].Trim(), out expDate))
                        expDate = DateTime.Now.Date;
                    if (basePriceIndex >= operationLineItems.Length || !Decimal.TryParse(operationLineItems[basePriceIndex].Trim(), out basePrice))
                        basePrice = 0;
                    if (basePriceAmountIndex >= operationLineItems.Length || !Decimal.TryParse(operationLineItems[basePriceAmountIndex].Trim(), out basePriceAmount))
                        basePriceAmount = 0;
                    if (costPriceIndex >= operationLineItems.Length || !Decimal.TryParse(operationLineItems[costPriceIndex].Trim(), out costPrice))
                        costPrice = 0;
                    if (costAmountIndex >= operationLineItems.Length || !Decimal.TryParse(operationLineItems[costAmountIndex].Trim(), out costAmount))
                        costAmount = 0;
                    #endregion

                    //var newOperationLine = InsertLine(typeFT, true);
                    Random rand = new Random();
                    int batchId1 = rand.Next(100000);
                    var newOperationLine = InsertLine(typeFT, true, batchId1);
                    insertedRows.Add(newOperationLine); // добавим запись в коллекцию

                    newOperationLine.Item_ID = itemID;
                    newOperationLine.Lot_Number = lotNumber;
                    newOperationLine.Location = location;
                    newOperationLine.Location_To = locationTo;
                    newOperationLine.Quantity = quantity;
                    newOperationLine.CostPrice = costPrice;
                    newOperationLine.CostAmount = costAmount;
                    newOperationLine.BasePrice = basePrice;
                    newOperationLine.BasePriceAmount = basePriceAmount;
                    newOperationLine.ExpDate = expDate;
                    newOperationLine.GLCategory = gLCategory;
                    newOperationLine.IC_Location = IC_Location;
                    newOperationLine.IC_Location_To = IC_LocationTo;
                    newOperationLine.SSCC_From = ssccFrom;
                    newOperationLine.SSCC_To = ssccTo;
                    newOperationLine.ItemName = itemName;
                    newOperationLine.LotStatus = lotStatus;
                    newOperationLine.LotStatusCode = lotStatusCode;
                    newOperationLine.Manufacturer = manufacturer;
                    newOperationLine.UnitOfMeasure = unitOfMeasure;
                    newOperationLine.VendorLot = vendorLot;

                    //SetItemInfo(ref newOperationLine);

                    //if (newOperationLine.FT == TO_LINE_TYPE)
                    //    SetLotInfo(ref newOperationLine);
                    //else
                    //    SetLocationInfo(ref newOperationLine);

                    //// Обновление UI в процессе вставки записей из буфера
                    if (dataGrid.InvokeRequired)
                    {
                        RefreshGridDelegate refreshHandler = new RefreshGridDelegate(RefreshGrid);
                        dataGrid.Invoke(refreshHandler, false);
                    }

                    newOperationLine.Quantity = quantity;
                }

                //if (errorItems.Count > 0)
                //    throw new ComplexRowException(errorItems);


                e.Result = new PasteWorkerResult() { InsertedRows = insertedRows };
            }
            catch (Exception error)
            {
                e.Result = new PasteWorkerResult() { Error = error, InsertedRows = insertedRows };
            }
        }

        /// <summary>
        /// Результат фоновой вставки из буфера обмена
        /// </summary>
        private class PasteWorkerResult
        {
            public Exception Error { get; set; }
            public List<Data.WH.OperationDocRowsRow> InsertedRows { get; set; }
        }

        delegate void RefreshGridDelegate(bool schemaUpdated);
        private void RefreshGrid(bool schemaUpdated)
        {
            operationDocRowsBindingSource.SuspendBinding();
            operationDocRowsBindingSource.ResetBindings(false);

            dgvOperationDetails.Refresh();
        }

        private void pasteWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var result = e.Result as PasteWorkerResult;

            //if (result.Error != null && result.Error is ComplexRowException)
            //    new ComplexRowErrorsDialog()
            //    {
            //        ErrorDataSource = (result.Error as ComplexRowException).Errors,
            //        ErrorDescription = "Во время импорта произошли ошибки при валидации отдельных строк.",
            //        ErrorCaption = "Импорт операций"
            //    }.ShowDialog();

            // Добавление созданных строк в источник данных после завершения фоновой операции вставки из буфера обмена
            foreach (Data.WH.OperationDocRowsRow insertedRow in result.InsertedRows)
                wH.OperationDocRows.AddOperationDocRowsRow(insertedRow);
            try
            {
                // Пересчитаем итоги
                RecalculateAmounts();
                operationDocRowsBindingSource.ResetBindings(false);
                operationDocRowsBindingSource.ResumeBinding(); // TODO восстановим привязку данных
                waitProcessForm.CloseForce();
                SaveOperation();
                VerifyCells();

                dgvOperationDetails.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Ошибка вставки новых строк из Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }

    #region Класс-обертка для процедуры pr_WW_CheckLines (содержит цвета раскраски и сообщения об ошибках)

    public class CheckedLineValues
    {
        public CheckedLineValues(Data.WH.CheckLinesResponseRow line)
        {
            Doc_ID = line.Doc_ID;
            Batch_ID = line.Batch_ID;
            ItemFrom = line.ItemFrom;
            ItemFrom_Color = line.ItemFrom_Color;
            ItemTo = line.ItemTo;
            ItemTo_Color = line.ItemTo_Color;
            LotFrom = line.LotFrom;
            LotFrom_Color = line.LotFrom_Color;
            LotTo = line.LotTo;
            LotTo_Color = line.LotTo_Color;
            LocationFrom = line.LocationFrom;
            LocationFrom_Color = line.LocationFrom_Color;
            LocationTo = line.LocationTo;
            LocationTo_Color = line.LocationTo_Color;
            QuantityFrom = line.QuantityFrom;
            QuantityFrom_Color = line.QuantityFrom_Color;
            QuantityTo = line.QuantityTo;
            QuantityTo_Color = line.QuantityTo_Color;
            SSCCFrom = line.SSCCFrom;
            SSCCFrom_Color = line.SSCCFrom_Color;
            SSCCTo = line.SSCCTo;
            SSCCTo_Color = line.SSCCTo_Color;
        }

        public long Doc_ID { get; set; }
        public long Batch_ID { get; set; }
        public string ItemFrom { get; set; }
        public string ItemFrom_Color { get; set; }
        public string ItemTo { get; set; }
        public string ItemTo_Color { get; set; }
        public string LotFrom { get; set; }
        public string LotFrom_Color { get; set; }
        public string LotTo { get; set; }
        public string LotTo_Color { get; set; }
        public string LocationFrom { get; set; }
        public string LocationFrom_Color { get; set; }
        public string LocationTo { get; set; }
        public string LocationTo_Color { get; set; }
        public string QuantityFrom { get; set; }
        public string QuantityFrom_Color { get; set; }
        public string QuantityTo { get; set; }
        public string QuantityTo_Color { get; set; }
        public string SSCCFrom { get; set; }
        public string SSCCFrom_Color { get; set; }
        public string SSCCTo { get; set; }
        public string SSCCTo_Color { get; set; }
    }
    #endregion

    #region Класс-обертка для цвета ячейки во время валидации
    public class SaveCurrentCellColor
    {
        public Color BackGroundColor { get; set; }
        public string ToolTip { get; set; }
    }
    #endregion

    #region Класс-обертка для импорта из Excel
    public class ImportParametrs
    {
        public int DisplayIndex { get; set; }
        public int Row { get; set; }
        public DataGridViewCell Cell { get; set; }
    }
    #endregion
}