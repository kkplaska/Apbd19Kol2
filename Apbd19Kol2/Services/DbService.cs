using Apbd19Kol2.Data;
using Apbd19Kol2.DTOs;
using Apbd19Kol2.Exceptions;
using Apbd19Kol2.Models;
using Microsoft.EntityFrameworkCore;

namespace Apbd19Kol2.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<CustomerPurchaseDto> GetPurchasesByCustomerId(int customerId)
    {
        var customerPurchases = await _context.Customers.Where(x => x.CustomerId == customerId).Select(e =>
            new CustomerPurchaseDto
            {
                FirstName = e.FirstName,
                LastName = e.LastName,
                PhoneNumber = e.PhoneNumber,
                Purchases = e.PurchaseHistories.Select(e => new PurchaseDto
                {
                    Date = e.PurchaseDate,
                    Rating = e.Rating,
                    Price = e.AvailableProgram.Price,
                    WashingMachine = new WashingMachineDto()
                    {
                        Serial = e.AvailableProgram.WashingMachine.SerialNumber,
                        MaxWeight = e.AvailableProgram.WashingMachine.MaxWeight
                    },
                    ProgramDto = new ProgramDto()
                    {
                        Name = e.AvailableProgram.Program.Name,
                        Duration = e.AvailableProgram.Program.DurationTime
                    }
                }).ToList()
            }).FirstOrDefaultAsync();
        
        if (customerPurchases is null)
            throw new NotFoundException();
        
        return customerPurchases;
    }

    public async Task AddWashingMachine(AddWashingMachineDto dto)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            var machineWithId = await _context.WashingMachines
                .FirstOrDefaultAsync(o => o.SerialNumber == dto.WashingMachine.SerialNumber);
            
            if (machineWithId != null)
                throw new ConflictException("Washing machine with that serial number already exists");

            if (dto.WashingMachine.MaxWeight < 8)
            {
                throw new ConflictException("Washing machine must have a minimum weight of 8");
            }
            
            var washingMachineEntityEntry = await _context.WashingMachines.AddAsync(new WashingMachine()
            {
                MaxWeight = dto.WashingMachine.MaxWeight,
                SerialNumber = dto.WashingMachine.SerialNumber
            });

            var washingMachineId = washingMachineEntityEntry.Entity.WashingMachineId;

            foreach (var program in dto.AvailablePrograms)
            {
                var checkProgram = await _context.Programs.FirstOrDefaultAsync(x => x.Name == program.ProgramName);
                if (checkProgram is null)
                    throw new NotFoundException($"Program {program.ProgramName} does not exist");

                if (program.Price > 25)
                {
                    throw new ConflictException($"Program {program.ProgramName} price is too large");
                }
                
                await _context.AvailablePrograms.AddAsync(new AvailableProgram()
                {
                    WashingMachineId = washingMachineId,
                    ProgramId = checkProgram.ProgramId,
                    Price = program.Price
                });
            }

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}