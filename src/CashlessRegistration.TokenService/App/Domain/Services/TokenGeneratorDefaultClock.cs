using System;
using Microsoft.Extensions.Internal;

namespace CashlessRegistration.TokenService.App.Domain.Services
{
    public class TokenGeneratorDefaultClock : ITokenGeneratorClock
    {
        private readonly ISystemClock _systemClock;

        public TokenGeneratorDefaultClock(ISystemClock systemClock)
        {
            _systemClock = systemClock ?? throw new ArgumentNullException(nameof(systemClock));
        }

        public DateTime Now()
        {
            var utcNow = _systemClock.UtcNow.DateTime;
            return new DateTime(utcNow.Year, utcNow.Month, utcNow.Day, utcNow.Hour, utcNow.Minute, 0, DateTimeKind.Utc);
        }
    }

}