using CashlessRegistration.TokenService.App.Domain.ValueObjects;

namespace CashlessRegistration.TokenService.App.Domain.Services
{
    public interface ITokenGeneratorStrategy
    {
        Token Generate(Card card);
    }
}
