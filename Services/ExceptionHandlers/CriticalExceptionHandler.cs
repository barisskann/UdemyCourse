using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace Services.ExceptionHandlers;

public class CriticalExceptionHandler : IExceptionHandler
{
    public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        //hata alması durumudna business akış için önemli
        if (exception is CriticalException)
        {
            Console.WriteLine("Hata mesajı gösterildi");
        }
        return ValueTask.FromResult(false);
    }
}
