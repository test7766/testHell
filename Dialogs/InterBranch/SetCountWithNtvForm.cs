using System;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.InterBranch
{
    /// <summary>
    /// Форма для ввода количества с возможностью ввода количества товара, 
    /// а также количества НТВ и Боя
    /// </summary>
    public partial class SetCountWithNtvForm : Form
    {
        #region ОСНОВНЫЕ ПЕРЕМЕННЫЕ И СВОЙСТВА

        /// <summary>
        /// Идентификатор сканируемого товара
        /// </summary>
        private readonly int itemID;

        #endregion

        #region СВОЙСТВА (КОЛИЧЕСТВА ТОВАРА)

        /// <summary>
        /// Значение, которое обозначает что в поле "Количество" введена левая строка (не целое число)
        /// </summary>
        private const int BAD_VALUE = Int32.MinValue;

        /// <summary>
        /// Введенное количество товара
        /// </summary>
        public int Count { get { return GetCountFromTextBox(tbxCount); } }

        /// <summary>
        /// Получение количества из текстового поля для ввода количества
        /// </summary>
        /// <param name="pTextBox">Текстовое поле для ввода количества</param>
        /// <returns>Целое значение, полученное из текстового поля</returns>
        private static int GetCountFromTextBox(TextBox pTextBox)
        {
            int cnt = 0;
            return (!String.IsNullOrEmpty(pTextBox.Text) && Int32.TryParse(pTextBox.Text, out cnt)) ?
                (cnt < 0 ? BAD_VALUE : cnt) : BAD_VALUE;
        }

        /// <summary>
        /// Введенное количество НТВ-товара
        /// </summary>
        public int CountNtv { get { return GetCountFromTextBox(tbxCountNtv); } }

        /// <summary>
        /// Введенное количество боя
        /// </summary>
        public int CountBoy { get { return GetCountFromTextBox(tbxCountBoy); } }

        /// <summary>
        /// Введенное количество брака
        /// </summary>
        public int CountDefect { get { return GetCountFromTextBox(tbxCountDefect); } }

        public bool? ND_ZU_Checked { get; private set; }

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ

        public SetCountWithNtvForm(int pItemID, string pItemName, string pLotn, int pExistedCount,
            int pExistedCountNtv, int pExistedCountBoy, int pExistedCountDefect, int pCount,
            int pCountNtv, int pCountBoy, int pCountDefect, bool zu_nd_enabled, bool zu_nd_checked)
        {
            InitializeComponent();
            itemID = pItemID;
            lblItemName.Text = pItemName;
            lblLotn.Text = pLotn;
            lblExistedCount.Text = pExistedCount.ToString();
            lblExistedCountNtv.Text = pExistedCountNtv.ToString();
            lblExistedCountBoy.Text = pExistedCountBoy.ToString();
            lblExistedCountDefect.Text = pExistedCountDefect.ToString();
            tbxCount.Text = pCount.ToString();
            tbxCountNtv.Text = pCountNtv.ToString();
            tbxCountBoy.Text = pCountBoy.ToString();
            tbxCountDefect.Text = pCountDefect.ToString();
            cbND_ZU.Visible = zu_nd_enabled;
            cbND_ZU.Checked = zu_nd_checked;
        }

        /// <summary>
        /// Загузка списка возможных склеек
        /// </summary>
        private void SetCountForm_Load(object sender, EventArgs e)
        {
            LoadUoms();
            tbxCount.Focus();
        }

        /// <summary>
        /// Загрузка единиц измерения для сканируемого товара
        /// </summary>
        private void LoadUoms()
        {
            try
            {
                taUomStructure.Fill(pickControl.UOMStructure, itemID);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время загрузки единиц измерения по товару: ", exc);
            }
        }

        #endregion

        #region ЗАВЕРШЕНИЕ ВВОДА КОЛИЧЕСТВА

        /// <summary>
        /// Нажали Enter - завершили ввод
        /// </summary>
        private void element_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                FinishEntering();
        }

        /// <summary>
        /// Завершить ввод количеств и закрыть окно с положительным результатом
        /// </summary>
        private void FinishEntering()
        {
            if (ValidateData())
            {
                this.ND_ZU_Checked = cbND_ZU.Visible ? cbND_ZU.Checked : (bool?)null;

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        /// <summary>
        /// Проверка введенных данных на корректность
        /// </summary>
        /// <returns>True если все количества заданы правильно, False если есть ошибки при вводе</returns>
        private bool ValidateData()
        {
            string msg = String.Empty;

            if (Count == BAD_VALUE)
            {
                msg = "В поле КОЛИЧЕСТВО не задано значение либо задано некорректное значение!";
                tbxCount.Focus();
            }
            else if (CountNtv == BAD_VALUE)
            {
                msg = "В поле КОЛ-ВО НТВ не задано значение либо задано некорректное значение!";
                tbxCountNtv.Focus();
            }
            else if (CountBoy == BAD_VALUE)
            {
                msg = "В поле КОЛ-ВО БОЯ не задано значение либо задано некорректное значение!";
                tbxCountBoy.Focus();
            }
            else if (CountDefect == BAD_VALUE)
            {
                msg = "В поле КОЛ-ВО БРАКА не задано значение либо задано некорректное значение!";
                tbxCountDefect.Focus();
            }

            if (!String.IsNullOrEmpty(msg))
            {
                MessageBox.Show(msg, "Проверка данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
                return true;
        }

        /// <summary>
        /// При нажатии на кнопку ОК завершаем ввод
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            FinishEntering();
        }

        /// <summary>
        /// Задание количества через список склеек
        /// </summary>
        private void lbxUoms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxUoms.Enabled && lbxUoms.SelectedItems.Count == 1)
                tbxCount.Text = lbxUoms.SelectedValue.ToString();
        }  

        #endregion      
    }
}
