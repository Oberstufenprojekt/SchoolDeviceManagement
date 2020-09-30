using System.ComponentModel.DataAnnotations;

namespace SchoolDeviceManagementWebApp.Models
{
    /// <summary>
    /// A flaw.
    /// </summary>
    public class Flaw
    {
        /// <summary>
        /// Primary key.
        /// </summary>
        [Key]
        public int Id { get; set; }
        
        /// <summary>
        /// A basic description.
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public Flaw()
        {
            
        }
    }
}