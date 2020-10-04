using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using SchoolDeviceManagementWebApp.Data;
using SchoolDeviceManagementWebApp.Models;
using SchoolDeviceManagementWebApp.ViewModels;

namespace SchoolDeviceManagementWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// The db context that is used to communicate with the database.
        /// </summary>
        private readonly ApplicationDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        { 
            return View(new IndexTables(_dbContext)); 
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult DeviceOverview()
        {
            // A list with all devices in the database. No matter if they're in use, broken or available.
            var allDevicesList = _dbContext.Devices.Include(d => d.Brand).ToList();
            
            return View(allDevicesList);
        }

        public IActionResult FreeDevices()
        {
            return View();
        }

        public IActionResult AssignedDevices()
        {
            // A list with all assigned devices and their assignees.
            var assignedDevicesList = _dbContext.AssignedDevices
                .Include(d => d.Device)
                .Include(d => d.Device.Brand)
                .Include(d => d.Assignee).ToList();
            
            return View(assignedDevicesList);
        }

        public IActionResult FlawDevices()
        {
            return View();
        }

        public IActionResult Help()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
