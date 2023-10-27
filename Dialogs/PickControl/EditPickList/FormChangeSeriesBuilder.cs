using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Transactions;
using System.Windows.Forms;
using WMSOffice.Data.PickControlTableAdapters;
using WMSOffice.Reports;

namespace WMSOffice.Dialogs.PickControl.EditPickList
{
    /// <summary>
    /// Строитель формы корректировки по причине "Замена серии"
    /// </summary>
    public class FormChangeSeriesBuilder : IFormBuilder
    {
        #region локальные переменные

        private PickListRow _pickListRow = null;
        private int _sessionId;

        private DescriptionControl _descriptionControl;
        private ChangeSeriesControl _changeSeriesControl;
        private ChangeSeriesControl _splitChangeSeriesControl;

        #endregion

        #region конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="pickListRow">Информация о строке сборочного</param>
        /// <param name="sessionId">Сессия пользователя WMS</param>
        public FormChangeSeriesBuilder(PickListRow pickListRow, int sessionId)
        {
            _pickListRow = pickListRow;
            _sessionId = sessionId;
        }

        #endregion

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
            //using (QueriesTableAdapter adapter = new QueriesTableAdapter())
            //{
            //    _location = adapter.GetLocation((int)CorrectionReasons.OutOfStock, null, null,
            //                                    _pickListRow.Company, _pickListRow.DocumentType, _pickListRow.DocumentNumber, _pickListRow.PickSlipNumber, _pickListRow.LineId).Trim();
            //}

            Controls = new List<BaseControl>();

            // информация о текущем состоянии строки заказа
            CurrentRowControl currentRow = new CurrentRowControl()
                                               {
                                                   Location = _pickListRow.Location,
                                                   Item = _pickListRow.Item,
                                                   Quantity = _pickListRow.Quantity.ToString(),
                                                   Series = _pickListRow.Series,
                                                   TabStop = false
                                               };
            Controls.Add(currentRow);

            _changeSeriesControl = new ChangeSeriesControl()
                                       {
                                           SplitEnabled = false,
                                           EditQuantityEnabled = false,
                                           OriginalQuantity = _pickListRow.Quantity,
                                           Quantity = _pickListRow.Quantity,
                                           PickList = _pickListRow,
                                           SessionID = _sessionId
                                       };
            _changeSeriesControl.ValueChanged += (field, value) => ParseFormValues(false, field, value);
            Controls.Add(_changeSeriesControl);

            _splitChangeSeriesControl = new ChangeSeriesControl()
                                            {
                                                QuantityLabel = "Количество 2:",
                                                SeriesLabel = "Серия 2:",
                                                EditQuantityEnabled = true,
                                                OriginalQuantity = _pickListRow.Quantity,
                                                PickList = _pickListRow,
                                                SessionID = _sessionId
                                            };
            _splitChangeSeriesControl.ValueChanged += (field, value) => ParseFormValues(true, field, value);
            Controls.Add(_splitChangeSeriesControl);

            // описание действия системы
            _descriptionControl = new DescriptionControl()
                                      {
                                          Action = String.Format("Вы производите пересортицу серии {0}", _pickListRow.Series),
                                          Count = _pickListRow.Quantity.ToString(CultureInfo.InvariantCulture),
                                          Description = String.Format("Действие системы: Серия {0} в количестве {1} будет пересортирована на выбранную серию.", _pickListRow.Series, _pickListRow.Quantity),
                                          TabStop = false
                                      };
            Controls.Add(_descriptionControl);

            if (DialogResultEnableChanged != null)
                DialogResultEnableChanged(this, new DialogResultEnableEventArgs() { ButtonOkEnabled = true, ButtonCancelEnabled = true });
        }

        /// <summary>
        /// Обработчик события изменения значения на форме корректировки
        /// </summary>
        /// <param name="field">Поле формы</param>
        /// <param name="value">Новое значение</param>
        private void ParseFormValues(bool isSplitRow, string field, object value)
        {
            bool allowOk = true;

            if (field == "Quantity" && isSplitRow)
            {
                int splitQuantity = (int) value;
                _changeSeriesControl.Quantity = _pickListRow.Quantity - splitQuantity;
                _changeSeriesControl.RefreshForm();
                // _descriptionControl.Count = splitQuantity.ToString();
                //_descriptionControl.Description = String.Format("Действие системы: Серия {0} в количестве {1} будет пересортирована на серию {2}.", _pickListRow.Series, _pickListRow.Quantity, _changeSeriesControl.Series);
            }

            if (field == "Series")
            {
                //_descriptionControl.Description = String.Format("Действие системы: Серия {0} в количестве {1} будет пересортирована на серию {2}.", _pickListRow.Series, _pickListRow.Quantity, _pickListRow.Series);
            }

            _descriptionControl.Description = (_splitChangeSeriesControl.SplitChecked)
                ? String.Format("Действие системы: Серия \"{0}\" в количестве {1} будет пересортирована на серию \"{2}\" в количестве {3} и серию \"{4}\" в количестве {5}.", _pickListRow.Series, _pickListRow.Quantity, _changeSeriesControl.Series, _changeSeriesControl.Quantity, _splitChangeSeriesControl.Series, _splitChangeSeriesControl.Quantity)
                : String.Format("Действие системы: Серия \"{0}\" в количестве {1} будет пересортирована на серию \"{2}\" в количестве {3}.", _pickListRow.Series, _pickListRow.Quantity, _changeSeriesControl.Series, _changeSeriesControl.Quantity);


            //if (field == "Split" && isSplitRow)
            //{
            //    _changeSeriesControl.RefreshForm();
            //}

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
            // проверка значений, введенных на форме
            if ((_changeSeriesControl.Quantity == 0)
                || (_splitChangeSeriesControl.SplitChecked && _splitChangeSeriesControl.Quantity == 0))
                ShowError("Поле \"Количество\" не может быть пустым или равняться 0."); 
            else if ((String.IsNullOrEmpty(_changeSeriesControl.Series)) 
                || (_splitChangeSeriesControl.SplitChecked && String.IsNullOrEmpty(_splitChangeSeriesControl.Series)))
                ShowError("Поле \"Серия\" не может быть пустым.");
            //else if ((_pickListRow.Series == _changeSeriesControl.Series)
            //    || (_splitChangeSeriesControl.SplitChecked && _pickListRow.Series == _splitChangeSeriesControl.Series))
            //    ShowError("Поле \"Серия\" должно быть изменено, для корректировки \"Замена серии\".");
            else
            {
                var changedAmount = (int?)null;
                var confirmEmployeeID = (Container as EditPickListItemForm).CheckPickSlipItemEditSum(changedAmount);

                using (QueriesTableAdapter adapter = new QueriesTableAdapter())
                {
                    SqlConnection connection = new SqlConnection(adapter.ConnectionString);
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();
                    try
                    {
                        // база данных, корректировка
                        adapter.CP_Correct_ChangeSeries_InTransaction(connection, transaction,
                            _sessionId, (int)CorrectionReasons.ChangeSeries, _pickListRow.Company,
                            _pickListRow.DocumentType, _pickListRow.DocumentNumber, _pickListRow.PickSlipNumber, _pickListRow.LineId,
                            _changeSeriesControl.Series, _changeSeriesControl.Quantity, confirmEmployeeID);
                        // база данных, корректировка (разделение строки)
                        if (_splitChangeSeriesControl.SplitChecked)
                            adapter.CP_Correct_ChangeSeries_InTransaction(connection, transaction,
                                _sessionId, (int)CorrectionReasons.ChangeSeries, _pickListRow.Company,
                                _pickListRow.DocumentType, _pickListRow.DocumentNumber, _pickListRow.PickSlipNumber, _pickListRow.LineId,
                                _splitChangeSeriesControl.Series, _splitChangeSeriesControl.Quantity, confirmEmployeeID);
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

        private void ShowError(string message)
        {
            // MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            throw new ArgumentException(message);
        }

        /// <summary>
        /// Событие, призывающее изменить состояние доступности кнопок закрытия диалога корректировки
        /// </summary>
        public event EventHandler<DialogResultEnableEventArgs> DialogResultEnableChanged;

        #endregion
    }
}