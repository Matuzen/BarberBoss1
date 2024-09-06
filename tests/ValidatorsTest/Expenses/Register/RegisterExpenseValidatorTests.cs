using BarberBoss.Application.UseCases.Expenses.Register;
using BarberBoss.Communication.Enums;
using BarberBoss.Exception;
using CommomTestUtilities.Requests;
using FluentAssertions;

namespace ValidatorsTest.Expenses.Register;
public class RegisterExpenseValidatorTests
{
    [Fact]
    public void Success()
    {
        // Arrange - Cria as instâncias
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseJSonBuilder.Build();

        // Act
        var result = validator.Validate(request);


        // Assert
        result.IsValid.Should().BeTrue();
    }

    [Fact]
    public void Title_Not_Empty()
    {
        // Arrange - Cria as instâncias
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseJSonBuilder.Build();
        request.Title = string.Empty;

        // Act
        var result = validator.Validate(request);


        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(x => x.ErrorMessage.Equals(ResourceErrorMessage.TITLE_REQUIRED));

    }

    [Fact]
    public void Error_Data_Future()
    {
        // Arrange
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseJSonBuilder.Build();
        request.Date = DateTime.UtcNow.AddDays(1);

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(x => x.ErrorMessage.Equals(ResourceErrorMessage.EXPENSES_CANNOT_FOR_THE_FUTURE));
    }

    [Fact]
    public void Error_Payment_Invalid()
    {
        // Arrange
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseJSonBuilder.Build();
        request.Type = (EPagamentType)700;

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(x => x.ErrorMessage.Equals(ResourceErrorMessage.PAYMENT_TYPE_INVALID));

    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-10)]
    public void Error_Amount_Invalid(decimal amount)
    {
        // Arrange
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseJSonBuilder.Build();
        request.Amount = amount;


        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(x => x.ErrorMessage.Equals(ResourceErrorMessage.AMOUNT_MUST_BE_GREATER_THAN_ZERO));
    }

}
