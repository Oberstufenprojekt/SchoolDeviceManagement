using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SchoolDeviceManagementWebApp.Data;
using SchoolDeviceManagementWebApp.Models;
using SchoolDeviceManagementWebApp.Models.Exceptions;

namespace SchoolDeviceManagementWebApp.Services
{
    /// <summary>
    /// Service to add a new device to the database.
    /// </summary>
    public class AddDeviceService
    {
        /// <summary>
        /// The ApplicationDbContext to insert the device.
        /// </summary>
        private readonly ApplicationDbContext _dbContext;
        
        /// <summary>
        /// Creates an AddDeviceService object.
        /// </summary>
        /// <param name="dbContext">The ApplicationDbContext to insert the device.</param>
        public AddDeviceService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Adds a non existing device to the database.
        /// </summary>
        /// <param name="deviceToAdd">The device to add.</param>
        public void Add(Device deviceToAdd)
        {
           if (!Validated(deviceToAdd)) throw new DeviceCouldNotBeValidatedException();
            
            _dbContext.Add(deviceToAdd);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Validates the device if it can be inserted into the database. A primary key violation or not null values
        /// that are null can cause problems.
        /// </summary>
        /// <param name="deviceToValidate">The device that should be validated.</param>
        /// <returns>True if the device can be inserted into the database.</returns>
        private bool Validated(Device deviceToValidate)
        {
            // TODO: Test this implementation. 
            
            // TODO: Check if device is non existent.
            var context = new ValidationContext(deviceToValidate);
            var validationResults = new List<ValidationResult>();
            
            return Validator.TryValidateObject(deviceToValidate, context, validationResults, true);
        }
    }
}