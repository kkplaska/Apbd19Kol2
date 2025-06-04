namespace Apbd19Kol2.DTOs;

public class CustomerPurchaseDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public List<PurchaseDto> Purchases { get; set; } = null!;
}