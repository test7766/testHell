using System;
using System.Collections.Generic;
using System.Text;
using WMSOffice.Window;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.ColdChain
{
    /// <summary>
    /// Класс-менеджер бизнес-процесса помещения товара в термосумки
    /// </summary>
    public class ColdChainPackingManager
    {
        // Экземпляр окна диалогового формы сканирования документов
        private ScanBarCodeForm scanFormHandler = null;

        public string DocName { get; private set; }
        public string DocType { get; private set; }
        public int UserID { get; private set; }

        /// <summary>
        ///  Признак завершения упаковки товара
        /// </summary>
        public bool CompletePacking { get; set; }
      
        /// <summary>
        /// Признак завершения использования термосумки
        /// </summary>
        public bool CompleteUsingTermoBag 
        {
            get { return TermoBagBarCode == null; }
            set { if (value) TermoBagBarCode = null; }
        }

        /// <summary>
        /// Номер маршрутного листа
        /// </summary>
        public int RouteListNumber { get; private set; }

        /// <summary>
        /// Код термосумки
        /// </summary>
        public string TermoBagBarCode { get; private set; }


        public ColdChainPackingManager(string docName, string docType)
        {
            DocName = docName;
            DocType = docType;
        }

        /// <summary>
        /// Поиск ранее открытого окна формы упаковки товара в термосумку
        /// </summary>
        /// </summary>
        /// <param name="activator"></param>
        /// <returns></returns>
        public GeneralWindow FindOpenedPackingWindow(MainForm activator)
        {
            foreach (GeneralWindow mdiChild in activator.MdiChildren)
                if (/*DocType == "PG" && */mdiChild is ColdChainTermoBagPackingWindow)
                    return mdiChild;

            return null;
        }

        /// <summary>
        /// Активация запущенного экземпляра окна формы упаковки товара в термосумку
        /// </summary>
        /// <param name="window"></param>
        public void Activate(GeneralWindow window)
        {
            window.Activate();
        }

        /// <summary>
        /// Cоздание окна формы упаковки товара в термосумку
        /// </summary>
        /// <param name="activator"></param>
        public void CreateForm(MainForm activator)
        {
            UserID = activator.UserID;

            if (PrepareWorking()) 
            //this.TermoBagBarCode = "1234567890"; // TODO временное условие для правильной работы в тестовом режиме
                OpenForm(activator);
        }

        /// <summary>
        /// Подготовка работы к процессу упаковки товара в термосумки 
        /// </summary>
        /// <returns></returns>
        private bool PrepareWorking()
        {
            if (ScanRouteList() && ScanTermoBag())
                return true;

            return false;
        }

        private bool ScanRouteList()
        {
            if (!RunScenario(ScanScenarioType.RouteList))
                return false;

            // Сохраняем номер маршрутного листа
            this.RouteListNumber = (int)scanFormHandler.ResponseData[0];
            return true;
        }

        /// <summary>
        /// Выбор следующей термосумки
        /// </summary>
        public void UseNextTermoBag()
        {
            ScanTermoBag();
        }

        private bool ScanTermoBag()
        {
            if (!RunScenario(ScanScenarioType.TermoBag))
                return false;

            // Сохраняем код термосумки
            this.TermoBagBarCode = (string)scanFormHandler.ResponseData[0];
            return true;
        }

        private bool RunScenario(ScanScenarioType type)
        {
            ScanScenario.UserID = this.UserID;
            scanFormHandler = new ScanBarCodeForm(type);
            if (scanFormHandler.ShowDialog() == DialogResult.OK)
                return true;

            return false;
        }

        /// <summary>
        /// Инициализация и открытие созданного экземпляра окна формы упаковки товара в термосумку
        /// </summary>
        /// <param name="activator"></param>
        private void OpenForm(MainForm activator)
        {
            GeneralWindow window = new ColdChainTermoBagPackingWindow(this);
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
