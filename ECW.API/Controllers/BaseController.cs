using Microsoft.AspNetCore.Mvc;

namespace ECW.API.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class BaseController : ControllerBase
{
    public BaseController()
    {
    }
}