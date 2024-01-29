using Domain.Entities;
using Domain.Repository;

namespace Persistence.Repository;

public class AppointmentRepository : IAppointmentRepository
{
    private readonly RepositoryDbContext _dbContext;
    public AppointmentRepository(RepositoryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Appointment GetById(Guid appointmentId)
    {
        return _dbContext.Appointments.FirstOrDefault(x => x.Id == appointmentId)!;
    }

    public void Insert(Appointment appointment)
    {
        var exists = _dbContext.Appointments.Any(
            (x =>
            x.AppointmentTime == appointment.AppointmentTime &&
            x.BarberId == appointment.BarberId));

        if (!exists) _dbContext.Appointments.Add(appointment);
    }

}
