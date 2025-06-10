using APBD_Przygotowanie_Kolos2A.Models;

namespace APBD_Przygotowanie_Kolos2A.DTO;

public class CustomerPurchasesDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public List<PurchasesDto> Purchases { get; set; }
}

public class PurchasesDto
{
    public DateTime Date { get; set; }
    public int? Rating { get; set; }
    public decimal Price { get; set; }
    public WashingMachineDto WashingMachine { get; set; }
    public ProgramDto Program { get; set; }
}

public class WashingMachineDto
{
    public string Serial { get; set; }
    public decimal MaxWeight { get; set; }
}

public class ProgramDto
{
    public string Name { get; set; }
    public int Duration { get; set; }
}