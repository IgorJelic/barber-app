namespace Domain.Entities;

public class Customer
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public bool Activated { get; set; }
    
    public List<Appointment> MyAppointments { get; set; }
    public bool IsDeleted { get; set; }
    
}
