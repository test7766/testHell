using System;
using System.Windows.Forms;

using WMSOffice.Data.ComplaintsTableAdapters;
using WMSOffice.Properties;
using System.Drawing;

namespace WMSOffice.Dialogs.Complaints
{
    /// <summary>
    /// Форма для вывода истории визирования по отдельной строке претензии
    /// </summary>
    public partial class ComplaintItemHistoryForm : DialogForm
    {
        /// <summary>
        /// Признак отображения блока "Автор версии ОК"
        /// </summary>
        public bool IsUserOKVisible { get; set; }

        #region АТРИБУТЫ

        /// <summary>
        /// Идентификатор документа
        /// </summary>
        private long _docId;

        /// <summary>
        /// Идентификатор сессии
        /// </summary>
        private long _sessionId;

        /// <summary>
        /// Идентификатор строки визирования
        /// </summary>
        private long _detailId;

        /// <summary>
        /// Признак возможности изменить фактическую серию
        /// </summary>
        private bool _canChangeFactLotn;

        #endregion

        #region КОНСТРУКТОРЫ

        public ComplaintItemHistoryForm()
        {
            InitializeComponent();
        }

        public ComplaintItemHistoryForm(long pDocId, long pSessionId, long pDetailId, bool pCanChangeFactLotn)
            : this()
        {
            _docId = pDocId;
            _sessionId = pSessionId;
            _detailId = pDetailId;
            _canChangeFactLotn = pCanChangeFactLotn;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Initialize();

            if (!_canChangeFactLotn)
            {
                tbVendorLotFact.BorderStyle = BorderStyle.None;
                tbVendorLotFact.ReadOnly = true;
                tbVendorLotFact.BackColor = SystemColors.Control;

                btnOK.Visible = false;
                btnCancel.Text = "Закрыть";

                btnCancel.Focus();
            }
            else
            {
                tbVendorLotFact.KeyDown += new KeyEventHandler(tbVendorLotFact_KeyDown);
            }

            tbVendorLotFact.Location = new Point(tbVendorLotFact.Location.X, (lblVendorLotFactHeader.Top + (lblVendorLotFactHeader.Height - lblVendorLotFactHeader.Top) / 2) - ((tbVendorLotFact.Height - tbVendorLotFact.Top) / 2));

            this.btnOK.Location = new Point(761, 8);
            this.btnCancel.Location = new Point(851, 8);
        }

        private void Initialize()
        {
            try
            {
                InitFormHeader();
                FillListViewInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
        }

        /// <summary>
        /// Инициализация заголовка строки претензии
        /// </summary>
        private void InitFormHeader()
        {
            using (StagesDetailsTitleTableAdapter adapter = new StagesDetailsTitleTableAdapter())
            {
                Data.Complaints.StagesDetailsTitleDataTable titleTable = adapter.GetData(_sessionId, _docId, _detailId);
                if (titleTable == null || titleTable.Rows.Count == 0)
                    throw new Exception(string.Format("Неизвестный заголовок товара в претензии!\r\nПозовите кого-нибудь на помощь!!!"));

                // Заполняем текстовые метки заголовка
                Data.Complaints.StagesDetailsTitleRow titleRow = titleTable[0];
                lblItemId.Text = titleRow.IsItem_IDNull() ? "" : titleRow.Item_ID.ToString();
                lblItemName.Text = titleRow.IsItem_nameNull() ? "" : titleRow.Item_name;
                lblManufacturer.Text = titleRow.IsManufacturerNull() ? "" : titleRow.Manufacturer;
                lblVendor.Text = titleRow.IsVendorNull() ? "" : titleRow.Vendor;
                lblManagerVendor.Text = titleRow.IsManager_VendorNull() ? "" : titleRow.Manager_Vendor;
                lblVendorLot.Text = titleRow.IsVendor_LotNull() ? "" : titleRow.Vendor_Lot;
                lblLotNumber.Text = titleRow.IsLot_NumberNull() ? "" : titleRow.Lot_Number;
                tbVendorLotFact.Text = titleRow.IsVendor_Lot_FactNull() ? "" : titleRow.Vendor_Lot_Fact;
                lblExpirationDate.Text = titleRow.IsExpiration_DateNull() ? "" : titleRow.Expiration_Date.ToShortDateString();

                lblUserOKHeader.Visible = lblUserOK.Visible = this.IsUserOKVisible;
                lblUserOK.Text = titleRow.IsOK_UserNull() ? "" : titleRow.OK_User;
            }
        }

        /// <summary>
        /// Заполняет ListView, выполняя запрос к базе
        /// </summary>
        public void FillListViewInfo()
        {
            using (StagesDetailsHistoryCurrentItemTableAdapter adapter = new StagesDetailsHistoryCurrentItemTableAdapter())
            {
                Data.Complaints.StagesDetailsHistoryCurrentItemDataTable table = adapter.GetData(_sessionId, _docId, _detailId);
                
                // Заполняем строки ListView
                foreach (Data.Complaints.StagesDetailsHistoryCurrentItemRow row in table.Rows)
                {
                    int imageIndex = row.IsStage_Result_IDNull() ? 4 : GetImageIndexByStageResultId(row.Stage_Result_ID);

                    ListViewItem newItem = new ListViewItem(new string[] {
                        "",
                        row.IsGroup_NameNull() ? "-" : row.Group_Name,
                        row.IsStage_Result_NameNull() ? "-" : row.Stage_Result_Name,
                        row.IsCommentNull() ? "-" : row.Comment,
                        row.IsExpiration_DateNull() ? "-" : row.Expiration_Date.ToString("dd.MM.yyy HH:mm:ss"),
                        row.IsUsers_UpdatedNull() ? "-" : row.Users_Updated,
                        row.IsDate_UpdatedNull() ? "-" : row.Date_Updated.ToString("dd.MM.yyy HH:mm:ss"),
                        
                    }, imageIndex);
                    lsvStages.Items.Add(newItem);
                }
            }
        }

        /// <summary>
        /// Получает индекс нужной пиктограммы по результату визирования
        /// </summary>
        /// <param name="pStageResultId"></param>
        /// <returns></returns>
        private static int GetImageIndexByStageResultId(long pStageResultId)
        {
            if (pStageResultId == 2 || pStageResultId == 4) // Отрицательная виза
                return 0;
            if (pStageResultId == 1 || pStageResultId == 5) // Положительная виза
                return 1;
            if (pStageResultId == 8) // Нужна виза
                return 3;

            return 4; // Результат этапа не определен
        }

        #endregion

        void tbVendorLotFact_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.DialogResult = DialogResult.OK;
        }

        private void ComplaintItemHistoryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveData();
        }

        private bool SaveData()
        {
            try
            {
                if (string.IsNullOrEmpty(tbVendorLotFact.Text))
                    throw new Exception("Фактическая серия должна быть указана.");

                var result = (int?)null;
                using (var adapter = new StagesDetailsTableAdapter())
                    adapter.ChangeVendorLotFact(_sessionId, _docId, _detailId, tbVendorLotFact.Text, ref result);

                var needChangeDocType = (result ?? 0) == 0;
                if (needChangeDocType)
                {
                    if (MessageBox.Show("Серии нет в базе.\n\nХотите изменить тип претензии на\nВозврат «Ошибка отдела качества»?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        using (var adapter = new StagesDetailsTableAdapter())
                            adapter.ChangeDocTypeVendorLotFact(_docId, _sessionId);
                    }
                    else
                        return false;
                }

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
