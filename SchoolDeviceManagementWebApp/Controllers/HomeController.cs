using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using QRCoder;
using SchoolDeviceManagementWebApp.Data;
using SchoolDeviceManagementWebApp.Models;

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
            return View();
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
        
        /// <summary>
        /// This method is called when someone clicks on an edit button in a table. It gets the device by its serial
        /// number out of the database and sends it to the AddDevice view where it can be edited. 
        /// </summary>
        /// <param name="id">The serial number of the device.</param>
        /// <returns>The AddDevice View.</returns>
        public IActionResult AddDevice(string id)
        {
            // Check if id is not null or empty.
            if (id == null || id.Equals(""))
            {
                _logger.LogDebug("No serial number given. Returning empty view.");
                return View();
            }
            
            try
            {
                var deviceToEdit = _dbContext.Devices
                    .Include(d => d.Brand)
                    .First(d => d.SerialNumber.Equals(id));
                
                _logger.LogInformation("Device with serial number {0} loaded from database", 
                    deviceToEdit.SerialNumber);
                
                return View(deviceToEdit);
            }
            catch (InvalidOperationException)
            {
                _logger.LogError("No device with serial number: {0} found in database. Returning empty view", id);

                return View();
            }
        }
        
        public IActionResult GenerateQRCode()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult GenerateQRCode(string txtQRCode)
        {
            QRCodeGenerator _qrCode = new QRCodeGenerator();
            QRCodeData _qrCodeData = _qrCode.CreateQrCode(txtQRCode, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(_qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            byte[] qrBytes = BitmapToBytesCode(qrCodeImage);
            System.IO.Directory.CreateDirectory(@".\QRCodes");
            System.IO.File.WriteAllBytes(@".\QRCodes\Index.png", qrBytes);

            return View(qrBytes);

        }
        [NonAction]
        private static Byte[] BitmapToBytesCode(Bitmap image)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
