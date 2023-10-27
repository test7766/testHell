using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs.Sert;
using System.IO;
using WMSOffice.Controls.Custom;

namespace WMSOffice.Dialogs.Quality
{
    public partial class ImportLicenseItemDocsForm : DialogForm
    {
        private readonly Data.Quality.QK_LI_LicItemsRow _item = null;

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();


        public ImportLicenseItemDocsForm()
        {
            InitializeComponent();
        }

        public ImportLicenseItemDocsForm(Data.Quality.QK_LI_LicItemsRow item)
            : this()
        {
            _item = item;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Text = string.Format("{0} {1} [{2}]", this.Text, _item.ItemName.Trim(), _item.ItemID);

            btnOK.Location = new Point(517, 8);
            btnCancel.Location = new Point(607, 8);

            btnOK.Visible = false;
            btnCancel.Text = "Закрыть";

            this.Initialize();
        }

        private void Initialize()
        {
            this.SetOperationsAccess();
            this.LoadDocs();
        }

        private void btnRefreshData_Click(object sender, EventArgs e)
        {
            this.LoadDocs();
        }

        private void LoadDocs()
        {
            try
            {
                var loadWorker = new BackgroundWorker();
                loadWorker.DoWork += (s, e) => 
                {
                    try 
	                {
                        e.Result = qK_LI_LicItem_DocsTableAdapter.GetData(this.UserID, _item.ItemID, _item.IsNoRegNull() ? (string)null : _item.NoReg, _item.IsGMPNull() ? (string)null : _item.GMP);
	                }
	                catch (Exception ex)
	                {
                        e.Result = ex;
	                }
                };
                loadWorker.RunWorkerCompleted += (s, e) =>
                {
                    splashForm.CloseForce();

                    if (e.Result is Exception)
                        MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        qKLILicItemDocsBindingSource.DataSource = e.Result as Data.Quality.QK_LI_LicItem_DocsDataTable;
                };
                qKLILicItemDocsBindingSource.DataSource = null;
                splashForm.ActionText = "Выполняется загрузка документов..";
                loadWorker.RunWorkerAsync();
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            this.PreviewDoc();
        }

        private void dgvDocs_SelectionChanged(object sender, EventArgs e)
        {
            this.SetOperationsAccess();
        }

        private void SetOperationsAccess()
        {
            btnPreview.Enabled = dgvDocs.SelectedRows.Count > 0;
        }

        private void dgvDocs_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.PreviewDoc();
        }

        private void PreviewDoc()
        {
            try
            {
                #region

                var doc = (dgvDocs.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.Quality.QK_LI_LicItem_DocsRow;

                var ivcDocument = new WMSOffice.Controls.Custom.ImageViewerControl();
                ivcDocument.CurrentItem = null;

                if (doc.DocSource == "Kadex")
                {
                    Data.Sert.ItemRegCertImagesDataTable table = null;
                    using (Data.SertTableAdapters.ItemRegCertImagesTableAdapter adapter = new Data.SertTableAdapters.ItemRegCertImagesTableAdapter())
                        table = adapter.GetData(doc.DataID, null);

                    foreach (Data.Sert.ItemRegCertImagesRow row in table.Rows)
                    {
                        // Выгружаем бинарный файл на диск
                        var tmpFileName = Path.GetTempFileName();
                        File.WriteAllBytes(tmpFileName, row.ImageBody);

                        ivcDocument.Items.Add(new ImageProxy(tmpFileName, row.ImageExt) { Properties = row });
                        ivcDocument.Items[ivcDocument.Items.Count - 1].LoadImage();
                    }
                }
                else if (doc.DocSource == "Accantum")
                {
                    Data.Sert.AccantumImagesDataTable table = null;
                    using (Data.SertTableAdapters.AccantumImagesTableAdapter adapter = new WMSOffice.Data.SertTableAdapters.AccantumImagesTableAdapter())
                        table = adapter.GetData(doc.DataID);

                    foreach (Data.Sert.AccantumImagesRow row in table.Rows)
                    {
                        // Выгружаем бинарный файл на диск
                        var tmpFileName = Path.GetTempFileName();
                        File.WriteAllBytes(tmpFileName, row.BinaryData);

                        ivcDocument.Items.Add(new ImageProxy(tmpFileName, row.ImageExt) { Properties = row });
                        ivcDocument.Items[ivcDocument.Items.Count - 1].LoadImage();
                    }
                }

                #region obdolete
                //foreach (Data.PrintNakl.EN_Doc_Dependent_ImagesRow docImageInfo in docDependentImages.Rows)
                //{
                //    try
                //    {
                //        docBinary = docImageInfo.Converted_bin;
                //        if (docBinary == null)
                //            continue;

                //        // Выгружаем бинарный PDF во временный файл
                //        var tmpFileName = Path.GetTempFileName();
                //        File.WriteAllBytes(tmpFileName, docBinary);

                //        ivcDocument.Items.Add(new ImageProxy(tmpFileName, ".PDF") { Properties = docImageInfo });
                //        ivcDocument.Items[ivcDocument.Items.Count - 1].LoadImage();
                //    }
                //    catch (Exception ex)
                //    {
                //        this.ShowError(ex);
                //    }
                //}


                //if (ivcDocument.Items.Count == 0)
                //    throw new Exception("Отсутствует документ для экспорта.");
                #endregion


                ivcDocument.CurrentItem = ivcDocument.Items.Count > 0 ? ivcDocument.Items[0] : new WMSOffice.Controls.Custom.ImageProxy(Properties.Resources.absentimage);
                var properties = ""; // ivcDocument.CurrentItem.Properties as Data.Sert.ItemRegCertImagesRow;
                var fileName = ""; // string.Format("{0}-{1} ({2}).PDF", properties.Doc_Type, properties.DOC, properties.DCT);

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
                    properties = ""; // ivcDocument.CurrentItem.Properties as Data.Sert.ItemRegCertImagesRow;
                    fileName = ""; // string.Format("{0}-{1} ({2}).PDF", properties.Doc_Type, properties.DOC, properties.DCT);
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

                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
