using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs.ColdChain;
using WMSOffice.Reports;
using WMSOffice.Window;
using System.Data;
using System.ComponentModel;

namespace WMSOffice.Dialogs.ColdChain
{
    /// <summary>
    /// Класс-менеджер отчета о температурном режиме
    /// </summary>
    public class ColdChainTransportationRegimeReportManager
    {
        public string DocName { get; private set; }
        public string DocType { get; private set; }
        public int UserID { get; private set; }

        /// <summary>
        /// Ш/К белой этикетки
        /// </summary>
        public double StickerCode { get; set; }

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();
        public Dialogs.SplashForm WaitProcessForm { get { return this.splashForm; } }

        public ColdChainTransportationRegimeReportManager(string docName, string docType)
        {
            DocName = docName;
            DocType = docType;
        }

        /// <summary>
        /// Поиск ранее открытого окна формы отчета о температурном режиме
        /// </summary>
        /// </summary>
        /// <param name="activator"></param>
        /// <returns></returns>
        public GeneralWindow FindOpenedTemperatureReportWindow(MainForm activator)
        {
            foreach (GeneralWindow mdiChild in activator.MdiChildren)
                if (mdiChild is ColdChainTemperatureReportWindow)
                    return mdiChild;

            return null;
        }

        /// <summary>
        /// Активация запущенного экземпляра окна формы отчета о температурном режиме
        /// </summary>
        /// <param name="window"></param>
        public void Activate(GeneralWindow window)
        {
            window.Activate();
        }

        /// <summary>
        /// Cоздание окна формы отчета о температурном режиме
        /// </summary>
        /// <param name="activator"></param>
        public void CreateForm(MainForm activator)
        {
            UserID = activator.UserID;
            OpenForm(activator);
        }

        /// <summary>
        /// Инициализация и открытие созданного экземпляра окна формы отчета о температурном режиме
        /// </summary>
        /// <param name="activator"></param>
        private void OpenForm(MainForm activator)
        {
            GeneralWindow window = new ColdChainTemperatureReportWindow(this);
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
