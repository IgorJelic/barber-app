using Shared.DataTransferObjects;
using Shared.FilterObjects;

namespace Services.Abstractions;

public interface IAppointmentService
{
    List<AppointmentDto> GetAllAppointments(AppointmentFilterObject? filterObject);
    List<AppointmentDto> GetCustomersAppointments(Guid customerId, AppointmentFilterObject? filterObject);
    List<AppointmentDto> GetBarbersAppointments(Guid barberId, AppointmentFilterObject? filterObject);
    AppointmentDto GetAppointmentById(Guid appointmentId);
}
