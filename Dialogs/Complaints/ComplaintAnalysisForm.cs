using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;

using WMSOffice.Classes;
using WMSOffice.Controls;
using WMSOffice.Data.ComplaintsTableAdapters;
using System.Diagnostics;
using System.Threading;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using System.Drawing;
using WMSOffice.Reports;

namespace WMSOffice.Dialogs.Complaints
{
    /// <summary>
    /// Форма, в которой отображается детальная информация по претензии
    /// </summary>
    public partial class ComplaintAnalysisForm : Form
    {
        #region ПЕРЕМЕННЫЕ И СВОЙСТВА

        /// <summary>
        /// Код ресурса при подключении к приложению видеомониторинга
        /// </summary>
        private static readonly string varEnvironment = "WMSVideoMonitoringTargetDir";

        /// <summary>
        /// Название приложения видеомониторинга
        /// </summary>
        private static readonly string wvmExecutableName = "WMSVideoMonitoring.exe";

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private readonly long sessionID;

        /// <summary>
        /// Претензия, которая анализируется
        /// </summary>
        private readonly Data.Complaints.CurrentDocsRow complaint;

        /// <summary>
        /// Возможность создания новой претензии на основе данной
        /// </summary>
        private bool canCreateSimilarComplaint = false;

        /// <summary>
        /// Строка, которая выводится в случае, если какая-нибудь информация не задана
        /// </summary>
        private const string NO_INFO_STR = "-";

        /// <summary>
        /// Выделенная в таблице аналитической инфомрации строка либо NULL, если не выбрано ни одной строки либо 
        /// таблица не содержит данных вообще
        /// </summary>
        private Data.Complaints.AnalysisInfoRow SelectedInfoRow
        {
            get
            {
                if (dgvComplaintDetails.SelectedRows.Count == 0)
                    return null;
                return (dgvComplaintDetails.SelectedRows[0].DataBoundItem as DataRowView).Row
                    as Data.Complaints.AnalysisInfoRow;
            }
        }

        private bool showWeightControlInfo = false;

        /// <summary>
        /// Список для хранения индикации загрузки страницы
        /// </summary>
        private List<bool> lstLoadingCompleted = new List<bool>();

        /// <summary>
        /// Необходимость обновлений списка текущих претензий
        /// </summary>
        public bool NeedRefresh { get; private set; }


        public bool CanPrintInvestigationReport
        {
            get { return btnPrintInvestigationReport.Enabled; }
            set { btnPrintInvestigationReport.Enabled = btnPrintInvestigationReport.Visible = value; }
        }

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ КЛАССА

        public ComplaintAnalysisForm(Data.Complaints.CurrentDocsRow pDocRow, long pSessionID,
            bool pCanAddTakingRemainsRequest, bool pCanRequestAttachments, bool pCanPrintMedicalRegister)
        {
            if (pDocRow == null)
                throw new ArgumentNullException("Претензия, которая анализируется, равна NULL!");
            InitializeComponent();
            complaint = pDocRow;
            sessionID = pSessionID;
            btnAddTakingRemainsRequest.Enabled = pCanAddTakingRemainsRequest &&
                pDocRow.Doc_Type == Constants.CO_DTFL_MANUFACTURERND || pDocRow.Doc_Type == Constants.CO_DTFL_DEFECT;
            btnAttachmentRequest.Enabled = pCanRequestAttachments;
            btnPrintMedicalRegister.Enabled = pCanPrintMedicalRegister;
            showWeightControlInfo = pDocRow.IsControl_TypeNull() ? false : pDocRow.Control_Type.Equals("A");
            CustomCommonInfo();
            CustomContactInfo();
            CustomCheckHeader();
            Config.LoadDataGridViewSettings(Name, dgvComplaintDetails);
        }

        /// <summary>
        /// Заполнение заголовка с общими данными по претензии
        /// </summary>
        private void CustomCommonInfo()
        {
            lblDocID.Text = complaint.First_Doc_ID.ToString();
            lblDocType.Text = String.Format("({0}) {1}", complaint.Doc_Type, complaint.Doc_Type_Name);
            lblDocStatus.Text = String.Format("({0}) {1}", complaint.Status_ID, complaint.Status_Name);
            lblContactName.Text = complaint.IsContact_NameNull() ? NO_INFO_STR : complaint.Contact_Name;
            tbxComment.Text = complaint.IsCommentNull() ? NO_INFO_STR : complaint.Comment;
            lblSource.Text = String.Format("({0}) {1} {2}", complaint.Source_Address_Code,
                complaint.Source_Address_Name, complaint.Source_Address);

            if (!complaint.IsLinked_Doc_IDNull() && complaint.Linked_Doc_ID > 0)
            {
                lblLinkedComplaintInfo.Visible = true;
                lblLinkedComplaintInfo.Text = String.Format("* СВЯЗЬ С № {0}", complaint.Linked_Doc_ID.ToString());
            }

            if (complaint.Doc_Type.Equals(
                ComplaintsConstants.ComplaintDocTypeVirtualRefuse, StringComparison.InvariantCultureIgnoreCase))
            {
                lblDestCaption.Visible = lblDest.Visible = true;
                lblDest.Text = String.Format("({0}) {1}", complaint.Dest_Address_Code, complaint.Dest_Address_Name);
            }
        }

        private void CustomContactInfo()
        {
            try
            {
                using (var adapter = new Data.ComplaintsTableAdapters.CO_ContactsTableAdapter())
                    adapter.Fill(complaints.CO_Contacts, complaint.Doc_ID);

                foreach (Data.Complaints.CO_ContactsRow contact in complaints.CO_Contacts)
                {
                    rtbContactInfo.BackColor = SystemColors.GradientInactiveCaption;

                    var debtorEmail = contact.IsDebtorEmailNull() ? (string)null : contact.DebtorEmail;
                    var surname = contact.IsSurnameNull() ? (string)null : contact.Surname;
                    var email = contact.IsEmailNull() ? (string)null : contact.Email;
                    var phone = contact.IsPhoneNull() ? (string)null : contact.Phone;

                    this.AppendCustomContactInfo(rtbContactInfo, "E-mail по претензиям: ", SystemColors.HotTrack, new Font(rtbContactInfo.Font, FontStyle.Bold));
                    this.AppendCustomContactInfo(rtbContactInfo, string.Format("{0}\n", string.IsNullOrEmpty(debtorEmail) ? "-" : debtorEmail), Color.Black, rtbContactInfo.Font);
                    this.AppendCustomContactInfo(rtbContactInfo, "ФИО зав. аптекой: ", SystemColors.HotTrack, new Font(rtbContactInfo.Font, FontStyle.Bold));
                    this.AppendCustomContactInfo(rtbContactInfo, string.Format("{0}\n", string.IsNullOrEmpty(surname) ? "-" : surname), Color.Black, rtbContactInfo.Font);
                    this.AppendCustomContactInfo(rtbContactInfo, "E-mail зав. аптекой: ", SystemColors.HotTrack, new Font(rtbContactInfo.Font, FontStyle.Bold));
                    this.AppendCustomContactInfo(rtbContactInfo, string.Format("{0}\n", string.IsNullOrEmpty(email) ? "-" : email), Color.Black, rtbContactInfo.Font);
                    this.AppendCustomContactInfo(rtbContactInfo, "Телефон: ", SystemColors.HotTrack, new Font(rtbContactInfo.Font, FontStyle.Bold));
                    this.AppendCustomContactInfo(rtbContactInfo, string.Format("{0}", string.IsNullOrEmpty(phone) ? "-" : phone), Color.Black, rtbContactInfo.Font);

                    break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AppendCustomContactInfo(RichTextBox rtb, string text, Color color, Font font)
        {
            rtb.SuspendLayout();
            rtb.SelectionStart = rtb.TextLength;
            rtb.SelectionLength = 0;

            rtb.SelectionColor = color;
            rtb.SelectionFont = font;
            rtb.AppendText(text);
            rtb.SelectionColor = rtb.ForeColor;
            rtb.ScrollToCaret();
            rtb.ResumeLayout();
        }

        /// <summary>
        /// Настройка заголовка для CheckBox-колонки тоже в виде CheckBox-а
        /// </summary>
        private void CustomCheckHeader()
        {
            var checkHeaderCell = new DataGridViewHeaderCheckBoxCell();
            checkHeaderCell.OnCheckBoxClicked += checkHeaderCell_OnCheckBoxClicked;
            checkHeaderCell.Value = String.Empty;
            colCheckBox.HeaderCell = checkHeaderCell;
        }

        /// <summary>
        /// Выбор/снятие флажка со всех строк при выборе флажка в заголовке колонки
        /// </summary>
        /// <param name="pState">True, если флажок в заголовке был выбран, False - если снят</param>
        public void checkHeaderCell_OnCheckBoxClicked(bool pState)
        {
            foreach (DataGridViewRow row in dgvComplaintDetails.Rows)
                ((row.DataBoundItem as DataRowView).Row as Data.Complaints.AnalysisInfoRow).IsChecked = pState;

            dgvComplaintDetails.RefreshEdit();
            bsAnalysisInfo.ResetBindings(false);
        }

        /// <summary>
        /// Загрузка аналитических данных при загрузке окна
        /// </summary>
        private void ComplaintAnalysisForm_Load(object sender, EventArgs e)
        {
            this.Initialize();

            this.complaintsExt.AvaibleComplaintTypes.LoadDataRow(new object[] { string.Empty, string.Empty }, true);
            cbChangeComplaintType.Enabled = false;
            cmbComplaintTypes.Enabled = false;

            if (!showWeightControlInfo)
                tcComplaintDetailsInfo.TabPages.Remove(tpWeightControl);

            CheckWarehouseComplaintOperationAccess();
            CheckShowPLKAccess();

            this.ReloadData();
        }

        private void Initialize()
        {
            // Инициализация загрузчика
            foreach (var page in this.tcComplaintDetailsInfo.TabPages)
                lstLoadingCompleted.Add(false);



            // Инициализация фильтруемого представления
            this.xdgvPickLog.UseMultiSelectMode = false;

            //this.xdgvPickLog.AllowFilter = false;
            this.xdgvPickLog.AllowSummary = false;
            this.xdgvPickLog.AllowRangeColumns = false;

            this.xdgvPickLog.Init(new ComplaintsPickLog(), true);

            this.xdgvPickLog.UserID = sessionID;

            this.xdgvPickLog.OnDataError += (s, e) => { e.ThrowException = false; };
            this.xdgvPickLog.OnFilterChanged += (s, e) => { this.xdgvPickLog.RecalculateSummary(); };



            // Инициализация фильтруемого представления
            this.xdgvWeightControl.UseMultiSelectMode = false;

            //this.xdgvWeightControl.AllowFilter = false;
            this.xdgvWeightControl.AllowSummary = false;
            this.xdgvWeightControl.AllowRangeColumns = false;
            this.xdgvWeightControl.AllowSort = false;

            this.xdgvWeightControl.Init(new ComplaintsWeightControlView(), true);

            this.xdgvWeightControl.UserID = sessionID;

            this.xdgvWeightControl.OnDataError += (s, e) => { e.ThrowException = false; };
            this.xdgvWeightControl.OnFilterChanged += (s, e) => { this.xdgvWeightControl.RecalculateSummary(); };
            this.xdgvWeightControl.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvWeightControl_OnFormattingCell);
            this.xdgvWeightControl.OnDataBindingComplete += new DataGridViewBindingCompleteEventHandler(xdgvWeightControl_OnDataBindingComplete);
            this.xdgvWeightControl.OnCellContentClick += new DataGridViewCellEventHandler(xdgvWeightControl_OnCellContentClick);
            this.xdgvWeightControl.OnMultiRowsSelectionChanged += new EventHandler<WMSOffice.Controls.DataGridViewCheckBoxHeaderCellEventArgs>(xdgvWeightControl_OnMultiRowsSelectionChanged);
            this.xdgvWeightControl.OnCustomSummaryCalculation += new EventHandler<СustomSummaryCalculationEventArgs>(xdgvWeightControl_OnСustomSummaryCalculation);

            this.xdgvWeightControl.DataGrid.ContextMenuStrip = cmsWeightControl;



            // Инициализация фильтруемого представления
            this.xdgvStatusLog.UseMultiSelectMode = false;

            //this.xdgvStatusLog.AllowFilter = false;
            this.xdgvStatusLog.AllowSummary = false;
            this.xdgvStatusLog.AllowRangeColumns = false;

            this.xdgvStatusLog.Init(new ComplaintStatusLogView(), true);

            this.xdgvStatusLog.UserID = sessionID;

            this.xdgvStatusLog.OnDataError += (s, e) => { e.ThrowException = false; };
            this.xdgvStatusLog.OnFilterChanged += (s, e) => { this.xdgvStatusLog.RecalculateSummary(); };
        }

        private void CheckWarehouseComplaintOperationAccess()
        {
            try
            {
                #region ПРОВЕРКА ВОЗМОЖНОСТИ ИЗМЕНЕНИЯ ТИПА ПРЕТЕНЗИИ

                var canChangeWarehouseComplaintType = (bool?)null;
                using (var adapter = new Data.ComplaintsExtTableAdapters.QueriesTableAdapter())
                    adapter.CanChangeWarehouseComplaintType(sessionID, complaint.Doc_ID, ref canChangeWarehouseComplaintType);

                canCreateSimilarComplaint = canChangeWarehouseComplaintType ?? false;
                cbChangeComplaintType.Enabled = canCreateSimilarComplaint;

                #endregion

                btnSave.Visible = canCreateSimilarComplaint;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CheckShowPLKAccess()
        {
            try
            {
                #region ПРОВЕРКА ВОЗМОЖНОСТИ ИСПОЛЬЗОВАТЬ ФИЛЬТР ПО ТИПУ СБОРОЧНОГО

                using (var adapter = new Data.ComplaintsTableAdapters.AnalysisInfoCheckPickTypeTableAdapter())
                    adapter.Fill(complaints.AnalysisInfoCheckPickType, complaint.Doc_ID, sessionID);

                chbShowPLK.Visible = false;
                if (complaints.AnalysisInfoCheckPickType.Count > 0)
                {
                    var checkResult = complaints.AnalysisInfoCheckPickType[0];

                    chbShowPLK.Visible = true;
                    chbShowPLK.Text = checkResult.IsLabelNull() ? string.Empty : checkResult.Label;
                    chbShowPLK.Checked = checkResult.IsIsCheckedNull() ? false : checkResult.IsChecked;
                }

                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обновляет данные в таблице при изменении состояния флажка "Показывать все строки накладной".
        /// </summary>
        private void chkbShowAll_CheckedChanged(object sender, EventArgs e)
        {
            ReloadData(null);
        }

        /// <summary>
        /// Обновляет данные в таблице при изменении состояния флажка "Показывать все строки сборочного (Плацкарт)".
        /// </summary>
        private void chbShowPLK_CheckedChanged(object sender, EventArgs e)
        {
            ReloadData(null);
        }

        private void ReloadData(object state)
        {
            for (int i = 0; i < this.lstLoadingCompleted.Count; i++)
                this.lstLoadingCompleted[i] = false;

            ReloadData();
        }

        /// <summary>
        /// Сохранение настроек грида при выходе из окна
        /// </summary>
        private void ComplaintAnalysisForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Config.SaveDataGridViewSettings(Name, dgvComplaintDetails);
        }

        #endregion

        private void tcComplaintDetailsInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadData();
        }
        
        private void ReloadData()
        {
            chbShowAll.Visible = true;

            var tabPageSelectedIndex = tcComplaintDetailsInfo.SelectedTab == tpComplaintDetails 
                ? 0
                : tcComplaintDetailsInfo.SelectedTab == tpPickLog
                    ? 1
                    : tcComplaintDetailsInfo.SelectedTab == tpWeightControl
                        ? 2
                        : tcComplaintDetailsInfo.SelectedTab == tpStatusLog
                            ? 3
                            : -1;

            switch (tabPageSelectedIndex)
            {
                case 0:
                    chbShowAll.Text = "Показывать все строки накладных";
                    if (!this.lstLoadingCompleted[0])
                    {
                        StartAnalysisInfoLoading();
                        this.lstLoadingCompleted[0] = true;
                    }
                    break;
                case 1:
                    chbShowAll.Text = "Показывать все строки сборки";
                    if (!this.lstLoadingCompleted[1])
                    {
                        ReloadPickLog();
                        this.lstLoadingCompleted[1] = true;
                    }
                    break;
                case 2:
                    chbShowAll.Text = "Показывать только строки по претензии";
                    if (!this.lstLoadingCompleted[2])
                    {
                        ReloadWeightControlInfo();
                        this.lstLoadingCompleted[2] = true;
                    }
                    break;
                case 3:
                    chbShowAll.Visible = false;
                    if (!this.lstLoadingCompleted[3])
                    {
                        ReloadStatusLog();
                        this.lstLoadingCompleted[3] = true;
                    }
                    break;
                default:
                    break;
            }
        }

        #region АСИНХРОННАЯ ЗАГРУЗКА АНАЛИТИЧЕСКОЙ ИНФОРМАЦИИ

        /// <summary>
        /// Запуск асинхронной загрузки аналитической информации
        /// </summary>
        private void StartAnalysisInfoLoading()
        {
            lastWorker = new BackgroundWorker();
            lastWorker.DoWork += lastWorker_DoWork;
            lastWorker.RunWorkerCompleted += lastWorker_RunWorkerCompleted;
            if (dgvComplaintDetails.Rows.Count > 0)  // Исключаем сохранение настроек на пустой таблице
                Config.SaveDataGridViewSettings(Name, dgvComplaintDetails);
            dgvComplaintDetails.Enabled = false;
            pbWait.Visible = true;
            tcComplaintDetailsInfo.Enabled = false;
            dgvComplaintDetails.DataSource = null;
            lastWorker.RunWorkerAsync(new object[] { complaint.Doc_ID, chbShowAll.Checked, chbShowPLK.Visible ? chbShowPLK.Checked : (bool?)null });
        }

        /// <summary>
        /// Асинхронная загрузка аналитической информации
        /// </summary>
        private void lastWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                object[] param = (object[])e.Argument;
                using (var adapter = new AnalysisInfoTableAdapter())
                {
                    adapter.SetTimeout((int)TimeSpan.FromMinutes(5).TotalSeconds);
                    e.Result = adapter.GetData((long)param[0], (bool)param[1], (bool?)param[2]);
                }
            }
            catch (Exception exc)
            {
                e.Result = exc;
            }
        }

        /// <summary>
        /// Загрузка аналитической информации закончена
        /// </summary>
        private void lastWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (sender == lastWorker)
            {
                if (e.Result is Exception)
                    Logger.ShowErrorMessageBox("Во время загрузки аналитической информации произошла ошибка: ", e.Result as Exception);
                else
                {
                    complaints.AnalysisInfo.Clear();
                    complaints.AnalysisInfo.Merge(e.Result as DataTable);
                }

                dgvComplaintDetails.DataSource = bsAnalysisInfo;

                pbWait.Visible = false;
                tcComplaintDetailsInfo.Enabled = true;
                dgvComplaintDetails.Enabled = true;
                DataGridViewHelper.AutoSetColumnWidths(dgvComplaintDetails);
                Config.LoadDataGridViewSettings(Name, dgvComplaintDetails);
            }
        }

        #endregion

        #region АСИНХРОННАЯ ЗАГРУЗКА ЖУРНАЛА СБОРКИ

        private void ReloadPickLog()
        {
            try
            {
                var searchCriteria = new ComplaintsPickLogSearchParameters();
                searchCriteria.SessionID = sessionID;
                searchCriteria.DocID = complaint.Doc_ID;
                searchCriteria.ShowAll = chbShowAll.Checked;
                searchCriteria.ShowPLK = chbShowPLK.Visible ? chbShowPLK.Checked : (bool?)null;

                lastWorker = new BackgroundWorker();
                lastWorker.DoWork += (s, e) => 
                {
                    try
                    {
                        var sc = e.Argument as ComplaintsPickLogSearchParameters;
                        this.xdgvPickLog.DataView.FillData(sc);
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                lastWorker.RunWorkerCompleted += (s, e) => 
                {
                    if (e.Result is Exception)
                        MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        this.xdgvPickLog.BindData(false);

                        //this.xdgvPickLog.AllowFilter = true;
                        this.xdgvPickLog.AllowSummary = true;
                    }

                    pbWait.Visible = false;
                    tcComplaintDetailsInfo.Enabled = true;
                };
                pbWait.Visible = true;
                tcComplaintDetailsInfo.Enabled = false;
                lastWorker.RunWorkerAsync(searchCriteria);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region АСИНХРОННАЯ ЗАГРУЗКА ИНФОРМАЦИИ ПО ВЕСОВОМУ КОНТРОЛЮ

        private void ReloadWeightControlInfo()
        {
            try
            {
                var searchCriteria = new ComplaintsWeightControlViewSearchParameters();
                searchCriteria.SessionID = sessionID;
                searchCriteria.DocID = complaint.Doc_ID;
                searchCriteria.ShowAll = !chbShowAll.Checked;

                lastWorker = new BackgroundWorker();
                lastWorker.DoWork += (s, e) =>
                {
                    try
                    {
                        var sc = e.Argument as ComplaintsWeightControlViewSearchParameters;
                        this.xdgvWeightControl.DataView.FillData(sc);
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                lastWorker.RunWorkerCompleted += (s, e) =>
                {
                    if (e.Result is Exception)
                        MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        this.xdgvWeightControl.BindData(false);

                        //this.xdgvWeightControl.AllowFilter = true;
                        this.xdgvWeightControl.AllowSummary = true;
                    }

                    pbWait.Visible = false;
                    tcComplaintDetailsInfo.Enabled = true;
                };
                complaints.WeightControlAnalysisInfo.Clear();
                pbWait.Visible = true;
                tcComplaintDetailsInfo.Enabled = false;

                lastWorker.RunWorkerAsync(searchCriteria);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void xdgvWeightControl_OnDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (isItemSelecting)
                return;

            var canShowDivider = false;

            foreach (DataGridViewRow gridRow in xdgvWeightControl.DataGrid.Rows)
            {
                var row = (gridRow.DataBoundItem as DataRowView).Row as Data.Complaints.WeightControlAnalysisInfoRow;
                var isItem = !row.IsIsItemNull() && row.IsItem;

                if (!isItem)
                {
                    gridRow.Frozen = true;
                    canShowDivider = true;
                }
                else
                {
                    gridRow.Selected = true;

                    if (canShowDivider)
                    {
                        xdgvWeightControl.DataGrid.Rows[gridRow.Index - 1].DividerHeight = 3;
                        xdgvWeightControl.DataGrid.Rows[gridRow.Index - 1].Height += xdgvWeightControl.DataGrid.Rows[gridRow.Index - 1].DividerHeight;
                    }

                    break;
                }
            }
        }

        void xdgvWeightControl_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var row = (xdgvWeightControl.DataGrid.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Complaints.WeightControlAnalysisInfoRow;

            var isItem = !row.IsIsItemNull() && row.IsItem;
            var isCO = isItem && !row.IsIsCONull() && row.IsCO;

            var color = Color.Empty;

            if (isItem)
            {
                if (isCO)
                    color = Color.White;
                else
                    color = Color.LightGray;
            }
            else
                color = Color.Khaki;

            e.CellStyle.BackColor = color;
            e.CellStyle.SelectionForeColor = color;
        }

        private bool isItemSelecting = false;
        void xdgvWeightControl_OnCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            isItemSelecting = true;

            try
            {
                if (xdgvWeightControl.DataGrid.Columns[e.ColumnIndex].DataPropertyName == "IsChecked")
                {
                    var row = (xdgvWeightControl.DataGrid.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;
                    var keyValue = row["ItemID"];

                    var isChecked = Convert.ToBoolean(row["IsChecked"]);

                    if (this.xdgvWeightControl.ChangeRowPropertyValue("ItemID", keyValue, "IsChecked", !isChecked))
                    {
                        row["IsChecked"] = !isChecked;
                        this.xdgvWeightControl.RecalculateSummary();
                    }
                }
            }
            catch (Exception ex)
            {

            }

            isItemSelecting = false;
        }

        void xdgvWeightControl_OnMultiRowsSelectionChanged(object sender, WMSOffice.Controls.DataGridViewCheckBoxHeaderCellEventArgs e)
        {
            isItemSelecting = true;

            try
            {
                if (this.xdgvWeightControl.ChangeMultipleRowsPropertyValue("IsChecked", e.Checked))
                {
                    foreach (DataGridViewRow dgRow in xdgvWeightControl.DataGrid.Rows)
                    {
                        var row = (dgRow.DataBoundItem as DataRowView).Row;
                        row["IsChecked"] = e.Checked;
                    }

                    this.xdgvWeightControl.RecalculateSummary();
                }
            }
            catch (Exception ex)
            {

            }

            isItemSelecting = false;
        }

        void xdgvWeightControl_OnСustomSummaryCalculation(object sender, СustomSummaryCalculationEventArgs e)
        {
            try
            {
                if (e.PatternСolumn.DataFieldName == "IsChecked")
                {
                    var cntCheckedRows = 0;
                    foreach (DataRow dataRow in e.FilteredFullDataRows)
                    {
                        if (dataRow["IsChecked"].Equals(true))
                            cntCheckedRows++;
                    }

                    e.TargetCell.Value = cntCheckedRows;
                    e.TargetCell.Style.BackColor = e.TargetCell.Style.SelectionBackColor = cntCheckedRows > 0 ? Color.FromArgb(209, 255, 117) : SystemColors.Window;
                    e.TargetCell.Style.ForeColor = e.TargetCell.Style.SelectionForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void miWeightControlItemsToActualize_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedRows = xdgvWeightControl.DataView.Data.Select(string.Format("{0} = '{1}'", "IsChecked", true));

                if (selectedRows.Length == 0)
                    throw new Exception("Не выбраны товары для актуализации веса.");

                var sbItems = new StringBuilder();

                foreach (Data.Complaints.WeightControlAnalysisInfoRow item in selectedRows)
                {
                    if (sbItems.Length > 0)
                        sbItems.AppendFormat(",{0}", item.ItemID);
                    else
                        sbItems.AppendFormat("{0}", item.ItemID);
                }

                using (var adapter = new Data.ComplaintsTableAdapters.WeightControlAnalysisInfoTableAdapter())
                    adapter.CreateReweightTask(sbItems.ToString(), sessionID);

                MessageBox.Show(string.Format("На актуализацию веса передан список товаров в количестве {0} шт.", selectedRows.Length), "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void miExportWeightControlItems_Click(object sender, EventArgs e)
        {
            try
            {
                xdgvWeightControl.ExportToExcel("Экспорт позиций весового контроля в Excel", "весовой контроль", true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region АСИНХРОННАЯ ЗАГРУЗКА ИСТОРИИ СТАТУСОВ

        private void ReloadStatusLog()
        {
            try
            {
                var searchCriteria = new ComplaintStatusLogViewSearchParameters();
                searchCriteria.SessionID = sessionID;
                searchCriteria.DocID = complaint.Doc_ID;

                lastWorker = new BackgroundWorker();
                lastWorker.DoWork += (s, e) =>
                {
                    try
                    {
                        var sc = e.Argument as ComplaintStatusLogViewSearchParameters;
                        this.xdgvStatusLog.DataView.FillData(sc);
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                lastWorker.RunWorkerCompleted += (s, e) =>
                {
                    if (e.Result is Exception)
                        MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        this.xdgvStatusLog.BindData(false);

                        //this.xdgvStatusLog.AllowFilter = true;
                        this.xdgvStatusLog.AllowSummary = true;
                    }

                    pbWait.Visible = false;
                    tcComplaintDetailsInfo.Enabled = true;
                };
                pbWait.Visible = true;
                tcComplaintDetailsInfo.Enabled = false;
                lastWorker.RunWorkerAsync(searchCriteria);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region СНЯТИЕ ОСТАТКОВ

        /// <summary>
        /// Загрузка результатов снятия остатков при изменении выделенной строки в таблице аналитической информации
        /// </summary>
        private void dgvComplaintDetails_SelectionChanged(object sender, EventArgs e)
        {
            RefreshTakingRemains();
        }

        /// <summary>
        /// Загрузка результатов снятия остатков по выделенной строке в таблице аналитической информации
        /// </summary>
        private void RefreshTakingRemains()
        {
            try
            {
                if (SelectedInfoRow != null)
                    taTakingRemains.Fill(complaints.TakingRemains, complaint.First_Doc_ID,
                        Convert.ToInt32(SelectedInfoRow.ItemID),
                        SelectedInfoRow.IsVendor_LotNull() ? null : SelectedInfoRow.Vendor_Lot,
                        SelectedInfoRow.IsVendor_Lot_FactNull() ? null : SelectedInfoRow.Vendor_Lot_Fact);
                else
                    complaints.TakingRemains.Clear();
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время загрузки результатов снятия остатков по выделенной строке:", exc);
                complaints.TakingRemains.Clear();
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Снять остатки по отмеченным строкам".
        /// </summary>
        private void btnAddTakingRemainsRequest_Click(object sender, EventArgs e)
        {
            string selStr;
            var checkedRows = GetCheckedRows(out selStr);
            if (checkedRows.Count == 0)
                Logger.ShowErrorMessageBox("Для снятия остатков необходимо отметить флажком хотя бы одну товарную позицию!");
            else if (MessageBox.Show("Вы действительно хотите создать запрос на снятие остатков по выбранным позициям?\n\n" + selStr,
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                try
                {
                    foreach (var row in checkedRows)
                    {
                        if (!row.IsVendor_LotNull())
                            taTakingRemains.AddRequest(sessionID, complaint.First_Doc_ID, Convert.ToInt32(row.ItemID), row.Vendor_Lot);
                        if (complaint.Doc_Type.Equals(ComplaintsConstants.ComplaintDocTypeRegrade,
                            StringComparison.InvariantCultureIgnoreCase) && !row.IsVendor_Lot_FactNull())
                            taTakingRemains.AddRequest(sessionID, complaint.First_Doc_ID, Convert.ToInt32(row.ItemID), row.Vendor_Lot_Fact);
                    }
                }
                catch (Exception exc)
                {
                    Logger.ShowErrorMessageBox("Во время добавления запроса на снятие остатков возникла следующая ошибка:", exc);
                }

            RefreshTakingRemains();
        }

        /// <summary>
        /// Возвращает строки, отмеченные флажком в таблице аналитической информации
        /// </summary>
        /// <param name="pCheckedStr">Строковое представление все выделенных в таблице аналитической информации строк</param>
        /// <returns>Коллекция строк, которые отмеченные флажком в таблице аналитической информации</returns>
        private List<Data.Complaints.AnalysisInfoRow> GetCheckedRows(out string pCheckedStr)
        {
            var result = new List<Data.Complaints.AnalysisInfoRow>();
            var sb = new StringBuilder();
            foreach (Data.Complaints.AnalysisInfoRow row in complaints.AnalysisInfo)
                if (row.IsChecked)
                {
                    if (result.Count <= 20)
                        sb.AppendLine(String.Format("({0}) {1}, серия {2}", row.ItemID, row.ItemName, 
                            row.IsVendor_Lot_FactNull() ? "не задана" : row.Vendor_Lot_Fact));
                    result.Add(row);
                }

            if (result.Count > 20)
                sb.AppendLine("...");
            pCheckedStr = sb.ToString();
            return result;
        }

        #endregion

        #region ЗАПРОС ПОВТОРНОГО ФОТООТЧЕТА

        /// <summary>
        /// Запрос повторного фотоотчета по выделенных строкам
        /// </summary>
        private void btnAttachmentRequest_Click(object sender, EventArgs e)
        {
            string selStr;
            var checkedRows = GetCheckedRows(out selStr);
            if (checkedRows.Count == 0)
                Logger.ShowErrorMessageBox("Для запроса повторного фотоотчета необходимо отметить флажком хотя бы одну товарную позицию!");
            else if (MessageBox.Show("Вы действительно хотите создать запрос повторного фотоотчета по выбранным позициям?\n\n" + selStr,
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                try
                {
                    foreach (var row in checkedRows)
                        taAnalysisInfo.AddAttachmentRequest(sessionID, complaint.First_Doc_ID, Convert.ToInt32(row.ItemID));
                    MessageBox.Show("Было успешно отправлено уведомление о необходимости повторного фотоотчета", 
                        "Анализ претензии", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception exc)
                {
                    Logger.ShowErrorMessageBox("Во время добавления запроса на повторный фотоотчет возникла следующая ошибка:", exc);
                }

        }

        #endregion

        #region ГОРЯЧИЕ КЛАВИШИ

        /// <summary>
        /// Управление окном с помощью горячих клавиш
        /// </summary>
        private void ComplaintAnalysisForm_KeyDown(object sender, KeyEventArgs e)
        {
            if ((int)e.KeyCode == 107 && e.Control)    // Знак "+"
                checkHeaderCell_OnCheckBoxClicked(true);
            else if ((int)e.KeyCode == 109 && e.Control)    // Знак "-"
                checkHeaderCell_OnCheckBoxClicked(false);
        }

        /// <summary>
        /// Установка флажков с помощью горячих клавиш
        /// </summary>
        private void dgvComplaintDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvComplaintDetails.SelectedRows.Count > 0)
                if ((int)e.KeyCode == 107)  // Знак "+"
                    SelectedInfoRow.IsChecked = true;
                else if ((int)e.KeyCode == 109) // Знак "-"
                    SelectedInfoRow.IsChecked = false;
        }

        #endregion

        private void btnVideoControl_Click(object sender, EventArgs e)
        {
            try
            {
                string wvmTargetPath = null;
                if (string.IsNullOrEmpty((wvmTargetPath = Environment.GetEnvironmentVariable(varEnvironment, EnvironmentVariableTarget.Machine))))
                    throw new Exception("Вам необходимо установить приложение WMSVideoMonitoring.\r\nОбратитесь к системному администратору.");

                wvmTargetPath = string.Format("{0}{1}", wvmTargetPath, wvmExecutableName);

                var dlgProcessesSelector = new ComplaintProcessesSelectorForm() { SessionID = sessionID, EntityKey = "complaint" };
                if (dlgProcessesSelector.ShowDialog() == DialogResult.OK)
                {
                    var psi = new System.Diagnostics.ProcessStartInfo();

                    psi.FileName = wvmTargetPath;
                    psi.Arguments = string.Format("SessionID={0} EntityKey={1} EntityValue={2} SelectedProcesses={3}", sessionID, "complaint", complaint.Doc_ID, dlgProcessesSelector.SelectedProcesses);
                    
                    System.Diagnostics.Process.Start(psi);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region ПЕЧАТЬ ПРОТОКОЛА РАССЛЕДОВАНИЯ

        private void btnPrintInvestigationReport_Click(object sender, EventArgs e)
        {
            ComplaintAnalysisForm.PrintInvestigationReport(complaint.Doc_ID);
        }

        public static void PrintInvestigationReport(long docID)
        {
            try
            {
                var today = DateTime.Today;
                var ds = new Data.ComplaintsExt();

                // 1. Реквизиты компании
                using (var adapter = new Data.ComplaintsExtTableAdapters.CompanyConstantsTableAdapter())
                    adapter.Fill(ds.CompanyConstants, "RU", DateTime.Today);

                // 2. Члены комиссии
                using (var adapter = new Data.ComplaintsExtTableAdapters.ComplaintInvestigationReportCommitteeMembersTableAdapter())
                    adapter.Fill(ds.ComplaintInvestigationReportCommitteeMembers, docID);

                var sCommitteeMembers = string.Empty;
                #region ПОДГОТОВКА ЧЛЕНОВ КОМИСИИ В ФОРМАТЕ СПИСКА

                var sb = new System.Text.StringBuilder();
                foreach (Data.ComplaintsExt.ComplaintInvestigationReportCommitteeMembersRow dr in ds.ComplaintInvestigationReportCommitteeMembers)
                {
                    var groupName = dr.IsGroup_NameNull() ? string.Empty : dr.Group_Name;
                    var committeeMember = dr.IsCommitteeMemberNull() ? string.Empty : dr.CommitteeMember;

                    if (sb.Length == 0)
                        sb.AppendFormat("• {0} {1}", groupName, committeeMember);
                    else
                        sb.AppendFormat("\r\n• {0} {1}", groupName, committeeMember);
                }
                sCommitteeMembers = sb.ToString();

                #endregion

                // 3. Заголовки
                using (var adapter = new Data.ComplaintsExtTableAdapters.ComplaintInvestigationReportHeadersTableAdapter())
                    adapter.Fill(ds.ComplaintInvestigationReportHeaders, docID);

                if (ds.ComplaintInvestigationReportHeaders.Count == 0)
                    throw new Exception("Процедура не вернула заголовки протокола расследования.");

                var docTypeName = ds.ComplaintInvestigationReportHeaders[0].Full_Doc_Type_Name;
                using (SaveFileDialog dlgSaveToFile = new SaveFileDialog()
                {
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    Title = "Укажите файл для сохранения протокола расследования",
                    Filter = "RTF файлы (*.rtf)|*.rtf",
                    FileName = ComplaintWarehouseAnalysisForm.GetPreparedFileName(string.Format("Протокол {0} от {1} по претензии №{2}", docTypeName.Trim(), today.ToShortDateString(), docID))
                })
                    if (dlgSaveToFile.ShowDialog() == DialogResult.OK)
                    {
                        foreach (Data.ComplaintsExt.ComplaintInvestigationReportHeadersRow header in ds.ComplaintInvestigationReportHeaders)
                        {
                            var dsVendor = new Data.ComplaintsExt();

                            // 4. Строки
                            using (var adapter = new Data.ComplaintsExtTableAdapters.ComplaintInvestigationReportDetailsTableAdapter())
                                adapter.Fill(dsVendor.ComplaintInvestigationReportDetails, docID);

                            dsVendor.CompanyConstants.Clear();
                            dsVendor.CompanyConstants.Merge(ds.CompanyConstants);

                            dsVendor.ComplaintInvestigationReportHeaders.Clear();
                            dsVendor.ComplaintInvestigationReportHeaders.LoadDataRow(header.ItemArray, true);

                            dsVendor.ComplaintInvestigationReportCommitteeMembers.Clear();
                            dsVendor.ComplaintInvestigationReportCommitteeMembers.Merge(ds.ComplaintInvestigationReportCommitteeMembers);

                            var report = new WMSOffice.Reports.ComplaintInvestigationReport();
                            report.SetDataSource(dsVendor);
                            report.SetParameterValue("CommitteeMembers", sCommitteeMembers);

                            var invoiceKind = header.Type_Printed_Form == 1 
                                                ? "Накладная\nклиента" 
                                                : header.Type_Printed_Form == 2 
                                                    ? "МС\nнакладная" 
                                                    : header.Type_Printed_Form == 3
                                                        ? string.Empty
                                                        : (string)null;
                            report.SetParameterValue("InvoiceKind", invoiceKind);

                            var processName = header.Type_Printed_Form == 1 || header.Type_Printed_Form == 2
                                                 ? string.Format("поставки")
                                                 : header.Type_Printed_Form == 3
                                                     ? string.Format("работы склада")
                                                     : (string)null;
                            report.SetParameterValue("ProcessName", processName);

                            var originatorName = header.Type_Printed_Form == 1 || header.Type_Printed_Form == 2
                                                    ? string.Format("претензия от {0}", header.Debtor_name)
                                                    : header.Type_Printed_Form == 3
                                                        ? string.Format("внутренняя претензия")
                                                        : (string)null;
                            report.SetParameterValue("ComplaintFullName", originatorName);

                            var fileName = dlgSaveToFile.FileName;
                            var idxRTF = fileName.LastIndexOf(".rtf");
                            fileName = string.Format("{0}.rtf", idxRTF != -1 ? fileName.Remove(idxRTF) : fileName);

                            // Сохранение файла протокола расследования на диск
                            report.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.RichText, fileName);

                            // Попытка открыть файл
                            Thread.Sleep(100);
                            Process.Start(fileName);
                        }
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region ПЕЧАТЬ РЕЕСТРА ЛЕК. СРЕДСТВ

        private void btnPrintMedicalRegister_Click(object sender, EventArgs e)
        {
            ComplaintAnalysisForm.PrintMedicalRegister(sessionID, complaint.Doc_ID);
        }

        public static void PrintMedicalRegister(long sessionID, long docID)
        {
            try
            {
                var today = DateTime.Today;
                var reportData = new Data.Complaints();

                // 1. Детали реестра
                using (var adapter = new Data.ComplaintsTableAdapters.Doc_LSReestr_DetailsTableAdapter())
                    adapter.Fill(reportData.Doc_LSReestr_Details, docID, sessionID);

                using (var report = new ComplaintAnalysisMedicalRegisterReport())
                {
                    report.SetDataSource(reportData);

                    var form = new ReportForm();
                    form.ReportDocument = report;
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void cbChangeComplaintType_CheckedChanged(object sender, EventArgs e)
        {
            cmbComplaintTypes.Enabled = cbChangeComplaintType.Checked;
            if (cbChangeComplaintType.Checked && this.complaintsExt.AvaibleComplaintTypes.Count > 0 && this.complaintsExt.AvaibleComplaintTypes[0].Doc_Type.Equals(string.Empty))
            {
                try
                {
                    avaibleComplaintTypesTableAdapter.Fill(this.complaintsExt.AvaibleComplaintTypes, sessionID, complaint.Doc_Type);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Создадим новую претензию
                if (canCreateSimilarComplaint && cbChangeComplaintType.Checked)
                {
                    if (MessageBox.Show("Вы действительно желаете сменить тип претензии?", "Смена типа претензии", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {

                        var newDocID = (long?)null;
                        var newDocTypeID = cmbComplaintTypes.SelectedValue.ToString();
                        var newDocTypeName = ((cmbComplaintTypes.SelectedItem as DataRowView).Row as Data.ComplaintsExt.AvaibleComplaintTypesRow).Doc_Type_Name;

                        // Создадим претензию с новым типом
                        using (var adapter = new Data.ComplaintsExtTableAdapters.QueriesTableAdapter())
                            adapter.ChangeComplaintType(sessionID, complaint.Doc_ID, newDocTypeID, ref newDocID);

                        // Была создана новая претензия
                        if (newDocID.HasValue)
                        {
                            // Отменим текущую претензию
                            using (var adapter = new Data.ComplaintsTableAdapters.CurrentDocsTableAdapter())
                                adapter.ChangeDocStatus(sessionID, complaint.Doc_ID, ComplaintsConstants.ComplaintStatusAutoClosingDeclined, complaint.Status_ID);

                            MessageBox.Show(string.Format("На основе данной претензии была создана претензия № {0} с типом \"{1}\"!", newDocID, newDocTypeName), "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        // Был изменен тип текущей претензии
                        else
                        {
                            MessageBox.Show(string.Format("В текущей претензии был изменен тип на \"{0}\"!", newDocTypeName), "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                        this.NeedRefresh = true;

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    /// <summary>
    /// Журнал сборки для товара из претензии
    /// </summary>
    public class ComplaintsPickLog : IDataView
    {
        /// <summary>
        /// Время ожидания выполнения запроса
        /// </summary>
        private const int DEFAULT_RESPONSE_TIMEOUT = 600;

        #region IDataView Members

        private PatternColumnsCollection dataColumns = new PatternColumnsCollection();
        public PatternColumnsCollection Columns
        {
            get { return this.dataColumns; }
        }

        private DataTable data;
        public DataTable Data
        {
            get { return this.data; }
        }

        public void FillData(SearchParametersBase searchParameters)
        {
            var searchCriteria = searchParameters as ComplaintsPickLogSearchParameters;

            var docID = searchCriteria.DocID;
            var showAll = searchCriteria.ShowAll;
            var sessionID = searchCriteria.SessionID;
            var showPLK = searchCriteria.ShowPLK;

            using (var adapter = new Data.ComplaintsTableAdapters.ComplaintPickLogTableAdapter())
            {
                adapter.SetTimeout(DEFAULT_RESPONSE_TIMEOUT);
                data = adapter.GetData(docID, showAll, sessionID, showPLK);
            }
        }

        #endregion

        public ComplaintsPickLog()
        {
            this.dataColumns.Add(new PatternColumn("Код", "ItemID", new FilterCompareExpressionRule<Int32>("ItemID"), SummaryCalculationType.Count) { Width = 55 });
            this.dataColumns.Add(new PatternColumn("Название товара", "ItemName", new FilterPatternExpressionRule("ItemName")) { Width = 400 });
            this.dataColumns.Add(new PatternColumn("Статус \"С\"", "StatusFrom", new FilterPatternExpressionRule("StatusFrom"), SummaryCalculationType.Count) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Статус \"По\"", "StatusTo", new FilterPatternExpressionRule("StatusTo"), SummaryCalculationType.Count) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Партия", "LotNumber", new FilterPatternExpressionRule("LotNumber"), SummaryCalculationType.Count) { Width = 170 });
            this.dataColumns.Add(new PatternColumn("Место", "LocationID", new FilterPatternExpressionRule("LocationID"), SummaryCalculationType.Count) { Width = 130 });
            this.dataColumns.Add(new PatternColumn("Сборочный", "PickSlipNumber", new FilterCompareExpressionRule<Int64>("PickSlipNumber"), SummaryCalculationType.Count) { Width = 80 });
            this.dataColumns.Add(new PatternColumn("К-во заказано", "QtyOrdered", new FilterCompareExpressionRule<Decimal>("QtyOrdered")) { Width = 110, UseIntegerNumbersAlignment = true });
            this.dataColumns.Add(new PatternColumn("К-во отказано", "QtyRefused", new FilterCompareExpressionRule<Decimal>("QtyRefused")) { Width = 110, UseIntegerNumbersAlignment = true });
            this.dataColumns.Add(new PatternColumn("Сборщик", "EmployeeName", new FilterPatternExpressionRule("EmployeeName")) { Width = 250 });
            this.dataColumns.Add(new PatternColumn("Дата", "OpDate", new FilterDateCompareExpressionRule("OpDate")) { Width = 100 });
        }
    }

    /// <summary>
    /// Критерий поиска
    /// </summary>
    public class ComplaintsPickLogSearchParameters : SessionIDSearchParameters
    {
        public long? DocID { get; set; }
        public bool? ShowAll { get; set; }
        public bool? ShowPLK { get; set; }
    }


    /// <summary>
    /// Представление для весового контроля
    /// </summary>
    public class ComplaintsWeightControlView : IDataView 
    { 
        /// <summary>
        /// Время ожидания выполнения запроса
        /// </summary>
        private const int DEFAULT_RESPONSE_TIMEOUT = 600;

        #region IDataView Members

        private PatternColumnsCollection dataColumns = new PatternColumnsCollection();
        public PatternColumnsCollection Columns
        {
            get { return this.dataColumns; }
        }

        private DataTable data;
        public DataTable Data
        {
            get { return this.data; }
        }

        public void FillData(SearchParametersBase searchParameters)
        {
            var searchCriteria = searchParameters as ComplaintsWeightControlViewSearchParameters;

            var docID = searchCriteria.DocID;
            var showAll = searchCriteria.ShowAll;
            var sessionID = searchCriteria.SessionID;

            using (var adapter = new Data.ComplaintsTableAdapters.WeightControlAnalysisInfoTableAdapter())
                data = adapter.GetData(docID, sessionID, showAll);
        }

        #endregion

        public ComplaintsWeightControlView()
        {
            this.dataColumns.Add(new SelectorPatternColumn("Отм.", "IsChecked", new FilterBoolCompareExpressionRule("IsChecked"), SummaryCalculationType.Custom) { Width = 35 });

            this.dataColumns.Add(new PatternColumn("Сборочный", "PickNumber", new FilterCompareExpressionRule<Int64>("PickNumber"), SummaryCalculationType.Count) { }); // Width = 69

            this.dataColumns.Add(new PatternColumn("Код", "ItemID", new FilterCompareExpressionRule<Int32>("ItemID"), SummaryCalculationType.Count) { }); // Width = 32
            this.dataColumns.Add(new PatternColumn("Название товара", "ItemName", new FilterPatternExpressionRule("ItemName")) { }); // Width = 91

            this.dataColumns.Add(new PatternColumn("К-во", "ItemQty", new FilterCompareExpressionRule<Int32>("ItemQty"), SummaryCalculationType.Sum) { UseIntegerNumbersAlignment = true }); // Width = 35

            this.dataColumns.Add(new PatternColumn("Вес строки, г", "ItemAvgWghtLn", new FilterCompareExpressionRule<Decimal>("ItemAvgWghtLn"), SummaryCalculationType.Sum) { UseDecimalNumbersAlignment = true, Format = "N3" }); // Width = 66
            
            this.dataColumns.Add(new PatternColumn("Допуст. отклонение по строке, г", "WghtConfidInter", new FilterCompareExpressionRule<Decimal>("WghtConfidInter"), SummaryCalculationType.None) { UseDecimalNumbersAlignment = true, Format = "N3" }); // Width = 120
            this.dataColumns.Add(new PatternColumn("Допуст. отклонение по сборочному, г", "WghtSumConfid", new FilterCompareExpressionRule<Decimal>("WghtSumConfid"), SummaryCalculationType.None) { UseDecimalNumbersAlignment = true, Format = "N3" }); // Width = 120

            this.dataColumns.Add(new PatternColumn("Расчет. вес сборочного (с контейнером), г", "PlanPickWght", new FilterCompareExpressionRule<Decimal>("PlanPickWght"), SummaryCalculationType.None) { UseDecimalNumbersAlignment = true, Format = "N3" }); // Width = 133
            this.dataColumns.Add(new PatternColumn("Факт. вес сборочного (получ. с весов), г", "FactPickWght", new FilterCompareExpressionRule<Decimal>("FactPickWght"), SummaryCalculationType.None) { UseDecimalNumbersAlignment = true, Format = "N3" }); // Width = 155

            this.dataColumns.Add(new PatternColumn("Разница весов, г", "DeltaWght", new FilterCompareExpressionRule<Decimal>("DeltaWght"), SummaryCalculationType.None) { UseDecimalNumbersAlignment = true, Format = "N3" }); // Width = 90

            this.dataColumns.Add(new PatternColumn("Вес 1 шт.\nпри расчете, г", "ItemAvgWght", new FilterCompareExpressionRule<Decimal>("ItemAvgWght"), SummaryCalculationType.None) { UseDecimalNumbersAlignment = true, Format = "N3" }); // Width = 133
            this.dataColumns.Add(new PatternColumn("Вес 1 шт\nОБВХ, г", "ItemOBVXWght", new FilterCompareExpressionRule<Decimal>("ItemOBVXWght"), SummaryCalculationType.None) { UseDecimalNumbersAlignment = true, Format = "N3" }); // Width = 133
            this.dataColumns.Add(new PatternColumn("Вес 1 шт\nактуальный, г", "ItemActualWght", new FilterCompareExpressionRule<Decimal>("ItemActualWght"), SummaryCalculationType.None) { UseDecimalNumbersAlignment = true, Format = "N3" }); // Width = 133
            this.dataColumns.Add(new PatternColumn("Дельта\nпо строке, г", "ItemAvgOBVXDelta", new FilterCompareExpressionRule<Decimal>("ItemAvgOBVXDelta"), SummaryCalculationType.None) { UseDecimalNumbersAlignment = true, Format = "N3" }); // Width = 133
        }
    }

    /// <summary>
    /// Критерий поиска
    /// </summary>
    public class ComplaintsWeightControlViewSearchParameters : SessionIDSearchParameters
    {
        public long? DocID { get; set; }
        public bool? ShowAll { get; set; }
    }


    /// <summary>
    /// Представление для истории статусов
    /// </summary>
    public class ComplaintStatusLogView : IDataView
    {
        /// <summary>
        /// Время ожидания выполнения запроса
        /// </summary>
        private const int DEFAULT_RESPONSE_TIMEOUT = 600;

        #region IDataView Members

        private PatternColumnsCollection dataColumns = new PatternColumnsCollection();
        public PatternColumnsCollection Columns
        {
            get { return this.dataColumns; }
        }

        private DataTable data;
        public DataTable Data
        {
            get { return this.data; }
        }

        public void FillData(SearchParametersBase searchParameters)
        {
            var searchCriteria = searchParameters as ComplaintStatusLogViewSearchParameters;

            var docID = searchCriteria.DocID;
            var sessionID = searchCriteria.SessionID;

            using (var adapter = new Data.ComplaintsTableAdapters.ComplaintsStatusLogTableAdapter())
                data = adapter.GetData(docID, sessionID);
        }

        #endregion

        public ComplaintStatusLogView()
        {
            this.dataColumns.Add(new PatternColumn("Тип", "Doc_type", new FilterPatternExpressionRule("Doc_type"), SummaryCalculationType.TotalRecords));
            this.dataColumns.Add(new PatternColumn("Название типа", "doc_type_name", new FilterPatternExpressionRule("doc_type_name")) { Width = 250 });

            this.dataColumns.Add(new PatternColumn("Код", "Status_ID", new FilterCompareExpressionRule<Int32>("Status_ID"), SummaryCalculationType.TotalRecords));
            this.dataColumns.Add(new PatternColumn("Название статуса", "Status_Name", new FilterPatternExpressionRule("Status_Name")) { Width = 250 });

            this.dataColumns.Add(new PatternColumn("Дата изменения", "date_change", new FilterDateCompareExpressionRule("date_change")) { Width = 130 });
            this.dataColumns.Add(new PatternColumn("Пользователь", "User_change", new FilterPatternExpressionRule("User_change")) { Width = 150 });
        }
    }

    /// <summary>
    /// Критерий поиска
    /// </summary>
    public class ComplaintStatusLogViewSearchParameters : SessionIDSearchParameters
    {
        public long? DocID { get; set; }
    }
}
