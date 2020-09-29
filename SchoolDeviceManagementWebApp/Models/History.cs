using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace SchoolDeviceManagementWebApp.Models
{
    /// <summary>
    /// A history. All historic data is saved here.
    /// </summary>
    [Table("History")]
    public class History
    {
        /// <summary>
        /// Primary key.
        /// </summary>
        [Key]
        public int Id { get; set; }
        
        /// <summary>
        /// The device that was assigned.
        /// </summary>
        public Device Device { get; set; }
        
        /// <summary>
        /// Foreign key of the device.
        /// </summary>
        [ForeignKey("Device")]
        [Required]
        public string DeviceId { get; set; }
        
        /// <summary>
        /// The start date.
        /// </summary>
        [Required]
        public DateTime AssignedFrom { get; set; }
        
        /// <summary>
        /// The end date.
        /// </summary>
        [Required]
        public DateTime AssignedTo { get; set; }
        
        /// <summary>
        /// The user who assigned the device.
        /// </summary>
        public IdentityUser Assignee { get; set; }
        
        /// <summary>
        /// The foreign key of the assignee.
        /// </summary>
        [ForeignKey("Assignee")]
        [Required]
        public string AssigneeId { get; set; }

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public History()
        {
            
        }
    }
}