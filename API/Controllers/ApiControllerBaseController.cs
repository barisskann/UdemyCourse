using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Net;
using System.Runtime.CompilerServices;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApiControllerBaseController : ControllerBase
{
    [NonAction]
    public IActionResult CreateActionResult<T>(ServiceResult<T> request)
    {
        return request.StatusCode switch
        {
            HttpStatusCode.NoContent => NoContent(),
            HttpStatusCode.Created => Created(),
            _ => new ObjectResult(request.Data) { StatusCode = (int)request.StatusCode }
        };
    }

    [NonAction]
    public IActionResult CreateActionResult(ServiceResult request)
    {
        return request.StatusCode switch
        {
            HttpStatusCode.NoContent => NoContent(),
            HttpStatusCode.Created => Created(),
            _ => new ObjectResult(null) { StatusCode = (int)request.StatusCode }
        };
    }
}
