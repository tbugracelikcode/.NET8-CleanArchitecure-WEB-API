using CleanApp.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace CleanApp.API.ExceptionHandler
{
    public class CriticalExceptionHandler : IExceptionHandler
    {
        public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
           if(exception is CriticalException)
            {
                Console.WriteLine("An SMS has sent which is about the error.");
            }

            return ValueTask.FromResult(false);
        }
    }
}
