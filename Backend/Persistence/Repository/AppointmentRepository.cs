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

    public List<Appointment> GetAll(AppointmentFilterObject? filterObject, Guid? customerId, Guid? barberId)
    {
        IQueryable<Appointment> appointments = _dbContext.Appointments
                                                .Include(a => a.Barber)
                                                .Include(a => a.Customer);

        appointments = customerId.HasValue
            ? appointments.Where(a => a.Customer.Id == customerId)
            : appointments;

        appointments = barberId.HasValue
            ? appointments.Where(a => a.Barber.Id == barberId)
            : appointments;

        if (filterObject is null) return appointments.ToList();

        appointments = (filterObject.PageSize is not null) && (filterObject.PageNumber is not null)
            ? appointments
                .Skip(((short)filterObject.PageNumber - 1) * (short)filterObject.PageSize)
                .Take((short)filterObject.PageSize)
            : appointments;

        return appointments.ToList();
    }


    public Appointment GetById(Guid appointmentId)
    {
        return _dbContext.Appointments
            .Include(a => a.Customer)
            .Include(a => a.Barber)
            .FirstOrDefault(x => x.Id == appointmentId)!;
    }

    public void Insert(Appointment appointment)
    {
        var exists = _dbContext.Appointments.Any(
            (x =>
            x.AppointmentTime == appointment.AppointmentTime &&
            x.Barber.Id == appointment.Barber.Id));

        if (!exists) _dbContext.Appointments.Add(appointment);
    }

}
