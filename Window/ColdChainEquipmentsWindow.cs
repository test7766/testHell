using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using WMSOffice.Classes;
using WMSOffice.Dialogs.ColdChain;

namespace WMSOffice.Window
{
    public partial class ColdChainEquipmentsWindow : GeneralWindow
    {
        /// <summary>
        /// Менеджер формы
        /// </summary>
        private ColdChainEquipmentManager manager = null;

        public ColdChainEquipmentsWindow(ColdChainEquipmentManager manager)
        {
            InitializeComponent();
            this.manager = manager;
        }
        
        private void ColdChainEquipmentsWindow_Load(object sender, EventArgs e)
        {
            this.SetPermissions();
            manager.EditingCellObserver.OnApplyChanges += new EditingGridCellObserver.CellChangedEventHandler(EditingCellObserver_OnApplyChanges);
            coldEquipmentBindingSource.CurrentItemChanged += new EventHandler(coldEquipmentBindingSource_CurrentItemChanged);

            this.PreparePrintersList();
            this.FillEquipmentAbilityStateSource();
        }

        /// <summary>
        /// Установка функциональных ограничений по правам пользователя
        /// </summary>
        private void SetPermissions()
        {
            manager.SetPermissions();

            this.sbAddEquipment.Enabled = manager.AddEquipmentPermission;

            this.btnFullEquipmentStates.Enabled = this.btnFullEquipmentStates.Visible = toolStripSeparator4.Visible = false;

            this.Branch.ReadOnly = !manager.ChangeBranchPermission;
            this.Department.ReadOnly = !manager.ChangeDepartmentNotationPermission;
            this.Ability.ReadOnly = !manager.ChangeAbilityPermission;
            this.TransportationType.ReadOnly = !manager.ChangeTransportationTypePermission;
            this.Forwarder_ID.ReadOnly = !manager.ChangeForwarderPermission;
        }

        /// <summary>
        /// Сформировать список принтеров, выбрать принтер по умолчанию
        /// </summary>
        private void PreparePrintersList()
        {
            try
            {
                foreach (string printerName in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                    cmbPrinters.Items.Add(printerName);

                System.Drawing.Printing.PrinterSettings tmpSettings = new System.Drawing.Printing.PrinterSettings();
                cmbPrinters.SelectedItem = tmpSettings.PrinterName;
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void FillEquipmentAbilityStateSource()
        {
            AddEquipmentAbilityState("Не используется");
            AddEquipmentAbilityState("Используется");
        }

        private void AddEquipmentAbilityState(string abilityStateName)
        {
            var abilityState = this.coldChain.ColdEquipmentAbilityState.NewColdEquipmentAbilityStateRow();
            abilityState.Name = abilityStateName;
            this.coldChain.ColdEquipmentAbilityState.AddColdEquipmentAbilityStateRow(abilityState);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.RefreshData();
        }

        private void coldEquipmentBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            if (AreEquipmentExists())
            {
                manager.CurrentEquipmentID = (((DataRowView)(coldEquipmentBindingSource.CurrencyManager.Current)).Row as Data.ColdChain.ColdEquipmentRow).Equipment_ID;

                bool allowEditDepartment = this.manager.GetEquipmentTypeUseDeparmentFlag((((DataRowView)(coldEquipmentBindingSource.CurrencyManager.Current)).Row as Data.ColdChain.ColdEquipmentRow).Equipment_Type_ID);
                this.Department.ReadOnly = !allowEditDepartment;
            }
        }

        /// <summary>
        /// Метод возвращает признак наличия списка оборудования
        /// </summary>
        /// <returns></returns>
        private bool AreEquipmentExists()
        {
            return coldEquipmentBindingSource.CurrencyManager.Count > 0;
        }

        private void sbAddEquipment_Click(object sender, EventArgs e)
        {
            WMSOffice.Dialogs.ColdChain.ColdEquipmentRegistrationForm newEquipment = new WMSOffice.Dialogs.ColdChain.ColdEquipmentRegistrationForm() { UserID = this.manager.UserID };
            if (newEquipment.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(this, "Новое холодильное оборудование было успешно добавлено.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshEquipment(); // обновим список холодильного оборудования
                SelectCurrentlyAddedDataRecord(coldEquipmentBindingSource);
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

        private void sbRefreshEquipment_Click(object sender, EventArgs e)
        {
            this.RefreshData();
        }

        private void RefreshData()
        {
            this.RefreshEquipmentTransportationsTypes();
            this.RefreshForwarders();
            this.RefreshBranches();
            this.RefreshEquipment();
        }

        /// <summary>
        /// Обновление типов транспортировки холодильного оборудования
        /// </summary>
        private void RefreshEquipmentTransportationsTypes()
        {
            try
            {
                this.coldChain.EquipmentTransportationsTypes.Clear();
                InsertEmptyTransportationType();
                this.equipmentTransportationsTypesTableAdapter.ClearBeforeFill = false;
                this.equipmentTransportationsTypesTableAdapter.Fill(this.coldChain.EquipmentTransportationsTypes);
            }
            catch (System.Data.SqlClient.SqlException er)
            {
                MessageBox.Show(er.Message, "Ошибка момента обновления списка типов транспортировки холодильного оборудования", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обновление справочника экспедиторов
        /// </summary>
        private void RefreshForwarders()
        {
            try
            {
                this.equipmentForwardersTableAdapter.Fill(this.coldChain.EquipmentForwarders, manager.UserID);
            }
            catch (System.Data.SqlClient.SqlException er)
            {
                MessageBox.Show(er.Message, "Ошибка момента обновления списка экспедиторов", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        /// Добавление типа транспортировки оборудования - "отсутсвует"
        /// </summary>
        private void InsertEmptyTransportationType()
        {
            var emptyTransportationType = this.coldChain.EquipmentTransportationsTypes.NewEquipmentTransportationsTypesRow();
            emptyTransportationType.Transportation_ID = string.Empty;
            emptyTransportationType.Transportation_Name = "Отсутствует";
            this.coldChain.EquipmentTransportationsTypes.AddEquipmentTransportationsTypesRow(emptyTransportationType);
        }

        #region Фоновая загрузка справочника холодильного оборудования
        private void RefreshEquipment()
        {
            BackgroundWorker loadWorker = new BackgroundWorker();
            loadWorker.DoWork += new DoWorkEventHandler(loadWorker_DoWork);
            loadWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(loadWorker_RunWorkerCompleted);

            this.coldEquipmentBindingSource.DataSource = null;
            this.manager.WaitProcessForm.ActionText = "Загрузка справочника холодильного оборудования...";
            loadWorker.RunWorkerAsync();
            this.manager.WaitProcessForm.ShowDialog();
        }   

        private void loadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = this.coldEquipmentTableAdapter.GetData(this.manager.UserID, (int?)null);
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
                this.coldChain.ColdEquipment.Clear();
            }
            else
                this.coldEquipmentBindingSource.DataSource = e.Result;

            this.manager.WaitProcessForm.CloseForce();
        }
        #endregion

        private void sbPrintEquipmentSticker_Click(object sender, EventArgs e)
        {
            if (cmbPrinters.Items.Count > 0)
                manager.PrintEquipmentSticker(cmbPrinters.SelectedItem.ToString());
            else
                MessageBox.Show("У Вас отсутсвуют подключенные принтера.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void dgvColdEquipment_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewComboBoxEditingControl) // Добавим обработчик момента завершения редактирования элементов выпадающего списка
                (e.Control as DataGridViewComboBoxEditingControl).SelectionChangeCommitted += new EventHandler(cellEditor_SelectionChangeCommitted);

            if (e.Control is DataGridViewTextBoxEditingControl) // Добавим обработчик момента завершения редактирования содержимого текстового редактора
                (e.Control as DataGridViewTextBoxEditingControl).TextChanged += new EventHandler(cellTextEditor_TextChanged);
        }

        private void cellTextEditor_TextChanged(object sender, EventArgs e)
        {
            manager.EditingCellObserver.NewValue = (sender as TextBox).Text;
        }

        private void cellEditor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            manager.EditingCellObserver.NewValue = (sender as ComboBox).SelectedValue;
        }

        private void dgvColdEquipment_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            manager.EditingCellObserver.SourceFieldName = (sender as DataGridView).Columns[(sender as DataGridView).CurrentCell.ColumnIndex].DataPropertyName;
            manager.EditingCellObserver.OldValue = (sender as DataGridView).CurrentCell.Value;
        }

        private void dgvColdEquipment_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
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
            if (ownerGrid == dgvColdEquipment)
            {
                if (manager.EditingCellObserver.SourceFieldName == this.coldChain.ColdEquipment.Transportation_IDColumn.Caption)
                    ChangeEquipmentTransportationType();
                else if (manager.EditingCellObserver.SourceFieldName == this.coldChain.ColdEquipment.IsWorkColumn.Caption)
                    ChangeEquipmentAbility();
                else if (manager.EditingCellObserver.SourceFieldName == this.coldChain.ColdEquipment.BranchColumn.Caption)
                    ChangeEquipmentBranch();
                else if (manager.EditingCellObserver.SourceFieldName == this.coldChain.ColdEquipment.DepartmentColumn.Caption)
                    ChangeEquipmentDepartmentNotation();
                else if (manager.EditingCellObserver.SourceFieldName == this.coldChain.ColdEquipment.Forwarder_IDColumn.Caption)
                    ChangeEquipmentForwarder();
            }
            else
                throw new NotImplementedException();
        }

        /// <summary>
        /// Изменение типа транспортировки холодильного оборудования
        /// </summary>
        private void ChangeEquipmentTransportationType()
        {
            try
            {
                string newTransportationType = manager.EditingCellObserver.NewValue.ToString();
                this.coldEquipmentTableAdapter.ChangeEquipmentTransportationType(manager.CurrentEquipmentID, newTransportationType, manager.UserID);

                MessageBox.Show(this, "Тип транспортировки холодильного оборудования был успешно изменен.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                manager.EditingCellObserver.ExecuteActionAfterUpdate = RefreshEquipment; // Обновим список холодильного оборудования
            }
            catch (System.Data.SqlClient.SqlException er)
            {
                MessageBox.Show(er.Message, "Ошибка момента изменения типа транспортировки холодильного оборудования", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception();
            }
        }

        /// <summary>
        /// Изменение признака активности холодильного оборудования
        /// </summary>
        private void ChangeEquipmentAbility()
        {
            try
            {
                bool newEquipmentOperationActivity = Convert.ToBoolean(manager.EditingCellObserver.NewValue);
                this.coldEquipmentTableAdapter.ChangeEquipmentOperationActivity(manager.CurrentEquipmentID, newEquipmentOperationActivity, manager.UserID);

                MessageBox.Show(this, "Тип исправности холодильного оборудования был успешно изменен.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                manager.EditingCellObserver.ExecuteActionAfterUpdate = RefreshEquipment; // Обновим список холодильного оборудования
            }
            catch (System.Data.SqlClient.SqlException er)
            {
                MessageBox.Show(er.Message, "Ошибка момента изменения исправности холодильного оборудования", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception();
            }
        }

        /// <summary>
        /// Изменение привязки холодильного оборудования к филиалу
        /// </summary>
        private void ChangeEquipmentBranch()
        {
            try
            {
                string newEquipmentBranch = manager.EditingCellObserver.NewValue.ToString();
                this.coldEquipmentTableAdapter.ChangeEquipmentBranch(manager.UserID, newEquipmentBranch, manager.CurrentEquipmentID);

                MessageBox.Show(this, "Привязка холодильного оборудования к филиалу была успешно изменена.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                manager.EditingCellObserver.ExecuteActionAfterUpdate = RefreshEquipment; // Обновим список холодильного оборудования
            }
            catch (System.Data.SqlClient.SqlException er)
            {
                MessageBox.Show(er.Message, "Ошибка момента изменения привязки холодильного оборудования к филиалу", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception();
            }
        }

        /// <summary>
        /// Измененеие экспедитора закрепленного за оборудованием
        /// </summary>
        private void ChangeEquipmentForwarder()
        {
            try
            {
                int newEquipmentForwarder = Convert.ToInt32(manager.EditingCellObserver.NewValue);
                this.coldEquipmentTableAdapter.ChangeEquipmentForwarder(manager.CurrentEquipmentID, newEquipmentForwarder, manager.UserID);

                MessageBox.Show(this, "Привязка экспедитора была успешно изменена.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                manager.EditingCellObserver.ExecuteActionAfterUpdate = RefreshEquipment; // Обновим список холодильного оборудования
            }
            catch (System.Data.SqlClient.SqlException er)
            {
                MessageBox.Show(er.Message, "Ошибка момента изменения привязки экспедитора", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception();
            }
        }

          /// <summary>
        /// Изменение отдела для холодильного оборудования
        /// </summary>
        private void ChangeEquipmentDepartmentNotation()
        {
            try
            {
                string newEquipmentDepartmentNotation = manager.EditingCellObserver.NewValue.ToString();
                this.coldEquipmentTableAdapter.ChangeEquipmentDepartmentNotation(manager.UserID, newEquipmentDepartmentNotation, manager.CurrentEquipmentID);

                MessageBox.Show(this, "Отдел для холодильного оборудования был успешно изменен.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                manager.EditingCellObserver.ExecuteActionAfterUpdate = RefreshEquipment; // Обновим список холодильного оборудования
            }
            catch (System.Data.SqlClient.SqlException er)
            {
                MessageBox.Show(er.Message, "Ошибка момента изменения отдела для холодильного оборудования", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception();
            }
        }

        private void dgvColdEquipment_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if ((sender as DataGridView).IsCurrentCellInEditMode && manager.EditingCellObserver.ExecuteActionAfterUpdate != null)
            {
                manager.EditingCellObserver.ExecuteActionAfterUpdate();
                manager.EditingCellObserver.ExecuteActionAfterUpdate = null;
            }
        }

        private void dgvColdEquipment_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        #region ЭКСПОРТ ТАБЛИЦЫ В EXCEL

        /// <summary>
        /// Настройка доступности элементов на панели инструментов в зависимости от выбранного оборудования в таблице
        /// </summary>
        private void dgvColdEquipment_SelectionChanged(object sender, EventArgs e)
        {
            tssAfterPrintLabel.Visible = sbPrintEquipmentSticker.Visible;
        }

        /// <summary>
        /// Экспорт справочника холодильного оборудования в CSV-файл
        /// </summary>
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                ExportHelper.ExportDataGridViewToExcel(dgvColdEquipment, "Экспорт справочника", "холодильное оборудование", true);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Во время экспорта справочника холодильного оборудования произошла ошибка:", exc);
            }
        }

        #endregion

        private void btnFullEquipmentStates_Click(object sender, EventArgs e)
        {
            try
            {
                var dlgFullEquipmentState = new FullEquipmentStateForm() { UserID = manager.UserID };
                dlgFullEquipmentState.ShowDialog();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }
    }
}
