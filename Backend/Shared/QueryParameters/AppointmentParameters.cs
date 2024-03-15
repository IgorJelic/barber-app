namespace Shared.FilterObjects;

public class AppointmentParameters : QueryStringParameters
{
    public DateTime Day { get; set; } = DateTime.Today;
}
