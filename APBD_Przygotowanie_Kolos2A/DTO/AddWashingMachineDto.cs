using APBD_Przygotowanie_Kolos2A.Models;

namespace APBD_Przygotowanie_Kolos2A.DTO;

public class AddWashingMachineDto
{
    public WashingMAchineDto WashingMachine { get; set; }
    public List<AvailableProgramDto> AvailablePrograms { get; set; }
}

public class WashingMAchineDto
{
    public decimal maxWeight { get; set; }
    public string SerialNumber { get; set; }
}

public class AvailableProgramDto
{
    public string ProgramName { get; set; }
    public decimal Price { get; set; }
}