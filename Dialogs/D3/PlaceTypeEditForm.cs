using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.D3
{
    /// <summary>
    /// Форма редактирования типов мест хранения
    /// </summary>
    public partial class PlaceTypeEditForm : DialogForm
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        public PlaceTypeEditForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик события загрузки формы
        /// </summary>
        private void PlaceTypeEditForm_Load(object sender, EventArgs e)
        {
            LoadPlaceTypes();
        }

        /// <summary>
        /// Загрузка списка типов мест хранения
        /// </summary>
        private void LoadPlaceTypes()
        {
            string index = (_selectedPlaceTypeRow != null) ? _selectedPlaceTypeRow.Place_Type_ID : "";

            _selectedPlaceTypeRow = null;
            _selectedCellRow = null;
            cbPlaceType.SelectedIndex = -1;
            this.placeTypesTableAdapter.Fill(this.d3.PlaceTypes);

            if (!String.IsNullOrEmpty(index) && this.d3.PlaceTypes.Count > 0)
            {
                cbPlaceType.SelectedIndex = 0;
                foreach (DataRowView item in cbPlaceType.Items)
                    if (((Data.D3.PlaceTypesRow)item.Row).Place_Type_ID == index)
                    {
                        cbPlaceType.SelectedItem = item;
                        break;
                    }
            }
            else if (d3.PlaceTypes.Count > 0)
            {
                cbPlaceType.SelectedIndex = 0;
            }
            cbPlaceType_SelectedIndexChanged(null, null);
        }

        /// <summary>
        /// Выбранный тип места хранения
        /// </summary>
        private Data.D3.PlaceTypesRow _selectedPlaceTypeRow = null;

        /// <summary>
        /// Обработчик события смены типа места хранения
        /// </summary>
        private void cbPlaceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedPlaceTypeRow = (cbPlaceType.SelectedItem != null) ? (Data.D3.PlaceTypesRow)((DataRowView)cbPlaceType.SelectedItem).Row : null;
            if (_selectedPlaceTypeRow != null)
                editPlaceTypeProperties.SelectedObject = Data.D3.GetPlaceTypeObject(_selectedPlaceTypeRow);
            else
                editPlaceTypeProperties.SelectedObject = null;

            RefreshPreview();
            LoadCells();
        }

        /// <summary>
        /// Метод обновления предварительного просмотра
        /// </summary>
        private void RefreshPreview()
        {
            if (_selectedPlaceTypeRow != null)
                preview.Source = Data.D3.GetPlaceObject(_selectedPlaceTypeRow);
            else
                preview.Source = null;
            preview.RefreshView();
        }

        /// <summary>
        /// Загрузка списка ячеек
        /// </summary>
        private void LoadCells()
        {
            string index = (_selectedCellRow != null) ? _selectedCellRow.Cell_ID : "";

            _selectedCellRow = null;
            d3.Cells.Clear();
            if (_selectedPlaceTypeRow != null)
            {
                this.cellsTableAdapter.FillByPlaceType(this.d3.Cells, _selectedPlaceTypeRow.Place_Type_ID);

                if (!String.IsNullOrEmpty(index) && this.d3.Cells.Count > 0)
                {
                    lbCells.SelectedIndex = 0;
                    foreach (DataRowView item in lbCells.Items)
                        if (((Data.D3.CellsRow)item.Row).Cell_ID == index)
                        {
                            lbCells.SelectedItem = item;
                            break;
                        }
                } else if (d3.Cells.Count > 0)
                {
                    lbCells.SelectedIndex = 0;
                }
                lbCells_SelectedIndexChanged(null, null);
            }
        }

        /// <summary>
        /// Выбранная ячейка
        /// </summary>
        private Data.D3.CellsRow _selectedCellRow = null;

        /// <summary>
        /// Выбор ячейки
        /// </summary>
        private void lbCells_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedCellRow = (lbCells.SelectedItem != null) ? (Data.D3.CellsRow)((DataRowView)lbCells.SelectedItem).Row : null;
            if (_selectedCellRow != null)
                editCellProperties.SelectedObject = Data.D3.GetCellObject(_selectedCellRow);
        }

        /// <summary>
        /// Добавление типа мест
        /// </summary>
        private void btnAddPlaceType_Click(object sender, EventArgs e)
        {
            try
            {
                    // создание новой ячейки
                    Data.D3.PlaceTypesDataTable newPlaceType = placeTypesTableAdapter.Create();

                    if (newPlaceType != null && newPlaceType.Count == 1)
                    {
                        // добавляем новый маршрут в список маршрутов
                        WMSOffice.Data.D3.PlaceTypesRow newPlaceTypeRow = (WMSOffice.Data.D3.PlaceTypesRow)newPlaceType[0];
                        d3.PlaceTypes.ImportRow(newPlaceTypeRow);
                        // сразу выбираем его для отображения и редактирования
                        cbPlaceType.SelectedItem = newPlaceTypeRow;
                    }
                    else
                        MessageBox.Show("Новая ячейка не была создана.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Удаление типа мест
        /// </summary>
        private void btnDeletePlaceType_Click(object sender, EventArgs e)
        {
            if (_selectedPlaceTypeRow != null)
                if (MessageBox.Show("Удалить тип места хранения?", "Удалить?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    try
                    {
                        placeTypesTableAdapter.Delete(_selectedPlaceTypeRow.Place_Type_ID);
                        LoadPlaceTypes();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
        }

        /// <summary>
        /// Изменение типа мест
        /// </summary>
        private void editPlaceTypeProperties_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            try
            {
                if (editPlaceTypeProperties.SelectedObject != null)
                {
                    // обновление типа мест
                    Controls.D3.PlaceTypeObject pt = (Controls.D3.PlaceTypeObject)editPlaceTypeProperties.SelectedObject;
                    Data.D3.UpdatePlaceTypeObject(pt, _selectedPlaceTypeRow.Place_Type_ID);
                    LoadPlaceTypes();
                    RefreshPreview();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Добавление ячейки
        /// </summary>
        private void btnAddCell_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedPlaceTypeRow != null)
                {
                    // создание новой ячейки
                    Data.D3.CellsDataTable newCell = cellsTableAdapter.AddCell(_selectedPlaceTypeRow.Place_Type_ID);

                    if (newCell != null && newCell.Count == 1)
                    {
                        // добавляем новый маршрут в список маршрутов
                        WMSOffice.Data.D3.CellsRow newCellRow = (WMSOffice.Data.D3.CellsRow)newCell[0];
                        d3.Cells.ImportRow(newCellRow);
                        // сразу выбираем его для отображения и редактирования
                        lbCells.SelectedItem = newCellRow;
                        RefreshPreview();
                    }
                    else
                        MessageBox.Show("Новая ячейка не была создана.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Удаление ячейки
        /// </summary>
        private void btnDeleteCell_Click(object sender, EventArgs e)
        {
            if (_selectedCellRow != null)
                if (MessageBox.Show("Удалить ячейку?", "Удалить?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    try
                    {
                        Data.D3.CellsRow cellRow = (Data.D3.CellsRow)((DataRowView)lbCells.SelectedItem).Row;
                        cellsTableAdapter.Delete(_selectedPlaceTypeRow.Place_Type_ID, _selectedCellRow.Cell_ID);
                        LoadCells();
                        RefreshPreview();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
        }

        /// <summary>
        /// Изменение ячейки
        /// </summary>
        private void editCellProperties_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            try
            {
                if (editCellProperties.SelectedObject != null)
                {
                    // обновление ячейки
                    Controls.D3.D2Cell cell= (Controls.D3.D2Cell)editCellProperties.SelectedObject;
                    Data.D3.UpdateCellObject(_selectedPlaceTypeRow.Place_Type_ID, _selectedCellRow.Cell_ID, cell);
                    LoadCells();
                    RefreshPreview();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
