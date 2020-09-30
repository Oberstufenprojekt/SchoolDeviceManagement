using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolDeviceManagementWebApp.Models
{
    /// <summary>
    /// Represents a device that has a certain error.
    /// </summary>
    [Table("DevicesWithFlaws")]
    public class DeviceWithFlaws
    {
        /// <summary>
        /// Primary key.
        /// </summary>
        [Key]
        public int Id { get; set; }
        
        /// <summary>
        /// The device that has the flaw.
        /// </summary>
        public virtual Device Device { get; set; }
        
        /// <summary>
        /// The foreign key of the device.
        /// </summary>
        [ForeignKey("Device")]
        [Required]
        public string DeviceId { get; set; }
        
        /// <summary>
        /// The flaw itself.
        /// </summary>
        public Flaw Flaw { get; set;}
        
        /// <summary>
        /// The foreign key of the flaw.
        /// </summary>
        [ForeignKey("Flaw")]
        [Required]
        public int FlawId { get; set; }
        
        /// <summary>
        /// An explanation.
        /// </summary>
        public string Comment { get; set; }
        
        /// <summary>
        /// The time when the flaw was discovered.
        /// </summary>
        [Required]
        public DateTime Captured { get; set; }

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public DeviceWithFlaws()
        {
            
        }
    }
}