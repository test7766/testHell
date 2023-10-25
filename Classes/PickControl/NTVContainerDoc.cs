using System;
using System.Collections.Generic;
using System.Text;
using WMSOffice.Dialogs.PickControl;

namespace WMSOffice.Classes.PickControl
{
    /// <summary>
    /// Класс для описания документа контейнера НТВ
    /// </summary>
    public class NTVContainerDoc : VarianceContainerDoc
    {
        //public long? ProcessVersionID { get; private set; }

        //public long? DocID { get; private set; }
        //public string BarCode { get; private set; }

        //public long UserID { get; private set; }
        //public string HostName { get; private set; }
        //public long PC_DocID { get; private set; }

        //public bool IsOpened { get { return DocID.HasValue; } }

        /// <summary>
        /// Тип расхождения: НТВ (8)
        /// </summary>
        public override int VarianceTypeID { get { return 8; } }

        //public event EventHandler OnOpen;
        //private void RaiseOnOpen()
        //{
        //    if (OnOpen != null)
        //        OnOpen(this, EventArgs.Empty);
        //}

        //public event EventHandler OnClose;
        //private void RaiseOnClose()
        //{
        //    if (OnClose != null)
        //        OnClose(this, EventArgs.Empty);
        //}

        public NTVContainerDoc(long userID, string userLogin, long pc_DocID, long? processVersionID, bool applyTestVersionChanges)
            : base(userID, userLogin, pc_DocID, processVersionID, applyTestVersionChanges)
        {
            //UserID = userID;
            //HostName = hostName;
            //PC_DocID = pc_DocID;
            //ProcessVersionID = processVersionID;
        }

        public override void TryOpen()
        {
            try
            {
                var containers = new Data.PickControl.NTVContainerDocsDataTable();

                // OBSOLETE
                //
                //using (var adapter = new Data.PickControlTableAdapters.NTVContainerDocsTableAdapter())
                //    adapter.Fill(containers, this.UserID, this.UserLogin);

                if (containers.Count > 0)
                {
                    this.DocID = containers[0].doc_id;
                    this.BarCode = containers[0].bar_code;

                    RaiseOnOpen();
                }
                else
                {
                    RaiseOnOpen();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Open()
        {
            try
            {
                var barCode = this.ScanContainer("Отсканируйте контейнер НТВ,\r\nкоторый необходимо открыть", "Открытие контейнера НТВ");

                if (string.IsNullOrEmpty(barCode))
                    return false;

                var docID = (long?)null;

                using (var adapter = new Data.PickControlTableAdapters.NTVContainerDocsTableAdapter())
                    adapter.AddNTVContainerDoc(this.UserID, this.UserLogin, this.PC_DocID, barCode, ref docID);

                if (!docID.HasValue)
                    throw new Exception("Документ контейнера НТВ не создан.");

                this.DocID = docID.Value;
                this.BarCode = barCode;

                RaiseOnOpen();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public string ScanContainer(string label, string text)
        //{
        //    var barCode = (string)null;

        //    var dlgSurplusContainerScanner = new WMSOffice.Dialogs.Containers.ScanContainerForm()
        //    {
        //        Label = label,
        //        Text = text,
        //        Image = Properties.Resources.paper_box
        //    };

        //    if (dlgSurplusContainerScanner.ShowDialog() == DialogResult.OK)
        //        barCode = dlgSurplusContainerScanner.Barcode;

        //    return barCode;
        //}

        public override bool Close()
        {
            try
            {
                var barCode = this.ScanContainer("Отсканируйте контейнер НТВ,\r\nкоторый необходимо закрыть", "Закрытие контейнера НТВ");

                if (string.IsNullOrEmpty(barCode))
                    return false;

                var bossID = (int?)null;
                if (!ConfirmBoss(ref bossID))
                    return false;

                var statusID = "110"; // закрыт на столе

                using (var adapter = new Data.PickControlTableAdapters.NTVContainerDocsTableAdapter())
                {
                    adapter.SetTimeout((int)TimeSpan.FromSeconds(90).TotalSeconds);
                    adapter.ChangeNTVContainerDocStatus(this.UserID, barCode, this.UserLogin, statusID, this.BarCode);
                }

                this.DocID = (long?)null;
                this.BarCode = (string)null;

                RaiseOnClose();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Init(VarianceContainerDocInitParameters parameters)
        {
            var p = parameters as NTVContainerDocInitParameters;

            var barCode = (string)null;
            if (p.NeedScanContainer)
            {
                barCode = this.ScanContainer("Отсканируйте контейнер НТВ,\r\nс которым ведется работа", "Подтверждение контейнера НТВ");
                if (string.IsNullOrEmpty(barCode))
                    return false;
            }
            else
            {
                barCode = this.BarCode;
            }

            using (var adapter = new Data.PickControlTableAdapters.NTVContainerDocDetailsTableAdapter())
                adapter.AddNTVContainerDocDetail(this.UserID, this.UserLogin, this.DocID, p.ItemID, p.VendorLot, p.Quantity, p.UnitOfMeasure, this.PC_DocID, barCode);

            return true;
        }

        public override void Preview(long? PC_DocID)
        {
            using (var containerForm = new NTVContainerForm(this, VarianceContainerWorkMode.Preview, PC_DocID))
                containerForm.ShowDialog();
        }

        public override void Confirm()
        {
            using (var containerForm = new NTVContainerForm(this, VarianceContainerWorkMode.Confirm))
                containerForm.ShowDialog();
        }

        public override void PreviewForClose()
        {

        }

        public override bool CloseDirectly()
        {
            return false;
        }

        public override bool CheckContainer(string containerBarCode)
        {
            return false;
        }
    }

    public class NTVContainerDocInitParameters : VarianceContainerDocInitParameters
    {
        public int ItemID { get; set; }
        public string VendorLot { get; set; }
        public string UnitOfMeasure { get; set; }
        public int Quantity { get; set; }
        public bool NeedScanContainer { get; set; }
    }
}
