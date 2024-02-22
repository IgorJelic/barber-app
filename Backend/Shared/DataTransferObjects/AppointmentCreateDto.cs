namespace Shared.DataTransferObjects;

public class AppointmentCreateDto
{
    public Guid BarberId { get; set; }
    // public DateTime AppointmentTime { get; set; }
    public string AppointmentTime { get; set; }
    public string CustomerEmail { get; set; }
    public string CustomerPhone { get; set; }
}
