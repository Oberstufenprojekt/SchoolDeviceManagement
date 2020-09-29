using System.ComponentModel.DataAnnotations;

namespace SchoolDeviceManagementWebApp.Models
{
    /// <summary>
    /// This class represents a brand of a laptop for example.
    /// </summary>
    public class Brand
    {
        /// <summary>
        /// Primary key of the brand.
        /// </summary>
        [Key]
        public int Id { get; set; }
        
        /// <summary>
        /// The name of the brand.
        /// </summary>
        [Required]
        public string BrandName { get; set; }

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public Brand()
        {
            
        }
    }
}