using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Transactions;

namespace WMSOffice.Dialogs.ColdChain
{
    public partial class EquipmentSensorsBindingEditor : DialogForm
    {
        /// <summary>
        /// Состояние привязки оборудования
        /// </summary>
        private enum EquipmentBindingInitialState
        {
            /// <summary>
            /// Привязка отсутсвует
            /// </summary>
            Absent,

            /// <summary>
            /// Привязка присутствует
            /// </summary>
            Present
        }

        private EquipmentBindingInitialState equipmentBindingInitialState = EquipmentBindingInitialState.Absent;

        private static readonly int EMPTY_BINDING_ELEMENT_NUMBER = -1;
        public ColdChainEquipmentSensorsBindingManager Manager { get; private set; }

        private SensorBindingItemsSelector itemsSelectorForm;

        public EquipmentSensorsBindingEditor(ColdChainEquipmentSensorsBindingManager manager, DataRow drEquipment)
        {
            InitializeComponent();
            this.DialogResult = DialogResult.None;

            this.Manager = manager;
            this.relatedEquipmentBindingSource.CurrentItemChanged += new EventHandler(relatedEquipmentBindingSource_CurrentItemChanged);

            // Изначально по умолчанию мы не знаем идентификаторов сущностей 
            this.Manager.CurrentData.EquipmentID = EMPTY_BINDING_ELEMENT_NUMBER;
            this.Manager.CurrentData.SensorID = EMPTY_BINDING_ELEMENT_NUMBER;

            if (drEquipment != null)
            {
                this.coldChain.RelatedEquipment.LoadDataRow(drEquipment.ItemArray, true);
                this.coldChain.RelatedEquipment.AcceptChanges();

                this.equipmentBindingInitialState = EquipmentBindingInitialState.Present;
            }
        }

        private void relatedEquipmentBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            bool allowBinding = this.AreEquipmentExists();
            this.Manager.CurrentData.EquipmentID = allowBinding ? (((DataRowView)(relatedEquipmentBindingSource.CurrencyManager.Current)).Row as Data.ColdChain.RelatedEquipmentRow).Equipment_ID : EMPTY_BINDING_ELEMENT_NUMBER;

            this.SetEquipmentVisibleRowsFilter();        
        }

        #region Методы фильтрации элементов привязки
        private void SetEquipmentVisibleRowsFilter()
        {
            this.relatedEquipmentBindingSource.Filter = string.Format("{0} = {1}", this.coldChain.RelatedEquipment.IsDeletedColumn.Caption, false);
        }

        private void SetSensorsVisibleRowsFilter()
        {
            this.relatedSensorsBindingSource.Filter = string.Format("{0} = {1}", this.coldChain.RelatedSensors.IsDeletedColumn.Caption, false);
        }

        private void SetPlatformFilterBySensor()
        {
            this.relatedPlatformsBindingSource.Filter = string.Format("{0} = {1} AND {2} = {3}", this.coldChain.RelatedPlatforms.Sensor_IDColumn.Caption, this.Manager.CurrentData.SensorID, this.coldChain.RelatedPlatforms.IsDeletedColumn, false);
        }
        #endregion

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.relatedSensorsBindingSource.CurrentItemChanged += new EventHandler(relatedSensorsBindingSource_CurrentItemChanged);
            this.RefreshData();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Text = this.equipmentBindingInitialState == EquipmentBindingInitialState.Absent ? "Редактор новых закреплений" : "Редактор текущих закреплений";
        }

        private void relatedSensorsBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            bool allowBinding = this.AreSensorsExists();
            this.Manager.CurrentData.SensorID = allowBinding ? (((DataRowView)(relatedSensorsBindingSource.CurrencyManager.Current)).Row as Data.ColdChain.RelatedSensorsRow).Sensor_ID : EMPTY_BINDING_ELEMENT_NUMBER;

            this.SetSensorsVisibleRowsFilter();
            this.SetPlatformFilterBySensor();
        }

        #region Проверочное методы существования обьектов привязки по фильтрам 
        private bool AreEquipmentExists()
        {
            return this.relatedEquipmentBindingSource.CurrencyManager.Count > 0;
        }

        private bool AreSensorsExists()
        {
            return this.relatedSensorsBindingSource.CurrencyManager.Count > 0;
        }

        private bool ArePlatformsExists()
        {
            return this.relatedPlatformsBindingSource.CurrencyManager.Count > 0;
        }
        #endregion

        private void RefreshData()
        {
            this.RefreshSensors();
            this.RefreshPlatforms();
        }

        private void RefreshSensors()
        {
            try
            {             
                this.relatedSensorsTableAdapter.Fill(this.coldChain.RelatedSensors, this.Manager.CurrentData.EquipmentID);
                this.relatedSensorsBindingSource.DataSource = this.coldChain.RelatedSensors;
                this.coldChain.RelatedSensors.AcceptChanges();
            }
            catch (System.Data.SqlClient.SqlException er)
            {
                MessageBox.Show(er.Message, "Ошибка момента обновления списка датчиков температур", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void RefreshPlatforms()
        {
            try
            {
                this.relatedPlatformsTableAdapter.FillByRelatedEquipment(this.coldChain.RelatedPlatforms, this.Manager.CurrentData.EquipmentID);
                this.relatedPlatformsBindingSource.DataSource = this.coldChain.RelatedPlatforms;
                this.coldChain.RelatedPlatforms.AcceptChanges();
            }
            catch (System.Data.SqlClient.SqlException er)
            {
                MessageBox.Show(er.Message, "Ошибка момента обновления списка перронов", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.ApplyOperation(DialogResult.OK);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ApplyOperation(DialogResult.Cancel);
        }

        /// <summary>
        /// Выполнить запрашиваемую операцию согласно ожидаемого результата - статуса диалогового окна
        /// </summary>
        /// <param name="agreedResult"></param>
        private void ApplyOperation(DialogResult agreedResult)
        {
            this.DialogResult = agreedResult;
            this.Close();
        }

        private void EquipmentSensorsBindingEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.ValidateOperation();
        }

        private bool ValidateOperation()
        {
            try
            {
                if (this.equipmentBindingInitialState == EquipmentBindingInitialState.Absent && !AreEquipmentExists())
                    throw new Exception("Нельзя создать закрепления без выбора оборудования!");

                if (this.equipmentBindingInitialState == EquipmentBindingInitialState.Absent && !AreSensorsExists())
                    throw new Exception("Нельзя создать закрепления без выбора датчиков!");

                // Определим уровень изоляции для транзакции
                TransactionOptions tranOptions = new TransactionOptions();
                tranOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;

                // Открываем транзакцию
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, tranOptions))
                {
                    this.ChangeRelations();
                    scope.Complete();
                }

                return true;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Ошибка сохранения закреплений", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Вызов процедур сохранения изменения закреплений
        /// </summary>
        private void ChangeRelations()
        {
            Data.ColdChain.RelatedEquipmentRow equipment = ((relatedEquipmentBindingSource.CurrencyManager.Current as DataRowView).Row as Data.ColdChain.RelatedEquipmentRow);

            int equipmentID = equipment.Equipment_ID;
            bool removeEquipment = equipment.IsDeleted;

            // организовываем обработку каждого датчика
            foreach (Data.ColdChain.RelatedSensorsRow sensor in this.coldChain.RelatedSensors.Rows)
            {
                int sensorID = sensor.Sensor_ID;
                bool removeSensor = sensor.IsDeleted;
                
                using (Data.ColdChainTableAdapters.QueriesTableAdapter adapter = new WMSOffice.Data.ColdChainTableAdapters.QueriesTableAdapter())
                    adapter.ChangeRelations(equipmentID, sensorID, this.GetPlatformsList(sensorID), (removeEquipment ? false : !removeSensor), this.Manager.UserID);
            }
        }

        /// <summary>
        /// Возврат списка перронов для датчика
        /// </summary>
        /// <param name="sensorID"></param>
        /// <returns></returns>
        private string GetPlatformsList(int sensorID)
        {
            StringBuilder platformsList = new StringBuilder();
            foreach (Data.ColdChain.RelatedPlatformsRow platform in this.coldChain.RelatedPlatforms.Select(string.Format("{0} = {1} AND {2} = {3}", this.coldChain.RelatedPlatforms.Sensor_IDColumn.Caption, sensorID, this.coldChain.RelatedPlatforms.IsDeletedColumn.Caption, false)))
            {
                platformsList.Append(platform.Peron_ID);
                platformsList.AppendFormat(";");
            }

            return platformsList.Length > 0 ? platformsList.ToString().Trim(';') : null;
        }

        #region Добавление элементов привязки и реакция-последействие
        private void btnAddEquipment_Click(object sender, EventArgs e)
        {
            try
            {
                bool equipmentExists = AreEquipmentExists();
                
                if (equipmentExists)
                    throw new Exception("Нельзя добавить еще одно оборудование!");

                if (!equipmentExists && equipmentBindingInitialState == EquipmentBindingInitialState.Present)
                    throw new Exception("Нельзя добавить оборудование после удаления существующего!\nДля начала сохраните результат!");

                this.ShowItemsSelector(BindingItemsType.Equipment);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Ошибка при добавлении оборудования", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddSensor_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AreEquipmentExists())
                    throw new Exception("Отсутсвует оборудование!");

                this.ShowItemsSelector(BindingItemsType.Sensors);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Ошибка при добавлении датчика", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddPlatform_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AreSensorsExists())
                    throw new Exception("Отсутсвует датчик!");

                this.ShowItemsSelector(BindingItemsType.Platforms);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Ошибка при добавлении перрона", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Отображение справочника элементов привязки
        /// </summary>
        /// <param name="itemsCategory"></param>
        private void ShowItemsSelector(BindingItemsType itemsType)
        {
            if (this.itemsSelectorForm != null) // Если справочник уже отображен, то повторно не отображаем его!
                return;

            this.itemsSelectorForm = new SensorBindingItemsSelector(itemsType);
            this.itemsSelectorForm.Shown += new EventHandler(itemsSelectorForm_Shown);
            this.itemsSelectorForm.FormClosed += new FormClosedEventHandler(ItemsSelectorForm_FormClosed);
            this.itemsSelectorForm.OnAddingBindingItem += new SensorBindingItemsSelector.AddBindingItemEventHandler(itemsSelectorForm_OnAddingBindingItem);
            itemsSelectorForm.Show(this);
        }

        private void itemsSelectorForm_Shown(object sender, EventArgs e)
        {
            this.ChangeGroupBindOptionsAbility(false);
        }

        private void itemsSelectorForm_OnAddingBindingItem(object sender, SensorBindingItemsSelector.AddBindingItemEventArgs e)
        {
            try
            {
                switch (e.BindingItemType)
                {
                    case BindingItemsType.Equipment:
                        this.AddEquipmentAfterCheck(e.ItemRow as Data.ColdChain.AvailableEquipmentRow);
                        break;
                    case BindingItemsType.Sensors:
                        this.AddSensorAfterCheck(e.ItemRow as Data.ColdChain.AvailableSensorsRow);
                        break;
                    case BindingItemsType.Platforms:
                        this.AddPlatformAfterCheck(e.ItemRow as Data.ColdChain.AvailablePlatformsRow);
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            catch (Exception err){ }
        }

        private void AddEquipmentAfterCheck(Data.ColdChain.AvailableEquipmentRow equipment)
        {
            if (FindEquipmentAndSetVisibility(equipment.Equipment_ID, true) == null)
            {
                var eq = coldChain.RelatedEquipment.NewRelatedEquipmentRow();
                
                eq.Equipment_ID = equipment.Equipment_ID;
                eq.Equipment_Name = equipment.IsEquipment_NameNull() ? string.Empty : equipment.Equipment_Name;
                eq.Equipment_Type_Name = equipment.IsEquipment_Type_NameNull() ? string.Empty : equipment.Equipment_Type_Name;
                eq.Department = equipment.IsDepartmentNull() ? string.Empty : equipment.Department;
                eq.Transportation_Type_Name = equipment.IsTransportation_Type_NameNull() ? string.Empty : equipment.Transportation_Type_Name;

                coldChain.RelatedEquipment.AddRelatedEquipmentRow(eq);
            }
        }

        private void AddSensorAfterCheck(Data.ColdChain.AvailableSensorsRow sensor)
        {
            if (FindSensorAndSetVisibility(sensor.Sensor_ID, true) == null)
            {
                coldChain.RelatedSensors.LoadDataRow(sensor.ItemArray, false);
            }
        }

        private void AddPlatformAfterCheck(Data.ColdChain.AvailablePlatformsRow platform)
        {
            if (FindPlatformAndSetVisibility(platform.Peron_ID, true) == null)
            {
                (coldChain.RelatedPlatforms.LoadDataRow(platform.ItemArray, false) as Data.ColdChain.RelatedPlatformsRow).Sensor_ID = this.Manager.CurrentData.SensorID;
            }
        }

        private void ItemsSelectorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.ChangeGroupBindOptionsAbility(true);
            this.itemsSelectorForm = null;
        }
        #endregion

        /// <summary>
        /// Меняет доступность опциональных кнопок
        /// </summary>
        /// <param name="isEnabled"></param>
        private void ChangeGroupBindOptionsAbility(bool isEnabled)
        {
            switch (itemsSelectorForm.BindingItemsType)
            {
                case BindingItemsType.Equipment:
                    btnAddEquipment.Enabled =
                    btnAddSensor.Enabled = btnAddPlatform.Enabled =
                    btnRemoveSensor.Enabled = btnRemovePlatform.Enabled = isEnabled;
                    break;
                case BindingItemsType.Sensors:
                    btnAddSensor.Enabled =
                    btnAddEquipment.Enabled = btnAddPlatform.Enabled =
                    btnRemoveEquipment.Enabled = btnRemovePlatform.Enabled = isEnabled;
                    break;
                case BindingItemsType.Platforms:
                    btnAddPlatform.Enabled =
                    btnAddEquipment.Enabled = btnAddSensor.Enabled =
                    btnRemoveEquipment.Enabled = btnRemoveSensor.Enabled = isEnabled;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        #region Удаление элементов привязки и реакция-последействие
        private void btnRemoveEquipment_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AreEquipmentExists())
                    throw new Exception("Отсутсвует оборудование!");

                if (AreSensorsExists())
                    throw new Exception("Нельзя удалить оборудование при наличии датчиков!");

                this.FindEquipmentAndSetVisibility(((relatedEquipmentBindingSource.CurrencyManager.Current as DataRowView).Row as Data.ColdChain.RelatedEquipmentRow).Equipment_ID, false);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Ошибка при удалении оборудования", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveSensor_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AreSensorsExists())
                    throw new Exception("Отсутсвует датчик!");

                if (ArePlatformsExists())
                    throw new Exception("Нельзя удалить датчик при наличии перронов!");

                this.FindSensorAndSetVisibility(((relatedSensorsBindingSource.CurrencyManager.Current as DataRowView).Row as Data.ColdChain.RelatedSensorsRow).Sensor_ID, false);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Ошибка при удалении датчика", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemovePlatform_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ArePlatformsExists())
                    throw new Exception("Отсутсвует перрон!");

                this.FindPlatformAndSetVisibility(((relatedPlatformsBindingSource.CurrencyManager.Current as DataRowView).Row as Data.ColdChain.RelatedPlatformsRow).Peron_ID, false);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Ошибка при удалении перрона", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Поиск и изменение статуса видимости текущих данных
        private DataRow FindEquipmentAndSetVisibility(int equipmentID, bool isVisible)
        {
            foreach (DataRow equipment in this.coldChain.RelatedEquipment.Select(string.Format("{0} = {1}", this.coldChain.RelatedEquipment.Equipment_IDColumn.Caption, equipmentID)))
            {
                (equipment as Data.ColdChain.RelatedEquipmentRow).IsDeleted = !isVisible;
                return equipment;
            }

            return null;
        }

        private DataRow FindSensorAndSetVisibility(int sensorID, bool isVisible)
        {
            foreach (DataRow sensor in this.coldChain.RelatedSensors.Select(string.Format("{0} = {1}", this.coldChain.RelatedSensors.Sensor_IDColumn.Caption, sensorID)))
            {
                (sensor as Data.ColdChain.RelatedSensorsRow).IsDeleted = !isVisible;
                return sensor;
            }

            return null;
        }

        private DataRow FindPlatformAndSetVisibility(int platformID, bool isVisible)
        {
            foreach (DataRow platform in this.coldChain.RelatedPlatforms.Select(string.Format("{0} = {1}", this.coldChain.RelatedPlatforms.Peron_IDColumn.Caption, platformID)))
            {
                // если перрон был помечен как удаленный - то мы восстанавливаем его и меняем привязку к датчику
                if ((platform as Data.ColdChain.RelatedPlatformsRow).IsDeleted)
                {
                    (platform as Data.ColdChain.RelatedPlatformsRow).IsDeleted = !isVisible;
                    (platform as Data.ColdChain.RelatedPlatformsRow).Sensor_ID = this.Manager.CurrentData.SensorID;
                    return platform;
                }

                (platform as Data.ColdChain.RelatedPlatformsRow).IsDeleted = !isVisible;
                return platform;
            }

            return null;
        }
        #endregion
    }
}
