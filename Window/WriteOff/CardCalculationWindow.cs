using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Dialogs.WH;
using WMSOffice.Data;
using WMSOffice.Data.WFTableAdapters;
using System.Xml;
using System.IO;
using System.Net;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.Net.Mail;
using System.Net.Mime;
using System.Data.SqlClient;

namespace WMSOffice.Window.WriteOff
{
    public partial class CardCalculationWindow : Form
    {
        const string STR_OutFilePath = @"\\dl2\fs";

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm waitProcessForm = new WMSOffice.Dialogs.SplashForm();

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private int sessionId;

        /// <summary>
        /// Название таблицы со строками в макете в конфигурационном файле
        /// </summary>
        private string ConfigLinesTableName { get { return String.Format("{0}_Lines", Name); } }

        private string MailCopyTo;

        private bool isSend
        {
            get
            {

                var con = new SqlConnection(Properties.Settings.Default.JDE_PROCConnectionString);
                using (SqlCommand command = new SqlCommand("SELECT [dbo].[WF_is_send] (@Doc_id)", con))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@Doc_id", SelectedDoc.Doc_ID);//@seed_date is the param name

                    con.Open();
                    object res = command.ExecuteScalar(); //res is always null 

                    con.Close();
                    if (res != null)
                    {
                        bool hasSend = false;
                        if (bool.TryParse(res.ToString(), out hasSend))
                            return hasSend;
                    }
                }

                return false;
            }
        }

        /// <summary>
        /// Выбранный макет списания в таблице либо null, если таблица пустая или в ней ничего не выбрано.
        /// Если в таблице выделено несколько макетов, то возвращается первый из них
        /// </summary>
        private WH.WF_GetDocsRow SelectedDoc { get; set; }

        string DocType;
        public CardCalculationWindow(int pUserId, WH.WF_GetDocsRow selectedDoc)
        {
            InitializeComponent();

            try
            {
                SelectedDoc = selectedDoc;
                sessionId = pUserId;
                InitializeCardCalculationGrid();

                var dc = new WMSOffice.Data.WHTableAdapters.WF_GetJDEDocTypesTableAdapter();
                var dt = dc.GetData(sessionId);

                if (!SelectedDoc.IsJDE_Doc_TypeNull())
                    foreach (WMSOffice.Data.WH.WF_GetJDEDocTypesRow item in dt.Rows)
                    {
                        if (item.DocType != SelectedDoc.JDE_Doc_Type)
                            continue;

                        DocType = item.Desc;
                        break;
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Начальная инициализация фильтруемого грида с остатками
        /// </summary>
        private void InitializeCardCalculationGrid()
        {
            if (SelectedDoc == null)
                return;

            Binding binding = new Binding("Text", SelectedDoc, "Doc_ID");
            tbAct_Number.DataBindings.Add(binding);

            binding = new Binding("Text", SelectedDoc, "Desc");
            tbDesc.DataBindings.Add(binding);

            binding = new Binding("Text", SelectedDoc, "Doc_Type");
            tbDoc_Type.DataBindings.Add(binding);

            // binding = new Binding("Text", SelectedDoc, "DocDate");
            tbDocDate.Text = SelectedDoc.DocDate.ToString("dd.MM.yyyy HH:mm");

            binding = new Binding("Text", SelectedDoc, "User");
            tbUser.DataBindings.Add(binding);

            binding = new Binding("Text", SelectedDoc, "Warehouse");
            tbWarehouse.DataBindings.Add(binding);

            dgvDocLines.Init(new CardCalculationView(!isSend), true);

            dgvDocLines.LargeAmountOfData = true;
            dgvDocLines.LoadExtraDataGridViewSettings(ConfigLinesTableName);
            dgvDocLines.UserID = sessionId;
            //dgvDocLines.SetCellStyles(dgvRemains.RowTemplate.DefaultCellStyle, dgvRemains.ColumnHeadersDefaultCellStyle);
            dgvDocLines.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvDocLines.AllowRangeColumns = true;
            dgvDocLines.UseMultiSelectMode = true;

            //dgvDocLines.OnFilterChanged += dgvRemains_OnFilterChanged;
            //dgvDocLines.OnRowSelectionChanged += dgvDocLines_OnRowSelectionChanged;

            //PrepareData();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            PrepareData();
        }

        private void PrepareData()
        {
            BackgroundWorker loadWorker = new BackgroundWorker();

            loadWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    var searchCriteria = e.Argument as CardCalculationSearchParameters;
                    dgvDocLines.DataView.FillData(searchCriteria);

                    //var ds = new CardCalculationView(!isSend);
                    //ds.FillData(new CardCalculationSearchParameters { Doc_ID = SelectedDoc.Doc_ID, SessionID = sessionId });
                    //dgvDocLines.Init(ds, true);
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            };
            loadWorker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Result is Exception)
                    MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    dgvDocLines.BindData(false);

                    SetEnableControls();

                    if (dgvDocLines.DataView.Data.Rows.Count > 0)
                    {
                        WF.CompensationDetailsRow item = dgvDocLines.DataView.Data.Rows[0] as WF.CompensationDetailsRow;
                        if (item != null)
                        {
                            tbVendor.Text = item.Поставщик;
                            tbEmail.Text = item.email;
                            MailCopyTo = item.copy_email;
                        }
                    }
                }

                waitProcessForm.CloseForce();
            };

            waitProcessForm.ActionText = "Подготовка данных. Ждите...";

            var sp = new CardCalculationSearchParameters { Doc_ID = SelectedDoc.Doc_ID, SessionID = sessionId };
            loadWorker.RunWorkerAsync(sp);

            waitProcessForm.ShowDialog();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            RunCalc();
        }

        private void RunCalc()
        {
            BackgroundWorker loadWorker = new BackgroundWorker();

            loadWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    (dgvDocLines.DataView as CardCalculationView).CompensationCalc(SelectedDoc.Doc_ID);

                    var searchCriteria = e.Argument as CardCalculationSearchParameters;
                    dgvDocLines.DataView.FillData(searchCriteria);

                    //var dv = dgvDocLines.DataView as CardCalculationView;
                    //dv.CompensationCalc(SelectedDoc.Doc_ID);
                    //dv.FillData(SelectedDoc.Doc_ID);
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            };
            loadWorker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Result is Exception)
                    MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    var dv = dgvDocLines.DataView as CardCalculationView;
                    dv.AllowEdit = !isSend;
                    dgvDocLines.BindData(true);

                    SetEnableControls();

                    if (dgvDocLines.DataView.Data.Rows.Count > 0)
                    {
                        WF.CompensationDetailsRow item = dgvDocLines.DataView.Data.Rows[0] as WF.CompensationDetailsRow;
                        if (item != null)
                        {
                            tbVendor.Text = item.Поставщик;
                            tbEmail.Text = item.email;
                            MailCopyTo = item.copy_email;
                        }
                    }
                }

                waitProcessForm.CloseForce();
            };

            waitProcessForm.ActionText = "Выполняется расчет. Ждите...";

            var sp = new CardCalculationSearchParameters { Doc_ID = SelectedDoc.Doc_ID, SessionID = sessionId };
            loadWorker.RunWorkerAsync(sp);

            waitProcessForm.ShowDialog();
        }

        private void btnEditDict_Click(object sender, EventArgs e)
        {
            #region obsolete
            //WF.AttachmentsDataTable dt = null;
            //using (var adapter = new AttachmentsTableAdapter())
            //    dt = adapter.GetData(SelectedDoc.Doc_ID);

            //if (dt == null)
            //    return;

            //CardCalcAttachmentWindow wnd = new CardCalcAttachmentWindow() { Data = dt };
            //if (wnd.ShowDialog() != DialogResult.OK)
            //    return;

            //using (var adapter = new CompensationDetailsTableAdapter())
            //{
            //    var desc = wnd.Description;
            //    var items = wnd.Items;

            //    bool allowDesc = true;
            //    foreach (ListViewItem item in items)
            //    {
            //        if (item.Tag == null)
            //            continue;

            //        var fi = item.Tag as FileInfo;
            //        if (fi == null)
            //            return;

            //        var destFile = fi.CopyTo(Path.Combine(STR_OutFilePath, fi.Name));

            //        adapter.SaveAttachment(SelectedDoc.Doc_ID, destFile.FullName, desc, sessionId, allowDesc);

            //        allowDesc = false;
            //    }
            //}
            #endregion

            var frmCardCalculationEdit = new CardCalculationEditForm() { DocID = SelectedDoc.Doc_ID, UserID = sessionId };
            if (frmCardCalculationEdit.ShowDialog() == DialogResult.OK)
            {
                //SelectedDoc.Status_ID = 125;
                SetEnableControls();
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbEmail.Text))
                return;

            string fileName = String.Format("Расчет компенсации ({0}).xlsx", SelectedDoc.Doc_ID);
            var fileTemPath = Path.Combine(Path.GetTempPath(), fileName);
            CreateFile(fileTemPath, false);
            var sendComplete = SendMail(fileTemPath);

            try
            {
                if (File.Exists(fileTemPath))
                    File.Delete(fileTemPath);
            }
            catch (Exception) { }

            if (!sendComplete)
                return;

            //string outFile = Path.Combine(STR_OutFilePath, fileName);
            //CreateFile(outFile, true);
            using (var adapter = new CompensationDetailsTableAdapter())
                adapter.SaveFilePath(SelectedDoc.Doc_ID, null);

            MessageBox.Show("Расчет успешно отправлен.", "Отправка поставщику", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CreateFile(string outFile, bool toDirectum)
        {
           CardCalculationWindow.CreateFile(outFile, toDirectum, dgvDocLines.DataView.Data, false);
        }

        public static void CreateFile(string outFile, bool toDirectum, DataTable data, bool isConsolid)
        {
            MemoryStream stream = new MemoryStream(Properties.Resources.WF_CalcTemp);

            XSSFWorkbook templateWorkbook = new XSSFWorkbook(stream);
            var sheet = templateWorkbook.GetSheet("Лист1");

            var fontBold = templateWorkbook.CreateFont();
            fontBold.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;

            var format = templateWorkbook.CreateDataFormat();

            var percentageFormat2 = format.GetFormat("0.00%");
            var percentageStyle2 = templateWorkbook.CreateCellStyle();
            percentageStyle2.DataFormat = percentageFormat2;

            var percentageFormat4 = format.GetFormat("0.0000%");
            var percentageStyle4 = templateWorkbook.CreateCellStyle();
            percentageStyle4.DataFormat = percentageFormat4;

            var numericFormat = format.GetFormat("#,##0.00");
            var numericStyle = templateWorkbook.CreateCellStyle();
            numericStyle.DataFormat = numericFormat;
            numericStyle.SetFont(fontBold);

            int rowNum = 1;
            foreach (WF.CompensationDetailsRow item in data.Rows)
            {
                try
                {
                    IRow row = sheet.CreateRow(rowNum);
                    row.CreateCell(0).SetCellValue(item.Макет_списания); 
                    row.CreateCell(1).SetCellValue(item.___акта_несоответствия);
                    row.CreateCell(2).SetCellValue(item.Производитель);
                    row.CreateCell(3).SetCellValue(item.Тип_компенсации);
                    row.CreateCell(4).SetCellValue(item.Дата_расчета_компенсации.ToString("dd.MM.yyyy"));
                    row.CreateCell(5).SetCellValue(item.Код_товара);
                    row.CreateCell(6).SetCellValue(item.Название_товара);
                    row.CreateCell(7).SetCellValue(item.Серия);
                    row.CreateCell(8).SetCellValue(item.Партия);
                    row.CreateCell(9).SetCellValue(item.Срок_годности.ToString("dd.MM.yyyy"));
                    row.CreateCell(10).SetCellValue(item._Номер_инвойса_накладной);
                    row.CreateCell(11).SetCellValue(item._Дата_инвойса_накладной.ToString("dd.MM.yyyy"));

                    if (toDirectum)
                        row.CreateCell(12).SetCellValue(item.Количество);
                    else
                        row.CreateCell(12).SetCellValue(item.Количество_расчета);

                    row.CreateCell(13).SetCellValue(item.Валюта);
                    row.CreateCell(14).SetCellValue((double)item.Цена_брутто);
                    row.CreateCell(15).SetCellValue(item._Вес_1_уп__кг);
                    row.CreateCell(16).SetCellValue(item.Курс_НБУ);

                    row.CreateCell(17).SetCellValue((double)item._Скидка___ / 100.0);
                    row.GetCell(17).CellStyle = percentageStyle4;

                    row.CreateCell(18).SetCellValue((double)item._Уценка___ / 100.0);
                    row.GetCell(18).CellStyle = percentageStyle4;

                    row.CreateCell(19).SetCellValue((double)item._Пошлина___ / 100.0);
                    row.GetCell(19).CellStyle = percentageStyle2;

                    row.CreateCell(20).SetCellValue(item._НДС___ / 100.0);
                    row.GetCell(20).CellStyle = percentageStyle2;

                    row.CreateCell(21).SetCellValue((double)item._НР___ / 100.0);
                    row.GetCell(21).CellStyle = percentageStyle2;

                    row.CreateCell(22).SetCellValue((double)item._Стоимость_уничтожения_грн__1_кг);

                    row.CreateCell(23).SetCellValue((double)item._ВУ___ / 100.0);
                    row.GetCell(23).CellStyle = percentageStyle2;

                    row.CreateCell(24).SetCellValue((double)item._НПП___ / 100.0);
                    row.GetCell(24).CellStyle = percentageStyle2;

                    //row.CreateCell(25).SetCellValue(toDirectum ? item.ИТОГО : item.ИТОГО_Расчета);

                    var formulaBrutto = string.Format("M{0}*ROUND((O{0}*(1-R{0}-S{0})+O{0}*T{0}+O{0}*(1+T{0})*U{0}+(O{0}*(1-R{0}-S{0})*(1+T{0})*(1+U{0}))*V{0}+P{0}*W{0}/Q{0}+O{0}*X{0})/(1-Y{0}),2)", rowNum + 1);
                    var formulaNetto = string.Format("M{0}*ROUND((O{0}*(1-R{0}-S{0})+O{0}*(1-R{0})*T{0}+O{0}*(1-R{0})*(1+T{0})*U{0}+(O{0}*(1-R{0}-S{0})*(1+T{0})*(1+U{0}))*V{0}+P{0}*W{0}/Q{0}+O{0}*(1-R{0}-S{0})*X{0})/(1-Y{0}),2)", rowNum + 1);

                    var priceType = item.PriceType;

                    var formula = priceType == 0 ? formulaBrutto : formulaNetto;
                    row.CreateCell(25).SetCellFormula(formula);

                    row.GetCell(25).CellStyle = numericStyle;

                    //if (isConsolid)
                    //    row.CreateCell(0).SetCellValue(item.Макет_списания);

                    rowNum++;
                }
                catch (Exception)
                {

                }
            }

            //if (isConsolid)
            //// шапка с номерами макетов (уже статическая)
            //{
            //    //IRow rowHeader = sheet.GetRow(0);

            //    //var prevCell = rowHeader.GetCell(24);

            //    //var cell = rowHeader.CreateCell(25);
            //    //prevCell.CopyCellTo(25);

            //    //cell.SetCellValue("Макет списания");
            //}
            //else

            // сумматор колонки ИТОГО
            //{
            IRow rowSum = sheet.CreateRow(rowNum);
            ICell cell = rowSum.CreateCell(25);
            cell.SetCellFormula(String.Format("SUM(Z2:Z{0})", rowNum));
            rowSum.GetCell(25).CellStyle = numericStyle;
            //cell.CellStyle.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.Pink.Index;
            //}

            var columnsCount = 26; // isConsolid ? 26 : 25;
            for (int i = 0; i < columnsCount; i++)
                sheet.AutoSizeColumn(i);

            FileStream file = new FileStream(outFile, FileMode.Create);
            templateWorkbook.Write(file);

            file.Close();
            file.Dispose();

            stream.Close();
            stream.Dispose();
        }

        private bool SendMail(string fileAttach)
        {
            try
            {
                if (String.IsNullOrEmpty(tbEmail.Text))
                    return false;

                //var client = new SmtpClient() { Host = "smtp.optima.kiev.ua" };
                //client.Credentials = new NetworkCredential("smtp", "OFFX@ls5");

                var client = new SmtpClient() { Host = "smtp.optimapharm.ua" };
                MailMessage email = new MailMessage();

                var mails = tbEmail.Text.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in mails)
                    email.To.Add(new MailAddress(item));

                if (!String.IsNullOrEmpty(MailCopyTo))
                {
                    var cc = MailCopyTo.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var item in cc)
                        email.CC.Add(new MailAddress(item));
                }

                email.From = new MailAddress("sqlmail@optimapharm.ua", "СП 'Оптима-Фарм, ЛТД'");
                email.Subject = String.Format("Запрос на получение компенсации по причине \"{0}({1}) {2}\"", String.IsNullOrEmpty(DocType) ? String.Empty : DocType.Trim(), SelectedDoc.Doc_ID, tbVendor.Text);
                email.IsBodyHtml = true;

                ImageConverter ic = new ImageConverter();
                byte[] _buffer = (byte[])ic.ConvertTo(Properties.Resources.logo, typeof(byte[]));

                var inline = new LinkedResource(new MemoryStream(_buffer), "image/png");
                inline.ContentId = Guid.NewGuid().ToString();

                var responsibleUser = SelectedDoc.IsResponsibleUserNull() ? string.Empty : SelectedDoc.ResponsibleUser;

                string msgBody = String.Format(Properties.Resources.WF_EmailMessageCalc, inline.ContentId, responsibleUser);

                var view = AlternateView.CreateAlternateViewFromString(msgBody, null, "text/html");
                view.LinkedResources.Add(inline);
                email.AlternateViews.Add(view);

                var attach = new Attachment(fileAttach);
                email.Attachments.Add(attach);

                client.Send(email);

                attach.Dispose();
                email.Dispose();
                client = null;

                return true;
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException ?? ex;
                MessageBox.Show(msg.Message, "Отправка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void SetEnableControls()
        {
            var hasRows = dgvDocLines.DataView.Data.Rows.Count > 0;

            btnCalc.Enabled = hasRows && !isSend;
            btnSend.Enabled = hasRows; // && !(SelectedDoc.Status_ID == 125 || SelectedDoc.Status_ID == 126)
            btnEditDict.Enabled = hasRows && (SelectedDoc.Status_ID == 110 || SelectedDoc.Status_ID == 120);
        }

        #region КЛАССЫ ДЛЯ РЕАЛИЗАЦИИ ФИЛЬТРУЕМОГО ГРИДА С МАКЕТАМИ СПИСАНИЯ

        /// <summary>
        /// Представление для грида с остатками на непродажных складах
        /// </summary>
        public class CardCalculationView : IDataView
        {

            public bool AllowEdit { get; set; }

            /// <summary>
            /// Коллекция отображаемых колонок
            /// </summary>
            private PatternColumnsCollection dataColumns = new PatternColumnsCollection();

            /// <summary>
            /// Коллекция отображаемых колонок
            /// </summary>
            public PatternColumnsCollection Columns { get { return dataColumns; } }

            /// <summary>
            /// Источник данных для представления
            /// </summary>
            private DataTable data;

            /// <summary>
            /// Источник данных для представления
            /// </summary>
            public DataTable Data { get { return data; } }

            /// <summary>
            /// Получение источника данных согласно критериям поиска
            /// </summary>
            /// <param name="pSearchParameters">Критерии поиска</param>
            public void FillData(SearchParametersBase pSearchParameters)
            {
                var par = pSearchParameters as CardCalculationSearchParameters;
                if (par == null)
                    return;

                FillData(par.Doc_ID);
            }

            /// <summary>
            /// Пересчитать
            /// </summary>
            /// <param name="doc_ID">Документ</param>
            public void CompensationCalc(long doc_ID)
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml("<Details></Details>");
                XmlElement xRoot = xDoc.DocumentElement;
                foreach (WF.CompensationDetailsRow item in Data.Rows)
                {
                    var xElement = xDoc.CreateElement("Item");

                    var xValue = xElement.Attributes.Append(xDoc.CreateAttribute("Line_ID"));
                    xValue.Value = item.Line_ID.ToString();

                    xValue = xElement.Attributes.Append(xDoc.CreateAttribute("Quantity"));
                    xValue.Value = item.Количество_расчета.ToString();

                    xValue = xElement.Attributes.Append(xDoc.CreateAttribute("act_number"));
                    xValue.Value = item.act_number;

                    //var xValue = xDoc.CreateElement("Line_ID");
                    //xValue.InnerText = item.Line_ID.ToString();
                    //xElement.AppendChild(xValue);


                    //xValue = xDoc.CreateElement("Quantity");
                    //xValue.InnerText = item.Количество_расчета.ToString();
                    //xElement.AppendChild(xValue);

                    xRoot.AppendChild(xElement);
                }

                var docId = (int)doc_ID;
                using (var adapter = new CompensationDetailsTableAdapter())
                    adapter.CompensationCalc(docId, xDoc.InnerXml);
            }

            /// <summary>
            /// Наполнение источника данных с внешнего источника
            /// </summary>
            /// <param name="pTable">Внешний источник</param>
            public void FillData(DataTable pTable)
            {
                data = pTable;
            }

            /// <summary>
            /// Наполнение источника данных с внешнего источника
            /// </summary>
            /// <param name="pTable">Внешний источник</param>
            public void FillData(long Doc_ID)
            {
                var docId = (int)Doc_ID;
                using (var adapter = new CompensationDetailsTableAdapter())
                    data = adapter.GetData(docId);
            }

            public static DataTable GetDataCons(string sConsDocs)
            {
                using (var adapter = new CompensationDetailsTableAdapter())
                    return adapter.GetDataCons(sConsDocs);
            }

            public CardCalculationView(bool allowEdit)
            {
                AllowEdit = allowEdit;

                this.dataColumns.Add(new PatternColumn("№ Акта", "act_number", new FilterPatternExpressionRule("act_number"), SummaryCalculationType.None) { ReadOnly = !AllowEdit });
                this.dataColumns.Add(new PatternColumn("Производитель", "Производитель", new FilterPatternExpressionRule("Производитель"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("Код поставщика", "Код поставщика", new FilterPatternExpressionRule("Код поставщика"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("Поставщик", "Поставщик", new FilterPatternExpressionRule("Поставщик"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("Тип компенсации", "Тип компенсации", new FilterPatternExpressionRule("Тип компенсации"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("Дата расчета компенсации", "Дата расчета компенсации", new FilterPatternExpressionRule("Дата расчета компенсации"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("Код товара", "Код товара", new FilterPatternExpressionRule("Код товара"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("Наименование товара", "Название товара", new FilterPatternExpressionRule("Название товара"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("Серия", "Серия", new FilterPatternExpressionRule("Серия"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("Партия", "Партия", new FilterPatternExpressionRule("Партия"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("Срок годности", "Срок годности", new FilterPatternExpressionRule("Срок годности"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn(@"Номер инвойса\накладной", "Номер инвойса/накладной", new FilterPatternExpressionRule("Номер инвойса/накладной"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn(@"Дата инвойса\накладной", "Дата инвойса/накладной", new FilterPatternExpressionRule("Дата инвойса/накладной"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("Количество", "Количество", new FilterPatternExpressionRule("Количество"), SummaryCalculationType.None) { UseIntegerNumbersAlignment = true });
                this.dataColumns.Add(new PatternColumn("Количество расчета", "Количество расчета", new FilterPatternExpressionRule("Количество расчета"), SummaryCalculationType.None) { UseIntegerNumbersAlignment = true, ReadOnly = !AllowEdit });
                this.dataColumns.Add(new PatternColumn("Валюта", "Валюта", new FilterPatternExpressionRule("Валюта"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("Цена брутто", "Цена брутто", new FilterPatternExpressionRule("Цена брутто"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("Вес 1 уп, кг", "Вес 1 уп, кг", new FilterPatternExpressionRule("Вес 1 уп, кг"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("Курс НБУ", "Курс НБУ", new FilterPatternExpressionRule("Курс НБУ"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("Скидка, %", "Скидка, %", new FilterPatternExpressionRule("Скидка, %"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("Уценка, %", "Уценка, %", new FilterPatternExpressionRule("Уценка, %"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("Пошлина, %", "Пошлина, %", new FilterPatternExpressionRule("Пошлина, %"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("НДС [Налог на добавленную стоимость], %", "НДС, %", new FilterPatternExpressionRule("НДС, %"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("НР [Накладные расходы], %", "НР, %", new FilterPatternExpressionRule("НР, %"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn(@"Стоимость уничтожения грн.\ 1 кг", "Стоимость уничтожения грн_/1 кг", new FilterPatternExpressionRule("Стоимость уничтожения грн_/1 кг"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("ВУ [Виртуальное уничтожение], % ", "ВУ, %", new FilterPatternExpressionRule("ВУ, %"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("НПП [Налог на прибыль], %", "НПП, %", new FilterPatternExpressionRule("НПП, %"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("Итого", "ИТОГО", new FilterPatternExpressionRule("ИТОГО"), SummaryCalculationType.Sum) { UseDecimalNumbersAlignment = true });
                this.dataColumns.Add(new PatternColumn("Итого расчета", "ИТОГО Расчета", new FilterPatternExpressionRule("ИТОГО Расчета"), SummaryCalculationType.Sum) { UseDecimalNumbersAlignment = true });
                //this.dataColumns.Add(new PatternColumn("№ Акта", "Location_ID", new FilterPatternExpressionRule("Location_ID"), SummaryCalculationType.None));

            }
        }

        /// <summary>
        /// Параметры получения списка макетов списания
        /// </summary>
        public class CardCalculationSearchParameters : SearchParametersBase
        {

            /// <summary>
            /// Идентификатор сессии пользователя
            /// </summary>
            public long SessionID { get; set; }

            /// <summary>
            /// Идентификатор документа
            /// </summary>
            public long Doc_ID { get; set; }


            /// <summary>
            /// Фильтры, которые вводятся в заголовках таблицы
            /// </summary>
            public CreateWriteOffStuffForm.RemainsFilter RemainsFilter { get; set; }
        }

        #endregion
    }
}
