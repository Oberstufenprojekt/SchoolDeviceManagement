using System;

namespace SchoolDeviceManagementWebApp.Models
{
    public class FreeDevice
    {
        public FreeDevice()
        {
            
        }
        public string SerialNumber;
        public string Type;
        public string Brand;
        public string Model;
        public DateTime AssignedFrom;
        public DateTime AssignedUntil; 
    }
}