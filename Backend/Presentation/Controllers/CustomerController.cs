using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Shared.DataTransferObjects;

namespace Presentation.Controllers;

[ApiController]
[Route("api/customers")]
public class CustomerController : ControllerBase
{
    private readonly IServiceManager _serviceManager;
    public CustomerController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }


    [HttpPost("appointment")]
    public ActionResult<AppointmentDto> MakeAppointment([FromBody]AppointmentCreateDto appointment){
        var newAppointment = _serviceManager.AppointmentService.CreateAppointment(appointment);

        return CreatedAtAction("GetAppointmentById", "Appointment", new {id = newAppointment.Id }, newAppointment);
    }
}
