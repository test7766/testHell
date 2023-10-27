using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Inventory
{
    public partial class InventoryManageDiscrepanciesForm : DialogForm
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm waitProcessForm = new WMSOffice.Dialogs.SplashForm();

        /// <summary>
        /// Ид-р документа инвентаризации
        /// </summary>
        public long InventoryDocID { get; set; }

        public InventoryManageDiscrepanciesForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.btnOK.Location = new Point(145, 8);
            this.btnCancel.Location = new Point(235, 8);

            this.LoadData();
        }

        /// <summary>
        /// Загрузка данных
        /// </summary>
        private void LoadData()
        {
            bool canContinue = false;
            Data.Inventory.InventoryItemsOfferingDataTable dtDifference = null;
            BackgroundWorker loadWorker = new BackgroundWorker();
            loadWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                   
                    using (var adapter = new Data.InventoryTableAdapters.InventoryItemsOfferingTableAdapter())
                    {
                       e.Result = adapter.GetData(this.InventoryDocID);
                    }
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
                {
                    dtDifference = e.Result as Data.Inventory.InventoryItemsOfferingDataTable;
                    canContinue = true;
                }
                waitProcessForm.CloseForce();
            };

            waitProcessForm.ActionText = "Выполняется получение итоговых расхождений..";
            loadWorker.RunWorkerAsync();
            waitProcessForm.ShowDialog();

            if (canContinue)
            {
                if (dtDifference.Count > 0)
                {
                    if (!dtDifference[0].IsSurplus_UAHNull())
                        lblSurplusTotalSum.Text = dtDifference[0].Surplus_UAH.ToString("f2");

                    if (!dtDifference[0].IsShortage_UAHNull())
                        lblShortageTotalSum.Text = dtDifference[0].Shortage_UAH.ToString("f2");

                    if (!dtDifference[0].IsResult_UAHNull())
                        lblTotalSum.Text = dtDifference[0].Result_UAH.ToString("f2");
                }
            }
        }

        private void InventoryManageDiscrepanciesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.AutoOfferRemains();
        }

        /// <summary>
        /// Автоприходование излишков
        /// </summary>
        private bool AutoOfferRemains()
        {
            bool succeed = false;
            BackgroundWorker saveWorker = new BackgroundWorker();
            saveWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    using (Data.InventoryTableAdapters.InventoryItemsOfferingTableAdapter adapter = new WMSOffice.Data.InventoryTableAdapters.InventoryItemsOfferingTableAdapter())
                    {
                        int RESPONSE_WAIT_TIMEOUT = 1800; // 30 минут
                        adapter.SetTimeout(RESPONSE_WAIT_TIMEOUT);
                        adapter.AutoOfferRemains(this.InventoryDocID);
                    }
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            };
            saveWorker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Result is Exception)
                    MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Проводки успешно сформированы.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    succeed = true;
                }

                waitProcessForm.CloseForce();
            };

            waitProcessForm.ActionText = "Выполняется балансировка расхождений..";
            saveWorker.RunWorkerAsync();
            waitProcessForm.ShowDialog();

            return succeed;
        }
    }
}
