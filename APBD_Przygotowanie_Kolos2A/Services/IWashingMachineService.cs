using APBD_Przygotowanie_Kolos2A.DTO;

namespace APBD_Przygotowanie_Kolos2A.Services;

public interface IWashingMachineService
{
    Task AddWashingMachineWithPrograms(AddWashingMachineDto addWashingMachineDto);
}