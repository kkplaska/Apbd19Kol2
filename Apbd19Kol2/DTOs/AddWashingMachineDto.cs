namespace Apbd19Kol2.DTOs;

public class AddWashingMachineDto
{
    public WashingMachineDto WashingMachine { get; set; }
    public List<AvaialbleProgramDto> AvaialblePrograms { get; set; }
}

public class WashingMachineToAddDto
{
    public string SerialNumber { get; set; } = null!;
    public double MaxWeight { get; set; }
}

public class AvaialbleProgramDto
{
    public string ProgramName { get; set; } = null!;
    public double Price { get; set; }
}