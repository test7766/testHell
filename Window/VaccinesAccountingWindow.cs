using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls;
using WMSOffice.Classes;
using WMSOffice.Dialogs.WH;

namespace WMSOffice.Window
{
    public partial class VaccinesAccountingWindow : GeneralWindow
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        public bool CanPrint { get; private set; }
        public bool CanApprove { get; private set; }

        public VaccinesAccountingWindow()
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
            stbWarehouse.ValueReferenceQuery = "[dbo].[pr_JV_Get_Available_Warehouses]";
            stbWarehouse.UserID = this.UserID;
            stbWarehouse.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stbVendor_OnVerifyValue);
            stbWarehouse.AddIgnorableColumn("Person_ID");
            stbWarehouse.AddIgnorableColumn("Warehouse_UDesc");

            stbVaccine.ValueReferenceQuery = "[dbo].[pr_JV_Get_Vaccine_List]";
            stbVaccine.UserID = this.UserID;
            stbVaccine.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stbVendor_OnVerifyValue);
            stbVaccine.AddIgnorableColumn("Item_Name_Ukr");
            stbVaccine.AddIgnorableColumn("ManufacturerName_Ukr");
            stbVaccine.AddIgnorableColumn("CountryOrigin_Ukr");

            stbStatusFrom.ValueReferenceQuery = "[dbo].[pr_JV_Get_Vaccine_Status_List]";
            stbStatusFrom.UserID = this.UserID;
            stbStatusFrom.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stbVendor_OnVerifyValue);
            stbStatusFrom.SetValueByDefault("100");

            stbStatusTo.ValueReferenceQuery = "[dbo].[pr_JV_Get_Vaccine_Status_List]";
            stbStatusTo.UserID = this.UserID;
            stbStatusTo.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stbVendor_OnVerifyValue);
            stbStatusTo.SetValueByDefault("200");

            dtpPeriodFrom.Value = DateTimeHelper.StartOfWeek(DateTime.Today, DayOfWeek.Monday).AddDays(-7);
            dtpPeriodTo.Value = DateTimeHelper.EndOfWeek(DateTime.Today, DayOfWeek.Monday).AddDays(-7);

            stbResponsible.ValueReferenceQuery = "[dbo].[pr_JV_Get_Responsible_Persons_List]";
            stbResponsible.UserID = this.UserID;
            stbResponsible.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stbVendor_OnVerifyValue);
            stbResponsible.AddIgnorableColumn("User_FIO_Ukr");
            stbResponsible.AddIgnorableColumn("Staff_Name_Ukr");

            //stbResponsible.ForeColor = Color.Blue;
            //tbResponsible.ForeColor = Color.Blue;

            dgvDocsHeaders.Columns[0].Frozen = true;

            dgvDocs.Columns[0].Frozen = true;
            dgvDocs.Columns[1].Frozen = true;

            this.SetUserAccess();
            this.SetOperationsAccess();
        }

        void stbVendor_OnVerifyValue(object sender, WMSOffice.Controls.VerifyValueArgs e)
        {
            var control = sender as SearchTextBox;
            TextBox lblDescription = null;

            if (control == stbWarehouse)
                lblDescription = tbWarehouse;
            else if (control == stbVaccine)
                lblDescription = tbVaccine;
            else if (control == stbStatusFrom)
                lblDescription = tbStatusFrom;
            else if (control == stbStatusTo)
                lblDescription = tbStatusTo;
            else if (control == stbResponsible)
                lblDescription = tbResponsible;

            if (lblDescription != null)
            {
                lblDescription.Text = e.Success ? e.Description : "ЗНАЧЕНИЕ НЕ НАЙДЕНО!";
                lblDescription.ForeColor = e.Success ? SystemColors.ControlText : Color.Red;

                if (e.Success)
                    control.Value = e.Value;
                //else
                //    control.Value = string.Empty;

                // Инициализация ответственного
                if (control == stbWarehouse)
                {
                    stbResponsible.SetValueByDefault(string.Empty);

                    if (e.Success && !string.IsNullOrEmpty(e.Value))
                    {
                        if (!e.OwnedRow["Person_ID"].Equals(DBNull.Value))
                        {
                            var personID = Convert.ToInt32(e.OwnedRow["Person_ID"]);
                            stbResponsible.SetValueByDefault(personID.ToString());
                        }
                    }
                }
            }
        }

        private void SetUserAccess()
        {
            try
            {
                var canPrint = (bool?)null;
                var canApprove = (bool?)null;
                jV_VaccineJournalTableAdapter.GetAccess(this.UserID, ref canPrint, ref canApprove);

                this.CanPrint = canPrint ?? false;
                this.CanApprove = canApprove ?? false;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F5))
            {
                this.RefreshData();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshData();
        }

        private void RefreshData()
        {
            try
            {
                var sessionID = this.UserID;
             
                var warehouseID = (string)null;
                if (string.IsNullOrEmpty(stbWarehouse.Value))
                    throw new Exception("Не указано подразделение.");
                else
                    warehouseID = stbWarehouse.Value;

                var itemID = (int?)null;
                if (string.IsNullOrEmpty(stbVaccine.Value))
                    throw new Exception("Не указана вакцина.");
                else
                {
                    int itemIDParsed;
                    if (!int.TryParse(stbVaccine.Value, out itemIDParsed))
                        throw new Exception("Код вакцины должен быть числом.");
                    else
                        itemID = itemIDParsed;
                }

                var periodFrom = dtpPeriodFrom.Value.Date;
                var periodTo = dtpPeriodTo.Value.Date;
                if (periodFrom > periodTo)
                    throw new Exception("Начальный период не должен превышать конечный.");

                var statusFrom = (int?)null;
                if (!string.IsNullOrEmpty(stbStatusFrom.Value))
                { 
                   int statusFromParsed;
                   if (!int.TryParse(stbStatusFrom.Value, out statusFromParsed))
                       throw new Exception("Код начального статуса должен быть числом.");
                   else
                       statusFrom = statusFromParsed;
                }

                var statusTo = (int?)null;
                if (!string.IsNullOrEmpty(stbStatusTo.Value))
                {
                    int statusToParsed;
                    if (!int.TryParse(stbStatusTo.Value, out statusToParsed))
                        throw new Exception("Код конечного статуса должен быть числом.");
                    else
                        statusTo = statusToParsed;
                }

                var loadWorker = new BackgroundWorker();
                loadWorker.DoWork += (s, e) => 
                {
                    try
                    {
                        jV_VaccineJournalTableAdapter.SetTimeout((int)TimeSpan.FromMinutes(3).TotalSeconds);
                       e.Result = jV_VaccineJournalTableAdapter.GetData(sessionID, warehouseID, itemID, periodFrom, periodTo, statusFrom, statusTo);
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                loadWorker.RunWorkerCompleted += (s, e) => 
                {
                    splashForm.CloseForce();

                    if (e.Result is Exception)
                        this.ShowError(e.Result as Exception);
                    else
                        wH.JV_VaccineJournal.Merge(e.Result as Data.WH.JV_VaccineJournalDataTable);
                };

                wH.JV_VaccineJournal.Clear();
                
                loadWorker.RunWorkerAsync();

                splashForm.ActionText = "Выполняется получение\nжурнала вакцин..";
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
               this.ShowError(ex);
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            this.ApproveDoc();
        }

        private void ApproveDoc()
        {
            try
            {
                if (MessageBox.Show("Вы желаете утвердить\nвсе выбранные документы?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                    return;

                var statusID = "300"; // архив
                var statusName = SearchTextBoxSelector.VerifyItem(stbStatusFrom.ValueReferenceQuery, stbStatusFrom.UserID, statusID, new List<ReferencedObject>(), AutoSelectItemSideMode.Top)[1].ToString();

                foreach (DataGridViewRow row in dgvDocs.SelectedRows)
                {
                    var doc = (row.DataBoundItem as DataRowView).Row as Data.WH.JV_VaccineJournalRow;

                    if (doc.Doc_Type == 0 || doc.Doc_Type == 1) // дебет или кредит
                    {
                        if (doc.Status_ID == 100 || doc.Status_ID == 200) // документ создан или просрочен
                        {
                            var docID = doc.Doc_ID;

                            jV_VaccineJournalTableAdapter.ChangeDocStatus(this.UserID, statusID, docID);
                            
                            doc.Status_ID = Convert.ToInt32(statusID);
                            doc.Status_Name = statusName;
                        }
                    }
                }

                dgvDocs.ClearSelection();

                MessageBox.Show("Документы утверждены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.Print();
        }

        private void Print()
        {
            try
            {
                var defaultParameters = new VaccinesDefaultPrintParameters()
                {
                    UserID = this.UserID,
                    WarehouseID = stbWarehouse.TextEditor.Text,
                    ItemID = stbVaccine.TextEditor.Text,
                    StatusFrom = stbStatusFrom.TextEditor.Text,
                    StatusTo = stbStatusTo.TextEditor.Text,
                    PeriodFrom = dtpPeriodFrom.Value,
                    PeriodTo = dtpPeriodTo.Value,
                    ResponsiblePersonID = stbResponsible.TextEditor.Text
                };

                var dlgVaccinesSetPrintParameters = new VaccinesSetPrintParametersForm(defaultParameters);
                if (dlgVaccinesSetPrintParameters.ShowDialog() == DialogResult.OK)
                {

                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void dgvDocs_SelectionChanged(object sender, EventArgs e)
        {
            this.SetOperationsAccess();
        }

        private void SetOperationsAccess()
        {
            var canApprove = false;
            foreach (DataGridViewRow row in dgvDocs.SelectedRows)
            {
                var doc = (row.DataBoundItem as DataRowView).Row as Data.WH.JV_VaccineJournalRow;

                // Доступ не возможен
                if (doc.Doc_Type == 2 || doc.Doc_Type == 3) // сальдо на начало или конец
                    continue;

                // Доступ возможен
                if (doc.Doc_Type == 0 || doc.Doc_Type == 1) // дебет или кредит
                {
                    if (doc.Status_ID == 100 || doc.Status_ID == 200) // документ создан или просрочен
                    {
                        canApprove = true;
                        break;
                    }
                }
            }

            btnPrint.Enabled = this.CanPrint;
            btnApprove.Enabled = canApprove && this.CanApprove;
        }

        private void dgvDocs_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                try
                {
                    dgvDocsHeaders.HorizontalScrollingOffset = e.NewValue;
                }
                catch (Exception ex)
                { }
            }
        }

        private void dgvDocsHeaders_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                try
                {
                    dgvDocs.HorizontalScrollingOffset = e.NewValue;
                }
                catch (Exception ex)
                { }
            }
        }

        private static readonly Color khakiBackColor = ColorTranslator.FromHtml("#fff5d5");
        private void dgvDocs_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var doc = (dgvDocs.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.WH.JV_VaccineJournalRow;

            var color = Color.Empty;
            var checkStatus = false;

            switch (doc.Doc_Type)
            {
                case 2:
                    color = khakiBackColor;
                    break;
                case 3:
                    color = Color.LightGreen;
                    break;
                default:
                    checkStatus = true;
                    break;
            }

            if (checkStatus)
            {
                switch (doc.Status_ID)
                {
                    case 100:
                        color = Color.White;
                        break;
                    case 200:
                        color = Color.LightPink;
                        break;
                    case 300:
                        color = Color.LightGray;
                        break;
                    default:
                        break;
                }
            }

            if (checkStatus)
            {
                e.CellStyle.BackColor = color;
                e.CellStyle.SelectionForeColor = color;
            }
            else
            {
                e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
                e.CellStyle.BackColor = color;
                e.CellStyle.SelectionBackColor = color;
                e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
            }
        }
    }
}
