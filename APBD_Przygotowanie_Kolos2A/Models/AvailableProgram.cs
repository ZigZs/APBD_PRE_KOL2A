using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_Przygotowanie_Kolos2A.Models;

[Table("Available_Program")]
public class AvailableProgram
{
    [Key] public int AvailableProgramId { get; set; }
    [ForeignKey(nameof(WashingMachine))] public int WashingMachineId { get; set; }
    [ForeignKey(nameof(WashingProgram))] public int ProgramId { get; set; }
    [Required] public decimal Price { get; set; }
    
    public WashingMachine WashingMachine { get; set; }
    public WashingProgram WashingProgram { get; set; }
}