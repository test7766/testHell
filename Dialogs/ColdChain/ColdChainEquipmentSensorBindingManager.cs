using System;
using System.Collections.Generic;
using System.Text;
using WMSOffice.Window;
using System.Windows.Forms;
using System.Collections;
using System.ComponentModel;

namespace WMSOffice.Dialogs.ColdChain
{
    public class ColdChainEquipmentSensorsBindingManager
    {
        public string DocName { get; private set; }
        public string DocType { get; private set; }
        public int UserID { get; private set; }

        /// <summary>
        /// Текущие свойства обьектов формы (позиции выбранных элементов)
        /// </summary>
        public CurrentProperties CurrentData { get; set; }

        public ColdChainEquipmentSensorsBindingManager(string docName, string docType)
        {
            DocName = docName;
            DocType = docType;

            this.CurrentData = new CurrentProperties();
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
                if (/*DocType == "SB" && */mdiChild is ColdChainEquipmentSensorsBinding)
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
            OpenForm(activator);
        }

        /// <summary>
        /// Инициализация и открытие созданного экземпляра окна формы ввода времени выгрузки товара
        /// </summary>
        /// <param name="activator"></param>
        private void OpenForm(MainForm activator)
        {
            GeneralWindow window = new ColdChainEquipmentSensorsBinding(this);
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

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();
    }

    public class CurrentProperties
    {
        public int EquipmentID { get; set; }
        public int SensorID { get; set; }
        public string BranchID { get; set; }
    }

    /// <summary>
    /// Тип элементов привязки
    /// </summary>
    public enum BindingItemsType
    {
        /// <summary>
        /// Оборудование
        /// </summary>
        Equipment,

        /// <summary>
        /// Датчики
        /// </summary>
        Sensors,

        /// <summary>
        /// Перроны
        /// </summary>
        Platforms
    }

    /// <summary>
    /// Абстрактный адаптер для привязки
    /// </summary>
    public abstract class BaseBindingItemsAdapter
    {
        public CurrentProperties CurrentData { get; set; }
        public abstract string Caption { get; }
        public abstract object GetData();
        public virtual void AdaptSourceToGrid(DataGridView dgvSource)
        {
            dgvSource.DataSource = this.GetData();
        }

        /// <summary>
        /// Фабричный метод для создания классов-адаптеров элементов привязки
        /// </summary>
        /// <param name="itemsType">Тип элемента привязки</param>
        /// <returns></returns>
        public static BaseBindingItemsAdapter CreateBindingItemsAdapter(BindingItemsType itemsType)
        {
            switch (itemsType)
            {
                case BindingItemsType.Equipment:
                    return new EquipmentBindingItemsAdapter();
                case BindingItemsType.Sensors:
                    return new SensorsBindingItemsAdapter();
                case BindingItemsType.Platforms:
                    return new PlatformsBindingItemsAdapter();
                default:
                    return null;
            }
        }
    }

    /// <summary>
    /// Адаптер для привязки оборудования
    /// </summary>
    public class EquipmentBindingItemsAdapter : BaseBindingItemsAdapter
    {
        public override string Caption { get { return "Выберите оборудование из списка для добавления"; } }
        private Data.ColdChain.AvailableEquipmentDataTable data = new WMSOffice.Data.ColdChain.AvailableEquipmentDataTable();

        public override object GetData()
        {
            try
            {
                using (Data.ColdChainTableAdapters.AvailableEquipmentTableAdapter adapter = new WMSOffice.Data.ColdChainTableAdapters.AvailableEquipmentTableAdapter())
                    adapter.Fill(this.data, this.CurrentData.BranchID);

                return this.data;
            }
            catch (System.Data.SqlClient.SqlException er)
            {
                MessageBox.Show(er.Message, "Ошибка момента обновления списка холодильного оборудования", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public override void AdaptSourceToGrid(DataGridView dgvSource)
        {
            base.AdaptSourceToGrid(dgvSource);
            dgvSource.Columns[this.data.Equipment_IDColumn.Caption].HeaderText = "№";
            dgvSource.Columns[this.data.Equipment_IDColumn.Caption].Width = 50;
            dgvSource.Columns[this.data.Equipment_NameColumn.Caption].HeaderText = "Название";
            dgvSource.Columns[this.data.Equipment_NameColumn.Caption].Width = 200;
            dgvSource.Columns[this.data.Equipment_Type_NameColumn.Caption].HeaderText = "Тип";
            dgvSource.Columns[this.data.Equipment_Type_NameColumn.Caption].Width = 170;
            dgvSource.Columns[this.data.DepartmentColumn.Caption].HeaderText = "Отдел (примечание)";
            dgvSource.Columns[this.data.DepartmentColumn.Caption].Width = 150;
            dgvSource.Columns[this.data.Transportation_Type_NameColumn.Caption].HeaderText = "Тип транспортировки";
            dgvSource.Columns[this.data.Transportation_Type_NameColumn.Caption].Width = 200;
        }
    }

    /// <summary>
    /// Адаптер для привязки датчиков
    /// </summary>
    public class SensorsBindingItemsAdapter : BaseBindingItemsAdapter
    {
        public override string Caption { get { return "Выберите датчик из списка для добавления"; } }
        private Data.ColdChain.AvailableSensorsDataTable data = new WMSOffice.Data.ColdChain.AvailableSensorsDataTable();

        public override object GetData()
        {
            try
            {
                using (Data.ColdChainTableAdapters.AvailableSensorsTableAdapter adapter = new WMSOffice.Data.ColdChainTableAdapters.AvailableSensorsTableAdapter())
                     adapter.Fill(this.data, this.CurrentData.BranchID, this.CurrentData.EquipmentID);

                return this.data;
            }
            catch (System.Data.SqlClient.SqlException er)
            {
                MessageBox.Show(er.Message, "Ошибка момента обновления списка датчиков температуры", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public override void AdaptSourceToGrid(DataGridView dgvSource)
        {
            base.AdaptSourceToGrid(dgvSource);
            dgvSource.Columns[this.data.Sensor_IDColumn.Caption].Visible = false;
            dgvSource.Columns[this.data.Serial_NumberColumn.Caption].HeaderText = "S/N";
            dgvSource.Columns[this.data.Sensor_Type_NameColumn.Caption].HeaderText = "Тип";
        }
    }

    /// <summary>
    /// Адаптер для привязки перронов
    /// </summary>
    public class PlatformsBindingItemsAdapter : BaseBindingItemsAdapter
    {
        public override string Caption { get { return "Выберите перрон из списка для добавления"; } }
        private Data.ColdChain.AvailablePlatformsDataTable data = new WMSOffice.Data.ColdChain.AvailablePlatformsDataTable();

        public override object GetData()
        {
            try
            {
                using (Data.ColdChainTableAdapters.AvailablePlatformsTableAdapter adapter = new WMSOffice.Data.ColdChainTableAdapters.AvailablePlatformsTableAdapter())
                    adapter.Fill(this.data, this.CurrentData.BranchID);

                return this.data;
            }
            catch (System.Data.SqlClient.SqlException er)
            {
                MessageBox.Show(er.Message, "Ошибка момента обновления списка перронов", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public override void AdaptSourceToGrid(DataGridView dgvSource)
        {
            base.AdaptSourceToGrid(dgvSource);
            dgvSource.Columns[this.data.Peron_IDColumn.Caption].HeaderText = "№";
        }
    }
}
