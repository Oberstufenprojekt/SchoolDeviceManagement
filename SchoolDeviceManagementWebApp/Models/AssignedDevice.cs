using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace SchoolDeviceManagementWebApp.Models
{
    /// <summary>
    /// Class for all assigned devices.
    /// </summary>
    public class AssignedDevice
    {
        /// <summary>
        /// Primary key of the table.
        /// </summary>
        [Key]
        public int Id { get; set; }
        
        /// <summary>
        /// The devices that is assigned.
        /// </summary>
        [Required]
        public Device Device { get; set; }
        
        /// <summary>
        /// Foreign key of the device.
        /// </summary>
        [ForeignKey("Device")]
        public string DeviceId { get; set; }
        
        /// <summary>
        /// The ID of the student who has the device.
        /// </summary>
        [Required]
        public int StudentId { get; set; }
        
        /// <summary>
        /// The start time.
        /// </summary>
        [Required]
        public DateTime AssignedFrom { get; set; }

        /// <summary>
        /// The end time.
        /// </summary>
        [Required]
        public DateTime AssignedUntil { get; set; }
        
        /// <summary>
        /// The user who assigned this device to the student.
        /// </summary>
        public IdentityUser Assignee { get; set; }
        
        /// <summary>
        /// The foreign key for the assignee.
        /// </summary>
        [ForeignKey("Assignee")]
        [Required]
        public string AssigneeId { get; set; }

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public AssignedDevice()
        {
            
        }
    }
}