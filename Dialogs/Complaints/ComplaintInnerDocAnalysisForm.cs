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

namespace WMSOffice.Dialogs.Complaints
{
    /// <summary>
    /// Форма, в которой отображается детальная информация по претензии
    /// </summary>
    public partial class ComplaintInnerDocAnalysisForm : Form
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
        /// Строка, которая выводится в случае, если какая-нибудь информация не задана
        /// </summary>
        private const string NO_INFO_STR = "-";

        /// <summary>
        /// Выделенная в таблице аналитической инфомрации строка либо NULL, если не выбрано ни одной строки либо 
        /// таблица не содержит данных вообще
        /// </summary>
        private Data.ComplaintsExt.AnalysisInfoRow SelectedInfoRow
        {
            get
            {
                if (dgvComplaintDetails.SelectedRows.Count == 0)
                    return null;
                return (dgvComplaintDetails.SelectedRows[0].DataBoundItem as DataRowView).Row
                    as Data.ComplaintsExt.AnalysisInfoRow;
            }
        }

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ КЛАССА

        public ComplaintInnerDocAnalysisForm(Data.Complaints.CurrentDocsRow pDocRow, long pSessionID, 
            bool pCanAddTakingRemainsRequest, bool pCanRequestAttachments)
        {
            if (pDocRow == null)
                throw new ArgumentNullException("Претензия, которая анализируется, равна NULL!");
            InitializeComponent();
            complaint = pDocRow;
            sessionID = pSessionID;
            btnAddTakingRemainsRequest.Enabled = pCanAddTakingRemainsRequest &&
                pDocRow.Doc_Type == Constants.CO_DTFL_MANUFACTURERND || pDocRow.Doc_Type == Constants.CO_DTFL_DEFECT;
            btnAttachmentRequest.Enabled = pCanRequestAttachments;
            CustomCommonInfo();
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
            lblSource.Text = String.Format("({0}) {1} {2}", 
                complaint.Source_Address_Code,
                complaint.IsSource_Address_NameNull() ? (string)null : complaint.Source_Address_Name,
                complaint.IsSource_AddressNull() ? (string)null : complaint.Source_Address);

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
                ((row.DataBoundItem as DataRowView).Row as Data.ComplaintsExt.AnalysisInfoRow).IsChecked = pState;

            dgvComplaintDetails.RefreshEdit();
            //bsAnalysisInfo.ResetBindings(false);
            analysisInfoBindingSource.ResetBindings(false);
        }

        /// <summary>
        /// Загрузка аналитических данных при загрузке окна
        /// </summary>
        private void ComplaintInnerDocAnalysisForm_Load(object sender, EventArgs e)
        {
            StartAnalysisInfoLoading();
        }

        /// <summary>
        /// Обновляет данные в таблице при изменении состояния флажка "Показывать все строки накладной".
        /// </summary>
        private void chkbShowAll_CheckedChanged(object sender, EventArgs e)
        {
            StartAnalysisInfoLoading();
        }

        /// <summary>
        /// Сохранение настроек грида при выходе из окна
        /// </summary>
        private void ComplaintInnerDocAnalysisForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Config.SaveDataGridViewSettings(Name, dgvComplaintDetails);
        }

        #endregion

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
            dgvComplaintDetails.DataSource = null;
            lastWorker.RunWorkerAsync(new object[] { complaint.Doc_ID, chbShowAll.Checked });
        }

        /// <summary>
        /// Асинхронная загрузка аналитической информации
        /// </summary>
        private void lastWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                object[] param = (object[])e.Argument;
                using (var adapter = new Data.ComplaintsExtTableAdapters.AnalysisInfoTableAdapter())
                    e.Result = adapter.GetData((long)param[0], (bool)param[1]);
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
                    complaintsExt.AnalysisInfo.Clear();
                    complaintsExt.AnalysisInfo.Merge(e.Result as DataTable);
                }

                dgvComplaintDetails.DataSource = analysisInfoBindingSource;

                pbWait.Visible = false;
                dgvComplaintDetails.Enabled = true;
                DataGridViewHelper.AutoSetColumnWidths(dgvComplaintDetails);
                Config.LoadDataGridViewSettings(Name, dgvComplaintDetails);
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
            RefreshGuiltyEmployees();
        }

        /// <summary>
        /// Загрузка списка виновных сотрудников
        /// </summary>
        private void RefreshGuiltyEmployees()
        {
            try
            {
                if (SelectedInfoRow != null)
                    complaintLineGuiltyEmployeesTableAdapter.Fill(complaintsExt.ComplaintLineGuiltyEmployees, complaint.First_Doc_ID, SelectedInfoRow.Detail_ID);
                else
                    complaintsExt.ComplaintLineGuiltyEmployees.Clear();
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время загрузки списка виновных сотрудников по выделенной строке:", exc);
                complaintsExt.ComplaintLineGuiltyEmployees.Clear();
            }
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
                        new Data.ComplaintsTableAdapters.AnalysisInfoTableAdapter().AddAttachmentRequest(sessionID, complaint.First_Doc_ID, Convert.ToInt32(row.ItemID));
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
        private void ComplaintInnerDocAnalysisForm_KeyDown(object sender, KeyEventArgs e)
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
    }
}
