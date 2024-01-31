using Domain.Repository;
using Services.Abstractions;
using Shared.DataTransferObjects;
using Shared.FilterObjects;

namespace Services;

public class AppointmentService : IAppointmentService
{
    private readonly IRepositoryManager _repositoryManager;
    public AppointmentService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    public List<AppointmentDto> GetAllAppointments(AppointmentFilterObject? filterObject)
    {
        throw new NotImplementedException();
    }

    public AppointmentDto GetAppointmentById(Guid appointmentId)
    {
        throw new NotImplementedException();
    }

    public List<AppointmentDto> GetBarbersAppointments(Guid barberId, AppointmentFilterObject? filterObject)
    {
        throw new NotImplementedException();
    }

    public List<AppointmentDto> GetCustomersAppointments(Guid customerId, AppointmentFilterObject? filterObject)
    {
        throw new NotImplementedException();
    }

}
