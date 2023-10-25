using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using WMSOffice.Controls.Custom;

namespace WMSOffice.Dialogs.Quality
{
    public partial class InputControlDeliveryWorksheetDesinfectionCertEditForm  : DialogForm
    {
        ///// <summary>
        ///// Сплеш-окно, используемое при длительной обработке данных.
        ///// </summary>
        //private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        private readonly ShipmentDesinficationCertPackage _dcPackage = null;

        private readonly bool _readOnlyMode = false;

        private readonly Data.Quality.QK_SA_WorksheetsRow _selectedWorksheet = null;

        private readonly long? _routeListNumber = null;

        /// <summary>
        /// Режим отображения из анкеты разрешения на отгрузку (SA)
        /// </summary>
        public bool IsOriginatorMode { get { return _selectedWorksheet != null; } }

        public InputControlDeliveryWorksheetDesinfectionCertEditForm ()
        {
            InitializeComponent();
        }

        public InputControlDeliveryWorksheetDesinfectionCertEditForm(ShipmentDesinficationCertPackage dc_package, bool readOnlyMode)
            :this()
        {
            _dcPackage = dc_package;
            _selectedWorksheet = dc_package.SelectedWorksheet;
            _routeListNumber = dc_package.RouteListNumber;

            _readOnlyMode = readOnlyMode;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            btnOK.Location = new Point(417, 8);
            btnCancel.Location = new Point(507, 8);

            this.Initialize();

            //this.WindowState = FormWindowState.Maximized;
        }

        private void Initialize()
        {
            try
            {
                var hasAttacments = this.LoadAttachments();

                if (hasAttacments)
                    tcDocs.TabPages.Remove(tpDocTemplate);
                else
                    tcDocs.TabPages.Remove(tpDocCopy);


                if (this.IsOriginatorMode && !_readOnlyMode)
                {
                    var fieldViewerToolBar = crvDocTemplate.GetType().GetField("viewerToolBar", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                    var toolStrip = (ToolStrip)fieldViewerToolBar.GetValue(crvDocTemplate);
                    toolStrip.Items.Add(new ToolStripSeparator() { Alignment = ToolStripItemAlignment.Left });
                    toolStrip.Items.Add(new ToolStripButton(string.Empty, Properties.Resources.pin, btnDocCopy_Click) { Alignment = ToolStripItemAlignment.Left, ToolTipText = "Вложить паспорт" });
                }

                if (!hasAttacments)
                {
                    var report = new WMSOffice.Reports.InputControlDeliveryWorksheetDesinfectionCertReport();
                    var reportData = GetDesinfectionReportData();
                    report.SetDataSource(reportData);
                    crvDocTemplate.ReportSource = report;

                    foreach (Control control in crvDocTemplate.Controls) // hide report layers panel
                    {
                        if (control is CrystalDecisions.Windows.Forms.PageView)
                        {
                            TabControl tab = (TabControl)((CrystalDecisions.Windows.Forms.PageView)control).Controls[0];
                            tab.ItemSize = new Size(0, 1);
                            tab.SizeMode = TabSizeMode.Fixed;
                            tab.Appearance = TabAppearance.Buttons;
                        }
                    }
                }

                if (_readOnlyMode || !this.IsOriginatorMode || hasAttacments)
                {
                    this.btnOK.Visible = false;
                    this.btnCancel.Text = "Закрыть";
                }          
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool LoadAttachments()
        {
            using (var adapter = new Data.QualityTableAdapters.AP_Get_AttachmentsTableAdapter())
                adapter.FillSA(quality.AP_Get_Attachments, this.UserID, _routeListNumber);

            foreach (Data.Quality.AP_Get_AttachmentsRow attachment in quality.AP_Get_Attachments)
            {
                ivcDocCopy.Items.Clear();

                var fileName = attachment.FileName;
                var fileExtension = fileName.Substring(fileName.LastIndexOf('.'));
                var fileData = attachment.FileData;

                // Выгружаем бинарный документ во временный файл
                var tmpFileName = Path.GetTempFileName();
                File.WriteAllBytes(tmpFileName, fileData);

                ivcDocCopy.Items.Add(new ImageProxy(tmpFileName, fileExtension) { Properties = attachment });
                ivcDocCopy.Items[ivcDocCopy.Items.Count - 1].LoadImage();

                ivcDocCopy.CurrentItem = ivcDocCopy.Items.Count > 0 ? ivcDocCopy.Items[0] : new WMSOffice.Controls.Custom.ImageProxy(Properties.Resources.absentimage);
            }

            return quality.AP_Get_Attachments.Count > 0;
        }

        private Data.Quality GetDesinfectionReportData()
        {
            var reportData = new Data.Quality();

            using (var adapter = new Data.QualityTableAdapters.QK_SA_Get_Desinfection_Cert_HeaderTableAdapter())
                adapter.Fill(reportData.QK_SA_Get_Desinfection_Cert_Header, this.UserID, _routeListNumber);

            using (var adapter = new Data.QualityTableAdapters.QK_SA_Get_Desinfection_Cert_DetailsTableAdapter())
                adapter.Fill(reportData.QK_SA_Get_Desinfection_Cert_Details, this.UserID, _routeListNumber);

            return reportData;
        }

        /// <summary>
        /// Критичный общий размер всех файлов, при котором пользователю будет отображено предупреждение (1 МБ).
        /// </summary>
        private const long ERROR_FILE_SIZE = 1048576;

        private void btnDocCopy_Click(object sender, EventArgs e)
        {
            try
            {
                if (ivcDocCopy.Items.Count > 0 && MessageBox.Show("Заменить текущую скан-копию?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                    return;

                var ofd = new OpenFileDialog();
                ofd.Title = "Скан-копия паспорта дезинфекции";
                ofd.Filter = "Файлы-изображения в форматах JPEG, JPG, PNG, GIF, ICO, TIFF, PDF|*.JPEG;*.JPG;*.PNG;*.GIF;*.ICO;*.TIFF;*.PDF";
                ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                if (ofd.ShowDialog() != DialogResult.OK)
                    return;

                var filePath = ofd.FileName;
                var fileInfo = new FileInfo(filePath);

                if (fileInfo.Length > ERROR_FILE_SIZE)
                    throw new Exception("Размер файла превышает допустимый (1 мегабайт).");

                var fileName = fileInfo.Name;
                var fileData = File.ReadAllBytes(filePath);
                var fileLength = Convert.ToDecimal(Math.Round(Convert.ToDouble(fileInfo.Length) / 1024 / 1024, 3));


                ivcDocCopy.Items.Clear();
                quality.AP_Get_Attachments.Clear();

                var attachment = quality.AP_Get_Attachments.NewAP_Get_AttachmentsRow();

                attachment.RowNumber = 1;
                attachment.AttachmentID = -1L;
                attachment.DocID = _selectedWorksheet.worksheet_number; 
                attachment.VersionID = Convert.ToInt32(_selectedWorksheet.version_number);

                attachment.FileName = fileName;
                attachment.FileData = File.ReadAllBytes(filePath);
                attachment.FileLength = string.Format("{0:f3} КБ", fileLength);

                attachment.UserCreated = "Текущий пользователь";
                attachment.DateCreated = DateTime.Now;

                attachment.TermoMode = string.Empty;

                quality.AP_Get_Attachments.AddAP_Get_AttachmentsRow(attachment);

                ivcDocCopy.Items.Add(new ImageProxy(filePath, filePath.Substring(filePath.LastIndexOf('.'))) { Properties = attachment });
                ivcDocCopy.Items[ivcDocCopy.Items.Count - 1].LoadImage();

                ivcDocCopy.CurrentItem = ivcDocCopy.Items.Count > 0 ? ivcDocCopy.Items[0] : new WMSOffice.Controls.Custom.ImageProxy(Properties.Resources.absentimage);


                if (!tcDocs.TabPages.Contains(tpDocCopy))
                    tcDocs.TabPages.Insert(1, tpDocCopy);

                tcDocs.SelectedTab = tpDocCopy;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InputControlDeliveryWorksheetUnloadDateEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveData();
            }

        private bool SaveData()
        {
            try
            {
                if (this.IsOriginatorMode)
                {
                    if (quality.AP_Get_Attachments.Count == 0)
                        throw new Exception("Не добавлена скан-копия паспорта дезинфекции.");

                    var attachment = quality.AP_Get_Attachments[0];

                    using (var adapter = new Data.QualityTableAdapters.AP_Get_AttachmentsTableAdapter())
                        adapter.DeleteDocAttachmentSA((long?)null, this.UserID, attachment.DocID, attachment.VersionID);
                    
                    using (var adapter = new Data.QualityTableAdapters.AP_Get_AttachmentsTableAdapter())
                        adapter.AddDocAttachmentSA(
                            this.UserID, 
                            attachment.DocID, 
                            attachment.VersionID, 
                            attachment.FileName, 
                            attachment.FileData, 
                            attachment.TermoMode,
                            null,
                            null,
                            null);

                    _dcPackage.HasAttachment = true;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void InputControlDeliveryWorksheetDesinfectionCertEditForm_SizeChanged(object sender, EventArgs e)
        {
            if (ivcDocCopy.AutoZoomActivated)
                ivcDocCopy.ChangeZoom();
        }
    }

    public class ShipmentDesinficationCertPackage
    {
        public byte[] DocBin { get; set; }
        public string DocName { get; set; }

        public bool HasAttachment { get; set; }

        public Data.Quality.QK_SA_WorksheetsRow SelectedWorksheet { get; set; }
        public long RouteListNumber { get; set; }
    }
}
