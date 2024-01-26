using Domain.Entities;

namespace Domain.Repository;

public interface IAppointmentRepository
{
    Appointment GetById(Guid appointmentId);
    void Insert(Appointment appointment);
    
}
