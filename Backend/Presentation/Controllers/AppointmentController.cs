using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Shared.DataTransferObjects;
using Shared.FilterObjects;

namespace Presentation.Controllers;

[ApiController]
[Route("api/appointments")]
public class AppointmentController : ControllerBase
{
    private readonly IServiceManager _serviceManager;
    public AppointmentController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    [HttpGet]
    public ActionResult<List<AppointmentDto>> GetAppointments([FromQuery] AppointmentFilterObject filterObject)
    {
        var (appointmentsCount, appointments) = _serviceManager.AppointmentService.GetAllAppointments(filterObject);

        int pageSize = filterObject.PageSize;
        int pageCount = (int)Math.Ceiling(appointmentsCount / (double)pageSize);
        int pageNumber = filterObject.PageNumber;

        return Ok(new
        {
            Appointments = appointments,
            Pages = pageCount,
            PageNumber = pageNumber
        });
    }

    [HttpGet("{id}")]
    public ActionResult<AppointmentDto> GetAppointmentById(Guid appointmentId)
    {
        var appointmentDto = _serviceManager.AppointmentService.GetAppointmentById(appointmentId);

        if (appointmentDto is null)
            return NotFound(string.Format("Appointment with id '{0}' does not exist.", appointmentDto));

        return Ok(appointmentDto);
    }

    [HttpPost]
    public ActionResult<AppointmentDto> MakeAppointment([FromBody] AppointmentCreateDto appointment)
    {
        var newAppointment = _serviceManager.AppointmentService.CreateAppointment(appointment);

        return Ok(newAppointment);
        return CreatedAtAction(nameof(GetAppointmentById), new { appointmentId = newAppointment.Id }, newAppointment);
    }

}
