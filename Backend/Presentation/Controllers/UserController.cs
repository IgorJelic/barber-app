using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Shared.DataTransferObjects;

namespace Presentation.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IServiceManager _serviceManager;
    public UserController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    [HttpPost("login")]
    public ActionResult<string> UserLogin([FromBody]LoginDto login)
    {
        var token = _serviceManager.UserService.Login(login);

        return Ok(token);
    }
}
