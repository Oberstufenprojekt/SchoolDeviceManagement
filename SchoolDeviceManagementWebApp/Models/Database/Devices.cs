using System;
using System.Collections.Generic;

namespace SchoolDeviceManagementWebApp.Models.Database
{
    public partial class Devices
    {
        public Devices()
        {
            AssignedDevices = new HashSet<AssignedDevices>();
            DeviceHasFlaws = new HashSet<DeviceHasFlaws>();
            History = new HashSet<History>();
        }

        public string SerialNumber { get; set; }
        public string Type { get; set; }
        public long FkBrand { get; set; }
        public string Model { get; set; }

        public virtual Brands FkBrandNavigation { get; set; }
        public virtual ICollection<AssignedDevices> AssignedDevices { get; set; }
        public virtual ICollection<DeviceHasFlaws> DeviceHasFlaws { get; set; }
        public virtual ICollection<History> History { get; set; }
    }
}
