using System;
using System.Collections.Generic;
using System.Text;
using WMSOffice.Window;
using System.Windows.Forms;
using System.Collections;
using System.ComponentModel;

namespace WMSOffice.Dialogs.ColdChain
{
    public class ColdChainEquipmentManager
    {
        public string DocName { get; private set; }
        public string DocType { get; private set; }
        public int UserID { get; private set; }

        public EditingGridCellObserver EditingCellObserver { get; private set; }

        /// <summary>
        /// Текущий идентификатор холодильного оборудования
        /// </summary>
        public int CurrentEquipmentID { get; set; }

        private static Data.ColdChain.EquipmentTypesDataTable equipmentTypes = null;
        public static Data.ColdChain.EquipmentTypesDataTable EquipmentTypes
        {
            get 
            {
                if (equipmentTypes == null)
                    LoadEquimpmentTypes();

                return equipmentTypes;
            }
        }

        public ColdChainEquipmentManager(string docName, string docType)
        {
            DocName = docName;
            DocType = docType;

            this.EditingCellObserver = new EditingGridCellObserver();
        }

        private static void LoadEquimpmentTypes()
        {
            try
            {
                equipmentTypes = new WMSOffice.Data.ColdChain.EquipmentTypesDataTable();
                using (Data.ColdChainTableAdapters.EquipmentTypesTableAdapter adapter = new WMSOffice.Data.ColdChainTableAdapters.EquipmentTypesTableAdapter())
                    adapter.Fill(equipmentTypes);
            }
            catch (System.Data.SqlClient.SqlException er)
            {
                MessageBox.Show(er.Message, "Ошибка момента обновления списка типов холодильного оборудования", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Возвращает признак доступности редактора отдела для данного типа оборудования
        /// </summary>
        /// <param name="equipmentTypeID"></param>
        /// <returns></returns>
        public bool GetEquipmentTypeUseDeparmentFlag(int equipmentTypeID)
        {
            return Convert.ToBoolean(EquipmentTypes.Select(string.Format("Equipment_Type_ID = {0}", equipmentTypeID))[0]["Use_Department"]);
        }

        /// <summary>
        /// Поиск ранее открытого окна формы привязки датчиков температуры к холодильному оборудованию
        /// </summary>
        /// </summary>
        /// <param name="activator"></param>
        /// <returns></returns>
        public GeneralWindow FindOpenedEquipmentWindow(MainForm activator)
        {
            foreach (GeneralWindow mdiChild in activator.MdiChildren)
                if (mdiChild is ColdChainEquipmentsWindow)
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
            GeneralWindow window = new ColdChainEquipmentsWindow(this);
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

        public bool AddEquipmentPermission { get; private set; }
        public bool ChangeBranchPermission { get; private set; }
        public bool ChangeDepartmentNotationPermission { get; private set; }
        public bool ChangeAbilityPermission { get; private set; }
        public bool ChangeTransportationTypePermission { get; private set; }
        public bool ChangeForwarderPermission { get; private set; }

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

                    this.AddEquipmentPermission = permissions.EquipmentAdd;
                    this.ChangeBranchPermission = permissions.EquipmentBranch;
                    this.ChangeDepartmentNotationPermission = permissions.EquipmentDepartment;
                    this.ChangeAbilityPermission = permissions.EquipmentActive;
                    this.ChangeTransportationTypePermission = permissions.EquipmentTransportation;
                    this.ChangeForwarderPermission = permissions.CanChangeForwarders;
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

        /// <summary>
        /// Печать этикетки холодильного оборудования
        /// </summary>
        public void PrintEquipmentSticker(string printerName)
        {
            BackgroundWorker printWorker = new BackgroundWorker();
            printWorker.DoWork += new DoWorkEventHandler(printWorker_DoWork);
            printWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(printWorker_RunWorkerCompleted);

            PrintWorkerParameters stickerPrintParameters = new PrintWorkerParameters() { EquipmentID = this.CurrentEquipmentID, PrinterName = printerName };
            splashForm.ActionText = "Печать этикетки холодильного оборудования...";
            printWorker.RunWorkerAsync(stickerPrintParameters);
            splashForm.ShowDialog();
        }

        private void printWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                PrintWorkerParameters stickerPrintParameters = (PrintWorkerParameters)e.Argument;

                Data.ColdChain.ColdEquipmentStickerDataTable stickerSource = new WMSOffice.Data.ColdChain.ColdEquipmentStickerDataTable();
                using (Data.ColdChainTableAdapters.ColdEquipmentStickerTableAdapter adapter = new WMSOffice.Data.ColdChainTableAdapters.ColdEquipmentStickerTableAdapter())
                    adapter.Fill(stickerSource, stickerPrintParameters.EquipmentID);

                // Cоздание изображения штрих-кода
                if (stickerSource.Rows.Count > 0)
                {
                    Data.ColdChain.ColdEquipmentStickerRow stickerData = stickerSource[0];
                    stickerData.BarCodeLabel = Dialogs.Complaints.BarCodeGenerator.GetBarcodeCODE39(stickerData.Bar_code);

                    using (Reports.ColdEquipmentStickerVertical report = new WMSOffice.Reports.ColdEquipmentStickerVertical())
                    {
                        report.SetDataSource((IEnumerable)stickerSource);
                        report.PrintOptions.PrinterName = stickerPrintParameters.PrinterName;
                        report.PrintToPrinter(1, false, 1, 0);
                    }
                }
            }
            catch (Exception err)
            {
                e.Result = err;
            }
        }

        private void printWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                MessageBox.Show((e.Result as Exception).ToString(), "Ошибка момента печати наклейки холодильного оборудования", MessageBoxButtons.OK, MessageBoxIcon.Error);

            splashForm.CloseForce();
        }

        /// <summary>
        /// Класс, содержащий параметры для печати этикеток холодильного оборудования
        /// </summary>
        private class PrintWorkerParameters
        {
            /// <summary>
            /// Название принтера.
            /// </summary>
            public string PrinterName { get; set; }

            /// <summary>
            /// Номер оборудования
            /// </summary>
            public int EquipmentID { get; set; }
        }
    }
}
