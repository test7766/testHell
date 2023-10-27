using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WIA;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace WMSOffice.Dialogs.Quality
{
    public partial class IntupControlScanDocumentForm : Form
    {
        public int CurrentItem { get; set; }

        private Device device { get; set; }

        public byte[] GetStream()
        {

            if (curImageList.Count == 0)
                return null;

            try
            {
                string fileName = Path.GetTempFileName();

                var encoder = System.Drawing.Imaging.Encoder.SaveFlag;
                ImageCodecInfo encoderInfo = new List<ImageCodecInfo>(ImageCodecInfo.GetImageEncoders()).Find(i => i.MimeType == "image/tiff");
                EncoderParameters encoderParameters = new EncoderParameters(1);
                encoderParameters.Param[0] = new EncoderParameter(encoder, (long)EncoderValue.MultiFrame);


                // Save the first frame of the multi page tiff
                Image firstImage = curImageList[0];
                firstImage.Save(fileName, encoderInfo, encoderParameters);
                encoderParameters.Param[0] = new EncoderParameter(encoder, (long)EncoderValue.FrameDimensionPage);


                // Add the remining images to the tiff
                for (int i = 1; i < curImageList.Count; i++)
                {
                    Image img = curImageList[i];
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

            }

            return null;
        }

        public byte[] GetOriginalStream()
        {

            if (origImageList.Count == 0)
                return null;

            string fileName = Path.GetTempFileName();

            var encoder = System.Drawing.Imaging.Encoder.SaveFlag;
            ImageCodecInfo encoderInfo = new List<ImageCodecInfo>(ImageCodecInfo.GetImageEncoders()).Find(i => i.MimeType == "image/tiff");
            EncoderParameters encoderParameters = new EncoderParameters(1);
            encoderParameters.Param[0] = new EncoderParameter(encoder, (long)EncoderValue.MultiFrame);


            // Save the first frame of the multi page tiff
            Image firstImage = origImageList[0];
            firstImage.Save(fileName, encoderInfo, encoderParameters);
            encoderParameters.Param[0] = new EncoderParameter(encoder, (long)EncoderValue.FrameDimensionPage);


            // Add the remining images to the tiff
            for (int i = 1; i < origImageList.Count; i++)
            {
                Image img = origImageList[i];
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

        public IntupControlScanDocumentForm()
        {
            InitializeComponent();
            CurrentItem = 0;

            device = null;
        }

        private void IntupControlScanDocumentForm_Load(object sender, EventArgs e)
        {
            Scan();
        }

        List<Image> curImageList = new List<Image>();
        List<Image> origImageList = new List<Image>();

        private void Scan()
        {
            try
            {
                var hasMorePages = false; //assume there are no more pages

                if (device == null)
                {
                    string deviceId = String.Empty;
                    var dlg = new WIA.CommonDialog();
                    var _device = dlg.ShowSelectDevice(WiaDeviceType.ScannerDeviceType, true, false);

                    if (_device == null)
                        return;

                    deviceId = _device.DeviceID;
                    
                    DeviceManager manager = new DeviceManager();


                    DeviceInfo deviceInfo = null;

                    foreach (DeviceInfo info in manager.DeviceInfos)
                        if (deviceId == info.DeviceID)
                        {
                            deviceInfo = info;
                            break;
                        }

                    if (deviceInfo == null)
                        throw new Exception("Не верно указан сканер!");

                    device = deviceInfo.Connect();
                }

                var commonDialog = new WIA.CommonDialog();
                var items = commonDialog.ShowSelectItems(device, WiaImageIntent.ColorIntent, WiaImageBias.MaximizeQuality, true, true, false);

                do
                {
                    WIA.Item Item = items[1] as WIA.Item;
                    ImageFile image = (WIA.ImageFile)commonDialog.ShowTransfer(Item, WIA.FormatID.wiaFormatBMP, false);

                    byte[] bytes = (byte[])image.FileData.get_BinaryData();

                    var ms = new MemoryStream(bytes);
                    ms.Flush();

                    var img = Image.FromStream(ms);

                    if (cbOriginal.Checked)
                        origImageList.Add(img);
                    else
                        curImageList.Add(img);

                    Property documentHandlingSelect = null;
                    Property documentHandlingStatus = null;

                    foreach (Property prop in device.Properties)
                    {
                        if (prop.PropertyID == WIA_PROPERTIES.WIA_DPS_DOCUMENT_HANDLING_SELECT)
                            documentHandlingSelect = prop;
                        if (prop.PropertyID == WIA_PROPERTIES.WIA_DPS_DOCUMENT_HANDLING_STATUS)
                            documentHandlingStatus = prop;
                    }
                    if (documentHandlingSelect != null)
                        if ((Convert.ToUInt32(documentHandlingSelect.get_Value()) & WIA_DPS_DOCUMENT_HANDLING_SELECT.FEEDER) != 0)
                            hasMorePages = ((Convert.ToUInt32(documentHandlingStatus.get_Value()) & WIA_DPS_DOCUMENT_HANDLING_STATUS.FEED_READY) != 0);

                } while (hasMorePages);


                BindingSource bs = new BindingSource();
                bs.DataSource = cbOriginal.Checked ? origImageList : curImageList;
                bindingNavigator1.BindingSource = bs;

                pictureBox1.Image = cbOriginal.Checked ? origImageList[CurrentItem] : curImageList[CurrentItem];

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Сканирование", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void btnScan_Click(object sender, EventArgs e)
        {
            Scan();
        }

        Image[] GetFrames(Image originalImg)
        {

            int numberOfFrames = originalImg.GetFrameCount(FrameDimension.Page);

            Image[] frames = new Image[numberOfFrames];



            for (int i = 0; i < numberOfFrames; i++)
            {

                originalImg.SelectActiveFrame(FrameDimension.Page, i);

                frames[i] = ((Image)originalImg.Clone());

            }

            return frames;

        }

        private void bindingNavigator1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == bindingNavigator1.MoveNextItem)
                CurrentItem++;

            if (e.ClickedItem == bindingNavigator1.MovePreviousItem)
                CurrentItem--;

            if (e.ClickedItem == bindingNavigator1.MoveLastItem)
                CurrentItem = curImageList.Count - 1;

            if (e.ClickedItem == bindingNavigator1.MoveFirstItem)
                CurrentItem = 0;

            pictureBox1.Image = cbOriginal.Checked ? origImageList[CurrentItem] : curImageList[CurrentItem];
        }

        private void cbOriginal_CheckedChanged(object sender, EventArgs e)
        {
            CurrentItem = 0;

            BindingSource bs = new BindingSource();
            bs.DataSource = cbOriginal.Checked ? origImageList : curImageList;
            bindingNavigator1.BindingSource = bs;

            if (cbOriginal.Checked)
                pictureBox1.Image = origImageList.Count == 0 ? null : origImageList[CurrentItem];
            else
                pictureBox1.Image = curImageList.Count == 0 ? null : curImageList[CurrentItem];

        }
    }


    #region InternalClasses
    class WIA_DPS_DOCUMENT_HANDLING_SELECT
    {
        public const uint FEEDER = 0x00000001;
        public const uint FLATBED = 0x00000002;
    }
    class WIA_DPS_DOCUMENT_HANDLING_STATUS
    {
        public const uint FEED_READY = 0x00000001;
    }
    class WIA_PROPERTIES
    {
        public const uint WIA_RESERVED_FOR_NEW_PROPS = 1024;
        public const uint WIA_DIP_FIRST = 2;
        public const uint WIA_DPA_FIRST = WIA_DIP_FIRST + WIA_RESERVED_FOR_NEW_PROPS;
        public const uint WIA_DPC_FIRST = WIA_DPA_FIRST + WIA_RESERVED_FOR_NEW_PROPS;
        //
        // Scanner only device properties (DPS)
        //
        public const uint WIA_DPS_FIRST = WIA_DPC_FIRST + WIA_RESERVED_FOR_NEW_PROPS;
        public const uint WIA_DPS_DOCUMENT_HANDLING_STATUS = WIA_DPS_FIRST + 13;
        public const uint WIA_DPS_DOCUMENT_HANDLING_SELECT = WIA_DPS_FIRST + 14;
    }
    class WIA_ERRORS
    {
        public const uint BASE_VAL_WIA_ERROR = 0x80210000;
        public const uint WIA_ERROR_PAPER_EMPTY = BASE_VAL_WIA_ERROR + 3;
    }
    #endregion
}
