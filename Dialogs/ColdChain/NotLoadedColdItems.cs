using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs.Complaints;

namespace WMSOffice.Dialogs.ColdChain
{
    public partial class NotLoadedColdItems : Form
    {
        private Dialogs.SplashForm waitProcessForm = new WMSOffice.Dialogs.SplashForm();

        public NotLoadedColdItems()
        {
            InitializeComponent();
        }

        public int PerronID { get; set; }
        public long PerronPackingDocID { get; set; }
        public long UserID { get; set; }

        private void NotLoadedColdItems_Load(object sender, EventArgs e)
        {
            this.Initialize();
        }

        private void Initialize()
        {
            btnWriteOffShortage.Enabled = this.CheckWriteOffShortageAccess();
        }

        private bool CheckWriteOffShortageAccess()
        {
            try
            {
                var access = (int?)null;
                using (var needPSNbyPeronTableAdapter = new Data.DeliveryTableAdapters.NeedPSNbyPeronTableAdapter())
                    needPSNbyPeronTableAdapter.CheckWriteOffShortageAccess(UserID, ref access);

                return Convert.ToBoolean(access ?? 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.FillNotLoadedColdItems();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.FillNotLoadedColdItems();
        }

        private void FillNotLoadedColdItems()
        {
            BackgroundWorker loadWorker = new BackgroundWorker();
            loadWorker.DoWork += new DoWorkEventHandler(loadWorker_DoWork);
            loadWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(loadWorker_RunWorkerCompleted);
            this.notLoadedColdItemsBindingSource.DataSource = null;
            waitProcessForm.ActionText = "Получение данных...";
            loadWorker.RunWorkerAsync();
            waitProcessForm.ShowDialog();
        }

        private void loadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = this.notLoadedColdItemsTableAdapter.GetData(PerronPackingDocID);
            }
            catch (Exception error)
            {
                e.Result = error;
            }
        }

        private void loadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
            {
                MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.coldChain.NotLoadedColdItems.Clear();
            }
            else
                this.notLoadedColdItemsBindingSource.DataSource = e.Result;

            waitProcessForm.CloseForce();
        }

        private void btnWriteOffShortage_Click(object sender, EventArgs e)
        {
            if (this.WriteOffShortage())
                this.FillNotLoadedColdItems();
        }

        private bool WriteOffShortage()
        {
            try
            {
                var frmEnterStringValue = new EnterStringValueForm("Комментарий", "Введите комментарий к списанию недостачи:", string.Empty);
                if (frmEnterStringValue.ShowDialog() == DialogResult.OK)
                {
                    var comment = frmEnterStringValue.Value;
                    var isCold = true;

                    using (var needPSNbyPeronTableAdapter = new Data.DeliveryTableAdapters.NeedPSNbyPeronTableAdapter())
                        needPSNbyPeronTableAdapter.WriteOffShortage(PerronID, PerronPackingDocID, UserID, comment, isCold);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
