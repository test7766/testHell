using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.D3;

namespace WMSOffice.Dialogs.D3
{
    /// <summary>
    /// Форма администрирования стеллажа - простое добавление/удаление мест хранения
    /// </summary>
    public partial class RackPlacesForm : Form
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        public RackPlacesForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик события загрузки формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RackPlacesForm_Load(object sender, EventArgs e)
        {
            // получаем типы мест хранения
            this.placeTypesTableAdapter.Fill(this.d3.PlaceTypes);
            // получаем список мест стеллажа
            RefreshPlaces();

            // определение реального направления мест            
            if (Rack != null && Rack.Items.Count > 1 && Rack.Items.ContainsKey("1") && Rack.Items.ContainsKey("2"))
                cbDirection.SelectedIndex = (Rack.Items["2"].Position.X - Rack.Items["1"].Position.X > 0) ? 0 : 1;
            else
                cbDirection.SelectedIndex = 0;
            // обновить предварительный просмотр
            RefreshPreview();

            _inLoadingMode = false;
        }

        /// <summary>
        /// получаем список мест стеллажа
        /// </summary>
        private void RefreshPlaces()
        {
            if (Rack != null)
            {
                this.placesTableAdapter.Fill(this.d3.Places, Rack.ID, SessionID);
                this.d3.Places.Columns.Add("ForSort", typeof(int), "Convert(Place_Name, 'System.Int32')");
                this.d3.Places.DefaultView.Sort = "ForSort";
                lbPlaces.DataSource = this.d3.Places.DefaultView;
            }
        }

        #region Fields

        private bool _inLoadingMode = true;

        // стеллаж
        private Controls.D3.D2Rack _rack = null;

        // размещение стеллажа в начало координат
        private Point3D zeroPoint = new Point3D(0, 0, 0);

        #endregion

        #region Properties

        /// <summary>
        /// Стеллаж, который нужно наполнить местами хранения
        /// </summary>
        public Controls.D3.D2Rack Rack {
            get { return _rack; }
            set {
                _rack = value;
                preview.Source = _rack;
                tbName.Text = _rack.Text;
            }
        }

        /// <summary>
        /// Сессия пользователя
        /// </summary>
        public int SessionID { get; set; }

        #endregion

        /// <summary>
        /// Обновление предварительного просмотра
        /// </summary>
        private void RefreshPreview()
        {
            if (Rack != null)
            {
                // перемещаем стеллаж в начало координат и убираем поворот
                Point3D position = Rack.Position;
                Rack.Position = zeroPoint;
                int rotation = Rack.Rotation;
                Rack.Rotation = 0;

                // формирование изображения
                //Bitmap bmp = new Bitmap(Rack.Size.Width, Rack.Size.Depth);
                //Graphics g = Graphics.FromImage(bmp);
                //Rack.Draw(null, g);
                //picPreview.Image = bmp;
                preview.RefreshView();

                // восстановление параметров
                Rack.Rotation = rotation;
                Rack.Position = position;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Добавление нового места хранения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddPlace_Click(object sender, EventArgs e)
        {
            if (lbTypes.SelectedItem != null)
            {
                try
                {
                    int totalWidth = 0; // общая ширина уже добавленных ячеек, каждая из которых имеет свою ширину
                    foreach (Data.D3.PlacesRow placeRow in d3.Places)
                        totalWidth += placeRow.Width;
                    // добавление места хранения
                    Data.D3.PlaceTypesRow placeType = (Data.D3.PlaceTypesRow)((DataRowView)lbTypes.SelectedItem).Row;
                    Data.D3.PlacesDataTable newPlace = placesTableAdapter.AddPlaceToRack(
                        Rack.ID, placeType.Place_Type_ID, 
                        (lbPlaces.Items.Count + 1).ToString(), 
                        (cbDirection.SelectedIndex == 0)
                            ? totalWidth
                            : Rack.Size.Width - placeType.Width - totalWidth,
                        (nudSectionSize.Value == 0) ? String.Empty : (lbPlaces.Items.Count / (int)nudSectionSize.Value + 1).ToString()
                        );
                    if (newPlace != null && newPlace.Count == 1)
                    {
                        // добавляем строку с местом хранения в список
                        this.d3.Places.ImportRow(newPlace[0]);
                        // получаем объект
                        D2Place place = Data.D3.GetPlaceObject(newPlace[0]);
                        // добавляем ячейки к указанному типу места хранения
                        LoadCellByPlace(ref place, newPlace[0].Place_Type_ID);
                        // добавляем новый объект "место хранения" в стеллаж
                        Rack.Items.Add(place.Text, place);
                    }
                    // обновление предварительного просмотра
                    RefreshPreview();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка при добавлении места хранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Чтобы добавить место хранения нужно выбрать тип места.", "Добавление невозможно", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        /// <summary>
        /// Наполнение места хранения стеллажа ячейками
        /// </summary>
        /// <param name="place"></param>
        /// <param name="placeTypeID"></param>
        private void LoadCellByPlace(ref WMSOffice.Controls.D3.D2Place place, string placeTypeID)
        {
            // загрузка ячеек для типов мест хранения
            using (Data.D3TableAdapters.CellsTableAdapter cellAdapter = new WMSOffice.Data.D3TableAdapters.CellsTableAdapter())
            {
                Data.D3.CellsDataTable cellTable = cellAdapter.GetDataByPlaceType(placeTypeID);
                if (cellTable != null && cellTable.Count > 0)
                    foreach(Data.D3.CellsRow cellRow in cellTable)
                    {
                        WMSOffice.Controls.D3.D2Cell cell = Data.D3.GetCellObject(cellRow, String.Empty);
                        place.Items.Add(cell.Text, cell);
                    }
            }
        }

        /// <summary>
        /// Метод удаления последнего места хранения из списка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeletePlace_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbPlaces.Items.Count > 0)
                {
                    if (MessageBox.Show("Удалить последнее место в списке мест?", "Удалить?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Data.D3.PlacesRow placesRow = (Data.D3.PlacesRow)((DataRowView)lbPlaces.Items[lbPlaces.Items.Count - 1]).Row;
                        // удаление объекта из БД
                        placesTableAdapter.Delete(placesRow.Place_ID);
                        // удаление места хранения из дочерних объектов стеллажа
                        if (Rack.Items.ContainsKey(placesRow.Place_Name))
                            Rack.Items.Remove(placesRow.Place_Name);
                        // удаление из списка мест
                        d3.Places.RemovePlacesRow(placesRow);
                        // обновление предварительного просмотра
                        RefreshPreview();
                    }
                }
                else
                    MessageBox.Show("Нельзя удалить место хранения. Список пуст.", "Удаление невозможно", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обработчик события изменения направления нумерации мест хранения в стеллаже
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbPlaces.Items.Count > 0 && !_inLoadingMode)
                if (MessageBox.Show("Смена направления нумерации приведет к обновлению координат всех мест хранения внутри выбранного сталлажа. Поменять направление нумерации?", "Поменять направление нумерации?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int totalWidth = 0; // - общая накопленная ширина
                    // обновить координаты X всех мест хранения
                    // обновить значения всех объектов внутри стеллажа
                    foreach (DataRowView drv in d3.Places.DefaultView)
                    {
                        Data.D3.PlacesRow placeRow = (Data.D3.PlacesRow)drv.Row;
                        int placeNum = 0;
                        if (int.TryParse(placeRow.Place_Name, out placeNum))
                        {
                            placeRow.X = (cbDirection.SelectedIndex == 0)
                                ? totalWidth
                                : Rack.Size.Width - totalWidth - placeRow.Width;
                            totalWidth += placeRow.Width;
                            Rack.Items[placeRow.Place_Name].Position.X = placeRow.X;
                        }
                    }
                    // сохраняем изменения в БД
                    placesTableAdapter.Update(d3.Places);
                    // обновляем предварительный просмотр
                    RefreshPreview();
                }
        }

        /// <summary>
        /// Отображение формы редактирования типа места хранения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditPlaceType_Click(object sender, EventArgs e)
        {
            PlaceTypeEditForm form = new PlaceTypeEditForm();
            form.ShowDialog();
        }


    }
}
