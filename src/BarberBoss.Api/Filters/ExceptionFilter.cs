using BarberBoss.Communication.Responses;
using BarberBoss.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BarberBoss.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is BarberBossException)
        {
            HandleException(context);
        }
        else
        {
            UnknownException(context);
        }
    }

    private void HandleException(ExceptionContext context)
    {
        if (context.Exception is ErrorOnValidationException ex)
        {
            var errorMessage = new ResponseErrorJson(ex.Errors);

            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Result = new BadRequestObjectResult(errorMessage);
        }
    }

    private void UnknownException(ExceptionContext context)
    {
        var errorMessage = new ResponseErrorJson("unknown error");

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

        context.Result = new ObjectResult(errorMessage);
    }
}
