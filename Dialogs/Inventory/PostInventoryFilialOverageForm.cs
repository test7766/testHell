using System;
using System.Text;
using System.Windows.Forms;

using WMSOffice.Controls;
using WMSOffice.Data.InventoryTableAdapters;
using System.Data;

namespace WMSOffice.Dialogs.Inventory
{
    /// <summary>
    /// Окно для приходования излишков
    /// </summary>
    public partial class PostInventoryFilialOverageForm : Form
    {
        #region ПЕРЕМЕННЫЕ И СВОЙСТВА

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private long sessionID;

        /// <summary>
        /// Инвентаризация, для которой проводится приходование излишков
        /// </summary>
        private readonly Data.Inventory.FP_Get_InventoriesRow invRow;

        /// <summary>
        /// Идентификатор документа приходования излишков
        /// </summary>
        private long docID;

        /// <summary>
        /// Список идентификаторов отмеченных приходований, разделенный запятыми
        /// </summary>
        private string CheckedList
        {
            get
            {
                var str = new StringBuilder();
                foreach (Data.Inventory.FP_Get_Items_For_Overage_ReceiptRow row in inventory.FP_Get_Items_For_Overage_Receipt)
                    if (row.CheckedFlag)
                    {
                        if (str.Length > 0)
                            str.Append(",");
                        str.Append(row.Код_строки);
                    }
                return str.ToString();
            }
        }

        /// <summary>
        /// True, если редактируется уже существующий документ, False если создается новый документ
        /// </summary>
        private bool isEditMode;

        private string _CorrectionType = "CO";
        public string CorrectionType { get { return _CorrectionType; } set { _CorrectionType = value; } }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ

        public PostInventoryFilialOverageForm(int pSessionID, Data.Inventory.FP_Get_InventoriesRow pInv)
        {
            InitializeComponent();
            sessionID = pSessionID;
            invRow = pInv;
            docID = pInv.Inventory_number;
            CustomCheckHeader();

            btnChangePlace.Visible = pInv.Inventory_type == "PI"; // смена полки только для частичной инвентаризации
        }

        /// <summary>
        /// Настройка заголовка для CheckBox-колонки таблицы приходований излишков
        /// </summary>
        private void CustomCheckHeader()
        {
            var checkHeaderCell = new DataGridViewHeaderCheckBoxCell();
            checkHeaderCell.OnCheckBoxClicked += checkHeaderCell_OnCheckBoxClicked;
            checkHeaderCell.Value = String.Empty;
            clChecked.HeaderCell = checkHeaderCell;
        }

        /// <summary>
        /// Выбор/снятие флажка со всех строк при выборе флажка в заголовке колонки
        /// </summary>
        /// <param name="pState">True, если флажок в заголовке был выбран, False - если снят</param>
        public void checkHeaderCell_OnCheckBoxClicked(bool pState)
        {
            foreach (Data.Inventory.FP_Get_Items_For_Overage_ReceiptRow row in inventory.FP_Get_Items_For_Overage_Receipt)
                if (row.CheckedFlag != pState)
                    row.CheckedFlag = pState;

            dgvOverages.RefreshEdit();
            bsFpGetItemsForOverageReceipt.ResetBindings(false);
        }

        private void ChangeState(Data.Inventory.FP_Get_Items_For_Overage_ReceiptRow receiptRow, bool isChecked)
        {
            if (receiptRow.IsКод_товараNull())
                return;
            foreach (Data.Inventory.FP_Get_Items_For_Overage_ReceiptRow row in inventory.FP_Get_Items_For_Overage_Receipt)
            {
                if (row.Код_товара == receiptRow.Код_товара && row.TransactionNumber == receiptRow.TransactionNumber)
                {
                    row.CheckedFlag = isChecked;
                    dgvOverages.RefreshEdit();
                    bsFpGetItemsForOverageReceipt.ResetBindings(false);
                }
            }
        }

        public PostInventoryFilialOverageForm(int pSessionID, Data.Inventory.FP_Get_InventoriesRow pInv, long pDocID)
            : this(pSessionID, pInv)
        {
            docID = pDocID;
            isEditMode = true;
            //if (pDoc.CorrectionType == "CN")
            //    Text = "Пересорт";
        }

        /// <summary>
        /// Загрузка излишков при загрузке окна
        /// </summary>
        private void PostInventoryFilialOverageForm_Load(object sender, EventArgs e)
        {
            if (!isEditMode)
                if (!CreateNewDoc())
                {
                    Close();
                    return;
                }

            LoadOverages(); 
            tbxFilter.Focus();
            Config.LoadDataGridViewSettings(Name, dgvOverages);
        }


        /// <summary>
        /// Загрузка излишков
        /// </summary>
        private void LoadOverages()
        {
            try
            {
                //if (!isEditMode)
                //    taFpGetItemsForOverageReceipt.Fill(inventory.FP_Get_Items_For_Overage_Receipt, invRow.Inventory_number);
                //else

                taFpGetItemsForOverageReceipt.SetTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds);
                taFpGetItemsForOverageReceipt.FillFromTemplates(inventory.FP_Get_Items_For_Overage_Receipt, docID);
                SetRowColor();
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Ошибка при загрузке излишков для приходования!", exc);
            }
        }

        /// <summary>
        /// Создание идентификатора для приходования излишков
        /// </summary>
        /// <returns>True, если создан идентификатор документа приходования излишков, False если возникла ошибка</returns>
        private bool CreateNewDoc()
        {
            try
            {
                using (var adapter = new FP_Get_Items_For_ReparationTableAdapter())
                {
                    adapter.SetTimeout((int)TimeSpan.FromMinutes(20).TotalSeconds);
                    docID = Convert.ToInt32(adapter.AddCorrection(sessionID, invRow.Inventory_number, CorrectionType));
                }
                return true;
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Ошибка при создании идентификатора для потоварного пересорта", exc);
                return false;
            }
        }

        /// <summary>
        /// По нажатию Ctrl+F переходим на фильтр
        /// </summary>
        private void PostInventoryFilialOverageForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F)
                tbxFilter.Focus();
        }

        #endregion

        #region ФИЛЬТРАЦИЯ ТОВАРОВ В ТАБЛИЦЕ

        /// <summary>
        /// Строка фильтра
        /// </summary>
        private string filter;

        /// <summary>
        /// Применение фильтра при окончании работы таймера
        /// </summary>
        private void delayTimer_Tick(object sender, EventArgs e)
        {
            delayTimer.Stop();
            RefreshFilter();
        }

        /// <summary>
        /// Обновление фильтров на таблице
        /// </summary>
        private void RefreshFilter()
        {
            try
            {
                if (String.IsNullOrEmpty(filter))
                    bsFpGetItemsForOverageReceipt.Filter = String.Empty;
                else
                    bsFpGetItemsForOverageReceipt.Filter =
                        String.Format("Convert([Код товара], 'System.String') LIKE '%{0}%' OR [Наименование] LIKE '%{0}%'", filter);
            }
            catch { }   // Нам тут не важно, какая ошибка - главное чтобы не слетала программа

        }

        /// <summary>
        /// Изменение фильтра
        /// </summary>
        private void tbxFilter_TextChanged(object sender, EventArgs e)
        {
            filter = tbxFilter.Text;
            delayTimer.Stop();
            delayTimer.Start();
        }

        /// <summary>
        /// Запуск фильтрации по нажатию на кнопку Enter
        /// </summary>
        private void tbxFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                delayTimer.Stop();
                RefreshFilter();
            }
        }

        #endregion

        #region СОХРАНЕНИЕ РЕЗУЛЬТАТОВ РЕДАКТИРОВАНИЯ

        /// <summary>
        /// Сохранение результатов редактирования и выход при нажатии на кнопку ОК
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                taFpGetItemsForOverageReceipt.AddOverageDetails(sessionID, docID, CheckedList);
                MessageBox.Show("Все приходования успешно сохранены!", "Приходование излишков",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Ошибка при сохранении выбранных приходований!", exc);
            }
        }

        /// <summary>
        /// Сохранение настроек таблицы при закрытии окна
        /// </summary>
        private void PostInventoryFilialOverageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Config.SaveDataGridViewSettings(Name, dgvOverages);
        }

        #endregion

        private void dgvOverages_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!dgvOverages.Columns[e.ColumnIndex].Equals(clChecked))
                return;
            var row = inventory.FP_Get_Items_For_Overage_Receipt[e.RowIndex];
            ChangeState(row, !row.CheckedFlag);
        }

        private void SetRowColor()
        {
            try
            {
                foreach (DataGridViewRow gridRow in dgvOverages.Rows)
                {
                    gridRow.DefaultCellStyle.BackColor = System.Drawing.Color.Empty;

                    var row = (gridRow.DataBoundItem as DataRowView).Row as WMSOffice.Data.Inventory.FP_Get_Items_For_Overage_ReceiptRow;
                    if (row == null || row._Кол_во >= 0)
                        continue;

                    gridRow.DefaultCellStyle.BackColor = System.Drawing.Color.Lavender;
                }
            }
            catch (Exception)
            {

            }
        }

        private void dgvOverages_Sorted(object sender, EventArgs e)
        {
            SetRowColor();
        }

        private void btnChangePlace_Click(object sender, EventArgs e)
        {
            try
            {
                var correctionID = docID;
                var correctionType = "CO";

                Data.Inventory.FI_PlacesDataTable fi_places = null;
                using (var adapter = new Data.InventoryTableAdapters.FI_PlacesTableAdapter())
                    fi_places = adapter.GetData(sessionID, invRow.Inventory_number, correctionID);

                if (fi_places != null && fi_places.Rows.Count > 0)
                {
                    var dlgChangePlace = new WMSOffice.Dialogs.RichListForm();
                    dlgChangePlace.Text = "Выберите полку С";

                    dlgChangePlace.AddColumn("NamePlace", "NamePlace", "Склад - место");
                    dlgChangePlace.ColumnForFilters.Add("NamePlace");
                    dlgChangePlace.FilterChangeLevel = 0;
                    dlgChangePlace.DataSource = fi_places;

                    if (dlgChangePlace.ShowDialog() == DialogResult.OK)
                    {
                        var fi_place = dlgChangePlace.SelectedRow as Data.Inventory.FI_PlacesRow;

                        using (var adapter = new Data.InventoryTableAdapters.FI_PlacesTableAdapter())
                            adapter.EditDiffPlaceForSurplus(sessionID, invRow.Inventory_number, correctionID, correctionType, fi_place.warehouse_id, fi_place.place_code);

                        tbxFilter.Clear();
                        this.LoadOverages();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
