using System;

using WMSOffice.Dialogs.Containers;

namespace WMSOffice.Window
{
    /// <summary>
    /// Окно интерфейса "Учет ТМЦ"
    /// </summary>
    public partial class TmMovementWindow : GeneralWindow
    {
        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ КЛАССА

        public TmMovementWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region СПРАВОЧНИКИ ПО ПРИНТЕРАМ

        /// <summary>
        /// Редактирование справочника площадок печати
        /// </summary>
        private void btnZonesDirectory_Click(object sender, EventArgs e)
        {
            var window = new ZonesDirectoryForm(UserID) { Owner = this };
            window.ShowDialog();
        }

        /// <summary>
        /// Редактирование справочника типов документов
        /// </summary>
        private void btnDocTypesDirectory_Click(object sender, EventArgs e)
        {
            var window = new DocTypesDirectoryForm(UserID) { Owner = this };
            window.ShowDialog();
        }

        /// <summary>
        /// Редактирование справочника IP-адресов
        /// </summary>
        private void btnIpDirectory_Click(object sender, EventArgs e)
        {
            var window = new IpDirectoryForm(UserID) { Owner = this };
            window.ShowDialog();
        }

        /// <summary>
        /// Редактирование справочника устройств
        /// </summary>
        private void btnDevicesDirectory_Click(object sender, EventArgs e)
        {
            var window = new DevicesDirectoryForm(UserID) { Owner = this };
            window.ShowDialog();
        }

        #endregion
    }
}
