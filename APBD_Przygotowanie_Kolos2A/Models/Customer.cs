using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_Przygotowanie_Kolos2A.Models;

[Table("Customer")]
public class Customer
{
    [Key] public int CustomerId { get; set; }
    [Required] [MaxLength(50)] public string FirstName { get; set; }
    [Required] [MaxLength(100)] public string LastName { get; set; }
    [MaxLength(100)] public string? PhoneNumber { get; set; }
}