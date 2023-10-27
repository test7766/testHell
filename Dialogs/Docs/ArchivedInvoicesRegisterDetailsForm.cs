using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.ExtraDataGridViewComponents;

namespace WMSOffice.Dialogs.Docs
{
    public partial class ArchivedInvoicesRegisterDetailsForm : DialogForm
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        public long RegisterID { get; set; }

        public ArchivedInvoicesRegisterDetailsForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Initialize();

            this.Text = string.Format("{0} № {1}", this.Text, this.RegisterID);

            this.btnOK.Location = new Point(967, 8);
            this.btnCancel.Location = new Point(1057, 8);

            this.btnOK.Visible = false;
            this.btnCancel.Text = "Закрыть";
        }

        private void Initialize()
        {
            xdgvRegistryDetails.AllowSummary = false;

            xdgvRegistryDetails.Init(new ArchivedInvoicesRegisterDetailsView(), true);
            xdgvRegistryDetails.UserID = this.UserID;

            xdgvRegistryDetails.OnDataError += new DataGridViewDataErrorEventHandler(xdgvRegistryDetails_OnDataError);
            xdgvRegistryDetails.OnRowSelectionChanged += new EventHandler(xdgvRegistryDetails_OnRowSelectionChanged);
            xdgvRegistryDetails.OnFilterChanged += new EventHandler(xdgvRegistryDetails_OnFilterChanged);
            xdgvRegistryDetails.OnDataBindingComplete += new DataGridViewBindingCompleteEventHandler(xdgvRegistryDetails_OnDataBindingComplete);

            // активация постраничного просмотра
            xdgvRegistryDetails.CreatePageNavigator();

            this.ReloadData();

            this.SetOperationAccess();
        }

        private void SetOperationAccess()
        {
            
        }


        void xdgvRegistryDetails_OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        void xdgvRegistryDetails_OnRowSelectionChanged(object sender, EventArgs e)
        {
            this.SetOperationAccess();
        }

        void xdgvRegistryDetails_OnFilterChanged(object sender, EventArgs e)
        {
            this.SetOperationAccess();
            xdgvRegistryDetails.RecalculateSummary();
        }

        /// <summary>
        /// Пустое изображение
        /// </summary>
        private static Bitmap emptyIcon = new Bitmap(16, 16);

        void xdgvRegistryDetails_OnDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in xdgvRegistryDetails.DataGrid.Rows)
            {
                var boundRow = (xdgvRegistryDetails.DataGrid.Rows[row.Index].DataBoundItem as DataRowView).Row;

                foreach (DataGridViewColumn column in xdgvRegistryDetails.DataGrid.Columns)
                {
                    #region ПОДСТАНОВКА ИКОНОК ПО НАЛИЧИЮ ВЛОЖЕНИЙ СКАН-КОПИЙ

                    if (column is DataGridViewImageColumn)
                    {
                        if (column.Tag != null)
                        {
                            string linkedFieldName = column.Tag.ToString();
                            if (linkedFieldName == "Scan")
                            {
                                var hasAttachment = Convert.ToBoolean(boundRow[linkedFieldName]);

                                if (hasAttachment)
                                    xdgvRegistryDetails.DataGrid.Rows[row.Index].Cells[column.Index].Value = Properties.Resources.pin;
                                else
                                    xdgvRegistryDetails.DataGrid.Rows[row.Index].Cells[column.Index].Value = emptyIcon;
                            }
                        }
                    }

                    #endregion
                }
            }

            if (xdgvRegistryDetails.DataGrid.Rows.Count > 0)
                xdgvRegistryDetails.DataGrid.Rows[0].Selected = false;
        }

        private void ReloadData()
        {
            try
            {
                var searchParams = new ArchivedInvoicesRegisterDetailsSearchParameters() { SessionID = this.UserID };
                searchParams.RegisterID = this.RegisterID;

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    try
                    {
                        this.xdgvRegistryDetails.DataView.FillData(e.Argument as ArchivedInvoicesRegisterDetailsSearchParameters);
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                bw.RunWorkerCompleted += (s, e) =>
                {
                    if (e.Result is Exception)
                         MessageBox.Show((e.Result as Exception).Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        this.xdgvRegistryDetails.BindData(false);

                        //this.xdgvRegistry.AllowFilter = true;
                        this.xdgvRegistryDetails.AllowSummary = true;
                    }

                    splashForm.CloseForce();
                };

                splashForm.ActionText = "Виконується завантаження деталей реєстру..";
                bw.RunWorkerAsync(searchParams);
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    /// <summary>
    /// Представление для деталей реестра архивных накладных
    /// </summary>
    public class ArchivedInvoicesRegisterDetailsView : IDataView
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
            var searchCriteria = searchParameters as ArchivedInvoicesRegisterDetailsSearchParameters;

            using (var adapter = new Data.WHTableAdapters.RG_Register_DetailsTableAdapter())
            {
                adapter.SetTimeout(DEFAULT_RESPONSE_TIMEOUT);

                this.data = adapter.GetData(searchCriteria.SessionID, searchCriteria.RegisterID);
            }
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ
        public ArchivedInvoicesRegisterDetailsView()
        {
            this.dataColumns.Add(new ImagePatternColumn("Скан", "Scan") { Width = 40 });

            this.dataColumns.Add(new PatternColumn("Номер документа", "DocID", new FilterPatternExpressionRule("DocID"), SummaryCalculationType.TotalRecords) { Width = 125 });
            this.dataColumns.Add(new PatternColumn("Дата документа", "DocDate", new FilterDateCompareExpressionRule("DocDate")) { Width = 120 });

            this.dataColumns.Add(new PatternColumn("Тип документа", "DocType", new FilterPatternExpressionRule("DocType"), SummaryCalculationType.Count) { Width = 120 });
            this.dataColumns.Add(new PatternColumn("Опис типу", "DocTypeDesc", new FilterPatternExpressionRule("DocTypeDesc")) { Width = 150 });

            this.dataColumns.Add(new PatternColumn("Філіал", "Filial", new FilterPatternExpressionRule("Filial"), SummaryCalculationType.Count) { Width = 150 });

            this.dataColumns.Add(new PatternColumn("Код дебітора", "DebtorID", new FilterCompareExpressionRule<Int32>("DebtorID"), SummaryCalculationType.Count) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Назва дебітора", "DebtorName", new FilterPatternExpressionRule("DebtorName")) { Width = 150 });
            this.dataColumns.Add(new PatternColumn("ЄДРПОУ дебітора", "OKPO", new FilterCompareExpressionRule<Int32>("OKPO"), SummaryCalculationType.Count) { Width = 125 });

            this.dataColumns.Add(new PatternColumn("Код ТТ", "DeliveryID", new FilterCompareExpressionRule<Int32>("DeliveryID"), SummaryCalculationType.Count) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Торговий менеджер", "Manager", new FilterPatternExpressionRule("Manager")) { Width = 150 });

            this.dataColumns.Add(new PatternColumn("Код статусу", "StatusID", new FilterCompareExpressionRule<Int32>("StatusID"), SummaryCalculationType.Count) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Назва статусу", "StatusDesc", new FilterPatternExpressionRule("StatusDesc")) { Width = 150 });

            this.dataColumns.Add(new PatternColumn("Час реєстрації", "DateReg", new FilterDateCompareExpressionRule("DateReg")) { Width = 110 });
            this.dataColumns.Add(new PatternColumn("Місцезнаходження", "Location", new FilterPatternExpressionRule("Location")) { Width = 150 });
        }
        #endregion
    }

    /// <summary>
    /// Критерий поиска
    /// </summary>
    public class ArchivedInvoicesRegisterDetailsSearchParameters : SessionIDSearchParameters
    {
        public long RegisterID { get; set; }
    }
}
