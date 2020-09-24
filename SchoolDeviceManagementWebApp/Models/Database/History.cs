using System;
using System.Collections.Generic;

namespace SchoolDeviceManagementWebApp.Models.Database
{
    public partial class History
    {
        public long Id { get; set; }
        public string FkDevices { get; set; }
        public DateTime AssignedFrom { get; set; }
        public DateTime AssignedUntil { get; set; }
        public string Assignee { get; set; }

        public virtual AspNetUsers AssigneeNavigation { get; set; }
        public virtual Devices FkDevicesNavigation { get; set; }
    }
}
