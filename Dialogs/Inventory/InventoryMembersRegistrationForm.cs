using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Inventory
{
    public partial class InventoryMembersRegistrationForm : DialogForm
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm waitProcessForm = new WMSOffice.Dialogs.SplashForm();

        /// <summary>
        /// Ид-р документа инвентаризации
        /// </summary>
        public long InventoryDocID { get; set; }

        /// <summary>
        /// Код даты инвентаризации (порядковый номер дня)
        /// </summary>
        public int? DateID { get; private set; }

        public InventoryMembersRegistrationForm()
        {
            InitializeComponent();
        }

        private void InventoryMembersRegistrationForm_Load(object sender, EventArgs e)
        {
            this.Initialize();
        }

        private void Initialize()
        {
            #region Формирование списка дат
            
            var bsDates = new BindingSource();
            bsDates.DataMember = "InventoryDates";
            bsDates.DataSource = new Data.Inventory();
            cmbDates.ComboBox.DisplayMember = "Date";
            cmbDates.ComboBox.ValueMember = "RN";
            cmbDates.ComboBox.DataSource = bsDates;

            try
            {
                using (var adapter = new Data.InventoryTableAdapters.InventoryDatesTableAdapter())
                      adapter.Fill(inventory.InventoryDates, this.UserID, this.InventoryDocID);

                bsDates.DataSource = inventory.InventoryDates;

                if (inventory.InventoryDates.Count > 0)
                    this.DateID = (int)inventory.InventoryDates[0].RN;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            cmbDates.ComboBox.SelectedValueChanged += delegate(object sender, EventArgs e)
            {
                this.DateID = Convert.ToInt32(cmbDates.ComboBox.SelectedValue);
                this.ReloadData();
            };
            
            #endregion

            this.tbScanEmployee.TextChanged += new EventHandler(tbScanEmployee_TextChanged);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.btnOK.Location = new Point(620, 8);
            this.btnCancel.Location = new Point(710, 8);
            this.btnCancel.Text = "Закрыть";

            this.ReloadData();         
        }

        private void sbRefresh_Click(object sender, EventArgs e)
        {
            this.ReloadData();
        }

        /// <summary>
        /// Перечитка данных
        /// </summary>
        private void ReloadData()
        {
            BackgroundWorker loadWorker = new BackgroundWorker();
            loadWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                   e.Result = this.inventoryNotRegisteredMembersTableAdapter.GetData(this.UserID, this.InventoryDocID, this.DateID);
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            };
            loadWorker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Result is Exception)
                    MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    this.inventoryNotRegisteredMembersBindingSource.DataSource = e.Result;

                waitProcessForm.CloseForce();
            };
            this.inventoryNotRegisteredMembersBindingSource.DataSource = null;
            waitProcessForm.ActionText = "Выполняется обновление списка незарегистрированных участников..";
            loadWorker.RunWorkerAsync();
            waitProcessForm.ShowDialog();

            tbScanEmployee.Focus();
        }

        void tbScanEmployee_TextChanged(object sender, EventArgs e)
        {
            this.RegisterMember();
        }

        /// <summary>
        /// Регистрация участника
        /// </summary>
        private void RegisterMember()
        {
            try
            {
                int memberID;
                if (!Int32.TryParse(tbScanEmployee.Text, out memberID))
                {
                    MessageBox.Show("Код сотрудника должен быть числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    using (var adapter = new Data.InventoryTableAdapters.RegisterMemberResultsTableAdapter())
                    {
                        var result = adapter.GetData(this.UserID, this.InventoryDocID, memberID, this.DateID);
                        if (result.Count > 0)
                        {
                            MessageBox.Show(result[0].StatusName.Replace("*", string.Format("\"{0} ({1})\"", result[0].Employee, result[0].Employee_ID)), "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.ReloadData();
                        }
                        else
                        {
                            MessageBox.Show("Сотрудник не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                tbScanEmployee.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
