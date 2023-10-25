using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.PickControl.AWStructure;

namespace WMSOffice.Window
{
    public partial class AWStructureManagementWindow : GeneralWindow
    {
        #region ПОЛЯ И СВОЙСТВА КЛАССА

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных
        /// </summary>
        private Dialogs.SplashForm waitProgressForm = new WMSOffice.Dialogs.SplashForm();

        /// <summary>
        /// Текущий редактор AW-структуры
        /// </summary>
        private IAWStructureEditor CurrentAWEditor 
        { 
            get 
            {
                return (previousAWEditor = GetSelectedAWEditor());
            } 
        }

        /// <summary>
        /// Предыдущий редактор AW-струткуры
        /// </summary>
        private IAWStructureEditor previousAWEditor = null;

        #endregion

        #region СОБЫТИЯ И ДЕЛЕГАТЫ

        delegate IAWStructureEditor GetSelectedAWEditorHandler();

        private IAWStructureEditor GetSelectedAWEditor()
        {
            if (tcAWEditorsHost.InvokeRequired)
            {
                GetSelectedAWEditorHandler callback = new GetSelectedAWEditorHandler(GetSelectedAWEditor);
                return (IAWStructureEditor)tcAWEditorsHost.Invoke(callback, new object[0]);
            }
            else
            {
                return tcAWEditorsHost.SelectedTab.Controls[0] as IAWStructureEditor; 
            }
        }

        private IAWStructureEditor GetAWEditor(TabPage tpAWEditorHost)
        {
            return tpAWEditorHost.Controls[0] as IAWStructureEditor;
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ

        public AWStructureManagementWindow()
        {
            InitializeComponent();
        }

        private void AWStructureManagementWindow_Load(object sender, EventArgs e)
        {
            var sectorsEditor = GetAWEditor(tpSectorsEditorHost);
            var cellsEditor = GetAWEditor(tpCellsEditorHost);
            var stationsEditor = GetAWEditor(tpStationsEditorHost);
            var cellsOnStationsEditor = GetAWEditor(tpCellsOnStationsEditorHost);
            var processesEditor = GetAWEditor(tpProcessesEditorHost);
            var processesInStationsEditor = GetAWEditor(tpProcessesInStationsEditorHost);

            cellsEditor.Initializers = new List<IAWStructureInitializer>();
            cellsEditor.Initializers.Add(sectorsEditor);

            cellsOnStationsEditor.Initializers = new List<IAWStructureInitializer>();
            cellsOnStationsEditor.Initializers.Add(stationsEditor);
            cellsOnStationsEditor.Initializers.Add(cellsEditor);

            processesInStationsEditor.Initializers = new List<IAWStructureInitializer>();
            processesInStationsEditor.Initializers.Add(processesEditor);
            processesInStationsEditor.Initializers.Add(stationsEditor);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            tcAWEditorsHost.DrawMode = TabDrawMode.OwnerDrawFixed;
            InitFilter();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F5)
            {
                ReloadData();
                return true;
            }

            if (keyData == (Keys.Control | Keys.S))
            {
                SaveData();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        private void tcAWEditorsHost_SelectedIndexChanged(object sender, EventArgs e)
        {
            UnloadPreviousPlugins();
            LoadCurrentPlugins();

            InitFilter();
        }

        private void LoadCurrentPlugins()
        {
            if (CurrentAWEditor.Plugins != null)
            {
                foreach (var control in CurrentAWEditor.Plugins)
                    tsMainMenu.Items.Add((ToolStripItem)control);
            }
        }

        private void UnloadPreviousPlugins()
        {
            if (previousAWEditor != null && previousAWEditor.Plugins != null)
            {
                foreach (var control in previousAWEditor.Plugins)
                    if (tsMainMenu.Items.Contains((ToolStripItem)control))
                        tsMainMenu.Items.Remove((ToolStripItem)control);
            }
        }

        private void InitFilter()
        {
            try
            {
                var parameter = new AWStructureEditorParameter();
                parameter.UserID = this.UserID;

                CurrentAWEditor.InitFilter(parameter);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void btnReloadData_Click(object sender, EventArgs e)
        {
            ReloadData();
        }

        private bool ReloadData()
        {
            try
            {
                return CurrentAWEditor.ReloadData(null);
            }
            catch (Exception ex)
            {
                ShowError(ex);
                return false;
            }
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private bool SaveData()
        {
            try
            {
                return CurrentAWEditor.SaveData(null);
            }
            catch (Exception ex)
            {
                ShowError(ex);
                return false;
            }
        }

        private void tcAWEditorsHost_DrawItem(object sender, DrawItemEventArgs e)
        {
            var awEditor = GetAWEditor(tcAWEditorsHost.TabPages[e.Index]);

            var foreColor = awEditor.Initializers != null ? Color.Red : Color.Green;
            var foreColorBrush = new SolidBrush(foreColor);

            var backColor = Color.Beige;
            var backColorBrush = new SolidBrush(backColor);

            e.Graphics.FillRectangle(backColorBrush, e.Bounds);

            var textHeader = tcAWEditorsHost.TabPages[e.Index].Text;
            SizeF sizeHeader = e.Graphics.MeasureString(textHeader, e.Font);
            e.Graphics.DrawString(tcAWEditorsHost.TabPages[e.Index].Text, e.Font, foreColorBrush, e.Bounds.Left + (e.Bounds.Width - sizeHeader.Width) / 2, e.Bounds.Top + (e.Bounds.Height - sizeHeader.Height) / 2 + 1);

            Rectangle bounds = e.Bounds;
            bounds.Offset(0, 1);
            bounds.Inflate(0, -1);
            e.Graphics.DrawRectangle(new Pen(backColor), bounds);
            e.DrawFocusRectangle();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AWStructureManagementImportFromExcellWindow f = new AWStructureManagementImportFromExcellWindow();
            f.ShowDialog();
        }
    }
}
