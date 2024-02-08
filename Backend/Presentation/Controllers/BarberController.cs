using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Services.Abstractions;
using Shared.DataTransferObjects;
using Shared.FilterObjects;

namespace Presentation.Controllers;

[ApiController]
[Route("api/barbers")]
public class BarberController : ControllerBase
{
    private readonly int DEFAULT_PAGE_SIZE = 4;
    private readonly int DEFAULT_PAGE_NUMBER = 1;
    private readonly IServiceManager _serviceManager;
    public BarberController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    [HttpGet]
    public ActionResult<List<BarberDto>> GetBarbers([FromQuery] BarberFilterObject? filterObject)
    {
        var (barbersCount, barbers) = _serviceManager.BarberService.GetAllBarbers(filterObject);

        int pageSize = filterObject?.PageSize ?? DEFAULT_PAGE_SIZE;
        int pageCount = (int)Math.Ceiling(barbersCount / (double)pageSize);
        int pageNumber = filterObject?.PageNumber ?? DEFAULT_PAGE_NUMBER;

        return Ok(new
        {
            Barbers = barbers,
            Pages = pageCount,
            PageNumber = pageNumber
        });
    }

    [HttpGet("{id}")]
    public ActionResult<BarberDto> GetBarberById(Guid id)
    {
        var barberDto = _serviceManager.BarberService.GetBarberById(id);

        if (barberDto is null) return NotFound(string.Format("Barber with id '{0}' does not exist.", id));

        return Ok(barberDto);
    }
}
