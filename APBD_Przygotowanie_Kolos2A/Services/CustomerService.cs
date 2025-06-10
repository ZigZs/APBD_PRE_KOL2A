using APBD_Przygotowanie_Kolos2A.Data;
using APBD_Przygotowanie_Kolos2A.DTO;
using APBD_Przygotowanie_Kolos2A.Exceptions;
using APBD_Przygotowanie_Kolos2A.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_Przygotowanie_Kolos2A.Services;

public class CustomerService : ICustomerService
{
    private readonly DatabaseContext _context;

    public CustomerService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<CustomerPurchasesDto> GetCustomerPurchases(int id)
    {
        var customer = await _context.Customers
            .FirstOrDefaultAsync(c => c.CustomerId == id);

        if (customer == null)
        {
            throw new NotFoundException($"Nie znaleziono klient z Id {id}");
        }
        
        
        var purchases = await _context.PurchaseHistories
            .Where(p => p.CustomerId == id)
            .Include(p => p.AvailableProgram)
            .ThenInclude(wp => wp.WashingProgram)
            .Include(p => p.AvailableProgram)
            .ThenInclude(m => m.WashingMachine)
            .ToListAsync();

        return new CustomerPurchasesDto
        {
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            PhoneNumber = customer.PhoneNumber,
            Purchases = purchases.Select(p => new PurchasesDto
            {
                Date = p.PurchaseDate,
                Rating = p.Rating,
                Price = p.AvailableProgram.Price,
                WashingMachine = new WashingMachineDto
                {
                    Serial = p.AvailableProgram.WashingMachine.SerialNumber,
                    MaxWeight = p.AvailableProgram.WashingMachine.MaxWeight
                },
                Program = new ProgramDto
                {
                    Name = p.AvailableProgram.WashingProgram.Name,
                    Duration = p.AvailableProgram.WashingProgram.DurationMinutes
                }

            }).ToList()
        };
    }
    
}