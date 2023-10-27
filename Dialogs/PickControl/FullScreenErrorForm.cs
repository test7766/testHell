using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TheArtOfDev.HtmlRenderer.WinForms;
using System.Text.RegularExpressions;
using System.IO;
using System.Drawing.Imaging;

namespace WMSOffice.Dialogs.PickControl
{
    public partial class FullScreenErrorForm : Form
    {
        public const int PREVIEW_SHIFT_TOP = 110;

        private const int DEFAULT_MARGIN_TOP = 250;
        private const int PREVIEW_MARGIN_TOP = 0;

        private readonly bool _htmlRenderMode = false;

        private HtmlPanel htmlPanel = null;

        private string message = string.Empty;

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public string ButtonText
        {
            get { return btnClose.Text; }
            set { btnClose.Text = value; }
        }

        public Color BackgroundColor
        {
            get { return BackColor; }
            set { BackColor = value; }
        }

        private int _timeOut = 1000;
        public int TimeOut
        {
            get { return _timeOut; }
            set { 
                _timeOut = value;
                lblTime.Text = (value/1000).ToString() + " сек."; 
            }
        }

        public bool AutoClose { get; set; }

        public bool PreviewMode { get; set; }

        public Keys CloseKey { get; set; }

        private bool AllowClose { get; set; }

        public FullScreenErrorForm()
        {
            InitializeComponent();
        }

        public FullScreenErrorForm(string message, string buttonText, Color backgroundColor, bool htmlRenderMode)
            : this()
        {
            Message = message;
            ButtonText = buttonText;
            BackgroundColor = backgroundColor;
            _htmlRenderMode = htmlRenderMode;
            TimeOut = 1000;
        }

        public FullScreenErrorForm(string message, string buttonText, Color backgroundColor)
            : this(message, buttonText, backgroundColor, false)
        {

        }

        private void FullScreenErrorForm_Load(object sender, EventArgs e)
        {
            if (this.PreviewMode)
                this.InitPreviewMode();

            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync();
        }

        private void InitPreviewMode()
        {
            lblTime.Visible = false;
            scContent.Panel2Collapsed = true;

            StartPosition = FormStartPosition.Manual;
            WindowState = FormWindowState.Normal;
            //FormBorderStyle = FormBorderStyle.Sizable;
            ShowInTaskbar = false;

            var area = Screen.PrimaryScreen.WorkingArea;
            this.Location = new Point(0, area.Height / 2 - PREVIEW_SHIFT_TOP); // 110); // 130
            this.Size = new Size(area.Width, area.Height / 2 + PREVIEW_SHIFT_TOP); // 110);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            // заменяем на html-viewer
            if (_htmlRenderMode)
            {
                pnlMessage.Controls.Remove(lblMessage);

                htmlPanel = new HtmlPanel();
                
                htmlPanel.IsSelectionEnabled = false;
                htmlPanel.IsContextMenuEnabled = false;
                htmlPanel.BackColor = Color.Transparent;
                htmlPanel.Text = HtmlRenderHelper.RenderMessage(message, this.PreviewMode ? PREVIEW_MARGIN_TOP : DEFAULT_MARGIN_TOP);
                htmlPanel.Dock = DockStyle.Fill;

                pnlMessage.Controls.Add(htmlPanel);
            }
            else
            {
                lblMessage.Text = message;
            }

            btnClose.Focus();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Threading.Thread.Sleep(TimeOut);
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this.CloseKey == Keys.None)
                AllowClose = true;

            if (AutoClose)
                this.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == this.CloseKey)
            {
                this.AllowClose = true;
                this.Close();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void FullScreenErrorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !AllowClose;
        }

        private void FullScreenErrorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Во избежание блокировки доступа к ресурсам (файлам), которые используются в html
            if (htmlPanel != null)
                htmlPanel.Text = string.Empty;

            HtmlRenderHelper.ClearCache();
        }
    }

    public static class HtmlRenderHelper
    {
        private static readonly string htmlBodyRenderPattern = "<body style=\"font-family:microsoft sans serif; font-size:32pt; font-weight:bold; color: black; vertical-align: middle; text-align:center; margin-top: {0}px;\">{1}</body>"; // margin-top: 250px;
        private static readonly string htmlImageRenderPattern = @"src=\""\[(\w.*?)\]\""";
        private static readonly string htmlImageReplaceRenderPattern = "src=\"{0}\"";

        private static readonly Dictionary<string, string> imgFileCache = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        public static string RenderMessage(string message, int marginTop)
        {
            try
            {
                var renderedMessage = string.Format(htmlBodyRenderPattern, marginTop, message);

                renderedMessage = Regex.Replace(renderedMessage, htmlImageRenderPattern, match => 
                {
                    var imgSource = match.Groups[1].Value;
                    var img = Properties.Resources.ResourceManager.GetObject(imgSource) as Image;
                    if (img != null)
                    {
                        var tmpFile = Path.GetTempFileName();
                        img.Save(tmpFile, ImageFormat.Png);

                        // закэшируем путь к временному файлу
                        imgFileCache[imgSource] = tmpFile;

                        return string.Format(htmlImageReplaceRenderPattern, tmpFile);
                    }
                    return match.Value;
                }, RegexOptions.IgnoreCase);

                return renderedMessage;
            }
            catch (Exception ex)
            {
                return message;
            }
        }

        public static void ClearCache()
        {
            foreach (var kvp in imgFileCache)
            {
                try
                {
                    var imgSource = kvp.Key;
                    var imgFile = kvp.Value;

                    if (File.Exists(imgFile))
                        File.Delete(imgFile);
                }
                catch (Exception ex)
                {
                   
                }
            }

            imgFileCache.Clear();
        }
    }
}
