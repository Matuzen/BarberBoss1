using BarberBoss.Communication.Enums;
using BarberBoss.Communication.Requests;
using Bogus;

namespace CommomTestUtilities.Requests;
public class RequestRegisterExpenseJSonBuilder
{
    public static RequestRegisterExpenseJSon Build()
    {
        var faker = new Faker();

        return new Faker<RequestRegisterExpenseJSon>()
            .RuleFor(x => x.Title, faker => faker.Commerce.ProductName())
            .RuleFor(x => x.Description, faker => faker.Commerce.ProductDescription())
            .RuleFor(x => x.Date, faker => faker.Date.Past())
            .RuleFor(x => x.Type, faker => faker.PickRandom<EPagamentType>())
            .RuleFor(x => x.Amount, faker => faker.Random.Decimal(min: 1, max: 1000));
    }
}
