using APBD_Przygotowanie_Kolos2A.Data;
using APBD_Przygotowanie_Kolos2A.DTO;
using APBD_Przygotowanie_Kolos2A.Exceptions;
using APBD_Przygotowanie_Kolos2A.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_Przygotowanie_Kolos2A.Services;

public class WashingMachineService : IWashingMachineService
{
    private readonly DatabaseContext _context;

    public WashingMachineService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task AddWashingMachineWithPrograms(AddWashingMachineDto addWashingMachineDto)
    {
        using var transaction = _context.Database.BeginTransaction();
        try
        {
            var exists = await _context.WashingMachines.AnyAsync(
                wm => wm.SerialNumber == addWashingMachineDto.WashingMachine.SerialNumber
            );

            if (exists)
            {
                throw new ConflictException($"Washing machine already exists!");
            }

            var washingMachine = new WashingMachine
            {
                MaxWeight = addWashingMachineDto.WashingMachine.maxWeight,
                SerialNumber = addWashingMachineDto.WashingMachine.SerialNumber
            };
            _context.WashingMachines.Add(washingMachine);
            await _context.SaveChangesAsync();

            var WashingProgramsNames = addWashingMachineDto.AvailablePrograms.Select(p =>
                p.ProgramName
            ).ToList();
            var programs = _context.Programs.Where(p => WashingProgramsNames.Contains(p.Name)).ToList();

            if (programs.Count != WashingProgramsNames.Count)
            {
                throw new NotFoundException($"There is no program like that");
            }

            var availablePrgrams = addWashingMachineDto.AvailablePrograms.Select(apDto =>
                {
                    var program = programs.First(p => p.Name == apDto.ProgramName);
                    return new AvailableProgram
                    {
                        WashingMachineId = washingMachine.WashingMachineId,
                        ProgramId = program.ProgramId,
                        Price = apDto.Price
                    };
                }
            ).ToList();

            _context.AvailablePrograms.AddRange(availablePrgrams);

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}