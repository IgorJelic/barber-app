using Shared.Enums;

namespace Shared.DataTransferObjects;

public class BarberDto
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public Gender Gender { get; set; }
    public List<AppointmentDto> MyAppointments { get; set; } = new List<AppointmentDto>();
    public bool IsDeleted { get; set; } = false;
}
