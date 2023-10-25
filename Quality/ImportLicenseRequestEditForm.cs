using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Quality
{
    public partial class ImportLicenseRequestEditForm : DialogForm
    {
        private const string ITEMS_LIST_OPEN_CHARACTER = "(";
        private const string ITEMS_LIST_CLOSE_CHARACTER = ")";

        private readonly Data.Quality.QK_LI_LicRequestsRow _request = null;

        public new long UserID { get; set; }

        public int? RequestID { get { return this.IsEditMode ? _request.RequestID : (int?)null; } }

        public bool IsEditMode { get { return _request != null; } }
        public bool IsReadOnly { get; private set; }

        public ImportLicenseRequestEditForm()
        {
            InitializeComponent();
        }

        public ImportLicenseRequestEditForm(Data.Quality.QK_LI_LicRequestsRow request)
            : this()
        {
            _request = request;
            //this.IsReadOnly = this.IsEditMode;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            btnOK.Location = new Point(317, 8);
            btnCancel.Location = new Point(407, 8);

            this.Initialize();
        }

        private void Initialize()
        {
            try
            {
                qK_LI_Request_ReasonsTableAdapter.Fill(quality.QK_LI_Request_Reasons, this.UserID, null);
                cmbReasons.SelectedItem = null;

                qK_LI_Request_ProdTypesTableAdapter.Fill(quality.QK_LI_Request_ProdTypes, this.UserID, null);
                cmbProdTypes.SelectedItem = null;

                //qK_LI_Request_ReceiveAdditionsTableAdapter.Fill(quality.QK_LI_Request_ReceiveAdditions, this.UserID, null);
                //cmbReceiveAdditions.SelectedItem = null;

                //qK_LI_Request_ReceiveDecisionsTableAdapter.Fill(quality.QK_LI_Request_ReceiveDecisions, this.UserID, null);
                //cmbReceiveDecisions.SelectedItem = null;

                if (this.IsEditMode)
                {
                    this.Text = string.Format("Изменение уведомления № {0} на обновление лицензии на импорт {1}", _request.RequestID, this.IsReadOnly ? "[ТОЛЬКО ЧТЕНИЕ]" : string.Empty);

                    cmbReasons.SelectedValue = _request.ReasonID;
                    cmbProdTypes.SelectedValue = _request.ProdTypeID;
                    //cmbReceiveAdditions.SelectedValue = _request.ReceiveAdditionID;
                    //cmbReceiveDecisions.SelectedValue = _request.ReceiveDecisionID;

                    cmbReasons.DropDownStyle = ComboBoxStyle.Simple;
                    cmbReasons.Enabled = false;

                    tbAddedItems.Text = btnShowAddedItemsSelector.Enabled ? string.Format("{0}список{1}", ITEMS_LIST_OPEN_CHARACTER, ITEMS_LIST_CLOSE_CHARACTER) : string.Empty;
                    tbRemovedItems.Text = btnShowRemovedItemsSelector.Enabled ? string.Format("{0}список{1}", ITEMS_LIST_OPEN_CHARACTER, ITEMS_LIST_CLOSE_CHARACTER) : string.Empty;

                    if (this.IsReadOnly)
                    {
                        cmbProdTypes.DropDownStyle = ComboBoxStyle.Simple;
                        cmbProdTypes.Enabled = false;

                        //cmbReceiveAdditions.DropDownStyle = ComboBoxStyle.Simple;
                        //cmbReceiveAdditions.Enabled = false;

                        //cmbReceiveDecisions.DropDownStyle = ComboBoxStyle.Simple;
                        //cmbReceiveDecisions.Enabled = false;

                        btnOK.Visible = false;
                        btnCancel.Text = "Закрыть";

                        btnCancel.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void cmbReasons_SelectedValueChanged(object sender, EventArgs e)
        {
            tbAddedItems.BackColor = SystemColors.ControlLight;
            btnShowAddedItemsSelector.Enabled = false;

            tbRemovedItems.BackColor = SystemColors.ControlLight;
            btnShowRemovedItemsSelector.Enabled = false;

            tbResponsiblePerson.BackColor = SystemColors.ControlLight;
            btnShowResponsiblePersonsSelector.Enabled = false;

            tbVendor.BackColor = SystemColors.ControlLight;
            btnShowVendorsSelector.Enabled = false;

            if (cmbReasons.SelectedValue == null)
                return;

            var reasonID = (RequestReasons)cmbReasons.SelectedValue;
            switch (reasonID)
            {
                case RequestReasons.ChangeLicItems:
                    tbAddedItems.BackColor = SystemColors.Window;
                    btnShowAddedItemsSelector.Enabled = true;

                    tbRemovedItems.BackColor = SystemColors.Window;
                    btnShowRemovedItemsSelector.Enabled = true;
                    break;
                case RequestReasons.AddLicItems:
                    tbAddedItems.BackColor = SystemColors.Window;
                    btnShowAddedItemsSelector.Enabled = true;
                    break;
                case RequestReasons.ChangeResponsiblePerson:
                    tbResponsiblePerson.BackColor = SystemColors.Window;
                    btnShowResponsiblePersonsSelector.Enabled = true;
                    break;
                case RequestReasons.ChangeVendorInformation:
                    tbVendor.BackColor = SystemColors.Window;
                    btnShowVendorsSelector.Enabled = true;
                    break;
                default:
                    break;
            }
        }

        private void btnShowAddedItemsSelector_Click(object sender, EventArgs e)
        {
            this.ShowAddedItemsSelector();
        }

        private void ShowAddedItemsSelector()
        {
            try
            {
                var items = tbAddedItems.Text.Contains(ITEMS_LIST_OPEN_CHARACTER) ? string.Empty : tbAddedItems.Text;
                if (this.GetItemsFromSelector(ref items, RequestCreateMode.AddItems))
                    tbAddedItems.Text = items;

                //var dlgImportLicenseRequestItemsSelector = new ImportLicenseRequestItemsSelectorForm(this.RequestID) { UserID = this.UserID, SelectedItems = tbAddedItems.Text, RequestCreateMode = RequestCreateMode.AddItems };
                //if (dlgImportLicenseRequestItemsSelector.ShowDialog() == DialogResult.OK)
                //{
                //    tbAddedItems.Text = dlgImportLicenseRequestItemsSelector.SelectedItems;
                //}
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnShowRemovedItemsSelector_Click(object sender, EventArgs e)
        {
            this.ShowRemovedItemsSelector();
        }

        private void ShowRemovedItemsSelector()
        {
            try
            {
                var items = tbRemovedItems.Text.Contains(ITEMS_LIST_OPEN_CHARACTER) ? string.Empty : tbRemovedItems.Text;
                if (this.GetItemsFromSelector(ref items, RequestCreateMode.RemoveItems))
                    tbRemovedItems.Text = items;

                //var dlgImportLicenseRequestItemsSelector = new ImportLicenseRequestItemsSelectorForm(this.RequestID) { UserID = this.UserID, SelectedItems = tbRemovedItems.Text, RequestCreateMode = RequestCreateMode.RemoveItems };
                //if (dlgImportLicenseRequestItemsSelector.ShowDialog() == DialogResult.OK)
                //{
                //    tbRemovedItems.Text = dlgImportLicenseRequestItemsSelector.SelectedItems;
                //}
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private bool GetItemsFromSelector(ref string items, RequestCreateMode mode)
        {
            var dlgImportLicenseRequestItemsSelector = new ImportLicenseRequestItemsSelectorForm(this.RequestID) { UserID = this.UserID, SelectedItems = items, RequestCreateMode = mode };
            if (dlgImportLicenseRequestItemsSelector.ShowDialog() == DialogResult.OK)
            {
                items = dlgImportLicenseRequestItemsSelector.SelectedItems;
                return true;
            }

            return false;
        }

        private void btnShowResponsiblePersonsSelector_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnShowVendorsSelector_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void ShowError(Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ImportLicenseRequestEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveLicenseRequest();
        }

        private bool SaveLicenseRequest()
        {
            try
            {
                if (cmbReasons.SelectedValue == null)
                    throw new Exception("Не выбрана причина.");

                if (cmbProdTypes.SelectedValue == null)
                    throw new Exception("Не выбран тип продукции.");

                //if (cmbReceiveAdditions.SelectedValue == null)
                //    throw new Exception("Не выбрано получение дополнения.");

                //if (cmbReceiveDecisions.SelectedValue == null)
                //    throw new Exception("Не выбрано получение решения.");

                var reasonID = Convert.ToInt32(cmbReasons.SelectedValue);
                var prodTypeID = Convert.ToInt32(cmbProdTypes.SelectedValue);
                var receiveAdditionID = (int?)null; // Convert.ToInt32(cmbReceiveAdditions.SelectedValue);
                var receiveDecisionID = (int?)null; // Convert.ToInt32(cmbReceiveDecisions.SelectedValue);

                if (((RequestReasons)reasonID).Equals(RequestReasons.ChangeLicItems) && string.IsNullOrEmpty(tbAddedItems.Text) && string.IsNullOrEmpty(tbRemovedItems.Text))
                    throw new Exception("Не выбраны товары.");

                if (((RequestReasons)reasonID).Equals(RequestReasons.AddLicItems) && string.IsNullOrEmpty(tbAddedItems.Text))
                    throw new Exception("Не выбраны товары.");

                if (((RequestReasons)reasonID).Equals(RequestReasons.ChangeResponsiblePerson) && tbResponsiblePerson.Tag == null)
                    throw new Exception("Не выбрано уполномоченное лицо.");

                if (((RequestReasons)reasonID).Equals(RequestReasons.ChangeVendorInformation) && tbVendor.Tag == null)
                    throw new Exception("Не выбран поставщик.");


                var itemsToAddition = (tbAddedItems.Text.Contains(ITEMS_LIST_OPEN_CHARACTER) ? string.Empty : tbAddedItems.Text).Replace(" ", "");
                var itemsToDeletion = (tbRemovedItems.Text.Contains(ITEMS_LIST_OPEN_CHARACTER) ? string.Empty : tbRemovedItems.Text).Replace(" ", "");

                if (string.IsNullOrEmpty(itemsToAddition))
                    itemsToAddition = (string)null;

                if (string.IsNullOrEmpty(itemsToDeletion))
                    itemsToDeletion = (string)null;

                var responsiblePersonID = ((RequestReasons)reasonID).Equals(RequestReasons.ChangeResponsiblePerson) ? Convert.ToInt32(tbResponsiblePerson.Tag) : (int?)null;
                var vendorID = ((RequestReasons)reasonID).Equals(RequestReasons.ChangeVendorInformation) ? Convert.ToInt32(tbVendor.Tag) : (int?)null;

                using (var adapter = new Data.QualityTableAdapters.QK_LI_LicRequestsTableAdapter())
                    adapter.ModifyRequest(this.UserID, this.RequestID, reasonID, prodTypeID, receiveAdditionID, receiveDecisionID, itemsToAddition, itemsToDeletion, responsiblePersonID, vendorID);

                return true;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
                return false;
            }
        }
    }

    public enum RequestReasons
    { 
        ChangeLicItems = 1,
        AddLicItems = 2,
        ChangeResponsiblePerson = 3,
        ChangeVendorInformation = 4
    }
}
