using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Printing;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace WMSOffice.Classes.ReportProviders.DebtorsReturnedTareInvoice
{
    public static class DebtorsReturnedTareInvoiceHelper
    {
        /// <summary>
        /// Создает отчет - накладную на оборотную тару.
        /// </summary>
        /// <returns>Отчет в виде накладной на оборотную тару.</returns>
        public static Data.PickControl GetTareInvoiceReportData(Data.PrintNakl.DocsRow docsRow, long sessionID, out bool isDraft)
        {
            var doco = docsRow.InvoiceID;
            var dcto = docsRow.SDDCT;
            var kcoo = docsRow.CompanyID;

            var routNumber = docsRow.Rout_Number;
            var deliveryAddressID = docsRow.DeliveryAddressID;

            return GetTareInvoiceReportData(doco, dcto, kcoo, routNumber, deliveryAddressID, sessionID, false, out isDraft);
        }

        public static Data.PickControl GetTareInvoiceReportData(double doco, string dcto, string kcoo, long? routNumber, int? deliveryAddressID, long sessionID, bool forceUpdateStatus, out bool isDraft)
        {
            var pickControlData = new Data.PickControl();

            pickControlData.CT_Tare_Invoice_Copies.LoadDataRow(new object[] { 1 }, true);
            pickControlData.CT_Tare_Invoice_Copies.LoadDataRow(new object[] { 2 }, true);

            isDraft = true;
            var canPrintBlank = false;

            // получим параметры накладной на оборотную тару
            if (routNumber.HasValue && deliveryAddressID.HasValue)
            {
                var find_doco = (long?)null;
                var find_dcto = (string)null;

                using (var adapter = new Data.PickControlTableAdapters.CT_Tare_Invoice_HeaderTableAdapter())
                    adapter.FindDocByDeliveryAddress(routNumber, deliveryAddressID, sessionID, ref find_doco, ref find_dcto);

                if (find_doco.HasValue && !string.IsNullOrEmpty(find_dcto))
                {
                    doco = Convert.ToDouble(find_doco);
                    dcto = find_dcto;

                    canPrintBlank = true;
                }
            }

            var printBlankFlag = (int?)null;

            using (var adapter = new Data.PickControlTableAdapters.CT_Tare_Invoice_HeaderTableAdapter())
                adapter.Fill(pickControlData.CT_Tare_Invoice_Header, doco, dcto, kcoo, ref printBlankFlag);

            if (pickControlData.CT_Tare_Invoice_Header.Rows.Count == 0)
                return null;

            var printStatus = (int?)null;
            using (var adapter = new Data.PickControlTableAdapters.CT_Tare_Invoice_DetailsTableAdapter())
                adapter.Fill(pickControlData.CT_Tare_Invoice_Details, doco, dcto, kcoo, forceUpdateStatus, sessionID, ref printStatus);

            isDraft = Convert.ToBoolean((printStatus ?? 0) == 0);

            // создание изображения штрих-кода
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                using (BarcodeLib.Barcode b = new BarcodeLib.Barcode())
                {
                    b.Encode(
                        BarcodeLib.TYPE.CODE128B, pickControlData.CT_Tare_Invoice_Header[0].Doc_Bar_Code,
                        1600,
                        200).Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                }
                pickControlData.CT_Tare_Invoice_Header[0].Doc_Bar_Code_Image = ms.ToArray();
            }

            // анализ печати бланка ОТ
            if (canPrintBlank && (printBlankFlag ?? 0) == 1)
            {
                using (var adapter = new Data.PickControlTableAdapters.CT_Tare_Invoice_BlankTableAdapter())
                    adapter.Fill(pickControlData.CT_Tare_Invoice_Blank, doco, dcto, kcoo);
            }

            return pickControlData;
        }

        public class DebtorsReturnedTareInvoiceReportPrintController
        {
            private readonly Queue<Action<PrintPageEventArgs>> qActions = new Queue<Action<PrintPageEventArgs>>();

            private readonly bool isDraft;
            
            private readonly Data.PickControl reportData = null;

            private Data.PickControl.CT_Tare_Invoice_HeaderRow Header { get { return reportData.CT_Tare_Invoice_Header[0]; } }

            private Data.PickControl.CT_Tare_Invoice_BlankRow Agreement { get { return reportData.CT_Tare_Invoice_Blank[0]; } }

            public DebtorsReturnedTareInvoiceReportPrintController(bool pIsDraft, Data.PickControl pReportData)
            {
                isDraft = pIsDraft;

                reportData = pReportData;
                InitializeActions();
            }

            public void Restore()
            {
                this.InitializeActions();
            }

            private void InitializeActions()
            {
                if (reportData.CT_Tare_Invoice_Blank.Count > 0)
                {
                    qActions.Enqueue(e =>
                    {
                        PrintAgreement(e);
                    });
                }

                qActions.Enqueue(e =>
                {
                    PrintLayout(e);

                    if (isDraft)
                        PrintPageWatermark(e);

                    for (int i = 0; i < 2; i++)
                        PrintCard(e, i);
                });
            }

            public bool PrintPage(PrintPageEventArgs e)
            {
                if (qActions.Count > 0)
                {
                    var action = qActions.Dequeue();
                    action(e);
                }

                return qActions.Count > 0;
            }

            public void PrintAgreement(PrintPageEventArgs e)
            {
                var font10 = new Font("Arial", 10.0f);
                var font7 = new Font("Arial", 7.0f, FontStyle.Regular);

                var sfFar = new StringFormat();
                sfFar.Alignment = StringAlignment.Far;

                var xIndent = 15;
                var yIndent = 5;
                int xLeft = xIndent;
                int xCurrent = xLeft;
                int yCurrent = yIndent;

                var maxContentWidth = e.PageBounds.Width - xIndent * 2;
                var maxRequisitesWidth = 200;
                var maxMessageWidth = maxContentWidth;

                e.Graphics.DrawImage(Properties.Resources.logo, new RectangleF(xLeft, yCurrent, 100, 30));

                xCurrent = maxContentWidth - maxRequisitesWidth;
                var sRequisites = string.Format("г. Киев, улица Бориспольская 9ж");
                var sizeRequisites = e.Graphics.MeasureString(sRequisites, font7, maxRequisitesWidth, sfFar);
                e.Graphics.DrawString(sRequisites, font7, Brushes.Black, new RectangleF(new PointF(xCurrent, yCurrent), new SizeF(sizeRequisites.Width, sizeRequisites.Height)), sfFar);

                //xCurrent = maxContentWidth - maxRequisitesWidth;
                yCurrent = yCurrent + (yIndent * 2);
                sRequisites = string.Format("тел.: +30 (044) 490-53-10");
                sizeRequisites = e.Graphics.MeasureString(sRequisites, font7, maxRequisitesWidth, sfFar);
                e.Graphics.DrawString(sRequisites, font7, Brushes.Black, new RectangleF(new PointF(xCurrent, yCurrent), new SizeF(sizeRequisites.Width, sizeRequisites.Height)), sfFar);

                xCurrent = xLeft;
                yCurrent = yCurrent + (yIndent * 30);
                var sMessage = string.Format("Уважаемый клиент {0}.", Agreement.Receiver_Name);
                var sizeMessage = e.Graphics.MeasureString(sMessage, font10, maxMessageWidth);
                e.Graphics.DrawString(sMessage, font10, Brushes.Black, new PointF(xCurrent, yCurrent));

                xCurrent = xLeft;
                yCurrent = yCurrent + (yIndent * 10);
                sMessage = string.Format("Ранее с Вами было подписано ДС № {0} от {1} на использование оборотной пластиковой тары на доставку Ваших заказов.", Agreement.Number_Agreement.Trim(), Agreement.Date_Agreement.Trim());
                sizeMessage = e.Graphics.MeasureString(sMessage, font10, maxMessageWidth);
                e.Graphics.DrawString(sMessage, font10, Brushes.Black, new RectangleF(new PointF(xCurrent, yCurrent), new SizeF(sizeMessage.Width, sizeMessage.Height)));

                xCurrent = xLeft;
                yCurrent = yCurrent + (yIndent * 5);
                sMessage = string.Format("Ваш заказ(ы) № {0} размещен(ы) в пластиковую тару.", Agreement.PSN_List.Trim());
                sizeMessage = e.Graphics.MeasureString(sMessage, font10, maxMessageWidth);
                e.Graphics.DrawString(sMessage, font10, Brushes.Black, new RectangleF(new PointF(xCurrent, yCurrent), new SizeF(sizeMessage.Width, sizeMessage.Height)));

                xCurrent = xLeft;
                yCurrent = yCurrent + (yIndent * 5);
                sMessage = string.Format("Убедительная просьба, при следующих поставках товара возвращать ранее полученную тару.");
                sizeMessage = e.Graphics.MeasureString(sMessage, font10, maxMessageWidth);
                e.Graphics.DrawString(sMessage, font10, Brushes.Black, new RectangleF(new PointF(xCurrent, yCurrent), new SizeF(sizeMessage.Width, sizeMessage.Height)));

                xCurrent = xLeft;
                yCurrent = yCurrent + (yIndent * 5);
                sMessage = string.Format("В случае возникновения вопросов, обращайтесь к закрепленному менеджеру.");
                sizeMessage = e.Graphics.MeasureString(sMessage, font10, maxMessageWidth);
                e.Graphics.DrawString(sMessage, font10, Brushes.Black, new RectangleF(new PointF(xCurrent, yCurrent), new SizeF(sizeMessage.Width, sizeMessage.Height)));

                xCurrent = xLeft;
                yCurrent = yCurrent + (yIndent * 10);
                sMessage = string.Format("Спасибо за сотрудничество.");
                sizeMessage = e.Graphics.MeasureString(sMessage, font10, maxMessageWidth);
                e.Graphics.DrawString(sMessage, font10, Brushes.Black, new RectangleF(new PointF(xCurrent, yCurrent), new SizeF(sizeMessage.Width, sizeMessage.Height)));
            }

            public void PrintLayout(PrintPageEventArgs e)
            {
                var xIndent = 20;

                var pen = new Pen(Brushes.Gray, 0.5f);
                pen.DashPattern = new float[] { 5, 5 };
                e.Graphics.DrawLine(pen, new Point(e.PageBounds.Width / 2 - xIndent, 0), new Point(e.PageBounds.Width / 2 - xIndent, e.PageBounds.Height));
            }

            public void PrintPageWatermark(PrintPageEventArgs e)
            {
                int xCurrent = 50; // подбор путем калибровки
                int yCurrent = 0; // подбор путем калибровки

                var angle = 30;

                var fontWatermark = new Font("Arial", 150.0f, FontStyle.Regular);
                var sWatermark = string.Format("ЧЕРНОВИК");
                var sizeWatermark = e.Graphics.MeasureString(sWatermark, fontWatermark);

                GraphicsState state = e.Graphics.Save();
                e.Graphics.ResetTransform();
                
                e.Graphics.RotateTransform(angle);
                e.Graphics.TranslateTransform(xCurrent, yCurrent, MatrixOrder.Append);

                e.Graphics.DrawString(sWatermark, fontWatermark, Brushes.LightGray, new RectangleF(new PointF(xCurrent, yCurrent), sizeWatermark));

                e.Graphics.Restore(state);
            }

            public void PrintCard(PrintPageEventArgs e, int cardNumber)
            {
                var xIndent = 15;
                var yIndent = 5;
                var xCellIndent = 3;
                var yCellIndent = 3;

                var cardWidth = (e.PageBounds.Width / 2);
                var maxContentWidth = cardWidth - (xIndent * 2);

                var wBarCode = (maxContentWidth / 3) * 2;
                var hBarCode = 30;

                var maxReceiverAddressWidth = maxContentWidth;

                var maxNumberWidth = 20;
                var maxTareBarCodeWidth = 0;//140;
                var maxCreditQtyWidth = 55;
                var maxShipQtyWidth = 55;
                var maxReturnQtyWidth = 55;
                var maxRemainsQtyWidth = 55;
                var maxPriceWidth = 64;

                maxContentWidth -= maxRemainsQtyWidth; // последний столбец не печатаем

                maxTareBarCodeWidth = maxContentWidth - (maxNumberWidth + maxPriceWidth + maxCreditQtyWidth * 5); // плавающая длинна
                // 1-я таблица: ΣW = 554

                var maxTareCreditBarCodesWidth = 0;
                maxTareCreditBarCodesWidth = maxContentWidth - (maxNumberWidth + maxTareBarCodeWidth); // плавающая длинна

                var maxGuiltyPersonWidth = 200;// 230;
                var maxTareDescriptionWidth = 0;
                var maxDescriptionWidth = 204;

                var sizeAddQty = (maxShipQtyWidth + maxRemainsQtyWidth) / 3;
                maxCreditQtyWidth += (sizeAddQty + 1);
                maxShipQtyWidth += sizeAddQty;
                maxReturnQtyWidth += sizeAddQty;

                maxTareDescriptionWidth = maxContentWidth - (maxNumberWidth + maxGuiltyPersonWidth + maxDescriptionWidth); // плавающая длинна
                // 2-я таблица: ΣW + maxNumberWidth = 554

                var fontReportHeader = new Font("Arial", 8.0f, FontStyle.Bold);
                var font8 = new Font("Arial", 8.0f);
                var fontTableCaption = new Font("Arial", 6.0f);
                var fontTableCaptionBold = new Font("Arial", 6.0f, FontStyle.Bold);

                int xLeft = (cardWidth * cardNumber) + xIndent;

                int xCurrent = xLeft;
                int yCurrent = yIndent;// 60 + yIndent;

                var sfCenter = new StringFormat();
                sfCenter.Alignment = StringAlignment.Center;

                var sfNear = new StringFormat();
                sfNear.Alignment = StringAlignment.Near;

                var sfFar = new StringFormat();
                sfFar.Alignment = StringAlignment.Far;

                var locTableTop = yCurrent;

                #region ЛОГО (OBSOLETE)

                //e.Graphics.DrawImage(Properties.Resources.logo, new RectangleF(xLeft, yCurrent, 100, 30));

                #endregion

                #region Ш/К ДОКУМЕНТА

                // создание изображения линейного штрих-кода
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    using (BarcodeLib.Barcode b = new BarcodeLib.Barcode())
                    {
                        b.Encode(
                            BarcodeLib.TYPE.CODE128B, Header.Doc_Bar_Code,
                            1600,
                            200).Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    }

                    var img = Image.FromStream(ms);
                    //e.Graphics.DrawImage(img, new RectangleF(xLeft + maxContentWidth - xIndent - wBarCode, yCurrent, wBarCode, hBarCode));
                    e.Graphics.DrawImage(img, new RectangleF(xLeft, yCurrent, wBarCode, hBarCode));
                }

                // создание изображения QR-кода
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    Zen.Barcode.CodeQrBarcodeDraw qrDrawTool = Zen.Barcode.BarcodeDrawFactory.CodeQr;
                    var qrImage = qrDrawTool.Draw(Header.Doc_Bar_Code, 100, 2);

                    var sizeQR = 91; // 70;
                    //e.Graphics.DrawImage(qrImage, new RectangleF(xLeft + maxContentWidth - xIndent - wBarCode + 0.95f*wBarCode, yCurrent + hBarCode + yIndent, sizeQR, sizeQR));
                    e.Graphics.DrawImage(qrImage, new RectangleF(xLeft + maxContentWidth - sizeQR, yCurrent, sizeQR, sizeQR)); 
                }

                #endregion

                #region ШАПКА ДОКУМЕНТА

                yCurrent = yCurrent + hBarCode + (yIndent * 5);

                var sDocNumberDescription = string.Format("Акт приймання-передачі тари: {0}", Header.Doc_Number_description);
                var sizeDocNumberDescription = e.Graphics.MeasureString(sDocNumberDescription, fontReportHeader);
                e.Graphics.DrawString(sDocNumberDescription, fontReportHeader, Brushes.Black, new RectangleF(new PointF(xCurrent, yCurrent), sizeDocNumberDescription));

                yCurrent = yCurrent + (int)sizeDocNumberDescription.Height + yIndent;
                var sSupplier = string.Format("Постачальник: СП \"Оптима-Фарм, ЛТД\"");
                var sizeSupplier = e.Graphics.MeasureString(sSupplier, fontReportHeader);
                e.Graphics.DrawString(sSupplier, fontReportHeader, Brushes.Black, new RectangleF(new PointF(xCurrent, yCurrent), sizeSupplier));

                yCurrent = yCurrent + (int)sizeSupplier.Height + yIndent;
                var sClient = string.Format("Покупець: {0}", Header.Client);
                var sizeClient = e.Graphics.MeasureString(sClient, font8);
                e.Graphics.DrawString(sClient, font8, Brushes.Black, new RectangleF(new PointF(xCurrent, yCurrent), sizeClient));

                yCurrent = yCurrent + (int)sizeClient.Height + yIndent;
                var sRouteNumber = string.Format("Маршрутний лист: {0}", Header.Route_Number);
                var sizeRouteNumber = e.Graphics.MeasureString(sRouteNumber, font8);
                e.Graphics.DrawString(sRouteNumber, font8, Brushes.Black, new RectangleF(new PointF(xCurrent, yCurrent), sizeRouteNumber));

                yCurrent = yCurrent + (int)sizeRouteNumber.Height + yIndent;
                var sReceiverAddressCaption = string.Format("Отримувач: ");
                var sizeReceiverAddressCaption = e.Graphics.MeasureString(sReceiverAddressCaption, fontReportHeader);
                e.Graphics.DrawString(sReceiverAddressCaption, fontReportHeader, Brushes.Black, new PointF(xCurrent, yCurrent));

                xCurrent = xCurrent + (int)sizeReceiverAddressCaption.Width;
                maxReceiverAddressWidth = maxReceiverAddressWidth - (int)sizeReceiverAddressCaption.Width;
                var sReceiverAddress = string.Format("{0}", Header.Receiver_Address);
                var sizeReceiverAddress = e.Graphics.MeasureString(sReceiverAddress, fontReportHeader, maxReceiverAddressWidth);
                e.Graphics.DrawString(sReceiverAddress, fontReportHeader, Brushes.Black, new RectangleF(new PointF(xCurrent, yCurrent), new SizeF(sizeReceiverAddress.Width, sizeReceiverAddress.Height)));

                xCurrent = xLeft;

                #endregion

                #region ТАБЛИЦА ФИКСАЦИИ ОТ

                // гор. линия - начало шапки
                yCurrent = yCurrent + (int)sizeRouteNumber.Height + (yIndent * 5);
                locTableTop = yCurrent;
                e.Graphics.DrawLine(Pens.Black, new PointF(xLeft, yCurrent), new Point(xLeft + maxContentWidth, yCurrent));

                var sNumber = string.Format("№");
                var sizeNumber = e.Graphics.MeasureString(sNumber, fontTableCaption, maxNumberWidth, sfCenter);
                e.Graphics.DrawString(sNumber, fontTableCaption, Brushes.Black, new RectangleF(new PointF(xCurrent, yCurrent), new SizeF(maxNumberWidth, sizeNumber.Height)), sfCenter);

                xCurrent = xCurrent + maxNumberWidth;
                var sTareBarCode = string.Format("Зворотна тара");
                var sizeTareBarCode = e.Graphics.MeasureString(sTareBarCode, fontTableCaption, maxTareBarCodeWidth, sfCenter);
                e.Graphics.DrawString(sTareBarCode, fontTableCaption, Brushes.Black, new RectangleF(new PointF(xCurrent, yCurrent), new SizeF(maxTareBarCodeWidth, sizeTareBarCode.Height)), sfCenter);

                xCurrent = xCurrent + maxTareBarCodeWidth;
                //var sCreditQty = string.Format("Заборго-\nваність");
                var sCreditQty = string.Format("Фактична заборгованість Покупця перед Постачальником, шт.");
                var sizeCreditQty = e.Graphics.MeasureString(sCreditQty, fontTableCaptionBold, maxCreditQtyWidth, sfCenter);
                e.Graphics.DrawString(sCreditQty, fontTableCaptionBold, Brushes.Black, new RectangleF(new PointF(xCurrent, yCurrent), new SizeF(maxCreditQtyWidth, sizeCreditQty.Height)), sfCenter);

                xCurrent = xCurrent + maxCreditQtyWidth;
                //var sShipQty = string.Format("Відван-\nтажено");
                var sShipQty = string.Format("Відвантажено Постачальником Покупцю за цим Актом, шт.");
                var sizeShipQty = e.Graphics.MeasureString(sShipQty, fontTableCaption, maxShipQtyWidth, sfCenter);
                e.Graphics.DrawString(sShipQty, fontTableCaption, Brushes.Black, new RectangleF(new PointF(xCurrent, yCurrent), new SizeF(maxShipQtyWidth, sizeShipQty.Height)), sfCenter);

                //xCurrent = xCurrent + maxShipQtyWidth;
                //var sReturnQty = string.Format("Повер-\nнення (план)");
                //var sizeReturnQty = e.Graphics.MeasureString(sReturnQty, fontTableCaption, maxReturnQtyWidth, sfCenter);
                //e.Graphics.DrawString(sReturnQty, fontTableCaption, Brushes.Black, new RectangleF(new PointF(xCurrent, yCurrent), new SizeF(maxReturnQtyWidth, sizeReturnQty.Height)), sfCenter);

                //xCurrent = xCurrent + maxReturnQtyWidth;
                //var sRemainsQty = string.Format("Залишок\n(план)");
                //var sizeRemainsQty = e.Graphics.MeasureString(sRemainsQty, fontTableCaption, maxRemainsQtyWidth, sfCenter);
                //e.Graphics.DrawString(sRemainsQty, fontTableCaption, Brushes.Black, new RectangleF(new PointF(xCurrent, yCurrent), new SizeF(maxRemainsQtyWidth, sizeRemainsQty.Height)), sfCenter);

                //xCurrent = xCurrent + maxRemainsQtyWidth;
                xCurrent = xCurrent + maxShipQtyWidth;
                var sPrice = string.Format("Ціна за шт.,\nгрн.");
                var sizePrice = e.Graphics.MeasureString(sPrice, fontTableCaption, maxPriceWidth, sfCenter);
                e.Graphics.DrawString(sPrice, fontTableCaption, Brushes.Black, new RectangleF(new PointF(xCurrent, yCurrent), new SizeF(maxPriceWidth, sizePrice.Height)), sfCenter);

                xCurrent = xCurrent + maxPriceWidth;
                //sReturnQty = string.Format("Повер-\nнення (факт)");
                var sReturnQty = string.Format("Повернуто\nвід Покупця Постачальнику за цим Актом, шт.");
                var sizeReturnQty = e.Graphics.MeasureString(sReturnQty, fontTableCaption, maxReturnQtyWidth, sfCenter);
                e.Graphics.DrawString(sReturnQty, fontTableCaption, Brushes.Black, new RectangleF(new PointF(xCurrent, yCurrent), new SizeF(maxReturnQtyWidth, sizeReturnQty.Height)), sfCenter);

                //xCurrent = xCurrent + maxReturnQtyWidth;
                //sRemainsQty = string.Format("Залишок\n(факт)");
                //sizeRemainsQty = e.Graphics.MeasureString(sRemainsQty, fontTableCaption, maxRemainsQtyWidth, sfCenter);
                //e.Graphics.DrawString(sRemainsQty, fontTableCaption, Brushes.Black, new RectangleF(new PointF(xCurrent, yCurrent), new SizeF(maxRemainsQtyWidth, sizeRemainsQty.Height)), sfCenter);

                // гор. линия - конец шапки
                xCurrent = xLeft;
                yCurrent = yCurrent + (int)sizeCreditQty.Height;
                e.Graphics.DrawLine(Pens.Black, new PointF(xLeft, yCurrent), new Point(xLeft + maxContentWidth, yCurrent));

                // ячейки
                var index = 0;
                foreach (Data.PickControl.CT_Tare_Invoice_DetailsRow row in reportData.CT_Tare_Invoice_Details)
                {
                    xCurrent = xLeft;

                    sNumber = string.Format("{0}", ++index);
                    sizeNumber = e.Graphics.MeasureString(sNumber, fontTableCaption, maxNumberWidth - xCellIndent, sfNear);
                    e.Graphics.DrawString(sNumber, fontTableCaption, Brushes.Black, new RectangleF(new PointF(xCurrent + xCellIndent, yCurrent + yCellIndent), new SizeF(maxNumberWidth - xCellIndent, sizeNumber.Height)), sfNear);

                    xCurrent = xCurrent + maxNumberWidth;
                    sTareBarCode = string.Format("{0}", row.Tare_Bar_code);
                    sizeTareBarCode = e.Graphics.MeasureString(sTareBarCode, fontTableCaption, maxTareBarCodeWidth - xCellIndent, sfNear);
                    e.Graphics.DrawString(sTareBarCode, fontTableCaption, Brushes.Black, new RectangleF(new PointF(xCurrent + xCellIndent, yCurrent + yCellIndent), new SizeF(maxTareBarCodeWidth - xCellIndent, sizeTareBarCode.Height)), sfNear);

                    xCurrent = xCurrent + maxTareBarCodeWidth;
                    sCreditQty = string.Format("{0:N0}", row.Credit_Qty);
                    sizeCreditQty = e.Graphics.MeasureString(sCreditQty, fontTableCaptionBold, maxCreditQtyWidth - xCellIndent, sfFar);
                    e.Graphics.DrawString(sCreditQty, fontTableCaptionBold, Brushes.Black, new RectangleF(new PointF(xCurrent, yCurrent + yCellIndent), new SizeF(maxCreditQtyWidth - xCellIndent, sizeCreditQty.Height)), sfFar);

                    xCurrent = xCurrent + maxCreditQtyWidth;
                    sShipQty = string.Format("{0:N0}", row.Ship_Qty);
                    sizeShipQty = e.Graphics.MeasureString(sShipQty, fontTableCaption, maxShipQtyWidth - xCellIndent, sfFar);
                    e.Graphics.DrawString(sShipQty, fontTableCaption, Brushes.Black, new RectangleF(new PointF(xCurrent, yCurrent + yCellIndent), new SizeF(maxShipQtyWidth - xCellIndent, sizeShipQty.Height)), sfFar);

                    //xCurrent = xCurrent + maxShipQtyWidth;
                    //sReturnQty = string.Format("{0:N0}", row.Return_Qty);
                    //sizeReturnQty = e.Graphics.MeasureString(sReturnQty, fontTableCaption, maxReturnQtyWidth - xCellIndent, sfFar);
                    //e.Graphics.DrawString(sReturnQty, fontTableCaption, Brushes.Black, new RectangleF(new PointF(xCurrent, yCurrent + yCellIndent), new SizeF(maxReturnQtyWidth - xCellIndent, sizeReturnQty.Height)), sfFar);

                    //xCurrent = xCurrent + maxReturnQtyWidth;
                    //sRemainsQty = string.Format("{0:N0}", row.Remains_Qty);
                    //sizeRemainsQty = e.Graphics.MeasureString(sRemainsQty, fontTableCaption, maxRemainsQtyWidth - xCellIndent, sfFar);
                    //e.Graphics.DrawString(sRemainsQty, fontTableCaption, Brushes.Black, new RectangleF(new PointF(xCurrent, yCurrent + yCellIndent), new SizeF(maxRemainsQtyWidth - xCellIndent, sizeRemainsQty.Height)), sfFar);

                    //xCurrent = xCurrent + maxRemainsQtyWidth;
                    xCurrent = xCurrent + maxShipQtyWidth;
                    sPrice = string.Format("{0:N2}", row.Price);
                    sizePrice = e.Graphics.MeasureString(sPrice, fontTableCaption, maxPriceWidth - xCellIndent, sfFar);
                    e.Graphics.DrawString(sPrice, fontTableCaption, Brushes.Black, new RectangleF(new PointF(xCurrent, yCurrent + yCellIndent), new SizeF(maxPriceWidth - xCellIndent, sizePrice.Height)), sfFar);

                    // гор. линии - низ ячейки
                    yCurrent = yCurrent + (int)sizeTareBarCode.Height + yCellIndent;
                    e.Graphics.DrawLine(Pens.Black, new PointF(xLeft, yCurrent), new Point(xLeft + maxContentWidth, yCurrent));
                }

                //верт.линии
                xCurrent = xLeft;
                e.Graphics.DrawLine(Pens.Black, new Point(xCurrent, locTableTop), new Point(xCurrent, yCurrent));

                xCurrent = xCurrent + maxNumberWidth;
                e.Graphics.DrawLine(Pens.Black, new Point(xCurrent, locTableTop), new Point(xCurrent, yCurrent));

                xCurrent = xCurrent + maxTareBarCodeWidth;
                e.Graphics.DrawLine(Pens.Black, new Point(xCurrent, locTableTop), new Point(xCurrent, yCurrent));

                xCurrent = xCurrent + maxCreditQtyWidth;
                e.Graphics.DrawLine(Pens.Black, new Point(xCurrent, locTableTop), new Point(xCurrent, yCurrent));

                xCurrent = xCurrent + maxShipQtyWidth;
                e.Graphics.DrawLine(Pens.Black, new Point(xCurrent, locTableTop), new Point(xCurrent, yCurrent));

                //xCurrent = xCurrent + maxReturnQtyWidth;
                //e.Graphics.DrawLine(Pens.Black, new Point(xCurrent, locTableTop), new Point(xCurrent, yCurrent));

                //xCurrent = xCurrent + maxRemainsQtyWidth;
                //e.Graphics.DrawLine(Pens.Black, new Point(xCurrent, locTableTop), new Point(xCurrent, yCurrent));

                xCurrent = xCurrent + maxPriceWidth;
                e.Graphics.DrawLine(Pens.Black, new Point(xCurrent, locTableTop), new Point(xCurrent, yCurrent));

                xCurrent = xCurrent + maxReturnQtyWidth;
                e.Graphics.DrawLine(Pens.Black, new Point(xCurrent, locTableTop), new Point(xCurrent, yCurrent));

                //xCurrent = xCurrent + maxRemainsQtyWidth;
                //e.Graphics.DrawLine(Pens.Black, new Point(xCurrent, locTableTop), new Point(xCurrent, yCurrent));

                #endregion

                #region ТАБЛИЦА ДЕТАЛИЗАЦИИ ЗАДОЛЖЕННОСТИ

                var qtyCreditTotal = Convert.ToInt32(reportData.CT_Tare_Invoice_Details.Compute(string.Format("SUM({0})", reportData.CT_Tare_Invoice_Details.Credit_QtyColumn.Caption), string.Empty));
                if (qtyCreditTotal > 0)
                {
                    xCurrent = xLeft;
                    yCurrent = yCurrent + (yIndent * 5);
                    var sComplaint = string.Format("Деталізація заборгованості");
                    var sizeComplaint = e.Graphics.MeasureString(sComplaint, font8);
                    e.Graphics.DrawString(sComplaint, font8, Brushes.Black, new RectangleF(new PointF(xCurrent, yCurrent), sizeComplaint));

                    // гор. линия - начало шапки
                    yCurrent = yCurrent + (int)sizeComplaint.Height + yIndent;
                    locTableTop = yCurrent;
                    e.Graphics.DrawLine(Pens.Black, new PointF(xLeft, yCurrent), new Point(xLeft + maxContentWidth, yCurrent));

                    sNumber = string.Format("№");
                    sizeNumber = e.Graphics.MeasureString(sNumber, fontTableCaption, maxNumberWidth, sfCenter);
                    e.Graphics.DrawString(sNumber, fontTableCaption, Brushes.Black, new RectangleF(new PointF(xCurrent, yCurrent), new SizeF(maxNumberWidth, sizeNumber.Height)), sfCenter);

                    xCurrent = xCurrent + maxNumberWidth;
                    sTareBarCode = string.Format("Зворотна тара");
                    sizeTareBarCode = e.Graphics.MeasureString(sTareBarCode, fontTableCaption, maxTareBarCodeWidth, sfCenter);
                    e.Graphics.DrawString(sTareBarCode, fontTableCaption, Brushes.Black, new RectangleF(new PointF(xCurrent, yCurrent), new SizeF(maxTareBarCodeWidth, sizeTareBarCode.Height)), sfCenter);

                    xCurrent = xCurrent + maxTareBarCodeWidth;
                    var sTareCreditBarCodes = string.Format("Перелік тари");
                    var sizeTareCreditBarCodes = e.Graphics.MeasureString(sTareCreditBarCodes, fontTableCaption, maxTareCreditBarCodesWidth, sfCenter);
                    e.Graphics.DrawString(sTareCreditBarCodes, fontTableCaption, Brushes.Black, new RectangleF(new PointF(xCurrent, yCurrent), new SizeF(maxTareCreditBarCodesWidth, sizeTareCreditBarCodes.Height)), sfCenter);

                    // гор. линия - конец шапки
                    xCurrent = xLeft;
                    yCurrent = yCurrent + 20; //(int)sizeCreditQty.Height;
                    e.Graphics.DrawLine(Pens.Black, new PointF(xLeft, yCurrent), new Point(xLeft + maxContentWidth, yCurrent));

                    // ячейки
                    index = 0;
                    foreach (Data.PickControl.CT_Tare_Invoice_DetailsRow row in reportData.CT_Tare_Invoice_Details)
                    {
                        xCurrent = xLeft;

                        sNumber = string.Format("{0}", ++index);
                        sizeNumber = e.Graphics.MeasureString(sNumber, fontTableCaption, maxNumberWidth - xCellIndent, sfNear);
                        e.Graphics.DrawString(sNumber, fontTableCaption, Brushes.Black, new RectangleF(new PointF(xCurrent + xCellIndent, yCurrent + yCellIndent), new SizeF(maxNumberWidth - xCellIndent, sizeNumber.Height)), sfNear);

                        xCurrent = xCurrent + maxNumberWidth;
                        sTareBarCode = string.Format("{0}", row.Tare_Bar_code);
                        sizeTareBarCode = e.Graphics.MeasureString(sTareBarCode, fontTableCaption, maxTareBarCodeWidth - xCellIndent, sfNear);
                        e.Graphics.DrawString(sTareBarCode, fontTableCaption, Brushes.Black, new RectangleF(new PointF(xCurrent + xCellIndent, yCurrent + yCellIndent), new SizeF(maxTareBarCodeWidth - xCellIndent, sizeTareBarCode.Height)), sfNear);

                        xCurrent = xCurrent + maxTareBarCodeWidth;
                        sTareCreditBarCodes = string.Format("{0}", row.Remains_Bar);
                        sizeTareCreditBarCodes = e.Graphics.MeasureString(sTareCreditBarCodes, fontTableCaption, maxTareCreditBarCodesWidth - xCellIndent, sfNear);
                        e.Graphics.DrawString(sTareCreditBarCodes, fontTableCaption, Brushes.Black, new RectangleF(new PointF(xCurrent, yCurrent + yCellIndent), new SizeF(maxTareCreditBarCodesWidth - xCellIndent, sizeTareCreditBarCodes.Height)), sfNear);

                        // гор. линии - низ ячейки
                        yCurrent = yCurrent + Math.Max((int)sizeTareBarCode.Height, (int)sizeTareCreditBarCodes.Height) + yCellIndent;
                        e.Graphics.DrawLine(Pens.Black, new PointF(xLeft, yCurrent), new Point(xLeft + maxContentWidth, yCurrent));
                    }

                    //верт.линии
                    xCurrent = xLeft;
                    e.Graphics.DrawLine(Pens.Black, new Point(xCurrent, locTableTop), new Point(xCurrent, yCurrent));

                    xCurrent = xCurrent + maxNumberWidth;
                    e.Graphics.DrawLine(Pens.Black, new Point(xCurrent, locTableTop), new Point(xCurrent, yCurrent));

                    xCurrent = xCurrent + maxTareBarCodeWidth;
                    e.Graphics.DrawLine(Pens.Black, new Point(xCurrent, locTableTop), new Point(xCurrent, yCurrent));

                    xCurrent = xCurrent + maxTareCreditBarCodesWidth;
                    e.Graphics.DrawLine(Pens.Black, new Point(xCurrent, locTableTop), new Point(xCurrent, yCurrent));
                }

                #endregion

                #region ТАБЛИЦА ФИКСАЦИИ ПОВРЕЖДЕНИЙ (ПУСТОГРАФКА)

                xCurrent = xLeft;
                yCurrent = yCurrent + (yIndent * 5);
                var sDamage = string.Format("Під час прийому передачі виявлено пошкодження:");
                var sizeDamage = e.Graphics.MeasureString(sDamage, font8);
                e.Graphics.DrawString(sDamage, font8, Brushes.Black, new RectangleF(new PointF(xCurrent, yCurrent), sizeDamage));

                // гор. линия - начало шапки
                yCurrent = yCurrent + (int)sizeDamage.Height + yIndent;
                locTableTop = yCurrent;
                e.Graphics.DrawLine(Pens.Black, new PointF(xLeft, yCurrent), new Point(xLeft + maxContentWidth, yCurrent));

                sNumber = string.Format("№");
                sizeNumber = e.Graphics.MeasureString(sNumber, fontTableCaption, maxNumberWidth, sfCenter);
                e.Graphics.DrawString(sNumber, fontTableCaption, Brushes.Black, new RectangleF(new PointF(xCurrent, yCurrent), new SizeF(maxNumberWidth, sizeNumber.Height)), sfCenter);

                xCurrent = xCurrent + maxNumberWidth;
                //var sGuiltyPerson = string.Format("Винуватець");
                var sGuiltyPerson = string.Format("Особа, яка виявила пошкодження\n(Покупець / Постачальник)");
                var sizeGuiltyPerson = e.Graphics.MeasureString(sGuiltyPerson, fontTableCaption, maxGuiltyPersonWidth, sfCenter);
                e.Graphics.DrawString(sGuiltyPerson, fontTableCaption, Brushes.Black, new RectangleF(new PointF(xCurrent, yCurrent), new SizeF(maxGuiltyPersonWidth, sizeGuiltyPerson.Height)), sfCenter);

                xCurrent = xCurrent + maxGuiltyPersonWidth;
              
                var sTareDescription = string.Format("Ш/К тари");
                var sizeTareDescription = e.Graphics.MeasureString(sTareDescription, fontTableCaption, maxTareDescriptionWidth, sfCenter);
                e.Graphics.DrawString(sTareDescription, fontTableCaption, Brushes.Black, new RectangleF(new PointF(xCurrent, yCurrent), new SizeF(maxTareDescriptionWidth, sizeTareDescription.Height)), sfCenter);

                xCurrent = xCurrent + maxTareDescriptionWidth;
                var sDescription = string.Format("Опис пошкодження");
                var sizeDescription = e.Graphics.MeasureString(sDescription, fontTableCaption, maxDescriptionWidth, sfCenter);
                e.Graphics.DrawString(sDescription, fontTableCaption, Brushes.Black, new RectangleF(new PointF(xCurrent, yCurrent), new SizeF(maxDescriptionWidth, sizeDescription.Height)), sfCenter);

                // гор. линия - конец шапки
                xCurrent = xLeft;
                //yCurrent = yCurrent + (int)sizeNumber.Height;
                yCurrent = yCurrent + (int)sizeGuiltyPerson.Height;
                e.Graphics.DrawLine(Pens.Black, new PointF(xLeft, yCurrent), new Point(xLeft + maxContentWidth, yCurrent));

                // гор. линии пустографки
                var hTableRow = 12;
                for (int i = 0; i < 1; i++)
                {
                    xCurrent = xCurrent + maxNumberWidth;
                    //var sSelectedGuiltyPerson = string.Format("{0}", "Одержувач / Постачальник");
                    var sSelectedGuiltyPerson = string.Empty;
                    var sizeSelectedGuiltyPerson = e.Graphics.MeasureString(sSelectedGuiltyPerson, fontTableCaption, maxTareBarCodeWidth - xCellIndent, sfNear);
                    e.Graphics.DrawString(sSelectedGuiltyPerson, fontTableCaption, Brushes.Black, new RectangleF(new PointF(xCurrent + xCellIndent, yCurrent + yCellIndent), new SizeF(maxTareBarCodeWidth - xCellIndent, sizeSelectedGuiltyPerson.Height)), sfNear);

                    yCurrent = yCurrent + hTableRow;
                    e.Graphics.DrawLine(Pens.Black, new PointF(xLeft, yCurrent), new Point(xLeft + maxContentWidth, yCurrent));
                }

                // верт. линии
                xCurrent = xLeft;
                e.Graphics.DrawLine(Pens.Black, new Point(xCurrent, locTableTop), new Point(xCurrent, yCurrent));

                xCurrent = xCurrent + maxNumberWidth;
                e.Graphics.DrawLine(Pens.Black, new Point(xCurrent, locTableTop), new Point(xCurrent, yCurrent));

                xCurrent = xCurrent + maxGuiltyPersonWidth;
                e.Graphics.DrawLine(Pens.Black, new Point(xCurrent, locTableTop), new Point(xCurrent, yCurrent));

                xCurrent = xCurrent + maxTareDescriptionWidth;
                e.Graphics.DrawLine(Pens.Black, new Point(xCurrent, locTableTop), new Point(xCurrent, yCurrent));

                xCurrent = xCurrent + maxDescriptionWidth;
                e.Graphics.DrawLine(Pens.Black, new Point(xCurrent, locTableTop), new Point(xCurrent, yCurrent));

                #endregion

                #region ПОДПИСЬ (FOOTER)

                xCurrent = xLeft;
                yCurrent = yCurrent + (yIndent * 5);

                var sSenderCaption = string.Format("Постачальник: _______________________");
                var sizeSender = e.Graphics.MeasureString(sSenderCaption, font8);
                e.Graphics.DrawString(sSenderCaption, font8, Brushes.Black, new RectangleF(new PointF(xCurrent, yCurrent), sizeSender));

                var sSender = string.Format("{0}", Header.Drivers);
                e.Graphics.DrawString(sSender, fontTableCaption, Brushes.Black, new PointF(xCurrent + 80, yCurrent));

                xCurrent = xCurrent + maxNumberWidth + maxGuiltyPersonWidth + maxTareDescriptionWidth;
                var sReceiver = string.Format("Покупець: _______________________");
                var sizeReceiver = e.Graphics.MeasureString(sReceiver, font8);
                e.Graphics.DrawString(sReceiver, font8, Brushes.Black, new RectangleF(new PointF(xCurrent, yCurrent), sizeReceiver));

                #endregion
            }


            private class PrinterBounds
            {
                [DllImport("gdi32.dll")]
                private static extern Int32 GetDeviceCaps(IntPtr hdc, Int32 capindex);

                private const int PHYSICALOFFSETX = 112;
                private const int PHYSICALOFFSETY = 113;

                public readonly Rectangle Bounds;
                public readonly int HardMarginLeft;
                public readonly int HardMarginTop;

                public PrinterBounds(PrintPageEventArgs e)
                {
                    IntPtr hDC = e.Graphics.GetHdc();

                    HardMarginLeft = GetDeviceCaps(hDC, PHYSICALOFFSETX);
                    HardMarginTop = GetDeviceCaps(hDC, PHYSICALOFFSETY);

                    e.Graphics.ReleaseHdc(hDC);

                    HardMarginLeft = (int)(HardMarginLeft * 100.0 / e.Graphics.DpiX);
                    HardMarginTop = (int)(HardMarginTop * 100.0 / e.Graphics.DpiY);

                    Bounds = e.MarginBounds;

                    Bounds.Offset(-HardMarginLeft, -HardMarginTop);
                }
            }
        }
    }
}
