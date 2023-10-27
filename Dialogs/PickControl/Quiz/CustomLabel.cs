using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WMSOffice.Dialogs.PickControl.Quiz
{
    public class CustomLabel : Label
    {
        private readonly Color MouseCapturedColor = Color.Wheat;

        private readonly Color SelectedColor = Color.Thistle;

        #region ПОЛЯ И СВОЙСТВА ДАННЫХ

        public int Position { get; private set; }

        private bool _IsSelected;
        public bool IsSelected
        {
            get { return _IsSelected; }
            set
            {
                _IsSelected = value;
                this.Content = this.Content; // Это необходимо для изменения отформатированного текста

                if (value)
                {
                    if (this.Parent != null)
                        foreach (var otherItem in this.Parent.Controls)
                            if (otherItem is CustomLabel && otherItem != this)
                                (otherItem as CustomLabel).IsSelected = false;
                }

                this.ChangeSelection();
            }
        }

        /// <summary>
        /// Префикс
        /// </summary>
        public string Prefix { get; set; }

        private string _Content = null;
        public string Content
        {
            get { return _Content; }
            set
            {
                _Content = value;
                this.Text = this.FormattedText;
            }
        }

        /// <summary>
        /// Отформатированный текст
        /// </summary>
        public string FormattedText { get { return string.Format("{0}{1}. {2}{3}", this.Prefix, this.Position, this.IsSelected ? "*" : string.Empty, this.Content); } }
        #endregion

        #region СОБЫТИЯ И ДЕЛЕГАТЫ
        public event EventHandler OnApplySelection;

        public event EventHandler OnSelectItem;
        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ

        public CustomLabel(int position)
            : base()
        {
            this.Position = position;
            this.MouseEnter += MouseEnterHandler;
            this.MouseHover += MouseEnterHandler;
            this.MouseLeave += MouseLeaveHandler;
            this.Click += ClickHandler;
            this.DoubleClick += DoubleClickHandler;
        }
        #endregion

        public void ApplySelection()
        {
            if (this.OnApplySelection != null)
                this.OnApplySelection(this, EventArgs.Empty);
        }

        private void MouseEnterHandler(object sender, EventArgs e)
        {
            this.BackColor = this.IsSelected ? this.BackColor : MouseCapturedColor;
        }

        private void MouseLeaveHandler(object sender, EventArgs e)
        {
            this.BackColor = this.IsSelected ? this.BackColor : Color.Transparent;
        }

        private void ChangeSelection()
        {
            this.BackColor = this.IsSelected ? SelectedColor : Color.Transparent;
            //this.BorderStyle = this.IsSelected ? BorderStyle.FixedSingle : BorderStyle.None;
            if (this.IsSelected)
                if (this.OnSelectItem != null)
                    this.OnSelectItem(this, EventArgs.Empty);
        }

        private void ClickHandler(object sender, EventArgs e)
        {
            this.IsSelected = true;
        }

        private void DoubleClickHandler(object sender, EventArgs e)
        {
            this.IsSelected = true;
            this.ApplySelection();
        }

        public static bool HandleKeyForItems(List<CustomLabel> items, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F1:
                    foreach (var item in items)
                        if (item.Position == 1)
                            item.IsSelected = true;
                    return true;
                case Keys.F2:
                    foreach (var item in items)
                        if (item.Position == 2)
                            item.IsSelected = true;
                    return true;
                case Keys.F3:
                    foreach (var item in items)
                        if (item.Position == 3)
                            item.IsSelected = true;
                    return true;
                case Keys.F4:
                    foreach (var item in items)
                        if (item.Position == 4)
                            item.IsSelected = true;
                    return true;
                case Keys.F5:
                    foreach (var item in items)
                        if (item.Position == 5)
                            item.IsSelected = true;
                    return true;
                case Keys.F6:
                    foreach (var item in items)
                        if (item.Position == 6)
                            item.IsSelected = true;
                    return true;
                case Keys.F7:
                    foreach (var item in items)
                        if (item.Position == 7)
                            item.IsSelected = true;
                    return true;
                case Keys.F8:
                    foreach (var item in items)
                        if (item.Position == 8)
                            item.IsSelected = true;
                    return true;
                case Keys.F9:
                    foreach (var item in items)
                        if (item.Position == 9)
                            item.IsSelected = true;
                    return true;
                case Keys.F10:
                    foreach (var item in items)
                        if (item.Position == 10)
                            item.IsSelected = true;
                    return true;
                case Keys.F11:
                    foreach (var item in items)
                        if (item.Position == 11)
                            item.IsSelected = true;
                    return true;
                case Keys.F12:
                    foreach (var item in items)
                        if (item.Position == 12)
                            item.IsSelected = true;
                    return true;
                case Keys.Enter:
                    foreach (var item in items)
                        if (item.IsSelected)
                            item.ApplySelection();
                    return true;
                case Keys.Up:
                    #region ВЫБОР ВЕРХНЕГО ЭЛЕМЕНТА
                    for (int i = 0; i < items.Count; i++)
                    {
                        if (i == items.Count - 1 && !items[i].IsSelected)
                        {
                            items[i].IsSelected = true;
                            break;
                        }

                        if (items[i].IsSelected)
                        {
                            items[i == 0 ? items.Count - 1 : i - 1].IsSelected = true;
                            break;
                        }
                    }
                    #endregion

                    return true;
                case  Keys.Down:
                    #region ВЫБОР НИЖНЕГО ЭЛЕМЕНТА
                    for (int i = 0; i < items.Count; i++)
                    {
                        if (i == items.Count - 1 && !items[i].IsSelected)
                        {
                            items[0].IsSelected = true;
                            break;
                        }

                        if (items[i].IsSelected)
                        {
                            items[i == items.Count - 1 ? 0 : i + 1].IsSelected = true;
                            break;
                        }
                    }
                    #endregion

                    return true;
                default:
                    return false;
            }
        }
    }
}
