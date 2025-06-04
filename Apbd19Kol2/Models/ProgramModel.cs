using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Apbd19Kol2.Models;

[Table("Program")]
public class ProgramModel
{
    [Key]
    public int ProgramId { get; set; }

    [MaxLength(50)] 
    public string Name { get; set; } = null!;

    public int DurationTime { get; set; }
    public int TemperatureCelsius { get; set; }
    
    public ICollection<AvailableProgram> AvailablePrograms { get; set; } = null!;
}