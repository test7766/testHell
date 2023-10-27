using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Reports;
using WMSOffice.Classes;

namespace WMSOffice.Dialogs.Quality
{
    public partial class QualityGLSActRecallSetParametersForm : DialogForm
    {
        private const byte RETURN_TYPE_OPTIMA = 1;


        public int DocID { get; private set; }

        public bool IsReadOnly { get; set; }

        private Button btnPrint = null;

        private bool isInitializeCompleted = false;

        public QualityGLSActRecallSetParametersForm()
        {
            InitializeComponent();
        }

        public QualityGLSActRecallSetParametersForm(int docID)
            : this()
        {
            this.DocID = docID;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(236, 8);
            this.btnCancel.Location = new Point(326, 8);

            if (this.IsReadOnly)
            {
                this.SetEditorsAccess();

                btnOK.Visible = false;
                btnCancel.Text = "Закрити";

                this.Text = string.Format("{0} (тільки читання)", this.Text);
            }
            else
            {
                btnOK.Text = "Зберегти";
            }

            btnPrint = this.AddAction("Друк", () =>
            {
                this.PrintData();
            },
           false, new Point(12, 8), AnchorStyles.Left);

            this.Initialize();
        }

        private void Initialize()
        {
            try
            {
                isInitializeCompleted = false;

                this.LoadReturnTypes();
                this.LoadProductConditions();
                this.LoadCompensationTypes();

                this.LoadData();

                if (quality.GA_Return_Dates.Count > 0)
                {
                    var data = quality.GA_Return_Dates[0];

                    if (data.IsReturnTypeNull())
                        cmbReturnTypes.SelectedItem = null;
                    else
                        cmbReturnTypes.SelectedValue = data.ReturnType;

                    if (data.IsProductConditionNull())
                        cmbProductConditions.SelectedItem = null;
                    else
                        cmbProductConditions.SelectedValue = data.ProductCondition;

                    if (data.IsCompensationTypeNull())
                        cmbCompensationTypes.SelectedItem = null;
                    else
                        cmbCompensationTypes.SelectedValue = data.CompensationType;

                    dtpReturnDate.Value = data.IsReturnDateNull() ? DateTime.Today : data.ReturnDate;
                    dtpClientLetterSend.Value = data.IsClientLetterSendNull() ? DateTime.Today : data.ClientLetterSend;
                    
                    dtpCoDateFrom.Value = data.IsCoDateFromNull() ? DateTime.Today : data.CoDateFrom;
                    dtpCoDateTo.Value = data.IsCoDateToNull() ? DateTime.Today : data.CoDateTo;

                    dtpCoClientClose.Value = data.IsCoClientCloseNull() ? DateTime.Today : data.CoClientClose;
                    dtpCoWhReturn.Value = data.IsCoWhReturnNull() ? DateTime.Today : data.CoWhReturn;

                    dtpDopClientLetterSend.Value = data.IsDopClientLetterSendNull() ? DateTime.Today : data.DopClientLetterSend;

                    dtpCoPCReClose.Value = data.IsCoPCReCloseNull() ? DateTime.Today : data.CoPCReClose;
                    dtpCoOmuClose.Value = data.IsCoOmuCloseNull() ? DateTime.Today : data.CoOmuClose;
                }
                else
                {
                    cmbReturnTypes.SelectedItem = null;
                    cmbProductConditions.SelectedItem = null;
                    cmbCompensationTypes.SelectedItem = null;
                }

                isInitializeCompleted = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadReturnTypes()
        {
            try
            {
                using (var adapter = new Data.QualityTableAdapters.GA_ReturnTypesTableAdapter())
                    adapter.Fill(quality.GA_ReturnTypes);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProductConditions()
        {
            try
            {
                using (var adapter = new Data.QualityTableAdapters.GA_ProductConditionsTableAdapter())
                    adapter.Fill(quality.GA_ProductConditions);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCompensationTypes()
        {
            try
            {
                using (var adapter = new Data.QualityTableAdapters.GA_CompensationTypesTableAdapter())
                    adapter.Fill(quality.GA_CompensationTypes);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            try
            {
                using (var adapter = new Data.QualityTableAdapters.GA_Return_DatesTableAdapter())
                    adapter.Fill(quality.GA_Return_Dates, this.DocID, this.UserID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbReturnTypes_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!this.IsReadOnly)
                this.SetEditorsAccess();
        }

        private void SetEditorsAccess()
        {
            var isDatePropertiesEnabled = cmbReturnTypes.SelectedValue == null || !cmbReturnTypes.SelectedValue.Equals(RETURN_TYPE_OPTIMA);


            cmbReturnTypes.Enabled = !this.IsReadOnly;
            cmbProductConditions.Enabled = !this.IsReadOnly;
            cmbCompensationTypes.Enabled = !this.IsReadOnly;

            dtpReturnDate.Enabled = !this.IsReadOnly;


            dtpClientLetterSend.Enabled = !this.IsReadOnly && isDatePropertiesEnabled;

            dtpCoDateFrom.Enabled = !this.IsReadOnly && isDatePropertiesEnabled;
            dtpCoDateTo.Enabled = !this.IsReadOnly && isDatePropertiesEnabled;

            dtpCoClientClose.Enabled = !this.IsReadOnly && isDatePropertiesEnabled;
            dtpCoWhReturn.Enabled = !this.IsReadOnly && isDatePropertiesEnabled;

            dtpDopClientLetterSend.Enabled = !this.IsReadOnly && isDatePropertiesEnabled;

            dtpCoPCReClose.Enabled = !this.IsReadOnly && isDatePropertiesEnabled;
            dtpCoOmuClose.Enabled = !this.IsReadOnly && isDatePropertiesEnabled;
        }

        private void dtpReturnDate_ValueChanged(object sender, EventArgs e)
        {
            if (isInitializeCompleted)
                this.RecalcData();
        }

        private void RecalcData()
        {
            try
            {
                using (var adapter = new Data.QualityTableAdapters.GA_Return_Dates_RecalcTableAdapter())
                    adapter.Fill(quality.GA_Return_Dates_Recalc, this.DocID, dtpReturnDate.Value);

                if (quality.GA_Return_Dates_Recalc.Count > 0)
                {
                    var data = quality.GA_Return_Dates_Recalc[0];

                    dtpReturnDate.Value = data.IsReturnDateNull() ? DateTime.Today : data.ReturnDate;
                    dtpClientLetterSend.Value = data.IsClientLetterSendNull() ? DateTime.Today : data.ClientLetterSend;

                    dtpCoDateFrom.Value = data.IsCoDateFromNull() ? DateTime.Today : data.CoDateFrom;
                    dtpCoDateTo.Value = data.IsCoDateToNull() ? DateTime.Today : data.CoDateTo;

                    dtpCoClientClose.Value = data.IsCoClientCloseNull() ? DateTime.Today : data.CoClientClose;
                    dtpCoWhReturn.Value = data.IsCoWhReturnNull() ? DateTime.Today : data.CoWhReturn;

                    dtpDopClientLetterSend.Value = data.IsDopClientLetterSendNull() ? DateTime.Today : data.DopClientLetterSend;

                    dtpCoPCReClose.Value = data.IsCoPCReCloseNull() ? DateTime.Today : data.CoPCReClose;
                    dtpCoOmuClose.Value = data.IsCoOmuCloseNull() ? DateTime.Today : data.CoOmuClose;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintData()
        {
            try
            {
                using (var report = new QualityGLSNoticeReport())
                {
                    var data = this.PrepareReportData();
                    report.SetDataSource(data);

                    using (Dialogs.ReportForm form = new WMSOffice.Dialogs.ReportForm())
                    {
                        form.Text = "Повідомлення за відкликанням";
                        form.ReportDocument = report;
                        form.ShowDialog();

                        if (form.IsPrinted)
                        {
                            // логирование факта печати
                            PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "GA", 29, Convert.ToInt64(this.DocID), (string)null, Convert.ToInt16(data.GA_Notice_Details.Count), form.PrinterName, Convert.ToByte(form.Copies));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Data.Quality PrepareReportData()
        { 
            var data = new Data.Quality();

            using (var adapter = new Data.QualityTableAdapters.GA_Notice_HeaderTableAdapter())
                adapter.Fill(data.GA_Notice_Header, this.DocID, this.UserID);

            using (var adapter = new Data.QualityTableAdapters.GA_Notice_DetailsTableAdapter())
                adapter.Fill(data.GA_Notice_Details, this.DocID, this.UserID);

            return data;
        }

        private void QualityGLSActRecallSetParametersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveData();
        }

        private bool SaveData()
        {
            try
            {
                if (cmbReturnTypes.SelectedValue == null)
                    throw new Exception("Не указано значение поля \"Возврат товара\"");

                if (cmbProductConditions.SelectedValue == null)
                    throw new Exception("Не указано значение поля \"Товарный вид\"");

                if (cmbCompensationTypes.SelectedValue == null)
                    throw new Exception("Не указано значение поля \"Тип работы с товаром\"");

                var returnType = (byte)cmbReturnTypes.SelectedValue;
                var productCondition = (byte)cmbProductConditions.SelectedValue;
                var compensationType = (byte)cmbCompensationTypes.SelectedValue;

                var returnDate = dtpReturnDate.Value;
                var clientLetterSend = dtpClientLetterSend.Value;

                var coDateFrom = dtpCoDateFrom.Value;
                var coDateTo = dtpCoDateTo.Value;

                var coClientClose = dtpCoClientClose.Value;
                var coWhReturn = dtpCoWhReturn.Value;

                var coDopClientLetterSend = dtpDopClientLetterSend.Value;

                var coPCReClose = dtpCoPCReClose.Value;
                var coOmuClose = dtpCoOmuClose.Value;

                using (var adapter = new Data.QualityTableAdapters.GA_Return_DatesTableAdapter())
                    adapter.Save(this.DocID, returnType, productCondition, compensationType,
                        returnDate, clientLetterSend, coDateFrom, coDateTo,
                        coClientClose, coWhReturn, coPCReClose, coOmuClose,
                        coDopClientLetterSend, this.UserID);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
