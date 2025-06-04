using Apbd19Kol2.DTOs;

namespace Apbd19Kol2.Services;

public interface IDbService
{
    Task<CustomerPurchaseDto> GetPurchasesByCustomerId(int customerId);
    Task AddWashingMachine(AddWashingMachineDto dto);
}