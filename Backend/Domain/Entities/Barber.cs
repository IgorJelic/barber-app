using System.ComponentModel.DataAnnotations.Schema;
using Shared.Enums;

namespace Domain.Entities;

public class Barber : User
{
    public Gender Gender { get; set; }
    public double Rating { get; set; } = 0;
    public List<Appointment> MyAppointments { get; set; } = new List<Appointment>();
    public bool IsDeleted { get; set; } = false;
}
