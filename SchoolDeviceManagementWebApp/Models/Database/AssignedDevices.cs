using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace SchoolDeviceManagementWebApp.Models.Database
{
    public partial class AssignedDevices
    {
        public string FkDevices { get; set; }
        public int StudentId { get; set; }
        public DateTime AssignedFrom { get; set; }
        public DateTime AssignedUntil { get; set; }
        public string Assignee { get; set; }
        public long Id { get; set; }

        public virtual IdentityUser AssigneeNavigation { get; set; }
        public virtual Devices FkDevicesNavigation { get; set; }
    }
}
