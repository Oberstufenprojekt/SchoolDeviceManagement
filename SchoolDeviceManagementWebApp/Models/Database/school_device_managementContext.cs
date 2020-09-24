using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SchoolDeviceManagementWebApp.Models.Database
{
    public partial class school_device_managementContext : DbContext
    {
        public school_device_managementContext()
        {
        }

        public school_device_managementContext(DbContextOptions<school_device_managementContext> options)
            : base(options)
        {
        }
        public virtual DbSet<AssignedDevices> AssignedDevices { get; set; }
        public virtual DbSet<Brands> Brands { get; set; }
        public virtual DbSet<DeviceHasFlaws> DeviceHasFlaws { get; set; }
        public virtual DbSet<Devices> Devices { get; set; }
        public virtual DbSet<Flaws> Flaws { get; set; }
        public virtual DbSet<History> History { get; set; }
        public virtual DbSet<Reservations> Reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("PostgresConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssignedDevices>(entity =>
            {
                entity.Property(e => e.Assignee).IsRequired();

                entity.Property(e => e.FkDevices).IsRequired();

                entity.HasOne(d => d.AssigneeNavigation)
                    .WithMany(p => p.AssignedDevices)
                    .HasForeignKey(d => d.Assignee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Assignee");

                entity.HasOne(d => d.FkDevicesNavigation)
                    .WithMany(p => p.AssignedDevices)
                    .HasForeignKey(d => d.FkDevices)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Device");
            });

            modelBuilder.Entity<Brands>(entity =>
            {
                entity.Property(e => e.Brand).IsRequired();
            });

            modelBuilder.Entity<DeviceHasFlaws>(entity =>
            {
                entity.Property(e => e.FkDevice).IsRequired();

                entity.Property(e => e.FkFlaws).ValueGeneratedOnAdd();

                entity.HasOne(d => d.FkDeviceNavigation)
                    .WithMany(p => p.DeviceHasFlaws)
                    .HasForeignKey(d => d.FkDevice)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Device");

                entity.HasOne(d => d.FkFlawsNavigation)
                    .WithMany(p => p.DeviceHasFlaws)
                    .HasForeignKey(d => d.FkFlaws)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Flaw");
            });

            modelBuilder.Entity<Devices>(entity =>
            {
                entity.HasKey(e => e.SerialNumber)
                    .HasName("Devices_pkey");

                entity.Property(e => e.FkBrand).ValueGeneratedOnAdd();

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.Type).IsRequired();

                entity.HasOne(d => d.FkBrandNavigation)
                    .WithMany(p => p.Devices)
                    .HasForeignKey(d => d.FkBrand)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FkBrand");
            });

            modelBuilder.Entity<Flaws>(entity =>
            {
                entity.Property(e => e.Flaw).IsRequired();
            });

            modelBuilder.Entity<History>(entity =>
            {
                entity.Property(e => e.Assignee).IsRequired();

                entity.Property(e => e.FkDevices).IsRequired();

                entity.HasOne(d => d.AssigneeNavigation)
                    .WithMany(p => p.History)
                    .HasForeignKey(d => d.Assignee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Assignee");

                entity.HasOne(d => d.FkDevicesNavigation)
                    .WithMany(p => p.History)
                    .HasForeignKey(d => d.FkDevices)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Device");
            });

            modelBuilder.Entity<Reservations>(entity =>
            {
                entity.Property(e => e.Creater).IsRequired();

                entity.Property(e => e.Person).IsRequired();

                entity.HasOne(d => d.CreaterNavigation)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.Creater)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Creator");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
