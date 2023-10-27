using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Window;

namespace WMSOffice.Dialogs.ColdChain
{
    public class ColdChainTemperatureSensorsManager
    {
        public string DocName { get; private set; }
        public string DocType { get; private set; }
        public int UserID { get; private set; }

        public EditingGridCellObserver EditingCellObserver { get; private set; }

        /// <summary>
        /// Текущий идентификатор датчика температуры
        /// </summary>
        public int CurrentSensorID { get; set; }

        public ColdChainTemperatureSensorsManager(string docName, string docType)
        {
            DocName = docName;
            DocType = docType;

            this.EditingCellObserver = new EditingGridCellObserver();
        }

        /// <summary>
        /// Поиск ранее открытого окна формы привязки датчиков температуры к холодильному оборудованию
        /// </summary>
        /// </summary>
        /// <param name="activator"></param>
        /// <returns></returns>
        public GeneralWindow FindOpenedSensorsWindow(MainForm activator)
        {
            foreach (GeneralWindow mdiChild in activator.MdiChildren)
                if (mdiChild is СoldChainTemperatureSensorsWindow)
                    return mdiChild;

            return null;
        }

        /// <summary>
        /// Активация запущенного экземпляра окна формы привязки датчиков температуры к холодильному оборудованию
        /// </summary>
        /// <param name="window"></param>
        public void Activate(GeneralWindow window)
        {
            window.Activate();
        }

        /// <summary>
        /// Cоздание окна формы ввода времени выгрузки товара
        /// </summary>
        /// <param name="activator"></param>
        public void CreateForm(MainForm activator)
        {
            UserID = activator.UserID;

            // if (PrepareWorking())
            OpenForm(activator);
        }

        /// <summary>
        /// Инициализация и открытие созданного экземпляра окна формы ввода времени выгрузки товара
        /// </summary>
        /// <param name="activator"></param>
        private void OpenForm(MainForm activator)
        {
            GeneralWindow window = new СoldChainTemperatureSensorsWindow(this);
            if (window != null)
            {
                InitializeWindow(window);
                window.MdiParent = activator;
                window.Show();
                activator.ActiveWindows.Enabled = true;
            }
        }

        /// <summary>
        /// Инициализаия окна
        /// </summary>
        /// <param name="window"></param>
        private void InitializeWindow(GeneralWindow window)
        {
            window.InitDocument(DocName, 0, DocType, DateTime.Now, "", "");
            window.WindowState = FormWindowState.Maximized;
        }

        public bool AddSensorPermission { get; private set; }
        public bool ChangeBranchPermission { get; private set; }
        public bool ChangeAbilityPermission { get; private set; }

        /// <summary>
        /// Получение пользовательских прав
        /// </summary>
        public void SetPermissions()
        {
            try
            {
                Data.ColdChain.ColdEditPermissionDataTable permissionsTable = new WMSOffice.Data.ColdChain.ColdEditPermissionDataTable();
                using (Data.ColdChainTableAdapters.ColdEditPermissionTableAdapter adapter = new WMSOffice.Data.ColdChainTableAdapters.ColdEditPermissionTableAdapter())
                    adapter.Fill(permissionsTable, this.UserID);

                if (permissionsTable.Rows.Count > 0)
                {
                    Data.ColdChain.ColdEditPermissionRow permissions = (permissionsTable.Rows[0] as Data.ColdChain.ColdEditPermissionRow);

                    this.AddSensorPermission = permissions.SensorAdd;
                    this.ChangeBranchPermission = permissions.SensorBranch;
                    this.ChangeAbilityPermission = permissions.SensorActive;
                }
            }
            catch (System.Data.SqlClient.SqlException er)
            {
                MessageBox.Show(er.Message, "Ошибка получения пользовательских прав", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();
        public Dialogs.SplashForm WaitProcessForm { get { return this.splashForm; } }
    }
}
