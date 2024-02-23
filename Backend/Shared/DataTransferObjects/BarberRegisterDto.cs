using System.ComponentModel.DataAnnotations;
using Shared.Enums;

namespace Shared.DataTransferObjects;

public class BarberRegisterDto
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public Gender Gender { get; set; }
}
