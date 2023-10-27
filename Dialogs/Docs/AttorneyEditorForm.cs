using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.Custom;
using WMSOffice.Controls;
using System.IO;
using WMSOffice.Dialogs.Sert;
using System.Drawing.Imaging;
using System.Transactions;
using WMSOffice.Window;
using System.Xml;

namespace WMSOffice.Dialogs.Docs
{
    public partial class AttorneyEditorForm : DialogForm
    {
        /// <summary>
        /// Критичный размер файла, при котором пользователю будет отображена ошибка (10 МБ)
        /// </summary>
        private const long MAX_FILE_SIZE = 10485760;

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
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        /// <summary>
        /// Свойства доверенности
        /// </summary>
        public AttorneyProperties AttorneyProperties { get; set; } 

        public AttorneyEditorForm()
        {
            InitializeComponent();
        }
       
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(517, 8);
            this.btnCancel.Location = new Point(607, 8);

            this.WindowState = FormWindowState.Maximized;

            this.Initialize();
        }

        private bool canInitAgreements = false;

        private void Initialize()
        {
            btnSelectDebtorsForClone.Enabled = false;

            this.LoadSettings();

            canInitAgreements = false;
            this.LoadDebtors();
            canInitAgreements = true;

            this.LoadAgreementsByDebtor();

            if (this.AttorneyProperties != null)
            {
                tbAttorneyNumber.Text = this.AttorneyProperties.AttorneyNumber;
                tbAttorneyNumber.Enabled = false;

                cmbReceiver.SelectedValue = this.AttorneyProperties.ReceiverID;
                cmbReceiver.Enabled = false;

                dtpPeriodFrom.Value = this.AttorneyProperties.PeriodFrom ?? DateTime.Today;
                dtpPeriodTo.Value = this.AttorneyProperties.PeriodTo ?? DateTime.Today;

                if (this.AttorneyProperties.AgreementID != null)
                    cmbAgreements.SelectedValue = this.AttorneyProperties.AgreementID;

                cbPrintOnInvoice.Checked = this.AttorneyProperties.PrintOnInvoice ?? false;
                tbRestrictDaysCount.Text = this.AttorneyProperties.RestrictDaysCount.ToString();
            }
            else
            {
                cmbReceiver.Text = (string)null;
                this.Text = string.Format("*{0}", this.Text);
            }

            this.InitializeImageViewer();

            tbAttorneyNumber.Focus();
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

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeImageViewer()
        {
            try
            {
                ivcAttorneys.Items.Clear();
                ivcAttorneys.CurrentItem = null;

                ivcAgreements.Items.Clear();
                ivcAgreements.CurrentItem = null;

                if (this.AttorneyProperties != null)
                {
                    var receiverID = this.AttorneyProperties.ReceiverID;
                    var attorneyNumber = this.AttorneyProperties.AttorneyNumber;

                    #region ДОВЕРЕННОСТИ

                    var bw = new BackgroundWorker();
                    bw.DoWork += (s, e) =>
                    {
                        try
                        {
                            using (var adapter = new Data.WHTableAdapters.AC_AttachmentsTableAdapter())
                                e.Result = adapter.GetData(receiverID, attorneyNumber);
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

                    #endregion

                    foreach (Data.WH.AC_AttachmentsRow row in wH.AC_Attachments.Rows)
                        ivcAttorneys.Items.Add(new ImageProxy(row.image_buffer, (string)null) { Properties = row });

                    ivcAttorneys.CurrentItem = ivcAttorneys.Items.Count > 0
                        ? ivcAttorneys.Items[0]
                        : new ImageProxy(Properties.Resources.absentimage);

                    btnDeleteAttachment.Enabled = ivcAttorneys.Items.Count > 0;
                }
                else
                {
                    btnDeleteAttachment.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool debtorsLoadingCompleted = false;
        private void LoadDebtors()
        {
            debtorsLoadingCompleted = false;

            try
            {
                var receiverID = this.AttorneyProperties == null ? (double?)null : this.AttorneyProperties.ReceiverID;

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    try
                    {
                        using (var adapter = new Data.WHTableAdapters.AC_DebtorsTableAdapter())
                            e.Result = adapter.GetData(this.UserID, receiverID, (string)null, (string)null, (int?)null);
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
                        wH.AC_Debtors.Merge(e.Result as Data.WH.AC_DebtorsDataTable);
                        aCDebtorsBindingSource.DataSource = e.Result;

                        cmbReceiver.SelectedItem = null;
                    }

                    splashForm.CloseForce();
                };
                splashForm.ActionText = "Выполняется загрузка справочника получателей..";
                wH.AC_Debtors.Clear();
                aCDebtorsBindingSource.DataSource = null;
                bw.RunWorkerAsync();
                splashForm.ShowDialog();

                //cmbReceiver.SelectedItem = null;

                debtorsLoadingCompleted = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbReceiver_SelectedValueChanged(object sender, EventArgs e)
        {
            if (debtorsLoadingCompleted)
            {
                var receiverID = Convert.ToDouble(cmbReceiver.SelectedValue);
                var drDebtor = wH.AC_Debtors.FindBydebtor_id(receiverID);

                wH.AC_Debtors_For_Clone.Clear();

                var canLoadDebtorsForClone = drDebtor != null && (drDebtor.IsIs_Main_DebtorNull() ? false : drDebtor.Is_Main_Debtor);

                if (canLoadDebtorsForClone)
                    this.LoadDebtorsForClone();

                btnSelectDebtorsForClone.Enabled = canLoadDebtorsForClone;

                this.LoadAgreementsByDebtor();
            }
        }

        private void LoadAgreementsByDebtor()
        {
            try
            {
                if (canInitAgreements)
                {
                    wH.AgreementsByVendor.Clear();
                    agreementsByVendorBindingSource.DataSource = null;

                    var agreementsByDebtor = new Data.WH.AgreementsByVendorDataTable();
                    var vendorCode = cmbReceiver.SelectedValue == null ? (string)null : cmbReceiver.SelectedValue.ToString();
                    using (var adapter = new Data.WHTableAdapters.AgreementsByVendorTableAdapter())
                        adapter.Fill(agreementsByDebtor, vendorCode);

                    wH.AgreementsByVendor.Merge(agreementsByDebtor);
                    agreementsByVendorBindingSource.DataSource = wH.AgreementsByVendor;

                    cmbAgreements.SelectedItem = null;

                    var cntAgreements = wH.AgreementsByVendor.Rows.Count; 
                    if (cntAgreements == 1)
                        cmbAgreements.SelectedValue = wH.AgreementsByVendor[0].DocID;

                    cmbAgreements.Enabled = tbAgreementFrom.Enabled = tbAgreementTo.Enabled = cntAgreements > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbAgreements_SelectedValueChanged(object sender, EventArgs e)
        {
            tbAgreementFrom.Clear();
            tbAgreementTo.Clear();

            if (cmbAgreements.SelectedValue == null)
                return;

            var agreement = (cmbAgreements.SelectedItem as DataRowView).Row as Data.WH.AgreementsByVendorRow;
            tbAgreementFrom.Text = agreement.DateStart.ToString("dd.MM.yyyy");
            tbAgreementTo.Text = agreement.DateEnd.ToString("dd.MM.yyyy");
        }

        /// <summary>
        /// Загрузка списка точек доставки по главному дебитору
        /// </summary>
        private void LoadDebtorsForClone()
        {
            try
            {
                var receiverID = Convert.ToDouble(cmbReceiver.SelectedValue);
                var updateMode = this.AttorneyProperties != null ? 1 : 0;
                var attorneyNumber = updateMode == 1 ? this.AttorneyProperties.AttorneyNumber.Trim() : (string)null;

                using (var adapter = new Data.WHTableAdapters.AC_Debtors_For_CloneTableAdapter())
                    adapter.Fill(wH.AC_Debtors_For_Clone, this.UserID, (string)null, receiverID, updateMode, attorneyNumber);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSelectDebtorsForClone_Click(object sender, EventArgs e)
        {
            var dlgAttorneyDebtorsForCloneSelector = new AttorneyDebtorsForCloneSelectorForm() { Items = wH.AC_Debtors_For_Clone };
            if (dlgAttorneyDebtorsForCloneSelector.ShowDialog() == DialogResult.OK)
            {
                var sbDebtorsForClone = new StringBuilder();

                foreach (Data.WH.AC_Debtors_For_CloneRow rowDebtor in wH.AC_Debtors_For_Clone)
                {
                    var debtorID = rowDebtor.Shan;
                    var canAcces = rowDebtor.IsCan_AccessNull() ? false : rowDebtor.Can_Access;
                    var isSelected = rowDebtor.IsIsSelectedNull() ? false : rowDebtor.IsSelected;

                    if (canAcces && isSelected)
                    {
                        if (sbDebtorsForClone.Length == 0)
                            sbDebtorsForClone.AppendFormat("{0}", debtorID);
                        else
                            sbDebtorsForClone.AppendFormat(", {0}", debtorID);
                    }
                }

                tbDebtorsForClone.Text = sbDebtorsForClone.ToString();
            }
        }

        /// <summary>
        /// Формирования списка точек доставки для клонирования в виде XML
        /// </summary>
        /// <returns></returns>
        private string PrepareDebtorsForCloneXML()
        {
            var doc = new XmlDocument();
            var root = (XmlElement)doc.AppendChild(doc.CreateElement("root"));

            foreach (Data.WH.AC_Debtors_For_CloneRow rowDebtor in wH.AC_Debtors_For_Clone)
            {
                var debtorID = rowDebtor.Shan;
                var canAcces = rowDebtor.IsCan_AccessNull() ? false : rowDebtor.Can_Access;
                var isSelected = rowDebtor.IsIsSelectedNull() ? false : rowDebtor.IsSelected;

                if (canAcces && isSelected)
                {
                    var node = (XmlElement)root.AppendChild(doc.CreateElement("shan"));
                    node.SetAttribute("ID", debtorID.ToString());
                }
            }

            return root.HasChildNodes ? doc.InnerXml : (string)null;
        }

        private void btnAddAttachment_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ofg = new OpenFileDialog())
                {
                    ofg.Title = "Выбор фотографий";
                    ofg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    ofg.Multiselect = true;
                    ofg.Filter = "Файлы-изображения в форматах JPEG, JPG, PNG, GIF, ICO, TIF, TIFF, PDF|*.JPEG;*.JPG;*.PNG;*.GIF;*.ICO;*.TIF;*.TIFF;*.PDF;";

                    if (ofg.ShowDialog() == DialogResult.OK)
                    {
                        //var cntImages = ivcAttorneys.Items.Count;

                        foreach (var imagePath in ofg.FileNames)
                        {
                            var fileInfo = new FileInfo(imagePath);
                            if (fileInfo.Length > MAX_FILE_SIZE)
                                throw new Exception("Размер файла не может превышать 10Мб.");

                            var cntImages = ivcAttorneys.Items.Count;

                            ivcAttorneys.Items.Add(new ImageProxy(imagePath) { Properties = null });

                            ivcAttorneys.Items[cntImages].LoadImage();
                            ivcAttorneys.CurrentItem = ivcAttorneys.Items[cntImages];
                        }

                        //ivcAttorneys.Items[cntImages].LoadImage();
                        //ivcAttorneys.CurrentItem = ivcAttorneys.Items[cntImages];

                        if (ivcAttorneys.Items.Count > 0)
                            btnDeleteAttachment.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //this.InitializeImageViewer();
            }
        }

        private void btnDeleteAttachment_Click(object sender, EventArgs e)
        {
            var properties = ivcAttorneys.CurrentItem.Properties;
            if (properties != null)
            {
                var data = properties as Data.WH.AC_AttachmentsRow;
                data.Delete();
            }

            var idxCurrentItem = ivcAttorneys.Items.IndexOf(ivcAttorneys.CurrentItem);

            ivcAttorneys.Items.Remove(ivcAttorneys.CurrentItem);

            var cntImages = ivcAttorneys.Items.Count;

            ivcAttorneys.CurrentItem = cntImages > 0
                ? cntImages == idxCurrentItem 
                    ? ivcAttorneys.Items[cntImages - 1]
                    : ivcAttorneys.Items[idxCurrentItem]
                : new ImageProxy(Properties.Resources.absentimage);

            if (cntImages == 0)
                btnDeleteAttachment.Enabled = false;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            this.LoadAgreements();
        }

        private void LoadAgreements()
        {
            try
            {
                ivcAgreements.Items.Clear();
                ivcAgreements.CurrentItem = null;

                int receiverID = 0;
                if (cmbReceiver.SelectedValue == null || cmbReceiver.SelectedIndex == -1)
                    throw new Exception("Получатель должен быть указан.");
                else
                    receiverID = Convert.ToInt32(cmbReceiver.SelectedValue);

                #region ДОГОВОРА

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    try
                    {
                        using (var adapter = new Data.WHTableAdapters.AC_AgreementsTableAdapter())
                            e.Result = adapter.GetData(receiverID);
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

                        ivcAgreements.CurrentItem = ivcAgreements.Items.Count > 0
                            ? ivcAgreements.Items[ivcAgreements.Items.Count - 1]
                            : new ImageProxy(Properties.Resources.absentimage);
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

        private void AttorneyRegistrationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                var succees = this.SaveData();
                if (succees)
                {
                    this.SaveSettings();
                    this.ClearData();
                }

                e.Cancel = this.AttorneyProperties == null ? true : !succees;
            }
        }

        private bool SaveData()
        {
            try
            {
                var attorneyNumber = tbAttorneyNumber.Text.Trim();
                if (string.IsNullOrEmpty(attorneyNumber))
                    throw new Exception("№ доверенности должен быть указан.");

                int receiverID = 0;
                if (cmbReceiver.SelectedValue == null || cmbReceiver.SelectedIndex == -1)
                    throw new Exception("Получатель должен быть указан.");
                else
                    receiverID = Convert.ToInt32(cmbReceiver.SelectedValue);

                var periodFrom = dtpPeriodFrom.Value.Date;
                var periodTo = dtpPeriodTo.Value.Date;
                if (periodFrom > periodTo)
                    throw new Exception("Дата начала действия не должна превышать\nдату конца действия.");

                var printOnInvoice = Convert.ToInt32(cbPrintOnInvoice.Checked);

                int restrictDaysCount; 
                if (!int.TryParse(tbRestrictDaysCount.Text, out restrictDaysCount))
                    throw new Exception("Количество дней должно быть числом.");

                //var lstImageBuffer = new List<byte[]>();

                //#region ПРОВЕРКА НАЛИЧИЯ ИЗОБРАЖЕНИЙ

                //foreach (var imageProxy in imageViewerControl.Items)
                //{
                //    if (imageProxy.Properties != null)
                //        continue;

                //    var image = imageProxy.Image;
                //    if (!imageProxy.ImageLoaded)
                //        continue;

                //    var imageBuffer = ImageUtils.ConvertToByteArray(image, ImageFormat.Jpeg);
                //    lstImageBuffer.Add(imageBuffer);
                //}

                //if (lstImageBuffer.Count == 0)
                //    throw new Exception("Хотя бы одно фото должно быть загружено.");

                //#endregion

                //var tranOptions = new TransactionOptions();
                //tranOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;

                //using (var scope = new TransactionScope(TransactionScopeOption.Required, tranOptions))
                //{
                    try
                    {
                        // Список точек доставки главного дебитора для клонирования
                        var debtorsForClone = this.PrepareDebtorsForCloneXML();

                        var agreementID = cmbAgreements.SelectedValue == null ? (long?)null : Convert.ToInt64(cmbAgreements.SelectedValue);

                        if (this.AttorneyProperties == null)
                        {
                            // Создание документа
                            using (var adapter = new Data.WHTableAdapters.AC_DocsTableAdapter())
                                adapter.Create(receiverID, attorneyNumber, periodFrom, periodTo, this.UserID, printOnInvoice, restrictDaysCount, debtorsForClone, agreementID);
                        }
                        else
                        {
                            // Модификация документа
                            using (var adapter = new Data.WHTableAdapters.AC_DocsTableAdapter())
                                adapter.Modify(receiverID, attorneyNumber, periodFrom, periodTo, this.UserID, printOnInvoice, restrictDaysCount, 0, debtorsForClone, agreementID);
                        }

                        //// Сохранение вложений
                        //foreach (var imageBuffer in lstImageBuffer)
                        //{
                        //    using (var adapter = new Data.WHTableAdapters.AC_AttachmentsTableAdapter())
                        //        adapter.Add(receiverID, attorneyNumber, imageBuffer, this.UserID);
                        //}

                        // Сохранение вложений
                        //
                        foreach (var image in ivcAttorneys.Items)
                        { 
                            if (image.Properties == null)
                            {
                                // Добавление нового вложения
                                if (image.ImageLoaded)
                                {
                                    //var imageBuffer = ImageUtils.ConvertToByteArray(image.Image, ImageFormat.Tiff);
                                    var imageBuffer = image.ImageBuffer;
                                    using (var adapter = new Data.WHTableAdapters.AC_AttachmentsTableAdapter())
                                        adapter.Add(receiverID, attorneyNumber, imageBuffer, this.UserID);
                                }
                            }
                        }

                        foreach (Data.WH.AC_AttachmentsRow row in wH.AC_Attachments.Rows)
                        {
                            // Удаление вложения
                            if (row.RowState == DataRowState.Deleted)
                            {
                                var attachmentID = Convert.ToInt32(row[wH.AC_Attachments.idColumn, DataRowVersion.Original]);
                                using (var adapter = new Data.WHTableAdapters.AC_AttachmentsTableAdapter())
                                    adapter.Remove(receiverID, attorneyNumber, attachmentID, this.UserID);
                            }
                        }
                       
                        var drDebtor = wH.AC_Debtors.FindBydebtor_id(receiverID);
                        var isMainDebtor = drDebtor != null && (drDebtor.IsIs_Main_DebtorNull() ? false : drDebtor.Is_Main_Debtor);

                        if (isMainDebtor)
                        {
                            // Клонирование изображений для торговых точек
                            using (var adapter = new Data.WHTableAdapters.AC_AttachmentsTableAdapter())
                                adapter.Clone(receiverID, attorneyNumber, this.UserID, debtorsForClone);
                        }

                        //scope.Complete();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                //}

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void ClearData()
        {
            tbAttorneyNumber.Clear();
            cmbReceiver.Text = (string)null;

            tbDebtorsForClone.Clear();

            dtpPeriodFrom.Value = DateTime.Today;
            dtpPeriodTo.Value = DateTime.Today;

            cbPrintOnInvoice.Checked = true;
            tbRestrictDaysCount.Text = "3";

            this.InitializeImageViewer();

            tbAttorneyNumber.Focus();
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool lockerSearchReceivers = false;
        private void cmbReceiver_TextChanged(object sender, EventArgs e)
        {
            //if (!lockerSearchReceivers && cmbReceiver.Text.Length >= 3)
            //    timerSearchReceivers.Enabled = true;
        }

        private void timerSearchReceivers_Tick(object sender, EventArgs e)
        {
            //lockerSearchReceivers = true;
            //timerSearchReceivers.Enabled = false;
            //SearchReceivers();
            //lockerSearchReceivers = false;
        }

        private void SearchReceivers()
        {
            //var pattern = cmbReceiver.Text;
            //if (!string.IsNullOrEmpty(pattern))
            //{
            //    aC_DebtorsTableAdapter.Fill(wH.AC_Debtors, this.UserID, (double?)null, pattern);
            //}
        }
    }
}
