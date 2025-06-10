using APBD_Przygotowanie_Kolos2A.DTO;

namespace APBD_Przygotowanie_Kolos2A.Services;

public interface ICustomerService
{
    Task<CustomerPurchasesDto> GetCustomerPurchases(int id);
}