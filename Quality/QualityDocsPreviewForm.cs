using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using WMSOffice.Classes;

namespace WMSOffice.Dialogs.Quality
{
    public partial class QualityDocsPreviewForm : Form
    {
        public QualityDocsPreviewForm(byte[] buffer)
        {
            InitializeComponent();

            Buffer = buffer;
            CurrentFrame = 0;
        }

        public byte[] Buffer { get; set; }

        public int CurrentFrame { get; set; }

        public int PrintFrame { get; set; }

        public Image ImageSource { get; set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            PrintDocsThread.FillPrintersComboBox(cmbPrint.ComboBox);

            ImageSource = Image.FromStream(new MemoryStream(Buffer));
            int cntFrames = ImageSource.GetFrameCount(FrameDimension.Page);
            if (cntFrames == 0)
                return;

            BindingSource bs = new BindingSource();
            bs.DataSource = new object[cntFrames];
            bindingNavigator.BindingSource = bs;

            ImageSource.SelectActiveFrame(FrameDimension.Page, 0);
            pictureBox.Image = ImageSource;
        }

        private void bindingNavigator_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int cntFrames = pictureBox.Image.GetFrameCount(FrameDimension.Page);

            if (e.ClickedItem == bindingNavigator.MoveNextItem)
                CurrentFrame++;

            if (e.ClickedItem == bindingNavigator.MovePreviousItem)
                CurrentFrame--;

            if (e.ClickedItem == bindingNavigator.MoveLastItem)
                CurrentFrame = cntFrames - 1;

            if (e.ClickedItem == bindingNavigator.MoveFirstItem)
                CurrentFrame = 0;

            ImageSource.SelectActiveFrame(FrameDimension.Page, CurrentFrame);
            pictureBox.Refresh();
        }

        private void Print_Click(object sender, EventArgs e)
        {
            PrintFrame = 0;
            PrintDocument document = new PrintDocument();
            document.PrinterSettings.PrinterName = cmbPrint.Text;
            document.PrintPage += new PrintPageEventHandler(document_PrintPage);
            CurrentFrame = 0;
            document.Print();

            ImageSource.SelectActiveFrame(FrameDimension.Page, CurrentFrame);
            pictureBox.Refresh();

            Close();
        }

        void document_PrintPage(object sender, PrintPageEventArgs e)
        {
            int cntFrames = pictureBox.Image.GetFrameCount(FrameDimension.Page);
            ImageSource.SelectActiveFrame(FrameDimension.Page, PrintFrame);
            e.Graphics.DrawImage(ImageSource, e.PageBounds);
            PrintFrame++;
            e.HasMorePages = PrintFrame != cntFrames;
        }

    }
}
