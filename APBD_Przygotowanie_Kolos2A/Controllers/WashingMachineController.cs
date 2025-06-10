using APBD_Przygotowanie_Kolos2A.DTO;
using APBD_Przygotowanie_Kolos2A.Exceptions;
using APBD_Przygotowanie_Kolos2A.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_Przygotowanie_Kolos2A.Controllers;

[Route("washing-machines")]
[ApiController]
public class WashingMachineController : ControllerBase
{
    private readonly IWashingMachineService _washingMachineService;

    public WashingMachineController(IWashingMachineService washingMachineService)
    {
        _washingMachineService = washingMachineService;
    }

    [HttpPost]
    public async Task<IActionResult> AddWashingMachine([FromBody] AddWashingMachineDto addWashingMachineDto)
    {
        try
        {
            if (addWashingMachineDto == null)
            {
                return BadRequest("Post nie może być pusty");
            }

            if (addWashingMachineDto.WashingMachine.maxWeight < 8)
            {
                return BadRequest("Maksymalna dopuszczalna waga nie może być mniejsza niż 8");
            }

            foreach (var VARIABLE in addWashingMachineDto.AvailablePrograms)
            {
                if (VARIABLE.Price > 25)
                {
                    return BadRequest("Cena programu nie może przekraczać 25");
                }
            }
            

            await _washingMachineService.AddWashingMachineWithPrograms(addWashingMachineDto);
            return Created(string.Empty, addWashingMachineDto);
        }
        catch (ConflictException e)
        {
            return Conflict(e.Message);
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