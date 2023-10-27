using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Window;
using System.IO;
using System.Threading;
using System.Diagnostics;
using WMSOffice.Controls.Custom;

namespace WMSOffice.Dialogs.WH
{
    public partial class DebitOrderSelectInvoiceForm : DialogForm
    {
        private readonly Data.WH.PurchaseOrdersForDebitRow order = null;

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        public EDocRegistryView DocsView { get { return xdgvDocs.DataView as EDocRegistryView; } }
        public EDocRegistryViewRow SelectedDoc { get { return this.DocsView.ConvertRow(xdgvDocs.SelectedItem); } }

        public DebitOrderSelectInvoiceForm()
        {
            InitializeComponent();
        }

        public DebitOrderSelectInvoiceForm(Data.WH.PurchaseOrdersForDebitRow pOrder)
            : this()
        {
            order = pOrder;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(567, 8);
            this.btnCancel.Location = new Point(657, 8);

            this.Initialize();   
        }

        private void Initialize()
        {
            try
            {
                xdgvDocs.Init(new EDDocRegistryView(true), true);
                xdgvDocs.LoadExtraDataGridViewSettings(string.Format("{0}_{1}", this.Name, this.DocsView.GetType().Name));
                xdgvDocs.UserID = this.UserID;

                xdgvDocs.OnDataError += new DataGridViewDataErrorEventHandler(xdgvDocs_OnDataError);
                xdgvDocs.OnRowSelectionChanged += new EventHandler(xdgvDocs_OnRowSelectionChanged);
                xdgvDocs.OnFilterChanged += new EventHandler(xdgvDocs_OnFilterChanged);
                xdgvDocs.OnDataBindingComplete += new DataGridViewBindingCompleteEventHandler(xdgvDocs_OnDataBindingComplete);
                xdgvDocs.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvDocs_OnFormattingCell);
                xdgvDocs.OnRowDoubleClick += new DataGridViewCellEventHandler(xdgvDocs_OnRowDoubleClick);

                xdgvDocs.SetSameStyleForAlternativeRows();

                // активация постраничного просмотра
                xdgvDocs.CreatePageNavigator();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.ReloadDocs();
            }
        }

        void xdgvDocs_OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        void xdgvDocs_OnRowSelectionChanged(object sender, EventArgs e)
        {
            this.SetOperationAccess(false);
        }

        void xdgvDocs_OnFilterChanged(object sender, EventArgs e)
        {
            xdgvDocs.RecalculateSummary();
            this.SetOperationAccess(true);
        }

        private void SetOperationAccess(bool wholeViewAccess)
        {
            var doc = this.SelectedDoc;

            if (wholeViewAccess)
            {
                btnPreview.Enabled = xdgvDocs.HasRows && doc.IsPreviewEnabled;
                btnExportToPDF.Enabled = xdgvDocs.HasRows && doc.IsExportToPDFEnabled;
                btnOK.Enabled = xdgvDocs.HasRows && doc.IsEnabled;
            }
            else
            {
                btnPreview.Enabled = doc.IsPreviewEnabled;
                btnExportToPDF.Enabled = doc.IsExportToPDFEnabled;
                btnOK.Enabled = doc.IsEnabled;
            }
        }

        /// <summary>
        /// Пустое изображение
        /// </summary>
        private static Bitmap emptyIcon = new Bitmap(16, 16);

        void xdgvDocs_OnDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in xdgvDocs.DataGrid.Rows)
            {
                var boundRow = (xdgvDocs.DataGrid.Rows[row.Index].DataBoundItem as DataRowView).Row;

                foreach (DataGridViewColumn column in xdgvDocs.DataGrid.Columns)
                {
                    #region ПОДСТАНОВКА ИКОНОК ПО НАЛИЧИЮ ВЛОЖЕНИЙ

                    if (column is DataGridViewImageColumn)
                    {
                        if (column.Tag != null)
                        {
                            string linkedFieldName = column.Tag.ToString();
                            if (linkedFieldName == "Has_Attachment")
                            {
                                //var stateID = Convert.ToByte(boundRow["State_ID"]);
                                //var hasAttachment = stateID >= 120;

                                var hasAttachment = boundRow.Table.Columns.Contains("Has_Attachment") && Convert.ToBoolean(boundRow["Has_Attachment"]);

                                if (hasAttachment)
                                {
                                    var hasArchiveAttachment = boundRow.Table.Columns.Contains("Export_DTTM") && !boundRow["Export_DTTM"].Equals(DBNull.Value);

                                    if (hasArchiveAttachment)
                                        xdgvDocs.DataGrid.Rows[row.Index].Cells[column.Index].Value = Properties.Resources.pin_yellow;
                                    else
                                        xdgvDocs.DataGrid.Rows[row.Index].Cells[column.Index].Value = Properties.Resources.pin_red;
                                }
                                else
                                    xdgvDocs.DataGrid.Rows[row.Index].Cells[column.Index].Value = emptyIcon;
                            }
                        }
                    }

                    #endregion
                }
            }
        }

        void xdgvDocs_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            var boundRow = (xdgvDocs.DataGrid.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;

            #region СТИЛЬ ДЛЯ ИНДИКАЦИИ СТАТУСОВ

            var color = Color.Empty;

            var stateID = Convert.ToByte(boundRow["State_ID"]);
            var docAmount = Convert.ToDecimal(boundRow["DocAmountWithVAT"]);

            stateID = docAmount.Equals(0.00M) ? (byte)ENDocRegistryView.ENDocState.Canceled : stateID; // переопределим статус индикации для нулевой суммы

            if ((color = this.DocsView.GetDocBackColorByDocRow(boundRow)) != Color.Empty)
            {
                e.CellStyle.BackColor = color;
                e.CellStyle.SelectionForeColor = color;
            }

            #endregion

            #region СТИЛЬ ДЛЯ ИНДИКАЦИИ ОШИБКИ

            var hasError = boundRow.Table.Columns.Contains("Error_msg") && boundRow["Error_msg"] != DBNull.Value;
            if (hasError)
            {
                color = Color.Red;

                e.CellStyle.ForeColor = color;
                e.CellStyle.SelectionForeColor = color;

                color = Color.Yellow;
                e.CellStyle.SelectionBackColor = color;
            }

            #endregion
        }

        void xdgvDocs_OnRowDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Загрузка документов с применением фильтра
        /// </summary>
        private void ReloadDocs()
        {
            try
            {
                #region НАСТРОЙКА ПАРАМЕТРОВ ПОИСКА

                var searchParams = new EDocRegistrySearchParameters() { SessionID = this.UserID };

                searchParams.EDocType = "3"; // 3 - Расходная накладная

                searchParams.DebtorID = order.SuplierCod; // Код поставщика

                searchParams.EDocStateFromID = Convert.ToByte(0);
                searchParams.EDocStateToID = Convert.ToByte(60);

                //searchParams.PeriodFrom = DateTime.Today;
                //searchParams.PeriodTo = DateTime.Today;

                #endregion

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    this.DocsView.FillData(e.Argument as EDocRegistrySearchParameters);
                };
                bw.RunWorkerCompleted += (s, e) =>
                {
                    if (e.Result is Exception)
                        MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        this.xdgvDocs.BindData(false);

                        //this.xdgvDocs.AllowFilter = true;
                        this.xdgvDocs.AllowSummary = true;
                    }

                    splashForm.CloseForce();
                };

                splashForm.ActionText = "Выполняется получение реестра электронных документов..";
                bw.RunWorkerAsync(searchParams);
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            this.Preview();
        }

        /// <summary>
        /// Просмотр документа
        /// </summary>
        private void Preview()
        {
            try
            {
                var workModeKey = "ED"; // ED - Входящие ЭДО 

                var doc = this.SelectedDoc;

                var eDocID = doc.DocID;

                byte[] docBinary = null;

                var docDependentImages = new Data.PrintNakl.EN_Doc_Dependent_ImagesDataTable();
                using (var adapter = new Data.PrintNaklTableAdapters.EN_Doc_Dependent_ImagesTableAdapter())
                    adapter.Fill(docDependentImages, eDocID, workModeKey);

                var ivcDocument = new WMSOffice.Controls.Custom.ImageViewerControl();
                ivcDocument.CurrentItem = null;

                foreach (Data.PrintNakl.EN_Doc_Dependent_ImagesRow docImageInfo in docDependentImages.Rows)
                {
                    try
                    {
                        docBinary = docImageInfo.Converted_bin;
                        if (docBinary == null)
                            continue;

                        // Выгружаем бинарный PDF во временный файл
                        var tmpFileName = Path.GetTempFileName();
                        File.WriteAllBytes(tmpFileName, docBinary);

                        ivcDocument.Items.Add(new ImageProxy(tmpFileName, ".PDF") { Properties = docImageInfo });
                        ivcDocument.Items[ivcDocument.Items.Count - 1].LoadImage();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (ivcDocument.Items.Count == 0)
                    throw new Exception("Отсутствует документ для просмотра.");

                ivcDocument.CurrentItem = ivcDocument.Items.Count > 0 ? ivcDocument.Items[0] : new WMSOffice.Controls.Custom.ImageProxy(Properties.Resources.absentimage);
                var properties = ivcDocument.CurrentItem.Properties as Data.PrintNakl.EN_Doc_Dependent_ImagesRow;
                var fileName = string.Format("{0}-{1} ({2}).PDF", properties.Doc_Type, properties.DOC, properties.DCT);

                #region КОНТЕЙНЕР ДЛЯ КОМПОНЕНТА ПРЕДВАРИТЕЛЬНОГО ПРОСМОТРА

                var dlgPreviewDocument = new Form()
                {
                    Text = string.Format("Просмотр документа {0}", fileName),
                    FormBorderStyle = FormBorderStyle.Sizable
                };
                dlgPreviewDocument.SizeChanged += (s, e) =>
                {
                    if (ivcDocument.AutoZoomActivated)
                        ivcDocument.ChangeZoom();
                };

                ivcDocument.PreviewCurrentItem += (s, e) =>
                {
                    properties = ivcDocument.CurrentItem.Properties as Data.PrintNakl.EN_Doc_Dependent_ImagesRow;
                    fileName = string.Format("{0}-{1} ({2}).PDF", properties.Doc_Type, properties.DOC, properties.DCT);
                    dlgPreviewDocument.Text = string.Format("Просмотр документа {0}", fileName);
                };

                dlgPreviewDocument.Controls.Add(ivcDocument);
                ivcDocument.Dock = DockStyle.Fill;

                var pnlFooter = new Panel();
                pnlFooter.Height = 43;
                dlgPreviewDocument.Controls.Add(pnlFooter);
                pnlFooter.Dock = DockStyle.Bottom;

                var btnClose = new Button()
                {
                    Text = "Закрыть",
                    DialogResult = DialogResult.Cancel,
                    Location = new Point(dlgPreviewDocument.Width - 75 - 25, 8),
                    Width = 75,
                    Anchor = AnchorStyles.Right | AnchorStyles.Bottom
                };
                pnlFooter.Controls.Add(btnClose);

                dlgPreviewDocument.CancelButton = btnClose;
                dlgPreviewDocument.WindowState = FormWindowState.Maximized;
                dlgPreviewDocument.ShowDialog(this);

                #endregion

                #region ОСВОБОЖДЕНИЕ ВРЕМЕННЫХ РЕСУРСОВ
                foreach (var item in ivcDocument.Items)
                {
                    try
                    {
                        var tmpFileName = item.FullName;
                        if (File.Exists(tmpFileName))
                            File.Delete(tmpFileName);
                    }
                    catch (Exception ex)
                    {

                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportToPDF_Click(object sender, EventArgs e)
        {
            this.ExportToPDF();
        }

        /// <summary>
        /// Экспорт документа в PDF
        /// </summary>
        private void ExportToPDF()
        {
            try
            {
                var workModeKey = "ED"; // ED - Входящие ЭДО 

                var doc = this.SelectedDoc;

                var eDocID = doc.DocID;

                byte[] docBinary = null;

                var docDependentImages = new Data.PrintNakl.EN_Doc_Dependent_ImagesDataTable();
                using (var adapter = new Data.PrintNaklTableAdapters.EN_Doc_Dependent_ImagesTableAdapter())
                    adapter.Fill(docDependentImages, eDocID, workModeKey);

                var lstDocImagesInfo = new List<Data.PrintNakl.EN_Doc_Dependent_ImagesRow>();
                foreach (Data.PrintNakl.EN_Doc_Dependent_ImagesRow docImageInfo in docDependentImages.Rows)
                {
                    try
                    {
                        docBinary = docImageInfo.Converted_bin;
                        if (docBinary == null)
                            continue;

                        lstDocImagesInfo.Add(docImageInfo);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (lstDocImagesInfo.Count == 0)
                    throw new Exception("Отсутствует документ для экспорта.");

                foreach (Data.PrintNakl.EN_Doc_Dependent_ImagesRow docImageInfo in lstDocImagesInfo)
                {
                    try
                    {
                        var eDocType = docImageInfo.Doc_Type;

                        var docID = docImageInfo.DOC;
                        var docType = docImageInfo.DCT;

                        docBinary = docImageInfo.Converted_bin;
                        var fileName = string.Format("{0}-{1} ({2})", eDocType, docID, docType);

                        using (var dlgSaveToPDF = new SaveFileDialog())
                        {
                            dlgSaveToPDF.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                            dlgSaveToPDF.Title = "Экспорт документа";
                            dlgSaveToPDF.Filter = "Документ PDF|*.PDF";
                            dlgSaveToPDF.FileName = fileName;

                            if (dlgSaveToPDF.ShowDialog(this) == DialogResult.OK)
                            {
                                fileName = dlgSaveToPDF.FileName;
                                File.WriteAllBytes(fileName, docBinary);

                                Thread.Sleep(500);
                                Process.Start(dlgSaveToPDF.FileName);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DebitOrderSelectInvoiceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SelectInvoice();
        }

        private bool SelectInvoice()
        {
            try
            {
                xdgvDocs.SaveExtraDataGridViewSettings(string.Format("{0}_{1}", this.Name, this.DocsView.GetType().Name));

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
