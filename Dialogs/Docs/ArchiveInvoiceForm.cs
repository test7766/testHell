using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.Custom;
using WMSOffice.Dialogs.Sert;
using WMSOffice.Classes;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;

namespace WMSOffice.Dialogs.Docs
{
    public partial class ArchiveInvoiceForm : DialogForm
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
        /// Масштаб реестра
        /// </summary>
        private const string REGISTER_ZOOM_FACTOR_SETTING_NAME = "Register_ZoomFactor";
        /// <summary>
        /// Автомасштабирование реестра
        /// </summary>
        private const string REGISTER_AUTO_ZOOM_ACTIVATED_SETTING_NAME = "Register_AutoZoomActivated";

        /// <summary>
        /// Ширина контейнера с разделителем
        /// </summary>
        private const string DOCUMENT_ATTACHMENTS_SPLITTER_DISTANCE_NAME = "DocumentAttachments_SplitterDistance";

        private int documentAttachmentsSplitterDistance = 0;

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        public DateTime InvoiceArchiveDate 
        {
            get { return dtpInvoiceArchiveDate.Value; }
            set { dtpInvoiceArchiveDate.Value = value; }
        }

        public bool IsArchiveModeEnabled { get; private set; }

        public string DocType { get; private set; }
        public double? DocNumber { get; private set; }
        public double? ReceiverCode { get; private set; }
        public string AttorneyNumber { get; private set; }
        public bool? IsTransitInvoice { get; private set; }

        /// <summary>
        /// Признак ручного поиска накладной
        /// </summary>
        public bool ManualSearchMode { get; private set; }

        /// <summary>
        /// Возможность установки режима подтверждения принятых документов
        /// </summary>
        public bool? CanAcceptReceivedDocs { get; set; }

        public ArchiveInvoiceForm()
        {
            InitializeComponent();
            tbsInvoiceBarCode.TextChanged += new EventHandler(tbsInvoiceBarCode_TextChanged);
        }

        public ArchiveInvoiceForm(string docType, double? docNumber)
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

            cbAcceptReceivedDocs.Enabled = this.CanAcceptReceivedDocs ?? false;

            btnCreateRegister.Enabled = true;
            btnSaveRegister.Enabled = false;
            btnCompleteRegister.Enabled = false;
            btnCloseRegister.Enabled = true;
            btnOpenRegister.Enabled = true;

            btnPrintRegister.Enabled = false;

            lblArchive.Visible = cbAcceptReceivedDocs.Visible = true;
            //foreach (ToolStripItem item in tsRegister.Items)
            //    item.Enabled = false;

            ivcRegister.DisablePrint = true;
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

                var sRegisterZoomFactor = Config.LoadSetting(this.Name, REGISTER_ZOOM_FACTOR_SETTING_NAME);
                var registerZoomFactor = 0.0;
                if (double.TryParse(sRegisterZoomFactor, out registerZoomFactor))
                    ivcRegister.CurrentZoomFactor = registerZoomFactor;

                var sRegisterAutoZoomActivated = Config.LoadSetting(this.Name, REGISTER_AUTO_ZOOM_ACTIVATED_SETTING_NAME);
                var registerAutoZoomActivated = false;
                if (bool.TryParse(sRegisterAutoZoomActivated, out registerAutoZoomActivated))
                    ivcRegister.AutoZoomActivated = registerAutoZoomActivated;

                var sDocumentAttachmentsSplitterDistance = Config.LoadSetting(this.Name, DOCUMENT_ATTACHMENTS_SPLITTER_DISTANCE_NAME);
                if (!int.TryParse(sDocumentAttachmentsSplitterDistance, out documentAttachmentsSplitterDistance))
                    documentAttachmentsSplitterDistance = scDocumentWithAttachments.SplitterDistance;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

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
            if (keyData == (Keys.Control | Keys.Enter))
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
                var dlgArchiveInvoiceFind = new ArchiveInvoiceFindForm() { UserID = this.UserID, DocNumber = this.DocNumber, DocTypeID = this.DocType, CanAcceptReceivedDocs = cbAcceptReceivedDocs.Enabled, AcceptReceivedDocs = cbAcceptReceivedDocs.Checked };
                if (dlgArchiveInvoiceFind.ShowDialog(this) == DialogResult.OK)
                {
                    cbAcceptReceivedDocs.Checked = dlgArchiveInvoiceFind.AcceptReceivedDocs ?? false;

                    var filialOnCWMode = Convert.ToInt32(cbAcceptReceivedDocs.Checked);
                    var dcto = dlgArchiveInvoiceFind.DocTypeID;
                    var doco = dlgArchiveInvoiceFind.DocNumber;

                    var pashan = (double?)null;
                    var pabrdn = (string)null;
                    var factCloseDate = (DateTime?)null;
                    var message = (string)null;
                    var isTransitInvoice = (bool?)null;

                    using (var adapter = new Data.WHTableAdapters.AI_DocsTableAdapter())
                        adapter.VerifyManual(filialOnCWMode, doco, dcto, ref pashan, ref pabrdn, ref factCloseDate, ref message, ref isTransitInvoice, this.RegisterID);

                    this.DocType = dcto;
                    this.DocNumber = doco;
                    this.ReceiverCode = pashan;
                    this.AttorneyNumber = pabrdn;
                    this.IsTransitInvoice = isTransitInvoice;

                    tbNote.Text = message ?? string.Empty;
                    tbNote.ForeColor = (this.IsTransitInvoice ?? false) ? Color.Blue : Color.Green;

                    if (factCloseDate != null)
                        dtpInvoiceArchiveDate.Value = factCloseDate.Value.Date;
                    else
                    {
                        dtpInvoiceArchiveDate.Value = DateTime.Today;
                        dtpInvoiceArchiveDate.Enabled = true;
                        tbNote.Text = string.Format("{0}\r\nОберіть дату закриття накладної!", tbNote.Text);
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

            if (this.CheckBarCode(barCode))
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
        private bool CheckBarCode(string invoiceBarCode)
        {
            try
            {
                var filialOnCWMode = Convert.ToInt32(cbAcceptReceivedDocs.Checked);
                var planArchiveDate = (DateTime?)null;//dtpInvoiceArchiveDate.Value;

                var message = (string)null;
                var dcto = (string)null;
                var doco = (double?)null;
                var pashan = (double?)null;
                var pabrdn = (string)null;
                var factCloseDate = (DateTime?)null;
                var isTransitInvoice = (bool?)null;

                using (var adapter = new Data.WHTableAdapters.AI_DocsTableAdapter())
                {
                    adapter.SetTimeout((int)TimeSpan.FromMinutes(3).TotalSeconds);
                    adapter.Verify(invoiceBarCode, filialOnCWMode, planArchiveDate, ref message, ref doco, ref dcto, ref pashan, ref pabrdn, ref factCloseDate, ref isTransitInvoice, this.RegisterID);
                }

                this.DocType = dcto;
                this.DocNumber = doco;
                this.ReceiverCode = pashan;
                this.AttorneyNumber = pabrdn;
                this.IsTransitInvoice = isTransitInvoice;

                tbNote.Text = message ?? string.Empty;
                tbNote.ForeColor = (this.IsTransitInvoice ?? false) ? Color.Blue : Color.Green;

                if (factCloseDate != null)
                    dtpInvoiceArchiveDate.Value = factCloseDate.Value.Date;
                else
                {
                    dtpInvoiceArchiveDate.Value = DateTime.Today;
                    dtpInvoiceArchiveDate.Enabled = true;
                    tbNote.Text = string.Format("{0}\r\nОберіть дату закриття накладної!", tbNote.Text);
                    tbNote.ForeColor = Color.Red;
                }

                return true;
            }
            catch (Exception ex)
            {
                tbNote.Text = ex.Message;
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
                    this.DialogResult = DialogResult.OK;
                    this.Close();
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
                this.InitializeImageViewer(false);

                #region ДОВЕРЕННОСТИ

                var bw = new BackgroundWorker();
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
                        MessageBox.Show((e.Result as Exception).Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        wH.AC_Attachments.Merge(e.Result as Data.WH.AC_AttachmentsDataTable);

                    splashForm.CloseForce();
                };

                splashForm.ActionText = "Виконується завантаження копії довіреності..";
                wH.AC_Attachments.Clear();
                bw.RunWorkerAsync();
                splashForm.ShowDialog();

                #endregion

                foreach (Data.WH.AC_AttachmentsRow row in wH.AC_Attachments.Rows)
                    ivcAttorneys.Items.Add(new ImageProxy(row.image_buffer, (string)null) { Properties = row });

                if (ivcAttorneys.Items.Count == 0)
                    this.InitializeImageViewer(true, true);
                else
                    ivcAttorneys.CurrentItem = ivcAttorneys.Items[0];

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

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearData();
        }

        private void ClearData()
        {
            this.DocType = (string)null;
            this.DocNumber = (double?)null;
            //this.ReceiverCode = (double?)null;
            this.AttorneyNumber = (string)null;
            this.IsTransitInvoice = (bool?)null;

            this.LockEditors(true);

            //tbNote.Clear();

            tbsInvoiceBarCode.Text = string.Empty;
            tbsInvoiceBarCode.Focus();
        }

        private void LockEditors(bool isEnabled)
        {
            if (dtpInvoiceArchiveDate.Enabled && isEnabled)
                dtpInvoiceArchiveDate.Enabled = false; //isEnabled;

            cbAcceptReceivedDocs.Enabled = isEnabled && this.IsArchiveModeEnabled;

            tbsInvoiceBarCode.Enabled = isEnabled;
            btnFind.Enabled = isEnabled;

            btnClear.Enabled = !isEnabled;
            this.btnOK.Enabled = !isEnabled;
        }

        private void ArchiveInvoiceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.SaveData())
                {
                    tbNote.Text = string.Format("Документ: {0} Тип: {1} успішно закритий.", this.DocNumber, this.DocType.Trim());

                    if ((this.IsTransitInvoice ?? false) == true)
                        tbNote.Text = string.Format("{0}\r\nТРАНЗИТ", tbNote.Text);

                    tbNote.ForeColor = (this.IsTransitInvoice ?? false) ? Color.Blue : Color.Green;

                    this.SaveSettings();

                    this.ClearData();
                }

                e.Cancel = true;
            }
            else
            {
                this.CheckRegister();
            }
        }

        private bool SaveData()
        {
            try
            {
                var filialOnCWMode = Convert.ToInt32(cbAcceptReceivedDocs.Checked);

                using (var adapter = new Data.WHTableAdapters.AI_DocsTableAdapter())
                {
                    adapter.SetTimeout((int)TimeSpan.FromMinutes(3).TotalSeconds);
                    adapter.Close(this.DocNumber, this.DocType, dtpInvoiceArchiveDate.Value, filialOnCWMode, this.UserID, this.RegisterID);
                }

                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                tbNote.Text = ex.Message;
                tbNote.ForeColor = Color.Red;

                return false;
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

                var sRegisterZoomFactor = ivcRegister.CurrentZoomFactor.ToString();
                Config.SaveSetting(this.Name, REGISTER_ZOOM_FACTOR_SETTING_NAME, sRegisterZoomFactor);

                var sRegisterAutoZoomActivated = ivcRegister.AutoZoomActivated.ToString();
                Config.SaveSetting(this.Name, REGISTER_AUTO_ZOOM_ACTIVATED_SETTING_NAME, sRegisterAutoZoomActivated);

                var sDocumentAttachmentsSplitterDistance = scDocumentWithAttachments.SplitterDistance.ToString();
                Config.SaveSetting(this.Name, DOCUMENT_ATTACHMENTS_SPLITTER_DISTANCE_NAME, sDocumentAttachmentsSplitterDistance);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CheckRegister()
        {
            try
            {
                using (var adapter = new Data.WHTableAdapters.AI_RegisterDocs_UncompletedTableAdapter())
                    adapter.CheckRegister(this.UserID, this.RegisterID);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    throw new Exception("Отримувач повинен бути вказаний.");

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
                        MessageBox.Show((e.Result as Exception).Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                splashForm.ActionText = "Виконується завантаження копії договора..";
                wH.AC_Agreements.Clear();
                bw.RunWorkerAsync();
                splashForm.ShowDialog();

                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tcAttachments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcAttachments.SelectedTab == tpAttorneys)
            {
                if (ivcAttorneys.AutoZoomActivated)
                    ivcAttorneys.ChangeZoom();
            }
            else if (tcAttachments.SelectedTab == tpAgreements)
            {
                if (ivcAgreements.AutoZoomActivated)
                    ivcAgreements.ChangeZoom();
            }
            else if (tcAttachments.SelectedTab == tpRegister)
            {
                if (ivcRegister.AutoZoomActivated)
                    ivcRegister.ChangeZoom();
            }
        }

        public long? RegisterID { get; set; }

        private void btnCreateRegister_Click(object sender, EventArgs e)
        {
            try
            {
                var registerID = (long?)null;
                using (var adapter = new Data.WHTableAdapters.AI_RegisterDocs_UncompletedTableAdapter())
                    adapter.CreateRegister(this.UserID, ref registerID);

                this.OpenRegister(registerID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveRegister_Click(object sender, EventArgs e)
        {
            try
            {
                using (var adapter = new Data.WHTableAdapters.AI_RegisterDocs_UncompletedTableAdapter())
                    adapter.SaveRegister(this.UserID, this.RegisterID);

                MessageBox.Show("Зміни збережено.", "Збереження реєстру архіву", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCompleteRegister_Click(object sender, EventArgs e)
        {
            try
            {
                var includeDetails = true;

                MessageBoxManager.Yes = "&Повний";
                MessageBoxManager.No = "&Скорочений";
                MessageBoxManager.Cancel = "&Відміна";

                MessageBoxManager.Register();

                var dlgResult = MessageBox.Show("Оберіть тип реєстру.", "Формування реєстру", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);

                MessageBoxManager.Unregister();
                
                switch (dlgResult)
                { 
                    case DialogResult.Yes:
                        includeDetails = true;
                        break;
                    case DialogResult.No:
                        includeDetails = false;
                        break;
                    case DialogResult.Cancel:
                    default:
                        return;
                }

                using (var adapter = new Data.WHTableAdapters.AI_RegisterDocs_UncompletedTableAdapter())
                    adapter.CompleteRegister(this.UserID, this.RegisterID);

                this.CreateRegisterReport(includeDetails);

                btnCreateRegister.Enabled = true;
                btnSaveRegister.Enabled = false;
                btnCompleteRegister.Enabled = false;
                btnCloseRegister.Enabled = true;
                btnOpenRegister.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCloseRegister_Click(object sender, EventArgs e)
        {
            try
            {
                var dlgArchiveInvoicesRegisterClose = new ArchiveInvoicesRegisterCloseForm() { UserID = this.UserID };
                if (dlgArchiveInvoicesRegisterClose.ShowDialog() == DialogResult.OK)
                {
                    var closePeriod = dlgArchiveInvoicesRegisterClose.ClosePeriod;
                    var warehouseCode = dlgArchiveInvoicesRegisterClose.WarehouseCode;

                    using (var adapter = new Data.WHTableAdapters.AI_RegisterDocs_UncompletedTableAdapter())
                        adapter.CloseRegister(this.UserID, closePeriod, warehouseCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOpenRegister_Click(object sender, EventArgs e)
        {
            try
            {
                var dlgArchiveInvoicesRegisterSearch = new ArchiveInvoicesRegisterSearchForm() { UserID = this.UserID };
                if (dlgArchiveInvoicesRegisterSearch.ShowDialog() == DialogResult.OK)
                {
                    var register = dlgArchiveInvoicesRegisterSearch.SelectedRegistry;
                    this.OpenRegister(register.RegisterID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenRegister(long? registerID)
        {
            this.RegisterID = registerID;

            lblRegister.Text = string.Format("№ реєстра: {0}", this.RegisterID);
            lblRegister.Visible = true;

            btnCreateRegister.Enabled = false;
            btnSaveRegister.Enabled = true;
            btnCompleteRegister.Enabled = true;
            btnCloseRegister.Enabled = true;
            btnOpenRegister.Enabled = false;
        }

        private void CreateRegisterReport()
        {
            this.CreateRegisterReport(true);
        }

        private void CreateRegisterReport(bool includeDetails)
        {
            try
            {
                string tempFilePath = null;
                ReportClass report = null;

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) => 
                {
                    try 
                    {
                        using (var adapter = new Data.WHTableAdapters.AI_RegisterDocs_HeadersTableAdapter())
                            adapter.Fill(wH.AI_RegisterDocs_Headers, this.UserID, this.RegisterID);

                        if (includeDetails)
                        {
                            using (var adapter = new Data.WHTableAdapters.AI_RegisterDocs_DetailsTableAdapter())
                                adapter.Fill(wH.AI_RegisterDocs_Details, this.UserID, this.RegisterID);
                        }
                        else
                        {
                            wH.AI_RegisterDocs_Headers.LoadDataRow(wH.AI_RegisterDocs_Headers[0].ItemArray, true);
                            wH.AI_RegisterDocs_Headers[1].Number = 2;
                        }

                        report = includeDetails ? (ReportClass)new WMSOffice.Reports.ArchiveInvoiceRegisterReport() : new WMSOffice.Reports.ArchiveInvoiceRegisterHeaderReport();
                        report.SetDataSource(wH);

                        tempFilePath = Path.GetTempFileName();
                        if (!string.IsNullOrEmpty(ExportHelper.ExportCrystalReportToFile(report, CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, tempFilePath, false)))
                            throw new Exception("Неможливо експортувати реєстр..");
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                bw.RunWorkerCompleted += (s, e) => 
                {
                    try
                    {
                        splashForm.CloseForce();

                        if (e.Result is Exception)
                            throw (e.Result as Exception);

                        var fileBin = File.ReadAllBytes(tempFilePath);
                        var fileExt = "PDF";

                        ivcRegister.Items.Clear();
                        foreach (var buffer in ImageUtils.ExtractImageLayersFromDataBufferEx(fileBin, fileExt))
                            ivcRegister.Items.Add(new ImageProxy(buffer, (string)null) { Properties = this.RegisterID });

                        if (ivcRegister.Items.Count > 0)
                            ivcRegister.CurrentItem = ivcRegister.Items[0];

                        btnPrintRegister.Tag = report;
                        btnPrintRegister.Enabled = true;

                        tcAttachments.SelectedTab = tpRegister;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        try
                        {
                            if (!string.IsNullOrEmpty(tempFilePath) && File.Exists(tempFilePath))
                                File.Delete(tempFilePath);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                };
                splashForm.ActionText = "Виконується побудова реєстру..";
                bw.RunWorkerAsync();
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrintRegister_Click(object sender, EventArgs e)
        {
            this.PrintPreviewRegister();
        }

        private void PrintPreviewRegister()
        {
            try
            {
                if (btnPrintRegister.Tag != null)
                {
                    var report = btnPrintRegister.Tag as ReportClass;

                    using (Dialogs.ReportForm form = new WMSOffice.Dialogs.ReportForm())
                    {
                        form.Text = string.Format("Реєстр архівних документів № {0}", this.RegisterID);

                        form.ReportDocument = report;
                        form.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
