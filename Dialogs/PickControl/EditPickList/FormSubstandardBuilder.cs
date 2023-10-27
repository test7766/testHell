using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;
using WMSOffice.Data.PickControlTableAdapters;
using WMSOffice.Reports;

namespace WMSOffice.Dialogs.PickControl.EditPickList
{
    /// <summary>
    /// Строитель формы корректировки по причине "Замена серии"
    /// </summary>
    public class FormSubstandardBuilder : IFormBuilder
    {
        #region локальные переменные

        private PickListRow _pickListRow = null;
        private int _sessionId;

        private SelectSubreasonControl _selectSubreasonBojControl;
        private SelectSubreasonControl _selectSubreasonNtvControl;
        private SelectEmployeeControl _selectGuiltyEmployeeControl;
        private SelectEmployeeControl _selectOfficerEmployeeControl;
        private DescriptionControl _descriptionControl;
        private string _locationBoj = "NULL";
        private string _locationNtv = "NULL";

        #endregion

        #region конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="pickListRow">Информация о строке сборочного</param>
        /// <param name="sessionId">Сессия пользователя WMS</param>
        public FormSubstandardBuilder(PickListRow pickListRow, int sessionId)
        {
            _pickListRow = pickListRow;
            _sessionId = sessionId;
        }

        #endregion

        private enum Subreasons
        {
            Boj = 1,
            Ntv = 2,
            Guilty = 256,
            Officer = 257
        };

        #region Implementation of IFormBuilder

        /// <summary>
        /// Созданные элементы управления для формы
        /// </summary>
        public List<BaseControl> Controls { get; set; }

        /// <summary>
        /// Метод построения элементов управления
        /// </summary>
        public void LoadControls()
        {
            // определяем полку, на которую будет перемещаться товар
            using (QueriesTableAdapter adapter = new QueriesTableAdapter())
            {
                var locn = adapter.GetLocation((int)CorrectionReasons.Substandard, "BO", null,
                                               _pickListRow.Company, _pickListRow.DocumentType,
                                               _pickListRow.DocumentNumber, _pickListRow.PickSlipNumber,
                                               _pickListRow.LineId, 0);
                if (locn != null)
                    _locationBoj = ((string)locn).Trim();
                locn = null;
                locn = adapter.GetLocation((int)CorrectionReasons.Substandard, "NV", null,
                                                   _pickListRow.Company, _pickListRow.DocumentType,
                                                   _pickListRow.DocumentNumber, _pickListRow.PickSlipNumber,
                                                   _pickListRow.LineId, 0);
                if (locn != null)
                    _locationNtv = ((string)locn).Trim();
            }

            Controls = new List<BaseControl>();

            // информация о текущем состоянии строки заказа
            CurrentRowControl currentRow = new CurrentRowControl()
                                               {
                                                   Location = _pickListRow.Location,
                                                   Item = _pickListRow.Item,
                                                   Quantity = _pickListRow.Quantity.ToString(),
                                                   Series = _pickListRow.Series
                                               };
            Controls.Add(currentRow);

            // ввод количества Бой
            _selectSubreasonBojControl = new SelectSubreasonControl()
                                                                 {
                                                                     SubreasonLabel = "Бой",
                                                                     QuantityLabel = "Количество Боя:",
                                                                     OriginalQuantity = _pickListRow.Quantity,
                                                                     Quantity = 0
                                                                 };
            _selectSubreasonBojControl.ValueChanged += (field, value) => ParseFormValues(Subreasons.Boj, field, value);
            Controls.Add(_selectSubreasonBojControl);

            // ввод количества НТВ
            _selectSubreasonNtvControl = new SelectSubreasonControl()
                                             {
                                                 SubreasonLabel = "НТВ",
                                                 QuantityLabel = "Количество НТВ:",
                                                 OriginalQuantity = _pickListRow.Quantity,
                                                 Quantity = 0
                                             };
            _selectSubreasonNtvControl.ValueChanged += (field, value) => ParseFormValues(Subreasons.Ntv, field, value);
            Controls.Add(_selectSubreasonNtvControl);

            // ввод виновного сотрудника
            _selectGuiltyEmployeeControl = new SelectEmployeeControl()
                                                               {
                                                                   EmployeeLabel = "Виновный сотрудник:",
                                                                   IsRequired = false
                                                               };
            _selectGuiltyEmployeeControl.ValueChanged += (field, value) => ParseFormValues(Subreasons.Ntv, field, value);
            Controls.Add(_selectGuiltyEmployeeControl);

            // ввод ответственного сотрудника
            _selectOfficerEmployeeControl = new SelectEmployeeControl()
                                                               {
                                                                   EmployeeLabel = "Ответственный сотрудник:",
                                                                   IsRequired = true
                                                               };
            Controls.Add(_selectOfficerEmployeeControl);

            // описание действия системы
            _descriptionControl = new DescriptionControl();
            _descriptionControl.Action = String.Format("Вы корректируете: ({0}) {1}", _pickListRow.ItemId, _pickListRow.Item);
            _descriptionControl.Count = "0";
            _descriptionControl.Description = String.Format("Выберите причину некондиционного товара и укажите количество. Обязательно укажите ответственного сотрудника и, по возможности, код виновного сотрудника.");
            Controls.Add(_descriptionControl);

            if (DialogResultEnableChanged != null)
                DialogResultEnableChanged(this, new DialogResultEnableEventArgs() { ButtonOkEnabled = true, ButtonCancelEnabled = true });
        }

        /// <summary>
        /// Обработчик события изменения значения на форме корректировки
        /// </summary>
        /// <param name="field">Поле формы</param>
        /// <param name="value">Новое значение</param>
        private void ParseFormValues(Subreasons subreason, string field, object value)
        {
            bool allowOk = true;

            bool changeGuilty = (subreason == Subreasons.Guilty && _selectGuiltyEmployeeControl.EmployeeID > 0);

            // обновление названий полок, куда будет перемещаться товар
            if ((field == "Select" && (bool)value) || (field == "Quantity") || changeGuilty)
            {
                // определяем полку, на которую будет перемещаться товар
                using (QueriesTableAdapter adapter = new QueriesTableAdapter())
                {
                    if (subreason == Subreasons.Boj || changeGuilty)
                    {
                        var locn = adapter.GetLocation((int) CorrectionReasons.Substandard, "BO", null,
                                                       _pickListRow.Company, _pickListRow.DocumentType,
                                                       _pickListRow.DocumentNumber, _pickListRow.PickSlipNumber,
                                                       _pickListRow.LineId, _selectSubreasonBojControl.Quantity);
                        if (locn != null)
                            _locationBoj = ((string) locn).Trim();
                    }
                    if (subreason == Subreasons.Ntv || changeGuilty)
                    {
                        var locn = adapter.GetLocation((int) CorrectionReasons.Substandard, "NV", null,
                                                       _pickListRow.Company, _pickListRow.DocumentType,
                                                       _pickListRow.DocumentNumber, _pickListRow.PickSlipNumber,
                                                       _pickListRow.LineId, _selectSubreasonNtvControl.Quantity);
                        if (locn != null)
                            _locationNtv = ((string) locn).Trim();
                    }
                }
            }
            
            // описание действий системы
            int qtyBoj = (_selectSubreasonBojControl.Selected) ? _selectSubreasonBojControl.Quantity : 0;
            int qtyNtv = (_selectSubreasonNtvControl.Selected) ? _selectSubreasonNtvControl.Quantity : 0;
            _descriptionControl.Count = (qtyBoj + qtyNtv).ToString();

            if (qtyBoj + qtyNtv > _pickListRow.Quantity)
                _descriptionControl.Description = String.Format("ОШИБКА! Корректируемое количество ({0} + {1}) превышает Исходное ({2})!", qtyBoj, qtyNtv, _pickListRow.Quantity);
            else
            {
                _descriptionControl.Description = "Действие системы: ";
                if (qtyBoj > 0)
                    _descriptionControl.Description += String.Format("Бой в количестве {0} будет перемещен на полку {1}. ", qtyBoj, _locationBoj);
                if (qtyNtv > 0)
                    _descriptionControl.Description += String.Format("НТВ в количестве {0} будет перемещен на полку {1}. ", qtyNtv, _locationNtv);
                if (qtyBoj + qtyNtv > 0)
                    _descriptionControl.Description += String.Format(
                            "На принтере по умолчанию будет распечатан Акт обнаружения некондиционного товара. Подпишите его у всех сотрудников, указанных в документе, и переместите товар в карантин.");
                else
                    _descriptionControl.Description = String.Format(
                            "Выберите причину некондиционного товара и укажите количество. Обязательно укажите ответственного сотрудника и, по возможности, код виновного сотрудника.");
            }

            //"\nДоступный остаток на полке {1} в количестве {2} будет перемещен на полку {0}.", _location, _pickListRow.Location, _allRemainsCount);

        //    if (field == "Quantity")
        //        _descriptionControl.Count = _quantityChange.CanceledQuantity.ToString();

        //    if (field == "MoveAllRemains")
        //        if ((bool)value)
        //        {
        //            try
        //            {
        //                // определяем полку, на которую будет перемещаться товар
        //                using (QueriesTableAdapter adapter = new QueriesTableAdapter())
        //                {
        //                    var res = adapter.CP_GetRemainsByLocation(_sessionId, _pickListRow.Company, _pickListRow.DocumentType, _pickListRow.DocumentNumber, _pickListRow.PickSlipNumber, _pickListRow.LineId);
        //                    _allRemainsCount = (res != null) ? (int)res : 0;
        //                }
        //                if (_allRemainsCount > 0)
        //                    _descriptionControl.Description = String.Format("Действие системы: Отмененное количество будет перемещено на полку {0}.\nДоступный остаток на полке {1} в количестве {2} будет перемещен на полку {0}.", _location, _pickListRow.Location, _allRemainsCount);
        //                else
        //                    _descriptionControl.Description = String.Format("Действие системы: Отмененное количество будет перемещено на полку {0}.\nДоступный остаток на полке {1} отсутствует.", _location, _pickListRow.Location);

        //            }
        //            catch (Exception ex)
        //            {
        //                _descriptionControl.Description = String.Format("Действие системы: Отмененное количество будет перемещено на полку {0}.\nОшибка при получении доступного остатка:\n {1}.", _location, ex.Message);
        //            }
        //        }
        //        else
        //        {
        //            _descriptionControl.Description = String.Format("Действие системы: Отмененное количество будет перемещено на полку {0}.", _location);
        //            _allRemainsCount = 0;
        //        }

            if (DialogResultEnableChanged != null)
                DialogResultEnableChanged(this, new DialogResultEnableEventArgs() { ButtonOkEnabled = allowOk, ButtonCancelEnabled = true });
        }

        /// <summary>
        /// Метод сохранения данных формы
        /// </summary>
        public void SaveData()
        {
            // описание действий системы
            int qtyBoj = (_selectSubreasonBojControl.Selected) ? _selectSubreasonBojControl.Quantity : 0;
            int qtyNtv = (_selectSubreasonNtvControl.Selected) ? _selectSubreasonNtvControl.Quantity : 0;

            if (qtyBoj + qtyNtv <= 0)
                ShowError("Общее корректируемое количество 0.\nКорректировка не возможна.");
            else if (qtyBoj + qtyNtv > _pickListRow.Quantity)
                ShowError(String.Format("ОШИБКА! Корректируемое количество ({0} + {1}) превышает Исходное ({2})!", qtyBoj, qtyNtv, _pickListRow.Quantity));
            else if (_selectOfficerEmployeeControl.EmployeeID <= 0)
                ShowError("Поле \"Ответственный сотрудник\" является обязательным для ввода.");
            else
            {
                var changedAmount = _pickListRow.Quantity;
                if (_selectSubreasonBojControl.Selected)
                    changedAmount -= _selectSubreasonBojControl.Quantity;
                if (_selectSubreasonNtvControl.Selected)
                    changedAmount -= _selectSubreasonNtvControl.Quantity;

                var confirmEmployeeID = (Container as EditPickListItemForm).CheckPickSlipItemEditSum(changedAmount);

                using (QueriesTableAdapter adapter = new QueriesTableAdapter())
                {
                    SqlConnection connection = new SqlConnection(adapter.ConnectionString);
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();
                    try
                    {
                        // база данных, корректировка
                        if (_selectSubreasonBojControl.Selected)
                            adapter.CP_Correct_Substandard_InTransaction(connection, transaction,
                                _sessionId, (int)CorrectionReasons.Substandard, "BO", _pickListRow.Company,
                                _pickListRow.DocumentType, _pickListRow.DocumentNumber, _pickListRow.PickSlipNumber, _pickListRow.LineId,
                                _selectSubreasonBojControl.Quantity, _selectOfficerEmployeeControl.EmployeeID, (_selectGuiltyEmployeeControl.EmployeeID > 0) ? (int?)_selectGuiltyEmployeeControl.EmployeeID : null, confirmEmployeeID);
                        // база данных, корректировка (разделение строки)
                        if (_selectSubreasonNtvControl.Selected)
                            adapter.CP_Correct_Substandard_InTransaction(connection, transaction,
                                _sessionId, (int)CorrectionReasons.Substandard, "NV", _pickListRow.Company,
                                _pickListRow.DocumentType, _pickListRow.DocumentNumber, _pickListRow.PickSlipNumber, _pickListRow.LineId,
                                _selectSubreasonNtvControl.Quantity, _selectOfficerEmployeeControl.EmployeeID, (_selectGuiltyEmployeeControl.EmployeeID > 0) ? (int?)_selectGuiltyEmployeeControl.EmployeeID : null, confirmEmployeeID);
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }

                // если не попали на throw; и можем печатать Акты
                using (SubstandartActsTableAdapter adapter = new SubstandartActsTableAdapter())
                {
                    Data.PickControl.SubstandartActsDataTable table = adapter.GetDataList(_sessionId, _pickListRow.Company,
                                        _pickListRow.DocumentType, _pickListRow.DocumentNumber, _pickListRow.PickSlipNumber, _pickListRow.LineId);
                    if (table != null && table.Rows.Count > 0)
                    {
                        foreach (Data.PickControl.SubstandartActsRow row in table.Rows)
                        {
                            Data.PickControl.SubstandartActsDataTable act = new Data.PickControl.SubstandartActsDataTable();
                            act.ImportRow(row);

                            SubstandartActReport report = new SubstandartActReport();
                            Window.WHDocsControlWindow.SubstandartActBarcodePrepare(act);

                            try
                            {
                                report.SetDataSource((DataTable)act);

                                ReportForm form = new ReportForm();
                                form.ReportDocument = report;
                                form.Print();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Контейнер
        /// </summary>
        public object Container { get; set; }

        /// <summary>
        /// Событие, призывающее изменить состояние доступности кнопок закрытия диалога корректировки
        /// </summary>
        public event EventHandler<DialogResultEnableEventArgs> DialogResultEnableChanged;

        #endregion

        private void ShowError(string message)
        {
            throw new ArgumentException(message);
        }
    }
}