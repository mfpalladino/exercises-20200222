using CashlessRegistration.TokenService.App.Domain.ValueObjects;

namespace CashlessRegistration.TokenService.App.Domain.Services
{
    public interface ITokenGenerator
    {
        Token Generate(Card card);
        bool IsValid(Card card, long token);
    }
}
