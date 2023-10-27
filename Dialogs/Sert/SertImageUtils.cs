using System;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace WMSOffice.Dialogs.Sert
{
    /// <summary>
    /// Предоставляет методы для работы с изображениями сертификатов, хранящихся в базах Sert, SertClient и ElCertificateWin.
    /// </summary>
    public class SertImageUtils
    {
        /// <summary>
        /// Распаковывает изображение из формата, в который сжимает TCompress (метод сжатия - LZH5).
        /// </summary>
        /// <param name="inputFileName">Путь к исходному файлу (сжатому при помощи TCompress).</param>
        /// <param name="outputFileName">Путь к конечному файлу (обычному BMP).</param>
        /// <param name="errorString">Буфер для сообщения об ошибке (при удачном выполнении операции заполняется пустой строкой).</param>
        /// <param name="errorStringLength">Размер буфера для сообщения об ошибке (рекомендуется использовать размер буфера более 200 символов).</param>
        [DllImport("TCompressUtils.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        private static extern void UnpackImageFile(string inputFileName, string outputFileName, StringBuilder errorString, int errorStringLength);

        /// <summary>
        /// Упаковывает изображение в формат при помощи компонента TCompress (метод сжатия - LZH5).
        /// </summary>
        /// <param name="inputFileName">Путь к исходному файлу (обычному BMP).</param>
        /// <param name="outputFileName">Путь к конечному файлу (сжатому при помощи TCompress).</param>
        /// <param name="errorString">Буфер для сообщения об ошибке (при удачном выполнении операции заполняется пустой строкой).</param>
        /// <param name="errorStringLength">Размер буфера для сообщения об ошибке (рекомендуется использовать размер буфера более 200 символов).</param>
        [DllImport("TCompressUtils.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        private static extern void PackImageFile(string inputFileName, string outputFileName, StringBuilder errorString, int errorStringLength);

        /// <summary>
        /// Распаковывает изображение из формата, в который сжимает TCompress (метод сжатия - LZH5).
        /// </summary>
        /// <param name="originalImage">Исходное изображение (сжатое при помощи TCompress).</param>
        /// <exception cref="Exception">Ошибка во время распаковки данных.</exception>
        /// <returns>Распакованное изображение в формате BMP (2 bit, Black and White). Сохранить это изображение .NET не сможет (Bitmap.Save() выдаст исключение).</returns>
        public static Bitmap UnpackImageByTCompress(byte[] originalImage)
        {
            Bitmap result = null;
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(UnpackImageByTCompressEx(originalImage)))
            {
                result = new Bitmap(ms);
            }
            return result;
        }

        /// <summary>
        /// Распаковывает изображение из формата, в который сжимает TCompress (метод сжатия - LZH5).
        /// </summary>
        /// <param name="originalImage">Исходное изображение (сжатое при помощи TCompress).</param>
        /// <exception cref="Exception">Ошибка во время распаковки данных.</exception>
        /// <returns>Распакованное изображение в формате BMP (2 bit, Black and White). Сохранить это изображение .NET не сможет (Bitmap.Save() выдаст исключение).</returns>
        public static byte[] UnpackImageByTCompressEx(byte[] originalImage)
        {
            byte[] result = null;
            StringBuilder errors = new StringBuilder(1000);
            string tmpFileOriginal = System.IO.Path.GetTempFileName();
            string tmpFileResult = System.IO.Path.GetTempFileName();
            System.IO.File.WriteAllBytes(tmpFileOriginal, originalImage);
            UnpackImageFile(tmpFileOriginal, tmpFileResult, errors, 1000);
            System.IO.File.Delete(tmpFileOriginal);
            if (errors.Length > 0)
            {
                System.IO.File.Delete(tmpFileResult);
                throw new Exception(errors.ToString());
            }
            else
            {
                result = System.IO.File.ReadAllBytes(tmpFileResult);
                System.IO.File.Delete(tmpFileResult);
            }
            return result;
        }

        /// <summary>
        /// Упаковывает изображение в формат, в который сжимает TCompress (метод сжатия - LZH5).
        /// </summary>
        /// <param name="originalImage">Исходное изображение в формате BMP.</param>
        /// <exception cref="Exception">Ошибка во время упаковки данных.</exception>
        /// <returns>Упакованное изображение в специальном формате.</returns>
        public static byte[] PackImageByTCompress(Bitmap originalImage)
        {
            byte[] result = null;
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                originalImage.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                result = PackImageByTCompressEx(ms.ToArray());
            }
            return result;
        }

        /// <summary>
        /// Упаковывает изображение в формат, в который сжимает TCompress (метод сжатия - LZH5).
        /// </summary>
        /// <param name="originalImage">Исходное изображение.</param>
        /// <exception cref="Exception">Ошибка во время упаковки данных.</exception>
        /// <returns>Упакованное изображение в специальном формате.</returns>
        public static byte[] PackImageByTCompressEx(byte[] originalImage)
        {
            byte[] result = null;
            StringBuilder errors = new StringBuilder(1000);
            string tmpFileOriginal = System.IO.Path.GetTempFileName();
            string tmpFileResult = System.IO.Path.GetTempFileName();
            System.IO.File.WriteAllBytes(tmpFileOriginal, originalImage);
            PackImageFile(tmpFileOriginal, tmpFileResult, errors, 1000);
            System.IO.File.Delete(tmpFileOriginal);
            if (errors.Length > 0)
            {
                System.IO.File.Delete(tmpFileResult);
                throw new Exception(errors.ToString());
            }
            else
            {
                result = System.IO.File.ReadAllBytes(tmpFileResult);
                System.IO.File.Delete(tmpFileResult);
            }
            return result;
        }
        
        /// <summary>
        /// Накладывает печать Оптимы-Фарм на изображение сертификата
        /// </summary>
        /// <param name="bmpSert">Исходное изображение сертификата</param>
        /// <param name="bmpStamp">Изображение печати</param>
        /// <returns>Изображение сертификата с наложенной печатью</returns>
        public static Bitmap DrawOptimaStamp(Bitmap bmpSert, Bitmap bmpStamp)
        {
            // инициализация
            Bitmap result = new Bitmap(bmpSert.Width, bmpSert.Height);
            Graphics gResult = Graphics.FromImage(result);
            gResult.DrawImage(bmpSert, new Rectangle(0, 0, bmpSert.Width, bmpSert.Height), 0, 0, bmpSert.Width, bmpSert.Height, GraphicsUnit.Pixel);

            Bitmap tmpStamp;

            // уменьшим или увеличим размер печати в зависимости от размера сертификата:
            // шаблон = 1600х2300, размер печати при этом 310х310
            // если размер сертификата = 1654х2338, значит, это "двустраничный" сертификат и нужно
            // печать повернуть на 90 градусов по часовой стрелке
            int stampWidth = Convert.ToInt32((float)bmpStamp.Width * (float)result.Width / 1600);
            tmpStamp = new Bitmap(stampWidth, stampWidth);
            using (Graphics gStamp = Graphics.FromImage(tmpStamp))
            {
                gStamp.DrawImage(bmpStamp, new Rectangle(0, 0, tmpStamp.Width, tmpStamp.Height), 0, 0, bmpStamp.Width, bmpStamp.Height, GraphicsUnit.Pixel);
                if (result.Width == 1654 && result.Height == 2338)
                    tmpStamp.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }

            // создаем массив весов, определяем границы анализа
            long[] arrW = { 0, 0, 0, 0, 0, 0, 0, 0 };
            int xLeft = result.Width / 8;
            int xRight = result.Width / 8 * 7;
            int yTop = result.Height / 3 * 2;
            int yBottom = result.Height / 20 * 19;
            int vertStep = (yBottom - yTop) / 2;
            int horStep = (xRight - xLeft) / 4;

            // перебираем диапазоны слева направо, сверху вниз
            // ускорено с использованием измененного класса http://www.gotdotnet.ru/LearnDotNet/NETFramework/529696.aspx
            using (BitmapDecorator bmp = new BitmapDecorator(result))
            {
                for (int i = 0; i < 8; i++)
                {
                    int xmin = xLeft + horStep * (i % 4), xmax = xLeft + horStep * (i % 4 + 1);
                    int ymin = yTop + vertStep * (i / 4), ymax = yTop + vertStep * (i / 4 + 1);
                    for (int x = xmin; x < xmax; x++)
                        for (int y = ymin; y < ymax; y++)
                            arrW[i] += bmp.GetBrightness(x, y);
                }
            }

            // выбираем диапазон с максимальной яркостью пикселов и "ставим" туда печать
            long maxVal = arrW[0];
            int maxNum = 0;
            for (int i = 1; i < 8; i++)
                if (arrW[i] > maxVal)
                {
                    maxVal = arrW[i];
                    maxNum = i;
                }

            Rectangle rect;
            if (maxNum < 4)
                rect = new Rectangle(xLeft + horStep * (maxNum % 4), yTop, tmpStamp.Width, tmpStamp.Width);
            else
                rect = new Rectangle(xLeft + horStep * (maxNum % 4), yTop + vertStep, tmpStamp.Width, tmpStamp.Width);

            gResult.DrawImage(tmpStamp, rect, 0, 0, tmpStamp.Width, tmpStamp.Height, GraphicsUnit.Pixel);
            gResult.Dispose();

            return result;
        }

        #region Class BitmapDecorator

        /// <summary>
        /// Быстрый доступ к пикселам Bitmap
        /// </summary>
        private class BitmapDecorator : IDisposable
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
        #endregion
    }
}
