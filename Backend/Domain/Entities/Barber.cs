namespace Domain.Entities;

public class Barber
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public bool IsDeleted { get; set; } = false;
}