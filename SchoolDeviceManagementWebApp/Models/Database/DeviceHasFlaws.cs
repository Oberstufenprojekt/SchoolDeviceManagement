using System;
using System.Collections.Generic;

namespace SchoolDeviceManagementWebApp.Models.Database
{
    public partial class DeviceHasFlaws
    {
        public long Id { get; set; }
        public string FkDevice { get; set; }
        public long FkFlaws { get; set; }
        public string Comment { get; set; }
        public DateTime Captured { get; set; }

        public virtual Devices FkDeviceNavigation { get; set; }
        public virtual Flaws FkFlawsNavigation { get; set; }
    }
}
