using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Classes.PickControl
{
    /// <summary>
    /// Класс для описания документа контейнера расхождения
    /// </summary>
    public abstract class VarianceContainerDoc
    {
        public bool ApplyTestVersionChanges { get; private set; }

        public long? ProcessVersionID { get; private set; }

        public long? DocID { get; protected set; }
        public string BarCode { get; protected set; }

        public long UserID { get; private set; }
        public string UserLogin { get; private set; }
        public long PC_DocID { get; private set; }

        public bool IsOpened { get { return DocID.HasValue; } }

        public bool IsRepeatControl { get; set; }

        /// <summary>
        /// Тип расхождения
        /// </summary>
        public abstract int VarianceTypeID { get; } 

        public event EventHandler OnOpen;
        protected void RaiseOnOpen()
        {
            if (OnOpen != null)
                OnOpen(this, EventArgs.Empty);
        }

        public event EventHandler OnClose;
        protected void RaiseOnClose()
        {
            if (OnClose != null)
                OnClose(this, EventArgs.Empty);
        }

        public VarianceContainerDoc(long userID, string userLogin, long pc_DocID, long? processVersionID, bool applyTestVersionChanges)
        {
            UserID = userID;
            UserLogin = userLogin;
            PC_DocID = pc_DocID;
            ProcessVersionID = processVersionID;
            ApplyTestVersionChanges = applyTestVersionChanges;
        }

        public string ScanContainer(string label, string text)
        {
            var barCode = (string)null;

            var dlgSurplusContainerScanner = new WMSOffice.Dialogs.Containers.ScanContainerForm()
            {
                Label = label,
                Text = text,
                Image = Properties.Resources.paper_box,
                //UseScanModeOnly = true
            };

            if (dlgSurplusContainerScanner.ShowDialog() == DialogResult.OK)
                barCode = dlgSurplusContainerScanner.Barcode;

            return barCode;
        }

        protected bool ConfirmBoss(ref int? bossID)
        {
            bossID = (int?)null;
            var dlgBossScanner = new WMSOffice.Dialogs.Containers.ScanContainerForm()
            {
                Label = "Отсканируйте бэйдж руководителя,\r\nкоторый отвечает за мониторинг контроля",
                Text = "Подтверждение закрытия контейнера",
                Image = Properties.Resources.role,
                //OnlyNumbersInBarcode = true
                UseScanModeOnly = true
            };

            if (dlgBossScanner.ShowDialog() != DialogResult.OK)
                return false;

            bossID = Convert.ToInt32(dlgBossScanner.Barcode);

            var result = (int?)null;
            using (var adapter = new Data.PickControlTableAdapters.SurplusContainerDocsTableAdapter())
                adapter.CheckBoss(this.UserID, this.PC_DocID, bossID, ref result);

            if (result.HasValue && Convert.ToBoolean(result.Value))
                return true;
            else
                throw new Exception("Пользователь не имеет права\r\nподтверждения.");
        }

        public abstract void TryOpen();
        public abstract bool Open();
        public abstract bool Close();

        public abstract bool Init(VarianceContainerDocInitParameters parameters);
        public abstract void Preview(long? PC_DocID);
        public abstract void Confirm();
        public abstract void PreviewForClose();
        public abstract bool CloseDirectly();
        public abstract bool CheckContainer(string containerBarCode);
    }

    /// <summary>
    /// Параметры инициализации контейнера
    /// </summary>
    public abstract class VarianceContainerDocInitParameters
    { 
    
    }

    /// <summary>
    /// Режим работы с контейнером расхождений
    /// </summary>
    public enum VarianceContainerWorkMode
    {
        /// <summary>
        /// Инициализация контейнера
        /// </summary>
        Init = 0,

        /// <summary>
        /// Подтверждение содержимого контейнера
        /// </summary>
        Confirm = 1,

        /// <summary>
        /// Просмотр содержимого контейнера
        /// </summary>
        Preview = 2,

        /// <summary>
        /// Режим просмотра с целью закрытия контейнера
        /// </summary>
        PreviewForClose = 3
    }
}
