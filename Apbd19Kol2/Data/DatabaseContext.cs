using Apbd19Kol2.Models;

namespace Apbd19Kol2.Data;
using Microsoft.EntityFrameworkCore;

public class DatabaseContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<PurchaseHistory> PurchaseHistories { get; set; }
    public DbSet<AvailableProgram> AvailablePrograms { get; set; }
    public DbSet<ProgramModel> Programs { get; set; }
    public DbSet<WashingMachine> WashingMachines { get; set; }
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasData(new List<Customer>()
        {
            new Customer() { CustomerId = 1, FirstName = "John", LastName = "Doe" , PhoneNumber = "123123456"},
            new Customer() { CustomerId = 2, FirstName = "Jane", LastName = "Doe" , PhoneNumber = "123456123"},
            new Customer() { CustomerId = 3, FirstName = "Julie", LastName = "Doe" , PhoneNumber = "456123123"},
        });
        
        modelBuilder.Entity<ProgramModel>().HasData(new List<ProgramModel>()
        {
            new ProgramModel() { ProgramId = 1, Name = "Program 1", DurationTime = 60, TemperatureCelsius = 50},
            new ProgramModel() { ProgramId = 2, Name = "Program 2", DurationTime = 60, TemperatureCelsius = 50},
            new ProgramModel() { ProgramId = 3, Name = "Program 3", DurationTime = 60, TemperatureCelsius = 50},
        });
        
        modelBuilder.Entity<WashingMachine>().HasData(new List<WashingMachine>()
        {
            new WashingMachine() { WashingMachineId = 1, MaxWeight = 3.45, SerialNumber = "632121"},
            new WashingMachine() { WashingMachineId = 2, MaxWeight = 5.55, SerialNumber = "632122"},
            new WashingMachine() { WashingMachineId = 3, MaxWeight = 12.37, SerialNumber = "632123"},
        });
        
        modelBuilder.Entity<PurchaseHistory>().HasData(new List<PurchaseHistory>()
        {
            new PurchaseHistory() { AvailableProgramId = 1, CustomerId = 1, PurchaseDate = DateTime.Parse("2025-05-01"), Rating = 10},
            new PurchaseHistory() { AvailableProgramId = 2, CustomerId = 2, PurchaseDate = DateTime.Parse("2025-05-02"), Rating = 10},
            new PurchaseHistory() { AvailableProgramId = 3, CustomerId = 3, PurchaseDate = DateTime.Parse("2025-05-03"), Rating = null},
        });
        
        modelBuilder.Entity<AvailableProgram>().HasData(new List<AvailableProgram>()
        {
            new AvailableProgram() { AvailableProgramId = 1, WashingMachineId = 1, ProgramId = 1, Price = 10.0},
            new AvailableProgram() { AvailableProgramId = 2, WashingMachineId = 1, ProgramId = 2, Price = 15.0},
            new AvailableProgram() { AvailableProgramId = 3, WashingMachineId = 1, ProgramId = 3, Price = 12.0},
        });
    }
}