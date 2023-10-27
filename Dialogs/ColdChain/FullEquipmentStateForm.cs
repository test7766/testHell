using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Window;

namespace WMSOffice.Dialogs.ColdChain
{
    public partial class FullEquipmentStateForm : DialogForm
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        public FullEquipmentStateForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            btnOK.Location = new Point(1000, 8);
            btnCancel.Location = new Point(1090, 8);

            btnOK.Visible = false;
            btnCancel.Text = "Закрыть";

            this.Initialize();
            this.ReloadData();
        }

        private void Initialize()
        {
            xdgvItems.AllowSummary = false;

            xdgvItems.Init(new FullEquipmentStateView(), true);
            xdgvItems.UserID = this.UserID;

            xdgvItems.OnDataError += new DataGridViewDataErrorEventHandler(xdgvItems_OnDataError);
            xdgvItems.OnFilterChanged += new EventHandler(xdgvItems_OnFilterChanged);
        }

        void xdgvItems_OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        void xdgvItems_OnFilterChanged(object sender, EventArgs e)
        {
            xdgvItems.RecalculateSummary();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.ReloadData();
        }

        private void ReloadData()
        {
            try
            {
                var searchParams = new FullEquipmentStateSearchParameters() { SessionID = this.UserID };
                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    try
                    {
                        this.xdgvItems.DataView.FillData(e.Argument as FullEquipmentStateSearchParameters);
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                bw.RunWorkerCompleted += (s, e) =>
                {
                    if (e.Result is Exception)
                        MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        this.xdgvItems.BindData(false);

                        //this.xdgvItems.AllowFilter = true;
                        this.xdgvItems.AllowSummary = true;
                    }

                    splashForm.CloseForce();
                };

                splashForm.ActionText = "Выполняется получение списка статусов оборудования..";
                bw.RunWorkerAsync(searchParams);
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
