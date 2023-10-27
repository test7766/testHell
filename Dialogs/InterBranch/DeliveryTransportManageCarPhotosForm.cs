using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.Custom;
using System.IO;

namespace WMSOffice.Dialogs.InterBranch
{
    public partial class DeliveryTransportManageCarPhotosForm : DialogForm
    {
        private const decimal LIMIT_IMAGE_SIZE = 15.0M;
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        public DateTime ShipmentDate { get; set; }

        public new long UserID { get; set; }

        public long? CarID { get; set; }
        public int? VolumeID { get; set; }
        public long? RouteNumber { get; set; }
        public string RouteInformation { get; set; }
        public int? FactPallets { get; set; }
        public string LockBar { get; set; }
        public string Comment { get; set; }

        public bool IsReadOnly { get; set; }

        public DeliveryTransportManageCarPhotosForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Initialize();

            this.btnOK.Location = new Point(717, 8);
            this.btnCancel.Location = new Point(807, 8);

            if (this.IsReadOnly)
            {
                this.Text = string.Format("{0} (только чтение)", this.Text);

                tbFactPallets.ReadOnly = true;
                tbFactPallets.BackColor = SystemColors.Window;

                tbLockBar.ReadOnly = true;
                tbLockBar.BackColor = SystemColors.Window;

                tbComment.ReadOnly = true;
                tbComment.BackColor = SystemColors.Window;

                this.btnOK.Visible = false;
                this.btnCancel.Text = "Закрыть";
            }
        }

        private void Initialize()
        {
            this.Text = string.Format("{0} [{1}]", this.Text, this.CarID);

            this.LoadCarVolumes(this.VolumeID);

            if (this.RouteNumber.HasValue)
                tbRouteNumber.Text = this.RouteNumber.Value.ToString();

            if (!string.IsNullOrEmpty(this.RouteInformation))
                tbRouteInformation.Text = this.RouteInformation.ToString();

            if (this.FactPallets.HasValue)
                tbFactPallets.Text = this.FactPallets.Value.ToString("N0");

            if (!string.IsNullOrEmpty(this.LockBar))
                tbLockBar.Text = this.LockBar;

            if (!string.IsNullOrEmpty(this.Comment))
                tbComment.Text = this.Comment;

            dgvPhotos.AutoGenerateColumns = false;

            imageProxyBindingSource.DataSource = imageViewerControl.Items;

            //this.InitializeImages();

            if (this.ShipmentDate.Date < DateTime.Today)
                this.IsReadOnly = true;

            this.SetOperationsAccess();

            this.LoadImages();

            this.SetOperationsAccess();
        }

        private void LoadCarVolumes(int? volumeID)
        {
            try
            {
                tSP_Car_VolumesTableAdapter.Fill(interbranch.TSP_Car_Volumes, volumeID);
                //cmbCarVolumes.SelectedValue = interbranch.TSP_Car_Volumes[interbranch.TSP_Car_Volumes.Count - 1].CV_ID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeImages()
        {
            imageViewerControl.Items.Clear();
            imageViewerControl.CurrentItem = new ImageProxy(Properties.Resources.absentimage);
        }

        private void LoadImages()
        {
            try
            {
                imageViewerControl.Items.Clear();
                imageViewerControl.CurrentItem = null;


                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    try
                    {
                        using (var adapter = new Data.InterbranchTableAdapters.TSP_Shipments_Cars_PhotoTableAdapter())
                            e.Result = adapter.GetData(this.UserID, this.CarID);
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                bw.RunWorkerCompleted += (s, e) =>
                {
                    if (e.Result is Exception)
                        MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        interbranch.TSP_Shipments_Cars_Photo.Merge(e.Result as Data.Interbranch.TSP_Shipments_Cars_PhotoDataTable);

                        foreach (Data.Interbranch.TSP_Shipments_Cars_PhotoRow photo in interbranch.TSP_Shipments_Cars_Photo.Rows)
                            imageViewerControl.Items.Add(new ImageProxy(photo.FileData, photo.FileName) { Properties = photo, Size = photo.FileLength });

                        imageViewerControl.CurrentItem = imageViewerControl.Items.Count > 0
                            ? imageViewerControl.Items[imageViewerControl.Items.Count - 1]
                            : new ImageProxy(Properties.Resources.absentimage);

                        imageProxyBindingSource.ResetBindings(false);
                    }

                    splashForm.CloseForce();
                };

                splashForm.ActionText = "Выполняется загрузка\nфотоотчета по авто..";
                interbranch.TSP_Shipments_Cars_Photo.Clear();
                bw.RunWorkerAsync();
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    var lstFileNames = new List<string>(ofg.FileNames);
                    //lstFileNames.Sort();

                    foreach (var imagePath in lstFileNames)
                    {
                        var imageInfo = new FileInfo(imagePath);
                        var imageSize = Convert.ToDecimal(Math.Round(Convert.ToDouble(imageInfo.Length) / 1024 / 1024, 3));

                        var photo = interbranch.TSP_Shipments_Cars_Photo.NewTSP_Shipments_Cars_PhotoRow();
                        photo.FileData = File.ReadAllBytes(imagePath);
                        photo.FileLength = imageSize;
                        photo.FileName = imageInfo.Name;
                        interbranch.TSP_Shipments_Cars_Photo.AddTSP_Shipments_Cars_PhotoRow(photo);

                        var image = new ImageProxy(photo.FileData, photo.FileName) { Properties = photo, Size = photo.FileLength };
                        imageViewerControl.Items.Add(image);

                        //imageProxyBindingSource.ResetBindings(false);
                    }

                    imageProxyBindingSource.ResetBindings(false);

                    if (imageViewerControl.Items.Count == 0)
                        this.InitializeImages();
                    else
                    {
                        imageViewerControl.CurrentItem = imageViewerControl.Items[imageViewerControl.Items.Count - 1];
                        
                        imageViewerControl.MoveToCurrentItem();

                        dgvPhotos.Focus();
                    }
                }
            }
        }

        private void SetOperationsAccess()
        {
            try
            {
                btnLoadPhoto.Enabled = !this.IsReadOnly;
                btnDeletePhoto.Enabled = dgvPhotos.SelectedRows.Count > 0 && !this.IsReadOnly;
            }
            catch (Exception ex)
            {

            }
        }

        private void btnDeletePhoto_Click(object sender, EventArgs e)
        {
            dgvPhotos_UserDeletingRow(dgvPhotos, new DataGridViewRowCancelEventArgs(dgvPhotos.CurrentCell.OwningRow));   
        }

        private void dgvPhotos_SelectionChanged(object sender, EventArgs e)
        {
            this.SetOperationsAccess();

            if (dgvPhotos.SelectedRows.Count > 0)
            {
                var selectedItem = dgvPhotos.SelectedRows[0].DataBoundItem as ImageProxy;

                if (imageViewerControl.CurrentItem != selectedItem)
                {
                    imageViewerControl.CurrentItem = selectedItem;

                    imageViewerControl.MoveToCurrentItem();
                }
            }
            //else
            //{
            //    if (dgvPhotos.Rows.Count == 0)
            //        imageViewerControl.CurrentItem = null;
            //}
        }

        private void dgvPhotos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var photo = dgvPhotos.Rows[e.RowIndex].DataBoundItem as ImageProxy;
            if (photo.Size > LIMIT_IMAGE_SIZE)
            {
                e.CellStyle.BackColor = Color.LightPink;
                e.CellStyle.SelectionForeColor = Color.LightPink;
            }
        }

        private void dgvPhotos_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                if (this.IsReadOnly)
                {
                    e.Cancel = true;
                    return;
                }

                var deletedRow = e.Row.DataBoundItem as ImageProxy;
                imageViewerControl.Items.Remove(deletedRow);

                (deletedRow.Properties as Data.Interbranch.TSP_Shipments_Cars_PhotoRow).Delete();

                imageProxyBindingSource.ResetBindings(false);

                if (imageViewerControl.Items.Count == 0)
                    this.InitializeImages();
            }
            catch (Exception ex)
            { 
            
            }
        }

        private void imageViewerControl_PreviewCurrentItem(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvPhotos.SelectedRows)
                row.Selected = false;

            if (dgvPhotos.Rows.Count > 0)
            {
                var idx = imageViewerControl.Items.IndexOf(imageViewerControl.CurrentItem);

                if (0 <= idx && idx < dgvPhotos.Rows.Count)
                {
                    dgvPhotos.Rows[idx].Selected = true;
                }
            }
        }

        private void DeliveryTransportManageCarPhotosForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveData();
        }

        private bool SaveData()
        {
            try
            {
                // 1. Сохранения информации о заказаном авто
                var factPallets = 0;
                if (!int.TryParse(tbFactPallets.Text, out factPallets))
                    throw new Exception("Паллет должно быть числом.");

                if (factPallets == 0)
                    throw new Exception("Паллет должно быть больше нуля.");

                var lockBar = (string)null;
                if (string.IsNullOrEmpty(tbLockBar.Text.Trim()))
                    throw new Exception("Не указан № пломбы.");
                else
                    lockBar = tbLockBar.Text.Trim();

                var comment = tbComment.Text.Trim();


                // 2. Сохранение фотоотчета
                var cntPhoto = imageViewerControl.Items.Count;
                if (cntPhoto == 0)
                    throw new Exception("Не выбраны фото.");
                else if (cntPhoto < 2)
                    throw new Exception("Необходимо выбрать как минимум 2 фото:\n   -фото пломбы вблизи\n   -фото кузова с паллетами");

                var totalSize = 0.0M;
                foreach (var image in imageViewerControl.Items)
                    totalSize += image.Size;

                if (totalSize > LIMIT_IMAGE_SIZE)
                    throw new Exception(string.Format("Превышен допустимый суммарный размер фото {0} МБ.", LIMIT_IMAGE_SIZE));

                using (var adapter = new Data.InterbranchTableAdapters.TSP_Shipments_Cars_PhotoTableAdapter())
                    adapter.AddLockBar(this.UserID, this.CarID, lockBar, factPallets, comment);

                foreach (Data.Interbranch.TSP_Shipments_Cars_PhotoRow photo in interbranch.TSP_Shipments_Cars_Photo)
                {
                    try
                    {
                        if (photo.RowState == DataRowState.Deleted)
                        {
                            var fileID = Convert.ToInt32(photo[interbranch.TSP_Shipments_Cars_Photo.FileIDColumn, DataRowVersion.Original]);
                            using (var adapter = new Data.InterbranchTableAdapters.TSP_Shipments_Cars_PhotoTableAdapter())
                                adapter.DeletePhoto(this.UserID, fileID);
                        }
                        else if (photo.RowState == DataRowState.Added && photo.FileID < 0)
                        {
                            using (var adapter = new Data.InterbranchTableAdapters.TSP_Shipments_Cars_PhotoTableAdapter())
                                adapter.AddPhoto(this.UserID, this.CarID, photo.FileName, photo.FileData);
                        }
                    }
                    catch (Exception ex)
                    {

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

        private void imageViewerControl_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                if (imageViewerControl.AutoZoomActivated)
                    imageViewerControl.ChangeZoom();
            }
            catch (Exception)
            {
                
            }
        }
    }
}
