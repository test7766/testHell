using System;
using System.Data;
using System.Windows.Forms;

using WMSOffice.Classes.SearchParameters;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Data.ComplaintsTableAdapters;

namespace WMSOffice.Dialogs.Complaints
{
    /// <summary>
    /// Окно для выбора полки для товара в претензии
    /// </summary>
    public partial class ChooseLocationForm : Form
    {
        #region ПЕРЕМЕННЫЕ И СВОЙСТВА КЛАССА

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private readonly long sessionID;

        /// <summary>
        /// Идентификатор претензии
        /// </summary>
        private readonly long docID;

        /// <summary>
        /// Полка, выбранная в таблице либо NULL, если в таблице не выделено ни одной полки
        /// </summary>
        public Data.Complaints.CO_Search_LocationsRow SelectedLocation
        {
            get { return dgvLocations.SelectedItem as Data.Complaints.CO_Search_LocationsRow; }
        }

        /// <summary>
        /// Параметры загрузки полок
        /// </summary>
        private LocationsSearchParameters sp;

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ

        public ChooseLocationForm(long pSessionID, long pDocID)
        {
            InitializeComponent();
            sessionID = pSessionID;
            docID = pDocID;
            sp = new LocationsSearchParameters { DocID = docID, SessionID = sessionID };
            InitializeLocationsGrid();
            tbxFilter.Focus();
        }

        /// <summary>
        /// Инициализация фильтруемого грида с полками
        /// </summary>
        private void InitializeLocationsGrid()
        {
            dgvLocations.Init(new LocationsView(), true);
            dgvLocations.UserID = sessionID;
            dgvLocations.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvLocations.AllowSummary = false;
        }

        /// <summary>
        /// Управление окном с помощью горячих клавиш
        /// </summary>
        private void ChooseLocationForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F && e.Control)
                tbxFilter.Focus();
        }

        /// <summary>
        /// Загрузка полок по умолчанию при загрузке окна
        /// </summary>
        private void ChooseLocationForm_Load(object sender, EventArgs e)
        {
            RefreshLocations();
        }

        /// <summary>
        /// Обновление полок
        /// </summary>
        private void RefreshLocations()
        {
            try
            {
                sp.Filter = String.IsNullOrEmpty(tbxFilter.Text) ? null : tbxFilter.Text;
                (dgvLocations.DataView as LocationsView).FillData(sp);
                dgvLocations.BindData(false);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время загрузки полок: ", exc);
            }
        }

        /// <summary>
        /// Нажатие Enter в строке фильтра - загружаем новые полки
        /// </summary>
        private void tbxFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !String.IsNullOrEmpty(tbxFilter.Text) && tbxFilter.Text.Length >= 3)
                RefreshLocations();
        }

        /// <summary>
        /// Выбор полки по двойному клику на записи
        /// </summary>
        private void dgvLocations_OnRowDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnOK_Click(btnOK, EventArgs.Empty);
        }

        #endregion

        #region ЗАКРЫТИЕ ОКНА

        /// <summary>
        /// Закрытие окна с положительным результатом (только если выбрана полка)
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (SelectedLocation == null)
                MessageBox.Show("Нужно обязательно выбрать полку!", "Выбор полки",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        #endregion
    }

    #region КЛАСС ДЛЯ ОТОБРАЖЕНИЯ ФИЛЬТРУЕМОГО ГРИДА ПОЛОК

    /// <summary>
    /// Представление для грида с полками
    /// </summary>
    public class LocationsView : IDataView
    {
        /// <summary>
        /// Коллекция отображаемых колонок
        /// </summary>
        private PatternColumnsCollection dataColumns = new PatternColumnsCollection();

        /// <summary>
        /// Коллекция отображаемых колонок
        /// </summary>
        public PatternColumnsCollection Columns { get { return dataColumns; } }

        /// <summary>
        /// Источник данных для представления
        /// </summary>
        private DataTable data;

        /// <summary>
        /// Источник данных для представления
        /// </summary>
        public DataTable Data { get { return data; } }

        /// <summary>
        /// Получение источника данных согласно критериям поиска
        /// </summary>
        /// <param name="pSearchParameters">Критерии поиска</param>
        public void FillData(SearchParametersBase pSearchParameters)
        {
            var sc = pSearchParameters as LocationsSearchParameters;
            using (var adapter = new CO_Search_LocationsTableAdapter())
                data = adapter.GetData(sc.SessionID, sc.ItemID, sc.DocID, sc.Filter);
        }

        public LocationsView()
        {
            this.dataColumns.Add(new PatternColumn("Склад", "Warehouse_ID", new FilterPatternExpressionRule("Warehouse_ID")));
            this.dataColumns.Add(new PatternColumn("Полка", "Location_ID", new FilterPatternExpressionRule("Location_ID")));
        }
    }

    #endregion
}

