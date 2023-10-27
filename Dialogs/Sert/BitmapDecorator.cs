using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace WMSOffice.Dialogs.Sert
{
    /// <summary>
    /// Быстрый доступ к пикселам Bitmap
    /// </summary>
    public class BitmapDecorator : IDisposable
    {
        private readonly Bitmap _bitmap;
        private readonly bool _isAlpha;
        private readonly int _width;
        private readonly int _height;
        private BitmapData _bmpData;
        private IntPtr _bmpPtr;
        private byte[] _rgbValues;
        private int index;
        private int b;
        private int r;
        private int g;
        private int a;

        public BitmapDecorator(Bitmap bitmap)
        {
            if (bitmap == null)
                throw new ArgumentNullException();
            _bitmap = bitmap;
            if (_bitmap.PixelFormat == (PixelFormat.Indexed | _bitmap.PixelFormat))
                throw new ArgumentException("Can't work with indexed pixel format");
            _isAlpha = (Bitmap.PixelFormat == (Bitmap.PixelFormat | PixelFormat.Alpha));
            _width = bitmap.Width;
            _height = bitmap.Height;
            Lock();
        }

        #region Properties

        public Bitmap Bitmap
        {
            get { return _bitmap; }
        }

        #endregion


        #region Methods

        private void Lock()
        {
            Rectangle rect = new Rectangle(0, 0, _width, _height);
            _bmpData = Bitmap.LockBits(rect, ImageLockMode.ReadWrite, Bitmap.PixelFormat);
            _bmpPtr = _bmpData.Scan0;
            int bytes = _width * _height * (_isAlpha ? 4 : 3);
            _rgbValues = new byte[bytes];
            Marshal.Copy(_bmpPtr, _rgbValues, 0, _rgbValues.Length);
        }

        private void UnLock()
        {
            // Copy the RGB values back to the bitmap
            Marshal.Copy(_rgbValues, 0, _bmpPtr, _rgbValues.Length);
            // Unlock the bits.
            Bitmap.UnlockBits(_bmpData);
        }

        public Color GetPixel(int x, int y)
        {
            if (x > _width - 1 || y > _height - 1)
                throw new ArgumentException();
            if (_isAlpha)
            {
                index = ((y * _width + x) * 4);
                b = _rgbValues[index];
                g = _rgbValues[index + 1];
                r = _rgbValues[index + 2];
                a = _rgbValues[index + 3];
                return Color.FromArgb(a, r, g, b);
            }
            else
            {
                index = ((y * _width + x) * 3);
                b = _rgbValues[index];
                g = _rgbValues[index + 1];
                r = _rgbValues[index + 2];
                return Color.FromArgb(r, g, b);
            }
        }

        public int GetBrightness(int x, int y)
        {
            if (x > _width - 1 || y > _height - 1)
                throw new ArgumentException();
            index = ((y * _width + x) * 4);
            b = _rgbValues[index];
            g = _rgbValues[index + 1];
            r = _rgbValues[index + 2];
            a = _rgbValues[index + 3];
            return b + g + r;
        }

        #region IDisposable Members

        public void Dispose()
        {
            UnLock();
        }
        #endregion

        #endregion
    }
}
