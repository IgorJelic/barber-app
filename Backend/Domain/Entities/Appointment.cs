namespace Domain.Entities;

public class Appointment
{
    public Guid Id { get; set; }
    public Guid BarberId { get; set; }
    public Barber Barber { get; set; }
    public string CustomerEmail { get; set; }
    public string CustomerPhone { get; set; }
    public DateTime AppointmentTime { get; set; }
    public short? Rating { get; set; }
    public bool IsCanceled { get; set; }
}
