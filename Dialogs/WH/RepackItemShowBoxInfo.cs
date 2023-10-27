using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.WH
{
    public partial class RepackItemShowBoxInfo : Form
    {
        #region ПОЛЯ И СВОЙСТВА ДАННЫХ

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных
        /// </summary>
        private Dialogs.SplashForm waitProgressForm = new WMSOffice.Dialogs.SplashForm();

        public long UserID { get; set; }

        #endregion

        public RepackItemShowBoxInfo()
        {
            InitializeComponent();
        }

        public RepackItemShowBoxInfo(string boxBarCode)
            : this()
        {
            tbScaner.Text = boxBarCode;
        }

        private void RepackItemShowBoxInfo_Load(object sender, EventArgs e)
        {
            tbScaner.TextChanged += new EventHandler(tbScaner_TextChanged);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (!string.IsNullOrEmpty(tbScaner.Text))
                this.ReloadBoxInfo(tbScaner.Text);
        }

        void tbScaner_TextChanged(object sender, EventArgs e)
        {
            this.ReloadBoxInfo(tbScaner.Text);
        }

        private void ReloadBoxInfo(string boxBarCode)
        {
            try
            {
                var bw = new BackgroundWorker();
                bw.DoWork += delegate(object sender, DoWorkEventArgs e)
                {
                    try
                    {
                        e.Result = repackItemBoxInfoTableAdapter.GetData(UserID, boxBarCode);
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };

                bw.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
                {
                    if (e.Result is Exception)
                        MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        wH.RepackItemBoxInfo.Merge(e.Result as DataTable);

                    waitProgressForm.CloseForce();
                };

                wH.RepackItemBoxInfo.Clear();

                waitProgressForm.ActionText = "Выполняется загрузка данных..";
                bw.RunWorkerAsync();
                waitProgressForm.ShowDialog();

                if (wH.RepackItemBoxInfo.Rows.Count == 0)
                    throw new Exception("Тележка пуста либо не существует.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            tbScaner.SelectAll();
            tbScaner.Focus();
        }
    }
}
