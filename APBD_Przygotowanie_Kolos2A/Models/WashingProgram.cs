using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_Przygotowanie_Kolos2A.Models;

[Table("Program")]
public class WashingProgram
{
    [Key] public int ProgramId { get; set; }
    [Required] [MaxLength(50)] public string Name { get; set; }
    [Required] public int DurationMinutes { get; set; }
    [Required] public int TemperatureCelsius { get; set; }
}