using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Shared.FilterObjects;

namespace Persistence.Repository;

public class AppointmentRepository : IAppointmentRepository
{
    private readonly RepositoryDbContext _dbContext;
    public AppointmentRepository(RepositoryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public (int, List<Appointment>) GetAll(AppointmentFilterObject filterObject, Guid? barberId)
    {
        IQueryable<Appointment> appointments = _dbContext.Appointments
                                                .Include(a => a.Barber);

        appointments = barberId.HasValue
            ? appointments.Where(a => a.Barber.Id == barberId)
            : appointments;

        appointments = appointments.Where(a => a.AppointmentTime.Day == filterObject.Day.Day);

        if (filterObject is null) return (appointments.Count(), appointments.ToList());

        var appointmentsCount = appointments.Count();

        appointments = appointments
                .Skip((filterObject.PageNumber - 1) * filterObject.PageSize)
                .Take(filterObject.PageSize);

        return (appointmentsCount, appointments.ToList());
    }


    public Appointment GetById(Guid appointmentId)
    {
        return _dbContext.Appointments
            .Include(a => a.Barber)
            .FirstOrDefault(x => x.Id == appointmentId)!;
    }

    public void Insert(Appointment appointment)
    {
        _dbContext.Appointments.Add(appointment);
    }

}
