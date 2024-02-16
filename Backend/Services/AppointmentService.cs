using Domain.Repository;
using Services.Abstractions;
using Shared.DataTransferObjects;
using Shared.FilterObjects;
using Mapster;
using Domain.Entities;

namespace Services;

public class AppointmentService : IAppointmentService
{
    private readonly IRepositoryManager _repositoryManager;
    public AppointmentService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }



    public (int, List<AppointmentDto>) GetAllAppointments(AppointmentFilterObject filterObject)
    {
        var (appointmentsCount, appointments) =
            _repositoryManager.AppointmentRepository.GetAll(filterObject: filterObject, null, null);

        return (appointmentsCount, appointments.Adapt<List<AppointmentDto>>());
    }

    public AppointmentDto GetAppointmentById(Guid appointmentId)
    {
        var appointment = _repositoryManager.AppointmentRepository.GetById(appointmentId);

        return appointment.Adapt<AppointmentDto>();
    }

    public (int appointmentsCount, List<AppointmentDto> appointments) GetBarbersAppointments(Guid barberId, AppointmentFilterObject filterObject)
    {
        var (appointmentsCount, appointments) =
            _repositoryManager.AppointmentRepository
                .GetAll(filterObject: filterObject, customerId: null, barberId: barberId);
        return (appointmentsCount, appointments.Adapt<List<AppointmentDto>>());
    }

    public (int appointmentsCount, List<AppointmentDto> appointments) GetCustomersAppointments(Guid customerId, AppointmentFilterObject filterObject)
    {
        var (appointmentsCount, appointments) =
            _repositoryManager.AppointmentRepository
                .GetAll(filterObject: filterObject, customerId: customerId, barberId: null);
        return (appointmentsCount, appointments.Adapt<List<AppointmentDto>>());
    }

    public AppointmentDto CreateAppointment(AppointmentCreateDto appointment, Guid customerId, Guid barberId)
    {
        var newAppointment = appointment.Adapt<Appointment>();
        newAppointment.Barber = _repositoryManager.BarberRepository.GetById(barberId);
        newAppointment.Customer = _repositoryManager.CustomerRepository.GetById(customerId);

        newAppointment = _repositoryManager.AppointmentRepository.Insert(newAppointment);
        _repositoryManager.UnitOfWork.SaveChanges();

        return newAppointment.Adapt<AppointmentDto>();
    }
}
