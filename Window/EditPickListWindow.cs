using System;
using System.Data;
using System.Windows.Forms;

using WMSOffice.Data;
using WMSOffice.Data.PickControlTableAdapters;
using WMSOffice.Dialogs.PickControl.EditPickList;
using EditPickListItemForm = WMSOffice.Dialogs.PickControl.EditPickListItemForm;

namespace WMSOffice.Window
{
    public partial class EditPickListWindow : Form
    {
        #region поля

        /// <summary>
        /// Номер компании (практически всегда 00001)
        /// </summary>
        private string _kcoo;

        /// <summary>
        /// Тип заказа (продажа, списание, врачебная, бюджетно-тендерная продажа)
        /// </summary>
        private string _dcto;

        /// <summary>
        /// Оригинальный номер заказа (из JD), не оригинальный (на разных филиалах), оригинально сочетание kcoo + dcto + doco
        /// </summary>
        private int _doco;

        /// <summary>
        /// Номер сборочного, не оригинальный, на разных филиалах могут быть одинаковые
        /// </summary>
        private int _psn;

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private int _sessionId;

        /// <summary>
        /// Идентификатор склада
        /// </summary>
        private string _warehouseId;

        /// <summary>
        /// Флаг, показывающий, можно ли закрывать окно (можно лишь после выполнения процедуры QueriesTableAdapter.CpCloseEditing
        /// </summary>
        private bool _allowClosing;

        #endregion

        #region КОНСТРУКТОРЫ

        public EditPickListWindow()
        {
            InitializeComponent();
        }

        public EditPickListWindow(string pKcoo, string pDcto, int pDoco, int pPsn, int pSessionId)
            : this()
        {
            _kcoo = pKcoo;
            _dcto = pDcto;
            _doco = pDoco;
            _psn = pPsn;
            _sessionId = pSessionId;
            InitPickListHeader();
            RefreshFormRows();
        }

        /// <summary>
        /// Инициализация общей информации по сборочному листу (в "шапке" формы)
        /// </summary>
        private void InitPickListHeader()
        {
            using (CpPickSlipHeaderTableAdapter adapter = new CpPickSlipHeaderTableAdapter())
            {
                PickControl.CpPickSlipHeaderDataTable pickListInfoTable = adapter.GetData(_kcoo, _dcto, _doco, _psn);
                PickControl.CpPickSlipHeaderRow pickListInfo = pickListInfoTable[0];
                lblDocType.Text = pickListInfo.Doc_type;
                lblDocNumber.Text = pickListInfo.Doc_number.ToString();
                lblDocDate.Text = pickListInfo.Order_Date.ToShortDateString();
                lblNumber.Text = pickListInfo.PickSlip.ToString();
                lblDelivery.Text = pickListInfo.Delivery;
                lblDeliveryDate.Text = pickListInfo.Delivery_Date.ToShortDateString();
                lblContainer.Text = pickListInfo.Conteiner_id;
                lblDepartment.Text = pickListInfo.OtdelName;
                lblRegim.Text = pickListInfo.Delivery_Zone;
                _warehouseId = pickListInfo.Warehouse_ID;
            }
        }

        /// <summary>
        /// Обновляет список товаров сборочного листа (загружает новые данные из базы)
        /// </summary>
        private void RefreshFormRows()
        {
            dsPickControl.CpPickSlipRow.Clear();
            taCpPickSlipRow.Fill(dsPickControl.CpPickSlipRow, _kcoo, _dcto, _doco, _psn);
        }

        #endregion

        #region свойства

        /// <summary>
        /// Выбранная строка сборочного
        /// </summary>
        public Data.PickControl.CpPickSlipRowRow SelectedRow
        {
            get { return (dgwLines.SelectedRows.Count > 0) ? ((Data.PickControl.CpPickSlipRowRow)((DataRowView)dgwLines.SelectedRows[0].DataBoundItem).Row) : null; }
        }

        /// <summary>
        /// Разрешено ли корректировать строку
        /// </summary>
        public bool AllowEditRow
        {
            get { return btnEditCurrentItem.Enabled; }
            set { btnEditCurrentItem.Enabled = value; }
        }

        /// <summary>
        /// Разрешено ли аннулировать строку
        /// </summary>
        public bool AllowDeleteRow
        {
            get { return btnDelCurrentItem.Enabled; }
            set { btnDelCurrentItem.Enabled = value; }
        }

        #endregion

        #region ОБРАБОТЧИКИ СОБЫТИЙ

        /// <summary>
        /// Строку, на которой щелкнули правой кнопкой мыши, делаем выбранной 
        /// </summary>
        private void DgvLines_RowContextMenuStripNeeded(object sender, DataGridViewRowContextMenuStripNeededEventArgs e)
        {
            (sender as DataGridView).Rows[e.RowIndex].Selected = true;
        }

        /// <summary>
        /// Запуск формы корректировки товара
        /// </summary>
        private void TsmiEditPickList_Click(object sender, EventArgs e)
        {
            if (AllowEditRow)
                DoEditPickListItem();
        }

        /// <summary>
        /// Запуск формы аннулирования товара
        /// </summary>
        private void tsmiDelPickList_Click(object sender, EventArgs e)
        {
            if (AllowDeleteRow)
                DoDelPickListItem();
        }

        /// <summary>
        /// Завершение корректировки сборочного листа по нажатию соответствующей кнопки на панели
        /// </summary>
        private void BtnCloseDoc_Click(object sender, EventArgs e)
        {
            FinishPickListEditing();
        }

        /// <summary>
        /// Завершение корректировки сборочного листа по нажатию кнопки F4 или корректировка выбраного товара по нажатию F2
        /// </summary>
        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            // закрываем корректировку
            if (e.KeyCode == Keys.F4)
                FinishPickListEditing();
            // запускаем аннулирование строки
            else if (e.KeyCode == Keys.F8 && AllowDeleteRow)
                btnDelCurrentItem_Click(btnDelCurrentItem, new EventArgs());
            // запускаем корректирование строки
            else if (e.KeyCode == Keys.F2 && AllowEditRow)
                BtnEditCurrentItem_Click(btnEditCurrentItem, new EventArgs());
        }

        /// <summary>
        /// Метод, который завершает корректировку сборочного листа и выполняет финальную процедуру в БД
        /// </summary>
        private void FinishPickListEditing()
        {
            // Уточняем
            if (MessageBox.Show("Вы точно хотите завершить корректировку сборочного листа?", "Завершение корректировки...",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            // Завершение корректировки сборочного листа
            using (QueriesTableAdapter adapter = new QueriesTableAdapter())
                adapter.CpCloseEditing(_kcoo, _dcto, _doco, _psn);

            // Подверждаем
            MessageBox.Show("Сборочный лист успешно скорректирован", "Завершение корректировки...",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Теперь окно закрывать можно
            _allowClosing = true;

            Close();    // Закрываем форму корректировки данного сборочного листа
        }

        /// <summary>
        /// Корректировка выбраного товара в таблице
        /// </summary>
        private void BtnEditCurrentItem_Click(object sender, EventArgs e)
        {
            DoEditPickListItem();
        }

        /// <summary>
        /// Аннулирование выбранной строки
        /// </summary>
        private void btnDelCurrentItem_Click(object sender, EventArgs e)
        {
            DoDelPickListItem();
        }

        /// <summary>
        /// Проверяем, можно ли на данном этапе закрыть окно
        /// </summary>
        private void EditPickListWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_allowClosing && (Control.ModifierKeys != Keys.Control))
            {
                MessageBox.Show("Пожалуйста, завершите сначала корректировку!", "Завершение корректировки...",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Обработка выбора строки в списке - делаем доступными операции со строкой
        /// </summary>
        private void dgwLines_SelectionChanged(object sender, EventArgs e)
        {
            if (SelectedRow != null)
            {
                // делаем доступными операции со строкой
                AllowEditRow = SelectedRow.CanBeCorrected;
                AllowDeleteRow = SelectedRow.CanBeCanceled;
            } else
            {
                AllowEditRow = AllowDeleteRow = false;
            }
        }

        /// <summary>
        /// Событие загрузки формы
        /// </summary>
        private void EditPickListWindow_Load(object sender, EventArgs e)
        {
            // при запуске формы запрещаем операции, строка не выбрана
            AllowEditRow = AllowDeleteRow = false;
        }

        #endregion

        #region методы

        /// <summary>
        /// Метод аннулирования строки сборочного в WMS
        /// </summary>
        private void DoDelPickListItem()
        {
            var sel = SelectedRow;
            if (sel != null)
            {
                var form = new Dialogs.PickControl.EditPickList.EditPickListItemForm(
                    new CancellationFormsFactory(), 
                    new PickListRow()
                        {
                            Company = _kcoo,
                            DocumentType = _dcto,
                            DocumentNumber = _doco,
                            PickSlipNumber = _psn,
                            LineId = (int)sel.Line_ID,
                            ItemId = (int)sel.Item_ID,
                            Item = sel.ItemName,
                            Manufacturer = sel.Manufacturer,
                            Series = (sel.IsVendorLotNull()) ? String.Empty : sel.VendorLot,
                            Lot = (sel.IsLotNumberNull()) ? String.Empty : sel.LotNumber,
                            Location = (sel.IsLocationNull()) ? String.Empty : sel.Location,
                            UnitOfMeasure = (sel.IsUnitOfMeasureNull()) ? String.Empty : sel.UnitOfMeasure,
                            Quantity = (int)sel.Quantity
                        },
                    _sessionId)
                               {
                                   Caption = "Аннулирование строки"
                               };
                // получаем причины аннулирования по строке
                using (CP_ReasonsTableAdapter adapter = new CP_ReasonsTableAdapter())
                {
                    var table = adapter.GetCancelationReasons(_sessionId, _kcoo, _dcto, _doco, _psn, sel.Line_ID);
                    foreach (PickControl.CP_ReasonsRow row in table.Rows)
                    {
                        int reasonid = 0;
                        if (int.TryParse(row.reason_code_id, out reasonid))
                            form.Reasons.Add(new CorrectionReason(reasonid, row.reason_code));
                    }
                }
                // показать форму аннулирования
                if (form.ShowDialog() == DialogResult.OK)
                    RefreshFormRows();
            }
        }

        /// <summary>
        /// Метод корректировки строки сборочного в WMS, как он был создан изначально
        /// </summary>
        private void DoEditPickListItem()
        {
            var sel = SelectedRow;
            if (sel != null)
            {
                var form = new Dialogs.PickControl.EditPickList.EditPickListItemForm(
                    new CorrectionFormsFactory(),
                    new PickListRow()
                    {
                        Company = _kcoo,
                        DocumentType = _dcto,
                        DocumentNumber = _doco,
                        PickSlipNumber = _psn,
                        LineId = (int)sel.Line_ID,
                        ItemId = (int)sel.Item_ID,
                        Item = sel.ItemName,
                        Manufacturer = sel.Manufacturer,
                        Series = (sel.IsVendorLotNull()) ? String.Empty : sel.VendorLot,
                        Lot = (sel.IsLotNumberNull()) ? String.Empty : sel.LotNumber,
                        Location = (sel.IsLocationNull()) ? String.Empty : sel.Location,
                        UnitOfMeasure = (sel.IsUnitOfMeasureNull()) ? String.Empty : sel.UnitOfMeasure,
                        Quantity = (int)sel.Quantity
                    },
                    _sessionId)
                {
                    Caption = "Корректировка строки",
                    NotSetDefaultReason = true
                };
                // получаем причины корректировки по строке
                using (CP_ReasonsTableAdapter adapter = new CP_ReasonsTableAdapter())
                {
                    var table = adapter.GetCorrectionReasons(_sessionId, _kcoo, _dcto, _doco, _psn, sel.Line_ID);
                    foreach (PickControl.CP_ReasonsRow row in table.Rows)
                    {
                        int reasonid = 0;
                        if (int.TryParse(row.reason_code_id, out reasonid))
                            form.Reasons.Add(new CorrectionReason(reasonid, row.reason_code));
                    }
                }
                // показать форму корректировки
                if (form.ShowDialog() == DialogResult.OK)
                    RefreshFormRows();
            }
            //// проверка наличия запроса на корректировку от ТП
            //using (CpCheckRequestFromTPTableAdapter adapterCheck = new CpCheckRequestFromTPTableAdapter())
            //{
            //    var table = adapterCheck.GetData(_sessionId, _kcoo, _dcto, _doco,
            //                         Convert.ToDouble(dgwLines.SelectedRows[0].Cells["dgwtbcLineId"].Value));
            //    if (table != null && table.Count == 1)
            //    {
            //        // есть запрос на корректировку, т.е. тип корректировки выбран и единственное допустимое действие - аннулирование строки
            //        var row = table[0];
            //        // Инициализируем данные о товаре (из соответствующей строки DataGridView)
            //        var item = dgwLines.SelectedRows[0].Cells["dgwtbcItemName"].Value.ToString().Trim(); ;
            //        var vendorLot = dgwLines.SelectedRows[0].Cells["dgwtbcVendorLot"].Value.ToString().Trim();
            //        var lotNumber = dgwLines.SelectedRows[0].Cells["dgwtbcLotNumber"].Value.ToString().Trim();
            //        var unitOfMeasure = dgwLines.SelectedRows[0].Cells["dgwtbcUnitOfMeasure"].Value.ToString().Trim();
            //        var locn = dgwLines.SelectedRows[0].Cells["dgwtbcLocation"].Value.ToString().Trim();
            //        var qty = Convert.ToDouble(dgwLines.SelectedRows[0].Cells["dgwtbcQuantity"].Value);

            //        string message = String.Format("На данную строку сборочного из офиса была запрошена корректировка менеджером торгового отдела.\rТип: {0}\rОписание: {1}\r\rНаименование: {2}\rСерия: {3}\rКоличество: {4}\r\rСтрока будет вычеркнута из сборочного.\rВыполнить корректировку?",
            //                    row.Reason_Code, row.Reason_Info, item, vendorLot, qty);
            //        if (MessageBox.Show(message, "Корректировка сборочного по запросу ТП", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            //        {

            //            using (QueriesTableAdapter adapter = new QueriesTableAdapter())
            //                adapter.CpCorrectDetail(_sessionId, _kcoo, _dcto, _doco, Convert.ToDouble(dgwLines.SelectedRows[0].Cells["dgwtbcLineId"].Value),
            //                    null, null, null, null,
            //                    null, null, null, null,
            //                    row.Reason_Code_ID, row.Reason_Info);

            //            RefreshFormRows();
            //        }
            //    }
            //    else
            //    {
            //        // корректировка строки по инициативе склада
            //        DoEditPickListItem();
            //    }
            //}
/*
            EditPickListItemForm editForm = new EditPickListItemForm();

            // Инициализируем данные о товаре (из соответствующей строки DataGridView)
            editForm.ItemID = Convert.ToInt32(dgwLines.SelectedRows[0].Cells["dgwtbcItemId"].Value);
            editForm.VendorLot = dgwLines.SelectedRows[0].Cells["dgwtbcVendorLot"].Value.ToString().Trim();
            editForm.LotNumber = dgwLines.SelectedRows[0].Cells["dgwtbcLotNumber"].Value.ToString().Trim();
            editForm.UnitOfMeasure = dgwLines.SelectedRows[0].Cells["dgwtbcUnitOfMeasure"].Value.ToString().Trim();
            editForm.Locn = dgwLines.SelectedRows[0].Cells["dgwtbcLocation"].Value.ToString().Trim();
            editForm.Qty = editForm.CurrentQty = Convert.ToDouble(dgwLines.SelectedRows[0].Cells["dgwtbcQuantity"].Value);

            // Инициализируем общие данные о сборочном листе
            editForm.SessionID = _sessionId;
            editForm.WarehouseId = _warehouseId;

            // Запускаем форму корректировки товара

            if (editForm.ShowDialog() == DialogResult.OK)
                try
                {
                    // Обновление в базе
                    using (QueriesTableAdapter adapter = new QueriesTableAdapter())
                        adapter.CpCorrectDetail(_sessionId, _kcoo, _dcto, _doco, Convert.ToDouble(dgwLines.SelectedRows[0].Cells["dgwtbcLineId"].Value),
                            editForm.Locn, editForm.LotNumber, editForm.UnitOfMeasure, editForm.CurrentQty - editForm.QtySplit,
                            editForm.LocnSplit, editForm.LotNumberSplit, editForm.UnitOfMeasureSplit, editForm.QtySplit,
                            editForm.ReasonCodeID, editForm.ReasonDescription);

                    RefreshFormRows();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }*/
        }

        #endregion

    }
}
