using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Windows.Forms;

using WMSOffice.Data;
using WMSOffice.Data.ColdChainTableAdapters;
using WMSOffice.Dialogs.ColdChain;
using WMSOffice.Dialogs.Complaints;
using WMSOffice.Classes;
using WMSOffice.Reports;
using WMSOffice.Controls.Custom;

namespace WMSOffice.Window
{
    public partial class СoldChainTemperatureSensorsWindow : GeneralWindow
    {
       /// <summary>
        /// Менеджер формы
        /// </summary>
        private ColdChainTemperatureSensorsManager manager = null;

        /// <summary>
        /// Список строк (датчиков), выбранных в таблице либо пустой список, если ни один датчик не выбран
        /// </summary>
        private List<ColdChain.TemperatureSensorsRow> SelectedSensors
        {
            get
            {
                var list = new List<ColdChain.TemperatureSensorsRow>();
                foreach (DataGridViewRow dgvRow in dgvSensors.SelectedRows)
                    list.Add((dgvRow.DataBoundItem as DataRowView).Row as ColdChain.TemperatureSensorsRow);
                return list;
            }
        }

        public СoldChainTemperatureSensorsWindow(ColdChainTemperatureSensorsManager manager)
        {
            InitializeComponent();
            this.manager = manager;
        }

        private void СoldChainTemperatureSensorsWindow_Load(object sender, EventArgs e)
        {
            this.SetPermissions();

            manager.EditingCellObserver.OnApplyChanges += new EditingGridCellObserver.CellChangedEventHandler(EditingCellObserver_OnApplyChanges);
            temperatureSensorsBindingSource.CurrentItemChanged += new EventHandler(temperatureSensorsBindingSource_CurrentItemChanged);

            this.FillSensorsAbilityStateSource();
            InitPrinters();
        }

        /// <summary>
        /// Установка функциональных ограничений по правам пользователя
        /// </summary>
        private void SetPermissions()
        {
            manager.SetPermissions();

            this.sbAddSensor.Enabled = manager.AddSensorPermission;

            this.Branch.ReadOnly = !manager.ChangeBranchPermission;
            this.Ability.ReadOnly = !manager.ChangeAbilityPermission;
        }

        private void FillSensorsAbilityStateSource()
        {
            AddSensorsAbilityState("Датчик не работает");
            AddSensorsAbilityState("Датчик работает");
        }

        private void AddSensorsAbilityState(string abilityStateName)
        {
            var abilityState = this.coldChain.TemperatureSensorsAbilityState.NewTemperatureSensorsAbilityStateRow();
            abilityState.Name = abilityStateName;
            this.coldChain.TemperatureSensorsAbilityState.AddTemperatureSensorsAbilityStateRow(abilityState);
        }

        /// <summary>
        /// Настройка доступности кнопок при изменении выбранного датчика температуры
        /// </summary>
        private void dgvSensors_SelectionChanged(object sender, EventArgs e)
        {
            CustomButtons();
        }

        /// <summary>
        /// Настройка доступности кнопок в зависимости от выбранного (выбранных) датчиков в таблице
        /// </summary>
        private void CustomButtons()
        {
            btnPrintSticker.Visible = miPrintSticker.Enabled = SelectedSensors.Count > 0 && cmbPrinters.SelectedItem != null;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.RefreshData();
        }

        private void temperatureSensorsBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            if (AreSensorsExists())
                manager.CurrentSensorID = (((DataRowView)(temperatureSensorsBindingSource.CurrencyManager.Current)).Row as Data.ColdChain.TemperatureSensorsRow).Sensor_ID;
        }

        /// <summary>
        /// Метод возвращает признак наличия списка датчиков температуры
        /// </summary>
        /// <returns></returns>
        private bool AreSensorsExists()
        {
            return temperatureSensorsBindingSource.CurrencyManager.Count > 0;
        }

        private void sbRefreshSensors_Click(object sender, EventArgs e)
        {
            this.RefreshData();
        }

        private void RefreshData()
        {
            this.RefreshBranches();
            this.RefreshForwarders();
            this.RefreshSensorModes();
            this.RefreshSensors();
        }
        /// <summary>
        /// Обновление справочника филиалов
        /// </summary>
        private void RefreshBranches()
        {
            try
            {
                this.branchesTableAdapter.Fill(this.coldChain.Branches);
            }
            catch (System.Data.SqlClient.SqlException er)
            {
                MessageBox.Show(er.Message, "Ошибка момента обновления списка филиалов", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обновление справочника экспедиторов
        /// </summary>
        private void RefreshForwarders()
        {
            try
            {
                this.sensorForwardersTableAdapter.Fill(this.coldChain.SensorForwarders, manager.UserID);
            }
            catch (System.Data.SqlClient.SqlException er)
            {
                MessageBox.Show(er.Message, "Ошибка момента обновления списка экспедиторов", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обновление справочника режимов датчиков
        /// </summary>
        private void RefreshSensorModes()
        {
            try
            {
                this.sensorModesTableAdapter.Fill(this.coldChain.SensorModes);
            }
            catch (System.Data.SqlClient.SqlException er)
            {
                MessageBox.Show(er.Message, "Ошибка момента обновления списка режимов датчиков", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Фоновая загрузка справочника датчиков температуры
        private void RefreshSensors()
        {
            BackgroundWorker loadWorker = new BackgroundWorker();
            loadWorker.DoWork += new DoWorkEventHandler(loadWorker_DoWork);
            loadWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(loadWorker_RunWorkerCompleted);
            this.temperatureSensorsBindingSource.DataSource = null;
            this.manager.WaitProcessForm.ActionText = "Загрузка справочника датчиков температуры...";
            loadWorker.RunWorkerAsync();
            this.manager.WaitProcessForm.ShowDialog();
        }

        private void loadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = this.temperatureSensorsTableAdapter.GetData(manager.UserID, (int?)null);
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
                ShowError(e.Result as Exception);
                this.coldChain.TemperatureSensors.Clear();
            }
            else
                this.temperatureSensorsBindingSource.DataSource = e.Result;

            this.manager.WaitProcessForm.CloseForce();
        }
        #endregion

        private void sbAddSensor_Click(object sender, EventArgs e)
        {
            WMSOffice.Dialogs.ColdChain.TemperatureSensorRegistrationForm newSensor = new TemperatureSensorRegistrationForm() { UserID = manager.UserID };
            if (newSensor.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(this, "Новый датчик температуры был успешно добавлен.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshSensors(); // обновим список датчиков температуры
                SelectCurrentlyAddedDataRecord(temperatureSensorsBindingSource);
            }
        }

        /// <summary>
        /// Переход к строке содержащей только что добавленную запись
        /// </summary>
        /// <param name="dataSource">Источник данных</param>
        private void SelectCurrentlyAddedDataRecord(BindingSource dataSource)
        {
            // Только что добавленная запись имеет максимальный ключ, поэтому она будет последней в списке
            SelectDataSourceRowByPosition(dataSource, Int32.MaxValue);
        }

        /// <summary>
        /// Переход к строке источника данных по индексу
        /// </summary>
        /// <param name="dataSource">Источник данных</param>
        /// <param name="position">Индекс строки</param>
        private void SelectDataSourceRowByPosition(BindingSource dataSource, int position)
        {
            // Устанавливаем фокус источника на определенную позицию
            dataSource.Position = position;
        }

        private void dgvSensors_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewComboBoxEditingControl) // Добавим обработчик момента завершения редактирования элементов выпадающего списка
                (e.Control as DataGridViewComboBoxEditingControl).SelectionChangeCommitted += new EventHandler(cellEditor_SelectionChangeCommitted);
        
            if (e.Control is DataGridViewDatePickerEditingControl) // Добавим обработчик момента завершения редактирования элементов календаря
                (e.Control as DataGridViewDatePickerEditingControl).ValueChanged += new EventHandler(cellEditor_ValueChanged);
        }

        private void cellEditor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            manager.EditingCellObserver.NewValue = (sender as ComboBox).SelectedValue;
        }

        private void cellEditor_ValueChanged(object sender, EventArgs e)
        {
            manager.EditingCellObserver.NewValue = (sender as DataGridViewDatePickerEditingControl).Value;
        }

        private void dgvSensors_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            manager.EditingCellObserver.SourceFieldName = (sender as DataGridView).Columns[(sender as DataGridView).CurrentCell.ColumnIndex].DataPropertyName;
            manager.EditingCellObserver.OldValue = (sender as DataGridView).CurrentCell.Value;
        }

        private void dgvSensors_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if ((sender as DataGridView).IsCurrentCellInEditMode && (sender as DataGridView).IsCurrentCellDirty)
                manager.EditingCellObserver.CheckChanges(sender as DataGridView);
        }    

        private void EditingCellObserver_OnApplyChanges(object sender, EditingGridCellObserver.CellChangedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Вы желаете внести изменения?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    ApplyGridCellChanges(e.Owner);
                else
                    e.Owner.CancelEdit();
            }
            catch (Exception err)
            {
                if (err.GetType() == typeof(NotImplementedException))
                    MessageBox.Show(err.ToString(), err.Message);

                e.Owner.CancelEdit();
            }
        }

        /// <summary>
        /// Анализ обновляемых данных и выполнение обновлений
        /// </summary>
        /// <param name="ownerGrid"></param>
        private void ApplyGridCellChanges(DataGridView ownerGrid)
        {
            if (ownerGrid == dgvSensors)
            {
                if (manager.EditingCellObserver.SourceFieldName == this.coldChain.TemperatureSensors.IsWorkColumn.Caption)
                    ChangeSensorAbility();
                else if (manager.EditingCellObserver.SourceFieldName == this.coldChain.TemperatureSensors.BranchColumn.Caption)
                    ChangeSensorBranch();
                else if (manager.EditingCellObserver.SourceFieldName == this.coldChain.TemperatureSensors.Forwarder_IDColumn.Caption)
                    ChangeSensorForwarder();
                else if (manager.EditingCellObserver.SourceFieldName == this.coldChain.TemperatureSensors.Sensor_Mode_IDColumn.Caption)
                    ChangeSensorMode();
                else if (manager.EditingCellObserver.SourceFieldName == this.coldChain.TemperatureSensors.Verification_DateColumn.Caption)
                    ChangeSensorVerificationDate();
            }
            else
                throw new NotImplementedException();
        }

        /// <summary>
        /// Изменение исправности датчика температуры
        /// </summary>
        private void ChangeSensorAbility()
        {
            try
            {
                bool newSensorOperationActivity = Convert.ToBoolean(manager.EditingCellObserver.NewValue);
                this.temperatureSensorsTableAdapter.ChangeSensorOperationActivity(manager.CurrentSensorID, newSensorOperationActivity, manager.UserID);

                MessageBox.Show(this, "Тип исправности датчика температуры был успешно изменен.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                manager.EditingCellObserver.ExecuteActionAfterUpdate = RefreshSensors; // обновим список датчиков температуры
            }
            catch (System.Data.SqlClient.SqlException er)
            {
                MessageBox.Show(er.Message, "Ошибка момента изменения исправности датчика температуры", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception();
            }
        }

        /// <summary>
        /// Изменение привязки датчика температуры к филиалу
        /// </summary>
        private void ChangeSensorBranch()
        {
            try
            {
                string newSensorBranch = manager.EditingCellObserver.NewValue.ToString();
                this.temperatureSensorsTableAdapter.ChangeSensorBranch(manager.UserID, newSensorBranch, manager.CurrentSensorID);

                MessageBox.Show(this, "Привязка датчика температуры к филиалу была успешно изменена.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                manager.EditingCellObserver.ExecuteActionAfterUpdate = RefreshSensors; // обновим список датчиков температуры
            }
            catch (System.Data.SqlClient.SqlException er)
            {
                MessageBox.Show(er.Message, "Ошибка момента изменения привязки датчика температуры к филиалу", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception();
            }
        }

        /// <summary>
        /// Измененеие экспедитора закрепленного за датчиком температуры
        /// </summary>
        private void ChangeSensorForwarder()
        {
            try
            {
                int newSensorForwarder = Convert.ToInt32(manager.EditingCellObserver.NewValue);
                this.temperatureSensorsTableAdapter.ChangeSensorForwarder(manager.CurrentSensorID, newSensorForwarder, manager.UserID);

                MessageBox.Show(this, "Привязка экспедитора была успешно изменена.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                manager.EditingCellObserver.ExecuteActionAfterUpdate = RefreshSensors; // Обновим список датчиков температуры
            }
            catch (System.Data.SqlClient.SqlException er)
            {
                MessageBox.Show(er.Message, "Ошибка момента изменения привязки экспедитора", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception();
            }
        }

        /// <summary>
        /// Измененеие режима датчика температуры
        /// </summary>
        private void ChangeSensorMode()
        {
            try
            {
                byte newSensorMode = Convert.ToByte(manager.EditingCellObserver.NewValue);
                this.temperatureSensorsTableAdapter.ChangeSensorMode(manager.UserID, newSensorMode, manager.CurrentSensorID);

                MessageBox.Show(this, "Температурный режим датчика была успешно измененен.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                manager.EditingCellObserver.ExecuteActionAfterUpdate = RefreshSensors; // Обновим список датчиков температуры
            }
            catch (System.Data.SqlClient.SqlException er)
            {
                MessageBox.Show(er.Message, "Ошибка момента изменения температурного режима", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception();
            }
        }

        /// <summary>
        /// Измененеие даты поверки датчика температуры
        /// </summary>
        private void ChangeSensorVerificationDate()
        {
            try
            {
                DateTime newSensorVerificationDate = DateTime.Parse(manager.EditingCellObserver.NewValue.ToString()).Date;
                this.temperatureSensorsTableAdapter.ChangeSensorVerificationDate(manager.UserID, newSensorVerificationDate, manager.CurrentSensorID);

                MessageBox.Show(this, "Дата поверки была успешно изменена.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                manager.EditingCellObserver.ExecuteActionAfterUpdate = RefreshSensors; // Обновим список датчиков температуры
            }
            catch (System.Data.SqlClient.SqlException er)
            {
                MessageBox.Show(er.Message, "Ошибка момента изменения даты поверки", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception();
            }
        }

        private void dgvSensors_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if ((sender as DataGridView).IsCurrentCellInEditMode && manager.EditingCellObserver.ExecuteActionAfterUpdate != null)
            {
                manager.EditingCellObserver.ExecuteActionAfterUpdate();
                manager.EditingCellObserver.ExecuteActionAfterUpdate = null;
            }
        }

        private void dgvSensors_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        #region ПЕЧАТЬ СТИКЕРА НА ЛОГГЕР (ДАТЧИК)

        /// <summary>
        /// Инициализация списка доступных принтеров
        /// </summary>
        private void InitPrinters()
        {
            try
            {
                foreach (string printerName in PrinterSettings.InstalledPrinters)
                    cmbPrinters.Items.Add(printerName);

                if (cmbPrinters.Items.Count > 0)
                {
                    var tmpSettings = new PrinterSettings();
                    cmbPrinters.SelectedItem = tmpSettings.PrinterName;
                }
            }
            catch (Exception exc)
            {
                ShowError(exc);
            }
        }

        /// <summary>
        /// Запуск печати стикера на логгер по нажатию на кнопку
        /// </summary>
        private void PrintSticker_Click(object sender, EventArgs e)
        {
            PrintStickerForSelectedDocs();
        }

        /// <summary>
        /// Печать стикеров для выбранных в таблице датчиков
        /// </summary>
        private void PrintStickerForSelectedDocs()
        {
            var printWorker = new BackgroundWorker();
            printWorker.DoWork += printWorker_DoWork;
            printWorker.RunWorkerCompleted += printWorker_RunWorkerCompleted;
            var param = new PrintDocsParameters
            {   
                PrinterName = cmbPrinters.SelectedItem.ToString(),
                Docs = SelectedSensors.ToArray()
            };
            printWorker.RunWorkerAsync(param);
            MessageBox.Show(String.Format("Печать стикеров для выбранных сенсоров запущена ({0} шт.)", SelectedSensors.Count),
                "Печать стикеров", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Запуск фоновой печати стикеров для выбранных в таблице датчиков
        /// </summary>
        private void printWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var param = e.Argument as PrintDocsParameters;
                var ds = new ColdChain();
                foreach (var row in param.Docs)
                {
                    FillDataForSticker(ds, (row as ColdChain.TemperatureSensorsRow).Sensor_ID);
                    var report = new ColdEquipmentSensorStickerVertical();
                    report.SetDataSource(ds);
                    report.PrintOptions.PrinterName = param.PrinterName;
                    report.PrintToPrinter(1, true, 1, 0);
                }
            }
            catch (Exception exc)
            {
                e.Result = exc.Message;
            }
        }

        /// <summary>
        /// Получение данных, которые нужны для печати стикера
        /// </summary>
        /// <param name="pData">DataSet с таблицей, которую нужно заполнить</param>
        private void FillDataForSticker(ColdChain pData, int pSensorID)
        {
            try
            {
                using (var adapter = new CL_Get_Sensor_StickerTableAdapter())
                {
                    adapter.Fill(pData.CL_Get_Sensor_Sticker, manager.UserID, pSensorID);
                    if (pData.CL_Get_Sensor_Sticker.Count == 0)
                        throw new ApplicationException("Процедура получения заголовка для стикера не вернула данные!");
                    else
                        pData.CL_Get_Sensor_Sticker[0].BarCodeLabel = BarCodeGenerator.GetBarcodeCODE39(
                            pData.CL_Get_Sensor_Sticker[0].Bar_code);
                }
            }
            catch (Exception exc)
            {
                throw new ApplicationException("Не удалось получить данные для стикера: " + exc.Message);
            }
        }

        /// <summary>
        /// Завершение печати и отображение ошибки, если такая вдруг возникла при печати
        /// </summary>
        private void printWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                Logger.ShowErrorMessageBox("Возникла ошибка во время печати этикетки: ", e.Result as Exception);
        }

        #endregion

        /// <summary>
        /// Экспорт справочника датчиков температуры в CSV-файл
        /// </summary>
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                ExportHelper.ExportDataGridViewToExcel(dgvSensors, "Экспорт справочника",
                    "датчики температуры", true);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Во время экспорта справочника датчиков температуры произошла ошибка:", exc);
            }
        }
    }
}
