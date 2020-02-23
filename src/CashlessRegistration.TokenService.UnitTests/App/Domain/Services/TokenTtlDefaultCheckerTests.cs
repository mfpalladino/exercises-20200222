using System;
using CashlessRegistration.TokenService.App.Domain.Services;
using FluentAssertions;
using Moq;
using Xunit;

namespace CashlessRegistration.TokenService.UnitTests.App.Domain.Services
{
    public class TokenTtlDefaultCheckerTests
    {
        private readonly DateTime _now;
        private readonly TokenTtlDefaultChecker _checker;

        public TokenTtlDefaultCheckerTests()
        {
            //Setup
            _now = DateTime.Now;

            var clock = new Mock<ITokenGeneratorClock>();
            clock.Setup(x => x.Now()).Returns(_now);

            _checker = new TokenTtlDefaultChecker(clock.Object);
        }

        [Fact]
        public void ReturnFalseWhenGeneratedDateHasMoreThan15Minutes()
        {
            //Action
            var result = _checker.IsValid(_now.AddMinutes(-16));

            //Asserts
            result.Should().BeFalse();
        }

        [Fact]
        public void ReturnTrueWhenGeneratedDateHasLessThan15Minutes()
        {
            //Action
            var result = _checker.IsValid(_now.AddMinutes(-14));

            //Asserts
            result.Should().BeTrue();
        }

        [Fact]
        public void ReturnTrueWhenGeneratedDateIsEqual15Minutes()
        {
            //Action
            var result = _checker.IsValid(_now.AddMinutes(-15));

            //Asserts
            result.Should().BeTrue();
        }
    }
}