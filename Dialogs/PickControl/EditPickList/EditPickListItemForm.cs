using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.PickControl.EditPickList
{
    /// <summary>
    /// Форма, мастер построения интерфейса для корректировки строки
    /// </summary>
    public partial class EditPickListItemForm : Form
    {
        #region локальные переменные

        private PickListRow _pickListRow;
        private int _sessionID;

        /// <summary>
        /// Локальная переменная - строитель
        /// </summary>
        private IFormBuilder _formBuilder;

        /// <summary>
        /// Локальная переменная - абстрактная фабрика строителей форм
        /// </summary>
        private IFormsBuilderFactory _factory;

        #endregion

        #region конструкторы формы

        /// <summary>
        /// Публичный конструктор формы
        /// </summary>
        /// <param name="pickListRow">Информация о строке сборочного</param>
        /// <param name="sessionId">Сессия пользователя WMS</param>
        public EditPickListItemForm(IFormsBuilderFactory factory, PickListRow pickListRow, int sessionId)
            : this()
        {
            _factory = factory;
            _pickListRow = pickListRow;
            _sessionID = sessionId;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        private EditPickListItemForm()
        {
            InitializeComponent();
            chooseReasonControl.ReasonChanged += ChangeReason;
        }

        #endregion

        #region свойства

        /// <summary>
        /// Заголовок окна
        /// </summary>
        public string Caption
        {
            get { return this.Text; }
            set { this.Text = value; }
        }

        /// <summary>
        /// Список причин корректировки
        /// </summary>
        public List<CorrectionReason> Reasons
        {
            get { return chooseReasonControl.Reasons; }
        }

        /// <summary>
        /// Признак "Не устанавливать причину по умолчанию"
        /// </summary>
        public bool NotSetDefaultReason
        {
            get { return chooseReasonControl.NotSetDefaultReason; } 
            set { chooseReasonControl.NotSetDefaultReason = value; }
        }

        #endregion

        /// <summary>
        /// Метод изменения причины корректировки
        /// </summary>
        /// <param name="newReason"></param>
        private void ChangeReason(CorrectionReason newReason)
        {
            btnOk.Enabled = false;
            _formBuilder = _factory.CreateFormBuilder(newReason, _pickListRow, _sessionID);

            if (_formBuilder != null)
            {
                _formBuilder.DialogResultEnableChanged += ChangeDialogResultEnables;
                _formBuilder.Container = this;
                _formBuilder.LoadControls();

                contentPanel.Controls.Clear();
                if (_formBuilder.Controls.Count > 0)
                {
                    int height = 0;
                    for (int i = 0; i < _formBuilder.Controls.Count; i++)
                    {
                        contentPanel.Controls.Add(_formBuilder.Controls[i]);
                        height += _formBuilder.Controls[i].Height + 6;
                    }
                    this.Height = height + 100;
                }
            }
        }

        /// <summary>
        /// Обработчик запроса на изменение доступности кнопок результатов диалога корректировки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeDialogResultEnables(object sender, DialogResultEnableEventArgs e)
        {
            btnOk.Enabled = e.ButtonOkEnabled;
            btnCancel.Enabled = e.ButtonCancelEnabled;
        }

        /// <summary>
        /// Событие загрузки формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditPickListItemForm_Load(object sender, EventArgs e)
        {
            if (NotSetDefaultReason)
                chooseReasonControl.Focus();
            else 
                btnCancel.Focus();
        }

        /// <summary>
        /// Событие закрытия формы с сохранением результата работы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (_formBuilder != null)
                {
                    _formBuilder.SaveData();
                }
                this.DialogResult = DialogResult.OK;
                Close();
            } 
            catch (Exception ex)
            {
                if (ex is OperationCanceledException)
                {
                    MessageBox.Show(ex.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show(ex.Message.Replace("<br>", Environment.NewLine), "Произошла ошибка при сохранении данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Метод проверки суммы откорректированой позиции сборочного листа
        /// </summary>
        /// <param name="changedAmount">Количество после корректировки</param>
        /// <returns>Возвращает код визировавшего сотрудника (если необходимо) </returns>
        public int? CheckPickSlipItemEditSum(int? changedAmount)
        {
            var confirmEmployeeID = 0;

            int? errorCode = 0;
        
            try
            {
                decimal? sumDifference = 0.0M;

                using (var adapter = new Data.PickControlTableAdapters.QueriesTableAdapter())
                    adapter.CP_CheckAmount(_pickListRow.Company, _pickListRow.DocumentType, _pickListRow.DocumentNumber, _pickListRow.LineId, changedAmount, ref errorCode, ref sumDifference);

                // Необходимость визирования корректировки
                if (errorCode == 1)
                {
                    // скан ш/к
                    while (true)
                    {
                        var dlgScanner = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                        {
                            OnlyNumbersInBarcode = true,
                            Label = string.Format("Сумма корректировки превышает допустимую на {0:N2} грн.\r\nОтсканируйте бейдж ответственного сотрудника", sumDifference),
                            Text = "Сканирование бейджа сотрудника"
                        };

                        if (dlgScanner.ShowDialog() == DialogResult.OK)
                        {
                            if (int.TryParse(dlgScanner.Barcode, out confirmEmployeeID))
                            {
                                using (var adapter = new Data.PickControlTableAdapters.QueriesTableAdapter())
                                    adapter.CP_CheckResponsibleEmployee(confirmEmployeeID, ref errorCode);

                                // Сотрудник не является византом корректировки
                                if (errorCode == 1)
                                {
                                    MessageBox.Show("У Вас недостаточно прав для корректировки позиции сборочного листа.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    continue;
                                }

                                return confirmEmployeeID;
                            }
                            else 
                            {
                                MessageBox.Show("Неверный код сотрудника.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                continue;
                            }
                        }
                        else
                        {
                            throw new OperationCanceledException("Вы отменили последнее действие!");
                        }
                    }
                }
                else
                {
                    // визирование не требуется
                    return (int?)null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return confirmEmployeeID;
        }
    }
}
