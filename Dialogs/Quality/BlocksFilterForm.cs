using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Quality
{
    /// <summary>
    /// Окно настройки фильтра блокировок
    /// </summary>
    public partial class BlocksFilterForm : Form
    {
        #region ОСНОВНЫЕ ПЕРЕМЕННЫЕ И СВОЙСТВА

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private readonly long sessionID;

        /// <summary>
        /// Введенные пользователем товары
        /// </summary>
        public List<Data.Quality.BL_BlockItemsRow> Items { get { return cicItems.Items; } }

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ

        public BlocksFilterForm(long pSessionID, Data.Quality.BL_BlockItemsDataTable pExistedTable)
        {
            InitializeComponent();
            sessionID = pSessionID;
            cicItems.InitControl(pSessionID, pExistedTable);
        }

        #endregion

        #region СОХРАНЕНИЕ ДАННЫХ И ВЫХОД

        /// <summary>
        /// True если есть красные строки (товары, с которыми проблемы), False если все товары существуют
        /// </summary>
        private bool RedRowExists
        {
            get
            {
                foreach (var row in cicItems.Items)
                    if (!(row.IsResultNull() || String.IsNullOrEmpty(row.Result)))
                        return true;

                return false;
            }
        }

        /// <summary>
        /// Сохранение данных и выход
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (RedRowExists)
                if (MessageBox.Show("В таблице есть нераспознанные строки (закрашены красным цветом)." +
                    "Эти товары не будут участвовать в формировании фильтра. Вы точно хотите завершить ввод товаров?", "Настройка фильтра",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

            DialogResult = DialogResult.OK;
            Close();
        }

        #endregion
    }
}
