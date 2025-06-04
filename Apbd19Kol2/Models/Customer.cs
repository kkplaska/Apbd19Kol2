using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apbd19Kol2.Models;

[Table("Customer")]
public class Customer
{
    [Key]
    public int CustomerId { get; set; }
    [MaxLength(50)]
    public string FirstName { get; set; } = null!;
    [MaxLength(100)]
    public string LastName { get; set; } = null!;
    [MaxLength(100)]
    public string? PhoneNumber { get; set; } = null!;

    public ICollection<PurchaseHistory> PurchaseHistories  { get; set; } = null!;
}