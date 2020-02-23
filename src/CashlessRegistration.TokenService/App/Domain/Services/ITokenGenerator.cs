using System;
using CashlessRegistration.TokenService.App.Domain.ValueObjects;

namespace CashlessRegistration.TokenService.App.Domain.Services
{
    public interface ITokenGenerator
    {
        Token Generate(Card card, DateTime baseDateTime);
        bool IsValid(Card card, DateTime baseDateTime, long token);
    }
}
