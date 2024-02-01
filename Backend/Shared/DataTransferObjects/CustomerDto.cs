namespace Shared.DataTransferObjects;

public class CustomerDto
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public bool Activated { get; set; }

    public List<AppointmentDto> MyAppointments { get; set; } = new List<AppointmentDto>();
    public bool IsDeleted { get; set; }
}
