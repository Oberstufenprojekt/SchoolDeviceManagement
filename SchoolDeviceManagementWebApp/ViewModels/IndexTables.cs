using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using SchoolDeviceManagementWebApp.Data;
using SchoolDeviceManagementWebApp.Models;
//TODO: Kommentare 
namespace SchoolDeviceManagementWebApp.ViewModels
{
    public class IndexTables
    {
        private List<string> _typeTables = new List<string>()
        {
            "Alle Geräte",
            "Freie Geräte",
            "Vergebene Geräte"
        };
        
        private readonly ApplicationDbContext _dbContext;
        
        public IndexTables(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            GetAllDevices();
            GetFreeDevices(); 
            GetAssignedDevices();
        }
        private void GetAllDevices()
        {
            AllDevices = _dbContext.Devices.Include(d => d.Brand).ToList<Device>();
        }
        /// <summary>
        /// Select all entitys form <see cref="AssignedDevice"/> joining <see cref="Device"/>
        /// where the assignedfrom datetime is less than the system datetime
        /// or werhe the assignedUntill datetime is greater than the system datetime 
        /// </summary>
        private void GetFreeDevices()
        {
            var query = _dbContext.Devices.Join(
                _dbContext.AssignedDevices,
                device => device.SerialNumber,
                assignedDevice => assignedDevice.Device.SerialNumber,
                (device, assignedDevice) => new 
                {
                    serialNumber = device.SerialNumber,
                    type = device.Type,
                    brand = device.Brand.BrandName, 
                    model = device.Model,
                    assignedFrom = assignedDevice.AssignedFrom,
                    assignedUntil = assignedDevice.AssignedUntil
                })
                .Where(assignedDevice => assignedDevice.assignedFrom > System.DateTime.Now || assignedDevice.assignedUntil < System.DateTime.Now)
                .ToList();
            // TODO: Alle Geräte die nicht in AssignedDevice sind auch selektieren 
            
            FreeDevices = new List<FreeDevice>(); //---> Creating a list to store the data request. 
            foreach (var item in query)
            {
                FreeDevices.Add(new FreeDevice()
                {
                    SerialNumber = item.serialNumber,
                    Type = item.type,
                    Brand = item.brand,
                    Model = item.model,
                }) ;
            }
        }

        private void GetAssignedDevices()
        {
            var query = _dbContext.Devices.Join(
                _dbContext.AssignedDevices,
                device => device.SerialNumber,
                assignedDevice => assignedDevice.Device.SerialNumber,
                (device, assignedDevice) => new
                {
                    serialNumber = device.SerialNumber,
                    type = device.Type,
                    brand = device.Brand.BrandName,
                    model = device.Model,
                    assignedFrom = assignedDevice.AssignedFrom,
                    assignedUntil = assignedDevice.AssignedUntil
                })
                .Where(assignedDevice=>assignedDevice.assignedFrom <= System.DateTime.Now && assignedDevice.assignedUntil > System.DateTime.Now)
                .ToList();
            AssignedDevicesNow = new List<FreeDevice>();
            foreach (var item in query)
            {
                AssignedDevicesNow.Add(new FreeDevice()
                {
                    SerialNumber = item.serialNumber,
                    Brand = item.brand,
                    Model = item.model,
                    Type = item.type,
                    AssignedFrom = item.assignedFrom,
                    AssignedUntil = item.assignedFrom
                });
            }
            
        }

        #region Properties
        public List<string> TypeTables { get => _typeTables; private set => _typeTables = value; }
        public List<Device> AllDevices { get; private set; }
        public List<FreeDevice> FreeDevices { get; private set; }
        public List<FreeDevice> AssignedDevicesNow { get; private set; }
        #endregion
    }
}