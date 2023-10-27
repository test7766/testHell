using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.Custom;
using WMSOffice.Dialogs.Sert;

namespace WMSOffice.Dialogs.Docs
{
    public partial class ArchiveReturnedTareInvoiceForm : DialogForm
    {
        /// <summary>
        /// Масштаб доверенности
        /// </summary>
        private const string ATTORNEY_ZOOM_FACTOR_SETTING_NAME = "Attorney_ZoomFactor";
        /// <summary>
        /// Автомасштабирование доверенности
        /// </summary>
        private const string ATTORNEY_AUTO_ZOOM_ACTIVATED_SETTING_NAME = "Attorney_AutoZoomActivated";
        /// <summary>
        /// Масштаб договора
        /// </summary>
        private const string AGREEMENT_ZOOM_FACTOR_SETTING_NAME = "Agreement_ZoomFactor";
        /// <summary>
        /// Автомасштабирование договора
        /// </summary>
        private const string AGREEMENT_AUTO_ZOOM_ACTIVATED_SETTING_NAME = "Agreement_AutoZoomActivated";

        /// <summary>
        /// Ширина контейнера с разделителем
        /// </summary>
        private const string DOCUMENT_ATTACHMENTS_SPLITTER_DISTANCE_NAME = "DocumentAttachments_SplitterDistance";

        private int documentAttachmentsSplitterDistance = 0;

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        private Button btnDelayOK = null;

        public DateTime InvoiceArchiveDate 
        {
            get { return dtpInvoiceArchiveDate.Value; }
            set { dtpInvoiceArchiveDate.Value = value; }
        }

        public bool IsArchiveModeEnabled { get; private set; }

        public string BarCode { get; private set; }

        public string DocType { get; private set; }
        public double? DocNumber { get; private set; }
        public double? ReceiverCode { get; private set; }
        public string AttorneyNumber { get; private set; }
        
        public bool HasActiveDoc { get { return this.DocNumber.HasValue; } }

        /// <summary>
        /// Признак ручного поиска накладной
        /// </summary>
        public bool ManualSearchMode { get; private set; }

        public ArchiveReturnedTareInvoiceForm()
        {
            InitializeComponent();
            tbsInvoiceBarCode.TextChanged += new EventHandler(tbsInvoiceBarCode_TextChanged);
        }

        public ArchiveReturnedTareInvoiceForm(string docType, double? docNumber)
            : this()
        {
            this.DocType = docType;
            this.DocNumber = docNumber;

            this.ManualSearchMode = true;
        }

        private void ArchiveInvoiceForm_Load(object sender, EventArgs e)
        {
            this.Initialize();
        }

        private void Initialize()
        {
            this.LoadSettings();

            btnDelayOK = this.AddAction("Доработка", () => 
            {
                this.DialogResult = DialogResult.Retry;
            }, 
            false, new Point(1202, 8), AnchorStyles.Right);
        }

        private void LoadSettings()
        {
            try
            {
                var sAttorneyZoomFactor = Config.LoadSetting(this.Name, ATTORNEY_ZOOM_FACTOR_SETTING_NAME);
                var attorneyZoomFactor = 0.0;
                if (double.TryParse(sAttorneyZoomFactor, out attorneyZoomFactor))
                    ivcAttorneys.CurrentZoomFactor = attorneyZoomFactor;

                var sAttorneyAutoZoomActivated = Config.LoadSetting(this.Name, ATTORNEY_AUTO_ZOOM_ACTIVATED_SETTING_NAME);
                var attorneyAutoZoomActivated = false;
                if (bool.TryParse(sAttorneyAutoZoomActivated, out attorneyAutoZoomActivated))
                    ivcAttorneys.AutoZoomActivated = attorneyAutoZoomActivated;

                var sAgreementZoomFactor = Config.LoadSetting(this.Name, AGREEMENT_ZOOM_FACTOR_SETTING_NAME);
                var agreementZoomFactor = 0.0;
                if (double.TryParse(sAgreementZoomFactor, out agreementZoomFactor))
                    ivcAgreements.CurrentZoomFactor = agreementZoomFactor;

                var sAgreementAutoZoomActivated = Config.LoadSetting(this.Name, AGREEMENT_AUTO_ZOOM_ACTIVATED_SETTING_NAME);
                var agreementAutoZoomActivated = false;
                if (bool.TryParse(sAgreementAutoZoomActivated, out agreementAutoZoomActivated))
                    ivcAgreements.AutoZoomActivated = agreementAutoZoomActivated;

                var sDocumentAttachmentsSplitterDistance = Config.LoadSetting(this.Name, DOCUMENT_ATTACHMENTS_SPLITTER_DISTANCE_NAME);
                if (!int.TryParse(sDocumentAttachmentsSplitterDistance, out documentAttachmentsSplitterDistance))
                    documentAttachmentsSplitterDistance = scDocumentWithAttachments.SplitterDistance;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnDelayOK.Enabled = false;

            this.btnOK.Location = new Point(1292, 8);
            this.btnCancel.Location = new Point(1382, 8);

            dtpInvoiceArchiveDate.Enabled = false;

            this.WindowState = FormWindowState.Maximized;

            scDocumentWithAttachments.SplitterDistance = documentAttachmentsSplitterDistance;

            tbsInvoiceBarCode.Focus();

            if (this.ManualSearchMode)
                this.CheckManualInvoice();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                if (btnDelayOK.Enabled)
                {
                    this.DialogResult = DialogResult.Retry;
                    return true;
                }
            }
            else if (keyData == (Keys.Control | Keys.Enter))
            {
                if (btnOK.Enabled)
                {
                    this.DialogResult = DialogResult.OK;
                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            this.CheckManualInvoice();
        }

        private void CheckManualInvoice()
        {
            if (this.FindInvoice())
            {
                this.CheckInvoice();
            }
            else
            {
                tbsInvoiceBarCode.Focus();
                tbsInvoiceBarCode.SelectAll();
            }
        }

        /// <summary>
        /// Поиск накладной по номеру и типу
        /// </summary>
        /// <returns></returns>
        private bool FindInvoice()
        {
            try
            {
                var dlgArchiveInvoiceFind = new ArchiveReturnedTareInvoiceFindForm() { UserID = this.UserID, DocNumber = this.DocNumber, DocTypeID = this.DocType };
                if (dlgArchiveInvoiceFind.ShowDialog(this) == DialogResult.OK)
                {
                    var dcto = dlgArchiveInvoiceFind.DocTypeID;
                    var doco = dlgArchiveInvoiceFind.DocNumber;

                    var pashan = (double?)null;
                    var pabrdn = (string)null;
                    var factCloseDate = (DateTime?)null;
                    var message = (string)null;

                    using (var adapter = new Data.WHTableAdapters.AI_Ret_DocsTableAdapter())
                        adapter.VerifyManual(this.UserID, doco, dcto, ref factCloseDate, ref message, ref pashan, ref pabrdn);

                    this.DocType = dcto;
                    this.DocNumber = doco;
                    this.ReceiverCode = pashan;
                    this.AttorneyNumber = pabrdn;

                    tbNote.Text = message ?? string.Empty;
                    tbNote.ForeColor = Color.Green;
                    
                    if (factCloseDate != null)
                        dtpInvoiceArchiveDate.Value = factCloseDate.Value.Date;
                    else
                    {
                        dtpInvoiceArchiveDate.Value = DateTime.Today;
                        dtpInvoiceArchiveDate.Enabled = true;
                        tbNote.Text = string.Format("{0}\r\nВыберите дату закрытия накладной!", tbNote.Text);
                        tbNote.ForeColor = Color.Red;
                    }

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                tbNote.Text = ex.Message;
                tbNote.ForeColor = Color.Red;

                return false;
            }
        }

        void tbsInvoiceBarCode_TextChanged(object sender, EventArgs e)
        {
            this.CheckScannedInvoice();
        }

        private void CheckScannedInvoice()
        {
            var barCode = string.Empty;

            if (string.IsNullOrEmpty(barCode = tbsInvoiceBarCode.Text))
                return;

            bool hasActiveDoc = false;
            
            // Если есть незакрытый документ, то сперва закроем его
            if (hasActiveDoc = this.HasActiveDoc)
            {
                var dialogResult = DialogResult.None;
                if (this.SaveData(ref dialogResult))
                {
                    var actionText = dialogResult == DialogResult.Retry ? "отправлен на доработку" : "успешно закрыт";
                    tbNote.Text = string.Format("Предыдущий документ: {0} Тип: {1} {2}.", this.DocNumber, this.DocType.Trim(), actionText);
                    tbNote.ForeColor = Color.Green;

                    this.ClearData();

                    tbsInvoiceBarCode.Text = barCode;
                    tbsInvoiceBarCode.Focus();
                    this.tbsInvoiceBarCode.SelectAll();
                }
                else
                {
                    tbsInvoiceBarCode.Text = this.BarCode;
                    tbsInvoiceBarCode.Focus();
                    this.tbsInvoiceBarCode.SelectAll();
                    return;
                }
            }

            this.BarCode = barCode;

            #region OBSOLETE

            //if (this.CheckBarCode(barCode) && this.FindInvoiceRequisites())
            //{
            //    this.LockEditors(false);

            //    if (dtpInvoiceArchiveDate.Enabled)
            //    {
            //        dtpInvoiceArchiveDate.Focus();
            //    }
            //    else
            //    {
            //        this.DialogResult = DialogResult.OK;
            //        this.Close();
            //    }
            //}

            #endregion

            if (this.CheckBarCode(barCode, hasActiveDoc))
            {
                this.CheckInvoice();
            }
            else
            {
                tbsInvoiceBarCode.Focus();
                tbsInvoiceBarCode.SelectAll();
            }
        }

        /// <summary>
        /// Проверка ш/к накладной
        /// </summary>
        /// <param name="invoiceBarCode"></param>
        /// <returns></returns>
        private bool CheckBarCode(string invoiceBarCode, bool showPreviousMessage)
        {
            try
            {
                var planArchiveDate = (DateTime?)null;//dtpInvoiceArchiveDate.Value;

                var message = (string)null;
                var dcto = (string)null;
                var doco = (double?)null;
                var pashan = (double?)null;
                var pabrdn = (string)null;
                var factCloseDate = (DateTime?)null;

                using (var adapter = new Data.WHTableAdapters.AI_Ret_DocsTableAdapter())
                    adapter.Verify(this.UserID, invoiceBarCode, ref doco, ref dcto, ref factCloseDate, ref message, ref pashan, ref pabrdn);

                this.DocType = dcto;
                this.DocNumber = doco;
                this.ReceiverCode = pashan;
                this.AttorneyNumber = pabrdn;

                var previousMessage = showPreviousMessage ? tbNote.Text : string.Empty;
                var currentMessage = (message ?? string.Empty);
                var currentMessageExt = string.Empty;
                //tbNote.Text = message ?? string.Empty;
                tbNote.ForeColor = Color.Green;

                if (factCloseDate != null)
                    dtpInvoiceArchiveDate.Value = factCloseDate.Value.Date;
                else
                {
                    dtpInvoiceArchiveDate.Value = DateTime.Today;
                    dtpInvoiceArchiveDate.Enabled = true;
                    //tbNote.Text = string.Format("{0}\r\nВыберите дату закрытия накладной!", tbNote.Text);
                    currentMessageExt = string.Format("Выберите дату закрытия накладной!");
                    tbNote.ForeColor = Color.Red;
                }

                var currentMessageFormat = string.Format("{0}\r\n{1}", currentMessage, currentMessageExt).Trim('\r', '\n');
                tbNote.Text = string.Format("{0}\r\n✔{1}", currentMessageFormat, previousMessage).Trim('✔', '\r', '\n');

                return true;
            }
            catch (Exception ex)
            {
                var previousMessage = showPreviousMessage ? tbNote.Text : string.Empty;
                var currentMessage = ex.Message;
                tbNote.Text = string.Format("{0}\r\n✔{1}", currentMessage, previousMessage).Trim('✔', '\r', '\n');
                //tbNote.Text = ex.Message;
                tbNote.ForeColor = Color.Red;

                return false;
            }
        }

        private void CheckInvoice()
        {
            if (this.FindInvoiceRequisites())
            {
                this.LockEditors(false);

                if (dtpInvoiceArchiveDate.Enabled)
                {
                    dtpInvoiceArchiveDate.Focus();
                }
                else
                {
                    dgvDocDetails.Focus();
                    dgvDocDetails.Select();

                    if (dgvDocDetails.Rows.Count > 0)
                        dgvDocDetails.Rows[0].Cells[factReturnQtyDataGridViewTextBoxColumn.Index].Selected = true;

                    ////this.btnOK.Focus();
                    //this.tbsInvoiceBarCode.Focus();
                    //this.tbsInvoiceBarCode.SelectAll();

                    ////this.DialogResult = DialogResult.OK;
                    ////this.Close();
                }
            }
            else
            {
                tbsInvoiceBarCode.Focus();
                tbsInvoiceBarCode.SelectAll();
            }
        }

        /// <summary>
        /// Получение реквизитов
        /// </summary>
        /// <returns></returns>
        private bool FindInvoiceRequisites()
        {
            try
            {
                BackgroundWorker bw = null;

                #region ЗАГОЛОВОК НАКЛАДНОЙ

                bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    try
                    {
                        using (var adapter = new Data.WHTableAdapters.AI_Ret_Doc_HeaderTableAdapter())
                            e.Result = adapter.GetData(this.DocNumber, this.DocType);
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                bw.RunWorkerCompleted += (s, e) =>
                {
                    if (e.Result is Exception)
                        MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        wH.AI_Ret_Doc_Header.Merge(e.Result as Data.WH.AI_Ret_Doc_HeaderDataTable);

                    splashForm.CloseForce();
                };

                splashForm.ActionText = "Выполняется загрузка заголовка накладной..";
                wH.AI_Ret_Doc_Header.Clear();
                bw.RunWorkerAsync();
                splashForm.ShowDialog();

                #endregion

                #region СТРОКИ НАКЛАДНОЙ

                bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    try
                    {
                        using (var adapter = new Data.WHTableAdapters.AI_Ret_Doc_DetailsTableAdapter())
                            e.Result = adapter.GetData(this.DocNumber, this.DocType, this.UserID);
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                bw.RunWorkerCompleted += (s, e) =>
                {
                    if (e.Result is Exception)
                        MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        wH.AI_Ret_Doc_Details.Merge(e.Result as Data.WH.AI_Ret_Doc_DetailsDataTable);

                    splashForm.CloseForce();
                };

                splashForm.ActionText = "Выполняется загрузка строк накладной..";
                wH.AI_Ret_Doc_Details.Clear();
                bw.RunWorkerAsync();
                splashForm.ShowDialog();

                #endregion

                #region ДОВЕРЕННОСТИ

                this.InitializeImageViewer(false);

                bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    try
                    {
                        using (var adapter = new Data.WHTableAdapters.AC_AttachmentsTableAdapter())
                            e.Result = adapter.GetData(this.ReceiverCode, this.AttorneyNumber);
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                bw.RunWorkerCompleted += (s, e) =>
                {
                    if (e.Result is Exception)
                        MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        wH.AC_Attachments.Merge(e.Result as Data.WH.AC_AttachmentsDataTable);

                    splashForm.CloseForce();
                };

                splashForm.ActionText = "Выполняется загрузка копии доверенности..";
                wH.AC_Attachments.Clear();
                bw.RunWorkerAsync();
                splashForm.ShowDialog();

                foreach (Data.WH.AC_AttachmentsRow row in wH.AC_Attachments.Rows)
                    ivcAttorneys.Items.Add(new ImageProxy(row.image_buffer, (string)null) { Properties = row });

                if (ivcAttorneys.Items.Count == 0)
                    this.InitializeImageViewer(true, true);
                else
                    ivcAttorneys.CurrentItem = ivcAttorneys.Items[0];

                #endregion

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void InitializeImageViewer(bool addEmptyImageIndicator)
        {
            this.InitializeImageViewer(addEmptyImageIndicator, true);
            this.InitializeImageViewer(addEmptyImageIndicator, false);
        }

        private void InitializeImageViewer(bool addEmptyImageIndicator, bool initializeAttorney)
        {
            if (initializeAttorney)
            {
                ivcAttorneys.Items.Clear();
                ivcAttorneys.CurrentItem = addEmptyImageIndicator ? new ImageProxy(Properties.Resources.absentimage) : null;
            }
            else
            {
                ivcAgreements.Items.Clear();
                ivcAgreements.CurrentItem = addEmptyImageIndicator ? new ImageProxy(Properties.Resources.absentimage) : null;
            }
        }

        private void dgvDocDetails_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            var boundRow = (dgvDocDetails.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.WH.AI_Ret_Doc_DetailsRow;

            // Если редактировалось поле "Возврат (факт)" или "Остаток (факт)"
            if (dgvDocDetails.Columns[e.ColumnIndex].DataPropertyName == this.wH.AI_Ret_Doc_Details.Fact_Return_QtyColumn.Caption ||
                dgvDocDetails.Columns[e.ColumnIndex].DataPropertyName == this.wH.AI_Ret_Doc_Details.Fact_Remains_QtyColumn.Caption)
            {
                try
                {
                    var tareType = boundRow.IsTare_typeNull() ? (string)null : boundRow.Tare_type;
                    var price = boundRow.IsPriceNull() ? (decimal?)null : boundRow.Price;
                    var qtyReturnFact = boundRow.IsFact_Return_QtyNull() ? (double?)null : boundRow.Fact_Return_Qty;
                    var qtyRemainsFact = boundRow.IsFact_Remains_QtyNull() ? (double?)null : boundRow.Fact_Remains_Qty;

                    using (var adapter = new Data.WHTableAdapters.AI_Ret_Doc_DetailsTableAdapter())
                        adapter.Modify(this.UserID, this.DocNumber, this.DocType, tareType, qtyReturnFact, qtyRemainsFact, price);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (this.FindInvoiceRequisites())
                    {
                        dgvDocDetails.Focus();
                        dgvDocDetails.Select();

                        if (dgvDocDetails.Rows.Count > 0)
                            dgvDocDetails.Rows[dgvDocDetails.SelectedRows.Count > 0 ? dgvDocDetails.SelectedRows[0].Index : 0].Cells[factReturnQtyDataGridViewTextBoxColumn.Index].Selected = true;
                    }
                    
                    //this.FindInvoiceRequisites()
                    //this.btnOK.Focus();
                }
            }
        }

        private void dgvDocDetails_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Context == (DataGridViewDataErrorContexts.Parsing | DataGridViewDataErrorContexts.Commit) && e.Exception != null)
            {
                if (this.dgvDocDetails.Columns[e.ColumnIndex].DataPropertyName == this.wH.AI_Ret_Doc_Details.Fact_Return_QtyColumn.Caption ||
                    this.dgvDocDetails.Columns[e.ColumnIndex].DataPropertyName == this.wH.AI_Ret_Doc_Details.Fact_Remains_QtyColumn.Caption)
                {
                    MessageBox.Show("Количество должно быть целым числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearData();
        }

        private void ClearData()
        {
            this.BarCode = (string)null;

            this.DocType = (string)null;
            this.DocNumber = (double?)null;
            //this.ReceiverCode = (double?)null;
            this.AttorneyNumber = (string)null;

            wH.AI_Ret_Doc_Header.Clear();
            wH.AI_Ret_Doc_Details.Clear();

            this.LockEditors(true);

            //tbNote.Clear();

            tbsInvoiceBarCode.Text = string.Empty;
            tbsInvoiceBarCode.Focus();
        }

        private void LockEditors(bool isEnabled)
        {
            if (dtpInvoiceArchiveDate.Enabled && isEnabled)
                dtpInvoiceArchiveDate.Enabled = false; //isEnabled;

            //tbsInvoiceBarCode.Enabled = isEnabled;
            btnFind.Enabled = isEnabled;

            btnClear.Enabled = !isEnabled;
            this.btnOK.Enabled = !isEnabled;

            this.btnDelayOK.Enabled = !isEnabled;
        }

        private void ArchiveInvoiceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var dialogResult = this.DialogResult; 
            if (dialogResult == DialogResult.OK || dialogResult == DialogResult.Retry)
            {
                if (this.SaveData(ref dialogResult))
                {
                    var actionText = dialogResult == DialogResult.Retry ? "отправлен на доработку" : "успешно закрыт";
                    tbNote.Text = string.Format("Документ: {0} Тип: {1} {2}.", this.DocNumber, this.DocType.Trim(), actionText);
                    tbNote.ForeColor = Color.Green;

                    this.SaveSettings();

                    this.ClearData();
                }

                e.Cancel = true;
            }
        }

        private bool SaveData(ref DialogResult dialogResult)
        {
            // 1. Определение параметров закрытия документа
            var delayReasonsFlag = (int?)null; // причины доработки документа

            if (this.DialogResult == DialogResult.Retry)
            {
                var dlgArchiveReturnedTareInvoiceDelayReasons = new ArchiveReturnedTareInvoiceDelayReasonsSetForm() { UserID = this.UserID };

                if (dlgArchiveReturnedTareInvoiceDelayReasons.ShowDialog(this) == DialogResult.OK)
                    delayReasonsFlag = dlgArchiveReturnedTareInvoiceDelayReasons.DelayReasonsFlag;
                else
                {
                    dialogResult = DialogResult.Cancel;
                    return false;
                }
            }

            // 2. Закрытие с проверкой на расхождения
            var allowWronqQtyFlag = (int?)null; // флаг сброса проверки на расхождения введенных количеств

            while (true)
            {
                try
                {
                    using (var adapter = new Data.WHTableAdapters.AI_Ret_DocsTableAdapter())
                        adapter.Close(this.UserID, this.DocNumber, this.DocType, this.BarCode, allowWronqQtyFlag, delayReasonsFlag);

                    dialogResult = ((allowWronqQtyFlag ?? 0) == 1 || (delayReasonsFlag ?? 0) > 0) ? DialogResult.Retry : DialogResult.OK;
                    return true;
                }
                catch (Exception ex)
                {
                    var message = ex.Message;

                    if (ex.Message.Contains("#WRONG_QTY"))
                    {
                        message = ex.Message.Replace("#WRONG_QTY", string.Empty);

                        var regex = new System.Text.RegularExpressions.Regex(@"^#WRONG_QTY#(?<msg>.+)#", System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Singleline);
                        if (regex.IsMatch(ex.Message))
                        {
                            message = regex.Match(ex.Message).Groups["msg"].Value;

                            if (MessageBox.Show(message, "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                            {
                                dialogResult = DialogResult.Cancel;
                                return false;
                            }
                            else
                            {
                                allowWronqQtyFlag = 1; // устанавливаем флаг сброса проверки
                                continue;
                            }
                        }
                    }

                    //MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    tbNote.Text = message;
                    tbNote.ForeColor = Color.Red;

                    dialogResult = DialogResult.Cancel;
                    return false;
                }
            }
        }

        private void SaveSettings()
        {
            try
            {
                var sAttorneyZoomFactor = ivcAttorneys.CurrentZoomFactor.ToString();
                Config.SaveSetting(this.Name, ATTORNEY_ZOOM_FACTOR_SETTING_NAME, sAttorneyZoomFactor);

                var sAttorneyAutoZoomActivated = ivcAttorneys.AutoZoomActivated.ToString();
                Config.SaveSetting(this.Name, ATTORNEY_AUTO_ZOOM_ACTIVATED_SETTING_NAME, sAttorneyAutoZoomActivated);

                var sAgreementZoomFactor = ivcAgreements.CurrentZoomFactor.ToString();
                Config.SaveSetting(this.Name, AGREEMENT_ZOOM_FACTOR_SETTING_NAME, sAgreementZoomFactor);

                var sAgreementAutoZoomActivated = ivcAgreements.AutoZoomActivated.ToString();
                Config.SaveSetting(this.Name, AGREEMENT_AUTO_ZOOM_ACTIVATED_SETTING_NAME, sAgreementAutoZoomActivated);

                var sDocumentAttachmentsSplitterDistance = scDocumentWithAttachments.SplitterDistance.ToString();
                Config.SaveSetting(this.Name, DOCUMENT_ATTACHMENTS_SPLITTER_DISTANCE_NAME, sDocumentAttachmentsSplitterDistance);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            this.LoadAgreements();
        }

        private void LoadAgreements()
        {
            try
            {
                this.InitializeImageViewer(false, false);

                if (this.ReceiverCode == null)
                    throw new Exception("Получатель должен быть указан.");

                #region ДОГОВОРА

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    try
                    {
                        using (var adapter = new Data.WHTableAdapters.AC_AgreementsTableAdapter())
                            e.Result = adapter.GetData(this.ReceiverCode);
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                bw.RunWorkerCompleted += (s, e) =>
                {
                    if (e.Result is Exception)
                        MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        wH.AC_Agreements.Merge(e.Result as Data.WH.AC_AgreementsDataTable);

                        foreach (Data.WH.AC_AgreementsRow row in wH.AC_Agreements.Rows)
                        {
                            var fullImageBuffer = row.Isimage_binNull() ? (byte[])null : row.image_bin;
                            var extension = row.IsextensionNull() ? (string)null : row.extension;

                            if (fullImageBuffer != null && !string.IsNullOrEmpty(extension))
                            {
                                foreach (var buffer in ImageUtils.ExtractImageLayersFromDataBufferEx(fullImageBuffer, extension))
                                    ivcAgreements.Items.Add(new ImageProxy(buffer, (string)null) { Properties = row });
                            }
                        }

                        if (ivcAgreements.Items.Count == 0)
                            this.InitializeImageViewer(true, false);
                        else
                            ivcAgreements.CurrentItem = ivcAgreements.Items[ivcAgreements.Items.Count - 1];

                        //ivcAgreements.CurrentItem = ivcAgreements.Items.Count > 0
                        //    ? ivcAgreements.Items[0]
                        //    : new ImageProxy(Properties.Resources.absentimage);
                    }

                    splashForm.CloseForce();
                };

                splashForm.ActionText = "Выполняется загрузка копии договора..";
                wH.AC_Agreements.Clear();
                bw.RunWorkerAsync();
                splashForm.ShowDialog();

                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tcDocumentAttachments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcDocumentAttachments.SelectedTab == tpAttorneys)
            {
                if (ivcAttorneys.AutoZoomActivated)
                    ivcAttorneys.ChangeZoom(); 
            }
            else if (tcDocumentAttachments.SelectedTab == tpAgreements)
            {
                if (ivcAgreements.AutoZoomActivated)
                    ivcAgreements.ChangeZoom(); 
            }
        }
    }
}
