using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace WMSOffice.Classes.VideoMonitoring
{
    public class Event
    {
        [DisplayName("Время создания события")]
        public DateTime Time { get; set; }

        [DisplayName("Наименование события")]
        public string Name { get; set; }

        [DisplayName("Описание события")]
        public string Description { get; set; }

        [DisplayName("Инициатор создания события")]
        public string OwnerName { get; set; }

        [DisplayName("№ сборочного")]
        public object OperationID { get; set; } 
    }
}
