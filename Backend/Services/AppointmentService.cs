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
            _repositoryManager.AppointmentRepository.GetAll(filterObject: filterObject, null);

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
                .GetAll(filterObject: filterObject, barberId: barberId);
        return (appointmentsCount, appointments.Adapt<List<AppointmentDto>>());
    }


    public AppointmentDto CreateAppointment(AppointmentCreateDto appointment)
    {
        var barber = _repositoryManager.BarberRepository.GetById(appointment.BarberId) ?? throw new Exception();
        var newAppointment = appointment.Adapt<Appointment>();

        bool exists = barber.MyAppointments
            .Any(a => a.AppointmentTime == newAppointment.AppointmentTime);

        if (exists) throw new Exception();

        var securePassword = 

        newAppointment.Barber = barber;

        _repositoryManager.AppointmentRepository.Insert(newAppointment);
        _repositoryManager.UnitOfWork.SaveChanges();

        return newAppointment.Adapt<AppointmentDto>();
    }
}
