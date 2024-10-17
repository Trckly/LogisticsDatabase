using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ORM_TestProj.Entities;

namespace ORM_TestProj.Context;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }
    public virtual DbSet<Cargo> Cargos { get; set; }
    public virtual DbSet<Driver> Drivers { get; set; }
    public virtual DbSet<DrivingLicense> DrivingLicenses { get; set; }
    public virtual DbSet<Logist> Logists { get; set; }
    public virtual DbSet<Order> Orders { get; set; }
    public virtual DbSet<Vehicle> Vehicles { get; set; }
    public virtual DbSet<OrderAddress> OrderAddresses { get; set; }
    public virtual DbSet<CargoOrder> CargoOrders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("/Users/trckly/Documents/Databases/LogisticsDatabase/ORM_TestProj/config.json", optional: false, reloadOnChange: true)
            .Build();
            
        optionsBuilder.UseNpgsql(configuration.GetConnectionString("PostgreSQL"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.Property(e => e.CompanyName).HasMaxLength(50);
            entity.Property(e => e.Province).HasMaxLength(50);
            entity.Property(e => e.Settlement).HasMaxLength(50);
            entity.Property(e => e.Street).HasMaxLength(50);
            entity.Property(e => e.StreetNumber).HasMaxLength(10);
        });

        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.Property(e => e.Denomination).HasMaxLength(50);
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Surname).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.DrivingLicenseId).HasMaxLength(10);
            
            entity.HasOne(e => e.DrivingLicenseNavigation)
                .WithOne(l => l.DriverNavigation)
                .HasForeignKey<Driver>(d => d.DrivingLicenseId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<DrivingLicense>(entity =>
        {
            entity.HasKey(e => e.DrivingLicenceId);
            
            entity.Property(e => e.DrivingLicenceId).HasMaxLength(10);
            entity.Property(e => e.LicenseIssuer).HasMaxLength(50);

            entity.HasOne(e => e.DriverNavigation)
                .WithOne(l => l.DrivingLicenseNavigation)
                .HasForeignKey<Driver>(d => d.DrivingLicenseId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Logist>(entity =>
        {
            entity.HasIndex(e => new { e.FirstName, e.LastName, e.Surname })
                .IsUnique();
            
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Surname).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.Email).HasMaxLength(50);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.ClientCompanyName).HasMaxLength(50);
            entity.Property(e => e.CarrierCompanyName).HasMaxLength(50);
            entity.Property(e => e.Active).HasDefaultValue(true);

            entity.HasOne(e => e.LogistNavigation)
                .WithMany(l => l.OrdersNavigation)
                .HasForeignKey(e => e.LogistId)
                .OnDelete(DeleteBehavior.Cascade);
            
            entity.HasOne(e => e.VehicleNavigation)
                .WithMany(v => v.OrdersNavigation)
                .HasForeignKey(e => e.VehicleId)
                .OnDelete(DeleteBehavior.Cascade);
            
            entity.HasOne(e => e.DriverNavigation)
                .WithMany(d => d.OrdersNavigation)
                .HasForeignKey(e => e.DriverId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.Property(e => e.LicensePlate).HasMaxLength(8).IsFixedLength();
            entity.Property(e => e.Model).HasMaxLength(20);
        });

        modelBuilder.Entity<OrderAddress>(entity =>
        {
            entity.Property(e => e.IsInitialAddress)
                .IsRequired();
            
            entity.HasOne(e => e.OrderNavigation)
                .WithMany(o => o.OrderAddressesNavigation)
                .HasForeignKey(e => e.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.AddressNavigation)
                .WithMany(a => a.OrderAddressesNavigation)
                .HasForeignKey(e => e.AddressId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<CargoOrder>(entity =>
        {
            entity.HasOne(e => e.OrderNavigation)
                .WithMany(o => o.CargoOrderNavigation)
                .HasForeignKey(e => e.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.CargoNavigation)
                .WithMany(c => c.CargoOrdersNavigation)
                .HasForeignKey(e => e.CargoId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
