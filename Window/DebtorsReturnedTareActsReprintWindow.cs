using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Classes.ReportProviders.DebtorsReturnedTareInvoice;
using WMSOffice.Classes;
using WMSOffice.Controls;
using WMSOffice.Controls.ExtraDataGridViewComponents;

namespace WMSOffice.Window
{
    public partial class DebtorsReturnedTareActsReprintWindow : GeneralWindow
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm waitProcessForm = new WMSOffice.Dialogs.SplashForm();

        public Data.Delivery.LT_ActsRow SelectedAct { get { return dgvActs.SelectedRows.Count > 0 ? ((dgvActs.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.Delivery.LT_ActsRow) : null; } }

        public DebtorsReturnedTareActsReprintWindow()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Initialize();
        }

        private void Initialize()
        {
            stbDeliveryID.ValueReferenceQuery = "[dbo].[pr_LT_RET_Get_Delivery]";
            stbDeliveryID.UserID = this.UserID;
            stbDeliveryID.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stbFilter_OnVerifyValue);
            //stbDeliveryID.SetValueByDefault("1234");
            //stbDeliveryID.ApplyFilter(new FilterStorage(new List<FilterItem>(new FilterItem[] { new FilterItem("delivery", string.Format("{0}*", stbDeliveryID.TextEditor.Text.Substring(0, Math.Min(4, stbDeliveryID.TextEditor.Text.Length)))) })));

            var today = DateTime.Today;
            dtpPeriodFrom.Value = today.AddMonths(-3);
            dtpPeriodTo.Value = today;

            this.SetOperationAccess();
        }

        void stbFilter_OnVerifyValue(object sender, WMSOffice.Controls.VerifyValueArgs e)
        {
            var control = sender as SearchTextBox;
            TextBox lblDescription = null;

            if (control == stbDeliveryID)
                lblDescription = tblDeliveryID;

            if (lblDescription != null)
            {
                lblDescription.Text = e.Success ? e.Description : "ЗНАЧЕНИЕ НЕ НАЙДЕНО!";
                lblDescription.ForeColor = e.Success ? SystemColors.ControlText : Color.Red;

                if (e.Success)
                    control.Value = e.Value;
                //else
                //    control.Value = string.Empty;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F5))
            {
                this.RefreshActs();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshActs();
        }

        private void RefreshActs()
        {
            try
            {
                int deliveryID;
                if (!string.IsNullOrEmpty(stbDeliveryID.Value))
                {
                    if (!int.TryParse(stbDeliveryID.Value, out deliveryID))
                        throw new Exception("Код торговой точки должен быть числом.");
                }
                else
                    throw new Exception("Не указан код торговой точки.");

                var periodFrom = dtpPeriodFrom.Value.Date;
                var periodTo = dtpPeriodTo.Value.Date;

                if (periodFrom > periodTo)
                    throw new Exception("Начальный период не должен превышать конечный.");

                var loadWorker = new BackgroundWorker();
                loadWorker.DoWork += (s, e) => 
                {
                    try
                    {
                        e.Result = lT_ActsTableAdapter.GetData(this.UserID, deliveryID, periodFrom, periodTo);
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                loadWorker.RunWorkerCompleted += (s, e) =>
                {
                    waitProcessForm.CloseForce();

                    if (e.Result is Exception)
                        this.ShowError(e.Result as Exception);
                    else
                        lTActsBindingSource.DataSource = e.Result;
                };

                lTActsBindingSource.DataSource = null;
                waitProcessForm.ActionText = "Выполняется получение списка актов на клиентскую оборотную тару..";
                loadWorker.RunWorkerAsync();
                waitProcessForm.ShowDialog();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }


        private void btnCreate_Click(object sender, EventArgs e)
        {
            this.CreateAct();
        }

        private void CreateAct()
        {
            try
            {
                int deliveryID;
                if (!string.IsNullOrEmpty(stbDeliveryID.Value))
                {
                    if (!int.TryParse(stbDeliveryID.Value, out deliveryID))
                        throw new Exception("Код торговой точки должен быть числом.");
                }
                else
                    throw new Exception("Не указан код торговой точки.");

                var message = (string)null;
                lT_ActsTableAdapter.CreateAct(this.UserID, deliveryID, ref message);

                if (!string.IsNullOrEmpty(message))
                    MessageBox.Show(message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.RefreshActs();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.PrintAct();
        }

        private void PrintAct()
        {
            try
            {
                var docID = this.SelectedAct.Doc;
                var docType = this.SelectedAct.DocType;

                var isDraft = true;
                var pickControlData = DebtorsReturnedTareInvoiceHelper.GetTareInvoiceReportData(docID, docType, "00001", (long?)null, (int?)null, this.UserID, false, out isDraft);
                if (pickControlData != null)
                {
                    using (var rdp = new PrintReportDocumentProvider())
                    {
                        // подставляем признак черновика
                        rdp.Init(isDraft, pickControlData);
                        rdp.Preview();
                        rdp.OnPrintCompleted += (s, e) =>
                        {
                            // логирование факта печати
                            PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "PN", 14, docID, docType, Convert.ToInt16(e.DocLines), e.PrinterName, Convert.ToByte(e.Copies));
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }


        private void dgvActs_SelectionChanged(object sender, EventArgs e)
        {
            this.SetOperationAccess();
        }

        private void SetOperationAccess()
        {
            var isEnabled = this.SelectedAct != null;
            btnPrint.Enabled = isEnabled;
        }

        private void dgvActs_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var act = (dgvActs.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Delivery.LT_ActsRow;

            if (act.StatusID == 100)
            {
                e.CellStyle.SelectionForeColor = e.CellStyle.BackColor = Color.LightGray;
            }
        }
    }
}
