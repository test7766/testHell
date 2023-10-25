using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs.ColdChain;

namespace WMSOffice.Window
{
    public partial class ColdChainSetUnloadingTimeWindow : GeneralWindow
    {
        /// <summary>
        /// Класс-менеджер данной формы
        /// </summary>
        private ColdChainSetUnloadingTimeManager manager = null;
        private readonly Color HANDLED_ACT_COLOR = Color.Green; // цвет обработанного акта
        private readonly Color ALLOW_ACT_COLOR = Color.Yellow; // цвет акта доступного к обработке

        private bool allowSetActsTimeStamp; // признак возможности проставления времени акта для текущего заказа

        /// <summary>
        /// Текущий акт
        /// </summary>
        private Data.ColdChain.DeliveryOrderActsRow CurrentActRow { get { return (this.deliveryOrderActsBindingSource.CurrencyManager.Current as DataRowView).Row as Data.ColdChain.DeliveryOrderActsRow; } }

        public ColdChainSetUnloadingTimeWindow(ColdChainSetUnloadingTimeManager manager)
        {
            InitializeComponent();
            this.manager = manager;
        }

        private void ColdChainSetUnloadingTimeWindow_Load(object sender, EventArgs e)
        {
            this.deliveryOrderActsBindingSource.CurrentItemChanged += new EventHandler(deliveryOrderActsBindingSource_CurrentItemChanged);
        }

        private void deliveryOrderActsBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            this.deliveryOrderActDetailsBindingSource.DataSource = null;

            if (this.IsActsExists())
            {
                manager.CurrentActID = this.CurrentActRow.Doc_ID;
                this.RefreshActItems();
            }

            SetInterfaceSettings();
        }

        private bool IsActsExists()
        {
            return this.deliveryOrderActsBindingSource.CurrencyManager.Count > 0;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.RefreshData(new LoadWorkerFilterParameters());
        }

        private void RefreshActItems()
        {
            try
            {
                this.deliveryOrderActDetailsBindingSource.DataSource = this.deliveryOrderActDetailsTableAdapter.GetData(this.manager.CurrentActID);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Ошибка момента загрузки состава текущего акта", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обновление списка заказов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefreshData_Click(object sender, EventArgs e)
        {
            RefreshData(new LoadWorkerFilterParameters());
        }

        #region Фоновая загрузка актов
        private void RefreshData(LoadWorkerFilterParameters parameters)
        {
            BackgroundWorker loadWorker = new BackgroundWorker();
            loadWorker.DoWork += new DoWorkEventHandler(loadWorker_DoWork);
            loadWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(loadWorker_RunWorkerCompleted);
            this.deliveryOrderActsBindingSource.DataSource = null;
            manager.WaitProcessForm.ActionText = "Выполняется загрузка актов...";
            loadWorker.RunWorkerAsync(parameters);
            manager.WaitProcessForm.ShowDialog();
        }

        private void loadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                LoadWorkerFilterParameters p = e.Argument as LoadWorkerFilterParameters;
                e.Result = this.deliveryOrderActsTableAdapter.GetData(manager.UserID, p.ActID, p.OrderID);
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
                ShowError(e.Result as Exception);
                this.coldChain.DeliveryOrderActs.Clear();
            }
            else
                this.deliveryOrderActsBindingSource.DataSource = e.Result;

            manager.WaitProcessForm.CloseForce();
        }
        #endregion

        /// <summary>
        /// Обновление состояния интерфейса
        /// </summary>
        private void SetInterfaceSettings()
        {
            allowSetActsTimeStamp = IsActsExists() && (this.CurrentActRow.Color.ToLower() == ALLOW_ACT_COLOR.Name.ToLower());
            btnSetTimeStamp.Enabled = allowSetActsTimeStamp;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.F))
                SearchData();

            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Поиск заказа по номеру заказа, коду акта в маршрутном листе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearchData_Click(object sender, EventArgs e)
        {
            this.SearchData();
        }

        /// <summary>
        /// Метод поиска заказов по коду акта либо номеру заказа
        /// </summary>
        private void SearchData()
        {
            using (SearchOrdersForm frmSearchOrders = new SearchOrdersForm())
            {
                if (frmSearchOrders.ShowDialog() == DialogResult.OK)
                    this.RefreshData(frmSearchOrders.GetFilterParameters());
            }
        }

        /// <summary>
        /// Проставления времени с актов в заказе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetTimeStamp_Click(object sender, EventArgs e)
        {
            SetActTimeStamp();
        }

        /// <summary>
        /// Проставление времени с акта в заказе по двойному клику на гриде
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && allowSetActsTimeStamp)
                SetActTimeStamp();
        }

        /// <summary>
        /// Проставление даты и времени по акту текущего заказа
        /// </summary>
        private void SetActTimeStamp()
        {
            SetTimeStampForm frmSetTimeStamp = new SetTimeStampForm();
            if (frmSetTimeStamp.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (Data.ColdChainTableAdapters.QueriesTableAdapter adapter = new WMSOffice.Data.ColdChainTableAdapters.QueriesTableAdapter())
                        adapter.SaveActTimeStamp(manager.CurrentActID, frmSetTimeStamp.ActTimeStamp, manager.UserID);

                    this.CurrentActRow.Date_Unloading = frmSetTimeStamp.ActTimeStamp;
                    this.CurrentActRow.Color = HANDLED_ACT_COLOR.Name;
                    this.ColorActs();
                }
                catch (System.Data.SqlClient.SqlException er)
                {
                    MessageBox.Show(er.Message, "Ошибка момента сохранения времени с акта текущего заказа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvOrders_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.ColorActs();
        }

        /// <summary>
        /// Раскраска актов согласно статусу
        /// </summary>
        private void ColorActs()
        {
            // Разрисовка строк в таблице
            foreach (DataGridViewRow row in dgvOrders.Rows)
            {
                Data.ColdChain.DeliveryOrderActsRow itemRow = (Data.ColdChain.DeliveryOrderActsRow)((DataRowView)row.DataBoundItem).Row;

                // Простая разрисовка строки
                string colorName = itemRow.IsColorNull() ? "white" : itemRow.Color.ToLower();
                Color backColor = Color.FromName(colorName);

                for (int c = 0; c < row.Cells.Count; c++)
                {
                    row.Cells[c].Style.BackColor = backColor;
                    row.Cells[c].Style.SelectionForeColor = backColor;
                }
            }
        }

        /// <summary>
        /// Параметры поиска
        /// </summary>
        public class LoadWorkerFilterParameters
        {
            public long? ActID { get; set; }
            public double? OrderID { get; set; }

            public LoadWorkerFilterParameters()
            {
                this.ActID = null;
                this.OrderID = null;
            }

        }
    }
}
