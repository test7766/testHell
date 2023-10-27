using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Timers;
using System.Transactions;
using System.Windows.Forms;

using WMSOffice.Controls;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Data.InventoryTableAdapters;
using System.Collections.Generic;
using WMSOffice.Classes;

namespace WMSOffice.Dialogs.Inventory
{
    /// <summary>
    /// Окно для создания/редактирования инвентаризации филиалов
    /// </summary>
    public partial class InventoryFilialEditForm : Form
    {
        #region КОНСТАНТЫ

        private readonly string executionMode = "INV_MODULE";

        #endregion

        #region ОСНОВНЫЕ ПЕРЕМЕННЫЕ И СВОЙСТВА КЛАССА

        /// <summary>
        /// Инвентаризация, которая редактируется. Если она еще не создана, то эта переменная равна null
        /// </summary>
        private WMSOffice.Data.Inventory.FI_Get_Inventory_ListsRow inventory;

        /// <summary>
        /// Признак, который показывает, в каком режиме открыто окно, создания новой инвентаризации или редактирования уже существующей.
        /// True, если редактирование, False если создание новой
        /// </summary>
        private bool isEditMode;

        /// <summary>
        /// DbAdapter для выполнения запросов, связанных со списком инвентаризаций
        /// </summary>
        private FI_Get_Inventory_ListsTableAdapter invAdapter = new FI_Get_Inventory_ListsTableAdapter();

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private long sessionID;

        /// <summary>
        /// Номер созданной инвентаризации
        /// </summary>
        private long inventoryNumber;

        /// <summary>
        /// Признак, показывающий, были ли произведены какие-либо изменения 
        /// (нужно ли после редактирования перезагружать список инвентаризаций)
        /// </summary>
        public bool WasChangesMade { get; private set; }

        #endregion

        #region СВОЙСТВА ДЛЯ ФОРМИРОВАНИЯ DelimetedList

        /// <summary>
        /// DelimetedList с отмеченными складами
        /// </summary>
        private string CheckedWarehouses
        {
            get
            {
                var s = new StringBuilder();
                foreach (Data.Inventory.FI_WarehousesRow row in inventory1.FI_Warehouses)
                    if (row.Checked)
                    {
                        s.Append(s.Length > 0 ? "," : String.Empty);
                        s.Append(row.Warehouse_ID);
                    }
                return s.ToString();
            }
        }

        /// <summary>
        /// DelimetedList с отмеченными зонами
        /// </summary>
        private string CheckedZones
        {
            get
            {
                var s = new StringBuilder();
                foreach (Data.Inventory.FI_ZonesRow row in inventory1.FI_Zones)
                    if (row.Checked)
                    {
                        s.Append(s.Length > 0 ? "," : String.Empty);
                        s.Append(row.Zone_ID);
                    }
                return s.ToString();
            }
        }

        /// <summary>
        /// DelimetedList с отмеченными стелажами
        /// </summary>
        private string CheckedStillages
        {
            get
            {
                var s = new StringBuilder();
                foreach (Data.Inventory.FI_StillagesRow row in inventory1.FI_Stillages)
                    if (row.Checked)
                    {
                        s.Append(s.Length > 0 ? "," : String.Empty);
                        s.Append(row.Stillage_ID);
                    }
                return s.ToString();
            }
        }

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ КЛАССА

        public InventoryFilialEditForm(long pUserID)
        {
            InitializeComponent();
            filterTimer.Elapsed += filterTimer_Elapsed;
            sessionID = pUserID;
            CustomCheckHeader(colCheckedWH, whHeaderCell_OnCheckBoxClicked);
            CustomCheckHeader(colCheckedZone, zoneHeaderCell_OnCheckBoxClicked);
            CustomCheckHeader(colCheckedStage, stageHeaderCell_OnCheckBoxClicked);
            CustomCheckHeader(colCheckedLocations, locationHeaderCell_OnCheckBoxClicked);
        }

        /// <summary>
        /// Настройка заголовка для заданной CheckBox-колонки тоже в виде CheckBox-а
        /// </summary>
        /// <param name="pColumn"></param>
        private static void CustomCheckHeader(DataGridViewColumn pColumn, CheckBoxClickedHandler pHandler)
        {
            var checkHeaderCell = new DataGridViewHeaderCheckBoxCell();
            checkHeaderCell.OnCheckBoxClicked += pHandler;
            checkHeaderCell.Value = String.Empty;
            pColumn.HeaderCell = checkHeaderCell;
        }

        /// <summary>
        /// Выбор/снятие флажка со всех строк при выборе флажка в заголовке колонки складов
        /// </summary>
        /// <param name="pState">True, если флажок в заголовке был выбран, False - если снят</param>
        public void whHeaderCell_OnCheckBoxClicked(bool pState)
        {
            foreach (DataGridViewRow row in dgvWarehouses.Rows)
                if (Convert.ToBoolean((row.Cells[0] as DataGridViewCheckBoxCell).Value) != pState)
                {
                    (row.Cells[0] as DataGridViewCheckBoxCell).Value = pState;
                    WarehouseWasChecked(row, pState);
                }
            dgvWarehouses.RefreshEdit();
        }

        /// <summary>
        /// Выбор/снятие флажка со всех строк при выборе флажка в заголовке колонки зон
        /// </summary>
        /// <param name="pState">True, если флажок в заголовке был выбран, False - если снят</param>
        public void zoneHeaderCell_OnCheckBoxClicked(bool pState)
        {
            foreach (DataGridViewRow row in dgvZones.Rows)
                if (Convert.ToBoolean((row.Cells[0] as DataGridViewCheckBoxCell).Value) != pState)
                {
                    (row.Cells[0] as DataGridViewCheckBoxCell).Value = pState;
                    ZoneWasChecked(row, pState);
                }
            dgvZones.RefreshEdit();
        }

        /// <summary>
        /// Выбор/снятие флажка со всех строк при выборе флажка в заголовке колонки стеллажей
        /// </summary>
        /// <param name="pState">True, если флажок в заголовке был выбран, False - если снят</param>
        public void stageHeaderCell_OnCheckBoxClicked(bool pState)
        {
            foreach (DataGridViewRow row in dgvStages.Rows)
                if (Convert.ToBoolean((row.Cells[0] as DataGridViewCheckBoxCell).Value) != pState)
                {
                    (row.Cells[0] as DataGridViewCheckBoxCell).Value = pState;
                    StageWasCanged(row, pState);
                }
            dgvStages.RefreshEdit();
        }

        /// <summary>
        /// Выбор/снятие флажка со всех строк при выборе флажка в заголовке колонки мест
        /// </summary>
        /// <param name="pState">True, если флажок в заголовке был выбран, False - если снят</param>
        public void locationHeaderCell_OnCheckBoxClicked(bool pState)
        {
            foreach (DataGridViewRow row in dgvPlaces.Rows)
                if (Convert.ToBoolean((row.Cells[0] as DataGridViewCheckBoxCell).Value) != pState)
                    (row.Cells[0] as DataGridViewCheckBoxCell).Value = pState;
                    
            dgvPlaces.RefreshEdit();
        }

        /// <summary>
        /// Создание номера инвентаризации или закрытие окна, если создать номер инвентаризации не получилось
        /// </summary>
        private void CreateInventoryNumber()
        {
            try
            {
                inventoryNumber = Convert.ToInt64(invAdapter.AddNewInventory(sessionID));
                Text = String.Format("Инвентаризация № {0}", inventoryNumber);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Не удалось создать инвентаризацию: " + Environment.NewLine + exc.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        public InventoryFilialEditForm(long pUserID, WMSOffice.Data.Inventory.FI_Get_Inventory_ListsRow pInventoryForEdit)
            : this(pUserID)
        {
            inventory = pInventoryForEdit;
            inventoryNumber = pInventoryForEdit.Inventory_number;
            isEditMode = true;
            Text = String.Format("Инвентаризация № {0}", pInventoryForEdit.Inventory_number);
            tbxDescription.Text = inventory.Description;
            dtpDate.Value = inventory.InventoryDate;
        }

        /// <summary>
        /// Инициализационные действия при загрузке окна
        /// </summary>
        private void InventoryFilialEditForm_Load(object sender, EventArgs e)
        {
            if (!isEditMode)
                CreateInventoryNumber();
            InitFilials();
            LoadWarehouses();
            InitInventoryTypes();
            if (isEditMode)
                LoadAllLocations();
        }

        /// <summary>
        /// Заполняет выпадающий список филиалов и если надо, выбирает текущий филиал
        /// </summary>
        private void InitFilials()
        {
            try
            {
                taFilials.Fill(inventory1.Filials, sessionID);
                switch (cbFilials.Items.Count)
                {
                    case 0:
                        MessageBox.Show("У пользователя нет прав ни на один филиал! Дальнейшее редактирование инвентаризации невозможно!",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Close();
                        break;
                    case 1:
                        cbFilials.Enabled = false;
                        cbFilials.SelectedIndex = 0;
                        tbxDescription.Focus();
                        break;
                    default:
                        cbFilials.Focus();
                        break;
                }

                if (isEditMode)
                    SelectFilial();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Не удалось заполнить список филиалов! Дальнейшее редактирование инвентаризации невозможно!" +
                    Environment.NewLine + exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        /// <summary>
        /// Выбор филиала, для которого на текущий момент задана инвентаризация
        /// </summary>
        private void SelectFilial()
        {
            foreach (var item in cbFilials.Items)
                if (((item as DataRowView).Row as WMSOffice.Data.Inventory.FilialsRow).Filial_ID == inventory.Filial_ID)
                {
                    cbFilials.SelectedItem = item;
                    return;
                }

            MessageBox.Show("Пользоатель не имеет прав на филиал, для которого задана инвентаризация! Дальнейшее редактирование инвентаризации невозможно!", 
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();
        }

        /// <summary>
        /// Выбор типа инвентаризации, для которого на текущий момент задана инвентаризация
        /// </summary>
        private void SelectInventoryType()
        {
            foreach (var item in cbInventoryTypes.Items)
                if (((item as DataRowView).Row as WMSOffice.Data.Inventory.FI_TypesRow).entity_key.Trim() == inventory.FI_Type_ID.Trim())
                {
                    cbInventoryTypes.SelectedItem = item;
                    return;
                }

            MessageBox.Show("Пользоатель не имеет прав на тип инвентаризации, для которого задана инвентаризация! Дальнейшее редактирование инвентаризации невозможно!",
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();
        }

        /// <summary>
        /// Загрузка складов, доступных пользователю
        /// </summary>
        private void LoadWarehouses()
        {
            try
            {
                taFiWarehouses.Fill(inventory1.FI_Warehouses, sessionID, inventoryNumber);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Ошибка при загрузке допустимых складов: " + Environment.NewLine + exc.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        /// <summary>
        /// Заполняет выпадающий список типов инвентаризации и если надо, выбирает текущий тип
        /// </summary>
        private void InitInventoryTypes()
        {
            try
            {
                tafITypes.Fill(inventory1.FI_Types, sessionID);

                if (isEditMode)
                    SelectInventoryType();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Ошибка при загрузке допустимых типов инвентаризации: " + Environment.NewLine + exc.Message,
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void cbInventoryTypes_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                var inventoryType = cbInventoryTypes.SelectedValue;
                if ("RT".Equals(inventoryType))
                {
                    tbcTabs.Enabled = false;
                    //tbcTabs.Visible = false;
                }
                else
                {
                    tbcTabs.Enabled = true;
                    //tbcTabs.Visible = true;
                }
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Если инвентаризация еще не была сохранена в БД, то надо удалить ту заглушку, которая создалась при открытии окна
        /// </summary>
        private void InventoryFilialEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isEditMode)
                DeleteEmptyInventory();
        }

        /// <summary>
        /// Удаление из БД пустой инвентаризации
        /// </summary>
        private void DeleteEmptyInventory()
        {
            try
            {
                invAdapter.DeleteEmptyInventory(sessionID, inventoryNumber);
            }
            catch { } // Нам не очень мешает пустая заглушка в таблице, поэтому 
                      // если случилась ошибка, то пользователю о ней знать не обязательно
        }

        /// <summary>
        /// Загрузка зон, стелажей и мест, если идет редактирование уже существующей инвентаризации
        /// </summary>
        private void LoadAllLocations()
        {
            try
            {
                bsFiZones.DataSource = null;
                bsFiStillages.DataSource = null;
                bsFiLocations.DataSource = null;
                taFiZones.Fill(inventory1.FI_Zones, sessionID, CheckedWarehouses, inventoryNumber, false);
                taFiStillages.Fill(inventory1.FI_Stillages, sessionID, CheckedWarehouses, CheckedZones, inventoryNumber, false);
                taFiLocations.Fill(inventory1.FI_Locations, sessionID, CheckedWarehouses, CheckedZones,
                    CheckedStillages, inventoryNumber, false);
                bsFiZones.DataSource = inventory1.FI_Zones;
                bsFiStillages.DataSource = inventory1.FI_Stillages;
                bsFiLocations.DataSource = inventory1.FI_Locations;
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Ошибка при загрузке зон, стелажей и мест по редактируемой инвентаризации", exc);
            }
        }

        #endregion

        #region ТАБЛИЦА СКЛАДОВ

        /// <summary>
        /// Разрисовка складов в разные цвета
        /// </summary>
        private void dgvWarehouses_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 || dgvWarehouses.Rows.Count == 0 || dgvWarehouses.Columns.Count == 0)
                return;

            string whId = dgvWarehouses.Rows[e.RowIndex].Cells[1].Value.ToString();
            SolidBrush br = whId.ToUpper().Contains("LA") ? new SolidBrush(Color.MediumSpringGreen) : new SolidBrush(Color.Pink);
            e.Graphics.FillRectangle(br, e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height);
            e.Graphics.DrawRectangle(Pens.Black, e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height);
            e.PaintContent(e.ClipBounds);
            e.Handled = true;
        }

        /// <summary>
        /// Загрузка/удаление зон/стеллажей/мест при редактировании таблицы складов
        /// </summary>
        private void dgvWarehouses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvWarehouses.CommitEdit(DataGridViewDataErrorContexts.Commit);

            if (e.ColumnIndex == 0)
                WarehouseWasChecked(dgvWarehouses.Rows[e.RowIndex], (bool)dgvWarehouses.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue);
        }

        /// <summary>
        /// Изменение "отмеченности" строки-склада
        /// </summary>
        /// <param name="pRow">Строка-склад</param>
        /// <param name="pIsChecked"></param>
        private void WarehouseWasChecked(DataGridViewRow pRow, bool pIsChecked)
        {
            if (pIsChecked)
            {
                AddZones(pRow.Cells[1].Value.ToString());
                AddStages(pRow.Cells[1].Value.ToString(), null);
                AddLocations(pRow.Cells[1].Value.ToString(), null, null);
            }
            else
            {
                DeleteLocations(pRow.Cells[1].Value.ToString(), null, null);
                DeleteStages(pRow.Cells[1].Value.ToString(), null);
                DeleteZones(pRow.Cells[1].Value.ToString());
            }
        }

        #endregion

        #region ТАБЛИЦА ЗОН

        /// <summary>
        /// Раскраска зон по привязке к складам
        /// </summary>
        private void dgvZones_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 || dgvZones.Rows.Count == 0 || dgvZones.Columns.Count == 0)
                return;

            string whId = dgvZones.Rows[e.RowIndex].Cells[3].Value.ToString();
            SolidBrush br = whId.ToUpper().Contains("LA") ? new SolidBrush(Color.MediumSpringGreen) : new SolidBrush(Color.Pink);
            e.Graphics.FillRectangle(br, e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height);
            e.Graphics.DrawRectangle(Pens.Black, e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height);
            e.PaintContent(e.ClipBounds);
            e.Handled = true;
        }

        /// <summary>
        /// Загрузка зон для заданного склада
        /// </summary>
        /// <param name="pWarehouseId">Идентификатор склада</param>
        private void AddZones(string pWarehouseId)
        {
            try
            {
                bsFiZones.DataSource = null;

                var table = taFiZones.GetData(sessionID, pWarehouseId, inventoryNumber, true);
                foreach (WMSOffice.Data.Inventory.FI_ZonesRow row in table.Rows)
                    inventory1.FI_Zones.ImportRow(row);

                bsFiZones.DataSource = inventory1;
                bsFiZones.DataMember = "FI_Zones";
            }
            catch (Exception exc)
            {
                MessageBox.Show("Ошибка при загрузке зон для склада, не рекомендуется дальнейшее редактирование инвентаризации!" +
                    Environment.NewLine + exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Удаление зон заданного склада
        /// </summary>
        /// <param name="pWarehouseId">Идентификатор склада</param>
        private void DeleteZones(string pWarehouseId)
        {
            try
            {
                bsFiZones.DataSource = null;

                for (int i = 0; i < inventory1.FI_Zones.Count; i++)
                    if ((inventory1.FI_Zones.Rows[i] as WMSOffice.Data.Inventory.FI_ZonesRow).Warehouse_ID == pWarehouseId)
                    {
                        inventory1.FI_Zones.RemoveFI_ZonesRow(inventory1.FI_Zones.Rows[i] as WMSOffice.Data.Inventory.FI_ZonesRow);
                        i--;
                    }

                bsFiZones.DataSource = inventory1;
                bsFiZones.DataMember = "FI_Zones";
            }
            catch (Exception exc)
            {
                MessageBox.Show("Ошибка при удалении зон, не рекомендуется дальнейшее редактирование инвентаризации!" +
                    Environment.NewLine + exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Загруза стелажей/мест при редактировании зоны
        /// </summary>
        private void dgvZones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvZones.CommitEdit(DataGridViewDataErrorContexts.Commit);

            if (e.ColumnIndex == 0)
                ZoneWasChecked(dgvZones.Rows[e.RowIndex], (bool)dgvZones.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue);
        }

        /// <summary>
        /// Отмечание строки-зоны
        /// </summary>
        /// <param name="pRow">Строка-зона</param>
        /// <param name="pState">Отметка, которую поставили на зоне</param>
        private void ZoneWasChecked(DataGridViewRow pRow, bool pState)
        {
            if (pState)
            {
                AddStages(pRow.Cells[3].Value.ToString(), pRow.Cells[1].Value.ToString());
                AddLocations(pRow.Cells[3].Value.ToString(), pRow.Cells[1].Value.ToString(), null);
            }
            else
            {
                DeleteLocations(pRow.Cells[3].Value.ToString(), pRow.Cells[1].Value.ToString(), null);
                DeleteStages(pRow.Cells[3].Value.ToString(), pRow.Cells[1].Value.ToString());
            }
        }

        #endregion

        #region ТАБЛИЦА СТЕЛАЖЕЙ

        /// <summary>
        /// Раскраска стелажей по привязке к складам
        /// </summary>
        private void dgvStages_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 || dgvStages.Rows.Count == 0 || dgvStages.Columns.Count == 0)
                return;

            string whId = dgvStages.Rows[e.RowIndex].Cells[3].Value.ToString();
            SolidBrush br = whId.ToUpper().Contains("LA") ? new SolidBrush(Color.MediumSpringGreen) : new SolidBrush(Color.Pink);
            e.Graphics.FillRectangle(br, e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height);
            e.Graphics.DrawRectangle(Pens.Black, e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height);
            e.PaintContent(e.ClipBounds);
            e.Handled = true;
        }

        /// <summary>
        /// Загрузка стелажей для заданных разделов
        /// </summary>
        /// <param name="pWarehouseID">Идентификатор склада</param>
        /// <param name="pZoneId">Идентификатор зоны</param>
        private void AddStages(string pWarehouseID, string pZoneId)
        {
            try
            {
                bsFiStillages.DataSource = null;

                var table = taFiStillages.GetData(sessionID, pWarehouseID, pZoneId, inventoryNumber, true);
                foreach (WMSOffice.Data.Inventory.FI_StillagesRow row in table.Rows)
                    inventory1.FI_Stillages.ImportRow(row);

                bsFiStillages.DataSource = inventory1;
                bsFiStillages.DataMember = "FI_Stillages";
            }
            catch (Exception exc)
            {
                MessageBox.Show("Ошибка при загрузке стеллажей для зоны, не рекомендуется дальнейшее редактирование инвентаризации!" +
                    Environment.NewLine + exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Удаление стелажей по заданному складу либо зоне
        /// </summary>
        /// <param name="pWarehouseId">Идентификатор склада</param>
        /// <param name="pZoneId">Идентификатор зоны</param>
        private void DeleteStages(string pWarehouseId, string pZoneId)
        {
            try
            {
                bsFiStillages.DataSource = null;

                for (int i = 0; i < inventory1.FI_Stillages.Count; i++)
                    if ((inventory1.FI_Stillages.Rows[i] as WMSOffice.Data.Inventory.FI_StillagesRow).Warehouse_ID == pWarehouseId &&
                        (pZoneId == null || (inventory1.FI_Stillages.Rows[i] as WMSOffice.Data.Inventory.FI_StillagesRow).Zone_ID == pZoneId))
                    {
                        inventory1.FI_Stillages.RemoveFI_StillagesRow(inventory1.FI_Stillages.Rows[i] as WMSOffice.Data.Inventory.FI_StillagesRow);
                        i--;
                    }

                bsFiStillages.DataSource = inventory1;
                bsFiStillages.DataMember = "FI_Stillages";
            }
            catch (Exception exc)
            {
                MessageBox.Show("Ошибка при удалении стелажей, не рекомендуется дальнейшее редактирование инвентаризации!" +
                    Environment.NewLine + exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Перезагрузка мест при редактировании стелажей
        /// </summary>
        private void dgvStages_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvStages.CommitEdit(DataGridViewDataErrorContexts.Commit);

            if (e.ColumnIndex == 0)
            {
                if ((bool)dgvStages.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue == true)
                    AddLocations(
                        dgvStages.Rows[e.RowIndex].Cells[3].Value.ToString(),
                        dgvStages.Rows[e.RowIndex].Cells[2].Value.ToString(),
                        dgvStages.Rows[e.RowIndex].Cells[1].Value.ToString());
                else
                    DeleteLocations(
                        dgvStages.Rows[e.RowIndex].Cells[3].Value.ToString(),
                        dgvStages.Rows[e.RowIndex].Cells[2].Value.ToString(),
                        dgvStages.Rows[e.RowIndex].Cells[1].Value.ToString());
            }
        }

        /// <summary>
        /// Была отмечена строка-стеллаж
        /// </summary>
        /// <param name="pRow">Строка-стеллаж</param>
        /// <param name="pIsChecked">Отметка, которая стоит на строке</param>
        private void StageWasCanged(DataGridViewRow pRow, bool pIsChecked)
        {
            if (pIsChecked)
                AddLocations(pRow.Cells[3].Value.ToString(), pRow.Cells[2].Value.ToString(),
                    pRow.Cells[1].Value.ToString());
            else
                DeleteLocations(pRow.Cells[3].Value.ToString(), pRow.Cells[2].Value.ToString(),
                    pRow.Cells[1].Value.ToString());
        }

        #endregion

        #region ТАБЛИЦА МЕСТ

        /// <summary>
        /// Раскраска мест в зависимости от склада
        /// </summary>
        private void dgvPlaces_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 || dgvPlaces.Rows.Count == 0 || dgvPlaces.Columns.Count == 0)
                return;

            string whId = dgvPlaces.Rows[e.RowIndex].Cells[4].Value.ToString();
            SolidBrush br = whId.ToUpper().Contains("LA") ? new SolidBrush(Color.MediumSpringGreen) : new SolidBrush(Color.Pink);
            e.Graphics.FillRectangle(br, e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height);
            e.Graphics.DrawRectangle(Pens.Black, e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height);
            e.PaintContent(e.ClipBounds);
            e.Handled = true;
        }

        /// <summary>
        /// Загрузка мест для заданных подразделений
        /// </summary>
        /// <param name="pWarehouseID">Идентификатор склада</param>
        /// <param name="pZoneId">Идентификатор зоны</param>
        /// <param name="pStageId">Идентификатор стелажа</param>
        private void AddLocations(string pWarehouseID, string pZoneId, string pStageId)
        {
            try
            {
                bsFiLocations.DataSource = null;

                taFiLocations.SetTimeout(600);
                var table = taFiLocations.GetData(sessionID, pWarehouseID, pZoneId, pStageId, inventoryNumber, true);
                foreach (WMSOffice.Data.Inventory.FI_LocationsRow row in table.Rows)
                    inventory1.FI_Locations.ImportRow(row);

                bsFiLocations.DataSource = inventory1;
                bsFiLocations.DataMember = "FI_Locations";
            }
            catch (Exception exc)
            {
                MessageBox.Show("Ошибка при загрузке мест, не рекомендуется дальнейшее редактирование инвентаризации!" +
                    Environment.NewLine + exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Удаление мест по заданному складу, стелажу либо зоне
        /// </summary>
        /// <param name="pWarehouseId">Идентификатор склада</param>
        /// <param name="pZoneId">Идентификатор зоны</param>
        /// <param name="pStageId">Идентификатор стелажа</param>
        private void DeleteLocations(string pWarehouseId, string pZoneId, string pStageId)
        {
            try
            {
                bsFiLocations.DataSource = null;

                for (int i = 0, j = 0; i < inventory1.FI_Locations.Count; j++, i++)
                    if ((inventory1.FI_Locations.Rows[i] as WMSOffice.Data.Inventory.FI_LocationsRow).Warehouse_ID == pWarehouseId &&
                        (pZoneId == null || (inventory1.FI_Locations.Rows[i] as WMSOffice.Data.Inventory.FI_LocationsRow).Zone_ID == pZoneId) &&
                        (pStageId == null || (inventory1.FI_Locations.Rows[i] as WMSOffice.Data.Inventory.FI_LocationsRow).Stillage_ID == pStageId))
                    {
                        inventory1.FI_Locations.RemoveFI_LocationsRow(inventory1.FI_Locations.Rows[i] as WMSOffice.Data.Inventory.FI_LocationsRow);
                        i--;
                    }
                
                bsFiLocations.DataSource = inventory1;
                bsFiLocations.DataMember = "FI_Locations";
            }
            catch (Exception exc)
            {
                MessageBox.Show("Ошибка при удалении стелажей, не рекомендуется дальнейшее редактирование инвентаризации!" +
                    Environment.NewLine + exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region СОХРАНЕНИЕ РЕЗУЛЬТАТОВ РЕДАКТИРОВАНИЯ

        /// <summary>
        /// Сохранение отредактированной инвентаризации
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            // Завершающая подготовка кеша товаров
            PrepareItemsCache();

            // Завершающая раскраска отобранных товаров
            PaintInventoryItems();

            try
            {
                using (var scope = new TransactionScope(TransactionScopeOption.RequiresNew, TimeSpan.MaxValue))
                {
                    invAdapter.SetTimeout(18000);
                    SaveInventarizationBody();
                    if (wasItemsTabSelected)
                        SaveInventoryItems();
                    SaveInventoryLocations();
                    scope.Complete();
                }
                Close();
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка при сохранении инвентаризации!", exc);
            }
        }

        /// <summary>
        /// Сохранение в БД основных данных об инвентаризации - филиал, дата, описание
        /// </summary>
        private void SaveInventarizationBody()
        {
            invAdapter.EditInventory(sessionID, 
                inventoryNumber,
                ((cbFilials.SelectedItem as DataRowView).Row as WMSOffice.Data.Inventory.FilialsRow).Filial_ID,
                dtpDate.Value, 
                tbxDescription.Text,
                ((cbInventoryTypes.SelectedItem as DataRowView).Row as WMSOffice.Data.Inventory.FI_TypesRow).entity_key,
                executionMode);

            isEditMode = true;
            WasChangesMade = true;
        }

        /// <summary>
        /// Сохранение товаров, участвующих в инвентаризации
        /// </summary>
        private void SaveInventoryItems()
        {
            invAdapter.AddItemsToInventory(sessionID, inventoryNumber, ItemsDelimetedList);
        }

        /// <summary>
        /// Сохранение мест проведения инвентаризации
        /// </summary>
        private void SaveInventoryLocations()
        {
            invAdapter.ClearInventoryParameters(sessionID, inventoryNumber);
            foreach (Data.Inventory.FI_WarehousesRow row in inventory1.FI_Warehouses)
                if (row.Checked)
                {
                    if (IsAllWarehouseChecked(row.Warehouse_ID))
                        invAdapter.AddInventoryParameterLocations(sessionID, inventoryNumber, row.Warehouse_ID,
                            null, null, null);
                    else
                        foreach (Data.Inventory.FI_LocationsRow locRow in inventory1.FI_Locations)
                            if (locRow.Warehouse_ID == row.Warehouse_ID && locRow.Checked)
                                invAdapter.AddInventoryParameterLocations(sessionID, inventoryNumber, row.Warehouse_ID,
                                    locRow.Zone_ID, locRow.Stillage_ID, locRow.Location_ID);
                }
        }

        /// <summary>
        /// Проверка, участвует ли склад в инвентаризации целиком
        /// </summary>
        /// <param name="pWarehouseID">Идентификатор склада, который проверяем</param>
        /// <returns>True, если склад целиком участвует в инвентаризации, False если не целиком 
        /// (отмеченные отдельные места)</returns>
        private bool IsAllWarehouseChecked(string pWarehouseID)
        {
            foreach (Data.Inventory.FI_ZonesRow zoneRow in inventory1.FI_Zones)
                if (zoneRow.Warehouse_ID == pWarehouseID && !zoneRow.Checked)
                    return false;
            foreach (Data.Inventory.FI_StillagesRow stillageRow in inventory1.FI_Stillages)
                if (stillageRow.Warehouse_ID == pWarehouseID && !stillageRow.Checked)
                    return false;
            foreach (Data.Inventory.FI_LocationsRow locationRow in inventory1.FI_Locations)
                if (locationRow.Warehouse_ID == pWarehouseID && !locationRow.Checked)
                    return false;

            return true;
        }

        #endregion

        #region ФИЛЬТРАЦИЯ ПО ЗОНЕ, СТЕЛАЖУ И МЕСТУ

        /// <summary>
        /// Строка фильтра по зонам (эта переменная сделана для того, чтобы не обращаться из левых потоков к TextBox)
        /// </summary>
        private string zonesFilter;

        /// <summary>
        /// Строка фильтра по стелажам (эта переменная сделана для того, чтобы не обращаться из левых потоков к TextBox)
        /// </summary>
        private string stagesFilter;

        /// <summary>
        /// Строка фильтра по местам (эта переменная сделана для того, чтобы не обращаться из левых потоков к TextBox)
        /// </summary>
        private string locationsFilter;

        /// <summary>
        /// Делегат для асинхронного вызова фильтрации
        /// </summary>
        private delegate void Method();

        /// <summary>
        /// Таймер, который отвечает за то, чтобы фильтрация проихсодила не сразу после изменения
        /// фильтра, а спустя некоторое время
        /// </summary>
        private System.Timers.Timer filterTimer = new System.Timers.Timer(1000);

        /// <summary>
        /// Начало фильтрации по нажатию на кнопку Enter
        /// </summary>
        private void tbxFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                filterTimer.Stop();
                RefreshFiltersForZones();
                RefreshFiltersForStages();
                RefreshFiltersForLocations();
            }
        }

        /// <summary>
        /// Обновление на таблице с зонами
        /// </summary>
        private void RefreshFiltersForZones()
        {
            try
            {
                if (String.IsNullOrEmpty(zonesFilter))
                    bsFiZones.Filter = String.Empty;
                else
                    bsFiZones.Filter =
                        String.Format("[Zone_ID] LIKE '%{0}%'", zonesFilter);
            }
            catch { }   // Нам тут не важно, какая ошибка - главное чтобы не слетала программа
        }

        /// <summary>
        /// Обновление на таблице со стелажами
        /// </summary>
        private void RefreshFiltersForStages()
        {
            try
            {
                if (String.IsNullOrEmpty(zonesFilter) && String.IsNullOrEmpty(stagesFilter))
                    bsFiStillages.Filter = String.Empty;
                else
                    bsFiStillages.Filter =
                        String.Format("[Zone_ID] LIKE '%{0}%' AND [Stillage_ID] LIKE '%{1}%'", zonesFilter, stagesFilter);
            }
            catch { }   // Нам тут не важно, какая ошибка - главное чтобы не слетала программа
        }

        /// <summary>
        /// Обновление на таблице с местами
        /// </summary>
        private void RefreshFiltersForLocations()
        {
            try
            {
                if (String.IsNullOrEmpty(zonesFilter) && String.IsNullOrEmpty(stagesFilter) && String.IsNullOrEmpty(locationsFilter))
                    bsFiLocations.Filter = String.Empty;
                else
                    bsFiLocations.Filter =
                        String.Format("[Zone_ID] LIKE '%{0}%' AND [Stillage_ID] LIKE '%{1}%' AND [Location_ID] LIKE '%{2}%'", 
                        zonesFilter, stagesFilter, locationsFilter);
            }
            catch { }   // Нам тут не важно, какая ошибка - главное чтобы не слетала программа
        }

        /// <summary>
        /// Если прошло достаточно времени с момента последнего редактирования фильтра, запускается фильтрация
        /// </summary>
        private void filterTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            filterTimer.Stop();
            dgvZones.Invoke(new Method(RefreshFiltersForZones));
            dgvZones.Invoke(new Method(RefreshFiltersForStages));
            dgvZones.Invoke(new Method(RefreshFiltersForLocations));
        }

        /// <summary>
        /// При изменении фильтра запускаем таймер ожидания, чтобы по прошествию некоторого времени обновить фильтры
        /// </summary>
        private void tbxFilter_TextChanged(object sender, EventArgs e)
        {
            zonesFilter = tbxZonesFilter.Text;
            stagesFilter = tbxStagesFilter.Text;
            locationsFilter = tbxLocationsFilter.Text;

            filterTimer.Stop();
            filterTimer.Start();
        }

        /// <summary>
        /// Переход на фильтры с помощью сочетания клавиш
        /// </summary>
        private void InventoryFilialEditForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(tbcTabs.SelectedTab == tbpPlaces))
                return;

            if (e.Alt && e.KeyCode == Keys.Z)
                tbxZonesFilter.Focus();
            else if (e.Alt && e.KeyCode == Keys.S)
                tbxStagesFilter.Focus();
            else if (e.Alt && e.KeyCode == Keys.L)
                tbxLocationsFilter.Focus();
        }

        #endregion

        #region ОТОБРАЖЕНИЕ ТАБЛИЦЫ ТОВАРОВ С ФИЛЬТРАМИ

        /// <summary>
        /// Признак, который показывает, была ли открыта 
        /// </summary>
        private bool wasItemsTabSelected;

        /// <summary>
        /// Окно ожидания, которое отображается при загрузке товаров
        /// </summary>
        private SplashForm splashForm = new SplashForm();

        /// <summary>
        /// Список через запятую идентификаторов отмеченных категорий товаров
        /// </summary>
        private string SalesCategories
        {
            get
            {
                string s = String.Empty;
                foreach (var item in ccbCategories.CheckedItems)
                {
                    if (s.Length > 0)
                        s += ",";
                    s += (item as CCBoxItem).Value.ToString();
                }

                return String.IsNullOrEmpty(s) ? null : s;
            }
        }

        /// <summary>
        /// Список через запятую идентификаторов отмеченных форм хранения
        /// </summary>
        private string StorageForms
        {
            get
            {
                string s = String.Empty;
                foreach (var item in ccbStorageForms.CheckedItems)
                {
                    if (s.Length > 0)
                        s += ",";
                    string val = (item as CCBoxItem).Value.ToString();
                    if (val.Length == 1)
                        val = "0" + val;
                    s += val;
                }

                return String.IsNullOrEmpty(s) ? null : s;
            }
        }

        /// <summary>
        /// Фильтр по ПКУ: True если надо выбирать только ПКУ-товары, False если надо выбирать только не ПКУ-товары, 
        /// null если надо выбирать все товары
        /// </summary>
        private bool? IsPku
        {
            get
            {
                if (rbtPKU.Checked)
                    return true;
                else if (rbtNotPku.Checked)
                    return false;
                else
                    return null;
            }
        }

        /// <summary>
        /// Нижняя граница фильтра цен либо null, если она не задана
        /// </summary>
        private decimal? BasePriceFrom
        {
            get
            {
                decimal? val;
                GetDecimalFromString(tbxBasePriceFrom.Text, out val);
                return val;
            }
        }

        /// <summary>
        /// Верхняя граница фильтра цен либо null, если она не задана
        /// </summary>
        private decimal? BasePriceTo
        {
            get
            {
                decimal? val;
                GetDecimalFromString(tbxBasePriceTo.Text, out val);
                return val;
            }
        }

        /// <summary>
        /// Код товара
        /// </summary>
        private int? ItemID
        {
            get
            {
                int? val;
                GetIntFromString(tbxItemID.Text, out val);
                return val;
            }
        }

        /// <summary>
        /// Попытка получения числа типа decimal из строки
        /// </summary>
        /// <param name="pStr">Строка, из которой нужно получить число</param>
        /// <param name="pVal">OUT-параметр - полученное число</param>
        /// <returns>True, если парсинг прошел успешно, False если переданная строка не является корректной</returns>
        private static bool GetDecimalFromString(string pStr, out decimal? pVal)
        {
            decimal dec;
            if (String.IsNullOrEmpty(pStr))
            {
                pVal = null;
                return true;
            }

            if (Decimal.TryParse(pStr, out dec))
            {
                pVal = dec;
                return true;
            }
            else if (Decimal.TryParse(pStr.Replace('.', ','), out dec))
            {
                pVal = dec;
                return true;
            }
            else if (Decimal.TryParse(pStr.Replace(',', '.'), out dec))
            {
                pVal = dec;
                return true;
            }
            else
            {
                pVal = null;
                return false;
            }
        }

        /// <summary>
        /// Попытка получения числа типа int из строки
        /// </summary>
        /// <param name="pStr">Строка, из которой нужно получить число</param>
        /// <param name="pVal">OUT-параметр - полученное число</param>
        /// <returns>True, если парсинг прошел успешно, False если переданная строка не является корректной</returns>
        private static bool GetIntFromString(string pStr, out int? pVal)
        {
            int parsed;
            if (String.IsNullOrEmpty(pStr))
            {
                pVal = null;
                return true;
            }

            if (Int32.TryParse(pStr, out parsed))
            {
                pVal = parsed;
                return true;
            }
            else
            {
                pVal = null;
                return false;
            }
        }

        /// <summary>
        /// DelimetedList с идентификаторами товаров, отмеченных в таблице товаров
        /// </summary>
        private string ItemsDelimetedList
        {
            get
            {
                var sbItems = new StringBuilder();

                foreach (var item in lstCachedInventoryItems)
                {
                    if (sbItems.Length > 0)
                        sbItems.AppendFormat(",{0}", item);
                    else
                        sbItems.AppendFormat("{0}", item);
                }

                return sbItems.ToString();
            }
        }

        /// <summary>
        /// Настройка фильтров при первом открытии вкладки
        /// </summary>
        private void tbcTabs_Selected(object sender, TabControlEventArgs e)
        {
            if (!wasItemsTabSelected)
            {
                CustomCheckHeaderForItemsGrid();
                LoadSalesCategories();
                LoadStorageForms();
                wasItemsTabSelected = true;
            }
        }

        /// <summary>
        /// Настройка заголовка для CheckBox-колонки тоже в виде CheckBox-а для таблицы товаров
        /// </summary>
        private void CustomCheckHeaderForItemsGrid()
        {
            var checkHeaderCell = new DataGridViewHeaderCheckBoxCell();
            checkHeaderCell.OnCheckBoxClicked += checkHeaderCell_OnCheckBoxClicked;
            checkHeaderCell.Value = String.Empty;
            dgvItems.Columns[0].HeaderCell = checkHeaderCell;
        }

        /// <summary>
        /// Выбор/снятие флажка со всех строк при выборе флажка в заголовке CheckBox-колонки таблицы товаров
        /// </summary>
        /// <param name="pState">True, если флажок в заголовке был выбран, False - если снят</param>
        public void checkHeaderCell_OnCheckBoxClicked(bool pState)
        {
            foreach (DataGridViewRow detailsRow in dgvItems.Rows)
                (detailsRow.Cells[0] as DataGridViewCheckBoxCell).Value = pState;

            dgvItems.RefreshEdit();
        }

        /// <summary>
        /// Инициализация выпадающего списка с категориями
        /// </summary>
        private void LoadSalesCategories()
        {
            try
            {
                using (var adapter = new FI_Sales_CategorysTableAdapter())
                {
                    var table = adapter.GetData(null, null);
                    foreach (WMSOffice.Data.Inventory.FI_Sales_CategorysRow row in table)
                        ccbCategories.Items.Add(new CCBoxItem(row.Sales_Category, Convert.ToInt32(row.Sales_Category_ID)));
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Не удалось загрузить список категорий товаров!" + Environment.NewLine + exc.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                ccbCategories.Items.Clear();
            }
        }

        /// <summary>
        /// Инициализация выпадающего списка с формами хранения
        /// </summary>
        private void LoadStorageForms()
        {
            try
            {
                using (var adapter = new FI_Storage_FormsTableAdapter())
                {
                    var table = adapter.GetData(null, null);
                    foreach (WMSOffice.Data.Inventory.FI_Storage_FormsRow row in table)
                        ccbStorageForms.Items.Add(new CCBoxItem(row.Storage_Form, Convert.ToInt32(row.Storage_Form_ID)));
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Не удалось загрузить список форм хранения!" + Environment.NewLine + exc.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                ccbStorageForms.Items.Clear();
            }
        }

        /// <summary>
        /// Обновление списка товаров по фильтрах
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Подготовка кеша товаров
            PrepareItemsCache();

            if (showCachedItems && lstCachedInventoryItems.Count == 0)
            {
                inventory1.FI_Items.Clear();
                return;
            }

            if (!showCachedItems && !ValidateItemFilters())
                return;

            var worker = new BackgroundWorker();
            worker.DoWork += loadDocsWorker_DoWork;
            worker.RunWorkerCompleted += loadDocsWorker_RunWorkerCompleted;
            bsFiItems.DataSource = null;
            splashForm.ActionText = "Загрузка товаров по фильтрам...";
            dgvItems.Enabled = false;
            btnRefresh.Enabled = false;

            worker.RunWorkerAsync(new ItemsSearchParameters()
                {
                    UserID = sessionID,
                    InventoryID = inventoryNumber,
                    SalesCategories = showCachedItems ? (string)null : SalesCategories,
                    StorageForms = showCachedItems ? (string)null : StorageForms,
                    IsPku = showCachedItems ? (bool?)null : IsPku,
                    PriceFrom = showCachedItems ? (decimal?)null : BasePriceFrom,
                    PriceTo = showCachedItems ? (decimal?)null : BasePriceTo,
                    ItemID = showCachedItems ? (int?)null : ItemID,
                    CachedItems = showCachedItems ? ItemsDelimetedList : (string)null
                });
            splashForm.ShowDialog();

            foreach (Data.Inventory.FI_ItemsRow item in inventory1.FI_Items)
                if (item.Checked)
                {
                    btnShowCachedItems.Enabled = true;
                    btnExportCachedItems.Enabled = true;
                    break;
                }

        }

        #region КЕШИРОВАНИЕ ТОВАРОВ ОТОБРАННЫХ ДЛЯ ИНВЕНТАРИЗАЦИИ

        /// <summary>
        /// Кеш товаров отобранных для инвентаризации
        /// </summary>
        private readonly List<int> lstCachedInventoryItems = new List<int>();

        /// <summary>
        /// Признак отображения кешированных товаров
        /// </summary>
        private bool showCachedItems = false;

        /// <summary>
        /// Отобразить товары из кеша
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowCachedItems_Click(object sender, EventArgs e)
        {
            showCachedItems = true;

            btnRefresh_Click(btnRefresh, EventArgs.Empty);

            showCachedItems = false;
        }

        /// <summary>
        /// Экспорт в Excel кешированных товаров
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportCachedItems_Click(object sender, EventArgs e)
        {
            try
            {
                // Получение кешируемых товаров
                btnShowCachedItems_Click(btnShowCachedItems, EventArgs.Empty);

                if (lstCachedInventoryItems.Count == 0)
                    return;

                var arTitles = new List<string>();
                var arColumnNames = new List<string>();

                foreach (DataGridViewColumn dgvc in dgvItems.Columns)
                {
                    if (dgvc.Index > 0)
                    {
                        arTitles.Add(dgvc.HeaderText);
                        arColumnNames.Add(dgvc.DataPropertyName);
                    }
                }

                var dtItems = inventory1.FI_Items.DefaultView.ToTable();
                dtItems.DefaultView.RowFilter = string.Format("{0} = 1", inventory1.FI_Items.CheckedColumn.Caption);

                ExportHelper.ExportDataTableToExcel(dtItems.DefaultView.ToTable(), arTitles.ToArray(), arColumnNames.ToArray(), "Экспорт выбранных товаров", string.Format("Выбранные товары для инвентаризации №{0}", inventoryNumber), true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка во время экспорта выбранных товаров.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Подготовка кеша товаров отобранных для инвентаризации
        /// </summary>
        private void PrepareItemsCache()
        {
            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                var itemID = Convert.ToInt32(((row.DataBoundItem as DataRowView).Row as WMSOffice.Data.Inventory.FI_ItemsRow).Item_ID);
                var isChecked = Convert.ToBoolean(row.Cells[0].Value);

                if (isChecked)
                {
                    if (!lstCachedInventoryItems.Contains(itemID))
                        lstCachedInventoryItems.Add(itemID);
                }
                else
                {
                    if (lstCachedInventoryItems.Contains(itemID))
                        lstCachedInventoryItems.Remove(itemID);
                }
            }

            bool isCacheEnabled = lstCachedInventoryItems.Count > 0;
            btnShowCachedItems.Enabled = isCacheEnabled;
            btnExportCachedItems.Enabled = isCacheEnabled;
        }

        /// <summary>
        /// Раскраска товаров отобранных для инвентаризации
        /// </summary>
        private void PaintInventoryItems()
        {
            foreach (DataGridViewRow row in dgvItems.Rows)
                PaintInventoryItem(row);
        }

        /// <summary>
        /// Раскраска товара отобранного для инвентаризации
        /// </summary>
        private void PaintInventoryItem(DataGridViewRow row)
        {
            var itemID = Convert.ToInt32(((row.DataBoundItem as DataRowView).Row as WMSOffice.Data.Inventory.FI_ItemsRow).Item_ID);
            if (lstCachedInventoryItems.Contains(itemID))
            {
                foreach (DataGridViewCell dgvc in row.Cells)
                {
                    var color = Color.Khaki;

                    dgvc.Style.BackColor = color;
                    dgvc.Style.SelectionForeColor = color;
                }
            }
        }

        private void dgvItems_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            PaintInventoryItems();
        }

        #endregion

        /// <summary>
        /// Загружает в фоне товары с учетом фильтров
        /// </summary>
        private void loadDocsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var sc = e.Argument as ItemsSearchParameters;
                using (var adapter = new FI_ItemsTableAdapter())
                {
                    adapter.SetTimeout(600);
                    adapter.Fill(inventory1.FI_Items, 
                        sc.UserID, 
                        sc.InventoryID, 
                        sc.SalesCategories, 
                        sc.StorageForms, 
                        sc.IsPku,
                        sc.PriceFrom, 
                        sc.PriceTo,
                        sc.ItemID,
                        sc.CachedItems);
                }
            }
            catch (Exception exc)
            {
                e.Result = exc;
            }
        }

        /// <summary>
        /// Загрузка данных завершена - обновляем таблицу на интерфейсе
        /// </summary>
        private void loadDocsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
            {
                MessageBox.Show("Возникла ошибка при загрузке товаров! Дальнейшее редактирование инвентаризации невозможно! "
                    + Environment.NewLine + (e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                inventory1.FI_Items.Clear();
                Close();
            }

            btnRefresh.Enabled = true;
            bsFiItems.DataSource = inventory1.FI_Items;
            splashForm.CloseForce();
            dgvItems.Enabled = true;
        }

        /// <summary>
        /// Проверка заданных фильтров на корректность
        /// </summary>
        /// <returns>True, если все данные заданы правильно, False если есть ошибки</returns>
        private bool ValidateItemFilters()
        {
            decimal? dec;
            if (!GetDecimalFromString(tbxBasePriceFrom.Text, out dec))
            {
                MessageBox.Show("Неверно задана базовая цена с! Она должна быть числом", "Неверно заданные данные!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (!GetDecimalFromString(tbxBasePriceTo.Text, out dec))
            {
                MessageBox.Show("Неверно задана базовая цена по! Она должна быть числом", "Неверно заданные данные!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            int? parsed;
            if (!GetIntFromString(tbxItemID.Text, out parsed))
            {
                MessageBox.Show("Неверно задан код товара! Он должен быть числом", "Неверно заданные данные!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        #endregion

        #region КЛАС КРИТЕРИЕВ ФИЛЬТРА ПО ТОВАРАХ

        /// <summary>
        /// Критерий поиска
        /// </summary>
        public class ItemsSearchParameters : SearchParametersBase
        {
            /// <summary>
            /// Идентификатор сессии пользователя
            /// </summary>
            public long UserID { get; set; }

            /// <summary>
            /// Номер инвентаризации
            /// </summary>
            public long InventoryID { get; set; }
            
            /// <summary>
            /// DelimetedList со списком категорий
            /// </summary>
            public string SalesCategories { get; set; }
            
            /// <summary>
            /// DelimetedList с формами хранения
            /// </summary>
            public string StorageForms { get; set; }

            /// <summary>
            /// Фильтр по признаку ПКУ: True - только ПКУ, False - только не ПКУ, null - все
            /// </summary>
            public bool? IsPku { get; set; }
            
            /// <summary>
            /// Нижняя граница цены для фильтра либо null, если она не задана
            /// </summary>
            public decimal? PriceFrom { get; set; }

            /// <summary>
            /// Верхняя граница цены для фильтра либо null, если она не задана
            /// </summary>
            public decimal? PriceTo { get; set; }

            /// <summary>
            /// Фильтр по коду товара
            /// </summary>
            public int? ItemID { get; set; }

            /// <summary>
            /// Кешируемый список товаров
            /// </summary>
            public string CachedItems { get; set; }
        }

        #endregion
    }
}
