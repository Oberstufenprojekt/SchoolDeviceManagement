using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolDeviceManagementWebApp.Models
{
    /// <summary>
    /// Represents a device.
    /// </summary>
    public class Device
    {
        /// <summary>
        /// Serial number of the device that is also the primary key in the database.
        /// </summary>
        [Key]
        public string SerialNumber { get; set; }
        
        /// <summary>
        /// Type of the device. For example a laptop.
        /// </summary>
        [Required]
        public string Type { get; set; }
        
        /// <summary>
        /// The brand of the device.
        /// </summary>
        public virtual Brand Brand { get; set; }
        
        /// <summary>
        /// The foreign key of the brand.
        /// </summary>
        [ForeignKey("Brand")]
        [Required]
        public int BrandId { get; set; }
        
        /// <summary>
        /// The model of the device.
        /// </summary>
        [Required]
        public string Model { get; set; }

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public Device()
        {
            
        }
    }
}