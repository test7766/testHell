using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using WMSOffice.Controls;
using WMSOffice.Reports;
using System.Drawing;

namespace WMSOffice.Window
{
    public partial class TareMoveCrossDockWindow : GeneralWindow
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных
        /// </summary>
        private Dialogs.SplashForm waitProgressForm = new WMSOffice.Dialogs.SplashForm();

        private TextBoxScaner tbScanTare = null;

        public new int DocID { get; private set; }

        public string MCUPlace { get; private set; }

        public TareMoveCrossDockWindow()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            gbRemCD.Visible = gbRemCurCD.Visible = false;

            if (!this.CreateDoc())
            {
                this.DialogResult = DialogResult.Abort;
                this.Close();
            }
            else
            {
                base.OnShown(e);
                this.Initialize();
            }
        }

        private bool CreateDoc()
        {
            try
            {
                var mcuPlace = (string)null;
                var dlgScanMCUPlace = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                {
                    Label = "Отсканируйте ш/к места отправки\r\nдля перемещения тары КД",
                    Text = "Перемещение тары КД",
                    Image = Properties.Resources.barcode
                };

                if (dlgScanMCUPlace.ShowDialog() == DialogResult.OK)
                    mcuPlace = dlgScanMCUPlace.Barcode;
                else
                    return false;

                var docID = (int?)null;
                tareMoveCrossDockDocDetailsTableAdapter.CreateDoc(this.UserID, mcuPlace, ref docID);

                if (docID.HasValue)
                {
                    this.MCUPlace = mcuPlace;
                    this.DocID = docID.Value;
                    this.InitDocument(this.DocName, this.DocID, this.DocType, this.DocDate, this.StatusID, this.StatusName);
                    return true;
                }
                else
                    throw new Exception("Документ не был создан.\r\nДальнейшая работа с интерфейсом невозможна.");
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
                return false;
            }
        }

        private void Initialize()
        {
            gbRemCD.Visible = gbRemCurCD.Visible = true;

            #region ДИНАМИЧЕСКИ ДОБАВЛЯЕМ ОКНО СКАНИРОВАНИЯ Ш/К

            tbScanTare = new TextBoxScaner() { Padding = new Padding(0, 14, 0, 0), Width = 300 };
            tbScanTare.TextChanged += (s, e) => { this.ScanTare(); };
            tsMain.Items.Insert(3, new ToolStripControlHost(tbScanTare));

            #endregion

            scContent.Panel1Collapsed = true;

            tbScanTare.Focus();
        }

        private void ScanTare()
        {
            if (string.IsNullOrEmpty(tbScanTare.Text))
                return;

            try
            {
                var tareBarCode = tbScanTare.Text;
                tareMoveCrossDockDocDetailsTableAdapter.ScanTare(this.DocID, tareBarCode);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
            finally
            {
                this.LoadDocDetails();

                tbScanTare.Text = string.Empty;
                tbScanTare.Focus();
            }
        }

        private void LoadDocDetails()
        {
            var bw = new BackgroundWorker();
            bw.DoWork += (s, e) =>
            {
                try
                {
                    e.Result = tareMoveCrossDockDocDetailsTableAdapter.GetData(this.DocID);
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            };
            bw.RunWorkerCompleted += (s, e) =>
            {
                waitProgressForm.CloseForce();

                if (e.Result is Exception)
                    this.ShowError(e.Result as Exception);
                else
                {
                    tareMoveCrossDockDocDetailsBindingSource.DataSource = e.Result;
                }
            };

            waitProgressForm.ActionText = "Выполняется загрузка деталей..";
            tareMoveCrossDockDocDetailsBindingSource.DataSource = null;
            bw.RunWorkerAsync();
            waitProgressForm.ShowDialog();
        }

        private void btnLoadRemains_Click(object sender, EventArgs e)
        {
            this.LoadRemains();
            this.GetDocRemainsInfo();
        }

        private void LoadRemains()
        {
            var bw = new BackgroundWorker();
            bw.DoWork += (s, e) => 
            {
                try
                {
                    e.Result = tareMoveCrossDockRemainsTableAdapter.GetData(this.UserID);
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            };
            bw.RunWorkerCompleted += (s, e) => 
            {
                waitProgressForm.CloseForce();

                if (e.Result is Exception)
                    this.ShowError(e.Result as Exception);
                else
                {
                    tareMoveCrossDockRemainsBindingSource.DataSource = e.Result;
                    scContent.Panel1Collapsed = false;
                }
            };

            waitProgressForm.ActionText = "Выполняется загрузка остатка..";
            tareMoveCrossDockRemainsBindingSource.DataSource = null;
            bw.RunWorkerAsync();
            waitProgressForm.ShowDialog();
        }

        private void GetDocRemainsInfo()
        {
            try
            {
                var remCDBox = (int?)null;
                var remCDCap = (int?)null;
                var remCurCDBox = (int?)null;
                var remCurCDCap = (int?)null;

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    try
                    {
                        tareMoveCrossDockDocDetailsTableAdapter.GetDocRemainsInfo(this.UserID, this.MCUPlace, this.DocID, ref remCDBox, ref remCDCap, ref remCurCDBox, ref remCurCDCap);
                    }
                    catch (Exception ex)
                    {
                       e.Result = ex;
                    }
                };
                bw.RunWorkerCompleted += (s, e) =>
                {
                    waitProgressForm.CloseForce();

                    if (e.Result is Exception)
                        this.ShowError(e.Result as Exception);
                    else
                    {
                        lblRemCDBox.Text = (remCDBox ?? 0).ToString();
                        lblRemCDCap.Text = (remCDCap ?? 0).ToString();

                        lblRemCurCDCap.Text = (remCurCDCap ?? 0).ToString();
                        lblRemCurCDBox.Text = (remCurCDBox ?? 0).ToString();
                    }
                };

                waitProgressForm.ActionText = "Выполняется загрузка остатка КД..";
                bw.RunWorkerAsync();
                waitProgressForm.ShowDialog();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnApproveDoc_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ApproveDoc()
        {
            var ignoreError = (int?)null;

            while (true)
            {
                try
                {
                    tareMoveCrossDockDocDetailsTableAdapter.ConfirmDoc(this.DocID, ignoreError);

                    this.PrintDoc();
                    return;
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("#CONFIRM#"))
                    {
                        var regex = new System.Text.RegularExpressions.Regex(@"#CONFIRM#(?<msg>.+)#", System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Singleline);
                        if (regex.IsMatch(ex.Message))
                        {
                            var match = regex.Match(ex.Message);
                            var message = match.Groups["msg"].Value;

                            MessageBoxManager.Yes = "&Да";
                            MessageBoxManager.No = "&Нет";
                            MessageBoxManager.Cancel = "&Повтор";
                            MessageBoxManager.Register();

                            var msgResult = MessageBox.Show(message, "Внимание", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button3);
                            MessageBoxManager.Unregister();
                            switch (msgResult)
                            {
                                case DialogResult.Yes:
                                    ignoreError = 1;
                                    break;
                                case DialogResult.No:
                                    throw new Exception("Вы отменили закрытие документа.");
                                case DialogResult.Cancel:
                                default:
                                    ignoreError = (int?)null;
                                    break;
                            }
                        }
                        else
                            throw ex;
                    }
                    else
                        throw ex;
                }
            }
        }

        private void PrintDoc()
        {
            TareMoveCrossDockWindow.PrintDoc(this.DocID);
        }

        public static void PrintDoc(int docID)
        {
            try
            {
                var report = TareMoveCrossDockWindow.CreateReport(docID);
                if (report != null)
                    report.PrintToPrinter(1, true, 1, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static TareMoveCrossDockReport CreateReport(int docID)
        {
            try
            {
                var ds = new Data.Containers();

                using (var adapter = new Data.ContainersTableAdapters.TareMoveCrossDockPrintDocDetailsTableAdapter())
                    adapter.Fill(ds.TareMoveCrossDockPrintDocDetails, docID);

                BarcodePrepare(ref ds);

                TareMoveCrossDockReport report = new TareMoveCrossDockReport();
                report.SetDataSource(ds);
                report.SetParameterValue("DocID", docID);

                return report;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static void BarcodePrepare(ref Data.Containers containers)
        {
            if (containers.TareMoveCrossDockPrintDocDetails.Count > 0)
            {
                // создание штрих-кода
                BarCodeCtrl barCodeCtrl = new BarCodeCtrl();
                barCodeCtrl.Weight = BarCodeCtrl.BarCodeWeight.Large;
                barCodeCtrl.Size = new Size(274 * 5, 108 * 5);
                barCodeCtrl.BarCodeHeight = 50 * 5;
                barCodeCtrl.FooterFont = new Font(barCodeCtrl.FooterFont.FontFamily, 12 * 5, FontStyle.Bold);
                barCodeCtrl.HeaderText = "";
                barCodeCtrl.LeftMargin = 10 * 5;
                barCodeCtrl.ShowFooter = true;
                barCodeCtrl.TopMargin = 20 * 5;
                barCodeCtrl.BarCode = containers.TareMoveCrossDockPrintDocDetails[0].Doc_Bar_Code; //"12345678OTCD";

                byte[] barCode = null;
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    barCodeCtrl.GetImage().Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    barCode = ms.ToArray();
                }

                containers.TareMoveCrossDockPrintDocDetails[0].Doc_Bar_Code_Image = barCode;
            }
        }

        private void btnCancelDoc_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void CancelDoc()
        {
            try
            {
                tareMoveCrossDockDocDetailsTableAdapter.CancelDoc(this.UserID, this.DocID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void TareMoveCrossDockWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (this.DialogResult == DialogResult.Abort)
                    return;

                if (this.DialogResult == DialogResult.None)
                    this.DialogResult = DialogResult.Cancel;

                if (this.DialogResult == DialogResult.OK)
                    this.ApproveDoc();

                if (this.DialogResult == DialogResult.Cancel)
                    this.CancelDoc();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);

                tbScanTare.Text = string.Empty;
                tbScanTare.Focus();

                e.Cancel = true;
            }
        }
    }
}
