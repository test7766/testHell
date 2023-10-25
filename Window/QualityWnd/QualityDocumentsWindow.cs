using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Classes;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Dialogs;
using System.Diagnostics;
using WMSOffice.Dialogs.Sert;
using System.IO;
using System.Drawing.Imaging;
using WMSOffice.Dialogs.Quality;

namespace WMSOffice.Window.QualityWnd
{
    public partial class QualityDocumentsWindow : GeneralWindow
    {
        #region Вспомогательный класс для отображения документов

        private class DocDetailSearchParam : SearchParametersBase
        {
            public int? ItemId { get; set; }
            public string VendorLot { get; set; }
        }

        private class DocumentsView : IDataView
        {
            public DocumentsView()
            {
                dataColumns.Add(new PatternColumn("№", "RowNum", new FilterPatternExpressionRule("RowNum"), SummaryCalculationType.Count));
                dataColumns.Add(new PatternColumn("Аббревиатура документа", "Abbreviation", new FilterPatternExpressionRule("Abbreviation"), SummaryCalculationType.None));
                dataColumns.Add(new PatternColumn("Тип документа", "DocType", new FilterPatternExpressionRule("DocType"), SummaryCalculationType.None));
                dataColumns.Add(new PatternColumn("Наименование", "DocName", new FilterPatternExpressionRule("DocName"), SummaryCalculationType.None));
                dataColumns.Add(new PatternColumn("Дата создания", "DocCreated", new FilterPatternExpressionRule("DocCreated"), SummaryCalculationType.None));
                dataColumns.Add(new PatternColumn("Дата дейстия", "DateAction", new FilterPatternExpressionRule("DateAction"), SummaryCalculationType.None));

            }

            #region IDataView Members

            /// <summary>
            /// Коллекция отображаемых колонок
            /// </summary>
            private PatternColumnsCollection dataColumns = new PatternColumnsCollection();

            public PatternColumnsCollection Columns { get { return dataColumns; } }

            /// <summary>
            /// Источник данных для представления
            /// </summary>
            private DataTable data;

            /// <summary>
            /// Источник данных для представления
            /// </summary>
            public DataTable Data { get { return data; } }

            public void FillData(SearchParametersBase searchParameters)
            {
                var docParam = searchParameters as DocDetailSearchParam;
                if (docParam == null)
                    return;

                try
                {
                    using (var adapter = new Data.QualityTableAdapters.WMS_GetImagesBySerieAndItemsTableAdapter())
                        data = adapter.GetData(docParam.VendorLot, docParam.ItemId);

                }
                catch (Exception)
                {
                    data = new Data.Quality.WMS_GetImagesBySerieAndItemsDataTable();
                }

            }


            #endregion
        }

        #endregion

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private SplashForm splashForm = new SplashForm();

        public QualityDocumentsWindow()
        {
            InitializeComponent();

            DateStart = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateEnd = DateTime.Today;

            btnPrint.Enabled = btnSave.Enabled = false;
        }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        public long? ItemId { get; set; }

        public String VendorLot { get; set; }

        public String BatchId { get; set; }

        public long? DocId { get; set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Binding binding = new Binding("Value", this, "DateStart") { DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged };
            dateStart.DataBindings.Add(binding);

            binding = new Binding("Value", this, "DateEnd") { DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged };
            dateEnd.DataBindings.Add(binding);

            binding = new Binding("Text", this, "ItemId", true, DataSourceUpdateMode.OnPropertyChanged, string.Empty);
            textItemId.DataBindings.Add(binding);

            binding = new Binding("Text", this, "VendorLot") { DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged };
            textVendorLot.DataBindings.Add(binding);

            binding = new Binding("Text", this, "BatchId") { DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged };
            textBatchId.DataBindings.Add(binding);

            binding = new Binding("Text", this, "DocId", true, DataSourceUpdateMode.OnPropertyChanged, string.Empty);
            textDocId.DataBindings.Add(binding);

            PrepareGridViews();
        }

        private void PrepareGridViews()
        {
            extraDataGridView.Init(new DocumentsView(), true);

            extraDataGridView.UserID = UserID;
            extraDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            extraDataGridView.AllowRangeColumns = true;
            extraDataGridView.UseMultiSelectMode = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var row = ((DataRowView)dataGridView.CurrentRow.DataBoundItem).Row as Data.Quality.QK_Docs_ForPrintRow;
            if (row == null)
                return;

            var dlg = new SaveFileDialog { Filter = "Image|*.tiff", FileName = row.Item_Name.Replace(':', '_').Replace(@"\", "_").Replace(@"/", "_") };
            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            var fileName = dlg.FileName;

            try
            {
                var buffer = PrepareBuffer();
                if (buffer == null)
                    return;


                var fs = File.Create(fileName);
                fs.Write(buffer, 0, buffer.Length);
                fs.Flush();
                fs.Close();

                MessageBox.Show("Файл успешно сохранен.", "Сохранить...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException ?? ex;
                MessageBox.Show(ex.Message, "Сохранить...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (File.Exists(fileName))
                    File.Delete(fileName);
            }
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            qK_Docs_ForPrintTableAdapter.Fill(quality.QK_Docs_ForPrint, DateStart, DateEnd, ItemId, String.IsNullOrEmpty(VendorLot) ? null : VendorLot, String.IsNullOrEmpty(BatchId) ? null : BatchId, DocId);

        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                ShowError(e.Result as Exception);

            splashForm.CloseForce();
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Data.Quality.QK_Docs_ForPrintRow row = null;
                Invoke((MethodInvoker)delegate
                {
                    row = ((DataRowView)dataGridView.CurrentRow.DataBoundItem).Row as Data.Quality.QK_Docs_ForPrintRow;
                });

                if (row == null)
                    return;

                var view = extraDataGridView.DataView;
                view.FillData(new DocDetailSearchParam { ItemId = row.Item_ID, VendorLot = row.Vendor_Lot });
                extraDataGridView.BindData(false);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex, "ERROR");
            }
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            //var worker = new BackgroundWorker();
            //worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            //worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            //worker.RunWorkerAsync();
            //splashForm.ActionText = "Подготовка данных...";
            //splashForm.ShowDialog();

            btnPrint.Enabled = btnSave.Enabled = (dataGridView.CurrentRow != null);

            try
            {
                Data.Quality.QK_Docs_ForPrintRow row = null;
                Invoke((MethodInvoker)delegate
                {
                    row = ((DataRowView)dataGridView.CurrentRow.DataBoundItem).Row as Data.Quality.QK_Docs_ForPrintRow;
                });

                if (row == null)
                    return;

                var view = extraDataGridView.DataView;
                view.FillData(new DocDetailSearchParam { ItemId = row.Item_ID, VendorLot = row.Vendor_Lot });
                extraDataGridView.BindData(false);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex, "ERROR");
            }
        }

        private byte[] PrepareBuffer()
        {
            List<byte[]> images = new List<byte[]>();
            var items = extraDataGridView.SelectedItems;

            foreach (var item in items)
            {
                var row = item as Data.Quality.WMS_GetImagesBySerieAndItemsRow;
                if (row == null)
                    continue;

                var imgList = ImageUtils.ExtractImageLayersFromDataBufferEx(row.ImageData, row.Extension);
                if (imgList == null)
                    continue;

                images.AddRange(imgList);
            }

            return PrepareBuffer(images);
        }

        private byte[] PrepareBuffer(List<byte[]> buffers)
        {
            try
            {
                string fileName = Path.GetTempFileName();

                var encoder = System.Drawing.Imaging.Encoder.SaveFlag;
                ImageCodecInfo encoderInfo = new List<ImageCodecInfo>(ImageCodecInfo.GetImageEncoders()).Find(i => i.MimeType == "image/tiff");
                EncoderParameters encoderParameters = new EncoderParameters(1);
                encoderParameters.Param[0] = new EncoderParameter(encoder, (long)EncoderValue.MultiFrame);


                // Save the first frame of the multi page tiff
                Image firstImage = Image.FromStream(new MemoryStream(buffers[0]));
                firstImage.Save(fileName, encoderInfo, encoderParameters);
                encoderParameters.Param[0] = new EncoderParameter(encoder, (long)EncoderValue.FrameDimensionPage);


                // Add the remining images to the tiff
                for (int i = 1; i < buffers.Count; i++)
                {
                    Image img = Image.FromStream(new MemoryStream(buffers[i]));
                    firstImage.SaveAdd(img, encoderParameters);
                }

                // Close out the file
                encoderParameters.Param[0] = new EncoderParameter(encoder, (long)EncoderValue.Flush);
                firstImage.SaveAdd(encoderParameters);

                var fs = File.Open(fileName, FileMode.Open);


                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                //MemoryStream ms = new MemoryStream(buffer);
                //ms.Flush();
                fs.Close();

                return buffer;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void Print_Click(object sender, EventArgs e)
        {
            var row = ((DataRowView)dataGridView.CurrentRow.DataBoundItem).Row as Data.Quality.QK_Docs_ForPrintRow;
            if (row == null)
                return;

            var buffer = PrepareBuffer();
            if (buffer == null)
                return;

            var dlg = new QualityDocsPreviewForm(buffer) { Owner = this, StartPosition = FormStartPosition.CenterParent, ShowInTaskbar = false };
            dlg.ShowDialog();
        }
    }
}
