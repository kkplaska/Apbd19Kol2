using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Apbd19Kol2.Models;

[Table("Available_Program")]
public class AvailableProgram
{
    [Key]
    public int AvailableProgramId { get; set; }
    
    [ForeignKey(nameof(WashingMachine))]
    public int WashingMachineId { get; set; }
    [ForeignKey(nameof(Program))]
    public int ProgramId { get; set; }
    
    [Column(TypeName = "numeric")]
    [Precision(10, 2)]
    public double Price { get; set; }

    public WashingMachine WashingMachine { get; set; }
    public ProgramModel Program { get; set; }
    
    public ICollection<PurchaseHistory> PurchaseHistories { get; set; } = null!;
}