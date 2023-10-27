using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

using WMSOffice.Classes;
using WMSOffice.Data.QualityTableAdapters;
using System.Globalization;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.IO;

namespace WMSOffice.Dialogs.Quality
{
    /// <summary>
    /// Окно редактирования анкеты входного контроля партии
    /// </summary>
    public partial class EditInputControlLotnWorksheetForm : Form
    {
        #region ОСНОВНЫЕ ПЕРЕМЕННЫЕ И СВОЙСТВА

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private readonly long sessionID;

        /// <summary>
        /// Редактируемая анкета
        /// </summary>
        private readonly Data.Quality.AT_Doc_VersionsRow row;

        /// <summary>
        /// Режим приема товара
        /// </summary>
        private readonly bool inboundMode = false;

        private int? OrderID { get; set; }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ

        public EditInputControlLotnWorksheetForm(long pSessionID, Data.Quality.AT_Doc_VersionsRow pRow, string pOrderID, bool pInboundMode)
        {
            InitializeComponent();
            sessionID = pSessionID;
            row = pRow;
            inboundMode = pInboundMode;
            int orderId = -1;
            if (int.TryParse(pOrderID, out orderId))
                OrderID = orderId;

            InitFields(pOrderID);

            if (!inboundMode)
                tbxCertNumber.Focus();
        }

        /// <summary>
        /// Инициализация текстовых полей окна реквизитами редактируемой анкеты
        /// </summary>
        /// <param name="pOrderID">Номер заказа, в котором находится партия</param>
        private void InitFields(string pOrderID)
        {
            tbxOrderID.Text = pOrderID;
            tbxVendor.Text = row.vendor;
            tbxItemID.Text = row.item_id.ToString();
            tbxLotNumber.Text = row.lot_number;
            tbxDocID.Text = row.doc_id.ToString();
            tbxDocDate.Text = row.doc_date.ToString();
            tbxVersionID.Text = row.version_id.ToString();
            tbxVersionDate.Text = row.version_date.ToString();
            tbxVersionStatus.Text = row.status;
            tbxUser.Text = row.user_FIO;
            tbxCurrentDate.Text = DateTime.Now.ToString();

            // Установка невозможности редактировать поле при наличии блокировки сертификата
            if (!row.Islock_certificateNull() && row.lock_certificate)
                cbHasCertificate.Enabled = false;

            // Установка пользовательского признака наличия сертификата
            if (!row.Ishas_certificateNull())
                cbHasCertificate.Checked = row.has_certificate;

            if (inboundMode)
            {
                lblCertNumber.Visible = lblCertNumber.Enabled = false;
                tbxCertNumber.Visible = tbxCertNumber.Enabled = false;
                lblCertDate.Visible = lblCertDate.Enabled = false;
                tbxCertDate.Visible = tbxCertDate.Enabled = false;
                dtpCertDate.Visible = dtpCertDate.Enabled = false;
                cbHasCertificate.Visible = cbHasCertificate.Enabled = false;
                lblLot_Qty.Visible = lblLot_Qty.Enabled = false;
                tbLot_Qty.Visible = tbLot_Qty.Enabled = false;
                btnScan.Visible = btnScan.Enabled = false;
            }
        }

        /// <summary>
        /// Загрузка уже существующих ответов на вопросы анкеты
        /// </summary>
        private void EditInputControlLotnWorksheetForm_Load(object sender, EventArgs e)
        {
            LoadExistedAnswers();
            LoadCurrentUserName();
            LoadLotnManufacturers();
            LoadTemperatureStorageModes();
            LoadCurrentParameters();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (inboundMode)
                btnOK.Focus();
        }

        /// <summary>
        /// Загрузка ФИО текущего пользователя
        /// </summary>
        private void LoadCurrentUserName()
        {
            try
            {
                using (var adapter = new Users_By_SessionTableAdapter())
                {
                    var userTable = adapter.GetData(sessionID);
                    var row = userTable[0];
                    tbxCurrentUser.Text = String.Format("{0} ({1})", row.Employee, row.Employee_ID);
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время загрузки ФИО текущего пользователя: ", exc);
            }
        }

        /// <summary>
        /// Загрузка производителей по партии
        /// </summary>
        private void LoadLotnManufacturers()
        {
            try
            {
                aT_Lotn_ManufacturersTableAdapter.Fill(quality.AT_Lotn_Manufacturers, row.item_id, sessionID);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка при загрузке производителей по партии!", exc);
            }
        }

        /// <summary>
        /// Загрузка температурных режимов хранения
        /// </summary>
        private void LoadTemperatureStorageModes()
        {
            try
            {
                aT_TemperatureStorageModeTableAdapter.Fill(quality.AT_TemperatureStorageMode, sessionID);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка при загрузке условий хранения!", exc);
            }
        }

        /// <summary>
        /// Загрузка текущих параметров партии (серия, срок годности и т.д.)
        /// </summary>
        private void LoadCurrentParameters()
        {
            try
            {
                using (var adapter = new AT_Current_Lotn_ParamsTableAdapter())
                {
                    var table = adapter.GetData(sessionID, row.doc_id, OrderID, (row.Isvendor_idNull() ? (long?)null : row.vendor_id));
                    if (table.Count == 0)
                        Logger.ShowErrorMessageBox("Процедура получения параметров не вернула данные!");
                    else
                    {
                        var r = table[0];
                        tbLot_Qty.Text = r.Islot_qtyNull() ? String.Empty : r.lot_qty.ToString();
                        tbLot_Qty.Enabled = inboundMode ? false : (r.Iscan_edit_lqNull() ? false : r.can_edit_lq);
                        tbxCertNumber.Text = r.Iscert_numberNull() ? String.Empty : r.cert_number;
                        
                        if (!r.Iscert_dateNull())
                            tbxCertDate.Text = (r.cert_date.Day < 10 ? "0" : "") + r.cert_date.Day +
                                (r.cert_date.Month < 10 ? "0" : "") + r.cert_date.Month + r.cert_date.Year.ToString().Substring(2, 2);
                        tbxVendorLot.Text = r.Isvendor_lotNull() ? String.Empty : r.vendor_lot;
                        
                        if (!r.Isexpiration_dateNull())
                            dtpExpirationDate.Value = r.expiration_date;

                        btnShowExpirationDatesDifference.Visible = false;
                        btnShowExpirationDatesDifference.Tag = r.IsisExpDateResortNull() ? (int?)null : r.isExpDateResort;
                        if (!r.IsisExpDateResortNull() && r.isExpDateResort == 1)
                        {
                            lblExpirationDate.ForeColor = Color.Magenta;
                            btnShowExpirationDatesDifference.Visible = true;
                            new ToolTip().SetToolTip(btnShowExpirationDatesDifference, "Информация о сроках годности\r\nтекущей и предыдущих поставок.");
                        }

                        if (!r.IsLotn_manufacturer_IDNull() && quality.AT_Lotn_Manufacturers.Count == 1)
                            cmbLotnManufacturer.SelectedValue = r.Lotn_manufacturer_ID;
                        else
                            cmbLotnManufacturer.SelectedItem = null;

                        if (!r.IsTempStorageModeNull())
                            ecmbTemperatureStorageMode.SelectedValue = r.TempStorageMode;
                    }
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка при загрузке параметров партии!", exc);
            }
        }

        private void btnShowExpirationDatesDifference_Click(object sender, EventArgs e)
        {
            try
            {
                using (var adapter = new Data.QualityTableAdapters.ExpirationDateShipmentsDifferenceTableAdapter())
                    adapter.Fill(quality.ExpirationDateShipmentsDifference, sessionID, row.doc_id);

                using (var frmExpirationDatesDifference = new RichListForm())
                {
                    #region column Shipment_Type
                    DataGridViewTextBoxColumn colShipmentType = new DataGridViewTextBoxColumn();
                    colShipmentType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                    colShipmentType.DataPropertyName = "Shipment_Type";
                    colShipmentType.HeaderText = "Поставка";
                    colShipmentType.Name = "colShipmentType";
                    colShipmentType.ReadOnly = true;
                    frmExpirationDatesDifference.Columns.Add(colShipmentType);
                    #endregion
                    #region column Lot_number
                    DataGridViewTextBoxColumn colLotnumber = new DataGridViewTextBoxColumn();
                    colLotnumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                    colLotnumber.DataPropertyName = "Lot_number";
                    colLotnumber.HeaderText = "Партия";
                    colLotnumber.Name = "colLotnumber";
                    colLotnumber.ReadOnly = true;
                    frmExpirationDatesDifference.Columns.Add(colLotnumber);
                    #endregion
                    #region column Exp_Date
                    DataGridViewTextBoxColumn colExpDate = new DataGridViewTextBoxColumn();
                    colExpDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                    colExpDate.DataPropertyName = "Exp_Date";
                    colExpDate.HeaderText = "Срок годности";
                    colExpDate.Name = "colExpDate";
                    colExpDate.ReadOnly = true;
                    frmExpirationDatesDifference.Columns.Add(colExpDate);
                    #endregion

                    frmExpirationDatesDifference.Text = "Информация о сроках годности текущей и предыдущих поставок";
                    frmExpirationDatesDifference.DataSource = quality.ExpirationDateShipmentsDifference;
                    frmExpirationDatesDifference.FilterVisible = false;
                    frmExpirationDatesDifference.ShowDialog();
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка при загрузке информации о сроках годности!", exc);
            }
        }

        #endregion

        #region ТАБЛИЦА С КРИТЕРИЯМИ

        /// <summary>
        /// Загрузка текущих ответов по анкете
        /// </summary>
        private void LoadExistedAnswers()
        {
            try
            {
                taAtDocVersionQuestions.Fill(quality.AT_Doc_Version_Questions, sessionID, row.doc_id);
                CheckGlsColumnEnability();
                DisableCells();
                for (int i = 0; i < dgvQuestions.RowCount; i++)
                    CheckRowResult(i);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время загрузки текущих ответов по анкете: ", exc);
            }
        }

        /// <summary>
        /// Отключение колонки "Заключение ГЛС", если в ней нет ни одного активного вопроса
        /// </summary>
        private void CheckGlsColumnEnability()
        {
            foreach (Data.Quality.AT_Doc_Version_QuestionsRow row in quality.AT_Doc_Version_Questions)
                if (!row.Isneed_answer_4Null() && row.need_answer_4)
                    return;

            // Если дошли до этого шага, значит нет ни одного активного вопроса
            clAnswer4.Visible = false;
        }

        /// <summary>
        /// Отключение ячеек, по которым нет вопросов
        /// </summary>
        private void DisableCells()
        {
            for (int i = 0; i < dgvQuestions.RowCount; i++)
            {
                var dbrow = (dgvQuestions.Rows[i].DataBoundItem as DataRowView).Row as Data.Quality.AT_Doc_Version_QuestionsRow;
                var dgvrow = dgvQuestions.Rows[i] as DataGridViewRow;

                if (!dbrow.need_answer_1)
                {
                    dgvrow.Cells[clAnswer1.Name].ReadOnly = true;
                    dgvrow.Cells[clAnswer1.Name].Style.BackColor = dgvrow.Cells[clAnswer1.Name].Style.SelectionBackColor =
                        dgvrow.Cells[clAnswer1.Name].Style.SelectionForeColor = Color.DarkGray;
                    dbrow.Setanswer1Null();
                }
                if (!dbrow.need_answer_2)
                {
                    dgvrow.Cells[clAnswer2.Name].ReadOnly = true;
                    dgvrow.Cells[clAnswer2.Name].Style.BackColor = dgvrow.Cells[clAnswer2.Name].Style.SelectionBackColor =
                        dgvrow.Cells[clAnswer2.Name].Style.SelectionForeColor = Color.DarkGray;
                    dbrow.Setanswer2Null();
                }
                if (!dbrow.need_answer_3)
                {
                    dgvrow.Cells[clAnswer3.Name].ReadOnly = true;
                    dgvrow.Cells[clAnswer3.Name].Style.BackColor = dgvrow.Cells[clAnswer3.Name].Style.SelectionBackColor =
                        dgvrow.Cells[clAnswer3.Name].Style.SelectionForeColor = Color.DarkGray;
                    dbrow.Setanswer3Null();
                }
                if (!dbrow.need_answer_4)
                {
                    dgvrow.Cells[clAnswer4.Name].ReadOnly = true;
                    dgvrow.Cells[clAnswer4.Name].Style.BackColor = dgvrow.Cells[clAnswer4.Name].Style.SelectionBackColor =
                        dgvrow.Cells[clAnswer4.Name].Style.SelectionForeColor = Color.DarkGray;
                    dbrow.Setanswer4Null();
                }
            }
        }

        /// <summary>
        /// При редактировании информации в таблице редактируем итоговую колонку
        /// </summary>
        private void dgvQuestions_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvQuestions.Columns[e.ColumnIndex].ReadOnly || e.RowIndex == -1 || e.ColumnIndex == -1)
                return;
            else
                CheckRowResult(e.RowIndex);
        }

        /// <summary>
        /// Проверка итогового значения Соответствует/Не соответствует по строке
        /// </summary>
        /// <param name="pRowIndex">Номер строки</param>
        private void CheckRowResult(int pRowIndex)
        {
            var dbRow = (dgvQuestions.Rows[pRowIndex].DataBoundItem as DataRowView).Row as Data.Quality.AT_Doc_Version_QuestionsRow;
            dgvQuestions.CommitEdit(DataGridViewDataErrorContexts.Commit);
            dbRow.result = "Соответствует";
            dgvQuestions.Rows[pRowIndex].DefaultCellStyle.BackColor = Color.MediumSeaGreen;
            foreach (DataGridViewColumn col in dgvQuestions.Columns)
                if (!col.ReadOnly && col.Visible && !dgvQuestions.Rows[pRowIndex].Cells[col.Name].ReadOnly
                    && (dgvQuestions.Rows[pRowIndex].Cells[col.Name].Value == DBNull.Value ||
                    !Convert.ToBoolean(dgvQuestions.Rows[pRowIndex].Cells[col.Name].Value)))
                {
                    dbRow.result = "Не соответствует";
                    dgvQuestions.Rows[pRowIndex].DefaultCellStyle.BackColor = Color.Pink;
                    break;
                }
        }

        #endregion

        #region ПРОВЕРКА И СОХРАНЕНИЕ ДАННЫХ

        /// <summary>
        /// XML-структура с ответами на критерии
        /// </summary>
        public string XmlAnswers { get; private set; }

        /// <summary>
        /// Название атрибута в XML-строке, отвечающего за код вопроса
        /// </summary>
        private const string QID_ATTR_NAME = "question_id";

        /// <summary>
        /// Название атрибута в XML-строке, отвечающего за код источника ответа
        /// </summary>
        private const string SID_ATTR_NAME = "source_id";

        /// <summary>
        /// Название атрибута в XML-строке, отвечающего за ответ
        /// </summary>
        private const string ANS_ATTR_NAME = "new_value";

        private bool LotQtyParse(out double result)
        {
            result = Double.NaN;

            if (inboundMode || !tbLot_Qty.Enabled)
                return true;

            var separator = CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator;

            var str_result = tbLot_Qty.Text.Replace(",", separator).Replace(".", separator);

            var ret = Double.TryParse(str_result, out result);
            return ret;
        }

        /// <summary>
        /// Сохранение данных по нажатию на кнопку "ОК"
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (lockExit)
                {
                    if (!inboundMode && (tbxCertDate.BackColor == Color.Red || string.IsNullOrEmpty(tbxCertNumber.Text)))
                    {
                        MessageBox.Show("Необходимо заполнить данные по сертификату!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        tbxCertNumber.Focus();
                        return;
                    }
                }

                XmlAnswers = CreateXml();
                if (CheckParameters())
                {
                    double lotQty = double.NaN;
                    if (!LotQtyParse(out lotQty))
                    {
                        tbLot_Qty.Focus();
                        return;
                    }

                    using (var adapter = new AT_Current_Lotn_ParamsTableAdapter())
                    {
                        var lotnManufacturerID = quality.AT_Lotn_Manufacturers.Count > 1 ? (double)cmbLotnManufacturer.SelectedValue : (double?)null;
                        var temperatureStorageMode = Convert.ToInt32(ecmbTemperatureStorageMode.SelectedValue);
                        var isExpDateResort = btnShowExpirationDatesDifference.Tag == null ? (int?)null : Convert.ToInt32(btnShowExpirationDatesDifference.Tag);

                        adapter.SetTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds);
                        adapter.ChangeInfoForLotn(sessionID, row.item_id, row.lot_number, tbxVendorLot.Text, dtpExpirationDate.Value,
                            tbxCertNumber.Text, dtpCertDate.Value, cbHasCertificate.Checked, row.doc_id, (Double.IsNaN(lotQty) ? (double?)null : lotQty), DirectumStream, "TIF", DirectumOriginalStream,
                            inboundMode, temperatureStorageMode, isExpDateResort, lotnManufacturerID);
                    }

                    // Установка факта прохождения контроля 
                    using (var adapter = new AT_Doc_Version_QuestionsTableAdapter())
                        adapter.CreateNewVersion(sessionID, row.doc_id, XmlAnswers, inboundMode);

                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время подтверждения входного контроля: ", exc);
            }
        }

        /// <summary>
        /// Формирование XML-структуры вопрос/ответ для передачи в процедуру
        /// </summary>
        /// <returns>XML-фильтр, который характиризует разворачиваемую строку</returns>
        private string CreateXml()
        {
            var doc = new XmlDocument();
            var root = doc.AppendChild(doc.CreateElement("Root"));
            foreach (Data.Quality.AT_Doc_Version_QuestionsRow row in quality.AT_Doc_Version_Questions)
            {
                // Добавляем строки по критериях
                if (row.need_answer_1)
                {
                    var xmlrow = (XmlElement)root.AppendChild(doc.CreateElement("Question"));
                    xmlrow.SetAttribute(QID_ATTR_NAME, row.question_id.ToString());
                    xmlrow.SetAttribute(SID_ATTR_NAME, Constants.QK_IC_SOURCEID_CERT);
                    if (!row.Isanswer1Null())
                        xmlrow.SetAttribute(ANS_ATTR_NAME, row.answer1.ToString());
                }
                if (row.need_answer_2)
                {
                    var xmlrow = (XmlElement)root.AppendChild(doc.CreateElement("Question"));
                    xmlrow.SetAttribute(QID_ATTR_NAME, row.question_id.ToString());
                    xmlrow.SetAttribute(SID_ATTR_NAME, Constants.QK_IC_SOURCEID_VISUAL);
                    if (!row.Isanswer2Null())
                        xmlrow.SetAttribute(ANS_ATTR_NAME, row.answer2.ToString());
                }
                if (row.need_answer_3)
                {
                    var xmlrow = (XmlElement)root.AppendChild(doc.CreateElement("Question"));
                    xmlrow.SetAttribute(QID_ATTR_NAME, row.question_id.ToString());
                    xmlrow.SetAttribute(SID_ATTR_NAME, Constants.QK_IC_SOURCEID_PRINTEDINV);
                    if (!row.Isanswer3Null())
                        xmlrow.SetAttribute(ANS_ATTR_NAME, row.answer3.ToString());
                }
                if (row.need_answer_4)
                {
                    var xmlrow = (XmlElement)root.AppendChild(doc.CreateElement("Question"));
                    xmlrow.SetAttribute(QID_ATTR_NAME, row.question_id.ToString());
                    xmlrow.SetAttribute(SID_ATTR_NAME, Constants.QK_IC_SOURCEID_GLS);
                    if (!row.Isanswer4Null())
                        xmlrow.SetAttribute(ANS_ATTR_NAME, row.answer4.ToString());
                }

            }
            return root.InnerXml;
        }

        /// <summary>
        /// Редактирование параметров партии
        /// </summary>
        private void btnEditData_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckParameters())
                {
                    double lotQty = double.NaN;
                    if (!LotQtyParse(out lotQty))
                    {
                        tbLot_Qty.Focus();
                        return;
                    }

                    using (var adapter = new AT_Current_Lotn_ParamsTableAdapter())
                    {
                        var lotnManufacturerID = quality.AT_Lotn_Manufacturers.Count > 1 ? (double)cmbLotnManufacturer.SelectedValue : (double?)null;
                        var temperatureStorageMode = Convert.ToInt32(ecmbTemperatureStorageMode.SelectedValue);
                        var isExpDateResort = btnShowExpirationDatesDifference.Tag == null ? (int?)null : Convert.ToInt32(btnShowExpirationDatesDifference.Tag);

                        adapter.SetTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds);
                        adapter.ChangeInfoForLotn(sessionID, row.item_id, row.lot_number, tbxVendorLot.Text, dtpExpirationDate.Value,
                            tbxCertNumber.Text, dtpCertDate.Value, cbHasCertificate.Checked, row.doc_id, (Double.IsNaN(lotQty) ? (double?)null : lotQty), DirectumStream, "TIF", DirectumOriginalStream,
                            inboundMode, temperatureStorageMode, isExpDateResort, lotnManufacturerID);
                    }
                    LoadExistedAnswers();
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время редактирования данных по партии: ", exc);
            }
        }

        /// <summary>
        /// Проверка введенных параметров серии
        /// </summary>
        /// <returns>True если параметры серии введены правильно, False в противном случае</returns>
        private bool CheckParameters()
        {
            string message = String.Empty;
            if (String.IsNullOrEmpty(tbxVendorLot.Text))
                message = "Номер серии не может быть пустой!";
            else if (!inboundMode && String.IsNullOrEmpty(tbxCertNumber.Text))
                message = "Поле с номером сертификата не может быть пустым! Если номер сертификата качества не указан, введите 'Б/Н'";
            else if (!inboundMode && tbxCertDate.BackColor == Color.Red)
                message = "Дата сертификата имеет неверный формат!";
            else if (!inboundMode && String.IsNullOrEmpty(tbLot_Qty.Text) && tbLot_Qty.Enabled)
                message = "Размер серии не может быть пустым!";
            else if (cmbLotnManufacturer.SelectedValue == null)
                message = "Производитель по партии должен быть задан!";
            else if (ecmbTemperatureStorageMode.SelectedValue == null)
                message = "Условия хранения должны быть заданы!";

            if (String.IsNullOrEmpty(message))
                return true;
            else
            {
                Logger.ShowErrorMessageBox(message);
                return false;
            }
        }

        /// <summary>
        /// Парсинг введенного года
        /// </summary>
        private void tbxDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                long l;
                tbxCertDate.BackColor = Color.Red;
                if (!String.IsNullOrEmpty(tbxCertDate.Text) || tbxCertDate.Text.Length == 6 && Int64.TryParse(tbxCertDate.Text, out l) && l > 0)
                {
                    int date = Convert.ToInt32(tbxCertDate.Text.Substring(0, 2));
                    int month = Convert.ToInt32(tbxCertDate.Text.Substring(2, 2));
                    int year = Convert.ToInt32("20" + tbxCertDate.Text.Substring(4, 2));
                    dtpCertDate.Value = new DateTime(year, month, date);
                    tbxCertDate.BackColor = Color.White;
                }
            }
            catch
            {
                tbxCertDate.BackColor = Color.Red;
            }
        }

        #endregion

        private bool lockExit = false; // Блокировка выхода из диалога в случае регистрации новой серии

        private void tbxVendorLot_Leave(object sender, EventArgs e)
        {
            try
            {
                lockExit = false;

                using (var adapter = new Data.QualityTableAdapters.CheckSertTableAdapter())
                    adapter.Fill(quality.CheckSert, row.item_id, tbxVendorLot.Text);

                if (quality != null)
                {
                    // серия новая
                    if (quality.CheckSert.Rows.Count == 0)
                    {
                        if (!inboundMode)
                        {
                            MessageBox.Show(string.Format("Введена новая серия!\r\nЗаполните поля \"{0}\", \"{1}\"", "Номер сертификата", "Дата сертификата"), "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            tbxCertNumber.Clear();
                            tbxCertDate.Clear();

                            tbxCertDate.Focus();

                            lockExit = true;
                        }
                    }
                    // серия старая
                    else
                    {
                        var sert = quality.CheckSert[0];
                        tbxCertNumber.Text = sert.srlot1;
                        tbxCertDate.Text = string.Format("{0}{1}{2}",
                            sert.SRUA01.Day.ToString().PadLeft(2, '0'),
                            sert.SRUA01.Month.ToString().PadLeft(2, '0'),
                            sert.SRUA01.Year.ToString().Substring(2, 2));

                        tbxCertDate.Focus();
                    }
                }
            }
            // серия не найдена
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbxVendorLot.Focus();
                tbxVendorLot.SelectAll();
            }
        }

        /// <summary>
        /// заливка заданий для обработки в directum
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddTaskDirectum_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckParameters())
                {
                    double lotQty = double.NaN;
                    if (!LotQtyParse(out lotQty))
                    {
                        tbLot_Qty.Focus();
                        return;
                    }

                    using (var adapter = new QueriesTableAdapter())
                        adapter.DocumentTaskAddSEK("SEK", row.doc_id, sessionID, row.item_id, row.lot_number, tbxVendorLot.Text,
                            tbxCertNumber.Text, dtpCertDate.Value, dtpExpirationDate.Value, cbHasCertificate.Checked, (Double.IsNaN(lotQty) ? (double?)null : lotQty), DirectumStream, "TIF", DirectumOriginalStream);
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время добавления задания в Directum: ", exc);
            }
        }

        public byte[] DirectumStream { get; set; }

        public byte[] DirectumOriginalStream { get; set; }

        /// <summary>
        /// Сканровать документ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnScan_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new IntupControlScanDocumentForm() { Owner = this };
                if (frm.ShowDialog() == DialogResult.Cancel)
                    return;

                DirectumStream = frm.GetStream();

                DirectumOriginalStream = frm.GetOriginalStream();
            }
            catch (Exception ex)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время добавления скан.копии докуманта: ", ex);
            }

        }
    }
}
