using System.Drawing.Imaging;
using System.IO;

using BarcodeLib;

namespace WMSOffice.Classes
{
    /// <summary>
    /// Класс, который выполняет построение рисунка штрих-кода
    /// </summary>
    public static class BarcodeGenerator
    {
        /// <summary>
        /// Генерирует изображение штрих-кода CODE39
        /// </summary>
        /// <param name="pBarcodeStr">Строка для формирования штрих-кода.</param>
        /// <returns>Изображение штрих-кода CODE39</returns>
        public static byte[] GetBarcodeCODE39(string pBarcodeStr)
        {
            using (var bc = new Barcode() { IncludeLabel = true })
            using (var bcImage = bc.Encode(TYPE.CODE39, pBarcodeStr, 300, 70))
            using (var ms = new MemoryStream())
            {
                bcImage.Save(ms, ImageFormat.Bmp);
                return ms.ToArray();
            }
        }
    }
}
