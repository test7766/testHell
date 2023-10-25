using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Quality
{
    public partial class MedicinesRegistrySearchForm : DialogForm
    {
        private const int FILTER_PARAMETERS_COUNT = 16;
        private const string ERROR_CAPTION = "Ошибка задания элементов фильтра";

        /// <summary>
        /// Предыдущий выбранный пользователем тип поиска.
        /// </summary>
        private static SearchType lastSearchType;
        /// <summary>
        /// Предыдущий введенный пользователем номер заказа.
        /// </summary>
        private static string lastOrderNumber;
        /// <summary>
        /// Предыдущий введенный пользователем код поставщика.
        /// </summary>
        private static string lastSupplierCode;
        /// <summary>
        /// Предыдущая введенная пользователем дата "с".
        /// </summary>
        private static DateTime lastStartDate;
        /// <summary>
        /// Предыдущая введенная пользователем дата "по".
        /// </summary>
        private static DateTime lastEndDate;
        /// <summary>
        /// Предыдущая введенная пользователем внешняя дата "с".
        /// </summary>
        private static DateTime lastInternalStartDate;
        /// <summary>
        /// Предыдущая введенная пользователем внешняя дата "по".
        /// </summary>
        private static DateTime lastInternalEndDate;
        /// <summary>
        /// Предыдущий введенный пользователем код товара.
        /// </summary>
        private static string lastDrugCode;
        /// <summary>
        /// Предыдущая введенная пользователем серия товара.
        /// </summary>
        private static string lastVendorLot;

        /// <summary>
        /// Предыдущий введенный пользователем код товара (в разделе разрешений)
        /// </summary>
        private static string lastQualityItemID;

        /// <summary>
        /// Предыдущая введенная пользователем серия (в разделе разрешений)
        /// </summary>
        private static string lastQualityVendorLot;

        /// <summary>
        /// Предыдущий введенный пользователем код поставщика (в разделе разрешений)
        /// </summary>
        private static string lastQualityVendorID;

        /// <summary>
        /// Предыдущая введенная пользователем "дата с" (в разделе разрешений)
        /// </summary>
        private static DateTime? lastQualityDateFrom;

        /// <summary>
        /// Предыдущая введенная пользователем "дата по" (в разделе разрешений)
        /// </summary>
        private static DateTime? lastQualityDateTo;

        /// <summary>
        /// Предыдущее значения фильтра по "разрешенности в продажу" (в разделе разрешений)
        /// </summary>
        private static int lastPermittedFilter;

        /// <summary>
        /// Предыдущее значения фильтра "Партия" (в разделе разрешений)
        /// </summary>
        private static string lastLotNumber;

        /// <summary>
        /// Предыдущее значения фильтра "№ накл. поставки" (в разделе разрешений)
        /// </summary>
        private static string lastInvoiceNumber;

        /// <summary>
        /// Статический конструктор класса MedicinesRegistrySearchForm - инициализация статических свойств.
        /// </summary>
        static MedicinesRegistrySearchForm()
        {
            lastSearchType = SearchType.ByOrderNumber;
            lastOrderNumber = string.Empty;
            lastSupplierCode = string.Empty;
            lastStartDate = lastEndDate = DateTime.Now;
            lastInternalStartDate = lastInternalEndDate = DateTime.Now;
            lastDrugCode = string.Empty;
            lastVendorLot = string.Empty;
            lastQualityItemID = lastQualityVendorLot = lastQualityVendorID = String.Empty;
            lastQualityDateFrom = lastQualityDateTo = null;
            lastLotNumber = null;
            lastInvoiceNumber = null;
        }

        public MedicinesRegistrySearchForm()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.None;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.SetInterfaceSettings();
            this.ApplyLastFilterSettings();
        }

        private void SetInterfaceSettings()
        {
            this.btnOK.Location = new Point(272, 8);
            this.btnCancel.Location = new Point(362, 8);
        }

        private void ApplyLastFilterSettings()
        {
            switch (lastSearchType)
            {
                case SearchType.ByOrderNumber:
                    rbOrderNumber.Checked = true;
                    break;
                case SearchType.BySupplierCode:
                    rbSupplierCode.Checked = true;
                    break;
                case SearchType.ByInternalDate:
                    rbInternalDate.Checked = true;
                    break;
                case SearchType.ByDrugs:
                    rbDrugsCode.Checked = true;
                    break;
                case SearchType.ByQualityPermission:
                    rbQualityInfo.Checked = true;
                    break;
                default:
                    rbOrderNumber.Checked = true;
                    break;
            }

            tbOrderNumber.Text = lastOrderNumber;
            tbSupplierCode.Text = lastSupplierCode;
            dtStartDate.Value = lastStartDate;
            dtEndDate.Value = lastEndDate;
            dtInternalStartDate.Value = lastInternalStartDate;
            dtInternalEndDate.Value = lastInternalEndDate;
            tbDrugsCode.Text = lastDrugCode;
            tbVendorLot.Text = lastVendorLot;
            tbxQualityItemID.Text = lastQualityItemID;
            tbxQualityVendorLot.Text = lastQualityVendorLot;
            tbxQualityVendorID.Text = lastQualityVendorID;
            dtpQualityDateFrom.Value = lastQualityDateFrom.HasValue ? lastQualityDateFrom.Value : DateTime.Now;
            dtpQualityDateTo.Value = lastQualityDateTo.HasValue ? lastQualityDateTo.Value : DateTime.Now;
            if (lastPermittedFilter == 0)
                rbtAll.Checked = true;
            else if (lastPermittedFilter == 1)
                rbtPermitted.Checked = true;
            else
                rbtNotPermitted.Checked = true;

            tbLotNumber.Text = lastLotNumber;
            tbVendorInvoice.Text = lastInvoiceNumber;
        }

        public int SearchTypeCode { get; private set; }
        public List<object> GetParametersFromFilter()
        {
            List<object> parameters = new List<object>(FILTER_PARAMETERS_COUNT);

            // проинилициализируем параметрами null-значениями
            for (int i = 0; i < parameters.Capacity; i++)
                parameters.Add(null);

            // фильтр задан по номеру накладной
            if (rbOrderNumber.Checked)
                parameters[0] = lastOrderNumber;

            // фильтр задан по коду поставщика
            if (rbSupplierCode.Checked)
            {
                parameters[1] = lastSupplierCode;
                parameters[2] = lastStartDate;
                parameters[3] = lastEndDate;
            }

            // фильтр задан по внешней дате
            if (rbInternalDate.Checked)
            {
                parameters[4] = lastInternalStartDate;
                parameters[5] = lastInternalEndDate;
            }

            // фильтр задан по коду/серии товара
            if (rbDrugsCode.Checked)
            {
                parameters[6] = lastDrugCode;
                parameters[7] = lastVendorLot;
            }

            // фильтр задан по разрешениям на реализацию
            if (rbQualityInfo.Checked)
            {
                parameters[8] = lastQualityItemID;
                parameters[9] = lastQualityVendorLot;
                parameters[10] = lastQualityVendorID;
                parameters[11] = chbQualityDateFilter.Checked ? (DateTime?)lastQualityDateFrom : null;
                parameters[12] = chbQualityDateFilter.Checked ? (DateTime?)lastQualityDateTo : null;
                parameters[13] = lastPermittedFilter;
                parameters[14] = String.IsNullOrEmpty(lastLotNumber) ? null : lastLotNumber;
                parameters[15] = String.IsNullOrEmpty(lastInvoiceNumber) ? null : lastInvoiceNumber;
            }

            return parameters;
        }

        private void rbMainFilterItem_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rbSearchElement = sender as RadioButton;

            if (rbSearchElement != null && rbSearchElement.Checked)
            {
                pnlOrder.Enabled = false;
                pnlSupplier.Enabled = false;
                pnlInternalDate.Enabled = false;
                pnlDrugs.Enabled = false;
                pnlQualityInfo.Enabled = false;

                // Элемент фильтра -- номер накладной
                if (rbSearchElement.Name == rbOrderNumber.Name)
                {
                    pnlOrder.Enabled = true;
                    tbOrderNumber.Focus();
                    return;
                }

                // Элемент фильтра -- код поставщика
                if (rbSearchElement.Name == rbSupplierCode.Name)
                {
                    pnlSupplier.Enabled = true;
                    tbSupplierCode.Focus();
                    return;
                }

                // Элемент фильтра -- внешние даты
                if (rbSearchElement.Name == rbInternalDate.Name)
                {
                    pnlInternalDate.Enabled = true;
                    dtInternalStartDate.Focus();
                    return;
                }

                // Элемент фильтра -- код/серия товара
                if (rbSearchElement.Name == rbDrugsCode.Name)
                {
                    pnlDrugs.Enabled = true;
                    tbDrugsCode.Focus();
                    return;
                }

                // Элемент фильтра -- разрешения на реализацию
                if (rbSearchElement.Name == rbQualityInfo.Name)
                {
                    pnlQualityInfo.Enabled = true;
                    tbxQualityItemID.Focus();
                    return;
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ApplyOperation(DialogResult.OK);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ApplyOperation(DialogResult.Cancel);
        }

        /// <summary>
        /// Выполнить запрашиваемую операцию согласно ожидаемого результата - статуса диалогового окна
        /// </summary>
        /// <param name="agreedResult"></param>
        private void ApplyOperation(DialogResult agreedResult)
        {
            this.DialogResult = agreedResult;
            this.Close();
        }

        private void AllowOnlyNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void FilterTextItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ApplyOperation(DialogResult.OK);
        }

        private void tbDrugsCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                tbVendorLot.Focus();
        }

        private void MedicinesRegistrySearchForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !ValidateFilterSettings();
        }

        private bool ValidateFilterSettings()
        {
            // Выбран фильтр по номеру заказа
            if (rbOrderNumber.Checked)
            {
                if (tbOrderNumber.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Номер заказа не может быть пустым.", ERROR_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbOrderNumber.Focus();
                    tbOrderNumber.SelectAll();
                    return false;
                }

                lastSearchType = SearchType.ByOrderNumber;
                this.SearchTypeCode = (int)lastSearchType;
                lastOrderNumber = tbOrderNumber.Text.Trim();
            }

            // Выбран фильтр по коду поставщика
            if (rbSupplierCode.Checked)
            {
                // Валидация кода поставщшика
                if (tbSupplierCode.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Код поставщика не может быть пустым.", ERROR_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbSupplierCode.Focus();
                    tbSupplierCode.SelectAll();
                    return false;
                }

                // Валидация диапазона дат
                if (dtStartDate.Value > dtEndDate.Value)
                {
                    MessageBox.Show("Начальная дата не должна превышать конечную.", ERROR_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtStartDate.Focus();
                    return false;
                }

                lastSearchType = SearchType.BySupplierCode;
                this.SearchTypeCode = (int)lastSearchType;
                lastSupplierCode = tbSupplierCode.Text.Trim();
                lastStartDate = dtStartDate.Value;
                lastEndDate = dtEndDate.Value;
            }

            // Выбран фильтр по внешним датам
            if (rbInternalDate.Checked)
            {
                if (dtInternalStartDate.Value > dtInternalEndDate.Value)
                {
                    MessageBox.Show("Начальная дата не должна превышать конечную.", ERROR_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtInternalStartDate.Focus();
                    return false;
                }

                lastSearchType = SearchType.ByInternalDate;
                this.SearchTypeCode = (int)lastSearchType;
                lastInternalStartDate = dtInternalStartDate.Value;
                lastInternalEndDate = dtInternalEndDate.Value;
            }

            // Выбран фильтр по коду/серии товара
            if (rbDrugsCode.Checked)
            {
                if (tbDrugsCode.Text.Trim() == string.Empty && tbVendorLot.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Хотя бы один из параметров товара должен быть указан.", ERROR_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbDrugsCode.Focus();
                    return false;
                }

                lastSearchType = SearchType.ByDrugs;
                this.SearchTypeCode = (int)lastSearchType;
                lastDrugCode = tbDrugsCode.Text.Trim();
                lastVendorLot = tbVendorLot.Text.Trim();
            }

            // Выбран фильтр по разрешениям на реализацию
            if (rbQualityInfo.Checked)
            {
                int id;
                if (!String.IsNullOrEmpty(tbxQualityItemID.Text) && !Int32.TryParse(tbxQualityItemID.Text, out id))
                {
                    MessageBox.Show("Код товара должен быть целым числом!", ERROR_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbxQualityItemID.Focus();
                    return false;
                }
                else if (!String.IsNullOrEmpty(tbxQualityVendorID.Text) && !Int32.TryParse(tbxQualityVendorID.Text, out id))
                {
                    MessageBox.Show("Код поставщика должен быть целым числом!", ERROR_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbxQualityVendorID.Focus();
                    return false;
                }
                else if (dtpQualityDateFrom.Value > dtpQualityDateTo.Value)
                {
                    MessageBox.Show("Начальная дата не должна превышать конечную!", ERROR_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtpQualityDateFrom.Focus();
                    return false;
                }

                lastSearchType = SearchType.ByQualityPermission;
                SearchTypeCode = (int)lastSearchType;
                lastQualityItemID = tbxQualityItemID.Text;
                lastQualityVendorLot = tbxQualityVendorLot.Text;
                lastQualityVendorID = tbxQualityVendorID.Text;
                lastQualityDateFrom = chbQualityDateFilter.Checked ? (DateTime?)dtpQualityDateFrom.Value : null;
                lastQualityDateTo = chbQualityDateFilter.Checked ? (DateTime?)dtpQualityDateTo.Value : null;
                
                if (rbtAll.Checked)
                    lastPermittedFilter = 0;
                else if (rbtPermitted.Checked)
                    lastPermittedFilter = 1;
                else
                    lastPermittedFilter = 2;

                lastInvoiceNumber = String.IsNullOrEmpty(tbVendorInvoice.Text) ? null : tbVendorInvoice.Text;
                lastLotNumber = String.IsNullOrEmpty(tbLotNumber.Text) ? null : tbLotNumber.Text;
            }

            return true;
        }

        /// <summary>
        /// Настройка доступности/недоступности фильтров по датам с помощью флажка
        /// </summary>
        private void chbQualityDateFilter_CheckedChanged(object sender, EventArgs e)
        {
            lblQualityDateFrom.Enabled = lblQualityDateTo.Enabled =
                dtpQualityDateFrom.Enabled = dtpQualityDateTo.Enabled = lblQualityDateTo.Enabled = chbQualityDateFilter.Checked;
        }

        ///<summary>
        /// Содержит типы поиска реестра.
        ///</summary>
        public enum SearchType
        {
            /// <summary>
            /// Поиск по номеру заказа (1).
            /// </summary>
            ByOrderNumber = 1,
            /// <summary>
            /// Поиск по коду поставщика (2).
            /// </summary>
            BySupplierCode = 2,

            /// <summary>
            /// Поиск по диапазону дат (4)
            /// </summary>
            ByInternalDate = 3,

            /// <summary>
            /// Поиск по коду товара и серии (3)
            /// </summary>
            ByDrugs = 4,

            /// <summary>
            /// Поиск по данным разрешения на реализацию (5)
            /// </summary>
            ByQualityPermission = 5
        }
    }
}
