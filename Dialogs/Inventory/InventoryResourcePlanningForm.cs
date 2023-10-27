using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Xml;

namespace WMSOffice.Dialogs.Inventory
{
    public partial class InventoryResourcePlanningForm : DialogForm
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
        /// Ид-р типа инвентаризации
        /// </summary>
        public string InventoryFI_Type { get; set; }

        /// <summary>
        /// Режим отображения закрепленных ресурсов (только закрепленные / все)
        /// </summary>
        CheckBox cbShowOnlyNotCompleted = null;

        /// <summary>
        /// Ркжим отображения свободных ресурсов (только свободные / все)
        /// </summary>
        CheckBox cbShowOnlyFree = null;

        /// <summary>
        /// Признак использования частичного планирования ресурсов (без привязки бригад)
        /// </summary>
        public bool UsePartialMode { get; set; }

        /// <summary>
        /// Режим процесса из обновленной модели
        /// </summary>
        public bool UpgradeMode { get; set; }

        public InventoryResourcePlanningForm()
        {
            InitializeComponent();
        }

        private void InventoryResourcePlanningForm_Load(object sender, EventArgs e)
        {
            this.Initialize();
        }      

        /// <summary>
        /// Инициализация
        /// </summary>
        private void Initialize()
        {
            cbShowOnlyNotCompleted = new CheckBox();
            cbShowOnlyNotCompleted.Text = "Отобразить только не укомплектованные бригады";
            cbShowOnlyNotCompleted.RightToLeft = RightToLeft.Yes;
            cbShowOnlyNotCompleted.Checked = true;
            cbShowOnlyNotCompleted.CheckedChanged += delegate(object sender, EventArgs e)
            {
               // this.LoadAssignedResources(cbShowOnlyNotCompleted.Checked);
                this.RefreshAssignedResources();
            };

            ToolStripControlHost hostShowAll = new ToolStripControlHost(cbShowOnlyNotCompleted);
            tsAssignedResourcesToolBar.Items.Add(hostShowAll);

            cbShowOnlyFree = new CheckBox();
            cbShowOnlyFree.Text = "Отобразить только доступные ресурсы";
            cbShowOnlyFree.RightToLeft = RightToLeft.Yes;
            cbShowOnlyFree.Checked = true;
            cbShowOnlyFree.CheckedChanged += delegate(object sender, EventArgs e)
            {
                // this.LoadFreeResources(cbShowOnlyFree.Checked);
                this.RefreshFreeResources();
            };

            ToolStripControlHost hostShowOnlyFree = new ToolStripControlHost(cbShowOnlyFree);
            tsFreeResourcesToolBar.Items.Add(hostShowOnlyFree);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.btnOK.Location = new Point(1320, 8);
            this.btnCancel.Location = new Point(1410, 8);
            this.btnOK.Text = "Контроль";
            this.btnCancel.Text = "Закрыть";

            if (this.UsePartialMode)
            {
                sbGenerateTeams.Visible = false;
                sbLinkZoneToTeam.Visible = false;

                this.btnOK.Enabled = false;
                this.btnOK.Visible = false;
            }
            else
            {
                tsImportSeparator.Visible = false;
                sbImportResources.Visible = false;
                tsEditSeparator.Visible = false;
                sbEditResource.Visible = false;
                sbDeleteResource.Visible = false;
            }

            this.Text = string.Format("{0} (инвентаризация № {1})", this.Text, this.InventoryDocID);

            this.ChangeOperationAccessability();

            this.xdgvAssignedResources.SetSameStyleForAlternativeRows();
            this.xdgvAssignedResources.AllowSummary = false;
            this.xdgvAssignedResources.AllowRangeColumns = true;
            this.xdgvAssignedResources.UserID = this.UserID;      
            this.xdgvAssignedResources.Init(new AssignedResourcesView(), true);
            this.xdgvAssignedResources.LoadExtraDataGridViewSettings(this.Name + "1");         
            xdgvAssignedResources.OnRowSelectionChanged += new EventHandler(xdgvAssignedResources_OnRowSelectionChanged);
            xdgvAssignedResources.OnFilterChanged += new EventHandler(xdgvAssignedResources_OnFilterChanged);
            xdgvAssignedResources.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvAssignedResources_OnFormattingCell);

            this.xdgvFreeResources.SetSameStyleForAlternativeRows();
            this.xdgvFreeResources.AllowSummary = false;
            this.xdgvFreeResources.AllowRangeColumns = true;
            this.xdgvFreeResources.UserID = this.UserID;
            this.xdgvFreeResources.Init(new FreeResourcesView(), true);
            this.xdgvFreeResources.LoadExtraDataGridViewSettings(this.Name + "2");
            xdgvFreeResources.OnRowSelectionChanged += new EventHandler(xdgvFreeResources_OnRowSelectionChanged);
            xdgvFreeResources.OnFilterChanged += new EventHandler(xdgvFreeResources_OnFilterChanged);
            xdgvFreeResources.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvFreeResources_OnFormattingCell);
            xdgvFreeResources.OnRowDoubleClick += new DataGridViewCellEventHandler(xdgvFreeResources_OnRowDoubleClick);

            this.RefreshData();
        }

        #region ОБРАБОТЧИКИ ЗАКРЕПЛЕННЫХ РЕСУРСОВ
        void xdgvAssignedResources_OnFilterChanged(object sender, EventArgs e)
        {
            this.xdgvAssignedResources.RecalculateSummary();
            sbExportToExcel.Enabled = this.xdgvAssignedResources.HasRows;
        }

        void xdgvAssignedResources_OnRowSelectionChanged(object sender, EventArgs e)
        {
            this.ChangeOperationAccessability();
        }

        void xdgvAssignedResources_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grid = sender as DataGridView;

            if (grid.Columns[e.ColumnIndex].DataPropertyName == "Percente")
            {
                object value = grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (value != null && value != DBNull.Value)
                {
                    decimal percent;
                    if (decimal.TryParse(value.ToString(), out percent))
                    {
                        e.Value = string.Format("{0} %", percent);

                        if (percent == 0)
                        {
                            e.CellStyle.BackColor = Color.FromArgb(255, 225, 225);
                            e.CellStyle.SelectionBackColor = Color.FromArgb(255, 225, 225);
                            e.CellStyle.ForeColor = Color.Black;
                            e.CellStyle.SelectionForeColor = Color.Black;
                            return;
                        }

                        if (percent == 100)
                        {
                            e.CellStyle.BackColor = Color.FromArgb(209, 255, 117);
                            e.CellStyle.SelectionBackColor = Color.FromArgb(209, 255, 117);
                            e.CellStyle.ForeColor = Color.Black;
                            e.CellStyle.SelectionForeColor = Color.Black;
                            return;
                        }

                        if (percent > 0 && percent < 100)
                        {

                            e.CellStyle.BackColor = Color.FromArgb(255, 255, 153);
                            e.CellStyle.SelectionBackColor = Color.FromArgb(255, 255, 153);
                            e.CellStyle.ForeColor = Color.Black;
                            e.CellStyle.SelectionForeColor = Color.Black;
                            return;
                        }
                    }
                }
            }
        }
        #endregion

        #region ОБРАБОТЧИКИ СВОБОДНЫХ РЕСУРСОВ
        void xdgvFreeResources_OnFilterChanged(object sender, EventArgs e)
        {
            this.xdgvFreeResources.RecalculateSummary();
        }

        void xdgvFreeResources_OnRowSelectionChanged(object sender, EventArgs e)
        {
            this.ChangeOperationAccessability();
        }

        void xdgvFreeResources_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grid = sender as DataGridView;

            DataRow row = (grid.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;
            
            #region СТИЛЬ ДЛЯ РЕСУРСОВ, КОТ. НЕДОСТУПНЫЕ
            if (row["ISFree"] != DBNull.Value)
            {
                decimal value;
                if (Decimal.TryParse(row["ISFree"].ToString(), out value))
                {
                   if (value == 0)
                   {
                       grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Gray;
                       grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionBackColor = Color.Gray;
                   }
                }
            }
            #endregion
        }
        #endregion

        /// <summary>
        /// Изменить доступность операций
        /// </summary>
        private void ChangeOperationAccessability()
        {
            sbAssignEmployee.Enabled = false;
            sbCancelEmployee.Enabled = false;
            sbDeleteTeam.Enabled = false;
            sbLinkZoneToTeam.Enabled = false;

            sbEditResource.Enabled = false;
            sbDeleteResource.Enabled = false;

            var assignedResourceRow = xdgvAssignedResources.SelectedItem;
            var freeResourceRow = xdgvFreeResources.SelectedItem;

            if (freeResourceRow != null)
            {
                if (Convert.ToDecimal(freeResourceRow["ISFree"]) == 1)
                {
                    sbEditResource.Enabled = true;
                    sbDeleteResource.Enabled = true;
                }
            }

            // если не выбрана строка из закрепленных ресурсов, то не закрепить не снять ресурс нельзя
            if (assignedResourceRow == null)
                return;

            // Добавляем возможность удаления бригады
            sbDeleteTeam.Enabled = true;

            // Добавляем возможность привязывать зону к бригаде
            sbLinkZoneToTeam.Enabled = true;

            // если нет закрепления, то проверяем дальше совместимость типов
            if (assignedResourceRow["Resource_ID"] == null || string.IsNullOrEmpty(assignedResourceRow["Resource_ID"].ToString()))
            {
                // есле не выбран свободный ресурс, то закрепить его нельзя
                if (freeResourceRow == null)
                    return;

                var assignedResourceTypeID = Convert.ToInt32(assignedResourceRow["EUnit_ID"]);
                var freeResourceTypeID = Convert.ToInt32(freeResourceRow["Establish_ID"]);

                // если типы ресурсов совместимы, то проверяем дальше доступность ресурса
                if (assignedResourceTypeID == freeResourceTypeID)
                {

                    // ресурс доступен - можно назначать его
                    if (Convert.ToDecimal(freeResourceRow["ISFree"]) != 0)
                    {
                        sbAssignEmployee.Enabled = true;
                    }
                }
            }
            // ресурс есть в закреплении - его можно снять 
            else
            {
                sbCancelEmployee.Enabled = true;
            }
        }

        /// <summary>
        /// Обновление данных
        /// </summary>
        private void RefreshData()
        {
            this.RefreshAssignedResources();
            this.RefreshFreeResources();
        }

        /// <summary>
        /// Обновление закрепленных ресурсов
        /// </summary>
        private void RefreshAssignedResources()
        {
            this.LoadAssignedResources(this.cbShowOnlyNotCompleted.Checked);
        }

        /// <summary>
        /// Обновление свободных ресурсов
        /// </summary>
        private void RefreshFreeResources()
        {
            this.LoadFreeResources(this.cbShowOnlyFree.Checked);
        }

        /// <summary>
        /// Загрузка закрепленных ресурсов
        /// </summary>
        /// <param name="showAll"></param>
        private void LoadAssignedResources(bool showOnlyNotCompleted)
        {
            this.xdgvAssignedResources.Focus();

            BackgroundWorker loadWorker = new BackgroundWorker();

            var searchCriteria = new AssignedResourcesSearchParameters();
            searchCriteria.UserID = this.UserID;
            searchCriteria.InventoryDocID = this.InventoryDocID;
            searchCriteria.ShowAll = !showOnlyNotCompleted;
            searchCriteria.UpgradeMode = this.UpgradeMode;


            loadWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    this.xdgvAssignedResources.DataView.FillData(searchCriteria);
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
                {
                    this.xdgvAssignedResources.BindData(false);

                    //this.xdgvResult.AllowFilter = true;
                    this.xdgvAssignedResources.AllowSummary = true;
                }

                waitProcessForm.CloseForce();
            };

            waitProcessForm.ActionText = "Выполняется загрузка необходимых ресурсов..";
            loadWorker.RunWorkerAsync();
            waitProcessForm.ShowDialog();
        }

        /// <summary>
        /// Загрузка свободных ресурсов
        /// </summary>
        /// <param name="showOnlyFree"></param>
        private void LoadFreeResources(bool showOnlyFree)
        {
            this.xdgvFreeResources.Focus();

            BackgroundWorker loadWorker = new BackgroundWorker();

            var searchCriteria = new FreeResourcesSearchParameters();
            searchCriteria.UserID = this.UserID;
            searchCriteria.InventoryDocID = this.InventoryDocID; // "530";
            searchCriteria.ShowOnlyFree = showOnlyFree;
            searchCriteria.UpgradeMode = this.UpgradeMode;

            loadWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    this.xdgvFreeResources.DataView.FillData(searchCriteria);
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
                {
                    this.xdgvFreeResources.BindData(false);

                    //this.xdgvResult.AllowFilter = true;
                    this.xdgvFreeResources.AllowSummary = true;
                }

                waitProcessForm.CloseForce();
            };

            waitProcessForm.ActionText = "Выполняется загрузка доступных ресурсов..";
            loadWorker.RunWorkerAsync();
            waitProcessForm.ShowDialog();
        }

        /// <summary>
        /// Назначение ресурса
        /// </summary>
        private void sbAssignEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                string resource_id = this.xdgvFreeResources.SelectedItem["Resource_ID"].ToString();
                int team_id = Convert.ToInt32(this.xdgvAssignedResources.SelectedItem["Team_ID"]);
                int unit_id = Convert.ToInt32(this.xdgvFreeResources.SelectedItem["Establish_ID"]);

                using (Data.InventoryTableAdapters.QueriesTableAdapter adapter = new WMSOffice.Data.InventoryTableAdapters.QueriesTableAdapter())
                {
                    if (this.UpgradeMode)
                        adapter.AssignResourceToTeamUpg(this.UserID, this.InventoryDocID, resource_id, team_id, unit_id);
                    else
                        adapter.AssignResourceToTeam(this.UserID, this.InventoryDocID, resource_id, team_id, unit_id);
                }

                this.RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Снять ресурс с назначения
        /// </summary>
        private void sbCancelEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                long team_id = Convert.ToInt64(this.xdgvAssignedResources.SelectedItem["Team_ID"]);
                string resource_id = this.xdgvAssignedResources.SelectedItem["Resource_ID"].ToString();
                int unit_id = Convert.ToInt32(this.xdgvAssignedResources.SelectedItem["EUnit_ID"]);

                using (Data.InventoryTableAdapters.QueriesTableAdapter adapter = new WMSOffice.Data.InventoryTableAdapters.QueriesTableAdapter())
                {
                    if (this.UpgradeMode)
                        adapter.FreeResourceFromTeamUpg(this.UserID, team_id, resource_id, unit_id);
                    else
                        adapter.FreeResourceFromTeam(this.UserID, team_id, resource_id, unit_id);
                }

                this.RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }          
        }

        private void sbExportToExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlgSelectFile = new SaveFileDialog())
            {
                dlgSelectFile.Title = "Экспорт необходимых ресурсов";

                DateTime now = DateTime.Now;
                dlgSelectFile.FileName = string.Format("{0}{1}{2}{3}{4}{5}-перечень необходимых ресурсов",
                    now.Year.ToString(),
                    now.Month.ToString().PadLeft(2, '0'),
                    now.Day.ToString().PadLeft(2, '0'),
                    now.Hour.ToString().PadLeft(2, '0'),
                    now.Minute.ToString().PadLeft(2, '0'),
                    now.Second.ToString().PadLeft(2, '0')
                    );

                dlgSelectFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                dlgSelectFile.Filter = "Текстовый файл с разделителями (*.csv)|*.csv";//;*.csv|Все файлы (*.*)|*.*";
                dlgSelectFile.FilterIndex = 0;
                dlgSelectFile.AddExtension = true;
                dlgSelectFile.DefaultExt = "csv";
                if (dlgSelectFile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        this.xdgvAssignedResources.ExportToExcel(dlgSelectFile.FileName);
                        Process.Start(dlgSelectFile.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void InventoryResourcePlanningForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                this.ShowAssignedResourcesStatistics();
                e.Cancel = true;
                return;
            }

            this.xdgvAssignedResources.SaveExtraDataGridViewSettings(this.Name + "1");
            this.xdgvFreeResources.SaveExtraDataGridViewSettings(this.Name + "2"); 
        }

        /// <summary>
        /// Отображение информации о комплектации бригад ресурсами
        /// </summary>
        private void ShowAssignedResourcesStatistics()
        {
            var dlgStatistics = new InventoryControlResourcePlanningForm() { InventoryDocID = this.InventoryDocID, UserID = this.UserID };
            dlgStatistics.ShowDialog();
        }

        /// <summary>
        /// Добавить бригаду
        /// </summary>
        private void sbAddTeam_Click(object sender, EventArgs e)
        {
            var dlgAddTeam = new InventoryResourcePlanningAddTeamForm() { UserID = this.UserID, InventoryDocID = this.InventoryDocID, UpgradeMode = this.UpgradeMode };
            if (dlgAddTeam.ShowDialog() == DialogResult.OK)
                this.RefreshAssignedResources();
        }

        /// <summary>
        /// Удалить бригаду
        /// </summary>
        private void sbDeleteTeam_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Вы действительно хотите удалить бригаду?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    long teamID = Convert.ToInt64(this.xdgvAssignedResources.SelectedItem["Team_ID"]);
                    using (Data.InventoryTableAdapters.QueriesTableAdapter adapter = new WMSOffice.Data.InventoryTableAdapters.QueriesTableAdapter())
                    {
                        if (this.UpgradeMode)
                            adapter.DeleteTeamUpg(this.UserID, this.InventoryDocID, teamID);
                        else
                            adapter.DeleteTeam(this.UserID, this.InventoryDocID, teamID);
                    }

                    this.RefreshAssignedResources();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Формирование бригад
        /// </summary>
        private void sbGenerateTeams_Click(object sender, EventArgs e)
        {
            var dlgGenerateTeam = new InventoryResourcePlanningGenerateTeamsForm() { UserID = this.UserID, InventoryDocID = this.InventoryDocID };
            if (dlgGenerateTeam.ShowDialog() == DialogResult.OK)
                this.RefreshAssignedResources();
        }

        /// <summary>
        /// Привязка зоны к бригаде
        /// </summary>
        private void sbLinkZoneToTeam_Click(object sender, EventArgs e)
        {
            long teamID = Convert.ToInt64(this.xdgvAssignedResources.SelectedItem["Team_ID"]);
            var dlgLinkZoneToTeam = new LinkZoneToTeamForm() { UserID = this.UserID, InventoryDocID = this.InventoryDocID, TeamID = teamID };
            if (dlgLinkZoneToTeam.ShowDialog() == DialogResult.OK)
                this.RefreshAssignedResources();
        }

        /// <summary>
        /// Импорт ресурсов
        /// </summary>
        private void sbImportResources_Click(object sender, EventArgs e)
        {
            try
            {
                var sText = Clipboard.GetText() ?? string.Empty;
                if (string.IsNullOrEmpty(sText.Trim()))
                    throw new Exception("Отсутствуют данные для импорта.");

                var importCompleted = false;

                var importWorker = new BackgroundWorker();
                importWorker.DoWork += delegate(object snd, DoWorkEventArgs ea)
                {
                    try
                    {
                        var text = ea.Argument.ToString();

                        var doc = new XmlDocument();
                        var root = (XmlElement)doc.AppendChild(doc.CreateElement("Root"));

                        foreach (var line in text.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            var cells = line.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                            if (cells.Length >= 2)
                            {
                                int resourceID;
                                if (!int.TryParse(cells[0], out resourceID))
                                    throw new Exception("Код ресурса должен быть числом.");

                                int establishID;
                                if (!int.TryParse(cells[1], out establishID))
                                    throw new Exception("Код типа ресурса должен быть числом.");

                                var node = (XmlElement)root.AppendChild(doc.CreateElement("Item"));
                                node.SetAttribute("ResourceID", resourceID.ToString());
                                node.SetAttribute("EstablishID", establishID.ToString());
                            }
                            else
                                throw new Exception("Неверная структура импортируемых данных.");
                        }

                        using (var adapter = new Data.InventoryTableAdapters.QueriesTableAdapter())
                        {
                            if (this.UpgradeMode)
                                adapter.ImportResourcesUpg(this.UserID, this.InventoryDocID, this.InventoryFI_Type, doc.InnerXml);
                            else
                                adapter.ImportResources(this.UserID, this.InventoryDocID, this.InventoryFI_Type, doc.InnerXml);
                        }
                    }
                    catch (Exception ex)
                    {
                        ea.Result = ex;
                    }
                };

                importWorker.RunWorkerCompleted += delegate(object snd, RunWorkerCompletedEventArgs ea)
                {
                    if (ea.Result is Exception)
                        MessageBox.Show((ea.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        importCompleted = true;

                    waitProcessForm.CloseForce();
                };

                waitProcessForm.ActionText = "Выполняется импорт ресурсов с буфера обмена..";
                importWorker.RunWorkerAsync(sText);
                waitProcessForm.ShowDialog();

                if (importCompleted)
                    RefreshFreeResources();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sbDeleteResource_Click(object sender, EventArgs e)
        {
            try
            {
                var freeResourceRow = xdgvFreeResources.SelectedItem;
                var id = Convert.ToInt32(freeResourceRow["ID"]);

                using (var adapter = new Data.InventoryTableAdapters.QueriesTableAdapter())
                {
                    if (this.UpgradeMode)
                        adapter.DeleteResourceFromInventoryUpg(this.UserID, this.InventoryDocID, this.InventoryFI_Type, id);
                    else
                        adapter.DeleteResourceFromInventory(this.UserID, this.InventoryDocID, this.InventoryFI_Type, id);
                }

                RefreshFreeResources();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sbEditResource_Click(object sender, EventArgs e)
        {
            this.EditResource();
        }

        void xdgvFreeResources_OnRowDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sbEditResource.Visible && sbEditResource.Enabled)
                this.EditResource();
        }

        private void EditResource()
        {
            try
            {
                var freeResourceRow = xdgvFreeResources.SelectedItem;
                var id = Convert.ToInt32(freeResourceRow["ID"]);

                var dlgSelectUnit = new WMSOffice.Dialogs.RichListForm();
                dlgSelectUnit.Text = "Выберите роль (тип ресурса)";
                dlgSelectUnit.AddColumn("establish_id", "establish_id", "Код");
                dlgSelectUnit.AddColumn("establish_name", "establish_name", "Наименование");
                dlgSelectUnit.FilterChangeLevel = 0;
                dlgSelectUnit.FilterVisible = false;

                var table = new Data.Inventory.ResourceEstablishUnitsDataTable();

                using (var adapter = new Data.InventoryTableAdapters.ResourceEstablishUnitsTableAdapter())
                {
                    if (this.UpgradeMode)
                        adapter.FillUpg(table, this.UserID, this.InventoryDocID, this.InventoryFI_Type);
                    else
                        adapter.Fill(table, this.UserID, this.InventoryDocID, this.InventoryFI_Type);
                }

                dlgSelectUnit.DataSource = table;

                if (dlgSelectUnit.ShowDialog() != DialogResult.OK)
                    return;

                var establishID = (dlgSelectUnit.SelectedRow as Data.Inventory.ResourceEstablishUnitsRow).establish_id;

                using (var adapter = new Data.InventoryTableAdapters.QueriesTableAdapter())
                {
                    if (this.UpgradeMode)
                        adapter.EditResourceEstablishForInventoryUpg(this.UserID, this.InventoryDocID, this.InventoryFI_Type, id, establishID);
                    else
                        adapter.EditResourceEstablishForInventory(this.UserID, this.InventoryDocID, this.InventoryFI_Type, id, establishID);
                }

                RefreshFreeResources();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    #region ЗАКРЕПЛЕННЫЕ РЕСУРСЫ
    /// <summary>
    /// Представление для закрепленных ресурсов
    /// </summary>
    public class AssignedResourcesView : IDataView
    {
        /// <summary>
        /// Время ожидания выполнения запроса
        /// </summary>
        private const int DEFAULT_RESPONSE_TIMEOUT = 300;

        #region IDataView Members

        private PatternColumnsCollection dataColumns = new PatternColumnsCollection();
        public PatternColumnsCollection Columns
        {
            get { return this.dataColumns; }
        }

        private DataTable data;
        public DataTable Data
        {
            get { return this.data; }
        }

        /// <summary>
        /// Поиск конечной выборки согласно критериям
        /// </summary>
        /// <param name="searchParameters">Критерии поиска</param>
        public void FillData(SearchParametersBase searchParameters)
        {
            var searchCriteria = searchParameters as AssignedResourcesSearchParameters;

            var spName = searchCriteria.UpgradeMode ? "[dbo].[pr_FI_Res_Select_Team]" : "[dbo].[pr_IV_GetTeam]";

            string query = string.Format("EXEC {0} {1}, {2}, {3}",
                spName,
                searchCriteria.UserID,
                searchCriteria.InventoryDocID, 
                searchCriteria.ShowAll);

            SqlDataAdapter adapter = new SqlDataAdapter(query, new SqlConnection(Properties.Settings.Default.JDE_PROCConnectionString));
            adapter.SelectCommand.CommandTimeout = DEFAULT_RESPONSE_TIMEOUT;
            //adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            var dataSet = new DataSet();
            adapter.Fill(dataSet);
            this.data = dataSet.Tables[0];
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ
        public AssignedResourcesView()
        {
            this.dataColumns.Add(new PatternColumn("% уком.", "Percente", new FilterCompareExpressionRule<Int32>("Percente")) { Width = 40 });
            this.dataColumns.Add(new PatternColumn("№ бриг.", "Team_ID", new FilterCompareExpressionRule<Int64>("Team_ID")) { Width = 40 });
            this.dataColumns.Add(new PatternColumn("Тип бригады", "TeamName", new FilterPatternExpressionRule("TeamName")) { Width = 220 });
            //this.dataColumns.Add(new PatternColumn("Zone_ID", "Zone_ID"));
            this.dataColumns.Add(new PatternColumn("Приор. зона бригады", "ZoneName", new FilterPatternExpressionRule("ZoneName")) { Width = 190 });
            this.dataColumns.Add(new PatternColumn("Код типа ресурса", "EUnit_ID", new FilterCompareExpressionRule<Int32>("EUnit_ID")) { Width = 60 });
            this.dataColumns.Add(new PatternColumn("Тип ресурса", "StaffName", new FilterPatternExpressionRule("StaffName")) { Width = 100 });

            this.dataColumns.Add(new PatternColumn("Код ресурса", "Resource_ID", new FilterPatternExpressionRule("Resource_ID")) { Width = 60 });
            this.dataColumns.Add(new PatternColumn("Ресурс", "ResourceName", new FilterPatternExpressionRule("ResourceName")) { Width = 170 });
            this.dataColumns.Add(new PatternColumn("Кол-во", "Quantity", new FilterCompareExpressionRule<Decimal>("Quantity"), SummaryCalculationType.Sum) { Width = 50 });
            this.dataColumns.Add(new PatternColumn("ЕИ", "Unit", new FilterPatternExpressionRule("Unit")) { Width = 30 });            

            //this.dataColumns.Add(new PatternColumn("ResourceZone_ID", "ResourceZone_ID"));
            this.dataColumns.Add(new PatternColumn("Приор. зона ресурса", "ResourceZone", new FilterPatternExpressionRule("ResourceZone")) { Width = 190 });



            //this.dataColumns.Add(new PatternColumn("Сумма заказа (без НДС)", "Amount", SummaryCalculationType.Sum) { Width = 100, UseDecimalNumbersAlignement = true });
            //this.dataColumns.Add(new PatternColumn("НДС", "AmountVAT", SummaryCalculationType.Sum) { Width = 100, UseDecimalNumbersAlignement = true });
        }
        #endregion
    }

    /// <summary>
    /// Критерий поиска для закрепленных ресурсов
    /// </summary>
    public class AssignedResourcesSearchParameters : SearchParametersBase
    {
        public long UserID { get; set; }
        public long InventoryDocID { get; set; }
        public bool ShowAll { get; set; }

        /// <summary>
        /// Режим процесса из обновленной модели
        /// </summary>
        public bool UpgradeMode { get; set; }
    }
    #endregion

    #region СВОБОДНЫЕ РЕСУРСЫ
    /// <summary>
    /// Представление для свободных ресурсов
    /// </summary>
    public class FreeResourcesView : IDataView
    {
        /// <summary>
        /// Время ожидания выполнения запроса
        /// </summary>
        private const int DEFAULT_RESPONSE_TIMEOUT = 300;

        #region IDataView Members
        private PatternColumnsCollection dataColumns = new PatternColumnsCollection();
        public PatternColumnsCollection Columns
        {
            get { return this.dataColumns; }
        }

        private DataTable data;
        public DataTable Data
        {
            get { return this.data; }
        }

        public void FillData(SearchParametersBase searchParameters)
        {
            var searchCriteria = searchParameters as FreeResourcesSearchParameters;

            var spName = searchCriteria.UpgradeMode ? "[dbo].[pr_FI_Res_Select_Resource]" : "[dbo].[pr_IV_GetResource]";

            string query = string.Format("EXEC {0} {1}, {2}, {3}",
                spName,
                searchCriteria.UserID,
                searchCriteria.InventoryDocID,
                searchCriteria.ShowOnlyFree);

            SqlDataAdapter adapter = new SqlDataAdapter(query, new SqlConnection(Properties.Settings.Default.JDE_PROCConnectionString));
            adapter.SelectCommand.CommandTimeout = DEFAULT_RESPONSE_TIMEOUT;
            //adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            var dataSet = new DataSet();
            adapter.Fill(dataSet);
            this.data = dataSet.Tables[0];
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ
        public FreeResourcesView()
        {
            //this.dataColumns.Add(new PatternColumn("ID", "ID"));
            this.dataColumns.Add(new PatternColumn("Код ресурса", "Resource_ID", new FilterPatternExpressionRule("Resource_ID"), SummaryCalculationType.Count) { Width = 60 });
            this.dataColumns.Add(new PatternColumn("Ресурс", "Resource_Name", new FilterPatternExpressionRule("Resource_Name")) { Width = 170 });
            this.dataColumns.Add(new PatternColumn("Код типа ресурса", "Establish_ID", new FilterCompareExpressionRule<Int32>("Establish_ID")) { Width = 60 });
            this.dataColumns.Add(new PatternColumn("Тип ресурса", "StaffName", new FilterPatternExpressionRule("StaffName")) { Width = 100 });
             //this.dataColumns.Add(new PatternColumn("Zone_ID", "Zone_ID"));
            this.dataColumns.Add(new PatternColumn("Приор. зона ресурса", "ZoneName", new FilterPatternExpressionRule("ZoneName")) { Width = 190 });
            this.dataColumns.Add(new PatternColumn("Доступность", "ISFree", new FilterCompareExpressionRule<Decimal>("ISFree")) { Width = 90 });
        }
        #endregion
    }

    /// <summary>
    /// Критерий поиска для закрепленных ресурсов
    /// </summary>
    public class FreeResourcesSearchParameters : SearchParametersBase
    {
        public long UserID { get; set; }
        public long InventoryDocID { get; set; }
        public bool ShowOnlyFree { get; set; }

        /// <summary>
        /// Режим процесса из обновленной модели
        /// </summary>
        public bool UpgradeMode { get; set; }
    }
    #endregion
}
