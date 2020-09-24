using System;
using System.Collections.Generic;

namespace SchoolDeviceManagementWebApp.Models.Database
{
    public partial class Flaws
    {
        public Flaws()
        {
            DeviceHasFlaws = new HashSet<DeviceHasFlaws>();
        }

        public long Id { get; set; }
        public string Flaw { get; set; }

        public virtual ICollection<DeviceHasFlaws> DeviceHasFlaws { get; set; }
    }
}
