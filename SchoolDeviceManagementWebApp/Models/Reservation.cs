using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace SchoolDeviceManagementWebApp.Models
{
    /// <summary>
    /// Represents a reservation that can be a bulk reservation.
    /// </summary>
    public class Reservation
    {
        /// <summary>
        /// Primary key of the reservation.
        /// </summary>
        [Key]
        public int Id { get; set; }
        
        /// <summary>
        /// The amount of devices that should be assigned in the future.
        /// </summary>
        [Required]
        public int AmountOfDevices { get; set; }
        
        /// <summary>
        /// Start date.
        /// </summary>
        [Required]
        public DateTime From { get; set; }
        
        /// <summary>
        /// End date.
        /// </summary>
        [Required]
        public DateTime To { get; set; }
        
        /// <summary>
        /// The person who receives the device/s.
        /// </summary>
        [Required]
        public string Person { get; set; }

        /// <summary>
        /// The user who created the reservation.
        /// </summary>
        public IdentityUser Creator { get; set; }
        
        /// <summary>
        /// The foreign key of the creator.
        /// </summary>
        [ForeignKey("Creator")]
        [Required]
        public string CreatorId { get; set; }
        
        /// <summary>
        /// The time when the reservation was created.
        /// </summary>
        public DateTime Created { get; set; }

        public Reservation()
        {
            Created = DateTime.Now;
        }
    }
}