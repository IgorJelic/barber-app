using System.ComponentModel.DataAnnotations.Schema;
using Shared.Enums;

namespace Domain.Entities;

public class Barber
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public Gender Gender { get; set; }
    public double Rating { get; set; } = 0.0;
    public int AppointmentsCount { get; set; } = 0;
    public List<Appointment> MyAppointments { get; set; } = new List<Appointment>();
    public bool IsDeleted { get; set; } = false;
}
