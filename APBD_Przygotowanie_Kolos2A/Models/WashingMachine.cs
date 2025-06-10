using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_Przygotowanie_Kolos2A.Models;

[Table("Washing_Machine")]
public class WashingMachine
{
    [Key] public int WashingMachineId { get; set; }
    [Required] public decimal MaxWeight { get; set; }
    [Required] [MaxLength(100)] public string SerialNumber { get; set; }
}