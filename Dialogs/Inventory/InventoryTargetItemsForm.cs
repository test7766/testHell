using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Inventory
{
    public partial class InventoryTargetItemsForm : DialogForm
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm waitProcessForm = new WMSOffice.Dialogs.SplashForm();

        /// <summary>
        /// Ид-р документа инвентаризации
        /// </summary>
        public long InventoryDocID { get; set; }

        public InventoryTargetItemsForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.btnOK.Location = new Point(569, 8);
            this.btnCancel.Location = new Point(659, 8);
        }

        private void InventoryTargetItemsForm_Load(object sender, EventArgs e)
        {
            this.LoadItems();
        }

        /// <summary>
        /// Загрузка перечня товаров для инвентаризации
        /// </summary>
        private void LoadItems()
        {
            BackgroundWorker loadWorker = new BackgroundWorker();
            loadWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    e.Result = this.inventoryTargetItemsTableAdapter.GetData(this.UserID, this.InventoryDocID);
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            };

            loadWorker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Result is Exception)
                    MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    this.inventoryTargetItemsBindingSource.DataSource = e.Result;

                waitProcessForm.CloseForce();
            };

            this.inventoryTargetItemsBindingSource.DataSource = null;
            waitProcessForm.ActionText = "Идет получение перечня товаров..";
            loadWorker.RunWorkerAsync();
            waitProcessForm.ShowDialog();
        }
    }
}
