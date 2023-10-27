using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

namespace WMSOffice.Dialogs.Complaints
{
    public partial class ComplaintAttachmentForm : Form
    {
        public Point LocationImage { get; set; }

        public ComplaintAttachmentForm(byte[] image)
        {
            InitializeComponent();

            ImageRow = image;
            cmbZoom.Items.AddRange(Enum.GetNames(typeof(PictureBoxSizeMode)));
            cmbZoom.AutoCompleteCustomSource.AddRange(Enum.GetNames(typeof(PictureBoxSizeMode)));
            cmbZoom.Text = pictureBox.SizeMode.ToString();
            cmbZoom.TextChanged += cmbZoom_TextChanged;

            btnOpen.Visible = !_ReadOnly;
            LocationImage = pictureBox.Location;
        }

        private void SetSizeMode()
        {
            var value = Enum.Parse(typeof(PictureBoxSizeMode), cmbZoom.Text, true);
            if (value == null && !(value is PictureBoxSizeMode))
                return;

            PictureBoxSizeMode sizeMode = (PictureBoxSizeMode)value;
            if (sizeMode != PictureBoxSizeMode.AutoSize)
                pictureBox.Dock = DockStyle.Fill;
            else
            {
                pictureBox.Dock = DockStyle.None;
                pictureBox.Location = LocationImage;
            }
            pictureBox.SizeMode = sizeMode;
        }

        void cmbZoom_TextChanged(object sender, EventArgs e)
        {
            SetSizeMode();
        }

        private byte[] _imageRow;
        public byte[] ImageRow
        {
            get
            {
                return _imageRow;
            }
            set
            {
                _imageRow = value;

                if (_imageRow == null)
                    return;

                MemoryStream ms = new MemoryStream(_imageRow);
                BinaryFormatter bf = new BinaryFormatter();
                AttachFileInfo = (AttachInfo)bf.Deserialize(ms);
            }
        }

        private AttachInfo _attachFileInfo;
        public AttachInfo AttachFileInfo
        {
            get
            {
                return _attachFileInfo;
            }
            set
            {
                _attachFileInfo = value;
                pictureBox.Image = Image.FromStream(_attachFileInfo.FStream);
                statusFileName.Text = _attachFileInfo.FileName;
                statusFileSize.Text = String.Format(" {0}", _attachFileInfo.FileSize);
            }
        }

        private bool _ReadOnly = false;
        public bool ReadOnly
        {
            get
            {
                return _ReadOnly;
            }
            set
            {
                _ReadOnly = value;
                btnOpen.Visible = !_ReadOnly;
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                var regex = new Regex(@"^.*\.(bmp|jpg|jpeg|png|tif|tiff|gif)$", RegexOptions.IgnoreCase);
                if (!regex.Match(openFileDialog.FileName).Success)
                    throw new Exception("Выбранный файл не является графическим!");

                FileInfo fi = new FileInfo(openFileDialog.FileName);
                using (Stream stream = new FileStream(openFileDialog.FileName, FileMode.Open))
                {
                    int streamLength = (int)stream.Length;
                    var ai = new AttachInfo
                    {
                        FileName = fi.Name,
                        FileExtension = fi.Extension,
                        Buffer = new byte[streamLength],
                        Length = fi.Length
                    };
                    stream.Read(ai.Buffer, 0, streamLength);
                    AttachFileInfo = ai;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ReadOnly)
            {
                saveFileDialog.DefaultExt = AttachFileInfo.FileExtension;
                saveFileDialog.FileName = AttachFileInfo.FileName;
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.CreateNew, FileAccess.ReadWrite);
                fs.Write(AttachFileInfo.Buffer, 0, AttachFileInfo.Buffer.Length);
                fs.Flush();
                fs.Close();
            }
            else
            {
                MemoryStream ms = new MemoryStream();
                BinaryFormatter bf = new BinaryFormatter();

                bf.Serialize(ms, AttachFileInfo);

                var retBuffer = ms.GetBuffer();
                ImageRow = retBuffer;
                DialogResult = DialogResult.OK;
            }
        }

        private void cmbZoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetSizeMode();
        }
    }

    [Serializable]
    public class AttachInfo
    {
        public string FileName { get; set; }

        public string FileExtension { get; set; }

        public byte[] Buffer { get; set; }

        public Stream FStream
        {
            get
            {
                if (Buffer == null)
                    return null;
                return new MemoryStream(Buffer);
            }
        }

        public long Length { get; set; }


        const double ENG_KBYTES = 1024;
        const double ENG_MBYTES = 1048576;
        const double ENG_GBYTES = 1073741824;
        public string FileSize
        {
            get
            {
                var retSize = String.Format("{0:n2} байт", Length);
                if (Length >= ENG_GBYTES)
                {
                    retSize = String.Format("{0:n2} Гб", (Length / ENG_GBYTES));
                    return retSize;
                }

                if (Length >= ENG_MBYTES)
                {
                    retSize = String.Format("{0:n2} Мб", (Length / ENG_MBYTES));
                    return retSize;
                }

                if (Length >= ENG_KBYTES)
                {
                    retSize = String.Format("{0:n2} Кб", (Length / ENG_KBYTES));
                    return retSize;
                }
                return String.Empty;
            }
        }
    }

}
