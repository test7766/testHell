using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace WMSOffice.Dialogs.Sert
{
    /// <summary>
    /// Утилита обработки TIF-формата
    /// </summary>
    public static class TIFUtils
    {
        /// <summary>
        /// Расслоение многостраничного изображения
        /// </summary>
        /// <param name="imageData"></param>
        /// <returns></returns>
        public static List<Image> GetMultipageImageLayers(byte[] imageData)
        {
            var imageLayers = new List<Image>();

            using (MemoryStream ms = new MemoryStream(imageData))
            {
                Image generalImage = Image.FromStream(ms);
                //FrameDimension frameDimension = new FrameDimension(generalImage.FrameDimensionsList[0]);
                int cntFrames = generalImage.GetFrameCount(FrameDimension.Page);

                for (int idxFrame = 0; idxFrame < cntFrames; idxFrame++)
                {
                    generalImage.SelectActiveFrame(FrameDimension.Page, idxFrame);

                    Image layerImage = null;
                    MemoryStream mss = new MemoryStream();

                    generalImage.Save(mss, ImageFormat.Tiff);
                    //generalImage.Save(String.Format("{0}.tiff",Guid.NewGuid()), ImageFormat.Tiff);
                    layerImage = Image.FromStream(mss);


                    //layerImage.Save(String.Format(@"d:\{0}.tiff", Guid.NewGuid()), ImageFormat.Tiff);
                    imageLayers.Add(layerImage);
                }

                generalImage.Dispose();
            }

            return imageLayers;
        }

        /// <summary>
        /// Расслоение многостраничного изображения
        /// </summary>
        /// <param name="imageData"></param>
        /// <returns></returns>
        public static List<byte[]> GetMultipageImageLayersEx(byte[] imageData)
        {
            var imageLayers = new List<byte[]>();

            using (MemoryStream ms = new MemoryStream(imageData))
            {
                Image generalImage = Image.FromStream(ms);
                //FrameDimension frameDimension = new FrameDimension(generalImage.FrameDimensionsList[0]);
                int cntFrames = generalImage.GetFrameCount(FrameDimension.Page);

                for (int idxFrame = 0; idxFrame < cntFrames; idxFrame++)
                {
                    generalImage.SelectActiveFrame(FrameDimension.Page, idxFrame);

                    MemoryStream mss = new MemoryStream();
                    generalImage.Save(mss, ImageFormat.Tiff);
                    imageLayers.Add(mss.GetBuffer());
                }

                generalImage.Dispose();
            }

            return imageLayers;
        }
    }
}
