using System;
using CashlessRegistration.TokenService.App.Domain.Services;
using CashlessRegistration.TokenService.UnitTests.App.Infrastructure;
using FluentAssertions;
using Xunit;

namespace CashlessRegistration.TokenService.UnitTests.App.Domain.Services
{
    public class TokenGeneratorDefaultClockShould
    {
        [Fact]
        public void ReturnDateWithoutSecond()
        {
            //Setup
            var systemClock = new SystemClock();
            var clock = new TokenGeneratorDefaultClock(systemClock);

            //Action
            DateTime now;
            do
            {
                now = clock.Now();
            }
            while(systemClock.UtcNow.Second == 0);
            
            //Asserts
            now.Second.Should().Be(0);
        }
    }
}
