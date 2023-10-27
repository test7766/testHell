using System;
using System.Collections.Generic;
using System.Text;
using WMSOffice.Window;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.ColdChain
{
    /// <summary>
    /// Класс-менеджер снятия показаний датчиков с термосумок
    /// </summary>
    public class ColdChainReadTermoBagSensorsDataManager
    {
        public string DocName { get; private set; }
        public string DocType { get; private set; }
        public int UserID { get; private set; }

        public int CurrentEquipmentID { get; set; }
        public string CurrentSensorSerialNumber { get; set; }
        public string CurrentSensorModeName { get; set; }

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();
        public Dialogs.SplashForm WaitProcessForm { get { return this.splashForm; } }

        public ColdChainReadTermoBagSensorsDataManager(string docName, string docType)
        {
            DocName = docName;
            DocType = docType;
        }

        /// <summary>
        /// Поиск ранее открытого окна формы привязки датчиков температуры к холодильному оборудованию
        /// </summary>
        /// </summary>
        /// <param name="activator"></param>
        /// <returns></returns>
        public GeneralWindow FindOpenedEquipmentSensorBindingWindow(MainForm activator)
        {
            foreach (GeneralWindow mdiChild in activator.MdiChildren)
                if (/*DocType == "SB" && */mdiChild is ColdChainReadTermoBagSensorsData)
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
            GeneralWindow window = new ColdChainReadTermoBagSensorsData(this);
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
    }
}
