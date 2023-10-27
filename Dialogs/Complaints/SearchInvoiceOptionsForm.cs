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
    /// Диалог для ввода параметров поиска строк заказа (накладной).
    /// </summary>
    public partial class SearchInvoiceOptionsForm : Form
    {
        /// <summary>
        /// Инициализирует новый экземпляр диалога.
        /// </summary>
        /// <param name="searchByInnerDocNumberOnly">Признак, определяющий возможность поиска только по номеру внутреннего документа.</param>
        /// <param name="canSearchByOrderNumber">Признак, показывающий, может ли пользователь делать поиск по номеру заказа.</param>
        /// <param name="defaultOrderType">Тип заказа по умолчанию.</param>
        /// <param name="defaultInvoiceType">Тип накладной по умолчанию.</param>
        /// <param name="docTypeID">Тип претензии.</param>
        public SearchInvoiceOptionsForm(bool searchByInnerDocNumberOnly, bool canSearchByOrderNumber, string defaultOrderType, string defaultInvoiceType, string defaultInnerDocType, string docTypeID)
        {
            InitializeComponent();

            // Режим поиска по внутреннему документу
            if (searchByInnerDocNumberOnly)
            {
                rbSearchByInnerDocNumber.Enabled = true;
                rbSearchByInnerDocNumber.Checked = true;

                rbSearchByOrderNumber.Checked = false;
                rbSearchByOrderNumber.Enabled = false;

                rbSearchByInvoiceNumber.Checked = false;
                rbSearchByInvoiceNumber.Enabled = false;

                rbSearchByPeriod.Checked = false;
                rbSearchByPeriod.Enabled = false;
            }
            else
            {
                if (canSearchByOrderNumber)
                {
                    rbSearchByOrderNumber.Checked = true;
                }
                else
                {
                    rbSearchByOrderNumber.Enabled = false;
                    rbSearchByInvoiceNumber.Checked = true;
                }

                // [GSPO-3695]
                if (docTypeID == ComplaintsConstants.ComplaintDocTypeCancellation)
                {
                    rbSearchByOrderNumber.Enabled = true;
                    rbSearchByOrderNumber.Checked = true;

                    rbSearchByInvoiceNumber.Checked = false;
                    rbSearchByInvoiceNumber.Enabled = false;
                }
                else if (docTypeID != ComplaintsConstants.ComplaintDocTypeResignInvoice)
                {
                    rbSearchByPeriod.Checked = false;
                    rbSearchByPeriod.Enabled = false;

                    dtpPeriodFrom.Checked = false;
                    dtpPeriodTo.Checked = false;
                }
            }

            tbOrderType.Text = defaultOrderType;
            
            tbInvoiceType.Text = defaultInvoiceType;
            tbInvoiceType.Enabled = docTypeID != ComplaintsConstants.ComplaintDocTypeResignInvoice;

            tbInnerDocType.Text = defaultInnerDocType;

            dtpPeriodFrom.Value = DateTime.Today.AddDays(-7);
            dtpPeriodTo.Value = DateTime.Today;
        }

        /// <summary>
        /// Возвращает выбранный пользователем тип поиска.
        /// </summary>
        public SearchType SelectedSearchType
        {
            get { return (rbSearchByOrderNumber.Checked 
                            ? SearchType.ByOrderNumber 
                            : rbSearchByInvoiceNumber.Checked 
                                ? SearchType.ByInvoiceNumber 
                                : rbSearchByInnerDocNumber.Checked
                                    ? SearchType.ByInnerDocNumber
                                    : SearchType.ByPeriod); }
        }

        /// <summary>
        /// Возвращает введенный пользователем тип заказа.
        /// </summary>
        public string OrderType
        {
            get { return (rbSearchByOrderNumber.Checked ? tbOrderType.Text : null); }
        }

        /// <summary>
        /// Возвращает введенный пользователем номер заказа.
        /// </summary>
        public int? OrderNumber
        {
            get { return (rbSearchByOrderNumber.Checked ? Convert.ToInt32(tbOrderNumber.Text) : (int?)null); }
        }

        /// <summary>
        /// Возвращает введенный пользователем тип накладной.
        /// </summary>
        public string InvoiceType
        {
            get { return (rbSearchByInvoiceNumber.Checked ? tbInvoiceType.Text : null); }
        }

        /// <summary>
        /// Возвращает введенный пользователем номер накладной.
        /// </summary>
        public int? InvoiceNumber
        {
            get { return (rbSearchByInvoiceNumber.Checked ? Convert.ToInt32(tbInvoiceNumber.Text) : (int?)null); }
        }

        /// <summary>
        /// Возвращает введенный пользователем тип внутреннего документа.
        /// </summary>
        public string InnerDocType
        {
            get { return (rbSearchByInnerDocNumber.Checked ? tbInnerDocType.Text : null); }
        }

        /// <summary>
        /// Возвращает введенный пользователем номер внутреннего документа.
        /// </summary>
        public int? InnerDocNumber
        {
            get { return (rbSearchByInnerDocNumber.Checked ? Convert.ToInt32(tbInnerDocNumber.Text) : (int?)null); }
        }

        /// <summary>
        /// Возвращает введеный пользователем период с
        /// </summary>
        public DateTime? PeriodFrom
        {
            get { return (rbSearchByPeriod.Checked && dtpPeriodFrom.Checked ? dtpPeriodFrom.Value.Date : (DateTime?)null); }
        }

        /// <summary>
        /// Возвращает введеный пользователем период по
        /// </summary>
        public DateTime? PeriodTo
        {
            get { return (rbSearchByPeriod.Checked && dtpPeriodTo.Checked ? dtpPeriodTo.Value.Date : (DateTime?)null); }
        }

        /// <summary>
        /// Обрабатывает момент первого отображения диалога.
        /// </summary>
        private void SearchInvoiceOptionsForm_Shown(object sender, EventArgs e)
        {
            InitializeSearchMode();
        }

        private void InitializeSearchMode()
        {
            if (rbSearchByOrderNumber.Checked)
            {
                tbOrderType.Focus();
            }
            else if (rbSearchByInvoiceNumber.Checked)
            {
                if (tbInvoiceType.Enabled)
                    tbInvoiceType.Focus();
                else
                    tbInvoiceNumber.Focus();
            }
            else if (rbSearchByInnerDocNumber.Checked)
            {
                tbInnerDocType.Focus();
            }
            else if (rbSearchByPeriod.Checked)
            {
                dtpPeriodFrom.Focus();
            }
        }

        /// <summary>
        /// Меняет доступность элементов управления при изменении выбора типа поиска радиокнопками.
        /// </summary>
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            gbSearchByOrderNumber.Enabled = rbSearchByOrderNumber.Checked;
            gbSearchByInvoiceNumber.Enabled = rbSearchByInvoiceNumber.Checked;
            gbSearchByInnerDocNumber.Enabled = rbSearchByInnerDocNumber.Checked;
            gbSearchByPeriod.Enabled = rbSearchByPeriod.Checked;

            if ((sender as RadioButton).Checked)
                InitializeSearchMode();
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "ОК".
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (rbSearchByOrderNumber.Checked)
            {
                if (string.IsNullOrEmpty(tbOrderType.Text))
                {
                    MessageBox.Show("Не введен тип заказа!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int tmp = 0;
                if (!int.TryParse(tbOrderNumber.Text, out tmp))
                {
                    MessageBox.Show("Не введен номер заказа!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (rbSearchByInvoiceNumber.Checked)
            {
                if (tbInvoiceType.Enabled && string.IsNullOrEmpty(tbInvoiceType.Text))
                {
                    MessageBox.Show("Не введен тип накладной!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int tmp = 0;
                if (!int.TryParse(tbInvoiceNumber.Text, out tmp))
                {
                    MessageBox.Show("Не введен номер накладной!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (rbSearchByInnerDocNumber.Checked)
            {
                if (string.IsNullOrEmpty(tbInnerDocType.Text))
                {
                    MessageBox.Show("Не введен тип внутреннего документа!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int tmp = 0;
                if (!int.TryParse(tbInnerDocNumber.Text, out tmp))
                {
                    MessageBox.Show("Не введен номер внутреннего документа!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            else if (rbSearchByPeriod.Checked)
            {
                if (!dtpPeriodFrom.Checked && !dtpPeriodTo.Checked)
                {
                    MessageBox.Show("Не выбран период!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (dtpPeriodFrom.Checked && dtpPeriodTo.Checked && dtpPeriodTo.Value.Date < dtpPeriodFrom.Value.Date)
                {
                    MessageBox.Show("Дата \"с\" не должна превышать дату \"по\"!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Список типов поиска заказа (накладной).
        /// </summary>
        public enum SearchType
        {
            /// <summary>
            /// Поиск по типу и номеру заказа (0).
            /// </summary>
            ByOrderNumber = 0,
            /// <summary>
            /// Поиск по типу и номеру накладной (1).
            /// </summary>
            ByInvoiceNumber = 1,
            /// <summary>
            /// Поиск по типу и номеру внутреннего документа (2).
            /// </summary>
            ByInnerDocNumber = 2,
            /// <summary>
            /// Поиск по периоду(3).
            /// </summary>
            ByPeriod = 3
        }
    }
}
