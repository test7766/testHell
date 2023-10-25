using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs.Docs;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Controls;

namespace WMSOffice.Window
{
    public partial class AttorneysWindow : GeneralWindow
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        public AttorneysWindow()
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
            stbWarehouse.ValueReferenceQuery = "[dbo].[pr_AC_Get_MCU_List]";
            stbWarehouse.UserID = this.UserID;
            stbWarehouse.OnVerifyValue += new VerifyValueHandler(stb_OnVerifyValue);

            stbWarehouse.SetFirstValueByDefault();

            stbReceiver.ValueReferenceQuery = "[dbo].[pr_AC_Debtors_Search]";
            stbReceiver.ApplyAdditionalParameter(stbReceiver.Name, 0);
            //stbReceiver.AddReference(stbWarehouse, "Value");
            stbReceiver.UserID = this.UserID;
            stbReceiver.OnVerifyValue += new VerifyValueHandler(stb_OnVerifyValue);

            stbMainDebtor.ValueReferenceQuery = "[dbo].[pr_AC_Debtors_Search]";
            stbMainDebtor.ApplyAdditionalParameter(stbMainDebtor.Name, 1);
            //stbMainDebtor.AddReference(stbWarehouse, "Value");
            stbMainDebtor.UserID = this.UserID;
            stbMainDebtor.OnVerifyValue += new VerifyValueHandler(stb_OnVerifyValue);

            xdgvDocs.AllowSummary = false;

            xdgvDocs.Init(new AttorneyView(), true);
            xdgvDocs.UserID = this.UserID;

            xdgvDocs.OnDataError += new DataGridViewDataErrorEventHandler(xdgvDocs_OnDataError);
            xdgvDocs.OnRowDoubleClick += new DataGridViewCellEventHandler(xdgvDocs_OnRowDoubleClick);
            xdgvDocs.OnRowSelectionChanged += new EventHandler(xdgvDocs_OnRowSelectionChanged);
            xdgvDocs.OnFilterChanged += new EventHandler(xdgvDocs_OnFilterChanged);
            xdgvDocs.OnDataBindingComplete += new DataGridViewBindingCompleteEventHandler(xdgvDocs_OnDataBindingComplete);
            xdgvDocs.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvDocs_OnFormattingCell);

            // активация постраничного просмотра
            xdgvDocs.CreatePageNavigator();

            this.SetOperationAccess(true);

            stbWarehouse.Focus();
        }

        void stb_OnVerifyValue(object sender, VerifyValueArgs e)
        {
            var control = sender as SearchTextBox;
            TextBox lblDescription = null;

            if (control == stbWarehouse)
                lblDescription = tbWarehouseName;
            else if (control == stbReceiver)
                lblDescription = tbReceiverName;
            else if (control == stbMainDebtor)
                lblDescription = tbMainDebtorName;

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

        void xdgvDocs_OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        void xdgvDocs_OnRowDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            if (xdgvDocs.SelectedItem != null)
                this.EditAttorney(false);
        }

        void xdgvDocs_OnRowSelectionChanged(object sender, EventArgs e)
        {
            this.SetOperationAccess(false);
        }

        private void SetOperationAccess(bool wholeViewAccess)
        {
            if (wholeViewAccess)
            {
                btnEdit.Enabled = xdgvDocs.HasRows;
                btnDelete.Enabled = xdgvDocs.HasRows;
                btnRevert.Enabled = xdgvDocs.HasRows;
                btnExportToExcel.Enabled = xdgvDocs.HasRows;
            }
            else
            {
                bool isEnabled = xdgvDocs.SelectedItem != null;

                btnEdit.Enabled = isEnabled;
                btnDelete.Enabled = isEnabled;
                btnRevert.Enabled = isEnabled;
                btnExportToExcel.Enabled = isEnabled;
            }
        }

        void xdgvDocs_OnFilterChanged(object sender, EventArgs e)
        {
            xdgvDocs.RecalculateSummary();
            this.SetOperationAccess(true);
        }

        /// <summary>
        /// Пустое изображение
        /// </summary>
        private static Bitmap emptyIcon = new Bitmap(16, 16);

        void xdgvDocs_OnDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in xdgvDocs.DataGrid.Rows)
            {
                var boundRow = (xdgvDocs.DataGrid.Rows[row.Index].DataBoundItem as DataRowView).Row;

                foreach (DataGridViewColumn column in xdgvDocs.DataGrid.Columns)
                {
                    #region ПОДСТАНОВКА ИКОНОК ПО НАЛИЧИЮ ВЛОЖЕНИЙ ЭЛЕКТРОННЫХ КОПИЙ ДОВЕРЕННОСТИ

                    if (column is DataGridViewImageColumn)
                    {
                        if (column.Tag != null)
                        {
                            string linkedFieldName = column.Tag.ToString();
                            if (linkedFieldName == "Has_Attachment")
                            {
                                var hasAttachment = Convert.ToBoolean(boundRow[linkedFieldName]);

                                if (hasAttachment)
                                    xdgvDocs.DataGrid.Rows[row.Index].Cells[column.Index].Value = Properties.Resources.pin;
                                else
                                    xdgvDocs.DataGrid.Rows[row.Index].Cells[column.Index].Value = emptyIcon;
                            }
                        }
                    }

                    #endregion
                }
            }
        }

        void xdgvDocs_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            var boundRow = (xdgvDocs.DataGrid.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;

            #region СТИЛЬ ДЛЯ ИНДИКАЦИИ ДОВЕРЕННОСТЕЙ ГЛАВНОГО ДЕБИТОРА

            var isMainDebtor = Convert.ToBoolean(boundRow["Is_Main_Debtor"]);
            if (isMainDebtor)
            {
                var color = Color.LightGreen;
                e.CellStyle.BackColor = color;
                e.CellStyle.SelectionForeColor = color;
                //e.CellStyle.SelectionBackColor = color;
            }

            #endregion
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F5))
            {
                this.ReloadData();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.ReloadData();
        }

        private void ReloadData()
        {
            try
            {
                var searchParams = new AttorneySearchParameters() { SessionID = this.UserID };

                if (string.IsNullOrEmpty(stbWarehouse.Value))
                    throw new Exception("Код склада должен быть указан.");
                else
                    searchParams.WarehouseID = stbWarehouse.Value;

                if (!string.IsNullOrEmpty(stbReceiver.Value))
                {
                    int receiverID;
                    if (!int.TryParse(stbReceiver.Value, out receiverID))
                        throw new Exception("Код получателя должен быть числом.");
                    else
                        searchParams.ReceiverID = receiverID;
                }

                if (!string.IsNullOrEmpty(stbMainDebtor.Value))
                {
                    int mainDebtorID;
                    if (!int.TryParse(stbMainDebtor.Value, out mainDebtorID))
                        throw new Exception("Код главного дебитора должен быть числом.");
                    else
                        searchParams.MainDebtorID = mainDebtorID;
                }

                searchParams.ShowOnlyActualAttorney = cbShowOnlyActualAttorney.Checked;

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    this.xdgvDocs.DataView.FillData(e.Argument as AttorneySearchParameters);
                };
                bw.RunWorkerCompleted += (s, e) =>
                {
                    if (e.Result is Exception)
                        this.ShowError(e.Result as Exception);
                    else
                    {
                        this.xdgvDocs.BindData(false);

                        //this.xdgvDocs.AllowFilter = true;
                        this.xdgvDocs.AllowSummary = true;
                    }

                    splashForm.CloseForce();
                };

                splashForm.ActionText = "Выполняется получение доверенностей..";
                bw.RunWorkerAsync(searchParams);
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.ModifyAttorney((AttorneyProperties)null);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.EditAttorney(false);
        }

        private void btnRevert_Click(object sender, EventArgs e)
        {
            this.EditAttorney(true);
        }

        private void EditAttorney(bool needRevert)
        {
            var properties = new AttorneyProperties();

            properties.AttorneyNumber = xdgvDocs.SelectedItem["Doc"].ToString();
            properties.ReceiverID = Convert.ToInt32(xdgvDocs.SelectedItem["Shan"]);
            properties.PeriodFrom = Convert.ToDateTime(xdgvDocs.SelectedItem["Date_From"]);
            properties.PeriodTo = Convert.ToDateTime(xdgvDocs.SelectedItem["Date_To"]);
            properties.PrintOnInvoice = Convert.ToBoolean(xdgvDocs.SelectedItem["Print_on_nakl"].ToString() == "Y");
            properties.RestrictDaysCount = Convert.ToInt32(xdgvDocs.SelectedItem["Not_print_count_days"]);
            properties.AgreementID = xdgvDocs.SelectedItem["Directum_Doc_ID"] == DBNull.Value ? (long?)null : Convert.ToInt64(xdgvDocs.SelectedItem["Directum_Doc_ID"]);

            if (needRevert)
            {
                if (this.RevertAttorney(ref properties))
                    xdgvDocs.SelectedItem["Date_To"] = properties.PeriodTo;
            }
            else
                this.ModifyAttorney(properties);
        }

        private bool RevertAttorney(ref AttorneyProperties properties)
        {
            var dlgRevertAttorney = new AttorneyRevertSetDateForm() { UserID = this.UserID, AttorneyProperties = properties };
            return dlgRevertAttorney.ShowDialog() == DialogResult.OK;
        }

        private bool ModifyAttorney(AttorneyProperties properties)
        {
            
            var dlgAttorneyRegistration = new AttorneyEditorForm() { UserID = this.UserID, AttorneyProperties = properties };
            return dlgAttorneyRegistration.ShowDialog() == DialogResult.OK;

            //while (true)
            //{
            //    var dlgAttorneyRegistration = new AttorneyRegistrationForm() { UserID = this.UserID };
            //    if (dlgAttorneyRegistration.ShowDialog() != DialogResult.OK)
            //        break;
            //}
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы желаете удалить выбранную доверенность?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                var properties = new AttorneyProperties();

                properties.AttorneyNumber = xdgvDocs.SelectedItem["Doc"].ToString();
                properties.ReceiverID = Convert.ToInt32(xdgvDocs.SelectedItem["Shan"]);

                if (this.DeleteAttorney(properties))
                    this.ReloadData();
            }
        }

        private bool DeleteAttorney(AttorneyProperties properties)
        {
            try
            {
                using (var adapter = new Data.WHTableAdapters.AC_DocsTableAdapter())
                    adapter.Remove(this.UserID, properties.ReceiverID, properties.AttorneyNumber);

                return true;
            }
            catch (Exception ex)
            {
                this.ShowError(ex.Message);
                return false;
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            this.ExportToExcel();
        }

        private void ExportToExcel()
        {
            try
            {
                xdgvDocs.ExportToExcel("Экспорт реестра доверенностей в Excel", "реестр доверенностей", true);   
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }
    }

    /// <summary>
    /// Представление для доверенностей
    /// </summary>
    public class AttorneyView : IDataView
    {
        /// <summary>
        /// Время ожидания выполнения запроса
        /// </summary>
        private const int DEFAULT_RESPONSE_TIMEOUT = 300;

        #region IDataView Members

        private PatternColumnsCollection dataColumns = new PatternColumnsCollection();
        public PatternColumnsCollection Columns
        {
            get { return this.dataColumns; }
        }

        private DataTable data;
        public DataTable Data
        {
            get { return this.data; }
        }

        /// <summary>
        /// Поиск конечной выборки согласно критериям
        /// </summary>
        /// <param name="searchParameters">Критерии поиска</param>
        public void FillData(SearchParametersBase searchParameters)
        {
            var searchCriteria = searchParameters as AttorneySearchParameters;

            using (var adapter = new Data.WHTableAdapters.AC_DocsTableAdapter())
                this.data = adapter.GetData(
                    searchCriteria.SessionID, 
                    searchCriteria.ReceiverID, 
                    Convert.ToInt32(searchCriteria.ShowOnlyActualAttorney), 
                    searchCriteria.WarehouseID,
                    searchCriteria.MainDebtorID);
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ
        public AttorneyView()
        {
            this.dataColumns.Add(new ImagePatternColumn("Влож.", "Has_Attachment") { Width = 40 });

            this.dataColumns.Add(new PatternColumn("№ доверенности", "Doc", new FilterPatternExpressionRule("Doc")) { Width = 120 });
            this.dataColumns.Add(new PatternColumn("Код дебитора", "Shan", new FilterCompareExpressionRule<Int32>("Shan"), SummaryCalculationType.Count) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Наименование дебитора", "Abalph", new FilterPatternExpressionRule("Abalph")) { Width = 260 });
            this.dataColumns.Add(new PatternColumn("Адрес", "adress", new FilterPatternExpressionRule("adress")) { Width = 250 });
            this.dataColumns.Add(new PatternColumn("Город", "city", new FilterPatternExpressionRule("city")) { Width = 200 });

            this.dataColumns.Add(new PatternColumn("Дата с", "Date_From", new FilterDateCompareExpressionRule("Date_From")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Дата по", "Date_To", new FilterDateCompareExpressionRule("Date_To")) { Width = 100 });

            this.dataColumns.Add(new PatternColumn("Печатать на РН", "Print_on_nakl_Flag", new FilterPatternExpressionRule("Print_on_nakl_Flag")) { Width = 60 });
            this.dataColumns.Add(new PatternColumn("Не печатать X дней", "Not_print_count_days", new FilterCompareExpressionRule<Int32>("Not_print_count_days")) { Width = 60 });

            this.dataColumns.Add(new PatternColumn("Пользователь", "User_modified", new FilterPatternExpressionRule("User_modified")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Хост", "Work_Stn", new FilterPatternExpressionRule("Work_Stn")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Дата", "Date_updated", new FilterDateCompareExpressionRule("Date_updated")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Время", "Time_Updated", new FilterPatternExpressionRule("Time_Updated")) { Width = 50 });

            this.dataColumns.Add(new PatternColumn("Код гл. дебитора", "Main_Debtor", new FilterCompareExpressionRule<Int32>("Main_Debtor"), SummaryCalculationType.Count) { Width = 100 });
        }
        #endregion
    }

    /// <summary>
    /// Критерий поиска
    /// </summary>
    public class AttorneySearchParameters : SessionIDSearchParameters
    {
        public string WarehouseID { get; set; }
        public int? ReceiverID { get; set; }
        public int? MainDebtorID { get; set; }
        public bool? ShowOnlyActualAttorney { get; set; }
    }

    /// <summary>
    /// Свойства доверенности
    /// </summary>
    public class AttorneyProperties
    {
        public string AttorneyNumber { get; set; }
        public int? ReceiverID { get; set; }
        public DateTime? PeriodFrom { get; set; }
        public DateTime? PeriodTo { get; set; }
        public bool? PrintOnInvoice { get; set; }
        public int? RestrictDaysCount { get; set; }
        public long? AgreementID { get; set; }
    }
}
