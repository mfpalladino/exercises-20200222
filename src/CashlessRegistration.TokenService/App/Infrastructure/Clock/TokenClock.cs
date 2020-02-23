using System;
using Microsoft.Extensions.Internal;

namespace CashlessRegistration.TokenService.App.Infrastructure.Clock
{
    public class TokenClock : ITokenClock
    {
        private readonly ISystemClock _systemClock;

        public TokenClock(ISystemClock systemClock)
        {
            _systemClock = systemClock;
        }

        public DateTime Now()
        {
            var utcNow = _systemClock.UtcNow.DateTime;
            return new DateTime(utcNow.Year, utcNow.Month, utcNow.Day, utcNow.Hour, utcNow.Minute, 0, DateTimeKind.Utc);
        }
    }
}