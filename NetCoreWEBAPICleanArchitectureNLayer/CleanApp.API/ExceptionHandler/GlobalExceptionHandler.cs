using System.Net;
using CleanApp.Application;
using Microsoft.AspNetCore.Diagnostics;

namespace CleanApp.API.ExceptionHandler
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var errorasDto = ServiceResult.Fail(exception.Message, HttpStatusCode.InternalServerError);

            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            httpContext.Response.ContentType = "application/json";

            await httpContext.Response.WriteAsJsonAsync(errorasDto, cancellationToken: cancellationToken);

            return true;
        }
    }
}
