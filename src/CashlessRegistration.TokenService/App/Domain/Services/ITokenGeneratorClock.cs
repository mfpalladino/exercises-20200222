using System;

namespace CashlessRegistration.TokenService.App.Domain.Services
{
    public interface ITokenGeneratorClock
    {
        DateTime Now();
    }
}
