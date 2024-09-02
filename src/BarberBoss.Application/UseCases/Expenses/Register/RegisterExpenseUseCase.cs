using BarberBoss.Communication.Requests;
using BarberBoss.Communication.Responses;
using BarberBoss.Exception.ExceptionsBase;

namespace BarberBoss.Application.UseCases.Expenses.Register;
public class RegisterExpenseUseCase
{
    public ResponseExpenseJson Execute(RequestRegisterExpenseJSon request)
    {
        Validate(request);

        return new ResponseExpenseJson();
    }

    public void Validate(RequestRegisterExpenseJSon request)
    {
        var errors = new RegisterExpenseValidator();
        var acessoErros = errors.Validate(request);

        if(acessoErros.IsValid == false)
        {
            var variosErrors = acessoErros.Errors.Select(x => x.ErrorMessage).ToList();

            throw new ErrorOnValidationException(variosErrors);
        }
    }
}
