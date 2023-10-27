using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace WMSOffice.Dialogs.Sert
{
    public class ImageHelper
    {
        /// <summary>
        /// Накладывает печать Оптимы-Фарм на изображение сертификата
        /// </summary>
        /// <param name="bmpSert">Исходное изображение сертификата</param>
        /// <returns>Изображение сертификата с наложенной печатью</returns>
        public static byte[] DrawOptimaStamp(Bitmap bmpSert)
        {
            //Bitmap bmpStamp;
            //using (var ms = new MemoryStream(Properties.Resources.watermark_optima))
            //    bmpStamp = new Bitmap(ms);

            return DrawOptimaStamp(bmpSert, Properties.Resources.watermark_optima);
        }
        /// <summary>
        /// Накладывает печать Оптимы-Фарм на изображение сертификата
        /// </summary>
        /// <param name="bmpSert">Исходное изображение сертификата</param>
        /// <param name="bmpStamp">Изображение печати</param>
        /// <returns>Изображение сертификата с наложенной печатью</returns>
        public static byte[] DrawOptimaStamp(Bitmap bmpSert, Bitmap bmpStamp)
        {
            // инициализация
            Bitmap result = new Bitmap(bmpSert.Width, bmpSert.Height);
            //result.SetResolution(bmpSert.HorizontalResolution, bmpSert.VerticalResolution);
            Graphics gResult = Graphics.FromImage(result);

            //gResult.DrawImageUnscaled(bmpSert, 0, 0);
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

            byte[] buffer = null;
            using (var ms = new MemoryStream())
            {
                result.Save(ms, ImageFormat.Tiff);
                buffer = ms.GetBuffer();
            }

            return buffer;
        }

        /// <summary>
        /// Накладывает печать Оптимы-Фарм на изображение сертификата
        /// </summary>
        /// <param name="bmpSert">Исходное изображение сертификата</param>
        /// <param name="bmpStamp">Изображение печати</param>
        /// <returns>Изображение сертификата с наложенной печатью</returns>
        public static Bitmap DrawOptimaStampExt(Bitmap bmpSert)
        {
            //Bitmap bmpStamp;
            //using (var ms = new MemoryStream(Properties.Resources.watermark_optima))
            //    bmpStamp = new Bitmap(ms);

            Bitmap bmpStamp = Properties.Resources.watermark_optima;

            // инициализация
            Bitmap result = new Bitmap(bmpSert.Width, bmpSert.Height);
            //result.SetResolution(bmpSert.HorizontalResolution, bmpSert.VerticalResolution);
            Graphics gResult = Graphics.FromImage(result);

            //gResult.DrawImageUnscaled(bmpSert, 0, 0);
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

        //public static byte[] DrawOptimaStamp(BitmapFrame frame)
        //{
        //    using (var ms = new MemoryStream())
        //    {
        //        BitmapEncoder enc = new BmpBitmapEncoder();
        //        enc.Frames.Add(frame);
        //        enc.Save(ms);
        //        var bitmap = new Bitmap(ms);

        //        return DrawOptimaStamp(bitmap);
        //    }
        //}
    }
}
