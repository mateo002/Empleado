using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PruebaTecnicaRenting.Application.Exceptions;

namespace PruebaTecnicaRenting.WebApi.Base.Filters;

[AttributeUsage(AttributeTargets.All)]
public sealed class AppExceptionFilterAttribute : ExceptionFilterAttribute
{
    public AppExceptionFilterAttribute()
    {
    }

    public override void OnException(ExceptionContext context)
    {
        if (context != null)
        {
            context.HttpContext.Response.StatusCode = context.Exception switch
            {
                NotFoundException => ((int)HttpStatusCode.NotFound),
                ValidationException => ((int)HttpStatusCode.BadRequest),
                _ => ((int)HttpStatusCode.InternalServerError)
            };

            var msg = new
            {
                context.Exception.Message
            };

            context.Result = new ObjectResult(msg);
        }
    }
}
