using APBD_Przygotowanie_Kolos2A.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_Przygotowanie_Kolos2A.Data;

public class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
        
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<Customer> Customers { get; set; }
    public DbSet<AvailableProgram> AvailablePrograms { get; set; }
    public DbSet<WashingProgram> Programs { get; set; }
    public DbSet<PurchaseHistory> PurchaseHistories { get; set; }
    public DbSet<WashingMachine> WashingMachines { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(c =>
            {
                c.HasKey(e => e.CustomerId);
                c.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                c.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                c.Property(e => e.PhoneNumber).HasMaxLength(100);
            }
        );

        modelBuilder.Entity<AvailableProgram>(ap =>
            {
                ap.HasKey(e => e.AvailableProgramId);
                ap.HasOne(e => e.WashingMachine)
                    .WithMany()
                    .HasForeignKey(e => e.WashingMachineId);
                ap.HasOne(e => e.WashingProgram)
                    .WithMany()
                    .HasForeignKey(e => e.ProgramId);
                ap.Property(e => e.Price).HasColumnType("decimal(10,2)").IsRequired();
            }
        );
        
        modelBuilder.Entity<PurchaseHistory>(ph =>
            {
                ph.HasKey(e => new {e.AvailableProgramId, e.CustomerId});
                ph.HasOne(e => e.AvailableProgram)
                    .WithMany()
                    .HasForeignKey(e => e.AvailableProgramId);
                ph.HasOne(e => e.Customer)
                    .WithMany()
                    .HasForeignKey(e => e.CustomerId);
                ph.Property(e => e.PurchaseDate).IsRequired();
                ph.Property(e => e.Rating);
            }
        );
        modelBuilder.Entity<WashingMachine>(wm =>
            {
                wm.HasKey(e => e.WashingMachineId);
                wm.Property(e => e.MaxWeight).IsRequired();
                wm.Property(e => e.SerialNumber).IsRequired().HasMaxLength(100);
            }
        );
        modelBuilder.Entity<WashingProgram>(wp =>
            {
                wp.HasKey(e => e.ProgramId);
                wp.Property(e => e.Name).IsRequired().HasMaxLength(50);
                wp.Property(e => e.DurationMinutes).IsRequired();
                wp.Property(e => e.TemperatureCelsius).IsRequired();
            }
        );
        
        modelBuilder.Entity<Customer>().HasData(
            new Customer()
            {
                CustomerId = 1,
                FirstName = "John",
                LastName = "Doe",
                PhoneNumber = "123456789"
            },
            new Customer()
            {
                CustomerId = 2,
                FirstName = "Jane",
                LastName = "Doe",
                PhoneNumber = "123456789"
            }
        );

        modelBuilder.Entity<WashingMachine>().HasData(
            new WashingMachine()
            {
                WashingMachineId = 1,
                MaxWeight = 32.23m,
                SerialNumber = "WM2014/S491/28"
            },
            new WashingMachine()
            {
                WashingMachineId = 2,
                MaxWeight = 52.23m,
                SerialNumber = "WM2025/51431/13"
            }
        );
        modelBuilder.Entity<WashingProgram>().HasData(
            new WashingProgram()
            {
                ProgramId = 1,
                Name = "Eco Wash",
                DurationMinutes = 120,
                TemperatureCelsius = 50
            },
            new WashingProgram()
            {
                ProgramId = 2,
                Name = "Quick Mash",
                DurationMinutes = 30,
                TemperatureCelsius = 69
            }
        );
        modelBuilder.Entity<AvailableProgram>().HasData(
            new AvailableProgram()
            {
                AvailableProgramId = 1,
                WashingMachineId = 1,
                ProgramId = 1,
                Price = 26m
            },
            new AvailableProgram()
            {
                AvailableProgramId = 2,
                WashingMachineId = 2,
                ProgramId = 2,
                Price = 15.5m
            }
        );
        modelBuilder.Entity<PurchaseHistory>().HasData(
            new PurchaseHistory()
            {
                AvailableProgramId = 1,
                CustomerId = 1,
                PurchaseDate = DateTime.Now,
                Rating = 3
            },
            new PurchaseHistory()
            {
                AvailableProgramId = 2,
                CustomerId = 2,
                PurchaseDate = new DateTime(2015, 3, 12),
                Rating = 4
            }
        );
    }
}