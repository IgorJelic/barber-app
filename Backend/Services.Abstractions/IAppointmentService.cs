using Shared.DataTransferObjects;
using Shared.FilterObjects;

namespace Services.Abstractions;

public interface IAppointmentService
{
    (int appointmentsCount, List<AppointmentDto> appointments) GetAllAppointments(AppointmentFilterObject filterObject);
    (int appointmentsCount, List<AppointmentDto> appointments) GetBarbersAppointments(Guid barberId, AppointmentFilterObject filterObject);
    AppointmentDto GetAppointmentById(Guid appointmentId);
    AppointmentDto CreateAppointment(AppointmentCreateDto appointment);
}
