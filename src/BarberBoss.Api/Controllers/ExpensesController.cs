using BarberBoss.Application.UseCases.Expenses.Register;
using BarberBoss.Communication.Requests;
using BarberBoss.Communication.Responses;
using BarberBoss.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;

namespace BarberBoss.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{
    [HttpPost]
    public IActionResult Register([FromBody] RequestRegisterExpenseJSon request)
    {
        try
        {
            var useCase = new RegisterExpenseUseCase().Execute(request);

            return Created(string.Empty, useCase);
        }

        catch(ErrorOnValidationException ex)
        {
            var errorMessage = new ResponseErrorJson(ex.Errors);

            return BadRequest(errorMessage);
        }
        catch
        {
            var errorMessage = new ResponseErrorJson("unknown error");
            return StatusCode(StatusCodes.Status500InternalServerError, errorMessage);
        }
    }
}
