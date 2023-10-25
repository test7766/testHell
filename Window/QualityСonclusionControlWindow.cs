using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using WMSOffice.Dialogs.Complaints;

namespace WMSOffice.Window
{
    public partial class QualityСonclusionControlWindow : GeneralWindow
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        /// <summary>
        /// Возвращает текущую выделенную строку из таблицы со списком заключений.
        /// </summary>
        private Data.Quality.UphiqGetItemsRow SelectedRow
        {
            get
            {
                if (dgvConclusions.SelectedRows.Count > 0)
                    return (Data.Quality.UphiqGetItemsRow)((DataRowView)dgvConclusions.SelectedRows[0].DataBoundItem).Row;
                else
                    return null;
            }
        }

        /// <summary>
        /// ID выбранной строки
        /// </summary>
        private int SelectedRowID { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр диалога.
        /// </summary>
        public QualityСonclusionControlWindow()
        {
            InitializeComponent();

            Config.LoadDataGridViewSettings(this.Name, dgvConclusions);

            SelectedRowID = -1;
            btnAccept.Enabled = btnAccept.Visible = btnReject.Enabled = btnReject.Visible = false;
        }

        /// <summary>
        /// Обновляет содержимое при первом показе окна.
        /// </summary>
        private void QualityСonclusionControlWindow_Shown(object sender, EventArgs e)
        {
            btnRefresh_Click(null, EventArgs.Empty);
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Обновить список заключений".
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BackgroundWorker loadCurrentComplaintsWorker = new BackgroundWorker();
            loadCurrentComplaintsWorker.DoWork += new DoWorkEventHandler(loadCurrentConclusionsWorker_DoWork);
            loadCurrentComplaintsWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(loadConclusionsWorker_RunWorkerCompleted);

            uphiqGetItemsBindingSource.DataSource = null;
            splashForm.ActionText = "Обновление списка заключений...";
            loadCurrentComplaintsWorker.RunWorkerAsync();
            splashForm.ShowDialog();
        }

        /// <summary>
        /// Загружает в фоне список претензий, используя параметры, переданные в аргументе.
        /// </summary>
        private void loadCurrentConclusionsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Data.Quality.UphiqGetItemsDataTable resultTable = new Data.Quality.UphiqGetItemsDataTable();
            try
            {
                using (Data.QualityTableAdapters.UphiqGetItemsTableAdapter adapter = new Data.QualityTableAdapters.UphiqGetItemsTableAdapter())
                {
                    adapter.SetTimeout(60);
                    adapter.Fill(resultTable, dtpConclusionsFrom.Value, dtpConclusionsTo.Value, cBShowProccessing.Checked ? 1 : 0);
                }
                e.Result = resultTable;
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        /// <summary>
        /// Обрабатывает окончание загрузки в фоне списка претензий.
        /// </summary>
        private void loadConclusionsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Data.Quality.UphiqGetItemsDataTable resultTable = null;
            if (e.Result is Exception)
            {
                ShowError(e.Result as Exception);
            }
            else if (e.Result is Data.Quality.UphiqGetItemsDataTable)
            {
                resultTable = (Data.Quality.UphiqGetItemsDataTable)e.Result;
            }
            uphiqGetItemsBindingSource.DataSource = resultTable;

            if (SelectedRowID > 0)
            {
                for (int i = 0; i < dgvConclusions.Rows.Count; i++)
                    if (dgvConclusions["Processing_ID", i].Value != DBNull.Value && (int)dgvConclusions["Processing_ID", i].Value == SelectedRowID)
                    {
                        dgvConclusions.Rows[i].Selected = true;
                        dgvConclusions.FirstDisplayedScrollingRowIndex = i;
                    }
                SelectedRowID = -1;
            }

            splashForm.CloseForce();
        }

        /// <summary>
        /// Раскрашивание строк
        /// </summary>
        private void gvConclusions_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvConclusions.Rows)
            {
                Data.Quality.UphiqGetItemsRow dbRow = (Data.Quality.UphiqGetItemsRow)((DataRowView)row.DataBoundItem).Row;
                if (!dbRow.IsProcessing_StatusNull())
                    row.DefaultCellStyle.BackColor = Color.FromName(row.Cells["Processing_Status"].Value.ToString());              
            }            
        }

        /// <summary>
        /// Обрабатывает закрытие окна.
        /// </summary>
        private void QualityСonclusionControlWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Config.SaveDataGridViewSettings(this.Name, dgvConclusions);
        }

        /// <summary>
        /// Подтверждение соответствия товаров.
        /// </summary>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            Data.Quality.UphiqGetItemsRow selectedRow = SelectedRow;
            if (selectedRow != null)
            {
                try
                {
                    using (Data.QualityTableAdapters.QueriesTableAdapter query = new Data.QualityTableAdapters.QueriesTableAdapter())
                    {
                        using (EnterStringValueForm form = new EnterStringValueForm("Комментарий", "Введите комментарий к подтверждаемому соответствию товаров:", string.Empty))
                            if (form.ShowDialog() == DialogResult.OK)
                            {
                                query.UphiqChangeStatus(1, selectedRow.Processing_ID, selectedRow.Item_ID, UserID, form.Value);
                                //dgvConclusions.SelectedRows[0].DefaultCellStyle.BackColor = Color.LightGreen;
                                RefreshAndSelectRow();
                            }
                    }
                }
                catch (Exception ex)
                {
                    ShowError("Во время подтверждение соответствия товаров (ТоварID = " + selectedRow.Item_ID.ToString() +
                        ") возникла следующая ошибка:" + Environment.NewLine + Environment.NewLine + ex.Message);
                }
            }
            else
            {
                ShowError("Не выбрана строка!");
            }
        }

        /// <summary>
        /// Отклонение соответствия товаров.
        /// </summary>
        private void btnReject_Click(object sender, EventArgs e)
        {
            Data.Quality.UphiqGetItemsRow selectedRow = SelectedRow;
            if (selectedRow != null)
            {
                try
                {
                    using (Data.QualityTableAdapters.QueriesTableAdapter query = new Data.QualityTableAdapters.QueriesTableAdapter())
                    {
                        using (EnterStringValueForm form = new EnterStringValueForm("Комментарий", "Введите комментарий к отклоняемому соответствию товаров:", string.Empty))
                            if (form.ShowDialog() == DialogResult.OK)
                            {
                                query.UphiqChangeStatus(0, selectedRow.Processing_ID, selectedRow.Item_ID, UserID, form.Value);
                                //dgvConclusions.SelectedRows[0].DefaultCellStyle.BackColor = Color.Pink;
                                RefreshAndSelectRow();
                            }
                    }
                }
                catch (Exception ex)
                {
                    ShowError("Во время отклонения соответствия товаров (ТоварID = " + selectedRow.Item_ID.ToString() +
                        ") возникла следующая ошибка:" + Environment.NewLine + Environment.NewLine + ex.Message);
                }
            }
            else
            {
                ShowError("Не выбрана строка!");
            }
        }

        /// <summary>
        /// Обрабатывает смену выделенной строки в таблице.
        /// </summary>
        private void dgvConclusions_SelectionChanged(object sender, EventArgs e)
        {
            RefreshButtons();
        }

        /// <summary>
        /// Обновляет доступность кнопок.
        /// </summary>
        private void RefreshButtons()
        {
            if (SelectedRow != null)
            {
                btnAccept.Enabled = btnAccept.Visible = btnReject.Enabled = btnReject.Visible = (!SelectedRow.IsProcessing_Status_IDNull() && SelectedRow.Processing_Status_ID == 100) ? true : false;
            }
        }

        /// <summary>
        /// Обновляет строки и выбирает строку.
        /// </summary>
        private void RefreshAndSelectRow()
        {
            if (SelectedRow != null)
                SelectedRowID = SelectedRow.Processing_ID;
            btnRefresh_Click(null, EventArgs.Empty);
        }

        /// <summary>
        /// Применение Фильтра
        /// </summary>
        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            if (tbFilter.Text.Length >= 3)
            {
                uphiqGetItemsBindingSource.Filter = String.Format("Item_Name_JD like '%{0}%' or Item_Name_Web like '%{0}%' or Manufacturer_Name_JD like '%{0}%' or Manufacturer_Name_Web like '%{0}%' or Lot_Number like '%{0}%'", tbFilter.Text);
                int number;
                if (int.TryParse(tbFilter.Text, out number))
                    uphiqGetItemsBindingSource.Filter += String.Format("or Item_ID = {0}", tbFilter.Text);
            }
            else
                uphiqGetItemsBindingSource.RemoveFilter();
        }

        /// <summary>
        /// Отображение только строк к обработке
        /// </summary>
        private void cBShowProccessing_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh_Click(null, EventArgs.Empty);
        }
    }
}
