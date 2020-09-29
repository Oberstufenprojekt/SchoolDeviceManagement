using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolDeviceManagementWebApp.Models;

namespace SchoolDeviceManagementWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<AssignedDevice> AssignedDevices { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<DeviceWithFlaws> DevicesWithFlaws { get; set; }
        public DbSet<Flaw> Flaws { get; set; }
        public DbSet<History> History { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
