using Domain.Entities;
using Shared.FilterObjects;

namespace Domain.Repository;

public interface IAppointmentRepository
{
    List<Appointment> GetAll(AppointmentFilterObject? filterObject, Guid? customerId, Guid? barberId);
    Appointment GetById(Guid appointmentId);
    void Insert(Appointment appointment);
}
