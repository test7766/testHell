using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs.Receive;
using WMSOffice.Controls;
using WMSOffice.Classes;

namespace WMSOffice.Window
{
    public partial class ItemsMeasurementWindow : GeneralWindow
    {

        private Dialogs.SplashForm waitProcessForm = new WMSOffice.Dialogs.SplashForm();

        public ItemsMeasurementWindow()
        {
            InitializeComponent();
        }

        private void ItemsMeasurementWindow_Load(object sender, EventArgs e)
        {
           // RefreshGrid();
            stbBatchNumber.ValueReferenceQuery = "[dbo].[pr_WH_Get_LOTN]";
            stbBatchNumber.AddReference(tbItemCode, "Text");
            stbBatchNumber.UserID = this.UserID;
            stbBatchNumber.OnVerifyValue += delegate(object snd, WMSOffice.Controls.VerifyValueArgs ea)
            {
                var control = snd as SearchTextBox;
                Label lblDescription = null;

                if (control == stbBatchNumber)
                    lblDescription = lblBatchNumber;

                if (lblDescription != null)
                {
                    lblDescription.Text = ea.Success ? ea.Description : "ЗНАЧЕНИЕ НЕ НАЙДЕНО!";
                    lblDescription.ForeColor = ea.Success ? SystemColors.ControlText : Color.Red;

                    if (ea.Success)
                        control.Value = ea.Value;
                    //else
                    //    control.Value = string.Empty;
                }
            };
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            cbSearchCriteria.SelectedIndex = 0;
            cbUseBatchNumber.Checked = false;
            tbItemCode.Focus();
        }

        private void miRefresh_Click(object sender, EventArgs e)
        {
           RefreshGrid();
        }

        private void gvBranches_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                MeasurementItem();
            }
        }

        private void gvBranches_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MeasurementItem();
        }

        private void MeasurementItem()
        {
            if (gvBranches.SelectedRows.Count == 1)
            {
                Data.ItemsMeasurement.ItemsRow row = ((Data.ItemsMeasurement.ItemsRow)((DataRowView)gvBranches.SelectedRows[0].DataBoundItem).Row);
                MeasurementForm form = new MeasurementForm();
                form.UserID = UserID;
                form.ItemID = (int)row.item_id;
                form.ItemName = row.item;
                form.BatchNumber = row.Islot_numberNull() ? (string)null : row.lot_number;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // сохраняем объемно-весовые характеристики (задание формируем в самой форме)
                    // и обновляем текущее окно
                    RefreshGrid();
                }
            }
        }
        
        private void tbItemCode_KeyDown(object sender, KeyEventArgs e)
        {         
            if (e.KeyCode == Keys.Enter)
                this.RefreshGrid();
        }

        private void tbItemCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void tbItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.RefreshGrid();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.RefreshGrid();
        }

        #region ФОНОВАЯ ЗАГРУЗКА ДАННЫХ
        /// <summary>
        /// Метод обновления таблицы с данными
        /// </summary>
        private void RefreshGrid()
        {
            if (cbUseBatchNumber.Checked && string.IsNullOrEmpty(tbItemCode.Text) && string.IsNullOrEmpty(stbBatchNumber.Value))
            {
                MessageBox.Show("В режиме поиска по партии необходимо обязательно\r\nуказывать либо код товара либо номер партии.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            BackgroundWorker loadWorker = new BackgroundWorker();
            loadWorker.DoWork += new DoWorkEventHandler(loadWorker_DoWork);
            itemsBindingSource.DataSource = null;
            waitProcessForm.ActionText = "Поиск товаров...";
            loadWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(loadWorker_RunWorkerCompleted);
            loadWorker.RunWorkerAsync(new SearchParameters() 
            { 
                Criteria = cbSearchCriteria.SelectedIndex, 
                ObjectID = (tbItemCode.Text == string.Empty) ? (int?)null : Convert.ToInt32(tbItemCode.Text),
                ObjectName = (tbItemName.Text.Trim() == string.Empty) ? (string)null : tbItemName.Text.Trim(),
                IncludeOutDatedItems = chbIncludeOutDatedItems.Checked, 
                IncludeUnPurchasedItems = chbIncludeUnPurchasedItems.Checked, 
                IncludeDeficiencyItems = chbIncludeDeficiencyItems.Checked,
                UseBatchNumberOnly = cbUseBatchNumber.Checked,
                BatchNumber = string.IsNullOrEmpty(stbBatchNumber.Value) ? (string)null : stbBatchNumber.Value
            });
            waitProcessForm.ShowDialog();
        }
        /// <summary>
        /// Параметры поиска
        /// </summary>
        private class SearchParameters
        {
            public int Criteria { get; set; }
            public int? ObjectID { get; set; }
            public string ObjectName { get; set; }
            public bool IncludeOutDatedItems { get; set; }
            public bool IncludeUnPurchasedItems { get; set; }
            public bool IncludeDeficiencyItems { get; set; }
            public bool UseBatchNumberOnly { get; set; }
            public string BatchNumber { get; set; }
        }

        private void loadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var searchParams = e.Argument as SearchParameters;

                e.Result = this.itemsTableAdapter.GetData(
                    searchParams.Criteria, 
                    searchParams.ObjectID, 
                    searchParams.ObjectName, 
                    searchParams.IncludeOutDatedItems, 
                    searchParams.IncludeUnPurchasedItems, 
                    searchParams.IncludeDeficiencyItems,
                    searchParams.UseBatchNumberOnly,
                    searchParams.BatchNumber);
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
                this.ShowError(e.Result as Exception);
                this.itemsMeasurement.Clear();
            }
            else
                itemsBindingSource.DataSource = e.Result;

            waitProcessForm.CloseForce();
        }
        #endregion

        private void gvBranches_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Разрисовка строк в таблице
            foreach (DataGridViewRow row in gvBranches.Rows)
            {
                Data.ItemsMeasurement.ItemsRow itemRow = (Data.ItemsMeasurement.ItemsRow)((DataRowView)row.DataBoundItem).Row;

                // Простая разрисовка строки
                Color backColor = itemRow.item_used == 0 ? Color.LightGray : Color.White;
                for (int c = 0; c < row.Cells.Count; c++)
                {
                    row.Cells[c].Style.BackColor = backColor;
                    row.Cells[c].Style.SelectionForeColor = backColor;
                }
            }
        }

        private void cbUseBatchNumber_CheckedChanged(object sender, EventArgs e)
        {
            this.ChangeBatchNumberUsageDesign(cbUseBatchNumber.Checked);
        }

        private void ChangeBatchNumberUsageDesign(bool changeTo)
        {
            stbBatchNumber.Enabled = changeTo;
            stbBatchNumber.TextEditor.Clear();
            lblBatchNumber.Text = string.Empty;
        }

        private void btnOpenWizard_Click(object sender, EventArgs e)
        {
            try
            {
                // Создаем провайдер
                var mProviderExternal = new ObtainMeasureProvider();

                try
                {
                    var measureAcquireMode = (WMSOffice.Controls.Receive.Measurement.MeasurementItem.CheckObtainMeasureAccess(this.UserID) == 1);
                    if (measureAcquireMode)
                        mProviderExternal.Initialize();
                    else
                        mProviderExternal.IsAccessDenied = true;
                }
                catch (Exception ex)
                {
                    mProviderExternal.IsAccessDenied = true;
                }

                while (true)
                {
                    var measurementWizardForm = new WMSOffice.Dialogs.Receive.MeasurementWizardForm(this.UserID, mProviderExternal);
                    measurementWizardForm.Owner = this;

                    if (measurementWizardForm.ShowDialog() != DialogResult.OK)
                        break;
                }

                // Завершаем работу с провайдером
                mProviderExternal.Disconnect();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }
    }
}
