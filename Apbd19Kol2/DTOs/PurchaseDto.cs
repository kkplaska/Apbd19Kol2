namespace Apbd19Kol2.DTOs;

public class PurchaseDto
{
    public DateTime Date { get; set; }
    public int? Rating { get; set; }
    public double Price { get; set; }
    public WashingMachineDto WashingMachine { get; set; }
    public ProgramDto ProgramDto { get; set; }
}

public class WashingMachineDto
{
    public string Serial { get; set; }
    public double MaxWeight { get; set; }
}

public class ProgramDto
{
    public string Name { get; set; }
    public int Duration { get; set; }
}