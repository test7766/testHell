using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Dialogs.Quality;
using System.Xml;
using System.Reflection;

namespace WMSOffice.Window
{
    public partial class ImportLicenseWindow : GeneralWindow
    {
        private Data.Quality.QK_LI_LicItemsRow SelectedItem { get { return xdgvDocs.SelectedItem as Data.Quality.QK_LI_LicItemsRow; } }

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

         /// <summary>
        /// Пустое изображение
        /// </summary>
        private static Bitmap emptyIcon = new Bitmap(16, 16);

        /// <summary>
        /// Столбец с информацией о наличии вложенных файлов
        /// </summary>
        private DataGridViewImageColumn dgvcColdType = null;

        public ImportLicenseWindow()
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
            stbVendor.ValueReferenceQuery = "[dbo].[pr_QK_LI_Get_Vendors_List]";
            stbVendor.UserID = this.UserID;
            stbVendor.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stbVendor_OnVerifyValue);

            stbItem.ValueReferenceQuery = "[dbo].[pr_QK_LI_Get_Items_List]";
            stbItem.UserID = this.UserID;
            stbItem.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stbVendor_OnVerifyValue);

            foreach (ImportLicenseAdvancedSearchModes mode in Enum.GetValues(typeof(ImportLicenseAdvancedSearchModes)))
            {
                var key = mode;
                var value = this.GetEnumDescription(mode);

                chbAdvancedSearchModes.Items.Add(new CCBoxItem(value, (long)key), false);
            }
            chbAdvancedSearchModes.SetItemChecked(0, true);

            xdgvDocs.AllowSummary = false;
            xdgvDocs.AllowRangeColumns = true;

            xdgvDocs.UseMultiSelectMode = true;

            xdgvDocs.SetSameStyleForAlternativeRows();

            xdgvDocs.Init(new ImportLicenseView(), true);
            xdgvDocs.LoadExtraDataGridViewSettings(this.Name);

            xdgvDocs.UserID = this.UserID;

            #region ИНИЦИАЛИЗАЦИЯ СТОЛБЦОВ-ИНДИКАТОРОВ

            foreach (DataGridViewColumn column in xdgvDocs.DataGrid.Columns)
            {
                if ((column.Tag ?? string.Empty).Equals("ColdType"))
                    dgvcColdType = column as DataGridViewImageColumn;
            }

            if (dgvcColdType == null)
            {
                this.ShowError("Отсутствует столбец с информацией о наличии температурного режима.");
                return;
            }

            #endregion

            xdgvDocs.OnDataError += new DataGridViewDataErrorEventHandler(xdgvDocs_OnDataError);
            xdgvDocs.OnRowSelectionChanged += new EventHandler(xdgvDocs_OnRowSelectionChanged);
            xdgvDocs.OnDataBindingComplete += new DataGridViewBindingCompleteEventHandler(xdgvDocs_OnDataBindingComplete);
            xdgvDocs.OnFilterChanged += new EventHandler(xdgvDocs_OnFilterChanged);
            xdgvDocs.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvDocs_OnFormattingCell);

            // активация постраничного просмотра
            xdgvDocs.CreatePageNavigator();

            SetOperationAccess();

            this.LoadDocs();
        }

        private string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        void stbVendor_OnVerifyValue(object sender, WMSOffice.Controls.VerifyValueArgs e)
        {
            var control = sender as SearchTextBox;
            TextBox lblDescription = null;

            if (control == stbVendor)
                lblDescription = tbVendor;
            else if (control == stbItem)
                lblDescription = tbItem;

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

        void xdgvDocs_OnRowSelectionChanged(object sender, EventArgs e)
        {
            SetOperationAccess();
        }

        void xdgvDocs_OnDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in xdgvDocs.DataGrid.Rows)
            {
                var boundRow = (xdgvDocs.DataGrid.Rows[row.Index].DataBoundItem as DataRowView).Row as Data.Quality.QK_LI_LicItemsRow;

                //var hasColdType = false;
                object coldTypeValue = emptyIcon;

                if (boundRow.IsColdTypeNull() || string.IsNullOrEmpty(boundRow.ColdType))
                {
                    //row.Cells[dgvcColdType.Index].Value = emptyIcon;
                    xdgvDocs.DataGrid.Rows[row.Index].Cells[dgvcColdType.Index].Value = coldTypeValue;
                }
                else
                {
                    if (boundRow.ColdType == "R")
                    {
                        xdgvDocs.DataGrid.Rows[row.Index].Cells[dgvcColdType.Index].Value = Properties.Resources.snowflakeR;
                        xdgvDocs.DataGrid.Rows[row.Index].Cells[dgvcColdType.Index].ToolTipText = "Признак холода 2-8";

                        //row.Cells[dgvcColdType.Index].Value = Properties.Resources.snowflakeR;
                        //row.Cells[dgvcColdType.Index].ToolTipText = "Признак холода 2-8";
                    }
                    else if (boundRow.ColdType == "B")
                    {
                        xdgvDocs.DataGrid.Rows[row.Index].Cells[dgvcColdType.Index].Value = Properties.Resources.snowflakeB;
                        xdgvDocs.DataGrid.Rows[row.Index].Cells[dgvcColdType.Index].ToolTipText = "Признак холода 8-15";

                        //row.Cells[dgvcColdType.Index].Value = Properties.Resources.snowflakeB;
                        //row.Cells[dgvcColdType.Index].ToolTipText = "Признак холода 8-15";
                    }
                }


                //switch (boundRow.ColdType)
                //{
                //    case 0:
                //        coldTypeValue = Properties.Resources.close;
                //        hasColdType = true;
                //        break;
                //    case 1:
                //        coldTypeValue = Properties.Resources.paperclip1;
                //        hasColdType = true;
                //        break;
                //    case 2:
                //        coldTypeValue = Properties.Resources.paperclip2;
                //        hasColdType = true;
                //        break;
                //    case 3:
                //        coldTypeValue = Properties.Resources.paperclip3;
                //        hasColdType = true;
                //        break;
                //    default:
                //        coldTypeValue = Properties.Resources.paperclipN;
                //        hasColdType = true;
                //        break;
                //}

                //if (hasColdType)
                //    xdgvDocs.DataGrid.Rows[row.Index].Cells[dgvcHasAttachedFiles.Index].Value = coldTypeValue;
            }
        }

        void xdgvDocs_OnFilterChanged(object sender, EventArgs e)
        {
            SetOperationAccess();
            xdgvDocs.RecalculateSummary();
        }
        
        void xdgvDocs_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var doc = (xdgvDocs.DataGrid.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Quality.QK_LI_LicItemsRow;

            var needLicense = doc.IsItemNeedLicenseNull() ? false : doc.ItemNeedLicense;
            var hasLicense = doc.IsItemInLicenseNull() ? false : doc.ItemInLicense;
            var outLicense = doc.IsItemOutLicenseNull() ? false : doc.ItemOutLicense;
            var notInUsage = doc.IsItemNotInUsageNull() ? false : doc.ItemNotInUsage;
            var isVendorChanged = doc.IsIsVendorChangedNull() ? false : doc.IsVendorChanged;

            if (notInUsage)
                e.CellStyle.BackColor = e.CellStyle.SelectionForeColor = Color.LightGray;
            else if (outLicense)
                e.CellStyle.BackColor = e.CellStyle.SelectionForeColor = Color.LightPink;
            else if (hasLicense)
                e.CellStyle.BackColor = e.CellStyle.SelectionForeColor = Color.LightGreen;
            else if (needLicense)
            {
                e.CellStyle.BackColor = e.CellStyle.SelectionForeColor = Color.Khaki;

                if (isVendorChanged && xdgvDocs.DataGrid.Columns[e.ColumnIndex].DataPropertyName == "VendorName")
                    e.CellStyle.BackColor = e.CellStyle.SelectionForeColor = Color.Orange;
                    //e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
            }

            //else
            //{
            //    var statusID = doc.QK_LI_Status_ID;
            //    switch (statusID)
            //    {
            //        case 300:
            //            e.CellStyle.BackColor = e.CellStyle.SelectionForeColor = Color.LightGreen;
            //            break;
            //        case 400:
            //            e.CellStyle.BackColor = e.CellStyle.SelectionForeColor = Color.LightGray;
            //            break;
            //        default:
            //            break;
            //    }
            //}

            //var canLink = doc.Can_link;
            //if (canLink)
            //    e.CellStyle.ForeColor = Color.Brown;
        }

        private void SetOperationAccess()
        {
            try
            {
                var isEnabled = this.SelectedItem != null;
                
                btnShowItemDocs.Enabled = isEnabled;
                btnRequestDocsFromPurchaseDepartment.Enabled = isEnabled;

                btnLinkItem.Enabled = isEnabled && this.SelectedItem.QK_LI_Status_ID == 100 && this.SelectedItem.Can_link;
                btnAddToLicense.Enabled = isEnabled;
                btnDeleteFromLicense.Enabled = isEnabled;
                btnDeleteFromUsage.Enabled = isEnabled;

                btnExportToExcel.Enabled = xdgvDocs.HasRows;
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
                this.LoadDocs();
                return true;
            }

            if (keyData == (Keys.F3))
            {
                this.ShowItemDocs();
                return true;
            }

            if (keyData == (Keys.Control | Keys.Q))
            {
                this.RequestDocsFromPurchaseDepartment();
                return true;
            }

            //if (keyData == (Keys.Control | Keys.L))
            //{
            //    this.LinkItem();
            //    return true;
            //}

            if (keyData == (Keys.Control | Keys.Insert))
            {
                this.AddToLicense();
                return true;
            }

            if (keyData == (Keys.Control | Keys.Delete))
            {
                this.DeleteFromLicense();
                return true;
            }

            if (keyData == (Keys.Control | Keys.Shift | Keys.Delete))
            {
                this.DeleteFromUsage();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.LoadDocs();
        }

        private void LoadDocs()
        {
            try
            {
                var searchParams = new ImportLicenseSearchParameters() { SessionID = this.UserID };


                if (!string.IsNullOrEmpty(stbVendor.Value))
                {
                    int vendorID;
                    if (!int.TryParse(stbVendor.Value, out vendorID))
                        throw new Exception("Код поставщика должен быть числом.");
                    else
                        searchParams.VendorID = vendorID;
                }


                if (!string.IsNullOrEmpty(stbItem.Value))
                {
                    int itemID;
                    if (!int.TryParse(stbItem.Value, out itemID))
                        throw new Exception("Код товара должен быть числом.");
                    else
                        searchParams.ItemID = itemID;
                }


                foreach (CCBoxItem item in chbAdvancedSearchModes.CheckedItems)
                {
                    var mode = (ImportLicenseAdvancedSearchModes)item.Value;

                    switch (mode)
                    {
                        case ImportLicenseAdvancedSearchModes.ItemNeedLicense:
                            searchParams.OnlyNeedLicense = true;
                            break;
                        case ImportLicenseAdvancedSearchModes.ItemInLicense:
                            searchParams.OnlyInLicense = true;
                            break;
                        case ImportLicenseAdvancedSearchModes.ItemOutLicense:
                            searchParams.OnlyOutLicense = true;
                            break;
                        case ImportLicenseAdvancedSearchModes.ItemNotInUsage:
                            searchParams.OnlyNotInUsage = true;
                            break;
                        default:
                            break;
                    }
                }

                //// Запоминаем фокус
                //selectedDocID = this.SelectedDoc == null ? 0 : SelectedDoc.ActID;

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    try
                    {
                        this.xdgvDocs.DataView.FillData(e.Argument as ImportLicenseSearchParameters);
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
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

                splashForm.ActionText = "Выполняется получение списка лицензий на импорт..";
                bw.RunWorkerAsync(searchParams);
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
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
                xdgvDocs.ExportToExcel("Экспорт списка лицензий на импорт в Excel", "лицензии на импорт", true);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnShowItemDocs_Click(object sender, EventArgs e)
        {
            this.ShowItemDocs();
        }

        private void ShowItemDocs()
        {
            try
            {
                if (!btnShowItemDocs.Enabled)
                    return;

                var dlgImportLicenseItemDocs = new ImportLicenseItemDocsForm(xdgvDocs.SelectedItem as Data.Quality.QK_LI_LicItemsRow) { UserID = this.UserID };
                if (dlgImportLicenseItemDocs.ShowDialog() == DialogResult.OK)
                { 
                
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnRequestDocsFromPurchaseDepartment_Click(object sender, EventArgs e)
        {
            this.RequestDocsFromPurchaseDepartment();
        }

        private void RequestDocsFromPurchaseDepartment()
        {
            try
            {
                if (!btnRequestDocsFromPurchaseDepartment.Enabled)
                    return;

                var lstSelectedItems = new List<Data.Quality.QK_LI_LicItemsRow>();

                foreach (Data.Quality.QK_LI_LicItemsRow item in xdgvDocs.SelectedItems)
                {
                    //var mozTaskID = item.IsMOZTaskIDNull() ? (int?)null : item.MOZTaskID;

                    //if (mozTaskID.HasValue)
                    //    throw new Exception("Среди выбранных строк есть товары с незавершенными заданиями у МОЗ.\n\nСоздать новое задание на актуализацию документов невозможно.");

                    var vendorTaskID = item.IsVendorTaskIDNull() ? (int?)null : item.VendorTaskID;

                    if (vendorTaskID.HasValue)
                        throw new Exception("Среди выбранных строк есть товары с незавершенными заданиями в кабинете у поставщика.\n\nСоздать новое задание на актуализацию документов невозможно.");
                    
                    lstSelectedItems.Add(item as Data.Quality.QK_LI_LicItemsRow);
                }

                //var selectedItem = xdgvDocs.SelectedItem as Data.Quality.QK_LI_LicItemsRow;

                //var mozTaskID = selectedItem.IsMOZTaskIDNull() ? (int?)null : selectedItem.MOZTaskID;

                //if (mozTaskID.HasValue)
                //    throw new Exception(string.Format("Задание № {0} на получение документов\nнаходится в работе у МОЗ. Ожидайте!", mozTaskID.Value));

                var dlgImportLicenseItemRequestDocsFromPurchaseDepartment = new ImportLicenseItemRequestDocsFromPurchaseDepartmentForm(lstSelectedItems) { UserID = this.UserID };
                if (dlgImportLicenseItemRequestDocsFromPurchaseDepartment.ShowDialog() == DialogResult.OK)
                {

                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnLinkItem_Click(object sender, EventArgs e)
        {
            this.LinkItem();
        }

        private void LinkItem()
        {
            try
            {
                if (!btnLinkItem.Enabled)
                    return;

                var item = xdgvDocs.SelectedItem as Data.Quality.QK_LI_LicItemsRow;

                var dlgItemSelector = new SearchTextBoxSelector("[dbo].[pr_QK_LI_LicItem_Items_To_Link]",
                    new List<ReferencedObject>(new ReferencedObject[] 
                    {
                        new ReferencedObject { Value = item.ItemID }
                    }),
                    new List<string>(new string[] 
                    { 
                        "AI_ID"
                    }));

                dlgItemSelector.UserID = UserID;
                
                if (dlgItemSelector.ShowDialog() != DialogResult.OK)
                    return;

                var itemToLinkWith = dlgItemSelector.SelectedItem;
                var itemToLinkWithID = Convert.ToInt32(itemToLinkWith["AI_ID"]);

                using (var adapter = new Data.QualityTableAdapters.QK_LI_LicItemsTableAdapter())
                    adapter.LinkItem(this.UserID, item.ItemID, itemToLinkWithID);

                this.LoadDocs();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnAddToLicense_Click(object sender, EventArgs e)
        {
            this.AddToLicense();
        }

        private void AddToLicense()
        {
            try
            {
                if (!btnAddToLicense.Enabled)
                    return;

                if (MessageBox.Show("Вы действительно хотите добавить\nвыбранные товары в Лицензию?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                    return;

                //var sbItems = new StringBuilder();
                //foreach (Data.Quality.QK_LI_LicItemsRow item in xdgvDocs.SelectedItems)
                //{
                //    var hasLicense = item.IsItemInLicenseNull() ? false : item.ItemInLicense;
                //    if (hasLicense)
                //        continue;

                //    if (sbItems.Length > 0)
                //        sbItems.AppendFormat(",{0}", item.ItemID);
                //    else
                //        sbItems.AppendFormat("{0}", item.ItemID);
                //}

                //if (sbItems.Length == 0)
                //    throw new Exception("Выбранные товары уже есть в Лицензии.");

                var xItems = this.CreateItemsXML(item => !(item.IsItemInLicenseNull() ? false : item.ItemInLicense) && !(item.IsItemOutLicenseNull() ? false : item.ItemOutLicense) && !(item.IsItemNotInUsageNull() ? false : item.ItemNotInUsage));

                if (xItems.DocumentElement.ChildNodes.Count == 0)
                    throw new Exception("Среди выбранных товаров нет подходящих для добавления в Лицензию.");

                var dlgImportLicenseSetConclusionDate = new ImportLicenseSetConclusionDateForm(true);
                if (dlgImportLicenseSetConclusionDate.ShowDialog() != DialogResult.OK)
                    return;

                using (var adapter = new Data.QualityTableAdapters.QK_LI_LicItemsTableAdapter())
                    adapter.AddToLicense(this.UserID, xItems.InnerXml, dlgImportLicenseSetConclusionDate.ConclusionDate);

                this.LoadDocs();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnDeleteFromLicense_Click(object sender, EventArgs e)
        {
            this.DeleteFromLicense();
        }

        private void DeleteFromLicense()
        {
            try
            {
                if (!btnDeleteFromLicense.Enabled)
                    return;

                if (MessageBox.Show("Вы действительно хотите исключить\nвыбранные товары из Лицензии?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                    return;

                var xItems = this.CreateItemsXML(item => !(item.IsItemOutLicenseNull() ? false : item.ItemOutLicense) && !(item.IsItemNotInUsageNull() ? false : item.ItemNotInUsage));

                if (xItems.DocumentElement.ChildNodes.Count == 0)
                    throw new Exception("Среди выбранных товаров нет подходящих для исключения из Лицензии.");

                var dlgImportLicenseSetConclusionDate = new ImportLicenseSetConclusionDateForm(false);
                if (dlgImportLicenseSetConclusionDate.ShowDialog() != DialogResult.OK)
                    return;

                using (var adapter = new Data.QualityTableAdapters.QK_LI_LicItemsTableAdapter())
                    adapter.DeleteFromLicense(this.UserID, xItems.InnerXml, dlgImportLicenseSetConclusionDate.ConclusionDate);

                this.LoadDocs();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnDeleteFromUsage_Click(object sender, EventArgs e)
        {
            this.DeleteFromUsage();
        }

        private void DeleteFromUsage()
        {
            try
            {
                if (!btnDeleteFromUsage.Enabled)
                    return;

                if (MessageBox.Show("Вы действительно хотите сделать неактуальными\nвыбранные товары?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                    return;

                var xItems = this.CreateItemsXML(item => !(item.IsItemNotInUsageNull() ? false : item.ItemNotInUsage) && !(item.IsItemInLicenseNull() ? false : item.ItemInLicense));

                if (xItems.DocumentElement.ChildNodes.Count == 0)
                    throw new Exception("Среди выбранных товаров нет подходящих для исключения из актуальных.");

                using (var adapter = new Data.QualityTableAdapters.QK_LI_LicItemsTableAdapter())
                    adapter.DeleteFromUsage(this.UserID, xItems.InnerXml);

                this.LoadDocs();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private XmlDocument CreateItemsXML(CheckItem checkItem)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml("<Items></Items>");
            XmlElement xRoot = xDoc.DocumentElement;

            XmlAttribute xValue = null;

            foreach (Data.Quality.QK_LI_LicItemsRow item in xdgvDocs.SelectedItems)
            {
                if (!checkItem(item))
                    continue;

                var xItemElement = xDoc.CreateElement("Item");

                xValue = xItemElement.Attributes.Append(xDoc.CreateAttribute("item_id"));
                xValue.Value = item.ItemID.ToString();

                xValue = xItemElement.Attributes.Append(xDoc.CreateAttribute("manufacturer_id"));
                xValue.Value = item.ManufacturerID.ToString();

                xRoot.AppendChild(xItemElement);
            }

            return xDoc;
        }

        delegate bool CheckItem(Data.Quality.QK_LI_LicItemsRow item);
    }

    public enum ImportLicenseAdvancedSearchModes
    {
        /// <summary>
        /// Товары требующие Лицензию
        /// </summary>
        [Description("Товары требующие Лицензию")]
        ItemNeedLicense = 0,

        /// <summary>
        /// Товары в Лицензии
        /// </summary>
        [Description("Товары в Лицензии")]
        ItemInLicense = 1,

        /// <summary>
        /// Товары изъятые из Лицензии
        /// </summary>
        [Description("Товары изъятые из Лицензии")]
        ItemOutLicense = 2,

        /// <summary>
        /// Неактуальные товары
        /// </summary>
        [Description("Неактуальные товары")]
        ItemNotInUsage = 3
    }

    /// <summary>
    /// Представление для лицензий на импорт
    /// </summary>
    public class ImportLicenseView : IDataView
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

        public void FillData(SearchParametersBase searchParameters)
        {
            var searchCriteria = searchParameters as ImportLicenseSearchParameters;

            var sessionID = searchCriteria.SessionID;
            var vendorID = searchCriteria.VendorID;
            var itemID = searchCriteria.ItemID;

            var onlyNeedLicense = searchCriteria.OnlyNeedLicense;
            var onlyInLicense = searchCriteria.OnlyInLicense;
            var onlyOutLicense = searchCriteria.OnlyOutLicense;
            var onlyNotInUsage = searchCriteria.OnlyNotInUsage; 

            using (var adapter = new Data.QualityTableAdapters.QK_LI_LicItemsTableAdapter())
            {
                adapter.SetTimeout(DEFAULT_RESPONSE_TIMEOUT);
                data = adapter.GetData(sessionID, vendorID, itemID, onlyNeedLicense, onlyInLicense, onlyOutLicense, onlyNotInUsage);
            }
        }

        #endregion

        public ImportLicenseView()
        {
            this.dataColumns.Add(new ImagePatternColumn(string.Empty, "ColdType") { Width = 22 });

            this.dataColumns.Add(new PatternColumn("Код", "ItemID", new FilterCompareExpressionRule<Int32>("ItemID"), SummaryCalculationType.TotalRecords) { Width = 60 });
            this.dataColumns.Add(new PatternColumn("Наименование товара", "ItemName", new FilterPatternExpressionRule("ItemName")) { Width = 200 });
            //this.dataColumns.Add(new PatternColumn("Форма выпуска", "ReleaseForm", new FilterPatternExpressionRule("ReleaseForm")) { Width = 120 });
            //this.dataColumns.Add(new PatternColumn("Дозировка", "Dosage", new FilterPatternExpressionRule("Dosage")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Количество в упаковке", "QtyPack", new FilterPatternExpressionRule("QtyPack")) { Width = 200 });

            this.dataColumns.Add(new PatternColumn("МНН", "MNN", new FilterPatternExpressionRule("MNN")) { Width = 120 });
            this.dataColumns.Add(new PatternColumn("Номер РС в Украине", "NoReg", new FilterPatternExpressionRule("NoReg")) { Width = 120 });
            this.dataColumns.Add(new PatternColumn("Код АТС", "AtcCode", new FilterPatternExpressionRule("AtcCode")) { Width = 100 });

            this.dataColumns.Add(new PatternColumn("Производитель", "ManufacturerName", new FilterPatternExpressionRule("ManufacturerName")) { Width = 150 });
            this.dataColumns.Add(new PatternColumn("Страна производителя", "ManufacturerCountry", new FilterPatternExpressionRule("ManufacturerCountry")) { Width = 120 });

            this.dataColumns.Add(new PatternColumn("Поставщик", "VendorName", new FilterPatternExpressionRule("VendorName"), SummaryCalculationType.Count) { Width = 150 });
            this.dataColumns.Add(new PatternColumn("Страна поставщика", "VendorCountry", new FilterPatternExpressionRule("VendorCountry")) { Width = 120 });
            this.dataColumns.Add(new PatternColumn("Адрес поставщика", "VendorAddress", new FilterPatternExpressionRule("VendorAddress")) { Width = 120 });

            this.dataColumns.Add(new PatternColumn("Срок действия РС в Украине", "DateEndReg", new FilterDateCompareExpressionRule("DateEndReg")) { Width = 120 });

            this.dataColumns.Add(new PatternColumn("GMP", "GMP", new FilterPatternExpressionRule("GMP")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Срок действия GMP", "GMPDateTo", new FilterDateCompareExpressionRule("GMPDateTo")) { Width = 120 });

            this.dataColumns.Add(new PatternColumn("Дата создания кода товара", "ItemCreateDate", new FilterDateCompareExpressionRule("ItemCreateDate")) { Width = 120 });

            this.dataColumns.Add(new PatternColumn("Дата добавления в Лицензию", "ItemInLicenseFrom", new FilterDateCompareExpressionRule("ItemInLicenseFrom")) { Width = 120 });
            this.dataColumns.Add(new PatternColumn("Дата исключения из Лицензии", "ItemOutLicenseFrom", new FilterDateCompareExpressionRule("ItemOutLicenseFrom")) { Width = 120 });

            //this.dataColumns.Add(new PatternColumn("№ уведомления", "QK_LI_No", new FilterPatternExpressionRule("QK_LI_No"), SummaryCalculationType.Count) { Width = 110 });
            //this.dataColumns.Add(new PatternColumn("Дата уведомления", "QK_LI_Date", new FilterDateCompareExpressionRule("QK_LI_Date"), SummaryCalculationType.Count) { Width = 120 });
            //this.dataColumns.Add(new PatternColumn("Статус товара в лицензии", "QK_LI_Status_ID", new FilterCompareExpressionRule<Int32>("QK_LI_Status_ID")) { Width = 120 });
            //this.dataColumns.Add(new PatternColumn("Примечание", "QK_LI_Memo", new FilterPatternExpressionRule("QK_LI_Memo")) { Width = 120 });

            //this.dataColumns.Add(new PatternColumn("№ задания МОЗ", "MOZTaskID", new FilterCompareExpressionRule<Int32>("MOZTaskID"), SummaryCalculationType.Count) { Width = 90 });
            this.dataColumns.Add(new PatternColumn("№ задания поставщика", "VendorTaskID", new FilterCompareExpressionRule<Int32>("VendorTaskID"), SummaryCalculationType.Count) { Width = 90 });
        }
    }

    /// <summary>
    /// Критерий поиска
    /// </summary>
    public class ImportLicenseSearchParameters : SessionIDSearchParameters
    {
        public int? VendorID { get; set; }
        public int? ItemID { get; set; }

        public bool? OnlyNeedLicense { get; set; }
        public bool? OnlyInLicense { get; set; }
        public bool? OnlyOutLicense { get; set; }
        public bool? OnlyNotInUsage { get; set; }
    }
}
