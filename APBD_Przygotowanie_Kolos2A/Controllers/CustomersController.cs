using APBD_Przygotowanie_Kolos2A.DTO;
using APBD_Przygotowanie_Kolos2A.Exceptions;
using APBD_Przygotowanie_Kolos2A.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_Przygotowanie_Kolos2A.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomersController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet("{id}/purchases")]
    public async Task<IActionResult> GetCustomerPurchases(int id)
    {
        try
        {
            var result = await _customerService.GetCustomerPurchases(id);
            return Ok(result);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}