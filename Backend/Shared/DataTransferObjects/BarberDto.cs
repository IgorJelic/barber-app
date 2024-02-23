using System.ComponentModel.DataAnnotations;
using Shared.Enums;

namespace Shared.DataTransferObjects;

public class BarberDto
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public Gender Gender { get; set; }
    public double Rating { get; set; }
    public List<AppointmentDto> MyAppointments { get; set; }
}
