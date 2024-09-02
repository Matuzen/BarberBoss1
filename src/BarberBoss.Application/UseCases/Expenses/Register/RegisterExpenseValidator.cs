using BarberBoss.Communication.Requests;
using FluentValidation;

namespace BarberBoss.Application.UseCases.Expenses.Register;
public class RegisterExpenseValidator : AbstractValidator<RequestRegisterExpenseJSon>
{
    public RegisterExpenseValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("The title is required");
        RuleFor(x => x.Amount).GreaterThan(0).WithMessage("The Amount must be greater than zero");
        RuleFor(x => x.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Expenses cannot be for the future");
        RuleFor(x => x.Type).IsInEnum().WithMessage("Payment Type is not valid");
    }
}
