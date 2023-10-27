using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Admin
{
    public partial class UserNotClosedDocumentsSelectorForm : DialogForm
    {
        /// <summary>
        /// Таймаут для выполнения запроса
        /// </summary>
        private const int QUERY_RESPONSE_TIMEOUT = 300;

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных
        /// </summary>
        private Dialogs.SplashForm waitProgressForm = new WMSOffice.Dialogs.SplashForm();

        /// <summary>
        /// Выбранный документ
        /// </summary>
        public Data.WH.DocsRow SelectedDoc
        {
            get { return dgvDocs.SelectedRows.Count != 0 ? (dgvDocs.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.WH.DocsRow : null; }
        }


        public UserNotClosedDocumentsSelectorForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.LoadNotClosedDocuments();
        }

        #region ФОНОВАЯ ЗАГРУЗКА ДОКУМЕНТОВ В РАБОТЕ
        /// <summary>
        /// Загрузка
        /// </summary>
        private void LoadNotClosedDocuments()
        {
            BackgroundWorker loadWorker = new BackgroundWorker();
            loadWorker.DoWork += new DoWorkEventHandler(loadWorker_DoWork);
            loadWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(loadWorker_RunWorkerCompleted);
            waitProgressForm.ActionText = "Выполняется поиск документов..";
            this.docsBindingSource.DataSource = null;
            loadWorker.RunWorkerAsync();
            waitProgressForm.ShowDialog();

            if (this.docsBindingSource.DataSource == null)
            {
                MessageBox.Show("У Вас отсутствуют документы в работе.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            dgvDocs.Focus();
        }

        void loadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                this.docsTableAdapter.SetTimeout(QUERY_RESPONSE_TIMEOUT);
                e.Result = this.docsTableAdapter.GetDataByEmpl(this.UserID);
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }
        
        void loadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
            {
                MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.wH.Docs.Clear();
            }
            else
                this.docsBindingSource.DataSource = e.Result;

            waitProgressForm.CloseForce();
        }
        #endregion

        private void dgvDocs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void dgvDocs_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.SelectedDoc != null && e.KeyCode == Keys.Enter)
            {
                this.DialogResult = DialogResult.OK;
                e.Handled = true;
            }
        }

        private void UserNotClosedDocumentsSelectorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.AllowCloseForm();
        }

        /// <summary>
        /// Определение возможности закрыть форму
        /// </summary>
        /// <returns></returns>
        private bool AllowCloseForm()
        {
            if (this.SelectedDoc == null)
            {
                MessageBox.Show("Для продолжения работы с документом Вам необходимо его выбрать.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private void dgvDocs_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Небольшая корректировка описания документа
            foreach (DataGridViewRow row in this.dgvDocs.Rows)
            {
               var boundRow = (row.DataBoundItem as DataRowView).Row as Data.WH.DocsRow;
               boundRow.Doc_Type_Name = boundRow.Doc_Type_Name.Replace("_", "");
            }
        }
    }
}
