using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs
{
    /// <summary>
    /// Диалог для ввода параметров поиска документа.
    /// </summary>
    public partial class SearchDocOptionsForm : Form
    {
        /// <summary>
        /// Предыдущий выбранный пользователем режим РН/ТТН
        /// </summary>
        private static bool LastWaybillModeEnabled { get; set; }

        /// <summary>
        /// Предыдущий выбранный пользователем тип поиска.
        /// </summary>
        private static SearchType LastSearchType { get; set; }
        /// <summary>
        /// Предыдущий введенный пользователем номер заказа.
        /// </summary>
        private static int? LastOrderNumber { get; set; }
        /// <summary>
        /// Предыдущий введенный пользователем номер накладной.
        /// </summary>
        private static int? LastInvoiceNumber { get; set; }
        /// <summary>
        /// Предыдущий введенный пользователем код дебитора.
        /// </summary>
        private static int? LastDebtorID { get; set; }

        /// <summary>
        /// Предыдущий введенный пользователем код адреса доставки
        /// </summary>
        private static int? LastAddressID { get; set; }

        /// <summary>
        /// Предыдущая введенная пользователем дата "с".
        /// </summary>
        private static DateTime? LastDateFrom { get; set; }
        /// <summary>
        /// Предыдущая введенная пользователем дата "по".
        /// </summary>
        private static DateTime? LastDateTo { get; set; }

        /// <summary>
        /// Предыдущий введенный пользователем номер марш. листа (для режима поиска по марш. листу)
        /// </summary>
        private static int? LastRouteListNumber { get; set; }

        /// <summary>
        /// Предыдущий введенный пользователем код адреса доставки (для режима поиска по марш. листу)
        /// </summary>
        private static int? LastDeliveryCode { get; set; }


        public static int? CurrentRouteListNumber { get { return LastRouteListNumber; } }

        /// <summary>
        /// Предыдущая введенная пользователем дата "с". (для режима поиска по марш. листу)
        /// </summary>
        private static DateTime? LastWaybillDateFrom { get; set; }

        /// <summary>
        /// Предыдущая введенная пользователем дата "по". (для режима поиска по марш. листу)
        /// </summary>
        private static DateTime? LastWaybillDateTo { get; set; }

        /// <summary>
        /// Статический конструктор класса SearchDocOptionsForm - инициализация статических свойств.
        /// </summary>
        static SearchDocOptionsForm()
        {
            Initialize();
        }

        /// <summary>
        /// Инициализирует новый экземпляр диалога.
        /// </summary>
        public SearchDocOptionsForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            tbOrderNumber.Text = LastOrderNumber.HasValue ? LastOrderNumber.Value.ToString() : string.Empty;
            tbInvoiceNumber.Text = LastInvoiceNumber.HasValue ? LastInvoiceNumber.Value.ToString() : string.Empty;
            tbDebtorID.Text = LastDebtorID.HasValue ? LastDebtorID.Value.ToString() : string.Empty;
            tbAddressCode.Text = LastAddressID.HasValue ? LastAddressID.Value.ToString() : String.Empty;
            dtpDateFrom.Value = LastDateFrom.HasValue ? LastDateFrom.Value : DateTime.Today;
            dtpDateTo.Value = LastDateTo.HasValue ? LastDateTo.Value : DateTime.Today;
            tbRouteNumber.Text = LastRouteListNumber.HasValue ? LastRouteListNumber.ToString() : string.Empty;
            tbDeliveryCode.Text = LastDeliveryCode.HasValue ? LastDeliveryCode.Value.ToString() : string.Empty;
            dtpWaybillDateFrom.Value = LastWaybillDateFrom.HasValue ? LastWaybillDateFrom.Value : DateTime.Today;
            dtpWaybillDateTo.Value = LastWaybillDateTo.HasValue ? LastWaybillDateTo.Value : DateTime.Today;

            if (LastWaybillModeEnabled)
            {
                rbSearchByOrderNumber.Enabled = false;
                rbSearchByDebtor.Enabled = false;
            }
            else
            {
                rbSearchByRoute.Enabled = false;
            }

            switch (LastSearchType)
            {
                case SearchType.ByOrderNumber:
                    rbSearchByOrderNumber.Checked = true;
                    break;
                case SearchType.ByInvoiceNumber:
                    rbSearchByInvoiceNumber.Checked = true;
                    break;
                case SearchType.ByDebtor:
                    rbSearchByDebtor.Checked = true;
                    break;
                case SearchType.ByRoute:
                    rbSearchByRoute.Checked = true;
                    break;
                default:
                    rbSearchByOrderNumber.Checked = true;
                    break;
            }
        }

        private static void Initialize()
        {
            Initialize(false);
        }

        public static void Initialize(bool isWaybillModeEnabled)
        {
            LastWaybillModeEnabled = isWaybillModeEnabled;
            LastSearchType = isWaybillModeEnabled ? SearchType.ByRoute : SearchType.ByOrderNumber;

            LastOrderNumber = (int?)null;
            LastInvoiceNumber = (int?)null;
            LastDebtorID = (int?)null;
            LastAddressID = (int?)null;
            LastDateFrom = (DateTime?)null;
            LastDateTo = (DateTime?)null;
            LastRouteListNumber = (int?)null;
            LastDeliveryCode = (int?)null;
            LastWaybillDateFrom = (DateTime?)null;
            LastWaybillDateTo = (DateTime?)null;
        }

        /// <summary>
        /// Возвращает выбранный пользователем тип поиска.
        /// </summary>
        public SearchType SelectedSearchType
        {
            get { return (rbSearchByOrderNumber.Checked ? SearchType.ByOrderNumber : (rbSearchByInvoiceNumber.Checked ? SearchType.ByInvoiceNumber : (rbSearchByDebtor.Checked ? SearchType.ByDebtor : SearchType.ByRoute))); }
        }

        /// <summary>
        /// Возвращает введенный пользователем номер заказа.
        /// </summary>
        public int? OrderNumber
        {
            get { return (rbSearchByOrderNumber.Checked ? Convert.ToInt32(tbOrderNumber.Text) : (int?)null); }
        }

        /// <summary>
        /// Возвращает введенный пользователем номер накладной.
        /// </summary>
        public int? InvoiceNumber
        {
            get { return (rbSearchByInvoiceNumber.Checked ? Convert.ToInt32(tbInvoiceNumber.Text) : (int?)null); }
        }

        /// <summary>
        /// Возвращает введенный пользователем код дебитора.
        /// </summary>
        public int? DebtorID
        {
            get
            {
                int id;
                if (Int32.TryParse(tbDebtorID.Text, out id) && id != 0)
                    return id;
                else
                    return null;
            }
        }

        /// <summary>
        /// Возвращает введенный пользователем код доставки
        /// </summary>
        public int? AddressID
        {
            get
            {
                int id;
                if (Int32.TryParse(tbAddressCode.Text, out id) && id != 0)
                    return id;
                else
                    return null;
            }
        }

        /// <summary>
        /// Возвращает введенную пользователем дату "с".
        /// </summary>
        public DateTime? DateFrom
        {
            get { return (rbSearchByDebtor.Checked ? dtpDateFrom.Value : (DateTime?)null); }
        }

        /// <summary>
        /// Возвращает введенную пользователем дату "по".
        /// </summary>
        public DateTime? DateTo
        {
            get { return (rbSearchByDebtor.Checked ? dtpDateTo.Value : (DateTime?)null); }
        }

        /// <summary>
        /// Возвращает введенный пользователем номер марш. листа (для режима поиска по марш. листу)
        /// </summary>
        public int? RouteListNumber
        {
            get 
            {
                if (rbSearchByRoute.Checked)
                {
                    int route;
                    if (Int32.TryParse(tbRouteNumber.Text, out route) && route != 0)
                        return route;
                }

                return null;
            }
        }

        /// <summary>
        /// Возвращает введенный пользователем код доставки (для режима поиска по марш. листу)
        /// </summary>
        public int? DeliveryCode
        {
            get
            {
                if (rbSearchByRoute.Checked)
                {
                    int code;
                    if (!string.IsNullOrEmpty(tbDeliveryCode.Text) && Int32.TryParse(tbDeliveryCode.Text, out code) && code != 0)
                        return code;
                }

                return null;
            }
        }

        /// <summary>
        /// Возвращает введенную пользователем дату "с". (для режима поиска по марш. листу)
        /// </summary>
        public DateTime? WaybillDateFrom
        {
            get { return (rbSearchByRoute.Checked ? dtpWaybillDateFrom.Value : (DateTime?)null); }
        }

        /// <summary>
        /// Возвращает введенную пользователем дату "по". (для режима поиска по марш. листу)
        /// </summary>
        public DateTime? WaybillDateTo
        {
            get { return (rbSearchByRoute.Checked ? dtpWaybillDateTo.Value : (DateTime?)null); }
        }

        /// <summary>
        /// Меняет доступность элементов управления при изменении выбора типа поиска радиокнопками.
        /// </summary>
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (gbSearchByOrderNumber.Enabled = rbSearchByOrderNumber.Checked)
            {
                tbOrderNumber.Focus();
                tbOrderNumber.SelectAll();
            }

            if (gbSearchByInvoiceNumber.Enabled = rbSearchByInvoiceNumber.Checked)
            {
                tbInvoiceNumber.Focus();
                tbInvoiceNumber.SelectAll();
            }

            if (gbSearchByDebtor.Enabled = rbSearchByDebtor.Checked)
            {
                tbDebtorID.Focus();
                tbDebtorID.SelectAll();
            }

            if (gbSearchByRoute.Enabled = rbSearchByRoute.Checked)
            {
                tbRouteNumber.Focus();
                tbRouteNumber.SelectAll();
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "ОК".
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (rbSearchByOrderNumber.Checked)
            {
                int tmp = 0;
                if (!int.TryParse(tbOrderNumber.Text, out tmp) || tmp == 0)
                {
                    MessageBox.Show("Не введен номер заказа!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                LastSearchType = SearchType.ByOrderNumber;
                LastOrderNumber = OrderNumber;
            }
            else if (rbSearchByInvoiceNumber.Checked)
            {
                int tmp = 0;
                if (!int.TryParse(tbInvoiceNumber.Text, out tmp) || tmp == 0)
                {
                    MessageBox.Show("Не введен номер накладной!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                LastSearchType = SearchType.ByInvoiceNumber;
                LastInvoiceNumber = InvoiceNumber;
            }
            else if (rbSearchByDebtor.Checked)
            {
                int tmp = 0, tmp1 = 0;
                if ((!int.TryParse(tbDebtorID.Text, out tmp) || tmp == 0) && (!int.TryParse(tbAddressCode.Text, out tmp1) || tmp1 == 0))
                {
                    MessageBox.Show("Нужно ввести код дебитора и/или код доставки!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (dtpDateFrom.Value > dtpDateTo.Value)
                {
                    MessageBox.Show("Дата \"с\" должна быть меньше или равна дате \"по\"!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if ((dtpDateTo.Value - dtpDateFrom.Value).TotalDays > 31)
                {
                    MessageBox.Show("Допустимый диапазон дат - не более 31 дня!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                LastSearchType = SearchType.ByDebtor;
                LastDebtorID = tmp;
                LastDateFrom = DateFrom;
                LastDateTo = DateTo;
            }
            else if (rbSearchByRoute.Checked)
            {
                int route = 0;
                //if (!string.IsNullOrEmpty(tbRouteNumber.Text) && !int.TryParse(tbRouteNumber.Text, out route) || route == 0)
                //{
                //    MessageBox.Show("Не введен номер марш. листа!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

                int code = 0;
                //if (!string.IsNullOrEmpty(tbDeliveryCode.Text) && (!int.TryParse(tbDeliveryCode.Text, out code) || code == 0))
                //{
                //    MessageBox.Show("Не введен код доставки!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

                if ((!int.TryParse(tbRouteNumber.Text, out route) || route == 0) && (!int.TryParse(tbDeliveryCode.Text, out code) || code == 0))
                {
                    MessageBox.Show("Нужно ввести номер марш. листа и/или код доставки!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (dtpWaybillDateFrom.Value > dtpWaybillDateTo.Value)
                {
                    MessageBox.Show("Дата \"с\" должна быть меньше или равна дате \"по\"!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if ((dtpWaybillDateTo.Value - dtpWaybillDateFrom.Value).TotalDays > 31)
                {
                    MessageBox.Show("Допустимый диапазон дат - не более 31 дня!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                LastSearchType = SearchType.ByRoute;
                LastRouteListNumber = RouteListNumber;
                LastDeliveryCode = DeliveryCode;
                LastWaybillDateFrom = WaybillDateFrom;
                LastWaybillDateTo = WaybillDateTo;

            }

            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Содержит типы поиска документов.
        /// </summary>
        public enum SearchType
        {
            /// <summary>
            /// Поиск по номеру заказа (1).
            /// </summary>
            ByOrderNumber = 1,
            /// <summary>
            /// Поиск по номеру накладной (2).
            /// </summary>
            ByInvoiceNumber = 2,
            /// <summary>
            /// Поиск по коду дебитора и диапазону дат (3).
            /// </summary>
            ByDebtor = 3,
            /// <summary>
            /// Поиск по номеру марш. листа (4).
            /// </summary>
            ByRoute = 4
        }
    }
}
