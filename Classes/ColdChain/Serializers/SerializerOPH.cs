using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace WMSOffice.Classes.ColdChain.Serializers
{
    public class SerializerOPH : SerializerBase
    {
        public SerializerOPH()
        {
            Algorithm = 1;
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
                        // Поле "Name" данных логгера содержится в первой строке файла
                        if (!buffer.Rows[0].Cells[0].Value.ToString().ToUpper().Equals("NAME"))
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

                if (cntRows > 1)
                {
                    var cntCells = buffer.Rows[1].Cells.Count;
                    if (cntCells > 4)
                    {
                        // Во 2-й строке файла должна находится шапка в нужных форматах
                        if (!buffer.Rows[1].Cells[0].Value.ToString().ToUpper().Equals("ID"))
                            return false;
                        if (!buffer.Rows[1].Cells[1].Value.ToString().ToUpper().Equals("DATETIME"))
                            return false;
                        if (!buffer.Rows[1].Cells[2].Value.ToString().ToUpper().Equals("CH1"))
                            return false;
                        if (!buffer.Rows[1].Cells[3].Value.ToString().ToUpper().Equals("CH2"))
                            return false;
                        if (!buffer.Rows[1].Cells[4].Value.ToString().ToUpper().Equals("CH3"))
                            return false; 
                    }
                    else
                        return false;

                }
                else
                    return false;

                if (cntRows > 2)
                {
                    var cntCells = buffer.Rows[2].Cells.Count;
                    if (cntCells > 2)
                    {
                        // Во 1-й колонке должно находится целое число
                        var sInt = buffer.Rows[2].Cells[0].Value.ToString();
                        int iParsed;
                        if (!int.TryParse(sInt, out iParsed))
                            return false;

                        // Во 2-й колонке должно находится дата и время
                        var sDateTime = buffer.Rows[2].Cells[1].Value.ToString();
                        DateTime dtParsed;
                        if (!DateTime.TryParse(sDateTime, out dtParsed))
                            return false;

                        // В 3-й колонке должно находится числовое значение с плавающей запятой
                        var separator = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                        var sValue = string.Format("{0}", buffer.Rows[2].Cells[2].ToString().Replace(".", separator).Replace(",", separator));
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

                for (var i = 2; i < buffer.Rows.Count; i++)
                {
                    var sID = buffer.Rows[i].Cells[0].Value.ToString();
                    int id;
                    if (!int.TryParse(sID, out id))
                        throw new Exception("Для значения поля [Номер показания] ожидалось целое число.");

                    var sDateTime = buffer.Rows[i].Cells[1].Value.ToString();
                    DateTime dt;
                    if (!DateTime.TryParse(sDateTime, out dt))
                        throw new Exception("Для значения поля [Время показания] ожидалcя тип дата+время.");

                  
                    var sCh1 = string.Format("{0}", buffer.Rows[i].Cells[2].ToString().Replace(".", separator).Replace(",", separator));
                    double ch1;
                    if (!double.TryParse(sCh1, out ch1))
                        throw new Exception("Для значения поля [Температура] ожидалось число с плавающей запятой.");

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
