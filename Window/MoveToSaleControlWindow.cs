using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Data;
using WMSOffice.Data.MoveToSaleTableAdapters;
using System.Data.SqlClient;
using System.Diagnostics;
using WMSOffice.Controls.MoveToSale;
using WMSOffice.Dialogs;
using WMSOffice.Reports;
using WMSOffice.Dialogs.MoveToSale;
using WMSOffice.Classes;

namespace WMSOffice.Window
{
    public partial class MoveToSaleControlWindow : WMSOffice.Window.GeneralWindow
    {
        private double qtyBeforeChange;
        private string colLM_LocationBeforeChange;
        private bool FillDetailsOnUpdate = true;
        private MoveToSale.ProblemLocationsDataTable problemLocationsDataTable = null;

        private long? ExternalDocID = null; // ид-р внешнего документа

        public int? RecalcType { get; private set; } // тип пересчета

        public string LM_LocationID { get; private set; } // целевая полка размещения

        public bool ScanControlOnly { get; private set; } // признак контроля через сканирование ЖЭ

        public MoveToSaleControlWindow()
        {
            InitializeComponent();
            tbDocumentScaner.TextChanged += new EventHandler(tbDocumentScanner_TextChanged);
            tbBoxScaner.TextChanged += new EventHandler(tbBoxScaner_TextChanged);

            this.PreparePrintersList();
            this.ExternalDocID = null;
        }

        void tbBoxScaner_TextChanged(object sender, EventArgs e)
        {
            var barcode = tbBoxScaner.Text;
            tbBoxScaner.Text = "";
            tbBoxScaner.Enabled = false;
            pnlDocLines.Hide();
            Application.DoEvents();

            using (var queriesTableAdapter = new QueriesTableAdapter())
            {
                try
                {
                    queriesTableAdapter.AddRowBarcode(DocID, barcode, cmbLevels.SelectedValue.ToString());
                }
                catch (SqlException ex)
                {
                    ShowSqlErrors(ex);
                }
                catch (Exception ex)
                {
                    ShowGenericError(ex, "Ошибка при обработке штрихкода");
                }
            }
            GetDocumentDetails(DocID);
        }

        public MoveToSaleControlWindow(long doc_ID)
            : this()
        {
            this.ExternalDocID = doc_ID;
        }

        private void MoveToSaleControlWindow_Load(object sender, EventArgs e)
        {
            // Если определен ид-р внешнего документа, то запускаем сценарий работы с документом в работе у пользователя
            if (this.ExternalDocID.HasValue)
                GetDocumentHeader(this.ExternalDocID.Value);
        }

        void tbDocumentScanner_TextChanged(object sender, EventArgs e)
        {
            var barcode = tbDocumentScaner.Text;

            using (Data.MoveToSaleTableAdapters.QueriesTableAdapter queriesTableAdapter = new QueriesTableAdapter())
            {
                try
                {
                    long docID = (long)queriesTableAdapter.BarcodeCheck(UserID, barcode);
                    GetDocumentHeader(docID);
                }
                catch (SqlException ex)
                {
                    ShowSqlErrors(ex);
                }
                catch (Exception ex)
                {
                    ShowGenericError(ex, "Ошибка при обработке штрихкода");
                }
                finally
                {
                    tbDocumentScaner.Text = "";
                }
            }
        }

        private void GetDocumentHeader(long docID)
        {
            using (var controlHeaderTableAdapter = new WMSOffice.Data.MoveToSaleTableAdapters.ControlHeaderTableAdapter())
            {
                try
                {
                    var controlHeaderDataTable = controlHeaderTableAdapter.GetData(docID);
                    if (controlHeaderDataTable.Rows.Count != 1)
                    {
                        throw new Exception("Документ не был создан.");
                    }

                    Data.MoveToSale.ControlHeaderRow row = controlHeaderDataTable[0];

                    InitDocument(DocName, row.Doc_ID, row.Doc_Type, row.Doc_Date, "", "");
                    tbDocNo.Text = row.Doc_ID.ToString();
                    tbDocType.Text = row.Doc_Type.ToString();
                    tbDocDate.Text = row.Doc_Date.ToShortDateString();
                    tbDocWarehouse.Text = row.Warehouse_id.ToString();
                    tbRelDocNo.Text = row.Related_Doc_ID.ToString();
                    tbRelDocType.Text = row.Related_Doc_Type.ToString();

                    // Тип пересчета
                    this.RecalcType = row.IsRecalcTypeNull() ? (int?)null : row.RecalcType;

                    // Целевая полка размещения
                    this.LM_LocationID = row.IsLM_LocationIDNull() ? (string)null : row.LM_LocationID;

                    // Запрет на ввод количества (режим сканирования ЖЭ)
                    if (this.RecalcType.HasValue && this.RecalcType.Value == 1)
                    {
                        this.ScanControlOnly = true;
                        lblScanItemsOnly.Visible = true;
                        this.colFactQtyVisible.ReadOnly = true;
                    }

                    // Попытка загрузки уровней
                    this.LoadLevels();

                    pnlBarcode.Hide();
                    pnlDocumentheader.Show();
                    GetDocumentDetails(docID);
                }
                catch (SqlException ex)
                {
                    ShowSqlErrors(ex);
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка доступа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    ShowGenericError(ex, "Ошибка при обработке штрихкода");
                }
            }
        }

        /// <summary>
        /// Загрузка уровней
        /// </summary>
        private void LoadLevels()
        {
            try
            {
                this.levelsBindingSource.DataSource = null;
                var levels = this.levelsTableAdapter.GetData(this.UserID, this.DocID);
                
                if (levels.Count == 0)
                    throw new InvalidOperationException("Для совершения требуемого действия у Вас нет прав доступа");

                this.levelsBindingSource.DataSource = levels;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void GetDocumentDetails(long docID)
        {
            using (var controlDetailsTableAdapter = new ControlDetailsTableAdapter())
            {
                try
                {
                    Data.MoveToSale.ControlDetailsDataTable controlDetailsDataTable = controlDetailsTableAdapter.GetData(docID);
                    dgvDetails.DataSource = controlDetailsDataTable;
                    pnlDocLines.Show();
                    pnlFooter.Show();
                    //
                    pnlDocLines.Location = new Point(0, pnlDocumentheader.Height + 40);
                    pnlDocLines.Size = new Size(this.ClientRectangle.Width, this.ClientRectangle.Height - pnlDocumentheader.Height - pnlFooter.Height - 40);
                    //
                    tbBoxScaner.Enabled = true;
                    Application.DoEvents();
                    tbBoxScaner.Focus();
                }
                catch (SqlException ex)
                {
                    ShowSqlErrors(ex);
                }
                catch (Exception ex)
                {
                    ShowGenericError(ex, "Ошибка при получении строк документа");
                }
            }
        }

        private void ShowSqlErrors(SqlException ex)
        {
            StringBuilder errorMessages = new StringBuilder();
            for (int i = 0; i < ex.Errors.Count; i++)
            {
                errorMessages.AppendLine(ex.Errors[i].Message);
            }
            MessageBox.Show(errorMessages.ToString(), "Ошибка обработки данных",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        }

        private void ShowGenericError(Exception ex, string message)
        {
            MessageBox.Show(ex.Message, message,
                MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        }

        private void dgvDetails_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < dgvDetails.RowCount)
            {
                var row = dgvDetails.Rows[e.RowIndex];
                try
                {
                    //Define color
                    string colorString = row.Cells["colColor"].Value.ToString();
                    row.DefaultCellStyle.BackColor = Color.FromName(colorString);

                    //Set actual value of quantity in visible unbound field to the value of invisible bound field
                    row.Cells["colFactQtyVisible"].Value = row.Cells["colFactQty"].Value;

                    //Set value of problem locatiob in visible unbound column to the value of inviible bound column
                    row.Cells["colLM_LocationVisible"].Value = row.Cells["colLM_Location"].Value;
                }
                catch (Exception)
                {
                    row.DefaultCellStyle.BackColor = Color.PapayaWhip;
                }
            }
        }

        private void dgvDetails_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetails.Columns[e.ColumnIndex].Name == "colFactQtyVisible")
                double.TryParse(dgvDetails[e.ColumnIndex, e.RowIndex].Value.ToString(), out qtyBeforeChange);

            if (dgvDetails.Columns[e.ColumnIndex].Name == "colLM_LocationVisible")
                colLM_LocationBeforeChange = dgvDetails[e.ColumnIndex, e.RowIndex].Value.ToString();
        }

        private void dgvDetails_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < dgvDetails.RowCount)
            {
                var row = dgvDetails.Rows[e.RowIndex];

                if (dgvDetails.Columns[e.ColumnIndex].Name == "colFactQtyVisible")
                {
                    double qtyAfterChange;

                    if (row.Cells[e.ColumnIndex].Value == null)
                        qtyAfterChange = 0;
                    else
                    {
                        if (!double.TryParse(row.Cells[e.ColumnIndex].Value.ToString(), out qtyAfterChange))
                        {
                            MessageBox.Show("Введено неправильное количество", "Ошибка", MessageBoxButtons.OKCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            return;
                        }
                    }

                    if (qtyAfterChange == qtyBeforeChange)
                        return;

                    qtyBeforeChange = qtyAfterChange;

                    if (FillDetailsOnUpdate)
                    {
                        pnlDocLines.Hide();
                        Application.DoEvents();
                    }

                    using (QueriesTableAdapter queriesTableAdapter = new QueriesTableAdapter())
                    {
                        try
                        {
                            int itemID = (int)row.Cells["colItem_ID"].Value;
                            string lotNumber = row.Cells["colLot_Number"].Value.ToString();
                            queriesTableAdapter.ChangeRowQuantity(DocID, itemID, lotNumber, qtyAfterChange, cmbLevels.SelectedValue.ToString());
                        }
                        catch (SqlException ex)
                        {
                            ShowSqlErrors(ex);
                        }
                        catch (Exception ex)
                        {
                            ShowGenericError(ex, "Ошибка при изменении количества");
                        }
                        finally
                        {
                            if (FillDetailsOnUpdate)
                            {
                                GetDocumentDetails(DocID);
                            }
                        }
                    }
                }

                if (dgvDetails.Columns[e.ColumnIndex].Name == "colLM_LocationVisible")
                {
                    string colLM_LocationAfterChange;

                    if ((row.Cells[e.ColumnIndex].Value is DBNull) || (row.Cells[e.ColumnIndex].Value == null))
                        colLM_LocationAfterChange = "";
                    else
                        colLM_LocationAfterChange = row.Cells[e.ColumnIndex].Value.ToString();

                    if (colLM_LocationAfterChange == colLM_LocationBeforeChange)
                        return;

                    colLM_LocationBeforeChange = colLM_LocationAfterChange;

                    if (FillDetailsOnUpdate)
                    {
                        pnlDocLines.Hide();
                        Application.DoEvents();
                    }

                    using (QueriesTableAdapter queriesTableAdapter = new QueriesTableAdapter())
                    {
                        try
                        {
                            int itemID = (int)row.Cells["colItem_ID"].Value;
                            string lotNumber = row.Cells["colLot_Number"].Value.ToString();
                            queriesTableAdapter.ChangeRowProblemLocation(DocID, itemID, lotNumber, colLM_LocationAfterChange);
                        }
                        catch (SqlException ex)
                        {
                            ShowSqlErrors(ex);
                        }
                        catch (Exception ex)
                        {
                            ShowGenericError(ex, "Ошибка при изменении проблемной полки");
                        }
                        finally
                        {
                            if (FillDetailsOnUpdate)
                            {
                                GetDocumentDetails(DocID);
                            }
                        }
                    }
                }
            }
        }

        private void btnCloseDoc_Click(object sender, EventArgs e)
        {
            CommitDocument(true);
        }

        private void btnCreateTask_Click(object sender, EventArgs e)
        {
            CommitDocument(false);
        }

        /// <summary>
        /// Performs complete control documant validation and then commits this document
        /// </summary>
        private void CommitDocument(bool closeDoc)
        {
            try
            {
                int? newUserID = this.UserID;

                if (closeDoc)
                {
                    if (this.ScanControlOnly)
                    {
                        if (!CheckProblemLocationsForScanYLMode())
                            return;
                    }
                    else
                    {
                        if (!CheckProblemLocations(out newUserID))
                            return;
                    }
                }

                List<Int64> jobs = new List<Int64>(); // список заданий

                WMSOffice.Data.MoveToSale.CloseDocDataTable docs = null;
                using (var adapter = new Data.MoveToSaleTableAdapters.CloseDocTableAdapter())
                {
                    try
                    {
                        docs = closeDoc ? adapter.GetAllTasksDocs(DocID, newUserID) : adapter.GetSingleTaskDocs(DocID, newUserID);
                        foreach (WMSOffice.Data.MoveToSale.CloseDocRow row in docs)
                            jobs.Add(row.WM_DOC_ID);
                    }
                    catch (SqlException ex)
                    {
                        ShowSqlErrors(ex);
                    }
                    catch (Exception ex)
                    {
                        ShowGenericError(ex, "Ошибка при получении заданий");
                    }
                }

                if (closeDoc)
                {
                    pnlBarcode.Show();
                    pnlDocumentheader.Hide();
                    pnlDocLines.Hide();
                    pnlFooter.Hide();
                    tbDocumentScaner.Focus();
                    Application.DoEvents();
                    MessageBox.Show("Документ успешно закрыт", "Документ закрыт", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }

                if (jobs.Count == 0)
                {
                    if (!closeDoc)
                        MessageBox.Show("Задания отсутствуют", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }

                if (cmbPrinters.Items.Count == 0)
                {
                    MessageBox.Show("Печать заданий невозможна, поскольку отсутсвуют подключенные принтеры.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                BackgroundWorker printWorker = new BackgroundWorker();
                printWorker.DoWork += new DoWorkEventHandler(printWorker_DoWork);
                printWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(printWorker_RunWorkerCompleted);
                waitProcessForm.ActionText = "Выполняется печать заданий...";

                var parameters = new PrintParameters()
                {
                    Jobs = jobs,
                    PrinterName = cmbPrinters.SelectedItem.ToString()
                };
                printWorker.RunWorkerAsync(parameters);
                waitProcessForm.ShowDialog();

                MessageBox.Show("Задания успешно напечатаны", "Завершение печати заданий", MessageBoxButtons.OK, MessageBoxIcon.Information);


                // Вызов печати ЖЭ
                PrintYL();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Необработанная ошибка окна с кодом ресурса TP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckProblemLocationsForScanYLMode()
        {
            try
            {
                MoveToSale.ControlDetailsDataTable table = controlDetailsTableAdapter.GetData(DocID);

                var errors = new Data.MoveToSale.ControlErrorsDataTable();

                foreach (MoveToSale.ControlDetailsRow item in table)
                {
                    // Если это поле "возврат", то никаких проверок не делаем
                    if (item.Return == 1)
                        continue;

                    var errorType = (string)null;
                    var errorTypeCode = (string)null;

                    // Анализ расхождений
                    if (!item.IsLine_TypeNull() && item.Line_Type == "SP")
                    {
                        errorTypeCode = "SP";
                        errorType = "Излишек";
                    }
                    else if (!item.IsDiffNull() && item.Diff != 0)
                    {
                        errorTypeCode = "SH";
                        errorType = "Недостача";
                    }
                    
                    // Есть расхождения
                    if (!string.IsNullOrEmpty(errorType))
                    {
                        var error = errors.NewControlErrorsRow();

                        if (!item.IsItem_IDNull())
                            error.Item_ID = item.Item_ID;

                        if (!item.IsItemNull())
                            error.Item = item.Item;

                        if (!item.IsVendor_LotNull())
                            error.Vendor_Lot = item.Vendor_Lot;

                        if (!item.IsDiffNull())
                            error.Diff = item.Diff;

                        if (!item.IsLot_NumberNull())
                            error.Lot_Number = item.Lot_Number;

                        error.ErrorTypeCode = errorTypeCode;
                        error.ErrorType = errorType;

                        errors.AddControlErrorsRow(error);
                    }
                }

                if (errors.Rows.Count == 0)
                    return true;

                // Вызываем форму автокоррекции расхождений
                var errorsForm = new MoveToSaleControlErrorsForm(DocID, LM_LocationID, errors);
                if (errorsForm.ShowDialog(this) == DialogResult.OK)
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
                return false;
            }
        }

        /// <summary>
        /// Печать ЖЭ
        /// </summary>
        private void PrintYL()
        {
            try
            {
                List<Data.MoveToSale.ControlDetailsRow> YLrows = new List<MoveToSale.ControlDetailsRow>();

                foreach (DataGridViewRow row in dgvDetails.Rows)
                {
                    var value = row.Cells[dgvcCheckPrintYL.Index].Value;
                    if (true.Equals(value))
                        YLrows.Add((row.DataBoundItem as DataRowView).Row as Data.MoveToSale.ControlDetailsRow);
                }

                string printerName = string.Empty;
                if (YLrows.Count > 0)
                {
                    var level = (cmbLevels.SelectedItem as DataRowView).Row as Data.MoveToSale.LevelsRow;
                    if (level != null)
                    {
                        // Определение принтера
                        using (var adapter = new Data.MoveToSaleTableAdapters.QueriesTableAdapter())
                            adapter.FindYLPrinterName(this.UserID, level.IslvlNull() ? string.Empty : level.lvl, ref printerName);

                        // Запуск печати
                        if (!string.IsNullOrEmpty(printerName))
                            using (var adapter = new Data.MoveToSaleTableAdapters.QueriesTableAdapter())
                                foreach (var row in YLrows)
                                    adapter.PrintYL(row.Item_ID, row.Lot_Number, 1, (int)row.FactQty, this.UserID, printerName, (string)null, (bool?)null, true, (string)null);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Печать ЖЭ была прервана из-за возникшей ошибки:\r\n{0}", ex.Message), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var parameters = e.Argument as PrintParameters;
                foreach (var job in parameters.Jobs)
                    MoveToSaleControlWindow.PrintJob(job, parameters.PrinterName, this.UserID);
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        private void printWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                ShowGenericError(e.Result as Exception, "Ошибка при печати заданий");

            waitProcessForm.CloseForce();
        }

        /// <summary>
        /// Параметры печати
        /// </summary>
        private class PrintParameters
        {
            public String PrinterName { get; set; }
            public List<Int64> Jobs { get; set; }
        }

        private Dialogs.SplashForm waitProcessForm = new WMSOffice.Dialogs.SplashForm();

        /// <summary>
        /// Сформировать список принтеров, выбрать принтер по умолчанию
        /// </summary>
        private void PreparePrintersList()
        {
            try
            {
                foreach (string printerName in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                    cmbPrinters.Items.Add(printerName);

                System.Drawing.Printing.PrinterSettings tmpSettings = new System.Drawing.Printing.PrinterSettings();
                cmbPrinters.SelectedItem = tmpSettings.PrinterName;
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        /// <summary>
        /// Метод печати листа размещения по его идентификатору
        /// </summary>
        /// <param name="moveTaskID"></param>
        public static void PrintJob(long moveTaskID, string printerName)
        {
            PrintJob(moveTaskID, printerName, -1);
        }
        /// <summary>
        /// Метод печати листа размещения по его идентификатору
        /// </summary>
        /// <param name="moveTaskID"></param>
        public static void PrintJob(long moveTaskID, string printerName, long userID)
        {
            try
            {
                // создадим таблицу для данных отчета
                WMove.WM_PutListDataTable putList = new WMove.WM_PutListDataTable();

                // получим данные отчета, штрих-код создан
                InterbranchReceiveWindow.MovePutListPrepare(putList, moveTaskID);

                // напечатаем лист размещения
                WMovePutListReport report = new WMovePutListReport();
                report.SetDataSource((DataTable)putList);

                report.PrintOptions.PrinterName = "";// stickerPrintParameters.PrinterName;
                report.PrintToPrinter(1, false, 1, 0);

                // логирование факта печати
                PrintDocsThread.AddPrintingDocTelemetryData(userID, "TP", 1, Convert.ToInt64(moveTaskID), (string)null, Convert.ToInt16(putList.Count), printerName, 1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Perfoms complete problem locations validation
        /// </summary>
        /// <returns>Returns true if all problem locations are validated and document is ready to be closed</returns>
        private bool CheckProblemLocations(out int? newUserID)
        {
            bool problemLocationsExists = false;
            newUserID = null;

            if (!ProblemLocationsHandled(out problemLocationsExists))
                return false;

            if (problemLocationsExists)
            {
                if (PermissionsValidated(out newUserID))
                    return true;
            }
            else
                return true;

            return false;
        }

        /// <summary>
        /// Checks if all lacks of quantity has corresponding problem locations defined. 
        /// Futher handling must be stopped until all necessary locations are defined.
        /// </summary>
        /// <param name="problemLocationsExists">Returns true if there are at least one problem location in the recordset</param>
        /// <returns>Returns true if all problem locations are defined properly, otherwise returns false</returns>
        private bool ProblemLocationsHandled(out bool problemLocationsExists)
        {
            problemLocationsExists = false;
            using (var controlDetailsTableAdapter = new ControlDetailsTableAdapter())
            {
                try
                {
                    MoveToSale.ControlDetailsDataTable table = controlDetailsTableAdapter.GetData(DocID);
                    foreach (MoveToSale.ControlDetailsRow item in table)
                    {
                        // Если это поле "возврат", то никаких проверок не делаем
                        if (item.Return == 1)
                            continue;

                        //// Излишек не проверяем
                        //if (!item.IsLine_TypeNull() && item.Line_Type == "SP")
                        //    continue;

                        if (!item.IsDiffNull())
                        {
                            if (item.Diff != 0)
                            {
                                problemLocationsExists = true;

                                if (item.IsLM_LocationNull() || (item.LM_Location.Trim() == ""))
                                {
                                    MessageBox.Show("В каждой строке, у которой требуемое количество не совпадает с фактическим количеством, должна быть указана полка недостачи." + Environment.NewLine +
                                        "Укажите полку недостачи для строки:" + Environment.NewLine + Environment.NewLine +
                                        "Код товара:\t" + item.Item_ID.ToString() + Environment.NewLine +
                                        "Наименование:\t" + item.Item + Environment.NewLine +
                                        "Партия:\t\t" + item.Lot_Number,
                                        "Не указана полка недостачи", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                                    return false;
                                }
                            }
                        }
                    }
                    return true;
                }
                catch (SqlException ex)
                {
                    ShowSqlErrors(ex);
                }
                catch (Exception ex)
                {
                    ShowGenericError(ex, "Ошибка при проверке проблемных полок");
                }
                return false;
            }
        }

        /// <summary>
        /// Prompt responsible persons to make authentication and then verifies if they have sufficient permisions to close control document with problem locations
        /// </summary>
        /// <returns>Returns true if authentication succeeded</returns>
        private bool PermissionsValidated(out int? newUserID)
        {
            newUserID = this.UserID;
            return true;

            // TODO Убрана логика повторной авторизации с созданием новой сессии
            //
            #region OBSOLETE
            //newUserID = null;

            //ChangeUserForm changeUserForm = new ChangeUserForm() { CreateTempSession = true };
            //if (changeUserForm.ShowDialog() != DialogResult.OK)
            //    return false;

            //newUserID = changeUserForm.UserID;

            //using (var resourcesBySessionTableAdapter = new WMSOffice.Data.AccessTableAdapters.ResourcesBySessionTableAdapter())
            //{
            //    try
            //    {
            //        var resourcesBySessionDataTable = resourcesBySessionTableAdapter.GetData(changeUserForm.UserID);
            //        foreach (Data.Access.ResourcesBySessionRow item in resourcesBySessionDataTable)
            //        {
            //            if ((item.Module_ID == "WMOVE") && (item.Doc_Type_ID == "LM"))
            //            {
            //                if (MessageBox.Show("Авторизация пройдена успешно." + Environment.NewLine + "Вы действительно хотите разместить недостающий товар на указанных в документе полках недостачи?", "Подтвердите недостачу товара", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            //                {
            //                    return true;
            //                }
            //                else
            //                {
            //                    MessageBox.Show("Вы отказались подтверждать недостачу товара. Документ остался открытым.", "Недостача не подтверждена", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            //                    return false;
            //                }
            //            }
            //        }

            //        MessageBox.Show("К сожалению, Ваших полномочий недостаточно для того, чтобы закрыть недостачу", "Недостаточно полномочий", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
            //        return false;
            //    }
            //    catch (SqlException ex)
            //    {
            //        ShowSqlErrors(ex);
            //    }
            //    catch (Exception ex)
            //    {
            //        ShowGenericError(ex, "Ошибка при проверке прав доступа");
            //    }
            //}
           
            //return false; 
            #endregion
        }

        private void dgvDetails_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }
    }
}
