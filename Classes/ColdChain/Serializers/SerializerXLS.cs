using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace WMSOffice.Classes.ColdChain.Serializers
{
    public abstract class SerializerXLS : SerializerBase
    {
        public SerializerXLS()
        {
            Algorithm = 3;
        }
    }

    public class SerializerTermoTester : SerializerXLS
    {
        public SerializerTermoTester()
        {
            Algorithm = 3;
        }

        public override bool TryDeserialize(Buffer buffer)
        {
            try
            {
                var cntRows = buffer.Rows.Count;
                if (cntRows > 0)
                {
                    var cntCells = buffer.Rows[0].Cells.Count;
                    if (cntCells > 1)
                    {
                        // В 1-й строке файла должна находится шапка в нужных форматах
                        if (!buffer.Rows[0].Cells[0].Value.ToString().ToUpper().Contains("ДАТА, ВРЕМЯ"))
                            return false;
                        if (!buffer.Rows[0].Cells[1].Value.ToString().ToUpper().Contains("ТЕМПЕРАТУРА"))
                            return false;
                    }
                    else
                        return false;
                }
                else
                    return false;

                if (cntRows > 1)
                {
                    var cntCells = buffer.Rows[1].Cells.Count;
                    if (cntCells > 1)
                    {
                        // В 1-й колонке должны находится компоненты даты и времени
                        var sDateTime = buffer.Rows[1].Cells[0].Value.ToString();
                        DateTime dtParsed;
                        if (!DateTime.TryParse(sDateTime, out dtParsed))
                            return false;


                        // Во 2-й колонке должно находится числовое значение с плавающей запятой
                        var separator = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                        var sValue = string.Format("{0}", buffer.Rows[1].Cells[1].ToString().Replace(".", separator).Replace(",", separator));
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

                var sName = this.SensorSerialNumber;

                var separator = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;

                for (var i = 1; i < buffer.Rows.Count; i++)
                {
                    int id = i;

                    var sDateTime = buffer.Rows[i].Cells[0].Value.ToString();
                    DateTime dt;
                    if (!DateTime.TryParse(sDateTime, out dt))
                        throw new Exception("Для значения поля [Время показания] ожидалcя тип дата+время.");


                    var sCh1 = string.Format("{0}", buffer.Rows[i].Cells[1].ToString().Replace(".", separator).Replace(",", separator));
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

    public class SerializerTermoTesterUSB : SerializerXLS
    {
        public SerializerTermoTesterUSB()
        {
            Algorithm = 4;
        }

        public override bool TryDeserialize(Buffer buffer)
        {
            try
            {
                var cntRows = buffer.Rows.Count;
                if (cntRows > 0)
                {
                    var cntCells = buffer.Rows[0].Cells.Count;
                    if (cntCells > 4)
                    {
                        // В 1-й строке файла должна находится шапка в нужных форматах
                        if (!buffer.Rows[0].Cells[0].Value.ToString().ToUpper().Equals("НОМЕР"))
                            return false;
                        if (!buffer.Rows[0].Cells[1].Value.ToString().ToUpper().Equals("ДАТА"))
                            return false;
                        if (!buffer.Rows[0].Cells[2].Value.ToString().ToUpper().Equals("ВРЕМЯ"))
                            return false;
                        if (!buffer.Rows[0].Cells[3].Value.ToString().ToUpper().Equals("ТЕМПЕРАТУРА"))
                            return false;
                        if (!buffer.Rows[0].Cells[4].Value.ToString().ToUpper().Equals("НАРУШЕНИЕ"))
                            return false;
                    }
                    else
                        return false;
                }
                else
                    return false;

                if (cntRows > 1)
                {
                    var cntCells = buffer.Rows[1].Cells.Count;
                    if (cntCells > 3)
                    {
                        // В 1-й колонке должно находится целое число
                        var sInt = buffer.Rows[1].Cells[0].Value.ToString();
                        int iParsed;
                        if (!int.TryParse(sInt, out iParsed))
                            return false;

                        // Во 2-3-их колонках должны находится компоненты даты и времени
                        var sDateTime = string.Format("{0} {1}", buffer.Rows[1].Cells[1].Value, buffer.Rows[1].Cells[2].Value);
                        DateTime dtParsed;
                        if (!DateTime.TryParse(sDateTime, out dtParsed))
                            return false;


                        // В 3-й колонке должно находится числовое значение с плавающей запятой
                        var separator = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                        var sValue = string.Format("{0}", buffer.Rows[1].Cells[3].ToString().Replace(".", separator).Replace(",", separator));
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

                var sName = this.SensorSerialNumber;

                var separator = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;

                for (var i = 1; i < buffer.Rows.Count; i++)
                {
                    var sID = buffer.Rows[i].Cells[0].Value.ToString();
                    int id;
                    if (!int.TryParse(sID, out id))
                        throw new Exception("Для значения поля [Номер показания] ожидалось целое число.");

                    var sDateTime = string.Format("{0} {1}", buffer.Rows[i].Cells[1].Value, buffer.Rows[i].Cells[2].Value);
                    DateTime dt;
                    if (!DateTime.TryParse(sDateTime, out dt))
                        throw new Exception("Для значения поля [Время показания] ожидалcя тип дата+время.");


                    var sCh1 = string.Format("{0}", buffer.Rows[i].Cells[3].ToString().Replace(".", separator).Replace(",", separator));
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

    public class SerializerEliTech : SerializerXLS
    {
        private readonly int idxSerialNumberRow = 9; // индекс серийного номера
        private readonly int idxHeaderRow = 28; // индекс шапки
        private readonly int cntEmptyRows = 4; // кол-во пустіх строк перед шапкой

        public SerializerEliTech()
        {
            Algorithm = 5;
            idxHeaderRow -= cntEmptyRows;
        }

        public override bool TryDeserialize(Buffer buffer)
        {
            try
            {
                var cntRows = buffer.Rows.Count;
                if (cntRows > 0)
                {
                    // Поле "S/N" данных логгера содержится в первой строке файла
                    if (!buffer.Rows[idxSerialNumberRow].Cells[0].Value.ToString().ToUpper().Equals("SERIAL NUMBER"))
                        return false;

                    var cntCells = buffer.Rows[idxHeaderRow].Cells.Count;
                    if (cntCells > 2)
                    {
                        // В 29-й строке файла должна находится шапка в нужных форматах
                        if (!buffer.Rows[idxHeaderRow].Cells[0].Value.ToString().ToUpper().Equals("NO."))
                            return false;
                        if (!buffer.Rows[idxHeaderRow].Cells[1].Value.ToString().ToUpper().Equals("TIME"))
                            return false;
                        if (!buffer.Rows[idxHeaderRow].Cells[2].Value.ToString().ToUpper().Equals("TEMPERATURE°C"))
                            return false;
                    }
                    else
                        return false;
                }
                else
                    return false;

                if (cntRows > 1)
                {
                    var idxFirstDataRow = idxHeaderRow + 1;

                    var cntCells = buffer.Rows[idxFirstDataRow].Cells.Count;
                    if (cntCells > 2)
                    {
                        // В 1-й колонке должно находится целое число
                        var sInt = buffer.Rows[idxFirstDataRow].Cells[0].Value.ToString();
                        int iParsed;
                        if (!int.TryParse(sInt, out iParsed))
                            return false;

                        // Во 2-й колонке должны находится компоненты даты и времени
                        var sDateTime = buffer.Rows[idxFirstDataRow].Cells[1].Value.ToString();
                        DateTime dtParsed;
                        if (!DateTime.TryParse(sDateTime, out dtParsed))
                            return false;


                        // В 3-й колонке должно находится числовое значение с плавающей запятой
                        var separator = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                        var sValue = string.Format("{0}", buffer.Rows[idxFirstDataRow].Cells[2].ToString().Replace(".", separator).Replace(",", separator));
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

                var sName = buffer.Rows[idxSerialNumberRow].Cells[1].Value.ToString();
                if (!string.IsNullOrEmpty(this.SensorSerialNumber))
                {
                    if (!sName.ToUpper().Equals(this.SensorSerialNumber.ToUpper()))
                        throw new Exception("Серийный номер датчика температуры не совпадает с ожидаемым.");
                }

                var separator = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;

                var idxFirstDataRow = idxHeaderRow + 1;

                for (var i = idxFirstDataRow; i < buffer.Rows.Count; i++)
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
