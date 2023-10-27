using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Transactions;

namespace WMSOffice.Dialogs.Complaints
{
    public partial class ComplaintsCheckErrorsLogForm : DialogForm
    {
        #region ПОЛЯ И СВОЙСТВА ДАННЫХ

        public readonly long? complaintDocID = null;

        private Data.Complaints.CheckExceptionsHeadersRow SelectedDocException
        {
            get { return (dgvExceptionsHeaders.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.Complaints.CheckExceptionsHeadersRow; }
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ

        public ComplaintsCheckErrorsLogForm()
        {
            InitializeComponent();
        }

        public ComplaintsCheckErrorsLogForm(long? pComplaintDocID)
            : this()
        {
            complaintDocID = pComplaintDocID;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(857, 8);
            this.btnCancel.Location = new Point(947, 8);

            this.btnOK.Visible = false;
            this.btnCancel.Text = "Закрыть";

            this.LoadHeaders();
            this.ChangeOperationAccess();
        }

        private void LoadHeaders()
        {
            var loadWorker = new BackgroundWorker();
            var waitProgressForm = new WMSOffice.Dialogs.SplashForm();

            loadWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    e.Result = checkExceptionsHeadersTableAdapter.GetData(this.UserID, complaintDocID);
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
                    checkExceptionsHeadersBindingSource.DataSource = e.Result;   

                waitProgressForm.CloseForce();
            };

            checkExceptionsHeadersBindingSource.DataSource = null;
            waitProgressForm.ActionText = "Выполняется загрузка реестра исключений..";
            loadWorker.RunWorkerAsync();
            waitProgressForm.ShowDialog();
        }

        #endregion

        private void dgvExceptionsHeaders_SelectionChanged(object sender, EventArgs e)
        {
            this.ChangeOperationAccess();

            if (dgvExceptionsHeaders.SelectedRows.Count == 0)
            {
                checkExceptionsDetailsBindingSource.DataSource = null;
            }
            else
            {
                var docID = this.SelectedDocException.Doc_ID;
                this.LoadDetails(docID);
            }
        }

        private void ChangeOperationAccess()
        {
            var isEnabled = dgvExceptionsHeaders.SelectedRows.Count > 0 && this.SelectedDocException.CO_Doc_Status_ID.Equals(ComplaintsConstants.ComplaintStatusWaitAccepting);

            btnAcceptException.Enabled = isEnabled;
            btnDeclineException.Enabled = isEnabled;
        }

        private void LoadDetails(long docID)
        {
            var loadWorker = new BackgroundWorker();
            var waitProgressForm = new WMSOffice.Dialogs.SplashForm();

            loadWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    e.Result = checkExceptionsDetailsTableAdapter.GetData(this.UserID, docID);
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
                    checkExceptionsDetailsBindingSource.DataSource = e.Result;

                waitProgressForm.CloseForce();
            };

            checkExceptionsDetailsBindingSource.DataSource = null;
            waitProgressForm.ActionText = "Выполняется загрузка состава исключения..";
            loadWorker.RunWorkerAsync();
            waitProgressForm.ShowDialog();

            if (dgvExceptionsDetails.Rows.Count > 0)
                dgvExceptionsDetails.Rows[0].Selected = false;
        }

        private void dgvExceptionsDetails_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var dr = (dgvExceptionsDetails.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Complaints.CheckExceptionsDetailsRow;

            bool isWarning = dr.IsIsWarningNull() ? false : dr.IsWarning;
            bool isError = dr.IsIsErrorNull() ? false : dr.IsError;

            if (isWarning)
            {
                e.CellStyle.BackColor = Color.Khaki;
                e.CellStyle.SelectionForeColor = Color.Khaki;
            }
            else
                if (isError)
                {
                    e.CellStyle.BackColor = Color.Salmon;
                    e.CellStyle.SelectionForeColor = Color.Salmon;
                }
        }

        private void btnAcceptException_Click(object sender, EventArgs e)
        {
            try
            { 
                var coDocID = this.SelectedDocException.CO_Doc_ID;
                var coDocStatusID = this.SelectedDocException.CO_Doc_Status_ID;
                var exceptionDocID = this.SelectedDocException.Doc_ID;

                if (MessageBox.Show(string.Format("Вы действительно хотите подтвердить исключения\r\nдля претензии № {0}?", coDocID), "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    var tranOptions = new TransactionOptions();
                    tranOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;

                    using (var scope = new TransactionScope(TransactionScopeOption.Required, tranOptions))
                    {
                        using (var adapter = new Data.ComplaintsTableAdapters.CurrentDocsTableAdapter())
                        {
                            adapter.ChangeDocExceptionsStatus(UserID, coDocID, "199", (string)null, exceptionDocID);
                            adapter.ChangeDocStatus(UserID, coDocID, ComplaintsConstants.ComplaintStatusAccepting, coDocStatusID);
                        }

                        scope.Complete();
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeclineException_Click(object sender, EventArgs e)
        {
            try
            {
                var coDocID = this.SelectedDocException.CO_Doc_ID;
                var coDocStatusID = this.SelectedDocException.CO_Doc_Status_ID;
                var exceptionDocID = this.SelectedDocException.Doc_ID;

                if (MessageBox.Show(string.Format("Вы действительно хотите отклонить исключения\r\nдля претензии № {0}?", coDocID), "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    var dlgEnterStringValueForm = new EnterStringValueForm("Комментарий", "Введите примечание к отклонению исключений проверок", string.Empty) { AllowEmptyValue = true };
                    if (dlgEnterStringValueForm.ShowDialog() == DialogResult.OK)
                    {
                        var comment = dlgEnterStringValueForm.Value;
                        if (string.IsNullOrEmpty(comment))
                            comment = "Не указан";

                        var tranOptions = new TransactionOptions();
                        tranOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;

                        using (var scope = new TransactionScope(TransactionScopeOption.Required, tranOptions))
                        {
                            using (var adapter = new Data.ComplaintsTableAdapters.CurrentDocsTableAdapter())
                            {
                                adapter.ChangeDocExceptionsStatus(UserID, coDocID, "198", comment, exceptionDocID);
                                adapter.ChangeDocStatus(UserID, coDocID, ComplaintsConstants.ComplaintStatusAutoClosingDeclined, coDocStatusID);
                            }

                            scope.Complete();
                        }

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
