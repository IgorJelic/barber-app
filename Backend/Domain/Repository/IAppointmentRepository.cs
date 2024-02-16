using Domain.Entities;
using Shared.FilterObjects;

namespace Domain.Repository;

public interface IAppointmentRepository
{
    (int appointmentsCount, List<Appointment> appointments) GetAll(AppointmentFilterObject filterObject, Guid? customerId, Guid? barberId);
    Appointment GetById(Guid appointmentId);
    Appointment Insert(Appointment appointment);
}
