using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.Custom;
using WMSOffice.Dialogs.Sert;
using System.Drawing.Imaging;
using System.Transactions;
using WMSOffice.Classes;

namespace WMSOffice.Dialogs.InterBranch
{
    public partial class AttachImagesForm : DialogForm
    {
        #region ПОЛЯ И СВОЙСТВА ДАННЫХ

        public string RouteListBarCode { get; set; }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ
         
        public AttachImagesForm()
        {
            InitializeComponent();
        }

        private void AttachImagesForm_Load(object sender, EventArgs e)
        {
            LoadWarehouses();
            LoadDocAttributeValues();

            dgvPhotos.AutoGenerateColumns = false;
            imageProxyBindingSource.DataSource = imageViewerControl.Items;
        }

        private void LoadWarehouses()
        {
            try
            {
                warehousesTableAdapter.Fill(interbranch.Warehouses, this.UserID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDocAttributeValues()
        {
            try
            {
                photoDocAttributeCarNameValuesBindingSource.DataSource = photoDocAttributeValuesTableAdapter.GetData(1);
                photoDocAttributeCarNumberValuesBindingSource.DataSource = photoDocAttributeValuesTableAdapter.GetData(2);
                photoDocAttributeTrailerNumberValuesBindingSource.DataSource = photoDocAttributeValuesTableAdapter.GetData(3);
                photoDocAttributeDriverNameValuesBindingSource.DataSource = photoDocAttributeValuesTableAdapter.GetData(4);

                ecmbCarName.Text = string.Empty;
                ecmbCarNumber.Text = string.Empty;
                ecmbTrailerNumber.Text = string.Empty;
                ecmbDriverName.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                photoDocAttributeCarNameValuesBindingSource.DataSource = null;
                photoDocAttributeCarNumberValuesBindingSource.DataSource = null;
                photoDocAttributeTrailerNumberValuesBindingSource.DataSource = null;
                photoDocAttributeDriverNameValuesBindingSource.DataSource = null;
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Text = string.Format("{0} по маршрутному листу {1}", this.Text, this.RouteListBarCode);
            this.btnOK.Location = new Point(557, 8);
            this.btnCancel.Location = new Point(647, 8);
        }

        #endregion

        private void driverInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.SelectNextControl(sender as Control, true, true, true, false);
        }

        private void btnLoadPhoto_Click(object sender, EventArgs e)
        {
            using (var ofg = new OpenFileDialog())
            {
                ofg.Title = "Выбор фотографий";
                ofg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                ofg.Multiselect = true;
                ofg.Filter = "Файлы-изображения в форматах JPEG, JPG, PNG, GIF, ICO|*.JPEG;*.JPG;*.PNG;*.GIF;*.ICO";

                if (ofg.ShowDialog() == DialogResult.OK)
                {
                    foreach (var imagePath in ofg.FileNames)
                        imageViewerControl.Items.Add(new ImageProxy(imagePath));

                    imageViewerControl.CurrentItem = imageViewerControl.Items.Count == 0 ? imageViewerControl.Items[0] : imageViewerControl.CurrentItem;
                    imageProxyBindingSource.ResetBindings(false);
                }
            }
        }

        private void imageViewerControl_PreviewCurrentItem(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvPhotos.SelectedRows)
                row.Selected = false;

            if (dgvPhotos.Rows.Count > 0)
                dgvPhotos.Rows[imageViewerControl.Items.IndexOf(imageViewerControl.CurrentItem)].Selected = true;
        }

        private void dgvPhotos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPhotos.SelectedRows.Count > 0)
            {
                var selectedItem = dgvPhotos.SelectedRows[0].DataBoundItem as ImageProxy;
                imageViewerControl.CurrentItem = selectedItem;
            }
            else
            {
                if (dgvPhotos.Rows.Count == 0)
                    imageViewerControl.CurrentItem = null;
            }
        }

        private void dgvPhotos_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            e.Cancel = true;
            var deletedRow = e.Row.DataBoundItem as ImageProxy;
            imageViewerControl.Items.Remove(deletedRow);

            imageProxyBindingSource.ResetBindings(false);
        }

        private void AttachImagesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.Save();
        }

        private bool Save()
        {
            try
            {
                if (cmbWarehouse.SelectedValue == null)
                    throw new Exception("Склад должен быть выбран.");

                if (string.IsNullOrEmpty(ecmbCarName.Text.Trim()))
                    throw new Exception("Автомобиль должен быть указан.");

                if (string.IsNullOrEmpty(ecmbCarNumber.Text.Trim()))
                    throw new Exception("Номер автомобиля должен быть указан.");

                if (string.IsNullOrEmpty(ecmbDriverName.Text.Trim()))
                    throw new Exception("Водитель должен быть указан.");

                var carName = ecmbCarName.Text.Trim();
                var isHiredCar = cbIsHiredCar.Checked;
                var carNumber = ecmbCarNumber.Text.Trim(); 
                var trailerNumber = ecmbTrailerNumber.Text.Trim();
                var driverName = ecmbDriverName.Text.Trim();
                var warehouseID = cmbWarehouse.SelectedValue.ToString();
                
                var lstImageBuffer = new List<byte[]>();

                #region ПРОВЕРКА НАЛИЧИЯ ИЗОБРАЖЕНИЙ

                foreach (var imageProxy in imageViewerControl.Items)
                {
                    var image = imageProxy.Image;
                    if (!imageProxy.ImageLoaded)
                        continue;

                    var imageBuffer = ImageUtils.ConvertToByteArray(image, ImageFormat.Jpeg);
                    lstImageBuffer.Add(imageBuffer);
                }

                if (lstImageBuffer.Count == 0)
                    throw new Exception("Хотя бы одно фото должно быть загружено.");

                #endregion

                var tranOptions = new TransactionOptions();
                tranOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;

                using (var scope = new TransactionScope(TransactionScopeOption.Required, tranOptions))
                {
                    try
                    {
                        var docID = (long?)null;
                        using (var adapter = new Data.InterbranchTableAdapters.PhotoDocsTableAdapter())
                            adapter.AddDoc(this.UserID, warehouseID, (string)null, this.RouteListBarCode, carName, carNumber, driverName, trailerNumber, isHiredCar, ref docID);

                        if (!docID.HasValue)
                            throw new Exception("Документ фотоотчета не был создан.");

                        foreach (var imageBuffer in lstImageBuffer)
                        {
                            using (var adapter = new Data.InterbranchTableAdapters.PhotoDetailsTableAdapter())
                                adapter.AddDetail(this.UserID, docID, imageBuffer);
                        }

                        using (var adapter = new Data.InterbranchTableAdapters.PhotoDocsTableAdapter())
                            adapter.ChangeStatus(this.UserID, docID, Constants.IB_IR_PHOTO_DOC_APPROVED);

                        scope.Complete();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

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
