using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace WMSOffice.Classes.ColdChain.Serializers
{
    public abstract class SerializerCSV : SerializerBase
    {
        public SerializerCSV()
        {
            Algorithm = 2;
        }
    }

    public class SerializerMicroLite : SerializerCSV
    {
        public SerializerMicroLite()
        {
            Algorithm = 2;
        }

        public override bool TryDeserialize(Buffer buffer)
        {
            try
            {
                var cntRows = buffer.Rows.Count;
                if (cntRows > 0)
                {
                    var cntCells = buffer.Rows[0].Cells.Count;
                    if (cntCells > 0)
                    {
                        // Поле "S/N" данных логгера содержится в первой строке файла
                        if (!buffer.Rows[0].Cells[0].Value.ToString().Contains("S/N"))
                            return false;
                    }
                    else
                        return false;

                    if (cntCells > 1)
                    { }
                    else
                        return false;
                }
                else
                    return false;

                if (cntRows > 3)
                {
                    var cntCells = buffer.Rows[3].Cells.Count;
                    if (cntCells > 2)
                    {
                        // В 1-х 2 колонках должны находится компоненты даты и времени
                        var sDateTime = string.Format("{0} {1}", buffer.Rows[3].Cells[0].Value, buffer.Rows[3].Cells[1].Value);
                        DateTime dtParsed;
                        if (!DateTime.TryParse(sDateTime, out dtParsed))
                            return false;

                        // В 3-й колонке должно находится числовое значение
                        var separator = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                        var sValue = string.Format("{0}", buffer.Rows[3].Cells[2].ToString().Replace(".", separator).Replace(",", separator));
                        double dParsed;
                        if (!double.TryParse(sValue, out dParsed))
                            return false;
                    }
                    else
                        return false;
                }
                else
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public override bool Deserialize(Buffer buffer)
        {
            try
            {
                this.Initialize();

                var sName = buffer.Rows[0].Cells[1].Value.ToString();
                if (!string.IsNullOrEmpty(this.SensorSerialNumber))
                {
                    if (!sName.ToUpper().Equals(this.SensorSerialNumber.ToUpper()))
                        throw new Exception("Серийный номер датчика температуры не совпадает с ожидаемым.");
                }

                var separator = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;

                for (var i = 3; i < buffer.Rows.Count; i++)
                {
                    int id = i;

                    var sDateTime = string.Format("{0} {1}", buffer.Rows[i].Cells[0].Value, buffer.Rows[i].Cells[1].Value);
                    DateTime dt;
                    if (!DateTime.TryParse(sDateTime, out dt))
                        throw new Exception("Для значения поля [Время показания] ожидалcя тип дата+время.");


                    var sCh1 = string.Format("{0}", buffer.Rows[i].Cells[2].ToString().Replace(".", separator).Replace(",", separator));
                    double ch1;
                    if (!double.TryParse(sCh1, out ch1))
                        throw new Exception("Для значения поля [Температура]ожидалось число с плавающей запятой.");

                    var row = Data.NewLoggerDataTransferRow();

                    row.Session_ID = this.SessionID;
                    row.Name = sName;
                    row.ID = id; 
                    row.DateTime = dt;
                    row.Ch1 = ch1;
                    row.Algorithm = this.Algorithm;

                    Data.AddLoggerDataTransferRow(row);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
