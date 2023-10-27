using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Complaints
{
    public partial class CustomActionsForm : Form
    {
        /// <summary>
        /// Высота одной строки (не выбранной). Для выбранной строки увеличивается в 2 раза.
        /// </summary>
        private int RowHeight { get; set; }

        /// <summary>
        /// Список флажков.
        /// </summary>
        private List<CheckBox> CheckBoxes { get; set; }

        /// <summary>
        /// Список кнопок.
        /// </summary>
        private List<Button> Buttons { get; set; }

        /// <summary>
        /// Индекс последней отмеченной (выбранной) строки.
        /// </summary>
        private int LastCheckedRowIndex { get; set; }

        /// <summary>
        /// Временная надпись над дополнительными элементами управления для выбранной строки.
        /// </summary>
        private Label TempLabel { get; set; }

        /// <summary>
        /// Временное текстовое поле для выбранной строки.
        /// </summary>
        private TextBox TempTextBox { get; set; }

        /// <summary>
        /// Временный элемент для ввода даты для выбранной строки.
        /// </summary>
        private DateTimePicker TempDateTimePicker { get; set; }

        /// <summary>
        /// Информация по суммам дебитора
        /// </summary>
        public DebtorAmountsInfo DebtorAmountsInfo { get; private set; }
        
        /// <summary>
        /// Инициализирует новый экземпляр диалога.
        /// </summary>
        /// <param name="actions">Список доступных пользователю действий (как минимум одно).</param>
        public CustomActionsForm(CustomActionTypes actions, string complaintOrderNumber)
        {
            InitializeComponent();

            if ((int)actions == 0)
                throw new ArgumentNullException("actions");

            #region Информация по суммам дебитора
            this.DebtorAmountsInfo = new DebtorAmountsInfo(complaintOrderNumber);
            this.DebtorAmountsInfo.Initialize();

            if (!string.IsNullOrEmpty(this.DebtorAmountsInfo.DebtorName))
                lblDebtorValue.Text = this.DebtorAmountsInfo.DebtorName;
            if (this.DebtorAmountsInfo.Amount.HasValue)
                lblAmountValue.Text = this.DebtorAmountsInfo.Amount.Value.ToString("f2");
            if (this.DebtorAmountsInfo.VAT.HasValue)
                lblVATValue.Text = this.DebtorAmountsInfo.VAT.Value.ToString("f2");
            if (this.DebtorAmountsInfo.AmountWithVAT.HasValue)
                lblAmountWithVATValue.Text = this.DebtorAmountsInfo.AmountWithVAT.Value.ToString("f2");
            #endregion

            RowHeight = panel.Height; // подразумевается одна тестовая строка, добавленная во время дизайна
            panel.RowCount = 0;
            panel.Height = 0;
            panel.Controls.Remove(testCheckBox);
            testCheckBox = null;
            panel.Controls.Remove(testButton);
            testButton = null;
            this.Height -= RowHeight;

            LastCheckedRowIndex = -1;
            CheckBoxes = new List<CheckBox>();
            Buttons = new List<Button>();
            TempLabel = null;

            if ((actions & CustomActionTypes.CloseComplaint) > 0)
                AddRow(CustomActionTypes.CloseComplaint);

            if ((actions & CustomActionTypes.CloseByInvoices) > 0)
                AddRow(CustomActionTypes.CloseByInvoices);

            if ((actions & CustomActionTypes.ContinueItemControl) > 0)
                AddRow(CustomActionTypes.ContinueItemControl);

            if ((actions & CustomActionTypes.EnterDateConfirmReturn) > 0)
                AddRow(CustomActionTypes.EnterDateConfirmReturn);

            if ((actions & CustomActionTypes.CancelComplaint) > 0)
                AddRow(CustomActionTypes.CancelComplaint);

            if ((actions & CustomActionTypes.CloseCancelledComplaint) > 0)
                AddRow(CustomActionTypes.CloseCancelledComplaint);

            // Выбранное действие по умолчанию - поштучный контроль товара
            if ((actions & CustomActionTypes.ContinueItemControl) > 0)
            {
                foreach (var checkBox in CheckBoxes)
                {
                    if (checkBox.Tag.Equals(CustomActionTypes.ContinueItemControl))
                    {
                        checkBox.Checked = true;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Возвращает выбранное пользователем действие.
        /// </summary>
        public CustomActionTypes SelectedAction { get; private set; }

        /// <summary>
        /// Возвращает введенный пользователем комментарий к выбранному действию (CancelComplaint).
        /// </summary>
        public string Comment { get; private set; }

        /// <summary>
        /// Возвращает введенную пользователем дату для выбранного действия (EnterDateConfirmReturn).
        /// </summary>
        public DateTime? Date { get; private set; }

        /// <summary>
        /// Добавляет строку с флажком и кнопкой.
        /// </summary>
        /// <param name="action">Тип действия.</param>
        private void AddRow(CustomActionTypes action)
        {
            panel.RowCount += 1;
            panel.Height += RowHeight;
            panel.RowStyles.Add(new RowStyle());
            panel.RowStyles[panel.RowCount - 1].SizeType = SizeType.Absolute;
            panel.RowStyles[panel.RowCount - 1].Height = RowHeight;
            
            CheckBox checkBox = new CheckBox();
            checkBox.Tag = action;
            checkBox.Dock = DockStyle.Fill;
            checkBox.Padding = new Padding(3, 0, 0, 0);
            checkBox.CheckedChanged += CheckBoxCheckedChanged;
            CheckBoxes.Add(checkBox);
            panel.Controls.Add(checkBox);
            panel.SetCellPosition(checkBox, new TableLayoutPanelCellPosition(0, panel.RowCount - 1));

            Button button = new Button();
            button.Tag = action;
            button.Text = GetButtonTextByActionType(action);
            button.Dock = DockStyle.Top;
            button.Height = RowHeight - 7;
            button.Click += ButtonClick;
            button.Font = new Font(button.Font.FontFamily, 11);
            Buttons.Add(button);
            Panel buttonPanel = new Panel();
            buttonPanel.Dock = DockStyle.Fill;
            buttonPanel.Controls.Add(button);
            panel.Controls.Add(buttonPanel);
            panel.SetCellPosition(button, new TableLayoutPanelCellPosition(1, panel.RowCount - 1));
           

            this.Height += RowHeight;
        }

        /// <summary>
        /// Возвращает текст надписи на кнопке по типу действия.
        /// </summary>
        /// <param name="action">Тип действия.</param>
        /// <returns>Текст надписи на кнопке.</returns>
        private string GetButtonTextByActionType(CustomActionTypes action)
        {
            string result;
            switch (action)
            {
                case CustomActionTypes.CloseComplaint:
                    result = "Закрыть претензию (обработка полностью завершена)"; break;
                case CustomActionTypes.CloseByInvoices:
                    result = "Закрыть претензию (отсканировать расходные и уничтожить документы)"; break;
                case CustomActionTypes.ContinueItemControl:
                    result = "Начать поштучный контроль товара"; break;
                case CustomActionTypes.EnterDateConfirmReturn:
                    result = "Ввести дату подтверждения возврата"; break;
                case CustomActionTypes.CancelComplaint:
                    result = "Отменить претензию"; break;
                case CustomActionTypes.CloseCancelledComplaint:
                    result = "Закрыть отмененную претензию"; break;
                default:
                    result = "Default Button Action Text"; break;
            }
            return result;
        }

        /// <summary>
        /// Обрабатывает изменение состояния флажка.
        /// </summary>
        private void CheckBoxCheckedChanged(object sender, EventArgs e)
        {
            CheckBox senderCheckBox = (CheckBox)sender;
            int currCheckedRowIndex = CheckBoxes.IndexOf(senderCheckBox);

            if (senderCheckBox.Checked)
            {
                btnOK.Enabled = true;
                if (currCheckedRowIndex != LastCheckedRowIndex)
                {
                    if (LastCheckedRowIndex != -1)
                    {
                        CheckBoxes[LastCheckedRowIndex].Checked = false;
                        ClearTempControls();
                        Buttons[LastCheckedRowIndex].Font = new Font(Buttons[LastCheckedRowIndex].Font, FontStyle.Regular);
                        CheckBoxes[LastCheckedRowIndex].BackColor = Color.Transparent;
                    }
                    CheckBoxes[currCheckedRowIndex].BackColor = Color.DodgerBlue;
                    Panel buttonPanel = (Panel)Buttons[currCheckedRowIndex].Parent;
                    buttonPanel.BorderStyle = BorderStyle.FixedSingle;
                    Buttons[currCheckedRowIndex].Font = new Font(Buttons[currCheckedRowIndex].Font, FontStyle.Bold);
                    btnOK.Focus();
                    AddTempControls((CustomActionTypes)CheckBoxes[currCheckedRowIndex].Tag, currCheckedRowIndex, buttonPanel);
                    LastCheckedRowIndex = currCheckedRowIndex;
                }
            }
        }

        /// <summary>
        /// Убирает добавленные ранее дополнительные элементы управления (если они были).
        /// </summary>
        private void ClearTempControls()
        {
            if (TempLabel != null)
            {
                Panel buttonPanel = (Panel)TempLabel.Parent;
                buttonPanel.BorderStyle = BorderStyle.None;
                buttonPanel.Controls.Remove(TempLabel);
                TempLabel = null;
                if (TempTextBox != null)
                {
                    buttonPanel.Controls.Remove(TempTextBox);
                    TempTextBox = null;
                }
                if (TempDateTimePicker != null)
                {
                    buttonPanel.Controls.Remove(TempDateTimePicker);
                    TempDateTimePicker = null;
                }
                panel.RowStyles[LastCheckedRowIndex].Height -= RowHeight;
                panel.Height -= RowHeight;
                this.Height -= RowHeight;
            }
        }

        /// <summary>
        /// Добавляет дополнительные элементы управления, если они необходимы для выбранного типа действия,
        /// на панель под кнопкой.
        /// </summary>
        /// <param name="action">Тип действия.</param>
        /// <param name="rowIndex">Индекс строки.</param>
        /// <param name="buttonPanel">Панель, на которой находится кнопка.</param>
        private void AddTempControls(CustomActionTypes action, int rowIndex, Panel buttonPanel)
        {
            switch (action)
            {
                case CustomActionTypes.EnterDateConfirmReturn:
                    {
                        this.Height += RowHeight;
                        panel.Height += RowHeight;
                        panel.RowStyles[rowIndex].Height += RowHeight;

                        TempLabel = new Label() { AutoSize = true, Text = "Введите дату подтверждения возврата:", Top = RowHeight, Left = 50 };
                        buttonPanel.Controls.Add(TempLabel);
                        TempDateTimePicker = new DateTimePicker() { Format = DateTimePickerFormat.Short, Width = 120, Top = RowHeight + TempLabel.Height + 5, Left = 50};
                        buttonPanel.Controls.Add(TempDateTimePicker);
                        break;
                    }
                case CustomActionTypes.CancelComplaint:
                    {
                        this.Height += RowHeight;
                        panel.Height += RowHeight;
                        panel.RowStyles[rowIndex].Height += RowHeight;

                        TempLabel = new Label() { AutoSize = true, Text = "Введите причину отмены претензии:", Top = RowHeight, Left = 50 };
                        buttonPanel.Controls.Add(TempLabel);
                        TempTextBox = new TextBox() { MaxLength = 500, Width = 250, Top = RowHeight + TempLabel.Height + 5, Left = 50 };
                        buttonPanel.Controls.Add(TempTextBox);
                        TempTextBox.Focus();
                        break;
                    }
                default:
                    break;
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку.
        /// </summary>
        private void ButtonClick(object sender, EventArgs e)
        {
            int clickedRowIndex = Buttons.IndexOf((Button)sender);
            if (!CheckBoxes[clickedRowIndex].Checked)
                CheckBoxes[clickedRowIndex].Checked = true;
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Продолжить".
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (TempTextBox != null && TempTextBox.Text.Length < 15)
            {
                MessageBox.Show("Введите не менее 15 символов!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TempTextBox.Focus();
                return;
            }

            SelectedAction = (CustomActionTypes)CheckBoxes[LastCheckedRowIndex].Tag;
            Comment = (TempTextBox == null ? null : TempTextBox.Text);
            Date = (TempDateTimePicker == null ? (DateTime?)null : TempDateTimePicker.Value);
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Отмена".
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

    /// <summary>
    /// Содержит варианты возможных дополнительных действий при закрытии претензии
    /// </summary>
    public enum CustomActionTypes
    {
        /// <summary>
        /// Действие "Закрыть претензию (обработка полностью завершена)"
        /// </summary>
        CloseComplaint = 1,

        /// <summary>
        /// Действие "Закрыть претензию (отсканировать расходные и уничтожить документы)"
        /// </summary>
        CloseByInvoices = 2,

        /// <summary>
        /// Действие "Начать поштучный контроль товара".
        /// </summary>
        ContinueItemControl = 4,

        /// <summary>
        /// Действие "Выбрать полки, на которые положить товар"
        /// </summary>
        ChooseLocation = 8,

        /// <summary>
        /// Действие "Ввести дату подтверждения возврата"
        /// </summary>
        EnterDateConfirmReturn = 16,

        /// <summary>
        /// Действие "Отменить претензию"
        /// </summary>
        CancelComplaint = 64,

        /// <summary>
        /// Действие "Закрыть отмененную претензию"
        /// </summary>
        CloseCancelledComplaint = 128,

        /// <summary>
        /// Действие "Выбрать полки на которые нужно положить товар по консолидированной накладной"
        /// </summary>
        ChooseLocationForConsolidatedInvoice = 256
    }

    /// <summary>
    /// Информация по суммам дебитора
    /// </summary>
    public class DebtorAmountsInfo
    {
        private readonly string _complaintOrderNumber = null;

        public string DebtorName { get; private set; }
        public double? Amount { get; private set; }
        public double? VAT { get; private set; }
        public double? AmountWithVAT { get; private set; }

        public long? CO_DocID { get; private set; }

        public DebtorAmountsInfo(string complaintOrderNumber)
        {
            _complaintOrderNumber = complaintOrderNumber;
        }

        public void Initialize()
        {
            try
            {
                var data = new Data.Complaints.CO_CustomActions_DebtorAmountsInfoDataTable();

                using (var adapter = new Data.ComplaintsTableAdapters.CO_CustomActions_DebtorAmountsInfoTableAdapter())
                    adapter.Fill(data, _complaintOrderNumber);

                foreach (Data.Complaints.CO_CustomActions_DebtorAmountsInfoRow info in data)
                {
                    if (!info.IsDebitor_NameNull())
                        this.DebtorName = info.Debitor_Name;
                    if (!info.IsAmountNull())
                        this.Amount = info.Amount;
                    if (!info.IsNDSNull())
                        this.VAT = info.NDS;
                    if (!info.IsAmountWNDSNull())
                        this.AmountWithVAT = info.AmountWNDS;

                    if (!info.IsExist_NTVNull())
                        this.CO_DocID = info.Exist_NTV;

                    break;
                }
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
