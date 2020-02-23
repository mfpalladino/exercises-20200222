using System;
using Microsoft.Extensions.Internal;

namespace CashlessRegistration.TokenService.UnitTests.App.Infrastructure
{
    public class SystemClock : ISystemClock
    {
        public DateTimeOffset UtcNow => DateTime.UtcNow;
    }
}