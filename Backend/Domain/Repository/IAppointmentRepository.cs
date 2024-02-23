using Domain.Entities;
using Shared.FilterObjects;

namespace Domain.Repository;

public interface IAppointmentRepository
{
    (int appointmentsCount, List<Appointment> appointments) GetAll(AppointmentFilterObject filterObject, Guid? barberId);
    Appointment GetById(Guid appointmentId);
    void Insert(Appointment appointment);
}
