using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Services.ExceptionHandlers;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        ServiceResult ErrorMesage = ServiceResult.Fail(exception.Message, HttpStatusCode.InternalServerError);

        await httpContext.Response.WriteAsJsonAsync(ErrorMesage);
        httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        httpContext.Response.ContentType = "application/json";

        return true;
    }
}
