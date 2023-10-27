using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;

namespace WMSOffice.Dialogs.Complaints
{
    /// <summary>
    /// Предоставляет методы для генерации изображений штрих-кодов.
    /// </summary>
    public static class BarCodeGenerator
    {
        /// <summary>
        /// Генерирует изображение штрих-кода EAN13.
        /// </summary>
        /// <param name="barcodeString">Строка для формирования штрих-кода.</param>
        /// <returns>Штрих-код EAN13.</returns>
        public static byte[] GetBarcodeEAN13(string barcodeString)
        {
            byte[] result = null;
            using (BarcodeLib.Barcode b = new BarcodeLib.Barcode() { IncludeLabel = true })
            {
                using (Image barCodeImage = b.Encode(
                    BarcodeLib.TYPE.EAN13,
                    barcodeString + CreateChecksum(barcodeString).ToString(),
                    300,
                    70))
                {
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                        barCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                        result = ms.ToArray();
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Генерирует изображение штрих-кода CODE39.
        /// </summary>
        /// <param name="barcodeString">Строка для формирования штрих-кода.</param>
        /// <returns>Штрих-код CODE39.</returns>
        public static byte[] GetBarcodeCODE39(string barcodeString)
        {
            byte[] result = null;
            using (BarcodeLib.Barcode b = new BarcodeLib.Barcode() { IncludeLabel = true })
            {
                using (Image barCodeImage = b.Encode(
                    BarcodeLib.TYPE.CODE39,
                    barcodeString,
                    300,
                    70))
                {
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                        barCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                        result = ms.ToArray();
                    }
                }
            }
            return result;
        }
        
        /// <summary>
        /// Генерирует символ контрольной суммы для штрих-кода EAN13.
        /// </summary>
        /// <param name="EAN">Строковое значение для штрих-кода EAN13.</param>
        /// <returns>Символ контрольной суммы.</returns>
        private static string CreateChecksum(string EAN)
        {
            int csumTotal = 0; // The checksum working variable starts at zero

            // Calculate the checksum value for the message
            for (int charPos = EAN.Length - 1; charPos >= 0; charPos--)
            {
                if (charPos % 2 == 0)
                    csumTotal = csumTotal + int.Parse(EAN.Substring(charPos, 1));
                else
                    csumTotal = csumTotal + (3 * int.Parse(EAN.Substring(charPos, 1)));
            }

            // Calculate the checksum digit
            int remainder = 10 - (csumTotal % 10);
            remainder = remainder % 10;
            return remainder.ToString();
        }
    }
}
