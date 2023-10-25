using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace WMSOffice.Classes.VideoMonitoring
{
    public class ComplaintsOperationContext : IOperationContext
    {
        public ComplaintsOperationContext()
        {
            Items = new List<IItem>();
            Events = new List<Event>();
        }

        public ComplaintsOperationContext(object operationID)
            : this()
        {
            this.OperationID = operationID;
            this.OperationName = string.Format("{0}", this.OperationID == null ? "(не выбрано)" : this.OperationID.ToString());
        }

        #region IOperationContext Members

        public object OperationID { get; private set; }


        public string OperationName { get; private set; }


        public int UserID { get; set; }
        

        public string IP { get; set; }
       

        public int Port { get; set; }


        public List<IItem> Items { get; set; }

        public void LoadItems()
        {
            Items.Clear();        
        }

        public List<Event> Events { get; set; }

        public void LoadEvents()
        {
            Events.Clear();

            if (OperationID.Equals(-1))
                return;

            try
            {
                using (var connection = new SqlConnection(Properties.Settings.Default.JDE_PROCConnectionString))
                {
                    using (var adapter = new SqlDataAdapter(string.Format(@"SELECT * 
                                                              FROM [WMS].[dbo].[TV_Messages_log] (nolock) 
                                                              where operation_id = '{0}' 
                                                              order by id", OperationID), connection))
                    {
                        var data = new DataTable();
                        adapter.Fill(data);

                        foreach (DataRow dr in data.Rows)
                        {
                            try
                            {
                                DateTime date;
                                if (!DateTime.TryParse(dr["Event_Date"].ToString(), out date))
                                    throw new InvalidCastException("Ожидался тип данных DateTime");

                                var timeParts = dr["Event_Time"].ToString().Split(':');
                                if (timeParts.Length != 3)
                                    throw new InvalidCastException("Ожидалось время в формате (чч:мм:сс)");

                                int hour, minute, second;
                                if (!Int32.TryParse(timeParts[0], out hour) ||
                                    !Int32.TryParse(timeParts[1], out minute) ||
                                    !Int32.TryParse(timeParts[2], out second))
                                    throw new InvalidCastException("Ожидался тип данных Int32 для компонента времени");

                                // время возникновения события
                                var eventDateTime = new DateTime(date.Year, date.Month, date.Day, hour, minute, second);

                                Events.Add(new Event() { Time = eventDateTime, Name = dr["Event_Code"].ToString().Trim(), Description = dr["Name"].ToString().Trim() });
                            }
                            catch (Exception ex)
                            { 
                            
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        public static IOperationContext CreateEmptyContext()
        {
            return new ComplaintsOperationContext(null);
        }
    }

    public class ComplaintsOperationContextTextGenerator
    {
        public static List<IOperationContext> Generate()
        {
            var lstComplaints = new List<IOperationContext>();
            var complaintsID = new int[] 
            { 
                397939,
                398239,
                397988,
                397991,
                398472,
                398520,
                398525,
                398530,
                398533,
                398534,
                398541,
                398553,
                398555,
                398556,
                398642,
                398648,
                398659,
                398660,
                395712,
                395715,
                395718,
                395720,
                395722,
                395725,
                395729,
                395730,
                395732,
                395733,
                395735,
                395796,
                395799,
                395801,
                395816,
                398896,
                398905,
                398912,
                398918,
                398937,
                398938,
                398945,
                398948,
                398951,
                398953,
                399001,
                399005,
                399012,
                399042,
                399054,
                399057
            };

            foreach (var complaintID in complaintsID)
                lstComplaints.Add(new ComplaintsOperationContext(complaintID));

              //var distinct

            return lstComplaints;
        }
    }
}
