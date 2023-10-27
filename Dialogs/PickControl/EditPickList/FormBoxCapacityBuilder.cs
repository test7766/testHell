using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WMSOffice.Controls;
using WMSOffice.Data.PickControlTableAdapters;
using WMSOffice.Reports;

namespace WMSOffice.Dialogs.PickControl.EditPickList
{
    /// <summary>
    /// Строитель формы корректировки по причине "Ящичная норма"
    /// </summary>
    public class FormBoxCapacityBuilder : IFormBuilder
    {
        #region локальные переменные

        private PickListRow _pickListRow = null;
        private int _sessionId;

        //private QuantityChangeControl _quantityChange;
        //private int _allRemainsCount;
        //private string _location = "NULL";
        private CheckBoxControl _notifyCheckBoxControl;
        private BoxMeasurementControl _boxOrigMeasurementControl;
        private BoxMeasurementControl _boxFactMeasurementControl;
        private DescriptionControl _descriptionControl;

        #endregion

        #region конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="pickListRow">Информация о строке сборочного</param>
        /// <param name="sessionId">Сессия пользователя WMS</param>
        public FormBoxCapacityBuilder(PickListRow pickListRow, int sessionId)
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
            // определяем количество ящиков
            int boxCount;
            int? origQtyInBox = null;
            using (QueriesTableAdapter adapter = new QueriesTableAdapter())
            {
                adapter.CP_GetItemQtyInBox(_sessionId, _pickListRow.Company, _pickListRow.DocumentType, _pickListRow.DocumentNumber, _pickListRow.LineId, ref origQtyInBox);
                if (!origQtyInBox.HasValue)
                    origQtyInBox = 1;
                boxCount = _pickListRow.Quantity / origQtyInBox.Value;
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

            // количество штук в ящике
            _boxOrigMeasurementControl = new BoxMeasurementControl()
                                                                   {
                                                                       QuantityLabel = "Количество в ящике в справочнике:",
                                                                       QuantityEnabled = false,
                                                                       OriginalQuantity = _pickListRow.Quantity,
                                                                       Quantity = origQtyInBox.Value,
                                                                       BoxCount = boxCount
                                                                   };
            Controls.Add(_boxOrigMeasurementControl);

            // фактическое количество штук в ящике
            _boxFactMeasurementControl = new BoxMeasurementControl()
                                                                   {
                                                                       QuantityLabel = "Фактическое количество в ящике:",
                                                                       QuantityEnabled = true,
                                                                       OriginalQuantity = _pickListRow.Quantity,
                                                                       Quantity = origQtyInBox.Value,
                                                                       BoxCount = boxCount
                                                                   };
            _boxFactMeasurementControl.ValueChanged += ParseFormValues;
            Controls.Add(_boxFactMeasurementControl);

            // признак необходимости уведомить оператора
            _notifyCheckBoxControl = new CheckBoxControl()
            {
                SelectLabel = "Уведомить оператора справочника для замены количества в ящике"
            };
            Controls.Add(_notifyCheckBoxControl);

            // описание действия системы
            _descriptionControl = new DescriptionControl();
            _descriptionControl.Action = String.Format("Вы изменяете ящичную норму: ({0}) {1}", _pickListRow.ItemId, _pickListRow.Item);
            _descriptionControl.Count = "0";
            _descriptionControl.Description = String.Format("Действие системы: На отмененное количество будет снят резерв и товар вновь станет доступным на полке {0}.", _pickListRow.Location);
            Controls.Add(_descriptionControl);

            if (DialogResultEnableChanged != null)
                DialogResultEnableChanged(this, new DialogResultEnableEventArgs() { ButtonOkEnabled = true, ButtonCancelEnabled = true });
        }

        /// <summary>
        /// Обработчик события изменения значения на форме корректировки
        /// </summary>
        /// <param name="field">Поле формы</param>
        /// <param name="value">Новое значение</param>
        private void ParseFormValues(string field, object value)
        {
            bool allowOk = true;

            if (field == "Quantity")
            {
                int val = (int) value;
                if (val < 1) val = _boxOrigMeasurementControl.Quantity;
                if (val < 1) val = 1;
                int boxes = _pickListRow.Quantity / val;
                _boxFactMeasurementControl.BoxCount = boxes;
                _boxFactMeasurementControl.RefreshForm();
                _descriptionControl.Count = (_pickListRow.Quantity - val*boxes).ToString();
            }

            if (DialogResultEnableChanged != null)
                DialogResultEnableChanged(this, new DialogResultEnableEventArgs() { ButtonOkEnabled = allowOk, ButtonCancelEnabled = true });
        }

        /// <summary>
        /// Метод сохранения данных формы
        /// </summary>
        public void SaveData()
        {
            var changedAmount = _boxFactMeasurementControl.Quantity * _boxFactMeasurementControl.BoxCount;
            var confirmEmployeeID = (Container as EditPickListItemForm).CheckPickSlipItemEditSum(changedAmount);

            using (QueriesTableAdapter adapter = new QueriesTableAdapter())
            {
                // база данных, корректировка строки
                adapter.CP_Correct_BoxNorm(_sessionId, (int)CorrectionReasons.BoxCapacity, _pickListRow.Company, _pickListRow.DocumentType,
                                              _pickListRow.DocumentNumber, _pickListRow.PickSlipNumber, _pickListRow.LineId,
                                              _boxFactMeasurementControl.Quantity, _boxFactMeasurementControl.Quantity * _boxFactMeasurementControl.BoxCount, _notifyCheckBoxControl.IsSelected, confirmEmployeeID);
            }
            // если не попали на throw; и можем печатать Акты
            /*using (SubstandartActsTableAdapter adapter = new SubstandartActsTableAdapter())
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
            }*/
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
    }
}