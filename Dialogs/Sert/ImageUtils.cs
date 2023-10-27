using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace WMSOffice.Dialogs.Sert
{
    /// <summary>
    /// утилита обработки изображения
    /// </summary>
    public static class ImageUtils
    {
        /// <summary>
        /// Извлечение слоев(страниц) изображения из буфера
        /// </summary>
        /// <param name="imageData"></param>
        /// <param name="extention"></param>
        /// <returns></returns>
        public static List<Image> ExtractImageLayersFromDataBuffer(byte[] imageBytes, string extention)
        {
            var images = new List<Image>();

            try
            {
                switch (extention)
                {
                    case "PDF":
                    case "pdf":
                        var pagesImages = PDFUtils.ExtractPages(imageBytes);
                        foreach (var pageImage in pagesImages)
                            images.Add(pageImage);
                        break;
                    case "TIF":
                    case "TIFF":
                    case "tif":
                    case "tiff":
                        var imageLayers = TIFUtils.GetMultipageImageLayers(imageBytes);
                        foreach (var imageLayer in imageLayers)
                            images.Add(imageLayer);
                        break;
                    default:
                        using (var ms = new MemoryStream(imageBytes))
                            images.Add(Image.FromStream(ms));
                        break;
                }
            }
            catch (Exception ex)
            {

            }

            return images;
        }

        /// <summary>
        /// Извлечение слоев(страниц) изображения из буфера
        /// </summary>
        /// <param name="imageData"></param>
        /// <param name="extention"></param>
        /// <returns></returns>
        public static List<byte[]> ExtractImageLayersFromDataBufferEx(byte[] imageBytes, string extention)
        {
            var images = new List<byte[]>();

            try
            {
                switch (extention)
                {
                    case "PDF":
                    case "pdf":
                        var pagesImages = PDFUtils.ExtractPagesEx(imageBytes);
                        foreach (var pageImage in pagesImages)
                            images.Add(pageImage);
                        break;
                    case "TIF":
                    case "TIFF":
                    case "tif":
                    case "tiff":
                        var imageLayers = TIFUtils.GetMultipageImageLayersEx(imageBytes);
                        foreach (var imageLayer in imageLayers)
                            images.Add(imageLayer);
                        break;
                    default:
                        try
                        {
                            using (var ms = new MemoryStream(imageBytes))
                                images.Add(ms.GetBuffer());
                        }
                        catch (UnauthorizedAccessException)
                        {
                            images.Add(imageBytes);
                        }
                        catch (Exception)
                        {
                            throw;
                        }

                        break;
                }
            }
            catch (Exception ex)
            {

            }

            return images;
        }

        /// <summary>
        /// Подготовка легковесного изображения
        /// </summary>
        /// <param name="origImage"></param>
        /// <param name="extention"></param>
        /// <param name="imageReplacer"></param>
        public static void PrepareLightweightImage(ref Image origImage, string extention, Image imageReplacer)
        {
            try
            {
                switch (extention)
                {
                    case "PDF":
                    case "pdf":
                        break;
                    case "TIF":
                    case "TIFF":
                    case "tif":
                    case "tiff":
                    default:
                        if (origImage != null)
                        {
                            origImage.Dispose();
                            origImage = imageReplacer; // для уменьшения объема требуемой памяти
                        }
                        break;
                }
            }
            catch (Exception ex)
            {

            }
        }

        public static byte[] ConvertToByteArray(Image image, ImageFormat format)
        {
            var imageBuffer = new byte[0];

            using (var ms = new MemoryStream())
            {
                image.Save(ms, format);
                ms.Close();

                imageBuffer = ms.ToArray();
            }

            return imageBuffer;
        }
    }
}
