using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolDeviceManagementWebApp.Models;

namespace SchoolDeviceManagementWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult DeviceOverview()
        {
            return View();
        }

        public IActionResult FreeDevices()
        {
            return View();
        }

        public IActionResult AssignedDevices()
        {
            return View();
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
