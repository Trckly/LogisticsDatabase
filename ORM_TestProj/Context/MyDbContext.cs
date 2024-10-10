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
    public virtual DbSet<Carrier> Carriers { get; set; }
    public virtual DbSet<Client> Clients { get; set; }
    public virtual DbSet<Driver> Drivers { get; set; }
    public virtual DbSet<DrivingLicense> DrivingLicenses { get; set; }
    public virtual DbSet<Logist> Logists { get; set; }
    public virtual DbSet<Order> Orders { get; set; }
    public virtual DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("config.json", optional: false, reloadOnChange: true)
            .Build();
            
        optionsBuilder.UseNpgsql(configuration.GetConnectionString("PostgreSQL"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
        });

        modelBuilder.Entity<Cargo>(entity =>
        {
        });

        modelBuilder.Entity<Carrier>(entity =>
        {
            entity.HasOne(d => d.LogistNavigation).WithMany(p => p.Carriers)
                .HasForeignKey(d => d.Logist)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasOne(d => d.LogistNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.Logist)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.Property(e => e.PhoneNumber).HasPrecision(10);

            entity.HasOne(d => d.DrivingLicenseNavigation).WithMany(p => p.Drivers)
                .HasForeignKey(d => d.DrivingLicense)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<DrivingLicense>(entity =>
        {
        });

        modelBuilder.Entity<Logist>(entity =>
        {
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.ValueAddedTax).HasDefaultValue(true);

            entity.HasOne(d => d.CargoNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Cargo)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.CarrierNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Carrier)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.ClientNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Client)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.DriverNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Driver)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.LoadingAddressNavigation).WithMany(p => p.OrderLoadingAddressNavigations)
                .HasForeignKey(d => d.LoadingAddress)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.LogistNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Logist)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.UnloadingAddressNavigation).WithMany(p => p.OrderUnloadingAddressNavigations)
                .HasForeignKey(d => d.UnloadingAddress)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.VehicleNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Vehicle)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Vehicle_pkey");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasDefaultValue(0)
                .HasColumnName("ID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
