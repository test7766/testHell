using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.WH
{
    public partial class ChoiceLocationListForm : Form
    {
        private Dialogs.SplashForm waitProcessForm = new WMSOffice.Dialogs.SplashForm();
        public Data.WH.GetLocationListRow SelectedItem
        {
            get
            {
                if (dgvLocationList.SelectedRows.Count == 0)
                    return null;
                else
                    return (Data.WH.GetLocationListRow)((DataRowView)dgvLocationList.SelectedRows[0].DataBoundItem).Row;
            }
        }

        /// <summary>
        /// Свалидированное значение
        /// </summary>
        public Data.WH.GetLocationListRow VerifiedItem { get; private set; }

        /// <summary>
        /// Номер сесии
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// № документа
        /// </summary>
        public long? DocID { get; set; }

        /// <summary>
        /// Тип места на складе From/To
        /// </summary>
        public string FT { get; set; }

        public string WarehouseID_From { get; set; }

        public string WarehouseID_To { get; set; }

        public ChoiceLocationListForm()
        {
            InitializeComponent();
            try
            {
                Config.LoadDataGridViewSettings("ChoiceLocationListForm", dgvLocationList);
            }
            catch (Exception ex)
            {
                MessageBox.Show("У вас нет прав на загрузку и сохранение конфигурации из файла");
            }
            
            this.ApplyOperation(DialogResult.None);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Search();
        }

        private void Search()
        {
            BackgroundWorker loadWorker = new BackgroundWorker();
            loadWorker.DoWork += new DoWorkEventHandler(loadWorker_DoWork);
            loadWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(loadWorker_RunWorkerCompleted);
            this.LocationListbindingSource.DataSource = null;
            waitProcessForm.ActionText = "Обработка запроса...";
            loadWorker.RunWorkerAsync();
            waitProcessForm.ShowDialog();

        }

        private void loadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = this.getLocationListTableAdapter.GetData(UserID, DocID, FT, null, WarehouseID_From, WarehouseID_To);
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
                MessageBox.Show((e.Result as Exception).ToString(), "Ошибка поиска", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.wH.GetLocationList.Clear();
            }
            else
                this.LocationListbindingSource.DataSource = e.Result;

            waitProcessForm.CloseForce();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.ApplyOperation(DialogResult.OK);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ApplyOperation(DialogResult.Cancel);
        }

        private void ApplyOperation(DialogResult agreedResult)
        {
            this.DialogResult = agreedResult;
        }

        private void dgvLocationList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
                this.ApplyOperation(DialogResult.OK);
        }

        private void ChoiceLocationListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                e.Cancel = !ValidateOperation();
                try
                {
                    Config.SaveDataGridViewSettings("ChoiceLocationListForm", dgvLocationList);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("У вас нет прав на загрузку и сохранение конфигурации из файла");
                }
                
            }
        }

        private bool ValidateOperation()
        {
            if (this.SelectedItem == null)
            {
                MessageBox.Show("Не выбрана партия из списка!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Валидация введенного значения
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool VerifyValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;

            string lotNumber = value;

            BackgroundWorker verifyWorker = new BackgroundWorker();
            verifyWorker.DoWork += new DoWorkEventHandler(verifyWorker_DoWork);
            verifyWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(verifyWorker_RunWorkerCompleted);
            waitProcessForm.ActionText = "Валидация на соответствие справочнику..";
            verifyWorker.RunWorkerAsync(lotNumber);
            waitProcessForm.ShowDialog();

            return this.VerifiedItem != null;
        }

        void verifyWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string lotNumber = e.Argument.ToString();
                var table = this.getLocationListTableAdapter.GetData(UserID, DocID, FT, lotNumber, WarehouseID_From, WarehouseID_To);
                if (table.Rows.Count != 0)
                {
                    var abc = table[0].ItemArray;
                    this.VerifiedItem = table[0];
                }
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        void verifyWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            waitProcessForm.CloseForce();
        }
    }
}
