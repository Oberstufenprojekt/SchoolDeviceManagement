using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SchoolDeviceManagementWebApp.Data;
using SchoolDeviceManagementWebApp.Models;

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
        private ApplicationDbContext _dbContext;
        
        public IndexTables(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            GetAllDevices();
        }
        private void GetAllDevices()
        {
            AllDevices = _dbContext.Devices.Include(d => d.Brand).ToList<Device>();
        }
        
        #region Properties
        public List<string> TypeTables { get => _typeTables; private set => _typeTables = value; }
        public List<Device> AllDevices { get; private set; }
        #endregion
    }
}
//_dbContext.Devices.Include(d => d.Brand)