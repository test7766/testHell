using System;
using System.Windows.Forms;

using WMSOffice.Data.ReceiveTableAdapters;

namespace WMSOffice.Dialogs.Receive
{
    /// <summary>
    /// Окно для отбора образцов по одному товару
    /// </summary>
    public partial class SamplingForm : Form
    {
        #region ПЕРЕМЕННЫЕ И СВОЙСТВА

        /// <summary>
        /// Идентификатор
        /// </summary>
        private int itemID;

        /// <summary>
        /// Идентификатор выбранного товара
        /// </summary>
        public int SelectedItemID { get; private set; }

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private int sessionID;

        /// <summary>
        /// Идентификатор задания на отбор образцов
        /// </summary>
        private long docID;

        /// <summary>
        /// Количество образцов для отбора
        /// </summary>
        private double quantity;

        /// <summary>
        /// Штрих-код отсканированного товара
        /// </summary>
        public string ItemBarcode { get; private set; }

        /// <summary>
        /// Штрих-код отсканированной этикетки образца
        /// </summary>
        public string SampleBarcode { get; private set; }

        /// <summary>
        /// Штрих-код корзины
        /// </summary>
        public string BasketBarcode { get; private set; }

        public LotnReceiptMode ReceiptMode { get; set; }

        #endregion

        #region КОНСТРУКТОР

        public SamplingForm(int pItemID, string pItemName, long pDocID, double pQuantity, int pSessionID)
        {
            InitializeComponent();
            itemID = pItemID;
            sessionID = pSessionID;
            docID = pDocID;
            quantity = pQuantity;
            lblScanItemCode.Text = String.Format("Отсканируйте товар {0}:", pItemName);
            lblQuantity.Text = quantity.ToString();
            tbsSampleCode.TextChanged += new EventHandler(tbsSampleCode_TextChanged);

            ItemPanelSetActive();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (ReceiptMode == LotnReceiptMode.PrintYL)
            {
                pnlSample.Visible = false;
                this.Height -= pnlSample.Height;
            }
        }

        private void ItemPanelSetActive()
        {
            pnlSample.Enabled = false;
            pnlBasket.Enabled = false;

            pnlItem.Enabled = true;
            tbsItemCode.SelectAll();
            tbsItemCode.Focus();
        }

        private void SamplePanelSetActive()
        {
            pnlItem.Enabled = false;
            pnlBasket.Enabled = false;

            pnlSample.Enabled = true;
            tbsSampleCode.Focus();
        }

        private void BasketPanelSetActive()
        {
            pnlItem.Enabled = false;
            pnlSample.Enabled = false;

            pnlBasket.Enabled = true;
            tbsBasketCode.Focus();
        }

        #endregion

        #region СКАНИРОВАНИЕ ТОВАРА И КОРЗИНЫ

        /// <summary>
        /// Сканирование товара
        /// </summary>
        private void tbsItemCode_TextChanged(object sender, EventArgs e)
        {
            GetItemCode(tbsItemCode.Text);
        }

        /// <summary>
        /// Получение кода товара по его штрих-коду
        /// </summary>
        /// <param name="pBarcode">Штрих-код товара</param>
        private void GetItemCode(string pBarcode)
        {
            try
            {
                using (var adapter = new DocLinesTableAdapter())
                {
                    var useCurrentLotNumber = this.ReceiptMode == LotnReceiptMode.AssignSSCC ? 1 : 0;
                    var tbl = adapter.CheckBarcode(docID, "IT", pBarcode, sessionID, useCurrentLotNumber);
                    if (tbl == null || tbl.Count == 0)
                    {
                        MessageBox.Show("Товар с таким штрих-кодом не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbsItemCode.SelectAll();
                    }
                    else
                    {
                        var row = tbl[0];
                        ItemBarcode = pBarcode;
                        SelectedItemID = row.Item_ID;

                        if (ReceiptMode == LotnReceiptMode.PrintYL)
                            BasketPanelSetActive();
                        else
                            SamplePanelSetActive();
                    }
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время проверки штрих-кода товара: ", exc);
            }
        }

        /// <summary>
        /// Сканирование этикетки образца
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbsSampleCode_TextChanged(object sender, EventArgs e)
        {
            SampleBarcode = tbsSampleCode.Text;
            BasketPanelSetActive();
        }

        /// <summary>
        /// Сканирование корзины
        /// </summary>
        private void tbsBasketCode_TextChanged(object sender, EventArgs e)
        {
            BasketBarcode = tbsBasketCode.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        #endregion

        #region ДОБАВЛЕНИЕ ТОВАРА БЕЗ ШТРИХ-КОДА

        /// <summary>
        /// Нажатие на кнопку "Выбор товара без штрих-кода"
        /// </summary>
        private void btnAddItemWithoutBarcode_Click(object sender, EventArgs e)
        {
            var addItemWnd = new AddItemForm { StartPosition = FormStartPosition.CenterScreen, IsCountEnabled = false };
            if (addItemWnd.ShowDialog() == DialogResult.OK)
            {
                if (addItemWnd.ItemCode <= 0)
                {
                    MessageBox.Show("Товар не выбран!", "Товар без штрих-кода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                tbsItemCode.Text = addItemWnd.ItemCode.ToString();
                SelectedItemID = addItemWnd.ItemCode;

                if (ReceiptMode == LotnReceiptMode.PrintYL)
                    BasketPanelSetActive();
                else
                    SamplePanelSetActive();
            }
        }

        #endregion
    }
}
