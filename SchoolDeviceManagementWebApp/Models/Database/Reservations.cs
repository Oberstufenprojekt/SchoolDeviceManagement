using System;
using System.Collections.Generic;

namespace SchoolDeviceManagementWebApp.Models.Database
{
    public partial class Reservations
    {
        public long Id { get; set; }
        public int AmountOfDevices { get; set; }
        public DateTime From { get; set; }
        public DateTime Until { get; set; }
        public string Person { get; set; }
        public string Creater { get; set; }
        public DateTime Created { get; set; }

        public virtual AspNetUsers CreaterNavigation { get; set; }
    }
}
