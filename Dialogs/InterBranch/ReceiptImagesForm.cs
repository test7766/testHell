using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.Custom;
using WMSOffice.Classes;
using WMSOffice.Window;

namespace WMSOffice.Dialogs.InterBranch
{
    public partial class ReceiptImagesForm : DialogForm
    {
        #region ПОЛЯ И СВОЙСТВА ДАННЫХ

        private readonly List<int> lstProcessedImagesID = new List<int>();

        public string RouteListBarCode { get; set; }
        public long DocID { get; set; }

        /// <summary>
        /// Установленный режим работы (оправитель-получатель) 
        /// </summary>
        public InterbranchReceiptUserWorkMode WorkMode { get; set; }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ

        public ReceiptImagesForm()
        {
            InitializeComponent();
        }

        private void ReceiptImagesForm_Load(object sender, EventArgs e)
        {
            this.LoadPhotoDoc();
            this.LoadPhotoDetails();
        }

        private void LoadPhotoDoc()
        {
            try
            {
                using (var adapter = new Data.InterbranchTableAdapters.PhotoDocsTableAdapter())
                {
                    var photoDocs = adapter.GetData(this.UserID, Constants.IB_IR_PHOTO_DOC_CREATED, Constants.IB_IR_PHOTO_DOC_CLOSED, this.DocID);
                    if (photoDocs.Rows.Count > 0)
                    {
                        var photoDoc = photoDocs[0];
                        tbCarName.Text = photoDoc.IsCar_NameNull() ? string.Empty : photoDoc.Car_Name;
                        cbIsHiredCar.Checked = photoDoc.IsIs_Hired_CarNull() ? false : photoDoc.Is_Hired_Car;
                        tbCarNumber.Text = photoDoc.IsCar_NumberNull() ? string.Empty : photoDoc.Car_Number;
                        tbTrailerNumber.Text = photoDoc.IsTrailer_NumberNull() ? string.Empty : photoDoc.Trailer_Number;
                        tbDriverName.Text = photoDoc.IsDriver_NameNull() ? string.Empty : photoDoc.Driver_Name;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPhotoDetails()
        {
            try
            {
                using(var adapter = new Data.InterbranchTableAdapters.PhotoDetailsTableAdapter())
                {
                    var photos = adapter.GetData(this.UserID, this.DocID);
                    foreach (Data.Interbranch.PhotoDetailsRow photo in photos.Rows)
                    {
                        var imageBuffer = photo.File_Data;
                        imageViewerControl.Items.Add(new ImageProxy(imageBuffer, null) { Properties = photo });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Text = string.Format("{0} по маршрутному листу {1}", this.Text, this.RouteListBarCode);

            this.btnOK.Location = new Point(557, 8);
            this.btnCancel.Location = new Point(647, 8);

            if (this.WorkMode == InterbranchReceiptUserWorkMode.Sender)
            {
                imageViewerControl.PreviewCurrentItem -= imageViewerControl_PreviewCurrentItem;
                this.Text = string.Format("{0} [Режим просмотра]", this.Text);
            }

            if (imageViewerControl.Items.Count > 0)
                imageViewerControl.CurrentItem = imageViewerControl.Items[0];

            imageViewerControl.Focus();
        }

        #endregion

        private void imageViewerControl_PreviewCurrentItem(object sender, EventArgs e)
        {
            try
            {
                if (imageViewerControl.CurrentItem.ImageLoaded)
                {
                    var photo = imageViewerControl.CurrentItem.Properties as Data.Interbranch.PhotoDetailsRow;
                    var photoID = photo.line_id;

                    if (!lstProcessedImagesID.Contains(photoID))
                    {
                        using (var adapter = new Data.InterbranchTableAdapters.PhotoDetailsTableAdapter())
                            adapter.SetPreviewed(this.UserID, this.DocID, photoID);

                        lstProcessedImagesID.Add(photoID);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pnlDriverInfo_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
