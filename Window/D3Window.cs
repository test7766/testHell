using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs.D3;
using WMSOffice.Controls.D3;

namespace WMSOffice.Window
{
    public partial class D3Window : GeneralWindow
    {
        public D3Window()
        {
            InitializeComponent();
        }

        private void D3Window_Load(object sender, EventArgs e)
        {
            // режим администрирования
            EntityElementsList funcs = GetLimitedElements("access_type");

            bool adminMode = funcs.Contains("edit"); // (GetLimitations("access") == "admin");
            editObjectProperties.Enabled = toolStripEditObject.Visible = 
                editRouteControl.Enabled = toolStripRoutes.Visible = toolStripRoutePlans.Visible = adminMode;
            if (adminMode)
            {
                cbWarehouses.ContextMenuStrip = cmWarehouse;
                lbRoutePlans.ContextMenuStrip = cmRoutePlans;
            }

            // удаление закладки с маршрутами
            if (tabControlInfo.TabPages.Contains(tabPageRoutes))
                tabControlInfo.TabPages.Remove(tabPageRoutes);

            // получаем список филиалов
            this.warehousesTableAdapter.Fill(this.d3.Warehouses, UserID);
            if (this.d3.Warehouses.Count > 0)
                cbWarehouses_SelectedIndexChanged(null, null);

            // получаем список отчетов
            using (Data.D3TableAdapters.ReportsTableAdapter rAdapter = new WMSOffice.Data.D3TableAdapters.ReportsTableAdapter())
            {
                Data.D3.ReportsDataTable rTable = rAdapter.GetData(UserID);
                foreach (Data.D3.ReportsRow rRow in rTable)
                {
                    ToolStripMenuItem mi = new ToolStripMenuItem(rRow.Report_Name);
                    mi.Tag = rRow.Report_ID;
                    mi.Click += new EventHandler(miReport_Click);
                    btnReports.DropDownItems.Add(mi);
                }
            }
        }

        #region работа со списком отчетов

        /// <summary>
        /// Событие изменения текущего отчета.
        /// Получаем новые данные, обновляем отчет.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void miReport_Click(object sender, EventArgs e)
        {
            // снимаем выделение
            foreach (var item in btnReports.DropDownItems)
                if (item is ToolStripMenuItem) ((ToolStripMenuItem)item).Checked = false;
            // удаление закладки с маршрутами
            if (tabControlInfo.TabPages.Contains(tabPageRoutes))
                tabControlInfo.TabPages.Remove(tabPageRoutes);

            // выделяем нужное
            ToolStripMenuItem thisItem = (ToolStripMenuItem)sender;
            thisItem.Checked = true;
            btnReports.Text = thisItem.Text;
            btnReports.Tag = thisItem.Tag;

            // получаем данные, обновляем слой с данными
            RefreshFillData();
        }

        /// <summary>
        /// Обновление данных для выбранного отчета
        /// </summary>
        private void RefreshFillData()
        {
            // должен быть выбран сектор, это обязательное условие
            if (cbSectors.SelectedItem != null)
            {
                this.d3.Routes.Clear();
                this.d3.RoutePlans.Clear();
                _selectedRoutes.Clear();

                // если "без отчета", очищаем данные
                if ((miNoReport.Checked) ||
                    (miViewSectors.Checked || miViewRacks.Checked || miViewPlaces.Checked || miViewRoutes.Checked))
                {
                    this.d3.FillCells.Clear();
                    this.d3.Legend.Clear();
                    // splitContainerView.SplitterDistance = splitContainerView.Width;
                    _viewMode = (miViewSectors.Checked) ? ViewModes.Sectors 
                        : (miViewRacks.Checked) ? ViewModes.Racks
                        : (miViewPlaces.Checked) ? ViewModes.Places
                        : ViewModes.Cells;
                    if (miViewRoutes.Checked)
                    {
                        _softChange = true;
                        LoadRoutePlans();
                        LoadRoutes();
                        _softChange = false;
                    }
                }
                else
                {
                    // получаем данные отчета для текущего сектора
                    Data.D3.SectorsRow rowSector = (Data.D3.SectorsRow)cbSectors.SelectedItem;
                    using (Data.D3TableAdapters.FillCellsTableAdapter adapter = new WMSOffice.Data.D3TableAdapters.FillCellsTableAdapter())
                    {
                        adapter.Fill(this.d3.FillCells, (string)btnReports.Tag, rowSector.Sector_ID, UserID);
                    }

                    // загрузка легенды к отчету
                    using (Data.D3TableAdapters.LegendTableAdapter legendAdapter = new WMSOffice.Data.D3TableAdapters.LegendTableAdapter())
                    {
                        legendAdapter.Fill(this.d3.Legend, (string)btnReports.Tag, rowSector.Sector_ID, UserID);
                    }

                    // показываем область легенды
                    splitContainerView.SplitterDistance = splitContainerView.Width - 300;
                    tabControlInfo.SelectedTab = tabPageLegend;
                    _viewMode = ViewModes.Cells;
                }
                // обновляем изображение
                RefreshView();
            }
        }

        #endregion

        /// <summary>
        /// Обработчик события смены филиала - получаем список секторов и обновляем отображение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbWarehouses_SelectedIndexChanged(object sender, EventArgs e)
        {
            // обновляем список секторов
            FillSectorsFromDB();
            viewD3.Focus();
        }

        /// <summary>
        /// Локальная переменная, которая хранит признак, что изменения производятся программно
        /// </summary>
        bool _softChange = false;

        /// <summary>
        /// Метод производит обновление списка секторов из базы данных
        /// </summary>
        private void FillSectorsFromDB()
        {
            // сохраняем текущее значение
            _softChange = true;
            int selectedSectorID = 0;
            if (cbSectors.SelectedItem != null) selectedSectorID = ((Data.D3.SectorsRow)cbSectors.SelectedItem).Sector_ID;

            // обновляем список секторов филиала
            this.d3.Sectors.Clear();
            if (cbWarehouses.SelectedItem != null)
            {
                // получаем список секторов
                this.sectorsTableAdapter.Fill(this.d3.Sectors,
                    ((Data.D3.WarehousesRow)((DataRowView)cbWarehouses.SelectedItem).Row).Warehouse_ID, UserID);
                // построение иерархии отображения списка секторов
                cbSectors.Items.Clear();
                cbSectrosFill(null, 0);

                // сохраняем выбор сектора
                if (selectedSectorID > 0)
                    foreach (object item in cbSectors.Items)
                        if (selectedSectorID == ((Data.D3.SectorsRow)item).Sector_ID)
                        {
                            cbSectors.SelectedItem = item;
                            break;
                        }
                _softChange = false;
                // либо выбор по умолчанию
                if (cbSectors.SelectedItem == null && cbSectors.Items.Count > 0)
                    cbSectors.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Метод заполнения списка секторов в виде иерархии объектов
        /// </summary>
        /// <param name="drvParent"></param>
        /// <param name="level"></param>
        private void cbSectrosFill(DataRowView drvParent, int level)
        {
            string filter = (drvParent == null) ? "Parent_Sector_ID is null" : String.Format("Parent_Sector_ID = {0}", ((Data.D3.SectorsRow)drvParent.Row).Sector_ID);
            DataView dv = new DataView(this.d3.Sectors, filter, "", DataViewRowState.CurrentRows);
            foreach (DataRowView drv in dv)
            {
                Data.D3.SectorsRow item = (Data.D3.SectorsRow)drv.Row;
                item.Text = (level == 0) ? item.Sector_Name : "|   |   |   |   |   |   |   |   |   |   ".Substring(0, (level - 1) * 4) + "|_ " + item.Sector_Name;
                cbSectors.Items.Add(item);
                cbSectrosFill(drv, level + 1);
            }
        }

        /// <summary>
        /// Обработчик события выбора сектора
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbSectors_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!_softChange)
                    ClearSelectedObjects();
                viewD3.Focus();

                // получаем данные, обновляем слой с данными
                RefreshFillData();
                // RefreshView();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        /// <summary>
        /// Загрузка/обновление всех элементов модели (смена сектора отображения)
        /// </summary>
        private void RefreshView()
        {
            if (cbSectors.SelectedItem != null)
            {
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += new DoWorkEventHandler(DrawWorker_DoWork);
                worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(DrawWorker_RunWorkerCompleted);

                splashForm.ActionText = "Построение модели склада...";

                Data.D3.SectorsRow rowSector = (Data.D3.SectorsRow)cbSectors.SelectedItem;
                worker.RunWorkerAsync(rowSector);
                splashForm.ShowDialog();
            }
            else
            {
                viewD3.Source = null;
                viewD3.RefreshView();
            }
        }

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();
        
        /// <summary>
        /// Фоновое обновление визуализации склада
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void DrawWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            viewD3.Source = null;
            try
            {
                // получаем "текущий" сектор - корневой элемент                
                Data.D3.SectorsRow rowSector = (Data.D3.SectorsRow)e.Argument;
                WMSOffice.Controls.D3.D2Sector sector = Data.D3.GetSectorObject(rowSector);

                // начальная загрузка всех типов ячеек
                if (this.d3.Cells.Count < 1)
                    using (Data.D3TableAdapters.CellsTableAdapter cellsAdapter = new WMSOffice.Data.D3TableAdapters.CellsTableAdapter())
                    {
                        cellsAdapter.Fill(this.d3.Cells, rowSector.Sector_ID, UserID);
                    }

                // построение иерархии из элементов склада
                LoadSector(ref sector, rowSector.Sector_ID);

                // присвоение корневого элемента
                viewD3.Source = sector;
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        
        /// <summary>
        /// Обработка окончания отрисовки схемы склада
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void DrawWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
            {
                MessageBox.Show((e.Result as Exception).Message, "Ошибка выполнения действия", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // информирование пользователя
            splashForm.ActionText = "Подготовка изображения...";

            // обновление вида ;)
            viewD3.RefreshView();
            // обнуление объекта
            // viewD3.Source = null;

            // закрываем окно прогреса обновлений
            splashForm.CloseForce();
        }

        #region создание иерархии объектов Controls.D3

        /// <summary>
        /// Перечисление режимов отображения схемы склада
        /// </summary>
        private enum ViewModes { 
            /// <summary>
            /// Отображать только сектора (с названиями)
            /// </summary>
            Sectors, 
            /// <summary>
            /// Отображать сектора и стеллажи (с названиями)
            /// </summary>
            Racks, 
            /// <summary>
            /// Отображать сектора, стеллажи и места хранения (с названиями)
            /// </summary>
            Places, 
            /// <summary>
            /// Отображать сектора, стеллажи, места хранения и ячейки
            /// </summary>
            Cells 
        }

        /// <summary>
        /// Локальная переменная хранит выбранный режим отображения схемы склада
        /// </summary>
        private ViewModes _viewMode = ViewModes.Cells;

        /// <summary>
        /// Метод загрузки содержимого указанного сектора
        /// </summary>
        /// <param name="parentSector"></param>
        /// <param name="currentSectorID"></param>
        void LoadSector(ref WMSOffice.Controls.D3.D2Sector parentSector, int currentSectorID)
        {
            // загрузка маршрутов, которые выбраны к отображению
            parentSector.Routes.Clear();
            if (_selectedRoutes.Count > 0)
            {
                foreach (Controls.D3.Route route in _selectedRoutes)
                    if (route.SectorID == parentSector.ID)
                        // каждый сектор содержит свои маршруты, которые должен будет отобразить
                        parentSector.Routes.Add(route);
            }


            // загрузка дочерних секторов
            DataView dv = new DataView(this.d3.Sectors, String.Format("Parent_Sector_ID = {0}", currentSectorID), "", DataViewRowState.CurrentRows);
            foreach (DataRowView drv in dv)
            {
                Data.D3.SectorsRow rowSector = (Data.D3.SectorsRow)drv.Row;
                WMSOffice.Controls.D3.D2Sector sector = Data.D3.GetSectorObject(rowSector);
                LoadSector(ref sector, rowSector.Sector_ID);

                parentSector.Items.Add(sector.Text, sector);
            }
            
            // загрузка стеллажей
            if (_viewMode != ViewModes.Sectors)
                using (Data.D3TableAdapters.RacksTableAdapter racksAdapter = new WMSOffice.Data.D3TableAdapters.RacksTableAdapter())
                {
                    Data.D3.RacksDataTable racksTable = racksAdapter.GetData(currentSectorID, UserID);
                    foreach (Data.D3.RacksRow rackRow in racksTable)
                    {
                        WMSOffice.Controls.D3.D2Rack rack = Data.D3.GetRackObject(rackRow);

                        if (_viewMode != ViewModes.Racks)
                            LoadPlaces(ref rack, rackRow.Rack_ID);

                        parentSector.Items.Add(rack.Text, rack);
                    }
                }
        }

        /// <summary>
        /// Наполнение стеллажа созданными местами хранения
        /// </summary>
        /// <param name="parentRack"></param>
        /// <param name="currentRackID"></param>
        void LoadPlaces(ref WMSOffice.Controls.D3.D2Rack parentRack, int currentRackID)
        {
            // загрузка мест стеллажа
            using (Data.D3TableAdapters.PlacesTableAdapter placesAdapter = new WMSOffice.Data.D3TableAdapters.PlacesTableAdapter())
            {
                Data.D3.PlacesDataTable placesTable = placesAdapter.GetData(currentRackID, UserID);
                foreach (Data.D3.PlacesRow placeRow in placesTable)
                {
                    WMSOffice.Controls.D3.D2Place place = Data.D3.GetPlaceObject(placeRow);

                    // присоединяем к полке указанные ячейки
                    if (_viewMode != ViewModes.Places)
                    {
                        this.d3.Cells.DefaultView.RowFilter = String.Format("Place_Type_ID = '{0}'", placeRow.Place_Type_ID);
                        foreach (DataRowView drvCell in this.d3.Cells.DefaultView)
                        {
                            Data.D3.CellsRow cellRow = (Data.D3.CellsRow)drvCell.Row;
                            Data.D3.FillCellsRow fillRow = this.d3.FillCells.FindByRackPlaceCell(parentRack.Text, place.Text, cellRow.Cell_ID);
                            WMSOffice.Controls.D3.D2Cell cell = Data.D3.GetCellObject(cellRow, (fillRow != null) ? fillRow.Style : String.Empty);
                            place.Items.Add(cell.Text, cell);
                        }
                    }

                    parentRack.Items.Add(place.Text, place);
                }
            }
        }

        /// <summary>
        /// Загрузка карт маршрутов по филиалу
        /// </summary>
        void LoadRoutePlans()
        {
            d3.RoutePlans.Clear();
            if (cbWarehouses.SelectedItem != null)
            {
                routePlansTableAdapter.Fill(d3.RoutePlans, ((Data.D3.WarehousesRow)((DataRowView)cbWarehouses.SelectedItem).Row).Warehouse_ID);
            }

            _softChange = true;
            lbRoutePlans.SelectedIndex = -1;
            _softChange = false;
        }

        /// <summary>
        /// Загрузка маршрутов по филиалу
        /// </summary>
        void LoadRoutes()
        {
            // сохраняем текущий выбор
            int prevSelectedRoute = (SelectedRoute != null) ? SelectedRoute.ID : 0;

            // добавляем закладку с маршрутами
            if (!tabControlInfo.TabPages.Contains(tabPageRoutes))
            {
                tabControlInfo.TabPages.Add(tabPageRoutes);
                tabControlInfo.SelectedTab = tabPageRoutes;
            }

            // загружаем список маршрутов, созданных для филиала
            d3.Routes.Clear();
            if (cbWarehouses.SelectedItem != null)
            {
                routesTableAdapter.Fill(d3.Routes, ((Data.D3.WarehousesRow)((DataRowView)cbWarehouses.SelectedItem).Row).Warehouse_ID);
            }

            _softChange = true;
            lbRoutes.SelectedIndex = -1;
            // восстанавливаем предыдущий выбор
            if (prevSelectedRoute > 0)
            {
                foreach (object item in lbRoutes.Items)
                {
                    Data.D3.RoutesRow routeRow = (Data.D3.RoutesRow)((DataRowView)item).Row;
                    if (routeRow.Route_ID == prevSelectedRoute)
                    {
                        lbRoutes.SelectedItem = item;
                        break;
                    }
                }
            }
            _softChange = false;

        }

        #endregion

        #region styles
        /*
        /// <summary>
        /// Загрузка всех стилей из БД
        /// </summary>
        private void LoadStyles()
        {
            using (Data.D3TableAdapters.StylesTableAdapter adapter = new WMSOffice.Data.D3TableAdapters.StylesTableAdapter())
            {
                adapter.Fill(this.d3.Styles, UserID);
            }
        }

        /// <summary>
        /// Стиль по умолчанию
        /// </summary>
        private WMSOffice.Controls.D3.Style _defaultStyle = new WMSOffice.Controls.D3.Style() { 
            BackColor = SystemColors.Info, 
            BorderColor = Color.Black,
            BorderStyle = WMSOffice.Controls.D3.BorderStyles.None,
            BorderWidth = 1,
            ForeColor = Color.Black,
            Name = "Default"
        };

        /// <summary>
        /// Метод возвращает нужный стиль из загруженных ранее
        /// </summary>
        /// <param name="styleName"></param>
        /// <returns></returns>
        private WMSOffice.Controls.D3.Style GetStyle(string styleID)
        {
            // начальная загрузка стилей
            if (this.d3.Styles.Count < 1) LoadStyles();

            // создание объекта стиля
            var rowStyle = this.d3.Styles.FindByStyle_ID(styleID);
            if (rowStyle != null)
                return new WMSOffice.Controls.D3.Style()
                {
                    Name = rowStyle.Style_ID,
                    BackColor = (rowStyle.IsBack_ColorNull()) ? _defaultStyle.BackColor
                        : (rowStyle.Back_Color[0] == '#') ? Color.FromArgb(Convert.ToInt32(rowStyle.Back_Color.Substring(1), 16))
                            : Color.FromName(rowStyle.Back_Color),
                    BorderColor = (rowStyle.IsBorder_ColorNull()) ? _defaultStyle.BorderColor
                        : (rowStyle.Border_Color[0] == '#') ? Color.FromArgb(Convert.ToInt32(rowStyle.Border_Color.Substring(1), 16))
                            : Color.FromName(rowStyle.Border_Color),
                    BorderStyle = (rowStyle.IsBorder_StyleNull()) ? _defaultStyle.BorderStyle
                        : (rowStyle.Border_Style == "solid") ? WMSOffice.Controls.D3.BorderStyles.Solid
                        : (rowStyle.Border_Style == "dash") ? WMSOffice.Controls.D3.BorderStyles.Dash
                        : (rowStyle.Border_Style == "cross") ? WMSOffice.Controls.D3.BorderStyles.Cross : WMSOffice.Controls.D3.BorderStyles.None,
                    BorderWidth = (rowStyle.IsBorder_WidthNull()) ? _defaultStyle.BorderWidth
                        : rowStyle.Border_Width,
                    ForeColor = (rowStyle.IsFore_ColorNull()) ? _defaultStyle.ForeColor
                        : (rowStyle.Fore_Color[0] == '#') ? Color.FromArgb(Convert.ToInt32(rowStyle.Fore_Color.Substring(1), 16))
                            : Color.FromName(rowStyle.Fore_Color)
                };

            // иначе возвращаем стиль по умолчанию
            return _defaultStyle;
        }
        */
        #endregion

        private void gvLegend_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Bitmap emptyBitmap = new Bitmap(16, 16);
            WMSOffice.Controls.D3.D2Cell cell = new WMSOffice.Controls.D3.D2Cell()
            {
                Position = new WMSOffice.Controls.D3.Point3D(0, 0, 0),
                Size = new WMSOffice.Controls.D3.Region3D(30, 50, 10),
                Style = Data.D3.GetStyle(""),
                Text = ""
            };

            foreach (DataGridViewRow row in gvLegend.Rows)
            {
                Data.D3.LegendRow diffRow = (Data.D3.LegendRow)((DataRowView)row.DataBoundItem).Row;

                if (!String.IsNullOrEmpty(diffRow.Style))
                {
                    Bitmap bmp = new Bitmap(cell.Size.Width, cell.Size.Height);
                    Graphics g = Graphics.FromImage(bmp);
                    cell.Style = Data.D3.GetStyle(diffRow.Style);
                    cell.Draw(null, g);
                    row.Cells[colImage.Index].Value = bmp;
                }
                else row.Cells[colImage.Index].Value = emptyBitmap;
            }
        }

        #region selected objects

        /// <summary>
        /// Обработчик события выбора объекта на схеме
        /// </summary>
        /// <param name="viewObjects"></param>
        private void viewD3_ObjectSelected(WMSOffice.Controls.D3.ObjectsList viewObjects)
        {
            if (_inRouteDesignMode)
            {
                // режим визуального прокладывания маршрута
                WMSOffice.Controls.D3.Object lastObject = viewObjects[viewObjects.Count - 1];
                // определяем начальную/конечную точку
                if (lastObject is D2Sector && editRouteControl.SelectedObject != null
                    && ((Route)editRouteControl.SelectedObject).SectorID == ((D2Sector)lastObject).ID)
                {
                    Route route = (Route)editRouteControl.SelectedObject;
                    AddPlaceToDesignRoutes(-1);
                }
                // определяем следующую точку маршрута
                if (lastObject is D2Place)
                    AddPlaceToDesignRoutes(lastObject.ID);
            }
            else
            {
                // отобразить полный путь к выбранному объекту
                pnlSelectedObjects.Controls.Clear();
                for (int i = 0; i < viewObjects.Count; i++)
                    AddSelectedObject(viewObjects[i]);

                // визуализация выбранного объекта
                ChangeSelectedObject(viewObjects[viewObjects.Count - 1]);

                // показываем область описания свойств
                if (splitContainerView.SplitterDistance > splitContainerView.Width - 100)
                    splitContainerView.SplitterDistance = splitContainerView.Width - 300;
                tabControlInfo.SelectedTab = tabPageProperties;
            }
        }

        /// <summary>
        /// Смена выбранного объекта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblObjectSelected_Click(object sender, EventArgs e)
        {
            ChangeSelectedObject((WMSOffice.Controls.D3.Object)((LinkLabel)sender).Tag);
        }        

        /// <summary>
        /// Метод отображения выбранного объекта в правой части экрана
        /// </summary>
        /// <param name="objectView"></param>
        private void ChangeSelectedObject(WMSOffice.Controls.D3.Object objectView)
        {
            // убираем поворот, если он был на объекте
            int rotation = 0;
            if (objectView is WMSOffice.Controls.D3.D2Rack) {
                rotation = ((WMSOffice.Controls.D3.D2Rack)objectView).Rotation;
                ((WMSOffice.Controls.D3.D2Rack)objectView).Rotation = 0;
            }

            // фронтальное отображение объекта
            viewObject.Source = objectView;
            viewObject.RefreshView();

            // возвращаем поворот объекта
            if (rotation != 0)
                ((WMSOffice.Controls.D3.D2Rack)objectView).Rotation = rotation;

            // свойства объекта
            editObjectProperties.SelectedObject = objectView;
        }

        /// <summary>
        /// Метод возвращает родительский выбранный объект (объект, которому принадлежит текущий выбранный)
        /// </summary>
        /// <param name="currentObject"></param>
        /// <returns></returns>
        private WMSOffice.Controls.D3.Object GetParentSelectedObject(WMSOffice.Controls.D3.Object currentObject)
        {
            WMSOffice.Controls.D3.Object res = null;
            for (int i = 1; i < pnlSelectedObjects.Controls.Count; i++)
            {
                WMSOffice.Controls.D3.Object obj = (WMSOffice.Controls.D3.Object)((LinkLabel)pnlSelectedObjects.Controls[i]).Tag;
                if (obj.GetType().Name == currentObject.GetType().Name && obj.ID == currentObject.ID)
                {
                    res = (WMSOffice.Controls.D3.Object)((LinkLabel)pnlSelectedObjects.Controls[i - 1]).Tag;
                    break;
                }
            }
            return res;
        }

        /// <summary>
        /// Метод позволяет программно перейти к выбору предыдущего (родительского) объекта
        /// </summary>
        /// <param name="currentObject"></param>
        private void SelectParentObject(WMSOffice.Controls.D3.Object currentObject)
        {
            WMSOffice.Controls.D3.Object obj = GetParentSelectedObject(currentObject);
            if (obj != null) 
                ChangeSelectedObject(obj);
            else
                ClearSelectedObjects();
        }

        /// <summary>
        /// Очистить список выбранных объектов схемы
        /// </summary>
        private void ClearSelectedObjects()
        {
            viewObject.Source = null;
            viewObject.RefreshView();
            editObjectProperties.SelectedObject = null;
            pnlSelectedObjects.Controls.Clear();
        }

        /// <summary>
        /// Метод удаляет выбранные объекты схемы после указанного (после = вложенные объекты)
        /// </summary>
        private void ClearSelectedObjectsAfterThis(Controls.D3.Object thisObject)
        {
            int id = thisObject.ID;
            string type = thisObject.GetType().Name;

            // ищем указанный объект (его индекс)
            int foundIndex = -1;
            for (int i = 0; i < pnlSelectedObjects.Controls.Count; i++)
            {
                Controls.D3.Object obj = (Controls.D3.Object)((LinkLabel)pnlSelectedObjects.Controls[i]).Tag;
                if (obj.GetType().Name == type && obj.ID == id)
                {
                    foundIndex = i;
                    break;
                }
            }
            if (foundIndex > -1)
                // удаляем объекты с индексом больше заданного
                while (pnlSelectedObjects.Controls.Count > foundIndex + 1)
                    pnlSelectedObjects.Controls.RemoveAt(pnlSelectedObjects.Controls.Count - 1);
        }

        /// <summary>
        /// Метод смены названия текущего объекта - меняется названия ссылки в списке выбранных объектов
        /// </summary>
        /// <param name="id"></param>
        /// <param name="text"></param>
        private void ChangeSelectedObjectTextLabel(int id, string text)
        {
            foreach (Control control in pnlSelectedObjects.Controls)
            {
                Controls.D3.Object obj = (Controls.D3.Object)((LinkLabel)control).Tag;
                if (obj.ID == id)
                {
                    ((LinkLabel)control).Text = text;
                    break;
                }
            }
        }

        /// <summary>
        /// Метод добавления еще одного объекта к списку выбранных
        /// </summary>
        /// <param name="currentObject"></param>
        private void AddSelectedObject(WMSOffice.Controls.D3.Object currentObject)
        {
            LinkLabel lbl = new LinkLabel();
            lbl.AutoSize = true;
            lbl.Text = currentObject.Text;
            lbl.Tag = currentObject;
            lbl.Click += new EventHandler(lblObjectSelected_Click);
            pnlSelectedObjects.Controls.Add(lbl);
        }

        #endregion

        #region admin actions with 2D/3D objects

        /// <summary>
        /// Добавление "родительского" сектора, по сути - отдельная схема скалада
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddParentSector_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbWarehouses.SelectedItem != null)
                {
                    Data.D3.WarehousesRow warehouseRow = (Data.D3.WarehousesRow)((DataRowView)cbWarehouses.SelectedItem).Row;
                    if (MessageBox.Show(
                        String.Format("Вы действительно хотите создать новую схему для склада \"{0}\"?", warehouseRow.Warehouse_Name),
                        "Новый склад", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // создание родительской "основной" схемы
                        WMSOffice.Data.D3.SectorsDataTable newSector = sectorsTableAdapter.CreateParent(warehouseRow.Warehouse_ID);

                        if (newSector != null && newSector.Count == 1)
                        {
                            // добавляем новый сектор в выпадающий список
                            WMSOffice.Data.D3.SectorsRow newSectorRow = (WMSOffice.Data.D3.SectorsRow)newSector[0];
                            d3.Sectors.ImportRow(newSectorRow);
                            // сразу выбираем его для отображения
                            cbSectors.SelectedItem = newSectorRow;
                            // и выбираем для редактирования
                            WMSOffice.Controls.D3.ObjectsList viewObjects = new WMSOffice.Controls.D3.ObjectsList();
                            viewObjects.Add(Data.D3.GetSectorObject(newSectorRow));
                            viewD3_ObjectSelected(viewObjects);
                        }
                        else
                            MessageBox.Show("Новая схема не была создана.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        /// <summary>
        /// Добавление вложенного сектора (отдел склада)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddSector_Click(object sender, EventArgs e)
        {
            try
            {
                if (viewObject.Source != null && viewObject.Source is Controls.D3.D2Sector)                
                {
                    Controls.D3.D2Sector parentSector = (Controls.D3.D2Sector)viewObject.Source;
                    if (MessageBox.Show(
                        String.Format("Вы действительно хотите создать сектор внутри сектора \"{0}\"?", parentSector.Text),
                        "Новый сектор", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // создание родительской "основной" схемы
                        WMSOffice.Data.D3.SectorsDataTable newSector = sectorsTableAdapter.Create(parentSector.ID);

                        if (newSector != null && newSector.Count == 1)
                        {
                            // добавляем новый сектор в выпадающий список
                            WMSOffice.Data.D3.SectorsRow newSectorRow = (WMSOffice.Data.D3.SectorsRow)newSector[0];
                            d3.Sectors.ImportRow(newSectorRow);
                            // сразу выбираем его для отображения
                            cbSectors.SelectedItem = newSectorRow;
                            // и выбираем для редактирования
                            WMSOffice.Controls.D3.ObjectsList viewObjects = new WMSOffice.Controls.D3.ObjectsList();
                            viewObjects.Add(Data.D3.GetSectorObject(newSectorRow));
                            viewD3_ObjectSelected(viewObjects);
                        }
                        else
                            MessageBox.Show("Новый сектор не был создан.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        /// <summary>
        /// Добавление стеллажа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddRack_Click(object sender, EventArgs e)
        {
            try
            {
                if (viewObject.Source != null && viewObject.Source is Controls.D3.D2Sector)
                {
                    // добавление стеллажа в текущий сектор
                    Controls.D3.D2Sector parentSector = (Controls.D3.D2Sector)viewObject.Source;

                    if (MessageBox.Show(
                        String.Format("Вы действительно хотите создать стеллаж внутри сектора \"{0}\"?", parentSector.Text),
                        "Новый стеллаж", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        using (Data.D3TableAdapters.RacksTableAdapter adapter = new WMSOffice.Data.D3TableAdapters.RacksTableAdapter())
                        {
                            // создание стеллажа внутри заданного сектора
                            WMSOffice.Data.D3.RacksDataTable newRack = adapter.Create(parentSector.ID);
                            if (newRack != null && newRack.Count == 1)
                            {
                                WMSOffice.Data.D3.RacksRow newRackRow = (WMSOffice.Data.D3.RacksRow)newRack[0];
                                Controls.D3.D2Rack rack = Data.D3.GetRackObject(newRackRow);
                                // добавляем новый стеллаж к текущему сектору
                                parentSector.Items.Add(rack.Text, rack);
                                // очищаем выбранные объекты после текущего сектора
                                ClearSelectedObjectsAfterThis(parentSector);
                                // добавляем новый стеллаж в список выбранных
                                AddSelectedObject(rack);
                                // и выбираем текущий объект для редактирования
                                ChangeSelectedObject(rack);
                            }
                            else
                                MessageBox.Show("Новый стеллаж не был создан.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                }
                else
                    // создание копии стеллажа в том же секторе
                    if (viewObject.Source != null && viewObject.Source is Controls.D3.D2Rack)
                    {
                        Controls.D3.D2Rack parentRack = (Controls.D3.D2Rack)viewObject.Source;

                        if (MessageBox.Show(
                            String.Format("Вы действительно хотите создать копию стеллажа \"{0}\"?", parentRack.Text),
                            "Новый стеллаж", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            using (Data.D3TableAdapters.RacksTableAdapter adapter = new WMSOffice.Data.D3TableAdapters.RacksTableAdapter())
                            {
                                // создание стеллажа, как копии текущего стеллажа
                                WMSOffice.Data.D3.RacksDataTable newRack = adapter.CreateCopy(parentRack.ID);
                                if (newRack != null && newRack.Count == 1)
                                {
                                    WMSOffice.Data.D3.RacksRow newRackRow = (WMSOffice.Data.D3.RacksRow)newRack[0];
                                    Controls.D3.D2Rack rack = Data.D3.GetRackObject(newRackRow);
                                    // добавляем места хранения (они могут существовать) для созданной копии стеллажа
                                    LoadPlaces(ref rack, rack.ID);
                                    // получаем родительский объект
                                    WMSOffice.Controls.D3.Object obj = GetParentSelectedObject(parentRack);
                                    if (obj != null)
                                    {
                                        // добавляем новый стеллаж к текущему сектору
                                        obj.Items.Add(rack.Text, rack);
                                        // очищаем выбранные объекты после текущего сектора
                                        ClearSelectedObjectsAfterThis(obj);
                                        // добавляем новый стеллаж в список выбранных
                                        AddSelectedObject(rack);
                                        // и выбираем текущий объект для редактирования
                                        ChangeSelectedObject(rack);
                                    }
                                }
                                else
                                    MessageBox.Show("Новый стеллаж не был создан.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                    }
                    else MessageBox.Show("Можно создать стеллаж либо внутри сектора, либо как копию существующего стеллажа. Сейчас выбран объект другого типа.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        /// <summary>
        /// Добавление мест хранения для текущего стеллажа
        /// (редактирование с помощью мастера)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddPlace_Click(object sender, EventArgs e)
        {
            if (viewObject.Source != null && viewObject.Source is Controls.D3.D2Rack)
            {
                Controls.D3.D2Rack parentRack = (Controls.D3.D2Rack)viewObject.Source;

                RackPlacesForm form = new RackPlacesForm();
                form.Rack = parentRack;
                form.ShowDialog();

                // обновляем вид объекта
                ChangeSelectedObject(viewObject.Source);
                //viewD3.RefreshView();
                RefreshView();
            }
            else
                MessageBox.Show("Места хранения можно добавлять только в стеллаж. Сейчас выбран другой объект.", "Действие не допустимо", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        /// <summary>
        /// Обработчик события изменения параметров объекта - сохраняем изменения
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void editObjectProperties_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            try
            {
                Controls.D3.Object changedObject = (Controls.D3.Object)editObjectProperties.SelectedObject;
                if (changedObject is Controls.D3.D2Sector)
                {
                    // обновляем свойства сектора в БД
                    Data.D3.UpdateSectorObject((Controls.D3.D2Sector)editObjectProperties.SelectedObject);
                    // 
                    // обновляем вид объекта
                    // viewObject.RefreshView();
                    ChangeSelectedObject(viewObject.Source);
                    // viewD3.RefreshView();
                    // RefreshView();
                    FillSectorsFromDB();
                }
                else if (changedObject is Controls.D3.D2Rack)
                {
                    // обновляем свойства сектора в БД
                    Data.D3.UpdateRackObject((Controls.D3.D2Rack)editObjectProperties.SelectedObject);
                    // обновляем вид объекта
                    // viewObject.RefreshView();
                    ChangeSelectedObject(viewObject.Source);
                    // viewD3.RefreshView();
                    RefreshView();
                }
                else if (changedObject is Controls.D3.D2Place)
                {
                    Data.D3.UpdatePlaceObject((Controls.D3.D2Place)editObjectProperties.SelectedObject);
                    ChangeSelectedObject(viewObject.Source);
                    RefreshView();
                }

                if (changedObject != null)
                    // при смене названия объекта меняем его для ссылки
                    if (e.ChangedItem.Label == "Текст")
                        ChangeSelectedObjectTextLabel(changedObject.ID, changedObject.Text);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        /// <summary>
        /// Удаление текущего объекта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteObject_Click(object sender, EventArgs e)
        {
            if (viewObject.Source != null)
                if (MessageBox.Show("Удалить выбранный объект?", "Удалить?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                if (viewObject.Source is WMSOffice.Controls.D3.D2Sector)
                    try
                    {
                        WMSOffice.Controls.D3.D2Sector sector = (WMSOffice.Controls.D3.D2Sector)viewObject.Source;
                        SelectParentObject(sector);
                        // удаление сектора
                        sectorsTableAdapter.Delete(sector.ID);
                        // из списка секторов филиала удаляем запись
                        Data.D3.SectorsRow sr = d3.Sectors.FindBySector_ID(sector.ID);
                        if (sr != null) sr.Delete();
                        // обновляем схему
                        RefreshView();
                    }
                    catch (Exception ex)
                    {
                        ShowError(ex);
                    }
                else if (viewObject.Source is WMSOffice.Controls.D3.D2Rack)
                    try
                    {
                        WMSOffice.Controls.D3.D2Rack rack = (WMSOffice.Controls.D3.D2Rack)viewObject.Source;
                        WMSOffice.Controls.D3.Object parentObject = GetParentSelectedObject(rack);
                        // удаление стеллажа из БД
                        Data.D3.DeleteRackObject(rack);
                        // удаляем стеллаж из элементов родительского объекта
                        if (parentObject.Items.ContainsKey(rack.Text)) parentObject.Items.Remove(rack.Text);
                        // выбираем родительский объект
                        ChangeSelectedObject(parentObject);
                        // удаляем стеллаж из выбранных объектов
                        ClearSelectedObjectsAfterThis(parentObject);
                        // обновляем схему
                        //viewD3.RefreshView();
                        RefreshView();
                    }
                    catch (Exception ex)
                    {
                        ShowError(ex);
                    }
        }
        #endregion

        #region маршруты

        private WMSOffice.Controls.D3.Routes _selectedRoutes = new WMSOffice.Controls.D3.Routes();

        /// <summary>
        /// Обработчик смены выбранного маршрута
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbRoutes_SelectedIndexChanged(object sender, EventArgs e)
        {
            _inRouteDesignMode = false;
            _selectedRoutes.Clear();
            if (lbRoutes.SelectedItem != null)
            {
                // сбрасываем выбор последовательности маршрутов
                bool softChange = _softChange;
                _softChange = true;
                lbRoutePlans.SelectedIndex = -1;
                _softChange = softChange;
                // выбираем текущий маршрут
                Data.D3.RoutesRow routeRow = (Data.D3.RoutesRow)((DataRowView)lbRoutes.SelectedItem).Row;
                WMSOffice.Controls.D3.Route route = Data.D3.GetRouteObject(routeRow);
                _selectedRoutes.Add(route);
                editRouteControl.SelectedObject = route;
            }
            else editRouteControl.SelectedObject = null;
            btnEditRoute.Enabled = btnDeleteRoute.Enabled = (lbRoutes.SelectedItem != null);
            
            if (!_softChange)
                RefreshView();
        }

        /// <summary>
        /// Обработчик события изменения свойств выбранного объекта маршрута
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void editRouteControl_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            try
            {
                if (editRouteControl.SelectedObject is Controls.D3.Route)
                {
                    // обновление маршрута
                    int index = lbRoutes.SelectedIndex;
                    Controls.D3.Route route = (Controls.D3.Route)editRouteControl.SelectedObject;
                    Data.D3.UpdateRouteObject(route);
                    _softChange = true;
                    LoadRoutes();
                    _softChange = false;
                    lbRoutes.SelectedIndex = index;
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        /// <summary>
        /// Метод создания нового маршрута для текущего сектора
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddRoute_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbSectors.SelectedItem != null)
                {
                    Data.D3.SectorsRow sectorRow = (Data.D3.SectorsRow)cbSectors.SelectedItem;
                    if (MessageBox.Show(
                        String.Format("Вы действительно хотите создать новый маршрут в секторе \"{0}\"?", sectorRow.Sector_Name),
                        "Новый маршрут", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // создание нового маршрута
                        Data.D3.RoutesDataTable newRoute = routesTableAdapter.Create(sectorRow.Sector_ID);

                        if (newRoute != null && newRoute.Count == 1)
                        {
                            // добавляем новый маршрут в список маршрутов
                            WMSOffice.Data.D3.RoutesRow newRouteRow = (WMSOffice.Data.D3.RoutesRow)newRoute[0];
                            d3.Routes.ImportRow(newRouteRow);
                            // сразу выбираем его для отображения и редактирования
                            lbRoutes.SelectedItem = newRouteRow;
                        }
                        else
                            MessageBox.Show("Новый маршрут не был создан.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        /// <summary>
        /// Локальная коллекция последовательности мест хранения, представляющая собой измененный участок маршрута
        /// </summary>
        private Controls.D3.Route _designRoute = null;// = new WMSOffice.Controls.D3.Route();

        private bool _inRouteDesignMode = false;
        private int _firstRouteLinePoint = 0;
        private int _firstRoutePoint = 0; // "0" - нет значения, "-1" - с начала маршрута

        /// <summary>
        /// Метод создания маршрута (переводит функцию выбора объектов в специальный режим)
        /// Использование: пользователь может последовательно выбирать пары объектов*, которые будут добавляться в маршрут. 
        /// Если будет найдена последовательность пар в существующем маршруте - отрезок будет заменен на новый.
        /// * - пара объектов, это пара мест хранения, принадлежащая одному стеллажу (либо точки Старт, Финиш)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditRoute_Click(object sender, EventArgs e)
        {
            // позволяем пользователю изменять маршрут с Ctrl
            if (lbRoutes.SelectedItem != null)
                if (MessageBox.Show("Вы переходите в режим определения маршрута. Для выбора мест хранения используйте клавишу Ctrl.\n\nНачалом последовательности должен быть либо отрезок маршрута, либо точка начала маршрута. Ввод последовательности завершиться, если Вы выберите существующий отрезок либо точку конца маршрута.\n\nНажмите ОК для продолжения.", "Информация", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    Data.D3.RoutesRow routeRow = (Data.D3.RoutesRow)((DataRowView)lbRoutes.SelectedItem).Row;
                    _designRoute = Data.D3.GetRouteObject(routeRow, false);
                    _designRoute.Style = new Style() { BackColor = Color.Orange, BorderColor = Color.OrangeRed, ForeColor = Color.OrangeRed, BorderWidth = 5, Name = "Orange" };
                    _inRouteDesignMode = true;
                    _firstRouteLinePoint = 0;
                    _firstRoutePoint = 0;
                    _selectedRoutes.Add(_designRoute);
                    RefreshView();
                }
        }

        /// <summary>
        /// Метод добавления выбранной точки в маршрут "хождения" по складу
        /// </summary>
        /// <param name="objectID">Идентификатор места хранения; либо -1 (начало), либо -2 (конец)</param>
        private void AddPlaceToDesignRoutes(int placeID)
        {
            if (!_inRouteDesignMode) MessageBox.Show("Вы не находитесь в режиме определения маршрута!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (SelectedRoute == null) MessageBox.Show("Нет выбранного маршрута!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (placeID == -1)
            {
                if (_designRoute.Places.Count == 0 && _firstRouteLinePoint == 0)
                {
                    if (MessageBox.Show("Вы выбрали сам сектор. Воспринимать это за желание выбрать начало маршрута?", "Выбрать начало маршрута?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    { 
                        // начало маршрута с точки старта
                        _firstRoutePoint = -1;
                    }
                }
                else if (_designRoute.Places.Count > 0 && _firstRouteLinePoint == 0)
                {
                    if (MessageBox.Show("Вы выбрали сам сектор. Воспринимать это за желание выбрать конец маршрута?", "Выбрать конец маршрута?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        // конец маршрута в точке финиша
                        UpdateSelectedRoute(_firstRoutePoint, -1);
                    }
                }
            } else if (_firstRouteLinePoint == 0)
            {
                // начало отрезка
                _firstRouteLinePoint = placeID;
                _designRoute.Places.Add(new RoutePlace() { FromPlace = placeID, ToPlace = placeID });
                RefreshView();
            }
            else
            {
                // конец отрезка
                if ((int)routesTableAdapter.CheckPlaces(_firstRouteLinePoint, placeID) == 1)
                {
                    _designRoute.Places[_designRoute.Places.Count-1].ToPlace = placeID;
                    _firstRouteLinePoint = 0;
                    // если это первый отрезок (не Старт), проверяем на совпадение с существующим отрезком маршрута
                    if (_firstRoutePoint == 0 && _designRoute.Places.Count == 1)
                    {
                        RoutePlace thisPlace = _designRoute.Places[0];
                        int oldPlace = 0;
                        foreach (RoutePlace place in SelectedRoute.Places)
                            if (thisPlace.IsEqualTo(place)) { oldPlace = place.ID; break; }
                        if (oldPlace == 0)
                        {
                            MessageBox.Show("Первый отрезок маршрута не найден в редактируемом маршруте! Необходимо либо выбрать началом точку Старта маршрута, либо выбрать существующий в редактируемом маршруте отрезок. Текущий отрезок маршрута не сохранен.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            _designRoute.Places.Remove(thisPlace);
                        }
                        else { _firstRoutePoint = oldPlace; thisPlace.ID = oldPlace; }
                    }
                    // если это не первый отрезок (либо первым был Старт), проверяем, не является ли это существующим отрезком маршрута, т.е. концом редактирования
                    else if (_firstRoutePoint == -1 || _designRoute.Places.Count > 1)
                    {
                        RoutePlace thisPlace = _designRoute.Places[_designRoute.Places.Count - 1];
                        int oldPlace = 0;
                        foreach (RoutePlace place in SelectedRoute.Places)
                            if (thisPlace.IsEqualTo(place)) { oldPlace = place.ID; break; }
                        if (oldPlace != 0)
                        {
                            // нашли совпадение отрезков, завершено редактирование
                            //if (_firstRoutePoint >= oldPlace)
                            //{
                            //    MessageBox.Show("Обнаружен замкнутый бесконечный контур маршрута. Циклы не допустимы! Текущий отрезок маршрута не сохранен.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //    _designRoute.Places.Remove(thisPlace);
                            //}
                            //else
                            //{
                                thisPlace.ID = oldPlace;
                                // проводим редактирование существующего маршрута
                                UpdateSelectedRoute(_firstRoutePoint, oldPlace);
                            //}
                        }
                    }
                }
                else MessageBox.Show("Выбранная точка не может являться концом отрезка (например, они с первой точкой принадлежат разным объектам). Последний отрезок удален из списка.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                RefreshView();
            }
        }

        /// <summary>
        /// Метод завершения редактирования отрезков маршрута
        /// </summary>
        private void UpdateSelectedRoute(int fromRoutePlace, int toRoutePlace)
        {
            using (Data.D3TableAdapters.RoutePlacesTableAdapter adapter = new WMSOffice.Data.D3TableAdapters.RoutePlacesTableAdapter())
            {
                // определяем количество добавляемых строк
                int newPlacesCount = _designRoute.Places.Count + ((fromRoutePlace == -1) ? 1 : 0) + ((toRoutePlace == -1) ? 1 : 0);

                int positionRange = (fromRoutePlace == -1) ? 0 : -1; // "-1" до диапазона, "0" в диапазоне (удаляем), "1" после диапазона (изменяем порядок)
                int sequence = 1;

                // удаление                
                foreach (RoutePlace place in SelectedRoute.Places)
                    // если нашли отрезок начала изменений
                    if (positionRange == -1 && place.ID == fromRoutePlace)
                        positionRange = 0;
                    // если еще не нашли начало отрезка начала изменений
                    else if (positionRange == -1)
                        sequence++;
                    // если нашли конец отрезка изменений
                    else if (positionRange == 0 && place.ID == toRoutePlace)
                    {
                        // добавляем новые строки
                        foreach (RoutePlace nplace in _designRoute.Places)
                            if (nplace.ID != fromRoutePlace && nplace.ID != toRoutePlace)
                            {
                                Data.D3.RoutePlacesDataTable placesTable = adapter.AddPlace(SelectedRoute.ID, nplace.FromPlace, nplace.ToPlace, sequence);
                                if (placesTable != null && placesTable.Count == 1)
                                {
                                    sequence++;
                                }
                                else MessageBox.Show("Ошибка обновления маршрута. Не смогли вставить строку в таблицу базы данных.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        // изменяем индекс строки, завершающей редактируемый отрезок
                        adapter.Update(place.ID, sequence);
                        sequence++;
                        positionRange = 1;
                    }
                    // если уже вышли за рамки этого отрезка
                    else if (positionRange == 1)
                    {
                        adapter.Update(place.ID, sequence);
                        sequence++;
                    }
                    // если находимся внутри отрезка изменений
                    else if (positionRange == 0)
                        adapter.Delete(place.ID);

                if (toRoutePlace == -1)
                    // добавление строк
                    foreach (RoutePlace nplace in _designRoute.Places)
                        if (nplace.ID != fromRoutePlace && nplace.ID != toRoutePlace)
                        {
                            Data.D3.RoutePlacesDataTable placesTable = adapter.AddPlace(SelectedRoute.ID, nplace.FromPlace, nplace.ToPlace, sequence);
                            if (placesTable != null && placesTable.Count == 1)
                            {
                                sequence++;
                            }
                            else MessageBox.Show("Ошибка обновления маршрута. Не смогли вставить строку в таблицу базы данных.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
            }
            //MessageBox.Show(String.Format("Удалить {0} строк, вставить {1} строк, изменить порядок {2} строк.",
            //    toRoutePlace - fromRoutePlace, _designRoute.Places.Count, SelectedRoute.Places.Count - (toRoutePlace - fromRoutePlace)));
            LoadRoutes();
            RefreshView();
        }

        /// <summary>
        /// Выбранный маршрут (исп. обращение при редактировании маршрута)
        /// </summary>
        private Route SelectedRoute
        {
            get
            {
                return (editRouteControl.SelectedObject != null) ? (Route)editRouteControl.SelectedObject : null;
            }
        }

        /// <summary>
        /// Метод удаления маршрута
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteRoute_Click(object sender, EventArgs e)
        {
            if (lbRoutes.SelectedItem != null)
                if (MessageBox.Show("Удалить выбранный маршрут?", "Удалить?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    try
                    {
                        Data.D3.RoutesRow routeRow = (Data.D3.RoutesRow)((DataRowView)lbRoutes.SelectedItem).Row;
                        routesTableAdapter.Delete(routeRow.Route_ID);
                        LoadRoutes();
                    }
                    catch (Exception ex)
                    {
                        ShowError(ex);
                    }
        }

        #endregion

        #region карты маршрутов

        /// <summary>
        /// Обработчик смены выбранной карты маршрутов
        /// </summary>
        private void lbRoutePlans_SelectedIndexChanged(object sender, EventArgs e)
        {
            _inRouteDesignMode = false;
            _selectedRoutes.Clear();
            if (lbRoutePlans.SelectedItem != null)
            {
                // сбрасываем выбор маршрута
                bool softChange = _softChange;
                _softChange = true;
                lbRoutes.SelectedIndex = -1;
                _softChange = softChange;
                // выбираем все маршруты текущей карты маршрутов
                Data.D3.RoutePlansRow routePlanRow = (Data.D3.RoutePlansRow)((DataRowView)lbRoutePlans.SelectedItem).Row;
                using (Data.D3TableAdapters.RoutesSequenceTableAdapter adapter = new WMSOffice.Data.D3TableAdapters.RoutesSequenceTableAdapter())
                {
                    adapter.Fill(d3.RoutesSequence, routePlanRow.Route_Plan_ID);
                    if (d3.RoutesSequence.Count > 0)
                        foreach (Data.D3.RoutesSequenceRow seq in d3.RoutesSequence)
                        {
                            Data.D3.RoutesRow routeRow = d3.Routes.FindByRoute_ID(seq.Route_ID);
                            if (routeRow != null)
                                _selectedRoutes.Add(Data.D3.GetRouteObject(routeRow));
                        }
                }
            }

            btnEditRoutePlan.Enabled = btnDeleteRoutePlan.Enabled = (lbRoutePlans.SelectedItem != null);

            if (!_softChange)
                RefreshView();
        }

        /// <summary>
        /// Выбранный филиал
        /// </summary>
        private string SelectedWarehouseID
        {
            get { return (cbWarehouses.SelectedItem != null) ? ((Data.D3.WarehousesRow)((DataRowView)cbWarehouses.SelectedItem).Row).Warehouse_ID : ""; }
        }

        /// <summary>
        /// Метод добавления карты маршрутов
        /// </summary>
        private void btnAddRoutePlan_Click(object sender, EventArgs e)
        {
            RoutePlanEditForm form = new RoutePlanEditForm();
            form.WarehouseID = SelectedWarehouseID;
            if (form.ShowDialog() == DialogResult.OK)
            {
                // добавляем новую последовательность маршрутов
                LoadRoutePlans();
            }
        }

        /// <summary>
        /// Метод изменения карты маршрутов
        /// </summary>
        private void btnEditRoutePlan_Click(object sender, EventArgs e)
        {
            if (lbRoutePlans.SelectedItem != null)
            {
                Data.D3.RoutePlansRow routePlan = (Data.D3.RoutePlansRow)((DataRowView)lbRoutePlans.SelectedItem).Row;
                RoutePlanEditForm form = new RoutePlanEditForm();
                form.WarehouseID = SelectedWarehouseID;
                form.RoutePlanID = routePlan.Route_Plan_ID;
                form.RoutePlanName = routePlan.Route_Plan_Name;
                form.RoutePlanType = routePlan.Route_Plan_Type;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // обновляем последовательность маршрутов
                    LoadRoutePlans();
                }
            }
        }

        /// <summary>
        /// Метод удаления карты маршрутов
        /// </summary>
        private void btnDeleteRoutePlan_Click(object sender, EventArgs e)
        {
            if (lbRoutePlans.SelectedItem != null)
            {
                Data.D3.RoutePlansRow routePlan = (Data.D3.RoutePlansRow)((DataRowView)lbRoutePlans.SelectedItem).Row;
                if (MessageBox.Show(String.Format("Удалить карту маршрутов \"{0}\"?", routePlan.Route_Plan_Name), "Удалить?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    // удаляем последовательность маршрутов
                    routePlansTableAdapter.Delete(routePlan.Route_Plan_ID);
                    LoadRoutePlans();
                }
            }
        }

        #endregion

        #region Export to JDE

        private void miExportPlacesToJDE_Click(object sender, EventArgs e)
        {
            if (cbWarehouses.SelectedItem != null)
                if (MessageBox.Show("Вы действиетльно хотите выполнить экспорт схемы склада в систему JDE?", "Подтверждение действия", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        using (Data.D3TableAdapters.QueriesTableAdapter adapter = new WMSOffice.Data.D3TableAdapters.QueriesTableAdapter())
                        {
                            adapter.ExportPlacesToJDE(SelectedWarehouseID);
                            MessageBox.Show(String.Format("Экспорт данных в JDE по складу '{0}' успешно завершен.", SelectedWarehouseID), "Экспорт", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowError(ex);
                    }
                }
        }

        private void miExportRoutePlanToJDE_Click(object sender, EventArgs e)
        {
            if (lbRoutePlans.SelectedItem != null)
                if (MessageBox.Show("Вы действиетльно хотите выполнить экспорт карты маршрутов в систему JDE?", "Подтверждение действия", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        using (Data.D3TableAdapters.QueriesTableAdapter adapter = new WMSOffice.Data.D3TableAdapters.QueriesTableAdapter())
                        {
                            Data.D3.RoutePlansRow routePlan = (Data.D3.RoutePlansRow)((DataRowView)lbRoutePlans.SelectedItem).Row;
                            adapter.ExportRouteToJDE(routePlan.Route_Plan_ID);
                            MessageBox.Show(String.Format("Экспорт данных в JDE по карте маршрутов '{0}' успешно завершен.", routePlan.Route_Plan_Name), "Экспорт", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowError(ex);
                    }
                }
        }

        #endregion

    }
}
