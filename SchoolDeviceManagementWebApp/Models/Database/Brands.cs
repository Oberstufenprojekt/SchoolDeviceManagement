using System;
using System.Collections.Generic;

namespace SchoolDeviceManagementWebApp.Models.Database
{
    public partial class Brands
    {
        public Brands()
        {
            Devices = new HashSet<Devices>();
        }

        public long Id { get; set; }
        public string Brand { get; set; }

        public virtual ICollection<Devices> Devices { get; set; }
    }
}
