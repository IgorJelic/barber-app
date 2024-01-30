using System.ComponentModel.DataAnnotations.Schema;
using Shared.Enums;

namespace Domain.Entities;

public class Barber
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public Gender Gender { get; set; }
    public List<Appointment> MyAppointments { get; set; } = new List<Appointment>();
    public bool IsDeleted { get; set; } = false;

    public double? CalculateRating()
    {
        if (MyAppointments.Any(appointment => appointment.Rating.HasValue))
        {
            return MyAppointments
                .Where(appointment => appointment.Rating.HasValue)
                .Average(appointment => appointment.Rating.Value);
        }
        else
        {
            return null;
        }
    }
}
