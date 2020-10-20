using System;

namespace SchoolDeviceManagementWebApp.Models.Exceptions
{
    /// <summary>
    /// An exception that is thrown if a device could not be validated.
    /// </summary>
    public class DeviceCouldNotBeValidatedException : Exception
    {
        /// <summary>
        /// Basic constructor with message.
        /// </summary>
        public DeviceCouldNotBeValidatedException() 
            : base("Error while validating the device.")
        {
            
        }
    }
}