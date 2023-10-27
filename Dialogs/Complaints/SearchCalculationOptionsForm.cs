using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Complaints
{
    /// <summary>
    /// Диалог для ввода параметров поиска расчет-корректировки. 
    /// </summary>
    public partial class SearchCalculationOptionsForm : Form
    {
        #region Fields & Constants

        /// <summary>
        /// Индекс в вып. списке типа поиска по номеру претензии (код 1).
        /// </summary>
        private const int ComplaintNumSearchTypeIndex = 0;
        /// <summary>
        /// Индекс в вып. списке типа поиска по номеру расчет-корректировки (код 2).
        /// </summary>
        private const int CalculationNumSearchTypeIndex = 1;
        /// <summary>
        /// Индекс в вып. списке типа поиска по номеру служебной записки (код 3).
        /// </summary>
        private const int MemoNumSearchTypeIndex = 2;
        /// <summary>
        /// Индекс в вып. списке типа поиска по номеру оригинальной накладной (код 4).
        /// </summary>
        private const int InvoiceNumSearchTypeIndex = 3;
        /// <summary>
        /// Индекс в вып. списке типа поиска по коду адреса доставки или головного дебитора (код 5).
        /// </summary>
        private const int AddressCodeSearchTypeIndex = 4;

        #endregion


        #region Constructor

        /// <summary>
        /// Инициализирует новый экземпляр диалога.
        /// </summary>
        /// <param name="sessionID">Идентификатор сессии пользователя.</param>
        public SearchCalculationOptionsForm(long sessionID)
        {
            InitializeComponent();

            // заполнение списка типов претензий
            availableDocsTypesTableAdapter.Fill(complaints.AvailableDocsTypes, sessionID, false, null);

            cbSearchType.SelectedIndex = 0;

            dtpDateFrom.Value = DateTime.Today.AddDays(-1);
            dtpDateTo.Value = DateTime.Today.AddDays(1);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            cbSearchType.Focus();
        }

        #endregion


        #region Properties

        /// <summary>
        /// Выбранный пользователем тип поиска.
        /// </summary>
        public CalculationSearchType SearchType { get; private set; }

        /// <summary>
        /// Введенный пользователем номер документа (претензии / корректировки / служебки / код адреса доставки или головного дебитора).
        /// </summary>
        public long? DocNumber { get; private set; }

        /// <summary>
        /// Выбранный или введенный пользователем тип документа.
        /// </summary>
        public string DocType { get; private set; }

        /// <summary>
        /// Введенная пользователем дата претензии "с".
        /// </summary>
        public DateTime? DateFrom { get; private set; }

        /// <summary>
        /// Введенная пользователем дата претензии "по".
        /// </summary>
        public DateTime? DateTo { get; private set; }

        /// <summary>
        /// Введеный пользователем код товара.
        /// </summary>
        public int? ItemID { get; private set; }

        /// <summary>
        /// Введенное пользователем наименование товара.
        /// </summary>
        public string ItemName { get; private set; }

        #endregion


        #region Private methods

        /// <summary>
        /// Меняет доступность элементов управления при изменении состояния флажков.
        /// </summary>
        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            gbDocType.Enabled = chkbDocType.Checked;
            gbDate.Enabled = chkbDate.Checked;
            gbItemID.Enabled = chkbItemID.Checked;
            gbItemName.Enabled = chkbItemName.Checked;
        }

        /// <summary>
        /// Обрабатывает смену типа поиска, меняя доступность настроек поиска.
        /// </summary>
        private void cbSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbSearchType.SelectedIndex)
            {
                case ComplaintNumSearchTypeIndex:
                    SearchType = CalculationSearchType.Complaint;
                    cbComplaintTypes.Enabled = true;
                    tbDocType.Enabled = false;
                    chkbDocNumber.Text = "№ претензии:";
                    break;

                case CalculationNumSearchTypeIndex:
                    SearchType = CalculationSearchType.Calculation;
                    cbComplaintTypes.Enabled = false;
                    tbDocType.Enabled = true;
                    chkbDocNumber.Text = "№ расчет-корр.:";
                    break;

                case MemoNumSearchTypeIndex:
                    SearchType = CalculationSearchType.Memo;
                    cbComplaintTypes.Enabled = false;
                    tbDocType.Enabled = true;
                    chkbDocNumber.Text = "№ служ.зап.:";
                    break;

                case InvoiceNumSearchTypeIndex:
                    SearchType = CalculationSearchType.Invoice;
                    cbComplaintTypes.Enabled = false;
                    tbDocType.Enabled = true;
                    chkbDocNumber.Text = "№ ориг. накладной:";
                    break;

                case AddressCodeSearchTypeIndex:
                    SearchType = CalculationSearchType.AddressCode;
                    cbComplaintTypes.Enabled = false;
                    tbDocType.Enabled = true;
                    chkbDocNumber.Text = "Код деб. / адр.дост.:";
                    break;

                default:
                    break;
            }
        }

        private void SearchCalculationOptionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.ValidateData();
        }

        private bool ValidateData()
        {
            try
            {
                if (chkbDocNumber.Checked)
                {
                    long tmp = 0;
                    if (!long.TryParse(tbDocNumber.Text, out tmp) || tmp <= 0)
                    {
                        throw new Exception(chkbDocNumber.Text.Replace(":", "") + " введен некорректно.");
                    }
                    else
                    {
                        DocNumber = tmp;
                    }
                }
                else
                {
                    DocNumber = null;
                }

                if (chkbDocType.Checked)
                {
                    if (SearchType == CalculationSearchType.Complaint)
                        DocType = (string)cbComplaintTypes.SelectedValue;
                    else
                        DocType = string.IsNullOrEmpty(tbDocType.Text) ? null : tbDocType.Text;
                }
                else
                {
                    DocType = null;
                }

                if (chkbDate.Checked)
                {
                    if (dtpDateFrom.Value > dtpDateTo.Value)
                    {
                        throw new Exception("Дата периода \"с\" не может быть больше даты периода \"по\".");
                    }
                    else if ((dtpDateFrom.Value - dtpDateTo.Value).TotalDays > 30)
                    {
                        throw new Exception("Выбран слишком большой период. Разница между датами периода\"с\" и \"по\" не должна превышать 30 дней.");
                    }
                    else
                    {
                        DateFrom = dtpDateFrom.Value;
                        DateTo = dtpDateTo.Value;
                    }
                }
                else
                {
                    DateFrom = null;
                    DateTo = null;
                }

                if (chkbItemID.Checked)
                {
                    int tmp = 0;
                    if (!int.TryParse(tbItemID.Text, out tmp) || tmp <= 0)
                    {
                        throw new Exception("Код товара введен некорректно.");
                    }
                    else
                    {
                        ItemID = tmp;
                    }
                }
                else
                {
                    ItemID = null;
                }

                if (chkbItemName.Checked)
                {
                    if (tbItemName.Text != null && tbItemName.Text.Length < 3)
                    {
                        throw new Exception("Наименование товара должно состоять минимум из 3-х букв.");
                    }
                    else
                    {
                        ItemName = string.IsNullOrEmpty(tbItemName.Text) ? null : tbItemName.Text;
                    }
                }
                else
                {
                    ItemName = null;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        #endregion


        #region Enum CalculationSearchType

        /// <summary>
        /// Содержит возможные варианты поиска (передается в хранимую процедуру).
        /// </summary>
        public enum CalculationSearchType
        {
            /// <summary>
            /// По номеру претензии (1).
            /// </summary>
            Complaint = 1,
            /// <summary>
            /// По номеру расчет-корректировки (2).
            /// </summary>
            Calculation = 2,
            /// <summary>
            /// По номеру служебной записки (3).
            /// </summary>
            Memo = 3,
            /// <summary>
            /// По номеру оригинальной накладной (4).
            /// </summary>
            Invoice = 4,
            /// <summary>
            /// По коду адреса доставки или головного дебитора (5).
            /// </summary>
            AddressCode = 5,
        }

        #endregion
    }
}
