using System;
using System.Collections.Generic;
using System.Text;
using WMSOffice.Window;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.ColdChain
{
    /// <summary>
    /// Класс-менеджер бизнес-процесса ввода времени выгрузки товара
    /// </summary>
    public class ColdChainSetUnloadingTimeManager
    {
        public string DocName { get; private set; }
        public string DocType { get; private set; }
        public int UserID { get; private set; }

        /// <summary>
        /// № текущего акта
        /// </summary>
        public long CurrentActID { get; set; }

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();
        public Dialogs.SplashForm WaitProcessForm { get { return this.splashForm; } }

        public ColdChainSetUnloadingTimeManager(string docName, string docType)
        {
            DocName = docName;
            DocType = docType;
        }

        /// <summary>
        /// Поиск ранее открытого окна формы ввода времени выгрузки товара
        /// </summary>
        /// </summary>
        /// <param name="activator"></param>
        /// <returns></returns>
        public GeneralWindow FindOpenedUnloadingTimeWindow(MainForm activator)
        {
            foreach (GeneralWindow mdiChild in activator.MdiChildren)
                if (/*DocType == "UT" && */mdiChild is ColdChainSetUnloadingTimeWindow)
                    return mdiChild;

            return null;
        }

        /// <summary>
        /// Активация запущенного экземпляра окна формы ввода времени выгрузки товара
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
            OpenForm(activator);
        }

        /// <summary>
        /// Инициализация и открытие созданного экземпляра окна формы ввода времени выгрузки товара
        /// </summary>
        /// <param name="activator"></param>
        private void OpenForm(MainForm activator)
        {
            GeneralWindow window = new ColdChainSetUnloadingTimeWindow(this);
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
