using System;

namespace CashlessRegistration.TokenService.App.Infrastructure.Clock
{
    public interface ITokenClock
    {
        DateTime Now();
    }
}
