using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects;

public class AppointmentCreateDto
{
    [Required]
    public Guid BarberId { get; set; }
    [Required]
    public string AppointmentTime { get; set; }
    [Required]
    public string CustomerEmail { get; set; }
    [Required]
    public string CustomerPhone { get; set; }
}
